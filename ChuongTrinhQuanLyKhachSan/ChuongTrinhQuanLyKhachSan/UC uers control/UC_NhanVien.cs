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
    public partial class UC_NhanVien : UserControl
    {
        funtion fn = new funtion();
        string query;
        public UC_NhanVien()
        {
            InitializeComponent();
        }

     

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            getMAXId();
        }

        public void getMAXId()
        {
            query = ("select max(eid) from employee");
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows[0][0].ToString()  != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                txtbyId.Text = (num+1).ToString();
            }
        }

        private void btnDangKiNhanVien_Click(object sender, EventArgs e)
        {
            if(txtTen.Text != "" && txtSDT.Text != "" && txtGioiTinh.Text !="" && txtEmail.Text != "" && txtUserName.Text !="" && txtPassword.Text != "")
            {
                string name = txtTen.Text;
                Int64 mobile = Int64.Parse(txtSDT.Text);
                string gender = txtGioiTinh.Text;
                string email = txtEmail.Text;
                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                query = "insert into employee (ename, mobile, gender, emailid, username, pass) values ('"+name+"',  '"+mobile+"','"+gender+"', '"+email+"','"+userName+"','"+password+"') ";
                fn.setData(query, "Đăng ký thông tin thành công");

                clearAll();
                getMAXId();
            }
        }

        public void clearAll()
        {
            txtTen.Clear();
            txtSDT.Clear();
            txtGioiTinh.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabEmployee.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if(tabEmployee.SelectedIndex ==2)
            {
                setEmployee(guna2DataGridView2);
            }
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.GetData(query);
            dgv.DataSource = ds.Tables[0];

        }

        private void txtXoaNhanVien_Click(object sender, EventArgs e)
        {
           if(txtId.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtId.Text + "";
                    fn.setData(query, "Bạn đã xóa thành công!");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }
         
        }

        private void UC_NhanVien_Leave(object sender, EventArgs e)
        {
            // sau khi roi khoi thi xoa du lieu
            clearAll();
        }
    }
}
