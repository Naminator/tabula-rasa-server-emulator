using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TRE.DataAccess.Entities
{
    //public class GameServer
    //{
        
    //}

    public class GameServerInfo
    {
        public byte ServerID { get; set; }
        public IPAddress ServerAddr { get; set; }
        public short ServerPort { get; set; }
        public short OnlineUsers { get; set; }
        public string ServerName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool DeveloperOnly;
    }
}
