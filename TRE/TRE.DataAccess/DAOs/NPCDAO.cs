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
        //public static IList<NPC> getNPCList(long mapContextId) {
        //    ISqlMapper mapper = Mapper.Instance();
        //    return mapper.QueryForList<NPC>("getNPCList", mapContextId);
        //}

        public static int getLastNPCEntityId()
        {
            ISqlMapper mapper = Mapper.Instance();
            return (int) mapper.QueryForMap("getLastNPCEntityId",null, "mapContextId")["mapContextId"];
        }
    }
}
