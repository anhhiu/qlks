using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKhachSan.UC_uers_control
{
    public partial class UC_themPhong : UserControl
    {
        funtion fn = new funtion();
        string query;
        public UC_themPhong()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_themPhong_Load(object sender, EventArgs e)
        {
            query = "select* from rooms";
            DataSet ds = fn.GetData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text != "" && txtLoaiPhong.Text != "" && txtSoGiuong.Text != "" && txtGiaTien.Text != "")
            {
                string roomno = txtSoPhong.Text;
                string roomtype = txtLoaiPhong.Text;
                string bed = txtSoGiuong.Text;
                string price = txtGiaTien.Text;
                query = "insert into rooms (roomno, roomtype, bed, price) values ('"+roomno+"', '"+roomtype+"', '"+bed+"', '"+price+"')";
                fn.setData(query, "Đã Thêm Thành Công!");

                UC_themPhong_Load(this, null);
                clearAll();

            }
            else
            {
                MessageBox.Show("Xin Vui Lòng Nhập Đầy Đủ Thông Tin.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        public void clearAll()
        {
            txtSoPhong.Clear();
            txtLoaiPhong.SelectedIndex = -1;
            txtSoGiuong.SelectedIndex = -1;
            txtGiaTien.Clear();
        }

        private void UC_themPhong_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_themPhong_Enter(object sender, EventArgs e)
        {
            UC_themPhong_Load(this, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
