Public Class frmEditor_Spell

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long

        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Spell(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Spell(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        Spell(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub scrlMP_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMP.ValueChanged
        If scrlMP.Value > 0 Then
            lblMP.Text = "MP Cost: " & scrlMP.Value
        Else
            lblMP.Text = "MP Cost: None"
        End If
        Spell(EditorIndex).MPCost = scrlMP.Value
    End Sub

    Private Sub scrlLevel_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLevel.ValueChanged
        If scrlLevel.Value > 0 Then
            lblLevel.Text = "Level Required: " & scrlLevel.Value
        Else
            lblLevel.Text = "Level Required: None"
        End If
        Spell(EditorIndex).LevelReq = scrlLevel.Value
    End Sub

    Private Sub scrlAccess_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAccess.ValueChanged
        If scrlAccess.Value > 0 Then
            lblAccess.Text = "Access Required: " & scrlAccess.Value
        Else
            lblAccess.Text = "Access Required: None"
        End If
        Spell(EditorIndex).AccessReq = scrlAccess.Value
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClass.SelectedIndexChanged
        Spell(EditorIndex).ClassReq = cmbClass.SelectedIndex
    End Sub

    Private Sub scrlCast_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlCast.ValueChanged
        lblCast.Text = "Casting Time: " & scrlCast.Value & "s"
        Spell(EditorIndex).CastTime = scrlCast.Value
    End Sub

    Private Sub scrlCool_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlCool.ValueChanged
        lblCool.Text = "Cooldown Time: " & scrlCool.Value & "s"
        Spell(EditorIndex).CDTime = scrlCool.Value
    End Sub

    Private Sub scrlIcon_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlIcon.ValueChanged
        If scrlIcon.Value > 0 Then
            lblIcon.Text = "Icon: " & scrlIcon.Value
        Else
            lblIcon.Text = "Icon: None"
        End If
        Spell(EditorIndex).Icon = scrlIcon.Value
        EditorSpell_BltIcon()
    End Sub

    Private Sub scrlMap_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMap.ValueChanged
        lblMap.Text = "Map: " & scrlMap.Value
        Spell(EditorIndex).Map = scrlMap.Value
    End Sub

    Private Sub scrlDir_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlDir.ValueChanged
        Dim sDir As String
        sDir = ""
        Select Case scrlDir.Value
            Case DIR_UP
                sDir = "Up"
            Case DIR_DOWN
                sDir = "Down"
            Case DIR_RIGHT
                sDir = "Right"
            Case DIR_LEFT
                sDir = "Left"
        End Select
        lblDir.Text = "Dir: " & sDir
        Spell(EditorIndex).Dir = scrlDir.Value
    End Sub

    Private Sub scrlX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlX.ValueChanged
        lblX.Text = "X: " & scrlX.Value
        Spell(EditorIndex).X = scrlX.Value
    End Sub

    Private Sub scrlY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlY.ValueChanged
        lblY.Text = "Y: " & scrlY.Value
        Spell(EditorIndex).Y = scrlY.Value
    End Sub

    Private Sub scrlVital_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlVital.ValueChanged
        lblVital.Text = "Vital: " & scrlVital.Value
        Spell(EditorIndex).Vital = scrlVital.Value
    End Sub

    Private Sub scrlDuration_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlDuration.ValueChanged
        lblDuration.Text = "Duration: " & scrlDuration.Value & "s"
        Spell(EditorIndex).Duration = scrlDuration.Value
    End Sub

    Private Sub scrlInterval_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlInterval.ValueChanged
        lblInterval.Text = "Interval: " & scrlInterval.Value & "s"
        Spell(EditorIndex).Interval = scrlInterval.Value
    End Sub

    Private Sub scrlRange_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRange.ValueChanged
        If scrlRange.Value > 0 Then
            lblRange.Text = "Range: " & scrlRange.Value & " tiles."
        Else
            lblRange.Text = "Range: Self-cast"
        End If
        Spell(EditorIndex).Range = scrlRange.Value
    End Sub

    Private Sub chkAOE_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkAOE.CheckedChanged
        If chkAOE.Checked = False Then
            Spell(EditorIndex).IsAoE = False
        Else
            Spell(EditorIndex).IsAoE = True
        End If
    End Sub

    Private Sub scrlAOE_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAOE.ValueChanged
        If scrlAOE.Value > 0 Then
            lblAOE.Text = "AoE: " & scrlAOE.Value & " tiles."
        Else
            lblAOE.Text = "AoE: Self-cast"
        End If
        Spell(EditorIndex).AoE = scrlAOE.Value
    End Sub

    Private Sub scrlAnimCast_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnimCast.ValueChanged
        If scrlAnimCast.Value > 0 Then
            lblAnimCast.Text = "Cast Anim: " & Trim$(Animation(scrlAnimCast.Value).Name)
        Else
            lblAnimCast.Text = "Cast Anim: None"
        End If
        Spell(EditorIndex).CastAnim = scrlAnimCast.Value
    End Sub

    Private Sub scrlAnim_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnim.ValueChanged
        If scrlAnim.Value > 0 Then
            lblAnim.Text = "Animation: " & Trim$(Animation(scrlAnim.Value).Name)
        Else
            lblAnim.Text = "Animation: None"
        End If
        Spell(EditorIndex).SpellAnim = scrlAnim.Value
    End Sub

    Private Sub scrlStun_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlStun.ValueChanged
        If scrlStun.Value > 0 Then
            lblStun.Text = "Stun Duration: " & scrlStun.Value & "s"
        Else
            lblStun.Text = "Stun Duration: None"
        End If
        Spell(EditorIndex).StunDuration = scrlStun.Value
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        SpellEditorInit()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        SpellEditorOk()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        ClearSpell(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Spell(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        SpellEditorInit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        SpellEditorCancel()
    End Sub

    Private Sub frmEditor_Spell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrlIcon.Maximum = NumSpellIcons
    End Sub
End Class