Module Enums
    ''' <Summary> Text Color Contstant </Summary>
    Enum ColorType As Byte
        Black
        Blue
        Green
        Cyan
        Red
        Magenta
        Brown
        Gray
        DarkGray
        BrightBlue
        BrightGreen
        BrightCyan
        BrightRed
        Pink
        Yellow
        White
    End Enum

    ''' <Summary> Quick Access/Constant Color References </Summary>
    Enum QColorType As Byte
        SayColor = ColorType.White
        GlobalColor = ColorType.BrightBlue
        BroadcastColor = ColorType.White
        TellColor = ColorType.BrightGreen
        EmoteColor = ColorType.BrightCyan
        AdminColor = ColorType.BrightCyan
        HelpColor = ColorType.BrightBlue
        WhoColor = ColorType.BrightBlue
        JoinLeftColor = ColorType.DarkGray
        NpcColor = ColorType.Brown
        AlertColor = ColorType.Red
        NewMapColor = ColorType.BrightBlue
    End Enum

    ''' <Summary> Sex Constant </Summary>
    Enum Sex As Byte
        Male
        Female
    End Enum

    ''' <Summary> Map Moral Constant </Summary>
    Enum MapMoral As Byte
        None
        Safe
        Indoors
    End Enum

    ''' <Summary> Tile Constant </Summary>
    Enum TileType As Byte
        None
        Blocked
        Warp
        Item
        NpcAvoid
        Key
        KeyOpen
        Resource
        Door
        NpcSpawn
        Shop
        Bank
        Heal
        Trap
        House
        Craft
        Light

        Count
    End Enum

    ''' <Summary> Item Constant </Summary>
    Enum ItemType As Byte
        None
        Equipment
        Consumable
        Key
        Currency
        Skill
        Furniture
        Recipe

        Count
    End Enum

    ''' <Summary> Direction Constant </Summary>
    Enum ConsumableType As Byte
        Hp
        Mp
        Sp
        Exp
    End Enum

    ''' <Summary> Direction Constant </Summary>
    Enum Direction As Byte
        Up
        Down
        Left
        Right
    End Enum

    ''' <Summary> Movement Constant </Summary>
    Enum MovementType As Byte
        Standing
        Walking
        Running
    End Enum

    ''' <Summary> Admin Constant </Summary>
    Enum AdminType As Byte
        Player
        Monitor
        Mapper
        Developer
        Creator
    End Enum

    ''' <Summary> Npc Behavior Constant </Summary>
    Enum NpcBehavior As Byte
        AttackOnSight
        AttackWhenAttacked
        Friendly
        ShopKeeper
        Guard
        Quest
    End Enum

    ''' <Summary> Skill Constant </Summary>
    Enum SkillType As Byte
        DamageHp
        DamageMp
        HealHp
        HealMp
        Warp
    End Enum

    ''' <Summary> Target Constant </Summary>
    Enum TargetType As Byte
        None
        Player
        Npc
        [Event]
    End Enum

    ''' <Summary> Action Message Constant </Summary>
    Enum ActionMsgType As Byte
        [Static]
        Scroll
        Screen
    End Enum

    ''' <Summary> Stats used by Players, Npcs and Classes </Summary>
    Public Enum Stats As Byte
        Strength = 1
        Endurance
        Vitality
        Luck
        Intelligence
        Spirit

        Count
    End Enum

    ''' <Summary> Vitals used by Players, Npcs, and Classes </Summary>
    Public Enum Vitals As Byte
        HP = 1
        MP
        SP

        Count
    End Enum

    ''' <Summary> Equipment used by Players </Summary>
    Public Enum EquipmentType As Byte
        Weapon = 1
        Armor
        Helmet
        Shield
        Shoes
        Gloves

        Count
    End Enum

    ''' <Summary> Layers in a map </Summary>
    Public Enum MapLayer As Byte
        Ground = 1
        Mask
        Mask2
        Fringe
        Fringe2

        Count
    End Enum

    ''' <Summary> Resource Skills </Summary>
    Public Enum ResourceSkills As Byte
        Herbalist = 1
        WoodCutter
        Miner
        Fisherman

        Count
    End Enum

    Public Enum RandomBonusType
        RANDOM_SPEED = 1            ' Reduces time between attacks by 20%
        RANDOM_DAMAGE        ' Increases base damage by 25%
        RANDOM_WARRIOR         ' Adds Strength and Endurance
        RANDOM_ARCHER        ' Adds Achery and Endurance
        RANDOM_MAGE          ' Adds Magic and Endurance
        RANDOM_JESTER         ' Adds Magic and Archery
        RANDOM_BATTLEMAGE     ' Adds Attack and Magic
        RANDOM_ROGUE         ' Adds Attack and Archery
        RANDOM_TOWER           ' Adds Endurance and Defense
        RANDOM_SURVIVALIST     ' Adds Cooking and Fishing
        RANDOM_PERFECTIONIST   ' Adds Mining and Jeweler
        RANDOM_COALMEN         ' Adds Mining and Blacksmithing
        RANDOM_BOWYER          ' Adds Woodcutting and Fletching
        RANDOM_BROKEN          ' Reduces damage and increases speed by 10%
        RANDOM_PRISM           ' Gives four random stats, but will always turn soulbound
        RANDOM_CANNON          ' Gives Attack, Ranged and Magic
    End Enum

    Public Enum RarityType
        RARITY_BROKEN = 1
        RARITY_COMMON
        RARITY_UNCOMMON
        RARITY_RARE
        RARITY_EPIC
    End Enum
End Module
