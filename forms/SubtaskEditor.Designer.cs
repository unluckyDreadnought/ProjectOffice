
namespace ProjectOffice.forms
{
    partial class SubtaskEditor
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
            this.projectNumLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subtaskCombo = new System.Windows.Forms.ComboBox();
            this.subtaskDescTxt = new System.Windows.Forms.TextBox();
            this.addSubtask = new System.Windows.Forms.Button();
            this.backToTree = new System.Windows.Forms.Button();
            this.stageName = new System.Windows.Forms.Label();
            this.subtaskLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projectNumLbl
            // 
            this.projectNumLbl.Location = new System.Drawing.Point(12, 9);
            this.projectNumLbl.Name = "projectNumLbl";
            this.projectNumLbl.Size = new System.Drawing.Size(159, 61);
            this.projectNumLbl.TabIndex = 0;
            this.projectNumLbl.Text = "Проект #";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Этап:";
            // 
            // subtaskCombo
            // 
            this.subtaskCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtaskCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subtaskCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.subtaskCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subtaskCombo.FormattingEnabled = true;
            this.subtaskCombo.Location = new System.Drawing.Point(17, 102);
            this.subtaskCombo.Name = "subtaskCombo";
            this.subtaskCombo.Size = new System.Drawing.Size(590, 37);
            this.subtaskCombo.TabIndex = 2;
            this.subtaskCombo.SelectedIndexChanged += new System.EventHandler(this.subtaskCombo_SelectedIndexChanged);
            this.subtaskCombo.TextChanged += new System.EventHandler(this.subtaskCombo_TextChanged);
            this.subtaskCombo.Click += new System.EventHandler(this.subtaskCombo_Click);
            this.subtaskCombo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.subtaskName_KeyPressed);
            this.subtaskCombo.Leave += new System.EventHandler(this.subtaskCombo_Leave);
            // 
            // subtaskDescTxt
            // 
            this.subtaskDescTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtaskDescTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subtaskDescTxt.Location = new System.Drawing.Point(17, 145);
            this.subtaskDescTxt.Multiline = true;
            this.subtaskDescTxt.Name = "subtaskDescTxt";
            this.subtaskDescTxt.Size = new System.Drawing.Size(590, 129);
            this.subtaskDescTxt.TabIndex = 3;
            this.subtaskDescTxt.Click += new System.EventHandler(this.subtaskDescTxt_Click);
            this.subtaskDescTxt.TextChanged += new System.EventHandler(this.subtaskDescTxt_TextChanged);
            this.subtaskDescTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.subtaskDesc_KeyPressed);
            this.subtaskDescTxt.Leave += new System.EventHandler(this.subtaskDescTxt_Leave);
            // 
            // addSubtask
            // 
            this.addSubtask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSubtask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.addSubtask.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addSubtask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSubtask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.addSubtask.Location = new System.Drawing.Point(467, 296);
            this.addSubtask.Name = "addSubtask";
            this.addSubtask.Size = new System.Drawing.Size(140, 44);
            this.addSubtask.TabIndex = 5;
            this.addSubtask.Text = "Добавить";
            this.addSubtask.UseVisualStyleBackColor = false;
            this.addSubtask.Click += new System.EventHandler(this.addSubtask_Click);
            // 
            // backToTree
            // 
            this.backToTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToTree.Location = new System.Drawing.Point(13, 296);
            this.backToTree.Name = "backToTree";
            this.backToTree.Size = new System.Drawing.Size(136, 44);
            this.backToTree.TabIndex = 5;
            this.backToTree.Text = "К списку задач";
            this.backToTree.UseVisualStyleBackColor = true;
            this.backToTree.Click += new System.EventHandler(this.backToTree_Click);
            // 
            // stageName
            // 
            this.stageName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stageName.Location = new System.Drawing.Point(278, 9);
            this.stageName.Name = "stageName";
            this.stageName.Size = new System.Drawing.Size(331, 61);
            this.stageName.TabIndex = 6;
            this.stageName.Text = "Наименование этапа";
            // 
            // subtaskLbl
            // 
            this.subtaskLbl.AutoSize = true;
            this.subtaskLbl.Location = new System.Drawing.Point(12, 70);
            this.subtaskLbl.Name = "subtaskLbl";
            this.subtaskLbl.Size = new System.Drawing.Size(138, 29);
            this.subtaskLbl.TabIndex = 7;
            this.subtaskLbl.Text = "Подзадача";
            // 
            // SubtaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(619, 355);
            this.Controls.Add(this.subtaskLbl);
            this.Controls.Add(this.stageName);
            this.Controls.Add(this.addSubtask);
            this.Controls.Add(this.backToTree);
            this.Controls.Add(this.subtaskDescTxt);
            this.Controls.Add(this.subtaskCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.projectNumLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SubtaskEditor";
            this.Text = "Редактор подзадач";
            this.Load += new System.EventHandler(this.SubtaskEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label projectNumLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox subtaskCombo;
        private System.Windows.Forms.TextBox subtaskDescTxt;
        private System.Windows.Forms.Button addSubtask;
        private System.Windows.Forms.Button backToTree;
        private System.Windows.Forms.Label stageName;
        private System.Windows.Forms.Label subtaskLbl;
    }
}