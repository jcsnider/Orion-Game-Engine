Imports System.Drawing
Imports System.Windows.Forms

Module ClientGameLogic
    Sub GameLoop()
        Dim i As Long
        Dim dest As Point = New Point(frmMainGame.PointToScreen(frmMainGame.picscreen.Location))
        Dim g As Graphics = frmMainGame.picscreen.CreateGraphics
        Dim starttime As Long, Tick As Long
        Dim tmpfps As Long, WalkTimer As Long, FrameTime As Long
        Dim destrect As Rectangle, tmr10000 As Long
        Dim tmr1000 As Long, tmr100 As Long, tmr500 As Long

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
                ElapsedTime = Tick - FrameTime ' Set the time difference for time-based movement

                FrameTime = Tick
                frmmaingamevisible = True

                If GetTickCount() - starttime >= 1000 Then
                    FPS = tmpfps
                    tmpfps = 0
                    starttime = GetTickCount()
                Else
                    tmpfps = tmpfps + 1
                End If

                ' Update inv animation
                If NumItems > 0 Then
                    If tmr100 < Tick Then

                        If InBank Then DrawBank()
                        If InShop Then DrawShop()
                        If InTrade Then DrawTrade()

                        tmr100 = Tick + 100
                    End If
                End If

                For i = 1 To MAX_BYTE
                    CheckAnimInstance(i)
                Next

                If Tick > EventChatTimer Then
                    If EventText = "" Then
                        If EventChat = True Then
                            EventChat = False
                            frmMainGame.pnlEventChat.Visible = False
                        End If
                    End If
                End If

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
                        AddText("You took too long to decide. Please try again.", Yellow)
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
                        CheckMovement() ' Check if player is trying to move
                        CheckAttack()   ' Check to see if player is trying to attack
                    End If

                    ' Process input before rendering, otherwise input will be behind by 1 frame
                    If WalkTimer < Tick Then

                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                ProcessMovement(i)
                            End If
                        Next i

                        ' Process npc movements (actually move them)
                        For i = 1 To MAX_MAP_NPCS
                            If Map.Npc(i) > 0 Then
                                ProcessNpcMovement(i)
                            End If
                        Next i

                        If Map.CurrentEvents > 0 Then
                            For i = 1 To Map.CurrentEvents
                                ProcessEventMovement(i)
                            Next i
                        End If

                        WalkTimer = Tick + 30 ' edit this value to change WalkTimer
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

                    If GettingMap Then
                        g.DrawString("Receiving Map", New Font(FONT_NAME, FONT_SIZE), Brushes.DarkCyan, frmMainGame.picscreen.Width - 130, 5)
                    End If

                    If InMapEditor Then
                        EditorMap_DrawTileset()
                    End If
                End SyncLock
            End If

            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Loop
    End Sub

    Public Sub CheckAttack()
        Dim attackspeed As Long, X As Long, Y As Long
        Dim Buffer As ByteBuffer

        If VbKeyControl Then
            If InEvent = True Then Exit Sub
            If SpellBuffer > 0 Then Exit Sub ' currently casting a spell, can't attack
            If StunDuration > 0 Then Exit Sub ' stunned, can't attack

            ' speed from weapon
            If GetPlayerEquipment(MyIndex, Equipment.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(MyIndex, Equipment.Weapon)).Speed * 1000
            Else
                attackspeed = 1000
            End If

            If Player(MyIndex).AttackTimer + attackspeed < GetTickCount() Then
                If Player(MyIndex).Attacking = 0 Then

                    With Player(MyIndex)
                        .Attacking = 1
                        .AttackTimer = GetTickCount()
                    End With

                    SendAttack()
                End If
            End If

            Select Case Player(MyIndex).Dir
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

            If GetTickCount() > Player(MyIndex).EventTimer Then
                For i = 1 To Map.CurrentEvents
                    If Map.MapEvents(i).Visible = 1 Then
                        If Map.MapEvents(i).X = X And Map.MapEvents(i).Y = Y Then
                            Buffer = New ByteBuffer
                            Buffer.WriteLong(ClientPackets.CEvent)
                            Buffer.WriteLong(i)
                            SendData(Buffer.ToArray)
                            Buffer = Nothing
                            Player(MyIndex).EventTimer = GetTickCount() + 200
                        End If
                    End If
                Next
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

        If InEvent Then
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
        Dim X As Long, Y As Long
        Dim i As Long, z As Long
        Dim Buffer As ByteBuffer

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

        If FurnitureHouse > 0 Then
            If FurnitureHouse = Player(MyIndex).InHouse Then
                If FurnitureCount > 0 Then
                    For i = 1 To FurnitureCount
                        If Item(Furniture(i).ItemNum).Data3 = 0 Then
                            If X >= Furniture(i).X And X <= Furniture(i).X + Item(Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                If Y <= Furniture(i).Y And Y >= Furniture(i).Y - Item(Furniture(i).ItemNum).FurnitureHeight Then
                                    z = Item(Furniture(i).ItemNum).FurnitureBlocks(X - Furniture(i).X, ((Furniture(i).Y - Y) * -1) + Item(Furniture(i).ItemNum).FurnitureHeight)
                                    If z = 1 Then CheckDirection = True : Exit Function
                                End If
                            End If
                        End If
                    Next
                End If
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

        For i = 1 To Map.CurrentEvents
            If Map.MapEvents(i).Visible = 1 Then
                If Map.MapEvents(i).X = X Then
                    If Map.MapEvents(i).Y = Y Then
                        'We are walking on top of OR tried to touch an event. Time to Handle the commands
                        Buffer = New ByteBuffer
                        Buffer.WriteLong(ClientPackets.CEventTouch)
                        Buffer.WriteLong(i)
                        SendData(Buffer.ToArray)
                        Buffer = Nothing
                        If Map.MapEvents(i).WalkThrough = 0 Then
                            CheckDirection = True
                            Exit Function
                        End If
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
                    If Player(Index).Steps = 1 Then
                        Player(Index).Steps = 3
                    Else
                        Player(Index).Steps = 1
                    End If
                End If
            Else
                If (Player(Index).XOffset <= 0) And (Player(Index).YOffset <= 0) Then
                    Player(Index).Moving = 0
                    If Player(Index).Steps = 1 Then
                        Player(Index).Steps = 3
                    Else
                        Player(Index).Steps = 1
                    End If
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
                        If MapNpc(MapNpcNum).Steps = 1 Then
                            MapNpc(MapNpcNum).Steps = 3
                        Else
                            MapNpc(MapNpcNum).Steps = 1
                        End If
                    End If
                Else
                    If (MapNpc(MapNpcNum).XOffset <= 0) And (MapNpc(MapNpcNum).YOffset <= 0) Then
                        MapNpc(MapNpcNum).Moving = 0
                        If MapNpc(MapNpcNum).Steps = 1 Then
                            MapNpc(MapNpcNum).Steps = 3
                        Else
                            MapNpc(MapNpcNum).Steps = 1
                        End If
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

        PingToDraw = Ping

        Select Case Ping
            Case -1
                PingToDraw = "Sync"
            Case 0 To 5
                PingToDraw = "Local"
        End Select

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

    Public Function Rand(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer

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
            frmMainGame.lblQuestNameVisual.Text = Trim$(Quest(QuestNum).Name)
            frmMainGame.lblQuestSay.Text = QuestMessage

            frmMainGame.lblQuestAccept.Visible = False

            If QuestNumForStart > 0 And QuestNumForStart <= MAX_QUESTS Then
                frmMainGame.lblQuestAccept.Visible = True
                frmMainGame.lblQuestAccept.Tag = QuestNumForStart
            End If
            frmMainGame.pnlQuestSpeech.Visible = True

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

                DialogPanelVisible = True
            ElseIf DialogType = DIALOGUE_TYPE_PARTY Then
                DialogPanelVisible = True
            End If

            UpdateDialog = False
        End If

        If HideGui = True Then

            HideGui = False
        End If

        If ShakeTimer = True Then
            frmMainGame.tmrShake.Enabled = True
            ShakeTimer = False
        End If

        If EventChat = True Then
            DrawEventChat()
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

        If EventChat = True Then
            If EventChatType = 0 Then
                Buffer = New ByteBuffer
                Buffer.WriteLong(ClientPackets.CEventChatReply)
                Buffer.WriteLong(EventReplyID)
                Buffer.WriteLong(EventReplyPage)
                Buffer.WriteLong(0)
                SendData(Buffer.ToArray)
                Buffer = Nothing
                ClearEventChat()
                InEvent = False
                Exit Sub
            End If
        End If

        ' Broadcast message
        If Left$(ChatText, 1) = "'" Then
            ChatText = Mid$(ChatText, 2, Len(ChatText) - 1)

            If Len(ChatText) > 0 Then
                BroadcastMsg(ChatText)
            End If

            MyText = vbNullString
            Exit Sub
        End If

        ' Emote message
        If Left$(ChatText, 1) = "-" Then
            MyText = Mid$(ChatText, 2, Len(ChatText) - 1)

            If Len(ChatText) > 0 Then
                EmoteMsg(ChatText)
            End If

            MyText = vbNullString
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
                PlayerMsg(MyText, Name)
            Else
                AddText("Usage: !playername (message)", Yellow)
            End If

            MyText = vbNullString
            Exit Sub
        End If

        If Left$(MyText, 1) = "/" Then
            Command = Split(MyText, Space(1))

            Select Case Command(0)
                Case "/help"
                    AddText("Social Commands:", Yellow)
                    AddText("'msghere = Broadcast Message", Yellow)
                    AddText("-msghere = Emote Message", Yellow)
                    AddText("!namehere msghere = Player Message", Yellow)
                    AddText("Available Commands: /help, /info, /who, /fps, /stats, /trade, /party, /join, /leave, /resetui, /sellhouse", Yellow)
                Case "/sellhouse"
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ClientPackets.CSellHouse)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                Case "/info"

                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText("Usage: /info (name)", Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /info (name)", Yellow)
                        GoTo Continue1
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
                        AddText("Usage: /party (name)", Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /party (name)", Yellow)
                        GoTo Continue1
                    End If

                    SendPartyRequest(Command(1))

                ' Join party
                Case "/join"
                    SendJoinParty()
                ' Leave party
                Case "/leave"
                    SendLeaveParty()
                ' // Monitor Admin Commands //

                Case "/questreset"
                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /questreset (quest #)", Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /questreset (quest #)", Yellow)
                        GoTo Continue1
                    End If

                    n = Command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_QUESTS Then
                        QuestReset(n)
                    Else
                        AddText("Invalid quest number.", AlertColor)
                    End If

                ' Admin Help
                Case "/admin"

                    If GetPlayerAccess(MyIndex) < ADMIN_MONITOR Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    AddText("Social Commands:", Yellow)
                    AddText("""msghere = Global Admin Message", Yellow)
                    AddText("=msghere = Private Admin Message", Yellow)
                    AddText("Available Commands: /admin, /loc, /mapeditor, /warpmeto, /warptome, /warpto, /setsprite, /mapreport, /kick, /ban, /edititem, /respawn, /editnpc, /motd, /editshop, /editspell, /debug, /questreset", Yellow)
                ' Kicking a player
                Case "/kick"

                    If GetPlayerAccess(MyIndex) < ADMIN_MONITOR Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /kick (name)", Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /kick (name)", Yellow)
                        GoTo Continue1
                    End If

                    SendKick(Command(1))
                ' // Mapper Admin Commands //
                ' Location
                Case "/loc"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    BLoc = Not BLoc
                ' Map Editor
                Case "/mapeditor"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditMap()
                ' Warping to a player
                Case "/warpmeto"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warpmeto (name)", Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /warpmeto (name)", Yellow)
                        GoTo Continue1
                    End If

                    WarpMeTo(Command(1))
                ' Warping a player to you
                Case "/warptome"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warptome (name)", Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /warptome (name)", Yellow)
                        GoTo Continue1
                    End If

                    WarpToMe(Command(1))
                ' Warping to a map
                Case "/warpto"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warpto (map #)", Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /warpto (map #)", Yellow)
                        GoTo Continue1
                    End If

                    n = Command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_MAPS Then
                        WarpTo(n)
                    Else
                        AddText("Invalid map number.", AlertColor)
                    End If

                ' Setting sprite
                Case "/setsprite"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /setsprite (sprite #)", Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /setsprite (sprite #)", Yellow)
                        GoTo Continue1
                    End If

                    SendSetSprite(Command(1))
                ' Map report
                Case "/mapreport"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestMapreport()
                ' Respawn request
                Case "/respawn"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendMapRespawn()
                ' MOTD change
                Case "/motd"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /motd (new motd)", Yellow)
                        GoTo Continue1
                    End If

                    SendMOTDChange(Right$(ChatText, Len(ChatText) - 5))
                ' Check the ban list
                Case "/banlist"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendBanList()
                ' Banning a player
                Case "/ban"

                    If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /ban (name)", Yellow)
                        GoTo Continue1
                    End If

                    SendBan(Command(1))
                ' // Developer Admin Commands //
                ' Editing item request
                Case "/edititem"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditItem()
                ' Editing animation request
                Case "/editanimation"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditAnimation()
                ' Editing npc request
                Case "/editnpc"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditNpc()
                Case "/editresource"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditResource()
                ' Editing shop request
                Case "/editshop"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditShop()
                ' Editing spell request
                Case "/editspell"

                    If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditSpell()
                ' // Creator Admin Commands //
                ' Giving another player access
                Case "/setaccess"

                    If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 2 Then
                        AddText("Usage: /setaccess (name) (access)", Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Or Not IsNumeric(Command(2)) Then
                        AddText("Usage: /setaccess (name) (access)", Yellow)
                        GoTo Continue1
                    End If

                    SendSetAccess(Command(1), CLng(Command(2)))
                ' Ban destroy
                Case "/destroybanlist"

                    If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    SendBanDestroy()
                ' Packet debug mode
                Case "/debug"

                    If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
                        AddText("You need to be a high enough staff member to do this!", AlertColor)
                        GoTo Continue1
                    End If

                    DEBUG_MODE = (Not DEBUG_MODE)
                Case Else
                    AddText("Not a valid command!", AlertColor)
            End Select

            'continue label where we go instead of exiting the sub
Continue1:
            MyText = vbNullString
            Exit Sub
        End If

        ' Say message
        If Len(ChatText) > 0 Then
            Call SayMsg(ChatText)
        End If

        MyText = vbNullString
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

    Public Sub UpdateDescWindow(ByVal itemnum As Long, ByVal Amount As Long)
        Dim FirstLetter As String

        FirstLetter = LCase$(Left$(Trim$(Item(itemnum).Name), 1))

        If FirstLetter = "$" Then
            ItemDescName = (Mid$(Trim$(Item(itemnum).Name), 2, Len(Trim$(Item(itemnum).Name)) - 1))
        Else
            ItemDescName = Trim$(Item(itemnum).Name)
        End If

        ItemDescItemNum = itemnum


        If LastItemDesc = itemnum Then Exit Sub

            ' set the name
            Select Case Item(itemnum).Rarity
                Case 0 ' White
                    ItemDescRarityColor = ITEM_RARITY_COLOR_0
                Case 1 ' green
                    ItemDescRarityColor = ITEM_RARITY_COLOR_1
                Case 2 ' blue
                    ItemDescRarityColor = ITEM_RARITY_COLOR_2
                Case 3 ' maroon
                    ItemDescRarityColor = ITEM_RARITY_COLOR_3
                Case 4 ' purple
                    ItemDescRarityColor = ITEM_RARITY_COLOR_4
                Case 5 'gold
                    ItemDescRarityColor = ITEM_RARITY_COLOR_5
            End Select

            ' For the stats label
            Select Case Item(itemnum).Type
                Case ITEM_TYPE_NONE
                    ItemDescInfo = "N/A"
                    ItemDescType = "N/A"
                Case ITEM_TYPE_WEAPON
                    ItemDescInfo = "Damage: " & Item(itemnum).Data2
                    ItemDescType = "Weapon"
                Case ITEM_TYPE_ARMOR
                    ItemDescInfo = "Defence: " & Item(itemnum).Data2
                    ItemDescType = "Armor"
                Case ITEM_TYPE_HELMET
                    ItemDescInfo = "Defence: " & Item(itemnum).Data2
                    ItemDescType = "Helmet"
                Case ITEM_TYPE_SHIELD
                    ItemDescInfo = "Defence: " & Item(itemnum).Data2
                    ItemDescType = "Shield"
                Case ITEM_TYPE_SHOES
                    ItemDescInfo = "Defence: " & Item(itemnum).Data2
                    ItemDescType = "Shoes"
                Case ITEM_TYPE_GLOVES
                    ItemDescInfo = "Defence: " & Item(itemnum).Data2
                    ItemDescType = "Gloves"
                Case ITEM_TYPE_POTIONADDHP
                    ItemDescInfo = "Restore Amount: " & Item(itemnum).Data2
                    ItemDescType = "Potion"
                Case ITEM_TYPE_POTIONADDMP
                    ItemDescInfo = "Restore Amount: " & Item(itemnum).Data2
                    ItemDescType = "Potion"
                Case ITEM_TYPE_POTIONADDSP
                    ItemDescInfo = "Restore Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONSUBHP
                    ItemDescInfo = "Damage Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONSUBMP
                    ItemDescInfo = "Damage Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_POTIONSUBSP
                    ItemDescInfo = "Damage Amount: " & Item(itemnum).Data2
                Case ITEM_TYPE_KEY
                    ItemDescInfo = "N/A"
                    ItemDescType = "Key"
                Case ITEM_TYPE_CURRENCY
                    ItemDescInfo = "N/A"
                    ItemDescType = "Currency"
                Case ITEM_TYPE_SPELL
                    ItemDescInfo = "N/A"
                    ItemDescType = "Spell"
                Case ITEM_TYPE_FURNITURE
                    ItemDescInfo = "Furniture"
            End Select

            ItemDescSize = 0

            ' Currency
            ItemDescCost = Item(itemnum).Price & "g"

            ' If currency, exit out before all the other shit
            If Item(itemnum).Type = ITEM_TYPE_CURRENCY Or Item(itemnum).Type = ITEM_TYPE_NONE Then
                ' Clear other labels
                ItemDescLevel = "N/A"
                ItemDescSpeed = "N/A"

                ItemDescStr = "N/A"
                ItemDescEnd = "N/A"
                ItemDescInt = "N/A"
                ItemDescSpr = "N/A"
                ItemDescVit = "N/A"
                ItemDescLuck = "N/A"
                ItemDescSize = 1
                Exit Sub
            End If

            ' Potions + crap
            ItemDescLevel = Item(itemnum).LevelReq

        ' Exit out for everything else 'scept equipment
        If Item(itemnum).Type < ITEM_TYPE_WEAPON Or Item(itemnum).Type > ITEM_TYPE_GLOVES Then
                ' Clear other labels
                ItemDescSpeed = "N/A"

                ItemDescStr = "N/A"
                ItemDescEnd = "N/A"
                ItemDescInt = "N/A"
                ItemDescSpr = "N/A"
                ItemDescVit = "N/A"
                ItemDescLuck = "N/A"
                ItemDescSize = 1
                Exit Sub
            End If

            ' Equipment specific
            If Item(itemnum).Add_Stat(Stats.strength) > 0 Then
                ItemDescStr = "+" & Item(itemnum).Add_Stat(Stats.strength)
            Else
                ItemDescStr = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.vitality) > 0 Then
                ItemDescVit = "+" & Item(itemnum).Add_Stat(Stats.vitality)
            Else
                ItemDescVit = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.intelligence) > 0 Then
                ItemDescInt = "+" & Item(itemnum).Add_Stat(Stats.intelligence)
            Else
                ItemDescInt = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.endurance) > 0 Then
                ItemDescEnd = "+" & Item(itemnum).Add_Stat(Stats.endurance)
            Else
                ItemDescEnd = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.luck) > 0 Then
                ItemDescLuck = "+" & Item(itemnum).Add_Stat(Stats.luck)
            Else
                ItemDescLuck = "None"
            End If

            If Item(itemnum).Add_Stat(Stats.spirit) > 0 Then
                ItemDescSpr = "+" & Item(itemnum).Add_Stat(Stats.spirit)
            Else
                ItemDescSpr = "None"
            End If

        If Item(itemnum).Type = ITEM_TYPE_WEAPON Then
            ItemDescSpeed = Item(itemnum).Speed / 1000 & " secs"
        Else
            ItemDescSpeed = "N/A"
        End If

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

    Public Sub UpdateSpellWindow(ByVal spellnum As Long)

        If LastSpellDesc = spellnum Then Exit Sub

        SpellDescName = Spell(spellnum).Name

        Select Case Spell(spellnum).Type
            Case SPELL_TYPE_DAMAGEHP
                SpellDescType = "Damage HP"
                SpellDescVital = "Damage:"
            Case SPELL_TYPE_DAMAGEMP
                SpellDescType = "Damage MP"
                SpellDescVital = "Damage:"
            Case SPELL_TYPE_HEALHP
                SpellDescType = "Heal HP"
                SpellDescVital = "Heal:"
            Case SPELL_TYPE_HEALMP
                SpellDescType = "Heal MP"
                SpellDescVital = "Heal:"
            Case SPELL_TYPE_WARP
                SpellDescType = "Warp"
        End Select

        SpellDescReqMp = Spell(spellnum).MPCost
        SpellDescReqLvl = Spell(spellnum).LevelReq
        SpellDescReqAccess = Spell(spellnum).AccessReq

        If Spell(spellnum).ClassReq > 0 Then
            SpellDescReqClass = Trim$(Classes(Spell(spellnum).ClassReq).Name)
        Else
            SpellDescReqClass = "None"
        End If

        SpellDescCastTime = Spell(spellnum).CastTime & "s"
        SpellDescCoolDown = Spell(spellnum).CDTime & "s"
        SpellDescDamage = Spell(spellnum).Vital

        If Spell(spellnum).IsAoE Then
            SpellDescAOE = Spell(spellnum).AoE & " tiles."
        Else
            SpellDescAOE = "No"
        End If

        If Spell(spellnum).Range > 0 Then
            SpellDescRange = Spell(spellnum).Range & " tiles."
        Else
            SpellDescRange = "Self-cast"
        End If

    End Sub

    Public Sub CastSpell(ByVal spellslot As Long)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If spellslot < 1 Or spellslot > MAX_PLAYER_SPELLS Then
            Exit Sub
        End If

        If SpellCD(spellslot) > 0 Then
            AddText("Spell has not cooled down yet!", AlertColor)
            Exit Sub
        End If

        ' Check if player has enough MP
        If GetPlayerVital(MyIndex, Vitals.MP) < Spell(PlayerSpells(spellslot)).MPCost Then
            AddText("Not enough MP to cast " & Trim$(Spell(PlayerSpells(spellslot)).Name) & ".", AlertColor)
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
                    AddText("Cannot cast while walking!", AlertColor)
                End If
            End If
        Else
            AddText("No spell here.", AlertColor)
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

    Public Sub UpdateDrawMapName()
        Dim g As Graphics = Graphics.FromImage(TempBitmap)
        Dim width As Long
        width = g.MeasureString(Trim$(Map.Name), New Font(FONT_NAME, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width
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
