
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;


namespace vraagprogramma
{
    public partial class userIdentification : Form
    {
        private int code;
        private Location location;
        static HttpClient client;
        public userIdentification(Location location)
        {
            InitializeComponent();
            this.location = location;

            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.231:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
         
        }

            
        private void userIdentification_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            label1.Text = "WELKOM BIJ " + location.localName;
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
        private async void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //question opzoeken op basis van locatie "/question/get/location/:location_number"

                //volgend formulier openen met user en question als gegevens

                int code = Convert.ToInt32(textBox1.Text);

                
                var userResponse = await client.GetAsync("/user/get/code/" + code);
                var userJson = await userResponse.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(userJson);

                
                var questionResponse = await client.GetAsync("/question/get/location/" + location.number);
                var questionJson = await questionResponse.Content.ReadAsStringAsync();
                Question question = JsonConvert.DeserializeObject<Question>(questionJson);

                answerSelection answerForm = new answerSelection(user, question);
                this.Hide();
                answerForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
    }



}


