using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WebDataParse
{
    public partial class OOPUrlAddForm : Form
    {
        public OOPUrlAddForm()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = YDFunction.GetConnection();
            MySqlCommand Comm = new MySqlCommand();
            try
            {
                Conn.Open();
                Comm.Connection = Conn;
                OOPUrl.Add(UrlBox.Text, Comm);
                Comm.Parameters.Clear();
            }
            catch { }
            try
            {
                Conn.Close();
                Comm.Dispose();
                Conn.Dispose();
            }
            catch { }
            MessageBox.Show("保存成功!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
