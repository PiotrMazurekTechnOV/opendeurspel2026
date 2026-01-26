using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class feedBack : Form
    {
        public feedBack()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Load += feedBack_Load;
            bool feedback = false;
            if (feedback)
            {
                feedbackLbl.Text = "True!";
            }
            else
            {
                feedbackLbl.Text = "False!";
            }
        }
        private void feedBack_Load(object sender, EventArgs e)
        {
            float fontSize = this.ClientSize.Height / 30;
            feedbackLbl.Font = new Font(feedbackLbl.Font.FontFamily, fontSize, feedbackLbl.Font.Style);
            feedbackLbl.Location = new Point((this.ClientSize.Width - feedbackLbl.Width) / 2, (int)(this.ClientSize.Height - feedbackLbl.Height) / 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}