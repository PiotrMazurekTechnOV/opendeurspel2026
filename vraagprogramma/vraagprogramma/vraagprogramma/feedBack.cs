using System.Net.Http.Headers;

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
            bool feedback = true;
            if (feedback)
            {
                feedbackLbl.Text = "True!";
                this.BackColor = Color.LightGreen;
            }
            else
            {
                feedbackLbl.Text = "False!";
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
            this.Close();
        }
    }
}