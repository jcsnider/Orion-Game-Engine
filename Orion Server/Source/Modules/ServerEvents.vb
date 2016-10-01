
Public Module ServerEvents
#Region "Globals"
    Public TempEventMap() As GlobalEventsRec
    Public Switches() As String
    Public Variables() As String

    Public Const MAX_SWITCHES As Long = 1000
    Public Const MAX_VARIABLES As Long = 1000

    Public Const PathfindingType As Long = 1

    'Effect Constants - Used for event options...
    Public Const EFFECT_TYPE_FADEIN As Long = 2
    Public Const EFFECT_TYPE_FADEOUT As Long = 1
    Public Const EFFECT_TYPE_FLASH As Long = 3
    Public Const EFFECT_TYPE_FOG As Long = 4
    Public Const EFFECT_TYPE_WEATHER As Long = 5
    Public Const EFFECT_TYPE_TINT As Long = 6
#End Region

#Region "Types"
    Structure MoveRouteRec
        Dim Index As Long
        Dim Data1 As Long
        Dim Data2 As Long
        Dim Data3 As Long
        Dim Data4 As Long
        Dim Data5 As Long
        Dim Data6 As Long
    End Structure

    Structure GlobalEventRec
        Dim X As Long
        Dim Y As Long
        Dim Dir As Long
        Dim Active As Long

        Dim WalkingAnim As Long
        Dim FixedDir As Long
        Dim WalkThrough As Long
        Dim ShowName As Long

        Dim Position As Long

        Dim GraphicType As Long
        Dim GraphicNum As Long
        Dim GraphicX As Long
        Dim GraphicX2 As Long
        Dim GraphicY As Long
        Dim GraphicY2 As Long

        'Server Only Options
        Dim MoveType As Long
        Dim MoveSpeed As Long
        Dim MoveFreq As Long
        Dim MoveRouteCount As Long
        Dim MoveRoute() As MoveRouteRec
        Dim MoveRouteStep As Long

        Dim RepeatMoveRoute As Long
        Dim IgnoreIfCannotMove As Long

        Dim MoveTimer As Long
        Dim QuestNum As Long
        Dim MoveRouteComplete As Long
    End Structure

    Structure GlobalEventsRec
        Dim EventCount As Long
        Dim Events() As GlobalEventRec
    End Structure

    Public Structure ConditionalBranchRec
        Dim Condition As Long
        Dim Data1 As Long
        Dim Data2 As Long
        Dim Data3 As Long
        Dim CommandList As Long
        Dim ElseCommandList As Long
    End Structure

    Structure EventCommandRec
        Dim Index As Byte
        Dim Text1 As String
        Dim Text2 As String
        Dim Text3 As String
        Dim Text4 As String
        Dim Text5 As String
        Dim Data1 As Long
        Dim Data2 As Long
        Dim Data3 As Long
        Dim Data4 As Long
        Dim Data5 As Long
        Dim Data6 As Long
        Dim ConditionalBranch As ConditionalBranchRec
        Dim MoveRouteCount As Long
        Dim MoveRoute() As MoveRouteRec
    End Structure

    Structure CommandListRec
        Dim CommandCount As Long
        Dim ParentList As Long
        Dim Commands() As EventCommandRec
    End Structure

    Structure EventPageRec
        'These are condition variables that decide if the event even appears to the player.
        Dim chkVariable As Long
        Dim VariableIndex As Long
        Dim VariableCondition As Long
        Dim VariableCompare As Long

        Dim chkSwitch As Long
        Dim SwitchIndex As Long
        Dim SwitchCompare As Long

        Dim chkHasItem As Long
        Dim HasItemIndex As Long
        Dim HasItemAmount As Long

        Dim chkSelfSwitch As Long
        Dim SelfSwitchIndex As Long
        Dim SelfSwitchCompare As Long
        Dim chkPlayerGender As Long
        'End Conditions

        'Handles the Event Sprite
        Dim GraphicType As Byte
        Dim Graphic As Long
        Dim GraphicX As Long
        Dim GraphicY As Long
        Dim GraphicX2 As Long
        Dim GraphicY2 As Long

        'Handles Movement - Move Routes to come soon.
        Dim MoveType As Byte
        Dim MoveSpeed As Byte
        Dim MoveFreq As Byte
        Dim MoveRouteCount As Long
        Dim MoveRoute() As MoveRouteRec
        Dim IgnoreMoveRoute As Long
        Dim RepeatMoveRoute As Long

        'Guidelines for the event
        Dim WalkAnim As Long
        Dim DirFix As Long
        Dim WalkThrough As Long
        Dim ShowName As Long

        'Trigger for the event
        Dim Trigger As Byte

        'Commands for the event
        Dim CommandListCount As Long
        Dim CommandList() As CommandListRec

        Dim Position As Byte

        Dim QuestNum As Integer

        'For EventMap
        Dim X As Long
        Dim Y As Long
    End Structure

    Structure EventRec
        Dim Name As String
        Dim Globals As Byte
        Dim PageCount As Long
        Dim Pages() As EventPageRec
        Dim X As Long
        Dim Y As Long
        'Self Switches re-set on restart.
        Dim SelfSwitches() As Long '0 to 4
    End Structure

    Public Structure GlobalMapEvents
        Dim EventID As Long
        Dim PageID As Long
        Dim X As Long
        Dim Y As Long
    End Structure

    Structure MapEventRec
        Dim Dir As Long
        Dim X As Long
        Dim Y As Long

        Dim WalkingAnim As Long
        Dim FixedDir As Long
        Dim WalkThrough As Long
        Dim ShowName As Long

        Dim GraphicType As Long
        Dim GraphicX As Long
        Dim GraphicY As Long
        Dim GraphicX2 As Long
        Dim GraphicY2 As Long
        Dim GraphicNum As Long

        Dim MovementSpeed As Long
        Dim Position As Long
        Dim Visible As Long
        Dim EventID As Long
        Dim PageID As Long

        'Server Only Options
        Dim MoveType As Long
        Dim MoveSpeed As Long
        Dim MoveFreq As Long
        Dim MoveRouteCount As Long
        Dim MoveRoute() As MoveRouteRec
        Dim MoveRouteStep As Long

        Dim RepeatMoveRoute As Long
        Dim IgnoreIfCannotMove As Long
        Dim QuestNum As Long

        Dim MoveTimer As Long
        Dim SelfSwitches() As Long '0 to 4
        Dim MoveRouteComplete As Long
    End Structure

    Structure EventMapRec
        Dim CurrentEvents As Long
        Dim EventPages() As MapEventRec
    End Structure

    Structure EventProcessingRec
        Dim Active As Long
        Dim CurList As Long
        Dim CurSlot As Long
        Dim EventID As Long
        Dim PageID As Long
        Dim WaitingForResponse As Long
        Dim EventMovingID As Long
        Dim EventMovingType As Long
        Dim ActionTimer As Long
        Dim ListLeftOff() As Long
    End Structure
#End Region

#Region "Enums"
    Public Enum MoveRouteOpts
        MoveUp = 1
        MoveDown
        MoveLeft
        MoveRight
        MoveRandom
        MoveTowardsPlayer
        MoveAwayFromPlayer
        StepForward
        StepBack
        Wait100ms
        Wait500ms
        Wait1000ms
        TurnUp
        TurnDown
        TurnLeft
        TurnRight
        Turn90Right
        Turn90Left
        Turn180
        TurnRandom
        TurnTowardPlayer
        TurnAwayFromPlayer
        SetSpeed8xSlower
        SetSpeed4xSlower
        SetSpeed2xSlower
        SetSpeedNormal
        SetSpeed2xFaster
        SetSpeed4xFaster
        SetFreqLowest
        SetFreqLower
        SetFreqNormal
        SetFreqHigher
        SetFreqHighest
        WalkingAnimOn
        WalkingAnimOff
        DirFixOn
        DirFixOff
        WalkThroughOn
        WalkThroughOff
        PositionBelowPlayer
        PositionWithPlayer
        PositionAbovePlayer
        ChangeGraphic
    End Enum

    ' Event Types
    Public Enum EventType
        ' Message
        evAddText = 1
        evShowText
        evShowChoices
        ' Game Progression
        evPlayerVar
        evPlayerSwitch
        evSelfSwitch
        ' Flow Control
        evCondition
        evExitProcess
        ' Player
        evChangeItems
        evRestoreHP
        evRestoreMP
        evLevelUp
        evChangeLevel
        evChangeSkills
        evChangeClass
        evChangeSprite
        evChangeSex
        evChangePK
        ' Movement
        evWarpPlayer
        evSetMoveRoute
        ' Character
        evPlayAnimation
        ' Music and Sounds
        evPlayBGM
        evFadeoutBGM
        evPlaySound
        evStopSound
        'Etc...
        evCustomScript
        evSetAccess
        'Shop/Bank
        evOpenBank
        evOpenShop
        'New
        evGiveExp
        evShowChatBubble
        evLabel
        evGotoLabel
        evSpawnNpc
        evFadeIn
        evFadeOut
        evFlashWhite
        evSetFog
        evSetWeather
        evSetTint
        evWait
        evOpenMail
        evBeginQuest
        evEndQuest
        evQuestTask
        evShowPicture
        evHidePicture
        evWaitMovement
        evHoldPlayer
        evReleasePlayer
    End Enum
#End Region

#Region "database"
    Sub SaveSwitches()
        Dim i As Long, filename As String

        filename = Application.StartupPath & "\data\switches.ini"

        For i = 1 To MAX_SWITCHES
            PutVar(filename, "Switches", "Switch" & i & "Name", Switches(i))
        Next

    End Sub

    Sub SaveVariables()
        Dim i As Long, filename As String

        filename = Application.StartupPath & "\data\variables.ini"

        For i = 1 To MAX_VARIABLES
            PutVar(filename, "Variables", "Variable" & i & "Name", Variables(i))
        Next

    End Sub

    Sub LoadSwitches()
        Dim i As Long, filename As String

        filename = Application.StartupPath & "\data\switches.ini"

        For i = 1 To MAX_SWITCHES
            DoEvents()
            Switches(i) = Getvar(filename, "Switches", "Switch" & i & "Name")
        Next

    End Sub

    Sub LoadVariables()
        Dim i As Long, filename As String

        filename = Application.StartupPath & "\data\variables.ini"

        For i = 1 To MAX_VARIABLES
            DoEvents()
            Variables(i) = Getvar(filename, "Variables", "Variable" & i & "Name")
        Next

    End Sub
#End Region

#Region "Movement"
    Function CanEventMove(Index As Long, ByVal MapNum As Long, x As Long, y As Long, eventID As Long, WalkThrough As Long, ByVal Dir As Byte, Optional globalevent As Boolean = False) As Boolean
        Dim i As Long
        Dim n As Long, z As Long, begineventprocessing As Boolean

        ' Check for subscript out of range

        If MapNum <= 0 Or MapNum > MAX_MAPS Or Dir < DIR_UP Or Dir > DIR_RIGHT Then Exit Function

        If Gettingmap = True Then Exit Function

        CanEventMove = True

        If Index = 0 Then Exit Function

        Select Case Dir
            Case DIR_UP

                ' Check to make sure not outside of boundries
                If y > 0 Then
                    n = Map(MapNum).Tile(x, y - 1).Type

                    If WalkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If


                    ' Check to make sure that the tile is walkable
                    If n = TILE_TYPE_BLOCKED Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = x) And (GetPlayerY(i) = y - 1) Then
                                CanEventMove = False
                                'There IS a player in the way. But now maybe we can call the event touch thingy!
                                If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Process this event, it is on-touch and everything checks out.
                                        If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount > 0 Then
                                            TempPlayer(Index).EventProcessing(eventID).Active = 1
                                            TempPlayer(Index).EventProcessing(eventID).ActionTimer = GetTickCount()
                                            TempPlayer(Index).EventProcessing(eventID).CurList = 1
                                            TempPlayer(Index).EventProcessing(eventID).CurSlot = 1
                                            TempPlayer(Index).EventProcessing(eventID).EventID = eventID
                                            TempPlayer(Index).EventProcessing(eventID).PageID = TempPlayer(Index).EventMap.EventPages(eventID).PageID
                                            TempPlayer(Index).EventProcessing(eventID).WaitingForResponse = 0
                                            ReDim TempPlayer(Index).EventProcessing(eventID).ListLeftOff(0 To Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function
                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).x = x) And (MapNpc(MapNum).Npc(i).y = y - 1) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True Then
                        If TempEventMap(MapNum).EventCount > 0 Then
                            For z = 1 To TempEventMap(MapNum).EventCount
                                If (z <> eventID) And (z > 0) And (TempEventMap(MapNum).Events(z).X = x) And (TempEventMap(MapNum).Events(z).Y = y - 1) And (TempEventMap(MapNum).Events(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    Else
                        If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(Index).EventMap.CurrentEvents
                                If (TempPlayer(Index).EventMap.EventPages(z).EventID <> eventID) And (eventID > 0) And (TempPlayer(Index).EventMap.EventPages(z).X = TempPlayer(Index).EventMap.EventPages(eventID).X) And (TempPlayer(Index).EventMap.EventPages(z).Y = TempPlayer(Index).EventMap.EventPages(eventID).Y - 1) And (TempPlayer(Index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(x, y).DirBlock, DIR_UP + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

            Case DIR_DOWN

                ' Check to make sure not outside of boundries
                If y < Map(MapNum).MaxY Then
                    n = Map(MapNum).Tile(x, y + 1).Type

                    If WalkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Check to make sure that the tile is walkable
                    If n = TILE_TYPE_BLOCKED Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = x) And (GetPlayerY(i) = y + 1) Then
                                CanEventMove = False
                                'There IS a player in the way. But now maybe we can call the event touch thingy!
                                If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Process this event, it is on-touch and everything checks out.
                                        If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount > 0 Then
                                            TempPlayer(Index).EventProcessing(eventID).Active = 1
                                            TempPlayer(Index).EventProcessing(eventID).ActionTimer = GetTickCount()
                                            TempPlayer(Index).EventProcessing(eventID).CurList = 1
                                            TempPlayer(Index).EventProcessing(eventID).CurSlot = 1
                                            TempPlayer(Index).EventProcessing(eventID).EventID = eventID
                                            TempPlayer(Index).EventProcessing(eventID).PageID = TempPlayer(Index).EventMap.EventPages(eventID).PageID
                                            TempPlayer(Index).EventProcessing(eventID).WaitingForResponse = 0
                                            ReDim TempPlayer(Index).EventProcessing(eventID).ListLeftOff(0 To Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).x = x) And (MapNpc(MapNum).Npc(i).y = y + 1) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True Then
                        If TempEventMap(MapNum).EventCount > 0 Then
                            For z = 1 To TempEventMap(MapNum).EventCount
                                If (z <> eventID) And (z > 0) And (TempEventMap(MapNum).Events(z).X = x) And (TempEventMap(MapNum).Events(z).Y = y + 1) And (TempEventMap(MapNum).Events(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    Else
                        If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(Index).EventMap.CurrentEvents
                                If (TempPlayer(Index).EventMap.EventPages(z).EventID <> eventID) And (eventID > 0) And (TempPlayer(Index).EventMap.EventPages(z).X = TempPlayer(Index).EventMap.EventPages(eventID).X) And (TempPlayer(Index).EventMap.EventPages(z).Y = TempPlayer(Index).EventMap.EventPages(eventID).Y + 1) And (TempPlayer(Index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(x, y).DirBlock, DIR_DOWN + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

            Case DIR_LEFT

                ' Check to make sure not outside of boundries
                If x > 0 Then
                    n = Map(MapNum).Tile(x - 1, y).Type

                    If WalkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Check to make sure that the tile is walkable
                    If n = TILE_TYPE_BLOCKED Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = x - 1) And (GetPlayerY(i) = y) Then
                                CanEventMove = False
                                'There IS a player in the way. But now maybe we can call the event touch thingy!
                                If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Process this event, it is on-touch and everything checks out.
                                        If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount > 0 Then
                                            TempPlayer(Index).EventProcessing(eventID).Active = 1
                                            TempPlayer(Index).EventProcessing(eventID).ActionTimer = GetTickCount()
                                            TempPlayer(Index).EventProcessing(eventID).CurList = 1
                                            TempPlayer(Index).EventProcessing(eventID).CurSlot = 1
                                            TempPlayer(Index).EventProcessing(eventID).EventID = eventID
                                            TempPlayer(Index).EventProcessing(eventID).PageID = TempPlayer(Index).EventMap.EventPages(eventID).PageID
                                            TempPlayer(Index).EventProcessing(eventID).WaitingForResponse = 0
                                            ReDim TempPlayer(Index).EventProcessing(eventID).ListLeftOff(0 To Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).x = x - 1) And (MapNpc(MapNum).Npc(i).y = y) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True Then
                        If TempEventMap(MapNum).EventCount > 0 Then
                            For z = 1 To TempEventMap(MapNum).EventCount
                                If (z <> eventID) And (z > 0) And (TempEventMap(MapNum).Events(z).X = x - 1) And (TempEventMap(MapNum).Events(z).Y = y) And (TempEventMap(MapNum).Events(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    Else
                        If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(Index).EventMap.CurrentEvents
                                If (TempPlayer(Index).EventMap.EventPages(z).EventID <> eventID) And (eventID > 0) And (TempPlayer(Index).EventMap.EventPages(z).X = TempPlayer(Index).EventMap.EventPages(eventID).X - 1) And (TempPlayer(Index).EventMap.EventPages(z).Y = TempPlayer(Index).EventMap.EventPages(eventID).Y) And (TempPlayer(Index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(x, y).DirBlock, DIR_LEFT + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

            Case DIR_RIGHT

                ' Check to make sure not outside of boundries
                If x < Map(MapNum).MaxX Then
                    n = Map(MapNum).Tile(x + 1, y).Type

                    If WalkThrough = 1 Then
                        CanEventMove = True
                        Exit Function
                    End If

                    ' Check to make sure that the tile is walkable
                    If n = TILE_TYPE_BLOCKED Then
                        CanEventMove = False
                        Exit Function
                    End If

                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanEventMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = x + 1) And (GetPlayerY(i) = y) Then
                                CanEventMove = False
                                'There IS a player in the way. But now maybe we can call the event touch thingy!
                                If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).Trigger = 1 Then
                                    begineventprocessing = True
                                    If begineventprocessing = True Then
                                        'Process this event, it is on-touch and everything checks out.
                                        If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount > 0 Then
                                            TempPlayer(Index).EventProcessing(eventID).Active = 1
                                            TempPlayer(Index).EventProcessing(eventID).ActionTimer = GetTickCount()
                                            TempPlayer(Index).EventProcessing(eventID).CurList = 1
                                            TempPlayer(Index).EventProcessing(eventID).CurSlot = 1
                                            TempPlayer(Index).EventProcessing(eventID).EventID = eventID
                                            TempPlayer(Index).EventProcessing(eventID).PageID = TempPlayer(Index).EventMap.EventPages(eventID).PageID
                                            TempPlayer(Index).EventProcessing(eventID).WaitingForResponse = 0
                                            ReDim TempPlayer(Index).EventProcessing(eventID).ListLeftOff(0 To Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(Index).EventMap.EventPages(eventID).PageID).CommandListCount)
                                        End If
                                        begineventprocessing = False
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If CanEventMove = False Then Exit Function

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).x = x + 1) And (MapNpc(MapNum).Npc(i).y = y) Then
                            CanEventMove = False
                            Exit Function
                        End If
                    Next

                    If globalevent = True Then
                        If TempEventMap(MapNum).EventCount > 0 Then
                            For z = 1 To TempEventMap(MapNum).EventCount
                                If (z <> eventID) And (z > 0) And (TempEventMap(MapNum).Events(z).X = x + 1) And (TempEventMap(MapNum).Events(z).Y = y) And (TempEventMap(MapNum).Events(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    Else
                        If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
                            For z = 1 To TempPlayer(Index).EventMap.CurrentEvents
                                If (TempPlayer(Index).EventMap.EventPages(z).EventID <> eventID) And (eventID > 0) And (TempPlayer(Index).EventMap.EventPages(z).X = TempPlayer(Index).EventMap.EventPages(eventID).X + 1) And (TempPlayer(Index).EventMap.EventPages(z).Y = TempPlayer(Index).EventMap.EventPages(eventID).Y) And (TempPlayer(Index).EventMap.EventPages(z).WalkThrough = 0) Then
                                    CanEventMove = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(x, y).DirBlock, DIR_RIGHT + 1) Then
                        CanEventMove = False
                        Exit Function
                    End If
                Else
                    CanEventMove = False
                End If

        End Select

    End Function

    Sub EventDir(PlayerIndex As Long, ByVal MapNum As Long, ByVal eventID As Long, ByVal Dir As Long, Optional globalevent As Boolean = False)
        Dim Buffer As ByteBuffer
        Dim eventIndex As Long, i As Long

        ' Check for subscript out of range

        If Gettingmap = True Then Exit Sub

        If MapNum <= 0 Or MapNum > MAX_MAPS Or Dir < DIR_UP Or Dir > DIR_RIGHT Then
            Exit Sub
        End If

        If globalevent = False Then
            If TempPlayer(PlayerIndex).EventMap.CurrentEvents > 0 Then
                For i = 1 To TempPlayer(PlayerIndex).EventMap.CurrentEvents
                    If eventID = i Then
                        eventIndex = eventID
                        eventID = TempPlayer(PlayerIndex).EventMap.EventPages(i).EventID
                        Exit For
                    End If
                Next
            End If

            If eventIndex = 0 Or eventID = 0 Then Exit Sub
        End If

        If globalevent Then
            If Map(MapNum).Events(eventID).Pages(1).DirFix = 0 Then TempEventMap(MapNum).Events(eventID).Dir = Dir
        Else
            If Map(MapNum).Events(eventID).Pages(TempPlayer(PlayerIndex).EventMap.EventPages(eventIndex).PageID).DirFix = 0 Then TempPlayer(PlayerIndex).EventMap.EventPages(eventIndex).Dir = Dir
        End If

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SEventDir)
        Buffer.WriteLong(eventID)

        If globalevent Then
            Buffer.WriteLong(TempEventMap(MapNum).Events(eventID).Dir)
        Else
            Buffer.WriteLong(TempPlayer(PlayerIndex).EventMap.EventPages(eventIndex).Dir)
        End If

        SendDataToMap(MapNum, Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Sub EventMove(Index As Long, MapNum As Long, ByVal eventID As Long, ByVal Dir As Long, movementspeed As Long, Optional globalevent As Boolean = False)
        Dim Buffer As ByteBuffer
        Dim eventIndex As Long, i As Long

        ' Check for subscript out of range
        If Gettingmap = True Then Exit Sub

        If MapNum <= 0 Or MapNum > MAX_MAPS Or Dir < DIR_UP Or Dir > DIR_RIGHT Then
            Exit Sub
        End If

        If globalevent = False Then
            If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
                For i = 1 To TempPlayer(Index).EventMap.CurrentEvents
                    If eventID = i Then
                        eventIndex = eventID
                        eventID = TempPlayer(Index).EventMap.EventPages(i).EventID
                        Exit For
                    End If
                Next
            End If

            If eventIndex = 0 Or eventID = 0 Then Exit Sub
        Else
            eventIndex = eventID
            If eventIndex = 0 Then Exit Sub
        End If

        If globalevent Then
            If Map(MapNum).Events(eventID).Pages(1).DirFix = 0 Then TempEventMap(MapNum).Events(eventID).Dir = Dir
        Else
            If Map(MapNum).Events(eventID).Pages(TempPlayer(Index).EventMap.EventPages(eventIndex).PageID).DirFix = 0 Then TempPlayer(Index).EventMap.EventPages(eventIndex).Dir = Dir
        End If

        Select Case Dir
            Case DIR_UP
                If globalevent Then
                    TempEventMap(MapNum).Events(eventIndex).Y = TempEventMap(MapNum).Events(eventIndex).Y - 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).X)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                Else
                    TempPlayer(Index).EventMap.EventPages(eventIndex).Y = TempPlayer(Index).EventMap.EventPages(eventIndex).Y - 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).X)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                End If

            Case DIR_DOWN
                If globalevent Then
                    TempEventMap(MapNum).Events(eventIndex).Y = TempEventMap(MapNum).Events(eventIndex).Y + 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).X)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                Else
                    TempPlayer(Index).EventMap.EventPages(eventIndex).Y = TempPlayer(Index).EventMap.EventPages(eventIndex).Y + 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).X)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                End If
            Case DIR_LEFT
                If globalevent Then
                    TempEventMap(MapNum).Events(eventIndex).X = TempEventMap(MapNum).Events(eventIndex).X - 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).X)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                Else
                    TempPlayer(Index).EventMap.EventPages(eventIndex).X = TempPlayer(Index).EventMap.EventPages(eventIndex).X - 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).X)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                End If
            Case DIR_RIGHT
                If globalevent Then
                    TempEventMap(MapNum).Events(eventIndex).X = TempEventMap(MapNum).Events(eventIndex).X + 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).X)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempEventMap(MapNum).Events(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                Else
                    TempPlayer(Index).EventMap.EventPages(eventIndex).X = TempPlayer(Index).EventMap.EventPages(eventIndex).X + 1
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SEventMove)
                    Buffer.WriteLong(eventID)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).X)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Y)
                    Buffer.WriteLong(Dir)
                    Buffer.WriteLong(TempPlayer(Index).EventMap.EventPages(eventIndex).Dir)
                    Buffer.WriteLong(movementspeed)
                    If globalevent Then
                        SendDataToMap(MapNum, Buffer.ToArray)
                    Else
                        SendDataTo(Index, Buffer.ToArray)
                    End If
                    Buffer = Nothing
                End If
        End Select

    End Sub

    Function IsOneBlockAway(x1 As Long, y1 As Long, x2 As Long, y2 As Long) As Boolean

        If x1 = x2 Then
            If y1 = y2 - 1 Or y1 = y2 + 1 Then
                IsOneBlockAway = True
            Else
                IsOneBlockAway = False
            End If
        ElseIf y1 = y2 Then
            If x1 = x2 - 1 Or x1 = x2 + 1 Then
                IsOneBlockAway = True
            Else
                IsOneBlockAway = False
            End If
        Else
            IsOneBlockAway = False
        End If

    End Function

    Function GetNpcDir(x As Long, y As Long, x1 As Long, y1 As Long) As Long
        Dim i As Long, distance As Long

        i = DIR_RIGHT

        If x - x1 > 0 Then
            If x - x1 > distance Then
                i = DIR_RIGHT
                distance = x - x1
            End If
        ElseIf x - x1 < 0 Then
            If ((x - x1) * -1) > distance Then
                i = DIR_LEFT
                distance = ((x - x1) * -1)
            End If
        End If

        If y - y1 > 0 Then
            If y - y1 > distance Then
                i = DIR_DOWN
                distance = y - y1
            End If
        ElseIf y - y1 < 0 Then
            If ((y - y1) * -1) > distance Then
                i = DIR_UP
                distance = ((y - y1) * -1)
            End If
        End If

        GetNpcDir = i

    End Function

    Function CanEventMoveTowardsPlayer(playerID As Long, MapNum As Long, eventID As Long) As Long
        Dim i As Long, x As Long, y As Long, x1 As Long, y1 As Long, didwalk As Boolean, WalkThrough As Long
        Dim tim As Long, sX As Long, sY As Long, pos(,) As Long, reachable As Boolean, j As Long, LastSum As Long, Sum As Long, FX As Long, FY As Long
        Dim path() As Point, LastX As Long, LastY As Long, did As Boolean
        'This does not work for global events so this MUST be a player one....
        'This Event returns a direction, 4 is not a valid direction so we assume fail unless otherwise told.

        CanEventMoveTowardsPlayer = 4
        If playerID <= 0 Or playerID > MAX_PLAYERS Then Exit Function
        If MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Function
        If eventID <= 0 Or eventID > TempPlayer(playerID).EventMap.CurrentEvents Then Exit Function
        If Gettingmap = True Then Exit Function

        x = GetPlayerX(playerID)
        y = GetPlayerY(playerID)
        x1 = TempPlayer(playerID).EventMap.EventPages(eventID).X
        y1 = TempPlayer(playerID).EventMap.EventPages(eventID).Y
        WalkThrough = Map(MapNum).Events(TempPlayer(playerID).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(playerID).EventMap.EventPages(eventID).PageID).WalkThrough
        'Add option for pathfinding to random guessing option.

        If PathfindingType = 1 Then
            i = Int(Rnd() * 5)
            didwalk = False

            ' Lets move the event
            Select Case i
                Case 0

                    ' Up
                    If y1 > y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                            CanEventMoveTowardsPlayer = DIR_UP
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Down
                    If y1 < y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                            CanEventMoveTowardsPlayer = DIR_DOWN
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Left
                    If x1 > x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                            CanEventMoveTowardsPlayer = DIR_LEFT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Right
                    If x1 < x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                            CanEventMoveTowardsPlayer = DIR_RIGHT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                Case 1

                    ' Right
                    If x1 < x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                            CanEventMoveTowardsPlayer = DIR_RIGHT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Left
                    If x1 > x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                            CanEventMoveTowardsPlayer = DIR_LEFT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Down
                    If y1 < y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                            CanEventMoveTowardsPlayer = DIR_DOWN
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Up
                    If y1 > y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                            CanEventMoveTowardsPlayer = DIR_UP
                            Exit Function
                            didwalk = True
                        End If
                    End If

                Case 2

                    ' Down
                    If y1 < y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                            CanEventMoveTowardsPlayer = DIR_DOWN
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Up
                    If y1 > y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                            CanEventMoveTowardsPlayer = DIR_UP
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Right
                    If x1 < x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                            CanEventMoveTowardsPlayer = DIR_RIGHT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Left
                    If x1 > x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                            CanEventMoveTowardsPlayer = DIR_LEFT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                Case 3

                    ' Left
                    If x1 > x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                            CanEventMoveTowardsPlayer = DIR_LEFT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Right
                    If x1 < x And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                            CanEventMoveTowardsPlayer = DIR_RIGHT
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Up
                    If y1 > y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                            CanEventMoveTowardsPlayer = DIR_UP
                            Exit Function
                            didwalk = True
                        End If
                    End If

                    ' Down
                    If y1 < y And Not didwalk Then
                        If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                            CanEventMoveTowardsPlayer = DIR_DOWN
                            Exit Function
                            didwalk = True
                        End If
                    End If
            End Select
            CanEventMoveTowardsPlayer = Random(0, 3)
        ElseIf PathfindingType = 2 Then
            'Initialization phase
            tim = 0
            sX = x1
            sY = y1
            FX = x
            FY = y

            ReDim pos(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

            For i = 1 To TempPlayer(playerID).EventMap.CurrentEvents
                If TempPlayer(playerID).EventMap.EventPages(i).Visible Then
                    If TempPlayer(playerID).EventMap.EventPages(i).WalkThrough = 1 Then
                        pos(TempPlayer(playerID).EventMap.EventPages(i).X, TempPlayer(playerID).EventMap.EventPages(i).Y) = 9
                    End If
                End If
            Next

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
                        CanEventMoveTowardsPlayer = 4
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
                CanEventMoveTowardsPlayer = DIR_RIGHT
            ElseIf path(1).y > LastY Then
                CanEventMoveTowardsPlayer = DIR_DOWN
            ElseIf path(1).y < LastY Then
                CanEventMoveTowardsPlayer = DIR_UP
            ElseIf path(1).x < LastX Then
                CanEventMoveTowardsPlayer = DIR_LEFT
            End If

        End If

    End Function

    Function CanEventMoveAwayFromPlayer(playerID As Long, MapNum As Long, eventID As Long) As Long
        Dim i As Long, x As Long, y As Long, x1 As Long, y1 As Long, didwalk As Boolean, WalkThrough As Long
        'This does not work for global events so this MUST be a player one....
        'This Event returns a direction, 5 is not a valid direction so we assume fail unless otherwise told.

        CanEventMoveAwayFromPlayer = 5
        If playerID <= 0 Or playerID > MAX_PLAYERS Then Exit Function
        If MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Function
        If eventID <= 0 Or eventID > TempPlayer(playerID).EventMap.CurrentEvents Then Exit Function
        If Gettingmap = True Then Exit Function

        x = GetPlayerX(playerID)
        y = GetPlayerY(playerID)
        x1 = TempPlayer(playerID).EventMap.EventPages(eventID).X
        y1 = TempPlayer(playerID).EventMap.EventPages(eventID).Y
        WalkThrough = Map(MapNum).Events(TempPlayer(playerID).EventMap.EventPages(eventID).EventID).Pages(TempPlayer(playerID).EventMap.EventPages(eventID).PageID).WalkThrough

        i = Int(Rnd() * 5)
        didwalk = False

        ' Lets move the event
        Select Case i
            Case 0

                ' Up
                If y1 > y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                        CanEventMoveAwayFromPlayer = DIR_DOWN
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Down
                If y1 < y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                        CanEventMoveAwayFromPlayer = DIR_UP
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Left
                If x1 > x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_RIGHT
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Right
                If x1 < x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_LEFT
                        Exit Function
                        didwalk = True
                    End If
                End If

            Case 1

                ' Right
                If x1 < x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_LEFT
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Left
                If x1 > x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_RIGHT
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Down
                If y1 < y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                        CanEventMoveAwayFromPlayer = DIR_UP
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Up
                If y1 > y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                        CanEventMoveAwayFromPlayer = DIR_DOWN
                        Exit Function
                        didwalk = True
                    End If
                End If

            Case 2

                ' Down
                If y1 < y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                        CanEventMoveAwayFromPlayer = DIR_UP
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Up
                If y1 > y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                        CanEventMoveAwayFromPlayer = DIR_DOWN
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Right
                If x1 < x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_LEFT
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Left
                If x1 > x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_RIGHT
                        Exit Function
                        didwalk = True
                    End If
                End If

            Case 3

                ' Left
                If x1 > x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_RIGHT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_RIGHT
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Right
                If x1 < x And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_LEFT, False) Then
                        CanEventMoveAwayFromPlayer = DIR_LEFT
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Up
                If y1 > y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_DOWN, False) Then
                        CanEventMoveAwayFromPlayer = DIR_DOWN
                        Exit Function
                        didwalk = True
                    End If
                End If

                ' Down
                If y1 < y And Not didwalk Then
                    If CanEventMove(playerID, MapNum, x1, y1, eventID, WalkThrough, DIR_UP, False) Then
                        CanEventMoveAwayFromPlayer = DIR_UP
                        Exit Function
                        didwalk = True
                    End If
                End If

        End Select

        CanEventMoveAwayFromPlayer = Random(0, 3)

    End Function

    Function GetDirToPlayer(playerID As Long, MapNum As Long, eventID As Long) As Long
        Dim i As Long, x As Long, y As Long, x1 As Long, y1 As Long, distance As Long
        'This does not work for global events so this MUST be a player one....
        'This Event returns a direction, 5 is not a valid direction so we assume fail unless otherwise told.

        If playerID <= 0 Or playerID > MAX_PLAYERS Then Exit Function
        If MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Function
        If eventID <= 0 Or eventID > TempPlayer(playerID).EventMap.CurrentEvents Then Exit Function

        x = GetPlayerX(playerID)
        y = GetPlayerY(playerID)
        x1 = TempPlayer(playerID).EventMap.EventPages(eventID).X
        y1 = TempPlayer(playerID).EventMap.EventPages(eventID).Y

        i = DIR_RIGHT

        If x - x1 > 0 Then
            If x - x1 > distance Then
                i = DIR_RIGHT
                distance = x - x1
            End If
        ElseIf x - x1 < 0 Then
            If ((x - x1) * -1) > distance Then
                i = DIR_LEFT
                distance = ((x - x1) * -1)
            End If
        End If

        If y - y1 > 0 Then
            If y - y1 > distance Then
                i = DIR_DOWN
                distance = y - y1
            End If
        ElseIf y - y1 < 0 Then
            If ((y - y1) * -1) > distance Then
                i = DIR_UP
                distance = ((y - y1) * -1)
            End If
        End If

        GetDirToPlayer = i

    End Function

    Function GetDirAwayFromPlayer(playerID As Long, MapNum As Long, eventID As Long) As Long
        Dim i As Long, x As Long, y As Long, x1 As Long, y1 As Long, distance As Long
        'This does not work for global events so this MUST be a player one....
        'This Event returns a direction, 5 is not a valid direction so we assume fail unless otherwise told.

        If playerID <= 0 Or playerID > MAX_PLAYERS Then Exit Function
        If MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Function
        If eventID <= 0 Or eventID > TempPlayer(playerID).EventMap.CurrentEvents Then Exit Function

        x = GetPlayerX(playerID)
        y = GetPlayerY(playerID)
        x1 = TempPlayer(playerID).EventMap.EventPages(eventID).X
        y1 = TempPlayer(playerID).EventMap.EventPages(eventID).Y


        i = DIR_RIGHT

        If x - x1 > 0 Then
            If x - x1 > distance Then
                i = DIR_LEFT
                distance = x - x1
            End If
        ElseIf x - x1 < 0 Then
            If ((x - x1) * -1) > distance Then
                i = DIR_RIGHT
                distance = ((x - x1) * -1)
            End If
        End If

        If y - y1 > 0 Then
            If y - y1 > distance Then
                i = DIR_UP
                distance = y - y1
            End If
        ElseIf y - y1 < 0 Then
            If ((y - y1) * -1) > distance Then
                i = DIR_DOWN
                distance = ((y - y1) * -1)
            End If
        End If

        GetDirAwayFromPlayer = i

    End Function
#End Region

#Region "Incoming Packets"
    Sub Packet_EventChatReply(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim eventID As Long, pageID As Long, reply As Long, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CEventChatReply Then Exit Sub

        eventID = Buffer.ReadLong
        pageID = Buffer.ReadLong
        reply = Buffer.ReadLong
        'Think I saved. Anyways... lol  This sub is broken because that line should be called when okay is pressed in a dialog
        If TempPlayer(index).EventProcessingCount > 0 Then
            For i = 1 To TempPlayer(index).EventProcessingCount
                If TempPlayer(index).EventProcessing(i).EventID = eventID And TempPlayer(index).EventProcessing(i).PageID = pageID Then
                    If TempPlayer(index).EventProcessing(i).WaitingForResponse = 1 Then
                        If reply = 0 Then
                            If Map(GetPlayerMap(index)).Events(eventID).Pages(pageID).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Index = EventType.evShowText Then
                                TempPlayer(index).EventProcessing(i).WaitingForResponse = 0
                            End If
                        ElseIf reply > 0 Then
                            If Map(GetPlayerMap(index)).Events(eventID).Pages(pageID).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Index = EventType.evShowChoices Then
                                Select Case reply
                                    Case 1
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventID).Pages(pageID).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data1
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                    Case 2
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventID).Pages(pageID).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data2
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                    Case 3
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventID).Pages(pageID).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data3
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                    Case 4
                                        TempPlayer(index).EventProcessing(i).ListLeftOff(TempPlayer(index).EventProcessing(i).CurList) = TempPlayer(index).EventProcessing(i).CurSlot - 1
                                        TempPlayer(index).EventProcessing(i).CurList = Map(GetPlayerMap(index)).Events(eventID).Pages(pageID).CommandList(TempPlayer(index).EventProcessing(i).CurList).Commands(TempPlayer(index).EventProcessing(i).CurSlot - 1).Data4
                                        TempPlayer(index).EventProcessing(i).CurSlot = 1
                                End Select
                            End If
                            TempPlayer(index).EventProcessing(i).WaitingForResponse = 0
                        End If
                    End If
                End If
            Next
        End If

        Buffer = Nothing

    End Sub

    Sub Packet_Event(ByVal index As Long, ByVal data() As Byte)
        Dim i As Long

        Dim x As Long, y As Long, begineventprocessing As Boolean, z As Long, Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CEvent Then Exit Sub

        i = Buffer.ReadLong
        Buffer = Nothing

        Select Case GetPlayerDir(index)
            Case DIR_UP

                If GetPlayerY(index) = 0 Then Exit Sub
                x = GetPlayerX(index)
                y = GetPlayerY(index) - 1
            Case DIR_DOWN

                If GetPlayerY(index) = Map(GetPlayerMap(index)).MaxY Then Exit Sub
                x = GetPlayerX(index)
                y = GetPlayerY(index) + 1
            Case DIR_LEFT

                If GetPlayerX(index) = 0 Then Exit Sub
                x = GetPlayerX(index) - 1
                y = GetPlayerY(index)
            Case DIR_RIGHT

                If GetPlayerX(index) = Map(GetPlayerMap(index)).MaxX Then Exit Sub
                x = GetPlayerX(index) + 1
                y = GetPlayerY(index)
        End Select



        If TempPlayer(index).EventMap.CurrentEvents > 0 Then
            For z = 1 To TempPlayer(index).EventMap.CurrentEvents
                If TempPlayer(index).EventMap.EventPages(z).EventID = i Then
                    i = z
                    begineventprocessing = True
                    Exit For
                End If
            Next
        End If

        If begineventprocessing = True Then
            If Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventID).Pages(TempPlayer(index).EventMap.EventPages(i).PageID).CommandListCount > 0 Then
                'Process this event, it is action button and everything checks out.
                If (TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventID).Active = 0) Then
                    TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventID).Active = 1
                    With TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventID)
                        .ActionTimer = GetTickCount()
                        .CurList = 1
                        .CurSlot = 1
                        .EventID = TempPlayer(index).EventMap.EventPages(i).EventID
                        .PageID = TempPlayer(index).EventMap.EventPages(i).PageID
                        .WaitingForResponse = 0
                        ReDim .ListLeftOff(0 To Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventID).Pages(TempPlayer(index).EventMap.EventPages(i).PageID).CommandListCount)
                    End With
                End If
            End If
                begineventprocessing = False
        End If

    End Sub

    Sub Packet_RequestSwitchesAndVariables(ByVal index As Long, ByVal data() As Byte)

        SendSwitchesAndVariables(index)

    End Sub

    Sub Packet_SwitchesAndVariables(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CSwitchesAndVariables Then Exit Sub

        For i = 1 To MAX_SWITCHES
            Switches(i) = Buffer.ReadString
        Next

        For i = 1 To MAX_VARIABLES
            Variables(i) = Buffer.ReadString
        Next

        SaveSwitches()
        SaveVariables()

        Buffer = Nothing

        SendSwitchesAndVariables(0, True)

    End Sub

    Sub Packet_EventTouch(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CEventTouch Then Exit Sub

        i = Buffer.ReadLong
        If Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(i).PageID).Trigger = 1 Then
            'Process this event, it is on-touch and everything checks out.
            If Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(TempPlayer(Index).EventMap.EventPages(i).EventID).PageID).CommandListCount > 0 Then
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).Active = 1
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).ActionTimer = GetTickCount()
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).CurList = 1
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).CurSlot = 1
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).EventID = TempPlayer(Index).EventMap.EventPages(i).EventID
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).PageID = TempPlayer(Index).EventMap.EventPages(i).PageID
                TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).WaitingForResponse = 0
                ReDim TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).ListLeftOff(0 To Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(i).PageID).CommandListCount)
            End If
        End If
        Buffer = Nothing

    End Sub
#End Region

#Region "Outgoing Packets"
    Sub SendSpecialEffect(ByVal Index As Long, EffectType As Long, Optional Data1 As Long = 0, Optional Data2 As Long = 0, Optional Data3 As Long = 0, Optional Data4 As Long = 0)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SSpecialEffect)

        Select Case EffectType
            Case EFFECT_TYPE_FADEIN
                Buffer.WriteLong(EffectType)
            Case EFFECT_TYPE_FADEOUT
                Buffer.WriteLong(EffectType)
            Case EFFECT_TYPE_FLASH
                Buffer.WriteLong(EffectType)
            Case EFFECT_TYPE_FOG
                Buffer.WriteLong(EffectType)
                Buffer.WriteLong(Data1) 'fognum
                Buffer.WriteLong(Data2) 'fog movement speed
                Buffer.WriteLong(Data3) 'opacity
            Case EFFECT_TYPE_WEATHER
                Buffer.WriteLong(EffectType)
                Buffer.WriteLong(Data1) 'weather type
                Buffer.WriteLong(Data2) 'weather intensity
            Case EFFECT_TYPE_TINT
                Buffer.WriteLong(EffectType)
                Buffer.WriteLong(Data1) 'red
                Buffer.WriteLong(Data2) 'green
                Buffer.WriteLong(Data3) 'blue
                Buffer.WriteLong(Data4) 'alpha
        End Select

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendChatBubble(ByVal MapNum As Long, ByVal Target As Long, ByVal TargetType As Long, ByVal message As String, ByVal Colour As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SChatBubble)
        Buffer.WriteLong(Target)
        Buffer.WriteLong(TargetType)
        Buffer.WriteString(message)
        Buffer.WriteLong(Colour)
        SendDataToMap(MapNum, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendSwitchesAndVariables(Index As Long, Optional everyone As Boolean = False)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SSwitchesAndVariables)

        For i = 1 To MAX_SWITCHES
            Buffer.WriteString(Trim(Switches(i)))
        Next

        For i = 1 To MAX_VARIABLES
            Buffer.WriteString(Trim(Variables(i)))
        Next

        If everyone Then
            SendDataToAll(Buffer.ToArray)
        Else
            SendDataTo(Index, Buffer.ToArray)
        End If

        Buffer = Nothing

    End Sub

    Sub SendMapEventData(Index As Long)
        Dim Buffer As ByteBuffer, i As Long, x As Long, y As Long, z As Long, MapNum As Long, w As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapEventData)
        MapNum = GetPlayerMap(Index)
        'Event Data
        Buffer.WriteLong(Map(MapNum).EventCount)

        If Map(MapNum).EventCount > 0 Then
            For i = 1 To Map(MapNum).EventCount
                With Map(MapNum).Events(i)
                    Buffer.WriteString(Trim(.Name))
                    Buffer.WriteLong(.Globals)
                    Buffer.WriteLong(.X)
                    Buffer.WriteLong(.Y)
                    Buffer.WriteLong(.PageCount)
                End With
                If Map(MapNum).Events(i).PageCount > 0 Then
                    For x = 1 To Map(MapNum).Events(i).PageCount
                        With Map(MapNum).Events(i).Pages(x)
                            Buffer.WriteLong(.chkVariable)
                            Buffer.WriteLong(.VariableIndex)
                            Buffer.WriteLong(.VariableCondition)
                            Buffer.WriteLong(.VariableCompare)

                            Buffer.WriteLong(.chkSwitch)
                            Buffer.WriteLong(.SwitchIndex)
                            Buffer.WriteLong(.SwitchCompare)

                            Buffer.WriteLong(.chkHasItem)
                            Buffer.WriteLong(.HasItemIndex)
                            Buffer.WriteLong(.HasItemAmount)

                            Buffer.WriteLong(.chkSelfSwitch)
                            Buffer.WriteLong(.SelfSwitchIndex)
                            Buffer.WriteLong(.SelfSwitchCompare)

                            Buffer.WriteLong(.GraphicType)
                            Buffer.WriteLong(.Graphic)
                            Buffer.WriteLong(.GraphicX)
                            Buffer.WriteLong(.GraphicY)
                            Buffer.WriteLong(.GraphicX2)
                            Buffer.WriteLong(.GraphicY2)

                            Buffer.WriteLong(.MoveType)
                            Buffer.WriteLong(.MoveSpeed)
                            Buffer.WriteLong(.MoveFreq)
                            Buffer.WriteLong(.MoveRouteCount)

                            Buffer.WriteLong(.IgnoreMoveRoute)
                            Buffer.WriteLong(.RepeatMoveRoute)

                            If .MoveRouteCount > 0 Then
                                For y = 1 To .MoveRouteCount
                                    Buffer.WriteLong(.MoveRoute(y).Index)
                                    Buffer.WriteLong(.MoveRoute(y).Data1)
                                    Buffer.WriteLong(.MoveRoute(y).Data2)
                                    Buffer.WriteLong(.MoveRoute(y).Data3)
                                    Buffer.WriteLong(.MoveRoute(y).Data4)
                                    Buffer.WriteLong(.MoveRoute(y).Data5)
                                    Buffer.WriteLong(.MoveRoute(y).Data6)
                                Next
                            End If

                            Buffer.WriteLong(.WalkAnim)
                            Buffer.WriteLong(.DirFix)
                            Buffer.WriteLong(.WalkThrough)
                            Buffer.WriteLong(.ShowName)
                            Buffer.WriteLong(.Trigger)
                            Buffer.WriteLong(.CommandListCount)

                            Buffer.WriteLong(.Position)
                            Buffer.WriteLong(.QuestNum)
                        End With

                        If Map(MapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            For y = 1 To Map(MapNum).Events(i).Pages(x).CommandListCount
                                Buffer.WriteLong(Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                Buffer.WriteLong(Map(MapNum).Events(i).Pages(x).CommandList(y).ParentList)
                                If Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    For z = 1 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            Buffer.WriteLong(.Index)
                                            Buffer.WriteString(.Text1)
                                            Buffer.WriteString(.Text2)
                                            Buffer.WriteString(.Text3)
                                            Buffer.WriteString(.Text4)
                                            Buffer.WriteString(.Text5)
                                            Buffer.WriteLong(.Data1)
                                            Buffer.WriteLong(.Data2)
                                            Buffer.WriteLong(.Data3)
                                            Buffer.WriteLong(.Data4)
                                            Buffer.WriteLong(.Data5)
                                            Buffer.WriteLong(.Data6)
                                            Buffer.WriteLong(.ConditionalBranch.CommandList)
                                            Buffer.WriteLong(.ConditionalBranch.Condition)
                                            Buffer.WriteLong(.ConditionalBranch.Data1)
                                            Buffer.WriteLong(.ConditionalBranch.Data2)
                                            Buffer.WriteLong(.ConditionalBranch.Data3)
                                            Buffer.WriteLong(.ConditionalBranch.ElseCommandList)
                                            Buffer.WriteLong(.MoveRouteCount)
                                            If .MoveRouteCount > 0 Then
                                                For w = 1 To .MoveRouteCount
                                                    Buffer.WriteLong(.MoveRoute(w).Index)
                                                    Buffer.WriteLong(.MoveRoute(w).Data1)
                                                    Buffer.WriteLong(.MoveRoute(w).Data2)
                                                    Buffer.WriteLong(.MoveRoute(w).Data3)
                                                    Buffer.WriteLong(.MoveRoute(w).Data4)
                                                    Buffer.WriteLong(.MoveRoute(w).Data5)
                                                    Buffer.WriteLong(.MoveRoute(w).Data6)
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If

        'End Event Data
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
        SendSwitchesAndVariables(Index)

    End Sub
#End Region

#Region "Misc"
    Public Sub GivePlayerEXP(ByVal Index As Long, ByVal Exp As Long)
        ' give the exp

        Call SetPlayerExp(Index, GetPlayerExp(Index) + Exp)
        SendActionMsg(GetPlayerMap(Index), "+" & Exp & " EXP", White, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
        ' check if we've leveled
        CheckPlayerLevelUp(Index)

        SendEXP(Index)
        SendPlayerData(Index)

    End Sub

    Public Sub CustomScript(Index As Long, caseID As Long)

        Select Case caseID
            Case Else
                PlayerMsg(Index, "You just activated custom script " & caseID & ". This script is not yet programmed.")
        End Select

    End Sub
#End Region

End Module
