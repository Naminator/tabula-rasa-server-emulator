using System;
using System.Collections.Generic;
using System.Text;

using TRLoginServer.src.Network.Client.Packets.Send;
using TRLoginServer.src.Utils;
using TRLoginServer.src.Database;
using TRLoginServer.src.Database.Tables;
using TRLoginServer.src.Network.Crypt;

using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto;

namespace TRLoginServer.src.Network.Client.Packets.Receive
{
    public class R_AuthLogin : ReceiveBasePacket
    {
        private byte[] buff;

        public R_AuthLogin(GameClient client, byte[] packet)
            : base(client, packet)
        {

        }

        public override void Read()
        {
            buff = ReadBytes(128);
        }

        private string PrepareString(string Value)
        {

            string newStr = "";
            for (short i = 0; i < Value.Length - 1; i++)
            {
                if (char.IsLetterOrDigit(Value[i]))
                    newStr += Value[i];
            }
            return newStr;
        }

        public override void Run()
        {
            if (ServerList.Instance.GameServerList.Count == 0)
            {
                Client.SendPacket(new S_LoginFail(Client, S_LoginFail.FailReason.NO_SERVERS_AVAILABLE));
                return;
            }

            Logger.WriteLog(buff.ToString(), Logger.LogType.Debug);
        }
    }
}
