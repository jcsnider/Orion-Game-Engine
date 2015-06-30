Imports System.Runtime.InteropServices

Module modGameLogic
    Function GetTotalMapPlayers(ByVal MapNum As Long) As Long
        Dim i As Long
        Dim n As Long
        n = 0

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) And GetPlayerMap(i) = MapNum Then
                n = n + 1
            End If

        Next

        GetTotalMapPlayers = n
    End Function
    Public Function GetPlayersOnline()
        Dim x As Long
        x = 0
        For i = 1 To MAX_PLAYERS
            If TempPlayer(i).InGame = True Then
                x = x + 1
            End If
        Next
        GetPlayersOnline = x
    End Function
    Function GetNpcMaxVital(ByVal NpcNum As Long, ByVal Vital As Vitals) As Long
        GetNpcMaxVital = 0

        ' Prevent subscript out of range
        If NpcNum <= 0 Or NpcNum > MAX_NPCS Then
            GetNpcMaxVital = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                GetNpcMaxVital = Npc(NpcNum).HP
            Case Vitals.MP
                GetNpcMaxVital = Npc(NpcNum).Stat(Stats.intelligence) * 2
            Case Vitals.SP
                GetNpcMaxVital = Npc(NpcNum).Stat(Stats.spirit) * 2
        End Select

    End Function
    Function FindPlayer(ByVal Name As String) As Long
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then

                ' Make sure we dont try to check a name thats to small
                If Len(GetPlayerName(i)) >= Len(Trim$(Name)) Then
                    If UCase$(Mid$(GetPlayerName(i), 1, Len(Trim$(Name)))) = UCase$(Trim$(Name)) Then
                        FindPlayer = i
                        Exit Function
                    End If
                End If
            End If

        Next

        FindPlayer = 0
    End Function
    Sub SpawnItem(ByVal itemNum As Long, ByVal ItemVal As Long, ByVal MapNum As Long, ByVal x As Long, ByVal y As Long)
        Dim i As Long

        ' Check for subscript out of range
        If itemNum < 1 Or itemNum > MAX_ITEMS Or MapNum <= 0 Or MapNum > MAX_MAPS Then
            Exit Sub
        End If

        ' Find open map item slot
        i = FindOpenMapItemSlot(MapNum)
        Call SpawnItemSlot(i, itemNum, ItemVal, MapNum, x, y)
    End Sub
    Sub SpawnItemSlot(ByVal MapItemSlot As Long, ByVal itemNum As Long, ByVal ItemVal As Long, ByVal MapNum As Long, ByVal x As Long, ByVal y As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If MapItemSlot <= 0 Or MapItemSlot > MAX_MAP_ITEMS Or itemNum < 0 Or itemNum > MAX_ITEMS Or MapNum <= 0 Or MapNum > MAX_MAPS Then
            Exit Sub
        End If

        i = MapItemSlot

        If i <> 0 Then
            If itemNum >= 0 Then
                If itemNum <= MAX_ITEMS Then
                    MapItem(MapNum, i).Num = itemNum
                    MapItem(MapNum, i).Value = ItemVal
                    MapItem(MapNum, i).x = x
                    MapItem(MapNum, i).y = y
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SSpawnItem)
                    Buffer.WriteLong(i)
                    Buffer.WriteLong(itemNum)
                    Buffer.WriteLong(ItemVal)
                    Buffer.WriteLong(x)
                    Buffer.WriteLong(y)
                    SendDataToMap(MapNum, Buffer.ToArray())
                    Buffer = Nothing
                End If
            End If
        End If

    End Sub
    Function FindOpenMapItemSlot(ByVal MapNum As Long) As Long
        Dim i As Long
        FindOpenMapItemSlot = 0

        ' Check for subscript out of range
        If MapNum <= 0 Or MapNum > MAX_MAPS Then
            Exit Function
        End If

        For i = 1 To MAX_MAP_ITEMS

            If MapItem(MapNum, i).Num = 0 Then
                FindOpenMapItemSlot = i
                Exit Function
            End If

        Next

    End Function
    Sub UpdateUI()
        If ConsoleText <> frmServer.txtText.Text Then
            frmServer.txtText.Text = ConsoleText
            frmServer.txtText.SelectionStart = frmServer.txtText.TextLength
            frmServer.txtText.ScrollToCaret()
        End If
        If NeedToUpDatePlayerList = True Then
            UpdateCaption()
            frmServer.lstView.Items.Clear()
            For x = 1 To MAX_PLAYERS
                frmServer.lstView.Items.Add(x)
                frmServer.lstView.Items(x - 1).SubItems.Add("")
                frmServer.lstView.Items(x - 1).SubItems.Add("")
                frmServer.lstView.Items(x - 1).SubItems.Add("")
            Next
            Try
                For i = 1 To MAX_PLAYERS
                    If Not Clients(i) Is Nothing Then
                        If Not Clients(i).Socket Is Nothing Then
                            If Clients(i).Socket.Connected Then
                                frmServer.lstView.Items(i - 1).SubItems(1).Text = Clients(i).IP
                                If Player(i).Login <> "" Then
                                    frmServer.lstView.Items(i - 1).SubItems(2).Text = Player(i).Login
                                    If Player(i).Name <> "" Then
                                        frmServer.lstView.Items(i - 1).SubItems(3).Text = Player(i).Name
                                    Else
                                        frmServer.lstView.Items(i - 1).SubItems(3).Text = ""
                                    End If
                                Else
                                    frmServer.lstView.Items(i - 1).SubItems(2).Text = ""
                                    frmServer.lstView.Items(i - 1).SubItems(3).Text = ""
                                End If
                            Else
                                frmServer.lstView.Items(i - 1).SubItems(1).Text = ""
                                frmServer.lstView.Items(i - 1).SubItems(2).Text = ""
                                frmServer.lstView.Items(i - 1).SubItems(3).Text = ""
                            End If
                        Else
                            frmServer.lstView.Items(i - 1).SubItems(1).Text = ""
                            frmServer.lstView.Items(i - 1).SubItems(2).Text = ""
                            frmServer.lstView.Items(i - 1).SubItems(3).Text = ""
                        End If
                    Else
                        frmServer.lstView.Items(i - 1).SubItems(1).Text = ""
                        frmServer.lstView.Items(i - 1).SubItems(2).Text = ""
                        frmServer.lstView.Items(i - 1).SubItems(3).Text = ""
                    End If
                Next
            Catch ex As Exception
                NeedToUpDatePlayerList = False
            End Try
            NeedToUpDatePlayerList = False
        End If
    End Sub
    Sub SpawnAllMapsItems()
        Dim i As Long

        For i = 1 To MAX_MAPS
            Call SpawnMapItems(i)
        Next

    End Sub
    Sub PlayerSwitchInvSlots(ByVal Index As Long, ByVal oldSlot As Integer, ByVal newSlot As Integer)
        Dim OldNum As Long
        Dim OldValue As Long
        Dim NewNum As Long
        Dim NewValue As Long

        If oldSlot = 0 Or newSlot = 0 Then
            Exit Sub
        End If

        OldNum = GetPlayerInvItemNum(Index, oldSlot)
        OldValue = GetPlayerInvItemValue(Index, oldSlot)
        NewNum = GetPlayerInvItemNum(Index, newSlot)
        NewValue = GetPlayerInvItemValue(Index, newSlot)
        SetPlayerInvItemNum(Index, newSlot, OldNum)
        SetPlayerInvItemValue(Index, newSlot, OldValue)
        SetPlayerInvItemNum(Index, oldSlot, NewNum)
        SetPlayerInvItemValue(Index, oldSlot, NewValue)
        SendInventory(Index)
    End Sub

    Sub SpawnMapItems(ByVal MapNum As Long)
        Dim x As Long
        Dim y As Long

        ' Check for subscript out of range
        If MapNum <= 0 Or MapNum > MAX_MAPS Then
            Exit Sub
        End If

        ' Spawn what we have
        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY

                ' Check if the tile type is an item or a saved tile incase someone drops something
                If (Map(MapNum).Tile(x, y).Type = TILE_TYPE_ITEM) Then

                    ' Check to see if its a currency and if they set the value to 0 set it to 1 automatically
                    If Item(Map(MapNum).Tile(x, y).Data1).Type = ITEM_TYPE_CURRENCY And Map(MapNum).Tile(x, y).Data2 <= 0 Then
                        Call SpawnItem(Map(MapNum).Tile(x, y).Data1, 1, MapNum, x, y)
                    Else
                        Call SpawnItem(Map(MapNum).Tile(x, y).Data1, Map(MapNum).Tile(x, y).Data2, MapNum, x, y)
                    End If
                End If

            Next
        Next

    End Sub
    Public Sub SpawnNpc(ByVal MapNpcNum As Long, ByVal MapNum As Long)
        Dim Buffer As ByteBuffer
        Dim NpcNum As Long
        Dim i As Long
        Dim x As Long
        Dim y As Long
        Dim Spawned As Boolean

        ' Check for subscript out of range
        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Sub
        NpcNum = Map(MapNum).Npc(MapNpcNum)

        If NpcNum > 0 Then

            MapNpc(MapNum).Npc(MapNpcNum).Num = NpcNum
            MapNpc(MapNum).Npc(MapNpcNum).Target = 0
            MapNpc(MapNum).Npc(MapNpcNum).TargetType = 0 ' clear

            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = GetNpcMaxVital(NpcNum, Vitals.HP)
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.MP) = GetNpcMaxVital(NpcNum, Vitals.MP)
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.SP) = GetNpcMaxVital(NpcNum, Vitals.SP)

            MapNpc(MapNum).Npc(MapNpcNum).Dir = Int(Rnd * 4)

            'Check if theres a spawn tile for the specific npc
            For x = 0 To Map(MapNum).MaxX
                For y = 0 To Map(MapNum).MaxY
                    If Map(MapNum).Tile(x, y).Type = TILE_TYPE_NPCSPAWN Then
                        If Map(MapNum).Tile(x, y).Data1 = MapNpcNum Then
                            MapNpc(MapNum).Npc(MapNpcNum).x = x
                            MapNpc(MapNum).Npc(MapNpcNum).y = y
                            MapNpc(MapNum).Npc(MapNpcNum).Dir = Map(MapNum).Tile(x, y).Data2
                            Spawned = True
                            Exit For
                        End If
                    End If
                Next y
            Next x

            If Not Spawned Then

                ' Well try 100 times to randomly place the sprite
                For i = 1 To 100
                    x = Random(0, Map(MapNum).MaxX)
                    y = Random(0, Map(MapNum).MaxY)

                    If x > Map(MapNum).MaxX Then x = Map(MapNum).MaxX
                    If y > Map(MapNum).MaxY Then y = Map(MapNum).MaxY

                    ' Check if the tile is walkable
                    If NpcTileIsOpen(MapNum, x, y) Then
                        MapNpc(MapNum).Npc(MapNpcNum).x = x
                        MapNpc(MapNum).Npc(MapNpcNum).y = y
                        Spawned = True
                        Exit For
                    End If

                Next

            End If

            ' Didn't spawn, so now we'll just try to find a free tile
            If Not Spawned Then

                For x = 0 To Map(MapNum).MaxX
                    For y = 0 To Map(MapNum).MaxY

                        If NpcTileIsOpen(MapNum, x, y) Then
                            MapNpc(MapNum).Npc(MapNpcNum).x = x
                            MapNpc(MapNum).Npc(MapNpcNum).y = y
                            Spawned = True
                        End If

                    Next
                Next

            End If

            ' If we suceeded in spawning then send it to everyone
            If Spawned Then
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SSpawnNpc)
                Buffer.WriteLong(MapNpcNum)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Num)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).x)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).y)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Dir)
                SendDataToMap(MapNum, Buffer.ToArray())
                Buffer = Nothing
            End If

            SendMapNpcVitals(MapNum, MapNpcNum)
        End If

    End Sub
    Public Function Random(ByVal low As Int32, ByVal high As Int32) As Integer
        Static RandomNumGen As New System.Random
        Return RandomNumGen.Next(low, high + 1)
    End Function
    Public Function NpcTileIsOpen(ByVal MapNum As Long, ByVal x As Long, ByVal y As Long) As Boolean
        Dim LoopI As Long
        NpcTileIsOpen = True

        If PlayersOnMap(MapNum) Then

            For LoopI = 1 To MAX_PLAYERS

                If GetPlayerMap(LoopI) = MapNum Then
                    If GetPlayerX(LoopI) = x Then
                        If GetPlayerY(LoopI) = y Then
                            NpcTileIsOpen = False
                            Exit Function
                        End If
                    End If
                End If

            Next

        End If

        For LoopI = 1 To MAX_MAP_NPCS

            If MapNpc(MapNum).Npc(LoopI).Num > 0 Then
                If MapNpc(MapNum).Npc(LoopI).x = x Then
                    If MapNpc(MapNum).Npc(LoopI).y = y Then
                        NpcTileIsOpen = False
                        Exit Function
                    End If
                End If
            End If

        Next

        If Map(MapNum).Tile(x, y).Type <> TILE_TYPE_WALKABLE Then
            If Map(MapNum).Tile(x, y).Type <> TILE_TYPE_NPCSPAWN Then
                If Map(MapNum).Tile(x, y).Type <> TILE_TYPE_ITEM Then
                    NpcTileIsOpen = False
                End If
            End If
        End If
    End Function
    Public Function CheckGrammar(ByVal Word As String, Optional ByVal Caps As Byte = 0) As String
        Dim FirstLetter As String

        FirstLetter = LCase$(Left$(Word, 1))

        If FirstLetter = "$" Then
            CheckGrammar = (Mid$(Word, 2, Len(Word) - 1))
            Exit Function
        End If

        If FirstLetter Like "*[aeiou]*" Then
            If Caps Then CheckGrammar = "An " & Word Else CheckGrammar = "an " & Word
        Else
            If Caps Then CheckGrammar = "A " & Word Else CheckGrammar = "a " & Word
        End If
    End Function
    Function CanNpcMove(ByVal MapNum As Long, ByVal MapNpcNum As Long, ByVal Dir As Byte) As Boolean
        Dim i As Long
        Dim n As Long
        Dim x As Long
        Dim y As Long

        ' Check for subscript out of range
        If MapNum <= 0 Or MapNum > MAX_MAPS Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Dir < DIR_UP Or Dir > DIR_RIGHT Then
            Exit Function
        End If

        x = MapNpc(MapNum).Npc(MapNpcNum).x
        y = MapNpc(MapNum).Npc(MapNpcNum).y
        CanNpcMove = True

        Select Case Dir
            Case DIR_UP

                ' Check to make sure not outside of boundries
                If y > 0 Then
                    n = Map(MapNum).Tile(x, y - 1).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanNpcMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS

                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = MapNpc(MapNum).Npc(MapNpcNum).x) And (GetPlayerY(i) = MapNpc(MapNum).Npc(MapNpcNum).y - 1) Then
                                CanNpcMove = False
                                Exit Function
                            End If
                        End If

                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS

                        If (i <> MapNpcNum) And (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = MapNpc(MapNum).Npc(MapNpcNum).x) And (MapNpc(MapNum).Npc(i).y = MapNpc(MapNum).Npc(MapNpcNum).y - 1) Then
                            CanNpcMove = False
                            Exit Function
                        End If

                    Next

                Else
                    CanNpcMove = False
                End If

            Case DIR_DOWN

                ' Check to make sure not outside of boundries
                If y < Map(MapNum).MaxY Then
                    n = Map(MapNum).Tile(x, y + 1).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanNpcMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS

                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = MapNpc(MapNum).Npc(MapNpcNum).x) And (GetPlayerY(i) = MapNpc(MapNum).Npc(MapNpcNum).y + 1) Then
                                CanNpcMove = False
                                Exit Function
                            End If
                        End If

                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS

                        If (i <> MapNpcNum) And (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = MapNpc(MapNum).Npc(MapNpcNum).x) And (MapNpc(MapNum).Npc(i).y = MapNpc(MapNum).Npc(MapNpcNum).y + 1) Then
                            CanNpcMove = False
                            Exit Function
                        End If

                    Next

                Else
                    CanNpcMove = False
                End If

            Case DIR_LEFT

                ' Check to make sure not outside of boundries
                If x > 0 Then
                    n = Map(MapNum).Tile(x - 1, y).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanNpcMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS

                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = MapNpc(MapNum).Npc(MapNpcNum).x - 1) And (GetPlayerY(i) = MapNpc(MapNum).Npc(MapNpcNum).y) Then
                                CanNpcMove = False
                                Exit Function
                            End If
                        End If

                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS

                        If (i <> MapNpcNum) And (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = MapNpc(MapNum).Npc(MapNpcNum).x - 1) And (MapNpc(MapNum).Npc(i).y = MapNpc(MapNum).Npc(MapNpcNum).y) Then
                            CanNpcMove = False
                            Exit Function
                        End If

                    Next

                Else
                    CanNpcMove = False
                End If

            Case DIR_RIGHT

                ' Check to make sure not outside of boundries
                If x < Map(MapNum).MaxX Then
                    n = Map(MapNum).Tile(x + 1, y).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TILE_TYPE_WALKABLE And n <> TILE_TYPE_ITEM And n <> TILE_TYPE_NPCSPAWN Then
                        CanNpcMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS

                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = MapNpc(MapNum).Npc(MapNpcNum).x + 1) And (GetPlayerY(i) = MapNpc(MapNum).Npc(MapNpcNum).y) Then
                                CanNpcMove = False
                                Exit Function
                            End If
                        End If

                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS

                        If (i <> MapNpcNum) And (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = MapNpc(MapNum).Npc(MapNpcNum).x + 1) And (MapNpc(MapNum).Npc(i).y = MapNpc(MapNum).Npc(MapNpcNum).y) Then
                            CanNpcMove = False
                            Exit Function
                        End If

                    Next

                Else
                    CanNpcMove = False
                End If

        End Select

    End Function
    Sub NpcMove(ByVal MapNum As Long, ByVal MapNpcNum As Long, ByVal Dir As Long, ByVal movement As Long)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If MapNum <= 0 Or MapNum > MAX_MAPS Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Dir < DIR_UP Or Dir > DIR_RIGHT Or movement < 1 Or movement > 2 Then
            Exit Sub
        End If

        MapNpc(MapNum).Npc(MapNpcNum).Dir = Dir

        Select Case Dir
            Case DIR_UP
                MapNpc(MapNum).Npc(MapNpcNum).y = MapNpc(MapNum).Npc(MapNpcNum).y - 1
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SNpcMove)
                Buffer.WriteLong(MapNpcNum)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).x)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).y)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Dir)
                Buffer.WriteLong(movement)
                SendDataToMap(MapNum, Buffer.ToArray())
                Buffer = Nothing
            Case DIR_DOWN
                MapNpc(MapNum).Npc(MapNpcNum).y = MapNpc(MapNum).Npc(MapNpcNum).y + 1
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SNpcMove)
                Buffer.WriteLong(MapNpcNum)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).x)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).y)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Dir)
                Buffer.WriteLong(movement)
                SendDataToMap(MapNum, Buffer.ToArray())
                Buffer = Nothing
            Case DIR_LEFT
                MapNpc(MapNum).Npc(MapNpcNum).x = MapNpc(MapNum).Npc(MapNpcNum).x - 1
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SNpcMove)
                Buffer.WriteLong(MapNpcNum)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).x)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).y)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Dir)
                Buffer.WriteLong(movement)
                SendDataToMap(MapNum, Buffer.ToArray())
                Buffer = Nothing
            Case DIR_RIGHT
                MapNpc(MapNum).Npc(MapNpcNum).x = MapNpc(MapNum).Npc(MapNpcNum).x + 1
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SNpcMove)
                Buffer.WriteLong(MapNpcNum)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).x)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).y)
                Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Dir)
                Buffer.WriteLong(movement)
                SendDataToMap(MapNum, Buffer.ToArray())
                Buffer = Nothing
        End Select

    End Sub

    Sub NpcDir(ByVal MapNum As Long, ByVal MapNpcNum As Long, ByVal Dir As Long)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If MapNum <= 0 Or MapNum > MAX_MAPS Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Dir < DIR_UP Or Dir > DIR_RIGHT Then
            Exit Sub
        End If

        MapNpc(MapNum).Npc(MapNpcNum).Dir = Dir
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SNpcDir)
        Buffer.WriteLong(MapNpcNum)
        Buffer.WriteLong(Dir)
        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SpawnAllMapNpcs()
        Dim i As Long

        For i = 1 To MAX_MAPS
            Call SpawnMapNpcs(i)
        Next

    End Sub
    Sub SpawnMapNpcs(ByVal MapNum As Long)
        Dim i As Long

        For i = 1 To MAX_MAP_NPCS
            Call SpawnNpc(i, MapNum)
        Next

    End Sub
    Sub SendMapNpcsToMap(ByVal MapNum As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapNpcData)

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Num)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).x)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).y)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Dir)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Vital(Vitals.HP))
        Next

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub PlayerSwitchBankSlots(ByVal Index As Long, ByVal oldSlot As Long, ByVal newSlot As Long)
        Dim OldNum As Long
        Dim OldValue As Long
        Dim NewNum As Long
        Dim NewValue As Long

        If oldSlot = 0 Or newSlot = 0 Then
            Exit Sub
        End If

        OldNum = GetPlayerBankItemNum(Index, oldSlot)
        OldValue = GetPlayerBankItemValue(Index, oldSlot)
        NewNum = GetPlayerBankItemNum(Index, newSlot)
        NewValue = GetPlayerBankItemValue(Index, newSlot)

        SetPlayerBankItemNum(Index, newSlot, OldNum)
        SetPlayerBankItemValue(Index, newSlot, OldValue)

        SetPlayerBankItemNum(Index, oldSlot, NewNum)
        SetPlayerBankItemValue(Index, oldSlot, NewValue)

        SendBank(Index)
    End Sub
    Function CanAttackPlayer(ByVal Attacker As Long, ByVal Victim As Long, Optional ByVal IsSpell As Boolean = False) As Boolean

        If Not IsSpell Then
            ' Check attack timer
            If GetPlayerEquipment(Attacker, Equipment.Weapon) > 0 Then
                If GetTickCount < TempPlayer(Attacker).AttackTimer + Item(GetPlayerEquipment(Attacker, Equipment.Weapon)).Speed Then Exit Function
            Else
                If GetTickCount < TempPlayer(Attacker).AttackTimer + 1000 Then Exit Function
            End If
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = YES Then Exit Function

        If Not IsSpell Then
            ' Check if at same coordinates
            Select Case GetPlayerDir(Attacker)
                Case DIR_UP

                    If Not ((GetPlayerY(Victim) + 1 = GetPlayerY(Attacker)) And (GetPlayerX(Victim) = GetPlayerX(Attacker))) Then Exit Function
                Case DIR_DOWN

                    If Not ((GetPlayerY(Victim) - 1 = GetPlayerY(Attacker)) And (GetPlayerX(Victim) = GetPlayerX(Attacker))) Then Exit Function
                Case DIR_LEFT

                    If Not ((GetPlayerY(Victim) = GetPlayerY(Attacker)) And (GetPlayerX(Victim) + 1 = GetPlayerX(Attacker))) Then Exit Function
                Case DIR_RIGHT

                    If Not ((GetPlayerY(Victim) = GetPlayerY(Attacker)) And (GetPlayerX(Victim) - 1 = GetPlayerX(Attacker))) Then Exit Function
                Case Else
                    Exit Function
            End Select
        End If

        ' Check if map is attackable
        If Not Map(GetPlayerMap(Attacker)).Moral = MAP_MORAL_NONE Then
            If GetPlayerPK(Victim) = NO Then
                Call PlayerMsg(Attacker, "This is a safe zone!")
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If GetPlayerVital(Victim, Vitals.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > ADMIN_MONITOR Then
            Call PlayerMsg(Attacker, "You cannot attack any player for thou art an admin!")
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > ADMIN_MONITOR Then
            Call PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "!")
            Exit Function
        End If

        ' Make sure attacker is high enough level
        If GetPlayerLevel(Attacker) < 10 Then
            Call PlayerMsg(Attacker, "You are below level 10, you cannot attack another player yet!")
            Exit Function
        End If

        ' Make sure victim is high enough level
        If GetPlayerLevel(Victim) < 10 Then
            Call PlayerMsg(Attacker, GetPlayerName(Victim) & " is below level 10, you cannot attack this player yet!")
            Exit Function
        End If

        CanAttackPlayer = True
    End Function
    Function CanPlayerBlockHit(ByVal Index As Long) As Boolean
        Dim i As Long
        Dim n As Long
        Dim ShieldSlot As Long
        ShieldSlot = GetPlayerEquipment(Index, Equipment.Shield)

        If ShieldSlot > 0 Then
            n = Int(Rnd * 2)

            If n = 1 Then
                i = (GetPlayerStat(Index, Stats.endurance) \ 2) + (GetPlayerLevel(Index) \ 2)
                n = Int(Rnd * 100) + 1

                If n <= i Then
                    CanPlayerBlockHit = True
                End If
            End If
        End If

    End Function
    Function CanPlayerCriticalHit(ByVal Index As Long) As Boolean
        On Error Resume Next
        Dim i As Long
        Dim n As Long

        If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
            n = (Rnd()) * 2

            If n = 1 Then
                i = (GetPlayerStat(Index, Stats.strength) \ 2) + (GetPlayerLevel(Index) \ 2)
                n = Int(Rnd() * 100) + 1

                If n <= i Then
                    CanPlayerCriticalHit = True
                End If
            End If
        End If

    End Function
    Function GetPlayerDamage(ByVal Index As Long) As Long
        Dim Weapon As Long
        GetPlayerDamage = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            Exit Function
        End If

        GetPlayerDamage = GetPlayerStat(Index, Stats.strength)

        If GetPlayerEquipment(Index, Weapon) > 0 Then
            Weapon = GetPlayerEquipment(Index, Weapon)
            GetPlayerDamage = GetPlayerDamage + Item(Weapon).Data2
        End If

    End Function

    Function GetPlayerProtection(ByVal Index As Long) As Long
        Dim Armor As Long
        Dim Helm As Long
        GetPlayerProtection = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            Exit Function
        End If

        Armor = GetPlayerEquipment(Index, Armor)
        Helm = GetPlayerEquipment(Index, Equipment.Helmet)
        GetPlayerProtection = (GetPlayerStat(Index, Stats.endurance) \ 5)

        If Armor > 0 Then
            GetPlayerProtection = GetPlayerProtection + Item(Armor).Data2
        End If

        If Helm > 0 Then
            GetPlayerProtection = GetPlayerProtection + Item(Helm).Data2
        End If

    End Function
    Sub AttackPlayer(ByVal Attacker As Long, ByVal Victim As Long, ByVal Damage As Long, Optional ByVal spellnum As Long = 0)
        Dim exp As Long
        Dim n As Long
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Then
            Exit Sub
        End If

        ' Check for weapon
        n = 0

        If GetPlayerEquipment(Attacker, Equipment.Weapon) > 0 Then
            n = GetPlayerEquipment(Attacker, Equipment.Weapon)
        End If

        ' Send this packet so they can see the person attacking
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SAttack)
        Buffer.WriteLong(Attacker)
        SendDataToMapBut(Attacker, GetPlayerMap(Attacker), Buffer.ToArray())
        Buffer = Nothing

        If Damage >= GetPlayerVital(Victim, Vitals.HP) Then

            'Call PlayerMsg(Attacker, "You hit " & GetPlayerName(Victim) & " for " & Damage & " hit points.", White)
            'Call PlayerMsg(Victim, GetPlayerName(Attacker) & " hit you for " & Damage & " hit points.", BrightRed)
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            ' Player is dead
            Call GlobalMsg(GetPlayerName(Victim) & " has been killed by " & GetPlayerName(Attacker))
            ' Calculate exp to give attacker
            exp = (GetPlayerExp(Victim) \ 10)

            ' Make sure we dont get less then 0
            If exp < 0 Then
                exp = 0
            End If

            If exp = 0 Then
                Call PlayerMsg(Victim, "You lost no exp.")
                Call PlayerMsg(Attacker, "You received no exp.")
            Else
                Call SetPlayerExp(Victim, GetPlayerExp(Victim) - exp)
                SendEXP(Victim)
                Call PlayerMsg(Victim, "You lost " & exp & " exp.")
                Call SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendEXP(Attacker)
                Call PlayerMsg(Attacker, "You received " & exp & " exp.")
            End If

            ' Check for a level up
            Call CheckPlayerLevelUp(Attacker)

            ' Check if target is player who died and if so set target to 0
            If TempPlayer(Attacker).TargetType = TARGET_TYPE_PLAYER Then
                If TempPlayer(Attacker).Target = Victim Then
                    TempPlayer(Attacker).Target = 0
                    TempPlayer(Attacker).TargetType = TARGET_TYPE_NONE
                End If
            End If

            If GetPlayerPK(Victim) = NO Then
                If GetPlayerPK(Attacker) = NO Then
                    Call SetPlayerPK(Attacker, YES)
                    Call SendPlayerData(Attacker)
                    Call GlobalMsg(GetPlayerName(Attacker) & " has been deemed a Player Killer!!!")
                End If

            Else
                Call GlobalMsg(GetPlayerName(Victim) & " has paid the price for being a Player Killer!!!")
            End If

            Call OnDeath(Victim)
        Else
            ' Player not dead, just do the damage
            Call SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
            Call SendVital(Victim, Vitals.HP)
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            'if a stunning spell, stun the player
            If spellnum > 0 Then
                If Spell(spellnum).StunDuration > 0 Then StunPlayer(Victim, spellnum)
            End If
        End If

        ' Reset attack timer
        TempPlayer(Attacker).AttackTimer = GetTickCount
    End Sub
    Public Sub StunPlayer(ByVal Index As Long, ByVal spellnum As Long)
        ' check if it's a stunning spell
        If Spell(spellnum).StunDuration > 0 Then
            ' set the values on index
            TempPlayer(Index).StunDuration = Spell(spellnum).StunDuration
            TempPlayer(Index).StunTimer = GetTickCount
            ' send it to the index
            SendStunned(Index)
            ' tell him he's stunned
            PlayerMsg(Index, "You have been stunned.")
        End If
    End Sub
    Function CanAttackNpc(ByVal Attacker As Long, ByVal MapNpcNum As Long, Optional ByVal IsSpell As Boolean = False) As Boolean
        Dim MapNum As Long
        Dim NpcNum As Long
        Dim atkX As Long
        Dim atkY As Long
        Dim attackspeed As Long

        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Attacker)).Npc(MapNpcNum).Num <= 0 Then
            Exit Function
        End If

        MapNum = GetPlayerMap(Attacker)
        NpcNum = MapNpc(MapNum).Npc(MapNpcNum).Num

        ' Make sure the npc isn't already dead
        If MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) <= 0 Then
            Exit Function
        End If

        ' Make sure they are on the same map
        If IsPlaying(Attacker) Then

            ' attack speed from weapon
            If GetPlayerEquipment(Attacker, Equipment.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(Attacker, Equipment.Weapon)).Speed
            Else
                attackspeed = 1000
            End If

            If NpcNum > 0 And GetTickCount > TempPlayer(Attacker).AttackTimer + attackspeed Then

                ' exit out early
                If IsSpell Then
                    If Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_FRIENDLY And Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_SHOPKEEPER Then
                        CanAttackNpc = True
                        Exit Function
                    End If
                End If

                ' Check if at same coordinates
                Select Case GetPlayerDir(Attacker)
                    Case DIR_UP
                        atkX = GetPlayerX(Attacker)
                        atkY = GetPlayerY(Attacker) - 1
                    Case DIR_DOWN
                        atkX = GetPlayerX(Attacker)
                        atkY = GetPlayerY(Attacker) + 1
                    Case DIR_LEFT
                        atkX = GetPlayerX(Attacker) - 1
                        atkY = GetPlayerY(Attacker)
                    Case DIR_RIGHT
                        atkX = GetPlayerX(Attacker) + 1
                        atkY = GetPlayerY(Attacker)
                End Select

                If atkX = MapNpc(MapNum).Npc(MapNpcNum).x Then
                    If atkY = MapNpc(MapNum).Npc(MapNpcNum).y Then
                        If Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_FRIENDLY And Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_SHOPKEEPER Then
                            CanAttackNpc = True
                        Else
                            If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                                PlayerMsg(Attacker, Trim$(Npc(NpcNum).Name) & ": " & Trim$(Npc(NpcNum).AttackSay))
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function
    Sub AttackNpc(ByVal Attacker As Long, ByVal MapNpcNum As Long, ByVal Damage As Long, Optional ByVal spellnum As Long = 0)
        Dim Name As String
        Dim exp As Long
        Dim n As Long
        Dim i As Long
        Dim MapNum As Long
        Dim NpcNum As Long
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Damage < 0 Then
            Exit Sub
        End If

        MapNum = GetPlayerMap(Attacker)
        NpcNum = MapNpc(MapNum).Npc(MapNpcNum).Num
        Name = Trim$(Npc(NpcNum).Name)

        If spellnum = 0 Then
            ' Send this packet so they can see the person attacking
            Buffer = New ByteBuffer
            Buffer.WriteLong(ServerPackets.SAttack)
            Buffer.WriteLong(Attacker)
            SendDataToMapBut(Attacker, MapNum, Buffer.ToArray())
            Buffer = Nothing
        End If

        ' Check for weapon
        n = 0

        If GetPlayerEquipment(Attacker, Equipment.Weapon) > 0 Then
            n = GetPlayerEquipment(Attacker, Equipment.Weapon)
        End If

        If Damage >= MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) Then

            SendActionMsg(GetPlayerMap(Attacker), "-" & Damage, BrightRed, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)

            ' Calculate exp to give attacker
            exp = Npc(NpcNum).exp

            ' Make sure we dont get less then 0
            If exp < 0 Then
                exp = 1
            End If

            ' Check if in party, if so divide the exp up by 2
            If TempPlayer(Attacker).InParty = NO Then
                Call SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendEXP(Attacker)
                'Call PlayerMsg(Attacker, "You have gained " & Exp & " experience points.", BrightBlue)
                SendActionMsg(GetPlayerMap(Attacker), "+" & exp & " EXP", White, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
            Else
                exp = exp / 2

                If exp < 0 Then
                    exp = 1
                End If

                Call SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendEXP(Attacker)
                'Call PlayerMsg(Attacker, "You have gained " & Exp & " party experience points.", BrightBlue)
                SendActionMsg(GetPlayerMap(Attacker), "+" & exp & " Shared EXP", White, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
                n = TempPlayer(Attacker).PartyPlayer

                If n > 0 Then
                    Call SetPlayerExp(n, GetPlayerExp(n) + exp)
                    SendEXP(n)
                    'Call PlayerMsg(n, "You have gained " & Exp & " party experience points.", BrightBlue)
                    SendActionMsg(GetPlayerMap(n), "+" & exp & " EXP", White, 1, (GetPlayerX(n) * 32), (GetPlayerY(n) * 32))
                End If
            End If

            ' Drop the goods if they get it
            n = Int(Rnd() * Npc(NpcNum).DropChance) + 1

            If n = 1 Then
                Call SpawnItem(Npc(NpcNum).DropItem, Npc(NpcNum).DropItemValue, MapNum, MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)
            End If

            ' Now set HP to 0 so we know to actually kill them in the server loop (this prevents subscript out of range)
            MapNpc(MapNum).Npc(MapNpcNum).Num = 0
            MapNpc(MapNum).Npc(MapNpcNum).SpawnWait = GetTickCount
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = 0

            Buffer = New ByteBuffer
            Buffer.WriteLong(ServerPackets.SNpcDead)
            Buffer.WriteLong(MapNpcNum)
            SendDataToMap(MapNum, Buffer.ToArray())
            Buffer = Nothing

            ' Check for level up
            Call CheckPlayerLevelUp(Attacker)

            ' Check for level up party member
            If TempPlayer(Attacker).InParty = YES Then
                Call CheckPlayerLevelUp(TempPlayer(Attacker).PartyPlayer)
            End If

            ' Check if target is npc that died and if so set target to 0
            If TempPlayer(Attacker).TargetType = TARGET_TYPE_NPC Then
                If TempPlayer(Attacker).Target = MapNpcNum Then
                    TempPlayer(Attacker).Target = 0
                    TempPlayer(Attacker).TargetType = TARGET_TYPE_NONE
                End If
            End If

        Else
            ' NPC not dead, just do the damage
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) - Damage

            ' Check for a weapon and say damage
            SendActionMsg(MapNum, "-" & Damage, BrightRed, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)

            ' send animation
            If n > 0 Then
                If spellnum = 0 Then Call SendAnimation(MapNum, Item(GetPlayerEquipment(Attacker, Equipment.Weapon)).Animation, 0, 0, TARGET_TYPE_NPC, MapNpcNum)
            End If

            ' Check if we should send a message
            If MapNpc(MapNum).Npc(MapNpcNum).Target = 0 Then
                If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                    Call PlayerMsg(Attacker, CheckGrammar(Trim$(Npc(NpcNum).Name), 1) & " says: " & Trim$(Npc(NpcNum).AttackSay))
                End If
            End If

            ' Set the NPC target to the player
            MapNpc(MapNum).Npc(MapNpcNum).TargetType = 1 ' player
            MapNpc(MapNum).Npc(MapNpcNum).Target = Attacker

            ' Now check for guard ai and if so have all onmap guards come after'm
            If Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Behaviour = NPC_BEHAVIOUR_GUARD Then

                For i = 1 To MAX_MAP_NPCS

                    If MapNpc(MapNum).Npc(i).Num = MapNpc(MapNum).Npc(MapNpcNum).Num Then
                        MapNpc(MapNum).Npc(i).Target = Attacker
                        MapNpc(MapNum).Npc(i).TargetType = 1 ' player
                    End If

                Next

            End If

            ' if stunning spell, stun the npc
            If spellnum > 0 Then
                If Spell(spellnum).StunDuration > 0 Then StunNPC(MapNpcNum, MapNum, spellnum)
            End If
        End If

        If spellnum = 0 Then
            ' Reset attack timer
            TempPlayer(Attacker).AttackTimer = GetTickCount
        End If
    End Sub
    Public Sub StunNPC(ByVal Index As Long, ByVal MapNum As Long, ByVal spellnum As Long)
        ' check if it's a stunning spell
        If Spell(spellnum).StunDuration > 0 Then
            ' set the values on index
            MapNpc(MapNum).Npc(Index).StunDuration = Spell(spellnum).StunDuration
            MapNpc(MapNum).Npc(Index).StunTimer = GetTickCount
        End If
    End Sub
    Sub PlayerUnequipItem(ByVal Index As Long, ByVal EqSlot As Long)

        If EqSlot <= 0 Or EqSlot > Equipment.Equipment_Count - 1 Then Exit Sub ' exit out early if error'd
        If FindOpenInvSlot(Index, GetPlayerEquipment(Index, EqSlot)) > 0 Then
            GiveInvItem(Index, GetPlayerEquipment(Index, EqSlot), 0)
            PlayerMsg(Index, "You unequip " & CheckGrammar(Item(GetPlayerEquipment(Index, EqSlot)).Name))
            SetPlayerEquipment(Index, 0, EqSlot)
            SendWornEquipment(Index)
            SendMapEquipment(Index)
            SendStats(Index)
        Else
            PlayerMsg(Index, "Your inventory is full.")
        End If

    End Sub
    Function CanNpcAttackPlayer(ByVal MapNpcNum As Long, ByVal Index As Long) As Boolean
        Dim MapNum As Long
        Dim NpcNum As Long

        ' Check for subscript out of range
        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Not IsPlaying(Index) Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Index)).Npc(MapNpcNum).Num <= 0 Then
            Exit Function
        End If

        MapNum = GetPlayerMap(Index)
        NpcNum = MapNpc(MapNum).Npc(MapNpcNum).Num

        ' Make sure the npc isn't already dead
        If MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) <= 0 Then
            Exit Function
        End If

        ' Make sure npcs dont attack more then once a second
        If GetTickCount < MapNpc(MapNum).Npc(MapNpcNum).AttackTimer + 1000 Then
            Exit Function
        End If

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Index).GettingMap = YES Then
            Exit Function
        End If

        MapNpc(MapNum).Npc(MapNpcNum).AttackTimer = GetTickCount

        ' Make sure they are on the same map
        If IsPlaying(Index) Then
            If NpcNum > 0 Then

                ' Check if at same coordinates
                If (GetPlayerY(Index) + 1 = MapNpc(MapNum).Npc(MapNpcNum).y) And (GetPlayerX(Index) = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                    CanNpcAttackPlayer = True
                Else

                    If (GetPlayerY(Index) - 1 = MapNpc(MapNum).Npc(MapNpcNum).y) And (GetPlayerX(Index) = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                        CanNpcAttackPlayer = True
                    Else

                        If (GetPlayerY(Index) = MapNpc(MapNum).Npc(MapNpcNum).y) And (GetPlayerX(Index) + 1 = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                            CanNpcAttackPlayer = True
                        Else

                            If (GetPlayerY(Index) = MapNpc(MapNum).Npc(MapNpcNum).y) And (GetPlayerX(Index) - 1 = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                                CanNpcAttackPlayer = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function
    Function CanNpcAttackNpc(ByVal MapNum As Long, ByVal Attacker As Long, ByVal Victim As Long) As Boolean
        Dim aNpcNum As Long
        Dim vNpcNum As Long
        Dim VictimX As Long
        Dim VictimY As Long
        Dim AttackerX As Long
        Dim AttackerY As Long

        CanNpcAttackNpc = False

        ' Check for subscript out of range
        If Attacker <= 0 Or Attacker > MAX_MAP_NPCS Then
            Exit Function
        End If

        If Victim <= 0 Or Victim > MAX_MAP_NPCS Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNpc(MapNum).Npc(Attacker).Num <= 0 Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNpc(MapNum).Npc(Victim).Num <= 0 Then
            Exit Function
        End If

        aNpcNum = MapNpc(MapNum).Npc(Attacker).Num
        vNpcNum = MapNpc(MapNum).Npc(Victim).Num

        If aNpcNum <= 0 Then Exit Function
        If vNpcNum <= 0 Then Exit Function

        ' Make sure the npcs arent already dead
        If MapNpc(MapNum).Npc(Attacker).Vital(Vitals.HP) <= 0 Then
            Exit Function
        End If

        ' Make sure the npc isn't already dead
        If MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) <= 0 Then
            Exit Function
        End If

        ' Make sure npcs dont attack more then once a second
        If GetTickCount < MapNpc(MapNum).Npc(Attacker).AttackTimer + 1000 Then
            Exit Function
        End If

        MapNpc(MapNum).Npc(Attacker).AttackTimer = GetTickCount

        AttackerX = MapNpc(MapNum).Npc(Attacker).x
        AttackerY = MapNpc(MapNum).Npc(Attacker).y
        VictimX = MapNpc(MapNum).Npc(Victim).x
        VictimY = MapNpc(MapNum).Npc(Victim).y

        ' Check if at same coordinates
        If (VictimY + 1 = AttackerY) And (VictimX = AttackerX) Then
            CanNpcAttackNpc = True
        Else

            If (VictimY - 1 = AttackerY) And (VictimX = AttackerX) Then
                CanNpcAttackNpc = True
            Else

                If (VictimY = AttackerY) And (VictimX + 1 = AttackerX) Then
                    CanNpcAttackNpc = True
                Else

                    If (VictimY = AttackerY) And (VictimX - 1 = AttackerX) Then
                        CanNpcAttackNpc = True
                    End If
                End If
            End If
        End If

    End Function
    Sub NpcAttackNpc(ByVal MapNum As Long, ByVal Attacker As Long, ByVal Victim As Long, ByVal Damage As Long)
        Dim Buffer As ByteBuffer
        Dim aNpcNum As Long
        Dim vNpcNum As Long
        Dim n As Long

        If Attacker <= 0 Or Attacker > MAX_MAP_NPCS Then Exit Sub
        If Victim <= 0 Or Victim > MAX_MAP_NPCS Then Exit Sub

        If Damage <= 0 Then Exit Sub

        aNpcNum = MapNpc(MapNum).Npc(Attacker).Num
        vNpcNum = MapNpc(MapNum).Npc(Victim).Num

        If aNpcNum <= 0 Then Exit Sub
        If vNpcNum <= 0 Then Exit Sub

        ' Send this packet so they can see the person attacking
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SNpcAttack)
        Buffer.WriteLong(Attacker)
        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing

        If Damage >= MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) Then
            SendActionMsg(MapNum, "-" & Damage, BrightRed, 1, (MapNpc(MapNum).Npc(Victim).x * 32), (MapNpc(MapNum).Npc(Victim).y * 32))
            SendBlood(MapNum, MapNpc(MapNum).Npc(Victim).x, MapNpc(MapNum).Npc(Victim).y)

            ' npc is dead.
            'Call GlobalMsg(CheckGrammar(Trim$(Npc(vNpcNum).Name), 1) & " has been killed by " & CheckGrammar(Trim$(Npc(aNpcNum).Name)) & "!", BrightRed)

            ' Set NPC target to 0
            MapNpc(MapNum).Npc(Attacker).Target = 0
            MapNpc(MapNum).Npc(Attacker).TargetType = 0

            ' Drop the goods if they get it
            n = Int(Rnd() * Npc(vNpcNum).DropChance) + 1
            If n = 1 Then
                Call SpawnItem(Npc(vNpcNum).DropItem, Npc(vNpcNum).DropItemValue, MapNum, MapNpc(MapNum).Npc(Victim).x, MapNpc(MapNum).Npc(Victim).y)
            End If

            ' Reset victim's stuff so it dies in loop
            MapNpc(MapNum).Npc(Victim).Num = 0
            MapNpc(MapNum).Npc(Victim).SpawnWait = GetTickCount
            MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) = 0

            ' send npc death packet to map
            Buffer = New ByteBuffer
            Buffer.WriteLong(ServerPackets.SNpcDead)
            Buffer.WriteLong(Victim)
            SendDataToMap(MapNum, Buffer.ToArray())
            Buffer = Nothing
        Else
            ' npc not dead, just do the damage
            MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) = MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) - Damage
            ' Say damage
            SendActionMsg(MapNum, "-" & Damage, BrightRed, 1, (MapNpc(MapNum).Npc(Victim).x * 32), (MapNpc(MapNum).Npc(Victim).y * 32))
            SendBlood(MapNum, MapNpc(MapNum).Npc(Victim).x, MapNpc(MapNum).Npc(Victim).y)
        End If

    End Sub
    Function isInRange(ByVal range As Long, ByVal x1 As Long, ByVal y1 As Long, ByVal x2 As Long, ByVal y2 As Long) As Boolean
        Dim nVal As Long
        isInRange = False
        nVal = System.Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
        If nVal <= range Then isInRange = True
    End Function
End Module
