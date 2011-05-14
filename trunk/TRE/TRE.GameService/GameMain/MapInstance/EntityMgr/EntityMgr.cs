using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    public class EntityMgr
    {
        #region Static
        static Object criticalSection = null;
        static EntityMgr Instance = null;
        EntityMgr() { }
        internal static EntityMgr GetInstance() {
            if (Instance == null) Instance = new EntityMgr();

            return Instance;
        }
        #endregion

        static Hashtable entityTable;

        int ceid_player = 0;
        int ceid_client = 0;
        int ceid_object = 0;
        int ceid_item = 0;
        int ceid_npc = 0;
        int ceid_creature = 0;
        
        internal static void Init() {
            const int ENTITYID_BASE = 4096; //0x1000;

            EntityMgr.criticalSection = new Object();
            entityTable = new Hashtable();

            int npceid = TRE.DataAccess.DAOs.NPCDAO.getLastNPCEntityId();
            // ceid_npc
            npceid = (npceid - ENTITYID_BASE) / 16;
            npceid++;
            //npceid += 16;
            //npceid &= ~0xF;
            //npceid += ENTITYTYPE_NPC;
            Instance.ceid_npc = npceid;
        }
    }
}
