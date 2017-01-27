Public Class FrmEditor_House
    Private Sub LstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        HouseEditorInit()
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        House(EditorIndex).ConfigName = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & House(EditorIndex).ConfigName)
        lstIndex.SelectedIndex = tmpIndex

    End Sub

    Private Sub TxtBaseMap_TextChanged(sender As Object, e As EventArgs) Handles nudBaseMap.ValueChanged
        If EditorIndex <= 0 Then Exit Sub

        If nudBaseMap.Value < 1 Or nudBaseMap.Value > MAX_MAPS Then Exit Sub
        House(EditorIndex).BaseMap = nudBaseMap.Value
    End Sub

    Private Sub TxtXEntrance_TextChanged(sender As Object, e As EventArgs) Handles nudX.ValueChanged
        If EditorIndex = 0 Then Exit Sub

        If nudX.Value < 0 Or nudX.Value > 255 Then Exit Sub
        House(EditorIndex).X = nudX.Value

    End Sub

    Private Sub TxtYEntrance_TextChanged(sender As Object, e As EventArgs) Handles nudY.ValueChanged
        If EditorIndex = 0 Then Exit Sub

        If nudY.Value < 0 Or nudY.Value > 255 Then Exit Sub
        House(EditorIndex).Y = nudY.Value

    End Sub

    Private Sub TxtHousePrice_TextChanged(sender As Object, e As EventArgs) Handles nudPrice.ValueChanged
        If EditorIndex = 0 Then Exit Sub

        House(EditorIndex).Price = nudPrice.Value

    End Sub

    Private Sub TxtHouseFurniture_TextChanged(sender As Object, e As EventArgs) Handles nudFurniture.ValueChanged
        If EditorIndex = 0 Then Exit Sub

        If nudFurniture.Value < 0 Then Exit Sub
        House(EditorIndex).MaxFurniture = nudFurniture.Value
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Len(Trim$(txtName.Text)) = 0 Then
            MsgBox("Name required.")
            Exit Sub
        End If

        If nudBaseMap.Value = 0 Then
            MsgBox("Base map required.")
            Exit Sub
        End If

        HouseEditorOk()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        HouseEditorCancel()
    End Sub
End Class