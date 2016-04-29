Public Module ServerEventLogic
    Public Sub RemoveDeadEvents()
        Dim i As Long, MapNum As Long, Buffer As ByteBuffer, x As Long, id As Long, page As Long, compare As Long

        If Gettingmap = True Then Exit Sub

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) = False Then TempPlayer(i).EventMap.CurrentEvents = 0 : Exit Sub
            MapNum = GetPlayerMap(i)
            If TempPlayer(i).EventMap.CurrentEvents > 0 And Map(MapNum).Events IsNot Nothing Then
                MapNum = GetPlayerMap(i)
                For x = 1 To TempPlayer(i).EventMap.CurrentEvents
                    id = TempPlayer(i).EventMap.EventPages(x).EventID
                    page = TempPlayer(i).EventMap.EventPages(x).PageID
                    If Map(MapNum).Events(id).PageCount >= page Then

                        'See if there is any reason to delete this event....
                        'In other words, go back through conditions and make sure they all check up.
                        If TempPlayer(i).EventMap.EventPages(x).Visible = 1 Then
                            If Map(MapNum).Events(id).Pages(page).chkHasItem = 1 Then
                                If HasItem(i, Map(MapNum).Events(id).Pages(page).HasItemIndex) = 0 Then
                                    TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                End If
                            End If



                            If Map(MapNum).Events(id).Pages(page).chkSelfSwitch = 1 Then
                                If Map(MapNum).Events(id).Pages(page).SelfSwitchCompare = 0 Then
                                    compare = 1
                                Else
                                    compare = 0
                                End If
                                If Map(MapNum).Events(id).Globals = 1 Then
                                    If Map(MapNum).Events(id).SelfSwitches(Map(MapNum).Events(id).Pages(page).SelfSwitchIndex) <> compare Then
                                        TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                    End If
                                Else
                                    If TempPlayer(i).EventMap.EventPages(id).SelfSwitches(Map(MapNum).Events(id).Pages(page).SelfSwitchIndex) <> compare Then
                                        TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                    End If
                                End If
                            End If

                            If Map(MapNum).Events(id).Pages(page).chkVariable = 1 Then
                                Select Case Map(MapNum).Events(id).Pages(page).VariableCompare
                                    Case 0
                                        If Player(i).Variables(Map(MapNum).Events(id).Pages(page).VariableIndex) <> Map(MapNum).Events(id).Pages(page).VariableCondition Then
                                            TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                        End If
                                    Case 1
                                        If Player(i).Variables(Map(MapNum).Events(id).Pages(page).VariableIndex) < Map(MapNum).Events(id).Pages(page).VariableCondition Then
                                            TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                        End If
                                    Case 2
                                        If Player(i).Variables(Map(MapNum).Events(id).Pages(page).VariableIndex) > Map(MapNum).Events(id).Pages(page).VariableCondition Then
                                            TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                        End If
                                    Case 3
                                        If Player(i).Variables(Map(MapNum).Events(id).Pages(page).VariableIndex) <= Map(MapNum).Events(id).Pages(page).VariableCondition Then
                                            TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                        End If
                                    Case 4
                                        If Player(i).Variables(Map(MapNum).Events(id).Pages(page).VariableIndex) >= Map(MapNum).Events(id).Pages(page).VariableCondition Then
                                            TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                        End If
                                    Case 5
                                        If Player(i).Variables(Map(MapNum).Events(id).Pages(page).VariableIndex) = Map(MapNum).Events(id).Pages(page).VariableCondition Then
                                            TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                        End If
                                End Select
                            End If

                            If Map(MapNum).Events(id).Pages(page).chkSwitch = 1 Then
                                If Map(MapNum).Events(id).Pages(page).SwitchCompare = 1 Then 'we expect true
                                    If Player(i).Switches(Map(MapNum).Events(id).Pages(page).SwitchIndex) = 0 Then ' we see false so we despawn the event
                                        TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                    End If
                                Else
                                    If Player(i).Switches(Map(MapNum).Events(id).Pages(page).SwitchIndex) = 1 Then ' we expect false and we see true so we despawn the event
                                        TempPlayer(i).EventMap.EventPages(x).Visible = 0
                                    End If
                                End If
                            End If

                            If Map(MapNum).Events(id).Globals = 1 And TempPlayer(i).EventMap.EventPages(x).Visible = 0 Then TempEventMap(MapNum).Events(id).Active = 0

                            If TempPlayer(i).EventMap.EventPages(x).Visible = 0 Then
                                Buffer = New ByteBuffer
                                Buffer.WriteLong(ServerPackets.SSpawnEvent)
                                Buffer.WriteLong(id)
                                With TempPlayer(i).EventMap.EventPages(x)
                                    Buffer.WriteString(Trim(Map(GetPlayerMap(i)).Events(.EventID).Name))
                                    Buffer.WriteLong(.Dir)
                                    Buffer.WriteLong(.GraphicNum)
                                    Buffer.WriteLong(.GraphicType)
                                    Buffer.WriteLong(.GraphicX)
                                    Buffer.WriteLong(.GraphicX2)
                                    Buffer.WriteLong(.GraphicY)
                                    Buffer.WriteLong(.GraphicY2)
                                    Buffer.WriteLong(.MovementSpeed)
                                    Buffer.WriteLong(.X)
                                    Buffer.WriteLong(.Y)
                                    Buffer.WriteLong(.Position)
                                    Buffer.WriteLong(.Visible)
                                    Buffer.WriteLong(Map(MapNum).Events(id).Pages(page).WalkAnim)
                                    Buffer.WriteLong(Map(MapNum).Events(id).Pages(page).DirFix)
                                    Buffer.WriteLong(Map(MapNum).Events(id).Pages(page).WalkThrough)
                                    Buffer.WriteLong(Map(MapNum).Events(id).Pages(page).ShowName)
                                    Buffer.WriteLong(.QuestNum)
                                End With
                                SendDataTo(i, Buffer.ToArray)
                                Buffer = Nothing
                            End If
                        End If
                    End If
                Next
            End If
        Next

    End Sub

    Public Sub SpawnNewEvents()
        Dim Buffer As ByteBuffer, pageID As Long, id As Long, compare As Long, i As Long, MapNum As Long
        Dim n As Long, x As Long, z As Long, spawnevent As Boolean, p As Long

        If Gettingmap = True Then Exit Sub

        'That was only removing events... now we gotta worry about spawning them again, luckily, it is almost the same exact thing, but backwards!

        For i = 1 To MAX_PLAYERS
            If TempPlayer(i).EventMap.CurrentEvents > 0 Then
                MapNum = GetPlayerMap(i)
                If MapNum = 0 Then Exit Sub
                For x = 1 To TempPlayer(i).EventMap.CurrentEvents
                    id = TempPlayer(i).EventMap.EventPages(x).EventID
                    pageID = TempPlayer(i).EventMap.EventPages(x).PageID
                    If TempPlayer(i).EventMap.EventPages(x).Visible = 0 Then pageID = 0
                    If (Map(MapNum).Events Is Nothing) Then Continue For
                    For z = Map(MapNum).Events(id).PageCount To 1 Step -1

                        spawnevent = True

                        If Map(MapNum).Events(id).Pages(z).chkHasItem = 1 Then
                            If HasItem(i, Map(MapNum).Events(id).Pages(z).HasItemIndex) = 0 Then
                                spawnevent = False
                            End If
                        End If

                        If Map(MapNum).Events(id).Pages(z).chkSelfSwitch = 1 Then
                            If Map(MapNum).Events(id).Pages(z).SelfSwitchCompare = 0 Then
                                compare = 1
                            Else
                                compare = 0
                            End If
                            If Map(MapNum).Events(id).Globals = 1 Then
                                If Map(MapNum).Events(id).SelfSwitches(Map(MapNum).Events(id).Pages(z).SelfSwitchIndex) <> compare Then
                                    spawnevent = False
                                End If
                            Else
                                If TempPlayer(i).EventMap.EventPages(id).SelfSwitches(Map(MapNum).Events(id).Pages(z).SelfSwitchIndex) <> compare Then
                                    spawnevent = False
                                End If
                            End If
                        End If


                        If Map(MapNum).Events(id).Pages(z).chkVariable = 1 Then
                            Select Case Map(MapNum).Events(id).Pages(z).VariableCompare
                                Case 0
                                    If Player(i).Variables(Map(MapNum).Events(id).Pages(z).VariableIndex) <> Map(MapNum).Events(id).Pages(z).VariableCondition Then
                                        spawnevent = False
                                    End If
                                Case 1
                                    If Player(i).Variables(Map(MapNum).Events(id).Pages(z).VariableIndex) < Map(MapNum).Events(id).Pages(z).VariableCondition Then
                                        spawnevent = False
                                    End If
                                Case 2
                                    If Player(i).Variables(Map(MapNum).Events(id).Pages(z).VariableIndex) > Map(MapNum).Events(id).Pages(z).VariableCondition Then
                                        spawnevent = False
                                    End If
                                Case 3
                                    If Player(i).Variables(Map(MapNum).Events(id).Pages(z).VariableIndex) <= Map(MapNum).Events(id).Pages(z).VariableCondition Then
                                        spawnevent = False
                                    End If
                                Case 4
                                    If Player(i).Variables(Map(MapNum).Events(id).Pages(z).VariableIndex) >= Map(MapNum).Events(id).Pages(z).VariableCondition Then
                                        spawnevent = False
                                    End If
                                Case 5
                                    If Player(i).Variables(Map(MapNum).Events(id).Pages(z).VariableIndex) = Map(MapNum).Events(id).Pages(z).VariableCondition Then
                                        spawnevent = False
                                    End If
                            End Select
                        End If

                        If Map(MapNum).Events(id).Pages(z).chkSwitch = 1 Then
                            If Map(MapNum).Events(id).Pages(z).SwitchCompare = 0 Then 'we want false 
                                If Player(i).Switches(Map(MapNum).Events(id).Pages(z).SwitchIndex) = 1 Then 'and switch is true
                                    spawnevent = False 'do not spawn
                                End If
                            Else
                                If Player(i).Switches(Map(MapNum).Events(id).Pages(z).SwitchIndex) = 0 Then ' else we want true and the switch is false
                                    spawnevent = False
                                End If
                            End If
                        End If

                        If spawnevent = True Then
                            If TempPlayer(i).EventMap.EventPages(x).Visible = 1 Then
                                If z <= pageID Then
                                    spawnevent = False
                                End If
                            End If
                        End If

                        If spawnevent = True Then

                            If TempPlayer(i).EventProcessingCount > 0 Then
                                For n = 1 To UBound(TempPlayer(i).EventProcessing)
                                    If TempPlayer(i).EventProcessing(n).EventID = id Then
                                        TempPlayer(i).EventProcessing(n).Active = 0
                                    End If
                                Next
                            End If


                            With TempPlayer(i).EventMap.EventPages(id)
                                If Map(MapNum).Events(id).Pages(z).GraphicType = 1 Then
                                    Select Case Map(MapNum).Events(id).Pages(z).GraphicY
                                        Case 0
                                            .Dir = DIR_DOWN
                                        Case 1
                                            .Dir = DIR_LEFT
                                        Case 2
                                            .Dir = DIR_RIGHT
                                        Case 3
                                            .Dir = DIR_UP
                                    End Select
                                Else
                                    .Dir = 0
                                End If
                                .GraphicNum = Map(MapNum).Events(id).Pages(z).Graphic
                                .GraphicType = Map(MapNum).Events(id).Pages(z).GraphicType
                                .GraphicX = Map(MapNum).Events(id).Pages(z).GraphicX
                                .GraphicY = Map(MapNum).Events(id).Pages(z).GraphicY
                                .GraphicX2 = Map(MapNum).Events(id).Pages(z).GraphicX2
                                .GraphicY2 = Map(MapNum).Events(id).Pages(z).GraphicY2
                                .QuestNum = Map(MapNum).Events(id).Pages(z).QuestNum
                                Select Case Map(MapNum).Events(id).Pages(z).MoveSpeed
                                    Case 0
                                        .MovementSpeed = 2
                                    Case 1
                                        .MovementSpeed = 3
                                    Case 2
                                        .MovementSpeed = 4
                                    Case 3
                                        .MovementSpeed = 6
                                    Case 4
                                        .MovementSpeed = 12
                                    Case 5
                                        .MovementSpeed = 24
                                End Select
                                .Position = Map(MapNum).Events(id).Pages(z).Position
                                .EventID = id
                                .PageID = z
                                .Visible = 1

                                .MoveType = Map(MapNum).Events(id).Pages(z).MoveType
                                If .MoveType = 2 Then
                                    .MoveRouteCount = Map(MapNum).Events(id).Pages(z).MoveRouteCount
                                    If .MoveRouteCount > 0 Then
                                        ReDim .MoveRoute(0 To Map(MapNum).Events(id).Pages(z).MoveRouteCount)
                                        For p = 0 To Map(MapNum).Events(id).Pages(z).MoveRouteCount
                                            .MoveRoute(p) = Map(MapNum).Events(id).Pages(z).MoveRoute(p)
                                        Next
                                        .MoveRouteComplete = 0
                                    Else
                                        .MoveRouteComplete = 1
                                    End If
                                Else
                                    .MoveRouteComplete = 1
                                End If

                                .RepeatMoveRoute = Map(MapNum).Events(id).Pages(z).RepeatMoveRoute
                                .IgnoreIfCannotMove = Map(MapNum).Events(id).Pages(z).IgnoreMoveRoute

                                .MoveFreq = Map(MapNum).Events(id).Pages(z).MoveFreq
                                .MoveSpeed = Map(MapNum).Events(id).Pages(z).MoveSpeed

                                .WalkThrough = Map(MapNum).Events(id).Pages(z).WalkThrough
                                .ShowName = Map(MapNum).Events(id).Pages(z).ShowName
                                .WalkingAnim = Map(MapNum).Events(id).Pages(z).WalkAnim
                                .FixedDir = Map(MapNum).Events(id).Pages(z).DirFix


                            End With

                            If Map(MapNum).Events(id).Globals = 1 Then
                                If spawnevent Then TempEventMap(MapNum).Events(id).Active = z : TempEventMap(MapNum).Events(id).Position = Map(MapNum).Events(id).Pages(z).Position
                            End If



                            Buffer = New ByteBuffer
                            Buffer.WriteLong(ServerPackets.SSpawnEvent)
                            Buffer.WriteLong(id)
                            With TempPlayer(i).EventMap.EventPages(x)
                                Buffer.WriteString(Trim(Map(GetPlayerMap(i)).Events(.EventID).Name))
                                Buffer.WriteLong(.Dir)
                                Buffer.WriteLong(.GraphicNum)
                                Buffer.WriteLong(.GraphicType)
                                Buffer.WriteLong(.GraphicX)
                                Buffer.WriteLong(.GraphicX2)
                                Buffer.WriteLong(.GraphicY)
                                Buffer.WriteLong(.GraphicY2)
                                Buffer.WriteLong(.MovementSpeed)
                                Buffer.WriteLong(.X)
                                Buffer.WriteLong(.Y)
                                Buffer.WriteLong(.Position)
                                Buffer.WriteLong(.Visible)
                                Buffer.WriteLong(Map(MapNum).Events(id).Pages(z).WalkAnim)
                                Buffer.WriteLong(Map(MapNum).Events(id).Pages(z).DirFix)
                                Buffer.WriteLong(Map(MapNum).Events(id).Pages(z).WalkThrough)
                                Buffer.WriteLong(Map(MapNum).Events(id).Pages(z).ShowName)
                                Buffer.WriteLong(Map(MapNum).Events(id).Pages(z).QuestNum)
                                Buffer.WriteLong(.QuestNum)
                            End With
                            SendDataTo(i, Buffer.ToArray)
                            Buffer = Nothing
                            z = 1
                        End If
                    Next
                Next
            End If
        Next

    End Sub

    Public Sub ProcessEventMovement()
        Dim rand As Long, x As Long, i As Long, playerID As Long, eventID As Long, WalkThrough As Long, isglobal As Boolean, MapNum As Long
        Dim actualmovespeed As Long, Buffer As ByteBuffer, z As Long, sendupdate As Boolean
        Dim donotprocessmoveroute As Boolean, pageNum As Long

        If Gettingmap = True Then Exit Sub

        'Process Movement if needed for each player/each map/each event....

        For i = 1 To MAX_MAPS
            If PlayersOnMap(i) Then
                'Manage Global Events First, then all the others.....
                If TempEventMap(i).EventCount > 0 Then
                    For x = 1 To TempEventMap(i).EventCount
                        If TempEventMap(i).Events(x).Active > 0 Then
                            pageNum = 1
                            If TempEventMap(i).Events(x).MoveTimer <= GetTickCount() Then
                                'Real event! Lets process it!
                                Select Case TempEventMap(i).Events(x).MoveType
                                    Case 0
                                        'Nothing, fixed position
                                    Case 1 'Random, move randomly if possible...
                                        rand = Random(0, 3)
                                        If CanEventMove(0, i, TempEventMap(i).Events(x).X, TempEventMap(i).Events(x).Y, x, TempEventMap(i).Events(x).WalkThrough, rand, True) Then
                                            Select Case TempEventMap(i).Events(x).MoveSpeed
                                                Case 0
                                                    EventMove(0, i, x, rand, 2, True)
                                                Case 1
                                                    EventMove(0, i, x, rand, 3, True)
                                                Case 2
                                                    EventMove(0, i, x, rand, 4, True)
                                                Case 3
                                                    EventMove(0, i, x, rand, 6, True)
                                                Case 4
                                                    EventMove(0, i, x, rand, 12, True)
                                                Case 5
                                                    EventMove(0, i, x, rand, 24, True)
                                            End Select
                                        Else
                                            EventDir(0, i, x, rand, True)
                                        End If
                                    Case 2 'Move Route
                                        With TempEventMap(i).Events(x)
                                            isglobal = True
                                            MapNum = i
                                            playerID = 0
                                            eventID = x
                                            WalkThrough = TempEventMap(i).Events(x).WalkThrough
                                            If .MoveRouteCount > 0 Then
                                                If .MoveRouteStep >= .MoveRouteCount And .RepeatMoveRoute = 1 Then
                                                    .MoveRouteStep = 0
                                                    .MoveRouteComplete = 1
                                                ElseIf .MoveRouteStep >= .MoveRouteCount And .RepeatMoveRoute = 0 Then
                                                    donotprocessmoveroute = True
                                                    .MoveRouteComplete = 1
                                                Else
                                                    .MoveRouteComplete = 0
                                                End If
                                                If donotprocessmoveroute = False Then
                                                    .MoveRouteStep = .MoveRouteStep + 1
                                                    Select Case .MoveSpeed
                                                        Case 0
                                                            actualmovespeed = 2
                                                        Case 1
                                                            actualmovespeed = 3
                                                        Case 2
                                                            actualmovespeed = 4
                                                        Case 3
                                                            actualmovespeed = 6
                                                        Case 4
                                                            actualmovespeed = 12
                                                        Case 5
                                                            actualmovespeed = 24
                                                    End Select
                                                    Select Case .MoveRoute(.MoveRouteStep).Index
                                                        Case 1
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_UP, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, DIR_UP, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 2
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_DOWN, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, DIR_DOWN, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 3
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_LEFT, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, DIR_LEFT, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 4
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_RIGHT, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, DIR_RIGHT, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 5
                                                            z = Random(0, 3)
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 6
                                                            If isglobal = False Then
                                                                If IsOneBlockAway(.X, .Y, GetPlayerX(playerID), GetPlayerY(playerID)) = True Then
                                                                    EventDir(playerID, GetPlayerMap(playerID), eventID, GetDirToPlayer(playerID, GetPlayerMap(playerID), eventID), False)
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                Else
                                                                    z = CanEventMoveTowardsPlayer(playerID, MapNum, eventID)
                                                                    If z >= 4 Then
                                                                        'No
                                                                        If .IgnoreIfCannotMove = 0 Then
                                                                            .MoveRouteStep = .MoveRouteStep - 1
                                                                        End If
                                                                    Else
                                                                        'i is the direct, lets go...
                                                                        If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                            EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                                        Else
                                                                            If .IgnoreIfCannotMove = 0 Then
                                                                                .MoveRouteStep = .MoveRouteStep - 1
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        Case 7
                                                            If isglobal = False Then
                                                                z = CanEventMoveAwayFromPlayer(playerID, MapNum, eventID)
                                                                If z >= 5 Then
                                                                    'No
                                                                Else
                                                                    'i is the direct, lets go...
                                                                    If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                        EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                                    Else
                                                                        If .IgnoreIfCannotMove = 0 Then
                                                                            .MoveRouteStep = .MoveRouteStep - 1
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        Case 8
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, .Dir, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, .Dir, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 9
                                                            Select Case .Dir
                                                                Case DIR_UP
                                                                    z = DIR_DOWN
                                                                Case DIR_DOWN
                                                                    z = DIR_UP
                                                                Case DIR_LEFT
                                                                    z = DIR_RIGHT
                                                                Case DIR_RIGHT
                                                                    z = DIR_LEFT
                                                            End Select
                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                            Else
                                                                If .IgnoreIfCannotMove = 0 Then
                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                End If
                                                            End If
                                                        Case 10
                                                            .MoveTimer = GetTickCount() + 100
                                                        Case 11
                                                            .MoveTimer = GetTickCount() + 500
                                                        Case 12
                                                            .MoveTimer = GetTickCount() + 1000
                                                        Case 13
                                                            EventDir(playerID, MapNum, eventID, DIR_UP, isglobal)
                                                        Case 14
                                                            EventDir(playerID, MapNum, eventID, DIR_DOWN, isglobal)
                                                        Case 15
                                                            EventDir(playerID, MapNum, eventID, DIR_LEFT, isglobal)
                                                        Case 16
                                                            EventDir(playerID, MapNum, eventID, DIR_RIGHT, isglobal)
                                                        Case 17
                                                            Select Case .Dir
                                                                Case DIR_UP
                                                                    z = DIR_RIGHT
                                                                Case DIR_RIGHT
                                                                    z = DIR_DOWN
                                                                Case DIR_LEFT
                                                                    z = DIR_UP
                                                                Case DIR_DOWN
                                                                    z = DIR_LEFT
                                                            End Select
                                                            EventDir(playerID, MapNum, eventID, z, isglobal)
                                                        Case 18
                                                            Select Case .Dir
                                                                Case DIR_UP
                                                                    z = DIR_LEFT
                                                                Case DIR_RIGHT
                                                                    z = DIR_UP
                                                                Case DIR_LEFT
                                                                    z = DIR_DOWN
                                                                Case DIR_DOWN
                                                                    z = DIR_RIGHT
                                                            End Select
                                                            EventDir(playerID, MapNum, eventID, z, isglobal)
                                                        Case 19
                                                            Select Case .Dir
                                                                Case DIR_UP
                                                                    z = DIR_DOWN
                                                                Case DIR_RIGHT
                                                                    z = DIR_LEFT
                                                                Case DIR_LEFT
                                                                    z = DIR_RIGHT
                                                                Case DIR_DOWN
                                                                    z = DIR_UP
                                                            End Select
                                                            EventDir(playerID, MapNum, eventID, z, isglobal)
                                                        Case 20
                                                            z = Random(0, 3)
                                                            EventDir(playerID, MapNum, eventID, z, isglobal)
                                                        Case 21
                                                            If isglobal = False Then
                                                                z = GetDirToPlayer(playerID, MapNum, eventID)
                                                                EventDir(playerID, MapNum, eventID, z, isglobal)
                                                            End If
                                                        Case 22
                                                            If isglobal = False Then
                                                                z = GetDirAwayFromPlayer(playerID, MapNum, eventID)
                                                                EventDir(playerID, MapNum, eventID, z, isglobal)
                                                            End If
                                                        Case 23
                                                            .MoveSpeed = 0
                                                        Case 24
                                                            .MoveSpeed = 1
                                                        Case 25
                                                            .MoveSpeed = 2
                                                        Case 26
                                                            .MoveSpeed = 3
                                                        Case 27
                                                            .MoveSpeed = 4
                                                        Case 28
                                                            .MoveSpeed = 5
                                                        Case 29
                                                            .MoveFreq = 0
                                                        Case 30
                                                            .MoveFreq = 1
                                                        Case 31
                                                            .MoveFreq = 2
                                                        Case 32
                                                            .MoveFreq = 3
                                                        Case 33
                                                            .MoveFreq = 4
                                                        Case 34
                                                            .WalkingAnim = 1
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 35
                                                            .WalkingAnim = 0
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 36
                                                            .FixedDir = 1
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 37
                                                            .FixedDir = 0
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 38
                                                            .WalkThrough = 1
                                                        Case 39
                                                            .WalkThrough = 0
                                                        Case 40
                                                            .Position = 0
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 41
                                                            .Position = 1
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 42
                                                            .Position = 2
                                                            'Need to send update to client
                                                            sendupdate = True
                                                        Case 43
                                                            .GraphicType = .MoveRoute(.MoveRouteStep).Data1
                                                            .GraphicNum = .MoveRoute(.MoveRouteStep).Data2
                                                            .GraphicX = .MoveRoute(.MoveRouteStep).Data3
                                                            .GraphicX2 = .MoveRoute(.MoveRouteStep).Data4
                                                            .GraphicY = .MoveRoute(.MoveRouteStep).Data5
                                                            .GraphicY2 = .MoveRoute(.MoveRouteStep).Data6
                                                            If .GraphicType = 1 Then
                                                                Select Case .GraphicY
                                                                    Case 0
                                                                        .Dir = DIR_DOWN
                                                                    Case 1
                                                                        .Dir = DIR_LEFT
                                                                    Case 2
                                                                        .Dir = DIR_RIGHT
                                                                    Case 3
                                                                        .Dir = DIR_UP
                                                                End Select
                                                            End If
                                                            'Need to Send Update to client
                                                            sendupdate = True
                                                    End Select

                                                    If sendupdate Then
                                                        Buffer = New ByteBuffer
                                                        Buffer.WriteLong(ServerPackets.SSpawnEvent)
                                                        Buffer.WriteLong(eventID)
                                                        With TempEventMap(i).Events(x)
                                                            Buffer.WriteString(Trim(Map(i).Events(x).Name))
                                                            Buffer.WriteLong(.Dir)
                                                            Buffer.WriteLong(.GraphicNum)
                                                            Buffer.WriteLong(.GraphicType)
                                                            Buffer.WriteLong(.GraphicX)
                                                            Buffer.WriteLong(.GraphicX2)
                                                            Buffer.WriteLong(.GraphicY)
                                                            Buffer.WriteLong(.GraphicY2)
                                                            Buffer.WriteLong(.MoveSpeed)
                                                            Buffer.WriteLong(.X)
                                                            Buffer.WriteLong(.Y)
                                                            Buffer.WriteLong(.Position)
                                                            Buffer.WriteLong(.Active)
                                                            Buffer.WriteLong(.WalkingAnim)
                                                            Buffer.WriteLong(.FixedDir)
                                                            Buffer.WriteLong(.WalkThrough)
                                                            Buffer.WriteLong(.ShowName)
                                                            Buffer.WriteLong(.QuestNum)
                                                        End With
                                                        SendDataToMap(i, Buffer.ToArray)
                                                        Buffer = Nothing
                                                    End If
                                                End If
                                                donotprocessmoveroute = False
                                            End If
                                        End With
                                End Select

                                Select Case TempEventMap(i).Events(x).MoveFreq
                                    Case 0
                                        TempEventMap(i).Events(x).MoveTimer = GetTickCount() + 4000
                                    Case 1
                                        TempEventMap(i).Events(x).MoveTimer = GetTickCount() + 2000
                                    Case 2
                                        TempEventMap(i).Events(x).MoveTimer = GetTickCount() + 1000
                                    Case 3
                                        TempEventMap(i).Events(x).MoveTimer = GetTickCount() + 500
                                    Case 4
                                        TempEventMap(i).Events(x).MoveTimer = GetTickCount() + 250
                                End Select
                            End If
                        End If
                    Next
                End If
            End If
            DoEvents()
        Next

    End Sub

    Public Sub ProcessLocalEventMovement()
        Dim rand As Long, x As Long, i As Long, playerID As Long, eventID As Long, WalkThrough As Long
        Dim isglobal As Boolean, MapNum As Long, actualmovespeed As Long, Buffer As ByteBuffer, z As Long, sendupdate As Boolean
        Dim donotprocessmoveroute As Boolean

        If Gettingmap = True Then Exit Sub

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                playerID = i
                If TempPlayer(i).EventMap.CurrentEvents > 0 Then
                    For x = 1 To TempPlayer(i).EventMap.CurrentEvents
                        If Map(GetPlayerMap(i)).Events Is Nothing Then Continue For
                        If Map(GetPlayerMap(i)).Events(TempPlayer(i).EventMap.EventPages(x).EventID).Globals = 0 Then
                            If TempPlayer(i).EventMap.EventPages(x).Visible = 1 Then
                                If TempPlayer(i).EventMap.EventPages(x).MoveTimer <= GetTickCount() Then
                                    'Real event! Lets process it!
                                    Select Case TempPlayer(i).EventMap.EventPages(x).MoveType
                                        Case 0
                                            'Nothing, fixed position
                                        Case 1 'Random, move randomly if possible...
                                            rand = Random(0, 3)
                                            playerID = i
                                            If CanEventMove(i, GetPlayerMap(i), TempPlayer(i).EventMap.EventPages(x).X, TempPlayer(i).EventMap.EventPages(x).Y, x, TempPlayer(i).EventMap.EventPages(x).WalkThrough, rand, False) Then
                                                Select Case TempPlayer(i).EventMap.EventPages(x).MoveSpeed
                                                    Case 0
                                                        EventMove(i, GetPlayerMap(i), x, rand, 2, False)
                                                    Case 1
                                                        EventMove(i, GetPlayerMap(i), x, rand, 3, False)
                                                    Case 2
                                                        EventMove(i, GetPlayerMap(i), x, rand, 4, False)
                                                    Case 3
                                                        EventMove(i, GetPlayerMap(i), x, rand, 6, False)
                                                    Case 4
                                                        EventMove(i, GetPlayerMap(i), x, rand, 12, False)
                                                    Case 5
                                                        EventMove(i, GetPlayerMap(i), x, rand, 24, False)
                                                End Select
                                            Else
                                                EventDir(0, GetPlayerMap(i), x, rand, True)
                                            End If
                                        Case 2 'Move Route - later!
                                            With TempPlayer(i).EventMap.EventPages(x)
                                                isglobal = False
                                                sendupdate = False
                                                MapNum = GetPlayerMap(i)
                                                playerID = i
                                                eventID = x
                                                WalkThrough = .WalkThrough
                                                If .MoveRouteCount > 0 Then
                                                    If .MoveRouteStep >= .MoveRouteCount And .RepeatMoveRoute = 1 Then
                                                        .MoveRouteStep = 0
                                                        .MoveRouteComplete = 1
                                                    ElseIf .MoveRouteStep >= .MoveRouteCount And .RepeatMoveRoute = 0 Then
                                                        donotprocessmoveroute = True
                                                        .MoveRouteComplete = 1
                                                    Else
                                                        .MoveRouteComplete = 0
                                                    End If
                                                    If donotprocessmoveroute = False Then
                                                        .MoveRouteStep = .MoveRouteStep + 1
                                                        Select Case .MoveSpeed
                                                            Case 0
                                                                actualmovespeed = 2
                                                            Case 1
                                                                actualmovespeed = 3
                                                            Case 2
                                                                actualmovespeed = 4
                                                            Case 3
                                                                actualmovespeed = 6
                                                            Case 4
                                                                actualmovespeed = 12
                                                            Case 5
                                                                actualmovespeed = 24
                                                        End Select
                                                        Select Case .MoveRoute(.MoveRouteStep).Index
                                                            Case 1
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_UP, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, DIR_UP, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 2
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_DOWN, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, DIR_DOWN, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 3
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_LEFT, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, DIR_LEFT, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 4
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, DIR_RIGHT, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, DIR_RIGHT, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 5
                                                                z = Random(0, 3)
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 6
                                                                If isglobal = False Then
                                                                    If IsOneBlockAway(.X, .Y, GetPlayerX(playerID), GetPlayerY(playerID)) = True Then
                                                                        EventDir(playerID, GetPlayerMap(playerID), eventID, GetDirToPlayer(playerID, GetPlayerMap(playerID), eventID), False)
                                                                        'Lets do cool stuff!
                                                                        If Map(GetPlayerMap(playerID)).Events(eventID).Pages(TempPlayer(playerID).EventMap.EventPages(eventID).PageID).Trigger = 1 Then
                                                                            If Map(MapNum).Events(eventID).Pages(TempPlayer(playerID).EventMap.EventPages(eventID).PageID).CommandListCount > 0 Then
                                                                                TempPlayer(playerID).EventProcessing(eventID).Active = 1
                                                                                TempPlayer(playerID).EventProcessing(eventID).ActionTimer = GetTickCount()
                                                                                TempPlayer(playerID).EventProcessing(eventID).CurList = 1
                                                                                TempPlayer(playerID).EventProcessing(eventID).CurSlot = 1
                                                                                TempPlayer(playerID).EventProcessing(eventID).EventID = eventID
                                                                                TempPlayer(playerID).EventProcessing(eventID).PageID = TempPlayer(playerID).EventMap.EventPages(eventID).PageID
                                                                                TempPlayer(playerID).EventProcessing(eventID).WaitingForResponse = 0
                                                                                ReDim TempPlayer(playerID).EventProcessing(eventID).ListLeftOff(0 To Map(GetPlayerMap(playerID)).Events(TempPlayer(playerID).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(playerID).EventMap.EventPages(eventID).PageID).CommandListCount)
                                                                            End If
                                                                        End If
                                                                        If .IgnoreIfCannotMove = 0 Then
                                                                            .MoveRouteStep = .MoveRouteStep - 1
                                                                        End If
                                                                    Else
                                                                        z = CanEventMoveTowardsPlayer(playerID, MapNum, eventID)
                                                                        If z >= 4 Then
                                                                            'No
                                                                            If .IgnoreIfCannotMove = 0 Then
                                                                                .MoveRouteStep = .MoveRouteStep - 1
                                                                            End If
                                                                        Else
                                                                            'i is the direct, lets go...
                                                                            If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                                EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                                            Else
                                                                                If .IgnoreIfCannotMove = 0 Then
                                                                                    .MoveRouteStep = .MoveRouteStep - 1
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            Case 7
                                                                If isglobal = False Then
                                                                    z = CanEventMoveAwayFromPlayer(playerID, MapNum, eventID)
                                                                    If z >= 5 Then
                                                                        'No
                                                                    Else
                                                                        'i is the direct, lets go...
                                                                        If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                            EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                                        Else
                                                                            If .IgnoreIfCannotMove = 0 Then
                                                                                .MoveRouteStep = .MoveRouteStep - 1
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            Case 8
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, .Dir, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, .Dir, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 9
                                                                Select Case .Dir
                                                                    Case DIR_UP
                                                                        z = DIR_DOWN
                                                                    Case DIR_DOWN
                                                                        z = DIR_UP
                                                                    Case DIR_LEFT
                                                                        z = DIR_RIGHT
                                                                    Case DIR_RIGHT
                                                                        z = DIR_LEFT
                                                                End Select
                                                                If CanEventMove(playerID, MapNum, .X, .Y, eventID, WalkThrough, z, isglobal) Then
                                                                    EventMove(playerID, MapNum, eventID, z, actualmovespeed, isglobal)
                                                                Else
                                                                    If .IgnoreIfCannotMove = 0 Then
                                                                        .MoveRouteStep = .MoveRouteStep - 1
                                                                    End If
                                                                End If
                                                            Case 10
                                                                .MoveTimer = GetTickCount() + 100
                                                            Case 11
                                                                .MoveTimer = GetTickCount() + 500
                                                            Case 12
                                                                .MoveTimer = GetTickCount() + 1000
                                                            Case 13
                                                                EventDir(playerID, MapNum, eventID, DIR_UP, isglobal)
                                                            Case 14
                                                                EventDir(playerID, MapNum, eventID, DIR_DOWN, isglobal)
                                                            Case 15
                                                                EventDir(playerID, MapNum, eventID, DIR_LEFT, isglobal)
                                                            Case 16
                                                                EventDir(playerID, MapNum, eventID, DIR_RIGHT, isglobal)
                                                            Case 17
                                                                Select Case .Dir
                                                                    Case DIR_UP
                                                                        z = DIR_RIGHT
                                                                    Case DIR_RIGHT
                                                                        z = DIR_DOWN
                                                                    Case DIR_LEFT
                                                                        z = DIR_UP
                                                                    Case DIR_DOWN
                                                                        z = DIR_LEFT
                                                                End Select
                                                                EventDir(playerID, MapNum, eventID, z, isglobal)
                                                            Case 18
                                                                Select Case .Dir
                                                                    Case DIR_UP
                                                                        z = DIR_LEFT
                                                                    Case DIR_RIGHT
                                                                        z = DIR_UP
                                                                    Case DIR_LEFT
                                                                        z = DIR_DOWN
                                                                    Case DIR_DOWN
                                                                        z = DIR_RIGHT
                                                                End Select
                                                                EventDir(playerID, MapNum, eventID, z, isglobal)
                                                            Case 19
                                                                Select Case .Dir
                                                                    Case DIR_UP
                                                                        z = DIR_DOWN
                                                                    Case DIR_RIGHT
                                                                        z = DIR_LEFT
                                                                    Case DIR_LEFT
                                                                        z = DIR_RIGHT
                                                                    Case DIR_DOWN
                                                                        z = DIR_UP
                                                                End Select
                                                                EventDir(playerID, MapNum, eventID, z, isglobal)
                                                            Case 20
                                                                z = Random(0, 3)
                                                                EventDir(playerID, MapNum, eventID, z, isglobal)
                                                            Case 21
                                                                If isglobal = False Then
                                                                    z = GetDirToPlayer(playerID, MapNum, eventID)
                                                                    EventDir(playerID, MapNum, eventID, z, isglobal)
                                                                End If
                                                            Case 22
                                                                If isglobal = False Then
                                                                    z = GetDirAwayFromPlayer(playerID, MapNum, eventID)
                                                                    EventDir(playerID, MapNum, eventID, z, isglobal)
                                                                End If
                                                            Case 23
                                                                .MoveSpeed = 0
                                                            Case 24
                                                                .MoveSpeed = 1
                                                            Case 25
                                                                .MoveSpeed = 2
                                                            Case 26
                                                                .MoveSpeed = 3
                                                            Case 27
                                                                .MoveSpeed = 4
                                                            Case 28
                                                                .MoveSpeed = 5
                                                            Case 29
                                                                .MoveFreq = 0
                                                            Case 30
                                                                .MoveFreq = 1
                                                            Case 31
                                                                .MoveFreq = 2
                                                            Case 32
                                                                .MoveFreq = 3
                                                            Case 33
                                                                .MoveFreq = 4
                                                            Case 34
                                                                .WalkingAnim = 1
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 35
                                                                .WalkingAnim = 0
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 36
                                                                .FixedDir = 1
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 37
                                                                .FixedDir = 0
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 38
                                                                .WalkThrough = 1
                                                            Case 39
                                                                .WalkThrough = 0
                                                            Case 40
                                                                .Position = 0
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 41
                                                                .Position = 1
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 42
                                                                .Position = 2
                                                                'Need to send update to client
                                                                sendupdate = True
                                                            Case 43
                                                                .GraphicType = .MoveRoute(.MoveRouteStep).Data1
                                                                .GraphicNum = .MoveRoute(.MoveRouteStep).Data2
                                                                .GraphicX = .MoveRoute(.MoveRouteStep).Data3
                                                                .GraphicX2 = .MoveRoute(.MoveRouteStep).Data4
                                                                .GraphicY = .MoveRoute(.MoveRouteStep).Data5
                                                                .GraphicY2 = .MoveRoute(.MoveRouteStep).Data6
                                                                If .GraphicType = 1 Then
                                                                    Select Case .GraphicY
                                                                        Case 0
                                                                            .Dir = DIR_DOWN
                                                                        Case 1
                                                                            .Dir = DIR_LEFT
                                                                        Case 2
                                                                            .Dir = DIR_RIGHT
                                                                        Case 3
                                                                            .Dir = DIR_UP
                                                                    End Select
                                                                End If
                                                                'Need to Send Update to client
                                                                sendupdate = True
                                                        End Select

                                                        If sendupdate Then
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SSpawnEvent)
                                                            Buffer.WriteLong(TempPlayer(playerID).EventMap.EventPages(eventID).EventID)
                                                            With TempPlayer(playerID).EventMap.EventPages(eventID)
                                                                Buffer.WriteString(Trim(Map(GetPlayerMap(playerID)).Events(TempPlayer(playerID).EventMap.EventPages(eventID).EventID).Name))
                                                                Buffer.WriteLong(.Dir)
                                                                Buffer.WriteLong(.GraphicNum)
                                                                Buffer.WriteLong(.GraphicType)
                                                                Buffer.WriteLong(.GraphicX)
                                                                Buffer.WriteLong(.GraphicX2)
                                                                Buffer.WriteLong(.GraphicY)
                                                                Buffer.WriteLong(.GraphicY2)
                                                                Buffer.WriteLong(.MoveSpeed)
                                                                Buffer.WriteLong(.X)
                                                                Buffer.WriteLong(.Y)
                                                                Buffer.WriteLong(.Position)
                                                                Buffer.WriteLong(.Visible)
                                                                Buffer.WriteLong(.WalkingAnim)
                                                                Buffer.WriteLong(.FixedDir)
                                                                Buffer.WriteLong(.WalkThrough)
                                                                Buffer.WriteLong(.ShowName)
                                                            End With
                                                            SendDataTo(playerID, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        End If
                                                    End If
                                                    donotprocessmoveroute = False
                                                End If
                                            End With
                                    End Select
                                    Select Case TempPlayer(playerID).EventMap.EventPages(x).MoveFreq
                                        Case 0
                                            TempPlayer(playerID).EventMap.EventPages(x).MoveTimer = GetTickCount() + 4000
                                        Case 1
                                            TempPlayer(playerID).EventMap.EventPages(x).MoveTimer = GetTickCount() + 2000
                                        Case 2
                                            TempPlayer(playerID).EventMap.EventPages(x).MoveTimer = GetTickCount() + 1000
                                        Case 3
                                            TempPlayer(playerID).EventMap.EventPages(x).MoveTimer = GetTickCount() + 500
                                        Case 4
                                            TempPlayer(playerID).EventMap.EventPages(x).MoveTimer = GetTickCount() + 250
                                    End Select
                                End If
                            End If
                        End If
                    Next
                End If
            End If
            DoEvents()
        Next

    End Sub

    Public Sub ProcessEventCommands()
        Dim Buffer As ByteBuffer, i As Long, x As Long, removeEventProcess As Boolean, w As Long, v As Long, p As Long
        Dim restartlist As Boolean, restartloop As Boolean, endprocess As Boolean

        If Gettingmap = True Then Exit Sub

        'Now, we process the damn things for commands :P

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                For x = 1 To TempPlayer(i).EventMap.CurrentEvents
                    If TempPlayer(i).EventMap.EventPages(x).Visible Then
                        If Map(Player(i).Map).Events(TempPlayer(i).EventMap.EventPages(x).EventID).Pages(TempPlayer(i).EventMap.EventPages(x).PageID).Trigger = 2 Then 'Parallel Process baby!
                            If TempPlayer(i).EventProcessingCount > 0 Then
                                If TempPlayer(i).EventProcessing(x).Active = 0 Then
                                    If Map(GetPlayerMap(i)).Events(TempPlayer(i).EventMap.EventPages(x).EventID).Pages(TempPlayer(i).EventMap.EventPages(x).PageID).CommandListCount > 0 Then
                                        'start new event processing
                                        TempPlayer(i).EventProcessing(TempPlayer(i).EventMap.EventPages(x).EventID).Active = 1
                                        With TempPlayer(i).EventProcessing(TempPlayer(i).EventMap.EventPages(x).EventID)
                                            .ActionTimer = GetTickCount()
                                            .CurList = 1
                                            .CurSlot = 1
                                            .EventID = TempPlayer(i).EventMap.EventPages(x).EventID
                                            .PageID = TempPlayer(i).EventMap.EventPages(x).PageID
                                            .WaitingForResponse = 0
                                            ReDim .ListLeftOff(0 To Map(GetPlayerMap(i)).Events(TempPlayer(i).EventMap.EventPages(x).EventID).Pages(TempPlayer(i).EventMap.EventPages(x).PageID).CommandListCount)
                                        End With
                                    End If
                                End If
                            Else
                                If Map(GetPlayerMap(i)).Events(TempPlayer(i).EventMap.EventPages(x).EventID).Pages(TempPlayer(i).EventMap.EventPages(x).PageID).CommandListCount > 0 Then
                                    'Clearly need to start it!
                                    TempPlayer(i).EventProcessing(TempPlayer(i).EventMap.EventPages(x).EventID).Active = 1
                                    With TempPlayer(i).EventProcessing(TempPlayer(i).EventMap.EventPages(x).EventID)
                                        .ActionTimer = GetTickCount()
                                        .CurList = 1
                                        .CurSlot = 1
                                        .EventID = TempPlayer(i).EventMap.EventPages(x).EventID
                                        .PageID = TempPlayer(i).EventMap.EventPages(x).PageID
                                        .WaitingForResponse = 0
                                        ReDim .ListLeftOff(0 To Map(GetPlayerMap(i)).Events(TempPlayer(i).EventMap.EventPages(x).EventID).Pages(TempPlayer(i).EventMap.EventPages(x).PageID).CommandListCount)
                                    End With
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next

        'That is it for starting parallel processes :D now we just have to make the code that actually processes the events to their fullest
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If TempPlayer(i).EventProcessingCount > 0 Then
                    restartloop = True
                    Do While restartloop = True
                        restartloop = False
                        For x = 1 To TempPlayer(i).EventProcessingCount
                            If TempPlayer(i).EventProcessing(x).Active = 1 Then
                                If x > TempPlayer(i).EventProcessingCount Then Exit For
                                With TempPlayer(i).EventProcessing(x)
                                    If TempPlayer(i).EventProcessingCount = 0 Then Exit Sub
                                    removeEventProcess = False
                                    If .WaitingForResponse = 2 Then
                                        If TempPlayer(i).InShop = 0 Then
                                            .WaitingForResponse = 0
                                        End If
                                    End If
                                    If .WaitingForResponse = 3 Then
                                        If TempPlayer(i).InBank = False Then
                                            .WaitingForResponse = 0
                                        End If
                                    End If
                                    If .WaitingForResponse = 4 Then
                                        'waiting for eventmovement to complete
                                        If .EventMovingType = 0 Then
                                            If TempPlayer(i).EventMap.EventPages(.EventMovingID).MoveRouteComplete = 1 Then
                                                .WaitingForResponse = 0
                                            End If
                                        Else
                                            If TempEventMap(GetPlayerMap(i)).Events(.EventMovingID).MoveRouteComplete = 1 Then
                                                .WaitingForResponse = 0
                                            End If
                                        End If
                                    End If
                                    If .WaitingForResponse = 0 Then
                                        If .ActionTimer <= GetTickCount() Then
                                            restartlist = True
                                            endprocess = False
                                            Do While restartlist = True And endprocess = False And .WaitingForResponse = 0
                                                restartlist = False
                                                If .ListLeftOff(.CurList) > 0 Then
                                                    .CurSlot = .ListLeftOff(.CurList) + 1
                                                    .ListLeftOff(.CurList) = 0
                                                End If
                                                If .CurList > Map(Player(i).Map).Events(.EventID).Pages(.PageID).CommandListCount Then
                                                    'Get rid of this event, it is bad
                                                    removeEventProcess = True
                                                    endprocess = True
                                                End If
                                                If .CurSlot > Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).CommandCount Then
                                                    If .CurList = 1 Then
                                                        'Get rid of this event, it is bad
                                                        removeEventProcess = True
                                                        endprocess = True
                                                    Else
                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).ParentList
                                                        .CurSlot = 1
                                                        restartlist = True
                                                    End If
                                                End If
                                                If restartlist = False And endprocess = False Then
                                                    'If we are still here, then we are good to process shit :D
                                                    'Debug.WriteLine(.CurSlot)
                                                    Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Index
                                                        Case EventType.evAddText
                                                            Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2
                                                                Case 0
                                                                    PlayerMsg(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1) ', Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                                Case 1
                                                                    MapMsg(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                Case 2
                                                                    GlobalMsg(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1) ', Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            End Select
                                                        Case EventType.evShowText
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SEventChat)
                                                            Buffer.WriteLong(.EventID)
                                                            Buffer.WriteLong(.PageID)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            Buffer.WriteString(Trim(ParseEventText(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1)))
                                                            Buffer.WriteLong(0)
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).CommandCount > .CurSlot Then
                                                                If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot + 1).Index = EventType.evShowText Or Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot + 1).Index = EventType.evShowChoices Then
                                                                    Buffer.WriteLong(1)
                                                                ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot + 1).Index = EventType.evCondition Then
                                                                    Buffer.WriteLong(2)
                                                                Else
                                                                    Buffer.WriteLong(0)
                                                                End If
                                                            Else
                                                                Buffer.WriteLong(2)
                                                            End If
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                            .WaitingForResponse = 1
                                                        Case EventType.evShowChoices
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SEventChat)
                                                            Buffer.WriteLong(.EventID)
                                                            Buffer.WriteLong(.PageID)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data5)
                                                            Buffer.WriteString(Trim(ParseEventText(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1)))
                                                            If Len(Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text2)) > 0 Then
                                                                w = 1
                                                                If Len(Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text3)) > 0 Then
                                                                    w = 2
                                                                    If Len(Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text4)) > 0 Then
                                                                        w = 3
                                                                        If Len(Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text5)) > 0 Then
                                                                            w = 4
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                            Buffer.WriteLong(w)
                                                            For v = 1 To w
                                                                Select Case v
                                                                    Case 1
                                                                        Buffer.WriteString(Trim(ParseEventText(i, Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text2))))
                                                                    Case 2
                                                                        Buffer.WriteString(Trim(ParseEventText(i, Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text3))))
                                                                    Case 3
                                                                        Buffer.WriteString(Trim(ParseEventText(i, Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text4))))
                                                                    Case 4
                                                                        Buffer.WriteString(Trim(ParseEventText(i, Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text5))))
                                                                End Select
                                                            Next
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).CommandCount > .CurSlot Then
                                                                If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot + 1).Index = EventType.evShowText Or Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot + 1).Index = EventType.evShowChoices Then
                                                                    Buffer.WriteLong(1)
                                                                ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot + 1).Index = EventType.evCondition Then
                                                                    Buffer.WriteLong(2)
                                                                Else
                                                                    Buffer.WriteLong(0)
                                                                End If
                                                            Else
                                                                Buffer.WriteLong(2)
                                                            End If
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                            .WaitingForResponse = 1
                                                        Case EventType.evPlayerVar
                                                            Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2
                                                                Case 0
                                                                    Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3
                                                                Case 1
                                                                    Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) + Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3
                                                                Case 2
                                                                    Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) - Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3
                                                                Case 3
                                                                    Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = Random(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data4)
                                                            End Select
                                                        Case EventType.evPlayerSwitch
                                                            'Debug.Print("server-data2 is: " & Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2)
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 0 Then
                                                                Player(i).Switches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = 1
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 1 Then
                                                                Player(i).Switches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = 0
                                                            End If
                                                        Case EventType.evSelfSwitch
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Globals = 1 Then
                                                                If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 0 Then
                                                                    Map(GetPlayerMap(i)).Events(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 + 1) = 1
                                                                ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 1 Then
                                                                    Map(GetPlayerMap(i)).Events(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 + 1) = 0
                                                                End If
                                                            Else
                                                                If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 0 Then
                                                                    TempPlayer(i).EventMap.EventPages(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 + 1) = 1
                                                                ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 1 Then
                                                                    TempPlayer(i).EventMap.EventPages(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 + 1) = 0
                                                                End If
                                                            End If
                                                        Case EventType.evCondition
                                                            Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Condition
                                                                Case 0
                                                                    Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2
                                                                        Case 0
                                                                            If Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 1
                                                                            If Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) >= Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 2
                                                                            If Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) <= Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 3
                                                                            If Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) > Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 4
                                                                            If Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) < Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 5
                                                                            If Player(i).Variables(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) <> Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                    End Select
                                                                Case 1
                                                                    Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2
                                                                        Case 0
                                                                            If Player(i).Switches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) = 1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 1
                                                                            If Player(i).Switches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) = 0 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                    End Select
                                                                Case 2
                                                                    If HasItem(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) >= Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2 Then
                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                        .CurSlot = 1
                                                                    Else
                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                        .CurSlot = 1
                                                                    End If
                                                                Case 3
                                                                    If Player(i).Classes = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                        .CurSlot = 1
                                                                    Else
                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                        .CurSlot = 1
                                                                    End If
                                                                Case 4
                                                                    If HasSpell(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) = True Then
                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                        .CurSlot = 1
                                                                    Else
                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                        .CurSlot = 1
                                                                    End If
                                                                Case 5
                                                                    Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2
                                                                        Case 0
                                                                            If GetPlayerLevel(i) = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 1
                                                                            If GetPlayerLevel(i) >= Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 2
                                                                            If GetPlayerLevel(i) <= Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 3
                                                                            If GetPlayerLevel(i) > Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 4
                                                                            If GetPlayerLevel(i) < Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        Case 5
                                                                            If GetPlayerLevel(i) <> Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                    End Select
                                                                Case 6
                                                                    If Map(GetPlayerMap(i)).Events(.EventID).Globals = 1 Then
                                                                        Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2
                                                                            Case 0 'Self Switch is true
                                                                                If Map(GetPlayerMap(i)).Events(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 + 1) = 1 Then
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                    .CurSlot = 1
                                                                                Else
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                    .CurSlot = 1
                                                                                End If
                                                                            Case 1  'self switch is false
                                                                                If Map(GetPlayerMap(i)).Events(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 + 1) = 0 Then
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                    .CurSlot = 1
                                                                                Else
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                    .CurSlot = 1
                                                                                End If
                                                                        End Select
                                                                    Else
                                                                        Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2
                                                                            Case 0 'Self Switch is true
                                                                                If TempPlayer(i).EventMap.EventPages(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 + 1) = 1 Then
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                    .CurSlot = 1
                                                                                Else
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                    .CurSlot = 1
                                                                                End If
                                                                            Case 1  'self switch is false
                                                                                If TempPlayer(i).EventMap.EventPages(.EventID).SelfSwitches(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 + 1) = 0 Then
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                    .CurSlot = 1
                                                                                Else
                                                                                    .ListLeftOff(.CurList) = .CurSlot
                                                                                    .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                    .CurSlot = 1
                                                                                End If
                                                                        End Select
                                                                    End If
                                                                Case 7
                                                                    If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 > 0 And Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1 <= MAX_QUESTS Then
                                                                        If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2 = 0 Then
                                                                            Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3
                                                                                Case 0
                                                                                    If Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1).Status = 0 Then
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                        .CurSlot = 1
                                                                                    Else
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                        .CurSlot = 1
                                                                                    End If
                                                                                Case 1
                                                                                    If Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1).Status = 1 Then
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                        .CurSlot = 1
                                                                                    Else
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                        .CurSlot = 1
                                                                                    End If
                                                                                Case 2
                                                                                    If Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1).Status = 2 Or Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1).Status = 3 Then
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                        .CurSlot = 1
                                                                                    Else
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                        .CurSlot = 1
                                                                                    End If
                                                                                Case 3
                                                                                    If CanStartQuest(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) Then
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                        .CurSlot = 1
                                                                                    Else
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                        .CurSlot = 1
                                                                                    End If
                                                                                Case 4
                                                                                    If CanEndQuest(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1) Then
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                        .CurSlot = 1
                                                                                    Else
                                                                                        .ListLeftOff(.CurList) = .CurSlot
                                                                                        .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                        .CurSlot = 1
                                                                                    End If
                                                                            End Select
                                                                        ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data2 = 1 Then
                                                                            If Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data1).ActualTask = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.Data3 Then
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.CommandList
                                                                                .CurSlot = 1
                                                                            Else
                                                                                .ListLeftOff(.CurList) = .CurSlot
                                                                                .CurList = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).ConditionalBranch.ElseCommandList
                                                                                .CurSlot = 1
                                                                            End If
                                                                        End If
                                                                    End If
                                                            End Select
                                                            endprocess = True
                                                        Case EventType.evExitProcess
                                                            removeEventProcess = True
                                                            endprocess = True
                                                        Case EventType.evChangeItems
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 0 Then
                                                                If HasItem(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) > 0 Then
                                                                    Call SetPlayerInvItemValue(i, FindItemSlot(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3)
                                                                    Call CheckTasks(i, QUEST_TYPE_GOGET, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                    Call CheckTasks(i, QUEST_TYPE_GOGIVE, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                End If
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 1 Then
                                                                GiveInvItem(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3, True)
                                                                Call CheckTasks(i, QUEST_TYPE_GOGET, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                Call CheckTasks(i, QUEST_TYPE_GOGIVE, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 2 Then
                                                                Dim itemAmount As Long
                                                                itemAmount = HasItem(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                ' Check Amount
                                                                If itemAmount >= Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3 Then
                                                                    TakeInvItem(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3)
                                                                    Call CheckTasks(i, QUEST_TYPE_GOGET, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                    Call CheckTasks(i, QUEST_TYPE_GOGIVE, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                End If
                                                            End If
                                                            SendInventory(i)
                                                        Case EventType.evRestoreHP
                                                            SetPlayerVital(i, Vitals.HP, GetPlayerMaxVital(i, Vitals.HP))
                                                            SendVital(i, Vitals.HP)
                                                        Case EventType.evRestoreMP
                                                            SetPlayerVital(i, Vitals.MP, GetPlayerMaxVital(i, Vitals.MP))
                                                            SendVital(i, Vitals.MP)
                                                        Case EventType.evLevelUp
                                                            SetPlayerExp(i, GetPlayerNextLevel(i))
                                                            CheckPlayerLevelUp(i)
                                                            SendEXP(i)
                                                            SendPlayerData(i)
                                                        Case EventType.evChangeLevel
                                                            SetPlayerLevel(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            SetPlayerExp(i, 0)
                                                            SendEXP(i)
                                                            SendPlayerData(i)
                                                        Case EventType.evChangeSkills
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 0 Then
                                                                If FindOpenSpellSlot(i) > 0 Then
                                                                    If HasSpell(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = False Then
                                                                        SetPlayerSpell(i, FindOpenSpellSlot(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                    Else
                                                                        'Error, already knows spell
                                                                    End If
                                                                Else
                                                                    'Error, no room for spells
                                                                End If
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 1 Then
                                                                If HasSpell(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) = True Then
                                                                    For p = 1 To MAX_PLAYER_SPELLS
                                                                        If Player(i).Spell(p) = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 Then
                                                                            SetPlayerSpell(i, p, 0)
                                                                        End If
                                                                    Next
                                                                End If
                                                            End If
                                                            SendPlayerSpells(i)
                                                        Case EventType.evChangeClass
                                                            Player(i).Classes = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                            SendPlayerData(i)
                                                        Case EventType.evChangeSprite
                                                            SetPlayerSprite(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            SendPlayerData(i)
                                                        Case EventType.evChangeSex
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 = 0 Then
                                                                Player(i).Sex = SEX_MALE
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 = 1 Then
                                                                Player(i).Sex = SEX_FEMALE
                                                            End If
                                                            SendPlayerData(i)
                                                        Case EventType.evChangePK
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 = 0 Then
                                                                Player(i).PK = NO
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 = 1 Then
                                                                Player(i).PK = YES
                                                            End If
                                                            SendPlayerData(i)
                                                        Case EventType.evWarpPlayer
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data4 = 0 Then
                                                                PlayerWarp(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3)
                                                            Else
                                                                Player(i).Dir = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data4 - 1
                                                                PlayerWarp(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3)
                                                            End If

                                                        Case EventType.evSetMoveRoute
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 <= Map(GetPlayerMap(i)).EventCount Then
                                                                If Map(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).Globals = 1 Then
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveType = 2
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).IgnoreIfCannotMove = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).RepeatMoveRoute = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRouteCount = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).MoveRouteCount
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRoute = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).MoveRoute
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRouteStep = 0
                                                                    TempEventMap(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRouteComplete = 0
                                                                Else
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveType = 2
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).IgnoreIfCannotMove = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).RepeatMoveRoute = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRouteCount = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).MoveRouteCount
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRoute = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).MoveRoute
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRouteStep = 0
                                                                    TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).MoveRouteComplete = 0
                                                                End If
                                                            End If
                                                        Case EventType.evPlayAnimation
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 0 Then
                                                                SendAnimation(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, GetPlayerX(i), GetPlayerY(i), TARGET_TYPE_PLAYER, i)
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 1 Then
                                                                If Map(GetPlayerMap(i)).Events(.EventID).Globals = 1 Then
                                                                    SendAnimation(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).X, Map(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3).Y)
                                                                Else
                                                                    SendAnimation(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3).X, TempPlayer(i).EventMap.EventPages(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3).Y, 0, 0)
                                                                End If
                                                            ElseIf Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 = 2 Then
                                                                SendAnimation(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data4, 0, 0)
                                                            End If
                                                        Case EventType.evCustomScript
                                                            'Runs Through Cases for a script
                                                            Call CustomScript(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                        Case EventType.evPlayBGM
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SPlayBGM)
                                                            Buffer.WriteString(Trim(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1))
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evFadeoutBGM
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SFadeoutBGM)
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evPlaySound
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SPlaySound)
                                                            Buffer.WriteString(Trim(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1))
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evStopSound
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SStopSound)
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evSetAccess
                                                            Player(i).Access = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                            SendPlayerData(i)
                                                        Case EventType.evOpenShop
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 > 0 Then ' shop exists?
                                                                If Len(Trim$(Shop(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).Name)) > 0 Then ' name exists?
                                                                    SendOpenShop(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                    TempPlayer(i).InShop = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 ' stops movement and the like
                                                                    .WaitingForResponse = 2
                                                                End If
                                                            End If
                                                        Case EventType.evOpenBank
                                                            SendBank(i)
                                                            TempPlayer(i).InBank = True
                                                            .WaitingForResponse = 3
                                                        Case EventType.evGiveExp
                                                            GivePlayerEXP(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                        Case EventType.evShowChatBubble
                                                            Select Case Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                                Case TARGET_TYPE_PLAYER
                                                                    SendChatBubble(GetPlayerMap(i), i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1, Brown)
                                                                Case TARGET_TYPE_NPC
                                                                    SendChatBubble(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1, Brown)
                                                                Case TARGET_TYPE_EVENT
                                                                    SendChatBubble(GetPlayerMap(i), Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1, Brown)
                                                            End Select
                                                        Case EventType.evLabel
                                                            'Do nothing, just a label
                                                        Case EventType.evGotoLabel
                                                            'Find the label's list of commands and slot
                                                            FindEventLabel(Trim$(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Text1), GetPlayerMap(i), .EventID, .PageID, .CurSlot, .CurList, .ListLeftOff)
                                                        Case EventType.evSpawnNpc
                                                            If Map(GetPlayerMap(i)).Npc(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) > 0 Then
                                                                SpawnNpc(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, GetPlayerMap(i))
                                                            End If
                                                        Case EventType.evFadeIn
                                                            SendSpecialEffect(i, EFFECT_TYPE_FADEIN)
                                                        Case EventType.evFadeOut
                                                            SendSpecialEffect(i, EFFECT_TYPE_FADEOUT)
                                                        Case EventType.evFlashWhite
                                                            SendSpecialEffect(i, EFFECT_TYPE_FLASH)
                                                        Case EventType.evSetFog
                                                            SendSpecialEffect(i, EFFECT_TYPE_FOG, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3)
                                                        Case EventType.evSetWeather
                                                            SendSpecialEffect(i, EFFECT_TYPE_WEATHER, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2)
                                                        Case EventType.evSetTint
                                                            SendSpecialEffect(i, EFFECT_TYPE_TINT, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data4)
                                                        Case EventType.evWait
                                                            .ActionTimer = GetTickCount() + Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                        Case EventType.evOpenMail
                                                            'SendMailBox(i)
                                                        Case EventType.evBeginQuest
                                                            If CanStartQuest(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) Then
                                                                QuestMessage(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Quest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).QuestLog, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            End If
                                                        Case EventType.evEndQuest
                                                            If CanEndQuest(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) Then
                                                                EndQuest(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                            End If
                                                        Case EventType.evQuestTask
                                                            If QuestInProgress(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1) Then
                                                                If Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).ActualTask = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2 Then
                                                                    If Quest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).Task(Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).ActualTask).TaskType = QUEST_TYPE_TALKEVENT Or Quest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).Task(Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).ActualTask).TaskType = QUEST_TYPE_GOGET Then
                                                                        CheckTask(i, Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1, Quest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).Task(Player(i).PlayerQuest(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).ActualTask).TaskType, -1)
                                                                    End If
                                                                End If
                                                            End If
                                                        Case EventType.evShowPicture
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SPic)
                                                            Buffer.WriteLong(0)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 + 1)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data2)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data3)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data4)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data5)
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evHidePicture
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SPic)
                                                            Buffer.WriteLong(1)
                                                            Buffer.WriteLong(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 + 1)
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evWaitMovement
                                                            If Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1 <= Map(GetPlayerMap(i)).EventCount Then
                                                                If Map(GetPlayerMap(i)).Events(Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1).Globals = 1 Then
                                                                    .WaitingForResponse = 4
                                                                    .EventMovingID = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                                    .EventMovingType = 1
                                                                Else
                                                                    .WaitingForResponse = 4
                                                                    .EventMovingID = Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1
                                                                    .EventMovingType = 0
                                                                End If
                                                            End If
                                                        Case EventType.evHoldPlayer
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SHoldPlayer)
                                                            Buffer.WriteLong(0)
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                        Case EventType.evReleasePlayer
                                                            Buffer = New ByteBuffer
                                                            Buffer.WriteLong(ServerPackets.SHoldPlayer)
                                                            Buffer.WriteLong(1)
                                                            SendDataTo(i, Buffer.ToArray)
                                                            Buffer = Nothing
                                                    End Select
                                                End If
                                            Loop
                                            If endprocess = False Then
                                                .CurSlot = .CurSlot + 1
                                            End If
                                        End If
                                    End If
                                End With
                            End If
                            If removeEventProcess = True Then
                                TempPlayer(i).EventProcessing(x).Active = 0
                                restartloop = True
                                removeEventProcess = False
                            End If
                        Next
                    Loop
                End If
            End If
        Next

    End Sub

    Public Sub UpdateEventLogic()
        'Check Removing and Adding of Events (Did switches change or something?)

        If Gettingmap = True Then Exit Sub

        RemoveDeadEvents()
        SpawnNewEvents()
        ProcessEventMovement()
        ProcessLocalEventMovement()
        ProcessEventCommands()

    End Sub

    Function ParseEventText(ByVal Index As Long, ByVal txt As String) As String
        Dim i As Long, x As Long, newtxt As String, parsestring As String, z As Long

        txt = Replace(txt, "/name", Trim$(Player(Index).Name))
        txt = Replace(txt, "/p", Trim$(Player(Index).Name))
        Do While InStr(1, txt, "/v") > 0
            x = InStr(1, txt, "/v")
            If x > 0 Then
                i = 0
                Do Until IsNumeric(Mid(txt, x + 2 + i, 1)) = False
                    i = i + 1
                Loop
                newtxt = Mid(txt, 1, x - 1)
                parsestring = Mid(txt, x + 2, i)
                z = Player(Index).Variables(Val(parsestring))
                newtxt = newtxt & CStr(z)
                newtxt = newtxt & Mid(txt, x + 2 + i, Len(txt) - (x + i))
                txt = newtxt
            End If
        Loop
        ParseEventText = txt

    End Function

    Sub FindEventLabel(ByVal Label As String, MapNum As Long, eventID As Long, pageID As Long, CurSlot As Long, CurList As Long, ListLeftOff() As Long)
        Dim tmpCurSlot As Long, tmpCurList As Long, CurrentListOption() As Long
        Dim removeEventProcess As Boolean, tmpListLeftOff() As Long, restartlist As Boolean, w As Long

        'Store the Old data, just in case

        tmpCurSlot = CurSlot
        tmpCurList = CurList
        tmpListLeftOff = ListLeftOff

        ReDim ListLeftOff(Map(MapNum).Events(eventID).Pages(pageID).CommandListCount)
        ReDim CurrentListOption(Map(MapNum).Events(eventID).Pages(pageID).CommandListCount)
        CurList = 1
        CurSlot = 1

        Do Until removeEventProcess = True
            If ListLeftOff(CurList) > 0 Then
                CurSlot = ListLeftOff(CurList)
                ListLeftOff(CurList) = 0
            End If
            If CurList > Map(MapNum).Events(eventID).Pages(pageID).CommandListCount Then
                'Get rid of this event, it is bad
                removeEventProcess = True
            End If

            If CurSlot > Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).CommandCount Then
                If CurList = 1 Then
                    removeEventProcess = True
                Else
                    CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).ParentList
                    CurSlot = 1
                    restartlist = True
                End If
            End If

            If restartlist = False Then
                If removeEventProcess = False Then
                    'If we are still here, then we are good to process shit :D
                    Select Case Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Index
                        Case EventType.evShowChoices
                            If Len(Trim$(Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Text2)) > 0 Then
                                w = 1
                                If Len(Trim$(Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Text3)) > 0 Then
                                    w = 2
                                    If Len(Trim$(Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Text4)) > 0 Then
                                        w = 3
                                        If Len(Trim$(Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Text5)) > 0 Then
                                            w = 4
                                        End If
                                    End If
                                End If
                            End If
                            If w > 0 Then
                                If CurrentListOption(CurList) < w Then
                                    CurrentListOption(CurList) = CurrentListOption(CurList) + 1
                                    'Process
                                    ListLeftOff(CurList) = CurSlot
                                    Select Case CurrentListOption(CurList)
                                        Case 1
                                            CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Data1
                                        Case 2
                                            CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Data2
                                        Case 3
                                            CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Data3
                                        Case 4
                                            CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Data4
                                    End Select
                                    CurSlot = 0
                                Else
                                    CurrentListOption(CurList) = 0
                                    'continue on
                                End If
                            End If
                            w = 0
                        Case EventType.evCondition
                            If CurrentListOption(CurList) = 0 Then
                                CurrentListOption(CurList) = 1
                                ListLeftOff(CurList) = CurSlot
                                CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).ConditionalBranch.CommandList
                                CurSlot = 0
                            ElseIf CurrentListOption(CurList) = 1 Then
                                CurrentListOption(CurList) = 2
                                ListLeftOff(CurList) = CurSlot
                                CurList = Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).ConditionalBranch.ElseCommandList
                                CurSlot = 0
                            ElseIf CurrentListOption(CurList) = 2 Then
                                CurrentListOption(CurList) = 0
                            End If
                        Case EventType.evLabel
                            'Do nothing, just a label
                            If Trim$(Map(MapNum).Events(eventID).Pages(pageID).CommandList(CurList).Commands(CurSlot).Text1) = Trim$(Label) Then
                                Exit Sub
                            End If
                    End Select
                    CurSlot = CurSlot + 1
                End If
            End If
            restartlist = False
        Loop

        ListLeftOff = tmpListLeftOff
        CurList = tmpCurList
        CurSlot = tmpCurSlot

    End Sub

    Function FindNpcPath(MapNum As Long, mapnpcnum As Long, targetx As Long, targety As Long) As Long
        Dim tim As Long, sX As Long, sY As Long, pos(,) As Long, reachable As Boolean, j As Long, LastSum As Long, Sum As Long, FX As Long, FY As Long, i As Long
        Dim path() As Point, LastX As Long, LastY As Long, did As Boolean

        'Initialization phase

        tim = 0

        sX = MapNpc(MapNum).Npc(mapnpcnum).x
        sY = MapNpc(MapNum).Npc(mapnpcnum).y

        FX = targetx
        FY = targety

        If FX = -1 Then FX = 0
        If FY = -1 Then FY = 0

        ReDim pos(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)
        'pos = MapBlocks(MapNum).Blocks

        pos(sX, sY) = 100 + tim
        pos(FX, FY) = 2

        'reset reachable
        reachable = False

        'Do while reachable is false... if its set true in progress, we jump out
        'If the path is decided unreachable in process, we will use exit sub. Not proper,
        'but faster ;-)
        Do While reachable = False
            'we loop through all squares
            For j = 0 To Map(MapNum).MaxY
                For i = 0 To Map(MapNum).MaxX
                    'If j = 10 And i = 0 Then MsgBox "hi!"
                    'If they are to be extended, the pointer TIM is on them
                    If pos(i, j) = 100 + tim Then
                        'The part is to be extended, so do it
                        'We have to make sure that there is a pos(i+1,j) BEFORE we actually use it,
                        'because then we get error... If the square is on side, we dont test for this one!
                        If i < Map(MapNum).MaxX Then
                            'If there isnt a wall, or any other... thing
                            If pos(i + 1, j) = 0 Then
                                'Expand it, and make its pos equal to tim+1, so the next time we make this loop,
                                'It will exapand that square too! This is crucial part of the program
                                pos(i + 1, j) = 100 + tim + 1
                            ElseIf pos(i + 1, j) = 2 Then
                                'If the position is no 0 but its 2 (FINISH) then Reachable = true!!! We found end
                                reachable = True
                            End If
                        End If

                        'This is the same as the last one, as i said a lot of copy paste work and editing that
                        'This is simply another side that we have to test for... so instead of i+1 we have i-1
                        'Its actually pretty same then... I wont comment it therefore, because its only repeating
                        'same thing with minor changes to check sides
                        If i > 0 Then
                            If pos((i - 1), j) = 0 Then
                                pos(i - 1, j) = 100 + tim + 1
                            ElseIf pos(i - 1, j) = 2 Then
                                reachable = True
                            End If
                        End If

                        If j < Map(MapNum).MaxY Then
                            If pos(i, j + 1) = 0 Then
                                pos(i, j + 1) = 100 + tim + 1
                            ElseIf pos(i, j + 1) = 2 Then
                                reachable = True
                            End If
                        End If

                        If j > 0 Then
                            If pos(i, j - 1) = 0 Then
                                pos(i, j - 1) = 100 + tim + 1
                            ElseIf pos(i, j - 1) = 2 Then
                                reachable = True
                            End If
                        End If
                    End If
                    DoEvents()
                Next i
            Next j

            'If the reachable is STILL false, then
            If reachable = False Then
                'reset sum
                Sum = 0
                For j = 0 To Map(MapNum).MaxY
                    For i = 0 To Map(MapNum).MaxX
                        'we add up ALL the squares
                        Sum = Sum + pos(i, j)
                    Next i
                Next j

                'Now if the sum is euqal to the last sum, its not reachable, if it isnt, then we store
                'sum to lastsum
                If Sum = LastSum Then
                    FindNpcPath = 4
                    Exit Function
                Else
                    LastSum = Sum
                End If
            End If

            'we increase the pointer to point to the next squares to be expanded
            tim = tim + 1
        Loop

        'We work backwards to find the way...
        LastX = FX
        LastY = FY

        ReDim path(tim + 1)

        'The following code may be a little bit confusing but ill try my best to explain it.
        'We are working backwards to find ONE of the shortest ways back to Start.
        'So we repeat the loop until the LastX and LastY arent in start. Look in the code to see
        'how LastX and LasY change
        Do While LastX <> sX Or LastY <> sY
            'We decrease tim by one, and then we are finding any adjacent square to the final one, that
            'has that value. So lets say the tim would be 5, because it takes 5 steps to get to the target.
            'Now everytime we decrease that, so we make it 4, and we look for any adjacent square that has
            'that value. When we find it, we just color it yellow as for the solution
            tim = tim - 1
            'reset did to false
            did = False

            'If we arent on edge
            If LastX < Map(MapNum).MaxX Then
                'check the square on the right of the solution. Is it a tim-1 one? or just a blank one
                If pos(LastX + 1, LastY) = 100 + tim Then
                    'if it, then make it yellow, and change did to true
                    LastX = LastX + 1
                    did = True
                End If
            End If

            'This will then only work if the previous part didnt execute, and did is still false. THen
            'we want to check another square, the on left. Is it a tim-1 one ?
            If did = False Then
                If LastX > 0 Then
                    If pos(LastX - 1, LastY) = 100 + tim Then
                        LastX = LastX - 1
                        did = True
                    End If
                End If
            End If

            'We check the one below it
            If did = False Then
                If LastY < Map(MapNum).MaxY Then
                    If pos(LastX, LastY + 1) = 100 + tim Then
                        LastY = LastY + 1
                        did = True
                    End If
                End If
            End If

            'And above it. One of these have to be it, since we have found the solution, we know that already
            'there is a way back.
            If did = False Then
                If LastY > 0 Then
                    If pos(LastX, LastY - 1) = 100 + tim Then
                        LastY = LastY - 1
                    End If
                End If
            End If

            path(tim).x = LastX
            path(tim).y = LastY

            'Now we loop back and decrease tim, and look for the next square with lower value
            DoEvents()
        Loop

        'Ok we got a path. Now, lets look at the first step and see what direction we should take.
        If path(1).x > LastX Then
            FindNpcPath = DIR_RIGHT
        ElseIf path(1).y > LastY Then
            FindNpcPath = DIR_DOWN
        ElseIf path(1).y < LastY Then
            FindNpcPath = DIR_UP
        ElseIf path(1).x < LastX Then
            FindNpcPath = DIR_LEFT
        End If

    End Function

    Sub SpawnAllMapGlobalEvents()
        Dim i As Long

        For i = 0 To MAX_MAPS
            DoEvents()
            SpawnGlobalEvents(i)
        Next

    End Sub

    Sub SpawnGlobalEvents(ByVal MapNum As Long)
        Dim i As Long, z As Long

        If Map(MapNum).EventCount > 0 Then
            TempEventMap(MapNum).EventCount = 0
            ReDim TempEventMap(MapNum).Events(0)
            For i = 1 To Map(MapNum).EventCount
                TempEventMap(MapNum).EventCount = TempEventMap(MapNum).EventCount + 1
                ReDim Preserve TempEventMap(MapNum).Events(0 To TempEventMap(MapNum).EventCount)
                If Map(MapNum).Events(i).PageCount > 0 Then
                    If Map(MapNum).Events(i).Globals = 1 Then
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).X = Map(MapNum).Events(i).X
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Y = Map(MapNum).Events(i).Y
                        If Map(MapNum).Events(i).Pages(1).GraphicType = 1 Then
                            Select Case Map(MapNum).Events(i).Pages(1).GraphicY
                                Case 0
                                    TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Dir = DIR_DOWN
                                Case 1
                                    TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Dir = DIR_LEFT
                                Case 2
                                    TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Dir = DIR_RIGHT
                                Case 3
                                    TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Dir = DIR_UP
                            End Select
                        Else
                            TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Dir = DIR_DOWN
                        End If
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).Active = 1

                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveType = Map(MapNum).Events(i).Pages(1).MoveType

                        If TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveType = 2 Then
                            TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveRouteCount = Map(MapNum).Events(i).Pages(1).MoveRouteCount
                            ReDim TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveRoute(0 To Map(MapNum).Events(i).Pages(1).MoveRouteCount)
                            For z = 0 To Map(MapNum).Events(i).Pages(1).MoveRouteCount
                                TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveRoute(z) = Map(MapNum).Events(i).Pages(1).MoveRoute(z)
                            Next
                            TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveRouteComplete = 0
                        Else
                            TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveRouteComplete = 1
                        End If

                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).RepeatMoveRoute = Map(MapNum).Events(i).Pages(1).RepeatMoveRoute
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).IgnoreIfCannotMove = Map(MapNum).Events(i).Pages(1).IgnoreMoveRoute

                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveFreq = Map(MapNum).Events(i).Pages(1).MoveFreq
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).MoveSpeed = Map(MapNum).Events(i).Pages(1).MoveSpeed

                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).WalkThrough = Map(MapNum).Events(i).Pages(1).WalkThrough
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).FixedDir = Map(MapNum).Events(i).Pages(1).DirFix
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).WalkingAnim = Map(MapNum).Events(i).Pages(1).WalkAnim
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).ShowName = Map(MapNum).Events(i).Pages(1).ShowName
                        TempEventMap(MapNum).Events(TempEventMap(MapNum).EventCount).QuestNum = Map(MapNum).Events(i).Pages(1).QuestNum
                    End If
                End If
            Next
        End If

    End Sub

    Public Sub SpawnMapEventsFor(Index As Long, MapNum As Long)
        Dim i As Long, z As Long, spawncurrentevent As Boolean, p As Long, compare As Long
        Dim Buffer As ByteBuffer

        TempPlayer(Index).EventMap.CurrentEvents = 0
        ReDim TempPlayer(Index).EventMap.EventPages(0)
        If Map(MapNum).EventCount > 0 Then
            ReDim TempPlayer(Index).EventProcessing(0 To Map(MapNum).EventCount)
            TempPlayer(Index).EventProcessingCount = Map(MapNum).EventCount
        Else
            ReDim TempPlayer(Index).EventProcessing(0)
            TempPlayer(Index).EventProcessingCount = 0
        End If

        If Map(MapNum).EventCount <= 0 Then Exit Sub
        For i = 1 To Map(MapNum).EventCount
            If Map(MapNum).Events(i).PageCount > 0 Then
                For z = Map(MapNum).Events(i).PageCount To 1 Step -1
                    With Map(MapNum).Events(i).Pages(z)
                        spawncurrentevent = True

                        If .chkVariable = 1 Then
                            Select Case .VariableCompare
                                Case 0
                                    If Player(Index).Variables(.VariableIndex) <> .VariableCondition Then
                                        spawncurrentevent = False
                                    End If
                                Case 1
                                    If Player(Index).Variables(.VariableIndex) < .VariableCondition Then
                                        spawncurrentevent = False
                                    End If
                                Case 2
                                    If Player(Index).Variables(.VariableIndex) > .VariableCondition Then
                                        spawncurrentevent = False
                                    End If
                                Case 3
                                    If Player(Index).Variables(.VariableIndex) <= .VariableCondition Then
                                        spawncurrentevent = False
                                    End If
                                Case 4
                                    If Player(Index).Variables(.VariableIndex) >= .VariableCondition Then
                                        spawncurrentevent = False
                                    End If
                                Case 5
                                    If Player(Index).Variables(.VariableIndex) = .VariableCondition Then
                                        spawncurrentevent = False
                                    End If
                            End Select
                        End If

                        'we are assuming the event will spawn, and are looking for ways to stop it
                        If .chkSwitch = 1 Then
                            If .SwitchCompare = 1 Then 'we want true
                                If Player(Index).Switches(.SwitchIndex) = 0 Then 'it is false, so we stop the spawn
                                    spawncurrentevent = False
                                End If
                            Else
                                If Player(Index).Switches(.SwitchIndex) = 1 Then 'we want false and it is true so we stop the spawn
                                    spawncurrentevent = False
                                End If
                            End If
                        End If

                        If .chkHasItem = 1 Then
                            If HasItem(Index, .HasItemIndex) = 0 Then
                                spawncurrentevent = False
                            End If
                        End If

                        If .chkSelfSwitch = 1 Then
                            If .SelfSwitchCompare = 0 Then
                                compare = 1
                            Else
                                compare = 0
                            End If
                            If Map(MapNum).Events(i).Globals = 1 Then
                                If Map(MapNum).Events(i).SelfSwitches(.SelfSwitchIndex) <> compare Then
                                    spawncurrentevent = False
                                End If
                            Else
                                If compare = 1 Then
                                    spawncurrentevent = False
                                End If
                            End If
                        End If

                        If spawncurrentevent = True Or (spawncurrentevent = False And z = 1) Then
                            'spawn the event... send data to player
                            TempPlayer(Index).EventMap.CurrentEvents = TempPlayer(Index).EventMap.CurrentEvents + 1
                            ReDim Preserve TempPlayer(Index).EventMap.EventPages(TempPlayer(Index).EventMap.CurrentEvents)
                            With TempPlayer(Index).EventMap.EventPages(TempPlayer(Index).EventMap.CurrentEvents)
                                If Map(MapNum).Events(i).Pages(z).GraphicType = 1 Then
                                    Select Case Map(MapNum).Events(i).Pages(z).GraphicY
                                        Case 0
                                            .Dir = DIR_DOWN
                                        Case 1
                                            .Dir = DIR_LEFT
                                        Case 2
                                            .Dir = DIR_RIGHT
                                        Case 3
                                            .Dir = DIR_UP
                                    End Select
                                Else
                                    .Dir = 0
                                End If
                                .GraphicNum = Map(MapNum).Events(i).Pages(z).Graphic
                                .GraphicType = Map(MapNum).Events(i).Pages(z).GraphicType
                                .GraphicX = Map(MapNum).Events(i).Pages(z).GraphicX
                                .GraphicY = Map(MapNum).Events(i).Pages(z).GraphicY
                                .GraphicX2 = Map(MapNum).Events(i).Pages(z).GraphicX2
                                .GraphicY2 = Map(MapNum).Events(i).Pages(z).GraphicY2
                                Select Case Map(MapNum).Events(i).Pages(z).MoveSpeed
                                    Case 0
                                        .MovementSpeed = 2
                                    Case 1
                                        .MovementSpeed = 3
                                    Case 2
                                        .MovementSpeed = 4
                                    Case 3
                                        .MovementSpeed = 6
                                    Case 4
                                        .MovementSpeed = 12
                                    Case 5
                                        .MovementSpeed = 24
                                End Select
                                If Map(MapNum).Events(i).Globals Then
                                    .X = TempEventMap(MapNum).Events(i).X
                                    .Y = TempEventMap(MapNum).Events(i).Y
                                    .Dir = TempEventMap(MapNum).Events(i).Dir
                                    .MoveRouteStep = TempEventMap(MapNum).Events(i).MoveRouteStep
                                Else
                                    .X = Map(MapNum).Events(i).X
                                    .Y = Map(MapNum).Events(i).Y
                                    .MoveRouteStep = 0
                                End If
                                .Position = Map(MapNum).Events(i).Pages(z).Position
                                .EventID = i
                                .PageID = z
                                If spawncurrentevent = True Then
                                    .Visible = 1
                                Else
                                    .Visible = 0
                                End If

                                .MoveType = Map(MapNum).Events(i).Pages(z).MoveType
                                If .MoveType = 2 Then
                                    .MoveRouteCount = Map(MapNum).Events(i).Pages(z).MoveRouteCount
                                    ReDim .MoveRoute(0 To Map(MapNum).Events(i).Pages(z).MoveRouteCount)
                                    If Map(MapNum).Events(i).Pages(z).MoveRouteCount > 0 Then
                                        For p = 0 To Map(MapNum).Events(i).Pages(z).MoveRouteCount
                                            .MoveRoute(p) = Map(MapNum).Events(i).Pages(z).MoveRoute(p)
                                        Next
                                    End If
                                    .MoveRouteComplete = 0
                                Else
                                    .MoveRouteComplete = 1
                                End If

                                .RepeatMoveRoute = Map(MapNum).Events(i).Pages(z).RepeatMoveRoute
                                .IgnoreIfCannotMove = Map(MapNum).Events(i).Pages(z).IgnoreMoveRoute

                                .MoveFreq = Map(MapNum).Events(i).Pages(z).MoveFreq
                                .MoveSpeed = Map(MapNum).Events(i).Pages(z).MoveSpeed

                                .WalkingAnim = Map(MapNum).Events(i).Pages(z).WalkAnim
                                .WalkThrough = Map(MapNum).Events(i).Pages(z).WalkThrough
                                .ShowName = Map(MapNum).Events(i).Pages(z).ShowName
                                .FixedDir = Map(MapNum).Events(i).Pages(z).DirFix
                                .QuestNum = Map(MapNum).Events(i).Pages(z).QuestNum
                            End With
                            GoTo nextevent
                        End If
                    End With
                Next
            End If
nextevent:
        Next

        If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
            For i = 1 To TempPlayer(Index).EventMap.CurrentEvents
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SSpawnEvent)
                Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(i).EventID)
                With TempPlayer(Index).EventMap.EventPages(i)
                    Buffer.WriteString(Trim$(Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Name))
                    Buffer.WriteLong(.Dir)
                    Buffer.WriteLong(.GraphicNum)
                    Buffer.WriteLong(.GraphicType)
                    Buffer.WriteLong(.GraphicX)
                    Buffer.WriteLong(.GraphicX2)
                    Buffer.WriteLong(.GraphicY)
                    Buffer.WriteLong(.GraphicY2)
                    Buffer.WriteLong(.MovementSpeed)
                    Buffer.WriteLong(.X)
                    Buffer.WriteLong(.Y)
                    Buffer.WriteLong(.Position)
                    Buffer.WriteLong(.Visible)
                    Buffer.WriteLong(Map(MapNum).Events(.EventID).Pages(.PageID).WalkAnim)
                    Buffer.WriteLong(Map(MapNum).Events(.EventID).Pages(.PageID).DirFix)
                    Buffer.WriteLong(Map(MapNum).Events(.EventID).Pages(.PageID).WalkThrough)
                    Buffer.WriteLong(Map(MapNum).Events(.EventID).Pages(.PageID).ShowName)
                    Buffer.WriteLong(Map(MapNum).Events(.EventID).Pages(.PageID).QuestNum)
                End With
                SendDataTo(Index, Buffer.ToArray)
                Buffer = Nothing
            Next
        End If

    End Sub
End Module
