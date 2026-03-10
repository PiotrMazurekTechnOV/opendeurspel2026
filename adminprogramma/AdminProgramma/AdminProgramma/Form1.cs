using Newtonsoft.Json;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdminProgramma
{
    public partial class Form1 : Form
    {

        
        HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.231:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            answer1CheckBox.Tag = answer1Box;
            answer2CheckBox.Tag = answer2Box;
            answer3CheckBox.Tag = answer3Box;
            answer4CheckBox.Tag = answer4Box;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            RefreshBoxes();
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

        async Task<string> AddQuestion(string text, int location_id)
        {
            Question question = new Question
            {
                text = text,
                location_number = location_id
            };
            

            StringContent json = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/question/add", json);

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

                MessageBox.Show(question.text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<List<Location>> GetAllLocations()
        {
            try
            {
                var response = await client.GetAsync("/locations/read");

                var jsonResponse = await response.Content.ReadAsStringAsync();

                List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(jsonResponse);

                return locations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async Task<List<Question>> GetAllQuestions()
        {
            try
            {
                var response = await client.GetAsync("/questions/read");

                var jsonResponse = await response.Content.ReadAsStringAsync();

                List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(jsonResponse);

                return questions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async void createQuestionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await AddQuestion(questionTextTxtBx.Text, (int)locationsComboBox.SelectedValue);
                MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshBoxes();
        }

        private async Task<string> createAnswers()
        {
            List<Answer> answers = new List<Answer>();
            foreach (Control control in answersGroupbox.Controls.OfType<TextBox>())
            {
                System.Windows.Forms.CheckBox pairedCheckBox = answersGroupbox.Controls
                                       .OfType<System.Windows.Forms.CheckBox>()
                                       .FirstOrDefault(chk => chk.Tag == control);

                // If a CheckBox is paired, get its value
                bool isChecked = pairedCheckBox != null && pairedCheckBox.Checked;
                answers.Add(new Answer { text = control.Text, question_id = (int)questionsComboBox.SelectedValue, correct = isChecked });
            }

            StringContent json = new StringContent(JsonConvert.SerializeObject(answers), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/answers/add", json);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }

        private async void createAnswersBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await createAnswers();
                MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RefreshBoxes()
        {
            List<Location> locations = await GetAllLocations();
            List<ComboBoxItem> locationItems = new List<ComboBoxItem>();
            if(locations != null && locations.Count > 0)
            {
                foreach (Location location in locations)
                {
                    locationItems.Add(new ComboBoxItem { Id = location.number, Name = location.number + " " + location.localName });
                }
                locationsComboBox.DataSource = locationItems;
                locationsComboBox.DisplayMember = "Name";
                locationsComboBox.ValueMember = "Id";
            }
            

            List<Question> questions = await GetAllQuestions();
            List<ComboBoxItem> questionItems = new List<ComboBoxItem>();
            if(questions != null && questions.Count > 0)
            {
                foreach (Question question in questions)
                {
                    questionItems.Add(new ComboBoxItem { Id = question.id, Name = question.text });
                }
                questionsComboBox.DataSource = questionItems;
                questionsComboBox.DisplayMember = "Name";
                questionsComboBox.ValueMember = "Id";
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
        public string text { get; set; }
        public int location_number { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public int number { get; set; }
        public string localName { get; set; }
    }

    public class Answer
    { 
        public int id { get; set; }
        public string text { get; set; }
        public int question_id { get; set; }
        public bool correct { get; set; }
    }

    public class ComboBoxItem
    {
        public int Id { get; set; }   
        public string Name { get; set; } 
    }

}
