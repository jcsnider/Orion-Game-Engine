Public Class frmEditor_Resource

    Private Sub scrlNormalPic_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlNormalPic.ValueChanged
        lblNormalPic.Text = "Normal Image: " & scrlNormalPic.Value
        EditorResource_DrawSprite()
        Resource(EditorIndex).ResourceImage = scrlNormalPic.Value
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        Resource(EditorIndex).ResourceType = cmbType.SelectedIndex
    End Sub

    Private Sub scrlExhaustedPic_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlExhaustedPic.ValueChanged
        lblExhaustedPic.Text = "Exhausted Image: " & scrlExhaustedPic.Value
        EditorResource_DrawSprite()
        Resource(EditorIndex).ExhaustedImage = scrlExhaustedPic.Value
    End Sub

    Private Sub scrlRewardItem_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRewardItem.ValueChanged
        If scrlRewardItem.Value > 0 Then
            lblRewardItem.Text = "Item Reward: " & Trim$(Item(scrlRewardItem.Value).Name)
        Else
            lblRewardItem.Text = "Item Reward: None"
        End If

        Resource(EditorIndex).ItemReward = scrlRewardItem.Value
    End Sub

    Private Sub scrlRewardExp_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRewardExp.ValueChanged
        If scrlRewardExp.Value > 0 Then
            lblRewardExp.Text = "Exp Reward: " & scrlRewardExp.Value
        Else
            lblRewardExp.Text = "Exp Reward: None"
        End If

        Resource(EditorIndex).ExpReward = scrlRewardExp.Value
    End Sub

    Private Sub scrlLvlReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLvlReq.ValueChanged
        If scrlLvlReq.Value > 0 Then
            lblLvlReq.Text = "Level Required: " & scrlLvlReq.Value
        Else
            lblLvlReq.Text = "level Required: None"
        End If

        Resource(EditorIndex).LvlRequired = scrlLvlReq.Value
    End Sub

    Private Sub cmbTool_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTool.SelectedIndexChanged
        Dim Name As String
        Name = ""

        Select Case cmbTool.SelectedIndex
            Case 0
                Name = "None"
            Case 1
                Name = "Hatchet"
            Case 2
                Name = "Rod"
            Case 3
                Name = "Pickaxe"
        End Select

        lblTool.Text = "Tool Required: " & Name

        Resource(EditorIndex).ToolRequired = cmbTool.SelectedIndex
    End Sub

    Private Sub scrlHealth_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlHealth.ValueChanged
        lblHealth.Text = "Health: " & scrlHealth.Value
        Resource(EditorIndex).Health = scrlHealth.Value
    End Sub

    Private Sub scrlRespawn_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRespawn.ValueChanged
        lblRespawn.Text = "Respawn Time (Seconds): " & scrlRespawn.Value
        Resource(EditorIndex).RespawnTime = scrlRespawn.Value
    End Sub

    Private Sub scrlAnim_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnimation.ValueChanged
        Dim sString As String
        If scrlAnimation.Value = 0 Then sString = "None" Else sString = Trim$(Animation(scrlAnimation.Value).Name)
        lblAnim.Text = "Animation: " & sString
        Resource(EditorIndex).Animation = scrlAnimation.Value
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        ResourceEditorInit()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        ResourceEditorOk()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        ClearResource(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Resource(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ResourceEditorInit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Call ResourceEditorCancel()
    End Sub

    Private Sub frmEditor_Resource_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        scrlRewardItem.Maximum = MAX_ITEMS
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long

        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Resource(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Resource(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub txtMessage_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMessage.TextChanged
        Resource(EditorIndex).SuccessMessage = Trim$(txtMessage.Text)
    End Sub

    Private Sub txtMessage2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMessage2.TextChanged
        Resource(EditorIndex).EmptyMessage = Trim$(txtMessage2.Text)
    End Sub


End Class