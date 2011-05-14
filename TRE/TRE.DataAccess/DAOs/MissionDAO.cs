using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Common;
using TRE.DataAccess.Entities;
using IBatisNet.DataMapper;

namespace TRE.DataAccess.DAOs
{
    public class MissionDAO
    {
        public static IList<MissionData> getMissionList()
        {
            ISqlMapper mapper = Mapper.Instance();
            return mapper.QueryForList<MissionData>("getMissionList", null);
        }
        
    }
}
