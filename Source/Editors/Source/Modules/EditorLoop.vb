Imports System.Threading

Module EditorLoop
#Region "Startup"
    Public Sub Main()

        'check if we are in the right place...
        If Not IO.Directory.Exists(Application.StartupPath & "\Data Files") Then
            MsgBox("Run Editor from inside the Client folder!")
            End
        End If

        If GameStarted = True Then Exit Sub

        SFML.CSFML.Activate()

        'Strings.Init(1, "English")

        ' set values for directional blocking arrows
        DirArrowX(1) = 12 ' up
        DirArrowY(1) = 0
        DirArrowX(2) = 12 ' down
        DirArrowY(2) = 23
        DirArrowX(3) = 0 ' left
        DirArrowY(3) = 12
        DirArrowX(4) = 23 ' right
        DirArrowY(4) = 12

        CheckTilesets()
        CheckCharacters()
        CheckPaperdolls()
        CheckAnimations()
        CheckItems()
        CheckResources()
        CheckSkillIcons()
        CheckFaces()
        CheckFog()
        CacheMusic()
        CacheSound()

        CheckFurniture()
        CheckProjectiles()

        InitGraphics()
        InitMessages()

        ReDim Autotile(0 To Map.MaxX, 0 To Map.MaxY)

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)
                For i = 0 To MapLayer.Count - 1
                    ReDim Autotile(X, Y).Layer(i).srcX(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).srcY(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).QuarterTile(0 To 4)
                Next
            Next
        Next

        ''Housing
        ReDim House(0 To MAX_HOUSES)
        ReDim HouseConfig(0 To MAX_HOUSES)

        'quests
        ReDim Quest(MAX_QUESTS)
        ClearQuests()

        ReDim Map.Npc(0 To MAX_MAP_NPCS)

        ReDim Item(0 To MAX_ITEMS)
        For i = 0 To MAX_ITEMS
            For x = 0 To Stats.Count - 1
                ReDim Item(i).Add_Stat(x)
            Next
            For x = 0 To Stats.Count - 1
                ReDim Item(i).Stat_Req(x)
            Next

            ReDim Item(i).FurnitureBlocks(0 To 3, 0 To 3)
            ReDim Item(i).FurnitureFringe(0 To 3, 0 To 3)
        Next

        ReDim Npc(0 To MAX_NPCS)
        For i = 0 To MAX_NPCS
            For x = 0 To Stats.Count - 1
                ReDim Npc(i).Stat(x)
            Next

            ReDim Npc(i).DropChance(5)
            ReDim Npc(i).DropItem(5)
            ReDim Npc(i).DropItemValue(5)

            ReDim Npc(i).Skill(6)
        Next

        ReDim MapNpc(0 To MAX_MAP_NPCS)
        For i = 0 To MAX_MAP_NPCS
            For x = 0 To Vitals.Count - 1
                ReDim MapNpc(i).Vital(x)
            Next
        Next

        ReDim Shop(0 To MAX_SHOPS)
        For i = 0 To MAX_SHOPS
            For x = 0 To MAX_TRADES
                ReDim Shop(i).TradeItem(x)
            Next
        Next

        ReDim Animation(0 To MAX_ANIMATIONS)
        For i = 0 To MAX_ANIMATIONS
            For x = 0 To 1
                ReDim Animation(i).Sprite(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).Frames(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).LoopCount(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).looptime(x)
            Next
        Next

        'craft
        ClearRecipes()

        'pets
        ClearPets()

        ' load options
        LoadOptions()

        GameDestroyed = False
        GameStarted = True

        frmLogin.Visible = True

        GameLoop()

    End Sub
#End Region

#Region "Options"

    Public Sub LoadOptions()
        Dim myXml As New XmlClass With {
            .Filename = Application.StartupPath & "\Data Files\Config.xml",
            .Root = "Options"
        }

        If Not FileExist(myXml.Filename) Then
            Options.Password = ""
            Options.SavePass = False
            Options.Username = ""
            Options.IP = "Localhost"
            Options.Port = 7001
            Options.MenuMusic = ""
            Options.Music = 1
            Options.Sound = 1
            Options.Volume = 100

        Else
            Options.Username = myXml.ReadString("UserInfo", "Username", "")
            Options.Password = myXml.ReadString("UserInfo", "Password", "")
            Options.SavePass = myXml.ReadString("UserInfo", "SavePass", "False")

            Options.IP = myXml.ReadString("Connection", "Ip", "127.0.0.1")
            Options.Port = Val(myXml.ReadString("Connection", "Port", "7001"))

            Options.MenuMusic = myXml.ReadString("Sfx", "MenuMusic", "")
            Options.Music = myXml.ReadString("Sfx", "Music", "1")
            Options.Sound = myXml.ReadString("Sfx", "Sound", "1")
            Options.Volume = Val(myXml.ReadString("Sfx", "Volume", "100"))
        End If

        frmLogin.txtLogin.Text = Options.Username
        frmLogin.txtPassword.Text = Options.Password
    End Sub
#End Region

    Sub GameLoop()
        Dim dest As Point = New Point(FrmEditor_MapEditor.PointToScreen(FrmEditor_MapEditor.picScreen.Location))
        Dim g As Graphics = FrmEditor_MapEditor.picScreen.CreateGraphics
        Dim starttime As Integer, Tick As Integer, fogtmr As Integer
        Dim FrameTime As Integer, tmr500 As Integer
        Dim destrect As Rectangle, tmpfps As Integer

        starttime = GetTickCount()

        Do
            If GameDestroyed = True Then End

            UpdateUI()

            If GameStarted = True Then
                Tick = GetTickCount()

                ' update animation editor
                If Editor = EDITOR_ANIMATION Then
                    EditorAnim_DrawAnim()
                End If

                FrameTime = Tick
                If InMapEditor And Not GettingMap Then

                    'Calculate FPS
                    If starttime < GetTickCount() Then
                        FPS = tmpfps

                        FrmEditor_MapEditor.tsCurFps.Text = "Current FPS: " & FPS
                        tmpfps = 0
                        starttime = GetTickCount() + 1000
                    End If
                    tmpfps = tmpfps + 1

                    SyncLock MapLock
                        ' fog scrolling
                        If fogtmr < Tick Then
                            If CurrentFogSpeed > 0 Then
                                'move
                                fogOffsetX = fogOffsetX - 1
                                fogOffsetY = fogOffsetY - 1
                                Reset()
                                If fogOffsetX < -256 Then fogOffsetX = 0
                                If fogOffsetY < -256 Then fogOffsetY = 0
                                fogtmr = Tick + 255 - CurrentFogSpeed
                            End If
                        End If

                        If tmr500 < Tick Then
                            ' animate waterfalls
                            Select Case waterfallFrame
                                Case 0
                                    waterfallFrame = 1
                                Case 1
                                    waterfallFrame = 2
                                Case 2
                                    waterfallFrame = 0
                            End Select
                            ' animate autotiles
                            Select Case autoTileFrame
                                Case 0
                                    autoTileFrame = 1
                                Case 1
                                    autoTileFrame = 2
                                Case 2
                                    autoTileFrame = 0
                            End Select

                            tmr500 = Tick + 500
                        End If

                        ProcessWeather()

                        'Auctual Game Loop Stuff :/
                        Render_Graphics()

                        If FadeInSwitch = True Then
                            FadeIn()
                        End If

                        If FadeOutSwitch = True Then
                            FadeOut()
                        End If

                        destrect = New Rectangle(0, 0, ScreenX, ScreenY)
                        Application.DoEvents()

                        EditorMap_DrawTileset()
                    End SyncLock

                End If
            End If

            Application.DoEvents()
            Thread.Sleep(1)
        Loop
    End Sub

    Sub UpdateUI()
        If InitEditor = True Then
            frmLogin.pnlAdmin.Visible = True
            InitEditor = False
        End If

        If InitPetEditor = True Then
            With frmEditor_Pet
                Editor = EDITOR_PET
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_PETS
                    .lstIndex.Items.Add(i & ": " & Trim$(Pet(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                PetEditorInit()
            End With
            InitPetEditor = False
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

        If InitAnimationEditor = True Then
            With FrmEditor_Animation
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

        If InitMapEditor = True Then
            MapEditorInit()
            InitMapEditor = False
        End If

        If InitMapProperties = True Then
            MapPropertiesInit()
            InitMapProperties = False
        End If

        If InitItemEditor = True Then
            ItemEditorPreInit()
            InitItemEditor = False
        End If

        If InitRecipeEditor = True Then
            RecipeEditorPreInit()
            InitRecipeEditor = False
        End If

        If InitClassEditor = True Then
            ClassEditorInit()
            InitClassEditor = False
        End If

        If LoadClassInfo = True Then
            LoadClass()
            LoadClassInfo = False
        End If

        If InitResourceEditor = True Then
            Dim i As Integer

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

        If InitSkillEditor = True Then
            With frmEditor_Skill
                Editor = EDITOR_SKILL
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_SKILLS
                    .lstIndex.Items.Add(i & ": " & Trim$(Skill(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                SkillEditorInit()
            End With
            InitSkillEditor = False
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
            With FrmEditor_Animation
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

        If InitAutoMapper = True Then
            FrmAutoMapper.Visible = True
            InitAutoMapper = False
        End If
    End Sub

    Sub CloseEditor()
        SendLeaveGame()

        GameDestroyed = True
        GameStarted = False

        Application.Exit()
    End Sub

End Module