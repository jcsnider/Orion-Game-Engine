﻿Imports System.IO

Public Module ServerQuest
#Region "Constants"
    'Constants
    Public Const MAX_QUESTS As Byte = 250
    'Public Const MAX_TASKS As Byte = 10
    'Public Const MAX_REQUIREMENTS As Byte = 10
    Public Const MAX_ACTIVEQUESTS = 10

    Public Const EDITOR_TASKS As Byte = 7

    'Public Const QUEST_TYPE_GOSLAY As Byte = 1
    'Public Const QUEST_TYPE_GOCOLLECT As Byte = 2
    'Public Const QUEST_TYPE_GOTALK As Byte = 3
    'Public Const QUEST_TYPE_GOREACH As Byte = 4
    'Public Const QUEST_TYPE_GOGIVE As Byte = 5
    'Public Const QUEST_TYPE_GOKILL As Byte = 6
    'Public Const QUEST_TYPE_GOGATHER As Byte = 7
    'Public Const QUEST_TYPE_GOFETCH As Byte = 8
    'Public Const QUEST_TYPE_TALKEVENT As Byte = 9

    'Public Const QUEST_NOT_STARTED As Byte = 0
    'Public Const QUEST_STARTED As Byte = 1
    'Public Const QUEST_COMPLETED As Byte = 2
    'Public Const QUEST_REPEATABLE As Byte = 3

    'Types
    Public Quest(0 To MAX_QUESTS) As QuestRec

    Public Structure PlayerQuestRec
        Dim Status As Integer '0=not started, 1=started, 2=completed, 3=completed but repeatable
        Dim ActualTask As Integer
        Dim CurrentCount As Integer 'Used to handle the Amount property
    End Structure

    Public Structure TaskRec
        Dim Order As Integer
        Dim NPC As Integer
        Dim Item As Integer
        Dim Map As Integer
        Dim Resource As Integer
        Dim Amount As Integer
        Dim Speech As String
        Dim TaskLog As String
        Dim QuestEnd As Byte
        Dim TaskType As Integer
    End Structure

    Public Structure QuestRec
        Dim Name As String
        Dim QuestLog As String
        Dim Repeat As Byte
        Dim Cancelable As Byte

        Dim ReqCount As Integer
        Dim Requirement() As Integer '1=item, 2=quest, 3=class
        Dim RequirementIndex() As Integer

        Dim QuestGiveItem As Integer 'Todo: make this dynamic
        Dim QuestGiveItemValue As Integer
        Dim QuestRemoveItem As Integer
        Dim QuestRemoveItemValue As Integer

        Dim Chat() As String

        Dim RewardCount As Integer
        Dim RewardItem() As Integer
        Dim RewardItemAmount() As Integer
        Dim RewardExp As Integer

        Dim TaskCount As Integer
        Dim Task() As TaskRec

    End Structure
#End Region

#Region "Database"
    Sub SaveQuests()
        Dim I As Integer
        For I = 1 To MAX_QUESTS
            SaveQuest(I)
            DoEvents()
        Next
    End Sub

    Sub SaveQuest(ByVal QuestNum As Integer)
        Dim filename As String
        Dim I As Integer
        filename = Path.Combine(Application.StartupPath, "data", "quests", String.Format("quest{0}.dat", QuestNum))

        Dim writer As New ArchaicIO.File.BinaryStream.Writer

        writer.Write(Quest(QuestNum).Name)
        writer.Write(Quest(QuestNum).QuestLog)
        writer.Write(Quest(QuestNum).Repeat)
        writer.Write(Quest(QuestNum).Cancelable)

        writer.Write(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            writer.Write(Quest(QuestNum).Requirement(I))
            writer.Write(Quest(QuestNum).RequirementIndex(I))
        Next

        writer.Write(Quest(QuestNum).QuestGiveItem)
        writer.Write(Quest(QuestNum).QuestGiveItemValue)
        writer.Write(Quest(QuestNum).QuestRemoveItem)
        writer.Write(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            writer.Write(Quest(QuestNum).Chat(I))
        Next

        writer.Write(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            writer.Write(Quest(QuestNum).RewardItem(I))
            writer.Write(Quest(QuestNum).RewardItemAmount(I))
        Next
        writer.Write(Quest(QuestNum).RewardExp)

        writer.Write(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            writer.Write(Quest(QuestNum).Task(I).Order)
            writer.Write(Quest(QuestNum).Task(I).NPC)
            writer.Write(Quest(QuestNum).Task(I).Item)
            writer.Write(Quest(QuestNum).Task(I).Map)
            writer.Write(Quest(QuestNum).Task(I).Resource)
            writer.Write(Quest(QuestNum).Task(I).Amount)
            writer.Write(Quest(QuestNum).Task(I).Speech)
            writer.Write(Quest(QuestNum).Task(I).TaskLog)
            writer.Write(Quest(QuestNum).Task(I).QuestEnd)
            writer.Write(Quest(QuestNum).Task(I).TaskType)
        Next

        writer.Save(filename)
        'load it so see if it matches O.o
        LoadQuest(QuestNum)
    End Sub

    Sub LoadQuests()
        Dim I As Integer

        CheckQuests()

        For I = 1 To MAX_QUESTS
            LoadQuest(I)
            DoEvents()
        Next
    End Sub

    Sub LoadQuest(ByVal QuestNum As Integer)
        Dim FileName As String
        Dim I As Integer

        FileName = Path.Combine(Application.StartupPath, "data", "quests", String.Format("quest{0}.dat", QuestNum))

        Dim reader As New ArchaicIO.File.BinaryStream.Reader(FileName)

        reader.Read(Quest(QuestNum).Name)
        reader.Read(Quest(QuestNum).QuestLog)
        reader.Read(Quest(QuestNum).Repeat)
        reader.Read(Quest(QuestNum).Cancelable)

        reader.Read(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).Requirement(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).RequirementIndex(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            reader.Read(Quest(QuestNum).Requirement(I))
            reader.Read(Quest(QuestNum).RequirementIndex(I))
        Next

        reader.Read(Quest(QuestNum).QuestGiveItem)
        reader.Read(Quest(QuestNum).QuestGiveItemValue)
        reader.Read(Quest(QuestNum).QuestRemoveItem)
        reader.Read(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            reader.Read(Quest(QuestNum).Chat(I))
        Next

        reader.Read(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItem(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItemAmount(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            reader.Read(Quest(QuestNum).RewardItem(I))
            reader.Read(Quest(QuestNum).RewardItemAmount(I))
        Next
        reader.Read(Quest(QuestNum).RewardExp)

        reader.Read(Quest(QuestNum).TaskCount)
        ReDim Quest(QuestNum).Task(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            reader.Read(Quest(QuestNum).Task(I).Order)
            reader.Read(Quest(QuestNum).Task(I).NPC)
            reader.Read(Quest(QuestNum).Task(I).Item)
            reader.Read(Quest(QuestNum).Task(I).Map)
            reader.Read(Quest(QuestNum).Task(I).Resource)
            reader.Read(Quest(QuestNum).Task(I).Amount)
            reader.Read(Quest(QuestNum).Task(I).Speech)
            reader.Read(Quest(QuestNum).Task(I).TaskLog)
            reader.Read(Quest(QuestNum).Task(I).QuestEnd)
            reader.Read(Quest(QuestNum).Task(I).TaskType)
        Next
    End Sub

    Sub CheckQuests()
        Dim I As Integer
        For I = 1 To MAX_QUESTS
            If Not FileExist(Path.Combine(Application.StartupPath, "data", "quests", String.Format("quest{0}.dat", I))) Then
                SaveQuest(I)
                DoEvents()
            End If
        Next
    End Sub

    Sub ClearQuest(ByVal QuestNum As Integer)
        Dim I As Integer

        ' clear the Quest
        Quest(QuestNum).Name = ""
        Quest(QuestNum).QuestLog = ""
        Quest(QuestNum).Repeat = 0
        Quest(QuestNum).Cancelable = 0

        Quest(QuestNum).ReqCount = 0
        ReDim Quest(QuestNum).Requirement(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).RequirementIndex(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Quest(QuestNum).Requirement(QuestNum) = 0
            Quest(QuestNum).RequirementIndex(QuestNum) = 0
        Next

        Quest(QuestNum).QuestGiveItem = 0
        Quest(QuestNum).QuestGiveItemValue = 0
        Quest(QuestNum).QuestRemoveItem = 0
        Quest(QuestNum).QuestRemoveItemValue = 0

        ReDim Quest(QuestNum).Chat(3)
        For I = 1 To 3
            Quest(QuestNum).Chat(I) = ""
        Next

        Quest(QuestNum).RewardCount = 0
        ReDim Quest(QuestNum).RewardItem(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItemAmount(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            Quest(QuestNum).RewardItem(I) = 0
            Quest(QuestNum).RewardItemAmount(I) = 0
        Next
        Quest(QuestNum).RewardExp = 0

        Quest(QuestNum).TaskCount = 0
        ReDim Quest(QuestNum).Task(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            Quest(QuestNum).Task(I).Order = 0
            Quest(QuestNum).Task(I).NPC = 0
            Quest(QuestNum).Task(I).Item = 0
            Quest(QuestNum).Task(I).Map = 0
            Quest(QuestNum).Task(I).Resource = 0
            Quest(QuestNum).Task(I).Amount = 0
            Quest(QuestNum).Task(I).Speech = ""
            Quest(QuestNum).Task(I).TaskLog = ""
            Quest(QuestNum).Task(I).QuestEnd = 0
            Quest(QuestNum).Task(I).TaskType = 0
        Next

    End Sub

    Sub ClearQuests()
        Dim I As Integer

        For I = 1 To MAX_QUESTS
            ClearQuest(I)
            DoEvents()
        Next
    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_RequestEditQuest(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> EditorPackets.RequestEditQuest Then Exit Sub

        Buffer = Nothing

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SQuestEditor)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub Packet_SaveQuest(ByVal Index As Integer, ByVal Data() As Byte)
        Dim QuestNum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> EditorPackets.SaveQuest Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        QuestNum = Buffer.ReadInteger
        If QuestNum < 0 Or QuestNum > MAX_QUESTS Then Exit Sub

        ' Update the Quest
        Quest(QuestNum).Name = Buffer.ReadString
        Quest(QuestNum).QuestLog = Buffer.ReadString
        Quest(QuestNum).Repeat = Buffer.ReadInteger
        Quest(QuestNum).Cancelable = Buffer.ReadInteger

        Quest(QuestNum).ReqCount = Buffer.ReadInteger
        ReDim Quest(QuestNum).Requirement(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).RequirementIndex(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Quest(QuestNum).Requirement(I) = Buffer.ReadInteger
            Quest(QuestNum).RequirementIndex(I) = Buffer.ReadInteger
        Next

        Quest(QuestNum).QuestGiveItem = Buffer.ReadInteger
        Quest(QuestNum).QuestGiveItemValue = Buffer.ReadInteger
        Quest(QuestNum).QuestRemoveItem = Buffer.ReadInteger
        Quest(QuestNum).QuestRemoveItemValue = Buffer.ReadInteger

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = Buffer.ReadString
        Next

        Quest(QuestNum).RewardCount = Buffer.ReadInteger
        ReDim Quest(QuestNum).RewardItem(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItemAmount(Quest(QuestNum).RewardCount)
        For i = 1 To Quest(QuestNum).RewardCount
            Quest(QuestNum).RewardItem(i) = Buffer.ReadInteger
            Quest(QuestNum).RewardItemAmount(i) = Buffer.ReadInteger
        Next

        Quest(QuestNum).RewardExp = Buffer.ReadInteger

        Quest(QuestNum).TaskCount = Buffer.ReadInteger
        ReDim Quest(QuestNum).Task(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            Quest(QuestNum).Task(I).Order = Buffer.ReadInteger
            Quest(QuestNum).Task(I).NPC = Buffer.ReadInteger
            Quest(QuestNum).Task(I).Item = Buffer.ReadInteger
            Quest(QuestNum).Task(I).Map = Buffer.ReadInteger
            Quest(QuestNum).Task(I).Resource = Buffer.ReadInteger
            Quest(QuestNum).Task(I).Amount = Buffer.ReadInteger
            Quest(QuestNum).Task(I).Speech = Buffer.ReadString
            Quest(QuestNum).Task(I).TaskLog = Buffer.ReadString
            Quest(QuestNum).Task(I).QuestEnd = Buffer.ReadInteger
            Quest(QuestNum).Task(I).TaskType = Buffer.ReadInteger
        Next

        Buffer = Nothing

        ' Save it
        SendQuests(Index) ' editor
        SendUpdateQuestToAll(QuestNum) 'players
        SaveQuest(QuestNum)
        Addlog(GetPlayerLogin(Index) & " saved Quest #" & QuestNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_RequestQuests(ByVal Index As Integer, ByVal Data() As Byte)
        SendQuests(Index)
    End Sub

    Sub Packet_PlayerHandleQuest(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim QuestNum As Integer, Order As Integer ', I As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CPlayerHandleQuest Then Exit Sub

        QuestNum = Buffer.ReadInteger
        Order = Buffer.ReadInteger '1 = accept, 2 = cancel

        If Order = 1 Then
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.Started '1
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = 1
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = 0
            PlayerMsg(Index, "New quest accepted: " & Trim$(Quest(QuestNum).Name) & "!", ColorType.BrightGreen)
        ElseIf Order = 2 Then
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.NotStarted '2
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = 1
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = 0

            PlayerMsg(Index, Trim$(Quest(QuestNum).Name) & " has been canceled!", ColorType.BrightRed)

            If GetPlayerAccess(Index) > 0 And QuestNum = 1 Then
                For I = 1 To MAX_QUESTS
                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(I).Status = QuestStatus.NotStarted '2
                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(I).ActualTask = 1
                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(I).CurrentCount = 0
                Next
            End If
        End If

        SavePlayer(Index)
        SendPlayerData(Index)
        SendPlayerQuests(Index)
        Buffer = Nothing
    End Sub

    Sub Packet_QuestLogUpdate(ByVal Index As Integer, ByVal Data() As Byte)
        SendPlayerQuests(Index)
    End Sub

    Sub Packet_QuestReset(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim QuestNum As Integer

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CQuestReset Then Exit Sub

        QuestNum = Buffer.ReadInteger

        ResetQuest(Index, QuestNum)

        Buffer = Nothing
    End Sub
#End Region

#Region "Outgoing packets"
    Sub SendQuests(ByVal Index As Integer)
        Dim I As Integer

        For I = 1 To MAX_QUESTS
            If Len(Trim$(Quest(I).Name)) > 0 Then
                SendUpdateQuestTo(Index, I)
            End If
        Next
    End Sub

    Sub SendUpdateQuestToAll(ByVal QuestNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateQuest)
        Buffer.WriteInteger(QuestNum)

        Buffer.WriteString(Trim(Quest(QuestNum).Name))
        Buffer.WriteString(Trim(Quest(QuestNum).QuestLog))
        Buffer.WriteInteger(Quest(QuestNum).Repeat)
        Buffer.WriteInteger(Quest(QuestNum).Cancelable)

        Buffer.WriteInteger(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Buffer.WriteInteger(Quest(QuestNum).Requirement(I))
            Buffer.WriteInteger(Quest(QuestNum).RequirementIndex(I))
        Next

        Buffer.WriteInteger(Quest(QuestNum).QuestGiveItem)
        Buffer.WriteInteger(Quest(QuestNum).QuestGiveItemValue)
        Buffer.WriteInteger(Quest(QuestNum).QuestRemoveItem)
        Buffer.WriteInteger(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            Buffer.WriteString(Trim(Quest(QuestNum).Chat(I)))
        Next

        Buffer.WriteInteger(Quest(QuestNum).RewardCount)
        For i = 1 To Quest(QuestNum).RewardCount
            Buffer.WriteInteger(Quest(QuestNum).RewardItem(i))
            Buffer.WriteInteger(Quest(QuestNum).RewardItemAmount(i))
        Next

        Buffer.WriteInteger(Quest(QuestNum).RewardExp)

        Buffer.WriteInteger(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Order)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).NPC)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Item)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Map)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Resource)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Amount)
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).Speech))
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).TaskLog))
            Buffer.WriteInteger(Quest(QuestNum).Task(I).QuestEnd)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).TaskType)
        Next

        SendDataToAll(Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub SendUpdateQuestTo(ByVal Index As Integer, ByVal QuestNum As Integer)
        Dim Buffer As ByteBuffer, I As Integer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateQuest)
        Buffer.WriteInteger(QuestNum)

        Buffer.WriteString(Trim(Quest(QuestNum).Name))
        Buffer.WriteString(Trim(Quest(QuestNum).QuestLog))
        Buffer.WriteInteger(Quest(QuestNum).Repeat)
        Buffer.WriteInteger(Quest(QuestNum).Cancelable)

        Buffer.WriteInteger(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Buffer.WriteInteger(Quest(QuestNum).Requirement(I))
            Buffer.WriteInteger(Quest(QuestNum).RequirementIndex(I))
        Next

        Buffer.WriteInteger(Quest(QuestNum).QuestGiveItem)
        Buffer.WriteInteger(Quest(QuestNum).QuestGiveItemValue)
        Buffer.WriteInteger(Quest(QuestNum).QuestRemoveItem)
        Buffer.WriteInteger(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            Buffer.WriteString(Trim(Quest(QuestNum).Chat(I)))
        Next

        Buffer.WriteInteger(Quest(QuestNum).RewardCount)
        For I = 1 To Quest(QuestNum).RewardCount
            Buffer.WriteInteger(Quest(QuestNum).RewardItem(I))
            Buffer.WriteInteger(Quest(QuestNum).RewardItemAmount(I))
        Next

        Buffer.WriteInteger(Quest(QuestNum).RewardExp)

        Buffer.WriteInteger(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Order)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).NPC)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Item)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Map)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Resource)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).Amount)
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).Speech))
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).TaskLog))
            Buffer.WriteInteger(Quest(QuestNum).Task(I).QuestEnd)
            Buffer.WriteInteger(Quest(QuestNum).Task(I).TaskType)
        Next

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerQuests(ByVal Index As Integer)
        Dim I As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPlayerQuests)

        For I = 1 To MAX_QUESTS
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(I).Status)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(I).ActualTask)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(I).CurrentCount)
        Next

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Public Sub SendPlayerQuest(ByVal Index As Integer, ByVal QuestNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPlayerQuest)

        Buffer.WriteInteger(QuestNum)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount)

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    'sends a message to the client that is shown on the screen
    Public Sub QuestMessage(ByVal Index As Integer, ByVal QuestNum As Integer, ByVal message As String, ByVal QuestNumForStart As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SQuestMessage)

        Buffer.WriteInteger(QuestNum)
        Buffer.WriteString(Trim$(message))
        Buffer.WriteInteger(QuestNumForStart)

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub
#End Region

#Region "Functions"

    Public Sub ResetQuest(ByVal Index As Integer, ByVal QuestNum As Integer)
        If GetPlayerAccess(Index) > 0 Then
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.NotStarted
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = 1
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = 0

            SendPlayerQuests(Index)
            PlayerMsg(Index, "Quest " & QuestNum & " reset!", ColorType.BrightRed)
        End If
    End Sub

    Public Function CanStartQuest(ByVal Index As Integer, ByVal QuestNum As Integer) As Boolean
        CanStartQuest = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function
        If QuestInProgress(Index, QuestNum) Then Exit Function

        'Check if player has the quest 0 (not started) or 3 (completed but it can be started again)
        If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.NotStarted Or Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.Repeatable Then
            For i = 1 To Quest(QuestNum).ReqCount
                'Check if item is needed
                If Quest(QuestNum).Requirement(i) = 1 Then
                    If Quest(QuestNum).RequirementIndex(i) > 0 And Quest(QuestNum).RequirementIndex(i) <= MAX_ITEMS Then
                        If HasItem(Index, Quest(QuestNum).RequirementIndex(i)) = 0 Then
                            PlayerMsg(Index, "You need " & Item(Quest(QuestNum).Requirement(2)).Name & " to take this quest!", ColorType.Yellow)
                            Exit Function
                        End If
                    End If
                End If

                'Check if previous quest is needed
                If Quest(QuestNum).Requirement(i) = 2 Then
                    If Quest(QuestNum).RequirementIndex(i) > 0 And Quest(QuestNum).RequirementIndex(i) <= MAX_QUESTS Then
                        If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(Quest(QuestNum).Requirement(2)).Status = QuestStatus.NotStarted Or Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(Quest(QuestNum).Requirement(2)).Status = QuestStatus.Started Then
                            PlayerMsg(Index, "You need to complete the " & Trim$(Quest(Quest(QuestNum).Requirement(2)).Name) & " quest in order to take this quest!", ColorType.Yellow)
                            Exit Function
                        End If
                    End If
                End If

            Next

            'Go on :)
            CanStartQuest = True
        Else
            'PlayerMsg Index, "You can't start that quest again!", BrightRed
        End If
    End Function

    Public Function CanEndQuest(ByVal Index As Integer, ByVal QuestNum As Integer) As Boolean
        CanEndQuest = False

        If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask >= Quest(QuestNum).Task.Length Then
            CanEndQuest = True
        End If
        If Quest(QuestNum).Task(Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask).QuestEnd = 1 Then
            CanEndQuest = True
        End If
    End Function

    'Tells if the quest is in progress or not
    Public Function QuestInProgress(ByVal Index As Integer, ByVal QuestNum As Integer) As Boolean
        QuestInProgress = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.Started Then 'Status=1 means started
            QuestInProgress = True
        End If
    End Function

    Public Function QuestCompleted(ByVal Index As Integer, ByVal QuestNum As Integer) As Boolean
        QuestCompleted = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = 2 Or Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = 3 Then
            QuestCompleted = True
        End If
    End Function

    'Gets the quest reference num (id) from the quest name (it shall be unique)
    Public Function GetQuestNum(ByVal QuestName As String) As Integer
        Dim I As Integer
        GetQuestNum = 0

        For I = 1 To MAX_QUESTS
            If Trim$(Quest(I).Name) = Trim$(QuestName) Then
                GetQuestNum = I
                Exit For
            End If
        Next
    End Function

    Public Function GetItemNum(ByVal ItemName As String) As Integer
        Dim I As Integer
        GetItemNum = 0

        For I = 1 To MAX_ITEMS
            If Trim$(Item(I).Name) = Trim$(ItemName) Then
                GetItemNum = I
                Exit For
            End If
        Next
    End Function

    ' /////////////////////
    ' // General Purpose //
    ' /////////////////////

    Public Sub CheckTasks(ByVal Index As Integer, ByVal TaskType As Integer, ByVal TargetIndex As Integer)
        Dim I As Integer

        For I = 1 To MAX_QUESTS
            If QuestInProgress(Index, I) Then
                CheckTask(Index, I, TaskType, TargetIndex)
            End If
        Next
    End Sub

    Public Sub CheckTask(ByVal Index As Integer, ByVal QuestNum As Integer, ByVal TaskType As Integer, ByVal TargetIndex As Integer)
        Dim ActualTask As Integer, I As Integer
        ActualTask = Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask

        If ActualTask >= Quest(QuestNum).Task.Length Then Exit Sub

        Select Case TaskType
            Case QuestType.Slay 'defeat X amount of X npc's.

                'is npc defeated id same as the npc i have to defeat?
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    'Count +1
                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                    'did i finish the work?
                    If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                        'is the quest's end?
                        If CanEndQuest(Index, QuestNum) Then
                            EndQuest(Index, QuestNum)
                        Else
                            'otherwise continue to the next task
                            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QuestType.Collect 'Gather X amount of X item.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).Item Then
                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                    If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                        If CanEndQuest(Index, QuestNum) Then
                            EndQuest(Index, QuestNum)
                        Else
                            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QuestType.Talk 'Interact with X npc.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC And Quest(QuestNum).Task(ActualTask).Amount = 0 Then
                    QuestMessage(Index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QuestType.Reach 'Reach X map.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).Map Then
                    QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QuestType.Give 'Give X amount of X item to X npc.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    For I = 1 To MAX_INV
                        If GetPlayerInvItemNum(Index, I) = Quest(QuestNum).Task(ActualTask).Item Then
                            If GetPlayerInvItemValue(Index, I) >= Quest(QuestNum).Task(ActualTask).Amount Then
                                TakeInvItem(Index, GetPlayerInvItemNum(Index, I), Quest(QuestNum).Task(ActualTask).Amount)
                                QuestMessage(Index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                                If CanEndQuest(Index, QuestNum) Then
                                    EndQuest(Index, QuestNum)
                                Else
                                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If

            Case QuestType.Kill 'Kill X amount of players.
                Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                    QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QuestType.Gather 'Hit X amount of times X resource.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).Resource Then
                    Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount = Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount + 1
                    If Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                        If CanEndQuest(Index, QuestNum) Then
                            EndQuest(Index, QuestNum)
                        Else
                            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QuestType.Fetch 'Get X amount of X item from X npc.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    GiveInvItem(Index, Quest(QuestNum).Task(ActualTask).Item, Quest(QuestNum).Task(ActualTask).Amount)
                    QuestMessage(Index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If
        End Select

        SendPlayerQuest(Index, QuestNum)
    End Sub

    Public Sub ShowQuest(ByVal Index As Integer, ByVal QuestNum As Integer)
        If QuestInProgress(Index, QuestNum) Then
            QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Chat(2)), 0) 'show meanwhile message
            Exit Sub
        End If
        If Not CanStartQuest(Index, QuestNum) Then Exit Sub

        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Chat(1)), QuestNum) 'chat 1 = request message
    End Sub

    Public Sub EndQuest(ByVal Index As Integer, ByVal QuestNum As Integer)
        Dim I As Integer

        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Chat(3)), 0)

        For I = 1 To Quest(QuestNum).RewardCount
            If Quest(QuestNum).RewardItem(I) > 0 Then
                PlayerMsg(Index, "You recieved " & Quest(QuestNum).RewardItemAmount(I) & " " & Trim(Item(Quest(QuestNum).RewardItem(I)).Name), ColorType.BrightGreen)
            End If
            GiveInvItem(Index, Quest(QuestNum).RewardItem(I), Quest(QuestNum).RewardItemAmount(I))
        Next

        If Quest(QuestNum).RewardExp > 0 Then
            SetPlayerExp(Index, GetPlayerExp(Index) + Quest(QuestNum).RewardExp)
            SendExp(Index)
            ' Check for level up
            CheckPlayerLevelUp(Index)
        End If

        'Check if quest is repeatable, set it as completed
        If Quest(QuestNum).Repeat = True Then
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.Repeatable
        Else
            Player(Index).Character(TempPlayer(Index).CurChar).PlayerQuest(QuestNum).Status = QuestStatus.Completed
        End If
        PlayerMsg(Index, Trim$(Quest(QuestNum).Name) & ": quest completed", ColorType.BrightGreen)

        SavePlayer(Index)
        SendPlayerData(Index)
        SendPlayerQuest(Index, QuestNum)
    End Sub
#End Region

End Module