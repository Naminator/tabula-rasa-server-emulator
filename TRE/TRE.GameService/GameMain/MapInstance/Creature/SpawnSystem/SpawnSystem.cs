using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal struct SpawnLocation
    {
        internal float x;
        internal float y;
        internal float z;
        internal ushort creatureTypeFilter; // a mask that enables the specific creatures defined by the spawn pool
        // used during runtime
        internal uint lastSpawnTime;
    }

    internal class SpawnPool
    {
        internal CreatureType[] spawnTypes = new CreatureType[16];  // 16 different creature types available at max, NULL if not set
        internal int[] spawnCountBase = new int[16];	    // (16) minimum creatures to spawn at once
        internal int[] spawnCountRandom = new int[16];   // (16) additional random factor of creatures to spawn
        internal int spawnVariantCount;    // 0 - 16

        // different spawn points
        internal int locationCount;
        internal SpawnLocation locationList;

        // spawn settings
        internal int maxCreatures;           // use depends on criteria
        internal int maxQueueLength;         // maximal number of delivering dropships
        internal int spawnLocationLockTime;  // number of milliseconds that have to pass until a location can be used again for spawning
        internal char criteria;

        // spawn runtime info
        internal int dropshipQueue;          // number of dropships that are currently delivering units
        internal int queuedCreatures;        // number of creatures that are spawning right now (i.e. delivered via dropship)
        internal int aliveCreatures;         // number of spawned creatures that are alive
        internal int deadCreatures;          // number of spawned creatures that are dead (either killed or spawned dead)

        // default action assignment
        // nothing here until 

        const int   SPAWN_CRITERIA_CELLCREATURECOUNT = 1,	// amount of living creatures in the same cell as the spawnLocation
                    SPAWN_CRITERIA_SPAWNPOOLCREATURECOUNT = 2,	// todo
                    SPAWN_CRITERIA_BOSSSPAWNER = 3;	// todo


        internal void initForMapChannel(MapChannel mapChannel)
        {

        }

        internal SpawnPool create()
        {
            return null;
        }

        internal void setCriteriaCellCreatureCount(SpawnPool spawnPool, int maxCount)
        {
        }

        internal bool setCreatureVariant(SpawnPool spawnPool, int index, string creatureTypeName)
        {
            return false;
        }

        internal void initSpawnLocations(SpawnPool spawnPool, int number)
        {
        }

        internal void setSpawnLocation(SpawnPool spawnPool, int index, float x, float y, float z, ushort typeMask)
        {
        }

        // count dropships
        internal void increaseQueueCount(MapChannel mapChannel, SpawnPool spawnPool)
        {
        }

        internal void decreaseQueueCount(MapChannel mapChannel, SpawnPool spawnPool)
        {
        }

        // count creatures
        internal void increaseQueuedCreatureCount(MapChannel mapChannel, SpawnPool spawnPool, int count)
        {
        }

        internal void increaseAliveCreatureCount(MapChannel mapChannel, SpawnPool spawnPool)
        {
        }

        internal void increaseDeadCreatureCount(MapChannel mapChannel, SpawnPool spawnPool)
        {
        }

        internal void decreaseQueuedCreatureCount(MapChannel mapChannel, SpawnPool spawnPool, int count)
        {
        }

        internal void decreaseAliveCreatureCount(MapChannel mapChannel, SpawnPool spawnPool)
        {
        }

        internal void decreaseDeadCreatureCount(MapChannel mapChannel, SpawnPool spawnPool)
        {
        }

    }
}
