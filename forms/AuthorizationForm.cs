﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.Properties;
using ProjectOffice.logic;
using ProjectOffice.logic.app;

namespace ProjectOffice.forms
{
    public partial class AuthorizationForm : Form
    {
        bool[] fieldsFilled = new bool[] { false, false };
        private Db _db = null;

        public AuthorizationForm()
        {
            InitializeComponent();
            _db = new Db();
        }

        // Функция, управляющая доступностью кнопки входа в зависимости от заполненности полей
        private void CheckFieldsFilling()
        {
            LogInBtn.Enabled = fieldsFilled[0] && fieldsFilled[1];
        }

        // Функция очистки полей формы авторизации
        private void ClearFields()
        {
            LoginTextBox_nec.Text = PswdTextBox_nec.Text = "";
            CheckFieldsFilling();
        }

        // Обработчик загрузки формы авторизации
        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Авторизация пользователя";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            appLogo.Image = Resources.PROJECT_OFFICE_LOGO;
            CheckFieldsFilling();
        }

        // Обработчик изменения текста в поле "Логин"
        private void LoginTextBox_nec_TextChanged(object sender, EventArgs e)
        {
            fieldsFilled[0] = LoginTextBox_nec.Text.Trim().Length > 0;
            CheckFieldsFilling();
        }

        // Обработчик изменения текста в поле "Пароль"
        private void PswdTextBox_nec_TextChanged(object sender, EventArgs e)
        {
            fieldsFilled[1] = PswdTextBox_nec.Text.Trim().Length > 0;
            CheckFieldsFilling();
        }

        // Обработчик нажатия на кнопку входа в приложение
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox_nec.Text.Trim();
            string pass = Security.HashSha512(PswdTextBox_nec.Text.Trim());
            // Поиск пользователя по логину и хэшированному паролю среди записанных в базе данных
            string[] result = _db.FindUser(login, pass);
            if (result == null)
            {
                MessageBox.Show("Ошибка обращения к базе данных", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (result.Length == 1)
            {
                MessageBox.Show(result[0], "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AppUser.Snp = result[0];
            int mode = 0;
            int.TryParse(result[1], out mode);
            switch (mode)
            {
                case (int)UserRole.Admin: AppUser.Role = UserRole.Admin;  break;
                case (int)UserRole.Manager: AppUser.Role = UserRole.Manager; break;
                case (int)UserRole.Employee: AppUser.Role = UserRole.Employee; break;
            }
            this.Hide();
            MenuForm menuForm = new MenuForm();
            if (menuForm.ShowDialog() == DialogResult.Abort)
            {
                Application.Exit();
            }
            else
            {
                ClearFields();
                this.Show();
            }           
        }

        // Обработчик нажатия на кнопку-картинку "Показать пароль"
        private void showPswdImgBox_Click(object sender, EventArgs e)
        {
            showPswdImgBox.Image = (new Bitmap(showPswdImgBox.Image) == Resources.SHOW_PICTURE) ? Resources.HIDE_PICTURE : Resources.SHOW_PICTURE;
            PswdTextBox_nec.UseSystemPasswordChar = !PswdTextBox_nec.UseSystemPasswordChar;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Обработчик нажатия на кнопку-картинку "Настройки"
        private void settingsImgBox_Click(object sender, EventArgs e)
        {
            ConnectionSettingsForm conForm = new ConnectionSettingsForm();
            conForm.ShowDialog();
        }
    }
}
