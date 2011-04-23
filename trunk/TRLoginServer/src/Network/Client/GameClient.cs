using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

using TRLoginServer.src.Network.Crypt;
using TRLoginServer.src.Utils;

namespace TRLoginServer.src.Network.Client
{
    public class GameClient
    {
        public delegate void DisconnectHandler(GameClient client);

        private Socket _socket;
        private byte[] _buffer;
        private byte[] _blowFishKey;
        private CryptEngine _loginCrypt;
        private ScrambledKeyPair _scrambledPair;
        public DisconnectHandler DisconnectHandle { get; set; }
        private FloodProtector _FloodProtector;

        public GameClient(Socket socket)
        {
            _socket = socket;
            _FloodProtector = new FloodProtector(50, 1000);
            _blowFishKey = GameClientProcessor.Instance.GenerateBlowfishKey();
            //_scrambledPair = GameClientProcessor.Instance.GenerateScrambledPair();

            _socket.Send(_blowFishKey);

            
        }

        private void Disconnect()
        {
            _socket.Disconnect(false);
            if (DisconnectHandle != null)
            {
                DisconnectHandle(this);
            }
            MaxConnections.Disconnect(_socket.RemoteEndPoint);
        }

        public IPEndPoint RemoteEndPoint
        {
            get { return (IPEndPoint)_socket.RemoteEndPoint; }
        }

        public byte[] BlowfishKey
        {
            get { return _blowFishKey; }
        }

        public ScrambledKeyPair ScrambledPair
        {
            get { return _scrambledPair; }
        }


    }
}
