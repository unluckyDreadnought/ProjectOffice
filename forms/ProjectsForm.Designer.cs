
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.projectEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.projectStartRangeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.projectResetFilterBtn = new System.Windows.Forms.Button();
            this.projectSearchLineTextBox = new System.Windows.Forms.TextBox();
            this.projectSortCombo = new System.Windows.Forms.ComboBox();
            this.projectFilterCombo = new System.Windows.Forms.ComboBox();
            this.projectFilterOnCombo = new System.Windows.Forms.ComboBox();
            this.projectsTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.editProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.backToMenu = new System.Windows.Forms.Button();
            this.projectReportBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsTable)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.projectsTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.9513F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.214445F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.214445F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.214445F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.42889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.73278F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.24369F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.projectEndDatePicker);
            this.panel1.Controls.Add(this.projectStartRangeDatePicker);
            this.panel1.Controls.Add(this.projectResetFilterBtn);
            this.panel1.Controls.Add(this.projectSearchLineTextBox);
            this.panel1.Controls.Add(this.projectSortCombo);
            this.panel1.Controls.Add(this.projectFilterCombo);
            this.panel1.Controls.Add(this.projectFilterOnCombo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 74);
            this.panel1.TabIndex = 0;
            // 
            // projectEndDatePicker
            // 
            this.projectEndDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.projectEndDatePicker.Location = new System.Drawing.Point(339, 4);
            this.projectEndDatePicker.Name = "projectEndDatePicker";
            this.projectEndDatePicker.Size = new System.Drawing.Size(214, 30);
            this.projectEndDatePicker.TabIndex = 3;
            // 
            // projectStartRangeDatePicker
            // 
            this.projectStartRangeDatePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.projectStartRangeDatePicker.Location = new System.Drawing.Point(10, 4);
            this.projectStartRangeDatePicker.Name = "projectStartRangeDatePicker";
            this.projectStartRangeDatePicker.Size = new System.Drawing.Size(209, 30);
            this.projectStartRangeDatePicker.TabIndex = 3;
            // 
            // projectResetFilterBtn
            // 
            this.projectResetFilterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.projectResetFilterBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.projectResetFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectResetFilterBtn.Location = new System.Drawing.Point(763, 38);
            this.projectResetFilterBtn.Name = "projectResetFilterBtn";
            this.projectResetFilterBtn.Size = new System.Drawing.Size(204, 36);
            this.projectResetFilterBtn.TabIndex = 2;
            this.projectResetFilterBtn.Text = "Сбросить";
            this.projectResetFilterBtn.UseVisualStyleBackColor = false;
            // 
            // projectSearchLineTextBox
            // 
            this.projectSearchLineTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectSearchLineTextBox.Location = new System.Drawing.Point(9, 38);
            this.projectSearchLineTextBox.Name = "projectSearchLineTextBox";
            this.projectSearchLineTextBox.Size = new System.Drawing.Size(544, 30);
            this.projectSearchLineTextBox.TabIndex = 1;
            this.projectSearchLineTextBox.Text = "Поиск";
            // 
            // projectSortCombo
            // 
            this.projectSortCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectSortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectSortCombo.FormattingEnabled = true;
            this.projectSortCombo.Items.AddRange(new object[] {
            "Наименьший бюджет",
            "Наибольшая бюджет",
            "Имя по возрастанию",
            "Имя по убыванию"});
            this.projectSortCombo.Location = new System.Drawing.Point(763, 3);
            this.projectSortCombo.Name = "projectSortCombo";
            this.projectSortCombo.Size = new System.Drawing.Size(204, 33);
            this.projectSortCombo.TabIndex = 0;
            // 
            // projectFilterCombo
            // 
            this.projectFilterCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectFilterCombo.FormattingEnabled = true;
            this.projectFilterCombo.Location = new System.Drawing.Point(559, 38);
            this.projectFilterCombo.Name = "projectFilterCombo";
            this.projectFilterCombo.Size = new System.Drawing.Size(198, 33);
            this.projectFilterCombo.TabIndex = 0;
            // 
            // projectFilterOnCombo
            // 
            this.projectFilterOnCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectFilterOnCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectFilterOnCombo.FormattingEnabled = true;
            this.projectFilterOnCombo.Items.AddRange(new object[] {
            "Фильтр по ...",
            "Ответственные",
            "Этапы",
            "Статус"});
            this.projectFilterOnCombo.Location = new System.Drawing.Point(559, 3);
            this.projectFilterOnCombo.Name = "projectFilterOnCombo";
            this.projectFilterOnCombo.Size = new System.Drawing.Size(198, 33);
            this.projectFilterOnCombo.TabIndex = 0;
            // 
            // projectsTable
            // 
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
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Coumn,
            this.Column6});
            this.tableLayoutPanel1.SetColumnSpan(this.projectsTable, 4);
            this.projectsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsTable.EnableHeadersVisualStyles = false;
            this.projectsTable.Location = new System.Drawing.Point(3, 83);
            this.projectsTable.Name = "projectsTable";
            this.projectsTable.RowHeadersVisible = false;
            this.projectsTable.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.projectsTable, 5);
            this.projectsTable.RowTemplate.Height = 24;
            this.projectsTable.Size = new System.Drawing.Size(970, 314);
            this.projectsTable.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название проекта";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Заказчик";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ответственный";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Этап";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Coumn
            // 
            this.Coumn.HeaderText = "Статус";
            this.Coumn.MinimumWidth = 6;
            this.Coumn.Name = "Coumn";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Бюджет";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.backToMenu);
            this.panel2.Controls.Add(this.projectReportBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 44);
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
            this.toolStrip1.Location = new System.Drawing.Point(349, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(296, 31);
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
            this.toolsDisplayModeCombo.Size = new System.Drawing.Size(121, 31);
            this.toolsDisplayModeCombo.ToolTipText = "Режим отображения";
            // 
            // backToMenu
            // 
            this.backToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToMenu.Location = new System.Drawing.Point(10, 3);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(102, 38);
            this.backToMenu.TabIndex = 1;
            this.backToMenu.Text = "В меню";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // projectReportBtn
            // 
            this.projectReportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.projectReportBtn.Location = new System.Drawing.Point(870, 3);
            this.projectReportBtn.Name = "projectReportBtn";
            this.projectReportBtn.Size = new System.Drawing.Size(91, 38);
            this.projectReportBtn.TabIndex = 0;
            this.projectReportBtn.Text = "Отчёт";
            this.projectReportBtn.UseVisualStyleBackColor = true;
            // 
            // ProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(976, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProjectsForm";
            this.Text = "ProjectsForm";
            this.Load += new System.EventHandler(this.ProjectsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.DataGridView projectsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addProjectBtn;
        private System.Windows.Forms.ToolStripButton editProjectBtn;
        private System.Windows.Forms.ToolStripButton deleteProjectBtn;
        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.Button projectReportBtn;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayModeCombo;
    }
}