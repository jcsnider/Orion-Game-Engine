Public Module ServerQuest
#Region "Constants"
    'Constants
    Public Const MAX_TASKS As Byte = 10
    Public Const MAX_QUESTS As Byte = 250
    Public Const EDITOR_TASKS As Byte = 7

    Public Const QUEST_TYPE_GOSLAY As Byte = 1
    Public Const QUEST_TYPE_GOGATHER As Byte = 2
    Public Const QUEST_TYPE_GOTALK As Byte = 3
    Public Const QUEST_TYPE_GOREACH As Byte = 4
    Public Const QUEST_TYPE_GOGIVE As Byte = 5
    Public Const QUEST_TYPE_GOKILL As Byte = 6
    Public Const QUEST_TYPE_GOTRAIN As Byte = 7
    Public Const QUEST_TYPE_GOGET As Byte = 8
    Public Const QUEST_TYPE_TALKEVENT As Byte = 9

    Public Const QUEST_NOT_STARTED As Byte = 0
    Public Const QUEST_STARTED As Byte = 1
    Public Const QUEST_COMPLETED As Byte = 2
    Public Const QUEST_COMPLETED_BUT As Byte = 3

    'Types
    Public Quest(0 To MAX_QUESTS) As QuestRec

    Public Structure PlayerQuestRec
        Dim Status As Long '0=not started, 1=started, 2=completed, 3=completed but repeatable
        Dim ActualTask As Long
        Dim CurrentCount As Long 'Used to handle the Amount property
    End Structure

    Public Structure TaskRec
        Dim Order As Long
        Dim NPC As Long
        Dim Item As Long
        Dim Map As Long
        Dim Resource As Long
        Dim Amount As Long
        Dim Speech As String
        Dim TaskLog As String
        Dim QuestEnd As Boolean
        Dim TaskType As Long
    End Structure

    Public Structure QuestRec
        Dim Name As String
        Dim QuestLog As String
        Dim TasksCount As Long 'todo
        Dim Repeat As Long

        Dim Requirement() As Long '1=item, 2=quest

        Dim StartItem As Long
        Dim StartItemValue As Long
        Dim StartRemoveItem As Long
        Dim StartRemoveItemValue As Long

        Dim Chat() As String

        Dim RewardItem As Long
        Dim RewardItemAmount As Long
        Dim RewardExp As Long

        Dim Task() As TaskRec
    End Structure
#End Region

#Region "Database"
    Sub SaveQuests()
        Dim I As Long
        For I = 1 To MAX_QUESTS
            Call SaveQuest(I)
            DoEvents()
        Next
    End Sub

    Sub SaveQuest(ByVal QuestNum As Long)
        Dim filename As String
        Dim F As Long, I As Long
        filename = Application.StartupPath & "\data\quests\quest" & QuestNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Quest(QuestNum).Name)
        FilePutObject(F, Quest(QuestNum).QuestLog)
        FilePutObject(F, Quest(QuestNum).TasksCount)
        FilePutObject(F, Quest(QuestNum).Repeat)

        For I = 1 To 3
            FilePutObject(F, Quest(QuestNum).Requirement(I))
        Next

        FilePutObject(F, Quest(QuestNum).StartItem)
        FilePutObject(F, Quest(QuestNum).StartItemValue)
        FilePutObject(F, Quest(QuestNum).StartRemoveItem)
        FilePutObject(F, Quest(QuestNum).StartRemoveItemValue)

        For I = 1 To 3
            FilePutObject(F, Quest(QuestNum).Chat(I))
        Next

        FilePutObject(F, Quest(QuestNum).RewardItem)
        FilePutObject(F, Quest(QuestNum).RewardItemAmount)
        FilePutObject(F, Quest(QuestNum).RewardExp)

        For I = 1 To MAX_TASKS
            FilePutObject(F, Quest(QuestNum).Task(I).Order)
            FilePutObject(F, Quest(QuestNum).Task(I).NPC)
            FilePutObject(F, Quest(QuestNum).Task(I).Item)
            FilePutObject(F, Quest(QuestNum).Task(I).Map)
            FilePutObject(F, Quest(QuestNum).Task(I).Resource)
            FilePutObject(F, Quest(QuestNum).Task(I).Amount)
            FilePutObject(F, Quest(QuestNum).Task(I).Speech)
            FilePutObject(F, Quest(QuestNum).Task(I).TaskLog)
            FilePutObject(F, Quest(QuestNum).Task(I).QuestEnd)
            FilePutObject(F, Quest(QuestNum).Task(I).TaskType)
        Next

        FileClose(F)
    End Sub

    Sub LoadQuests()
        Dim I As Long

        Call CheckQuests()

        For I = 1 To MAX_QUESTS
            LoadQuest(I)
            DoEvents()
        Next
    End Sub

    Sub LoadQuest(ByVal QuestNum As Long)
        Dim FileName As String
        Dim F As Long, n As Long

        FileName = Application.StartupPath & "\data\quests\quest" & QuestNum & ".dat"
        F = FreeFile()
        FileOpen(F, FileName, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Quest(QuestNum).Name)
        FileGetObject(F, Quest(QuestNum).QuestLog)
        FileGetObject(F, Quest(QuestNum).TasksCount)
        FileGetObject(F, Quest(QuestNum).Repeat)

        For n = 1 To 3
            FileGetObject(F, Quest(QuestNum).Requirement(n))
        Next

        FileGetObject(F, Quest(QuestNum).StartItem)
        FileGetObject(F, Quest(QuestNum).StartItemValue)
        FileGetObject(F, Quest(QuestNum).StartRemoveItem)
        FileGetObject(F, Quest(QuestNum).StartRemoveItemValue)

        For n = 1 To 3
            FileGetObject(F, Quest(QuestNum).Chat(n))
        Next

        FileGetObject(F, Quest(QuestNum).RewardItem)
        FileGetObject(F, Quest(QuestNum).RewardItemAmount)
        FileGetObject(F, Quest(QuestNum).RewardExp)

        For n = 1 To MAX_TASKS
            FileGetObject(F, Quest(QuestNum).Task(n).Order)
            FileGetObject(F, Quest(QuestNum).Task(n).NPC)
            FileGetObject(F, Quest(QuestNum).Task(n).Item)
            FileGetObject(F, Quest(QuestNum).Task(n).Map)
            FileGetObject(F, Quest(QuestNum).Task(n).Resource)
            FileGetObject(F, Quest(QuestNum).Task(n).Amount)
            FileGetObject(F, Quest(QuestNum).Task(n).Speech)
            FileGetObject(F, Quest(QuestNum).Task(n).TaskLog)
            FileGetObject(F, Quest(QuestNum).Task(n).QuestEnd)
            FileGetObject(F, Quest(QuestNum).Task(n).TaskType)
        Next

        FileClose(F)
    End Sub

    Sub CheckQuests()
        Dim I As Long
        For I = 1 To MAX_QUESTS
            If Not FileExist(Application.StartupPath & "\Data\quests\quest" & I & ".dat") Then
                Call SaveQuest(I)
                DoEvents()
            End If
        Next
    End Sub

    Sub ClearQuest(ByVal QuestNum As Long)
        Dim I As Long

        ' clear the Quest
        Quest(QuestNum).Name = vbNullString
        Quest(QuestNum).QuestLog = vbNullString
        Quest(QuestNum).TasksCount = 0
        Quest(QuestNum).Repeat = 0

        For I = 1 To 3
            Quest(QuestNum).Requirement(I) = 0
        Next

        Quest(QuestNum).StartItem = 0
        Quest(QuestNum).StartItemValue = 0
        Quest(QuestNum).StartRemoveItem = 0
        Quest(QuestNum).StartRemoveItemValue = 0

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = vbNullString
        Next

        Quest(QuestNum).RewardItem = 0
        Quest(QuestNum).RewardItemAmount = 0
        Quest(QuestNum).RewardExp = 0

        For I = 1 To MAX_TASKS
            Quest(QuestNum).Task(I).Order = 0
            Quest(QuestNum).Task(I).NPC = 0
            Quest(QuestNum).Task(I).Item = 0
            Quest(QuestNum).Task(I).Map = 0
            Quest(QuestNum).Task(I).Resource = 0
            Quest(QuestNum).Task(I).Amount = 0
            Quest(QuestNum).Task(I).Speech = vbNullString
            Quest(QuestNum).Task(I).TaskLog = vbNullString
            Quest(QuestNum).Task(I).QuestEnd = 0
            Quest(QuestNum).Task(I).TaskType = 0
        Next

    End Sub

    Sub ClearQuests()
        Dim I As Long

        For I = 1 To MAX_QUESTS
            Call ClearQuest(I)
            DoEvents()
        Next
    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_RequestEditQuest(ByVal Index As Long, ByVal Data() As Byte)

        Dim Buffer As ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_DEVELOPER Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SQuestEditor)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub Packet_SaveQuest(ByVal Index As Long, ByVal Data() As Byte)
        Dim QuestNum As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CSaveQuest Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_DEVELOPER Then Exit Sub

        QuestNum = Buffer.ReadLong
        If QuestNum < 0 Or QuestNum > MAX_QUESTS Then
            Exit Sub
        End If

        ' Update the Quest
        Quest(QuestNum).Name = Buffer.ReadString
        Quest(QuestNum).QuestLog = Buffer.ReadString
        Quest(QuestNum).TasksCount = Buffer.ReadLong
        Quest(QuestNum).Repeat = Buffer.ReadLong

        For I = 1 To 3
            Quest(QuestNum).Requirement(I) = Buffer.ReadLong
        Next

        Quest(QuestNum).StartItem = Buffer.ReadLong
        Quest(QuestNum).StartItemValue = Buffer.ReadLong
        Quest(QuestNum).StartRemoveItem = Buffer.ReadLong
        Quest(QuestNum).StartRemoveItemValue = Buffer.ReadLong

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = Buffer.ReadString
        Next

        Quest(QuestNum).RewardItem = Buffer.ReadLong
        Quest(QuestNum).RewardItemAmount = Buffer.ReadLong
        Quest(QuestNum).RewardExp = Buffer.ReadLong

        For I = 1 To MAX_TASKS
            Quest(QuestNum).Task(I).Order = Buffer.ReadLong
            Quest(QuestNum).Task(I).NPC = Buffer.ReadLong
            Quest(QuestNum).Task(I).Item = Buffer.ReadLong
            Quest(QuestNum).Task(I).Map = Buffer.ReadLong
            Quest(QuestNum).Task(I).Resource = Buffer.ReadLong
            Quest(QuestNum).Task(I).Amount = Buffer.ReadLong
            Quest(QuestNum).Task(I).Speech = Buffer.ReadString
            Quest(QuestNum).Task(I).TaskLog = Buffer.ReadString
            Quest(QuestNum).Task(I).QuestEnd = Buffer.ReadLong
            Quest(QuestNum).Task(I).TaskType = Buffer.ReadLong
        Next

        Buffer = Nothing

        ' Save it
        Call SendUpdateQuestToAll(QuestNum)
        Call SaveQuest(QuestNum)
        Call Addlog(GetPlayerName(Index) & " saved Quest #" & QuestNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_RequestQuests(ByVal Index As Long, ByVal Data() As Byte)
        SendQuests(Index)
    End Sub

    Sub Packet_PlayerHandleQuest(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim QuestNum As Long, Order As Long ', I As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CPlayerHandleQuest Then Exit Sub

        QuestNum = Buffer.ReadLong
        Order = Buffer.ReadLong '1 = accept, 2 = cancel

        If Order = 1 Then
            Player(Index).PlayerQuest(QuestNum).Status = QUEST_STARTED '1
            Player(Index).PlayerQuest(QuestNum).ActualTask = 1
            Player(Index).PlayerQuest(QuestNum).CurrentCount = 0
            PlayerMsg(Index, "New quest accepted: " & Trim$(Quest(QuestNum).Name) & "!")
        ElseIf Order = 2 Then
            Player(Index).PlayerQuest(QuestNum).Status = QUEST_NOT_STARTED '2
            Player(Index).PlayerQuest(QuestNum).ActualTask = 1
            Player(Index).PlayerQuest(QuestNum).CurrentCount = 0

            PlayerMsg(Index, Trim$(Quest(QuestNum).Name) & " has been canceled!")

            If GetPlayerAccess(Index) > 0 And QuestNum = 1 Then
                For I = 1 To MAX_QUESTS
                    Player(Index).PlayerQuest(I).Status = QUEST_NOT_STARTED '2
                    Player(Index).PlayerQuest(I).ActualTask = 1
                    Player(Index).PlayerQuest(I).CurrentCount = 0
                Next
            End If
        End If

        SavePlayer(Index)
        SendPlayerData(Index)
        SendPlayerQuests(Index)
        Buffer = Nothing
    End Sub

    Sub Packet_QuestLogUpdate(ByVal Index As Long, ByVal Data() As Byte)
        SendPlayerQuests(Index)
    End Sub

    Sub Packet_QuestReset(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim QuestNum As Long

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CQuestReset Then Exit Sub

        QuestNum = Buffer.ReadLong

        ResetQuest(Index, QuestNum)

        Buffer = Nothing
    End Sub
#End Region

#Region "Outgoing packets"
    Sub SendQuests(ByVal Index As Long)
        Dim I As Long

        For I = 1 To MAX_QUESTS
            If Len(Trim$(Quest(I).Name)) > 0 Then
                Call SendUpdateQuestTo(Index, I)
            End If
        Next
    End Sub

    Sub SendUpdateQuestToAll(ByVal QuestNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateQuest)
        Buffer.WriteLong(QuestNum)

        Buffer.WriteString(Trim(Quest(QuestNum).Name))
        Buffer.WriteString(Trim(Quest(QuestNum).QuestLog))
        Buffer.WriteLong(Quest(QuestNum).TasksCount)
        Buffer.WriteLong(Quest(QuestNum).Repeat)

        For I = 1 To 3
            Buffer.WriteLong(Quest(QuestNum).Requirement(I))
        Next

        Buffer.WriteLong(Quest(QuestNum).StartItem)
        Buffer.WriteLong(Quest(QuestNum).StartItemValue)
        Buffer.WriteLong(Quest(QuestNum).StartRemoveItem)
        Buffer.WriteLong(Quest(QuestNum).StartRemoveItemValue)

        For I = 1 To 3
            Buffer.WriteString(Trim(Quest(QuestNum).Chat(I)))
        Next

        Buffer.WriteLong(Quest(QuestNum).RewardItem)
        Buffer.WriteLong(Quest(QuestNum).RewardItemAmount)
        Buffer.WriteLong(Quest(QuestNum).RewardExp)

        For I = 1 To MAX_TASKS
            Buffer.WriteLong(Quest(QuestNum).Task(I).Order)
            Buffer.WriteLong(Quest(QuestNum).Task(I).NPC)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Item)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Map)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Resource)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Amount)
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).Speech))
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).TaskLog))
            Buffer.WriteLong(Quest(QuestNum).Task(I).QuestEnd)
            Buffer.WriteLong(Quest(QuestNum).Task(I).TaskType)
        Next

        SendDataToAll(Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub SendUpdateQuestTo(ByVal Index As Long, ByVal QuestNum As Long)
        Dim Buffer As ByteBuffer, I As Long
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateQuest)
        Buffer.WriteLong(QuestNum)

        Buffer.WriteString(Trim(Quest(QuestNum).Name))
        Buffer.WriteString(Trim(Quest(QuestNum).QuestLog))
        Buffer.WriteLong(Quest(QuestNum).TasksCount)
        Buffer.WriteLong(Quest(QuestNum).Repeat)

        For I = 1 To 3
            Buffer.WriteLong(Quest(QuestNum).Requirement(I))
        Next

        Buffer.WriteLong(Quest(QuestNum).StartItem)
        Buffer.WriteLong(Quest(QuestNum).StartItemValue)
        Buffer.WriteLong(Quest(QuestNum).StartRemoveItem)
        Buffer.WriteLong(Quest(QuestNum).StartRemoveItemValue)

        For I = 1 To 3
            Buffer.WriteString(Trim(Quest(QuestNum).Chat(I)))
        Next

        Buffer.WriteLong(Quest(QuestNum).RewardItem)
        Buffer.WriteLong(Quest(QuestNum).RewardItemAmount)
        Buffer.WriteLong(Quest(QuestNum).RewardExp)

        For I = 1 To MAX_TASKS
            Buffer.WriteLong(Quest(QuestNum).Task(I).Order)
            Buffer.WriteLong(Quest(QuestNum).Task(I).NPC)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Item)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Map)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Resource)
            Buffer.WriteLong(Quest(QuestNum).Task(I).Amount)
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).Speech))
            Buffer.WriteString(Trim(Quest(QuestNum).Task(I).TaskLog))
            Buffer.WriteLong(Quest(QuestNum).Task(I).QuestEnd)
            Buffer.WriteLong(Quest(QuestNum).Task(I).TaskType)
        Next

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerQuests(ByVal Index As Long)
        Dim I As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SPlayerQuests)

        For I = 1 To MAX_QUESTS
            Buffer.WriteLong(Player(Index).PlayerQuest(I).Status)
            Buffer.WriteLong(Player(Index).PlayerQuest(I).ActualTask)
            Buffer.WriteLong(Player(Index).PlayerQuest(I).CurrentCount)
        Next

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Public Sub SendPlayerQuest(ByVal Index As Long, ByVal QuestNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SPlayerQuest)
        Buffer.WriteLong(QuestNum)
        Buffer.WriteLong(Player(Index).PlayerQuest(QuestNum).Status)
        Buffer.WriteLong(Player(Index).PlayerQuest(QuestNum).ActualTask)
        Buffer.WriteLong(Player(Index).PlayerQuest(QuestNum).CurrentCount)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    'sends a message to the client that is shown on the screen
    Public Sub QuestMessage(ByVal Index As Long, ByVal QuestNum As Long, ByVal message As String, ByVal QuestNumForStart As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SQuestMessage)
        Buffer.WriteLong(QuestNum)
        Buffer.WriteString(Trim$(message))
        Buffer.WriteLong(QuestNumForStart)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub
#End Region

#Region "Functions"

    Public Sub ResetQuest(ByVal Index As Long, ByVal QuestNum As Long)
        If GetPlayerAccess(Index) > 0 Then
            Player(Index).PlayerQuest(QuestNum).Status = QUEST_NOT_STARTED
            Player(Index).PlayerQuest(QuestNum).ActualTask = 1
            Player(Index).PlayerQuest(QuestNum).CurrentCount = 0

            SendPlayerQuests(Index)
            Call PlayerMsg(Index, "Quest " & QuestNum & " reset!")
        End If
    End Sub

    Public Function CanStartQuest(ByVal Index As Long, ByVal QuestNum As Long) As Boolean
        CanStartQuest = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function
        If QuestInProgress(Index, QuestNum) Then Exit Function

        'Check if player has the quest 0 (not started) or 3 (completed but it can be started again)
        If Player(Index).PlayerQuest(QuestNum).Status = QUEST_NOT_STARTED Or Player(Index).PlayerQuest(QuestNum).Status = QUEST_COMPLETED_BUT Then
            'Check if item is needed
            If Quest(QuestNum).Requirement(1) > 0 And Quest(QuestNum).Requirement(1) <= MAX_ITEMS Then
                If HasItem(Index, Quest(QuestNum).Requirement(2)) = 0 Then
                    PlayerMsg(Index, "You need " & Item(Quest(QuestNum).Requirement(2)).Name & " to take this quest!")
                    Exit Function
                End If
            End If
            'Check if previous quest is needed
            'Debug.Print(Quest(QuestNum).Requirement(2))
            If Quest(QuestNum).Requirement(2) > 0 And Quest(QuestNum).Requirement(2) <= MAX_QUESTS Then
                If Player(Index).PlayerQuest(Quest(QuestNum).Requirement(2)).Status = QUEST_NOT_STARTED Or Player(Index).PlayerQuest(Quest(QuestNum).Requirement(2)).Status = QUEST_STARTED Then
                    PlayerMsg(Index, "You need to complete the " & Trim$(Quest(Quest(QuestNum).Requirement(2)).Name) & " quest in order to take this quest!")
                    Exit Function
                End If
            End If
            'Go on :)
            CanStartQuest = True
        Else
            'PlayerMsg Index, "You can't start that quest again!", BrightRed
        End If
    End Function

    Public Function CanEndQuest(ByVal Index As Long, QuestNum As Long) As Boolean
        CanEndQuest = False
        If Quest(QuestNum).Task(Player(Index).PlayerQuest(QuestNum).ActualTask).QuestEnd = True Then
            CanEndQuest = True
        End If
    End Function

    'Tells if the quest is in progress or not
    Public Function QuestInProgress(ByVal Index As Long, ByVal QuestNum As Long) As Boolean
        QuestInProgress = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(Index).PlayerQuest(QuestNum).Status = QUEST_STARTED Then 'Status=1 means started
            QuestInProgress = True
        End If
    End Function

    Public Function QuestCompleted(ByVal Index As Long, ByVal QuestNum As Long) As Boolean
        QuestCompleted = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(Index).PlayerQuest(QuestNum).Status = 2 Or Player(Index).PlayerQuest(QuestNum).Status = 3 Then
            QuestCompleted = True
        End If
    End Function

    'Gets the quest reference num (id) from the quest name (it shall be unique)
    Public Function GetQuestNum(ByVal QuestName As String) As Long
        Dim I As Long
        GetQuestNum = 0

        For I = 1 To MAX_QUESTS
            If Trim$(Quest(I).Name) = Trim$(QuestName) Then
                GetQuestNum = I
                Exit For
            End If
        Next
    End Function

    Public Function GetItemNum(ByVal ItemName As String) As Long
        Dim I As Long
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

    Public Sub CheckTasks(ByVal Index As Long, ByVal TaskType As Long, ByVal TargetIndex As Long)
        Dim I As Long

        For I = 1 To MAX_QUESTS
            If QuestInProgress(Index, I) Then
                Call CheckTask(Index, I, TaskType, TargetIndex)
            End If
        Next
    End Sub

    Public Sub CheckTask(ByVal Index As Long, ByVal QuestNum As Long, ByVal TaskType As Long, ByVal TargetIndex As Long)
        Dim ActualTask As Long, I As Long
        ActualTask = Player(Index).PlayerQuest(QuestNum).ActualTask

        'PlayerMsg Index, "actual tasknr: " & ActualTask, Yellow

        Select Case TaskType
            Case QUEST_TYPE_GOSLAY 'defeat X amount of X poke's.

                'is poke defeated id same as the poke i have to defeat?
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    'Count +1
                    Player(Index).PlayerQuest(QuestNum).CurrentCount = Player(Index).PlayerQuest(QuestNum).CurrentCount + 1
                    'did i finish the work?
                    If Player(Index).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                        'is the quest's end?
                        If CanEndQuest(Index, QuestNum) Then
                            EndQuest(Index, QuestNum)
                        Else
                            'otherwise continue to the next task
                            Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QUEST_TYPE_GOGATHER 'Gather X amount of X item.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).Item Then
                    Player(Index).PlayerQuest(QuestNum).CurrentCount = Player(Index).PlayerQuest(QuestNum).CurrentCount + 1
                    If Player(Index).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                        If CanEndQuest(Index, QuestNum) Then
                            EndQuest(Index, QuestNum)
                        Else
                            Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QUEST_TYPE_GOTALK 'Interact with X npc.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    QuestMessage(Index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QUEST_TYPE_GOREACH 'Reach X map.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).Map Then
                    QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QUEST_TYPE_GOGIVE 'Give X amount of X item to X npc.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    For I = 1 To MAX_INV
                        If GetPlayerInvItemNum(Index, I) = Quest(QuestNum).Task(ActualTask).Item Then
                            If GetPlayerInvItemValue(Index, I) >= Quest(QuestNum).Task(ActualTask).Amount Then
                                TakeInvItem(Index, I, Quest(QuestNum).Task(ActualTask).Amount)
                                QuestMessage(Index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                                If CanEndQuest(Index, QuestNum) Then
                                    EndQuest(Index, QuestNum)
                                Else
                                    Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If

            Case QUEST_TYPE_GOKILL 'Kill X amount of players.
                Player(Index).PlayerQuest(QuestNum).CurrentCount = Player(Index).PlayerQuest(QuestNum).CurrentCount + 1
                If Player(Index).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                    QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If

            Case QUEST_TYPE_GOTRAIN 'Hit X amount of times X resource.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).Resource Then
                    Player(Index).PlayerQuest(QuestNum).CurrentCount = Player(Index).PlayerQuest(QuestNum).CurrentCount + 1
                    If Player(Index).PlayerQuest(QuestNum).CurrentCount >= Quest(QuestNum).Task(ActualTask).Amount Then
                        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Task(ActualTask).TaskLog) & " - Task completed", 0)
                        If CanEndQuest(Index, QuestNum) Then
                            EndQuest(Index, QuestNum)
                        Else
                            Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                        End If
                    End If
                End If

            Case QUEST_TYPE_GOGET 'Get X amount of X item from X npc.
                If TargetIndex = Quest(QuestNum).Task(ActualTask).NPC Then
                    GiveInvItem(Index, Quest(QuestNum).Task(ActualTask).Item, Quest(QuestNum).Task(ActualTask).Amount)
                    QuestMessage(Index, QuestNum, Quest(QuestNum).Task(ActualTask).Speech, 0)
                    If CanEndQuest(Index, QuestNum) Then
                        EndQuest(Index, QuestNum)
                    Else
                        Player(Index).PlayerQuest(QuestNum).ActualTask = ActualTask + 1
                    End If
                End If
        End Select

        SendPlayerQuest(Index, QuestNum)
    End Sub

    Public Sub ShowQuest(ByVal Index As Long, ByVal QuestNum As Long)
        If QuestInProgress(Index, QuestNum) Then
            QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Chat(2)), 0) 'show meanwhile message
            Exit Sub
        End If
        If Not CanStartQuest(Index, QuestNum) Then Exit Sub

        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Chat(1)), QuestNum) 'chat 1 = request message
    End Sub

    Public Sub EndQuest(ByVal Index As Long, ByVal QuestNum As Long)
        QuestMessage(Index, QuestNum, Trim$(Quest(QuestNum).Chat(3)), 0)
        If Quest(QuestNum).RewardItem > 0 Then
            PlayerMsg(Index, "You recieved " & Quest(QuestNum).RewardItemAmount & " " & Trim(Item(Quest(QuestNum).RewardItem).Name))
        End If
        GiveInvItem(Index, Quest(QuestNum).RewardItem, Quest(QuestNum).RewardItemAmount)

        If Quest(QuestNum).RewardExp > 0 Then
            SetPlayerExp(Index, GetPlayerExp(Index) + Quest(QuestNum).RewardExp)
            SendEXP(Index)
            ' Check for level up
            CheckPlayerLevelUp(Index)
        End If

        'Check if quest is repeatable, set it as completed
        If Quest(QuestNum).Repeat = YES Then
            Player(Index).PlayerQuest(QuestNum).Status = QUEST_COMPLETED_BUT
        Else
            Player(Index).PlayerQuest(QuestNum).Status = QUEST_COMPLETED
        End If
        PlayerMsg(Index, Trim$(Quest(QuestNum).Name) & ": quest completed")

        SavePlayer(Index)
        SendPlayerData(Index)
        SendPlayerQuest(Index, QuestNum)
    End Sub
#End Region

End Module
