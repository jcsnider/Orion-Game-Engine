Imports System.ComponentModel

Public Class FrmEditor_MapEditor

#Region "Form Code"

    Private Sub FrmEditor_Map_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        cmbTileSets.SelectedIndex = 0
        pnlAttributes.BringToFront()
        pnlAttributes.Visible = False
        pnlTiles.BringToFront()
        pnlTiles.Visible = True
        optBlocked.Checked = True
        SelectedTab = 1

        nudFog.Maximum = NumFogs

        picScreen.Width = (Map.MaxX * PIC_X) + PIC_X
        picScreen.Height = (Map.MaxY * PIC_Y) + PIC_Y

        scrlMapViewH.Maximum = (Map.MaxX \ PIC_X) + PIC_X
        scrlMapViewV.Maximum = (Map.MaxY \ PIC_Y) + PIC_Y

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)))
        TilesetWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, picBackSelect.Width, picBackSelect.Height)))

        picScreen.Focus()

    End Sub

    Private Sub FrmEditor_MapEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If GameWindow Is Nothing Then Exit Sub

        picScreen.Width = (Map.MaxX * PIC_X) + PIC_X
        picScreen.Height = (Map.MaxY * PIC_Y) + PIC_Y

        ' set the scrollbars
        scrlMapViewH.Maximum = (Map.MaxX \ PIC_X) + PIC_X
        scrlMapViewV.Maximum = (Map.MaxY \ PIC_Y) + PIC_Y

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)))
    End Sub

    Private Sub FrmEditor_MapEditor_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        MapEditorCancel()
    End Sub

    Private Sub FrmEditor_MapEditor_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MapEditorCancel()
    End Sub

    Private Sub PicBackSelect_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picBackSelect.MouseDown
        MapEditorChooseTile(e.Button, e.X, e.Y)
    End Sub

    Private Sub PicBackSelect_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picBackSelect.MouseMove
        MapEditorDrag(e.Button, e.X, e.Y)
    End Sub

    Private Overloads Sub PicBackSelect_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picBackSelect.Paint
        'Overrides the paint sub
    End Sub

    Private Overloads Sub PnlBack_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlBack.Paint
        'Overrides the paint sub
    End Sub

    Private Overloads Sub PnlBack2_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlBack2.Paint
        'Overrides the paint sub
    End Sub

    Private Sub ScrlPictureY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPictureY.ValueChanged
        MapEditorTileScroll()
    End Sub

    Private Sub ScrlPictureX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPictureX.ValueChanged
        MapEditorTileScroll()
    End Sub

    Private Sub CmbTileSets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTileSets.SelectedIndexChanged
        If cmbTileSets.SelectedIndex + 1 > NumTileSets Then
            cmbTileSets.SelectedIndex = 0
        End If

        Map.tileset = cmbTileSets.SelectedIndex + 1

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        'EditorMap_DrawTileset2()

        'pnlBack.Refresh()

        picBackSelect.Height = TileSetTextureInfo(cmbTileSets.SelectedIndex + 1).height
        picBackSelect.Width = TileSetTextureInfo(cmbTileSets.SelectedIndex + 1).width

        scrlPictureY.Maximum = (picBackSelect.Height \ PIC_Y) + PIC_Y
        scrlPictureX.Maximum = (picBackSelect.Width \ PIC_X) + PIC_X
    End Sub

    Private Sub CmbAutoTile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAutoTile.SelectedIndexChanged
        If cmbAutoTile.SelectedIndex = 0 Then
            EditorTileWidth = 1
            EditorTileHeight = 1
        End If
    End Sub

    Private Sub BtnTiles_Click(sender As Object, e As EventArgs) Handles btnTiles.Click
        SelectedTab = 1

        pnlTiles.Visible = True

        pnlAttribute.Visible = False
        pnlNpc.Visible = False
        pnlDirBlock.Visible = False
        pnlEvents.Visible = False
    End Sub

    Private Sub BtnAttributes_Click(sender As Object, e As EventArgs) Handles btnAttributes.Click
        SelectedTab = 2

        pnlAttribute.Visible = True

        pnlTiles.Visible = False
        pnlNpc.Visible = False
        pnlDirBlock.Visible = False
        pnlEvents.Visible = False
    End Sub

    Private Sub BtnNpc_Click(sender As Object, e As EventArgs) Handles btnNpc.Click
        SelectedTab = 3

        pnlNpc.Visible = True

        pnlTiles.Visible = False
        pnlAttribute.Visible = False
        pnlDirBlock.Visible = False
        pnlEvents.Visible = False
    End Sub

    Private Sub BtnDirBlock_Click(sender As Object, e As EventArgs) Handles btnDirBlock.Click
        SelectedTab = 4

        pnlDirBlock.Visible = True

        pnlTiles.Visible = False
        pnlNpc.Visible = False
        pnlAttribute.Visible = False
        pnlEvents.Visible = False
    End Sub

    Private Sub BtnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click
        SelectedTab = 5

        pnlEvents.Visible = True

        pnlTiles.Visible = False
        pnlAttribute.Visible = False
        pnlNpc.Visible = False
        pnlDirBlock.Visible = False

    End Sub
#End Region

#Region "Toolbar"
    Private Sub TsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        HideCursor = True
        ScreenShotTimer = GetTickCount() + 1000
        MakeCache = True
        'MapEditorSend()
    End Sub

    Private Sub TsbDiscard_Click(sender As Object, e As EventArgs) Handles tsbDiscard.Click
        MapEditorCancel()
    End Sub

    Private Sub TsbMapGrid_Click(sender As Object, e As EventArgs) Handles tsbMapGrid.Click
        MapGrid = Not MapGrid
    End Sub

    Private Sub TsbFill_Click(sender As Object, e As EventArgs) Handles tsbFill.Click
        MapEditorFillLayer(cmbAutoTile.SelectedIndex)
    End Sub

    Private Sub TsbClear_Click(sender As Object, e As EventArgs) Handles tsbClear.Click
        MapEditorClearLayer()
    End Sub

    Private Sub CmbMapList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMapList.SelectedIndexChanged
        SendEditorRequestMap(cmbMapList.SelectedIndex + 1)
    End Sub

    Private Sub TsbScreenShot_Click(sender As Object, e As EventArgs) Handles tsbScreenShot.Click
        HideCursor = True
        ScreenShotTimer = GetTickCount() + 1000
        TakeScreenShot = True
    End Sub
#End Region

#Region "PicScreen"
    Private Sub Picscreen_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picScreen.MouseDown
        If e.X > pnlBack2.Width - 32 Or e.Y > pnlBack2.Height - 32 Then Exit Sub
        MapEditorMouseDown(e.Button, e.X, e.Y, False)

    End Sub

    Private Overloads Sub Picscreen_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picScreen.Paint
        'This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
        Exit Sub
    End Sub

    Private Sub Picscreen_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picScreen.MouseMove

        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

        CurMouseX = e.Location.X
        CurMouseY = e.Location.Y

        If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
            MapEditorMouseDown(e.Button, e.X, e.Y)
        End If

        tslCurXY.Text = "X: " & CurX & " - " & " Y: " & CurY
    End Sub

    Private Sub Picscreen_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picScreen.MouseUp

        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

    End Sub

#End Region

#Region "Attributes"
    Private Sub ScrlMapWarpMap_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapWarpMap.Scroll
        lblMapWarpMap.Text = "Map: " & scrlMapWarpMap.Value
    End Sub

    Private Sub ScrlMapWarpX_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapWarpX.Scroll
        lblMapWarpX.Text = "X: " & scrlMapWarpX.Value
    End Sub

    Private Sub ScrlMapWarpY_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapWarpY.Scroll
        lblMapWarpY.Text = "Y: " & scrlMapWarpY.Value
    End Sub

    Private Sub BtnMapWarp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapWarp.Click
        EditorWarpMap = scrlMapWarpMap.Value

        EditorWarpX = scrlMapWarpX.Value
        EditorWarpY = scrlMapWarpY.Value
        pnlAttributes.Visible = False
        fraMapWarp.Visible = False
    End Sub

    Private Sub OptWarp_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optWarp.CheckedChanged

        If optWarp.Checked = True Then
            ClearAttributeDialogue()
            FrmVisualWarp.Visible = True
        End If

    End Sub

    Private Sub ScrlMapItem_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapItem.Scroll
        If Item(scrlMapItem.Value).Type = ItemType.Currency Or Item(scrlMapItem.Value).Stackable = 1 Then
            scrlMapItemValue.Enabled = True
        Else
            scrlMapItemValue.Value = 1
            scrlMapItemValue.Enabled = False
        End If

        EditorMap_DrawMapItem()
        lblMapItem.Text = "Item: " & scrlMapItem.Value & ". " & Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub ScrlMapItemValue_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapItemValue.Scroll
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub BtnMapItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapItem.Click
        ItemEditorNum = scrlMapItem.Value
        ItemEditorValue = scrlMapItemValue.Value
        pnlAttributes.Visible = False
        fraMapItem.Visible = False
    End Sub

    Private Sub OptItem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optItem.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapItem.Visible = True

        scrlMapItem.Maximum = MAX_ITEMS
        scrlMapItem.Value = 1
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
        EditorMap_DrawMapItem()
    End Sub

    Private Sub ScrlMapKey_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlMapKey.Scroll
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
        EditorMap_DrawKey()
    End Sub

    Private Sub BtnMapKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapKey.Click
        KeyEditorNum = scrlMapKey.Value
        KeyEditorTake = chkMapKey.Checked
        pnlAttributes.Visible = False
        fraMapKey.Visible = False
    End Sub

    Private Sub OptKey_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optKey.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapKey.Visible = True

        scrlMapKey.Maximum = MAX_ITEMS
        scrlMapKey.Value = 1
        chkMapKey.Checked = True
        EditorMap_DrawKey()
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
    End Sub

    Private Sub ScrlKeyX_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlKeyX.Scroll
        lblKeyX.Text = "X: " & scrlKeyX.Value
    End Sub

    Private Sub ScrlKeyY_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlKeyY.Scroll
        lblKeyY.Text = "X: " & scrlKeyY.Value
    End Sub

    Private Sub BtnMapKeyOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapKeyOpen.Click
        KeyOpenEditorX = scrlKeyX.Value
        KeyOpenEditorY = scrlKeyY.Value
        pnlAttributes.Visible = False
        fraKeyOpen.Visible = False
    End Sub

    Private Sub OptKeyOpen_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optKeyOpen.CheckedChanged
        ClearAttributeDialogue()
        fraKeyOpen.Visible = True
        pnlAttributes.Visible = True

        scrlKeyX.Maximum = Map.MaxX
        scrlKeyY.Maximum = Map.MaxY
        scrlKeyX.Value = 0
        scrlKeyY.Value = 0
    End Sub

    Private Sub BtnResourceOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResourceOk.Click
        ResourceEditorNum = scrlResource.Value
        pnlAttributes.Visible = False
        fraResource.Visible = False
    End Sub

    Private Sub ScrlResource_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlResource.Scroll
        lblResource.Text = "Resource: " & Resource(scrlResource.Value).Name
    End Sub

    Private Sub OptResource_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optResource.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraResource.Visible = True
    End Sub

    Private Sub BtnNpcSpawn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNpcSpawn.Click
        SpawnNpcNum = lstNpc.SelectedIndex + 1
        SpawnNpcDir = scrlNpcDir.Value
        pnlAttributes.Visible = False
        fraNpcSpawn.Visible = False
    End Sub

    Private Sub OptNPCSpawn_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optNpcSpawn.CheckedChanged
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

    Private Sub BtnShop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShop.Click
        EditorShop = cmbShop.SelectedIndex
        pnlAttributes.Visible = False
        fraShop.Visible = False
    End Sub

    Private Sub OptShop_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optShop.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraShop.Visible = True
    End Sub

    Private Sub BtnHeal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHeal.Click
        MapEditorHealType = cmbHeal.SelectedIndex + 1
        MapEditorHealAmount = scrlHeal.Value
        pnlAttributes.Visible = False
        fraHeal.Visible = False
    End Sub

    Private Sub ScrlHeal_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlHeal.Scroll
        lblHeal.Text = "Amount: " & scrlHeal.Value
    End Sub

    Private Sub OptHeal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optHeal.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraHeal.Visible = True
    End Sub

    Private Sub ScrlTrap_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlTrap.Scroll
        lblTrap.Text = "Amount: " & scrlTrap.Value
    End Sub

    Private Sub BtnTrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrap.Click
        MapEditorHealAmount = scrlTrap.Value
        pnlAttributes.Visible = False
        fraTrap.Visible = False
    End Sub

    Private Sub OptTrap_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optTrap.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraTrap.Visible = True
    End Sub

    Private Sub BtnClearAttribute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAttribute.Click
        MapEditorClearAttribs()
    End Sub

    Private Sub ScrlNpcDir_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlNpcDir.Scroll
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

    Private Sub OptBlocked_CheckedChanged(sender As Object, e As EventArgs) Handles optBlocked.CheckedChanged
        If optBlocked.Checked Then pnlAttributes.Visible = False
    End Sub

    Private Sub OptHouse_CheckedChanged(sender As Object, e As EventArgs) Handles optHouse.CheckedChanged
        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraBuyHouse.Visible = True
        scrlBuyHouse.Maximum = MAX_HOUSES
        scrlBuyHouse.Value = 1
    End Sub

    Private Sub ScrlBuyHouse_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlBuyHouse.Scroll
        lblHouseName.Text = scrlBuyHouse.Value & ". " & HouseConfig(scrlBuyHouse.Value).ConfigName
    End Sub

    Private Sub BtnHouseTileOk_Click(sender As Object, e As EventArgs) Handles btnHouseTileOk.Click
        HouseTileIndex = scrlBuyHouse.Value
        pnlAttributes.Visible = False
        fraBuyHouse.Visible = False
    End Sub

#End Region

#Region "Map Settings"
    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Map.Name = Trim$(txtName.Text)
    End Sub

    Private Sub CmbMoral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoral.SelectedIndexChanged
        Map.Moral = cmbMoral.SelectedIndex
    End Sub

    Private Sub NudLeft_ValueChanged(sender As Object, e As EventArgs) Handles nudLeft.ValueChanged
        Map.Left = nudLeft.Value
    End Sub

    Private Sub NudRight_ValueChanged(sender As Object, e As EventArgs) Handles nudRight.ValueChanged
        Map.Right = nudRight.Value
    End Sub

    Private Sub NudUp_ValueChanged(sender As Object, e As EventArgs) Handles nudUp.ValueChanged
        Map.Up = nudUp.Value
    End Sub

    Private Sub NudDown_ValueChanged(sender As Object, e As EventArgs) Handles nudDown.ValueChanged
        Map.Down = nudDown.Value
    End Sub

    Private Sub TxtBootMap_TextChanged(sender As Object, e As EventArgs) Handles nudSpawnMap.ValueChanged
        Map.BootMap = nudSpawnMap.Value
    End Sub

    Private Sub TxtBootX_TextChanged(sender As Object, e As EventArgs) Handles nudSpawnX.ValueChanged
        Map.BootX = nudSpawnX.Value
    End Sub

    Private Sub TxtBootY_TextChanged(sender As Object, e As EventArgs) Handles nudSpawnY.ValueChanged
        Map.BootY = nudSpawnY.Value
    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
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

    Private Sub CmbWeather_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWeather.SelectedIndexChanged
        Map.WeatherType = cmbWeather.SelectedIndex
        CurrentWeather = cmbWeather.SelectedIndex
    End Sub

    Private Sub ScrlFog_Scroll(sender As Object, e As EventArgs) Handles nudFog.ValueChanged
        Map.FogIndex = nudFog.Value
        CurrentFog = nudFog.Value
    End Sub

    Private Sub ScrlIntensity_Scroll(sender As Object, e As EventArgs) Handles nudIntensity.ValueChanged
        Map.WeatherIntensity = nudIntensity.Value
        CurrentWeatherIntensity = nudIntensity.Value
    End Sub

    Private Sub ScrlFogSpeed_Scroll(sender As Object, e As EventArgs) Handles nudFogSpeed.ValueChanged
        Map.FogSpeed = nudFogSpeed.Value
        CurrentFogSpeed = nudFogSpeed.Value
    End Sub

    Private Sub ScrlFogAlpha_Scroll(sender As Object, e As EventArgs) Handles nudFogAlpha.ValueChanged
        Map.FogAlpha = nudFogAlpha.Value
        CurrentFogOpacity = nudFogAlpha.Value
    End Sub

    Private Sub ChkUseTint_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseTint.CheckedChanged
        If chkUseTint.Checked = True Then
            Map.HasMapTint = 1
        Else
            Map.HasMapTint = 0
        End If
    End Sub

    Private Sub ScrlMapRed_Scroll(sender As Object, e As EventArgs) Handles nudMapRed.ValueChanged
        Map.MapTintR = nudMapRed.Value
        CurrentTintR = nudMapRed.Value
    End Sub

    Private Sub ScrlMapGreen_Scroll(sender As Object, e As EventArgs) Handles nudMapGreen.ValueChanged
        Map.MapTintG = nudMapGreen.Value
        CurrentTintG = nudMapGreen.Value
    End Sub

    Private Sub ScrlMapBlue_Scroll(sender As Object, e As EventArgs) Handles nudMapBlue.ValueChanged
        Map.MapTintB = nudMapBlue.Value
        CurrentTintB = nudMapBlue.Value
    End Sub

    Private Sub ScrlMapAlpha_Scroll(sender As Object, e As EventArgs) Handles nudMapAlpha.ValueChanged
        Map.MapTintA = nudMapAlpha.Value
        CurrentTintA = nudMapAlpha.Value
    End Sub

    Private Sub BtnSetSize_Click(sender As Object, e As EventArgs) Handles btnSetSize.Click
        Dim X As Integer, x2 As Integer, i As Integer
        Dim Y As Integer, y2 As Integer
        Dim tempArr(,) As TileRec

        If nudMaxX.Value < SCREEN_MAPX Then nudMaxX.Value = SCREEN_MAPX
        If nudMaxY.Value < SCREEN_MAPY Then nudMaxY.Value = SCREEN_MAPY

        GettingMap = True
        With Map

            ' set the data before changing it
            ReDim tempArr(0 To .MaxX, 0 To .MaxY)
            For X = 0 To .MaxX
                For Y = 0 To .MaxY
                    ReDim tempArr(X, Y).Layer(0 To MapLayer.Count - 1)

                    tempArr(X, Y).Data1 = .Tile(X, Y).Data1
                    tempArr(X, Y).Data2 = .Tile(X, Y).Data2
                    tempArr(X, Y).Data3 = .Tile(X, Y).Data3
                    tempArr(X, Y).DirBlock = .Tile(X, Y).DirBlock
                    tempArr(X, Y).Type = .Tile(X, Y).Type

                    For i = 1 To MapLayer.Count - 1
                        tempArr(X, Y).Layer(i).AutoTile = .Tile(X, Y).Layer(i).AutoTile
                        tempArr(X, Y).Layer(i).Tileset = .Tile(X, Y).Layer(i).Tileset
                        tempArr(X, Y).Layer(i).X = .Tile(X, Y).Layer(i).X
                        tempArr(X, Y).Layer(i).Y = .Tile(X, Y).Layer(i).Y
                    Next
                Next
            Next

            x2 = Map.MaxX
            y2 = Map.MaxY
            ' change the data
            .MaxX = nudMaxX.Value
            .MaxY = nudMaxY.Value

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
                            .Tile(X, Y).Data1 = tempArr(X, Y).Data1
                            .Tile(X, Y).Data2 = tempArr(X, Y).Data2
                            .Tile(X, Y).Data3 = tempArr(X, Y).Data3
                            .Tile(X, Y).DirBlock = tempArr(X, Y).DirBlock
                            .Tile(X, Y).Type = tempArr(X, Y).Type

                            For i = 1 To MapLayer.Count - 1
                                .Tile(X, Y).Layer(i).AutoTile = tempArr(X, Y).Layer(i).AutoTile
                                .Tile(X, Y).Layer(i).Tileset = tempArr(X, Y).Layer(i).Tileset
                                .Tile(X, Y).Layer(i).X = tempArr(X, Y).Layer(i).X
                                .Tile(X, Y).Layer(i).Y = tempArr(X, Y).Layer(i).Y
                            Next
                        End If
                    End If
                Next
            Next
            InitAutotiles()
            ClearTempTile()
            'MapEditorSend()
        End With

        GettingMap = False
    End Sub

    Private Sub ScrlMapViewH_Scroll(sender As Object, e As EventArgs) Handles scrlMapViewH.ValueChanged
        EditorViewX = scrlMapViewH.Value
    End Sub

    Private Sub ScrlMapViewV_Scroll(sender As Object, e As EventArgs) Handles scrlMapViewV.ValueChanged
        EditorViewY = scrlMapViewV.Value
    End Sub

    Private Sub ChkInstance_CheckedChanged(sender As Object, e As EventArgs) Handles chkInstance.CheckedChanged
        If chkInstance.Checked = True Then
            Map.Instanced = 1
        Else
            Map.Instanced = 0
        End If
    End Sub

    Private Sub BtnMoreOptions_Click(sender As Object, e As EventArgs) Handles btnMoreOptions.Click
        If pnlMoreOptions.Visible = False Then
            pnlMoreOptions.Visible = True
        Else
            pnlMoreOptions.Visible = False
        End If
    End Sub

    Private Sub LstMusic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMusic.SelectedIndexChanged
        If lstMusic.SelectedIndex >= 0 Then
            Map.Music = lstMusic.Items(lstMusic.SelectedIndex).ToString
        Else
            Map.Music = ""
        End If
    End Sub

    Private Sub OptDoor_CheckedChanged(sender As Object, e As EventArgs) Handles optDoor.CheckedChanged
        If optDoor.Checked = False Then Exit Sub

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

#End Region

#Region "Npc's"
    Private Sub LstMapNpc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMapNpc.SelectedIndexChanged
        cmbNpcList.SelectedItem = lstMapNpc.SelectedItem
    End Sub

    Private Sub CmbNpcList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNpcList.SelectedIndexChanged
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

    Private Sub FrmEditor_MapEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'To Whom It May Concern,
        'This is super shitty code.
        'We know this is super shitty code
        'You will be tempted to remove this code
        'Do not.

        'Find and yell at JC. But leave this code in place
        'Have a nice day
        Me.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        Me.WindowState = FormWindowState.Normal
    End Sub
#End Region

End Class