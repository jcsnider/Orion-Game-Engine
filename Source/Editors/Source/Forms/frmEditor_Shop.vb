Imports System.Windows.Forms

Public Class frmEditor_Shop

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer

        If EditorIndex = 0 Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Shop(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Shop(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub scrlBuy_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlBuy.Scroll
        lblBuy.Text = "Buy Rate: " & scrlBuy.Value & "%"
        Shop(EditorIndex).BuyRate = scrlBuy.Value
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim Index As Integer
        Index = lstTradeItem.SelectedIndex + 1
        If Index = 0 Then Exit Sub
        With Shop(EditorIndex).TradeItem(Index)
            .Item = cmbItem.SelectedIndex
            .ItemValue = Val(txtItemValue.Text)
            .CostItem = cmbCostItem.SelectedIndex
            .CostValue = Val(txtCostValue.Text)
        End With
        Call UpdateShopTrade()
    End Sub

    Private Sub btnDeleteTrade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteTrade.Click
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

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        ShopEditorInit()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim$(txtName.Text)) = 0 Then
            Call MsgBox("Name required.")
        Else
            Call ShopEditorOk()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        ShopEditorCancel()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        ClearShop(EditorIndex)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Shop(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ShopEditorInit()
    End Sub

    Private Sub scrlFace_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlFace.Scroll
        lblFace.Text = "Face: " & scrlFace.Value

        If FileExist(Application.StartupPath & GFX_PATH & "Faces\" & scrlFace.Value & GFX_EXT) Then
            Me.picFace.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "Faces\" & scrlFace.Value & GFX_EXT)
        End If

        Shop(EditorIndex).Face = scrlFace.Value
    End Sub

#Region "Shop editor"
    Public Sub ShopEditorInit()
        Dim i As Integer

        If frmEditor_Shop.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Shop.lstIndex.SelectedIndex + 1

        frmEditor_Shop.txtName.Text = Trim$(Shop(EditorIndex).Name)
        If Shop(EditorIndex).BuyRate > 0 Then
            frmEditor_Shop.scrlBuy.Value = Shop(EditorIndex).BuyRate
        Else
            frmEditor_Shop.scrlBuy.Value = 100
        End If
        frmEditor_Shop.lblBuy.Text = "Buy Rate: " & frmEditor_Shop.scrlBuy.Value & "%"

        frmEditor_Shop.scrlFace.Value = Shop(EditorIndex).Face
        frmEditor_Shop.lblFace.Text = "Face: " & Shop(EditorIndex).Face
        If FileExist(Application.StartupPath & GFX_PATH & "Faces\" & Shop(EditorIndex).Face & GFX_EXT) Then
            frmEditor_Shop.picFace.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "Faces\" & Shop(EditorIndex).Face & GFX_EXT)
        End If

        frmEditor_Shop.cmbItem.Items.Clear()
        frmEditor_Shop.cmbItem.Items.Add("None")
        frmEditor_Shop.cmbCostItem.Items.Clear()
        frmEditor_Shop.cmbCostItem.Items.Add("None")

        For i = 1 To MAX_ITEMS
            frmEditor_Shop.cmbItem.Items.Add(i & ": " & Trim$(Item(i).Name))
            frmEditor_Shop.cmbCostItem.Items.Add(i & ": " & Trim$(Item(i).Name))
        Next

        frmEditor_Shop.cmbItem.SelectedIndex = 0
        frmEditor_Shop.cmbCostItem.SelectedIndex = 0

        UpdateShopTrade()

        Shop_Changed(EditorIndex) = True
    End Sub

    Public Sub UpdateShopTrade()
        Dim i As Integer
        frmEditor_Shop.lstTradeItem.Items.Clear()

        For i = 1 To MAX_TRADES
            With Shop(EditorIndex).TradeItem(i)
                ' if none, show as none
                If .Item = 0 And .CostItem = 0 Then
                    frmEditor_Shop.lstTradeItem.Items.Add("Empty Trade Slot")
                Else
                    frmEditor_Shop.lstTradeItem.Items.Add(i & ": " & .ItemValue & "x " & Trim$(Item(.Item).Name) & " for " & .CostValue & "x " & Trim$(Item(.CostItem).Name))
                End If
            End With
        Next

        frmEditor_Shop.lstTradeItem.SelectedIndex = 0
    End Sub

    Public Sub ShopEditorOk()
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            If Shop_Changed(i) Then
                SendSaveShop(i)
            End If
        Next

        frmEditor_Shop.Visible = False
        Editor = 0
        ClearChanged_Shop()
    End Sub

    Public Sub ShopEditorCancel()
        Editor = 0
        frmEditor_Shop.Visible = False
        ClearChanged_Shop()
        ClearShops()
        SendRequestShops()
    End Sub

    Public Sub ClearChanged_Shop()
        For i = 1 To MAX_SHOPS
            Shop_Changed(i) = False
        Next
    End Sub
#End Region
End Class