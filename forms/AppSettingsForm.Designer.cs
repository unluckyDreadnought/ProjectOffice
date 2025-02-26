
namespace ProjectOffice.forms
{
    partial class AppSettingsForm
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
            this.backToMenuBtn = new System.Windows.Forms.Button();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.setsPswdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hidePassChars = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hidePassChars)).BeginInit();
            this.SuspendLayout();
            // 
            // backToMenuBtn
            // 
            this.backToMenuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToMenuBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.backToMenuBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.backToMenuBtn.Location = new System.Drawing.Point(36, 274);
            this.backToMenuBtn.Name = "backToMenuBtn";
            this.backToMenuBtn.Size = new System.Drawing.Size(137, 42);
            this.backToMenuBtn.TabIndex = 15;
            this.backToMenuBtn.Text = "В меню";
            this.backToMenuBtn.UseVisualStyleBackColor = false;
            this.backToMenuBtn.Click += new System.EventHandler(this.backToMenuBtn_Click);
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveSettingsBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSettingsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveSettingsBtn.Location = new System.Drawing.Point(315, 274);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(149, 42);
            this.saveSettingsBtn.TabIndex = 16;
            this.saveSettingsBtn.Text = "Сохранить";
            this.saveSettingsBtn.UseVisualStyleBackColor = false;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // setsPswdTextBox
            // 
            this.setsPswdTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.setsPswdTextBox.Location = new System.Drawing.Point(62, 131);
            this.setsPswdTextBox.MaxLength = 256;
            this.setsPswdTextBox.Name = "setsPswdTextBox";
            this.setsPswdTextBox.Size = new System.Drawing.Size(347, 28);
            this.setsPswdTextBox.TabIndex = 14;
            this.setsPswdTextBox.UseSystemPasswordChar = true;
            this.setsPswdTextBox.TextChanged += new System.EventHandler(this.setsPswdTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 101);
            this.label1.TabIndex = 12;
            this.label1.Text = "Настройка пароля к настройкам приложения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hidePassChars
            // 
            this.hidePassChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hidePassChars.Image = global::ProjectOffice.Properties.Resources.SHOW_PICTURE;
            this.hidePassChars.Location = new System.Drawing.Point(426, 131);
            this.hidePassChars.Name = "hidePassChars";
            this.hidePassChars.Size = new System.Drawing.Size(39, 39);
            this.hidePassChars.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hidePassChars.TabIndex = 17;
            this.hidePassChars.TabStop = false;
            this.hidePassChars.Click += new System.EventHandler(this.hidePassChars_Click);
            // 
            // AppSettingsForm
            // 
            this.AcceptButton = this.saveSettingsBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(506, 335);
            this.Controls.Add(this.hidePassChars);
            this.Controls.Add(this.backToMenuBtn);
            this.Controls.Add(this.saveSettingsBtn);
            this.Controls.Add(this.setsPswdTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AppSettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.AppSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hidePassChars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToMenuBtn;
        private System.Windows.Forms.Button saveSettingsBtn;
        private System.Windows.Forms.TextBox setsPswdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox hidePassChars;
    }
}