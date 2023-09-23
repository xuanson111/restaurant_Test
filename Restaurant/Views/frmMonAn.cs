using Restaurant.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Restaurant.Views
{
    public partial class frmMonAn : Form
    {
        public frmMonAn()
        {
            InitializeComponent();
        }
        ctrMonAn ctr = new ctrMonAn();
        public string MaMA, TenMon, LoaiMon, Gia;
        public void getData()
        {
            string query = "select MaMonAn as 'Mã món ăn', TenMonAn as 'Tên món ăn'," +
                " LoaiMonAn as 'Loại món ăn', DonGia as 'Đơn giá' from MonAn";
            DataTable dt = ctr.getData(query);
            dgvMonAn.DataSource = dt;
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
        private void frmMonAn_Load(object sender, EventArgs e)
        {
            loaiMon();
            getData();
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            string query = "select  MaMonAn as 'Mã món ăn', TenMonAn as 'Tên món ăn', " +
                "LoaiMonAn as 'Loại món ăn', DonGia as 'Đơn giá' " +
                "from MonAn where TenMonAn like N'%" + txtSearch.Text + "%'";
            DataTable dt = ctr.getData(query);
            dgvMonAn.DataSource = dt;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbLoaiMon.Items.Clear();
            loaiMon();
            getData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị tự tăng từ cơ sở dữ liệu (ví dụ: ID tự tăng)
                SqlConnection conn = ctr.GetConnection();
                conn.Open();
                string query = "select max(MaMonAn) from MonAn";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {

                    string data = rd.GetString(0);
                    int thuTuMon = int.Parse(data.Substring(2)) + 1;
                    string primaryKey = string.Format("MA{0:000}", thuTuMon);
                    MaMA = primaryKey;
                }
                conn.Close();
                // Tạo chuỗi số format theo định dạng bạn mong muốn (ví dụ: "MA{0:000}")
                // Kết hợp giá trị tự tăng với chuỗi số format
            } catch (System.Exception ex) 
            {
                MessageBox.Show("Loi");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from MonAn where MaMonAn = N'" + MaMA + "'";
                if (ctr.execute(query))
                {
                    MessageBox.Show("Xóa thành công");
                    getData();
                }
                else
                {
                    if (MaMA == "")
                    {
                        MessageBox.Show("Hãy chọn món ăn muốn xóa");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!\nMón ăn mà bạn đang xóa đang được sử dụng trong danh sách hóa đơn");
                    }
                }
            }
            catch (Exception ex) { }
            MaMA = "";
        }

        private void cmbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                string food = cmbLoaiMon.SelectedItem.ToString();
                string query = "select MaMonAn as 'Mã món ăn', TenMonAn as 'Tên món ăn'," +
                    " LoaiMonAn as 'Loại món ăn', DonGia as 'Đơn giá'" +
                    " from MonAn where LoaiMonAn = N'" + food + "'";
                DataTable dt = ctr.getData(query);
                dgvMonAn.DataSource = dt;
            } catch (System.Exception ex) { }
        }

        

        private void dgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                MaMA = dgvMonAn.Rows[r].Cells["Mã Món Ăn"].Value.ToString();
                TenMon = dgvMonAn.Rows[r].Cells["Tên món ăn"].Value.ToString();
                LoaiMon = dgvMonAn.Rows[r].Cells["Loại món ăn"].Value.ToString();
                Gia = dgvMonAn.Rows[r].Cells["Đơn giá"].Value.ToString();
            }
        }
    }
}
