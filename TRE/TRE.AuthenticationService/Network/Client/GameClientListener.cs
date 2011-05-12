using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

using TRE.DataAccess.Common;
//using TRE.DataAccess.Entities;

namespace TRE.AuthenticationService.Network.Client
{
    public sealed class GameClientListener
    {
        static GameClientListener instance = null;
        static readonly object padlock = new object();

        public static GameClientListener Instance
        {
            get { lock (padlock) { if (instance == null)instance = new GameClientListener(); return instance; } }
        }

        private Socket _listener;

        public GameClientListener()
        {
            Logger.WriteLog("Initializing GameClientListener...", Logger.LogType.Initialize);
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Listen()
        {
            try
            {
                _listener.Bind(new IPEndPoint(Config.LoginServerListenAddr, Config.LoginServerListenPort));
                Logger.WriteLog(string.Format("Listening for clients on {0} port", Config.LoginServerListenPort), Logger.LogType.Network);
                _listener.Listen(100);
                _listener.BeginAccept(OnClientAccept, null);


                return true;
            }
            catch (Exception e)
            {
                Logger.WriteLog("Unable to listen for clients on " + Config.LoginServerListenPort + "port\r\n" + e.Message, Logger.LogType.Error);
                this.Close();
                return false;
            }
        }

        public void Close()
        {
            Logger.WriteLog("Closing the GameClientListener...", Logger.LogType.Network);
            _listener.Close();
        }

        private void OnClientAccept(IAsyncResult ar)
        {
            Socket acceptedSocket = _listener.EndAccept(ar);
            System.Threading.Thread.Sleep(50);

            if (MaxConnections.AcceptConnection(acceptedSocket.RemoteEndPoint))
            {
                GameClientProcessor.Instance.ProcessClient(acceptedSocket);
            }
            else
            {
                //Disconnect
                acceptedSocket.Disconnect(false);
                acceptedSocket = null;
            }

            _listener.BeginAccept(OnClientAccept, null);
        }
    }
}
