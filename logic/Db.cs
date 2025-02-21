using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOffice.logic.app;
using MySql.Data.MySqlClient;

namespace ProjectOffice.logic
{
    public class Db
    {
        private AppSettings _appConfig = null;

        public Db()
        {
            _appConfig = new AppSettings();
        }

        public string MakeConnectionString(bool withDbName = true)
        {
            string conStr = $"host={_appConfig.dbHost};user={_appConfig.dbUser};password={_appConfig.dbUserPass};";
            if (withDbName) conStr += $"database={_appConfig.dbName};";
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

    }
}
