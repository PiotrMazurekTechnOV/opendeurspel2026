using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class locationSelection : Form
    {
        public locationSelection()
        {
            InitializeComponent();
        }

        private void locationSelection_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

           
        }
    }
}
