using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleAuthServerThuvvik.Configuration;
using ConsoleAuthServerThuvvik.DAL;
using System.Data;

namespace ConsoleAuthServerThuvvik.BLL
{
    public class UserManager
    {
        public static void dbTest(IniParser pIp)
        {
            MySqlManager msm = new MySqlManager(pIp.GetSetting("Database", "host")
                                                , pIp.GetSetting("Database", "port")
                                                , pIp.GetSetting("Database", "name")
                                                , pIp.GetSetting("Database", "user")
                                                , pIp.GetSetting("Database", "password"));

            DataTable dt = msm.queryMultipleRows("SELECT * FROM sessions");

            int i = dt.Rows.Count;
        }
    }
}
