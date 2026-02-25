namespace formulierProgramma
{
    partial class Code
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
            this.CodeLabel = new CuoreUI.Controls.cuiLabel();
            this.SuspendLayout();
            // 
            // CodeLabel
            // 
            this.CodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.CodeLabel.Content = "Random\\ Code";
            this.CodeLabel.Font = new System.Drawing.Font("Broadway", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CodeLabel.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.CodeLabel.Location = new System.Drawing.Point(254, 77);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(210, 47);
            this.CodeLabel.TabIndex = 0;
            this.CodeLabel.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CodeLabel);
            this.Name = "Code";
            this.Text = "Code";
            this.Load += new System.EventHandler(this.Code_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CuoreUI.Controls.cuiLabel CodeLabel;
    }
}