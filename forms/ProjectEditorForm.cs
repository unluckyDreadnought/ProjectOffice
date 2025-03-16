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
        Regex regex = new Regex(@"^Проект \d+$");

        private bool tempProject = false;
        bool editMode = false;
        private string clientId = "null";

        string projId = "";
        string tempId = "";
        private string projName = "";
        private string placeholderName = "";

        public ProjectEditorForm(string projectId = "")
        {
            InitializeComponent();
            projId = projectId;
            editMode = projectId != "";
            tempId = (editMode) ? projId : "0";
        }

        private void CheckFieldsFilling()
        {

        }

        /// <summary>
        /// Получение номера последнего шаблонного имени проекта
        /// </summary>
        /// <returns>Возвращает целое число - номер из последнего шаблонного имени проекта "Проект n"</returns>
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

        /// <summary>
        /// Получение целочисленного результата из асинхронного запроса, выполненного методом ExecuteNoQuery или ExecuteScalar
        /// </summary>
        /// <param name="task">Асинхронная операция, возвращающая целое число и описание ошибки (при наличии)</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую целочисленное значение</returns>
        private async Task<int> GetNoScalarResult(Task<(int, string)> task)
        {
            (int affected, string msg) = await task;
            if (msg != null)
            {
                MessageBox.Show($"Описание ошибки:\n{msg}", "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return affected;
        }

        /// <summary>
        /// Создание временного (несохранённого) проекта с id = 0 
        /// </summary>
        /// <returns>Возвращает асинхронную операцию, возвращающую целое число и описание ошибки (при наличии)</returns>
        private async Task<(int, string)> CreateTempProject()
        {
            string query = $@"set session sql_mode='NO_AUTO_VALUE_ON_ZERO';
insert into {Db.Name}.project value (0, 1, 1, {AppUser.Id}, '{projName}', '{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("yyyy-MM-dd")}', null, '0', 0);";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        /// <summary>
        /// Обновляет запись проекта в базе данных переданными данными
        /// </summary>
        /// <param name="projectID">Идентификатор обновляемого проекта</param>
        /// <param name="columnName">Обновляемое поле</param>
        /// <param name="value">Новое значение</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую целое число и описание ошибки (при наличии)</returns>
        private async Task<(int, string)> UpdateProject(string projectID, string columnName, string value)
        {
            string query = $"update {Db.Name}.project set project.{columnName} = {value} where ProjectID = {projectID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        /// <summary>
        /// Удаляет проект из базы данных
        /// </summary>
        /// <param name="projectID">Идентификатор удаляемого проекта</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую целое число и описание ошибки (при наличии)</returns>
        private async Task<(int, string)> DeleteProject(string projectID)
        {
            string query = $"delete from {Db.Name}.project where ProjectID = {projectID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        /// <summary>
        /// Получает уникальный ключ (идентификатор) последнего проекта
        /// </summary>
        /// <returns>Возвращает асинхронную операцию, возвращающую целое число (идентификатор)</returns>
        private async Task<int> GetLastProjID()
        {
            string query = $"SELECT ProjectID FROM {Db.Name}.project order by ProjectID DESC limit 1;";
            (object value, Exception e) = await _db.ExecuteScalarAsync(query);
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

        /// <summary>
        /// Вставляет шаблонное имя проекта как placeholder
        /// </summary>
        private void SetProjNamePlaceholder()
        {
            projectNameTextBox.ForeColor = Color.Gray;
            projectNameTextBox.Text = placeholderName;
        }

        /// <summary>
        /// Очищает шаблонное имя проекта и восстанавливает обычный цвет текста
        /// </summary>
        private void EraseProjNamePlaceholder()
        {
            projectNameTextBox.Text = "";
            projectNameTextBox.Clear();
            projectNameTextBox.ForeColor = Color.Black;
        }

        /// <summary>
        /// Преобразует записи из таблиц в формат, понятный форме ChooseForm для восстановления выбора
        /// </summary>
        /// <param name="mode">Значение перечисления <see cref="ChooseMode"></see>, описывающее тип объектов из таблицы</param>
        private async Task<string[][]> FormatDataFromTable(ChooseMode mode)
        {
            List<string[]> formatted = new List<string[]>();
            int r = 0;
            DataGridView dgv = null;
            if (mode == ChooseMode.Employee) dgv = employeesTable;
            else if (mode == ChooseMode.Stages) dgv = stagesTable;
            while (r < dgv.Rows.Count)
            {
                if (mode == ChooseMode.Employee)
                {
                    string empId = await GetEmployeeID(dgv.Rows[r].Cells[0].Value.ToString());
                    if (empId == null)
                    {
                        r++;
                        continue;
                    }
                    bool resp = Convert.ToBoolean(((DataGridViewCheckBoxCell)dgv.Rows[r].Cells[1]).Value);
                    formatted.Add(resp ? new string[] { empId, "1" } : new string[] { empId });
                }
                else if (mode == ChooseMode.Stages)
                {
                    string stgId = await GetStageId(dgv.Rows[r].Cells[0].Value.ToString());
                    if (stgId != null) formatted.Add(new string[] { stgId });
                }
                r++;
            }
            return formatted.ToArray();
            
        }

        /// <summary>
        /// Получает имя клиента по его идентификатору
        /// </summary>
        /// <param name="clientID">Идентификатор клиента</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую строку - имя клиента</returns>
        private async Task<string> GetClientName(string clientID)
        {
            string query = $@"select case when ClientOrgTypeID is null then ClientName else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`
from {Db.Name}.client where ClientID = {clientID}; ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt.Rows[0].ItemArray[0].ToString();
        }

        /// <summary>
        /// Получает имя сотрудника по его идентификатору
        /// </summary>
        /// <param name="usrID">Идентификатор сотрудника</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую строку - имя сотрудника</returns>
        private async Task<string> GetEmployee(string usrID)
        {
            string query = $@"select concat(UserSurname, ' ', substring(UserName, 1, 1), '. ', case when UserPatronymic is null then '' else substring(UserPatronymic, 1, 1) end)  as 'Name' from {Db.Name}.`user` where UserID = {usrID};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string employeeName = (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
            return employeeName;
        }

        /// <summary>
        /// Получает идентификатор сотрудника по его сокращённому ФИО
        /// </summary>
        /// <param name="shortSnp">Сокращённое ФИО сотрудника</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую строку - идентификатор сотрудника</returns>
        private async Task<string> GetEmployeeID(string shortSnp)
        {
            string query = $@"select UserID from {Db.Name}.`user` where concat(UserSurname, ' ', substring(UserName, 1, 1), '. ', case when UserPatronymic is null then '' else substring(UserPatronymic, 1, 1) end) = '{shortSnp}';";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string eId = (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
            return eId;
        }

        private async Task<string[]> GetUsersInProject(string projID)
        {
            string query = $"select UserID from {Db.Name}.userproject where ProjectID = {projID};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count <= 0) return null;
            List<string> ids = new List<string>();
            int n = 0;
            while (n < dt.Rows.Count)
            {
                ids.Add(dt.Rows[n][0].ToString());
                n++;
            }
            return ids.ToArray();
        }

        private async Task<(int, string)> AddUserToProject(string projID, string usrID, bool responsible)
        {
            string resp = responsible ? "1" : "0";
            string query = $@"insert into {Db.Name}.userproject value ({usrID}, {projID}, {resp});";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        private async Task<(int, string)> RemoveUserFromProject(string projID, string usrID)
        {
            string query = $@"delete from {Db.Name}.userproject where UserID = {usrID} and ProjectID = {projID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        private async Task<(int, string)> RemoveAllUsersFromProject(string projID)
        {
            string query = $@"delete from {Db.Name}.userproject where ProjectID = {projID};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        private async Task<DataTable> GetStageTitle(string stageId)
        {
            string query = $"select StageTitle from {Db.Name}.stage where StageID = {stageId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt;
        }

        private async Task<string> GetStageId(string stageTitle)
        {
            string query = $"select StageID from {Db.Name}.stage where StageTitle = '{stageTitle}';";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return (dt.Rows.Count > 0) ? dt.Rows[0][0].ToString() : null;
        }

        /// <summary>
        /// Получает идентификаторы всех включённых в проект стадий
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns></returns>
        private async Task<string[]> GetStagesInProject(string projectId)
        {
            string query = $"select StageID from {Db.Name}.stage_in_project where ProjectID = {projectId}";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count <= 0) return null;
            List<string> ids = new List<string>();
            int n = 0;
            while (n < dt.Rows.Count)
            {
                ids.Add(dt.Rows[n][0].ToString());
                n++;
            }
            return ids.ToArray();
        }

        /// <summary>
        /// Получает идентификатор записи в связующей таблице стадий и проектов
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является массив идентификаторов при успехе, иначе - пустой массив</returns>
        private async Task<string[]> GetStageLink(string projectId, string stageId)
        {
            string query = $"select StgLinkID from {Db.Name}.stage_in_project where ProjectID = {projectId} and StageID = {stageId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы всех стадий в связующей таблице, включённых в данный проект
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является массив идентификаторов при успехе, иначе - пустой массив</returns>
        private async Task<string[]> GetStageLink(string projectId)
        {
            string query = $"select StgLinkID from {Db.Name}.stage_in_project where ProjectID = {projectId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает последнее значение идентификатора в связующей таблице стадий и проекта
        /// </summary>
        /// <returns>Возвращает асинхронную операцию, результатом которой является последний занятый идентификатор при успехе, иначе - null</returns>
        private async Task<string> GetLastStageLink()
        {
            string query = $"select StgLinkID from {Db.Name}.stage_in_project order by StgLinkID DESC limit 1;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count <= 0) return null;
            return dt.Rows[0][0].ToString();
        }

        private async Task<(int,string)> AddStageToProject(string projectId, string stageId, string forceId = "null")
        {
            string query = $"insert into {Db.Name}.stage_in_project value ({forceId},{projectId}, {stageId});";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        /// <summary>
        /// Удаляет стадию из проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <returns>Возвращает асинхронную опрерацию, результатом которой является число удалённых записей и null в случае успеха, иначе -1 и сообщение ошибки</returns>
        private async Task<(int,string)> RemoveStageFromProject(string projectId, string stageId)
        {
            string query = $"delete from {Db.Name}.stage_in_project where ProjectID = {projectId} and StageID = {stageId};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        /// <summary>
        /// Удаляет все стадии из проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns>Возвращает асинхронную опрерацию, результатом которой является число удалённых записей и null в случае успеха, иначе -1 и сообщение ошибки</returns>
        private async Task<(int, string)> RemoveAllStagesFromProject(string projectId)
        {
            string[] linkIds = await GetStageLink(projectId);
            if (linkIds.Length == 0) return (0, null);
            string query = $"delete from {Db.Name}.stage_in_project where StgLinkID >= {linkIds.First()} and StgLinkID <= {linkIds.Last()};";
            object response = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            if (response is string) return (-1, response.ToString());
            else return (Convert.ToInt32(response.ToString()), null);
        }

        #region event_handlers

        // Обработчик загрузки формы редактора проекта
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
                projId = $"{await GetLastProjID() + 1}";
                choosenClientLbl.Text = "клиент не выбран";
                projCostLbl.Enabled = projCostLbl.Visible = false;
                subtaskPanel.Hide();
                startDateLbl.Text = DateTime.Now.ToString("dd.MM.yyyy");
                endPlanDate.MinDate = DateTime.Now.AddDays(5);
                endPlanDate.MaxDate = DateTime.Now.AddMonths(4);
                placeholderName = projName = $"Проект {number + 1}";
                projectNameTextBox.Text = projName;
                await GetNoScalarResult(CreateTempProject());
            }
            managerLbl.Text = AppUser.Snp;
            startDateLbl.Text = DateTime.Now.ToString("dd.MM.yyyy");
            projectIdLbl.Text = $"Проект #{projId}";

        }

        // Обработчик нажатия на кнопку выбора клиента-заказчика проекта
        private async void chooseClientBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Client);
            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                string[][] choosen = chooseForm.SelectedIndexes.ToArray();
                clientId = choosen.Length > 0 ? choosen[0][0] : "null";
                choosenClientLbl.Text = clientId != "null" ? $"{await GetClientName(clientId)}" : choosenClientLbl.Text;
                if (!editMode && clientId != "null")
                {
                    int n = await GetNoScalarResult(UpdateProject(tempId, "ProjectCustomerID", clientId));
                }
                else
                {
                    // возможно стоит убрать
                    choosenClientLbl.Text = "клиент не выбран";
                }
            }
        }

        // Обработчик нажатия на кнопку выбора этапов проекта
        private async void chooseStagesBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = null;
            if (stagesTable.Rows.Count == 0) chooseForm = new ChooseForm(ChooseMode.Stages);
            // альтернативный вариант выбор назначенных с прошлого раза
            else
            {
                string[][] formatted = await FormatDataFromTable(ChooseMode.Stages);
                chooseForm = new ChooseForm(ChooseMode.Stages, formatted);
            }

            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                string[][] selected = chooseForm.SelectedIndexes.ToArray();
                if (selected.Length == 0)
                {
                    int vtemp = await GetNoScalarResult(RemoveAllStagesFromProject(tempId));
                    stagesTable.Rows.Clear();
                    return;
                }
                string nStgLnkId = await GetLastStageLink();
                int n = await GetNoScalarResult(RemoveAllStagesFromProject(tempId));
                stagesTable.Rows.Clear();

                int temp = 0;
                int.TryParse(nStgLnkId, out temp);
                nStgLnkId = (nStgLnkId != null) ? $"{temp + 1}" : "null";

                int set = 0;

                while (set < selected.Length)
                {
                    if (nStgLnkId != "null")
                    {
                        int.TryParse(nStgLnkId, out temp);
                        nStgLnkId = $"{temp + set}";
                    }
                    n = await GetNoScalarResult(AddStageToProject(tempId, selected[set][0], nStgLnkId));
                    int indx = stagesTable.Rows.Add();
                    DataTable dt = await GetStageTitle(selected[set][0]);
                    if (dt.Rows.Count <= 0)
                    {
                        set++;
                        continue;
                    }
                    stagesTable.Rows[indx].Cells[0].Value = dt.Rows[0][0].ToString();
                    set++;
                }
                ;
            }
        }

        private async void chooseEmployeesBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = null;
            if (employeesTable.Rows.Count == 0) chooseForm = new ChooseForm(ChooseMode.Employee);
            // альтернативный вариант выбор назначенных с прошлого раза
            else
            {
                string[][] formatted = await FormatDataFromTable(ChooseMode.Employee);
                chooseForm = new ChooseForm(ChooseMode.Employee, formatted);
            }

            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                string[][] selected = chooseForm.SelectedIndexes.ToArray();
                if (selected.Length == 0)
                {
                    int vtemp = await GetNoScalarResult(RemoveAllUsersFromProject(tempId));
                    employeesTable.Rows.Clear();
                    return;
                }
                int n = await GetNoScalarResult(RemoveAllUsersFromProject(tempId));
                employeesTable.Rows.Clear();
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
                    n = await GetNoScalarResult(AddUserToProject(tempId, tUsrId, selected[set].Length > 1));
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

        private void projectNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Symbols.ru_alp + Symbols.en_alp + " (-,.)").Contains(Char.ToLower(e.KeyChar)) || Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 127)
            {
                if (projectNameTextBox.Text.EndsWith(".") || projectNameTextBox.Text.EndsWith(". ")) e.KeyChar = Char.ToUpper(e.KeyChar);
                return;
            }
            else e.Handled = true;
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

        private void endPlanDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void employeesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }

        private void projectCostTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || (projectCostTextBox.Text.Length != 0 && e.KeyChar == '0') || (!projectCostTextBox.Text.Contains(".") && e.KeyChar == '.') || e.KeyChar == 8 || e.KeyChar == 127)
            {
                return;
            }
            else e.Handled = true;
        }

        private void projectCostTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        // Обработчик нажатия на кнопку выхода из редактора ("К списку")
        private async void backToProjectListBtn_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                DialogResult msgResult = MessageBox.Show("Вы уверены, что хотите перейти к списку проектов и отменить изменения в новом проекте?", "Новый проект", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    int affected = await GetNoScalarResult(RemoveAllUsersFromProject(tempId));
                    affected = await GetNoScalarResult(RemoveAllStagesFromProject(tempId));
                    await GetNoScalarResult(DeleteProject(tempId));
                    this.Close();
                }
            }
            else this.Close();
        }

        #endregion
    }
}
