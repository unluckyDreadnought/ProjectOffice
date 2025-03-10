
namespace ProjectOffice.forms
{
    partial class UserEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.specCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addEditBtn = new System.Windows.Forms.Button();
            this.userAccountEditPnl = new System.Windows.Forms.Panel();
            this.roleCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.generatePswdBtn = new System.Windows.Forms.Button();
            this.generateLoginBtn = new System.Windows.Forms.Button();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userPhoto = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backToListBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.userAccountEditPnl.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhoto)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.73077F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.26923F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.userAccountEditPnl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.panel4.Controls.Add(this.specCombo);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.patronymicTextBox);
            this.panel4.Controls.Add(this.nameTextBox);
            this.panel4.Controls.Add(this.surnameTextBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel4.Location = new System.Drawing.Point(218, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(504, 275);
            this.panel4.TabIndex = 1;
            // 
            // specCombo
            // 
            this.specCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specCombo.FormattingEnabled = true;
            this.specCombo.Location = new System.Drawing.Point(69, 214);
            this.specCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.specCombo.Name = "specCombo";
            this.specCombo.Size = new System.Drawing.Size(387, 33);
            this.specCombo.TabIndex = 1;
            this.specCombo.SelectedIndexChanged += new System.EventHandler(this.specCombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "*Фамилия";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "*Имя";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Специальность";
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patronymicTextBox.Location = new System.Drawing.Point(69, 151);
            this.patronymicTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.patronymicTextBox.MaxLength = 50;
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(387, 30);
            this.patronymicTextBox.TabIndex = 0;
            this.patronymicTextBox.TextChanged += new System.EventHandler(this.snpTextBox_TextChanged);
            this.patronymicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fioFields_KeyPressed);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(69, 89);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameTextBox.MaxLength = 45;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(387, 30);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.snpTextBox_TextChanged);
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fioFields_KeyPressed);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameTextBox.Location = new System.Drawing.Point(69, 30);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.surnameTextBox.MaxLength = 60;
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(387, 30);
            this.surnameTextBox.TabIndex = 0;
            this.surnameTextBox.TextChanged += new System.EventHandler(this.snpTextBox_TextChanged);
            this.surnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fioFields_KeyPressed);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.addEditBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(218, 391);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 57);
            this.panel1.TabIndex = 0;
            // 
            // addEditBtn
            // 
            this.addEditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addEditBtn.AutoSize = true;
            this.addEditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.addEditBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addEditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEditBtn.ForeColor = System.Drawing.Color.White;
            this.addEditBtn.Location = new System.Drawing.Point(356, 0);
            this.addEditBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addEditBtn.Name = "addEditBtn";
            this.addEditBtn.Size = new System.Drawing.Size(144, 50);
            this.addEditBtn.TabIndex = 0;
            this.addEditBtn.Text = "button1";
            this.addEditBtn.UseVisualStyleBackColor = false;
            this.addEditBtn.Click += new System.EventHandler(this.addEditBtn_Click);
            // 
            // userAccountEditPnl
            // 
            this.userAccountEditPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.userAccountEditPnl, 2);
            this.userAccountEditPnl.Controls.Add(this.roleCombo);
            this.userAccountEditPnl.Controls.Add(this.label6);
            this.userAccountEditPnl.Controls.Add(this.label1);
            this.userAccountEditPnl.Controls.Add(this.label);
            this.userAccountEditPnl.Controls.Add(this.generatePswdBtn);
            this.userAccountEditPnl.Controls.Add(this.generateLoginBtn);
            this.userAccountEditPnl.Controls.Add(this.passTextBox);
            this.userAccountEditPnl.Controls.Add(this.loginTextBox);
            this.userAccountEditPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAccountEditPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userAccountEditPnl.Location = new System.Drawing.Point(3, 281);
            this.userAccountEditPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userAccountEditPnl.Name = "userAccountEditPnl";
            this.userAccountEditPnl.Size = new System.Drawing.Size(719, 106);
            this.userAccountEditPnl.TabIndex = 1;
            // 
            // roleCombo
            // 
            this.roleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleCombo.FormattingEnabled = true;
            this.roleCombo.Location = new System.Drawing.Point(9, 28);
            this.roleCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleCombo.Name = "roleCombo";
            this.roleCombo.Size = new System.Drawing.Size(200, 33);
            this.roleCombo.TabIndex = 3;
            this.roleCombo.SelectedIndexChanged += new System.EventHandler(this.roleCombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "*Роль";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "*Логин";
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(499, 2);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(88, 25);
            this.label.TabIndex = 2;
            this.label.Text = "*Пароль";
            // 
            // generatePswdBtn
            // 
            this.generatePswdBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generatePswdBtn.AutoSize = true;
            this.generatePswdBtn.Location = new System.Drawing.Point(494, 62);
            this.generatePswdBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generatePswdBtn.Name = "generatePswdBtn";
            this.generatePswdBtn.Size = new System.Drawing.Size(216, 43);
            this.generatePswdBtn.TabIndex = 0;
            this.generatePswdBtn.Text = "Сгенерировать";
            this.generatePswdBtn.UseVisualStyleBackColor = true;
            this.generatePswdBtn.Click += new System.EventHandler(this.generatePswdBtn_Click);
            // 
            // generateLoginBtn
            // 
            this.generateLoginBtn.AutoSize = true;
            this.generateLoginBtn.Location = new System.Drawing.Point(237, 62);
            this.generateLoginBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateLoginBtn.Name = "generateLoginBtn";
            this.generateLoginBtn.Size = new System.Drawing.Size(225, 43);
            this.generateLoginBtn.TabIndex = 0;
            this.generateLoginBtn.Text = "Сгенерировать";
            this.generateLoginBtn.UseVisualStyleBackColor = true;
            this.generateLoginBtn.Click += new System.EventHandler(this.generateLoginBtn_Click);
            // 
            // passTextBox
            // 
            this.passTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passTextBox.Location = new System.Drawing.Point(494, 30);
            this.passTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passTextBox.MaxLength = 128;
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(216, 30);
            this.passTextBox.TabIndex = 0;
            this.passTextBox.TextChanged += new System.EventHandler(this.accountFields_TextChanged);
            this.passTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accountFields_KeyPressed);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(237, 30);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginTextBox.MaxLength = 100;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(225, 30);
            this.loginTextBox.TabIndex = 0;
            this.loginTextBox.TextChanged += new System.EventHandler(this.accountFields_TextChanged);
            this.loginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accountFields_KeyPressed);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.panel3.Controls.Add(this.userPhoto);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 275);
            this.panel3.TabIndex = 1;
            // 
            // userPhoto
            // 
            this.userPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPhoto.Location = new System.Drawing.Point(25, 12);
            this.userPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userPhoto.Name = "userPhoto";
            this.userPhoto.Size = new System.Drawing.Size(167, 240);
            this.userPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhoto.TabIndex = 0;
            this.userPhoto.TabStop = false;
            this.userPhoto.Click += new System.EventHandler(this.userPhoto_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.backToListBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(3, 391);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 57);
            this.panel2.TabIndex = 0;
            // 
            // backToListBtn
            // 
            this.backToListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToListBtn.AutoSize = true;
            this.backToListBtn.Location = new System.Drawing.Point(3, 2);
            this.backToListBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backToListBtn.Name = "backToListBtn";
            this.backToListBtn.Size = new System.Drawing.Size(163, 48);
            this.backToListBtn.TabIndex = 0;
            this.backToListBtn.Text = "К списку";
            this.backToListBtn.UseVisualStyleBackColor = true;
            this.backToListBtn.Click += new System.EventHandler(this.backToListBtn_Click);
            // 
            // UserEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserEditor_FormClosing);
            this.Load += new System.EventHandler(this.UserEditor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.userAccountEditPnl.ResumeLayout(false);
            this.userAccountEditPnl.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPhoto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addEditBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button backToListBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox specCombo;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Panel userAccountEditPnl;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox userPhoto;
        private System.Windows.Forms.Button generatePswdBtn;
        private System.Windows.Forms.Button generateLoginBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox roleCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
    }
}