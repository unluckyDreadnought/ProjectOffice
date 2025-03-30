using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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
        string userId = "";

        private async Task<(DataTable, Exception)> GetUserList()
        {
            string query = $@"select UserID, UserPhoto, usermode.UserModeTitle, 
concat(UserSurname, ' ', substring(UserName, 1, 1), '. ', case when UserPatronymic is null then '' else substring(UserPatronymic, 1, 1) end)  as 'Name', UserLogin from {Db.Name}.user
inner join {Db.Name}.usermode on usermode.UserModeID = user.UserModeID where UserID != {AppUser.Id};";
            return await _db.ExecuteReaderAsync(query);
        }

        private async void UpdateUserList()
        {
            Common.SetSizeForImageRow(ref usersTable, "userAvatar");
            usersTable.Rows.Clear();
            DataTable dt = await Common.GetAsyncResult(GetUserList());
            int i = 0;
            while (i < dt.Rows.Count)
            {
                int indx = usersTable.Rows.Add();
                Bitmap curBmp = null;
                if (dt.Rows[i].ItemArray[1] as byte[] != null)
                {
                    byte[] bytes = Сompressor.DecompressBytes((byte[])dt.Rows[i].ItemArray[1]);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        curBmp = new Bitmap(ms);
                    }
                }
                else
                {
                    curBmp = Resources.USR_PLUG_PICTURE;
                }


                curBmp = Сompressor.ResizeImage(curBmp, 80, 160);

                usersTable.Rows[indx].Height = 40;
                usersTable.Rows[indx].Cells["id"].Value = dt.Rows[i].ItemArray[0].ToString();
                usersTable.Rows[indx].Cells["userAvatar"].Value = curBmp;
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
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            usrSnpLbl.Text = AppUser.Snp;
            userPhotoPic.Image = AppUser.Photo;
            userModeTip.SetToolTip(usrSnpLbl, AppUser.GetUserMode());

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
            UpdateUserList();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            if (userId == "" || userId == null || userId == "-1")
            {
                MessageBox.Show("Выберите пользователя для редактирования", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserEditor uEdit = new UserEditor(edit: true, user: true, userId);
            uEdit.ShowDialog();
            UpdateUserList();
        }

        private void usersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            userId = usersTable.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private async void deleteUserBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = usersTable.Rows.Cast<DataGridViewRow>().Where(
                row => row.Cells["id"].Value.ToString() == userId).First();
            string userSnp = selectedRow.Cells["fio"].Value.ToString();
            string userLogin = selectedRow.Cells["login"].Value.ToString();
            if (MessageBox.Show($"Вы действительно хотите удалить этого пользователя ({userSnp} [{userLogin}])?", 
                "Редактор пользователей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool deleting = true;
                bool force = false;
                while (deleting)
                {
                    int linkedProjCount = 0;
                    (int n, bool haveRefs) = await Common.DeleteUser(userId, force: force);
                    if (n < 0)
                    {
                        if (haveRefs && !force)
                        {
                            if (n == int.MinValue)
                            {
                                if (MessageBox.Show($"Пользователь ({userSnp} [{userLogin}]) является менеджером создавшим несколько проектов.\n" +
                            $"Для удаления пользователя требуется удалить все проекты с его участием.\nВы действительно хотите это сделать?",
                    "Редактор пользователей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    force = true;
                                    continue;
                                }
                                else
                                {
                                    MessageBox.Show("Операция удаления отменена. Дальнейшее удаление невозможно без предыдущего шага.", "Редактор пользователей",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    deleting = false;
                                    continue;
                                }
                            }
                            else
                            {
                                linkedProjCount += -1 * n;
                                if (MessageBox.Show($"Пользователь ({userSnp} [{userLogin}]) включён в список исполнителей в {linkedProjCount} проектах.\n" +
                            $"Для удаления пользователя требуется удалить все записи о нём из других таблиц.\nВы действительно хотите это сделать?",
                    "Редактор пользователей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    force = true;
                                    continue;
                                }
                                else
                                {
                                    MessageBox.Show("Операция удаления отменена. Дальнейшее удаление невозможно без предыдущего шага.", "Редактор пользователей",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    deleting = false;
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления пользователя", "Редактор пользователей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            deleting = false;
                            continue;
                        }
                    }
                    else if (n == 0)
                    {
                        MessageBox.Show("Что-то пошло не так. Пользователь не был удалён.", "Редактор пользователей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deleting = false;
                        continue;
                    }
                    else
                    {
                        await _db.LogToEventJournal(EventJournal.EventType.DeleteObject, this);
                        MessageBox.Show($"Пользователь ({userSnp} [{userLogin}]) успешно удалён", "Редактор пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        deleting = false;
                        continue;
                    }
                }
                UpdateUserList();
            }
            else
            {
                MessageBox.Show($"Операция удаления пользователя ({userSnp} [{userLogin}]) прервана", "Редактор пользователей", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
