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
    Public pnlBankVisible As Boolean
    Public pnlShopVisible As Boolean
    Public pnlTradeVisible As Boolean
    Public pnlEventChatVisible As Boolean

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
    Public ItemDescRarityBackColor As SFML.Graphics.Color

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

    Public StrengthUpgradeX As Long = 370
    Public StrengthUpgradeY As Long = 33
    Public EnduranceUpgradeX As Long = 370
    Public EnduranceUpgradeY As Long = 53
    Public VitalityUpgradeX As Long = 370
    Public VitalityUpgradeY As Long = 72
    Public IntellectUpgradeX As Long = 370
    Public IntellectUpgradeY As Long = 91
    Public LuckUpgradeX As Long = 370
    Public LuckUpgradeY As Long = 110
    Public SpiritUpgradeX As Long = 370
    Public SpiritUpgradeY As Long = 129

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

    'bank window Coordinates
    Public BankWindowX As Long = 319
    Public BankWindowY As Long = 105

    ' Bank constants
    Public Const BankTop As Byte = 30
    Public Const BankLeft As Byte = 16
    Public Const BankOffsetY As Byte = 5
    Public Const BankOffsetX As Byte = 6
    Public Const BankColumns As Byte = 9

    ' shop coordinates
    Public ShopWindowX As Long = 250
    Public ShopWindowY As Long = 125
    Public ShopFaceX As Long = 20
    Public ShopFaceY As Long = 20

    Public ShopButtonBuyX As Long = 150
    Public ShopButtonBuyY As Long = 140

    Public ShopButtonSellX As Long = 150
    Public ShopButtonSellY As Long = 190

    Public ShopButtonCloseX As Long = 10
    Public ShopButtonCloseY As Long = 215

    ' shop constants
    Public Const ShopTop As Byte = 46
    Public Const ShopLeft As Long = 271
    Public Const ShopOffsetY As Byte = 5
    Public Const ShopOffsetX As Byte = 5
    Public Const ShopColumns As Byte = 6

    'trade constants
    Public Const TradeWindowX As Long = 200
    Public Const TradeWindowY As Byte = 100
    Public Const OurTradeX As Long = 2
    Public Const OurTradeY As Byte = 17
    Public Const TheirTradeX As Long = 201
    Public Const TheirTradeY As Byte = 17

    Public TradeButtonAcceptX As Long = 50
    Public TradeButtonAcceptY As Long = 320

    Public TradeButtonDeclineX As Long = 250
    Public TradeButtonDeclineY As Long = 320

    Public TradeTimer As Long
    Public TradeRequest As Boolean
    Public InTrade As Boolean
    Public TradeYourOffer(0 To MAX_INV) As PlayerInvRec
    Public TradeTheirOffer(0 To MAX_INV) As PlayerInvRec
    Public TradeX As Long
    Public TradeY As Long
    Public TheirWorth As String
    Public YourWorth As String

    'event chat constants
    Public Const EventChatX As Long = 250
    Public Const EventChatY As Byte = 210
    Public EventChatTextX As Long = 113
    Public EventChatTextY As Long = 14

    Sub UpdateUI()
        If ReloadFrmMain = True Then
            ReloadFrmMain = False
        End If

        If UpdateNews = True Then
            frmMenu.lblNews.Text = News
            UpdateNews = False
        End If

        If pnlRegisterVisible <> frmMenu.pnlRegister.Visible Then
            frmMenu.pnlRegister.Visible = pnlRegisterVisible
        End If

        If pnlCharCreateVisible <> frmMenu.pnlNewChar.Visible Then
            frmMenu.pnlNewChar.Visible = pnlCharCreateVisible
            frmMenu.DrawCharacter()
        End If

        If lblnextcharleft <> frmMenu.lblNextChar.Left Then
            frmMenu.lblNextChar.Left = lblnextcharleft
            frmMenu.DrawCharacter()
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

        If frmmaingamevisible <> frmMainGame.Visible Then
            frmMainGame.Visible = frmmaingamevisible
        End If

        If InitMapEditor = True Then
            MapEditorInit()
            InitMapEditor = False
        End If

        If InitItemEditor = True Then
            ItemEditorPreInit()
            InitItemEditor = False
        End If

        If InitResourceEditor = True Then
            Dim i As Long

            With frmEditor_Resource
                Editor = EDITOR_RESOURCE
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_RESOURCES
                    If Resource(i).Name Is Nothing Then Resource(i).Name = ""
                    If Resource(i).SuccessMessage Is Nothing Then Resource(i).SuccessMessage = ""
                    If Resource(i).EmptyMessage Is Nothing Then Resource(i).EmptyMessage = ""
                    .lstIndex.Items.Add(i & ": " & Trim$(Resource(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                ResourceEditorInit()
            End With
            InitResourceEditor = False
        End If

        If InitNPCEditor = True Then
            With frmEditor_NPC
                Editor = EDITOR_NPC
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_NPCS
                    .lstIndex.Items.Add(i & ": " & Trim$(Npc(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                NpcEditorInit()
            End With
            InitNPCEditor = False
        End If

        If InitSpellEditor = True Then
            With frmEditor_Spell
                Editor = EDITOR_SPELL
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_SPELLS
                    .lstIndex.Items.Add(i & ": " & Trim$(Spell(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                SpellEditorInit()
            End With
            InitSpellEditor = False
        End If

        If InitShopEditor = True Then
            With frmEditor_Shop
                Editor = EDITOR_SHOP
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_SHOPS
                    .lstIndex.Items.Add(i & ": " & Trim$(Shop(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                ShopEditorInit()
            End With
            InitShopEditor = False
        End If

        If InitAnimationEditor = True Then
            With frmEditor_Animation
                Editor = EDITOR_ANIMATION
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_ANIMATIONS
                    .lstIndex.Items.Add(i & ": " & Trim$(Animation(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                AnimationEditorInit()
            End With
            InitAnimationEditor = False
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

        If frmloadvisible <> frmLoad.Visible Then
            frmLoad.Visible = frmloadvisible
        End If

        If InitMapProperties = True Then
            MapPropertiesInit()
            InitMapProperties = False
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

        If QuestEditorShow = True Then
            With frmEditor_Quest
                Editor = EDITOR_TASKS
                .lstIndex.Items.Clear()

                ' Add the names
                For I = 1 To MAX_QUESTS
                    .lstIndex.Items.Add(I & ": " & Trim$(Quest(I).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                QuestEditorInit()
            End With
            QuestEditorShow = False
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

        If HouseEdit = True Then
            With frmEditor_House
                Editor = EDITOR_HOUSE
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_HOUSES
                    .lstIndex.Items.Add(i & ": " & Trim$(House(i).ConfigName))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
            End With

            HouseEditorInit()

            HouseEdit = False
        End If

        If UpdateDialog = True Then
            If DialogType = DIALOGUE_TYPE_BUYHOME Or DialogType = DIALOGUE_TYPE_VISIT Then 'house offer & visit
                DialogButton1Text = "Accept"
                DialogButton2Text = "Decline"
                DialogPanelVisible = True
            ElseIf DialogType = DIALOGUE_TYPE_PARTY Then
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

        If ShakeTimer = True Then
            frmMainGame.tmrShake.Enabled = True
            ShakeTimer = False
        End If

        If EventChat = True Then
            pnlEventChatVisible = True
            EventChat = False
        End If

        If InitEventEditorForm = True Then
            frmEditor_Events.InitEventEditorForm()

            ' populate form
            With frmEditor_Events
                ' set the tabs
                .tabPages.TabPages.Clear()

                For i = 1 To tmpEvent.PageCount
                    .tabPages.TabPages.Add(Str(i))
                Next
                ' items
                .cmbHasItem.Items.Clear()
                .cmbHasItem.Items.Add("None")
                For i = 1 To MAX_ITEMS
                    .cmbHasItem.Items.Add(i & ": " & Trim$(Item(i).Name))
                Next
                ' variables
                .cmbPlayerVar.Items.Clear()
                .cmbPlayerVar.Items.Add("None")
                For i = 1 To MAX_VARIABLES
                    .cmbPlayerVar.Items.Add(i & ". " & Variables(i))
                Next
                ' variables
                .cmbPlayerSwitch.Items.Clear()
                .cmbPlayerSwitch.Items.Add("None")
                For i = 1 To MAX_SWITCHES
                    .cmbPlayerSwitch.Items.Add(i & ". " & Switches(i))
                Next
                ' name
                .txtName.Text = tmpEvent.Name
                ' enable delete button
                If tmpEvent.PageCount > 1 Then
                    .btnDeletePage.Enabled = True
                Else
                    .btnDeletePage.Enabled = False
                End If
                .btnPastePage.Enabled = False
                ' Load page 1 to start off with
                curPageNum = 1
                EventEditorLoadPage(curPageNum)

                .scrlShowTextFace.Maximum = NumFaces
                .scrlShowChoicesFace.Maximum = NumFaces
            End With
            ' show the editor
            frmEditor_Events.Show()

            InitEventEditorForm = False
        End If

        If InitProjectileEditor = True Then
            With frmEditor_Projectile
                Editor = EDITOR_PROJECTILE
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_PROJECTILES
                    .lstIndex.Items.Add(i & ": " & Trim$(Projectiles(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                ProjectileEditorInit()
            End With

            InitProjectileEditor = False
        End If

        If frmEditor_Projectile.Visible Then
            EditorProjectile_DrawProjectile()
        End If

        If ShowRClick = True Then
            frmMainGame.lblRCName.Text = Player(myTarget).Name
            frmMainGame.pnlRClick.Left = CurX * PIC_X
            frmMainGame.pnlRClick.Top = CurY * PIC_Y
            frmMainGame.pnlRClick.Visible = True
            ShowRClick = False
        End If

    End Sub

End Module
