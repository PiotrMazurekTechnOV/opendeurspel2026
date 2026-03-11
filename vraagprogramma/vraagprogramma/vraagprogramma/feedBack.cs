using System.Net.Http.Headers;

namespace vraagprogramma
{
    public partial class feedBack : Form
    {
        static HttpClient client;
        bool reset = false;
        Location location;
        public feedBack(bool feedback, Location location)
        {
            InitializeComponent();
            this.location = location;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.231:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Load += feedBack_Load;

            if (feedback)
            {
                feedbackLbl.Text = "True!\n Thank for playing!";
                this.BackColor = Color.LightGreen;
            }
            else
            {
                feedbackLbl.Text = "False!\n Thanks for playing!";
                this.BackColor = Color.Red;
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
            
            userIdentification userIdentification = new userIdentification(this.location);
            this.Close();
            userIdentification.Show();
        }
    }
}