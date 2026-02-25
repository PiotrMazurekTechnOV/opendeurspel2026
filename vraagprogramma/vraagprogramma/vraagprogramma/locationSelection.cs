using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vraagprogramma
{
    public partial class locationSelection : Form
    {
        private int location;
        private string klas;
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

        private void klasBtn_Click(object sender, EventArgs e)
        {
            location = Convert.ToInt32(codeTextbox.Text);
            switch (location)
            {
                case 112:
                    klas = "INDUSTRIËLE ICT";
                    break;
                case 104:
                    klas = "ELEKTROTECHNIEKEN";
                    break;
                case 116:
                    klas = "NATUURWETENSCHAPPEN";
                    break;
                default:
                    MessageBox.Show("Er is een fout opgetreden, probeer het opnieuw.");
                    break;
            }

            userIdentification userIdentification = new userIdentification(klas);
            this.Hide();
            userIdentification.Show();
        }
        public string Klas
        {
            get { return klas; }
        }
    }


}
    
