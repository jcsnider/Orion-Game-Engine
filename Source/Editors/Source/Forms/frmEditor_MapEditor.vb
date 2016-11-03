Public Class frmEditor_MapEditor
#Region "Form Code"
    Private Sub frmEditor_Map_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cmbTileSets.SelectedIndex = 0
        EditorMap_DrawTileset()
        pnlAttributes.BringToFront()
        pnlAttributes.Visible = False
        pnlAttributes.Left = 8
        'Me.Width = 525
        optBlocked.Checked = True
        tabpages.SelectedIndex = 0

        scrlFog.Maximum = NumFogs

        picScreen.Width = Map.MaxX * PIC_X
        picScreen.Height = Map.MaxY * PIC_Y

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)))

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

    Private Sub btnLoadMap_Click(sender As Object, e As EventArgs) Handles btnLoadMap.Click
        SendEditorRequestMap(cmbMapList.SelectedIndex + 1)
    End Sub

#End Region

#Region "Map Editor"

    Public Sub MapPropertiesInit()
        Dim X As Integer, Y As Integer, i As Integer

        frmEditor_MapEditor.txtName.Text = Trim$(Map.Name)

        ' find the music we have set

        frmEditor_MapEditor.lstMusic.Items.Clear()
        frmEditor_MapEditor.lstMusic.Items.Add("None")

        If UBound(MusicCache) > 0 Then
            For i = 1 To UBound(MusicCache)
                frmEditor_MapEditor.lstMusic.Items.Add(MusicCache(i))
            Next
        End If

        If Trim$(Map.Music) = "None" Then
            frmEditor_MapEditor.lstMusic.SelectedIndex = 0
        Else
            For i = 1 To frmEditor_MapEditor.lstMusic.Items.Count
                If frmEditor_MapEditor.lstMusic.Items(i - 1).ToString = Trim$(Map.Music) Then
                    frmEditor_MapEditor.lstMusic.SelectedIndex = i - 1
                    Exit For
                End If
            Next
        End If

        ' rest of it
        frmEditor_MapEditor.txtUp.Text = Map.Up
        frmEditor_MapEditor.txtDown.Text = Map.Down
        frmEditor_MapEditor.txtLeft.Text = Map.Left
        frmEditor_MapEditor.txtRight.Text = Map.Right
        frmEditor_MapEditor.cmbMoral.SelectedIndex = Map.Moral
        frmEditor_MapEditor.txtBootMap.Text = Map.BootMap
        frmEditor_MapEditor.txtBootX.Text = Map.BootX
        frmEditor_MapEditor.txtBootY.Text = Map.BootY

        frmEditor_MapEditor.lstMapNpc.Items.Clear()

        For X = 1 To MAX_MAP_NPCS
            If Map.Npc(X) = 0 Then
                frmEditor_MapEditor.lstMapNpc.Items.Add("No NPC")
            Else
                frmEditor_MapEditor.lstMapNpc.Items.Add(X & ": " & Trim$(Npc(Map.Npc(X)).Name))
            End If

        Next

        frmEditor_MapEditor.cmbNpcList.Items.Clear()
        frmEditor_MapEditor.cmbNpcList.Items.Add("No NPC")

        For Y = 1 To MAX_NPCS
            frmEditor_MapEditor.cmbNpcList.Items.Add(Y & ": " & Trim$(Npc(Y).Name))
        Next

        frmEditor_MapEditor.lblMap.Text = "Current map: " & "?"
        frmEditor_MapEditor.txtMaxX.Text = Map.MaxX
        frmEditor_MapEditor.txtMaxY.Text = Map.MaxY

        frmEditor_MapEditor.cmbTileSets.SelectedIndex = 0
        frmEditor_MapEditor.cmbLayers.SelectedIndex = 0
        frmEditor_MapEditor.cmbAutoTile.SelectedIndex = 0

        frmEditor_MapEditor.cmbWeather.SelectedIndex = Map.WeatherType
        frmEditor_MapEditor.scrlFog.Value = Map.FogIndex
        frmEditor_MapEditor.lblFogIndex.Text = "Fog: " & frmEditor_MapEditor.scrlFog.Value
        frmEditor_MapEditor.scrlIntensity.Value = Map.WeatherIntensity
        frmEditor_MapEditor.lblIntensity.Text = "Intensity: " & frmEditor_MapEditor.scrlIntensity.Value

        ' render the tiles
        EditorMap_DrawTileset()

        frmEditor_MapEditor.tabpages.SelectedIndex = 0

        frmEditor_MapEditor.picScreen.Width = Map.MaxX * PIC_X
        frmEditor_MapEditor.picScreen.Height = Map.MaxY * PIC_Y

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, frmEditor_MapEditor.picScreen.Width, frmEditor_MapEditor.picScreen.Height)))

        ' show the form
        frmEditor_MapEditor.Visible = True

        GameStarted = True
    End Sub

    Public Sub MapEditorInit()
        ' we're in the map editor
        InMapEditor = True

        ' set the scrolly bars
        If Map.tileset = 0 Then Map.tileset = 1
        If Map.tileset > NumTileSets Then Map.tileset = 1

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        'clear memory
        ReDim TileSetImgsLoaded(NumTileSets)
        For i = 0 To NumTileSets
            TileSetImgsLoaded(i) = False
        Next

        ' set the scrollbars
        frmEditor_MapEditor.scrlPictureY.Maximum = (frmEditor_MapEditor.picBackSelect.Height \ PIC_Y) \ 2 ' \2 is new, lets test
        frmEditor_MapEditor.scrlPictureX.Maximum = (frmEditor_MapEditor.picBackSelect.Width \ PIC_X) \ 2

        'set map names
        frmEditor_MapEditor.cmbMapList.Items.Clear()

        For i = 1 To MAX_MAPS
            frmEditor_MapEditor.cmbMapList.Items.Add(i & ": " & MapNames(i))
        Next

        If Map.MapNum > 0 Then
            frmEditor_MapEditor.cmbMapList.SelectedIndex = Map.MapNum - 1
        Else
            frmEditor_MapEditor.cmbMapList.SelectedIndex = 0
        End If


        ' set shops for the shop attribute
        frmEditor_MapEditor.cmbShop.Items.Add("None")
        For i = 1 To MAX_SHOPS
            frmEditor_MapEditor.cmbShop.Items.Add(i & ": " & Shop(i).Name)
        Next
        ' we're not in a shop
        frmEditor_MapEditor.cmbShop.SelectedIndex = 0

        frmEditor_MapEditor.optBlocked.Checked = True

        frmEditor_MapEditor.cmbTileSets.Items.Clear()
        For i = 1 To NumTileSets
            frmEditor_MapEditor.cmbTileSets.Items.Add("Tileset " & i)
        Next

        frmEditor_MapEditor.cmbTileSets.SelectedIndex = 0
        frmEditor_MapEditor.cmbLayers.SelectedIndex = 0

        InitMapProperties = True

        If MapData = True Then GettingMap = False

    End Sub

    Public Sub MapEditorTileScroll()
        frmEditor_MapEditor.picBackSelect.Top = (frmEditor_MapEditor.scrlPictureY.Value * PIC_Y) * -1
        frmEditor_MapEditor.picBackSelect.Left = (frmEditor_MapEditor.scrlPictureX.Value * PIC_X) * -1
    End Sub

    Public Sub MapEditorChooseTile(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)

        If Button = MouseButtons.Left Then 'Left Mouse Button

            EditorTileWidth = 1
            EditorTileHeight = 1

            If frmEditor_MapEditor.cmbAutoTile.SelectedIndex > 0 Then
                Select Case frmEditor_MapEditor.cmbAutoTile.SelectedIndex
                    Case 1 ' autotile
                        EditorTileWidth = 2
                        EditorTileHeight = 3
                    Case 2 ' fake autotile
                        EditorTileWidth = 1
                        EditorTileHeight = 1
                    Case 3 ' animated
                        EditorTileWidth = 6
                        EditorTileHeight = 3
                    Case 4 ' cliff
                        EditorTileWidth = 2
                        EditorTileHeight = 2
                    Case 5 ' waterfall
                        EditorTileWidth = 2
                        EditorTileHeight = 3
                End Select
            End If

            EditorTileX = X \ PIC_X
            EditorTileY = Y \ PIC_Y

            EditorTileSelStart = New Point(EditorTileX, EditorTileY)
            EditorTileSelEnd = New Point(EditorTileX + EditorTileWidth, EditorTileY + EditorTileHeight)

        End If

    End Sub

    Public Sub MapEditorDrag(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)

        If Button = MouseButtons.Left Then 'Left Mouse Button
            ' convert the pixel number to tile number
            X = (X \ PIC_X) + 1
            Y = (Y \ PIC_Y) + 1
            ' check it's not out of bounds
            If X < 0 Then X = 0
            If X > frmEditor_MapEditor.picBackSelect.Width / PIC_X Then X = frmEditor_MapEditor.picBackSelect.Width / PIC_X
            If Y < 0 Then Y = 0
            If Y > frmEditor_MapEditor.picBackSelect.Height / PIC_Y Then Y = frmEditor_MapEditor.picBackSelect.Height / PIC_Y
            ' find out what to set the width + height of map editor to
            If X > EditorTileX Then ' drag right
                'EditorTileWidth = X
                EditorTileWidth = X - EditorTileX
            Else ' drag left
                ' TO DO
            End If
            If Y > EditorTileY Then ' drag down
                'EditorTileHeight = Y
                EditorTileHeight = Y - EditorTileY
            Else ' drag up
                ' TO DO
            End If

            EditorTileSelStart = New Point(EditorTileX, EditorTileY)
            EditorTileSelEnd = New Point(EditorTileWidth, EditorTileHeight)
        End If

    End Sub

    Public Sub MapEditorMouseDown(ByVal Button As Integer, ByVal X As Integer, ByVal Y As Integer, Optional ByVal movedMouse As Boolean = True)
        Dim i As Integer
        Dim CurLayer As Integer

        CurLayer = frmEditor_MapEditor.cmbLayers.SelectedIndex + 1

        If Not isInBounds() Then Exit Sub
        If Button = MouseButtons.Left Then
            If frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpTiles Then
                ' (EditorTileSelEnd.X - EditorTileSelStart.X) = 1 And (EditorTileSelEnd.Y - EditorTileSelStart.Y) = 1 Then 'single tile
                If EditorTileWidth = 1 And EditorTileHeight = 1 Then

                    MapEditorSetTile(CurX, CurY, CurLayer, False, frmEditor_MapEditor.cmbAutoTile.SelectedIndex)
                Else ' multi tile!
                    If frmEditor_MapEditor.cmbAutoTile.SelectedIndex = 0 Then
                        MapEditorSetTile(CurX, CurY, CurLayer, True)
                    Else
                        MapEditorSetTile(CurX, CurY, CurLayer, , frmEditor_MapEditor.cmbAutoTile.SelectedIndex)
                    End If
                End If
            ElseIf frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpAttributes Then
                With Map.Tile(CurX, CurY)
                    ' blocked tile
                    If frmEditor_MapEditor.optBlocked.Checked = True Then .Type = TileType.Blocked
                    ' warp tile
                    If frmEditor_MapEditor.optWarp.Checked = True Then
                        .Type = TileType.Warp
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' item spawn
                    If frmEditor_MapEditor.optItem.Checked = True Then
                        .Type = TileType.Item
                        .Data1 = ItemEditorNum
                        .Data2 = ItemEditorValue
                        .Data3 = 0
                    End If
                    ' npc avoid
                    If frmEditor_MapEditor.optNPCAvoid.Checked = True Then
                        .Type = TileType.NpcAvoid
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' key
                    If frmEditor_MapEditor.optKey.Checked = True Then
                        .Type = TileType.Key
                        .Data1 = KeyEditorNum
                        .Data2 = KeyEditorTake
                        .Data3 = 0
                    End If
                    ' key open
                    If frmEditor_MapEditor.optKeyOpen.Checked = True Then
                        .Type = TileType.KeyOpen
                        .Data1 = KeyOpenEditorX
                        .Data2 = KeyOpenEditorY
                        .Data3 = 0
                    End If
                    ' resource
                    If frmEditor_MapEditor.optResource.Checked = True Then
                        .Type = TileType.Resource
                        .Data1 = ResourceEditorNum
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' door
                    If frmEditor_MapEditor.optDoor.Checked = True Then
                        .Type = TileType.Door
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' npc spawn
                    If frmEditor_MapEditor.optNPCSpawn.Checked = True Then
                        .Type = TileType.NpcSpawn
                        .Data1 = SpawnNpcNum
                        .Data2 = SpawnNpcDir
                        .Data3 = 0
                    End If
                    ' shop
                    If frmEditor_MapEditor.optShop.Checked = True Then
                        .Type = TileType.Shop
                        .Data1 = EditorShop
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' bank
                    If frmEditor_MapEditor.optBank.Checked = True Then
                        .Type = TileType.Bank
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' heal
                    If frmEditor_MapEditor.optHeal.Checked = True Then
                        .Type = TileType.Heal
                        .Data1 = MapEditorHealType
                        .Data2 = MapEditorHealAmount
                        .Data3 = 0
                    End If
                    ' trap
                    If frmEditor_MapEditor.optTrap.Checked = True Then
                        .Type = TileType.Trap
                        .Data1 = MapEditorHealAmount
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'Housing
                    If frmEditor_MapEditor.optHouse.Checked Then
                        .Type = TileType.House
                        .Data1 = HouseTileIndex
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'craft tile
                    If frmEditor_MapEditor.optCraft.Checked Then
                        .Type = TileType.Craft
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                End With
            ElseIf frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpDirBlock Then
                If movedMouse Then Exit Sub
                ' find what tile it is
                X = X - ((X \ PIC_X) * PIC_X)
                Y = Y - ((Y \ PIC_Y) * PIC_Y)
                ' see if it hits an arrow
                For i = 1 To 4
                    If X >= DirArrowX(i) And X <= DirArrowX(i) + 8 Then
                        If Y >= DirArrowY(i) And Y <= DirArrowY(i) + 8 Then
                            ' flip the value.
                            setDirBlock(Map.Tile(CurX, CurY).DirBlock, (i), Not isDirBlocked(Map.Tile(CurX, CurY).DirBlock, (i)))
                            Exit Sub
                        End If
                    End If
                Next
            ElseIf frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpEvents Then
                If frmEditor_Events.Visible = False Then
                    AddEvent(CurX, CurY)
                End If
            End If
        End If

        If Button = MouseButtons.Right Then
            If frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpTiles Then

                With Map.Tile(CurX, CurY)
                    ' clear layer
                    .Layer(CurLayer).X = 0
                    .Layer(CurLayer).Y = 0
                    .Layer(CurLayer).Tileset = 0
                    If .Layer(CurLayer).AutoTile > 0 Then
                        .Layer(CurLayer).AutoTile = 0
                        ' do a re-init so we can see our changes
                        initAutotiles()
                    End If
                    CacheRenderState(X, Y, CurLayer)
                End With

            ElseIf frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpAttributes Then
                With Map.Tile(CurX, CurY)
                    ' clear attribute
                    .Type = 0
                    .Data1 = 0
                    .Data2 = 0
                    .Data3 = 0
                End With
            ElseIf frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpEvents Then
                DeleteEvent(CurX, CurY)
            End If
        End If

    End Sub

    Public Sub MapEditorCancel()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CNeedMap)
        Buffer.WriteInteger(1)
        SendData(Buffer.ToArray())
        InMapEditor = False
        frmEditor_MapEditor.Visible = False
        GettingMap = True

        'clear memory
        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
            TileSetImgsGFX(i) = Nothing
            TileSetImgsLoaded(i) = False
        Next

    End Sub

    Public Sub MapEditorSend()
        SendEditorMap()
        InMapEditor = False
        frmEditor_MapEditor.Visible = False
        GettingMap = True

        'clear memory
        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
            TileSetImgsGFX(i) = Nothing
            TileSetImgsLoaded(i) = False
        Next
    End Sub

    Public Sub MapEditorSetTile(ByVal X As Integer, ByVal Y As Integer, ByVal CurLayer As Integer, Optional ByVal multitile As Boolean = False, Optional ByVal theAutotile As Byte = 0)
        Dim x2 As Integer, y2 As Integer

        If theAutotile > 0 Then
            With Map.Tile(X, Y)
                ' set layer
                .Layer(CurLayer).X = EditorTileX
                .Layer(CurLayer).Y = EditorTileY
                .Layer(CurLayer).Tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1
                .Layer(CurLayer).AutoTile = theAutotile
                CacheRenderState(X, Y, CurLayer)
            End With
            ' do a re-init so we can see our changes
            initAutotiles()
            Exit Sub
        End If

        If Not multitile Then ' single
            With Map.Tile(X, Y)
                ' set layer
                .Layer(CurLayer).X = EditorTileX
                .Layer(CurLayer).Y = EditorTileY
                .Layer(CurLayer).Tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1
                .Layer(CurLayer).AutoTile = 0
                CacheRenderState(X, Y, CurLayer)
            End With
        Else ' multitile
            y2 = 0 ' starting tile for y axis
            For Y = CurY To CurY + EditorTileHeight - 1
                x2 = 0 ' re-set x count every y loop
                For X = CurX To CurX + EditorTileWidth - 1
                    If X >= 0 And X <= Map.MaxX Then
                        If Y >= 0 And Y <= Map.MaxY Then
                            With Map.Tile(X, Y)
                                .Layer(CurLayer).X = EditorTileX + x2
                                .Layer(CurLayer).Y = EditorTileY + y2
                                .Layer(CurLayer).Tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1
                                .Layer(CurLayer).AutoTile = 0
                                CacheRenderState(X, Y, CurLayer)
                            End With
                        End If
                    End If
                    x2 = x2 + 1
                Next
                y2 = y2 + 1
            Next
        End If
    End Sub

    Public Sub MapEditorClearLayer()
        Dim X As Integer
        Dim Y As Integer
        Dim CurLayer As Integer

        CurLayer = frmEditor_MapEditor.cmbLayers.SelectedIndex + 1

        If CurLayer = 0 Then Exit Sub

        ' ask to clear layer
        If MsgBox("Are you sure you wish to clear this layer?", vbYesNo, "MapEditor") = vbYes Then
            For X = 0 To Map.MaxX
                For Y = 0 To Map.MaxY
                    With Map.Tile(X, Y)
                        .Layer(CurLayer).X = 0
                        .Layer(CurLayer).Y = 0
                        .Layer(CurLayer).Tileset = 0
                        .Layer(CurLayer).AutoTile = 0
                        CacheRenderState(X, Y, CurLayer)
                    End With
                Next
            Next
        End If
    End Sub

    Public Sub MapEditorFillLayer(Optional ByVal theAutotile As Byte = 0)
        Dim X As Integer
        Dim Y As Integer
        Dim CurLayer As Integer

        CurLayer = frmEditor_MapEditor.cmbLayers.SelectedIndex + 1

        If MsgBox("Are you sure you wish to fill this layer?", vbYesNo, "Map Editor") = vbYes Then
            If theAutotile > 0 Then
                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Layer(CurLayer).X = EditorTileX
                        Map.Tile(X, Y).Layer(CurLayer).Y = EditorTileY
                        Map.Tile(X, Y).Layer(CurLayer).Tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1
                        Map.Tile(X, Y).Layer(CurLayer).AutoTile = theAutotile
                        CacheRenderState(X, Y, CurLayer)
                    Next
                Next

                ' do a re-init so we can see our changes
                initAutotiles()
            Else
                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Layer(CurLayer).X = EditorTileX
                        Map.Tile(X, Y).Layer(CurLayer).Y = EditorTileY
                        Map.Tile(X, Y).Layer(CurLayer).Tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1
                        CacheRenderState(X, Y, CurLayer)
                    Next
                Next
            End If
        End If
    End Sub

    Public Sub ClearAttributeDialogue()

        With frmEditor_MapEditor
            .fraNpcSpawn.Visible = False
            .fraResource.Visible = False
            .fraMapItem.Visible = False
            .fraMapKey.Visible = False
            .fraKeyOpen.Visible = False
            .fraMapWarp.Visible = False
            .fraShop.Visible = False
            .fraHeal.Visible = False
            .fraTrap.Visible = False
            .fraBuyHouse.Visible = False
        End With

    End Sub

    Public Sub MapEditorClearAttribs()
        Dim X As Integer
        Dim Y As Integer

        If MsgBox("Are you sure you wish to clear the attributes on this map?", vbYesNo, "MapEditor") = vbYes Then

            For X = 0 To Map.MaxX
                For Y = 0 To Map.MaxY
                    Map.Tile(X, Y).Type = 0
                Next
            Next

        End If

    End Sub

    Public Sub MapEditorLeaveMap()

        If InMapEditor Then
            If MsgBox("Save changes to current map?", vbYesNo) = vbYes Then
                MapEditorSend()
            Else
                MapEditorCancel()
            End If
        End If

    End Sub
#End Region

#Region "Auto Tiles"

#Region "Globals and Types"
    ' Autotiles
    Public Const AUTO_INNER As Byte = 1
    Public Const AUTO_OUTER As Byte = 2
    Public Const AUTO_HORIZONTAL As Byte = 3
    Public Const AUTO_VERTICAL As Byte = 4
    Public Const AUTO_FILL As Byte = 5

    ' Autotile types
    Public Const AUTOTILE_NONE As Byte = 0
    Public Const AUTOTILE_NORMAL As Byte = 1
    Public Const AUTOTILE_FAKE As Byte = 2
    Public Const AUTOTILE_ANIM As Byte = 3
    Public Const AUTOTILE_CLIFF As Byte = 4
    Public Const AUTOTILE_WATERFALL As Byte = 5

    ' Rendering
    Public Const RENDER_STATE_NONE As Integer = 0
    Public Const RENDER_STATE_NORMAL As Integer = 1
    Public Const RENDER_STATE_AUTOTILE As Integer = 2

    ' autotiling
    Public autoInner(0 To 4) As PointRec
    Public autoNW(0 To 4) As PointRec
    Public autoNE(0 To 4) As PointRec
    Public autoSW(0 To 4) As PointRec
    Public autoSE(0 To 4) As PointRec

    ' Map animations
    Public waterfallFrame As Integer
    Public autoTileFrame As Integer

    Public Autotile(,) As AutotileRec

    Public Structure PointRec
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure QuarterTileRec
        Dim QuarterTile() As PointRec '1 To 4
        Dim renderState As Byte
        Dim srcX() As Integer '1 To 4
        Dim srcY() As Integer '1 To 4
    End Structure

    Public Structure AutotileRec
        Dim Layer() As QuarterTileRec '1 To MapLayer.Count - 1
        Dim ExLayer() As QuarterTileRec '1 To ExMapLayer.Count - 1
    End Structure
#End Region

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '   All of this code is for auto tiles and the math behind generating them.
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Sub placeAutotile(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal tileQuarter As Byte, ByVal autoTileLetter As String)

        If layerNum > MapLayer.Count - 1 Then
            layerNum = layerNum - (MapLayer.Count - 1)
            With Autotile(X, Y).ExLayer(layerNum).QuarterTile(tileQuarter)
                Select Case autoTileLetter
                    Case "a"
                        .X = autoInner(1).X
                        .Y = autoInner(1).Y
                    Case "b"
                        .X = autoInner(2).X
                        .Y = autoInner(2).Y
                    Case "c"
                        .X = autoInner(3).X
                        .Y = autoInner(3).Y
                    Case "d"
                        .X = autoInner(4).X
                        .Y = autoInner(4).Y
                    Case "e"
                        .X = autoNW(1).X
                        .Y = autoNW(1).Y
                    Case "f"
                        .X = autoNW(2).X
                        .Y = autoNW(2).Y
                    Case "g"
                        .X = autoNW(3).X
                        .Y = autoNW(3).Y
                    Case "h"
                        .X = autoNW(4).X
                        .Y = autoNW(4).Y
                    Case "i"
                        .X = autoNE(1).X
                        .Y = autoNE(1).Y
                    Case "j"
                        .X = autoNE(2).X
                        .Y = autoNE(2).Y
                    Case "k"
                        .X = autoNE(3).X
                        .Y = autoNE(3).Y
                    Case "l"
                        .X = autoNE(4).X
                        .Y = autoNE(4).Y
                    Case "m"
                        .X = autoSW(1).X
                        .Y = autoSW(1).Y
                    Case "n"
                        .X = autoSW(2).X
                        .Y = autoSW(2).Y
                    Case "o"
                        .X = autoSW(3).X
                        .Y = autoSW(3).Y
                    Case "p"
                        .X = autoSW(4).X
                        .Y = autoSW(4).Y
                    Case "q"
                        .X = autoSE(1).X
                        .Y = autoSE(1).Y
                    Case "r"
                        .X = autoSE(2).X
                        .Y = autoSE(2).Y
                    Case "s"
                        .X = autoSE(3).X
                        .Y = autoSE(3).Y
                    Case "t"
                        .X = autoSE(4).X
                        .Y = autoSE(4).Y
                End Select
            End With
        Else
            With Autotile(X, Y).Layer(layerNum).QuarterTile(tileQuarter)
                Select Case autoTileLetter
                    Case "a"
                        .X = autoInner(1).X
                        .Y = autoInner(1).Y
                    Case "b"
                        .X = autoInner(2).X
                        .Y = autoInner(2).Y
                    Case "c"
                        .X = autoInner(3).X
                        .Y = autoInner(3).Y
                    Case "d"
                        .X = autoInner(4).X
                        .Y = autoInner(4).Y
                    Case "e"
                        .X = autoNW(1).X
                        .Y = autoNW(1).Y
                    Case "f"
                        .X = autoNW(2).X
                        .Y = autoNW(2).Y
                    Case "g"
                        .X = autoNW(3).X
                        .Y = autoNW(3).Y
                    Case "h"
                        .X = autoNW(4).X
                        .Y = autoNW(4).Y
                    Case "i"
                        .X = autoNE(1).X
                        .Y = autoNE(1).Y
                    Case "j"
                        .X = autoNE(2).X
                        .Y = autoNE(2).Y
                    Case "k"
                        .X = autoNE(3).X
                        .Y = autoNE(3).Y
                    Case "l"
                        .X = autoNE(4).X
                        .Y = autoNE(4).Y
                    Case "m"
                        .X = autoSW(1).X
                        .Y = autoSW(1).Y
                    Case "n"
                        .X = autoSW(2).X
                        .Y = autoSW(2).Y
                    Case "o"
                        .X = autoSW(3).X
                        .Y = autoSW(3).Y
                    Case "p"
                        .X = autoSW(4).X
                        .Y = autoSW(4).Y
                    Case "q"
                        .X = autoSE(1).X
                        .Y = autoSE(1).Y
                    Case "r"
                        .X = autoSE(2).X
                        .Y = autoSE(2).Y
                    Case "s"
                        .X = autoSE(3).X
                        .Y = autoSE(3).Y
                    Case "t"
                        .X = autoSE(4).X
                        .Y = autoSE(4).Y
                End Select
            End With
        End If

    End Sub

    Public Sub initAutotiles()
        Dim X As Integer, Y As Integer, layerNum As Integer
        ' Procedure used to cache autotile positions. All positioning is
        ' independant from the tileset. Calculations are convoluted and annoying.
        ' Maths is not my strong point. Luckily we're caching them so it's a one-off
        ' thing when the map is originally loaded. As such optimisation isn't an issue.
        ' For simplicity's sake we cache all subtile SOURCE positions in to an array.
        ' We also give letters to each subtile for easy rendering tweaks. ;]
        ' First, we need to re-size the array

        ReDim Autotile(0 To Map.MaxX, 0 To Map.MaxY)
        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)
                For i = 0 To MapLayer.Count - 1
                    ReDim Autotile(X, Y).Layer(i).srcX(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).srcY(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).QuarterTile(0 To 4)
                Next
            Next
        Next

        ' Inner tiles (Top right subtile region)
        ' NW - a
        autoInner(1).X = 32
        autoInner(1).Y = 0
        ' NE - b
        autoInner(2).X = 48
        autoInner(2).Y = 0
        ' SW - c
        autoInner(3).X = 32
        autoInner(3).Y = 16
        ' SE - d
        autoInner(4).X = 48
        autoInner(4).Y = 16
        ' Outer Tiles - NW (bottom subtile region)
        ' NW - e
        autoNW(1).X = 0
        autoNW(1).Y = 32
        ' NE - f
        autoNW(2).X = 16
        autoNW(2).Y = 32
        ' SW - g
        autoNW(3).X = 0
        autoNW(3).Y = 48
        ' SE - h
        autoNW(4).X = 16
        autoNW(4).Y = 48
        ' Outer Tiles - NE (bottom subtile region)
        ' NW - i
        autoNE(1).X = 32
        autoNE(1).Y = 32
        ' NE - g
        autoNE(2).X = 48
        autoNE(2).Y = 32
        ' SW - k
        autoNE(3).X = 32
        autoNE(3).Y = 48
        ' SE - l
        autoNE(4).X = 48
        autoNE(4).Y = 48
        ' Outer Tiles - SW (bottom subtile region)
        ' NW - m
        autoSW(1).X = 0
        autoSW(1).Y = 64
        ' NE - n
        autoSW(2).X = 16
        autoSW(2).Y = 64
        ' SW - o
        autoSW(3).X = 0
        autoSW(3).Y = 80
        ' SE - p
        autoSW(4).X = 16
        autoSW(4).Y = 80
        ' Outer Tiles - SE (bottom subtile region)
        ' NW - q
        autoSE(1).X = 32
        autoSE(1).Y = 64
        ' NE - r
        autoSE(2).X = 48
        autoSE(2).Y = 64
        ' SW - s
        autoSE(3).X = 32
        autoSE(3).Y = 80
        ' SE - t
        autoSE(4).X = 48
        autoSE(4).Y = 80

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                For layerNum = 1 To MapLayer.Count - 1
                    ' calculate the subtile positions and place them
                    CalculateAutotile(X, Y, layerNum)
                    ' cache the rendering state of the tiles and set them
                    CacheRenderState(X, Y, layerNum)
                Next
            Next
        Next

    End Sub

    Public Sub CacheRenderState(ByVal X As Integer, ByVal Y As Integer, ByVal layerNum As Integer)
        Dim quarterNum As Integer

        ' exit out early

        If X < 0 Or X > Map.MaxX Or Y < 0 Or Y > Map.MaxY Then Exit Sub

        With Map.Tile(X, Y)
            ' check if the tile can be rendered
            If .Layer(layerNum).Tileset <= 0 Or .Layer(layerNum).Tileset > NumTileSets Then
                Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NONE
                Exit Sub
            End If
            ' check if it's a key - hide mask if key is closed
            If layerNum = MapLayer.Mask Then
                If .Type = TileType.Key Then
                    If TempTile(X, Y).DoorOpen = False Then
                        Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NONE
                        Exit Sub
                    Else
                        Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NORMAL
                        Exit Sub
                    End If
                End If
            End If
            ' check if it needs to be rendered as an autotile
            If .Layer(layerNum).AutoTile = AUTOTILE_NONE Or .Layer(layerNum).AutoTile = AUTOTILE_FAKE Then
                'ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)
                ' default to... default
                Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NORMAL
            Else
                Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_AUTOTILE
                ' cache tileset positioning
                For quarterNum = 1 To 4
                    Autotile(X, Y).Layer(layerNum).srcX(quarterNum) = (Map.Tile(X, Y).Layer(layerNum).X * 32) + Autotile(X, Y).Layer(layerNum).QuarterTile(quarterNum).X
                    Autotile(X, Y).Layer(layerNum).srcY(quarterNum) = (Map.Tile(X, Y).Layer(layerNum).Y * 32) + Autotile(X, Y).Layer(layerNum).QuarterTile(quarterNum).Y
                Next
            End If
        End With
        ' End If

    End Sub

    Public Sub CalculateAutotile(ByVal X As Integer, ByVal Y As Integer, ByVal layerNum As Integer)
        ' Right, so we've split the tile block in to an easy to remember
        ' collection of letters. We now need to do the calculations to find
        ' out which little lettered block needs to be rendered. We do this
        ' by reading the surrounding tiles to check for matches.
        ' First we check to make sure an autotile situation is actually there.
        ' Then we calculate exactly which situation has arisen.
        ' The situations are "inner", "outer", "horizontal", "vertical" and "fill".
        ' Exit out if we don't have an autotile

        If Map.Tile(X, Y).Layer(layerNum).AutoTile = 0 Then Exit Sub
        ' Okay, we have autotiling but which one?
        Select Case Map.Tile(X, Y).Layer(layerNum).AutoTile
                ' Normal or animated - same difference
            Case AUTOTILE_NORMAL, AUTOTILE_ANIM
                ' North West Quarter
                CalculateNW_Normal(layerNum, X, Y)
                ' North East Quarter
                CalculateNE_Normal(layerNum, X, Y)
                ' South West Quarter
                CalculateSW_Normal(layerNum, X, Y)
                ' South East Quarter
                CalculateSE_Normal(layerNum, X, Y)
                ' Cliff
            Case AUTOTILE_CLIFF
                ' North West Quarter
                CalculateNW_Cliff(layerNum, X, Y)
                ' North East Quarter
                CalculateNE_Cliff(layerNum, X, Y)
                ' South West Quarter
                CalculateSW_Cliff(layerNum, X, Y)
                ' South East Quarter
                CalculateSE_Cliff(layerNum, X, Y)
                ' Waterfalls
            Case AUTOTILE_WATERFALL
                ' North West Quarter
                CalculateNW_Waterfall(layerNum, X, Y)
                ' North East Quarter
                CalculateNE_Waterfall(layerNum, X, Y)
                ' South West Quarter
                CalculateSW_Waterfall(layerNum, X, Y)
                ' South East Quarter
                CalculateSE_Waterfall(layerNum, X, Y)
                ' Anything else
            Case Else
                ' Don't need to render anything... it's fake or not an autotile
        End Select
        ' End If

    End Sub

    ' Normal autotiling
    Public Sub CalculateNW_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North West

        If checkTileMatch(layerNum, X, Y, X - 1, Y - 1) Then tmpTile(1) = True
        ' North
        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(2) = True
        ' West
        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(2) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If Not tmpTile(2) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(2) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If Not tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 1, "e")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 1, "a")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 1, "i")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 1, "m")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 1, "q")
        End Select

    End Sub

    Public Sub CalculateNE_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North

        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(1) = True
        ' North East
        If checkTileMatch(layerNum, X, Y, X + 1, Y - 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If tmpTile(1) And Not tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 2, "j")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 2, "b")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 2, "f")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 2, "r")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 2, "n")
        End Select

    End Sub

    Public Sub CalculateSW_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(1) = True
        ' South West
        If checkTileMatch(layerNum, X, Y, X - 1, Y + 1) Then tmpTile(2) = True
        ' South
        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If tmpTile(1) And Not tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 3, "o")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 3, "c")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 3, "s")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 3, "g")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 3, "k")
        End Select

    End Sub

    Public Sub CalculateSE_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' South

        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(1) = True
        ' South East
        If checkTileMatch(layerNum, X, Y, X + 1, Y + 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If tmpTile(1) And Not tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 4, "t")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 4, "d")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 4, "p")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 4, "l")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 4, "h")
        End Select

    End Sub

    ' Waterfall autotiling
    Public Sub CalculateNW_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 1, "i")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 1, "e")
        End If

    End Sub

    Public Sub CalculateNE_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' East

        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 2, "f")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 2, "j")
        End If

    End Sub

    Public Sub CalculateSW_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 3, "k")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 3, "g")
        End If

    End Sub

    Public Sub CalculateSE_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' East

        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 4, "h")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 4, "l")
        End If

    End Sub

    ' Cliff autotiling
    Public Sub CalculateNW_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North West

        If checkTileMatch(layerNum, X, Y, X - 1, Y - 1) Then tmpTile(1) = True
        ' North
        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(2) = True
        ' West
        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation - Horizontal
        If Not tmpTile(2) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(2) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(2) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 1, "e")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 1, "i")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 1, "m")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 1, "q")
        End Select

    End Sub

    Public Sub CalculateNE_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North

        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(1) = True
        ' North East
        If checkTileMatch(layerNum, X, Y, X + 1, Y - 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation - Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 2, "j")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 2, "f")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 2, "r")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 2, "n")
        End Select

    End Sub

    Public Sub CalculateSW_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(1) = True
        ' South West
        If checkTileMatch(layerNum, X, Y, X - 1, Y + 1) Then tmpTile(2) = True
        ' South
        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation - Horizontal
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 3, "o")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 3, "s")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 3, "g")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 3, "k")
        End Select

    End Sub

    Public Sub CalculateSE_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' South

        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(1) = True
        ' South East
        If checkTileMatch(layerNum, X, Y, X + 1, Y + 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation -  Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 4, "t")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 4, "p")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 4, "l")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 4, "h")
        End Select

    End Sub

    Public Function checkTileMatch(ByVal layerNum As Integer, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Boolean
        ' we'll exit out early if true
        Dim exTile As Boolean

        If layerNum > MapLayer.Count - 1 Then exTile = True : layerNum = layerNum - (MapLayer.Count - 1)
        checkTileMatch = True
        ' if it's off the map then set it as autotile and exit out early
        If X2 < 0 Or X2 > Map.MaxX Or Y2 < 0 Or Y2 > Map.MaxY Then
            checkTileMatch = True
            Exit Function
        End If

        ' fakes ALWAYS return true
        If Map.Tile(X2, Y2).Layer(layerNum).AutoTile = AUTOTILE_FAKE Then
            checkTileMatch = True
            Exit Function
        End If
        ' End If

        ' check neighbour is an autotile
        If Map.Tile(X2, Y2).Layer(layerNum).AutoTile = 0 Then
            checkTileMatch = False
            Exit Function
        End If
        ' End If

        ' check we're a matching
        If Map.Tile(X1, Y1).Layer(layerNum).Tileset <> Map.Tile(X2, Y2).Layer(layerNum).Tileset Then
            checkTileMatch = False
            Exit Function
        End If

        ' check tiles match
        If Map.Tile(X1, Y1).Layer(layerNum).X <> Map.Tile(X2, Y2).Layer(layerNum).X Then
            checkTileMatch = False
            Exit Function
        Else
            If Map.Tile(X1, Y1).Layer(layerNum).Y <> Map.Tile(X2, Y2).Layer(layerNum).Y Then
                checkTileMatch = False
                Exit Function
            End If
        End If
    End Function

    Public Sub DrawAutoTile(ByVal layerNum As Integer, ByVal destX As Integer, ByVal destY As Integer, ByVal quarterNum As Integer, ByVal X As Integer, ByVal Y As Integer, Optional forceFrame As Integer = 0, Optional strict As Boolean = True, Optional ExLayer As Boolean = False)
        Dim YOffset As Integer, XOffset As Integer
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim tmpSprite As Sprite

        ' calculate the offset
        If forceFrame > 0 Then
            Select Case forceFrame - 1
                Case 0
                    waterfallFrame = 1
                Case 1
                    waterfallFrame = 2
                Case 2
                    waterfallFrame = 0
            End Select
            ' animate autotiles
            Select Case forceFrame - 1
                Case 0
                    autoTileFrame = 1
                Case 1
                    autoTileFrame = 2
                Case 2
                    autoTileFrame = 0
            End Select
        End If


        Select Case Map.Tile(X, Y).Layer(layerNum).AutoTile
            Case AUTOTILE_WATERFALL
                YOffset = (waterfallFrame - 1) * 32
            Case AUTOTILE_ANIM
                XOffset = autoTileFrame * 64
            Case AUTOTILE_CLIFF
                YOffset = -32
        End Select

        ' Draw the quarter
        tmpSprite = New Sprite(TileSetTexture(Map.Tile(X, Y).Layer(layerNum).Tileset))
        tmpSprite.TextureRect = New IntRect(Autotile(X, Y).Layer(layerNum).srcX(quarterNum) + XOffset, Autotile(X, Y).Layer(layerNum).srcY(quarterNum) + YOffset, 16, 16)
        tmpSprite.Position = New SFML.Window.Vector2f(destX, destY)
        GameWindow.Draw(tmpSprite)

    End Sub
#End Region
End Class