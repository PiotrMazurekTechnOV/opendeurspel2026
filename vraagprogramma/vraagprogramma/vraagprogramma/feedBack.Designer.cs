namespace vraagprogramma
{
    partial class feedBack
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
            components = new System.ComponentModel.Container();
            feedbackLbl = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // feedbackLbl
            // 
            feedbackLbl.AutoSize = true;
            feedbackLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            feedbackLbl.Location = new Point(355, 155);
            feedbackLbl.Name = "feedbackLbl";
            feedbackLbl.Size = new Size(90, 25);
            feedbackLbl.TabIndex = 0;
            feedbackLbl.Text = "feedback";
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // feedBack
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(feedbackLbl);
            Name = "feedBack";
            Text = "feedBack";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label feedbackLbl;
        private System.Windows.Forms.Timer timer1;
    }
}