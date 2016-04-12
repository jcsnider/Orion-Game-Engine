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

    'Character window Coordinates
    Public CharWindowX As Long = 748
    Public CharWindowY As Long = 275
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
    Public WillPowerUpgradeX As Long = 157
    Public WillPowerUpgradeY As Long = 237
    Public SpiritUpgradeX As Long = 157
    Public SpiritUpgradeY As Long = 252

    'Action Panel Coordinates
    Public ActionPanelX As Long = 747
    Public ActionPanelY As Long = 555
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

    'Hotbar Coordinates
    Public HotbarX As Long = 489
    Public HotbarY As Long = 626

    'Inventory window Coordinates
    Public InvWindowX As Long = 748
    Public InvWindowY As Long = 275
    Public Const InvTop As Byte = 9
    Public Const InvLeft As Byte = 10
    Public Const InvOffsetY As Byte = 5
    Public Const InvOffsetX As Byte = 6
    Public Const InvColumns As Byte = 5

    'Spell window Coordinates
    Public SpellWindowX As Long = 748
    Public SpellWindowY As Long = 275
    ' spells constants
    Public Const SpellTop As Byte = 9
    Public Const SpellLeft As Byte = 10
    Public Const SpellOffsetY As Byte = 5
    Public Const SpellOffsetX As Byte = 6
    Public Const SpellColumns As Byte = 5
End Module
