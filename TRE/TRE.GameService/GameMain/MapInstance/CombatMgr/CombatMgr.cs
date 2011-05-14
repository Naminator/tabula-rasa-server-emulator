using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class Missile
    {
        internal int type;
        internal int damageA;
        internal int damageB;
        ulong targetEntityId; // the entityId of the destination (it is possible that the object does no more exist on arrival)
        int triggerTime; // amount of milliseconds left before the missile is triggered, is decreased on every tick
        Missile previous, next;
    }

    /*
     *	Missiles are, of course, map bound.
     *	So the structure below is included in the mapchannel
     */
    struct MissileInfo
    {
        Missile firstMissile;
    }

    internal class CombatMgr
    {
        const int MISSILE_PISTOL = 1;

        internal void missile_initForMapchannel(MapChannel mapChannel)
        {
        }

        internal void missile_check(MapChannel mapChannel, int passedTime)
        {
        }

        internal void missile_launch(MapChannel mapChannel, Actor origin, ulong targetEntityId, int type, int damage)
        {
        }

    }
}
