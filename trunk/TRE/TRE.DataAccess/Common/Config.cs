using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TRE.DataAccess.Common
{
    public static class Config
    {
        // Below is an example of following proper OOP
        //private static Config _instance = null;
        //private Config() { }
        //public static Config GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new Config();
        //    }
        //    return _instance;
        //}

        public static bool DebugMode
        {
            get { 
                return ( System.Configuration.ConfigurationManager.AppSettings["DebugMode"] == "True"); 
            }
        }

        public static string DatabaseHost
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DBServer"]; }
        }

        public static string DatabaseUser
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DBUser"]; }
        }

        public static string DatabasePassword
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DBPassword"]; }
        }

        public static string DatabaseName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["DBName"]; }
        }


        static Dictionary<string, string> _DbConnectionInfo = null;
        public static Dictionary<string, string> DbConnectionInfo
        {
            get
            {
                if (_DbConnectionInfo == null)
                {
                    _DbConnectionInfo = new Dictionary<string, string>();
                    _DbConnectionInfo.Add("Host", Config.DatabaseHost);
                    _DbConnectionInfo.Add("User", Config.DatabaseUser);
                    _DbConnectionInfo.Add("Password", Config.DatabasePassword);
                    _DbConnectionInfo.Add("Database", Config.DatabaseName);
                }

                return _DbConnectionInfo;
            }
        }

        public static string GetConnectionString()
        {
            //get {
                const string CNSTR = "SERVER={0};DATABASE={1},UID={2};PASSWORD={3};";

                return String.Format(CNSTR,
                    Config.DatabaseHost,
                    Config.DatabaseName,
                    Config.DatabaseUser,
                    Config.DatabasePassword);
            //}
        }
    }
}
