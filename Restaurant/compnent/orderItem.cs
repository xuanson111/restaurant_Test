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
    public partial class orderItem : UserControl
    {
        private string maMon;
        private string tenMon;
        private int soLuong;
        private double donGia;
        private double tongTien;
        public orderItem()
        {
            InitializeComponent();
        }

        public string MaMon { get => maMon; set => maMon = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
    }
}
