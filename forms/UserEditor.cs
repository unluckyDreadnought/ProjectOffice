using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class UserEditor : Form
    {
        bool editMode = false;
        bool userMode = false;
        Db _db = new Db();
        object[] storedValues = { };
        string userId = "";

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

        private async void FillUserInfo(string userId)
        {
            string query = $"select * from  `{Db.Name}`.`user` where UserID = {userId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось обнаружить информацию от этом пользователе", "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public UserEditor(bool edit = false, bool user = false, string userId = null)
        {
            InitializeComponent();
            editMode = edit;
            userMode = user;
        }

        private void UserEditor_Load(object sender, EventArgs e)
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
                FillUserInfo(userId);
                userAccountEditPnl.Show();
                FillRolesCombo();
            }
            else userAccountEditPnl.Hide();
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
    }
}
