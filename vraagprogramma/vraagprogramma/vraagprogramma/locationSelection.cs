using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vraagprogramma
{
    public partial class locationSelection : Form
    {
        private int location;
        private string klas;
        static HttpClient client;

        public locationSelection()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        private void locationSelection_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            klasBtn.Left = (this.ClientSize.Width - klasBtn.Width) / 2;
            klasBtn.Top = (this.ClientSize.Height - klasBtn.Height) / 3;
            codeTextbox.Left = (this.ClientSize.Width - codeTextbox.Width) / 2;
            codeTextbox.Top = klasBtn.Bottom + 5;


        }

        private async void klasBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await client.GetAsync("/location/get/number/" + Convert.ToInt32(codeTextbox.Text));
                var jsonResponse = await response.Content.ReadAsStringAsync();

                Location location = JsonConvert.DeserializeObject<Location>(jsonResponse);
                klas = location.localName;

                userIdentification userIdentification = new userIdentification(location);
                this.Hide();
                userIdentification.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            
        }

        /*
        public string Klas
        {
            get { return klas; }
        }

        */
       
    }

        public class Location
        {
            public int id { get; set; }
            public string localName { get; set; }
            public int number { get; set; }
        }
        
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public int code { get; set; }
        }
    
        public class Question
        {
            public int id { get; set; }
            public string questionText { get; set; }
            public int locationNumber { get; set; }
        }



}

