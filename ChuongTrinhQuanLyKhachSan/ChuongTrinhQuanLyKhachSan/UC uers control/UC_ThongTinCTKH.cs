using System;
using System.Collections;
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
    public partial class UC_ThongTinCTKH : UserControl
    {
        funtion fn = new funtion();
        string query;
        public UC_ThongTinCTKH()
        {
            InitializeComponent();
        }

        private void txtTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.SelectedIndex == 0)
            {
                query = "select customer.cid, customer.cname, customer.mobie, customer.nationnality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomno, rooms.roomtype, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid ";
                getRecord(query);
            }
            else if (txtTimKiem.SelectedIndex ==1)
            {
                query = "select customer.cid, customer.cname, customer.mobie, customer.nationnality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomno, rooms.roomtype, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is null";
                getRecord(query);
            }
            else if (txtTimKiem.SelectedIndex ==2)
            {
                query = "select customer.cid, customer.cname, customer.mobie, customer.nationnality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomno, rooms.roomtype, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null ";
                getRecord(query);
            }
        }
        private void getRecord(string query)
        {
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
    }
}
