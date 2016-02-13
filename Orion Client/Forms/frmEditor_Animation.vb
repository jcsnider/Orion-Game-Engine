Public Class frmEditor_Animation

    Private Sub scrlSprite0_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSprite0.ValueChanged, scrlSprite0.Scroll
        lblSprite0.Text = "Sprite: " & scrlSprite0.Value
        Animation(EditorIndex).Sprite(0) = scrlSprite0.Value
    End Sub

    Private Sub scrlSprite1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSprite1.ValueChanged, scrlSprite1.Scroll
        lblSprite1.Text = "Sprite: " & scrlSprite1.Value
        Animation(EditorIndex).Sprite(1) = scrlSprite1.Value
    End Sub

    Private Sub scrlLoopCount0_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLoopCount0.ValueChanged
        lblLoopCount0.Text = "Loop Count: " & scrlLoopCount0.Value
        Animation(EditorIndex).LoopCount(0) = scrlLoopCount0.Value
    End Sub

    Private Sub scrlLoopCount1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLoopCount1.ValueChanged, scrlLoopCount1.Scroll
        lblLoopCount1.Text = "Loop Count: " & scrlLoopCount1.Value
        Animation(EditorIndex).LoopCount(1) = scrlLoopCount1.Value
    End Sub

    Private Sub scrlFrameCount0_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlFrameCount0.ValueChanged
        lblFrameCount0.Text = "Frame Count: " & scrlFrameCount0.Value
        Animation(EditorIndex).Frames(0) = scrlFrameCount0.Value
    End Sub

    Private Sub scrlFrameCount1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlFrameCount1.ValueChanged
        lblFrameCount1.Text = "Frame Count: " & scrlFrameCount1.Value
        Animation(EditorIndex).Frames(1) = scrlFrameCount1.Value
    End Sub

    Private Sub scrlLoopTime0_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLoopTime0.ValueChanged
        lblLoopTime0.Text = "Loop Time: " & scrlLoopTime0.Value
        Animation(EditorIndex).looptime(0) = scrlLoopTime0.Value
    End Sub

    Private Sub scrlLoopTime1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLoopTime1.ValueChanged
        lblLoopTime1.Text = "Loop Time: " & scrlLoopTime1.Value
        Animation(EditorIndex).looptime(1) = scrlLoopTime1.Value
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        AnimationEditorOk()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long
        If EditorIndex = 0 Or EditorIndex > MAX_ANIMATIONS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Animation(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Animation(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub lstIndex_MouseClick(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs) Handles lstIndex.MouseClick
        AnimationEditorInit()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        If EditorIndex = 0 Or EditorIndex > MAX_ANIMATIONS Then Exit Sub

        ClearAnimation(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Animation(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        AnimationEditorInit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        AnimationEditorCancel()
    End Sub
End Class