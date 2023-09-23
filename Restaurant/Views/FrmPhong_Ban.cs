using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Restaurant.Controls;
using Restaurant.Modals;
using Restaurant.Views.frmChild;

namespace Restaurant.Views
{
    public partial class FrmPhong_Ban : Form
    {
        public FrmPhong_Ban()
        {
            InitializeComponent();
        }
        public string SoBan, Tang, Loai;

        ctrPhongBan ctr = new ctrPhongBan();
        public void getDT()
        {
            string sqlQuery = "select SoBan as 'Số bàn', Tang as 'Tầng', Loai as 'Loại' from PhongBan";
            DataTable dt = ctr.getData(sqlQuery);
            dgvPhongBan.DataSource = dt;
        }

        public void getFloor()
        {
            try
            {
                SqlConnection conn = ctr.getConnetion();
                conn.Open();
                string query = "select distinct Tang from PhongBan";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string tang = rd.GetString(0);
                    cmbFloor.Items.Add(tang);
                }
                conn.Close();
            } catch (System.Exception ex) { }
        }

        private void FrmPhong_Ban_Load(object sender, EventArgs e)
        {
            getDT();
            getFloor();
            for (int i = 0; i < dgvPhongBan.ColumnCount; i++)
            {
                dgvPhongBan.Columns[i].ReadOnly = true;
            }
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            string sqlQuery = "select SoBan as 'Số bàn', Tang as 'Tầng', Loai as 'Loại' from PhongBan where SoBan like '%" + txtSearch.Text + "%'";
            DataTable dt = ctr.getData(sqlQuery);
            dgvPhongBan.DataSource = dt;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbFloor.Items.Clear();
            getFloor();
            getDT();
        }

        private void dgvPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                SoBan = dgvPhongBan.Rows[r].Cells["Số bàn"].Value.ToString();
                Tang = dgvPhongBan.Rows[r].Cells["Tầng"].Value.ToString();
                Loai = dgvPhongBan.Rows[r].Cells["Loại"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPhongBanChild frm = new frmPhongBanChild();
            frm.SoBan = SoBan;
            frm.Tang = Tang;
            frm.Loai = Loai;
            frm.hideBtnEdit();
            frm.ShowDialog();
            if (frm.success) getDT();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmPhongBanChild frm = new frmPhongBanChild();
            frm.SoBan = SoBan;
            frm.Tang = Tang;
            frm.Loai = Loai;
            frm.hideBtnAdd();
            frm.disableTxtSoBan();
            frm.ShowDialog();
            if (frm.success) getDT();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from PhongBan where SoBan = N'" + SoBan + "'";
                if (ctr.execute(query))
                {
                    MessageBox.Show("Xóa thành công");
                    getDT();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!\nBàn mà bạn muốn xóa có thể đang được sử dụng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hãy chọn bàn muốn xóa");
            }
            SoBan = "";
        }

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                string floor = cmbFloor.SelectedItem.ToString();
                string query = "select SoBan as 'Số bàn', Tang as 'Tầng', Loai as 'Loại' from PhongBan where Tang = N'" + floor + "'";
                DataTable dt = ctr.getData(query);
                dgvPhongBan.DataSource = dt;
            } catch (Exception ex) { }
        }
    }
}
