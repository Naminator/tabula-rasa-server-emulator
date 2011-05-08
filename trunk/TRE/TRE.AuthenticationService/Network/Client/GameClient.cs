using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

using TRE.DataAccess.Common;

using TRE.AuthenticationService.Network.Crypt;
using TRE.AuthenticationService.Network.Client.Packets;
using TRE.AuthenticationService.Network.Client.Packets.Outbound;

namespace TRE.AuthenticationService.Network.Client
{
    public class GameClient
    {
        public delegate void DisconnectHandler(GameClient client);

        private Socket _socket;
        private byte[] _buffer;
        //private byte[] _blowFishKey;
        //private ScrambledKeyPair _scrambledPair;
        //private CryptEngine _loginCrypt;
        public DisconnectHandler OnDisconnect { get; set; }
        private FloodProtector _FloodProtector;

        public GameClient(Socket socket)
        {
            _socket = socket;
            _FloodProtector = new FloodProtector(50, 1000);
            //_blowFishKey = GameClientProcessor.Instance.GenerateBlowfishKey();
            //_scrambledPair = GameClientProcessor.Instance.GenerateScrambledPair();
            // _loginCrypt = new CryptEngine();
            //_loginCrypt.updateKey(_blowFishKey);

            this.SendPacket(new HelloPacket(this));
            this.Read();
        }

        public void SendPacket(OutboundPacket packet)
        {
            //Constructs the packet
            packet.Write();

            // encrypt every outgoing packet except the hello packet
            if (!(packet is TRE.AuthenticationService.Network.Client.Packets.Outbound.HelloPacket))
            {
                byte[] encryptedData = packet.ToByteArray(); // not yet encrypted

                Console.WriteLine(BitConverter.ToString(encryptedData));

                //encryptedData = CryptEngine.GetInstance().Encrypt(encryptedData);
                //TREncryptor.Instance.Encrypt(ref encryptedData);
                TREncryptor.Init().Encrypt(ref encryptedData);

                Console.WriteLine(BitConverter.ToString(encryptedData));

                /*List<Byte> fullData = new List<byte>();
                fullData.AddRange(BitConverter.GetBytes((short)(encryptedData.Length + 2)));
                fullData.AddRange(encryptedData);
                _socket.Send(fullData.ToArray());*/

                _socket.Send(encryptedData);

                return;
            }

            _socket.Send(packet.ToByteArray());
        }

        private void Read()
        {
            _buffer = new byte[2];
            _socket.BeginReceive(_buffer, 0, 2, SocketFlags.Partial, ReadCallbackStatic, null);
        }

        private void ReadCallbackStatic(IAsyncResult ar)
        {
            bool dontDisconnect = false;
            try
            {
                if (_socket.EndReceive(ar) >= 2)
                {
                    _buffer = new byte[BitConverter.ToInt16(_buffer, 0) - 2];

                    if (_buffer.Length > 128)
                    {
                        Logger.WriteLog("Possible incorrect packet from " + _socket.RemoteEndPoint.ToString(), Logger.LogType.Network);
                    }
                    else
                        if (_buffer.Length > 0)
                        {
                            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.Partial, ReadCallback, null);
                            dontDisconnect = true;
                        }

                }

            }
            catch
            {
                Logger.WriteLog("Catched exception at reading callback", Logger.LogType.Error);
            }
            finally
            {
                if (!dontDisconnect)
                    this.Disconnect();
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                if (_socket.EndReceive(ar) >= 1)
                {
                    //Copy the buffer so we can receive the next packet ASAP
                    byte[] data = new byte[_buffer.Length];
                    Array.Copy(_buffer, data, _buffer.Length);

                    //Read();

                    //Doesn't yet works :/
                    //_loginCrypt.Decrypt(buff);
                    //CryptEngine.GetInstance().Decrypt(data);

                    //Send Login fail for check
                    SendPacket(new LoginFailPacket(this, LoginFailPacket.FailReason.INVALID_PASSWORD_2));

                    this.Disconnect();
                    return; // Cutting the function because i haven't figured the encryption this is for tests only

                    //Process the packet
                    /*Type pck = ClientPacketProcessor.ProcessPacket(data);
                    if (pck != null)
                    {
                        InboundPacket rbp = (InboundPacket) Activator.CreateInstance(pck, this, data);
                        Thread pckRun = new Thread(rbp.Run);
                        pckRun.Start();
                    }
                    else
                    {
                        this. Disconnect();
                        return;
                    }*/
                }
            }
            catch (Exception e)
            {
                Logger.WriteLog("Exception: " + e.Message, Logger.LogType.Error);
                Disconnect();
                return;
            }
        }

        private void Disconnect()
        {
            _socket.Disconnect(false);
            if (OnDisconnect != null)
            {
                OnDisconnect(this);
            }
            MaxConnections.Disconnect(_socket.RemoteEndPoint);
        }

        public IPEndPoint RemoteEndPoint
        {
            get { return (IPEndPoint)_socket.RemoteEndPoint; }
        }

        //public byte[] BlowfishKey
        //{
        //    get { return _blowFishKey; }
        //}

        //public ScrambledKeyPair ScrambledPair
        //{
        //    get { return _scrambledPair; }
        //}


    }
}
