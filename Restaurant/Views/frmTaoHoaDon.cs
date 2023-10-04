using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using Restaurant.compnent;
using Restaurant.Controls;
using Restaurant.Models;

namespace Restaurant.Views
{
    public partial class frmTaoHoaDon : Form
    {
        control ctr = new control();
        public table currentTable;
        public frmTaoHoaDon()
        {
            InitializeComponent();
        }

        // method ===============================================================
        public void AddTable(string soBan, string tang)
        {
            table tbl = new table()
            {
                SoBan = soBan,
                Tang = tang
            };
            panelTable.Controls.Add(tbl);

            tbl.OnSelect += (ss, ee) =>
            {
                try
                {
                    var itemTable = (table)ss;
                    currentTable = itemTable;
                    panelOrder.Controls.Clear();
                    foreach (var item in currentTable.lstOrderItem)
                    {
                        AddOrder(item.MaMon, item.TenMon, item.SoLuong.ToString(), string.Format("{0:N0}", item.DonGia));
                    }
                    tabControl1.SelectedIndex = 1;
                    lblTable.Text = itemTable.lblTable.Text;
                }
                catch (Exception ex) { }
            };
        }

        public void AddMonAn(string maMon, string name, string price, Image img, string loaiMon)
        {
            monAn item = new monAn()
            {
                MaMon = maMon,
                TenMon = name,
                DonGia = string.Format("{0:N0}", double.Parse(price)),
                Img = img,
                LoaiMon = loaiMon
            };
            panelMonAn.Controls.Add(item);

            item.OnSelect += (ss, ee) =>
            {
                try
                {
                    if (lblTable.Text != "Bàn ...")
                    {
                        var mon = (monAn)ss;
                        foreach (Control ctr in panelOrder.Controls)
                        {
                            var itemOrder = (order)ctr;
                            if (itemOrder.tenMon.Text == mon.tenMon.Text)
                            {
                                itemOrder.txtSoLuong.Text = (int.Parse(itemOrder.txtSoLuong.Text) + 1).ToString();
                                double tongTien = int.Parse(itemOrder.txtSoLuong.Text) * double.Parse(itemOrder.txtDonGia.Text);
                                itemOrder.lblTong.Text = string.Format("{0:N0}", tongTien);

                                // cập nhật lại tổng tiền trong lstOrderItem
                                orderItem ordItm = currentTable.lstOrderItem.Find(x => x.TenMon == mon.TenMon);
                                ordItm.TongTien = tongTien;
                                ordItm.SoLuong = int.Parse(itemOrder.txtSoLuong.Text);
                                CalculateTotal();
                                return;
                            }
                        }
                        AddOrder(mon.MaMon, mon.TenMon, "1", mon.DonGia);
                        currentTable.lstOrderItem.Add(new orderItem()
                        {
                            MaMon = mon.MaMon,
                            TenMon = mon.TenMon,
                            SoLuong = 1,
                            DonGia = double.Parse(mon.DonGia),
                            TongTien = double.Parse(mon.DonGia)
                        });
                        // tùy chỉnh lại giao diện cho bàn được chon, khi có người
                        setUpTable(true);
                        // tính lại tổng tiền của hóa đơn
                        CalculateTotal();
                    } else
                    {
                        MessageBox.Show("Bạn chưa chọn bàn!");
                    }
                } catch (SqlException ex) { }
            };
        }

        public void AddOrder(string id, string name, string soLuong, string donGia)
        {
            order ord = new order()
            {
                IdMon = id,
                TenMon = name,
                SoLuong = soLuong,
                DonGia = donGia,
                TongTien = string.Format("{0:N0}", (double.Parse(donGia) * int.Parse(soLuong)))
            };
            ord.OnChane += (ss, ee) =>
            {
                var itemOrder = (order)ss;
                int quti;
                if (int.TryParse(itemOrder.txtSoLuong.Text, out quti))
                {
                    // cập nhật lại tổng tiền cho itemOrder trên giao diện và trong danh sách lstOrderItem
                    itemOrder.TongTien = (double.Parse(itemOrder.txtDonGia.Text) * int.Parse(itemOrder.txtSoLuong.Text)).ToString();
                    currentTable.lstOrderItem.Find(x => x.TenMon == itemOrder.TenMon).TongTien = double.Parse(itemOrder.TongTien);
                }
                CalculateTotal();
            };

            ord.OnDelete += (ss, ee) =>
            {
                // xóa itemOrder khỏi lstOrderItem 
                currentTable.lstOrderItem.Remove(currentTable.lstOrderItem.Find(x => x.TenMon == ord.TenMon));
                //kiểm tra lại lstOrderItem của bàn đang chọn, nếu không có món ăn nào thì chỉnh lại thành bàn không có người
                if (currentTable.lstOrderItem.Count == 0) setUpTable(false);
                // cập nhật lại tổng tiền hóa đơn, và xóa itemOrder của giao diện
                double total = double.Parse(lblTotal.Text) - double.Parse(ord.lblTong.Text);
                lblTotal.Text = total.ToString();
                panelOrder.Controls.Remove(ord);
            };

            panelOrder.Controls.Add(ord);
            ord.Dock = DockStyle.Top;
        }

        void CalculateTotal()
        {
            double total = 0;
            foreach (Control ctr in panelOrder.Controls)
            {
                var it = (order)ctr;
                total += double.Parse(it.lblTong.Text);
            }
            lblTotal.Text = string.Format("{0:N0}", total);
        }

        static Bitmap ByteArrayToBitmap(byte[] byteArray)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    return bitmap;
                }
            }
            catch (Exception)
            {
                // Xử lý nếu không thể chuyển đổi thành Bitmap
                return null;
            }
        }

        public void AddItemCmb(ComboBox cmb, string query)
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

        public void setUpTable (Boolean coNguoi)
        {
            if (coNguoi)
            {
                currentTable.bunifuPanel1.BackgroundColor = Color.FromArgb(24, 119, 241);
                currentTable.lblTable.ForeColor = Color.White;
                currentTable.iconTable.IconColor = Color.White;
            } else
            {
                currentTable.bunifuPanel1.BackgroundColor = Color.White;
                currentTable.lblTable.ForeColor = Color.Black;
                currentTable.iconTable.IconColor = Color.Black;
            }
        }

        // Event listener =======================================================
        private void frmTaoHoaDon_Shown(object sender, EventArgs e)
        {
            cmbLoaiMon.Items.Add("All");
            cmbTang.Items.Add("All");

            DataTable table = ctr.getData("select SoBan, Tang from PhongBan");
            foreach (DataRow row in table.Rows)
            {
                AddTable("Bàn " + row["SoBan"].ToString(), row["Tang"].ToString());
            }

            DataTable MonAn = ctr.getData("select MaMonAn, TenMonAn, DonGia, HinhAnh, LoaiMonAn from MonAn");
            foreach(DataRow row in MonAn.Rows)
            {
                byte[] imgBytes = (byte[])row["HinhAnh"];
                Bitmap bitmap = ByteArrayToBitmap(imgBytes);
                AddMonAn(row["MaMonAn"].ToString() ,row["TenMonAn"].ToString(), row["DonGia"].ToString(), bitmap, row["LoaiMonAn"].ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panelOrder.Controls.Clear();
            lblTotal.Text = "0";
            if (currentTable != null) setUpTable(false);

            string query = "update NguyenLieu set SoLuong = (SoLuong - 4) where MaNL = 'NL001'";
            ctr.execute(query);
        }
        private void frmTaoHoaDon_Load(object sender, EventArgs e)
        {
            string query = "select distinct Tang from PhongBan";
            AddItemCmb(cmbTang, query);
            string queryLoaiMon = "select distinct LoaiMonAn From MonAn";
            AddItemCmb(cmbLoaiMon, queryLoaiMon);
            AddItemCmb(cmbTable, "select SoBan from PhongBan");
            cmbTable.Visible = false;
        }

        private void cmbTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tang = cmbTang.SelectedItem.ToString();
                if (tang == "All")
                {
                    foreach (var item in panelTable.Controls)
                    {
                        var itemTable = (table)item;
                        itemTable.Visible = true;
                    }
                } else
                {
                    foreach (var item in panelTable.Controls)
                    {
                        var itemTable = (table)item;
                        itemTable.Visible = itemTable.tang.ToLower().ToLower().Contains(tang.Trim().ToLower());
                    }
                }
            } catch { }
        }

        private void cmbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                string loaiMon = cmbLoaiMon.SelectedItem.ToString();
                if (loaiMon == "All")
                {
                    foreach (var item in panelMonAn.Controls)
                    {
                        var itemMonAn = (monAn)item;
                        itemMonAn.Visible = true;
                    }
                } else
                {
                    foreach (var item in panelMonAn.Controls)
                    {
                        var itemMonAn = (monAn)item;
                        itemMonAn.Visible = itemMonAn.loaiMon.ToLower().ToLower().Contains(loaiMon.Trim().ToLower());
                    }
                }
            }
            catch { }
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            foreach (var item in panelMonAn.Controls)
            {
                var itemMonAn = (monAn)item;
                itemMonAn.Visible = itemMonAn.tenMon.Text.ToLower().ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void inHoaDon(Boolean istrue)
        {
            if (panelOrder.Controls.Count > 0)
            {
                ppdHoaDon.Document = pdHoaDon;
                ppdHoaDon.PrintPreviewControl.Zoom = 0.75;
                ppdHoaDon.ShowDialog();

                // Hiển thị hộp thoại in ấn để chọn máy in và cài đặt in ấn khác.
                /*printDialog1.Document = pdHoaDon;

                DialogResult result = printDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Bắt đầu quá trình in ấn.
                    pdHoaDon.Print();
                }*/
                if (istrue)
                {
                    // nếu nút thanh toán được kích hoạt, thực hiện lưu vào cơ sở dữ liệu

                    string queryMaxMaHD = "select max(MaHD) from HoaDon";
                    DataTable maxMaHD = ctr.getData(queryMaxMaHD);

                    // Tạo mã hóa đơn tự động
                    //
                    foreach(DataRow row in maxMaHD.Rows)
                    {
                        // tạo mã hóa đơn tự động
                        int thuTuMon = int.Parse(row[0].ToString().Substring(2)) + 1;
                        string primaryKey = string.Format("HD{0:000}", thuTuMon);
                        // lấy ngày hiện tại
                        DateTime currentDay = DateTime.Now;
                        string ngayTaoHD = currentDay.Year + "-" + currentDay.Month + "-" + currentDay.Day;
                        // câu lệnh truy vấn thêm hóa đơn
                        string queryInsertHD = "INSERT INTO HoaDon(MaHD, MaNV, NgayTao, SoBan)" +
                            "  VALUES('" + primaryKey + "', 'NV007', '" + ngayTaoHD + "', '" + lblTable.Text.Replace("Bàn ", "") + "')";

                        string queryInsertCTHoaDon = "";

                        // danh sách lưu nguyên liệu, và số lượng nguyên liệu dùng trong hóa đơn
                        List<chiTietMonAn> lstMaNL = new List<chiTietMonAn>();

                        // duyệt qua lstOrderItem để lấy mã món ăn trong hóa đơn
                        foreach (var item in currentTable.lstOrderItem)
                        {
                            // thêm chi tiết hóa đơn, (phải làm như này vì không có dấu phẩy ở cuối câu lệnh
                            if (queryInsertCTHoaDon == "")
                            {
                                queryInsertCTHoaDon += "INSERT INTO ChiTietHD(MaHD, MaMonAn, SoLuongMon) VALUES ('" + primaryKey + "', N'" + item.MaMon + "', " + item.SoLuong + " )";
                            }
                            else
                            {
                                queryInsertCTHoaDon += ", ('" + primaryKey + "', N'" + item.MaMon + "', " + item.SoLuong + " )";
                            }

                            // truy vấn lấy ra những nguyên liệu cần dùng cho món ăn trong hóa đơn
                            string queryCTMonAn = "select MaNL, SoLuongNL from ChiTietMonAn where MaMonAn = '" + item.MaMon + "'";
                            DataTable ctMonAn = ctr.getData(queryCTMonAn);

                            // lưu dữ liệu vừa lấy được (mã nguyên liệu, số lượng sử dụng) vào lstMaNL
                            foreach (DataRow rw in ctMonAn.Rows)
                            {
                                chiTietMonAn ctMA = lstMaNL.Find(x => x.MaNL == rw["MaNL"].ToString());
                                if (ctMA != null)
                                {
                                    ctMA.SoLuong += (double.Parse(rw["SoLuongNL"].ToString()) * item.SoLuong);
                                } else
                                {
                                    lstMaNL.Add(
                                    new chiTietMonAn(rw["MaNL"].ToString(), (item.SoLuong * double.Parse(rw["SoLuongNL"].ToString())))
                                    );
                                }
                            }
                        }
                        /*MessageBox.Show(queryInsertHD);
                        MessageBox.Show(queryInsertCTHoaDon);*/
                        // thực hiện thêm hóa đơn
                        ctr.execute(queryInsertHD);
                        // thực hiện thêm chi tiết hóa đơn
                        ctr.execute(queryInsertCTHoaDon);
                        // tạo câu lệnh trừ số lượng nguyên liệu vừa sử dụng vào DB
                        foreach (var nguyenLieu in lstMaNL)
                        {
                            string queryUpdateNL = "update NguyenLieu set Soluong = (SoLuong - " + nguyenLieu.SoLuong + ") where MaNL = '" + nguyenLieu.MaNL + "'";
                            // thực hiện trừ số lượng nguyên liệu đã sử dụng
                            ctr.execute(queryUpdateNL);
                        }
                        
                        break;
                    }
                }
            } else
            {
                MessageBox.Show("Vui lòng chọn món ăn!");
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            inHoaDon(true);
            btnClear_Click(sender, e);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            inHoaDon(false);
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // lấy thông tin từ cấu hình

            // lấy chiều rộng của giấy in
            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;

            // header ============================================
            // Vẽ header của bill
            //1. Tên cửa hàng
            e.Graphics.DrawString(
                    "Nhà hàng Dũng Nguyễn",
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new Point(100, 20)
                ); ;
            //  mã hóa đơn
            e.Graphics.DrawString(
                String.Format("HD001"),
                new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new Point(w / 2 + 100, 20)
                );

            // 2. Địa chỉ quán ăn
            e.Graphics.DrawString(
                String.Format("{0} - {1}", "491 Hoàng Quốc Việt, Hà Nội", "0982 932 843"),
                new Font("Courier New", 8, FontStyle.Bold),
                    Brushes.Black, new Point(100, 45)
                );

            // 3. Ngày giờ xuất hóa đơn
            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
                new Font("Courier New", 12, FontStyle.Regular),
                    Brushes.Black, new Point(w / 2 + 100, 45)
                );

            // Định dạng bút vẽ
            Pen blackPen = new Pen(Color.Black, 1);

            // Tọa đọ theo chiều dọc
            var y = 70;

            // định nghĩa 2 điểm để vẽ đường thẳng
            // cách lề trái 10, lề phải 10
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);

            // Kẻ đương thẳng thứ nhất
            e.Graphics.DrawLine(blackPen, p1, p2);

            // Body ================================================
            y += 10;
            e.Graphics.DrawString("Tên món", new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("SL", new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("ĐG", new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(w / 2 + 60, y));
            e.Graphics.DrawString("T.Tiền", new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(w - 200, y));

            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            // Kẻ đương thẳng thứ hai
            e.Graphics.DrawLine(blackPen, p1, p2);

            foreach (Control ctr in panelOrder.Controls)
            {
                y += 20;
                var it = (order)ctr;
                e.Graphics.DrawString(it.TenMon, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(it.SoLuong, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(it.DonGia, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(w / 2 + 60, y));
                e.Graphics.DrawString(it.TongTien, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, new Point(w - 200, y));
            }


            // end =================================================
            y += 40;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);

            // Kẻ đương thẳng thứ ba
            e.Graphics.DrawLine(blackPen, p1, p2);

            y += 15;
            e.Graphics.DrawString("Tổng tiền", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString(lblTotal.Text, new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            y += 40;
            e.Graphics.DrawString("Chúc quý khách vui vẻ, hẹn gặp lại!", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(230, y));
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            cmbTable.Visible = true;
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblTable.Text = "Bàn " + cmbTable.SelectedItem.ToString();
                setUpTable(false);
                foreach (var item in panelTable.Controls)
                {
                    var itemTable = (table)item;
                    if (itemTable.SoBan == lblTable.Text)
                    {
                        itemTable.lstOrderItem = currentTable.lstOrderItem;
                        currentTable.lstOrderItem.Clear();
                        currentTable = itemTable;
                        if (currentTable.lstOrderItem[0] != null) setUpTable(true);
                        break;
                    }
                }
                cmbTable.Visible = false;
            } catch
            {

            }
        }
    }
}
