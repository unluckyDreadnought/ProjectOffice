
namespace ProjectOffice.forms
{
    partial class SubtaskList
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
            this.projectTree = new System.Windows.Forms.TreeView();
            this.backBtn = new System.Windows.Forms.Button();
            this.employeePanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.objAddCombo = new System.Windows.Forms.ToolStripComboBox();
            this.addBtn = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nodesDescLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.descLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rejectProject = new System.Windows.Forms.Button();
            this.employeePanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.nodesDescLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(736, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Этапы, подзадачи, контрольные точки";
            // 
            // projectTree
            // 
            this.projectTree.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTree.Location = new System.Drawing.Point(3, 3);
            this.projectTree.Name = "projectTree";
            this.projectTree.Size = new System.Drawing.Size(478, 234);
            this.projectTree.TabIndex = 1;
            this.projectTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projectTree_MouseClick);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(6, 348);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(178, 36);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "К проекту";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // employeePanel
            // 
            this.employeePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeePanel.BackColor = System.Drawing.Color.White;
            this.employeePanel.Controls.Add(this.toolStrip1);
            this.employeePanel.Location = new System.Drawing.Point(3, 284);
            this.employeePanel.Name = "employeePanel";
            this.employeePanel.Size = new System.Drawing.Size(742, 43);
            this.employeePanel.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objAddCombo,
            this.addBtn,
            this.editBtn,
            this.deleteBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(254, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(242, 40);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // objAddCombo
            // 
            this.objAddCombo.Items.AddRange(new object[] {
            "подзадачи",
            "контрольные точки"});
            this.objAddCombo.Name = "objAddCombo";
            this.objAddCombo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.objAddCombo.Size = new System.Drawing.Size(121, 40);
            // 
            // addBtn
            // 
            this.addBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtn.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtn.Name = "addBtn";
            this.addBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.addBtn.Size = new System.Drawing.Size(29, 37);
            this.addBtn.Text = "Добавить объект";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBtn.Name = "editBtn";
            this.editBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.editBtn.Size = new System.Drawing.Size(29, 37);
            this.editBtn.Text = "Изменить объект";
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.deleteBtn.Size = new System.Drawing.Size(29, 37);
            this.deleteBtn.Text = "Удалить объект";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nodesDescLayout);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 275);
            this.panel2.TabIndex = 4;
            // 
            // nodesDescLayout
            // 
            this.nodesDescLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodesDescLayout.ColumnCount = 2;
            this.nodesDescLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.nodesDescLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.nodesDescLayout.Controls.Add(this.projectTree, 0, 0);
            this.nodesDescLayout.Controls.Add(this.panel1, 1, 0);
            this.nodesDescLayout.Location = new System.Drawing.Point(-3, 32);
            this.nodesDescLayout.Name = "nodesDescLayout";
            this.nodesDescLayout.RowCount = 1;
            this.nodesDescLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.nodesDescLayout.Size = new System.Drawing.Size(745, 240);
            this.nodesDescLayout.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.descLbl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(487, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 234);
            this.panel1.TabIndex = 2;
            // 
            // descLbl
            // 
            this.descLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descLbl.Location = new System.Drawing.Point(0, 20);
            this.descLbl.Name = "descLbl";
            this.descLbl.Size = new System.Drawing.Size(253, 212);
            this.descLbl.TabIndex = 0;
            this.descLbl.Text = "label2";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Описание";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.employeePanel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 330);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // rejectProject
            // 
            this.rejectProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rejectProject.Location = new System.Drawing.Point(546, 349);
            this.rejectProject.Name = "rejectProject";
            this.rejectProject.Size = new System.Drawing.Size(196, 35);
            this.rejectProject.TabIndex = 6;
            this.rejectProject.Text = "Отклонить";
            this.rejectProject.UseVisualStyleBackColor = true;
            this.rejectProject.Click += new System.EventHandler(this.rejectProject_Click);
            // 
            // SubtaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(754, 396);
            this.Controls.Add(this.rejectProject);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.backBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SubtaskList";
            this.Text = "Список задач:";
            this.Load += new System.EventHandler(this.SubtaskList_Load);
            this.employeePanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.nodesDescLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView projectTree;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel employeePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addBtn;
        private System.Windows.Forms.ToolStripButton editBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripComboBox objAddCombo;
        private System.Windows.Forms.TableLayoutPanel nodesDescLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label descLbl;
        private System.Windows.Forms.Button rejectProject;
    }
}