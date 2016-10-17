Imports System.IO

Module Transition


    Public Sub Main()
        Console.WriteLine("Converting Maps...")
        ConvertMaps()
        Console.WriteLine("Converting Npcs...")
        ConvertNpcs()
        Console.WriteLine("Converting Items...")
        ConvertItems()
        Console.WriteLine("Done!")
        Console.ReadKey()
    End Sub

    Public Sub ChangeMapData()
        NewMap.Name = OldMap.Name
        NewMap.Music = OldMap.Music

        NewMap.Revision = OldMap.Revision
        NewMap.Moral = OldMap.Moral
        NewMap.Tileset = OldMap.Tileset

        NewMap.Up = OldMap.Up
        NewMap.Down = OldMap.Down
        NewMap.Left = OldMap.Left
        NewMap.Right = OldMap.Right

        NewMap.BootMap = OldMap.BootMap
        NewMap.BootX = OldMap.BootX
        NewMap.BootY = OldMap.BootY

        NewMap.MaxX = OldMap.MaxX
        NewMap.MaxY = OldMap.MaxY

        ReDim NewMap.Tile(0 To NewMap.MaxX, 0 To NewMap.MaxY)

        For x = 0 To OldMap.MaxX
            For y = 0 To OldMap.MaxY
                NewMap.Tile(x, y).Data1 = OldMap.Tile(x, y).Data1
                NewMap.Tile(x, y).Data2 = OldMap.Tile(x, y).Data2
                NewMap.Tile(x, y).Data3 = OldMap.Tile(x, y).Data3
                NewMap.Tile(x, y).DirBlock = OldMap.Tile(x, y).DirBlock
                ReDim NewMap.Tile(x, y).Layer(0 To MapLayer.Count - 1)
                For l = 0 To MapLayer.Count - 1
                    NewMap.Tile(x, y).Layer(l).Tileset = OldMap.Tile(x, y).Layer(l).Tileset
                    NewMap.Tile(x, y).Layer(l).x = OldMap.Tile(x, y).Layer(l).X
                    NewMap.Tile(x, y).Layer(l).y = OldMap.Tile(x, y).Layer(l).Y
                    NewMap.Tile(x, y).Layer(l).AutoTile = OldMap.Tile(x, y).Layer(l).Autotile
                Next
                NewMap.Tile(x, y).Type = OldMap.Tile(x, y).Type
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            NewMap.Npc(x) = OldMap.Npc(x)
        Next

        NewMap.EventCount = OldMap.EventCount

        NewMap.WeatherType = OldMap.WeatherType
        NewMap.FogIndex = OldMap.FogIndex
        NewMap.WeatherIntensity = OldMap.WeatherIntensity
        NewMap.FogAlpha = OldMap.FogAlpha
        NewMap.FogSpeed = OldMap.FogSpeed

        NewMap.HasMapTint = OldMap.HasMapTint
        NewMap.MapTintR = OldMap.MapTintR
        NewMap.MapTintG = OldMap.MapTintG
        NewMap.MapTintB = OldMap.MapTintB
        NewMap.MapTintA = OldMap.MapTintA
    End Sub

    Public Sub ChangeNpcData()
        NewNpc.Name = OldNpc.Name
        NewNpc.AttackSay = OldNpc.AttackSay
        NewNpc.Sprite = OldNpc.Sprite
        NewNpc.SpawnSecs = OldNpc.SpawnSecs
        NewNpc.Behaviour = OldNpc.Behaviour
        NewNpc.Range = OldNpc.Range

        For i = 1 To 5
            NewNpc.DropChance(i) = OldNpc.DropChance(i)
            NewNpc.DropItem(i) = OldNpc.DropItem(i)
            NewNpc.DropItemValue(i) = OldNpc.DropItemValue(i)
        Next

        For i = 0 To Stats.Count - 1
            NewNpc.Stat(i) = OldNpc.Stat(i)
        Next

        NewNpc.Faction = OldNpc.Faction
        NewNpc.HP = OldNpc.HP
        NewNpc.Exp = OldNpc.Exp
        NewNpc.Animation = OldNpc.Animation

        NewNpc.QuestNum = OldNpc.QuestNum

        For i = 1 To MAX_NPC_SKILLS
            NewNpc.Skill(i) = OldNpc.Skill(i)
        Next
    End Sub

    Public Sub ChangeItemData()

        NewItem.Name = OldItem.Name
        NewItem.Pic = OldItem.Pic
        NewItem.Description = OldItem.Description

        NewItem.Type = OldItem.Type
        NewItem.Data1 = OldItem.Data1
        NewItem.Data2 = OldItem.Data2
        NewItem.Data3 = OldItem.Data3
        NewItem.ClassReq = OldItem.ClassReq
        NewItem.AccessReq = OldItem.AccessReq
        NewItem.LevelReq = OldItem.LevelReq
        NewItem.Mastery = OldItem.Mastery
        NewItem.price = OldItem.price

        For i = 0 To Stats.Count - 1
            NewItem.Add_Stat(i) = OldItem.Add_Stat(i)
        Next

        NewItem.Rarity = OldItem.Rarity
        NewItem.Speed = OldItem.Speed
        NewItem.Handed = OldItem.Handed
        NewItem.BindType = OldItem.BindType

        For i = 0 To Stats.Count - 1
            NewItem.Stat_Req(i) = OldItem.Stat_Req(i)
        Next

        NewItem.Animation = OldItem.Animation
        NewItem.Paperdoll = OldItem.Paperdoll

        'Housing
        NewItem.FurnitureWidth = OldItem.FurnitureWidth
        NewItem.FurnitureHeight = OldItem.FurnitureHeight

        For a = 1 To 3
            For b = 1 To 3
                NewItem.FurnitureBlocks(a, b) = OldItem.FurnitureBlocks(a, b)
                NewItem.FurnitureFringe(a, b) = OldItem.FurnitureBlocks(a, b)
            Next
        Next

        NewItem.KnockBack = OldItem.KnockBack
        NewItem.KnockBackTiles = OldItem.KnockBackTiles

        NewItem.Randomize = OldItem.Randomize
        NewItem.RandomMin = OldItem.RandomMin
        NewItem.RandomMax = OldItem.RandomMax

        NewItem.Stackable = OldItem.Stackable
    End Sub

    Public Sub ConvertMaps()
        Dim cd As New System.IO.DirectoryInfo(Application.StartupPath & "\Maps\")
        Dim fd As System.IO.FileInfo() = cd.GetFiles()

        Directory.CreateDirectory(Application.StartupPath & "\NewMaps")

        For Each f As FileInfo In fd
            If f.Name.Contains("_eventdata") Then
                FileCopy(f.FullName, Application.StartupPath & "\NewMaps\" & f.Name)
                Continue For
            ElseIf Not f.Name.Contains(".dat") Then
                Continue For
            End If

            ClearOldMap()
            ClearNewMap()

            LoadOldMap(f.FullName)
            ChangeMapData()
            SaveNewMap(Application.StartupPath & "\NewMaps\" & f.Name)
        Next

        My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\Maps\", "OldMaps")
        My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\NewMaps\", "Maps")
    End Sub

    Public Sub ConvertNpcs()
        Dim cd As New System.IO.DirectoryInfo(Application.StartupPath & "\Npcs\")
        Dim fd As System.IO.FileInfo() = cd.GetFiles()

        Directory.CreateDirectory(Application.StartupPath & "\NewNpcs")

        For Each f As FileInfo In fd
            If Not f.Name.Contains(".dat") Then
                Continue For
            End If

            ClearOldNpcs()
            ClearNewNpcs()

            LoadOldNpc(f.FullName)
            ChangeNpcData()
            SaveNewNpc(Application.StartupPath & "\NewNpcs\" & f.Name)
        Next

        My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\Npcs\", "OldNpcs")
        My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\NewNpcs\", "Npcs")
    End Sub

    Public Sub ConvertItems()
        Dim cd As New System.IO.DirectoryInfo(Application.StartupPath & "\Items\")
        Dim fd As System.IO.FileInfo() = cd.GetFiles()

        Directory.CreateDirectory(Application.StartupPath & "\NewItems")

        For Each f As FileInfo In fd
            If Not f.Name.Contains(".dat") Then
                Continue For
            End If

            ClearOldItems()
            ClearNewItems()

            LoadOldItem(f.FullName)
            ChangeItemData()
            SaveNewItem(Application.StartupPath & "\NewItems\" & f.Name)
        Next

        My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\Items\", "OldItems")
        My.Computer.FileSystem.RenameDirectory(Application.StartupPath & "\NewItems\", "Items")
    End Sub
End Module
