
namespace ProjectOffice.forms
{
    partial class ConnectionSettingsForm
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
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.usrTextBox = new System.Windows.Forms.TextBox();
            this.usrPswdTextBox = new System.Windows.Forms.TextBox();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.testConnectionBtn = new System.Windows.Forms.Button();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.unknownUsrPlugPanel = new System.Windows.Forms.Panel();
            this.hidePswdChar = new System.Windows.Forms.PictureBox();
            this.closeSettingsBtn = new System.Windows.Forms.Button();
            this.checkSettingsPswdBtn = new System.Windows.Forms.Button();
            this.pswdToSettingsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.unknownUsrPlugPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hidePswdChar)).BeginInit();
            this.SuspendLayout();
            // 
            // hostTextBox
            // 
            this.hostTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hostTextBox.Location = new System.Drawing.Point(197, 70);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(322, 38);
            this.hostTextBox.TabIndex = 0;
            this.hostTextBox.TextChanged += new System.EventHandler(this.settingTextBox_TextChanged);
            // 
            // usrTextBox
            // 
            this.usrTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usrTextBox.Location = new System.Drawing.Point(47, 171);
            this.usrTextBox.Name = "usrTextBox";
            this.usrTextBox.Size = new System.Drawing.Size(191, 38);
            this.usrTextBox.TabIndex = 1;
            this.usrTextBox.TextChanged += new System.EventHandler(this.settingTextBox_TextChanged);
            // 
            // usrPswdTextBox
            // 
            this.usrPswdTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usrPswdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usrPswdTextBox.Location = new System.Drawing.Point(259, 171);
            this.usrPswdTextBox.Name = "usrPswdTextBox";
            this.usrPswdTextBox.Size = new System.Drawing.Size(260, 38);
            this.usrPswdTextBox.TabIndex = 2;
            this.usrPswdTextBox.TextChanged += new System.EventHandler(this.settingTextBox_TextChanged);
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dbNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbNameTextBox.Location = new System.Drawing.Point(197, 250);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(322, 38);
            this.dbNameTextBox.TabIndex = 3;
            this.dbNameTextBox.Visible = false;
            // 
            // testConnectionBtn
            // 
            this.testConnectionBtn.AutoSize = true;
            this.testConnectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.testConnectionBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.testConnectionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testConnectionBtn.Location = new System.Drawing.Point(179, 368);
            this.testConnectionBtn.Name = "testConnectionBtn";
            this.testConnectionBtn.Size = new System.Drawing.Size(214, 43);
            this.testConnectionBtn.TabIndex = 4;
            this.testConnectionBtn.Text = "Протестировать";
            this.testConnectionBtn.UseVisualStyleBackColor = false;
            this.testConnectionBtn.Click += new System.EventHandler(this.testConnectionBtn_Click);
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.AutoSize = true;
            this.saveSettingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveSettingsBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSettingsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveSettingsBtn.Location = new System.Drawing.Point(403, 368);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(149, 43);
            this.saveSettingsBtn.TabIndex = 5;
            this.saveSettingsBtn.Text = "Сохранить";
            this.saveSettingsBtn.UseVisualStyleBackColor = false;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.AutoSize = true;
            this.closeBtn.Location = new System.Drawing.Point(13, 368);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(119, 43);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "Адрес размещения";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(42, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пользователь БД";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(259, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пароль пользователя БД";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(42, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Название БД";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Настройки подключения";
            // 
            // unknownUsrPlugPanel
            // 
            this.unknownUsrPlugPanel.Controls.Add(this.hidePswdChar);
            this.unknownUsrPlugPanel.Controls.Add(this.closeSettingsBtn);
            this.unknownUsrPlugPanel.Controls.Add(this.checkSettingsPswdBtn);
            this.unknownUsrPlugPanel.Controls.Add(this.pswdToSettingsTextBox);
            this.unknownUsrPlugPanel.Controls.Add(this.label6);
            this.unknownUsrPlugPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unknownUsrPlugPanel.Location = new System.Drawing.Point(0, 0);
            this.unknownUsrPlugPanel.Name = "unknownUsrPlugPanel";
            this.unknownUsrPlugPanel.Size = new System.Drawing.Size(562, 423);
            this.unknownUsrPlugPanel.TabIndex = 8;
            // 
            // hidePswdChar
            // 
            this.hidePswdChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hidePswdChar.Image = global::ProjectOffice.Properties.Resources.SHOW_PICTURE;
            this.hidePswdChar.Location = new System.Drawing.Point(449, 170);
            this.hidePswdChar.Name = "hidePswdChar";
            this.hidePswdChar.Size = new System.Drawing.Size(39, 39);
            this.hidePswdChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hidePswdChar.TabIndex = 3;
            this.hidePswdChar.TabStop = false;
            this.hidePswdChar.Click += new System.EventHandler(this.hidePswdChar_Click);
            // 
            // closeSettingsBtn
            // 
            this.closeSettingsBtn.Location = new System.Drawing.Point(13, 365);
            this.closeSettingsBtn.Name = "closeSettingsBtn";
            this.closeSettingsBtn.Size = new System.Drawing.Size(147, 46);
            this.closeSettingsBtn.TabIndex = 2;
            this.closeSettingsBtn.Text = "Закрыть";
            this.closeSettingsBtn.UseVisualStyleBackColor = true;
            this.closeSettingsBtn.Click += new System.EventHandler(this.closeSettingsBtn_Click);
            // 
            // checkSettingsPswdBtn
            // 
            this.checkSettingsPswdBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.checkSettingsPswdBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkSettingsPswdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkSettingsPswdBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.checkSettingsPswdBtn.Location = new System.Drawing.Point(389, 365);
            this.checkSettingsPswdBtn.Name = "checkSettingsPswdBtn";
            this.checkSettingsPswdBtn.Size = new System.Drawing.Size(161, 46);
            this.checkSettingsPswdBtn.TabIndex = 2;
            this.checkSettingsPswdBtn.Text = "Проверить";
            this.checkSettingsPswdBtn.UseVisualStyleBackColor = false;
            this.checkSettingsPswdBtn.Click += new System.EventHandler(this.checkSettingsPswdBtn_Click);
            // 
            // pswdToSettingsTextBox
            // 
            this.pswdToSettingsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pswdToSettingsTextBox.Location = new System.Drawing.Point(83, 171);
            this.pswdToSettingsTextBox.Name = "pswdToSettingsTextBox";
            this.pswdToSettingsTextBox.Size = new System.Drawing.Size(346, 34);
            this.pswdToSettingsTextBox.TabIndex = 1;
            this.pswdToSettingsTextBox.TextChanged += new System.EventHandler(this.pswdToSettingsTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(95, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(348, 84);
            this.label6.TabIndex = 0;
            this.label6.Text = "Чтобы открыть доступ к настройкам, введите пароль";
            // 
            // ConnectionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(562, 423);
            this.Controls.Add(this.unknownUsrPlugPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveSettingsBtn);
            this.Controls.Add(this.testConnectionBtn);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.usrTextBox);
            this.Controls.Add(this.usrPswdTextBox);
            this.Controls.Add(this.dbNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ConnectionSettingsForm";
            this.Text = "ConnectionSettingsForm";
            this.Load += new System.EventHandler(this.ConnectionSettingsForm_Load);
            this.unknownUsrPlugPanel.ResumeLayout(false);
            this.unknownUsrPlugPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hidePswdChar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox usrTextBox;
        private System.Windows.Forms.TextBox usrPswdTextBox;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.Button testConnectionBtn;
        private System.Windows.Forms.Button saveSettingsBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel unknownUsrPlugPanel;
        private System.Windows.Forms.Button closeSettingsBtn;
        private System.Windows.Forms.Button checkSettingsPswdBtn;
        private System.Windows.Forms.TextBox pswdToSettingsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox hidePswdChar;
    }
}