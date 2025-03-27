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
concat(UserSurname, ' ', substring(UserName, 1,1), '.', substring(UserPatronymic, 1,1)) as 'Snp',
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
                employeeTable.Rows[row].Cells["fio"].Value = employeesInfo[row][1];
                employeeTable.Rows[row].Cells["spec"].Value = employeesInfo[row][2];
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

        private void editEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (uId == "" || uId == null || uId == "-1")
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserEditor uEdit = new UserEditor(edit: true, userId: uId);
            uEdit.ShowDialog();
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            UserEditor uEdit = new UserEditor(edit: false);
            uEdit.ShowDialog();
        }

        private async void deleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (uId == "" || uId == null || uId == "-1")
            {
                MessageBox.Show("Выберите сотрудника для удаления", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string msg = "Вы уверены, что хотите удалить выбранного сотрудника?\n";
                string query = $"select ProjectID from {Db.Name}.userproject where UserID = {uId};";
                string[] projIds = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
                if (projIds.Length > 0)
                {
                    msg += "Выбранный сотрудник, включён в исполнителей некоторых проектов.\nСотрудник будет удалён из всех записей безвозвратно.";
                }
                if (MessageBox.Show(msg, "Удаление сотрудника", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = $"delete from userproject where UserID in ({string.Join(",",projIds)});";
                }
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
