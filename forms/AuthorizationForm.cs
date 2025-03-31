using System;
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

        // конструктор класса
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
            // установка названия формы и иконки
            this.Text = $"{Resources.APP_NAME}: Авторизация пользователя";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            appLogo.Image = Resources.PROJECT_OFFICE_LOGO;
            // проверка заполнения полей
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
        private async void LogInBtn_Click(object sender, EventArgs e)
        {
            // подготавливаем логин и пароль для сравнения со значениями в базе данных
            string login = LoginTextBox_nec.Text.Trim();
            string pass = Security.HashSha512(PswdTextBox_nec.Text.Trim());
            // Поиск пользователя по логину и хэшированному паролю среди записанных в базе данных
            (string[] result, DataTable dt) = await _db.FindUser(login, pass);
            // неудачное подключении к БД
            if (result == null)
            {
                MessageBox.Show("Ошибка обращения к базе данных", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // пользователь с такими учётными данными не обнаружен
            else if (result.Length == 1)
            {
                MessageBox.Show(result[0], "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // заполнение данных текущего пользователя
            AppUser.Photo = null;
            // сохранение фотографии пользователя, если она была найдена
            if (dt.Rows[0].ItemArray[3] as byte[] != null)
            {
                byte[] bytes = Сompressor.DecompressBytes((byte[])dt.Rows[0].ItemArray[3]);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    AppUser.Photo = new Bitmap(ms);
                }
            }
            // сохранение основных данных о пользователе
            AppUser.Id = result[2];
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
            // запись входа в систему в "Журнал действий пользователей"
            await _db.LogToEventJournal(EventJournal.EventType.Authorize, this);
            // открытие меню
            MenuForm menuForm = new MenuForm();
            // определение реакции системы на закрытие меню
            if (menuForm.ShowDialog() == DialogResult.Abort)
            {
                // полный выход - нажатие кнопки "Выход" на форме меню
                Application.Exit();
            }
            else
            {
                // выход из аккаунта - нажатие кнопки "Покинуть личный кабинет" на форме меню
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

        // Обработчик нажатия на  кнопку "Выход" на форме авторизации
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
