using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TRLoginServer.src.Network.Gameserver
{
    public class GameServer
    {
        
    }

    public class GameServerInfo
    {
        public byte ServerID { get; set; }
        public IPAddress ServerAddr { get; set; }
        public short ServerPort { get; set; }
        public ushort OnlineUsers { get; set; }
        public string ServerName { get; set; }
        public uint DateCreated { get; set; }
        public bool DeveoperOnly { get; set; }
        
        public GameServerInfo(byte serverID, string serverName, IPAddress serverAddr, short serverPort, 
            ushort onlineUsers, uint dateCreated, bool developerOnly)
        {

            ServerID = serverID;
            ServerAddr = serverAddr;
            ServerPort = serverPort;
            ServerName = serverName;
            OnlineUsers = onlineUsers;
            DateCreated = dateCreated;
            DeveoperOnly = developerOnly;
        }
    }
}
