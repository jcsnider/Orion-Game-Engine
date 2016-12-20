Imports System.Drawing

Module ClientConstants
    Public Const INSTANCED_MAP_MASK As Long = 16777216 '1 << 24
    Public Const MAP_NUMBER_MASK As Long = INSTANCED_MAP_MASK - 1

    'Graphics
    Public Const FPS_LIMIT As Integer = 64

    'Chatbubble
    Public Const ChatBubbleWidth As Integer = 100

    Public Const EFFECT_TYPE_FADEIN As Integer = 1
    Public Const EFFECT_TYPE_FADEOUT As Integer = 2
    Public Const EFFECT_TYPE_FLASH As Integer = 3
    Public Const EFFECT_TYPE_FOG As Integer = 4
    Public Const EFFECT_TYPE_WEATHER As Integer = 5
    Public Const EFFECT_TYPE_TINT As Integer = 6

    ' path constants
    Public Const SOUND_PATH As String = "\Data Files\sound\"
    Public Const MUSIC_PATH As String = "\Data Files\music\"

    ' Font variables
    Public Const FONT_NAME As String = "Arial.ttf"
    Public Const FONT_SIZE As Byte = 13

    ' Log Path and variables
    Public Const LOG_DEBUG As String = "debug.txt"
    Public Const LOG_PATH As String = "\Data Files\logs\"

    ' Gfx Path and variables
    Public Const GFX_PATH As String = "\Data Files\graphics\"
    Public Const GFX_GUI_PATH As String = "\Data Files\graphics\gui\"
    Public Const GFX_EXT As String = ".png"

    ' Menu states
    Public Const MENU_STATE_NEWACCOUNT As Byte = 0
    Public Const MENU_STATE_DELACCOUNT As Byte = 1
    Public Const MENU_STATE_LOGIN As Byte = 2
    Public Const MENU_STATE_GETCHARS As Byte = 3
    Public Const MENU_STATE_NEWCHAR As Byte = 4
    Public Const MENU_STATE_ADDCHAR As Byte = 5
    Public Const MENU_STATE_DELCHAR As Byte = 6
    Public Const MENU_STATE_USECHAR As Byte = 7
    Public Const MENU_STATE_INIT As Byte = 8

    ' Number of tiles in width in tilesets
    Public Const TILESHEET_WIDTH As Integer = 15 ' * PIC_X pixels

    Public MapGrid As Boolean

    ' Speed moving vars
    Public Const WALK_SPEED As Byte = 6
    Public Const RUN_SPEED As Byte = 10

    ' Tile size constants
    Public Const PIC_X As Integer = 32
    Public Const PIC_Y As Integer = 32

    ' Sprite, item, skill size constants
    Public Const SIZE_X As Integer = 32
    Public Const SIZE_Y As Integer = 32

    ' ********************************************************
    ' * The values below must match with the server's values *
    ' ********************************************************

    ' General constants
    Public GAME_NAME As String = "Orion+"

    ' Website
    Public Const GAME_WEBSITE As String = "http://ascensiongamedev.com/index.php"

    ' Map constants
    Public SCREEN_MAPX As Byte = 35
    Public SCREEN_MAPY As Byte = 26

    Public ITEM_RARITY_COLOR_0 = SFML.Graphics.Color.White ' white
    Public ITEM_RARITY_COLOR_1 = New SFML.Graphics.Color(102, 255, 0) ' green
    Public ITEM_RARITY_COLOR_2 = New SFML.Graphics.Color(73, 151, 208) ' blue
    Public ITEM_RARITY_COLOR_3 = New SFML.Graphics.Color(128, 0, 0) ' red
    Public ITEM_RARITY_COLOR_4 = New SFML.Graphics.Color(159, 0, 197) ' purple
    Public ITEM_RARITY_COLOR_5 = New SFML.Graphics.Color(255, 215, 0) ' gold

    ' Game editor constants
    Public Const EDITOR_ITEM As Byte = 1
    Public Const EDITOR_NPC As Byte = 2
    Public Const EDITOR_SKILL As Byte = 3
    Public Const EDITOR_SHOP As Byte = 4
    Public Const EDITOR_RESOURCE As Byte = 5
    Public Const EDITOR_ANIMATION As Byte = 6
    Public Const EDITOR_QUEST As Byte = 7
    Public Const EDITOR_HOUSE As Byte = 8
    Public Const EDITOR_RECIPE As Byte = 9
    Public Const EDITOR_CLASSES As Byte = 10

    ' Used to check if in editor or not and variables for use in editor
    Public InMapEditor As Boolean
    Public EditorTileX As Integer
    Public EditorTileY As Integer
    Public EditorTileWidth As Integer
    Public EditorTileHeight As Integer
    Public EditorWarpMap As Integer
    Public EditorWarpX As Integer
    Public EditorWarpY As Integer
    Public EditorShop As Integer
    Public EditorTileSelStart As Point
    Public EditorTileSelEnd As Point

    Public HalfX As Integer = ((SCREEN_MAPX + 1) \ 2) * PIC_X
    Public HalfY As Integer = ((SCREEN_MAPY + 1) \ 2) * PIC_Y
    Public ScreenX As Integer = (SCREEN_MAPX + 1) * PIC_X
    Public ScreenY As Integer = (SCREEN_MAPY + 1) * PIC_Y

    'dialog types
    Public Const DIALOGUE_TYPE_BUYHOME As Byte = 1
    Public Const DIALOGUE_TYPE_VISIT As Byte = 2
    Public Const DIALOGUE_TYPE_PARTY As Byte = 3
    Public Const DIALOGUE_TYPE_QUEST As Byte = 4
    Public Const DIALOGUE_TYPE_TRADE As Byte = 5

End Module
