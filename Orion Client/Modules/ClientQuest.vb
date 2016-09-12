Public Module ClientQuest
#Region "Global Info"
    'Constants
    Public Const MAX_QUESTS As Byte = 250
    Public Const MAX_TASKS As Byte = 10
    Public Const EDITOR_TASKS As Byte = 7

    Public Const QUEST_TYPE_GOSLAY As Byte = 1
    Public Const QUEST_TYPE_GOGATHER As Byte = 2
    Public Const QUEST_TYPE_GOTALK As Byte = 3
    Public Const QUEST_TYPE_GOREACH As Byte = 4
    Public Const QUEST_TYPE_GOGIVE As Byte = 5
    Public Const QUEST_TYPE_GOKILL As Byte = 6
    Public Const QUEST_TYPE_GOTRAIN As Byte = 7
    Public Const QUEST_TYPE_GOGET As Byte = 8

    Public Const QUEST_NOT_STARTED As Byte = 0
    Public Const QUEST_STARTED As Byte = 1
    Public Const QUEST_COMPLETED As Byte = 2
    Public Const QUEST_COMPLETED_BUT As Byte = 3

    Public QuestLogPage As Long
    Public QuestNames(MAX_ACTIVEQUESTS) As String

    Public Quest_Changed(MAX_QUESTS) As Boolean

    Public QuestEditorShow As Boolean

    'questlog variables

    Public Const MAX_ACTIVEQUESTS = 10

    Public QuestLogX As Long = 150
    Public QuestLogY As Long = 100

    Public pnlQuestLogVisible As Boolean
    Public SelectedQuest As String
    Public QuestTaskLogText As String = ""
    Public ActualTaskText As String = ""
    Public QuestDialogText As String = ""
    Public QuestStatus2Text As String = ""
    Public AbandonQuestText As String = ""
    Public AbandonQuestVisible As Boolean
    Public QuestRequirementsText As String = ""
    Public QuestRewardsText As String = ""

    'here we store temp info because off UpdateUI >.<
    Public UpdateQuestWindow As Boolean
    Public UpdateQuestChat As Boolean
    Public QuestNum As Long
    Public QuestNumForStart As Long
    Public QuestMessage As String
    Public QuestAcceptTag As Long

    'Types
    Public Quest(0 To MAX_QUESTS) As QuestRec

    Public Structure PlayerQuestRec
        Dim Status As Long '0=not started, 1=started, 2=completed, 3=completed but repeatable
        Dim ActualTask As Long
        Dim CurrentCount As Long 'Used to handle the Amount property
    End Structure

    Public Structure TaskRec
        Dim Order As Long
        Dim Npc As Long
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

        Dim QuestGiveItem As Long 'Todo: make this dynamic
        Dim QuestGiveItemValue As Long
        Dim QuestRemoveItem As Long
        Dim QuestRemoveItemValue As Long

        Dim Chat() As String

        Dim RewardItem As Long 'ToDo: make this dynamic
        Dim RewardItemAmount As Long
        Dim RewardExp As Long

        Dim Task() As TaskRec

    End Structure
#End Region

#Region "Quest Editor"
    Public Sub QuestEditorInit()

        If frmEditor_Quest.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Quest.lstIndex.SelectedIndex + 1

        With frmEditor_Quest
            .txtName.Text = Trim$(Quest(EditorIndex).Name)
            .txtQuestLog.Text = Trim$(Quest(EditorIndex).QuestLog)

            If Quest(EditorIndex).Repeat = 1 Then
                .chkRepeat.Checked = 1
            Else
                .chkRepeat.Checked = 0
            End If

            .scrlItemRec.Value = Quest(EditorIndex).Requirement(1)
            .scrlQuestRec.Value = Quest(EditorIndex).Requirement(2)

            .txtStartText.Text = Trim$(Quest(EditorIndex).Chat(1))
            .txtProgressText.Text = Trim$(Quest(EditorIndex).Chat(2))
            .txtEndText.Text = Trim$(Quest(EditorIndex).Chat(3))

            .scrlStartItemName.Value = Quest(EditorIndex).QuestGiveItem
            .scrlEndItemName.Value = Quest(EditorIndex).QuestRemoveItem

            If Not Quest(EditorIndex).QuestGiveItemValue = 0 Then
                .scrlStartItemAmount.Value = Quest(EditorIndex).QuestGiveItemValue
            Else
                .scrlStartItemAmount.Value = 1
            End If

            If Not Quest(EditorIndex).QuestRemoveItemValue = 0 Then
                .scrlEndItemAmount.Value = Quest(EditorIndex).QuestRemoveItemValue
            Else
                .scrlEndItemAmount.Value = 1
            End If

            .scrlItemRew1.Value = Quest(EditorIndex).RewardItem

            If Not Quest(EditorIndex).RewardItemAmount = 0 Then
                .scrlItemRew1.Value = Quest(EditorIndex).RewardItemAmount
            Else
                .scrlItemRew1.Value = 1
            End If

            If Not Quest(EditorIndex).RewardExp = 0 Then
                .scrlExpReward.Value = Quest(EditorIndex).RewardExp
            Else
                .scrlExpReward.Value = 1
            End If


            'load task nº1
            .scrlTotalTasks.Value = 1
            LoadTask(EditorIndex, 1)

        End With

        'frmEditor_Quest.lstIndex.SelectedIndex = 0
        Quest_Changed(EditorIndex) = True

    End Sub

    Public Sub QuestEditorOk()
        Dim I As Long

        For I = 1 To MAX_QUESTS
            If Quest_Changed(I) Then
                Call SendSaveQuest(I)
            End If
        Next

        frmEditor_Quest.Dispose()
        Editor = 0
        ClearChanged_Quest()

    End Sub

    Public Sub QuestEditorCancel()
        Editor = 0
        frmEditor_Quest.Dispose()
        ClearChanged_Quest()
        ClearQuests()
        SendRequestQuests()
    End Sub

    Public Sub ClearChanged_Quest()
        Dim I As Long

        For I = 0 To MAX_QUESTS
            Quest_Changed(I) = False
        Next
    End Sub
#End Region

#Region "DataBase"
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

        Quest(QuestNum).QuestGiveItem = 0
        Quest(QuestNum).QuestGiveItemValue = 0
        Quest(QuestNum).QuestRemoveItem = 0
        Quest(QuestNum).QuestRemoveItemValue = 0

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = vbNullString
        Next

        Quest(QuestNum).RewardItem = 0
        Quest(QuestNum).RewardItemAmount = 0
        Quest(QuestNum).RewardExp = 0

        For I = 1 To MAX_TASKS
            Quest(QuestNum).Task(I).Order = 0
            Quest(QuestNum).Task(I).Npc = 0
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
        Next
    End Sub
#End Region

#Region "Incoming Packets"
    Public Sub Packet_QuestEditor(ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SQuestEditor Then Exit Sub

        QuestEditorShow = True

        buffer = Nothing
    End Sub

    Public Sub Packet_UpdateQuest(ByVal data() As Byte)
        Dim QuestNum As Long
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SUpdateQuest Then Exit Sub

        QuestNum = buffer.ReadLong

        ' Update the Quest
        Quest(QuestNum).Name = buffer.ReadString
        Quest(QuestNum).QuestLog = buffer.ReadString
        Quest(QuestNum).TasksCount = buffer.ReadLong
        Quest(QuestNum).Repeat = buffer.ReadLong

        For I = 1 To 3
            Quest(QuestNum).Requirement(I) = buffer.ReadLong
        Next

        Quest(QuestNum).QuestGiveItem = buffer.ReadLong
        Quest(QuestNum).QuestGiveItemValue = buffer.ReadLong
        Quest(QuestNum).QuestRemoveItem = buffer.ReadLong
        Quest(QuestNum).QuestRemoveItemValue = buffer.ReadLong

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = buffer.ReadString
        Next

        Quest(QuestNum).RewardItem = buffer.ReadLong
        Quest(QuestNum).RewardItemAmount = buffer.ReadLong
        Quest(QuestNum).RewardExp = buffer.ReadLong

        For I = 1 To MAX_TASKS
            Quest(QuestNum).Task(I).Order = buffer.ReadLong
            Quest(QuestNum).Task(I).Npc = buffer.ReadLong
            Quest(QuestNum).Task(I).Item = buffer.ReadLong
            Quest(QuestNum).Task(I).Map = buffer.ReadLong
            Quest(QuestNum).Task(I).Resource = buffer.ReadLong
            Quest(QuestNum).Task(I).Amount = buffer.ReadLong
            Quest(QuestNum).Task(I).Speech = buffer.ReadString
            Quest(QuestNum).Task(I).TaskLog = buffer.ReadString
            Quest(QuestNum).Task(I).QuestEnd = buffer.ReadLong
            Quest(QuestNum).Task(I).TaskType = buffer.ReadLong
        Next

        buffer = Nothing
    End Sub

    Public Sub Packet_PlayerQuest(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim QuestNum As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SPlayerQuest Then Exit Sub

        QuestNum = buffer.ReadLong

        Player(MyIndex).PlayerQuest(QuestNum).Status = buffer.ReadLong
        Player(MyIndex).PlayerQuest(QuestNum).ActualTask = buffer.ReadLong
        Player(MyIndex).PlayerQuest(QuestNum).CurrentCount = buffer.ReadLong

        RefreshQuestLog()

        buffer = Nothing
    End Sub

    Public Sub Packet_PlayerQuests(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim I As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SPlayerQuests Then Exit Sub

        For I = 1 To MAX_QUESTS
            Player(MyIndex).PlayerQuest(I).Status = buffer.ReadLong
            Player(MyIndex).PlayerQuest(I).ActualTask = buffer.ReadLong
            Player(MyIndex).PlayerQuest(I).CurrentCount = buffer.ReadLong
        Next

        RefreshQuestLog()

        buffer = Nothing
    End Sub

    Public Sub Packet_QuestMessage(ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SQuestMessage Then Exit Sub

        QuestNum = buffer.ReadLong
        QuestMessage = Trim$(buffer.ReadString)
        QuestMessage = QuestMessage.Replace("$playername$", GetPlayerName(MyIndex))
        QuestNumForStart = buffer.ReadLong

        UpdateQuestChat = True

        buffer = Nothing
    End Sub
#End Region

#Region "Outgoing Packets"
    Public Sub SendRequestEditQuest()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CRequestEditQuest)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub SendSaveQuest(ByVal QuestNum As Long)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CSaveQuest)
        buffer.WriteLong(QuestNum)

        buffer.WriteString(Trim(Quest(QuestNum).Name))
        buffer.WriteString(Trim(Quest(QuestNum).QuestLog))
        buffer.WriteLong(Quest(QuestNum).TasksCount)
        buffer.WriteLong(Quest(QuestNum).Repeat)

        For I = 1 To 3
            buffer.WriteLong(Quest(QuestNum).Requirement(I))
        Next

        buffer.WriteLong(Quest(QuestNum).QuestGiveItem)
        buffer.WriteLong(Quest(QuestNum).QuestGiveItemValue)
        buffer.WriteLong(Quest(QuestNum).QuestRemoveItem)
        buffer.WriteLong(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            buffer.WriteString(Trim(Quest(QuestNum).Chat(I)))
        Next

        buffer.WriteLong(Quest(QuestNum).RewardItem)
        buffer.WriteLong(Quest(QuestNum).RewardItemAmount)
        buffer.WriteLong(Quest(QuestNum).RewardExp)

        For I = 1 To MAX_TASKS
            buffer.WriteLong(Quest(QuestNum).Task(I).Order)
            buffer.WriteLong(Quest(QuestNum).Task(I).Npc)
            buffer.WriteLong(Quest(QuestNum).Task(I).Item)
            buffer.WriteLong(Quest(QuestNum).Task(I).Map)
            buffer.WriteLong(Quest(QuestNum).Task(I).Resource)
            buffer.WriteLong(Quest(QuestNum).Task(I).Amount)
            buffer.WriteString(Trim(Quest(QuestNum).Task(I).Speech))
            buffer.WriteString(Trim(Quest(QuestNum).Task(I).TaskLog))
            buffer.WriteLong(Quest(QuestNum).Task(I).QuestEnd)
            buffer.WriteLong(Quest(QuestNum).Task(I).TaskType)
        Next

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Sub SendRequestQuests()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CRequestQuests)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub UpdateQuestLog()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CQuestLogUpdate)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub PlayerHandleQuest(ByVal QuestNum As Long, ByVal Order As Long)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CPlayerHandleQuest)
        buffer.WriteLong(QuestNum)
        buffer.WriteLong(Order) '1=accept quest, 2=cancel quest
        SendData(buffer.ToArray)
        buffer = Nothing
    End Sub

    Public Sub QuestReset(ByVal QuestNum As Long)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CQuestReset)
        buffer.WriteLong(QuestNum)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub
#End Region

#Region "Support Functions"
    'Tells if the quest is in progress or not
    Public Function QuestInProgress(ByVal QuestNum As Long) As Boolean
        QuestInProgress = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_STARTED Then 'Status=1 means started
            QuestInProgress = True
        End If
    End Function

    Public Function QuestCompleted(ByVal QuestNum As Long) As Boolean
        QuestCompleted = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_COMPLETED Or Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_COMPLETED_BUT Then
            QuestCompleted = True
        End If
    End Function

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
#End Region

#Region "Misc Functions"
    'Subroutine that load the desired task in the form
    Public Sub LoadTask(ByVal QuestNum As Long, ByVal TaskNum As Long)
        Dim TaskToLoad As TaskRec
        TaskToLoad = Quest(QuestNum).Task(TaskNum)

        With frmEditor_Quest
            'Load the task type
            Select Case TaskToLoad.Order
                Case 0
                    .optTask0.Checked = True
                Case 1
                    .optTask1.Checked = True
                Case 2
                    .optTask2.Checked = True
                Case 3
                    .optTask3.Checked = True
                Case 4
                    .optTask4.Checked = True
                Case 5
                    .optTask5.Checked = True
                Case 6
                    .optTask6.Checked = True
                Case 7
                    .optTask7.Checked = True
            End Select

            'Load textboxes
            .txtSpeech.Text = vbNullString
            .txtTaskLog.Text = "" & Trim$(TaskToLoad.TaskLog)

            'Set scrolls to 0 and disable them so they can be enabled when needed
            .scrlNPC.Value = 0
            .scrlItem.Value = 0
            .scrlMap.Value = 0
            .scrlResource.Value = 0
            .scrlAmount.Value = 0
            .txtSpeech.Enabled = False
            .scrlNPC.Enabled = False
            .scrlItem.Enabled = False
            .scrlMap.Enabled = False
            .scrlResource.Enabled = False
            .scrlAmount.Enabled = False

            If TaskToLoad.QuestEnd = True Then
                .chkEnd.Checked = 1
            Else
                .chkEnd.Checked = 0
            End If

            Select Case TaskToLoad.Order
                Case 0 'Nothing

                Case QUEST_TYPE_GOSLAY '1
                    .scrlNPC.Enabled = True
                    .scrlNPC.Value = TaskToLoad.Npc
                    .scrlAmount.Enabled = True
                    .scrlAmount.Value = TaskToLoad.Amount

                Case QUEST_TYPE_GOGATHER '2
                    .scrlItem.Enabled = True
                    .scrlItem.Value = TaskToLoad.Item
                    .scrlAmount.Enabled = True
                    .scrlAmount.Value = TaskToLoad.Amount

                Case QUEST_TYPE_GOTALK '3
                    .scrlNPC.Enabled = True
                    .scrlNPC.Value = TaskToLoad.Npc
                    .txtSpeech.Enabled = True
                    .txtSpeech.Text = "" & Trim$(TaskToLoad.Speech)

                Case QUEST_TYPE_GOREACH '4
                    .scrlMap.Enabled = True
                    .scrlMap.Value = TaskToLoad.Map

                Case QUEST_TYPE_GOGIVE '5
                    .scrlItem.Enabled = True
                    .scrlItem.Value = TaskToLoad.Item
                    .scrlAmount.Enabled = True
                    .scrlAmount.Value = TaskToLoad.Amount
                    .scrlNPC.Enabled = True
                    .scrlNPC.Value = TaskToLoad.Npc
                    .txtSpeech.Enabled = True
                    .txtSpeech.Text = "" & Trim$(TaskToLoad.Speech)

                Case QUEST_TYPE_GOTRAIN '6
                    .scrlResource.Enabled = True
                    .scrlResource.Value = TaskToLoad.Resource
                    .scrlAmount.Enabled = True
                    .scrlAmount.Value = TaskToLoad.Amount

                Case QUEST_TYPE_GOGET '7
                    .scrlNPC.Enabled = True
                    .scrlNPC.Value = TaskToLoad.Npc
                    .scrlItem.Enabled = True
                    .scrlItem.Value = TaskToLoad.Item
                    .scrlAmount.Enabled = True
                    .scrlAmount.Value = TaskToLoad.Amount
                    .txtSpeech.Enabled = True
                    .txtSpeech.Text = "" & Trim$(TaskToLoad.Speech)
            End Select
        End With
    End Sub

    Public Function CanStartQuest(ByVal QuestNum As Long) As Boolean
        CanStartQuest = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function
        If QuestInProgress(QuestNum) Then Exit Function

        'Check if player has the quest 0 (not started) or 3 (completed but it can be started again)
        If Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_NOT_STARTED Or Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_COMPLETED_BUT Then
            'Check if item is needed
            If Quest(QuestNum).Requirement(1) > 0 And Quest(QuestNum).Requirement(1) <= MAX_ITEMS Then
                If HasItem(MyIndex, Quest(QuestNum).Requirement(2)) = 0 Then
                    Exit Function
                End If
            End If

            'Check if previous quest is needed
            If Quest(QuestNum).Requirement(2) > 0 And Quest(QuestNum).Requirement(2) <= MAX_QUESTS Then
                If Player(MyIndex).PlayerQuest(Quest(QuestNum).Requirement(2)).Status = QUEST_NOT_STARTED Or Player(MyIndex).PlayerQuest(Quest(QuestNum).Requirement(2)).Status = QUEST_STARTED Then
                    Exit Function
                End If
            End If
            'Go on :)
            CanStartQuest = True
        Else

        End If
    End Function

    Function HasItem(ByVal Index As Long, ByVal itemNum As Long) As Long
        Dim i As Long

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                If Item(itemNum).Type = ITEM_TYPE_CURRENCY Or Item(itemNum).Stackable = 1 Then
                    HasItem = GetPlayerInvItemValue(Index, i)
                Else
                    HasItem = 1
                End If

                Exit Function
            End If

        Next

    End Function

    Public Sub RefreshQuestLog()
        Dim I As Long, x As Long

        For I = 1 To MAX_ACTIVEQUESTS
            QuestNames(I) = ""
        Next

        x = 1

        For I = 1 To MAX_QUESTS
            If QuestInProgress(I) And x < MAX_ACTIVEQUESTS Then
                QuestNames(x) = Trim$(Quest(I).Name)
                x = x + 1
            End If
        Next

    End Sub

    ' ////////////////////////
    ' // Visual Interaction //
    ' ////////////////////////

    Public Sub LoadQuestlogBox()
        Dim QuestNum As Long, CurTask As Long

        If Trim$(SelectedQuest) = vbNullString Then Exit Sub

        QuestNum = SelectedQuest
        CurTask = Player(MyIndex).PlayerQuest(QuestNum).ActualTask

            'Quest Log (Main Task)
            QuestTaskLogText = Trim$(Quest(QuestNum).QuestLog)

            'Actual Task
            ActualTaskText = Trim$(Quest(QuestNum).Task(CurTask).TaskLog)

            'Last dialog
            If Player(MyIndex).PlayerQuest(QuestNum).ActualTask > 1 Then
                If Len(Trim$(Quest(QuestNum).Task(CurTask - 1).Speech)) > 0 Then
                    QuestDialogText = Trim$(Quest(QuestNum).Task(CurTask - 1).Speech).Replace("$playername$", GetPlayerName(MyIndex))
                Else
                    QuestDialogText = Trim$(Quest(QuestNum).Chat(1).Replace("$playername$", GetPlayerName(MyIndex)))
                End If
            Else
                QuestDialogText = Trim$(Quest(QuestNum).Chat(1).Replace("$playername$", GetPlayerName(MyIndex)))
            End If

            'Quest Status
            If Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_STARTED Then
                QuestStatus2Text = "Quest Started"
                AbandonQuestText = "Cancel Quest"
                AbandonQuestVisible = True
            ElseIf Player(MyIndex).PlayerQuest(QuestNum).Status = QUEST_COMPLETED Then
                QuestStatus2Text = "Quest Completed"
                AbandonQuestVisible = False
            Else
                QuestStatus2Text = "???"
                AbandonQuestVisible = False
            End If

            'defeat x amount of Npc
            If Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOSLAY Then
                Dim CurCount As Long = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Long = Quest(QuestNum).Task(CurTask).Amount
                Dim NpcName As String = Npc(Quest(QuestNum).Task(CurTask).Npc).Name
                QuestRequirementsText = "Defeat " & CurCount & "/" & MaxAmount & " " & NpcName
                'gather x amount of items
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOGATHER Then
                Dim CurCount As Long = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Long = Quest(QuestNum).Task(CurTask).Amount
                Dim ItemName As String = Item(Quest(QuestNum).Task(CurTask).Item).Name
                QuestRequirementsText = "Collect " & CurCount & "/" & MaxAmount & " " & ItemName
                'go talk to npc
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOTALK Then
                Dim NpcName As String = Npc(Quest(QuestNum).Task(CurTask).Npc).Name
                QuestRequirementsText = "Go talk to  " & NpcName
                'reach certain map
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOREACH Then
                Dim MapName As String = MapNames(Quest(QuestNum).Task(CurTask).Map)
                QuestRequirementsText = "Go to " & MapName
                'give x amount of items to npc
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOGIVE Then
                Dim NpcName As String = Item(Quest(QuestNum).Task(CurTask).Npc).Name
                Dim MaxAmount As Long = Quest(QuestNum).Task(CurTask).Amount
                Dim ItemName As String = Item(Quest(QuestNum).Task(CurTask).Item).Name
                QuestRequirementsText = "Give " & NpcName & " the " & ItemName & "X" & MaxAmount & " they requested"
                'defeat certain amount of players
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOKILL Then
                Dim CurCount As Long = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Long = Quest(QuestNum).Task(CurTask).Amount
                QuestRequirementsText = "Defeat " & MaxAmount & " Players in Battle " & CurCount & "/" & MaxAmount
                'go collect resources
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOTRAIN Then
                Dim CurCount As Long = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Long = Quest(QuestNum).Task(CurTask).Amount
                Dim ResourceName As String = Resource(Quest(QuestNum).Task(CurTask).Resource).Name
                QuestRequirementsText = "Defeat " & MaxAmount & " Players in Battle " & CurCount & "/" & MaxAmount
                'collect x amount of items from npc
            ElseIf Quest(QuestNum).Task(Player(MyIndex).PlayerQuest(QuestNum).ActualTask).TaskType = QUEST_TYPE_GOTRAIN Then
                Dim NpcName As String = Item(Quest(QuestNum).Task(CurTask).Npc).Name
                Dim MaxAmount As Long = Quest(QuestNum).Task(CurTask).Amount
                Dim ItemName As String = Item(Quest(QuestNum).Task(CurTask).Item).Name
                QuestRequirementsText = "Collect " & ItemName & "X" & MaxAmount & " from " & NpcName
            Else
                QuestRequirementsText = "Requirements: "  'ToDo
            End If

        'Rewards
        QuestRewardsText = Item(Quest(QuestNum).RewardItem).Name & " X" & Str(Quest(QuestNum).RewardItemAmount)

    End Sub

    Public Sub DrawQuestLog()
        Dim i As Long, y As Long

        y = 10

        'first render panel
        RenderTexture(QuestGFX, GameWindow, QuestLogX, QuestLogY, 0, 0, QuestGFXInfo.width, QuestGFXInfo.height)

        'draw quest names
        For i = 1 To MAX_ACTIVEQUESTS
            If Len(Trim$(QuestNames(i))) > 0 Then
                DrawText(QuestLogX + 7, QuestLogY + y, Trim$(QuestNames(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 20
            End If
        Next

        If SelectedQuest <= 0 Then Exit Sub

        'quest log text
        DrawText(QuestLogX + 204, QuestLogY + 30, Trim$(QuestTaskLogText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        DrawText(QuestLogX + 204, QuestLogY + 147, Trim$(ActualTaskText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        y = 0
        For Each str As String In WordWrap(Trim$(QuestDialogText), 40)
            'description
            DrawText(QuestLogX + 204, QuestLogY + 218 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next
        DrawText(QuestLogX + 280, QuestLogY + 263, Trim$(QuestStatus2Text), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        DrawText(QuestLogX + 285, QuestLogY + 288, Trim$(QuestRequirementsText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        DrawText(QuestLogX + 255, QuestLogY + 313, Trim$(QuestRewardsText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
    End Sub

    Public Sub ResetQuestLog()

        QuestTaskLogText = ""
            ActualTaskText = ""
            QuestDialogText = ""
            QuestStatus2Text = ""
            AbandonQuestText = ""
            AbandonQuestVisible = False
            QuestRequirementsText = ""
            QuestRewardsText = ""
        pnlQuestLogVisible = False

        SelectedQuest = 0
    End Sub
#End Region

End Module
