Public Class frmEditor_NPC
    Private Sub scrlSprite_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSprite.ValueChanged, scrlSprite.Scroll
        If EditorIndex <= 0 Then Exit Sub

        lblSprite.Text = "Sprite: " & scrlSprite.Value
        EditorNpc_DrawSprite()
        Npc(EditorIndex).Sprite = scrlSprite.Value
    End Sub

    Private Sub scrlRange_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRange.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblRange.Text = "Range: " & scrlRange.Value
        Npc(EditorIndex).Range = scrlRange.Value
    End Sub

    Private Sub cmbBehavior_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBehaviour.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Behaviour = cmbBehaviour.SelectedIndex
    End Sub

    Private Sub cmbFaction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFaction.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Faction = cmbFaction.SelectedIndex
    End Sub

    Private Sub scrlAnimation_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnimation.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Dim sString As String
        If scrlAnimation.Value = 0 Then sString = "None" Else sString = Trim$(Animation(scrlAnimation.Value).Name)
        lblAnimation.Text = "Anim: " & sString
        Npc(EditorIndex).Animation = scrlAnimation.Value
    End Sub

    Private Sub scrlStr_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlStr.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblStr.Text = "Str: " & scrlStr.Value
        Npc(EditorIndex).Stat(Stats.strength) = scrlStr.Value
    End Sub

    Private Sub scrlEnd_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlEnd.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblEnd.Text = "End: " & scrlEnd.Value
        Npc(EditorIndex).Stat(Stats.endurance) = scrlEnd.Value
    End Sub

    Private Sub scrlVit_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlVit.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblVit.Text = "Vit: " & scrlVit.Value
        Npc(EditorIndex).Stat(Stats.vitality) = scrlVit.Value
    End Sub

    Private Sub scrlLuck_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLuck.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblLuck.Text = "Luck: " & scrlLuck.Value
        Npc(EditorIndex).Stat(Stats.luck) = scrlLuck.Value
    End Sub

    Private Sub scrlInt_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlInt.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblInt.Text = "Int: " & scrlInt.Value
        Npc(EditorIndex).Stat(Stats.intelligence) = scrlInt.Value
    End Sub

    Private Sub scrlSpr_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSpr.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblSpr.Text = "Spr: " & scrlSpr.Value
        Npc(EditorIndex).Stat(Stats.spirit) = scrlSpr.Value
    End Sub

    Private Sub scrlNum_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlNum.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        If scrlNum.Value > 0 Then
            lblItemName.Text = "Item: " & Trim$(Item(scrlNum.Value).Name)
        Else
            lblItemName.Text = "Item: "
        End If

        Npc(EditorIndex).DropItem(cmbDropSlot.SelectedIndex + 1) = scrlNum.Value
    End Sub

    Private Sub scrlValue_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlValue.ValueChanged
        If EditorIndex <= 0 Then Exit Sub
        lblValue.Text = "Value: " & scrlValue.Value
        Npc(EditorIndex).DropItemValue(cmbDropSlot.SelectedIndex + 1) = scrlValue.Value
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        NpcEditorInit()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        NpcEditorOk()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        If EditorIndex <= 0 Then Exit Sub

        ClearNpc(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Npc(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        NpcEditorInit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        NpcEditorCancel()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long

        If EditorIndex = 0 Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Npc(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Npc(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub txtSpawnSecs_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSpawnSecs.TextChanged
        If EditorIndex <= 0 Then Exit Sub

        If IsNumeric(txtSpawnSecs.Text) Then Npc(EditorIndex).SpawnSecs = txtSpawnSecs.Text
    End Sub

    Private Sub txtAttackSay_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAttackSay.TextChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).AttackSay = txtAttackSay.Text
    End Sub

    Private Sub txtHP_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtHP.TextChanged
        If EditorIndex <= 0 Then Exit Sub

        If IsNumeric(txtHP.Text) Then Npc(EditorIndex).HP = txtHP.Text
    End Sub

    Private Sub txtEXP_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtEXP.TextChanged
        If EditorIndex <= 0 Then Exit Sub

        If IsNumeric(txtEXP.Text) Then Npc(EditorIndex).EXP = txtEXP.Text
    End Sub

    Private Sub txtChance_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtChance.TextChanged
        If EditorIndex <= 0 Then Exit Sub

        If IsNumeric(txtChance.Text) Then Npc(EditorIndex).DropChance(cmbDropSlot.SelectedIndex + 1) = txtChance.Text
    End Sub

    Private Sub scrlQuest_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scrlQuest.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        lblQuest.Text = "Quest: " & scrlQuest.Value
        Npc(EditorIndex).QuestNum = scrlQuest.Value
    End Sub

    Private Sub frmEditor_NPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrlSprite.Maximum = NumCharacters
    End Sub

    Private Sub cmbDropSlot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDropSlot.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        scrlNum.Value = Npc(EditorIndex).DropItem(cmbDropSlot.SelectedIndex + 1)

        If scrlNum.Value > 0 Then
            lblItemName.Text = "Item: " & Trim$(Item(scrlNum.Value).Name)
        End If
        scrlValue.Value = Npc(EditorIndex).DropItemValue(cmbDropSlot.SelectedIndex + 1)
        lblValue.Text = "Value: " & scrlValue.Value

        txtChance.Text = Npc(EditorIndex).DropChance(cmbDropSlot.SelectedIndex + 1)
    End Sub

    Private Sub cmbSkill1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill1.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(1) = cmbSkill1.SelectedIndex
    End Sub

    Private Sub cmbSkill2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill2.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(2) = cmbSkill2.SelectedIndex
    End Sub

    Private Sub cmbSkill3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill3.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(3) = cmbSkill3.SelectedIndex
    End Sub

    Private Sub cmbSkill4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill4.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(4) = cmbSkill4.SelectedIndex
    End Sub

    Private Sub cmbSkill5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill5.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(5) = cmbSkill5.SelectedIndex
    End Sub

    Private Sub cmbSkill6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill6.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(6) = cmbSkill6.SelectedIndex
    End Sub
End Class