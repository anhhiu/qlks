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
    public partial class UC_chechout : UserControl
    {
        funtion fn = new funtion();
        string query;
        public UC_chechout()
        {
            InitializeComponent();
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTen.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoPhong.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
             //   txtNgayThanhToan.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
        }

        private void UC_chechout_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobie, customer.nationnality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomno, rooms.roomtype, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobie, customer.nationnality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomno, rooms.roomtype, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '"+txtTen.Text+"%' and chekout = 'NO'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(txtTen.Text != "")
            {
                if(MessageBox.Show("Bạn có muốn thanh toán không", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string cdate = txtNgayThanhToan.Text;
                    query = "update customer set chekout = 'YES', checkout = '"+cdate+"' where cid = '"+id+"' update rooms set booked = 'NO' where roomno = '"+txtSoPhong.Text+"' ";
                    fn.setData(query , "Thanh toán thành công!");
                    UC_chechout_Load(this, null);
                    clearAll();

                }
                else
                {
                    MessageBox.Show("Không có thông tin khách hàng để lựa chọn", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
        public void clearAll()
        {
            txtTen.Clear();
            txtTimKiem.Clear();
            txtSoPhong.Clear();
            txtNgayThanhToan.ResetText();

        }

        private void UC_chechout_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
