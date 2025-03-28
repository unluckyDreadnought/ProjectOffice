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

        private bool changes = false;
        bool editMode = false;
        private string clientId = "null";
        private bool[] fieldsFilled = new bool[6];

        string projId = "";
        private string placeholderName = "";
        Project proj = null;

        public ProjectEditorForm(string projectId = "")
        {
            InitializeComponent();
            projId = projectId;
            editMode = projectId != "";
        }

        private bool HaveResponsibleEmployees()
        {
            bool result = false;
            int line = 0;
            while (line < employeesTable.Rows.Count && !result)
            {
                result = Convert.ToBoolean(((DataGridViewCheckBoxCell)employeesTable.Rows[line].Cells[1]).Value);
                line++;
            }
            return result;
        }

        private void ChangeAddEditBtnState()
        {
            if (!editMode) saveProjectBtn.Enabled = fieldsFilled[0] && fieldsFilled[1] && fieldsFilled[2] && fieldsFilled[3] && fieldsFilled[4] && fieldsFilled[5];
            else saveProjectBtn.Enabled = fieldsFilled[0] && fieldsFilled[3] && fieldsFilled[4];
        }

        private async Task CompareWithDbProject()
        {
            Project dbCopy = await Project.InitilazeAsync(proj.Id);
            changes = !proj.CompareWith(dbCopy);
            dbCopy.Dispose();
        }

        private async Task CheckFieldsFilling()
        {
            fieldsFilled[0] = projectNameTextBox.Text.Trim().Length > 0;
            fieldsFilled[1] = choosenClientLbl.Text.Trim() != "клиент не выбран";
            fieldsFilled[2] = endPlanDate.Value > DateTime.Now;
            fieldsFilled[3] = stagesTable.Rows.Count > 0;
            fieldsFilled[4] = employeesTable.Rows.Count > 0 && HaveResponsibleEmployees();
            fieldsFilled[5] = projectCostTextBox.Text.Trim().Length > 3;
            ChangeAddEditBtnState();

            if (editMode)
            {
                await CompareWithDbProject();
                saveProjectBtn.Enabled = saveProjectBtn.Enabled && changes;
            }
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
                    string empId = await Common.GetEmployeeID(dgv.Rows[r].Cells[0].Value.ToString());
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

        private async Task<string> GetManagerName(string manId)
        {
            string query = $"select concat(UserSurname, ' ', substring(UserName,1,1), '.', substring(UserPatronymic,1,1)) from {Db.Name}.{Db.GetTableName(Db.Tables.User)} where UserID = {manId};";
            var task = _db.ExecuteReaderAsync(query);
            string[] name = Common.DataTableToStringArray(await Common.GetAsyncResult(task));
            return name.Length > 0 ? name[0] : "<менеджер не указан>";
        }

        private void ParseStages(List<Stage> stgList)
        {
            stagesTable.Rows.Clear();
            int indx = 0;
            while (indx < stgList.Count)
            {
                stagesTable.Rows.Add(stgList[indx].Title);
                indx++;
            }
        }

        private async Task UpdateEmployeeList(string[][] selected)
        {
            proj.EmployeesId = selected;
            if (selected.Length == 0)
            {
                employeesTable.Rows.Clear();
                return;
            }
            employeesTable.Rows.Clear();
            int set = 0;
            while (set < selected.Length)
            {
                string tUsrId = selected[set][0];
                string name = await Common.GetEmployee(tUsrId);
                if (name == null)
                {
                    set++;
                    continue;
                }
                int rIndx = employeesTable.Rows.Add();
                employeesTable.Rows[rIndx].Cells[0].Value = name;
                ((DataGridViewCheckBoxCell)employeesTable.Rows[rIndx].Cells[1]).Value = selected[set].Length > 1;
                set++;
            }
        }

        private async Task UpdateStagesList(string[][] selected)
        {
            int arr = 0;
            List<logic.Stage> selectedStages = new List<logic.Stage>();
            while (arr < selected.Length)
            {
                logic.Stage stg = await logic.Stage.GetById(selected[arr][0]);
                selectedStages.Add(stg);
                arr++;
            }
            proj.Stages = selectedStages;

            stagesTable.Rows.Clear();
            if (selected.Length == 0) return;

            int set = 0;
            while (set < selected.Length)
            {
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
                //chooseEmployeePanel.Hide();
                //chooseStagePanel.Hide();
                projectCostTextBox.Enabled = projectCostTextBox.Visible = false;
                endPlanDate.Enabled = endPlanDate.Visible = false;

                proj = await Project.InitilazeAsync(projId);
                if (proj.EndDate != null)
                {
                    chooseClientPanel.Hide();
                    chooseEmployeePanel.Hide();
                    chooseStagePanel.Hide();
                    saveProjectBtn.Enabled = saveProjectBtn.Visible = false;
                    projectNameTextBox.Enabled = false;
                    factEndDateLbl.Text = DateTime.Parse(proj.EndDate).ToString("dd.MM.yyyy");
                }
                else
                {
                    label1.Enabled = label1.Visible = false;
                    factEndDateLbl.Enabled = factEndDateLbl.Visible = false;
                }
                projectIdLbl.Text = $"Проект #{proj.Id}";
                placeholderName = projectNameTextBox.Text = proj.Title;
                startDateLbl.Text = DateTime.Parse(proj.StartDate).ToString("dd.MM.yyyy");
                planDateEditLbl.Text = DateTime.Parse(proj.PlanEndDate).ToString("dd.MM.yyyy");
                choosenClientLbl.Text = await GetClientName(proj.CustomerId);
                managerLbl.Text = await GetManagerName(proj.CreatorId);
                await UpdateEmployeeList(proj.EmployeesId);
                ParseStages(proj.Stages);
                projCostLbl.Text = proj.Cost;
            }
            else
            {
                this.Text = $"{Resources.APP_NAME}: Создание проекта";
                planDateEditLbl.Enabled = planDateEditLbl.Visible = false;
                projCostLbl.Enabled = projCostLbl.Visible = false;
                subtaskPanel.Hide();
                               
                (proj, changes) = await Project.InitilazeAsync();
                projId = proj.Id;
                proj.Title = placeholderName = $"Проект {number + 1}";
                choosenClientLbl.Text = "клиент не выбран";
                startDateLbl.Text = DateTime.Parse(proj.StartDate).ToString("dd.MM.yyyy");

                endPlanDate.MinDate = DateTime.Parse(proj.StartDate).AddDays(5);
                endPlanDate.MaxDate = DateTime.Parse(proj.StartDate).AddMonths(4);

                projectNameTextBox.Text = proj.Title;
                managerLbl.Text = await GetManagerName(proj.CreatorId);
                projectIdLbl.Text = $"Проект #{projId}";
            }
            await CheckFieldsFilling();
            subtaskBtn.Enabled = subtaskBtn.Visible = proj.Status == ((int)Status.Finish).ToString();
            if (proj.Status == ((int)Status.PreparingToEnd).ToString()) 
            {
                endProject.Text = "Завершить";
            }
            else if (proj.Status == ((int)Status.Rejected).ToString())
            {
                endProject.Text = "Договор";
            }
            endProject.Enabled = endProject.Visible = proj.Status == ((int)Status.PreparingToEnd).ToString() || proj.Status == ((int)Status.Rejected).ToString();
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
                    proj.CustomerId = clientId;
                }
                else
                {
                    choosenClientLbl.Text = "клиент не выбран";
                }
                await CheckFieldsFilling();
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
                await UpdateStagesList(selected);
            }
            await CheckFieldsFilling();
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
                await UpdateEmployeeList(selected);
            }
            await CheckFieldsFilling();
        }

        private void subtaskBtn_Click(object sender, EventArgs e)
        {
            SubtaskList tasksList = new SubtaskList(ref proj);
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

        private async void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (projectNameTextBox.Text.Trim() == "") SetProjNamePlaceholder();
            proj.Title = projectNameTextBox.Text.Trim();
            await CheckFieldsFilling();
        }

        private async void projectNameTextBox_Leave(object sender, EventArgs e)
        {
            if (projectNameTextBox.Text.Trim() == "") SetProjNamePlaceholder();
            await CheckFieldsFilling();
        }

        private void projectNameTextBox_Click(object sender, EventArgs e)
        {
            Match match = regex.Match(projectNameTextBox.Text.Trim());
            if (match.Success) EraseProjNamePlaceholder();
        }

        private async void endPlanDate_ValueChanged(object sender, EventArgs e)
        {
            proj.PlanEndDate = endPlanDate.Value.ToString("yyyy.MM.dd");
            await CheckFieldsFilling();
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

        private async void projectCostTextBox_TextChanged(object sender, EventArgs e)
        {
            proj.Cost = projectCostTextBox.Text.Trim();
            await CheckFieldsFilling();
        }

        private async void saveProjectBtn_Click(object sender, EventArgs e)
        {
            (logic.Stage[] toDelete, int n) = await proj.Save(existInDb: editMode);
            if (n == -1)
            {
                string[] delLinkedStgTitles = toDelete.Where(delStg => delStg.subtasks.Count > 0).Select(delStg => delStg.Title).ToArray();
                if (delLinkedStgTitles.Length > 0)
                {
                    string msgText = "Внесённые в проект изменения удаляют стадию (-ии), к которым уже привязаны подзадачи и контрольные точки.\n" +
                    "Удаление такой стадии удалит и связанные с ней зависимости безвозвратно.\n" +
                    "Стадии, влекущие удаление зависимостей:\n\n";
                    int delIndx = 0;
                    while (delIndx < delLinkedStgTitles.Length)
                    {
                        msgText += $"{delIndx + 1}. {delLinkedStgTitles[delIndx]}\n";
                        delIndx++;
                    }
                    msgText += "\nЕсли Вы не хотите удаления этих стадий, выберите их в окне выбора стадий.\nВы действительно хотите их удалить?";
                    if (MessageBox.Show(msgText, "Конфликт изменения проекта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        (toDelete, n) = await proj.Save(existInDb: editMode, force: true);
                        int linkedN = toDelete.Where(delStg => delStg.subtasks.Count > 0).ToArray().Length;
                        MessageBox.Show($"Проект успешно изменён. Удалено {linkedN} стадий с зависимостями.", "Изменение проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changes = false;
                        this.Close();
                        return;
                    }
                }
                else
                {
                    (toDelete, n) = await proj.Save(existInDb: editMode, force: true);
                }
            }
            if (n >= 0)
            {
                string[][] titles = new string[][] { new string[] { "добавлен", "Создание проекта" }, new string[] { "изменён", "Изменение" } };
                string[] curTitle = editMode ? titles[1] : titles[0];
                MessageBox.Show($"Проект успешно {curTitle[0]}", $"{curTitle[1]} проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                changes = false;

                string baseSavePath = "";
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fileDialog.Filter = "Документ Word (*.docx)|*.docx";
                fileDialog.DefaultExt = "docx";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (fileDialog.FileName != "") baseSavePath = fileDialog.FileName;
                }
                Reports.SetBasePath(baseSavePath);
                MessageBox.Show($"Файл будет сохранён по пути '{Reports.baseSavePath}'", "Сохранение отчёта Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (string text, bool isError) = await Reports.MakeDevelopmentDealDocument(proj, Reports.baseSavePath);
                if (text != null && isError)
                {
                    MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
        }


        // Обработчик нажатия на кнопку выхода из редактора ("К списку")
        private async void backToProjectListBtn_Click(object sender, EventArgs e)
        {
            if (changes)
            {
                DialogResult msgResult = MessageBox.Show("Вы уверены, что хотите перейти к списку проектов и отменить изменения в новом проекте?", "Новый проект", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    if (!editMode)
                    {
                        int n = await proj.Delete();
                        if (n == -1) MessageBox.Show("Не удалось провести удаление проекта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }
            }
            else this.Close();
        }

        private async void ProjectEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changes)
            {
                if (!editMode)
                {
                    int n = await proj.Delete();
                    if (n == -1) MessageBox.Show("Не удалось провести удаление проекта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void endProject_Click(object sender, EventArgs e)
        {
            switch (endProject.Text)
            {
                case "Договор":
                    {

                        break;
                    }
                case "Завершить":
                    {

                        break;
                    }
            }
        }
    }
}
