using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    enum ActorState {
        ALIVE = 0,
        DEAD = 1
    }

    struct  ActorAppearanceData
    {
	    public int classId;
        public int hue;
    }

    struct ActorStats
    {
        public int level;
        public int healthCurrent;
        public int healthMax;
        public int healthBonus;
    }

    class Actor
    {
        int entityId;
	    int entityClassId;
	    string name;
	    ActorStats stats;
	    ActorAppearanceData[] appearanceData; // should move this to manifestation and npc structure? (Because not used by monsters)
	    float posX;
	    float posY;
	    float posZ;
	    float rotation;
	    bool isRunning;
	    MapCellLocation cellLocation;
	    GameEffect activeEffects;
	    string state;
    }
}
