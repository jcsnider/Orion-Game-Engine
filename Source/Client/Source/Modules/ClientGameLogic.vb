Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Module ClientGameLogic
    Public GameRand As New Random()

    Sub GameLoop()
        Dim i As Integer
        Dim dest As Point = New Point(frmMainGame.PointToScreen(frmMainGame.picscreen.Location))
        Dim g As Graphics = frmMainGame.picscreen.CreateGraphics
        Dim starttime As Integer, Tick As Integer, fogtmr As Integer
        Dim tmpfps As Integer, WalkTimer As Integer, FrameTime As Integer
        Dim destrect As Rectangle, tmr10000 As Integer
        Dim tmr100 As Integer, tmr500 As Integer

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

                'Calculate FPS
                If starttime < GetTickCount() Then
                    FPS = tmpfps

                    tmpfps = 0
                    starttime = GetTickCount() + 1000
                End If
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
                    'clear any unused gfx
                    ClearGFX()
                    GetPing()
                    DrawPing()

                    tmr10000 = Tick + 10000
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
                                frmMainGame.picscreen.Location = New Point(frmMainGame.picscreen.Location.X + 20, frmMainGame.picscreen.Location.Y)
                                LastDir = 1
                            Else
                                frmMainGame.picscreen.Location = New Point(frmMainGame.picscreen.Location.X - 20, frmMainGame.picscreen.Location.Y)
                                LastDir = 0
                            End If
                        Else
                            frmMainGame.picscreen.Location = New Point(0, 0)
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
                        AddText("You took too Integer to decide. Please try again.", ColorType.Yellow)
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

                    ' fog scrolling
                    If fogtmr < Tick Then
                        If CurrentFogSpeed > 0 Then
                            ' move
                            fogOffsetX = fogOffsetX - 1
                            fogOffsetY = fogOffsetY - 1
                            ' reset
                            If fogOffsetX < -256 Then fogOffsetX = 0
                            If fogOffsetY < -256 Then fogOffsetY = 0
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

                    'Auctual Game Loop Stuff :/
                    Render_Graphics()

                    If FadeInSwitch = True Then
                        FadeIn()
                    End If

                    If FadeOutSwitch = True Then
                        FadeOut()
                    End If

                    If InMapEditor Then EditorMap_DrawTileset()

                    destrect = New Rectangle(0, 0, ScreenX, ScreenY)
                    Application.DoEvents()

                    If GettingMap Then
                        Dim font As New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + FONT_NAME, FONT_SIZE)
                        g.DrawString("Receiving Map", font, Brushes.DarkCyan, frmMainGame.picscreen.Width - 130, 5)
                    End If

                End SyncLock
            End If

            Application.DoEvents()
            Thread.Sleep(1)
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
        ChatText = Trim$(MyText)
        Name = ""

        If Len(ChatText) = 0 Then Exit Sub
        MyText = LCase$(ChatText)

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
                BroadcastMsg(ChatText)
            End If

            MyText = ""
            Exit Sub
        End If

        ' Emote message
        If Left$(ChatText, 1) = "-" Then
            MyText = Mid$(ChatText, 2, Len(ChatText) - 1)

            If Len(ChatText) > 0 Then
                EmoteMsg(ChatText)
            End If

            MyText = ""
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

            MyText = Trim$(Mid$(ChatText, i, Len(ChatText) - 1))

            ' Make sure they are actually sending something
            If Len(MyText) > 0 Then
                ' Send the message to the player
                PlayerMsg(MyText, Name)
            Else
                AddText("Usage: !playername (message)", ColorType.Yellow)
            End If

            MyText = ""
            Exit Sub
        End If

        If Left$(MyText, 1) = "/" Then
            Command = Split(MyText, Space(1))

            Select Case Command(0)
                Case "/emote"
                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText("Usage: /emote (number 1 to 11)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /emote (number 1 to 11)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendUseEmote(Command(1))

                Case "/help"
                    AddText("Social Commands:", ColorType.Yellow)
                    AddText("'msghere = Broadcast Message", ColorType.Yellow)
                    AddText("-msghere = Emote Message", ColorType.Yellow)
                    AddText("!namehere msghere = Player Message", ColorType.Yellow)
                    AddText("Available Commands: /help, /info, /who, /fps, /stats, /trade, /party, /join, /leave, /sellhouse", ColorType.Yellow)
                Case "/sellhouse"
                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ClientPackets.CSellHouse)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                Case "/info"

                    ' Checks to make sure we have more than one string in the array
                    If UBound(Command) < 1 Then
                        AddText("Usage: /info (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /info (name)", ColorType.Yellow)
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
                ' Request stats
                Case "/stats"
                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ClientPackets.CGetStats)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                Case "/party"
                    ' Make sure they are actually sending something
                    If UBound(Command) < 1 Then
                        AddText("Usage: /party (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /party (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendPartyRequest(Command(1))

                ' Join party
                Case "/join"
                    SendAcceptParty()
                ' Leave party
                Case "/leave"
                    SendLeaveParty()
                ' // Monitor Admin Commands //

                Case "/questreset"
                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /questreset (quest #)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /questreset (quest #)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    n = Command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_QUESTS Then
                        QuestReset(n)
                    Else
                        AddText("Invalid quest number.", QColorType.AlertColor)
                    End If

                ' Admin Help
                Case "/admin"

                    If GetPlayerAccess(MyIndex) < AdminType.Monitor Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    AddText("Social Commands:", ColorType.Yellow)
                    AddText("""msghere = Global Admin Message", ColorType.Yellow)
                    AddText("=msghere = Private Admin Message", ColorType.Yellow)
                    AddText("Available Commands: /admin, /loc, /mapeditor, /warpmeto, /warptome, /warpto, /setsprite, /mapreport, /kick, /ban, /edititem, /respawn, /editnpc, /motd, /editshop, /editskill, /debug, /questreset", ColorType.Yellow)
                ' Kicking a player
                Case "/kick"

                    If GetPlayerAccess(MyIndex) < AdminType.Monitor Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /kick (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /kick (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendKick(Command(1))
                ' // Mapper Admin Commands //
                ' Location
                Case "/loc"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    BLoc = Not BLoc
                ' Map Editor
                Case "/mapeditor"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditMap()
                ' Warping to a player
                Case "/warpmeto"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warpmeto (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /warpmeto (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    WarpMeTo(Command(1))
                ' Warping a player to you
                Case "/warptome"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warptome (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Then
                        AddText("Usage: /warptome (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    WarpToMe(Command(1))
                ' Warping to a map
                Case "/warpto"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /warpto (map #)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /warpto (map #)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    n = Command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_MAPS Then
                        WarpTo(n)
                    Else
                        AddText("Invalid map number.", QColorType.AlertColor)
                    End If

                ' Setting sprite
                Case "/setsprite"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /setsprite (sprite #)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If Not IsNumeric(Command(1)) Then
                        AddText("Usage: /setsprite (sprite #)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetSprite(Command(1))
                ' Map report
                Case "/mapreport"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestMapreport()
                ' Respawn request
                Case "/respawn"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendMapRespawn()
                ' MOTD change
                Case "/motd"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /motd (new motd)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendMOTDChange(Right$(ChatText, Len(ChatText) - 5))
                ' Check the ban list
                Case "/banlist"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendBanList()
                ' Banning a player
                Case "/ban"

                    If GetPlayerAccess(MyIndex) < AdminType.Mapper Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 1 Then
                        AddText("Usage: /ban (name)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendBan(Command(1))
                ' // Developer Admin Commands //
                ' Editing item request
                Case "/edititem"

                    If GetPlayerAccess(MyIndex) < AdminType.Developer Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditItem()
                ' Editing animation request
                Case "/editanimation"

                    If GetPlayerAccess(MyIndex) < AdminType.Developer Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditAnimation()
                ' Editing npc request
                Case "/editnpc"

                    If GetPlayerAccess(MyIndex) < AdminType.Developer Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditNpc()
                Case "/editresource"

                    If GetPlayerAccess(MyIndex) < AdminType.Developer Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditResource()
                ' Editing shop request
                Case "/editshop"

                    If GetPlayerAccess(MyIndex) < AdminType.Developer Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditShop()
                ' Editing skill request
                Case "/editskill"

                    If GetPlayerAccess(MyIndex) < AdminType.Developer Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendRequestEditSkill()
                ' // Creator Admin Commands //
                ' Giving another player access
                Case "/setaccess"

                    If GetPlayerAccess(MyIndex) < AdminType.Creator Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    If UBound(Command) < 2 Then
                        AddText("Usage: /setaccess (name) (access)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    If IsNumeric(Command(1)) Or Not IsNumeric(Command(2)) Then
                        AddText("Usage: /setaccess (name) (access)", ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetAccess(Command(1), CLng(Command(2)))
                ' Ban destroy
                Case "/destroybanlist"

                    If GetPlayerAccess(MyIndex) < AdminType.Creator Then
                        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
                        GoTo Continue1
                    End If

                    SendBanDestroy()
                Case Else
                    AddText("Not a valid command!", QColorType.AlertColor)
            End Select

            'continue label where we go instead of exiting the sub
Continue1:
            MyText = ""
            Exit Sub
        End If

        ' Say message
        If Len(ChatText) > 0 Then
            SayMsg(ChatText)
        End If

        MyText = ""
    End Sub

    Sub CheckMapGetItem()
        Dim Buffer As New ByteBuffer
        Buffer = New ByteBuffer

        If GetTickCount() > Player(MyIndex).MapGetTimer + 250 Then
            If Trim$(MyText) = "" Then
                Player(MyIndex).MapGetTimer = GetTickCount()
                Buffer.WriteInteger(ClientPackets.CMapGetItem)
                SendData(Buffer.ToArray())
            End If
        End If

        Buffer = Nothing
    End Sub

    Public Sub UpdateDescWindow(ByVal itemnum As Integer, ByVal Amount As Integer, ByVal InvNum As Integer)
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
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 1 ' green
                ItemDescRarityColor = ITEM_RARITY_COLOR_1
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 2 ' blue
                ItemDescRarityColor = ITEM_RARITY_COLOR_2
                ItemDescRarityBackColor = SFML.Graphics.Color.Black
            Case 3 ' maroon
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
                ItemDescInfo = "N/A"
                ItemDescType = "N/A"
            Case ItemType.Weapon
                ItemDescInfo = "Damage: " & Item(itemnum).Data2
                ItemDescType = "Weapon"
            Case ItemType.Armor
                ItemDescInfo = "Defence: " & Item(itemnum).Data2
                ItemDescType = "Armor"
            Case ItemType.Helmet
                ItemDescInfo = "Defence: " & Item(itemnum).Data2
                ItemDescType = "Helmet"
            Case ItemType.Shield
                ItemDescInfo = "Defence: " & Item(itemnum).Data2
                ItemDescType = "Shield"
            Case ItemType.Shoes
                ItemDescInfo = "Defence: " & Item(itemnum).Data2
                ItemDescType = "Shoes"
            Case ItemType.Gloves
                ItemDescInfo = "Defence: " & Item(itemnum).Data2
                ItemDescType = "Gloves"
            Case ItemType.PotionHp
                ItemDescInfo = "Restore Amount: " & Item(itemnum).Data2
                ItemDescType = "Potion"
            Case ItemType.PotionMp
                ItemDescInfo = "Restore Amount: " & Item(itemnum).Data2
                ItemDescType = "Potion"
            Case ItemType.PotionSp
                ItemDescInfo = "Restore Amount: " & Item(itemnum).Data2
            Case ItemType.PoisonHp
                ItemDescInfo = "Damage Amount: " & Item(itemnum).Data2
            Case ItemType.PoisonMp
                ItemDescInfo = "Damage Amount: " & Item(itemnum).Data2
            Case ItemType.PoisonSp
                ItemDescInfo = "Damage Amount: " & Item(itemnum).Data2
            Case ItemType.Key
                ItemDescInfo = "N/A"
                ItemDescType = "Key"
            Case ItemType.Currency
                ItemDescInfo = "N/A"
                ItemDescType = "Currency"
            Case ItemType.Skill
                ItemDescInfo = "N/A"
                ItemDescType = "Skill"
            Case ItemType.Furniture
                ItemDescInfo = "Furniture"
        End Select

        ' Currency
        ItemDescCost = Item(itemnum).Price & "g"

        ' If currency, exit out before all the other shit
        If Item(itemnum).Type = ItemType.Currency Or Item(itemnum).Type = ItemType.None Then
            ' Clear other labels
            ItemDescLevel = "N/A"
            ItemDescSpeed = "N/A"

            ItemDescStr = "N/A"
            ItemDescEnd = "N/A"
            ItemDescInt = "N/A"
            ItemDescSpr = "N/A"
            ItemDescVit = "N/A"
            ItemDescLuck = "N/A"
            Exit Sub
        End If

        ' Potions + crap
        ItemDescLevel = Item(itemnum).LevelReq

        ' Exit out for everything else 'scept equipment
        If Item(itemnum).Type < ItemType.Weapon Or Item(itemnum).Type > ItemType.Gloves Then
            ' Clear other labels
            ItemDescSpeed = "N/A"

            ItemDescStr = "N/A"
            ItemDescEnd = "N/A"
            ItemDescInt = "N/A"
            ItemDescSpr = "N/A"
            ItemDescVit = "N/A"
            ItemDescLuck = "N/A"
            Exit Sub
        End If

        ' Equipment specific
        If Item(itemnum).Add_Stat(Stats.strength) > 0 Then
            ItemDescStr = "+" & Item(itemnum).Add_Stat(Stats.strength)
        Else
            ItemDescStr = "None"
        End If

        If Item(itemnum).Add_Stat(Stats.Vitality) > 0 Then
            ItemDescVit = "+" & Item(itemnum).Add_Stat(Stats.Vitality)
        Else
            ItemDescVit = "None"
        End If

        If Item(itemnum).Add_Stat(Stats.intelligence) > 0 Then
            ItemDescInt = "+" & Item(itemnum).Add_Stat(Stats.intelligence)
        Else
            ItemDescInt = "None"
        End If

        If Item(itemnum).Add_Stat(Stats.Endurance) > 0 Then
            ItemDescEnd = "+" & Item(itemnum).Add_Stat(Stats.Endurance)
        Else
            ItemDescEnd = "None"
        End If

        If Item(itemnum).Add_Stat(Stats.Luck) > 0 Then
            ItemDescLuck = "+" & Item(itemnum).Add_Stat(Stats.Luck)
        Else
            ItemDescLuck = "None"
        End If

        If Item(itemnum).Add_Stat(Stats.Speed) > 0 Then
            ItemDescSpr = "+" & Item(itemnum).Add_Stat(Stats.Speed)
        Else
            ItemDescSpr = "None"
        End If

        If Item(itemnum).Type = ItemType.Weapon Then
            ItemDescSpeed = Item(itemnum).Speed / 1000 & " secs"
        Else
            ItemDescSpeed = "N/A"
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
                SkillDescType = "Damage HP"
                SkillDescVital = "Damage:"
            Case SkillType.DamageMp
                SkillDescType = "Damage MP"
                SkillDescVital = "Damage:"
            Case SkillType.HealHp
                SkillDescType = "Heal HP"
                SkillDescVital = "Heal:"
            Case SkillType.HealMp
                SkillDescType = "Heal MP"
                SkillDescVital = "Heal:"
            Case SkillType.Warp
                SkillDescType = "Warp"
        End Select

        SkillDescReqMp = Skill(skillnum).MPCost
        SkillDescReqLvl = Skill(skillnum).LevelReq
        SkillDescReqAccess = Skill(skillnum).AccessReq

        If Skill(skillnum).ClassReq > 0 Then
            SkillDescReqClass = Trim$(Classes(Skill(skillnum).ClassReq).Name)
        Else
            SkillDescReqClass = "None"
        End If

        SkillDescCastTime = Skill(skillnum).CastTime & "s"
        SkillDescCoolDown = Skill(skillnum).CDTime & "s"
        SkillDescDamage = Skill(skillnum).Vital

        If Skill(skillnum).IsAoE Then
            SkillDescAOE = Skill(skillnum).AoE & " tiles."
        Else
            SkillDescAOE = "No"
        End If

        If Skill(skillnum).Range > 0 Then
            SkillDescRange = Skill(skillnum).Range & " tiles."
        Else
            SkillDescRange = "Self-cast"
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
        Dim width As Integer
        width = g.MeasureString(Trim$(Map.Name), New Font(FONT_NAME, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width
        DrawMapNameX = ((SCREEN_MAPX + 1) * PIC_X / 2) - width + 32
        DrawMapNameY = 1

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
