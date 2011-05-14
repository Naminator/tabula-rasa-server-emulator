using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace TRE.DataAccess.Entities
{
    [DataContract]
    public class NpcData : CharacterDataBase
    {
        public int mapContextId { get; set; }
        public long entityClassID { get; set; }
    }
}
