Public Module OldStuff
#Region "Maps"
    Public OldMap As OldMapRec
    Public Const MAX_MAP_NPCS As Byte = 30

    Public Enum MapLayer As Byte
        Ground = 1
        Mask
        Mask2
        Fringe
        Fringe2
        Count
    End Enum

    Public Structure OldTileDataRec
        Dim X As Byte
        Dim Y As Byte
        Dim Tileset As Byte
        Dim Autotile As Byte
    End Structure

    Public Structure OldTileRec
        Dim Layer() As OldTileDataRec
        Dim Type As Byte
        Dim Data1 As Long
        Dim Data2 As Long
        Dim Data3 As Long
        Dim DirBlock As Byte
    End Structure

    Public Structure OldMapRec
        Dim Name As String
        Dim Music As String

        Dim Revision As Long
        Dim Moral As Byte
        Dim Tileset As Long

        Dim Up As Integer
        Dim Down As Integer
        Dim Left As Integer
        Dim Right As Integer

        Dim BootMap As Integer
        Dim BootX As Byte
        Dim BootY As Byte

        Dim MaxX As Byte
        Dim MaxY As Byte

        Dim Tile(,) As OldTileRec

        Dim Npc() As Integer

        Dim EventCount As Long

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
    End Structure

    Sub ClearOldMap()
        Dim x As Long
        Dim y As Long
        OldMap = Nothing
        OldMap.Tileset = 1
        OldMap.Name = ""
        OldMap.MaxX = 50
        OldMap.MaxY = 50
        ReDim OldMap.Npc(0 To MAX_MAP_NPCS)
        ReDim OldMap.Tile(0 To OldMap.MaxX, 0 To OldMap.MaxY)

        For x = 0 To 50
            For y = 0 To 50
                ReDim OldMap.Tile(x, y).Layer(0 To MapLayer.Count - 1)
            Next
        Next

        OldMap.EventCount = 0

        OldMap.Tileset = 1
        OldMap.Name = ""
        OldMap.Music = ""
        OldMap.MaxX = 50
        OldMap.MaxY = 50
    End Sub

    Sub LoadOldMap(ByVal filename As String)

        Dim F As Long
        Dim x As Long
        Dim y As Long
        Dim l As Long

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        FileGetObject(F, OldMap.Name)
        FileGetObject(F, OldMap.Music)
        FileGetObject(F, OldMap.Revision)
        FileGetObject(F, OldMap.Moral)
        FileGetObject(F, OldMap.Tileset)
        FileGetObject(F, OldMap.Up)
        FileGetObject(F, OldMap.Down)
        FileGetObject(F, OldMap.Left)
        FileGetObject(F, OldMap.Right)
        FileGetObject(F, OldMap.BootMap)
        FileGetObject(F, OldMap.BootX)
        FileGetObject(F, OldMap.BootY)
        FileGetObject(F, OldMap.MaxX)
        FileGetObject(F, OldMap.MaxY)
        FileGetObject(F, OldMap.WeatherType)
        FileGetObject(F, OldMap.FogIndex)
        FileGetObject(F, OldMap.WeatherIntensity)
        FileGetObject(F, OldMap.FogAlpha)
        FileGetObject(F, OldMap.FogSpeed)
        FileGetObject(F, OldMap.HasMapTint)
        FileGetObject(F, OldMap.MapTintR)
        FileGetObject(F, OldMap.MapTintG)
        FileGetObject(F, OldMap.MapTintB)
        FileGetObject(F, OldMap.MapTintA)

        ' have to set the tile()
        ReDim OldMap.Tile(0 To OldMap.MaxX, 0 To OldMap.MaxY)

        For x = 0 To OldMap.MaxX
            For y = 0 To OldMap.MaxY
                FileGetObject(F, OldMap.Tile(x, y).Data1)
                FileGetObject(F, OldMap.Tile(x, y).Data2)
                FileGetObject(F, OldMap.Tile(x, y).Data3)
                FileGetObject(F, OldMap.Tile(x, y).DirBlock)
                ReDim OldMap.Tile(x, y).Layer(0 To MapLayer.Count - 1)
                For l = 0 To MapLayer.Count - 1
                    FileGetObject(F, OldMap.Tile(x, y).Layer(l).Tileset)
                    FileGetObject(F, OldMap.Tile(x, y).Layer(l).X)
                    FileGetObject(F, OldMap.Tile(x, y).Layer(l).Y)
                    FileGetObject(F, OldMap.Tile(x, y).Layer(l).Autotile)
                Next
                FileGetObject(F, OldMap.Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            FileGetObject(F, OldMap.Npc(x))
        Next

        FileClose(F)

    End Sub
#End Region

#Region "Npc's"
    Public OldNpc As OldNpcRec
    Public Const MAX_NPC_SKILLS As Byte = 6
    Public Const MAX_NPCS As Byte = 255
    ''' <Summary> Stats used by Players Npcs and Classes </Summary>
    Public Enum Stats As Byte
        strength = 1
        endurance
        vitality
        luck
        intelligence
        spirit
        Count
    End Enum

    Public Structure OldNpcRec
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
        Dim Exp As Long
        Dim Animation As Long
        Dim QuestNum As Long
        Dim Skill() As Byte
    End Structure

    Public Sub ClearOldNpcs()
        OldNpc = Nothing
        OldNpc.Name = ""
        OldNpc.AttackSay = ""
        ReDim OldNpc.Stat(0 To Stats.Count - 1)
        For i = 1 To 5
            ReDim OldNpc.DropChance(5)
            ReDim OldNpc.DropItem(5)
            ReDim OldNpc.DropItemValue(5)
            ReDim OldNpc.Skill(MAX_NPC_SKILLS)
        Next
    End Sub

    Sub LoadOldNpc(ByVal filename As String)
        Dim F As Long
        Dim n As Long

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, OldNpc.Name)
        FileGetObject(F, OldNpc.AttackSay)
        FileGetObject(F, OldNpc.Sprite)
        FileGetObject(F, OldNpc.SpawnSecs)
        FileGetObject(F, OldNpc.Behaviour)
        FileGetObject(F, OldNpc.Range)

        For i = 1 To 5
            FileGetObject(F, OldNpc.DropChance(i))
            FileGetObject(F, OldNpc.DropItem(i))
            FileGetObject(F, OldNpc.DropItemValue(i))
        Next

        For n = 0 To Stats.Count - 1
            FileGetObject(F, OldNpc.Stat(n))
        Next

        FileGetObject(F, OldNpc.Faction)
        FileGetObject(F, OldNpc.HP)
        FileGetObject(F, OldNpc.Exp)
        FileGetObject(F, OldNpc.Animation)

        FileGetObject(F, OldNpc.QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            FileGetObject(F, OldNpc.Skill(i))
        Next

        FileClose(F)

        If OldNpc.Name Is Nothing Then OldNpc.Name = ""
        If OldNpc.AttackSay Is Nothing Then OldNpc.AttackSay = ""
    End Sub
#End Region

#Region "Items"
    Public OldItem As OldItemRec
    Public Const MAX_ITEMS As Byte = 255

    Public Structure OldItemRec
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
        Dim price As Long
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

    Sub ClearOldItems()
        OldItem = Nothing
        OldItem.Name = ""
        OldItem.Description = ""

        For i = 0 To MAX_ITEMS
            ReDim OldItem.Add_Stat(0 To Stats.Count - 1)
            ReDim OldItem.Stat_Req(0 To Stats.Count - 1)
            ReDim OldItem.FurnitureBlocks(0 To 3, 0 To 3)
            ReDim OldItem.FurnitureFringe(0 To 3, 0 To 3)
        Next

    End Sub

    Sub LoadOldItem(ByVal filename As String)
        Dim F As Long
        Dim s As Long

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        FileGetObject(F, OldItem.Name)
        FileGetObject(F, OldItem.Pic)
        FileGetObject(F, OldItem.Description)

        FileGetObject(F, OldItem.Type)
        FileGetObject(F, OldItem.Data1)
        FileGetObject(F, OldItem.Data2)
        FileGetObject(F, OldItem.Data3)
        FileGetObject(F, OldItem.ClassReq)
        FileGetObject(F, OldItem.AccessReq)
        FileGetObject(F, OldItem.LevelReq)
        FileGetObject(F, OldItem.Mastery)
        FileGetObject(F, OldItem.price)

        For s = 0 To Stats.Count - 1
            FileGetObject(F, OldItem.Add_Stat(s))
        Next

        FileGetObject(F, OldItem.Rarity)
        FileGetObject(F, OldItem.Speed)
        FileGetObject(F, OldItem.Handed)
        FileGetObject(F, OldItem.BindType)

        For s = 0 To Stats.Count - 1
            FileGetObject(F, OldItem.Stat_Req(s))
        Next

        FileGetObject(F, OldItem.Animation)
        FileGetObject(F, OldItem.Paperdoll)

        'Housing
        FileGetObject(F, OldItem.FurnitureWidth)
        FileGetObject(F, OldItem.FurnitureHeight)

        For a = 1 To 3
            For b = 1 To 3
                FileGetObject(F, OldItem.FurnitureBlocks(a, b))
                FileGetObject(F, OldItem.FurnitureFringe(a, b))
            Next
        Next

        FileGetObject(F, OldItem.KnockBack)
        FileGetObject(F, OldItem.KnockBackTiles)

        FileGetObject(F, OldItem.Randomize)
        FileGetObject(F, OldItem.RandomMin)
        FileGetObject(F, OldItem.RandomMax)

        FileGetObject(F, OldItem.Stackable)

        FileClose(F)

    End Sub
#End Region
End Module