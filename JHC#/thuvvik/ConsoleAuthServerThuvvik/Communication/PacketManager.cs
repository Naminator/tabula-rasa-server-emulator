using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ConsoleAuthServerThuvvik.Communication
{
    /// <summary>
    /// creer Packet de données
    /// Encrypter ou pas
    /// envoyer.
    /// </summary>
    public class PacketManager
    {
        public void sendAuthHello(TcpClient tcpC)
        {
            AuthHello packetAuthHello = new AuthHello();
            packetAuthHello.PacketLength    = 0x0B;
	        packetAuthHello.OPCode		    = OPCode.AuthH;
	        packetAuthHello.Unknown1		= 0xDEAD0E01;
	        packetAuthHello.Unknown2		= 0x00;

            tcpC.Client.Send(StructureOperations.RawSerialize(packetAuthHello), 0, 0x0B, 0);
        }   
    }
}
