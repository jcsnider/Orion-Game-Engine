Imports System.ComponentModel

Public Class frmEditor_MapEditor
#Region "Form Code"
    Private Sub frmEditor_Map_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cmbTileSets.SelectedIndex = 0
        EditorMap_DrawTileset()
        pnlAttributes.BringToFront()
        pnlAttributes.Visible = False

        optBlocked.Checked = True
        tabpages.SelectedIndex = 0

        scrlFog.Maximum = NumFogs

        'picScreen.Width = Map.MaxX * PIC_X
        'picScreen.Height = Map.MaxY * PIC_Y

        scrlMapViewV.Maximum = Map.MaxX
        scrlMapViewH.Maximum = Map.MaxY

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)))

        picScreen.Focus()
    End Sub

    Private Sub frmEditor_MapEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If GameWindow Is Nothing Then Exit Sub

        'picScreen.Width = Map.MaxX * PIC_X
        'picScreen.Height = Map.MaxY * PIC_Y
        ' set the scrollbars
        scrlMapViewV.Maximum = Map.MaxX
        scrlMapViewH.Maximum = Map.MaxY

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)))
    End Sub

    Private Sub frmEditor_MapEditor_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        MapEditorCancel()
    End Sub

    Private Sub picBackSelect_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picBackSelect.MouseDown
        MapEditorChooseTile(e.Button, e.X, e.Y)
    End Sub

    Private Sub picBackSelect_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picBackSelect.MouseMove
        MapEditorDrag(e.Button, e.X, e.Y)
    End Sub

    Private Sub picBackSelect_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picBackSelect.Paint
        'Overrides the paint sub
    End Sub

    Private Sub pnlBack_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlBack.Paint
        'Overrides the paint sub
    End Sub

    Private Sub pnlBack2_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlBack2.Paint
        'Overrides the paint sub
    End Sub

    Private Sub scrlPictureY_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlPictureY.Scroll
        MapEditorTileScroll()
    End Sub

    Private Sub scrlPictureX_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlPictureX.Scroll
        MapEditorTileScroll()
    End Sub

    Private Sub cmbTileSets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTileSets.Click
        If cmbTileSets.SelectedIndex + 1 > NumTileSets Then
            cmbTileSets.SelectedIndex = 0
        End If

        Map.tileset = cmbTileSets.SelectedIndex + 1

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        EditorMap_DrawTileset()

        pnlBack.Refresh()

        picBackSelect.Height = TileSetImgsGFX(cmbTileSets.SelectedIndex + 1).Height
        picBackSelect.Width = TileSetImgsGFX(cmbTileSets.SelectedIndex + 1).Width

        scrlPictureY.Maximum = (picBackSelect.Height \ PIC_Y)
        scrlPictureX.Maximum = (picBackSelect.Width \ PIC_X)
    End Sub

    Private Sub cmbAutoTile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAutoTile.SelectedIndexChanged
        If cmbAutoTile.SelectedIndex = 0 Then
            EditorTileWidth = 1
            EditorTileHeight = 1
        End If
    End Sub
#End Region

#Region "Attributes"
    Private Sub scrlMapWarpMap_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapWarpMap.Scroll
        lblMapWarpMap.Text = "Map: " & scrlMapWarpMap.Value
    End Sub

    Private Sub scrlMapWarpX_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapWarpX.Scroll
        lblMapWarpX.Text = "X: " & scrlMapWarpX.Value
    End Sub

    Private Sub scrlMapWarpY_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapWarpY.Scroll
        lblMapWarpY.Text = "Y: " & scrlMapWarpY.Value
    End Sub

    Private Sub btnMapWarp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapWarp.Click
        EditorWarpMap = scrlMapWarpMap.Value

        If chkIsInstanced.Checked = True Then
            EditorWarpMap = scrlMapWarpMap.Value Or INSTANCED_MAP_MASK
        End If

        EditorWarpX = scrlMapWarpX.Value
        EditorWarpY = scrlMapWarpY.Value
        pnlAttributes.Visible = False
        fraMapWarp.Visible = False
    End Sub

    Private Sub optWarp_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optWarp.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapWarp.Visible = True

        scrlMapWarpMap.Maximum = MAX_MAPS
        scrlMapWarpMap.Value = 1
        scrlMapWarpX.Maximum = Byte.MaxValue
        scrlMapWarpY.Maximum = Byte.MaxValue
        scrlMapWarpX.Value = 0
        scrlMapWarpY.Value = 0
    End Sub

    Private Sub scrlMapItem_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapItem.Scroll
        If Item(scrlMapItem.Value).Type = ItemType.Currency Or Item(scrlMapItem.Value).Stackable = 1 Then
            scrlMapItemValue.Enabled = True
        Else
            scrlMapItemValue.Value = 1
            scrlMapItemValue.Enabled = False
        End If

        EditorMap_DrawMapItem()
        lblMapItem.Text = "Item: " & scrlMapItem.Value & ". " & Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub scrlMapItemValue_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapItemValue.Scroll
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub btnMapItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapItem.Click
        ItemEditorNum = scrlMapItem.Value
        ItemEditorValue = scrlMapItemValue.Value
        pnlAttributes.Visible = False
        fraMapItem.Visible = False
    End Sub

    Private Sub optItem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optItem.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapItem.Visible = True

        scrlMapItem.Maximum = MAX_ITEMS
        scrlMapItem.Value = 1
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
        EditorMap_DrawMapItem()
    End Sub

    Private Sub scrlMapKey_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapKey.Scroll
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
        EditorMap_DrawKey()
    End Sub

    Private Sub btnMapKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapKey.Click
        KeyEditorNum = scrlMapKey.Value
        KeyEditorTake = chkMapKey.Checked
        pnlAttributes.Visible = False
        fraMapKey.Visible = False
    End Sub

    Private Sub optKey_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optKey.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapKey.Visible = True

        scrlMapKey.Maximum = MAX_ITEMS
        scrlMapKey.Value = 1
        chkMapKey.Checked = True
        EditorMap_DrawKey()
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
    End Sub

    Private Sub scrlKeyX_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlKeyX.Scroll
        lblKeyX.Text = "X: " & scrlKeyX.Value
    End Sub

    Private Sub scrlKeyY_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlKeyY.Scroll
        lblKeyY.Text = "X: " & scrlKeyY.Value
    End Sub

    Private Sub btnMapKeyOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapKeyOpen.Click
        KeyOpenEditorX = scrlKeyX.Value
        KeyOpenEditorY = scrlKeyY.Value
        pnlAttributes.Visible = False
        fraKeyOpen.Visible = False
    End Sub

    Private Sub optKeyOpen_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optKeyOpen.CheckedChanged
        ClearAttributeDialogue()
        fraKeyOpen.Visible = True
        pnlAttributes.Visible = True

        scrlKeyX.Maximum = Map.MaxX
        scrlKeyY.Maximum = Map.MaxY
        scrlKeyX.Value = 0
        scrlKeyY.Value = 0
    End Sub

    Private Sub btnResourceOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResourceOk.Click
        ResourceEditorNum = scrlResource.Value
        pnlAttributes.Visible = False
        fraResource.Visible = False
    End Sub

    Private Sub scrlResource_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlResource.Scroll
        lblResource.Text = "Resource: " & Resource(scrlResource.Value).Name
    End Sub

    Private Sub optResource_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optResource.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraResource.Visible = True
    End Sub

    Private Sub btnNpcSpawn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNpcSpawn.Click
        SpawnNpcNum = lstNpc.SelectedIndex + 1
        SpawnNpcDir = scrlNpcDir.Value
        pnlAttributes.Visible = False
        fraNpcSpawn.Visible = False
    End Sub

    Private Sub optNPCSpawn_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optNPCSpawn.CheckedChanged
        Dim n As Integer

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

    Private Sub btnShop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShop.Click
        EditorShop = cmbShop.SelectedIndex
        pnlAttributes.Visible = False
        fraShop.Visible = False
    End Sub

    Private Sub optShop_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optShop.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraShop.Visible = True
    End Sub

    Private Sub btnHeal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHeal.Click
        MapEditorHealType = cmbHeal.SelectedIndex + 1
        MapEditorHealAmount = scrlHeal.Value
        pnlAttributes.Visible = False
        fraHeal.Visible = False
    End Sub

    Private Sub scrlHeal_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlHeal.Scroll
        lblHeal.Text = "Amount: " & scrlHeal.Value
    End Sub

    Private Sub optHeal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optHeal.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraHeal.Visible = True
    End Sub

    Private Sub scrlTrap_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlTrap.Scroll
        lblTrap.Text = "Amount: " & scrlTrap.Value
    End Sub

    Private Sub btnTrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrap.Click
        MapEditorHealAmount = scrlTrap.Value
        pnlAttributes.Visible = False
        fraTrap.Visible = False
    End Sub

    Private Sub optTrap_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optTrap.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraTrap.Visible = True
    End Sub

    Private Sub btnClearAttribute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAttribute.Click
        MapEditorClearAttribs()
    End Sub

    Private Sub scrlNpcDir_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlNpcDir.Scroll
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

    Private Sub optHouse_CheckedChanged(sender As Object, e As EventArgs) Handles optHouse.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraBuyHouse.Visible = True
        scrlBuyHouse.Maximum = MAX_HOUSES
        scrlBuyHouse.Value = 1
    End Sub

    Private Sub scrlBuyHouse_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlBuyHouse.Scroll
        lblHouseName.Text = scrlBuyHouse.Value & ". " & HouseConfig(scrlBuyHouse.Value).ConfigName
    End Sub

    Private Sub btnHouseTileOk_Click(sender As Object, e As EventArgs) Handles btnHouseTileOk.Click
        HouseTileIndex = scrlBuyHouse.Value
        pnlAttributes.Visible = False
        fraBuyHouse.Visible = False
    End Sub

#End Region

#Region "Toolbar"
    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        MapEditorSend()
    End Sub

    Private Sub tsbDiscard_Click(sender As Object, e As EventArgs) Handles tsbDiscard.Click
        MapEditorCancel()
    End Sub

    Private Sub tsbMapGrid_Click(sender As Object, e As EventArgs) Handles tsbMapGrid.Click
        MapGrid = Not MapGrid
    End Sub

    Private Sub tsbFill_Click(sender As Object, e As EventArgs) Handles tsbFill.Click
        MapEditorFillLayer(cmbAutoTile.SelectedIndex)
    End Sub

    Private Sub tsbClear_Click(sender As Object, e As EventArgs) Handles tsbClear.Click
        MapEditorClearLayer()
    End Sub

    Private Sub cmbMapList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMapList.SelectedIndexChanged
        SendEditorRequestMap(cmbMapList.SelectedIndex + 1)
    End Sub
#End Region

#Region "Npc's"
    Private Sub lstMapNpc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMapNpc.SelectedIndexChanged
        cmbNpcList.SelectedItem = lstMapNpc.SelectedItem
    End Sub

    Private Sub cmbNpcList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNpcList.SelectedIndexChanged
        If lstMapNpc.SelectedIndex > -1 Then
            If cmbNpcList.SelectedIndex > 0 Then
                lstMapNpc.Items.Item(lstMapNpc.SelectedIndex) = cmbNpcList.SelectedIndex & ": " & Npc(cmbNpcList.SelectedIndex).Name
                Map.Npc(lstMapNpc.SelectedIndex + 1) = cmbNpcList.SelectedIndex
            Else
                lstMapNpc.Items.Item(lstMapNpc.SelectedIndex) = "No NPC"
                Map.Npc(lstMapNpc.SelectedIndex + 1) = 0
            End If

        End If
    End Sub
#End Region

#Region "PicScreen"
    Private Sub picscreen_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picScreen.MouseDown
        If e.X > pnlBack2.Width - 32 Or e.Y > pnlBack2.Height - 32 Then Exit Sub
        MapEditorMouseDown(e.Button, e.X, e.Y, False)

    End Sub

    Private Overloads Sub picscreen_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picScreen.Paint
        'This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
        Exit Sub
    End Sub

    Private Sub picscreen_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picScreen.MouseMove

        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

        CurMouseX = e.Location.X
        CurMouseY = e.Location.Y

        If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
            MapEditorMouseDown(e.Button, e.X, e.Y)
        End If

        tslCurXY.Text = "X: " & CurX & " - " & " Y: " & CurY
    End Sub

    Private Sub picscreen_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picScreen.MouseUp

        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

    End Sub

#End Region

#Region "Map Settings"
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Map.Name = Trim$(txtName.Text)
    End Sub

    Private Sub cmbMoral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoral.SelectedIndexChanged
        Map.Moral = cmbMoral.SelectedIndex
    End Sub

    Private Sub txtLeft_TextChanged(sender As Object, e As EventArgs) Handles txtLeft.TextChanged
        Map.Left = Val(txtLeft.Text)
    End Sub

    Private Sub txtRight_TextChanged(sender As Object, e As EventArgs) Handles txtRight.TextChanged
        Map.Right = Val(txtRight.Text)
    End Sub

    Private Sub txtUp_TextChanged(sender As Object, e As EventArgs) Handles txtUp.TextChanged
        Map.Up = Val(txtUp.Text)
    End Sub

    Private Sub txtDown_TextChanged(sender As Object, e As EventArgs) Handles txtDown.TextChanged
        Map.Down = Val(txtDown.Text)
    End Sub

    Private Sub txtBootMap_TextChanged(sender As Object, e As EventArgs) Handles txtBootMap.TextChanged
        Map.BootMap = Val(txtBootMap.Text)
    End Sub

    Private Sub txtBootX_TextChanged(sender As Object, e As EventArgs) Handles txtBootX.TextChanged
        Map.BootX = Val(txtBootX.Text)
    End Sub

    Private Sub txtBootY_TextChanged(sender As Object, e As EventArgs) Handles txtBootY.TextChanged
        Map.BootY = Val(txtBootY.Text)
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If PreviewPlayer Is Nothing Then
            If lstMusic.SelectedIndex >= 0 Then
                StopMusic()
                PlayPreview(lstMusic.Items(lstMusic.SelectedIndex).ToString)
            End If
        Else
            StopPreview()
            PlayMusic(Map.Music)
        End If
    End Sub

    Private Sub cmbWeather_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWeather.SelectedIndexChanged
        Map.WeatherType = cmbWeather.SelectedIndex
        CurrentWeather = cmbWeather.SelectedIndex
    End Sub

    Private Sub scrlFog_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlFog.Scroll
        Map.FogIndex = scrlFog.Value
        lblFogIndex.Text = "Fog: " & scrlFog.Value
        CurrentFog = scrlFog.Value
    End Sub

    Private Sub scrlIntensity_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlIntensity.Scroll
        Map.WeatherIntensity = scrlIntensity.Value
        lblIntensity.Text = "Intensity: " & scrlIntensity.Value
        CurrentWeatherIntensity = scrlIntensity.Value
    End Sub

    Private Sub scrlFogSpeed_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlFogSpeed.Scroll
        Map.FogSpeed = scrlFogSpeed.Value
        lblFogSpeed.Text = "FogSpeed: " & scrlFogSpeed.Value
        CurrentFogSpeed = scrlFogSpeed.Value
    End Sub

    Private Sub scrlFogAlpha_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlFogAlpha.Scroll
        Map.FogAlpha = scrlFogAlpha.Value
        lblFogAlpha.Text = "Fog Alpha: " & scrlFogAlpha.Value
        CurrentFogOpacity = scrlFogAlpha.Value
    End Sub

    Private Sub chkUseTint_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseTint.CheckedChanged
        If chkUseTint.Checked = True Then
            Map.HasMapTint = 1
        Else
            Map.HasMapTint = 0
        End If
    End Sub

    Private Sub scrlMapRed_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMapRed.Scroll
        Map.MapTintR = scrlMapRed.Value
        lblMapRed.Text = "Red: " & scrlMapRed.Value
        CurrentTintR = scrlMapRed.Value
    End Sub

    Private Sub scrlMapGreen_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMapGreen.Scroll
        Map.MapTintG = scrlMapGreen.Value
        lblMapGreen.Text = "Green: " & scrlMapGreen.Value
        CurrentTintG = scrlMapGreen.Value
    End Sub

    Private Sub scrlMapBlue_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMapBlue.Scroll
        Map.MapTintB = scrlMapBlue.Value
        lblMapBlue.Text = "Blue: " & scrlMapBlue.Value
        CurrentTintB = scrlMapBlue.Value
    End Sub

    Private Sub scrlMapAlpha_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMapAlpha.Scroll
        Map.MapTintA = scrlMapAlpha.Value
        lblMapAlpha.Text = "Alpha: " & scrlMapAlpha.Value
        CurrentTintA = scrlMapAlpha.Value
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Dim X As Integer, x2 As Integer
        Dim Y As Integer, y2 As Integer
        Dim tempArr(,) As TileRec

        If Not IsNumeric(txtMaxX.Text) Then txtMaxX.Text = Map.MaxX
        If Val(txtMaxX.Text) < SCREEN_MAPX Then txtMaxX.Text = SCREEN_MAPX
        If Val(txtMaxX.Text) > Byte.MaxValue Then txtMaxX.Text = Byte.MaxValue
        If Not IsNumeric(txtMaxY.Text) Then txtMaxY.Text = Map.MaxY
        If Val(txtMaxY.Text) < SCREEN_MAPY Then txtMaxY.Text = SCREEN_MAPY
        If Val(txtMaxY.Text) > Byte.MaxValue Then txtMaxY.Text = Byte.MaxValue

        With Map

            If lstMusic.SelectedIndex >= 0 Then
                .Music = lstMusic.Items(lstMusic.SelectedIndex).ToString
            Else
                .Music = ""
            End If

            ' set the data before changing it
            tempArr = Map.Tile.Clone

            x2 = Map.MaxX
            y2 = Map.MaxY
            ' change the data
            .MaxX = Val(txtMaxX.Text)
            .MaxY = Val(txtMaxY.Text)
            ReDim Map.Tile(0 To .MaxX, 0 To .MaxY)

            ReDim Autotile(0 To .MaxX, 0 To .MaxY)

            If x2 > .MaxX Then x2 = .MaxX
            If y2 > .MaxY Then y2 = .MaxY

            For X = 0 To .MaxX
                For Y = 0 To .MaxY
                    ReDim Preserve .Tile(X, Y).Layer(0 To MapLayer.Count - 1)

                    ReDim Preserve Autotile(X, Y).Layer(0 To MapLayer.Count - 1)

                    If X <= x2 Then
                        If Y <= y2 Then
                            .Tile(X, Y) = tempArr(X, Y)
                        End If
                    End If
                Next
            Next

            ClearTempTile()
            MapEditorSend()
        End With
    End Sub

    Private Sub scrlMapViewH_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMapViewH.Scroll
        EditorViewX = scrlMapViewH.Value
    End Sub

    Private Sub scrlMapViewV_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMapViewV.Scroll
        EditorViewY = scrlMapViewV.Value
    End Sub

    Private Sub chkInstance_CheckedChanged(sender As Object, e As EventArgs) Handles chkInstance.CheckedChanged
        If chkInstance.Checked = True Then
            Map.Instanced = 1
        Else
            Map.Instanced = 0
        End If
    End Sub

#End Region

End Class