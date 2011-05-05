using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using TRE.DataAccess.Common;
using TRE.AuthenticationService.Network.Crypt;

namespace TRE.AuthenticationService.Network.Client
{
    public class GameClientProcessor
    {
        public static GameClientProcessor instance = null;
        static readonly object padlock = new object();

        public static GameClientProcessor Instance
        {
            get { lock (padlock) { if (instance == null)instance = new GameClientProcessor(); return instance; } }
        }

        private List<GameClient> _clientList;

        //private int _blowFishCount = 50;
        //private int _scrambledCount = 1;
        //private byte[][] _blowFishKeys;
        //private ScrambledKeyPair[] _scrambledPairs;

        public GameClientProcessor()
        {
            _clientList = new List<GameClient>();
        }

        public void Initialize()
        {
            //GenerateBlowfishKeys();
            //GenerateScrambledPairs();
        }

        //public void GenerateBlowfishKeys()
        //{
        //    Logger.WriteLog("Initializing Blowfish keys...", Logger.LogType.Initialize);
        //    _blowFishKeys = new byte[_blowFishCount][];
        //    for (int i = 0; i < _blowFishCount; i++)
        //    {
        //        _blowFishKeys[i] = TRRandom.NextBytes(16);
        //    }
        //}

        //public void GenerateScrambledPairs()
        //{
        //    Logger.WriteLog("Initializing Scrambled Key Pairs...", Logger.LogType.Initialize);
        //    _scrambledPairs = new ScrambledKeyPair[_scrambledCount];
        //    for (int i = 0; i < _scrambledCount; i++)
        //    {
        //        _scrambledPairs[i] = new ScrambledKeyPair(ScrambledKeyPair.genKeyPair());
        //    }
        //}

        public void ProcessClient(Socket client)
        {
            Logger.WriteLog("Incoming client connection from: " + client.RemoteEndPoint.ToString(), Logger.LogType.Network);
            System.Threading.Thread.Sleep(40);
            if (MaxConnections.AcceptConnection(client.RemoteEndPoint))
            {
                GameClient gameClient = new GameClient(client);
                _clientList.Add(gameClient);
                gameClient.OnDisconnect = _OnDisconnect;
            }
            else
            {
                client.Disconnect(false);
                client = null;
            }
        }

        private void _OnDisconnect(GameClient client)
        {
            Logger.WriteLog("Client disconnected: " + client.RemoteEndPoint.ToString(), Logger.LogType.Network);
            _clientList.Remove(client);
        }

        public int ConnectedClientCount
        {
            get { return _clientList.Count; }
        }

        public GameClient[] Clients
        {
            get { return _clientList.ToArray(); }
        }

        //public byte[] GenerateBlowfishKey()
        //{
        //    return _blowFishKeys[TRRandom.Next((short)(_blowFishCount - 1))];
        //}

        //public ScrambledKeyPair GenerateScrambledPair()
        //{
        //    return _scrambledPairs[TRRandom.Next((short)(_scrambledCount - 1))];
        //}
    }

}
