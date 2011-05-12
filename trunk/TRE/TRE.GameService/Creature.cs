using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    class Creature
    {
        struct CreatureType
        {
            // actor info
            int nameId; // note that it is also possible to overwrite the name with actor Recv_SetName
            int entityClassId;
            // stats info
            int maxHealth;
        }

        static List<CreatureType> CreatureTypes;

        CreatureType type;		// the creature 'layout'
        Actor actor;		// the base actor object
        // stats
        int currentHealth;
        // origin
        SpawnPool spawnPool; // the spawnpool that initiated the creation of this creature
        // behavior controller
        BehaviorState controller;

        void static Init()
        {
            CreatureTypes = new List<CreatureType>();

            // REgister creature types
        }
    }
}
