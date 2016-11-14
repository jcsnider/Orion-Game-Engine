Public Class frmEditor_Quest
    Private Sub frmEditor_Quest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 715

        fraRequirements.Location = fraText.Location
        fraRewards.Location = fraText.Location
        fraTasks.Location = fraText.Location

        scrlTotalTasks.Maximum = MAX_TASKS
        scrlNPC.Maximum = MAX_NPCS
        scrlItem.Maximum = MAX_ITEMS
        scrlMap.Maximum = MAX_MAPS
        scrlResource.Maximum = MAX_RESOURCES
        scrlAmount.Maximum = 999999
        scrlItemRec.Maximum = MAX_ITEMS
        scrlQuestRec.Maximum = MAX_QUESTS
        scrlStartItemName.Maximum = MAX_ITEMS
        scrlStartItemAmount.Maximum = Byte.MaxValue
        scrlEndItemName.Maximum = MAX_ITEMS
        scrlEndItemAmount.Maximum = Byte.MaxValue
        scrlItemRew1.Maximum = MAX_ITEMS
        scrlItemRewValue1.Maximum = 999999

        optSpeech.Checked = True
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

    Private Sub optSpeech_CheckedChanged(sender As Object, e As EventArgs) Handles optSpeech.CheckedChanged
        fraText.Visible = False
        fraRequirements.Visible = False
        fraRewards.Visible = False
        fraTasks.Visible = False

        If optSpeech.Checked = True Then
            fraText.Visible = True
        End If
    End Sub

    Private Sub optRequirements_CheckedChanged(sender As Object, e As EventArgs) Handles optRequirements.CheckedChanged
        fraText.Visible = False
        fraRequirements.Visible = False
        fraRewards.Visible = False
        fraTasks.Visible = False

        If optRequirements.Checked = True Then
            fraRequirements.Visible = True
        End If
    End Sub

    Private Sub optRewards_CheckedChanged(sender As Object, e As EventArgs) Handles optRewards.CheckedChanged
        fraText.Visible = False
        fraRequirements.Visible = False
        fraRewards.Visible = False
        fraTasks.Visible = False

        If optRewards.Checked = True Then
            fraRewards.Visible = True
        End If
    End Sub

    Private Sub optTasks_CheckedChanged(sender As Object, e As EventArgs) Handles optTasks.CheckedChanged
        fraText.Visible = False
        fraRequirements.Visible = False
        fraRewards.Visible = False
        fraTasks.Visible = False

        If optTasks.Checked = True Then
            fraTasks.Visible = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Len(Trim$(txtName.Text)) = 0 Then
            Call MsgBox("Name required.")
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

    Private Sub scrlItemRec_ValueChanged(sender As Object, e As EventArgs) Handles scrlItemRec.ValueChanged
        If scrlItemRec.Value = 0 Then
            lblItemReq.Text = "Item Requirement: None"
        Else
            lblItemReq.Text = "Item Requirement: " & Trim(Item(scrlItemRec.Value).Name)
        End If
        Quest(EditorIndex).Requirement(1) = scrlItemRec.Value
    End Sub

    Private Sub scrlQuestRec_ValueChanged(sender As Object, e As EventArgs) Handles scrlQuestRec.ValueChanged
        If scrlQuestRec.Value = 0 Then
            lblQuestRec.Text = "Quest Requirement: None"
        Else
            lblQuestRec.Text = "Quest Requirement: " & Trim(Quest(scrlQuestRec.Value).Name)
        End If
        Quest(EditorIndex).Requirement(2) = scrlQuestRec.Value
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

    Private Sub sscrlEndItemAmount_ValueChanged(sender As Object, e As EventArgs) Handles scrlEndItemAmount.ValueChanged
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

    Private Sub txtQuestLog_TextChanged(sender As Object, e As EventArgs) Handles txtQuestLog.TextChanged
        Quest(EditorIndex).QuestLog = Trim$(txtQuestLog.Text)
    End Sub

    Private Sub scrlTotalTasks_ValueChanged(sender As Object, e As EventArgs) Handles scrlTotalTasks.ValueChanged
        lblSelected.Text = "Selected Task: " & scrlTotalTasks.Value

        LoadTask(EditorIndex, scrlTotalTasks.Value)
    End Sub

    Private Sub txtSpeech_TextChanged(sender As Object, e As EventArgs) Handles txtSpeech.TextChanged
        Quest(EditorIndex).Task(scrlTotalTasks.Value).Speech = Trim$(txtSpeech.Text)
    End Sub

    Private Sub txtTaskLog_TextChanged(sender As Object, e As EventArgs) Handles txtTaskLog.TextChanged
        Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskLog = Trim$(txtTaskLog.Text)
    End Sub

    Private Sub scrlNPC_ValueChanged(sender As Object, e As EventArgs) Handles scrlNPC.ValueChanged
        lblNpc.Text = "NPC: " & Npc(scrlNPC.Value).Name
        Quest(EditorIndex).Task(scrlTotalTasks.Value).Npc = scrlNPC.Value
    End Sub

    Private Sub scrlItem_ValueChanged(sender As Object, e As EventArgs) Handles scrlItem.ValueChanged
        lblItem.Text = "Item: " & Item(scrlItem.Value).Name
        Quest(EditorIndex).Task(scrlTotalTasks.Value).Item = scrlItem.Value
    End Sub

    Private Sub scrlMap_ValueChanged(sender As Object, e As EventArgs) Handles scrlMap.ValueChanged
        lblMap.Text = "Map: " & scrlMap.Value & " " & MapNames(scrlMap.Value)
        Quest(EditorIndex).Task(scrlTotalTasks.Value).Map = scrlMap.Value
    End Sub

    Private Sub scrlResource_ValueChanged(sender As Object, e As EventArgs) Handles scrlResource.ValueChanged
        lblResource.Text = "Resource: " & Resource(scrlResource.Value).Name
        Quest(EditorIndex).Task(scrlTotalTasks.Value).Resource = scrlResource.Value
    End Sub

    Private Sub scrlAmount_ValueChanged(sender As Object, e As EventArgs) Handles scrlAmount.ValueChanged
        lblAmount.Text = "Amount: " & scrlAmount.Value
        Quest(EditorIndex).Task(scrlTotalTasks.Value).Amount = scrlAmount.Value
    End Sub

    Private Sub chkEnd_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnd.CheckedChanged
        If chkEnd.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).QuestEnd = True
        Else
            Quest(EditorIndex).Task(scrlTotalTasks.Value).QuestEnd = False
        End If
    End Sub

    Private Sub optTask0_CheckedChanged(sender As Object, e As EventArgs) Handles optTask0.CheckedChanged
        If optTask0.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 0
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = 0
            LoadTask(EditorIndex, scrlTotalTasks.Value)
        End If
    End Sub

    Private Sub optTask1_CheckedChanged(sender As Object, e As EventArgs) Handles optTask1.CheckedChanged
        If optTask1.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 1
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOSLAY
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlNPC.Enabled = True
        Else
            scrlNPC.Enabled = False
        End If
    End Sub

    Private Sub optTask2_CheckedChanged(sender As Object, e As EventArgs) Handles optTask2.CheckedChanged
        If optTask2.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 2
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOGATHER
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlItem.Enabled = True
        Else
            scrlItem.Enabled = False
        End If
    End Sub

    Private Sub optTask3_CheckedChanged(sender As Object, e As EventArgs) Handles optTask3.CheckedChanged
        If optTask3.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 3
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOTALK
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlNPC.Enabled = True
        Else
            scrlNPC.Enabled = False
        End If
    End Sub

    Private Sub optTask4_CheckedChanged(sender As Object, e As EventArgs) Handles optTask4.CheckedChanged
        If optTask4.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 4
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOREACH
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlMap.Enabled = True
        Else
            scrlMap.Enabled = False
        End If
    End Sub

    Private Sub optTask5_CheckedChanged(sender As Object, e As EventArgs) Handles optTask5.CheckedChanged
        If optTask5.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 5
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOGIVE
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlItem.Enabled = True
        Else
            scrlItem.Enabled = False
        End If
    End Sub

    Private Sub optTask6_CheckedChanged(sender As Object, e As EventArgs) Handles optTask6.CheckedChanged
        If optTask6.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 6
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOTRAIN
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlResource.Enabled = True
        Else
            scrlResource.Enabled = False
        End If
    End Sub

    Private Sub optTask7_CheckedChanged(sender As Object, e As EventArgs) Handles optTask7.CheckedChanged
        If optTask7.Checked = True Then
            Quest(EditorIndex).Task(scrlTotalTasks.Value).Order = 7
            Quest(EditorIndex).Task(scrlTotalTasks.Value).TaskType = QUEST_TYPE_GOGET
            LoadTask(EditorIndex, scrlTotalTasks.Value)
            scrlNPC.Enabled = True
        Else
            scrlNPC.Enabled = False
        End If
    End Sub

    Private Sub scrlExpReward_ValueChanged(sender As Object, e As EventArgs) Handles scrlExpReward.ValueChanged
        lblExpReward.Text = "Experience Gained: " & scrlExpReward.Value
        Quest(EditorIndex).RewardExp = scrlExpReward.Value
    End Sub
End Class