Public Class FrmEditor_Animation
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub NudSprite0_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSprite0.ValueChanged
        Animation(EditorIndex).Sprite(0) = nudSprite0.Value
    End Sub

    Private Sub NudSprite1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSprite1.ValueChanged
        Animation(EditorIndex).Sprite(1) = nudSprite1.Value
    End Sub

    Private Sub NudLoopCount0_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLoopCount0.ValueChanged
        Animation(EditorIndex).LoopCount(0) = nudLoopCount0.Value
    End Sub

    Private Sub NudLoopCount1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLoopCount1.ValueChanged
        Animation(EditorIndex).LoopCount(1) = nudLoopCount1.Value
    End Sub

    Private Sub NudFrameCount0_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudFrameCount0.ValueChanged
        Animation(EditorIndex).Frames(0) = nudFrameCount0.Value
    End Sub

    Private Sub NudFrameCount1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudFrameCount1.ValueChanged
        Animation(EditorIndex).Frames(1) = nudFrameCount1.Value
    End Sub

    Private Sub NudLoopTime0_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLoopTime0.ValueChanged
        Animation(EditorIndex).looptime(0) = nudLoopTime0.Value
    End Sub

    Private Sub NudLoopTime1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLoopTime1.ValueChanged
        Animation(EditorIndex).looptime(1) = nudLoopTime1.Value
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        AnimationEditorOk()
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer
        If EditorIndex = 0 Or EditorIndex > MAX_ANIMATIONS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Animation(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Animation(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub LstIndex_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstIndex.MouseClick
        AnimationEditorInit()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        If EditorIndex = 0 Or EditorIndex > MAX_ANIMATIONS Then Exit Sub

        ClearAnimation(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Animation(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        AnimationEditorInit()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        AnimationEditorCancel()
    End Sub

    Private Sub FrmEditor_Animation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudSprite0.Maximum = NumAnimations
        nudSprite1.Maximum = NumAnimations
    End Sub
End Class
