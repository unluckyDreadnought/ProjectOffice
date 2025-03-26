
namespace ProjectOffice.forms
{
    partial class ControlPointEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.projNumLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.descTxt = new System.Windows.Forms.TextBox();
            this.mainTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.backToTree = new System.Windows.Forms.Button();
            this.stageName = new System.Windows.Forms.Label();
            this.subtaskTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Этап:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Статус:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Проект:";
            // 
            // projNumLbl
            // 
            this.projNumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projNumLbl.Location = new System.Drawing.Point(197, 11);
            this.projNumLbl.Name = "projNumLbl";
            this.projNumLbl.Size = new System.Drawing.Size(509, 29);
            this.projNumLbl.TabIndex = 4;
            this.projNumLbl.Text = "Проект #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Подзадача:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(47, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Описание точки";
            // 
            // statusCombo
            // 
            this.statusCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCombo.FormattingEnabled = true;
            this.statusCombo.Location = new System.Drawing.Point(202, 399);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(364, 37);
            this.statusCombo.TabIndex = 1;
            this.statusCombo.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
            // 
            // descTxt
            // 
            this.descTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.descTxt.Location = new System.Drawing.Point(52, 264);
            this.descTxt.MaxLength = 512;
            this.descTxt.Multiline = true;
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(626, 115);
            this.descTxt.TabIndex = 5;
            this.descTxt.TextChanged += new System.EventHandler(this.control_Changed);
            this.descTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descTxt_KeyPress);
            // 
            // mainTxt
            // 
            this.mainTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainTxt.Location = new System.Drawing.Point(52, 186);
            this.mainTxt.MaxLength = 100;
            this.mainTxt.Name = "mainTxt";
            this.mainTxt.Size = new System.Drawing.Size(626, 34);
            this.mainTxt.TabIndex = 5;
            this.mainTxt.TextChanged += new System.EventHandler(this.control_Changed);
            this.mainTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainTxt_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(47, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Краткая информация";
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.addBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.addBtn.Location = new System.Drawing.Point(548, 457);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(158, 42);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // backToTree
            // 
            this.backToTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToTree.Location = new System.Drawing.Point(12, 457);
            this.backToTree.Name = "backToTree";
            this.backToTree.Size = new System.Drawing.Size(223, 42);
            this.backToTree.TabIndex = 6;
            this.backToTree.Text = "К списку задач";
            this.backToTree.UseVisualStyleBackColor = true;
            this.backToTree.Click += new System.EventHandler(this.backToTree_Click);
            // 
            // stageName
            // 
            this.stageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stageName.Location = new System.Drawing.Point(197, 48);
            this.stageName.Name = "stageName";
            this.stageName.Size = new System.Drawing.Size(493, 34);
            this.stageName.TabIndex = 7;
            this.stageName.Text = "stageName";
            // 
            // subtaskTitle
            // 
            this.subtaskTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtaskTitle.Location = new System.Drawing.Point(197, 82);
            this.subtaskTitle.Name = "subtaskTitle";
            this.subtaskTitle.Size = new System.Drawing.Size(493, 74);
            this.subtaskTitle.TabIndex = 8;
            this.subtaskTitle.Text = "subtask";
            // 
            // ControlPointEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(718, 511);
            this.ControlBox = false;
            this.Controls.Add(this.subtaskTitle);
            this.Controls.Add(this.stageName);
            this.Controls.Add(this.backToTree);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.mainTxt);
            this.Controls.Add(this.descTxt);
            this.Controls.Add(this.projNumLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusCombo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ControlPointEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор контрольных точек";
            this.Load += new System.EventHandler(this.ControlPointEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label projNumLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox statusCombo;
        private System.Windows.Forms.TextBox descTxt;
        private System.Windows.Forms.TextBox mainTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button backToTree;
        private System.Windows.Forms.Label stageName;
        private System.Windows.Forms.Label subtaskTitle;
    }
}