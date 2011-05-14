using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TRE.GameService
{
    internal class ClientGamemain
    {
        const int   GAMEMAIN_STATE_UNAUTHED = 0,
                    GAMEMAIN_STATE_CHARACTERSELECTION = 1,
                    GAMEMAIN_STATE_RELIEVED = 3; // instance was passed to an other handler, we have to remove it asap
        
        internal Socket socket;
        internal CriticalSection cs_send;
        internal CriticalSection cs_general;
        internal byte[] RecvBuffer = new byte[8 * 1024];
        internal uint RecvState;
        internal uint RecvSize;

        internal uint sessionId1;
        internal uint sessionId2;
        internal UInt64 userID;

        internal char[] Accountname = new char[20];
        internal TabulaCrypt2 tbc2;

        internal uint state_bytesRecv;
        internal uint state_bytesSend;

        internal int State;
        
        // set by gameMain, used by mapChannel
        internal int mapLoadContextId; // map to load
        internal int mapLoadSlotId; // choosen character
        
        // helpers
        internal pyMarshalString pyms;
        internal pyUnmarshalString pyums;
    
        internal int Run(object p1)
        {
            return 0;
        }

        internal void PassClient(Socket s, TabulaCrypt2 tbc2)
        {
        }

        internal void PassClientToCharacterSelection(ClientGamemain cgm)
        {
        }


        internal ClientGamemain isolate(ClientGamemain cgm)
        {
            return null;
        }

    }
}
