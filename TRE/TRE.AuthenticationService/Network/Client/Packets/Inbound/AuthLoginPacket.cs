using System;
using System.Collections.Generic;
using System.Text;

using TRE.DataAccess.Common;
using TRE.DataAccess;

using TRE.AuthenticationService.Network.Client.Packets.Outbound;
using TRE.AuthenticationService.Network.Crypt;

//using Org.BouncyCastle.Crypto.Engines;
//using Org.BouncyCastle.Crypto;

namespace TRE.AuthenticationService.Network.Client.Packets.Inbound
{
    public class AuthLoginPacket : InboundPacket
    {
        private byte[] buffer;

        public AuthLoginPacket(GameClient client, byte[] data)
            : base(client, data)
        {

        }

        public override void Read()
        {
            buffer = ReadBytes(128);
        }

        private string PrepareString(string Value)
        {
            StringBuilder sb = new StringBuilder();
            //string newStr = string.Empty;
            for (short i = 0; i < Value.Length - 1; i++)
            {
                if (char.IsLetterOrDigit(Value[i]))
                    //newStr += Value[i];
                    sb.Append(Value[i]);
            }
            return sb.ToString();// newStr;
        }

        public override void Run()
        {
            if (ServerList.Instance.GameServerList.Count == 0)
            {
                this.GameClient.SendPacket(new LoginFailPacket(this.GameClient, LoginFailPacket.FailReason.NO_SERVERS_AVAILABLE));
            }

            Logger.WriteLog(buffer.ToString(), Logger.LogType.Debug);
        }
    }
}
