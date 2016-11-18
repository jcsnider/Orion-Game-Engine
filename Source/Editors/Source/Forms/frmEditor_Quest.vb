Public Class frmEditor_Quest
    Private Sub frmEditor_Quest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer

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
        scrlItemRew1.Maximum = MAX_ITEMS
        scrlItemRewValue1.Maximum = 999999

        lstRequirements.Items.Clear()
        For i = 1 To MAX_REQUIREMENTS
            lstRequirements.Items.Add(i & ":")
        Next

        lstTasks.Items.Clear()
        For i = 1 To MAX_TASKS
            lstTasks.Items.Add(i & ":")
        Next

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        ClearQuest(EditorIndex)
        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Quest(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
        QuestEditorInit()
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

    Private Sub scrlItemRew1_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemRew1.ValueChanged
        If scrlItemRew1.Value = 0 Then
            lblItemReward1.Text = "Item Reward: None" & " (" & scrlItemRewValue1.Value & ")"
        Else
            lblItemReward1.Text = "Item Reward: " & Trim(Item(scrlItemRew1.Value).Name) & " (" & scrlItemRewValue1.Value & ")"
        End If
        Quest(EditorIndex).RewardItem = scrlItemRew1.Value
    End Sub

    Private Sub scrlItemRew1Value_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemRewValue1.ValueChanged
        If scrlItemRew1.Value = 0 Then
            lblItemReward1.Text = "Item Reward: None" & " (" & scrlItemRewValue1.Value & ")"
        Else
            lblItemReward1.Text = "Item Reward: " & Trim(Item(scrlItemRew1.Value).Name) & " (" & scrlItemRewValue1.Value & ")"
        End If
        Quest(EditorIndex).RewardItemAmount = scrlItemRewValue1.Value
    End Sub

    Private Sub scrlExpReward_ValueChanged(sender As Object, e As EventArgs) Handles scrlExpReward.ValueChanged
        lblExpReward.Text = "Experience Gained: " & scrlExpReward.Value
        Quest(EditorIndex).RewardExp = scrlExpReward.Value
    End Sub

#Region "Tasks"
    Private Sub lstTasks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTasks.SelectedIndexChanged
        LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
        'fraTasks.Visible = True
    End Sub

    Private Sub btnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        fraTasks.Visible = True
    End Sub

    Private Sub btnRemoveTask_Click(sender As Object, e As EventArgs) Handles btnRemoveTask.Click
        LoadTask(EditorIndex, lstTasks.SelectedIndex + 1)
    End Sub

    Private Sub btnSaveTask_Click(sender As Object, e As EventArgs) Handles btnSaveTask.Click
        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).TaskLog = Trim$(txtTaskLog.Text)
        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Speech = txtTaskSpeech.Text

        If chkEnd.Checked = True Then
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).QuestEnd = True
        Else
            Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).QuestEnd = False
        End If

        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Npc = scrlNPC.Value
        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Item = scrlItem.Value
        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Map = scrlMap.Value
        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Resource = scrlResource.Value
        Quest(EditorIndex).Task(lstTasks.SelectedIndex + 1).Amount = scrlAmount.Value

        lstTasks.Items.Clear()
        For i = 1 To MAX_TASKS
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
        fraRequirements.Visible = True
        fraRequirements.BringToFront()
    End Sub

    Private Sub btnRemoveRequirement_Click(sender As Object, e As EventArgs) Handles btnRemoveRequirement.Click

    End Sub

    Private Sub lstRequirements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRequirements.SelectedIndexChanged

    End Sub

    Private Sub scrlItemRec_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemRec.ValueChanged
        If scrlItemRec.Value = 0 Then
            lblItemReq.Text = "Item Requirement: None"
        Else
            lblItemReq.Text = "Item Requirement: " & Trim(Item(scrlItemRec.Value).Name)
        End If
        Quest(EditorIndex).Requirement(lstRequirements.SelectedIndex + 1) = scrlItemRec.Value
    End Sub

    Private Sub scrlQuestRec_ValueChanged(sender As Object, e As EventArgs) Handles scrlQuestRec.ValueChanged
        If scrlQuestRec.Value = 0 Then
            lblQuestRec.Text = "Quest Requirement: None"
        Else
            lblQuestRec.Text = "Quest Requirement: " & Trim(Quest(scrlQuestRec.Value).Name)
        End If
        Quest(EditorIndex).Requirement(lstRequirements.SelectedIndex + 1) = scrlQuestRec.Value
    End Sub

    Private Sub scrlClassRec_ValueChanged(sender As Object, e As ScrollEventArgs) Handles scrlClassRec.ValueChanged
        If scrlClassRec.Value = 0 Then
            lblClassRec.Text = "Class Requirement: None"
        Else
            lblClassRec.Text = "Class Requirement: " & Trim(Classes(scrlClassRec.Value).Name)
        End If
        Quest(EditorIndex).Requirement(lstRequirements.SelectedIndex + 1) = scrlClassRec.Value
    End Sub

    Private Sub btnRequirementSave_Click(sender As Object, e As EventArgs) Handles btnRequirementSave.Click
        If rdbNoneReq.Checked = True Then

        End If
        lstRequirements.Items.Clear()
        For i = 1 To MAX_REQUIREMENTS
            lstRequirements.Items.Add(i & ":")
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