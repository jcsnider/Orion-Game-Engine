Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq

Module ClientDataBase
    Public Sub CheckTilesets()
        Dim i As Long
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
        frmEditor_Map.scrlTileSet.Minimum = 1
    End Sub

    Public Sub CheckCharacters()
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "characters\" & i & GFX_EXT)
            NumCharacters = NumCharacters + 1
            i = i + 1
        End While

        If NumCharacters = 0 Then Exit Sub
    End Sub

    Public Sub CheckPaperdolls()
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "paperdolls\" & i & GFX_EXT)
            NumPaperdolls = NumPaperdolls + 1
            i = i + 1
        End While

        If NumPaperdolls = 0 Then Exit Sub
    End Sub

    Public Sub CheckAnimations()
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "animations\" & i & GFX_EXT)
            NumAnimations = NumAnimations + 1
            i = i + 1
        End While

        If NumAnimations = 0 Then Exit Sub
    End Sub

    Public Sub CheckItems()
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Items\" & i & GFX_EXT)
            NumItems = NumItems + 1
            i = i + 1
        End While

        If NumItems = 0 Then Exit Sub
    End Sub

    Public Sub CheckResources()
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Resources\" & i & GFX_EXT)
            NumResources = NumResources + 1
            i = i + 1
        End While

        If NumResources = 0 Then Exit Sub
    End Sub

    Public Sub CheckSpellIcons()
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "SpellIcons\" & i & GFX_EXT)
            NumSpellIcons = NumSpellIcons + 1
            i = i + 1
        End While

        If NumSpellIcons = 0 Then Exit Sub
    End Sub

    Public Sub CacheMusic()
        Dim Files As String() = Directory.GetFiles(Application.StartupPath & MUSIC_PATH, "*.ogg")
        Dim MaxNum As String = Directory.GetFiles(Application.StartupPath & MUSIC_PATH, "*.ogg").Count
        Dim Counter As Long = 1

        For Each FileName In Files
            ReDim Preserve MusicCache(Counter)

            MusicCache(Counter) = FileName
            Counter = Counter + 1
            Application.DoEvents()
        Next

    End Sub

    Public Sub CacheSound()
        Dim Files As String() = Directory.GetFiles(Application.StartupPath & SOUND_PATH, "*.ogg")
        Dim MaxNum As String = Directory.GetFiles(Application.StartupPath & SOUND_PATH, "*.ogg").Count
        Dim Counter As Long = 1

        For Each FileName In Files
            ReDim Preserve SoundCache(Counter)

            SoundCache(Counter) = FileName
            Counter = Counter + 1
            Application.DoEvents()
        Next

    End Sub

    Public Sub SaveOptions()
        Dim FileName As String

        FileName = Application.StartupPath & "\Data Files\config.ini"

        Call PutVar(FileName, "Options", "Username", Trim$(Options.Username))
        Call PutVar(FileName, "Options", "Password", Trim$(Options.Password))
        Call PutVar(FileName, "Options", "SavePass", Str(Options.SavePass))
        Call PutVar(FileName, "Options", "IP", Options.IP)
        Call PutVar(FileName, "Options", "Port", Str(Options.Port))
        Call PutVar(FileName, "Options", "MenuMusic", Trim$(Options.MenuMusic))
        Call PutVar(FileName, "Options", "Music", Str(Options.Music))
        Call PutVar(FileName, "Options", "Sound", Str(Options.Sound))
    End Sub

    Public Sub LoadOptions()
        Dim FileName As String

        FileName = Application.StartupPath & "\Data Files\config.ini"

        If Not FileExist(FileName) Then
            Options.Password = vbNullString
            Options.SavePass = 0
            Options.Username = vbNullString
            Options.IP = "127.0.0.1"
            Options.Port = 7001
            Options.MenuMusic = vbNullString
            Options.Music = 1
            Options.Sound = 1
            Options.Volume = 100
            SaveOptions()
        Else
            Options.Username = Getvar(FileName, "Options", "Username")
            Options.Password = Getvar(FileName, "Options", "Password")
            Options.SavePass = Getvar(FileName, "Options", "SavePass")
            Options.IP = Getvar(FileName, "Options", "IP")
            Options.Port = Val(Getvar(FileName, "Options", "Port"))
            Options.MenuMusic = Getvar(FileName, "Options", "MenuMusic")
            Options.Music = Getvar(FileName, "Options", "Music")
            Options.Sound = Getvar(FileName, "Options", "Sound")
            Options.Volume = Getvar(FileName, "Options", "Volume")
        End If

        ' show in GUI
        If Options.Music = 0 Then
            frmMainGame.optMOff.Checked = True
        Else
            frmMainGame.optMOn.Checked = True
        End If

        If Options.Sound = 0 Then
            frmMainGame.optSOff.Checked = True
        Else
            frmMainGame.optSOn.Checked = True
        End If
        frmMainGame.lblVolume.Text = "Volume: " & Options.Volume
        frmMainGame.scrlVolume.Value = Options.Volume
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

    Sub SetPlayerEquipment(ByVal Index As Long, ByVal InvNum As Long, ByVal EquipmentSlot As Equipment)

        If Index < 1 Or Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Equipment(EquipmentSlot) = InvNum
    End Sub

    Sub ClearPlayer(ByVal Index As Long)
        Player(Index).Name = vbNullString
        Player(Index).Access = 0
        Player(Index).Attacking = 0
        Player(Index).AttackTimer = 0
        Player(Index).Classes = 0
        Player(Index).Dir = 0
        Player(Index).Equipment(Equipment.Armor) = 0
        Player(Index).Equipment(Equipment.Helmet) = 0
        Player(Index).Equipment(Equipment.Shield) = 0
        Player(Index).Equipment(Equipment.Weapon) = 0
        Player(Index).EXP = 0
        Player(Index).Level = 0
        Player(Index).Map = 0
        Player(Index).MapGetTimer = 0
        Player(Index).MaxHP = 0
        Player(Index).MaxMP = 0
        Player(Index).MaxSP = 0
        Player(Index).Moving = 0
        Player(Index).PK = 0
        Player(Index).POINTS = 0
        Player(Index).Sprite = 0
        Player(Index).Stat(Stats.endurance) = 0
        Player(Index).Stat(Stats.intelligence) = 0
        Player(Index).Stat(Stats.spirit) = 0
        Player(Index).Stat(Stats.strength) = 0
        Player(Index).Stat(Stats.vitality) = 0
        Player(Index).Stat(Stats.willpower) = 0
        Player(Index).Steps = 0
        Player(Index).Vital(Vitals.HP) = 0
        Player(Index).Vital(Vitals.MP) = 0
        Player(Index).Vital(Vitals.SP) = 0
        Player(Index).X = 0
        Player(Index).XOffset = 0
        Player(Index).Y = 0
        Player(Index).YOffset = 0
    End Sub

    Sub ClearMap()
        SyncLock MapLock
            Map.Name = vbNullString
            Map.tileset = 1
            Map.MaxX = MAX_MAPX
            Map.MaxY = MAX_MAPY
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
            'ReDim Map.exTile(0 To Map.MaxX, 0 To Map.MaxY)
            For x = 0 To MAX_MAPX
                For y = 0 To MAX_MAPY
                    ReDim Map.Tile(x, y).Layer(0 To MapLayer.Layer_Count - 1)
                    ReDim Map.Tile(x, y).Autotile(0 To MapLayer.Layer_Count - 1)
                    For l = 0 To MapLayer.Layer_Count - 1
                        Map.Tile(x, y).Layer(l).tileset = 0
                        Map.Tile(x, y).Layer(l).X = 0
                        Map.Tile(x, y).Layer(l).Y = 0
                        Map.Tile(x, y).Autotile(l) = 0
                    Next

                    'ReDim Map.exTile(x, y).Layer(0 To ExMapLayer.Layer_Count - 1)
                    'ReDim Map.exTile(x, y).Autotile(0 To ExMapLayer.Layer_Count - 1)
                    'For l = 0 To ExMapLayer.Layer_Count - 1
                    '    Map.exTile(x, y).Layer(l).tileset = 0
                    '    Map.exTile(x, y).Layer(l).X = 0
                    '    Map.exTile(x, y).Layer(l).Y = 0
                    '    Map.exTile(x, y).Autotile(l) = 0
                    'Next

                Next
            Next

        End SyncLock
    End Sub

    Sub ClearMapItems()
        Dim i As Long

        For i = 1 To MAX_MAP_ITEMS
            ClearMapItem(i)
        Next

    End Sub

    Sub ClearMapItem(ByVal Index As Long)
        MapItem(Index).Frame = 0
        MapItem(Index).Num = 0
        MapItem(Index).Value = 0
        MapItem(Index).X = 0
        MapItem(Index).Y = 0
    End Sub

    Sub ClearMapNpc(ByVal Index As Long)
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

    Sub SetPlayerMap(ByVal Index As Long, ByVal MapNum As Long)
        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Map = MapNum
    End Sub

    Sub ClearMapNpcs()
        Dim i As Long

        For i = 1 To MAX_MAP_NPCS
            Call ClearMapNpc(i)
        Next

    End Sub

    Public Sub SaveMap(ByVal MapNum As Long)
        Dim FileName As String
        Dim f As Long
        Dim X As Long
        Dim Y As Long
        FileName = Application.StartupPath & MAP_PATH & "map" & MapNum & MAP_EXT

        f = FreeFile()
        FileOpen(f, FileName, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(f, Map.Name)
        FilePutObject(f, Map.Music)
        FilePutObject(f, Map.Revision)
        FilePutObject(f, Map.Moral)
        FilePutObject(f, Map.tileset)
        FilePutObject(f, Map.Up)
        FilePutObject(f, Map.Down)
        FilePutObject(f, Map.Left)
        FilePutObject(f, Map.Right)
        FilePutObject(f, Map.BootMap)
        FilePutObject(f, Map.BootX)
        FilePutObject(f, Map.BootY)
        FilePutObject(f, Map.MaxX)
        FilePutObject(f, Map.MaxY)

        ' have to set the tile()

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                FilePutObject(f, Map.Tile(X, Y).Data1)
                FilePutObject(f, Map.Tile(X, Y).Data2)
                FilePutObject(f, Map.Tile(X, Y).Data3)
                FilePutObject(f, Map.Tile(X, Y).DirBlock)
                For i = 0 To UBound(Map.Tile(X, Y).Layer)
                    FilePutObject(f, Map.Tile(X, Y).Layer(i).tileset)
                    FilePutObject(f, Map.Tile(X, Y).Layer(i).X)
                    FilePutObject(f, Map.Tile(X, Y).Layer(i).Y)
                    FilePutObject(f, Map.Tile(X, Y).Autotile)
                Next
                FilePutObject(f, Map.Tile(X, Y).Type)
            Next
        Next

        For X = 1 To MAX_MAP_NPCS
            FilePutObject(f, Map.Npc(X))
        Next

        'For X = 0 To Map.MaxX
        '    For Y = 0 To Map.MaxY
        '        For l = 0 To MapLayer.Layer_Count - 1
        '            FilePutObject(f, Map.exTile(X, Y).Layer(l).tileset)
        '            FilePutObject(f, Map.exTile(X, Y).Layer(l).X)
        '            FilePutObject(f, Map.exTile(X, Y).Layer(l).Y)
        '            FilePutObject(f, Map.exTile(X, Y).Autotile)
        '        Next

        '    Next
        'Next

        FileClose(f)
    End Sub

    Public Sub LoadMap(ByVal MapNum As Long)
        Dim FileName As String
        Dim f As Long
        Dim X As Long
        Dim Y As Long
        FileName = Application.StartupPath & MAP_PATH & "map" & MapNum & MAP_EXT

        ClearMap()

        f = FreeFile()
        FileOpen(f, FileName, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        FileGetObject(f, Map.Name)
        FileGetObject(f, Map.Music)
        FileGetObject(f, Map.Revision)
        FileGetObject(f, Map.Moral)
        FileGetObject(f, Map.tileset)
        FileGetObject(f, Map.Up)
        FileGetObject(f, Map.Down)
        FileGetObject(f, Map.Left)
        FileGetObject(f, Map.Right)
        FileGetObject(f, Map.BootMap)
        FileGetObject(f, Map.BootX)
        FileGetObject(f, Map.BootY)
        FileGetObject(f, Map.MaxX)
        FileGetObject(f, Map.MaxY)

        ' have to set the tile()
        ReDim Map.Tile(0 To Map.MaxX, 0 To Map.MaxY)
        'ReDim Map.exTile(0 To Map.MaxX, 0 To Map.MaxY)

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                FileGetObject(f, Map.Tile(X, Y).Data1)
                FileGetObject(f, Map.Tile(X, Y).Data2)
                FileGetObject(f, Map.Tile(X, Y).Data3)
                FileGetObject(f, Map.Tile(X, Y).DirBlock)
                ReDim Map.Tile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
                For i = 0 To UBound(Map.Tile(X, Y).Layer)
                    FileGetObject(f, Map.Tile(X, Y).Layer(i).tileset)
                    FileGetObject(f, Map.Tile(X, Y).Layer(i).X)
                    FileGetObject(f, Map.Tile(X, Y).Layer(i).Y)
                    FileGetObject(f, Map.Tile(X, Y).Autotile)
                Next
                FileGetObject(f, Map.Tile(X, Y).Type)
            Next
        Next

        For X = 1 To MAX_MAP_NPCS
            FileGetObject(f, Map.Npc(X))
        Next

        'For X = 0 To Map.MaxX
        '    For Y = 0 To Map.MaxY
        '        ReDim Map.exTile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
        '        For l = 0 To MapLayer.Layer_Count - 1
        '            FileGetObject(f, Map.exTile(X, Y).Layer(l).tileset)
        '            FileGetObject(f, Map.exTile(X, Y).Layer(l).X)
        '            FileGetObject(f, Map.exTile(X, Y).Layer(l).Y)
        '            FileGetObject(f, Map.exTile(X, Y).Autotile)
        '        Next

        '    Next
        'Next

        FileClose(f)

        ClearTempTile()
    End Sub

    Function GetPlayerInvItemNum(ByVal Index As Long, ByVal invslot As Long) As Long
        GetPlayerInvItemNum = 0
        If Index > MAX_PLAYERS Then Exit Function
        If invslot = 0 Then Exit Function
        GetPlayerInvItemNum = PlayerInv(invslot).Num
    End Function

    Sub SetPlayerName(ByVal Index As Long, ByVal Name As String)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Name = Name
    End Sub

    Sub SetPlayerPOINTS(ByVal Index As Long, ByVal POINTS As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).POINTS = POINTS
    End Sub

    Sub SetPlayerStat(ByVal Index As Long, ByVal Stat As Stats, ByVal Value As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        If Value <= 0 Then Value = 1
        If Value > MAX_BYTE Then Value = MAX_BYTE
        Player(Index).Stat(Stat) = Value
    End Sub

    Sub SetPlayerInvItemNum(ByVal Index As Long, ByVal invslot As Long, ByVal itemnum As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        PlayerInv(invslot).Num = itemnum
    End Sub

    Function GetPlayerInvItemValue(ByVal Index As Long, ByVal invslot As Long) As Long
        GetPlayerInvItemValue = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerInvItemValue = PlayerInv(invslot).Value
    End Function

    Sub SetPlayerInvItemValue(ByVal Index As Long, ByVal invslot As Long, ByVal ItemValue As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        PlayerInv(invslot).Value = ItemValue
    End Sub

    Function GetPlayerPOINTS(ByVal Index As Long) As Long
        GetPlayerPOINTS = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPOINTS = Player(Index).POINTS
    End Function

    Sub SetPlayerAccess(ByVal Index As Long, ByVal Access As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Access = Access
    End Sub

    Sub SetPlayerPK(ByVal Index As Long, ByVal PK As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).PK = PK
    End Sub

    Sub SetPlayerVital(ByVal Index As Long, ByVal Vital As Vitals, ByVal Value As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Vital(Vital) = Value

        If GetPlayerVital(Index, Vital) > GetPlayerMaxVital(Index, Vital) Then
            Player(Index).Vital(Vital) = GetPlayerMaxVital(Index, Vital)
        End If

    End Sub

    Function GetPlayerMaxVital(ByVal Index As Long, ByVal Vital As Vitals) As Long
        GetPlayerMaxVital = 0
        If Index > MAX_PLAYERS Then Exit Function

        Select Case Vital
            Case Vitals.HP
                GetPlayerMaxVital = Player(Index).MaxHP
            Case Vitals.MP
                GetPlayerMaxVital = Player(Index).MaxMP
            Case Vitals.SP
                GetPlayerMaxVital = Player(Index).MaxSP
        End Select

    End Function

    Sub SetPlayerX(ByVal Index As Long, ByVal X As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).X = X
    End Sub

    Sub SetPlayerY(ByVal Index As Long, ByVal Y As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Y = Y
    End Sub

    Sub SetPlayerSprite(ByVal Index As Long, ByVal Sprite As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Sprite = Sprite
    End Sub

    Sub SetPlayerExp(ByVal Index As Long, ByVal EXP As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).EXP = EXP
    End Sub

    Sub SetPlayerLevel(ByVal Index As Long, ByVal Level As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Level = Level
    End Sub

    Sub SetPlayerDir(ByVal Index As Long, ByVal Dir As Long)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Dir = Dir
    End Sub

    Function GetPlayerVital(ByVal Index As Long, ByVal Vital As Vitals) As Long
        GetPlayerVital = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerVital = Player(Index).Vital(Vital)
    End Function

    Function GetPlayerSprite(ByVal Index As Long) As Long
        GetPlayerSprite = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerSprite = Player(Index).Sprite
    End Function

    Function GetPlayerMap(ByVal Index As Long) As Long
        GetPlayerMap = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerMap = Player(Index).Map
    End Function

    Function GetPlayerLevel(ByVal Index As Long) As Long
        GetPlayerLevel = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerLevel = Player(Index).Level
    End Function

    Function GetPlayerEquipment(ByVal Index As Long, ByVal EquipmentSlot As Equipment) As Byte
        GetPlayerEquipment = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerEquipment = Player(Index).Equipment(EquipmentSlot)
    End Function

    Function GetPlayerStat(ByVal Index As Long, ByVal Stat As Stats) As Long
        GetPlayerStat = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerStat = Player(Index).Stat(Stat)
    End Function

    Function GetPlayerExp(ByVal Index As Long) As Long

        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerExp = Player(Index).EXP
    End Function

    Function GetPlayerX(ByVal Index As Long) As Long
        GetPlayerX = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerX = Player(Index).X
    End Function

    Function GetPlayerY(ByVal Index As Long) As Long
        GetPlayerY = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerY = Player(Index).Y
    End Function

    Function GetPlayerAccess(ByVal Index As Long) As Long
        GetPlayerAccess = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerAccess = Player(Index).Access
    End Function

    Function GetPlayerPK(ByVal Index As Long) As Long
        GetPlayerPK = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPK = Player(Index).PK
    End Function

    Public Sub ClearItem(ByVal Index As Long)
        Index = Index - 1
        Item(Index) = Nothing
        Item(Index) = New ItemRec
        For x = 0 To Stats.stat_count - 1
            ReDim Item(Index).Add_Stat(x)
        Next
        For x = 0 To Stats.stat_count - 1
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
        Dim i As Long

        For i = 1 To MAX_ITEMS
            Call ClearItem(i)
        Next

    End Sub

    Public Sub ClearChanged_Resource()
        For i = 1 To MAX_RESOURCES
            Resource_Changed(i) = Nothing
        Next i
        ReDim Resource_Changed(0 To MAX_RESOURCES)
    End Sub

    Sub ClearResource(ByVal Index As Long)
        Resource(Index) = Nothing
        Resource(Index) = New ResourceRec
        Resource(Index).Name = vbNullString
    End Sub

    Sub ClearResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES
            Call ClearResource(i)
        Next

    End Sub

    Sub ClearNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS
            Call ClearNpc(i)
        Next

    End Sub

    Sub ClearNpc(ByVal Index As Long)
        Npc(Index) = Nothing
        Npc(Index).Name = ""
        Npc(Index).AttackSay = ""
        ReDim Npc(Index).Stat(0 To Stats.stat_count - 1)
    End Sub

    Sub ClearAnimation(ByVal Index As Long)
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
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS
            Call ClearAnimation(i)
        Next

    End Sub

    Sub ClearSpells()
        Dim i As Long

        For i = 1 To MAX_SPELLS
            Call ClearSpell(i)
        Next

    End Sub

    Sub ClearSpell(ByVal Index As Long)
        Spell(Index) = Nothing
        Spell(Index) = New SpellRec
        Spell(Index).Name = ""
    End Sub

    Sub ClearShop(ByVal Index As Long)
        Shop(Index) = Nothing
        Shop(Index) = New ShopRec
        Shop(Index).Name = ""
        ReDim Shop(Index).TradeItem(MAX_TRADES)
    End Sub

    Sub ClearShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS
            Call ClearShop(i)
        Next

    End Sub

    Sub ClearAnimInstance(ByVal index As Long)
        AnimInstance(index).Animation = 0
        AnimInstance(index).X = 0
        AnimInstance(index).Y = 0
        For i = 0 To UBound(AnimInstance(index).Used)
            AnimInstance(index).Used(i) = False
        Next
        For i = 0 To UBound(AnimInstance(index).Timer)
            AnimInstance(index).Timer(i) = False
        Next
        For i = 0 To UBound(AnimInstance(index).FrameIndex)
            AnimInstance(index).FrameIndex(i) = False
        Next

        AnimInstance(index).LockType = 0
        AnimInstance(index).lockindex = 0
    End Sub

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

    Sub CheckDirectories()
        ' Check if the directory is there, if its not make it
        If LCase$(Dir(Application.StartupPath & "\data files", vbDirectory)) <> "data files" Then
            Call MkDir(Application.StartupPath & "\data files")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\fonts", vbDirectory)) <> "fonts" Then
            Call MkDir(Application.StartupPath & "\data files\fonts")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics", vbDirectory)) <> "graphics" Then
            Call MkDir(Application.StartupPath & "\data files\graphics")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\maps", vbDirectory)) <> "maps" Then
            Call MkDir(Application.StartupPath & "\data files\maps")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\music", vbDirectory)) <> "music" Then
            Call MkDir(Application.StartupPath & "\data files\music")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\sound", vbDirectory)) <> "sound" Then
            Call MkDir(Application.StartupPath & "\data files\sound")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\actionbar", vbDirectory)) <> "actionbar" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\actionbar")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\animations", vbDirectory)) <> "animations" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\animations")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\characters", vbDirectory)) <> "characters" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\characters")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\gui", vbDirectory)) <> "gui" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\gui")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\items", vbDirectory)) <> "items" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\items")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\paperdolls", vbDirectory)) <> "paperdolls" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\paperdolls")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\resources", vbDirectory)) <> "resources" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\resources")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\spellicons", vbDirectory)) <> "spellicons" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\spellicons")
        End If

        If LCase$(Dir(Application.StartupPath & "\data files\graphics\tilesets", vbDirectory)) <> "tilesets" Then
            Call MkDir(Application.StartupPath & "\data files\graphics\tilesets")
        End If


    End Sub

End Module
