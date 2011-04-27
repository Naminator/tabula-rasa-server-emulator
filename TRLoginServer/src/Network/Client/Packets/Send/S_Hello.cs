using System;
using System.Collections.Generic;
using System.Text;

namespace TRLoginServer.src.Network.Client.Packets.Send
{
    public class S_Hello : SendBasePacket
    {
        public S_Hello(GameClient client)
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
