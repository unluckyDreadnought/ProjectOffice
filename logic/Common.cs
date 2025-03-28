using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOffice.logic
{
    /// <summary>
    /// Класс для методов, которые могут применяться на разных формах
    /// </summary>
    public static class Common
    {
        private static Db _db = new Db();

        public static async Task<DataTable> GetAsyncResult(Task<(DataTable, Exception)> task)
        {
            object res = await _db.GetAsyncReaderResult(task);
            if (res == null) return new DataTable();
            if (res is string)
            {
                MessageBox.Show((string)res, "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
            else return (DataTable)res;
        }

        /// <summary>
        /// Получает результат из запросов к БД типа <see cref="Db.GetAsynNonReaderResult(Task{(int, Exception)})"/> и <see cref="Db.GetAsynNonReaderResult(Task{(object, Exception)})"/>
        /// </summary>
        /// <param name="dbResponseTask">Асинхронная операция <see cref="Task"/> к БД</param>
        /// <returns>
        /// Возвращает асинхронную операцию, результатом которой является:<br></br>
        /// 1. При успешном выполнении запроса к БД:<br></br>
        /// (значение некоторого типа, упакованное в <see cref="object"/>; false)<br></br>
        /// (<see cref="int"/>, упакованный в <see cref="object"/>; true)<br></br>
        /// 2. Иначе:<br></br>
        /// (-1; true)
        /// </returns>
        public static async Task<(object, bool)> GetNoScalarResult(Task<object> dbResponseTask)
        {
            object response = await dbResponseTask;
            if (response is string)
            {
                MessageBox.Show($"Описание ошибки:\n{response.ToString()}", "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (-1, true);
            }
            else if (response is int) return (response, true);
            else return (response, false);
            
        }

        /// <summary>
        /// Получает имя сотрудника по его идентификатору
        /// </summary>
        /// <param name="usrID">Идентификатор сотрудника</param>
        /// <returns>Возвращает асинхронную операцию, возвращающую строку - имя сотрудника</returns>
        public static async Task<string> GetEmployee(string usrID)
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
        public async static Task<string> GetEmployeeID(string shortSnp)
        {
            string query = $@"select UserID from {Db.Name}.`user` where concat(UserSurname, ' ', substring(UserName, 1, 1), '. ', case when UserPatronymic is null then '' else substring(UserPatronymic, 1, 1) end) = '{shortSnp}';";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            string eId = (dt.Rows.Count != 0) ? dt.Rows[0][0].ToString() : null;
            return eId;
        }

        /// <summary>
        /// Преобразует <see cref="DataTable"/> в массив строк (string[]), упаковывая значения всех строк и полей в один массив<br></br>
        /// Не рекомендуется для таблиц с числом полей более 1
        /// </summary>
        /// <param name="dt">Таблица <see cref="DataTable"/></param>
        /// <returns>Возвращает общий массив значений полей всех строк</returns>
        public static string[] DataTableToStringArray(DataTable dt)
        {
            List<string> result = new List<string>();
            int r = 0;
            while (r < dt.Rows.Count)
            {
                int colCount = dt.Rows[r].ItemArray.Length;
                int c = 0;
                while (c < colCount)
                {
                    string value = (dt.Rows[r][c] != DBNull.Value) ? dt.Rows[r][c].ToString() : null;
                    result.Add(value);
                    c++;
                }
                r++;
            }
            return result.ToArray();
        }

        /// <summary>
        /// Преобразует <see cref="DataTable"/> в массив массивов строк (string[][]), упаковывает поля каждой строки в отдельный массив
        /// </summary>
        /// <param name="dt">Таблица <see cref="DataTable"/></param>
        /// <returns>Возвращает массив массивов значений по строкам</returns>
        public static string[][] MultiColumnDataTableToStringArray(DataTable dt)
        {
            List<string[]> result = new List<string[]>();
            int r = 0;
            while (r < dt.Rows.Count)
            {
                List<string> row = new List<string>();
                int colCount = dt.Rows[r].ItemArray.Length;
                int c = 0;
                while (c < colCount)
                {
                    string value = (dt.Rows[r][c] != DBNull.Value) ? dt.Rows[r][c].ToString() : null;
                    row.Add(value);
                    c++;
                }
                result.Add(row.ToArray());
                r++;
            }
            return result.ToArray();
        }

        /// <summary>
        /// Проверяет наличие отличий между двумя массивами байт между собой
        /// </summary>
        /// <param name="arr1">Массив байт 1</param>
        /// <param name="arr2">Массив байт 2</param>
        /// <returns>Возвращает <see cref="true"/>, если массивы различны, иначе <see cref="false"/></returns>
        public static bool IsImageBytesDifference(byte[] arr1, byte[] arr2)
        {
            if (arr1 == null && arr2 == null) return false;
            else if (arr1 == null) return true;
            else if (arr2 == null) return true;
            string hash1 = Security.hashMd5(BitConverter.ToString(arr1, 0), "");
            string hash2 = Security.hashMd5(BitConverter.ToString(arr2, 0), "");
            return hash1 != hash2;
        }

        public static async Task<object[]> GetPersonClientInfo(string clientId)
        {
            Db db = new Db();
            string query = $@"select
ClientName, ClientAddress, ClientBankAccount, ClientBank, ClientPhone, ClientEmail, ClientPhoto
from project_office.client where ClientID = {clientId};";
            var task = db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return new object[] { };
            else return dt.Rows[0].ItemArray;
        }

        public static async Task<object[]> GetOrgClientInfo(string clientId)
        {
            Db db = new Db();
            string query = $@"select ClientOrgTypeID, ClientName, ClientAddress, ClientBankAccount, ClientBank, 
ClientPhone, ClientEmail, ClientOrgINN, ClientOrgKPP, ClientOrgOGRN, ClientOrgBIK, ClientPhoto from client where ClientID = {clientId};";
            var task = db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return new object[] { };
            else return dt.Rows[0].ItemArray;
        }

        /// <summary>
        /// Удаляет запись о клиенте из БД
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="force">Флаг подтверждения удаления</param>
        /// <returns>(количество удалённых записей; флаг возврата из-за обнаруженных связей)</returns>
        public static async Task<(int, bool)> DeleteClient(string clientId, bool force = false)
        {
            string query = $"select ProjectID from {Db.Name}.project where ProjectCustomerID = {clientId};";
            string[] projectIds = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            if (!force && projectIds.Length > 0)
            {
                return (-1, true);
            }

            int total = 0;
            int projIndx = 0;
            while (projIndx < projectIds.Length)
            {
                Project temp = await Project.InitilazeAsync(projectIds[projIndx]);
                int deleted = Convert.ToInt32(await temp.Delete());
                if (deleted == -1)
                {
                    return (-1, false);
                }
                total += deleted;
                projIndx++;
            }
            query = $"delete from {Db.Name}.`client` where ClientID = {clientId}";
            (object n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query)));
            total += Convert.ToInt32(n);
            return (total, false);
        }

        /// <summary>
        /// Удаляет запись о пользователе (сотруднике) из БД
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="force">Флаг подтверждения удаления</param>
        /// <returns>(количество удалённых записей; флаг возврата из-за обнаруженных связей)</returns>
        public static async Task<(int, bool)> DeleteUser(string userId, bool force = false)
        {
            string query = $"select ProjectID from {Db.Name}.userproject where UserID = {userId};";
            string[] projIds = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));

            if (!force && projIds.Length > 0)
            {
                return (-1*(projIds.Length), true);
            }

            object n = null;
            int total = 0;

            query = $"delete from {Db.Name}.userproject where UserID = {userId};";
            (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query)));
            if (Convert.ToInt32(n) == -1)
            {
                return (-1, false);
            }
            else total += Convert.ToInt32(n);

            query = $"delete from {Db.Name}.`user` where UserID = {userId};";
            (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query)));
            if (Convert.ToInt32(n) == -1)
            {
                return (-1, false);
            }
            else total += Convert.ToInt32(n);
            return (total, false);
        }

        public static void SetSizeForImageRow(ref DataGridView table, string imgColName, int imgColWidth = 80, int rowHeight = 100)
        {
            table.Columns[imgColName].Width = imgColWidth;
            int row = 0;
            while (row < table.Rows.Count)
            {
                table.Rows[row].MinimumHeight = 20;
                table.Rows[row].Height = rowHeight;
                row++;
            }
        }

        public static void SetSizeForImageRow(ref DataGridView table, int imgColIndx, int imgColWidth = 80, int rowHeight = 100)
        {
            table.Columns[imgColIndx].Width = imgColWidth;
            int row = 0;
            while (row < table.Rows.Count)
            {
                table.Rows[row].MinimumHeight = 20;
                table.Rows[row].Height = rowHeight;
            }
        }
    }
}
