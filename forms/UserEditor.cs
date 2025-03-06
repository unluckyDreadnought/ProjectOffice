using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class UserEditor : Form
    {
        MemoryStream imgMem = null;
        bool editMode = false;
        bool userMode = false;
        Db _db = new Db();
        object[] storedValues = { };
        string userAc = "";
        bool[] fieldsFilled = null;
        byte[] neccessaryFields = new byte[] { 1, 2, 5, 6, 7 };
        Regex secRegex = new Regex("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}");
        

        // UserID, UserModeID, UserSpecializationID, UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserPhoto

        private bool HaveDiffFromDbValue()
        {
            //bool photo = 
            bool role = roleCombo.SelectedIndex != Convert.ToInt32(storedValues[1]);
            bool spec = specCombo.SelectedIndex != Convert.ToInt32(storedValues[2]);
            bool snp = surnameTextBox.Text != storedValues[3].ToString() || nameTextBox.Text != storedValues[4].ToString() || patronymicTextBox.Text != storedValues[5].ToString();
            bool login = loginTextBox.Text != storedValues[6].ToString();
            bool pass = passTextBox.Text.Trim() != "";
            return role || spec || snp || login || pass;
        }

        private bool IsNeccessariesFilled()
        {
            bool res = true;
            int i = 0;
            while (res && i < neccessaryFields.Length)
            {
                if (neccessaryFields[i] >= fieldsFilled.Length) break;
                res = res & fieldsFilled[neccessaryFields[i]];
                i++;
            }
            return res;
        }

        private async void FillSpecCombo()
        {
            string query = $"select SpecializationTitle from `{Db.Name}`.`specialization`;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            specCombo.Items.Clear();
            specCombo.Items.Add("Не определено");
            int i = 0;
            while (i < dt.Rows.Count)
            {
                specCombo.Items.Add(dt.Rows[i][0].ToString());
                i++;
            }
            specCombo.SelectedIndex = 0;
        }

        private async void FillRolesCombo()
        {
            string query = $"select UserModeTitle from `{Db.Name}`.`usermode`;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            roleCombo.Items.Clear();
            roleCombo.Items.Add("Не определено");
            int i = 0;
            while (i < dt.Rows.Count)
            {
                roleCombo.Items.Add(dt.Rows[i][0].ToString());
                i++;
            }
            roleCombo.SelectedIndex = 0;
        }

        private async Task FillUserInfo(string userId)
        {
            string query = $"select * from  `{Db.Name}`.`user` where UserID = {userId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось обнаружить информацию от этом пользователе", "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            storedValues = dt.Rows[0].ItemArray;

            roleCombo.SelectedIndex = Convert.ToInt32(dt.Rows[0][1].ToString());
            nameTextBox.Text = dt.Rows[0][4].ToString();
            surnameTextBox.Text = dt.Rows[0][3].ToString();
            patronymicTextBox.Text = dt.Rows[0][5].ToString();
            loginTextBox.Text = dt.Rows[0][6].ToString();
        }

        public UserEditor(bool edit = false, bool user = false, string userId = null)
        {
            InitializeComponent();
            editMode = edit;
            userMode = user;
            userAc = userId;
        }

        private async void UserEditor_Load(object sender, EventArgs e)
        {
            if (editMode) this.Text = $"{Resources.APP_NAME}: Редактирование";
            else this.Text = $"{Resources.APP_NAME}: Добавление";
            this.Text += (userMode) ? " пользователя" : " сотрудника";
            this.Icon = Resources.PROJECT_OFFICE_ICON;

            if (editMode) addEditBtn.Text = "Изменить";
            else addEditBtn.Text = "Добавить";
            FillSpecCombo();
            if (userMode)
            {
                fieldsFilled = new bool[8];
                userAccountEditPnl.Show();
                FillRolesCombo();
                if (userAc != "" && userAc != null)
                {
                    await FillUserInfo(userAc);
                    addEditBtn.Enabled = HaveDiffFromDbValue();
                }
            }
            else
            {
                fieldsFilled = new bool[5];
                userAccountEditPnl.Hide();
            }
            addEditBtn.Enabled = IsNeccessariesFilled();
            userPhoto.Image = Resources.USR_PLUG_PICTURE;
        }

        private void fioFields_KeyPressed(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (Symbols.ru_alp.Contains((e.KeyChar).ToString().ToLower()) || e.KeyChar == 8 || e.KeyChar == 127 || (textBox.Name == "surnameTextBox" && e.KeyChar == '-'))
            {
                if (textBox.TextLength == 0 || textBox.Text.Last<char>() == '-') e.KeyChar = Char.ToUpper(e.KeyChar);
                else e.KeyChar = Char.ToLower(e.KeyChar);
                return;
            }
            else e.Handled = true;
        }

        private void accountFields_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Symbols.en_alp.Contains(e.KeyChar.ToString().ToLower()) || Symbols.spec.Contains(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 127)
            {
                return;
            }
            else e.Handled = true;
        }

        private void backToListBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateLoginBtn_Click(object sender, EventArgs e)
        {
            loginTextBox.Text = Security.GenerateString(8, false);
        }

        private void generatePswdBtn_Click(object sender, EventArgs e)
        {
            passTextBox.Text = Security.GenerateString(8, true);
        }

        private void userPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Изображение JPEG|*.jpg;*.jpeg|Изображение PNG|*.png";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDialog.CheckFileExists = fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() != DialogResult.OK) return;

            imgMem = new MemoryStream();
            using (var file = File.Open(fileDialog.FileName, FileMode.Open))
            {
                file.CopyTo(imgMem);
            }
            userPhoto.Image = null;

            string dataIn = Сompressor.HumanReadableSizeLite(imgMem.Length);
            byte[] thumb = Сompressor.GetThumbnail(fileDialog.FileName, Convert.ToInt32(Math.Abs(Math.Sin(Math.Cos((double)imgMem.Length / 65535))) * 100));
            byte[] final = Сompressor.CompressBytes(thumb);
            //while (final.Length > 65535)
            //{
            //    thumb = Сompressor.DecompressBytes(final);
            //    using (var tmp = new MemoryStream(thumb))
            //    {
            //        thumb = Сompressor.GetThumbnail(new Bitmap(tmp), 0);
            //    }
            //    final = Сompressor.CompressBytes(thumb);

            //}
            //string dataOut = Сompressor.HumanReadableSizeLite(Сompressor.CompressImage(fileDialog.FileName).Length);

            //MessageBox.Show($"Вход: {dataIn}\nВыход:\n" +
            //    $"{Сompressor.HumanReadableSizeLite(thumb.Length)} => {Сompressor.HumanReadableSizeLite(final.Length)}" +
            //    $"\n{dataOut}");

            imgMem = new MemoryStream(Сompressor.DecompressBytes(final));
            userPhoto.Image = new Bitmap(imgMem);
        }

        private void ChangeEnabledBtn()
        {
            if (userMode && (userAc != "" && userAc != null))
            {
                addEditBtn.Enabled = HaveDiffFromDbValue();
            }
            else
            {
                addEditBtn.Enabled = IsNeccessariesFilled();
            }
        }

        private void snpTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox it = ((TextBox)sender);
            switch (it.Name)
            {
                case "surnameTextBox": fieldsFilled[1] = it.Text.Trim() != ""; break;
                case "nameTextBox": fieldsFilled[2] = it.Text.Trim() != ""; break;
                case "patronymicTextBox": fieldsFilled[3] = it.Text.Trim() != "";  break;
            }
            ChangeEnabledBtn();
        }

        private void specCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fieldsFilled[4] = specCombo.SelectedIndex > 0;
            ChangeEnabledBtn();
        }

        private void roleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fieldsFilled[5] = roleCombo.SelectedIndex > 0;
            ChangeEnabledBtn();
        }

        private void accountFields_TextChanged(object sender, EventArgs e)
        {
            bool res = secRegex.Match(((TextBox)sender).Text.Trim()).Success;
            if (((TextBox)sender).Name == "loginTextBox") fieldsFilled[6] = res;
            else fieldsFilled[7] = res;
            ChangeEnabledBtn();
        }

        private string GetSpecialization()
        {
            return (specCombo.SelectedIndex <= 0) ? "null" : $"{specCombo.SelectedIndex}";
        }

        private string GetPatronymic()
        {
            return patronymicTextBox.Text.Trim() == "" ? "null" : patronymicTextBox.Text.Trim();
        }

        private string GetPassWord()
        {
            return Security.HashSha512(passTextBox.Text.Trim());
        }

        private async Task  AddUser()
        {
            string query = $@"insert into {Db.Name}.user  
value (null,{roleCombo.SelectedIndex},{GetSpecialization()},'{surnameTextBox.Text.Trim()}','{nameTextBox.Text.Trim()}','{GetPatronymic()}','{loginTextBox.Text.Trim()}','{GetPassWord()}',null)";
            (int rows, Exception e) = await _db.ExecuteNoDataResultAsync(query);
            if (e != null)
            {
                MessageBox.Show(e.Message, "Создание пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (rows > 0) MessageBox.Show($"Пользователь создан успешно.", "Создание пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task EditUser()
        {
            string query = $@"update {Db.Name}.user 
UserModeID = {roleCombo.SelectedIndex}, UserSpecialization = {GetSpecialization()}, UserSurname = '{surnameTextBox.Text.Trim()}', UserName = '{nameTextBox.Text.Trim()}', UserPatronymic = '{GetPatronymic()}', UserLogin = '{loginTextBox.Text.Trim()}', UserPassword = '{GetPassWord()}', UserPhoto = null";
            (int rows, Exception e) = await _db.ExecuteNoDataResultAsync(query);
            if (e != null)
            {
                MessageBox.Show(e.Message, "Создание пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (rows > 0) MessageBox.Show($"Пользователь успешно отредактирован.", "Создание пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearFields()
        {
            surnameTextBox.Text = "";
            nameTextBox.Text = "";
            patronymicTextBox.Text = "";
            specCombo.SelectedIndex = 0;
            roleCombo.SelectedIndex = 0;
            loginTextBox.Text = "";
            passTextBox.Text = "";
        }

        private async void addEditBtn_Click(object sender, EventArgs e)
        {
            if (userMode && (userAc != "" && userAc != null))
            {

                ClearFields();
                this.Close();
            }
            else
            {
                await AddUser();
                ClearFields();
                this.Close();
            }
        }
    }
}
