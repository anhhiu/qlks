using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKhachSan.UC_uers_control
{
    public partial class UC_FormDangKy : UserControl
    {
        funtion fn = new funtion();
        String query;
        public UC_FormDangKy()
        {
            InitializeComponent();
        }
        public void setComboBox(String query,  ComboBox combo)
        {
            SqlDataReader reader = fn.GetForCombo(query);
            while(reader.Read())
            {
                for(int i = 0;i< reader.FieldCount; i++)
                {
                    combo.Items.Add(reader.GetString(i));
                }
            }
            reader.Close(); 
        }

        private void UC_FormDangKy_Load(object sender, EventArgs e)
        {

        }

        private void txtloaiGiuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLoaiPhong.SelectedIndex = -1;
            txtSoPhong.Items.Clear();
            txtGiatien.Clear();
        }

        private void txtLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoPhong.Items.Clear();
            query = "select roomno from rooms where bed = '"+txtSoGiuong.Text+"' and roomtype = '"+txtLoaiPhong.Text+"' and booked = 'NO' ";
            setComboBox(query, txtSoPhong);
        }
        int rid;
        private void txtSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price, roomid from rooms where roomno = '"+txtSoPhong.Text+"'";
            DataSet ds = fn.GetData(query);
            txtGiatien.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnDangKyKH_Click(object sender, EventArgs e)
        {
            if (txtTen.Text != "" && txtSDT.Text != "" && txtSoPhong.Text != "" && txtGiatien.Text != "" && txtNgaySinh.Text != "" && txtNgayDangKy.Text != "")
            {
                String cname = txtTen.Text;
                String mobie = txtSDT.Text;
                String nationnal = txtQuocTich.Text;
                string gender = txtGioitinh.Text;
                string dod = txtNgaySinh.Text;
                String idroomf = txtid.Text;
                String address = txtDiachi.Text;
                string checkin = txtNgayDangKy.Text;
                
                query = "Insert into customer(cname, mobie, nationnality, gender, dob, idproof, address, checkin, roomid) values ('"+cname+"','"+mobie+"','"+nationnal+"','"+gender+"','"+dod+"','"+idroomf+"','"+address+"','"+checkin+"','"+rid+"') update rooms set booked = 'YES' where roomno = '"+txtSoPhong.Text+"'";
                fn.setData(query, "Phòng "+txtSoPhong.Text+" đã đăng ký thành công.");
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin","Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtTen.Clear();
            txtSDT.Clear();
            txtQuocTich.Clear();
            txtDiachi.Clear();
            txtGioitinh.SelectedIndex = -1;
            txtSoPhong.Items.Clear();
            txtLoaiPhong.SelectedIndex = -1;
            txtSoGiuong.SelectedIndex = -1;
            txtGiatien.Clear();
            txtNgaySinh.ResetText();
            txtid.Clear();
            txtNgayDangKy.ResetText();
        }

        private void UC_FormDangKy_Leave(object sender, EventArgs e)
        {
            clearAll(); 
        }
    }
}
