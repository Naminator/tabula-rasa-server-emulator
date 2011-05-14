using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{
    internal class Npc
    {


        /*
            NPCs are all interactable characters.
	
        */


        const int NPC_TYPE_NONE = 0,
                    NPC_TYPE_VENDOR = 1;

        internal struct metaNpc_vendor
        {
            internal char vendorType;
        }


        internal ulong entityId;		// the generated unique entityId
        //int classId;						// the classId (defined in entityClass.pyo) (is stored inside actor)
        internal Actor actor;						// the base actor object
        internal MissionList missionList;			// available missions
        internal char npcType;						// the npc type (see above)

        internal metaNpc_vendor metaVendor;

        // behavior controller
        internal BehaviorState controller;


        internal void test(MapChannelClient client)
        {
        }

        internal NpcData createNPC(MapChannel mapChannel, int classId, string name)
        {
            return null;
        }

        // set (must not be called after addToWorld, does not take effect on client instantly)
        internal void setLocation(NpcData npc, float x, float y, float z, float rX, float rY)
        {
        }

        internal void setType(NpcData npc, int npcType)
        {
        }

        internal void setMissionList(NpcData npc, MissionList missionList)
        {
        }

        internal void setAppearanceEntry(NpcData npc, int entryIndex, int classId, uint hue)
        {
        }

        // update
        internal void updateConversationStatus(MapChannelClient client, NpcData npc)
        {
        }

        internal void updateAppearanceItem(MapChannel mapChannel, NpcData npc, uint itemClassId, uint hue)
        {
        }

        internal void updateName(MapChannel mapChannel, NpcData npc, string newName)
        {
        }


        internal void recv_RequestNPCConverse(MapChannelClient cm, string pyString, int pyStringLen)
        {
        }
        internal void recv_RequestNPCVending(MapChannelClient client, string pyString, int pyStringLen)
        {
        }

        internal void recv_AssignNPCMission(MapChannelClient client, string pyString, int pyStringLen)
        {
        }


        internal void cellIntroduceNPCToClients(MapChannel mapChannel, NpcData npc, List<MapChannelClient> playerList, int playerCount)
        {
        }

        internal void cellIntroduceNPCsToClient(MapChannel mapChannel, MapChannelClient client, List<NpcData> npcList, int npcCount)
        {
        }

        internal void cellDiscardNPCToClients(MapChannel mapChannel, NpcData npc, List<MapChannelClient> playerList, int playerCount)
        {
        }

        internal void cellDiscardNPCsToClient(MapChannel mapChannel, MapChannelClient client, List<NpcData> npcList, int npcCount)
        {
        }

        internal void initForMapChannel(MapChannel mapChannel)
        {
        }
    }
}
