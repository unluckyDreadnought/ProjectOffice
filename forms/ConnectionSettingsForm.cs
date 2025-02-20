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

namespace ProjectOffice.forms
{
    public partial class ConnectionSettingsForm : Form
    {
        public ConnectionSettingsForm()
        {
            InitializeComponent();
        }

        private void GetAccessToSetting(bool rightPass = false)
        {
            hostTextBox.Enabled = usrTextBox.Enabled = usrPswdTextBox.Enabled = dbNameTextBox.Enabled = rightPass;
            closeBtn.Enabled = checkSettingsPswdBtn.Enabled = saveSettingsBtn.Enabled = rightPass;
            if (!rightPass) unknownUsrPlugPanel.Show();
            else unknownUsrPlugPanel.Hide();
            closeSettingsBtn.Enabled = checkSettingsPswdBtn.Enabled = pswdToSettingsTextBox.Enabled = !rightPass;
        }

        private void closeSettingsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkSettingsPswdBtn_Click(object sender, EventArgs e)
        {
            if (pswdToSettingsTextBox.Text.Trim().Length == 0) return;
            AppUser.confirmAccessToSettings = true;
            GetAccessToSetting(true);
        }

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Настройки подключения";
            GetAccessToSetting();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
