using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.Properties;
using ProjectOffice.logic;
using ProjectOffice.logic.app;

namespace ProjectOffice.forms
{
    public partial class ProjectEditorForm : Form
    {
        Db _db = new Db();
        string projId = "";
        bool editMode = false;
        Regex regex = new Regex(@"^Проект \d+$");

        private bool tempProject = false;
        private string clientId = "null";

        private string projName = "";
        private string placeholderName = "";

        public ProjectEditorForm(string projectId = "")
        {
            InitializeComponent();
            projId = projectId;
            editMode = projId != "";
        }

        private async Task<int> GetLastProjectStandardNameNumber()
        {
            string query = $"select ProjectTitle from {Db.Name}.project where ProjectTitle like '%Проект %' order by ProjectTitle DESC limit 1;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count > 0)
            {
                int num = 0;
                int.TryParse(dt.Rows[0].ItemArray[0].ToString().Split(' ')[1].Trim(' ', ':', '.'), out num);
                return num;
            }
            else return 0;
        } 

        private async Task<int> GetNoScalarResult(Task<(int,string)> task)
        {
            (int affected, string msg) = await task;
            if (msg != null)
            {
                MessageBox.Show($"Описание ошибки:\n{msg}", "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return affected;
        }

        private async Task<(int,string)> CreateTempProject()
        {
            string query = $@"set session sql_mode='NO_AUTO_VALUE_ON_ZERO';
insert into {Db.Name}.project value (0, 1, 1, {AppUser.Id}, '{projName}', '{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("yyyy-MM-dd")}', null, '0', 0);";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else
            {
                tempProject = true;
                return (Convert.ToInt32(response.ToString()), null);
            }
        }

        private async Task<(int, string)> UpdateProject(string projectID, string columnName, string value)
        {
            string query = $"update {Db.Name}.project set project.{columnName} = {value} where ProjectID = {projectID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);

        }

        private async Task<(int, string)> DeleteProject(string projectID)
        {
            string query = $"delete from {Db.Name}.project where ProjectID = {projectID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        private async Task<int> GetLastProjID()
        {
            string query = $"SELECT ProjectID FROM {Db.Name}.project order by ProjectID DESC limit 1;";
            (object value,  Exception e) = await _db.ExecuteScalarAsync(query);
            int projId = -1;
            if (e != null)
            {
                MessageBox.Show(e.Message, "Не удалось извлечь значение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e == null && Convert.ToInt32(value) == -1)
            {
                MessageBox.Show("Не удалось установить подключение к БД.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else projId = Convert.ToInt32(value);
            return projId;
        }

        private void SetProjNamePlaceholder()
        {
            projectNameTextBox.ForeColor = Color.Gray;
            projectNameTextBox.Text = placeholderName;
        }

        private void EraseProjNamePlaceholder()
        {
            projectNameTextBox.Text = "";
            projectNameTextBox.Clear();
            projectNameTextBox.ForeColor = Color.Black;
        }

        private async void ProjectEditorForm_Load(object sender, EventArgs e)
        {
            int number = await GetLastProjectStandardNameNumber();
            if (editMode)
            {
                this.Text = $"{Resources.APP_NAME}: Редактирование проекта";
                chooseClientPanel.Hide();
                chooseEmployeePanel.Hide();
                chooseStagePanel.Hide();
                projectCostTextBox.Enabled = projectCostTextBox.Visible = false;
            }
            else
            {
                this.Text = $"{Resources.APP_NAME}: Создание проекта";
                projId = $"{await GetLastProjID()+1}";
                choosenClientLbl.Text = "клиент не выбран";
                projCostLbl.Enabled = projCostLbl.Visible = false;
                subtaskPanel.Hide();
                startDateLbl.Text = DateTime.Now.ToString("dd.MM.yyyy");
                endPlanDate.MinDate = DateTime.Now.AddDays(5);
                endPlanDate.MaxDate = DateTime.Now.AddMonths(4);
                placeholderName = projName = $"Проект {number+1}";
                projectNameTextBox.Text = projName;
                await GetNoScalarResult(CreateTempProject());
            }
            managerLbl.Text = AppUser.Snp;
            startDateLbl.Text = DateTime.Now.ToString("dd.MM.yyyy");
            projectIdLbl.Text = $"Проект #{projId}";
            
        }

        private async void backToProjectListBtn_Click(object sender, EventArgs e)
        {
            if (tempProject)
            {
                DialogResult msgResult = MessageBox.Show("Вы уверены, что хотите перейти к списку проектов и отменить изменения в новом проекте?", "Новый проект", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    if (tempProject)
                    {
                        string project = "0";
                        DataTable dt = await GetUsersInProject(project);
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            int tn = await GetNoScalarResult(RemoveUserFromProject(project, dt.Rows[i][0].ToString()));
                            i++;
                        }
                        await GetNoScalarResult(DeleteProject(project));
                    }
                    this.Close();
                }
            }
            else this.Close();
        }

        private async Task<string> GetClientName(string clientID)
        {
            string query = $@"select case when ClientOrgTypeID is null then ClientName else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`
from {Db.Name}.client where ClientID = {clientID}; ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        private async void chooseClientBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Client);
            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                string[][] choosen = chooseForm.SelectedIndexes.ToArray();
                clientId = choosen.Length > 0 ? choosen[0][0] : "null";
                choosenClientLbl.Text = clientId != "null" ? $"{await GetClientName(clientId)}" : choosenClientLbl.Text;
                if (tempProject && clientId != "null")
                {
                    int n = await GetNoScalarResult(UpdateProject("0", "ProjectCustomerID", clientId));
                }
            }
            
        }

        private void chooseStagesBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Stages);
            chooseForm.ShowDialog();
        }

        private async Task<string> GetEmployee(string usrID)
        {
            string query = $@"select concat(UserSurname, ' ', substring(UserName, 1, 1), '.')  as 'Name' from {Db.Name}.`user` where UserID = {usrID};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string employeeName = (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
            return employeeName;
        }

        private async Task<DataTable> GetUsersInProject(string projID)
        {
            string query = $"select UserID from {Db.Name}.userproject where ProjectID = {projID};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt;
        }

        private async Task<(int, string)> AddUserToProject(string projID, string usrID, bool responsible)
        {
            string resp = responsible ? "1" : "0";
            string query = $@"insert into {Db.Name}.userproject value ({usrID}, {projID}, {resp});";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else
            {
                tempProject = true;
                return (Convert.ToInt32(response.ToString()), null);
            }
        }

        private async Task<(int, string)> RemoveUserFromProject(string projID, string usrID)
        {
            string query = $@"delete from {Db.Name}.userproject where UserID = {usrID} and ProjectID = {projID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else
            {
                tempProject = true;
                return (Convert.ToInt32(response.ToString()), null);
            }
        }

        private async void chooseEmployeesBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Employee);
            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                string[][] selected = chooseForm.SelectedIndexes.ToArray();
                if (selected.Length == 0) return;
                int set = 0;
                while (set < selected.Length)
                {
                    string tUsrId = selected[set][0];
                    string name = await GetEmployee(tUsrId);
                    if (name == null)
                    {
                        set++;
                        continue;
                    }
                    int n = await GetNoScalarResult(AddUserToProject("0", tUsrId, selected[set].Length > 1));
                    int rIndx = employeesTable.Rows.Add();
                    employeesTable.Rows[rIndx].Cells[0].Value = name;
                    ((DataGridViewCheckBoxCell)employeesTable.Rows[rIndx].Cells[1]).Value = selected[set].Length > 1;
                    set++;
                }
            }
        }

        private void subtaskBtn_Click(object sender, EventArgs e)
        {
            SubtaskList tasksList = new SubtaskList();
            tasksList.ShowDialog();
        }

        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (projectNameTextBox.Text.Trim() == "") SetProjNamePlaceholder();

        }

        private void projectNameTextBox_Leave(object sender, EventArgs e)
        {
            if (projectNameTextBox.Text.Trim() == "") SetProjNamePlaceholder();
        }

        private void projectNameTextBox_Click(object sender, EventArgs e)
        {
            Match match = regex.Match(projectNameTextBox.Text.Trim());
            if (match.Success) EraseProjNamePlaceholder();
        }

        private void employeesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }
    }
}
