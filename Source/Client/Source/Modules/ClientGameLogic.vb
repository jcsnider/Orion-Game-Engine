Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports Orion

Module ClientGameLogic
    Public GameRand As New Random()

    Sub GameLoop()
        Dim i As Integer
        Dim dest As Point = New Point(FrmMainGame.PointToScreen(FrmMainGame.picscreen.Location))
        Dim g As Graphics = FrmMainGame.picscreen.CreateGraphics
        Dim starttime As Integer, Tick As Integer, fogtmr As Integer
        Dim tmpfps As Integer, tmplps as integer, WalkTimer As Integer, FrameTime As Integer
        Dim tmr10000 As Integer, tmr1000 As Integer
        Dim tmr100 As Integer, tmr500 As Integer, tmrconnect As Integer
        Dim rendercount as integer

        starttime = GetTickCount()
        FrmMenu.lblNextChar.Left = lblnextcharleft

        Do
            If GameDestroyed Then End

            DirDown = VbKeyDown
            DirUp = VbKeyUp
            DirLeft = VbKeyLeft
            DirRight = VbKeyRight

            If frmmenuvisible = True Then
                If tmrconnect < GetTickCount() Then
                    If IsConnected() = True Then
                        FrmMenu.lblServerStatus.ForeColor = Color.LightGreen
                        FrmMenu.lblServerStatus.Text = Strings.Get("mainmenu", "serveronline")
                    Else
                        i = i + 1
                        If i = 5 Then
                            Connect()
                            FrmMenu.lblServerStatus.Text = Strings.Get("mainmenu", "serverreconnect")
                            FrmMenu.lblServerStatus.ForeColor = Color.Orange
                            i = 0
                        Else
                            FrmMenu.lblServerStatus.Text = Strings.Get("mainmenu", "serveroffline")
                            FrmMenu.lblServerStatus.ForeColor = Color.Red
                        End If
                    End If
                    tmrconnect = GetTickCount() + 500
                End If
            End If

            'Update the UI
            UpdateUI()

            If GameStarted() = True Then
                Tick = GetTickCount()
                ElapsedTime = Tick - FrameTime ' Set the time difference for time-based movement

                FrameTime = Tick
                frmmaingamevisible = True

                'Calculate FPS
                If starttime < Tick Then
                    FPS = tmpfps
                    LPS = tmplps
                    tmpfps = 0
                    tmplps = 0
                    starttime = Tick + 1000
                End If
                tmplps = tmplps + 1
                tmpfps = tmpfps + 1

                ' Update inv animation
                If NumItems > 0 Then
                    If tmr100 < Tick Then

                        If InBank Then DrawBank()
                        If InShop Then DrawShop()
                        If InTrade Then DrawTrade()

                        tmr100 = Tick + 100
                    End If
                End If

                If ShowAnimTimer < Tick Then
                    ShowAnimLayers = Not ShowAnimLayers
                    ShowAnimTimer = Tick + 500
                End If

                For i = 1 To Byte.MaxValue
                    CheckAnimInstance(i)
                Next

                If Tick > EventChatTimer Then
                    If EventText = "" Then
                        If EventChat = True Then
                            EventChat = False
                            pnlEventChatVisible = False
                        End If
                    End If
                End If

                If tmr10000 < Tick Then
                    If Options.HighEnd = 0 Then
                        'clear any unused gfx
                        ClearGFX()
                    End If

                    GetPing()
                    DrawPing()

                    tmr10000 = Tick + 10000
                End If

                If tmr1000 < Tick Then
                    Time.Instance.Tick()

                    tmr1000 = Tick + 1000
                End If

                'crafting timer
                If CraftTimerEnabled Then
                    If CraftTimer < Tick Then
                        CraftProgressValue = CraftProgressValue + (100 / Recipe(GetRecipeIndex(RecipeNames(SelectedRecipe))).CreateTime)

                        If CraftProgressValue >= 100 Then
                            CraftTimerEnabled = False
                        End If
                        CraftTimer = Tick + 1000
                    End If
                End If

                'screenshake timer
                If ShakeTimerEnabled Then
                    If ShakeTimer < Tick Then
                        If ShakeCount < 10 Then
                            If LastDir = 0 Then
                                FrmMainGame.picscreen.Location = New Point(FrmMainGame.picscreen.Location.X + 20, FrmMainGame.picscreen.Location.Y)
                                LastDir = 1
                            Else
                                FrmMainGame.picscreen.Location = New Point(FrmMainGame.picscreen.Location.X - 20, FrmMainGame.picscreen.Location.Y)
                                LastDir = 0
                            End If
                        Else
                            FrmMainGame.picscreen.Location = New Point(0, 0)
                            ShakeCount = 0
                            ShakeTimerEnabled = False
                        End If

                        ShakeCount += 1

                        ShakeTimer = Tick + 50
                    End If
                End If

                ' check if trade timed out
                If TradeRequest = True Then
                    If TradeTimer < Tick Then
                        AddText(Strings.Get("trade", "tradetimeout"), ColorType.Yellow)
                        TradeRequest = False
                        TradeTimer = 0
                    End If
                End If

                ' check if we need to end the CD icon
                If NumSkillIcons > 0 Then
                    For i = 1 To MAX_PLAYER_SKILLS
                        If PlayerSkills(i) > 0 Then
                            If SkillCD(i) > 0 Then
                                If SkillCD(i) + (Skill(PlayerSkills(i)).CDTime * 1000) < Tick Then
                                    SkillCD(i) = 0
                                    DrawPlayerSkills()
                                End If
                            End If
                        End If
                    Next
                End If

                ' check if we need to unlock the player's skill casting restriction
                If SkillBuffer > 0 Then
                    If SkillBufferTimer + (Skill(PlayerSkills(SkillBuffer)).CastTime * 1000) < Tick Then
                        SkillBuffer = 0
                        SkillBufferTimer = 0
                    End If
                End If
                ' check if we need to unlock the pets's spell casting restriction
                If PetSkillBuffer > 0 Then
                    If PetSkillBufferTimer + (Skill(Pet(Player(MyIndex).Pet.Num).Skill(PetSkillBuffer)).CastTime * 1000) < Tick Then
                        PetSkillBuffer = 0
                        PetSkillBufferTimer = 0
                    End If
                End If

                SyncLock MapLock
                    If CanMoveNow Then
                        CheckMovement() ' Check if player is trying to move
                        CheckAttack()   ' Check to see if player is trying to attack
                    End If

                    ' Process input before rendering, otherwise input will be behind by 1 frame
                    If WalkTimer < Tick Then

                        For i = 1 To TotalOnline 'MAX_PLAYERS
                            If IsPlaying(i) Then
                                ProcessMovement(i)
                                If PetAlive(i) Then
                                    ProcessPetMovement(i)
                                End If
                            End If
                        Next

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

                    ' fog scrolling
                    If fogtmr < Tick Then
                        If CurrentFogSpeed > 0 Then
                            ' move
                            fogOffsetX = fogOffsetX - 1
                            fogOffsetY = fogOffsetY - 1
                            ' reset
                            If fogOffsetX < -255 Then fogOffsetX = 1
                            If fogOffsetY < -255 Then fogOffsetY = 1
                            fogtmr = Tick + 255 - CurrentFogSpeed
                        End If
                    End If

                    If tmr500 < Tick Then
                        ' animate waterfalls
                        Select Case WaterfallFrame
                            Case 0
                                WaterfallFrame = 1
                            Case 1
                                WaterfallFrame = 2
                            Case 2
                                WaterfallFrame = 0
                        End Select
                        ' animate autotiles
                        Select Case AutoTileFrame
                            Case 0
                                AutoTileFrame = 1
                            Case 1
                                AutoTileFrame = 2
                            Case 2
                                AutoTileFrame = 0
                        End Select

                        tmr500 = Tick + 500
                    End If

                    ProcessWeather()

                    If FadeInSwitch = True Then
                        FadeIn()
                    End If

                    If FadeOutSwitch = True Then
                        FadeOut()
                    End If

                    If InMapEditor Then EditorMap_DrawTileset()

                    Application.DoEvents()

                    If GettingMap Then
                        Dim font As New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + FONT_NAME, FONT_SIZE)
                        g.DrawString(Strings.Get("gamegui", "maprecieve"), font, Brushes.DarkCyan, FrmMainGame.picscreen.Width - 130, 5)
                    End If

                End SyncLock
            End If

            if rendercount < tick then
            	'Auctual Game Loop Stuff :/
                Render_Graphics()
                tmplps = tmplps + 1
                rendercount = Tick + 16
            End if

            Application.DoEvents()

            If Options.HighEnd = 1 Then
                Thread.Yield()
            Else
                Thread.Sleep(1)
            End If

        Loop
    End Sub

    Sub ClearTempTile()
        Dim X As Integer
        Dim Y As Integer
        ReDim TempTile(0 To Map.MaxX, 0 To Map.MaxY)

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                TempTile(X, Y).DoorOpen = 0
            Next
        Next

    End Sub

    Sub ProcessNpcMovement(ByVal MapNpcNum As Integer)

        ' Check if NPC is walking, and if so process moving them over
        If MapNpc(MapNpcNum).Moving = MovementType.Walking Then

            Select Case MapNpc(MapNpcNum).Dir
                Case Direction.Up
                    MapNpc(MapNpcNum).YOffset = MapNpc(MapNpcNum).YOffset - ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).YOffset < 0 Then MapNpc(MapNpcNum).YOffset = 0

                Case Direction.Down
                    MapNpc(MapNpcNum).YOffset = MapNpc(MapNpcNum).YOffset + ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).YOffset > 0 Then MapNpc(MapNpcNum).YOffset = 0

                Case Direction.Left
                    MapNpc(MapNpcNum).XOffset = MapNpc(MapNpcNum).XOffset - ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).XOffset < 0 Then MapNpc(MapNpcNum).XOffset = 0

                Case Direction.Right
                    MapNpc(MapNpcNum).XOffset = MapNpc(MapNpcNum).XOffset + ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If MapNpc(MapNpcNum).XOffset > 0 Then MapNpc(MapNpcNum).XOffset = 0

            End Select

            ' Check if completed walking over to the next tile
            If MapNpc(MapNpcNum).Moving > 0 Then
                If MapNpc(MapNpcNum).Dir = Direction.Right Or MapNpc(MapNpcNum).Dir = Direction.Down Then
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

    Sub DrawPing()

        PingToDraw = Ping

        Select Case Ping
            Case -1
                PingToDraw = Strings.Get("gamegui", "pingsync")
            Case 0 To 5
                PingToDraw = Strings.Get("gamegui", "pinglocal")
        End Select

    End Sub

    Public Function IsInBounds()
        IsInBounds = False

        If (CurX >= 0) AndAlso (CurX <= Map.MaxX) Then
            If (CurY >= 0) AndAlso (CurY <= Map.MaxY) Then
                IsInBounds = True
            End If
        End If

    End Function

    Function GameStarted() As Boolean
        GameStarted = False
        If InGame = False Then Exit Function
        If MapData = False Then Exit Function
        If PlayerData = False Then Exit Function
        GameStarted = True
        pnlloadvisible = False
    End Function

    Public Sub CreateActionMsg(ByVal message As String, ByVal color As Integer, ByVal MsgType As Byte, ByVal X As Integer, ByVal Y As Integer)

        ActionMsgIndex = ActionMsgIndex + 1
        If ActionMsgIndex >= Byte.MaxValue Then ActionMsgIndex = 1

        With ActionMsg(ActionMsgIndex)
            .message = message
            .color = color
            .Type = MsgType
            .Created = GetTickCount()
            .Scroll = 1
            .X = X
            .Y = Y
        End With

        If ActionMsg(ActionMsgIndex).Type = ActionMsgType.Scroll Then
            ActionMsg(ActionMsgIndex).Y = ActionMsg(ActionMsgIndex).Y + Rand(-2, 6)
            ActionMsg(ActionMsgIndex).X = ActionMsg(ActionMsgIndex).X + Rand(-8, 8)
        End If

    End Sub

    Public Function Rand(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer
        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return GameRand.Next(MinNumber, MaxNumber)
    End Function

    ' BitWise Operators for directional blocking
    Public Sub SetDirBlock(ByRef blockvar As Byte, ByRef Dir As Byte, ByVal block As Boolean)
        If block Then
            blockvar = blockvar Or (2 ^ Dir)
        Else
            blockvar = blockvar And Not (2 ^ Dir)
        End If
    End Sub

    Public Function IsDirBlocked(ByRef blockvar As Byte, ByRef Dir As Byte) As Boolean
        If Not blockvar And (2 ^ Dir) Then
            IsDirBlocked = False
        Else
            IsDirBlocked = True
        End If
    End Function

    Public Function ConvertCurrency(ByVal Amount As Integer) As String

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
        Dim i As Integer
        Dim n As Integer
        Dim Command() As String
        Dim Buffer As ByteBuffer
        ChatText = Trim$(ChatInput.CurrentMessage)
        Name = ""

        If Len(ChatText) = 0 Then Exit Sub
        ChatInput.CurrentMessage = LCase$(ChatText)

        If EventChat = True Then
            If EventChatType = 0 Then
                Buffer = New ByteBuffer
                Buffer.WriteInteger(ClientPackets.CEventChatReply)
                Buffer.WriteInteger(EventReplyID)
                Buffer.WriteInteger(EventReplyPage)
                Buffer.WriteInteger(0)
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
                BroadcastMsg(ChatText) '("Привет, русский чат")
            End If

            ChatInput.CurrentMessage = ""
            Exit Sub
        End If

        ' party message
        If Left$(ChatText, 1) = "-" Then
            ChatInput.CurrentMessage = Mid$(ChatText, 2, Len(ChatText) - 1)

            If Len(ChatText) > 0 Then
                SendPartyChatMsg(ChatInput.CurrentMessage)
            End If

            ChatInput.CurrentMessage = ""
            Exit Sub
        End If

        ' Player message
        If Left$(ChatText, 1) = "!" Then
            ChatText = Mid$(ChatText, 2, Len(ChatText) - 1)
            Name = ""

            ' Get the desired player from the user text
            For i = 1 To Len(ChatText)

                If Mid$(ChatText, i, 1) <> Space(1) Then
                    Name = Name & Mid$(ChatText, i, 1)
                Else
                    Exit For
                End If

            Next

            ChatInput.CurrentMessage = Trim$(Mid$(ChatText, i, Len(ChatText) - 1))

            ' Make sure they are actually sending something
            If Len(ChatInput.CurrentMessage) > 0 Then
                ' Send the message to the player
                PlayerMsg(ChatInput.CurrentMessage, Name)
            Else
                AddText(Strings.Get("chatcommand", "playermsg"), ColorType.Yellow)
            End If

            ChatInput.CurrentMessage = ""
            Exit Sub
        End If

        If Left$(ChatInput.CurrentMessage, 1) = "/" Then
            Command = Split(ChatInput.CurrentMessage, Space(1))

            Select Case Command(0)
                Case "/emote"
                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("chatcommand", "emote"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText(Strings.Get("chatcommand", "emote"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendUseEmote(Command(1))

                Case "/help"
                    AddText(Strings.Get("chatcommand", "help1"), ColorType.Yellow)
                    AddText(Strings.Get("chatcommand", "help2"), ColorType.Yellow)
                    AddText(Strings.Get("chatcommand", "help3"), ColorType.Yellow)
                    AddText(Strings.Get("chatcommand", "help4"), ColorType.Yellow)
                    AddText(Strings.Get("chatcommand", "help5"), ColorType.Yellow)

                Case "/houseinvite"

                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("chatcommand", "houseinvite"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText(Strings.Get("chatcommand", "houseinvite"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendInvite(Command(1))

                Case "/sellhouse"
                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ClientPackets.CSellHouse)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                Case "/info"

                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("chatcommand", "info"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText(Strings.Get("chatcommand", "info"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ClientPackets.CPlayerInfoRequest)
                    Buffer.WriteString(Command(1))
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                ' Whos Online
                Case "/who"
                    SendWhosOnline()
                ' Checking fps
                Case "/fps"
                    BFPS = Not BFPS
                Case "/lps"
                    BLPS = Not BLPS
                ' Request stats
                Case "/stats"
                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ClientPackets.CGetStats)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                Case "/party"
                    ' Make sure they are actually sending something
                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("chatcommand", "party"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText(Strings.Get("chatcommand", "party"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendPartyRequest(Command(1))

                ' Join party
                Case "/join"
                    SendAcceptParty()
                ' Leave party
                Case "/leave"
                    SendLeaveParty()

                'release pet
                Case "/releasepet"
                    SendReleasePet()

                ' // Monitor Admin Commands //

                Case "/questreset"
                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "questreset"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText(Strings.Get("adminchatcommand", "questreset"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    n = Command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_QUESTS Then
                        QuestReset(n)
                    Else
                        AddText(Strings.Get("adminchatcommand", "wrongquestnr"), QColorType.AlertColor)
                    End If

                ' Admin Help
                Case "/admin"

                    If GetPlayerAccess(MyIndex) < AdminType.Monitor Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    AddText(Strings.Get("adminchatcommand", "admin1"), ColorType.Yellow)
                    AddText(Strings.Get("adminchatcommand", "adminglobal"), ColorType.Yellow)
                    AddText(Strings.Get("adminchatcommand", "adminprivate"), ColorType.Yellow)
                    AddText(Strings.Get("adminchatcommand", "admin2"), ColorType.Yellow)
                ' Kicking a player
                Case "/kick"

                    If GetPlayerAccess(MyIndex) < AdminType.Monitor Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "kick"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText(Strings.Get("adminchatcommand", "kick"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendKick(Command(1))
                ' // Mapper Admin Commands //
                ' Location
                Case "/loc"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    BLoc = Not BLoc
                ' Map Editor
                Case "/mapeditor"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditMap()
                ' Warping to a player
                Case "/warpmeto"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "warpmeto"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText(Strings.Get("adminchatcommand", "warpmeto"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    WarpMeTo(Command(1))
                ' Warping a player to you
                Case "/warptome"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "warptome"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText(Strings.Get("adminchatcommand", "warptome"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    WarpToMe(Command(1))
                ' Warping to a map
                Case "/warpto"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "warpto"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText(Strings.Get("adminchatcommand", "warpto"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    n = Command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_MAPS Then
                        WarpTo(n)
                    Else
                        AddText(Strings.Get("adminchatcommand", "wrongmapnr"), QColorType.AlertColor)
                    End If

                ' Setting sprite
                Case "/setsprite"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "setsprite"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText(Strings.Get("adminchatcommand", "setsprite"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetSprite(Command(1))
                ' Map report
                Case "/mapreport"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestMapreport()
                ' Respawn request
                Case "/respawn"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendMapRespawn()
                ' MOTD change
                Case "/motd"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "motd"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendMOTDChange(Right$(ChatText, Len(ChatText) - 5))
                ' Check the ban list
                Case "/banlist"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendBanList()
                ' Banning a player
                Case "/ban"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText(Strings.Get("adminchatcommand", "ban"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendBan(Command(1))
                ' // Developer Admin Commands //

                ' // Creator Admin Commands //
                ' Giving another player access
                Case "/setaccess"

                    If GetPlayerAccess(MyIndex) < AdminType.Creator Then
                        AddText(Strings.Get("adminchatcommand", "accesswarning"), QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 2 Then
                        AddText(Strings.Get("adminchatcommand", "setaccess"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Or Not IsNumeric(Command(2)) Then
                        AddText(Strings.Get("adminchatcommand", "setaccess"), ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetAccess(Command(1), CLng(Command(2)))
                Case Else
                    AddText(Strings.Get("chatcommand", "wrongcmd"), QColorType.AlertColor)
            End Select

            'continue label where we go instead of exiting the sub
Continue1:
            ChatInput.CurrentMessage = ""
            Exit Sub
        End If

        ' Say message
        If Len(ChatText) > 0 Then
            SayMsg(ChatText)
        End If

        ChatInput.CurrentMessage = ""
    End Sub

    Sub CheckMapGetItem()
        Dim Buffer As New ByteBuffer
        Buffer = New ByteBuffer

        If GetTickCount() > Player(MyIndex).MapGetTimer + 250 Then
            If Trim$(ChatInput.CurrentMessage) = "" Then
                Player(MyIndex).MapGetTimer = GetTickCount()
                Buffer.WriteInteger(ClientPackets.CMapGetItem)
                SendData(Buffer.ToArray())
            End If
        End If

        Buffer = Nothing
    End Sub

    Public Sub UpdateDescWindow(ByVal itemnum As Integer, ByVal Amount As Integer, ByVal InvNum As Integer, ByVal WindowType As Byte)
        Dim theName As String = "", tmpRarity As Integer

        If Item(itemnum).Randomize <> 0 And InvNum <> 0 Then
            If WindowType = 0 Then ' inventory
                theName = Trim(Player(MyIndex).RandInv(InvNum).Prefix) & " " & Trim(Item(itemnum).Name) & " " & Trim(Player(MyIndex).RandInv(InvNum).Suffix)
                tmpRarity = Player(MyIndex).RandInv(InvNum).Rarity
            ElseIf WindowType = 1 Then ' equip
                theName = Trim(Player(MyIndex).RandEquip(InvNum).Prefix) & " " & Trim(Item(itemnum).Name) & " " & Trim(Player(MyIndex).RandEquip(InvNum).Suffix)
                tmpRarity = Player(MyIndex).RandEquip(InvNum).Rarity
            ElseIf WindowType = 2 Then ' bank
                theName = Trim(Bank.ItemRand(InvNum).Prefix) & " " & Trim(Item(itemnum).Name) & " " & Trim(Bank.ItemRand(InvNum).Suffix)
                tmpRarity = Bank.ItemRand(InvNum).Rarity
            ElseIf WindowType = 3 Then ' shop
                theName = Trim(Player(MyIndex).RandEquip(InvNum).Prefix) & " " & Trim(Item(itemnum).Name) & " " & Trim(Player(MyIndex).RandEquip(InvNum).Suffix)
                tmpRarity = Player(MyIndex).RandEquip(InvNum).Rarity
            ElseIf WindowType = 4 Then ' trade
                theName = Trim(Player(MyIndex).RandEquip(InvNum).Prefix) & " " & Trim(Item(itemnum).Name) & " " & Trim(Player(MyIndex).RandEquip(InvNum).Suffix)
                tmpRarity = Player(MyIndex).RandEquip(InvNum).Rarity
            End If
        Else
            theName = Trim$(Item(itemnum).Name)
            tmpRarity = Item(itemnum).Rarity
        End If

        ItemDescName = theName

        ItemDescItemNum = itemnum

        If LastItemDesc = itemnum Then Exit Sub

        ' set the name
        Select Case tmpRarity
            Case 0 ' White
                ItemDescRarityColor = ITEM_RARITY_COLOR_0
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 1 ' green
                ItemDescRarityColor = ITEM_RARITY_COLOR_1
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 2 ' blue
                ItemDescRarityColor = ITEM_RARITY_COLOR_2
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 3 ' red
                ItemDescRarityColor = ITEM_RARITY_COLOR_3
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 4 ' purple
                ItemDescRarityColor = ITEM_RARITY_COLOR_4
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 5 'gold
                ItemDescRarityColor = ITEM_RARITY_COLOR_5
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
        End Select

        ItemDescDescription = Item(itemnum).Description

        ' For the stats label
        Select Case Item(itemnum).Type
            Case ItemType.None
                ItemDescInfo = Strings.Get("itemdescription", "notavail")
                ItemDescType = Strings.Get("itemdescription", "notavail")

            Case ItemType.Equipment
                Select Case Item(itemnum).SubType

                    Case EquipmentType.Weapon
                        If Item(itemnum).Randomize <> 0 Then
                            If WindowType = 0 Then
                                ItemDescInfo = "Damage: " & Player(MyIndex).RandInv(InvNum).Damage
                            Else
                                ItemDescInfo = "Damage: " & Player(MyIndex).RandEquip(InvNum).Damage
                            End If
                        Else
                            ItemDescInfo = "Damage: " & Item(itemnum).Data2
                        End If
                        ItemDescType = "Weapon"
                    Case EquipmentType.Armor
                        ItemDescInfo = "Defence: " & Item(itemnum).Data2
                        ItemDescType = "Armor"
                    Case EquipmentType.Helmet
                        ItemDescInfo = "Defence: " & Item(itemnum).Data2
                        ItemDescType = "Helmet"
                    Case EquipmentType.Shield
                        ItemDescInfo = "Defence: " & Item(itemnum).Data2
                        ItemDescType = "Shield"
                    Case EquipmentType.Shoes
                        ItemDescInfo = "Defence: " & Item(itemnum).Data2
                        ItemDescType = "Shoes"
                    Case EquipmentType.Gloves
                        ItemDescInfo = "Defence: " & Item(itemnum).Data2
                        ItemDescType = "Gloves"
                End Select

            Case ItemType.Consumable
                Select Case Item(itemnum).SubType
                    Case ConsumableType.Hp
                        ItemDescInfo = Strings.Get("itemdescription", "restore") & Item(itemnum).Data2
                        ItemDescType = Strings.Get("itemdescription", "potion")
                    Case ConsumableType.Mp
                        ItemDescInfo = Strings.Get("itemdescription", "restore") & Item(itemnum).Data2
                        ItemDescType = Strings.Get("itemdescription", "potion")
                    Case ConsumableType.Sp
                        ItemDescInfo = Strings.Get("itemdescription", "restore") & Item(itemnum).Data2
                        ItemDescType = Strings.Get("itemdescription", "potion")
                    Case ConsumableType.Exp
                        ItemDescInfo = Strings.Get("itemdescription", "amount") & Item(itemnum).Data2
                        ItemDescType = Strings.Get("itemdescription", "potion")
                End Select

            Case ItemType.Key
                ItemDescInfo = Strings.Get("itemdescription", "notavail")
                ItemDescType = Strings.Get("itemdescription", "key")
            Case ItemType.Currency
                ItemDescInfo = Strings.Get("itemdescription", "notavail")
                ItemDescType = Strings.Get("itemdescription", "currency")
            Case ItemType.Skill
                ItemDescInfo = Strings.Get("itemdescription", "notavail")
                ItemDescType = Strings.Get("itemdescription", "skill")
            Case ItemType.Furniture
                ItemDescInfo = Strings.Get("itemdescription", "furniture")
        End Select

        ' Currency
        ItemDescCost = Item(itemnum).Price & "g"

        ' If currency, exit out before all the other shit
        If Item(itemnum).Type = ItemType.Currency Or Item(itemnum).Type = ItemType.None Then
            ' Clear other labels
            ItemDescLevel = Strings.Get("itemdescription", "notavail")
            ItemDescSpeed = Strings.Get("itemdescription", "notavail")

            ItemDescStr = Strings.Get("itemdescription", "notavail")
            ItemDescEnd = Strings.Get("itemdescription", "notavail")
            ItemDescInt = Strings.Get("itemdescription", "notavail")
            ItemDescSpr = Strings.Get("itemdescription", "notavail")
            ItemDescVit = Strings.Get("itemdescription", "notavail")
            ItemDescLuck = Strings.Get("itemdescription", "notavail")
            Exit Sub
        End If

        ' Potions + crap
        ItemDescLevel = Item(itemnum).LevelReq

        ' Exit out for everything else 'scept equipment
        If Item(itemnum).Type <> ItemType.Equipment Then
            ' Clear other labels
            ItemDescSpeed = Strings.Get("itemdescription", "notavail")

            ItemDescStr = Strings.Get("itemdescription", "notavail")
            ItemDescEnd = Strings.Get("itemdescription", "notavail")
            ItemDescInt = Strings.Get("itemdescription", "notavail")
            ItemDescSpr = Strings.Get("itemdescription", "notavail")
            ItemDescVit = Strings.Get("itemdescription", "notavail")
            ItemDescLuck = Strings.Get("itemdescription", "notavail")
            Exit Sub
        End If

        ' Equipment specific
        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Player(MyIndex).RandInv(InvNum).Stat(Stats.Strength) > 0 Then
                    ItemDescStr = "+" & Player(MyIndex).RandInv(InvNum).Stat(Stats.Strength)
                Else
                    ItemDescStr = Strings.Get("itemdescription", "none")
                End If
            Else
                If Player(MyIndex).RandEquip(InvNum).Stat(Stats.Strength) > 0 Then
                    ItemDescStr = "+" & Player(MyIndex).RandEquip(InvNum).Stat(Stats.Strength)
                Else
                    ItemDescStr = Strings.Get("itemdescription", "none")
                End If
            End If

        Else
            If Item(itemnum).Add_Stat(Stats.Strength) > 0 Then
                ItemDescStr = "+" & Item(itemnum).Add_Stat(Stats.Strength)
            Else
                ItemDescStr = Strings.Get("itemdescription", "none")
            End If
        End If

        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Player(MyIndex).RandInv(InvNum).Stat(Stats.Vitality) > 0 Then
                    ItemDescVit = "+" & Player(MyIndex).RandInv(InvNum).Stat(Stats.Vitality)
                Else
                    ItemDescVit = Strings.Get("itemdescription", "none")
                End If
            Else
                If Player(MyIndex).RandEquip(InvNum).Stat(Stats.Vitality) > 0 Then
                    ItemDescVit = "+" & Player(MyIndex).RandEquip(InvNum).Stat(Stats.Vitality)
                Else
                    ItemDescVit = Strings.Get("itemdescription", "none")
                End If
            End If
        Else
            If Item(itemnum).Add_Stat(Stats.Vitality) > 0 Then
                ItemDescVit = "+" & Item(itemnum).Add_Stat(Stats.Vitality)
            Else
                ItemDescVit = Strings.Get("itemdescription", "none")
            End If
        End If

        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Player(MyIndex).RandInv(InvNum).Stat(Stats.Intelligence) > 0 Then
                    ItemDescInt = "+" & Player(MyIndex).RandInv(InvNum).Stat(Stats.Intelligence)
                Else
                    ItemDescInt = Strings.Get("itemdescription", "none")
                End If
            Else
                If Player(MyIndex).RandEquip(InvNum).Stat(Stats.Intelligence) > 0 Then
                    ItemDescInt = "+" & Player(MyIndex).RandEquip(InvNum).Stat(Stats.Intelligence)
                Else
                    ItemDescInt = Strings.Get("itemdescription", "none")
                End If
            End If
        Else
            If Item(itemnum).Add_Stat(Stats.Intelligence) > 0 Then
                ItemDescInt = "+" & Item(itemnum).Add_Stat(Stats.Intelligence)
            Else
                ItemDescInt = Strings.Get("itemdescription", "none")
            End If
        End If

        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Player(MyIndex).RandInv(InvNum).Stat(Stats.Endurance) > 0 Then
                    ItemDescEnd = "+" & Player(MyIndex).RandInv(InvNum).Stat(Stats.Endurance)
                Else
                    ItemDescEnd = Strings.Get("itemdescription", "none")
                End If
            Else
                If Player(MyIndex).RandEquip(InvNum).Stat(Stats.Endurance) > 0 Then
                    ItemDescEnd = "+" & Player(MyIndex).RandEquip(InvNum).Stat(Stats.Endurance)
                Else
                    ItemDescEnd = Strings.Get("itemdescription", "none")
                End If
            End If

        Else
            If Item(itemnum).Add_Stat(Stats.Endurance) > 0 Then
                ItemDescEnd = "+" & Item(itemnum).Add_Stat(Stats.Endurance)
            Else
                ItemDescEnd = Strings.Get("itemdescription", "none")
            End If
        End If

        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Player(MyIndex).RandInv(InvNum).Stat(Stats.Luck) > 0 Then
                    ItemDescLuck = "+" & Player(MyIndex).RandInv(InvNum).Stat(Stats.Luck)
                Else
                    ItemDescLuck = Strings.Get("itemdescription", "none")
                End If
            Else
                If Player(MyIndex).RandEquip(InvNum).Stat(Stats.Luck) > 0 Then
                    ItemDescLuck = "+" & Player(MyIndex).RandEquip(InvNum).Stat(Stats.Luck)
                Else
                    ItemDescLuck = Strings.Get("itemdescription", "none")
                End If
            End If

        Else
            If Item(itemnum).Add_Stat(Stats.Luck) > 0 Then
                ItemDescLuck = "+" & Item(itemnum).Add_Stat(Stats.Luck)
            Else
                ItemDescLuck = Strings.Get("itemdescription", "none")
            End If
        End If

        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Player(MyIndex).RandInv(InvNum).Stat(Stats.Spirit) > 0 Then
                    ItemDescSpr = "+" & Player(MyIndex).RandInv(InvNum).Stat(Stats.Spirit)
                Else
                    ItemDescSpr = Strings.Get("itemdescription", "none")
                End If
            Else
                If Player(MyIndex).RandEquip(InvNum).Stat(Stats.Spirit) > 0 Then
                    ItemDescSpr = "+" & Player(MyIndex).RandEquip(InvNum).Stat(Stats.Spirit)
                Else
                    ItemDescSpr = Strings.Get("itemdescription", "none")
                End If
            End If

        Else
            If Item(itemnum).Add_Stat(Stats.Spirit) > 0 Then
                ItemDescSpr = "+" & Item(itemnum).Add_Stat(Stats.Spirit)
            Else
                ItemDescSpr = Strings.Get("itemdescription", "none")
            End If
        End If

        If Item(itemnum).Randomize <> 0 Then
            If WindowType = 0 Then
                If Item(itemnum).SubType = EquipmentType.Weapon Then
                    ItemDescSpeed = Player(MyIndex).RandInv(InvNum).Speed / 1000 & Strings.Get("itemdescription", "secs")
                Else
                    ItemDescSpeed = Strings.Get("itemdescription", "notavail")
                End If
            Else
                If Item(itemnum).SubType = EquipmentType.Weapon Then
                    ItemDescSpeed = Player(MyIndex).RandEquip(InvNum).Speed / 1000 & Strings.Get("itemdescription", "secs")
                Else
                    ItemDescSpeed = Strings.Get("itemdescription", "notavail")
                End If
            End If

        Else
            If Item(itemnum).SubType = EquipmentType.Weapon Then
                ItemDescSpeed = Item(itemnum).Speed / 1000 & Strings.Get("itemdescription", "secs")
            Else
                ItemDescSpeed = Strings.Get("itemdescription", "notavail")
            End If
        End If

    End Sub

    Public Sub OpenShop(ByVal shopnum As Integer)
        InShop = shopnum
        ShopAction = 0
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

    Public Sub SetBankItemNum(ByVal Bankslot As Byte, ByVal itemnum As Integer)
        Bank.Item(Bankslot).Num = itemnum
    End Sub

    Public Function GetBankItemValue(ByVal Bankslot As Byte) As Integer
        GetBankItemValue = Bank.Item(Bankslot).Value
    End Function

    Public Sub SetBankItemValue(ByVal Bankslot As Byte, ByVal ItemValue As Integer)
        Bank.Item(Bankslot).Value = ItemValue
    End Sub

    Public Sub ClearActionMsg(ByVal Index As Byte)
        ActionMsg(Index).message = ""
        ActionMsg(Index).Created = 0
        ActionMsg(Index).Type = 0
        ActionMsg(Index).color = 0
        ActionMsg(Index).Scroll = 0
        ActionMsg(Index).X = 0
        ActionMsg(Index).Y = 0
    End Sub

    Public Sub UpdateSkillWindow(ByVal skillnum As Integer)

        If LastSkillDesc = skillnum Then Exit Sub

        SkillDescName = Skill(skillnum).Name

        Select Case Skill(skillnum).Type
            Case SkillType.DamageHp
                SkillDescType = Strings.Get("skilldescription", "damagehp")
                SkillDescVital = Strings.Get("skilldescription", "damage")
            Case SkillType.DamageMp
                SkillDescType = Strings.Get("skilldescription", "damagemp")
                SkillDescVital = Strings.Get("skilldescription", "damage")
            Case SkillType.HealHp
                SkillDescType = Strings.Get("skilldescription", "healhp")
                SkillDescVital = Strings.Get("skilldescription", "heal")
            Case SkillType.HealMp
                SkillDescType = Strings.Get("skilldescription", "healmp")
                SkillDescVital = Strings.Get("skilldescription", "heal")
            Case SkillType.Warp
                SkillDescType = Strings.Get("skilldescription", "warp")
        End Select

        SkillDescReqMp = Skill(skillnum).MPCost
        SkillDescReqLvl = Skill(skillnum).LevelReq
        SkillDescReqAccess = Skill(skillnum).AccessReq

        If Skill(skillnum).ClassReq > 0 Then
            SkillDescReqClass = Trim$(Classes(Skill(skillnum).ClassReq).Name)
        Else
            SkillDescReqClass = Strings.Get("skilldescription", "none")
        End If

        SkillDescCastTime = Skill(skillnum).CastTime & "s"
        SkillDescCoolDown = Skill(skillnum).CDTime & "s"
        SkillDescDamage = Skill(skillnum).Vital

        If Skill(skillnum).IsAoE Then
            SkillDescAOE = Skill(skillnum).AoE & Strings.Get("skilldescription", "tiles")
        Else
            SkillDescAOE = Strings.Get("skilldescription", "no")
        End If

        If Skill(skillnum).Range > 0 Then
            SkillDescRange = Skill(skillnum).Range & Strings.Get("skilldescription", "tiles")
        Else
            SkillDescRange = Strings.Get("skilldescription", "selfcast")
        End If

    End Sub

    Public Sub CheckAnimInstance(ByVal Index As Integer)
        Dim looptime As Integer
        Dim Layer As Integer
        Dim FrameCount As Integer

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
        Dim g As Graphics = Graphics.FromImage(New Bitmap(1, 1))
        'Dim width As Integer
        'width = g.MeasureString(Trim$(Map.Name), New Font(FONT_NAME, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width
        'DrawMapNameX = ((SCREEN_MAPX + 1) * PIC_X / 2) - width + 32
        'DrawMapNameY = 1

        Select Case Map.Moral
            Case MapMoral.None
                DrawMapNameColor = SFML.Graphics.Color.Red
            Case MapMoral.Safe
                DrawMapNameColor = SFML.Graphics.Color.Green
            Case Else
                DrawMapNameColor = SFML.Graphics.Color.White
        End Select
        g.Dispose()
    End Sub

    Public Sub AddChatBubble(ByVal target As Long, ByVal targetType As Byte, ByVal Msg As String, ByVal colour As Long)
        Dim i As Long, Index As Long

        ' set the global index

        chatBubbleIndex = chatBubbleIndex + 1
        If chatBubbleIndex < 1 Or chatBubbleIndex > Byte.MaxValue Then chatBubbleIndex = 1
        ' default to new bubble
        Index = chatBubbleIndex
        ' loop through and see if that player/npc already has a chat bubble
        For i = 1 To Byte.MaxValue
            If chatBubble(i).targetType = targetType Then
                If chatBubble(i).target = target Then
                    ' reset master index
                    If chatBubbleIndex > 1 Then chatBubbleIndex = chatBubbleIndex - 1
                    ' we use this one now, yes?
                    Index = i
                    Exit For
                End If
            End If
        Next
        ' set the bubble up
        With chatBubble(Index)
            .target = target
            .targetType = targetType
            .Msg = Msg
            .colour = colour
            .Timer = GetTickCount()
            .active = True
        End With

    End Sub

End Module