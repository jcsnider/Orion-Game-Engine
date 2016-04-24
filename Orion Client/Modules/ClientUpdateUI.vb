Module ClientUpdateUI

    Public GameDestroyed As Boolean
    Public ReloadFrmMain As Boolean
    Public pnlRegisterVisible As Boolean
    Public pnlCharCreateVisible As Boolean
    Public pnlLoginVisible As Boolean
    Public pnlCreditsVisible As Boolean
    Public frmmenuvisible As Boolean
    Public frmmaingamevisible As Boolean
    Public frmloadvisible As Boolean
    Public lblnextcharleft As Long
    Public cmbclass() As String
    Public txtChatAdd As String
    Public chkSavePassChecked As Boolean
    Public tempUserName As String
    Public tempPassword As String

    'Mapreport
    Public UpdateMapnames As Boolean
    Public ShakeTimer As Boolean

    Public Adminvisible As Boolean

    'GUI drawing
    Public HUDVisible As Boolean
    Public pnlCharacterVisible As Boolean
    Public pnlInventoryVisible As Boolean
    Public pnlSpellsVisible As Boolean

    Public VbKeyRight As Boolean
    Public VbKeyLeft As Boolean
    Public VbKeyUp As Boolean
    Public VbKeyDown As Boolean
    Public VbKeyShift As Boolean
    Public VbKeyControl As Boolean

    Public picHpWidth As Long
    Public picManaWidth As Long
    Public picEXPWidth As Long

    Public lblHPText As String
    Public lblManaText As String
    Public lblEXPText As String

    'Editors
    Public InitMapEditor As Boolean
    Public InitItemEditor As Boolean
    Public InitResourceEditor As Boolean
    Public InitNPCEditor As Boolean
    Public InitSpellEditor As Boolean
    Public InitShopEditor As Boolean
    Public InitAnimationEditor As Boolean

    Public UpdateCharacterPanel As Boolean

    Public NeedToOpenShop As Boolean
    Public NeedToOpenShopNum As Long
    Public NeedToOpenBank As Boolean
    Public NeedToOpenTrade As Boolean
    Public NeedtoCloseTrade As Boolean
    Public NeedtoUpdateTrade As Boolean

    Public InitMapProperties As Boolean

    Public Tradername As String

    'UI Panels Coordinates
    Public HUDWindowX As Long = 0
    Public HUDWindowY As Long = 0
    Public HUDFaceX As Long = 4
    Public HUDFaceY As Long = 4
    'bars
    Public HUDHPBarX As Long = 110
    Public HUDHPBarY As Long = 10
    Public HUDMPBarX As Long = 110
    Public HUDMPBarY As Long = 30
    Public HUDEXPBarX As Long = 110
    Public HUDEXPBarY As Long = 50

    'Set the Chat Position

    Public MyChatX As Long = 1
    Public MyChatY As Long = frmMainGame.Height - 55

    Public ChatWindowX As Long = 1
    Public ChatWindowY As Long = 705

    Public ShowItemDesc As Boolean
    Public ItemDescSize As Byte
    Public ItemDescItemNum As Long
    Public ItemDescName As String
    Public ItemDescValue As Long
    Public ItemDescInfo As String
    Public ItemDescType As String
    Public ItemDescCost As String
    Public ItemDescLevel As String
    Public ItemDescSpeed As String
    Public ItemDescStr As String
    Public ItemDescEnd As String
    Public ItemDescInt As String
    Public ItemDescSpr As String
    Public ItemDescVit As String
    Public ItemDescLuck As String
    Public ItemDescRarityColor As SFML.Graphics.Color

    'Action Panel Coordinates
    Public ActionPanelX As Long = 942
    Public ActionPanelY As Long = 755
    Public InvBtnX As Long = 16
    Public InvBtnY As Long = 16
    Public SkillBtnX As Long = 64
    Public SkillBtnY As Long = 16
    Public CharBtnX As Long = 112
    Public CharBtnY As Long = 16
    Public QuestBtnX As Long = 160
    Public QuestBtnY As Long = 16
    Public TradeBtnX As Long = 16
    Public TradeBtnY As Long = 64
    Public OptBtnX As Long = 64
    Public OptBtnY As Long = 64
    Public ExitBtnX As Long = 112
    Public ExitBtnY As Long = 64

    'Character window Coordinates
    Public CharWindowX As Long = 943
    Public CharWindowY As Long = 475
    Public Const EqTop As Byte = 85
    Public Const EqLeft As Byte = 8
    Public Const EqOffsetX As Byte = 125
    Public Const EqOffsetY As Byte = 5
    Public Const EqColumns As Byte = 2

    Public StrengthUpgradeX As Long = 69
    Public StrengthUpgradeY As Long = 221
    Public EnduranceUpgradeX As Long = 157
    Public EnduranceUpgradeY As Long = 221
    Public VitalityUpgradeX As Long = 69
    Public VitalityUpgradeY As Long = 237
    Public IntellectUpgradeX As Long = 69
    Public IntellectUpgradeY As Long = 252
    Public LuckUpgradeX As Long = 157
    Public LuckUpgradeY As Long = 237
    Public SpiritUpgradeX As Long = 157
    Public SpiritUpgradeY As Long = 252

    'Hotbar Coordinates
    Public HotbarX As Long = 489
    Public HotbarY As Long = 825

    'Inventory window Coordinates
    Public InvWindowX As Long = 943
    Public InvWindowY As Long = 475
    Public Const InvTop As Byte = 9
    Public Const InvLeft As Byte = 10
    Public Const InvOffsetY As Byte = 5
    Public Const InvOffsetX As Byte = 6
    Public Const InvColumns As Byte = 5

    'Spell window Coordinates
    Public SpellWindowX As Long = 943
    Public SpellWindowY As Long = 475
    ' spells constants
    Public Const SpellTop As Byte = 9
    Public Const SpellLeft As Byte = 10
    Public Const SpellOffsetY As Byte = 5
    Public Const SpellOffsetX As Byte = 6
    Public Const SpellColumns As Byte = 5

    Public ShowSpellDesc As Boolean
    Public SpellDescSize As Byte
    Public SpellDescSpellNum As Long
    Public SpellDescName As String
    Public SpellDescVital As String
    Public SpellDescInfo As String
    Public SpellDescType As String
    Public SpellDescCastTime As String
    Public SpellDescCoolDown As String
    Public SpellDescDamage As String
    Public SpellDescAOE As String
    Public SpellDescRange As String
    Public SpellDescReqMp As String
    Public SpellDescReqLvl As String
    Public SpellDescReqClass As String
    Public SpellDescReqAccess As String

    'dialog panel
    Public DialogPanelVisible As Boolean
    Public DialogPanelX As Long = 250
    Public DialogPanelY As Long = 400
    Public OkButtonX As Long = 10
    Public OkButtonY As Long = 90
    Public CancelButtonX As Long = 340
    Public CancelButtonY As Long = 90

End Module
