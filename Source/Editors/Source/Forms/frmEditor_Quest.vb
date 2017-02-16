Public Class frmEditor_Quest
    Dim SelectedTask As Integer

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub FrmEditor_Quest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = 740

        fraRequirements.Location = fraQuestList.Location
        fraRequirements.Visible = False
        fraTasks.Location = fraQuestList.Location
        fraTasks.Visible = False

        nudAmount.Maximum = 999999

        nudGiveAmount.Maximum = Byte.MaxValue
        nudTakeAmount.Maximum = Byte.MaxValue
        nudItemRewValue.Maximum = 999999

    End Sub

    Private Sub LstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        QuestEditorInit()
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Quest(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Quest(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        If Len(Trim$(txtName.Text)) = 0 Then
            MsgBox("Name required.")
        Else
            QuestEditorOk()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        QuestEditorCancel()
    End Sub

    Private Sub TxtStartText_TextChanged(sender As Object, e As EventArgs) Handles txtStartText.TextChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).Chat(1) = Trim$(txtStartText.Text)
    End Sub

    Private Sub TxtProgressText_TextChanged(sender As Object, e As EventArgs) Handles txtProgressText.TextChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).Chat(2) = Trim$(txtProgressText.Text)
    End Sub

    Private Sub TxtEndText_TextChanged(sender As Object, e As EventArgs) Handles txtEndText.TextChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).Chat(3) = Trim$(txtEndText.Text)
    End Sub

    Private Sub CmbStartItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStartItem.SelectedIndexChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).QuestGiveItem = cmbStartItem.SelectedIndex
    End Sub

    Private Sub CmbEndItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEndItem.SelectedIndexChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).QuestRemoveItem = cmbEndItem.SelectedIndex
    End Sub

    Private Sub NudGiveAmount_ValueChanged(sender As Object, e As EventArgs) Handles nudGiveAmount.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).QuestGiveItemValue = cmbEndItem.SelectedIndex
    End Sub

    Private Sub NudTakeAmount_ValueChanged(sender As Object, e As EventArgs) Handles nudTakeAmount.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).QuestRemoveItemValue = nudTakeAmount.Value
    End Sub

    Private Sub ChkRepeat_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepeat.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        If chkRepeat.Checked = True Then
            Quest(EditorIndex).Repeat = 1
        Else
            Quest(EditorIndex).Repeat = 0
        End If
    End Sub

    Private Sub ChkQuestCancel_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuestCancel.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        If chkQuestCancel.Checked = True Then
            Quest(EditorIndex).Cancelable = 1
        Else
            Quest(EditorIndex).Cancelable = 0
        End If
    End Sub

#Region "Rewards"

    Private Sub NudExpReward_ValueChanged(sender As Object, e As EventArgs) Handles nudExpReward.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).RewardExp = nudExpReward.Value
    End Sub

    Private Sub BtnAddReward_Click(sender As Object, e As EventArgs) Handles btnAddReward.Click
        If EditorIndex <= 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        Quest(EditorIndex).RewardCount = Quest(EditorIndex).RewardCount + 1

        ReDim Preserve Quest(EditorIndex).RewardItem(Quest(EditorIndex).RewardCount)
        ReDim Preserve Quest(EditorIndex).RewardItemAmount(Quest(EditorIndex).RewardCount)

        Quest(EditorIndex).RewardItem(Quest(EditorIndex).RewardCount) = cmbItemReward.SelectedIndex
        Quest(EditorIndex).RewardItemAmount(Quest(EditorIndex).RewardCount) = nudItemRewValue.Value

        lstRewards.Items.Clear()
        For i = 1 To Quest(EditorIndex).RewardCount
            lstRewards.Items.Add(i & ":" & Quest(EditorIndex).RewardItemAmount(i) & " X " & Trim(Item(Quest(EditorIndex).RewardItem(i)).Name))
        Next
    End Sub

    Private Sub BtnRemoveReward_Click(sender As Object, e As EventArgs) Handles btnRemoveReward.Click
        Dim tmpRewardItem() As Integer, tmpRewardItemIndex() As Integer

        If lstRewards.SelectedIndex < 0 Then Exit Sub
        If Quest(EditorIndex).RewardCount <= 0 Then Exit Sub

        ReDim tmpRewardItem(Quest(EditorIndex).RewardCount - 1)
        ReDim tmpRewardItemIndex(Quest(EditorIndex).RewardCount - 1)

        For i = 1 To Quest(EditorIndex).RewardCount
            If Not i = lstRewards.SelectedIndex + 1 Then
                tmpRewardItem(i) = Quest(EditorIndex).RewardItem(i)
                tmpRewardItemIndex(i) = Quest(EditorIndex).RewardItemAmount(i)
            End If
        Next

        Quest(EditorIndex).RewardCount = Quest(EditorIndex).RewardCount - 1

        ReDim Quest(EditorIndex).RewardItem(Quest(EditorIndex).RewardCount)
        ReDim Quest(EditorIndex).RewardItemAmount(Quest(EditorIndex).RewardCount)

        For i = 1 To Quest(EditorIndex).RewardCount
            Quest(EditorIndex).RewardItem(i) = tmpRewardItem(i)
            Quest(EditorIndex).RewardItemAmount(i) = tmpRewardItemIndex(i)
        Next

        lstRewards.Items.Clear()
        For i = 1 To Quest(EditorIndex).RewardCount
            lstRewards.Items.Add(i & ":" & Quest(EditorIndex).RewardItemAmount(i) & " X " & Trim(Item(Quest(EditorIndex).RewardItem(i)).Name))
        Next

    End Sub

#End Region

#Region "Tasks"
    Private Sub LstTasks_DoubleClick(sender As Object, e As EventArgs) Handles lstTasks.DoubleClick
        If lstTasks.SelectedIndex < 0 Then Exit Sub

        SelectedTask = lstTasks.SelectedIndex + 1
        LoadTask(EditorIndex, SelectedTask)
        fraTasks.Visible = True
        fraTasks.BringToFront()
    End Sub

    Private Sub BtnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        Quest(EditorIndex).TaskCount = Quest(EditorIndex).TaskCount + 1

        ReDim Preserve Quest(EditorIndex).Task(Quest(EditorIndex).TaskCount)

        SelectedTask = Quest(EditorIndex).TaskCount

        LoadTask(EditorIndex, SelectedTask)

        fraTasks.Visible = True
        fraTasks.BringToFront()
    End Sub

    Private Sub BtnRemoveTask_Click(sender As Object, e As EventArgs) Handles btnRemoveTask.Click
        Dim i As Integer, tmptask() As TaskRec

        If lstTasks.SelectedIndex < 0 Then Exit Sub
        If Quest(EditorIndex).TaskCount <= 0 Then Exit Sub

        ReDim tmptask(Quest(EditorIndex).TaskCount - 1)

        For i = 1 To Quest(EditorIndex).TaskCount
            If Not i = lstTasks.SelectedIndex + 1 Then
                tmptask(i) = Quest(EditorIndex).Task(i)
            End If
        Next

        Quest(EditorIndex).TaskCount = Quest(EditorIndex).TaskCount - 1

        ReDim Quest(EditorIndex).Task(Quest(EditorIndex).TaskCount)

        For i = 1 To Quest(EditorIndex).TaskCount
            If Not i = lstTasks.SelectedIndex + 1 Then
                Quest(EditorIndex).Task(i) = tmptask(i)
            End If
        Next

        lstTasks.Items.Clear()
        For i = 1 To Quest(EditorIndex).TaskCount
            lstTasks.Items.Add(i & ":" & Quest(EditorIndex).Task(i).TaskLog)
        Next

    End Sub

    Private Sub BtnSaveTask_Click(sender As Object, e As EventArgs) Handles btnSaveTask.Click

        If lstTasks.SelectedIndex < 0 Then
            SelectedTask = Quest(EditorIndex).TaskCount
        Else
            SelectedTask = lstTasks.SelectedIndex + 1
        End If

        Quest(EditorIndex).Task(SelectedTask).TaskLog = Trim$(txtTaskLog.Text)
        Quest(EditorIndex).Task(SelectedTask).Speech = txtTaskSpeech.Text

        If chkEnd.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).QuestEnd = 1
        Else
            Quest(EditorIndex).Task(SelectedTask).QuestEnd = 0
        End If

        Quest(EditorIndex).Task(SelectedTask).Npc = cmbNpc.SelectedIndex
        Quest(EditorIndex).Task(SelectedTask).Item = cmbItem.SelectedIndex
        Quest(EditorIndex).Task(SelectedTask).Map = cmbMap.SelectedIndex
        Quest(EditorIndex).Task(SelectedTask).Resource = cmbResource.SelectedIndex
        Quest(EditorIndex).Task(SelectedTask).Amount = nudAmount.Value

        If optTask0.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 0
        ElseIf optTask1.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 1
        ElseIf optTask2.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 2
        ElseIf optTask3.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 3
        ElseIf optTask4.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 4
        ElseIf optTask5.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 5
        ElseIf optTask6.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 6
        ElseIf optTask7.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 7
        End If

        lstTasks.Items.Clear()
        For i = 1 To Quest(EditorIndex).TaskCount
            lstTasks.Items.Add(i & ":" & Quest(EditorIndex).Task(i).TaskLog)
        Next

        fraTasks.Visible = False
    End Sub

    Private Sub BtnCancelTask_Click(sender As Object, e As EventArgs) Handles btnCancelTask.Click
        Quest(EditorIndex).TaskCount = Quest(EditorIndex).TaskCount - 1

        ReDim Quest(EditorIndex).Task(Quest(EditorIndex).TaskCount)

        SelectedTask = Quest(EditorIndex).TaskCount
        fraTasks.Visible = False
    End Sub

    Private Sub OptTask0_CheckedChanged(sender As Object, e As EventArgs) Handles optTask0.CheckedChanged
        If optTask0.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 0
            Quest(EditorIndex).Task(SelectedTask).TaskType = 0
            LoadTask(EditorIndex, SelectedTask)
        End If
    End Sub

    Private Sub OptTask1_CheckedChanged(sender As Object, e As EventArgs) Handles optTask1.CheckedChanged
        If optTask1.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 1
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOSLAY
            LoadTask(EditorIndex, SelectedTask)
            cmbNpc.Enabled = True
        Else
            cmbNpc.Enabled = False
        End If
    End Sub

    Private Sub OptTask2_CheckedChanged(sender As Object, e As EventArgs) Handles optTask2.CheckedChanged
        If optTask2.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 2
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOGATHER
            LoadTask(EditorIndex, SelectedTask)
            cmbItem.Enabled = True
        Else
            cmbItem.Enabled = False
        End If
    End Sub

    Private Sub OptTask3_CheckedChanged(sender As Object, e As EventArgs) Handles optTask3.CheckedChanged
        If optTask3.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 3
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOTALK
            LoadTask(EditorIndex, SelectedTask)
            cmbNpc.Enabled = True
        Else
            cmbNpc.Enabled = False
        End If
    End Sub

    Private Sub OptTask4_CheckedChanged(sender As Object, e As EventArgs) Handles optTask4.CheckedChanged
        If optTask4.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 4
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOREACH
            LoadTask(EditorIndex, SelectedTask)
            cmbMap.Enabled = True
        Else
            cmbMap.Enabled = False
        End If
    End Sub

    Private Sub OptTask5_CheckedChanged(sender As Object, e As EventArgs) Handles optTask5.CheckedChanged
        If optTask5.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 5
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOGIVE
            LoadTask(EditorIndex, SelectedTask)
            cmbItem.Enabled = True
        Else
            cmbItem.Enabled = False
        End If
    End Sub

    Private Sub OptTask6_CheckedChanged(sender As Object, e As EventArgs) Handles optTask6.CheckedChanged
        If optTask6.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 6
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOTRAIN
            LoadTask(EditorIndex, SelectedTask)
            cmbResource.Enabled = True
        Else
            cmbResource.Enabled = False
        End If
    End Sub

    Private Sub OptTask7_CheckedChanged(sender As Object, e As EventArgs) Handles optTask7.CheckedChanged
        If optTask7.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).Order = 7
            Quest(EditorIndex).Task(SelectedTask).TaskType = QUEST_TYPE_GOGET
            LoadTask(EditorIndex, SelectedTask)
            cmbNpc.Enabled = True
        Else
            cmbNpc.Enabled = False
        End If
    End Sub
#End Region

#Region "Requirements"
    Private Sub BtnAddRequirement_Click(sender As Object, e As EventArgs) Handles btnAddRequirement.Click
        Quest(EditorIndex).ReqCount = Quest(EditorIndex).ReqCount + 1

        ReDim Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount)
        ReDim Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount)

        fraRequirements.Visible = True
        fraRequirements.BringToFront()
    End Sub

    Private Sub BtnRemoveRequirement_Click(sender As Object, e As EventArgs) Handles btnRemoveRequirement.Click
        Dim i As Integer, tmpRequirement() As Integer, tmpRequirementIndex() As Integer

        If lstRequirements.SelectedIndex < 0 Then Exit Sub

        ReDim tmpRequirement(Quest(EditorIndex).ReqCount - 1)
        ReDim tmpRequirementIndex(Quest(EditorIndex).ReqCount - 1)

        For i = 1 To Quest(EditorIndex).ReqCount
            If Not i = lstRequirements.SelectedIndex + 1 Then
                tmpRequirement(i) = Quest(EditorIndex).Requirement(i)
                tmpRequirementIndex(i) = Quest(EditorIndex).RequirementIndex(i)
            End If
        Next

        Quest(EditorIndex).ReqCount = Quest(EditorIndex).ReqCount - 1

        ReDim Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount)
        ReDim Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount)

        For i = 1 To Quest(EditorIndex).ReqCount
            If Not i = lstRequirements.SelectedIndex + 1 Then
                Quest(EditorIndex).Requirement(i) = tmpRequirement(i)
                Quest(EditorIndex).RequirementIndex(i) = tmpRequirementIndex(i)
            End If
        Next

        lstRequirements.Items.Clear()
        For i = 1 To Quest(EditorIndex).ReqCount
            Select Case Quest(EditorIndex).Requirement(i)
                Case 1
                    lstRequirements.Items.Add(i & ":" & "Item Requirement: " & Trim(Item(Quest(EditorIndex).RequirementIndex(i)).Name))
                Case 2
                    lstRequirements.Items.Add(i & ":" & "Quest Requirement: " & Trim(Quest(Quest(EditorIndex).RequirementIndex(i)).Name))
                Case 3
                    lstRequirements.Items.Add(i & ":" & "Class Requirement: " & Trim(Classes(Quest(EditorIndex).RequirementIndex(i)).Name))
                Case Else
                    lstRequirements.Items.Add(i & ":")
            End Select

        Next
    End Sub

    Private Sub LstRequirements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRequirements.SelectedIndexChanged
        If lstRequirements.SelectedIndex < 0 Then Exit Sub

        LoadRequirement(EditorIndex, lstRequirements.SelectedIndex + 1)
        fraRequirements.Visible = True
        fraRequirements.BringToFront()
    End Sub

    Private Sub BtnRequirementSave_Click(sender As Object, e As EventArgs) Handles btnRequirementSave.Click
        If rdbNoneReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 0
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = 0
        ElseIf rdbItemReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 1
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = cmbItemReq.SelectedIndex
        ElseIf rdbQuestReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 2
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = cmbQuestReq.SelectedIndex
        ElseIf rdbClassReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 3
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = cmbClassReq.SelectedIndex
        End If

        lstRequirements.Items.Clear()
        For i = 1 To Quest(EditorIndex).ReqCount
            Select Case Quest(EditorIndex).Requirement(i)
                Case 1
                    lstRequirements.Items.Add(i & ":" & "Item Requirement: " & Trim(Item(Quest(EditorIndex).RequirementIndex(i)).Name))
                Case 2
                    lstRequirements.Items.Add(i & ":" & "Quest Requirement: " & Trim(Quest(Quest(EditorIndex).RequirementIndex(i)).Name))
                Case 3
                    lstRequirements.Items.Add(i & ":" & "Class Requirement: " & Trim(Classes(Quest(EditorIndex).RequirementIndex(i)).Name))
                Case Else
                    lstRequirements.Items.Add(i & ":")
            End Select

        Next

        fraRequirements.Visible = False
    End Sub

    Private Sub BtnRequirementCancel_Click(sender As Object, e As EventArgs) Handles btnRequirementCancel.Click
        fraRequirements.Visible = False
    End Sub

    Private Sub RdbNoneReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoneReq.CheckedChanged
        cmbItemReq.SelectedIndex = 0
        cmbItemReq.Enabled = False

        cmbQuestReq.SelectedIndex = 0
        cmbQuestReq.Enabled = False

        cmbClassReq.SelectedIndex = 0
        cmbClassReq.Enabled = False
    End Sub

    Private Sub RdbItemReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbItemReq.CheckedChanged
        cmbItemReq.Enabled = True
    End Sub

    Private Sub RdbQuestReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbQuestReq.CheckedChanged
        cmbQuestReq.Enabled = True
    End Sub

    Private Sub RdbClassReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbClassReq.CheckedChanged
        cmbClassReq.Enabled = True
    End Sub

#End Region
End Class