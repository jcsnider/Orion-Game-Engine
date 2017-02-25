Public Class frmEditor_Recipe

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        RecipeEditorOk()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        RecipeEditorCancel()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        If EditorIndex = 0 Or EditorIndex > MAX_RECIPE Then Exit Sub

        ClearRecipe(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Recipe(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        lstIngredients.Items.Clear()

        RecipeEditorInit()
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer
        If EditorIndex = 0 Or EditorIndex > MAX_RECIPE Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Recipe(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Recipe(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub LstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        If EditorIndex = 0 Or EditorIndex > MAX_RECIPE Then Exit Sub
        RecipeEditorInit()
    End Sub

    Private Sub BtnIngredientAdd_Click(sender As Object, e As EventArgs) Handles btnIngredientAdd.Click
        If lstIngredients.SelectedIndex < 0 Or cmbIngredient.SelectedIndex = 0 Then Exit Sub

        Recipe(EditorIndex).Ingredients(lstIngredients.SelectedIndex + 1).ItemNum = cmbIngredient.SelectedIndex
        Recipe(EditorIndex).Ingredients(lstIngredients.SelectedIndex + 1).Value = numItemAmount.Value

        UpdateIngredient()

    End Sub

    Private Sub CmbMakeItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMakeItem.SelectedIndexChanged
        Recipe(EditorIndex).MakeItemNum = cmbMakeItem.SelectedIndex
    End Sub

    Private Sub CmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        Recipe(EditorIndex).RecipeType = cmbType.SelectedIndex
    End Sub

    Private Sub NudAmount_ValueChanged(sender As Object, e As EventArgs) Handles nudAmount.ValueChanged
        Recipe(EditorIndex).MakeItemAmount = nudAmount.Value
    End Sub

    Private Sub NudCreateTime_ValueChanged(sender As Object, e As EventArgs) Handles nudCreateTime.ValueChanged
        Recipe(EditorIndex).CreateTime = nudCreateTime.Value
    End Sub
End Class