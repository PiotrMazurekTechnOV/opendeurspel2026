using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulierProgramma
{
    public partial class Code : Form
    {
        public Code()
        {
            InitializeComponent();
        }

        private void Code_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Image.FromFile("images/technov formulier.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
