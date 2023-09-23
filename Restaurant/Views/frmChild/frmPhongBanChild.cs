using Restaurant.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.frmChild
{
    public partial class frmPhongBanChild : Form
    {
        public string SoBan, Tang, Loai;
        public bool success = false;
        ctrPhongBan ctr = new ctrPhongBan();
        public frmPhongBanChild()
        {
            InitializeComponent();
        }
        
        public void hideBtnAdd()
        {
            btnAdd.Visible = false;
        }
        public void hideBtnEdit()
        {
            btnEdit.Visible = false;
        }
        public void disableTxtSoBan()
        {
            txtSoBan.Enabled = false;
        }

        public void getDataCmb(ComboBox cmb, string query)
        {
            try
            {
                SqlConnection conn = ctr.getConnetion();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string tang = rd.GetString(0);
                    cmb.Items.Add(tang);
                }
                conn.Close();
            }
            catch (System.Exception ex) { }
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void bunifuPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmPhongBanChild_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(700, 300);
            txtLoai.Text = Loai;
            txtTang.Text = Tang;
            txtSoBan.Text = SoBan;
            string queryTang = "select distinct Tang from PhongBan";
            string queryLoai = "select distinct Loai from PhongBan";
            getDataCmb(cmbTang, queryTang);
            getDataCmb(cmbLoai, queryLoai);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO PhongBan VALUES (N'" + txtSoBan.Text + "', N'" + txtTang.Text + "', N'" + txtLoai.Text + "')";
            try
            {
                if (ctr.execute(query))
                {
                    MessageBox.Show("Thêm thành công");
                    success = true;
                    this.Close();
                }
                else MessageBox.Show("Thêm thất bại!\n Bàn số " + txtSoBan.Text + " đã tồn tại");
            } catch(Exception ex)
            {
                //MessageBox.Show("Hãy nhập đầy đủ thông tin");
            }
        }

        private void cmbTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Tang = cmbTang.SelectedItem.ToString();
                txtTang.Text = Tang;
            }
            catch (Exception ex) { }
        }

        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Loai = cmbLoai.SelectedItem.ToString();
                txtLoai.Text = Loai;
            }
            catch (Exception ex) { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string query = "update PhongBan set Tang = N'" + txtTang.Text + "', Loai = N'" + txtLoai.Text + "' where SoBan = N'" + txtSoBan.Text + "'";
            try
            {
                if (ctr.execute(query))
                {
                    MessageBox.Show("Sửa thành công");
                    success = true;
                    this.Close();
                }
                else MessageBox.Show("Sửa thất bại!\n ");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hãy nhập đầy đủ thông tin");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
