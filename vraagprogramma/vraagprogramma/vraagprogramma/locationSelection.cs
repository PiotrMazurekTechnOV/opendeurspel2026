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
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            userIdentification userIdentification = new userIdentification(klas);
            this.Hide();
            userIdentification.Show();
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
    
}

