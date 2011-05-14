using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TRE.GameService
{
    internal class Communicator
    {
        #region Static
        static Object criticalSection = null;
        static Communicator Instance = null;
        Communicator() { }
        internal static Communicator GetInstance()
        {
            if (Instance == null) Instance = new Communicator();

            return Instance;
        }
        #endregion

        static Hashtable playersByName;
        static Hashtable channelsBySeed;
        static Hashtable playersByEntityId;

        internal static void Init()
        {
            Communicator.criticalSection = new Object();

            const int MAX_PLAYERS = 2048;
            const int MAX_CHANNELS = 16;
            const int MAX_UNKNOWN = 16;

            playersByName = new Hashtable(MAX_PLAYERS);
            channelsBySeed = new Hashtable(MAX_CHANNELS);
            playersByEntityId = new Hashtable(MAX_UNKNOWN);

            
        }


    }
}
