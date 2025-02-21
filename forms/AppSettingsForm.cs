using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.Properties;
using ProjectOffice.logic.app;

namespace ProjectOffice.forms
{
    public partial class AppSettingsForm : Form
    {
        private AppSettings _appConfig = null;
        public AppSettingsForm()
        {
            InitializeComponent();
            _appConfig = new AppSettings();
        }

        // Функция, управляющая доступностью для нажатия кнопки сохранения
        private void ChangeSaveBtnEnable()
        {
            if (setsPswdTextBox.Text.Trim().Length > 0)
            {
                saveSettingsBtn.Enabled = !(_appConfig.settingsPswd == setsPswdTextBox.Text.Trim()); 
            }
            else
            {
                saveSettingsBtn.Enabled = false;
            }
        }

        // Обработчик события загрузки формы
        private void AppSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Настройки";
        }

        // Обработчик события нажатия на кнопку скрытия / показа пароля
        private void hidePassChars_Click(object sender, EventArgs e)
        {
            setsPswdTextBox.UseSystemPasswordChar = !setsPswdTextBox.UseSystemPasswordChar;
            hidePassChars.Image = (setsPswdTextBox.UseSystemPasswordChar) ? Resources.SHOW_PICTURE : Resources.HIDE_PICTURE;
        }

        // Обработчик события нажатия на кнопку сохранения
        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            _appConfig.settingsPswd = setsPswdTextBox.Text.Trim();
            _appConfig.SaveModified();
        }

        // Обработчик события изменения текста в текстовом поле
        private void setsPswdTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeSaveBtnEnable();
        }

        // Обработчик события нажатия на кнопку возвращения в меню
        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
