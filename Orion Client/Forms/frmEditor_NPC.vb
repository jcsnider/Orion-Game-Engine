Public Class frmEditor_NPC
    Private Sub scrlSprite_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlSprite.ValueChanged
        lblSprite.Text = "Sprite: " & scrlSprite.Value
        Call EditorNpc_DrawSprite()
        Npc(EditorIndex).Sprite = scrlSprite.Value
    End Sub

    Private Sub scrlRange_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlRange.ValueChanged
        lblRange.Text = "Range: " & scrlRange.Value
        Npc(EditorIndex).Range = scrlRange.Value
    End Sub

    Private Sub cmbBehavior_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBehaviour.SelectedIndexChanged
        Npc(EditorIndex).Behaviour = cmbBehaviour.SelectedIndex
    End Sub

    Private Sub cmbFaction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFaction.SelectedIndexChanged
        Npc(EditorIndex).faction = cmbFaction.SelectedIndex
    End Sub

    Private Sub scrlAnimation_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAnimation.ValueChanged
        Dim sString As String
        If scrlAnimation.Value = 0 Then sString = "None" Else sString = Trim$(Animation(scrlAnimation.Value).Name)
        lblAnimation.Text = "Anim: " & sString
        Npc(EditorIndex).Animation = scrlAnimation.Value
    End Sub

    Private Sub scrlStr_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlStr.ValueChanged
        lblStr.Text = "Str: " & scrlStr.Value
        Npc(EditorIndex).Stat(Stats.strength) = scrlStr.Value
    End Sub

    Private Sub scrlEnd_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlEnd.ValueChanged
        lblEnd.Text = "End: " & scrlEnd.Value
        Npc(EditorIndex).Stat(Stats.endurance) = scrlEnd.Value
    End Sub

    Private Sub scrlVit_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlVit.ValueChanged
        lblVit.Text = "Vit: " & scrlVit.Value
        Npc(EditorIndex).Stat(Stats.vitality) = scrlVit.Value
    End Sub

    Private Sub scrlWill_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlWill.ValueChanged
        lblWill.Text = "Will: " & scrlWill.Value
        Npc(EditorIndex).Stat(Stats.willpower) = scrlWill.Value
    End Sub

    Private Sub scrlInt_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlInt.ValueChanged
        lblInt.Text = "Int: " & scrlInt.Value
        Npc(EditorIndex).Stat(Stats.intelligence) = scrlInt.Value
    End Sub

    Private Sub scrlSpr_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlSpr.ValueChanged
        lblSpr.Text = "Spr: " & scrlSpr.Value
        Npc(EditorIndex).Stat(Stats.spirit) = scrlSpr.Value
    End Sub

    Private Sub scrlNum_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlNum.ValueChanged
        lblNum.Text = "Num: " & scrlNum.Value

        If scrlNum.Value > 0 Then
            lblItemName.Text = "Item: " & Trim$(Item(scrlNum.Value).Name)
        End If

        Npc(EditorIndex).DropItem = scrlNum.Value
    End Sub

    Private Sub scrlValue_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlValue.ValueChanged
        lblValue.Text = "Value: " & scrlValue.Value
        Npc(EditorIndex).DropItemValue = scrlValue.Value
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstIndex.Click
        NpcEditorInit()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        NpcEditorOk()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        ClearResource(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Resource(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ResourceEditorInit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call NpcEditorCancel()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long
        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Npc(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Npc(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub txtSpawnSecs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSpawnSecs.TextChanged
        Npc(EditorIndex).SpawnSecs = txtSpawnSecs.Text
    End Sub

    Private Sub txtAttackSay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttackSay.TextChanged
        Npc(EditorIndex).AttackSay = txtAttackSay.Text
    End Sub

    Private Sub txtHP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHP.TextChanged
        If IsNumeric(txtHP.Text) Then Npc(EditorIndex).HP = txtHP.Text
    End Sub

    Private Sub txtEXP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEXP.TextChanged
        If IsNumeric(txtEXP.Text) Then Npc(EditorIndex).EXP = txtEXP.Text
    End Sub

    Private Sub txtChance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChance.TextChanged
        Npc(EditorIndex).DropChance = txtChance.Text
    End Sub
End Class