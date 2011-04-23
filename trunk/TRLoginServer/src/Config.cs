using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;

using TRLoginServer.src.Utils;

namespace TRLoginServer.src
{
    public class Config
    {
        private static string configPath = "./Config/General.ini";

        private static IPAddress _clientListenAddr;
        private static ushort _clientListenPort;

        private static IPAddress _serverListenAddr;
        private static ushort _serverListenPort;

        private static bool _debugMode;

        private static string _dbHost, _dbUser, _dbPass, _dbName;

        public static void Load()
        {
            Logger.WriteLog("Loading configuration file...", Logger.LogType.Initialize);

            ConfigFile general = new ConfigFile(configPath);

            //Parse variables
            _clientListenAddr = IPAddress.Parse(general.getProperty("LoginServer", "ListenIP", "0.0.0.0"));
            _clientListenPort = ushort.Parse(general.getProperty("LoginServer", "port", "2106"));

            _serverListenAddr = IPAddress.Parse(general.getProperty("GameServer", "ListenIP", "0.0.0.0"));
            _serverListenPort = ushort.Parse(general.getProperty("GameServer", "port", "4001"));

            _debugMode = bool.Parse(general.getProperty("Debug", "DebugMode", "false"));

            _dbHost = general.getProperty("Database", "Host", "localhost");
            _dbUser = general.getProperty("Database", "User", "root");
            _dbPass = general.getProperty("Database", "Password", "");
            _dbName = general.getProperty("Database", "Database", "tabularasa");

        }

        public static bool DebugMode
        {
            get { return _debugMode; }
        }

        public static IPAddress GameServerListenAddr
        {
            get { return _serverListenAddr; }
        }

        public static ushort GameServerListenPort
        {
            get { return _serverListenPort; }
        }

        public static IPAddress LoginServerListenAddr
        {
            get { return _clientListenAddr; }
        }

        public static ushort LoginServerListenPort
        {
            get { return _clientListenPort; }
        }

        public static string DatabaseHost
        {
            get { return _dbHost; }
        }

        public static string DatabaseUser
        {
            get { return _dbUser; }
        }

        public static string DatabasePassword
        {
            get { return _dbPass;  }
        }

        public static string DatabaseName
        {
            get { return _dbName; }
        }

        public static Hashtable DbConnectionInfo
        {
            get {
                Hashtable dbInfo = new Hashtable();
                dbInfo.Add("Host", _dbHost);
                dbInfo.Add("User", _dbUser);
                dbInfo.Add("Password", _dbPass);
                dbInfo.Add("Database", _dbName);

                return dbInfo;
            }
        }
    }
}
