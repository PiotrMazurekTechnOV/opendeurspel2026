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
            this.Load += answerSelection_Load;
        }


        private void answerSelection_Load(object sender, EventArgs e)
        {
            questionLbl.Location = new Point((this.ClientSize.Width - questionLbl.Width) / 2,(int)(this.ClientSize.Height * 0.25));


            answer1.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.25), Convert.ToInt32(this.ClientSize.Height / 2));           

            answer2.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.75)-answer1.Width, Convert.ToInt32(this.ClientSize.Height / 2));                            

            answer3.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.25), Convert.ToInt32(this.ClientSize.Height *0.75));         

            answer4.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.75)-answer4.Width, Convert.ToInt32(this.ClientSize.Height * 0.75));                        
        }

    }
}
