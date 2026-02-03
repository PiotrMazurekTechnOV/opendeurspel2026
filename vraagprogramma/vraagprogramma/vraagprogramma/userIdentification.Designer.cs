namespace vraagprogramma
{
    partial class userIdentification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userIdentification));
            label1 = new Label();
            textBox1 = new TextBox();
            vraagCode = new Label();
            confirmBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 40F);
            label1.ForeColor = Color.FromArgb(252, 231, 0);
            label1.Location = new Point(71, 98);
            label1.Name = "label1";
            label1.Size = new Size(1220, 141);
            label1.TabIndex = 0;
            label1.Text = "WELKOM BIJ INDUSTRIËLE ICT";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(651, 298);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // vraagCode
            // 
            vraagCode.AutoSize = true;
            vraagCode.Font = new Font("Poppins", 13F);
            vraagCode.ForeColor = Color.White;
            vraagCode.Location = new Point(614, 250);
            vraagCode.Name = "vraagCode";
            vraagCode.Size = new Size(224, 46);
            vraagCode.TabIndex = 2;
            vraagCode.Text = "VUL JE CODE IN:";
            // 
            // confirmBtn
            // 
            confirmBtn.Location = new Point(667, 367);
            confirmBtn.Margin = new Padding(4, 5, 4, 5);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(136, 40);
            confirmBtn.TabIndex = 3;
            confirmBtn.Text = "Beginnen !";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // userIdentification
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1459, 798);
            Controls.Add(confirmBtn);
            Controls.Add(vraagCode);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "userIdentification";
            Text = "userIdentification";
            Load += userIdentification_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label vraagCode;
        private Button confirmBtn;
    }
}