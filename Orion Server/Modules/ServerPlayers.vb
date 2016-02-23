Module ServerPlayers
    ' //////////////////////
    ' // PLAYER FUNCTIONS //
    ' //////////////////////
    Function GetPlayerLogin(ByVal Index As Long) As String
        GetPlayerLogin = Trim$(Player(Index).Login)
    End Function
    Function GetPlayerIP(ByVal Index As Long) As String
        GetPlayerIP = ""
        GetPlayerIP = GetClientIP(Index)
    End Function
    Public Sub HandleUseChar(ByVal Index As Long)
        If Not IsPlaying(Index) Then
            Call JoinGame(Index)
            Call Addlog(GetPlayerLogin(Index) & "/" & GetPlayerName(Index) & " has began playing " & Options.Game_Name & ".", PLAYER_LOG)
            Call TextAdd(GetPlayerLogin(Index) & "/" & GetPlayerName(Index) & " has began playing " & Options.Game_Name & ".")
        End If
    End Sub
    Function GetPlayerName(ByVal Index As Long) As String
        GetPlayerName = ""
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerName = Trim$(Player(Index).Name)
    End Function
    Sub SetPlayerAccess(ByVal Index As Long, ByVal Access As Long)
        Player(Index).Access = Access
    End Sub
    Sub SetPlayerSprite(ByVal Index As Long, ByVal Sprite As Long)
        Player(Index).Sprite = Sprite
    End Sub
    Function GetPlayerMaxVital(ByVal Index As Long, ByVal Vital As Vitals) As Long

        GetPlayerMaxVital = 0

        If Index > MAX_PLAYERS Then Exit Function

        Select Case Vital
            Case Vitals.HP
                GetPlayerMaxVital = (Player(Index).Level + (GetPlayerStat(Index, Stats.vitality) \ 2) + Classes(Player(Index).Classes).Stat(Stats.vitality)) * 2
            Case Vitals.MP
                GetPlayerMaxVital = (Player(Index).Level + (GetPlayerStat(Index, Stats.intelligence) \ 2) + Classes(Player(Index).Classes).Stat(Stats.intelligence)) * 2
            Case Vitals.SP
                GetPlayerMaxVital = (Player(Index).Level + (GetPlayerStat(Index, Stats.spirit) \ 2) + Classes(Player(Index).Classes).Stat(Stats.spirit)) * 2
        End Select

    End Function
    Public Function GetPlayerStat(ByVal Index As Long, ByVal Stat As Stats) As Long
        Dim x As Long, i As Long

        GetPlayerStat = 0

        If Index > MAX_PLAYERS Then Exit Function

        x = Player(Index).Stat(Stat)

        For i = 1 To Equipment.Equipment_Count - 1
            If Player(Index).Equipment(i) > 0 Then
                If Item(Player(Index).Equipment(i)).Add_Stat(Stat) > 0 Then
                    x = x + Item(Player(Index).Equipment(i)).Add_Stat(Stat)
                End If
            End If
        Next

        GetPlayerStat = x
    End Function
    Function GetPlayerAccess(ByVal Index As Long) As Long
        GetPlayerAccess = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerAccess = Player(Index).Access
    End Function
    Function GetPlayerMap(ByVal Index As Long) As Long
        GetPlayerMap = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerMap = Player(Index).Map
    End Function
    Function GetPlayerX(ByVal Index As Long) As Long
        GetPlayerX = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerX = Player(Index).x
    End Function
    Function GetPlayerY(ByVal Index As Long) As Long
        GetPlayerY = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerY = Player(Index).y
    End Function
    Sub SendLeaveMap(ByVal Index As Long, ByVal MapNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SLeftMap)
        Buffer.WriteLong(Index)
        SendDataToMapBut(Index, MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub PlayerWarp(ByVal Index As Long, ByVal MapNum As Long, ByVal x As Long, ByVal y As Long, Optional HouseTeleport As Boolean = False)
        Dim OldMap As Long
        Dim i As Long
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or MapNum <= 0 Or MapNum > MAX_MAPS Then
            Exit Sub
        End If

        ' Check if you are out of bounds
        If x > Map(MapNum).MaxX Then x = Map(MapNum).MaxX
        If y > Map(MapNum).MaxY Then y = Map(MapNum).MaxY

        TempPlayer(Index).EventProcessingCount = 0
        TempPlayer(Index).EventMap.CurrentEvents = 0

        If HouseTeleport = False Then
            Player(Index).InHouse = 0
        End If

        If Player(Index).InHouse > 0 Then
            If IsPlaying(Player(Index).InHouse) Then
                If Player(Index).InHouse <> Player(Index).InHouse Then
                    Player(Index).InHouse = 0
                    PlayerWarp(Index, Player(Index).LastMap, Player(Index).LastX, Player(Index).LastY)
                    Exit Sub
                Else
                    SendFurnitureToHouse(Player(Index).InHouse)
                End If
            End If
        End If

        'clear target
        TempPlayer(Index).Target = 0
        TempPlayer(Index).TargetType = TARGET_TYPE_NONE

        ' Save old map to send erase player data to
        OldMap = GetPlayerMap(Index)

        If OldMap <> MapNum Then
            Call SendLeaveMap(Index, OldMap)
        End If

        Call SetPlayerMap(Index, MapNum)
        Call SetPlayerX(Index, x)
        Call SetPlayerY(Index, y)

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
            PlayersOnMap(OldMap) = NO

            ' Regenerate all NPCs' health
            For i = 1 To MAX_MAP_NPCS

                If MapNpc(OldMap).Npc(i).Num > 0 Then
                    MapNpc(OldMap).Npc(i).Vital(Vitals.HP) = GetNpcMaxVital(MapNpc(OldMap).Npc(i).Num, Vitals.HP)
                End If

            Next

        End If

        ' Sets it so we know to process npcs on the map
        PlayersOnMap(MapNum) = YES
        TempPlayer(Index).GettingMap = YES

        Call CheckTasks(Index, QUEST_TYPE_GOREACH, MapNum)


        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SCheckForMap)
        Buffer.WriteLong(MapNum)
        Buffer.WriteLong(Map(MapNum).Revision)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Function GetPlayerDir(ByVal Index As Long) As Long
        GetPlayerDir = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerDir = Player(Index).Dir
    End Function
    Function GetPlayerSprite(ByVal Index As Long) As Long
        GetPlayerSprite = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerSprite = Player(Index).Sprite
    End Function
    Function GetPlayerPK(ByVal Index As Long) As Long
        GetPlayerPK = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPK = Player(Index).PK
    End Function
    Sub CheckEquippedItems(ByVal Index As Long)
        Dim itemNum As Long
        Dim i As Long

        ' We want to check incase an admin takes away an object but they had it equipped
        For i = 1 To Equipment.Equipment_Count - 1
            itemNum = GetPlayerEquipment(Index, i)

            If itemNum > 0 Then

                Select Case i
                    Case Equipment.Weapon

                        If Item(itemNum).Type <> ITEM_TYPE_WEAPON Then SetPlayerEquipment(Index, 0, i)
                    Case Equipment.Armor

                        If Item(itemNum).Type <> ITEM_TYPE_ARMOR Then SetPlayerEquipment(Index, 0, i)
                    Case Equipment.Helmet

                        If Item(itemNum).Type <> ITEM_TYPE_HELMET Then SetPlayerEquipment(Index, 0, i)
                    Case Equipment.Shield

                        If Item(itemNum).Type <> ITEM_TYPE_SHIELD Then SetPlayerEquipment(Index, 0, i)
                End Select

            Else
                SetPlayerEquipment(Index, 0, i)
            End If

        Next

    End Sub
    Function GetPlayerEquipment(ByVal Index As Long, ByVal EquipmentSlot As Equipment) As Byte
        GetPlayerEquipment = 0
        If Index > MAX_PLAYERS Then Exit Function
        If EquipmentSlot = 0 Then Exit Function
        GetPlayerEquipment = Player(Index).Equipment(EquipmentSlot)
    End Function
    Sub SetPlayerEquipment(ByVal Index As Long, ByVal InvNum As Long, ByVal EquipmentSlot As Equipment)
        Player(Index).Equipment(EquipmentSlot) = InvNum
    End Sub
    Sub JoinGame(ByVal Index As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        ' Set the flag so we know the person is in the game
        TempPlayer(Index).InGame = True

        ' Send a global message that he/she joined
        If GetPlayerAccess(Index) <= ADMIN_MONITOR Then
            Call GlobalMsg(GetPlayerName(Index) & " has joined " & Options.Game_Name & "!")
        Else
            Call GlobalMsg(GetPlayerName(Index) & " has joined " & Options.Game_Name & "!")
        End If

        'Update the log
        ' Send an ok to client to start receiving in game data
        Call SendLoginOk(Index)
        TotalPlayersOnline = TotalPlayersOnline + 1
        ' Send some more little goodies, no need to explain these
        Call CheckEquippedItems(Index)

        SendGameData(Index)

        Call SendInventory(Index)
        Call SendWornEquipment(Index)
        Call SendMapEquipment(Index)

        For i = 1 To Vitals.Vital_Count - 1
            Call SendVital(Index, i)
        Next

        SendEXP(Index)

        'Housing
        If Player(Index).InHouse Then
            Player(Index).InHouse = 0
            Player(Index).x = Player(Index).LastX
            Player(Index).y = Player(Index).LastY
            Player(Index).Map = Player(Index).LastMap
        End If
        SendHouseConfigs(Index)

        'quests
        SendQuests(Index)
        SendPlayerQuests(Index)
        SendMapNames(Index)

        'hotbar
        SendHotbar(Index)
        SendPlayerSpells(Index)

        Call SendStats(Index)
        Call SendJoinMap(Index)
        ' Warp the player to his saved location
        Call PlayerWarp(Index, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
        ' Send welcome messages
        Call SendWelcome(Index)

        ' Send Resource cache
        For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count
            SendResourceCacheTo(Index, i)
        Next

        ' Send the flag so they know they can start doing stuff
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SInGame)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub LeftGame(ByVal Index As Long)
        Dim n As Long, i As Long
        Dim tradeTarget As Long

        If TempPlayer(Index).InGame Then
            TempPlayer(Index).InGame = False

            ' Check if player was the only player on the map and stop npc processing if so
            If GetTotalMapPlayers(GetPlayerMap(Index)) < 1 Then
                PlayersOnMap(GetPlayerMap(Index)) = NO
            End If

            ' Check if the player was in a party, and if so cancel it out so the other player doesn't continue to get half exp
            If TempPlayer(Index).InParty = YES Then
                n = TempPlayer(Index).PartyPlayer
                Call PlayerMsg(n, GetPlayerName(Index) & " has left " & Options.Game_Name & ", disbanning party.")
                TempPlayer(n).InParty = NO
                TempPlayer(n).PartyPlayer = 0
            End If

            ' cancel any trade they're in
            If TempPlayer(Index).InTrade > 0 Then
                tradeTarget = TempPlayer(Index).InTrade
                PlayerMsg(tradeTarget, Trim$(GetPlayerName(Index)) & " has declined the trade.")
                ' clear out trade
                For i = 1 To MAX_INV
                    TempPlayer(tradeTarget).TradeOffer(i).Num = 0
                    TempPlayer(tradeTarget).TradeOffer(i).Value = 0
                Next
                TempPlayer(tradeTarget).InTrade = 0
                SendCloseTrade(tradeTarget)
            End If

            Call SavePlayer(Index)
            Call SaveBank(Index)
            Call ClearBank(Index)

            ' Send a global message that he/she left
            If GetPlayerAccess(Index) <= ADMIN_MONITOR Then
                Call GlobalMsg(GetPlayerName(Index) & " has left " & Options.Game_Name & "!")
            Else
                Call GlobalMsg(GetPlayerName(Index) & " has left " & Options.Game_Name & "!")
            End If

            TextAdd(GetPlayerName(Index) & " has disconnected from " & Options.Game_Name & ".")
            Call SendLeftGame(Index)
            TotalPlayersOnline = TotalPlayersOnline - 1
            TempPlayer(Index) = Nothing
            ReDim TempPlayer(i).SpellCD(0 To MAX_PLAYER_SPELLS)
            ReDim TempPlayer(i).TradeOffer(0 To MAX_INV)
        End If

        Call ClearPlayer(Index)
    End Sub
    Sub PlayerMove(ByVal Index As Long, ByVal Dir As Long, ByVal movement As Long)
        Dim MapNum As Long, Buffer As ByteBuffer
        Dim x As Long, y As Long, begineventprocessing As Boolean
        Dim Moved As Byte
        Dim NewMapX As Byte, NewMapY As Byte
        Dim VitalType As Long, Colour As Long, amount As Long

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Dir < DIR_UP Or Dir > DIR_RIGHT Or movement < 1 Or movement > 2 Then
            Exit Sub
        End If

        Call SetPlayerDir(Index, Dir)
        Moved = NO
        MapNum = GetPlayerMap(Index)

        Select Case Dir
            Case DIR_UP

                ' Check to make sure not outside of boundries
                If GetPlayerY(Index) > 0 Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, DIR_UP + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type <> TILE_TYPE_BLOCKED Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type <> TILE_TYPE_RESOURCE Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type <> TILE_TYPE_KEY Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) - 1).Type = TILE_TYPE_KEY And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index), GetPlayerY(Index) - 1) = YES) Then
                                    Call SetPlayerY(Index, GetPlayerY(Index) - 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = YES
                                End If
                            End If
                        End If
                    End If

                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Up > 0 Then
                        NewMapY = Map(Map(GetPlayerMap(Index)).Up).MaxY
                        Call PlayerWarp(Index, Map(GetPlayerMap(Index)).Up, GetPlayerX(Index), NewMapY)
                        Moved = YES
                    End If
                End If

            Case DIR_DOWN

                ' Check to make sure not outside of boundries
                If GetPlayerY(Index) < Map(MapNum).MaxY Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, DIR_DOWN + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type <> TILE_TYPE_BLOCKED Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type <> TILE_TYPE_RESOURCE Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type <> TILE_TYPE_KEY Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index) + 1).Type = TILE_TYPE_KEY And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index), GetPlayerY(Index) + 1) = YES) Then
                                    Call SetPlayerY(Index, GetPlayerY(Index) + 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = YES
                                End If
                            End If
                        End If
                    End If

                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Down > 0 Then
                        Call PlayerWarp(Index, Map(GetPlayerMap(Index)).Down, GetPlayerX(Index), 0)
                        Moved = YES
                    End If
                End If

            Case DIR_LEFT

                ' Check to make sure not outside of boundries
                If GetPlayerX(Index) > 0 Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, DIR_LEFT + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type <> TILE_TYPE_BLOCKED Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type <> TILE_TYPE_RESOURCE Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type <> TILE_TYPE_KEY Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) - 1, GetPlayerY(Index)).Type = TILE_TYPE_KEY And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index) - 1, GetPlayerY(Index)) = YES) Then
                                    Call SetPlayerX(Index, GetPlayerX(Index) - 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = YES
                                End If
                            End If
                        End If
                    End If

                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Left > 0 Then
                        NewMapX = Map(Map(GetPlayerMap(Index)).Left).MaxX
                        Call PlayerWarp(Index, Map(GetPlayerMap(Index)).Left, NewMapX, GetPlayerY(Index))
                        Moved = YES
                    End If
                End If

            Case DIR_RIGHT

                ' Check to make sure not outside of boundries
                If GetPlayerX(Index) < Map(MapNum).MaxX Then

                    ' Check to make sure that the tile is walkable
                    If Not isDirBlocked(Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index)).DirBlock, DIR_RIGHT + 1) Then
                        If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type <> TILE_TYPE_BLOCKED Then
                            If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type <> TILE_TYPE_RESOURCE Then

                                ' Check to see if the tile is a key and if it is check if its opened
                                If Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type <> TILE_TYPE_KEY Or (Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index) + 1, GetPlayerY(Index)).Type = TILE_TYPE_KEY And TempTile(GetPlayerMap(Index)).DoorOpen(GetPlayerX(Index) + 1, GetPlayerY(Index)) = YES) Then
                                    Call SetPlayerX(Index, GetPlayerX(Index) + 1)
                                    SendPlayerMove(Index, movement)
                                    Moved = YES
                                End If
                            End If
                        End If
                    End If


                Else

                    ' Check to see if we can move them to the another map
                    If Map(GetPlayerMap(Index)).Right > 0 Then
                        Call PlayerWarp(Index, Map(GetPlayerMap(Index)).Right, 0, GetPlayerY(Index))
                        Moved = YES
                    End If
                End If
        End Select

        With Map(GetPlayerMap(Index)).Tile(GetPlayerX(Index), GetPlayerY(Index))
            ' Check to see if the tile is a warp tile, and if so warp them
            If .Type = TILE_TYPE_WARP Then
                MapNum = .Data1
                x = .Data2
                y = .Data3
                'TempPlayer(Index).CanPlayerMove = 1
                Call PlayerWarp(Index, MapNum, x, y)
                Moved = YES
            End If

            ' Check to see if the tile is a door tile, and if so warp them
            If .Type = TILE_TYPE_DOOR Then
                MapNum = .Data1
                x = .Data2
                y = .Data3
                ' send the animation to the map
                SendDoorAnimation(GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
                'TempPlayer(Index).CanPlayerMove = 1
                Call PlayerWarp(Index, MapNum, x, y)
                Moved = YES
            End If

            ' Check for key trigger open
            If .Type = TILE_TYPE_KEYOPEN Then
                x = .Data1
                y = .Data2

                If Map(GetPlayerMap(Index)).Tile(x, y).Type = TILE_TYPE_KEY And TempTile(GetPlayerMap(Index)).DoorOpen(x, y) = NO Then
                    TempTile(GetPlayerMap(Index)).DoorOpen(x, y) = YES
                    TempTile(GetPlayerMap(Index)).DoorTimer = GetTickCount()
                    SendMapKey(Index, x, y, 1)
                    Call MapMsg(GetPlayerMap(Index), "A door has been unlocked.", White)
                End If
            End If

            ' Check for a shop, and if so open it
            If .Type = TILE_TYPE_SHOP Then
                x = .Data1
                If x > 0 Then ' shop exists?
                    If Len(Trim$(Shop(x).Name)) > 0 Then ' name exists?
                        SendOpenShop(Index, x)
                        TempPlayer(Index).InShop = x ' stops movement and the like
                    End If
                End If
            End If

            ' Check to see if the tile is a bank, and if so send bank
            If .Type = TILE_TYPE_BANK Then
                SendBank(Index)
                TempPlayer(Index).InBank = True
                Moved = YES
            End If

            ' Check if it's a heal tile
            If .Type = TILE_TYPE_HEAL Then
                VitalType = .Data1
                amount = .Data2
                If Not GetPlayerVital(Index, VitalType) = GetPlayerMaxVital(Index, VitalType) Then
                    If VitalType = Vitals.HP Then
                        Colour = BrightGreen
                    Else
                        Colour = BrightBlue
                    End If
                    SendActionMsg(GetPlayerMap(Index), "+" & amount, Colour, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32, 1)
                    SetPlayerVital(Index, VitalType, GetPlayerVital(Index, VitalType) + amount)
                    PlayerMsg(Index, "You feel rejuvinating forces flowing through your boy.")
                    Call SendVital(Index, VitalType)
                End If
                Moved = YES
            End If

            ' Check if it's a trap tile
            If .Type = TILE_TYPE_TRAP Then
                amount = .Data1
                SendActionMsg(GetPlayerMap(Index), "-" & amount, BrightRed, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32, 1)
                If GetPlayerVital(Index, Vitals.HP) - amount <= 0 Then
                    KillPlayer(Index)
                    PlayerMsg(Index, "You're killed by a trap.")
                Else
                    SetPlayerVital(Index, Vitals.HP, GetPlayerVital(Index, Vitals.HP) - amount)
                    PlayerMsg(Index, "You're injured by a trap.")
                    Call SendVital(Index, Vitals.HP)
                End If
                Moved = YES
            End If

            'Housing
            If .Type = TILE_TYPE_HOUSE Then
                If Player(Index).House.HouseIndex = .Data1 Then
                    'Do warping and such to the player's house :/
                    Player(Index).LastMap = GetPlayerMap(Index)
                    Player(Index).LastX = GetPlayerX(Index)
                    Player(Index).LastY = GetPlayerY(Index)
                    Player(Index).InHouse = Index
                    SendDataTo(Index, PlayerData(Index))
                    Call PlayerWarp(Index, HouseConfig(Player(Index).House.HouseIndex).BaseMap, HouseConfig(Player(Index).House.HouseIndex).X, HouseConfig(Player(Index).House.HouseIndex).Y, True)
                    Exit Sub
                Else
                    'Send the buy sequence and see what happens. (To be recreated in events.)
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SBuyHouse)
                    Buffer.WriteLong(.Data1)
                    SendDataTo(Index, Buffer.ToArray)
                    Buffer = Nothing
                    TempPlayer(Index).BuyHouseIndex = .Data1
                End If
            End If

        End With

        If Moved = YES Then
            If Player(Index).InHouse > 0 Then
                If Player(Index).x = HouseConfig(Player(Player(Index).InHouse).House.HouseIndex).X Then
                    If Player(Index).y = HouseConfig(Player(Player(Index).InHouse).House.HouseIndex).Y Then
                        Call PlayerWarp(Index, Player(Index).LastMap, Player(Index).LastX, Player(Index).LastY)
                    End If
                End If
            End If
        End If

        ' They tried to hack
        If Moved = NO Then
            Call PlayerWarp(Index, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
        End If

        x = GetPlayerX(Index)
        y = GetPlayerY(Index)

        If Moved = YES Then
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

    Function HasItem(ByVal Index As Long, ByVal itemNum As Long) As Long
        Dim i As Long

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                If Item(itemNum).Type = ITEM_TYPE_CURRENCY Then
                    HasItem = GetPlayerInvItemValue(Index, i)
                Else
                    HasItem = 1
                End If

                Exit Function
            End If

        Next

    End Function
    Sub SetPlayerDir(ByVal Index As Long, ByVal Dir As Long)
        Player(Index).Dir = Dir
    End Sub
    Sub SetPlayerVital(ByVal Index As Long, ByVal Vital As Vitals, ByVal Value As Long)
        Player(Index).Vital(Vital) = Value

        If GetPlayerVital(Index, Vital) > GetPlayerMaxVital(Index, Vital) Then
            Player(Index).Vital(Vital) = GetPlayerMaxVital(Index, Vital)
        End If

        If GetPlayerVital(Index, Vital) < 0 Then
            Player(Index).Vital(Vital) = 0
        End If

    End Sub
    Public Function isDirBlocked(ByRef blockvar As Byte, ByRef Dir As Byte) As Boolean
        If Not blockvar And (2 ^ Dir) Then
            isDirBlocked = False
        Else
            isDirBlocked = True
        End If
    End Function
    Function GetPlayerVital(ByVal Index As Long, ByVal Vital As Vitals) As Long
        GetPlayerVital = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerVital = Player(Index).Vital(Vital)
    End Function
    Function GetPlayerLevel(ByVal Index As Long) As Long
        GetPlayerLevel = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerLevel = Player(Index).Level
    End Function
    Function GetPlayerPOINTS(ByVal Index As Long) As Long
        GetPlayerPOINTS = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerPOINTS = Player(Index).POINTS
    End Function
    Function GetPlayerNextLevel(ByVal Index As Long) As Long
        GetPlayerNextLevel = (GetPlayerLevel(Index) + 1) * (GetPlayerStat(Index, Stats.strength) + GetPlayerStat(Index, Stats.endurance) + GetPlayerStat(Index, Stats.intelligence) + GetPlayerStat(Index, Stats.spirit) + GetPlayerPOINTS(Index)) * 25
    End Function
    Function GetPlayerExp(ByVal Index As Long) As Long
        GetPlayerExp = Player(Index).exp
    End Function
    Sub SetPlayerMap(ByVal Index As Long, ByVal MapNum As Long)
        If MapNum > 0 And MapNum <= MAX_MAPS Then
            Player(Index).Map = MapNum
        End If
    End Sub
    Sub SetPlayerX(ByVal Index As Long, ByVal x As Long)
        Player(Index).x = x
    End Sub
    Sub SetPlayerY(ByVal Index As Long, ByVal y As Long)
        Player(Index).y = y
    End Sub
    Function GetPlayerInvItemNum(ByVal Index As Long, ByVal invSlot As Long) As Long
        GetPlayerInvItemNum = 0
        If Index > MAX_PLAYERS Then Exit Function
        If invSlot = 0 Then Exit Function

        GetPlayerInvItemNum = Player(Index).Inv(invSlot).Num
    End Function
    Function GetPlayerInvItemValue(ByVal Index As Long, ByVal invSlot As Long) As Long
        GetPlayerInvItemValue = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerInvItemValue = Player(Index).Inv(invSlot).Value
    End Function
    Sub SetPlayerExp(ByVal Index As Long, ByVal exp As Long)
        Player(Index).exp = exp
    End Sub
    Public Function GetPlayerRawStat(ByVal Index As Long, ByVal Stat As Stats) As Long
        GetPlayerRawStat = 0
        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerRawStat = Player(Index).Stat(Stat)
    End Function

    Public Sub SetPlayerStat(ByVal Index As Long, ByVal Stat As Stats, ByVal Value As Long)
        Player(Index).Stat(Stat) = Value
    End Sub
    Sub SetPlayerLevel(ByVal Index As Long, ByVal Level As Long)

        If Level > MAX_LEVELS Then Exit Sub
        Player(Index).Level = Level
    End Sub
    Sub SetPlayerPOINTS(ByVal Index As Long, ByVal POINTS As Long)
        Player(Index).POINTS = POINTS
    End Sub
    Sub CheckPlayerLevelUp(ByVal Index As Long)
        Dim expRollover As Long
        Dim level_count As Long

        level_count = 0

        Do While GetPlayerExp(Index) >= GetPlayerNextLevel(Index)
            expRollover = GetPlayerExp(Index) - GetPlayerNextLevel(Index)
            Call SetPlayerLevel(Index, GetPlayerLevel(Index) + 1)
            Call SetPlayerPOINTS(Index, GetPlayerPOINTS(Index) + 3)
            Call SetPlayerExp(Index, expRollover)
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
            SendEXP(Index)
            SendPlayerData(Index)
        End If
    End Sub
    Sub PlayerMapGetItem(ByVal Index As Long)
        Dim i As Long
        Dim n As Long
        Dim MapNum As Long
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
                                Call SetPlayerInvItemNum(Index, n, MapItem(MapNum, i).Num)

                                If Item(GetPlayerInvItemNum(Index, n)).Type = ITEM_TYPE_CURRENCY Then
                                    Call SetPlayerInvItemValue(Index, n, GetPlayerInvItemValue(Index, n) + MapItem(MapNum, i).Value)
                                    Msg = MapItem(MapNum, i).Value & " " & Trim$(Item(GetPlayerInvItemNum(Index, n)).Name)
                                Else
                                    Call SetPlayerInvItemValue(Index, n, 0)
                                    Msg = CheckGrammar(Trim$(Item(GetPlayerInvItemNum(Index, n)).Name), 1)
                                End If

                                ' Erase item from the map
                                MapItem(MapNum, i).Num = 0
                                MapItem(MapNum, i).Value = 0
                                MapItem(MapNum, i).x = 0
                                MapItem(MapNum, i).y = 0
                                Call SendInventoryUpdate(Index, n)
                                Call SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), 0, 0)
                                'Call PlayerMsg(Index, Msg, Yellow)
                                SendActionMsg(GetPlayerMap(Index), Msg, White, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                                Call CheckTasks(Index, QUEST_TYPE_GOGATHER, GetItemNum(Trim$(Item(GetPlayerInvItemNum(Index, n)).Name)))
                                Exit For
                            Else
                                Call PlayerMsg(Index, "Your inventory is full.")
                                Exit For
                            End If
                        End If
                    End If
                End If
            End If

        Next

    End Sub
    Sub SetPlayerInvItemValue(ByVal Index As Long, ByVal invSlot As Long, ByVal ItemValue As Long)
        Player(Index).Inv(invSlot).Value = ItemValue
    End Sub
    Sub SetPlayerInvItemNum(ByVal Index As Long, ByVal invSlot As Long, ByVal itemNum As Long)
        Player(Index).Inv(invSlot).Num = itemNum
    End Sub
    Function FindOpenInvSlot(ByVal Index As Long, ByVal itemNum As Long) As Long
        Dim i As Long

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        If Item(itemNum).Type = ITEM_TYPE_CURRENCY Then

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
    Function TakeInvItem(ByVal Index As Long, ByVal itemNum As Long, ByVal ItemVal As Long) As Boolean
        Dim i As Long

        TakeInvItem = False

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(Index, i) = itemNum Then
                If Item(itemNum).Type = ITEM_TYPE_CURRENCY Then

                    ' Is what we are trying to take away more then what they have?  If so just set it to zero
                    If ItemVal >= GetPlayerInvItemValue(Index, i) Then
                        TakeInvItem = True
                    Else
                        Call SetPlayerInvItemValue(Index, i, GetPlayerInvItemValue(Index, i) - ItemVal)
                        Call SendInventoryUpdate(Index, i)
                    End If
                Else
                    TakeInvItem = True
                End If

                If TakeInvItem Then
                    Call SetPlayerInvItemNum(Index, i, 0)
                    Call SetPlayerInvItemValue(Index, i, 0)
                    ' Send the inventory update
                    Call SendInventoryUpdate(Index, i)
                    Exit Function
                End If
            End If

        Next

    End Function
    Function GiveInvItem(ByVal Index As Long, ByVal itemNum As Long, ByVal ItemVal As Long, Optional ByVal sendUpdate As Boolean = True) As Boolean
        Dim i As Long

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or itemNum <= 0 Or itemNum > MAX_ITEMS Then
            GiveInvItem = False
            Exit Function
        End If

        i = FindOpenInvSlot(Index, itemNum)

        ' Check to see if inventory is full
        If i <> 0 Then
            Call SetPlayerInvItemNum(Index, i, itemNum)
            Call SetPlayerInvItemValue(Index, i, GetPlayerInvItemValue(Index, i) + ItemVal)
            If sendUpdate Then Call SendInventoryUpdate(Index, i)
            GiveInvItem = True
        Else
            Call PlayerMsg(Index, "Your inventory is full.")
            GiveInvItem = False
        End If

    End Function
    Function GetPlayerClass(ByVal Index As Long) As Long
        GetPlayerClass = Player(Index).Classes
    End Function
    Function FindOpenSpellSlot(ByVal Index As Long) As Long
        Dim i As Long

        For i = 1 To MAX_PLAYER_SPELLS

            If GetPlayerSpell(Index, i) = 0 Then
                FindOpenSpellSlot = i
                Exit Function
            End If

        Next

    End Function
    Function GetPlayerSpell(ByVal Index As Long, ByVal spellslot As Long) As Long
        GetPlayerSpell = 0
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerSpell = Player(Index).Spell(spellslot)
    End Function
    Function HasSpell(ByVal Index As Long, ByVal spellnum As Long) As Boolean
        Dim i As Long

        For i = 1 To MAX_PLAYER_SPELLS

            If GetPlayerSpell(Index, i) = spellnum Then
                HasSpell = True
                Exit Function
            End If

        Next

    End Function
    Sub SetPlayerSpell(ByVal Index As Long, ByVal spellslot As Long, ByVal spellnum As Long)
        Player(Index).Spell(spellslot) = spellnum
    End Sub
    Sub PlayerMapDropItem(ByVal Index As Long, ByVal InvNum As Long, ByVal amount As Long)
        Dim i As Long

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

                    If Item(GetPlayerInvItemNum(Index, InvNum)).Type = ITEM_TYPE_CURRENCY Then

                        ' Check if its more then they have and if so drop it all
                        If amount >= GetPlayerInvItemValue(Index, InvNum) Then
                            MapItem(GetPlayerMap(Index), i).Value = GetPlayerInvItemValue(Index, InvNum)
                            Call MapMsg(GetPlayerMap(Index), GetPlayerName(Index) & " drops " & GetPlayerInvItemValue(Index, InvNum) & " " & Trim$(Item(GetPlayerInvItemNum(Index, InvNum)).Name) & ".", Yellow)
                            Call SetPlayerInvItemNum(Index, InvNum, 0)
                            Call SetPlayerInvItemValue(Index, InvNum, 0)
                        Else
                            MapItem(GetPlayerMap(Index), i).Value = amount
                            Call MapMsg(GetPlayerMap(Index), GetPlayerName(Index) & " drops " & amount & " " & Trim$(Item(GetPlayerInvItemNum(Index, InvNum)).Name) & ".", Yellow)
                            Call SetPlayerInvItemValue(Index, InvNum, GetPlayerInvItemValue(Index, InvNum) - amount)
                        End If

                    Else
                        ' Its not a currency object so this is easy
                        MapItem(GetPlayerMap(Index), i).Value = 0
                        ' send message
                        Call MapMsg(GetPlayerMap(Index), GetPlayerName(Index) & " drops " & CheckGrammar(Trim$(Item(GetPlayerInvItemNum(Index, InvNum)).Name)) & ".", Yellow)
                        Call SetPlayerInvItemNum(Index, InvNum, 0)
                        Call SetPlayerInvItemValue(Index, InvNum, 0)
                    End If

                    ' Send inventory update
                    Call SendInventoryUpdate(Index, InvNum)
                    ' Spawn the item before we set the num or we'll get a different free map item slot
                    Call SpawnItemSlot(i, MapItem(GetPlayerMap(Index), i).Num, amount, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
                Else
                    Call PlayerMsg(Index, "Too many items already on the ground.")
                End If
            End If
        End If

    End Sub
    Sub GiveBankItem(ByVal Index As Long, ByVal invSlot As Long, ByVal amount As Long)
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
            If Item(GetPlayerInvItemNum(Index, invSlot)).Type = ITEM_TYPE_CURRENCY Then
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
    Function GetPlayerBankItemNum(ByVal Index As Long, ByVal BankSlot As Byte) As Integer
        GetPlayerBankItemNum = Bank(Index).Item(BankSlot).Num
    End Function

    Sub SetPlayerBankItemNum(ByVal Index As Long, ByVal BankSlot As Byte, ByVal itemNum As Integer)
        Bank(Index).Item(BankSlot).Num = itemNum
    End Sub

    Function GetPlayerBankItemValue(ByVal Index As Long, ByVal BankSlot As Byte) As Long
        GetPlayerBankItemValue = Bank(Index).Item(BankSlot).Value
    End Function

    Sub SetPlayerBankItemValue(ByVal Index As Long, ByVal BankSlot As Byte, ByVal ItemValue As Long)
        Bank(Index).Item(BankSlot).Value = ItemValue
    End Sub
    Function FindOpenBankSlot(ByVal Index As Long, ByVal itemNum As Integer) As Byte
        Dim i As Long

        If Not IsPlaying(Index) Then Exit Function
        If itemNum <= 0 Or itemNum > MAX_ITEMS Then Exit Function

        If Item(itemNum).Type = ITEM_TYPE_CURRENCY Then
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
    Sub SetPlayerPK(ByVal Index As Long, ByVal PK As Long)
        Player(Index).PK = PK
    End Sub
    Sub TakeBankItem(ByVal Index As Long, ByVal BankSlot As Long, ByVal amount As Long)
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
            If Item(GetPlayerBankItemNum(Index, BankSlot)).Type = ITEM_TYPE_CURRENCY Then
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

    Public Sub KillPlayer(ByVal Index As Long)
        Dim exp As Long

        ' Calculate exp to give attacker
        exp = GetPlayerExp(Index) \ 3

        ' Make sure we dont get less then 0
        If exp < 0 Then exp = 0
        If exp = 0 Then
            Call PlayerMsg(Index, "You lost no exp.")
        Else
            Call SetPlayerExp(Index, GetPlayerExp(Index) - exp)
            SendEXP(Index)
            Call PlayerMsg(Index, "You lost " & exp & " exp.")
        End If

        Call OnDeath(Index)
    End Sub
    Sub OnDeath(ByVal Index As Long)
        Dim i As Long

        ' Set HP to nothing
        Call SetPlayerVital(Index, Vitals.HP, 0)

        ' Drop all worn items
        For i = 1 To Equipment.Equipment_Count - 1
            If GetPlayerEquipment(Index, i) > 0 Then
                PlayerMapDropItem(Index, GetPlayerEquipment(Index, i), 0)
            End If
        Next

        ' Warp player away
        Call SetPlayerDir(Index, DIR_DOWN)

        With Map(GetPlayerMap(Index))
            ' to the bootmap if it is set
            If .BootMap > 0 Then
                PlayerWarp(Index, .BootMap, .BootX, .BootY)
            Else
                Call PlayerWarp(Index, START_MAP, START_X, START_Y)
            End If
        End With

        ' Clear spell casting
        TempPlayer(Index).SpellBuffer = 0
        TempPlayer(Index).SpellBufferTimer = 0
        Call SendClearSpellBuffer(Index)

        ' Restore vitals
        Call SetPlayerVital(Index, Vitals.HP, GetPlayerMaxVital(Index, Vitals.HP))
        Call SetPlayerVital(Index, Vitals.MP, GetPlayerMaxVital(Index, Vitals.MP))
        Call SetPlayerVital(Index, Vitals.SP, GetPlayerMaxVital(Index, Vitals.SP))
        Call SendVital(Index, Vitals.HP)
        Call SendVital(Index, Vitals.MP)
        Call SendVital(Index, Vitals.SP)

        ' If the player the attacker killed was a pk then take it away
        If GetPlayerPK(Index) = YES Then
            Call SetPlayerPK(Index, NO)
            Call SendPlayerData(Index)
        End If

    End Sub
    Function TakeInvSlot(ByVal Index As Long, ByVal invSlot As Long, ByVal ItemVal As Long) As Boolean
        Dim itemNum

        TakeInvSlot = False

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or invSlot <= 0 Or invSlot > MAX_ITEMS Then
            Exit Function
        End If

        itemNum = GetPlayerInvItemNum(Index, invSlot)

        If Item(itemNum).Type = ITEM_TYPE_CURRENCY Then

            ' Is what we are trying to take away more then what they have?  If so just set it to zero
            If ItemVal >= GetPlayerInvItemValue(Index, invSlot) Then
                TakeInvSlot = True
            Else
                Call SetPlayerInvItemValue(Index, invSlot, GetPlayerInvItemValue(Index, invSlot) - ItemVal)
            End If
        Else
            TakeInvSlot = True
        End If

        If TakeInvSlot Then
            Call SetPlayerInvItemNum(Index, invSlot, 0)
            Call SetPlayerInvItemValue(Index, invSlot, 0)
            Exit Function
        End If

    End Function
    Function GetPlayerVitalRegen(ByVal Index As Long, ByVal Vital As Vitals) As Long
        Dim i As Long

        ' Prevent subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            GetPlayerVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                i = (GetPlayerStat(Index, Stats.vitality) \ 2)
            Case Vitals.MP
                i = (GetPlayerStat(Index, Stats.spirit) \ 2)
            Case Vitals.SP
                i = (GetPlayerStat(Index, Stats.spirit) \ 2)
        End Select

        If i < 2 Then i = 2
        GetPlayerVitalRegen = i
    End Function
    Sub CheckResource(ByVal Index As Long, ByVal x As Long, ByVal y As Long)
        Dim Resource_num As Long
        Dim Resource_index As Long
        Dim rX As Long, rY As Long
        Dim i As Long
        Dim Damage As Long

        If Map(GetPlayerMap(Index)).Tile(x, y).Type = TILE_TYPE_RESOURCE Then
            Resource_num = 0
            Resource_index = Map(GetPlayerMap(Index)).Tile(x, y).Data1

            ' Get the cache number
            For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count

                If ResourceCache(GetPlayerMap(Index)).ResourceData(i).x = x Then
                    If ResourceCache(GetPlayerMap(Index)).ResourceData(i).y = y Then
                        Resource_num = i
                    End If
                End If

            Next

            If Resource_num > 0 Then
                If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
                    If Item(GetPlayerEquipment(Index, Equipment.Weapon)).Data3 = Resource(Resource_index).ToolRequired Then

                        ' inv space?
                        If Resource(Resource_index).ItemReward > 0 Then
                            If FindOpenInvSlot(Index, Resource(Resource_index).ItemReward) = 0 Then
                                PlayerMsg(Index, "You have no inventory space.")
                                Exit Sub
                            End If
                        End If

                        ' check if already cut down
                        If ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceState = 0 Then

                            rX = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).x
                            rY = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).y

                            Damage = Item(GetPlayerEquipment(Index, Equipment.Weapon)).Data2

                            ' check if damage is more than health
                            If Damage > 0 Then
                                ' cut it down!
                                If ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health - Damage <= 0 Then
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceState = 1 ' Cut
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceTimer = GetTickCount()
                                    SendResourceCacheToMap(GetPlayerMap(Index), Resource_num)
                                    SendActionMsg(GetPlayerMap(Index), Trim$(Resource(Resource_index).SuccessMessage), BrightGreen, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                                    GiveInvItem(Index, Resource(Resource_index).ItemReward, 1)
                                    SendAnimation(GetPlayerMap(Index), Resource(Resource_index).Animation, rX, rY)
                                Else
                                    ' just do the damage
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health - Damage
                                    SendActionMsg(GetPlayerMap(Index), "-" & Damage, BrightRed, 1, (rX * 32), (rY * 32))
                                    SendAnimation(GetPlayerMap(Index), Resource(Resource_index).Animation, rX, rY)
                                End If
                                Call CheckTasks(Index, QUEST_TYPE_GOTRAIN, Resource_index)
                            Else
                                ' too weak
                                SendActionMsg(GetPlayerMap(Index), "Miss!", BrightRed, 1, (rX * 32), (rY * 32))
                            End If
                        Else
                            SendActionMsg(GetPlayerMap(Index), Trim$(Resource(Resource_index).EmptyMessage), BrightRed, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                        End If

                    Else
                        PlayerMsg(Index, "You have the wrong type of tool equiped.")
                    End If

                Else
                    PlayerMsg(Index, "You need a tool to interact with this resource.")
                End If
            End If
        End If
    End Sub
    Public Sub BufferSpell(ByVal Index As Long, ByVal spellslot As Long)
        Dim spellnum As Long
        Dim MPCost As Long
        Dim LevelReq As Long
        Dim MapNum As Long
        Dim SpellCastType As Long
        Dim ClassReq As Long
        Dim AccessReq As Long
        Dim range As Long
        Dim HasBuffered As Boolean

        Dim TargetType As Byte
        Dim Target As Long

        ' Prevent subscript out of range
        If spellslot <= 0 Or spellslot > MAX_PLAYER_SPELLS Then Exit Sub

        spellnum = GetPlayerSpell(Index, spellslot)
        MapNum = GetPlayerMap(Index)

        If spellnum <= 0 Or spellnum > MAX_SPELLS Then Exit Sub

        ' Make sure player has the spell
        If Not HasSpell(Index, spellnum) Then Exit Sub

        ' see if cooldown has finished
        If TempPlayer(Index).SpellCD(spellslot) > GetTickCount() Then
            PlayerMsg(Index, "Spell hasn't cooled down yet!")
            Exit Sub
        End If

        MPCost = Spell(spellnum).MPCost

        ' Check if they have enough MP
        If GetPlayerVital(Index, Vitals.MP) < MPCost Then
            Call PlayerMsg(Index, "Not enough mana!")
            Exit Sub
        End If

        LevelReq = Spell(spellnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > GetPlayerLevel(Index) Then
            Call PlayerMsg(Index, "You must be level " & LevelReq & " to cast this spell.")
            Exit Sub
        End If

        AccessReq = Spell(spellnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(Index) Then
            Call PlayerMsg(Index, "You must be an administrator to cast this spell.")
            Exit Sub
        End If

        ClassReq = Spell(spellnum).ClassReq

        ' make sure the classreq > 0
        If ClassReq > 0 Then ' 0 = no req
            If ClassReq <> GetPlayerClass(Index) Then
                Call PlayerMsg(Index, "Only " & CheckGrammar(Trim$(Classes(ClassReq).Name)) & " can use this spell.")
                Exit Sub
            End If
        End If

        ' find out what kind of spell it is! self cast, target or AOE
        If Spell(spellnum).range > 0 Then
            ' ranged attack, single target or aoe?
            If Not Spell(spellnum).IsAoE Then
                SpellCastType = 2 ' targetted
            Else
                SpellCastType = 3 ' targetted aoe
            End If
        Else
            If Not Spell(spellnum).IsAoE Then
                SpellCastType = 0 ' self-cast
            Else
                SpellCastType = 1 ' self-cast AoE
            End If
        End If

        TargetType = TempPlayer(Index).TargetType
        Target = TempPlayer(Index).Target
        range = Spell(spellnum).range
        HasBuffered = False

        Select Case SpellCastType
            Case 0, 1 ' self-cast & self-cast AOE
                HasBuffered = True
            Case 2, 3 ' targeted & targeted AOE
                ' check if have target
                If Not Target > 0 Then
                    PlayerMsg(Index, "You do not have a target.")
                End If
                If TargetType = TARGET_TYPE_PLAYER Then
                    'Housing
                    If Player(Target).InHouse = Player(Index).InHouse Then
                        If CanAttackPlayer(Index, Target, True) Then
                            HasBuffered = True
                        End If
                    End If
                    ' if have target, check in range
                    If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), GetPlayerX(Target), GetPlayerY(Target)) Then
                        PlayerMsg(Index, "Target not in range.")
                    Else
                        ' go through spell types
                        If Spell(spellnum).Type <> SPELL_TYPE_DAMAGEHP And Spell(spellnum).Type <> SPELL_TYPE_DAMAGEMP Then
                            HasBuffered = True
                        Else
                            If CanAttackPlayer(Index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                ElseIf TargetType = TARGET_TYPE_NPC Then
                    ' if have target, check in range
                    If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), MapNpc(MapNum).Npc(Target).x, MapNpc(MapNum).Npc(Target).y) Then
                        PlayerMsg(Index, "Target not in range.")
                        HasBuffered = False
                    Else
                        ' go through spell types
                        If Spell(spellnum).Type <> SPELL_TYPE_DAMAGEHP And Spell(spellnum).Type <> SPELL_TYPE_DAMAGEMP Then
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
            SendAnimation(MapNum, Spell(spellnum).CastAnim, 0, 0, TARGET_TYPE_PLAYER, Index)
            TempPlayer(Index).SpellBuffer = spellslot
            TempPlayer(Index).SpellBufferTimer = GetTickCount()
            Exit Sub
        Else
            SendClearSpellBuffer(Index)
        End If
    End Sub
End Module
