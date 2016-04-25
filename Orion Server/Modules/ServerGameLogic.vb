Module ServerGameLogic
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
        SpawnItemSlot(i, itemNum, ItemVal, MapNum, x, y)
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

        If oldSlot = 0 Or newSlot = 0 Then Exit Sub

        OldNum = GetPlayerInvItemNum(Index, oldSlot)
        OldValue = GetPlayerInvItemValue(Index, oldSlot)
        NewNum = GetPlayerInvItemNum(Index, newSlot)
        NewValue = GetPlayerInvItemValue(Index, newSlot)

        If OldNum = NewNum And Item(NewNum).Stackable = 1 Then ' same item, if we can stack it, lets do that :P
            SetPlayerInvItemNum(Index, newSlot, NewNum)
            SetPlayerInvItemValue(Index, newSlot, OldValue + NewValue)
            SetPlayerInvItemNum(Index, oldSlot, 0)
            SetPlayerInvItemValue(Index, oldSlot, 0)
        Else
            SetPlayerInvItemNum(Index, newSlot, OldNum)
            SetPlayerInvItemValue(Index, newSlot, OldValue)
            SetPlayerInvItemNum(Index, oldSlot, NewNum)
            SetPlayerInvItemValue(Index, oldSlot, NewValue)
        End If

        SendInventory(Index)
    End Sub

    Sub SpawnMapItems(ByVal MapNum As Long)
        Dim x As Long
        Dim y As Long

        ' Check for subscript out of range
        If MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Sub

        ' Spawn what we have
        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY

                ' Check if the tile type is an item or a saved tile incase someone drops something
                If (Map(MapNum).Tile(x, y).Type = TILE_TYPE_ITEM) Then

                    ' Check to see if its a currency and if they set the value to 0 set it to 1 automatically
                    If Item(Map(MapNum).Tile(x, y).Data1).Type = ITEM_TYPE_CURRENCY Or Item(Map(MapNum).Tile(x, y).Data1).Stackable = 1 And Map(MapNum).Tile(x, y).Data2 <= 0 Then
                        SpawnItem(Map(MapNum).Tile(x, y).Data1, 1, MapNum, x, y)
                    Else
                        SpawnItem(Map(MapNum).Tile(x, y).Data1, Map(MapNum).Tile(x, y).Data2, MapNum, x, y)
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

            MapNpc(MapNum).Npc(MapNpcNum).Dir = Int(Rnd() * 4)

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

End Module
