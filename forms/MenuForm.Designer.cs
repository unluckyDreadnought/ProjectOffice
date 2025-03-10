
namespace ProjectOffice.forms
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userDataPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usrSnpLbl = new System.Windows.Forms.Label();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.splashPicture = new System.Windows.Forms.PictureBox();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.userModeTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.userDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splashPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.userDataPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picturePanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonsPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 505);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // userDataPanel
            // 
            this.userDataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.userDataPanel.Controls.Add(this.pictureBox1);
            this.userDataPanel.Controls.Add(this.usrSnpLbl);
            this.userDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDataPanel.Location = new System.Drawing.Point(399, 3);
            this.userDataPanel.Name = "userDataPanel";
            this.userDataPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userDataPanel.Size = new System.Drawing.Size(391, 100);
            this.userDataPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ProjectOffice.Properties.Resources.USR_PLUG_PICTURE;
            this.pictureBox1.Location = new System.Drawing.Point(349, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // usrSnpLbl
            // 
            this.usrSnpLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrSnpLbl.Location = new System.Drawing.Point(5, 6);
            this.usrSnpLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.usrSnpLbl.Name = "usrSnpLbl";
            this.usrSnpLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usrSnpLbl.Size = new System.Drawing.Size(336, 37);
            this.usrSnpLbl.TabIndex = 3;
            this.usrSnpLbl.Text = "Фамилия И.О.";
            // 
            // picturePanel
            // 
            this.picturePanel.BackColor = System.Drawing.Color.White;
            this.picturePanel.Controls.Add(this.splashPicture);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel.Location = new System.Drawing.Point(399, 109);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(391, 393);
            this.picturePanel.TabIndex = 0;
            // 
            // splashPicture
            // 
            this.splashPicture.Image = global::ProjectOffice.Properties.Resources.PLUG_PICTURE;
            this.splashPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("splashPicture.InitialImage")));
            this.splashPicture.Location = new System.Drawing.Point(-3, 21);
            this.splashPicture.Name = "splashPicture";
            this.splashPicture.Size = new System.Drawing.Size(396, 351);
            this.splashPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.splashPicture.TabIndex = 4;
            this.splashPicture.TabStop = false;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 3);
            this.buttonsPanel.Name = "buttonsPanel";
            this.tableLayoutPanel1.SetRowSpan(this.buttonsPanel, 2);
            this.buttonsPanel.Size = new System.Drawing.Size(390, 499);
            this.buttonsPanel.TabIndex = 0;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 505);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.userDataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splashPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel userDataPanel;
        private System.Windows.Forms.Label usrSnpLbl;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox splashPicture;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip userModeTip;
    }
}