namespace AdminProgramma
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.check1 = new System.Windows.Forms.CheckBox();
            this.check2 = new System.Windows.Forms.CheckBox();
            this.check3 = new System.Windows.Forms.CheckBox();
            this.check4 = new System.Windows.Forms.CheckBox();
            this.antwoord1 = new System.Windows.Forms.TextBox();
            this.antwoord3 = new System.Windows.Forms.TextBox();
            this.antwoord2 = new System.Windows.Forms.TextBox();
            this.antwoord4 = new System.Windows.Forms.TextBox();
            this.vraagtext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Location = new System.Drawing.Point(382, 288);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(114, 24);
            this.check1.TabIndex = 2;
            this.check1.Text = "antwoord 1";
            this.check1.UseVisualStyleBackColor = true;
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.Location = new System.Drawing.Point(382, 403);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(110, 24);
            this.check2.TabIndex = 3;
            this.check2.Text = "antwoord2";
            this.check2.UseVisualStyleBackColor = true;
            // 
            // check3
            // 
            this.check3.AutoSize = true;
            this.check3.Location = new System.Drawing.Point(794, 288);
            this.check3.Name = "check3";
            this.check3.Size = new System.Drawing.Size(114, 24);
            this.check3.TabIndex = 4;
            this.check3.Text = "antwoord 3";
            this.check3.UseVisualStyleBackColor = true;
            // 
            // check4
            // 
            this.check4.AutoSize = true;
            this.check4.Location = new System.Drawing.Point(807, 403);
            this.check4.Name = "check4";
            this.check4.Size = new System.Drawing.Size(114, 24);
            this.check4.TabIndex = 5;
            this.check4.Text = "antwoord 4";
            this.check4.UseVisualStyleBackColor = true;
            // 
            // antwoord1
            // 
            this.antwoord1.Location = new System.Drawing.Point(174, 285);
            this.antwoord1.Name = "antwoord1";
            this.antwoord1.Size = new System.Drawing.Size(155, 26);
            this.antwoord1.TabIndex = 6;
            // 
            // antwoord3
            // 
            this.antwoord3.Location = new System.Drawing.Point(622, 288);
            this.antwoord3.Name = "antwoord3";
            this.antwoord3.Size = new System.Drawing.Size(155, 26);
            this.antwoord3.TabIndex = 7;
            // 
            // antwoord2
            // 
            this.antwoord2.Location = new System.Drawing.Point(174, 401);
            this.antwoord2.Name = "antwoord2";
            this.antwoord2.Size = new System.Drawing.Size(155, 26);
            this.antwoord2.TabIndex = 8;
            // 
            // antwoord4
            // 
            this.antwoord4.Location = new System.Drawing.Point(622, 403);
            this.antwoord4.Name = "antwoord4";
            this.antwoord4.Size = new System.Drawing.Size(155, 26);
            this.antwoord4.TabIndex = 9;
            // 
            // vraagtext
            // 
            this.vraagtext.Location = new System.Drawing.Point(316, 62);
            this.vraagtext.Name = "vraagtext";
            this.vraagtext.Size = new System.Drawing.Size(449, 26);
            this.vraagtext.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.vraagtext);
            this.Controls.Add(this.antwoord4);
            this.Controls.Add(this.antwoord2);
            this.Controls.Add(this.antwoord3);
            this.Controls.Add(this.antwoord1);
            this.Controls.Add(this.check4);
            this.Controls.Add(this.check3);
            this.Controls.Add(this.check2);
            this.Controls.Add(this.check1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox check1;
        private System.Windows.Forms.CheckBox check2;
        private System.Windows.Forms.CheckBox check3;
        private System.Windows.Forms.CheckBox check4;
        private System.Windows.Forms.TextBox antwoord1;
        private System.Windows.Forms.TextBox antwoord3;
        private System.Windows.Forms.TextBox antwoord2;
        private System.Windows.Forms.TextBox antwoord4;
        private System.Windows.Forms.TextBox vraagtext;
    }
}

