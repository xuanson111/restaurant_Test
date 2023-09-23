using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Controls;

namespace Restaurant.Views
{
    public partial class frmHangTon : Form
    {
        public frmHangTon()
        {
            InitializeComponent();
        }
        ctrHoaDon ctr = new ctrHoaDon();
        public void getData()
        {
            try
            {
                string sqlQuery = "select MaNL as 'Mã nguyên liệu', TenNL as 'Tên nguyên liệu', SoLuong as 'Số lượng', " +
                    "LoaiNL as 'Loại nguyên liệu', HSD as 'Hạn sử dụng', datediff(day, getdate(), HSD) as 'Số ngày còn lại' " +
                    "from NguyenLieu where datediff(day, getdate(), HSD) < 100";
                DataTable dt = ctr.getData(sqlQuery);
                dgvHangTon.DataSource = dt;
            }
            catch (Exception ex) { }
        }
        private void frmHangTon_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            try
            {
                string sqlQuery = "select MaNL as 'Mã nguyên liệu', TenNL as 'Tên nguyên liệu', SoLuong as 'Số lượng', " +
                    "LoaiNL as 'Loại nguyên liệu', HSD as 'Hạn sử dụng', datediff(day, getdate(), HSD) as 'Số ngày còn lại' " +
                    "from NguyenLieu where datediff(day, getdate(), HSD) < 100 and TenNL like N'%" + txtSearch.Text + "%'";
                DataTable dt = ctr.getData(sqlQuery);
                dgvHangTon.DataSource = dt;
            } catch (Exception ex) { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            getData();
        }
    }
}
