using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    struct MapChannelClient
    {
	    long clientEntityId;
	    ClientGamemain cgm;
	    Manifestation player;
	    MapChannel mapChannel;
	    CharacterData tempCharacterData; // used while loading
	    bool logoutActive;
	    long logoutRequestedLast;
	    bool removeFromMap; // should be removed from the map at end of processing
	    bool disconnected; // client disconnected (do not pass to other)
	    // chat
	    int joinedChannels;
	    int channelHashes[CHANNEL_LIMIT];
	    // inventory data
	    Inventory inventory;
	    // mission data
	    List<int> mission;
    }

    class MapChannel
    {
        const int CHANNEL_LIMIT = 14;


    }
}
