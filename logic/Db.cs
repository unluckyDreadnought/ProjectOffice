using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ProjectOffice.logic.app;
using MySql.Data.MySqlClient;

namespace ProjectOffice.logic
{
    public class Db
    {
        public static string Name { get { return AppSettings.dbName;  } }
        private Regex _regexp = null;

        public enum Tables
        {
            Client = 0,
            ClientType = 1,
            ControlPoint = 2,
            CtrlPntToSubtask = 3,
            EventJournal = 4,
            EventType = 5,
            OrgType = 6,
            Specialization = 7,
            Project = 8,
            Stage = 9,
            StgInProj = 10,
            Status = 11,
            Subtask = 12,
            SbtskInProjStg = 13,
            User = 14,
            UserMode = 15,
            UserProject = 16
        }

        static public string GetTableName(Tables table)
        {
            string name = "";
            switch (table)
            {
                case Tables.Client: name = "client"; break;
                case Tables.ClientType: name = "clienttype"; break;
                case Tables.ControlPoint: name = "controlpoint"; break;
                case Tables.CtrlPntToSubtask: name = "control_point_to_subtask"; break;
                case Tables.EventJournal: name = "eventjournal"; break;
                case Tables.EventType: name = "eventtype"; break;
                case Tables.OrgType: name = "organitationtype"; break;
                case Tables.Specialization: name = "specialization"; break;
                case Tables.Project: name = "project"; break;
                case Tables.Stage: name = "stage"; break;
                case Tables.StgInProj: name = "stage_in_project"; break;
                case Tables.Status: name = "status"; break;
                case Tables.Subtask: name = "subtask"; break;
                case Tables.SbtskInProjStg: name = "subtask_in_project_stage"; break;
                case Tables.User: name = "`user`"; break;
                case Tables.UserMode: name = "usermode"; break;
                case Tables.UserProject: name = "userproject"; break;
            }
            return name;
        }

        public string MakeConnectionString(bool withDbName = true)
        {
            string conStr = $"host={AppSettings.dbHost};user={AppSettings.dbUser};password={AppSettings.dbUserPass};";
            if (withDbName) conStr += $"database={AppSettings.dbName};";
            return conStr;
        }
        public string MakeConnectionString(string host, string user, string pass, bool withDbName = true)
        {
            string conStr = $"host={host};user={user};password={pass};";
            if (withDbName) conStr += $"database={AppSettings.dbName};";
            return conStr;
        }

        private (MySqlConnection, int) GetOpenConnection()
        {
            MySqlConnection con = new MySqlConnection(MakeConnectionString());
            try
            {
                con.Open();
                return (con, 0);
            }
            catch (MySqlException ex)
            {
                return (null, ex.Number);
            }
        }
        private (MySqlConnection, int) GetOpenConnection(string host, string user, string pass)
        {
            MySqlConnection con = new MySqlConnection(MakeConnectionString(host, user, pass));
            try
            {
                con.Open();
                return (con, 0);
            }
            catch (MySqlException ex)
            {
                return (null, ex.Number);
            }
        }

        public bool CanConnectToDb()
        {
            bool can = false;
            (MySqlConnection con, int code) = GetOpenConnection();
            if (con != null)
            {
                con.Close();
                can = true;
            }
            return can;
        }
        public bool CanConnectToDb(string host, string user, string pass)
        {
            bool can = false;
            (MySqlConnection con, int code) = GetOpenConnection(host, user, pass);
            if (con != null)
            {
                con.Close();
                can = true;
            }
            return can;
        }


        // Метод для подстановки параметров в запросы
        // Если текст запроса содержит @, то подразумевается, что необходимо использовать параметры MySqlParameter.
        // Значения для параметров подставляются из массива args в порядке массива.
        private int AddParametersToCommand(string query, ref MySqlCommand command, object[] args)
        {
            int n = 0;
            _regexp = new Regex("@\\w*");
            MatchCollection mathces = _regexp.Matches(query);
            int i = 0;
            foreach (Match param in mathces)
            {
                try
                {
                    if (args[i] is string)
                    {
                        command.Parameters.AddWithValue(param.Value.Replace("@", ""), args[i]);
                    }
                    else if (args[i] is byte[])
                    {
                        MySqlParameter tmpBlobParam = new MySqlParameter(param.Value.Replace("@", ""), MySqlDbType.Blob);
                        tmpBlobParam.Value = args[i];
                        command.Parameters.Add(tmpBlobParam);
                    }
                    
                    n++;
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
                i++;
            }
            return n;
        }

        // Асинхронный метод получения числового значения из БД
        // query: Текст запроса к БД
        // args: Массив значений для параметров
        public async Task<(int, Exception)> ExecuteNoDataResultAsync(string query, params object[] args)
        {
            MySqlException msg = null;
            int affected = -1;
            (MySqlConnection con, int errCode) = GetOpenConnection();
            if (con == null) return (affected, msg);
            MySqlCommand com = new MySqlCommand(query, con);

            if (query.Contains("@"))
            {
                AddParametersToCommand(query, ref com, args);
            }

            try
            {
                affected = await com.ExecuteNonQueryAsync(System.Threading.CancellationToken.None); ;
            }
            catch (MySqlException e)
            {
                msg = e;
            }
            con.Close();
            return (affected, msg);
        }

        // Асинхронный метод получения одного значения из БД
        // query: Текст запроса к БД
        // args: Массив значений для параметров
        public async Task<(object, Exception)> ExecuteScalarAsync(string query, params object[] args)
        {
            MySqlException msg = null;
            (MySqlConnection con, int errCode) = GetOpenConnection();
            if (con == null) return (-1, msg);
            MySqlCommand com = new MySqlCommand(query, con);

            if (query.Contains("@"))
            {
                AddParametersToCommand(query, ref com, args);
            }

            object result = null;
            try
            {
                result = await com.ExecuteScalarAsync(System.Threading.CancellationToken.None);
            }
            catch (MySqlException ex)
            {
                msg = ex;
            }
            con.Close();
            return (result, msg);
        }

        // Метод для получения значения из асинхронных ExecuteScalarAsync
        // Возвращает при успешном запросе - набор строк, при запросе, повлекшем ошибки - описание ошибки, null
        public async Task<object> GetAsynNonReaderResult(Task<(object, Exception)> task)
        {
            string msgText = null;
            (object value, Exception e) = await task;

            if (value != null && value is int)
            {
                msgText = ((int)value == -1) ? "Не удалось установить подключение к базе данных. Проверьте настройки." : null;
            }
            msgText = (e != null) ? e.Message : null;

            if (msgText == null) return value;
            else return msgText;
        }

        // Метод для получения значения из асинхронных ExecuteNoDataResult
        // Возвращает при успешном запросе - набор строк, при запросе, повлекшем ошибки - описание ошибки, null
        public async Task<object> GetAsynNonReaderResult(Task<(int, Exception)> task)
        {
            string msgText = null;
            (int value, Exception e) = await task;

            msgText = (value == -1) ? "Не удалось установить подключение к базе данных. Проверьте настройки." : null;
            msgText = (e != null) ? e.Message : null;

            if (msgText == null) return (object)value;
            else return msgText;
        }

        // Асинхронный метод получения данных с помощью MySqlDataReader
        // query: Текст запроса к БД
        // args: Массив значений для параметров
        public async Task<(DataTable, Exception)> ExecuteReaderAsync(string query, params object[] args)
        {
            MySqlException msg = null;
            (MySqlConnection con, int errCode) = GetOpenConnection();
            if (con == null) return (null, null);
            MySqlCommand com = new MySqlCommand(query, con);

            if (query.Contains("@"))
            {
                AddParametersToCommand(query, ref com, args);
            }

            DataTable dt = new DataTable();
            MySqlDataReader rdr = null;
            try
            {
                rdr = (MySqlDataReader)await com.ExecuteReaderAsync();
                dt.Load(rdr);
            }
            catch (MySqlException e)
            {
                msg = e;
            }

            if (rdr != null)
            {
                if (!rdr.IsClosed) rdr.Close();
            }
            await con.CloseAsync();

            return (dt, msg);
        }


        // Метод для получения значения из асинхронного ExecuteReaderAsync
        // Возвращает при успешном запросе - набор строк, при запросе, повлекшем ошибки - описание ошибки, null
        public async Task<object> GetAsyncReaderResult(Task<(DataTable, Exception)> task)
        {
            string msgText = "";
            (DataTable dt, Exception e) = await task;
            if (dt == null)
            {
                msgText = "Не удалось установить подключение к базе данных. Проверьте настройки.";
                return msgText;
            }
            if (dt.Rows.Count == 0)
            {
                return (e != null) ? e.Message : null;
            }
            else
            {
                return dt;
            }
        }

        public async Task<(string[], DataTable)> FindUser(string login, string passwd)
        {
            string query = $@"select concat(UserSurname, ' ', substring(UserName, 1, 1), '.', substring(UserPatronymic, 1, 1)) as snf, UserModeID, UserID, UserPhoto 
from `{AppSettings.dbName}`.`user` where UserLogin = @login and UserPassword = @pswd;";

            var task = ExecuteReaderAsync(query, login, passwd);
            DataTable result = await Common.GetAsyncResult(task);
            if (result == null) return (null, null); 

            if (result.Rows.Count == 0)
            {
                return (new string[] { "Пользователь с такими учётными данными не найден." }, null);
            }
            return (new string[] { result.Rows[0][0].ToString(), result.Rows[0][1].ToString(), result.Rows[0][2].ToString() }, result);
        }
    }
}
