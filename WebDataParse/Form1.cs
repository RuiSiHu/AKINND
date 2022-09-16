using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Threading;
using System.IO;
namespace WebDataParse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable UrlTable = new DataTable();
        OOPUrl[] Urls = null;
        private delegate void AppendAlum(string AlumMsg,int MsgType);//代理
//        string UAString = "Mozilla/5.0 (compatible; Baiduspider-render/2.0; +http://www.baidu.com/search/spider.html)";

        private void AddAlum(string AlumMsg,int MsgType)
        {

            if (this.InvokeRequired)
            {
                AppendAlum AppendAlumMsg = new AppendAlum(AddAlum);
                this.Invoke(AppendAlumMsg, new object[] { AlumMsg,MsgType });

            }
            else
            {
                this.tabControl1.SelectedIndex = 1;
                //                AlumTabPage.Select();
                this.AlumBox.Text = AlumMsg + "\n" + this.AlumBox.Text;
                if (MsgType == 2)
                {
                    serviceStart = false;
                    ReflushData();
                    ServiceBtn.Text = "启动服务";
                }
            }
        }

        void LoadUrlData(MySqlCommand Comm)
        {
            UrlTable.Rows.Clear();
            Urls = OOPUrl.List(null, "OOPUrl.OOPIndex", Comm);
            for (int i = 0; i < Urls.Length; i++)
            {
                UrlTable.Rows.Add(new object[] { Urls[i].GenBank, Urls[i].LinkUrl.Replace("\\?", "?"), Urls[i].Locus2 + " " + Urls[i].Locus3, Urls[i].Journal1, Urls[i].Pubmed, Urls[i].Organism, Urls[i].PHost, Urls[i].Country, Urls[i].Downloaded == 1 ? "是" : "否" });
            }
            UrlBox.DataSource = UrlTable;
            UrlBox.Columns[0].Width = 300;
            UrlBox.Columns[1].Width = 400;
            UrlBox.Columns[2].Width = 250;
            UrlBox.Refresh();

        }
        void ReflushData()
        {
    
            MySqlConnection Conn = YDFunction.GetConnection();
            MySqlCommand Comm = new MySqlCommand();
            try
            {
                Conn.Open();
                Comm.Connection = Conn;
                /*                Comm.CommandText = "create table OOPConfig(SecondDistance int not null,OOPIndex counter(1,1) not null PRIMARY KEY)";

                               Comm.ExecuteNonQuery();

                                Comm.CommandText = "insert into OOPConfig(SecondDistance)values(5)";

                                Comm.ExecuteNonQuery();
                
                                Comm.CommandText = "create table OOPKW(Txt varchar(255) not null,OOPIndex counter(1,1) not null PRIMARY KEY)";

                                Comm.ExecuteNonQuery();

                                Comm.CommandText = "create table OOPUrl(UrlLink varchar(255) not null,OOPIndex counter(1,1) not null PRIMARY KEY)";

                                Comm.ExecuteNonQuery();
                                */
                LoadUrlData(Comm);
            }
            catch { }
            try
            {
                Conn.Close();
                Comm.Dispose();
                Conn.Dispose();
            }
            catch { }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            UrlTable.Columns.Add("GenBank");
            UrlTable.Columns.Add("网址");
            UrlTable.Columns.Add("LOCUS");
            UrlTable.Columns.Add("JOURNAL");
            UrlTable.Columns.Add("PUBMED");
            UrlTable.Columns.Add("Organism");
            UrlTable.Columns.Add("Host");
            UrlTable.Columns.Add("国家");

            UrlTable.Columns.Add("已下载");

            ReflushData();
        }

        private void AddUrlBtn_Click(object sender, EventArgs e)
        {
            OOPUrlAddForm PForm = new OOPUrlAddForm();
            if (PForm.ShowDialog() == DialogResult.OK)
            {
                MySqlConnection Conn = YDFunction.GetConnection();
                MySqlCommand Comm = new MySqlCommand();
                try
                {
                    Conn.Open();
                    Comm.Connection = Conn;
                    LoadUrlData(Comm);
                }
                catch { }
                try
                {
                    Conn.Close();
                    Comm.Dispose();
                    Conn.Dispose();
                }
                catch { }
            }
        }

        private void DelUrlBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗?!", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (UrlBox.CurrentRow != null)
                {
                    MySqlConnection Conn = YDFunction.GetConnection();
                    MySqlCommand Comm = new MySqlCommand();
                    try
                    {
                        Conn.Open();
                        Comm.Connection = Conn;
                        Urls[UrlBox.CurrentRow.Index].Delete(Comm);
                        Comm.Parameters.Clear();
                        LoadUrlData(Comm);
                    }
                    catch { }
                    try
                    {
                        Conn.Close();
                        Comm.Dispose();
                        Conn.Dispose();
                    }
                    catch { }

                }
            }
        }
        bool serviceStart = false;
        void RunThread()
        {
            serviceStart = true;
            WebClient wc = new WebClient();
//            wc.Headers.Add("User-Agent:" + UAString);
            if (serviceStart)
            {
                MySqlConnection Conn = YDFunction.GetConnection();
                try
                {
                    Conn.Open();
                    MySqlCommand Comm2 = new MySqlCommand();
                    Comm2.Connection = Conn;


                    OOPUrl[] UnDownLoadUrls = OOPUrl.List("OOPUrl.Downloaded=2", "OOPUrl.OOPIndex", Comm2);
                    Comm2.Parameters.Clear();
                    Comm2.Dispose();
                    for (int i = 0; i < UnDownLoadUrls.Length; i++)
                {


                    try
                    {
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Add("Accept: text/html");
                        wc.Headers.Add("Content-Type: text/html");
                        wc.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)");
//                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls ;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        string HtmlContent = wc.DownloadString(UnDownLoadUrls[i].LinkUrl.Replace("\\?", "?"));
                        string res = "下载已完成";
                        bool allPass = true;
                        string Locus2="";
                        string Locus3 = "";
                        string Journal1 = "";
                        string Journal2 = "";
                        string Pubmed = "";
                        string Organism="";
                        string PHost="";
                        string Country="";
                        int Downloaded=1;

                        string ProcessContent=HtmlContent;
                        string PreLOCUS2 = "LOCUS";
                        string AftLOCUS2 = "bp";
                        string AftLOCUS3 = " ";
                        string PrePubmed = "PUBMED";
                        if (HtmlContent.IndexOf(PrePubmed) == -1)
                        {
                            MySqlCommand Comm = new MySqlCommand();
                            Comm.Connection = Conn;
                            UnDownLoadUrls[i].Delete(Comm);
                            Comm.Parameters.Clear();
                            Comm.Dispose();
                            AddAlum("网址[" + UnDownLoadUrls[i].LinkUrl.Replace("\\?", "?") + "]不存在PUBMED，已删除", 1);

                        }
                        else
                        {
                            int FromLoc = ProcessContent.IndexOf(PreLOCUS2);
                            ProcessContent = ProcessContent.Substring(FromLoc + PreLOCUS2.Length).Trim();

                            PreLOCUS2 = " ";
                            FromLoc = ProcessContent.IndexOf(PreLOCUS2);

                            ProcessContent = ProcessContent.Substring(FromLoc + PreLOCUS2.Length).Trim();


                            int ToLoc = -1;
                            ToLoc = ProcessContent.IndexOf(AftLOCUS2);
                            if (ToLoc != -1)
                            {
                                Locus2 = ProcessContent.Substring(0, ToLoc) + " bp";
                                ProcessContent = ProcessContent.Substring(ToLoc + AftLOCUS2.Length).Trim();
                            }

                            ToLoc = -1;
                            ToLoc = ProcessContent.IndexOf(AftLOCUS3);
                            if (ToLoc != -1)
                            {
                                Locus3 = ProcessContent.Substring(0, ToLoc);
                                ProcessContent = ProcessContent.Substring(ToLoc + AftLOCUS3.Length).Trim();
                            }

                            string PreJournal1 = "JOURNAL";
                            string AftJournal1 = " ";
                            string AftJournal2 = " ";


                            FromLoc = ProcessContent.IndexOf(PreJournal1);
                            if (FromLoc != -1)
                            {
                                ProcessContent = ProcessContent.Substring(FromLoc + PreJournal1.Length).Trim();



                                ToLoc = -1;
                                ToLoc = ProcessContent.IndexOf(AftJournal1);
                                if (ToLoc != -1)
                                {
                                    Journal1 = ProcessContent.Substring(0, ToLoc);
                                    ProcessContent = ProcessContent.Substring(ToLoc + AftJournal1.Length).Trim();
                                }

                                ToLoc = -1;
                                ToLoc = ProcessContent.IndexOf(AftJournal2);
                                if (ToLoc != -1)
                                {
                                    Journal1 += " ";
                                    Journal1 += ProcessContent.Substring(0, ToLoc);
                                    ProcessContent = ProcessContent.Substring(ToLoc + AftJournal2.Length).Trim();
                                }
                            }

                            string AftPubmed = "\n";
                            FromLoc = ProcessContent.IndexOf(PrePubmed);
                            if (FromLoc != -1)
                            {
                                ProcessContent = ProcessContent.Substring(FromLoc + PrePubmed.Length).Trim();
                                ToLoc = -1;
                                ToLoc = ProcessContent.IndexOf(AftPubmed);
                                if (ToLoc != -1)
                                {
                                    Pubmed = ProcessContent.Substring(0, ToLoc);
                                    ProcessContent = ProcessContent.Substring(ToLoc + AftPubmed.Length).Trim();
                                }
                            }

                            string PreOrganism = "/organism=\"";
                            string AftOrganism = "\"";
                            FromLoc = ProcessContent.IndexOf(PreOrganism);
                            if (FromLoc != -1)
                            {
                                ProcessContent = ProcessContent.Substring(FromLoc + PreOrganism.Length).Trim();
                                ToLoc = -1;
                                ToLoc = ProcessContent.IndexOf(AftOrganism);
                                if (ToLoc != -1)
                                {
                                    Organism = ProcessContent.Substring(0, ToLoc);
                                    ProcessContent = ProcessContent.Substring(ToLoc + AftOrganism.Length).Trim();
                                }
                            }

                            string PreHost = "/host=\"";
                            string AftHost = "\"";
                            FromLoc = ProcessContent.IndexOf(PreHost);
                            ProcessContent = ProcessContent.Substring(FromLoc + PreHost.Length).Trim();
                            ToLoc = -1;
                            ToLoc = ProcessContent.IndexOf(AftHost);
                            if (ToLoc != -1)
                            {
                                PHost = ProcessContent.Substring(0, ToLoc);
                                ProcessContent = ProcessContent.Substring(ToLoc + AftHost.Length).Trim();
                            }

                            string PreCountry = "/country=\"";
                            string AftCountry = "\"";
                            FromLoc = ProcessContent.IndexOf(PreCountry);
                            if (FromLoc != -1)
                            {
                                ProcessContent = ProcessContent.Substring(FromLoc + PreCountry.Length).Trim();
                                ToLoc = -1;
                                ToLoc = ProcessContent.IndexOf(AftCountry);
                                if (ToLoc != -1)
                                {
                                    Country = ProcessContent.Substring(0, ToLoc);
                                    //       ProcessContent = ProcessContent.Substring(ToLoc + AftCountry.Length).Trim();
                                }
                            }
                            MySqlCommand Comm = new MySqlCommand();
                            Comm.Connection = Conn;


                            UnDownLoadUrls[i].Update(Locus2, Journal1, Pubmed, Organism, PHost, Country, Downloaded, HtmlContent, Locus3, Comm);
                            Comm.Parameters.Clear();
                            Comm.Dispose();
                            /*
                            for (int i2 = 0; i2 < KWs.Length; i2++)
                            {
                                if (content.IndexOf(KWs[i2].Txt) == -1)
                                {
                                    res += "关键字[" + KWs[i2].Txt + "]匹配不成功";
                                    allPass = false;
                                    //          AddAlum("网址[" + UnDownLoadUrls[i] + "]匹配失败,请及时处理");
                                    break;
                                }

                            }*/
                            if (allPass)
                            {
                                res = "匹配完全成功！";
                            }
                            AddAlum("网址[" + UnDownLoadUrls[i].LinkUrl.Replace("\\?", "?") + "]" + res, 1);
                            if (!serviceStart)
                            {
                                break;
                            }
                       }
                        
                     }
                    catch
                    {

                        AddAlum("网址[" + UnDownLoadUrls[i].LinkUrl.Replace("\\?", "?") + "]下载失败,网站或者已下线请及时处理", 1);

                    }
                    if (!serviceStart)
                    {
                        break;
                    }
                }
                    }
                catch { }
                try
                {
                    Conn.Close();
                    Conn.Dispose();
                }
                catch { }
//                Thread.Sleep(YDFunction.SecondDistince);
            }
            serviceStart = false;
            AddAlum("已下载完成", 2);
;

        }
        private void ServiceBtn_Click(object sender, EventArgs e)
        {
            if (!serviceStart)
            {
//                UAString = UABox.Text;
  //              UABox.Enabled = false;
                this.ServiceBtn.Text = "停止服务";
                Thread fThread = new Thread(new ThreadStart(RunThread));
                fThread.Start();
            }
            else
            {
                serviceStart = false;
                this.ServiceBtn.Text = "服务停止中";
            }
        }

        private void ImpBtn_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = File.OpenText(OFD.FileName);
                string Content = sr.ReadToEnd();
                string[] genBanks = Content.Split(new string[] { "\n" }, StringSplitOptions.None);

                MySqlConnection Conn = YDFunction.GetConnection();
                MySqlCommand Comm = new MySqlCommand();
                try
                {
                    Conn.Open();
                    Comm.Connection = Conn;

                    for (int i = 0; i < genBanks.Length; i++)
                    {
                        OOPUrl.Add(genBanks[i], Comm);
                        Comm.Parameters.Clear();
                    }
                    LoadUrlData(Comm);
                }
                catch { }
                try
                {
                    Conn.Close();
                    Comm.Dispose();
                    Conn.Dispose();
                }
                catch { }

            }
        }

        private void UrlAllDelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要全部删除吗?!", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (UrlBox.CurrentRow != null)
                {
                    MySqlConnection Conn = YDFunction.GetConnection();
                    MySqlCommand Comm = new MySqlCommand();
                    try
                    {
                        Conn.Open();
                        Comm.Connection = Conn;
                        OOPUrl.DeleteAll("1=1", Comm);
                        LoadUrlData(Comm);
                    }
                    catch { }
                    try
                    {
                        Conn.Close();
                        Comm.Dispose();
                        Conn.Dispose();
                    }
                    catch { }

                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serviceStart = false;
           
            Application.Exit();
        }

        private void ReflushDataBtn_Click(object sender, EventArgs e)
        {
            ReflushData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serviceStart = false;
            Application.Exit();
        }

    }
}
