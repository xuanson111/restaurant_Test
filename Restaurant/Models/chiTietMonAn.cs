using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class chiTietMonAn
    {
        private string maNL;
        private double soLuong;

        public chiTietMonAn(string maNL, double soLuong)
        {
            this.maNL = maNL;
            this.soLuong = soLuong;
        }

        public string MaNL { get => maNL; set => maNL = value; }
        public double SoLuong { get => soLuong; set => soLuong = value; }
    }
}
