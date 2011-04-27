using System;
using System.Collections;
using System.Text;

using TRLoginServer.src.Utils;
using TRLoginServer.src.Database;
using TRLoginServer.src.Database.Tables;
using TRLoginServer.src.Network;
using TRLoginServer.src.Network.Client;
using TRLoginServer.src.Network.Client.Packets;

using MySql.Data.MySqlClient;

namespace TRLoginServer.src
{
    class LoginServer
    {
        private GameClientListener gcl;
        //private GameServerListener gsl;
        private MaxConnections maxConnections;

        public LoginServer()
        {
            Logger.WriteLog("Starting the login server...", Logger.LogType.Initialize);
        }

        public void Initialize()
        {
            //Load Configurations
            Config.Load();

            //Create database connection pools
            DatabaseFactory.Instance.Initialize();

            //Preload serverlist
            ServerList.Instance.Initialize();
            Logger.WriteLog(string.Format("{0} Server(s) has been loaded.", ServerList.Instance.GameServerList.Count), Logger.LogType.Debug);

            //Add listeners
            ClientPacketProcessor.Initialize();
            maxConnections = new MaxConnections();
            GameClientProcessor.Instance.Initialize();

            gcl = GameClientListener.Instance;
         }

        public void Shutdown()
        {

        }

        public bool Start()
        {
            if (!gcl.Listen() /* || !gs1.listen()*/)
            {
                return false;
            }

            return true;
        }
    }
}
