﻿Module modServerLoop
    Sub ServerLoop()
        Dim i As Long
        Dim Tick As Long
        Dim tmr25 As Long
        Dim tmr500 As Long
        Dim tmr1000 As Long
        Dim LastUpdateSavePlayers As Long
        Dim LastUpdateMapSpawnItems As Long
        Dim LastUpdatePlayerVitals As Long

        ServerOnline = True

        Do
            Tick = GetTickCount()
            UpdateUI()
            If ServerDestroyed Then End

            If Tick > tmr25 Then
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) Then
                        ' check if they've completed casting, and if so set the actual spell going
                        If TempPlayer(i).SpellBuffer > 0 Then
                            If GetTickCount() > TempPlayer(i).SpellBufferTimer + (Spell(Player(i).Spell(TempPlayer(i).SpellBuffer)).CastTime * 1000) Then
                                CastSpell(i, TempPlayer(i).SpellBuffer)
                                TempPlayer(i).SpellBuffer = 0
                                TempPlayer(i).SpellBufferTimer = 0
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
                tmr25 = GetTickCount() + 25
            End If


            If Tick > tmr1000 Then
                If isShuttingDown Then
                    Call HandleShutdown()
                End If

                tmr1000 = GetTickCount() + 1000
            End If

            ' Check for disconnections every half second
            If Tick > tmr500 Then

                For i = 1 To MAX_PLAYERS
                    If Not Clients(i).Socket Is Nothing Then
                        If Not Clients(i).Socket.Connected Then
                            Call CloseSocket(i)
                        End If
                    End If

                Next

                UpdateNpcAI()
                tmr500 = GetTickCount() + 500
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
            Sleep(1)
        Loop
    End Sub
    Private Sub UpdateSavePlayers()
        Dim i As Long

        If TotalPlayersOnline > 0 Then
            Call TextAdd("Sauvegarde de tous les joueurs en ligne...")
            Call GlobalMsg("Sauvegarde de tous les joueurs en ligne...")

            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) Then
                    Call SavePlayer(i)
                    Call SaveBank(i)
                End If

                DoEvents()
            Next

        End If

    End Sub
    Private Sub UpdateMapSpawnItems()
        Dim x As Long
        Dim y As Long

        ' ///////////////////////////////////////////
        ' // This is used for respawning map items //
        ' ///////////////////////////////////////////
        For y = 1 To MAX_MAPS

            ' Make sure no one is on the map when it respawns
            If Not PlayersOnMap(y) Then

                ' Clear out unnecessary junk
                For x = 1 To MAX_MAP_ITEMS
                    Call ClearMapItem(x, y)
                Next

                ' Spawn the items
                Call SpawnMapItems(y)
                Call SendMapItemsToAll(y)
            End If

            DoEvents()
        Next

    End Sub
    Private Sub UpdatePlayerVitals()
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerVital(i, Vitals.HP) <> GetPlayerMaxVital(i, Vitals.HP) Then
                    Call SetPlayerVital(i, Vitals.HP, GetPlayerVital(i, Vitals.HP) + GetPlayerVitalRegen(i, Vitals.HP))
                    Call SendVital(i, Vitals.HP)
                End If

                If GetPlayerVital(i, Vitals.MP) <> GetPlayerMaxVital(i, Vitals.MP) Then
                    Call SetPlayerVital(i, Vitals.MP, GetPlayerVital(i, Vitals.MP) + GetPlayerVitalRegen(i, Vitals.MP))
                    Call SendVital(i, Vitals.MP)
                End If

                If GetPlayerVital(i, Vitals.SP) <> GetPlayerMaxVital(i, Vitals.SP) Then
                    Call SetPlayerVital(i, Vitals.SP, GetPlayerVital(i, Vitals.SP) + GetPlayerVitalRegen(i, Vitals.SP))
                    Call SendVital(i, Vitals.SP)
                End If
            End If

        Next

    End Sub

    Private Sub UpdateNpcAI()
        Dim i As Long
        Dim x As Long
        Dim MapNum As Long
        Dim n As Long
        Dim x1 As Long
        Dim y1 As Long
        Dim TickCount As Long
        Dim Damage As Long
        Dim DistanceX As Long
        Dim DistanceY As Long
        Dim NpcNum As Long
        Dim Target As Long
        Dim TargetType As Byte
        Dim DidWalk As Boolean
        Dim Resource_index As Long
        Dim TargetX As Long
        Dim TargetY As Long
        Dim target_verify As Boolean
        For MapNum = 1 To MAX_MAPS

            '  Close the doors
            If TickCount > TempTile(MapNum).DoorTimer + 5000 Then

                For x1 = 0 To Map(MapNum).MaxX
                    For y1 = 0 To Map(MapNum).MaxY
                        If Map(MapNum).Tile(x1, y1).Type = TILE_TYPE_KEY And TempTile(MapNum).DoorOpen(x1, y1) = YES Then
                            TempTile(MapNum).DoorOpen(x1, y1) = NO
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
                                ResourceCache(MapNum).ResourceData(i).cur_health = Resource(Resource_index).health
                                SendResourceCacheToMap(MapNum, i)
                            End If
                        End If
                    End If
                Next
            End If

            If PlayersOnMap(MapNum) = YES Then
                TickCount = GetTickCount()

                For x = 1 To MAX_MAP_NPCS
                    NpcNum = MapNpc(MapNum).Npc(x).Num

                    ' /////////////////////////////////////////
                    ' // This is used for ATTACKING ON SIGHT //
                    ' /////////////////////////////////////////
                    ' Make sure theres a npc with the map
                    If Map(MapNum).Npc(x) > 0 And MapNpc(MapNum).Npc(x).Num > 0 Then

                        ' If the npc is a attack on sight, search for a player on the map
                        If Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_ATTACKONSIGHT Or Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_GUARD Then

                            ' make sure it's not stunned
                            If Not MapNpc(MapNum).Npc(x).StunDuration > 0 Then

                                For i = 1 To MAX_PLAYERS
                                    If IsPlaying(i) Then
                                        If GetPlayerMap(i) = MapNum And MapNpc(MapNum).Npc(x).Target = 0 And GetPlayerAccess(i) <= ADMIN_MONITOR Then
                                            n = Npc(NpcNum).range
                                            DistanceX = MapNpc(MapNum).Npc(x).x - GetPlayerX(i)
                                            DistanceY = MapNpc(MapNum).Npc(x).y - GetPlayerY(i)

                                            ' Make sure we get a positive value
                                            If DistanceX < 0 Then DistanceX = DistanceX * -1
                                            If DistanceY < 0 Then DistanceY = DistanceY * -1

                                            ' Are they in range?  if so GET'M!
                                            If DistanceX <= n And DistanceY <= n Then
                                                If Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_ATTACKONSIGHT Or GetPlayerPK(i) = YES Then
                                                    If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                                                        Call PlayerMsg(i, CheckGrammar(Trim$(Npc(NpcNum).Name), 1) & " dit, '" & Trim$(Npc(NpcNum).AttackSay) & "' à vous.")
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
                                    If Npc(NpcNum).faction > 0 Then
                                        ' search for npc of another faction to target
                                        For i = 1 To MAX_MAP_NPCS
                                            ' exist?
                                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                                ' different faction?
                                                If Npc(MapNpc(MapNum).Npc(i).Num).faction > 0 Then
                                                    If Npc(MapNpc(MapNum).Npc(i).Num).faction <> Npc(NpcNum).faction Then
                                                        n = Npc(NpcNum).range
                                                        DistanceX = MapNpc(MapNum).Npc(x).x - CLng(MapNpc(MapNum).Npc(i).x)
                                                        DistanceY = MapNpc(MapNum).Npc(x).y - CLng(MapNpc(MapNum).Npc(i).y)

                                                        ' Make sure we get a positive value
                                                        If DistanceX < 0 Then DistanceX = DistanceX * -1
                                                        If DistanceY < 0 Then DistanceY = DistanceY * -1

                                                        ' Are they in range?  if so GET'M!
                                                        If DistanceX <= n And DistanceY <= n Then
                                                            If Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_ATTACKONSIGHT Then
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
                            If Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_SHOPKEEPER Then

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

                                    i = Int(Rnd() * 5)

                                    ' Lets move the npc
                                    Select Case i
                                        Case 0

                                            ' Up
                                            If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_UP) Then
                                                    Call NpcMove(MapNum, x, DIR_UP, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Down
                                            If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_DOWN) Then
                                                    Call NpcMove(MapNum, x, DIR_DOWN, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Left
                                            If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_LEFT) Then
                                                    Call NpcMove(MapNum, x, DIR_LEFT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Right
                                            If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_RIGHT) Then
                                                    Call NpcMove(MapNum, x, DIR_RIGHT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                        Case 1

                                            ' Right
                                            If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_RIGHT) Then
                                                    Call NpcMove(MapNum, x, DIR_RIGHT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Left
                                            If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_LEFT) Then
                                                    Call NpcMove(MapNum, x, DIR_LEFT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Down
                                            If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_DOWN) Then
                                                    Call NpcMove(MapNum, x, DIR_DOWN, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Up
                                            If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_UP) Then
                                                    Call NpcMove(MapNum, x, DIR_UP, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                        Case 2

                                            ' Down
                                            If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_DOWN) Then
                                                    Call NpcMove(MapNum, x, DIR_DOWN, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Up
                                            If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_UP) Then
                                                    Call NpcMove(MapNum, x, DIR_UP, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Right
                                            If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_RIGHT) Then
                                                    Call NpcMove(MapNum, x, DIR_RIGHT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Left
                                            If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_LEFT) Then
                                                    Call NpcMove(MapNum, x, DIR_LEFT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                        Case 3

                                            ' Left
                                            If MapNpc(MapNum).Npc(x).x > TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_LEFT) Then
                                                    Call NpcMove(MapNum, x, DIR_LEFT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Right
                                            If MapNpc(MapNum).Npc(x).x < TargetX And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_RIGHT) Then
                                                    Call NpcMove(MapNum, x, DIR_RIGHT, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Up
                                            If MapNpc(MapNum).Npc(x).y > TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_UP) Then
                                                    Call NpcMove(MapNum, x, DIR_UP, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                            ' Down
                                            If MapNpc(MapNum).Npc(x).y < TargetY And Not DidWalk Then
                                                If CanNpcMove(MapNum, x, DIR_DOWN) Then
                                                    Call NpcMove(MapNum, x, DIR_DOWN, MOVING_WALKING)
                                                    DidWalk = True
                                                End If
                                            End If

                                    End Select

                                    ' Check if we can't move and if Target is behind something and if we can just switch dirs
                                    If Not DidWalk Then
                                        If MapNpc(MapNum).Npc(x).x - 1 = TargetX And MapNpc(MapNum).Npc(x).y = TargetY Then
                                            If MapNpc(MapNum).Npc(x).Dir <> DIR_LEFT Then
                                                Call NpcDir(MapNum, x, DIR_LEFT)
                                            End If

                                            DidWalk = True
                                        End If

                                        If MapNpc(MapNum).Npc(x).x + 1 = TargetX And MapNpc(MapNum).Npc(x).y = TargetY Then
                                            If MapNpc(MapNum).Npc(x).Dir <> DIR_RIGHT Then
                                                Call NpcDir(MapNum, x, DIR_RIGHT)
                                            End If

                                            DidWalk = True
                                        End If

                                        If MapNpc(MapNum).Npc(x).x = TargetX And MapNpc(MapNum).Npc(x).y - 1 = TargetY Then
                                            If MapNpc(MapNum).Npc(x).Dir <> DIR_UP Then
                                                Call NpcDir(MapNum, x, DIR_UP)
                                            End If

                                            DidWalk = True
                                        End If

                                        If MapNpc(MapNum).Npc(x).x = TargetX And MapNpc(MapNum).Npc(x).y + 1 = TargetY Then
                                            If MapNpc(MapNum).Npc(x).Dir <> DIR_DOWN Then
                                                Call NpcDir(MapNum, x, DIR_DOWN)
                                            End If

                                            DidWalk = True
                                        End If

                                        ' We could not move so Target must be behind something, walk randomly.
                                        If Not DidWalk Then
                                            i = Int(Rnd() * 2)

                                            If i = 1 Then
                                                i = Int(Rnd() * 4)

                                                If CanNpcMove(MapNum, x, i) Then
                                                    Call NpcMove(MapNum, x, i, MOVING_WALKING)
                                                End If
                                            End If
                                        End If
                                    End If

                                Else
                                    i = Int(Rnd() * 4)

                                    If i = 1 Then
                                        i = Int(Rnd() * 4)

                                        If CanNpcMove(MapNum, x, i) Then
                                            Call NpcMove(MapNum, x, i, MOVING_WALKING)
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
                                            Damage = Npc(NpcNum).Stat(Stats.strength) - GetPlayerProtection(Target)
                                            Call NpcAttackPlayer(x, Target, Damage)
                                        Else
                                            Call PlayerMsg(Target, "Your " & Trim$(Item(GetPlayerEquipment(Target, Equipment.Shield)).Name) & " blocks the " & Trim$(Npc(NpcNum).Name) & "'s hit!")
                                            SendActionMsg(GetPlayerMap(Target), "BLOCK!", Cyan, 1, (GetPlayerX(Target) * 32), (GetPlayerY(Target) * 32))
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
                                        Damage = CLng(Npc(NpcNum).Stat(Stats.strength)) - CLng(Npc(Target).Stat(Stats.endurance))
                                        If Damage < 1 Then Damage = 1
                                        Call NpcAttackNpc(MapNum, x, Target, Damage)
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
                            Call SpawnNpc(x, MapNum)
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

        ' Make sure we reset the timer for door closing
        If GetTickCount() > KeyTimer + 15000 Then
            KeyTimer = GetTickCount()
        End If

    End Sub
    Function GetNpcVitalRegen(ByVal NpcNum As Long, ByVal Vital As Vitals) As Long
        Dim i As Long

        'Prevent subscript out of range
        If NpcNum <= 0 Or NpcNum > MAX_NPCS Then
            GetNpcVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                i = Npc(NpcNum).Stat(Stats.vitality) \ 3

                If i < 1 Then i = 1
                GetNpcVitalRegen = i
        End Select

    End Function
    Sub NpcAttackPlayer(ByVal MapNpcNum As Long, ByVal Victim As Long, ByVal Damage As Long)
        Dim Name As String
        Dim MapNum As Long
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or IsPlaying(Victim) = False Then
            Exit Sub
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num <= 0 Then
            Exit Sub
        End If

        MapNum = GetPlayerMap(Victim)
        Name = Trim$(Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Name)
        ' Send this packet so they can see the person attacking
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SNpcAttack)
        Buffer.WriteLong(MapNpcNum)
        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing

        If Damage <= 0 Then
            SendActionMsg(GetPlayerMap(Victim), "BLOCK!", Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
            Exit Sub
        End If

        If Damage >= GetPlayerVital(Victim, Vitals.HP) Then
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            ' kill player
            KillPlayer(Victim)

            ' Player is dead
            Call GlobalMsg(GetPlayerName(Victim) & " has been killed by " & CheckGrammar(Name))

            ' Set NPC target to 0
            For i = 1 To MAX_MAP_NPCS
                If MapNpc(MapNum).Npc(i).TargetType = TARGET_TYPE_PLAYER Then
                    If MapNpc(MapNum).Npc(i).Target = Victim Then
                        MapNpc(MapNum).Npc(i).Target = 0
                        MapNpc(MapNum).Npc(i).TargetType = 0
                    End If
                End If
            Next
        Else
            ' Player not dead, just do the damage
            Call SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
            Call SendVital(Victim, Vitals.HP)
            Call SendAnimation(MapNum, Npc(MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num).Animation, 0, 0, TARGET_TYPE_PLAYER, Victim)
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
        End If

    End Sub
    Public Sub CastSpell(ByVal Index As Long, ByVal spellslot As Long)
        Dim spellnum As Long
        Dim MPCost As Long
        Dim LevelReq As Long
        Dim MapNum As Long
        Dim Vital As Long
        Dim DidCast As Boolean
        Dim ClassReq As Long
        Dim AccessReq As Long
        Dim i As Long
        Dim AoE As Long
        Dim range As Long
        Dim VitalType As Byte
        Dim increment As Boolean
        Dim x As Long, y As Long

        Dim TargetType As Byte
        Dim Target As Long
        Dim SpellCastType As Long

        DidCast = False

        ' Prevent subscript out of range
        If spellslot <= 0 Or spellslot > MAX_PLAYER_SPELLS Then Exit Sub

        spellnum = GetPlayerSpell(Index, spellslot)
        MapNum = GetPlayerMap(Index)

        ' Make sure player has the spell
        If Not HasSpell(Index, spellnum) Then Exit Sub

        MPCost = Spell(spellnum).MPCost

        ' Check if they have enough MP
        If GetPlayerVital(Index, Vitals.MP) < MPCost Then
            Call PlayerMsg(Index, "Not enough mana!")
            Exit Sub
        End If

        LevelReq = Spell(spellnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > GetPlayerLevel(Index) Then
            Call PlayerMsg(Index, "Vous devez être niveau " & LevelReq & " pour utiliser ce sort.")
            Exit Sub
        End If

        AccessReq = Spell(spellnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(Index) Then
            Call PlayerMsg(Index, "Vous devez être administrateur pour utiliser ce sort.")
            Exit Sub
        End If

        ClassReq = Spell(spellnum).ClassReq

        ' make sure the classreq > 0
        If ClassReq > 0 Then ' 0 = no req
            If ClassReq <> GetPlayerClass(Index) Then
                Call PlayerMsg(Index, "Seul " & CheckGrammar(Trim$(Classes(ClassReq).Name)) & " peut utiliser ce sort.")
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

        ' set the vital
        Vital = Spell(spellnum).Vital
        AoE = Spell(spellnum).AoE
        range = Spell(spellnum).range

        Select Case SpellCastType
            Case 0 ' self-cast target
                Select Case Spell(spellnum).Type
                    Case SPELL_TYPE_HEALHP
                        SpellPlayer_Effect(Vitals.HP, True, Index, Vital, spellnum)
                        DidCast = True
                    Case SPELL_TYPE_HEALMP
                        SpellPlayer_Effect(Vitals.MP, True, Index, Vital, spellnum)
                        DidCast = True
                    Case SPELL_TYPE_WARP
                        SendAnimation(MapNum, Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_PLAYER, Index)
                        PlayerWarp(Index, Spell(spellnum).Map, Spell(spellnum).x, Spell(spellnum).y)
                        SendAnimation(GetPlayerMap(Index), Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_PLAYER, Index)
                        DidCast = True
                End Select
            Case 1, 3 ' self-cast AOE & targetted AOE
                If SpellCastType = 1 Then
                    x = GetPlayerX(Index)
                    y = GetPlayerY(Index)
                ElseIf SpellCastType = 3 Then
                    TargetType = TempPlayer(Index).TargetType
                    Target = TempPlayer(Index).Target

                    If TargetType = 0 Then Exit Sub
                    If Target = 0 Then Exit Sub

                    If TempPlayer(Index).TargetType = TARGET_TYPE_PLAYER Then
                        x = GetPlayerX(Target)
                        y = GetPlayerY(Target)
                    Else
                        x = MapNpc(MapNum).Npc(Target).x
                        y = MapNpc(MapNum).Npc(Target).y
                    End If

                    If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), x, y) Then
                        PlayerMsg(Index, "Target not in range.")
                        SendClearSpellBuffer(Index)
                    End If
                End If
                Select Case Spell(spellnum).Type
                    Case SPELL_TYPE_DAMAGEHP
                        DidCast = True
                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                If i <> Index Then
                                    If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                        If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                            If CanAttackPlayer(Index, i, True) Then
                                                SendAnimation(MapNum, Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_PLAYER, i)
                                                AttackPlayer(Index, i, Vital, spellnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        If CanAttackNpc(Index, i, True) Then
                                            SendAnimation(MapNum, Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_NPC, i)
                                            AttackNpc(Index, i, Vital, spellnum)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Case SPELL_TYPE_HEALHP, SPELL_TYPE_HEALMP, SPELL_TYPE_DAMAGEMP
                        If Spell(spellnum).Type = SPELL_TYPE_HEALHP Then
                            VitalType = Vitals.HP
                            increment = True
                        ElseIf Spell(spellnum).Type = SPELL_TYPE_HEALMP Then
                            VitalType = Vitals.MP
                            increment = True
                        ElseIf Spell(spellnum).Type = SPELL_TYPE_DAMAGEMP Then
                            VitalType = Vitals.MP
                            increment = False
                        End If

                        DidCast = True
                        For i = 1 To MAX_PLAYERS
                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                    If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        SpellPlayer_Effect(VitalType, increment, i, Vital, spellnum)
                                    End If
                                End If
                            End If
                        Next
                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        SpellNpc_Effect(VitalType, increment, i, Vital, spellnum, MapNum)
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

                If TempPlayer(Index).TargetType = TARGET_TYPE_PLAYER Then
                    x = GetPlayerX(Target)
                    y = GetPlayerY(Target)
                Else
                    x = MapNpc(MapNum).Npc(Target).x
                    y = MapNpc(MapNum).Npc(Target).y
                End If

                If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), x, y) Then
                    PlayerMsg(Index, "Target not in range.")
                    SendClearSpellBuffer(Index)
                    Exit Sub
                End If

                Select Case Spell(spellnum).Type
                    Case SPELL_TYPE_DAMAGEHP
                        If TempPlayer(Index).TargetType = TARGET_TYPE_PLAYER Then
                            If CanAttackPlayer(Index, Target, True) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_PLAYER, Target)
                                    AttackPlayer(Index, Target, Vital, spellnum)
                                    DidCast = True
                                End If
                            End If
                        Else
                            If CanAttackNpc(Index, Target, True) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_NPC, Target)
                                    AttackNpc(Index, Target, Vital, spellnum)
                                    DidCast = True
                                End If
                            End If
                        End If

                    Case SPELL_TYPE_DAMAGEMP, SPELL_TYPE_HEALMP, SPELL_TYPE_HEALHP
                        If Spell(spellnum).Type = SPELL_TYPE_DAMAGEMP Then
                            VitalType = Vitals.MP
                            increment = False
                        ElseIf Spell(spellnum).Type = SPELL_TYPE_HEALMP Then
                            VitalType = Vitals.MP
                            increment = True
                        ElseIf Spell(spellnum).Type = SPELL_TYPE_HEALHP Then
                            VitalType = Vitals.HP
                            increment = True
                        End If

                        If TempPlayer(Index).TargetType = TARGET_TYPE_PLAYER Then
                            If Spell(spellnum).Type = SPELL_TYPE_DAMAGEMP Then
                                If CanAttackPlayer(Index, Target, True) Then
                                    SpellPlayer_Effect(VitalType, increment, Target, Vital, spellnum)
                                End If
                            Else
                                SpellPlayer_Effect(VitalType, increment, Target, Vital, spellnum)
                            End If
                        Else
                            If Spell(spellnum).Type = SPELL_TYPE_DAMAGEMP Then
                                If CanAttackNpc(Index, Target, True) Then
                                    SpellNpc_Effect(VitalType, increment, Target, Vital, spellnum, MapNum)
                                End If
                            Else
                                SpellNpc_Effect(VitalType, increment, Target, Vital, spellnum, MapNum)
                            End If
                        End If
                End Select
        End Select

        If DidCast Then
            Call SetPlayerVital(Index, Vitals.MP, GetPlayerVital(Index, Vitals.MP) - MPCost)
            Call SendVital(Index, Vitals.MP)
            TempPlayer(Index).SpellCD(spellslot) = GetTickCount() + (Spell(spellnum).CDTime * 1000)
            Call SendCooldown(Index, spellslot)
        End If
    End Sub
    Public Sub SpellPlayer_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Long, ByVal Damage As Long, ByVal spellnum As Long)
        Dim sSymbol As String
        Dim Colour As Long

        If Damage > 0 Then
            If increment Then
                sSymbol = "+"
                If Vital = Vitals.HP Then Colour = BrightGreen
                If Vital = Vitals.MP Then Colour = BrightBlue
            Else
                sSymbol = "-"
                Colour = Blue
            End If

            SendAnimation(GetPlayerMap(Index), Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_PLAYER, Index)
            SendActionMsg(GetPlayerMap(Index), sSymbol & Damage, Colour, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
            If increment Then SetPlayerVital(Index, Vital, GetPlayerVital(Index, Vital) + Damage)
            If Not increment Then SetPlayerVital(Index, Vital, GetPlayerVital(Index, Vital) - Damage)
        End If
    End Sub

    Public Sub SpellNpc_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Long, ByVal Damage As Long, ByVal spellnum As Long, ByVal MapNum As Long)
        Dim sSymbol As String
        Dim Colour As Long

        If Damage > 0 Then
            If increment Then
                sSymbol = "+"
                If Vital = Vitals.HP Then Colour = BrightGreen
                If Vital = Vitals.MP Then Colour = BrightBlue
            Else
                sSymbol = "-"
                Colour = Blue
            End If

            SendAnimation(MapNum, Spell(spellnum).SpellAnim, 0, 0, TARGET_TYPE_NPC, Index)
            SendActionMsg(MapNum, sSymbol & Damage, Colour, ACTIONMSG_SCROLL, MapNpc(MapNum).Npc(Index).x * 32, MapNpc(MapNum).Npc(Index).y * 32)
            If increment Then MapNpc(MapNum).Npc(Index).Vital(Vital) = MapNpc(MapNum).Npc(Index).Vital(Vital) + Damage
            If Not increment Then MapNpc(MapNum).Npc(Index).Vital(Vital) = MapNpc(MapNum).Npc(Index).Vital(Vital) - Damage
        End If
    End Sub
End Module
