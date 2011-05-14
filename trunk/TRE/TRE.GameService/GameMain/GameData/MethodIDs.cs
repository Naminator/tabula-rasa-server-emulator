using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRE.GameService
{
    internal class MethodIDs
    {
        internal const int 
            CREATE_PYHSICAL_ENTITY = 49

            , ANNOUNCE_HEALING = 620

            , INVENTORY_CREATE = 86
            , INVENTORY_ADD_ITEM = 85
            , INVENTORY_DESTROY = 87
            , INVENTORY_DISABLED = 291
            , INVENTORY_MOVE_FAILED = 464
            , INVENTORY_MOVE_ITEM_FAILED = 465
            , INVENTORY_REMOVE_ITEM = 88
            , INVENTORY_TRANSFER = 89

            , HOME_INVENTORY_CLOSE = 79
            , HOME_INVENTORY_DESTROY_ITEM = 80
            , HOME_INVENTORY_MOVE_ITEM = 81
            , HOME_INVENTORY_OPEN = 82

            , PERSONAL_INVENTORY_DESTROY_ITEM = 127
            , PERSONAL_INVENTORY_MOVE_ITEM = 498
            , PERSONAL_INVENTORY_MOVE_ITEMS = 128
            , PERSONAL_INVENTORY_SPLIT_ITEM = 499

            , EQUIPMENTINFO = 66

            //GAME REQUESTS
            , REQUEST_TOOL_ACTION = 524
            , REQUEST_SWAP_ABILITY_SLOTS = 601
            , REQUEST_SWAP_ABILITY_SLOT = 522
            , REQUEST_SAVE_POSITION_INFO = 162
            , REQUEST_REVIVE = 763
            , REQUEST_REQUEST_CORPSE_LOOTING = 650
            , REQUEST_EQUIP = 1
            , REQUEST_EQUIP_ARMOR = 514
            , REQUEST_EQUIP_WEAPON = 515
            , REQUEST_FAMILYNAME = 516
            , REQUEST_LOGOUT = 820
            , REQUEST_LOOT_ALL_FROM_CORPSE = 651
            , REQUEST_LOOT_ITEM_FROM_CORPSE = 652
            , REQUEST_MAPINSTANCE_LIST = 157
            , REQUEST_MOVE_ITEM_TO_HOME_INVENTORY = 582
            , REQUEST_NPC_VENDING = 519
            , REQUEST_NPC_VENDOR_PURCHASE = 158
            , REQUEST_NPC_VENDOR_SALE = 159
            , REQUEST_PERFORM_ABILITY = 33
            , REQUEST_PERFORM_CHARGED_ABILITY = 520
            , REQUEST_PLACE_OBJECT = 344
            , REQUEST_PLAYER_VENDOR_ITEMS_BY_CATEGORY = 345
            , REQUEST_PURCHASE_PLAYER_VENDOR_ITEM = 346
            , REQUEST_REPAIR = 348
            , REQUEST_RETURN_ITEM_TO_INVENTORY = 349
            , REQUEST_REVERSE_ENGINEER = 668
            , REQUEST_SAVE_CURRENT_CHARACTER_TO_POSITION = 161
            , REQUEST_TOOLTIP_FOR_ITEM_TEMPLATEID = 578
            , REQUEST_TOOLTIP_FOR_ITEM_CLASSID = 690
            , REQUEST_TOOLTIP_FOR_CLASSID = 525
            , REQUEST_TOGGLE_RUN = 164
            , REQUEST_UNEQUIP = 167
            , REQUEST_USE_OBJECT = 352
            , REQUEST_USE_TRANSFER_CREDIT = 752
            , REQUEST_VENDOR_BUYBACK = 527
            , REQUEST_VENDOR_PURCHASE = 528
            , REQUEST_VENDOR_REPAIR = 667
            , REQUEST_VENDOR_SALE = 529
            , REQUEST_VIEW_PLAYER_VENDOR = 353
            , REQUEST_VISUAL_COMBAT_MODE = 753
            , REQUEST_WAYPOINT_LIST = 168
            , REQUEST_WEAPONAT_TACK = 354
            , REQUEST_WEAPON_DRAW = 530
            , REQUEST_WEAPON_RELOAD = 531
            , REQUEST_WEAPON_STOW = 532
            , REQUEST_CHARACTER_NAME = 149
            , REQUEST_CREATE_CHARACTER_IN_SLOT = 512
            , REQUEST_DELETE_CHARACTER_IN_SLOT = 513
            , REQUEST_SWITCH_TO_CHARACTER_IN_SLOT = 523
            , REQUEST_ARMWEAPON = 507

            //CANCEL
            , CANCEL_LOGOUT_REQUEST = 818

            , LOGOUT_TIME_REMAINING = 819

            , HIT_POINT_CHANGED = 285

            , HEAL = 711

            , CHAT_CHANNEL_JOINED = 10000038
            , LOGIN_OK = 105
            , SYSTEM_MESSAGE = 553
            , ABILITY_DRAWER = 393
            , RADIAL_CHAT = 136
            , SHOUT = 204
            , CHANNEL_CHAT = 10000034
            , WHISPER = 2
            , WHISPER_SELF = 241
            , WHISPER_ACK = 240

            , BEGIN_CHARACTER_SELETION = 413
            , CHARACTER_CREATE_SUCCESS = 426
            , USER_CREATION_FAILED = 231
            , CHARACTER_DELETE_SUCCESS = 734
            , GENERATED_CHARACTER_NAME = 77
            , GENERATED_FAMILY_NAME = 456
            , CHARACTER_UPDATE_EMPTY_POD = -1 //UNK
            , CHARACTER_INFO = 41
            //, WONKAVATE = 242
            , CHARACTER_CLASS = 40
            , CHARACTER_NAME = 427
            , CHARACTER_LOGOUT = 10000040

            , ACTOR_NAME = 16
            , IS_RUNNING = 96
            , SKILLS = 548


            , SET_SKY_TIME = 198
            , SET_CURRENT_CONTEXTID = 362
            , UPDATE_REGIONS = 568

            , APPEARANCE_DATA = 27

            , ATTRIBUTE_INFO = 29

            , PRELOAD_DATA = 622

            , LEVEL = 103
            , LEVEL_INCREASED = 104

            , WONKAVATE = 242
            , PRE_WONKAVATE = 134
            , WORLD_LOCATION_DESCRIPTOR = 243
            , WORLD_PLACEMENT_DESCRIPTOR = 244

            , DESTROY_PHYSICAL_ENTITY = 56

            , WEAPON_READY = 575

            , USE = 230
            , USE_INTERRUPTED = 609
            , USE_INTERRUPTIBLE = 691

            , SET_AUTOLOOT_TRESHOLD = 546

            , ACCEPT_PARTY_INVITES_CHANGED = 395

            , SAVE_USER_OPTIONS = 694
            , SET_TARGETID = 201
            , TRASNFER_CREDIT_TO_LOCKBOX = 596

            , ITEM_TEMPLATE_TOOLTIP_INFO = 579

            , MAP_LOADED = 107
            , PING = 129;

    }
}
