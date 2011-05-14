using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{


    internal class MapCell
    {
        internal int cellX;
        internal int cellZ;
        internal UIntDictionary playerList;       // players currently in this cell
        internal UIntDictionary playerNotifyList; // players that currently see this cell and should be informed about updates
        internal UIntDictionary objectList;       // dynamic gameobjects that are in the cell
        internal UIntDictionary npcList;          // dynamic npcs that are in the cell
        internal UIntDictionary creatureList;     // dynamic creatures that are in the cell
    }

    internal struct MapCellLocation
    {
        internal int x;
        internal int z;
    }

    internal struct MapCellInfo
    {
        internal UIntDictionary cells;
        internal int loadedCellCount;
        internal int loadedCellLimit;
        internal List<MapCell> loadedCellList;
        internal uint time_updateVisibility;
    }

    internal class CellMgr
    {
        const float CELL_SIZE = 25.0f, //32.0f
                    CELL_BIAS = 32768.0f;
        const int CELL_VIEWRANGE = 2; // 2 cells in evers direction

        internal bool initForMapChannel(MapChannel mapChannel)
        {
            return false;
        }

        // add/remove client from the world
        internal void addToWorld(MapChannelClient client)
        {
        }

        internal void removeFromWorld(MapChannelClient client)
        {
        }

        // add/remove object from the world
        internal void addToWorld(MapChannel mapChannel, DynObject dynObject)
        {
        }

        internal void removeFromWorld(MapChannel mapChannel, DynObject dynObject)
        {
        }

        // add/remove npc from the world
        internal void addToWorld(MapChannel mapChannel, NpcData npc)
        {
        }

        // add/remove creature from the world
        internal void addToWorld(MapChannel mapChannel, Creature creature)
        {
        }

        // misc
        internal NpcData findNPCinViewOf(MapChannelClient aggregator, ulong npcEntityId)
        {
            return null;
        }

        internal MapCell tryGetCell(MapChannel mapChannel, int x, int z)
        {
            return null;
        }

        internal List<MapChannelClient> getNotifiedPlayers(MapChannelClient aggregator, int oCount)
        {
            return null;
        }

        internal List<MapChannelClient> getNotifiedPlayers(MapChannel mapChannel, Actor aggregator, int oCount)
        {
            return null;
        }

        internal List<MapChannelClient> getNotifiedPlayers(MapChannel mapChannel, DynObject aggregator, int oCount)
        {
            return null;
        }

        internal void doWork(MapChannel mapChannel)
        {
        }
    }
}
