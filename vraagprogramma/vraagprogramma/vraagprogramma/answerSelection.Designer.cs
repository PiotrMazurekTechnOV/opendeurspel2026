namespace vraagprogramma
{
    partial class answerSelection
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
            questionLbl = new Label();
            answer1 = new Button();
            answer2 = new Button();
            answer3 = new Button();
            answer4 = new Button();
            technovLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)technovLogo).BeginInit();
            SuspendLayout();
            // 
            // questionLbl
            // 
            questionLbl.Anchor = AnchorStyles.None;
            questionLbl.AutoSize = true;
            questionLbl.BackColor = Color.Transparent;
            questionLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            questionLbl.Location = new Point(384, 69);
            questionLbl.Name = "questionLbl";
            questionLbl.Size = new Size(46, 25);
            questionLbl.TabIndex = 0;
            questionLbl.Text = "text";
            questionLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // answer1
            // 
            answer1.Anchor = AnchorStyles.None;
            answer1.AutoSize = true;
            answer1.BackColor = Color.Transparent;
            answer1.Location = new Point(127, 150);
            answer1.Name = "answer1";
            answer1.Size = new Size(112, 35);
            answer1.TabIndex = 1;
            answer1.Text = "button1";
            answer1.UseVisualStyleBackColor = false;
            answer1.Click += answer1_Click;
            // 
            // answer2
            // 
            answer2.Anchor = AnchorStyles.None;
            answer2.AutoSize = true;
            answer2.BackColor = Color.Transparent;
            answer2.Location = new Point(553, 150);
            answer2.Name = "answer2";
            answer2.Size = new Size(112, 35);
            answer2.TabIndex = 2;
            answer2.Text = "button2";
            answer2.UseVisualStyleBackColor = false;
            answer2.Click += answer2_Click;
            // 
            // answer3
            // 
            answer3.Anchor = AnchorStyles.None;
            answer3.AutoSize = true;
            answer3.BackColor = Color.Transparent;
            answer3.Location = new Point(127, 311);
            answer3.Name = "answer3";
            answer3.Size = new Size(112, 35);
            answer3.TabIndex = 3;
            answer3.Text = "button3";
            answer3.UseVisualStyleBackColor = false;
            answer3.Click += answer3_Click;
            // 
            // answer4
            // 
            answer4.Anchor = AnchorStyles.None;
            answer4.AutoSize = true;
            answer4.BackColor = Color.Transparent;
            answer4.Location = new Point(553, 311);
            answer4.Name = "answer4";
            answer4.Size = new Size(112, 35);
            answer4.TabIndex = 4;
            answer4.Text = "button4";
            answer4.UseVisualStyleBackColor = false;
            answer4.Click += answer4_Click;
            // 
            // technovLogo
            // 
            technovLogo.BackColor = Color.Transparent;
            technovLogo.BackgroundImage = Properties.Resources.technov_logo_transparant;
            technovLogo.BackgroundImageLayout = ImageLayout.Stretch;
            technovLogo.Location = new Point(607, 19);
            technovLogo.Name = "technovLogo";
            technovLogo.Size = new Size(150, 75);
            technovLogo.TabIndex = 5;
            technovLogo.TabStop = false;
            // 
            // answerSelection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = Properties.Resources.questionBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(technovLogo);
            Controls.Add(answer4);
            Controls.Add(answer3);
            Controls.Add(answer2);
            Controls.Add(answer1);
            Controls.Add(questionLbl);
            Name = "answerSelection";
            Text = "answerSelection";
            ((System.ComponentModel.ISupportInitialize)technovLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label questionLbl;
        private Button answer1;
        private Button answer2;
        private Button answer3;
        private Button answer4;
        private PictureBox technovLogo;
    }
}