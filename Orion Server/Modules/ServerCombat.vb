Public Module ServerCombat

#Region "PlayerCombat"
    Function CanAttackPlayer(ByVal Attacker As Long, ByVal Victim As Long, Optional ByVal IsSkill As Boolean = False) As Boolean

        If Not IsSkill Then
            ' Check attack timer
            If GetPlayerEquipment(Attacker, Equipment.Weapon) > 0 Then
                If GetTickCount() < TempPlayer(Attacker).AttackTimer + Item(GetPlayerEquipment(Attacker, Equipment.Weapon)).Speed Then Exit Function
            Else
                If GetTickCount() < TempPlayer(Attacker).AttackTimer + 1000 Then Exit Function
            End If
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = YES Then Exit Function

        If Not IsSkill Then
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
                PlayerMsg(Attacker, "This is a safe zone!")
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If GetPlayerVital(Victim, Vitals.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > ADMIN_MONITOR Then
            PlayerMsg(Attacker, "You cannot attack any player for thou art an admin!")
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > ADMIN_MONITOR Then
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

    Function CanPlayerBlockHit(ByVal Index As Long) As Boolean
        Dim i As Long
        Dim n As Long
        Dim ShieldSlot As Long
        ShieldSlot = GetPlayerEquipment(Index, Equipment.Shield)

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
        Dim Armor As Long, Helm As Long, Shoes As Long, Gloves As Long
        GetPlayerProtection = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            Exit Function
        End If

        Armor = GetPlayerEquipment(Index, Equipment.Armor)
        Helm = GetPlayerEquipment(Index, Equipment.Helmet)
        Shoes = GetPlayerEquipment(Index, Equipment.Shoes)
        Gloves = GetPlayerEquipment(Index, Equipment.Gloves)
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

    Sub AttackPlayer(ByVal Attacker As Long, ByVal Victim As Long, ByVal Damage As Long, Optional ByVal skillnum As Long = 0)
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

            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

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
                SendEXP(Victim)
                PlayerMsg(Victim, "You lost " & exp & " exp.")
                SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendEXP(Attacker)
                PlayerMsg(Attacker, "You received " & exp & " exp.")
            End If

            ' Check for a level up
            CheckPlayerLevelUp(Attacker)

            ' Check if target is player who died and if so set target to 0
            If TempPlayer(Attacker).TargetType = TARGET_TYPE_PLAYER Then
                If TempPlayer(Attacker).Target = Victim Then
                    TempPlayer(Attacker).Target = 0
                    TempPlayer(Attacker).TargetType = TARGET_TYPE_NONE
                End If
            End If

            If GetPlayerPK(Victim) = NO Then
                If GetPlayerPK(Attacker) = NO Then
                    SetPlayerPK(Attacker, YES)
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
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            'if a stunning skill, stun the player
            If skillnum > 0 Then
                If Skill(skillnum).StunDuration > 0 Then StunPlayer(Victim, skillnum)
            End If
        End If

        ' Reset attack timer
        TempPlayer(Attacker).AttackTimer = GetTickCount()
    End Sub

    Public Sub StunPlayer(ByVal Index As Long, ByVal skillnum As Long)
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

    Function CanAttackNpc(ByVal Attacker As Long, ByVal MapNpcNum As Long, Optional ByVal IsSkill As Boolean = False) As Boolean
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

            If NpcNum > 0 And GetTickCount() > TempPlayer(Attacker).AttackTimer + attackspeed Then

                ' exit out early
                If IsSkill Then
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
                        If Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_FRIENDLY And Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_SHOPKEEPER And Npc(NpcNum).Behaviour <> NPC_BEHAVIOUR_QUEST Then
                            CanAttackNpc = True
                        Else
                            If Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_QUEST Then
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
                            ElseIf Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_FRIENDLY Or Npc(NpcNum).Behaviour = NPC_BEHAVIOUR_SHOPKEEPER Then
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

    Public Sub StunNPC(ByVal Index As Long, ByVal MapNum As Long, ByVal skillnum As Long)
        ' check if it's a stunning skill
        If Skill(skillnum).StunDuration > 0 Then
            ' set the values on index
            MapNpc(MapNum).Npc(Index).StunDuration = Skill(skillnum).StunDuration
            MapNpc(MapNum).Npc(Index).StunTimer = GetTickCount()
        End If
    End Sub

    Sub AttackNpc(ByVal Attacker As Long, ByVal MapNpcNum As Long, ByVal Damage As Long, Optional ByVal skillnum As Long = 0)
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

        If skillnum = 0 Then
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
            exp = Npc(NpcNum).Exp

            ' Make sure we dont get less then 0
            If exp < 0 Then
                exp = 1
            End If

            ' Check if in party, if so divide the exp up by 2
            If TempPlayer(Attacker).InParty = NO Then
                SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendEXP(Attacker)
                SendActionMsg(GetPlayerMap(Attacker), "+" & exp & " EXP", White, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
            Else
                exp = exp / 2

                If exp < 0 Then
                    exp = 1
                End If

                SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                SendEXP(Attacker)
                SendActionMsg(GetPlayerMap(Attacker), "+" & exp & " Shared EXP", White, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
                n = TempPlayer(Attacker).PartyPlayer

                If n > 0 Then
                    SetPlayerExp(n, GetPlayerExp(n) + exp)
                    SendEXP(n)
                    SendActionMsg(GetPlayerMap(n), "+" & exp & " EXP", White, 1, (GetPlayerX(n) * 32), (GetPlayerY(n) * 32))
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
            Buffer.WriteLong(ServerPackets.SNpcDead)
            Buffer.WriteLong(MapNpcNum)
            SendDataToMap(MapNum, Buffer.ToArray())
            Buffer = Nothing

            ' Check for level up
            CheckPlayerLevelUp(Attacker)

            ' Check for level up party member
            If TempPlayer(Attacker).InParty = YES Then
                CheckPlayerLevelUp(TempPlayer(Attacker).PartyPlayer)
            End If

            ' Check if target is npc that died and if so set target to 0
            If TempPlayer(Attacker).TargetType = TARGET_TYPE_NPC Then
                If TempPlayer(Attacker).Target = MapNpcNum Then
                    TempPlayer(Attacker).Target = 0
                    TempPlayer(Attacker).TargetType = TARGET_TYPE_NONE
                End If
            End If

            CheckTasks(Attacker, QUEST_TYPE_GOSLAY, NpcNum)

        Else
            ' NPC not dead, just do the damage
            MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) - Damage

            ' Check for a weapon and say damage
            SendActionMsg(MapNum, "-" & Damage, BrightRed, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)

            ' send animation
            If n > 0 Then
                If skillnum = 0 Then SendAnimation(MapNum, Item(GetPlayerEquipment(Attacker, Equipment.Weapon)).Animation, 0, 0, TARGET_TYPE_NPC, MapNpcNum)
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
            If Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Behaviour = NPC_BEHAVIOUR_GUARD Then

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
        If GetTickCount() < MapNpc(MapNum).Npc(MapNpcNum).AttackTimer + 1000 Then
            Exit Function
        End If

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Index).GettingMap = YES Then
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

    Function CanNpcAttackNpc(ByVal MapNum As Long, ByVal Attacker As Long, ByVal Victim As Long) As Boolean
        Dim aNpcNum As Long, vNpcNum As Long, VictimX As Long
        Dim VictimY As Long, AttackerX As Long, AttackerY As Long

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

    Sub NpcAttackPlayer(ByVal MapNpcNum As Long, ByVal Victim As Long, ByVal Damage As Long)
        Dim Name As String
        Dim MapNum As Long
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or IsPlaying(Victim) = False Then Exit Sub

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num <= 0 Then Exit Sub

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
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & CheckGrammar(Name))

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
            SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
            SendVital(Victim, Vitals.HP)
            SendAnimation(MapNum, Npc(MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num).Animation, 0, 0, TARGET_TYPE_PLAYER, Victim)
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
        End If

    End Sub

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

    Public Sub KnockBackNpc(ByVal Index As Long, ByVal NpcNum As Long, Optional IsSkill As Long = 0)
        If IsSkill > 0 Then
            For i = 1 To Skill(IsSkill).KnockBackTiles
                If CanNpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index)) Then
                    NpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index), MOVING_WALKING)
                End If
            Next
            MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunDuration = 1
            MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunTimer = GetTickCount()
        Else
            If Item(GetPlayerEquipment(Index, Equipment.Weapon)).KnockBack = 1 Then
                For i = 1 To Item(GetPlayerEquipment(Index, Equipment.Weapon)).KnockBackTiles
                    If CanNpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index)) Then
                        NpcMove(GetPlayerMap(Index), NpcNum, GetPlayerDir(Index), MOVING_WALKING)
                    End If
                Next
                MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunDuration = 1
                MapNpc(GetPlayerMap(Index)).Npc(NpcNum).StunTimer = GetTickCount()
            End If
        End If
    End Sub

#End Region

    Function isInRange(ByVal range As Long, ByVal x1 As Long, ByVal y1 As Long, ByVal x2 As Long, ByVal y2 As Long) As Boolean
        Dim nVal As Long
        isInRange = False
        nVal = Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
        If nVal <= range Then isInRange = True
    End Function

End Module
