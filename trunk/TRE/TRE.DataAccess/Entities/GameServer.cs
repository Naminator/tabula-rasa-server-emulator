using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;

namespace TRE.DataAccess.Entities
{
    //public class GameServer
    //{
        
    //}

    [DataContract(Name="game_servers")]
    public class GameServerInfo
    {

        [DataMember(Name = "server_id", Order = 0, IsRequired = false)]
        public byte ServerID { get; set; }
       
    }
}
