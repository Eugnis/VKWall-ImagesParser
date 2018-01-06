using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace VKWallImagesParser
{
    public partial class MainForm : Form
    {
        private List<Tuple<string, string>> _links;
        private const string ApiPage = "https://api.vk.com/method/";
        private const string ServiceKey = "4f93df004f93df004f93df00764fc6b31d44f934f93df0015c367b4fac65ac4285a66cb";

        public MainForm()
        {
            InitializeComponent();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            if (groupNameTxtBox.Text != "")
            {
                var wallPageName = groupNameTxtBox.Text;
                var pCount = decimal.Parse(GetWallPostsCount(wallPageName).ToString());
                cntNumericUpDown.Value = cntNumericUpDown.Maximum = pCount;
                parseBtn.Enabled = true;
            }
            else MessageBox.Show("Заполните поле!");

        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += Parse_DoWork;
            worker.RunWorkerCompleted += Parse_RunWorkerCompleted;
            worker.RunWorkerAsync(new Tuple<string, int>(groupNameTxtBox.Text, int.Parse(cntNumericUpDown.Text)));
        }

        private void Parse_DoWork(object sender, DoWorkEventArgs e)
        {
            var pp = (Tuple<string, int>) e.Argument;
            var links = GetWallPostsImagesLinks(pp.Item1, pp.Item2);
            e.Result = links;
        }

        private void Parse_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var res = (List<Tuple<string, string>>) e.Result;
            _links = new List<Tuple<string, string>>();
            _links = res;
            downloadImgBtn.Enabled = true;
        }

        private int GetWallPostsCount(string wallPageName)
        {
            var https = new Https();
            var count = 0;
            const string method = "wall.get";
            var vkParams = new NameValueCollection
            {
                {"access_token", ServiceKey },
                {"v", "5.53"},
                {"domain", wallPageName}
            };
            var response = https.POST(ApiPage + method, new CookieContainer(), vkParams);
            try
            {
                count = int.Parse(JObject.Parse(response.Content)["response"]["count"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неправильный адрес стены / страница не общедоступна");
                //throw;
            }
            

            return count;
        }

        private List<Tuple<string, string>> GetWallPostsImagesLinks(string wallPageName, int quantity)
        {
            var https = new Https();
            var links = new List<Tuple<string, string>>();
            
            const string method = "wall.get";
            var proceedCount = 0;
            while (proceedCount < quantity)
            {
                var curCount = quantity - proceedCount;
                if (curCount > 100) curCount = 100;
                //else curCount = quantity - proceedCount;
                var vkParams = new NameValueCollection
                {
                    {"access_token", ServiceKey },
                    {"v", "5.53"},
                    {"domain", wallPageName},
                    {"count", curCount.ToString()},
                    {"offset", proceedCount.ToString()}
                };
                var response = https.POST(ApiPage + method, new CookieContainer(), vkParams);
                
                foreach (var jo in JObject.Parse(response.Content)["response"]["items"])
                {
                    if (jo["attachments"] == null) continue;
                    var imgName = "wallid" + jo["id"];
                    var tImageName = imgName;
                    var jj = jo["attachments"] ?? jo["copy_history"]["attachments"];
                    var attCnt = 1;
                    foreach (var jo1 in jj)
                    {
                        imgName += "_" + attCnt++;
                        if (!jo1["type"].ToString().Equals("photo")) continue;
                        if (jo1["photo"]["photo_2560"] != null)
                            links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_2560"].ToString()));
                        else if (jo1["photo"]["photo_1280"] != null)
                            links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_1280"].ToString()));
                        else if (jo1["photo"]["photo_807"] != null)
                            links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_807"].ToString()));
                        else if (jo1["photo"]["photo_604"] != null)
                            links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_604"].ToString()));
                        else links.Add(new Tuple<string, string>(imgName, jo1["photo"]["photo_130"].ToString()));
                        imgName = tImageName;
                    }
                }

                proceedCount += curCount;
                parsedCntLabel.Invoke(() => { parsedCntLabel.Text = "Спаршено: " + proceedCount + " из " + quantity; });
                parsedInfo.Invoke(() => { parsedInfo.Text = "(найдено " + links.Count + " изображений)"; });
            }
            return links;
        }

        private void downloadImgBtn_Click(object sender, EventArgs e)
        {
            var FBD = new FolderBrowserDialog();
            
            if (FBD.ShowDialog() != DialogResult.OK) return;
            downloadImgBtn.Text = "Скачиваем...";
            downloadImgBtn.Enabled = false;
            parseBtn.Enabled = false;
            checkBtn.Enabled = false;
            var worker = new BackgroundWorker();
            worker.DoWork += Download_DoWork;
            worker.RunWorkerCompleted += Download_RunWorkerCompleted;
            worker.RunWorkerAsync(FBD.SelectedPath);
        }

        private void Download_DoWork(object sender, DoWorkEventArgs e)
        {
            var folder = (string) e.Argument;
            var cnt = 0;
            var errCnt = 0;
            foreach (var imgLink in _links)
            {
                var localFilename = folder + "\\" + imgLink.Item1 + ".jpg";
                cnt++;
                var isError = false;
                using (var client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(imgLink.Item2, localFilename);
                    }
                    catch (WebException)
                    {
                        //MessageBox.Show(imgLink + " не рабочая");
                        isError = true;
                        errCnt++;
                    } 
                }

                downloadedCntLabel.Invoke(
                    () =>
                    {
                        downloadedCntLabel.Text = "Скачано: " + cnt + " из " + _links.Count;
                        if (errCnt > 0) downloadedCntLabel.Text += " (" + errCnt + " ошибок)";
                    });
                if (isError) continue;
            }
            e.Result = folder;
        }

        private void Download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var res = (string) e.Result;
            downloadImgBtn.Text = "Скачать";
            parseBtn.Enabled = true;
            downloadImgBtn.Enabled = true;
            checkBtn.Enabled = true;
            Process.Start(res);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            parseBtn.Enabled = false;
        }
    }

    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            if (control.InvokeRequired) control.Invoke(new MethodInvoker(action), null);
            else action.Invoke();
        }
    }
}
