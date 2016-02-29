Imports SFML.Graphics
Imports System.Drawing
Imports System.Windows.Forms

Module ClientGraphics
    Public GameWindow As RenderWindow

    Public EditorMap_Item As RenderWindow
    Public EditorMap_Key As RenderWindow

    Public EditorItem_Item As RenderWindow
    Public EditorItem_Furniture As RenderWindow
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
    Public TmpSpellWindow As RenderWindow

    Public HotbarWindow As RenderWindow

    Public SFMLGameFont As SFML.Graphics.Font

    Public TileSetImgsGFX() As Bitmap
    Public TileSetImgsLoaded() As Boolean
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
    'Housing
    Public FurnitureGFX() As Texture
    Public FurnitureGFXInfo() As GraphicInfo

    Public DoorGFX As Texture
    Public DoorGFXInfo As GraphicInfo
    Public BloodGFX As Texture
    Public BloodGFXInfo As GraphicInfo
    Public DirectionsGfx As Texture
    Public DirectionsGFXInfo As GraphicInfo
    Public MiscGFX As Texture
    Public MiscGFXInfo As GraphicInfo

    Public HotBarGFX As Texture
    Public HotBarGFXInfo As GraphicInfo

    Public TextBB As Bitmap

    Public PanelGFX As Texture
    Public PanelGFXInfo As GraphicInfo

    Public InvPanelGFX As Texture
    Public InvPanelGFXInfo As GraphicInfo

    Public SpellPanelGFX As Texture
    Public SpellPanelGFXInfo As GraphicInfo

    Public CharPanelGFX As Texture
    Public CharPanelGFXInfo As GraphicInfo

    Public TargetGFX As Texture
    Public TargetGFXInfo As GraphicInfo

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
    Public NumFaces As Long

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
        Dim IsLoaded As Boolean
        Dim TextureTimer As Long
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
        EditorItem_Furniture = New RenderWindow(frmEditor_Item.picFurniture.Handle)

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
        TmpSpellWindow = New RenderWindow(frmMainGame.pnlTmpSkill.Handle)

        HotbarWindow = New RenderWindow(frmMainGame.pnlHotBar.Handle)

        SFMLGameFont = New SFML.Graphics.Font(FONT_NAME)

        TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "misc" & GFX_EXT)

        StatBarBackbuffer = New Bitmap(frmMainGame.picGeneral.Width, frmMainGame.picGeneral.Height, Imaging.PixelFormat.Format32bppPArgb)

        ReDim TileSetImgsGFX(0 To NumTileSets)
        ReDim TileSetTexture(0 To NumTileSets)
        ReDim TileSetTextureInfo(0 To NumTileSets)

        'For i = 1 To NumTileSets
        'TileSetImgsGFX(i) = New Bitmap(Application.StartupPath & GFX_PATH & "tilesets\" & i & GFX_EXT)

        'Load texture first, dont care about memory streams (just use the filename)
        'TileSetTexture(i) = New Texture(Application.StartupPath & GFX_PATH & "tilesets\" & i & GFX_EXT)

        'Cache the width and height
        'TileSetTextureInfo(i).width = TileSetTexture(i).Size.X
        'TileSetTextureInfo(i).height = TileSetTexture(i).Size.Y
        'Next


        ReDim SpritesGFX(0 To NumCharacters)
        ReDim SpritesGFXInfo(0 To NumCharacters)
        'For i = 1 To NumCharacters
        'Load texture first, dont care about memory streams (just use the filename)
        'SpritesGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "characters\" & i & GFX_EXT)

        'Cache the width and height
        'SpritesGFXInfo(i).width = SpritesGFX(i).Size.X
        'SpritesGFXInfo(i).height = SpritesGFX(i).Size.Y
        'Next

        ReDim PaperDollGFX(0 To NumPaperdolls)
        ReDim PaperDollGFXInfo(0 To NumPaperdolls)
        'For i = 1 To NumPaperdolls
        'Load texture first, dont care about memory streams (just use the filename)
        'PaperDollGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "Paperdolls\" & i & GFX_EXT)

        'Cache the width and height
        'PaperDollGFXInfo(i).width = PaperDollGFX(i).Size.X
        'PaperDollGFXInfo(i).height = PaperDollGFX(i).Size.Y
        'Next

        ReDim ItemsGFX(0 To NumItems)
        ReDim ItemsGFXInfo(0 To NumItems)
        'For i = 1 To NumItems
        'Load texture first, dont care about memory streams (just use the filename)
        'ItemsGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "items\" & i & GFX_EXT)

        'Cache the width and height
        'ItemsGFXInfo(i).width = ItemsGFX(i).Size.X
        'ItemsGFXInfo(i).height = ItemsGFX(i).Size.Y
        'Next

        ReDim ResourcesGFX(0 To NumResources)
        ReDim ResourcesGFXInfo(0 To NumResources)
        For i = 1 To NumResources
            'Load texture first, dont care about memory streams (just use the filename)
            ResourcesGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "resources\" & i & GFX_EXT)

            'Cache the width and height
            ResourcesGFXInfo(i).width = ResourcesGFX(i).Size.X
            ResourcesGFXInfo(i).height = ResourcesGFX(i).Size.Y

        Next

        ReDim AnimationsGFX(0 To NumAnimations)
        ReDim AnimationsGFXInfo(0 To NumAnimations)
        For i = 1 To NumAnimations
            'Load texture first, dont care about memory streams (just use the filename)
            AnimationsGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "animations\" & i & GFX_EXT)

            'Cache the width and height
            AnimationsGFXInfo(i).width = AnimationsGFX(i).Size.X
            AnimationsGFXInfo(i).height = AnimationsGFX(i).Size.Y

        Next

        ReDim SpellIconsGFX(0 To NumSpellIcons)
        ReDim SpellIconsGFXInfo(0 To NumSpellIcons)
        For i = 1 To NumSpellIcons
            'Load texture first, dont care about memory streams (just use the filename)
            SpellIconsGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "spellicons\" & i & GFX_EXT)

            'Cache the width and height
            SpellIconsGFXInfo(i).width = SpellIconsGFX(i).Size.X
            SpellIconsGFXInfo(i).height = SpellIconsGFX(i).Size.Y

        Next

        'Housing
        ReDim FurnitureGFX(0 To NumFurniture)
        ReDim FurnitureGFXInfo(0 To NumFurniture)
        For i = 1 To NumFurniture
            'Load texture first, dont care about memory streams (just use the filename)
            FurnitureGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "Furniture\" & i & GFX_EXT)

            'Cache the width and height
            FurnitureGFXInfo(i).width = FurnitureGFX(i).Size.X
            FurnitureGFXInfo(i).height = FurnitureGFX(i).Size.Y

        Next

        DoorGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "door" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            DoorGFX = New Texture(Application.StartupPath & GFX_PATH & "door" & GFX_EXT)

            'Cache the width and height
            DoorGFXInfo.width = DoorGFX.Size.X
            DoorGFXInfo.height = DoorGFX.Size.Y

        End If

        BloodGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "blood" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            BloodGFX = New Texture(Application.StartupPath & GFX_PATH & "blood" & GFX_EXT)

            'Cache the width and height
            BloodGFXInfo.width = BloodGFX.Size.X
            BloodGFXInfo.height = BloodGFX.Size.Y

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

        PanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\panel" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            PanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\panel" & GFX_EXT)

            'Cache the width and height
            PanelGFXInfo.width = PanelGFX.Size.X
            PanelGFXInfo.height = PanelGFX.Size.Y

        End If

        InvPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\inventory" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            InvPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\inventory" & GFX_EXT)

            'Cache the width and height
            InvPanelGFXInfo.width = PanelGFX.Size.X
            InvPanelGFXInfo.height = PanelGFX.Size.Y

        End If

        SpellPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\spells" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            SpellPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\spells" & GFX_EXT)

            'Cache the width and height
            SpellPanelGFXInfo.width = PanelGFX.Size.X
            SpellPanelGFXInfo.height = PanelGFX.Size.Y

        End If

        CharPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\char" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CharPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\char" & GFX_EXT)

            'Cache the width and height
            CharPanelGFXInfo.width = PanelGFX.Size.X
            CharPanelGFXInfo.height = PanelGFX.Size.Y

        End If

        TargetGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "target" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            TargetGFX = New Texture(Application.StartupPath & GFX_PATH & "target" & GFX_EXT)

            'Cache the width and height
            TargetGFXInfo.width = TargetGFX.Size.X
            TargetGFXInfo.height = TargetGFX.Size.Y

        End If

        HotBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\HotBar" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            HotBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\HotBar" & GFX_EXT)

            'Cache the width and height
            HotBarGFXInfo.width = HotBarGFX.Size.X
            HotBarGFXInfo.height = HotBarGFX.Size.Y

        End If

        HPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\HPBar" & GFX_EXT)
        ManaBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\manaBar" & GFX_EXT)
        EXPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\expBar" & GFX_EXT)
        EmptyHPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\HPBarEmpty" & GFX_EXT)
        EmptyManaBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\ManaBarEmpty" & GFX_EXT)
        EmptyEXPBar = New Bitmap(Application.StartupPath & GFX_PATH & "GUI\ExpBarEmpty" & GFX_EXT)

    End Sub

    Public Sub LoadTexture(ByVal Index As Long, ByVal TexType As Byte)

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
            SpritesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "characters\" & Index & GFX_EXT)

            'Cache the width and height
            With SpritesGFXInfo(Index)
                .width = SpritesGFX(Index).Size.X
                .height = SpritesGFX(Index).Size.Y
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
            If Index < 0 Or Index > NumItems Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ItemsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "items\" & Index & GFX_EXT)

            'Cache the width and height
            With ItemsGFXInfo(Index)
                .width = ItemsGFX(Index).Size.X
                .height = ItemsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        End If

    End Sub

    Public Sub DrawDirections(ByVal X As Long, ByVal Y As Long)
        Dim rec As Rectangle
        Dim i As Long
        Dim tmpSprite As Sprite = New Sprite(DirectionsGfx)

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
            If Not isDirBlocked(Map.Tile(X, Y).DirBlock, (i)) Then
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

    Public Sub DrawFace(ByVal Index As Long)
        If FileExist(Application.StartupPath & GFX_PATH & "Faces\" & Index & GFX_EXT) Then
            frmMainGame.picFace.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "Faces\" & Index & GFX_EXT)
        End If
    End Sub

    Public Sub DrawPlayer(ByVal Index As Long)
        Dim Anim As Byte, X As Long, Y As Long
        Dim Spritenum As Long, spriteleft As Long
        Dim attackspeed As Long, AttackSprite As Byte
        Dim srcrec As Rectangle

        Spritenum = GetPlayerSprite(Index)

        AttackSprite = 0

        If Spritenum < 1 Or Spritenum > NumCharacters Then Exit Sub

        ' speed from weapon
        If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
            attackspeed = Item(GetPlayerEquipment(Index, Equipment.Weapon)).Speed
        Else
            attackspeed = 1000
        End If

        ' Reset frame
        Anim = 0

        ' Check for attacking animation
        If Player(Index).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If Player(Index).Attacking = 1 Then
                If AttackSprite = 1 Then
                    Anim = 4
                Else
                    Anim = 3
                End If
            End If
        Else
            ' If not attacking, walk normally
            Select Case GetPlayerDir(Index)
                Case DIR_UP

                    If (Player(Index).YOffset > 8) Then Anim = Player(Index).Steps
                Case DIR_DOWN

                    If (Player(Index).YOffset < -8) Then Anim = Player(Index).Steps
                Case DIR_LEFT

                    If (Player(Index).XOffset > 8) Then Anim = Player(Index).Steps
                Case DIR_RIGHT

                    If (Player(Index).XOffset < -8) Then Anim = Player(Index).Steps
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

        If AttackSprite = 1 Then
            srcrec = New Rectangle((Anim) * (SpritesGFXInfo(Spritenum).width / 5), spriteleft * (SpritesGFXInfo(Spritenum).height / 4), (SpritesGFXInfo(Spritenum).width / 5), (SpritesGFXInfo(Spritenum).height / 4))
        Else
            srcrec = New Rectangle((Anim) * (SpritesGFXInfo(Spritenum).width / 4), spriteleft * (SpritesGFXInfo(Spritenum).height / 4), (SpritesGFXInfo(Spritenum).width / 4), (SpritesGFXInfo(Spritenum).height / 4))
        End If

        ' Calculate the X
        If AttackSprite = 1 Then
            X = GetPlayerX(Index) * PIC_X + Player(Index).XOffset - ((SpritesGFXInfo(Spritenum).width / 5 - 32) / 2)
        Else
            X = GetPlayerX(Index) * PIC_X + Player(Index).XOffset - ((SpritesGFXInfo(Spritenum).width / 4 - 32) / 2)
        End If

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
                    Call DrawPaperdoll(X, Y, Item(GetPlayerEquipment(Index, i)).Paperdoll, Anim, spriteleft)
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

        If PaperDollGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 3)
        End If

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
        anim = 0

        ' Check for attacking animation
        If MapNpc(MapNpcNum).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If MapNpc(MapNpcNum).Attacking = 1 Then
                anim = 3
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

        If ItemsGFXInfo(PicNum).IsLoaded = False Then
            LoadTexture(PicNum, 2)
        End If

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

        If SpritesGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 2)
        End If

        'seeying we still use it, lets update timer
        With SpritesGFXInfo(Sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

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
                If .Layer(i).tileset > 0 And .Layer(i).tileset <= NumTileSets Then
                    If TileSetTextureInfo(.Layer(i).tileset).IsLoaded = False Then
                        LoadTexture(.Layer(i).tileset, 1)
                    End If
                    If Autotile(X, Y).Layer(i).renderState = RENDER_STATE_NORMAL Then
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

        'With Map.exTile(X, Y)
        '    For i = ExMapLayer.Mask3 To ExMapLayer.Mask5
        '        If .Layer(i).tileset > 0 Then
        '            If Autotile(X, Y).ExLayer(i).renderState = RENDER_STATE_NORMAL Then
        '                With srcrect
        '                    .X = Map.Tile(X, Y).Layer(i).X * 32
        '                    .Y = Map.Tile(X, Y).Layer(i).Y * 32
        '                    .Width = 32
        '                    .Height = 32
        '                End With
        '                tmpSprite = New Sprite(TileSetTexture(.Layer(i).tileset))
        '                tmpSprite.TextureRect = New IntRect(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)
        '                tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y))
        '                GameWindow.Draw(tmpSprite)
        '            ElseIf Autotile(X, Y).ExLayer(i).renderState = RENDER_STATE_AUTOTILE Then
        '                ' Draw autotiles
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), 1, X, Y, 0, False)
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y), 2, X, Y, 0, False)
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y) + 16, 3, X, Y, 0, False)
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y) + 16, 4, X, Y, 0, False)
        '            End If
        '        End If
        '    Next
        'End With
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
                    If TileSetTextureInfo(.Layer(i).tileset).IsLoaded = False Then
                        LoadTexture(.Layer(i).tileset, 1)
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
                        tmpSprite = New Sprite(TileSetTexture(.Layer(i).tileset))
                        tmpSprite.TextureRect = New IntRect(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)
                        tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y))
                        GameWindow.Draw(tmpSprite)

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

        'With Map.exTile(X, Y)
        '    For i = ExMapLayer.Fringe3 To ExMapLayer.Fringe5
        '        If .Layer(i).tileset > 0 Then
        '            If Autotile(X, Y).ExLayer(i).renderState = RENDER_STATE_NORMAL Then
        '                With srcrect
        '                    .X = Map.Tile(X, Y).Layer(i).X * 32
        '                    .Y = Map.Tile(X, Y).Layer(i).Y * 32
        '                    .Width = 32
        '                    .Height = 32
        '                End With
        '                tmpSprite = New Sprite(TileSetTexture(.Layer(i).tileset))
        '                tmpSprite.TextureRect = New IntRect(srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)
        '                tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y))
        '                GameWindow.Draw(tmpSprite)
        '            ElseIf Autotile(X, Y).ExLayer(i).renderState = RENDER_STATE_AUTOTILE Then
        '                ' Draw autotiles
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), 1, X, Y, 0, False)
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y), 2, X, Y, 0, False)
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y) + 16, 3, X, Y, 0, False)
        '                DrawAutoTile(i, ConvertMapX(X * PIC_X) + 16, ConvertMapY(Y * PIC_Y) + 16, 4, X, Y, 0, False)
        '            End If
        '        End If
        '    Next
        'End With
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
        Dim X As Long, Y As Long, I As Long

        'Don't Render IF
        If frmMainGame.WindowState = FormWindowState.Minimized Then Exit Sub
        If GettingMap Then Exit Sub

        UpdateCamera()

        DoEvents()

        'Clear each of our render targets
        GameWindow.DispatchEvents()
        GameWindow.Clear(SFML.Graphics.Color.Black)

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
            If SpritesGFXInfo(I).IsLoaded Then
                If SpritesGFXInfo(I).TextureTimer < GetTickCount() Then
                    SpritesGFX(I).Dispose()
                    SpritesGFXInfo(I).IsLoaded = False
                    SpritesGFXInfo(I).TextureTimer = 0
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

        ' update animation editor
        If Editor = EDITOR_ANIMATION Then
            EditorAnim_DrawAnim()
        End If

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

        ' Furniture
        If FurnitureHouse > 0 Then
            If FurnitureHouse = Player(MyIndex).InHouse Then
                If FurnitureCount > 0 Then
                    For I = 1 To FurnitureCount
                        If Furniture(I).ItemNum > 0 Then
                            DrawFurniture(I, 0)
                        End If
                    Next
                End If
            End If
        End If

        If Map.CurrentEvents > 0 And Map.CurrentEvents <= Map.EventCount Then

            For I = 1 To Map.CurrentEvents
                If Map.MapEvents(I).Position = 0 Then
                    DrawEvent(I)
                End If
            Next
        End If

        For I = 1 To MAX_BYTE
            DrawBlood(I)
        Next

        ' Draw out the items
        If NumItems > 0 Then
            For I = 1 To MAX_MAP_ITEMS

                If MapItem(I).Num > 0 Then
                    DrawItem(I)
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
            For I = 1 To MAX_BYTE
                If AnimInstance(I).Used(0) Then
                    DrawAnimation(I, 0)
                End If
            Next
        End If

        ' Y-based render. Renders Players, Npcs and Resources based on Y-axis.
        For Y = 0 To Map.MaxY

            If NumCharacters > 0 Then
                ' Players
                For I = 1 To MAX_PLAYERS
                    If IsPlaying(I) And GetPlayerMap(I) = GetPlayerMap(MyIndex) Then
                        If Player(I).Y = Y Then
                            DrawPlayer(I)
                        End If
                    End If
                Next

                ' Npcs
                For I = 1 To MAX_MAP_NPCS
                    If MapNpc(I).Y = Y Then
                        DrawNpc(I)
                    End If
                Next

                If Map.CurrentEvents > 0 And Map.CurrentEvents <= Map.EventCount Then

                    For I = 1 To Map.CurrentEvents
                        If Map.MapEvents(I).Position = 1 Then
                            If Y = Map.MapEvents(I).Y Then
                                DrawEvent(I)
                            End If
                        End If
                    Next
                End If

                ' Draw the target icon
                If myTarget > 0 Then
                    If myTargetType = TARGET_TYPE_PLAYER Then
                        DrawTarget(Player(myTarget).X * 32 - 16 + Player(myTarget).XOffset, Player(myTarget).Y * 32 + Player(myTarget).YOffset)
                    ElseIf myTargetType = TARGET_TYPE_NPC Then
                        DrawTarget(MapNpc(myTarget).X * 32 - 16 + MapNpc(myTarget).XOffset, MapNpc(myTarget).Y * 32 + MapNpc(myTarget).YOffset)
                    End If
                End If

                For I = 1 To MAX_PLAYERS
                    If IsPlaying(I) Then
                        If Player(I).Map = Player(MyIndex).Map Then
                            If CurX = Player(I).X And CurY = Player(I).Y Then
                                If myTargetType = TARGET_TYPE_PLAYER And myTarget = I Then
                                    ' dont render lol
                                Else
                                    DrawHover(Player(I).X * 32 - 16, Player(I).Y * 32 + Player(I).YOffset)
                                End If
                            End If

                        End If
                    End If
                Next
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

        ' animations
        If NumAnimations > 0 Then
            For I = 1 To MAX_BYTE
                If AnimInstance(I - 1).Used(1) Then
                    DrawAnimation(I - 1, 1)
                End If
            Next
        End If

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

        ' Furniture
        If FurnitureHouse > 0 Then
            If FurnitureHouse = Player(MyIndex).InHouse Then
                If FurnitureCount > 0 Then
                    For I = 1 To FurnitureCount
                        If Furniture(I).ItemNum > 0 Then
                            DrawFurniture(I, 1)
                        End If
                    Next
                End If
            End If
        End If



        ' Draw out a square at mouse cursor
        If InMapEditor Then
            If frmEditor_Map.optBlocks.Checked = True Then
                For X = TileView.left To TileView.right
                    For Y = TileView.top To TileView.bottom
                        If IsValidMapPoint(X, Y) Then
                            DrawDirections(X, Y)
                        End If
                    Next
                Next
            End If
            DrawTileOutline()
        End If

        If FurnitureSelected > 0 Then
            If Player(MyIndex).InHouse = MyIndex Then
                DrawFurnitureOutline()
            End If
        End If

        ' draw cursor, player X and Y locations
        If BLoc Then
            If frmMainGame.picGeneral.Visible = True Then
                DrawText(1, frmMainGame.picGeneral.Top + frmMainGame.picGeneral.Height + 1, Trim$("cur x: " & CurX & " y: " & CurY), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
                DrawText(1, frmMainGame.picGeneral.Top + frmMainGame.picGeneral.Height + 15, Trim$("loc x: " & GetPlayerX(MyIndex) & " y: " & GetPlayerY(MyIndex)), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
                DrawText(1, frmMainGame.picGeneral.Top + frmMainGame.picGeneral.Height + 30, Trim$(" (map #" & GetPlayerMap(MyIndex) & ")"), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
            Else
                DrawText(1, 1, Trim$("cur x: " & CurX & " y: " & CurY), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
                DrawText(1, 15, Trim$("loc x: " & GetPlayerX(MyIndex) & " y: " & GetPlayerY(MyIndex)), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
                DrawText(1, 30, Trim$(" (map #" & GetPlayerMap(MyIndex) & ")"), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
            End If

        End If

        ' draw player names
        For I = 1 To MAX_PLAYERS
            If IsPlaying(I) And GetPlayerMap(I) = GetPlayerMap(MyIndex) Then
                DrawPlayerName(I)
            End If
        Next

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

        For I = 1 To MAX_BYTE
            DrawActionMsg(I)
        Next I

        ' Blit out map attributes
        If InMapEditor Then
            DrawMapAttributes()
        End If

        If InMapEditor And frmEditor_Map.optEvent.Checked = True Then DrawEvents()

        ' Draw map name
        DrawMapName()

        GameWindow.Display()

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
        DrawText(DrawMapNameX, DrawMapNameY, Map.Name, DrawMapNameColor, SFML.Graphics.Color.Black, GameWindow)
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

    Public Sub DrawFurnitureOutline()
        Dim rec As Rectangle

        If InMapEditor Then Exit Sub

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

        'Draw the tileset into memory.)
        height = TileSetImgsGFX(tileset).Height
        width = TileSetImgsGFX(tileset).Width
        MapEditorBackBuffer = New Bitmap(width, height)

        Dim g As Graphics = Graphics.FromImage(MapEditorBackBuffer)
        g.FillRectangle(Brushes.Black, New Rectangle(0, 0, MapEditorBackBuffer.Width, MapEditorBackBuffer.Height))

        frmEditor_Map.picBackSelect.Height = height
        frmEditor_Map.picBackSelect.Width = width

        ' change selected shape for autotiles
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

        g.DrawImage(TileSetImgsGFX(tileset), New Rectangle(0, 0, TileSetImgsGFX(tileset).Width, TileSetImgsGFX(tileset).Height))
        g.DrawRectangle(Pens.Red, New Rectangle(EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, EditorTileWidth * PIC_X, EditorTileHeight * PIC_X))
        g.Dispose()

        g = frmEditor_Map.picBackSelect.CreateGraphics
        g.DrawImage(MapEditorBackBuffer, New Rectangle(0, 0, width, height))
        g.Dispose()

        LastTileset = tileset
    End Sub

    Sub DestroyGraphics()

        ' Number of graphic files
        If Not StatBarBackbuffer Is Nothing Then StatBarBackbuffer.Dispose()
        If Not MapEditorBackBuffer Is Nothing Then MapEditorBackBuffer.Dispose()

        If Not TempBitmap Is Nothing Then TempBitmap.Dispose()
        If Not TempBitmap1 Is Nothing Then TempBitmap1.Dispose()

        For i = 0 To NumAnimations
            If Not AnimationsGFX(i) Is Nothing Then AnimationsGFX(i).Dispose()
        Next i

        For i = 0 To NumCharacters
            If Not SpritesGFX(i) Is Nothing Then SpritesGFX(i).Dispose()
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

        For i = 0 To NumSpellIcons
            If Not SpellIconsGFX(i) Is Nothing Then SpellIconsGFX(i).Dispose()
        Next

        For i = 0 To NumTileSets
            If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
            If Not TileSetTexture(i) Is Nothing Then TileSetTexture(i).Dispose()
        Next i

        For i = 0 To NumFurniture
            If Not FurnitureGFX(i) Is Nothing Then FurnitureGFX(i).Dispose()
        Next

        If Not DoorGFX Is Nothing Then DoorGFX.Dispose()
        If Not BloodGFX Is Nothing Then BloodGFX.Dispose()
        If Not DirectionsGfx Is Nothing Then DirectionsGfx.Dispose()
        If Not MiscGFX Is Nothing Then MiscGFX.Dispose()
        If Not PanelGFX Is Nothing Then PanelGFX.Dispose()
        If Not TargetGFX Is Nothing Then TargetGFX.Dispose()
        If Not HotBarGFX Is Nothing Then HotBarGFX.Dispose()

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

        ' rect for source
        sRECT.Y = 0
        sRECT.Height = FurnitureGFXInfo(Furniturenum).height
        sRECT.X = 0
        sRECT.Width = FurnitureGFXInfo(Furniturenum).width

        ' same for destination as source
        dRECT = sRECT
        EditorItem_Furniture.Clear(ToSFMLColor(frmEditor_Item.picFurniture.BackColor))
        Dim tmpSprite As Sprite = New Sprite(FurnitureGFX(Furniturenum))
        tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        tmpSprite.Position = New SFML.System.Vector2f(dRECT.X, dRECT.Y)
        EditorItem_Furniture.Draw(tmpSprite)

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
        sRECT.Height = SIZE_Y * 2
        sRECT.X = 0 ' facing down
        sRECT.Width = SIZE_X
        dRECT.Y = 0
        dRECT.Height = SIZE_Y * 2
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
        Dim rec As Rectangle, rec2 As Rectangle, rec_pos As Rectangle
        Dim tmpSprite2 As Sprite = New Sprite(CharPanelGFX)
        If NumItems = 0 Then Exit Sub

        EquipmentWindow.Clear(ToSFMLColor(frmMainGame.pnlCharacter.BackColor))

        With rec2
            .Y = 0
            .Height = frmMainGame.pnlCharacter.Height
            .X = 0
            .Width = frmMainGame.pnlCharacter.Width
        End With

        tmpSprite2.TextureRect = New IntRect(rec2.X, rec2.Y, rec2.Width, rec2.Height)
        tmpSprite2.Position = New SFML.System.Vector2f(0, 0)
        EquipmentWindow.Draw(tmpSprite2)

        For i = 1 To Equipment.Equipment_Count - 1
            itemnum = GetPlayerEquipment(MyIndex, i)

            If itemnum > 0 Then

                itempic = Item(itemnum).Pic

                If ItemsGFXInfo(itempic).IsLoaded = False Then
                    LoadTexture(itempic, 2)
                End If

                With rec
                    .Y = 0
                    .Height = 32
                    .X = 0
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

            If ItemsGFXInfo(itempic).IsLoaded = False Then
                LoadTexture(itempic, 4)
            End If

            With rec
                .Y = 0
                .Height = PIC_Y
                .X = 0
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
        Dim rec As Rectangle, rec2 As Rectangle, rec_pos As Rectangle
        Dim colour As SFML.Graphics.Color
        Dim tmpSprite2 As Sprite = New Sprite(InvPanelGFX)

        If Not InGame Then Exit Sub
        InventoryWindow.Clear(ToSFMLColor(frmMainGame.pnlInventory.BackColor))

        With rec2
            .Y = 0
            .Height = frmMainGame.pnlInventory.Height
            .X = 0
            .Width = frmMainGame.pnlInventory.Width
        End With

        tmpSprite2.TextureRect = New IntRect(rec2.X, rec2.Y, rec2.Width, rec2.Height)
        tmpSprite2.Position = New SFML.System.Vector2f(0, 0)
        InventoryWindow.Draw(tmpSprite2)

        For i = 1 To MAX_INV
            itemnum = GetPlayerInvItemNum(MyIndex, i)

            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic = 0 Then GoTo NextLoop

                If ItemsGFXInfo(itempic).IsLoaded = False Then
                    LoadTexture(itempic, 4)
                End If

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
                            .X = 0
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
                            Amount = GetPlayerInvItemValue(MyIndex, i)

                            colour = SFML.Graphics.Color.White

                            ' Draw currency but with k, m, b etc. using a convertion function
                            If CLng(Amount) < 1000000 Then
                                colour = SFML.Graphics.Color.White
                            ElseIf CLng(Amount) > 1000000 And CLng(Amount) < 10000000 Then
                                colour = SFML.Graphics.Color.Yellow
                            ElseIf CLng(Amount) > 10000000 Then
                                colour = SFML.Graphics.Color.Green
                            End If

                            DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, InventoryWindow)

                            ' Check if it's gold, and update the label
                            If GetPlayerInvItemNum(MyIndex, i) = 1 Then '1 = gold :P
                                frmMainGame.lblGold.Text = Format(CLng(Amount), "#,###,###,###")
                            End If
                        End If
                    End If
                End If
            End If
NextLoop:
        Next

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
                            DrawText(X, Y, ConvertCurrency(Amount), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, InventoryWindow)
                            ' Check if it's gold, and update the label
                            If GetPlayerInvItemNum(MyIndex, i) = 1 Then '1 = gold :P
                                frmMainGame.lblGold.Text = Format(Amount, "#,###,###,###")
                            End If
                        End If
                    End If
                End If
            End If

        Next
    End Sub

    Public Sub DrawSpellItem(ByVal X As Long, ByVal Y As Long)
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim spellnum As Long, spellpic As Long

        spellnum = DragSpellSlotNum
        TmpSpellWindow.Clear(ToSFMLColor(frmMainGame.pnlTmpSkill.BackColor))
        If spellnum > 0 And spellnum <= MAX_SPELLS Then
            spellpic = Spell(spellnum).Icon
            If spellpic = 0 Then Exit Sub

            With rec
                .Y = 0
                .Height = PIC_Y
                .X = 0
                .Width = PIC_X
            End With

            With rec_pos
                .Y = 0
                .Height = PIC_Y
                .X = 0
                .Width = PIC_X
            End With

            Dim tmpSprite As Sprite = New Sprite(SpellIconsGFX(spellpic))
            tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
            tmpSprite.Position = New SFML.System.Vector2f(0, 0)
            TmpSpellWindow.Draw(tmpSprite)

            With frmMainGame.pnlTmpSkill
                .Top = Y
                .Left = X
                .Visible = True
                .BringToFront()
            End With

        End If
        TmpSpellWindow.Display()

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
                        Amount = Shop(InShop).TradeItem(i).ItemValue
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

                    If ItemsGFXInfo(Sprite).IsLoaded = False Then
                        LoadTexture(Sprite, 4)
                    End If

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

                        Amount = GetBankItemValue(i)
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
                        DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, BankWindow)
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

        If itemnum > 0 And itemnum <= MAX_ITEMS Then

            If ItemsGFXInfo(Sprite).IsLoaded = False Then
                LoadTexture(Sprite, 4)
            End If

            With sRECT
                .Y = 0
                .Height = PIC_Y
                .X = ItemsGFXInfo(Sprite).width / 2
                .Width = PIC_X
            End With
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

                        Amount = TradeYourOffer(i).Value
                        DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, YourTradeWindow)
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

                        Amount = TradeTheirOffer(i).Value
                        DrawText(X, Y, Amount, colour, SFML.Graphics.Color.Black, TheirTradeWindow)
                    End If
                End If
            End If
        Next
        TheirTradeWindow.Display()
    End Sub

    Sub DrawPlayerSpells()
        Dim i As Long, spellnum As Long, spellicon As Long
        Dim rec As Rectangle, rec2 As Rectangle, rec_pos As Rectangle
        Dim tmpSprite2 As Sprite = New Sprite(SpellPanelGFX)

        If Not InGame Then Exit Sub
        SpellsWindow.Clear(ToSFMLColor(frmMainGame.pnlSpells.BackColor))

        With rec2
            .Y = 0
            .Height = frmMainGame.pnlSpells.Height
            .X = 0
            .Width = frmMainGame.pnlSpells.Width
        End With

        tmpSprite2.TextureRect = New IntRect(rec2.X, rec2.Y, rec2.Width, rec2.Height)
        tmpSprite2.Position = New SFML.System.Vector2f(0, 0)
        SpellsWindow.Draw(tmpSprite2)

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

    Public Function ToSFMLColor(ToConvert As Drawing.Color) As SFML.Graphics.Color
        Return New SFML.Graphics.Color(ToConvert.R, ToConvert.G, ToConvert.G, ToConvert.A)
    End Function

    Public Sub DrawTarget(ByVal X2 As Long, ByVal Y2 As Long)
        Dim rec As Rectangle
        Dim X As Long, y As Long
        Dim width As Long, height As Long

        With rec
            .Y = 0
            .Height = TargetGFXInfo.height
            .X = 0
            .Width = TargetGFXInfo.width / 2
        End With

        X = ConvertMapX(X2)
        y = ConvertMapY(Y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        Dim tmpSprite As Sprite = New Sprite(TargetGFX)
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(X, y)
        GameWindow.Draw(tmpSprite)

    End Sub

    Public Sub DrawHover(ByVal X2 As Long, ByVal Y2 As Long)
        Dim rec As Rectangle
        Dim X As Long, Y As Long
        Dim width As Long, height As Long

        With rec
            .Y = 0
            .Height = TargetGFXInfo.height
            .X = TargetGFXInfo.width / 2
            .Width = TargetGFXInfo.width / 2 + TargetGFXInfo.width / 2
        End With

        X = ConvertMapX(X2)
        Y = ConvertMapY(Y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        Dim tmpSprite As Sprite = New Sprite(TargetGFX)
        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        tmpSprite.Position = New SFML.System.Vector2f(X, Y)
        GameWindow.Draw(tmpSprite)

    End Sub

    Public Sub LoadGuiGraphics()

        'main menu
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\menu" & GFX_EXT) Then
            frmMenu.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\menu" & GFX_EXT)
        End If

        'main menu buttons
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnCredits" & GFX_EXT) Then
            frmMenu.btnCredits.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnCredits" & GFX_EXT)
        End If
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnExit" & GFX_EXT) Then
            frmMenu.btnExit.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnExit" & GFX_EXT)
        End If
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnLogin" & GFX_EXT) Then
            frmMenu.btnLogin.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnLogin" & GFX_EXT)
        End If
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnRegister" & GFX_EXT) Then
            frmMenu.btnRegister.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnRegister" & GFX_EXT)
        End If

        'main game
        frmMainGame.picInventory.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Inventory" & GFX_EXT
        frmMainGame.picSkills.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Skills" & GFX_EXT
        frmMainGame.picCharacter.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Character" & GFX_EXT
        frmMainGame.picTrade.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Trade" & GFX_EXT
        frmMainGame.picOptions.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Options" & GFX_EXT
        frmMainGame.picExit.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Exit" & GFX_EXT
        frmMainGame.picQuest.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Quest" & GFX_EXT
        If FileExist(Application.StartupPath & GFX_PATH & "Gui\Main\main" & GFX_EXT) Then
            frmMenu.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Main\main" & GFX_EXT)
        End If

    End Sub


End Module

