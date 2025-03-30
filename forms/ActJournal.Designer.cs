
namespace ProjectOffice.forms
{
    partial class ActJournal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterEventTypeCombo = new System.Windows.Forms.ComboBox();
            this.filterUserRoleCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.endRangeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startRangeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.exportBtn = new System.Windows.Forms.Button();
            this.eventsTable = new System.Windows.Forms.DataGridView();
            this.dateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initiator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backToMenuBtn = new System.Windows.Forms.Button();
            this.reloadDataTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.exportBtn, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.eventsTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.backToMenuBtn, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.filterEventTypeCombo);
            this.panel1.Controls.Add(this.filterUserRoleCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.endRangeDatePicker);
            this.panel1.Controls.Add(this.startRangeDatePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 42);
            this.panel1.TabIndex = 0;
            // 
            // filterEventTypeCombo
            // 
            this.filterEventTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterEventTypeCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.filterEventTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterEventTypeCombo.FormattingEnabled = true;
            this.filterEventTypeCombo.Items.AddRange(new object[] {
            "Событие",
            "Создание объекта",
            "Изменение объекта",
            "Удаление объекта",
            "Создание отчёта",
            ""});
            this.filterEventTypeCombo.Location = new System.Drawing.Point(579, 2);
            this.filterEventTypeCombo.Name = "filterEventTypeCombo";
            this.filterEventTypeCombo.Size = new System.Drawing.Size(214, 37);
            this.filterEventTypeCombo.TabIndex = 2;
            this.filterEventTypeCombo.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
            // 
            // filterUserRoleCombo
            // 
            this.filterUserRoleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterUserRoleCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.filterUserRoleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterUserRoleCombo.FormattingEnabled = true;
            this.filterUserRoleCombo.Items.AddRange(new object[] {
            "Роль пользователя",
            "Администратор",
            "Менеджер",
            "Сотрудник"});
            this.filterUserRoleCombo.Location = new System.Drawing.Point(347, 2);
            this.filterUserRoleCombo.Name = "filterUserRoleCombo";
            this.filterUserRoleCombo.Size = new System.Drawing.Size(227, 37);
            this.filterUserRoleCombo.TabIndex = 2;
            this.filterUserRoleCombo.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // endRangeDatePicker
            // 
            this.endRangeDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.endRangeDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endRangeDatePicker.Location = new System.Drawing.Point(188, 4);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.Size = new System.Drawing.Size(146, 34);
            this.endRangeDatePicker.TabIndex = 0;
            this.endRangeDatePicker.ValueChanged += new System.EventHandler(this.control_Changed);
            // 
            // startRangeDatePicker
            // 
            this.startRangeDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.startRangeDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startRangeDatePicker.Location = new System.Drawing.Point(9, 4);
            this.startRangeDatePicker.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.Size = new System.Drawing.Size(149, 34);
            this.startRangeDatePicker.TabIndex = 0;
            this.startRangeDatePicker.ValueChanged += new System.EventHandler(this.control_Changed);
            // 
            // exportBtn
            // 
            this.exportBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exportBtn.Location = new System.Drawing.Point(603, 401);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(194, 46);
            this.exportBtn.TabIndex = 1;
            this.exportBtn.Text = "Экспорт";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.actionsReportBtn_Click);
            // 
            // eventsTable
            // 
            this.eventsTable.AllowUserToAddRows = false;
            this.eventsTable.AllowUserToDeleteRows = false;
            this.eventsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.eventsTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.eventsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eventsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.eventsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateTime,
            this.initiator,
            this.eventType,
            this.formName});
            this.tableLayoutPanel1.SetColumnSpan(this.eventsTable, 4);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.eventsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.eventsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.eventsTable.EnableHeadersVisualStyles = false;
            this.eventsTable.Location = new System.Drawing.Point(3, 51);
            this.eventsTable.Name = "eventsTable";
            this.eventsTable.ReadOnly = true;
            this.eventsTable.RowHeadersVisible = false;
            this.eventsTable.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.eventsTable, 4);
            this.eventsTable.RowTemplate.Height = 24;
            this.eventsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventsTable.Size = new System.Drawing.Size(794, 344);
            this.eventsTable.TabIndex = 2;
            // 
            // dateTime
            // 
            this.dateTime.HeaderText = "Время";
            this.dateTime.MinimumWidth = 6;
            this.dateTime.Name = "dateTime";
            this.dateTime.ReadOnly = true;
            // 
            // initiator
            // 
            this.initiator.HeaderText = "Инициатор";
            this.initiator.MinimumWidth = 6;
            this.initiator.Name = "initiator";
            this.initiator.ReadOnly = true;
            // 
            // eventType
            // 
            this.eventType.HeaderText = "Тип события";
            this.eventType.MinimumWidth = 6;
            this.eventType.Name = "eventType";
            this.eventType.ReadOnly = true;
            // 
            // formName
            // 
            this.formName.HeaderText = "Форма";
            this.formName.MinimumWidth = 6;
            this.formName.Name = "formName";
            this.formName.ReadOnly = true;
            // 
            // backToMenuBtn
            // 
            this.backToMenuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backToMenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenuBtn.Location = new System.Drawing.Point(3, 401);
            this.backToMenuBtn.Name = "backToMenuBtn";
            this.backToMenuBtn.Size = new System.Drawing.Size(194, 46);
            this.backToMenuBtn.TabIndex = 3;
            this.backToMenuBtn.Text = "В меню";
            this.backToMenuBtn.UseVisualStyleBackColor = true;
            this.backToMenuBtn.Click += new System.EventHandler(this.backToMenuBtn_Click);
            // 
            // reloadDataTimer
            // 
            this.reloadDataTimer.Interval = 15000;
            this.reloadDataTimer.Tick += new System.EventHandler(this.reloadDataTimer_Tick);
            // 
            // ActJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ActJournal";
            this.Text = "ActJournal";
            this.Load += new System.EventHandler(this.ActJournal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox filterEventTypeCombo;
        private System.Windows.Forms.ComboBox filterUserRoleCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endRangeDatePicker;
        private System.Windows.Forms.DateTimePicker startRangeDatePicker;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.DataGridView eventsTable;
        private System.Windows.Forms.Button backToMenuBtn;
        private System.Windows.Forms.Timer reloadDataTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn initiator;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn formName;
    }
}