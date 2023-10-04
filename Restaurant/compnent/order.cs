using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.compnent
{
    public partial class order : UserControl
    {
        public EventHandler OnChane = null;
        public EventHandler OnDelete = null;
        private string idMon;
        public order()
        {
            InitializeComponent();
        }
        public order(string idMon, string tenMon, string soLuong, string donGia, string tongTien)
        {
            IdMon = idMon;
            TenMon = tenMon;
            SoLuong = soLuong;
            DonGia = donGia;
            TongTien = tongTien;
        }

        public string IdMon { get => idMon; set => idMon = value; }
        public string TenMon { get => tenMon.Text; set => tenMon.Text = value; }
        public string SoLuong { get => txtSoLuong.Text; set => txtSoLuong.Text = value; }
        public string DonGia { get => txtDonGia.Text; set => txtDonGia.Text = value;} 
        public string TongTien { get => lblTong.Text; set => lblTong.Text = value; }

        private void txtSoLuong_TextChange(object sender, EventArgs e)
        {
            OnChane?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDelete?.Invoke(this, e);
        }
    }
}
