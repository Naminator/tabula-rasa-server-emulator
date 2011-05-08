using System;
using System.Collections.Generic;
using System.Text;

namespace TRE.AuthenticationService.Network.Client.Packets.Outbound
{
    public class LoginFailPacket : OutboundPacket
    {
        FailReason _reason;

        public LoginFailPacket(GameClient client, FailReason reason)
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
            this.WriteShort(0x07);
            this.WriteByte(0x02);
            //this.WriteInteger((int)_reason);
            this.WriteUInt((uint)_reason);
        }
    }
}
