namespace formulierProgramma
{
    partial class form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cuiButton1 = new CuoreUI.Controls.cuiButton();
            this.naam_textbox = new CuoreUI.Controls.cuiTextBox();
            this.naamOuders_textbox = new CuoreUI.Controls.cuiTextBox();
            this.email_textbox = new CuoreUI.Controls.cuiTextBox();
            this.naam_label = new CuoreUI.Controls.cuiLabel();
            this.naamOuder_label = new CuoreUI.Controls.cuiLabel();
            this.email_Label = new CuoreUI.Controls.cuiLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // cuiButton1
            // 
            this.cuiButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cuiButton1.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton1.CheckButton = false;
            this.cuiButton1.Checked = false;
            this.cuiButton1.CheckedBackground = System.Drawing.Color.Transparent;
            this.cuiButton1.CheckedForeColor = System.Drawing.Color.Transparent;
            this.cuiButton1.CheckedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.CheckedOutline = System.Drawing.Color.Transparent;
            this.cuiButton1.Content = "";
            this.cuiButton1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cuiButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cuiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton1.ForeColor = System.Drawing.Color.Transparent;
            this.cuiButton1.HoverBackground = System.Drawing.Color.Transparent;
            this.cuiButton1.HoverForeColor = System.Drawing.Color.Transparent;
            this.cuiButton1.HoverImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiButton1.Image = null;
            this.cuiButton1.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton1.Location = new System.Drawing.Point(74, 382);
            this.cuiButton1.Name = "cuiButton1";
            this.cuiButton1.NormalBackground = System.Drawing.Color.Transparent;
            this.cuiButton1.NormalForeColor = System.Drawing.Color.Transparent;
            this.cuiButton1.NormalImageTint = System.Drawing.Color.Black;
            this.cuiButton1.NormalOutline = System.Drawing.Color.Transparent;
            this.cuiButton1.OutlineThickness = 1F;
            this.cuiButton1.PressedBackground = System.Drawing.Color.Transparent;
            this.cuiButton1.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cuiButton1.PressedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cuiButton1.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cuiButton1.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiButton1.Size = new System.Drawing.Size(493, 82);
            this.cuiButton1.TabIndex = 1;
            this.cuiButton1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.cuiButton1.TextPadding = -1;
            this.cuiButton1.TextSpacing = 2;
            this.cuiButton1.Click += new System.EventHandler(this.cuiButton1_Click);
            // 
            // naam_textbox
            // 
            this.naam_textbox.BackgroundColor = System.Drawing.Color.White;
            this.naam_textbox.Content = "";
            this.naam_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.naam_textbox.FocusBackgroundColor = System.Drawing.Color.White;
            this.naam_textbox.FocusImageTint = System.Drawing.Color.White;
            this.naam_textbox.FocusOutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.naam_textbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naam_textbox.ForeColor = System.Drawing.Color.Gray;
            this.naam_textbox.Image = null;
            this.naam_textbox.ImageExpand = new System.Drawing.Point(0, 0);
            this.naam_textbox.ImageOffset = new System.Drawing.Point(0, 0);
            this.naam_textbox.Location = new System.Drawing.Point(314, 164);
            this.naam_textbox.Multiline = false;
            this.naam_textbox.Name = "naam_textbox";
            this.naam_textbox.NormalImageTint = System.Drawing.Color.White;
            this.naam_textbox.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.naam_textbox.Padding = new System.Windows.Forms.Padding(16, 6, 16, 0);
            this.naam_textbox.PasswordChar = false;
            this.naam_textbox.PlaceholderColor = System.Drawing.Color.LightGray;
            this.naam_textbox.PlaceholderText = "Placeholder text..";
            this.naam_textbox.Rounding = new System.Windows.Forms.Padding(8);
            this.naam_textbox.Size = new System.Drawing.Size(469, 29);
            this.naam_textbox.TabIndex = 2;
            this.naam_textbox.TextOffset = new System.Drawing.Size(0, 0);
            this.naam_textbox.UnderlinedStyle = true;
            // 
            // naamOuders_textbox
            // 
            this.naamOuders_textbox.BackgroundColor = System.Drawing.Color.White;
            this.naamOuders_textbox.Content = "";
            this.naamOuders_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.naamOuders_textbox.FocusBackgroundColor = System.Drawing.Color.White;
            this.naamOuders_textbox.FocusImageTint = System.Drawing.Color.White;
            this.naamOuders_textbox.FocusOutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.naamOuders_textbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naamOuders_textbox.ForeColor = System.Drawing.Color.Gray;
            this.naamOuders_textbox.Image = null;
            this.naamOuders_textbox.ImageExpand = new System.Drawing.Point(0, 0);
            this.naamOuders_textbox.ImageOffset = new System.Drawing.Point(0, 0);
            this.naamOuders_textbox.Location = new System.Drawing.Point(314, 219);
            this.naamOuders_textbox.Multiline = false;
            this.naamOuders_textbox.Name = "naamOuders_textbox";
            this.naamOuders_textbox.NormalImageTint = System.Drawing.Color.White;
            this.naamOuders_textbox.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.naamOuders_textbox.Padding = new System.Windows.Forms.Padding(16, 6, 16, 0);
            this.naamOuders_textbox.PasswordChar = false;
            this.naamOuders_textbox.PlaceholderColor = System.Drawing.Color.LightGray;
            this.naamOuders_textbox.PlaceholderText = "Placeholder text..";
            this.naamOuders_textbox.Rounding = new System.Windows.Forms.Padding(8);
            this.naamOuders_textbox.Size = new System.Drawing.Size(469, 29);
            this.naamOuders_textbox.TabIndex = 3;
            this.naamOuders_textbox.TextOffset = new System.Drawing.Size(0, 0);
            this.naamOuders_textbox.UnderlinedStyle = true;
            this.naamOuders_textbox.ContentChanged += new System.EventHandler(this.cuiTextBox2_ContentChanged);
            // 
            // email_textbox
            // 
            this.email_textbox.BackgroundColor = System.Drawing.Color.White;
            this.email_textbox.Content = "";
            this.email_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email_textbox.FocusBackgroundColor = System.Drawing.Color.White;
            this.email_textbox.FocusImageTint = System.Drawing.Color.White;
            this.email_textbox.FocusOutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.email_textbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_textbox.ForeColor = System.Drawing.Color.Gray;
            this.email_textbox.Image = null;
            this.email_textbox.ImageExpand = new System.Drawing.Point(0, 0);
            this.email_textbox.ImageOffset = new System.Drawing.Point(0, 0);
            this.email_textbox.Location = new System.Drawing.Point(314, 275);
            this.email_textbox.Multiline = false;
            this.email_textbox.Name = "email_textbox";
            this.email_textbox.NormalImageTint = System.Drawing.Color.White;
            this.email_textbox.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.email_textbox.Padding = new System.Windows.Forms.Padding(16, 6, 16, 0);
            this.email_textbox.PasswordChar = false;
            this.email_textbox.PlaceholderColor = System.Drawing.Color.LightGray;
            this.email_textbox.PlaceholderText = "Placeholder text..";
            this.email_textbox.Rounding = new System.Windows.Forms.Padding(8);
            this.email_textbox.Size = new System.Drawing.Size(469, 29);
            this.email_textbox.TabIndex = 4;
            this.email_textbox.TextOffset = new System.Drawing.Size(0, 0);
            this.email_textbox.UnderlinedStyle = true;
            // 
            // naam_label
            // 
            this.naam_label.Content = "Naam\\ ";
            this.naam_label.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.naam_label.Location = new System.Drawing.Point(57, 164);
            this.naam_label.Name = "naam_label";
            this.naam_label.Size = new System.Drawing.Size(163, 29);
            this.naam_label.TabIndex = 5;
            this.naam_label.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // naamOuder_label
            // 
            this.naamOuder_label.Content = "Naam\\ Ouders";
            this.naamOuder_label.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.naamOuder_label.Location = new System.Drawing.Point(57, 219);
            this.naamOuder_label.Name = "naamOuder_label";
            this.naamOuder_label.Size = new System.Drawing.Size(163, 29);
            this.naamOuder_label.TabIndex = 6;
            this.naamOuder_label.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // email_Label
            // 
            this.email_Label.Content = "Email";
            this.email_Label.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.email_Label.Location = new System.Drawing.Point(57, 275);
            this.email_Label.Name = "email_Label";
            this.email_Label.Size = new System.Drawing.Size(163, 29);
            this.email_Label.TabIndex = 7;
            this.email_Label.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 565);
            this.Controls.Add(this.email_Label);
            this.Controls.Add(this.naamOuder_label);
            this.Controls.Add(this.naam_label);
            this.Controls.Add(this.email_textbox);
            this.Controls.Add(this.naamOuders_textbox);
            this.Controls.Add(this.naam_textbox);
            this.Controls.Add(this.cuiButton1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private CuoreUI.Controls.cuiTextBox naam_textbox;
        private CuoreUI.Controls.cuiTextBox naamOuders_textbox;
        private CuoreUI.Controls.cuiTextBox email_textbox;
        private CuoreUI.Controls.cuiLabel naam_label;
        private CuoreUI.Controls.cuiLabel naamOuder_label;
        private CuoreUI.Controls.cuiLabel email_Label;
    }
}

