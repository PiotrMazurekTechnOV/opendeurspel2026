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
            klasBtn.Location = new Point(634, 317);
            klasBtn.Name = "klasBtn";
            klasBtn.Size = new Size(112, 34);
            klasBtn.TabIndex = 0;
            klasBtn.Text = "Klaar";
            klasBtn.UseVisualStyleBackColor = true;
            // 
            // codeTextbox
            // 
            codeTextbox.Location = new Point(612, 251);
            codeTextbox.Name = "codeTextbox";
            codeTextbox.Size = new Size(150, 31);
            codeTextbox.TabIndex = 1;
            // 
            // locationSelection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1352, 509);
            Controls.Add(codeTextbox);
            Controls.Add(klasBtn);
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