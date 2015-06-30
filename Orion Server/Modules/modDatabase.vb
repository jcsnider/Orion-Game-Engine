Imports System.Runtime.InteropServices
Imports System.IO
Imports System.IO.Compression

Module modDataBase
    Public Declare Function VarPtr Lib "msvbvm60.dll" Alias "VarPtr" (ByVal lpObject As Object) As Long
    ' *************
    ' ** Classes **
    ' *************
    Public Sub CreateClassesINI()
        Dim filename As String
        filename = Application.StartupPath & "\data\classes.ini"
        Max_Classes = 1

        If Not FileExist(filename) Then
            Call PutVar(filename, "INIT", "MaxClasses", CStr(Max_Classes))
            Call PutVar(filename, "CLASS1", "Name", "Warrior")
            Call PutVar(filename, "CLASS1", "Malesprite", "1")
            Call PutVar(filename, "CLASS1", "Femalesprite", "2")
            Call PutVar(filename, "CLASS1", "Str", "5")
            Call PutVar(filename, "CLASS1", "End", "5")
            Call PutVar(filename, "CLASS1", "Vit", "5")
            Call PutVar(filename, "CLASS1", "Will", "5")
            Call PutVar(filename, "CLASS1", "Int", "5")
            Call PutVar(filename, "CLASS1", "Spir", "5")
        End If
    End Sub
    Sub ClearClasses()
        Dim i As Long

        For i = 1 To Max_Classes
            Classes(i) = Nothing
            Classes(i).Name = vbNullString
        Next

        ReDim Classes(0 To Max_Classes)
        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Stat_Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

    End Sub
    Sub LoadClasses()
        Dim filename As String
        Dim i As Long, n As Long
        Dim tmpSprite As String
        Dim tmpArray() As String
        Dim x As Long

        filename = Application.StartupPath & "\data\classes.ini"

        If Not FileExist(filename) Then Call CreateClassesINI()

        Max_Classes = Val(Getvar(filename, "INIT", "MaxClasses"))
        ReDim Classes(0 To Max_Classes)
        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Stat_Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

        Call ClearClasses()

        For i = 1 To Max_Classes
            Classes(i).Name = Getvar(filename, "CLASS" & i, "Name")

            ' read string of sprites
            tmpSprite = Getvar(filename, "CLASS" & i, "MaleSprite")
            ' split into an array of strings
            tmpArray = Split(tmpSprite, ",")
            ' redim the class sprite array
            ReDim Classes(i).MaleSprite(0 To UBound(tmpArray))
            ' loop through converting strings to values and store in the sprite array
            For n = 0 To UBound(tmpArray)
                Classes(i).MaleSprite(n) = Val(tmpArray(n))
            Next

            ' read string of sprites
            tmpSprite = Getvar(filename, "CLASS" & i, "FemaleSprite")
            ' split into an array of strings
            tmpArray = Split(tmpSprite, ",")
            ' redim the class sprite array
            ReDim Classes(i).FemaleSprite(0 To UBound(tmpArray))
            ' loop through converting strings to values and store in the sprite array
            For n = 0 To UBound(tmpArray)
                Classes(i).FemaleSprite(n) = Val(tmpArray(n))
            Next

            ' continue
            Classes(i).Stat(Stats.strength) = Val(Getvar(filename, "CLASS" & i, "Str"))
            Classes(i).Stat(Stats.endurance) = Val(Getvar(filename, "CLASS" & i, "End"))
            Classes(i).Stat(Stats.vitality) = Val(Getvar(filename, "CLASS" & i, "Vit"))
            Classes(i).Stat(Stats.willpower) = Val(Getvar(filename, "CLASS" & i, "Will"))
            Classes(i).Stat(Stats.intelligence) = Val(Getvar(filename, "CLASS" & i, "Int"))
            Classes(i).Stat(Stats.spirit) = Val(Getvar(filename, "CLASS" & i, "Spir"))

            ' loop for items & values
            For x = 1 To 5
                Classes(i).StartItem(x) = Val(Getvar(filename, "CLASS" & i, "StartItem" & x))
                Classes(i).StartValue(x) = Val(Getvar(filename, "CLASS" & i, "StartValue" & x))
            Next
        Next

    End Sub
    Sub SaveClasses()
        Dim filename As String
        Dim i As Long
        Dim x As Long

        filename = Application.StartupPath & "\data\classes.ini"

        For i = 1 To Max_Classes
            Call PutVar(filename, "CLASS" & i, "Name", Trim$(Classes(i).Name))
            Call PutVar(filename, "CLASS" & i, "Maleprite", "1")
            Call PutVar(filename, "CLASS" & i, "Femaleprite", "1")
            Call PutVar(filename, "CLASS" & i, "Str", Str(Classes(i).Stat(Stats.strength)))
            Call PutVar(filename, "CLASS" & i, "End", Str(Classes(i).Stat(Stats.endurance)))
            Call PutVar(filename, "CLASS" & i, "Vit", Str(Classes(i).Stat(Stats.vitality)))
            Call PutVar(filename, "CLASS" & i, "Will", Str(Classes(i).Stat(Stats.willpower)))
            Call PutVar(filename, "CLASS" & i, "Int", Str(Classes(i).Stat(Stats.intelligence)))
            Call PutVar(filename, "CLASS" & i, "Spr", Str(Classes(i).Stat(Stats.spirit)))
            ' loop for items & values
            For x = 1 To 5
                Call PutVar(filename, "CLASS" & i, "StartItem" & x, Str(Classes(i).StartItem(x)))
                Call PutVar(filename, "CLASS" & i, "StartValue" & x, Str(Classes(i).StartValue(x)))
            Next
        Next

    End Sub
    Function GetClassMaxVital(ByVal ClassNum As Long, ByVal Vital As Vitals) As Long
        GetClassMaxVital = 0

        Select Case Vital
            Case Vitals.HP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.vitality) \ 2) + Classes(ClassNum).Stat(Stats.vitality)) * 2
            Case Vitals.MP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.intelligence) \ 2) + Classes(ClassNum).Stat(Stats.intelligence)) * 2
            Case Vitals.SP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.spirit) \ 2) + Classes(ClassNum).Stat(Stats.spirit)) * 2
        End Select

    End Function
    Function GetClassName(ByVal ClassNum As Long) As String
        GetClassName = Trim$(Classes(ClassNum).Name)
    End Function


    ' **********
    ' ** Maps **
    ' **********
    Sub CheckMaps()
        Dim i As Long

        For i = 1 To MAX_MAPS

            If Not FileExist(Application.StartupPath & "\Data\maps\map" & i & ".dat") Then
                Call SaveMap(i)
            End If

        Next

    End Sub
    Sub ClearMap(ByVal MapNum As Long)
        Dim x As Long
        Dim y As Long
        Map(MapNum) = Nothing
        Map(MapNum).Tileset = 1
        Map(MapNum).Name = ""
        Map(MapNum).MaxX = MAX_MAPX
        Map(MapNum).MaxY = MAX_MAPY
        ReDim Map(MapNum).Npc(0 To MAX_MAP_NPCS)
        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)
        For x = 0 To MAX_MAPX
            For y = 0 To MAX_MAPY
                ReDim Map(MapNum).Tile(x, y).Layer(0 To MapLayer.Layer_Count - 1)
            Next
        Next

        ' Reset the values for if a player is on the map or not
        PlayersOnMap(MapNum) = NO
        Map(MapNum).Tileset = 1
        Map(MapNum).Name = ""
        Map(MapNum).Music = ""
        Map(MapNum).MaxX = MAX_MAPX
        Map(MapNum).MaxY = MAX_MAPY
        ' Reset the map cache array for this map.
        MapCache(MapNum).Data = Nothing
    End Sub
    Sub ClearMaps()
        Dim i As Long

        For i = 1 To MAX_MAPS
            Call ClearMap(i)
        Next

    End Sub
    Sub LoadMaps()
        Dim filename As String
        Dim i As Long
        Dim F As Long
        Dim x As Long
        Dim y As Long
        Dim l As Long
        Call CheckMaps()

        For i = 1 To MAX_MAPS
            filename = Application.StartupPath & "\data\maps\map" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Map(i).Name)
            FileGetObject(F, Map(i).Music)
            FileGetObject(F, Map(i).Revision)
            FileGetObject(F, Map(i).Moral)
            FileGetObject(F, Map(i).Tileset)
            FileGetObject(F, Map(i).Up)
            FileGetObject(F, Map(i).Down)
            FileGetObject(F, Map(i).Left)
            FileGetObject(F, Map(i).Right)
            FileGetObject(F, Map(i).BootMap)
            FileGetObject(F, Map(i).BootX)
            FileGetObject(F, Map(i).BootY)
            FileGetObject(F, Map(i).MaxX)
            FileGetObject(F, Map(i).MaxY)

            ' have to set the tile()
            ReDim Map(i).Tile(0 To Map(i).MaxX, 0 To Map(i).MaxY)

            For x = 0 To Map(i).MaxX
                For y = 0 To Map(i).MaxY
                    FileGetObject(F, Map(i).Tile(x, y).Data1)
                    FileGetObject(F, Map(i).Tile(x, y).Data2)
                    FileGetObject(F, Map(i).Tile(x, y).Data3)
                    FileGetObject(F, Map(i).Tile(x, y).DirBlock)
                    ReDim Map(i).Tile(x, y).Layer(0 To MapLayer.Layer_Count - 1)
                    For l = 0 To MapLayer.Layer_Count - 1
                        FileGetObject(F, Map(i).Tile(x, y).Layer(l).Tileset)
                        FileGetObject(F, Map(i).Tile(x, y).Layer(l).x)
                        FileGetObject(F, Map(i).Tile(x, y).Layer(l).y)
                    Next
                    FileGetObject(F, Map(i).Tile(x, y).Type)
                Next
            Next

            For x = 1 To MAX_MAP_NPCS
                FileGetObject(F, Map(i).Npc(x))
                MapNpc(i).Npc(x).Num = Map(i).Npc(x)
            Next

            FileClose(F)

            ClearTempTile(i)
            CacheResources(i)

            If Map(i).Name Is Nothing Then Map(i).Name = ""
            If Map(i).Music Is Nothing Then Map(i).Music = ""
            DoEvents()
        Next
    End Sub
    Sub SaveMap(ByVal MapNum As Long)
        Dim filename As String
        Dim F As Long
        Dim x As Long
        Dim y As Long
        Dim l As Long
        filename = Application.StartupPath & "\data\maps\map" & MapNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Map(MapNum).Name)
        FilePutObject(F, Map(MapNum).Music)
        FilePutObject(F, Map(MapNum).Revision)
        FilePutObject(F, Map(MapNum).Moral)
        FilePutObject(F, Map(MapNum).Tileset)
        FilePutObject(F, Map(MapNum).Up)
        FilePutObject(F, Map(MapNum).Down)
        FilePutObject(F, Map(MapNum).Left)
        FilePutObject(F, Map(MapNum).Right)
        FilePutObject(F, Map(MapNum).BootMap)
        FilePutObject(F, Map(MapNum).BootX)
        FilePutObject(F, Map(MapNum).BootY)
        FilePutObject(F, Map(MapNum).MaxX)
        FilePutObject(F, Map(MapNum).MaxY)
        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                FilePutObject(F, Map(MapNum).Tile(x, y).Data1)
                FilePutObject(F, Map(MapNum).Tile(x, y).Data2)
                FilePutObject(F, Map(MapNum).Tile(x, y).Data3)
                FilePutObject(F, Map(MapNum).Tile(x, y).DirBlock)
                For l = 0 To MapLayer.Layer_Count - 1
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).Tileset)
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).x)
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).y)
                Next
                FilePutObject(F, Map(MapNum).Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            FilePutObject(F, Map(MapNum).Npc(x))
        Next
        FileClose(F)
    End Sub
    Sub SaveMaps()
        Dim i As Long

        For i = 1 To MAX_MAPS
            Call SaveMap(i)
            DoEvents()
        Next

    End Sub
    Sub ClearTempTiles()
        Dim i As Long

        For i = 1 To MAX_MAPS
            ClearTempTile(i)
        Next

    End Sub
    Sub ClearTempTile(ByVal MapNum As Long)
        Dim y As Long
        Dim x As Long
        TempTile(MapNum).DoorTimer = 0
        ReDim TempTile(MapNum).DoorOpen(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                TempTile(MapNum).DoorOpen(x, y) = NO
            Next
        Next

    End Sub
    Sub ClearMapItem(ByVal Index As Long, ByVal MapNum As Long)
        MapItem(MapNum, Index) = Nothing
    End Sub
    Sub ClearMapItems()
        Dim x As Long
        Dim y As Long

        For y = 1 To MAX_MAPS
            For x = 1 To MAX_MAP_ITEMS
                Call ClearMapItem(x, y)
            Next
        Next

    End Sub




    ' ***********
    ' ** Items **
    ' ***********
    Sub SaveItems()
        Dim i As Long

        For i = 1 To MAX_ITEMS
            Call SaveItem(i)
            DoEvents()
        Next

    End Sub
    Sub SaveItem(ByVal itemNum As Long)
        Dim filename As String
        Dim F As Long
        filename = Application.StartupPath & "\data\items\item" & itemNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Item(itemNum).Name)
        FilePutObject(F, Item(itemNum).Pic)
        FilePutObject(F, Item(itemNum).Type)
        FilePutObject(F, Item(itemNum).Data1)
        FilePutObject(F, Item(itemNum).Data2)
        FilePutObject(F, Item(itemNum).Data3)
        FilePutObject(F, Item(itemNum).ClassReq)
        FilePutObject(F, Item(itemNum).AccessReq)
        FilePutObject(F, Item(itemNum).LevelReq)
        FilePutObject(F, Item(itemNum).Mastery)
        FilePutObject(F, Item(itemNum).price)
        For i = 0 To Stats.Stat_Count - 1
            FilePutObject(F, Item(itemNum).Add_Stat(i))
        Next
        FilePutObject(F, Item(itemNum).Rarity)
        FilePutObject(F, Item(itemNum).Speed)
        FilePutObject(F, Item(itemNum).Handed)
        FilePutObject(F, Item(itemNum).BindType)
        For i = 0 To Stats.Stat_Count - 1
            FilePutObject(F, Item(itemNum).Stat_Req(i))
        Next
        FilePutObject(F, Item(itemNum).Animation)
        FilePutObject(F, Item(itemNum).Paperdoll)
        FileClose()
    End Sub
    Sub LoadItems()
        Dim filename As String
        Dim i As Long
        Dim F As Long
        Dim s As Long
        Call CheckItems()

        For i = 1 To MAX_ITEMS
            filename = Application.StartupPath & "\data\Items\Item" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Item(i).Name)
            FileGetObject(F, Item(i).Pic)
            FileGetObject(F, Item(i).Type)
            FileGetObject(F, Item(i).Data1)
            FileGetObject(F, Item(i).Data2)
            FileGetObject(F, Item(i).Data3)
            FileGetObject(F, Item(i).ClassReq)
            FileGetObject(F, Item(i).AccessReq)
            FileGetObject(F, Item(i).LevelReq)
            FileGetObject(F, Item(i).Mastery)
            FileGetObject(F, Item(i).price)
            For s = 0 To Stats.Stat_Count - 1
                FileGetObject(F, Item(i).Add_Stat(s))
            Next
            FileGetObject(F, Item(i).Rarity)
            FileGetObject(F, Item(i).Speed)
            FileGetObject(F, Item(i).Handed)
            FileGetObject(F, Item(i).BindType)
            For s = 0 To Stats.Stat_Count - 1
                FileGetObject(F, Item(i).Stat_Req(s))
            Next
            FileGetObject(F, Item(i).Animation)
            FileGetObject(F, Item(i).Paperdoll)
            FileClose()
            DoEvents()
        Next

    End Sub
    Sub CheckItems()
        Dim i As Long

        For i = 1 To MAX_ITEMS

            If Not FileExist(Application.StartupPath & "\Data\Items\Item" & i & ".dat") Then
                Call SaveItem(i)
            End If

        Next

    End Sub
    Sub ClearItem(ByVal Index As Long)
        Item(Index) = Nothing
        Item(Index).Name = ""
        For i = 0 To MAX_ITEMS
            ReDim Item(i).Add_Stat(0 To Stats.Stat_Count - 1)
            ReDim Item(i).Stat_Req(0 To Stats.Stat_Count - 1)
        Next
    End Sub
    Sub ClearItems()
        Dim i As Long

        For i = 1 To MAX_ITEMS
            Call ClearItem(i)
        Next

    End Sub



    ' **********
    ' ** NPCs **
    ' **********
    Sub SaveNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS
            Call SaveNpc(i)
            DoEvents()
        Next

    End Sub
    Sub SaveNpc(ByVal NpcNum As Long)
        Dim filename As String
        Dim F As Long
        Dim i As Long
        filename = Application.StartupPath & "\data\npcs\npc" & NpcNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Npc(NpcNum).Name)
        FilePutObject(F, Npc(NpcNum).AttackSay)
        FilePutObject(F, Npc(NpcNum).Sprite)
        FilePutObject(F, Npc(NpcNum).SpawnSecs)
        FilePutObject(F, Npc(NpcNum).Behaviour)
        FilePutObject(F, Npc(NpcNum).range)
        FilePutObject(F, Npc(NpcNum).DropChance)
        FilePutObject(F, Npc(NpcNum).DropItem)
        FilePutObject(F, Npc(NpcNum).DropItemValue)
        For i = 0 To Stats.Stat_Count - 1
            FilePutObject(F, Npc(NpcNum).Stat(i))
        Next
        FilePutObject(F, Npc(NpcNum).faction)
        FilePutObject(F, Npc(NpcNum).HP)
        FilePutObject(F, Npc(NpcNum).exp)
        FilePutObject(F, Npc(NpcNum).Animation)
        FileClose()
    End Sub
    Sub LoadNpcs()
        Dim filename As String
        Dim i As Integer
        Dim F As Long
        Dim n As Long
        Call CheckNpcs()

        For i = 1 To MAX_NPCS
            filename = Application.StartupPath & "\data\npcs\npc" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Npc(i).Name)
            FileGetObject(F, Npc(i).AttackSay)
            FileGetObject(F, Npc(i).Sprite)
            FileGetObject(F, Npc(i).SpawnSecs)
            FileGetObject(F, Npc(i).Behaviour)
            FileGetObject(F, Npc(i).range)
            FileGetObject(F, Npc(i).DropChance)
            FileGetObject(F, Npc(i).DropItem)
            FileGetObject(F, Npc(i).DropItemValue)
            For n = 0 To Stats.Stat_Count - 1
                FileGetObject(F, Npc(i).Stat(n))
            Next
            FileGetObject(F, Npc(i).faction)
            FileGetObject(F, Npc(i).HP)
            FileGetObject(F, Npc(i).exp)
            FileGetObject(F, Npc(i).Animation)
            FileClose()
            If Npc(i).Name Is Nothing Then Npc(i).Name = ""
            If Npc(i).AttackSay Is Nothing Then Npc(i).AttackSay = ""
            DoEvents()
        Next

    End Sub
    Sub CheckNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS

            If Not FileExist(Application.StartupPath & "\Data\npcs\npc" & i & ".dat") Then
                Call SaveNpc(i)
            End If

        Next

    End Sub
    Sub ClearMapNpc(ByVal Index As Long, ByVal MapNum As Long)
        MapNpc(MapNum).Npc(Index) = Nothing

        ReDim MapNpc(MapNum).Npc(Index).Vital(0 To Vitals.Vital_Count)
    End Sub
    Sub ClearMapNpcs()
        Dim x As Long
        Dim y As Long

        For y = 1 To MAX_MAPS
            For x = 1 To MAX_MAP_NPCS
                Call ClearMapNpc(x, y)
            Next
        Next

    End Sub
    Sub ClearNpc(ByVal Index As Long)
        Npc(Index) = Nothing
        Npc(Index).Name = ""
        Npc(Index).AttackSay = ""
        ReDim Npc(Index).Stat(0 To Stats.Stat_Count - 1)
    End Sub
    Sub ClearNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS
            Call ClearNpc(i)
        Next

    End Sub




    ' ***************
    ' ** Resources **
    ' ***************
    Sub SaveResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES
            Call SaveResource(i)
            DoEvents()
        Next

    End Sub
    Sub SaveResource(ByVal ResourceNum As Long)
        Dim filename As String
        Dim F As Long
        filename = Application.StartupPath & "\data\resources\resource" & ResourceNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Resource(ResourceNum).Name)
        FilePutObject(F, Resource(ResourceNum).SuccessMessage)
        FilePutObject(F, Resource(ResourceNum).EmptyMessage)
        FilePutObject(F, Resource(ResourceNum).ResourceType)
        FilePutObject(F, Resource(ResourceNum).ResourceImage)
        FilePutObject(F, Resource(ResourceNum).ExhaustedImage)
        FilePutObject(F, Resource(ResourceNum).ItemReward)
        FilePutObject(F, Resource(ResourceNum).ToolRequired)
        FilePutObject(F, Resource(ResourceNum).health)
        FilePutObject(F, Resource(ResourceNum).RespawnTime)
        FilePutObject(F, Resource(ResourceNum).Walkthrough)
        FilePutObject(F, Resource(ResourceNum).Animation)
        FileClose()
    End Sub
    Sub LoadResources()
        Dim filename As String
        Dim i As Integer
        Dim F As Long

        Call CheckResources()

        For i = 1 To MAX_RESOURCES
            filename = Application.StartupPath & "\data\resources\resource" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Resource(i).Name)
            FileGetObject(F, Resource(i).SuccessMessage)
            FileGetObject(F, Resource(i).EmptyMessage)
            FileGetObject(F, Resource(i).ResourceType)
            FileGetObject(F, Resource(i).ResourceImage)
            FileGetObject(F, Resource(i).ExhaustedImage)
            FileGetObject(F, Resource(i).ItemReward)
            FileGetObject(F, Resource(i).ToolRequired)
            FileGetObject(F, Resource(i).health)
            FileGetObject(F, Resource(i).RespawnTime)
            FileGetObject(F, Resource(i).Walkthrough)
            FileGetObject(F, Resource(i).Animation)
            If Resource(i).Name Is Nothing Then Resource(i).Name = ""
            If Resource(i).EmptyMessage Is Nothing Then Resource(i).EmptyMessage = ""
            If Resource(i).SuccessMessage Is Nothing Then Resource(i).SuccessMessage = ""
            FileClose()
            DoEvents()
        Next

    End Sub
    Sub CheckResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES

            If Not FileExist(Application.StartupPath & "\Data\Resources\Resource" & i & ".dat") Then
                Call SaveResource(i)
            End If

        Next

    End Sub
    Sub ClearResource(ByVal Index As Long)
        Resource(Index) = Nothing
        Resource(Index).Name = ""
        Resource(Index).EmptyMessage = ""
        Resource(Index).SuccessMessage = ""
    End Sub
    Sub ClearResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES
            Call ClearResource(i)
        Next
    End Sub
    Public Sub CacheResources(ByVal MapNum As Long)
        Dim x As Long, y As Long, Resource_Count As Long
        Resource_Count = 0

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY

                If Map(MapNum).Tile(x, y).Type = TILE_TYPE_RESOURCE Then
                    Resource_Count = Resource_Count + 1
                    ReDim Preserve ResourceCache(MapNum).ResourceData(0 To Resource_Count)
                    ResourceCache(MapNum).ResourceData(Resource_Count).x = x
                    ResourceCache(MapNum).ResourceData(Resource_Count).y = y
                    ResourceCache(MapNum).ResourceData(Resource_Count).cur_health = Resource(Map(MapNum).Tile(x, y).Data1).health
                End If

            Next
        Next

        ResourceCache(MapNum).Resource_Count = Resource_Count
    End Sub




    ' ***********
    ' ** Shops **
    ' ***********
    Sub SaveShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS
            Call SaveShop(i)
            DoEvents()
        Next

    End Sub
    Sub SaveShop(ByVal shopNum As Long)
        Dim i As Long
        Dim filename As String
        Dim F As Long
        filename = Application.StartupPath & "\data\shops\shop" & shopNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Shop(shopNum).Name)
        FilePutObject(F, Shop(shopNum).BuyRate)
        For i = 1 To MAX_TRADES
            FilePutObject(F, Shop(shopNum).TradeItem(i).Item)
            FilePutObject(F, Shop(shopNum).TradeItem(i).ItemValue)
            FilePutObject(F, Shop(shopNum).TradeItem(i).costitem)
            FilePutObject(F, Shop(shopNum).TradeItem(i).costvalue)
        Next
        FileClose()
    End Sub
    Sub LoadShops()
        Dim filename As String
        Dim i As Long
        Dim x As Long
        Dim F As Long
        Call CheckShops()

        For i = 1 To MAX_SHOPS
            filename = Application.StartupPath & "\data\shops\shop" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Shop(i).Name)
            FileGetObject(F, Shop(i).BuyRate)
            For x = 1 To MAX_TRADES
                FileGetObject(F, Shop(i).TradeItem(x).Item)
                FileGetObject(F, Shop(i).TradeItem(x).ItemValue)
                FileGetObject(F, Shop(i).TradeItem(x).costitem)
                FileGetObject(F, Shop(i).TradeItem(x).costvalue)
            Next
            FileClose()
            DoEvents()
        Next

    End Sub
    Sub CheckShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS

            If Not FileExist(Application.StartupPath & "\Data\shops\shop" & i & ".dat") Then
                Call SaveShop(i)
            End If

        Next

    End Sub
    Sub ClearShop(ByVal Index As Long)
        Dim i As Long
        Shop(Index) = Nothing
        Shop(Index).Name = vbNullString
        ReDim Shop(Index).TradeItem(MAX_TRADES)
        For i = 0 To MAX_SHOPS
            ReDim Shop(i).TradeItem(0 To MAX_TRADES)
        Next

    End Sub
    Sub ClearShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS
            Call ClearShop(i)
        Next

    End Sub



    ' ************ '
    ' ** Spells ** '
    ' ************ '
    Sub SaveSpell(ByVal spellnum As Long)
        Dim filename As String
        Dim F As Long
        filename = Application.StartupPath & "\data\spells\spells" & spellnum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Spell(spellnum).Name)
        FilePutObject(F, Spell(spellnum).Type)
        FilePutObject(F, Spell(spellnum).MPCost)
        FilePutObject(F, Spell(spellnum).LevelReq)
        FilePutObject(F, Spell(spellnum).AccessReq)
        FilePutObject(F, Spell(spellnum).ClassReq)
        FilePutObject(F, Spell(spellnum).CastTime)
        FilePutObject(F, Spell(spellnum).CDTime)
        FilePutObject(F, Spell(spellnum).Icon)
        FilePutObject(F, Spell(spellnum).Map)
        FilePutObject(F, Spell(spellnum).x)
        FilePutObject(F, Spell(spellnum).y)
        FilePutObject(F, Spell(spellnum).Dir)
        FilePutObject(F, Spell(spellnum).Vital)
        FilePutObject(F, Spell(spellnum).Duration)
        FilePutObject(F, Spell(spellnum).Interval)
        FilePutObject(F, Spell(spellnum).range)
        FilePutObject(F, Spell(spellnum).IsAoE)
        FilePutObject(F, Spell(spellnum).AoE)
        FilePutObject(F, Spell(spellnum).CastAnim)
        FilePutObject(F, Spell(spellnum).SpellAnim)
        FilePutObject(F, Spell(spellnum).StunDuration)
        FileClose(F)
    End Sub
    Sub SaveSpells()
        Dim i As Long
        Call SetStatus("Saving spells... ")

        For i = 1 To MAX_SPELLS
            Call SaveSpell(i)
        Next

    End Sub
    Sub LoadSpells()
        Dim filename As String
        Dim i As Long
        Dim F As Long
        Call CheckSpells()

        For i = 1 To MAX_SPELLS
            filename = Application.StartupPath & "\data\spells\spells" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Spell(i).Name)
            FileGetObject(F, Spell(i).Type)
            FileGetObject(F, Spell(i).MPCost)
            FileGetObject(F, Spell(i).LevelReq)
            FileGetObject(F, Spell(i).AccessReq)
            FileGetObject(F, Spell(i).ClassReq)
            FileGetObject(F, Spell(i).CastTime)
            FileGetObject(F, Spell(i).CDTime)
            FileGetObject(F, Spell(i).Icon)
            FileGetObject(F, Spell(i).Map)
            FileGetObject(F, Spell(i).x)
            FileGetObject(F, Spell(i).y)
            FileGetObject(F, Spell(i).Dir)
            FileGetObject(F, Spell(i).Vital)
            FileGetObject(F, Spell(i).Duration)
            FileGetObject(F, Spell(i).Interval)
            FileGetObject(F, Spell(i).range)
            FileGetObject(F, Spell(i).IsAoE)
            FileGetObject(F, Spell(i).AoE)
            FileGetObject(F, Spell(i).CastAnim)
            FileGetObject(F, Spell(i).SpellAnim)
            FileGetObject(F, Spell(i).StunDuration)
            FileClose(F)
        Next

    End Sub
    Sub CheckSpells()
        Dim i As Long

        For i = 1 To MAX_SPELLS

            If Not FileExist(Application.StartupPath & "\Data\spells\spells" & i & ".dat") Then
                Call SaveSpell(i)
            End If

        Next

    End Sub
    Sub ClearSpell(ByVal Index As Long)
        Spell(Index) = Nothing
        Spell(Index).Name = vbNullString
        Spell(Index).LevelReq = 1 'Needs to be 1 for the spell editor
    End Sub
    Sub ClearSpells()
        Dim i As Long

        For i = 1 To MAX_SPELLS
            Call ClearSpell(i)
        Next

    End Sub




    ' **************** '
    ' ** Animations ** '
    ' **************** '
    Sub SaveAnimations()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS
            Call SaveAnimation(i)
            DoEvents()
        Next

    End Sub
    Sub SaveAnimation(ByVal AnimationNum As Long)
        Dim filename As String
        Dim F As Long
        Dim x As Long
        filename = Application.StartupPath & "\data\animations\animation" & AnimationNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Animation(AnimationNum).Name)
        For x = 1 To UBound(Animation(AnimationNum).Sprite)
            FilePutObject(F, Animation(AnimationNum).Sprite(x))
        Next
        For x = 1 To UBound(Animation(AnimationNum).Frames)
            FilePutObject(F, Animation(AnimationNum).Frames(x))
        Next
        For x = 1 To UBound(Animation(AnimationNum).LoopCount)
            FilePutObject(F, Animation(AnimationNum).LoopCount(x))
        Next
        For x = 1 To UBound(Animation(AnimationNum).LoopTime)
            FilePutObject(F, Animation(AnimationNum).LoopTime(x))
        Next
        FileClose()
    End Sub
    Sub LoadAnimations()
        Dim filename As String
        Dim i As Integer
        Dim F As Long

        Call CheckAnimations()

        For i = 1 To MAX_ANIMATIONS
            filename = Application.StartupPath & "\data\animations\animation" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            FileGetObject(F, Animation(i).Name)
            For x = 1 To UBound(Animation(i).Sprite)
                FileGetObject(F, Animation(i).Sprite(x))
            Next
            For x = 1 To UBound(Animation(i).Frames)
                FileGetObject(F, Animation(i).Frames(x))
            Next
            For x = 1 To UBound(Animation(i).LoopCount)
                FileGetObject(F, Animation(i).LoopCount(x))
            Next
            For x = 1 To UBound(Animation(i).LoopTime)
                FileGetObject(F, Animation(i).LoopTime(x))
            Next
            FileClose()
            If Animation(i).Name Is Nothing Then Animation(i).Name = ""
            DoEvents()
        Next

    End Sub
    Sub CheckAnimations()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS

            If Not FileExist("\Data\animations\animation" & i & ".dat") Then
                Call SaveAnimation(i)
            End If

        Next
    End Sub
    Sub ClearAnimation(ByVal Index As Long)
        Animation(Index) = Nothing
        Animation(Index).Name = ""
        ReDim Animation(Index).Sprite(0 To 1)
        ReDim Animation(Index).Frames(0 To 1)
        ReDim Animation(Index).LoopCount(0 To 1)
        ReDim Animation(Index).LoopTime(0 To 1)
    End Sub
    Sub ClearAnimations()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS
            Call ClearAnimation(i)
        Next
    End Sub



    ' **************
    ' ** Accounts **
    ' **************
    Function AccountExist(ByVal Name As String) As Boolean
        Dim filename As String
        filename = Application.StartupPath & "\data\accounts\" & Trim(Name) & ".bin"

        If FileExist(filename) Then
            AccountExist = True
        Else
            AccountExist = False
        End If
    End Function
    Function PasswordOK(ByVal Name As String, ByVal Password As String) As Boolean
        Dim filename As String
        Dim RightPassword As String
        Dim namecheck As String
        Dim nFileNum As Integer
        RightPassword = ""
        namecheck = ""
        PasswordOK = False
        If AccountExist(Name) Then
            filename = Application.StartupPath & "\data\accounts\" & Trim$(Name) & ".bin"
            nFileNum = FreeFile()
            FileOpen(nFileNum, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared)
            FileGetObject(nFileNum, namecheck)
            FileGetObject(nFileNum, RightPassword)
            FileClose()

            If Trim(namecheck) <> Trim(Name) Then
                Exit Function
            End If

            If UCase$(Trim$(Password)) = UCase$(Trim$(RightPassword)) Then
                PasswordOK = True
            Else
                PasswordOK = False
            End If
        End If
    End Function
    Sub AddAccount(ByVal Index As Long, ByVal Name As String, ByVal Password As String)
        ClearPlayer(Index)

        Player(Index).Login = Name
        Player(Index).Password = Password

        Call SavePlayer(Index)
    End Sub
    Sub DeleteName(ByVal Name As String)
        Dim f1 As Long
        Dim f2 As Long
        Dim s As String
        s = ""
        Call FileCopy(Application.StartupPath & "\data\accounts\charlist.txt", Application.StartupPath & "\data\accounts\chartemp.txt")
        ' Destroy name from charlist
        f1 = FreeFile()
        FileOpen(f1, Application.StartupPath & "\data\accounts\chartemp.txt", OpenMode.Input, OpenAccess.ReadWrite, OpenShare.Default)
        f2 = FreeFile()
        FileOpen(f2, Application.StartupPath & "\data\accounts\charlist.txt", OpenMode.Output, OpenAccess.ReadWrite, OpenShare.Default)

        Do While Not EOF(f1)
            FileGetObject(f1, s)

            If Trim$(LCase$(s)) <> Trim$(LCase$(Name)) Then
                FilePutObject(f2, s)
            End If

        Loop

        FileClose(f1)
        FileClose(f2)
        Call Kill(Application.StartupPath & "\data\accounts\chartemp.txt")
    End Sub




    ' *************
    ' ** Players **
    ' *************
    Sub SaveAllPlayersOnline()
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                Call SavePlayer(i)
                Call SaveBank(i)
            End If

        Next

    End Sub
    Sub SavePlayer(ByVal Index As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Player(Index).Login)
        FilePutObject(F, Player(Index).Password)
        FilePutObject(F, Player(Index).Access)
        FilePutObject(F, Player(Index).Classes)
        FilePutObject(F, Player(Index).Dir)
        FilePutObject(F, Player(Index).Equipment(Equipment.Armor))
        FilePutObject(F, Player(Index).Equipment(Equipment.Helmet))
        FilePutObject(F, Player(Index).Equipment(Equipment.Shield))
        FilePutObject(F, Player(Index).Equipment(Equipment.Weapon))
        FilePutObject(F, Player(Index).exp)
        For i = 0 To MAX_INV
            FilePutObject(F, Player(Index).Inv(i).Num)
            FilePutObject(F, Player(Index).Inv(i).Value)
        Next
        FilePutObject(F, Player(Index).Level)
        FilePutObject(F, Player(Index).Map)
        FilePutObject(F, Player(Index).Name)
        FilePutObject(F, Player(Index).PK)
        FilePutObject(F, Player(Index).POINTS)
        FilePutObject(F, Player(Index).Sex)
        For i = 0 To MAX_PLAYER_SPELLS
            FilePutObject(F, Player(Index).Spell(i))
        Next
        FilePutObject(F, Player(Index).Sprite)
        For i = 0 To Stats.Stat_Count - 1
            FilePutObject(F, Player(Index).Stat(i))
        Next
        For i = 0 To Vitals.Vital_Count - 1
            FilePutObject(F, Player(Index).Vital(i))
        Next
        FilePutObject(F, Player(Index).x)
        FilePutObject(F, Player(Index).y)
        FileClose(F)
    End Sub
    Sub LoadPlayer(ByVal Index As Long, ByVal Name As String)
        Dim filename As String
        Dim F As Long
        Call ClearPlayer(Index)
        filename = Application.StartupPath & "\data\accounts\" & Trim(Name) & ".bin"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        FileGetObject(F, Player(Index).Login)
        FileGetObject(F, Player(Index).Password)
        FileGetObject(F, Player(Index).Access)
        FileGetObject(F, Player(Index).Classes)
        FileGetObject(F, Player(Index).Dir)
        FileGetObject(F, Player(Index).Equipment(Equipment.Armor))
        FileGetObject(F, Player(Index).Equipment(Equipment.Helmet))
        FileGetObject(F, Player(Index).Equipment(Equipment.Shield))
        FileGetObject(F, Player(Index).Equipment(Equipment.Weapon))
        FileGetObject(F, Player(Index).exp)
        For i = 0 To MAX_INV
            FileGetObject(F, Player(Index).Inv(i).Num)
            FileGetObject(F, Player(Index).Inv(i).Value)
        Next
        FileGetObject(F, Player(Index).Level)
        FileGetObject(F, Player(Index).Map)
        FileGetObject(F, Player(Index).Name)
        FileGetObject(F, Player(Index).PK)
        FileGetObject(F, Player(Index).POINTS)
        FileGetObject(F, Player(Index).Sex)
        For i = 0 To MAX_PLAYER_SPELLS
            FileGetObject(F, Player(Index).Spell(i))
        Next
        FileGetObject(F, Player(Index).Sprite)
        For i = 0 To Stats.Stat_Count - 1
            FileGetObject(F, Player(Index).Stat(i))
        Next
        For i = 0 To Vitals.Vital_Count - 1
            FileGetObject(F, Player(Index).Vital(i))
        Next
        FileGetObject(F, Player(Index).x)
        FileGetObject(F, Player(Index).y)
        FileClose(F)
    End Sub
    Sub ClearPlayer(ByVal Index As Long)
        Dim i As Integer
        TempPlayer(Index).Buffer = New ByteBuffer

        Player(Index).Login = ""
        Player(Index).Password = ""

        Player(Index).Access = 0
        Player(Index).Classes = 0
        Player(Index).Dir = 0

        For i = 0 To Equipment.Equipment_Count - 1
            Player(Index).Equipment(i) = 0
        Next

        For i = 0 To MAX_INV
            Player(Index).Inv(i).Num = 0
            Player(Index).Inv(i).Value = 0
        Next

        Player(Index).exp = 0
        Player(Index).Level = 0
        Player(Index).Map = 0
        Player(Index).Name = ""
        Player(Index).PK = 0
        Player(Index).POINTS = 0
        Player(Index).Sex = 0

        For i = 0 To MAX_PLAYER_SPELLS
            Player(Index).Spell(i) = 0
        Next

        Player(Index).Sprite = 0

        For i = 0 To Stats.Stat_Count - 1
            Player(Index).Stat(i) = 0
        Next

        For i = 0 To Vitals.Vital_Count - 1
            Player(Index).Vital(i) = 0
        Next

        Player(Index).x = 0
        Player(Index).y = 0

        i = CInt(Index - 1)
        'frmServer.lstView.Items(i).SubItems(1).Text = ""
        'frmServer.lstView.Items(i).SubItems(2).Text = ""
        'frmServer.lstView.Items(i).SubItems(3).Text = ""
    End Sub




    ' ******************
    ' ** Players Bank **
    ' ******************
    Public Sub LoadBank(ByVal Index As Long, ByVal Name As String)
        Dim filename As String
        Dim F As Long

        Call ClearBank(Index)

        filename = Application.StartupPath & "\data\banks\" & Trim$(Name) & ".bin"

        If Not FileExist(filename) Then
            Call SaveBank(Index)
            Exit Sub
        End If

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        For i = 0 To MAX_BANK
            FileGetObject(F, Bank(Index).Item(i).Num)
            FileGetObject(F, Bank(Index).Item(i).Value)
        Next
        FileClose(F)
    End Sub
    Sub SaveBank(ByVal Index As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\banks\" & Trim$(Player(Index).Login) & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        For i = 0 To MAX_BANK
            FilePutObject(F, Bank(Index).Item(i).Num)
            FilePutObject(F, Bank(Index).Item(i).Value)
        Next
        FileClose(F)
    End Sub
    Sub ClearBank(ByVal Index As Long)
        For i = 0 To MAX_BANK
            Bank(Index).Item(i).Num = 0
            Bank(Index).Item(i).Value = 0
        Next
    End Sub





    ' ****************
    ' ** Characters **
    ' ****************
    Function CharExist(ByVal Index As Long) As Boolean

        If Len(Trim$(Player(Index).Name)) > 0 Then
            CharExist = True
        Else
            CharExist = False
        End If

    End Function
    Sub AddChar(ByVal Index As Long, ByVal Name As String, ByVal Sex As Byte, ByVal ClassNum As Byte, ByVal Sprite As Long)
        Dim n As Long
        Dim spritecheck As Boolean

        If Len(Trim$(Player(Index).Name)) = 0 Then

            spritecheck = False

            Player(Index).Name = Name
            Player(Index).Sex = Sex
            Player(Index).Classes = ClassNum

            If Player(Index).Sex = SEX_MALE Then
                Player(Index).Sprite = Classes(ClassNum).MaleSprite(Sprite - 1)
            Else
                Player(Index).Sprite = Classes(ClassNum).FemaleSprite(Sprite - 1)
            End If

            Player(Index).Level = 1

            For n = 1 To Stats.Stat_Count - 1
                Player(Index).Stat(n) = Classes(ClassNum).Stat(n)
            Next n

            Player(Index).Dir = DIR_DOWN
            Player(Index).Map = START_MAP
            Player(Index).x = START_X
            Player(Index).y = START_Y
            Player(Index).Dir = DIR_DOWN
            Player(Index).Vital(Vitals.HP) = GetPlayerMaxVital(Index, Vitals.HP)
            Player(Index).Vital(Vitals.MP) = GetPlayerMaxVital(Index, Vitals.MP)
            Player(Index).Vital(Vitals.SP) = GetPlayerMaxVital(Index, Vitals.SP)

            ' set starter equipment
            For n = 1 To 5
                If Classes(ClassNum).StartItem(n) > 0 Then
                    Player(Index).Inv(n).Num = Classes(ClassNum).StartItem(n)
                    Player(Index).Inv(n).Value = Classes(ClassNum).StartValue(n)
                End If
            Next

            ' Append name to file
            AddTextToFile(Name, "accounts\charlist.txt")
            Call SavePlayer(Index)
            Exit Sub
        End If

    End Sub
    Function FindChar(ByVal Name As String) As Boolean
        FindChar = False
        Dim characters() As String
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False
        fullpath = Application.StartupPath & "\data\accounts\charlist.txt"
        Contents = GetFileContents(fullpath)
        characters = Split(Contents, vbNewLine)
        For i = 0 To UBound(characters)
            If Trim$(LCase(characters(i)) = Trim$(LCase(Name))) Then
                FindChar = True
            End If
        Next
        Return FindChar
    End Function





    ' *****************
    ' ** INI Reading **
    ' *****************
    Public Sub SaveOptions()
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Game_Name", Options.Game_Name)
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Port", Str(Options.Port))
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "MOTD", Options.MOTD)
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Website", Options.Website)
    End Sub
    Public Sub LoadOptions()
        Options.Game_Name = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Game_Name")
        Options.Port = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Port")
        Options.MOTD = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "MOTD")
        Options.Website = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Website")
    End Sub



    ' *****************
    ' **     Logs    **
    ' *****************

    Public Function GetFileContents(ByVal FullPath As String, _
               Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader
        strContents = ""
        If Not File.Exists(FullPath) Then
            Dim fs As FileStream = File.Create(FullPath)
            fs.Close()
            fs.Dispose()
        End If
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return strContents
    End Function
    Public Function Addlog(ByVal strData As String, _
     ByVal FN As String, _
       Optional ByVal ErrInfo As String = "") As Boolean
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        fullpath = Application.StartupPath & "\data\logs\" & FN
        Contents = GetFileContents(fullpath)
        Contents = Contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(Contents)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function
    Public Function AddTextToFile(ByVal strData As String, ByVal FN As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        fullpath = Application.StartupPath & "\data\" & FN
        Contents = GetFileContents(fullpath)
        Contents = Contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(Contents)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function
    Public Function Addlog1(ByVal strData As String, _
 ByVal FN As String, _
   Optional ByVal ErrInfo As String = "") As Boolean
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        fullpath = Application.StartupPath & "\data\logs\" & FN
        Contents = GetFileContents(fullpath)
        Contents = Contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(Contents)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function
    Public Function Compress(ByVal b() As Byte) As Byte()
        Dim ms As New System.IO.MemoryStream()
        Dim gzipstream As New Compression.GZipStream(ms, CompressionMode.Compress)
        gzipstream.Write(b, 0, b.Length)
        gzipstream.Flush()
        gzipstream.Close()
        Dim ret() As Byte = ms.ToArray()
        gzipstream.Close()
        gzipstream.Dispose()
        ms.Close()
        ms.Dispose()
        Return ret
    End Function
    Public Function Decompress(ByVal bytes() As Byte) As Byte()
        Dim ms As New MemoryStream(bytes)
        Dim gz As New GZipStream(ms, CompressionMode.Decompress)
        Dim bt(3) As Byte
        ms.Position = ms.Length - 4
        ms.Read(bt, 0, 4)
        ms.Position = 0
        Dim size As Integer = BitConverter.ToInt32(bt, 0)
        Dim buffer(size + 100) As Byte
        Dim offset As Integer = 0
        Dim total As Integer = 0
        While (True)
            Dim j As Integer = gz.Read(buffer, offset, 100)
            If j = 0 Then Exit While
            offset += j
            total += j
        End While
        gz.Close()
        gz.Dispose()
        ms.Close()
        ms.Dispose()
        Dim ra(total - 1) As Byte
        Array.ConstrainedCopy(buffer, 0, ra, 0, total)
        Return ra
    End Function
    Sub ServerBanIndex(ByVal BanPlayerIndex As Long)
        Dim filename As String
        Dim IP As String
        Dim F As Long
        Dim i As Long
        filename = Application.StartupPath & "data\banlist.txt"

        ' Make sure the file exists
        If Not FileExist("data\banlist.txt") Then
            F = FreeFile
            'COME HERE!!!
        End If

        ' Cut off last portion of ip
        IP = GetPlayerIP(BanPlayerIndex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP & "," & "Server", "banlist.txt")
        Call GlobalMsg(GetPlayerName(BanPlayerIndex) & " has been banned from " & Options.Game_Name & " by " & "the Server" & "!")
        Call AddLog("The Server" & " has banned " & GetPlayerName(BanPlayerIndex) & ".", ADMIN_LOG)
        Call AlertMsg(BanPlayerIndex, "You have been banned by " & "The Server" & "!")
    End Sub
    Sub BanIndex(ByVal BanPlayerIndex As Long, ByVal BannedByIndex As Long)
        Dim filename As String
        Dim IP As String
        Dim F As Long
        Dim i As Long
        filename = Application.StartupPath & "\data\banlist.txt"

        ' Make sure the file exists
        If Not FileExist("data\banlist.txt") Then
            F = FreeFile
        End If

        ' Cut off last portion of ip
        IP = GetPlayerIP(BanPlayerIndex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP & "," & GetPlayerName(BannedByIndex), "banlist.txt")
        Call GlobalMsg(GetPlayerName(BanPlayerIndex) & " has been banned from " & Options.Game_Name & " by " & GetPlayerName(BannedByIndex) & "!")
        Call AddLog(GetPlayerName(BannedByIndex) & " has banned " & GetPlayerName(BanPlayerIndex) & ".", ADMIN_LOG)
        Call AlertMsg(BanPlayerIndex, "You have been banned by " & GetPlayerName(BannedByIndex) & "!")
    End Sub

    Function ClassData() As Byte()
        Dim i As Long, n As Long, q As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(GetClassName(i))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)

            ' send array size
            Buffer.WriteLong(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)

            ' send array size
            Buffer.WriteLong(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteLong(Classes(i).Stat(Stats.strength))
            Buffer.WriteLong(Classes(i).Stat(Stats.endurance))
            Buffer.WriteLong(Classes(i).Stat(Stats.vitality))
            Buffer.WriteLong(Classes(i).Stat(Stats.intelligence))
            Buffer.WriteLong(Classes(i).Stat(Stats.willpower))
            Buffer.WriteLong(Classes(i).Stat(Stats.spirit))
        Next

        Return Buffer.ToArray()
        Buffer = Nothing
    End Function

    Function ItemsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long
        buffer = New ByteBuffer

        For i = 1 To MAX_ITEMS

            If Len(Trim$(Item(i).Name)) > 0 Then
                buffer.WriteBytes(ItemData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing

    End Function
    Function ItemData(ByVal itemNum As Long) As Byte()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(itemNum)
        Buffer.WriteLong(Item(itemNum).AccessReq)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteLong(Item(itemNum).Animation)
        Buffer.WriteLong(Item(itemNum).BindType)
        Buffer.WriteLong(Item(itemNum).ClassReq)
        Buffer.WriteLong(Item(itemNum).Data1)
        Buffer.WriteLong(Item(itemNum).Data2)
        Buffer.WriteLong(Item(itemNum).Data3)
        Buffer.WriteLong(Item(itemNum).Handed)
        Buffer.WriteLong(Item(itemNum).LevelReq)
        Buffer.WriteLong(Item(itemNum).Mastery)
        Buffer.WriteString(Item(itemNum).Name)
        Buffer.WriteLong(Item(itemNum).Paperdoll)
        Buffer.WriteLong(Item(itemNum).Pic)
        Buffer.WriteLong(Item(itemNum).price)
        Buffer.WriteLong(Item(itemNum).Rarity)
        Buffer.WriteLong(Item(itemNum).Speed)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteLong(Item(itemNum).Type)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function
    Function AnimationsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long
        buffer = New ByteBuffer

        For i = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(i).Name)) > 0 Then
                buffer.WriteBytes(AnimationData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function
    Function AnimationData(ByVal AnimationNum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteLong(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteLong(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteLong(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteLong(Animation(AnimationNum).Sprite(i))
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function
    Function NpcsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long
        buffer = New ByteBuffer

        For i = 1 To MAX_NPCS

            If Len(Trim$(Npc(i).Name)) > 0 Then
                buffer.WriteBytes(NpcData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function
    Function NpcData(ByVal NpcNum As Long) As Byte()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(NpcNum)
        Buffer.WriteLong(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteLong(Npc(NpcNum).Behaviour)
        Buffer.WriteLong(Npc(NpcNum).DropChance)
        Buffer.WriteLong(Npc(NpcNum).DropItem)
        Buffer.WriteLong(Npc(NpcNum).DropItemValue)
        Buffer.WriteLong(Npc(NpcNum).exp)
        Buffer.WriteLong(Npc(NpcNum).faction)
        Buffer.WriteLong(Npc(NpcNum).HP)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteLong(Npc(NpcNum).range)
        Buffer.WriteLong(Npc(NpcNum).SpawnSecs)
        Buffer.WriteLong(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Npc(NpcNum).Stat(i))
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function
    Function ShopsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long

        buffer = New ByteBuffer

        For i = 1 To MAX_SHOPS

            If Len(Trim$(Shop(i).Name)) > 0 Then
                buffer.WriteBytes(ShopData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function
    Function ShopData(ByVal shopNum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(shopNum)
        Buffer.WriteLong(Shop(shopNum).BuyRate)
        Buffer.WriteString(Shop(shopNum).Name)

        For i = 0 To MAX_TRADES
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costitem)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costvalue)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function
    Function SpellsData() As Byte()
        Dim i As Long
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        For i = 1 To MAX_SPELLS

            If Len(Trim$(Spell(i).Name)) > 0 Then
                buffer.WriteBytes(SpellData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function
    Function SpellData(ByVal spellnum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(spellnum)
        Buffer.WriteLong(Spell(spellnum).AccessReq)
        Buffer.WriteLong(Spell(spellnum).AoE)
        Buffer.WriteLong(Spell(spellnum).CastAnim)
        Buffer.WriteLong(Spell(spellnum).CastTime)
        Buffer.WriteLong(Spell(spellnum).CDTime)
        Buffer.WriteLong(Spell(spellnum).ClassReq)
        Buffer.WriteLong(Spell(spellnum).Dir)
        Buffer.WriteLong(Spell(spellnum).Duration)
        Buffer.WriteLong(Spell(spellnum).Icon)
        Buffer.WriteLong(Spell(spellnum).Interval)
        Buffer.WriteLong(Spell(spellnum).IsAoE)
        Buffer.WriteLong(Spell(spellnum).LevelReq)
        Buffer.WriteLong(Spell(spellnum).Map)
        Buffer.WriteLong(Spell(spellnum).MPCost)
        Buffer.WriteString(Spell(spellnum).Name)
        Buffer.WriteLong(Spell(spellnum).range)
        Buffer.WriteLong(Spell(spellnum).SpellAnim)
        Buffer.WriteLong(Spell(spellnum).StunDuration)
        Buffer.WriteLong(Spell(spellnum).Type)
        Buffer.WriteLong(Spell(spellnum).Vital)
        Buffer.WriteLong(Spell(spellnum).x)
        Buffer.WriteLong(Spell(spellnum).y)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function
    Function ResourcesData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long

        buffer = New ByteBuffer

        For i = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(i).Name)) > 0 Then
                buffer.WriteBytes(ResourceData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function
    Function ResourceData(ByVal ResourceNum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ResourceNum)
        Buffer.WriteLong(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteLong(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteLong(Resource(ResourceNum).health)
        Buffer.WriteLong(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteLong(Resource(ResourceNum).ResourceImage)
        Buffer.WriteLong(Resource(ResourceNum).ResourceType)
        Buffer.WriteLong(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteLong(Resource(ResourceNum).ToolRequired)
        Buffer.WriteLong(Resource(ResourceNum).Walkthrough)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function
End Module
