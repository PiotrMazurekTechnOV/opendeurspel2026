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

namespace formulierProgramma
{
    public partial class form1 : Form
    {
        static HttpClient client;

        public form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
        static async Task<string> addUser(int Id, string NameGuardian, string NameChild, string Email, int Code)
        {
            User user = new User
            {
                id = Id,
                nameGaurdian = NameGuardian,
                nameChild = NameChild,
                email = Email,
                code = Code
            };
            StringContent json = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8,
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
            public int id { get; set; }
            public string nameGaurdian { get; set; }
            public string nameChild { get; set; }
            public string email { get; set; }
            public int code { get; set; }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            Code codewindow = new Code();
            this.Hide();
            codewindow.Show();
        }

        private void cuiTextBox2_ContentChanged(object sender, EventArgs e)
        {

        }
        
        private void UpdateLabelPositions()
        {
            naam_textbox.Left = this.ClientSize.Width / 5;
            naam_textbox.Top = this.ClientSize.Height / 7 * 2;

            naamOuders_textbox.Left = this.ClientSize.Width / 5;
            naamOuders_textbox.Top = this.ClientSize.Height / 5*14/7;

            email_textbox.Left = this.ClientSize.Width / 5;
            email_textbox.Top = this.ClientSize.Height / 102 * 50;

            cuiButton1.Left = this.ClientSize.Width / 14 * 5;
            cuiButton1.Top = this.ClientSize.Height / 7 * 4;
        }




    }
}
