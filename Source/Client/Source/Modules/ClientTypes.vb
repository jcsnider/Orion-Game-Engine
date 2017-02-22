Module ClientTypes
    ' options
    Public Options As New ClientOptions()

    ' Public data structures
    Public Map As MapRec
    Public MapLock As New Object()
    Public Bank As BankRec
    Public MapItem(MAX_MAP_ITEMS) As MapItemRec
    Public MapNpc(MAX_MAP_NPCS) As MapNpcRec
    Public TempTile(,) As TempTileRec
    Public Player(MAX_PLAYERS) As PlayerRec

    ' client-side stuff
    Public ActionMsg(Byte.MaxValue) As ActionMsgRec
    Public Blood(Byte.MaxValue) As BloodRec
    Public AnimInstance(Byte.MaxValue) As AnimInstanceRec
    Public Chat As New List(Of ChatRec)

    'Mapreport
    Public MapNames(MAX_MAPS) As String

    Public CharSelection() As CharSelRec
    Public Structure CharSelRec
        Dim Name As String
        Dim Sprite As Integer
        Dim Gender As Integer
        Dim ClassName As String
        Dim Level As Integer
    End Structure

    Public Structure ChatRec
        Dim Text As String
        Dim Color As Integer
        Dim Y As Byte
    End Structure

    Public Structure SkillAnim
        Dim skillnum As Integer
        Dim Timer As Integer
        Dim FramePointer As Integer
    End Structure

    Public Structure PlayerRec
        ' General
        Dim Name As String
        Dim Classes As Byte
        Dim Sprite As Integer
        Dim Level As Byte
        Dim EXP As Integer
        Dim Access As Byte
        Dim PK As Byte
        ' Vitals
        Dim Vital() As Integer
        ' Stats
        Dim Stat() As Byte
        Dim POINTS As Byte
        ' Worn equipment
        Dim Equipment() As Byte
        ' Position
        Dim Map As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte

        ' Client use only
        Dim MaxHP As Integer
        Dim MaxMP As Integer
        Dim MaxSP As Integer
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Moving As Byte
        Dim Attacking As Byte
        Dim AttackTimer As Integer
        Dim MapGetTimer As Integer
        Dim Steps As Byte

        Dim Emote As Integer
        Dim EmoteTimer As Integer

        Dim PlayerQuest() As PlayerQuestRec

        'Housing
        Dim House As PlayerHouseRec

        Dim InHouse As Integer
        Dim LastMap As Integer
        Dim LastX As Integer
        Dim LastY As Integer

        Dim Hotbar() As HotbarRec

        Dim EventTimer As Integer

        'gather skills
        Dim GatherSkills() As ResourceSkillsRec

        Dim RecipeLearned() As Byte

        ' Random Items
        Dim RandInv() As RandInvRec
        Dim RandEquip() As RandInvRec

        Dim Pet As PlayerPetRec
    End Structure

    Public Structure MapRec
        Dim Name As String
        Dim Music As String

        Dim Revision As Integer
        Dim Moral As Byte
        Dim Tileset As Integer

        Dim Up As Integer
        Dim Down As Integer
        Dim Left As Integer
        Dim Right As Integer

        Dim BootMap As Integer
        Dim BootX As Byte
        Dim BootY As Byte

        Dim MaxX As Byte
        Dim MaxY As Byte

        Dim Tile(,) As TileRec
        Dim Npc() As Integer
        Dim EventCount As Integer
        Dim Events() As EventRec

        Dim WeatherType As Byte
        Dim FogIndex As Integer
        Dim WeatherIntensity As Integer
        Dim FogAlpha As Byte
        Dim FogSpeed As Byte

        Dim HasMapTint As Byte
        Dim MapTintR As Byte
        Dim MapTintG As Byte
        Dim MapTintB As Byte
        Dim MapTintA As Byte

        Dim Instanced As Byte

        Dim Panorama As Byte
        Dim Parallax As Byte

        'Client Side Only -- Temporary
        Dim CurrentEvents As Integer
        Dim MapEvents() As MapEventRec
    End Structure

    Public Structure ClassRec
        Dim Name As String
        Dim Desc As String
        Dim Stat() As Byte
        Dim MaleSprite() As Integer
        Dim FemaleSprite() As Integer
        Dim StartItem() As Integer
        Dim StartValue() As Integer
        Dim StartMap As Integer
        Dim StartX As Byte
        Dim StartY As Byte
        Dim BaseExp As Integer
        ' For client use
        Dim Vital() As Integer
    End Structure

    Public Structure MapItemRec
        Dim Num As Byte
        Dim Value As Integer
        Dim Frame As Byte
        Dim X As Byte
        Dim Y As Byte

        Dim RandData As RandInvRec
    End Structure

    Public Structure MapNpcRec
        Dim Num As Byte
        Dim Target As Byte
        Dim TargetType As Byte
        Dim Vital() As Integer
        Dim Map As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte
        ' Client use only
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Moving As Byte
        Dim Attacking As Byte
        Dim AttackTimer As Integer
        Dim Steps As Integer
    End Structure

    Public Structure ChatBubbleRec
        Dim Msg As String
        Dim colour As Integer
        Dim target As Integer
        Dim targetType As Byte
        Dim Timer As Integer
        Dim active As Boolean
    End Structure

    Public Structure TempTileRec
        Dim DoorOpen As Byte
        Dim DoorFrame As Byte
        Dim DoorTimer As Integer
        Dim DoorAnimate As Byte ' 0 = nothing| 1 = opening | 2 = closing
    End Structure

    Public Structure MapResourceRec
        Dim X As Integer
        Dim Y As Integer
        Dim ResourceState As Byte
    End Structure

    Public Structure ActionMsgRec
        Dim message As String
        Dim Created As Integer
        Dim Type As Integer
        Dim color As Integer
        Dim Scroll As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Timer As Integer
    End Structure

    Public Structure BloodRec
        Dim Sprite As Integer
        Dim Timer As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

End Module