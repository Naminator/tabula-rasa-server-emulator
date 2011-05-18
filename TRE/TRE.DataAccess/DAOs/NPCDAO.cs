using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Common;
using TRE.DataAccess.Entities;
using IBatisNet.DataMapper;

namespace TRE.DataAccess.DAOs
{
    public class NPCDAO
    {
        public static IList<NpcData> getNPCList(long mapContextId)
        {
            ISqlMapper mapper = Mapper.Instance();
            return mapper.QueryForList<NpcData>("getNPCList", mapContextId);
        }

        public static ulong getLastNPCEntityId()
        {
            ISqlMapper mapper = Mapper.Instance();
            return (ulong)mapper.QueryForMap("getLastNPCEntityId", null, "mapContextId")["mapContextId"];
        }

        public static void updateNpc(NpcData npc)
        {
            //ISqlMapper mapper = Mapper.Instance();
            //mapper.Insert("InsertCharacter", npc);
        }
    }
}
