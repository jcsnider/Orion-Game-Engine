Imports System.Threading

Module ServerLoop
    Sub ServerLoop()
        Dim i As Integer
        Dim Tick As Integer
        Dim tmr25 As Integer
        Dim tmr300 As Integer
        Dim tmr500 As Integer
        Dim tmr1000 As Integer, tmrCraft As Integer
        Dim LastUpdateSavePlayers As Integer
        Dim LastUpdateMapSpawnItems As Integer
        Dim LastUpdatePlayerVitals As Integer

        ServerOnline = True

        Do
            Tick = GetTickCount()
            'UpdateUI()
            If ServerDestroyed Then End

            If Tick > tmr25 Then
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) Then
                        ' check if they've completed casting, and if so set the actual skill going
                        If TempPlayer(i).SkillBuffer > 0 Then
                            If GetTickCount() > TempPlayer(i).SkillBufferTimer + (Skill(Player(i).Character(TempPlayer(i).CurChar).Skill(TempPlayer(i).SkillBuffer)).CastTime * 1000) Then
                                CastSkill(i, TempPlayer(i).SkillBuffer)
                                TempPlayer(i).SkillBuffer = 0
                                TempPlayer(i).SkillBufferTimer = 0
                            End If
                        End If
                        ' check if need to turn off stunned
                        If TempPlayer(i).StunDuration > 0 Then
                            If GetTickCount() > TempPlayer(i).StunTimer + (TempPlayer(i).StunDuration * 1000) Then
                                TempPlayer(i).StunDuration = 0
                                TempPlayer(i).StunTimer = 0
                                SendStunned(i)
                            End If
                        End If
                    End If
                Next

                UpdateEventLogic()

                tmr25 = GetTickCount() + 25
            End If

            If Tick > tmr1000 Then
                If isShuttingDown Then
                    HandleShutdown()
                End If

                tmr1000 = GetTickCount() + 1000
            End If

            If Tick > tmrCraft Then
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) Then
                        If TempPlayer(i).CraftIt = 1 Then
                            If GetTickCount() > TempPlayer(i).CraftTimer + (TempPlayer(i).CraftTimeNeeded * 1000) Then
                                TempPlayer(i).CraftIt = 0
                                TempPlayer(i).CraftTimer = 0
                                TempPlayer(i).CraftTimeNeeded = 0
                                UpdateCraft(i)
                            End If
                        End If
                    End If
                Next
                tmrCraft = GetTickCount() + 1000
            End If

            ' Check for disconnections every half second
            If Tick > tmr500 Then

                For i = 1 To MAX_PLAYERS
                    'Housing
                    If IsPlaying(i) Then
                        If Player(i).Character(TempPlayer(i).CurChar).InHouse > 0 Then
                            If IsPlaying(Player(i).Character(TempPlayer(i).CurChar).InHouse) Then
                                If Player(Player(i).Character(TempPlayer(i).CurChar).InHouse).Character(TempPlayer(i).CurChar).InHouse <> Player(i).Character(TempPlayer(i).CurChar).InHouse Then
                                    Player(i).Character(TempPlayer(i).CurChar).InHouse = 0
                                    PlayerWarp(i, Player(i).Character(TempPlayer(i).CurChar).LastMap, Player(i).Character(TempPlayer(i).CurChar).LastX, Player(i).Character(TempPlayer(i).CurChar).LastY)
                                    PlayerMsg(i, "Your visitation has ended. Possibly due to a disconnection. You are being warped back to your previous location.", ColorType.Yellow)
                                End If
                            End If
                        End If
                    End If

                    If Not Clients(i).Socket Is Nothing Then
                        If Not Clients(i).Socket.Connected Then
                            CloseSocket(i)
                        End If
                    End If

                Next

                tmr500 = GetTickCount() + 500

                If GetTickCount() > tmr25 Then
                    UpdateEventLogic()
                    tmr25 = GetTickCount() + 25
                End If
            End If

            If GetTickCount() > tmr300 Then
                UpdateNpcAI()
                tmr300 = GetTickCount() + 300
            End If

            ' Checks to update player vitals every 5 seconds - Can be tweaked
            If Tick > LastUpdatePlayerVitals Then
                UpdatePlayerVitals()
                LastUpdatePlayerVitals = GetTickCount() + 5000
            End If

            ' Checks to spawn map items every 5 minutes - Can be tweaked
            If Tick > LastUpdateMapSpawnItems Then
                UpdateMapSpawnItems()
                LastUpdateMapSpawnItems = GetTickCount() + 300000
            End If

            ' Checks to save players every 10 minutes - Can be tweaked
            If Tick > LastUpdateSavePlayers Then
                UpdateSavePlayers()
                LastUpdateSavePlayers = GetTickCount() + 600000
            End If

            DoEvents()
            'Thread.Yield()
            Thread.Sleep(1)
        Loop
    End Sub

    Private Sub UpdateSavePlayers()
        Dim i As Integer

        If TotalPlayersOnline > 0 Then
            TextAdd("Saving all online players...")
            GlobalMsg("Saving all online players...")

            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) Then
                    SavePlayer(i)
                    SaveBank(i)
                End If

                DoEvents()
            Next

        End If

    End Sub

    Private Sub UpdateMapSpawnItems()
        Dim x As Integer
        Dim y As Integer

        ' ///////////////////////////////////////////
        ' // This is used for respawning map items //
        ' ///////////////////////////////////////////
        For y = 1 To MAX_CACHED_MAPS

            ' Make sure no one is on the map when it respawns
            If Not PlayersOnMap(y) Then

                ' Clear out unnecessary junk
                For x = 1 To MAX_MAP_ITEMS
                    ClearMapItem(x, y)
                Next

                ' Spawn the items
                SpawnMapItems(y)
                SendMapItemsToAll(y)
            End If

            DoEvents()
        Next

    End Sub

    Private Sub UpdatePlayerVitals()
        Dim i As Integer

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerVital(i, Vitals.HP) <> GetPlayerMaxVital(i, Vitals.HP) Then
                    SetPlayerVital(i, Vitals.HP, GetPlayerVital(i, Vitals.HP) + GetPlayerVitalRegen(i, Vitals.HP))
                    SendVital(i, Vitals.HP)
                End If

                If GetPlayerVital(i, Vitals.MP) <> GetPlayerMaxVital(i, Vitals.MP) Then
                    SetPlayerVital(i, Vitals.MP, GetPlayerVital(i, Vitals.MP) + GetPlayerVitalRegen(i, Vitals.MP))
                    SendVital(i, Vitals.MP)
                End If

                If GetPlayerVital(i, Vitals.SP) <> GetPlayerMaxVital(i, Vitals.SP) Then
                    SetPlayerVital(i, Vitals.SP, GetPlayerVital(i, Vitals.SP) + GetPlayerVitalRegen(i, Vitals.SP))
                    SendVital(i, Vitals.SP)
                End If
            End If
            ' send vitals to party if in one
            If TempPlayer(i).InParty > 0 Then SendPartyVitals(TempPlayer(i).InParty, i)
        Next

    End Sub

    Private Sub UpdateNpcAI()
        Dim i As Integer, x As Integer, n As Integer, x1 As Integer, y1 As Integer
        Dim MapNum As Integer, TickCount As Integer
        Dim Damage As Integer
        Dim DistanceX As Integer, DistanceY As Integer
        Dim NpcNum As Integer
        Dim Target As Integer, TargetType As Byte, TargetX As Integer, TargetY As Integer, target_verify As Boolean
        Dim DidWalk As Boolean
        Dim Resource_index As Integer

        For MapNum = 1 To MAX_CACHED_MAPS

            If ServerDestroyed Then End

            '  Close the doors
            If TickCount > TempTile(MapNum).DoorTimer + 5000 Then

                For x1 = 0 To Map(MapNum).MaxX
                    For y1 = 0 To Map(MapNum).MaxY
                        If Map(MapNum).Tile(x1, y1).Type = TileType.Key And TempTile(MapNum).DoorOpen(x1, y1) = True Then
                            TempTile(MapNum).DoorOpen(x1, y1) = False
                            SendMapKeyToMap(MapNum, x1, y1, 0)
                        End If
                    Next
                Next

            End If

            ' Respawning Resources
            If ResourceCache(MapNum).Resource_Count > 0 Then
                For i = 0 To ResourceCache(MapNum).Resource_Count
                    Resource_index = Map(MapNum).Tile(ResourceCache(MapNum).ResourceData(i).x, ResourceCache(MapNum).ResourceData(i).y).Data1

                    If Resource_index > 0 Then
                        If ResourceCache(MapNum).ResourceData(i).ResourceState = 1 Or ResourceCache(MapNum).ResourceData(i).cur_health < 1 Then  ' dead or fucked up
                            If ResourceCache(MapNum).ResourceData(i).ResourceTimer + (Resource(Resource_index).RespawnTime * 1000) < GetTickCount() Then
                                ResourceCache(MapNum).ResourceData(i).ResourceTimer = GetTickCount()
                                ResourceCache(MapNum).ResourceData(i).ResourceState = 0 ' normal
                                ' re-set health to resource root
                                ResourceCache(MapNum).ResourceData(i).cur_health = Resource(Resource_index).Health
                                SendResourceCacheToMap(MapNum, i)
                            End If
                        End If
                    End If
                Next
            End If

            If PlayersOnMap(MapNum) = True Then
                TickCount = GetTickCount()

                For x = 1 To MAX_MAP_NPCS
                    NpcNum = MapNpc(MapNum).Npc(x).Num

                    ' check if they've completed casting, and if so set the actual skill going
                    If MapNpc(MapNum).Npc(x).SkillBuffer > 0 Then
                        If Map(MapNum).Npc(x) > 0 And MapNpc(MapNum).Npc(x).Num > 0 Then
                            If GetTickCount() > MapNpc(MapNum).Npc(x).SkillBufferTimer + (Skill(Npc(NpcNum).Skill(MapNpc(MapNum).Npc(x).SkillBuffer)).CastTime * 1000) Then
                                CastNpcSkill(x, MapNum, MapNpc(MapNum).Npc(x).SkillBuffer)
                                MapNpc(MapNum).Npc(x).SkillBuffer = 0
                                MapNpc(MapNum).Npc(x).SkillBufferTimer = 0
                            End If
                        End If

                    Else
                        ' /////////////////////////////////////////
                        ' // This is used for ATTACKING ON SIGHT //
                        ' /////////////////////////////////////////
                        ' Make sure theres a npc with the map
                        If Map(MapNum).Npc(x) > 0 And MapNpc(MapNum).Npc(x).Num > 0 Then

                            ' If the npc is a attack on sight, search for a player on the map
                            If Npc(NpcNum).Behaviour = NpcBehavior.AttackOnSight Or Npc(NpcNum).Behaviour = NpcBehavior.Guard Then

                                ' make sure it's not stunned
                                If Not MapNpc(MapNum).Npc(x).StunDuration > 0 Then

                                    For i = 1 To MAX_PLAYERS
                                        If IsPlaying(i) Then
                                            If GetPlayerMap(i) = MapNum And MapNpc(MapNum).Npc(x).Target = 0 And GetPlayerAccess(i) <= AdminType.Monitor Then
                                                n = Npc(NpcNum).Range
                                                DistanceX = MapNpc(MapNum).Npc(x).x - GetPlayerX(i)
                                                DistanceY = MapNpc(MapNum).Npc(x).y - GetPlayerY(i)

                                                ' Make sure we get a positive value
                                                If DistanceX < 0 Then DistanceX = DistanceX * -1
                                                If DistanceY < 0 Then DistanceY = DistanceY * -1

                                                ' Are they in range?  if so GET'M!
                                                If DistanceX <= n And DistanceY <= n Then
                                                    If Npc(NpcNum).Behaviour = NpcBehavior.AttackOnSight Or GetPlayerPK(i) = True Then
                                                        If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                                                            PlayerMsg(i, CheckGrammar(Trim$(Npc(NpcNum).Name), 1) & " says, '" & Trim$(Npc(NpcNum).AttackSay) & "' to you.", ColorType.Yellow)
                                                        End If
                                                        MapNpc(MapNum).Npc(x).TargetType = 1 ' player
                                                        MapNpc(MapNum).Npc(x).Target = i
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next

                                    ' Check if target was found for NPC targetting
                                    If MapNpc(MapNum).Npc(x).Target = 0 Then
                                        ' make sure it belongs to a faction
                                        If Npc(NpcNum).Faction > 0 Then
                                            ' search for npc of another faction to target
                                            For i = 1 To MAX_MAP_NPCS
                                                ' exist?
                                                If MapNpc(MapNum).Npc(i).Num > 0 Then
                                                    ' different faction?
                                                    If Npc(MapNpc(MapNum).Npc(i).Num).Faction > 0 Then
                                                        If Npc(MapNpc(MapNum).Npc(i).Num).Faction <> Npc(NpcNum).Faction Then
                                                            n = Npc(NpcNum).Range
                                                            DistanceX = MapNpc(MapNum).Npc(x).x - CLng(MapNpc(MapNum).Npc(i).x)
                                                            DistanceY = MapNpc(MapNum).Npc(x).y - CLng(MapNpc(MapNum).Npc(i).y)

                                                            ' Make sure we get a positive value
                                                            If DistanceX < 0 Then DistanceX = DistanceX * -1
                                                            If DistanceY < 0 Then DistanceY = DistanceY * -1

                                                            ' Are they in range?  if so GET'M!
                                                            If DistanceX <= n And DistanceY <= n Then
                                                                If Npc(NpcNum).Behaviour = NpcBehavior.AttackOnSight Then
                                                                    MapNpc(MapNum).Npc(x).TargetType = 2 ' npc
                                                                    MapNpc(MapNum).Npc(x).Target = i
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            End If
                        End If

                        target_verify = False

                        ' /////////////////////////////////////////////
                        ' // This is used for NPC walking/targetting //
                        ' /////////////////////////////////////////////
                        ' Make sure theres a npc with the map
                        If Map(MapNum).Npc(x) > 0 And MapNpc(MapNum).Npc(x).Num > 0 Then
                            If MapNpc(MapNum).Npc(x).StunDuration > 0 Then
                                ' check if we can unstun them
                                If GetTickCount() > MapNpc(MapNum).Npc(x).StunTimer + (MapNpc(MapNum).Npc(x).StunDuration * 1000) Then
                                    MapNpc(MapNum).Npc(x).StunDuration = 0
                                    MapNpc(MapNum).Npc(x).StunTimer = 0
                                End If
                            Else

                                Target = MapNpc(MapNum).Npc(x).Target
                                TargetType = MapNpc(MapNum).Npc(x).TargetType

                                ' Check to see if its time for the npc to walk
                                If Npc(NpcNum).Behaviour <> NpcBehavior.ShopKeeper And Npc(NpcNum).Behaviour <> NpcBehavior.Quest Then

                                    If TargetType = 1 Then ' player

                                        ' Check to see if we are following a player or not
                                        If Target > 0 Then

                                            ' Check if the player is even playing, if so follow'm
                                            If IsPlaying(Target) And GetPlayerMap(Target) = MapNum Then
                                                DidWalk = False
                                                target_verify = True
                                                TargetY = GetPlayerY(Target)
                                                TargetX = GetPlayerX(Target)
                                            Else
                                                MapNpc(MapNum).Npc(x).TargetType = 0 ' clear
                                                MapNpc(MapNum).Npc(x).Target = 0
                                            End If
                                        End If

                                    ElseIf TargetType = 2 Then 'npc

                                        If Target > 0 Then

                                            If MapNpc(MapNum).Npc(Target).Num > 0 Then
                                                DidWalk = False
                                                target_verify = True
                                                TargetY = MapNpc(MapNum).Npc(Target).y
                                                TargetX = MapNpc(MapNum).Npc(Target).x
                                            Else
                                                MapNpc(MapNum).Npc(x).TargetType = 0 ' clear
                                                MapNpc(MapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    End If

                                    If target_verify Then
                                        'Gonna make the npcs smarter.. Implementing a pathfinding algorithm.. we shall see what happens.
                                        If IsOneBlockAway(TargetX, TargetY, CLng(MapNpc(MapNum).Npc(x).x), CLng(MapNpc(MapNum).Npc(x).y)) = False Then
                                            If PathfindingType = 1 Then
                                                i = Int(Rnd() * 5)

                                                ' Lets move the npc
                                                Select Case i
                                                    Case 0

                                                        ' Up
                                                        If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Up) Then
                                                                NpcMove(MapNum, x, Direction.Up, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Down
                                                        If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Down) Then
                                                                NpcMove(MapNum, x, Direction.Down, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Left
                                                        If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Left) Then
                                                                NpcMove(MapNum, x, Direction.Left, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Right
                                                        If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Right) Then
                                                                NpcMove(MapNum, x, Direction.Right, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                    Case 1

                                                        ' Right
                                                        If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Right) Then
                                                                NpcMove(MapNum, x, Direction.Right, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Left
                                                        If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Left) Then
                                                                NpcMove(MapNum, x, Direction.Left, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Down
                                                        If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Down) Then
                                                                NpcMove(MapNum, x, Direction.Down, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Up
                                                        If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Up) Then
                                                                NpcMove(MapNum, x, Direction.Up, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                    Case 2

                                                        ' Down
                                                        If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Down) Then
                                                                NpcMove(MapNum, x, Direction.Down, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Up
                                                        If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Up) Then
                                                                NpcMove(MapNum, x, Direction.Up, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Right
                                                        If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Right) Then
                                                                NpcMove(MapNum, x, Direction.Right, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Left
                                                        If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Left) Then
                                                                NpcMove(MapNum, x, Direction.Left, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                    Case 3

                                                        ' Left
                                                        If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Left) Then
                                                                NpcMove(MapNum, x, Direction.Left, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Right
                                                        If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Right) Then
                                                                NpcMove(MapNum, x, Direction.Right, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Up
                                                        If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Up) Then
                                                                NpcMove(MapNum, x, Direction.Up, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                        ' Down
                                                        If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                            If CanNpcMove(MapNum, x, Direction.Down) Then
                                                                NpcMove(MapNum, x, Direction.Down, MovementType.Walking)
                                                                DidWalk = True
                                                            End If
                                                        End If

                                                End Select

                                                ' Check if we can't move and if Target is behind something and if we can just switch dirs
                                                If Not DidWalk Then
                                                    If MapNpc(MapNum).Npc(x).x - 1 = TargetX And MapNpc(MapNum).Npc(x).y = TargetY Then
                                                        If MapNpc(MapNum).Npc(x).Dir <> Direction.Left Then
                                                            NpcDir(MapNum, x, Direction.Left)
                                                        End If

                                                        DidWalk = True
                                                    End If

                                                    If MapNpc(MapNum).Npc(x).x + 1 = TargetX And MapNpc(MapNum).Npc(x).y = TargetY Then
                                                        If MapNpc(MapNum).Npc(x).Dir <> Direction.Right Then
                                                            NpcDir(MapNum, x, Direction.Right)
                                                        End If

                                                        DidWalk = True
                                                    End If

                                                    If MapNpc(MapNum).Npc(x).x = TargetX And MapNpc(MapNum).Npc(x).y - 1 = TargetY Then
                                                        If MapNpc(MapNum).Npc(x).Dir <> Direction.Up Then
                                                            NpcDir(MapNum, x, Direction.Up)
                                                        End If

                                                        DidWalk = True
                                                    End If

                                                    If MapNpc(MapNum).Npc(x).x = TargetX And MapNpc(MapNum).Npc(x).y + 1 = TargetY Then
                                                        If MapNpc(MapNum).Npc(x).Dir <> Direction.Down Then
                                                            NpcDir(MapNum, x, Direction.Down)
                                                        End If

                                                        DidWalk = True
                                                    End If

                                                    ' We could not move so Target must be behind something, walk randomly.
                                                    If Not DidWalk Then
                                                        i = Int(Rnd() * 2)

                                                        If i = 1 Then
                                                            i = Int(Rnd() * 4)

                                                            If CanNpcMove(MapNum, x, i) Then
                                                                NpcMove(MapNum, x, i, MovementType.Walking)
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Else
                                                i = FindNpcPath(MapNum, x, TargetX, TargetY)
                                                If i < 4 Then 'Returned an answer. Move the NPC
                                                    If CanNpcMove(MapNum, x, i) Then
                                                        NpcMove(MapNum, x, i, MovementType.Walking)
                                                    End If
                                                Else 'No good path found. Move randomly
                                                    i = Int(Rnd() * 4)
                                                    If i = 1 Then
                                                        i = Int(Rnd() * 4)

                                                        If CanNpcMove(MapNum, x, i) Then
                                                            NpcMove(MapNum, x, i, MovementType.Walking)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else

                                            NpcDir(MapNum, x, GetNpcDir(TargetX, TargetY, CLng(MapNpc(MapNum).Npc(x).x), CLng(MapNpc(MapNum).Npc(x).y)))
                                        End If
                                    Else
                                        i = Int(Rnd() * 4)

                                        If i = 1 Then
                                            i = Int(Rnd() * 4)

                                            If CanNpcMove(MapNum, x, i) Then
                                                NpcMove(MapNum, x, i, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If


                    End If

                    ' /////////////////////////////////////////////
                    ' // This is used for npcs to attack targets //
                    ' /////////////////////////////////////////////
                    ' Make sure theres a npc with the map
                    If Map(MapNum).Npc(x) > 0 And MapNpc(MapNum).Npc(x).Num > 0 Then
                        Target = MapNpc(MapNum).Npc(x).Target
                        TargetType = MapNpc(MapNum).Npc(x).TargetType

                        ' Check if the npc can attack the targeted player player
                        If Target > 0 Then

                            If TargetType = 1 Then ' player

                                ' Is the target playing and on the same map?
                                If IsPlaying(Target) And GetPlayerMap(Target) = MapNum Then
                                    'Can the npc attack the player?
                                    If CanNpcAttackPlayer(x, Target) Then
                                        If Not CanPlayerBlockHit(Target) Then
                                            If Random(1, 3) = 1 Then
                                                'Damage = Npc(NpcNum).Stat(StatType.Strength) - GetPlayerProtection(Target)
                                                Dim skillnum As Byte = RandomNpcAttack(MapNum, x)
                                                If skillnum > 0 Then
                                                    BufferNpcSkill(MapNum, x, skillnum)
                                                Else
                                                    NpcAttackPlayer(x, Target) ', Damage)
                                                End If
                                            Else
                                                NpcAttackPlayer(x, Target) ', Damage)
                                            End If

                                        Else
                                            PlayerMsg(Target, "Your " & Trim$(Item(GetPlayerEquipment(Target, EquipmentType.Shield)).Name) & " blocks the " & Trim$(Npc(NpcNum).Name) & "'s hit!", ColorType.BrightGreen)
                                            SendActionMsg(GetPlayerMap(Target), "BLOCK!", ColorType.Cyan, 1, (GetPlayerX(Target) * 32), (GetPlayerY(Target) * 32))
                                        End If
                                    End If

                                Else
                                    ' Player left map or game, set target to 0
                                    MapNpc(MapNum).Npc(x).Target = 0
                                    MapNpc(MapNum).Npc(x).TargetType = 0 ' clear
                                End If
                            Else
                                If MapNpc(MapNum).Npc(Target).Num > 0 Then ' npc exists
                                    'Can the npc attack the npc?
                                    If CanNpcAttackNpc(MapNum, x, Target) Then
                                        Damage = Npc(NpcNum).Stat(Stats.Strength) - CLng(Npc(Target).Stat(Stats.Endurance))
                                        If Damage < 1 Then Damage = 1
                                        NpcAttackNpc(MapNum, x, Target, Damage)
                                    End If

                                Else
                                    ' npc is dead or non-existant
                                    MapNpc(MapNum).Npc(x).Target = 0
                                    MapNpc(MapNum).Npc(x).TargetType = 0 ' clear
                                End If
                            End If
                        End If
                    End If

                    ' ////////////////////////////////////////////
                    ' // This is used for regenerating NPC's HP //
                    ' ////////////////////////////////////////////
                    ' Check to see if we want to regen some of the npc's hp
                    If MapNpc(MapNum).Npc(x).Num > 0 And TickCount > GiveNPCHPTimer + 10000 Then
                        If MapNpc(MapNum).Npc(x).Vital(Vitals.HP) > 0 Then
                            MapNpc(MapNum).Npc(x).Vital(Vitals.HP) = MapNpc(MapNum).Npc(x).Vital(Vitals.HP) + GetNpcVitalRegen(NpcNum, Vitals.HP)

                            ' Check if they have more then they should and if so just set it to max
                            If MapNpc(MapNum).Npc(x).Vital(Vitals.HP) > GetNpcMaxVital(NpcNum, Vitals.HP) Then
                                MapNpc(MapNum).Npc(x).Vital(Vitals.HP) = GetNpcMaxVital(NpcNum, Vitals.HP)
                            End If
                        End If
                    End If

                    If MapNpc(MapNum).Npc(x).Num > 0 And TickCount > GiveNPCMPTimer + 10000 Then
                        If MapNpc(MapNum).Npc(x).Vital(Vitals.MP) > 0 Then
                            MapNpc(MapNum).Npc(x).Vital(Vitals.MP) = MapNpc(MapNum).Npc(x).Vital(Vitals.MP) + GetNpcVitalRegen(NpcNum, Vitals.MP)

                            ' Check if they have more then they should and if so just set it to max
                            If MapNpc(MapNum).Npc(x).Vital(Vitals.MP) > GetNpcMaxVital(NpcNum, Vitals.MP) Then
                                MapNpc(MapNum).Npc(x).Vital(Vitals.MP) = GetNpcMaxVital(NpcNum, Vitals.MP)
                            End If
                        End If
                    End If

                    ' ////////////////////////////////////////////////////////
                    ' // This is used for checking if an NPC is dead or not //
                    ' ////////////////////////////////////////////////////////
                    ' Check if the npc is dead or not
                    'If MapNpc(y, x).Num > 0 Then
                    '    If MapNpc(y, x).HP <= 0 And Npc(MapNpc(y, x).Num).STR > 0 And Npc(MapNpc(y, x).Num).DEF > 0 Then
                    '        MapNpc(y, x).Num = 0
                    '        MapNpc(y, x).SpawnWait = TickCount
                    '   End If
                    'End If

                    ' //////////////////////////////////////
                    ' // This is used for spawning an NPC //
                    ' //////////////////////////////////////
                    ' Check if we are supposed to spawn an npc or not
                    If MapNpc(MapNum).Npc(x).Num = 0 And Map(MapNum).Npc(x) > 0 Then
                        If TickCount > MapNpc(MapNum).Npc(x).SpawnWait + (Npc(Map(MapNum).Npc(x)).SpawnSecs * 1000) Then
                            SpawnNpc(x, MapNum)
                        End If
                    End If

                Next

            End If

            DoEvents()
        Next

        ' Make sure we reset the timer for npc hp regeneration
        If GetTickCount() > GiveNPCHPTimer + 10000 Then
            GiveNPCHPTimer = GetTickCount()
        End If
        If GetTickCount() > GiveNPCMPTimer + 10000 Then
            GiveNPCMPTimer = GetTickCount()
        End If

        ' Make sure we reset the timer for door closing
        If GetTickCount() > KeyTimer + 15000 Then
            KeyTimer = GetTickCount()
        End If

    End Sub

    Function GetNpcVitalRegen(ByVal NpcNum As Integer, ByVal Vital As Vitals) As Integer
        Dim i As Integer

        'Prevent subscript out of range
        If NpcNum <= 0 Or NpcNum > MAX_NPCS Then
            GetNpcVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                i = Npc(NpcNum).Stat(Stats.Vitality) \ 3

                If i < 1 Then i = 1
                GetNpcVitalRegen = i
            Case Vitals.MP
                i = Npc(NpcNum).Stat(Stats.intelligence) \ 3

                If i < 1 Then i = 1
                GetNpcVitalRegen = i
        End Select

    End Function

    Public Sub CastSkill(ByVal Index As Integer, ByVal skillslot As Integer)
        Dim skillnum As Integer, MPCost As Integer, LevelReq As Integer
        Dim MapNum As Integer, Vital As Integer, DidCast As Boolean
        Dim ClassReq As Integer, AccessReq As Integer, i As Integer
        Dim AoE As Integer, range As Integer, VitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer

        Dim TargetType As Byte
        Dim Target As Integer
        Dim SkillCastType As Integer

        DidCast = False

        ' Prevent subscript out of range
        If skillslot <= 0 Or skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        skillnum = GetPlayerSkill(Index, skillslot)
        MapNum = GetPlayerMap(Index)

        ' Make sure player has the skill
        If Not HasSkill(Index, skillnum) Then Exit Sub

        MPCost = Skill(skillnum).MPCost

        ' Check if they have enough MP
        If GetPlayerVital(Index, Enums.Vitals.MP) < MPCost Then
            PlayerMsg(Index, "Not enough mana!", ColorType.BrightRed)
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
                PlayerMsg(Index, "Only " & CheckGrammar(Trim$(Classes(ClassReq).Name)) & " can use this skill.", ColorType.BrightRed)
                Exit Sub
            End If
        End If

        ' find out what kind of skill it is! self cast, target or AOE
        If Skill(skillnum).IsProjectile = 1 Then
            SkillCastType = 4 ' Projectile
        ElseIf Skill(skillnum).range > 0 Then
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

        ' set the vital
        Vital = Skill(skillnum).Vital
        AoE = Skill(skillnum).AoE
        range = Skill(skillnum).range

        Select Case SkillCastType
            Case 0 ' self-cast target
                Select Case Skill(skillnum).Type
                    Case SkillType.HealHp
                        SkillPlayer_Effect(Enums.Vitals.HP, True, Index, Vital, skillnum)
                        DidCast = True
                    Case SkillType.HealMp
                        SkillPlayer_Effect(Enums.Vitals.MP, True, Index, Vital, skillnum)
                        DidCast = True
                    Case SkillType.Warp
                        SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Player, Index)
                        PlayerWarp(Index, Skill(skillnum).Map, Skill(skillnum).x, Skill(skillnum).y)
                        SendAnimation(GetPlayerMap(Index), Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Player, Index)
                        DidCast = True
                End Select

            Case 1, 3 ' self-cast AOE & targetted AOE
                If SkillCastType = 1 Then
                    x = GetPlayerX(Index)
                    y = GetPlayerY(Index)
                ElseIf SkillCastType = 3 Then
                    TargetType = TempPlayer(Index).TargetType
                    Target = TempPlayer(Index).Target

                    If TargetType = 0 Then Exit Sub
                    If Target = 0 Then Exit Sub

                    If TempPlayer(Index).TargetType = Enums.TargetType.Player Then
                        x = GetPlayerX(Target)
                        y = GetPlayerY(Target)
                    Else
                        x = MapNpc(MapNum).Npc(Target).x
                        y = MapNpc(MapNum).Npc(Target).y
                    End If

                    If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), x, y) Then
                        PlayerMsg(Index, "Target not in range.", ColorType.BrightRed)
                        SendClearSkillBuffer(Index)
                    End If
                End If
                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        DidCast = True
                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                If i <> Index Then
                                    If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                        If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                            If CanAttackPlayer(Index, i, True) Then
                                                SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Player, i)
                                                AttackPlayer(Index, i, Vital, skillnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Enums.Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        If CanAttackNpc(Index, i, True) Then
                                            SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Npc, i)
                                            AttackNpc(Index, i, Vital, skillnum)
                                            If Skill(skillnum).KnockBack = 1 Then
                                                KnockBackNpc(Index, Target, skillnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Case SkillType.HealHp, SkillType.HealMp, SkillType.DamageMp
                        If Skill(skillnum).Type = SkillType.HealHp Then
                            VitalType = Enums.Vitals.HP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            VitalType = Enums.Vitals.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.DamageMp Then
                            VitalType = Enums.Vitals.MP
                            increment = False
                        End If

                        DidCast = True
                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                    If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        SkillPlayer_Effect(VitalType, increment, i, Vital, skillnum)
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Enums.Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        SkillNpc_Effect(VitalType, increment, i, Vital, skillnum, MapNum)
                                    End If
                                End If
                            End If
                        Next
                End Select

            Case 2 ' targetted

                TargetType = TempPlayer(Index).TargetType
                Target = TempPlayer(Index).Target

                If TargetType = 0 Then Exit Sub
                If Target = 0 Then Exit Sub

                If TempPlayer(Index).TargetType = Enums.TargetType.Player Then
                    x = GetPlayerX(Target)
                    y = GetPlayerY(Target)
                Else
                    x = MapNpc(MapNum).Npc(Target).x
                    y = MapNpc(MapNum).Npc(Target).y
                End If

                If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), x, y) Then
                    PlayerMsg(Index, "Target not in range.", ColorType.BrightRed)
                    SendClearSkillBuffer(Index)
                    Exit Sub
                End If

                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        If TempPlayer(Index).TargetType = Enums.TargetType.Player Then
                            If CanAttackPlayer(Index, Target, True) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Player, Target)
                                    AttackPlayer(Index, Target, Vital, skillnum)
                                    DidCast = True
                                End If
                            End If
                        Else
                            If CanAttackNpc(Index, Target, True) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Npc, Target)
                                    AttackNpc(Index, Target, Vital, skillnum)
                                    If Skill(skillnum).KnockBack = 1 Then
                                        KnockBackNpc(Index, Target, skillnum)
                                    End If
                                    DidCast = True
                                End If
                            End If
                        End If

                    Case SkillType.DamageMp, SkillType.HealMp, SkillType.HealHp
                        If Skill(skillnum).Type = SkillType.DamageMp Then
                            VitalType = Enums.Vitals.MP
                            increment = False
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            VitalType = Enums.Vitals.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealHp Then
                            VitalType = Enums.Vitals.HP
                            increment = True
                        End If

                        If TempPlayer(Index).TargetType = Enums.TargetType.Player Then
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanAttackPlayer(Index, Target, True) Then
                                    SkillPlayer_Effect(VitalType, increment, Target, Vital, skillnum)
                                End If
                            Else
                                SkillPlayer_Effect(VitalType, increment, Target, Vital, skillnum)
                            End If
                        Else
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanAttackNpc(Index, Target, True) Then
                                    SkillNpc_Effect(VitalType, increment, Target, Vital, skillnum, MapNum)
                                End If
                            Else
                                SkillNpc_Effect(VitalType, increment, Target, Vital, skillnum, MapNum)
                            End If
                        End If
                End Select
            Case 4 ' Projectile
                PlayerFireProjectile(Index, skillnum)

                DidCast = True
        End Select

        If DidCast Then
            SetPlayerVital(Index, Enums.Vitals.MP, GetPlayerVital(Index, Enums.Vitals.MP) - MPCost)
            SendVital(Index, Enums.Vitals.MP)
            TempPlayer(Index).SkillCD(skillslot) = GetTickCount() + (Skill(skillnum).CDTime * 1000)
            SendCooldown(Index, skillslot)
        End If
    End Sub

    Public Sub CastNpcSkill(ByVal NpcNum As Integer, ByVal MapNum As Integer, ByVal skillslot As Integer)
        Dim skillnum As Integer, MPCost As Integer
        Dim Vital As Integer, DidCast As Boolean
        Dim i As Integer
        Dim AoE As Integer, range As Integer, VitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer

        Dim TargetType As Byte
        Dim Target As Integer
        Dim SkillCastType As Integer

        DidCast = False

        ' Prevent subscript out of range
        If skillslot <= 0 Or skillslot > MAX_NPC_SKILLS Then Exit Sub

        skillnum = GetNpcSkill(MapNpc(MapNum).Npc(NpcNum).Num, skillslot)

        MPCost = Skill(skillnum).MPCost

        ' Check if they have enough MP
        If MapNpc(MapNum).Npc(NpcNum).Vital(Enums.Vitals.MP) < MPCost Then Exit Sub

        ' find out what kind of skill it is! self cast, target or AOE
        If Skill(skillnum).IsProjectile = 1 Then
            SkillCastType = 4 ' Projectile
        ElseIf Skill(skillnum).range > 0 Then
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

        ' set the vital
        Vital = Skill(skillnum).Vital
        AoE = Skill(skillnum).AoE
        range = Skill(skillnum).range

        Select Case SkillCastType
            Case 0 ' self-cast target
                'Select Case Skill(skillnum).Type
                '    Case SkillType.HEALHP
                '        SkillPlayer_Effect(VitalType.HP, True, NpcNum, Vital, skillnum)
                '        DidCast = True
                '    Case SkillType.HEALMP
                '        SkillPlayer_Effect(VitalType.MP, True, NpcNum, Vital, skillnum)
                '        DidCast = True
                '    Case SkillType.WARP
                '        SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.PLAYER, NpcNum)
                '        PlayerWarp(NpcNum, Skill(skillnum).Map, Skill(skillnum).x, Skill(skillnum).y)
                '        SendAnimation(GetPlayerMap(NpcNum), Skill(skillnum).SkillAnim, 0, 0, TargetType.PLAYER, NpcNum)
                '        DidCast = True
                'End Select

            Case 1, 3 ' self-cast AOE & targetted AOE
                If SkillCastType = 1 Then
                    x = MapNpc(MapNum).Npc(NpcNum).x
                    y = MapNpc(MapNum).Npc(NpcNum).y
                ElseIf SkillCastType = 3 Then
                    TargetType = MapNpc(MapNum).Npc(NpcNum).TargetType
                    Target = MapNpc(MapNum).Npc(NpcNum).Target

                    If TargetType = 0 Then Exit Sub
                    If Target = 0 Then Exit Sub

                    If TargetType = Enums.TargetType.Player Then
                        x = GetPlayerX(Target)
                        y = GetPlayerY(Target)
                    Else
                        x = MapNpc(MapNum).Npc(Target).x
                        y = MapNpc(MapNum).Npc(Target).y
                    End If

                    If Not isInRange(range, x, y, GetPlayerX(NpcNum), GetPlayerY(NpcNum)) Then
                        Exit Sub
                    End If
                End If
                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        DidCast = True
                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = MapNum Then
                                    If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        If CanNpcAttackPlayer(NpcNum, i) Then
                                            SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Player, i)
                                            PlayerMsg(i, Trim(Npc(MapNpc(MapNum).Npc(NpcNum).Num).Name) & " uses " & Trim(Skill(skillnum).Name) & "!", ColorType.Yellow)
                                            AttackPlayer(NpcNum, i, Vital, skillnum, NpcNum)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Enums.Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        If CanAttackNpc(NpcNum, i, True) Then
                                            SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Npc, i)
                                            AttackNpc(NpcNum, i, Vital, skillnum)
                                            If Skill(skillnum).KnockBack = 1 Then
                                                KnockBackNpc(NpcNum, Target, skillnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Case SkillType.HealHp, SkillType.HealMp, SkillType.DamageMp
                        If Skill(skillnum).Type = SkillType.HealHp Then
                            VitalType = Enums.Vitals.HP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            VitalType = Enums.Vitals.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.DamageMp Then
                            VitalType = Enums.Vitals.MP
                            increment = False
                        End If

                        DidCast = True
                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = GetPlayerMap(NpcNum) Then
                                    If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        SkillPlayer_Effect(VitalType, increment, i, Vital, skillnum)
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Enums.Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        SkillNpc_Effect(VitalType, increment, i, Vital, skillnum, MapNum)
                                    End If
                                End If
                            End If
                        Next
                End Select

            Case 2 ' targetted

                TargetType = MapNpc(MapNum).Npc(NpcNum).TargetType
                Target = MapNpc(MapNum).Npc(NpcNum).Target

                If TargetType = 0 Then Exit Sub
                If Target = 0 Then Exit Sub

                If MapNpc(MapNum).Npc(NpcNum).TargetType = Enums.TargetType.Player Then
                    x = GetPlayerX(Target)
                    y = GetPlayerY(Target)
                Else
                    x = MapNpc(MapNum).Npc(Target).x
                    y = MapNpc(MapNum).Npc(Target).y
                End If

                If Not isInRange(range, MapNpc(MapNum).Npc(NpcNum).x, MapNpc(MapNum).Npc(NpcNum).y, x, y) Then
                    Exit Sub
                End If

                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        If MapNpc(MapNum).Npc(NpcNum).TargetType = Enums.TargetType.Player Then
                            If CanNpcAttackPlayer(NpcNum, Target) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Player, Target)
                                    PlayerMsg(Target, Trim(Npc(MapNpc(MapNum).Npc(NpcNum).Num).Name) & " uses " & Trim(Skill(skillnum).Name) & "!", ColorType.Yellow)
                                    AttackPlayer(NpcNum, Target, Vital, skillnum, NpcNum)
                                    DidCast = True
                                End If
                            End If
                        Else
                            If CanAttackNpc(NpcNum, Target, True) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, Enums.TargetType.Npc, Target)
                                    AttackNpc(NpcNum, Target, Vital, skillnum)
                                    If Skill(skillnum).KnockBack = 1 Then
                                        KnockBackNpc(NpcNum, Target, skillnum)
                                    End If
                                    DidCast = True
                                End If
                            End If
                        End If

                    Case SkillType.DamageMp, SkillType.HealMp, SkillType.HealHp
                        If Skill(skillnum).Type = SkillType.DamageMp Then
                            VitalType = Enums.Vitals.MP
                            increment = False
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            VitalType = Enums.Vitals.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealHp Then
                            VitalType = Enums.Vitals.HP
                            increment = True
                        End If

                        If TempPlayer(NpcNum).TargetType = Enums.TargetType.Player Then
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanAttackPlayer(NpcNum, Target, True) Then
                                    SkillPlayer_Effect(VitalType, increment, Target, Vital, skillnum)
                                End If
                            Else
                                SkillPlayer_Effect(VitalType, increment, Target, Vital, skillnum)
                            End If
                        Else
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanAttackNpc(NpcNum, Target, True) Then
                                    SkillNpc_Effect(VitalType, increment, Target, Vital, skillnum, MapNum)
                                End If
                            Else
                                SkillNpc_Effect(VitalType, increment, Target, Vital, skillnum, MapNum)
                            End If
                        End If
                End Select
            Case 4 ' Projectile
                PlayerFireProjectile(NpcNum, skillnum)

                DidCast = True
        End Select

        If DidCast Then
            MapNpc(MapNum).Npc(NpcNum).Vital(Enums.Vitals.MP) = MapNpc(MapNum).Npc(NpcNum).Vital(Enums.Vitals.MP) - MPCost
            SendMapNpcVitals(MapNum, NpcNum)
            MapNpc(MapNum).Npc(NpcNum).SkillCD(skillslot) = GetTickCount() + (Skill(skillnum).CDTime * 1000)
        End If
    End Sub

    Public Sub SkillPlayer_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Integer, ByVal Damage As Integer, ByVal Skillnum As Integer)
        Dim sSymbol As String
        Dim Colour As Integer

        If Damage > 0 Then
            If increment Then
                sSymbol = "+"
                If Vital = Vitals.HP Then Colour = ColorType.BrightGreen
                If Vital = Vitals.MP Then Colour = ColorType.BrightBlue
            Else
                sSymbol = "-"
                Colour = ColorType.Blue
            End If

            SendAnimation(GetPlayerMap(Index), Skill(Skillnum).SkillAnim, 0, 0, TargetType.Player, Index)
            SendActionMsg(GetPlayerMap(Index), sSymbol & Damage, Colour, ActionMsgType.Scroll, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
            If increment Then SetPlayerVital(Index, Vital, GetPlayerVital(Index, Vital) + Damage)
            If Not increment Then SetPlayerVital(Index, Vital, GetPlayerVital(Index, Vital) - Damage)
        End If
    End Sub

    Public Sub SkillNpc_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Integer, ByVal Damage As Integer, ByVal skillnum As Integer, ByVal MapNum As Integer)
        Dim sSymbol As String
        Dim Colour As Integer

        If Damage > 0 Then
            If increment Then
                sSymbol = "+"
                If Vital = Vitals.HP Then Colour = ColorType.BrightGreen
                If Vital = Vitals.MP Then Colour = ColorType.BrightBlue
            Else
                sSymbol = "-"
                Colour = ColorType.Blue
            End If

            SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.Npc, Index)
            SendActionMsg(MapNum, sSymbol & Damage, Colour, ActionMsgType.Scroll, MapNpc(MapNum).Npc(Index).x * 32, MapNpc(MapNum).Npc(Index).y * 32)
            If increment Then MapNpc(MapNum).Npc(Index).Vital(Vital) = MapNpc(MapNum).Npc(Index).Vital(Vital) + Damage
            If Not increment Then MapNpc(MapNum).Npc(Index).Vital(Vital) = MapNpc(MapNum).Npc(Index).Vital(Vital) - Damage
        End If
    End Sub
End Module
