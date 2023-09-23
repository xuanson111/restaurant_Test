using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Modals
{
    internal class PhongBan
    {
        private string SoBan;
        private string Tang;
        private string Loai;

        /*public PhongBan(string soBan, string tang, string loai)
        {
            SoBan = soBan;
            Tang = tang;
            Loai = loai;
        }*/

        public string SoBan1 { get => SoBan; set => SoBan = value; }
        public string Tang1 { get => Tang; set => Tang = value; }
        public string Loai1 { get => Loai; set => Loai = value; }
    }
}
