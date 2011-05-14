using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TRE.DataAccess.Entities;

namespace TRE.GameService
{
    internal class Inventory
    {
        
        internal const int INVENTORY_SLOTOFFSET_PLAYER	=	0,
            INVENTORY_SLOTOFFSET_WEAPONDRAWER =	250,
            INVENTORY_PERSONAL			=	1,
            INVENTORY_HOMEINVENTORY	=		2, // (lockbox)
            INVENTORY_HIDDENINVENTORY	=	3,
            INVENTORY_TRADEINVENTORY	=	4,
            INVENTORY_PLAYERVENDORINVENTORY	=5,
            INVENTORY_GAMECONTEXTINVENTORY	=6,
            INVENTORY_OVERFLOWINVENTORY	=	7,
            INVENTORY_EQUIPPEDINVENTORY	=	8,
            INVENTORY_WEAPONDRAWERINVENTORY=	9,
            INVENTORY_BUYBACKINVENTORY	=	10,
            INVENTORY_AUCTIONINVENTORY	=	11,
            INVENTORY_INBOXINVENTORY	=	12,
            INVENTORY_OUTBOXINVENTORY	=	13,
            INVENTORY_WAGERINVENTORY	=	14,
            INVENTORY_CLANINVENTORY	=		15;


		internal UInt64[] homeInventory = new UInt64[50*5]; // 250 slots
		internal UInt64[] weaponDrawer = new UInt64[5];

		internal UInt64[] slot = new UInt64[250+5];
		internal char activeWeaponDrawer;

        void initForClient(MapChannelClient client)
        {

        }

        void notifyEquipmentUpdate(MapChannelClient client)
        {

        }

        // subclass for inventory item
        internal class Item  
        {
	        internal ulong entityId;
	        //unsigned int entityClassId;
	        //unsigned int itemTemplateId;
	        // location info
	        internal ulong locationEntityId;
	        internal int locationSlotIndex;
	        // template
	        internal ItemTemplate itemTemplate;

            internal void recv_RequestTooltipForItemTemplateId(MapChannelClient cm, string pyString, int pyStringLen)
            {
            }

            internal void recv_PersonalInventoryMoveItem(MapChannelClient cm, string pyString, int pyStringLen)
            {
            }

            internal void recv_RequestEquipWeapon(MapChannelClient client, string pyString, int pyStringLen)
            {
            }

            internal void recv_RequestWeaponDraw(MapChannelClient client, string pyString, int pyStringLen)
            {
            }

            internal void recv_RequestWeaponStow(MapChannelClient client, string pyString, int pyStringLen)
            {
            }

            internal void recv_RequestWeaponReload(MapChannelClient client, string pyString, int pyStringLen)
            {
            }


        }

    }
}
