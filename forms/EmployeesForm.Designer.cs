
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
            this.userPhotoPic = new System.Windows.Forms.PictureBox();
            this.usrSnpLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.actionsPanel = new System.Windows.Forms.ToolStrip();
            this.specFilterCombo = new System.Windows.Forms.ToolStripComboBox();
            this.addEmployeeBtn = new System.Windows.Forms.ToolStripButton();
            this.editEmployeeBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteEmployeeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.employeeTable = new System.Windows.Forms.DataGridView();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haveAccountCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.backToMenu = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.backToMenu, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.440356F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.464166F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 452);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.userPhotoPic);
            this.panel1.Controls.Add(this.usrSnpLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 36);
            this.panel1.TabIndex = 0;
            // 
            // userPhotoPic
            // 
            this.userPhotoPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userPhotoPic.Image = global::ProjectOffice.Properties.Resources.USR_PLUG_PICTURE;
            this.userPhotoPic.Location = new System.Drawing.Point(737, 0);
            this.userPhotoPic.Name = "userPhotoPic";
            this.userPhotoPic.Size = new System.Drawing.Size(39, 36);
            this.userPhotoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPic.TabIndex = 6;
            this.userPhotoPic.TabStop = false;
            // 
            // usrSnpLbl
            // 
            this.usrSnpLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrSnpLbl.Location = new System.Drawing.Point(393, 4);
            this.usrSnpLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.usrSnpLbl.Name = "usrSnpLbl";
            this.usrSnpLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usrSnpLbl.Size = new System.Drawing.Size(336, 30);
            this.usrSnpLbl.TabIndex = 5;
            this.usrSnpLbl.Text = "Фамилия И.О.";
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
            this.panel2.Size = new System.Drawing.Size(779, 360);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.actionsPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 316);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(779, 44);
            this.panel3.TabIndex = 2;
            // 
            // actionsPanel
            // 
            this.actionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.actionsPanel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.actionsPanel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.actionsPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specFilterCombo,
            this.addEmployeeBtn,
            this.editEmployeeBtn,
            this.deleteEmployeeBtn,
            this.toolsDisplayModeCombo});
            this.actionsPanel.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.actionsPanel.Location = new System.Drawing.Point(223, 8);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.actionsPanel.Size = new System.Drawing.Size(297, 27);
            this.actionsPanel.Stretch = true;
            this.actionsPanel.TabIndex = 1;
            this.actionsPanel.Text = "toolStrip1";
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
            this.specFilterCombo.Size = new System.Drawing.Size(121, 27);
            this.specFilterCombo.ToolTipText = "Фильтр по должности";
            // 
            // addEmployeeBtn
            // 
            this.addEmployeeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addEmployeeBtn.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addEmployeeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addEmployeeBtn.Name = "addEmployeeBtn";
            this.addEmployeeBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.addEmployeeBtn.Size = new System.Drawing.Size(24, 24);
            this.addEmployeeBtn.Text = "Добавить сотрудника";
            this.addEmployeeBtn.Click += new System.EventHandler(this.addEmployeeBtn_Click);
            // 
            // editEmployeeBtn
            // 
            this.editEmployeeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editEmployeeBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editEmployeeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editEmployeeBtn.Name = "editEmployeeBtn";
            this.editEmployeeBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.editEmployeeBtn.Size = new System.Drawing.Size(24, 24);
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
            this.deleteEmployeeBtn.Size = new System.Drawing.Size(24, 24);
            this.deleteEmployeeBtn.Text = "Удалить";
            this.deleteEmployeeBtn.Click += new System.EventHandler(this.deleteEmployeeBtn_Click);
            // 
            // toolsDisplayModeCombo
            // 
            this.toolsDisplayModeCombo.Items.AddRange(new object[] {
            "Иконка",
            "Текст",
            "Совместный"});
            this.toolsDisplayModeCombo.Name = "toolsDisplayModeCombo";
            this.toolsDisplayModeCombo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolsDisplayModeCombo.Size = new System.Drawing.Size(121, 27);
            this.toolsDisplayModeCombo.ToolTipText = "Режим отображения";
            // 
            // employeeTable
            // 
            this.employeeTable.AllowUserToAddRows = false;
            this.employeeTable.AllowUserToDeleteRows = false;
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
            this.idCol,
            this.fio,
            this.spec,
            this.haveAccountCol});
            this.employeeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.employeeTable.EnableHeadersVisualStyles = false;
            this.employeeTable.Location = new System.Drawing.Point(0, 0);
            this.employeeTable.Name = "employeeTable";
            this.employeeTable.RowHeadersVisible = false;
            this.employeeTable.RowHeadersWidth = 51;
            this.employeeTable.RowTemplate.Height = 24;
            this.employeeTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeTable.Size = new System.Drawing.Size(779, 360);
            this.employeeTable.TabIndex = 0;
            this.employeeTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeTable_CellClick);
            // 
            // idCol
            // 
            this.idCol.HeaderText = "Column1";
            this.idCol.Name = "idCol";
            this.idCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idCol.Visible = false;
            // 
            // fio
            // 
            this.fio.FillWeight = 4F;
            this.fio.HeaderText = "ФИО";
            this.fio.MinimumWidth = 6;
            this.fio.Name = "fio";
            this.fio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // spec
            // 
            this.spec.FillWeight = 5F;
            this.spec.HeaderText = "Должность";
            this.spec.MinimumWidth = 6;
            this.spec.Name = "spec";
            this.spec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // haveAccountCol
            // 
            this.haveAccountCol.FillWeight = 2F;
            this.haveAccountCol.HeaderText = "Аккаунт";
            this.haveAccountCol.Name = "haveAccountCol";
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
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 452);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeesForm";
            this.Load += new System.EventHandler(this.EmployeesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.actionsPanel.ResumeLayout(false);
            this.actionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip actionsPanel;
        private System.Windows.Forms.ToolStripButton editEmployeeBtn;
        private System.Windows.Forms.ToolStripButton deleteEmployeeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView employeeTable;
        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.ToolStripComboBox specFilterCombo;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayModeCombo;
        private System.Windows.Forms.ToolStripButton addEmployeeBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.DataGridViewCheckBoxColumn haveAccountCol;
        private System.Windows.Forms.PictureBox userPhotoPic;
        private System.Windows.Forms.Label usrSnpLbl;
    }
}