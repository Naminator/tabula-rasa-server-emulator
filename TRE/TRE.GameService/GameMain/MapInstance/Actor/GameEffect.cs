using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class GameEffect
    {
        const int EFFECTID_SPRINT = 247;

        internal int effectId;
        internal int effectLevel;
        internal int aliveTime;
        internal int time;

        /// <summary>
        /// Attaches a GameEffect (buffs, etc.) to a actor entity.
        /// </summary>
        internal void attach(MapChannel mapChannel, Actor actor, int effectId, int effectLevel)
        {
        }

        internal void dettach(MapChannel mapChannel, Actor actor, GameEffect gameEffect)
        {
        }

        /// <summary>
        /// Periodically called for all clients in a mapContext
        /// Updates and applys effects of abilities or items
        /// </summary>
        internal void checkForPlayers(List<MapChannelClient> clients, int count, int passedTime)
        {
        }

        /// <summary>
        /// update the walk/runspeed of the actor
        /// </summary>
        private void updateMovementMod(MapChannel mapChannel, Actor actor) {

        }

    }
}
