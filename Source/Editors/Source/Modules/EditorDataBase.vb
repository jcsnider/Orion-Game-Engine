Imports System.IO

Module ClientDataBase
    Public GameRand As New Random()

    Sub ClearTempTile()
        Dim X As Integer
        Dim Y As Integer
        ReDim TempTile(0 To Map.MaxX, 0 To Map.MaxY)

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                TempTile(X, Y).DoorOpen = 0
            Next
        Next

    End Sub

    Public Function IsInBounds()
        IsInBounds = False
        If (CurX >= 0) Then
            If (CurX <= Map.MaxX) Then
                If (CurY >= 0) Then
                    If (CurY <= Map.MaxY) Then
                        IsInBounds = True
                    End If
                End If
            End If
        End If

    End Function

    Public Sub DoEvents()
        Application.DoEvents()
    End Sub

    Public Function GetTickCount()
        Return Environment.TickCount
    End Function

    Public Function FileExist(ByVal file_path) As Boolean
        FileExist = IO.File.Exists(file_path)
    End Function

    Public Function Rand(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer
        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return GameRand.Next(MinNumber, MaxNumber)
    End Function

    Public Sub CheckTilesets()
        Dim i As Integer
        Dim tmp As Bitmap
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "\tilesets\" & i & GFX_EXT)
            NumTileSets = NumTileSets + 1
            i = i + 1
        End While

        ReDim TilesetsClr(0 To NumTileSets)

        For i = 1 To NumTileSets
            tmp = New Bitmap(Application.StartupPath & GFX_PATH & "\tilesets\" & i & GFX_EXT)
            TilesetsClr(NumTileSets) = tmp.GetPixel(0, 0)
        Next
        If NumTileSets = 0 Then Exit Sub

    End Sub

    Public Sub CheckCharacters()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "characters\" & i & GFX_EXT)
            NumCharacters = NumCharacters + 1
            i = i + 1
        End While

        If NumCharacters = 0 Then Exit Sub
    End Sub

    Public Sub CheckPaperdolls()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "paperdolls\" & i & GFX_EXT)
            NumPaperdolls = NumPaperdolls + 1
            i = i + 1
        End While

        If NumPaperdolls = 0 Then Exit Sub
    End Sub

    Public Sub CheckAnimations()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "animations\" & i & GFX_EXT)
            NumAnimations = NumAnimations + 1
            i = i + 1
        End While

        If NumAnimations = 0 Then Exit Sub
    End Sub

    Public Sub CheckItems()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Items\" & i & GFX_EXT)
            NumItems = NumItems + 1
            i = i + 1
        End While

        If NumItems = 0 Then Exit Sub
    End Sub

    Public Sub CheckResources()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Resources\" & i & GFX_EXT)
            NumResources = NumResources + 1
            i = i + 1
        End While

        If NumResources = 0 Then Exit Sub
    End Sub

    Public Sub CheckSkillIcons()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "SkillIcons\" & i & GFX_EXT)
            NumSkillIcons = NumSkillIcons + 1
            i = i + 1
        End While

        If NumSkillIcons = 0 Then Exit Sub
    End Sub

    Public Sub CheckFaces()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Faces\" & i & GFX_EXT)
            NumFaces = NumFaces + 1
            i = i + 1
        End While

        If NumFaces = 0 Then Exit Sub
    End Sub

    Public Sub CheckFog()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Fogs\" & i & GFX_EXT)
            NumFogs = NumFogs + 1
            i = i + 1
        End While

        If NumFogs = 0 Then Exit Sub
    End Sub

    Public Sub CacheMusic()
        Dim Files As String() = Directory.GetFiles(Application.StartupPath & MUSIC_PATH, "*.ogg")
        Dim MaxNum As String = Directory.GetFiles(Application.StartupPath & MUSIC_PATH, "*.ogg").Count
        Dim Counter As Integer = 1

        For Each FileName In Files
            ReDim Preserve MusicCache(Counter)

            MusicCache(Counter) = Path.GetFileName(FileName)
            Counter = Counter + 1
            Application.DoEvents()
        Next

    End Sub

    Public Sub CacheSound()
        Dim Files As String() = Directory.GetFiles(Application.StartupPath & SOUND_PATH, "*.ogg")
        Dim MaxNum As String = Directory.GetFiles(Application.StartupPath & SOUND_PATH, "*.ogg").Count
        Dim Counter As Integer = 1

        For Each FileName In Files
            ReDim Preserve SoundCache(Counter)

            SoundCache(Counter) = Path.GetFileName(FileName)
            Counter = Counter + 1
            Application.DoEvents()
        Next

    End Sub

    Public Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader
        strContents = ""
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return strContents
    End Function

    Sub ClearMap()
        SyncLock MapLock
            Map.MapNum = 0
            Map.Name = ""
            Map.tileset = 1
            Map.MaxX = SCREEN_MAPX
            Map.MaxY = SCREEN_MAPY
            Map.BootMap = 0
            Map.BootX = 0
            Map.BootY = 0
            Map.Down = 0
            Map.Left = 0
            Map.Moral = 0
            Map.Music = ""
            Map.Revision = 0
            Map.Right = 0
            Map.Up = 0

            ReDim Map.Npc(0 To MAX_MAP_NPCS)
            ReDim Map.Tile(0 To Map.MaxX, 0 To Map.MaxY)

            For x = 0 To SCREEN_MAPX
                For y = 0 To SCREEN_MAPY
                    ReDim Map.Tile(x, y).Layer(0 To MapLayer.Count - 1)
                    For l = 0 To MapLayer.Count - 1
                        Map.Tile(x, y).Layer(l).Tileset = 0
                        Map.Tile(x, y).Layer(l).X = 0
                        Map.Tile(x, y).Layer(l).Y = 0
                        Map.Tile(x, y).Layer(l).AutoTile = 0
                    Next

                Next
            Next

        End SyncLock

    End Sub

    Sub ClearMapItems()
        Dim i As Integer

        For i = 1 To MAX_MAP_ITEMS
            ClearMapItem(i)
        Next

    End Sub

    Sub ClearMapItem(ByVal Index As Integer)
        MapItem(Index).Frame = 0
        MapItem(Index).Num = 0
        MapItem(Index).Value = 0
        MapItem(Index).X = 0
        MapItem(Index).Y = 0
    End Sub

    Sub ClearMapNpc(ByVal Index As Integer)
        MapNpc(Index).Attacking = 0
        MapNpc(Index).AttackTimer = 0
        MapNpc(Index).Dir = 0
        MapNpc(Index).Map = 0
        MapNpc(Index).Moving = 0
        MapNpc(Index).Num = 0
        MapNpc(Index).Steps = 0
        MapNpc(Index).Target = 0
        MapNpc(Index).TargetType = 0
        MapNpc(Index).Vital(Vitals.HP) = 0
        MapNpc(Index).Vital(Vitals.MP) = 0
        MapNpc(Index).Vital(Vitals.SP) = 0
        MapNpc(Index).X = 0
        MapNpc(Index).XOffset = 0
        MapNpc(Index).Y = 0
        MapNpc(Index).YOffset = 0
    End Sub

    Sub ClearMapNpcs()
        Dim i As Integer

        For i = 1 To MAX_MAP_NPCS
            ClearMapNpc(i)
        Next

    End Sub

    Public Sub ClearItem(ByVal Index As Integer)
        Index = Index - 1
        Item(Index) = Nothing
        Item(Index) = New ItemRec
        For x = 0 To Stats.Count - 1
            ReDim Item(Index).Add_Stat(x)
        Next
        For x = 0 To Stats.Count - 1
            ReDim Item(Index).Stat_Req(x)
        Next

        ReDim Item(Index).FurnitureBlocks(0 To 3, 0 To 3)
        ReDim Item(Index).FurnitureFringe(0 To 3, 0 To 3)

        Item(Index).Name = ""
    End Sub

    Public Sub ClearChanged_Item()
        For i = 1 To MAX_ITEMS
            Item_Changed(i) = Nothing
        Next i
        ReDim Item_Changed(0 To MAX_ITEMS)
    End Sub

    Sub ClearItems()
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next

    End Sub

    Public Sub ClearChanged_Resource()
        For i = 1 To MAX_RESOURCES
            Resource_Changed(i) = Nothing
        Next i
        ReDim Resource_Changed(0 To MAX_RESOURCES)
    End Sub

    Sub ClearResource(ByVal Index As Integer)
        Resource(Index) = Nothing
        Resource(Index) = New ResourceRec
        Resource(Index).Name = ""
    End Sub

    Sub ClearResources()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES
            ClearResource(i)
        Next

    End Sub

    Sub ClearNpcs()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            ClearNpc(i)
        Next

    End Sub

    Sub ClearNpc(ByVal Index As Integer)
        Npc(Index) = Nothing
        Npc(Index).Name = ""
        Npc(Index).AttackSay = ""
        ReDim Npc(Index).Stat(0 To Stats.Count - 1)
        ReDim Npc(Index).Skill(0 To MAX_NPC_SKILLS)
    End Sub

    Sub ClearAnimation(ByVal Index As Integer)
        Animation(Index) = Nothing
        Animation(Index) = New AnimationRec
        For x = 0 To 1
            ReDim Animation(Index).Sprite(x)
        Next
        For x = 0 To 1
            ReDim Animation(Index).Frames(x)
        Next
        For x = 0 To 1
            ReDim Animation(Index).LoopCount(x)
        Next
        For x = 0 To 1
            ReDim Animation(Index).looptime(x)
        Next
        Animation(Index).Name = ""
    End Sub

    Sub ClearAnimations()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS
            ClearAnimation(i)
        Next

    End Sub

    Sub ClearSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            ClearSkill(i)
        Next

    End Sub

    Sub ClearSkill(ByVal Index As Integer)
        Skill(Index) = Nothing
        Skill(Index) = New SkillRec
        Skill(Index).Name = ""
    End Sub

    Sub ClearShop(ByVal Index As Integer)
        Shop(Index) = Nothing
        Shop(Index) = New ShopRec
        Shop(Index).Name = ""
        ReDim Shop(Index).TradeItem(MAX_TRADES)
    End Sub

    Sub ClearShops()
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            ClearShop(i)
        Next

    End Sub

End Module
