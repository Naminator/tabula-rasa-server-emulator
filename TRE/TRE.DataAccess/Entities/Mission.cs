using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.DataAccess.Entities
{
    public struct CharacterMissionData {
	    public int missionId;
        public int missionState;
    }

    public class MissionData
    {
        public int missionId { get; set; }
        public int dispenserNPC { get; set; }
        public int collectorNPC { get; set; }
    }
}
