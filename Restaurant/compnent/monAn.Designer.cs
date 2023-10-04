namespace Restaurant.compnent
{
    partial class monAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(monAn));
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.donGia = new System.Windows.Forms.Label();
            this.tenMon = new System.Windows.Forms.Label();
            this.imgMonAn = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuPanel1.BorderRadius = 15;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.imgMonAn);
            this.bunifuPanel1.Controls.Add(this.donGia);
            this.bunifuPanel1.Controls.Add(this.tenMon);
            this.bunifuPanel1.Location = new System.Drawing.Point(3, 3);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(148, 203);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // donGia
            // 
            this.donGia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.donGia.AutoSize = true;
            this.donGia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(241)))));
            this.donGia.Location = new System.Drawing.Point(5, 171);
            this.donGia.MaximumSize = new System.Drawing.Size(130, 0);
            this.donGia.MinimumSize = new System.Drawing.Size(138, 0);
            this.donGia.Name = "donGia";
            this.donGia.Size = new System.Drawing.Size(138, 23);
            this.donGia.TabIndex = 6;
            this.donGia.Text = "30.000";
            this.donGia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tenMon
            // 
            this.tenMon.AutoSize = true;
            this.tenMon.BackColor = System.Drawing.Color.Transparent;
            this.tenMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenMon.ForeColor = System.Drawing.Color.Black;
            this.tenMon.Location = new System.Drawing.Point(4, 127);
            this.tenMon.MaximumSize = new System.Drawing.Size(138, 46);
            this.tenMon.MinimumSize = new System.Drawing.Size(138, 0);
            this.tenMon.Name = "tenMon";
            this.tenMon.Size = new System.Drawing.Size(138, 40);
            this.tenMon.TabIndex = 5;
            this.tenMon.Text = "bánh mì súc sích pate";
            this.tenMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgMonAn
            // 
            this.imgMonAn.AllowFocused = false;
            this.imgMonAn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgMonAn.AutoSizeHeight = true;
            this.imgMonAn.BorderRadius = 60;
            this.imgMonAn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgMonAn.Image = ((System.Drawing.Image)(resources.GetObject("imgMonAn.Image")));
            this.imgMonAn.IsCircle = false;
            this.imgMonAn.Location = new System.Drawing.Point(7, 2);
            this.imgMonAn.MaximumSize = new System.Drawing.Size(134, 120);
            this.imgMonAn.Name = "imgMonAn";
            this.imgMonAn.Size = new System.Drawing.Size(134, 120);
            this.imgMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgMonAn.TabIndex = 7;
            this.imgMonAn.TabStop = false;
            this.imgMonAn.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            this.imgMonAn.Click += new System.EventHandler(this.imgMonAn_Click_1);
            // 
            // monAn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "monAn";
            this.Size = new System.Drawing.Size(154, 209);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMonAn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        public System.Windows.Forms.Label donGia;
        public System.Windows.Forms.Label tenMon;
        public Bunifu.UI.WinForms.BunifuPictureBox imgMonAn;
    }
}
