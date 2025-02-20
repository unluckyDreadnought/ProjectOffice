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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Пользователи системы";
            userEditorPanel.Hide();

            userSnp.Text = AppUser.Snp;
            userMode.Text = AppUser.GetUserMode();

            string[] arr = { "Администратор", "Менеджер", "Сотрудник" };
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                usersTable.Rows.Add();
                DataGridViewRow row = usersTable.Rows[i];
                row.Cells[0].Value = "Иванов Иван Иванович";
                row.Cells[1].Value = $"login{i}{i + 2}";
                row.Cells[2].Value = "********";
                row.Cells[3].Value = arr[rand.Next(arr.Length - 1)];
            }
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            userEditorPanel.Show();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            userEditorPanel.Show();
        }

        private void hideUserEditorBtn_Click(object sender, EventArgs e)
        {
            userEditorPanel.Hide();
        }
    }
}
