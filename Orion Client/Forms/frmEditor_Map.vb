Imports System.Drawing

Public Class frmEditor_Map

    Private Sub picBackSelect_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picBackSelect.MouseDown

        Call MapEditorChooseTile(e.Button, e.X, e.Y)
    End Sub

    Private Sub picBackSelect_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picBackSelect.MouseMove
        Call MapEditorDrag(e.Button, e.X, e.Y)
    End Sub

    Private Sub picBackSelect_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picBackSelect.Paint
        'Overrides the paint sub
    End Sub

    Private Sub pnlBack_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBack.Paint
        'Overrides the paint sub
    End Sub

    Private Sub scrlPictureY_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlPictureY.Scroll
        MapEditorTileScroll()
    End Sub

    Private Sub scrlPictureX_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlPictureX.Scroll
        MapEditorTileScroll()
    End Sub

    Private Sub scrlTileSet_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlTileSet.Scroll
        If scrlTileSet.Value > NumTileSets Then
            scrlTileSet.Value = 1
        End If

        Map.tileset = scrlTileSet.Value
        fraTileSet.Text = "Tileset: " & scrlTileSet.Value

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        EditorMap_DrawTileset()

        pnlBack.Refresh()

        picBackSelect.Height = TileSetImgsGFX(scrlTileSet.Value).Height
        picBackSelect.Width = TileSetImgsGFX(scrlTileSet.Value).Width


        scrlPictureY.Maximum = (picBackSelect.Height \ PIC_Y)
        scrlPictureX.Maximum = (picBackSelect.Width \ PIC_X)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        MapEditorSend()
        GettingMap = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        MapEditorCancel()
    End Sub

    Private Sub btnClearLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLayer.Click
        MapEditorClearLayer()
    End Sub

    Private Sub btnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MapEditorFillLayer()
    End Sub

    Private Sub optAttributes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAttributes.CheckedChanged
        If optAttributes.Checked Then
            fraLayers.Visible = False
            fraAttributes.Visible = True
        End If
    End Sub

    Private Sub optLayers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLayers.CheckedChanged
        If optLayers.Checked Then
            fraLayers.Visible = True
            fraAttributes.Visible = False
        End If
    End Sub

    Private Sub scrlMapWarpMap_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlMapWarpMap.Scroll
        lblMapWarpMap.Text = "Map: " & scrlMapWarpMap.Value
    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlMapWarpX.Scroll
        lblMapWarpX.Text = "X: " & scrlMapWarpX.Value
    End Sub

    Private Sub scrlMapWarpY_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlMapWarpY.Scroll
        lblMapWarpY.Text = "Y: " & scrlMapWarpY.Value
    End Sub

    Private Sub btnMapWarp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMapWarp.Click
        EditorWarpMap = scrlMapWarpMap.Value
        EditorWarpX = scrlMapWarpX.Value
        EditorWarpY = scrlMapWarpY.Value
        pnlAttributes.Visible = False
        fraMapWarp.Visible = False
    End Sub

    Private Sub frmEditor_Map_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        scrlTileSet.Maximum = NumTileSets
        pnlAttributes.Visible = False
        pnlAttributes.Left = 8
        Me.Width = 504
    End Sub

    Private Sub optWarp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optWarp.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapWarp.Visible = True

        scrlMapWarpMap.Maximum = MAX_MAPS
        scrlMapWarpMap.Value = 1
        scrlMapWarpX.Maximum = MAX_BYTE
        scrlMapWarpY.Maximum = MAX_BYTE
        scrlMapWarpX.Value = 0
        scrlMapWarpY.Value = 0
    End Sub

    Private Sub scrlMapItem_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlMapItem.Scroll
        If Item(scrlMapItem.Value).Type = ITEM_TYPE_CURRENCY Then
            scrlMapItemValue.Enabled = True
        Else
            scrlMapItemValue.Value = 1
            scrlMapItemValue.Enabled = False
        End If

        EditorMap_DrawMapItem()
        lblMapItem.Text = "Item: " & scrlMapItem.Value & ". " & Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub scrlMapItemValue_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlMapItemValue.Scroll
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ItemEditorNum = scrlMapItem.Value
        ItemEditorValue = scrlMapItemValue.Value
        pnlAttributes.Visible = False
        fraMapItem.Visible = False
    End Sub

    Private Sub optItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItem.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapItem.Visible = True

        scrlMapItem.Maximum = MAX_ITEMS
        scrlMapItem.Value = 1
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
        EditorMap_DrawMapItem()
    End Sub

    Private Sub scrlMapKey_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlMapKey.Scroll
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
        EditorMap_DrawKey()
    End Sub

    Private Sub fraMapKey_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraMapKey.Enter

    End Sub

    Private Sub btnMapKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMapKey.Click
        KeyEditorNum = scrlMapKey.Value
        KeyEditorTake = chkMapKey.Checked
        pnlAttributes.Visible = False
        fraMapKey.Visible = False
    End Sub

    Private Sub optKey_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optKey.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapKey.Visible = True

        scrlMapKey.Maximum = MAX_ITEMS
        scrlMapKey.Value = 1
        chkMapKey.Checked = True
        EditorMap_DrawKey()
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
    End Sub

    Private Sub scrlKeyX_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlKeyX.Scroll
        lblKeyX.Text = "X: " & scrlKeyX.Value
    End Sub

    Private Sub scrlKeyY_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlKeyY.Scroll
        lblKeyY.Text = "X: " & scrlKeyY.Value
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        KeyOpenEditorX = scrlKeyX.Value
        KeyOpenEditorY = scrlKeyY.Value
        pnlAttributes.Visible = False
        fraKeyOpen.Visible = False
    End Sub

    Private Sub optKeyOpen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optKeyOpen.CheckedChanged
        ClearAttributeDialogue()
        fraKeyOpen.Visible = True
        pnlAttributes.Visible = True

        scrlKeyX.Maximum = Map.MaxX
        scrlKeyY.Maximum = Map.MaxY
        scrlKeyX.Value = 0
        scrlKeyY.Value = 0
    End Sub

    Private Sub btnResourceOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResourceOk.Click
        ResourceEditorNum = scrlResource.Value
        pnlAttributes.Visible = False
        fraResource.Visible = False
    End Sub

    Private Sub scrlResource_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlResource.Scroll
        lblResource.Text = "Resource: " & Resource(scrlResource.Value).Name
    End Sub

    Private Sub optResource_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResource.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraResource.Visible = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNpcSpawn.Click
        SpawnNpcNum = lstNpc.SelectedIndex + 1
        SpawnNpcDir = scrlNpcDir.Value
        pnlAttributes.Visible = False
        fraNpcSpawn.Visible = False
    End Sub

    Private Sub optNPCSpawn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNPCSpawn.CheckedChanged
        Dim n As Long

        lstNpc.Items.Clear()

        For n = 1 To MAX_MAP_NPCS
            If Map.Npc(n) > 0 Then
                lstNpc.Items.Add(n & ": " & Npc(Map.Npc(n)).Name)
            Else
                lstNpc.Items.Add(n & ": No Npc")
            End If
        Next n

        scrlNpcDir.Value = 0
        lstNpc.SelectedIndex = 0

        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraNpcSpawn.Visible = True
    End Sub

    Private Sub btnShop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShop.Click
        EditorShop = cmbShop.SelectedIndex
        pnlAttributes.Visible = False
        fraShop.Visible = False
    End Sub

    Private Sub optShop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optShop.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraShop.Visible = True
    End Sub

    Private Sub btnHeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHeal.Click
        MapEditorHealType = cmbHeal.SelectedIndex + 1
        MapEditorHealAmount = scrlHeal.Value
        pnlAttributes.Visible = False
        fraHeal.Visible = False
    End Sub

    Private Sub scrlHeal_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlHeal.Scroll
        lblHeal.Text = "Amount: " & scrlHeal.Value
    End Sub

    Private Sub optHeal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optHeal.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraHeal.Visible = True
    End Sub

    Private Sub scrlTrap_Scroll_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlTrap.Scroll
        lblTrap.Text = "Amount: " & scrlTrap.Value
    End Sub

    Private Sub btnTrap_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrap.Click
        MapEditorHealAmount = scrlTrap.Value
        pnlAttributes.Visible = False
        fraTrap.Visible = False
    End Sub

    Private Sub optTrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTrap.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraTrap.Visible = True
    End Sub

    Private Sub btnProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProperties.Click
        frmEditor_MapProperties.Visible = True
    End Sub

    Private Sub btnClearAttribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAttribute.Click
        Call MapEditorClearAttribs()
    End Sub

    Private Sub btnFill_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill.Click
        MapEditorFillLayer()
    End Sub

    Private Sub scrlNpcDir_Scroll(sender As Object, e As Windows.Forms.ScrollEventArgs) Handles scrlNpcDir.Scroll
        Select Case scrlNpcDir.Value
            Case 0
                lblNpcDir.Text = "Direction: Up"
            Case 1
                lblNpcDir.Text = "Direction: Down"
            Case 2
                lblNpcDir.Text = "Direction: Left"
            Case 3
                lblNpcDir.Text = "Direction: Right"
        End Select
    End Sub

    Private Sub optBlocked_CheckedChanged(sender As Object, e As EventArgs) Handles optBlocked.CheckedChanged
        If optBlocked.Checked Then pnlAttributes.Visible = False
    End Sub
End Class