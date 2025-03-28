using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
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
        Regex secRegex = new Regex("[a-zA-Z0-9]{8,}");


        // UserID, UserModeID, UserSpecializationID, UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserPhoto

        private bool HaveDiffFromDbValue(bool user)
        {
            bool photo = Common.IsImageBytesDifference(imgMem == null ? null : imgMem.ToArray(), storedValues[8] == System.DBNull.Value ? null : Сompressor.DecompressBytes((byte[])storedValues[8]));
            int specIndx = storedValues[2] != System.DBNull.Value ? Convert.ToInt32(storedValues[2]) : 0;
            bool spec = specCombo.SelectedIndex != specIndx;
            bool snp = surnameTextBox.Text != storedValues[3].ToString() || nameTextBox.Text != storedValues[4].ToString() || patronymicTextBox.Text != storedValues[5].ToString();

            if (user)
            {
                bool role = roleCombo.SelectedIndex != Convert.ToInt32(storedValues[1]);
                bool login = loginTextBox.Text != storedValues[6].ToString();
                bool pass = passTextBox.Text.Trim() != "";
                return photo || role || spec || snp || login || pass;
            }
            return photo || spec || snp;
        }

        private bool IsNeccessariesFilled()
        {
            bool res = true;
            int i = 0;
            while (res && i < neccessaryFields.Length)
            {
                if (neccessaryFields[i] >= fieldsFilled.Length) break;
                res = res && fieldsFilled[neccessaryFields[i]];
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

        private async Task FillRolesCombo()
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
            }

            storedValues = dt.Rows[0].ItemArray;

            if (dt.Rows[0][8] != System.DBNull.Value && (dt.Rows[0][8] as byte[]).Length > 0)
            {
                byte[] imgBytes = Сompressor.DecompressBytes((byte[])dt.Rows[0][8]);
                using (MemoryStream memStream = new MemoryStream(imgBytes))
                {
                    imgMem = new MemoryStream();
                    memStream.CopyTo(imgMem);
                    imgMem.Flush();

                    Bitmap tmpBmp = new Bitmap(imgMem);
                    userPhoto.Image = tmpBmp;
                }
            }
            else userPhoto.Image = null;

            // roleCombo.SelectedIndex = Convert.ToInt32(dt.Rows[0][1].ToString());
            if (userMode)
            {
                roleCombo.SelectedIndex = Convert.ToInt32(dt.Rows[0][1].ToString());
                loginTextBox.Text = dt.Rows[0][6].ToString();
            }

            nameTextBox.Text = dt.Rows[0][4].ToString();
            surnameTextBox.Text = dt.Rows[0][3].ToString();
            int spec = (dt.Rows[0][2] != System.DBNull.Value && dt.Rows[0][2].ToString() != "") ? Convert.ToInt32(dt.Rows[0][2].ToString()) : 0;
            specCombo.SelectedIndex = spec;
            patronymicTextBox.Text = dt.Rows[0][5].ToString();
            addEditBtn.Enabled = HaveDiffFromDbValue(userMode);
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

            specLbl.Text = userMode ? "Специальность" : "*Специальность";
            tipImageBox.SetToolTip(userPhoto, "Нажмите, чтобы сменить фотографию");

            FillSpecCombo();
            if (userMode)
            {
                fieldsFilled = new bool[8];
                userAccountEditPnl.Show();
                await FillRolesCombo();
            }
            else
            {
                neccessaryFields = new byte[] { 1, 2, 4 };
                fieldsFilled = new bool[5];
                userAccountEditPnl.Hide();
            }
            if (userAc != "" && userAc != null)
            {
                await FillUserInfo(userAc);
            }
            ChangeEnabledBtn();
            if (userPhoto.Image == null) userPhoto.Image = Resources.USR_PLUG_PICTURE;
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
            if (Symbols.en_alp.Contains(e.KeyChar.ToString().ToLower()) || Symbols.spec.Contains(e.KeyChar) || Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 127)
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
            fileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDialog.CheckFileExists = fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() != DialogResult.OK) return;

            byte[] newImg = Сompressor.CompressImageToBytes(fileDialog.FileName);
            if (imgMem == null)
            {
                imgMem = new MemoryStream(newImg);
                fieldsFilled[0] = Common.IsImageBytesDifference(newImg, new byte[0]);
            }
            else
            {
                fieldsFilled[0] = Common.IsImageBytesDifference(newImg, imgMem.ToArray());
                if (fieldsFilled[0])
                {
                    imgMem = new MemoryStream(newImg);
                }
            }

            //imgMem = new MemoryStream(Сompressor.CompressImageToBytes(fileDialog.FileName));
            userPhoto.Image = new Bitmap(imgMem);
            if (storedValues.Length > 0) ChangeEnabledBtn();
            else if (userAc == null || userAc == "") ChangeEnabledBtn();
        }

        private void ChangeEnabledBtn()
        {
            bool filled = true;
            if (userAc != "" && userAc != null)
            {
                filled = HaveDiffFromDbValue(userMode);
            }
            addEditBtn.Enabled = filled && IsNeccessariesFilled();
        }

        private void snpTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox it = ((TextBox)sender);
            switch (it.Name)
            {
                case "surnameTextBox": fieldsFilled[1] = it.Text.Trim() != ""; break;
                case "nameTextBox": fieldsFilled[2] = it.Text.Trim() != ""; break;
                case "patronymicTextBox": fieldsFilled[3] = it.Text.Trim() != ""; break;
            }
            if (storedValues.Length > 0) ChangeEnabledBtn();
            else if (userAc == null || userAc == "") ChangeEnabledBtn();
        }

        private void specCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fieldsFilled[4] = specCombo.SelectedIndex > 0;
            if (storedValues.Length > 0) ChangeEnabledBtn();
            else if (userAc == null || userAc == "") ChangeEnabledBtn();
        }

        private void roleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fieldsFilled[5] = roleCombo.SelectedIndex > 0;
            if (storedValues.Length > 0) ChangeEnabledBtn();
            else if (userAc == null || userAc == "") ChangeEnabledBtn();
        }

        private void accountFields_TextChanged(object sender, EventArgs e)
        {
            bool res = secRegex.Match(((TextBox)sender).Text.Trim()).Success;
            if (((TextBox)sender).Name == "loginTextBox") fieldsFilled[6] = res;
            else fieldsFilled[7] = res;
            if (storedValues.Length > 0) ChangeEnabledBtn();
            else if (userAc == null || userAc == "") ChangeEnabledBtn();
        }

        private string GetSpecialization()
        {
            return (specCombo.SelectedIndex <= 0) ? "0" : $"{specCombo.SelectedIndex}";
        }

        private string GetPatronymic()
        {
            return patronymicTextBox.Text.Trim() == "" ? "null" : patronymicTextBox.Text.Trim();
        }

        private string GetPassWord()
        {
            return Security.HashSha512(passTextBox.Text.Trim());
        }

        private async Task AddUser()
        {
            int rows = -1;
            Exception e = null;
            string patronymic = GetPatronymic() == "null" ? "null" : $"'{GetPatronymic()}'";
            string query = $"insert into {Db.Name}.user ";
            if (userMode)
            {
                query += $@"value (null,{roleCombo.SelectedIndex},{GetSpecialization()},'{surnameTextBox.Text.Trim()}','{nameTextBox.Text.Trim()}',{patronymic},'{loginTextBox.Text.Trim()}','{GetPassWord()}',";
            }
            else
            {
                query += $@"value (null,3,{GetSpecialization()},'{surnameTextBox.Text.Trim()}','{nameTextBox.Text.Trim()}',{patronymic},null,null,";
            }
            if (fieldsFilled[0] != false)
            {
                query += "@image";
            }
            else query += "null";
            query += ");";
            if (fieldsFilled[0] != false)
            {
                (rows, e) = await _db.ExecuteNoDataResultAsync(query, Сompressor.CompressBytes(imgMem.ToArray()));
            }
            else (rows, e) = await _db.ExecuteNoDataResultAsync(query);
            if (e != null)
            {
                MessageBox.Show(e.Message, "Создание пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (rows > 0) MessageBox.Show($"Пользователь создан успешно.", "Создание пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task EditUser(string userId)
        {
            // UserID, UserModeID, UserSpecialization, UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserPhoto
            string query = $@"update {Db.Name}.user set ";
            if (userMode)
            {
                if (Convert.ToInt32(storedValues[1].ToString()) != roleCombo.SelectedIndex)
                {
                    string role = roleCombo.SelectedIndex < 0 ? "null" : $"{roleCombo.SelectedIndex}";
                    query += $"UserModeID = {role}, ";
                }
                if (storedValues[6].ToString() != loginTextBox.Text.Trim())
                {
                    query += $"UserLogin = '{loginTextBox.Text.Trim()}', ";
                }
                if (passTextBox.Text.Trim() != "")
                {
                    query += $"UserPassword = '{GetPassWord()}', ";
                }
            }
            if (Convert.ToInt32(storedValues[2].ToString()) != specCombo.SelectedIndex)
            {
                query += $"UserSpecialization = {GetSpecialization()}, ";
            }
            if (storedValues[3].ToString() != surnameTextBox.Text.Trim())
            {
                query += $"UserSurname = '{surnameTextBox.Text.Trim()}', ";
            }
            if (storedValues[4].ToString() != nameTextBox.Text.Trim())
            {
                query += $"UserName = '{nameTextBox.Text.Trim()}', ";
            }
            if (storedValues[5].ToString() != patronymicTextBox.Text.Trim())
            {
                string patronymic = GetPatronymic() == "null" ? "null" : $"'{GetPatronymic()}'";
                query += $"UserPatronymic = {patronymic}, ";
            }
            if (fieldsFilled[0] != false)
            {
                query += "UserPhoto = @image ";
            }
            else
            {
                query += "UserPhoto = null ";
            }
            query += $"where UserID = {userId};";

            int rows = -1;
            Exception e = null;

            if (fieldsFilled[0] != false)
            {
                (rows, e) = await _db.ExecuteNoDataResultAsync(query, logic.Сompressor.CompressBytes(imgMem.ToArray()));
            }
            else
            {
                (rows, e) = await _db.ExecuteNoDataResultAsync(query);
            }

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
            if (userMode)
            {
                roleCombo.SelectedIndex = 0;
                loginTextBox.Text = "";
                passTextBox.Text = "";
            }
        }

        private async void addEditBtn_Click(object sender, EventArgs e)
        {
            if (userAc != "" && userAc != null)
            {
                await EditUser(userAc);
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

        private void UserEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (imgMem != null) imgMem.Close();
        }
    }
}
