Public Class FrmVisualWarp
    Private Sub LstMaps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMaps.SelectedIndexChanged
        DrawMap()
        EditorWarpMap = lstMaps.SelectedIndex + 1
    End Sub

    Private Sub PicPreview_Click(sender As Object, e As MouseEventArgs) Handles picPreview.Click
        EditorWarpX = e.Location.X \ PIC_X
        EditorWarpY = e.Location.Y \ PIC_Y

        lblSelX.Text = "Selected X: " & EditorWarpX
        lblSelY.Text = "Selected Y: " & EditorWarpY
    End Sub

    Private Sub BtnWarpOK_Click(sender As Object, e As EventArgs) Handles btnWarpOK.Click
        Visible = False
    End Sub

    Private Overloads Sub PicPreview_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        'This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
        Exit Sub
    End Sub

    Private Sub DrawMap()
        Dim g As Graphics, x As Integer, y As Integer
        Dim srcRect As Rectangle
        Dim destRect As Rectangle

        If lstMaps.SelectedIndex < 0 Then Exit Sub

        If FileExist(Application.StartupPath & "\Data\Cache\Map" & lstMaps.SelectedIndex + 1 & ".png") Then
            g = picPreview.CreateGraphics

            Dim mapsprite As Bitmap = New Bitmap(Application.StartupPath & "\Data\Cache\Map" & lstMaps.SelectedIndex + 1 & ".png")

            picPreview.Width = mapsprite.Width
            picPreview.Height = mapsprite.Height

            srcRect = New Rectangle(0, 0, mapsprite.Width, mapsprite.Height)
            destRect = New Rectangle(0, 0, mapsprite.Width, mapsprite.Height)

            picPreview.Refresh()
            g.DrawImage(mapsprite, destRect, srcRect, GraphicsUnit.Pixel)

            For x = 0 To (mapsprite.Width \ PIC_X)
                For y = 0 To (mapsprite.Height \ PIC_Y)
                    g.DrawRectangle(Pens.Red, New Rectangle(x * PIC_X, y * PIC_Y, PIC_X, PIC_Y))
                Next
            Next

            g.Dispose()
        Else
            MsgBox("This map is not in the chache yet, please save the destination map first!")
        End If
    End Sub

    Private Sub PnlPreview_Paint(sender As Object, e As PaintEventArgs) Handles pnlPreview.Paint
        'nothing
    End Sub

    Private Sub PnlPreview_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlPreview.Scroll
        DrawMap()
    End Sub

    Private Sub FrmVisualWarp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class