Module ServerEnumerations

    ' The order of the packets must match with the client's packet enumeration

    ' Packets sent by server to client
    Public Enum ServerPackets
        SAlertMsg = 1
        SLoginOk
        SNewCharClasses
        SClassesData
        SInGame
        SPlayerInv
        SPlayerInvUpdate
        SPlayerWornEq
        SPlayerHp
        SPlayerMp
        SPlayerSp
        SPlayerStats
        SPlayerData
        SPlayerMove
        SNpcMove
        SPlayerDir
        SNpcDir
        SPlayerXY
        SAttack
        SNpcAttack
        SCheckForMap
        SMapData
        SMapItemData
        SMapNpcData
        SMapNpcUpdate
        SMapDone
        SGlobalMsg
        SAdminMsg
        SPlayerMsg
        SMapMsg
        SSpawnItem
        SItemEditor
        SUpdateItem
        SREditor
        SSpawnNpc
        SNpcDead
        SNpcEditor
        SUpdateNpc
        SMapKey
        SEditMap
        SShopEditor
        SUpdateShop
        SSpellEditor
        SUpdateSpell
        SSpells
        SLeftMap
        SResourceCache
        SResourceEditor
        SUpdateResource
        SSendPing
        SDoorAnimation
        SActionMsg
        SPlayerEXP
        SBlood
        SAnimationEditor
        SUpdateAnimation
        SAnimation
        SMapNpcVitals
        SCooldown
        SClearSpellBuffer
        SSayMsg
        SOpenShop
        SResetShopAction
        SStunned
        SMapWornEq
        SBank
        SClearTradeTimer
        STrade
        SCloseTrade
        STradeUpdate
        STradeStatus
        SGameData
        SMapReport
        STarget
        SAdmin
        SMapNames
        SCritical
        SNews

        'quests
        SQuestEditor
        SUpdateQuest
        SPlayerQuest
        SPlayerQuests
        SQuestMessage

        'Housing
        SBuyHouse
        SVisit
        SFurniture
        SHouseEdit
        SHouseConfigs

        'hotbar
        SHotbar

        'Events
        SSpawnEvent
        SEventMove
        SEventDir
        SEventChat
        SEventStart
        SEventEnd
        SPlayBGM
        SPlaySound
        SFadeoutBGM
        SStopSound
        SSwitchesAndVariables
        SMapEventData
        SChatBubble
        SSpecialEffect
        SPic
        SHoldPlayer

        SProjectileEditor
        SUpdateProjectile
        SMapProjectile

        ' Make sure SMSG_COUNT is below everything else
        SMSG_COUNT
    End Enum

    ' Packets sent by client to server
    Public Enum ClientPackets
        CNewAccount = 1
        CDelAccount
        CLogin
        CAddChar
        CUseChar
        CSayMsg
        CEmoteMsg
        CBroadcastMsg
        CPlayerMsg
        CPlayerMove
        CPlayerDir
        CUseItem
        CAttack
        CUseStatPoint
        CPlayerInfoRequest
        CWarpMeTo
        CWarpToMe
        CWarpTo
        CSetSprite
        CGetStats
        CRequestNewMap
        CMapData
        CNeedMap
        CMapGetItem
        CMapDropItem
        CMapRespawn
        CMapReport
        CKickPlayer
        CBanList
        CBanDestroy
        CBanPlayer
        CRequestEditMap
        CRequestEditItem
        CSaveItem
        CRequestEditNpc
        CSaveNpc
        CRequestEditShop
        CSaveShop
        CRequestEditSpell
        CSaveSpell
        CSetAccess
        CWhosOnline
        CSetMotd
        CSearch
        CParty
        CJoinParty
        CLeaveParty
        CSpells
        CCast
        CQuit
        CSwapInvSlots
        CRequestEditResource
        CSaveResource
        CCheckPing
        CUnequip
        CRequestPlayerData
        CRequestItems
        CRequestNPCS
        CRequestResources
        CSpawnItem
        CTrainStat
        CRequestEditAnimation
        CSaveAnimation
        CRequestAnimations
        CRequestSpells
        CRequestShops
        CRequestLevelUp
        CForgetSpell
        CCloseShop
        CBuyItem
        CSellItem
        CChangeBankSlots
        CDepositItem
        CWithdrawItem
        CCloseBank
        CAdminWarp
        CTradeRequest
        CAcceptTrade
        CDeclineTrade
        CTradeItem
        CUntradeItem
        CAdmin

        'quests
        CRequestEditQuest
        CSaveQuest
        CRequestQuests
        CQuestLogUpdate
        CPlayerHandleQuest
        CQuestReset

        'Housing
        CBuyHouse
        CVisit
        CAcceptVisit
        CPlaceFurniture
        CRequestEditHouse
        CSaveHouses
        CSellHouse

        'Hotbar
        CSetHotbarSkill
        CDeleteHotbarSkill

        'Events
        CEventChatReply
        CEvent
        CSwitchesAndVariables
        CRequestSwitchesAndVariables
        CEventTouch

        CRequestEditProjectiles
        CSaveProjectile
        CRequestProjectiles
        CClearProjectile

        ' Make sure CMSG_COUNT is below everything else
        CMSG_COUNT
    End Enum


    ' Stats used by Players, Npcs and Classes
    Public Enum Stats
        strength = 1
        endurance
        vitality
        luck
        intelligence
        spirit
        ' Make sure Stat_Count is below everything else
        Stat_Count
    End Enum

    ' Vitals used by Players, Npcs and Classes
    Public Enum Vitals
        HP = 1
        MP
        SP
        ' Make sure Vital_Count is below everything else
        Vital_Count
    End Enum

    ' Equipment used by Players
    Public Enum Equipment
        Weapon = 1
        Armor
        Helmet
        Shield
        Shoes
        Gloves
        ' Make sure Equipment_Count is below everything else
        Equipment_Count
    End Enum

    ' Layers in a map
    Public Enum MapLayer
        Ground = 1
        Mask
        Mask2
        Fringe
        Fringe2
        ' Make sure Layer_Count is below everything else
        Layer_Count
    End Enum

    ' resource skills
    Public Enum ResourceSkills
        Herbalist = 1
        WoodCutter
        Miner
        Fisherman
        ' Make sure Layer_Count is below everything else
        Skill_Count
    End Enum

End Module
