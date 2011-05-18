using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    public enum EntityType
    {
        Player = 0,
        Client = 1,
        Item = 2,
        Object = 3,
        Npc = 4,
        Creature = 5
    }

    public class EntityMgr
    {
        #region Singleton pattern
        static EntityMgr instance = null;
        public static EntityMgr Instance { get { if (instance == null) instance = new EntityMgr(); return instance; } }
        private EntityMgr() { }
        #endregion

        CriticalSection csEntityMgr = new CriticalSection();
        UIntDictionary entityTable;
        const int ENTITYID_BASE = 4096; //0x1000;

        uint ceid_player = 0;
        uint ceid_client = 0;
        uint ceid_object = 0;
        uint ceid_item = 0;
        uint ceid_npc = 0;
        uint ceid_creature = 0;

        internal void init()
        {
            entityTable = new UIntDictionary();
            // get current npc
	        uint npceid = (uint) TRE.DataAccess.DAOs.NPCDAO.getLastNPCEntityId();

	        if( npceid < ENTITYID_BASE )
		        npceid = ENTITYID_BASE;
	        // ceid_npc
	        npceid = (npceid - ENTITYID_BASE) / 16;
	        npceid++;
	        //npceid += 16;
	        //npceid &= ~0xF;
	        //npceid += ENTITYTYPE_NPC;
	        ceid_npc = npceid;
        }

        internal uint getFreeEntityIdForClient()
        {
            return 0;
        }

        internal uint getFreeEntityIdForPlayer()
        {
            return 0;
        }

        internal uint getFreeEntityIdForItem()
        {
            return 0;
        }

        internal uint getFreeEntityIdForObject()
        {
            return 0;
        }

        internal uint getFreeEntityIdForNPC()
        {
            return 0;
        }

        internal uint getFreeEntityIdForCreature()
        {
            lock (csEntityMgr)
            {
                uint eid = ENTITYID_BASE + ceid_creature*16 + (uint) EntityType.Creature;
                return eid;
            }
        }

        internal EntityType entityMgr_getEntityType(uint entityId)
        {
            return (EntityType) (entityId & 0xF);
        }

        internal void registerEntity(uint entityId, object entity)
        {
            lock (csEntityMgr)
            {
                if (entityTable.ContainsKey(entityId))
                {
                    entityTable[entityId] = entity;
                }
                else
                {
                    entityTable.Add(entityId, entity);
                }
            }
        }

        internal void unregisterEntity(uint entityId)
        {
            lock (csEntityMgr)
            {
                if (entityTable.ContainsKey(entityId))
                {
                    entityTable[entityId] = null;
                }
                //else
                //{
                //    entityTable.Add(entityId, null);
                //}
            }
        }

        internal object get(uint entityId)
        {
            lock (csEntityMgr)
            {
                return entityTable[entityId];
            }
        }
    }
}
