using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class BaneDropship
    {
        internal int phaseTimeleft;
        internal char phase;
        internal SpawnPool spawnPool; // spawnPool the dropship belongs to
        internal char spawnCount;
        internal CreatureType[] spawnTypeList = new CreatureType[24]; // maximal 24 creatures can be spawned at once
    }

    internal class DynObject
    {
        internal void init(MapChannel mapChannel)
        {
        }

        internal void recv_RequestUseObject(MapChannelClient client, string pyString)
        {
        }

        internal ulong entityId;
        internal ushort objectType;
        internal ulong entityClassId;
        internal object objectData;
        // universal position data
        internal float x;
        internal float y;
        internal float z;
        internal float rotX;
        internal float rotY;
        internal float rotZ;
        //float velocity;
        //float viewX;
        //float viewY;
        // useable data
        internal int stateId;
        // todo: rotation quarterninion
        internal MapCellLocation cellLocation;


        //typedef struct
        //{
        //    int period;
        //    int timeLeft;
        //    dynObject_t *object;
        //    unsigned long long entityId;
        //}dynObject_workEntry_t; 

        internal void dynamicObject_cellIntroduceObjectToClients(MapChannel mapChannel, DynObject dynObj, List<MapChannelClient> playerList, int playerCount)
        {

        }

        internal void dynamicObject_cellIntroduceObjectsToClient(MapChannel mapChannel, MapChannelClient client, List<DynObject> objectList, int objectCount)
        {
        }

        internal void dynamicObject_cellDiscardObjectToClients(MapChannel mapChannel, DynObject dynObj, List<MapChannelClient> playerList, int playerCount)
        {
        }

        internal void dynamicObject_cellDiscardObjectsToClient(MapChannel mapChannel, MapChannelClient client, List<DynObject> objectList, int objectCount)
        {
        }

        internal void dynamicObject_check(MapChannel mapChannel, int timePassed)
        {
        }

        internal bool dynamicObject_process(MapChannel mapChannel, DynObject dynObject, int timePassed)
        {
            return false;
        }


        // developer / testing
        internal void dynamicObject_developer_createFootlocker(MapChannel mapChannel, float x, float y, float z)
        {
        }

        internal void dynamicObject_developer_createCustom(MapChannel mapChannel, int classId, float x, float y, float z)
        {
        }

        internal void dynamicObject_createBaneDropship(MapChannel mapChannel, float x, float y, float z, int spawnCount, List<CreatureType> spawnTypeList, SpawnPool spawnPool)
        {
        }

        internal void dynamicObject_createBaneDropship(MapChannel mapChannel, float x, float y, float z, int spawnCount, List<CreatureType> spawnTypeList)
        {
        }

        internal void dynamicObject_destroy(MapChannel mapChannel, DynObject dynObject)
        {
        }
    }
}
