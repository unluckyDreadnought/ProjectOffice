using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using ProjectOffice.logic.app;

namespace ProjectOffice.logic
{
    public class ControlPoint
    {
        private static Db _db = new Db();
        public string Id;
        private string SubtaskId;
        public string AuthorId;
        public string CreatedTime;
        public string Title;
        public string Description;
        public string StatusId;
        private bool _disposed = false;

        /// <summary>
        /// Получение экземпляра <see cref="ControlPoint"/>, заполненого данными из БД
        /// </summary>
        /// <param name="pointId">Идентификатор контрольной точки</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является экземпляр <see cref="ControlPoint"/> в случае успеха, иначе <see cref="null"/></returns>
        public static async Task<ControlPoint> GetById(string pointId)
        {
            string query = $@"select 
ControlPointAuthorID, StatusID, ControlPointTitle, ControlPointDescription, ControlPointDateTime 
from {Db.Name}.controlpoint where ControlPointID = {pointId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return null;
            string[] info = Common.DataTableToStringArray(dt);
            ControlPoint point = new ControlPoint();
            point.Id = pointId;
            point.AuthorId = info[0];
            point.StatusId = info[1];
            point.Title = info[2];
            point.Description = info[3];
            point.CreatedTime = info[4];
            return point;
        }

        /// <summary>
        /// Получает все контрольные точки данной подзадачи проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <param name="subtaskId">Идентификатор подзадачи</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является список контольных точек</returns>
        public static async Task<List<ControlPoint>> GetControlPoints(string projectId, string stageId, string subtaskId)
        {
            string sbtskLink = await Subtask.GetSubtaskLinkID(projectId, stageId, subtaskId);
            if (sbtskLink == null) return new List<ControlPoint>();
            string query = $@"select control_point_to_subtask.ControlPointID, ControlPointDateTime, ControlPointAuthorID, 
ControlPointTitle, ControlPointDescription, controlpoint.StatusID from {Db.Name}.control_point_to_subtask
inner join controlpoint on controlpoint.ControlPointID = control_point_to_subtask.ControlPointID
where SbtskReferenceID = {sbtskLink}
order by ControlPointDateTime asc;";
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
                current.SubtaskId = subtaskId;
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
            if (controlPointIds.Length == 0) return new string[] { };
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
            if (controlPointIds.Length == 0) return (0, true);
            string[] ctnrPntsLinks = await ControlPoint.GetControlPointLinkIDs(controlPointIds);
            if (ctnrPntsLinks.Length == 0) return (0, true);

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

        /// <summary>
        /// Очищает данные контрольной точки
        /// </summary>
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

        /// <summary>
        /// Получает все подзадачи данной стадии проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является список подзадач</returns>
        public static async Task<List<Subtask>> GetSubtasks(string projectId, string stageId)
        {
            string stgsLink = await Stage.GetStageLinkID(projectId, stageId);
            if (stgsLink == null) return new List<Subtask>();
            string query = $@"select subtask_in_project_stage.SubtaskId, SubtaskTitle, SubtaskDescription from {Db.Name}.subtask_in_project_stage
inner join subtask on subtask.SubtaskID = subtask_in_project_stage.SubtaskID
where StgProjReferenceID = {stgsLink};";
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
                current.Title = raw[row][1];
                current.Description = raw[row][2];
                current.points = await ControlPoint.GetControlPoints(projectId, stageId, current.Id);
                result.Add(current);
                row++;
            }
            return result;
        }

        /// <summary>
        /// Получает идентификатор записи в связующей таблице подзадачи и стадии
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <param name="subtaskId">Идентификатор подзадачи</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является идентификатор соответствующей связующей записи</returns>
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
        /// Получает все идентификаторы записей из связующей таблицы подзадач к конкретным стадиям по идентификатору (-ам) связующей таблицы
        /// </summary>
        /// <param name="stgProjRefIds">Идентификатор (-ы) связующей таблицы проекта и стадии (-ий)</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами записей</returns>
        public static async Task<string[]> GetSubtaskLinkIDsByStgProjRefs(params string[] stgProjRefIds)
        {
            if (stgProjRefIds.Length == 0) return new string[] { };
            string query = $@"select SbtskLinkId from {Db.Name}.subtask_in_project_stage
where StgProjReferenceID in
({string.Join(",", stgProjRefIds)}); ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает все идентификаторы записей из связующей таблицы подзадач по идентификатору подзадачи
        /// </summary>
        /// <param name="subtaskIds">Идентификатор (-ы) подзадач (-и)</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами связующих записей</returns>
        public static async Task<string[]> GetSubtaskLinkIDs(params string[] subtaskIds)
        {
            string query = $@"select SbtskLinkID from {Db.Name}.subtask_in_project_stage
where SubtaskID in ({string.Join(",", subtaskIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает все идентификаторы записей из связующей таблицы подзадач по идентификатору подзадачи и иденфикатору проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="subtaskIds">Идентификатор (-ы) подзадач (-и)</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами связующих записей</returns>
        public static async Task<string[]> GetSubtaskLinkIDs(string projectId, params string[] subtaskIds)
        {
            string query = $@"select SbtskLinkID from {Db.Name}.subtask_in_project_stage
where StgProjReferenceID in
(select StgLinkID from {Db.Name}.stage_in_project where ProjectID = {projectId}) and SubtaskID in ({string.Join(",", subtaskIds)});;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы подзадач соответствующие идентификаторам записей из связующей таблицы подзадач
        /// </summary>
        /// <param name="sbtskLinkIds">Идентификаторы записей из связующей таблицы подзадач</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами подзадач</returns>
        public static async Task<string[]> GetSubtaskIDs(params string[] sbtskLinkIds)
        {
            string query = $@"select SubtaskID from {Db.Name}.subtask_in_project_stage 
where SbtskLinkID in ({string.Join(",", sbtskLinkIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Добавление к подзадаче проекта новой контрольной точки
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="title">Заголовок контрольной точки</param>
        /// <param name="status">Статус выполение подзадачи</param>
        /// <param name="description">Описание контрольной точки</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является число добавленных записей в связующую контрольные точки и подзадачи таблицу при успехе, иначе -1</returns>
        public async Task<int> AddControlPoint(string projectId, string title, Status status, string description = null)
        {
            int lastCpId = -1;
            int.TryParse(await ProjectLinked.GetLastId(_db, ProjectLinked.LinkedTables.ControlPoint), out lastCpId);
            string idPlaceholder = lastCpId != -1 ? $"{lastCpId + 1}" : "null";
            string desc = description != null ? $"'{description}'" : "null";
            string t = title.Length == 0 ? "null" : $"'{title}'";
            string query = $@"insert into {Db.Name}.{Db.GetTableName(Db.Tables.ControlPoint)} value ({idPlaceholder}, {AppUser.Id}, {((int)status)}, {t}, {desc}, '{DateTime.Now.ToString("yyyy.MM.dd HH:mm")}');";
            var task =  _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            if (Convert.ToInt32(result) == -1) return -1;

            lastCpId = -1;
            int.TryParse(await ProjectLinked.GetLastId(_db, ProjectLinked.LinkedTables.ControlPoint), out lastCpId);
            if (lastCpId == -1) return -1;

            int lastLinkId = -1;
            int.TryParse(await ProjectLinked.GetLastId(_db, ProjectLinked.LinkedTables.ControlPointInSubtask), out lastLinkId);
            idPlaceholder = lastLinkId != -1 ? $"{lastLinkId + 1}" : "null";

            query = $"insert into {Db.Name}.{Db.GetTableName(Db.Tables.CtrlPntToSubtask)} value ({idPlaceholder}, {await Subtask.GetSubtaskLinkID(projectId, this.StageId, this.Id)}, {lastCpId});";
            task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (result, _) = await Common.GetNoScalarResult(task);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Обновляет контрольную точку
        /// </summary>
        /// <param name="cntrPointId">Идентификатор обновляемой контрольной точки</param>
        /// <param name="title">Заголовок конторльной точки</param>
        /// <param name="status">Статус выполнения подзадачи</param>
        /// <param name="description">Описание контрольной точки</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является число добавленных записей в связующую контрольные точки и подзадачи таблицу при успехе, иначе -1</returns>
        public async Task<int> UpdateControlPoint(string cntrPointId, string title = null, Status status = Status.NotSetted, string description = null)
        {
            int lastCpId = -1;
            int.TryParse(await ProjectLinked.GetLastId(_db, ProjectLinked.LinkedTables.ControlPoint), out lastCpId);
            if (lastCpId == -1) return -1;
            string query = $@"update {Db.Name}.{Db.GetTableName(Db.Tables.ControlPoint)} set";
            if (title != null) query += $" ControlPointTitle = '{title}',";
            if (status != Status.NotSetted) query += $" StatusID = {((int)status).ToString()},";
            if (description != null) query += $" ControlPointDescription = '{description}',";
            if (description != null) query += $" ControlPointDateTime = '{DateTime.Now.ToString("yyyy.MM.dd HH:mm")}'";
            query += $"where ControlPointID = {cntrPointId};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Удаляет подзадачи из всех таблиц
        /// </summary>
        /// <param name="subtaskIds">Идентификатор (-ы) удаляемых подзадач</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является (общее количество удалённых записей | -1, флаг, является ли ответ числом)</returns>
        public static async Task<(object, bool)> Delete(params string[] subtaskIds)
        {
            if (subtaskIds.Length == 0) return (0, true);
            string[] sbtskLinks = await Subtask.GetSubtaskLinkIDs(subtaskIds);
            if (sbtskLinks.Length == 0) return (0, true);

            // получение идентификаторов записей связующей таблицы контрольных точек с проектом
            string query = $@"select ControlPointID from {Db.Name}.control_point_to_subtask
where SbtskReferenceID in ({string.Join(",", sbtskLinks)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string[] controlPoints = Common.DataTableToStringArray(dt);

            int total = 0;
            int temp = 0;
            object n = null;
            bool isInt = false;

            //удаление зависимостей от контрольных точек
            string[] cntrPtsLinks = await ControlPoint.GetControlPointLinkIDs(controlPoints);
            if (cntrPtsLinks.Length == 0)
            {
                query = $@"delete from {Db.Name}.{Db.GetTableName(Db.Tables.CtrlPntToSubtask)}
where CntrPntLinkID in ({string.Join(",", cntrPtsLinks)});";
                var task2 = _db.ExecuteNoDataResultAsync(query);
                (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task2));
                temp = Convert.ToInt32(n);
                if (temp == -1) return (-1, true);
                total += temp;
            }

            // удаление контрольных точек
            (n, isInt) = await ControlPoint.Delete(controlPoints);
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total = temp;

            // удаление зависимостей от подзадач
            query = $@"delete from {Db.Name}.subtask_in_project_stage
where SbtskLinkID in ({string.Join(",", sbtskLinks)});";
            var task3 = _db.ExecuteNoDataResultAsync(query);
            (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task3));
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total += temp;

            // удаление зависимостей от подзадач
            query = $@"delete from {Db.Name}.subtask
where SubtaskID in ({string.Join(",", subtaskIds)});";
            task3 = _db.ExecuteNoDataResultAsync(query);
            (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task3));
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total += temp;

            return (total, true);
        }

        /// <summary>
        /// Открепление подзадач, связанных с идентификаторами записей из связующей таблицы проектов и стадий  
        /// </summary>
        /// <param name="stgProjRefIds">Идентификаторы записей из связующей таблицы проектов и стадий, от которых нужно открепить подзадачи</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является (общее количество удалённых записей | -1, флаг, является ли ответ числом)</returns>
        public static async Task<(object, bool)> UnlinkByStgProjLinks(params string[] stgProjRefIds)
        {
            if (stgProjRefIds.Length == 0) return (0, true);
            string[] sbtskLinks = await Subtask.GetSubtaskLinkIDsByStgProjRefs(stgProjRefIds);
            if (sbtskLinks.Length == 0) return (0, true);

            // получение идентификаторов записей связующей таблицы контрольных точек с проектом
            string query = $@"select ControlPointID from {Db.Name}.control_point_to_subtask
where SbtskReferenceID in ({string.Join(",", sbtskLinks)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string[] controlPoints = Common.DataTableToStringArray(dt);

            int total = 0;
            int temp = 0;
            object n = null;
            bool isInt = false;

            //удаление зависимостей от контрольных точек
            string[] cntrPtsLinks = await ControlPoint.GetControlPointLinkIDs(controlPoints);
            if (cntrPtsLinks.Length != 0)
            {
                query = $@"delete from {Db.Name}.{Db.GetTableName(Db.Tables.CtrlPntToSubtask)}
where CntrPntLinkID in ({string.Join(",", cntrPtsLinks)});";
                var task2 = _db.ExecuteNoDataResultAsync(query);
                (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task2));
                temp = Convert.ToInt32(n);
                if (temp == -1) return (-1, true);
                total += temp;
            }

            // удаление контрольных точек
            (n, isInt) = await ControlPoint.Delete(controlPoints);
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total = temp;

            // удаление зависимостей от подзадач
            query = $@"delete from {Db.Name}.subtask_in_project_stage
where SbtskLinkID in ({string.Join(",", sbtskLinks)});";
            var task3 = _db.ExecuteNoDataResultAsync(query);
            (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task3));
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total += temp;

            return (total, true);
        }

        /// <summary>
        /// Открепление подзадач из проекта по их идентификаторам  
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="subtaskIds">Идентификатор (-ы) подзадач, которые нужно открепить</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является (общее количество удалённых записей | -1, флаг, является ли ответ числом)</returns>
        public static async Task<(object, bool)> UnlinkSubtaskIds(string projectId, params string[] subtaskIds)
        {
            if (subtaskIds.Length == 0) return (0, true);
            string[] sbtskLinks = await Subtask.GetSubtaskLinkIDs(projectId, subtaskIds);
            if (sbtskLinks.Length == 0) return (0, true);

            // получение идентификаторов записей связующей таблицы контрольных точек с проектом
            string query = $@"select ControlPointID from {Db.Name}.control_point_to_subtask
where SbtskReferenceID in ({string.Join(",", sbtskLinks)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string[] controlPoints = Common.DataTableToStringArray(dt);

            int total = 0;
            int temp = 0;
            object n = null;
            bool isInt = false;

            //удаление зависимостей от контрольных точек
            string[] cntrPtsLinks = await ControlPoint.GetControlPointLinkIDs(controlPoints);
            if (cntrPtsLinks.Length != 0)
            {
                query = $@"delete from {Db.Name}.{Db.GetTableName(Db.Tables.CtrlPntToSubtask)}
where CntrPntLinkID in ({string.Join(",", cntrPtsLinks)});";
                var task2 = _db.ExecuteNoDataResultAsync(query);
                (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task2));
                temp = Convert.ToInt32(n);
                if (temp == -1) return (-1, true);
                total += temp;
            }

            // удаление контрольных точек
            (n, isInt) = await ControlPoint.Delete(controlPoints);
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total = temp;

            // удаление зависимостей от подзадач
            query = $@"delete from {Db.Name}.subtask_in_project_stage
where SbtskLinkID in ({string.Join(",", sbtskLinks)});";
            var task3 = _db.ExecuteNoDataResultAsync(query);
            (n, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(task3));
            temp = Convert.ToInt32(n);
            if (temp == -1) return (-1, true);
            total += temp;

            return (total, true);
        }

        /// <summary>
        /// Очищает данные подзадачи
        /// </summary>
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
        public string ProjectId { private get; set; }
        public string Title;
        public List<Subtask> subtasks = null;
        private bool _disposed = false;

        /// <summary>
        /// Получает существующую стадию по идентификатору
        /// </summary>
        /// <param name="stgId">Идентификатор стадии</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является экземпляр класса <see cref="Stage"/></returns>
        public static async Task<Stage> GetById(string stgId)
        {
            string query = $@"select * from {Db.Name}.{Db.GetTableName(Db.Tables.Stage)} where StageID = {stgId};";
            var task = _db.ExecuteReaderAsync(query);
            string[] stgFields = Common.DataTableToStringArray(await Common.GetAsyncResult(task));
            if (stgFields.Length == 0) return null;
            Stage stg = new Stage();
            stg.Id = stgFields[0];
            stg.Title = stgFields[1];
            stg.subtasks = new List<Subtask>();
            return stg;
        }

        /// <summary>
        /// Получает все стадии указанного проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является список стадий</returns>
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

        /// <summary>
        /// Получает идентификатор записи из связующей таблицы соответствующие указанной стадии проекта
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageId">Идентификатор стадии</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является идентификатор записи из связующей таблицы</returns>
        public static async Task<string> GetStageLinkID(string projectId, string stageId)
        {
            string query = $@"select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId} and stage_in_project.StageID = {stageId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
        }

        /// <summary>
        /// Получает идентификаторы всех записей из связующей таблицы проектов и стадий
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами записей связующей таблицы стадий</returns>
        public static async Task<string[]> GetStageLinkIDs(string projectId)
        {
            string query = $@"select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы всех записей из связующей таблицы проектов и стадий соответствующих идентификаторам стадий 
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageIds">Идентификатор стадии</param>
        /// <returns>Возращает асинхронную операцию, результатом которой является массив строк с идентификаторами записей связующей таблицы стадий</returns>
        public static async Task<string[]> GetStageLinkIDs(string projectId, params string[] stageIds)
        {
            if (stageIds.Length == 0) return Common.DataTableToStringArray(new DataTable());
            string query = $@"select StgLinkID from {Db.Name}.stage_in_project
where ProjectID = {projectId} and StageID in ({string.Join(",", stageIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает идентификаторы стадий, включённых в связующие записи таблицы стадий и проектов
        /// </summary>
        /// <param name="stgLinkIds">Идентификаторы записей связующей таблицы стадий</param>
        /// <returns>Возвращает асинхронную операциб=ю, результатом которой является массив строк с идентификаторами стадий</returns>
        public static async Task<string[]> GetStageIDs(params string[] stgLinkIds)
        {
            if (stgLinkIds.Length == 0) return Common.DataTableToStringArray(new DataTable());
            string query = $@"select StageID from {Db.Name}.stage_in_project where StgLinkID in ({string.Join(",", stgLinkIds)});";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Добавляет подзадачу к стадии в проекте
        /// </summary>
        /// <param name="title">Заголовок подзадачи</param>
        /// <param name="description">Описание подзадачи</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество добавленных записей в связующую таблицу подзадач в случае успеха, иначе -1</returns>
        public async Task<int> AddSubtask(string title, string description = null)
        {
            string query = $@"select SubtaskID from subtask where SubtaskTitle = '{title}';";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = 0;
            if (result != null)
            {
                res = Convert.ToInt32(result);
            }
            if (res == -1) return -1;
            
            if (res == 0)
            {
                query = $@"insert into {Db.Name}.subtask value (null, '{title}');
select SubtaskID from {Db.Name}.subtask order by SubtaskID DESC limit 1";
                task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
                (result, _) = await Common.GetNoScalarResult(task);
                res = Convert.ToInt32(result);
                if (res == -1) return -1;
            }

            string desc = (description != null) ? $"'{description}'" : "null";
            query = $"insert into {Db.Name}.subtask_in_project_stage value (null, {await GetStageLinkID(this.ProjectId, this.Id)}, {res}, {desc});";
            var task2 = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (result, _) = await Common.GetNoScalarResult(task2);
            res = Convert.ToInt32(result);
            if (res == -1) return -1;

            this.subtasks = await Subtask.GetSubtasks(this.ProjectId, await GetStageLinkID(this.ProjectId, this.Id));
            return res;
        }

        /// <summary>
        /// Обнавляет подзадачу к стадии в проекте
        /// </summary>
        /// <param name="sbtskRefId">Идентификатор записи связующей таблицы со стадией</param>
        /// <param name="description">Описание подзадачи</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество добавленных записей в связующую таблицу подзадач в случае успеха, иначе -1</returns>
        public async Task<int> UpdateSubtask(string sbtskRefId, string description)
        {
            string query = $"update {Db.Name}.subtask_in_project_stage set SubtaskDescription = '{description}' where SbtskLinkID = {sbtskRefId};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            this.subtasks = await Subtask.GetSubtasks(this.ProjectId, await GetStageLinkID(this.ProjectId, this.Id));
            return res;
        }

        /// <summary>
        /// Удаляет зависимости в проектах от стадий
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="stageIds">Идентификатор (-ы) стадий</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является общее количество удалённых записей в случае успеха, иначе -1</returns>
        public static async Task<(object, bool)> Delete(string projectId, params string[] stageIds)
        {
            if (stageIds.Length == 0) return (0, true);
            string[] stgLinks = await Stage.GetStageLinkIDs(projectId, stageIds);
            if (stgLinks.Length == 0) return (0, true);

            (object affected, bool isInt) = await Subtask.UnlinkByStgProjLinks(stgLinks);
            int temp = Convert.ToInt32(affected);
            if (temp == -1) return (-1, true);
            int total = temp;

            string query = $@"delete from {Db.Name}.stage_in_project where StgLinkId in ({string.Join(",", stgLinks)});";
            var taks2 = _db.ExecuteNoDataResultAsync(query);
            (affected, isInt) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(taks2));
            temp = Convert.ToInt32(affected);
            if (temp == -1) return (-1, true);
            total += temp;

            return (total, true);
        }

        /// <summary>
        /// Очищает данные стадии
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                Id = null;
                Title = null;
                if (subtasks != null)
                {
                    subtasks.Clear();
                    subtasks = null;
                }
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
        public string PlanEndDate { get; set; }
        public string EndDate { get; private set; }
        public string CustomerId { get; set; }
        public string CreatorId { get; set; }
        public string Coefficient { get; set; }
        public string Cost { get; set; }
        public string Status;
        public List<Stage> Stages { get; set; }
        public string[][] EmployeesId = null;

        // конструктор проекта
        private Project(string id, string title, string start, string endPlan, string customer, string creator, string coff, string cost, string status, List<Stage> stages, string[][] employees, string end = "not-end")
        {
            Id = id;
            Title = title;
            StartDate = start;
            PlanEndDate = endPlan;
            if (end != "not-end")
            {
                if (status != ((int)logic.Status.Rejected).ToString()) EndDate = end == null ? PlanEndDate : end;
                else EndDate = StartDate;
            }
            else EndDate = null;
            CustomerId = customer;
            CreatorId = creator;
            Coefficient = coff;
            Status = status;
            int iCost = Convert.ToInt32(cost);
            int iCoef = Convert.ToInt32(coff);
            Cost = $"{Math.Round((float)iCost * (1 + (iCoef / 100)), 2)}";
            Stages = stages;
            EmployeesId = employees;
        }

        /// <summary>
        /// Добавляет новую запись в таблицу проектов
        /// </summary>
        /// <param name="proj">Экземпляр класса проекта с данными</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество добавленных записей в случае успеха, иначе -1</returns>
        private static async Task<int> Add(Project proj)
        {
            string customer = (proj.CustomerId == null) ? "null" : proj.CustomerId;
            string query = $@"insert into {Db.Name}.project value ({proj.Id}, {proj.Status}, {customer}, {proj.CreatorId}, '{proj.Title}', '{proj.StartDate}', '{proj.PlanEndDate}', null, '{proj.Coefficient}', 0);";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            return res;
        }

        /// <summary>
        /// Создаёт новый проект
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Project"/>, заполненный некоторыми шаблонными данными и булевое значение, символизирующие был ли создан проект или нет</returns>
        public async static Task<(Project, bool)> InitilazeAsync()
        {
            string id = $"{await GetLastProjID() + 1}";
            string title = $"Проект {await GetLastStandardNameNumber()}";
            string start = DateTime.Now.ToString("yyyy.MM.dd");
            string planEnd = DateTime.Parse(start).AddDays(5).ToString("yyyy.MM.dd");
            string creator = AppUser.Id;
            string coef = "0";
            List<Stage> stgs = new List<Stage>();
            string[][] empl = new string[][] { };
            Project proj = new Project(id, title, start, planEnd, null, creator, coef, null, "1", stgs, empl);
            int n = await Project.Add(proj);
            return (proj, n != -1);
        }

        /// <summary>
        /// Получает существующий проект
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Экземпляр класса <see cref="Project"/>, заполненный данными из базы данных</returns>
        public async static Task<Project> InitilazeAsync(string id)
        {
            string[] info = await GetExistingProjectInfo(id);
            List<Stage> stgs = await Stage.GetStages(id);
            string[][] empl = await GetEmployees(id);
            if (info[7] == ((int)logic.Status.Finish).ToString() || info[7] == ((int)logic.Status.Rejected).ToString())
            {
                return new Project(id, title: info[0], start: info[1], endPlan: info[2], customer: info[3], creator: info[4], coff: info[5], cost: info[6], status: info[7], stgs, empl, end: info[8]);
            }
            else
            {
                return new Project(id, title: info[0], start: info[1], endPlan: info[2], customer: info[3], creator: info[4], coff: info[5], cost: info[6], status: info[7], stgs, empl);
            }
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
ProjectCreatorID, ProjectCoefficient, ProjectCost, ProjectStatusID,
ProjectFactEndDate from {Db.Name}.project where ProjectID = {id}; ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return Common.DataTableToStringArray(dt);
        }

        /// <summary>
        /// Получает всех сотрудников, закреплённых в проекте
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является массив массивов с идентификаторами сотрудников</returns>
        public static async Task<string[][]> GetEmployees(string id)
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
                else result.Add(new string[] {raw[r][0]});
                r++;
            }
            return result.ToArray();
        }

        /// <summary>
        /// Получает строку с именем поля в таблице проектов
        /// </summary>
        /// <param name="field">Необходимое поле</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является строка с именем поля</returns>
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

        /// <summary>
        /// Добавляет стадию в проект
        /// </summary>
        /// <param name="stg">Экземпляр класса <see cref="Stage"/></param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество добавленных записей в случае успеха, иначе -1</returns>
        public async Task<int> AddStage(Stage stg)
        {
            stg.ProjectId = this.Id;
            string query = $"select StgLinkID from {Db.Name}.{Db.GetTableName(Db.Tables.StgInProj)} order by StgLinkID desc limit 1";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int link = Convert.ToInt32(result) + 1;

            query = $@"insert into {Db.Name}.stage_in_project value ({link},{Id}, {stg.Id});";
            task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);

            return res;
        }

        /// <summary>
        /// Удаляет все прикрепленные к проекту стадии
        /// </summary>
        /// <returns></returns>
        public async Task<int> RemoveAllStages()
        {
            (object result, _) = await Stage.Delete(Id, await Stage.GetStageIDs(await Stage.GetStageLinkIDs(Id)));
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Удаляет всех прикреплённых к проекту сотрудников
        /// </summary>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество добавленных записей в случае успеха, иначе -1</returns>
        public async Task<int> RemoveAllEmployees()
        {
            string query = $@"delete from {Db.Name}.{Db.GetTableName(Db.Tables.UserProject)} where ProjectID = {Id};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            EmployeesId = await Project.GetEmployees(Id);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Перезаписывает список прикреплённых к проекту сотрудников новыми
        /// </summary>
        /// <param name="employees">
        /// Массив массивов сотрудников, где каждый отдельный массив имеет вид { EmployeeID, [1] }<br></br>
        ///это запись о сотруднике, содержащая его идентификатор и, если является ответственным - 1.
        /// </param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество добавленных записей в случае успеха, иначе -1</returns>
        public async Task<int> AddEmployees(string[][] employees)
        {
            await this.RemoveAllEmployees();
            string query = $@"insert into {Db.Name}.{Db.GetTableName(Db.Tables.UserProject)} values ";

            int indx = 0;
            while (indx < employees.Length)
            {
                string resp = (employees[indx].Length > 1) ? "1" : "null";
                query += $"({employees[indx][0]}, {Id}, {resp})";
                if (indx != employees.Length - 1) query += ",";
                indx++;
            }
            query += ";";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            EmployeesId = await Project.GetEmployees(Id);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proj"></param>
        /// <returns>Возвращает true, проекты идентичны (за исключением Id), иначе - false</returns>
        public bool CompareWith(Project proj)
        {
            bool equals = true;
            equals = Id == proj.Id;
            if (equals) equals = Title == proj.Title;
            if (equals) equals = StartDate == proj.StartDate;
            if (equals) equals = PlanEndDate == proj.PlanEndDate;
            if (equals) equals = CustomerId == proj.CustomerId;
            if (equals) equals = CreatorId == proj.CreatorId;
            if (equals) equals = Cost == proj.Cost;

            bool stageEquals = Stages.Count == proj.Stages.Count;
            int stgIndx = 0;
            while (stageEquals && stgIndx < Stages.Count)
            {
                stageEquals = Stages[stgIndx].Id == proj.Stages[stgIndx].Id;
                if (stageEquals) stageEquals = Stages[stgIndx].Title == proj.Stages[stgIndx].Title;
                if (stageEquals) stageEquals = Stages[stgIndx].subtasks.Count == proj.Stages[stgIndx].subtasks.Count;
                stgIndx++;
            }
            if (equals) equals = stageEquals;

            bool emplEquals = EmployeesId.Length == proj.EmployeesId.Length;
            int emplIndx = 0;
            while (emplEquals && emplIndx < EmployeesId.Length)
            {
                emplEquals = EmployeesId[emplIndx].Length == proj.EmployeesId[emplIndx].Length;
                if (emplEquals) emplEquals = EmployeesId[emplIndx][0] == proj.EmployeesId[emplIndx][0];
                emplIndx++;
            }
            if (equals) equals = emplEquals;
            return equals;
        }

        /// <summary>
        /// Обновляет проект
        /// </summary>
        /// <param name="fields">Поля для обновления</param>
        /// <param name="args">Значения для обновляемых полей</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество изменённых записей в случае успеха, иначе -1</returns>
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
            query += $" where {GetColumnName(ProjectField.Id)} = {Id};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            return res;
        }

        /// <summary>
        /// Сохраняет изменения в текущем экземпляре <see cref="Project"/> в запись в БД
        /// </summary>
        /// <param name="existInDb">Флаг, определяющий новый ли это проект. По умолчанию - true</param>
        /// <param name="force">Флаг принудительного удаления стадий. По умолчанию - false</param>
        /// <returns>
        /// Возвращает асинхронную операцию, результатом которой являются (1, 2):<br></br>
        /// 1. Массив экземпляров <see cref="Stage"/>, которые должны быть удалены, для определения действия над ними<br></br>
        /// 2. Число удалённых стадий
        /// </returns>
        public async Task<(Stage[], int)> Save(bool existInDb = false, bool force = false)
        {
            int n = 0;
            if (!existInDb)
            {
                n = await this.Update(new ProjectField[] { ProjectField.Title, ProjectField.PlanEnd, ProjectField.CLient, ProjectField.Cost }, new string[] { this.Title, this.PlanEndDate, this.CustomerId, this.Cost });
            }
            else
            {
                n = await this.Update(new ProjectField[] { ProjectField.Coefficient, ProjectField.Status, ProjectField.Title }, new string[] { this.Coefficient, this.Status, this.Title });
            }
            n = await this.AddEmployees(EmployeesId);
            int indx = 0;

            List<string> listStgIds = new List<string>();
            List<Stage> storedDb = new List<Stage>();
            foreach (Stage s in (await Stage.GetStages(this.Id)))
            {
                listStgIds.Add(s.Id);
                storedDb.Add(s);
            }

            // стадии, которые остаются в проекте
            string[] keep = this.Stages.Where(stg => listStgIds.Contains(stg.Id)).Select(stg => stg.Id).ToArray();

            // стадии, которые должны быть добавлены в проект
            Stage[] notLinked = this.Stages.Where(stg => !listStgIds.Contains(stg.Id)).ToArray();

            // получение стадий, которые должны быть удалены, и их возврат для решения об их удалении
            string[] notLinkedStr = notLinked.Select(stg => stg.Id).ToArray();
            Stage[] toDelete = storedDb.Where(storedStg => !keep.Contains(storedStg.Id) && !notLinkedStr.Contains(storedStg.Id)).ToArray();
            if (!force && toDelete.Length != 0) return (toDelete, -1);

            // добавление стадий в проект
            int id = 0;
            while (id < notLinked.Length)
            {
                n = await this.AddStage(notLinked[id]);
                id++;
            }

            if (force)
            {
                (object result, _) = await Stage.Delete(this.Id, toDelete.Select(delStg => delStg.Id).ToArray());
                return (toDelete, Convert.ToInt32(result));
            }

            return (toDelete, 0);
        }

        /// <summary>
        /// Удаляет проект
        /// </summary>
        /// <returns>Возвращает асинхронную операцию, результатом которой является количество удалённых записей в случае успеха, иначе -1</returns>
        public async Task<int> Delete()
        {
            await this.RemoveAllEmployees();
            await this.RemoveAllStages();
            string query = $"delete from {Db.Name}.{Db.GetTableName(Db.Tables.Project)} where {GetColumnName(ProjectField.Id)} = {Id};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            int res = Convert.ToInt32(result);
            this.Dispose();
            return res;
        }

        /// <summary>
        /// Очищает данные, связанные с проектом
        /// </summary>
        public void Dispose()
        {
            foreach (Stage stg in Stages)
            {
                if (stg.subtasks == null)
                {
                    stg.Dispose();
                    continue;
                }
                foreach (Subtask sbtsk in stg.subtasks)
                {
                    if (sbtsk.points == null)
                    {
                        sbtsk.Dispose();
                        continue;
                    }
                    foreach (ControlPoint cp in sbtsk.points) { cp.Dispose(); }
                    sbtsk.Dispose();
                }
                stg.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
