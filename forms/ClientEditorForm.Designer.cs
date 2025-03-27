
namespace ProjectOffice.forms
{
    partial class ClientEditorForm
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
            this.closeOrgEditorBtn = new System.Windows.Forms.Button();
            this.saveOrganizationBtn = new System.Windows.Forms.Button();
            this.clientTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fizClientPhone = new System.Windows.Forms.MaskedTextBox();
            this.fizClientBankAcc = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.fizClientMail = new System.Windows.Forms.TextBox();
            this.fizClientBank = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.fizPhoto = new System.Windows.Forms.PictureBox();
            this.clientPatro = new System.Windows.Forms.TextBox();
            this.clientName = new System.Windows.Forms.TextBox();
            this.fizClientAddr = new System.Windows.Forms.TextBox();
            this.clientSurname = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.orgLogo = new System.Windows.Forms.PictureBox();
            this.orgInn = new System.Windows.Forms.MaskedTextBox();
            this.orgBik = new System.Windows.Forms.MaskedTextBox();
            this.orgOgrn = new System.Windows.Forms.MaskedTextBox();
            this.phoneTxt = new System.Windows.Forms.MaskedTextBox();
            this.orgBankAcc = new System.Windows.Forms.MaskedTextBox();
            this.orgKpp = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.orgType = new System.Windows.Forms.ComboBox();
            this.orgAddr = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.orgBank = new System.Windows.Forms.TextBox();
            this.orgName = new System.Windows.Forms.TextBox();
            this.clientTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fizPhoto)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // closeOrgEditorBtn
            // 
            this.closeOrgEditorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeOrgEditorBtn.Location = new System.Drawing.Point(12, 515);
            this.closeOrgEditorBtn.Name = "closeOrgEditorBtn";
            this.closeOrgEditorBtn.Size = new System.Drawing.Size(150, 40);
            this.closeOrgEditorBtn.TabIndex = 13;
            this.closeOrgEditorBtn.Text = "Закрыть";
            this.closeOrgEditorBtn.UseVisualStyleBackColor = true;
            this.closeOrgEditorBtn.Click += new System.EventHandler(this.closeOrgEditorBtn_Click);
            // 
            // saveOrganizationBtn
            // 
            this.saveOrganizationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveOrganizationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(143)))), ((int)(((byte)(252)))));
            this.saveOrganizationBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveOrganizationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveOrganizationBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.saveOrganizationBtn.Location = new System.Drawing.Point(486, 513);
            this.saveOrganizationBtn.Name = "saveOrganizationBtn";
            this.saveOrganizationBtn.Size = new System.Drawing.Size(175, 45);
            this.saveOrganizationBtn.TabIndex = 12;
            this.saveOrganizationBtn.Text = "Сохранить";
            this.saveOrganizationBtn.UseVisualStyleBackColor = false;
            this.saveOrganizationBtn.Click += new System.EventHandler(this.saveOrganizationBtn_Click);
            // 
            // clientTabs
            // 
            this.clientTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientTabs.Controls.Add(this.tabPage1);
            this.clientTabs.Controls.Add(this.tabPage2);
            this.clientTabs.Location = new System.Drawing.Point(1, 9);
            this.clientTabs.Name = "clientTabs";
            this.clientTabs.SelectedIndex = 0;
            this.clientTabs.Size = new System.Drawing.Size(674, 498);
            this.clientTabs.TabIndex = 33;
            this.clientTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.clientTabs_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fizClientPhone);
            this.tabPage1.Controls.Add(this.fizClientBankAcc);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.fizClientMail);
            this.tabPage1.Controls.Add(this.fizClientBank);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.fizPhoto);
            this.tabPage1.Controls.Add(this.clientPatro);
            this.tabPage1.Controls.Add(this.clientName);
            this.tabPage1.Controls.Add(this.fizClientAddr);
            this.tabPage1.Controls.Add(this.clientSurname);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(666, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Физическое лицо";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fizClientPhone
            // 
            this.fizClientPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fizClientPhone.Location = new System.Drawing.Point(418, 406);
            this.fizClientPhone.Mask = "+9 (999) 000 00 00";
            this.fizClientPhone.Name = "fizClientPhone";
            this.fizClientPhone.Size = new System.Drawing.Size(215, 34);
            this.fizClientPhone.TabIndex = 9;
            this.fizClientPhone.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // fizClientBankAcc
            // 
            this.fizClientBankAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fizClientBankAcc.Location = new System.Drawing.Point(382, 263);
            this.fizClientBankAcc.Mask = "99999999999999999999";
            this.fizClientBankAcc.Name = "fizClientBankAcc";
            this.fizClientBankAcc.Size = new System.Drawing.Size(274, 34);
            this.fizClientBankAcc.TabIndex = 5;
            this.fizClientBankAcc.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(13, 378);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 25);
            this.label14.TabIndex = 90;
            this.label14.Text = "*Почта";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(413, 378);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 25);
            this.label15.TabIndex = 89;
            this.label15.Text = "*Телефон";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(13, 310);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 25);
            this.label16.TabIndex = 88;
            this.label16.Text = "*Банк";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(377, 235);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(171, 25);
            this.label17.TabIndex = 87;
            this.label17.Text = "*Расчётный счёт";
            // 
            // fizClientMail
            // 
            this.fizClientMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fizClientMail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fizClientMail.Location = new System.Drawing.Point(18, 406);
            this.fizClientMail.MaxLength = 256;
            this.fizClientMail.Name = "fizClientMail";
            this.fizClientMail.Size = new System.Drawing.Size(377, 34);
            this.fizClientMail.TabIndex = 7;
            this.fizClientMail.TextChanged += new System.EventHandler(this.control_Changed);
            this.fizClientMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.email_KeyPress);
            // 
            // fizClientBank
            // 
            this.fizClientBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fizClientBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.fizClientBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.fizClientBank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fizClientBank.Location = new System.Drawing.Point(18, 338);
            this.fizClientBank.MaxLength = 256;
            this.fizClientBank.Name = "fizClientBank";
            this.fizClientBank.Size = new System.Drawing.Size(619, 34);
            this.fizClientBank.TabIndex = 6;
            this.fizClientBank.TextChanged += new System.EventHandler(this.control_Changed);
            this.fizClientBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orgName_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(13, 207);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 25);
            this.label20.TabIndex = 82;
            this.label20.Text = "*Адрес";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(159, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 25);
            this.label19.TabIndex = 82;
            this.label19.Text = "Отчество";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(159, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 25);
            this.label18.TabIndex = 82;
            this.label18.Text = "*Имя";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(159, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 25);
            this.label11.TabIndex = 82;
            this.label11.Text = "*Фамилия";
            // 
            // fizPhoto
            // 
            this.fizPhoto.Image = global::ProjectOffice.Properties.Resources.PLUG_PICTURE;
            this.fizPhoto.Location = new System.Drawing.Point(24, 40);
            this.fizPhoto.Name = "fizPhoto";
            this.fizPhoto.Size = new System.Drawing.Size(115, 110);
            this.fizPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fizPhoto.TabIndex = 81;
            this.fizPhoto.TabStop = false;
            // 
            // clientPatro
            // 
            this.clientPatro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientPatro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientPatro.Location = new System.Drawing.Point(164, 174);
            this.clientPatro.Name = "clientPatro";
            this.clientPatro.Size = new System.Drawing.Size(476, 34);
            this.clientPatro.TabIndex = 3;
            this.clientPatro.TextChanged += new System.EventHandler(this.control_Changed);
            this.clientPatro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clientSurname_KeyPress);
            // 
            // clientName
            // 
            this.clientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientName.Location = new System.Drawing.Point(164, 107);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(476, 34);
            this.clientName.TabIndex = 2;
            this.clientName.TextChanged += new System.EventHandler(this.control_Changed);
            this.clientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clientSurname_KeyPress);
            // 
            // fizClientAddr
            // 
            this.fizClientAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fizClientAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fizClientAddr.Location = new System.Drawing.Point(18, 235);
            this.fizClientAddr.Multiline = true;
            this.fizClientAddr.Name = "fizClientAddr";
            this.fizClientAddr.Size = new System.Drawing.Size(342, 72);
            this.fizClientAddr.TabIndex = 4;
            this.fizClientAddr.TextChanged += new System.EventHandler(this.control_Changed);
            this.fizClientAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orgAddress_KeyPress);
            // 
            // clientSurname
            // 
            this.clientSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientSurname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clientSurname.Location = new System.Drawing.Point(164, 41);
            this.clientSurname.Name = "clientSurname";
            this.clientSurname.Size = new System.Drawing.Size(476, 34);
            this.clientSurname.TabIndex = 1;
            this.clientSurname.TextChanged += new System.EventHandler(this.control_Changed);
            this.clientSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clientSurname_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.orgLogo);
            this.tabPage2.Controls.Add(this.orgInn);
            this.tabPage2.Controls.Add(this.orgBik);
            this.tabPage2.Controls.Add(this.orgOgrn);
            this.tabPage2.Controls.Add(this.phoneTxt);
            this.tabPage2.Controls.Add(this.orgBankAcc);
            this.tabPage2.Controls.Add(this.orgKpp);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.orgType);
            this.tabPage2.Controls.Add(this.orgAddr);
            this.tabPage2.Controls.Add(this.emailTxt);
            this.tabPage2.Controls.Add(this.orgBank);
            this.tabPage2.Controls.Add(this.orgName);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(666, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Юридическое лицо";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // orgLogo
            // 
            this.orgLogo.Image = global::ProjectOffice.Properties.Resources.PLUG_PICTURE;
            this.orgLogo.Location = new System.Drawing.Point(26, 39);
            this.orgLogo.Name = "orgLogo";
            this.orgLogo.Size = new System.Drawing.Size(115, 110);
            this.orgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.orgLogo.TabIndex = 80;
            this.orgLogo.TabStop = false;
            this.orgLogo.Click += new System.EventHandler(this.orgLogo_Click);
            // 
            // orgInn
            // 
            this.orgInn.Location = new System.Drawing.Point(26, 207);
            this.orgInn.Mask = "9999999999";
            this.orgInn.Name = "orgInn";
            this.orgInn.Size = new System.Drawing.Size(145, 34);
            this.orgInn.TabIndex = 59;
            this.orgInn.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgBik
            // 
            this.orgBik.Location = new System.Drawing.Point(345, 207);
            this.orgBik.Mask = "999999999";
            this.orgBik.Name = "orgBik";
            this.orgBik.Size = new System.Drawing.Size(129, 34);
            this.orgBik.TabIndex = 61;
            this.orgBik.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgOgrn
            // 
            this.orgOgrn.Location = new System.Drawing.Point(26, 278);
            this.orgOgrn.Mask = "9999999999999";
            this.orgOgrn.Name = "orgOgrn";
            this.orgOgrn.Size = new System.Drawing.Size(178, 34);
            this.orgOgrn.TabIndex = 63;
            this.orgOgrn.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // phoneTxt
            // 
            this.phoneTxt.Location = new System.Drawing.Point(426, 412);
            this.phoneTxt.Mask = "+9 (999) 000 00 00";
            this.phoneTxt.Name = "phoneTxt";
            this.phoneTxt.Size = new System.Drawing.Size(215, 34);
            this.phoneTxt.TabIndex = 67;
            this.phoneTxt.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgBankAcc
            // 
            this.orgBankAcc.Location = new System.Drawing.Point(368, 278);
            this.orgBankAcc.Mask = "99999999999999999999";
            this.orgBankAcc.Name = "orgBankAcc";
            this.orgBankAcc.Size = new System.Drawing.Size(274, 34);
            this.orgBankAcc.TabIndex = 64;
            this.orgBankAcc.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgKpp
            // 
            this.orgKpp.Location = new System.Drawing.Point(186, 207);
            this.orgKpp.Mask = "999999999";
            this.orgKpp.Name = "orgKpp";
            this.orgKpp.Size = new System.Drawing.Size(129, 34);
            this.orgKpp.TabIndex = 60;
            this.orgKpp.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(21, 384);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 25);
            this.label13.TabIndex = 77;
            this.label13.Text = "*Почта";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(421, 384);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 25);
            this.label12.TabIndex = 76;
            this.label12.Text = "*Телефон";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(338, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 25);
            this.label9.TabIndex = 75;
            this.label9.Text = "*БИК";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(21, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 25);
            this.label8.TabIndex = 74;
            this.label8.Text = "*Банк";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(363, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 25);
            this.label6.TabIndex = 73;
            this.label6.Text = "*Расчётный счёт";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 25);
            this.label5.TabIndex = 72;
            this.label5.Text = "*ОГРН";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(181, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 25);
            this.label7.TabIndex = 70;
            this.label7.Text = "*КПП";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 71;
            this.label4.Text = "*ИНН";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(164, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 69;
            this.label3.Text = "*Адрес";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(32, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 25);
            this.label10.TabIndex = 79;
            this.label10.Text = "Логотип";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(161, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 78;
            this.label2.Text = "*Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(495, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 68;
            this.label1.Text = "*Форма";
            // 
            // orgType
            // 
            this.orgType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.orgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orgType.FormattingEnabled = true;
            this.orgType.Items.AddRange(new object[] {
            "ООО",
            "ОАО",
            "ПАО",
            "ЗАО",
            "АО"});
            this.orgType.Location = new System.Drawing.Point(500, 207);
            this.orgType.Name = "orgType";
            this.orgType.Size = new System.Drawing.Size(142, 37);
            this.orgType.TabIndex = 62;
            this.orgType.SelectedIndexChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgAddr
            // 
            this.orgAddr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.orgAddr.Location = new System.Drawing.Point(166, 104);
            this.orgAddr.MaxLength = 256;
            this.orgAddr.Multiline = true;
            this.orgAddr.Name = "orgAddr";
            this.orgAddr.Size = new System.Drawing.Size(476, 66);
            this.orgAddr.TabIndex = 58;
            this.orgAddr.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // emailTxt
            // 
            this.emailTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.emailTxt.Location = new System.Drawing.Point(26, 412);
            this.emailTxt.MaxLength = 256;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(377, 34);
            this.emailTxt.TabIndex = 66;
            this.emailTxt.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgBank
            // 
            this.orgBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.orgBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.orgBank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.orgBank.Location = new System.Drawing.Point(26, 344);
            this.orgBank.MaxLength = 256;
            this.orgBank.Name = "orgBank";
            this.orgBank.Size = new System.Drawing.Size(619, 34);
            this.orgBank.TabIndex = 65;
            this.orgBank.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // orgName
            // 
            this.orgName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.orgName.Location = new System.Drawing.Point(166, 39);
            this.orgName.MaxLength = 256;
            this.orgName.Name = "orgName";
            this.orgName.Size = new System.Drawing.Size(476, 34);
            this.orgName.TabIndex = 57;
            this.orgName.TextChanged += new System.EventHandler(this.control_Changed);
            // 
            // ClientEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(673, 562);
            this.Controls.Add(this.clientTabs);
            this.Controls.Add(this.closeOrgEditorBtn);
            this.Controls.Add(this.saveOrganizationBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ClientEditorForm";
            this.Text = "OrganizationClientEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrganizationClientEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.OrganizationClientEditorForm_Load);
            this.clientTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fizPhoto)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orgLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeOrgEditorBtn;
        private System.Windows.Forms.Button saveOrganizationBtn;
        private System.Windows.Forms.TabControl clientTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox orgLogo;
        private System.Windows.Forms.MaskedTextBox orgInn;
        private System.Windows.Forms.MaskedTextBox orgBik;
        private System.Windows.Forms.MaskedTextBox orgOgrn;
        private System.Windows.Forms.MaskedTextBox phoneTxt;
        private System.Windows.Forms.MaskedTextBox orgBankAcc;
        private System.Windows.Forms.MaskedTextBox orgKpp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox orgType;
        private System.Windows.Forms.TextBox orgAddr;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox orgBank;
        private System.Windows.Forms.TextBox orgName;
        private System.Windows.Forms.MaskedTextBox fizClientPhone;
        private System.Windows.Forms.MaskedTextBox fizClientBankAcc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox fizClientMail;
        private System.Windows.Forms.TextBox fizClientBank;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox fizPhoto;
        private System.Windows.Forms.TextBox clientPatro;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.TextBox clientSurname;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox fizClientAddr;
    }
}