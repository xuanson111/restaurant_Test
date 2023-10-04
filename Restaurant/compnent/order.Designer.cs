namespace Restaurant.compnent
{
    partial class order
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(order));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tenMon = new System.Windows.Forms.Label();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.txtSoLuong = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtDonGia = new Bunifu.UI.WinForms.BunifuTextBox();
            this.lblTong = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tenMon);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.txtDonGia);
            this.panel1.Controls.Add(this.lblTong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 64);
            this.panel1.TabIndex = 0;
            // 
            // tenMon
            // 
            this.tenMon.AutoSize = true;
            this.tenMon.BackColor = System.Drawing.Color.White;
            this.tenMon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenMon.ForeColor = System.Drawing.Color.Black;
            this.tenMon.Location = new System.Drawing.Point(42, 16);
            this.tenMon.MaximumSize = new System.Drawing.Size(120, 46);
            this.tenMon.MinimumSize = new System.Drawing.Size(120, 0);
            this.tenMon.Name = "tenMon";
            this.tenMon.Size = new System.Drawing.Size(120, 25);
            this.tenMon.TabIndex = 12;
            this.tenMon.Text = "Bún chả";
            this.tenMon.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.Gray;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 24;
            this.btnDelete.Location = new System.Drawing.Point(3, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(35, 39);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.AcceptsReturn = false;
            this.txtSoLuong.AcceptsTab = false;
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.AnimationSpeed = 200;
            this.txtSoLuong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSoLuong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSoLuong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtSoLuong.BackColor = System.Drawing.Color.White;
            this.txtSoLuong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSoLuong.BackgroundImage")));
            this.txtSoLuong.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtSoLuong.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSoLuong.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtSoLuong.BorderColorIdle = System.Drawing.Color.DarkGray;
            this.txtSoLuong.BorderRadius = 1;
            this.txtSoLuong.BorderThickness = 1;
            this.txtSoLuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoLuong.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.DefaultText = "90";
            this.txtSoLuong.FillColor = System.Drawing.Color.White;
            this.txtSoLuong.ForeColor = System.Drawing.Color.Black;
            this.txtSoLuong.HideSelection = true;
            this.txtSoLuong.IconLeft = null;
            this.txtSoLuong.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoLuong.IconPadding = 10;
            this.txtSoLuong.IconRight = null;
            this.txtSoLuong.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoLuong.Lines = new string[] {
        "90"};
            this.txtSoLuong.Location = new System.Drawing.Point(159, 3);
            this.txtSoLuong.MaximumSize = new System.Drawing.Size(44, 38);
            this.txtSoLuong.MaxLength = 32767;
            this.txtSoLuong.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtSoLuong.Modified = false;
            this.txtSoLuong.Multiline = false;
            this.txtSoLuong.Name = "txtSoLuong";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSoLuong.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtSoLuong.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSoLuong.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.DarkGray;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Black;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSoLuong.OnIdleState = stateProperties4;
            this.txtSoLuong.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.txtSoLuong.PasswordChar = '\0';
            this.txtSoLuong.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSoLuong.PlaceholderText = "";
            this.txtSoLuong.ReadOnly = false;
            this.txtSoLuong.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSoLuong.SelectedText = "";
            this.txtSoLuong.SelectionLength = 0;
            this.txtSoLuong.SelectionStart = 0;
            this.txtSoLuong.ShortcutsEnabled = true;
            this.txtSoLuong.Size = new System.Drawing.Size(44, 38);
            this.txtSoLuong.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtSoLuong.TabIndex = 10;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoLuong.TextMarginBottom = 0;
            this.txtSoLuong.TextMarginLeft = 0;
            this.txtSoLuong.TextMarginTop = 0;
            this.txtSoLuong.TextPlaceholder = "";
            this.txtSoLuong.UseSystemPasswordChar = false;
            this.txtSoLuong.WordWrap = true;
            this.txtSoLuong.TextChange += new System.EventHandler(this.txtSoLuong_TextChange);
            // 
            // txtDonGia
            // 
            this.txtDonGia.AcceptsReturn = false;
            this.txtDonGia.AcceptsTab = false;
            this.txtDonGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDonGia.AnimationSpeed = 200;
            this.txtDonGia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDonGia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDonGia.BackColor = System.Drawing.Color.White;
            this.txtDonGia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDonGia.BackgroundImage")));
            this.txtDonGia.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtDonGia.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtDonGia.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtDonGia.BorderColorIdle = System.Drawing.Color.DarkGray;
            this.txtDonGia.BorderRadius = 1;
            this.txtDonGia.BorderThickness = 1;
            this.txtDonGia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDonGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDonGia.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.DefaultText = "100.000";
            this.txtDonGia.FillColor = System.Drawing.Color.White;
            this.txtDonGia.ForeColor = System.Drawing.Color.Black;
            this.txtDonGia.HideSelection = true;
            this.txtDonGia.IconLeft = null;
            this.txtDonGia.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDonGia.IconPadding = 10;
            this.txtDonGia.IconRight = null;
            this.txtDonGia.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDonGia.Lines = new string[] {
        "100.000"};
            this.txtDonGia.Location = new System.Drawing.Point(223, 3);
            this.txtDonGia.MaximumSize = new System.Drawing.Size(90, 38);
            this.txtDonGia.MaxLength = 32767;
            this.txtDonGia.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDonGia.Modified = false;
            this.txtDonGia.Multiline = false;
            this.txtDonGia.Name = "txtDonGia";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDonGia.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDonGia.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDonGia.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.DarkGray;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Black;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDonGia.OnIdleState = stateProperties8;
            this.txtDonGia.Padding = new System.Windows.Forms.Padding(3);
            this.txtDonGia.PasswordChar = '\0';
            this.txtDonGia.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDonGia.PlaceholderText = "";
            this.txtDonGia.ReadOnly = false;
            this.txtDonGia.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDonGia.SelectedText = "";
            this.txtDonGia.SelectionLength = 0;
            this.txtDonGia.SelectionStart = 7;
            this.txtDonGia.ShortcutsEnabled = true;
            this.txtDonGia.Size = new System.Drawing.Size(90, 38);
            this.txtDonGia.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtDonGia.TabIndex = 9;
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDonGia.TextMarginBottom = 0;
            this.txtDonGia.TextMarginLeft = 0;
            this.txtDonGia.TextMarginTop = 0;
            this.txtDonGia.TextPlaceholder = "";
            this.txtDonGia.UseSystemPasswordChar = false;
            this.txtDonGia.WordWrap = true;
            // 
            // lblTong
            // 
            this.lblTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.ForeColor = System.Drawing.Color.Black;
            this.lblTong.Location = new System.Drawing.Point(300, 14);
            this.lblTong.MaximumSize = new System.Drawing.Size(138, 46);
            this.lblTong.MinimumSize = new System.Drawing.Size(130, 0);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(130, 25);
            this.lblTong.TabIndex = 8;
            this.lblTong.Text = "100.000.000";
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // order
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.panel1);
            this.Name = "order";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Size = new System.Drawing.Size(430, 65);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnDelete;
        public System.Windows.Forms.Label lblTong;
        public System.Windows.Forms.Label tenMon;
        public Bunifu.UI.WinForms.BunifuTextBox txtSoLuong;
        public Bunifu.UI.WinForms.BunifuTextBox txtDonGia;
    }
}
