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



    }
}
