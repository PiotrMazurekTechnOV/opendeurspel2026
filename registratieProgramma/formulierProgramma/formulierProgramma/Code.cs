using Newtonsoft.Json;
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
        private HashSet<Keys> keysPressed = new HashSet<Keys>();
        public Code(string result)
        {
            InitializeComponent();
            this.result = result;

            this.KeyPreview = true;
            this.KeyDown += Code_KeyDown;
            this.KeyUp += Code_KeyUp;
        }
        public class CodeResponse
        {
          public int code { get; set; }
        }

        private void Code_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Properties.Resources.formulier_foto2;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            Timer timer = new Timer();
            timer.Interval = 20000; // 20 seconden
            timer.Tick += timer1_Tick;
            timer.Start();

            CodeResponse codeObj = JsonConvert.DeserializeObject<CodeResponse>(this.result);

            // alleen de code tonen
            CodeLabel.Content = "User toegevoegd! Code: " + codeObj.code;
            CodeLabel.Font = new Font("Segoe UI", 58, FontStyle.Bold);
            CodeLabel.ForeColor = Color.DarkBlue;
        }
        
        private void CodeLabel_Load(object sender, EventArgs e)
        {
            
        }
       
        private void cuiButton1_Click(object sender, EventArgs e)
        {
            //back button
            form1 form1window = new form1();
            this.Hide();
            form1window.Show();
        }
        private void Code_KeyDown(object sender, KeyEventArgs e)
        {
            keysPressed.Add(e.KeyCode);

            if (keysPressed.Contains(Keys.I) &&
                keysPressed.Contains(Keys.C) &&
                keysPressed.Contains(Keys.T))
            {
                Environment.Exit(0);
            }
        }
        
        private void Code_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Environment.Exit(0);
        }
    }
}
