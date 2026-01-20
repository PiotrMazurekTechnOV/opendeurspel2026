using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class answerSelection : Form
    {
        public answerSelection()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            answer1.Location = new Point(Convert.ToInt32(this.Width *0.4), Convert.ToInt32(this.Height / 2));
            answer2.Location = new Point(this.Width / 1, this.Height / 2);
            answer3.Location = new Point(this.Width / 3, this.Height / 2);
            answer4.Location = new Point(this.Width / 3, this.Height / 2);


        }

        public void answerSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
