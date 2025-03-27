
namespace ProjectOffice.forms
{
    partial class ClientsForm
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
            this.userModelbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clientsTable = new System.Windows.Forms.DataGridView();
            this.clientIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.clientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innKpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ogrn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rshet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addClientBtn = new System.Windows.Forms.ToolStripButton();
            this.editClientBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteClientBtn = new System.Windows.Forms.ToolStripButton();
            this.backToMenuBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.440357F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.464167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 569);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.userSnpLbl);
            this.panel1.Controls.Add(this.userModelbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 47);
            this.panel1.TabIndex = 0;
            // 
            // userSnpLbl
            // 
            this.userSnpLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userSnpLbl.AutoSize = true;
            this.userSnpLbl.Location = new System.Drawing.Point(482, 6);
            this.userSnpLbl.Name = "userSnpLbl";
            this.userSnpLbl.Size = new System.Drawing.Size(79, 29);
            this.userSnpLbl.TabIndex = 0;
            this.userSnpLbl.Text = "label1";
            // 
            // userModelbl
            // 
            this.userModelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userModelbl.AutoSize = true;
            this.userModelbl.Location = new System.Drawing.Point(650, 6);
            this.userModelbl.Name = "userModelbl";
            this.userModelbl.Size = new System.Drawing.Size(79, 29);
            this.userModelbl.TabIndex = 0;
            this.userModelbl.Text = "label1";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.clientsTable);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 56);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(805, 454);
            this.panel2.TabIndex = 1;
            // 
            // clientsTable
            // 
            this.clientsTable.AllowUserToAddRows = false;
            this.clientsTable.AllowUserToDeleteRows = false;
            this.clientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.clientsTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clientsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.clientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientIdCol,
            this.clientImgCol,
            this.clientName,
            this.clientPhone,
            this.clientEmail});
            this.clientsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.clientsTable.EnableHeadersVisualStyles = false;
            this.clientsTable.Location = new System.Drawing.Point(0, 0);
            this.clientsTable.Name = "clientsTable";
            this.clientsTable.RowHeadersVisible = false;
            this.clientsTable.RowHeadersWidth = 51;
            this.clientsTable.RowTemplate.Height = 24;
            this.clientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientsTable.Size = new System.Drawing.Size(805, 410);
            this.clientsTable.TabIndex = 6;
            this.clientsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsTable_CellClick);
            // 
            // clientIdCol
            // 
            this.clientIdCol.HeaderText = "id";
            this.clientIdCol.MinimumWidth = 6;
            this.clientIdCol.Name = "clientIdCol";
            this.clientIdCol.Visible = false;
            // 
            // clientImgCol
            // 
            this.clientImgCol.FillWeight = 3F;
            this.clientImgCol.HeaderText = "";
            this.clientImgCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.clientImgCol.MinimumWidth = 6;
            this.clientImgCol.Name = "clientImgCol";
            // 
            // clientName
            // 
            this.clientName.FillWeight = 50F;
            this.clientName.HeaderText = "Имя";
            this.clientName.MinimumWidth = 6;
            this.clientName.Name = "clientName";
            // 
            // clientPhone
            // 
            this.clientPhone.FillWeight = 20F;
            this.clientPhone.HeaderText = "Телефон";
            this.clientPhone.MinimumWidth = 6;
            this.clientPhone.Name = "clientPhone";
            // 
            // clientEmail
            // 
            this.clientEmail.FillWeight = 20F;
            this.clientEmail.HeaderText = "Почта";
            this.clientEmail.MinimumWidth = 6;
            this.clientEmail.Name = "clientEmail";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.name,
            this.address,
            this.innKpp,
            this.ogrn,
            this.rshet,
            this.bankName,
            this.bik,
            this.okved,
            this.phone,
            this.email});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(805, 410);
            this.dataGridView1.TabIndex = 5;
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            // 
            // address
            // 
            this.address.HeaderText = "Адрес";
            this.address.MinimumWidth = 6;
            this.address.Name = "address";
            // 
            // innKpp
            // 
            this.innKpp.HeaderText = "(Серия|ИНН)/(Номер|КПП)";
            this.innKpp.MinimumWidth = 6;
            this.innKpp.Name = "innKpp";
            // 
            // ogrn
            // 
            this.ogrn.HeaderText = "ОГРН";
            this.ogrn.MinimumWidth = 6;
            this.ogrn.Name = "ogrn";
            // 
            // rshet
            // 
            this.rshet.HeaderText = "Р/с";
            this.rshet.MinimumWidth = 6;
            this.rshet.Name = "rshet";
            // 
            // bankName
            // 
            this.bankName.HeaderText = "Банк";
            this.bankName.MinimumWidth = 6;
            this.bankName.Name = "bankName";
            // 
            // bik
            // 
            this.bik.HeaderText = "БИК";
            this.bik.MinimumWidth = 6;
            this.bik.Name = "bik";
            // 
            // okved
            // 
            this.okved.HeaderText = "ОКВЭД";
            this.okved.MinimumWidth = 6;
            this.okved.Name = "okved";
            // 
            // phone
            // 
            this.phone.HeaderText = "Телефон";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            // 
            // email
            // 
            this.email.HeaderText = "Почта";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 410);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 44);
            this.panel3.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientBtn,
            this.editClientBtn,
            this.deleteClientBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(329, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(129, 27);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addClientBtn
            // 
            this.addClientBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addClientBtn.Image = global::ProjectOffice.Properties.Resources.ADD_BTN_PICTURE;
            this.addClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Size = new System.Drawing.Size(29, 24);
            this.addClientBtn.Text = "Добавить";
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // editClientBtn
            // 
            this.editClientBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editClientBtn.Image = global::ProjectOffice.Properties.Resources.EDIT_BTN_PICTURE;
            this.editClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editClientBtn.Name = "editClientBtn";
            this.editClientBtn.Size = new System.Drawing.Size(29, 24);
            this.editClientBtn.Text = "Удалить";
            this.editClientBtn.Click += new System.EventHandler(this.editClientBtn_Click);
            // 
            // deleteClientBtn
            // 
            this.deleteClientBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteClientBtn.Image = global::ProjectOffice.Properties.Resources.BASKET_BTN_PICTURE;
            this.deleteClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteClientBtn.Name = "deleteClientBtn";
            this.deleteClientBtn.Size = new System.Drawing.Size(29, 24);
            this.deleteClientBtn.Text = "Редактировать";
            this.deleteClientBtn.Click += new System.EventHandler(this.deleteClientBtn_Click);
            // 
            // backToMenuBtn
            // 
            this.backToMenuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenuBtn.Location = new System.Drawing.Point(3, 516);
            this.backToMenuBtn.Name = "backToMenuBtn";
            this.backToMenuBtn.Size = new System.Drawing.Size(150, 38);
            this.backToMenuBtn.TabIndex = 2;
            this.backToMenuBtn.Text = "Меню";
            this.backToMenuBtn.UseVisualStyleBackColor = true;
            this.backToMenuBtn.Click += new System.EventHandler(this.backToMenuBtn_Click);
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ClientsForm";
            this.Text = "ClientsForm";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userSnpLbl;
        private System.Windows.Forms.Label userModelbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView clientsTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn innKpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ogrn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rshet;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bik;
        private System.Windows.Forms.DataGridViewTextBoxColumn okved;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addClientBtn;
        private System.Windows.Forms.ToolStripButton editClientBtn;
        private System.Windows.Forms.ToolStripButton deleteClientBtn;
        private System.Windows.Forms.Button backToMenuBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdCol;
        private System.Windows.Forms.DataGridViewImageColumn clientImgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientEmail;
    }
}