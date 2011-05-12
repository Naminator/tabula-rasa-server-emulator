using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    struct MapCell
    {
        public int cellX;
        public int cellZ;
        public List<int> playerList;       // players currently in this cell
        public List<int> playerNotifyList; // players that currently see this cell and should be informed about updates
        public List<int> objectList;       // dynamic gameobjects that are in the cell
        public List<int> npcList;          // dynamic npcs that are in the cell
        public List<int> creatureList;     // dynamic creatures that are in the cell
    }

    struct MapCellLocation
    {
        public int x;
        public int z;
    }

    struct  MapCellInfo
    {
	    public List<int> cells;
	    public int loadedCellCount;
	    public int loadedCellLimit;
	    public MapCell loadedCellList;
	    public int time_updateVisibility;
    }

    class CellMgr
    {
        bool initForMapChannel(MapChannel mapChannel);
    }
}
