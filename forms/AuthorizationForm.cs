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
    public partial class AuthorizationForm : Form
    {
        bool[] fieldsFilled = new bool[] { false, false };

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void CheckFieldsFilling()
        {
            LogInBtn.Enabled = fieldsFilled[0] && fieldsFilled[1];
        }

        private void ClearFields()
        {
            LoginTextBox_nec.Text = PswdTextBox_nec.Text = "";
            CheckFieldsFilling();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Авторизация пользователя";
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            AppUser.Snp = "Иванов И.И.";
            switch (LoginTextBox_nec.Text)
            {
                case "админ": AppUser.Role = UserRole.Admin;  break;
                case "менеджер": AppUser.Role = UserRole.Manager; break;
                case "сотрудник": AppUser.Role = UserRole.Employee; break;
            }
            this.Hide();
            MenuForm menuForm = new MenuForm();
            this.Hide();
            if (menuForm.ShowDialog() == DialogResult.Abort)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }           
        }

        private void showPswdImgBox_Click(object sender, EventArgs e)
        {
            showPswdImgBox.Image = (new Bitmap(showPswdImgBox.Image) == Resources.SHOW_PICTURE) ? Resources.HIDE_PICTURE : Resources.SHOW_PICTURE;
            PswdTextBox_nec.UseSystemPasswordChar = !PswdTextBox_nec.UseSystemPasswordChar;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsImgBox_Click(object sender, EventArgs e)
        {
            ConnectionSettingsForm conForm = new ConnectionSettingsForm();
            conForm.ShowDialog();
        }
    }
}
