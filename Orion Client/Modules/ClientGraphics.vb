Imports SFML.Graphics
Imports System.Drawing
Imports System.Windows.Forms

Module ClientGraphics
    Public GameWindow As RenderWindow

    Public EditorItem_Furniture As RenderWindow

    Public EditorSpell_Icon As RenderWindow

    Public EditorAnimation_Anim1 As RenderWindow
    Public EditorAnimation_Anim2 As RenderWindow

    Public TmpItemWindow As RenderWindow

    Public ShopWindow As RenderWindow

    Public BankWindow As RenderWindow
    Public TmpBankItem As RenderWindow

    Public YourTradeWindow As RenderWindow
    Public TheirTradeWindow As RenderWindow

    Public TmpSpellWindow As RenderWindow

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
    'Faces
    Public FacesGFX() As Texture
    Public FacesGFXInfo() As GraphicInfo

    Public ProjectileGFX() As Texture
    Public ProjectileGFXInfo() As GraphicInfo

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

    Public ChatWindow As Texture
    Public ChatWindowInfo As GraphicInfo

    Public TextBB As Bitmap

    Public HUDPanelGFX As Texture
    Public HUDPanelGFXInfo As GraphicInfo

    Public ActionPanelGFX As Texture
    Public ActionPanelGFXInfo As GraphicInfo
    Public ActionPanelButtonsGFX(8) As Texture
    Public ActionPanelButtonGFXInfo(8) As GraphicInfo

    Public InvPanelGFX As Texture
    Public InvPanelGFXInfo As GraphicInfo

    Public SpellPanelGFX As Texture
    Public SpellPanelGFXInfo As GraphicInfo

    Public CharPanelGFX As Texture
    Public CharPanelGFXInfo As GraphicInfo
    Public CharPanelPlusGFX As Texture
    Public CharPanelPlusGFXInfo As GraphicInfo

    Public TargetGFX As Texture
    Public TargetGFXInfo As GraphicInfo

    ' Number of graphic files
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

    Public HPBarGFX As Texture
    Public HPBarGFXInfo As GraphicInfo
    Public EmptyHPBarGFX As Texture
    Public EmptyHPBarGFXInfo As GraphicInfo

    Public MPBarGFX As Texture
    Public MPBarGFXInfo As GraphicInfo
    Public EmptyMPBarGFX As Texture
    Public EmptyMPBarGFXInfo As GraphicInfo

    Public EXPBarGFX As Texture
    Public EXPBarGFXInfo As GraphicInfo
    Public EmptyEXPBarGFX As Texture
    Public EmptyEXPBarGFXInfo As GraphicInfo
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

        EditorItem_Furniture = New RenderWindow(frmEditor_Item.picFurniture.Handle)

        EditorSpell_Icon = New RenderWindow(frmEditor_Spell.picSprite.Handle)

        EditorAnimation_Anim1 = New RenderWindow(frmEditor_Animation.picSprite0.Handle)
        EditorAnimation_Anim2 = New RenderWindow(frmEditor_Animation.picSprite1.Handle)

        TmpItemWindow = New RenderWindow(frmMainGame.pnlTmpInv.Handle)

        ShopWindow = New RenderWindow(frmMainGame.pnlShopItems.Handle)

        BankWindow = New RenderWindow(frmMainGame.pnlBank.Handle)
        frmMainGame.pnlBank.Hide()
        TmpBankItem = New RenderWindow(frmMainGame.pnlTempBank.Handle)

        YourTradeWindow = New RenderWindow(frmMainGame.pnlYourTrade.Handle)
        TheirTradeWindow = New RenderWindow(frmMainGame.pnlTheirTrade.Handle)

        TmpSpellWindow = New RenderWindow(frmMainGame.pnlTmpSkill.Handle)

        SFMLGameFont = New SFML.Graphics.Font(FONT_NAME)

        TempBitmap = New Bitmap(Application.StartupPath & GFX_PATH & "misc" & GFX_EXT)

        ReDim TileSetImgsGFX(0 To NumTileSets)
        ReDim TileSetTexture(0 To NumTileSets)
        ReDim TileSetTextureInfo(0 To NumTileSets)

        ReDim SpritesGFX(0 To NumCharacters)
        ReDim SpritesGFXInfo(0 To NumCharacters)

        ReDim PaperDollGFX(0 To NumPaperdolls)
        ReDim PaperDollGFXInfo(0 To NumPaperdolls)

        ReDim ItemsGFX(0 To NumItems)
        ReDim ItemsGFXInfo(0 To NumItems)

        ReDim ResourcesGFX(0 To NumResources)
        ReDim ResourcesGFXInfo(0 To NumResources)

        ReDim AnimationsGFX(0 To NumAnimations)
        ReDim AnimationsGFXInfo(0 To NumAnimations)

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

        'Faces
        ReDim FacesGFX(0 To NumFaces)
        ReDim FacesGFXInfo(0 To NumFaces)
        For i = 1 To NumFaces
            'Load texture first, dont care about memory streams (just use the filename)
            FacesGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "Faces\" & i & GFX_EXT)

            'Cache the width and height
            FacesGFXInfo(i).width = FacesGFX(i).Size.X
            FacesGFXInfo(i).height = FacesGFX(i).Size.Y
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

        HUDPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\HUD" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            HUDPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\HUD" & GFX_EXT)

            'Cache the width and height
            HUDPanelGFXInfo.width = HUDPanelGFX.Size.X
            HUDPanelGFXInfo.height = HUDPanelGFX.Size.Y
        End If

        ActionPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "ActionBar\panel" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            ActionPanelGFX = New Texture(Application.StartupPath & GFX_PATH & "ActionBar\panel" & GFX_EXT)

            'Cache the width and height
            ActionPanelGFXInfo.width = ActionPanelGFX.Size.X
            ActionPanelGFXInfo.height = ActionPanelGFX.Size.Y
        End If

        InvPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\inventory" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            InvPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\inventory" & GFX_EXT)

            'Cache the width and height
            InvPanelGFXInfo.width = InvPanelGFX.Size.X
            InvPanelGFXInfo.height = InvPanelGFX.Size.Y
        End If

        SpellPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\spells" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            SpellPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\spells" & GFX_EXT)

            'Cache the width and height
            SpellPanelGFXInfo.width = SpellPanelGFX.Size.X
            SpellPanelGFXInfo.height = SpellPanelGFX.Size.Y
        End If

        CharPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\char" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CharPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\char" & GFX_EXT)

            'Cache the width and height
            CharPanelGFXInfo.width = CharPanelGFX.Size.X
            CharPanelGFXInfo.height = CharPanelGFX.Size.Y
        End If

        CharPanelPlusGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\plus" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CharPanelPlusGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\plus" & GFX_EXT)

            'Cache the width and height
            CharPanelPlusGFXInfo.width = CharPanelPlusGFX.Size.X
            CharPanelPlusGFXInfo.height = CharPanelPlusGFX.Size.Y
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

        HPBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "HPBar" & GFX_EXT) Then
            HPBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "HPBar" & GFX_EXT)

            'Cache the width and height
            HPBarGFXInfo.width = HPBarGFX.Size.X
            HPBarGFXInfo.height = HPBarGFX.Size.Y
        End If

        MPBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "MPBar" & GFX_EXT) Then
            MPBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "MPBar" & GFX_EXT)

            'Cache the width and height
            MPBarGFXInfo.width = MPBarGFX.Size.X
            MPBarGFXInfo.height = MPBarGFX.Size.Y
        End If

        EXPBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "EXPBar" & GFX_EXT) Then
            EXPBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "EXPBar" & GFX_EXT)

            'Cache the width and height
            EXPBarGFXInfo.width = EXPBarGFX.Size.X
            EXPBarGFXInfo.height = EXPBarGFX.Size.Y
        End If

        ChatWindowInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Chat" & GFX_EXT) Then
            ChatWindow = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Chat" & GFX_EXT)

            'Cache the width and height
            ChatWindowInfo.width = ChatWindow.Size.X
            ChatWindowInfo.height = ChatWindow.Size.Y
        End If

        ReDim ProjectileGFX(0 To NumProjectiles)
        ReDim ProjectileGFXInfo(0 To NumProjectiles)
        For i = 1 To NumProjectiles
            'Load texture first, dont care about memory streams (just use the filename)
            ProjectileGFX(i) = New Texture(Application.StartupPath & GFX_PATH & "projectiles\" & i & GFX_EXT)

            'Cache the width and height
            ProjectileGFXInfo(i).width = ProjectileGFX(i).Size.X
            ProjectileGFXInfo(i).height = ProjectileGFX(i).Size.Y
        Next

    End Sub

    Sub DrawChat()
        Dim i As Long, x As Long, y As Long
        Dim text As String

        'first draw back image
        RenderTexture(ChatWindow, GameWindow, ChatWindowX, ChatWindowY, 0, 0, ChatWindowInfo.width, ChatWindowInfo.height)

        y = 5
        x = 5

        Dim maxLines As Long = 8

        Dim first As Long = Chat.Count - maxLines 'First element is the 5th from the last in the list
        If first < 0 Then first = 0 'if the list has less than 5 elements, the first is the 0th index or first element

        Dim last As Long = first + maxLines
        If (last >= Chat.Count) Then last = Chat.Count - 1  'Based off of index 0, so the last element should be Chat.Count -1



        'only loop tru last entries
        For i = first To last
            text = Chat(i).Text

            If text <> "" Then ' or not
                'DrawText(ChatWindowX + x, ChatWindowY + y, text, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                DrawText(ChatWindowX + x, ChatWindowY + y, text, GetSFMLColor(Chat(i).Color), SFML.Graphics.Color.Black, GameWindow)
                y = y + 15
            End If

        Next
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

        ElseIf TexType = 5 Then 'resources
            If Index < 0 Or Index > NumItems Then Exit Sub

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
            If Index <= 0 Or Index > NumItems Then Exit Sub

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
            If Index < 0 Or Index > NumItems Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FacesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Faces\" & Index & GFX_EXT)

            'Cache the width and height
            With FacesGFXInfo(Index)
                .width = FacesGFX(Index).Size.X
                .height = FacesGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        End If

    End Sub

    Public Sub RenderTexture(ByVal Txture As Texture, ByVal Target As RenderWindow, ByVal DestX As Long, ByVal DestY As Long, ByVal SourceX As Long, ByVal SourceY As Long,
           ByVal SourceWidth As Long, ByVal SourceHeight As Long)
        Dim TmpImage As Sprite = New Sprite(Txture)
        TmpImage.TextureRect = New IntRect(SourceX, SourceY, SourceWidth, SourceHeight)
        TmpImage.Position = New SFML.Window.Vector2f(DestX, DestY)
        Target.Draw(TmpImage)
    End Sub

    Public Sub DrawDirections(ByVal X As Long, ByVal Y As Long)
        Dim rec As Rectangle, i As Long

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

    Public Function ConvertMapX(ByVal X As Long) As Long
        ConvertMapX = X - (TileView.left * PIC_X) - Camera.Left
    End Function

    Public Function ConvertMapY(ByVal Y As Long) As Long
        ConvertMapY = Y - (TileView.top * PIC_Y) - Camera.Top
    End Function

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
                    DrawPaperdoll(X, Y, Item(GetPlayerEquipment(Index, i)).Paperdoll, Anim, spriteleft)
                End If
            End If
        Next
    End Sub

    Public Sub DrawPaperdoll(ByVal x2 As Long, ByVal y2 As Long, ByVal Sprite As Long, ByVal Anim As Long, ByVal spritetop As Long)
        Dim rec As Rectangle
        Dim X As Long, Y As Long
        Dim width As Long, height As Long

        ' If debug mode, handle error then exit out

        If Sprite < 1 Or Sprite > NumPaperdolls Then Exit Sub

        If PaperDollGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 3)
        End If

        ' we use it, lets update timer
        With PaperDollGFXInfo(Sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

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

        RenderTexture(PaperDollGFX(Sprite), GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)
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

        DrawSprite(Sprite, X, Y, srcrec)

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

        If ResourcesGFXInfo(Resource).IsLoaded = False Then
            LoadTexture(Resource, 5)
        End If

        'seeying we still use it, lets update timer
        With ResourcesGFXInfo(Resource)
            .TextureTimer = GetTickCount() + 100000
        End With

        RenderTexture(ResourcesGFX(Resource), GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub DrawMapResource(ByVal Resource_num As Long)
        Dim Resource_master As Long

        Dim Resource_state As Long
        Dim Resource_sprite As Long
        Dim rec As Rectangle
        Dim X As Long, Y As Long

        If GettingMap Then Exit Sub

        If MapResource(Resource_num).X > MAX_MAPX Or MapResource(Resource_num).Y > MAX_MAPY Then Exit Sub
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

    Public Sub DrawItem(ByVal itemnum As Long)

        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim PicNum As Integer
        Dim x As Long, y As Long
        PicNum = Item(MapItem(itemnum).Num).Pic

        If PicNum < 1 Or PicNum > NumItems Then Exit Sub

        If ItemsGFXInfo(itemnum).IsLoaded = False Then
            LoadTexture(itemnum, 2)
        End If

        'seeying we still use it, lets update timer
        With ItemsGFXInfo(itemnum)
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

        RenderTexture(SpritesGFX(Sprite), GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height)
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

            RenderTexture(BloodGFX, GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)
        End With

    End Sub

    Public Sub DrawMapTile(ByVal X As Long, ByVal Y As Long)
        Dim i As Long
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        'Dim tmpSprite As Sprite
        If GettingMap Then Exit Sub

        With Map.Tile(X, Y)
            For i = MapLayer.Ground To MapLayer.Mask2
                ' skip tile if tileset isn't set
                If .Layer(i).tileset > 0 And .Layer(i).tileset <= NumTileSets Then
                    If TileSetTextureInfo(.Layer(i).tileset).IsLoaded = False Then
                        LoadTexture(.Layer(i).tileset, 1)
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

                        RenderTexture(TileSetTexture(.Layer(i).tileset), GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)
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

    Public Sub DrawMapFringeTile(ByVal X As Long, ByVal Y As Long)
        Dim i As Long
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim dest As Rectangle = New Rectangle(frmMainGame.PointToScreen(frmMainGame.picscreen.Location), New Size(32, 32))
        'Dim tmpSprite As Sprite

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

                        RenderTexture(TileSetTexture(.Layer(i).tileset), GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)

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
        Dim X As Long, Y As Long, I As Long

        'Don't Render IF
        If frmMainGame.WindowState = FormWindowState.Minimized Then Exit Sub
        If GettingMap Then Exit Sub

        UpdateCamera()

        DoEvents()

        'Clear each of our render targets
        GameWindow.DispatchEvents()
        GameWindow.Clear(SFML.Graphics.Color.Black)

        ClearGFX()

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

        If NumProjectiles > 0 Then
            For I = 1 To MAX_PROJECTILES
                If MapProjectiles(I).ProjectileNum > 0 Then
                    DrawProjectile(I)
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
            If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpDirBlock Then
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
            DrawText(1, HUDWindowY + HUDPanelGFXInfo.height + 1, Trim$("cur x: " & CurX & " y: " & CurY), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
            DrawText(1, HUDWindowY + HUDPanelGFXInfo.height + 15, Trim$("loc x: " & GetPlayerX(MyIndex) & " y: " & GetPlayerY(MyIndex)), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
            DrawText(1, HUDWindowY + HUDPanelGFXInfo.height + 30, Trim$(" (map #" & GetPlayerMap(MyIndex) & ")"), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
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

        If InMapEditor And frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpEvents Then DrawEvents()

        ' Draw map name
        DrawMapName()

        'Render GUI
        DrawGUI()

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
            If Spell(PlayerSpells(SpellBuffer)).CastTime = 0 Then Spell(PlayerSpells(SpellBuffer)).CastTime = 1
            ' calculate the width to fill
            barWidth = ((GetTickCount() - SpellBufferTimer) / ((GetTickCount() - SpellBufferTimer) + (Spell(PlayerSpells(SpellBuffer)).CastTime * 1000)) * 64)
            ' draw bars
            rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
            Dim rectShape As New RectangleShape(New SFML.Window.Vector2f(barWidth, 4))
            rectShape.Position = New SFML.Window.Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY))
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

        RenderTexture(DoorGFX, GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
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

        If AnimationsGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 6)
        End If

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

        RenderTexture(AnimationsGFX(Sprite), GameWindow, X, Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
    End Sub

    Public Sub DrawTileOutline()
        Dim rec As Rectangle
        If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpDirBlock Then Exit Sub

        With rec
            .Y = 0
            .Height = PIC_Y
            .X = 0
            .Width = PIC_X
        End With

        If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpAttributes Then
            RenderTexture(MiscGFX, GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
        Else
            If EditorTileWidth = 1 And EditorTileHeight = 1 Then
                RenderTexture(TileSetTexture(frmEditor_Map.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, rec.Width, rec.Height)
            Else
                If frmEditor_Map.cmbAutoTile.SelectedIndex > 0 Then
                    RenderTexture(TileSetTexture(frmEditor_Map.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, rec.Width, rec.Height)
                Else
                    RenderTexture(TileSetTexture(frmEditor_Map.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, EditorTileSelEnd.X * PIC_X, EditorTileSelEnd.Y * PIC_Y)
                End If

            End If

        End If

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

        'Dim tmpSprite As Sprite = New Sprite(MiscGFX)
        'tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        'tmpSprite.Position = New SFML.System.Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
        'GameWindow.Draw(tmpSprite)

        RenderTexture(MiscGFX, GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub EditorMap_DrawTileset()
        Dim height As Integer
        Dim width As Integer
        Dim tileset As Byte

        ' find tileset number
        tileset = frmEditor_Map.cmbTileSets.SelectedIndex + 1

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

        'Draw the tileset into memory.)
        height = TileSetImgsGFX(tileset).Height
        width = TileSetImgsGFX(tileset).Width
        MapEditorBackBuffer = New Bitmap(width, height)

        Dim g As Graphics = Graphics.FromImage(MapEditorBackBuffer)
        g.FillRectangle(Brushes.Black, New Rectangle(0, 0, MapEditorBackBuffer.Width, MapEditorBackBuffer.Height))

        frmEditor_Map.picBackSelect.Height = height
        frmEditor_Map.picBackSelect.Width = width

        ' change selected shape for autotiles
        If frmEditor_Map.cmbAutoTile.SelectedIndex > 0 Then
            Select Case frmEditor_Map.cmbAutoTile.SelectedIndex
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
        If Not MapEditorBackBuffer Is Nothing Then MapEditorBackBuffer.Dispose()

        If Not TempBitmap Is Nothing Then TempBitmap.Dispose()

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

        For i = 0 To NumFaces
            If Not FacesGFX(i) Is Nothing Then FacesGFX(i).Dispose()
        Next

        For i = 0 To NumProjectiles
            If Not ProjectileGFX(i) Is Nothing Then ProjectileGFX(i).Dispose()
        Next

        If Not DoorGFX Is Nothing Then DoorGFX.Dispose()
        If Not BloodGFX Is Nothing Then BloodGFX.Dispose()
        If Not DirectionsGfx Is Nothing Then DirectionsGfx.Dispose()
        If Not MiscGFX Is Nothing Then MiscGFX.Dispose()
        If Not ActionPanelGFX Is Nothing Then ActionPanelGFX.Dispose()
        If Not InvPanelGFX Is Nothing Then InvPanelGFX.Dispose()
        If Not CharPanelGFX Is Nothing Then CharPanelGFX.Dispose()
        If Not TargetGFX Is Nothing Then TargetGFX.Dispose()
        If Not HotBarGFX Is Nothing Then HotBarGFX.Dispose()
        If Not ChatWindow Is Nothing Then ChatWindow.Dispose()

        If Not HPBarGFX Is Nothing Then HPBarGFX.Dispose()
        If Not MPBarGFX Is Nothing Then MPBarGFX.Dispose()
        If Not EXPBarGFX Is Nothing Then EXPBarGFX.Dispose()
        If Not EmptyHPBarGFX Is Nothing Then EmptyHPBarGFX.Dispose()
        If Not EmptyMPBarGFX Is Nothing Then EmptyMPBarGFX.Dispose()
        If Not EmptyEXPBarGFX Is Nothing Then EmptyEXPBarGFX.Dispose()

    End Sub

    Public Sub EditorMap_DrawMapItem()
        Dim itemnum As Integer
        itemnum = Item(frmEditor_Map.scrlMapItem.Value).Pic

        If itemnum < 1 Or itemnum > NumItems Then
            frmEditor_Map.picMapItem.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT) Then
            frmEditor_Map.picMapItem.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT)
        End If

    End Sub

    Public Sub EditorMap_DrawKey()
        Dim itemnum As Long

        itemnum = Item(frmEditor_Map.scrlMapKey.Value).Pic

        If itemnum < 1 Or itemnum > NumItems Then
            frmEditor_Map.picMapKey.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT) Then
            frmEditor_Map.picMapKey.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & itemnum & GFX_EXT)
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
        Dim Sprite As Long

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
        'Dim tmpSprite As Sprite = New Sprite(FurnitureGFX(Furniturenum))
        'tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        'tmpSprite.Position = New SFML.Window.Vector2f(dRECT.X, dRECT.Y)
        'EditorItem_Furniture.Draw(tmpSprite)

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
        Dim Sprite As Long

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
        Dim Sprite As Long

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

        With sRECT
            .Y = 0
            .Height = PIC_Y
            .X = 0
            .Width = PIC_X
        End With

        'drect is the same, so just copy it
        dRECT = sRECT

        EditorSpell_Icon.Clear(ToSFMLColor(frmEditor_Spell.picSprite.BackColor))
        'Dim tmpSprite As Sprite = New Sprite(SpellIconsGFX(iconnum))
        'tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
        'tmpSprite.Position = New SFML.Window.Vector2f(dRECT.X, dRECT.Y)
        'EditorSpell_Icon.Draw(tmpSprite)

        RenderTexture(SpellIconsGFX(iconnum), EditorSpell_Icon, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)

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
                    'Dim tmpSprite As Sprite = New Sprite(AnimationsGFX(Animationnum))
                    'tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    'tmpSprite.Position = New SFML.Window.Vector2f(dRECT.X, dRECT.Y)
                    'EditorAnimation_Anim1.Draw(tmpSprite)

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

                    'Dim tmpSprite As Sprite = New Sprite(AnimationsGFX(Animationnum))
                    'tmpSprite.TextureRect = New IntRect(sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    'tmpSprite.Position = New SFML.Window.Vector2f(dRECT.X, dRECT.Y)
                    'EditorAnimation_Anim2.Draw(tmpSprite)

                    RenderTexture(AnimationsGFX(Animationnum), EditorAnimation_Anim2, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)
                    EditorAnimation_Anim2.Display()

                End If
            End If
        End If
    End Sub

    Sub DrawHUD()
        Dim rec As Rectangle

        'first render backpanel
        With rec
            .Y = 0
            .Height = HUDPanelGFXInfo.height
            .X = 0
            .Width = HUDPanelGFXInfo.width
        End With

        RenderTexture(HUDPanelGFX, GameWindow, HUDWindowX, HUDWindowY, rec.X, rec.Y, rec.Width, rec.Height)

        If Player(MyIndex).Sprite <= NumFaces Then
            Dim tmpSprite As Sprite = New Sprite(FacesGFX(Player(MyIndex).Sprite))

            If FacesGFXInfo(Player(MyIndex).Sprite).IsLoaded = False Then
                LoadTexture(Player(MyIndex).Sprite, 7)
            End If

            'seeying we still use it, lets update timer
            With FacesGFXInfo(Player(MyIndex).Sprite)
                .TextureTimer = GetTickCount() + 100000
            End With

            'then render face
            With rec
                .Y = 0
                .Height = FacesGFXInfo(Player(MyIndex).Sprite).height
                .X = 0
                .Width = FacesGFXInfo(Player(MyIndex).Sprite).width
            End With

            RenderTexture(FacesGFX(Player(MyIndex).Sprite), GameWindow, HUDFaceX, HUDFaceY, rec.X, rec.Y, rec.Width, rec.Height)
        End If

        'Hp Bar etc
        DrawStatBars()

        'Fps etc
        DrawText(HUDWindowX + HUDHPBarX + HPBarGFXInfo.width + 10, HUDWindowY + HUDHPBarY + 4, "FPS: " & FPS, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        DrawText(HUDWindowX + HUDMPBarX + MPBarGFXInfo.width + 10, HUDWindowY + HUDMPBarY + 4, "Ping: " & PingToDraw, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        DrawText(HUDWindowX + HUDEXPBarX, HUDWindowY + HUDEXPBarY + 20, "Gold: " & GoldAmount, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
    End Sub

    Sub DrawStatBars()
        Dim rec As Rectangle
        Dim CurHP As Long, CurMP As Long, CurEXP As Long

        'HP Bar
        CurHP = (GetPlayerVital(MyIndex, 1) / GetPlayerMaxVital(MyIndex, 1)) * 100

        ''first render empty
        'With rec
        '    .Y = 0
        '    .Height = EmptyHPBarGFXInfo.height
        '    .X = 0
        '    .Width = EmptyHPBarGFXInfo.width
        'End With

        'RenderTexture(EmptyHPBarGFX, GameWindow, HUDWindowX + HUDHPBarX, HUDWindowY + HUDHPBarY, rec.X, rec.Y, rec.Width, rec.Height)

        With rec
            .Y = 0
            .Height = HPBarGFXInfo.height
            .X = 0
            .Width = CurHP * HPBarGFXInfo.width / 100
        End With

        'then render full ontop of it
        RenderTexture(HPBarGFX, GameWindow, HUDWindowX + HUDHPBarX, HUDWindowY + HUDHPBarY + 4, rec.X, rec.Y, rec.Width, rec.Height)

        'then draw the text onto that
        DrawText(HUDWindowX + HUDHPBarX + 65, HUDWindowY + HUDHPBarY + 4, GetPlayerVital(MyIndex, 1) & "/" & GetPlayerMaxVital(MyIndex, 1), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        '==============================

        'MP Bar
        CurMP = (GetPlayerVital(MyIndex, 2) / GetPlayerMaxVital(MyIndex, 2)) * 100

        ''first render empty
        'With rec
        '    .Y = 0
        '    .Height = EmptyMPBarGFXInfo.height
        '    .X = 0
        '    .Width = EmptyMPBarGFXInfo.width
        'End With

        'RenderTexture(EmptyMPBarGFX, GameWindow, HUDWindowX + HUDMPBarX, HUDWindowY + HUDMPBarY, rec.X, rec.Y, rec.Width, rec.Height)

        'then render full ontop of it
        With rec
            .Y = 0
            .Height = MPBarGFXInfo.height
            .X = 0
            .Width = CurMP * MPBarGFXInfo.width / 100
        End With

        RenderTexture(MPBarGFX, GameWindow, HUDWindowX + HUDMPBarX, HUDWindowY + HUDMPBarY + 4, rec.X, rec.Y, rec.Width, rec.Height)

        'draw text onto that
        DrawText(HUDWindowX + HUDMPBarX + 65, HUDWindowY + HUDMPBarY + 4, GetPlayerVital(MyIndex, 2) & "/" & GetPlayerMaxVital(MyIndex, 2), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        '====================================================
        'EXP Bar
        CurEXP = (GetPlayerExp(MyIndex) / NextlevelExp) * 100

        ''first render empty
        'With rec
        '    .Y = 0
        '    .Height = EmptyEXPBarGFXInfo.height
        '    .X = 0
        '    .Width = EmptyEXPBarGFXInfo.width
        'End With

        'RenderTexture(EmptyEXPBarGFX, GameWindow, HUDWindowX + HUDEXPBarX, HUDWindowY + HUDEXPBarY, rec.X, rec.Y, rec.Width, rec.Height)

        'then render full ontop of it
        With rec
            .Y = 0
            .Height = EXPBarGFXInfo.height
            .X = 0
            .Width = CurEXP * EXPBarGFXInfo.width / 100
        End With

        RenderTexture(EXPBarGFX, GameWindow, HUDWindowX + HUDEXPBarX, HUDWindowY + HUDEXPBarY + 4, rec.X, rec.Y, rec.Width, rec.Height)

        'draw text onto that
        DrawText(HUDWindowX + HUDEXPBarX + 65, HUDWindowY + HUDEXPBarY + 4, GetPlayerExp(MyIndex) & "/" & NextlevelExp, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
    End Sub

    Sub DrawActionPanel()
        Dim rec As Rectangle

        'first render backpanel
        With rec
            .Y = 0
            .Height = ActionPanelGFXInfo.height
            .X = 0
            .Width = ActionPanelGFXInfo.width
        End With

        RenderTexture(ActionPanelGFX, GameWindow, ActionPanelX, ActionPanelY, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

    Sub DrawEquipment()
        Dim i As Long, itemnum As Long, itempic As Long
        Dim rec As Rectangle, rec_pos As Rectangle, playersprite As Long
        Dim tmpSprite2 As Sprite = New Sprite(CharPanelGFX)

        If NumItems = 0 Then Exit Sub

        'first render panel
        RenderTexture(CharPanelGFX, GameWindow, CharWindowX, CharWindowY, 0, 0, CharPanelGFXInfo.width, CharPanelGFXInfo.height)

        'lets get player sprite to render
        playersprite = GetPlayerSprite(MyIndex)

        With rec
            .Y = 0
            .Height = SpritesGFXInfo(playersprite).height / 4
            .X = 0
            .Width = SpritesGFXInfo(playersprite).width / 4
        End With

        RenderTexture(SpritesGFX(playersprite), GameWindow, CharWindowX + CharPanelGFXInfo.width / 2 - rec.Width / 2, CharWindowY + CharPanelGFXInfo.height / 2 - rec.Height / 2, rec.X, rec.Y, rec.Width, rec.Height)

        For i = 1 To Equipment.Equipment_Count - 1
            itemnum = GetPlayerEquipment(MyIndex, i)

            If itemnum > 0 Then

                itempic = Item(itemnum).Pic

                If ItemsGFXInfo(itempic).IsLoaded = False Then
                    LoadTexture(itempic, 4)
                End If

                'seeying we still use it, lets update timer
                With ItemsGFXInfo(itempic)
                    .TextureTimer = GetTickCount() + 100000
                End With

                With rec
                    .Y = 0
                    .Height = 32
                    .X = 0
                    .Width = 32
                End With

                With rec_pos
                    .Y = CharWindowY + EqTop + ((EqOffsetY + 32) * ((i - 1) \ EqColumns))
                    .Height = PIC_Y
                    .X = CharWindowX + EqLeft + ((EqOffsetX + 32) * (((i - 1) Mod EqColumns)))
                    .Width = PIC_X
                End With

                Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                GameWindow.Draw(tmpSprite)
            End If

        Next

        ' Set the character windows
        'name
        DrawText(CharWindowX + 10, CharWindowY + 14, "Name: " & GetPlayerName(MyIndex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'class
        DrawText(CharWindowX + 10, CharWindowY + 33, "Class: " & Trim(Classes(GetPlayerClass(MyIndex)).Name), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'level
        DrawText(CharWindowX + 150, CharWindowY + 14, "Lvl: " & GetPlayerLevel(MyIndex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'points
        DrawText(CharWindowX + 6, CharWindowY + 200, "Points: " & GetPlayerPOINTS(MyIndex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'strength stat
        DrawText(CharWindowX + 6, CharWindowY + 219, "Str: " & GetPlayerStat(MyIndex, Stats.strength), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'endurance stat
        DrawText(CharWindowX + 88, CharWindowY + 219, "End: " & GetPlayerStat(MyIndex, Stats.endurance), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'vitality stat
        DrawText(CharWindowX + 6, CharWindowY + 235, "Vit: " & GetPlayerStat(MyIndex, Stats.vitality), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'willpower stat
        DrawText(CharWindowX + 88, CharWindowY + 235, "Will: " & GetPlayerStat(MyIndex, Stats.willpower), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'intelligence stat
        DrawText(CharWindowX + 6, CharWindowY + 250, "Int: " & GetPlayerStat(MyIndex, Stats.intelligence), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'spirit stat
        DrawText(CharWindowX + 88, CharWindowY + 250, "Sprt: " & GetPlayerStat(MyIndex, Stats.spirit), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        If GetPlayerPOINTS(MyIndex) > 0 Then
            'strength upgrade
            RenderTexture(CharPanelPlusGFX, GameWindow, CharWindowX + StrengthUpgradeX, CharWindowY + StrengthUpgradeY, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
            'endurance upgrade
            RenderTexture(CharPanelPlusGFX, GameWindow, CharWindowX + EnduranceUpgradeX, CharWindowY + EnduranceUpgradeY, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
            'vitality upgrade
            RenderTexture(CharPanelPlusGFX, GameWindow, CharWindowX + VitalityUpgradeX, CharWindowY + VitalityUpgradeY, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
            'intelligence upgrade
            RenderTexture(CharPanelPlusGFX, GameWindow, CharWindowX + IntellectUpgradeX, CharWindowY + IntellectUpgradeY, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
            'willpower upgrade
            RenderTexture(CharPanelPlusGFX, GameWindow, CharWindowX + WillPowerUpgradeX, CharWindowY + WillPowerUpgradeY, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
            'spirit upgrade
            RenderTexture(CharPanelPlusGFX, GameWindow, CharWindowX + SpiritUpgradeX, CharWindowY + SpiritUpgradeY, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
        End If
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

            'seeying we still use it, lets update timer
            With ItemsGFXInfo(itempic)
                .TextureTimer = GetTickCount() + 100000
            End With

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
            tmpSprite.Position = New SFML.Window.Vector2f(0, 0)
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

        'first render panel
        RenderTexture(InvPanelGFX, GameWindow, InvWindowX, InvWindowY, 0, 0, InvPanelGFXInfo.width, InvPanelGFXInfo.height)

        For i = 1 To MAX_INV
            itemnum = GetPlayerInvItemNum(MyIndex, i)

            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic = 0 Then GoTo NextLoop

                If ItemsGFXInfo(itempic).IsLoaded = False Then
                    LoadTexture(itempic, 4)
                End If

                'seeying we still use it, lets update timer
                With ItemsGFXInfo(itempic)
                    .TextureTimer = GetTickCount() + 100000
                End With

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
                            .Y = InvWindowY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                            .Height = PIC_Y
                            .X = InvWindowX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                            .Width = PIC_X
                        End With

                        Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                        tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                        tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                        GameWindow.Draw(tmpSprite)


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

                            DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, GameWindow)

                            ' Check if it's gold, and update the label
                            If GetPlayerInvItemNum(MyIndex, i) = 1 Then '1 = gold :P
                                GoldAmount = Format(CLng(Amount), "#,###,###,###")
                            End If
                        End If
                    End If
                End If
            End If
NextLoop:
        Next

        DrawAnimatedInvItems()
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
                        tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                        GameWindow.Draw(tmpSprite)


                        ' If item is a stack - draw the amount you have
                        If GetPlayerInvItemValue(MyIndex, i) > 1 Then
                            Y = rec_pos.Top + 22
                            X = rec_pos.Left - 4
                            Amount = CStr(GetPlayerInvItemValue(MyIndex, i))
                            ' Draw currency but with k, m, b etc. using a convertion function
                            DrawText(X, Y, ConvertCurrency(Amount), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
                            ' Check if it's gold, and update the label
                            If GetPlayerInvItemNum(MyIndex, i) = 1 Then '1 = gold :P
                                GoldAmount = Format(Amount, "#,###,###,###")
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
            tmpSprite.Position = New SFML.Window.Vector2f(0, 0)
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
        Dim colour As SFML.Graphics.Color

        If Not InGame Then Exit Sub
        ShopWindow.Clear(ToSFMLColor(frmMainGame.pnlShopItems.BackColor))
        For i = 1 To MAX_TRADES
            itemnum = Shop(InShop).TradeItem(i).Item
            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic
                If itempic > 0 And itempic <= NumItems Then

                    If ItemsGFXInfo(itempic).IsLoaded = False Then
                        LoadTexture(itempic, 4)
                    End If

                    'seeying we still use it, lets update timer
                    With ItemsGFXInfo(itempic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
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
                    tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                    ShopWindow.Draw(tmpSprite)

                    ' If item is a stack - draw the amount you have
                    If Shop(InShop).TradeItem(i).ItemValue > 1 Then
                        Y = rec_pos.Top + 22
                        X = rec_pos.Left - 4
                        Amount = Shop(InShop).TradeItem(i).ItemValue
                        colour = SFML.Graphics.Color.White
                        ' Draw currency but with k, m, b etc. using a convertion function
                        If CLng(Amount) < 1000000 Then
                            colour = SFML.Graphics.Color.White
                        ElseIf CLng(Amount) > 1000000 And CLng(Amount) < 10000000 Then
                            colour = SFML.Graphics.Color.Yellow
                        ElseIf CLng(Amount) > 10000000 Then
                            colour = SFML.Graphics.Color.Green
                        End If

                        DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, BankWindow)
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

                    'seeying we still use it, lets update timer
                    With ItemsGFXInfo(Sprite)
                        .TextureTimer = GetTickCount() + 100000
                    End With

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
                    tmpSprite.Position = New SFML.Window.Vector2f(dRECT.X, dRECT.Y)
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

            'seeying we still use it, lets update timer
            With ItemsGFXInfo(Sprite)
                .TextureTimer = GetTickCount() + 100000
            End With

            With sRECT
                .Y = 0
                .Height = PIC_Y
                .X = 0
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
        tmpSprite.Position = New SFML.Window.Vector2f(dRECT.X, dRECT.Y)
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

                    If ItemsGFXInfo(itempic).IsLoaded = False Then
                        LoadTexture(itempic, 4)
                    End If

                    'seeying we still use it, lets update timer
                    With ItemsGFXInfo(itempic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

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

                    'Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                    'tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    'tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                    'YourTradeWindow.Draw(tmpSprite)

                    RenderTexture(ItemsGFX(itempic), TheirTradeWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

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
        frmMainGame.lblYourWorth.Text = YourWorth
        YourTradeWindow.Display()

        TheirTradeWindow.Clear(ToSFMLColor(frmMainGame.pnlTheirTrade.BackColor))
        For i = 1 To MAX_INV
            ' blt their offer
            itemnum = TradeTheirOffer(i).Num
            If itemnum > 0 And itemnum <= MAX_ITEMS Then
                itempic = Item(itemnum).Pic

                If itempic > 0 And itempic <= NumItems Then
                    If ItemsGFXInfo(itempic).IsLoaded = False Then
                        LoadTexture(itempic, 4)
                    End If

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

                    'Dim tmpSprite As Sprite = New Sprite(ItemsGFX(itempic))
                    'tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    'tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                    'TheirTradeWindow.Draw(tmpSprite)

                    RenderTexture(ItemsGFX(itempic), TheirTradeWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

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
        frmMainGame.lblTheirWorth.Text = TheirWorth
        TheirTradeWindow.Display()
    End Sub

    Sub DrawPlayerSpells()
        Dim i As Long, spellnum As Long, spellicon As Long
        Dim rec As Rectangle, rec_pos As Rectangle

        If Not InGame Then Exit Sub

        'first render panel
        RenderTexture(SpellPanelGFX, GameWindow, SpellWindowX, SpellWindowY, 0, 0, SpellPanelGFXInfo.width, SpellPanelGFXInfo.height)

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
                        .Y = SpellWindowY + SpellTop + ((SpellOffsetY + 32) * ((i - 1) \ SpellColumns))
                        .Height = PIC_Y
                        .X = SpellWindowX + SpellLeft + ((SpellOffsetX + 32) * (((i - 1) Mod SpellColumns)))
                        .Width = PIC_X
                    End With

                    'Dim tmpSprite As Sprite = New Sprite(SpellIconsGFX(spellicon))
                    'tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                    'tmpSprite.Position = New SFML.Window.Vector2f(rec_pos.X, rec_pos.Y)
                    'GameWindow.Draw(tmpSprite)
                    RenderTexture(SpellIconsGFX(spellicon), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
                End If
            End If
        Next

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

        'Dim tmpSprite As Sprite = New Sprite(TargetGFX)
        'tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        'tmpSprite.Position = New SFML.Window.Vector2f(X, y)
        'GameWindow.Draw(tmpSprite)

        RenderTexture(TargetGFX, GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height)

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

        'Dim tmpSprite As Sprite = New Sprite(TargetGFX)
        'tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
        'tmpSprite.Position = New SFML.Window.Vector2f(X, Y)
        'GameWindow.Draw(tmpSprite)

        RenderTexture(TargetGFX, GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)
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
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnPlay" & GFX_EXT) Then
            frmMenu.btnPlay.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnPlay" & GFX_EXT)
        End If
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnLogin" & GFX_EXT) Then
            frmMenu.btnLogin.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnLogin" & GFX_EXT)
        End If
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\btnRegister" & GFX_EXT) Then
            frmMenu.btnRegister.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\btnRegister" & GFX_EXT)
        End If

        'main game
        If FileExist(Application.StartupPath & GFX_PATH & "Gui\Main\main" & GFX_EXT) Then
            frmMenu.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Main\main" & GFX_EXT)
        End If

    End Sub

    Public Sub DrawGUI()
        'hide GUI when mapping...
        If InMapEditor Then Exit Sub

        If HUDVisible = True Then
            DrawHUD()
            DrawActionPanel()
            DrawChat()
            DrawHotbar()
        End If

        If pnlCharacterVisible = True Then
            DrawEquipment()
        End If

        If pnlInventoryVisible = True Then
            DrawInventory()
        End If

        If pnlSpellsVisible = True Then
            DrawPlayerSpells()
        End If
    End Sub
End Module

