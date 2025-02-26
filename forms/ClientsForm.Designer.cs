
namespace ProjectOffice.forms
{
    partial class ClientsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userSnpLbl = new System.Windows.Forms.Label();
            this.userModelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clientsTable = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innKpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ogrn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rshet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fizSwitchBtn = new System.Windows.Forms.ToolStripButton();
            this.urSwitchBtn = new System.Windows.Forms.ToolStripButton();
            this.addClientBtn = new System.Windows.Forms.ToolStripButton();
            this.editClientBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteClientBtn = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayMode = new System.Windows.Forms.ToolStripComboBox();
            this.backToMenuBtn = new System.Windows.Forms.Button();
            this.fizClientEditorPanel = new System.Windows.Forms.Panel();
            this.clientBirthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.clientPhoneMTextBox = new System.Windows.Forms.MaskedTextBox();
            this.hideEditorPanelBtn = new System.Windows.Forms.Button();
            this.clientDepartmentCodeTextBox = new System.Windows.Forms.TextBox();
            this.clientDepartmentTextBox = new System.Windows.Forms.TextBox();
            this.clientPatronymicTextBox = new System.Windows.Forms.TextBox();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.clientPaspSeriesTextBox = new System.Windows.Forms.TextBox();
            this.clientPaspNumberTextBox = new System.Windows.Forms.TextBox();
            this.clientSurnameTextBox = new System.Windows.Forms.TextBox();
            this.clientBankAccountTextBox = new System.Windows.Forms.TextBox();
            this.clientPaspAddressTextBox = new System.Windows.Forms.TextBox();
            this.clientEmailTextBox = new System.Windows.Forms.TextBox();
            this.clientBank = new System.Windows.Forms.TextBox();
            this.saveClientBtn = new System.Windows.Forms.Button();
            this.clientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.fizClientEditorPanel.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.fizClientEditorPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.440357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.464167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 569);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.userSnpLbl);
            this.panel1.Controls.Add(this.userModelbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 47);
            this.panel1.TabIndex = 0;
            // 
            // userSnpLbl
            // 
            this.userSnpLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userSnpLbl.AutoSize = true;
            this.userSnpLbl.Location = new System.Drawing.Point(264, 6);
            this.userSnpLbl.Name = "userSnpLbl";
            this.userSnpLbl.Size = new System.Drawing.Size(60, 24);
            this.userSnpLbl.TabIndex = 0;
            this.userSnpLbl.Text = "label1";
            // 
            // userModelbl
            // 
            this.userModelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userModelbl.AutoSize = true;
            this.userModelbl.Location = new System.Drawing.Point(432, 6);
            this.userModelbl.Name = "userModelbl";
            this.userModelbl.Size = new System.Drawing.Size(60, 24);
            this.userModelbl.TabIndex = 0;
            this.userModelbl.Text = "label1";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.clientsTable);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 56);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(587, 454);
            this.panel2.TabIndex = 1;
            // 
            // clientsTable
            // 
            this.clientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clientsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.clientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientId,
            this.clientName,
            this.clientPhone,
            this.clientEmail,
            this.dop});
            this.clientsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.clientsTable.EnableHeadersVisualStyles = false;
            this.clientsTable.Location = new System.Drawing.Point(0, 0);
            this.clientsTable.Name = "clientsTable";
            this.clientsTable.RowHeadersVisible = false;
            this.clientsTable.RowHeadersWidth = 51;
            this.clientsTable.RowTemplate.Height = 24;
            this.clientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientsTable.Size = new System.Drawing.Size(587, 410);
            this.clientsTable.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.name,
            this.address,
            this.innKpp,
            this.ogrn,
            this.rshet,
            this.bankName,
            this.bik,
            this.okved,
            this.phone,
            this.email});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(587, 410);
            this.dataGridView1.TabIndex = 5;
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            // 
            // address
            // 
            this.address.HeaderText = "Адрес";
            this.address.MinimumWidth = 6;
            this.address.Name = "address";
            // 
            // innKpp
            // 
            this.innKpp.HeaderText = "(Серия|ИНН)/(Номер|КПП)";
            this.innKpp.MinimumWidth = 6;
            this.innKpp.Name = "innKpp";
            // 
            // ogrn
            // 
            this.ogrn.HeaderText = "ОГРН";
            this.ogrn.MinimumWidth = 6;
            this.ogrn.Name = "ogrn";
            // 
            // rshet
            // 
            this.rshet.HeaderText = "Р/с";
            this.rshet.MinimumWidth = 6;
            this.rshet.Name = "rshet";
            // 
            // bankName
            // 
            this.bankName.HeaderText = "Банк";
            this.bankName.MinimumWidth = 6;
            this.bankName.Name = "bankName";
            // 
            // bik
            // 
            this.bik.HeaderText = "БИК";
            this.bik.MinimumWidth = 6;
            this.bik.Name = "bik";
            // 
            // okved
            // 
            this.okved.HeaderText = "ОКВЭД";
            this.okved.MinimumWidth = 6;
            this.okved.Name = "okved";
            // 
            // phone
            // 
            this.phone.HeaderText = "Телефон";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            // 
            // email
            // 
            this.email.HeaderText = "Почта";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 410);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(587, 44);
            this.panel3.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fizSwitchBtn,
            this.urSwitchBtn,
            this.addClientBtn,
            this.editClientBtn,
            this.deleteClientBtn,
            this.toolsDisplayMode});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(109, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(297, 27);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fizSwitchBtn
            // 
            this.fizSwitchBtn.Checked = true;
            this.fizSwitchBtn.CheckOnClick = true;
            this.fizSwitchBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fizSwitchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fizSwitchBtn.Image = ((System.Drawing.Image)(resources.GetObject("fizSwitchBtn.Image")));
            this.fizSwitchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fizSwitchBtn.Name = "fizSwitchBtn";
            this.fizSwitchBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.fizSwitchBtn.Size = new System.Drawing.Size(35, 24);
            this.fizSwitchBtn.Text = "Физ.";
            this.fizSwitchBtn.ToolTipText = "Редактирование физ. лиц";
            this.fizSwitchBtn.Click += new System.EventHandler(this.fizSwitchBtn_Click);
            // 
            // urSwitchBtn
            // 
            this.urSwitchBtn.CheckOnClick = true;
            this.urSwitchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.urSwitchBtn.Image = ((System.Drawing.Image)(resources.GetObject("urSwitchBtn.Image")));
            this.urSwitchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.urSwitchBtn.Name = "urSwitchBtn";
            this.urSwitchBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.urSwitchBtn.Size = new System.Drawing.Size(33, 24);
            this.urSwitchBtn.Text = "Юр.";
            this.urSwitchBtn.ToolTipText = "Редактирование юр. лиц";
            this.urSwitchBtn.Click += new System.EventHandler(this.urSwitchBtn_Click);
            // 
            // addClientBtn
            // 
            this.addClientBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addClientBtn.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Size = new System.Drawing.Size(24, 24);
            this.addClientBtn.Text = "Добавить";
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // editClientBtn
            // 
            this.editClientBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editClientBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editClientBtn.Name = "editClientBtn";
            this.editClientBtn.Size = new System.Drawing.Size(24, 24);
            this.editClientBtn.Text = "Удалить";
            this.editClientBtn.Click += new System.EventHandler(this.editClientBtn_Click);
            // 
            // deleteClientBtn
            // 
            this.deleteClientBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteClientBtn.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteClientBtn.Name = "deleteClientBtn";
            this.deleteClientBtn.Size = new System.Drawing.Size(24, 24);
            this.deleteClientBtn.Text = "Редактировать";
            // 
            // toolsDisplayMode
            // 
            this.toolsDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolsDisplayMode.Items.AddRange(new object[] {
            "Иконка",
            "Текст",
            "Совместный"});
            this.toolsDisplayMode.Name = "toolsDisplayMode";
            this.toolsDisplayMode.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolsDisplayMode.Size = new System.Drawing.Size(121, 27);
            this.toolsDisplayMode.ToolTipText = "Режим отображения";
            // 
            // backToMenuBtn
            // 
            this.backToMenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenuBtn.Location = new System.Drawing.Point(3, 516);
            this.backToMenuBtn.Name = "backToMenuBtn";
            this.backToMenuBtn.Size = new System.Drawing.Size(150, 38);
            this.backToMenuBtn.TabIndex = 2;
            this.backToMenuBtn.Text = "Меню";
            this.backToMenuBtn.UseVisualStyleBackColor = true;
            this.backToMenuBtn.Click += new System.EventHandler(this.backToMenuBtn_Click);
            // 
            // fizClientEditorPanel
            // 
            this.fizClientEditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.fizClientEditorPanel.Controls.Add(this.clientBirthDatePicker);
            this.fizClientEditorPanel.Controls.Add(this.clientPhoneMTextBox);
            this.fizClientEditorPanel.Controls.Add(this.hideEditorPanelBtn);
            this.fizClientEditorPanel.Controls.Add(this.clientDepartmentCodeTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientDepartmentTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientPatronymicTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientNameTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientPaspSeriesTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientPaspNumberTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientSurnameTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientBankAccountTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientPaspAddressTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientEmailTextBox);
            this.fizClientEditorPanel.Controls.Add(this.clientBank);
            this.fizClientEditorPanel.Controls.Add(this.saveClientBtn);
            this.fizClientEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fizClientEditorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fizClientEditorPanel.Location = new System.Drawing.Point(596, 3);
            this.fizClientEditorPanel.Name = "fizClientEditorPanel";
            this.tableLayoutPanel1.SetRowSpan(this.fizClientEditorPanel, 4);
            this.fizClientEditorPanel.Size = new System.Drawing.Size(213, 563);
            this.fizClientEditorPanel.TabIndex = 3;
            // 
            // clientBirthDatePicker
            // 
            this.clientBirthDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.clientBirthDatePicker.Location = new System.Drawing.Point(10, 130);
            this.clientBirthDatePicker.Name = "clientBirthDatePicker";
            this.clientBirthDatePicker.Size = new System.Drawing.Size(190, 26);
            this.clientBirthDatePicker.TabIndex = 6;
            // 
            // clientPhoneMTextBox
            // 
            this.clientPhoneMTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientPhoneMTextBox.Location = new System.Drawing.Point(23, 382);
            this.clientPhoneMTextBox.Mask = "+7 (999) 000-0000";
            this.clientPhoneMTextBox.Name = "clientPhoneMTextBox";
            this.clientPhoneMTextBox.Size = new System.Drawing.Size(180, 26);
            this.clientPhoneMTextBox.TabIndex = 5;
            // 
            // hideEditorPanelBtn
            // 
            this.hideEditorPanelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideEditorPanelBtn.Location = new System.Drawing.Point(4, 513);
            this.hideEditorPanelBtn.Name = "hideEditorPanelBtn";
            this.hideEditorPanelBtn.Size = new System.Drawing.Size(43, 40);
            this.hideEditorPanelBtn.TabIndex = 3;
            this.hideEditorPanelBtn.Text = ">";
            this.hideEditorPanelBtn.UseVisualStyleBackColor = true;
            this.hideEditorPanelBtn.Click += new System.EventHandler(this.hideEditorPanelBtn_Click);
            // 
            // clientDepartmentCodeTextBox
            // 
            this.clientDepartmentCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientDepartmentCodeTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientDepartmentCodeTextBox.Location = new System.Drawing.Point(36, 202);
            this.clientDepartmentCodeTextBox.Name = "clientDepartmentCodeTextBox";
            this.clientDepartmentCodeTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientDepartmentCodeTextBox.TabIndex = 1;
            this.clientDepartmentCodeTextBox.Text = "Подразделение";
            // 
            // clientDepartmentTextBox
            // 
            this.clientDepartmentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientDepartmentTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientDepartmentTextBox.Location = new System.Drawing.Point(36, 166);
            this.clientDepartmentTextBox.Name = "clientDepartmentTextBox";
            this.clientDepartmentTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientDepartmentTextBox.TabIndex = 1;
            this.clientDepartmentTextBox.Text = "Кем Выдан";
            // 
            // clientPatronymicTextBox
            // 
            this.clientPatronymicTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientPatronymicTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientPatronymicTextBox.Location = new System.Drawing.Point(36, 94);
            this.clientPatronymicTextBox.Name = "clientPatronymicTextBox";
            this.clientPatronymicTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientPatronymicTextBox.TabIndex = 1;
            this.clientPatronymicTextBox.Text = "Иванович";
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientNameTextBox.Location = new System.Drawing.Point(36, 58);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientNameTextBox.TabIndex = 1;
            this.clientNameTextBox.Text = "Иван";
            // 
            // clientPaspSeriesTextBox
            // 
            this.clientPaspSeriesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientPaspSeriesTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientPaspSeriesTextBox.Location = new System.Drawing.Point(36, 238);
            this.clientPaspSeriesTextBox.Name = "clientPaspSeriesTextBox";
            this.clientPaspSeriesTextBox.Size = new System.Drawing.Size(88, 26);
            this.clientPaspSeriesTextBox.TabIndex = 1;
            this.clientPaspSeriesTextBox.Text = "2203";
            // 
            // clientPaspNumberTextBox
            // 
            this.clientPaspNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientPaspNumberTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientPaspNumberTextBox.Location = new System.Drawing.Point(123, 238);
            this.clientPaspNumberTextBox.Name = "clientPaspNumberTextBox";
            this.clientPaspNumberTextBox.Size = new System.Drawing.Size(88, 26);
            this.clientPaspNumberTextBox.TabIndex = 1;
            this.clientPaspNumberTextBox.Text = "959614";
            // 
            // clientSurnameTextBox
            // 
            this.clientSurnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientSurnameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientSurnameTextBox.Location = new System.Drawing.Point(36, 22);
            this.clientSurnameTextBox.Name = "clientSurnameTextBox";
            this.clientSurnameTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientSurnameTextBox.TabIndex = 1;
            this.clientSurnameTextBox.Text = "Иванов";
            // 
            // clientBankAccountTextBox
            // 
            this.clientBankAccountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientBankAccountTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientBankAccountTextBox.Location = new System.Drawing.Point(42, 310);
            this.clientBankAccountTextBox.Name = "clientBankAccountTextBox";
            this.clientBankAccountTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientBankAccountTextBox.TabIndex = 1;
            this.clientBankAccountTextBox.Text = "Расч./счёт";
            // 
            // clientPaspAddressTextBox
            // 
            this.clientPaspAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientPaspAddressTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientPaspAddressTextBox.Location = new System.Drawing.Point(40, 346);
            this.clientPaspAddressTextBox.Name = "clientPaspAddressTextBox";
            this.clientPaspAddressTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientPaspAddressTextBox.TabIndex = 1;
            this.clientPaspAddressTextBox.Text = "Адрес";
            // 
            // clientEmailTextBox
            // 
            this.clientEmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientEmailTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientEmailTextBox.Location = new System.Drawing.Point(42, 418);
            this.clientEmailTextBox.Name = "clientEmailTextBox";
            this.clientEmailTextBox.Size = new System.Drawing.Size(168, 26);
            this.clientEmailTextBox.TabIndex = 1;
            this.clientEmailTextBox.Text = "Почта";
            // 
            // clientBank
            // 
            this.clientBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientBank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientBank.Location = new System.Drawing.Point(42, 274);
            this.clientBank.Name = "clientBank";
            this.clientBank.Size = new System.Drawing.Size(168, 26);
            this.clientBank.TabIndex = 1;
            this.clientBank.Text = "Банк";
            // 
            // saveClientBtn
            // 
            this.saveClientBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveClientBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveClientBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveClientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveClientBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveClientBtn.Location = new System.Drawing.Point(76, 513);
            this.saveClientBtn.Name = "saveClientBtn";
            this.saveClientBtn.Size = new System.Drawing.Size(128, 40);
            this.saveClientBtn.TabIndex = 0;
            this.saveClientBtn.Text = "Сохранить";
            this.saveClientBtn.UseVisualStyleBackColor = false;
            // 
            // clientId
            // 
            this.clientId.HeaderText = "id";
            this.clientId.Name = "clientId";
            this.clientId.Visible = false;
            // 
            // clientName
            // 
            this.clientName.FillWeight = 50F;
            this.clientName.HeaderText = "Имя";
            this.clientName.MinimumWidth = 6;
            this.clientName.Name = "clientName";
            // 
            // clientPhone
            // 
            this.clientPhone.FillWeight = 20F;
            this.clientPhone.HeaderText = "Телефон";
            this.clientPhone.MinimumWidth = 6;
            this.clientPhone.Name = "clientPhone";
            // 
            // clientEmail
            // 
            this.clientEmail.FillWeight = 20F;
            this.clientEmail.HeaderText = "Почта";
            this.clientEmail.MinimumWidth = 6;
            this.clientEmail.Name = "clientEmail";
            // 
            // dop
            // 
            this.dop.HeaderText = "Дополнительно";
            this.dop.MinimumWidth = 6;
            this.dop.Name = "dop";
            this.dop.Visible = false;
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ClientsForm";
            this.Text = "ClientsForm";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.fizClientEditorPanel.ResumeLayout(false);
            this.fizClientEditorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userSnpLbl;
        private System.Windows.Forms.Label userModelbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView clientsTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn innKpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ogrn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rshet;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bik;
        private System.Windows.Forms.DataGridViewTextBoxColumn okved;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addClientBtn;
        private System.Windows.Forms.ToolStripButton editClientBtn;
        private System.Windows.Forms.ToolStripButton deleteClientBtn;
        private System.Windows.Forms.Button backToMenuBtn;
        private System.Windows.Forms.Panel fizClientEditorPanel;
        private System.Windows.Forms.DateTimePicker clientBirthDatePicker;
        private System.Windows.Forms.MaskedTextBox clientPhoneMTextBox;
        private System.Windows.Forms.Button hideEditorPanelBtn;
        private System.Windows.Forms.TextBox clientDepartmentCodeTextBox;
        private System.Windows.Forms.TextBox clientDepartmentTextBox;
        private System.Windows.Forms.TextBox clientPatronymicTextBox;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.TextBox clientPaspSeriesTextBox;
        private System.Windows.Forms.TextBox clientPaspNumberTextBox;
        private System.Windows.Forms.TextBox clientSurnameTextBox;
        private System.Windows.Forms.TextBox clientBankAccountTextBox;
        private System.Windows.Forms.TextBox clientPaspAddressTextBox;
        private System.Windows.Forms.TextBox clientEmailTextBox;
        private System.Windows.Forms.TextBox clientBank;
        private System.Windows.Forms.Button saveClientBtn;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayMode;
        private System.Windows.Forms.ToolStripButton fizSwitchBtn;
        private System.Windows.Forms.ToolStripButton urSwitchBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop;
    }
}