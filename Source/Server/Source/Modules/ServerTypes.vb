Module ServerTypes
    ' Public data structures
    Public Map(MAX_CACHED_MAPS) As MapRec
    Public TempTile(MAX_CACHED_MAPS) As TempTileRec
    Public PlayersOnMap(MAX_CACHED_MAPS) As Integer
    Public ResourceCache(MAX_CACHED_MAPS) As ResourceCacheRec
    Public Player(MAX_PLAYERS) As PlayerRec
    Public Bank(MAX_PLAYERS) As BankRec
    Public TempPlayer(MAX_PLAYERS) As TempPlayerRec
    Public Classes() As ClassRec
    Public Item(MAX_ITEMS) As ItemRec
    Public Npc(MAX_NPCS) As NpcRec
    Public MapItem(MAX_CACHED_MAPS, MAX_MAP_ITEMS) As MapItemRec
    Public MapNpc(MAX_CACHED_MAPS) As MapDataRec
    Public Shop(MAX_SHOPS) As ShopRec
    Public Skill(MAX_SKILLS) As SkillRec
    Public Resource(MAX_RESOURCES) As ResourceRec
    Public Animation(MAX_ANIMATIONS) As AnimationRec
    Public Options As OptionsRec

    Public Structure RandInvRec
        Dim Prefix As String
        Dim Suffix As String
        Dim Stat() As Integer
        Dim Rarity As Integer
        Dim Damage As Integer
        Dim Speed As Integer
    End Structure

    Public Structure OptionsRec
        Dim Game_Name As String
        Dim Motd As String
        Dim Port As Integer
        Dim Website As String
        Dim StartMap As Integer
        Dim StartX As Integer
        Dim StartY As Integer
    End Structure

    Public Structure PlayerInvRec
        Dim Num As Byte
        Dim Value As Integer
    End Structure

    Public Structure Cache
        Dim Data() As Byte
    End Structure

    Public Structure BankRec
        Dim Item() As PlayerInvRec
        Dim ItemRand() As RandInvRec
    End Structure

    Public Structure PlayerRec
        ' Account
        Dim Login As String
        Dim Password As String
        Dim Access As Byte

        'multi char
        Dim Character() As CharacterRec

    End Structure

    Public Structure CharacterRec
        ' General
        Dim Name As String
        Dim Sex As Byte
        Dim Classes As Byte
        Dim Sprite As Integer
        Dim Level As Byte
        Dim Exp As Integer

        Dim Pk As Byte

        ' Vitals
        Dim Vital() As Integer

        ' Stats
        Dim Stat() As Byte
        Dim Points As Byte

        ' Worn equipment
        Dim Equipment() As Byte

        ' Inventory
        Dim Inv() As PlayerInvRec
        Dim Skill() As Byte

        ' Position
        Dim Map As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Byte

        Dim PlayerQuest() As PlayerQuestRec

        'Housing
        Dim House As PlayerHouseRec

        Dim InHouse As Integer
        Dim LastMap As Integer
        Dim LastX As Integer
        Dim LastY As Integer

        'Hotbar
        Dim Hotbar() As HotbarRec

        'Event
        Dim Switches() As Byte
        Dim Variables() As Integer

        'gather skills
        Dim GatherSkills() As ResourceSkillsRec

        Dim RecipeLearned() As Byte

        ' Random Items
        Dim RandInv() As RandInvRec
        Dim RandEquip() As RandInvRec

        Dim Pet As PlayerPetRec
    End Structure

    Public Structure TempPlayerRec
        ' Non saved local vars
        Dim Buffer As ByteBuffer
        Dim InGame As Boolean
        Dim AttackTimer As Integer
        Dim DataTimer As Integer
        Dim DataBytes As Integer
        Dim DataPackets As Integer
        Dim PartyInvite As Integer
        Dim InParty As Byte
        Dim TargetType As Byte
        Dim Target As Byte
        Dim PartyStarter As Byte
        Dim GettingMap As Byte
        Dim SkillBuffer As Integer
        Dim SkillBufferTimer As Integer
        Dim SkillCD() As Integer
        Dim InShop As Integer
        Dim StunTimer As Integer
        Dim StunDuration As Integer
        Dim InBank As Boolean
        ' trade
        Dim TradeRequest As Integer
        Dim InTrade As Integer
        Dim TradeOffer() As PlayerInvRec
        Dim AcceptTrade As Boolean

        'Housing
        Dim BuyHouseIndex As Integer

        Dim InvitationIndex As Integer
        Dim InvitationTimer As Integer

        Dim EventMap As EventMapRec
        Dim EventProcessingCount As Integer
        Dim EventProcessing() As EventProcessingRec

        'multi char
        Dim CurChar As Byte

        'craft shit
        Dim IsCrafting As Boolean
        Dim CraftIt As Byte
        Dim CraftTimer As Integer
        Dim CraftTimeNeeded As Integer

        Dim CraftRecipe As Integer
        Dim CraftAmount As Integer

        Dim StopRegenTimer As Integer
        Dim StopRegen As Byte

        'instance stuff
        Dim InInstance As Byte
        Dim TmpInstanceNum As Integer
        Dim TmpMap As Integer
        Dim TmpX As Integer
        Dim TmpY As Integer

        'pets
        Dim PetTarget As Integer
        Dim PetTargetType As Integer
        Dim PetBehavior As Integer

        Dim GoToX As Integer
        Dim GoToY As Integer

        Dim PetStunTimer As Integer
        Dim PetStunDuration As Integer
        Dim PetAttackTimer As Integer

        Dim PetSkillCD() As Integer
        Dim PetskillBuffer As SkillBufferRec

        Dim PetDoT() As DoTRec
        Dim PetHoT() As DoTRec
        ' regen
        Dim PetstopRegen As Boolean
        Dim PetstopRegenTimer As Integer

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
    End Structure

    Public Structure ItemRec
        Dim Name As String
        Dim Pic As Integer
        Dim Description As String

        Dim Type As Byte
        Dim SubType As Byte
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
        Dim TwoHanded As Integer
        Dim BindType As Byte
        Dim Stat_Req() As Byte
        Dim Animation As Integer
        Dim Paperdoll As Integer

        Dim Randomize As Byte
        Dim RandomMin As Byte
        Dim RandomMax As Byte

        Dim Stackable As Byte

        Dim ItemLevel As Byte

        'Housing
        Dim FurnitureWidth As Integer
        Dim FurnitureHeight As Integer
        Dim FurnitureBlocks(,) As Integer
        Dim FurnitureFringe(,) As Integer

        Dim KnockBack As Byte
        Dim KnockBackTiles As Byte

        Dim Projectile As Integer
        Dim Ammo As Integer
    End Structure

    Public Structure MapItemRec
        Dim Num As Byte
        Dim Value As Integer
        Dim X As Byte
        Dim Y As Byte

        Dim RandData As RandInvRec
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
        Dim Hp As Integer
        Dim Exp As Integer
        Dim Animation As Integer
        Dim QuestNum As Integer
        Dim Skill() As Byte

        Dim Level As Integer
        Dim Damage As Integer
    End Structure

    Public Structure MapNpcRec
        Dim Num As Integer
        Dim Target As Integer
        Dim TargetType As Byte
        Dim Vital() As Integer
        Dim X As Byte
        Dim Y As Byte
        Dim Dir As Integer
        ' For server use only
        Dim SpawnWait As Integer
        Dim AttackTimer As Integer
        Dim StunDuration As Integer
        Dim StunTimer As Integer
        Dim SkillBuffer As Integer
        Dim SkillBufferTimer As Integer
        Dim SkillCD() As Integer
        Dim StopRegen As Byte
        Dim StopRegenTimer As Integer
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
        Dim MpCost As Integer
        Dim LevelReq As Integer
        Dim AccessReq As Integer
        Dim ClassReq As Integer
        Dim CastTime As Integer
        Dim CdTime As Integer
        Dim Icon As Integer
        Dim Map As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Byte
        Dim Vital As Integer
        Dim Duration As Integer
        Dim Interval As Integer
        Dim range As Integer
        Dim IsAoE As Boolean
        Dim AoE As Integer
        Dim CastAnim As Integer
        Dim SkillAnim As Integer
        Dim StunDuration As Integer

        'projectiles
        Dim IsProjectile As Integer '0 is no, 1 is yes
        Dim Projectile As Integer

        Dim KnockBack As Byte '0 is no, 1 is yes
        Dim KnockBackTiles As Byte
    End Structure

    Public Structure TempTileRec
        Dim DoorOpen(,) As Byte
        Dim DoorTimer As Integer
    End Structure

    Public Structure MapDataRec
        Dim Npc() As MapNpcRec
    End Structure

    Public Structure MapResourceRec
        Dim ResourceState As Byte
        Dim ResourceTimer As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Cur_Health As Byte
    End Structure

    Public Structure ResourceCacheRec
        Dim Resource_Count As Integer
        Dim ResourceData() As MapResourceRec
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
        Dim LvlRequired As Integer
        Dim ToolRequired As Integer
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
        Dim LoopTime() As Integer
    End Structure

    Public Structure HotbarRec
        Dim Slot As Integer
        Dim SlotType As Byte
    End Structure

    Public Structure ResourceSkillsRec
        Dim SkillLevel As Integer
        Dim SkillCurExp As Integer
        Dim SkillNextLvlExp As Integer
    End Structure

    Public Structure SkillBufferRec
        Dim Skill As Integer
        Dim Timer As Integer
        Dim Target As Integer
        Dim TargetTypes As Byte
    End Structure

    Public Structure DoTRec
        Dim Used As Boolean
        Dim Skill As Integer
        Dim Timer As Integer
        Dim Caster As Integer
        Dim StartTime As Integer
        'PET
        Dim AttackerType As Integer 'For Pets

    End Structure
End Module