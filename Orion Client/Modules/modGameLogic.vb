﻿Imports SFML.Graphics
Imports SFML.Audio
Imports System.Drawing
Imports System.Windows.Forms

Module modGameLogic
    Sub GameLoop()
        Dim i As Long
        Dim dest As Point = New Point(frmMainGame.PointToScreen(frmMainGame.picscreen.Location))
        Dim starttime As Long
        Dim Tick As Long
        Dim fps As Long
        Dim WalkTimer As Long
        Dim FrameTime As Long
        Dim destrect As Rectangle
        Dim tmr10000 As Long
        Dim tmr1000 As Long
        Dim tmr100 As Long
        Dim g As Graphics = frmMainGame.picscreen.CreateGraphics
        starttime = GetTickCount()
        frmMenu.lblNextChar.Left = lblnextcharleft
        Do
            If GameDestroyed Then End
            DirDown = VbKeyDown
            DirUp = VbKeyUp
            DirLeft = VbKeyLeft
            DirRight = VbKeyRight

            'Update the UI
            UpdateUI()

            If GameStarted() = True Then
                Tick = GetTickCount()
                ElapsedTime = Tick - FrameTime                 ' Set the time difference for time-based movement
                FrameTime = Tick
                frmmaingamevisible = True

                If GetTickCount() - starttime >= 1000 Then
                    frmMainGame.lblFPS.Text = fps
                    fps = 0
                    starttime = GetTickCount()
                Else
                    fps = fps + 1
                End If

                ' Update inv animation
                If NumItems > 0 Then
                    If tmr100 < Tick Then
                        If frmMainGame.pnlInventory.Visible = True Then
                            DrawInventory()
                        End If
                        If frmMainGame.pnlSpells.Visible = True Then DrawPlayerSpells()
                        If frmMainGame.pnlCharacter.Visible = True Then DrawEquipment()
                        If InBank Then DrawBank()
                        If InShop Then DrawShop()
                        tmr100 = Tick + 100
                    End If
                End If

                ' Change map animation every 250 milliseconds
                If MapAnimTimer < Tick Then
                    MapAnim = Not MapAnim
                    MapAnimTimer = Tick + 250
                End If

                For i = 1 To MAX_BYTE
                    CheckAnimInstance(i)
                Next

                If tmr1000 < Tick Then
                    tmr1000 = Tick + 1000
                End If

                If tmr10000 < Tick Then
                    GetPing()
                    DrawPing()
                    tmr10000 = Tick + 10000
                End If

                ' check if trade timed out
                If TradeRequest = True Then
                    If TradeTimer < Tick Then
                        AddText("You took too long to decide. Please try again.")
                        TradeRequest = False
                        TradeTimer = 0
                    End If
                End If

                ' check if we need to end the CD icon
                If NumSpellIcons > 0 Then
                    For i = 1 To MAX_PLAYER_SPELLS
                        If PlayerSpells(i) > 0 Then
                            If SpellCD(i) > 0 Then
                                If SpellCD(i) + (Spell(PlayerSpells(i)).CDTime * 1000) < Tick Then
                                    SpellCD(i) = 0
                                    DrawPlayerSpells()
                                End If
                            End If
                        End If
                    Next
                End If

                ' check if we need to unlock the player's spell casting restriction
                If SpellBuffer > 0 Then
                    If SpellBufferTimer + (Spell(PlayerSpells(SpellBuffer)).CastTime * 1000) < Tick Then
                        SpellBuffer = 0
                        SpellBufferTimer = 0
                    End If
                End If

                SyncLock MapLock
                    If CanMoveNow Then
                        Call CheckMovement() ' Check if player is trying to move
                        Call CheckAttack()   ' Check to see if player is trying to attack
                    End If

                    ' Process input before rendering, otherwise input will be behind by 1 frame
                    If WalkTimer < Tick Then

                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                Call ProcessMovement(i)
                            End If
                        Next i

                        ' Process npc movements (actually move them)
                        For i = 1 To MAX_MAP_NPCS
                            If Map.Npc(i) > 0 Then
                                Call ProcessNpcMovement(i)
                            End If
                        Next i

                        WalkTimer = Tick + 30 ' edit this value to change WalkTimer
                    End If

                    'Auctual Game Loop Stuff :/
                    Render_Graphics()
                    DrawStatBars()

                    destrect = New Rectangle(0, 0, ScreenX, ScreenY)
                    Application.DoEvents()



                    If GettingMap Then
                        g.DrawString("Receiving Map", New System.Drawing.Font(FONT_NAME, FONT_SIZE), Brushes.DarkCyan, frmMainGame.picscreen.Width - 130, 5)
                    End If

                    If InMapEditor Then
                        EditorMap_DrawTileset()
                    End If
                End SyncLock
            End If

            Application.DoEvents()
            System.Threading.Thread.Sleep(1)
        Loop
    End Sub
    Public Sub CheckAttack()
        Dim Buffer As ByteBuffer
        Dim attackspeed As Long

        If VbKeyControl Then

            If SpellBuffer > 0 Then Exit Sub ' currently casting a spell, can't attack
            If StunDuration > 0 Then Exit Sub ' stunned, can't attack

            ' speed from weapon
            If GetPlayerEquipment(MyIndex, Equipment.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(MyIndex, Equipment.Weapon)).Speed
            Else
                attackspeed = 1000
            End If

            If Player(MyIndex).AttackTimer + attackspeed < GetTickCount() Then
                If Player(MyIndex).Attacking = 0 Then

                    With Player(MyIndex)
                        .Attacking = 1
                        .AttackTimer = GetTickCount()
                    End With

                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ClientPackets.CAttack)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                End If
            End If
        End If

    End Sub
    Sub ClearTempTile()
        Dim X As Long
        Dim Y As Long
        ReDim TempTile(0 To Map.MaxX, 0 To Map.MaxY)

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                TempTile(X, Y).DoorOpen = 0
            Next
        Next

    End Sub
    Sub CheckMovement()

        If IsTryingToMove() Then
            If CanMove() Then

                ' Check if player has the shift key down for running
                If VbKeyShift Then
                    Player(MyIndex).Moving = MOVING_RUNNING
                Else
                    Player(MyIndex).Moving = MOVING_WALKING
                End If

                Select Case GetPlayerDir(MyIndex)
                    Case DIR_UP
                        Call SendPlayerMove()
                        Player(MyIndex).YOffset = PIC_Y
                        Call SetPlayerY(MyIndex, GetPlayerY(MyIndex) - 1)
                    Case DIR_DOWN
                        Call SendPlayerMove()
                        Player(MyIndex).YOffset = PIC_Y * -1
                        Call SetPlayerY(MyIndex, GetPlayerY(MyIndex) + 1)
                    Case DIR_LEFT
                        Call SendPlayerMove()
                        Player(MyIndex).XOffset = PIC_X
                        Call SetPlayerX(MyIndex, GetPlayerX(MyIndex) - 1)
                    Case DIR_RIGHT
                        Call SendPlayerMove()
                        Player(MyIndex).XOffset = PIC_X * -1
                        Call SetPlayerX(MyIndex, GetPlayerX(MyIndex) + 1)
                End Select

                If Player(MyIndex).XOffset = 0 Then
                    If Player(MyIndex).YOffset = 0 Then
                        If Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).Type = TILE_TYPE_WARP Then
                            GettingMap = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Function IsTryingToMove() As Boolean

        If DirUp Or DirDown Or DirLeft Or DirRight Then
            IsTryingToMove = True
        End If

    End Function

    Function CanMove() As Boolean
        Dim d As Long
        CanMove = True

        ' Make sure they aren't trying to move when they are already moving
        If Player(MyIndex).Moving <> 0 Then
            CanMove = False
            Exit Function
        End If

        ' Make sure they haven't just casted a spell
        If SpellBuffer > 0 Then
            CanMove = False
            Exit Function
        End If

        ' make sure they're not stunned
        If StunDuration > 0 Then
            CanMove = False
            Exit Function
        End If

        ' make sure they're not in a shop
        If InShop > 0 Then
            CanMove = False
            Exit Function
        End If

        If InTrade Then
            CanMove = False
            Exit Function
        End If

        ' not in bank
        If InBank Then
            CanMove = False
            Exit Function
        End If

        d = GetPlayerDir(MyIndex)

        If DirUp Then
            Call SetPlayerDir(MyIndex, DIR_UP)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerY(MyIndex) > 0 Then
                If CheckDirection(DIR_UP) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_UP Then
                        Call SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Up > 0 Then
                    Call MapEditorLeaveMap()
                    Call SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirDown Then
            Call SetPlayerDir(MyIndex, DIR_DOWN)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerY(MyIndex) < Map.MaxY Then
                If CheckDirection(DIR_DOWN) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_DOWN Then
                        Call SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Down > 0 Then
                    Call MapEditorLeaveMap()
                    Call SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirLeft Then
            Call SetPlayerDir(MyIndex, DIR_LEFT)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerX(MyIndex) > 0 Then
                If CheckDirection(DIR_LEFT) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_LEFT Then
                        Call SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Left > 0 Then
                    Call MapEditorLeaveMap()
                    Call SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirRight Then
            Call SetPlayerDir(MyIndex, DIR_RIGHT)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerX(MyIndex) < Map.MaxX Then
                If CheckDirection(DIR_RIGHT) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_RIGHT Then
                        Call SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Right > 0 Then
                    Call MapEditorLeaveMap()
                    Call SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

    End Function

    Function CheckDirection(ByVal Direction As Byte) As Boolean
        Dim X As Long
        Dim Y As Long
        Dim i As Long
        CheckDirection = False

        ' check directional blocking
        If isDirBlocked(Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).DirBlock, Direction + 1) Then
            CheckDirection = True
            Exit Function
        End If

        Select Case Direction
            Case DIR_UP
                X = GetPlayerX(MyIndex)
                Y = GetPlayerY(MyIndex) - 1
            Case DIR_DOWN
                X = GetPlayerX(MyIndex)
                Y = GetPlayerY(MyIndex) + 1
            Case DIR_LEFT
                X = GetPlayerX(MyIndex) - 1
                Y = GetPlayerY(MyIndex)
            Case DIR_RIGHT
                X = GetPlayerX(MyIndex) + 1
                Y = GetPlayerY(MyIndex)
        End Select

        ' Check to see if the map tile is blocked or not
        If Map.Tile(X, Y).Type = TILE_TYPE_BLOCKED Then
            CheckDirection = True
            Exit Function
        End If

        ' Check to see if the map tile is tree or not
        If Map.Tile(X, Y).Type = TILE_TYPE_RESOURCE Then
            CheckDirection = True
            Exit Function
        End If

        ' Check to see if the key door is open or not
        If Map.Tile(X, Y).Type = TILE_TYPE_KEY Then

            ' This actually checks if its open or not
            If TempTile(X, Y).DoorOpen = NO Then
                CheckDirection = True
                Exit Function
            End If
        End If

        ' Check to see if a player is already on that tile
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                If GetPlayerX(i) = X Then
                    If GetPlayerY(i) = Y Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If
        Next i

        ' Check to see if a npc is already on that tile
        For i = 1 To MAX_MAP_NPCS

            If MapNpc(i).Num > 0 Then
                If MapNpc(i).X = X Then
                    If MapNpc(i).Y = Y Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function
    Sub ProcessMovement(ByVal Index As Long)
        Dim MovementSpeed As Long

        ' Check if player is walking, and if so process moving them over
        Select Case Player(Index).Moving
            Case MOVING_WALKING : MovementSpeed = ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
            Case MOVING_RUNNING : MovementSpeed = ((ElapsedTime / 1000) * (RUN_SPEED * SIZE_X))
            Case Else : Exit Sub
        End Select

        Select Case GetPlayerDir(Index)
            Case DIR_UP
                Player(Index).YOffset = Player(Index).YOffset - MovementSpeed
                If Player(Index).YOffset < 0 Then Player(Index).YOffset = 0
            Case DIR_DOWN
                Player(Index).YOffset = Player(Index).YOffset + MovementSpeed
                If Player(Index).YOffset > 0 Then Player(Index).YOffset = 0
            Case DIR_LEFT
                Player(Index).XOffset = Player(Index).XOffset - MovementSpeed
                If Player(Index).XOffset < 0 Then Player(Index).XOffset = 0
            Case DIR_RIGHT
                Player(Index).XOffset = Player(Index).XOffset + MovementSpeed
                If Player(Index).XOffset > 0 Then Player(Index).XOffset = 0
        End Select

        ' Check if completed walking over to the next tile
        If Player(Index).Moving > 0 Then
            If GetPlayerDir(Index) = DIR_RIGHT Or GetPlayerDir(Index) = DIR_DOWN Then
                If (Player(Index).XOffset >= 0) And (Player(Index).YOffset >= 0) Then
                    Player(Index).Moving = 0
                    Player(Index).Steps = Player(Index).Steps + 1
                    If Player(Index).Steps = 4 Then Player(Index).Steps = 0
                End If
            Else
                If (Player(Index).XOffset <= 0) And (Player(Index).YOffset <= 0) Then
                    Player(Index).Moving = 0
                    Player(Index).Steps = Player(Index).Steps + 1
                    If Player(Index).Steps = 4 Then Player(Index).Steps = 0
                End If
            End If
        End If

    End Sub
    Sub ProcessNpcMovement(ByVal MapNpcNum As Long)

        ' Check if NPC is walking, and if so process moving them over
        If MapNpc(MapNpcNum).Moving = MOVING_WALKING Then

            Select Case MapNpc(MapNpcNum).Dir
                Case DIR_UP
                    MapNpc(MapNpcNum).YOffset = MapNpc(MapNpcNum).YOffset - ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).YOffset < 0 Then MapNpc(MapNpcNum).YOffset = 0

                Case DIR_DOWN
                    MapNpc(MapNpcNum).YOffset = MapNpc(MapNpcNum).YOffset + ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).YOffset > 0 Then MapNpc(MapNpcNum).YOffset = 0

                Case DIR_LEFT
                    MapNpc(MapNpcNum).XOffset = MapNpc(MapNpcNum).XOffset - ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).XOffset < 0 Then MapNpc(MapNpcNum).XOffset = 0

                Case DIR_RIGHT
                    MapNpc(MapNpcNum).XOffset = MapNpc(MapNpcNum).XOffset + ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).XOffset > 0 Then MapNpc(MapNpcNum).XOffset = 0

            End Select

            ' Check if completed walking over to the next tile
            If MapNpc(MapNpcNum).Moving > 0 Then
                If MapNpc(MapNpcNum).Dir = DIR_RIGHT Or MapNpc(MapNpcNum).Dir = DIR_DOWN Then
                    If (MapNpc(MapNpcNum).XOffset >= 0) And (MapNpc(MapNpcNum).YOffset >= 0) Then
                        MapNpc(MapNpcNum).Moving = 0
                        MapNpc(MapNpcNum).Steps = MapNpc(MapNpcNum).Steps + 1
                        If MapNpc(MapNpcNum).Steps = 4 Then MapNpc(MapNpcNum).Steps = 0
                    End If
                Else
                    If (MapNpc(MapNpcNum).XOffset <= 0) And (MapNpc(MapNpcNum).YOffset <= 0) Then
                        MapNpc(MapNpcNum).Moving = 0
                        MapNpc(MapNpcNum).Steps = MapNpc(MapNpcNum).Steps + 1
                        If MapNpc(MapNpcNum).Steps = 4 Then MapNpc(MapNpcNum).Steps = 0
                    End If
                End If
            End If
        End If
    End Sub
    Function GetPlayerDir(ByVal Index As Long) As Long

        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerDir = Player(Index).Dir
    End Function
    Sub DrawPing()
        Dim PingToDraw As String
        PingToDraw = Ping

        Select Case Ping
            Case -1
                PingToDraw = "Syncing"
            Case 0 To 5
                PingToDraw = "Local"
        End Select

        frmMainGame.lblPing.Text = PingToDraw
    End Sub
    Public Function isInBounds()
        isInBounds = False
        If (CurX >= 0) Then
            If (CurX <= Map.MaxX) Then
                If (CurY >= 0) Then
                    If (CurY <= Map.MaxY) Then
                        isInBounds = True
                    End If
                End If
            End If
        End If

    End Function
    Function GameStarted() As Boolean
        GameStarted = False
        If InGame = False Then Exit Function
        If MapData = False Then Exit Function
        If PlayerData = False Then Exit Function
        GameStarted = True
        frmloadvisible = False
    End Function
    Public Sub CreateActionMsg(ByVal message As String, ByVal color As Integer, ByVal MsgType As Byte, ByVal X As Long, ByVal Y As Long)

        ActionMsgIndex = ActionMsgIndex + 1
        If ActionMsgIndex >= MAX_BYTE Then ActionMsgIndex = 1

        With ActionMsg(ActionMsgIndex)
            .message = message
            .color = color
            .Type = MsgType
            .Created = GetTickCount()
            .Scroll = 1
            .X = X
            .Y = Y
        End With

        If ActionMsg(ActionMsgIndex).Type = ACTIONMSG_SCROLL Then
            ActionMsg(ActionMsgIndex).Y = ActionMsg(ActionMsgIndex).Y + Rand(-2, 6)
            ActionMsg(ActionMsgIndex).X = ActionMsg(ActionMsgIndex).X + Rand(-8, 8)
        End If

    End Sub
    Public Function Rand(ByVal MaxNumber As Integer, _
    Optional ByVal MinNumber As Integer = 0) As Integer

        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return r.Next(MinNumber, MaxNumber)

    End Function
    ' BitWise Operators for directional blocking
    Public Sub setDirBlock(ByRef blockvar As Byte, ByRef Dir As Byte, ByVal block As Boolean)
        If block Then
            blockvar = blockvar Or (2 ^ Dir)
        Else
            blockvar = blockvar And Not (2 ^ Dir)
        End If
    End Sub
    Public Function isDirBlocked(ByRef blockvar As Byte, ByRef Dir As Byte) As Boolean
        If Not blockvar And (2 ^ Dir) Then
            isDirBlocked = False
        Else
            isDirBlocked = True
        End If
    End Function
    Sub UpdateUI()
        If ReloadFrmMain = True Then
            ReloadFrmMain = False
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

        If txtChatAdd <> frmMainGame.txtChat.Text Then
            frmMainGame.txtChat.Text = txtChatAdd
            frmMainGame.txtChat.SelectionStart = frmMainGame.txtChat.TextLength
            frmMainGame.txtChat.ScrollToCaret()
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
        End If

        If NeedToOpenBank = True Then
            InBank = True
            frmMainGame.pnlBank.Visible = True
            DrawBank()
            NeedToOpenBank = False
        End If

        If NeedToOpenTrade = True Then
            InTrade = True
            frmMainGame.pnlTrade.Visible = True
            frmMainGame.lblTheirOffer.Text = Tradername & "'s offer."
            DrawTrade()
            NeedToOpenTrade = False
        End If

        If NeedtoCloseTrade = True Then
            InTrade = False
            frmMainGame.pnlTrade.Visible = False
            frmMainGame.lblTradeStatus.Text = vbNullString
            NeedtoCloseTrade = False
        End If

        If UpdateCharacterPanel = True Then
            ' Set the character windows
            frmMainGame.lblCharName.Text = GetPlayerName(MyIndex)
            frmMainGame.lblCharLevel.Text = GetPlayerLevel(MyIndex)
            frmMainGame.lblCharPoints.Text = GetPlayerPOINTS(MyIndex)

            frmMainGame.lblCharStr.Text = GetPlayerStat(MyIndex, Stats.strength)
            frmMainGame.lblCharEnd.Text = GetPlayerStat(MyIndex, Stats.endurance)
            frmMainGame.lblCharInt.Text = GetPlayerStat(MyIndex, Stats.intelligence)
            frmMainGame.lblCharVit.Text = GetPlayerStat(MyIndex, Stats.vitality)
            frmMainGame.lblCharWill.Text = GetPlayerStat(MyIndex, Stats.willpower)
            frmMainGame.lblCharSpr.Text = GetPlayerStat(MyIndex, Stats.spirit)


            ' Set training label visiblity depending on points
            If GetPlayerPOINTS(MyIndex) > 0 Then
                frmMainGame.lblTrainStr.Visible = True
                frmMainGame.lblTrainSpr.Visible = True
                frmMainGame.lblTrainEnd.Visible = True
                frmMainGame.lblTrainInt.Visible = True
                frmMainGame.lblTrainVit.Visible = True
                frmMainGame.lblTrainWill.Visible = True
            Else
                frmMainGame.lblTrainStr.Visible = False
                frmMainGame.lblTrainSpr.Visible = False
                frmMainGame.lblTrainEnd.Visible = False
                frmMainGame.lblTrainInt.Visible = False
                frmMainGame.lblTrainVit.Visible = False
                frmMainGame.lblTrainWill.Visible = False
            End If
            UpdateCharacterPanel = False
        End If

        If frmloadvisible <> frmLoad.Visible Then
            frmLoad.Visible = frmloadvisible
        End If
    End Sub
    Public Function ConvertCurrency(ByVal Amount As Long) As String

        If Int(Amount) < 10000 Then
            ConvertCurrency = Amount
        ElseIf Int(Amount) < 999999 Then
            ConvertCurrency = Int(Amount / 1000) & "k"
        ElseIf Int(Amount) < 999999999 Then
            ConvertCurrency = Int(Amount / 1000000) & "m"
        Else
            ConvertCurrency = Int(Amount / 1000000000) & "b"
        End If

    End Function

    Sub HandlePressEnter()
        Dim ChatText As String
        Dim Name As String
        Dim i As Long
        Dim n As Long
        Dim Command() As String
        Dim Buffer As ByteBuffer
        ChatText = Trim$(MyText)
        Name = ""

        If Len(ChatText) = 0 Then Exit Sub
        MyText = LCase$(ChatText)
        ' Broadcast message
        If Left$(ChatText, 1) = "'" Then
            ChatText = Mid$(ChatText, 2, Len(ChatText) - 1)

            If Len(ChatText) > 0 Then
                Call BroadcastMsg(ChatText)
            End If

            MyText = vbNullString
            frmMainGame.txtMeChat.Text = vbNullString
            Exit Sub
        End If

        ' Emote message
        If Left$(ChatText, 1) = "-" Then
            MyText = Mid$(ChatText, 2, Len(ChatText) - 1)

            If Len(ChatText) > 0 Then
                Call EmoteMsg(ChatText)
            End If

            MyText = vbNullString
            frmMainGame.txtMeChat.Text = vbNullString
            Exit Sub
        End If

        ' Player message
        If Left$(ChatText, 1) = "!" Then
            ChatText = Mid$(ChatText, 2, Len(ChatText) - 1)
            Name = vbNullString

            ' Get the desired player from the user text
            For i = 1 To Len(ChatText)

                If Mid$(ChatText, i, 1) <> Space(1) Then
                    Name = Name & Mid$(ChatText, i, 1)
                Else
                    Exit For
                End If

            Next

            MyText = Trim$(Mid$(ChatText, i, Len(ChatText) - 1))

            ' Make sure they are actually sending something
            If Len(MyText) > 0 Then
                ' Send the message to the player
                Call PlayerMsg(MyText, Name)
            Else
                Call AddText("Usage: !playername (message)")
            End If

            MyText = vbNullString
            frmMainGame.txtMeChat.Text = vbNullString
            Exit Sub
        End If

        If Left$(MyText, 1) = "/" Then
            Command = Split(MyText, Space(1))

            Select Case Command(0)
                Case "/help"
                    Call AddText("Social Commands:")
                    Call AddText("'msghere = Broadcast Message")
                    Call AddText("-msghere = Emote Message")
                    Call AddText("!namehere msghere = Player Message")
                    Call AddText("Available Commands: /help, /info, /who, /fps, /stats, /trade, /party, /join, /leave, /resetui")
                Case "/info"

                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText("Usage: /info (name)")
                        GoTo continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /info (name)")
                        GoTo continue1
                    End If

                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ClientPackets.CPlayerInfoRequest)
                    Buffer.WriteString(Command(1))
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                    ' Whos Online
                Case "/who"
                    SendWhosOnline()
                    ' Checking fps
                Case "/fps"
                    BFPS = Not BFPS
                    ' toggle fps lock
                Case "/fpslock"
                    FPS_Lock = Not FPS_Lock
                    ' Request stats
                Case "/stats"
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ClientPackets.CGetStats)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                Case "/party"

                    ' Make sure they are actually sending something
                    If UBound(Command) < 1 Then
                        AddText("Usage: /party (name)")
                        GoTo continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /party (name)")
                        GoTo continue1
                    End If

                    Call SendPartyRequest(Command(1))

                    ' Join party
                Case "/join"
                    SendJoinParty()
                    ' Leave party
                Case "/leave"
                    SendLeaveParty()
                    ' // Monitor Admin Commands //
                    ' Admin Help
                Case "/admin"

                    If GetPlayerAccess(MyIndex) < ADMIN_MONITOR Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    Call AddText("Social Commands:")
                    Call AddText("""msghere = Global Admin Message")
                    Call AddText("=msghere = Private Admin Message")
                    Call AddText("Available Commands: /admin, /loc, /mapeditor, /warpmeto, /warptome, /warpto, /setsprite, /mapreport, /kick, /ban, /edititem, /respawn, /editnpc, /motd, /editshop, /editspell, /debug")
                    ' Kicking a player
                Case "/kick"

                    If GetPlayerAccess(MyIndex) < ADMIN_MONITOR Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /kick (name)")
                        GoTo continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /kick (name)")
                        GoTo continue1
                    End If

                    SendKick(Command(1))
                    ' // Mapper Admin Commands //
                    ' Location
                Case "/loc"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    BLoc = Not BLoc
                    ' Map Editor
                Case "/mapeditor"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditMap()
                    ' Warping to a player
                Case "/warpmeto"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warpmeto (name)")
                        GoTo continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /warpmeto (name)")
                        GoTo continue1
                    End If

                    WarpMeTo(Command(1))
                    ' Warping a player to you
                Case "/warptome"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warptome (name)")
                        GoTo continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /warptome (name)")
                        GoTo continue1
                    End If

                    WarpToMe(Command(1))
                    ' Warping to a map
                Case "/warpto"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warpto (map #)")
                        GoTo continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /warpto (map #)")
                        GoTo continue1
                    End If

                    n = CLng(Command(1))

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_MAPS Then
                        Call WarpTo(n)
                    Else
                        Call AddText("Invalid map number.")
                    End If

                    ' Setting sprite
                Case "/setsprite"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /setsprite (sprite #)")
                        GoTo continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /setsprite (sprite #)")
                        GoTo continue1
                    End If

                    SendSetSprite(CLng(Command(1)))
                    ' Map report
                Case "/mapreport"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    'SendData CMapReport & END_CHAR
                    AddText("Convert this to Byte Array, Robin!")
                    ' Respawn request
                Case "/respawn"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendMapRespawn()
                    ' MOTD change
                Case "/motd"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /motd (new motd)")
                        GoTo continue1
                    End If

                    SendMOTDChange(Right$(ChatText, Len(ChatText) - 5))
                    ' Check the ban list
                Case "/banlist"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendBanList()
                    ' Banning a player
                Case "/ban"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /ban (name)")
                        GoTo continue1
                    End If

                    SendBan(Command(1))
                    ' // Developer Admin Commands //
                    ' Editing item request
                Case "/edititem"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditItem()
                    ' Editing animation request
                Case "/editanimation"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditAnimation()
                    ' Editing npc request
                Case "/editnpc"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditNpc()
                Case "/editresource"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditResource()
                    ' Editing shop request
                Case "/editshop"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditShop()
                    ' Editing spell request
                Case "/editspell"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendRequestEditSpell()
                    ' // Creator Admin Commands //
                    ' Giving another player access
                Case "/setaccess"

                    If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    If UBound(Command) < 2 Then
                        AddText("Usage: /setaccess (name) (access)")
                        GoTo continue1
                    End If

                    If IsNumeric(Command(1)) Or Not IsNumeric(Command(2)) Then
                        AddText("Usage: /setaccess (name) (access)")
                        GoTo continue1
                    End If

                    SendSetAccess(Command(1), CLng(Command(2)))
                    ' Ban destroy
                Case "/destroybanlist"

                    If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    SendBanDestroy()
                    ' Packet debug mode
                Case "/debug"

                    If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
                        AddText("You need to be a high enough staff member to do this!")
                        GoTo continue1
                    End If

                    DEBUG_MODE = (Not DEBUG_MODE)
                Case Else
                    AddText("Not a valid command!")
            End Select

            'continue label where we go instead of exiting the sub
Continue1:
            MyText = vbNullString
            frmMainGame.txtMeChat.Text = vbNullString
            Exit Sub
        End If

        ' Say message
        If Len(ChatText) > 0 Then
            Call SayMsg(ChatText)
        End If

        MyText = vbNullString
        frmMainGame.txtMeChat.Text = vbNullString
    End Sub
    Sub CheckMapGetItem()
        Dim Buffer As New ByteBuffer
        Buffer = New ByteBuffer

        If GetTickCount() > Player(MyIndex).MapGetTimer + 250 Then
            If Trim$(MyText) = vbNullString Then
                Player(MyIndex).MapGetTimer = GetTickCount()
                Buffer.WriteLong(ClientPackets.CMapGetItem)
                SendData(Buffer.ToArray())
            End If
        End If

        Buffer = Nothing
    End Sub
    Public Sub UpdateDescWindow(ByVal itemnum As Long, ByVal Amount As Long, ByVal X As Long, ByVal Y As Long)
        Dim FirstLetter As String
        Dim Name As String

        FirstLetter = LCase$(Left$(Trim$(Item(itemnum).Name), 1))

        If FirstLetter = "$" Then
            Name = (Mid$(Trim$(Item(itemnum).Name), 2, Len(Trim$(Item(itemnum).Name)) - 1))
        Else
            Name = Trim$(Item(itemnum).Name)
        End If

        ' check for off-screen
        If Y + frmMainGame.pnlItemDesc.Height > frmMainGame.Height Then
            Y = frmMainGame.Height - frmMainGame.pnlItemDesc.Height
        End If

        With frmMainGame
            .pnlItemDesc.Top = Y
            .pnlItemDesc.Left = X
            .pnlItemDesc.Visible = True
            .pnlItemDesc.BringToFront()

            If LastItemDesc = itemnum Then Exit Sub ' exit out after setting x + y so we don't reset values

            .lblItemDescName.Font = New System.Drawing.Font("Verdana Bold", 8.25)

            ' set the name
            Select Case Item(itemnum).Rarity
                Case 0 ' black
                    .lblItemDescName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Case 1 ' green
                    .lblItemDescName.ForeColor = System.Drawing.Color.FromArgb(18, 92, 40)
                Case 2 ' blue
                    .lblItemDescName.ForeColor = System.Drawing.Color.FromArgb(31, 37, 118)
                Case 3 ' maroon
                    .lblItemDescName.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0)
                Case 4 ' purple
                    .lblItemDescName.ForeColor = System.Drawing.Color.FromArgb(81, 36, 81)
                Case 5 '
                    .lblItemDescName.ForeColor = System.Drawing.Color.FromArgb(112, 146, 190)
            End Select

            .lblItemDescName.Text = Name

            ' For the stats label
            Select Case Item(itemnum).Type
                Case ITEM_TYPE_NONE
                    .lblItemDescInfo.Text = "N/A"
                Case ITEM_TYPE_WEAPON
                    .lblItemDescInfo.Text = "Damage: " & Item(itemnum).Data2
                Case ITEM_TYPE_ARMOR
                    .lblItemDescInfo.Text = "Defence: " & Item(itemnum).Data2
                Case ITEM_TYPE_HELMET
                    .lblItemDescInfo.Text = "Defence: " & Item(itemnum).Data2
                Case ITEM_TYPE_SHIELD
                    .lblItemDescInfo.Text = "Defence: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONADDHP
                    .lblItemDescInfo.Text = "Restore Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONADDMP
                    .lblItemDescInfo.Text = "Restore Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONADDSP
                    .lblItemDescInfo.Text = "Restore Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONSUBHP
                    .lblItemDescInfo.Text = "Damage Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONSUBMP
                    .lblItemDescInfo.Text = "Damage Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONSUBSP
                    .lblItemDescInfo.Text = "Damage Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_KEY
                    .lblItemDescInfo.Text = "N/A"
                Case ITEM_TYPE_CURRENCY
                    .lblItemDescInfo.Text = "N/A"
                Case ITEM_TYPE_SPELL
                    .lblItemDescInfo.Text = "N/A"
            End Select

            ' Currency
            .lblItemDescCost.Text = Item(itemnum).Price & "g"

            ' If currency, exit out before all the other shit
            If Item(itemnum).Type = ITEM_TYPE_CURRENCY Or Item(itemnum).Type = ITEM_TYPE_NONE Then
                ' Clear other labels
                .lblItemDescLevel.Text = "N/A"
                .lblItemDescSpeed.Text = "N/A"

                .lblItemDescStr.Text = "N/A"
                .lblItemDescEnd.Text = "N/A"
                .lblItemDescInt.Text = "N/A"
                .lblItemDescSpr.Text = "N/A"
                .lblItemDescVit.Text = "N/A"
                .lblItemDescWill.Text = "N/A"
                Exit Sub
            End If

            ' Potions + crap
            .lblItemDescLevel.Text = Item(itemnum).LevelReq

            ' Exit out for everything else 'scept equipment
            If Item(itemnum).Type < ITEM_TYPE_WEAPON Or Item(itemnum).Type > ITEM_TYPE_SHIELD Then
                ' Clear other labels
                .lblItemDescSpeed.Text = "N/A"


                .lblItemDescStr.Text = "N/A"
                .lblItemDescEnd.Text = "N/A"
                .lblItemDescInt.Text = "N/A"
                .lblItemDescSpr.Text = "N/A"
                .lblItemDescVit.Text = "N/A"
                .lblItemDescWill.Text = "N/A"
                Exit Sub
            End If

            ' Equipment specific
            If Item(itemnum).Add_Stat(Stats.strength) > 0 Then
                .lblItemDescStr.Text = "+" & Item(itemnum).Add_Stat(Stats.strength)
            Else
                .lblItemDescStr.Text = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.vitality) > 0 Then
                .lblItemDescVit.Text = "+" & Item(itemnum).Add_Stat(Stats.vitality)
            Else
                .lblItemDescVit.Text = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.intelligence) > 0 Then
                .lblItemDescInt.Text = "+" & Item(itemnum).Add_Stat(Stats.intelligence)
            Else
                .lblItemDescInt.Text = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.endurance) > 0 Then
                .lblItemDescEnd.Text = "+" & Item(itemnum).Add_Stat(Stats.endurance)
            Else
                .lblItemDescEnd.Text = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.willpower) > 0 Then
                .lblItemDescWill.Text = "+" & Item(itemnum).Add_Stat(Stats.willpower)
            Else
                .lblItemDescWill.Text = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.spirit) > 0 Then
                .lblItemDescSpr.Text = "+" & Item(itemnum).Add_Stat(Stats.spirit)
            Else
                .lblItemDescSpr.Text = "None"
            End If




            If Item(itemnum).Type = ITEM_TYPE_WEAPON Then
                .lblItemDescSpeed.Text = Item(itemnum).Speed / 1000 & " secs"
            Else
                .lblItemDescSpeed.Text = "N/A"
            End If

            ' don't need to exit :3
        End With

    End Sub
    Public Sub OpenShop(ByVal shopnum As Long)
        frmMainGame.lblShopName.Text = Trim$(Shop(shopnum).Name)
        InShop = shopnum
        ShopAction = 0
        frmMainGame.pnlShop.Visible = True
        DrawShop()
    End Sub
    Public Function GetBankItemNum(ByVal bankslot As Byte) As Integer
        GetBankItemNum = 0

        If bankslot = 0 Then
            GetBankItemNum = 0
            Exit Function
        End If

        If bankslot > MAX_BANK Then
            GetBankItemNum = 0
            Exit Function
        End If

        GetBankItemNum = Bank.Item(bankslot).Num
    End Function

    Public Sub SetBankItemNum(ByVal bankslot As Byte, ByVal itemnum As Integer)
        Bank.Item(bankslot).Num = itemnum
    End Sub

    Public Function GetBankItemValue(ByVal bankslot As Byte) As Long
        GetBankItemValue = Bank.Item(bankslot).Value
    End Function

    Public Sub SetBankItemValue(ByVal bankslot As Byte, ByVal ItemValue As Long)
        Bank.Item(bankslot).Value = ItemValue
    End Sub
    Public Sub ClearActionMsg(ByVal Index As Byte)
        ActionMsg(Index).message = vbNullString
        ActionMsg(Index).Created = 0
        ActionMsg(Index).Type = 0
        ActionMsg(Index).color = 0
        ActionMsg(Index).Scroll = 0
        ActionMsg(Index).X = 0
        ActionMsg(Index).Y = 0
    End Sub
    Public Sub UpdateSpellWindow(ByVal spellnum As Long, ByVal X As Long, ByVal Y As Long)

        ' check for off-screen
        If Y + frmMainGame.pnlSpellDesc.Height > frmMainGame.Size.Height Then
            Y = frmMainGame.Size.Height - frmMainGame.pnlSpellDesc.Height
        End If

        With frmMainGame
            .pnlSpellDesc.Top = Y
            .pnlSpellDesc.Left = X
            .pnlSpellDesc.Visible = True

            If LastSpellDesc = spellnum Then Exit Sub

            .lblSpellName.Text = Spell(spellnum).Name
            .lblSpellDamage.Visible = True

            Select Case Spell(spellnum).Type
                Case SPELL_TYPE_DAMAGEHP
                    .lblSpellType.Text = "Damage HP"
                    .lblSpellVital.Text = "Damage:"
                Case SPELL_TYPE_DAMAGEMP
                    .lblSpellType.Text = "Damage MP"
                    .lblSpellVital.Text = "Damage:"
                Case SPELL_TYPE_HEALHP
                    .lblSpellType.Text = "Heal HP"
                    .lblSpellVital.Text = "Heal:"
                Case SPELL_TYPE_HEALMP
                    .lblSpellType.Text = "Heal MP"
                    .lblSpellVital.Text = "Heal:"
                Case SPELL_TYPE_WARP
                    .lblSpellType.Text = "Warp"
                    .lblSpellVital.Text = "Empty"
                    .lblSpellDamage.Visible = False
            End Select

            .lblSpellMp.Text = Spell(spellnum).MPCost
            .lblSpellLevel.Text = Spell(spellnum).LevelReq
            .lblSpellAccess.Text = Spell(spellnum).AccessReq
            If Spell(spellnum).ClassReq > 0 Then
                .lblSpellClass.Text = Trim$(Classes(Spell(spellnum).ClassReq).Name)
            Else
                .lblSpellClass.Text = "None"
            End If
            .lblSpellCast.Text = Spell(spellnum).CastTime & "s"
            .lblSpellCool.Text = Spell(spellnum).CDTime & "s"
            .lblSpellDamage.Text = Spell(spellnum).Vital
            If Spell(spellnum).IsAoE Then
                .lblSpellAoE.Text = Spell(spellnum).AoE & " tiles."
            Else
                .lblSpellAoE.Text = "No"
            End If
            If Spell(spellnum).Range > 0 Then
                .lblSpellRange.Text = Spell(spellnum).Range & " tiles."
            Else
                .lblSpellRange.Text = "Self-cast"
            End If
        End With
    End Sub
    Public Sub CastSpell(ByVal spellslot As Long)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If spellslot < 1 Or spellslot > MAX_PLAYER_SPELLS Then
            Exit Sub
        End If

        If SpellCD(spellslot) > 0 Then
            AddText("Spell has not cooled down yet!")
            Exit Sub
        End If

        ' Check if player has enough MP
        If GetPlayerVital(MyIndex, Vitals.MP) < Spell(PlayerSpells(spellslot)).MPCost Then
            Call AddText("Not enough MP to cast " & Trim$(Spell(PlayerSpells(spellslot)).Name) & ".")
            Exit Sub
        End If

        If PlayerSpells(spellslot) > 0 Then
            If GetTickCount() > Player(MyIndex).AttackTimer + 1000 Then
                If Player(MyIndex).Moving = 0 Then
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ClientPackets.CCast)
                    Buffer.WriteLong(spellslot)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                    SpellBuffer = spellslot
                    SpellBufferTimer = GetTickCount()
                Else
                    Call AddText("Cannot cast while walking!")
                End If
            End If
        Else
            Call AddText("No spell here.")
        End If

    End Sub
    Public Sub CheckAnimInstance(ByVal Index As Long)
        Dim looptime As Long
        Dim Layer As Long
        Dim FrameCount As Long

        ' if doesn't exist then exit sub
        If AnimInstance(Index).Animation <= 0 Then Exit Sub
        If AnimInstance(Index).Animation >= MAX_ANIMATIONS Then Exit Sub

        For Layer = 0 To 1
            If AnimInstance(Index).Used(Layer) Then
                looptime = Animation(AnimInstance(Index).Animation).looptime(Layer)
                FrameCount = Animation(AnimInstance(Index).Animation).Frames(Layer)

                ' if zero'd then set so we don't have extra loop and/or frame
                If AnimInstance(Index).FrameIndex(Layer) = 0 Then AnimInstance(Index).FrameIndex(Layer) = 1
                If AnimInstance(Index).LoopIndex(Layer) = 0 Then AnimInstance(Index).LoopIndex(Layer) = 1

                ' check if frame timer is set, and needs to have a frame change
                If AnimInstance(Index).Timer(Layer) + looptime <= GetTickCount() Then
                    ' check if out of range
                    If AnimInstance(Index).FrameIndex(Layer) >= FrameCount Then
                        AnimInstance(Index).LoopIndex(Layer) = AnimInstance(Index).LoopIndex(Layer) + 1
                        If AnimInstance(Index).LoopIndex(Layer) > Animation(AnimInstance(Index).Animation).LoopCount(Layer) Then
                            AnimInstance(Index).Used(Layer) = False
                        Else
                            AnimInstance(Index).FrameIndex(Layer) = 1
                        End If
                    Else
                        AnimInstance(Index).FrameIndex(Layer) = AnimInstance(Index).FrameIndex(Layer) + 1
                    End If
                    AnimInstance(Index).Timer(Layer) = GetTickCount()
                End If
            End If
        Next

        ' if neither layer is used, clear
        If AnimInstance(Index).Used(0) = False And AnimInstance(Index).Used(1) = False Then ClearAnimInstance(Index)
    End Sub
    Sub PlayMusic(ByVal filename As String)
        If Not Options.Music = 1 Or Not FileExist(Application.StartupPath & MUSIC_PATH & filename) Then Exit Sub
        If MusicPlayer Is Nothing Then
            Try
                MusicPlayer = New Music(Application.StartupPath & MUSIC_PATH & filename)
                MusicPlayer.Play()
            Catch ex As Exception

            End Try
        Else
            Try
                MusicPlayer.Stop()
                MusicPlayer.Dispose()
                MusicPlayer = Nothing
                MusicPlayer = New Music(Application.StartupPath & MUSIC_PATH & filename)
                MusicPlayer.Play()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub StopMusic()
        If MusicPlayer Is Nothing Then Exit Sub
        MusicPlayer.Stop()
        MusicPlayer.Dispose()
        MusicPlayer = Nothing
    End Sub
    Sub PlaySound(ByVal filename As String)
        If Not Options.Sound = 1 Or Not FileExist(Application.StartupPath & SOUND_PATH & filename) Then Exit Sub
        Dim buffer As SoundBuffer
        If SoundPlayer Is Nothing Then
            SoundPlayer = New Sound()
            buffer = New SoundBuffer(Application.StartupPath & SOUND_PATH & filename)
            SoundPlayer.SoundBuffer = buffer
            SoundPlayer.Play()
        Else
            SoundPlayer.Stop()
            buffer = New SoundBuffer(Application.StartupPath & SOUND_PATH & filename)
            SoundPlayer.SoundBuffer = buffer
            SoundPlayer.Play()
        End If
    End Sub
    Sub StopSound()
        If SoundPlayer Is Nothing Then Exit Sub
        SoundPlayer.Dispose()
        SoundPlayer = Nothing
    End Sub
    Public Sub UpdateDrawMapName()
        Dim g As Graphics = Graphics.FromImage(TempBitmap)
        Dim width As Long
        width = g.MeasureString(Trim$(Map.Name), New System.Drawing.Font(FONT_NAME, CSng(FONT_SIZE), FontStyle.Bold, GraphicsUnit.Pixel)).Width
        DrawMapNameX = ((MAX_MAPX + 1) * PIC_X / 2) - width + 32
        DrawMapNameY = 1

        Select Case Map.Moral
            Case MAP_MORAL_NONE
                DrawMapNameColor = SFML.Graphics.Color.Red
            Case MAP_MORAL_SAFE
                DrawMapNameColor = SFML.Graphics.Color.White
            Case Else
                DrawMapNameColor = SFML.Graphics.Color.White
        End Select
        g.Dispose()
    End Sub
End Module
