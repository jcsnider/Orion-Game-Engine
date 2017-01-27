Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Module EditorEventSystem
#Region "Globals"
    ' Temp event storage
    Public tmpEvent As EventRec
    Public isEdit As Boolean

    Public curPageNum As Integer
    Public curCommand As Integer
    Public GraphicSelX As Integer
    Public GraphicSelY As Integer
    Public GraphicSelX2 As Integer
    Public GraphicSelY2 As Integer

    Public EventTileX As Integer
    Public EventTileY As Integer

    Public EditorEvent As Integer

    Public GraphicSelType As Integer 'Are we selecting a graphic for a move route? A page sprite? What???
    Public TempMoveRouteCount As Integer
    Public TempMoveRoute() As MoveRouteRec
    Public IsMoveRouteCommand As Boolean
    Public ListOfEvents() As Integer

    Public EventReplyID As Integer
    Public EventReplyPage As Integer
    Public EventChatFace As Integer

    Public RenameType As Integer
    Public RenameIndex As Integer
    Public EventChatTimer As Integer

    Public EventChat As Boolean
    Public EventText As String
    Public ShowEventLbl As Boolean
    Public EventChoices(0 To 4) As String
    Public EventChoiceVisible(0 To 4) As Boolean
    Public EventChatType As Integer
    Public AnotherChat As Integer 'Determines if another showtext/showchoices is comming up, if so, dont close the event chatbox...

    'constants
    Public Switches(0 To MAX_SWITCHES) As String
    Public Variables(0 To MAX_VARIABLES) As String
    Public Const MAX_SWITCHES As Integer = 1000
    Public Const MAX_VARIABLES As Integer = 1000

    Public cpEvent As EventRec
    Public EventList() As EventListRec

    Public InEvent As Boolean
    Public HoldPlayer As Boolean
    Public InitEventEditorForm As Boolean

#End Region

#Region "Types"
    Public Structure EventCommandRec
        Dim Index As Integer
        Dim Text1 As String
        Dim Text2 As String
        Dim Text3 As String
        Dim Text4 As String
        Dim Text5 As String
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim Data4 As Integer
        Dim Data5 As Integer
        Dim Data6 As Integer
        Dim ConditionalBranch As ConditionalBranchRec
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteRec
    End Structure

    Public Structure MoveRouteRec
        Dim Index As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim Data4 As Integer
        Dim Data5 As Integer
        Dim Data6 As Integer
    End Structure

    Public Structure CommandListRec
        Dim CommandCount As Integer
        Dim ParentList As Integer
        Dim Commands() As EventCommandRec
    End Structure

    Public Structure ConditionalBranchRec
        Dim Condition As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim CommandList As Integer
        Dim ElseCommandList As Integer
    End Structure

    Public Structure EventPageRec
        'These are condition variables that decide if the event even appears to the player.
        Dim chkVariable As Integer
        Dim VariableIndex As Integer
        Dim VariableCondition As Integer
        Dim VariableCompare As Integer
        Dim chkSwitch As Integer
        Dim SwitchIndex As Integer
        Dim SwitchCompare As Integer
        Dim chkHasItem As Integer
        Dim HasItemIndex As Integer
        Dim HasItemAmount As Integer
        Dim chkSelfSwitch As Integer
        Dim SelfSwitchIndex As Integer
        Dim SelfSwitchCompare As Integer
        Dim chkPlayerGender As Integer
        'End Conditions

        'Handles the Event Sprite
        Dim GraphicType As Byte
        Dim Graphic As Integer
        Dim GraphicX As Integer
        Dim GraphicY As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY2 As Integer

        'Handles Movement - Move Routes to come soon.
        Dim MoveType As Byte
        Dim MoveSpeed As Byte
        Dim MoveFreq As Byte
        Dim MoveRouteCount As Integer
        Dim MoveRoute() As MoveRouteRec
        Dim IgnoreMoveRoute As Integer
        Dim RepeatMoveRoute As Integer

        'Guidelines for the event
        Dim WalkAnim As Byte
        Dim DirFix As Byte
        Dim WalkThrough As Byte
        Dim ShowName As Byte

        'Trigger for the event
        Dim Trigger As Byte

        'Commands for the event
        Dim CommandListCount As Integer
        Dim CommandList() As CommandListRec
        Dim Position As Byte
        Dim Questnum As Integer

        'Client Needed Only
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure EventRec
        Dim Name As String
        Dim Globals As Integer
        Dim PageCount As Integer
        Dim Pages() As EventPageRec
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure MapEventRec
        Dim Name As String
        Dim dir As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim GraphicType As Integer
        Dim GraphicX As Integer
        Dim GraphicY As Integer
        Dim GraphicX2 As Integer
        Dim GraphicY2 As Integer
        Dim GraphicNum As Integer
        Dim Moving As Integer
        Dim MovementSpeed As Integer
        Dim Position As Integer
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Steps As Integer
        Dim Visible As Integer
        Dim WalkAnim As Integer
        Dim DirFix As Integer
        Dim ShowDir As Integer
        Dim WalkThrough As Integer
        Dim ShowName As Integer
        Dim questnum As Integer
    End Structure

    Public CopyEvent As EventRec
    Public CopyEventPage As EventPageRec

    Public Structure EventListRec
        Dim CommandList As Integer
        Dim CommandNum As Integer
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

#Region "EventEditor"
    'Event Editor Stuffz Also includes event functions from the map editor (copy/paste/delete)

    Sub CopyEvent_Map(X As Integer, Y As Integer)
        Dim count As Integer, i As Integer

        count = Map.EventCount
        If count = 0 Then Exit Sub
        For i = 1 To count
            If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                ' copy it
                CopyEvent = Map.Events(i)
                ' exit
                Exit Sub
            End If
        Next

    End Sub

    Sub PasteEvent_Map(X As Integer, Y As Integer)
        Dim count As Integer, i As Integer, EventNum As Integer

        count = Map.EventCount
        If count > 0 Then
            For i = 1 To count
                If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                    ' already an event - paste over it
                    EventNum = i
                End If
            Next
        End If

        ' couldn't find one - create one
        If EventNum = 0 Then
            ' increment count
            AddEvent(X, Y, True)
            EventNum = count + 1
        End If

        ' copy it
        Map.Events(EventNum) = CopyEvent
        ' set position
        Map.Events(EventNum).X = X
        Map.Events(EventNum).Y = Y

    End Sub

    Sub DeleteEvent(X As Integer, Y As Integer)
        Dim count As Integer, i As Integer, lowIndex As Integer

        If Not InMapEditor Then Exit Sub
        If frmEditor_Events.Visible = True Then Exit Sub
        count = Map.EventCount
        For i = 1 To count
            If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                ' delete it
                ClearEvent(i)
                lowIndex = i
                Exit For
            End If
        Next
        ' not found anything
        If lowIndex = 0 Then Exit Sub
        ' move everything down an index
        For i = lowIndex To count - 1
            Map.Events(i) = Map.Events(i + 1)
        Next
        ' delete the last index
        ClearEvent(count)
        ' set the new count
        Map.EventCount = count - 1
        Map.CurrentEvents = count - 1

    End Sub

    Sub AddEvent(X As Integer, Y As Integer, Optional ByVal cancelLoad As Boolean = False)
        Dim count As Integer, pageCount As Integer, i As Integer

        count = Map.EventCount + 1
        ' make sure there's not already an event
        If count - 1 > 0 Then
            For i = 1 To count - 1
                If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                    ' already an event - edit it
                    If Not cancelLoad Then EventEditorInit(i)
                    Exit Sub
                End If
            Next
        End If
        ' increment count
        Map.EventCount = count
        ReDim Preserve Map.Events(0 To count)
        ' set the new event
        Map.Events(count).X = X
        Map.Events(count).Y = Y
        ' give it a new page
        pageCount = Map.Events(count).PageCount + 1
        Map.Events(count).PageCount = pageCount
        ReDim Preserve Map.Events(count).Pages(pageCount)
        ' load the editor
        If Not cancelLoad Then EventEditorInit(count)

    End Sub

    Sub ClearEvent(EventNum As Integer)
        If EventNum > Map.EventCount Or EventNum > UBound(Map.MapEvents) Then Exit Sub
        With Map.Events(EventNum)
            .Name = ""
            .PageCount = 0
            ReDim .Pages(0)
            .Globals = 0
            .X = 0
            .Y = 0
        End With
        With Map.MapEvents(EventNum)
            .Name = ""
            .dir = 0
            .ShowDir = 0
            .GraphicNum = 0
            .GraphicType = 0
            .GraphicX = 0
            .GraphicX2 = 0
            .GraphicY = 0
            .GraphicY2 = 0
            .MovementSpeed = 0
            .Moving = 0
            .X = 0
            .Y = 0
            .XOffset = 0
            .YOffset = 0
            .Position = 0
            .Visible = 0
            .WalkAnim = 0
            .DirFix = 0
            .WalkThrough = 0
            .ShowName = 0
            .questnum = 0
        End With

    End Sub

    Sub EventEditorInit(EventNum As Integer)
        'Dim i As Integer

        EditorEvent = EventNum

        tmpEvent = Map.Events(EventNum)
        InitEventEditorForm = True

    End Sub

    Sub EventEditorLoadPage(pageNum As Integer)
        ' populate form

        With tmpEvent.Pages(pageNum)
            GraphicSelX = .GraphicX
            GraphicSelY = .GraphicY
            GraphicSelX2 = .GraphicX2
            GraphicSelY2 = .GraphicY2
            frmEditor_Events.cmbGraphic.SelectedIndex = .GraphicType
            frmEditor_Events.cmbHasItem.SelectedIndex = .HasItemIndex
            If .HasItemAmount = 0 Then
                frmEditor_Events.scrlCondition_HasItem.Value = 1
            Else
                frmEditor_Events.scrlCondition_HasItem.Value = .HasItemAmount
            End If
            frmEditor_Events.cmbMoveFreq.SelectedIndex = .MoveFreq
            frmEditor_Events.cmbMoveSpeed.SelectedIndex = .MoveSpeed
            frmEditor_Events.cmbMoveType.SelectedIndex = .MoveType
            frmEditor_Events.cmbPlayerVar.SelectedIndex = .VariableIndex
            frmEditor_Events.cmbPlayerSwitch.SelectedIndex = .SwitchIndex
            frmEditor_Events.cmbSelfSwitch.SelectedIndex = .SelfSwitchIndex
            frmEditor_Events.cmbSelfSwitchCompare.SelectedIndex = .SelfSwitchCompare
            frmEditor_Events.cmbPlayerSwitchCompare.SelectedIndex = .SwitchCompare
            frmEditor_Events.cmbPlayervarCompare.SelectedIndex = .VariableCompare
            frmEditor_Events.chkGlobal.Checked = tmpEvent.Globals
            frmEditor_Events.cmbTrigger.SelectedIndex = .Trigger
            frmEditor_Events.chkDirFix.Checked = .DirFix
            frmEditor_Events.chkHasItem.Checked = .chkHasItem
            frmEditor_Events.chkPlayerVar.Checked = .chkVariable
            frmEditor_Events.chkPlayerSwitch.Checked = .chkSwitch
            frmEditor_Events.chkSelfSwitch.Checked = .chkSelfSwitch
            frmEditor_Events.chkWalkAnim.Checked = .WalkAnim
            frmEditor_Events.chkWalkThrough.Checked = .WalkThrough
            frmEditor_Events.chkShowName.Checked = .ShowName
            frmEditor_Events.txtPlayerVariable.Text = .VariableCondition
            frmEditor_Events.scrlGraphic.Value = .Graphic
            If frmEditor_Events.cmbEventQuest.Items.Count > 0 Then
                If .Questnum >= 0 And .Questnum <= frmEditor_Events.cmbEventQuest.Items.Count Then
                    frmEditor_Events.cmbEventQuest.SelectedIndex = .Questnum
                End If
            End If
            If frmEditor_Events.cmbEventQuest.SelectedIndex = -1 Then frmEditor_Events.cmbEventQuest.SelectedIndex = 0
            If .chkHasItem = 0 Then
                frmEditor_Events.cmbHasItem.Enabled = False
            Else
                frmEditor_Events.cmbHasItem.Enabled = True
            End If
            If .chkSelfSwitch = 0 Then
                frmEditor_Events.cmbSelfSwitch.Enabled = False
                frmEditor_Events.cmbSelfSwitchCompare.Enabled = False
            Else
                frmEditor_Events.cmbSelfSwitch.Enabled = True
                frmEditor_Events.cmbSelfSwitchCompare.Enabled = True
            End If
            If .chkSwitch = 0 Then
                frmEditor_Events.cmbPlayerSwitch.Enabled = False
                frmEditor_Events.cmbPlayerSwitchCompare.Enabled = False
            Else
                frmEditor_Events.cmbPlayerSwitch.Enabled = True
                frmEditor_Events.cmbPlayerSwitchCompare.Enabled = True
            End If
            If .chkVariable = 0 Then
                frmEditor_Events.cmbPlayerVar.Enabled = False
                frmEditor_Events.txtPlayerVariable.Enabled = False
                frmEditor_Events.cmbPlayervarCompare.Enabled = False
            Else
                frmEditor_Events.cmbPlayerVar.Enabled = True
                frmEditor_Events.txtPlayerVariable.Enabled = True
                frmEditor_Events.cmbPlayervarCompare.Enabled = True
            End If
            If frmEditor_Events.cmbMoveType.SelectedIndex = 2 Then
                frmEditor_Events.btnMoveRoute.Enabled = True
            Else
                frmEditor_Events.btnMoveRoute.Enabled = False
            End If
            frmEditor_Events.cmbPositioning.SelectedIndex = .Position
            ' show the commands
            EventListCommands()

            EditorEvent_DrawGraphic()
        End With

    End Sub

    Sub EventEditorOK()
        ' copy the event data from the temp event

        Map.Events(EditorEvent) = tmpEvent
        ' unload the form
        frmEditor_Events.Dispose()

    End Sub

    Public Sub EventListCommands()
        Dim i As Integer, curlist As Integer, X As Integer, indent As String = "", listleftoff() As Integer, conditionalstage() As Integer

        frmEditor_Events.lstCommands.Items.Clear()

        If tmpEvent.Pages(curPageNum).CommandListCount > 0 Then
            ReDim listleftoff(0 To tmpEvent.Pages(curPageNum).CommandListCount)
            ReDim conditionalstage(0 To tmpEvent.Pages(curPageNum).CommandListCount)
            'Start Up at 1
            curlist = 1
            X = -1
newlist:
            For i = 1 To tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount
                If listleftoff(curlist) > 0 Then
                    If (tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(listleftoff(curlist)).Index = EventType.evCondition Or tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(listleftoff(curlist)).Index = EventType.evShowChoices) And conditionalstage(curlist) <> 0 Then
                        i = listleftoff(curlist)
                    ElseIf listleftoff(curlist) >= i Then
                        i = listleftoff(curlist) + 1
                    End If
                End If
                If i <= tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount Then
                    If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Index = EventType.evCondition Then
                        X = X + 1
                        Select Case conditionalstage(curlist)
                            Case 0
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = i
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Condition
                                    Case 0
                                        Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2
                                            Case 0
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 1
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] >= " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 2
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] <= " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 3
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] > " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 4
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] < " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 5
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] != " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                        End Select
                                    Case 1
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Switch [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Switches(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & "True")
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Switch [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Switches(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & "False")
                                        End If
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Has Item [" & Trim$(Item(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "] x" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2)
                                    Case 3
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Class Is [" & Trim$(Classes(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "]")
                                    Case 4
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Knows Skill [" & Trim$(Skill(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "]")
                                    Case 5
                                        Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2
                                            Case 0
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is == " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 1
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is >= " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 2
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is <= " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 3
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is > " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 4
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is < " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 5
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is NOT " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                        End Select
                                    Case 6
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                                Case 0
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [A] == " & "True")
                                                Case 1
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [B] == " & "True")
                                                Case 2
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [C] == " & "True")
                                                Case 3
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [D] == " & "True")
                                            End Select
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                                Case 0
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [A] == " & "False")
                                                Case 1
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [B] == " & "False")
                                                Case 2
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [C] == " & "False")
                                                Case 3
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [D] == " & "False")
                                            End Select
                                        End If
                                    Case 7
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3
                                                Case 0
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] not started.")
                                                Case 1
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] is started.")
                                                Case 2
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] is completed.")
                                                Case 3
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] can be started.")
                                                Case 4
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] can be ended. (All tasks complete)")
                                            End Select
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] in progress and on task #" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                        End If
                                    Case 8
                                        Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                            Case Sex.Male
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Gender is Male")
                                            Case Sex.Female
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's  Gender is Female")
                                        End Select
                                End Select
                                indent = indent & "       "
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 1
                                curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.CommandList
                                GoTo newlist
                            Case 1
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Else")
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 2
                                curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).ConditionalBranch.ElseCommandList
                                GoTo newlist
                            Case 2
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "End Branch")
                                indent = Mid(indent, 1, Len(indent) - 7)
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 0
                        End Select
                    ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Index = EventType.evShowChoices Then
                        X = X + 1
                        Select Case conditionalstage(curlist)
                            Case 0
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = i
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data5 > 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Choices - Prompt: " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Face: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data5)
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Choices - Prompt: " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - No Face")
                                End If
                                indent = indent & "       "
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 1
                                GoTo newlist
                            Case 1
                                If Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text2) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text2) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 2
                                    curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 2
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 2
                                If Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text3) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text3) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 3
                                    curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 3
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 3
                                If Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text4) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text4) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 4
                                    curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 4
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 4
                                If Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text5) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text5) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 5
                                    curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 5
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 5
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Branch End")
                                indent = Mid(indent, 1, Len(indent) - 7)
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 0
                        End Select
                    Else
                        X = X + 1
                        ReDim Preserve EventList(X)
                        EventList(X).CommandList = curlist
                        EventList(X).CommandNum = i
                        Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Index
                            Case EventType.evAddText
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Add Text - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Color: " & GetColorString(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & " - Chat Type: Player")
                                    Case 1
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Add Text - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Color: " & GetColorString(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & " - Chat Type: Map")
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Add Text - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Color: " & GetColorString(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & " - Chat Type: Global")
                                End Select
                            Case EventType.evShowText
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Text - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - No Face")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Text - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Face: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1)
                                End If
                            Case EventType.evPlayerVar
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "] == " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 1
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "] + " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "] - " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 3
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & Variables(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "] Random Between " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & " and " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4)
                                End Select
                            Case EventType.evPlayerSwitch
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Switch [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & ". " & Switches(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "] == True")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Switch [" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & ". " & Switches(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "] == False")
                                End If
                            Case EventType.evSelfSwitch
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1
                                    Case 0
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [A] to ON")
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [A] to OFF")
                                        End If
                                    Case 1
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [B] to ON")
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [B] to OFF")
                                        End If
                                    Case 2
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [C] to ON")
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [C] to OFF")
                                        End If
                                    Case 3
                                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [D] to ON")
                                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [D] to OFF")
                                        End If
                                End Select
                            Case EventType.evExitProcess
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Exit Event Processing")
                            Case EventType.evChangeItems
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Item Amount of [" & Trim$(Item(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "] to " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3)
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Give Player " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & " " & Trim$(Item(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "(s)")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 2 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Take " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & " " & Trim$(Item(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "(s) from Player.")
                                End If
                            Case EventType.evRestoreHP
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Restore Player HP")
                            Case EventType.evRestoreMP
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Restore Player MP")
                            Case EventType.evLevelUp
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Level Up Player")
                            Case EventType.evChangeLevel
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Level to " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.evChangeSkills
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teach Player Skill [" & Trim$(Skill(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Remove Player Skill [" & Trim$(Skill(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                End If
                            Case EventType.evChangeClass
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Class to " & Trim$(Classes(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.evChangeSprite
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Sprite to " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.evChangeSex
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Sex to Male.")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Sex to Female.")
                                End If
                            Case EventType.evChangePK
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player PK to No.")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player PK to Yes.")
                                End If
                            Case EventType.evWarpPlayer
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 & "," & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & ") while retaining direction.")
                                Else
                                    Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4 - 1
                                        Case Direction.Up
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 & "," & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & ") facing upward.")
                                        Case Direction.Down
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 & "," & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & ") facing downward.")
                                        Case Direction.Left
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 & "," & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & ") facing left.")
                                        Case Direction.Right
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 & "," & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & ") facing right.")
                                    End Select
                                End If
                            Case EventType.evSetMoveRoute
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 <= Map.EventCount Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Move Route for Event #" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Map.Events(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Move Route for COULD NOT FIND EVENT!")
                                End If
                            Case EventType.evPlayAnimation
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Animation " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Player")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Animation " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Event #" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & " [" & Trim$(Map.Events(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3).Name) & "]")
                                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2 = 2 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Animation " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Tile(" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3 & "," & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4 & ")")
                                End If
                            Case EventType.evCustomScript
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Execute Custom Script Case: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.evPlayBGM
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play BGM [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.evFadeoutBGM
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Fadeout BGM")
                            Case EventType.evPlaySound
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Sound [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.evStopSound
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Stop Sound")
                            Case EventType.evOpenBank
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Open Bank")
                            Case EventType.evOpenMail
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Open Mail Box")
                            Case EventType.evOpenShop
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Open Shop [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Shop(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                            Case EventType.evSetAccess
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Access [" & frmEditor_Events.cmbSetAccess.Items(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "]")
                            Case EventType.evGiveExp
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Give Player " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " Experience.")
                            Case EventType.evShowChatBubble
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1
                                    Case TargetType.Player
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On Player")
                                    Case TargetType.Npc
                                        If Map.Npc(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) <= 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On NPC [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & ". ]")
                                        Else
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On NPC [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & ". " & Trim$(Npc(Map.Npc(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2)).Name) & "]")
                                        End If
                                    Case TargetType.Event
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On Event [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & ". " & Trim$(Map.Events(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2).Name) & "]")
                                End Select
                            Case EventType.evLabel
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Label: [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.evGotoLabel
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Jump to Label: [" & Trim$(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.evSpawnNpc
                                If Map.Npc(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) <= 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Spawn NPC: [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & ". " & "]")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Spawn NPC: [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Npc(Map.Npc(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1)).Name) & "]")
                                End If
                            Case EventType.evFadeIn
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Fade In")
                            Case EventType.evFadeOut
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Fade Out")
                            Case EventType.evFlashWhite
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Flash White")
                            Case EventType.evSetFog
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Fog [Fog: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & " Speed: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & " Opacity: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3) & "]")
                            Case EventType.evSetWeather
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1
                                    Case Weather.None
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [None]")
                                    Case Weather.Rain
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Rain - Intensity: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case Weather.Snow
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Snow - Intensity: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case Weather.Sandstorm
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Sand Storm - Intensity: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case Weather.Storm
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Storm - Intensity: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                End Select
                            Case EventType.evSetTint
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Map Tint RGBA [" & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & "," & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & "," & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3) & "," & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4) & "]")
                            Case EventType.evWait
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Wait " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & " Ms")
                            Case EventType.evBeginQuest
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Begin Quest: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Quest(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.evEndQuest
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "End Quest: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Quest(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.evQuestTask
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Complete Quest Task: " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Quest(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & " - Task# " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2)
                            Case EventType.evShowPicture
                                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data3
                                    Case 1
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 + 1) & ": Pic=" & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & " Top Left, X: " & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 + 1) & ": Pic=" & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & " Center Screen, X: " & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 3
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 + 1) & ": Pic=" & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data2) & " On Player, X: " & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data5))
                                End Select
                            Case EventType.evHidePicture
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Hide Picture " & CStr(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 + 1))
                            Case EventType.evWaitMovement
                                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 <= Map.EventCount Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Wait for Event #" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Map.Events(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i).Data1).Name) & "] to complete move route.")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Wait for COULD NOT FIND EVENT to complete move route.")
                                End If
                            Case EventType.evHoldPlayer
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Hold Player [Do not allow player to move.]")
                            Case EventType.evReleasePlayer
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Release Player [Allow player to turn and move again.]")
                            Case Else
                                'Ghost
                                X = X - 1
                                If X = -1 Then
                                    ReDim EventList(0)
                                Else
                                    ReDim Preserve EventList(X)
                                End If
                        End Select
                    End If
                End If
            Next
            If curlist > 1 Then
                X = X + 1
                ReDim Preserve EventList(X)
                EventList(X).CommandList = curlist
                EventList(X).CommandNum = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount + 1
                frmEditor_Events.lstCommands.Items.Add(indent & "@> ")
                curlist = tmpEvent.Pages(curPageNum).CommandList(curlist).ParentList
                GoTo newlist
            End If
        End If
        frmEditor_Events.lstCommands.Items.Add(indent & "@> ")

        Dim z As Integer
        X = 0
        For i = 0 To frmEditor_Events.lstCommands.Items.Count - 1
            'X = frmEditor_Events.TextWidth(frmEditor_Events.lstCommands.Items.Item(i).ToString)
            If X > z Then z = X
        Next

        ScrollCommands(z)

    End Sub

    Public Sub ScrollCommands(size As Integer)

        'Call SendMessage(frmEditor_Events.lstCommands.hwnd, LB_SETHORIZONTALEXTENT, (size) + 6, 0&)

    End Sub

    Sub ListCommandAdd(s As String)

        frmEditor_Events.lstCommands.Items.Add(s)

    End Sub

    Sub AddCommand(Index As Integer)
        Dim curlist As Integer, i As Integer, X As Integer, curslot As Integer, p As Integer, oldCommandList As CommandListRec

        If tmpEvent.Pages(curPageNum).CommandListCount = 0 Then
            tmpEvent.Pages(curPageNum).CommandListCount = 1
            ReDim tmpEvent.Pages(curPageNum).CommandList(1)
        End If

        If frmEditor_Events.lstCommands.SelectedIndex = frmEditor_Events.lstCommands.Items.Count - 1 Then
            curlist = 1
        Else
            curlist = EventList(frmEditor_Events.lstCommands.SelectedIndex).CommandList
        End If
        If tmpEvent.Pages(curPageNum).CommandListCount = 0 Then
            tmpEvent.Pages(curPageNum).CommandListCount = 1
            ReDim tmpEvent.Pages(curPageNum).CommandList(curlist)
        End If
        oldCommandList = tmpEvent.Pages(curPageNum).CommandList(curlist)
        tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount + 1
        p = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount
        If p <= 0 Then
            ReDim tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(0)
        Else
            ReDim tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(0 To p)
            tmpEvent.Pages(curPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
            tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount = p
            For i = 1 To p - 1
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(i) = oldCommandList.Commands(i)
            Next
        End If
        If frmEditor_Events.lstCommands.SelectedIndex = frmEditor_Events.lstCommands.Items.Count - 1 Then
            curslot = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount
        Else
            i = EventList(frmEditor_Events.lstCommands.SelectedIndex).CommandNum
            If i < tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount Then
                For X = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount - 1 To i Step -1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(X + 1) = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(X)
                Next
                curslot = EventList(frmEditor_Events.lstCommands.SelectedIndex).CommandNum
            Else
                curslot = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount
            End If
        End If

        Select Case Index
            Case EventType.evAddText
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtAddText_Text.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
                If frmEditor_Events.optAddText_Player.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optAddText_Map.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optAddText_Global.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
            Case EventType.evCondition
                'This is the part where the whole entire source goes to hell :D
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandListCount = tmpEvent.Pages(curPageNum).CommandListCount + 2
                ReDim Preserve tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandListCount)
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.CommandList = tmpEvent.Pages(curPageNum).CommandListCount - 1
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.ElseCommandList = tmpEvent.Pages(curPageNum).CommandListCount
                tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.CommandList).ParentList = curlist
                tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.ElseCommandList).ParentList = curlist

                If frmEditor_Events.optCondition0.Checked = True Then X = 0
                If frmEditor_Events.optCondition1.Checked = True Then X = 1
                If frmEditor_Events.optCondition2.Checked = True Then X = 2
                If frmEditor_Events.optCondition3.Checked = True Then X = 3
                If frmEditor_Events.optCondition4.Checked = True Then X = 4
                If frmEditor_Events.optCondition5.Checked = True Then X = 5
                If frmEditor_Events.optCondition6.Checked = True Then X = 6
                If frmEditor_Events.optCondition7.Checked = True Then X = 7
                If frmEditor_Events.optCondition7.Checked = True Then X = 8

                Select Case X
                    Case 0 'Player Var
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 0
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex + 1
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = Val(frmEditor_Events.txtCondition_PlayerVarCondition.Text)
                    Case 1 'Player Switch
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 1
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex + 1
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex
                    Case 2 'Has Item
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 2
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_HasItem.SelectedIndex + 1
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = Val(frmEditor_Events.scrlCondition_HasItem.Value)
                    Case 3 'Class Is
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 3
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_ClassIs.SelectedIndex + 1
                    Case 4 'Learnt Skill
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 4
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_LearntSkill.SelectedIndex + 1
                    Case 5 'Level Is
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 5
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = Val(frmEditor_Events.txtCondition_LevelAmount.Text)
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_LevelCompare.SelectedIndex
                    Case 6 'Self Switch
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 6
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex
                    Case 7 'Quest Shiz
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 7
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.scrlCondition_Quest.Value
                        If frmEditor_Events.optCondition_Quest0.Checked Then
                            tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 0
                            tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = frmEditor_Events.cmbCondition_General.SelectedIndex
                        Else
                            tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 1
                            tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = frmEditor_Events.scrlCondition_QuestTask.Value
                        End If
                    Case 8 'Gender
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 8
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_Gender.SelectedIndex
                End Select

            Case EventType.evShowText
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                Dim tmptxt As String = ""
                For i = 0 To UBound(frmEditor_Events.txtShowText.Lines)
                    tmptxt = tmptxt & frmEditor_Events.txtShowText.Lines(i)
                Next
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = tmptxt
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlShowTextFace.Value

            Case EventType.evShowChoices
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChoicePrompt.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text2 = frmEditor_Events.txtChoices1.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text3 = frmEditor_Events.txtChoices2.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text4 = frmEditor_Events.txtChoices3.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text5 = frmEditor_Events.txtChoices4.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data5 = frmEditor_Events.scrlShowChoicesFace.Value
                tmpEvent.Pages(curPageNum).CommandListCount = tmpEvent.Pages(curPageNum).CommandListCount + 4
                ReDim Preserve tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandListCount)
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = tmpEvent.Pages(curPageNum).CommandListCount - 3
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = tmpEvent.Pages(curPageNum).CommandListCount - 2
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = tmpEvent.Pages(curPageNum).CommandListCount - 1
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = tmpEvent.Pages(curPageNum).CommandListCount
                tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandListCount - 3).ParentList = curlist
                tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandListCount - 2).ParentList = curlist
                tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandListCount - 1).ParentList = curlist
                tmpEvent.Pages(curPageNum).CommandList(tmpEvent.Pages(curPageNum).CommandListCount).ParentList = curlist

            Case EventType.evPlayerVar
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbVariable.SelectedIndex + 1

                If frmEditor_Events.optVariableAction0.Checked = True Then i = 0
                If frmEditor_Events.optVariableAction1.Checked = True Then i = 1
                If frmEditor_Events.optVariableAction2.Checked = True Then i = 2
                If frmEditor_Events.optVariableAction3.Checked = True Then i = 3

                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = i
                If i = 3 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData3.Text)
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = Val(frmEditor_Events.txtVariableData4.Text)
                ElseIf i = 0 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData0.Text)
                ElseIf i = 1 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData1.Text)
                ElseIf i = 2 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData2.Text)
                End If

            Case EventType.evPlayerSwitch
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSwitch.SelectedIndex + 1
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbPlayerSwitchSet.SelectedIndex

            Case EventType.evSelfSwitch
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetSelfSwitch.SelectedIndex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex

            Case EventType.evExitProcess
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evChangeItems
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeItemIndex.SelectedIndex + 1
                If frmEditor_Events.optChangeItemSet.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeItemAdd.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optChangeItemRemove.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtChangeItemsAmount.Text)

            Case EventType.evRestoreHP
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evRestoreMP
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evLevelUp
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evChangeLevel
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlChangeLevel.Value

            Case EventType.evChangeSkills
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeSkills.SelectedIndex + 1
                If frmEditor_Events.optChangeSkillsAdd.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeSkillsRemove.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                End If

            Case EventType.evChangeClass
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeClass.SelectedIndex + 1

            Case EventType.evChangeSprite
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlChangeSprite.Value

            Case EventType.evChangeSex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                If frmEditor_Events.optChangeSexMale.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                ElseIf frmEditor_Events.optChangeSexFemale.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                End If

            Case EventType.evChangePK
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                If frmEditor_Events.optChangePKYes.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                ElseIf frmEditor_Events.optChangePKNo.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                End If

            Case EventType.evWarpPlayer
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlWPMap.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlWPX.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.scrlWPY.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.cmbWarpPlayerDir.SelectedIndex

            Case EventType.evSetMoveRoute
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbEvent.SelectedIndex)
                If frmEditor_Events.chkIgnoreMove.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                Else
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                End If

                If frmEditor_Events.chkRepeatRoute.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                Else
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 0
                End If

                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount = TempMoveRouteCount
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).MoveRoute = TempMoveRoute

            Case EventType.evPlayAnimation
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbPlayAnim.SelectedIndex + 1
                If frmEditor_Events.optPlayAnimPlayer.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optPlayAnimEvent.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.cmbPlayAnimEvent.SelectedIndex + 1
                ElseIf frmEditor_Events.optPlayAnimTile.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.scrlPlayAnimTileX.Value
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.scrlPlayAnimTileY.Value
                End If

            Case EventType.evCustomScript
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlCustomScript.Value

            Case EventType.evPlayBGM
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = MusicCache(frmEditor_Events.cmbPlayBGM.SelectedIndex + 1)

            Case EventType.evFadeoutBGM
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evPlaySound
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = SoundCache(frmEditor_Events.cmbPlaySound.SelectedIndex + 1)

            Case EventType.evStopSound
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evOpenBank
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evOpenMail
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evOpenShop
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbOpenShop.SelectedIndex + 1

            Case EventType.evSetAccess
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetAccess.SelectedIndex

            Case EventType.evGiveExp
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlGiveExp.Value

            Case EventType.evShowChatBubble
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChatbubbleText.Text
                If frmEditor_Events.optChatBubbleTarget0.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = TargetType.Player
                ElseIf frmEditor_Events.optChatBubbleTarget1.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = TargetType.Npc
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbChatBubbleTarget.SelectedIndex + 1
                ElseIf frmEditor_Events.optChatBubbleTarget2.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = TargetType.Event
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbChatBubbleTarget.SelectedIndex + 1
                End If

            Case EventType.evLabel
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtLabelName.Text

            Case EventType.evGotoLabel
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtGotoLabel.Text

            Case EventType.evSpawnNpc
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSpawnNPC.SelectedIndex + 1

            Case EventType.evFadeIn
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evFadeOut
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evFlashWhite
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evSetFog
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.ScrlFogData0.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.ScrlFogData1.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.ScrlFogData2.Value

            Case EventType.evSetWeather
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.CmbWeather.SelectedIndex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlWeatherIntensity.Value

            Case EventType.evSetTint
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlMapTintData0.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlMapTintData1.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.scrlMapTintData2.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.scrlMapTintData3.Value

            Case EventType.evWait
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlWaitAmount.Value

            Case EventType.evBeginQuest
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbBeginQuest.SelectedIndex + 1

            Case EventType.evEndQuest
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbEndQuest.SelectedIndex + 1

            Case EventType.evQuestTask
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlCompleteQuestTaskQuest.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlCompleteQuestTask.Value

            Case EventType.evShowPicture
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbPicIndex.SelectedIndex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlShowPicture.Value

                If frmEditor_Events.optPic1.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                ElseIf frmEditor_Events.optPic2.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 2
                Else
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 3
                End If
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = Val(frmEditor_Events.txtPicOffset1.Text)
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data5 = Val(frmEditor_Events.txtPicOffset2.Text)

            Case EventType.evHidePicture
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbHidePic.SelectedIndex

            Case EventType.evWaitMovement
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbMoveWait.SelectedIndex)

            Case EventType.evHoldPlayer
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.evReleasePlayer
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index = Index
        End Select
        EventListCommands()

    End Sub

    Public Sub EditEventCommand()
        Dim i As Integer, X As Integer, curlist As Integer, curslot As Integer

        i = frmEditor_Events.lstCommands.SelectedIndex
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        frmEditor_Events.fraConditionalBranch.Visible = False
        frmEditor_Events.fraDialogue.BringToFront()

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > tmpEvent.Pages(curPageNum).CommandListCount Then Exit Sub
        If curslot > tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount Then Exit Sub
        Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index
            Case EventType.evAddText
                isEdit = True
                frmEditor_Events.txtAddText_Text.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.scrlAddText_Colour.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                    Case 0
                        frmEditor_Events.optAddText_Player.Checked = True
                    Case 1
                        frmEditor_Events.optAddText_Map.Checked = True
                    Case 2
                        frmEditor_Events.optAddText_Global.Checked = True
                End Select
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraAddText.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evCondition
                isEdit = True
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraConditionalBranch.Visible = True
                frmEditor_Events.fraCommands.Visible = False
                frmEditor_Events.ClearConditionFrame()

                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition
                    Case 0
                        frmEditor_Events.optCondition0.Checked = True
                    Case 1
                        frmEditor_Events.optCondition1.Checked = True
                    Case 2
                        frmEditor_Events.optCondition2.Checked = True
                    Case 3
                        frmEditor_Events.optCondition3.Checked = True
                    Case 4
                        frmEditor_Events.optCondition4.Checked = True
                    Case 5
                        frmEditor_Events.optCondition5.Checked = True
                    Case 6
                        frmEditor_Events.optCondition6.Checked = True
                    Case 7
                        frmEditor_Events.optCondition7.Checked = True
                    Case 8
                        frmEditor_Events.optCondition8.Checked = True
                End Select

                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition
                    Case 0
                        frmEditor_Events.cmbCondition_PlayerVarIndex.Enabled = True
                        frmEditor_Events.cmbCondition_PlayerVarCompare.Enabled = True
                        frmEditor_Events.txtCondition_PlayerVarCondition.Enabled = True
                        frmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        frmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                        frmEditor_Events.txtCondition_PlayerVarCondition.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                    Case 1
                        frmEditor_Events.cmbCondition_PlayerSwitch.Enabled = True
                        frmEditor_Events.cmbCondtion_PlayerSwitchCondition.Enabled = True
                        frmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        frmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 2
                        frmEditor_Events.cmbCondition_HasItem.Enabled = True
                        frmEditor_Events.scrlCondition_HasItem.Enabled = True
                        frmEditor_Events.cmbCondition_HasItem.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        frmEditor_Events.scrlCondition_HasItem.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 3
                        frmEditor_Events.cmbCondition_ClassIs.Enabled = True
                        frmEditor_Events.cmbCondition_ClassIs.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                    Case 4
                        frmEditor_Events.cmbCondition_LearntSkill.Enabled = True
                        frmEditor_Events.cmbCondition_LearntSkill.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                    Case 5
                        frmEditor_Events.cmbCondition_LevelCompare.Enabled = True
                        frmEditor_Events.txtCondition_LevelAmount.Enabled = True
                        frmEditor_Events.txtCondition_LevelAmount.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        frmEditor_Events.cmbCondition_LevelCompare.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 6
                        frmEditor_Events.cmbCondition_SelfSwitch.Enabled = True
                        frmEditor_Events.cmbCondition_SelfSwitchCondition.Enabled = True
                        frmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        frmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 7
                        frmEditor_Events.scrlCondition_Quest.Enabled = True
                        frmEditor_Events.scrlCondition_Quest.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        frmEditor_Events.fraConditions_Quest.Visible = True
                        If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 0 Then
                            frmEditor_Events.optCondition_Quest0.Checked = True
                            frmEditor_Events.cmbCondition_General.Enabled = True
                            frmEditor_Events.cmbCondition_General.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                            frmEditor_Events.lblConditionQuest.Text = "Quest: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                        ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 1 Then
                            frmEditor_Events.optCondition_Quest1.Checked = True
                            frmEditor_Events.scrlCondition_QuestTask.Enabled = True
                            frmEditor_Events.scrlCondition_QuestTask.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                            frmEditor_Events.lblCondition_QuestTask.Text = "#" & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                        End If
                    Case 8
                        frmEditor_Events.cmbCondition_Gender.Enabled = True
                        frmEditor_Events.cmbCondition_Gender.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                End Select
            Case EventType.evShowText
                isEdit = True
                frmEditor_Events.txtShowText.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.scrlShowTextFace.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowText.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evShowChoices
                isEdit = True
                frmEditor_Events.txtChoicePrompt.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.txtChoices1.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text2
                frmEditor_Events.txtChoices2.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text3
                frmEditor_Events.txtChoices3.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text4
                frmEditor_Events.txtChoices4.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text5
                frmEditor_Events.scrlShowChoicesFace.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data5
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowChoices.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evPlayerVar
                isEdit = True
                frmEditor_Events.cmbVariable.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                    Case 0
                        frmEditor_Events.optVariableAction0.Checked = True
                        frmEditor_Events.txtVariableData0.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 1
                        frmEditor_Events.optVariableAction1.Checked = True
                        frmEditor_Events.txtVariableData1.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 2
                        frmEditor_Events.optVariableAction2.Checked = True
                        frmEditor_Events.txtVariableData2.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 3
                        frmEditor_Events.optVariableAction3.Checked = True
                        frmEditor_Events.txtVariableData3.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                        frmEditor_Events.txtVariableData4.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4
                End Select
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayerVariable.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evPlayerSwitch
                isEdit = True
                frmEditor_Events.cmbSwitch.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.cmbPlayerSwitchSet.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayerSwitch.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSelfSwitch
                isEdit = True
                frmEditor_Events.cmbSetSelfSwitch.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetSelfSwitch.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangeItems
                isEdit = True
                frmEditor_Events.cmbChangeItemIndex.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    frmEditor_Events.optChangeItemSet.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    frmEditor_Events.optChangeItemAdd.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2 Then
                    frmEditor_Events.optChangeItemRemove.Checked = True
                End If
                frmEditor_Events.txtChangeItemsAmount.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeItems.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangeLevel
                isEdit = True
                frmEditor_Events.scrlChangeLevel.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeLevel.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangeSkills
                isEdit = True
                frmEditor_Events.cmbChangeSkills.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    frmEditor_Events.optChangeSkillsAdd.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    frmEditor_Events.optChangeSkillsRemove.Checked = True
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeSkills.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangeClass
                isEdit = True
                frmEditor_Events.cmbChangeClass.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeClass.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangeSprite
                isEdit = True
                frmEditor_Events.scrlChangeSprite.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeSprite.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangeSex
                isEdit = True
                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 0 Then
                    frmEditor_Events.optChangeSexMale.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 1 Then
                    frmEditor_Events.optChangeSexFemale.Checked = True
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeGender.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evChangePK
                isEdit = True
                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 1 Then
                    frmEditor_Events.optChangePKYes.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 0 Then
                    frmEditor_Events.optChangePKNo.Checked = True
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangePK.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evWarpPlayer
                isEdit = True
                frmEditor_Events.scrlWPMap.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.scrlWPX.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.scrlWPY.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.cmbWarpPlayerDir.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayerWarp.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSetMoveRoute
                isEdit = True
                frmEditor_Events.pnlMoveRoute.Visible = True
                frmEditor_Events.pnlMoveRoute.BringToFront()
                frmEditor_Events.lstMoveRoute.Items.Clear()
                frmEditor_Events.cmbEvent.Items.Clear()
                ReDim ListOfEvents(0 To Map.EventCount)
                ListOfEvents(0) = EditorEvent
                frmEditor_Events.cmbEvent.Items.Add("This Event")
                frmEditor_Events.cmbEvent.SelectedIndex = 0
                frmEditor_Events.cmbEvent.Enabled = True
                For i = 1 To Map.EventCount
                    If i <> EditorEvent Then
                        frmEditor_Events.cmbEvent.Items.Add(Trim$(Map.Events(i).Name))
                        X = X + 1
                        ListOfEvents(X) = i
                        If i = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 Then frmEditor_Events.cmbEvent.SelectedIndex = X
                    End If
                Next

                IsMoveRouteCommand = True
                frmEditor_Events.chkIgnoreMove.Checked = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.chkRepeatRoute.Checked = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                TempMoveRouteCount = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount
                TempMoveRoute = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).MoveRoute
                For i = 1 To TempMoveRouteCount
                    Select Case TempMoveRoute(i).Index
                        Case 1
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Up")
                        Case 2
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Down")
                        Case 3
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Left")
                        Case 4
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Right")
                        Case 5
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Randomly")
                        Case 6
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Towards Player")
                        Case 7
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Away From Player")
                        Case 8
                            frmEditor_Events.lstMoveRoute.Items.Add("Step Forward")
                        Case 9
                            frmEditor_Events.lstMoveRoute.Items.Add("Step Back")
                        Case 10
                            frmEditor_Events.lstMoveRoute.Items.Add("Wait 100ms")
                        Case 11
                            frmEditor_Events.lstMoveRoute.Items.Add("Wait 500ms")
                        Case 12
                            frmEditor_Events.lstMoveRoute.Items.Add("Wait 1000ms")
                        Case 13
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Up")
                        Case 14
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Down")
                        Case 15
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Left")
                        Case 16
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Right")
                        Case 17
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn 90 Degrees To the Right")
                        Case 18
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn 90 Degrees To the Left")
                        Case 19
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Around 180 Degrees")
                        Case 20
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Randomly")
                        Case 21
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Towards Player")
                        Case 22
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Away from Player")
                        Case 23
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 8x Slower")
                        Case 24
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 4x Slower")
                        Case 25
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 2x Slower")
                        Case 26
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed to Normal")
                        Case 27
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 2x Faster")
                        Case 28
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 4x Faster")
                        Case 29
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Lowest")
                        Case 30
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Lower")
                        Case 31
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Normal")
                        Case 32
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Higher")
                        Case 33
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Highest")
                        Case 34
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn On Walking Animation")
                        Case 35
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Off Walking Animation")
                        Case 36
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn On Fixed Direction")
                        Case 37
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Off Fixed Direction")
                        Case 38
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn On Walk Through")
                        Case 39
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Off Walk Through")
                        Case 40
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Position Below Player")
                        Case 41
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Position at Player Level")
                        Case 42
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Position Above Player")
                        Case 43
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Graphic")
                    End Select
                Next
                frmEditor_Events.fraMoveRoute.Width = 841
                frmEditor_Events.fraMoveRoute.Height = 636
                frmEditor_Events.fraMoveRoute.Visible = True
                frmEditor_Events.fraDialogue.Visible = False
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evPlayAnimation
                isEdit = True
                frmEditor_Events.lblPlayAnimX.Visible = False
                frmEditor_Events.lblPlayAnimY.Visible = False
                frmEditor_Events.scrlPlayAnimTileX.Visible = False
                frmEditor_Events.scrlPlayAnimTileY.Visible = False
                frmEditor_Events.cmbPlayAnimEvent.Visible = False
                frmEditor_Events.cmbPlayAnim.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.cmbPlayAnimEvent.Items.Clear()
                For i = 1 To Map.EventCount
                    frmEditor_Events.cmbPlayAnimEvent.Items.Add(i & ". " & Trim$(Map.Events(i).Name))
                Next
                frmEditor_Events.cmbPlayAnimEvent.SelectedIndex = 0
                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    frmEditor_Events.optPlayAnimPlayer.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    frmEditor_Events.optPlayAnimEvent.Checked = True
                    frmEditor_Events.cmbPlayAnimEvent.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 - 1
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2 Then
                    frmEditor_Events.optPlayAnimTile.Checked = True
                    frmEditor_Events.scrlPlayAnimTileX.Maximum = Map.MaxX
                    frmEditor_Events.scrlPlayAnimTileY.Maximum = Map.MaxY
                    frmEditor_Events.scrlPlayAnimTileX.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                    frmEditor_Events.scrlPlayAnimTileY.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayAnimation.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evCustomScript
                isEdit = True
                frmEditor_Events.scrlCustomScript.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraCustomScript.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evPlayBGM
                isEdit = True
                For i = 1 To UBound(MusicCache)
                    If MusicCache(i) = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 Then
                        frmEditor_Events.cmbPlayBGM.SelectedIndex = i - 1
                    End If
                Next
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayBGM.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evPlaySound
                isEdit = True
                For i = 1 To UBound(SoundCache)
                    If SoundCache(i) = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 Then
                        frmEditor_Events.cmbPlaySound.SelectedIndex = i - 1
                    End If
                Next
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlaySound.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evOpenShop
                isEdit = True
                frmEditor_Events.cmbOpenShop.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraOpenShop.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSetAccess
                isEdit = True
                frmEditor_Events.cmbSetAccess.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetAccess.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evGiveExp
                isEdit = True
                frmEditor_Events.scrlGiveExp.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.lblGiveExp.Text = "Give Exp: " & tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraGiveExp.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evShowChatBubble
                isEdit = True
                frmEditor_Events.txtChatbubbleText.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1
                Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                    Case TargetType.Player
                        frmEditor_Events.optChatBubbleTarget0.Checked = True
                    Case TargetType.Npc
                        frmEditor_Events.optChatBubbleTarget1.Checked = True
                    Case TargetType.Event
                        frmEditor_Events.optChatBubbleTarget2.Checked = True
                End Select
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowChatBubble.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evLabel
                isEdit = True
                frmEditor_Events.txtLabelName.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraCreateLabel.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evGotoLabel
                isEdit = True
                frmEditor_Events.txtGotoLabel.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraGoToLabel.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSpawnNpc
                isEdit = True
                frmEditor_Events.cmbSpawnNPC.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSpawnNpc.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSetFog
                isEdit = True
                frmEditor_Events.ScrlFogData0.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.ScrlFogData1.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.ScrlFogData2.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetFog.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSetWeather
                isEdit = True
                frmEditor_Events.CmbWeather.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.scrlWeatherIntensity.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetWeather.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evSetTint
                isEdit = True
                frmEditor_Events.scrlMapTintData0.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.scrlMapTintData1.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.scrlMapTintData2.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.scrlMapTintData3.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraMapTint.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evWait
                isEdit = True
                frmEditor_Events.scrlWaitAmount.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetWait.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evBeginQuest
                isEdit = True
                frmEditor_Events.cmbBeginQuest.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraBeginQuest.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evEndQuest
                isEdit = True
                frmEditor_Events.cmbEndQuest.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraEndQuest.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evQuestTask
                isEdit = True
                frmEditor_Events.scrlCompleteQuestTaskQuest.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.scrlCompleteQuestTask.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraCompleteTask.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evShowPicture
                isEdit = True
                frmEditor_Events.cmbPicIndex.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.scrlShowPicture.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2
                If tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 1 Then
                    frmEditor_Events.optPic1.Checked = True
                ElseIf tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 2 Then
                    frmEditor_Events.optPic2.Checked = True
                Else
                    frmEditor_Events.optPic3.Checked = True
                End If
                frmEditor_Events.txtPicOffset1.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4
                frmEditor_Events.txtPicOffset2.Text = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data5
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowPic.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evHidePicture
                isEdit = True
                frmEditor_Events.cmbHidePic.SelectedIndex = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraHidePic.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.evWaitMovement
                isEdit = True
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraMoveRouteWait.Visible = True
                frmEditor_Events.fraCommands.Visible = False
                frmEditor_Events.cmbMoveWait.Items.Clear()
                ReDim ListOfEvents(0 To Map.EventCount)
                ListOfEvents(0) = EditorEvent
                frmEditor_Events.cmbMoveWait.Items.Add("This Event")
                frmEditor_Events.cmbMoveWait.SelectedIndex = 0
                For i = 1 To Map.EventCount
                    If i <> EditorEvent Then
                        frmEditor_Events.cmbMoveWait.Items.Add(Trim$(Map.Events(i).Name))
                        X = X + 1
                        ListOfEvents(X) = i
                        If i = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 Then frmEditor_Events.cmbMoveWait.SelectedIndex = X
                    End If
                Next
        End Select

    End Sub

    Public Sub DeleteEventCommand()
        Dim i As Integer, X As Integer, curlist As Integer, curslot As Integer, p As Integer, oldCommandList As CommandListRec

        i = frmEditor_Events.lstCommands.SelectedIndex
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub
        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > tmpEvent.Pages(curPageNum).CommandListCount Then Exit Sub
        If curslot > tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount Then Exit Sub
        If curslot = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount Then
            tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount - 1
            p = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount
            If p <= 0 Then
                ReDim tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(0)
            Else
                oldCommandList = tmpEvent.Pages(curPageNum).CommandList(curlist)
                ReDim tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(p)
                X = 1
                tmpEvent.Pages(curPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
                tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount = p
                For i = 1 To p + 1
                    If i <> curslot Then
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(X) = oldCommandList.Commands(i)
                        X = X + 1
                    End If
                Next
            End If
        Else
            tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount - 1
            p = tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount
            oldCommandList = tmpEvent.Pages(curPageNum).CommandList(curlist)
            X = 1
            If p <= 0 Then
                ReDim tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(0)
            Else
                ReDim tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(p)
                tmpEvent.Pages(curPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
                tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount = p
                For i = 1 To p + 1
                    If i <> curslot Then
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(X) = oldCommandList.Commands(i)
                        X = X + 1
                    End If
                Next
            End If
        End If
        EventListCommands()

    End Sub

    Public Sub ClearEventCommands()

        ReDim tmpEvent.Pages(curPageNum).CommandList(1)
        tmpEvent.Pages(curPageNum).CommandListCount = 1
        EventListCommands()

    End Sub

    Public Sub EditCommand()
        Dim i As Integer, curlist As Integer, curslot As Integer

        i = frmEditor_Events.lstCommands.SelectedIndex
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > tmpEvent.Pages(curPageNum).CommandListCount Then Exit Sub
        If curslot > tmpEvent.Pages(curPageNum).CommandList(curlist).CommandCount Then Exit Sub
        Select Case tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Index
            Case EventType.evAddText
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtAddText_Text.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
                If frmEditor_Events.optAddText_Player.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optAddText_Map.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optAddText_Global.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
            Case EventType.evCondition
                If frmEditor_Events.optCondition0.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 0
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex + 1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = Val(frmEditor_Events.txtCondition_PlayerVarCondition.Text)
                ElseIf frmEditor_Events.optCondition1.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex + 1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex
                ElseIf frmEditor_Events.optCondition2.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 2
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_HasItem.SelectedIndex + 1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = Val(frmEditor_Events.scrlCondition_HasItem.Value)
                ElseIf frmEditor_Events.optCondition3.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 3
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_ClassIs.SelectedIndex + 1
                ElseIf frmEditor_Events.optCondition4.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 4
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_LearntSkill.SelectedIndex + 1
                ElseIf frmEditor_Events.optCondition5.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 5
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = Val(frmEditor_Events.txtCondition_LevelAmount.Text)
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_LevelCompare.SelectedIndex
                ElseIf frmEditor_Events.optCondition6.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 6
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex
                ElseIf frmEditor_Events.optCondition7.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 7
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.scrlCondition_Quest.Value
                    If frmEditor_Events.optCondition_Quest0.Checked Then
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 0
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = frmEditor_Events.cmbCondition_General.SelectedIndex
                    Else
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = 1
                        tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = frmEditor_Events.scrlCondition_QuestTask.Value
                    End If
                ElseIf frmEditor_Events.optCondition8.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 8
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_Gender.SelectedIndex
                End If
            Case EventType.evShowText
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtShowText.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlShowTextFace.Value
            Case EventType.evShowChoices
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChoicePrompt.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text2 = frmEditor_Events.txtChoices1.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text3 = frmEditor_Events.txtChoices2.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text4 = frmEditor_Events.txtChoices3.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text5 = frmEditor_Events.txtChoices4.Text
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data5 = frmEditor_Events.scrlShowChoicesFace.Value
            Case EventType.evPlayerVar
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbVariable.SelectedIndex + 1
                If frmEditor_Events.optVariableAction0.Checked = True Then i = 0
                If frmEditor_Events.optVariableAction1.Checked = True Then i = 1
                If frmEditor_Events.optVariableAction2.Checked = True Then i = 2
                If frmEditor_Events.optVariableAction3.Checked = True Then i = 3
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = i
                If i = 0 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData0.Text)
                ElseIf i = 1 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData1.Text)
                ElseIf i = 2 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData2.Text)
                ElseIf i = 3 Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtVariableData3.Text)
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = Val(frmEditor_Events.txtVariableData4.Text)
                End If
            Case EventType.evPlayerSwitch
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSwitch.SelectedIndex + 1
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbPlayerSwitchSet.SelectedIndex
            Case EventType.evSelfSwitch
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetSelfSwitch.SelectedIndex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex
            Case EventType.evChangeItems
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeItemIndex.SelectedIndex + 1
                If frmEditor_Events.optChangeItemSet.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeItemAdd.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optChangeItemRemove.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = Val(frmEditor_Events.txtChangeItemsAmount.Text)
            Case EventType.evChangeLevel
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlChangeLevel.Value
            Case EventType.evChangeSkills
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeSkills.SelectedIndex + 1
                If frmEditor_Events.optChangeSkillsAdd.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeSkillsRemove.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                End If
            Case EventType.evChangeClass
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeClass.SelectedIndex + 1
            Case EventType.evChangeSprite
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlChangeSprite.Value
            Case EventType.evChangeSex
                If frmEditor_Events.optChangeSexMale.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                ElseIf frmEditor_Events.optChangeSexFemale.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                End If
            Case EventType.evChangePK
                If frmEditor_Events.optChangePKYes.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                ElseIf frmEditor_Events.optChangePKNo.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                End If
            Case EventType.evWarpPlayer
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlWPMap.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlWPX.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.scrlWPY.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.cmbWarpPlayerDir.SelectedIndex
            Case EventType.evSetMoveRoute
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbEvent.SelectedIndex)
                If frmEditor_Events.chkIgnoreMove.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                Else
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                End If

                If frmEditor_Events.chkRepeatRoute.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                Else
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 0
                End If
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount = TempMoveRouteCount
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).MoveRoute = TempMoveRoute
            Case EventType.evPlayAnimation
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbPlayAnim.SelectedIndex + 1
                If frmEditor_Events.optPlayAnimPlayer.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optPlayAnimEvent.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.cmbPlayAnimEvent.SelectedIndex + 1
                ElseIf frmEditor_Events.optPlayAnimTile.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.scrlPlayAnimTileX.Value
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.scrlPlayAnimTileY.Value
                End If
            Case EventType.evCustomScript
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlCustomScript.Value
            Case EventType.evPlayBGM
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = MusicCache(frmEditor_Events.cmbPlayBGM.SelectedIndex + 1)
            Case EventType.evPlaySound
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = SoundCache(frmEditor_Events.cmbPlaySound.SelectedIndex + 1)
            Case EventType.evOpenShop
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbOpenShop.SelectedIndex + 1
            Case EventType.evSetAccess
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetAccess.SelectedIndex
            Case EventType.evGiveExp
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlGiveExp.Value
            Case EventType.evShowChatBubble
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChatbubbleText.Text
                If frmEditor_Events.optChatBubbleTarget0.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = TargetType.Player
                ElseIf frmEditor_Events.optChatBubbleTarget1.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = TargetType.Npc
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbChatBubbleTarget.SelectedIndex + 1
                ElseIf frmEditor_Events.optChatBubbleTarget2.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = TargetType.Event
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbChatBubbleTarget.SelectedIndex + 1
                End If
            Case EventType.evLabel
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtLabelName.Text
            Case EventType.evGotoLabel
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtGotoLabel.Text
            Case EventType.evSpawnNpc
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSpawnNPC.SelectedIndex + 1
            Case EventType.evSetFog
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.ScrlFogData0.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.ScrlFogData1.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.ScrlFogData2.Value
            Case EventType.evSetWeather
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.CmbWeather.SelectedIndex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlWeatherIntensity.Value
            Case EventType.evSetTint
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlMapTintData0.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlMapTintData1.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.scrlMapTintData2.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.scrlMapTintData3.Value
            Case EventType.evWait
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlWaitAmount.Value
            Case EventType.evBeginQuest
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbBeginQuest.SelectedIndex + 1
            Case EventType.evEndQuest
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbEndQuest.SelectedIndex + 1
            Case EventType.evQuestTask
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlCompleteQuestTaskQuest.Value
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlCompleteQuestTask.Value
            Case EventType.evShowPicture
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbPicIndex.SelectedIndex
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.scrlShowPicture.Value
                If frmEditor_Events.optPic1.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                ElseIf frmEditor_Events.optPic2.Checked = True Then
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 2
                Else
                    tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data3 = 3
                End If
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data4 = Val(frmEditor_Events.txtPicOffset1.Text)
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data5 = Val(frmEditor_Events.txtPicOffset2.Text)
            Case EventType.evHidePicture
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbHidePic.SelectedIndex
            Case EventType.evWaitMovement
                tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbMoveWait.SelectedIndex)
        End Select
        EventListCommands()

    End Sub

    Sub RequestSwitchesAndVariables()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CRequestSwitchesAndVariables)
        SendData(Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Sub SendSwitchesAndVariables()
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CSwitchesAndVariables)
        For i = 1 To MAX_SWITCHES
            Buffer.WriteString(Trim$(Switches(i)))
        Next
        For i = 1 To MAX_VARIABLES
            Buffer.WriteString(Trim$(Variables(i)))
        Next
        SendData(Buffer.ToArray)

        Buffer = Nothing
    End Sub

#End Region

#Region "Incoming Packets"
    Sub Packet_SpawnEvent(ByVal data() As Byte)
        Dim id As Integer
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SSpawnEvent Then Exit Sub

        id = buffer.ReadInteger
        If id > Map.CurrentEvents Then
            Map.CurrentEvents = id
            ReDim Preserve Map.MapEvents(Map.CurrentEvents)
        End If

        With Map.MapEvents(id)
            .Name = buffer.ReadString
            .dir = buffer.ReadInteger
            .ShowDir = .dir
            .GraphicNum = buffer.ReadInteger
            .GraphicType = buffer.ReadInteger
            .GraphicX = buffer.ReadInteger
            .GraphicX2 = buffer.ReadInteger
            .GraphicY = buffer.ReadInteger
            .GraphicY2 = buffer.ReadInteger
            .MovementSpeed = buffer.ReadInteger
            .Moving = 0
            .X = buffer.ReadInteger
            .Y = buffer.ReadInteger
            .XOffset = 0
            .YOffset = 0
            .Position = buffer.ReadInteger
            .Visible = buffer.ReadInteger
            .WalkAnim = buffer.ReadInteger
            .DirFix = buffer.ReadInteger
            .WalkThrough = buffer.ReadInteger
            .ShowName = buffer.ReadInteger
            .questnum = buffer.ReadInteger
        End With
        buffer = Nothing

    End Sub

    Sub Packet_EventMove(ByVal data() As Byte)
        Dim id As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim dir As Integer, ShowDir As Integer
        Dim MovementSpeed As Integer
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SEventMove Then Exit Sub

        id = buffer.ReadInteger
        X = buffer.ReadInteger
        Y = buffer.ReadInteger
        dir = buffer.ReadInteger
        ShowDir = buffer.ReadInteger
        MovementSpeed = buffer.ReadInteger
        If id > Map.CurrentEvents Then Exit Sub

        With Map.MapEvents(id)
            .X = X
            .Y = Y
            .dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 1
            .ShowDir = ShowDir
            .MovementSpeed = MovementSpeed

            Select Case dir
                Case Direction.Up
                    .YOffset = PIC_Y
                Case Direction.Down
                    .YOffset = PIC_Y * -1
                Case Direction.Left
                    .XOffset = PIC_X
                Case Direction.Right
                    .XOffset = PIC_X * -1
            End Select

        End With

    End Sub

    Sub Packet_EventDir(ByVal data() As Byte)
        Dim i As Integer
        Dim dir As Byte
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SEventDir Then Exit Sub

        i = buffer.ReadInteger
        dir = buffer.ReadInteger
        If i > Map.CurrentEvents Then Exit Sub

        With Map.MapEvents(i)
            .dir = dir
            .ShowDir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

    End Sub

    Sub Packet_SwitchesAndVariables(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim i As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SSwitchesAndVariables Then Exit Sub

        For i = 1 To MAX_SWITCHES
            Switches(i) = buffer.ReadString
        Next
        For i = 1 To MAX_VARIABLES
            Variables(i) = buffer.ReadString
        Next

        buffer = Nothing

    End Sub

    Sub Packet_MapEventData(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim i As Integer, X As Integer, Y As Integer, z As Integer, w As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SMapEventData Then Exit Sub

        'Event Data!
        Map.EventCount = buffer.ReadInteger
        If Map.EventCount > 0 Then
            ReDim Map.Events(0 To Map.EventCount)
            For i = 1 To Map.EventCount
                With Map.Events(i)
                    .Name = buffer.ReadString
                    .Globals = buffer.ReadInteger
                    .X = buffer.ReadInteger
                    .Y = buffer.ReadInteger
                    .PageCount = buffer.ReadInteger
                End With
                If Map.Events(i).PageCount > 0 Then
                    ReDim Map.Events(i).Pages(0 To Map.Events(i).PageCount)
                    For X = 1 To Map.Events(i).PageCount
                        With Map.Events(i).Pages(X)
                            .chkVariable = buffer.ReadInteger
                            .VariableIndex = buffer.ReadInteger
                            .VariableCondition = buffer.ReadInteger
                            .VariableCompare = buffer.ReadInteger
                            .chkSwitch = buffer.ReadInteger
                            .SwitchIndex = buffer.ReadInteger
                            .SwitchCompare = buffer.ReadInteger
                            .chkHasItem = buffer.ReadInteger
                            .HasItemIndex = buffer.ReadInteger
                            .HasItemAmount = buffer.ReadInteger
                            .chkSelfSwitch = buffer.ReadInteger
                            .SelfSwitchIndex = buffer.ReadInteger
                            .SelfSwitchCompare = buffer.ReadInteger
                            .GraphicType = buffer.ReadInteger
                            .Graphic = buffer.ReadInteger
                            .GraphicX = buffer.ReadInteger
                            .GraphicY = buffer.ReadInteger
                            .GraphicX2 = buffer.ReadInteger
                            .GraphicY2 = buffer.ReadInteger
                            .MoveType = buffer.ReadInteger
                            .MoveSpeed = buffer.ReadInteger
                            .MoveFreq = buffer.ReadInteger
                            .MoveRouteCount = buffer.ReadInteger
                            .IgnoreMoveRoute = buffer.ReadInteger
                            .RepeatMoveRoute = buffer.ReadInteger
                            If .MoveRouteCount > 0 Then
                                ReDim Map.Events(i).Pages(X).MoveRoute(0 To .MoveRouteCount)
                                For Y = 1 To .MoveRouteCount
                                    .MoveRoute(Y).Index = buffer.ReadInteger
                                    .MoveRoute(Y).Data1 = buffer.ReadInteger
                                    .MoveRoute(Y).Data2 = buffer.ReadInteger
                                    .MoveRoute(Y).Data3 = buffer.ReadInteger
                                    .MoveRoute(Y).Data4 = buffer.ReadInteger
                                    .MoveRoute(Y).Data5 = buffer.ReadInteger
                                    .MoveRoute(Y).Data6 = buffer.ReadInteger
                                Next
                            End If
                            .WalkAnim = buffer.ReadInteger
                            .DirFix = buffer.ReadInteger
                            .WalkThrough = buffer.ReadInteger
                            .ShowName = buffer.ReadInteger
                            .Trigger = buffer.ReadInteger
                            .CommandListCount = buffer.ReadInteger
                            .Position = buffer.ReadInteger
                            .Questnum = buffer.ReadInteger
                        End With
                        If Map.Events(i).Pages(X).CommandListCount > 0 Then
                            ReDim Map.Events(i).Pages(X).CommandList(0 To Map.Events(i).Pages(X).CommandListCount)
                            For Y = 1 To Map.Events(i).Pages(X).CommandListCount
                                Map.Events(i).Pages(X).CommandList(Y).CommandCount = buffer.ReadInteger
                                Map.Events(i).Pages(X).CommandList(Y).ParentList = buffer.ReadInteger
                                If Map.Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                    ReDim Map.Events(i).Pages(X).CommandList(Y).Commands(0 To Map.Events(i).Pages(X).CommandList(Y).CommandCount)
                                    For z = 1 To Map.Events(i).Pages(X).CommandList(Y).CommandCount
                                        With Map.Events(i).Pages(X).CommandList(Y).Commands(z)
                                            .Index = buffer.ReadInteger
                                            .Text1 = buffer.ReadString
                                            .Text2 = buffer.ReadString
                                            .Text3 = buffer.ReadString
                                            .Text4 = buffer.ReadString
                                            .Text5 = buffer.ReadString
                                            .Data1 = buffer.ReadInteger
                                            .Data2 = buffer.ReadInteger
                                            .Data3 = buffer.ReadInteger
                                            .Data4 = buffer.ReadInteger
                                            .Data5 = buffer.ReadInteger
                                            .Data6 = buffer.ReadInteger
                                            .ConditionalBranch.CommandList = buffer.ReadInteger
                                            .ConditionalBranch.Condition = buffer.ReadInteger
                                            .ConditionalBranch.Data1 = buffer.ReadInteger
                                            .ConditionalBranch.Data2 = buffer.ReadInteger
                                            .ConditionalBranch.Data3 = buffer.ReadInteger
                                            .ConditionalBranch.ElseCommandList = buffer.ReadInteger
                                            .MoveRouteCount = buffer.ReadInteger
                                            If .MoveRouteCount > 0 Then
                                                ReDim Preserve .MoveRoute(.MoveRouteCount)
                                                For w = 1 To .MoveRouteCount
                                                    .MoveRoute(w).Index = buffer.ReadInteger
                                                    .MoveRoute(w).Data1 = buffer.ReadInteger
                                                    .MoveRoute(w).Data2 = buffer.ReadInteger
                                                    .MoveRoute(w).Data3 = buffer.ReadInteger
                                                    .MoveRoute(w).Data4 = buffer.ReadInteger
                                                    .MoveRoute(w).Data5 = buffer.ReadInteger
                                                    .MoveRoute(w).Data6 = buffer.ReadInteger
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
        buffer = Nothing

    End Sub

    Sub Packet_EventChat(ByVal data() As Byte)
        Dim i As Integer
        Dim buffer As ByteBuffer
        Dim choices As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SEventChat Then Exit Sub

        EventReplyID = buffer.ReadInteger
        EventReplyPage = buffer.ReadInteger
        EventChatFace = buffer.ReadInteger
        EventText = buffer.ReadString
        If EventText = "" Then EventText = " "
        EventChat = True
        ShowEventLbl = True
        choices = buffer.ReadInteger
        InEvent = True
        For i = 1 To 4
            EventChoices(i) = ""
            EventChoiceVisible(i) = False
        Next
        EventChatType = 0
        If choices = 0 Then
        Else
            EventChatType = 1
            For i = 1 To choices
                EventChoices(i) = buffer.ReadString
                EventChoiceVisible(i) = True
            Next
        End If
        AnotherChat = buffer.ReadInteger

        buffer = Nothing

    End Sub

    Sub Packet_EventStart(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SEventStart Then Exit Sub

        InEvent = True

        buffer = Nothing
    End Sub

    Sub Packet_EventEnd(ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SEventEnd Then Exit Sub

        InEvent = False

        buffer = Nothing
    End Sub

    Sub Packet_HoldPlayer(ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SHoldPlayer Then Exit Sub

        If buffer.ReadInteger = 0 Then
            HoldPlayer = True
        Else
            HoldPlayer = False
        End If

        buffer = Nothing

    End Sub

#End Region

#Region "Drawing..."
    Public Sub EditorEvent_DrawGraphic()
        Dim sRect As RECT
        Dim dRect As RECT
        Dim targetBitmap As Bitmap 'Bitmap we draw to
        Dim sourceBitmap As Bitmap 'This is our sprite or tileset that we are drawing from
        Dim g As Graphics 'This is our graphics class that helps us draw to the targetBitmap

        If frmEditor_Events.picGraphicSel.Visible Then
            Select Case frmEditor_Events.cmbGraphic.SelectedIndex
                Case 0
                    'None
                    frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                Case 1
                    If frmEditor_Events.scrlGraphic.Value > 0 And frmEditor_Events.scrlGraphic.Value <= NumCharacters Then
                        'Load character from Contents into our sourceBitmap
                        sourceBitmap = New Bitmap(Application.StartupPath & "/Data Files/graphics/characters/" & frmEditor_Events.scrlGraphic.Value & ".png")
                        targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                        g = Graphics.FromImage(targetBitmap)

                        Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height)  'This is the section we are pulling from the source graphic
                        Dim destRect As New Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height)     'This is the rectangle in the target graphic we want to render to

                        g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                        g.DrawRectangle(Pens.Red, New Rectangle(GraphicSelX * PIC_X, GraphicSelY * PIC_Y, GraphicSelX2 * PIC_X, GraphicSelY2 * PIC_Y))

                        g.Dispose()

                        frmEditor_Events.picGraphicSel.Width = targetBitmap.Width
                        frmEditor_Events.picGraphicSel.Height = targetBitmap.Height
                        frmEditor_Events.picGraphicSel.Visible = True
                        frmEditor_Events.picGraphicSel.BackgroundImage = targetBitmap
                        frmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                    Else
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                        Exit Sub
                    End If
                Case 2
                    If frmEditor_Events.scrlGraphic.Value > 0 And frmEditor_Events.scrlGraphic.Value <= NumTileSets Then
                        'Load tilesheet from Contents into our sourceBitmap
                        sourceBitmap = New Bitmap(Application.StartupPath & "/Data Files/graphics/tilesets/" & frmEditor_Events.scrlGraphic.Value & ".png")
                        targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                        If tmpEvent.Pages(curPageNum).GraphicX2 = 0 And tmpEvent.Pages(curPageNum).GraphicY2 = 0 Then
                            sRect.top = tmpEvent.Pages(curPageNum).GraphicY * 32
                            sRect.left = tmpEvent.Pages(curPageNum).GraphicX * 32
                            sRect.bottom = sRect.top + 32
                            sRect.right = sRect.left + 32

                            With dRect
                                dRect.top = (193 / 2) - ((sRect.bottom - sRect.top) / 2)
                                dRect.bottom = dRect.top + (sRect.bottom - sRect.top)
                                dRect.left = (120 / 2) - ((sRect.right - sRect.left) / 2)
                                dRect.right = dRect.left + (sRect.right - sRect.left)
                            End With

                        Else
                            sRect.top = tmpEvent.Pages(curPageNum).GraphicY * 32
                            sRect.left = tmpEvent.Pages(curPageNum).GraphicX * 32
                            sRect.bottom = sRect.top + ((tmpEvent.Pages(curPageNum).GraphicY2 - tmpEvent.Pages(curPageNum).GraphicY) * 32)
                            sRect.right = sRect.left + ((tmpEvent.Pages(curPageNum).GraphicX2 - tmpEvent.Pages(curPageNum).GraphicX) * 32)

                            With dRect
                                dRect.top = (193 / 2) - ((sRect.bottom - sRect.top) / 2)
                                dRect.bottom = dRect.top + (sRect.bottom - sRect.top)
                                dRect.left = (120 / 2) - ((sRect.right - sRect.left) / 2)
                                dRect.right = dRect.left + (sRect.right - sRect.left)
                            End With

                        End If

                        g = Graphics.FromImage(targetBitmap)

                        Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height)  'This is the section we are pulling from the source graphic
                        Dim destRect As New Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height)     'This is the rectangle in the target graphic we want to render to

                        g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                        g.DrawRectangle(Pens.Red, New Rectangle(GraphicSelX * PIC_X, GraphicSelY * PIC_Y, (GraphicSelX2) * PIC_X, (GraphicSelY2) * PIC_Y))

                        g.Dispose()

                        frmEditor_Events.picGraphicSel.Width = targetBitmap.Width
                        frmEditor_Events.picGraphicSel.Height = targetBitmap.Height
                        frmEditor_Events.picGraphicSel.Visible = True
                        frmEditor_Events.picGraphicSel.BackgroundImage = targetBitmap
                        ' frmEditor_Events.pnlGraphicSelect.Width = targetBitmap.Width
                        'frmEditor_Events.pnlGraphicSelect.Height = targetBitmap.Height
                    Else
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                        Exit Sub
                    End If
            End Select
        Else
            If tmpEvent.PageCount > 0 Then
                Select Case tmpEvent.Pages(curPageNum).GraphicType
                    Case 0
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                    Case 1
                        If tmpEvent.Pages(curPageNum).Graphic > 0 And tmpEvent.Pages(curPageNum).Graphic <= NumCharacters Then
                            'Load character from Contents into our sourceBitmap
                            sourceBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "\characters\" & tmpEvent.Pages(curPageNum).Graphic & ".png")
                            targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                            g = Graphics.FromImage(targetBitmap)

                            Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height)  'This is the section we are pulling from the source graphic
                            Dim destRect As New Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height)     'This is the rectangle in the target graphic we want to render to

                            g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                            g.Dispose()

                            frmEditor_Events.picGraphic.Width = targetBitmap.Width
                            frmEditor_Events.picGraphic.Height = targetBitmap.Height
                            frmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        Else
                            frmEditor_Events.picGraphic.BackgroundImage = Nothing
                            Exit Sub
                        End If
                    Case 2
                        If tmpEvent.Pages(curPageNum).Graphic > 0 And tmpEvent.Pages(curPageNum).Graphic <= NumTileSets Then
                            'Load tilesheet from Contents into our sourceBitmap
                            sourceBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "tilesets\" & tmpEvent.Pages(curPageNum).Graphic & ".png")
                            targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                            If tmpEvent.Pages(curPageNum).GraphicX2 = 0 And tmpEvent.Pages(curPageNum).GraphicY2 = 0 Then
                                sRect.top = tmpEvent.Pages(curPageNum).GraphicY * 32
                                sRect.left = tmpEvent.Pages(curPageNum).GraphicX * 32
                                sRect.bottom = sRect.top + 32
                                sRect.right = sRect.left + 32

                                With dRect
                                    dRect.top = 0
                                    dRect.bottom = PIC_Y
                                    dRect.left = 0
                                    dRect.right = PIC_X
                                End With

                            Else
                                sRect.top = tmpEvent.Pages(curPageNum).GraphicY * 32
                                sRect.left = tmpEvent.Pages(curPageNum).GraphicX * 32
                                sRect.bottom = tmpEvent.Pages(curPageNum).GraphicY2 * 32
                                sRect.right = tmpEvent.Pages(curPageNum).GraphicX2 * 32

                                With dRect
                                    dRect.top = 0
                                    dRect.bottom = sRect.bottom
                                    dRect.left = 0
                                    dRect.right = sRect.right
                                End With

                            End If

                            g = Graphics.FromImage(targetBitmap)

                            Dim sourceRect As New Rectangle(sRect.left, sRect.top, sRect.right, sRect.bottom)  'This is the section we are pulling from the source graphic
                            Dim destRect As New Rectangle(dRect.left, dRect.top, dRect.right, dRect.bottom)     'This is the rectangle in the target graphic we want to render to

                            g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                            g.Dispose()

                            frmEditor_Events.picGraphic.Width = targetBitmap.Width
                            frmEditor_Events.picGraphic.Height = targetBitmap.Height
                            frmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        End If
                End Select
            End If
        End If

    End Sub

    Public Sub DrawEvents()
        Dim rec As Rectangle
        Dim Width As Integer, Height As Integer, i As Integer, X As Integer, Y As Integer
        Dim tX As Integer
        Dim tY As Integer

        If Map.EventCount <= 0 Then Exit Sub
        For i = 1 To Map.EventCount
            Width = 32
            Height = 32
            X = Map.Events(i).X * 32
            Y = Map.Events(i).Y * 32
            If Map.Events(i).PageCount <= 0 Then
                With rec
                    .Y = 0
                    .Height = PIC_Y
                    .X = 0
                    .Width = PIC_X
                End With
                Dim rec2 As New RectangleShape
                rec2.OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue)
                rec2.OutlineThickness = 0.6
                rec2.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
                rec2.Size = New Vector2f(rec.Width, rec.Height)
                rec2.Position = New Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
                GameWindow.Draw(rec2)
                GoTo nextevent
            End If
            X = ConvertMapX(X)
            Y = ConvertMapY(Y)
            If i > Map.EventCount Then Exit Sub
            If 1 > Map.Events(i).PageCount Then Exit Sub
            Select Case Map.Events(i).Pages(1).GraphicType
                Case 0
                    tX = ((X) - 4) + (PIC_X * 0.5)
                    tY = ((Y) - 7) + (PIC_Y * 0.5)
                    DrawText(tX, tY, "EV", (SFML.Graphics.Color.Green), (SFML.Graphics.Color.Black), GameWindow)
                Case 1
                    If Map.Events(i).Pages(1).Graphic > 0 And Map.Events(i).Pages(1).Graphic <= NumCharacters Then
                        If CharacterGFXInfo(Map.Events(i).Pages(1).Graphic).IsLoaded = False Then
                            LoadTexture(Map.Events(i).Pages(1).Graphic, 2)
                        End If

                        'seeying we still use it, lets update timer
                        With CharacterGFXInfo(Map.Events(i).Pages(1).Graphic)
                            .TextureTimer = GetTickCount() + 100000
                        End With
                        With rec
                            .Y = (Map.Events(i).Pages(1).GraphicY * (CharacterGFXInfo(Map.Events(i).Pages(1).Graphic).height / 4))
                            .Height = .Y + PIC_Y
                            .X = (Map.Events(i).Pages(1).GraphicX * (CharacterGFXInfo(Map.Events(i).Pages(1).Graphic).width / 4))
                            .Width = .X + PIC_X
                        End With
                        Dim tmpSprite As Sprite = New Sprite(CharacterGFX(Map.Events(i).Pages(1).Graphic))
                        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                        tmpSprite.Position = New Vector2f(ConvertMapX(Map.Events(i).X * PIC_X), ConvertMapY(Map.Events(i).Y * PIC_Y))
                        GameWindow.Draw(tmpSprite)
                    Else
                        With rec
                            .Y = 0
                            .Height = PIC_Y
                            .X = 0
                            .Width = PIC_X
                        End With
                        Dim rec2 As New RectangleShape
                        rec2.OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue)
                        rec2.OutlineThickness = 0.6
                        rec2.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
                        rec2.Size = New Vector2f(rec.Width, rec.Height)
                        rec2.Position = New Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
                        GameWindow.Draw(rec2)
                    End If
                Case 2
                    If Map.Events(i).Pages(1).Graphic > 0 And Map.Events(i).Pages(1).Graphic < NumTileSets Then
                        With rec
                            .X = Map.Events(i).Pages(1).GraphicX * 32
                            .Width = Map.Events(i).Pages(1).GraphicX2 * 32
                            .Y = Map.Events(i).Pages(1).GraphicY * 32
                            .Height = Map.Events(i).Pages(1).GraphicY2 * 32
                        End With

                        Dim tmpSprite As Sprite = New Sprite(TileSetTexture(Map.Events(i).Pages(1).Graphic))
                        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                        tmpSprite.Position = New Vector2f(ConvertMapX(Map.Events(i).X * PIC_X), ConvertMapY(Map.Events(i).Y * PIC_Y))
                        GameWindow.Draw(tmpSprite)
                    Else
                        With rec
                            .Y = 0
                            .Height = PIC_Y
                            .X = 0
                            .Width = PIC_X
                        End With
                        Dim rec2 As New RectangleShape
                        rec2.OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue)
                        rec2.OutlineThickness = 0.6
                        rec2.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
                        rec2.Size = New Vector2f(rec.Width, rec.Height)
                        rec2.Position = New Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
                        GameWindow.Draw(rec2)
                    End If
            End Select
nextevent:
        Next

    End Sub

    Public Sub DrawEvent(id As Integer)
        Dim X As Integer, Y As Integer, Width As Integer, Height As Integer, sRect As Rectangle, Anim As Integer, spritetop As Integer

        If Map.MapEvents(id).Visible = 0 Then Exit Sub
        If InMapEditor Then Exit Sub
        Select Case Map.MapEvents(id).GraphicType
            Case 0
                Exit Sub
            Case 1
                If Map.MapEvents(id).GraphicNum <= 0 Or Map.MapEvents(id).GraphicNum > NumCharacters Then Exit Sub

                ' Reset frame
                If Map.MapEvents(id).Steps = 3 Then
                    Anim = 0
                ElseIf Map.MapEvents(id).Steps = 1 Then
                    Anim = 2
                End If

                Select Case Map.MapEvents(id).dir
                    Case Direction.Up
                        If (Map.MapEvents(id).YOffset > 8) Then Anim = Map.MapEvents(id).Steps
                    Case Direction.Down
                        If (Map.MapEvents(id).YOffset < -8) Then Anim = Map.MapEvents(id).Steps
                    Case Direction.Left
                        If (Map.MapEvents(id).XOffset > 8) Then Anim = Map.MapEvents(id).Steps
                    Case Direction.Right
                        If (Map.MapEvents(id).XOffset < -8) Then Anim = Map.MapEvents(id).Steps
                End Select

                ' Set the left
                Select Case Map.MapEvents(id).ShowDir
                    Case Direction.Up
                        spritetop = 3
                    Case Direction.Right
                        spritetop = 2
                    Case Direction.Down
                        spritetop = 0
                    Case Direction.Left
                        spritetop = 1
                End Select

                If Map.MapEvents(id).WalkAnim = 1 Then Anim = 0
                If Map.MapEvents(id).Moving = 0 Then Anim = Map.MapEvents(id).GraphicX

                Width = CharacterGFXInfo(Map.MapEvents(id).GraphicNum).width / 4
                Height = CharacterGFXInfo(Map.MapEvents(id).GraphicNum).height / 4

                sRect = New Rectangle((Anim) * (CharacterGFXInfo(Map.MapEvents(id).GraphicNum).width / 4), spritetop * (CharacterGFXInfo(Map.MapEvents(id).GraphicNum).height / 4), (CharacterGFXInfo(Map.MapEvents(id).GraphicNum).width / 4), (CharacterGFXInfo(Map.MapEvents(id).GraphicNum).height / 4))
                ' Calculate the X
                X = Map.MapEvents(id).X * PIC_X + Map.MapEvents(id).XOffset - ((CharacterGFXInfo(Map.MapEvents(id).GraphicNum).width / 4 - 32) / 2)

                ' Is the player's height more than 32..?
                If (CharacterGFXInfo(Map.MapEvents(id).GraphicNum).height * 4) > 32 Then
                    ' Create a 32 pixel offset for larger sprites
                    Y = Map.MapEvents(id).Y * PIC_Y + Map.MapEvents(id).YOffset - ((CharacterGFXInfo(Map.MapEvents(id).GraphicNum).height / 4) - 32)
                Else
                    ' Proceed as normal
                    Y = Map.MapEvents(id).Y * PIC_Y + Map.MapEvents(id).YOffset
                End If
                ' render the actual sprite
                DrawCharacter(Map.MapEvents(id).GraphicNum, X, Y, sRect)
            Case 2
                If Map.MapEvents(id).GraphicNum < 1 Or Map.MapEvents(id).GraphicNum > NumTileSets Then Exit Sub
                If Map.MapEvents(id).GraphicY2 > 0 Or Map.MapEvents(id).GraphicX2 > 0 Then
                    With sRect
                        .X = Map.MapEvents(id).GraphicX * 32
                        .Y = Map.MapEvents(id).GraphicY * 32
                        .Width = Map.MapEvents(id).GraphicX2 * 32
                        .Height = Map.MapEvents(id).GraphicY2 * 32
                    End With
                Else
                    With sRect
                        .X = Map.MapEvents(id).GraphicY * 32
                        .Height = .Top + 32
                        .Y = Map.MapEvents(id).GraphicX * 32
                        .Width = .Left + 32
                    End With
                End If
                X = Map.MapEvents(id).X * 32
                Y = Map.MapEvents(id).Y * 32
                X = X - ((sRect.Right - sRect.Left) / 2)
                Y = Y - (sRect.Bottom - sRect.Top) + 32
                If Map.MapEvents(id).GraphicY2 > 0 Then
                    RenderSprite(TileSetSprite(Map.MapEvents(id).GraphicNum), GameWindow, ConvertMapX(Map.MapEvents(id).X * 32), ConvertMapY(Map.MapEvents(id).Y * 32) - ConvertMapX(Map.MapEvents(id).GraphicY2 * 32) + 32, sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                Else
                    RenderSprite(TileSetSprite(Map.MapEvents(id).GraphicNum), GameWindow, ConvertMapX(Map.MapEvents(id).X * 32), ConvertMapY(Map.MapEvents(id).Y * 32), sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                End If
                'tmpSprite.Position = New Vector2f(ConvertMapX(Map.Events(i).X * PIC_X), ConvertMapY(Map.Events(i).Y * PIC_Y))
        End Select

    End Sub
#End Region

#Region "Misc"

    Public Function GetColorString(color As Integer)

        Select Case color
            Case 0
                GetColorString = "Black"
            Case 1
                GetColorString = "Blue"
            Case 2
                GetColorString = "Green"
            Case 3
                GetColorString = "Cyan"
            Case 4
                GetColorString = "Red"
            Case 5
                GetColorString = "Magenta"
            Case 6
                GetColorString = "Brown"
            Case 7
                GetColorString = "Grey"
            Case 8
                GetColorString = "Dark Grey"
            Case 9
                GetColorString = "Bright Blue"
            Case 10
                GetColorString = "Bright Green"
            Case 11
                GetColorString = "Bright Cyan"
            Case 12
                GetColorString = "Bright Red"
            Case 13
                GetColorString = "Pink"
            Case 14
                GetColorString = "Yellow"
            Case 15
                GetColorString = "White"
            Case Else
                GetColorString = "Black"
        End Select

    End Function

    Public Sub ResetEventdata()
        For i = 0 To Map.EventCount
            ReDim Map.MapEvents(Map.EventCount)
            Map.CurrentEvents = 0
            With Map.MapEvents(i)
                .Name = ""
                .dir = 0
                .ShowDir = 0
                .GraphicNum = 0
                .GraphicType = 0
                .GraphicX = 0
                .GraphicX2 = 0
                .GraphicY = 0
                .GraphicY2 = 0
                .MovementSpeed = 0
                .Moving = 0
                .X = 0
                .Y = 0
                .XOffset = 0
                .YOffset = 0
                .Position = 0
                .Visible = 0
                .WalkAnim = 0
                .DirFix = 0
                .WalkThrough = 0
                .ShowName = 0
                .questnum = 0
            End With
        Next
    End Sub
#End Region
End Module