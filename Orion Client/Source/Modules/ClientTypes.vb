Module ClientTypes
    ' Public data structures
    Public Map As MapRec
    Public MapLock As New Object()
    Public Bank As BankRec
    Public TempTile(,) As TempTileRec
    Public Player(0 To MAX_PLAYERS) As PlayerRec
    Public Classes() As ClassRec
    Public Item(0 To MAX_ITEMS) As ItemRec
    Public Npc(0 To MAX_NPCS) As NpcRec
    Public MapItem(0 To MAX_MAP_ITEMS) As MapItemRec
    Public MapNpc(0 To MAX_MAP_NPCS) As MapNpcRec
    Public Shop(0 To MAX_SHOPS) As ShopRec
    Public Skill(0 To MAX_SKILLS) As SkillRec
    Public Resource(0 To MAX_RESOURCES) As ResourceRec
    Public Animation(0 To MAX_ANIMATIONS) As AnimationRec

    ' client-side stuff
    Public ActionMsg(0 To MAX_BYTE) As ActionMsgRec
    Public Blood(0 To MAX_BYTE) As BloodRec
    Public AnimInstance(0 To MAX_BYTE) As AnimInstanceRec
    Public Chat As New List(Of ChatRec)

    'Mapreport
    Public MapNames(0 To MAX_MAPS) As String

    ' options
    Public Options As OptionsRec

    Public CharSelection() As CharSelRec
    Public Structure CharSelRec
        Dim Name As String
        Dim Sprite As Long
        Dim Gender As Integer
        Dim ClassName As String
        Dim Level As Integer
    End Structure

    ' Type recs
    Public Structure OptionsRec
        Dim SavePass As Boolean
        Dim Password As String
        Dim Username As String
        Dim IP As String
        Dim Port As Long
        Dim MenuMusic As String
        Dim Music As Byte
        Dim Sound As Byte
        Dim Volume As Single
        Dim ScreenSize As Byte
    End Structure

    Public Structure RECT
        Dim top As Long
        Dim left As Long
        Dim right As Long
        Dim bottom As Long
    End Structure

    Public Structure ChatRec
        Dim Text As String
        Dim Color As Long
        Dim Y As Byte
    End Structure

    Public Structure PlayerInvRec
        Dim Num As Byte
        Dim Value As Long
    End Structure

    Public Structure BankRec
        Dim Item() As PlayerInvRec
    End Structure

    Public Structure SkillAnim
        Dim skillnum As Integer
        Dim Timer As Long
        Dim FramePointer As Long
    End Structure

    Public Structure PlayerRec
        ' General
        Dim Name As String
        Dim Classes As Byte
        Dim Sprite As Integer
        Dim Level As Byte
        Dim EXP As Long
        Dim Access As Byte
        Dim PK As Byte
        ' Vitals
        Dim Vital() As Long
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
        Dim MaxHP As Long
        Dim MaxMP As Long
        Dim MaxSP As Long
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Moving As Byte
        Dim Attacking As Byte
        Dim AttackTimer As Long
        Dim MapGetTimer As Long
        Dim Steps As Byte

        Dim PlayerQuest() As PlayerQuestRec

        'Housing
        Dim House As PlayerHouseRec

        Dim InHouse As Long
        Dim LastMap As Long
        Dim LastX As Long
        Dim LastY As Long

        Dim Hotbar() As HotbarRec

        Dim EventTimer As Long

        'gather skills
        Dim GatherSkills() As ResourceSkillsRec

        Dim RecipeLearned() As Byte
    End Structure

    Public Structure TileDataRec
        Dim X As Byte
        Dim Y As Byte
        Dim Tileset As Byte
        Dim Autotile As Byte
    End Structure

    Public Structure TileRec
        Dim Layer() As TileDataRec
        Dim Type As Byte
        Dim Data1 As Long
        Dim Data2 As Long
        Dim Data3 As Long
        Dim DirBlock As Byte
    End Structure

    Public Structure MapRec
        Dim Name As String
        Dim Music As String

        Dim Revision As Long
        Dim Moral As Byte
        Dim tileset As Long

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
        Dim EventCount As Long
        Dim Events() As EventRec

        Dim WeatherType As Byte
        Dim FogIndex As Long
        Dim WeatherIntensity As Long
        Dim FogAlpha As Byte
        Dim FogSpeed As Byte

        Dim HasMapTint As Byte
        Dim MapTintR As Byte
        Dim MapTintG As Byte
        Dim MapTintB As Byte
        Dim MapTintA As Byte

        'Client Side Only -- Temporary
        Dim CurrentEvents As Long
        Dim MapEvents() As MapEventRec
    End Structure

    Public Structure ClassRec
        Dim Name As String
        Dim Desc As String
        Dim Stat() As Byte
        Dim MaleSprite() As Long
        Dim FemaleSprite() As Long
        Dim StartItem() As Long
        Dim StartValue() As Long
        Dim StartMap As Long
        Dim StartX As Byte
        Dim StartY As Byte
        Dim BaseExp As Long
        ' For client use
        Dim Vital() As Long
    End Structure

    Public Structure ItemRec
        Dim Name As String
        Dim Pic As Integer
        Dim Description As String

        Dim Type As Byte
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim ClassReq As Long
        Dim AccessReq As Long
        Dim LevelReq As Long
        Dim Mastery As Byte
        Dim Price As Long
        Dim Add_Stat() As Byte
        Dim Rarity As Byte
        Dim Speed As Long
        Dim Handed As Long
        Dim BindType As Byte
        Dim Stat_Req() As Byte
        Dim Animation As Long
        Dim Paperdoll As Long

        Dim Randomize As Byte
        Dim RandomMin As Byte
        Dim RandomMax As Byte

        Dim Stackable As Byte

        'Housing
        Dim FurnitureWidth As Long
        Dim FurnitureHeight As Long
        Dim FurnitureBlocks(,) As Long
        Dim FurnitureFringe(,) As Long

        Dim KnockBack As Byte
        Dim KnockBackTiles As Byte
    End Structure

    Public Structure MapItemRec
        Dim Num As Byte
        Dim Value As Long
        Dim Frame As Byte
        Dim X As Byte
        Dim Y As Byte
    End Structure

    Public Structure NpcRec
        Dim Name As String
        Dim AttackSay As String
        Dim Sprite As Long
        Dim SpawnSecs As Long
        Dim Behaviour As Byte
        Dim Range As Byte
        Dim DropChance() As Long
        Dim DropItem() As Long
        Dim DropItemValue() As Long
        Dim Stat() As Byte
        Dim Faction As Byte
        Dim HP As Long
        Dim EXP As Long
        Dim Animation As Long
        Dim QuestNum As Long
        Dim Skill() As Byte
    End Structure

    Public Structure MapNpcRec
        Dim Num As Byte
        Dim Target As Byte
        Dim TargetType As Byte
        Dim Vital() As Long
        Dim Map As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte
        ' Client use only
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Moving As Byte
        Dim Attacking As Byte
        Dim AttackTimer As Long
        Dim Steps As Long
    End Structure

    Public Structure TradeItemRec
        Dim Item As Long
        Dim ItemValue As Long
        Dim CostItem As Long
        Dim CostValue As Long
    End Structure

    Public Structure ShopRec
        Dim Name As String
        Dim Face As Byte
        Dim BuyRate As Long
        Dim TradeItem() As TradeItemRec
    End Structure

    Public Structure SkillRec
        Dim Name As String
        Dim Type As Byte
        Dim MPCost As Long
        Dim LevelReq As Long
        Dim AccessReq As Long
        Dim ClassReq As Long
        Dim CastTime As Long
        Dim CDTime As Long
        Dim Icon As Long
        Dim Map As Long
        Dim X As Long
        Dim Y As Long
        Dim Dir As Byte
        Dim Vital As Long
        Dim Duration As Long
        Dim Interval As Long
        Dim Range As Long
        Dim IsAoE As Boolean
        Dim AoE As Long
        Dim CastAnim As Long
        Dim SkillAnim As Long
        Dim StunDuration As Long

        Dim IsProjectile As Long '0 is no, 1 is yes
        Dim Projectile As Long

        Dim KnockBack As Byte '0 is no, 1 is yes
        Dim KnockBackTiles As Byte
    End Structure

    Public Structure TempTileRec
        Dim DoorOpen As Byte
        Dim DoorFrame As Byte
        Dim DoorTimer As Long
        Dim DoorAnimate As Byte ' 0 = nothing| 1 = opening | 2 = closing
    End Structure

    Public Structure MapResourceRec
        Dim X As Long
        Dim Y As Long
        Dim ResourceState As Byte
    End Structure

    Public Structure ResourceRec
        Dim Name As String
        Dim SuccessMessage As String
        Dim EmptyMessage As String
        Dim ResourceType As Long
        Dim ResourceImage As Long
        Dim ExhaustedImage As Long
        Dim ExpReward As Long
        Dim ItemReward As Long
        Dim ToolRequired As Long
        Dim LvlRequired As Long
        Dim Health As Long
        Dim RespawnTime As Long
        Dim Walkthrough As Boolean
        Dim Animation As Long
    End Structure

    Public Structure ActionMsgRec
        Dim message As String
        Dim Created As Long
        Dim Type As Long
        Dim color As Long
        Dim Scroll As Long
        Dim X As Long
        Dim Y As Long
        Dim Timer As Long
    End Structure

    Public Structure BloodRec
        Dim Sprite As Long
        Dim Timer As Long
        Dim X As Long
        Dim Y As Long
    End Structure

    Public Structure AnimationRec
        Dim Name As String
        Dim Sprite() As Long
        Dim Frames() As Long
        Dim LoopCount() As Long
        Dim looptime() As Long
    End Structure

    Public Structure AnimInstanceRec
        Dim Animation As Long
        Dim X As Long
        Dim Y As Long
        ' used for locking to players/npcs
        Dim lockindex As Long
        Dim LockType As Byte
        ' timing
        Dim Timer() As Long
        ' rendering check
        Dim Used() As Boolean
        ' counting the loop
        Dim LoopIndex() As Long
        Dim FrameIndex() As Long
    End Structure

    Public Structure ChatBubbleRec
        Dim Msg As String
        Dim colour As Long
        Dim target As Long
        Dim targetType As Byte
        Dim Timer As Long
        Dim active As Boolean
    End Structure

    Public Structure ResourceSkillsRec
        Dim SkillLevel As Long
        Dim SkillCurExp As Long
        Dim SkillNextLvlExp As Long
    End Structure

End Module
