Public Class frmEditor_Projectile
    Private Sub frmEditor_Projectile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudPic.Maximum = NumProjectiles
    End Sub

    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        ProjectileEditorInit()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ProjectileEditorOk()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ProjectileEditorCancel()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Projectiles(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Projectiles(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub nudPic_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudPic.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Sprite = nudPic.Value
    End Sub

    Private Sub nudRange_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudRange.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Range = nudRange.Value
    End Sub

    Private Sub nudSpeed_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSpeed.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Speed = nudSpeed.Value
    End Sub

    Private Sub nudDamage_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudDamage.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        Projectiles(EditorIndex).Damage = nudDamage.Value
    End Sub

End Class