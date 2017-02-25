Public Class frmEditor_Skill

    Private Sub TxtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Skill(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Skill(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub CmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        Skill(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub NudMp_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudMp.ValueChanged
        Skill(EditorIndex).MpCost = nudMp.Value
    End Sub

    Private Sub NudLevel_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLevel.ValueChanged
        Skill(EditorIndex).LevelReq = nudLevel.Value
    End Sub

    Private Sub CmbAccessReq_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAccessReq.SelectedIndexChanged
        Skill(EditorIndex).AccessReq = cmbAccessReq.SelectedIndex
    End Sub

    Private Sub CmbClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClass.SelectedIndexChanged
        Skill(EditorIndex).ClassReq = cmbClass.SelectedIndex
    End Sub

    Private Sub NudCast_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudCast.ValueChanged
        Skill(EditorIndex).CastTime = nudCast.Value
    End Sub

    Private Sub NudCool_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudCool.ValueChanged
        Skill(EditorIndex).CdTime = nudCool.Value
    End Sub

    Private Sub NudIcon_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudIcon.ValueChanged

        Skill(EditorIndex).Icon = nudIcon.Value
        EditorSkill_BltIcon()
    End Sub

    Private Sub NudMap_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudMap.ValueChanged
        Skill(EditorIndex).Map = nudMap.Value
    End Sub

    Private Sub CmbDir_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDir.SelectedIndexChanged
        Skill(EditorIndex).Dir = cmbDir.SelectedIndex
    End Sub

    Private Sub NudX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudX.ValueChanged
        Skill(EditorIndex).X = nudX.Value
    End Sub

    Private Sub NudY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudY.ValueChanged
        Skill(EditorIndex).Y = nudY.Value
    End Sub

    Private Sub NudVital_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudVital.ValueChanged
        Skill(EditorIndex).Vital = nudVital.Value
    End Sub

    Private Sub NudDuration_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudDuration.ValueChanged
        Skill(EditorIndex).Duration = nudDuration.Value
    End Sub

    Private Sub NudInterval_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudInterval.ValueChanged
        Skill(EditorIndex).Interval = nudInterval.Value
    End Sub

    Private Sub NudRange_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudRange.ValueChanged
        Skill(EditorIndex).Range = nudRange.Value
    End Sub

    Private Sub ChkAOE_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkAoE.CheckedChanged
        If chkAoE.Checked = False Then
            Skill(EditorIndex).IsAoE = False
        Else
            Skill(EditorIndex).IsAoE = True
        End If
    End Sub

    Private Sub NudAoE_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudAoE.ValueChanged
        Skill(EditorIndex).AoE = nudAoE.Value
    End Sub

    Private Sub CmbAnimCast_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAnimCast.SelectedIndexChanged
        Skill(EditorIndex).CastAnim = cmbAnimCast.SelectedIndex
    End Sub

    Private Sub CmbAnim_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAnim.SelectedIndexChanged
        Skill(EditorIndex).SkillAnim = cmbAnim.SelectedIndex
    End Sub

    Private Sub NudStun_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudStun.ValueChanged
        Skill(EditorIndex).StunDuration = nudStun.Value
    End Sub

    Private Sub LstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        SkillEditorInit()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        SkillEditorOk()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        ClearSkill(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Skill(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        SkillEditorInit()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        SkillEditorCancel()
    End Sub

    Private Sub FrmEditor_Skill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudIcon.Maximum = NumSkillIcons
        nudCast.Value = 1
    End Sub

    Private Sub ChkProjectile_CheckedChanged(sender As Object, e As EventArgs) Handles chkProjectile.CheckedChanged
        If chkProjectile.Checked = False Then
            Skill(EditorIndex).IsProjectile = 0
        Else
            Skill(EditorIndex).IsProjectile = 1
        End If
    End Sub

    Private Sub ScrlProjectile_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProjectile.SelectedIndexChanged
        Skill(EditorIndex).Projectile = cmbProjectile.SelectedIndex
    End Sub

    Private Sub ChkKnockBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkKnockBack.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_SKILLS Then Exit Sub

        If chkKnockBack.Checked = True Then
            Skill(EditorIndex).KnockBack = 1
        Else
            Skill(EditorIndex).KnockBack = 0
        End If
    End Sub

    Private Sub CmbKnockBackTiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKnockBackTiles.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_SKILLS Then Exit Sub

        Skill(EditorIndex).KnockBackTiles = cmbKnockBackTiles.SelectedIndex
    End Sub
End Class