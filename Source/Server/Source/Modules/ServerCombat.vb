Public Module ServerCombat

#Region "PlayerCombat"
    Function CanAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, Optional ByVal IsSkill As Boolean = False) As Boolean

        If Not IsSkill Then
            ' Check attack timer
            If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
                If GetTickCount() < TempPlayer(Attacker).AttackTimer + Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Speed Then Exit Function
            Else
                If GetTickCount() < TempPlayer(Attacker).AttackTimer + 1000 Then Exit Function
            End If
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = True Then Exit Function

        If Not IsSkill Then
            ' Check if at same coordinates
            Select Case GetPlayerDir(Attacker)
                Case Direction.Up

                    If Not ((GetPlayerY(Victim) + 1 = GetPlayerY(Attacker)) And (GetPlayerX(Victim) = GetPlayerX(Attacker))) Then Exit Function
                Case Direction.Down

                    If Not ((GetPlayerY(Victim) - 1 = GetPlayerY(Attacker)) And (GetPlayerX(Victim) = GetPlayerX(Attacker))) Then Exit Function
                Case Direction.Left

                    If Not ((GetPlayerY(Victim) = GetPlayerY(Attacker)) And (GetPlayerX(Victim) + 1 = GetPlayerX(Attacker))) Then Exit Function
                Case Direction.Right

                    If Not ((GetPlayerY(Victim) = GetPlayerY(Attacker)) And (GetPlayerX(Victim) - 1 = GetPlayerX(Attacker))) Then Exit Function
                Case Else
                    Exit Function
            End Select
        End If

        ' Check if map is attackable
        If Not Map(GetPlayerMap(Attacker)).Moral = MapMoral.None Then
            If GetPlayerPK(Victim) = False Then
                PlayerMsg(Attacker, "This is a safe zone!")
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If GetPlayerVital(Victim, Vitals.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack any player for thou art an admin!")
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "!")
            Exit Function
        End If

        ' Make sure attacker is high enough level
        If GetPlayerLevel(Attacker) < 10 Then
            PlayerMsg(Attacker, "You are below level 10, you cannot attack another player yet!")
            Exit Function
        End If

        ' Make sure victim is high enough level
        If GetPlayerLevel(Victim) < 10 Then
            PlayerMsg(Attacker, GetPlayerName(Victim) & " is below level 10, you cannot attack this player yet!")
            Exit Function
        End If

        CanAttackPlayer = True
    End Function

    Function CanPlayerBlockHit(ByVal Index As Integer) As Boolean
        Dim i As Integer
        Dim n As Integer
        Dim ShieldSlot As Integer
        ShieldSlot = GetPlayerEquipment(Index, EquipmentType.Shield)

        If ShieldSlot > 0 Then
            n = Int(Rnd() * 2)

            If n = 1 Then
                i = (GetPlayerStat(Index, Stats.endurance) \ 2) + (GetPlayerLevel(Index) \ 2)
                n = Int(Rnd() * 100) + 1

                If n <= i Then
                    CanPlayerBlockHit = True
                End If
            End If
        End If

    End Function

    Function CanPlayerCriticalHit(ByVal Index As Integer) As Boolean
        On Error Resume Next
        Dim i As Integer
        Dim n As Integer

        If GetPlayerEquipment(Index, EquipmentType.Weapon) > 0 Then
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

    Function GetPlayerDamage(ByVal Index As Integer) As Integer
        Dim Weapon As Integer
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

    Function GetPlayerProtection(ByVal Index As Integer) As Integer
        Dim Armor As Integer, Helm As Integer, Shoes As Integer, Gloves As Integer
        GetPlayerProtection = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            Exit Function
        End If

        Armor = GetPlayerEquipment(Index, EquipmentType.Armor)
        Helm = GetPlayerEquipment(Index, EquipmentType.Helmet)
        Shoes = GetPlayerEquipment(Index, EquipmentType.Shoes)
        Gloves = GetPlayerEquipment(Index, EquipmentType.Gloves)
        GetPlayerProtection = (GetPlayerStat(Index, Stats.endurance) \ 5)

        If Armor > 0 Then
            GetPlayerProtection = GetPlayerProtection + Item(Armor).Data2
        End If

        If Helm > 0 Then
            GetPlayerProtection = GetPlayerProtection + Item(Helm).Data2
        End If

        If Shoes > 0 Then
            GetPlayerProtection = GetPlayerProtection + Item(Shoes).Data2
        End If

        If Gloves > 0 Then
            GetPlayerProtection = GetPlayerProtection + Item(Gloves).Data2
        End If

    End Function

    Sub AttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer, Optional ByVal skillnum As Integer = 0, Optional ByVal npcnum As Byte = 0)
        Dim exp As Integer, mapnum As Integer
        Dim n As Integer
        Dim Buffer As ByteBuffer

        If npcnum = 0 Then
            ' Check for subscript out of range
            If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Then
                Exit Sub
            End If

            ' Check for weapon
            n = 0

            If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
                n = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
            End If

            ' Send this packet so they can see the person attacking
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SAttack)
            Buffer.WriteInteger(Attacker)
            SendDataToMapBut(Attacker, GetPlayerMap(Attacker), Buffer.ToArray())
            Buffer = Nothing

            If Damage >= GetPlayerVital(Victim, Vitals.HP) Then

                SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

                ' Player is dead
                GlobalMsg(GetPlayerName(Victim) & " has been killed by " & GetPlayerName(Attacker))
                ' Calculate exp to give attacker
                exp = (GetPlayerExp(Victim) \ 10)

                ' Make sure we dont get less then 0
                If exp < 0 Then
                    exp = 0
                End If

                If exp = 0 Then
                    PlayerMsg(Victim, "You lost no exp.")
                    PlayerMsg(Attacker, "You received no exp.")
                Else
                    SetPlayerExp(Victim, GetPlayerExp(Victim) - exp)
                    SendExp(Victim)
                    PlayerMsg(Victim, "You lost " & exp & " exp.")
                    SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                    SendExp(Attacker)
                    PlayerMsg(Attacker, "You received " & exp & " exp.")
                End If

                ' Check for a level up
                CheckPlayerLevelUp(Attacker)

                ' Check if target is player who died and if so set target to 0
                If TempPlayer(Attacker).TargetType = TargetType.Player Then
                    If TempPlayer(Attacker).Target = Victim Then
                        TempPlayer(Attacker).Target = 0
                        TempPlayer(Attacker).TargetType = TargetType.None
                    End If
                End If

                If GetPlayerPK(Victim) = False Then
                    If GetPlayerPK(Attacker) = False Then
                        SetPlayerPK(Attacker, True)
                        SendPlayerData(Attacker)
                        GlobalMsg(GetPlayerName(Attacker) & " has been deemed a Player Killer!!!")
                    End If

                Else
                    GlobalMsg(GetPlayerName(Victim) & " has paid the price for being a Player Killer!!!")
                End If

                OnDeath(Victim)
            Else
                ' Player not dead, just do the damage
                SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
                SendVital(Victim, Vitals.HP)
                SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

                'if a stunning skill, stun the player
                If skillnum > 0 Then
                    If Skill(skillnum).StunDuration > 0 Then StunPlayer(Victim, skillnum)
                End If
            End If

            ' Reset attack timer
            TempPlayer(Attacker).AttackTimer = GetTickCount()
        Else ' npc to player
            ' Check for subscript out of range
            If IsPlaying(Victim) = False Or Damage < 0 Then Exit Sub

            mapnum = GetPlayerMap(Victim)

            ' Send this packet so they can see the person attacking
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SNpcAttack)
            Buffer.WriteInteger(Attacker)
            SendDataToMap(mapnum, Buffer.ToArray())
            Buffer = Nothing

            If Damage >= GetPlayerVital(Victim, Vitals.HP) Then

                SendActionMsg(mapnum, "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

                ' Player is dead
                GlobalMsg(GetPlayerName(Victim) & " has been killed by " & Npc(MapNpc(mapnum).Npc(Attacker).Num).Name)

                ' Check if target is player who died and if so set target to 0
                If TempPlayer(Attacker).TargetType = TargetType.Player Then
                    If TempPlayer(Attacker).Target = Victim Then
                        TempPlayer(Attacker).Target = 0
                        TempPlayer(Attacker).TargetType = TargetType.None
                    End If
                End If

                OnDeath(Victim)
            Else
                ' Player not dead, just do the damage
                SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
                SendVital(Victim, Vitals.HP)
                SendActionMsg(mapnum, "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

                'if a stunning skill, stun the player
                If skillnum > 0 Then
                    If Skill(skillnum).StunDuration > 0 Then StunPlayer(Victim, skillnum)
                End If
            End If

            ' Reset attack timer
            MapNpc(mapnum).Npc(Attacker).AttackTimer = GetTickCount()
        End If

    End Sub

    Public Sub StunPlayer(ByVal Index As Integer, ByVal skillnum As Integer)
        ' check if it's a stunning skill
        If Skill(skillnum).StunDuration > 0 Then
            ' set the values on index
            TempPlayer(Index).StunDuration = Skill(skillnum).StunDuration
            TempPlayer(Index).StunTimer = GetTickCount()
            ' send it to the index
            SendStunned(Index)
            ' tell him he's stunned
            PlayerMsg(Index, "You have been stunned!")
        End If
    End Sub

    Function CanAttackNpc(ByVal Attacker As Integer, ByVal MapNpcNum As Integer, Optional ByVal IsSkill As Boolean = False) As Boolean
        Dim MapNum As Integer
        Dim NpcNum As Integer
        Dim atkX As Integer
        Dim atkY As Integer
        Dim attackspeed As Integer

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
            If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Speed
            Else
                attackspeed = 1000
            End If

            If NpcNum > 0 And GetTickCount() > TempPlayer(Attacker).AttackTimer + attackspeed Then

                ' exit out early
                If IsSkill Then
                    If Npc(NpcNum).Behaviour <> NpcBehavior.Friendly And Npc(NpcNum).Behaviour <> NpcBehavior.ShopKeeper Then
                        CanAttackNpc = True
                        Exit Function
                    End If
                End If

                ' Check if at same coordinates
                Select Case GetPlayerDir(Attacker)
                    Case Direction.Up
                        atkX = GetPlayerX(Attacker)
                        atkY = GetPlayerY(Attacker) - 1
                    Case Direction.Down
                        atkX = GetPlayerX(Attacker)
                        atkY = GetPlayerY(Attacker) + 1
                    Case Direction.Left
                        atkX = GetPlayerX(Attacker) - 1
                        atkY = GetPlayerY(Attacker)
                    Case Direction.Right
                        atkX = GetPlayerX(Attacker) + 1
                        atkY = GetPlayerY(Attacker)
                End Select

                If atkX = MapNpc(MapNum).Npc(MapNpcNum).x Then
                    If atkY = MapNpc(MapNum).Npc(MapNpcNum).y Then
                        If Npc(NpcNum).Behaviour <> NpcBehavior.Friendly And Npc(NpcNum).Behaviour <> NpcBehavior.ShopKeeper And Npc(NpcNum).Behaviour <> NpcBehavior.Quest Then
                            CanAttackNpc = True
                        Else
                            If Npc(NpcNum).Behaviour = NpcBehavior.Quest Then
                                If QuestCompleted(Attacker, Npc(NpcNum).QuestNum) Then
                                    PlayerMsg(Attacker, Trim$(Npc(NpcNum).Name) & ": " & Trim$(Npc(NpcNum).AttackSay))
                                    Exit Function
                                ElseIf Not CanStartQuest(Attacker, Npc(NpcNum).QuestNum) Then
                                    CheckTasks(Attacker, QUEST_TYPE_GOTALK, NpcNum)
                                    CheckTasks(Attacker, QUEST_TYPE_GOGIVE, NpcNum)
                                    CheckTasks(Attacker, QUEST_TYPE_GOGET, NpcNum)
                                    Exit Function
                                Else
                                    ShowQuest(Attacker, Npc(NpcNum).QuestNum)
                                    Exit Function
                                End If
                            ElseIf Npc(NpcNum).Behaviour = NpcBehavior.Friendly Or Npc(NpcNum).Behaviour = NpcBehavior.ShopKeeper Then
                                CheckTasks(Attacker, QUEST_TYPE_GOTALK, NpcNum)
                                CheckTasks(Attacker, QUEST_TYPE_GOGIVE, NpcNum)
                                CheckTasks(Attacker, QUEST_TYPE_GOGET, NpcNum)
                                'Exit Function
                            End If
                            If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                                PlayerMsg(Attacker, Trim$(Npc(NpcNum).Name) & ": " & Trim$(Npc(NpcNum).AttackSay))
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function

    Public Sub StunNPC(ByVal Index As Integer, ByVal MapNum As Integer, ByVal skillnum As Integer)
        ' check if it's a stunning skill
        If Skill(skillnum).StunDuration > 0 Then
            ' set the values on index
            MapNpc(MapNum).Npc(Index).StunDuration = Skill(skillnum).StunDuration
            MapNpc(MapNum).Npc(Index).StunTimer = GetTickCount()
        End If
    End Sub

    Sub AttackNpc(ByVal Attacker As Integer, ByVal MapNpcNum As Integer, ByVal Damage As Integer, Optional ByVal skillnum As Integer = 0)
        Dim Name As String
        Dim exp As Integer
        Dim n As Integer
        Dim i As Integer
        Dim MapNum As Integer
        Dim NpcNum As Integer
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Damage < 0 Then
            Exit Sub
        End If

        MapNum = GetPlayerMap(Attacker)
        NpcNum = MapNpc(MapNum).Npc(MapNpcNum).Num
        Name = Trim$(Npc(NpcNum).Name)

        If skillnum = 0 Then
            ' Send this packet so they can see the person attacking
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SAttack)
            Buffer.WriteInteger(Attacker)
            SendDataToMapBut(Attacker, MapNum, Buffer.ToArray())
            Buffer = Nothing
        End If

        ' Check for weapon
        n = 0

        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            n = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        If Damage >= MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) Then

            SendActionMsg(GetPlayerMap(Attacker), "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)

            ' Calculate exp to give attacker
            exp = Npc(NpcNum).Exp

            ' Make sure we dont get less then 0
            If exp < 0 Then
                exp = 1
            End If

            ' Check if in party, if so divide the exp up by 2
            If TempPlayer(Attacker).InParty = False Then
                SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendExp(Attacker)
                SendActionMsg(GetPlayerMap(Attacker), "+" & exp & " EXP", ColorType.White, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
            Else
                exp = exp / 2

                If exp < 0 Then
                    exp = 1
                End If

                SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendExp(Attacker)
                SendActionMsg(GetPlayerMap(Attacker), "+" & exp & " Shared EXP", ColorType.White, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
                n = TempPlayer(Attacker).PartyPlayer

                If n > 0 Then
                    SetPlayerExp(n, GetPlayerExp(n) + exp)
                    SendExp(n)
                    SendActionMsg(GetPlayerMap(n), "+" & exp & " EXP", ColorType.White, 1, (GetPlayerX(n) * 32), (GetPlayerY(n) * 32))
                End If
            End If

            ' Drop the goods if they get it
            Dim tmpitem = Random(1, 5)
            n = Int(Rnd() * Npc(NpcNum).DropChance(tmpitem)) + 1

            If n = 1 Then
                SpawnItem(Npc(NpcNum).DropItem(tmpitem), Npc(NpcNum).DropItemValue(tmpitem), MapNum, MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)
            End If

            ' Now set HP to 0 so we know to actually kill them in the server loop (this prevents subscript out of range)
            MapNpc(MapNum).Npc(MapNpcNum).Num = 0
            MapNpc(MapNum).Npc(MapNpcNum).SpawnWait = GetTickCount()
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = 0

            SendTarget(Attacker, 0, 0)

            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SNpcDead)
            Buffer.WriteInteger(MapNpcNum)
            SendDataToMap(MapNum, Buffer.ToArray())
            Buffer = Nothing

            ' Check for level up
            CheckPlayerLevelUp(Attacker)

            ' Check for level up party member
            If TempPlayer(Attacker).InParty = True Then
                CheckPlayerLevelUp(TempPlayer(Attacker).PartyPlayer)
            End If

            ' Check if target is npc that died and if so set target to 0
            If TempPlayer(Attacker).TargetType = TargetType.Npc Then
                If TempPlayer(Attacker).Target = MapNpcNum Then
                    TempPlayer(Attacker).Target = 0
                    TempPlayer(Attacker).TargetType = TargetType.None
                End If
            End If

            CheckTasks(Attacker, QUEST_TYPE_GOSLAY, NpcNum)

        Else
            ' NPC not dead, just do the damage
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) - Damage

            ' Check for a weapon and say damage
            SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)

            ' send animation
            If n > 0 Then
                If skillnum = 0 Then SendAnimation(MapNum, Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Animation, 0, 0, TargetType.Npc, MapNpcNum)
            End If

            ' Check if we should send a message
            If MapNpc(MapNum).Npc(MapNpcNum).Target = 0 Then
                If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                    PlayerMsg(Attacker, CheckGrammar(Trim$(Npc(NpcNum).Name), 1) & " says: " & Trim$(Npc(NpcNum).AttackSay))
                End If
            End If

            ' Set the NPC target to the player
            MapNpc(MapNum).Npc(MapNpcNum).TargetType = 1 ' player
            MapNpc(MapNum).Npc(MapNpcNum).Target = Attacker

            ' Now check for guard ai and if so have all onmap guards come after'm
            If Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Behaviour = NpcBehavior.Guard Then

                For i = 1 To MAX_MAP_NPCS

                    If MapNpc(MapNum).Npc(i).Num = MapNpc(MapNum).Npc(MapNpcNum).Num Then
                        MapNpc(MapNum).Npc(i).Target = Attacker
                        MapNpc(MapNum).Npc(i).TargetType = 1 ' player
                    End If

                Next

            End If

            ' if stunning skill, stun the npc
            If skillnum > 0 Then
                If Skill(skillnum).StunDuration > 0 Then StunNPC(MapNpcNum, MapNum, skillnum)
            End If

            SendMapNpcTo(MapNum, MapNpcNum)
        End If

        If skillnum = 0 Then
            ' Reset attack timer
            TempPlayer(Attacker).AttackTimer = GetTickCount()
        End If

    End Sub
#End Region

#Region "Npcombat"
    Function CanNpcAttackPlayer(ByVal MapNpcNum As Integer, ByVal Index As Integer) As Boolean
        Dim MapNum As Integer
        Dim NpcNum As Integer

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
        If GetTickCount() < MapNpc(MapNum).Npc(MapNpcNum).AttackTimer + 1000 Then
            Exit Function
        End If

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Index).GettingMap = True Then
            Exit Function
        End If

        MapNpc(MapNum).Npc(MapNpcNum).AttackTimer = GetTickCount()

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

    Function CanNpcAttackNpc(ByVal MapNum As Integer, ByVal Attacker As Integer, ByVal Victim As Integer) As Boolean
        Dim aNpcNum As Integer, vNpcNum As Integer, VictimX As Integer
        Dim VictimY As Integer, AttackerX As Integer, AttackerY As Integer

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
        If GetTickCount() < MapNpc(MapNum).Npc(Attacker).AttackTimer + 1000 Then
            Exit Function
        End If

        MapNpc(MapNum).Npc(Attacker).AttackTimer = GetTickCount()

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

    Public Sub NpcAttackPlayer(ByVal MapNpcNum As Integer, ByVal Victim As Integer)
        Dim Name As String, damage As Integer
        Dim MapNum As Integer
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or IsPlaying(Victim) = False Then Exit Sub

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num <= 0 Then Exit Sub

        MapNum = GetPlayerMap(Victim)
        Name = Trim$(Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Name)

        ' Send this packet so they can see the npc attacking
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SNpcAttack)
        Buffer.WriteInteger(MapNpcNum)
        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing

        damage = Npc(MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num).Stat(Stats.strength) - GetPlayerProtection(Victim)

        If damage <= 0 Then
            SendActionMsg(GetPlayerMap(Victim), "BLOCK!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
            Exit Sub
        End If

        If damage >= GetPlayerVital(Victim, Vitals.HP) Then
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            ' kill player
            KillPlayer(Victim)

            ' Player is dead
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & CheckGrammar(Name))

            ' Set NPC target to 0
            For i = 1 To MAX_MAP_NPCS
                If MapNpc(MapNum).Npc(i).TargetType = TargetType.Player Then
                    If MapNpc(MapNum).Npc(i).Target = Victim Then
                        MapNpc(MapNum).Npc(i).Target = 0
                        MapNpc(MapNum).Npc(i).TargetType = 0
                    End If
                End If
            Next
        Else
            ' Player not dead, just do the damage
            SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - damage)
            SendVital(Victim, Vitals.HP)
            SendAnimation(MapNum, Npc(MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num).Animation, 0, 0, TargetType.Player, Victim)
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
        End If

    End Sub

    Sub NpcAttackNpc(ByVal MapNum As Integer, ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer)
        Dim Buffer As ByteBuffer
        Dim aNpcNum As Integer
        Dim vNpcNum As Integer
        Dim n As Integer

        If Attacker <= 0 Or Attacker > MAX_MAP_NPCS Then Exit Sub
        If Victim <= 0 Or Victim > MAX_MAP_NPCS Then Exit Sub

        If Damage <= 0 Then Exit Sub

        aNpcNum = MapNpc(MapNum).Npc(Attacker).Num
        vNpcNum = MapNpc(MapNum).Npc(Victim).Num

        If aNpcNum <= 0 Then Exit Sub
        If vNpcNum <= 0 Then Exit Sub

        ' Send this packet so they can see the person attacking
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SNpcAttack)
        Buffer.WriteInteger(Attacker)
        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing

        If Damage >= MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) Then
            SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(Victim).x * 32), (MapNpc(MapNum).Npc(Victim).y * 32))
            SendBlood(MapNum, MapNpc(MapNum).Npc(Victim).x, MapNpc(MapNum).Npc(Victim).y)

            ' npc is dead.

            ' Set NPC target to 0
            MapNpc(MapNum).Npc(Attacker).Target = 0
            MapNpc(MapNum).Npc(Attacker).TargetType = 0

            ' Drop the goods if they get it
            Dim tmpitem = Random(1, 5)
            n = Int(Rnd() * Npc(vNpcNum).DropChance(tmpitem)) + 1
            If n = 1 Then
                SpawnItem(Npc(vNpcNum).DropItem(tmpitem), Npc(vNpcNum).DropItemValue(tmpitem), MapNum, MapNpc(MapNum).Npc(Victim).x, MapNpc(MapNum).Npc(Victim).y)
            End If

            ' Reset victim's stuff so it dies in loop
            MapNpc(MapNum).Npc(Victim).Num = 0
            MapNpc(MapNum).Npc(Victim).SpawnWait = GetTickCount()
            MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) = 0

            ' send npc death packet to map
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SNpcDead)
            Buffer.WriteInteger(Victim)
            SendDataToMap(MapNum, Buffer.ToArray())
            Buffer = Nothing
        Else
            ' npc not dead, just do the damage
            MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) = MapNpc(MapNum).Npc(Victim).Vital(Vitals.HP) - Damage
            ' Say damage
            SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(Victim).x * 32), (MapNpc(MapNum).Npc(Victim).y * 32))
            SendBlood(MapNum, MapNpc(MapNum).Npc(Victim).x, MapNpc(MapNum).Npc(Victim).y)
        End If

    End Sub

    Public Sub KnockBackNpc(ByVal Index As Integer, ByVal NpcNum As Integer, Optional IsSkill As Integer = 0)
        If IsSkill > 0 Then
            For i = 1 To Skill(IsSkill).KnockBackTiles
                If CanNpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index)) Then
                    NpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index), MovementType.Walking)
                End If
            Next
            MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunDuration = 1
            MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunTimer = GetTickCount()
        Else
            If Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).KnockBack = 1 Then
                For i = 1 To Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).KnockBackTiles
                    If CanNpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index)) Then
                        NpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index), MovementType.Walking)
                    End If
                Next
                MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunDuration = 1
                MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunTimer = GetTickCount()
            End If
        End If
    End Sub

    Public Function RandomNpcAttack(ByVal MapNum As Integer, ByVal NpcNum As Integer) As Integer
        Dim i As Integer, SkillList As New List(Of Byte)

        RandomNpcAttack = 0

        If MapNpc(MapNum).Npc(NpcNum).SkillBuffer > 0 Then Exit Function

        For i = 1 To MAX_NPC_SKILLS
            If Npc(NpcNum).Skill(i) > 0 Then
                SkillList.Add(Npc(NpcNum).Skill(i))
            End If
        Next

        If SkillList.Count > 1 Then
            RandomNpcAttack = SkillList(Random(0, SkillList.Count - 1))
        End If

    End Function

    Public Function GetNpcSkill(ByVal NpcNum As Integer, ByVal skillslot As Integer) As Integer
        GetNpcSkill = Npc(NpcNum).Skill(skillslot)
    End Function

    Public Sub BufferNpcSkill(ByVal MapNum As Integer, ByVal MapNpcNum As Integer, ByVal skillslot As Integer)
        Dim skillnum As Integer
        Dim MPCost As Integer
        Dim SkillCastType As Integer
        Dim range As Integer
        Dim HasBuffered As Boolean

        Dim TargetType As Byte
        Dim Target As Integer

        ' Prevent subscript out of range
        If skillslot <= 0 Or skillslot > MAX_NPC_SKILLS Then Exit Sub


        skillnum = GetNpcSkill(MapNpc(MapNum).Npc(MapNpcNum).Num, skillslot)

        If skillnum <= 0 Or skillnum > MAX_SKILLS Then Exit Sub

        ' see if cooldown has finished
        If MapNpc(MapNum).Npc(MapNpcNum).SkillCD(skillslot) > GetTickCount() Then
            NpcAttackPlayer(MapNpcNum, MapNpc(MapNum).Npc(MapNpcNum).Target)
            Exit Sub
        End If

        MPCost = Skill(skillnum).MPCost

        ' Check if they have enough MP
        If MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.MP) < MPCost Then Exit Sub

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

        TargetType = MapNpc(MapNum).Npc(MapNpcNum).TargetType
        Target = MapNpc(MapNum).Npc(MapNpcNum).Target
        range = Skill(skillnum).range
        HasBuffered = False

        Select Case SkillCastType
            Case 0, 1 ' self-cast & self-cast AOE
                HasBuffered = True
            Case 2, 3 ' targeted & targeted AOE
                ' check if have target
                If Not Target > 0 Then
                    Exit Sub
                End If
                If TargetType = Enums.TargetType.Player Then
                    ' if have target, check in range
                    If Not isInRange(range, MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y, GetPlayerX(Target), GetPlayerY(Target)) Then
                        Exit Sub
                    Else
                        HasBuffered = True
                    End If
                ElseIf TargetType = Enums.TargetType.Npc Then
                    '' if have target, check in range
                    'If Not isInRange(range, GetPlayerX(Index), GetPlayerY(Index), MapNpc(MapNum).Npc(Target).x, MapNpc(MapNum).Npc(Target).y) Then
                    '    PlayerMsg(Index, "Target not in range.")
                    '    HasBuffered = False
                    'Else
                    '    ' go through skill types
                    '    If Skill(skillnum).Type <> SkillType.DAMAGEHP And Skill(skillnum).Type <> SkillType.DAMAGEMP Then
                    '        HasBuffered = True
                    '    Else
                    '        If CanAttackNpc(Index, Target, True) Then
                    '            HasBuffered = True
                    '        End If
                    '    End If
                    'End If
                End If
        End Select

        If HasBuffered Then
            SendAnimation(MapNum, Skill(skillnum).CastAnim, 0, 0, Enums.TargetType.Player, Target)
            MapNpc(MapNum).Npc(MapNpcNum).SkillBuffer = skillslot
            MapNpc(MapNum).Npc(MapNpcNum).SkillBufferTimer = GetTickCount()
            Exit Sub
        End If
    End Sub
#End Region

    Function isInRange(ByVal range As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Boolean
        Dim nVal As Integer
        isInRange = False
        nVal = Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
        If nVal <= range Then isInRange = True
    End Function

End Module
