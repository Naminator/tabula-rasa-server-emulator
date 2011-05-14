using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class NetMgr
    {

        internal struct NetCompressedMovement
        {
            internal ulong entityId;
            internal uint posX24b;
            internal uint posY24b;
            internal uint posZ24b;
            internal ushort velocity;
            internal char flag; // or string ?
            internal ushort viewX;
            internal ushort viewY;
        }

        internal void pythonAddMethodCallRaw(ClientGamemain cgm, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        internal void pythonAddMethodCallRaw(MapChannel broadCastChannel, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        internal void testOpc(ClientGamemain cgm)
        {
        }

        internal void entityMovementTest(ClientGamemain cgm, string pyObjString)
        {
        }

        internal void pythonAddMethodCallRaw(List<MapChannelClient> clientList, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        /*
         * CELL DOMAIN
         */

        internal void cellDomain_pythonAddMethodCallRaw(MapChannelClient aggregator, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        internal void cellDomain_pythonAddMethodCallRaw(MapChannel mapChannel, Actor aggregator, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        internal void cellDomain_pythonAddMethodCallRawIgnoreSelf(MapChannelClient aggregator, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        internal void cellDomain_pythonAddMethodCallRaw(MapChannel mapChannel, DynObject aggregator, uint EntityID, uint MethodID, string pyObjString)
        {
        }

        internal void cellDomain_sendEntityMovement(MapChannelClient aggregator, NetCompressedMovement movement, bool skipOwner)
        {

        }

        internal void cellDomain_sendEntityMovement(MapChannel mapChannel, Actor aggregator, NetCompressedMovement movement)
        {

        }

        internal void cellDomain_sendEntityMovement(ClientGamemain cgm, NetCompressedMovement movement)
        {

        }

    }
}
