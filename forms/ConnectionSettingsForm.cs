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
        private AppSettings _appConfig = null;
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
            string[] currentSets = { _appConfig.dbHost, _appConfig.dbUser, _appConfig.dbUserPass };
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
            if (dbSetsFilling[0]) _appConfig.dbHost = hostTextBox.Text;
            if (dbSetsFilling[1]) _appConfig.dbUser = usrTextBox.Text;
            if (dbSetsFilling[2]) _appConfig.dbUserPass = usrPswdTextBox.Text;
            _appConfig.SaveModified();
            CheckFieldsFilling();
        }

        // Функция восстановления текущих применённых значений настроек в текстовых полях
        private void RestoreSettings()
        {
            hostTextBox.Text = _appConfig.dbHost;
            usrTextBox.Text = _appConfig.dbUser;
            usrPswdTextBox.Text = _appConfig.dbUserPass;
            CheckFieldsFilling();
        }

        public ConnectionSettingsForm()
        {
            InitializeComponent();
            dbSetsFilling = new bool[3];
            _appConfig = new AppSettings();
            _db = new Db();
        }

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Настройки подключения";
            GetAccessToSetting();
            ChangeCheckBtnEnable();
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
            if (_appConfig.settingsPswd == Security.hashMd5(pswdToSettingsTextBox.Text.Trim(), "D1n5altn")) {
                GetAccessToSetting(true);
            }
            else
            {
                MessageBox.Show("Неверный пароль.", "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pswdToSettingsTextBox.Clear();
            }
        }

        private void closeSettingsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (_db.CanConnectToDb())
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
