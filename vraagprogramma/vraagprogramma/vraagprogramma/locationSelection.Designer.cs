namespace vraagprogramma
{
    partial class locationSelection
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
            klasBtn = new Button();
            codeTextbox = new TextBox();
            SuspendLayout();
            // 
            // klasBtn
            // 
            klasBtn.Location = new Point(444, 190);
            klasBtn.Margin = new Padding(2, 2, 2, 2);
            klasBtn.Name = "klasBtn";
            klasBtn.Size = new Size(78, 20);
            klasBtn.TabIndex = 0;
            klasBtn.Text = "Klaar";
            klasBtn.UseVisualStyleBackColor = true;
            klasBtn.Click += klasBtn_Click;
            // 
            // codeTextbox
            // 
            codeTextbox.Location = new Point(428, 151);
            codeTextbox.Margin = new Padding(2, 2, 2, 2);
            codeTextbox.Name = "codeTextbox";
            codeTextbox.Size = new Size(106, 23);
            codeTextbox.TabIndex = 1;
            // 
            // locationSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 305);
            Controls.Add(codeTextbox);
            Controls.Add(klasBtn);
            Margin = new Padding(2, 2, 2, 2);
            Name = "locationSelection";
            Text = "locationSelectionForm";
            Load += locationSelection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button klasBtn;
        private TextBox codeTextbox;
    }
}