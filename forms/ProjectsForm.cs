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
    public partial class ProjectsForm : Form
    {
        Db _db = null;
        bool _loading = true;

        public ProjectsForm()
        {
            InitializeComponent();
            _db = new Db();
        }

        // для менеджера
        private async Task<(DataTable, Exception)> GetProjectsData(string searchPattern = "", string filter = "", string orderRule = "", string dateRange = "")
        {
            string query = $@"select project.ProjectID, ProjectTitle, concat(UserSurname, ' ', substring(UserName, 1,1), '.', substring(UserPatronymic, 1,1)) as 'fio', StatusTitle,
case when ProjectFactEndDate is NULL then ProjectPlanEndDate
else ProjectFactEndDate
end as 'date',
case when ProjectCoefficient = 0 then concat(ProjectCost, ' | 0')
else concat(round(ProjectCost*(1+ProjectCoefficient/100),2), ' | ', round(ProjectCost-round(ProjectCost*(1+ProjectCoefficient/100),2),2))
end as 'cost'
from project
left join userproject on userproject.ProjectID = project.ProjectID and userproject.IsResponsible = 1
left join `user` on `user`.UserID = userproject.UserID
inner join `status` on `status`.StatusID = project.ProjectStatusID
where ProjectTitle like '%{searchPattern}%' ";
            if (filter != "")
            {
                query += $"and {filter} ";
            }
            if (dateRange != "")
            {
                query += $"and {dateRange} ";
            }
            if (orderRule != "")
            {
                query += $"order by {orderRule}";
            }
            query += ";";
            
            var task = _db.ExecuteReaderAsync(query);
            return await task;
        }

        // для сотрудника 
        private async Task<(DataTable, Exception)> GetEmployeeProjectsData(string searchPattern = "")
        {
            string query = $@"select 
ProjectID, '' as '№', ProjectTitle as 'Наименование и назначение',  '' as 'Сотрудники',
concat(date_format(ProjectStartDate, '%d.%m.%Y'), ' - ',  date_format(ProjectPlanEndDate, '%d.%m.%Y')) as 'Сроки выполнения',
StatusTitle as 'Статус'
from project_office.project
inner join project_office.`status` on `status`.StatusID = project.ProjectStatusID
where project.ProjectStatusID not in (5,6) and ({AppUser.Id}) in (select UserID from project_office.userproject)
and ProjectTitle like '%{searchPattern}%' ";
            query += $"order by ProjectPlanEndDate asc;";
            var task = _db.ExecuteReaderAsync(query);
            return await task;
        }

        private async void UpdateProjectsTable(string searchPattern = "", string filter = "", string orderRule = "", string dateRange = "")
        {
            object res = await _db.GetAsyncReaderResult(GetProjectsData(searchPattern, filter, orderRule, dateRange));
            projectsTable.Rows.Clear();
            if (res is DataTable == false)
            {
                if (res != null) MessageBox.Show((string)res, "Обновление данных о проектах", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt = (DataTable)res;
            int i = 0;
            while (i < dt.Rows.Count)
            {
                object[] rowData = dt.Rows[i].ItemArray;
                int indx = projectsTable.Rows.Add();
                DataGridViewCellCollection columns = projectsTable.Rows[indx].Cells;
                columns["projId"].Value = rowData[0].ToString();
                columns["projName"].Value = rowData[1].ToString();
                columns["projResp"].Value = rowData[2].ToString();
                columns["projEndDate"].Value = DateTime.Parse(rowData[4].ToString()).ToString("dd.MM.yyyy"); ;
                columns["projCost"].Value = rowData[5].ToString();
                columns["projStatus"].Value = rowData[3].ToString();
                i++;
            }
        }

        private async Task<string> PrintEmployees(string  projectId)
        {
            string emplList = "";
            string[][] emplIds = await Project.GetEmployees(projectId);
            List<string> employees = new List<string>();
            string[] resps = emplIds.Where(arr => arr.Length > 1).Select(elem => elem[0]).ToArray().OrderBy(elem => elem).ToArray();
            if (resps.Length != 0) resps[resps.Length - 1] += "\n";
            else resps = new string[] { "-\n" };
            employees.AddRange(resps);
            string[] slaves = emplIds.Where(arr => arr.Length == 1).Select(elem => elem[0]).ToArray().OrderBy(elem => elem).ToArray();
            employees.AddRange(slaves);
            int indx = 0;
            while (indx < employees.Count)
            {
                if (employees[indx] == "-\n")
                {
                    indx++;
                    continue;
                }
                string temp = await Common.GetEmployee(employees[indx]);
                employees[indx] = employees[indx].Contains("\n") ? temp + "\n" : temp;
                indx++;
            }
            emplList = $"Ответственные\n{string.Join("\n", employees)}";
            return emplList;
        }

        private async void UpdateEmployeeProjectTable(string searchPattern = "")
        {
            object res = await _db.GetAsyncReaderResult(GetEmployeeProjectsData(searchPattern));
            employeeProjectTable.DataSource = new DataTable();
            if (res is DataTable == false)
            {
                if (res != null) MessageBox.Show((string)res, "Обновление данных о проектах", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt = (DataTable)res;
            DataTable dtClone = dt.Clone();
            int col = 0;
            while (col < dtClone.Columns.Count)
            {
                dtClone.Columns[col].DataType = typeof(string);
                dtClone.Columns[col].MaxLength = 256;
                col++;
            }
            int row = 0;
            while (row < dt.Rows.Count)
            {
                dtClone.ImportRow(dt.Rows[row]);
                row++;
            }

            employeeProjectTable.DataSource = dtClone;
            // 0id 1# 2title 3empl 4dates 5status
            employeeProjectTable.Columns[0].Visible = false;
            //employeeProjectTable.Columns[0].FillWeight = 0;
            employeeProjectTable.Columns[1].FillWeight = 1;
            employeeProjectTable.Columns[2].FillWeight = 5;
            employeeProjectTable.Columns[3].FillWeight = 3;
            employeeProjectTable.Columns[4].FillWeight = 2;
            employeeProjectTable.Columns[5].FillWeight = 2;

            row = 0;
            while (row < employeeProjectTable.Rows.Count)
            {
                employeeProjectTable.Rows[row].Cells[1].Value = $"{row+1}";
                employeeProjectTable.Rows[row].Cells[3].Value = await PrintEmployees(employeeProjectTable.Rows[row].Cells[0].Value.ToString());
                row++;
            }
        }

        private void SetSearchLinePlaceholder()
        {
            projectSearchLineTextBox.Text = "Поиск";
            projectSearchLineTextBox.ForeColor = Color.Gray;
        }

        private void EraseSearchLinePlaceholder()
        {
            projectSearchLineTextBox.Text = "";
            projectSearchLineTextBox.ForeColor = Color.Black;
        }

        private string ShortSnp(string snp)
        {
            string[] parts = snp.Split(' ');
            for (int i = 1; i < parts.Length; i++)
            {
                parts[i] = $"{parts[i][0]}.";
            }
            return String.Join(" ", parts).Trim(' ', '.');
        }

        private async Task<object> GetDateFromAsync(Task<(object, Exception)> task)
        {
            object res = await _db.GetAsynNonReaderResult(task);
            if (res == null) return DateTime.MinValue.ToString("g");
            if (res is string)
            {
                bool date = false;
                try
                {
                    DateTime.Parse((string)res);
                    date = true;
                }
                catch (Exception) { date = false; }
                if (!date)
                {
                    MessageBox.Show((string)res, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return DateTime.MinValue.ToString("g");
                }
            }
            return res;
        }

        private async Task<string> GetIntAsyncResult(Task<(int, Exception)> task)
        {
            object res = await _db.GetAsynNonReaderResult(task);
            if (res == null) return "";
            if (res is int && (int)res >= 0) return res.ToString();
            else
            {
                MessageBox.Show((string)res, "Ошибка получения ответственного", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private async Task<DateTime> GetEarlyStartDate()
        {
            string query = "select ProjectStartDate from project order by ProjectStartDate asc limit 1;";
            object res = await GetDateFromAsync(_db.ExecuteScalarAsync(query));
            return DateTime.Parse(res.ToString());
        }

        private async Task<DateTime> GetLastDate()
        {
            string query = "select ProjectPlanEndDate from project order by ProjectPlanEndDate desc limit 1; ";
            object res = await GetDateFromAsync(_db.ExecuteScalarAsync(query));
            return DateTime.Parse(res.ToString());
        }

        private async Task<string[]> GetResponsibleEmployees()
        {
            string query = $@"select distinct concat(`user`.UserSurname, ' ', `user`.UserName, ' ', `user`.UserPatronymic) from userproject
inner join `user` on `user`.UserID = userproject.UserID
where IsResponsible = 1;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            List<string> respResult = new List<string>();
            int i = 0;
            while (i < dt.Rows.Count)
            {
                respResult.Add(ShortSnp(dt.Rows[i][0].ToString()));
                i++;
            }
            return respResult.ToArray();
        }

        private async Task<string> GetRespUserId(string shortSnp)
        {
            string query = $@"select userproject.UserID from userproject
inner join `user` on `user`.UserID = userproject.UserID
where IsResponsible = 1 and '{shortSnp}' = concat(`user`.UserSurname, ' ', substring(`user`.UserName,1,1), '. ', substring(`user`.UserPatronymic,1,1)); ";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            return result.ToString();
        }

        private async Task<string[]> GetStatuses()
        {
            string query = $@"select StatusTitle from `status`;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            List<string> statuses = new List<string>();
            int i = 0;
            while (i < dt.Rows.Count)
            {
                statuses.Add(dt.Rows[i][0].ToString());
                i++;
            }
            return statuses.ToArray();
        }

        private async Task<string> GetStatusID(string statusName)
        {
            string query = $"select StatusID from `status` where StatusTitle = '{statusName}';";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object value, _) = await Common.GetNoScalarResult(task);
            return value.ToString();
        }

        private string GetSearchPattern()
        {
            string search = "";
            if (projectSearchLineTextBox.Text == "Поиск") return "";
            string sText = projectSearchLineTextBox.Text.Trim();
            search = sText;
            return search;
        }

        private async Task<string> GetFilterCondition()
        {
            string id = "";
            string column = "";
            if (projectFilterCombo.SelectedIndex < 1) return "";
            switch (projectFilterOnCombo.SelectedIndex)
            {
                case 1:
                    {
                        column = "userproject.UserID";
                        id = await GetRespUserId(projectFilterCombo.SelectedItem.ToString());

                        break;
                    }
                case 2: break;
                case 3:
                    {
                        column = "project.ProjectStatusID";
                        id = await GetStatusID(projectFilterCombo.SelectedItem.ToString());

                        break;
                    }
                default: break;
            }
            return ($"{column} = {id}").Trim(' ', '=');
        }

        private string GetFilterDateRange()
        {
            return $"ProjectStartDate >= '{projectStartRangeDatePicker.Value.ToString("yyyy-MM-dd")}' and ProjectPlanEndDate <= '{projectEndDatePicker.Value.ToString("yyyy-MM-dd")}'";
        }

        private string GetSortingCondition()
        {
            string sort = "";
            switch (projectSortCombo.SelectedIndex)
            {
                case 1: sort = "cost asc"; break;
                case 2: sort = "cost desc"; break;
                case 3: sort = "ProjectTitle asc"; break;
                case 4: sort = "ProjectTitle desc"; break;
                default: break;
            }
            return sort;
        }

        private async Task UpdateTable()
        {
            if (AppUser.Role == UserRole.Manager)
            {
                UpdateProjectsTable(GetSearchPattern(), await GetFilterCondition(), GetSortingCondition(), GetFilterDateRange());
            }
            else if (AppUser.Role == UserRole.Employee)
            {
                UpdateEmployeeProjectTable(GetSearchPattern());
            }
        }

        private void HideTable(bool projMngr, bool projEmpl)
        {
            TableLayoutRowStyleCollection styles = projectTablesLayout.RowStyles;
            styles[0].SizeType = SizeType.Percent;
            styles[1].SizeType = SizeType.Percent;

            if (!projMngr) styles[0].Height = 50;
            else styles[0].Height = 0;

            if (!projEmpl) styles[1].Height = 50;
            else styles[1].Height = 0;
        }

        private void HideDateFilters()
        {
            TableLayoutRowStyleCollection styles = searchLayout.RowStyles;
            styles[0].SizeType = SizeType.Percent;
            styles[1].SizeType = SizeType.Percent;

            styles[0].Height = 0;
            styles[1].Height = 50;
        }

        private async void ProjectsForm_Load(object sender, EventArgs e)
        {
            if (AppUser.Role == UserRole.Employee) 
            {
                toolStrip1.Hide();
                projectReportBtn.Hide();
                projectsTable.Hide();
                employeeProjectTable.Show();
                HideTable(projMngr: true, projEmpl: false);
                HideDateFilters();
                groupBox1.Hide();
                label1.Hide();
                projectSortCombo.Hide();
                projectResetFilterBtn.Hide();
                employeeProjectTable.Show();
            }
            else if (AppUser.Role == UserRole.Manager)
            {
                toolStrip1.Show();
                projectReportBtn.Show();
                projectsTable.Show();
                employeeProjectTable.Hide();
                HideTable(projMngr: false, projEmpl: true);
 
                DateTime minDateValue = DateTime.MinValue;
                var minDateTask = GetEarlyStartDate();
                minDateValue = await minDateTask;
                projectStartRangeDatePicker.Value = projectStartRangeDatePicker.MinDate;
                projectEndDatePicker.Value = projectEndDatePicker.MinDate;
                projectStartRangeDatePicker.MaxDate = DateTime.Now;
                projectEndDatePicker.MinDate = await GetLastDate();
                projectStartRangeDatePicker.MinDate = minDateValue;
            }
            _loading = true;
            this.Text = $"{Resources.APP_NAME}: Учёт проектов";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            this.WindowState = FormWindowState.Maximized;
            
            SetSearchLinePlaceholder();
            await UpdateTable();
            _loading = false;
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addProjectBtn_Click(object sender, EventArgs e)
        {
            ProjectEditorForm projEditor = new ProjectEditorForm();
            projEditor.ShowDialog();
            await UpdateTable();
        }

        private async void editProjectBtn_Click(object sender, EventArgs e)
        {
            string selectedId = GetSelectedProjectId();
            if (selectedId == "") return;
            ProjectEditorForm projEditor = new ProjectEditorForm(selectedId);
            projEditor.ShowDialog();
            await UpdateTable();
        }

        private void projectSearchLineTextBox_Leave(object sender, EventArgs e)
        {
            if (projectSearchLineTextBox.Text == "") SetSearchLinePlaceholder();
        }

        private void projectSearchLineTextBox_Click(object sender, EventArgs e)
        {
            if (projectSearchLineTextBox.Text == "Поиск") EraseSearchLinePlaceholder();
        }

        private async void projectSearchLineTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_loading) await UpdateTable();
        }

        private async void projectFilterOnCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectFilterCombo.Items.Clear();
            projectFilterCombo.Items.Add("Отсутствует");
            switch (projectFilterOnCombo.SelectedIndex)
            {
                case 1: projectFilterCombo.Items.AddRange(await GetResponsibleEmployees()); break;
                case 2: break;
                case 3: projectFilterCombo.Items.AddRange(await GetStatuses()); break;
                default: break;
            }
        }

        private async void projectFilterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading) await UpdateTable();
        }

        private async void projectSortCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading) await UpdateTable();
        }

        private async void projectStartRangeDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!_loading) await UpdateTable();
        }

        private async void projectEndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!_loading) await UpdateTable();
        }

        private void projectResetFilterBtn_Click(object sender, EventArgs e)
        {
            projectFilterOnCombo.SelectedIndex = 0;
            projectSortCombo.SelectedIndex = 0;
        }

        private string GetSelectedProjectId()
        {
            string selectedId = "";
            int rIndx = projectsTable.CurrentCell.RowIndex;
            if (rIndx < -1) return selectedId;
            selectedId = projectsTable.Rows[rIndx].Cells[0].Value.ToString();
            return selectedId;
        }

        private async void deleteProjectBtn_Click(object sender, EventArgs e)
        {
            string selectedId = GetSelectedProjectId();
            if (selectedId == "")
            {
                MessageBox.Show("Проект не выбран", "Удаление проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите удалить выделенный проект? Вы не сможете восстановить запись после удаления. При удалении удалятся также все связанные записи.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Project temp = await Project.InitilazeAsync(selectedId);
                int n = await temp.Delete();
                if (n != -1) MessageBox.Show($"Проект (#{selectedId}) был удалён", "Удаление проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show($"Удаление проекта (#{selectedId}) было прервано", "Удаление проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await UpdateTable();
        }

        private async void employeeProjectTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.Button == MouseButtons.Left)
            {
                employeeProjectTable.ClearSelection();
                employeeProjectTable.CurrentCell = employeeProjectTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Project proj = await Project.InitilazeAsync(employeeProjectTable.Rows[e.RowIndex].Cells[0].Value.ToString());
                SubtaskList tasksList = new SubtaskList(ref proj);
                tasksList.ShowDialog();
                await UpdateTable();
            }
        }
    }
}
