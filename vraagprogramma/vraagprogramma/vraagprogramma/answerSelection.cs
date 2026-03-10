using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class answerSelection : Form
    {
        static HttpClient client;
        private Question question;
        public answerSelection(User user, Question question)
        {
            InitializeComponent();

            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.231:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Load += answerSelection_Load;
            

            this.question = question;
            questionLbl.Text = question.text;
            
        }


        private async void answerSelection_Load(object sender, EventArgs e)
        {


            technovLogo.Size = new Size(this.ClientSize.Width / 4, this.ClientSize.Height / 5);
            technovLogo.Location = new Point(this.ClientSize.Width - technovLogo.Width, 0);
            float fontSize = this.ClientSize.Height / 25;

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

            try
            {
                var response = await client.GetAsync("/answer/get/question-on-id/" + this.question.id);
                var json = await response.Content.ReadAsStringAsync();

                List<Answer> answers = JsonConvert.DeserializeObject<List<Answer>>(json);
                int index = 0;
                foreach(Button btn in Controls.OfType<Button>()) 
                {
                    btn.Text = answers[index].text;
                    btn.Tag = answers[index].correct;
                    index++;
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void answer1_Click(object sender, EventArgs e)
        {
            //stuur 1 naar database

            feedBack feedback = new();
            feedback.Show();
            feedback.FormClosed += (s, args) => this.Close();

        }

        private void answer2_Click(object sender, EventArgs e)
        {
            //stuur 2 naar database

            feedBack feedback = new();
            feedback.Show();
            feedback.FormClosed += (s, args) => this.Close();

        }

        private void answer3_Click(object sender, EventArgs e)
        {
            //stuur 3 naar database

            feedBack feedback = new();
            feedback.Show();
            feedback.FormClosed += (s, args) => this.Close();

        }

        private void answer4_Click(object sender, EventArgs e)
        {
            //stuur 4 naar database

            feedBack feedback = new();
            feedback.Show();
            feedback.FormClosed += (s, args) => this.Close();


        }

        
    }

    public class  Question
    {
        public int id { get; set; }
        public string text { get; set; }
        public int? locations_id { get; set; }
    }

    public class Answer
    { 
        public int id { get; set; } 
        public string text { get; set; }

        public bool correct
        {
            get; set; 
        }
        public int question_id { get; set; }
    }
    

}


