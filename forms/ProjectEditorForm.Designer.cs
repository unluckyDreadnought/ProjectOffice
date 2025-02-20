
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stagesTable = new System.Windows.Forms.DataGridView();
            this.stageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesTable = new System.Windows.Forms.DataGridView();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otvet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.targetProjectDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.projectCostTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.аlab = new System.Windows.Forms.Label();
            this.chooseEmployeesBtn = new System.Windows.Forms.Button();
            this.chooseClientBtn = new System.Windows.Forms.Button();
            this.chooseStagesBtn = new System.Windows.Forms.Button();
            this.backToProjectListBtn = new System.Windows.Forms.Button();
            this.saveProjectBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.managerLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.choosenClientLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.projectIdLbl = new System.Windows.Forms.Label();
            this.startDateLbl = new System.Windows.Forms.Label();
            this.subtaskBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stagesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // stagesTable
            // 
            this.stagesTable.AllowUserToAddRows = false;
            this.stagesTable.AllowUserToDeleteRows = false;
            this.stagesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stagesTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.stagesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stagesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.stagesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stagesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stageNumber,
            this.Stage});
            this.stagesTable.EnableHeadersVisualStyles = false;
            this.stagesTable.Location = new System.Drawing.Point(27, 326);
            this.stagesTable.Name = "stagesTable";
            this.stagesTable.ReadOnly = true;
            this.stagesTable.RowHeadersVisible = false;
            this.stagesTable.RowHeadersWidth = 51;
            this.stagesTable.RowTemplate.Height = 24;
            this.stagesTable.Size = new System.Drawing.Size(286, 188);
            this.stagesTable.TabIndex = 28;
            // 
            // stageNumber
            // 
            this.stageNumber.HeaderText = "№";
            this.stageNumber.MinimumWidth = 6;
            this.stageNumber.Name = "stageNumber";
            this.stageNumber.ReadOnly = true;
            // 
            // Stage
            // 
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
            this.employeesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.employeesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fio,
            this.otvet});
            this.employeesTable.EnableHeadersVisualStyles = false;
            this.employeesTable.Location = new System.Drawing.Point(331, 326);
            this.employeesTable.Name = "employeesTable";
            this.employeesTable.ReadOnly = true;
            this.employeesTable.RowHeadersVisible = false;
            this.employeesTable.RowHeadersWidth = 51;
            this.employeesTable.RowTemplate.Height = 24;
            this.employeesTable.Size = new System.Drawing.Size(322, 188);
            this.employeesTable.TabIndex = 27;
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.MinimumWidth = 6;
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            // 
            // otvet
            // 
            this.otvet.HeaderText = "Ответственный";
            this.otvet.MinimumWidth = 6;
            this.otvet.Name = "otvet";
            this.otvet.ReadOnly = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dateTimePicker1.Location = new System.Drawing.Point(427, 180);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 34);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectNameTextBox.Location = new System.Drawing.Point(154, 72);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(499, 34);
            this.projectNameTextBox.TabIndex = 25;
            // 
            // targetProjectDescriptionTextBox
            // 
            this.targetProjectDescriptionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.targetProjectDescriptionTextBox.Location = new System.Drawing.Point(154, 127);
            this.targetProjectDescriptionTextBox.Name = "targetProjectDescriptionTextBox";
            this.targetProjectDescriptionTextBox.Size = new System.Drawing.Size(499, 34);
            this.targetProjectDescriptionTextBox.TabIndex = 24;
            // 
            // projectCostTextBox
            // 
            this.projectCostTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectCostTextBox.Location = new System.Drawing.Point(351, 538);
            this.projectCostTextBox.Name = "projectCostTextBox";
            this.projectCostTextBox.Size = new System.Drawing.Size(302, 34);
            this.projectCostTextBox.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Цель";
            // 
            // аlab
            // 
            this.аlab.AutoSize = true;
            this.аlab.Location = new System.Drawing.Point(22, 75);
            this.аlab.Name = "аlab";
            this.аlab.Size = new System.Drawing.Size(126, 29);
            this.аlab.TabIndex = 14;
            this.аlab.Text = "Название";
            // 
            // chooseEmployeesBtn
            // 
            this.chooseEmployeesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.chooseEmployeesBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseEmployeesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseEmployeesBtn.Location = new System.Drawing.Point(331, 264);
            this.chooseEmployeesBtn.Name = "chooseEmployeesBtn";
            this.chooseEmployeesBtn.Size = new System.Drawing.Size(322, 39);
            this.chooseEmployeesBtn.TabIndex = 21;
            this.chooseEmployeesBtn.Text = "Назначение сотрудников";
            this.chooseEmployeesBtn.UseVisualStyleBackColor = false;
            this.chooseEmployeesBtn.Click += new System.EventHandler(this.chooseEmployeesBtn_Click);
            // 
            // chooseClientBtn
            // 
            this.chooseClientBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.chooseClientBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseClientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseClientBtn.Location = new System.Drawing.Point(27, 180);
            this.chooseClientBtn.Name = "chooseClientBtn";
            this.chooseClientBtn.Size = new System.Drawing.Size(205, 39);
            this.chooseClientBtn.TabIndex = 20;
            this.chooseClientBtn.Text = "Выбор клиента";
            this.chooseClientBtn.UseVisualStyleBackColor = false;
            this.chooseClientBtn.Click += new System.EventHandler(this.chooseClientBtn_Click);
            // 
            // chooseStagesBtn
            // 
            this.chooseStagesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.chooseStagesBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseStagesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseStagesBtn.Location = new System.Drawing.Point(27, 264);
            this.chooseStagesBtn.Name = "chooseStagesBtn";
            this.chooseStagesBtn.Size = new System.Drawing.Size(191, 39);
            this.chooseStagesBtn.TabIndex = 19;
            this.chooseStagesBtn.Text = "Выбор этапов";
            this.chooseStagesBtn.UseVisualStyleBackColor = false;
            this.chooseStagesBtn.Click += new System.EventHandler(this.chooseStagesBtn_Click);
            // 
            // backToProjectListBtn
            // 
            this.backToProjectListBtn.Location = new System.Drawing.Point(12, 646);
            this.backToProjectListBtn.Name = "backToProjectListBtn";
            this.backToProjectListBtn.Size = new System.Drawing.Size(241, 39);
            this.backToProjectListBtn.TabIndex = 22;
            this.backToProjectListBtn.Text = "К списку проектов";
            this.backToProjectListBtn.UseVisualStyleBackColor = true;
            this.backToProjectListBtn.Click += new System.EventHandler(this.backToProjectListBtn_Click);
            // 
            // saveProjectBtn
            // 
            this.saveProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveProjectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveProjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveProjectBtn.Location = new System.Drawing.Point(503, 646);
            this.saveProjectBtn.Name = "saveProjectBtn";
            this.saveProjectBtn.Size = new System.Drawing.Size(183, 39);
            this.saveProjectBtn.TabIndex = 18;
            this.saveProjectBtn.Text = "Сохранить";
            this.saveProjectBtn.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 538);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 29);
            this.label8.TabIndex = 16;
            this.label8.Text = "Стоимость";
            // 
            // managerLbl
            // 
            this.managerLbl.Location = new System.Drawing.Point(498, 575);
            this.managerLbl.Name = "managerLbl";
            this.managerLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.managerLbl.Size = new System.Drawing.Size(155, 29);
            this.managerLbl.TabIndex = 15;
            this.managerLbl.Text = "Иванов И.И.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(346, 575);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(132, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "Оформил:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "№ проекта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Окончание";
            // 
            // choosenClientLbl
            // 
            this.choosenClientLbl.AutoSize = true;
            this.choosenClientLbl.Location = new System.Drawing.Point(67, 222);
            this.choosenClientLbl.Name = "choosenClientLbl";
            this.choosenClientLbl.Size = new System.Drawing.Size(100, 29);
            this.choosenClientLbl.TabIndex = 9;
            this.choosenClientLbl.Text = "Клиент";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Начало";
            // 
            // projectIdLbl
            // 
            this.projectIdLbl.Location = new System.Drawing.Point(164, 18);
            this.projectIdLbl.Name = "projectIdLbl";
            this.projectIdLbl.Size = new System.Drawing.Size(149, 34);
            this.projectIdLbl.TabIndex = 17;
            this.projectIdLbl.Text = "Проект #";
            // 
            // startDateLbl
            // 
            this.startDateLbl.Location = new System.Drawing.Point(504, 18);
            this.startDateLbl.Name = "startDateLbl";
            this.startDateLbl.Size = new System.Drawing.Size(149, 34);
            this.startDateLbl.TabIndex = 7;
            this.startDateLbl.Text = "label1";
            // 
            // subtaskBtn
            // 
            this.subtaskBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.subtaskBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.subtaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subtaskBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.subtaskBtn.Location = new System.Drawing.Point(12, 592);
            this.subtaskBtn.Name = "subtaskBtn";
            this.subtaskBtn.Size = new System.Drawing.Size(253, 38);
            this.subtaskBtn.TabIndex = 29;
            this.subtaskBtn.Text = "Этапы и подзадачи";
            this.subtaskBtn.UseVisualStyleBackColor = false;
            this.subtaskBtn.Click += new System.EventHandler(this.subtaskBtn_Click);
            // 
            // ProjectEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(698, 702);
            this.Controls.Add(this.subtaskBtn);
            this.Controls.Add(this.stagesTable);
            this.Controls.Add(this.employeesTable);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.targetProjectDescriptionTextBox);
            this.Controls.Add(this.projectCostTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.аlab);
            this.Controls.Add(this.chooseEmployeesBtn);
            this.Controls.Add(this.chooseClientBtn);
            this.Controls.Add(this.chooseStagesBtn);
            this.Controls.Add(this.backToProjectListBtn);
            this.Controls.Add(this.saveProjectBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.managerLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.choosenClientLbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.projectIdLbl);
            this.Controls.Add(this.startDateLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProjectEditorForm";
            this.Text = "ProjectEditorForm";
            this.Load += new System.EventHandler(this.ProjectEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stagesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stagesTable;
        private System.Windows.Forms.DataGridView employeesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn otvet;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.TextBox targetProjectDescriptionTextBox;
        private System.Windows.Forms.TextBox projectCostTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label аlab;
        private System.Windows.Forms.Button chooseEmployeesBtn;
        private System.Windows.Forms.Button chooseClientBtn;
        private System.Windows.Forms.Button chooseStagesBtn;
        private System.Windows.Forms.Button backToProjectListBtn;
        private System.Windows.Forms.Button saveProjectBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label managerLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label choosenClientLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label projectIdLbl;
        private System.Windows.Forms.Label startDateLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stage;
        private System.Windows.Forms.Button subtaskBtn;
    }
}