Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq

Module ClientDataBase
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

    Public Sub SaveOptions()
        Dim FileName As String

        FileName = Application.StartupPath & "\Data Files\config.ini"

        PutVar(FileName, "Options", "Username", Trim$(Options.Username))
        PutVar(FileName, "Options", "Password", Trim$(Options.Password))
        PutVar(FileName, "Options", "SavePass", Str(Options.SavePass))
        PutVar(FileName, "Options", "IP", Options.IP)
        PutVar(FileName, "Options", "Port", Str(Options.Port))
        PutVar(FileName, "Options", "MenuMusic", Trim$(Options.MenuMusic))
        PutVar(FileName, "Options", "Music", Str(Options.Music))
        PutVar(FileName, "Options", "Sound", Str(Options.Sound))
        PutVar(FileName, "Options", "Volume", Str(Options.Volume))
        PutVar(FileName, "Options", "ScreenSize", Str(Options.ScreenSize))
    End Sub

    Public Sub LoadOptions()
        Dim FileName As String

        FileName = Application.StartupPath & "\Data Files\config.ini"

        If Not FileExist(FileName) Then
            Options.Password = ""
            Options.SavePass = 0
            Options.Username = ""
            Options.IP = "127.0.0.1"
            Options.Port = 7001
            Options.MenuMusic = ""
            Options.Music = 1
            Options.Sound = 1
            Options.Volume = 100
            Options.ScreenSize = 0
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
            If Getvar(FileName, "Options", "Volume") = "" Then
                Options.Volume = 100
                SaveOptions()
            End If
            Options.Volume = Getvar(FileName, "Options", "Volume")
            Options.ScreenSize = Val(Getvar(FileName, "Options", "ScreenSize"))
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

        frmMainGame.cmbScreenSize.SelectedIndex = Options.ScreenSize

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

    Sub SetPlayerEquipment(ByVal Index As Integer, ByVal InvNum As Integer, ByVal EquipmentSlot As EquipmentType)

        If Index < 1 Or Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Equipment(EquipmentSlot) = InvNum
    End Sub

    Sub ClearPlayer(ByVal Index As Integer)
        Player(Index).Name = ""
        Player(Index).Access = 0
        Player(Index).Attacking = 0
        Player(Index).AttackTimer = 0
        Player(Index).Classes = 0
        Player(Index).Dir = 0
        Player(Index).Equipment(EquipmentType.Armor) = 0
        Player(Index).Equipment(EquipmentType.Helmet) = 0
        Player(Index).Equipment(EquipmentType.Shield) = 0
        Player(Index).Equipment(EquipmentType.Weapon) = 0
        Player(Index).Equipment(EquipmentType.Shoes) = 0
        Player(Index).Equipment(EquipmentType.Gloves) = 0
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
        Player(Index).Stat(Stats.Endurance) = 0
        Player(Index).Stat(Stats.Intelligence) = 0
        Player(Index).Stat(Stats.Spirit) = 0
        Player(Index).Stat(Stats.Strength) = 0
        Player(Index).Stat(Stats.Vitality) = 0
        Player(Index).Stat(Stats.Luck) = 0
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

    Sub SetPlayerMap(ByVal Index As Integer, ByVal MapNum As Integer)
        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Map = MapNum
    End Sub

    Sub ClearMapNpcs()
        Dim i As Integer

        For i = 1 To MAX_MAP_NPCS
            ClearMapNpc(i)
        Next

    End Sub

    Function GetPlayerInvItemNum(ByVal Index As Integer, ByVal invslot As Integer) As Integer
        GetPlayerInvItemNum = 0
        If Index > MAX_PLAYERS Then Exit Function
        If invslot = 0 Then Exit Function
        GetPlayerInvItemNum = PlayerInv(invslot).Num
    End Function

    Sub SetPlayerName(ByVal Index As Integer, ByVal Name As String)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Name = Name
    End Sub

    Sub SetPlayerClass(ByVal Index As Integer, ByVal Classnum As Integer)
        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Classes = Classnum
    End Sub

    Sub SetPlayerPOINTS(ByVal Index As Integer, ByVal POINTS As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).POINTS = POINTS
    End Sub

    Sub SetPlayerStat(ByVal Index As Integer, ByVal Stat As Stats, ByVal Value As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        If Value <= 0 Then Value = 1
        If Value > Byte.MaxValue Then Value = Byte.MaxValue
        Player(Index).Stat(Stat) = Value
    End Sub

    Sub SetPlayerInvItemNum(ByVal Index As Integer, ByVal invslot As Integer, ByVal itemnum As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        PlayerInv(invslot).Num = itemnum
    End Sub

    Function GetPlayerInvItemValue(ByVal Index As Integer, ByVal invslot As Integer) As Integer
        GetPlayerInvItemValue = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerInvItemValue = PlayerInv(invslot).Value
    End Function

    Sub SetPlayerInvItemValue(ByVal Index As Integer, ByVal invslot As Integer, ByVal ItemValue As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        PlayerInv(invslot).Value = ItemValue
    End Sub

    Function GetPlayerPOINTS(ByVal Index As Integer) As Integer
        GetPlayerPOINTS = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPOINTS = Player(Index).POINTS
    End Function

    Sub SetPlayerAccess(ByVal Index As Integer, ByVal Access As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Access = Access
    End Sub

    Sub SetPlayerPK(ByVal Index As Integer, ByVal PK As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).PK = PK
    End Sub

    Sub SetPlayerVital(ByVal Index As Integer, ByVal Vital As Vitals, ByVal Value As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Vital(Vital) = Value

        If GetPlayerVital(Index, Vital) > GetPlayerMaxVital(Index, Vital) Then
            Player(Index).Vital(Vital) = GetPlayerMaxVital(Index, Vital)
        End If

    End Sub

    Function GetPlayerMaxVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer
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

    Sub SetPlayerX(ByVal Index As Integer, ByVal X As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).X = X
    End Sub

    Sub SetPlayerY(ByVal Index As Integer, ByVal Y As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Y = Y
    End Sub

    Sub SetPlayerSprite(ByVal Index As Integer, ByVal Sprite As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Sprite = Sprite
    End Sub

    Sub SetPlayerExp(ByVal Index As Integer, ByVal EXP As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).EXP = EXP
    End Sub

    Sub SetPlayerLevel(ByVal Index As Integer, ByVal Level As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Level = Level
    End Sub

    Sub SetPlayerDir(ByVal Index As Integer, ByVal Dir As Integer)

        If Index > MAX_PLAYERS Then Exit Sub
        Player(Index).Dir = Dir
    End Sub

    Function GetPlayerVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer
        GetPlayerVital = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerVital = Player(Index).Vital(Vital)
    End Function

    Function GetPlayerSprite(ByVal Index As Integer) As Integer
        GetPlayerSprite = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerSprite = Player(Index).Sprite
    End Function

    Function GetPlayerClass(ByVal Index As Integer) As Integer
        GetPlayerClass = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerClass = Player(Index).Classes
    End Function

    Function GetPlayerMap(ByVal Index As Integer) As Integer
        GetPlayerMap = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerMap = Player(Index).Map
    End Function

    Function GetPlayerLevel(ByVal Index As Integer) As Integer
        GetPlayerLevel = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerLevel = Player(Index).Level
    End Function

    Function GetPlayerEquipment(ByVal Index As Integer, ByVal EquipmentSlot As EquipmentType) As Byte
        GetPlayerEquipment = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerEquipment = Player(Index).Equipment(EquipmentSlot)
    End Function

    Function GetPlayerStat(ByVal Index As Integer, ByVal Stat As Stats) As Integer
        GetPlayerStat = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerStat = Player(Index).Stat(Stat)
    End Function

    Function GetPlayerExp(ByVal Index As Integer) As Integer

        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerExp = Player(Index).EXP
    End Function

    Function GetPlayerX(ByVal Index As Integer) As Integer
        GetPlayerX = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerX = Player(Index).X
    End Function

    Function GetPlayerY(ByVal Index As Integer) As Integer
        GetPlayerY = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerY = Player(Index).Y
    End Function

    Function GetPlayerAccess(ByVal Index As Integer) As Integer
        GetPlayerAccess = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerAccess = Player(Index).Access
    End Function

    Function GetPlayerPK(ByVal Index As Integer) As Integer
        GetPlayerPK = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPK = Player(Index).PK
    End Function

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
            Call ClearAnimation(i)
        Next

    End Sub

    Sub ClearSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            Call ClearSkill(i)
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
            Call ClearShop(i)
        Next

    End Sub

    Sub ClearAnimInstance(ByVal index As Integer)
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


End Module
