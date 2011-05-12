using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.DataAccess.Entities
{
    struct CharacterMissionData {
	    public int missionId;
        public int missionState;
    }

    class Mission
    {
        public int missionId { get; set; }
        public int dispenserNPC { get; set; }
        public int collectorNPC { get; set; }
    }
}
