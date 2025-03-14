﻿using System;
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
                    result.Add(dt.Rows[r][c].ToString());
                    c++;
                }
                r++;
            }
            return result.ToArray();
        }
    }
}
