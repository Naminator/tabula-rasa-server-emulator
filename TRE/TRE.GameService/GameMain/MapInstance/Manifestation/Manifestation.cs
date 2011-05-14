using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{
    internal class Manifestation
    {

        internal Actor actor;
        //long long controllerUserId;
        internal MapChannelClient controllerUser;
        internal int raceId;
        internal int classId;
        internal int level;
        internal bool genderIsMale;
        internal ulong targetEntityId;

        internal void createPlayerCharacter(MapChannel mapChannel, MapChannelClient owner, CharacterData characterData)
        {
        }

        internal void removePlayerCharacter(MapChannel mapChannel, MapChannelClient owner)
        {
        }

        internal void setAppearanceItem(Manifestation manifestation, int itemClassId, uint hueAARRGGBB)
        {
        }

        internal void updateAppearance(MapChannelClient owner)
        {
        }

        internal void updateWeaponReadyState(MapChannelClient client)
        {
        }

        internal void recv_SetTargetId(MapChannelClient cm, string pyString, int pyStringLen)
        {
        }

        internal void recv_ClearTargetId(MapChannelClient cm, string pyString, int pyStringLen)
        {
        }

        internal void recv_ToggleRun(MapChannelClient cm, string pyString, int pyStringLen)
        {
        }

        internal void recv_RequestSetAbilitySlot(MapChannelClient cm, string pyString, int pyStringLen)
        {
        }

        internal void recv_RequestPerformAbility(MapChannelClient cm, string pyString, int pyStringLen)
        {
        }

        internal void recv_StartAutoFire(MapChannelClient client, string pyString, int pyStringLen)
        {
        }

        internal void recv_StopAutoFire(MapChannelClient client, string pyString, int pyStringLen)
        {
        }

        internal void recv_AutoFireKeepAlive(MapChannelClient client, string pyString, int pyStringLen)
        {
        }

        // cell mgr specific
        internal void cellIntroducePlayersToClient(MapChannel mapChannel, MapChannelClient client, List<MapChannelClient> playerList, int playerCount)
        {
        }

        internal void cellIntroduceClientToPlayers(MapChannel mapChannel, MapChannelClient client, List<MapChannelClient> playerList, int playerCount)
        {
        }

        internal void cellDiscardClientToPlayers(MapChannel mapChannel, MapChannelClient client, List<MapChannelClient> playerList, int playerCount)
        {
        }

        internal void cellDiscardPlayersToClient(MapChannel mapChannel, MapChannelClient client, List<MapChannelClient> playerList, int playerCount)
        {
        }
    }
}
