Public Class frmEditor_Projectile
    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        ProjectileEditorInit()
    End Sub


    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Projectiles(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Projectiles(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub


    Private Sub scrlPic_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scrlPic.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub
        Projectiles(EditorIndex).Sprite = scrlPic.Value
        lblPic.Text = "Pic: " & scrlPic.Value
    End Sub

    Private Sub scrlRange_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scrlRange.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub
        Projectiles(EditorIndex).Range = scrlRange.Value
        lblRange.Text = "Range: " & scrlRange.Value
    End Sub

    Private Sub scrlSpeed_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scrlSpeed.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub
        Projectiles(EditorIndex).Speed = scrlSpeed.Value
        lblSpeed.Text = "Speed: " & scrlSpeed.Value
    End Sub

    Private Sub scrlDamage_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scrlDamage.ValueChanged
        If EditorIndex < 1 Or EditorIndex > MAX_PROJECTILES Then Exit Sub
        Projectiles(EditorIndex).Damage = scrlDamage.Value
        lblDamage.Text = "Additional Damage: " & scrlDamage.Value
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ProjectileEditorOk()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ProjectileEditorCancel()
    End Sub

    Private Sub frmEditor_Projectile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrlPic.Maximum = NumProjectiles
    End Sub
End Class