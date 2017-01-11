Module GameEditors

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

        EditorAnim_DrawAnim()
        Animation_Changed(EditorIndex) = True
    End Sub

    Public Sub AnimationEditorOk()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS
            If Animation_Changed(i) Then
                SendSaveAnimation(i)
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
        Dim X As Integer, Y As Integer, i As Integer

        FrmEditor_DarkMapEditor.txtName.Text = Trim$(Map.Name)

        ' find the music we have set

        FrmEditor_DarkMapEditor.lstMusic.Items.Clear()
        FrmEditor_DarkMapEditor.lstMusic.Items.Add("None")

        If UBound(MusicCache) > 0 Then
            For i = 1 To UBound(MusicCache)
                FrmEditor_DarkMapEditor.lstMusic.Items.Add(MusicCache(i))
            Next
        End If

        If Trim$(Map.Music) = "None" Then
            FrmEditor_DarkMapEditor.lstMusic.SelectedIndex = 0
        Else
            For i = 1 To FrmEditor_DarkMapEditor.lstMusic.Items.Count
                If FrmEditor_DarkMapEditor.lstMusic.Items(i - 1).ToString = Trim$(Map.Music) Then
                    FrmEditor_DarkMapEditor.lstMusic.SelectedIndex = i - 1
                    Exit For
                End If
            Next
        End If

        ' rest of it
        FrmEditor_DarkMapEditor.txtUp.Text = Map.Up
        FrmEditor_DarkMapEditor.txtDown.Text = Map.Down
        FrmEditor_DarkMapEditor.txtLeft.Text = Map.Left
        FrmEditor_DarkMapEditor.txtRight.Text = Map.Right
        FrmEditor_DarkMapEditor.cmbMoral.SelectedIndex = Map.Moral
        FrmEditor_DarkMapEditor.txtSpawnMap.Text = Map.BootMap
        FrmEditor_DarkMapEditor.txtSpawnX.Text = Map.BootX
        FrmEditor_DarkMapEditor.txtSpawnY.Text = Map.BootY

        If Map.Instanced = 1 Then
            FrmEditor_DarkMapEditor.chkInstance.Checked = True
        Else
            FrmEditor_DarkMapEditor.chkInstance.Checked = False
        End If

        FrmEditor_DarkMapEditor.lstMapNpc.Items.Clear()

        For X = 1 To MAX_MAP_NPCS
            If Map.Npc(X) = 0 Then
                FrmEditor_DarkMapEditor.lstMapNpc.Items.Add("No NPC")
            Else
                FrmEditor_DarkMapEditor.lstMapNpc.Items.Add(X & ": " & Trim$(Npc(Map.Npc(X)).Name))
            End If

        Next

        FrmEditor_DarkMapEditor.cmbNpcList.Items.Clear()
        FrmEditor_DarkMapEditor.cmbNpcList.Items.Add("No NPC")

        For Y = 1 To MAX_NPCS
            FrmEditor_DarkMapEditor.cmbNpcList.Items.Add(Y & ": " & Trim$(Npc(Y).Name))
        Next

        FrmEditor_DarkMapEditor.lblMap.Text = "Current map: " & Map.MapNum
        FrmEditor_DarkMapEditor.txtMaxX.Text = Map.MaxX
        FrmEditor_DarkMapEditor.txtMaxY.Text = Map.MaxY

        FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex = 0
        FrmEditor_DarkMapEditor.cmbLayers.SelectedIndex = 0
        FrmEditor_DarkMapEditor.cmbAutoTile.SelectedIndex = 0

        FrmEditor_DarkMapEditor.cmbWeather.SelectedIndex = Map.WeatherType
        FrmEditor_DarkMapEditor.scrlFog.Value = Map.FogIndex
        FrmEditor_DarkMapEditor.lblFogIndex.Text = "Fog: " & FrmEditor_DarkMapEditor.scrlFog.Value
        FrmEditor_DarkMapEditor.scrlIntensity.Value = Map.WeatherIntensity
        FrmEditor_DarkMapEditor.lblIntensity.Text = "Intensity: " & FrmEditor_DarkMapEditor.scrlIntensity.Value

        ' render the tiles
        EditorMap_DrawTileset()

        SelectedTab = 1

        'frmEditor_MapEditor.picScreen.Width = Map.MaxX * PIC_X
        'frmEditor_MapEditor.picScreen.Height = Map.MaxY * PIC_Y

        GameWindow.SetView(New SFML.Graphics.View(New SFML.Graphics.FloatRect(0, 0, FrmEditor_DarkMapEditor.picScreen.Width, FrmEditor_DarkMapEditor.picScreen.Height)))

        FrmEditor_DarkMapEditor.tslCurMap.Text = "Map: " & Map.MapNum
        FrmEditor_DarkMapEditor.lblMap.Text = "Map: " & Map.MapNum

        ' show the form
        FrmEditor_DarkMapEditor.Visible = True

        GameStarted = True

        FrmEditor_DarkMapEditor.picScreen.Focus()

        InitMapEditor = False
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
        FrmEditor_DarkMapEditor.scrlPictureY.Maximum = (FrmEditor_DarkMapEditor.picBackSelect.Height \ PIC_Y) \ 2 ' \2 is new, lets test
        FrmEditor_DarkMapEditor.scrlPictureX.Maximum = (FrmEditor_DarkMapEditor.picBackSelect.Width \ PIC_X) \ 2

        'set map names
        FrmEditor_DarkMapEditor.cmbMapList.Items.Clear()

        For i = 1 To MAX_MAPS
            FrmEditor_DarkMapEditor.cmbMapList.Items.Add(i & ": " & MapNames(i))
        Next

        If Map.MapNum > 0 Then
            FrmEditor_DarkMapEditor.cmbMapList.SelectedIndex = Map.MapNum - 1
        Else
            FrmEditor_DarkMapEditor.cmbMapList.SelectedIndex = 0
        End If

        ' set shops for the shop attribute
        FrmEditor_DarkMapEditor.cmbShop.Items.Add("None")
        For i = 1 To MAX_SHOPS
            FrmEditor_DarkMapEditor.cmbShop.Items.Add(i & ": " & Shop(i).Name)
        Next
        ' we're not in a shop
        FrmEditor_DarkMapEditor.cmbShop.SelectedIndex = 0

        FrmEditor_DarkMapEditor.optBlocked.Checked = True

        FrmEditor_DarkMapEditor.cmbTileSets.Items.Clear()
        For i = 1 To NumTileSets
            FrmEditor_DarkMapEditor.cmbTileSets.Items.Add("Tileset " & i)
        Next

        FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex = 0
        FrmEditor_DarkMapEditor.cmbLayers.SelectedIndex = 0

        InitMapProperties = True

        If MapData = True Then GettingMap = False

    End Sub

    Public Sub MapEditorTileScroll()
        FrmEditor_DarkMapEditor.picBackSelect.Top = (FrmEditor_DarkMapEditor.scrlPictureY.Value * PIC_Y) * -1
        FrmEditor_DarkMapEditor.picBackSelect.Left = (FrmEditor_DarkMapEditor.scrlPictureX.Value * PIC_X) * -1
    End Sub

    Public Sub MapEditorChooseTile(ByVal Button As Integer, ByVal X As Single, ByVal Y As Single)

        If Button = MouseButtons.Left Then 'Left Mouse Button

            EditorTileWidth = 1
            EditorTileHeight = 1

            If FrmEditor_DarkMapEditor.cmbAutoTile.SelectedIndex > 0 Then
                Select Case FrmEditor_DarkMapEditor.cmbAutoTile.SelectedIndex
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
            If X > FrmEditor_DarkMapEditor.picBackSelect.Width / PIC_X Then X = FrmEditor_DarkMapEditor.picBackSelect.Width / PIC_X
            If Y < 0 Then Y = 0
            If Y > FrmEditor_DarkMapEditor.picBackSelect.Height / PIC_Y Then Y = FrmEditor_DarkMapEditor.picBackSelect.Height / PIC_Y
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

        CurLayer = FrmEditor_DarkMapEditor.cmbLayers.SelectedIndex + 1

        If Not IsInBounds() Then Exit Sub
        If Button = MouseButtons.Left Then
            If SelectedTab = 1 Then
                ' (EditorTileSelEnd.X - EditorTileSelStart.X) = 1 And (EditorTileSelEnd.Y - EditorTileSelStart.Y) = 1 Then 'single tile
                If EditorTileWidth = 1 And EditorTileHeight = 1 Then

                    MapEditorSetTile(CurX, CurY, CurLayer, False, FrmEditor_DarkMapEditor.cmbAutoTile.SelectedIndex)
                Else ' multi tile!
                    If FrmEditor_DarkMapEditor.cmbAutoTile.SelectedIndex = 0 Then
                        MapEditorSetTile(CurX, CurY, CurLayer, True)
                    Else
                        MapEditorSetTile(CurX, CurY, CurLayer, , FrmEditor_DarkMapEditor.cmbAutoTile.SelectedIndex)
                    End If
                End If
            ElseIf SelectedTab = 2 Then
                With Map.Tile(CurX, CurY)
                    ' blocked tile
                    If FrmEditor_DarkMapEditor.optBlocked.Checked = True Then .Type = TileType.Blocked
                    ' warp tile
                    If FrmEditor_DarkMapEditor.optWarp.Checked = True Then
                        .Type = TileType.Warp
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' item spawn
                    If FrmEditor_DarkMapEditor.optItem.Checked = True Then
                        .Type = TileType.Item
                        .Data1 = ItemEditorNum
                        .Data2 = ItemEditorValue
                        .Data3 = 0
                    End If
                    ' npc avoid
                    If FrmEditor_DarkMapEditor.optNpcAvoid.Checked = True Then
                        .Type = TileType.NpcAvoid
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' key
                    If FrmEditor_DarkMapEditor.optKey.Checked = True Then
                        .Type = TileType.Key
                        .Data1 = KeyEditorNum
                        .Data2 = KeyEditorTake
                        .Data3 = 0
                    End If
                    ' key open
                    If FrmEditor_DarkMapEditor.optKeyOpen.Checked = True Then
                        .Type = TileType.KeyOpen
                        .Data1 = KeyOpenEditorX
                        .Data2 = KeyOpenEditorY
                        .Data3 = 0
                    End If
                    ' resource
                    If FrmEditor_DarkMapEditor.optResource.Checked = True Then
                        .Type = TileType.Resource
                        .Data1 = ResourceEditorNum
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' door
                    If FrmEditor_DarkMapEditor.optDoor.Checked = True Then
                        .Type = TileType.Door
                        .Data1 = EditorWarpMap
                        .Data2 = EditorWarpX
                        .Data3 = EditorWarpY
                    End If
                    ' npc spawn
                    If FrmEditor_DarkMapEditor.optNpcSpawn.Checked = True Then
                        .Type = TileType.NpcSpawn
                        .Data1 = SpawnNpcNum
                        .Data2 = SpawnNpcDir
                        .Data3 = 0
                    End If
                    ' shop
                    If FrmEditor_DarkMapEditor.optShop.Checked = True Then
                        .Type = TileType.Shop
                        .Data1 = EditorShop
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' bank
                    If FrmEditor_DarkMapEditor.optBank.Checked = True Then
                        .Type = TileType.Bank
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    ' heal
                    If FrmEditor_DarkMapEditor.optHeal.Checked = True Then
                        .Type = TileType.Heal
                        .Data1 = MapEditorHealType
                        .Data2 = MapEditorHealAmount
                        .Data3 = 0
                    End If
                    ' trap
                    If FrmEditor_DarkMapEditor.optTrap.Checked = True Then
                        .Type = TileType.Trap
                        .Data1 = MapEditorHealAmount
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'Housing
                    If FrmEditor_DarkMapEditor.optHouse.Checked Then
                        .Type = TileType.House
                        .Data1 = HouseTileIndex
                        .Data2 = 0
                        .Data3 = 0
                    End If
                    'craft tile
                    If FrmEditor_DarkMapEditor.optCraft.Checked Then
                        .Type = TileType.Craft
                        .Data1 = 0
                        .Data2 = 0
                        .Data3 = 0
                    End If
                End With
            ElseIf SelectedTab = 4 Then
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
            ElseIf SelectedTab = 5 Then
                If frmEditor_Events.Visible = False Then
                    AddEvent(CurX, CurY)
                End If
            End If
        End If

        If Button = MouseButtons.Right Then
            If SelectedTab = 1 Then

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

            ElseIf SelectedTab = 2 Then
                With Map.Tile(CurX, CurY)
                    ' clear attribute
                    .Type = 0
                    .Data1 = 0
                    .Data2 = 0
                    .Data3 = 0
                End With
            ElseIf SelectedTab = 5 Then
                DeleteEvent(CurX, CurY)
            End If
        End If

    End Sub

    Public Sub MapEditorCancel()
        InMapEditor = False
        FrmEditor_DarkMapEditor.Visible = False
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
        FrmEditor_DarkMapEditor.Visible = False
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
                .Layer(CurLayer).Tileset = FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex + 1
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
                .Layer(CurLayer).Tileset = FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex + 1
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
                                .Layer(CurLayer).Tileset = FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex + 1
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

        CurLayer = FrmEditor_DarkMapEditor.cmbLayers.SelectedIndex + 1

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

        CurLayer = FrmEditor_DarkMapEditor.cmbLayers.SelectedIndex + 1

        If MsgBox("Are you sure you wish to fill this layer?", vbYesNo, "Map Editor") = vbYes Then
            If theAutotile > 0 Then
                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Layer(CurLayer).X = EditorTileX
                        Map.Tile(X, Y).Layer(CurLayer).Y = EditorTileY
                        Map.Tile(X, Y).Layer(CurLayer).Tileset = FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex + 1
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
                        Map.Tile(X, Y).Layer(CurLayer).Tileset = FrmEditor_DarkMapEditor.cmbTileSets.SelectedIndex + 1
                        CacheRenderState(X, Y, CurLayer)
                    Next
                Next
            End If
        End If
    End Sub

    Public Sub ClearAttributeDialogue()

        With FrmEditor_DarkMapEditor
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

#Region "Item Editor"
    Public Sub ItemEditorPreInit()
        Dim i As Integer

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
        Dim i As Integer

        If frmEditor_Item.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Item.lstIndex.SelectedIndex + 1

        With Item(EditorIndex)
            frmEditor_Item.txtName.Text = Trim$(.Name)
            frmEditor_Item.txtDescription.Text = Trim$(.Description)

            If .Pic > frmEditor_Item.scrlPic.Maximum Then .Pic = 0
            frmEditor_Item.scrlPic.Value = .Pic
            If .Type > ItemType.Count - 1 Then .Type = 0
            frmEditor_Item.cmbType.SelectedIndex = .Type
            frmEditor_Item.scrlAnim.Value = .Animation

            If .ItemLevel = 0 Then .ItemLevel = 1
            frmEditor_Item.scrlItemLevel.Value = .ItemLevel
            frmEditor_Item.lblItemLvl.Text = "Item Level: " & frmEditor_Item.scrlItemLevel.Value

            ' Type specific settings
            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Equipment) Then
                frmEditor_Item.fraEquipment.Visible = True
                frmEditor_Item.scrlProjectile.Value = .Data1
                frmEditor_Item.scrlDamage.Value = .Data2
                frmEditor_Item.cmbTool.SelectedIndex = .Data3

                frmEditor_Item.cmbSubType.SelectedIndex = .SubType

                If .Speed < 100 Then .Speed = 100
                If .Speed > frmEditor_Item.scrlSpeed.Maximum Then .Speed = frmEditor_Item.scrlSpeed.Maximum
                frmEditor_Item.scrlSpeed.Value = .Speed

                frmEditor_Item.scrlAddStr.Value = .Add_Stat(Stats.Strength)
                frmEditor_Item.scrlAddEnd.Value = .Add_Stat(Stats.Endurance)
                frmEditor_Item.scrlAddInt.Value = .Add_Stat(Stats.Intelligence)
                frmEditor_Item.scrlAddVit.Value = .Add_Stat(Stats.Vitality)
                frmEditor_Item.scrlAddLuck.Value = .Add_Stat(Stats.Luck)
                frmEditor_Item.scrlAddSpr.Value = .Add_Stat(Stats.Spirit)

                If .KnockBack = 1 Then
                    frmEditor_Item.chkKnockBack.Checked = True
                Else
                    frmEditor_Item.chkKnockBack.Checked = False
                End If
                frmEditor_Item.cmbKnockBackTiles.SelectedIndex = .KnockBackTiles

                If .Randomize = 1 Then
                    frmEditor_Item.chkRandomize.Checked = True
                Else
                    frmEditor_Item.chkRandomize.Checked = False
                End If

                If .RandomMin = 0 Then .RandomMin = 1
                frmEditor_Item.numMin.Value = .RandomMin

                If .RandomMax <= 1 Then .RandomMax = 2
                frmEditor_Item.numMax.Value = .RandomMax

                frmEditor_Item.scrlPaperdoll.Value = .Paperdoll

                frmEditor_Item.scrlProjectile.Value = .Projectile
                frmEditor_Item.scrlAmmo.Value = .Ammo
            Else
                frmEditor_Item.fraEquipment.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Consumable) Then
                frmEditor_Item.fraVitals.Visible = True
                frmEditor_Item.scrlVitalMod.Value = .Data1
            Else
                frmEditor_Item.fraVitals.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Skill) Then
                frmEditor_Item.fraSkill.Visible = True
                frmEditor_Item.scrlSkill.Value = .Data1
            Else
                frmEditor_Item.fraSkill.Visible = False
            End If

            If frmEditor_Item.cmbType.SelectedIndex = ItemType.Furniture Then
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

            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Pet) Then
                frmEditor_Item.fraPets.Visible = True
                frmEditor_Item.scrlPetNum.Value = .Data1
                frmEditor_Item.lblPetNum.Text = "Num: " & frmEditor_Item.scrlPetNum.Value
                frmEditor_Item.lblPetName.Text = "Name: " & Pet(frmEditor_Item.scrlPetNum.Value).Name
            Else
                frmEditor_Item.fraPets.Visible = False
            End If

            ' Basic requirements
            frmEditor_Item.scrlAccessReq.Value = .AccessReq
            frmEditor_Item.scrlLevelReq.Value = .LevelReq

            frmEditor_Item.scrlStrReq.Value = .Stat_Req(Stats.Strength)
            frmEditor_Item.scrlVitReq.Value = .Stat_Req(Stats.Vitality)
            frmEditor_Item.scrlLuckReq.Value = .Stat_Req(Stats.Luck)
            frmEditor_Item.scrlEndReq.Value = .Stat_Req(Stats.Endurance)
            frmEditor_Item.scrlIntReq.Value = .Stat_Req(Stats.Intelligence)
            frmEditor_Item.scrlSprReq.Value = .Stat_Req(Stats.Spirit)

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

            If .Stackable = 1 Then
                frmEditor_Item.chkStackable.Checked = True
            Else
                frmEditor_Item.chkStackable.Checked = False
            End If

            EditorIndex = frmEditor_Item.lstIndex.SelectedIndex + 1
        End With

        frmEditor_Item.scrlPic.Maximum = NumItems
        frmEditor_Item.scrlAnim.Maximum = MAX_ANIMATIONS

        If NumPaperdolls > 0 Then
            frmEditor_Item.scrlPaperdoll.Maximum = NumPaperdolls + 1
        End If

        frmEditor_Item.tabInfo.SelectedTab = frmEditor_Item.tabPageInfo

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
        Dim i As Integer

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
        Dim i As Integer

        If frmEditor_NPC.Visible = False Then Exit Sub
        EditorIndex = frmEditor_NPC.lstIndex.SelectedIndex + 1
        frmEditor_NPC.cmbDropSlot.SelectedIndex = 0
        If Npc(EditorIndex).AttackSay Is Nothing Then Npc(EditorIndex).AttackSay = ""
        If Npc(EditorIndex).Name Is Nothing Then Npc(EditorIndex).Name = ""

        With frmEditor_NPC
            .txtName.Text = Trim$(Npc(EditorIndex).Name)
            .txtAttackSay.Text = Trim$(Npc(EditorIndex).AttackSay)
            If Npc(EditorIndex).Sprite < 0 Or Npc(EditorIndex).Sprite > .scrlSprite.Maximum Then Npc(EditorIndex).Sprite = 0
            .scrlSprite.Value = Npc(EditorIndex).Sprite
            .txtSpawnSecs.Text = Npc(EditorIndex).SpawnSecs
            .cmbBehaviour.SelectedIndex = Npc(EditorIndex).Behaviour
            .cmbFaction.SelectedIndex = Npc(EditorIndex).Faction
            .scrlRange.Value = Npc(EditorIndex).Range
            .txtChance.Text = Npc(EditorIndex).DropChance(frmEditor_NPC.cmbDropSlot.SelectedIndex + 1)
            .scrlNum.Value = Npc(EditorIndex).DropItem(frmEditor_NPC.cmbDropSlot.SelectedIndex + 1)
            'frmEditor_NPC.lblNum.Text = "Num: " & frmEditor_NPC.scrlNum.Value
            If frmEditor_NPC.scrlNum.Value > 0 Then
                frmEditor_NPC.lblItemName.Text = "Item: " & Trim$(Item(frmEditor_NPC.scrlNum.Value).Name)
            End If
            .scrlValue.Value = Npc(EditorIndex).DropItemValue(frmEditor_NPC.cmbDropSlot.SelectedIndex + 1)
            frmEditor_NPC.lblValue.Text = "Value: " & frmEditor_NPC.scrlValue.Value

            .txtHP.Text = Npc(EditorIndex).HP
            .txtEXP.Text = Npc(EditorIndex).EXP
            .txtLevel.Text = Npc(EditorIndex).Level
            .txtDamage.Text = Npc(EditorIndex).Damage

            .scrlQuest.Value = Npc(EditorIndex).QuestNum

            .scrlStr.Value = Npc(EditorIndex).Stat(Stats.Strength)
            .scrlEnd.Value = Npc(EditorIndex).Stat(Stats.Endurance)
            .scrlInt.Value = Npc(EditorIndex).Stat(Stats.Intelligence)
            .scrlSpr.Value = Npc(EditorIndex).Stat(Stats.Spirit)
            .scrlLuck.Value = Npc(EditorIndex).Stat(Stats.Luck)
            .scrlVit.Value = Npc(EditorIndex).Stat(Stats.Vitality)

            .cmbSkill1.Items.Clear()
            .cmbSkill2.Items.Clear()
            .cmbSkill3.Items.Clear()
            .cmbSkill4.Items.Clear()
            .cmbSkill5.Items.Clear()
            .cmbSkill6.Items.Clear()

            .cmbSkill1.Items.Add("None")
            .cmbSkill2.Items.Add("None")
            .cmbSkill3.Items.Add("None")
            .cmbSkill4.Items.Add("None")
            .cmbSkill5.Items.Add("None")
            .cmbSkill6.Items.Add("None")

            For i = 1 To MAX_SKILLS
                If Len(Skill(i).Name) > 0 Then
                    .cmbSkill1.Items.Add(Skill(i).Name)
                    .cmbSkill2.Items.Add(Skill(i).Name)
                    .cmbSkill3.Items.Add(Skill(i).Name)
                    .cmbSkill4.Items.Add(Skill(i).Name)
                    .cmbSkill5.Items.Add(Skill(i).Name)
                    .cmbSkill6.Items.Add(Skill(i).Name)
                End If
            Next

            .cmbSkill1.SelectedIndex = Npc(EditorIndex).Skill(1)
            .cmbSkill2.SelectedIndex = Npc(EditorIndex).Skill(2)
            .cmbSkill3.SelectedIndex = Npc(EditorIndex).Skill(3)
            .cmbSkill4.SelectedIndex = Npc(EditorIndex).Skill(4)
            .cmbSkill5.SelectedIndex = Npc(EditorIndex).Skill(5)
            .cmbSkill6.SelectedIndex = Npc(EditorIndex).Skill(6)
        End With

        EditorNpc_DrawSprite()
        NPC_Changed(EditorIndex) = True
    End Sub

    Public Sub NpcEditorOk()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            If NPC_Changed(i) Then
                SendSaveNpc(i)
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
        frmEditor_Resource.scrlRewardItem.Value = Resource(EditorIndex).ItemReward
        frmEditor_Resource.scrlRewardExp.Value = Resource(EditorIndex).ExpReward
        frmEditor_Resource.cmbTool.SelectedIndex = Resource(EditorIndex).ToolRequired
        frmEditor_Resource.scrlHealth.Value = Resource(EditorIndex).Health
        frmEditor_Resource.scrlRespawn.Value = Resource(EditorIndex).RespawnTime
        frmEditor_Resource.scrlAnimation.Value = Resource(EditorIndex).Animation
        frmEditor_Resource.scrlLvlReq.Value = Resource(EditorIndex).LvlRequired

        frmEditor_Resource.Visible = True

        EditorResource_DrawSprite()

        Resource_Changed(EditorIndex) = True
    End Sub

    Public Sub ResourceEditorOk()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES
            If Resource_Changed(i) Then
                SendSaveResource(i)
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

#Region "Skill Editor"
    Public Sub SkillEditorInit()
        Dim i As Integer

        If frmEditor_Skill.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Skill.lstIndex.SelectedIndex + 1

        If Skill(EditorIndex).Name Is Nothing Then Skill(EditorIndex).Name = ""

        With frmEditor_Skill
            ' set max values
            .scrlAnimCast.Maximum = MAX_ANIMATIONS
            .scrlAnim.Maximum = MAX_ANIMATIONS
            .scrlAOE.Maximum = Byte.MaxValue
            .scrlRange.Maximum = Byte.MaxValue
            .scrlMap.Maximum = MAX_MAPS
            .scrlProjectile.Maximum = MAX_PROJECTILES

            ' build class combo
            .cmbClass.Items.Clear()
            .cmbClass.Items.Add("None")
            For i = 1 To Max_Classes
                .cmbClass.Items.Add(Trim$(Classes(i).Name))
            Next
            .cmbClass.SelectedIndex = 0

            ' set values
            .txtName.Text = Trim$(Skill(EditorIndex).Name)
            .cmbType.SelectedIndex = Skill(EditorIndex).Type
            .scrlMP.Value = Skill(EditorIndex).MPCost
            .scrlLevel.Value = Skill(EditorIndex).LevelReq
            .scrlAccess.Value = Skill(EditorIndex).AccessReq
            .cmbClass.SelectedIndex = Skill(EditorIndex).ClassReq
            .scrlCast.Value = Skill(EditorIndex).CastTime
            .scrlCool.Value = Skill(EditorIndex).CDTime
            .scrlIcon.Value = Skill(EditorIndex).Icon
            .scrlMap.Value = Skill(EditorIndex).Map
            .scrlX.Value = Skill(EditorIndex).X
            .scrlY.Value = Skill(EditorIndex).Y
            .scrlDir.Value = Skill(EditorIndex).Dir
            .scrlVital.Value = Skill(EditorIndex).Vital
            .scrlDuration.Value = Skill(EditorIndex).Duration
            .scrlInterval.Value = Skill(EditorIndex).Interval
            .scrlRange.Value = Skill(EditorIndex).Range
            If Skill(EditorIndex).IsAoE = True Then
                .chkAOE.Checked = True
            Else
                .chkAOE.Checked = False
            End If
            .scrlAOE.Value = Skill(EditorIndex).AoE
            .scrlAnimCast.Value = Skill(EditorIndex).CastAnim
            .scrlAnim.Value = Skill(EditorIndex).SkillAnim
            .scrlStun.Value = Skill(EditorIndex).StunDuration

            If Skill(EditorIndex).IsProjectile = 1 Then
                .chkProjectile.Checked = True
            Else
                .chkProjectile.Checked = False
            End If
            .scrlProjectile.Value = Skill(EditorIndex).Projectile

            If Skill(EditorIndex).KnockBack = 1 Then
                .chkKnockBack.Checked = True
            Else
                .chkKnockBack.Checked = False
            End If
            .cmbKnockBackTiles.SelectedIndex = Skill(EditorIndex).KnockBackTiles
        End With

        EditorSkill_BltIcon()

        Skill_Changed(EditorIndex) = True
    End Sub

    Public Sub SkillEditorOk()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            If Skill_Changed(i) Then
                SendSaveSkill(i)
            End If
        Next

        frmEditor_Skill.Visible = False
        Editor = 0
        ClearChanged_Skill()
    End Sub

    Public Sub SkillEditorCancel()
        Editor = 0
        frmEditor_Skill.Visible = False
        ClearChanged_Skill()
        ClearSkills()
        SendRequestSkills()
    End Sub

    Public Sub ClearChanged_Skill()
        For i = 1 To MAX_SKILLS
            Skill_Changed(i) = False
        Next
    End Sub
#End Region

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

#Region "Class Editor"

    Public Sub ClassesEditorOk()
        SendSaveClasses()

        frmEditor_Classes.Visible = False
        Editor = 0
    End Sub

    Public Sub ClassesEditorCancel()
        SendRequestClasses()
        frmEditor_Classes.Visible = False
        Editor = 0
    End Sub

    Public Sub ClassEditorInit()
        Dim i As Integer

        frmEditor_Classes.lstIndex.Items.Clear()

        For i = 1 To Max_Classes
            frmEditor_Classes.lstIndex.Items.Add(Trim(Classes(i).Name))
        Next

        Editor = EDITOR_CLASSES

        frmEditor_Classes.scrlMaleSprite.Maximum = NumCharacters
        frmEditor_Classes.scrlFemaleSprite.Maximum = NumCharacters

        frmEditor_Classes.cmbItems.Items.Clear()

        frmEditor_Classes.cmbItems.Items.Add("None")
        For i = 1 To MAX_ITEMS
            frmEditor_Classes.cmbItems.Items.Add(Trim(Item(i).Name))
        Next

        frmEditor_Classes.lstIndex.SelectedIndex = 0

        frmEditor_Classes.Visible = True
    End Sub

    Public Sub LoadClass()
        Dim i As Integer

        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        frmEditor_Classes.txtName.Text = Classes(EditorIndex).Name
        frmEditor_Classes.txtDescription.Text = Classes(EditorIndex).Desc

        frmEditor_Classes.cmbMaleSprite.Items.Clear()

        For i = 0 To UBound(Classes(EditorIndex).MaleSprite)
            frmEditor_Classes.cmbMaleSprite.Items.Add("Sprite " & i + 1)
        Next

        frmEditor_Classes.cmbFemaleSprite.Items.Clear()

        For i = 0 To UBound(Classes(EditorIndex).FemaleSprite)
            frmEditor_Classes.cmbFemaleSprite.Items.Add("Sprite " & i + 1)
        Next

        frmEditor_Classes.scrlMaleSprite.Value = Classes(EditorIndex).MaleSprite(0)
        frmEditor_Classes.scrlFemaleSprite.Value = Classes(EditorIndex).FemaleSprite(0)

        frmEditor_Classes.cmbMaleSprite.SelectedIndex = 0
        frmEditor_Classes.cmbFemaleSprite.SelectedIndex = 0

        frmEditor_Classes.DrawPreview()

        For i = 1 To Stats.Count - 1
            If Classes(EditorIndex).Stat(i) = 0 Then Classes(EditorIndex).Stat(i) = 1
        Next

        frmEditor_Classes.numStrength.Value = Classes(EditorIndex).Stat(Stats.Strength)
        frmEditor_Classes.numLuck.Value = Classes(EditorIndex).Stat(Stats.Luck)
        frmEditor_Classes.numEndurance.Value = Classes(EditorIndex).Stat(Stats.Endurance)
        frmEditor_Classes.numIntelligence.Value = Classes(EditorIndex).Stat(Stats.Intelligence)
        frmEditor_Classes.numVitality.Value = Classes(EditorIndex).Stat(Stats.Vitality)
        frmEditor_Classes.numSpirit.Value = Classes(EditorIndex).Stat(Stats.Spirit)

        If Classes(EditorIndex).BaseExp < 10 Then
            frmEditor_Classes.numBaseExp.Value = 10
        Else
            frmEditor_Classes.numBaseExp.Value = Classes(EditorIndex).BaseExp
        End If

        frmEditor_Classes.lstStartItems.Items.Clear()

        For i = 1 To 5
            If Classes(EditorIndex).StartItem(i) > 0 Then
                frmEditor_Classes.lstStartItems.Items.Add(Item(Classes(EditorIndex).StartItem(i)).Name & " X " & Classes(EditorIndex).StartValue(i))
            Else
                frmEditor_Classes.lstStartItems.Items.Add("None")
            End If
        Next

        frmEditor_Classes.numStartMap.Value = Classes(EditorIndex).StartMap
        frmEditor_Classes.numStartX.Value = Classes(EditorIndex).StartX
        frmEditor_Classes.numStartY.Value = Classes(EditorIndex).StartY
    End Sub

#End Region

End Module