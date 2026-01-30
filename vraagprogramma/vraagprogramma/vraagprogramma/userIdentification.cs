using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class userIdentification : Form
    {
        public userIdentification()
        {
            InitializeComponent();
        }

        private void userIdentification_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            label1.BackColor = Color.Transparent;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label1.Top = (this.ClientSize.Height - label1.Height) / 3;
            vraagCode.BackColor = Color.Transparent;
            vraagCode.Left = (this.ClientSize.Width - vraagCode.Width) / 2;
            vraagCode.Top = label1.Bottom + 20;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;
            textBox1.Top = vraagCode.Bottom + 10;
            confirmBtn.Left = (this.ClientSize.Width - confirmBtn.Width) / 2;
            confirmBtn.Top = textBox1.Bottom + 20;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
