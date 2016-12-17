Module ServerPlayers
    ' //////////////////////
    ' // PLAYER FUNCTIONS //
    ' //////////////////////
    Function GetPlayerLogin(ByVal Index As Integer) As String
        GetPlayerLogin = Trim$(Player(Index).Login)
    End Function

    Function GetPlayerIP(ByVal Index As Integer) As String
        GetPlayerIP = ""
        GetPlayerIP = GetClientIP(Index)
    End Function

    Public Sub HandleUseChar(ByVal Index As Integer)
        If Not IsPlaying(Index) Then
            JoinGame(Index)
            Addlog(GetPlayerLogin(Index) & "/" & GetPlayerName(Index) & " has began playing " & Options.Game_Name & ".", PLAYER_LOG)
            TextAdd(GetPlayerLogin(Index) & "/" & GetPlayerName(Index) & " has began playing " & Options.Game_Name & ".")
        End If
    End Sub

    Function GetPlayerName(ByVal Index As Integer) As String
        GetPlayerName = ""
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerName = Trim$(Player(Index).Character(TempPlayer(Index).CurChar).Name)
    End Function

    Sub SetPlayerAccess(ByVal Index As Integer, ByVal Access As Integer)
        Player(Index).Access = Access
    End Sub

    Sub SetPlayerSprite(ByVal Index As Integer, ByVal Sprite As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Sprite = Sprite
    End Sub

    Function GetPlayerMaxVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer

        GetPlayerMaxVital = 0

        If Index > MAX_PLAYERS Then Exit Function

        Select Case Vital
            Case Vitals.HP
                GetPlayerMaxVital = (Player(Index).Character(TempPlayer(Index).CurChar).Level + (GetPlayerStat(Index, Stats.Vitality) \ 2) + Classes(Player(Index).Character(TempPlayer(Index).CurChar).Classes).Stat(Stats.Vitality)) * 2
            Case Vitals.MP
                GetPlayerMaxVital = (Player(Index).Character(TempPlayer(Index).CurChar).Level + (GetPlayerStat(Index, Stats.intelligence) \ 2) + Classes(Player(Index).Character(TempPlayer(Index).CurChar).Classes).Stat(Stats.intelligence)) * 2
            Case Vitals.SP
                GetPlayerMaxVital = (Player(Index).Character(TempPlayer(Index).CurChar).Level + (GetPlayerStat(Index, Stats.Speed) \ 2) + Classes(Player(Index).Character(TempPlayer(Index).CurChar).Classes).Stat(Stats.Speed)) * 2
        End Select

    End Function

    Public Function GetPlayerStat(ByVal Index As Integer, ByVal Stat As Stats) As Integer
        Dim x As Integer, i As Integer

        GetPlayerStat = 0

        If Index > MAX_PLAYERS Then Exit Function

        x = Player(Index).Character(TempPlayer(Index).CurChar).Stat(Stat)

        For i = 1 To EquipmentType.Count - 1
            If Player(Index).Character(TempPlayer(Index).CurChar).Equipment(i) > 0 Then
                If Item(Player(Index).Character(TempPlayer(Index).CurChar).Equipment(i)).Add_Stat(Stat) > 0 Then
                    x = x + Item(Player(Index).Character(TempPlayer(Index).CurChar).Equipment(i)).Add_Stat(Stat)
                End If
            End If
        Next

        GetPlayerStat = x
    End Function

    Function GetPlayerAccess(ByVal Index As Integer) As Integer
        GetPlayerAccess = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerAccess = Player(Index).Access
    End Function

    Function GetPlayerMap(ByVal Index As Integer) As Integer
        GetPlayerMap = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerMap = Player(Index).Character(TempPlayer(Index).CurChar).Map
    End Function

    Function GetPlayerX(ByVal Index As Integer) As Integer
        GetPlayerX = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerX = Player(Index).Character(TempPlayer(Index).CurChar).x
    End Function

    Function GetPlayerY(ByVal Index As Integer) As Integer
        GetPlayerY = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerY = Player(Index).Character(TempPlayer(Index).CurChar).y
    End Function

    Sub SendLeaveMap(ByVal Index As Integer, ByVal MapNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SLeftMap)
        Buffer.WriteInteger(Index)
        SendDataToMapBut(Index, MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub PlayerWarp(ByVal Index As Integer, ByVal MapNum As Integer, ByVal x As Integer, ByVal y As Integer, Optional HouseTeleport As Boolean = False)
        Dim OldMap As Integer
        Dim i As Integer
        Dim Buffer As ByteBuffer

        If (MapNum And INSTANCED_MAP_MASK) > 0 Then
            MapNum = CreateInstance(MapNum And MAP_NUMBER_MASK)
            If MapNum = -1 Then
                'Couldn't create instanced map!
                MapNum = GetPlayerMap(Index)
                x = GetPlayerX(Index)
                y = GetPlayerY(Index)
                AlertMsg(Index, "Unable to create a cached map!")
            Else
                MapNum = MapNum + MAX_MAPS
            End If
        End If

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or MapNum <= 0 Or MapNum > MAX_CACHED_MAPS Then Exit Sub

        ' Check if you are out of bounds
        If x > Map(MapNum).MaxX Then x = Map(MapNum).MaxX
        If y > Map(MapNum).MaxY Then y = Map(MapNum).MaxY

        TempPlayer(Index).EventProcessingCount = 0
        TempPlayer(Index).EventMap.CurrentEvents = 0

        If HouseTeleport = False Then
            Player(Index).Character(TempPlayer(Index).CurChar).InHouse = 0
        End If

        If Player(Index).Character(TempPlayer(Index).CurChar).InHouse > 0 Then
            If IsPlaying(Player(Index).Character(TempPlayer(Index).CurChar).InHouse) Then
                If Player(Index).Character(TempPlayer(Index).CurChar).InHouse <> Player(Index).Character(TempPlayer(Index).CurChar).InHouse Then
                    Player(Index).Character(TempPlayer(Index).CurChar).InHouse = 0
                    PlayerWarp(Index, Player(Index).Character(TempPlayer(Index).CurChar).LastMap, Player(Index).Character(TempPlayer(Index).CurChar).LastX, Player(Index).Character(TempPlayer(Index).CurChar).LastY)
                    Exit Sub
                Else
                    SendFurnitureToHouse(Player(Index).Character(TempPlayer(Index).CurChar).InHouse)
                End If
            End If
        End If

        'clear target
        TempPlayer(Index).Target = 0
        TempPlayer(Index).TargetType = TargetType.None

        ' Save old map to send erase player data to
        OldMap = GetPlayerMap(Index)

        If OldMap <> MapNum Then
            SendLeaveMap(Index, OldMap)
        End If

        SetPlayerMap(Index, MapNum)
        SetPlayerX(Index, x)
        SetPlayerY(Index, y)

        ' send equipment of all people on new map
        If GetTotalMapPlayers(MapNum) > 0 Then
            For i = 1 To MAX_PLAYERS
                If IsPlaying(i) Then
                    If GetPlayerMap(i) = MapNum Then
                        SendMapEquipmentTo(i, Index)
                    End If
                End If
            Next
        End If

        ' Now we check if there were any players left on the map the player just left, and if not stop processing npcs
        If GetTotalMapPlayers(OldMap) = 0 Then
            PlayersOnMap(OldMap) = False

            If IsInstancedMap(OldMap) Then
                DestroyInstancedMap(OldMap - MAX_MAPS)
            End If

            ' Regenerate all NPCs' health
            For i = 1 To MAX_MAP_NPCS

                If MapNpc(OldMap).Npc(i).Num > 0 Then
                    MapNpc(OldMap).Npc(i).Vital(Vitals.HP) = GetNpcMaxVital(MapNpc(OldMap).Npc(i).Num, Vitals.HP)
                End If

            Next

        End If

        ' Sets it so we know to process npcs on the map
        PlayersOnMap(MapNum) = True
        TempPlayer(Index).GettingMap = True

        CheckTasks(Index, QUEST_TYPE_GOREACH, MapNum)

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SCheckForMap)
        Buffer.WriteInteger(MapNum)
        Buffer.WriteInteger(Map(MapNum).Revision)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing

    End Sub

    Function GetPlayerDir(ByVal Index As Integer) As Integer
        GetPlayerDir = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerDir = Player(Index).Character(TempPlayer(Index).CurChar).Dir
    End Function

    Function GetPlayerSprite(ByVal Index As Integer) As Integer
        GetPlayerSprite = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerSprite = Player(Index).Character(TempPlayer(Index).CurChar).Sprite
    End Function

    Function GetPlayerPK(ByVal Index As Integer) As Integer
        GetPlayerPK = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPK = Player(Index).Character(TempPlayer(Index).CurChar).PK
    End Function

    Sub CheckEquippedItems(ByVal Index As Integer)
        Dim itemNum As Integer
        Dim i As Integer

        ' We want to check incase an admin takes away an object but they had it equipped
        For i = 1 To EquipmentType.Count - 1
            itemNum = GetPlayerEquipment(Index, i)

            If itemNum > 0 Then

                Select Case i
                    Case EquipmentType.Weapon

                        If Item(itemNum).SubType <> EquipmentType.Weapon Then SetPlayerEquipment(Index, 0, i)
                    Case EquipmentType.Armor

                        If Item(itemNum).SubType <> EquipmentType.Armor Then SetPlayerEquipment(Index, 0, i)
                    Case EquipmentType.Helmet

                        If Item(itemNum).SubType <> EquipmentType.Helmet Then SetPlayerEquipment(Index, 0, i)
                    Case EquipmentType.Shield

                        If Item(itemNum).SubType <> EquipmentType.Shield Then SetPlayerEquipment(Index, 0, i)
                    Case EquipmentType.Shoes

                        If Item(itemNum).SubType <> EquipmentType.Shoes Then SetPlayerEquipment(Index, 0, i)
                    Case EquipmentType.Gloves

                        If Item(itemNum).SubType <> EquipmentType.Gloves Then SetPlayerEquipment(Index, 0, i)
                End Select

            Else
                SetPlayerEquipment(Index, 0, i)
            End If

        Next

    End Sub

    Function GetPlayerEquipment(ByVal Index As Integer, ByVal EquipmentSlot As EquipmentType) As Byte
        GetPlayerEquipment = 0
        If Index > MAX_PLAYERS Then Exit Function
        If EquipmentSlot = 0 Then Exit Function
        GetPlayerEquipment = Player(Index).Character(TempPlayer(Index).CurChar).Equipment(EquipmentSlot)
    End Function

    Sub SetPlayerEquipment(ByVal Index As Integer, ByVal InvNum As Integer, ByVal EquipmentSlot As EquipmentType)
        Player(Index).Character(TempPlayer(Index).CurChar).Equipment(EquipmentSlot) = InvNum
    End Sub

    Sub JoinGame(ByVal Index As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        ' Set the flag so we know the person is in the game
        TempPlayer(Index).InGame = True

        ' Send a global message that he/she joined
        If GetPlayerAccess(Index) <= AdminType.Monitor Then
            GlobalMsg(GetPlayerName(Index) & " has joined " & Options.Game_Name & "!")
        Else
            GlobalMsg(GetPlayerName(Index) & " has joined " & Options.Game_Name & "!")
        End If

        'Update the log
        ' Send an ok to client to start receiving in game data
        SendLoginOk(Index)
        TotalPlayersOnline = TotalPlayersOnline + 1
        ' Send some more little goodies, no need to explain these
        CheckEquippedItems(Index)

        SendGameData(Index)

        SendInventory(Index)
        SendWornEquipment(Index)
        SendMapEquipment(Index)

        'projectiles
        SendProjectiles(Index)

        For i = 1 To Vitals.Count - 1
            SendVital(Index, i)
        Next

        SendExp(Index)

        'Housing
        If Player(Index).Character(TempPlayer(Index).CurChar).InHouse Then
            Player(Index).Character(TempPlayer(Index).CurChar).InHouse = 0
            Player(Index).Character(TempPlayer(Index).CurChar).x = Player(Index).Character(TempPlayer(Index).CurChar).LastX
            Player(Index).Character(TempPlayer(Index).CurChar).y = Player(Index).Character(TempPlayer(Index).CurChar).LastY
            Player(Index).Character(TempPlayer(Index).CurChar).Map = Player(Index).Character(TempPlayer(Index).CurChar).LastMap
        End If
        SendHouseConfigs(Index)

        'quests
        SendQuests(Index)
        SendPlayerQuests(Index)
        SendMapNames(Index)

        'hotbar
        SendHotbar(Index)
        SendPlayerSkills(Index)

        'craft
        SendRecipes(Index)

        SendStats(Index)
        SendJoinMap(Index)

        ' Warp the player to his saved location
        PlayerWarp(Index, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))

        ' Send welcome messages
        SendWelcome(Index)

        ' Send Resource cache
        For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count
            SendResourceCacheTo(Index, i)
        Next

        ' Send the flag so they know they can start doing stuff
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SInGame)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub LeftGame(ByVal Index As Integer)
        Dim i As Integer
        Dim tradeTarget As Integer
        Dim instanceMapID As Integer
        instanceMapID = -1

        If TempPlayer(Index).InGame Then
            TempPlayer(Index).InGame = False

            ' Check if player was the only player on the map and stop npc processing if so
            If GetPlayerMap(Index) > 0 Then
                If GetTotalMapPlayers(GetPlayerMap(Index)) < 1 Then
                    PlayersOnMap(GetPlayerMap(Index)) = False
                    If IsInstancedMap(GetPlayerMap(Index)) Then
                        instanceMapID = InstancedMaps(GetPlayerMap(Index) - MAX_MAPS).OriginalMap
                        DestroyInstancedMap(GetPlayerMap(Index) - MAX_MAPS)
                    End If
                End If
                If instanceMapID > 0 Then
                    SetPlayerMap(Index, instanceMapID)
                End If
            End If

            ' Check if the player was in a party, and if so cancel it out so the other player doesn't continue to get half exp
            ' leave party.
            Party_PlayerLeave(Index)

            ' cancel any trade they're in
            If TempPlayer(Index).InTrade > 0 Then
                tradeTarget = TempPlayer(Index).InTrade
                PlayerMsg(tradeTarget, Trim$(GetPlayerName(Index)) & " has declined the trade.", ColorType.BrightRed)
                ' clear out trade
                For i = 1 To MAX_INV
                    TempPlayer(tradeTarget).TradeOffer(i).Num = 0
                    TempPlayer(tradeTarget).TradeOffer(i).Value = 0
                Next
                TempPlayer(tradeTarget).InTrade = 0
                SendCloseTrade(tradeTarget)
            End If

            SavePlayer(Index)
            SaveBank(Index)
            ClearBank(Index)

            ' Send a global message that he/she left
            If GetPlayerAccess(Index) <= AdminType.Monitor Then
                GlobalMsg(GetPlayerName(Index) & " has left " & Options.Game_Name & "!")
            Else
                GlobalMsg(GetPlayerName(Index) & " has left " & Options.Game_Name & "!")
            End If

            TextAdd(GetPlayerName(Index) & " has disconnected from " & Options.Game_Name & ".")
            SendLeftGame(Index)

            TotalPlayersOnline = TotalPlayersOnline - 1
            TempPlayer(Index) = Nothing
            ReDim TempPlayer(i).SkillCD(0 To MAX_PLAYER_SKILLS)
            ReDim TempPlayer(i).TradeOffer(0 To MAX_INV)
        End If

        ClearPlayer(Index)
    End Sub

    Sub PlayerMove(ByVal Index As Integer, ByVal Dir As Integer, ByVal movement As Integer, expectingwarp As Boolean)
        Dim MapNum As Integer, Buffer As ByteBuffer
        Dim x As Integer, y As Integer, begineventprocessing As Boolean
        Dim Moved As Byte, DidWarp As Boolean
        Dim NewMapX As Byte, NewMapY As Byte
        Dim VitalType As Integer, Colour As Integer, amount As Integer

        'Debug.Print("Server-PlayerMove")

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Dir < Direction.Up Or Dir > Direction.Right Or movement < 1 Or movement > 2 Then
            Exit Sub
        End If

        SetPlayerDir(Index, Dir)
        Moved = False
        MapNum = GetPlayerMap(Index)

        Select Case Dir
            Case Direction.Up

                ' Check to make sure not outside of boundries
                If GetPlayerY(Index) > 0 Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, Direction.Up + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type <> TileType.Blocked Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type <> TileType.Resource Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type <> TileType.Key Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type = TileType.Key And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index), GetPlayerY(Index) - 1) = True) Then
                                    SetPlayerY(Index, GetPlayerY(Index) - 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = True
                                End If
                            End If
                        End If
                    End If

                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Up > 0 Then
                        NewMapY = Map(Map(GetPlayerMap(Index)).Up).MaxY
                        PlayerWarp(Index, Map(GetPlayerMap(Index)).Up, GetPlayerX(Index), NewMapY)
                        DidWarp = True
                        Moved = True
                    End If
                End If

            Case Direction.Down

                ' Check to make sure not outside of boundries
                If GetPlayerY(Index) < Map(MapNum).MaxY Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, Direction.Down + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type <> TileType.Blocked Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type <> TileType.Resource Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type <> TileType.Key Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type = TileType.Key And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index), GetPlayerY(Index) + 1) = True) Then
                                    Call SetPlayerY(Index, GetPlayerY(Index) + 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = True
                                End If
                            End If
                        End If
                    End If

                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Down > 0 Then
                        PlayerWarp(Index, Map(GetPlayerMap(Index)).Down, GetPlayerX(Index), 0)
                        DidWarp = True
                        Moved = True
                    End If
                End If

            Case Direction.Left

                ' Check to make sure not outside of boundries
                If GetPlayerX(Index) > 0 Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, Direction.Left + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type <> TileType.Blocked Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type <> TileType.Resource Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type <> TileType.Key Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type = TileType.Key And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index) - 1, GetPlayerY(Index)) = True) Then
                                    SetPlayerX(Index, GetPlayerX(Index) - 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = True
                                End If
                            End If
                        End If
                    End If

                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Left > 0 Then
                        NewMapX = Map(Map(GetPlayerMap(Index)).Left).MaxX
                        PlayerWarp(Index, Map(GetPlayerMap(Index)).Left, NewMapX, GetPlayerY(Index))
                        DidWarp = True
                        Moved = True
                    End If
                End If

            Case Direction.Right

                ' Check to make sure not outside of boundries
                If GetPlayerX(Index) < Map(MapNum).MaxX Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, Direction.Right + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type <> TileType.Blocked Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type <> TileType.Resource Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type <> TileType.Key Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type = TileType.Key And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index) + 1, GetPlayerY(Index)) = True) Then
                                    SetPlayerX(Index, GetPlayerX(Index) + 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = True
                                End If
                            End If
                        End If
                    End If


                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Right > 0 Then
                        PlayerWarp(Index, Map(GetPlayerMap(Index)).Right, 0, GetPlayerY(Index))
                        DidWarp = True
                        Moved = True
                    End If
                End If
        End Select

        With Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index))
            ' Check to see if the tile is a warp tile, and if so warp them
            If .Type = TileType.Warp Then
                MapNum = .Data1
                x = .Data2
                y = .Data3

                If (MapNum And INSTANCED_MAP_MASK) > 0 Then
                    If TempPlayer(Index).InParty Then
                        PartyWarp(Index, MapNum, x, y)
                    Else
                        PlayerWarp(Index, MapNum, x, y)
                    End If
                Else
                    PlayerWarp(Index, MapNum, x, y)
                End If

                DidWarp = True
                Moved = True
            End If

            ' Check to see if the tile is a door tile, and if so warp them
            If .Type = TileType.Door Then
                MapNum = .Data1
                x = .Data2
                y = .Data3
                ' send the animation to the map
                SendDoorAnimation(GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))

                If (MapNum And INSTANCED_MAP_MASK) > 0 Then
                    If TempPlayer(Index).InParty Then
                        PartyWarp(Index, MapNum, x, y)
                    Else
                        PlayerWarp(Index, MapNum, x, y)
                    End If
                Else
                    PlayerWarp(Index, MapNum, x, y)
                End If
                DidWarp = True
                Moved = True
            End If

            ' Check for key trigger open
            If .Type = TileType.KeyOpen Then
                x = .Data1
                y = .Data2

                If Map(GetPlayerMap(Index)).Tile(x, y).Type = TileType.Key And TempTile(GetPlayerMap(Index)).DoorOpen(x, y) = False Then
                    TempTile(GetPlayerMap(Index)).DoorOpen(x, y) = True
                    TempTile(GetPlayerMap(Index)).DoorTimer = GetTickCount()
                    SendMapKey(Index, x, y, 1)
                    MapMsg(GetPlayerMap(Index), "A door has been unlocked.", ColorType.White)
                End If
            End If

            ' Check for a shop, and if so open it
            If .Type = TileType.Shop Then
                x = .Data1
                If x > 0 Then ' shop exists?
                    If Len(Trim$(Shop(x).Name)) > 0 Then ' name exists?
                        SendOpenShop(Index, x)
                        TempPlayer(Index).InShop = x ' stops movement and the like
                    End If
                End If
            End If

            ' Check to see if the tile is a bank, and if so send bank
            If .Type = TileType.Bank Then
                SendBank(Index)
                TempPlayer(Index).InBank = True
                Moved = True
            End If

            ' Check if it's a heal tile
            If .Type = TileType.Heal Then
                VitalType = .Data1
                amount = .Data2
                If Not GetPlayerVital(Index, VitalType) = GetPlayerMaxVital(Index, VitalType) Then
                    If VitalType = Enums.Vitals.HP Then
                        Colour = ColorType.BrightGreen
                    Else
                        Colour = ColorType.BrightBlue
                    End If
                    SendActionMsg(GetPlayerMap(Index), "+" & amount, Colour, ActionMsgType.Scroll, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32, 1)
                    SetPlayerVital(Index, VitalType, GetPlayerVital(Index, VitalType) + amount)
                    PlayerMsg(Index, "You feel rejuvinating forces flowing through your body.", ColorType.BrightGreen)
                    SendVital(Index, VitalType)
                    ' send vitals to party if in one
                    If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)
                End If
                Moved = True
            End If

            ' Check if it's a trap tile
            If .Type = TileType.Trap Then
                amount = .Data1
                SendActionMsg(GetPlayerMap(Index), "-" & amount, ColorType.BrightRed, ActionMsgType.Scroll, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32, 1)
                If GetPlayerVital(Index, Enums.Vitals.HP) - amount <= 0 Then
                    KillPlayer(Index)
                    PlayerMsg(Index, "You're killed by a trap.", ColorType.BrightRed)
                Else
                    SetPlayerVital(Index, Enums.Vitals.HP, GetPlayerVital(Index, Enums.Vitals.HP) - amount)
                    PlayerMsg(Index, "You're injured by a trap.", ColorType.BrightRed)
                    SendVital(Index, Enums.Vitals.HP)
                    ' send vitals to party if in one
                    If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)
                End If
                Moved = True
            End If

            'Housing
            If .Type = TileType.House Then
                If Player(Index).Character(TempPlayer(Index).CurChar).House.HouseIndex = .Data1 Then
                    'Do warping and such to the player's house :/
                    Player(Index).Character(TempPlayer(Index).CurChar).LastMap = GetPlayerMap(Index)
                    Player(Index).Character(TempPlayer(Index).CurChar).LastX = GetPlayerX(Index)
                    Player(Index).Character(TempPlayer(Index).CurChar).LastY = GetPlayerY(Index)
                    Player(Index).Character(TempPlayer(Index).CurChar).InHouse = Index
                    SendDataTo(Index, PlayerData(Index))
                    PlayerWarp(Index, HouseConfig(Player(Index).Character(TempPlayer(Index).CurChar).House.HouseIndex).BaseMap, HouseConfig(Player(Index).Character(TempPlayer(Index).CurChar).House.HouseIndex).X, HouseConfig(Player(Index).Character(TempPlayer(Index).CurChar).House.HouseIndex).Y, True)
                    DidWarp = True
                    Exit Sub
                Else
                    'Send the buy sequence and see what happens. (To be recreated in events.)
                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ServerPackets.SBuyHouse)
                    Buffer.WriteInteger(.Data1)
                    SendDataTo(Index, Buffer.ToArray)
                    Buffer = Nothing
                    TempPlayer(Index).BuyHouseIndex = .Data1
                End If
            End If

            'crafting
            If .Type = TileType.Craft Then
                TempPlayer(Index).IsCrafting = True
                SendPlayerRecipes(Index)
                SendOpenCraft(Index)
                Moved = True
            End If

        End With

        If Moved = True Then
            If Player(Index).Character(TempPlayer(Index).CurChar).InHouse > 0 Then
                If Player(Index).Character(TempPlayer(Index).CurChar).x = HouseConfig(Player(Player(Index).Character(TempPlayer(Index).CurChar).InHouse).Character(TempPlayer(Index).CurChar).House.HouseIndex).X Then
                    If Player(Index).Character(TempPlayer(Index).CurChar).y = HouseConfig(Player(Player(Index).Character(TempPlayer(Index).CurChar).InHouse).Character(TempPlayer(Index).CurChar).House.HouseIndex).Y Then
                        PlayerWarp(Index, Player(Index).Character(TempPlayer(Index).CurChar).LastMap, Player(Index).Character(TempPlayer(Index).CurChar).LastX, Player(Index).Character(TempPlayer(Index).CurChar).LastY)
                        DidWarp = True
                    End If
                End If
            End If
        End If

        ' They tried to hack
        If Moved = False Or (expectingwarp And Not DidWarp) Then
            PlayerWarp(Index, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
        End If

        x = GetPlayerX(Index)
        y = GetPlayerY(Index)

        If Moved = True Then
            If TempPlayer(Index).EventMap.CurrentEvents > 0 Then
                For i = 1 To TempPlayer(Index).EventMap.CurrentEvents
                    If Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Globals = 1 Then
                        If Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).X = x And Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Y = y And Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(i).PageID).Trigger = 1 And TempPlayer(Index).EventMap.EventPages(i).Visible = 1 Then begineventprocessing = True
                    Else
                        If TempPlayer(Index).EventMap.EventPages(i).X = x And TempPlayer(Index).EventMap.EventPages(i).Y = y And Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(i).PageID).Trigger = 1 And TempPlayer(Index).EventMap.EventPages(i).Visible = 1 Then begineventprocessing = True
                    End If
                    begineventprocessing = False
                    If begineventprocessing = True Then
                        'Process this event, it is on-touch and everything checks out.
                        If Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(i).PageID).CommandListCount > 0 Then
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).Active = 1
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).ActionTimer = GetTickCount()
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).CurList = 1
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).CurSlot = 1
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).EventID = TempPlayer(Index).EventMap.EventPages(i).EventID
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).PageID = TempPlayer(Index).EventMap.EventPages(i).PageID
                            TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).WaitingForResponse = 0
                            ReDim TempPlayer(Index).EventProcessing(TempPlayer(Index).EventMap.EventPages(i).EventID).ListLeftOff(0 To Map(GetPlayerMap(Index)).Events(TempPlayer(Index).EventMap.EventPages(i).EventID).Pages(TempPlayer(Index).EventMap.EventPages(i).PageID).CommandListCount)
                        End If
                        begineventprocessing = False
                    End If
                Next
            End If
        End If

    End Sub

    Function HasItem(ByVal Index As Integer, ByVal itemNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then
                    HasItem = GetPlayerInvItemValue(Index, i)
                Else
                    HasItem = 1
                End If

                Exit Function
            End If

        Next

    End Function

    Function FindItemSlot(ByVal Index As Integer, ByVal itemNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                FindItemSlot = i
                Exit Function
            End If

        Next

    End Function

    Sub SetPlayerDir(ByVal Index As Integer, ByVal Dir As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Dir = Dir
    End Sub

    Sub SetPlayerVital(ByVal Index As Integer, ByVal Vital As Vitals, ByVal Value As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Vital(Vital) = Value

        If GetPlayerVital(Index, Vital) > GetPlayerMaxVital(Index, Vital) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Vital(Vital) = GetPlayerMaxVital(Index, Vital)
        End If

        If GetPlayerVital(Index, Vital) < 0 Then
            Player(Index).Character(TempPlayer(Index).CurChar).Vital(Vital) = 0
        End If

    End Sub

    Public Function isDirBlocked(ByRef blockvar As Byte, ByRef Dir As Byte) As Boolean
        If Not blockvar And (2 ^ Dir) Then
            isDirBlocked = False
        Else
            isDirBlocked = True
        End If
    End Function

    Function GetPlayerVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer
        GetPlayerVital = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerVital = Player(Index).Character(TempPlayer(Index).CurChar).Vital(Vital)
    End Function

    Function GetPlayerLevel(ByVal Index As Integer) As Integer
        GetPlayerLevel = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerLevel = Player(Index).Character(TempPlayer(Index).CurChar).Level
    End Function

    Function GetPlayerPOINTS(ByVal Index As Integer) As Integer
        GetPlayerPOINTS = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPOINTS = Player(Index).Character(TempPlayer(Index).CurChar).POINTS
    End Function

    Function GetPlayerNextLevel(ByVal Index As Integer) As Integer
        GetPlayerNextLevel = ((GetPlayerLevel(Index) + 1) * (GetPlayerStat(Index, Stats.Strength) + GetPlayerStat(Index, Stats.Endurance) + GetPlayerStat(Index, Stats.Intelligence) + GetPlayerStat(Index, Stats.Speed) + GetPlayerPOINTS(Index)) + StatPtsPerLvl) * Classes(GetPlayerClass(Index)).BaseExp '25
    End Function

    Function GetPlayerExp(ByVal Index As Integer) As Integer
        GetPlayerExp = Player(Index).Character(TempPlayer(Index).CurChar).exp
    End Function

    Sub SetPlayerMap(ByVal Index As Integer, ByVal MapNum As Integer)
        If MapNum > 0 And MapNum <= MAX_CACHED_MAPS Then
            Player(Index).Character(TempPlayer(Index).CurChar).Map = MapNum
        End If
    End Sub

    Sub SetPlayerX(ByVal Index As Integer, ByVal x As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).x = x
    End Sub

    Sub SetPlayerY(ByVal Index As Integer, ByVal y As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).y = y
    End Sub

    Function GetPlayerInvItemNum(ByVal Index As Integer, ByVal invSlot As Integer) As Integer
        GetPlayerInvItemNum = 0
        If Index > MAX_PLAYERS Then Exit Function
        If invSlot = 0 Then Exit Function

        GetPlayerInvItemNum = Player(Index).Character(TempPlayer(Index).CurChar).Inv(invSlot).Num
    End Function

    Function GetPlayerInvItemValue(ByVal Index As Integer, ByVal invSlot As Integer) As Integer
        GetPlayerInvItemValue = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerInvItemValue = Player(Index).Character(TempPlayer(Index).CurChar).Inv(invSlot).Value
    End Function

    Sub SetPlayerExp(ByVal Index As Integer, ByVal exp As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).exp = exp
    End Sub

    Public Function GetPlayerRawStat(ByVal Index As Integer, ByVal Stat As Stats) As Integer
        GetPlayerRawStat = 0
        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerRawStat = Player(Index).Character(TempPlayer(Index).CurChar).Stat(Stat)
    End Function

    Public Sub SetPlayerStat(ByVal Index As Integer, ByVal Stat As Stats, ByVal Value As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Stat(Stat) = Value
    End Sub

    Sub SetPlayerLevel(ByVal Index As Integer, ByVal Level As Integer)

        If Level > MAX_LEVELS Then Exit Sub
        Player(Index).Character(TempPlayer(Index).CurChar).Level = Level
    End Sub

    Sub SetPlayerPOINTS(ByVal Index As Integer, ByVal POINTS As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).POINTS = POINTS
    End Sub

    Sub CheckPlayerLevelUp(ByVal Index As Integer)
        Dim expRollover As Integer
        Dim level_count As Integer

        level_count = 0

        Do While GetPlayerExp(Index) >= GetPlayerNextLevel(Index)
            expRollover = GetPlayerExp(Index) - GetPlayerNextLevel(Index)
            SetPlayerLevel(Index, GetPlayerLevel(Index) + 1)
            SetPlayerPOINTS(Index, GetPlayerPOINTS(Index) + 3)
            SetPlayerExp(Index, expRollover)
            level_count = level_count + 1
        Loop

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                GlobalMsg(GetPlayerName(Index) & " has gained " & level_count & " level!")
            Else
                'plural
                GlobalMsg(GetPlayerName(Index) & " has gained " & level_count & " levels!")
            End If
            SendExp(Index)
            SendPlayerData(Index)
        End If
    End Sub

    Sub PlayerMapGetItem(ByVal Index As Integer)
        Dim i As Integer
        Dim n As Integer
        Dim MapNum As Integer
        Dim Msg As String

        If Not IsPlaying(Index) Then Exit Sub
        MapNum = GetPlayerMap(Index)

        For i = 1 To MAX_MAP_ITEMS

            ' See if theres even an item here
            If (MapItem(MapNum, i).Num > 0) Then
                If (MapItem(MapNum, i).Num <= MAX_ITEMS) Then

                    ' Check if item is at the same location as the player
                    If (MapItem(MapNum, i).x = GetPlayerX(Index)) Then
                        If (MapItem(MapNum, i).y = GetPlayerY(Index)) Then
                            ' Find open slot
                            n = FindOpenInvSlot(Index, MapItem(MapNum, i).Num)

                            ' Open slot available?
                            If n <> 0 Then
                                ' Set item in players inventor
                                SetPlayerInvItemNum(Index, n, MapItem(MapNum, i).Num)

                                If Item(GetPlayerInvItemNum(Index, n)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(Index, n)).Stackable = 1 Then
                                    SetPlayerInvItemValue(Index, n, GetPlayerInvItemValue(Index, n) + MapItem(MapNum, i).Value)
                                    Msg = MapItem(MapNum, i).Value & " " & Trim$(Item(GetPlayerInvItemNum(Index, n)).Name)
                                Else
                                    SetPlayerInvItemValue(Index, n, 0)
                                    Msg = CheckGrammar(Trim$(Item(GetPlayerInvItemNum(Index, n)).Name), 1)
                                End If

                                ' Erase item from the map
                                MapItem(MapNum, i).Num = 0
                                MapItem(MapNum, i).Value = 0
                                MapItem(MapNum, i).x = 0
                                MapItem(MapNum, i).y = 0

                                SendInventoryUpdate(Index, n)
                                SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), 0, 0)

                                SendActionMsg(GetPlayerMap(Index), Msg, ColorType.White, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                                CheckTasks(Index, QUEST_TYPE_GOGATHER, GetItemNum(Trim$(Item(GetPlayerInvItemNum(Index, n)).Name)))
                                Exit For
                            Else
                                PlayerMsg(Index, "Your inventory is full.", ColorType.BrightRed)
                                Exit For
                            End If
                        End If
                    End If
                End If
            End If

        Next

    End Sub

    Sub SetPlayerInvItemValue(ByVal Index As Integer, ByVal invSlot As Integer, ByVal ItemValue As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Inv(invSlot).Value = ItemValue
    End Sub

    Sub SetPlayerInvItemNum(ByVal Index As Integer, ByVal invSlot As Integer, ByVal itemNum As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Inv(invSlot).Num = itemNum
    End Sub

    Function FindOpenInvSlot(ByVal Index As Integer, ByVal itemNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then

            ' If currency then check to see if they already have an instance of the item and add it to that
            For i = 1 To MAX_INV

                If GetPlayerInvItemNum(Index, i) = itemNum Then
                    FindOpenInvSlot = i
                    Exit Function
                End If

            Next

        End If

        For i = 1 To MAX_INV

            ' Try to find an open free slot
            If GetPlayerInvItemNum(Index, i) = 0 Then
                FindOpenInvSlot = i
                Exit Function
            End If

        Next

    End Function

    Function TakeInvItem(ByVal Index As Integer, ByVal itemNum As Integer, ByVal ItemVal As Integer) As Boolean
        Dim i As Integer

        TakeInvItem = False

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then

                    ' Is what we are trying to take away more then what they have?  If so just set it to zero
                    If ItemVal >= GetPlayerInvItemValue(Index, i) Then
                        TakeInvItem = True
                    Else
                        SetPlayerInvItemValue(Index, i, GetPlayerInvItemValue(Index, i) - ItemVal)
                        SendInventoryUpdate(Index, i)
                    End If
                Else
                    TakeInvItem = True
                End If

                If TakeInvItem Then
                    SetPlayerInvItemNum(Index, i, 0)
                    SetPlayerInvItemValue(Index, i, 0)
                    ' Send the inventory update
                    SendInventoryUpdate(Index, i)
                    Exit Function
                End If
            End If

        Next

    End Function

    Function GiveInvItem(ByVal Index As Integer, ByVal itemNum As Integer, ByVal ItemVal As Integer, Optional ByVal sendUpdate As Boolean = True) As Boolean
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            GiveInvItem = False
            Exit Function
        End If

        i = FindOpenInvSlot(Index, itemNum)

        ' Check to see if inventory is full
        If i <> 0 Then
            SetPlayerInvItemNum(Index, i, itemNum)
            SetPlayerInvItemValue(Index, i, GetPlayerInvItemValue(Index, i) + ItemVal)
            If sendUpdate Then SendInventoryUpdate(Index, i)
            GiveInvItem = True
        Else
            Call PlayerMsg(Index, "Your inventory is full.", ColorType.BrightRed)
            GiveInvItem = False
        End If

    End Function

    Function GetPlayerClass(ByVal Index As Integer) As Integer
        GetPlayerClass = Player(Index).Character(TempPlayer(Index).CurChar).Classes
    End Function

    Function FindOpenSkillSlot(ByVal Index As Integer) As Integer
        Dim i As Integer

        For i = 1 To MAX_PLAYER_SKILLS

            If GetPlayerSkill(Index, i) = 0 Then
                FindOpenSkillSlot = i
                Exit Function
            End If

        Next

    End Function

    Function GetPlayerSkill(ByVal Index As Integer, ByVal skillslot As Integer) As Integer
        GetPlayerSkill = 0
        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerSkill = Player(Index).Character(TempPlayer(Index).CurChar).Skill(skillslot)
    End Function

    Function HasSkill(ByVal Index As Integer, ByVal skillnum As Integer) As Boolean
        Dim i As Integer

        For i = 1 To MAX_PLAYER_SKILLS

            If GetPlayerSkill(Index, i) = skillnum Then
                HasSkill = True
                Exit Function
            End If

        Next

    End Function

    Sub SetPlayerSkill(ByVal Index As Integer, ByVal skillslot As Integer, ByVal skillnum As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Skill(skillslot) = skillnum
    End Sub

    Sub PlayerMapDropItem(ByVal Index As Integer, ByVal InvNum As Integer, ByVal amount As Integer)
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or InvNum <= 0 Or InvNum > MAX_INV Then
            Exit Sub
        End If

        ' check the player isn't doing something
        If TempPlayer(Index).InBank Or TempPlayer(Index).InShop Or TempPlayer(Index).InTrade > 0 Then Exit Sub

        If (GetPlayerInvItemNum(Index, InvNum) > 0) Then
            If (GetPlayerInvItemNum(Index, InvNum) <= MAX_ITEMS) Then
                i = FindOpenMapItemSlot(GetPlayerMap(Index))

                If i <> 0 Then
                    MapItem(GetPlayerMap(Index), i).Num = GetPlayerInvItemNum(Index, InvNum)
                    MapItem(GetPlayerMap(Index), i).x = GetPlayerX(Index)
                    MapItem(GetPlayerMap(Index), i).y = GetPlayerY(Index)

                    If Item(GetPlayerInvItemNum(Index, InvNum)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(Index, InvNum)).Stackable = 1 Then

                        ' Check if its more then they have and if so drop it all
                        If amount >= GetPlayerInvItemValue(Index, InvNum) Then
                            MapItem(GetPlayerMap(Index), i).Value = GetPlayerInvItemValue(Index, InvNum)
                            Call MapMsg(GetPlayerMap(Index), GetPlayerName(Index) & " drops " & GetPlayerInvItemValue(Index, InvNum) & " " & Trim$(Item(GetPlayerInvItemNum(Index, InvNum)).Name) & ".", ColorType.Yellow)
                            Call SetPlayerInvItemNum(Index, InvNum, 0)
                            Call SetPlayerInvItemValue(Index, InvNum, 0)
                        Else
                            MapItem(GetPlayerMap(Index), i).Value = amount
                            Call MapMsg(GetPlayerMap(Index), GetPlayerName(Index) & " drops " & amount & " " & Trim$(Item(GetPlayerInvItemNum(Index, InvNum)).Name) & ".", ColorType.Yellow)
                            Call SetPlayerInvItemValue(Index, InvNum, GetPlayerInvItemValue(Index, InvNum) - amount)
                        End If

                    Else
                        ' Its not a currency object so this is easy
                        MapItem(GetPlayerMap(Index), i).Value = 0
                        ' send message
                        Call MapMsg(GetPlayerMap(Index), GetPlayerName(Index) & " drops " & CheckGrammar(Trim$(Item(GetPlayerInvItemNum(Index, InvNum)).Name)) & ".", ColorType.Yellow)
                        Call SetPlayerInvItemNum(Index, InvNum, 0)
                        Call SetPlayerInvItemValue(Index, InvNum, 0)
                    End If

                    ' Send inventory update
                    Call SendInventoryUpdate(Index, InvNum)
                    ' Spawn the item before we set the num or we'll get a different free map item slot
                    Call SpawnItemSlot(i, MapItem(GetPlayerMap(Index), i).Num, amount, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
                Else
                    Call PlayerMsg(Index, "Too many items already on the ground.", ColorType.Yellow)
                End If
            End If
        End If

    End Sub

    Sub GiveBankItem(ByVal Index As Integer, ByVal invSlot As Integer, ByVal amount As Integer)
        Dim BankSlot

        If invSlot < 0 Or invSlot > MAX_INV Then
            Exit Sub
        End If

        If GetPlayerInvItemValue(Index, invSlot) < 0 Then Exit Sub
        If GetPlayerInvItemValue(Index, invSlot) < amount Then
            Exit Sub
        End If

        BankSlot = FindOpenBankSlot(Index, GetPlayerInvItemNum(Index, invSlot))

        If BankSlot > 0 Then
            If Item(GetPlayerInvItemNum(Index, invSlot)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(Index, invSlot)).Stackable = 1 Then
                If GetPlayerBankItemNum(Index, BankSlot) = GetPlayerInvItemNum(Index, invSlot) Then
                    Call SetPlayerBankItemValue(Index, BankSlot, GetPlayerBankItemValue(Index, BankSlot) + amount)
                    Call TakeInvItem(Index, GetPlayerInvItemNum(Index, invSlot), amount)
                Else
                    Call SetPlayerBankItemNum(Index, BankSlot, GetPlayerInvItemNum(Index, invSlot))
                    Call SetPlayerBankItemValue(Index, BankSlot, amount)
                    Call TakeInvItem(Index, GetPlayerInvItemNum(Index, invSlot), amount)
                End If
            Else
                If GetPlayerBankItemNum(Index, BankSlot) = GetPlayerInvItemNum(Index, invSlot) Then
                    Call SetPlayerBankItemValue(Index, BankSlot, GetPlayerBankItemValue(Index, BankSlot) + 1)
                    Call TakeInvItem(Index, GetPlayerInvItemNum(Index, invSlot), 0)
                Else
                    Call SetPlayerBankItemNum(Index, BankSlot, GetPlayerInvItemNum(Index, invSlot))
                    Call SetPlayerBankItemValue(Index, BankSlot, 1)
                    Call TakeInvItem(Index, GetPlayerInvItemNum(Index, invSlot), 0)
                End If
            End If
        End If

        SaveBank(Index)
        SavePlayer(Index)
        SendBank(Index)

    End Sub

    Function GetPlayerBankItemNum(ByVal Index As Integer, ByVal BankSlot As Byte) As Integer
        GetPlayerBankItemNum = Bank(Index).Item(BankSlot).Num
    End Function

    Sub SetPlayerBankItemNum(ByVal Index As Integer, ByVal BankSlot As Byte, ByVal itemNum As Integer)
        Bank(Index).Item(BankSlot).Num = itemNum
    End Sub

    Function GetPlayerBankItemValue(ByVal Index As Integer, ByVal BankSlot As Byte) As Integer
        GetPlayerBankItemValue = Bank(Index).Item(BankSlot).Value
    End Function

    Sub SetPlayerBankItemValue(ByVal Index As Integer, ByVal BankSlot As Byte, ByVal ItemValue As Integer)
        Bank(Index).Item(BankSlot).Value = ItemValue
    End Sub

    Function FindOpenBankSlot(ByVal Index As Integer, ByVal itemNum As Integer) As Byte
        Dim i As Integer

        If Not IsPlaying(Index) Then Exit Function
        If itemNum <= 0 Or itemNum > MAX_ITEMS Then Exit Function

        If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then
            For i = 1 To MAX_BANK
                If GetPlayerBankItemNum(Index, i) = itemNum Then
                    FindOpenBankSlot = i
                    Exit Function
                End If
            Next i
        End If

        For i = 1 To MAX_BANK
            If GetPlayerBankItemNum(Index, i) = 0 Then
                FindOpenBankSlot = i
                Exit Function
            End If
        Next i

    End Function

    Sub SetPlayerPK(ByVal Index As Integer, ByVal PK As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).PK = PK
    End Sub

    Sub TakeBankItem(ByVal Index As Integer, ByVal BankSlot As Integer, ByVal amount As Integer)
        Dim invSlot

        If BankSlot < 0 Or BankSlot > MAX_BANK Then
            Exit Sub
        End If

        If GetPlayerBankItemValue(Index, BankSlot) < 0 Then Exit Sub

        If GetPlayerBankItemValue(Index, BankSlot) < amount Then
            Exit Sub
        End If

        invSlot = FindOpenInvSlot(Index, GetPlayerBankItemNum(Index, BankSlot))

        If invSlot > 0 Then
            If Item(GetPlayerBankItemNum(Index, BankSlot)).Type = ItemType.Currency Or Item(GetPlayerBankItemNum(Index, BankSlot)).Stackable = 1 Then
                Call GiveInvItem(Index, GetPlayerBankItemNum(Index, BankSlot), amount)
                Call SetPlayerBankItemValue(Index, BankSlot, GetPlayerBankItemValue(Index, BankSlot) - amount)
                If GetPlayerBankItemValue(Index, BankSlot) <= 0 Then
                    Call SetPlayerBankItemNum(Index, BankSlot, 0)
                    Call SetPlayerBankItemValue(Index, BankSlot, 0)
                End If
            Else
                If GetPlayerBankItemValue(Index, BankSlot) > 1 Then
                    Call GiveInvItem(Index, GetPlayerBankItemNum(Index, BankSlot), 0)
                    Call SetPlayerBankItemValue(Index, BankSlot, GetPlayerBankItemValue(Index, BankSlot) - 1)
                Else
                    Call GiveInvItem(Index, GetPlayerBankItemNum(Index, BankSlot), 0)
                    Call SetPlayerBankItemNum(Index, BankSlot, 0)
                    Call SetPlayerBankItemValue(Index, BankSlot, 0)
                End If
            End If
        End If

        SaveBank(Index)
        SavePlayer(Index)
        SendBank(Index)

    End Sub

    Public Sub KillPlayer(ByVal Index As Integer)
        Dim exp As Integer

        ' Calculate exp to give attacker
        exp = GetPlayerExp(Index) \ 3

        ' Make sure we dont get less then 0
        If exp < 0 Then exp = 0
        If exp = 0 Then
            Call PlayerMsg(Index, "You lost no exp.", ColorType.BrightGreen)
        Else
            Call SetPlayerExp(Index, GetPlayerExp(Index) - exp)
            SendExp(Index)
            Call PlayerMsg(Index, "You lost " & exp & " exp.", ColorType.BrightRed)
        End If

        Call OnDeath(Index)
    End Sub

    Sub OnDeath(ByVal Index As Integer)
        Dim i As Integer

        ' Set HP to nothing
        SetPlayerVital(Index, Vitals.HP, 0)

        ' Drop all worn items
        For i = 1 To EquipmentType.Count - 1
            If GetPlayerEquipment(Index, i) > 0 Then
                PlayerMapDropItem(Index, GetPlayerEquipment(Index, i), 0)
            End If
        Next

        ' Warp player away
        SetPlayerDir(Index, Direction.Down)

        With Map(GetPlayerMap(Index))
            ' to the bootmap if it is set
            If .BootMap > 0 Then
                PlayerWarp(Index, .BootMap, .BootX, .BootY)
            Else
                PlayerWarp(Index, START_MAP, START_X, START_Y)
            End If
        End With

        ' Clear skill casting
        TempPlayer(Index).SkillBuffer = 0
        TempPlayer(Index).SkillBufferTimer = 0
        SendClearSkillBuffer(Index)

        ' Restore vitals
        SetPlayerVital(Index, Vitals.HP, GetPlayerMaxVital(Index, Vitals.HP))
        SetPlayerVital(Index, Vitals.MP, GetPlayerMaxVital(Index, Vitals.MP))
        SetPlayerVital(Index, Vitals.SP, GetPlayerMaxVital(Index, Vitals.SP))
        SendVital(Index, Vitals.HP)
        SendVital(Index, Vitals.MP)
        SendVital(Index, Vitals.SP)

        ' send vitals to party if in one
        If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

        ' If the player the attacker killed was a pk then take it away
        If GetPlayerPK(Index) = True Then
            SetPlayerPK(Index, False)
            SendPlayerData(Index)
        End If

    End Sub

    Function TakeInvSlot(ByVal Index As Integer, ByVal invSlot As Integer, ByVal ItemVal As Integer) As Boolean
        Dim itemNum

        TakeInvSlot = False

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or invSlot <= 0 Or invSlot > MAX_ITEMS Then Exit Function

        itemNum = GetPlayerInvItemNum(Index, invSlot)

        If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then

            ' Is what we are trying to take away more then what they have?  If so just set it to zero
            If ItemVal >= GetPlayerInvItemValue(Index, invSlot) Then
                TakeInvSlot = True
            Else
                SetPlayerInvItemValue(Index, invSlot, GetPlayerInvItemValue(Index, invSlot) - ItemVal)
            End If
        Else
            TakeInvSlot = True
        End If

        If TakeInvSlot Then
            SetPlayerInvItemNum(Index, invSlot, 0)
            SetPlayerInvItemValue(Index, invSlot, 0)
            Exit Function
        End If

    End Function

    Function GetPlayerVitalRegen(ByVal Index As Integer, ByVal Vital As Vitals) As Integer
        Dim i As Integer

        ' Prevent subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            GetPlayerVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                i = (GetPlayerStat(Index, Stats.Vitality) \ 2)
            Case Vitals.MP
                i = (GetPlayerStat(Index, Stats.Speed) \ 2)
            Case Vitals.SP
                i = (GetPlayerStat(Index, Stats.Speed) \ 2)
        End Select

        If i < 2 Then i = 2
        GetPlayerVitalRegen = i
    End Function


    Public Sub BufferSkill(ByVal Index As Integer, ByVal skillslot As Integer)
        Dim skillnum As Integer
        Dim MPCost As Integer
        Dim LevelReq As Integer
        Dim MapNum As Integer
        Dim SkillCastType As Integer
        Dim ClassReq As Integer
        Dim AccessReq As Integer
        Dim range As Integer
        Dim HasBuffered As Boolean

        Dim TargetType As TargetType
        Dim Target As Integer

        ' Prevent subscript out of range
        If skillslot <= 0 Or skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        skillnum = GetPlayerSkill(Index, skillslot)
        MapNum = GetPlayerMap(Index)

        If skillnum <= 0 Or skillnum > MAX_SKILLS Then Exit Sub

        ' Make sure player has the skill
        If Not HasSkill(Index, skillnum) Then Exit Sub

        ' see if cooldown has finished
        If TempPlayer(Index).SkillCD(skillslot) > GetTickCount() Then
            PlayerMsg(Index, "Skill hasn't cooled down yet!", ColorType.Yellow)
            Exit Sub
        End If

        MPCost = Skill(skillnum).MPCost

        ' Check if they have enough MP
        If GetPlayerVital(Index, Vitals.MP) < MPCost Then
            PlayerMsg(Index, "Not enough mana!", ColorType.Yellow)
            Exit Sub
        End If

        LevelReq = Skill(skillnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > GetPlayerLevel(Index) Then
            PlayerMsg(Index, "You must be level " & LevelReq & " to use this skill.", ColorType.BrightRed)
            Exit Sub
        End If

        AccessReq = Skill(skillnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(Index) Then
            PlayerMsg(Index, "You must be an administrator to use this skill.", ColorType.BrightRed)
            Exit Sub
        End If

        ClassReq = Skill(skillnum).ClassReq

        ' make sure the classreq > 0
        If ClassReq > 0 Then ' 0 = no req
            If ClassReq <> GetPlayerClass(Index) Then
                PlayerMsg(Index, "Only " & CheckGrammar(Trim$(Classes(ClassReq).Name)) & " can use this skill.", ColorType.Yellow)
                Exit Sub
            End If
        End If

        ' find out what kind of skill it is! self cast, target or AOE
        If Skill(skillnum).range > 0 Then
            ' ranged attack, single target or aoe?
            If Not Skill(skillnum).IsAoE Then
                SkillCastType = 2 ' targetted
            Else
                SkillCastType = 3 ' targetted aoe
            End If
        Else
            If Not Skill(skillnum).IsAoE Then
                SkillCastType = 0 ' self-cast
            Else
                SkillCastType = 1 ' self-cast AoE
            End If
        End If

        TargetType = TempPlayer(Index).TargetType
        Target = TempPlayer(Index).Target
        range = Skill(skillnum).range
        HasBuffered = False

        Select Case SkillCastType
            Case 0, 1 ' self-cast & self-cast AOE
                HasBuffered = True
            Case 2, 3 ' targeted & targeted AOE
                ' check if have target
                If Not Target > 0 Then
                    PlayerMsg(Index, "You do not have a target.", ColorType.BrightRed)
                End If
                If TargetType = TargetType.PLAYER Then
                    'Housing
                    If Player(Target).Character(TempPlayer(Target).CurChar).InHouse = Player(Index).Character(TempPlayer(Index).CurChar).InHouse Then
                        If CanAttackPlayer(Index, Target, True) Then
                            HasBuffered = True
                        End If
                    End If
                    ' if have target, check in range
                    If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), GetPlayerX(Target), GetPlayerY(Target)) Then
                        PlayerMsg(Index, "Target not in range.", ColorType.BrightRed)
                    Else
                        ' go through skill types
                        If Skill(skillnum).Type <> SkillType.DamageHp And Skill(skillnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanAttackPlayer(Index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                ElseIf TargetType = TargetType.NPC Then
                    ' if have target, check in range
                    If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), MapNpc(MapNum).Npc(Target).x, MapNpc(MapNum).Npc(Target).y) Then
                        PlayerMsg(Index, "Target not in range.", ColorType.BrightRed)
                        HasBuffered = False
                    Else
                        ' go through skill types
                        If Skill(skillnum).Type <> SkillType.DamageHp And Skill(skillnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanAttackNpc(Index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                End If
        End Select

        If HasBuffered Then
            SendAnimation(MapNum, Skill(skillnum).CastAnim, 0, 0, TargetType.PLAYER, Index)
            TempPlayer(Index).SkillBuffer = skillslot
            TempPlayer(Index).SkillBufferTimer = GetTickCount()
            Exit Sub
        Else
            SendClearSkillBuffer(Index)
        End If
    End Sub

    Public Sub UseItem(ByVal Index As Integer, ByVal InvNum As Integer)
        Dim InvItemNum As Integer, i As Integer, n As Integer, x As Integer, y As Integer, tempitem As Integer

        ' Prevent hacking
        If InvNum < 1 Or InvNum > MAX_ITEMS Then Exit Sub

        If (GetPlayerInvItemNum(Index, InvNum) > 0) And (GetPlayerInvItemNum(Index, InvNum) <= MAX_ITEMS) Then
            InvItemNum = GetPlayerInvItemNum(Index, InvNum)

            n = Item(InvItemNum).Data2

            ' Find out what kind of item it is
            Select Case Item(InvItemNum).Type
                Case ItemType.Equipment
                    For i = 1 To Stats.Count - 1
                        If GetPlayerStat(Index, i) < Item(InvItemNum).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.", ColorType.BrightRed)
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(InvItemNum).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(InvItemNum).ClassReq = GetPlayerClass(Index) And Not Item(InvItemNum).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    'if that went fine, we progress the subtype

                    Select Case Item(InvItemNum).SubType
                        Case EquipmentType.Weapon

                            If GetPlayerEquipment(Index, EquipmentType.Weapon) > 0 Then
                                tempitem = GetPlayerEquipment(Index, EquipmentType.Weapon)
                            End If

                            SetPlayerEquipment(Index, InvItemNum, EquipmentType.Weapon)
                            PlayerMsg(Index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                            TakeInvItem(Index, InvItemNum, 1)

                            If tempitem > 0 Then
                                GiveInvItem(Index, tempitem, 0) ' give back the stored item
                                tempitem = 0
                            End If

                            SendWornEquipment(Index)
                            SendMapEquipment(Index)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case EquipmentType.Armor

                            If GetPlayerEquipment(Index, EquipmentType.Armor) > 0 Then
                                tempitem = GetPlayerEquipment(Index, EquipmentType.Armor)
                            End If

                            SetPlayerEquipment(Index, InvItemNum, EquipmentType.Armor)
                            PlayerMsg(Index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                            TakeInvItem(Index, InvItemNum, 0)

                            If tempitem > 0 Then
                                GiveInvItem(Index, tempitem, 0) ' give back the stored item
                                tempitem = 0
                            End If

                            SendWornEquipment(Index)
                            SendMapEquipment(Index)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case EquipmentType.Helmet

                            If GetPlayerEquipment(Index, EquipmentType.Helmet) > 0 Then
                                tempitem = GetPlayerEquipment(Index, EquipmentType.Helmet)
                            End If

                            SetPlayerEquipment(Index, InvItemNum, EquipmentType.Helmet)
                            PlayerMsg(Index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                            TakeInvItem(Index, InvItemNum, 1)

                            If tempitem > 0 Then
                                GiveInvItem(Index, tempitem, 0) ' give back the stored item
                                tempitem = 0
                            End If

                            SendWornEquipment(Index)
                            SendMapEquipment(Index)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case EquipmentType.Shield
                            If GetPlayerEquipment(Index, EquipmentType.Shield) > 0 Then
                                tempitem = GetPlayerEquipment(Index, EquipmentType.Shield)
                            End If

                            SetPlayerEquipment(Index, InvItemNum, EquipmentType.Shield)
                            PlayerMsg(Index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                            TakeInvItem(Index, InvItemNum, 1)

                            If tempitem > 0 Then
                                GiveInvItem(Index, tempitem, 0) ' give back the stored item
                                tempitem = 0
                            End If

                            SendWornEquipment(Index)
                            SendMapEquipment(Index)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case EquipmentType.Shoes
                            If GetPlayerEquipment(Index, EquipmentType.Shoes) > 0 Then
                                tempitem = GetPlayerEquipment(Index, EquipmentType.Shoes)
                            End If

                            SetPlayerEquipment(Index, InvItemNum, EquipmentType.Shoes)
                            PlayerMsg(Index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                            TakeInvItem(Index, InvItemNum, 1)

                            If tempitem > 0 Then
                                GiveInvItem(Index, tempitem, 0) ' give back the stored item
                                tempitem = 0
                            End If

                            SendWornEquipment(Index)
                            SendMapEquipment(Index)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case EquipmentType.Gloves
                            If GetPlayerEquipment(Index, EquipmentType.Gloves) > 0 Then
                                tempitem = GetPlayerEquipment(Index, EquipmentType.Gloves)
                            End If

                            SetPlayerEquipment(Index, InvItemNum, EquipmentType.Gloves)
                            PlayerMsg(Index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                            TakeInvItem(Index, InvItemNum, 1)

                            If tempitem > 0 Then
                                GiveInvItem(Index, tempitem, 0) ' give back the stored item
                                tempitem = 0
                            End If

                            SendWornEquipment(Index)
                            SendMapEquipment(Index)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)
                    End Select

                Case ItemType.Consumable

                    For i = 1 To Stats.Count - 1
                        If GetPlayerStat(Index, i) < Item(InvItemNum).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.", ColorType.BrightRed)
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(InvItemNum).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(InvItemNum).ClassReq = GetPlayerClass(Index) And Not Item(InvItemNum).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    'if that went fine, we progress the subtype

                    Select Case Item(InvItemNum).SubType
                        Case ConsumableType.Hp
                            SendActionMsg(GetPlayerMap(Index), "+" & Item(InvItemNum).Data1, ColorType.BrightGreen, ActionMsgType.Scroll, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                            SendAnimation(GetPlayerMap(Index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, Index)
                            SetPlayerVital(Index, Vitals.HP, GetPlayerVital(Index, Vitals.HP) + Item(InvItemNum).Data1)
                            If Item(InvItemNum).Stackable = 1 Then
                                TakeInvItem(Index, InvItemNum, 1)
                            Else
                                TakeInvItem(Index, InvItemNum, 0)
                            End If
                            SendVital(Index, Vitals.HP)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case ConsumableType.Mp
                            SendActionMsg(GetPlayerMap(Index), "+" & Item(InvItemNum).Data1, ColorType.BrightBlue, ActionMsgType.Scroll, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                            SendAnimation(GetPlayerMap(Index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, Index)
                            SetPlayerVital(Index, Vitals.MP, GetPlayerVital(Index, Vitals.MP) + Item(InvItemNum).Data1)
                            If Item(InvItemNum).Stackable = 1 Then
                                TakeInvItem(Index, InvItemNum, 1)
                            Else
                                TakeInvItem(Index, InvItemNum, 0)
                            End If
                            SendVital(Index, Vitals.MP)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case ConsumableType.Mp
                            SendAnimation(GetPlayerMap(Index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, Index)
                            SetPlayerVital(Index, Vitals.SP, GetPlayerVital(Index, Vitals.SP) + Item(InvItemNum).Data1)
                            If Item(InvItemNum).Stackable = 1 Then
                                TakeInvItem(Index, InvItemNum, 1)
                            Else
                                TakeInvItem(Index, InvItemNum, 0)
                            End If
                            SendVital(Index, Vitals.SP)

                            ' send vitals to party if in one
                            If TempPlayer(Index).InParty > 0 Then SendPartyVitals(TempPlayer(Index).InParty, Index)

                        Case ConsumableType.Exp

                    End Select


                Case ItemType.Key
                    InvItemNum = GetPlayerInvItemNum(Index, InvNum)

                    For i = 1 To Stats.Count - 1
                        If GetPlayerStat(Index, i) < Item(InvItemNum).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.", ColorType.BrightRed)
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(InvItemNum).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(InvItemNum).ClassReq = GetPlayerClass(Index) And Not Item(InvItemNum).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    Select Case GetPlayerDir(Index)
                        Case Direction.Up

                            If GetPlayerY(Index) > 0 Then
                                x = GetPlayerX(Index)
                                y = GetPlayerY(Index) - 1
                            Else
                                Exit Sub
                            End If

                        Case Direction.Down

                            If GetPlayerY(Index) < Map(GetPlayerMap(Index)).MaxY Then
                                x = GetPlayerX(Index)
                                y = GetPlayerY(Index) + 1
                            Else
                                Exit Sub
                            End If

                        Case Direction.Left

                            If GetPlayerX(Index) > 0 Then
                                x = GetPlayerX(Index) - 1
                                y = GetPlayerY(Index)
                            Else
                                Exit Sub
                            End If

                        Case Direction.Right

                            If GetPlayerX(Index) < Map(GetPlayerMap(Index)).MaxX Then
                                x = GetPlayerX(Index) + 1
                                y = GetPlayerY(Index)
                            Else
                                Exit Sub
                            End If

                    End Select

                    ' Check if a key exists
                    If Map(GetPlayerMap(Index)).Tile(x, y).Type = TileType.Key Then

                        ' Check if the key they are using matches the map key
                        If InvItemNum = Map(GetPlayerMap(Index)).Tile(x, y).Data1 Then
                            TempTile(GetPlayerMap(Index)).DoorOpen(x, y) = True
                            TempTile(GetPlayerMap(Index)).DoorTimer = GetTickCount()
                            SendMapKey(Index, x, y, 1)
                            MapMsg(GetPlayerMap(Index), "A door has been unlocked.", ColorType.Yellow)

                            SendAnimation(GetPlayerMap(Index), Item(InvItemNum).Animation, x, y)

                            ' Check if we are supposed to take away the item
                            If Map(GetPlayerMap(Index)).Tile(x, y).Data2 = 1 Then
                                TakeInvItem(Index, InvItemNum, 0)
                                PlayerMsg(Index, "The key is destroyed in the lock.", ColorType.Yellow)
                            End If
                        End If
                    End If

                Case ItemType.Skill
                    InvItemNum = GetPlayerInvItemNum(Index, InvNum)

                    For i = 1 To Stats.Count - 1
                        If GetPlayerStat(Index, i) < Item(InvItemNum).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.", ColorType.BrightRed)
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right class
                    If Not Item(InvItemNum).ClassReq = GetPlayerClass(Index) And Not Item(InvItemNum).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.", ColorType.BrightRed)
                        Exit Sub
                    End If

                    ' Get the skill num
                    n = Item(InvItemNum).Data1

                    If n > 0 Then

                        ' Make sure they are the right class
                        If Skill(n).ClassReq = GetPlayerClass(Index) Or Skill(n).ClassReq = 0 Then
                            ' Make sure they are the right level
                            i = Skill(n).LevelReq

                            If i <= GetPlayerLevel(Index) Then
                                i = FindOpenSkillSlot(Index)

                                ' Make sure they have an open skill slot
                                If i > 0 Then

                                    ' Make sure they dont already have the skill
                                    If Not HasSkill(Index, n) Then
                                        SetPlayerSkill(Index, i, n)
                                        SendAnimation(GetPlayerMap(Index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, Index)
                                        TakeInvItem(Index, InvItemNum, 0)
                                        PlayerMsg(Index, "You study the skill carefully.", ColorType.Yellow)
                                        PlayerMsg(Index, "You have learned a new skill!", ColorType.BrightGreen)
                                    Else
                                        PlayerMsg(Index, "You have already learned this skill!", ColorType.BrightRed)
                                    End If

                                Else
                                    PlayerMsg(Index, "You have learned all that you can learn!", ColorType.BrightRed)
                                End If

                            Else
                                PlayerMsg(Index, "You must be level " & i & " to learn this skill.", ColorType.Yellow)
                            End If

                        Else
                            PlayerMsg(Index, "This skill can only be learned by " & CheckGrammar(GetClassName(Skill(n).ClassReq)) & ".", ColorType.Yellow)
                        End If

                    Else
                        PlayerMsg(Index, "This scroll is not connected to a skill, please inform an admin!", ColorType.BrightRed)
                    End If
                Case ItemType.Furniture
                    PlayerMsg(Index, "To place furniture, simply click on it in your inventory, then click in your house where you want it.", ColorType.Yellow)

                Case ItemType.Recipe

                    PlayerMsg(Index, "Lets learn this recipe :)", ColorType.BrightGreen)
                    ' Get the recipe num
                    n = Item(InvItemNum).Data1
                    LearnRecipe(Index, n, InvNum)
            End Select

        End If
    End Sub
End Module
