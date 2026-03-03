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

namespace AdminProgramma
{
    public partial class Form1 : Form
    {

        
        HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        async Task<string> AddUser(string nameChild, string nameGuardian, string email)
        {
            User user = new User
            {
                nameChild = nameChild,
                nameGuardian = nameGuardian,
                email = email
            };

            StringContent json = new StringContent(JsonConvert.SerializeObject(user));

            var response = await client.PostAsync("/user/add", json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }

        async Task<string> AddQuestion(string text)
        {
            

            StringContent json = new StringContent(JsonConvert.SerializeObject(user));

            var response = await client.PostAsync("/user/add", json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }

        async Task<string> AddLocation(int locationNumber, string name)
        {
            Location location = new Location
            {
                number = locationNumber,
                localName = name
            };

            StringContent json = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("/location/add", json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }

        private async void aanvraagvragen_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await client.GetAsync("/get/question/" + 1);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                Question question = JsonConvert.DeserializeObject<Question>(jsonResponse);

                MessageBox.Show(question.question);
            }
            catch (Exception ex)
            {

            }
        }

        private async void createQuestionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await client.GetAsync("/get/question/" + 1);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                Question question = JsonConvert.DeserializeObject<Question>(jsonResponse);

                MessageBox.Show(question.question);
            }
            catch (Exception ex)
            {

            }
        }

        private async void createLocationBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await AddLocation(Convert.ToInt32(locationNumberTxtBx.Text), locationNameTxtBx.Text);
                MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class User
    {
        public int id { get; set; }
        public string nameChild { get; set; }
        public string nameGuardian { get; set; }
        public string email { get; set; }
        public int code { get; set; }

    }

    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public int locations_id { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public int number { get; set; }
        public string localName { get; set; }
    }

}
