using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using ConsoleAuthServerThuvvik.Communication;
using ConsoleAuthServerThuvvik.Cryptography;
using System.Runtime.InteropServices;

namespace ConsoleAuthServerThuvvik.Configuration
{
    public class ThreadManager
    {
        private Thread _clientWaiter;
        private TRTeam_BlowFishProcess _bfp = new TRTeam_BlowFishProcess();
        private TRTeam_OwnProcess _op = new TRTeam_OwnProcess();

        //private Thread _serverWaiter; // not used in Dharkael code.

        private Boolean _serverRunning = true;
        public Boolean serverRunning
        {
            set
            {
                _serverRunning = value;
            }
        }


        /// <summary>
        /// Used to close every thread currently opened.
        /// </summary>
        public void joinAllThreads()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Only instantiate internally the clients' waiter thread
        /// </summary>
        public void createAndActivateNewClientWaiter()
        {
            _clientWaiter = new Thread(new ThreadStart(waitForClients));
            _clientWaiter.Start();
        }

        public void waitForClients()
        {
            // create network Socket (winsok)
            //TODO : basculer Socket dans socketManager prévu à cet effet.
            //TODO : enlever valeurs par défaut et passer paramètres depuis main
            IPAddress ipaddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener tcpl = new TcpListener(ipaddress, 2106);
            tcpl.Start();
            while (_serverRunning)
            {

                Display.displayMessage("Thread tourne.");
                TcpClient tcpC = tcpl.AcceptTcpClient();               
                if (tcpC.Connected)
                {
                    Display.displayMessage("Client connecté !! ");
                    Display.displayMessage("Address : " + tcpC.Client.RemoteEndPoint.ToString());

                    // Create Thread for its process.

                    Thread playerHandler = new Thread(new ParameterizedThreadStart(handleIncomingClient));
                    playerHandler.Start(tcpC);

                }
            }

            Thread.Sleep(100);
        }

        private void handleIncomingClient(object pTcpC)
        {
            TcpClient tcpC = (TcpClient)pTcpC;
            Display.displayMessage("On gère le client connecté!!");

            // Test AuthHello
            PacketManager pm = new PacketManager();
            pm.sendAuthHello(tcpC);
            Byte[] buffer = new byte[128];
            int result = tcpC.Client.Receive(buffer);


            for(int i=0; i<6; i++) //(0x32-2)/8; i++)
	        {
                UInt32 a = BitConverter.ToUInt32(buffer, 2 + i * 8);
                UInt32 b = BitConverter.ToUInt32(buffer, 2 + i * 8 + 4);

                _bfp.BFDecrypt(ref a,ref b);

                Byte[] bA = BitConverter.GetBytes(a);
                Byte[] bB = BitConverter.GetBytes(b);

                for (int j = 0; j < 4; j++)
                {
                    buffer[2 + i * 8 + j] = bA[j];
                    buffer[2 + i * 8 + 4 + j] = bB[j];
                }
	        }
            AuthLogin packet = new AuthLogin();
            packet.UserData = new Byte[30];
            packet = StructureOperations.RawDeserialize<AuthLogin>(buffer, 0);
            int size = Marshal.SizeOf(packet);
            if (packet.OPCode != OPCode.AuthL)
            {
                // fucked up !!
                throw new NotImplementedException("Fucked up like JH said");
            }

            
            _op.decrypt(ref packet.UserData, packet.UserData.Length);

            AuthLoginOk(packet, tcpC);
        }

        //void HandleMessage::AuthLoginOk(Player* player, CryptManager* Crypt)
        private void AuthLoginOk(AuthLogin Ppacket,TcpClient tcpC)
        {
            // related to subscription, need info
            AuthLoginOk packet;
            packet.PacketLength = 0x28;
            packet.OPCode		= OPCode.AuthLO;
            packet.Unknown1		= 0x00;
            packet.Unknown2		= 0x00;
            packet.Unknown3		= 0x00;
            packet.Unknown4		= 0x00;
            packet.Unknown5		= 0x00;
            packet.Unknown6		= 0x00;
            packet.Unknown7		= 0x00;
            packet.Unknown8		= 0x00;
            packet.Unknown9		= 0x00;
            packet.Unknown10	= 0x00;

        //    Net::SendEncrypted(player->socket, (char*)&packet, 0x28, Crypt);
            SendEncrypted(packet, tcpC, 0x28);
        //    return;
        }

        //void Net::SendEncrypted(SOCKET s, const char* buff, int len, CryptManager* Crypt)
        private void SendEncrypted(AuthLoginOk Ppacket,TcpClient tcpC, int len)
        {
            // char buffer[128];
            Byte[] buffer = new Byte[128];
            int length = len;

            //memcpy((void*)&buffer,(void*)buff, len);
            for (int i = 0; i < 128; i++)
               buffer[i] = 204; // très très moche !!! l'agorithme se base sur la valeur de non-initialisation en C !!
            
            Byte[] temp = StructureOperations.RawSerialize(Ppacket);
            for (int iCopy = 0; iCopy < len; iCopy++)
                buffer[iCopy] = temp[iCopy];
           
            //Align to 8 bytes
            length = length + ((8-((length-2)%8))%8);

            //Calculate checksum
            UInt32 CS = 0;
            for(int p=0; p<(length-2)/4; p++)
                CS = Convert.ToUInt32(CS  ^ buffer[p * 4 + 2]);

            //Add checksum and unknown value
            buffer[length] = Convert.ToByte(CS);
            buffer[length+4] = 0;
            length += 8;

            buffer[0] = Convert.ToByte(length);
            
            for(int p=0; p<(length-2)/8; p++)
            {
                uint a = (uint)buffer[p*8+2];
                uint b = (uint)buffer[6 + p*8];

                _bfp.BFEncrypt(ref a,ref b);

                Byte[] bA = BitConverter.GetBytes(a);
                Byte[] bB = BitConverter.GetBytes(b);

                for (int j = 0; j < 4; j++)
                {
                    buffer[p * 8 + 2 + j] = Convert.ToByte(bA[j]);
                    buffer[6 + p * 8 + j] = Convert.ToByte(bB[j]);
                }
            }

            tcpC.Client.Send(buffer);
        }
    }
}
