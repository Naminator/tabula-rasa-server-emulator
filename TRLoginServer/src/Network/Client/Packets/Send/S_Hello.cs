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

        protected internal override void Write()
        {
            unchecked
            {
                WriteByte(0x00);
                //[23:06] <Dahrkael> 0x0B 0x00 0xDEAD0EE01 0x00
                WriteByte(0);
            }
        }
    }
}
