using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class Msg
    {
        internal void beginCharacterSelection(ClientGamemain cgm)
        {
        }

        internal void createSelectionPodEntitys(ClientGamemain cgm)
        {
        }

        internal void sendCharacterInfo(ClientGamemain cgm)
        {
        }

        internal void initCharacterSelection(ClientGamemain cgm)
        {
        }

        internal void updateCharacterSelection(ClientGamemain cgm)
        {
        }


        // recv
        internal int recv_requestCharacterName(ClientGamemain cgm, string pyString, int pyStringLen)
        {
            return 0;
        }

        internal int recv_requestCreateCharacterInSlot(ClientGamemain cgm, string pyString, int pyStringLen)
        {
            return 0;
        }

        internal int recv_requestDeleteCharacterInSlot(ClientGamemain cgm, string pyString, int pyStringLen)
        {
            return 0;
        }

        internal int recv_requestSwitchToCharacterInSlot(ClientGamemain cgm, string pyString, int pyStringLen)
        {
            return 0;
        }
    }
}
