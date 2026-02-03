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
        private int location;
        public locationSelection()
        {
            InitializeComponent();
        }

        private void locationSelection_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            klasBtn.Left = (this.ClientSize.Width - klasBtn.Width) / 2;
            klasBtn.Top = (this.ClientSize.Height - klasBtn.Height) / 3;
            codeTextbox.Left = (this.ClientSize.Width - codeTextbox.Width) / 2;
            codeTextbox.Top = klasBtn.Bottom + 5;


        }

        private void klasBtn_Click(object sender, EventArgs e)
        {
            location = Convert.ToInt32(codeTextbox.Text);
            userIdentification userIdentification = new userIdentification();
            this.Hide();
            userIdentification.Show();
        }
        public int Location { get { return location; } set { Location = location; } }
    }
    
}
