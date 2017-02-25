﻿Imports System.Drawing
Imports System.Windows.Forms

Public Class frmEditor_MapEditor
#Region "Frm"
    Private Sub FrmEditor_Map_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cmbTileSets.SelectedIndex = 0
        EditorMap_DrawTileset()
        pnlAttributes.BringToFront()
        pnlAttributes.Visible = False
        pnlAttributes.Left = 4
        pnlAttributes.Top = 28
        Me.Width = 525
        optBlocked.Checked = True
        tabpages.SelectedIndex = 0

        scrlFog.Maximum = NumFogs
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        MapEditorSend()
        GettingMap = True
    End Sub

    Private Sub TsbFill_Click(sender As Object, e As EventArgs) Handles tsbFill.Click
        MapEditorFillLayer(cmbAutoTile.SelectedIndex)
    End Sub

    Private Sub TsbClear_Click(sender As Object, e As EventArgs) Handles tsbClear.Click
        MapEditorClearLayer()
    End Sub

    Private Sub TsbDiscard_Click(sender As Object, e As EventArgs) Handles tsbDiscard.Click
        MapEditorCancel()
    End Sub

    Private Sub TsbMapGrid_Click(sender As Object, e As EventArgs) Handles tsbMapGrid.Click
        MapGrid = Not MapGrid
    End Sub
#End Region

#Region "Tiles"
    Private Sub PicBackSelect_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picBackSelect.MouseDown
        MapEditorChooseTile(e.Button, e.X, e.Y)
    End Sub

    Private Sub PicBackSelect_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picBackSelect.MouseMove
        MapEditorDrag(e.Button, e.X, e.Y)
    End Sub

    Private Sub PicBackSelect_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picBackSelect.Paint
        'Overrides the paint sub
    End Sub

    Private Sub PnlBack_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlBack.Paint
        'Overrides the paint sub
    End Sub

    Private Sub ScrlPictureY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPictureY.ValueChanged
        MapEditorTileScroll()
    End Sub

    Private Sub ScrlPictureX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPictureX.ValueChanged
        MapEditorTileScroll()
    End Sub

    Private Sub CmbTileSets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTileSets.Click
        If cmbTileSets.SelectedIndex + 1 > NumTileSets Then
            cmbTileSets.SelectedIndex = 0
        End If

        Map.Tileset = cmbTileSets.SelectedIndex + 1

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        picBackSelect.Height = TileSetTextureInfo(cmbTileSets.SelectedIndex + 1).Height
        picBackSelect.Width = TileSetTextureInfo(cmbTileSets.SelectedIndex + 1).Width

        scrlPictureY.Maximum = (picBackSelect.Height \ PIC_Y)
        scrlPictureX.Maximum = (picBackSelect.Width \ PIC_X)
    End Sub

    Private Sub CmbAutoTile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAutoTile.SelectedIndexChanged
        If cmbAutoTile.SelectedIndex = 0 Then
            EditorTileWidth = 1
            EditorTileHeight = 1
        End If
    End Sub
#End Region

#Region "Attributes"
    Private Sub ScrlMapWarpMap_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMapWarpMap.ValueChanged
        lblMapWarpMap.Text = "Map: " & scrlMapWarpMap.Value
    End Sub

    Private Sub ScrlMapWarpX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMapWarpX.ValueChanged
        lblMapWarpX.Text = "X: " & scrlMapWarpX.Value
    End Sub

    Private Sub ScrlMapWarpY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMapWarpY.ValueChanged
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
        If optWarp.Checked = False Then Exit Sub

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

    Private Sub ScrlMapItem_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMapItem.ValueChanged
        If Item(scrlMapItem.Value).Type = ItemType.Currency Or Item(scrlMapItem.Value).Stackable = 1 Then
            scrlMapItemValue.Enabled = True
        Else
            scrlMapItemValue.Value = 1
            scrlMapItemValue.Enabled = False
        End If

        EditorMap_DrawMapItem()
        lblMapItem.Text = "Item: " & scrlMapItem.Value & ". " & Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub ScrlMapItemValue_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMapItemValue.ValueChanged
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
    End Sub

    Private Sub BtnMapItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapItem.Click
        ItemEditorNum = scrlMapItem.Value
        ItemEditorValue = scrlMapItemValue.Value
        pnlAttributes.Visible = False
        fraMapItem.Visible = False
    End Sub

    Private Sub OptItem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optItem.CheckedChanged
        If optItem.Checked = False Then Exit Sub

        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapItem.Visible = True

        scrlMapItem.Maximum = MAX_ITEMS
        scrlMapItem.Value = 1
        lblMapItem.Text = Trim$(Item(scrlMapItem.Value).Name) & " x" & scrlMapItemValue.Value
        EditorMap_DrawMapItem()
    End Sub

    Private Sub ScrlMapKey_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlMapKey.ValueChanged
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
        If optKey.Checked = False Then Exit Sub

        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraMapKey.Visible = True

        scrlMapKey.Maximum = MAX_ITEMS
        scrlMapKey.Value = 1
        chkMapKey.Checked = True
        EditorMap_DrawKey()
        lblMapKey.Text = "Item: " & Trim$(Item(scrlMapKey.Value).Name)
    End Sub

    Private Sub ScrlKeyX_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlKeyX.ValueChanged
        lblKeyX.Text = "X: " & scrlKeyX.Value
    End Sub

    Private Sub ScrlKeyY_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlKeyY.ValueChanged
        lblKeyY.Text = "X: " & scrlKeyY.Value
    End Sub

    Private Sub BtnMapKeyOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapKeyOpen.Click
        KeyOpenEditorX = scrlKeyX.Value
        KeyOpenEditorY = scrlKeyY.Value
        pnlAttributes.Visible = False
        fraKeyOpen.Visible = False
    End Sub

    Private Sub OptKeyOpen_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optKeyOpen.CheckedChanged
        If optKeyOpen.Checked = False Then Exit Sub

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

    Private Sub ScrlResource_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlResource.ValueChanged
        lblResource.Text = "Resource: " & Resource(scrlResource.Value).Name
    End Sub

    Private Sub OptResource_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optResource.CheckedChanged
        If optResource.Checked = False Then Exit Sub

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

    Private Sub OptNPCSpawn_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optNPCSpawn.CheckedChanged
        Dim n As Integer
        If optNPCSpawn.Checked = False Then Exit Sub

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
        If optShop.Checked = False Then Exit Sub

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

    Private Sub ScrlHeal_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlHeal.ValueChanged
        lblHeal.Text = "Amount: " & scrlHeal.Value
    End Sub

    Private Sub OptHeal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optHeal.CheckedChanged
        If optHeal.Checked = False Then Exit Sub

        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraHeal.Visible = True
    End Sub

    Private Sub ScrlTrap_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlTrap.ValueChanged
        lblTrap.Text = "Amount: " & scrlTrap.Value
    End Sub

    Private Sub BtnTrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrap.Click
        MapEditorHealAmount = scrlTrap.Value
        pnlAttributes.Visible = False
        fraTrap.Visible = False
    End Sub

    Private Sub OptTrap_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles optTrap.CheckedChanged
        If optTrap.Checked = False Then Exit Sub

        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraTrap.Visible = True
    End Sub

    Private Sub BtnClearAttribute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAttribute.Click
        MapEditorClearAttribs()
    End Sub

    Private Sub ScrlNpcDir_Scroll(sender As Object, e As EventArgs) Handles scrlNpcDir.ValueChanged
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
        If optHouse.Checked = False Then Exit Sub

        ClearAttributeDialogue()
        pnlAttributes.Visible = True
        fraBuyHouse.Visible = True
        scrlBuyHouse.Maximum = MAX_HOUSES
        scrlBuyHouse.Value = 1
    End Sub

    Private Sub ScrlBuyHouse_Scroll(sender As Object, e As EventArgs) Handles scrlBuyHouse.ValueChanged
        lblHouseName.Text = scrlBuyHouse.Value & ". " & HouseConfig(scrlBuyHouse.Value).ConfigName
    End Sub

    Private Sub BtnHouseTileOk_Click(sender As Object, e As EventArgs) Handles btnHouseTileOk.Click
        HouseTileIndex = scrlBuyHouse.Value
        pnlAttributes.Visible = False
        fraBuyHouse.Visible = False
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
#End Region

#Region "Settings"
    Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
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
            .Name = Trim$(txtName.Text)
            If lstMusic.SelectedIndex >= 0 Then
                .Music = lstMusic.Items(lstMusic.SelectedIndex).ToString
            Else
                .Music = ""
            End If
            .Up = Val(txtUp.Text)
            .Down = Val(txtDown.Text)
            .Left = Val(txtLeft.Text)
            .Right = Val(txtRight.Text)
            .Moral = cmbMoral.SelectedIndex
            .BootMap = Val(txtBootMap.Text)
            .BootX = Val(txtBootX.Text)
            .BootY = Val(txtBootY.Text)

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
                    ReDim .Tile(X, Y).Layer(0 To MapLayer.Count - 1)

                    ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)

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
#End Region

#Region "Events"
    Private Sub BtnCopyEvent_Click(sender As Object, e As EventArgs) Handles btnCopyEvent.Click
        If EventCopy = False Then
            EventCopy = True
            lblCopyMode.Text = "CopyMode On"
            EventPaste = False
            lblPasteMode.Text = "PasteMode Off"
        Else
            EventCopy = False
            lblCopyMode.Text = "CopyMode Off"
        End If
    End Sub

    Private Sub BtnPasteEvent_Click(sender As Object, e As EventArgs) Handles btnPasteEvent.Click
        If EventPaste = False Then
            EventPaste = True
            lblPasteMode.Text = "PasteMode On"
            EventCopy = False
            lblCopyMode.Text = "CopyMode Off"
        Else
            EventPaste = False
            lblPasteMode.Text = "PasteMode Off"
        End If
    End Sub
#End Region

#Region "Map Effects"
    Private Sub CmbWeather_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWeather.SelectedIndexChanged
        Map.WeatherType = cmbWeather.SelectedIndex
    End Sub

    Private Sub ScrlFog_Scroll(sender As Object, e As EventArgs) Handles scrlFog.ValueChanged
        Map.FogIndex = scrlFog.Value
        lblFogIndex.Text = "Fog: " & scrlFog.Value
    End Sub

    Private Sub ScrlIntensity_Scroll(sender As Object, e As EventArgs) Handles scrlIntensity.ValueChanged
        Map.WeatherIntensity = scrlIntensity.Value
        lblIntensity.Text = "Intensity: " & scrlIntensity.Value
    End Sub

    Private Sub ScrlFogSpeed_Scroll(sender As Object, e As EventArgs) Handles scrlFogSpeed.ValueChanged
        Map.FogSpeed = scrlFogSpeed.Value
        lblFogSpeed.Text = "FogSpeed: " & scrlFogSpeed.Value
    End Sub

    Private Sub ScrlFogAlpha_Scroll(sender As Object, e As EventArgs) Handles scrlFogAlpha.ValueChanged
        Map.FogAlpha = scrlFogAlpha.Value
        lblFogAlpha.Text = "Fog Alpha: " & scrlFogAlpha.Value
    End Sub

    Private Sub ChkUseTint_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseTint.CheckedChanged
        If chkUseTint.Checked = True Then
            Map.HasMapTint = 1
        Else
            Map.HasMapTint = 0
        End If
    End Sub

    Private Sub ScrlMapRed_Scroll(sender As Object, e As EventArgs) Handles scrlMapRed.ValueChanged
        Map.MapTintR = scrlMapRed.Value
        lblMapRed.Text = "Red: " & scrlMapRed.Value
    End Sub

    Private Sub ScrlMapGreen_Scroll(sender As Object, e As EventArgs) Handles scrlMapGreen.ValueChanged
        Map.MapTintG = scrlMapGreen.Value
        lblMapGreen.Text = "Green: " & scrlMapGreen.Value
    End Sub

    Private Sub ScrlMapBlue_Scroll(sender As Object, e As EventArgs) Handles scrlMapBlue.ValueChanged
        Map.MapTintB = scrlMapBlue.Value
        lblMapBlue.Text = "Blue: " & scrlMapBlue.Value
    End Sub

    Private Sub ScrlMapAlpha_Scroll(sender As Object, e As EventArgs) Handles scrlMapAlpha.ValueChanged
        Map.MapTintA = scrlMapAlpha.Value
        lblMapAlpha.Text = "Alpha: " & scrlMapAlpha.Value
    End Sub

    Private Sub CmbPanorama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPanorama.SelectedIndexChanged
        Map.Panorama = cmbPanorama.SelectedIndex
    End Sub

    Private Sub CmbParallax_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParallax.SelectedIndexChanged
        Map.Parallax = cmbParallax.SelectedIndex
    End Sub
#End Region

#Region "Map Editor"

    Public Sub MapPropertiesInit()
        Dim X As Integer, Y As Integer, i As Integer

        txtName.Text = Trim$(Map.Name)

        ' find the music we have set

        lstMusic.Items.Clear()
        lstMusic.Items.Add("None")

        If UBound(MusicCache) > 0 Then
            For i = 1 To UBound(MusicCache)
                lstMusic.Items.Add(MusicCache(i))
            Next
        End If

        If Trim$(Map.Music) = "None" Then
            lstMusic.SelectedIndex = 0
        Else
            For i = 1 To lstMusic.Items.Count
                If lstMusic.Items(i - 1).ToString = Trim$(Map.Music) Then
                    lstMusic.SelectedIndex = i - 1
                    Exit For
                End If
            Next
        End If

        ' rest of it
        txtUp.Text = Map.Up
        txtDown.Text = Map.Down
        txtLeft.Text = Map.Left
        txtRight.Text = Map.Right
        cmbMoral.SelectedIndex = Map.Moral
        txtBootMap.Text = Map.BootMap
        txtBootX.Text = Map.BootX
        txtBootY.Text = Map.BootY

        lstMapNpc.Items.Clear()

        For X = 1 To MAX_MAP_NPCS
            If Map.Npc(X) = 0 Then
                lstMapNpc.Items.Add("No NPC")
            Else
                lstMapNpc.Items.Add(X & ": " & Trim$(Npc(Map.Npc(X)).Name))
            End If

        Next

        cmbNpcList.Items.Clear()
        cmbNpcList.Items.Add("No NPC")

        For Y = 1 To MAX_NPCS
            cmbNpcList.Items.Add(Y & ": " & Trim$(Npc(Y).Name))
        Next

        lblMap.Text = "Current map: " & "?"
        txtMaxX.Text = Map.MaxX
        txtMaxY.Text = Map.MaxY

        cmbTileSets.SelectedIndex = 0
        cmbLayers.SelectedIndex = 0
        cmbAutoTile.SelectedIndex = 0

        cmbWeather.SelectedIndex = Map.WeatherType
        scrlFog.Value = Map.FogIndex
        lblFogIndex.Text = "Fog: " & scrlFog.Value
        scrlIntensity.Value = Map.WeatherIntensity
        lblIntensity.Text = "Intensity: " & scrlIntensity.Value

        cmbPanorama.Items.Clear()
        cmbPanorama.Items.Add("None")
        For i = 1 To NumPanorama
            cmbPanorama.Items.Add("Panorama" & i)
        Next

        cmbParallax.Items.Clear()
        cmbParallax.Items.Add("None")
        For i = 1 To NumParallax
            cmbParallax.Items.Add("Parallax" & i)
        Next

        ' render the tiles
        EditorMap_DrawTileset()

        tabpages.SelectedIndex = 0

        ' show the form
        Visible = True

    End Sub

    Public Sub MapEditorInit()
        ' we're in the map editor
        InMapEditor = True

        ' set the scrolly bars
        If Map.tileset = 0 Then Map.tileset = 1
        If Map.tileset > NumTileSets Then Map.tileset = 1

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)

        ' set the scrollbars
        scrlPictureY.Maximum = (picBackSelect.Height \ PIC_Y) \ 2 ' \2 is new, lets test
        scrlPictureX.Maximum = (picBackSelect.Width \ PIC_X) \ 2

        ' set shops for the shop attribute
        cmbShop.Items.Add("None")
        For i = 1 To MAX_SHOPS
            cmbShop.Items.Add(i & ": " & Shop(i).Name)
        Next
        ' we're not in a shop
        cmbShop.SelectedIndex = 0

        optBlocked.Checked = True

        cmbTileSets.Items.Clear()
        For i = 1 To NumTileSets
            cmbTileSets.Items.Add("Tileset " & i)
        Next

        cmbTileSets.SelectedIndex = 0
        cmbLayers.SelectedIndex = 0

        InitMapProperties = True

        If MapData = True Then GettingMap = False

    End Sub

    Public Sub MapEditorTileScroll()
        picBackSelect.Top = (scrlPictureY.Value * PIC_Y) * -1
        picBackSelect.Left = (scrlPictureX.Value * PIC_X) * -1
    End Sub

    Public Sub MapEditorChooseTile(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)

        If Button = MouseButtons.Left Then 'Left Mouse Button

            EditorTileWidth = 1
            EditorTileHeight = 1

            If cmbAutoTile.SelectedIndex > 0 Then
                Select Case cmbAutoTile.SelectedIndex
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
            If X > picBackSelect.Width / PIC_X Then X = picBackSelect.Width / PIC_X
            If Y < 0 Then Y = 0
            If Y > picBackSelect.Height / PIC_Y Then Y = picBackSelect.Height / PIC_Y
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

        CurLayer = cmbLayers.SelectedIndex + 1

        If Not IsInBounds() Then Exit Sub
        If Button = MouseButtons.Left Then
            If tabpages.SelectedTab Is tpTiles Then
                If EditorTileWidth = 1 And EditorTileHeight = 1 Then 'single tile

                    MapEditorSetTile(CurX, CurY, CurLayer, False, cmbAutoTile.SelectedIndex)
                Else ' multi tile!
                    If cmbAutoTile.SelectedIndex = 0 Then
                        MapEditorSetTile(CurX, CurY, CurLayer, True)
                    Else
                        MapEditorSetTile(CurX, CurY, CurLayer, , cmbAutoTile.SelectedIndex)
                    End If
                End If
            ElseIf tabpages.SelectedTab Is tpAttributes Then
                With Map.Tile(CurX, CurY)
                    ' blocked tile
                    If optBlocked.Checked = True Then .Type = TileType.Blocked
                    ' warp tile
                    If optWarp.Checked = True Then
                        .Type = TileType.Warp
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' item spawn
                    If optItem.Checked = True Then
                        .Type = TileType.Item
                        .Data1 = ItemEditorNum
                        .Data2 = ItemEditorValue
                        .Data3 = 0
                    End If
                    ' npc avoid
                    If optNPCAvoid.Checked = True Then
                        .Type = TileType.NpcAvoid
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' key
                    If optKey.Checked = True Then
                        .Type = TileType.Key
                        .Data1 = KeyEditorNum
                        .Data2 = KeyEditorTake
                        .Data3 = 0
                    End If
                    ' key open
                    If optKeyOpen.Checked = True Then
                        .Type = TileType.KeyOpen
                        .Data1 = KeyOpenEditorX
                        .Data2 = KeyOpenEditorY
                        .Data3 = 0
                    End If
                    ' resource
                    If optResource.Checked = True Then
                        .Type = TileType.Resource
                        .Data1 = ResourceEditorNum
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' door
                    If optDoor.Checked = True Then
                        .Type = TileType.Door
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' npc spawn
                    If optNPCSpawn.Checked = True Then
                        .Type = TileType.NpcSpawn
                        .Data1 = SpawnNpcNum
                        .Data2 = SpawnNpcDir
                        .Data3 = 0
                    End If
                    ' shop
                    If optShop.Checked = True Then
                        .Type = TileType.Shop
                        .Data1 = EditorShop
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' bank
                    If optBank.Checked = True Then
                        .Type = TileType.Bank
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' heal
                    If optHeal.Checked = True Then
                        .Type = TileType.Heal
                        .Data1 = MapEditorHealType
                        .Data2 = MapEditorHealAmount
                        .Data3 = 0
                    End If
                    ' trap
                    If optTrap.Checked = True Then
                        .Type = TileType.Trap
                        .Data1 = MapEditorHealAmount
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'Housing
                    If optHouse.Checked Then
                        .Type = TileType.House
                        .Data1 = HouseTileIndex
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'craft tile
                    If optCraft.Checked Then
                        .Type = TileType.Craft
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'light
                    If optLight.Checked Then
                        .Type = TileType.Light
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                End With
            ElseIf tabpages.SelectedTab Is tpDirBlock Then
                If movedMouse Then Exit Sub
                ' find what tile it is
                X = X - ((X \ PIC_X) * PIC_X)
                Y = Y - ((Y \ PIC_Y) * PIC_Y)
                ' see if it hits an arrow
                For i = 1 To 4
                    If X >= DirArrowX(i) And X <= DirArrowX(i) + 8 Then
                        If Y >= DirArrowY(i) And Y <= DirArrowY(i) + 8 Then
                            ' flip the value.
                            SetDirBlock(Map.Tile(CurX, CurY).DirBlock, (i), Not IsDirBlocked(Map.Tile(CurX, CurY).DirBlock, (i)))
                            Exit Sub
                        End If
                    End If
                Next
            ElseIf tabpages.SelectedTab Is tpEvents Then
                If FrmEditor_Events.Visible = False Then
                    If EventCopy Then
                        CopyEvent_Map(CurX, CurY)
                    ElseIf EventPaste Then
                        PasteEvent_Map(CurX, CurY)
                    Else
                        AddEvent(CurX, CurY)
                    End If
                End If
            End If
        End If

        If Button = MouseButtons.Right Then
            If tabpages.SelectedTab Is tpTiles Then

                With Map.Tile(CurX, CurY)
                    ' clear layer
                    .Layer(CurLayer).X = 0
                    .Layer(CurLayer).Y = 0
                    .Layer(CurLayer).Tileset = 0
                    If .Layer(CurLayer).AutoTile > 0 Then
                        .Layer(CurLayer).AutoTile = 0
                        ' do a re-init so we can see our changes
                        InitAutotiles()
                    End If
                    CacheRenderState(X, Y, CurLayer)
                End With

            ElseIf tabpages.SelectedTab Is tpAttributes Then
                With Map.Tile(CurX, CurY)
                    ' clear attribute
                    .Type = 0
                    .Data1 = 0
                    .Data2 = 0
                    .Data3 = 0
                End With
            ElseIf tabpages.SelectedTab Is tpEvents Then
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
        Visible = False
        GettingMap = True
    End Sub

    Public Sub MapEditorSend()
        SendMap()
        InMapEditor = False
        Visible = False
        GettingMap = True
    End Sub

    Public Sub MapEditorSetTile(ByVal X As Integer, ByVal Y As Integer, ByVal CurLayer As Integer, Optional ByVal multitile As Boolean = False, Optional ByVal theAutotile As Byte = 0)
        Dim x2 As Integer, y2 As Integer

        If theAutotile > 0 Then
            With Map.Tile(X, Y)
                ' set layer
                .Layer(CurLayer).X = EditorTileX
                .Layer(CurLayer).Y = EditorTileY
                .Layer(CurLayer).Tileset = cmbTileSets.SelectedIndex + 1
                .Layer(CurLayer).AutoTile = theAutotile
                CacheRenderState(X, Y, CurLayer)
            End With
            ' do a re-init so we can see our changes
            InitAutotiles()
            Exit Sub
        End If

        If Not multitile Then ' single
            With Map.Tile(X, Y)
                ' set layer
                .Layer(CurLayer).X = EditorTileX
                .Layer(CurLayer).Y = EditorTileY
                .Layer(CurLayer).Tileset = cmbTileSets.SelectedIndex + 1
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
                                .Layer(CurLayer).Tileset = cmbTileSets.SelectedIndex + 1
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

        CurLayer = cmbLayers.SelectedIndex + 1

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

        CurLayer = cmbLayers.SelectedIndex + 1

        If MsgBox("Are you sure you wish to fill this layer?", vbYesNo, "Map Editor") = vbYes Then
            If theAutotile > 0 Then
                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Layer(CurLayer).X = EditorTileX
                        Map.Tile(X, Y).Layer(CurLayer).Y = EditorTileY
                        Map.Tile(X, Y).Layer(CurLayer).Tileset = cmbTileSets.SelectedIndex + 1
                        Map.Tile(X, Y).Layer(CurLayer).AutoTile = theAutotile
                        CacheRenderState(X, Y, CurLayer)
                    Next
                Next

                ' do a re-init so we can see our changes
                InitAutotiles()
            Else
                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Layer(CurLayer).X = EditorTileX
                        Map.Tile(X, Y).Layer(CurLayer).Y = EditorTileY
                        Map.Tile(X, Y).Layer(CurLayer).Tileset = cmbTileSets.SelectedIndex + 1
                        CacheRenderState(X, Y, CurLayer)
                    Next
                Next
            End If
        End If
    End Sub

    Public Sub ClearAttributeDialogue()

        fraNpcSpawn.Visible = False
        fraResource.Visible = False
        fraMapItem.Visible = False
        fraMapKey.Visible = False
        fraKeyOpen.Visible = False
        fraMapWarp.Visible = False
        fraShop.Visible = False
        fraHeal.Visible = False
        fraTrap.Visible = False
        fraBuyHouse.Visible = False

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

    Private Sub ChkInstance_CheckedChanged(sender As Object, e As EventArgs) Handles chkInstance.CheckedChanged
        If chkInstance.Checked = True Then
            Map.Instanced = 1
        Else
            Map.Instanced = 0
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

End Class