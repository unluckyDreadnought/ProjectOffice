
namespace ProjectOffice.forms
{
    partial class AuthorizationForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.OrgNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LogInBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.PswdTextBox_nec = new System.Windows.Forms.TextBox();
            this.LoginTextBox_nec = new System.Windows.Forms.TextBox();
            this.showPswdImgBox = new System.Windows.Forms.PictureBox();
            this.settingsImgBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showPswdImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пароль";
            // 
            // OrgNameLbl
            // 
            this.OrgNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OrgNameLbl.AutoSize = true;
            this.OrgNameLbl.Location = new System.Drawing.Point(135, 49);
            this.OrgNameLbl.Name = "OrgNameLbl";
            this.OrgNameLbl.Size = new System.Drawing.Size(328, 32);
            this.OrgNameLbl.TabIndex = 8;
            this.OrgNameLbl.Text = "Название_организации";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин";
            // 
            // LogInBtn
            // 
            this.LogInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LogInBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.LogInBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.LogInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.LogInBtn.Location = new System.Drawing.Point(164, 252);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(239, 52);
            this.LogInBtn.TabIndex = 3;
            this.LogInBtn.Text = "Войти";
            this.LogInBtn.UseVisualStyleBackColor = false;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.Location = new System.Drawing.Point(164, 370);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(239, 52);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Выйти";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // PswdTextBox_nec
            // 
            this.PswdTextBox_nec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PswdTextBox_nec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PswdTextBox_nec.Location = new System.Drawing.Point(164, 176);
            this.PswdTextBox_nec.Name = "PswdTextBox_nec";
            this.PswdTextBox_nec.Size = new System.Drawing.Size(329, 38);
            this.PswdTextBox_nec.TabIndex = 2;
            this.PswdTextBox_nec.UseSystemPasswordChar = true;
            this.PswdTextBox_nec.TextChanged += new System.EventHandler(this.PswdTextBox_nec_TextChanged);
            // 
            // LoginTextBox_nec
            // 
            this.LoginTextBox_nec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginTextBox_nec.AutoCompleteCustomSource.AddRange(new string[] {
            "админ",
            "менеджер",
            "сотрудник"});
            this.LoginTextBox_nec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LoginTextBox_nec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.LoginTextBox_nec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LoginTextBox_nec.Location = new System.Drawing.Point(164, 116);
            this.LoginTextBox_nec.Name = "LoginTextBox_nec";
            this.LoginTextBox_nec.Size = new System.Drawing.Size(329, 38);
            this.LoginTextBox_nec.TabIndex = 1;
            this.LoginTextBox_nec.TextChanged += new System.EventHandler(this.LoginTextBox_nec_TextChanged);
            // 
            // showPswdImgBox
            // 
            this.showPswdImgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.showPswdImgBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPswdImgBox.Image = global::ProjectOffice.Properties.Resources.SHOW_PICTURE;
            this.showPswdImgBox.Location = new System.Drawing.Point(500, 176);
            this.showPswdImgBox.Name = "showPswdImgBox";
            this.showPswdImgBox.Size = new System.Drawing.Size(38, 38);
            this.showPswdImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showPswdImgBox.TabIndex = 10;
            this.showPswdImgBox.TabStop = false;
            this.showPswdImgBox.Click += new System.EventHandler(this.showPswdImgBox_Click);
            // 
            // settingsImgBox
            // 
            this.settingsImgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsImgBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsImgBox.Image = global::ProjectOffice.Properties.Resources.GEAR_WHEEL_PICTURE;
            this.settingsImgBox.Location = new System.Drawing.Point(522, 16);
            this.settingsImgBox.Name = "settingsImgBox";
            this.settingsImgBox.Size = new System.Drawing.Size(39, 39);
            this.settingsImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsImgBox.TabIndex = 11;
            this.settingsImgBox.TabStop = false;
            this.settingsImgBox.Click += new System.EventHandler(this.settingsImgBox_Click);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(573, 427);
            this.ControlBox = false;
            this.Controls.Add(this.settingsImgBox);
            this.Controls.Add(this.showPswdImgBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OrgNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogInBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.PswdTextBox_nec);
            this.Controls.Add(this.LoginTextBox_nec);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthorizationForm";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPswdImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsImgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label OrgNameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox PswdTextBox_nec;
        private System.Windows.Forms.TextBox LoginTextBox_nec;
        private System.Windows.Forms.PictureBox showPswdImgBox;
        private System.Windows.Forms.PictureBox settingsImgBox;
    }
}