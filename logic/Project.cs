using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ProjectOffice.logic.app;

namespace ProjectOffice.logic
{
    public class ControlPoint
    {
        private static Db _db = new Db();
        public string Id;
        public string AuthorId;
        public string CreatedTime;
        public string Title;
        public string Description;
        public string StatusId;
        private bool _disposed = false;

        public static async Task<List<ControlPoint>> GetControlPoints(string projectId, string stageId, string subtaskId)
        {
            string sbtskLink = await Subtask.GetSubtaskLinkID(projectId, stageId, subtaskId);
            string query = $@"select control_point_to_subtask.ControlPointID, ControlPointDateTime, ControlPointAuthorID, 
ControlPointTitle, ControlPointDescription, controlpoint.StatusID from {Db.Name}.control_point_to_subtask
inner join controlpoint on controlpoint.ControlPointID = control_point_to_subtask.ControlPointID
where SbtskReferenceID = {sbtskLink};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return new List<ControlPoint>();
            string[][] rawInfo = Common.MultiColumnDataTableToStringArray(dt);
            List<ControlPoint> result = new List<ControlPoint>();
            int row = 0;
            while (row < rawInfo.Length)
            {
                ControlPoint current = new ControlPoint();
                current.Id = rawInfo[row][0];
                current.CreatedTime = rawInfo[row][1];
                current.AuthorId = rawInfo[row][2];
                current.Title = rawInfo[row][3];
                current.Description = rawInfo[row][4];
                current.StatusId = rawInfo[row][5];
                result.Add(current);
                row++;
            }
            return result;
        }

        /// <summary>
        /// Получает идентификатор записи в связующей таблице для конкретной контрольной точки проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <param name="subtaskId">Идентификатор подзадачи</param>
        /// <param name="controlPointId">Идентификатор контрольной точки</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является строка с идентификатором записи</returns>
        public static async Task<string> GetContolPointLinkID(string projectId, string stageId, string subtaskId, string controlPointId)
        {
            string sbtskLink = await Subtask.GetSubtaskLinkID(projectId, stageId, subtaskId);
            if (sbtskLink == null) return null;
            string query = $@"select CntrPntLinkId from {Db.Name}.control_point_to_subtask
where SbtskReferenceID = {sbtskLink} and ControlPointID = {controlPointId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
        }

        /// <summary>
        /// Получает идентификаторы всех записей в связующей таблице контрольных точек проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификатором записи</returns>
        public static async Task<string[]> GetControlPointLinkIDs(string projectId)
        {
            string query = $@"select CntrPntLinkId from {Db.Name}.control_point_to_subtask
where SbtskReferenceID in 
(select SbtskLinkID from {Db.Name}.subtask_in_project_stage 
where StgProjReferenceID in 
(select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId}));";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы всех записей в связующей таблице контрольных точек конкретной стадии проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификатором записи</returns>
        public static async Task<string[]> GetControlPointLinkIDs(string projectId, string stageId)
        {
            string query = $@"select CntrPntLinkId from {Db.Name}.control_point_to_subtask
where SbtskReferenceID in 
(select SbtskLinkID from {Db.Name}.subtask_in_project_stage 
where StgProjReferenceID in 
(select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId} and StageID = {stageId}));";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы всех записей в связующей таблице контрольных точек конкретной подзадачи проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <param name="subtaskId">Идентификатор подзадачи</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификатором записи</returns>
        public static async Task<string[]> GetControlPointLinkIDs(string projectId, string stageId, string subtaskId)
        {
            string sbtskLink = await Subtask.GetSubtaskLinkID(projectId, stageId, subtaskId);
            if (sbtskLink == null) return new string[] { };
            string query = $@"select CntrPntLinkId from {Db.Name}.control_point_to_subtask
where SbtskReferenceID = {sbtskLink};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы всех записей в связующей таблице контрольных точек по идентификатору контрольной точки
        /// </summary>
        /// <param name="controlPointIds">Идентификатор (-ы) контрольной (-ых) точки (-чек)</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификатором записи</returns>
        public static async Task<string[]> GetControlPointLinkIDs(params string[] controlPointIds)
        {
            string query = $@"select CntrPntLinkID from project_office.control_point_to_subtask
where ControlPointID in ({string.Join(",",controlPointIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получение всех идентификаторов контрольных точек из связующих записей с определёнными идентификаторами
        /// </summary>
        /// <param name="cntrPntLinkIds">Идентификатор (-ы) записи (-ей) из связующей таблицы</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификатором котрольной точки</returns>
        public static async Task<string[]> GetControlPointIDs(params string[] cntrPntLinkIds)
        {
            string query = $@"select ControlPointID from {Db.Name}.control_point_to_subtask
where CntrPntLinkID in ({string.Join(",", cntrPntLinkIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Удаление из БД контрольных точек с определённым идентификатором
        /// </summary>
        /// <param name="controlPointIds">Идентификатор (-ы) контрольной (-ых) точки (-ек)</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является (число изменённых строк или -1; true)</returns>
        public static async Task<(object, bool)> Delete(params string[] controlPointIds)
        {
            string[] ctnrPntsLinks = await ControlPoint.GetControlPointLinkIDs(controlPointIds);
            if (ctnrPntsLinks.Length == 0) return (-1, true);

            string query = $@"delete from {Db.Name}.control_point_to_subtask where ControlPointID in ({string.Join(",", controlPointIds)});";
            var task = _db.ExecuteNoDataResultAsync(query);
            (object affected, bool isInt) =  await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task));
            int res0 = Convert.ToInt32(affected);
            if (res0 == -1) return (-1, true);

            query = $@"delete from {Db.Name}.controlpoint where ControlPointId in ({string.Join(",", controlPointIds)});";
            task = _db.ExecuteNoDataResultAsync(query);
            (affected, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task));
            int res1 = Convert.ToInt32(affected);
            if (res1 == -1) return (-1, true);
            return (res0 + res1, true);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Id = null;
                AuthorId = null;
                CreatedTime = null;
                Title = null;
                Description = null;
                StatusId = null;
                GC.SuppressFinalize(this);
                _disposed = true;
            }
            _disposed = false;
        }
    }

    public class Subtask
    {
        private static Db _db = new Db();
        public string Id;
        private string StageId;
        public string Title;
        public string Description;
        public List<ControlPoint> points = null;
        private bool _disposed = false;

        public static async Task<List<Subtask>> GetSubtasks(string projectId, string stageId)
        {
            string stgsLink = await Stage.GetStageLinkID(projectId, stageId);
            if (stgsLink == null) return new List<Subtask>();
            string query = $@"select subtask_in_project_stage.SubtaskId, SubtaskTitle, SubtaskDescription from {Db.Name}.subtask_in_project_stage
inner join subtask on subtask.SubtaskID = subtask_in_project_stage.SubtaskID
where StgProjReferenceID = {stgsLink[0]};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return new List<Subtask>();
            string[][] raw = Common.MultiColumnDataTableToStringArray(dt);
            List<Subtask> result = new List<Subtask>();
            int row = 0;
            while (row < raw.Length)
            {
                Subtask current = new Subtask();
                current.Id = raw[row][0];
                current.StageId = stageId;
                current.Title = raw[row][0];
                current.Description = raw[row][0];
                current.points = await ControlPoint.GetControlPoints(projectId, stageId, current.Id);
                row++;
            }
            return result;
        }

        public static async Task<string> GetSubtaskLinkID(string projectId, string stageId, string subtaskId)
        {
            string stgsLink = await Stage.GetStageLinkID(projectId, stageId);
            if (stgsLink == null) return null;
            string query = $@"select SbtskLinkID from {Db.Name}.subtask_in_project_stage
where StgProjReferenceID = {stgsLink} and SubtaskId = {subtaskId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
        }

        /// <summary>
        /// Получает все идентификаторы записей из связующей таблицы подзадач к конкретному проекту
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами записей</returns>
        public static async Task<string[]> GetSubtaskLinkIDs(string projectId)
        {
            string query = $@"select SbtskLinkId from {Db.Name}.subtask_in_project_stage
where StgProjReferenceID in
(select StgLinkID from project_office.stage_in_project
where ProjectID = {projectId}); ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает все идентификаторы записей из связующей таблицы подзадач к конкретной стадии
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами записей</returns>
        public static async Task<string[]> GetSubtaskLinkIDs(string projectId, string stageId)
        {
            string query = $@"select SbtskLinkId from {Db.Name}.subtask_in_project_stage
where StgProjReferenceID in
(select StgLinkID from project_office.stage_in_project
where ProjectID = {projectId} and StageID = {stageId}); ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает все идентификаторы записей из связующей таблицы подзадач по идентификатору подзадачи
        /// </summary>
        /// <param name="subtaskIds">Идентификатор (-ы) подзадач (-и)</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами записей</returns>
        public static async Task<string[]> GetSubtaskLinkIDs(params string[] subtaskIds)
        {
            string query = $@"select SbtskLinkID from {Db.Name}.subtask_in_project_stage
where SubtaskID in ({string.Join(",", subtaskIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        public static async Task<string[]> GetSubtaskIDs(params string[] sbtskLinkIds)
        {
            string query = $@"select SubtaskID from {Db.Name}.subtask_in_project_stage 
where SbtskLinkID in ({string.Join(",", sbtskLinkIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        // to do: add cp & update cp

        public static async Task<(object, bool)> Delete(params string[] subtaskIds)
        {
            string[] sbtskLinks = await Subtask.GetSubtaskLinkIDs(subtaskIds);
            if (sbtskLinks.Length == 0) return (0, true);

            // получение идентификаторов записей связующей таблицы контрольных точек с проектом
            string query = $@"select ControlPointID from {Db.Name}.control_point_to_subtask
where SbtskReferenceID in ({string.Join(",", sbtskLinks)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string[] controlPoints = Common.DataTableToStringArray(dt);

            int total = 0;
            //удаление зависимостей от контрольных точек и контрольных точек
            string[] cntrPtsLinks = await ControlPoint.GetControlPointLinkIDs(controlPoints);
            (object n, bool isInt) = await ControlPoint.Delete(controlPoints);
            int temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total = temp;

            // удаление зависимостей от подзадач
            query = $@"delete from {Db.Name}.subtask_in_project_stage
where SbtskLinkID in ({string.Join(",", sbtskLinks)});";
            var task2 = _db.ExecuteNoDataResultAsync(query);
            (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task2));
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total += temp;

            // удаление подзадач
            query = $@"delete from {Db.Name}.subtask
where SubtaskID in ({string.Join(",", subtaskIds)});";
            task2 = _db.ExecuteNoDataResultAsync(query);
            (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task2));
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);

            total += temp;
            return (total, true);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Id = null;
                Title = null;
                Description = null;
                points.Clear();
                points = null;
                GC.SuppressFinalize(this);
                _disposed = true;
            }
            _disposed = false;
        }
    }

    public class Stage
    {
        private static Db _db = new Db();
        public string Id;
        private string ProjectId;
        public string Title;
        public List<Subtask> subtasks = null;
        private bool _disposed = false;

        public static async Task<List<Stage>> GetStages(string projectId)
        {
            string query = $@"select stage_in_project.StageID, StageTitle from {Db.Name}.stage_in_project 
inner join stage on stage.StageID = stage_in_project.StageID
where ProjectID = {projectId}; ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return new List<Stage>();
            string[][] rawInfo = Common.MultiColumnDataTableToStringArray(dt);
            List<Stage> result = new List<Stage>();
            int row = 0;
            while (row < rawInfo.Length)
            {
                Stage current = new Stage();
                current.Id = rawInfo[row][0];
                current.ProjectId = projectId;
                current.Title = rawInfo[row][1];
                current.subtasks = await Subtask.GetSubtasks(projectId, current.Id);
                result.Add(current);
                row++;
            }
            return result;
        }

        public static async Task<string> GetStageLinkID(string projectId, string stageId)
        {
            string query = $@"select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId} and stage_in_project.StageID = {stageId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
        }

        public static async Task<string[]> GetStageLinkIDs(string projectId)
        {
            string query = $@"select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        public static async Task<string[]> GetStageLinkIDs(string projectId, params string[] stageIds)
        {
            string query = $@"select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId} and StageID in ({string.Join(",", stageIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        public static async Task<string[]> GetStageIDs(params string[] stgLinkIds)
        {
            string query = $@"select StageID from {Db.Name}.stage_in_project where StgLinkID in ({string.Join(",", stgLinkIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        public async Task<int> AddSubtask(string title, string description)
        {
            string query = $@"insert into {Db.Name}.subtask value (null, {title});
select SubtaskID from {Db.Name}.subtask order by SubtaskID DESC limit 1";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            if (res == -1) return -1;

            string desc = (description != null) ? description : "null";
            query = $"insert into {Db.Name}.subtask_in_project_stage value (null, {await GetStageLinkID(this.ProjectId, this.Id)}, {res}, {desc});";
            var task2 = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (result, _) = await Common.GetNoScalarResult(task2);
            res = Convert.ToInt32(result);
            if (res == -1) return -1;

            this.subtasks = await Subtask.GetSubtasks(this.ProjectId, await GetStageLinkID(this.ProjectId, this.Id));
            return res;
        }

        public async Task<int> UpdateSubtask(string sbtskRefId, string description)
        {
            string query = $"update {Db.Name}.subtask_in_project_stage set SubtaskDescription = '{description}' where SbtskLinkID = {sbtskRefId};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            this.subtasks = await Subtask.GetSubtasks(this.ProjectId, await GetStageLinkID(this.ProjectId, this.Id));
            return res;
        }

        public static async Task<(object, bool)> Delete(string projectId, params string[] stageIds)
        {
            string[] stgLinks = await Stage.GetStageLinkIDs(projectId, stageIds);
            if (stgLinks.Length == 0) return (-1, true);

            string query = $@"select SubtaskID from {Db.Name}.subtask_in_project_stage
where StgProjReferenceID in ({string.Join(",", stgLinks)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string[] subtasksIds = Common.DataTableToStringArray(dt);

            (object affected, bool isInt) = await Subtask.Delete(subtasksIds);
            int temp = Convert.ToInt32(affected);

            if (temp != -1) return (-1, true);
            int total = temp;

            query = $@"delete from {Db.Name}.stage_in_project where StgLinkId in ({string.Join(",", stgLinks)});";
            var taks2 = _db.ExecuteNoDataResultAsync(query);
            (affected, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(taks2));
            temp = Convert.ToInt32(affected);

            if (temp != -1) return (-1, true);
            total += temp;

            return (total, true);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Id = null;
                Title = null;
                subtasks.Clear();
                subtasks = null;
                GC.SuppressFinalize(this);
                _disposed = true;
            }
            _disposed = false;
        }
    }

    public class Project
    {
        protected static Db _db = new Db();
        public string Id;
        public string Title;
        public string StartDate { get; private set; }
        public string PlanEndDate { get; private set; }
        public string EndDate { get; private set; }
        public string CustomerId { get; private set; }
        public string CreatorId { get; private set; }
        public string Coefficient { get; private set; }
        public string Cost { get; private set; }
        public string Status;
        public List<Stage> Stages { get; set; }
        public string[][] EmployeesId = null;

        private Project(string id, string title, string start, string endPlan, string customer, string creator, string coff, string cost, string status, List<Stage> stages, string[][] employees)
        {
            Id = id;
            Title = title;
            StartDate = start;
            PlanEndDate = endPlan;
            CustomerId = customer;
            CreatorId = creator;
            Coefficient = coff;
            Status = status;
            int iCost = Convert.ToInt32(cost);
            int iCoef = Convert.ToInt32(coff);
            Cost = $"{Math.Round((float)iCost * (1 + (iCoef / 100)), 2)}";
            Stages = new List<Stage>();
            EmployeesId = new string[][] { };
        }

        public async static Task<Project> InitilazeAsync()
        {
            string id = $"{await GetLastProjID() + 1}";
            string title = $"Проект {await GetLastStandardNameNumber()}";
            string start = DateTime.Now.ToString("yyyy.MM.dd");
            string creator = AppUser.Id;
            string coef = "0";
            List<Stage> stgs = new List<Stage>();
            string[][] empl = new string[][] { };
            Project proj = new Project(id, title, start, null, null, creator, coef, null, "1", stgs, empl);
            await Project.Add(proj);
            return proj;
        }

        public async static Task<Project> InitilazeAsync(string id)
        {
            string[] info = await GetExistingProjectInfo(id);
            List<Stage> stgs = await Stage.GetStages(id);
            string[][] empl = await GetEmployees(id);
            return new Project(id, title: info[0], start: info[1], endPlan: info[2], customer: info[3], creator: info[4], coff: info[5], cost: info[6], status: info[7], stgs, empl);
        }

        /// <summary>
        /// Получает уникальный ключ (идентификатор) последнего проекта
        /// </summary>
        /// <returns>Возвращает асинхронную операцию, возвращающую целое число (идентификатор)</returns>
        private static async Task<int> GetLastProjID()
        {
            string query = $"SELECT ProjectID FROM {Db.Name}.project order by ProjectID DESC limit 1;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count > 0)
            {
                int last = 0;
                int.TryParse(dt.Rows[0].ItemArray[0].ToString(), out last);
                return last;
            }
            else return 0;
        }

        /// <summary>
        /// Получение номера последнего шаблонного имени проекта
        /// </summary>
        /// <returns>Возвращает целое число - номер из последнего шаблонного имени проекта "Проект n"</returns>
        private static async Task<int> GetLastStandardNameNumber()
        {
            string query = $"select ProjectTitle from {Db.Name}.project where ProjectTitle like '%Проект %' order by ProjectTitle DESC limit 1;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return 0;
            int num = 0;
            int.TryParse(dt.Rows[0].ItemArray[0].ToString().Split(' ')[1].Trim(' ', ':', '.'), out num);
            return num;
        }

        /// <summary>
        /// Получает информацию о существующем в БД проекте (Название, Дата начала, Дата окончания (план), Клиент, Создатель, Коэффициет, Стоимость)
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Возвращает массив строк</returns>
        private static async Task<string[]> GetExistingProjectInfo(string id)
        {
            string query = $@"select 
ProjectTitle, ProjectStartDate, ProjectPlanEndDate, ProjectCustomerID, 
ProjectCreatorID, ProjectCoefficient, ProjectCost, ProjectStatusID
from {Db.Name}.project where ProjectID = {id}; ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        private static async Task<string[][]> GetEmployees(string id)
        {
            string query = $"select UserId, IsResponsible from {Db.Name}.userproject where ProjectID = {id};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string[][] raw = Common.MultiColumnDataTableToStringArray(dt);
            List<string[]> result = new List<string[]>();
            int r = 0;
            while (r < raw.Length)
            {
                if (raw[r][1] == "1") result.Add(raw[r]);
                else result.Add(new string[] { raw[r][0] });
                r++;
            }
            return result.ToArray();
        }

        public static string GetColumnName(ProjectField field)
        {
            string columnName = "";
            switch (field)
            {
                case ProjectField.Id: columnName = "ProjectID"; break;
                case ProjectField.Status: columnName = "ProjectStatusID"; break;
                case ProjectField.CLient: columnName = "ProjectCustomerID"; break;
                case ProjectField.Coefficient: columnName = "ProjectCoefficient"; break;
                case ProjectField.Cost: columnName = "ProjectCost"; break;
                case ProjectField.Creator: columnName = "ProjectCreatorID"; break;
                case ProjectField.FactEnd: columnName = "ProjectFactEndDate"; break;
                case ProjectField.PlanEnd: columnName = "ProjectPlanEndDate"; break;
                case ProjectField.StartDate: columnName = "ProjectStartDate"; break;
                case ProjectField.Title: columnName = "ProjectTitle"; break;
            }
            return columnName;
        }

        private static async Task<int> Add(Project proj)
        {
            string query = $@"insert into {Db.Name}.project value ({proj.Id}, {proj.Status}, {proj.CustomerId}, {proj.CreatorId}, '{proj.Title}', '{proj.StartDate}', null, null, '{proj.Coefficient}', 0);";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            return res;
        }

        public async Task<int> Update(ProjectField[] fields, string[] args)
        {
            string query = $@"update {Db.Name}.project set";
            int i = 0;
            while (i < fields.Length && i < args.Length)
            {
                query += $" {GetColumnName(fields[i])} = ";
                bool text = (new ProjectField[] { ProjectField.Coefficient, ProjectField.FactEnd, ProjectField.PlanEnd, ProjectField.StartDate, ProjectField.Title }).Contains(fields[i]);
                query += (text) ? $"'{args[i]}'" : $"{args[i]}";
                if (i != fields.Length - 1) query += ",";
                i++;
            }
            query += $"where {GetColumnName(ProjectField.Id)} = {Id};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            return res;
        }

        public async Task<int> AddStage(Stage stg)
        {
            string query = $"insert into {Db.Name}.stage_in_project (null, {Id}, {stg.Id});";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            if (res != -1) Stages.Add(stg);
            return res;
        }

        public async Task<int> Delete()
        {
            await Stage.Delete(Id, await Stage.GetStageIDs(await Stage.GetStageLinkIDs(Id)));
            string query = $"delete from {Db.Name} where {GetColumnName(ProjectField.Id)} = {Id};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            this.Dispose();
            return res;
        }

        public void Dispose()
        {
            foreach (Stage stg in Stages)
            {
                foreach (Subtask sbtsk in stg.subtasks)
                {
                    foreach (ControlPoint cp in sbtsk.points) { cp.Dispose(); }
                    sbtsk.Dispose();
                }
                stg.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
