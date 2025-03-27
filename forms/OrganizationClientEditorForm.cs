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

namespace ProjectOffice.forms
{
    public partial class OrganizationClientEditorForm : Form
    {
        object[] storedOrgInfo = null;
        Db _db = new Db();
        string editId = "";
        MemoryStream imgStream = null;
        Regex regexEmail = new Regex(Symbols.emailPattern);

        private OrganizationClientEditorForm(string id = "", object[] clientInfo = null)
        {
            InitializeComponent();
            editId = id;
            if (editId != "")
            {
                storedOrgInfo = clientInfo;
                PasteClientInformation();
            }
        }

        private void CheckFieldsFilling()
        {
            bool filled = true;
            string phone = "";

            if (editId != "")
            {
                phone = phoneTxt.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace(" ", "");
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
                if (imgStream != null && storedOrgInfo[11] == DBNull.Value)
                {
                    filled = true;
                }
                else if (imgStream != null && storedOrgInfo[11] != DBNull.Value)
                {
                    filled = filled || Common.IsImageBytesDifference(imgStream.ToArray(), logic.Сompressor.DecompressBytes((byte[])storedOrgInfo[11]));
                }
            }

            phone = phoneTxt.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace(" ", "");
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

            saveOrganizationBtn.Enabled = filled;
        }

        private void PasteClientInformation()
        {
            if (storedOrgInfo == null || storedOrgInfo.Length == 0) return;
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
            if (storedOrgInfo[11] != DBNull.Value)
            {
                using (var ms = new MemoryStream(logic.Сompressor.DecompressBytes((byte[])storedOrgInfo[12])))
                {
                    ms.CopyTo(imgStream);
                }
            }
            orgLogo.Image = (imgStream != null) ? new Bitmap(imgStream) : Resources.PLUG_PICTURE;
        }

        public static async Task<OrganizationClientEditorForm> OpenOrganizationEditor(string id = "")
        {
            Db db = new Db();
            if (id == "" || id == null) return new OrganizationClientEditorForm();
            object[] clientInfo = await Common.GetClientInfo(id);
            if (clientInfo.Length == 0)
            {
                if (id == "0")
                {
                    string query = $@"SET SESSION sql_mode='NO_AUTO_VALUE_ON_ZERO';
insert into client value (0, 2, 'ООО', '', '', '', '', null, null, null, null, null, null, null)";
                    (object n, _) = await Common.GetNoScalarResult(db.GetAsynNonReaderResult(db.ExecuteNoDataResultAsync(query)));
                    if (Convert.ToInt32(n) > 0) MessageBox.Show("Подготовка редактора Вашей организации завершена успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clientInfo = await Common.GetClientInfo(id);
                }
                else clientInfo = null;
            }
            return new OrganizationClientEditorForm(id, clientInfo);
        }

        private async Task<string[]> GetStoredBanks()
        {
            string query = $"select distinct ClientBank from {Db.Name}.`client`;";
            string[] banks = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            return banks.Where(bank => bank.Trim().Length > 0).ToArray();
        }

        private async void OrganizationClientEditorForm_Load(object sender, EventArgs e)
        {
            if (editId != "") this.Text = $"{Resources.APP_NAME}: Редактирование организации";
            else this.Text = $"{Resources.APP_NAME}: Создание организации";

            this.Icon = Resources.PROJECT_OFFICE_ICON;
            if (editId != "" && editId != null)
            {
                if (storedOrgInfo == null) storedOrgInfo = await Common.GetClientInfo(editId);
            }
            orgBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            orgBank.AutoCompleteSource = AutoCompleteSource.CustomSource;
            orgBank.AutoCompleteCustomSource.AddRange(await GetStoredBanks());
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

        private async void saveOrganizationBtn_Click(object sender, EventArgs e)
        {
            object n = null;
            string phone = phoneTxt.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            if (editId == "" || editId == null)
            {
                string query = $@"set session sql_mode='NO_AUTO_VALUE_ON_ZERO';
insert into {Db.Name}.client value 
(null, 2, '{orgType.SelectedItem.ToString()}', '{orgName.Text.Trim()}', '{orgAddr.Text.Trim()}', '{orgBankAcc.Text.Trim()}', '{orgBank.Text.Trim()}', 
'{phone}', @email, '{orgInn.Text.Trim()}', '{orgKpp.Text.Trim()}', '{orgOgrn.Text.Trim()}', '{orgBik.Text.Trim()}',";
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
                
                if (Convert.ToInt32(n) > 0)
                {
                    MessageBox.Show("Организиция успешно добавлена.", "Добавление клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                string query = $@"update {Db.Name}.`client` set
ClientOrgTypeId = '{orgType.SelectedItem.ToString()}', ClientName = '{orgName.Text.Trim()}', ClientAddress = '{orgAddr.Text.Trim()}', ClientBankAccount = '{orgBankAcc.Text.Trim()}',
ClientBank = '{orgBank.Text.Trim()}', ClientPhone = '{phone}', ClientEmail = @mail, ClientOrgINN = '{orgInn.Text.Trim()}',
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

                if (Convert.ToInt32(n) > 0)
                {
                    MessageBox.Show("Организиция успешно изменена.", "Изменение клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void closeOrgEditorBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
