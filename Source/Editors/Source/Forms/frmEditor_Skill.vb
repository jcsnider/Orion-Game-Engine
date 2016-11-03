Public Class frmEditor_Skill
    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Skill(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Skill(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        Skill(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub scrlMP_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMP.ValueChanged
        If scrlMP.Value > 0 Then
            lblMP.Text = "MP Cost: " & scrlMP.Value
        Else
            lblMP.Text = "MP Cost: None"
        End If
        Skill(EditorIndex).MPCost = scrlMP.Value
    End Sub

    Private Sub scrlLevel_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLevel.ValueChanged
        If scrlLevel.Value > 0 Then
            lblLevel.Text = "Level Required: " & scrlLevel.Value
        Else
            lblLevel.Text = "Level Required: None"
        End If
        Skill(EditorIndex).LevelReq = scrlLevel.Value
    End Sub

    Private Sub scrlAccess_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAccess.ValueChanged
        If scrlAccess.Value > 0 Then
            lblAccess.Text = "Access Required: " & scrlAccess.Value
        Else
            lblAccess.Text = "Access Required: None"
        End If
        Skill(EditorIndex).AccessReq = scrlAccess.Value
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClass.SelectedIndexChanged
        Skill(EditorIndex).ClassReq = cmbClass.SelectedIndex
    End Sub

    Private Sub scrlCast_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlCast.ValueChanged
        lblCast.Text = "Casting Time: " & scrlCast.Value & "s"
        Skill(EditorIndex).CastTime = scrlCast.Value
    End Sub

    Private Sub scrlCool_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlCool.ValueChanged
        lblCool.Text = "Cooldown Time: " & scrlCool.Value & "s"
        Skill(EditorIndex).CDTime = scrlCool.Value
    End Sub

    Private Sub scrlIcon_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlIcon.ValueChanged
        If scrlIcon.Value > 0 Then
            lblIcon.Text = "Icon: " & scrlIcon.Value
        Else
            lblIcon.Text = "Icon: None"
        End If
        Skill(EditorIndex).Icon = scrlIcon.Value
        EditorSkill_BltIcon()
    End Sub

    Private Sub scrlMap_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMap.ValueChanged
        lblMap.Text = "Map: " & scrlMap.Value
        Skill(EditorIndex).Map = scrlMap.Value
    End Sub

    Private Sub scrlDir_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlDir.ValueChanged
        Dim sDir As String
        sDir = ""
        Select Case scrlDir.Value
            Case Direction.Up
                sDir = "Up"
            Case Direction.Down
                sDir = "Down"
            Case Direction.Right
                sDir = "Right"
            Case Direction.Left
                sDir = "Left"
        End Select
        lblDir.Text = "Dir: " & sDir
        Skill(EditorIndex).Dir = scrlDir.Value
    End Sub

    Private Sub scrlX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlX.ValueChanged
        lblX.Text = "X: " & scrlX.Value
        Skill(EditorIndex).X = scrlX.Value
    End Sub

    Private Sub scrlY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlY.ValueChanged
        lblY.Text = "Y: " & scrlY.Value
        Skill(EditorIndex).Y = scrlY.Value
    End Sub

    Private Sub scrlVital_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlVital.ValueChanged
        lblVital.Text = "Vital: " & scrlVital.Value
        Skill(EditorIndex).Vital = scrlVital.Value
    End Sub

    Private Sub scrlDuration_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlDuration.ValueChanged
        lblDuration.Text = "Duration: " & scrlDuration.Value & "s"
        Skill(EditorIndex).Duration = scrlDuration.Value
    End Sub

    Private Sub scrlInterval_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlInterval.ValueChanged
        lblInterval.Text = "Interval: " & scrlInterval.Value & "s"
        Skill(EditorIndex).Interval = scrlInterval.Value
    End Sub

    Private Sub scrlRange_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRange.ValueChanged
        If scrlRange.Value > 0 Then
            lblRange.Text = "Range: " & scrlRange.Value & " tiles."
        Else
            lblRange.Text = "Range: Self-cast"
        End If
        Skill(EditorIndex).Range = scrlRange.Value
    End Sub

    Private Sub chkAOE_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkAOE.CheckedChanged
        If chkAOE.Checked = False Then
            Skill(EditorIndex).IsAoE = False
        Else
            Skill(EditorIndex).IsAoE = True
        End If
    End Sub

    Private Sub scrlAOE_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAOE.ValueChanged
        If scrlAOE.Value > 0 Then
            lblAOE.Text = "AoE: " & scrlAOE.Value & " tiles."
        Else
            lblAOE.Text = "AoE: Self-cast"
        End If
        Skill(EditorIndex).AoE = scrlAOE.Value
    End Sub

    Private Sub scrlAnimCast_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnimCast.ValueChanged
        If scrlAnimCast.Value > 0 Then
            lblAnimCast.Text = "Cast Anim: " & Trim$(Animation(scrlAnimCast.Value).Name)
        Else
            lblAnimCast.Text = "Cast Anim: None"
        End If
        Skill(EditorIndex).CastAnim = scrlAnimCast.Value
    End Sub

    Private Sub scrlAnim_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnim.ValueChanged
        If scrlAnim.Value > 0 Then
            lblAnim.Text = "Animation: " & Trim$(Animation(scrlAnim.Value).Name)
        Else
            lblAnim.Text = "Animation: None"
        End If
        Skill(EditorIndex).SkillAnim = scrlAnim.Value
    End Sub

    Private Sub scrlStun_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlStun.ValueChanged
        If scrlStun.Value > 0 Then
            lblStun.Text = "Stun Duration: " & scrlStun.Value & "s"
        Else
            lblStun.Text = "Stun Duration: None"
        End If
        Skill(EditorIndex).StunDuration = scrlStun.Value
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        SkillEditorInit()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        SkillEditorOk()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        ClearSkill(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Skill(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        SkillEditorInit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        SkillEditorCancel()
    End Sub

    Private Sub frmEditor_Skill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrlIcon.Maximum = NumSkillIcons
        scrlCast.Value = 1
    End Sub

    Private Sub chkProjectile_CheckedChanged(sender As Object, e As EventArgs) Handles chkProjectile.CheckedChanged
        If chkProjectile.Checked = False Then
            Skill(EditorIndex).IsProjectile = 0
        Else
            Skill(EditorIndex).IsProjectile = 1
        End If
    End Sub

    Private Sub scrlProjectile_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlProjectile.ValueChanged, scrlProjectile.Scroll
        If scrlProjectile.Value > 0 Then
            lblProjectile.Text = "Projectile: " & scrlProjectile.Value & " " & Trim$(Projectiles(scrlProjectile.Value).Name)
        Else
            lblProjectile.Text = "Projectile: 0 None"
        End If
        Skill(EditorIndex).Projectile = scrlProjectile.Value
    End Sub

    Private Sub chkKnockBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkKnockBack.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_SKILLS Then Exit Sub

        If chkKnockBack.Checked = True Then
            Skill(EditorIndex).KnockBack = 1
        Else
            Skill(EditorIndex).KnockBack = 0
        End If
    End Sub

    Private Sub cmbKnockBackTiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKnockBackTiles.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_SKILLS Then Exit Sub

        Skill(EditorIndex).KnockBackTiles = cmbKnockBackTiles.SelectedIndex
    End Sub
End Class