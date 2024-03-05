using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKhachSan
{
    public partial class Form1 : Form
    {
        funtion fn = new funtion();
        string query;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            query = "select username, pass from employee where username = '"+txtuser.Text+"'and pass = '"+txtpass.Text+"'";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count !=0)
            {
               
                Form2 form = new Form2();
                this.Hide();
                form.Show();
            }
            else
            {
                labelero.Visible = true;
                txtpass.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
