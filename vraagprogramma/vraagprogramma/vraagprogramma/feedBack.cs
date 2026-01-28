using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class feedBack : Form
    {
        static HttpClient client;
        bool reset = false;
        public feedBack()
        {
            InitializeComponent();

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}