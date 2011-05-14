using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal enum ActorState {
        ALIVE = 0,
        DEAD = 1
    }

    internal struct  ActorAppearanceData
    {
        internal int classId;
        internal int hue;
    }

    internal struct ActorStats
    {
        internal int level;
        internal int healthCurrent;
        internal int healthMax;
        internal int healthBonus;
    }

    internal class Actor
    {
        internal int entityId;
        internal int entityClassId;
        internal string name; // 64 max
        internal ActorStats stats;
        internal ActorAppearanceData[] appearanceData; // should move this to manifestation and npc structure? (Because not used by monsters)
        internal float posX;
        internal float posY;
        internal float posZ;
        internal float rotation;
        internal bool isRunning;
        internal MapCellLocation cellLocation;
        internal GameEffect activeEffects;
        internal ActorState state;
    }
}
