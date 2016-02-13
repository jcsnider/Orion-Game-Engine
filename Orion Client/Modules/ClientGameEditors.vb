Imports System.Drawing
Imports System.Windows.Forms

Module ClientGameEditors

#Region "Animation Editor"
    Public Sub AnimationEditorInit()

        If frmEditor_Animation.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Animation.lstIndex.SelectedIndex + 1

        With Animation(EditorIndex)
            frmEditor_Animation.txtName.Text = Trim$(.Name)

            frmEditor_Animation.scrlSprite0.Value = .Sprite(0)
            frmEditor_Animation.scrlFrameCount0.Value = .Frames(0)
            frmEditor_Animation.scrlLoopCount0.Value = .LoopCount(0)
            frmEditor_Animation.scrlLoopTime0.Value = .looptime(0)

            frmEditor_Animation.scrlSprite1.Value = .Sprite(1)
            frmEditor_Animation.scrlFrameCount1.Value = .Frames(1)
            frmEditor_Animation.scrlLoopCount1.Value = .LoopCount(1)
            frmEditor_Animation.scrlLoopTime1.Value = .looptime(1)

            EditorIndex = frmEditor_Animation.lstIndex.SelectedIndex + 1
        End With

        Call EditorAnim_DrawAnim()
        Animation_Changed(EditorIndex) = True
    End Sub

    Public Sub AnimationEditorOk()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS
            If Animation_Changed(i) Then
                Call SendSaveAnimation(i)
            End If
        Next

        frmEditor_Animation.Visible = False
        Editor = 0
        ClearChanged_Animation()
    End Sub

    Public Sub AnimationEditorCancel()
        Editor = 0
        frmEditor_Animation.Visible = False
        ClearChanged_Animation()
        ClearAnimations()
        SendRequestAnimations()
    End Sub

    Public Sub ClearChanged_Animation()
        For i = 0 To MAX_ANIMATIONS
            Animation_Changed(i) = False
        Next
    End Sub

#End Region

#Region "Map Editor"

    Public Sub MapPropertiesInit()
        Dim X As Long
        Dim Y As Long
        Dim i As Long
        Dim di As New IO.DirectoryInfo(Application.StartupPath & MUSIC_PATH)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.*")
        Dim fi As IO.FileInfo
        ReDim frmEditor_MapProperties.cmbNpcs(0 To 30)
        Dim StartX
        Dim StartY
        StartX = 6
        StartY = 19


        frmEditor_MapProperties.txtName.Text = Trim$(Map.Name)
        ' find the music we have set
        frmEditor_MapProperties.lstMusic.Items.Clear()
        frmEditor_MapProperties.lstMusic.Items.Add("None")

        For Each fi In aryFi
            frmEditor_MapProperties.lstMusic.Items.Add(fi.Name)
        Next

        If Trim$(Map.Music) = "None" Then
            frmEditor_MapProperties.lstMusic.SelectedIndex = 0
        Else
            For i = 1 To frmEditor_MapProperties.lstMusic.Items.Count
                If frmEditor_MapProperties.lstMusic.Items(i - 1).ToString = Trim$(Map.Music) Then
                    frmEditor_MapProperties.lstMusic.SelectedIndex = i - 1
                    Exit For
                End If
            Next
        End If

        ' rest of it
        frmEditor_MapProperties.txtUp.Text = Map.Up
        frmEditor_MapProperties.txtDown.Text = Map.Down
        frmEditor_MapProperties.txtLeft.Text = Map.Left
        frmEditor_MapProperties.txtRight.Text = Map.Right
        frmEditor_MapProperties.cmbMoral.SelectedIndex = Map.Moral
        frmEditor_MapProperties.txtBootMap.Text = Map.BootMap
        frmEditor_MapProperties.txtBootX.Text = Map.BootX
        frmEditor_MapProperties.txtBootY.Text = Map.BootY


        For i = 1 To 15
            frmEditor_MapProperties.cmbNpcs(i) = New cmbNpc
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc = New ComboBox
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Width = 133
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Height = 21
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Left = StartX
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Top = StartY + ((i - 1) * 27)
            frmEditor_MapProperties.Controls.Add(frmEditor_MapProperties.cmbNpcs(i).cmbNpc)
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.DropDownStyle = ComboBoxStyle.DropDownList
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Parent = frmEditor_MapProperties.fraNpcs
        Next
        StartX = 165
        For i = 16 To 30
            frmEditor_MapProperties.cmbNpcs(i) = New cmbNpc
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc = New ComboBox
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Width = 133
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Height = 21
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Left = StartX
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Top = StartY + ((i - 16) * 27)
            frmEditor_MapProperties.Controls.Add(frmEditor_MapProperties.cmbNpcs(i).cmbNpc)
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.DropDownStyle = ComboBoxStyle.DropDownList
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.Parent = frmEditor_MapProperties.fraNpcs
        Next

        For X = 1 To MAX_MAP_NPCS
            frmEditor_MapProperties.cmbNpcs(X).cmbNpc.Items.Add("No NPC")
        Next


        For Y = 1 To MAX_NPCS
            For X = 1 To MAX_MAP_NPCS
                frmEditor_MapProperties.cmbNpcs(X).cmbNpc.Items.Add(Y & ": " & Trim$(Npc(Y).Name))
            Next
        Next

        For i = 1 To MAX_MAP_NPCS
            frmEditor_MapProperties.cmbNpcs(i).cmbNpc.SelectedIndex = Map.Npc(i)
        Next

        frmEditor_MapProperties.lblMap.Text = "Current map: " & GetPlayerMap(MyIndex)
        frmEditor_MapProperties.txtMaxX.Text = Map.MaxX
        frmEditor_MapProperties.txtMaxY.Text = Map.MaxY
    End Sub

    Public Sub MapEditorInit()
        ' we're in the map editor
        InMapEditor = True
        ' show the form
        frmEditor_Map.Visible = True
        ' set the scrolly bars
        If Map.tileset = 0 Then Map.tileset = 1
        If Map.tileset > NumTileSets Then Map.tileset = 1
        frmEditor_Map.fraTileSet.Text = "Tileset: " & Map.tileset

        EditorTileSelStart = New Point(0, 0)
        EditorTileSelEnd = New Point(1, 1)
        ' render the tiles
        Call EditorMap_DrawTileset()
        ' set the scrollbars
        frmEditor_Map.scrlPictureY.Maximum = (frmEditor_Map.picBackSelect.Height \ PIC_Y)
        frmEditor_Map.scrlPictureX.Maximum = (frmEditor_Map.picBackSelect.Width \ PIC_X)

        ' set shops for the shop attribute
        frmEditor_Map.cmbShop.Items.Add("None")
        For i = 1 To MAX_SHOPS
            frmEditor_Map.cmbShop.Items.Add(i & ": " & Shop(i).Name)
        Next
        ' we're not in a shop
        frmEditor_Map.cmbShop.SelectedIndex = 0

        frmEditor_Map.optBlocked.Checked = True

        ' music in map properties
        'If frmEditor_MapProperties.fMusic.Path <> Application.StartupPath & MUSIC_PATH Then frmEditor_MapProperties.fMusic.Path = Application.StartupPath & MUSIC_PATH
    End Sub

    Public Sub MapEditorTileScroll()
        frmEditor_Map.picBackSelect.Top = (frmEditor_Map.scrlPictureY.Value * PIC_Y) * -1
        frmEditor_Map.picBackSelect.Left = (frmEditor_Map.scrlPictureX.Value * PIC_X) * -1
    End Sub

    Public Sub MapEditorChooseTile(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)

        If Button = MouseButtons.Left Then 'Left Mouse Button

            EditorTileWidth = 1
            EditorTileHeight = 1

            If frmEditor_Map.scrlAutotile.Value > 0 Then
                Select Case frmEditor_Map.scrlAutotile.Value
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
            If X > frmEditor_Map.picBackSelect.Width / PIC_X Then X = frmEditor_Map.picBackSelect.Width / PIC_X
            If Y < 0 Then Y = 0
            If Y > frmEditor_Map.picBackSelect.Height / PIC_Y Then Y = frmEditor_Map.picBackSelect.Height / PIC_Y
            ' find out what to set the width + height of map editor to
            If X > EditorTileX Then ' drag right
                'EditorTileWidth = X
                EditorTileWidth = X - EditorTileX
                'Debug.Print("EditorTileWidth = " & EditorTileWidth)
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

    Public Sub MapEditorMouseDown(ByVal Button As Integer, ByVal X As Long, ByVal Y As Long, Optional ByVal movedMouse As Boolean = True)
        Dim i As Long
        Dim CurLayer As Long

        If frmEditor_Map.optGround.Checked = True Then CurLayer = 1
        If frmEditor_Map.optMask.Checked = True Then CurLayer = 2
        If frmEditor_Map.optMask2.Checked = True Then CurLayer = 3
        If frmEditor_Map.optFringe.Checked = True Then CurLayer = 4
        If frmEditor_Map.optFringe2.Checked = True Then CurLayer = 5

        If Not isInBounds() Then Exit Sub
        If Button = MouseButtons.Left Then
            If frmEditor_Map.optLayers.Checked = True Then
                ' (EditorTileSelEnd.X - EditorTileSelStart.X) = 1 And (EditorTileSelEnd.Y - EditorTileSelStart.Y) = 1 Then 'single tile
                If EditorTileWidth = 1 And EditorTileHeight = 1 Then

                    MapEditorSetTile(CurX, CurY, CurLayer, False, frmEditor_Map.scrlAutotile.Value)
                Else ' multi tile!
                    If frmEditor_Map.scrlAutotile.Value = 0 Then
                        MapEditorSetTile(CurX, CurY, CurLayer, True)
                    Else
                        MapEditorSetTile(CurX, CurY, CurLayer, , frmEditor_Map.scrlAutotile.Value)
                    End If
                End If
            ElseIf frmEditor_Map.optAttributes.Checked = True Then
                With Map.Tile(CurX, CurY)
                    ' blocked tile
                    If frmEditor_Map.optBlocked.Checked = True Then .Type = TILE_TYPE_BLOCKED
                    ' warp tile
                    If frmEditor_Map.optWarp.Checked = True Then
                        .Type = TILE_TYPE_WARP
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' item spawn
                    If frmEditor_Map.optItem.Checked = True Then
                        .Type = TILE_TYPE_ITEM
                        .Data1 = ItemEditorNum
                        .Data2 = ItemEditorValue
                        .Data3 = 0
                    End If
                    ' npc avoid
                    If frmEditor_Map.optNPCAvoid.Checked = True Then
                        .Type = TILE_TYPE_NPCAVOID
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' key
                    If frmEditor_Map.optKey.Checked = True Then
                        .Type = TILE_TYPE_KEY
                        .Data1 = KeyEditorNum
                        .Data2 = KeyEditorTake
                        .Data3 = 0
                    End If
                    ' key open
                    If frmEditor_Map.optKeyOpen.Checked = True Then
                        .Type = TILE_TYPE_KEYOPEN
                        .Data1 = KeyOpenEditorX
                        .Data2 = KeyOpenEditorY
                        .Data3 = 0
                    End If
                    ' resource
                    If frmEditor_Map.optResource.Checked = True Then
                        .Type = TILE_TYPE_RESOURCE
                        .Data1 = ResourceEditorNum
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' door
                    If frmEditor_Map.optDoor.Checked = True Then
                        .Type = TILE_TYPE_DOOR
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' npc spawn
                    If frmEditor_Map.optNPCSpawn.Checked = True Then
                        .Type = TILE_TYPE_NPCSPAWN
                        .Data1 = SpawnNpcNum
                        .Data2 = SpawnNpcDir
                        .Data3 = 0
                    End If
                    ' shop
                    If frmEditor_Map.optShop.Checked = True Then
                        .Type = TILE_TYPE_SHOP
                        .Data1 = EditorShop
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' bank
                    If frmEditor_Map.optBank.Checked = True Then
                        .Type = TILE_TYPE_BANK
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' heal
                    If frmEditor_Map.optHeal.Checked = True Then
                        .Type = TILE_TYPE_HEAL
                        .Data1 = MapEditorHealType
                        .Data2 = MapEditorHealAmount
                        .Data3 = 0
                    End If
                    ' trap
                    If frmEditor_Map.optTrap.Checked = True Then
                        .Type = TILE_TYPE_TRAP
                        .Data1 = MapEditorHealAmount
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'Housing
                    If frmEditor_Map.optHouse.Checked Then
                        .Type = TILE_TYPE_HOUSE
                        .Data1 = HouseTileIndex
                        .Data2 = 0
                        .Data3 = 0
                    End If
                End With
            ElseIf frmEditor_Map.optBlocks.Checked = True Then
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
            ElseIf frmEditor_Map.optEvent.Checked Then
                If frmEditor_Events.Visible = False Then
                    AddEvent(CurX, CurY)
                End If
            End If
        End If

        If Button = MouseButtons.Right Then
            If frmEditor_Map.optLayers.Checked = True Then
                'If CurLayer > MapLayer.Layer_Count - 1 Then
                '    With Map.exTile(CurX, CurY)
                '        ' clear layer
                '        .Layer(CurLayer - (MapLayer.Layer_Count - 1)).X = 0
                '        .Layer(CurLayer - (MapLayer.Layer_Count - 1)).Y = 0
                '        .Layer(CurLayer - (MapLayer.Layer_Count - 1)).tileset = 0
                '        If .Autotile(CurLayer - (MapLayer.Layer_Count - 1)) > 0 Then
                '            .Autotile(CurLayer - (MapLayer.Layer_Count - 1)) = 0
                '            ' do a re-init so we can see our changes
                '            initAutotiles()
                '        End If
                '        CacheRenderState(X, Y, CurLayer)
                '    End With
                'Else
                With Map.Tile(CurX, CurY)
                    ' clear layer
                    .Layer(CurLayer).X = 0
                    .Layer(CurLayer).Y = 0
                    .Layer(CurLayer).tileset = 0
                    If .Autotile(CurLayer) > 0 Then
                        .Autotile(CurLayer) = 0
                        ' do a re-init so we can see our changes
                        initAutotiles()
                    End If
                    CacheRenderState(X, Y, CurLayer)
                End With
            End If
        ElseIf frmEditor_Map.optAttributes.Checked = True Then
            With Map.Tile(CurX, CurY)
                ' clear attribute
                .Type = 0
                .Data1 = 0
                .Data2 = 0
                .Data3 = 0
            End With
        ElseIf frmEditor_Map.optEvent.Checked Then
            Call DeleteEvent(CurX, CurY)
        End If
        ' End If

    End Sub

    Public Sub MapEditorCancel()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CNeedMap)
        Buffer.WriteLong(1)
        SendData(Buffer.ToArray())
        InMapEditor = False
        frmEditor_Map.Visible = False
        GettingMap = True

        'clear memory
        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
        Next i
    End Sub

    Public Sub MapEditorSend()
        SendMap()
        InMapEditor = False
        frmEditor_Map.Visible = False
        GettingMap = True

        'clear memory
        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
        Next i
    End Sub

    Public Sub MapEditorSetTile(ByVal X As Long, ByVal Y As Long, ByVal CurLayer As Long, Optional ByVal multitile As Boolean = False, Optional ByVal theAutotile As Byte = 0)
        Dim x2 As Long, y2 As Long

        If theAutotile > 0 Then
            'If CurLayer > MapLayer.Layer_Count - 1 Then
            '    With Map.exTile(X, Y)
            '        ' set layer
            '        .Layer(CurLayer - (ExMapLayer.Layer_Count - 1)).X = EditorTileX
            '        .Layer(CurLayer - (ExMapLayer.Layer_Count - 1)).Y = EditorTileY
            '        .Layer(CurLayer - (ExMapLayer.Layer_Count - 1)).tileset = frmEditor_Map.scrlTileSet.Value
            '        .Autotile(CurLayer - (ExMapLayer.Layer_Count - 1)) = theAutotile
            '        CacheRenderState(X, Y, CurLayer)
            '    End With

            'Else
            With Map.Tile(X, Y)
                ' set layer
                .Layer(CurLayer).X = EditorTileX
                .Layer(CurLayer).Y = EditorTileY
                .Layer(CurLayer).tileset = frmEditor_Map.scrlTileSet.Value
                .Autotile(CurLayer) = theAutotile
                CacheRenderState(X, Y, CurLayer)
            End With
        End If
        ' do a re-init so we can see our changes
        initAutotiles()
        Exit Sub
        ' End If

        If Not multitile Then ' single
            'If CurLayer > (MapLayer.Layer_Count - 1) Then
            '    With Map.exTile(X, Y)
            '        ' set layer
            '        .Layer(CurLayer - (MapLayer.Layer_Count - 1)).X = EditorTileX
            '        .Layer(CurLayer - (MapLayer.Layer_Count - 1)).Y = EditorTileY
            '        .Layer(CurLayer - (MapLayer.Layer_Count - 1)).tileset = frmEditor_Map.scrlTileSet.Value
            '        .Autotile(CurLayer - (MapLayer.Layer_Count - 1)) = 0
            '        CacheRenderState(X, Y, CurLayer)
            '    End With
            'Else
            With Map.Tile(X, Y)
                ' set layer
                .Layer(CurLayer).X = EditorTileX
                .Layer(CurLayer).Y = EditorTileY
                .Layer(CurLayer).tileset = frmEditor_Map.scrlTileSet.Value
                .Autotile(CurLayer) = 0
                CacheRenderState(X, Y, CurLayer)
            End With
            ' End If
        Else ' multitile
            y2 = 0 ' starting tile for y axis
            For Y = CurY To CurY + EditorTileHeight - 1
                x2 = 0 ' re-set x count every y loop
                For X = CurX To CurX + EditorTileWidth - 1
                    If X >= 0 And X <= Map.MaxX Then
                        If Y >= 0 And Y <= Map.MaxY Then
                            'If CurLayer > (MapLayer.Layer_Count - 1) Then
                            '    With Map.exTile(X, Y)
                            '        .Layer(CurLayer - (ExMapLayer.Layer_Count - 1)).X = EditorTileX + x2
                            '        .Layer(CurLayer - (ExMapLayer.Layer_Count - 1)).Y = EditorTileY + y2
                            '        .Layer(CurLayer - (ExMapLayer.Layer_Count - 1)).tileset = frmEditor_Map.scrlTileSet.Value
                            '        .Autotile(CurLayer - (ExMapLayer.Layer_Count - 1)) = 0
                            '        CacheRenderState(X, Y, CurLayer)
                            '    End With

                            'Else
                            With Map.Tile(X, Y)
                                .Layer(CurLayer).X = EditorTileX + x2
                                .Layer(CurLayer).Y = EditorTileY + y2
                                .Layer(CurLayer).tileset = frmEditor_Map.scrlTileSet.Value
                                .Autotile(CurLayer) = 0
                                CacheRenderState(X, Y, CurLayer)
                            End With
                            ' End If
                        End If
                    End If
                    x2 = x2 + 1
                Next
                y2 = y2 + 1
            Next
        End If
    End Sub

    Public Sub MapEditorClearLayer()
        Dim X As Long
        Dim Y As Long
        Dim CurLayer As Long

        If frmEditor_Map.optGround.Checked = True Then CurLayer = 1
        If frmEditor_Map.optMask.Checked = True Then CurLayer = 2
        If frmEditor_Map.optMask2.Checked = True Then CurLayer = 3
        If frmEditor_Map.optFringe.Checked = True Then CurLayer = 4
        If frmEditor_Map.optFringe2.Checked = True Then CurLayer = 5

        If CurLayer = 0 Then Exit Sub

        ' ask to clear layer
        If MsgBox("Are you sure you wish to clear this layer?", vbYesNo, GAME_NAME) = vbYes Then
            For X = 0 To Map.MaxX
                For Y = 0 To Map.MaxY
                    Map.Tile(X, Y).Layer(CurLayer).X = 0
                    Map.Tile(X, Y).Layer(CurLayer).Y = 0
                    Map.Tile(X, Y).Layer(CurLayer).tileset = 0
                    CacheRenderState(X, Y, CurLayer)
                Next
            Next
        End If
    End Sub

    Public Sub MapEditorFillLayer()
        Dim X As Long
        Dim Y As Long
        Dim CurLayer As Long

        If frmEditor_Map.optGround.Checked = True Then CurLayer = 1
        If frmEditor_Map.optMask.Checked = True Then CurLayer = 2
        If frmEditor_Map.optMask2.Checked = True Then CurLayer = 3
        If frmEditor_Map.optFringe.Checked = True Then CurLayer = 4
        If frmEditor_Map.optFringe2.Checked = True Then CurLayer = 5

        ' Ground layer
        If MsgBox("Are you sure you wish to fill this layer?", vbYesNo, GAME_NAME) = vbYes Then
            For X = 0 To Map.MaxX
                For Y = 0 To Map.MaxY
                    Map.Tile(X, Y).Layer(CurLayer).X = EditorTileX
                    Map.Tile(X, Y).Layer(CurLayer).Y = EditorTileY
                    Map.Tile(X, Y).Layer(CurLayer).tileset = frmEditor_Map.scrlTileSet.Value
                    CacheRenderState(X, Y, CurLayer)
                Next
            Next
        End If
    End Sub

    Public Sub ClearAttributeDialogue()
        frmEditor_Map.fraNpcSpawn.Visible = False
        frmEditor_Map.fraResource.Visible = False
        frmEditor_Map.fraMapItem.Visible = False
        frmEditor_Map.fraMapKey.Visible = False
        frmEditor_Map.fraKeyOpen.Visible = False
        frmEditor_Map.fraMapWarp.Visible = False
        frmEditor_Map.fraShop.Visible = False
        frmEditor_Map.fraHeal.Visible = False
        frmEditor_Map.fraTrap.Visible = False
        frmEditor_Map.fraBuyHouse.Visible = False
    End Sub

    Public Sub MapEditorClearAttribs()
        Dim X As Long
        Dim Y As Long

        If MsgBox("Are you sure you wish to clear the attributes on this map?", vbYesNo, GAME_NAME) = vbYes Then

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
                Call MapEditorSend()
            Else
                Call MapEditorCancel()
            End If
        End If

    End Sub
#End Region

#Region "Item Editor"
    Public Sub ItemEditorPreInit()
        Dim i As Long

        With frmEditor_Item
            Editor = EDITOR_ITEM
            .lstIndex.Items.Clear()

            ' Add the names
            For i = 1 To MAX_ITEMS
                .lstIndex.Items.Add(i & ": " & Trim$(Item(i).Name))
            Next

            .Show()
            .lstIndex.SelectedIndex = 0
            ItemEditorInit()
        End With
    End Sub

    Public Sub ItemEditorInit()
        Dim i As Long

        If frmEditor_Item.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Item.lstIndex.SelectedIndex + 1

        With Item(EditorIndex)
            frmEditor_Item.txtName.Text = Trim$(.Name)
            If .Pic > frmEditor_Item.scrlPic.Maximum Then .Pic = 0
            frmEditor_Item.scrlPic.Value = .Pic
            frmEditor_Item.cmbType.SelectedIndex = .Type
            frmEditor_Item.scrlAnim.Value = .Animation

            ' Type specific settings
            If (frmEditor_Item.cmbType.SelectedIndex >= ITEM_TYPE_WEAPON) And (frmEditor_Item.cmbType.SelectedIndex <= ITEM_TYPE_SHIELD) Then
                frmEditor_Item.fraEquipment.Visible = True
                frmEditor_Item.scrlDamage.Value = .Data2
                frmEditor_Item.cmbTool.SelectedIndex = .Data3

                If .Speed < 100 Then .Speed = 100
                frmEditor_Item.scrlSpeed.Value = .Speed

                frmEditor_Item.scrlAddStr.Value = .Add_Stat(Stats.strength)
                frmEditor_Item.scrlAddEnd.Value = .Add_Stat(Stats.endurance)
                frmEditor_Item.scrlAddInt.Value = .Add_Stat(Stats.intelligence)
                frmEditor_Item.scrlAddVit.Value = .Add_Stat(Stats.vitality)
                frmEditor_Item.scrlAddWill.Value = .Add_Stat(Stats.willpower)
                frmEditor_Item.scrlAddSpr.Value = .Add_Stat(Stats.spirit)


                frmEditor_Item.scrlPaperdoll.Value = .Paperdoll
            Else
                frmEditor_Item.fraEquipment.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex >= ITEM_TYPE_POTIONADDHP) And (frmEditor_Item.cmbType.SelectedIndex <= ITEM_TYPE_POTIONSUBSP) Then
                frmEditor_Item.fraVitals.Visible = True
                frmEditor_Item.scrlVitalMod.Value = .Data1
            Else
                frmEditor_Item.fraVitals.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex = ITEM_TYPE_SPELL) Then
                frmEditor_Item.fraSpell.Visible = True
                frmEditor_Item.scrlSpell.Value = .Data1
            Else
                frmEditor_Item.fraSpell.Visible = False
            End If

            If frmEditor_Item.cmbType.SelectedIndex = ITEM_TYPE_FURNITURE Then
                frmEditor_Item.fraFurniture.Visible = True
                If Item(EditorIndex).Data2 > 0 And Item(EditorIndex).Data2 <= NumFurniture Then
                    frmEditor_Item.scrlFurniture.Value = Item(EditorIndex).Data2
                Else
                    frmEditor_Item.scrlFurniture.Value = 1
                End If
                frmEditor_Item.cmbFurnitureType.SelectedIndex = Item(EditorIndex).Data1
            Else
                frmEditor_Item.fraFurniture.Visible = False
            End If

            ' Basic requirements
            frmEditor_Item.scrlAccessReq.Value = .AccessReq
            frmEditor_Item.scrlLevelReq.Value = .LevelReq

            frmEditor_Item.scrlStrReq.Value = .Stat_Req(Stats.strength)
            frmEditor_Item.scrlVitReq.Value = .Stat_Req(Stats.vitality)
            frmEditor_Item.scrlWillReq.Value = .Stat_Req(Stats.willpower)
            frmEditor_Item.scrlEndReq.Value = .Stat_Req(Stats.endurance)
            frmEditor_Item.scrlIntReq.Value = .Stat_Req(Stats.intelligence)
            frmEditor_Item.scrlSprReq.Value = .Stat_Req(Stats.spirit)

            ' Build cmbClassReq
            frmEditor_Item.cmbClassReq.Items.Clear()
            frmEditor_Item.cmbClassReq.Items.Add("None")

            For i = 1 To Max_Classes
                frmEditor_Item.cmbClassReq.Items.Add(Classes(i).Name)
            Next

            frmEditor_Item.cmbClassReq.SelectedIndex = .ClassReq
            ' Info
            frmEditor_Item.scrlPrice.Value = .Price
            frmEditor_Item.cmbBind.SelectedIndex = .BindType
            frmEditor_Item.scrlRarity.Value = .Rarity

            EditorIndex = frmEditor_Item.lstIndex.SelectedIndex + 1
        End With

        frmEditor_Item.scrlPic.Maximum = NumItems
        frmEditor_Item.scrlAnim.Maximum = MAX_ANIMATIONS

        If NumPaperdolls > 0 Then
            frmEditor_Item.scrlPaperdoll.Maximum = NumPaperdolls + 1
        End If


        EditorItem_DrawItem()
        EditorItem_DrawPaperdoll()
        EditorItem_DrawFurniture()
        Item_Changed(EditorIndex) = True

    End Sub

    Public Sub ItemEditorCancel()
        Editor = 0
        frmEditor_Item.Visible = False
        ClearChanged_Item()
        ClearItems()
        SendRequestItems()
    End Sub

    Public Sub ItemEditorOk()
        Dim i As Long

        For i = 1 To MAX_ITEMS
            If Item_Changed(i) Then
                SendSaveItem(i)
            End If
        Next

        frmEditor_Item.Visible = False
        Editor = 0
        ClearChanged_Item()
    End Sub
#End Region

#Region "Npc Editor"
    Public Sub NpcEditorInit()

        If frmEditor_NPC.Visible = False Then Exit Sub
        EditorIndex = frmEditor_NPC.lstIndex.SelectedIndex + 1

        If Npc(EditorIndex).AttackSay Is Nothing Then Npc(EditorIndex).AttackSay = ""
        If Npc(EditorIndex).Name Is Nothing Then Npc(EditorIndex).Name = ""

        With frmEditor_NPC
            .txtName.Text = Trim$(Npc(EditorIndex).Name)
            .txtAttackSay.Text = Trim$(Npc(EditorIndex).AttackSay)
            If Npc(EditorIndex).Sprite < 0 Or Npc(EditorIndex).Sprite > .scrlSprite.Maximum Then Npc(EditorIndex).Sprite = 0
            .scrlSprite.Value = Npc(EditorIndex).Sprite
            .txtSpawnSecs.Text = Npc(EditorIndex).SpawnSecs
            .cmbBehaviour.SelectedIndex = Npc(EditorIndex).Behaviour
            .cmbFaction.SelectedIndex = Npc(EditorIndex).faction
            .scrlRange.Value = Npc(EditorIndex).Range
            .txtChance.Text = Npc(EditorIndex).DropChance
            .scrlNum.Value = Npc(EditorIndex).DropItem
            .scrlValue.Value = Npc(EditorIndex).DropItemValue
            .txtHP.Text = Npc(EditorIndex).HP
            .txtEXP.Text = Npc(EditorIndex).EXP
            .scrlQuest.Value = Npc(EditorIndex).QuestNum

            .scrlStr.Value = Npc(EditorIndex).Stat(Stats.strength)
            .scrlEnd.Value = Npc(EditorIndex).Stat(Stats.endurance)
            .scrlInt.Value = Npc(EditorIndex).Stat(Stats.intelligence)
            .scrlSpr.Value = Npc(EditorIndex).Stat(Stats.spirit)
            .scrlWill.Value = Npc(EditorIndex).Stat(Stats.willpower)
            .scrlVit.Value = Npc(EditorIndex).Stat(Stats.vitality)
        End With

        Call EditorNpc_DrawSprite()
        NPC_Changed(EditorIndex) = True
    End Sub

    Public Sub NpcEditorOk()
        Dim i As Long

        For i = 1 To MAX_NPCS
            If NPC_Changed(i) Then
                Call SendSaveNpc(i)
            End If
        Next

        frmEditor_NPC.Visible = False
        Editor = 0
        ClearChanged_NPC()
    End Sub

    Public Sub NpcEditorCancel()
        Editor = 0
        frmEditor_NPC.Visible = False
        ClearChanged_NPC()
        ClearNpcs()
        SendRequestNPCS()
    End Sub

    Public Sub ClearChanged_NPC()
        For i = 1 To MAX_NPCS
            NPC_Changed(i) = False
        Next
    End Sub
#End Region

#Region "Resource Editor"
    Public Sub ResourceEditorInit()

        If frmEditor_Resource.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Resource.lstIndex.SelectedIndex + 1

        frmEditor_Resource.scrlExhaustedPic.Maximum = NumResources
        frmEditor_Resource.scrlNormalPic.Maximum = NumResources
        frmEditor_Resource.scrlAnimation.Maximum = MAX_ANIMATIONS
        frmEditor_Resource.txtName.Text = Trim$(Resource(EditorIndex).Name)
        frmEditor_Resource.txtMessage.Text = Trim$(Resource(EditorIndex).SuccessMessage)
        frmEditor_Resource.txtMessage2.Text = Trim$(Resource(EditorIndex).EmptyMessage)
        frmEditor_Resource.cmbType.SelectedIndex = Resource(EditorIndex).ResourceType
        frmEditor_Resource.scrlNormalPic.Value = Resource(EditorIndex).ResourceImage
        frmEditor_Resource.scrlExhaustedPic.Value = Resource(EditorIndex).ExhaustedImage
        frmEditor_Resource.scrlReward.Value = Resource(EditorIndex).ItemReward
        frmEditor_Resource.scrlTool.Value = Resource(EditorIndex).ToolRequired
        frmEditor_Resource.scrlHealth.Value = Resource(EditorIndex).Health
        frmEditor_Resource.scrlRespawn.Value = Resource(EditorIndex).RespawnTime
        frmEditor_Resource.scrlAnimation.Value = Resource(EditorIndex).Animation
        frmEditor_Resource.Visible = True
        Call EditorResource_DrawSprite()

        Resource_Changed(EditorIndex) = True
    End Sub

    Public Sub ResourceEditorOk()
        Dim i As Long

        For i = 1 To MAX_RESOURCES
            If Resource_Changed(i) Then
                Call SendSaveResource(i)
            End If
        Next

        frmEditor_Resource.Visible = False
        Editor = 0
        ClearChanged_Resource()
    End Sub

    Public Sub ResourceEditorCancel()
        Editor = 0
        frmEditor_Resource.Visible = False
        ClearChanged_Resource()
        ClearResources()
        SendRequestResources()
    End Sub
#End Region

#Region "Spell Editor"
    Public Sub SpellEditorInit()
        Dim i As Long

        If frmEditor_Spell.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Spell.lstIndex.SelectedIndex + 1

        If Spell(EditorIndex).Name Is Nothing Then Spell(EditorIndex).Name = ""

        With frmEditor_Spell
            ' set max values
            .scrlAnimCast.Maximum = MAX_ANIMATIONS
            .scrlAnim.Maximum = MAX_ANIMATIONS
            .scrlAOE.Maximum = MAX_BYTE
            .scrlRange.Maximum = MAX_BYTE
            .scrlMap.Maximum = MAX_MAPS

            ' build class combo
            .cmbClass.Items.Clear()
            .cmbClass.Items.Add("None")
            For i = 1 To Max_Classes
                .cmbClass.Items.Add(Trim$(Classes(i).Name))
            Next
            .cmbClass.SelectedIndex = 0

            ' set values
            .txtName.Text = Trim$(Spell(EditorIndex).Name)
            .cmbType.SelectedIndex = Spell(EditorIndex).Type
            .scrlMP.Value = Spell(EditorIndex).MPCost
            .scrlLevel.Value = Spell(EditorIndex).LevelReq
            .scrlAccess.Value = Spell(EditorIndex).AccessReq
            .cmbClass.SelectedIndex = Spell(EditorIndex).ClassReq
            .scrlCast.Value = Spell(EditorIndex).CastTime
            .scrlCool.Value = Spell(EditorIndex).CDTime
            .scrlIcon.Value = Spell(EditorIndex).Icon
            .scrlMap.Value = Spell(EditorIndex).Map
            .scrlX.Value = Spell(EditorIndex).X
            .scrlY.Value = Spell(EditorIndex).Y
            .scrlDir.Value = Spell(EditorIndex).Dir
            .scrlVital.Value = Spell(EditorIndex).Vital
            .scrlDuration.Value = Spell(EditorIndex).Duration
            .scrlInterval.Value = Spell(EditorIndex).Interval
            .scrlRange.Value = Spell(EditorIndex).Range
            If Spell(EditorIndex).IsAoE = True Then
                .chkAOE.Checked = True
            Else
                .chkAOE.Checked = False
            End If
            .scrlAOE.Value = Spell(EditorIndex).AoE
            .scrlAnimCast.Value = Spell(EditorIndex).CastAnim
            .scrlAnim.Value = Spell(EditorIndex).SpellAnim
            .scrlStun.Value = Spell(EditorIndex).StunDuration
        End With

        EditorSpell_BltIcon()

        Spell_Changed(EditorIndex) = True
    End Sub

    Public Sub SpellEditorOk()
        Dim i As Long

        For i = 1 To MAX_SPELLS
            If Spell_Changed(i) Then
                Call SendSaveSpell(i)
            End If
        Next

        frmEditor_Spell.Visible = False
        Editor = 0
        ClearChanged_Spell()
    End Sub

    Public Sub SpellEditorCancel()
        Editor = 0
        frmEditor_Spell.Visible = False
        ClearChanged_Spell()
        ClearSpells()
        SendRequestSpells()
    End Sub

    Public Sub ClearChanged_Spell()
        For i = 1 To MAX_SPELLS
            Spell_Changed(i) = False
        Next
    End Sub
#End Region

#Region "Shop editor"
    Public Sub ShopEditorInit()
        Dim i As Long

        If frmEditor_Shop.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Shop.lstIndex.SelectedIndex + 1

        frmEditor_Shop.txtName.Text = Trim$(Shop(EditorIndex).Name)
        If Shop(EditorIndex).BuyRate > 0 Then
            frmEditor_Shop.scrlBuy.Value = Shop(EditorIndex).BuyRate
        Else
            frmEditor_Shop.scrlBuy.Value = 100
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
        Dim i As Long
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
        Dim i As Long

        For i = 1 To MAX_SHOPS
            If Shop_Changed(i) Then
                Call SendSaveShop(i)
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
End Module
