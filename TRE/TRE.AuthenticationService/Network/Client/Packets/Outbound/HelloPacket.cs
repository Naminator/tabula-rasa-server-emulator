using System;
using System.Collections.Generic;
using System.Text;

using TRE.AuthenticationService.Network.Client.Packets;

namespace TRE.AuthenticationService.Network.Client.Packets.Outbound
{
    public class HelloPacket : OutboundPacket
    {
        public HelloPacket(GameClient client)
            : base(client)
        {

        }

        //Handshake success thanks to Dahrkael from InfiniteRasa C++ Emulator
        protected internal override void Write()
        {
            unchecked
            {
                WriteShort(0x0B); //Packet length
                WriteByte(0x00); //OPCode
                WriteUInt(0xDEAD0E01); //Unknown 1
                WriteInteger(0x00); //Unknown 2 / End
            }
        }
    }
}
