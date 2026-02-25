using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace formulierProgramma
{
    public partial class Code : Form
    {
        string result;

        public Code(string result)
        {
            InitializeComponent();
            
        }

        private void Code_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Properties.Resources.formulier_foto2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        
        private void CodeLabel_Load(object sender, EventArgs e)
        {
            CodeLabel.Text = "User toegevoegd!\n" + result ;
        }

        
    }
}
