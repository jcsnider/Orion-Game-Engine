Module EditorGlobals
    Public GameStarted As Boolean
    Public GameDestroyed As Boolean

    Public TilesetsClr() As Color
    Public LastTileset As Byte

    ' Gfx Path and variables
    Public Const GFX_PATH As String = "\Data Files\graphics\"
    Public Const GFX_GUI_PATH As String = "\Data Files\graphics\gui\"
    Public Const GFX_EXT As String = ".png"

    ' path constants
    Public Const SOUND_PATH As String = "\Data Files\sound\"
    Public Const MUSIC_PATH As String = "\Data Files\music\"

    Public Max_Classes As Byte

    Public MapData As Boolean
    ' Cache the Resources in an array
    Public MapResource() As MapResourceRec
    Public Resource_Index As Integer
    Public Resources_Init As Boolean

    ' fog
    Public fogOffsetX As Integer
    Public fogOffsetY As Integer

    Public CurrentWeather As Integer
    Public CurrentWeatherIntensity As Integer
    Public CurrentFog As Integer
    Public CurrentFogSpeed As Integer
    Public CurrentFogOpacity As Integer
    Public CurrentTintR As Integer
    Public CurrentTintG As Integer
    Public CurrentTintB As Integer
    Public CurrentTintA As Integer
    Public DrawThunder As Integer

    ' Editor edited items array
    Public Item_Changed(0 To MAX_ITEMS) As Boolean
    Public NPC_Changed(0 To MAX_NPCS) As Boolean
    Public Resource_Changed(0 To MAX_NPCS) As Boolean
    Public Animation_Changed(0 To MAX_ANIMATIONS) As Boolean
    Public Skill_Changed(0 To MAX_SKILLS) As Boolean
    Public Shop_Changed(0 To MAX_SHOPS) As Boolean

    'Editors
    Public InitEditor As Boolean
    Public InitMapEditor As Boolean
    Public InitItemEditor As Boolean
    Public InitResourceEditor As Boolean
    Public InitNPCEditor As Boolean
    Public InitSkillEditor As Boolean
    Public InitShopEditor As Boolean
    Public InitAnimationEditor As Boolean
    Public InitClassEditor As Boolean

    Public InitMapProperties As Boolean

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

    'Mapreport
    Public UpdateMapnames As Boolean

    ' Game editors
    Public Editor As Byte
    Public EditorIndex As Integer
    Public AnimEditorFrame(0 To 1) As Integer
    Public AnimEditorTimer(0 To 1) As Integer

    ' Used to check if in editor or not and variables for use in editor
    Public InMapEditor As Boolean
    Public EditorTileX As Integer
    Public EditorTileY As Integer
    Public EditorTileWidth As Integer
    Public EditorTileHeight As Integer
    Public EditorWarpMap As Integer
    Public EditorWarpX As Integer
    Public EditorWarpY As Integer
    Public SpawnNpcNum As Byte
    Public SpawnNpcDir As Byte
    Public EditorShop As Integer
    Public EditorTileSelStart As Point
    Public EditorTileSelEnd As Point

    ' Used for map item editor
    Public ItemEditorNum As Integer
    Public ItemEditorValue As Integer

    ' Used for map key editor
    Public KeyEditorNum As Integer
    Public KeyEditorTake As Integer

    ' Used for map key open editor
    Public KeyOpenEditorX As Integer
    Public KeyOpenEditorY As Integer

    ' Map Resources
    Public ResourceEditorNum As Integer

    ' Used for map editor heal & trap & slide tiles
    Public MapEditorHealType As Integer
    Public MapEditorHealAmount As Integer
    Public MapEditorSlideDir As Integer

    ' Map constants
    Public SCREEN_MAPX As Byte = 35
    Public SCREEN_MAPY As Byte = 26

    ' Used to freeze controls when getting a new map
    Public GettingMap As Boolean

    ' Font variables
    Public Const FONT_NAME As String = "Arial.ttf"
    Public Const FONT_SIZE As Byte = 13

    ' Tile size constants
    Public Const PIC_X As Integer = 32
    Public Const PIC_Y As Integer = 32

    ' Sprite, item, skill size constants
    Public Const SIZE_X As Integer = 32
    Public Const SIZE_Y As Integer = 32

    'Graphics
    Public Const FPS_LIMIT As Integer = 64

    Public Camera As Rectangle
    Public TileView As RECT

    ' for directional blocking
    Public DirArrowX(0 To 4) As Byte
    Public DirArrowY(0 To 4) As Byte

    Public HalfX As Integer = ((SCREEN_MAPX + 1) \ 2) * PIC_X
    Public HalfY As Integer = ((SCREEN_MAPY + 1) \ 2) * PIC_Y
    Public ScreenX As Integer = (SCREEN_MAPX + 1) * PIC_X
    Public ScreenY As Integer = (SCREEN_MAPY + 1) * PIC_Y

    ' Number of tiles in width in tilesets
    Public Const TILESHEET_WIDTH As Integer = 15 ' * PIC_X pixels

    Public MapGrid As Boolean

    ' Mouse cursor tile location
    Public CurX As Integer
    Public CurY As Integer
    Public CurMouseX As Integer
    Public CurMouseY As Integer

    ' Draw map name location
    Public DrawMapNameX As Single
    Public DrawMapNameY As Single
    Public DrawMapNameColor As SFML.Graphics.Color

    Public LoadClassInfo As Boolean
End Module
