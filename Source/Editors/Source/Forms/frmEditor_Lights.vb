Public Class frmEditor_Lights
    Private Sub FrmEditor_Lights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LstIndex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIndex.SelectedIndexChanged

    End Sub

    Private Sub ScrlRed_ValueChanged(sender As Object, e As EventArgs) Handles scrlRed.ValueChanged
        CurrentTintR = scrlRed.Value
    End Sub

    Private Sub ScrlGreen_ValueChanged(sender As Object, e As EventArgs) Handles ScrlGreen.ValueChanged
        CurrentTintG = ScrlGreen.Value
    End Sub

    Private Sub ScrlBlue_ValueChanged(sender As Object, e As EventArgs) Handles scrlBlue.ValueChanged
        CurrentTintB = scrlBlue.Value
    End Sub

    Private Sub ScrlAlpha_ValueChanged(sender As Object, e As EventArgs) Handles scrlAlpha.ValueChanged
        CurrentTintA = scrlAlpha.Value
    End Sub

    Private Sub CmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub picPreview_Click(sender As Object, e As EventArgs) Handles picPreview.Click

    End Sub
End Class