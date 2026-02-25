using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace formulierProgramma
{

    public partial class form1 : Form
    {
        static HttpClient client;
        string nameChild;
        string nameGuardian;
        string email;
        public string result;


        public form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
        static async Task<string> addUser(string nameChild, string nameGuardian, string Email)
        {
            User user = new User
            { 
                nameChild = nameChild,
                nameGuardian = nameGuardian,
                email = Email
                
            };
            StringContent json = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8,
                   "application/json");

            var response = await client.PostAsync(
                "user/add",
                json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.formulier_foto1;

            // achtergrond aanpassen
            this.BackgroundImageLayout = ImageLayout.Stretch; // past aan naar het hele scherm
            UpdateLabelPositions();
        }

        public class User
        {
            public string nameGuardian { get; set; }
            public string nameChild { get; set; }
            public string email { get; set; }
            
        }

        private async void cuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // waarden uit textboxes halen
                 nameChild = naam_textbox.Text;
                 nameGuardian = naamOuders_textbox.Text;
                 email = email_textbox.Text;


                // API call
                result = await addUser(nameChild, nameGuardian, email);

               

                Code codewindow = new Code(result);
                this.Hide();
                codewindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij verzenden: " + ex.Message);
            }
        }

        private void cuiTextBox2_ContentChanged(object sender, EventArgs e)
        {
            // naam ouders tekstbox
         
        }

        private void SetPosition(Control c, double xPercent, double yPercent)
        {
            c.Left = (int)(ClientSize.Width * xPercent);
            c.Top = (int)(ClientSize.Height * yPercent);
        }
        private void UpdateLabelPositions()
        {
            SetPosition(naam_textbox, 0.20, 0.265);
            SetPosition(naamOuders_textbox, 0.20, 0.38);
            SetPosition(email_textbox, 0.20, 0.49);
            SetPosition(cuiButton1, 0.35, 0.59);
        }

        private void naam_textbox_ContentChanged(object sender, EventArgs e)
        {
            
        }

        private void email_textbox_ContentChanged(object sender, EventArgs e)
        {
           
        }
    }
}
