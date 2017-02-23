Imports System.Drawing

Module ClientGlobals
    'char creation/selecting
    Public SelectedChar As Byte
    Public MaxChars As Byte

    Public TotalOnline As Integer

    ' for directional blocking
    Public DirArrowX(0 To 4) As Byte
    Public DirArrowY(0 To 4) As Byte

    Public TilesetsClr() As Color
    Public LastTileset As Byte

    Public FadeType As Integer
    Public FadeAmount As Integer
    Public FlashTimer As Integer

    ' targetting
    Public myTarget As Integer
    Public myTargetType As Integer

    ' chat bubble
    Public chatBubble(0 To Byte.MaxValue) As ChatBubbleRec
    Public chatBubbleIndex As Integer

    ' Cache the Resources in an array
    Public MapResource() As MapResourceRec
    Public Resource_Index As Integer
    Public Resources_Init As Boolean

    ' inv drag + drop
    Public DragInvSlotNum As Integer
    Public InvX As Integer
    Public InvY As Integer

    ' skill drag + drop
    Public DragSkillSlotNum As Integer
    Public SkillX As Integer
    Public SkillY As Integer

    ' bank drag + drop
    Public DragBankSlotNum As Integer
    Public BankX As Integer
    Public BankY As Integer

    ' gui
    Public EqX As Integer
    Public EqY As Integer
    Public FPS As Integer
    Public LPS As Integer
    Public PingToDraw As String
    Public ShowRClick As Boolean

    Public InvItemFrame(0 To MAX_INV) As Byte ' Used for animated items
    Public LastItemDesc As Integer ' Stores the last item we showed in desc
    Public LastSkillDesc As Integer ' Stores the last skill we showed in desc
    Public LastBankDesc As Integer ' Stores the last bank item we showed in desc
    Public tmpCurrencyItem As Integer
    Public InShop As Integer ' is the player in a shop?
    Public ShopAction As Byte ' stores the current shop action
    Public InBank As Integer
    Public CurrencyMenu As Byte
    Public HideGui As Boolean

    ' Player variables
    Public MyIndex As Integer ' Index of actual player
    Public PlayerInv(0 To MAX_INV) As PlayerInvRec   ' Inventory
    Public PlayerSkills(0 To MAX_PLAYER_SKILLS) As Byte
    Public InventoryItemSelected As Integer
    Public SkillBuffer As Integer
    Public SkillBufferTimer As Integer
    Public SkillCD(0 To MAX_PLAYER_SKILLS) As Integer
    Public StunDuration As Integer
    Public NextlevelExp As Integer

    ' Stops movement when updating a map
    Public CanMoveNow As Boolean

    ' Controls main gameloop
    Public InGame As Boolean
    Public isLogging As Boolean
    Public MapData As Boolean
    Public PlayerData As Boolean

    ' Text variables

    ' Draw map name location
    Public DrawMapNameX As Single = 110
    Public DrawMapNameY As Single = 70
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

    ' Used to freeze controls when getting a new map
    Public GettingMap As Boolean

    ' Used to check if FPS needs to be drawn
    Public BFPS As Boolean
    Public BLPS As Boolean
    Public BLoc As Boolean

    ' FPS and Time-based movement vars
    Public ElapsedTime As Integer
    'Public ElapsedMTime As Integer
    Public GameFPS As Integer
    Public GameLPS As Integer

    ' Text vars
    Public vbQuote As String

    ' Mouse cursor tile location
    Public CurX As Integer
    Public CurY As Integer
    Public CurMouseX As Integer
    Public CurMouseY As Integer

    ' Game editors
    Public Editor As Byte
    Public EditorIndex As Integer
    Public AnimEditorFrame(0 To 1) As Integer
    Public AnimEditorTimer(0 To 1) As Integer

    ' Used to check if in editor or not and variables for use in editor
    Public SpawnNpcNum As Byte
    Public SpawnNpcDir As Byte

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

    ' Maximum classes
    Public Max_Classes As Byte

    Public Camera As Rectangle
    Public TileView As Rect

    ' Pinging
    Public PingStart As Integer
    Public PingEnd As Integer
    Public Ping As Integer

    ' indexing
    Public ActionMsgIndex As Byte
    Public BloodIndex As Byte
    Public AnimationIndex As Byte

    ' Editor edited items array
    Public Item_Changed(MAX_ITEMS) As Boolean
    Public NPC_Changed(MAX_NPCS) As Boolean
    Public Resource_Changed(MAX_NPCS) As Boolean
    Public Animation_Changed(MAX_ANIMATIONS) As Boolean
    Public Skill_Changed(MAX_SKILLS) As Boolean
    Public Shop_Changed(MAX_SHOPS) As Boolean

    ' New char
    Public newCharSprite As Integer
    Public newCharClass As Integer

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

    ' fog
    Public fogOffsetX As Integer
    Public fogOffsetY As Integer

    'Weather Stuff... events take precedent OVER map settings so we will keep temp map weather settings here.
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

    Public ShakeTimerEnabled As Boolean
    Public ShakeTimer As Integer
    Public ShakeCount As Byte
    Public LastDir As Byte

    Public CraftTimerEnabled As Boolean
    Public CraftTimer As Integer

    Public ShowAnimLayers As Boolean
    Public ShowAnimTimer As Integer
End Module