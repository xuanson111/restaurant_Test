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
    public partial class monAn : UserControl
    {
        public EventHandler OnSelect = null;
        private string maMon;
        public string loaiMon;
        public monAn()
        {
            InitializeComponent();
        }
        
        public string MaMon { get => maMon; set => maMon = value; }
        public string TenMon { get => tenMon.Text; set => tenMon.Text = value; }
        public string DonGia { get => donGia.Text; set => donGia.Text = value; }
        public Image Img { get => imgMonAn.Image; set => imgMonAn.Image = value; }
        public string LoaiMon { get => loaiMon; set => loaiMon = value; }

        private void imgMonAn_Click_1(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
    }
}
