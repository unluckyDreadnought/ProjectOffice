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
using ProjectOffice.logic;
using ProjectOffice.logic.app;

namespace ProjectOffice.forms
{
    public partial class ConnectionSettingsForm : Form
    {
        private bool[] dbSetsFilling;
        private Db _db = null;

        private bool HasTrue(bool[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                if (array[i]) return true;
                i++;
            }
            return false;
        }

        // Функция изменения доступности кнопки применения параметров подключения
        private void CheckFieldsFilling()
        {
            string[] currentSets = { AppSettings.dbHost, AppSettings.dbUser, AppSettings.dbUserPass };
            byte cntr = 0;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox == false || !control.Visible) continue;
                dbSetsFilling[cntr] = (((TextBox)control).Text.Length > 0 && ((TextBox)control).Text != currentSets[cntr]);
                cntr++;
            }
            saveSettingsBtn.Enabled = HasTrue(dbSetsFilling);
        }

        // Функция изменения доступности кнопки проверки пароля доступа к настройкам
        private void ChangeCheckBtnEnable()
        {
            checkSettingsPswdBtn.Enabled = pswdToSettingsTextBox.Text.Length > 0;
        }

        // Функция, управляющая отображением панели для подтверждения доступа к настройкам
        private void GetAccessToSetting(bool rightPass = false)
        {
            hostTextBox.Enabled = usrTextBox.Enabled = usrPswdTextBox.Enabled = dbNameTextBox.Enabled = rightPass;
            closeBtn.Enabled = checkSettingsPswdBtn.Enabled = saveSettingsBtn.Enabled = rightPass;
            if (!rightPass) unknownUsrPlugPanel.Show();
            else unknownUsrPlugPanel.Hide();
            closeSettingsBtn.Enabled = checkSettingsPswdBtn.Enabled = pswdToSettingsTextBox.Enabled = !rightPass;
            RestoreSettings();
        }

        // Функция применения изменённых настроек
        private void SaveSettings()
        {
            if (dbSetsFilling[0]) AppSettings.dbHost = hostTextBox.Text;
            if (dbSetsFilling[1]) AppSettings.dbUser = usrTextBox.Text;
            if (dbSetsFilling[2]) AppSettings.dbUserPass = usrPswdTextBox.Text;
            AppSettings.SaveModified();
            CheckFieldsFilling();
        }

        // Функция восстановления текущих применённых значений настроек в текстовых полях
        private void RestoreSettings()
        {
            hostTextBox.Text = AppSettings.dbHost;
            usrTextBox.Text = AppSettings.dbUser;
            usrPswdTextBox.Text = AppSettings.dbUserPass;
            CheckFieldsFilling();
        }

        public ConnectionSettingsForm()
        {
            InitializeComponent();
            dbSetsFilling = new bool[3];
            _db = new Db();
        }

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Настройки подключения";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            GetAccessToSetting();
            ChangeCheckBtnEnable();
            pswdToSettingsTextBox.UseSystemPasswordChar = true;
        }

        private void hidePswdChar_Click(object sender, EventArgs e)
        {
            pswdToSettingsTextBox.UseSystemPasswordChar = !pswdToSettingsTextBox.UseSystemPasswordChar;
        }

        private void settingTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckFieldsFilling();
        }

        private void pswdToSettingsTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeCheckBtnEnable();
        }

        private void checkSettingsPswdBtn_Click(object sender, EventArgs e)
        {
            if (AppSettings.settingsPswd == Security.hashMd5(pswdToSettingsTextBox.Text.Trim(), "D1n5altn")) {
                GetAccessToSetting(true);
            }
            else
            {
                MessageBox.Show("Неверный пароль.", "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pswdToSettingsTextBox.Clear();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите изменить настройки подключения?", "Внимание, необратимое действие", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                SaveSettings();
            }
            else RestoreSettings();
            CheckFieldsFilling();
        }

        private void testConnectionBtn_Click(object sender, EventArgs e)
        {
            if (_db.CanConnectToDb(hostTextBox.Text.Trim(), usrTextBox.Text.Trim(), usrPswdTextBox.Text.Trim()))
            {
                MessageBox.Show("Подключение было успешно установлено", "Тестирование подключения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к базе данных", "Тестирование подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
