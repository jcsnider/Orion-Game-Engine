Imports SFML.Graphics
Imports System.Drawing
Imports System.Windows.Forms
Imports SFML.Window

Module EditorGraphics
    Public GameWindow As RenderWindow

    Public EditorItem_Furniture As RenderWindow

    Public EditorSkill_Icon As RenderWindow

    Public EditorAnimation_Anim1 As RenderWindow
    Public EditorAnimation_Anim2 As RenderWindow

    Public TmpItemWindow As RenderWindow

    Public TmpBankItem As RenderWindow

    Public TmpSkillWindow As RenderWindow

    Public SFMLGameFont As SFML.Graphics.Font

    Public TileSetImgsGFX() As Bitmap
    Public TileSetImgsLoaded() As Boolean
    Public TileSetTexture() As Texture
    Public TileSetTextureInfo() As GraphicInfo
    Public CharacterGFX() As Texture
    Public CharacterGFXInfo() As GraphicInfo
    Public PaperDollGFX() As Texture
    Public PaperDollGFXInfo() As GraphicInfo
    Public ItemsGFX() As Texture
    Public ItemsGFXInfo() As GraphicInfo
    Public ResourcesGFX() As Texture
    Public ResourcesGFXInfo() As GraphicInfo
    Public AnimationsGFX() As Texture
    Public AnimationsGFXInfo() As GraphicInfo
    Public SkillIconsGFX() As Texture
    Public SkillIconsGFXInfo() As GraphicInfo
    'Housing
    Public FurnitureGFX() As Texture
    Public FurnitureGFXInfo() As GraphicInfo
    'Faces
    Public FacesGFX() As Texture
    Public FacesGFXInfo() As GraphicInfo

    Public DoorGFX As Texture
    Public DoorGFXInfo As GraphicInfo
    Public DirectionsGfx As Texture
    Public DirectionsGFXInfo As GraphicInfo
    Public MiscGFX As Texture
    Public MiscGFXInfo As GraphicInfo
    Public WeatherGFX As Texture
    Public WeatherGFXInfo As GraphicInfo

    Public FogGFX() As Texture
    Public FogGFXInfo() As GraphicInfo

    ' Number of graphic files
    Public MapEditorBackBuffer As Bitmap

    Public NumTileSets As Integer
    Public NumCharacters As Integer
    Public NumPaperdolls As Integer
    Public NumItems As Integer
    Public NumResources As Integer
    Public NumAnimations As Integer
    Public NumSkillIcons As Integer
    Public NumFaces As Integer
    Public NumFogs As Integer

    Public Structure GraphicInfo
        Dim width As Integer
        Dim height As Integer
        Dim IsLoaded As Boolean
        Dim TextureTimer As Integer
    End Structure

    Public Structure Graphics_Tiles
        Dim Tile(,) As Texture
    End Structure

    Sub InitGraphics()

        GameWindow = New RenderWindow(frmEditor_MapEditor.picscreen.Handle)
        GameWindow.SetFramerateLimit(FPS_LIMIT)

        EditorItem_Furniture = New RenderWindow(frmEditor_Item.picFurniture.Handle)

        EditorSkill_Icon = New RenderWindow(frmEditor_Skill.picSprite.Handle)

        EditorAnimation_Anim1 = New RenderWindow(frmEditor_Animation.picSprite0.Handle)
        EditorAnimation_Anim2 = New RenderWindow(frmEditor_Animation.picSprite1.Handle)

        SFMLGameFont = New SFML.Graphics.Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + FONT_NAME)

        'this stuff only loads when needed :)

        ReDim TileSetImgsGFX(0 To NumTileSets)
        ReDim TileSetTexture(0 To NumTileSets)
        ReDim TileSetTextureInfo(0 To NumTileSets)

        ReDim CharacterGFX(0 To NumCharacters)
        ReDim CharacterGFXInfo(0 To NumCharacters)

        ReDim PaperDollGFX(0 To NumPaperdolls)
        ReDim PaperDollGFXInfo(0 To NumPaperdolls)

        ReDim ItemsGFX(0 To NumItems)
        ReDim ItemsGFXInfo(0 To NumItems)

        ReDim ResourcesGFX(0 To NumResources)
        ReDim ResourcesGFXInfo(0 To NumResources)

        ReDim AnimationsGFX(0 To NumAnimations)
        ReDim AnimationsGFXInfo(0 To NumAnimations)

        ReDim FogGFX(0 To NumFogs)
        ReDim FogGFXInfo(0 To NumFogs)

        ReDim SkillIconsGFX(0 To NumSkillIcons)
        ReDim SkillIconsGFXInfo(0 To NumSkillIcons)

        ReDim FacesGFX(0 To NumFaces)
        ReDim FacesGFXInfo(0 To NumFaces)

        ReDim FurnitureGFX(0 To NumFurniture)
        ReDim FurnitureGFXInfo(0 To NumFurniture)

        'sadly, gui shit is always needed, so we preload it :/
        DoorGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "door" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            DoorGFX = New Texture(Application.StartupPath & GFX_PATH & "door" & GFX_EXT)

            'Cache the width and height
            DoorGFXInfo.width = DoorGFX.Size.X
            DoorGFXInfo.height = DoorGFX.Size.Y
        End If

        DirectionsGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "direction" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            DirectionsGfx = New Texture(Application.StartupPath & GFX_PATH & "direction" & GFX_EXT)

            'Cache the width and height
            DirectionsGFXInfo.width = DirectionsGfx.Size.X
            DirectionsGFXInfo.height = DirectionsGfx.Size.Y
        End If

        MiscGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "misc" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            MiscGFX = New Texture(Application.StartupPath & GFX_PATH & "misc" & GFX_EXT)

            'Cache the width and height
            MiscGFXInfo.width = MiscGFX.Size.X
            MiscGFXInfo.height = MiscGFX.Size.Y
        End If

        WeatherGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "weather" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            WeatherGFX = New Texture(Application.StartupPath & GFX_PATH & "weather" & GFX_EXT)

            'Cache the width and height
            WeatherGFXInfo.width = WeatherGFX.Size.X
            WeatherGFXInfo.height = WeatherGFX.Size.Y
        End If

    End Sub

    Public Sub LoadTexture(ByVal Index As Integer, ByVal TexType As Byte)

        If TexType = 1 Then 'tilesets
            If Index < 0 Or Index > NumTileSets Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            TileSetTexture(Index) = New Texture(Application.StartupPath & GFX_PATH & "tilesets\" & Index & GFX_EXT)

            'Cache the width and height
            With TileSetTextureInfo(Index)
                .width = TileSetTexture(Index).Size.X
                .height = TileSetTexture(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 2 Then 'characters
            If Index < 0 Or Index > NumCharacters Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            CharacterGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "characters\" & Index & GFX_EXT)

            'Cache the width and height
            With CharacterGFXInfo(Index)
                .width = CharacterGFX(Index).Size.X
                .height = CharacterGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 3 Then 'paperdoll
            If Index < 0 Or Index > NumPaperdolls Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            PaperDollGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Paperdolls\" & Index & GFX_EXT)

            'Cache the width and height
            With PaperDollGFXInfo(Index)
                .width = PaperDollGFX(Index).Size.X
                .height = PaperDollGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 4 Then 'items
            If Index <= 0 Or Index > NumItems Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ItemsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "items\" & Index & GFX_EXT)

            'Cache the width and height
            With ItemsGFXInfo(Index)
                .width = ItemsGFX(Index).Size.X
                .height = ItemsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 5 Then 'resources
            If Index < 0 Or Index > NumResources Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ResourcesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "resources\" & Index & GFX_EXT)

            'Cache the width and height
            With ResourcesGFXInfo(Index)
                .width = ResourcesGFX(Index).Size.X
                .height = ResourcesGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 6 Then 'animations
            If Index <= 0 Or Index > NumAnimations Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            AnimationsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Animations\" & Index & GFX_EXT)

            'Cache the width and height
            With AnimationsGFXInfo(Index)
                .width = AnimationsGFX(Index).Size.X
                .height = AnimationsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 7 Then 'faces
            If Index < 0 Or Index > NumFaces Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FacesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Faces\" & Index & GFX_EXT)

            'Cache the width and height
            With FacesGFXInfo(Index)
                .width = FacesGFX(Index).Size.X
                .height = FacesGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 8 Then 'fogs
            If Index < 0 Or Index > NumFogs Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FogGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Fogs\" & Index & GFX_EXT)

            'Cache the width and height
            With FogGFXInfo(Index)
                .width = FogGFX(Index).Size.X
                .height = FogGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 9 Then 'skill icons
            If Index <= 0 Or Index > NumSkillIcons Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            SkillIconsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "SkillIcons\" & Index & GFX_EXT)

            'Cache the width and height
            With SkillIconsGFXInfo(Index)
                .width = SkillIconsGFX(Index).Size.X
                .height = SkillIconsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        ElseIf TexType = 10 Then 'furniture
            If Index < 0 Or Index > NumFurniture Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FurnitureGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Furniture\" & Index & GFX_EXT)

            'Cache the width and height
            With FurnitureGFXInfo(Index)
                .width = FurnitureGFX(Index).Size.X
                .height = FurnitureGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        End If

    End Sub

    Public Sub RenderTexture(ByVal Txture As Texture, ByVal Target As RenderWindow, ByVal DestX As Integer, ByVal DestY As Integer, ByVal SourceX As Integer, ByVal SourceY As Integer,
           ByVal SourceWidth As Integer, ByVal SourceHeight As Integer)
        Dim TmpImage As Sprite = New Sprite(Txture)
        TmpImage.TextureRect = New IntRect(SourceX, SourceY, SourceWidth, SourceHeight)
        TmpImage.Position = New Vector2f(DestX, DestY)
        Target.Draw(TmpImage)

    End Sub

    Public Sub DrawDirections(ByVal X As Integer, ByVal Y As Integer)
        Dim rec As Rectangle, i As Integer

        ' render grid
        rec.Y = 24
        rec.X = 0
        rec.Width = 32
        rec.Height = 32

        RenderTexture(DirectionsGfx, GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)

        ' render dir blobs
        For i = 1 To 4
            rec.X = (i - 1) * 8
            rec.Width = 8
            ' find out whether render blocked or not
            If Not isDirBlocked(Map.Tile(X, Y).DirBlock, (i)) Then
                rec.Y = 8
            Else
                rec.Y = 16
            End If
            rec.Height = 8

            RenderTexture(DirectionsGfx, GameWindow, ConvertMapX(X * PIC_X) + DirArrowX(i), ConvertMapY(Y * PIC_Y) + DirArrowY(i), rec.X, rec.Y, rec.Width, rec.Height)
        Next
    End Sub

    ' BitWise Operators for directional blocking
    Public Sub setDirBlock(ByRef blockvar As Byte, ByRef Dir As Byte, ByVal block As Boolean)
        If block Then
            blockvar = blockvar Or (2 ^ Dir)
        Else
            blockvar = blockvar And Not (2 ^ Dir)
        End If
    End Sub

    Public Function isDirBlocked(ByRef blockvar As Byte, ByRef Dir As Byte) As Boolean
        If Not blockvar And (2 ^ Dir) Then
            isDirBlocked = False
        Else
            isDirBlocked = True
        End If
    End Function

    Public Function ConvertMapX(ByVal X As Integer) As Integer
        ConvertMapX = X - (TileView.left * PIC_X) - Camera.Left
    End Function

    Public Function ConvertMapY(ByVal Y As Integer) As Integer
        ConvertMapY = Y - (TileView.top * PIC_Y) - Camera.Top
    End Function

    Public Sub DrawNpc(ByVal MapNpcNum As Integer)
        Dim anim As Byte
        Dim X As Integer
        Dim Y As Integer
        Dim Sprite As Integer, spriteleft As Integer
        Dim destrec As Rectangle
        Dim srcrec As Rectangle
        Dim attackspeed As Integer

        If MapNpc(MapNpcNum).Num = 0 Then Exit Sub ' no npc set

        If MapNpc(MapNpcNum).X < TileView.left Or MapNpc(MapNpcNum).X > TileView.right Then Exit Sub
        If MapNpc(MapNpcNum).Y < TileView.top Or MapNpc(MapNpcNum).Y > TileView.bottom Then Exit Sub

        Sprite = Npc(MapNpc(MapNpcNum).Num).Sprite

        If Sprite < 1 Or Sprite > NumCharacters Then Exit Sub

        attackspeed = 1000

        ' Reset frame
        anim = 0

        ' Check for attacking animation
        If MapNpc(MapNpcNum).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If MapNpc(MapNpcNum).Attacking = 1 Then
                anim = 3
            End If
        Else
            ' If not attacking, walk normally
            Select Case MapNpc(MapNpcNum).Dir
                Case Direction.Up
                    If (MapNpc(MapNpcNum).YOffset > 8) Then anim = MapNpc(MapNpcNum).Steps
                Case Direction.Down
                    If (MapNpc(MapNpcNum).YOffset < -8) Then anim = MapNpc(MapNpcNum).Steps
                Case Direction.Left
                    If (MapNpc(MapNpcNum).XOffset > 8) Then anim = MapNpc(MapNpcNum).Steps
                Case Direction.Right
                    If (MapNpc(MapNpcNum).XOffset < -8) Then anim = MapNpc(MapNpcNum).Steps
            End Select
        End If

        ' Check to see if we want to stop making him attack
        With MapNpc(MapNpcNum)
            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If
        End With

        ' Set the left
        Select Case MapNpc(MapNpcNum).Dir
            Case Direction.Up
                spriteleft = 3
            Case Direction.Right
                spriteleft = 2
            Case Direction.Down
                spriteleft = 0
            Case Direction.Left
                spriteleft = 1
        End Select


        srcrec = New Rectangle((anim) * (CharacterGFXInfo(Sprite).width / 4), spriteleft * (CharacterGFXInfo(Sprite).height / 4), (CharacterGFXInfo(Sprite).width / 4), (CharacterGFXInfo(Sprite).height / 4))

        ' Calculate the X
        X = MapNpc(MapNpcNum).X * PIC_X + MapNpc(MapNpcNum).XOffset - ((CharacterGFXInfo(Sprite).width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (CharacterGFXInfo(Sprite).height / 4) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            Y = MapNpc(MapNpcNum).Y * PIC_Y + MapNpc(MapNpcNum).YOffset - ((CharacterGFXInfo(Sprite).height / 4) - 32)
        Else
            ' Proceed as normal
            Y = MapNpc(MapNpcNum).Y * PIC_Y + MapNpc(MapNpcNum).YOffset
        End If

        destrec = New Rectangle(X, Y, CharacterGFXInfo(Sprite).width / 4, CharacterGFXInfo(Sprite).height / 4)

        DrawCharacter(Sprite, X, Y, srcrec)

    End Sub

    Public Sub DrawResource(ByVal Resource As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal rec As Rectangle)
        If Resource < 1 Or Resource > NumResources Then Exit Sub
        Dim X As Integer
        Dim Y As Integer
        Dim width As Integer
        Dim height As Integer

        X = ConvertMapX(dx)
        Y = ConvertMapY(dy)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        If rec.Width < 0 Or rec.Height < 0 Then Exit Sub

        If ResourcesGFXInfo(Resource).IsLoaded = False Then
            LoadTexture(Resource, 5)
        End If

        'seeying we still use it, lets update timer
        With ResourcesGFXInfo(Resource)
            .TextureTimer = GetTickCount() + 100000
        End With

        RenderTexture(ResourcesGFX(Resource), GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub DrawMapResource(ByVal Resource_num As Integer)
        Dim Resource_master As Integer

        Dim Resource_state As Integer
        Dim Resource_sprite As Integer
        Dim rec As Rectangle
        Dim X As Integer, Y As Integer

        If GettingMap Then Exit Sub
        If MapData = False Then Exit Sub

        If MapResource(Resource_num).X > Map.MaxX Or MapResource(Resource_num).Y > Map.MaxY Then Exit Sub
        ' Get the Resource type
        Resource_master = Map.Tile(MapResource(Resource_num).X, MapResource(Resource_num).Y).Data1

        If Resource_master = 0 Then Exit Sub

        If Resource(Resource_master).ResourceImage = 0 Then Exit Sub

        ' Get the Resource state
        Resource_state = MapResource(Resource_num).ResourceState

        If Resource_state = 0 Then ' normal
            Resource_sprite = Resource(Resource_master).ResourceImage
        ElseIf Resource_state = 1 Then ' used
            Resource_sprite = Resource(Resource_master).ExhaustedImage
        End If

        ' src rect
        With rec
            .Y = 0
            .Height = ResourcesGFXInfo(Resource_sprite).height
            .X = 0
            .Width = ResourcesGFXInfo(Resource_sprite).width
        End With

        ' Set base x + y, then the offset due to size
        X = (MapResource(Resource_num).X * PIC_X) - (ResourcesGFXInfo(Resource_sprite).width / 2) + 16
        Y = (MapResource(Resource_num).Y * PIC_Y) - ResourcesGFXInfo(Resource_sprite).height + 32

        DrawResource(Resource_sprite, X, Y, rec)
    End Sub

    Public Sub DrawItem(ByVal itemnum As Integer)

        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim PicNum As Integer
        Dim x As Integer, y As Integer
        PicNum = Item(MapItem(itemnum).Num).Pic

        If PicNum < 1 Or PicNum > NumItems Then Exit Sub

        If ItemsGFXInfo(PicNum).IsLoaded = False Then
            LoadTexture(PicNum, 4)
        End If

        'seeying we still use it, lets update timer
        With ItemsGFXInfo(PicNum)
            .TextureTimer = GetTickCount() + 100000
        End With

        With MapItem(itemnum)
            If .X < TileView.left Or .X > TileView.right Then Exit Sub
            If .Y < TileView.top Or .Y > TileView.bottom Then Exit Sub
        End With

        If ItemsGFXInfo(PicNum).width > 32 Then ' has more than 1 frame
            srcrec = New Rectangle((MapItem(itemnum).Frame * 32), 0, 32, 32)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PIC_X), ConvertMapY(MapItem(itemnum).Y * PIC_Y), 32, 32)
        Else
            srcrec = New Rectangle(0, 0, PIC_X, PIC_Y)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PIC_X), ConvertMapY(MapItem(itemnum).Y * PIC_Y), PIC_X, PIC_Y)
        End If

        x = ConvertMapX(MapItem(itemnum).X * PIC_X)
        y = ConvertMapY(MapItem(itemnum).Y * PIC_Y)

        RenderTexture(ItemsGFX(PicNum), GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)
    End Sub

    Public Sub DrawCharacter(ByVal Sprite As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal rec As Rectangle)
        Dim X As Integer
        Dim y As Integer
        Dim width As Integer
        Dim height As Integer
        On Error Resume Next

        If Sprite < 1 Or Sprite > NumCharacters Then Exit Sub

        If CharacterGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 2)
        End If

        'seeying we still use it, lets update timer
        With CharacterGFXInfo(Sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        X = ConvertMapX(x2)
        y = ConvertMapY(y2)
        width = (rec.Width)
        height = (rec.Height)

        RenderTexture(CharacterGFX(Sprite), GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub DrawMapTile(ByVal X As Integer, ByVal Y As Integer)
        Dim i As Integer
        Dim srcrect As New Rectangle(0, 0, 0, 0)

        If GettingMap Then Exit Sub

        With Map.Tile(X, Y)
            For i = MapLayer.Ground To MapLayer.Mask2
                ' skip tile if tileset isn't set
                If .Layer(i).Tileset > 0 And .Layer(i).Tileset <= NumTileSets Then
                    If TileSetTextureInfo(.Layer(i).Tileset).IsLoaded = False Then
                        LoadTexture(.Layer(i).Tileset, 1)
                    End If
                    ' we use it, lets update timer
                    With TileSetTextureInfo(i)
                        .TextureTimer = GetTickCount() + 100000
                    End With
                    If Autotile(X, Y).Layer(i).renderState = RENDER_STATE_NORMAL Then
                        With srcrect
                            .X = Map.Tile(X, Y).Layer(i).X * 32
                            .Y = Map.Tile(X, Y).Layer(i).Y * 32
                            .Width = 32
                            .Height = 32
                        End With

                        RenderTexture(TileSetTexture(.Layer(i).Tileset), GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)

                    ElseIf Autotile(X, Y).Layer(i).renderState = RENDER_STATE_AUTOTILE Then
                        ' Draw autotiles
                        DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), 1, X, Y, 0, False)
                        DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y), 2, X, Y, 0, False)
                        DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y) + 16, 3, X, Y, 0, False)
                        DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y) + 16, 4, X, Y, 0, False)
                    End If
                End If
            Next
        End With

    End Sub

    Public Sub DrawMapFringeTile(ByVal X As Integer, ByVal Y As Integer)
        Dim i As Integer
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim dest As Rectangle = New Rectangle(frmEditor_MapEditor.PointToScreen(frmEditor_MapEditor.picScreen.Location), New Size(32, 32))
        'Dim tmpSprite As Sprite

        If GettingMap Then Exit Sub

        With Map.Tile(X, Y)
            For i = MapLayer.Fringe To MapLayer.Fringe2
                ' skip tile if tileset isn't set
                If .Layer(i).Tileset > 0 And .Layer(i).Tileset <= NumTileSets Then
                    If TileSetTextureInfo(.Layer(i).Tileset).IsLoaded = False Then
                        LoadTexture(.Layer(i).Tileset, 1)
                    End If

                    ' we use it, lets update timer
                    With TileSetTextureInfo(i)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    ' render
                    If Autotile(X, Y).Layer(i).renderState = RENDER_STATE_NORMAL Then
                        With srcrect
                            .X = Map.Tile(X, Y).Layer(i).X * 32
                            .Y = Map.Tile(X, Y).Layer(i).Y * 32
                            .Width = 32
                            .Height = 32
                        End With

                        RenderTexture(TileSetTexture(.Layer(i).Tileset), GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)

                    ElseIf Autotile(X, Y).Layer(i).renderState = RENDER_STATE_AUTOTILE Then
                        ' Draw autotiles
                        DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), 1, X, Y, 0, False)
                        DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y), 2, X, Y, 0, False)
                        DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y) + 16, 3, X, Y, 0, False)
                        DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y) + 16, 4, X, Y, 0, False)
                    End If
                End If
            Next
        End With

    End Sub

    Public Function IsValidMapPoint(ByVal X As Integer, ByVal Y As Integer) As Boolean
        IsValidMapPoint = False

        If X < 0 Then Exit Function
        If Y < 0 Then Exit Function
        If X > Map.MaxX Then Exit Function
        If Y > Map.MaxY Then Exit Function
        IsValidMapPoint = True
    End Function

    Public Sub UpdateCamera()
        Dim offsetX As Integer, offsetY As Integer
        Dim StartX As Integer, StartY As Integer
        Dim EndX As Integer, EndY As Integer

        'offsetX = Player(MyIndex).XOffset + PIC_X
        'offsetY = Player(MyIndex).YOffset + PIC_Y
        'StartX = GetPlayerX(MyIndex) - ((SCREEN_MAPX + 1) \ 2) - 1
        'StartY = GetPlayerY(MyIndex) - ((SCREEN_MAPY + 1) \ 2) - 1

        If StartX < 0 Then
            offsetX = 0

            'If StartX = -1 Then
            '    If Player(MyIndex).XOffset > 0 Then
            '        offsetX = Player(MyIndex).XOffset
            '    End If
            'End If

            StartX = 0
        End If

        If StartY < 0 Then
            offsetY = 0

            If StartY = -1 Then
                'If Player(MyIndex).YOffset > 0 Then
                '    offsetY = Player(MyIndex).YOffset
                'End If
            End If

            StartY = 0
        End If

        EndX = StartX + (SCREEN_MAPX + 1) + 1
        EndY = StartY + (SCREEN_MAPY + 1) + 1

        If EndX > Map.MaxX Then
            offsetX = 32

            If EndX = Map.MaxX + 1 Then
                'If Player(MyIndex).XOffset < 0 Then
                '    offsetX = Player(MyIndex).XOffset + PIC_X
                'End If
            End If

            EndX = Map.MaxX
            StartX = EndX - SCREEN_MAPX - 1
        End If

        If EndY > Map.MaxY Then
            offsetY = 32

            If EndY = Map.MaxY + 1 Then
                'If Player(MyIndex).YOffset < 0 Then
                '    offsetY = Player(MyIndex).YOffset + PIC_Y
                'End If
            End If

            EndY = Map.MaxY
            StartY = EndY - SCREEN_MAPY - 1
        End If

        With TileView
            .top = StartY
            .bottom = EndY
            .left = StartX
            .right = EndX
        End With

        With Camera
            .Y = offsetY
            .Height = ScreenY + 32
            .X = offsetX
            .Width = ScreenX + 32
        End With


        UpdateDrawMapName()

    End Sub

    Sub ClearGFX()

        'clear tilesets
        For I = 1 To NumTileSets
            If TileSetTextureInfo(I).IsLoaded Then
                If TileSetTextureInfo(I).TextureTimer < GetTickCount() Then
                    TileSetTexture(I).Dispose()
                    TileSetTextureInfo(I).IsLoaded = False
                    TileSetTextureInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear characters
        For I = 1 To NumCharacters
            If CharacterGFXInfo(I).IsLoaded Then
                If CharacterGFXInfo(I).TextureTimer < GetTickCount() Then
                    CharacterGFX(I).Dispose()
                    CharacterGFXInfo(I).IsLoaded = False
                    CharacterGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear paperdoll
        For I = 1 To NumPaperdolls
            If PaperDollGFXInfo(I).IsLoaded Then
                If PaperDollGFXInfo(I).TextureTimer < GetTickCount() Then
                    PaperDollGFX(I).Dispose()
                    PaperDollGFXInfo(I).IsLoaded = False
                    PaperDollGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear items
        For I = 1 To NumItems
            If ItemsGFXInfo(I).IsLoaded Then
                If ItemsGFXInfo(I).TextureTimer < GetTickCount() Then
                    ItemsGFX(I).Dispose()
                    ItemsGFXInfo(I).IsLoaded = False
                    ItemsGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear resources
        For I = 1 To NumResources
            If ResourcesGFXInfo(I).IsLoaded Then
                If ResourcesGFXInfo(I).TextureTimer < GetTickCount() Then
                    ResourcesGFX(I).Dispose()
                    ResourcesGFXInfo(I).IsLoaded = False
                    ResourcesGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear faces
        For I = 1 To NumFaces
            If FacesGFXInfo(I).IsLoaded Then
                If FacesGFXInfo(I).TextureTimer < GetTickCount() Then
                    FacesGFX(I).Dispose()
                    FacesGFXInfo(I).IsLoaded = False
                    FacesGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next
    End Sub

    Public Sub Render_Graphics()
        Dim X As Integer, Y As Integer, I As Integer

        'Don't Render IF
        'If GettingMap Then Exit Sub

        'lets get going

        'update view around player
        UpdateCamera()

        'let program do other things
        DoEvents()

        'Clear each of our render targets
        GameWindow.DispatchEvents()
        GameWindow.Clear(SFML.Graphics.Color.Black)

        'clear any unused gfx
        ClearGFX()

        ' update animation editor
        If Editor = EDITOR_ANIMATION Then
            EditorAnim_DrawAnim()
        End If

        If InMapEditor And MapData = True Then
            ' blit lower tiles
            If NumTileSets > 0 Then
                For X = TileView.left To TileView.right + 1
                    For Y = TileView.top To TileView.bottom + 1
                        If IsValidMapPoint(X, Y) Then
                            DrawMapTile(X, Y)
                        End If
                    Next
                Next
            End If

            ' events
            If Map.CurrentEvents > 0 And Map.CurrentEvents <= Map.EventCount Then

                For I = 1 To Map.CurrentEvents
                    If Map.MapEvents(I).Position = 0 Then
                        DrawEvent(I)
                    End If
                Next
            End If

            ' Draw out the items
            If NumItems > 0 Then
                For I = 1 To MAX_MAP_ITEMS

                    If MapItem(I).Num > 0 Then
                        DrawItem(I)
                    End If

                Next
            End If

            'Draw sum d00rs.
            For X = TileView.left To TileView.right
                For Y = TileView.top To TileView.bottom

                    If IsValidMapPoint(X, Y) Then
                        If Map.Tile(X, Y).Type = TileType.Door Then
                            DrawDoor(X, Y)
                        End If
                    End If

                Next
            Next

            ' Y-based render. Renders Players, Npcs and Resources based on Y-axis.
            For Y = 0 To Map.MaxY

                If NumCharacters > 0 Then

                    ' Npcs
                    For I = 1 To MAX_MAP_NPCS
                        If MapNpc(I).Y = Y Then
                            DrawNpc(I)
                        End If
                    Next

                    ' events
                    If Map.CurrentEvents > 0 And Map.CurrentEvents <= Map.EventCount Then

                        For I = 1 To Map.CurrentEvents
                            If Map.MapEvents(I).Position = 1 Then
                                If Y = Map.MapEvents(I).Y Then
                                    DrawEvent(I)
                                End If
                            End If
                        Next
                    End If

                End If

                ' Resources
                If NumResources > 0 Then
                    If Resources_Init Then
                        If Resource_Index > 0 Then
                            For I = 1 To Resource_Index
                                If MapResource(I).Y = Y Then
                                    DrawMapResource(I)
                                End If
                            Next
                        End If
                    End If
                End If
            Next

            'events
            If Map.CurrentEvents > 0 And Map.CurrentEvents <= Map.EventCount Then

                For I = 1 To Map.CurrentEvents
                    If Map.MapEvents(I).Position = 2 Then
                        DrawEvent(I)
                    End If
                Next
            End If

            ' blit out upper tiles
            If NumTileSets > 0 Then
                For X = TileView.left To TileView.right + 1
                    For Y = TileView.top To TileView.bottom + 1
                        If IsValidMapPoint(X, Y) Then
                            DrawMapFringeTile(X, Y)
                        End If
                    Next
                Next
            End If

            DrawWeather()
            DrawThunderEffect()
            DrawMapTint()

            ' Draw out a square at mouse cursor
            If MapGrid = True Then
                DrawGrid()
            End If

            If frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpDirBlock Then
                For X = TileView.left To TileView.right
                    For Y = TileView.top To TileView.bottom
                        If IsValidMapPoint(X, Y) Then
                            DrawDirections(X, Y)
                        End If
                    Next
                Next
            End If

            DrawTileOutline()

            'draw event names
            For I = 0 To Map.CurrentEvents
                If Map.MapEvents(I).Visible = 1 Then
                    If Map.MapEvents(I).ShowName = 1 Then
                        DrawEventName(I)
                    End If
                End If
            Next

            ' draw npc names
            For I = 1 To MAX_MAP_NPCS
                If MapNpc(I).Num > 0 Then
                    DrawNPCName(I)
                End If
            Next

            If CurrentFog > 0 Then
                DrawFog()
            End If

            ' Blit out map attributes
            If InMapEditor Then
                DrawMapAttributes()
            End If

            If InMapEditor And frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpEvents Then
                DrawEvents()
                EditorEvent_DrawGraphic()
            End If

            ' Draw map name
            DrawMapName()
        End If

        'and finally show everything on screen
        GameWindow.Display()
    End Sub

    Sub DrawMapName()
        DrawText(DrawMapNameX, DrawMapNameY, Map.Name, DrawMapNameColor, SFML.Graphics.Color.Black, GameWindow)
    End Sub

    Public Sub DrawDoor(ByVal X As Integer, ByVal Y As Integer)
        Dim rec As Rectangle

        Dim x2 As Integer, y2 As Integer

        ' sort out animation
        With TempTile(X, Y)
            If .DoorAnimate = 1 Then ' opening
                If .DoorTimer + 100 < GetTickCount() Then
                    If .DoorFrame < 4 Then
                        .DoorFrame = .DoorFrame + 1
                    Else
                        .DoorAnimate = 2 ' set to closing
                    End If
                    .DoorTimer = GetTickCount()
                End If
            ElseIf .DoorAnimate = 2 Then ' closing
                If .DoorTimer + 100 < GetTickCount() Then
                    If .DoorFrame > 1 Then
                        .DoorFrame = .DoorFrame - 1
                    Else
                        .DoorAnimate = 0 ' end animation
                    End If
                    .DoorTimer = GetTickCount()
                End If
            End If

            If .DoorFrame = 0 Then .DoorFrame = 1
        End With

        With rec
            .Y = 0
            .Height = DoorGFXInfo.height
            .X = ((TempTile(X, Y).DoorFrame - 1) * DoorGFXInfo.width / 4)
            .Width = DoorGFXInfo.width / 4
        End With

        x2 = (X * PIC_X)
        y2 = (Y * PIC_Y) - (DoorGFXInfo.height / 2) + 4

        RenderTexture(DoorGFX, GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub DrawTileOutline()
        Dim rec As Rectangle
        If frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpDirBlock Then Exit Sub

        With rec
            .Y = 0
            .Height = PIC_Y
            .X = 0
            .Width = PIC_X
        End With

        Dim rec2 As New RectangleShape
        rec2.OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue)
        rec2.OutlineThickness = 0.6
        rec2.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)

        If frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpAttributes Then
            'RenderTexture(MiscGFX, GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
            rec2.Size = New Vector2f(rec.Width, rec.Height)
        Else
            If EditorTileWidth = 1 And EditorTileHeight = 1 Then
                RenderTexture(TileSetTexture(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, rec.Width, rec.Height)
                rec2.Size = New Vector2f(rec.Width, rec.Height)
            Else
                If frmEditor_MapEditor.cmbAutoTile.SelectedIndex > 0 Then
                    RenderTexture(TileSetTexture(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, rec.Width, rec.Height)
                    rec2.Size = New Vector2f(rec.Width, rec.Height)
                Else
                    RenderTexture(TileSetTexture(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, EditorTileSelEnd.X * PIC_X, EditorTileSelEnd.Y * PIC_Y)
                    rec2.Size = New Vector2f(EditorTileSelEnd.X * PIC_X, EditorTileSelEnd.Y * PIC_Y)
                End If

            End If

        End If

        rec2.Position = New Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
        GameWindow.Draw(rec2)
    End Sub

    Public Sub DrawGrid()

        Dim rec As New RectangleShape

        For x = TileView.left To TileView.right ' - 1

            For y = TileView.top To TileView.bottom ' - 1

                If IsValidMapPoint(x, y) Then

                    rec.OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.White)
                    rec.OutlineThickness = 0.6
                    rec.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
                    rec.Size = New Vector2f((x * PIC_X), (y * PIC_X))
                    rec.Position = New Vector2f(ConvertMapX((x - 1) * PIC_X), ConvertMapY((y - 1) * PIC_Y))

                    GameWindow.Draw(rec)
                End If

            Next

        Next

    End Sub

    Public Sub DrawMapTint()
        'If InMapEditor Then Exit Sub

        If Map.HasMapTint = 0 Then Exit Sub

        Dim tmpSprite As Sprite
        tmpSprite = New Sprite(MiscGFX)
        tmpSprite.Color = New SFML.Graphics.Color(CurrentTintR, CurrentTintG, CurrentTintB, CurrentTintA)
        tmpSprite.TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y)

        tmpSprite.Position = New Vector2f(0, 0)

        GameWindow.Draw(tmpSprite) '

        tmpSprite.Dispose()
    End Sub

    Public Sub EditorMap_DrawTileset()
        Dim height As Integer
        Dim width As Integer
        Dim tileset As Byte

        ' find tileset number
        tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1

        ' exit out if doesn't exist
        If tileset <= 0 Or tileset > NumTileSets Then Exit Sub

        If tileset <> LastTileset Then
            If Not TileSetImgsGFX(LastTileset) Is Nothing Then TileSetImgsGFX(LastTileset).Dispose()
            TileSetImgsGFX(LastTileset) = Nothing
            TileSetImgsLoaded(LastTileset) = False
        End If

        'check if its loaded
        If TileSetImgsLoaded(tileset) = False Then
            TileSetImgsGFX(tileset) = New Bitmap(Application.StartupPath & GFX_PATH & "tilesets\" & tileset & GFX_EXT)
            TileSetImgsLoaded(tileset) = True
        End If

        'Draw the tileset into memory.
        height = TileSetImgsGFX(tileset).Height
        width = TileSetImgsGFX(tileset).Width
        MapEditorBackBuffer = New Bitmap(width, height)

        Dim g As Graphics = Graphics.FromImage(MapEditorBackBuffer)
        g.FillRectangle(Brushes.Black, New Rectangle(0, 0, MapEditorBackBuffer.Width, MapEditorBackBuffer.Height))

        frmEditor_MapEditor.picBackSelect.Height = height
        frmEditor_MapEditor.picBackSelect.Width = width

        ' change selected shape for autotiles
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

        g.DrawImage(TileSetImgsGFX(tileset), New Rectangle(0, 0, TileSetImgsGFX(tileset).Width, TileSetImgsGFX(tileset).Height))
        g.DrawRectangle(Pens.Red, New Rectangle(EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, EditorTileWidth * PIC_X, EditorTileHeight * PIC_X))
        g.Dispose()

        g = frmEditor_MapEditor.picBackSelect.CreateGraphics
        g.DrawImage(MapEditorBackBuffer, New Rectangle(0, 0, width, height))
        g.Dispose()

        LastTileset = tileset
    End Sub

    Sub DestroyGraphics()

        ' Number of graphic files
        If Not MapEditorBackBuffer Is Nothing Then MapEditorBackBuffer.Dispose()

        For i = 0 To NumAnimations
            If Not AnimationsGFX(i) Is Nothing Then AnimationsGFX(i).Dispose()
        Next i

        For i = 0 To NumCharacters
            If Not CharacterGFX(i) Is Nothing Then CharacterGFX(i).Dispose()
        Next

        For i = 0 To NumItems
            If Not ItemsGFX(i) Is Nothing Then ItemsGFX(i).Dispose()
        Next

        For i = 0 To NumPaperdolls
            If Not PaperDollGFX(i) Is Nothing Then PaperDollGFX(i).Dispose()
        Next

        For i = 0 To NumResources
            If Not ResourcesGFX(i) Is Nothing Then ResourcesGFX(i).Dispose()
        Next

        For i = 0 To NumSkillIcons
            If Not SkillIconsGFX(i) Is Nothing Then SkillIconsGFX(i).Dispose()
        Next

        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
            If Not TileSetTexture(i) Is Nothing Then TileSetTexture(i).Dispose()
        Next i

        For i = 0 To NumFurniture
            If Not FurnitureGFX(i) Is Nothing Then FurnitureGFX(i).Dispose()
        Next

        For i = 0 To NumFaces
            If Not FacesGFX(i) Is Nothing Then FacesGFX(i).Dispose()
        Next

        For i = 0 To NumFogs
            If Not FogGFX(i) Is Nothing Then FogGFX(i).Dispose()
        Next

        If Not DoorGFX Is Nothing Then DoorGFX.Dispose()
        If Not DirectionsGfx Is Nothing Then DirectionsGfx.Dispose()
        If Not MiscGFX Is Nothing Then MiscGFX.Dispose()
        If Not WeatherGFX Is Nothing Then WeatherGFX.Dispose()

    End Sub

    Public Sub EditorMap_DrawMapItem()
        Dim itemnum As Integer
        itemnum = Item(frmEditor_MapEditor.scrlMapItem.Value).Pic

        If itemnum < 1 Or itemnum > NumItems Then
            frmEditor_MapEditor.picMapItem.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT) Then
            frmEditor_MapEditor.picMapItem.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT)
        End If

    End Sub

    Public Sub EditorMap_DrawKey()
        Dim itemnum As Integer

        itemnum = Item(frmEditor_MapEditor.scrlMapKey.Value).Pic

        If itemnum < 1 Or itemnum > NumItems Then
            frmEditor_MapEditor.picMapKey.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT) Then
            frmEditor_MapEditor.picMapKey.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT)
        End If

    End Sub

    Public Sub EditorItem_DrawItem()
        Dim itemnum As Integer
        itemnum = frmEditor_Item.scrlPic.Value

        If itemnum < 1 Or itemnum > NumItems Then
            frmEditor_Item.picItem.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT) Then
            frmEditor_Item.picItem.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT)
        End If

    End Sub

    Public Sub EditorItem_DrawPaperdoll()
        Dim Sprite As Integer

        Sprite = frmEditor_Item.scrlPaperdoll.Value

        If Sprite < 1 Or Sprite > NumPaperdolls Then
            frmEditor_Item.picPaperdoll.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "paperdolls\" & Sprite & GFX_EXT) Then
            frmEditor_Item.picPaperdoll.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "paperdolls\" & Sprite & GFX_EXT)
        End If
    End Sub

    Public Sub EditorItem_DrawFurniture()
        Dim Furniturenum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Furniturenum = frmEditor_Item.scrlFurniture.Value

        If Furniturenum < 1 Or Furniturenum > NumFurniture Then
            EditorItem_Furniture.Clear(ToSFMLColor(frmEditor_Item.picFurniture.BackColor))
            EditorItem_Furniture.Display()
            Exit Sub
        End If

        If FurnitureGFXInfo(Furniturenum).IsLoaded = False Then
            LoadTexture(Furniturenum, 10)
        End If

        'seeying we still use it, lets update timer
        With FurnitureGFXInfo(Furniturenum)
            .TextureTimer = GetTickCount() + 100000
        End With

        ' rect for source
        With sRECT
            .Y = 0
            .Height = FurnitureGFXInfo(Furniturenum).height
            .X = 0
            .Width = FurnitureGFXInfo(Furniturenum).width
        End With

        ' same for destination as source
        dRECT = sRECT

        EditorItem_Furniture.Clear(ToSFMLColor(frmEditor_Item.picFurniture.BackColor))

        RenderTexture(FurnitureGFX(Furniturenum), EditorItem_Furniture, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)

        If frmEditor_Item.optSetBlocks.Checked = True Then
            For X = 0 To 3
                For Y = 0 To 3
                    If X <= (FurnitureGFXInfo(Furniturenum).width / 32) - 1 Then
                        If Y <= (FurnitureGFXInfo(Furniturenum).height / 32) - 1 Then
                            If Item(EditorIndex).FurnitureBlocks(X, Y) = 1 Then
                                DrawText(X * 32 + 8, Y * 32 + 8, "X", SFML.Graphics.Color.Red, SFML.Graphics.Color.Black, EditorItem_Furniture)
                            Else
                                DrawText(X * 32 + 8, Y * 32 + 8, "O", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, EditorItem_Furniture)
                            End If
                        End If
                    End If
                Next
            Next
        ElseIf frmEditor_Item.optSetFringe.Checked = True Then
            For X = 0 To 3
                For Y = 0 To 3
                    If X <= Item(EditorIndex).FurnitureWidth - 1 Then
                        If Y <= Item(EditorIndex).FurnitureHeight Then
                            If Item(EditorIndex).FurnitureFringe(X, Y) = 1 Then
                                DrawText(X * 32 + 8, Y * 32 + 8, "O", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, EditorItem_Furniture)
                            End If
                        End If
                    End If
                Next
            Next
        End If
        EditorItem_Furniture.Display()
    End Sub

    Public Sub EditorNpc_DrawSprite()
        Dim Sprite As Integer

        Sprite = frmEditor_NPC.scrlSprite.Value

        If Sprite < 1 Or Sprite > NumCharacters Then
            frmEditor_NPC.picSprite.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "characters\" & Sprite & GFX_EXT) Then
            frmEditor_NPC.picSprite.Width = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "characters\" & Sprite & GFX_EXT).Width / 4
            frmEditor_NPC.picSprite.Height = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "characters\" & Sprite & GFX_EXT).Height / 4
            frmEditor_NPC.picSprite.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "characters\" & Sprite & GFX_EXT)
        End If
    End Sub

    Public Sub EditorResource_DrawSprite()
        Dim Sprite As Integer

        ' normal sprite
        Sprite = frmEditor_Resource.scrlNormalPic.Value

        If Sprite < 1 Or Sprite > NumResources Then
            frmEditor_Resource.picNormalpic.BackgroundImage = Nothing
        Else
            If FileExist(Application.StartupPath & GFX_PATH & "resources\" & Sprite & GFX_EXT) Then
                frmEditor_Resource.picNormalpic.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "resources\" & Sprite & GFX_EXT)
            End If
        End If

        ' exhausted sprite
        Sprite = frmEditor_Resource.scrlExhaustedPic.Value

        If Sprite < 1 Or Sprite > NumResources Then
            frmEditor_Resource.picExhaustedPic.BackgroundImage = Nothing
        Else
            If FileExist(Application.StartupPath & GFX_PATH & "resources\" & Sprite & GFX_EXT) Then
                frmEditor_Resource.picExhaustedPic.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "resources\" & Sprite & GFX_EXT)
            End If
        End If
    End Sub

    Public Sub EditorSkill_BltIcon()
        Dim iconnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        iconnum = frmEditor_Skill.scrlIcon.Value

        If iconnum < 1 Or iconnum > NumSkillIcons Then
            EditorSkill_Icon.Clear(ToSFMLColor(frmEditor_Skill.picSprite.BackColor))
            EditorSkill_Icon.Display()
            Exit Sub
        End If

        If SkillIconsGFXInfo(iconnum).IsLoaded = False Then
            LoadTexture(iconnum, 9)
        End If

        'seeying we still use it, lets update timer
        With SkillIconsGFXInfo(iconnum)
            .TextureTimer = GetTickCount() + 100000
        End With

        With sRECT
            .Y = 0
            .Height = PIC_Y
            .X = 0
            .Width = PIC_X
        End With

        'drect is the same, so just copy it
        dRECT = sRECT

        EditorSkill_Icon.Clear(ToSFMLColor(frmEditor_Skill.picSprite.BackColor))

        RenderTexture(SkillIconsGFX(iconnum), EditorSkill_Icon, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)

        EditorSkill_Icon.Display()
    End Sub

    Public Sub EditorAnim_DrawAnim()
        Dim Animationnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Dim width As Integer, height As Integer
        Dim looptime As Integer
        Dim FrameCount As Integer
        Dim ShouldRender As Boolean

        Animationnum = frmEditor_Animation.scrlSprite0.Value

        If AnimationsGFXInfo(Animationnum).IsLoaded = False Then
            LoadTexture(Animationnum, 6)
        End If

        'seeying we still use it, lets update timer
        With AnimationsGFXInfo(Animationnum)
            .TextureTimer = GetTickCount() + 100000
        End With

        If Animationnum < 1 Or Animationnum > NumAnimations Then
            EditorAnimation_Anim1.Clear(ToSFMLColor(frmEditor_Animation.picSprite0.BackColor))
            EditorAnimation_Anim1.Display()
        Else

            looptime = frmEditor_Animation.scrlLoopTime0.Value
            FrameCount = frmEditor_Animation.scrlFrameCount0.Value

            ShouldRender = False

            ' check if we need to render new frame
            If AnimEditorTimer(0) + looptime <= GetTickCount() Then
                ' check if out of range
                If AnimEditorFrame(0) >= FrameCount Then
                    AnimEditorFrame(0) = 1
                Else
                    AnimEditorFrame(0) = AnimEditorFrame(0) + 1
                End If
                AnimEditorTimer(0) = GetTickCount()
                ShouldRender = True
            End If

            If ShouldRender Then
                If frmEditor_Animation.scrlFrameCount0.Value > 0 Then
                    ' total width divided by frame count
                    height = AnimationsGFXInfo(Animationnum).height
                    width = AnimationsGFXInfo(Animationnum).width / frmEditor_Animation.scrlFrameCount0.Value

                    With sRECT
                        .Y = 0
                        .Height = height
                        .X = (AnimEditorFrame(0) - 1) * width
                        .Width = width
                    End With

                    With dRECT
                        .Y = 0
                        .Height = height
                        .X = 0
                        .Width = width
                    End With

                    EditorAnimation_Anim1.Clear(ToSFMLColor(frmEditor_Animation.picSprite0.BackColor))

                    RenderTexture(AnimationsGFX(Animationnum), EditorAnimation_Anim1, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)

                    EditorAnimation_Anim1.Display()
                End If
            End If
        End If


        Animationnum = frmEditor_Animation.scrlSprite1.Value

        If Animationnum < 1 Or Animationnum > NumAnimations Then
            EditorAnimation_Anim2.Clear(ToSFMLColor(frmEditor_Animation.picSprite1.BackColor))
            EditorAnimation_Anim2.Display()
        Else
            looptime = frmEditor_Animation.scrlLoopTime1.Value
            FrameCount = frmEditor_Animation.scrlFrameCount1.Value

            ShouldRender = False

            ' check if we need to render new frame
            If AnimEditorTimer(1) + looptime <= GetTickCount() Then
                ' check if out of range
                If AnimEditorFrame(1) >= FrameCount Then
                    AnimEditorFrame(1) = 1
                Else
                    AnimEditorFrame(1) = AnimEditorFrame(1) + 1
                End If
                AnimEditorTimer(1) = GetTickCount()
                ShouldRender = True
            End If

            If ShouldRender Then
                If frmEditor_Animation.scrlFrameCount1.Value > 0 Then
                    ' total width divided by frame count
                    height = AnimationsGFXInfo(Animationnum).height
                    width = AnimationsGFXInfo(Animationnum).width / frmEditor_Animation.scrlFrameCount1.Value

                    With sRECT
                        .Y = 0
                        .Height = height
                        .X = (AnimEditorFrame(1) - 1) * width
                        .Width = width
                    End With

                    With dRECT
                        .Y = 0
                        .Height = height
                        .X = 0
                        .Width = width
                    End With

                    EditorAnimation_Anim2.Clear(ToSFMLColor(frmEditor_Animation.picSprite1.BackColor))

                    RenderTexture(AnimationsGFX(Animationnum), EditorAnimation_Anim2, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    EditorAnimation_Anim2.Display()

                End If
            End If
        End If
    End Sub

    Public Sub UpdateDrawMapName()
        Dim g As Graphics = Graphics.FromImage(New Bitmap(1, 1))
        Dim width As Integer
        width = g.MeasureString(Trim$(Map.Name), New Drawing.Font(FONT_NAME, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width
        DrawMapNameX = ((SCREEN_MAPX + 1) * PIC_X / 2) - width + 32
        DrawMapNameY = 1

        Select Case Map.Moral
            Case MapMoral.None
                DrawMapNameColor = SFML.Graphics.Color.Red
            Case MapMoral.Safe
                DrawMapNameColor = SFML.Graphics.Color.Green
            Case Else
                DrawMapNameColor = SFML.Graphics.Color.White
        End Select
        g.Dispose()
    End Sub

    Public Function ToSFMLColor(ToConvert As Drawing.Color) As SFML.Graphics.Color
        Return New SFML.Graphics.Color(ToConvert.R, ToConvert.G, ToConvert.G, ToConvert.A)
    End Function

End Module

