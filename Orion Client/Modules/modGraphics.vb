Imports System.Drawing.Imaging
Imports SFML.Graphics
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Module modGraphics
    Public GameWindow As RenderWindow
    Public EditorMap_Item As RenderWindow
    Public EditorMap_Key As RenderWindow

    Public EditorItem_Item As RenderWindow
    Public EditorItem_Paperdoll As RenderWindow

    Public EditorNPC_Sprite As RenderWindow

    Public EditorResource_Resource As RenderWindow
    Public EditorResource_ExResource As RenderWindow

    Public EditorSpell_Icon As RenderWindow

    Public EditorAnimation_Anim1 As RenderWindow
    Public EditorAnimation_Anim2 As RenderWindow

    Public EquipmentWindow As RenderWindow

    Public TmpItemWindow As RenderWindow

    Public InventoryWindow As RenderWindow

    Public ShopWindow As RenderWindow

    Public BankWindow As RenderWindow
    Public TmpBankItem As RenderWindow

    Public YourTradeWindow As RenderWindow
    Public TheirTradeWindow As RenderWindow

    Public SpellsWindow As RenderWindow

    Public SFMLGameFont As SFML.Graphics.Font

    Public TileSetImgsGFX() As Bitmap
    Public TileSetTexture() As Texture
    Public TileSetTextureInfo() As GraphicInfo
    Public SpritesGFX() As Texture
    Public SpritesGFXInfo() As GraphicInfo
    Public PaperDollGFX() As Texture
    Public PaperDollGFXInfo() As GraphicInfo
    Public ItemsGFX() As Texture
    Public ItemsGFXInfo() As GraphicInfo
    Public ResourcesGFX() As Texture
    Public ResourcesGFXInfo() As GraphicInfo
    Public AnimationsGFX() As Texture
    Public AnimationsGFXInfo() As GraphicInfo
    Public SpellIconsGFX() As Texture
    Public SpellIconsGFXInfo() As GraphicInfo

    Public DoorGFX As Texture
    Public DoorGFXInfo As GraphicInfo
    Public BloodGFX As Texture
    Public BloodGFXInfo As GraphicInfo
    Public Directions As Texture
    Public DirectionsGFXInfo As GraphicInfo
    Public MiscGFX As Texture
    Public MiscGFXInfo As GraphicInfo

    Public TextBB As Bitmap





    ' Number of graphic files
    Public StatBarBackbuffer As Bitmap
    Public MapEditorBackBuffer As Bitmap

    Public NumTileSets As Long
    Public NumCharacters As Long
    Public NumPaperdolls As Long
    Public NumItems As Long
    Public NumResources As Long
    Public NumAnimations As Long
    Public NumSpellIcons As Long

    Public TempBitmap As Bitmap
    Public TempBitmap1 As Bitmap


    Public HPBar As Bitmap
    Public ManaBar As Bitmap
    Public EXPBar As Bitmap
    Public EmptyHPBar As Bitmap
    Public EmptyManaBar As Bitmap
    Public EmptyEXPBar As Bitmap
    Dim bmp_stream As IO.MemoryStream
    Public Structure GraphicInfo
        Dim width As Long
        Dim height As Long
    End Structure
    Public Structure Graphics_Tiles
        Dim Tile(,) As Texture
    End Structure

    Sub InitGraphics()

        GameWindow = New RenderWindow(frmMainGame.picscreen.Handle)
        GameWindow.SetFramerateLimit(FPS_LIMIT)

        EditorMap_Item = New RenderWindow(frmEditor_Map.picMapItem.Handle)
        EditorMap_Key = New RenderWindow(frmEditor_Map.picMapKey.Handle)

        EditorItem_Item = New RenderWindow(frmEditor_Item.picItem.Handle)
        EditorItem_Paperdoll = New RenderWindow(frmEditor_Item.picPaperdoll.Handle)

        EditorNPC_Sprite = New RenderWindow(frmEditor_NPC.picSprite.Handle)

        EditorResource_Resource = New RenderWindow(frmEditor_Resource.picNormalpic.Handle)
        EditorResource_ExResource = New RenderWindow(frmEditor_Resource.picExhaustedPic.Handle)

        EditorSpell_Icon = New RenderWindow(frmEditor_Spell.picSprite.Handle)

        EditorAnimation_Anim1 = New RenderWindow(frmEditor_Animation.picSprite0.Handle)
        EditorAnimation_Anim2 = New RenderWindow(frmEditor_Animation.picSprite1.Handle)

        EquipmentWindow = New RenderWindow(frmMainGame.pnlCharacter.Handle)

        TmpItemWindow = New RenderWindow(frmMainGame.pnlTmpInv.Handle)

        InventoryWindow = New RenderWindow(frmMainGame.pnlInventory.Handle)

        ShopWindow = New RenderWindow(frmMainGame.pnlShopItems.Handle)

        BankWindow = New RenderWindow(frmMainGame.pnlBank.Handle)
        frmMainGame.pnlBank.Hide()
        TmpBankItem = New RenderWindow(frmMainGame.pnlTempBank.Handle)

        YourTradeWindow = New RenderWindow(frmMainGame.pnlYourTrade.Handle)
        TheirTradeWindow = New RenderWindow(frmMainGame.pnlTheirTrade.Handle)

        SpellsWindow = New RenderWindow(frmMainGame.pnlSpells.Handle)

        SFMLGameFont = New SFML.Graphics.Font(FONT_NAME)

        Dim transcolor As System.Drawing.Color
        Dim ms As MemoryStream
        ReDim TileSetImgsGFX(0 To NumTileSets)
        ReDim TileSetTexture(0 To NumTileSets)
        ReDim TileSetTextureInfo(0 To NumTileSets)
        StatBarBackbuffer = New Bitmap(frmMainGame.picGeneral.Width, frmMainGame.picGeneral.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
        For i = 1 To NumTileSets
            TileSetImgsGFX(i) = New Bitmap(Application.StartupPath & GFX_PATH & "tilesets\" & i & GFX_EXT)
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "tilesets\" & i & GFX_EXT)
            TileSetTextureInfo(i).width = TempBitmap.Width
            TileSetTextureInfo(i).height = TempBitmap.Height
            transcolor = (TempBitmap.GetPixel(0, 0))

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            TileSetTexture(i) = New Texture(ms)
            ms.Dispose()
        Next


        ReDim SpritesGFX(0 To NumCharacters)
        ReDim SpritesGFXInfo(0 To NumCharacters)
        For i = 1 To NumCharacters
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "characters\" & i & GFX_EXT)
            transcolor = TempBitmap.GetPixel(0, 0)
            SpritesGFXInfo(i).width = TempBitmap.Width
            SpritesGFXInfo(i).height = TempBitmap.Height

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            SpritesGFX(i) = New Texture(ms)
            ms.Dispose()
        Next

        ReDim PaperDollGFX(0 To NumPaperdolls)
        ReDim PaperDollGFXInfo(0 To NumPaperdolls)
        For i = 1 To NumPaperdolls
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "Paperdolls\" & i & GFX_EXT)
            PaperDollGFXInfo(i).width = TempBitmap.Width
            PaperDollGFXInfo(i).height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            PaperDollGFX(i) = New Texture(ms)
            ms.Dispose()
        Next

        ReDim ItemsGFX(0 To NumItems)
        ReDim ItemsGFXInfo(0 To NumItems)
        For i = 1 To NumItems
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "items\" & i & GFX_EXT)
            ItemsGFXInfo(i).width = TempBitmap.Width
            ItemsGFXInfo(i).height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            ItemsGFX(i) = New Texture(ms)
            ms.Dispose()
        Next

        ReDim ResourcesGFX(0 To NumResources)
        ReDim ResourcesGFXInfo(0 To NumResources)
        For i = 1 To NumResources
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "resources\" & i & GFX_EXT)
            ResourcesGFXInfo(i).width = TempBitmap.Width
            ResourcesGFXInfo(i).height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            ResourcesGFX(i) = New Texture(ms)
            ms.Dispose()
        Next

        ReDim AnimationsGFX(0 To NumAnimations)
        ReDim AnimationsGFXInfo(0 To NumAnimations)
        For i = 1 To NumAnimations
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "animations\" & i & GFX_EXT)
            AnimationsGFXInfo(i).width = TempBitmap.Width
            AnimationsGFXInfo(i).height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            AnimationsGFX(i) = New Texture(ms)
            ms.Dispose()
        Next

        ReDim SpellIconsGFX(0 To NumSpellIcons)
        ReDim SpellIconsGFXInfo(0 To NumSpellIcons)
        For i = 1 To NumSpellIcons
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "spellicons\" & i & GFX_EXT)
            SpellIconsGFXInfo(i).width = TempBitmap.Width
            SpellIconsGFXInfo(i).height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            SpellIconsGFX(i) = New Texture(ms)
            ms.Dispose()
        Next

        DoorGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "door" & GFX_EXT) Then
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "door" & GFX_EXT)
            DoorGFXInfo.width = TempBitmap.Width
            DoorGFXInfo.height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            DoorGFX = New Texture(ms)
            ms.Dispose()
        End If

        BloodGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "blood" & GFX_EXT) Then
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "blood" & GFX_EXT)
            BloodGFXInfo.width = TempBitmap.Width
            BloodGFXInfo.height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            BloodGFX = New Texture(ms)
            ms.Dispose()
        End If

        DirectionsGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "direction" & GFX_EXT) Then
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "direction" & GFX_EXT)
            DirectionsGFXInfo.width = TempBitmap.Width
            DirectionsGFXInfo.height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Directions = New Texture(ms)
            ms.Dispose()
        End If

        MiscGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "misc" & GFX_EXT) Then
            TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "misc" & GFX_EXT)
            MiscGFXInfo.width = TempBitmap.Width
            MiscGFXInfo.height = TempBitmap.Height
            transcolor = TempBitmap.GetPixel(0, 0)

            ms = New MemoryStream()
            TempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            MiscGFX = New Texture(ms)
            ms.Dispose()
        End If



        HPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\HPBar" & GFX_EXT)
        ManaBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\manaBar" & GFX_EXT)
        EXPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\expBar" & GFX_EXT)
        EmptyHPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\HPBarEmpty" & GFX_EXT)
        EmptyManaBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\ManaBarEmpty" & GFX_EXT)
        EmptyEXPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\ExpBarEmpty" & GFX_EXT)


    End Sub

    Public Sub DrawDirections(ByVal X As Long, ByVal Y As Long)
        Dim rec As Rectangle
        Dim i As Long
        Dim tmpSprite As Sprite = New Sprite(Directions)

        ' render grid
        rec.Y = 24
        rec.X = 0
        rec.Width = 32
        rec.Height = 32

        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y))
        GameWindow.Draw(tmpSprite)
        ' render dir blobs
        For i = 1 To 4
            rec.X = (i - 1) * 8
            rec.Width = 8
            ' find out whether render blocked or not
            If Not isDirBlocked(Map.Tile(X, Y).DirBlock, CByte(i)) Then
                rec.Y = 8
            Else
                rec.Y = 16
            End If
            rec.Height = 8
            'render!
            tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
            tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X) + DirArrowX(i), ConvertMapY(Y * PIC_Y) + DirArrowY(i))
            GameWindow.Draw(tmpSprite)
        Next
    End Sub
    Public Function ConvertMapX(ByVal X As Long) As Long
        ConvertMapX = X - (TileView.left * PIC_X) - Camera.Left
    End Function
    Public Function ConvertMapY(ByVal Y As Long) As Long
        ConvertMapY = Y - (TileView.top * PIC_Y) - Camera.Top
    End Function
    Public Sub DrawPlayer(ByVal Index As Long)
        Dim anim As Byte
        Dim X As Long
        Dim Y As Long
        Dim Spritenum As Long, spriteleft As Long
        Dim attackspeed As Long
        Dim srcrec As Rectangle
        Spritenum = GetPlayerSprite(Index)

        If Spritenum < 1 Or Spritenum > NumCharacters Then Exit Sub

        ' speed from weapon
        If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
            attackspeed = Item(GetPlayerEquipment(Index, Equipment.Weapon)).Speed
        Else
            attackspeed = 1000
        End If

        ' Reset frame
        anim = 0

        ' Check for attacking animation
        If Player(Index).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If Player(Index).Attacking = 1 Then
                anim = 3
            End If
        Else
            ' If not attacking, walk normally
            Select Case GetPlayerDir(Index)
                Case DIR_UP

                    If (Player(Index).YOffset > 8) Then anim = Player(Index).Steps
                Case DIR_DOWN

                    If (Player(Index).YOffset < -8) Then anim = Player(Index).Steps
                Case DIR_LEFT

                    If (Player(Index).XOffset > 8) Then anim = Player(Index).Steps
                Case DIR_RIGHT

                    If (Player(Index).XOffset < -8) Then anim = Player(Index).Steps
            End Select

        End If

        ' Check to see if we want to stop making him attack
        With Player(Index)

            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If

        End With

        ' Set the left
        Select Case GetPlayerDir(Index)
            Case DIR_UP
                spriteleft = 3
            Case DIR_RIGHT
                spriteleft = 2
            Case DIR_DOWN
                spriteleft = 0
            Case DIR_LEFT
                spriteleft = 1
        End Select

        srcrec = New Rectangle((anim) * (SpritesGFXInfo(Spritenum).width / 4), spriteleft * (SpritesGFXInfo(Spritenum).height / 4), (SpritesGFXInfo(Spritenum).width / 4), (SpritesGFXInfo(Spritenum).height / 4))

        ' Calculate the X
        X = GetPlayerX(Index) * PIC_X + Player(Index).XOffset - ((SpritesGFXInfo(Spritenum).width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (SpritesGFXInfo(Spritenum).height) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            Y = GetPlayerY(Index) * PIC_Y + Player(Index).YOffset - ((SpritesGFXInfo(Spritenum).height / 4) - 32)
        Else
            ' Proceed as normal
            Y = GetPlayerY(Index) * PIC_Y + Player(Index).YOffset
        End If

        ' render the actual sprite

        DrawSprite(Spritenum, X, Y, srcrec)



        'check for paperdolling
        For i = 1 To Equipment.Equipment_Count - 1
            If GetPlayerEquipment(Index, i) > 0 Then
                If Item(GetPlayerEquipment(Index, i)).Paperdoll > 0 Then
                    Call DrawPaperdoll(X, Y, Item(GetPlayerEquipment(Index, i)).Paperdoll, anim, spriteleft)
                End If
            End If
        Next
    End Sub
    Public Sub DrawPaperdoll(ByVal x2 As Long, ByVal y2 As Long, ByVal Sprite As Long, ByVal Anim As Long, ByVal spritetop As Long)
        Dim rec As Rectangle
        Dim X As Long, y As Long
        Dim width As Long, height As Long

        ' If debug mode, handle error then exit out

        If Sprite < 1 Or Sprite > NumPaperdolls Then Exit Sub


        With rec
            .Y = spritetop * (PaperDollGFXInfo(Sprite).height / 4)
            .Height = (PaperDollGFXInfo(Sprite).height / 4)
            .X = Anim * (PaperDollGFXInfo(Sprite).width / 4)
            .Width = (PaperDollGFXInfo(Sprite).width / 4)
        End With

        X = ConvertMapX(x2)
        y = ConvertMapY(y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        Dim tmpSprite As Sprite = New Sprite(PaperDollGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(X, y)
        GameWindow.Draw(tmpSprite)
    End Sub
    Public Sub DrawNpc(ByVal MapNpcNum As Long)
        Dim anim As Byte
        Dim X As Long
        Dim Y As Long
        Dim Sprite As Long, spriteleft As Long
        Dim destrec As Rectangle
        Dim srcrec As Rectangle
        Dim attackspeed As Long

        If MapNpc(MapNpcNum).Num = 0 Then Exit Sub ' no npc set

        If MapNpc(MapNpcNum).X < TileView.left Or MapNpc(MapNpcNum).X > TileView.right Then Exit Sub
        If MapNpc(MapNpcNum).Y < TileView.top Or MapNpc(MapNpcNum).Y > TileView.bottom Then Exit Sub

        Sprite = Npc(MapNpc(MapNpcNum).Num).Sprite

        If Sprite < 1 Or Sprite > NumCharacters Then Exit Sub

        attackspeed = 1000

        ' Reset frame
        anim = 1

        ' Check for attacking animation
        If MapNpc(MapNpcNum).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If MapNpc(MapNpcNum).Attacking = 1 Then
                anim = 2
            End If
        Else
            ' If not attacking, walk normally
            Select Case MapNpc(MapNpcNum).Dir
                Case DIR_UP
                    If (MapNpc(MapNpcNum).YOffset > 8) Then anim = MapNpc(MapNpcNum).Steps
                Case DIR_DOWN
                    If (MapNpc(MapNpcNum).YOffset < -8) Then anim = MapNpc(MapNpcNum).Steps
                Case DIR_LEFT
                    If (MapNpc(MapNpcNum).XOffset > 8) Then anim = MapNpc(MapNpcNum).Steps
                Case DIR_RIGHT
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
            Case DIR_UP
                spriteleft = 3
            Case DIR_RIGHT
                spriteleft = 2
            Case DIR_DOWN
                spriteleft = 0
            Case DIR_LEFT
                spriteleft = 1
        End Select


        srcrec = New Rectangle((anim) * (SpritesGFXInfo(Sprite).width / 4), spriteleft * (SpritesGFXInfo(Sprite).height / 4), (SpritesGFXInfo(Sprite).width / 4), (SpritesGFXInfo(Sprite).height / 4))

        ' Calculate the X
        X = MapNpc(MapNpcNum).X * PIC_X + MapNpc(MapNpcNum).XOffset - ((SpritesGFXInfo(Sprite).width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (SpritesGFXInfo(Sprite).height / 4) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            Y = MapNpc(MapNpcNum).Y * PIC_Y + MapNpc(MapNpcNum).YOffset - ((SpritesGFXInfo(Sprite).height / 4) - 32)
        Else
            ' Proceed as normal
            Y = MapNpc(MapNpcNum).Y * PIC_Y + MapNpc(MapNpcNum).YOffset
        End If

        destrec = New Rectangle(X, Y, SpritesGFXInfo(Sprite).width / 4, SpritesGFXInfo(Sprite).height / 4)

        Call DrawSprite(Sprite, X, Y, srcrec)

    End Sub
    Public Sub DrawResource(ByVal Resource As Long, ByVal dx As Long, ByVal dy As Long, ByVal rec As Rectangle)
        If Resource < 1 Or Resource > NumResources Then Exit Sub
        Dim X As Long
        Dim Y As Long
        Dim width As Long
        Dim height As Long

        X = ConvertMapX(dx)
        Y = ConvertMapY(dy)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        If rec.Width < 0 Or rec.Height < 0 Then Exit Sub
        Dim tmpSprite As Sprite = New Sprite(ResourcesGFX(Resource))
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(X, Y)
        GameWindow.Draw(tmpSprite)
    End Sub



    Public Sub DrawMapResource(ByVal Resource_num As Long)
        Dim Resource_master As Long

        Dim Resource_state As Long
        Dim Resource_sprite As Long
        Dim rec As Rectangle
        Dim X As Long, Y As Long
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
        Call DrawResource(Resource_sprite, X, Y, rec)
    End Sub
    Public Sub DrawItem(ByVal itemnum As Long)

        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim PicNum As Integer
        Dim x As Long, y As Long
        PicNum = Item(MapItem(itemnum).Num).Pic

        If PicNum < 1 Or PicNum > NumItems Then Exit Sub

        With MapItem(itemnum)
            If .X < TileView.left Or .X > TileView.right Then Exit Sub
            If .Y < TileView.top Or .Y > TileView.bottom Then Exit Sub
        End With


        If ItemsGFXInfo(PicNum).width > 64 Then ' has more than 1 frame
            srcrec = New Rectangle((MapItem(itemnum).Frame * 32), 0, 32, 32)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PIC_X), ConvertMapY(MapItem(itemnum).Y * PIC_Y), 32, 32)
        Else
            srcrec = New Rectangle(0, 0, PIC_X, PIC_Y)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PIC_X), ConvertMapY(MapItem(itemnum).Y * PIC_Y), PIC_X, PIC_Y)
        End If

        x = ConvertMapX(MapItem(itemnum).X * PIC_X)
        y = ConvertMapY(MapItem(itemnum).Y * PIC_Y)

        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(PicNum))
        tmpSprite.TextureRect = New IntRect(srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(x, y)
        GameWindow.Draw(tmpSprite)
    End Sub

    Public Sub DrawSprite(ByVal Sprite As Long, ByVal x2 As Long, ByVal y2 As Long, ByVal rec As Rectangle)
        Dim X As Long
        Dim y As Long
        Dim width As Long
        Dim height As Long
        On Error Resume Next

        If Sprite < 1 Or Sprite > NumCharacters Then Exit Sub
        X = ConvertMapX(x2)
        y = ConvertMapY(y2)
        width = (rec.Width)
        height = (rec.Height)

        Dim tmpSprite As Sprite = New Sprite(SpritesGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(X, y)
        GameWindow.Draw(tmpSprite)
    End Sub
    Public Sub DrawBlood(ByVal Index As Long)
        Dim dest As Point = New Point(frmMainGame.PointToScreen(frmMainGame.picscreen.Location))
        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim x As Long
        Dim y As Long

        With Blood(Index)
            If .X < TileView.left Or .X > TileView.right Then Exit Sub
            If .Y < TileView.top Or .Y > TileView.bottom Then Exit Sub
            ' check if we should be seeing it
            If .Timer + 20000 < GetTickCount() Then Exit Sub

            x = ConvertMapX(Blood(Index).X * PIC_X)
            y = ConvertMapY(Blood(Index).Y * PIC_Y)

            srcrec = New Rectangle((.Sprite - 1) * PIC_X, 0, PIC_X, PIC_Y)

            destrec = New Rectangle(ConvertMapX(.X * PIC_X), ConvertMapY(.Y * PIC_Y), PIC_X, PIC_Y)

            Dim tmpSprite As Sprite = New Sprite(BloodGFX)
            tmpSprite.TextureRect = New IntRect(srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)
            tmpSprite.Position = New SFML.System.Vector2f(x, y)
            GameWindow.Draw(tmpSprite)
        End With

    End Sub

    Public Sub DrawMapTile(ByVal X As Long, ByVal Y As Long)
        Dim i As Long
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim tmpSprite As Sprite
        If GettingMap Then Exit Sub
        With Map.Tile(X, Y)
            For i = MapLayer.Ground To MapLayer.Mask2
                ' skip tile if tileset isn't set
                If .Layer(i).tileset > 0 Then
                    With srcrect
                        .X = Map.Tile(X, Y).Layer(i).X * 32
                        .Y = Map.Tile(X, Y).Layer(i).Y * 32
                        .Width = 32
                        .Height = 32
                    End With
                    tmpSprite = New Sprite(TileSetTexture(.Layer(i).tileset))
                    tmpSprite.TextureRect = New IntRect(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y))
                    GameWindow.Draw(tmpSprite)
                End If
            Next
        End With
    End Sub
    Public Sub DrawMapFringeTile(ByVal X As Long, ByVal Y As Long)
        Dim i As Long
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim dest As Rectangle = New Rectangle(frmMainGame.PointToScreen(frmMainGame.picscreen.Location), New Size(32, 32))
        Dim tmpSprite As Sprite
        With Map.Tile(X, Y)
            For i = MapLayer.Fringe To MapLayer.Fringe2
                ' skip tile if tileset isn't set
                If .Layer(i).tileset > 0 And .Layer(i).tileset <= NumTileSets Then
                    ' render
                    With srcrect
                        .X = Map.Tile(X, Y).Layer(i).X * 32
                        .Y = Map.Tile(X, Y).Layer(i).Y * 32
                        .Width = 32
                        .Height = 32
                    End With
                    tmpSprite = New Sprite(TileSetTexture(.Layer(i).tileset))
                    tmpSprite.TextureRect = New IntRect(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y))
                    GameWindow.Draw(tmpSprite)
                End If
            Next
        End With
    End Sub
    Public Function IsValidMapPoint(ByVal X As Long, ByVal Y As Long) As Boolean
        IsValidMapPoint = False

        If X < 0 Then Exit Function
        If Y < 0 Then Exit Function
        If X > Map.MaxX Then Exit Function
        If Y > Map.MaxY Then Exit Function
        IsValidMapPoint = True
    End Function
    Public Sub UpdateCamera()
        Dim offsetX As Long
        Dim offsetY As Long
        Dim StartX As Long
        Dim StartY As Long
        Dim EndX As Long
        Dim EndY As Long
        offsetX = Player(MyIndex).XOffset + PIC_X
        offsetY = Player(MyIndex).YOffset + PIC_Y
        StartX = GetPlayerX(MyIndex) - ((MAX_MAPX + 1) \ 2) - 1
        StartY = GetPlayerY(MyIndex) - ((MAX_MAPY + 1) \ 2) - 1

        If StartX < 0 Then
            offsetX = 0

            If StartX = -1 Then
                If Player(MyIndex).XOffset > 0 Then
                    offsetX = Player(MyIndex).XOffset
                End If
            End If

            StartX = 0
        End If

        If StartY < 0 Then
            offsetY = 0

            If StartY = -1 Then
                If Player(MyIndex).YOffset > 0 Then
                    offsetY = Player(MyIndex).YOffset
                End If
            End If

            StartY = 0
        End If

        EndX = StartX + (MAX_MAPX + 1) + 1
        EndY = StartY + (MAX_MAPY + 1) + 1

        If EndX > Map.MaxX Then
            offsetX = 32

            If EndX = Map.MaxX + 1 Then
                If Player(MyIndex).XOffset < 0 Then
                    offsetX = Player(MyIndex).XOffset + PIC_X
                End If
            End If

            EndX = Map.MaxX
            StartX = EndX - MAX_MAPX - 1
        End If

        If EndY > Map.MaxY Then
            offsetY = 32

            If EndY = Map.MaxY + 1 Then
                If Player(MyIndex).YOffset < 0 Then
                    offsetY = Player(MyIndex).YOffset + PIC_Y
                End If
            End If

            EndY = Map.MaxY
            StartY = EndY - MAX_MAPY - 1
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
    Public Sub Render_Graphics()
        Dim X As Long
        Dim Y As Long
        Dim i As Long
        'Don't Render IF
        If frmMainGame.WindowState = FormWindowState.Minimized Then Exit Sub
        If GettingMap Then Exit Sub

        UpdateCamera()

        DoEvents()

        'Clear each of our render targets
        GameWindow.DispatchEvents()
        GameWindow.Clear(SFML.Graphics.Color.Black)

        ' update animation editor
        If Editor = EDITOR_ANIMATION Then
            EditorAnim_DrawAnim()
        End If

        ' blit lower tiles
        If NumTileSets > 0 Then
            For X = TileView.left To TileView.right + 1
                For Y = TileView.top To TileView.bottom + 1
                    If IsValidMapPoint(X, Y) Then
                        Call DrawMapTile(X, Y)
                    End If
                Next
            Next
        End If

        For i = 1 To MAX_BYTE
            Call DrawBlood(i)
        Next

        ' Draw out the items
        If NumItems > 0 Then
            For i = 1 To MAX_MAP_ITEMS

                If MapItem(i).Num > 0 Then
                    Call DrawItem(i)
                End If

            Next
        End If

        ''Draw sum d00rs.
        For X = TileView.left To TileView.right
            For Y = TileView.top To TileView.bottom

                If IsValidMapPoint(X, Y) Then
                    If Map.Tile(X, Y).Type = TILE_TYPE_DOOR Then
                        DrawDoor(X, Y)
                    End If
                End If

            Next
        Next

        ' draw animations
        If NumAnimations > 0 Then
            For i = 1 To MAX_BYTE
                If AnimInstance(i).Used(0) Then
                    DrawAnimation(i, 0)
                End If
            Next
        End If


        ' Y-based render. Renders Players, Npcs and Resources based on Y-axis.
        For Y = 0 To Map.MaxY

            If NumCharacters > 0 Then
                ' Players
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                        If Player(i).Y = Y Then
                            Call DrawPlayer(i)
                        End If
                    End If
                Next

                ' Npcs
                For i = 1 To MAX_MAP_NPCS
                    If MapNpc(i).Y = Y Then
                        Call DrawNpc(i)
                    End If
                Next
            End If

            ' Resources
            If NumResources > 0 Then
                If Resources_Init Then
                    If Resource_Index > 0 Then
                        For i = 1 To Resource_Index
                            If MapResource(i).Y = Y Then
                                Call DrawMapResource(i)
                            End If
                        Next
                    End If
                End If
            End If
        Next

        ' animations
        If NumAnimations > 0 Then
            For i = 1 To MAX_BYTE
                If AnimInstance(i - 1).Used(1) Then
                    DrawAnimation(i - 1, 1)
                End If
            Next
        End If

        ' blit out upper tiles
        If NumTileSets > 0 Then
            For X = TileView.left To TileView.right + 1
                For Y = TileView.top To TileView.bottom + 1
                    If IsValidMapPoint(X, Y) Then
                        Call DrawMapFringeTile(X, Y)
                    End If
                Next
            Next
        End If

        ' Draw out a square at mouse cursor
        If InMapEditor Then
            If frmEditor_Map.optBlocks.Checked = True Then
                For X = TileView.left To TileView.right
                    For Y = TileView.top To TileView.bottom
                        If IsValidMapPoint(X, Y) Then
                            Call DrawDirections(X, Y)
                        End If
                    Next
                Next
            End If
            Call DrawTileOutline()
        End If

        ' draw cursor, player X and Y locations
        If BLoc Then
            Call DrawText(1, 1, Trim$("cur x: " & CurX & " y: " & CurY), SFML.Graphics.Color.Yellow, GameWindow)
            Call DrawText(1, 15, Trim$("loc x: " & GetPlayerX(MyIndex) & " y: " & GetPlayerY(MyIndex)), SFML.Graphics.Color.Yellow, GameWindow)
            Call DrawText(1, 27, Trim$(" (map #" & GetPlayerMap(MyIndex) & ")"), SFML.Graphics.Color.Yellow, GameWindow)
        End If

        ' draw player names
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                Call DrawPlayerName(i)
            End If
        Next

        ' draw npc names
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).Num > 0 Then
                Call DrawNPCName(i)
            End If
        Next

        For i = 1 To MAX_BYTE
            Call DrawActionMsg(i)
        Next i

        ' Blit out map attributes
        If InMapEditor Then
            Call DrawMapAttributes()
        End If

        GameWindow.Display()

        ' Draw map name
        DrawMapName()
        DrawBars() 'Uses graphicscard.clear method which isnt called DURING a scene :D




    End Sub
    Public Sub DrawBars()
        Dim tmpY As Long
        Dim tmpX As Long
        Dim barWidth As Long
        Dim rec(1) As Rectangle

        ' check for casting time bar
        If SpellBuffer > 0 Then
            ' lock to player
            tmpX = GetPlayerX(MyIndex) * PIC_X + Player(MyIndex).XOffset
            tmpY = GetPlayerY(MyIndex) * PIC_Y + Player(MyIndex).YOffset + 35
            ' calculate the width to fill
            barWidth = ((GetTickCount() - SpellBufferTimer) / ((GetTickCount() - SpellBufferTimer) + (Spell(PlayerSpells(SpellBuffer)).CastTime * 1000)) * 64)
            ' draw bars
            rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
            Dim rectShape As New RectangleShape(New SFML.System.Vector2f(barWidth, 4))
            rectShape.Position = New SFML.System.Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY))
            rectShape.FillColor = SFML.Graphics.Color.Cyan
            GameWindow.Draw(rectShape)
        End If
    End Sub
    Sub DrawMapName()
        DrawText(DrawMapNameX, DrawMapNameY, Map.Name, DrawMapNameColor, GameWindow)
    End Sub
    Public Sub DrawDoor(ByVal X As Long, ByVal Y As Long)
        Dim rec As Rectangle

        Dim x2 As Long, y2 As Long

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
        Dim tmpSprite As Sprite = New Sprite(DoorGFX)
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(x2), ConvertMapY(y2))
        GameWindow.Draw(tmpSprite)
    End Sub
    Public Sub DrawAnimation(ByVal Index As Long, ByVal Layer As Long)

        Dim Sprite As Integer
        Dim sRECT As Rectangle
        Dim width As Long, height As Long
        Dim FrameCount As Long
        Dim X As Long, Y As Long
        Dim lockindex As Long

        If AnimInstance(Index).Animation = 0 Then
            ClearAnimInstance(Index)
            Exit Sub
        End If

        Sprite = Animation(AnimInstance(Index).Animation).Sprite(Layer)

        If Sprite < 1 Or Sprite > NumAnimations Then Exit Sub

        FrameCount = Animation(AnimInstance(Index).Animation).Frames(Layer)

        ' total width divided by frame count
        width = AnimationsGFXInfo(Sprite).width / FrameCount
        height = AnimationsGFXInfo(Sprite).height

        sRECT.Y = 0
        sRECT.Height = height
        sRECT.X = (AnimInstance(Index).FrameIndex(Layer) - 1) * width
        sRECT.Width = width

        ' change x or y if locked
        If AnimInstance(Index).LockType > TARGET_TYPE_NONE Then ' if <> none
            ' is a player
            If AnimInstance(Index).LockType = TARGET_TYPE_PLAYER Then
                ' quick save the index
                lockindex = AnimInstance(Index).lockindex
                ' check if is ingame
                If IsPlaying(lockindex) Then
                    ' check if on same map
                    If GetPlayerMap(lockindex) = GetPlayerMap(MyIndex) Then
                        ' is on map, is playing, set x & y
                        X = (GetPlayerX(lockindex) * PIC_X) + 16 - (width / 2) + Player(lockindex).XOffset
                        Y = (GetPlayerY(lockindex) * PIC_Y) + 16 - (height / 2) + Player(lockindex).YOffset
                    End If
                End If
            ElseIf AnimInstance(Index).LockType = TARGET_TYPE_NPC Then
                ' quick save the index
                lockindex = AnimInstance(Index).lockindex
                ' check if NPC exists
                If MapNpc(lockindex).Num > 0 Then
                    ' check if alive
                    If MapNpc(lockindex).Vital(Vitals.HP) > 0 Then
                        ' exists, is alive, set x & y
                        X = (MapNpc(lockindex).X * PIC_X) + 16 - (width / 2) + MapNpc(lockindex).XOffset
                        Y = (MapNpc(lockindex).Y * PIC_Y) + 16 - (height / 2) + MapNpc(lockindex).YOffset
                    Else
                        ' npc not alive anymore, kill the animation
                        ClearAnimInstance(Index)
                        Exit Sub
                    End If
                Else
                    ' npc not alive anymore, kill the animation
                    ClearAnimInstance(Index)
                    Exit Sub
                End If
            End If
        Else
            ' no lock, default x + y
            X = (AnimInstance(Index).X * 32) + 16 - (width / 2)
            Y = (AnimInstance(Index).Y * 32) + 16 - (height / 2)
        End If

        X = ConvertMapX(X)
        Y = ConvertMapY(Y)

        ' Clip to screen
        If Y < 0 Then

            With sRECT
                .Y = .Y - Y
                .Height = .Height - (Y * (-1))
            End With

            Y = 0
        End If

        If X < 0 Then

            With sRECT
                .X = .X - X
                .Width = .Width - (Y * (-1))
            End With

            X = 0
        End If

        If sRECT.Width < 0 Or sRECT.Height < 0 Then Exit Sub

        Dim tmpSprite As Sprite = New Sprite(AnimationsGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(X, Y)
        GameWindow.Draw(tmpSprite)
    End Sub

    Public Sub DrawTileOutline()
        Dim rec As Rectangle
        If frmEditor_Map.optBlocks.Checked Then Exit Sub

        With rec
            .Y = 0
            .Height = PIC_Y
            .X = 0
            .Width = PIC_X
        End With

        Dim tmpSprite As Sprite = New Sprite(MiscGFX)
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
        GameWindow.Draw(tmpSprite)
    End Sub
    Public Sub EditorMap_DrawTileset()
        Dim height As Integer
        Dim width As Integer
        Dim tileset As Byte

        ' find tileset number
        tileset = frmEditor_Map.scrlTileSet.Value

        ' exit out if doesn't exist
        If tileset < 0 Or tileset > NumTileSets Then Exit Sub

        'Draw the tileset into memory.)

        height = TileSetImgsGFX(tileset).Height
        width = TileSetImgsGFX(tileset).Width
        MapEditorBackBuffer = New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(MapEditorBackBuffer)
        g.FillRectangle(Brushes.Black, New Rectangle(0, 0, MapEditorBackBuffer.Width, MapEditorBackBuffer.Height))
        frmEditor_Map.picBackSelect.Height = height
        frmEditor_Map.picBackSelect.Width = width


        g.DrawImage(TileSetImgsGFX(tileset), New Rectangle(0, 0, TileSetImgsGFX(tileset).Width, TileSetImgsGFX(tileset).Height))
        g.DrawRectangle(Pens.Red, New Rectangle(EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, (EditorTileSelEnd.X - EditorTileSelStart.X) * PIC_X, (EditorTileSelEnd.Y - EditorTileSelStart.Y) * PIC_X))
        g.Dispose()

        g = frmEditor_Map.picBackSelect.CreateGraphics
        g.DrawImage(MapEditorBackBuffer, New Rectangle(0, 0, width, height))
        g.Dispose()
    End Sub
    Sub DestroyGraphics()
        On Error Resume Next ' Just in Case (For instance, map editor wasn't used. A new object instance error will occur.) We dont want it to error
        ' Number of graphic files
        If Not StatBarBackbuffer Is Nothing Then StatBarBackbuffer.Dispose()
        If Not MapEditorBackBuffer Is Nothing Then MapEditorBackBuffer.Dispose()


        If Not TempBitmap Is Nothing Then TempBitmap.Dispose()
        If Not TempBitmap1 Is Nothing Then TempBitmap1.Dispose()

        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
            If Not TileSetTexture(i) Is Nothing Then TileSetTexture(i).Dispose()
        Next i

        For i = 0 To NumCharacters
            If Not SpritesGFX(i) Is Nothing Then SpritesGFX(i).Dispose()
        Next

        If Not BloodGFX Is Nothing Then BloodGFX.Dispose()
        If Not Directions Is Nothing Then Directions.Dispose()
        If Not MiscGFX Is Nothing Then MiscGFX.Dispose()
        If Not DoorGFX Is Nothing Then DoorGFX.Dispose()

        For i = 0 To NumItems
            If Not ItemsGFX(i) Is Nothing Then ItemsGFX(i).Dispose()
        Next

        If Not HPBar Is Nothing Then HPBar.Dispose()
        If Not ManaBar Is Nothing Then ManaBar.Dispose()
        If Not EXPBar Is Nothing Then EXPBar.Dispose()
        If Not EmptyHPBar Is Nothing Then EmptyHPBar.Dispose()
        If Not EmptyManaBar Is Nothing Then EmptyManaBar.Dispose()
        If Not EmptyEXPBar Is Nothing Then EmptyEXPBar.Dispose()

    End Sub
    Public Sub EditorMap_DrawMapItem()
        Dim itemnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Dim g As Graphics = frmEditor_Map.picMapItem.CreateGraphics
        itemnum = Item(frmEditor_Map.scrlMapItem.Value).Pic

        If itemnum < 1 Or itemnum > NumItems Then
            EditorMap_Item.Clear(ToSFMLColor(frmEditor_Map.picMapItem.BackColor))
            EditorMap_Item.Display()
            Exit Sub
        End If


        sRECT.Y = 0
        sRECT.Height = PIC_Y
        sRECT.X = 0
        sRECT.Width = PIC_X
        dRECT.Y = 0
        dRECT.Height = PIC_Y
        dRECT.X = 0
        dRECT.Width = PIC_X

        EditorMap_Item.Clear(ToSFMLColor(frmEditor_Map.picMapItem.BackColor))
        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itemnum))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorMap_Item.Draw(tmpSprite)
        EditorMap_Item.Display()
    End Sub
    Public Sub EditorMap_DrawKey()
        Dim itemnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Dim g As Graphics = frmEditor_Map.picMapKey.CreateGraphics
        itemnum = Item(frmEditor_Map.scrlMapKey.Value).Pic

        If itemnum < 1 Or itemnum > NumItems Then
            EditorMap_Key.Clear(ToSFMLColor(frmEditor_Map.picMapKey.BackColor))
            EditorMap_Key.Display()
            Exit Sub
        End If

        sRECT.Y = 0
        sRECT.Height = PIC_Y
        sRECT.X = 0
        sRECT.Width = PIC_X
        dRECT.Y = 0
        dRECT.Height = PIC_Y
        dRECT.X = 0
        dRECT.Width = PIC_X

        EditorMap_Key.Clear(ToSFMLColor(frmEditor_Map.picMapKey.BackColor))
        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itemnum))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorMap_Key.Draw(tmpSprite)
        EditorMap_Key.Display()
    End Sub
    Public Sub EditorItem_DrawItem()
        Dim itemnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        itemnum = frmEditor_Item.scrlPic.Value

        If itemnum < 1 Or itemnum > NumItems Then
            EditorItem_Item.Clear(ToSFMLColor(frmEditor_Item.picItem.BackColor))
            EditorItem_Item.Display()
            Exit Sub
        End If

        ' rect for source
        sRECT.Y = 0
        sRECT.Height = PIC_Y
        sRECT.X = 0
        sRECT.Width = PIC_X
        ' same for destination as source
        dRECT = sRECT
        EditorItem_Item.Clear(ToSFMLColor(frmEditor_Item.picItem.BackColor))
        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itemnum))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorItem_Item.Draw(tmpSprite)
        EditorItem_Item.Display()
    End Sub

    Public Sub EditorItem_DrawPaperdoll()
        Dim Sprite As Long
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle


        Sprite = frmEditor_Item.scrlPaperdoll.Value

        If Sprite < 1 Or Sprite > NumPaperdolls Then
            EditorItem_Paperdoll.Clear(ToSFMLColor(frmEditor_Item.picPaperdoll.BackColor))
            EditorItem_Paperdoll.Display()
            Exit Sub
        End If

        ' rect for source
        sRECT.Y = 0
        sRECT.Height = PaperDollGFXInfo(Sprite).height
        sRECT.X = 0
        sRECT.Width = PaperDollGFXInfo(Sprite).width
        ' same for destination as source
        dRECT = sRECT
        EditorItem_Paperdoll.Clear(ToSFMLColor(frmEditor_Item.picPaperdoll.BackColor))
        Dim tmpSprite As Sprite = New Sprite(PaperDollGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorItem_Paperdoll.Draw(tmpSprite)
        EditorItem_Paperdoll.Display()
    End Sub
    Public Sub EditorNpc_DrawSprite()
        Dim Sprite As Long
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Sprite = frmEditor_NPC.scrlSprite.Value

        If Sprite < 1 Or Sprite > NumCharacters Then
            EditorNPC_Sprite.Clear(ToSFMLColor(frmEditor_NPC.picSprite.BackColor))
            EditorNPC_Sprite.Display()
            Exit Sub
        End If

        sRECT.Y = 0
        sRECT.Height = SIZE_Y
        sRECT.X = 0 ' facing down
        sRECT.Width = SIZE_X
        dRECT.Y = 0
        dRECT.Height = SIZE_Y
        dRECT.X = 0
        dRECT.Width = SIZE_X

        EditorNPC_Sprite.Clear(ToSFMLColor(frmEditor_NPC.picSprite.BackColor))
        Dim tmpSprite As Sprite = New Sprite(SpritesGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorNPC_Sprite.Draw(tmpSprite)
        EditorNPC_Sprite.Display()
    End Sub
    Public Sub EditorResource_DrawSprite()
        Dim Sprite As Long
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle

        ' normal sprite
        Sprite = frmEditor_Resource.scrlNormalPic.Value

        If Sprite < 1 Or Sprite > NumResources Then
            EditorResource_Resource.Clear(ToSFMLColor(frmEditor_Resource.picNormalpic.BackColor))
            EditorResource_Resource.Display()
        Else
            sRECT.Y = 0
            sRECT.Height = ResourcesGFXInfo(Sprite).height
            sRECT.X = 0
            sRECT.Width = ResourcesGFXInfo(Sprite).width
            dRECT.Y = 0
            dRECT.Height = ResourcesGFXInfo(Sprite).height
            dRECT.X = 0
            dRECT.Width = ResourcesGFXInfo(Sprite).width

            EditorResource_Resource.Clear(ToSFMLColor(frmEditor_Resource.picNormalpic.BackColor))
            Dim tmpSprite As Sprite = New Sprite(ResourcesGFX(Sprite))
            tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
            tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
            EditorResource_Resource.Draw(tmpSprite)
            EditorResource_Resource.Display()
        End If

        ' exhausted sprite
        Sprite = frmEditor_Resource.scrlExhaustedPic.Value

        If Sprite < 1 Or Sprite > NumResources Then
            EditorResource_ExResource.Clear(ToSFMLColor(frmEditor_Resource.picExhaustedPic.BackColor))
            EditorResource_ExResource.Display()
        Else
            sRECT.Y = 0
            sRECT.Height = ResourcesGFXInfo(Sprite).height
            sRECT.X = 0
            sRECT.Width = ResourcesGFXInfo(Sprite).width
            dRECT.Y = 0
            dRECT.Height = ResourcesGFXInfo(Sprite).height
            dRECT.X = 0
            dRECT.Width = ResourcesGFXInfo(Sprite).width
            EditorResource_ExResource.Clear(ToSFMLColor(frmEditor_Resource.picExhaustedPic.BackColor))
            Dim tmpSprite As Sprite = New Sprite(ResourcesGFX(Sprite))
            tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
            tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
            EditorResource_ExResource.Draw(tmpSprite)
            EditorResource_ExResource.Display()
        End If
    End Sub
    Public Sub EditorSpell_BltIcon()
        Dim iconnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        iconnum = frmEditor_Spell.scrlIcon.Value

        If iconnum < 1 Or iconnum > NumSpellIcons Then
            EditorSpell_Icon.Clear(ToSFMLColor(frmEditor_Spell.picSprite.BackColor))
            EditorSpell_Icon.Display()
            Exit Sub
        End If

        sRECT.Y = 0
        sRECT.Height = PIC_Y
        sRECT.X = 0
        sRECT.Width = PIC_X
        dRECT.Y = 0
        dRECT.Height = PIC_Y
        dRECT.X = 0
        dRECT.Width = PIC_X

        EditorSpell_Icon.Clear(ToSFMLColor(frmEditor_Spell.picSprite.BackColor))
        Dim tmpSprite As Sprite = New Sprite(SpellIconsGFX(iconnum))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorSpell_Icon.Draw(tmpSprite)
        EditorSpell_Icon.Display()
    End Sub
    Public Sub EditorAnim_DrawAnim()
        Dim Animationnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Dim width As Long, height As Long
        Dim looptime As Long
        Dim FrameCount As Long
        Dim ShouldRender As Boolean


        Animationnum = frmEditor_Animation.scrlSprite0.Value

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

                    sRECT.Y = 0
                    sRECT.Height = height
                    sRECT.X = (AnimEditorFrame(0) - 1) * width
                    sRECT.Width = width

                    dRECT.Y = 0
                    dRECT.Height = height
                    dRECT.X = 0
                    dRECT.Width = width

                    EditorAnimation_Anim1.Clear(ToSFMLColor(frmEditor_Animation.picSprite0.BackColor))
                    Dim tmpSprite As Sprite = New Sprite(AnimationsGFX(Animationnum))
                    tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
                    EditorAnimation_Anim1.Draw(tmpSprite)
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

                    sRECT.Y = 0
                    sRECT.Height = height
                    sRECT.X = (AnimEditorFrame(1) - 1) * width
                    sRECT.Width = width

                    dRECT.Y = 0
                    dRECT.Height = height
                    dRECT.X = 0
                    dRECT.Width = width
                    EditorAnimation_Anim2.Clear(ToSFMLColor(frmEditor_Animation.picSprite1.BackColor))
                    Dim tmpSprite As Sprite = New Sprite(AnimationsGFX(Animationnum))
                    tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
                    EditorAnimation_Anim2.Draw(tmpSprite)
                    EditorAnimation_Anim2.Display()
                End If
            End If
        End If
    End Sub
    Sub DrawEquipment()
        Dim i As Long, itemnum As Long, itempic As Long
        Dim rec As Rectangle, rec_pos As Rectangle
        If NumItems = 0 Then Exit Sub

        EquipmentWindow.Clear(ToSFMLColor(frmMainGame.pnlCharacter.BackColor))

        For i = 1 To Equipment.Equipment_Count - 1
            itemnum = GetPlayerEquipment(MyIndex, i)

            If itemnum > 0 Then
                itempic = Item(itemnum).Pic

                With rec
                    .Y = 0
                    .Height = 32
                    .X = 32
                    .Width = 32
                End With

                With rec_pos
                    .Y = EqTop
                    .Height = PIC_Y
                    .X = EqLeft + ((EqOffsetX + 32) * (((i - 1) Mod EqColumns)))
                    .Width = PIC_X
                End With

                Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                EquipmentWindow.Draw(tmpSprite)
            End If

        Next
        EquipmentWindow.Display()
    End Sub
    Public Sub DrawInventoryItem(ByVal X As Long, ByVal Y As Long)
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim itemnum As Long, itempic As Long

        itemnum = GetPlayerInvItemNum(MyIndex, DragInvSlotNum)
        TmpItemWindow.Clear(ToSFMLColor(frmMainGame.pnlTmpInv.BackColor))
        If itemnum > 0 And itemnum <= MAX_ITEMS Then
            itempic = Item(itemnum).Pic
            If itempic = 0 Then Exit Sub

            With rec
                .Y = 0
                .Height = PIC_Y
                .X = ItemsGFXInfo(itempic).width / 2
                .Width = PIC_X
            End With

            With rec_pos
                .Y = 0
                .Height = PIC_Y
                .X = 0
                .Width = PIC_X
            End With

            Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
            tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
            tmpSprite.Position = New SFML.System.Vector2f(0, 0)
            TmpItemWindow.Draw(tmpSprite)

            With frmMainGame.pnlTmpInv
                .Top = Y
                .Left = X
                .Visible = True
                .BringToFront()
            End With

        End If
        TmpItemWindow.Display()

    End Sub
    Sub DrawInventory()
        Dim i As Long, X As Long, Y As Long, itemnum As Long, itempic As Long
        Dim Amount As String
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim colour As SFML.Graphics.Color


        If Not InGame Then Exit Sub
        InventoryWindow.Clear(ToSFMLColor(frmMainGame.pnlInventory.BackColor))

        For i = 1 To MAX_INV
            itemnum = GetPlayerInvItemNum(MyIndex, i)

            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic = 0 Then GoTo nextloop

                ' exit out if we're offering item in a trade.
                If InTrade > 0 Then
                    For X = 1 To MAX_INV
                        If TradeYourOffer(X).Num = i Then
                            GoTo NextLoop
                        End If
                    Next
                End If

                If itempic > 0 And itempic <= NumItems Then
                    If ItemsGFXInfo(itempic).width <= 64 Then ' more than 1 frame is handled by anim sub

                        With rec
                            .Y = 0
                            .Height = 32
                            .X = 32
                            .Width = 32
                        End With

                        With rec_pos
                            .Y = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                            .Height = PIC_Y
                            .X = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                            .Width = PIC_X
                        End With

                        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                        tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                        InventoryWindow.Draw(tmpSprite)


                        ' If item is a stack - draw the amount you have
                        If GetPlayerInvItemValue(MyIndex, i) > 1 Then
                            Y = rec_pos.Top + 22
                            X = rec_pos.Left - 4
                            Amount = CStr(GetPlayerInvItemValue(MyIndex, i))

                            colour = SFML.Graphics.Color.White

                            ' Draw currency but with k, m, b etc. using a convertion function
                            If CLng(Amount) < 1000000 Then
                                colour = SFML.Graphics.Color.White
                            ElseIf CLng(Amount) > 1000000 And CLng(Amount) < 10000000 Then
                                colour = SFML.Graphics.Color.Yellow
                            ElseIf CLng(Amount) > 10000000 Then
                                colour = SFML.Graphics.Color.Green
                            End If

                            DrawText(X, Y, ConvertCurrency(Amount), colour, InventoryWindow)

                            ' Check if it's gold, and update the label
                            If GetPlayerInvItemNum(MyIndex, i) = 1 Then '1 = gold :P
                                frmMainGame.lblGold.Text = Microsoft.VisualBasic.Strings.Format(Amount, "#,###,###,###")
                            End If
                        End If
                    End If
                End If
            End If
NextLoop:
        Next
        'GraphicsCard.EndScene()
        'GraphicsCard.Present(New Rectangle(0, 0, frmMainGame.pnlInventory.Width, frmMainGame.pnlInventory.Height), frmMainGame.pnlInventory, True)
        'update animated items
        DrawAnimatedInvItems()
        InventoryWindow.Display()
    End Sub
    Sub DrawAnimatedInvItems()
        Dim i As Long
        Dim itemnum As Long, itempic As Long

        Dim X As Long, Y As Long
        Dim MaxFrames As Byte
        Dim Amount As Long
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim clearregion(1) As Rectangle
        Static tmr100 As Long
        If tmr100 = 0 Then tmr100 = GetTickCount() + 100

        If Not InGame Then Exit Sub

        If GetTickCount() > tmr100 Then
            ' check for map animation changes#
            For i = 1 To MAX_MAP_ITEMS

                If MapItem(i).Num > 0 Then
                    itempic = Item(MapItem(i).Num).Pic

                    If itempic < 1 Or itempic > NumItems Then Exit Sub
                    MaxFrames = (ItemsGFXInfo(itempic).width / 2) / 32 ' Work out how many frames there are. /2 because of inventory icons as well as ingame

                    If MapItem(i).Frame < MaxFrames - 1 Then
                        MapItem(i).Frame = MapItem(i).Frame + 1
                    Else
                        MapItem(i).Frame = 1
                    End If
                End If
            Next
        End If

        For i = 1 To MAX_INV
            itemnum = GetPlayerInvItemNum(MyIndex, i)

            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic > 0 And itempic <= NumItems Then
                    If ItemsGFXInfo(itempic).width > 64 Then

                        MaxFrames = (ItemsGFXInfo(itempic).width / 2) / 32 ' Work out how many frames there are. /2 because of inventory icons as well as ingame

                        If GetTickCount() > tmr100 Then
                            If InvItemFrame(i) < MaxFrames - 1 Then
                                InvItemFrame(i) = InvItemFrame(i) + 1
                            Else
                                InvItemFrame(i) = 1
                            End If
                            tmr100 = GetTickCount() + 100
                        End If

                        With rec
                            .Y = 0
                            .Height = 32
                            .X = (ItemsGFXInfo(itempic).width / 2) + (InvItemFrame(i) * 32) ' middle to get the start of inv gfx, then +32 for each frame
                            .Width = 32
                        End With

                        With rec_pos
                            .Y = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                            .Height = PIC_Y
                            .X = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                            .Width = PIC_X
                        End With

                        With clearregion(1)
                            .Y = rec_pos.Y
                            .Height = rec_pos.Height
                            .X = rec_pos.X
                            .Width = rec_pos.Width
                        End With

                        ' We'll now re-blt the item, and place the currency value over it again :P
                        'g.DrawImage(ItemsGFX(itempic), rec_pos, rec, GraphicsUnit.Pixel)
                        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                        tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                        InventoryWindow.Draw(tmpSprite)


                        ' If item is a stack - draw the amount you have
                        If GetPlayerInvItemValue(MyIndex, i) > 1 Then
                            Y = rec_pos.Top + 22
                            X = rec_pos.Left - 4
                            Amount = CStr(GetPlayerInvItemValue(MyIndex, i))
                            ' Draw currency but with k, m, b etc. using a convertion function
                            DrawText(X, Y, ConvertCurrency(Amount), SFML.Graphics.Color.Yellow, InventoryWindow)
                            ' Check if it's gold, and update the label
                            If GetPlayerInvItemNum(MyIndex, i) = 1 Then '1 = gold :P
                                frmMainGame.lblGold.Text = Microsoft.VisualBasic.Strings.Format(Amount, "#,###,###,###")
                            End If
                        End If
                    End If
                End If
            End If

        Next
    End Sub

    Sub DrawShop()
        Dim i As Long, X As Long, Y As Long, itemnum As Long, itempic As Long
        Dim Amount As String
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim colour As Brush

        If Not InGame Then Exit Sub
        ShopWindow.Clear(ToSFMLColor(frmMainGame.pnlShopItems.BackColor))
        For i = 1 To MAX_TRADES
            itemnum = Shop(InShop).TradeItem(i).Item 'GetPlayerInvItemNum(MyIndex, i)
            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic > 0 And itempic <= NumItems Then

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 32
                        .Width = 32
                    End With

                    With rec_pos
                        .Y = ShopTop + ((ShopOffsetY + 32) * ((i - 1) \ ShopColumns))
                        .Height = PIC_Y
                        .X = ShopLeft + ((ShopOffsetX + 32) * (((i - 1) Mod ShopColumns)))
                        .Width = PIC_X
                    End With

                    Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                    tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                    ShopWindow.Draw(tmpSprite)

                    ' If item is a stack - draw the amount you have
                    If Shop(InShop).TradeItem(i).ItemValue > 1 Then
                        Y = rec_pos.Top + 22
                        X = rec_pos.Left - 4
                        Amount = CStr(Shop(InShop).TradeItem(i).ItemValue)
                        colour = Brushes.White
                        ' Draw currency but with k, m, b etc. using a convertion function
                        If CLng(Amount) < 1000000 Then
                            colour = Brushes.White
                        ElseIf CLng(Amount) > 1000000 And CLng(Amount) < 10000000 Then
                            colour = Brushes.Yellow
                        ElseIf CLng(Amount) > 10000000 Then
                            colour = Brushes.LightGreen
                        End If

                        'g.DrawString(ConvertCurrency(Amount), New Font(FONT_NAME, FONT_SIZE), colour, X, Y)
                    End If
                End If
            End If
        Next
        ShopWindow.Display()
    End Sub
    Sub DrawBank()
        Dim i As Long, X As Long, Y As Long, itemnum As Long
        Dim Amount As String
        Dim sRECT As Rectangle, dRECT As Rectangle
        Dim Sprite As Long, colour As SFML.Graphics.Color

        If frmMainGame.pnlBank.Visible Then
            BankWindow.Clear(ToSFMLColor(frmMainGame.pnlBank.BackColor))
            For i = 1 To MAX_BANK
                itemnum = GetBankItemNum(i)
                If itemnum > 0 And itemnum <= MAX_ITEMS Then

                    Sprite = Item(itemnum).Pic

                    With sRECT
                        .Y = 0
                        .Height = PIC_Y
                        .X = ItemsGFXInfo(Sprite).width / 2
                        .Width = PIC_X
                    End With

                    With dRECT
                        .Y = BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                        .Height = PIC_Y
                        .X = BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                        .Width = PIC_X
                    End With


                    Dim tmpSprite As Sprite = New Sprite(ItemsGFX(Sprite))
                    tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
                    BankWindow.Draw(tmpSprite)

                    ' If item is a stack - draw the amount you have
                    If GetBankItemValue(i) > 1 Then
                        Y = dRECT.Top + 22
                        X = dRECT.Left - 4

                        Amount = CStr(GetBankItemValue(i))
                        colour = SFML.Graphics.Color.White
                        ' Draw currency but with k, m, b etc. using a convertion function
                        If CLng(Amount) < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf CLng(Amount) > 1000000 And CLng(Amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf CLng(Amount) > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If
                        'g.DrawString(ConvertCurrency(Amount), New Font(FONT_NAME, FONT_SIZE), colour, X, Y)
                        DrawText(X, Y, ConvertCurrency(Amount), colour, BankWindow)
                    End If
                End If
            Next
            BankWindow.Display()
        End If
    End Sub
    Public Sub DrawBankItem(ByVal X As Long, ByVal Y As Long)
        Dim sRECT As Rectangle, dRECT As Rectangle

        Dim itemnum As Long
        Dim Sprite As Long

        itemnum = GetBankItemNum(DragBankSlotNum)
        Sprite = Item(GetBankItemNum(DragBankSlotNum)).Pic
        If itemnum > 0 Then
            If itemnum <= MAX_ITEMS Then
                With sRECT
                    .Y = 0
                    .Height = PIC_Y
                    .X = ItemsGFXInfo(Sprite).width / 2
                    .Width = PIC_X
                End With
            End If
        End If

        With dRECT
            .Y = 0
            .Height = PIC_Y
            .X = 0
            .Width = PIC_X
        End With

        TmpBankItem.Clear(ToSFMLColor(frmMainGame.pnlTempBank.BackColor))
        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        TmpBankItem.Draw(tmpSprite)

        With frmMainGame.pnlTempBank
            .Top = Y
            .Left = X
            .Visible = True
            .BringToFront()
        End With

        TmpBankItem.Display()

    End Sub
    Sub DrawTrade()
        Dim i As Long, X As Long, Y As Long, itemnum As Long, itempic As Long
        Dim Amount As String
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim colour As SFML.Graphics.Color

        Amount = 0

        If Not InGame Then Exit Sub
        colour = SFML.Graphics.Color.White
        YourTradeWindow.Clear(ToSFMLColor(frmMainGame.pnlYourTrade.BackColor))
        For i = 1 To MAX_INV
            ' blt your own offer
            itemnum = GetPlayerInvItemNum(MyIndex, TradeYourOffer(i).Num)

            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic

                If itempic > 0 And itempic <= NumItems Then
                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 32
                        .Width = 32
                    End With

                    With rec_pos
                        .Y = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                        .Height = PIC_Y
                        .X = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                        .Width = PIC_X
                    End With

                    Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                    tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                    YourTradeWindow.Draw(tmpSprite)

                    ' If item is a stack - draw the amount you have
                    If TradeYourOffer(i).Value > 1 Then
                        Y = rec_pos.Top + 22
                        X = rec_pos.Left - 4

                        ' Draw currency but with k, m, b etc. using a convertion function
                        If Amount < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf Amount > 1000000 And CLng(Amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf Amount > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If

                        Amount = CStr(TradeYourOffer(i).Value)
                        DrawText(X, Y, ConvertCurrency(Amount), colour, YourTradeWindow)
                    End If
                End If
            End If
        Next
        YourTradeWindow.Display()

        TheirTradeWindow.Clear(ToSFMLColor(frmMainGame.pnlTheirTrade.BackColor))
        For i = 1 To MAX_INV
            ' blt their offer
            itemnum = TradeTheirOffer(i).Num
            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic

                If itempic > 0 And itempic <= NumItems Then
                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 32
                        .Width = 32
                    End With

                    With rec_pos
                        .Y = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                        .Height = PIC_Y
                        .X = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                        .Width = PIC_X
                    End With

                    Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                    tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                    TheirTradeWindow.Draw(tmpSprite)

                    ' If item is a stack - draw the amount you have
                    If TradeTheirOffer(i).Value > 1 Then
                        Y = rec_pos.Top + 22
                        X = rec_pos.Left - 4

                        ' Draw currency but with k, m, b etc. using a convertion function
                        If Amount < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf Amount > 1000000 And CLng(Amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf Amount > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If

                        Amount = CStr(TradeTheirOffer(i).Value)
                        DrawText(X, Y, Amount, colour, TheirTradeWindow)
                    End If
                End If
            End If
        Next
        TheirTradeWindow.Display()
    End Sub
    Sub DrawPlayerSpells()
        Dim i As Long, spellnum As Long, spellicon As Long
        Dim rec As Rectangle, rec_pos As Rectangle

        If Not InGame Then Exit Sub
        SpellsWindow.Clear(ToSFMLColor(frmMainGame.pnlSpells.BackColor))
        For i = 1 To MAX_PLAYER_SPELLS
            spellnum = PlayerSpells(i)

            If spellnum > 0 And spellnum <= MAX_SPELLS Then
                spellicon = Spell(spellnum).Icon

                If spellicon > 0 And spellicon <= NumSpellIcons Then

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
                        .Width = 32
                    End With

                    If Not SpellCD(i) = 0 Then
                        rec.X = 32
                        rec.Width = 32
                    End If

                    With rec_pos
                        .Y = SpellTop + ((SpellOffsetY + 32) * ((i - 1) \ SpellColumns))
                        .Height = PIC_Y
                        .X = SpellLeft + ((SpellOffsetX + 32) * (((i - 1) Mod SpellColumns)))
                        .Width = PIC_X
                    End With

                    Dim tmpSprite As Sprite = New Sprite(SpellIconsGFX(spellicon))
                    tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                    SpellsWindow.Draw(tmpSprite)
                End If
            End If
        Next
        SpellsWindow.Display()
    End Sub

    Public Function ToSFMLColor(ToConvert As System.Drawing.Color) As SFML.Graphics.Color
        Return New SFML.Graphics.Color(ToConvert.R, ToConvert.G, ToConvert.G, ToConvert.A)
    End Function
End Module

