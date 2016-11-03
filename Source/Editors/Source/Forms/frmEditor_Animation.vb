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
        Dim tmpIndex As Integer
        If EditorIndex = 0 Or EditorIndex > MAX_ANIMATIONS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Animation(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Animation(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub lstIndex_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstIndex.MouseClick
        AnimationEditorInit()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

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

    Private Sub frmEditor_Animation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrlSprite0.Maximum = NumAnimations
        scrlSprite1.Maximum = NumAnimations
    End Sub

#Region "Animation Editor"
    Public Sub AnimationEditorInit()

        If frmEditor_Animation.Visible = False Then Exit Sub

        EditorIndex = frmEditor_Animation.lstIndex.SelectedIndex + 1

        With Animation(EditorIndex)
            frmEditor_Animation.txtName.Text = Trim$(.Name)

            frmEditor_Animation.scrlSprite0.Value = .Sprite(0)
            frmEditor_Animation.scrlFrameCount0.Value = .Frames(0)
            frmEditor_Animation.scrlLoopCount0.Value = .LoopCount(0)
            frmEditor_Animation.scrlLoopTime0.Value = .looptime(0)

            frmEditor_Animation.scrlSprite1.Value = .Sprite(1)
            frmEditor_Animation.scrlFrameCount1.Value = .Frames(1)
            frmEditor_Animation.scrlLoopCount1.Value = .LoopCount(1)
            frmEditor_Animation.scrlLoopTime1.Value = .looptime(1)

            EditorIndex = frmEditor_Animation.lstIndex.SelectedIndex + 1
        End With

        EditorAnim_DrawAnim()
        Animation_Changed(EditorIndex) = True
    End Sub

    Public Sub AnimationEditorOk()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS
            If Animation_Changed(i) Then
                SendSaveAnimation(i)
            End If
        Next

        frmEditor_Animation.Visible = False
        Editor = 0
        ClearChanged_Animation()
    End Sub

    Public Sub AnimationEditorCancel()
        Editor = 0
        frmEditor_Animation.Visible = False
        ClearChanged_Animation()
        ClearAnimations()
        SendRequestAnimations()
    End Sub

    Public Sub ClearChanged_Animation()
        For i = 0 To MAX_ANIMATIONS
            Animation_Changed(i) = False
        Next
    End Sub

#End Region
End Class