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
using ProjectOffice.logic.app;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class UsersForm : Form
    {
        Db _db = new Db();

        private async Task<(DataTable, Exception)> GetUserList()
        {
            string query = $@"select UserID, UserPhoto, usermode.UserModeTitle, concat(UserSurname, ' ', substring(UserName, 1, 1), '. ', substring(UserPatronymic,1,1)), UserLogin from {Db.Name}.user
inner join {Db.Name}.usermode on usermode.UserModeID = user.UserModeID";
            return await _db.ExecuteReaderAsync(query);
        }

        private async void UpdateUserList()
        {
            DataTable dt = await Common.GetAsyncResult(GetUserList());
            int i = 0;
            while (i < dt.Rows.Count)
            {
                int indx = usersTable.Rows.Add();
                usersTable.Rows[indx].Height = 40;
                usersTable.Rows[indx].Cells["id"].Value = dt.Rows[i].ItemArray[0].ToString();
                usersTable.Rows[indx].Cells["userAvatar"].Value = null;
                usersTable.Rows[indx].Cells["fio"].Value = dt.Rows[i].ItemArray[3].ToString();
                string login = dt.Rows[i].ItemArray[4].ToString();
                string hiddenLogin = "";
                int si = 0;
                int symbolsToHide = (int)Math.Ceiling((double)login.Length * 0.5);
                while (si < login.Length)
                {
                    if (si > 1 && symbolsToHide > 0)
                    {
                        hiddenLogin += "*";
                        symbolsToHide--;
                    }
                    else hiddenLogin += login[si].ToString();
                    si++;
                }

                usersTable.Rows[indx].Cells["role"].Value = dt.Rows[i].ItemArray[2].ToString();
                usersTable.Rows[indx].Cells["login"].Value = hiddenLogin;
                i++;
            }
        }

        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Пользователи системы";
            userSnp.Text = AppUser.Snp;
            userMode.Text = AppUser.GetUserMode();

            UpdateUserList();
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            UserEditor uEdit = new UserEditor(user: true);
            uEdit.ShowDialog();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            string userId = usersTable.SelectedRows[0].Cells[0].Value.ToString();
            UserEditor uEdit = new UserEditor(edit: true, user: true, userId);
            uEdit.ShowDialog();
        }
    }
}
