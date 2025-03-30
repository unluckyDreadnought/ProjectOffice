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
    public partial class EmployeesForm : Form
    {
        Db _db = new Db();
        string uId = "";

        public EmployeesForm(bool canEdit = false)
        {
            InitializeComponent();
            actionsPanel.Enabled = actionsPanel.Visible = canEdit;
        }

        private async Task<DataTable> LoadEmployees()
        {
            string query = $@"select 
UserID, SpecializationTitle, 
concat(UserSurname, ' ', substring(UserName, 1,1), '.', 
case when UserPatronymic is not null then substring(UserPatronymic, 1,1) else '' end) as 'Snp',
case when UserLogin is not null then true else false end as 'HaveAccount'
from project_office.user
inner join specialization on specialization.SpecializationID = `user`.UserSpecializationID
where UserModeID = 3
order by Snp asc;";
            DataTable dt = await Common.GetAsyncResult(_db.ExecuteReaderAsync(query));
            return dt;
        }

        private async Task UpdateEmployeesTable()
        {
            employeeTable.Rows.Clear();
            string[][] employeesInfo = Common.MultiColumnDataTableToStringArray(await LoadEmployees());
            int row = 0;
            while (row < employeesInfo.Length)
            {
                employeeTable.Rows.Add();
                employeeTable.Rows[row].Cells["idCol"].Value = employeesInfo[row][0];
                employeeTable.Rows[row].Cells["fio"].Value = employeesInfo[row][2];
                employeeTable.Rows[row].Cells["spec"].Value = employeesInfo[row][1];
                employeeTable.Rows[row].Cells["haveAccountCol"].Value = Convert.ToInt32(employeesInfo[row][3]) > 0;
                row++;
            }
        }

        private async void EmployeesForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Сотрудники";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            await UpdateEmployeesTable();
            actionsPanel.Enabled = actionsPanel.Visible = AppUser.Role == UserRole.Admin;
            usrSnpLbl.Text = AppUser.Snp;
            userPhotoPic.Image = AppUser.Photo;
        }

        private async void editEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (uId == "" || uId == null || uId == "-1")
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserEditor uEdit = new UserEditor(edit: true, userId: uId);
            uEdit.ShowDialog();
            await UpdateEmployeesTable();
        }

        private async void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            UserEditor uEdit = new UserEditor(edit: false);
            uEdit.ShowDialog();
            await UpdateEmployeesTable();
        }

        private async void deleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = employeeTable.Rows.Cast<DataGridViewRow>().Where(
                row => row.Cells[0].Value.ToString() == uId).First();
            string userSnp = selectedRow.Cells["fio"].Value.ToString();

            if (MessageBox.Show($"Вы действительно хотите удалить этого пользователя ({userSnp})?",
                "Редактор пользователей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool deleting = true;
                bool force = false;
                while (deleting)
                {
                    int linkedProjCount = 0;
                    (int n, bool haveRefs) = await Common.DeleteUser(uId, force: force);
                    if (n < 0)
                    {
                        if (haveRefs && !force)
                        {
                            linkedProjCount += -1 * n;
                            if (MessageBox.Show($"Сотрудниик ({userSnp}) включён в список исполнителей в {linkedProjCount} проектах.\n" +
                        $"Для удаления сотрудника требуется удалить все записи о нём из других таблиц.\nВы действительно хотите это сделать?",
                "Редактор сотрудников", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                force = true;
                                continue;
                            }
                            else
                            {
                                MessageBox.Show("Операция удаления отменена. Дальнейшее удаление невозможно без предыдущего шага.", "Редактор сотрудников",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                deleting = false;
                                continue;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления сотрудника", "Редактор сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            deleting = false;
                            continue;
                        }
                    }
                    else if (n == 0)
                    {
                        MessageBox.Show("Что-то пошло не так. Сотрудник не был удалён.", "Редактор сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        deleting = false;
                        continue;
                    }
                    else
                    {
                        await _db.LogToEventJournal(EventJournal.EventType.DeleteObject, this);
                        MessageBox.Show($"Сотрудник ({userSnp}) успешно удалён", "Редактор сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        deleting = false;
                        continue;
                    }
                }
                await UpdateEmployeesTable();
            }
            else
            {
                MessageBox.Show($"Операция удаления сотрудника ({userSnp}) прервана", "Редактор сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeeTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uId = "";
            if (e.RowIndex < 0) return;
            uId = employeeTable.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
