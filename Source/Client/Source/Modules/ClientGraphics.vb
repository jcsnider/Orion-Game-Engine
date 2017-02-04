Imports SFML.Graphics
Imports System.Drawing
Imports System.Windows.Forms
Imports SFML.System

Module ClientGraphics
#Region "Declarations"
    Public GameWindow As RenderWindow
    Public TilesetWindow As RenderWindow

    Public SFMLGameFont As SFML.Graphics.Font

    Public CursorGFX As Texture
    Public CursorSprite As Sprite
    Public CursorInfo As GraphicInfo

    'TileSets
    Public TileSetTexture() As Texture
    Public TileSetSprite() As Sprite
    Public TileSetTextureInfo() As GraphicInfo
    'Characters
    Public CharacterGFX() As Texture
    Public CharacterSprite() As Sprite
    Public CharacterGFXInfo() As GraphicInfo
    'Paperdolls
    Public PaperDollGFX() As Texture
    Public PaperDollSprite() As Sprite
    Public PaperDollGFXInfo() As GraphicInfo
    'Items
    Public ItemsGFX() As Texture
    Public ItemsSprite() As Sprite
    Public ItemsGFXInfo() As GraphicInfo
    'Resources
    Public ResourcesGFX() As Texture
    Public ResourcesSprite() As Sprite
    Public ResourcesGFXInfo() As GraphicInfo
    'Animations
    Public AnimationsGFX() As Texture
    Public AnimationsSprite() As Sprite
    Public AnimationsGFXInfo() As GraphicInfo
    'Skills
    Public SkillIconsGFX() As Texture
    Public SkillIconsSprite() As Sprite
    Public SkillIconsGFXInfo() As GraphicInfo
    'Housing
    Public FurnitureGFX() As Texture
    Public FurnitureSprite() As Sprite
    Public FurnitureGFXInfo() As GraphicInfo
    'Faces
    Public FacesGFX() As Texture
    Public FacesSprite() As Sprite
    Public FacesGFXInfo() As GraphicInfo
    'Projectiles
    Public ProjectileGFX() As Texture
    Public ProjectileSprite() As Sprite
    Public ProjectileGFXInfo() As GraphicInfo
    'Fogs
    Public FogGFX() As Texture
    Public FogSprite() As Sprite
    Public FogGFXInfo() As GraphicInfo
    'Emotes
    Public EmotesGFX() As Texture
    Public EmotesSprite() As Sprite
    Public EmotesGFXInfo() As GraphicInfo
    'Door
    Public DoorGFX As Texture
    Public DoorSprite As Sprite
    Public DoorGFXInfo As GraphicInfo
    'Blood
    Public BloodGFX As Texture
    Public BloodSprite As Sprite
    Public BloodGFXInfo As GraphicInfo
    'Directions
    Public DirectionsGfx As Texture
    Public DirectionsSprite As Sprite
    Public DirectionsGFXInfo As GraphicInfo
    'Weather
    Public WeatherGFX As Texture
    Public WeatherSprite As Sprite
    Public WeatherGFXInfo As GraphicInfo
    'Hotbar
    Public HotBarGFX As Texture
    Public HotBarSprite As Sprite
    Public HotBarGFXInfo As GraphicInfo
    'Chat
    Public ChatWindowGFX As Texture
    Public ChatWindowSprite As Sprite
    Public ChatWindowGFXInfo As GraphicInfo
    'MyChat
    Public MyChatWindowGFX As Texture
    Public MyChatWindowSprite As Sprite
    Public MyChatWindowGFXInfo As GraphicInfo
    'Buttons
    Public ButtonGFX As Texture
    Public ButtonSprite As Sprite
    Public ButtonGFXInfo As GraphicInfo
    Public ButtonHoverGFX As Texture
    Public ButtonHoverSprite As Sprite
    Public ButtonHoverGFXInfo As GraphicInfo
    'Hud
    Public HUDPanelGFX As Texture
    Public HUDPanelSprite As Sprite
    Public HUDPanelGFXInfo As GraphicInfo
    'Bars
    Public HPBarGFX As Texture
    Public HPBarSprite As Sprite
    Public HPBarGFXInfo As GraphicInfo
    Public MPBarGFX As Texture
    Public MPBarSprite As Sprite
    Public MPBarGFXInfo As GraphicInfo
    Public EXPBarGFX As Texture
    Public EXPBarSprite As Sprite
    Public EXPBarGFXInfo As GraphicInfo

    Public ActionPanelGFX As Texture
    Public ActionPanelSprite As Sprite
    Public ActionPanelGFXInfo As GraphicInfo
    Public ActionPanelButtonsGFX(8) As Texture
    Public ActionPanelButtonsSprite(8) As Sprite
    Public ActionPanelButtonGFXInfo(8) As GraphicInfo

    Public InvPanelGFX As Texture
    Public InvPanelSprite As Sprite
    Public InvPanelGFXInfo As GraphicInfo

    Public SkillPanelGFX As Texture
    Public SkillPanelSprite As Sprite
    Public SkillPanelGFXInfo As GraphicInfo

    Public CharPanelGFX As Texture
    Public CharPanelSprite As Sprite
    Public CharPanelGFXInfo As GraphicInfo
    Public CharPanelPlusGFX As Texture
    Public CharPanelPlusSprite As Sprite
    Public CharPanelPlusGFXInfo As GraphicInfo
    Public CharPanelMinGFX As Texture
    Public CharPanelMinSprite As Sprite
    Public CharPanelMinGFXInfo As GraphicInfo

    Public BankPanelGFX As Texture
    Public BankPanelSprite As Sprite
    Public BankPanelGFXInfo As GraphicInfo

    Public TradePanelGFX As Texture
    Public TradePanelSprite As Sprite
    Public TradePanelGFXInfo As GraphicInfo

    Public ShopPanelGFX As Texture
    Public ShopPanelSprite As Sprite
    Public ShopPanelGFXInfo As GraphicInfo

    Public EventChatGFX As Texture
    Public EventChatSprite As Sprite
    Public EventChatGFXInfo As GraphicInfo

    Public TargetGFX As Texture
    Public TargetSprite As Sprite
    Public TargetGFXInfo As GraphicInfo

    Public DescriptionGFX As Texture
    Public DescriptionSprite As Sprite
    Public DescriptionGFXInfo As GraphicInfo

    Public QuestGFX As Texture
    Public QuestSprite As Sprite
    Public QuestGFXInfo As GraphicInfo

    Public CraftGFX As Texture
    Public CraftSprite As Sprite
    Public CraftGFXInfo As GraphicInfo

    Public ProgBarGFX As Texture
    Public ProgBarSprite As Sprite
    Public ProgBarGFXInfo As GraphicInfo

    Public RClickGFX As Texture
    Public RClickSprite As Sprite
    Public RClickGFXInfo As GraphicInfo

    Public ChatBubbleGFX As Texture
    Public ChatBubbleSprite As Sprite
    Public ChatBubbleGFXInfo As GraphicInfo

    Public PetStatsGFX As Texture
    Public PetStatsSprite As Sprite
    Public PetStatsGFXInfo As GraphicInfo

    Public PetBarGFX As Texture
    Public PetBarSprite As Sprite
    Public PetbarGFXInfo As GraphicInfo

    Public MapTintSprite As Sprite

    ' Number of graphic files
    Public NumTileSets As Integer
    Public NumCharacters As Integer
    Public NumPaperdolls As Integer
    Public NumItems As Integer
    Public NumResources As Integer
    Public NumAnimations As Integer
    Public NumSkillIcons As Integer
    Public NumFaces As Integer
    Public NumFogs As Integer
    Public NumEmotes As Integer

    ' #Day/Night
    Public NightGfx As New RenderTexture(1152, 864)
    Public NightSprite As Sprite
    Public NightGfxInfo As GraphicInfo

    Public LightGfx As Texture
    Public LightSprite As Sprite
    Public LightGfxInfo As GraphicInfo

    Public ShadowGfx As Texture
    Public ShadowSprite As Sprite
    Public ShadowGfxInfo As GraphicInfo
#End Region

#Region "Types"
    Public Structure GraphicInfo
        Dim Width As Integer
        Dim Height As Integer
        Dim IsLoaded As Boolean
        Dim TextureTimer As Integer
    End Structure

    Public Structure Graphics_Tiles
        Dim Tile(,) As Texture
    End Structure
#End Region

#Region "initialisation"
    Sub InitGraphics()

        GameWindow = New RenderWindow(FrmMainGame.picscreen.Handle)
        TilesetWindow = New RenderWindow(frmEditor_MapEditor.picBackSelect.Handle)

        SFMLGameFont = New SFML.Graphics.Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + FONT_NAME)

        'this stuff only loads when needed :)

        ReDim TileSetTexture(0 To NumTileSets)
        ReDim TileSetSprite(0 To NumTileSets)
        ReDim TileSetTextureInfo(0 To NumTileSets)

        ReDim CharacterGFX(0 To NumCharacters)
        ReDim CharacterSprite(0 To NumCharacters)
        ReDim CharacterGFXInfo(0 To NumCharacters)

        ReDim PaperDollGFX(0 To NumPaperdolls)
        ReDim PaperDollSprite(0 To NumPaperdolls)
        ReDim PaperDollGFXInfo(0 To NumPaperdolls)

        ReDim ItemsGFX(0 To NumItems)
        ReDim ItemsSprite(0 To NumItems)
        ReDim ItemsGFXInfo(0 To NumItems)

        ReDim ResourcesGFX(0 To NumResources)
        ReDim ResourcesSprite(0 To NumResources)
        ReDim ResourcesGFXInfo(0 To NumResources)

        ReDim AnimationsGFX(0 To NumAnimations)
        ReDim AnimationsSprite(0 To NumAnimations)
        ReDim AnimationsGFXInfo(0 To NumAnimations)

        ReDim SkillIconsGFX(0 To NumSkillIcons)
        ReDim SkillIconsSprite(0 To NumSkillIcons)
        ReDim SkillIconsGFXInfo(0 To NumSkillIcons)

        ReDim FacesGFX(0 To NumFaces)
        ReDim FacesSprite(0 To NumFaces)
        ReDim FacesGFXInfo(0 To NumFaces)

        ReDim FurnitureGFX(0 To NumFurniture)
        ReDim FurnitureSprite(0 To NumFurniture)
        ReDim FurnitureGFXInfo(0 To NumFurniture)

        ReDim ProjectileGFX(0 To NumProjectiles)
        ReDim ProjectileSprite(0 To NumProjectiles)
        ReDim ProjectileGFXInfo(0 To NumProjectiles)

        ReDim FogGFX(0 To NumFogs)
        ReDim FogSprite(0 To NumFogs)
        ReDim FogGFXInfo(0 To NumFogs)

        ReDim EmotesGFX(0 To NumEmotes)
        ReDim EmotesSprite(0 To NumEmotes)
        ReDim EmotesGFXInfo(0 To NumEmotes)

        'sadly, gui shit is always needed, so we preload it :/
        CursorInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "Cursor" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CursorGFX = New Texture(Application.StartupPath & GFX_PATH & "Cursor" & GFX_EXT)
            CursorSprite = New Sprite(CursorGFX)

            'Cache the width and height
            CursorInfo.Width = CursorGFX.Size.X
            CursorInfo.Height = CursorGFX.Size.Y
        End If

        DoorGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "door" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            DoorGFX = New Texture(Application.StartupPath & GFX_PATH & "door" & GFX_EXT)
            DoorSprite = New Sprite(DoorGFX)

            'Cache the width and height
            DoorGFXInfo.Width = DoorGFX.Size.X
            DoorGFXInfo.Height = DoorGFX.Size.Y
        End If

        BloodGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "blood" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            BloodGFX = New Texture(Application.StartupPath & GFX_PATH & "blood" & GFX_EXT)
            BloodSprite = New Sprite(BloodGFX)

            'Cache the width and height
            BloodGFXInfo.Width = BloodGFX.Size.X
            BloodGFXInfo.Height = BloodGFX.Size.Y
        End If

        DirectionsGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "direction" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            DirectionsGfx = New Texture(Application.StartupPath & GFX_PATH & "direction" & GFX_EXT)
            DirectionsSprite = New Sprite(DirectionsGfx)

            'Cache the width and height
            DirectionsGFXInfo.Width = DirectionsGfx.Size.X
            DirectionsGFXInfo.Height = DirectionsGfx.Size.Y
        End If

        WeatherGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "weather" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            WeatherGFX = New Texture(Application.StartupPath & GFX_PATH & "weather" & GFX_EXT)
            WeatherSprite = New Sprite(WeatherGFX)

            'Cache the width and height
            WeatherGFXInfo.Width = WeatherGFX.Size.X
            WeatherGFXInfo.Height = WeatherGFX.Size.Y
        End If

        HotBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\HotBar" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            HotBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\HotBar" & GFX_EXT)
            HotBarSprite = New Sprite(HotBarGFX)

            'Cache the width and height
            HotBarGFXInfo.Width = HotBarGFX.Size.X
            HotBarGFXInfo.Height = HotBarGFX.Size.Y
        End If

        ChatWindowGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Chat" & GFX_EXT) Then
            ChatWindowGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Chat" & GFX_EXT)
            ChatWindowSprite = New Sprite(ChatWindowGFX)

            'Cache the width and height
            ChatWindowGFXInfo.Width = ChatWindowGFX.Size.X
            ChatWindowGFXInfo.Height = ChatWindowGFX.Size.Y
        End If

        MyChatWindowGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "MyChat" & GFX_EXT) Then
            MyChatWindowGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "MyChat" & GFX_EXT)
            MyChatWindowSprite = New Sprite(MyChatWindowGFX)

            'Cache the width and height
            MyChatWindowGFXInfo.Width = MyChatWindowGFX.Size.X
            MyChatWindowGFXInfo.Height = MyChatWindowGFX.Size.Y
        End If

        ButtonGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Button" & GFX_EXT) Then
            ButtonGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Button" & GFX_EXT)
            ButtonSprite = New Sprite(ButtonGFX)

            'Cache the width and height
            ButtonGFXInfo.Width = ButtonGFX.Size.X
            ButtonGFXInfo.Height = ButtonGFX.Size.Y
        End If

        ButtonHoverGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Button_Hover" & GFX_EXT) Then
            ButtonHoverGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Button_Hover" & GFX_EXT)
            ButtonHoverSprite = New Sprite(ButtonHoverGFX)

            'Cache the width and height
            ButtonHoverGFXInfo.Width = ButtonHoverGFX.Size.X
            ButtonHoverGFXInfo.Height = ButtonHoverGFX.Size.Y
        End If

        HUDPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\HUD" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            HUDPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\HUD" & GFX_EXT)
            HUDPanelSprite = New Sprite(HUDPanelGFX)

            'Cache the width and height
            HUDPanelGFXInfo.Width = HUDPanelGFX.Size.X
            HUDPanelGFXInfo.Height = HUDPanelGFX.Size.Y
        End If

        HPBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "HPBar" & GFX_EXT) Then
            HPBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "HPBar" & GFX_EXT)
            HPBarSprite = New Sprite(HPBarGFX)

            'Cache the width and height
            HPBarGFXInfo.Width = HPBarGFX.Size.X
            HPBarGFXInfo.Height = HPBarGFX.Size.Y
        End If

        MPBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "MPBar" & GFX_EXT) Then
            MPBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "MPBar" & GFX_EXT)
            MPBarSprite = New Sprite(MPBarGFX)

            'Cache the width and height
            MPBarGFXInfo.Width = MPBarGFX.Size.X
            MPBarGFXInfo.Height = MPBarGFX.Size.Y
        End If

        EXPBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "EXPBar" & GFX_EXT) Then
            EXPBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "EXPBar" & GFX_EXT)
            EXPBarSprite = New Sprite(EXPBarGFX)

            'Cache the width and height
            EXPBarGFXInfo.Width = EXPBarGFX.Size.X
            EXPBarGFXInfo.Height = EXPBarGFX.Size.Y
        End If

        ActionPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "ActionBar\panel" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            ActionPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "ActionBar\panel" & GFX_EXT)
            ActionPanelSprite = New Sprite(ActionPanelGFX)

            'Cache the width and height
            ActionPanelGFXInfo.Width = ActionPanelGFX.Size.X
            ActionPanelGFXInfo.Height = ActionPanelGFX.Size.Y
        End If

        InvPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\inventory" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            InvPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\inventory" & GFX_EXT)
            InvPanelSprite = New Sprite(InvPanelGFX)

            'Cache the width and height
            InvPanelGFXInfo.Width = InvPanelGFX.Size.X
            InvPanelGFXInfo.Height = InvPanelGFX.Size.Y
        End If

        SkillPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\skills" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            SkillPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\skills" & GFX_EXT)
            SkillPanelSprite = New Sprite(SkillPanelGFX)

            'Cache the width and height
            SkillPanelGFXInfo.Width = SkillPanelGFX.Size.X
            SkillPanelGFXInfo.Height = SkillPanelGFX.Size.Y
        End If

        CharPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\char" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CharPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\char" & GFX_EXT)
            CharPanelSprite = New Sprite(CharPanelGFX)

            'Cache the width and height
            CharPanelGFXInfo.Width = CharPanelGFX.Size.X
            CharPanelGFXInfo.Height = CharPanelGFX.Size.Y
        End If

        CharPanelPlusGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\plus" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CharPanelPlusGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\plus" & GFX_EXT)
            CharPanelPlusSprite = New Sprite(CharPanelPlusGFX)

            'Cache the width and height
            CharPanelPlusGFXInfo.Width = CharPanelPlusGFX.Size.X
            CharPanelPlusGFXInfo.Height = CharPanelPlusGFX.Size.Y
        End If

        CharPanelMinGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\min" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            CharPanelMinGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\min" & GFX_EXT)
            CharPanelMinSprite = New Sprite(CharPanelMinGFX)

            'Cache the width and height
            CharPanelMinGFXInfo.Width = CharPanelMinGFX.Size.X
            CharPanelMinGFXInfo.Height = CharPanelMinGFX.Size.Y
        End If

        BankPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\Bank" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            BankPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\Bank" & GFX_EXT)
            BankPanelSprite = New Sprite(BankPanelGFX)

            'Cache the width and height
            BankPanelGFXInfo.Width = BankPanelGFX.Size.X
            BankPanelGFXInfo.Height = BankPanelGFX.Size.Y
        End If

        ShopPanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\Shop" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            ShopPanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\Shop" & GFX_EXT)
            ShopPanelSprite = New Sprite(ShopPanelGFX)

            'Cache the width and height
            ShopPanelGFXInfo.Width = ShopPanelGFX.Size.X
            ShopPanelGFXInfo.Height = ShopPanelGFX.Size.Y
        End If

        TradePanelGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\Trade" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            TradePanelGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\Trade" & GFX_EXT)
            TradePanelSprite = New Sprite(TradePanelGFX)

            'Cache the width and height
            TradePanelGFXInfo.Width = TradePanelGFX.Size.X
            TradePanelGFXInfo.Height = TradePanelGFX.Size.Y
        End If

        EventChatGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\EventChat" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            EventChatGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\EventChat" & GFX_EXT)
            EventChatSprite = New Sprite(EventChatGFX)

            'Cache the width and height
            EventChatGFXInfo.Width = EventChatGFX.Size.X
            EventChatGFXInfo.Height = EventChatGFX.Size.Y
        End If

        TargetGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "target" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            TargetGFX = New Texture(Application.StartupPath & GFX_PATH & "target" & GFX_EXT)
            TargetSprite = New Sprite(TargetGFX)

            'Cache the width and height
            TargetGFXInfo.Width = TargetGFX.Size.X
            TargetGFXInfo.Height = TargetGFX.Size.Y
        End If

        DescriptionGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Description" & GFX_EXT) Then
            DescriptionGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Description" & GFX_EXT)
            DescriptionSprite = New Sprite(DescriptionGFX)

            'Cache the width and height
            DescriptionGFXInfo.Width = DescriptionGFX.Size.X
            DescriptionGFXInfo.Height = DescriptionGFX.Size.Y
        End If

        RClickGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "RightClick" & GFX_EXT) Then
            RClickGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "RightClick" & GFX_EXT)
            RClickSprite = New Sprite(RClickGFX)

            'Cache the width and height
            RClickGFXInfo.Width = RClickGFX.Size.X
            RClickGFXInfo.Height = RClickGFX.Size.Y
        End If

        QuestGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "QuestLog" & GFX_EXT) Then
            QuestGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "QuestLog" & GFX_EXT)
            QuestSprite = New Sprite(QuestGFX)

            'Cache the width and height
            QuestGFXInfo.Width = QuestGFX.Size.X
            QuestGFXInfo.Height = QuestGFX.Size.Y
        End If

        CraftGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Craft" & GFX_EXT) Then
            CraftGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "Craft" & GFX_EXT)
            CraftSprite = New Sprite(CraftGFX)

            'Cache the width and height
            CraftGFXInfo.Width = CraftGFX.Size.X
            CraftGFXInfo.Height = CraftGFX.Size.Y
        End If

        ProgBarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\" & "ProgBar" & GFX_EXT) Then
            ProgBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\" & "ProgBar" & GFX_EXT)
            ProgBarSprite = New Sprite(ProgBarGFX)

            'Cache the width and height
            ProgBarGFXInfo.Width = ProgBarGFX.Size.X
            ProgBarGFXInfo.Height = ProgBarGFX.Size.Y
        End If

        ChatBubbleGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "ChatBubble" & GFX_EXT) Then
            ChatBubbleGFX = New Texture(Application.StartupPath & GFX_PATH & "ChatBubble" & GFX_EXT)
            ChatBubbleSprite = New Sprite(ChatBubbleGFX)
            'Cache the width and height
            ChatBubbleGFXInfo.Width = ChatBubbleGFX.Size.X
            ChatBubbleGFXInfo.Height = ChatBubbleGFX.Size.Y
        End If

        PetStatsGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\Pet" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            PetStatsGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\Pet" & GFX_EXT)
            PetStatsSprite = New Sprite(PetStatsGFX)

            'Cache the width and height
            PetStatsGFXInfo.Width = PetStatsGFX.Size.X
            PetStatsGFXInfo.Height = PetStatsGFX.Size.Y
        End If

        PetbarGFXInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Main\Petbar" & GFX_EXT) Then
            'Load texture first, dont care about memory streams (just use the filename)
            PetBarGFX = New Texture(Application.StartupPath & GFX_GUI_PATH & "Main\Petbar" & GFX_EXT)
            PetBarSprite = New Sprite(PetBarGFX)

            'Cache the width and height
            PetbarGFXInfo.Width = PetBarGFX.Size.X
            PetbarGFXInfo.Height = PetBarGFX.Size.Y
        End If

        LightGfxInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "Light" & GFX_EXT) Then
            LightGfx = New Texture(Application.StartupPath & GFX_PATH & "Light" & GFX_EXT)
            LightSprite = New Sprite(LightGfx)

            'Cache the width and height
            LightGfxInfo.Width = LightGfx.Size.X
            LightGfxInfo.Height = LightGfx.Size.Y
        End If

        ShadowGfxInfo = New GraphicInfo
        If FileExist(Application.StartupPath & GFX_PATH & "Shadow" & GFX_EXT) Then
            ShadowGfx = New Texture(Application.StartupPath & GFX_PATH & "Shadow" & GFX_EXT)
            ShadowSprite = New Sprite(ShadowGfx)

            'Cache the width and height
            ShadowGfxInfo.Width = ShadowGfx.Size.X
            ShadowGfxInfo.Height = ShadowGfx.Size.Y
        End If
    End Sub

    Public Sub LoadTexture(ByVal Index As Integer, ByVal TexType As Byte)

        If TexType = 1 Then 'tilesets
            If Index < 0 Or Index > NumTileSets Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            TileSetTexture(Index) = New Texture(Application.StartupPath & GFX_PATH & "tilesets\" & Index & GFX_EXT)
            TileSetSprite(Index) = New Sprite(TileSetTexture(Index))

            'Cache the width and height
            With TileSetTextureInfo(Index)
                .Width = TileSetTexture(Index).Size.X
                .Height = TileSetTexture(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 2 Then 'characters
            If Index < 0 Or Index > NumCharacters Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            CharacterGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "characters\" & Index & GFX_EXT)
            CharacterSprite(Index) = New Sprite(CharacterGFX(Index))

            'Cache the width and height
            With CharacterGFXInfo(Index)
                .Width = CharacterGFX(Index).Size.X
                .Height = CharacterGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 3 Then 'paperdoll
            If Index < 0 Or Index > NumPaperdolls Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            PaperDollGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Paperdolls\" & Index & GFX_EXT)
            PaperDollSprite(Index) = New Sprite(PaperDollGFX(Index))

            'Cache the width and height
            With PaperDollGFXInfo(Index)
                .Width = PaperDollGFX(Index).Size.X
                .Height = PaperDollGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 4 Then 'items
            If Index <= 0 Or Index > NumItems Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ItemsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "items\" & Index & GFX_EXT)
            ItemsSprite(Index) = New Sprite(ItemsGFX(Index))

            'Cache the width and height
            With ItemsGFXInfo(Index)
                .Width = ItemsGFX(Index).Size.X
                .Height = ItemsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 5 Then 'resources
            If Index < 0 Or Index > NumResources Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ResourcesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "resources\" & Index & GFX_EXT)
            ResourcesSprite(Index) = New Sprite(ResourcesGFX(Index))

            'Cache the width and height
            With ResourcesGFXInfo(Index)
                .Width = ResourcesGFX(Index).Size.X
                .Height = ResourcesGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 6 Then 'animations
            If Index <= 0 Or Index > NumAnimations Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            AnimationsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Animations\" & Index & GFX_EXT)
            AnimationsSprite(Index) = New Sprite(AnimationsGFX(Index))

            'Cache the width and height
            With AnimationsGFXInfo(Index)
                .Width = AnimationsGFX(Index).Size.X
                .Height = AnimationsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 7 Then 'faces
            If Index < 0 Or Index > NumFaces Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FacesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Faces\" & Index & GFX_EXT)
            FacesSprite(Index) = New Sprite(FacesGFX(Index))

            'Cache the width and height
            With FacesGFXInfo(Index)
                .Width = FacesGFX(Index).Size.X
                .Height = FacesGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 8 Then 'fogs
            If Index < 0 Or Index > NumFogs Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FogGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Fogs\" & Index & GFX_EXT)
            FogSprite(Index) = New Sprite(FogGFX(Index))

            'Cache the width and height
            With FogGFXInfo(Index)
                .Width = FogGFX(Index).Size.X
                .Height = FogGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 9 Then 'skill icons
            If Index <= 0 Or Index > NumSkillIcons Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            SkillIconsGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "SkillIcons\" & Index & GFX_EXT)
            SkillIconsSprite(Index) = New Sprite(SkillIconsGFX(Index))

            'Cache the width and height
            With SkillIconsGFXInfo(Index)
                .Width = SkillIconsGFX(Index).Size.X
                .Height = SkillIconsGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 10 Then 'furniture
            If Index < 0 Or Index > NumFurniture Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FurnitureGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Furniture\" & Index & GFX_EXT)
            FurnitureSprite(Index) = New Sprite(FurnitureGFX(Index))

            'Cache the width and height
            With FurnitureGFXInfo(Index)
                .Width = FurnitureGFX(Index).Size.X
                .Height = FurnitureGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 11 Then 'projectiles
            If Index < 0 Or Index > NumProjectiles Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ProjectileGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Projectiles\" & Index & GFX_EXT)
            ProjectileSprite(Index) = New Sprite(ProjectileGFX(Index))

            'Cache the width and height
            With ProjectileGFXInfo(Index)
                .Width = ProjectileGFX(Index).Size.X
                .Height = ProjectileGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf TexType = 12 Then 'emotes
            If Index < 0 Or Index > NumEmotes Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            EmotesGFX(Index) = New Texture(Application.StartupPath & GFX_PATH & "Emotes\" & Index & GFX_EXT)
            EmotesSprite(Index) = New Sprite(EmotesGFX(Index))

            'Cache the width and height
            With EmotesGFXInfo(Index)
                .Width = EmotesGFX(Index).Size.X
                .Height = EmotesGFX(Index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        End If

    End Sub
#End Region

    Public Sub DrawEmotes(ByVal x2 As Integer, ByVal y2 As Integer, ByVal Sprite As Integer)
        Dim rec As Rectangle
        Dim X As Integer, y As Integer, Anim As Integer
        'Dim width As Integer, height As Integer

        If Sprite < 1 Or Sprite > NumEmotes Then Exit Sub

        If EmotesGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 12)
        End If

        'seeying we still use it, lets update timer
        With EmotesGFXInfo(Sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        If ShowAnimLayers = True Then
            Anim = 1
        Else
            Anim = 0
        End If

        With rec
            .Y = 0
            .Height = PIC_X
            .X = Anim * (EmotesGFXInfo(Sprite).Width / 2)
            .Width = (EmotesGFXInfo(Sprite).Width / 2)
        End With

        X = ConvertMapX(x2)
        y = ConvertMapY(y2) - (PIC_Y + 16)

        RenderSprite(EmotesSprite(Sprite), GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

    Sub DrawChat()
        Dim i As Integer, x As Integer, y As Integer
        Dim text As String
        Dim strLen As Integer

        'first draw back image
        RenderSprite(ChatWindowSprite, GameWindow, ChatWindowX, ChatWindowY - 2, 0, 0, ChatWindowGFXInfo.Width, ChatWindowGFXInfo.Height)

        y = 5
        x = 5

        FirstLineIndex = (Chat.Count - MaxChatDisplayLines) - ScrollMod 'First element is the 5th from the last in the list
        If FirstLineIndex < 0 Then FirstLineIndex = 0 'if the list has less than 5 elements, the first is the 0th index or first element

        LastLineIndex = (FirstLineIndex + MaxChatDisplayLines) ' - ScrollMod
        If (LastLineIndex >= Chat.Count) Then LastLineIndex = Chat.Count - 1  'Based off of index 0, so the last element should be Chat.Count -1

        'only loop tru last entries
        For i = FirstLineIndex To LastLineIndex
            text = Chat(i).Text

            If text <> "" Then ' or not
                DrawText(ChatWindowX + x, ChatWindowY + y, text, GetSFMLColor(Chat(i).Color), SFML.Graphics.Color.Black, GameWindow)
                y = y + ChatLineSpacing + 1
            End If

        Next

        'My Text
        'first draw back image
        RenderSprite(MyChatWindowSprite, GameWindow, MyChatX, MyChatY - 5, 0, 0, MyChatWindowGFXInfo.Width, MyChatWindowGFXInfo.Height)

        If Len(MyText) > 0 Then
            strLen = MyText.Length - MyChatTextLimit
            If strLen < 0 Then strLen = 0
            Dim chatStr As String = MyText.PadRight(MyChatTextLimit).Substring(strLen, MyChatTextLimit)
            DrawText(MyChatX + 5, MyChatY - 3, chatStr, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        End If

    End Sub

    Public Sub DrawButton(ByVal Text As String, ByVal DestX As Integer, ByVal DestY As Integer, ByVal Hover As Byte)
        If Hover = 0 Then
            RenderSprite(ButtonSprite, GameWindow, DestX, DestY, 0, 0, ButtonGFXInfo.Width, ButtonGFXInfo.Height)

            DrawText(DestX + (ButtonGFXInfo.Width \ 2) - (GetTextWidth(Text) \ 2), DestY + (ButtonGFXInfo.Height \ 2) - (FONT_SIZE \ 2), Text, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        Else
            RenderSprite(ButtonHoverSprite, GameWindow, DestX, DestY, 0, 0, ButtonHoverGFXInfo.Width, ButtonHoverGFXInfo.Height)

            DrawText(DestX + (ButtonHoverGFXInfo.Width \ 2) - (GetTextWidth(Text) \ 2), DestY + (ButtonHoverGFXInfo.Height \ 2) - (FONT_SIZE \ 2), Text, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        End If

    End Sub

    Public Sub RenderSprite(ByVal TmpSprite As Sprite, ByVal Target As RenderWindow, ByVal DestX As Integer, ByVal DestY As Integer, ByVal SourceX As Integer, ByVal SourceY As Integer,
           ByVal SourceWidth As Integer, ByVal SourceHeight As Integer)

        If TmpSprite Is Nothing Then Exit Sub

        TmpSprite.TextureRect = New IntRect(SourceX, SourceY, SourceWidth, SourceHeight)
        TmpSprite.Position = New Vector2f(DestX, DestY)
        Target.Draw(TmpSprite)
    End Sub

    Public Sub RenderTextures(ByVal Txture As Texture, ByVal Target As RenderWindow, ByVal dX As Single, ByVal dY As Single, ByVal sx As Single, ByVal sy As Single, ByVal dWidth As Single, ByVal dHeight As Single, ByVal sWidth As Single, ByVal sHeight As Single)
        Dim TmpImage As Sprite = New Sprite(Txture)
        TmpImage.TextureRect = New IntRect(sx, sy, sWidth, sHeight)
        TmpImage.Scale = New Vector2f(dWidth / sWidth, dHeight / sHeight)
        TmpImage.Position = New Vector2f(dX, dY)
        Target.Draw(TmpImage)
    End Sub

    Public Sub DrawDirections(ByVal X As Integer, ByVal Y As Integer)
        Dim rec As Rectangle, i As Integer

        ' render grid
        rec.Y = 24
        rec.X = 0
        rec.Width = 32
        rec.Height = 32

        RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)

        ' render dir blobs
        For i = 1 To 4
            rec.X = (i - 1) * 8
            rec.Width = 8
            ' find out whether render blocked or not
            If Not IsDirBlocked(Map.Tile(X, Y).DirBlock, (i)) Then
                rec.Y = 8
            Else
                rec.Y = 16
            End If
            rec.Height = 8

            RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(X * PIC_X) + DirArrowX(i), ConvertMapY(Y * PIC_Y) + DirArrowY(i), rec.X, rec.Y, rec.Width, rec.Height)
        Next
    End Sub

    Public Function ConvertMapX(ByVal X As Integer) As Integer
        ConvertMapX = X - (TileView.left * PIC_X) - Camera.Left
    End Function

    Public Function ConvertMapY(ByVal Y As Integer) As Integer
        ConvertMapY = Y - (TileView.top * PIC_Y) - Camera.Top
    End Function

    Public Sub DrawPlayer(ByVal Index As Integer)
        Dim Anim As Byte, X As Integer, Y As Integer
        Dim Spritenum As Integer, spriteleft As Integer
        Dim attackspeed As Integer, AttackSprite As Byte
        Dim srcrec As Rectangle

        Spritenum = GetPlayerSprite(Index)

        AttackSprite = 0

        If Spritenum < 1 Or Spritenum > NumCharacters Then Exit Sub

        ' speed from weapon
        If GetPlayerEquipment(Index, EquipmentType.Weapon) > 0 Then
            attackspeed = Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Speed
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
                Case Direction.Up

                    If (Player(Index).YOffset > 8) Then Anim = Player(Index).Steps
                Case Direction.Down

                    If (Player(Index).YOffset < -8) Then Anim = Player(Index).Steps
                Case Direction.Left

                    If (Player(Index).XOffset > 8) Then Anim = Player(Index).Steps
                Case Direction.Right

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
            Case Direction.Up
                spriteleft = 3
            Case Direction.Right
                spriteleft = 2
            Case Direction.Down
                spriteleft = 0
            Case Direction.Left
                spriteleft = 1
        End Select

        If AttackSprite = 1 Then
            srcrec = New Rectangle((Anim) * (CharacterGFXInfo(Spritenum).Width / 5), spriteleft * (CharacterGFXInfo(Spritenum).Height / 4), (CharacterGFXInfo(Spritenum).Width / 5), (CharacterGFXInfo(Spritenum).Height / 4))
        Else
            srcrec = New Rectangle((Anim) * (CharacterGFXInfo(Spritenum).Width / 4), spriteleft * (CharacterGFXInfo(Spritenum).Height / 4), (CharacterGFXInfo(Spritenum).Width / 4), (CharacterGFXInfo(Spritenum).Height / 4))
        End If

        ' Calculate the X
        If AttackSprite = 1 Then
            X = GetPlayerX(Index) * PIC_X + Player(Index).XOffset - ((CharacterGFXInfo(Spritenum).Width / 5 - 32) / 2)
        Else
            X = GetPlayerX(Index) * PIC_X + Player(Index).XOffset - ((CharacterGFXInfo(Spritenum).Width / 4 - 32) / 2)
        End If

        ' Is the player's height more than 32..?
        If (CharacterGFXInfo(Spritenum).Height) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            Y = GetPlayerY(Index) * PIC_Y + Player(Index).YOffset - ((CharacterGFXInfo(Spritenum).Height / 4) - 32)
        Else
            ' Proceed as normal
            Y = GetPlayerY(Index) * PIC_Y + Player(Index).YOffset
        End If

        ' render the actual sprite
        DrawCharacter(Spritenum, X, Y, srcrec)

        'check for paperdolling
        For i = 1 To EquipmentType.Count - 1
            If GetPlayerEquipment(Index, i) > 0 Then
                If Item(GetPlayerEquipment(Index, i)).Paperdoll > 0 Then
                    DrawPaperdoll(X, Y, Item(GetPlayerEquipment(Index, i)).Paperdoll, Anim, spriteleft)
                End If
            End If
        Next

        ' Check to see if we want to stop showing emote
        With Player(Index)
            If .EmoteTimer < GetTickCount() Then
                .Emote = 0
                .EmoteTimer = 0
            End If
        End With

        'check for emotes
        'Player(Index).Emote = 4
        If Player(Index).Emote > 0 Then
            DrawEmotes(X, Y, Player(Index).Emote)
        End If
    End Sub

    Public Sub DrawPaperdoll(ByVal x2 As Integer, ByVal y2 As Integer, ByVal Sprite As Integer, ByVal Anim As Integer, ByVal spritetop As Integer)
        Dim rec As Rectangle
        Dim X As Integer, Y As Integer
        Dim width As Integer, height As Integer

        If Sprite < 1 Or Sprite > NumPaperdolls Then Exit Sub

        If PaperDollGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 3)
        End If

        ' we use it, lets update timer
        With PaperDollGFXInfo(Sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        With rec
            .Y = spritetop * (PaperDollGFXInfo(Sprite).Height / 4)
            .Height = (PaperDollGFXInfo(Sprite).Height / 4)
            .X = Anim * (PaperDollGFXInfo(Sprite).Width / 4)
            .Width = (PaperDollGFXInfo(Sprite).Width / 4)
        End With

        X = ConvertMapX(x2)
        Y = ConvertMapY(y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderSprite(PaperDollSprite(Sprite), GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

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

        srcrec = New Rectangle((anim) * (CharacterGFXInfo(Sprite).Width / 4), spriteleft * (CharacterGFXInfo(Sprite).Height / 4), (CharacterGFXInfo(Sprite).Width / 4), (CharacterGFXInfo(Sprite).Height / 4))

        ' Calculate the X
        X = MapNpc(MapNpcNum).X * PIC_X + MapNpc(MapNpcNum).XOffset - ((CharacterGFXInfo(Sprite).Width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (CharacterGFXInfo(Sprite).Height / 4) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            Y = MapNpc(MapNpcNum).Y * PIC_Y + MapNpc(MapNpcNum).YOffset - ((CharacterGFXInfo(Sprite).Height / 4) - 32)
        Else
            ' Proceed as normal
            Y = MapNpc(MapNpcNum).Y * PIC_Y + MapNpc(MapNpcNum).YOffset
        End If

        destrec = New Rectangle(X, Y, CharacterGFXInfo(Sprite).Width / 4, CharacterGFXInfo(Sprite).Height / 4)

        DrawCharacter(Sprite, X, Y, srcrec)

        If Npc(MapNpc(MapNpcNum).Num).Behaviour = NpcBehavior.Quest Then
            If CanStartQuest(Npc(MapNpc(MapNpcNum).Num).QuestNum) Then
                If Player(MyIndex).PlayerQuest(Npc(MapNpc(MapNpcNum).Num).QuestNum).Status = QuestStatus.NotStarted Then
                    DrawEmotes(X, Y, 5)
                End If
            ElseIf Player(MyIndex).PlayerQuest(Npc(MapNpc(MapNpcNum).Num).QuestNum).Status = QuestStatus.Started Then
                DrawEmotes(X, Y, 9)
            End If
        End If

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

        RenderSprite(ResourcesSprite(Resource), GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)

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
            .Height = ResourcesGFXInfo(Resource_sprite).Height
            .X = 0
            .Width = ResourcesGFXInfo(Resource_sprite).Width
        End With

        ' Set base x + y, then the offset due to size
        X = (MapResource(Resource_num).X * PIC_X) - (ResourcesGFXInfo(Resource_sprite).Width / 2) + 16
        Y = (MapResource(Resource_num).Y * PIC_Y) - ResourcesGFXInfo(Resource_sprite).Height + 32

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

        If ItemsGFXInfo(PicNum).Width > 32 Then ' has more than 1 frame
            srcrec = New Rectangle((MapItem(itemnum).Frame * 32), 0, 32, 32)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PIC_X), ConvertMapY(MapItem(itemnum).Y * PIC_Y), 32, 32)
        Else
            srcrec = New Rectangle(0, 0, PIC_X, PIC_Y)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PIC_X), ConvertMapY(MapItem(itemnum).Y * PIC_Y), PIC_X, PIC_Y)
        End If

        x = ConvertMapX(MapItem(itemnum).X * PIC_X)
        y = ConvertMapY(MapItem(itemnum).Y * PIC_Y)

        RenderSprite(ItemsSprite(PicNum), GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)

    End Sub

    Public Sub DrawCharacter(ByVal Sprite As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal rec As Rectangle)
        Dim X As Integer
        Dim y As Integer
        Dim width As Integer
        Dim height As Integer
        'On Error Resume Next

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

        'shadow first
        RenderSprite(ShadowSprite, GameWindow, X - 1, y + 6, 0, 0, ShadowGfxInfo.Width, ShadowGfxInfo.Height)

        RenderSprite(CharacterSprite(Sprite), GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

    Public Sub DrawBlood(ByVal Index As Integer)
        Dim dest As Point = New Point(FrmMainGame.PointToScreen(FrmMainGame.picscreen.Location))
        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim x As Integer
        Dim y As Integer

        With Blood(Index)
            If .X < TileView.left Or .X > TileView.right Then Exit Sub
            If .Y < TileView.top Or .Y > TileView.bottom Then Exit Sub

            ' check if we should be seeing it
            If .Timer + 20000 < GetTickCount() Then Exit Sub

            x = ConvertMapX(Blood(Index).X * PIC_X)
            y = ConvertMapY(Blood(Index).Y * PIC_Y)

            srcrec = New Rectangle((.Sprite - 1) * PIC_X, 0, PIC_X, PIC_Y)

            destrec = New Rectangle(ConvertMapX(.X * PIC_X), ConvertMapY(.Y * PIC_Y), PIC_X, PIC_Y)

            RenderSprite(BloodSprite, GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)

        End With

    End Sub

    Public Sub DrawMapTile(ByVal X As Integer, ByVal Y As Integer)
        Dim i As Integer
        Dim srcrect As New Rectangle(0, 0, 0, 0)

        If GettingMap Then Exit Sub
        If Map.Tile Is Nothing Then Exit Sub

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

                        RenderSprite(TileSetSprite(.Layer(i).Tileset), GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)

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
        Dim dest As Rectangle = New Rectangle(FrmMainGame.PointToScreen(FrmMainGame.picscreen.Location), New Size(32, 32))

        If GettingMap Then Exit Sub
        If Map.Tile Is Nothing Then Exit Sub

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

                        RenderSprite(TileSetSprite(.Layer(i).Tileset), GameWindow, ConvertMapX(X * PIC_X), ConvertMapY(Y * PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height)

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

        offsetX = Player(MyIndex).XOffset + PIC_X
        offsetY = Player(MyIndex).YOffset + PIC_Y
        StartX = GetPlayerX(MyIndex) - ((SCREEN_MAPX + 1) \ 2) - 1
        StartY = GetPlayerY(MyIndex) - ((SCREEN_MAPY + 1) \ 2) - 1

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

        EndX = StartX + (SCREEN_MAPX + 1) + 1
        EndY = StartY + (SCREEN_MAPY + 1) + 1

        If EndX > Map.MaxX Then
            offsetX = 32

            If EndX = Map.MaxX + 1 Then
                If Player(MyIndex).XOffset < 0 Then
                    offsetX = Player(MyIndex).XOffset + PIC_X
                End If
            End If

            EndX = Map.MaxX
            StartX = EndX - SCREEN_MAPX - 1
        End If

        If EndY > Map.MaxY Then
            offsetY = 32

            If EndY = Map.MaxY + 1 Then
                If Player(MyIndex).YOffset < 0 Then
                    offsetY = Player(MyIndex).YOffset + PIC_Y
                End If
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
                    TileSetSprite(I).Dispose()
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
                    CharacterSprite(I).Dispose()
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
                    PaperDollSprite(I).Dispose()
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
                    ItemsSprite(I).Dispose()
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
                    ResourcesSprite(I).Dispose()
                    ResourcesGFXInfo(I).IsLoaded = False
                    ResourcesGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'animations
        For I = 1 To NumAnimations
            If AnimationsGFXInfo(I).IsLoaded Then
                If AnimationsGFXInfo(I).TextureTimer < GetTickCount() Then
                    AnimationsGFX(I).Dispose()
                    AnimationsGFXInfo(I).IsLoaded = False
                    AnimationsGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear faces
        For I = 1 To NumFaces
            If FacesGFXInfo(I).IsLoaded Then
                If FacesGFXInfo(I).TextureTimer < GetTickCount() Then
                    FacesGFX(I).Dispose()
                    FacesSprite(I).Dispose()
                    FacesGFXInfo(I).IsLoaded = False
                    FacesGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear fogs
        For I = 1 To NumFogs
            If FogGFXInfo(I).IsLoaded Then
                If FogGFXInfo(I).TextureTimer < GetTickCount() Then
                    FogGFX(I).Dispose()
                    FogGFXInfo(I).IsLoaded = False
                    FogGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear SkillIcons
        For I = 1 To NumSkillIcons
            If SkillIconsGFXInfo(I).IsLoaded Then
                If SkillIconsGFXInfo(I).TextureTimer < GetTickCount() Then
                    SkillIconsGFX(I).Dispose()
                    SkillIconsSprite(I).Dispose()
                    SkillIconsGFXInfo(I).IsLoaded = False
                    SkillIconsGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear Furniture
        For I = 1 To NumFurniture
            If FurnitureGFXInfo(I).IsLoaded Then
                If FurnitureGFXInfo(I).TextureTimer < GetTickCount() Then
                    FurnitureGFX(I).Dispose()
                    FurnitureSprite(I).Dispose()
                    FurnitureGFXInfo(I).IsLoaded = False
                    FurnitureGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear Projectiles
        For I = 1 To NumProjectiles
            If ProjectileGFXInfo(I).IsLoaded Then
                If ProjectileGFXInfo(I).TextureTimer < GetTickCount() Then
                    ProjectileGFX(I).Dispose()
                    ProjectileSprite(I).Dispose()
                    ProjectileGFXInfo(I).IsLoaded = False
                    ProjectileGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next

        'clear Emotes
        For I = 1 To NumEmotes
            If EmotesGFXInfo(I).IsLoaded Then
                If EmotesGFXInfo(I).TextureTimer < GetTickCount() Then
                    EmotesGFX(I).Dispose()
                    EmotesSprite(I).Dispose()
                    EmotesGFXInfo(I).IsLoaded = False
                    EmotesGFXInfo(I).TextureTimer = 0
                End If
            End If
        Next
    End Sub

    Public Sub Render_Graphics()
        Dim X As Integer, Y As Integer, I As Integer

        'Don't Render IF
        If FrmMainGame.WindowState = FormWindowState.Minimized Then Exit Sub
        If GettingMap Then Exit Sub

        'lets get going

        'update view around player
        UpdateCamera()

        'let program do other things
        DoEvents()

        'Clear each of our render targets
        GameWindow.DispatchEvents()
        GameWindow.Clear(SFML.Graphics.Color.Black)

        'If CurMouseX > 0 AndAlso CurMouseX <= GameWindow.Size.X Then
        '    If CurMouseY > 0 AndAlso CurMouseY <= GameWindow.Size.Y Then
        '        GameWindow.SetMouseCursorVisible(False)
        '    End If
        'End If

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

        ' events
        If Map.CurrentEvents > 0 And Map.CurrentEvents <= Map.EventCount Then

            For I = 1 To Map.CurrentEvents
                If Map.MapEvents(I).Position = 0 Then
                    DrawEvent(I)
                End If
            Next
        End If

        'blood
        For I = 1 To Byte.MaxValue
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

        'Draw sum d00rs.
        If GettingMap Then Exit Sub

        For X = TileView.left To TileView.right
            For Y = TileView.top To TileView.bottom
                If IsValidMapPoint(X, Y) Then
                    If Map.Tile Is Nothing Then Exit Sub
                    If Map.Tile(X, Y).Type = TileType.Door Then
                        DrawDoor(X, Y)
                    End If
                End If
            Next
        Next

        ' draw animations
        If NumAnimations > 0 Then
            For I = 1 To Byte.MaxValue
                If AnimInstance(I).Used(0) Then
                    DrawAnimation(I, 0)
                End If
            Next
        End If

        ' Y-based render. Renders Players, Npcs and Resources based on Y-axis.
        For Y = 0 To Map.MaxY

            If NumCharacters > 0 Then
                ' Players
                For I = 1 To TotalOnline 'MAX_PLAYERS
                    If IsPlaying(I) And GetPlayerMap(I) = GetPlayerMap(MyIndex) Then
                        If Player(I).Y = Y Then
                            DrawPlayer(I)
                        End If
                        If PetAlive(I) Then
                            If Player(I).Pet.Y = Y Then
                                DrawPet(I)
                            End If
                        End If
                    End If
                Next

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

                ' Draw the target icon
                If myTarget > 0 Then
                    If myTargetType = TargetType.Player Then
                        DrawTarget(Player(myTarget).X * 32 - 16 + Player(myTarget).XOffset, Player(myTarget).Y * 32 + Player(myTarget).YOffset)
                    ElseIf myTargetType = TargetType.Npc Then
                        DrawTarget(MapNpc(myTarget).X * 32 - 16 + MapNpc(myTarget).XOffset, MapNpc(myTarget).Y * 32 + MapNpc(myTarget).YOffset)
                    ElseIf myTargetType = TargetType.Pet Then
                        DrawTarget(Player(myTarget).Pet.X * 32 - 16 + Player(myTarget).Pet.XOffset, (Player(myTarget).Pet.Y * 32) + Player(myTarget).Pet.YOffset)
                    End If
                End If

                For I = 1 To TotalOnline 'MAX_PLAYERS
                    If IsPlaying(I) Then
                        If Player(I).Map = Player(MyIndex).Map Then
                            If CurX = Player(I).X And CurY = Player(I).Y Then
                                If myTargetType = TargetType.Player And myTarget = I Then
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
            For I = 1 To Byte.MaxValue
                If AnimInstance(I - 1).Used(1) Then
                    DrawAnimation(I - 1, 1)
                End If
            Next
        End If

        'projectiles
        If NumProjectiles > 0 Then
            For I = 1 To MAX_PROJECTILES
                If MapProjectiles(I).ProjectileNum > 0 Then
                    DrawProjectile(I)
                End If
            Next
        End If

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

        DrawNight()

        DrawWeather()
        DrawThunderEffect()
        DrawMapTint()

        ' Draw out a square at mouse cursor
        If MapGrid = True AndAlso InMapEditor Then
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

        If InMapEditor Then DrawTileOutline()

        'furniture
        If FurnitureSelected > 0 Then
            If Player(MyIndex).InHouse = MyIndex Then
                DrawFurnitureOutline()
            End If
        End If

        ' draw cursor, player X and Y locations
        If BLoc Then
            DrawText(1, HUDWindowY + HUDPanelGFXInfo.Height + 1, Trim$(Strings.Get("gamegui", "curloc", CurX, CurY)), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
            DrawText(1, HUDWindowY + HUDPanelGFXInfo.Height + 15, Trim$(Strings.Get("gamegui", "loc", GetPlayerX(MyIndex), GetPlayerY(MyIndex))), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
            DrawText(1, HUDWindowY + HUDPanelGFXInfo.Height + 30, Trim$(Strings.Get("gamegui", "curmap", GetPlayerMap(MyIndex))), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
        End If

        ' draw player names
        For I = 1 To TotalOnline 'MAX_PLAYERS
            If IsPlaying(I) And GetPlayerMap(I) = GetPlayerMap(MyIndex) Then
                DrawPlayerName(I)
                If PetAlive(I) Then
                    DrawPlayerPetName(I)
                End If
            End If
        Next

        'draw event names
        For I = 1 To Map.CurrentEvents
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

        ' draw the messages
        For I = 1 To Byte.MaxValue
            If chatBubble(I).active Then
                DrawChatBubble(I)
            End If
        Next

        'action msg
        For I = 1 To Byte.MaxValue
            DrawActionMsg(I)
        Next I

        ' Blit out map attributes
        If InMapEditor Then
            DrawMapAttributes()
        End If

        If InMapEditor And frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpEvents Then
            DrawEvents()
            EditorEvent_DrawGraphic()
        End If

        If GettingMap Then Exit Sub

        'draw hp and casting bars
        DrawBars()

        'party
        DrawParty()

        'Render GUI
        DrawGUI()

        'and finally show everything on screen
        GameWindow.Display()
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
            rec2.Size = New Vector2f(rec.Width, rec.Height)
        Else
            If TileSetTextureInfo(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1).IsLoaded = False Then
                LoadTexture(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1, 1)
            End If
            ' we use it, lets update timer
            With TileSetTextureInfo(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1)
                .TextureTimer = GetTickCount() + 100000
            End With

            If EditorTileWidth = 1 And EditorTileHeight = 1 Then
                RenderSprite(TileSetSprite(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, rec.Width, rec.Height)

                rec2.Size = New Vector2f(rec.Width, rec.Height)
            Else
                If frmEditor_MapEditor.cmbAutoTile.SelectedIndex > 0 Then
                    RenderSprite(TileSetSprite(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, rec.Width, rec.Height)

                    rec2.Size = New Vector2f(rec.Width, rec.Height)
                Else
                    RenderSprite(TileSetSprite(frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y, EditorTileSelEnd.X * PIC_X, EditorTileSelEnd.Y * PIC_Y)

                    rec2.Size = New Vector2f(EditorTileSelEnd.X * PIC_X, EditorTileSelEnd.Y * PIC_Y)
                End If

            End If

        End If

        rec2.Position = New Vector2f(ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y))
        GameWindow.Draw(rec2)
    End Sub

    Public Sub DrawBars()
        Dim tmpY As Integer
        Dim tmpX As Integer
        Dim barWidth As Integer
        Dim rec(1) As Rectangle

        If GettingMap Then Exit Sub

        ' check for casting time bar
        If SkillBuffer > 0 Then
            ' lock to player
            tmpX = GetPlayerX(MyIndex) * PIC_X + Player(MyIndex).XOffset
            tmpY = GetPlayerY(MyIndex) * PIC_Y + Player(MyIndex).YOffset + 35
            If Skill(PlayerSkills(SkillBuffer)).CastTime = 0 Then Skill(PlayerSkills(SkillBuffer)).CastTime = 1
            ' calculate the width to fill
            barWidth = ((GetTickCount() - SkillBufferTimer) / ((GetTickCount() - SkillBufferTimer) + (Skill(PlayerSkills(SkillBuffer)).CastTime * 1000)) * 64)
            ' draw bars
            rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
            Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4))
            rectShape.Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY))
            rectShape.FillColor = SFML.Graphics.Color.Cyan
            GameWindow.Draw(rectShape)
        End If

        If Options.ShowNpcBar = 1 Then
            ' check for hp bar
            For i = 1 To MAX_MAP_NPCS
                If Map.Npc Is Nothing Then Exit Sub
                If Map.Npc(i) > 0 Then
                    If Npc(MapNpc(i).Num).Behaviour = NpcBehavior.AttackOnSight Or Npc(MapNpc(i).Num).Behaviour = NpcBehavior.AttackWhenAttacked Or Npc(MapNpc(i).Num).Behaviour = NpcBehavior.Guard Then
                        ' lock to npc
                        tmpX = MapNpc(i).X * PIC_X + MapNpc(i).XOffset
                        tmpY = MapNpc(i).Y * PIC_Y + MapNpc(i).YOffset + 35
                        If MapNpc(i).Vital(Vitals.HP) > 0 Then
                            ' calculate the width to fill
                            barWidth = ((MapNpc(i).Vital(Vitals.HP) / (Npc(MapNpc(i).Num).HP) * 32))
                            ' draw bars
                            rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                            Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4))
                            rectShape.Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 75))
                            rectShape.FillColor = SFML.Graphics.Color.Red
                            GameWindow.Draw(rectShape)

                            If MapNpc(i).Vital(Vitals.MP) > 0 Then
                                ' calculate the width to fill
                                barWidth = ((MapNpc(i).Vital(Vitals.MP) / (Npc(MapNpc(i).Num).Stat(Stats.Intelligence) * 2) * 32))
                                ' draw bars
                                rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                                Dim rectShape2 As New RectangleShape(New Vector2f(barWidth, 4))
                                rectShape2.Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 80))
                                rectShape2.FillColor = SFML.Graphics.Color.Blue
                                GameWindow.Draw(rectShape2)
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If PetAlive(MyIndex) Then
            ' draw own health bar
            If Player(MyIndex).Pet.Health > 0 And Player(MyIndex).Pet.Health <= Player(MyIndex).Pet.MaxHp Then
                ' lock to Player
                tmpX = Player(MyIndex).Pet.X * PIC_X + Player(MyIndex).Pet.XOffset
                tmpY = Player(MyIndex).Pet.Y * PIC_X + Player(MyIndex).Pet.YOffset + 35
                ' calculate the width to fill
                barWidth = ((Player(MyIndex).Pet.Health) / (Player(MyIndex).Pet.MaxHp)) * 32
                ' draw bars
                rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4))
                rectShape.Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 75))
                rectShape.FillColor = SFML.Graphics.Color.Red
                GameWindow.Draw(rectShape)
            End If
        End If
        ' check for pet casting time bar
        If PetSkillBuffer > 0 Then
            If Skill(Pet(Player(MyIndex).Pet.Num).Skill(PetSkillBuffer)).CastTime > 0 Then
                ' lock to pet
                tmpX = Player(MyIndex).Pet.X * PIC_X + Player(MyIndex).Pet.XOffset
                tmpY = Player(MyIndex).Pet.Y * PIC_Y + Player(MyIndex).Pet.YOffset + 35

                ' calculate the width to fill
                barWidth = (GetTickCount() - PetSkillBufferTimer) / ((Skill(Pet(Player(MyIndex).Pet.Num).Skill(PetSkillBuffer)).CastTime * 1000)) * 64
                ' draw bar background
                rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4))
                rectShape.Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY))
                rectShape.FillColor = SFML.Graphics.Color.Cyan
                GameWindow.Draw(rectShape)
            End If
        End If
    End Sub

    Sub DrawMapName()
        DrawText(DrawMapNameX, DrawMapNameY, Strings.Get("gamegui", "mapname") & Map.Name, DrawMapNameColor, SFML.Graphics.Color.Black, GameWindow)
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
            .Height = DoorGFXInfo.Height
            .X = ((TempTile(X, Y).DoorFrame - 1) * DoorGFXInfo.Width / 4)
            .Width = DoorGFXInfo.Width / 4
        End With

        x2 = (X * PIC_X)
        y2 = (Y * PIC_Y) - (DoorGFXInfo.Height / 2) + 4

        RenderSprite(DoorSprite, GameWindow, ConvertMapX(X * PIC_X), ConvertMapY((Y * PIC_Y) - PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

    Public Sub DrawAnimation(ByVal Index As Integer, ByVal Layer As Integer)

        Dim Sprite As Integer
        Dim sRECT As Rectangle
        Dim width As Integer, height As Integer
        Dim FrameCount As Integer
        Dim X As Integer, Y As Integer
        Dim lockindex As Integer

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

        If FrameCount <= 0 Then Exit Sub

        ' total width divided by frame count
        width = AnimationsGFXInfo(Sprite).Width / FrameCount
        height = AnimationsGFXInfo(Sprite).Height

        sRECT.Y = 0
        sRECT.Height = height
        sRECT.X = (AnimInstance(Index).FrameIndex(Layer) - 1) * width
        sRECT.Width = width

        ' change x or y if locked
        If AnimInstance(Index).LockType > TargetType.None Then ' if <> none
            ' is a player
            If AnimInstance(Index).LockType = TargetType.Player Then
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
            ElseIf AnimInstance(Index).LockType = TargetType.Npc Then
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
            ElseIf AnimInstance(Index).LockType = TargetType.Pet Then
                ' quick save the index
                lockindex = AnimInstance(Index).lockindex
                ' check if is ingame
                If IsPlaying(lockindex) And PetAlive(lockindex) = True Then
                    ' check if on same map
                    If GetPlayerMap(lockindex) = GetPlayerMap(MyIndex) Then
                        ' is on map, is playing, set x & y
                        X = (Player(lockindex).Pet.X * PIC_X) + 16 - (width / 2) + Player(lockindex).Pet.XOffset
                        Y = (Player(lockindex).Pet.Y * PIC_Y) + 16 - (height / 2) + Player(lockindex).Pet.YOffset
                    End If
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

        RenderSprite(AnimationsSprite(Sprite), GameWindow, X, Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)

    End Sub

    Public Sub DrawFurnitureOutline()
        Dim rec As Rectangle

        With rec
            .Y = 0
            .Height = Item(GetPlayerInvItemNum(MyIndex, FurnitureSelected)).FurnitureHeight * PIC_Y
            .X = 0
            .Width = Item(GetPlayerInvItemNum(MyIndex, FurnitureSelected)).FurnitureWidth * PIC_X
        End With

        Dim rec2 As New RectangleShape
        rec2.OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue)
        rec2.OutlineThickness = 0.6
        rec2.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
        rec2.Size = New Vector2f(rec.Width, rec.Height)
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

        If Map.HasMapTint = 0 Then Exit Sub

        MapTintSprite = New Sprite(New Texture(New SFML.Graphics.Image(GameWindow.Size.X, GameWindow.Size.Y, SFML.Graphics.Color.White)))
        MapTintSprite.Color = New SFML.Graphics.Color(CurrentTintR, CurrentTintG, CurrentTintB, CurrentTintA)
        MapTintSprite.TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y)

        MapTintSprite.Position = New Vector2f(0, 0)

        GameWindow.Draw(MapTintSprite)

    End Sub

    Sub DestroyGraphics()

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

        For i = 0 To NumProjectiles
            If Not ProjectileGFX(i) Is Nothing Then ProjectileGFX(i).Dispose()
        Next

        For i = 0 To NumEmotes
            If Not EmotesGFX(i) Is Nothing Then EmotesGFX(i).Dispose()
        Next

        If Not CursorGFX Is Nothing Then CursorGFX.Dispose()
        If Not DoorGFX Is Nothing Then DoorGFX.Dispose()
        If Not BloodGFX Is Nothing Then BloodGFX.Dispose()
        If Not DirectionsGfx Is Nothing Then DirectionsGfx.Dispose()
        If Not ActionPanelGFX Is Nothing Then ActionPanelGFX.Dispose()
        If Not InvPanelGFX Is Nothing Then InvPanelGFX.Dispose()
        If Not CharPanelGFX Is Nothing Then CharPanelGFX.Dispose()
        If Not CharPanelPlusGFX Is Nothing Then CharPanelPlusGFX.Dispose()
        If Not CharPanelMinGFX Is Nothing Then CharPanelMinGFX.Dispose()
        If Not TargetGFX Is Nothing Then TargetGFX.Dispose()
        If Not WeatherGFX Is Nothing Then WeatherGFX.Dispose()
        If Not HotBarGFX Is Nothing Then HotBarGFX.Dispose()
        If Not ChatWindowGFX Is Nothing Then ChatWindowGFX.Dispose()
        If Not BankPanelGFX Is Nothing Then BankPanelGFX.Dispose()
        If Not ShopPanelGFX Is Nothing Then ShopPanelGFX.Dispose()
        If Not TradePanelGFX Is Nothing Then TradePanelGFX.Dispose()
        If Not EventChatGFX Is Nothing Then EventChatGFX.Dispose()
        If Not RClickGFX Is Nothing Then RClickGFX.Dispose()
        If Not ButtonGFX Is Nothing Then ButtonGFX.Dispose()
        If Not ButtonHoverGFX Is Nothing Then ButtonHoverGFX.Dispose()
        If Not QuestGFX Is Nothing Then QuestGFX.Dispose()
        If Not CraftGFX Is Nothing Then CraftGFX.Dispose()
        If Not ProgBarGFX Is Nothing Then ProgBarGFX.Dispose()
        If Not ChatBubbleGFX Is Nothing Then ChatBubbleGFX.Dispose()

        If Not HPBarGFX Is Nothing Then HPBarGFX.Dispose()
        If Not MPBarGFX Is Nothing Then MPBarGFX.Dispose()
        If Not EXPBarGFX Is Nothing Then EXPBarGFX.Dispose()

        If Not LightGfx Is Nothing Then LightGfx.Dispose()
        If Not NightGfx Is Nothing Then NightGfx.Dispose()

    End Sub

    Sub DrawHUD()
        Dim rec As Rectangle

        'first render backpanel
        With rec
            .Y = 0
            .Height = HUDPanelGFXInfo.Height
            .X = 0
            .Width = HUDPanelGFXInfo.Width
        End With

        RenderSprite(HUDPanelSprite, GameWindow, HUDWindowX, HUDWindowY, rec.X, rec.Y, rec.Width, rec.Height)

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
                .Height = FacesGFXInfo(Player(MyIndex).Sprite).Height
                .X = 0
                .Width = FacesGFXInfo(Player(MyIndex).Sprite).Width
            End With

            RenderSprite(FacesSprite(Player(MyIndex).Sprite), GameWindow, HUDFaceX, HUDFaceY, rec.X, rec.Y, rec.Width, rec.Height)
        End If

        'Hp Bar etc
        DrawStatBars()

        'Fps etc
        DrawText(HUDWindowX + HUDHPBarX + HPBarGFXInfo.Width + 10, HUDWindowY + HUDHPBarY + 4, Strings.Get("gamegui", "fps") & FPS, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        DrawText(HUDWindowX + HUDMPBarX + MPBarGFXInfo.Width + 10, HUDWindowY + HUDMPBarY + 4, Strings.Get("gamegui", "ping") & PingToDraw, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        DrawText(HUDWindowX + HUDEXPBarX + EXPBarGFXInfo.Width + 10, HUDWindowY + HUDEXPBarY + 4, Strings.Get("gamegui", "clock") & CurTime, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        If BLPS Then
            DrawText(HUDWindowX + HUDEXPBarX + EXPBarGFXInfo.Width + 10, HUDWindowY + HUDEXPBarY + 20, Strings.Get("gamegui", "lps") & LPS, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        End If

        ' Draw map name
        DrawMapName()
    End Sub

    Sub DrawStatBars()
        Dim rec As Rectangle
        Dim CurHP As Integer, CurMP As Integer, CurEXP As Integer

        'HP Bar
        CurHP = (GetPlayerVital(MyIndex, 1) / GetPlayerMaxVital(MyIndex, 1)) * 100

        With rec
            .Y = 0
            .Height = HPBarGFXInfo.Height
            .X = 0
            .Width = CurHP * HPBarGFXInfo.Width / 100
        End With

        'then render full ontop of it
        RenderSprite(HPBarSprite, GameWindow, HUDWindowX + HUDHPBarX, HUDWindowY + HUDHPBarY + 4, rec.X, rec.Y, rec.Width, rec.Height)

        'then draw the text onto that
        DrawText(HUDWindowX + HUDHPBarX + 65, HUDWindowY + HUDHPBarY + 4, GetPlayerVital(MyIndex, 1) & "/" & GetPlayerMaxVital(MyIndex, 1), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        '==============================

        'MP Bar
        CurMP = (GetPlayerVital(MyIndex, 2) / GetPlayerMaxVital(MyIndex, 2)) * 100

        'then render full ontop of it
        With rec
            .Y = 0
            .Height = MPBarGFXInfo.Height
            .X = 0
            .Width = CurMP * MPBarGFXInfo.Width / 100
        End With

        RenderSprite(MPBarSprite, GameWindow, HUDWindowX + HUDMPBarX, HUDWindowY + HUDMPBarY + 4, rec.X, rec.Y, rec.Width, rec.Height)

        'draw text onto that
        DrawText(HUDWindowX + HUDMPBarX + 65, HUDWindowY + HUDMPBarY + 4, GetPlayerVital(MyIndex, 2) & "/" & GetPlayerMaxVital(MyIndex, 2), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        '====================================================
        'EXP Bar
        CurEXP = (GetPlayerExp(MyIndex) / NextlevelExp) * 100

        'then render full ontop of it
        With rec
            .Y = 0
            .Height = EXPBarGFXInfo.Height
            .X = 0
            .Width = CurEXP * EXPBarGFXInfo.Width / 100
        End With

        RenderSprite(EXPBarSprite, GameWindow, HUDWindowX + HUDEXPBarX, HUDWindowY + HUDEXPBarY + 4, rec.X, rec.Y, rec.Width, rec.Height)

        'draw text onto that
        DrawText(HUDWindowX + HUDEXPBarX + 65, HUDWindowY + HUDEXPBarY + 4, GetPlayerExp(MyIndex) & "/" & NextlevelExp, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
    End Sub

    Sub DrawActionPanel()
        Dim rec As Rectangle

        'first render backpanel
        With rec
            .Y = 0
            .Height = ActionPanelGFXInfo.Height
            .X = 0
            .Width = ActionPanelGFXInfo.Width
        End With

        RenderSprite(ActionPanelSprite, GameWindow, ActionPanelX, ActionPanelY, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

    Sub DrawEquipment()
        Dim i As Integer, itemnum As Integer, itempic As Integer, tmprarity As Byte
        Dim rec As Rectangle, rec_pos As Rectangle, playersprite As Integer
        Dim tmpSprite2 As Sprite = New Sprite(CharPanelGFX)
        Dim tempRarityColor As SFML.Graphics.Color

        If NumItems = 0 Then Exit Sub

        'first render panel
        RenderSprite(CharPanelSprite, GameWindow, CharWindowX, CharWindowY, 0, 0, CharPanelGFXInfo.Width, CharPanelGFXInfo.Height)

        'lets get player sprite to render
        playersprite = GetPlayerSprite(MyIndex)

        With rec
            .Y = 0
            .Height = CharacterGFXInfo(playersprite).Height / 4
            .X = 0
            .Width = CharacterGFXInfo(playersprite).Width / 4
        End With

        RenderSprite(CharacterSprite(playersprite), GameWindow, CharWindowX + CharPanelGFXInfo.Width / 4 - rec.Width / 2, CharWindowY + CharPanelGFXInfo.Height / 2 - rec.Height / 2, rec.X, rec.Y, rec.Width, rec.Height)

        For i = 1 To EquipmentType.Count - 1
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
                    .X = CharWindowX + EqLeft + 1 + ((EqOffsetX + 32 - 2) * (((i - 1) Mod EqColumns)))
                    .Width = PIC_X
                End With

                ItemsSprite(itempic).TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                ItemsSprite(itempic).Position = New Vector2f(rec_pos.X, rec_pos.Y)
                GameWindow.Draw(ItemsSprite(itempic))

                ' set the name
                If Item(itemnum).Randomize <> 0 Then
                    tmprarity = Player(MyIndex).RandEquip(i).Rarity
                Else
                    tmprarity = Item(itemnum).Rarity
                End If

                Select Case tmprarity
                    Case 0 ' White
                        tempRarityColor = ITEM_RARITY_COLOR_0
                    Case 1 ' green
                        tempRarityColor = ITEM_RARITY_COLOR_1
                    Case 2 ' blue
                        tempRarityColor = ITEM_RARITY_COLOR_2
                    Case 3 ' maroon
                        tempRarityColor = ITEM_RARITY_COLOR_3
                    Case 4 ' purple
                        tempRarityColor = ITEM_RARITY_COLOR_4
                    Case 5 'gold
                        tempRarityColor = ITEM_RARITY_COLOR_5
                End Select

                Dim rec2 As New RectangleShape
                rec2.OutlineColor = New SFML.Graphics.Color(tempRarityColor)
                rec2.OutlineThickness = 2
                rec2.FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
                rec2.Size = New Vector2f(30, 30)
                rec2.Position = New Vector2f(rec_pos.X, rec_pos.Y)
                GameWindow.Draw(rec2)
            End If

        Next

        ' Set the character windows
        'name
        DrawText(CharWindowX + 10, CharWindowY + 14, Strings.Get("charwindow", "charname") & GetPlayerName(MyIndex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'class
        DrawText(CharWindowX + 10, CharWindowY + 33, Strings.Get("charwindow", "charclass") & Trim(Classes(GetPlayerClass(MyIndex)).Name), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'level
        DrawText(CharWindowX + 150, CharWindowY + 14, Strings.Get("charwindow", "charlvl") & GetPlayerLevel(MyIndex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'points
        DrawText(CharWindowX + 6, CharWindowY + 200, Strings.Get("charwindow", "charpoints") & GetPlayerPOINTS(MyIndex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'Header
        DrawText(CharWindowX + 250, CharWindowY + 14, Strings.Get("charwindow", "charstatslbl"), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'strength stat
        DrawText(CharWindowX + 210, CharWindowY + 30, Strings.Get("charwindow", "charstrength") & GetPlayerStat(MyIndex, Stats.Strength), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'endurance stat
        DrawText(CharWindowX + 210, CharWindowY + 50, Strings.Get("charwindow", "charendurance") & GetPlayerStat(MyIndex, Stats.Endurance), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'vitality stat
        DrawText(CharWindowX + 210, CharWindowY + 70, Strings.Get("charwindow", "charvitality") & GetPlayerStat(MyIndex, Stats.Vitality), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'intelligence stat
        DrawText(CharWindowX + 210, CharWindowY + 90, Strings.Get("charwindow", "charintelligence") & GetPlayerStat(MyIndex, Stats.Intelligence), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'luck stat
        DrawText(CharWindowX + 210, CharWindowY + 110, Strings.Get("charwindow", "charluck") & GetPlayerStat(MyIndex, Stats.Luck), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'spirit stat
        DrawText(CharWindowX + 210, CharWindowY + 130, Strings.Get("charwindow", "charspirit") & GetPlayerStat(MyIndex, Stats.Spirit), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)

        If GetPlayerPOINTS(MyIndex) > 0 Then
            'strength upgrade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + StrengthUpgradeX, CharWindowY + StrengthUpgradeY + 4, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)
            'endurance upgrade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + EnduranceUpgradeX, CharWindowY + EnduranceUpgradeY + 4, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)
            'vitality upgrade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + VitalityUpgradeX, CharWindowY + VitalityUpgradeY + 4, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)
            'intelligence upgrade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + IntellectUpgradeX, CharWindowY + IntellectUpgradeY + 4, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)
            'willpower upgrade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + LuckUpgradeX, CharWindowY + LuckUpgradeY + 4, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)
            'spirit upgrade
            RenderSprite(CharPanelPlusSprite, GameWindow, CharWindowX + SpiritUpgradeX, CharWindowY + SpiritUpgradeY + 4, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)
        End If

        'gather skills
        'Header
        DrawText(CharWindowX + 250, CharWindowY + 145, Strings.Get("charwindow", "chargather"), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'herbalist skill
        DrawText(CharWindowX + 210, CharWindowY + 164, Strings.Get("charwindow", "charherb") & GetPlayerGatherSkillLvl(MyIndex, ResourceSkills.Herbalist) & Strings.Get("charwindow", "charexp") & GetPlayerGatherSkillExp(MyIndex, ResourceSkills.Herbalist) & "/" & GetPlayerGatherSkillMaxExp(MyIndex, ResourceSkills.Herbalist), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'woodcutter
        DrawText(CharWindowX + 210, CharWindowY + 184, Strings.Get("charwindow", "charwood") & GetPlayerGatherSkillLvl(MyIndex, ResourceSkills.WoodCutter) & Strings.Get("charwindow", "charexp") & GetPlayerGatherSkillExp(MyIndex, ResourceSkills.WoodCutter) & "/" & GetPlayerGatherSkillMaxExp(MyIndex, ResourceSkills.WoodCutter), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'miner
        DrawText(CharWindowX + 210, CharWindowY + 204, Strings.Get("charwindow", "charmine") & GetPlayerGatherSkillLvl(MyIndex, ResourceSkills.Miner) & Strings.Get("charwindow", "charexp") & GetPlayerGatherSkillExp(MyIndex, ResourceSkills.Miner) & "/" & GetPlayerGatherSkillMaxExp(MyIndex, ResourceSkills.Miner), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
        'fisherman
        DrawText(CharWindowX + 210, CharWindowY + 224, Strings.Get("charwindow", "charfish") & GetPlayerGatherSkillLvl(MyIndex, ResourceSkills.Fisherman) & Strings.Get("charwindow", "charexp") & GetPlayerGatherSkillExp(MyIndex, ResourceSkills.Fisherman) & "/" & GetPlayerGatherSkillMaxExp(MyIndex, ResourceSkills.Fisherman), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 11)
    End Sub

    Public Sub DrawInventoryItem(ByVal X As Integer, ByVal Y As Integer)
        Dim rec As Rectangle
        Dim itemnum As Integer, itempic As Integer

        itemnum = GetPlayerInvItemNum(MyIndex, DragInvSlotNum)

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

            RenderSprite(ItemsSprite(itempic), GameWindow, X + 16, Y + 16, rec.X, rec.Y, rec.Width, rec.Height)
        End If
    End Sub

    Sub DrawInventory()
        Dim i As Integer, X As Integer, Y As Integer, itemnum As Integer, itempic As Integer
        Dim Amount As String
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim colour As SFML.Graphics.Color

        If Not InGame Then Exit Sub

        'first render panel
        RenderSprite(InvPanelSprite, GameWindow, InvWindowX, InvWindowY, 0, 0, InvPanelGFXInfo.Width, InvPanelGFXInfo.Height)

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
                    If ItemsGFXInfo(itempic).Width <= 64 Then ' more than 1 frame is handled by anim sub

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

                        RenderSprite(ItemsSprite(itempic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

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

                        End If
                    End If
                End If
            End If
NextLoop:
        Next

        DrawAnimatedInvItems()
    End Sub

    Sub DrawAnimatedInvItems()
        Dim i As Integer
        Dim itemnum As Integer, itempic As Integer

        Dim X As Integer, Y As Integer
        Dim MaxFrames As Byte
        Dim Amount As Integer
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim clearregion(1) As Rectangle
        Static tmr100 As Integer
        If tmr100 = 0 Then tmr100 = GetTickCount() + 100

        If Not InGame Then Exit Sub

        If GetTickCount() > tmr100 Then
            ' check for map animation changes#
            For i = 1 To MAX_MAP_ITEMS

                If MapItem(i).Num > 0 Then
                    itempic = Item(MapItem(i).Num).Pic

                    If itempic < 1 Or itempic > NumItems Then Exit Sub
                    MaxFrames = (ItemsGFXInfo(itempic).Width / 2) / 32 ' Work out how many frames there are. /2 because of inventory icons as well as ingame

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
                    If ItemsGFXInfo(itempic).Width > 64 Then

                        MaxFrames = (ItemsGFXInfo(itempic).Width / 2) / 32 ' Work out how many frames there are. /2 because of inventory icons as well as ingame

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
                            .X = (ItemsGFXInfo(itempic).Width / 2) + (InvItemFrame(i) * 32) ' middle to get the start of inv gfx, then +32 for each frame
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

                        ' We'll now re-draw the item, and place the currency value over it again :P
                        RenderSprite(ItemsSprite(itempic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

                        ' If item is a stack - draw the amount you have
                        If GetPlayerInvItemValue(MyIndex, i) > 1 Then
                            Y = rec_pos.Top + 22
                            X = rec_pos.Left - 4
                            Amount = CStr(GetPlayerInvItemValue(MyIndex, i))
                            ' Draw currency but with k, m, b etc. using a convertion function
                            DrawText(X, Y, ConvertCurrency(Amount), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)

                        End If
                    End If
                End If
            End If

        Next
    End Sub

    Public Sub DrawSkillItem(ByVal X As Integer, ByVal Y As Integer)
        Dim rec As Rectangle
        Dim skillnum As Integer, skillpic As Integer

        skillnum = DragSkillSlotNum

        If skillnum > 0 And skillnum <= MAX_SKILLS Then

            skillpic = Skill(skillnum).Icon
            If skillpic = 0 Then Exit Sub

            If SkillIconsGFXInfo(skillpic).IsLoaded = False Then
                LoadTexture(skillpic, 9)
            End If

            'seeying we still use it, lets update timer
            With SkillIconsGFXInfo(skillnum)
                .TextureTimer = GetTickCount() + 100000
            End With

            With rec
                .Y = 0
                .Height = PIC_Y
                .X = 0
                .Width = PIC_X
            End With

            RenderSprite(SkillIconsSprite(skillpic), GameWindow, X + 16, Y + 16, rec.X, rec.Y, rec.Width, rec.Height)
        End If
    End Sub

    Sub DrawShop()
        Dim i As Integer, X As Integer, Y As Integer, itemnum As Integer, itempic As Integer
        Dim Amount As String
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim colour As SFML.Graphics.Color

        If Not InGame Or pnlShopVisible = False Then Exit Sub

        'first render panel
        RenderSprite(ShopPanelSprite, GameWindow, ShopWindowX, ShopWindowY, 0, 0, ShopPanelGFXInfo.Width, ShopPanelGFXInfo.Height)

        If Shop(InShop).Face > 0 Then
            'render face
            If FacesGFXInfo(Shop(InShop).Face).IsLoaded = False Then
                LoadTexture(Shop(InShop).Face, 7)
            End If

            'seeying we still use it, lets update timer
            With FacesGFXInfo(Shop(InShop).Face)
                .TextureTimer = GetTickCount() + 100000
            End With
            RenderSprite(FacesSprite(Shop(InShop).Face), GameWindow, ShopWindowX + ShopFaceX, ShopWindowY + ShopFaceY, 0, 0, FacesGFXInfo(Shop(InShop).Face).Width, FacesGFXInfo(Shop(InShop).Face).Height)
        End If

        'draw text
        DrawText(ShopWindowX + ShopLeft, ShopWindowY + 10, Trim(Shop(InShop).Name), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        DrawText(ShopWindowX + 10, ShopWindowY + 10, "Hello, and welcome", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)
        DrawText(ShopWindowX + 10, ShopWindowY + 25, "to the shop!", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        'render buy button
        If CurMouseX > ShopWindowX + ShopButtonBuyX And CurMouseX < ShopWindowX + ShopButtonBuyX + ButtonGFXInfo.Width And
             CurMouseY > ShopWindowY + ShopButtonBuyY And CurMouseY < ShopWindowY + ShopButtonBuyY + ButtonGFXInfo.Height Then
            DrawButton("Buy Item", ShopWindowX + ShopButtonBuyX, ShopWindowY + ShopButtonBuyY, 1)
        Else
            DrawButton("Buy Item", ShopWindowX + ShopButtonBuyX, ShopWindowY + ShopButtonBuyY, 0)
        End If

        'render sell button
        If CurMouseX > ShopWindowX + ShopButtonSellX And CurMouseX < ShopWindowX + ShopButtonSellX + ButtonGFXInfo.Width And
             CurMouseY > ShopWindowY + ShopButtonSellY And CurMouseY < ShopWindowY + ShopButtonSellY + ButtonGFXInfo.Height Then
            DrawButton("Sell Item", ShopWindowX + ShopButtonSellX, ShopWindowY + ShopButtonSellY, 1)
        Else
            DrawButton("Sell Item", ShopWindowX + ShopButtonSellX, ShopWindowY + ShopButtonSellY, 0)
        End If

        'render close button
        If CurMouseX > ShopWindowX + ShopButtonCloseX And CurMouseX < ShopWindowX + ShopButtonCloseX + ButtonGFXInfo.Width And
             CurMouseY > ShopWindowY + ShopButtonCloseY And CurMouseY < ShopWindowY + ShopButtonCloseY + ButtonGFXInfo.Height Then
            DrawButton("Close Shop", ShopWindowX + ShopButtonCloseX, ShopWindowY + ShopButtonCloseY, 1)
        Else
            DrawButton("Close Shop", ShopWindowX + ShopButtonCloseX, ShopWindowY + ShopButtonCloseY, 0)
        End If

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
                        .Y = ShopWindowY + ShopTop + ((ShopOffsetY + 32) * ((i - 1) \ ShopColumns))
                        .Height = PIC_Y
                        .X = ShopWindowX + ShopLeft + ((ShopOffsetX + 1 + 32) * (((i - 1) Mod ShopColumns)))
                        .Width = PIC_X
                    End With

                    RenderSprite(ItemsSprite(itempic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

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

                        DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, GameWindow)
                    End If
                End If
            End If
        Next

    End Sub

    Sub DrawBank()
        Dim i As Integer, X As Integer, Y As Integer, itemnum As Integer
        Dim Amount As String
        Dim sRECT As Rectangle, dRECT As Rectangle
        Dim Sprite As Integer, colour As SFML.Graphics.Color

        'first render panel
        RenderSprite(BankPanelSprite, GameWindow, BankWindowX, BankWindowY, 0, 0, BankPanelGFXInfo.Width, BankPanelGFXInfo.Height)

        'Headertext
        DrawText(BankWindowX + 140, BankWindowY + 6, "Your Bank", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        'close
        DrawText(BankWindowX + 140, BankWindowY + BankPanelGFXInfo.Height - 20, "Close Bank", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

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
                    .X = 0
                    .Width = PIC_X
                End With

                With dRECT
                    .Y = BankWindowY + BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                    .Height = PIC_Y
                    .X = BankWindowX + BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                    .Width = PIC_X
                End With

                RenderSprite(ItemsSprite(Sprite), GameWindow, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height)

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

                    DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, GameWindow)
                End If
            End If
        Next

    End Sub

    Public Sub DrawBankItem(ByVal X As Integer, ByVal Y As Integer)
        Dim rec As Rectangle

        Dim itemnum As Integer
        Dim Sprite As Integer

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

            With rec
                .Y = 0
                .Height = PIC_Y
                .X = 0
                .Width = PIC_X
            End With
        End If

        RenderSprite(ItemsSprite(Sprite), GameWindow, X + 16, Y + 16, rec.X, rec.Y, rec.Width, rec.Height)

    End Sub

    Sub DrawTrade()
        Dim i As Integer, X As Integer, Y As Integer, itemnum As Integer, itempic As Integer
        Dim Amount As String
        Dim rec As Rectangle, rec_pos As Rectangle
        Dim colour As SFML.Graphics.Color

        Amount = 0
        colour = SFML.Graphics.Color.White

        If Not InGame Then Exit Sub

        'first render panel
        RenderSprite(TradePanelSprite, GameWindow, TradeWindowX, TradeWindowY, 0, 0, TradePanelGFXInfo.Width, TradePanelGFXInfo.Height)

        'Headertext
        DrawText(TradeWindowX + 70, TradeWindowY + 6, "Your Offer", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

        DrawText(TradeWindowX + 260, TradeWindowY + 6, Tradername & "'s Offer.", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 15)

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
                        .Height = PIC_Y
                        .X = 0
                        .Width = PIC_X
                    End With

                    With rec_pos
                        .Y = TradeWindowY + OurTradeY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                        .Height = PIC_Y
                        .X = TradeWindowX + OurTradeX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                        .Width = PIC_X
                    End With

                    RenderSprite(ItemsSprite(itempic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

                    ' If item is a stack - draw the amount you have
                    If TradeYourOffer(i).Value >= 1 Then
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
                        DrawText(X, Y, ConvertCurrency(Amount), colour, SFML.Graphics.Color.Black, GameWindow)
                    End If
                End If
            End If
        Next

        DrawText(TradeWindowX + 8, TradeWindowY + 288, YourWorth, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)

        For i = 1 To MAX_INV
            ' blt their offer
            itemnum = TradeTheirOffer(i).Num
            'itemnum = GetPlayerInvItemNum(MyIndex, TradeYourOffer(i).Num)
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
                        .Height = PIC_Y
                        .X = 0
                        .Width = PIC_X
                    End With

                    With rec_pos
                        .Y = TradeWindowY + TheirTradeY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                        .Height = PIC_Y
                        .X = TradeWindowX + TheirTradeX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                        .Width = PIC_X
                    End With

                    RenderSprite(ItemsSprite(itempic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)

                    ' If item is a stack - draw the amount they have
                    If TradeTheirOffer(i).Value >= 1 Then
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
                        DrawText(X, Y, Amount, colour, SFML.Graphics.Color.Black, GameWindow)
                    End If
                End If
            End If
        Next

        DrawText(TradeWindowX + 208, TradeWindowY + 288, TheirWorth, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, 13)

        'render accept button
        DrawButton("Accept Trade", TradeWindowX + TradeButtonAcceptX, TradeWindowY + TradeButtonAcceptY, 0)

        'render decline button
        DrawButton("Decline Trade", TradeWindowX + TradeButtonDeclineX, TradeWindowY + TradeButtonDeclineY, 0)
    End Sub

    Sub DrawPlayerSkills()
        Dim i As Integer, skillnum As Integer, skillicon As Integer
        Dim rec As Rectangle, rec_pos As Rectangle

        If Not InGame Then Exit Sub

        'first render panel
        RenderSprite(SkillPanelSprite, GameWindow, SkillWindowX, SkillWindowY, 0, 0, SkillPanelGFXInfo.Width, SkillPanelGFXInfo.Height)

        For i = 1 To MAX_PLAYER_SKILLS
            skillnum = PlayerSkills(i)

            If skillnum > 0 And skillnum <= MAX_SKILLS Then
                skillicon = Skill(skillnum).Icon

                If skillicon > 0 And skillicon <= NumSkillIcons Then

                    If SkillIconsGFXInfo(skillicon).IsLoaded = False Then
                        LoadTexture(skillicon, 9)
                    End If

                    'seeying we still use it, lets update timer
                    With SkillIconsGFXInfo(skillicon)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
                        .Width = 32
                    End With

                    If Not SkillCD(i) = 0 Then
                        rec.X = 32
                        rec.Width = 32
                    End If

                    With rec_pos
                        .Y = SkillWindowY + SkillTop + ((SkillOffsetY + 32) * ((i - 1) \ SkillColumns))
                        .Height = PIC_Y
                        .X = SkillWindowX + SkillLeft + ((SkillOffsetX + 32) * (((i - 1) Mod SkillColumns)))
                        .Width = PIC_X
                    End With

                    RenderSprite(SkillIconsSprite(skillicon), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
                End If
            End If
        Next

    End Sub

    Public Function ToSFMLColor(ToConvert As Drawing.Color) As SFML.Graphics.Color
        Return New SFML.Graphics.Color(ToConvert.R, ToConvert.G, ToConvert.G, ToConvert.A)
    End Function

    Public Sub DrawTarget(ByVal X2 As Integer, ByVal Y2 As Integer)
        Dim rec As Rectangle
        Dim X As Integer, y As Integer
        Dim width As Integer, height As Integer

        With rec
            .Y = 0
            .Height = TargetGFXInfo.Height
            .X = 0
            .Width = TargetGFXInfo.Width / 2
        End With

        X = ConvertMapX(X2)
        y = ConvertMapY(Y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderSprite(TargetSprite, GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub DrawHover(ByVal X2 As Integer, ByVal Y2 As Integer)
        Dim rec As Rectangle
        Dim X As Integer, Y As Integer
        Dim width As Integer, height As Integer

        With rec
            .Y = 0
            .Height = TargetGFXInfo.Height
            .X = TargetGFXInfo.Width / 2
            .Width = TargetGFXInfo.Width / 2 + TargetGFXInfo.Width / 2
        End With

        X = ConvertMapX(X2)
        Y = ConvertMapY(Y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderSprite(TargetSprite, GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Public Sub DrawItemDesc()
        Dim Xoffset As Integer, Yoffset As Integer, y As Integer

        y = 0

        If pnlCharacterVisible = True Then
            Xoffset = CharWindowX
            Yoffset = CharWindowY
        End If
        If pnlInventoryVisible = True Then
            Xoffset = InvWindowX
            Yoffset = InvWindowY
        End If
        If pnlBankVisible = True Then
            Xoffset = BankWindowX
            Yoffset = BankWindowY
        End If
        If pnlShopVisible = True Then
            Xoffset = ShopWindowX
            Yoffset = ShopWindowY
        End If
        If pnlTradeVisible = True Then
            Xoffset = TradeWindowX
            Yoffset = TradeWindowY
        End If

        'first render panel
        RenderSprite(DescriptionSprite, GameWindow, Xoffset - DescriptionGFXInfo.Width, Yoffset, 0, 0, DescriptionGFXInfo.Width, DescriptionGFXInfo.Height)

        'name
        For Each str As String In WordWrap(ItemDescName, 22)
            'description
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 12 + y, str, ItemDescRarityColor, ItemDescRarityBackColor, GameWindow)
            y = y + 15
        Next

        If ShiftDown Or VbKeyShift = True Then
            'info
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 56, ItemDescInfo, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

            'cost
            'DrawText(Xoffset - DescriptionGFXInfo.width + 10, Yoffset + 74, "Worth: " & ItemDescCost, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'type
            'DrawText(Xoffset - DescriptionGFXInfo.width + 10, Yoffset + 90, "Type: " & ItemDescType, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'speed
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 74, "Speed: " & ItemDescSpeed, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'level
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 90, "Level required: " & ItemDescLevel, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'bonuses
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 118, "=Bonuses=", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'strength
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 134, "Strenght: " & ItemDescStr, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'vitality
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 150, "Vitality: " & ItemDescVit, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'intelligence
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 166, "Intelligence: " & ItemDescInt, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'endurance
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 182, "Endurance: " & ItemDescEnd, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'luck
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 198, "Luck: " & ItemDescLuck, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
            'spirit
            DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 214, "Spirit: " & ItemDescSpr, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        Else
            For Each str As String In WordWrap(ItemDescDescription, 22)
                'description
                DrawText(Xoffset - DescriptionGFXInfo.Width + 10, Yoffset + 44 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 15
            Next
        End If

    End Sub

    Public Sub DrawSkillDesc()
        'first render panel
        RenderSprite(DescriptionSprite, GameWindow, SkillWindowX - DescriptionGFXInfo.Width, SkillWindowY, 0, 0, DescriptionGFXInfo.Width, DescriptionGFXInfo.Height)

        'name
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 12, SkillDescName, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'type
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 28, SkillDescInfo, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'cast time
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 44, "Cast Time: " & SkillDescCastTime, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'cool down
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 58, "CoolDown: " & SkillDescCoolDown, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'Damage
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 74, "Damage: " & SkillDescDamage, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'AOE
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 90, "Aoe: " & SkillDescAOE, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'range
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 104, "Range: " & SkillDescRange, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        'requirements
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 128, "=Requirements=", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'Mp
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 144, "MP: " & SkillDescReqMp, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'level
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 160, "Level: " & SkillDescReqLvl, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'Access
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 176, "Access: " & SkillDescReqAccess, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        'Class
        DrawText(SkillWindowX - DescriptionGFXInfo.Width + 10, SkillWindowY + 192, "Class: " & SkillDescReqClass, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

    End Sub

    Public Sub DrawDialogPanel()
        'first render panel
        RenderSprite(EventChatSprite, GameWindow, DialogPanelX, DialogPanelY, 0, 0, EventChatGFXInfo.Width, EventChatGFXInfo.Height)

        DrawText(DialogPanelX + 175, DialogPanelY + 10, Trim(DialogMsg1), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        If Len(DialogMsg2) > 0 Then
            DrawText(DialogPanelX + 60, DialogPanelY + 30, Trim(DialogMsg2), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        End If

        If Len(DialogMsg3) > 0 Then
            DrawText(DialogPanelX + 60, DialogPanelY + 50, Trim(DialogMsg3), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        End If

        If DialogType = DIALOGUE_TYPE_QUEST Then
            If QuestAcceptTag > 0 Then
                'render accept button
                DrawButton(DialogButton1Text, DialogPanelX + OkButtonX, DialogPanelY + OkButtonY, 0)
                DrawButton(DialogButton2Text, DialogPanelX + CancelButtonX, DialogPanelY + CancelButtonY, 0)
            Else
                'render cancel button
                DrawButton(DialogButton2Text, DialogPanelX + CancelButtonX - 140, DialogPanelY + CancelButtonY, 0)
            End If
        Else
            'render ok button
            DrawButton(DialogButton1Text, DialogPanelX + OkButtonX, DialogPanelY + OkButtonY, 0)

            'render cancel button
            DrawButton(DialogButton2Text, DialogPanelX + CancelButtonX, DialogPanelY + CancelButtonY, 0)
        End If

    End Sub

    Public Sub DrawRClick()
        'first render panel
        RenderSprite(RClickSprite, GameWindow, RClickX, RClickY, 0, 0, RClickGFXInfo.Width, RClickGFXInfo.Height)

        DrawText(RClickX + (RClickGFXInfo.Width \ 2) - (GetTextWidth(RClickname) \ 2), RClickY + 10, RClickname, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        DrawText(RClickX + (RClickGFXInfo.Width \ 2) - (GetTextWidth("Invite to Trade") \ 2), RClickY + 35, "Invite to Trade", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        DrawText(RClickX + (RClickGFXInfo.Width \ 2) - (GetTextWidth("Invite to Party") \ 2), RClickY + 60, "Invite to Party", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

        DrawText(RClickX + (RClickGFXInfo.Width \ 2) - (GetTextWidth("Invite to House") \ 2), RClickY + 85, "Invite to House", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

    End Sub

    Public Sub DrawGUI()
        'hide GUI when mapping...
        If HideGui = True Then Exit Sub

        If HUDVisible = True Then
            DrawHUD()
            DrawActionPanel()
            DrawChat()
            DrawHotbar()
            DrawPetBar()
            DrawPetStats()
        End If

        If pnlCharacterVisible = True Then
            DrawEquipment()
            If ShowItemDesc = True Then DrawItemDesc()
        End If

        If pnlInventoryVisible = True Then
            DrawInventory()
            If ShowItemDesc = True Then DrawItemDesc()
        End If

        If pnlSkillsVisible = True Then
            DrawPlayerSkills()
            If ShowSkillDesc = True Then DrawSkillDesc()
        End If

        If DialogPanelVisible = True Then
            DrawDialogPanel()
        End If

        If pnlBankVisible = True Then
            DrawBank()
        End If

        If pnlShopVisible = True Then
            DrawShop()
        End If

        If pnlTradeVisible = True Then
            DrawTrade()
        End If

        If pnlEventChatVisible = True Then
            DrawEventChat()
        End If

        If pnlRClickVisible = True Then
            DrawRClick()
        End If

        If pnlQuestLogVisible = True Then
            DrawQuestLog()
        End If

        If pnlCraftVisible = True Then
            DrawCraftPanel()
        End If

        If DragInvSlotNum > 0 Then
            DrawInventoryItem(CurMouseX, CurMouseY)
        End If

        If DragBankSlotNum > 0 Then
            DrawBankItem(CurMouseX, CurMouseY)
        End If

        If DragSkillSlotNum > 0 Then
            DrawSkillItem(CurMouseX, CurMouseY)
        End If

        'draw cursor
        'DrawCursor()
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

    Public Sub EditorMap_DrawTileset()
        Dim height As Integer
        Dim width As Integer
        Dim tileset As Byte

        TilesetWindow.DispatchEvents()
        TilesetWindow.Clear(SFML.Graphics.Color.Black)

        ' find tileset number
        tileset = frmEditor_MapEditor.cmbTileSets.SelectedIndex + 1

        ' exit out if doesn't exist
        If tileset <= 0 Or tileset > NumTileSets Then Exit Sub

        Dim rec2 As New RectangleShape With {
            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Red),
            .OutlineThickness = 0.6,
            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
        }

        If TileSetTextureInfo(tileset).IsLoaded = False Then
            LoadTexture(tileset, 1)
        End If
        ' we use it, lets update timer
        With TileSetTextureInfo(tileset)
            .TextureTimer = GetTickCount() + 100000
        End With

        height = TileSetTextureInfo(tileset).Height
        width = TileSetTextureInfo(tileset).Width
        frmEditor_MapEditor.picBackSelect.Height = height
        frmEditor_MapEditor.picBackSelect.Width = width

        TilesetWindow.SetView(New SFML.Graphics.View(New FloatRect(0, 0, width, height)))

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
                Case Else
                    EditorTileWidth = 1
                    EditorTileHeight = 1
            End Select
        End If

        RenderSprite(TileSetSprite(tileset), TilesetWindow, 0, 0, 0, 0, width, height)

        rec2.Size = New Vector2f(EditorTileWidth * PIC_X, EditorTileHeight * PIC_Y)

        rec2.Position = New Vector2f(EditorTileSelStart.X * PIC_X, EditorTileSelStart.Y * PIC_Y)
        TilesetWindow.Draw(rec2)

        'and finally show everything on screen
        TilesetWindow.Display()

        LastTileset = tileset
    End Sub

    Sub DrawNight()
        Dim X As Integer, Y As Integer

        If Map.Moral = MapMoral.Indoors Then Exit Sub

        If GameTime = Time.Dawn Then
            NightGfx.Clear(New SFML.Graphics.Color(0, 0, 0, 100))
        ElseIf GameTime = Time.Day Then
            Exit Sub
        ElseIf GameTime = Time.Dusk Then
            NightGfx.Clear(New SFML.Graphics.Color(0, 0, 0, 150))
        Else
            NightGfx.Clear(New SFML.Graphics.Color(0, 0, 0, 200))
        End If

        For X = TileView.left To TileView.right + 1
            For Y = TileView.top To TileView.bottom + 1
                If IsValidMapPoint(X, Y) Then
                    If Map.Tile(X, Y).Type = TileType.Light Then
                        Dim X1 = ConvertMapX(X * 32) + 16 - LightGfxInfo.Width / 2
                        Dim Y1 = ConvertMapY(Y * 32) + 16 - LightGfxInfo.Height / 2

                        'Create the light texture to multiply over the dark texture.
                        LightSprite.Position = New Vector2f(X1, Y1)

                        NightGfx.Draw(LightSprite, New RenderStates(BlendMode.Multiply))

                    End If
                End If
            Next
        Next

        ''draw on player
        'Dim x2 As Integer, y2 As Integer

        '' Calculate the X
        'x2 = GetPlayerX(MyIndex) * PIC_X + Player(MyIndex).XOffset - ((CharacterGFXInfo(GetPlayerSprite(MyIndex)).Width / 4 - 32) / 2)

        '' Is the player's height more than 32..?
        'If (CharacterGFXInfo(GetPlayerSprite(MyIndex)).Height) > 32 Then
        '    ' Create a 32 pixel offset for larger sprites
        '    y2 = GetPlayerY(MyIndex) * PIC_Y + Player(MyIndex).YOffset - ((CharacterGFXInfo(GetPlayerSprite(MyIndex)).Height / 4) - 32)
        'Else
        '    ' Proceed as normal
        '    y2 = GetPlayerY(MyIndex) * PIC_Y + Player(MyIndex).YOffset
        'End If

        ''LightSprite.TextureRect = New IntRect(0, 0, LightSprite.Texture.Size.X, LightSprite.Texture.Size.Y)
        'LightSprite.Color = New SFML.Graphics.Color(255, 0, 0, 255)
        '' 16 offset is for the center of the graphic
        'LightSprite.Origin = New Vector2f(LightSprite.TextureRect.Width / 2 - 16, LightSprite.TextureRect.Height / 2 - 16)
        'LightSprite.Position = New Vector2f(x2, y2)
        'NightGfx.Draw(LightSprite, New RenderStates(BlendMode.Multiply))


        NightSprite = New Sprite(NightGfx.Texture)

        NightGfx.Display()
        GameWindow.Draw(NightSprite)
    End Sub

    Sub DrawCursor()
        RenderSprite(CursorSprite, GameWindow, CurMouseX, CurMouseY, 0, 0, CursorInfo.Width, CursorInfo.Height)
    End Sub
End Module