using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{
    public class MissionCondition
    {
        public int conditionCode;
        public int conditionValue;
        public MissionCondition next; // if there is more than one condition
    } // the condition(s) that must be true so the quest can be accepted

    public struct MissionObjective
    {
        public int temp;
        //int conditionCode;
        //int conditionValue;
        //struct _missionCondition_t *next; // if there is more than one condition
    } // the objective(s) that must be true so the quest can be completed

    public class MissionList : List<Mission> { }// a list of missions related to a single NPC
    public class Mission
    {
        const short MISSION_STATE_MASK = 0xF;
        const int MISSION_STATE_NOTACCEPTED = 0,
                    MISSION_STATE_ACTIVE = 1,	// mission running, still have to do objectives
                    MISSION_STATE_DONE = 2,	// mission objectives done, must talk to NPC
                    MISSION_STATE_COMPLETED = 3;	// mission completed, no more in mission log

        public int missionId;
        public ulong npcDispenserEntityId; // the NPC that offers the mission
        public ulong npcCollectorEntityId; // the NPC that the mission can be completed at
        public MissionCondition firstCondition; // NULL if no conditions, else points to the first condition
        public int objectiveCount;
        public MissionObjective objectiveList;

        internal void init()
        {
        }

        internal void initForClient(MapChannelClient client)
        {
        }

        internal void initForChannel(MapChannel mapChannel)
        {
        }

        internal MissionList generateMissionListForNPC(NpcData npc)
        {
            return null;
        }


        internal bool completeableAvailableForClient(MissionList missionList, MapChannelClient client, NpcData npc, MissionList outMissionList, int outLimit)
        {
            return false;
        }

        internal bool newAvailableForClient(MissionList missionList, MapChannelClient client, NpcData npc, MissionList outMissionList, int outLimit)
        {
            return false;
        }

        internal void acceptForClient(MapChannelClient client, Mission mission)
        {

        }
    }
}
