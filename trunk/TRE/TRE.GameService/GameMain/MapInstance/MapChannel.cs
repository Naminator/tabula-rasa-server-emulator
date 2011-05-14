using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{


    internal class MapChannelClient
    {
        internal ulong clientEntityId;
        internal ClientGamemain cgm;
        internal Manifestation player;
        internal MapChannel mapChannel;
        internal CharacterData tempCharacterData; // used while loading
        internal bool logoutActive;
        internal ulong logoutRequestedLast;
        internal bool removeFromMap; // should be removed from the map at end of processing
        internal bool disconnected; // client disconnected (do not pass to other)
        // chat
        internal uint joinedChannels;
        internal uint[] channelHashes = new uint[MapChannel.CHANNEL_LIMIT];
        // inventory data
        internal Inventory inventory;
        // mission data
        internal UIntDictionary mission;
    }

    internal delegate bool mapChannelTimerCallback(MapChannel mapChannel, object param, int timePassed);
    internal struct mapChannelTimer
    {
        internal int period;
        internal int timeLeft;
        internal object param;
        internal mapChannelTimerCallback cb;
    }

    internal class MapChannel
    {
        internal const int  CHANNEL_LIMIT = 14,
                            MAPCHANNEL_PLAYERQUEUE = 32;

        internal MapInfo mapInfo;
        internal List<MapChannelClient> playerList;
        internal int loadState; // temporary variable used for multithreaded but synchronous operations
        internal int playerCount;
        internal int playerLimit;
        internal UIntDictionary socketToClient; // maps socket to client structure

        // ringbuffer for passed players
        internal ClientGamemain[] playerQueue = new ClientGamemain[MAPCHANNEL_PLAYERQUEUE];
        internal int playerQueueReadIndex;
        internal int playerQueueWriteIndex;
        internal object criticalSection;

        // timers
        internal uint timer_clientEffectUpdate;
        internal uint timer_missileUpdate;
        internal uint timer_dynObjUpdate;
        internal uint timer_generalTimer;
        internal uint timer_controller;

        // other timers
        internal UIntDictionary timerList; // Todo: relace this with a list implementation

        // cell data
        internal MapCellInfo mapCellInfo;

        // missile data
        internal MissileInfo missileInfo;

        // dynamic object info ( contains only objects that require regular updates )
        internal UIntDictionary updateObjectList;

        internal void init()
        {
        }

        internal void start(List<int> contextIdList, int contextCount)
        {
        }

        internal MapChannel findByContextId(int contextId)
        {
            return null;
        }

        internal bool pass(MapChannel mapChannel, ClientGamemain cgm)
        {
            return false;
        }

        // timer
        internal void registerTimer(MapChannel mapChannel, int period, object param, mapChannelTimerCallback cb)
        {
        }
    }
}
