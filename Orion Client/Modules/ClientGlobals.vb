Imports System.Drawing

Module ClientGlobals
    'Music + Sound Players
    Public SoundPlayer As SFML.Audio.Sound
    Public MusicPlayer As SFML.Audio.Music
    Public MusicCache(0 To 100) As String
    Public SoundCache(0 To 100) As String

    ' for directional blocking
    Public DirArrowX(0 To 4) As Byte
    Public DirArrowY(0 To 4) As Byte

    Public TilesetsClr() As Color
    Public LastTileset As Byte

    ' targetting
    Public myTarget As Long
    Public myTargetType As Long

    ' chat bubble
    Public chatBubble(0 To MAX_BYTE) As ChatBubbleRec
    Public chatBubbleIndex As Long

    Public UpdateMiniMap As Boolean

    ' trading
    Public TradeTimer As Long
    Public TradeRequest As Boolean
    Public InTrade As Boolean
    Public TradeYourOffer(0 To MAX_INV) As PlayerInvRec
    Public TradeTheirOffer(0 To MAX_INV) As PlayerInvRec
    Public TradeX As Long
    Public TradeY As Long
    Public TheirWorth As String
    Public YourWorth As String

    ' Cache the Resources in an array
    Public MapResource() As MapResourceRec
    Public Resource_Index As Long
    Public Resources_Init As Boolean

    ' inv drag + drop
    Public DragInvSlotNum As Integer
    Public InvX As Long
    Public InvY As Long

    ' spell drag + drop
    Public DragSpellSlotNum As Integer
    Public SpellX As Long
    Public SpellY As Long

    ' bank drag + drop
    Public DragBankSlotNum As Integer
    Public BankX As Long
    Public BankY As Long

    ' gui
    Public EqX As Long
    Public EqY As Long
    Public FPS As Long
    Public PingToDraw As String
    Public GoldAmount As String
    Public inChat As Boolean

    Public InvItemFrame(0 To MAX_INV) As Byte ' Used for animated items
    Public LastItemDesc As Long ' Stores the last item we showed in desc
    Public LastSpellDesc As Long ' Stores the last spell we showed in desc
    Public LastBankDesc As Long ' Stores the last bank item we showed in desc
    Public tmpCurrencyItem As Long
    Public InShop As Long ' is the player in a shop?
    Public ShopAction As Byte ' stores the current shop action
    Public InBank As Long
    Public CurrencyMenu As Byte
    Public HideGui As Boolean

    ' Player variables
    Public MyIndex As Long ' Index of actual player
    Public PlayerInv(0 To MAX_INV) As PlayerInvRec   ' Inventory
    Public PlayerSpells(0 To MAX_PLAYER_SPELLS) As Byte
    Public InventoryItemSelected As Integer
    Public SpellBuffer As Long
    Public SpellBufferTimer As Long
    Public SpellCD(0 To MAX_PLAYER_SPELLS) As Long
    Public StunDuration As Long
    Public NextlevelExp As Long

    ' Stops movement when updating a map
    Public CanMoveNow As Boolean

    ' Debug mode
    Public DEBUG_MODE As Boolean

    ' Controls main gameloop
    Public InGame As Boolean
    Public isLogging As Boolean
    Public MapData As Boolean
    Public PlayerData As Boolean

    ' Text variables
    Public TexthDC As Long
    Public GameFont As Long

    ' Draw map name location
    Public DrawMapNameX As Single
    Public DrawMapNameY As Single
    Public DrawMapNameColor As SFML.Graphics.Color

    ' Game direction vars
    Public DirUp As Boolean
    Public DirDown As Boolean
    Public DirLeft As Boolean
    Public DirRight As Boolean
    Public ShiftDown As Boolean
    Public ControlDown As Boolean

    ' Used for dragging Picture Boxes
    Public SOffsetX As Integer
    Public SOffsetY As Integer

    ' Map animation #, used to keep track of what map animation is currently on
    Public MapAnim As Byte
    Public MapAnimTimer As Long

    ' Used to freeze controls when getting a new map
    Public GettingMap As Boolean

    ' Used to check if FPS needs to be drawn
    Public BFPS As Boolean
    Public BLoc As Boolean

    ' FPS and Time-based movement vars
    Public ElapsedTime As Long
    'Public ElapsedMTime As Long
    Public GameFPS As Long

    ' Text vars
    Public vbQuote As String

    ' Mouse cursor tile location
    Public CurX As Integer
    Public CurY As Integer

    ' Game editors
    Public Editor As Byte
    Public EditorIndex As Long
    Public AnimEditorFrame(0 To 1) As Long
    Public AnimEditorTimer(0 To 1) As Long

    ' Used to check if in editor or not and variables for use in editor
    Public InMapEditor As Boolean
    Public EditorTileX As Long
    Public EditorTileY As Long
    Public EditorTileWidth As Long
    Public EditorTileHeight As Long
    Public EditorWarpMap As Long
    Public EditorWarpX As Long
    Public EditorWarpY As Long
    Public SpawnNpcNum As Byte
    Public SpawnNpcDir As Byte
    Public EditorShop As Long
    Public EditorTileSelStart As Point
    Public EditorTileSelEnd As Point

    ' Used for map item editor
    Public ItemEditorNum As Long
    Public ItemEditorValue As Long

    ' Used for map key editor
    Public KeyEditorNum As Long
    Public KeyEditorTake As Long

    ' Used for map key open editor
    Public KeyOpenEditorX As Long
    Public KeyOpenEditorY As Long

    ' Map Resources
    Public ResourceEditorNum As Long

    ' Used for map editor heal & trap & slide tiles
    Public MapEditorHealType As Long
    Public MapEditorHealAmount As Long
    Public MapEditorSlideDir As Long

    ' Maximum classes
    Public Max_Classes As Byte
    Public Camera As Rectangle
    Public TileView As RECT

    ' Pinging
    Public PingStart As Long
    Public PingEnd As Long
    Public Ping As Long

    ' indexing
    Public ActionMsgIndex As Byte
    Public BloodIndex As Byte
    Public AnimationIndex As Byte

    ' fps lock
    Public FPS_Lock As Boolean

    ' Editor edited items array
    Public Item_Changed(0 To MAX_ITEMS) As Boolean
    Public NPC_Changed(0 To MAX_NPCS) As Boolean
    Public Resource_Changed(0 To MAX_NPCS) As Boolean
    Public Animation_Changed(0 To MAX_ANIMATIONS) As Boolean
    Public Spell_Changed(0 To MAX_SPELLS) As Boolean
    Public Shop_Changed(0 To MAX_SHOPS) As Boolean

    ' New char
    Public newCharSprite As Long
    Public newCharClass As Long

    Public TempMapData() As Byte

    'dialog
    Public DialogType As Byte
    Public DialogMsg1 As String
    Public DialogMsg2 As String
    Public DialogMsg3 As String
    Public UpdateDialog As Boolean
    Public DialogButton1Text As String
    Public DialogButton2Text As String

    'store news here
    Public News As String
    Public UpdateNews As Boolean

End Module
