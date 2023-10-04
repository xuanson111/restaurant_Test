namespace Restaurant.compnent
{
    partial class table
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(table));
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.lblTable = new System.Windows.Forms.Label();
            this.iconTable = new FontAwesome.Sharp.IconPictureBox();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTable)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.DimGray;
            this.bunifuPanel1.BorderRadius = 20;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.lblTable);
            this.bunifuPanel1.Controls.Add(this.iconTable);
            this.bunifuPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bunifuPanel1.Location = new System.Drawing.Point(3, 3);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(134, 134);
            this.bunifuPanel1.TabIndex = 0;
            this.bunifuPanel1.Click += new System.EventHandler(this.bunifuPanel1_Click);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.BackColor = System.Drawing.Color.Transparent;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.Black;
            this.lblTable.Location = new System.Drawing.Point(7, 94);
            this.lblTable.MaximumSize = new System.Drawing.Size(120, 46);
            this.lblTable.MinimumSize = new System.Drawing.Size(120, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(120, 25);
            this.lblTable.TabIndex = 13;
            this.lblTable.Text = "Bàn 10";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconTable
            // 
            this.iconTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconTable.BackColor = System.Drawing.Color.Transparent;
            this.iconTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconTable.ForeColor = System.Drawing.Color.Black;
            this.iconTable.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.iconTable.IconColor = System.Drawing.Color.Black;
            this.iconTable.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconTable.IconSize = 90;
            this.iconTable.Location = new System.Drawing.Point(23, 9);
            this.iconTable.Name = "iconTable";
            this.iconTable.Size = new System.Drawing.Size(90, 90);
            this.iconTable.TabIndex = 0;
            this.iconTable.TabStop = false;
            this.iconTable.Click += new System.EventHandler(this.iconTable_Click);
            // 
            // table
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "table";
            this.Size = new System.Drawing.Size(140, 140);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public FontAwesome.Sharp.IconPictureBox iconTable;
        public System.Windows.Forms.Label lblTable;
        public Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
    }
}
