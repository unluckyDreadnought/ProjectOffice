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
    }
}
