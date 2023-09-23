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
using Restaurant.Controls;

namespace Restaurant.Views
{
    public partial class frmBanChay : Form
    {
        public frmBanChay()
        {
            InitializeComponent();
        }

        ctrMonAn ctr = new ctrMonAn();
        private void getData()
        {
            string query = "select ChiTietHD.MaMonAn as 'Mã món ăn', TenMonAn as 'Tên món ăn'," +
                " LoaiMonAn as 'Loại món ăn', sum(SoLuongMon) as 'số lượng bán được' " +
                "from ChiTietHD, HoaDon, MonAn " +
                "where ChiTietHD.MaHD = HoaDon.MaHD " +
                "and ChiTietHD.MaMonAn = MonAn.MaMonAn " +
                "and DATEPART(MONTH, HoaDon.NgayTao) = 1 " +
                "and DATEPART(YEAR, HoaDon.NgayTao) = 2023 " +
                "group by ChiTietHD.MaMonAn, TenMonAn, LoaiMonAn " +
                "order by sum(SoLuongMon) DESC";
            DataTable dt = ctr.getData(query);
            dgvBanChay.DataSource = dt;
        }

        public void loaiMon()
        {
            try
            {
                SqlConnection conn = ctr.GetConnection();
                conn.Open();
                string query = "select distinct LoaiMonAn from MonAn";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string tang = rd.GetString(0);
                    cmbLoaiMon.Items.Add(tang);
                }
                conn.Close();
            }
            catch (System.Exception ex) { }
        }
        private void frmBanChay_Load(object sender, EventArgs e)
        {
            getData();
            loaiMon();
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            try
            {
                string query = "select ChiTietHD.MaMonAn as 'Mã món ăn', TenMonAn as 'Tên món ăn'," +
                    " LoaiMonAn as 'Loại món ăn', sum(SoLuongMon) as 'số lượng bán được' " +
                    "from ChiTietHD, HoaDon, MonAn " +
                    "where ChiTietHD.MaHD = HoaDon.MaHD " +
                    "and ChiTietHD.MaMonAn = MonAn.MaMonAn " +
                    "and DATEPART(MONTH, HoaDon.NgayTao) = 1 " +
                    "and DATEPART(YEAR, HoaDon.NgayTao) = 2023 " +
                    "and TenMonAn like N'%" + txtSearch.Text +"%'" +
                    "group by ChiTietHD.MaMonAn, TenMonAn, LoaiMonAn " +
                    "order by sum(SoLuongMon) DESC";
                DataTable dt = ctr.getData(query);
                dgvBanChay.DataSource = dt;
            }
            catch (System.Exception ex) { }
        }

    }
}
