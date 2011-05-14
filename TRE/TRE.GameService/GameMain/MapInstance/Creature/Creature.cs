using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class CreatureType
    {
        // actor info
        int nameId; // note that it is also possible to overwrite the name with actor Recv_SetName
        int entityClassId;
        // stats info
        int maxHealth;

        internal CreatureType createCreatureType(int entityClassId, int nameId)
        {
            return null;
        }

        internal void registerCreatureType(CreatureType creatureType, string name)
        {
        }

        internal void setMaxHealth(CreatureType creatureType, int maxHealth)
        {
        }

        internal CreatureType findType(string typeName)
        {
            return null;
        }
    }

    internal class Creature
    {

        List<CreatureType> CreatureTypes;

        internal CreatureType type;		// the creature 'layout'
        internal Actor actor;		// the base actor object
        // stats
        internal int currentHealth;
        // origin
        internal SpawnPool spawnPool; // the spawnpool that initiated the creation of this creature
        // behavior controller
        internal BehaviorState controller;


        internal Creature createCreature(MapChannel mapChannel, string typeName, SpawnPool spawnPool)
        {
            return null;
        }

        internal Creature createCreature(MapChannel mapChannel, CreatureType creatureType, SpawnPool spawnPool)
        {
            return null;
        }

        internal void setLocation(Creature creature, float x, float y, float z, float rX, float rY)
        {

        }


        // cellMgr related
        internal void cellIntroduceCreatureToClients(MapChannel mapChannel, Creature creature, MapChannelClient playerList, int playerCount)
        {
        }

        internal void cellIntroduceCreaturesToClient(MapChannel mapChannel, MapChannelClient client, Creature creatureList, int creatureCount)
        {
        }

        internal void cellDiscardCreatureToClients(MapChannel mapChannel, Creature creature, MapChannelClient playerList, int playerCount)
        {
        }

        internal void cellDiscardCreaturesToClient(MapChannel mapChannel, MapChannelClient client, Creature creatureList, int creatureCount)
        {
        }

        // global init
        internal void creature_init()
        {
        }
    }
}
