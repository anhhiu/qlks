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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            uC_themPhong1.Visible = false;
            uC_FormDangKy1.Visible = false;
            uC_chechout1.Visible = false;
            uC_ThongTinCTKH1.Visible = false;
            uC_NhanVien1.Visible = false;   
            btnThemPhong.PerformClick();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnThemPhong.Left + 50;
            uC_themPhong1.Visible = true;
            uC_themPhong1.BringToFront();
            
        }


        private void btnDangKyKhachHang_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnDangKyKhachHang.Left + 50;
            uC_FormDangKy1.Visible = true;
            uC_FormDangKy1.BringToFront();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnThanhToan.Left + 60;
            uC_chechout1.Visible = true;
            uC_chechout1.BringToFront();
        }

        private void btnThongTinKhachHang_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnThongTinKhachHang.Left + 60;
            uC_ThongTinCTKH1.Visible = true;
            uC_ThongTinCTKH1.BringToFront();
           
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnNhanVien.Left + 60;
            uC_NhanVien1.Visible = true;
            uC_NhanVien1.BringToFront();
        }
    }
}
