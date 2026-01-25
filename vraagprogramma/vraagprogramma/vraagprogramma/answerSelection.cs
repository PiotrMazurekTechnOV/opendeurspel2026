using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
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

            float fontSize = this.ClientSize.Height / 30;

            questionLbl.Font = new Font(questionLbl.Font.FontFamily, fontSize, questionLbl.Font.Style);

            questionLbl.Location = new Point((this.ClientSize.Width - questionLbl.Width) / 2, (int)(this.ClientSize.Height * 0.25));

            answer1.Font = new Font(answer1.Font.FontFamily, fontSize / 3, answer1.Font.Style);
            answer2.Font = new Font(answer2.Font.FontFamily, fontSize / 3, answer2.Font.Style);
            answer3.Font = new Font(answer3.Font.FontFamily, fontSize / 3, answer3.Font.Style);
            answer4.Font = new Font(answer4.Font.FontFamily, fontSize / 3, answer4.Font.Style);

            answer1.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.25) - answer1.Width / 2, Convert.ToInt32(this.ClientSize.Height / 2));

            answer2.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.75) - answer2.Width / 2, Convert.ToInt32(this.ClientSize.Height / 2));

            answer3.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.25) - answer3.Width / 2, Convert.ToInt32(this.ClientSize.Height * 0.75));

            answer4.Location = new Point(Convert.ToInt32(this.ClientSize.Width * 0.75) - answer4.Width / 2, Convert.ToInt32(this.ClientSize.Height * 0.75));
        }

        private void answer1_Click(object sender, EventArgs e)
        {
            //stuur 1 naar database
        }

        private void answer2_Click(object sender, EventArgs e)
        {
            //stuur 2 naar database
        }

        private void answer3_Click(object sender, EventArgs e)
        {
            //stuur 3 naar database
        }

        private void answer4_Click(object sender, EventArgs e)
        {
            //stuur 4 naar database
        }
    }
}



