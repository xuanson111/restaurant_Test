using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Documents;
using System.Windows.Forms;
using Restaurant.Controls;

namespace Restaurant.Views
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        ctrHoaDon ctr = new ctrHoaDon();
        public string MaHD, MaNV, NgayTao, SoBan;
        public void getData()
        {
            try
            {
                string sqlQuery = "select MaHD as 'Mã hóa đơn', MaNV as 'Mã nhân viên', NgayTao as 'Ngày tạo', SoBan as'Số bàn' from HoaDon";
                DataTable dt = ctr.getData(sqlQuery);
                dgvHoaDon.DataSource = dt;
            } catch (Exception ex) { }
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select MaHD as 'Mã hóa đơn', MaNV as 'Mã nhân viên', NgayTao as 'Ngày tạo', SoBan as'Số bàn' from HoaDon where MaHD = 'HD001'";
                DataTable dt = ctr.getData(query);
                dgvHoaDon.DataSource = dt;
            } catch (Exception ex) { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from HoaDon where MaHD = '" + MaHD + "'";
                if (ctr.execute(query))
                {
                    MessageBox.Show("Xóa thành công");
                    getData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!\nHóa đơn bạn muốn xóa có thể đang được sử dụng");
                }
            } catch (Exception ex) 
            { 
                MessageBox.Show("Hãy chọn hóa đơn muốn xóa");
            }
            MaHD = "";
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                MaHD = dgvHoaDon.Rows[r].Cells["Mã hóa đơn"].Value.ToString();
                MaNV = dgvHoaDon.Rows[r].Cells["Mã nhân viên"].Value.ToString();
                NgayTao = dgvHoaDon.Rows[r].Cells["Ngày tạo"].Value.ToString();
                SoBan = dgvHoaDon.Rows[r].Cells["Số bàn"].Value.ToString();
            }
        }
    }
}
