using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace formulierProgramma
{
    public partial class Form1 : Form
    {
        public HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/");
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

            // achtergrond aanpassen
            this.BackgroundImage = Image.FromFile("images/technov formulier1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch; // past aan naar het hele scherm
        }

        public class User
        {
            public int id { get; set; }
            public string nameGaurdian { get; set; }
            public string nameChild { get; set; }
            public string email { get; set; }
            public int code { get; set; }
        }

    }
}
