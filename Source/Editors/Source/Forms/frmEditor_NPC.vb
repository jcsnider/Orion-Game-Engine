Public Class FrmEditor_Npc
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

#Region "Form Code"
    Private Sub FrmEditor_NPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudSprite.Maximum = NumCharacters

        cmbItem.Items.Clear()
        cmbItem.Items.Add("None")
        For i = 1 To MAX_ITEMS
            cmbItem.Items.Add(i & ": " & Item(i).Name)
        Next
    End Sub

    Private Sub LstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        NpcEditorInit()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        NpcEditorOk()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        If EditorIndex <= 0 Then Exit Sub

        ClearNpc(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Npc(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        NpcEditorInit()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        NpcEditorCancel()
    End Sub

#End Region

#Region "Properties"
    Private Sub TxtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Npc(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Npc(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub TxtAttackSay_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAttackSay.TextChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).AttackSay = txtAttackSay.Text
    End Sub

    Private Sub NudSprite_ValueChanged(sender As Object, e As EventArgs) Handles nudSprite.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Sprite = nudSprite.Value

        EditorNpc_DrawSprite()
    End Sub

    Private Sub NudRange_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudRange.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Range = nudRange.Value
    End Sub

    Private Sub CmbBehavior_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBehaviour.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Behaviour = cmbBehaviour.SelectedIndex
    End Sub

    Private Sub CmbFaction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFaction.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Faction = cmbFaction.SelectedIndex
    End Sub

    Private Sub CmbAnimation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnimation.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Animation = cmbAnimation.SelectedIndex
    End Sub

    Private Sub NudSpawnSecs_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSpawnSecs.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).SpawnSecs = nudSpawnSecs.Value
    End Sub

    Private Sub NudHp_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudHp.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).HP = nudHp.Value
    End Sub

    Private Sub TxtEXP_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudExp.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).EXP = nudExp.Value
    End Sub

    Private Sub ScrlQuest_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbQuest.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).QuestNum = cmbQuest.SelectedIndex
    End Sub

    Private Sub NudLevel_ValueChanged(sender As Object, e As EventArgs) Handles nudLevel.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Level = nudLevel.Value
    End Sub

    Private Sub NudDamage_ValueChanged(sender As Object, e As EventArgs) Handles nudDamage.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Damage = nudDamage.Value
    End Sub
#End Region

#Region "Stats"
    Private Sub NudStrength_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudStrength.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Stat(Stats.Strength) = nudStrength.Value
    End Sub

    Private Sub NudEndurance_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudEndurance.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Stat(Stats.Endurance) = nudEndurance.Value
    End Sub

    Private Sub NudVitality_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudVitality.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Stat(Stats.Vitality) = nudVitality.Value
    End Sub

    Private Sub NudLuck_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLuck.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Stat(Stats.Luck) = nudLuck.Value
    End Sub

    Private Sub NudIntelligence_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudIntelligence.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Stat(Stats.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub NudSpirit_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSpirit.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Stat(Stats.Spirit) = nudSpirit.Value
    End Sub
#End Region

#Region "Drop Items"
    Private Sub CmbDropSlot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDropSlot.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        cmbItem.SelectedIndex = Npc(EditorIndex).DropItem(cmbDropSlot.SelectedIndex + 1)

        nudAmount.Value = Npc(EditorIndex).DropItemValue(cmbDropSlot.SelectedIndex + 1)

        nudChance.Value = Npc(EditorIndex).DropChance(cmbDropSlot.SelectedIndex + 1)
    End Sub

    Private Sub CmbItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbItem.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).DropItem(cmbDropSlot.SelectedIndex + 1) = cmbItem.SelectedIndex
    End Sub

    Private Sub ScrlValue_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudAmount.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).DropItemValue(cmbDropSlot.SelectedIndex + 1) = nudAmount.Value
    End Sub

    Private Sub NudChance_ValueChanged(sender As Object, e As EventArgs) Handles nudChance.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).DropChance(cmbDropSlot.SelectedIndex + 1) = nudChance.Value
    End Sub
#End Region

#Region "Skills"
    Private Sub CmbSkill1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill1.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(1) = cmbSkill1.SelectedIndex
    End Sub

    Private Sub CmbSkill2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill2.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(2) = cmbSkill2.SelectedIndex
    End Sub

    Private Sub CmbSkill3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill3.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(3) = cmbSkill3.SelectedIndex
    End Sub

    Private Sub CmbSkill4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill4.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(4) = cmbSkill4.SelectedIndex
    End Sub

    Private Sub CmbSkill5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill5.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(5) = cmbSkill5.SelectedIndex
    End Sub

    Private Sub CmbSkill6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill6.SelectedIndexChanged
        If EditorIndex <= 0 Then Exit Sub

        Npc(EditorIndex).Skill(6) = cmbSkill6.SelectedIndex
    End Sub


#End Region

End Class