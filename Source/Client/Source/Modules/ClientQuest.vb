Public Module ClientQuest
#Region "Global Info"
    'Constants
    Public Const MAX_QUESTS As Byte = 250
    'Public Const MAX_TASKS As Byte = 10
    'Public Const MAX_REQUIREMENTS As Byte = 10
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

    Public QuestLogPage As Integer
    Public QuestNames(MAX_ACTIVEQUESTS) As String

    Public Quest_Changed(MAX_QUESTS) As Boolean

    Public QuestEditorShow As Boolean

    'questlog variables

    Public Const MAX_ACTIVEQUESTS = 10

    Public QuestLogX As Integer = 150
    Public QuestLogY As Integer = 100

    Public pnlQuestLogVisible As Boolean
    Public SelectedQuest As Integer
    Public QuestTaskLogText As String = ""
    Public ActualTaskText As String = ""
    Public QuestDialogText As String = ""
    Public QuestStatus2Text As String = ""
    Public AbandonQuestText As String = ""
    Public AbandonQuestVisible As Boolean
    Public QuestRequirementsText As String = ""
    Public QuestRewardsText() As String

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

#Region "DataBase"
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
            Quest(QuestNum).Requirement(I) = 0
            Quest(QuestNum).RequirementIndex(I) = 0
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
            Quest(QuestNum).Task(I).Npc = 0
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

        ReDim Quest(MAX_QUESTS)

        For I = 1 To MAX_QUESTS
            ClearQuest(I)
        Next
    End Sub
#End Region

#Region "Incoming Packets"
    Public Sub Packet_QuestEditor(ByVal data() As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SQuestEditor Then Exit Sub

        QuestEditorShow = True

        buffer = Nothing
    End Sub

    Public Sub Packet_UpdateQuest(ByVal data() As Byte)
        Dim QuestNum As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SUpdateQuest Then Exit Sub

        QuestNum = buffer.ReadInteger

        ' Update the Quest
        Quest(QuestNum).Name = buffer.ReadString
        Quest(QuestNum).QuestLog = buffer.ReadString
        Quest(QuestNum).Repeat = buffer.ReadInteger
        Quest(QuestNum).Cancelable = buffer.ReadInteger

        Quest(QuestNum).ReqCount = buffer.ReadInteger
        ReDim Quest(QuestNum).Requirement(Quest(QuestNum).ReqCount)
        ReDim Quest(QuestNum).RequirementIndex(Quest(QuestNum).ReqCount)
        For I = 1 To Quest(QuestNum).ReqCount
            Quest(QuestNum).Requirement(I) = buffer.ReadInteger
            Quest(QuestNum).RequirementIndex(I) = buffer.ReadInteger
        Next

        Quest(QuestNum).QuestGiveItem = buffer.ReadInteger
        Quest(QuestNum).QuestGiveItemValue = buffer.ReadInteger
        Quest(QuestNum).QuestRemoveItem = buffer.ReadInteger
        Quest(QuestNum).QuestRemoveItemValue = buffer.ReadInteger

        For I = 1 To 3
            Quest(QuestNum).Chat(I) = buffer.ReadString
        Next

        Quest(QuestNum).RewardCount = buffer.ReadInteger
        ReDim Quest(QuestNum).RewardItem(Quest(QuestNum).RewardCount)
        ReDim Quest(QuestNum).RewardItemAmount(Quest(QuestNum).RewardCount)
        For i = 1 To Quest(QuestNum).RewardCount
            Quest(QuestNum).RewardItem(i) = buffer.ReadInteger
            Quest(QuestNum).RewardItemAmount(i) = buffer.ReadInteger
        Next

        Quest(QuestNum).RewardExp = buffer.ReadInteger

        Quest(QuestNum).TaskCount = buffer.ReadInteger
        ReDim Quest(QuestNum).Task(Quest(QuestNum).TaskCount)
        For I = 1 To Quest(QuestNum).TaskCount
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

    Public Sub Packet_PlayerQuest(ByVal data() As Byte)
        Dim buffer As New ByteBuffer
        Dim QuestNum As Integer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SPlayerQuest Then Exit Sub

        QuestNum = buffer.ReadInteger

        Player(MyIndex).PlayerQuest(QuestNum).Status = buffer.ReadInteger
        Player(MyIndex).PlayerQuest(QuestNum).ActualTask = buffer.ReadInteger
        Player(MyIndex).PlayerQuest(QuestNum).CurrentCount = buffer.ReadInteger

        RefreshQuestLog()

        buffer = Nothing
    End Sub

    Public Sub Packet_PlayerQuests(ByVal data() As Byte)
        Dim buffer As New ByteBuffer
        Dim I As Integer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SPlayerQuests Then Exit Sub

        For I = 1 To MAX_QUESTS
            Player(MyIndex).PlayerQuest(I).Status = buffer.ReadInteger
            Player(MyIndex).PlayerQuest(I).ActualTask = buffer.ReadInteger
            Player(MyIndex).PlayerQuest(I).CurrentCount = buffer.ReadInteger
        Next

        RefreshQuestLog()

        buffer = Nothing
    End Sub

    Public Sub Packet_QuestMessage(ByVal data() As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SQuestMessage Then Exit Sub

        QuestNum = buffer.ReadInteger
        QuestMessage = Trim$(buffer.ReadString)
        QuestMessage = QuestMessage.Replace("$playername$", GetPlayerName(MyIndex))
        QuestNumForStart = buffer.ReadInteger

        UpdateQuestChat = True

        buffer = Nothing
    End Sub
#End Region

#Region "Outgoing Packets"

    Sub SendRequestQuests()
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CRequestQuests)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub UpdateQuestLog()
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CQuestLogUpdate)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub PlayerHandleQuest(ByVal QuestNum As Integer, ByVal Order As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CPlayerHandleQuest)
        buffer.WriteInteger(QuestNum)
        buffer.WriteInteger(Order) '1=accept quest, 2=cancel quest

        SendData(buffer.ToArray)
        buffer = Nothing
    End Sub

    Public Sub QuestReset(ByVal QuestNum As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CQuestReset)
        buffer.WriteInteger(QuestNum)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub
#End Region

#Region "Support Functions"
    'Tells if the quest is in progress or not
    Public Function QuestInProgress(ByVal QuestNum As Integer) As Boolean
        QuestInProgress = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.Started Then 'Status=1 means started
            QuestInProgress = True
        End If
    End Function

    Public Function QuestCompleted(ByVal QuestNum As Integer) As Boolean
        QuestCompleted = False
        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function

        If Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.Completed Or Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.Repeatable Then
            QuestCompleted = True
        End If
    End Function

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
    Public Function CanStartQuest(ByVal QuestNum As Integer) As Boolean
        Dim i As Integer

        CanStartQuest = False

        If QuestNum < 1 Or QuestNum > MAX_QUESTS Then Exit Function
        If QuestInProgress(QuestNum) Then Exit Function

        'Check if player has the quest 0 (not started) or 3 (completed but it can be started again)
        If Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.NotStarted Or Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.Repeatable Then

            For i = 1 To Quest(QuestNum).ReqCount
                'Check if item is needed
                If Quest(QuestNum).Requirement(i) = 1 Then
                    If Quest(QuestNum).RequirementIndex(i) > 0 And Quest(QuestNum).RequirementIndex(i) <= MAX_ITEMS Then
                        If HasItem(MyIndex, Quest(QuestNum).RequirementIndex(i)) = 0 Then
                            Exit Function
                        End If
                    End If
                End If

                'Check if previous quest is needed
                If Quest(QuestNum).Requirement(i) = 2 Then
                    If Quest(QuestNum).RequirementIndex(i) > 0 And Quest(QuestNum).RequirementIndex(i) <= MAX_QUESTS Then
                        If Player(MyIndex).PlayerQuest(Quest(QuestNum).RequirementIndex(i)).Status = QuestStatus.NotStarted Or Player(MyIndex).PlayerQuest(Quest(QuestNum).RequirementIndex(i)).Status = QuestStatus.Started Then
                            Exit Function
                        End If
                    End If
                End If

            Next

            'Go on :)
            CanStartQuest = True
        Else
            CanStartQuest = False
        End If
    End Function

    Public Function CanEndQuest(ByVal Index As Integer, QuestNum As Integer) As Boolean
        CanEndQuest = False

        If Player(Index).PlayerQuest(QuestNum).ActualTask >= Quest(QuestNum).Task.Length Then
            CanEndQuest = True
        End If
        If Quest(QuestNum).Task(Player(Index).PlayerQuest(QuestNum).ActualTask).QuestEnd = 1 Then
            CanEndQuest = True
        End If
    End Function

    Function HasItem(ByVal Index As Integer, ByVal itemNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then
                    HasItem = GetPlayerInvItemValue(Index, i)
                Else
                    HasItem = 1
                End If

                Exit Function
            End If

        Next

    End Function

    Public Sub RefreshQuestLog()
        Dim I As Integer, x As Integer

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
        Dim QuestNum As Integer, CurTask As Integer, I As Integer

        If SelectedQuest = 0 Then Exit Sub

        For I = 1 To MAX_QUESTS
            If Trim$(QuestNames(SelectedQuest)) = Trim$(Quest(I).Name) Then
                QuestNum = I
            End If
        Next

        If QuestNum = 0 Then Exit Sub

        CurTask = Player(MyIndex).PlayerQuest(QuestNum).ActualTask

        If CurTask >= Quest(QuestNum).Task.Length Then Exit Sub

        'Quest Log (Main Task)
        QuestTaskLogText = Trim$(Quest(QuestNum).QuestLog)

        'Actual Task
        QuestTaskLogText = Trim$(Quest(QuestNum).Task(CurTask).TaskLog)

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
        If Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.Started Then
            QuestStatus2Text = Strings.Get("quests", "queststarted")
            AbandonQuestText = Strings.Get("quests", "questcancel")
            AbandonQuestVisible = True
        ElseIf Player(MyIndex).PlayerQuest(QuestNum).Status = QuestStatus.COMPLETED Then
            QuestStatus2Text = Strings.Get("quests", "questcomplete")
            AbandonQuestVisible = False
        Else
            QuestStatus2Text = "???"
            AbandonQuestVisible = False
        End If

        Select Case Quest(QuestNum).Task(CurTask).TaskType
                'defeat x amount of Npc
            Case QuestType.Slay
                Dim CurCount As Integer = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Integer = Quest(QuestNum).Task(CurTask).Amount
                Dim NpcName As String = Npc(Quest(QuestNum).Task(CurTask).Npc).Name
                ActualTaskText = Strings.Get("quests", "questgoslay", CurCount, MaxAmount, NpcName)'"Defeat " & CurCount & "/" & MaxAmount & " " & NpcName
                'gather x amount of items
            Case QuestType.Collect
                Dim CurCount As Integer = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Integer = Quest(QuestNum).Task(CurTask).Amount
                Dim ItemName As String = Item(Quest(QuestNum).Task(CurTask).Item).Name
                ActualTaskText = Strings.Get("quests", "questgocollect", CurCount, MaxAmount, ItemName)'"Collect " & CurCount & "/" & MaxAmount & " " & ItemName
                'go talk to npc
            Case QuestType.Talk
                Dim NpcName As String = Npc(Quest(QuestNum).Task(CurTask).Npc).Name
                ActualTaskText = Strings.Get("quests", "questtalkto", NpcName)'"Go talk to  " & NpcName
                'reach certain map
            Case QuestType.Reach
                Dim MapName As String = MapNames(Quest(QuestNum).Task(CurTask).Map)
                ActualTaskText = Strings.Get("quests", "questgoto", MapName)'"Go to " & MapName
            Case QuestType.Give
                'give x amount of items to npc
                Dim NpcName As String = Npc(Quest(QuestNum).Task(CurTask).Npc).Name
                Dim CurCount As Integer = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Integer = Quest(QuestNum).Task(CurTask).Amount
                Dim ItemName As String = Item(Quest(QuestNum).Task(CurTask).Item).Name
                ActualTaskText = Strings.Get("quests", "questgive", NpcName, ItemName, CurCount, MaxAmount)'"Give " & NpcName & " the " & ItemName & CurCount & "/" & MaxAmount & " they requested"
                'defeat certain amount of players
            Case QuestType.Kill
                Dim CurCount As Integer = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Integer = Quest(QuestNum).Task(CurTask).Amount
                ActualTaskText = Strings.Get("quests", "questkill", CurCount, MaxAmount)'"Defeat " & CurCount & "/" & MaxAmount & " Players in Battle"
                'go collect resources
            Case QuestType.Gather
                Dim CurCount As Integer = Player(MyIndex).PlayerQuest(QuestNum).CurrentCount
                Dim MaxAmount As Integer = Quest(QuestNum).Task(CurTask).Amount
                Dim ResourceName As String = Resource(Quest(QuestNum).Task(CurTask).Resource).Name
                ActualTaskText = Strings.Get("quests", "questgather", CurCount, MaxAmount, ResourceName)'"Gather " & CurCount & "/" & MaxAmount & " " & ResourceName
                'fetch x amount of items from npc
            Case QuestType.Fetch
                Dim NpcName As String = Item(Quest(QuestNum).Task(CurTask).Npc).Name
                Dim MaxAmount As Integer = Quest(QuestNum).Task(CurTask).Amount
                Dim ItemName As String = Item(Quest(QuestNum).Task(CurTask).Item).Name
                ActualTaskText = Strings.Get("quests", "questfetch", ItemName, MaxAmount, NpcName) '"Fetch " & ItemName & "X" & MaxAmount & " from " & NpcName
            Case Else
                'ToDo
                ActualTaskText = "errr..."
        End Select

        'Rewards
        ReDim QuestRewardsText(Quest(QuestNum).RewardCount + 1)
        For I = 1 To Quest(QuestNum).RewardCount
            QuestRewardsText(I) = Item(Quest(QuestNum).RewardItem(I)).Name & " X" & Str(Quest(QuestNum).RewardItemAmount(I))
        Next
        QuestRewardsText(I) = Str(Quest(QuestNum).RewardExp) & " EXP"
    End Sub

    Public Sub DrawQuestLog()
        Dim i As Integer, y As Integer

        y = 10

        'first render panel
        RenderSprite(QuestSprite, GameWindow, QuestLogX, QuestLogY, 0, 0, QuestGFXInfo.Width, QuestGFXInfo.Height)

        'draw quest names
        For i = 1 To MAX_ACTIVEQUESTS
            If Len(Trim$(QuestNames(i))) > 0 Then
                DrawText(QuestLogX + 7, QuestLogY + y, Trim$(QuestNames(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 20
            End If
        Next

        If SelectedQuest <= 0 Then Exit Sub

        'quest log text
        y = 0
        For Each str As String In WordWrap(Trim$(QuestTaskLogText), 35)
            'description
            DrawText(QuestLogX + 204, QuestLogY + 30 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next

        y = 0
        For Each str As String In WordWrap(Trim$(ActualTaskText), 40)
            'description
            DrawText(QuestLogX + 204, QuestLogY + 147 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next

        y = 0
        For Each str As String In WordWrap(Trim$(QuestDialogText), 40)
            'description
            DrawText(QuestLogX + 204, QuestLogY + 218 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next
        DrawText(QuestLogX + 280, QuestLogY + 263, Trim$(QuestStatus2Text), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'DrawText(QuestLogX + 285, QuestLogY + 288, Trim$(QuestRequirementsText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        y = 0
        For i = 1 To QuestRewardsText.Length - 1
            'description
            DrawText(QuestLogX + 255, QuestLogY + 292 + y, Trim$(QuestRewardsText(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            y = y + 15
        Next

    End Sub

    Public Sub ResetQuestLog()

        QuestTaskLogText = ""
        ActualTaskText = ""
        QuestDialogText = ""
        QuestStatus2Text = ""
        AbandonQuestText = ""
        AbandonQuestVisible = False
        QuestRequirementsText = ""
        ReDim QuestRewardsText(0)
        pnlQuestLogVisible = False

        SelectedQuest = 0
    End Sub
#End Region

End Module