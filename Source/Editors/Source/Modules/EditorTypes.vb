Module EditorTypes
    ' Public data structures
    Public Map As MapRec
    Public TempTile(,) As TempTileRec
    Public MapLock As New Object()
    Public Classes() As ClassRec
    Public Item(0 To MAX_ITEMS) As ItemRec
    Public Npc(0 To MAX_NPCS) As NpcRec
    Public MapItem(0 To MAX_MAP_ITEMS) As MapItemRec
    Public MapNpc(0 To MAX_MAP_NPCS) As MapNpcRec
    Public Shop(0 To MAX_SHOPS) As ShopRec
    Public Skill(0 To MAX_SKILLS) As SkillRec
    Public Resource(0 To MAX_RESOURCES) As ResourceRec
    Public Animation(0 To MAX_ANIMATIONS) As AnimationRec

    'Mapreport
    Public MapNames(0 To MAX_MAPS) As String

    ' options
    Public Options As OptionsRec

    ' Type recs
    Public Structure OptionsRec
        Dim SavePass As Boolean
        Dim Password As String
        Dim Username As String
        Dim IP As String
        Dim Port As Integer
        Dim MenuMusic As String
        Dim Music As Byte
        Dim Sound As Byte
        Dim Volume As Single
        Dim ScreenSize As Byte
    End Structure

    Public Structure RECT
        Dim top As Integer
        Dim left As Integer
        Dim right As Integer
        Dim bottom As Integer
    End Structure

    Public Structure TileDataRec
        Dim X As Byte
        Dim Y As Byte
        Dim Tileset As Byte
        Dim AutoTile As Byte
    End Structure

    Public Structure TileRec
        Dim Layer() As TileDataRec
        Dim Type As Byte
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim DirBlock As Byte
    End Structure

    Public Structure MapRec
        Dim MapNum As Integer
        Dim Name As String
        Dim Music As String

        Dim Revision As Integer
        Dim Moral As Byte
        Dim tileset As Integer

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

    Public Structure ItemRec
        Dim Name As String
        Dim Pic As Integer
        Dim Description As String

        Dim Type As Byte
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim ClassReq As Integer
        Dim AccessReq As Integer
        Dim LevelReq As Integer
        Dim Mastery As Byte
        Dim Price As Integer
        Dim Add_Stat() As Byte
        Dim Rarity As Byte
        Dim Speed As Integer
        Dim Handed As Integer
        Dim BindType As Byte
        Dim Stat_Req() As Byte
        Dim Animation As Integer
        Dim Paperdoll As Integer

        Dim Randomize As Byte
        Dim RandomMin As Byte
        Dim RandomMax As Byte

        Dim Stackable As Byte

        'Housing
        Dim FurnitureWidth As Integer
        Dim FurnitureHeight As Integer
        Dim FurnitureBlocks(,) As Integer
        Dim FurnitureFringe(,) As Integer

        Dim KnockBack As Byte
        Dim KnockBackTiles As Byte
    End Structure

    Public Structure MapItemRec
        Dim Num As Byte
        Dim Value As Integer
        Dim Frame As Byte
        Dim X As Byte
        Dim Y As Byte
    End Structure

    Public Structure NpcRec
        Dim Name As String
        Dim AttackSay As String
        Dim Sprite As Integer
        Dim SpawnSecs As Integer
        Dim Behaviour As Byte
        Dim Range As Byte
        Dim DropChance() As Integer
        Dim DropItem() As Integer
        Dim DropItemValue() As Integer
        Dim Stat() As Byte
        Dim Faction As Byte
        Dim HP As Integer
        Dim EXP As Integer
        Dim Animation As Integer
        Dim QuestNum As Integer
        Dim Skill() As Byte
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

    Public Structure TradeItemRec
        Dim Item As Integer
        Dim ItemValue As Integer
        Dim CostItem As Integer
        Dim CostValue As Integer
    End Structure

    Public Structure ShopRec
        Dim Name As String
        Dim Face As Byte
        Dim BuyRate As Integer
        Dim TradeItem() As TradeItemRec
    End Structure

    Public Structure SkillRec
        Dim Name As String
        Dim Type As Byte
        Dim MPCost As Integer
        Dim LevelReq As Integer
        Dim AccessReq As Integer
        Dim ClassReq As Integer
        Dim CastTime As Integer
        Dim CDTime As Integer
        Dim Icon As Integer
        Dim Map As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Byte
        Dim Vital As Integer
        Dim Duration As Integer
        Dim Interval As Integer
        Dim Range As Integer
        Dim IsAoE As Boolean
        Dim AoE As Integer
        Dim CastAnim As Integer
        Dim SkillAnim As Integer
        Dim StunDuration As Integer

        Dim IsProjectile As Integer '0 is no, 1 is yes
        Dim Projectile As Integer

        Dim KnockBack As Byte '0 is no, 1 is yes
        Dim KnockBackTiles As Byte
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

    Public Structure ResourceRec
        Dim Name As String
        Dim SuccessMessage As String
        Dim EmptyMessage As String
        Dim ResourceType As Integer
        Dim ResourceImage As Integer
        Dim ExhaustedImage As Integer
        Dim ExpReward As Integer
        Dim ItemReward As Integer
        Dim ToolRequired As Integer
        Dim LvlRequired As Integer
        Dim Health As Integer
        Dim RespawnTime As Integer
        Dim Walkthrough As Boolean
        Dim Animation As Integer
    End Structure

    Public Structure AnimationRec
        Dim Name As String
        Dim Sprite() As Integer
        Dim Frames() As Integer
        Dim LoopCount() As Integer
        Dim looptime() As Integer
    End Structure

    Public Structure AnimInstanceRec
        Dim Animation As Integer
        Dim X As Integer
        Dim Y As Integer
        ' used for locking to players/npcs
        Dim lockindex As Integer
        Dim LockType As Byte
        ' timing
        Dim Timer() As Integer
        ' rendering check
        Dim Used() As Boolean
        ' counting the loop
        Dim LoopIndex() As Integer
        Dim FrameIndex() As Integer
    End Structure

End Module
