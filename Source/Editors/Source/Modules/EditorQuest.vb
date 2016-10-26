Public Module EditorQuest
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

    Public QuestLogPage As Integer
    Public QuestNames(MAX_ACTIVEQUESTS) As String

    Public Quest_Changed(MAX_QUESTS) As Boolean

    Public QuestEditorShow As Boolean

    'questlog variables

    Public Const MAX_ACTIVEQUESTS = 10

    Public QuestLogX As Integer = 150
    Public QuestLogY As Integer = 100

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
    Public QuestNum As Integer
    Public QuestNumForStart As Integer
    Public QuestMessage As String
    Public QuestAcceptTag As Integer

    'Types
    Public Quest(0 To MAX_QUESTS) As QuestRec

    Public Structure PlayerQuestRec
        Dim Status As Integer '0=not started, 1=started, 2=completed, 3=completed but repeatable
        Dim ActualTask As Integer
        Dim CurrentCount As Integer 'Used to handle the Amount property
    End Structure

    Public Structure TaskRec
        Dim Order As Integer
        Dim Npc As Integer
        Dim Item As Integer
        Dim Map As Integer
        Dim Resource As Integer
        Dim Amount As Integer
        Dim Speech As String
        Dim TaskLog As String
        Dim QuestEnd As Boolean
        Dim TaskType As Integer
    End Structure

    Public Structure QuestRec
        Dim Name As String
        Dim QuestLog As String
        Dim TasksCount As Integer 'todo
        Dim Repeat As Integer

        Dim Requirement() As Integer '1=item, 2=quest

        Dim QuestGiveItem As Integer 'Todo: make this dynamic
        Dim QuestGiveItemValue As Integer
        Dim QuestRemoveItem As Integer
        Dim QuestRemoveItemValue As Integer

        Dim Chat() As String

        Dim RewardItem As Integer 'ToDo: make this dynamic
        Dim RewardItemAmount As Integer
        Dim RewardExp As Integer

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
        Dim I As Integer

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
        Dim I As Integer

        For I = 0 To MAX_QUESTS
            Quest_Changed(I) = False
        Next
    End Sub
#End Region

#Region "DataBase"
    Sub ClearQuest(ByVal QuestNum As Integer)
        Dim I As Integer

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
        Dim I As Integer

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

        If buffer.ReadInteger <> ServerPackets.SQuestEditor Then Exit Sub

        QuestEditorShow = True

        buffer = Nothing
    End Sub

    Public Sub Packet_UpdateQuest(ByVal data() As Byte)
        Dim QuestNum As Integer
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SUpdateQuest Then Exit Sub

        QuestNum = buffer.ReadInteger

        ' Update the Quest
        Quest(QuestNum).Name = buffer.ReadString
        Quest(QuestNum).QuestLog = buffer.ReadString
        Quest(QuestNum).TasksCount = buffer.ReadInteger
        Quest(QuestNum).Repeat = buffer.ReadInteger

        For I = 1 To 3
            Quest(QuestNum).Requirement(I) = buffer.ReadInteger
        Next

        Quest(QuestNum).QuestGiveItem = buffer.ReadInteger
        Quest(QuestNum).QuestGiveItemValue = buffer.ReadInteger
        Quest(QuestNum).QuestRemoveItem = buffer.ReadInteger
        Quest(QuestNum).QuestRemoveItemValue = buffer.ReadInteger

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = buffer.ReadString
        Next

        Quest(QuestNum).RewardItem = buffer.ReadInteger
        Quest(QuestNum).RewardItemAmount = buffer.ReadInteger
        Quest(QuestNum).RewardExp = buffer.ReadInteger

        For I = 1 To MAX_TASKS
            Quest(QuestNum).Task(I).Order = buffer.ReadInteger
            Quest(QuestNum).Task(I).Npc = buffer.ReadInteger
            Quest(QuestNum).Task(I).Item = buffer.ReadInteger
            Quest(QuestNum).Task(I).Map = buffer.ReadInteger
            Quest(QuestNum).Task(I).Resource = buffer.ReadInteger
            Quest(QuestNum).Task(I).Amount = buffer.ReadInteger
            Quest(QuestNum).Task(I).Speech = buffer.ReadString
            Quest(QuestNum).Task(I).TaskLog = buffer.ReadString
            Quest(QuestNum).Task(I).QuestEnd = buffer.ReadInteger
            Quest(QuestNum).Task(I).TaskType = buffer.ReadInteger
        Next

        buffer = Nothing
    End Sub

#End Region

#Region "Outgoing Packets"
    Public Sub SendRequestEditQuest()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CRequestEditQuest)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub SendSaveQuest(ByVal QuestNum As Integer)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        buffer.WriteInteger(ClientPackets.CSaveQuest)
        buffer.WriteInteger(QuestNum)

        buffer.WriteString(Trim(Quest(QuestNum).Name))
        buffer.WriteString(Trim(Quest(QuestNum).QuestLog))
        buffer.WriteInteger(Quest(QuestNum).TasksCount)
        buffer.WriteInteger(Quest(QuestNum).Repeat)

        For I = 1 To 3
            buffer.WriteInteger(Quest(QuestNum).Requirement(I))
        Next

        buffer.WriteInteger(Quest(QuestNum).QuestGiveItem)
        buffer.WriteInteger(Quest(QuestNum).QuestGiveItemValue)
        buffer.WriteInteger(Quest(QuestNum).QuestRemoveItem)
        buffer.WriteInteger(Quest(QuestNum).QuestRemoveItemValue)

        For I = 1 To 3
            buffer.WriteString(Trim(Quest(QuestNum).Chat(I)))
        Next

        buffer.WriteInteger(Quest(QuestNum).RewardItem)
        buffer.WriteInteger(Quest(QuestNum).RewardItemAmount)
        buffer.WriteInteger(Quest(QuestNum).RewardExp)

        For I = 1 To MAX_TASKS
            buffer.WriteInteger(Quest(QuestNum).Task(I).Order)
            buffer.WriteInteger(Quest(QuestNum).Task(I).Npc)
            buffer.WriteInteger(Quest(QuestNum).Task(I).Item)
            buffer.WriteInteger(Quest(QuestNum).Task(I).Map)
            buffer.WriteInteger(Quest(QuestNum).Task(I).Resource)
            buffer.WriteInteger(Quest(QuestNum).Task(I).Amount)
            buffer.WriteString(Trim(Quest(QuestNum).Task(I).Speech))
            buffer.WriteString(Trim(Quest(QuestNum).Task(I).TaskLog))
            buffer.WriteInteger(Quest(QuestNum).Task(I).QuestEnd)
            buffer.WriteInteger(Quest(QuestNum).Task(I).TaskType)
        Next

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Sub SendRequestQuests()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CRequestQuests)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub UpdateQuestLog()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CQuestLogUpdate)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub PlayerHandleQuest(ByVal QuestNum As Integer, ByVal Order As Integer)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        buffer.WriteInteger(ClientPackets.CPlayerHandleQuest)
        buffer.WriteInteger(QuestNum)
        buffer.WriteInteger(Order) '1=accept quest, 2=cancel quest
        SendData(buffer.ToArray)
        buffer = Nothing
    End Sub

    Public Sub QuestReset(ByVal QuestNum As Integer)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CQuestReset)
        buffer.WriteInteger(QuestNum)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub
#End Region

#Region "Support Functions"

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
#End Region

#Region "Misc Functions"
    'Subroutine that load the desired task in the form
    Public Sub LoadTask(ByVal QuestNum As Integer, ByVal TaskNum As Integer)
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
#End Region

End Module
