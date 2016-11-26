Public Class frmEditor_Quest
    Private Sub frmEditor_Quest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = 740

        fraRequirements.Location = fraGeneral.Location
        fraTasks.Location = fraGeneral.Location

        scrlNPC.Maximum = MAX_NPCS
        scrlItem.Maximum = MAX_ITEMS
        scrlMap.Maximum = MAX_MAPS
        scrlResource.Maximum = MAX_RESOURCES
        scrlAmount.Maximum = 999999
        scrlItemRec.Maximum = MAX_ITEMS
        scrlQuestRec.Maximum = MAX_QUESTS
        scrlClassRec.Maximum = Max_Classes
        scrlStartItemName.Maximum = MAX_ITEMS
        scrlStartItemAmount.Maximum = Byte.MaxValue
        scrlEndItemName.Maximum = MAX_ITEMS
        scrlEndItemAmount.Maximum = Byte.MaxValue
        scrlItemReward.Maximum = MAX_ITEMS
        scrlItemRewValue.Maximum = 999999

    End Sub

    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        QuestEditorInit()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Or EditorIndex > MAX_QUESTS Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Quest(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Quest(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Len(Trim$(txtName.Text)) = 0 Then
            MsgBox("Name required.")
        Else
            QuestEditorOk()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        QuestEditorCancel()
    End Sub

    Private Sub txtStartText_TextChanged(sender As Object, e As EventArgs) Handles txtStartText.TextChanged
        Quest(EditorIndex).Chat(1) = Trim$(txtStartText.Text)
    End Sub

    Private Sub txtProgressText_TextChanged(sender As Object, e As EventArgs) Handles txtProgressText.TextChanged
        Quest(EditorIndex).Chat(2) = Trim$(txtProgressText.Text)
    End Sub

    Private Sub txtEndText_TextChanged(sender As Object, e As EventArgs) Handles txtEndText.TextChanged
        Quest(EditorIndex).Chat(3) = Trim$(txtEndText.Text)
    End Sub

    Private Sub scrlStartItemName_ValueChanged(sender As Object, e As EventArgs) Handles scrlStartItemName.ValueChanged
        If scrlStartItemName.Value = 0 Then
            lblStartItem.Text = "Give Item on Start: None" & " (" & scrlStartItemAmount.Value & ")"
        Else
            lblStartItem.Text = "Give Item on Start: " & Trim(Item(scrlStartItemName.Value).Name) & " (" & scrlStartItemAmount.Value & ")"
        End If

        Quest(EditorIndex).QuestGiveItem = scrlStartItemName.Value
    End Sub

    Private Sub scrlEndItemName_ValueChanged(sender As Object, e As EventArgs) Handles scrlEndItemName.ValueChanged
        If scrlEndItemName.Value = 0 Then
            lblEnditem.Text = "Take Item on End: None" & " (" & scrlEndItemAmount.Value & ")"
        Else
            lblEnditem.Text = "Take Item on End: " & Trim(Item(scrlEndItemName.Value).Name) & " (" & scrlEndItemAmount.Value & ")"
        End If

        Quest(EditorIndex).QuestRemoveItem = scrlEndItemName.Value
    End Sub

    Private Sub scrlStartItemAmount_ValueChanged(sender As Object, e As EventArgs) Handles scrlStartItemAmount.ValueChanged
        If scrlStartItemName.Value = 0 Then
            lblStartItem.Text = "Give Item on Start: None" & " (" & scrlStartItemAmount.Value & ")"
        Else
            lblStartItem.Text = "Give Item on Start: " & Trim(Item(scrlStartItemName.Value).Name) & " (" & scrlStartItemAmount.Value & ")"
        End If
        Quest(EditorIndex).QuestGiveItemValue = scrlStartItemAmount.Value
    End Sub

    Private Sub scrlEndItemAmount_ValueChanged(sender As Object, e As EventArgs) Handles scrlEndItemAmount.ValueChanged
        If scrlEndItemName.Value = 0 Then
            lblEnditem.Text = "Take Item on End: None" & " (" & scrlEndItemAmount.Value & ")"
        Else
            lblEnditem.Text = "Take Item on End: " & Trim(Item(scrlEndItemName.Value).Name) & " (" & scrlEndItemAmount.Value & ")"
        End If
        Quest(EditorIndex).QuestRemoveItemValue = scrlEndItemAmount.Value
    End Sub

    Private Sub chkRepeat_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepeat.CheckedChanged
        If chkRepeat.Checked = True Then
            Quest(EditorIndex).Repeat = 1
        Else
            Quest(EditorIndex).Repeat = 0
        End If
    End Sub

#Region "Rewards"
    Private Sub scrlItemReward_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemReward.ValueChanged

        If scrlItemReward.Value = 0 Then
            lblItemReward.Text = "Item Reward: None" & " (" & scrlItemRewValue.Value & ")"
        Else
            lblItemReward.Text = "Item Reward: " & Trim(Item(scrlItemReward.Value).Name) & " (" & scrlItemRewValue.Value & ")"
        End If

    End Sub

    Private Sub scrlItemRewValue_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemRewValue.ValueChanged

        If scrlItemReward.Value = 0 Then
            lblItemReward.Text = "Item Reward: None" & " (" & scrlItemRewValue.Value & ")"
        Else
            lblItemReward.Text = "Item Reward: " & Trim(Item(scrlItemReward.Value).Name) & " (" & scrlItemRewValue.Value & ")"
        End If

    End Sub

    Private Sub scrlExpReward_ValueChanged(sender As Object, e As EventArgs) Handles scrlExpReward.ValueChanged
        lblExpReward.Text = "Experience Gained: " & scrlExpReward.Value
        Quest(EditorIndex).RewardExp = scrlExpReward.Value
    End Sub

    Private Sub btnAddReward_Click(sender As Object, e As EventArgs) Handles btnAddReward.Click
        Quest(EditorIndex).RewardCount = Quest(EditorIndex).RewardCount + 1

        ReDim Preserve Quest(EditorIndex).RewardItem(Quest(EditorIndex).RewardCount)
        ReDim Preserve Quest(EditorIndex).RewardItemAmount(Quest(EditorIndex).RewardCount)

        Quest(EditorIndex).RewardItem(Quest(EditorIndex).RewardCount) = scrlItemReward.Value
        Quest(EditorIndex).RewardItemAmount(Quest(EditorIndex).RewardCount) = scrlItemRewValue.Value

        lstRewards.Items.Clear()
        For i = 1 To Quest(EditorIndex).RewardCount
            lstRewards.Items.Add(i & ":" & Quest(EditorIndex).RewardItemAmount(i) & " X " & Trim(Item(Quest(EditorIndex).RewardItem(i)).Name))
        Next
    End Sub

    Private Sub btnRemoveReward_Click(sender As Object, e As EventArgs) Handles btnRemoveReward.Click

    End Sub
#End Region


#Region "Tasks"
    Private Sub lstTasks_DoubleClick(sender As Object, e As EventArgs) Handles lstTasks.DoubleClick
        If lstTasks.SelectedIndex < 0 Then Exit Sub

        LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
        fraTasks.Visible = True
        fraTasks.BringToFront()
    End Sub

    Private Sub btnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        Quest(EditorIndex).TaskCount = Quest(EditorIndex).TaskCount + 1

        ReDim Quest(EditorIndex).Task(Quest(EditorIndex).TaskCount)

        fraTasks.Visible = True
        fraTasks.BringToFront()
    End Sub

    Private Sub btnRemoveTask_Click(sender As Object, e As EventArgs) Handles btnRemoveTask.Click
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

    Private Sub btnSaveTask_Click(sender As Object, e As EventArgs) Handles btnSaveTask.Click
        Dim SelectedTask As Integer

        If lstTasks.SelectedIndex < 0 Then
            SelectedTask = Quest(EditorIndex).TaskCount
        Else
            SelectedTask = lstTasks.SelectedIndex + 1
        End If

        Quest(EditorIndex).Task(SelectedTask).TaskLog = Trim$(txtTaskLog.Text)
        Quest(EditorIndex).Task(SelectedTask).Speech = txtTaskSpeech.Text

        If chkEnd.Checked = True Then
            Quest(EditorIndex).Task(SelectedTask).QuestEnd = True
        Else
            Quest(EditorIndex).Task(SelectedTask).QuestEnd = False
        End If

        Quest(EditorIndex).Task(SelectedTask).Npc = scrlNPC.Value
        Quest(EditorIndex).Task(SelectedTask).Item = scrlItem.Value
        Quest(EditorIndex).Task(SelectedTask).Map = scrlMap.Value
        Quest(EditorIndex).Task(SelectedTask).Resource = scrlResource.Value
        Quest(EditorIndex).Task(SelectedTask).Amount = scrlAmount.Value

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

    Private Sub btnCancelTask_Click(sender As Object, e As EventArgs) Handles btnCancelTask.Click
        fraTasks.Visible = False
    End Sub

    Private Sub scrlNPC_ValueChanged(sender As Object, e As EventArgs) Handles scrlNPC.ValueChanged
        lblNpc.Text = "NPC: " & Npc(scrlNPC.Value).Name
    End Sub

    Private Sub scrlItem_ValueChanged(sender As Object, e As EventArgs) Handles scrlItem.ValueChanged
        lblItem.Text = "Item: " & Item(scrlItem.Value).Name
    End Sub

    Private Sub scrlMap_ValueChanged(sender As Object, e As EventArgs) Handles scrlMap.ValueChanged
        lblMap.Text = "Map: " & scrlMap.Value & " " & MapNames(scrlMap.Value)
    End Sub

    Private Sub scrlResource_ValueChanged(sender As Object, e As EventArgs) Handles scrlResource.ValueChanged
        lblResource.Text = "Resource: " & Resource(scrlResource.Value).Name
    End Sub

    Private Sub scrlAmount_ValueChanged(sender As Object, e As EventArgs) Handles scrlAmount.ValueChanged
        lblAmount.Text = "Amount: " & scrlAmount.Value
    End Sub

    Private Sub optTask0_CheckedChanged(sender As Object, e As EventArgs) Handles optTask0.CheckedChanged
        If optTask0.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 0
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = 0
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
        End If
    End Sub

    Private Sub optTask1_CheckedChanged(sender As Object, e As EventArgs) Handles optTask1.CheckedChanged
        If optTask1.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 1
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOSLAY
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlNPC.Enabled = True
        Else
            scrlNPC.Enabled = False
        End If
    End Sub

    Private Sub optTask2_CheckedChanged(sender As Object, e As EventArgs) Handles optTask2.CheckedChanged
        If optTask2.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 2
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOGATHER
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlItem.Enabled = True
        Else
            scrlItem.Enabled = False
        End If
    End Sub

    Private Sub optTask3_CheckedChanged(sender As Object, e As EventArgs) Handles optTask3.CheckedChanged
        If optTask3.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 3
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOTALK
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlNPC.Enabled = True
        Else
            scrlNPC.Enabled = False
        End If
    End Sub

    Private Sub optTask4_CheckedChanged(sender As Object, e As EventArgs) Handles optTask4.CheckedChanged
        If optTask4.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 4
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOREACH
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlMap.Enabled = True
        Else
            scrlMap.Enabled = False
        End If
    End Sub

    Private Sub optTask5_CheckedChanged(sender As Object, e As EventArgs) Handles optTask5.CheckedChanged
        If optTask5.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 5
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOGIVE
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlItem.Enabled = True
        Else
            scrlItem.Enabled = False
        End If
    End Sub

    Private Sub optTask6_CheckedChanged(sender As Object, e As EventArgs) Handles optTask6.CheckedChanged
        If optTask6.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 6
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOTRAIN
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlResource.Enabled = True
        Else
            scrlResource.Enabled = False
        End If
    End Sub

    Private Sub optTask7_CheckedChanged(sender As Object, e As EventArgs) Handles optTask7.CheckedChanged
        If optTask7.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Order = 7
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskType = QUEST_TYPE_GOGET
            LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
            scrlNPC.Enabled = True
        Else
            scrlNPC.Enabled = False
        End If
    End Sub
#End Region

#Region "Requirements"
    Private Sub btnAddRequirement_Click(sender As Object, e As EventArgs) Handles btnAddRequirement.Click
        Quest(EditorIndex).ReqCount = Quest(EditorIndex).ReqCount + 1

        ReDim Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount)
        ReDim Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount)

        fraRequirements.Visible = True
        fraRequirements.BringToFront()
    End Sub

    Private Sub btnRemoveRequirement_Click(sender As Object, e As EventArgs) Handles btnRemoveRequirement.Click
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

    Private Sub lstRequirements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRequirements.SelectedIndexChanged
        If lstRequirements.SelectedIndex < 0 Then Exit Sub

        LoadRequirement(EditorIndex, lstRequirements.SelectedIndex + 1)
        fraRequirements.Visible = True
        fraRequirements.BringToFront()
    End Sub

    Private Sub scrlItemRec_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemRec.ValueChanged
        If scrlItemRec.Value = 0 Then
            lblItemReq.Text = "Item Requirement: None"
        Else
            lblItemReq.Text = "Item Requirement: " & Trim(Item(scrlItemRec.Value).Name)
        End If
    End Sub

    Private Sub scrlQuestRec_ValueChanged(sender As Object, e As EventArgs) Handles scrlQuestRec.ValueChanged
        If scrlQuestRec.Value = 0 Then
            lblQuestRec.Text = "Quest Requirement: None"
        Else
            lblQuestRec.Text = "Quest Requirement: " & Trim(Quest(scrlQuestRec.Value).Name)
        End If
    End Sub

    Private Sub scrlClassRec_ValueChanged(sender As Object, e As ScrollEventArgs) Handles scrlClassRec.ValueChanged
        If scrlClassRec.Value = 0 Then
            lblClassRec.Text = "Class Requirement: None"
        Else
            lblClassRec.Text = "Class Requirement: " & Trim(Classes(scrlClassRec.Value).Name)
        End If
    End Sub

    Private Sub btnRequirementSave_Click(sender As Object, e As EventArgs) Handles btnRequirementSave.Click
        If rdbNoneReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 0
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = 0
        ElseIf rdbItemReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 1
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = scrlItemRec.Value
        ElseIf rdbQuestReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 2
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = scrlQuestRec.Value
        ElseIf rdbClassReq.Checked = True Then
            Quest(EditorIndex).Requirement(Quest(EditorIndex).ReqCount) = 3
            Quest(EditorIndex).RequirementIndex(Quest(EditorIndex).ReqCount) = scrlClassRec.Value
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

    Private Sub btnRequirementCancel_Click(sender As Object, e As EventArgs) Handles btnRequirementCancel.Click
        fraRequirements.Visible = False
    End Sub

    Private Sub rdbNoneReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoneReq.CheckedChanged
        scrlItemRec.Value = 0
        scrlItemRec.Enabled = False

        scrlQuestRec.Value = 0
        scrlQuestRec.Enabled = False

        scrlClassRec.Value = 0
        scrlClassRec.Enabled = False
    End Sub

    Private Sub rdbItemReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbItemReq.CheckedChanged
        scrlItemRec.Enabled = True
    End Sub

    Private Sub rdbQuestReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbQuestReq.CheckedChanged
        scrlQuestRec.Enabled = True
    End Sub

    Private Sub rdbClassReq_CheckedChanged(sender As Object, e As EventArgs) Handles rdbClassReq.CheckedChanged
        scrlClassRec.Enabled = True
    End Sub

#End Region

End Class