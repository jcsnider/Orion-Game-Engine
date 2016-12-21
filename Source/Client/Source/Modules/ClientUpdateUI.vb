Module ClientUpdateUI

#Region "Defines"
    Public GameDestroyed As Boolean
    Public ReloadFrmMain As Boolean
    Public pnlRegisterVisible As Boolean
    Public pnlCharCreateVisible As Boolean
    Public pnlLoginVisible As Boolean
    Public pnlCreditsVisible As Boolean
    Public frmmenuvisible As Boolean
    Public frmmaingamevisible As Boolean
    Public pnlloadvisible As Boolean
    Public lblnextcharleft As Integer
    Public cmbclass() As String
    Public txtChatAdd As String
    Public chkSavePassChecked As Boolean
    Public tempUserName As String
    Public tempPassword As String
    Public pnlCharSelectVisible As Boolean
    Public DrawCharSelect As Boolean

    'Mapreport
    Public UpdateMapnames As Boolean

    Public Adminvisible As Boolean

    'GUI drawing
    Public HUDVisible As Boolean
    Public pnlCharacterVisible As Boolean
    Public pnlInventoryVisible As Boolean
    Public pnlSkillsVisible As Boolean
    Public pnlBankVisible As Boolean
    Public pnlShopVisible As Boolean
    Public pnlTradeVisible As Boolean
    Public pnlEventChatVisible As Boolean
    Public pnlRClickVisible As Boolean
    Public OptionsVisible As Boolean

    Public VbKeyRight As Boolean
    Public VbKeyLeft As Boolean
    Public VbKeyUp As Boolean
    Public VbKeyDown As Boolean
    Public VbKeyShift As Boolean
    Public VbKeyControl As Boolean
    Public VbKeyAlt As Boolean

    Public picHpWidth As Integer
    Public picManaWidth As Integer
    Public picEXPWidth As Integer

    Public lblHPText As String
    Public lblManaText As String
    Public lblEXPText As String

    'Editors
    Public InitMapEditor As Boolean

    Public UpdateCharacterPanel As Boolean

    Public NeedToOpenShop As Boolean
    Public NeedToOpenShopNum As Integer
    Public NeedToOpenBank As Boolean
    Public NeedToOpenTrade As Boolean
    Public NeedtoCloseTrade As Boolean
    Public NeedtoUpdateTrade As Boolean

    Public InitMapProperties As Boolean

    Public Tradername As String

    'UI Panels Coordinates
    Public HUDWindowX As Integer = 0
    Public HUDWindowY As Integer = 0
    Public HUDFaceX As Integer = 4
    Public HUDFaceY As Integer = 4
    'bars
    Public HUDHPBarX As Integer = 110
    Public HUDHPBarY As Integer = 10
    Public HUDMPBarX As Integer = 110
    Public HUDMPBarY As Integer = 30
    Public HUDEXPBarX As Integer = 110
    Public HUDEXPBarY As Integer = 50

    'Set the Chat Position

    Public MyChatX As Integer = 1
    Public MyChatY As Integer = frmMainGame.Height - 55

    Public ChatWindowX As Integer = 1
    Public ChatWindowY As Integer = 705

    Public ShowItemDesc As Boolean
    Public ItemDescItemNum As Integer
    Public ItemDescName As String
    Public ItemDescDescription As String
    Public ItemDescValue As Integer
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
    Public ItemDescRarityBackColor As SFML.Graphics.Color

    'Action Panel Coordinates
    Public ActionPanelX As Integer = 942
    Public ActionPanelY As Integer = 755

    Public InvBtnX As Integer = 16
    Public InvBtnY As Integer = 16
    Public SkillBtnX As Integer = 80
    Public SkillBtnY As Integer = 16
    Public CharBtnX As Integer = 144
    Public CharBtnY As Integer = 16

    Public QuestBtnX As Integer = 25
    Public QuestBtnY As Integer = 64
    Public OptBtnX As Integer = 88
    Public OptBtnY As Integer = 64
    Public ExitBtnX As Integer = 144
    Public ExitBtnY As Integer = 64

    'Character window Coordinates
    Public CharWindowX As Integer = 943
    Public CharWindowY As Integer = 475
    Public Const EqTop As Byte = 85
    Public Const EqLeft As Byte = 8
    Public Const EqOffsetX As Byte = 125
    Public Const EqOffsetY As Byte = 5
    Public Const EqColumns As Byte = 2

    Public StrengthUpgradeX As Integer = 370
    Public StrengthUpgradeY As Integer = 33
    Public EnduranceUpgradeX As Integer = 370
    Public EnduranceUpgradeY As Integer = 53
    Public VitalityUpgradeX As Integer = 370
    Public VitalityUpgradeY As Integer = 72
    Public IntellectUpgradeX As Integer = 370
    Public IntellectUpgradeY As Integer = 91
    Public LuckUpgradeX As Integer = 370
    Public LuckUpgradeY As Integer = 110
    Public SpiritUpgradeX As Integer = 370
    Public SpiritUpgradeY As Integer = 129

    'Hotbar Coordinates
    Public HotbarX As Integer = 489
    Public HotbarY As Integer = 825

    'Inventory window Coordinates
    Public InvWindowX As Integer = 943
    Public InvWindowY As Integer = 475
    Public Const InvTop As Byte = 9
    Public Const InvLeft As Byte = 10
    Public Const InvOffsetY As Byte = 5
    Public Const InvOffsetX As Byte = 6
    Public Const InvColumns As Byte = 5

    'Skill window Coordinates
    Public SkillWindowX As Integer = 943
    Public SkillWindowY As Integer = 475
    ' skills constants
    Public Const SkillTop As Byte = 9
    Public Const SkillLeft As Byte = 10
    Public Const SkillOffsetY As Byte = 5
    Public Const SkillOffsetX As Byte = 6
    Public Const SkillColumns As Byte = 5

    Public ShowSkillDesc As Boolean
    Public SkillDescSize As Byte
    Public SkillDescSkillNum As Integer
    Public SkillDescName As String
    Public SkillDescVital As String
    Public SkillDescInfo As String
    Public SkillDescType As String
    Public SkillDescCastTime As String
    Public SkillDescCoolDown As String
    Public SkillDescDamage As String
    Public SkillDescAOE As String
    Public SkillDescRange As String
    Public SkillDescReqMp As String
    Public SkillDescReqLvl As String
    Public SkillDescReqClass As String
    Public SkillDescReqAccess As String

    'dialog panel
    Public DialogPanelVisible As Boolean
    Public DialogPanelX As Integer = 250
    Public DialogPanelY As Integer = 400
    Public OkButtonX As Integer = 50
    Public OkButtonY As Integer = 130
    Public CancelButtonX As Integer = 200
    Public CancelButtonY As Integer = 130

    'bank window Coordinates
    Public BankWindowX As Integer = 319
    Public BankWindowY As Integer = 105

    ' Bank constants
    Public Const BankTop As Byte = 30
    Public Const BankLeft As Byte = 16
    Public Const BankOffsetY As Byte = 5
    Public Const BankOffsetX As Byte = 6
    Public Const BankColumns As Byte = 9

    ' shop coordinates
    Public ShopWindowX As Integer = 250
    Public ShopWindowY As Integer = 125
    Public ShopFaceX As Integer = 60
    Public ShopFaceY As Integer = 60

    Public ShopButtonBuyX As Integer = 150
    Public ShopButtonBuyY As Integer = 140

    Public ShopButtonSellX As Integer = 150
    Public ShopButtonSellY As Integer = 190

    Public ShopButtonCloseX As Integer = 10
    Public ShopButtonCloseY As Integer = 215

    ' shop constants
    Public Const ShopTop As Byte = 46
    Public Const ShopLeft As Integer = 271
    Public Const ShopOffsetY As Byte = 5
    Public Const ShopOffsetX As Byte = 5
    Public Const ShopColumns As Byte = 6

    'trade constants
    Public Const TradeWindowX As Integer = 200
    Public Const TradeWindowY As Byte = 100
    Public Const OurTradeX As Integer = 2
    Public Const OurTradeY As Byte = 17
    Public Const TheirTradeX As Integer = 201
    Public Const TheirTradeY As Byte = 17

    Public TradeButtonAcceptX As Integer = 50
    Public TradeButtonAcceptY As Integer = 320

    Public TradeButtonDeclineX As Integer = 250
    Public TradeButtonDeclineY As Integer = 320

    Public TradeTimer As Integer
    Public TradeRequest As Boolean
    Public InTrade As Boolean
    Public TradeYourOffer(0 To MAX_INV) As PlayerInvRec
    Public TradeTheirOffer(0 To MAX_INV) As PlayerInvRec
    Public TradeX As Integer
    Public TradeY As Integer
    Public TheirWorth As String
    Public YourWorth As String

    'event chat constants
    Public Const EventChatX As Integer = 250
    Public Const EventChatY As Byte = 210
    Public EventChatTextX As Integer = 113
    Public EventChatTextY As Integer = 14

    'right click menu
    Public RClickname As String
    Public RClickX As Integer
    Public RClickY As Integer

    Public DrawChar As Boolean

    Public CraftPanelX As Integer = 25
    Public CraftPanelY As Integer = 25
    Public LoadClassInfo As Boolean
#End Region

    Sub UpdateUI()
        If ReloadFrmMain = True Then
            ReloadFrmMain = False
        End If

        If UpdateNews = True Then
            frmMenu.lblNews.Text = News
            frmMenu.Text = GAME_NAME
            frmMainGame.Text = GAME_NAME
            UpdateNews = False
        End If

        If pnlRegisterVisible <> frmMenu.pnlRegister.Visible Then
            frmMenu.pnlRegister.Visible = pnlRegisterVisible
        End If

        If DrawChar = True Then
            frmMenu.DrawCharacter()
            DrawChar = False
        End If

        If pnlCharCreateVisible <> frmMenu.pnlNewChar.Visible Then
            frmMenu.pnlNewChar.Visible = pnlCharCreateVisible
            DrawChar = True
        End If

        If lblnextcharleft <> frmMenu.lblNextChar.Left Then
            frmMenu.lblNextChar.Left = lblnextcharleft
        End If

        If Not cmbclass Is Nothing Then
            frmMenu.cmbClass.Items.Clear()

            For i = 1 To UBound(cmbclass)
                frmMenu.cmbClass.Items.Add(cmbclass(i))
            Next

            frmMenu.cmbClass.SelectedIndex = 0

            frmMenu.rdoMale.Checked = True

            frmMenu.txtCharName.Focus()

            cmbclass = Nothing
        End If

        If pnlLoginVisible <> frmMenu.pnlLogin.Visible Then
            frmMenu.pnlLogin.Visible = pnlLoginVisible
            If pnlLoginVisible Then
                frmMenu.txtLogin.Focus()
            End If
        End If

        If pnlCreditsVisible <> frmMenu.pnlCredits.Visible Then
            frmMenu.pnlCredits.Visible = pnlCreditsVisible
        End If

        If frmmenuvisible <> frmMenu.Visible Then
            frmMenu.Visible = frmmenuvisible
        End If

        If DrawCharSelect Then
            frmMenu.DrawCharacterSelect()
            DrawCharSelect = False
        End If

        If pnlCharSelectVisible <> frmMenu.pnlCharSelect.Visible Then
            frmMenu.pnlCharSelect.Visible = pnlCharSelectVisible
            If pnlCharSelectVisible Then
                DrawCharSelect = True
            End If
        End If

        If frmmaingamevisible <> frmMainGame.Visible Then
            frmMainGame.Visible = frmmaingamevisible
        End If

        If InitCrafting = True Then
            CraftingInit()
            InitCrafting = False
        End If

        If NeedToOpenShop = True Then
            OpenShop(NeedToOpenShopNum)
            NeedToOpenShop = False
            NeedToOpenShopNum = 0
            pnlShopVisible = True
        End If

        If NeedToOpenBank = True Then
            InBank = True
            pnlBankVisible = True
            DrawBank()
            NeedToOpenBank = False
        End If

        If NeedToOpenTrade = True Then
            InTrade = True
            pnlTradeVisible = True

            NeedToOpenTrade = False
        End If

        If NeedtoCloseTrade = True Then
            InTrade = False
            pnlTradeVisible = False

            NeedtoCloseTrade = False
        End If

        If NeedtoUpdateTrade = True Then
            DrawTrade()
            NeedtoUpdateTrade = False
        End If

        If UpdateCharacterPanel = True Then
            UpdateCharacterPanel = False
        End If

        If pnlloadvisible <> frmMenu.pnlLoad.Visible Then
            frmMenu.pnlLoad.Visible = pnlloadvisible
        End If

        If UpdateMapnames = True Then
            Dim x As Integer

            frmAdmin.lstMaps.Items.Clear()

            For x = 1 To MAX_MAPS
                frmAdmin.lstMaps.Items.Add(x)
                frmAdmin.lstMaps.Items(x - 1).SubItems.Add(MapNames(x))
            Next

            UpdateMapnames = False
        End If

        If Adminvisible = True Then
            frmAdmin.Visible = Not frmAdmin.Visible
            Adminvisible = False
        End If

        If UpdateQuestChat = True Then
            DialogMsg1 = "Quest: " & Trim$(Quest(QuestNum).Name)
            DialogMsg2 = QuestMessage

            DialogType = DIALOGUE_TYPE_QUEST

            If QuestNumForStart > 0 And QuestNumForStart <= MAX_QUESTS Then
                QuestAcceptTag = QuestNumForStart
            End If

            UpdateDialog = True

            UpdateQuestChat = False
        End If

        If UpdateQuestWindow = True Then
            LoadQuestlogBox()
            UpdateQuestWindow = False
        End If

        If UpdateDialog = True Then
            If DialogType = DIALOGUE_TYPE_BUYHOME Or DialogType = DIALOGUE_TYPE_VISIT Then 'house offer & visit
                DialogButton1Text = "Accept"
                DialogButton2Text = "Decline"
                DialogPanelVisible = True
            ElseIf DialogType = DIALOGUE_TYPE_PARTY Or DialogType = DIALOGUE_TYPE_TRADE Then
                DialogButton1Text = "Accept"
                DialogButton2Text = "Decline"
                DialogPanelVisible = True
            ElseIf DialogType = DIALOGUE_TYPE_QUEST Then
                DialogButton1Text = "Accept"
                DialogButton2Text = "Ok"
                If QuestAcceptTag > 0 Then
                    DialogButton2Text = "Decline"
                End If
                DialogPanelVisible = True
            End If

            UpdateDialog = False
        End If

        If EventChat = True Then
            pnlEventChatVisible = True
            EventChat = False
        End If

        If ShowRClick = True Then
            RClickname = Player(myTarget).Name
            RClickX = ConvertMapX(CurX * PIC_X)
            RClickY = ConvertMapY(CurY * PIC_Y)
            pnlRClickVisible = True

            ShowRClick = False
        End If

        If InitMapEditor = True Then
            frmEditor_MapEditor.MapEditorInit()
            InitMapEditor = False
        End If

        If InitMapProperties = True Then
            frmEditor_MapEditor.MapPropertiesInit()
            InitMapProperties = False
        End If

        If OptionsVisible = True Then

            ' show in GUI
            If Options.Music = 1 Then
                frmOptions.optMOn.Checked = True
            Else
                frmOptions.optMOff.Checked = True
            End If

            If Options.Music = 1 Then
                frmOptions.optSOn.Checked = True
            Else
                frmOptions.optSOff.Checked = True
            End If

            frmOptions.lblVolume.Text = "Volume: " & Options.Volume
            frmOptions.scrlVolume.Value = Options.Volume

            frmOptions.cmbScreenSize.SelectedIndex = Options.ScreenSize

            If Options.HighEnd = 1 Then
                frmOptions.chkHighEnd.Checked = True
            Else
                frmOptions.chkHighEnd.Checked = False
            End If

            If Options.ShowNpcBar = 1 Then
                frmOptions.chkNpcBars.Checked = True
            Else
                frmOptions.chkNpcBars.Checked = False
            End If

            frmOptions.Visible = True
            OptionsVisible = False
        End If
    End Sub

End Module
