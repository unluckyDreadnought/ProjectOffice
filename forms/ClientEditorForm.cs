using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.Properties;
using ProjectOffice.logic;
using ProjectOffice.logic.app;

namespace ProjectOffice.forms
{
    public partial class ClientEditorForm : Form
    {
        object[] storedOrgInfo = null;
        Db _db = new Db();
        string editId = "";
        MemoryStream imgStream = null;
        Regex regexEmail = new Regex(Symbols.emailPattern);
        bool organization = false;
        string obj = null;

        private ClientEditorForm(string id = "", object[] clientInfo = null, bool org = true)
        {
            InitializeComponent();
            editId = id;
            organization = org;
            if (editId != "")
            {
                storedOrgInfo = clientInfo;
                PasteClientInformation();
            }
            SelectTab(organization);
        }

        private void HideNotEditTab(bool isOrganization)
        {
            int tabIndx = isOrganization ? 0 : 1;
            clientTabs.TabPages[tabIndx].Text = "";
            ((Control)clientTabs.TabPages[tabIndx]).Enabled = false;
        }

        private void SelectTab(bool isOrganization)
        {
            int tabIndx = isOrganization ? 1 : 0;
            clientTabs.SelectTab(tabIndx);
        }

        private string GetPhoneText(string initial)
        {
            return initial.Replace("+", "").Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        private void CheckFieldsFilling()
        {
            bool filled = true;
            string phone = "";

            if (organization)
            {
                phone = GetPhoneText(phoneTxt.Text);
                if (editId != "")
                {
                    filled = false || orgType.SelectedItem.ToString() != storedOrgInfo[0].ToString();
                    filled = filled || orgName.Text != storedOrgInfo[1].ToString();
                    filled = filled || orgAddr.Text != storedOrgInfo[2].ToString();
                    filled = filled || orgBankAcc.Text != storedOrgInfo[3].ToString();
                    filled = filled || orgBank.Text != storedOrgInfo[4].ToString();
                    filled = filled || phone != storedOrgInfo[5].ToString();
                    filled = filled || emailTxt.Text != storedOrgInfo[6].ToString();
                    filled = filled || orgInn.Text != storedOrgInfo[7].ToString();
                    filled = filled || orgKpp.Text != storedOrgInfo[8].ToString();
                    filled = filled || orgOgrn.Text != storedOrgInfo[9].ToString();
                    filled = filled || orgBik.Text != storedOrgInfo[10].ToString();
                    if (editId == "0") filled = filled || director.Text.Trim().Length > 0;
                    if (imgStream != null && storedOrgInfo[11] == DBNull.Value)
                    {
                        filled = true;
                    }
                    else if (imgStream != null && storedOrgInfo[11] != DBNull.Value)
                    {
                        filled = filled || Common.IsImageBytesDifference(imgStream.ToArray(), logic.Сompressor.DecompressBytes((byte[])storedOrgInfo[11]));
                    }
                }

                filled = filled && orgType.SelectedItem != null;
                filled = filled && orgName.Text.Trim().Length > 0;
                filled = filled && orgAddr.Text.Trim().Length > 0;
                filled = filled && (orgBankAcc.Text.Trim().Length == 20 && orgBankAcc.Text.Trim()[0] != '0');
                filled = filled && orgBank.Text.Trim().Length > 0;
                filled = filled && (phone.Length == 11 && phone[0] != '0');
                filled = filled && regexEmail.Match(emailTxt.Text.Trim()).Success;
                filled = filled && (orgInn.Text.Trim().Length == 10 && orgInn.Text.Trim()[0] != '0');
                filled = filled && (orgKpp.Text.Trim().Length == 9 && orgKpp.Text.Trim()[0] != '0');
                filled = filled && (orgOgrn.Text.Trim().Length == 13 && orgOgrn.Text.Trim()[0] != '0'); ;
                filled = filled && (orgBik.Text.Trim().Length == 9 && orgBik.Text.Trim()[0] != '0'); ;
            }
            else
            {
                phone = GetPhoneText(fizClientPhone.Text);
                string patronymic = clientPatro.Text != null && clientPatro.Text != "" ? clientPatro.Text : "";
                if (editId != "")
                {
                    filled = false || $"{clientName.Text.Trim()} {clientSurname.Text.Trim()} {patronymic}".Trim() != storedOrgInfo[0].ToString();
                    filled = filled || fizClientAddr.Text.Trim() != storedOrgInfo[1].ToString();
                    filled = filled || fizClientBankAcc.Text != storedOrgInfo[2].ToString();
                    filled = filled || fizClientBank.Text != storedOrgInfo[3].ToString();
                    filled = filled || GetPhoneText(fizClientPhone.Text) != storedOrgInfo[4].ToString();
                    filled = filled || fizClientMail.Text != storedOrgInfo[5].ToString();
                    filled = filled || fizClientAddr.Text.Trim() != storedOrgInfo[1].ToString();
                    if (imgStream != null && storedOrgInfo[6] == DBNull.Value)
                    {
                        filled = true;
                    }
                    else if (imgStream != null && storedOrgInfo[6] != DBNull.Value)
                    {
                        filled = filled || Common.IsImageBytesDifference(imgStream.ToArray(), logic.Сompressor.DecompressBytes((byte[])storedOrgInfo[6]));
                    }
                }

                filled = filled && $"{clientName.Text.Trim()} {clientSurname.Text.Trim()} {patronymic}".Trim().Length > 0;
                filled = filled && fizClientAddr.Text.Trim().Length > 0;
                filled = filled && fizClientBankAcc.Text.Trim().Length == 20;
                filled = filled && fizClientBank.Text.Length > 0;
                filled = filled && GetPhoneText(fizClientPhone.Text).Trim().Length == 11;
                filled = filled && regexEmail.Match(fizClientMail.Text).Success; 
                filled = filled && fizClientAddr.Text.Trim().Length > 0;
            }

            saveOrganizationBtn.Enabled = filled;
        }

        private void PasteClientInformation()
        {
            if (storedOrgInfo == null || storedOrgInfo.Length == 0) return;
            if (organization)
            {
                orgType.SelectedItem = storedOrgInfo[0];
                orgName.Text = storedOrgInfo[1].ToString();
                orgAddr.Text = storedOrgInfo[2].ToString();
                orgBankAcc.Text = storedOrgInfo[3].ToString();
                orgBank.Text = storedOrgInfo[4].ToString();
                phoneTxt.Text = storedOrgInfo[5].ToString();
                emailTxt.Text = storedOrgInfo[6].ToString();
                orgInn.Text = storedOrgInfo[7].ToString();
                orgKpp.Text = storedOrgInfo[8].ToString();
                orgOgrn.Text = storedOrgInfo[9].ToString();
                orgBik.Text = storedOrgInfo[10].ToString();
                if (editId == "0") director.Text = AppSettings.director;
                if (storedOrgInfo[11] != DBNull.Value)
                {
                    using (var ms = new MemoryStream(logic.Сompressor.DecompressBytes((byte[])storedOrgInfo[11])))
                    {
                        if (imgStream == null) imgStream = new MemoryStream();
                        ms.CopyTo(imgStream);
                    }
                }
                orgLogo.Image = (imgStream != null) ? new Bitmap(imgStream) : Resources.PLUG_PICTURE;
            }
            else
            {
                string[] nameParts = storedOrgInfo[0].ToString().Split(' ');
                clientName.Text = nameParts[0];
                clientSurname.Text = nameParts[1];
                clientPatro.Text = (nameParts.Length > 2) ? nameParts[2] : null;
                fizClientAddr.Text = storedOrgInfo[1].ToString();
                fizClientBankAcc.Text = storedOrgInfo[2].ToString();
                fizClientBank.Text = storedOrgInfo[3].ToString();
                fizClientMail.Text = storedOrgInfo[5].ToString();
                fizClientPhone.Text = (storedOrgInfo[4] != DBNull.Value) ? storedOrgInfo[4].ToString() : null;
                if (storedOrgInfo[6] != DBNull.Value)
                {
                    using (var ms = new MemoryStream(logic.Сompressor.DecompressBytes((byte[])storedOrgInfo[6])))
                    {
                        ms.CopyTo(imgStream);
                    }
                }
                fizPhoto.Image = (imgStream != null) ? new Bitmap(imgStream) : Resources.USR_PLUG_PICTURE;
            }
        }

        private async Task<object[]> GetClientInfo(string id)
        {
            object[] res = null;
            if (organization) res = await Common.GetOrgClientInfo(id);
            else res = await Common.GetPersonClientInfo(id);
            return res;
        }

        public static async Task<ClientEditorForm> OpenPersonEditor(string id = "")
        {
            Db db = new Db();
            if (id == "" || id == null) return new ClientEditorForm(org: false);
            object[] clientInfo = await Common.GetPersonClientInfo(id);
            if (clientInfo.Length == 0) clientInfo = null;
            return new ClientEditorForm(id, clientInfo, org: false);
        }

        public static async Task<ClientEditorForm> OpenOrganizationEditor(string id = "")
        {
            Db db = new Db();
            if (id == "" || id == null) return new ClientEditorForm(org: true);
            object[] clientInfo = await Common.GetOrgClientInfo(id);
            if (clientInfo.Length == 0)
            {
                if (id == "0")
                {
                    string query = $@"SET SESSION sql_mode='NO_AUTO_VALUE_ON_ZERO';
insert into client value (0, 2, 'ООО', '', '', '', '', null, null, null, null, null, null, null)";
                    (object n, _) = await Common.GetNoScalarResult(db.GetAsynNonReaderResult(db.ExecuteNoDataResultAsync(query)));
                    if (Convert.ToInt32(n) > 0) MessageBox.Show("Подготовка редактора Вашей организации завершена успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clientInfo = await Common.GetOrgClientInfo(id);
                }
                else clientInfo = null;
            }
            return new ClientEditorForm(id, clientInfo, org: true);
        }

        private async Task<string[]> GetStoredBanks()
        {
            string query = $"select distinct ClientBank from {Db.Name}.`client`;";
            string[] banks = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            return banks.Where(bank => bank.Trim().Length > 0).ToArray();
        }

        private async void OrganizationClientEditorForm_Load(object sender, EventArgs e)
        {
            obj = organization ? "организации" : "физического лица";
            if (editId != "")
            {
                directorLbl.Visible = editId == "0";
                director.Visible = director.Enabled = directorLbl.Visible;

                this.Text = $"{Resources.APP_NAME}: Редактирование {obj}";
                HideNotEditTab(organization);
            }
            else this.Text = $"{Resources.APP_NAME}: Создание {obj}";
            SelectTab(organization);

            this.Icon = Resources.PROJECT_OFFICE_ICON;
            if (editId != "" && editId != null)
            {
                if (storedOrgInfo == null) storedOrgInfo = await GetClientInfo(editId);
            }
            fizClientBank.AutoCompleteMode = orgBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            fizClientBank.AutoCompleteSource = orgBank.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string[] banks = await GetStoredBanks();
            orgBank.AutoCompleteCustomSource.AddRange(banks);
            fizClientBank.AutoCompleteCustomSource.AddRange(banks);
            CheckFieldsFilling();
        }

        private void orgLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDialog.CheckFileExists = fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() != DialogResult.OK) return;

            byte[] newImg = Сompressor.CompressImageToBytes(fileDialog.FileName);
            if (imgStream == null)
            {
                imgStream = new MemoryStream(newImg);
            }
            else
            {
                if (Common.IsImageBytesDifference(newImg, imgStream.ToArray())) 
                {
                    imgStream = new MemoryStream(newImg);
                }
            }
            orgLogo.Image = new Bitmap(imgStream);
            CheckFieldsFilling();
        }

        private void control_Changed(object sender, EventArgs e)
        {
            CheckFieldsFilling();
        }

        private void orgName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("\"".Concat(Symbols.ru_alp).Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == (int)Keys.Space
                || e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back || Char.IsDigit(e.KeyChar))
            {
                return;
            }
            else e.Handled = true;
        }

        private void orgAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (".,".Concat(Symbols.ru_alp).Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == (int)Keys.Space
                || e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back || Char.IsDigit(e.KeyChar))
            {
                return;
            }
            else e.Handled = true;
        }

        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (".@_-".Concat(Symbols.en_alp).Contains(Char.ToLower(e.KeyChar)) ||
                e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back || Char.IsDigit(e.KeyChar))
            {
                return;
            }
            else e.Handled = true;
        }

        private void OrganizationClientEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (imgStream != null) imgStream.Close();
        }

        private async Task<object> AddOrganization(string phn)
        {
            object n = null;
            string query = $@"set session sql_mode='NO_AUTO_VALUE_ON_ZERO';
insert into {Db.Name}.client value 
(null, 2, '{orgType.SelectedItem.ToString()}', '{orgName.Text.Trim()}', '{orgAddr.Text.Trim()}', '{orgBankAcc.Text.Trim()}', '{orgBank.Text.Trim()}', 
'{phn}', @email, '{orgInn.Text.Trim()}', '{orgKpp.Text.Trim()}', '{orgOgrn.Text.Trim()}', '{orgBik.Text.Trim()}',";
            if (imgStream != null)
            {
                query += " @photo);";
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, emailTxt.Text.Trim(), logic.Сompressor.CompressBytes(imgStream.ToArray()))));
            }
            else
            {
                query += " null);";
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, emailTxt.Text.Trim())));
            }
            return n;
        }

        private async Task<object> AddPerson(string phn)
        {
            object n = null;
            string name = $"{clientName.Text.Trim()} {clientSurname.Text.Trim()} {clientPatro.Text.Trim()}".Trim();
            string query = $@"insert into {Db.Name}.client value 
(null, 1, null, '{name}', '{fizClientAddr.Text.Trim()}', '{fizClientBankAcc.Text.Trim()}', '{fizClientBank.Text.Trim()}', 
'{phn}', @email, null, null, null, null, ";
            if (imgStream != null)
            {
                query += " @photo);";
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, fizClientMail.Text.Trim(), logic.Сompressor.CompressBytes(imgStream.ToArray()))));
            }
            else
            {
                query += " null);";
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, fizClientMail.Text.Trim())));
            }
            return n;
        }

        private async Task<object> UpdateOrganization(string phn)
        {
            object n = null;
            if (editId == "0")
            {
                AppSettings.director = director.Text.Trim();
                AppSettings.SaveModified();
            }
            string query = $@"update {Db.Name}.`client` set
ClientOrgTypeId = '{orgType.SelectedItem.ToString()}', ClientName = '{orgName.Text.Trim()}', ClientAddress = '{orgAddr.Text.Trim()}', ClientBankAccount = '{orgBankAcc.Text.Trim()}',
ClientBank = '{orgBank.Text.Trim()}', ClientPhone = '{phn}', ClientEmail = @mail, ClientOrgINN = '{orgInn.Text.Trim()}',
ClientOrgKPP = '{orgKpp.Text.Trim()}', ClientOrgOGRN = '{orgOgrn.Text.Trim()}', ClientOrgBIK = '{orgBik.Text.Trim()}', ClientPhoto = ";
            if (imgStream != null)
            {
                query += " @photo ";
            }
            else
            {
                query += " null ";
            }
            query += $"where ClientID = {editId};";
            if (imgStream != null)
            {
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, emailTxt.Text.Trim(), logic.Сompressor.CompressBytes(imgStream.ToArray()))));
            }
            else (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, emailTxt.Text.Trim())));
            return n;
        }

        private async Task<object> UpdatePerson(string phn)
        {
            object n = null;
            string name = $"{clientName.Text.Trim()} {clientSurname.Text.Trim()} {clientPatro.Text.Trim()}".Trim();
            string query = $@"update {Db.Name}.`client` set
ClientName = '{name}', ClientAddress = '{fizClientAddr.Text.Trim()}', ClientBankAccount = '{fizClientBankAcc.Text.Trim()}',
ClientBank = '{fizClientBank.Text.Trim()}', ClientPhone = '{phn}', ClientEmail = @mail, ClientPhoto = ";
            if (imgStream != null)
            {
                query += " @photo ";
            }
            else
            {
                query += " null ";
            }
            query += $"where ClientID = {editId};";
            if (imgStream != null)
            {
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, emailTxt.Text.Trim(), logic.Сompressor.CompressBytes(imgStream.ToArray()))));
            }
            else (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query, emailTxt.Text.Trim())));
            return n;
        }

        private async void saveOrganizationBtn_Click(object sender, EventArgs e)
        {
            object n = null;
            if (organization && clientTabs.SelectedIndex == 1)
            {
                if (editId == "" || editId == null) 
                {
                    n = await AddOrganization(GetPhoneText(phoneTxt.Text));
                    if (Convert.ToInt32(n) > 0)
                    {
                        await _db.LogToEventJournal(EventJournal.EventType.CreateObject, this);
                        MessageBox.Show("Организиция успешно добавлена.", "Добавление клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    n = await UpdateOrganization(GetPhoneText(phoneTxt.Text));
                    if (Convert.ToInt32(n) > 0)
                    {
                        await _db.LogToEventJournal(EventJournal.EventType.ChangeObject, this);
                        MessageBox.Show("Организиция успешно изменена.", "Изменение клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else if (!organization && clientTabs.SelectedIndex == 0)
            {
                if (editId == "" || editId == null)
                {
                    n = await AddPerson(GetPhoneText(fizClientPhone.Text));
                    if (Convert.ToInt32(n) > 0)
                    {
                        await _db.LogToEventJournal(EventJournal.EventType.CreateObject, this);
                        MessageBox.Show("Клиент успешно добавлен.", "Добавление клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    n = await UpdatePerson(GetPhoneText(fizClientPhone.Text));
                    if (Convert.ToInt32(n) > 0)
                    {
                        await _db.LogToEventJournal(EventJournal.EventType.ChangeObject, this);
                        MessageBox.Show("Клиент успешно изменен.", "Изменение клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void closeOrgEditorBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            organization = e.TabPageIndex == 0 ? false : true;
            SelectTab(organization);
        }

        private void clientSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("- ".Concat(Symbols.ru_alp).Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back)
            {
                if (((TextBox)sender).Text.Trim().Length == 0) e.KeyChar = Char.ToUpper(e.KeyChar);
                return;
            }
            else e.Handled = true;
        }

        private void director_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("- ".Concat(Symbols.ru_alp).Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back)
            {
                if (((TextBox)sender).Text.Trim().Length == 0 || ((TextBox)sender).Text.Last() == ' ') e.KeyChar = Char.ToUpper(e.KeyChar);
                return;
            }
            else e.Handled = true;
        }

        private void fizPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDialog.CheckFileExists = fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() != DialogResult.OK) return;

            byte[] newImg = Сompressor.CompressImageToBytes(fileDialog.FileName);
            if (imgStream == null)
            {
                imgStream = new MemoryStream(newImg);
            }
            else
            {
                if (Common.IsImageBytesDifference(newImg, imgStream.ToArray()))
                {
                    imgStream = new MemoryStream(newImg);
                }
            }
            fizPhoto.Image = new Bitmap(imgStream);
            CheckFieldsFilling();
        }
    }
}
