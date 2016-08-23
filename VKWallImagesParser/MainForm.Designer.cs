namespace VKWallImagesParser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBtn = new System.Windows.Forms.Button();
            this.groupNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cntNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.parseBtn = new System.Windows.Forms.Button();
            this.parsedCntLabel = new System.Windows.Forms.Label();
            this.downloadImgBtn = new System.Windows.Forms.Button();
            this.downloadedCntLabel = new System.Windows.Forms.Label();
            this.parsedInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cntNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(138, 70);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(67, 42);
            this.checkBtn.TabIndex = 0;
            this.checkBtn.Text = "Старт";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // groupNameTxtBox
            // 
            this.groupNameTxtBox.Location = new System.Drawing.Point(27, 78);
            this.groupNameTxtBox.Name = "groupNameTxtBox";
            this.groupNameTxtBox.Size = new System.Drawing.Size(105, 26);
            this.groupNameTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID/страница стены";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кол-во постов: ";
            // 
            // cntNumericUpDown
            // 
            this.cntNumericUpDown.Location = new System.Drawing.Point(29, 158);
            this.cntNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.cntNumericUpDown.Name = "cntNumericUpDown";
            this.cntNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.cntNumericUpDown.TabIndex = 6;
            // 
            // parseBtn
            // 
            this.parseBtn.Location = new System.Drawing.Point(27, 206);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(178, 37);
            this.parseBtn.TabIndex = 7;
            this.parseBtn.Text = "Парсить";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // parsedCntLabel
            // 
            this.parsedCntLabel.AutoSize = true;
            this.parsedCntLabel.Location = new System.Drawing.Point(249, 81);
            this.parsedCntLabel.Name = "parsedCntLabel";
            this.parsedCntLabel.Size = new System.Drawing.Size(95, 20);
            this.parsedCntLabel.TabIndex = 8;
            this.parsedCntLabel.Text = "Спаршено: ";
            // 
            // downloadImgBtn
            // 
            this.downloadImgBtn.Enabled = false;
            this.downloadImgBtn.Location = new System.Drawing.Point(253, 206);
            this.downloadImgBtn.Name = "downloadImgBtn";
            this.downloadImgBtn.Size = new System.Drawing.Size(178, 37);
            this.downloadImgBtn.TabIndex = 9;
            this.downloadImgBtn.Text = "Скачать";
            this.downloadImgBtn.UseVisualStyleBackColor = true;
            this.downloadImgBtn.Click += new System.EventHandler(this.downloadImgBtn_Click);
            // 
            // downloadedCntLabel
            // 
            this.downloadedCntLabel.AutoSize = true;
            this.downloadedCntLabel.Location = new System.Drawing.Point(249, 163);
            this.downloadedCntLabel.Name = "downloadedCntLabel";
            this.downloadedCntLabel.Size = new System.Drawing.Size(0, 20);
            this.downloadedCntLabel.TabIndex = 10;
            // 
            // parsedInfo
            // 
            this.parsedInfo.AutoSize = true;
            this.parsedInfo.Location = new System.Drawing.Point(249, 122);
            this.parsedInfo.Name = "parsedInfo";
            this.parsedInfo.Size = new System.Drawing.Size(0, 20);
            this.parsedInfo.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 267);
            this.Controls.Add(this.parsedInfo);
            this.Controls.Add(this.downloadedCntLabel);
            this.Controls.Add(this.downloadImgBtn);
            this.Controls.Add(this.parsedCntLabel);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.cntNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupNameTxtBox);
            this.Controls.Add(this.checkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "VKWall Images Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cntNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.TextBox groupNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cntNumericUpDown;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.Label parsedCntLabel;
        private System.Windows.Forms.Button downloadImgBtn;
        private System.Windows.Forms.Label downloadedCntLabel;
        private System.Windows.Forms.Label parsedInfo;
    }
}

