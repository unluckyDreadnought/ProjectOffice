
namespace ProjectOffice.forms
{
    partial class UsersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userSnp = new System.Windows.Forms.Label();
            this.userMode = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableActionBtnPanel = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addUserBtn = new System.Windows.Forms.ToolStripButton();
            this.editUserBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteUserBtn = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.usersTable = new System.Windows.Forms.DataGridView();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backToMenuBtn = new System.Windows.Forms.Button();
            this.userEditorPanel = new System.Windows.Forms.Panel();
            this.hideUserEditorBtn = new System.Windows.Forms.Button();
            this.userRoleCombo = new System.Windows.Forms.ComboBox();
            this.userPswdTextBox = new System.Windows.Forms.TextBox();
            this.userLoginTextBox = new System.Windows.Forms.TextBox();
            this.userPatronymicTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userSurnameTextBox = new System.Windows.Forms.TextBox();
            this.saveUserBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableActionBtnPanel.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).BeginInit();
            this.userEditorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.backToMenuBtn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.userEditorPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.440357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.464167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.userSnp);
            this.panel1.Controls.Add(this.userMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 36);
            this.panel1.TabIndex = 0;
            // 
            // userSnp
            // 
            this.userSnp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userSnp.AutoSize = true;
            this.userSnp.Location = new System.Drawing.Point(288, 6);
            this.userSnp.Name = "userSnp";
            this.userSnp.Size = new System.Drawing.Size(79, 29);
            this.userSnp.TabIndex = 0;
            this.userSnp.Text = "label1";
            // 
            // userMode
            // 
            this.userMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userMode.AutoSize = true;
            this.userMode.Location = new System.Drawing.Point(456, 6);
            this.userMode.Name = "userMode";
            this.userMode.Size = new System.Drawing.Size(79, 29);
            this.userMode.TabIndex = 0;
            this.userMode.Text = "label1";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.tableActionBtnPanel);
            this.panel2.Controls.Add(this.usersTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(611, 358);
            this.panel2.TabIndex = 1;
            // 
            // tableActionBtnPanel
            // 
            this.tableActionBtnPanel.Controls.Add(this.toolStrip2);
            this.tableActionBtnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableActionBtnPanel.Location = new System.Drawing.Point(0, 314);
            this.tableActionBtnPanel.Name = "tableActionBtnPanel";
            this.tableActionBtnPanel.Size = new System.Drawing.Size(611, 44);
            this.tableActionBtnPanel.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserBtn,
            this.editUserBtn,
            this.deleteUserBtn,
            this.toolsDisplayModeCombo});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(182, 8);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(211, 28);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // addUserBtn
            // 
            this.addUserBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addUserBtn.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addUserBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.addUserBtn.Size = new System.Drawing.Size(29, 25);
            this.addUserBtn.Text = "Добавить";
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // editUserBtn
            // 
            this.editUserBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editUserBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editUserBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editUserBtn.Name = "editUserBtn";
            this.editUserBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.editUserBtn.Size = new System.Drawing.Size(29, 25);
            this.editUserBtn.Text = "Редактировать";
            this.editUserBtn.Click += new System.EventHandler(this.editUserBtn_Click);
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteUserBtn.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteUserBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.deleteUserBtn.Size = new System.Drawing.Size(29, 25);
            this.deleteUserBtn.Text = "Удалить";
            // 
            // toolsDisplayModeCombo
            // 
            this.toolsDisplayModeCombo.Items.AddRange(new object[] {
            "Иконка",
            "Текст",
            "Совместный"});
            this.toolsDisplayModeCombo.Name = "toolsDisplayModeCombo";
            this.toolsDisplayModeCombo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolsDisplayModeCombo.Size = new System.Drawing.Size(121, 28);
            this.toolsDisplayModeCombo.ToolTipText = "Режим отображения";
            // 
            // usersTable
            // 
            this.usersTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.usersTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usersTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.usersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fio,
            this.login,
            this.pass,
            this.role});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.usersTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.usersTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.usersTable.EnableHeadersVisualStyles = false;
            this.usersTable.Location = new System.Drawing.Point(0, 0);
            this.usersTable.Name = "usersTable";
            this.usersTable.RowHeadersVisible = false;
            this.usersTable.RowHeadersWidth = 51;
            this.usersTable.RowTemplate.Height = 24;
            this.usersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersTable.Size = new System.Drawing.Size(608, 308);
            this.usersTable.TabIndex = 0;
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.MinimumWidth = 6;
            this.fio.Name = "fio";
            // 
            // login
            // 
            this.login.HeaderText = "Логин";
            this.login.MinimumWidth = 6;
            this.login.Name = "login";
            // 
            // pass
            // 
            this.pass.HeaderText = "Пароль";
            this.pass.MinimumWidth = 6;
            this.pass.Name = "pass";
            // 
            // role
            // 
            this.role.HeaderText = "Роль";
            this.role.MinimumWidth = 6;
            this.role.Name = "role";
            // 
            // backToMenuBtn
            // 
            this.backToMenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenuBtn.Location = new System.Drawing.Point(3, 409);
            this.backToMenuBtn.Name = "backToMenuBtn";
            this.backToMenuBtn.Size = new System.Drawing.Size(150, 38);
            this.backToMenuBtn.TabIndex = 2;
            this.backToMenuBtn.Text = "Меню";
            this.backToMenuBtn.UseVisualStyleBackColor = true;
            this.backToMenuBtn.Click += new System.EventHandler(this.backToMenuBtn_Click);
            // 
            // userEditorPanel
            // 
            this.userEditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.userEditorPanel.Controls.Add(this.hideUserEditorBtn);
            this.userEditorPanel.Controls.Add(this.userRoleCombo);
            this.userEditorPanel.Controls.Add(this.userPswdTextBox);
            this.userEditorPanel.Controls.Add(this.userLoginTextBox);
            this.userEditorPanel.Controls.Add(this.userPatronymicTextBox);
            this.userEditorPanel.Controls.Add(this.userNameTextBox);
            this.userEditorPanel.Controls.Add(this.userSurnameTextBox);
            this.userEditorPanel.Controls.Add(this.saveUserBtn);
            this.userEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userEditorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userEditorPanel.Location = new System.Drawing.Point(620, 3);
            this.userEditorPanel.Name = "userEditorPanel";
            this.tableLayoutPanel1.SetRowSpan(this.userEditorPanel, 4);
            this.userEditorPanel.Size = new System.Drawing.Size(211, 444);
            this.userEditorPanel.TabIndex = 3;
            // 
            // hideUserEditorBtn
            // 
            this.hideUserEditorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideUserEditorBtn.Location = new System.Drawing.Point(4, 395);
            this.hideUserEditorBtn.Name = "hideUserEditorBtn";
            this.hideUserEditorBtn.Size = new System.Drawing.Size(43, 40);
            this.hideUserEditorBtn.TabIndex = 3;
            this.hideUserEditorBtn.Text = ">";
            this.hideUserEditorBtn.UseVisualStyleBackColor = true;
            this.hideUserEditorBtn.Click += new System.EventHandler(this.hideUserEditorBtn_Click);
            // 
            // userRoleCombo
            // 
            this.userRoleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userRoleCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userRoleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userRoleCombo.FormattingEnabled = true;
            this.userRoleCombo.Items.AddRange(new object[] {
            "Администратор",
            "Менеджер",
            "Сотрудник"});
            this.userRoleCombo.Location = new System.Drawing.Point(36, 306);
            this.userRoleCombo.Name = "userRoleCombo";
            this.userRoleCombo.Size = new System.Drawing.Size(166, 33);
            this.userRoleCombo.TabIndex = 2;
            // 
            // userPswdTextBox
            // 
            this.userPswdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPswdTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userPswdTextBox.Location = new System.Drawing.Point(36, 245);
            this.userPswdTextBox.Name = "userPswdTextBox";
            this.userPswdTextBox.Size = new System.Drawing.Size(166, 30);
            this.userPswdTextBox.TabIndex = 1;
            this.userPswdTextBox.Text = "*********";
            // 
            // userLoginTextBox
            // 
            this.userLoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLoginTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userLoginTextBox.Location = new System.Drawing.Point(36, 195);
            this.userLoginTextBox.Name = "userLoginTextBox";
            this.userLoginTextBox.Size = new System.Drawing.Size(166, 30);
            this.userLoginTextBox.TabIndex = 1;
            this.userLoginTextBox.Text = "login12345";
            // 
            // userPatronymicTextBox
            // 
            this.userPatronymicTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPatronymicTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userPatronymicTextBox.Location = new System.Drawing.Point(36, 122);
            this.userPatronymicTextBox.Name = "userPatronymicTextBox";
            this.userPatronymicTextBox.Size = new System.Drawing.Size(166, 30);
            this.userPatronymicTextBox.TabIndex = 1;
            this.userPatronymicTextBox.Text = "Иванович";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userNameTextBox.Location = new System.Drawing.Point(36, 69);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(166, 30);
            this.userNameTextBox.TabIndex = 1;
            this.userNameTextBox.Text = "Иван";
            // 
            // userSurnameTextBox
            // 
            this.userSurnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userSurnameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userSurnameTextBox.Location = new System.Drawing.Point(36, 23);
            this.userSurnameTextBox.Name = "userSurnameTextBox";
            this.userSurnameTextBox.Size = new System.Drawing.Size(166, 30);
            this.userSurnameTextBox.TabIndex = 1;
            this.userSurnameTextBox.Text = "Иванов";
            // 
            // saveUserBtn
            // 
            this.saveUserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveUserBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveUserBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveUserBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveUserBtn.Location = new System.Drawing.Point(74, 395);
            this.saveUserBtn.Name = "saveUserBtn";
            this.saveUserBtn.Size = new System.Drawing.Size(128, 40);
            this.saveUserBtn.TabIndex = 0;
            this.saveUserBtn.Text = "Сохранить";
            this.saveUserBtn.UseVisualStyleBackColor = false;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableActionBtnPanel.ResumeLayout(false);
            this.tableActionBtnPanel.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).EndInit();
            this.userEditorPanel.ResumeLayout(false);
            this.userEditorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userSnp;
        private System.Windows.Forms.Label userMode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel tableActionBtnPanel;
        private System.Windows.Forms.DataGridView usersTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.Button backToMenuBtn;
        private System.Windows.Forms.Panel userEditorPanel;
        private System.Windows.Forms.Button hideUserEditorBtn;
        private System.Windows.Forms.ComboBox userRoleCombo;
        private System.Windows.Forms.TextBox userPswdTextBox;
        private System.Windows.Forms.TextBox userLoginTextBox;
        private System.Windows.Forms.TextBox userPatronymicTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox userSurnameTextBox;
        private System.Windows.Forms.Button saveUserBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton editUserBtn;
        private System.Windows.Forms.ToolStripButton deleteUserBtn;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayModeCombo;
        private System.Windows.Forms.ToolStripButton addUserBtn;
    }
}