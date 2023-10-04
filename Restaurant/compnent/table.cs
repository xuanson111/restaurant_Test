using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.compnent
{
    public partial class table : UserControl
    {
        public EventHandler OnSelect = null;
        public string tang;
        public List<orderItem> lstOrderItem = new List<orderItem>();
        public table()
        {
            InitializeComponent();
        }

        public string SoBan { get => lblTable.Text; set => lblTable.Text = value; }
        public string Tang { get => tang; set => tang = value; }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        private void iconTable_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
    }
}

