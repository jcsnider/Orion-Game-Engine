Public Module NewStuff
#Region "Maps"
    Public NewMap As NewMapRec

    Public Structure NewTileDataRec
        Dim x As Byte
        Dim y As Byte
        Dim Tileset As Byte
        Dim AutoTile As Byte
    End Structure

    Public Structure NewTileRec
        Dim Layer() As NewTileDataRec
        Dim Type As Byte
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
        Dim DirBlock As Byte
    End Structure

    Public Structure NewMapRec
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

        Dim Tile(,) As NewTileRec

        Dim Npc() As Integer

        Dim EventCount As Integer

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
    End Structure

    Sub ClearNewMap()
        Dim x As Integer
        Dim y As Integer
        NewMap = Nothing
        NewMap.Tileset = 1
        NewMap.Name = ""
        NewMap.MaxX = 50
        NewMap.MaxY = 50
        ReDim NewMap.Npc(0 To MAX_MAP_NPCS)
        ReDim NewMap.Tile(0 To NewMap.MaxX, 0 To NewMap.MaxY)

        For x = 0 To 50
            For y = 0 To 50
                ReDim NewMap.Tile(x, y).Layer(0 To MapLayer.Count - 1)
            Next
        Next

        NewMap.EventCount = 0

        ' Reset the values for if a player is on the map or not
        NewMap.Tileset = 1
        NewMap.Name = ""
        NewMap.Music = ""
        NewMap.MaxX = 50
        NewMap.MaxY = 50
    End Sub

    Sub SaveNewMap(filename As String)
        Dim x As Integer, y As Integer, l As Integer

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(NewMap.Name)
        writer.Write(NewMap.Music)

        writer.Write(NewMap.Revision)
        writer.Write(NewMap.Moral)
        writer.Write(NewMap.Tileset)

        writer.Write(NewMap.Up)
        writer.Write(NewMap.Down)
        writer.Write(NewMap.Left)
        writer.Write(NewMap.Right)

        writer.Write(NewMap.BootMap)
        writer.Write(NewMap.BootX)
        writer.Write(NewMap.BootY)

        writer.Write(NewMap.MaxX)
        writer.Write(NewMap.MaxY)

        writer.Write(NewMap.WeatherType)
        writer.Write(NewMap.FogIndex)
        writer.Write(NewMap.WeatherIntensity)
        writer.Write(NewMap.FogAlpha)
        writer.Write(NewMap.FogSpeed)

        writer.Write(NewMap.HasMapTint)
        writer.Write(NewMap.MapTintR)
        writer.Write(NewMap.MapTintG)
        writer.Write(NewMap.MapTintB)
        writer.Write(NewMap.MapTintA)

        writer.Write(NewMap.Instanced)

        For x = 0 To NewMap.MaxX
            For y = 0 To NewMap.MaxY
                writer.Write(NewMap.Tile(x, y).Data1)
                writer.Write(NewMap.Tile(x, y).Data2)
                writer.Write(NewMap.Tile(x, y).Data3)
                writer.Write(NewMap.Tile(x, y).DirBlock)
                For l = 0 To MapLayer.Count - 1
                    writer.Write(NewMap.Tile(x, y).Layer(l).Tileset)
                    writer.Write(NewMap.Tile(x, y).Layer(l).x)
                    writer.Write(NewMap.Tile(x, y).Layer(l).y)
                    writer.Write(NewMap.Tile(x, y).Layer(l).AutoTile)
                Next
                writer.Write(NewMap.Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            writer.Write(NewMap.Npc(x))
        Next

        writer.Save(filename)
    End Sub
#End Region

#Region "Npc's"
    Public NewNpc As NewNpcRec

    Public Structure NewNpcRec
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
        Dim Exp As Integer
        Dim Animation As Integer
        Dim QuestNum As Integer
        Dim Skill() As Byte
    End Structure

    Sub SaveNewNpc(ByVal filename As String)
        Dim i As Integer

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(NewNpc.Name)
        writer.Write(NewNpc.AttackSay)
        writer.Write(NewNpc.Sprite)
        writer.Write(NewNpc.SpawnSecs)
        writer.Write(NewNpc.Behaviour)
        writer.Write(NewNpc.Range)

        For i = 1 To 5
            writer.Write(NewNpc.DropChance(i))
            writer.Write(NewNpc.DropItem(i))
            writer.Write(NewNpc.DropItemValue(i))
        Next

        For i = 0 To Stats.Count - 1
            writer.Write(NewNpc.Stat(i))
        Next

        writer.Write(NewNpc.Faction)
        writer.Write(NewNpc.HP)
        writer.Write(NewNpc.Exp)
        writer.Write(NewNpc.Animation)

        writer.Write(NewNpc.QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            writer.Write(NewNpc.Skill(i))
        Next

        writer.Save(filename)
    End Sub

    Sub ClearNewNpcs()
        NewNpc = Nothing
        NewNpc.Name = ""
        NewNpc.AttackSay = ""
        ReDim NewNpc.Stat(0 To Stats.Count - 1)
        For i = 1 To 5
            ReDim NewNpc.DropChance(5)
            ReDim NewNpc.DropItem(5)
            ReDim NewNpc.DropItemValue(5)
            ReDim NewNpc.Skill(MAX_NPC_SKILLS)
        Next
    End Sub
#End Region

#Region "Items"
    Public NewItem As NewItemRec

    Public Structure NewItemRec
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
        Dim price As Integer
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

    Sub ClearNewItems()
        NewItem = Nothing
        NewItem.Name = ""
        NewItem.Description = ""

        For i = 0 To MAX_ITEMS
            ReDim NewItem.Add_Stat(0 To Stats.Count - 1)
            ReDim NewItem.Stat_Req(0 To Stats.Count - 1)
            ReDim NewItem.FurnitureBlocks(0 To 3, 0 To 3)
            ReDim NewItem.FurnitureFringe(0 To 3, 0 To 3)
        Next

    End Sub

    Sub SaveNewItem(ByVal filename As String)

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(NewItem.Name)
        writer.Write(NewItem.Pic)
        writer.Write(NewItem.Description)

        writer.Write(NewItem.Type)
        writer.Write(NewItem.Data1)
        writer.Write(NewItem.Data2)
        writer.Write(NewItem.Data3)
        writer.Write(NewItem.ClassReq)
        writer.Write(NewItem.AccessReq)
        writer.Write(NewItem.LevelReq)
        writer.Write(NewItem.Mastery)
        writer.Write(NewItem.price)

        For i = 0 To Stats.Count - 1
            writer.Write(NewItem.Add_Stat(i))
        Next

        writer.Write(NewItem.Rarity)
        writer.Write(NewItem.Speed)
        writer.Write(NewItem.Handed)
        writer.Write(NewItem.BindType)

        For i = 0 To Stats.Count - 1
            writer.Write(NewItem.Stat_Req(i))
        Next

        writer.Write(NewItem.Animation)
        writer.Write(NewItem.Paperdoll)

        'Housing
        writer.Write(NewItem.FurnitureWidth)
        writer.Write(NewItem.FurnitureHeight)

        For a = 1 To 3
            For b = 1 To 3
                writer.Write(NewItem.FurnitureBlocks(a, b))
                writer.Write(NewItem.FurnitureFringe(a, b))
            Next
        Next

        writer.Write(NewItem.KnockBack)
        writer.Write(NewItem.KnockBackTiles)

        writer.Write(NewItem.Randomize)
        writer.Write(NewItem.RandomMin)
        writer.Write(NewItem.RandomMax)

        writer.Write(NewItem.Stackable)

        writer.Save(filename)
    End Sub
#End Region
End Module