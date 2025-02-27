using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using ProjectOffice.logic.app;
using MySql.Data.MySqlClient;

namespace ProjectOffice.logic
{
    public class Db
    {
        public static string Name { get { return AppSettings.dbName;  } }
        private Regex _regexp = null;

        public string MakeConnectionString(bool withDbName = true)
        {
            string conStr = $"host={AppSettings.dbHost};user={AppSettings.dbUser};password={AppSettings.dbUserPass};";
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

        public int ExecuteNoDataResult(string query)
        {
            (MySqlConnection con, int errCode) = GetOpenConnection();
            if (con == null) return -1;
            MySqlCommand com = new MySqlCommand(query, con);
            int affected = 0;
            try
            {
                affected = com.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                con.Close();
                return -1;
            }
            con.Close();
            return affected;
        }

        //public (int, Exception) ExecuteNoDataResult(string query) {
        //    (MySqlConnection con, int errCode) = GetOpenConnection();
        //    if (con == null) return (-1, null);
        //    MySqlCommand com = new MySqlCommand(query, con);
        //    int affected = 0;
        //    try
        //    {
        //        affected = com.ExecuteNonQuery();
        //    }
        //    catch (MySqlException e)
        //    {
        //        con.Close();
        //        return (-1, e);
        //    }
        //    con.Close();
        //    return (affected, null);
        //}

        public object ExecuteScalar(string query)
        {
            (MySqlConnection con, int errCode) = GetOpenConnection();
            if (con == null) return -1;
            MySqlCommand com = new MySqlCommand(query, con);
            object result = null;
            try
            {
                result = com.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                con.Close();
                return ex;
            }
            con.Close();
            return result;
        }

        public DataTable ExecuteReader(string query, params string[] args)
        {
            (MySqlConnection con, int errCode) = GetOpenConnection();
            if (con == null) return null;
            MySqlCommand com = new MySqlCommand(query, con);

            if (query.Contains("@"))
            {
                _regexp = new Regex("@\\w*");
                MatchCollection mathces = _regexp.Matches(query);
                int i = 0;
                foreach (Match param in mathces)
                {
                    try
                    {
                        com.Parameters.AddWithValue(param.Value.Replace("@", ""), args[i]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                    i++;
                }
            }

            DataTable dt = new DataTable();
            try
            {
                MySqlDataReader rdr = com.ExecuteReader();
                dt.Load(rdr);
            }
            catch (MySqlException e)
            {
                ;
                return null;
                con.Close();
            }
            return dt;
        }

        public string[] FindUser(string login, string passwd)
        {
            string query = $"select concat(UserSurname, ' ', substring(UserName, 1, 1), '.', substring(UserPatronymic, 1, 1)) as snf, UserModeID, UserID from `{AppSettings.dbName}`.`user` where UserLogin = @login and UserPassword = @pswd;";

            DataTable result = ExecuteReader(query, login, passwd);
            if (result == null) return null; 

            if (result.Rows.Count == 0)
            {
                return new string[] { "Пользователь с такими учётными данными не найден." };
            }
            return new string[] { result.Rows[0][0].ToString(), result.Rows[0][1].ToString(), result.Rows[0][2].ToString() };
        }
    }
}
