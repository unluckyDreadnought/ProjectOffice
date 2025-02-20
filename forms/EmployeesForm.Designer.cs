
namespace ProjectOffice.forms
{
    partial class EmployeesForm
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
            this.userSnpLbl = new System.Windows.Forms.Label();
            this.userModeLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.specFilterCombo = new System.Windows.Forms.ToolStripComboBox();
            this.editEmployeeBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteEmployeeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.employeeTable = new System.Windows.Forms.DataGridView();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backToMenu = new System.Windows.Forms.Button();
            this.employeeEditorPanel = new System.Windows.Forms.Panel();
            this.hideEditorPanel = new System.Windows.Forms.Button();
            this.specCombo = new System.Windows.Forms.ComboBox();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.saveEmployeeData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTable)).BeginInit();
            this.employeeEditorPanel.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.backToMenu, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.employeeEditorPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.440357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.464167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 452);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.userSnpLbl);
            this.panel1.Controls.Add(this.userModeLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 36);
            this.panel1.TabIndex = 0;
            // 
            // userSnpLbl
            // 
            this.userSnpLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userSnpLbl.AutoSize = true;
            this.userSnpLbl.Location = new System.Drawing.Point(242, 6);
            this.userSnpLbl.Name = "userSnpLbl";
            this.userSnpLbl.Size = new System.Drawing.Size(79, 29);
            this.userSnpLbl.TabIndex = 0;
            this.userSnpLbl.Text = "label1";
            // 
            // userModeLbl
            // 
            this.userModeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userModeLbl.AutoSize = true;
            this.userModeLbl.Location = new System.Drawing.Point(410, 6);
            this.userModeLbl.Name = "userModeLbl";
            this.userModeLbl.Size = new System.Drawing.Size(79, 29);
            this.userModeLbl.TabIndex = 0;
            this.userModeLbl.Text = "label1";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.employeeTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(565, 360);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 316);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(565, 44);
            this.panel3.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specFilterCombo,
            this.editEmployeeBtn,
            this.deleteEmployeeBtn,
            this.toolsDisplayModeCombo});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(108, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(304, 28);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // specFilterCombo
            // 
            this.specFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specFilterCombo.Items.AddRange(new object[] {
            "Должность",
            "Неопределена",
            "Программист",
            "Аналитик",
            "Аднистратор баз данных"});
            this.specFilterCombo.Name = "specFilterCombo";
            this.specFilterCombo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.specFilterCombo.Size = new System.Drawing.Size(121, 28);
            this.specFilterCombo.ToolTipText = "Фильтр по должности";
            // 
            // editEmployeeBtn
            // 
            this.editEmployeeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editEmployeeBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editEmployeeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editEmployeeBtn.Name = "editEmployeeBtn";
            this.editEmployeeBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.editEmployeeBtn.Size = new System.Drawing.Size(29, 25);
            this.editEmployeeBtn.Text = "Редактировать";
            this.editEmployeeBtn.Click += new System.EventHandler(this.editEmployeeBtn_Click);
            // 
            // deleteEmployeeBtn
            // 
            this.deleteEmployeeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteEmployeeBtn.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteEmployeeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteEmployeeBtn.Name = "deleteEmployeeBtn";
            this.deleteEmployeeBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.deleteEmployeeBtn.Size = new System.Drawing.Size(29, 25);
            this.deleteEmployeeBtn.Text = "Удалить";
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
            // employeeTable
            // 
            this.employeeTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeeTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.employeeTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.employeeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fio,
            this.spec});
            this.employeeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.employeeTable.EnableHeadersVisualStyles = false;
            this.employeeTable.Location = new System.Drawing.Point(0, 0);
            this.employeeTable.Name = "employeeTable";
            this.employeeTable.RowHeadersVisible = false;
            this.employeeTable.RowHeadersWidth = 51;
            this.employeeTable.RowTemplate.Height = 24;
            this.employeeTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeTable.Size = new System.Drawing.Size(565, 360);
            this.employeeTable.TabIndex = 0;
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.MinimumWidth = 6;
            this.fio.Name = "fio";
            // 
            // spec
            // 
            this.spec.HeaderText = "Должность";
            this.spec.MinimumWidth = 6;
            this.spec.Name = "spec";
            // 
            // backToMenu
            // 
            this.backToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenu.Location = new System.Drawing.Point(3, 411);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(150, 38);
            this.backToMenu.TabIndex = 2;
            this.backToMenu.Text = "Меню";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // employeeEditorPanel
            // 
            this.employeeEditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.employeeEditorPanel.Controls.Add(this.hideEditorPanel);
            this.employeeEditorPanel.Controls.Add(this.specCombo);
            this.employeeEditorPanel.Controls.Add(this.patronymicTextBox);
            this.employeeEditorPanel.Controls.Add(this.nameTextBox);
            this.employeeEditorPanel.Controls.Add(this.surnameTextBox);
            this.employeeEditorPanel.Controls.Add(this.saveEmployeeData);
            this.employeeEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeEditorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeeEditorPanel.Location = new System.Drawing.Point(574, 3);
            this.employeeEditorPanel.Name = "employeeEditorPanel";
            this.tableLayoutPanel1.SetRowSpan(this.employeeEditorPanel, 4);
            this.employeeEditorPanel.Size = new System.Drawing.Size(208, 446);
            this.employeeEditorPanel.TabIndex = 3;
            // 
            // hideEditorPanel
            // 
            this.hideEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideEditorPanel.Location = new System.Drawing.Point(4, 397);
            this.hideEditorPanel.Name = "hideEditorPanel";
            this.hideEditorPanel.Size = new System.Drawing.Size(43, 40);
            this.hideEditorPanel.TabIndex = 3;
            this.hideEditorPanel.Text = ">";
            this.hideEditorPanel.UseVisualStyleBackColor = true;
            this.hideEditorPanel.Click += new System.EventHandler(this.hideEditorPanel_Click);
            // 
            // specCombo
            // 
            this.specCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.specCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specCombo.FormattingEnabled = true;
            this.specCombo.Items.AddRange(new object[] {
            "Аналитик",
            "Менеджер",
            "Программист",
            "Администратор баз данных"});
            this.specCombo.Location = new System.Drawing.Point(36, 192);
            this.specCombo.Name = "specCombo";
            this.specCombo.Size = new System.Drawing.Size(163, 33);
            this.specCombo.TabIndex = 2;
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patronymicTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.patronymicTextBox.Location = new System.Drawing.Point(36, 124);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(163, 30);
            this.patronymicTextBox.TabIndex = 1;
            this.patronymicTextBox.Text = "Иванович";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nameTextBox.Location = new System.Drawing.Point(36, 71);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(163, 30);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Text = "Иван";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.surnameTextBox.Location = new System.Drawing.Point(36, 25);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(163, 30);
            this.surnameTextBox.TabIndex = 1;
            this.surnameTextBox.Text = "Иванов";
            // 
            // saveEmployeeData
            // 
            this.saveEmployeeData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveEmployeeData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveEmployeeData.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveEmployeeData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveEmployeeData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(252)))));
            this.saveEmployeeData.Location = new System.Drawing.Point(71, 397);
            this.saveEmployeeData.Name = "saveEmployeeData";
            this.saveEmployeeData.Size = new System.Drawing.Size(128, 40);
            this.saveEmployeeData.TabIndex = 0;
            this.saveEmployeeData.Text = "Сохранить";
            this.saveEmployeeData.UseVisualStyleBackColor = false;
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 452);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EmployeesForm";
            this.Text = "EmployeesForm";
            this.Load += new System.EventHandler(this.EmployeesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTable)).EndInit();
            this.employeeEditorPanel.ResumeLayout(false);
            this.employeeEditorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userSnpLbl;
        private System.Windows.Forms.Label userModeLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton editEmployeeBtn;
        private System.Windows.Forms.ToolStripButton deleteEmployeeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView employeeTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.Panel employeeEditorPanel;
        private System.Windows.Forms.Button hideEditorPanel;
        private System.Windows.Forms.ComboBox specCombo;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Button saveEmployeeData;
        private System.Windows.Forms.ToolStripComboBox specFilterCombo;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayModeCombo;
    }
}