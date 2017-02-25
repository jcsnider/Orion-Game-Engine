Public Class FrmEditor_Shop

    Private Sub TxtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Shop(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Shop(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub ScrlBuy_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles nudBuy.ValueChanged
        Shop(EditorIndex).BuyRate = nudBuy.Value
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim Index As Integer
        Index = lstTradeItem.SelectedIndex + 1
        If Index = 0 Then Exit Sub
        With Shop(EditorIndex).TradeItem(Index)
            .Item = cmbItem.SelectedIndex
            .ItemValue = nudItemValue.Value
            .CostItem = cmbCostItem.SelectedIndex
            .CostValue = nudCostValue.Value
        End With
        Call UpdateShopTrade()
    End Sub

    Private Sub BtnDeleteTrade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteTrade.Click
        Dim Index As Integer
        Index = lstTradeItem.SelectedIndex + 1
        If Index = 0 Then Exit Sub
        With Shop(EditorIndex).TradeItem(Index)
            .Item = 0
            .ItemValue = 0
            .CostItem = 0
            .CostValue = 0
        End With
        Call UpdateShopTrade()
    End Sub

    Private Sub LstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        ShopEditorInit()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim$(txtName.Text)) = 0 Then
            MsgBox("Name required.")
        Else
            ShopEditorOk()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        ShopEditorCancel()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        ClearShop(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Shop(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ShopEditorInit()
    End Sub

    Private Sub ScrlFace_Scroll(sender As Object, e As ScrollEventArgs) Handles nudFace.ValueChanged

        If FileExist(Application.StartupPath & GFX_PATH & "Faces\" & nudFace.Value & GFX_EXT) Then
            Me.picFace.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "Faces\" & nudFace.Value & GFX_EXT)
        End If

        Shop(EditorIndex).Face = nudFace.Value
    End Sub
End Class