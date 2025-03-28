
namespace ProjectOffice.forms
{
    partial class ProjectEditorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stagesTable = new System.Windows.Forms.DataGridView();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesTable = new System.Windows.Forms.DataGridView();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otvet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.endPlanDate = new System.Windows.Forms.DateTimePicker();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.projectCostTextBox = new System.Windows.Forms.TextBox();
            this.аlab = new System.Windows.Forms.Label();
            this.chooseClientBtn = new System.Windows.Forms.Button();
            this.backToProjectListBtn = new System.Windows.Forms.Button();
            this.saveProjectBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.managerLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.choosenClientLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.projectIdLbl = new System.Windows.Forms.Label();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.subtaskBtn = new System.Windows.Forms.Button();
            this.projCostLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.factEndDateLbl = new System.Windows.Forms.Label();
            this.planDateEditLbl = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subtaskPanel = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chooseClientPanel = new System.Windows.Forms.Panel();
            this.chooseEmployeePanel = new System.Windows.Forms.Panel();
            this.chooseEmployeesBtn = new System.Windows.Forms.Button();
            this.chooseStagePanel = new System.Windows.Forms.Panel();
            this.chooseStagesBtn = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.endProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stagesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.subtaskPanel.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.chooseClientPanel.SuspendLayout();
            this.chooseEmployeePanel.SuspendLayout();
            this.chooseStagePanel.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // stagesTable
            // 
            this.stagesTable.AllowUserToAddRows = false;
            this.stagesTable.AllowUserToDeleteRows = false;
            this.stagesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stagesTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.stagesTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.stagesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stagesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.stagesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stagesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stage});
            this.stagesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stagesTable.EnableHeadersVisualStyles = false;
            this.stagesTable.Location = new System.Drawing.Point(3, 305);
            this.stagesTable.Name = "stagesTable";
            this.stagesTable.ReadOnly = true;
            this.stagesTable.RowHeadersVisible = false;
            this.stagesTable.RowHeadersWidth = 51;
            this.stagesTable.RowTemplate.Height = 24;
            this.stagesTable.Size = new System.Drawing.Size(363, 229);
            this.stagesTable.TabIndex = 28;
            // 
            // Stage
            // 
            this.Stage.FillWeight = 7F;
            this.Stage.HeaderText = "Этап";
            this.Stage.MinimumWidth = 6;
            this.Stage.Name = "Stage";
            this.Stage.ReadOnly = true;
            // 
            // employeesTable
            // 
            this.employeesTable.AllowUserToAddRows = false;
            this.employeesTable.AllowUserToDeleteRows = false;
            this.employeesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeesTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.employeesTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.employeesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.employeesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fio,
            this.otvet});
            this.employeesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesTable.EnableHeadersVisualStyles = false;
            this.employeesTable.Location = new System.Drawing.Point(372, 305);
            this.employeesTable.Name = "employeesTable";
            this.employeesTable.ReadOnly = true;
            this.employeesTable.RowHeadersVisible = false;
            this.employeesTable.RowHeadersWidth = 51;
            this.employeesTable.RowTemplate.Height = 24;
            this.employeesTable.Size = new System.Drawing.Size(364, 229);
            this.employeesTable.TabIndex = 27;
            this.employeesTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeesTable_CellClick);
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.MinimumWidth = 6;
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            this.fio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // otvet
            // 
            this.otvet.HeaderText = "Ответственный";
            this.otvet.MinimumWidth = 6;
            this.otvet.Name = "otvet";
            this.otvet.ReadOnly = true;
            this.otvet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // endPlanDate
            // 
            this.endPlanDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endPlanDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.endPlanDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.endPlanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endPlanDate.Location = new System.Drawing.Point(0, 0);
            this.endPlanDate.Name = "endPlanDate";
            this.endPlanDate.Size = new System.Drawing.Size(235, 26);
            this.endPlanDate.TabIndex = 26;
            this.endPlanDate.ValueChanged += new System.EventHandler(this.endPlanDate_ValueChanged);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectNameTextBox.Location = new System.Drawing.Point(170, 7);
            this.projectNameTextBox.MaxLength = 256;
            this.projectNameTextBox.Multiline = true;
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(555, 69);
            this.projectNameTextBox.TabIndex = 25;
            this.projectNameTextBox.Click += new System.EventHandler(this.projectNameTextBox_Click);
            this.projectNameTextBox.TextChanged += new System.EventHandler(this.projectNameTextBox_TextChanged);
            this.projectNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.projectNameTextBox_KeyPress);
            this.projectNameTextBox.Leave += new System.EventHandler(this.projectNameTextBox_Leave);
            // 
            // projectCostTextBox
            // 
            this.projectCostTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectCostTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.projectCostTextBox.Location = new System.Drawing.Point(0, 0);
            this.projectCostTextBox.Name = "projectCostTextBox";
            this.projectCostTextBox.Size = new System.Drawing.Size(364, 28);
            this.projectCostTextBox.TabIndex = 23;
            this.projectCostTextBox.TextChanged += new System.EventHandler(this.projectCostTextBox_TextChanged);
            this.projectCostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.projectCostTextBox_KeyPress);
            // 
            // аlab
            // 
            this.аlab.Location = new System.Drawing.Point(38, 10);
            this.аlab.Name = "аlab";
            this.аlab.Size = new System.Drawing.Size(126, 77);
            this.аlab.TabIndex = 14;
            this.аlab.Text = "Название";
            // 
            // chooseClientBtn
            // 
            this.chooseClientBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseClientBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.chooseClientBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseClientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseClientBtn.Location = new System.Drawing.Point(63, 3);
            this.chooseClientBtn.Name = "chooseClientBtn";
            this.chooseClientBtn.Size = new System.Drawing.Size(237, 39);
            this.chooseClientBtn.TabIndex = 20;
            this.chooseClientBtn.Text = "Выбор клиента";
            this.chooseClientBtn.UseVisualStyleBackColor = false;
            this.chooseClientBtn.Click += new System.EventHandler(this.chooseClientBtn_Click);
            // 
            // backToProjectListBtn
            // 
            this.backToProjectListBtn.Location = new System.Drawing.Point(0, 5);
            this.backToProjectListBtn.Name = "backToProjectListBtn";
            this.backToProjectListBtn.Size = new System.Drawing.Size(209, 39);
            this.backToProjectListBtn.TabIndex = 22;
            this.backToProjectListBtn.Text = "К списку проектов";
            this.backToProjectListBtn.UseVisualStyleBackColor = true;
            this.backToProjectListBtn.Click += new System.EventHandler(this.backToProjectListBtn_Click);
            // 
            // saveProjectBtn
            // 
            this.saveProjectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveProjectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveProjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveProjectBtn.Location = new System.Drawing.Point(208, 5);
            this.saveProjectBtn.Name = "saveProjectBtn";
            this.saveProjectBtn.Size = new System.Drawing.Size(153, 38);
            this.saveProjectBtn.TabIndex = 18;
            this.saveProjectBtn.Text = "Сохранить";
            this.saveProjectBtn.UseVisualStyleBackColor = false;
            this.saveProjectBtn.Click += new System.EventHandler(this.saveProjectBtn_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "Стоимость";
            // 
            // managerLbl
            // 
            this.managerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.managerLbl.Location = new System.Drawing.Point(149, 3);
            this.managerLbl.Name = "managerLbl";
            this.managerLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.managerLbl.Size = new System.Drawing.Size(208, 29);
            this.managerLbl.TabIndex = 15;
            this.managerLbl.Text = "Иванов И.И.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(14, 3);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(132, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "Оформил:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "№ проекта";
            // 
            // choosenClientLbl
            // 
            this.choosenClientLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.choosenClientLbl.Location = new System.Drawing.Point(0, 0);
            this.choosenClientLbl.Name = "choosenClientLbl";
            this.choosenClientLbl.Size = new System.Drawing.Size(357, 29);
            this.choosenClientLbl.TabIndex = 9;
            this.choosenClientLbl.Text = "Клиент";
            this.choosenClientLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Начало";
            // 
            // projectIdLbl
            // 
            this.projectIdLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectIdLbl.AutoSize = true;
            this.projectIdLbl.Location = new System.Drawing.Point(146, 6);
            this.projectIdLbl.Name = "projectIdLbl";
            this.projectIdLbl.Size = new System.Drawing.Size(90, 24);
            this.projectIdLbl.TabIndex = 17;
            this.projectIdLbl.Text = "Проект #";
            // 
            // startDateLbl
            // 
            this.startDateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startDateLbl.AutoSize = true;
            this.startDateLbl.Location = new System.Drawing.Point(127, 6);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(60, 24);
            this.startDateLbl.TabIndex = 7;
            this.startDateLbl.Text = "label1";
            // 
            // subtaskBtn
            // 
            this.subtaskBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.subtaskBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.subtaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subtaskBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.subtaskBtn.Location = new System.Drawing.Point(30, 3);
            this.subtaskBtn.Name = "subtaskBtn";
            this.subtaskBtn.Size = new System.Drawing.Size(251, 38);
            this.subtaskBtn.TabIndex = 29;
            this.subtaskBtn.Text = "Этапы и подзадачи";
            this.subtaskBtn.UseVisualStyleBackColor = false;
            this.subtaskBtn.Click += new System.EventHandler(this.subtaskBtn_Click);
            // 
            // projCostLbl
            // 
            this.projCostLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projCostLbl.Location = new System.Drawing.Point(3, 3);
            this.projCostLbl.Name = "projCostLbl";
            this.projCostLbl.Size = new System.Drawing.Size(358, 35);
            this.projCostLbl.TabIndex = 30;
            this.projCostLbl.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.projectIdLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(343, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 45);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.startDateLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(372, 3);
            this.panel2.MinimumSize = new System.Drawing.Size(343, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 45);
            this.panel2.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.аlab);
            this.panel3.Controls.Add(this.projectNameTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(733, 87);
            this.panel3.TabIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel13, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.subtaskPanel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.stagesTable, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.employeesTable, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chooseEmployeePanel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chooseStagePanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 717);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.endProject);
            this.panel13.Controls.Add(this.saveProjectBtn);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(372, 665);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(364, 49);
            this.panel13.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(372, 147);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(364, 100);
            this.panel4.TabIndex = 27;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.79121F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.20879F));
            this.tableLayoutPanel3.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(364, 100);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.factEndDateLbl);
            this.panel5.Controls.Add(this.planDateEditLbl);
            this.panel5.Controls.Add(this.endPlanDate);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(126, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 94);
            this.panel5.TabIndex = 11;
            // 
            // factEndDateLbl
            // 
            this.factEndDateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.factEndDateLbl.Location = new System.Drawing.Point(4, 51);
            this.factEndDateLbl.Name = "factEndDateLbl";
            this.factEndDateLbl.Size = new System.Drawing.Size(229, 42);
            this.factEndDateLbl.TabIndex = 28;
            this.factEndDateLbl.Text = "label4";
            this.factEndDateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // planDateEditLbl
            // 
            this.planDateEditLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planDateEditLbl.Location = new System.Drawing.Point(1, 0);
            this.planDateEditLbl.Name = "planDateEditLbl";
            this.planDateEditLbl.Size = new System.Drawing.Size(232, 42);
            this.planDateEditLbl.TabIndex = 27;
            this.planDateEditLbl.Text = "label1";
            this.planDateEditLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(117, 94);
            this.panel6.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Завершено";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 50);
            this.label3.TabIndex = 11;
            this.label3.Text = "Окончание (план)";
            // 
            // subtaskPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.subtaskPanel, 2);
            this.subtaskPanel.Controls.Add(this.subtaskBtn);
            this.subtaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtaskPanel.Location = new System.Drawing.Point(3, 615);
            this.subtaskPanel.Name = "subtaskPanel";
            this.subtaskPanel.Size = new System.Drawing.Size(733, 44);
            this.subtaskPanel.TabIndex = 34;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.label8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 540);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(363, 69);
            this.panel9.TabIndex = 34;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chooseClientPanel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 147);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 100);
            this.tableLayoutPanel2.TabIndex = 33;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.choosenClientLbl);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 54);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(357, 44);
            this.panel7.TabIndex = 34;
            // 
            // chooseClientPanel
            // 
            this.chooseClientPanel.AutoSize = true;
            this.chooseClientPanel.Controls.Add(this.chooseClientBtn);
            this.chooseClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseClientPanel.Location = new System.Drawing.Point(3, 3);
            this.chooseClientPanel.Name = "chooseClientPanel";
            this.chooseClientPanel.Size = new System.Drawing.Size(357, 45);
            this.chooseClientPanel.TabIndex = 34;
            // 
            // chooseEmployeePanel
            // 
            this.chooseEmployeePanel.Controls.Add(this.chooseEmployeesBtn);
            this.chooseEmployeePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseEmployeePanel.Location = new System.Drawing.Point(372, 253);
            this.chooseEmployeePanel.Name = "chooseEmployeePanel";
            this.chooseEmployeePanel.Size = new System.Drawing.Size(364, 46);
            this.chooseEmployeePanel.TabIndex = 34;
            // 
            // chooseEmployeesBtn
            // 
            this.chooseEmployeesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseEmployeesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.chooseEmployeesBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseEmployeesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseEmployeesBtn.Location = new System.Drawing.Point(9, 4);
            this.chooseEmployeesBtn.Name = "chooseEmployeesBtn";
            this.chooseEmployeesBtn.Size = new System.Drawing.Size(346, 39);
            this.chooseEmployeesBtn.TabIndex = 21;
            this.chooseEmployeesBtn.Text = "Назначение сотрудников";
            this.chooseEmployeesBtn.UseVisualStyleBackColor = false;
            this.chooseEmployeesBtn.Click += new System.EventHandler(this.chooseEmployeesBtn_Click);
            // 
            // chooseStagePanel
            // 
            this.chooseStagePanel.Controls.Add(this.chooseStagesBtn);
            this.chooseStagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseStagePanel.Location = new System.Drawing.Point(3, 253);
            this.chooseStagePanel.Name = "chooseStagePanel";
            this.chooseStagePanel.Size = new System.Drawing.Size(363, 46);
            this.chooseStagePanel.TabIndex = 34;
            // 
            // chooseStagesBtn
            // 
            this.chooseStagesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseStagesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.chooseStagesBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseStagesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseStagesBtn.Location = new System.Drawing.Point(66, 4);
            this.chooseStagesBtn.Name = "chooseStagesBtn";
            this.chooseStagesBtn.Size = new System.Drawing.Size(226, 39);
            this.chooseStagesBtn.TabIndex = 19;
            this.chooseStagesBtn.Text = "Выбор этапов";
            this.chooseStagesBtn.UseVisualStyleBackColor = false;
            this.chooseStagesBtn.Click += new System.EventHandler(this.chooseStagesBtn_Click);
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.projCostLbl);
            this.panel10.Controls.Add(this.projectCostTextBox);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(372, 540);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(364, 69);
            this.panel10.TabIndex = 34;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label7);
            this.panel11.Controls.Add(this.managerLbl);
            this.panel11.Location = new System.Drawing.Point(0, 34);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(364, 32);
            this.panel11.TabIndex = 34;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.backToProjectListBtn);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(3, 665);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(363, 49);
            this.panel14.TabIndex = 34;
            // 
            // endProject
            // 
            this.endProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.endProject.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.endProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.endProject.Location = new System.Drawing.Point(49, 5);
            this.endProject.Name = "endProject";
            this.endProject.Size = new System.Drawing.Size(153, 38);
            this.endProject.TabIndex = 18;
            this.endProject.Text = "Завершить";
            this.endProject.UseVisualStyleBackColor = false;
            this.endProject.Click += new System.EventHandler(this.endProject_Click);
            // 
            // ProjectEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(739, 717);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(716, 756);
            this.Name = "ProjectEditorForm";
            this.Text = "ProjectEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.ProjectEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stagesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.subtaskPanel.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.chooseClientPanel.ResumeLayout(false);
            this.chooseEmployeePanel.ResumeLayout(false);
            this.chooseStagePanel.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stagesTable;
        private System.Windows.Forms.DataGridView employeesTable;
        private System.Windows.Forms.DateTimePicker endPlanDate;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.TextBox projectCostTextBox;
        private System.Windows.Forms.Label аlab;
        private System.Windows.Forms.Button chooseClientBtn;
        private System.Windows.Forms.Button backToProjectListBtn;
        private System.Windows.Forms.Button saveProjectBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label managerLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label choosenClientLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label projectIdLbl;
        private System.Windows.Forms.Label startDateLbl;
        private System.Windows.Forms.Button subtaskBtn;
        private System.Windows.Forms.Label projCostLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel subtaskPanel;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel chooseClientPanel;
        private System.Windows.Forms.Panel chooseEmployeePanel;
        private System.Windows.Forms.Button chooseEmployeesBtn;
        private System.Windows.Forms.Panel chooseStagePanel;
        private System.Windows.Forms.Button chooseStagesBtn;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn otvet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label planDateEditLbl;
        private System.Windows.Forms.Label factEndDateLbl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button endProject;
    }
}