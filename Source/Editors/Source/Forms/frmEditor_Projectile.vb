﻿Public Class frmEditor_Projectile

    Private Sub FrmEditor_Projectile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudPic.Maximum = NumProjectiles
    End Sub

    Private Sub LstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        ProjectileEditorInit()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ProjectileEditorOk()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ProjectileEditorCancel()
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Projectiles(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Projectiles(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub NudPic_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudPic.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Sprite = nudPic.Value
    End Sub

    Private Sub NudRange_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudRange.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Range = nudRange.Value
    End Sub

    Private Sub NudSpeed_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSpeed.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Speed = nudSpeed.Value
    End Sub

    Private Sub NudDamage_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudDamage.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Damage = nudDamage.Value
    End Sub

End Class