using System;
using System.Collections;
using System.Text;

using TRE.DataAccess;
using TRE.DataAccess.Common;
using TRE.DataAccess.Entities;

using TRE.AuthenticationService.Network;
using TRE.AuthenticationService.Network.Client;
using TRE.AuthenticationService.Network.Client.Packets;

namespace TRE.AuthenticationService
{
    class LoginServer
    {
        private GameClientListener clientListener;
        //private GameServerListener gsl;
        private MaxConnections maxConnections;

        public LoginServer()
        {
            Logger.WriteLog("Starting the login server...", Logger.LogType.Initialize);
        }

        public void Initialize()
        {
            //Load Configurations
            // automatically loaded by .net

            //Create database connection pools
            DatabaseFactory.Instance.Initialize();

            //Preload serverlist
            ServerList.Instance.Initialize();
            Logger.WriteLog(string.Format("{0} Server(s) has been loaded.", ServerList.Instance.GameServerList.Count), Logger.LogType.Debug);

            //Add listeners
            ClientPacketProcessor.Initialize();
            maxConnections = new MaxConnections();
            GameClientProcessor.Instance.Initialize();

            clientListener = GameClientListener.Instance;
         }

        public void Shutdown()
        {

        }

        public bool Start()
        {
            if (!clientListener.Listen() /* || !gs1.listen()*/)
            {
                return false;
            }

            return true;
        }
    }
}
