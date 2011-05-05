using System;
using System.Collections.Generic;
using System.Text;

namespace TRLoginServer.src.Network.Client.Packets.Send
{
    public class S_LoginFail : SendBasePacket
    {
        FailReason _reason;

        public S_LoginFail(GameClient client, FailReason reason)
            : base(client)
        {
            _reason = reason;
        }

        public enum FailReason
        {
            SYSTEM_ERROR            = 0x01,
            INVALID_PASSWORD        = 0x02,
            INVALID_PASSWORD_2      = 0x03,
            INVALID_PASSWORD_3      = 0x04,
            NO_SERVERS_AVAILABLE    = 0x06,
            ALREADY_LOGGED_IN		= 0x07,
            KICKED					= 0x0B,
        }

        protected internal override void Write()
        {
            WriteShort(0x07);
            WriteByte(0x02);
            //WriteInteger((int)_reason);
            WriteInteger(0x03);

            //WriteInteger(0x00);
        }
    }
}
