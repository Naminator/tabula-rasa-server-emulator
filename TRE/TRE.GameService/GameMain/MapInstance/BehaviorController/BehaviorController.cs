using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{
    internal struct BehaviorState
    {
        internal int currentAction;
        internal int faction; // 'team'
        // combat info
        internal long targetEntityId;
    }
    
    /// <summary>
    /// Behavior controller
    /// responsible for:
    /// 	npc and creature movement, decisions, combat or any actions.
    /// </summary>
    internal class BehaviorController
    {
        const int BEHAVIOR_ACTION_IDLE = 0,
             BEHAVIOR_ACTION_FOLLOWINGPATH = 1,
             BEHAVIOR_ACTION_FIGHTING = 2;

        internal void initForMapChannel(MapChannel mapChannel) {
        
        }

        /*
         * Called every 250 milliseconds
         */
        internal void mapChannelThink(MapChannel mapChannel) { 
        
        }

        /// <summary>
        /// Called every 250 milliseconds for every NPC on the map
        /// </summary>
        void npcThink(MapChannel mapChannel, NpcData npc)
        {
        }

        /// <summary>
        /// Called every 250 milliseconds for every creature on the map
        /// </summary>
        void creatureThink(MapChannel mapChannel, Creature creature)
        {
        }

    }
}
