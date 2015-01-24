Public Class frmLoad

    Private Sub frmLoad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        If started = False Then Call startup()
    End Sub
End Class