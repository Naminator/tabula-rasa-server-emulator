using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

using TRLoginServer.src.Network.Crypt;
using TRLoginServer.src.Utils;
using TRLoginServer.src.Network.Client.Packets;
using TRLoginServer.src.Network.Client.Packets.Send;
using TRLoginServer.src.Network.TRCrypt;

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
            _scrambledPair = GameClientProcessor.Instance.GenerateScrambledPair();
            _loginCrypt = new CryptEngine();
            _loginCrypt.updateKey(_blowFishKey);

            SendPacket(new S_Hello(this));
            Read();
        }

        public void SendPacket(SendBasePacket packet)
        {
            packet.Write();

            //Yes it's stupid >.< But its a quick workaround \m/o_O\m/
            if (!(packet is TRLoginServer.src.Network.Client.Packets.Send.S_Hello))
            {
                byte[] pck = packet.ToByteArray();
                //pck = _loginCrypt.Encrypt(pck);
                pck = _loginCrypt.EncryptDbg(pck);

                List<Byte> FullPacket = new List<byte>();
                FullPacket.AddRange(BitConverter.GetBytes((short)(pck.Length + 2)));
                FullPacket.AddRange(pck);
                _socket.Send(FullPacket.ToArray());
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
            try
            {
                if (_socket.EndReceive(ar) >= 2)
                {
                    _buffer = new byte[BitConverter.ToInt16(_buffer, 0) - 2];

                    if (_buffer.Length > 128)
                    {
                        Logger.WriteLog("Possible incorrect packet from " + _socket.RemoteEndPoint.ToString(), Logger.LogType.Network);
                        Disconnect();
                        return;
                    }

                    if (_buffer.Length > 0)
                    {
                        _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.Partial, ReadCallback, null);
                        return;
                    }
                    else
                    {
                        Disconnect();
                        return;
                    }
                }
                else
                {
                    Disconnect();
                    return;
                }
            }
            catch
            {
                Logger.WriteLog("Catched exception at reading callback", Logger.LogType.Error);
                Disconnect();
                return;
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                if (_socket.EndReceive(ar) >= 1)
                {
                    //Copy the buffer so we can receive the next packet ASAP
                    byte[] buff = new byte[_buffer.Length];
                    Array.Copy(_buffer, buff, _buffer.Length);

                    //Read();

                    CryptWrapper CW = new CryptWrapper();
                    for (int i = 0; i < ( buff.Length / 8 ); i++)
                    {
                        CW.BFDecrypt((uint)buff[i * 8], (uint)buff[i * 8 + 4]);

                        string byteData = System.Text.Encoding.Unicode.GetString(buff);
                        Console.WriteLine(byteData);

                    }

                    //Send Login fail for check
                    SendPacket(new S_LoginFail(this, S_LoginFail.FailReason.INVALID_PASSWORD_2));

                    Disconnect();
                    return;


                    //Process the packet
                    Type pck = ClientPacketProcessor.ProcessPacket(buff);
                    if (pck != null)
                    {
                        ReceiveBasePacket rbp = (ReceiveBasePacket)Activator.CreateInstance(pck, this, buff);
                        Thread pckRun = new Thread(rbp.Run);
                        pckRun.Start();
                    }
                    else
                    {
                        Disconnect();
                        return;
                    }
                }
            }
            catch(Exception e)
            {
                Logger.WriteLog("Exception: " + e.Message, Logger.LogType.Error);
                Disconnect();
                return;
            }
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
