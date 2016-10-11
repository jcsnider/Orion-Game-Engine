Public Class frmLoad

    Private Sub frmLoad_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Show()
        If Started = False Then Call startup()
    End Sub
End Class