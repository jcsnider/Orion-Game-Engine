Public Class frmEditor_House
    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        HouseEditorInit()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        House(EditorIndex).ConfigName = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & House(EditorIndex).ConfigName)
        lstIndex.SelectedIndex = tmpIndex

    End Sub

    Private Sub txtBaseMap_TextChanged(sender As Object, e As EventArgs) Handles txtBaseMap.TextChanged
        If EditorIndex = 0 Then Exit Sub
        If IsNumeric(txtBaseMap.Text) Then
            If Val(txtBaseMap.Text) < 1 Or Val(txtBaseMap.Text) > MAX_MAPS Then Exit Sub
            House(EditorIndex).BaseMap = Val(txtBaseMap.Text)
        End If
    End Sub

    Private Sub txtXEntrance_TextChanged(sender As Object, e As EventArgs) Handles txtXEntrance.TextChanged
        If EditorIndex = 0 Then Exit Sub
        If IsNumeric(txtXEntrance.Text) Then
            If Val(txtXEntrance.Text) < 0 Or Val(txtXEntrance.Text) > 255 Then Exit Sub
            House(EditorIndex).X = Val(txtXEntrance.Text)
        End If
    End Sub

    Private Sub txtYEntrance_TextChanged(sender As Object, e As EventArgs) Handles txtYEntrance.TextChanged
        If EditorIndex = 0 Then Exit Sub
        If IsNumeric(txtYEntrance.Text) Then
            If Val(txtYEntrance.Text) < 0 Or Val(txtYEntrance.Text) > 255 Then Exit Sub
            House(EditorIndex).Y = Val(txtYEntrance.Text)
        End If
    End Sub

    Private Sub txtHousePrice_TextChanged(sender As Object, e As EventArgs) Handles txtHousePrice.TextChanged
        If EditorIndex = 0 Then Exit Sub
        If IsNumeric(txtHousePrice.Text) Then
            House(EditorIndex).Price = Val(txtHousePrice.Text)
        End If
    End Sub

    Private Sub txtHouseFurniture_TextChanged(sender As Object, e As EventArgs) Handles txtHouseFurniture.TextChanged
        If IsNumeric(txtHouseFurniture.Text) Then
            If Val(txtHouseFurniture.Text) < 0 Then Exit Sub
            House(EditorIndex).MaxFurniture = Val(txtHouseFurniture.Text)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Len(Trim$(txtName.Text)) = 0 Then
            Call MsgBox("Name required.")
            Exit Sub
        End If

        If Len(Trim$(txtBaseMap.Text)) = 0 Then
            Call MsgBox("Base map required.")
            Exit Sub
        End If

        HouseEditorOk
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        HouseEditorCancel
    End Sub
End Class