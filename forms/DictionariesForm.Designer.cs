
namespace ProjectOffice.forms
{
    partial class DictionariesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictionariesForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userPhotoPic = new System.Windows.Forms.PictureBox();
            this.usrSnpLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.specCheckBtn = new System.Windows.Forms.ToolStripButton();
            this.stagesCheckBtn = new System.Windows.Forms.ToolStripButton();
            this.statusCheckBtn = new System.Windows.Forms.ToolStripButton();
            this.addObject = new System.Windows.Forms.ToolStripButton();
            this.editObject = new System.Windows.Forms.ToolStripButton();
            this.deleteObject = new System.Windows.Forms.ToolStripButton();
            this.toolsDisplayModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.typesCheckBtn = new System.Windows.Forms.ToolStripButton();
            this.subtasksCheckBtn = new System.Windows.Forms.ToolStripButton();
            this.objectTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backToMenuBtn = new System.Windows.Forms.Button();
            this.editorPanel = new System.Windows.Forms.Panel();
            this.hideEditorPanelBtn = new System.Windows.Forms.Button();
            this.objectTextBox = new System.Windows.Forms.TextBox();
            this.saveObjectBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectTable)).BeginInit();
            this.editorPanel.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.editorPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.440357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.464167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 588);
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
            this.panel1.Size = new System.Drawing.Size(571, 49);
            this.panel1.TabIndex = 0;
            // 
            // userPhotoPic
            // 
            this.userPhotoPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userPhotoPic.Image = global::ProjectOffice.Properties.Resources.USR_PLUG_PICTURE;
            this.userPhotoPic.Location = new System.Drawing.Point(525, 4);
            this.userPhotoPic.Name = "userPhotoPic";
            this.userPhotoPic.Size = new System.Drawing.Size(39, 39);
            this.userPhotoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPhotoPic.TabIndex = 6;
            this.userPhotoPic.TabStop = false;
            // 
            // usrSnpLbl
            // 
            this.usrSnpLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrSnpLbl.Location = new System.Drawing.Point(181, 7);
            this.usrSnpLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.usrSnpLbl.Name = "usrSnpLbl";
            this.usrSnpLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usrSnpLbl.Size = new System.Drawing.Size(336, 37);
            this.usrSnpLbl.TabIndex = 5;
            this.usrSnpLbl.Text = "Фамилия И.О.";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.objectTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 58);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(571, 470);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel3.Location = new System.Drawing.Point(0, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(571, 33);
            this.panel3.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specCheckBtn,
            this.stagesCheckBtn,
            this.statusCheckBtn,
            this.addObject,
            this.editObject,
            this.deleteObject,
            this.toolsDisplayModeCombo,
            this.typesCheckBtn,
            this.subtasksCheckBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(571, 33);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // specCheckBtn
            // 
            this.specCheckBtn.CheckOnClick = true;
            this.specCheckBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.specCheckBtn.Image = ((System.Drawing.Image)(resources.GetObject("specCheckBtn.Image")));
            this.specCheckBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.specCheckBtn.Name = "specCheckBtn";
            this.specCheckBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.specCheckBtn.Size = new System.Drawing.Size(121, 30);
            this.specCheckBtn.Text = "Специальности";
            this.specCheckBtn.CheckedChanged += new System.EventHandler(this.specCheckBtn_CheckedChanged);
            this.specCheckBtn.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // stagesCheckBtn
            // 
            this.stagesCheckBtn.CheckOnClick = true;
            this.stagesCheckBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stagesCheckBtn.Image = ((System.Drawing.Image)(resources.GetObject("stagesCheckBtn.Image")));
            this.stagesCheckBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stagesCheckBtn.Name = "stagesCheckBtn";
            this.stagesCheckBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.stagesCheckBtn.Size = new System.Drawing.Size(56, 30);
            this.stagesCheckBtn.Text = "Этапы";
            this.stagesCheckBtn.CheckedChanged += new System.EventHandler(this.stagesCheckBtn_CheckedChanged);
            this.stagesCheckBtn.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // statusCheckBtn
            // 
            this.statusCheckBtn.CheckOnClick = true;
            this.statusCheckBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusCheckBtn.Image = ((System.Drawing.Image)(resources.GetObject("statusCheckBtn.Image")));
            this.statusCheckBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusCheckBtn.Name = "statusCheckBtn";
            this.statusCheckBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusCheckBtn.Size = new System.Drawing.Size(67, 30);
            this.statusCheckBtn.Text = "Статусы";
            // 
            // addObject
            // 
            this.addObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addObject.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addObject.Name = "addObject";
            this.addObject.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.addObject.Size = new System.Drawing.Size(29, 30);
            this.addObject.Text = "Добавить";
            this.addObject.Click += new System.EventHandler(this.addObject_Click);
            // 
            // editObject
            // 
            this.editObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editObject.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editObject.Name = "editObject";
            this.editObject.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.editObject.Size = new System.Drawing.Size(29, 30);
            this.editObject.Text = "Удалить";
            this.editObject.Click += new System.EventHandler(this.editObject_Click);
            // 
            // deleteObject
            // 
            this.deleteObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteObject.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteObject.Name = "deleteObject";
            this.deleteObject.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.deleteObject.Size = new System.Drawing.Size(29, 30);
            this.deleteObject.Text = "Редактировать";
            this.deleteObject.Click += new System.EventHandler(this.deleteObject_Click);
            // 
            // toolsDisplayModeCombo
            // 
            this.toolsDisplayModeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolsDisplayModeCombo.Name = "toolsDisplayModeCombo";
            this.toolsDisplayModeCombo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolsDisplayModeCombo.Size = new System.Drawing.Size(121, 33);
            this.toolsDisplayModeCombo.ToolTipText = "Режим отображения";
            // 
            // typesCheckBtn
            // 
            this.typesCheckBtn.CheckOnClick = true;
            this.typesCheckBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.typesCheckBtn.Image = ((System.Drawing.Image)(resources.GetObject("typesCheckBtn.Image")));
            this.typesCheckBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.typesCheckBtn.Name = "typesCheckBtn";
            this.typesCheckBtn.Size = new System.Drawing.Size(146, 24);
            this.typesCheckBtn.Text = "Типы организаций";
            this.typesCheckBtn.CheckedChanged += new System.EventHandler(this.typesCheckBtn_CheckedChanged);
            this.typesCheckBtn.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // subtasksCheckBtn
            // 
            this.subtasksCheckBtn.CheckOnClick = true;
            this.subtasksCheckBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.subtasksCheckBtn.Image = ((System.Drawing.Image)(resources.GetObject("subtasksCheckBtn.Image")));
            this.subtasksCheckBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subtasksCheckBtn.Name = "subtasksCheckBtn";
            this.subtasksCheckBtn.Size = new System.Drawing.Size(89, 24);
            this.subtasksCheckBtn.Text = "Подзадачи";
            this.subtasksCheckBtn.CheckedChanged += new System.EventHandler(this.subtasksCheckBtn_CheckedChanged);
            this.subtasksCheckBtn.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // objectTable
            // 
            this.objectTable.AllowUserToAddRows = false;
            this.objectTable.AllowUserToDeleteRows = false;
            this.objectTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.objectTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.objectTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.objectTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.objectTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.objectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.objectTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name});
            this.objectTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.objectTable.EnableHeadersVisualStyles = false;
            this.objectTable.Location = new System.Drawing.Point(0, 0);
            this.objectTable.MultiSelect = false;
            this.objectTable.Name = "objectTable";
            this.objectTable.RowHeadersVisible = false;
            this.objectTable.RowHeadersWidth = 51;
            this.objectTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.objectTable.RowTemplate.Height = 24;
            this.objectTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.objectTable.Size = new System.Drawing.Size(571, 470);
            this.objectTable.TabIndex = 0;
            // 
            // name
            // 
            this.name.HeaderText = "Column1";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            // 
            // backToMenuBtn
            // 
            this.backToMenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenuBtn.Location = new System.Drawing.Point(3, 534);
            this.backToMenuBtn.Name = "backToMenuBtn";
            this.backToMenuBtn.Size = new System.Drawing.Size(150, 38);
            this.backToMenuBtn.TabIndex = 2;
            this.backToMenuBtn.Text = "Меню";
            this.backToMenuBtn.UseVisualStyleBackColor = true;
            this.backToMenuBtn.Click += new System.EventHandler(this.backToMenuBtn_Click);
            // 
            // editorPanel
            // 
            this.editorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.editorPanel.Controls.Add(this.hideEditorPanelBtn);
            this.editorPanel.Controls.Add(this.objectTextBox);
            this.editorPanel.Controls.Add(this.saveObjectBtn);
            this.editorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editorPanel.Location = new System.Drawing.Point(580, 3);
            this.editorPanel.Name = "editorPanel";
            this.tableLayoutPanel1.SetRowSpan(this.editorPanel, 4);
            this.editorPanel.Size = new System.Drawing.Size(213, 582);
            this.editorPanel.TabIndex = 3;
            // 
            // hideEditorPanelBtn
            // 
            this.hideEditorPanelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideEditorPanelBtn.Location = new System.Drawing.Point(4, 533);
            this.hideEditorPanelBtn.Name = "hideEditorPanelBtn";
            this.hideEditorPanelBtn.Size = new System.Drawing.Size(43, 40);
            this.hideEditorPanelBtn.TabIndex = 3;
            this.hideEditorPanelBtn.Text = ">";
            this.hideEditorPanelBtn.UseVisualStyleBackColor = true;
            this.hideEditorPanelBtn.Click += new System.EventHandler(this.hideEditorPanelBtn_Click);
            // 
            // objectTextBox
            // 
            this.objectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.objectTextBox.Location = new System.Drawing.Point(27, 304);
            this.objectTextBox.Name = "objectTextBox";
            this.objectTextBox.Size = new System.Drawing.Size(168, 30);
            this.objectTextBox.TabIndex = 1;
            this.objectTextBox.Text = "Иванов";
            // 
            // saveObjectBtn
            // 
            this.saveObjectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveObjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveObjectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveObjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveObjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveObjectBtn.Location = new System.Drawing.Point(76, 533);
            this.saveObjectBtn.Name = "saveObjectBtn";
            this.saveObjectBtn.Size = new System.Drawing.Size(128, 40);
            this.saveObjectBtn.TabIndex = 0;
            this.saveObjectBtn.Text = "Сохранить";
            this.saveObjectBtn.UseVisualStyleBackColor = false;
            // 
            // DictionariesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 588);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DictionariesForm";
            this.Text = "DictionariesForm";
            this.Load += new System.EventHandler(this.DictionariesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPhotoPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectTable)).EndInit();
            this.editorPanel.ResumeLayout(false);
            this.editorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addObject;
        private System.Windows.Forms.ToolStripButton editObject;
        private System.Windows.Forms.ToolStripButton deleteObject;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView objectTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button backToMenuBtn;
        private System.Windows.Forms.Panel editorPanel;
        private System.Windows.Forms.Button hideEditorPanelBtn;
        private System.Windows.Forms.TextBox objectTextBox;
        private System.Windows.Forms.Button saveObjectBtn;
        private System.Windows.Forms.ToolStripButton specCheckBtn;
        private System.Windows.Forms.ToolStripButton statusCheckBtn;
        private System.Windows.Forms.ToolStripButton stagesCheckBtn;
        private System.Windows.Forms.ToolStripComboBox toolsDisplayModeCombo;
        private System.Windows.Forms.ToolStripButton typesCheckBtn;
        private System.Windows.Forms.ToolStripButton subtasksCheckBtn;
        private System.Windows.Forms.PictureBox userPhotoPic;
        private System.Windows.Forms.Label usrSnpLbl;
    }
}