Imports System.Drawing
Imports System.Windows.Forms
Imports SFML.Graphics
Imports SFML.Window

Public Module ClientEventSystem
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
                Case Direction.UP
                    .YOffset = PIC_Y
                Case Direction.DOWN
                    .YOffset = PIC_Y * -1
                Case Direction.LEFT
                    .XOffset = PIC_X
                Case Direction.RIGHT
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

    Sub Packet_PlayBGM(ByVal data() As Byte)
        Dim buffer As ByteBuffer, music As String

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SPlayBGM Then Exit Sub

        music = buffer.ReadString

        PlayMusic(music)

        buffer = Nothing
    End Sub

    Sub Packet_FadeOutBGM(ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SFadeoutBGM Then Exit Sub
        CurMusic = ""
        FadeOutSwitch = True

        buffer = Nothing
    End Sub

    Sub Packet_PlaySound(ByVal data() As Byte)
        Dim buffer As ByteBuffer, sound As String

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SPlaySound Then Exit Sub

        sound = buffer.ReadString

        PlaySound(sound)

        buffer = Nothing
    End Sub

    Sub Packet_StopSound(ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SStopSound Then Exit Sub

        StopSound()

        buffer = Nothing
    End Sub

    Sub Packet_SpecialEffect(ByVal data() As Byte)
        Dim buffer As ByteBuffer, effectType As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SSpecialEffect Then Exit Sub

        effectType = buffer.ReadInteger

        Select Case effectType
            Case EFFECT_TYPE_FADEIN
                FadeType = 1
                FadeAmount = 0
            Case EFFECT_TYPE_FADEOUT
                FadeType = 0
                FadeAmount = 255
            Case EFFECT_TYPE_FLASH
                FlashTimer = GetTickCount() + 150
            Case EFFECT_TYPE_FOG
                CurrentFog = buffer.ReadInteger
                CurrentFogSpeed = buffer.ReadInteger
                CurrentFogOpacity = buffer.ReadInteger
            Case EFFECT_TYPE_WEATHER
                CurrentWeather = buffer.ReadInteger
                CurrentWeatherIntensity = buffer.ReadInteger
            Case EFFECT_TYPE_TINT
                Map.HasMapTint = 1
                CurrentTintR = buffer.ReadInteger
                CurrentTintG = buffer.ReadInteger
                CurrentTintB = buffer.ReadInteger
                CurrentTintA = buffer.ReadInteger
        End Select

        buffer = Nothing
    End Sub

#End Region

#Region "Drawing..."

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
                    Case Direction.UP
                        If (Map.MapEvents(id).YOffset > 8) Then Anim = Map.MapEvents(id).Steps
                    Case Direction.DOWN
                        If (Map.MapEvents(id).YOffset < -8) Then Anim = Map.MapEvents(id).Steps
                    Case Direction.LEFT
                        If (Map.MapEvents(id).XOffset > 8) Then Anim = Map.MapEvents(id).Steps
                    Case Direction.RIGHT
                        If (Map.MapEvents(id).XOffset < -8) Then Anim = Map.MapEvents(id).Steps
                End Select

                ' Set the left
                Select Case Map.MapEvents(id).ShowDir
                    Case Direction.UP
                        spritetop = 3
                    Case Direction.RIGHT
                        spritetop = 2
                    Case Direction.DOWN
                        spritetop = 0
                    Case Direction.LEFT
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
                    RenderTexture(TileSetTexture(Map.MapEvents(id).GraphicNum), GameWindow, ConvertMapX(Map.MapEvents(id).X * 32), ConvertMapY(Map.MapEvents(id).Y * 32) - ConvertMapX(Map.MapEvents(id).GraphicY2 * 32) + 32, sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                Else
                    RenderTexture(TileSetTexture(Map.MapEvents(id).GraphicNum), GameWindow, ConvertMapX(Map.MapEvents(id).X * 32), ConvertMapY(Map.MapEvents(id).Y * 32), sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                End If
                'tmpSprite.Position = New Vector2f(ConvertMapX(Map.Events(i).X * PIC_X), ConvertMapY(Map.Events(i).Y * PIC_Y))
        End Select

    End Sub

    Public Sub DrawEventChat()
        Dim temptext As String, txtArray As New List(Of String)
        Dim tmpY As Integer = 0

        'first render panel
        RenderTexture(EventChatGFX, GameWindow, EventChatX, EventChatY, 0, 0, EventChatGFXInfo.width, EventChatGFXInfo.height)

        With frmMainGame
            'face
            If EventChatFace > 0 And EventChatFace < NumFaces Then
                'render face
                If FacesGFXInfo(EventChatFace).IsLoaded = False Then
                    LoadTexture(EventChatFace, 7)
                End If

                'seeying we still use it, lets update timer
                With FacesGFXInfo(EventChatFace)
                    .TextureTimer = GetTickCount() + 100000
                End With
                RenderTexture(FacesGFX(EventChatFace), GameWindow, EventChatX + 12, EventChatY + 14, 0, 0, FacesGFXInfo(EventChatFace).width, FacesGFXInfo(EventChatFace).height)
                EventChatTextX = 113
            Else
                EventChatTextX = 14
            End If

            'EventPrompt
            txtArray = WordWrap(EventText, 45)
            For i = 0 To txtArray.Count
                If i = txtArray.Count Then Exit For
                'draw text
                DrawText(EventChatX + EventChatTextX, EventChatY + EventChatTextY + tmpY, Trim$(txtArray(i).Replace(vbCrLf, "")), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                tmpY = tmpY + 20
            Next

            If EventChatType = 1 Then

                If EventChoiceVisible(1) Then
                    'Response1
                    temptext = EventChoices(1)
                    DrawText(EventChatX + 10, EventChatY + 124, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

                If EventChoiceVisible(2) Then
                    'Response2
                    temptext = EventChoices(2)
                    DrawText(EventChatX + 10, EventChatY + 146, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

                If EventChoiceVisible(3) Then
                    'Response3
                    temptext = EventChoices(3)
                    DrawText(EventChatX + 226, EventChatY + 124, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

                If EventChoiceVisible(4) Then
                    'Response4
                    temptext = EventChoices(4)
                    DrawText(EventChatX + 226, EventChatY + 146, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
                End If

            Else
                temptext = "Continue"
                DrawText(EventChatX + 410, EventChatY + 156, Trim(temptext), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)
            End If

        End With

    End Sub
#End Region

#Region "Misc"

    Sub ProcessEventMovement(ByVal id As Integer)

        If id > Map.EventCount Then Exit Sub

        If Map.MapEvents(id).Moving = 1 Then
            Select Case Map.MapEvents(id).dir
                Case Direction.UP
                    Map.MapEvents(id).YOffset = Map.MapEvents(id).YOffset - ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SIZE_X))
                    If Map.MapEvents(id).YOffset < 0 Then Map.MapEvents(id).YOffset = 0
                Case Direction.DOWN
                    Map.MapEvents(id).YOffset = Map.MapEvents(id).YOffset + ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SIZE_X))
                    If Map.MapEvents(id).YOffset > 0 Then Map.MapEvents(id).YOffset = 0
                Case Direction.LEFT
                    Map.MapEvents(id).XOffset = Map.MapEvents(id).XOffset - ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SIZE_X))
                    If Map.MapEvents(id).XOffset < 0 Then Map.MapEvents(id).XOffset = 0
                Case Direction.RIGHT
                    Map.MapEvents(id).XOffset = Map.MapEvents(id).XOffset + ((ElapsedTime / 1000) * (Map.MapEvents(id).MovementSpeed * SIZE_X))
                    If Map.MapEvents(id).XOffset > 0 Then Map.MapEvents(id).XOffset = 0
            End Select
            ' Check if completed walking over to the next tile
            If Map.MapEvents(id).Moving > 0 Then
                If Map.MapEvents(id).dir = Direction.RIGHT Or Map.MapEvents(id).dir = Direction.DOWN Then
                    If (Map.MapEvents(id).XOffset >= 0) And (Map.MapEvents(id).YOffset >= 0) Then
                        Map.MapEvents(id).Moving = 0
                        If Map.MapEvents(id).Steps = 1 Then
                            Map.MapEvents(id).Steps = 3
                        Else
                            Map.MapEvents(id).Steps = 1
                        End If
                    End If
                Else
                    If (Map.MapEvents(id).XOffset <= 0) And (Map.MapEvents(id).YOffset <= 0) Then
                        Map.MapEvents(id).Moving = 0
                        If Map.MapEvents(id).Steps = 1 Then
                            Map.MapEvents(id).Steps = 3
                        Else
                            Map.MapEvents(id).Steps = 1
                        End If
                    End If
                End If
            End If
        End If

    End Sub

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

    Sub ClearEventChat()
        Dim i As Integer

        If AnotherChat = 1 Then
            For i = 1 To 4
                EventChoiceVisible(i) = False
            Next
            EventText = ""
            EventChatType = 1
            EventChatTimer = GetTickCount() + 100
        ElseIf AnotherChat = 2 Then
            For i = 1 To 4
                EventChoiceVisible(i) = False
            Next
            EventText = ""
            EventChatType = 1
            EventChatTimer = GetTickCount() + 100
        Else
            EventChat = False
        End If
        pnlEventChatVisible = False
    End Sub

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
