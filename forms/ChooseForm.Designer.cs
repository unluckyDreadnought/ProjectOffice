﻿
namespace ProjectOffice.forms
{
    partial class ChooseForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.addObject = new System.Windows.Forms.Button();
            this.searchGroup = new System.Windows.Forms.GroupBox();
            this.searchLine = new System.Windows.Forms.TextBox();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.chooseBtn = new System.Windows.Forms.Button();
            this.chooseObjectsTable = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.searchGroup.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chooseObjectsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.panel1.Controls.Add(this.addObject);
            this.panel1.Controls.Add(this.searchGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 75);
            this.panel1.TabIndex = 0;
            // 
            // addObject
            // 
            this.addObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addObject.AutoSize = true;
            this.addObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.addObject.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addObject.Location = new System.Drawing.Point(536, 27);
            this.addObject.Name = "addObject";
            this.addObject.Size = new System.Drawing.Size(40, 41);
            this.addObject.TabIndex = 1;
            this.addObject.Text = "+";
            this.addObject.UseVisualStyleBackColor = false;
            // 
            // searchGroup
            // 
            this.searchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchGroup.Controls.Add(this.searchLine);
            this.searchGroup.Location = new System.Drawing.Point(8, 0);
            this.searchGroup.Name = "searchGroup";
            this.searchGroup.Size = new System.Drawing.Size(517, 72);
            this.searchGroup.TabIndex = 0;
            this.searchGroup.TabStop = false;
            this.searchGroup.Text = "Поиск";
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLine.Location = new System.Drawing.Point(3, 30);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(511, 34);
            this.searchLine.TabIndex = 2;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.cancelBtn);
            this.buttonsPanel.Controls.Add(this.chooseBtn);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 437);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(584, 51);
            this.buttonsPanel.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(12, 6);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(136, 42);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // chooseBtn
            // 
            this.chooseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.chooseBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.chooseBtn.Location = new System.Drawing.Point(436, 6);
            this.chooseBtn.Name = "chooseBtn";
            this.chooseBtn.Size = new System.Drawing.Size(136, 42);
            this.chooseBtn.TabIndex = 0;
            this.chooseBtn.Text = "Выбрать";
            this.chooseBtn.UseVisualStyleBackColor = false;
            this.chooseBtn.Click += new System.EventHandler(this.chooseBtn_Click);
            // 
            // chooseObjectsTable
            // 
            this.chooseObjectsTable.AllowUserToAddRows = false;
            this.chooseObjectsTable.AllowUserToDeleteRows = false;
            this.chooseObjectsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chooseObjectsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.chooseObjectsTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseObjectsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chooseObjectsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.chooseObjectsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chooseObjectsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseObjectsTable.EnableHeadersVisualStyles = false;
            this.chooseObjectsTable.Location = new System.Drawing.Point(0, 75);
            this.chooseObjectsTable.Name = "chooseObjectsTable";
            this.chooseObjectsTable.ReadOnly = true;
            this.chooseObjectsTable.RowHeadersVisible = false;
            this.chooseObjectsTable.RowHeadersWidth = 51;
            this.chooseObjectsTable.RowTemplate.Height = 24;
            this.chooseObjectsTable.Size = new System.Drawing.Size(584, 362);
            this.chooseObjectsTable.TabIndex = 3;
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 488);
            this.Controls.Add(this.chooseObjectsTable);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChooseForm";
            this.Text = "ChooseForm";
            this.Load += new System.EventHandler(this.ChooseForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.searchGroup.ResumeLayout(false);
            this.searchGroup.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chooseObjectsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.DataGridView chooseObjectsTable;
        private System.Windows.Forms.GroupBox searchGroup;
        private System.Windows.Forms.TextBox searchLine;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button chooseBtn;
        private System.Windows.Forms.Button addObject;
    }
}