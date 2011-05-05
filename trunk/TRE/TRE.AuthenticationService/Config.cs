using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using TRE.DataAccess.Common;

namespace TRE.AuthenticationService
{
    public static partial class Config
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

        public static IPAddress GameServerListenAddr
        {
            get { 
                string ip = System.Configuration.ConfigurationManager.AppSettings["GameServerIP"];
                IPAddress address;
                if (! IPAddress.TryParse(String.IsNullOrEmpty(ip) ? "127.0.0.1" : ip, out address) )
                    throw new Exception("Illegal value for GameServerIP property in configuration file.");

                return address; 
            }
        }

        public static int GameServerListenPort
        {
            get { 
                int port = 4001; // default
                if (! Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings["LoginServerIP"], out port) )
                    throw new Exception("Illegal value for LoginServerIP property in configuration file.");
                return port;
            }
        }

        public static IPAddress LoginServerListenAddr
        {
            get { 
                string ip = System.Configuration.ConfigurationManager.AppSettings["LoginServerIP"];
                IPAddress address;
                if (! IPAddress.TryParse(String.IsNullOrEmpty(ip) ? "127.0.0.1" : ip, out address) )
                    throw new Exception("Illegal value for GameServerIP property in configuration file.");

                return address; 
            }
        }

        public static int LoginServerListenPort
        {
            get { 
                int port = 2106; // default
                if (! Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings["LoginServerPort"], out port) )
                    throw new Exception("Illegal value for LoginServerIP property in configuration file.");
                return port;
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
    }
}
