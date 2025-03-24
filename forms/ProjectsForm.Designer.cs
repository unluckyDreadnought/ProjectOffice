
namespace ProjectOffice.forms
{
    partial class ProjectsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchLayout = new System.Windows.Forms.TableLayoutPanel();
            this.datesPanelFilter = new System.Windows.Forms.Panel();
            this.projectStartRangeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.projectEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.projectSearchLineTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.projectSortCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.projectFilterOnCombo = new System.Windows.Forms.ComboBox();
            this.projectFilterCombo = new System.Windows.Forms.ComboBox();
            this.projectResetFilterBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.editProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.backToMenu = new System.Windows.Forms.Button();
            this.projectReportBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.projectTablesLayout = new System.Windows.Forms.TableLayoutPanel();
            this.projectsTable = new System.Windows.Forms.DataGridView();
            this.projId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projResp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeProjectTable = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.searchLayout.SuspendLayout();
            this.datesPanelFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.projectTablesLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProjectTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.63555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.63555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.63555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.09335F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1018, 568);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.searchLayout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.projectSortCombo);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.projectResetFilterBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 127);
            this.panel1.TabIndex = 0;
            // 
            // searchLayout
            // 
            this.searchLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLayout.ColumnCount = 1;
            this.searchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchLayout.Controls.Add(this.datesPanelFilter, 0, 0);
            this.searchLayout.Controls.Add(this.projectSearchLineTextBox, 0, 1);
            this.searchLayout.Location = new System.Drawing.Point(3, 3);
            this.searchLayout.Name = "searchLayout";
            this.searchLayout.RowCount = 2;
            this.searchLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.searchLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.searchLayout.Size = new System.Drawing.Size(580, 118);
            this.searchLayout.TabIndex = 7;
            // 
            // datesPanelFilter
            // 
            this.datesPanelFilter.AutoSize = true;
            this.datesPanelFilter.Controls.Add(this.projectStartRangeDatePicker);
            this.datesPanelFilter.Controls.Add(this.label4);
            this.datesPanelFilter.Controls.Add(this.projectEndDatePicker);
            this.datesPanelFilter.Controls.Add(this.label3);
            this.datesPanelFilter.Controls.Add(this.label2);
            this.datesPanelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datesPanelFilter.Location = new System.Drawing.Point(3, 3);
            this.datesPanelFilter.Name = "datesPanelFilter";
            this.datesPanelFilter.Size = new System.Drawing.Size(574, 59);
            this.datesPanelFilter.TabIndex = 6;
            // 
            // projectStartRangeDatePicker
            // 
            this.projectStartRangeDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.projectStartRangeDatePicker.Location = new System.Drawing.Point(2, 27);
            this.projectStartRangeDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.projectStartRangeDatePicker.Name = "projectStartRangeDatePicker";
            this.projectStartRangeDatePicker.Size = new System.Drawing.Size(209, 30);
            this.projectStartRangeDatePicker.TabIndex = 3;
            this.projectStartRangeDatePicker.ValueChanged += new System.EventHandler(this.projectStartRangeDatePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 5;
            // 
            // projectEndDatePicker
            // 
            this.projectEndDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.projectEndDatePicker.Location = new System.Drawing.Point(331, 27);
            this.projectEndDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.projectEndDatePicker.Name = "projectEndDatePicker";
            this.projectEndDatePicker.Size = new System.Drawing.Size(214, 30);
            this.projectEndDatePicker.TabIndex = 3;
            this.projectEndDatePicker.ValueChanged += new System.EventHandler(this.projectEndDatePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата окончания";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата начала";
            // 
            // projectSearchLineTextBox
            // 
            this.projectSearchLineTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectSearchLineTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.projectSearchLineTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectSearchLineTextBox.Location = new System.Drawing.Point(2, 78);
            this.projectSearchLineTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.projectSearchLineTextBox.Name = "projectSearchLineTextBox";
            this.projectSearchLineTextBox.Size = new System.Drawing.Size(576, 38);
            this.projectSearchLineTextBox.TabIndex = 1;
            this.projectSearchLineTextBox.Click += new System.EventHandler(this.projectSearchLineTextBox_Click);
            this.projectSearchLineTextBox.TextChanged += new System.EventHandler(this.projectSearchLineTextBox_TextChanged);
            this.projectSearchLineTextBox.Leave += new System.EventHandler(this.projectSearchLineTextBox_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сортировка";
            // 
            // projectSortCombo
            // 
            this.projectSortCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectSortCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectSortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectSortCombo.FormattingEnabled = true;
            this.projectSortCombo.Items.AddRange(new object[] {
            "не применяется",
            "стоимость по возрастанию",
            "стоимость по убыванию",
            "имя по возрастанию",
            "имя по убыванию"});
            this.projectSortCombo.Location = new System.Drawing.Point(817, 38);
            this.projectSortCombo.Margin = new System.Windows.Forms.Padding(2);
            this.projectSortCombo.Name = "projectSortCombo";
            this.projectSortCombo.Size = new System.Drawing.Size(188, 33);
            this.projectSortCombo.TabIndex = 0;
            this.projectSortCombo.SelectedIndexChanged += new System.EventHandler(this.projectSortCombo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.projectFilterOnCombo);
            this.groupBox1.Controls.Add(this.projectFilterCombo);
            this.groupBox1.Location = new System.Drawing.Point(601, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(200, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтрация";
            // 
            // projectFilterOnCombo
            // 
            this.projectFilterOnCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectFilterOnCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectFilterOnCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectFilterOnCombo.FormattingEnabled = true;
            this.projectFilterOnCombo.Items.AddRange(new object[] {
            "Фильтр по ...",
            "Ответственные",
            "Этапы",
            "Статус"});
            this.projectFilterOnCombo.Location = new System.Drawing.Point(6, 29);
            this.projectFilterOnCombo.Margin = new System.Windows.Forms.Padding(2);
            this.projectFilterOnCombo.Name = "projectFilterOnCombo";
            this.projectFilterOnCombo.Size = new System.Drawing.Size(188, 33);
            this.projectFilterOnCombo.TabIndex = 0;
            this.projectFilterOnCombo.SelectedIndexChanged += new System.EventHandler(this.projectFilterOnCombo_SelectedIndexChanged);
            // 
            // projectFilterCombo
            // 
            this.projectFilterCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectFilterCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectFilterCombo.FormattingEnabled = true;
            this.projectFilterCombo.Location = new System.Drawing.Point(6, 78);
            this.projectFilterCombo.Margin = new System.Windows.Forms.Padding(2);
            this.projectFilterCombo.Name = "projectFilterCombo";
            this.projectFilterCombo.Size = new System.Drawing.Size(188, 33);
            this.projectFilterCombo.TabIndex = 0;
            this.projectFilterCombo.SelectedIndexChanged += new System.EventHandler(this.projectFilterCombo_SelectedIndexChanged);
            // 
            // projectResetFilterBtn
            // 
            this.projectResetFilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectResetFilterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.projectResetFilterBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.projectResetFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectResetFilterBtn.Location = new System.Drawing.Point(817, 82);
            this.projectResetFilterBtn.Margin = new System.Windows.Forms.Padding(2);
            this.projectResetFilterBtn.Name = "projectResetFilterBtn";
            this.projectResetFilterBtn.Size = new System.Drawing.Size(188, 39);
            this.projectResetFilterBtn.TabIndex = 2;
            this.projectResetFilterBtn.Text = "Сбросить всё";
            this.projectResetFilterBtn.UseVisualStyleBackColor = false;
            this.projectResetFilterBtn.Click += new System.EventHandler(this.projectResetFilterBtn_Click);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.backToMenu);
            this.panel2.Controls.Add(this.projectReportBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 520);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 46);
            this.panel2.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectBtn,
            this.editProjectBtn,
            this.deleteProjectBtn,
            this.toolsDisplayModeCombo});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(349, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(341, 31);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addProjectBtn
            // 
            this.addProjectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addProjectBtn.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addProjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addProjectBtn.Name = "addProjectBtn";
            this.addProjectBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.addProjectBtn.Size = new System.Drawing.Size(29, 28);
            this.addProjectBtn.Text = "Добавить";
            this.addProjectBtn.Click += new System.EventHandler(this.addProjectBtn_Click);
            // 
            // editProjectBtn
            // 
            this.editProjectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editProjectBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editProjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editProjectBtn.Name = "editProjectBtn";
            this.editProjectBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.editProjectBtn.Size = new System.Drawing.Size(29, 28);
            this.editProjectBtn.Text = "Редактировать";
            this.editProjectBtn.Click += new System.EventHandler(this.editProjectBtn_Click);
            // 
            // deleteProjectBtn
            // 
            this.deleteProjectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteProjectBtn.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteProjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteProjectBtn.Name = "deleteProjectBtn";
            this.deleteProjectBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.deleteProjectBtn.Size = new System.Drawing.Size(29, 28);
            this.deleteProjectBtn.Text = "Удалить";
            this.deleteProjectBtn.Click += new System.EventHandler(this.deleteProjectBtn_Click);
            // 
            // toolsDisplayModeCombo
            // 
            this.toolsDisplayModeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolsDisplayModeCombo.Items.AddRange(new object[] {
            "Иконка",
            "Текст",
            "Совместный"});
            this.toolsDisplayModeCombo.Name = "toolsDisplayModeCombo";
            this.toolsDisplayModeCombo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolsDisplayModeCombo.Size = new System.Drawing.Size(122, 31);
            this.toolsDisplayModeCombo.ToolTipText = "Режим отображения";
            // 
            // backToMenu
            // 
            this.backToMenu.Location = new System.Drawing.Point(10, 2);
            this.backToMenu.Margin = new System.Windows.Forms.Padding(2);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(102, 38);
            this.backToMenu.TabIndex = 1;
            this.backToMenu.Text = "В меню";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // projectReportBtn
            // 
            this.projectReportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectReportBtn.Location = new System.Drawing.Point(914, 2);
            this.projectReportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.projectReportBtn.Name = "projectReportBtn";
            this.projectReportBtn.Size = new System.Drawing.Size(91, 38);
            this.projectReportBtn.TabIndex = 0;
            this.projectReportBtn.Text = "Отчёт";
            this.projectReportBtn.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.projectTablesLayout);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 134);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 3);
            this.panel3.Size = new System.Drawing.Size(1012, 381);
            this.panel3.TabIndex = 3;
            // 
            // projectTablesLayout
            // 
            this.projectTablesLayout.ColumnCount = 1;
            this.projectTablesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.projectTablesLayout.Controls.Add(this.projectsTable, 0, 0);
            this.projectTablesLayout.Controls.Add(this.employeeProjectTable, 0, 1);
            this.projectTablesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTablesLayout.Location = new System.Drawing.Point(0, 0);
            this.projectTablesLayout.Name = "projectTablesLayout";
            this.projectTablesLayout.RowCount = 2;
            this.projectTablesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.projectTablesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.projectTablesLayout.Size = new System.Drawing.Size(1012, 381);
            this.projectTablesLayout.TabIndex = 3;
            // 
            // projectsTable
            // 
            this.projectsTable.AllowUserToAddRows = false;
            this.projectsTable.AllowUserToDeleteRows = false;
            this.projectsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projectsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.projectsTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.projectsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.projectsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.projectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projId,
            this.projName,
            this.projResp,
            this.projEndDate,
            this.projCost,
            this.projStatus});
            this.projectsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.projectsTable.EnableHeadersVisualStyles = false;
            this.projectsTable.Location = new System.Drawing.Point(2, 2);
            this.projectsTable.Margin = new System.Windows.Forms.Padding(2);
            this.projectsTable.Name = "projectsTable";
            this.projectsTable.ReadOnly = true;
            this.projectsTable.RowHeadersVisible = false;
            this.projectsTable.RowHeadersWidth = 51;
            this.projectsTable.RowTemplate.Height = 24;
            this.projectsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.projectsTable.Size = new System.Drawing.Size(1008, 186);
            this.projectsTable.TabIndex = 2;
            // 
            // projId
            // 
            this.projId.FillWeight = 6.251337F;
            this.projId.HeaderText = "№";
            this.projId.MinimumWidth = 6;
            this.projId.Name = "projId";
            this.projId.ReadOnly = true;
            this.projId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // projName
            // 
            this.projName.FillWeight = 50.74332F;
            this.projName.HeaderText = "Название проекта";
            this.projName.MinimumWidth = 10;
            this.projName.Name = "projName";
            this.projName.ReadOnly = true;
            this.projName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // projResp
            // 
            this.projResp.FillWeight = 25.25134F;
            this.projResp.HeaderText = "Ответственный";
            this.projResp.MinimumWidth = 6;
            this.projResp.Name = "projResp";
            this.projResp.ReadOnly = true;
            this.projResp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // projEndDate
            // 
            this.projEndDate.FillWeight = 19.25134F;
            this.projEndDate.HeaderText = "Дата окончания";
            this.projEndDate.MinimumWidth = 6;
            this.projEndDate.Name = "projEndDate";
            this.projEndDate.ReadOnly = true;
            this.projEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // projCost
            // 
            this.projCost.FillWeight = 23.25134F;
            this.projCost.HeaderText = "Итоговая стоимость  | Возвращено";
            this.projCost.MinimumWidth = 6;
            this.projCost.Name = "projCost";
            this.projCost.ReadOnly = true;
            this.projCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // projStatus
            // 
            this.projStatus.FillWeight = 19.25134F;
            this.projStatus.HeaderText = "Статус";
            this.projStatus.MinimumWidth = 6;
            this.projStatus.Name = "projStatus";
            this.projStatus.ReadOnly = true;
            this.projStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // employeeProjectTable
            // 
            this.employeeProjectTable.AllowUserToAddRows = false;
            this.employeeProjectTable.AllowUserToDeleteRows = false;
            this.employeeProjectTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeeProjectTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.employeeProjectTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.employeeProjectTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeProjectTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.employeeProjectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeProjectTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.employeeProjectTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeProjectTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.employeeProjectTable.EnableHeadersVisualStyles = false;
            this.employeeProjectTable.Location = new System.Drawing.Point(3, 193);
            this.employeeProjectTable.MultiSelect = false;
            this.employeeProjectTable.Name = "employeeProjectTable";
            this.employeeProjectTable.ReadOnly = true;
            this.employeeProjectTable.RowHeadersVisible = false;
            this.employeeProjectTable.RowHeadersWidth = 51;
            this.employeeProjectTable.RowTemplate.Height = 24;
            this.employeeProjectTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeProjectTable.Size = new System.Drawing.Size(1006, 185);
            this.employeeProjectTable.TabIndex = 3;
            this.employeeProjectTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.employeeProjectTable_CellMouseDoubleClick);
            // 
            // ProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 568);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectsForm";
            this.Load += new System.EventHandler(this.ProjectsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.searchLayout.ResumeLayout(false);
            this.searchLayout.PerformLayout();
            this.datesPanelFilter.ResumeLayout(false);
            this.datesPanelFilter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.projectTablesLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProjectTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker projectEndDatePicker;
        private System.Windows.Forms.DateTimePicker projectStartRangeDatePicker;
        private System.Windows.Forms.Button projectResetFilterBtn;
        private System.Windows.Forms.TextBox projectSearchLineTextBox;
        private System.Windows.Forms.ComboBox projectSortCombo;
        private System.Windows.Forms.ComboBox projectFilterCombo;
        private System.Windows.Forms.ComboBox projectFilterOnCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addProjectBtn;
        private System.Windows.Forms.ToolStripButton editProjectBtn;
        private System.Windows.Forms.ToolStripButton deleteProjectBtn;
        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.Button projectReportBtn;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayModeCombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel projectTablesLayout;
        private System.Windows.Forms.DataGridView projectsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn projId;
        private System.Windows.Forms.DataGridViewTextBoxColumn projName;
        private System.Windows.Forms.DataGridViewTextBoxColumn projResp;
        private System.Windows.Forms.DataGridViewTextBoxColumn projEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn projCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn projStatus;
        private System.Windows.Forms.DataGridView employeeProjectTable;
        private System.Windows.Forms.TableLayoutPanel searchLayout;
        private System.Windows.Forms.Panel datesPanelFilter;
    }
}