using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.InteropServices;
using RJCodeAdvance.RJControls;
using System.Runtime.Remoting.Channels;
using Restaurant.Views;

namespace Restaurant
{
    public partial class frmHeThong : Form
    {
        // files
        private int borderSize = 5;
        private Size formSize;
        private Form currentFormChild;
        // Constructor
        public frmHeThong()
        {
            InitializeComponent();
            customizeDesing(); 
            /*CollapseMenu();*/
            this.Padding = new Padding(borderSize); // border size
            this.BackColor = Color.FromArgb(24, 119, 241); // border color
        }

        private void customizeDesing()
        {
            panelSubThongKe.Visible = false;
            panelSubGiaoDich.Visible = false;
            panelSubHangHoa.Visible = false;
            panelSubNhanVien.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSubThongKe.Visible == true)
            {
                panelSubThongKe.Visible = false;
            }
            if (panelSubHangHoa.Visible == true)
            {
                panelSubHangHoa.Visible = false;
            }
            if (panelSubGiaoDich.Visible == true)
            {
                panelSubGiaoDich.Visible = false;
            }
            if (panelSubNhanVien.Visible == true)
            {
                panelSubNhanVien.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Drag form
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTilteBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //overHidden methods
        protected override void WndProc(ref Message m)
        {
            //Overridden methods
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            //const int WM_SYSCOMMAND = 0x0112;
            //const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            //const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            
            base.WndProc(ref m);
        }

        //Event methods
        private void Form1_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        // Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                    this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200)
            {
                customizeDesing();
                this.panelMenu.Width = 100;
                btnMenu.Text = "";
                btnMenu.ImageAlign = ContentAlignment.MiddleCenter;
                btnMenu.Padding = new Padding(0);
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                this.panelMenu.Width = 250;
                btnMenu.Dock = DockStyle.None;
                btnMenu.ImageAlign = ContentAlignment.MiddleLeft;
                btnMenu.Padding = new Padding(10, 0, 0, 0);
                btnMenu.Text = "   " + btnMenu.Tag.ToString();
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void HangHoaBtn_Click(object sender, EventArgs e)
        {
            if (this.panelMenu.Width > 200)
            {
                showSubMenu(panelSubHangHoa);
            }
        }

        private void GiaoDichBtn_Click(object sender, EventArgs e)
        {
            if (this.panelMenu.Width > 200)
            {
                showSubMenu(panelSubGiaoDich);
            }
        }

        private void NhanVienBtn_Click(object sender, EventArgs e)
        {
            if (this.panelMenu.Width > 200)
            {
                showSubMenu(panelSubNhanVien);
            }
        }

        private void ThongKeBtn_Click(object sender, EventArgs e)
        {
            if (this.panelMenu.Width > 200)
            {
                showSubMenu(panelSubThongKe);
            }
        }

        private void dsNhanVienBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Danh sách nhân viên";
            OpenChildForm(new FormCSNV());
        }

        private void MonAnBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Thông tin món ăn";
            OpenChildForm(new frmMonAn());
        }

        private void PhongBanBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Phòng / bàn";
            OpenChildForm(new FrmPhong_Ban());
        }

        private void dsHDBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Danh sách hóa đơn";
            OpenChildForm(new frmHoaDon());
        }

        private void DoanhThuBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Doanh thu";
            OpenChildForm(new frmDoanhThu());
        }

        private void HangTonBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Hàng tồn";
            OpenChildForm(new frmHangTon());
        }

        private void BanChayBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Bán chạy";
            OpenChildForm(new frmBanChay());
        }

        private void TaoHDBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Thu ngân";
            OpenChildForm(new frmTaoHoaDon());
        }

        private void chamCongBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Chấm công";
            OpenChildForm(new FormChamCong());
        }

        private void NguyenLieuBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Nguyên liệu";
            OpenChildForm(new FormNL());
        }

        private void DoiTacBtn_Click(object sender, EventArgs e)
        {
            labelTagForm.Text = "Nhà cung cấp";
            OpenChildForm(new FormCSNCC());
        }

        private void frmHeThong_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 150);
        }

        // Open dropDownMenu
        /*private void Open_DropdownMenu(RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
                    => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);

        }
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu.Visible)
                    ctrl.BackColor = Color.FromArgb(24, 119, 241);
                else ctrl.BackColor = Color.FromArgb(24, 119, 241);
            }
        }*/

    }
}
