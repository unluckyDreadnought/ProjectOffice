using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectOffice.logic
{
    public static class Symbols
    {
        public static string ru_alp { get { return "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; } }
        public static string en_alp { get { return "abcdefghijklmnopqrstuvwxyz"; } }
        public static string spec { get { return "!_.+=~$#%^:&?*(){}[]-<>"; } }
        public static string emailPattern { get { return @"(?:(?:[._-]+)*(?:\w+)*(?:\d+)*)+\@(?:\w+)*(?:\d+)*.\w+"; } }
    }

    public enum ChooseMode
    {
        Client = 0,
        Employee = 1,
        Stages = 2
    }

    public enum UserRole
    {
        Admin = 1,
        Manager = 2,
        Employee = 3
    }

    public enum Dictionaries
    {
        Specializations = 0,
        Status = 1,
        Stages = 2,
        OrganizationTypes = 3,
        Subtasks = 4
    }

    public enum Connection
    {
        OK = 0,
        HostUnreachable = 1,
        UserError = 2,
        DatabaseNotExist = 3
    }

    public enum Status
    {
        NotSetted = -1,
        New = 1,
        Work = 2,
        Agreement = 3,
        PreparingToEnd = 4,
        Finish = 5,
        Rejected = 6
    }

    public enum ProjectField
    {
        Id = 0,
        Status = 1,
        CLient = 2,
        Creator = 3,
        Title = 4,
        StartDate = 5,
        PlanEnd = 6,
        FactEnd = 7,
        Coefficient = 8,
        Cost = 9
    }

    public static class ProjectLinked
    {
        public enum LinkedTables
        {
            Project = 0,
            Stage = 1,
            StageInProject = 2,
            Subtask = 3,
            SubtaskInStage = 4,
            ControlPoint = 5,
            ControlPointInSubtask = 6,
            User = 7,
            UserProject = 8
        }

        /// <summary>
        /// Получает имя таблицы, связанной с таблицей проектов, и имя поля, идентифицирующего каждую запись в ней
        /// </summary>
        /// <param name="table">Таблица, для которой нужно получить собственное имя и имя поля идентификатора</param>
        /// <returns>Возвращает <see cref="KeyValuePair{TKey, TValue}"/>, где<br></br>
        ///  Tkey - имя таблицы (string)<br></br>
        ///  TValue - поле (-я) идентификатора (string[])
        /// </returns>
        public static KeyValuePair<string, string[]> GetTableAndIdNames(LinkedTables table)
        {
            KeyValuePair<string, string[]> pair = new KeyValuePair<string, string[]>();
            switch (table)
            {
                case LinkedTables.Project: pair = new KeyValuePair<string, string[]>("project", new string[] { "ProjectID" }); break;
                case LinkedTables.Stage: pair = new KeyValuePair<string, string[]>("stage", new string[] { "StageID" }); break;
                case LinkedTables.StageInProject: pair = new KeyValuePair<string, string[]>("stage_in_project", new string[] { "StgLinkID" }); break;
                case LinkedTables.Subtask: pair = new KeyValuePair<string, string[]>("subtask", new string[] { "SubtaskID" }); break;
                case LinkedTables.SubtaskInStage: pair = new KeyValuePair<string, string[]>("subtask_in_project_stage", new string[] { "SbtskLinkID" }); break;
                case LinkedTables.ControlPoint: pair = new KeyValuePair<string, string[]>("controlpoint", new string[] { "ControlPointID" }); break;
                case LinkedTables.ControlPointInSubtask: pair = new KeyValuePair<string, string[]>("control_point_to_subtask", new string[] { "CntrPntLinkID" }); break;
                case LinkedTables.User: pair = new KeyValuePair<string, string[]>("`user`", new string[] { "UserID" }); break;
                case LinkedTables.UserProject: pair = new KeyValuePair<string, string[]>("userproject", new string[] { "UserID", "ProjectID" }); break;
            }
            return pair;
        }

        /// <summary>
        /// Получает идентификатор последней записи в указанной таблице
        /// </summary>
        /// <param name="dbInstance">Экземпляр класса <see cref="Db"/></param>
        /// <param name="table">Таблица</param>
        /// <returns>Возвращает идентификатор последней записи (string) [несколько полей разделяются знаком :]</returns>
        public static async Task<string> GetLastId(Db dbInstance, LinkedTables table)
        {
            KeyValuePair<string, string[]> tableIdFieldPair = GetTableAndIdNames(table);
            if (table != LinkedTables.UserProject)
            {
                string query = $"select {tableIdFieldPair.Value[0]} from {Db.Name}.{tableIdFieldPair.Key} order by {tableIdFieldPair.Value[0]} desc limit 1;";
                var task = dbInstance.GetAsynNonReaderResult(dbInstance.ExecuteScalarAsync(query));
                (object result, _) = await Common.GetNoScalarResult(task);
                int res = Convert.ToInt32(result);
                if (res == -1) return null;
                return $"{res}";
            }
            else
            {
                string query = $"select {string.Join(",", tableIdFieldPair.Value)} from {Db.Name}.{tableIdFieldPair.Key} order by {tableIdFieldPair.Value[0]} desc limit 1;";
                var task = dbInstance.ExecuteReaderAsync(query);
                System.Data.DataTable dt = await Common.GetAsyncResult(task);
                string[] ids = Common.DataTableToStringArray(dt);
                return string.Join(":", ids);
            }
        }
    }

    public static class EventJournal
    {

        public enum EventType
        {
            Authorize = 1,
            ChangeObject = 2,
            CreateObject = 3,
            DeleteObject = 4,
            Exit = 5,
            TimeoutExit = 6,
        }

        public static EventType GetEventTypeById(string id)
        {
            EventType type = EventType.Exit;
            EventType[] types = { EventType.Authorize, EventType.ChangeObject, EventType.CreateObject, EventType.DeleteObject, EventType.Exit, EventType.TimeoutExit };
            int typeIndx = 0;
            while (typeIndx < types.Length)
            {
                if (((int)types[typeIndx]).ToString() == id)
                {
                    type = types[typeIndx];
                    break;
                }
                typeIndx++;
            }
            return type;
        }

        public static string GetHumanReadableEventType(EventType eventType)
        {
            string title = "";
            switch (eventType)
            {
                case EventType.Authorize: title = "Авторизация"; break;
                case EventType.ChangeObject: title = "Изменение объекта"; break;
                case EventType.CreateObject: title = "Создание объекта"; break;
                case EventType.DeleteObject: title = "Удаление объекта"; break;
                case EventType.Exit: title = "Выход из системы"; break;
                case EventType.TimeoutExit: title = "Выход по истечении времени бездействия"; break;
            }
            return title;
        }

        public static string GetEventTypeId(string eventTypeTitle)
        {
            EventType[] types = { EventType.Authorize, EventType.ChangeObject, EventType.CreateObject, EventType.DeleteObject, EventType.Exit, EventType.TimeoutExit };
            int indx = 0;
            while (indx < types.Length)
            {
                if (eventTypeTitle == GetHumanReadableEventType(types[indx])) break;
                indx++;
            }
            return (indx < types.Length) ? ((int)types[indx]).ToString() : null;
        }
    }

}