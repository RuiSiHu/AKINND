namespace WebDataParse
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ReflushDataBtn = new System.Windows.Forms.Button();
            this.UrlAllDelBtn = new System.Windows.Forms.Button();
            this.ImpBtn = new System.Windows.Forms.Button();
            this.DelUrlBtn = new System.Windows.Forms.Button();
            this.AddUrlBtn = new System.Windows.Forms.Button();
            this.UrlBox = new System.Windows.Forms.DataGridView();
            this.LogTabPage = new System.Windows.Forms.TabPage();
            this.AlumBox = new System.Windows.Forms.RichTextBox();
            this.ServiceBtn = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrlBox)).BeginInit();
            this.LogTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.LogTabPage);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1391, 581);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ReflushDataBtn);
            this.tabPage1.Controls.Add(this.UrlAllDelBtn);
            this.tabPage1.Controls.Add(this.ImpBtn);
            this.tabPage1.Controls.Add(this.DelUrlBtn);
            this.tabPage1.Controls.Add(this.AddUrlBtn);
            this.tabPage1.Controls.Add(this.UrlBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1383, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "网址";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ReflushDataBtn
            // 
            this.ReflushDataBtn.Location = new System.Drawing.Point(1308, 133);
            this.ReflushDataBtn.Name = "ReflushDataBtn";
            this.ReflushDataBtn.Size = new System.Drawing.Size(69, 25);
            this.ReflushDataBtn.TabIndex = 6;
            this.ReflushDataBtn.Text = "刷新";
            this.ReflushDataBtn.UseVisualStyleBackColor = true;
            this.ReflushDataBtn.Click += new System.EventHandler(this.ReflushDataBtn_Click);
            // 
            // UrlAllDelBtn
            // 
            this.UrlAllDelBtn.Location = new System.Drawing.Point(1308, 102);
            this.UrlAllDelBtn.Name = "UrlAllDelBtn";
            this.UrlAllDelBtn.Size = new System.Drawing.Size(69, 25);
            this.UrlAllDelBtn.TabIndex = 5;
            this.UrlAllDelBtn.Text = "全删除";
            this.UrlAllDelBtn.UseVisualStyleBackColor = true;
            this.UrlAllDelBtn.Click += new System.EventHandler(this.UrlAllDelBtn_Click);
            // 
            // ImpBtn
            // 
            this.ImpBtn.Location = new System.Drawing.Point(1308, 68);
            this.ImpBtn.Name = "ImpBtn";
            this.ImpBtn.Size = new System.Drawing.Size(69, 25);
            this.ImpBtn.TabIndex = 4;
            this.ImpBtn.Text = "导入";
            this.ImpBtn.UseVisualStyleBackColor = true;
            this.ImpBtn.Click += new System.EventHandler(this.ImpBtn_Click);
            // 
            // DelUrlBtn
            // 
            this.DelUrlBtn.Location = new System.Drawing.Point(1308, 37);
            this.DelUrlBtn.Name = "DelUrlBtn";
            this.DelUrlBtn.Size = new System.Drawing.Size(69, 25);
            this.DelUrlBtn.TabIndex = 3;
            this.DelUrlBtn.Text = "删除";
            this.DelUrlBtn.UseVisualStyleBackColor = true;
            this.DelUrlBtn.Click += new System.EventHandler(this.DelUrlBtn_Click);
            // 
            // AddUrlBtn
            // 
            this.AddUrlBtn.Location = new System.Drawing.Point(1308, 6);
            this.AddUrlBtn.Name = "AddUrlBtn";
            this.AddUrlBtn.Size = new System.Drawing.Size(69, 25);
            this.AddUrlBtn.TabIndex = 2;
            this.AddUrlBtn.Text = "新增";
            this.AddUrlBtn.UseVisualStyleBackColor = true;
            this.AddUrlBtn.Click += new System.EventHandler(this.AddUrlBtn_Click);
            // 
            // UrlBox
            // 
            this.UrlBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UrlBox.Location = new System.Drawing.Point(3, 6);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.RowTemplate.Height = 23;
            this.UrlBox.Size = new System.Drawing.Size(1299, 533);
            this.UrlBox.TabIndex = 1;
            // 
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.AlumBox);
            this.LogTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.Size = new System.Drawing.Size(1383, 555);
            this.LogTabPage.TabIndex = 3;
            this.LogTabPage.Text = "采集日志";
            this.LogTabPage.UseVisualStyleBackColor = true;
            // 
            // AlumBox
            // 
            this.AlumBox.Location = new System.Drawing.Point(0, 0);
            this.AlumBox.Name = "AlumBox";
            this.AlumBox.Size = new System.Drawing.Size(979, 543);
            this.AlumBox.TabIndex = 0;
            this.AlumBox.Text = "";
            // 
            // ServiceBtn
            // 
            this.ServiceBtn.Location = new System.Drawing.Point(652, 599);
            this.ServiceBtn.Name = "ServiceBtn";
            this.ServiceBtn.Size = new System.Drawing.Size(183, 25);
            this.ServiceBtn.TabIndex = 6;
            this.ServiceBtn.Text = "启动服务";
            this.ServiceBtn.UseVisualStyleBackColor = true;
            this.ServiceBtn.Click += new System.EventHandler(this.ServiceBtn_Click);
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 636);
            this.Controls.Add(this.ServiceBtn);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UrlBox)).EndInit();
            this.LogTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button UrlAllDelBtn;
        private System.Windows.Forms.Button ImpBtn;
        private System.Windows.Forms.Button DelUrlBtn;
        private System.Windows.Forms.Button AddUrlBtn;
        private System.Windows.Forms.DataGridView UrlBox;
        private System.Windows.Forms.TabPage LogTabPage;
        private System.Windows.Forms.RichTextBox AlumBox;
        private System.Windows.Forms.Button ServiceBtn;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Button ReflushDataBtn;
    }
}

