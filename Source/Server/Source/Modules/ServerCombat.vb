Imports System.Linq

Public Module ServerCombat

#Region "PlayerCombat"
    Function CanPlayerAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, Optional ByVal IsSkill As Boolean = False) As Boolean

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
                PlayerMsg(Attacker, "This is a safe zone!", ColorType.BrightRed)
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If GetPlayerVital(Victim, Vitals.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack any player for thou art an admin!", ColorType.BrightRed)
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "!", ColorType.BrightRed)
            Exit Function
        End If

        ' Make sure attacker is high enough level
        If GetPlayerLevel(Attacker) < 10 Then
            PlayerMsg(Attacker, "You are below level 10, you cannot attack another player yet!", ColorType.BrightRed)
            Exit Function
        End If

        ' Make sure victim is high enough level
        If GetPlayerLevel(Victim) < 10 Then
            PlayerMsg(Attacker, GetPlayerName(Victim) & " is below level 10, you cannot attack this player yet!", ColorType.BrightRed)
            Exit Function
        End If

        CanPlayerAttackPlayer = True
    End Function

    Function CanPlayerBlockHit(ByVal Index As Integer) As Boolean
        Dim i As Integer
        Dim n As Integer
        Dim ShieldSlot As Integer
        ShieldSlot = GetPlayerEquipment(Index, EquipmentType.Shield)

        CanPlayerBlockHit = False

        If ShieldSlot > 0 Then
            n = Int(Rnd() * 2)

            If n = 1 Then
                i = (GetPlayerStat(Index, Stats.Endurance) \ 2) + (GetPlayerLevel(Index) \ 2)
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
                i = (GetPlayerStat(Index, Stats.Strength) \ 2) + (GetPlayerLevel(Index) \ 2)
                n = Int(Rnd() * 100) + 1

                If n <= i Then
                    CanPlayerCriticalHit = True
                End If
            End If
        End If

    End Function

    Function GetPlayerDamage(ByVal Index As Integer) As Integer
        Dim weaponNum As Integer

        GetPlayerDamage = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Then
            Exit Function
        End If

        If GetPlayerEquipment(Index, EquipmentType.Weapon) > 0 Then
            weaponNum = GetPlayerEquipment(Index, EquipmentType.Weapon)
            GetPlayerDamage = (GetPlayerStat(Index, Stats.Strength) * 2) + (Item(weaponNum).Data2 * 2) + (GetPlayerLevel(Index) * 3) + Random(0, 20)
        Else
            GetPlayerDamage = (GetPlayerStat(Index, Stats.Strength) * 2) + (GetPlayerLevel(Index) * 3) + Random(0, 20)
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
        GetPlayerProtection = (GetPlayerStat(Index, Stats.Endurance) \ 5)

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
                    PlayerMsg(Victim, "You lost no exp.", ColorType.BrightGreen)
                    PlayerMsg(Attacker, "You received no exp.", ColorType.BrightRed)
                Else
                    SetPlayerExp(Victim, GetPlayerExp(Victim) - exp)
                    SendExp(Victim)
                    PlayerMsg(Victim, "You lost " & exp & " exp.", ColorType.BrightRed)
                    SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp)
                    SendExp(Attacker)
                    PlayerMsg(Attacker, "You received " & exp & " exp.", ColorType.BrightGreen)
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
            PlayerMsg(Index, "You have been stunned!", ColorType.Yellow)
        End If
    End Sub

    Function CanPlayerAttackNpc(ByVal Attacker As Integer, ByVal MapNpcNum As Integer, Optional ByVal IsSkill As Boolean = False) As Boolean
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
                        CanPlayerAttackNpc = True
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
                            CanPlayerAttackNpc = True
                        Else
                            If Npc(NpcNum).Behaviour = NpcBehavior.Quest Then
                                If QuestCompleted(Attacker, Npc(NpcNum).QuestNum) Then
                                    PlayerMsg(Attacker, Trim$(Npc(NpcNum).Name) & ": " & Trim$(Npc(NpcNum).AttackSay), ColorType.Yellow)
                                    Exit Function
                                ElseIf Not CanStartQuest(Attacker, Npc(NpcNum).QuestNum) And Not QuestInProgress(Attacker, Npc(NpcNum).QuestNum) Then
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
                                PlayerMsg(Attacker, Trim$(Npc(NpcNum).Name) & ": " & Trim$(Npc(NpcNum).AttackSay), ColorType.Yellow)
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

    Sub PlayerAttackNpc(ByVal Attacker As Integer, ByVal MapNpcNum As Integer, ByVal Damage As Integer)
        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Damage < 0 Then Exit Sub

        Dim MapNum = GetPlayerMap(Attacker)
        Dim NpcNum = MapNpc(MapNum).Npc(MapNpcNum).Num
        Dim Name = Npc(NpcNum).Name.Trim()

        ' Check for weapon
        Dim Weapon = 0
        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            Weapon = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        ' Deal damage to our NPC.
        MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) - Damage

        ' Set the NPC target to the player so they can come after them.
        MapNpc(MapNum).Npc(MapNpcNum).TargetType = TargetType.Player
        MapNpc(MapNum).Npc(MapNpcNum).Target = Attacker

        ' Check for any mobs on the map with the Guard behaviour so they can come after our player.
        If Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Behaviour = NpcBehavior.Guard Then
            For Each Guard In MapNpc(MapNum).Npc.Where(Function(x) x.Num = MapNpc(MapNum).Npc(MapNpcNum).Num).Select(Function(x, y) y + 1).ToArray()
                MapNpc(MapNum).Npc(Guard).Target = Attacker
                MapNpc(MapNum).Npc(Guard).TargetType = TargetType.Player
            Next
        End If

        ' Send our general visual stuff.
        SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
        SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)
        SendPlayerAttack(Attacker)
        If Weapon > 0 Then
            SendAnimation(MapNum, Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Animation, 0, 0, TargetType.Npc, MapNpcNum)
        End If

        ' Reset our attack timer.
        TempPlayer(Attacker).AttackTimer = GetTickCount()

        If Not IsNpcDead(MapNum, MapNpcNum) Then
            ' Check if our NPC has something to share with our player.
            If MapNpc(MapNum).Npc(MapNpcNum).Target = 0 Then
                If Len(Trim$(Npc(NpcNum).AttackSay)) > 0 Then
                    PlayerMsg(Attacker, String.Format("{0} says: '{1}'", Npc(NpcNum).Name.Trim(), Npc(NpcNum).AttackSay.Trim()), ColorType.Yellow)
                End If
            End If

            SendMapNpcTo(MapNum, MapNpcNum)
        Else
            HandlePlayerKillNpc(MapNum, Attacker, MapNpcNum)
        End If
    End Sub
#End Region

#Region "Npcombat"
    Public Sub TryNpcAttackPlayer(ByVal mapnpcnum As Integer, ByVal Index As Integer)

        Dim MapNum As Integer, npcnum As Integer, Damage As Integer, i As Integer, armor As Integer

        ' Can the npc attack the player?

        If CanNpcAttackPlayer(mapnpcnum, Index) Then
            MapNum = GetPlayerMap(Index)
            npcnum = MapNpc(MapNum).Npc(mapnpcnum).Num

            ' check if PLAYER can avoid the attack
            If CanPlayerDodge(Index) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (Player(Index).Character(TempPlayer(Index).CurChar).x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).y * 32))
                Exit Sub
            End If

            If CanPlayerParry(Index) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (Player(Index).Character(TempPlayer(Index).CurChar).x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).y * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetNpcDamage(npcnum)

            If CanPlayerBlockHit(Index) Then
                SendActionMsg(MapNum, "Block!", ColorType.Pink, 1, (Player(Index).Character(TempPlayer(Index).CurChar).x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).y * 32))
                Exit Sub
            Else

                For i = 2 To EquipmentType.Count - 1 ' start at 2, so we skip weapon
                    If GetPlayerEquipment(Index, i) > 0 Then
                        armor = armor + Item(GetPlayerEquipment(Index, i)).Data2
                    End If
                Next
                ' take away armour
                Damage = Damage - ((GetPlayerStat(Index, Stats.Spirit) * 2) + (GetPlayerLevel(Index) * 2) + armor)

                ' * 1.5 if crit hit
                If CanNpcCrit(npcnum) Then
                    Damage = Damage * 1.5
                    SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (MapNpc(MapNum).Npc(mapnpcnum).x * 32), (MapNpc(MapNum).Npc(mapnpcnum).y * 32))
                End If

            End If

            If Damage > 0 Then
                NpcAttackPlayer(mapnpcnum, Index, Damage)
            End If

        End If

    End Sub

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

    Public Sub NpcAttackPlayer(ByVal MapNpcNum As Integer, ByVal Victim As Integer, ByVal Damage As Integer)
        Dim Name As String, MapNum As Integer
        Dim z As Integer, InvCount As Integer, EqCount As Integer, j As Integer, x As Integer
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
        SendDataToMap(MapNum, Buffer.ToArray)
        Buffer = Nothing

        If Damage <= 0 Then Exit Sub

        ' set the regen timer
        MapNpc(MapNum).Npc(MapNpcNum).stopRegen = True
        MapNpc(MapNum).Npc(MapNpcNum).stopRegenTimer = GetTickCount()

        If Damage >= GetPlayerVital(Victim, Vitals.HP) Then
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & GetPlayerVital(Victim, Vitals.HP), ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            ' Set NPC target to 0
            MapNpc(MapNum).Npc(MapNpcNum).Target = 0
            MapNpc(MapNum).Npc(MapNpcNum).TargetType = 0

            If GetPlayerLevel(Victim) >= 10 Then

                For z = 1 To MAX_INV
                    If GetPlayerInvItemNum(Victim, z) > 0 Then
                        InvCount = InvCount + 1
                    End If
                Next

                For z = 1 To EquipmentType.Count - 1
                    If GetPlayerEquipment(Victim, z) > 0 Then
                        EqCount = EqCount + 1
                    End If
                Next
                z = Random(1, InvCount + EqCount)

                If z = 0 Then z = 1
                If z > InvCount + EqCount Then z = InvCount + EqCount
                If z > InvCount Then
                    z = z - InvCount

                    For x = 1 To EquipmentType.Count - 1

                        If GetPlayerEquipment(Victim, x) > 0 Then
                            j = j + 1

                            If j = z Then
                                'Here it is, drop this piece of equipment!
                                PlayerMsg(Victim, "In death you lost grip on your " & Trim$(Item(GetPlayerEquipment(Victim, x)).Name), ColorType.BrightRed)
                                SpawnItem(GetPlayerEquipment(Victim, x), 1, GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))
                                SetPlayerEquipment(Victim, 0, x)
                                SendWornEquipment(Victim)
                                SendMapEquipment(Victim)
                            End If
                        End If
                    Next
                Else
                    For x = 1 To MAX_INV
                        If GetPlayerInvItemNum(Victim, x) > 0 Then
                            j = j + 1

                            If j = z Then
                                'Here it is, drop this item!
                                PlayerMsg(Victim, "In death you lost grip on your " & Trim$(Item(GetPlayerInvItemNum(Victim, x)).Name), ColorType.BrightRed)
                                SpawnItem(GetPlayerInvItemNum(Victim, x), GetPlayerInvItemValue(Victim, x), GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))
                                SetPlayerInvItemNum(Victim, x, 0)
                                SetPlayerInvItemValue(Victim, x, 0)
                                SendInventory(Victim)
                            End If
                        End If
                    Next
                End If
            End If

            ' kill player
            KillPlayer(Victim)

            ' Player is dead
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & Name)
        Else
            ' Player not dead, just do the damage
            SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
            SendVital(Victim, Vitals.HP)
            SendAnimation(MapNum, Npc(MapNpc(GetPlayerMap(Victim)).Npc(MapNpcNum).Num).Animation, 0, 0, TargetType.Player, Victim)

            ' send vitals to party if in one
            If TempPlayer(Victim).InParty > 0 Then SendPartyVitals(TempPlayer(Victim).InParty, Victim)

            ' send the sound
            'SendMapSound Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seNpc, MapNpc(MapNum).Npc(MapNpcNum).Num

            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
            SendBlood(GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))

            ' set the regen timer
            TempPlayer(Victim).stopRegen = True
            TempPlayer(Victim).stopRegenTimer = GetTickCount()

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

    Public Function RandomNpcAttack(ByVal MapNum As Integer, ByVal MapNpcNum As Integer) As Integer
        Dim i As Integer, SkillList As New List(Of Byte)

        RandomNpcAttack = 0

        If MapNpc(MapNum).Npc(MapNpcNum).SkillBuffer > 0 Then Exit Function

        For i = 1 To MAX_NPC_SKILLS
            If Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Skill(i) > 0 Then
                SkillList.Add(Npc(MapNpc(MapNum).Npc(MapNpcNum).Num).Skill(i))
            End If
        Next

        If SkillList.Count > 1 Then
            RandomNpcAttack = SkillList(Random(0, SkillList.Count - 1))
        Else
            RandomNpcAttack = 0
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
            TryNpcAttackPlayer(MapNpcNum, MapNpc(MapNum).Npc(MapNpcNum).Target)
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

    Public Function CanNpcBlock(ByVal npcnum As Integer) As Boolean
        Dim rate As Integer
        Dim stat As Integer
        Dim rndNum As Integer

        CanNpcBlock = False

        stat = Npc(npcnum).Stat(Stats.Luck) / 5  'guessed shield agility
        rate = stat / 12.08
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanNpcBlock = True

    End Function

    Public Function CanNpcCrit(ByVal npcnum As Integer) As Boolean
        Dim rate As Integer
        Dim rndNum As Integer

        CanNpcCrit = False

        rate = Npc(npcnum).Stat(Stats.Luck) / 3
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanNpcCrit = True

    End Function

    Public Function CanNpcDodge(ByVal npcnum As Integer) As Boolean
        Dim rate As Integer
        Dim rndNum As Integer

        CanNpcDodge = False

        rate = Npc(npcnum).Stat(Stats.Luck) / 4
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanNpcDodge = True

    End Function

    Public Function CanNpcParry(ByVal npcnum As Integer) As Boolean
        Dim rate As Integer
        Dim rndNum As Integer

        CanNpcParry = False

        rate = Npc(npcnum).Stat(Stats.Luck) / 6
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanNpcParry = True

    End Function

    Function GetNpcDamage(ByVal npcnum As Integer) As Integer

        GetNpcDamage = (Npc(npcnum).Stat(Stats.Strength) * 2) + (Npc(npcnum).Damage * 2) + (Npc(npcnum).Level * 3) + Random(1, 20)

    End Function

    Public Sub SpellPlayer_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Integer, ByVal Damage As Integer, ByVal Skillnum As Integer)
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

            ' send the sound
            'SendMapSound Index, GetPlayerX(Index), GetPlayerY(Index), SoundEntity.seSpell, Spellnum

            If increment Then
                SetPlayerVital(Index, Vital, GetPlayerVital(Index, Vital) + Damage)

                If Skill(Skillnum).Duration > 0 Then
                    'AddHoT_Player(Index, Spellnum)
                End If

            ElseIf Not increment Then
                SetPlayerVital(Index, Vital, GetPlayerVital(Index, Vital) - Damage)
            End If

            SendVital(Index, Vital)

        End If

    End Sub

    Public Sub SpellNpc_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Integer, ByVal Damage As Integer, ByVal Skillnum As Integer, ByVal MapNum As Integer)
        Dim sSymbol As String
        Dim Colour As Long

        If Damage > 0 Then
            If increment Then
                sSymbol = "+"
                If Vital = Vitals.HP Then Colour = ColorType.BrightGreen
                If Vital = Vitals.MP Then Colour = ColorType.BrightBlue
            Else
                sSymbol = "-"
                Colour = ColorType.Blue
            End If

            SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Npc, Index)
            SendActionMsg(MapNum, sSymbol & Damage, Colour, ActionMsgType.Scroll, MapNpc(MapNum).Npc(Index).x * 32, MapNpc(MapNum).Npc(Index).y * 32)

            ' send the sound
            'SendMapSound(Index, MapNpc(MapNum).Npc(Index).x, MapNpc(MapNum).Npc(Index).y, SoundEntity.seSpell, Skillnum)

            If increment Then
                MapNpc(MapNum).Npc(Index).Vital(Vital) = MapNpc(MapNum).Npc(Index).Vital(Vital) + Damage

                If Skill(Skillnum).Duration > 0 Then
                    'AddHoT_Npc(MapNum, Index, Skillnum, 0)
                End If

            ElseIf Not increment Then
                MapNpc(MapNum).Npc(Index).Vital(Vital) = MapNpc(MapNum).Npc(Index).Vital(Vital) - Damage
            End If

        End If

    End Sub

    Public Function CanPlayerDodge(ByVal Index As Integer) As Boolean
        Dim rate As Long, rndNum As Long

        CanPlayerDodge = False

        rate = GetPlayerStat(Index, Stats.Luck) / 4
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPlayerDodge = True
        End If

    End Function

    Public Function CanPlayerParry(ByVal Index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        CanPlayerParry = False

        rate = GetPlayerStat(Index, Stats.Luck) / 6
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPlayerParry = True
        End If

    End Function

    Public Sub TryPlayerAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer)
        Dim MapNum As Integer
        Dim Damage As Integer, i As Integer, armor As Integer

        Damage = 0

        ' Can we attack the player?
        If CanPlayerAttackPlayer(Attacker, Victim) Then

            MapNum = GetPlayerMap(Attacker)

            ' check if NPC can avoid the attack
            If CanPlayerDodge(Victim) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            If CanPlayerParry(Victim) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPlayerDamage(Attacker)

            If CanPlayerBlockHit(Victim) Then
                SendActionMsg(MapNum, "Block!", ColorType.BrightCyan, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Damage = 0
                Exit Sub
            Else

                For i = 1 To EquipmentType.Count - 1
                    If GetPlayerEquipment(Victim, i) > 0 Then
                        armor = armor + Item(GetPlayerEquipment(Victim, i)).Data2
                    End If
                Next

                ' take away armour
                Damage = Damage - ((GetPlayerStat(Victim, Stats.Spirit) * 2) + (GetPlayerLevel(Victim) * 3) + armor)

                ' * 1.5 if it's a crit!
                If CanPlayerCriticalHit(Attacker) Then
                    Damage = Damage * 1.5
                    SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
                End If
            End If

            If Damage > 0 Then
                PlayerAttackPlayer(Attacker, Victim, Damage)
            Else
                PlayerMsg(Attacker, "Your attack does nothing.", ColorType.BrightRed)
            End If

        End If

    End Sub

    Sub PlayerAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer)
        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage <= 0 Then
            Exit Sub
        End If

        ' Check if our assailant has a weapon.
        Dim Weapon = 0
        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            Weapon = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        ' Stop our player's regeneration abilities.
        TempPlayer(Attacker).stopRegen = True
        TempPlayer(Attacker).stopRegenTimer = GetTickCount()

        ' Deal damage to our player.
        SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)

        ' Send all the visuals to our player.
        If Weapon > 0 Then
            SendAnimation(GetPlayerMap(Victim), Item(Weapon).Animation, 0, 0, TargetType.Player, Victim)
        End If
        SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
        SendBlood(GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))

        ' set the regen timer
        TempPlayer(Victim).stopRegen = True
        TempPlayer(Victim).stopRegenTimer = GetTickCount()

        ' Reset attack timer
        TempPlayer(Attacker).AttackTimer = GetTickCount()

        If Not IsPlayerDead(Victim) Then
            ' Send our player's new vitals to everyone that needs them.
            SendVital(Victim, Vitals.HP)
            If TempPlayer(Victim).InParty > 0 Then SendPartyVitals(TempPlayer(Victim).InParty, Victim)
        Else
            ' Handle our dead player.
            HandlePlayerKillPlayer(Attacker, Victim)
        End If
    End Sub

    Public Sub TryPlayerAttackNpc(ByVal Index As Integer, ByVal mapnpcnum As Integer)

        Dim npcnum As Integer

        Dim MapNum As Integer

        Dim Damage As Integer

        Damage = 0

        ' Can we attack the npc?
        If CanPlayerAttackNpc(Index, mapnpcnum) Then

            MapNum = GetPlayerMap(Index)
            npcnum = MapNpc(MapNum).Npc(mapnpcnum).Num

            ' check if NPC can avoid the attack
            If CanNpcDodge(npcnum) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (MapNpc(MapNum).Npc(mapnpcnum).x * 32), (MapNpc(MapNum).Npc(mapnpcnum).y * 32))
                Exit Sub
            End If

            If CanNpcParry(npcnum) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (MapNpc(MapNum).Npc(mapnpcnum).x * 32), (MapNpc(MapNum).Npc(mapnpcnum).y * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPlayerDamage(Index)

            If CanNpcBlock(npcnum) Then
                SendActionMsg(MapNum, "Block!", ColorType.BrightCyan, 1, (MapNpc(MapNum).Npc(mapnpcnum).x * 32), (MapNpc(MapNum).Npc(mapnpcnum).y * 32))
                Damage = 0
                Exit Sub
            Else

                Damage = Damage - ((Npc(npcnum).Stat(Stats.Spirit) * 2) + (Npc(npcnum).Level * 3))

                ' * 1.5 if it's a crit!
                If CanPlayerCriticalHit(Index) Then
                    Damage = Damage * 1.5
                    SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                End If

            End If

            TempPlayer(Index).Target = mapnpcnum
            TempPlayer(Index).TargetType = TargetType.Npc
            SendTarget(Index, mapnpcnum, TargetType.Npc)

            If Damage > 0 Then
                PlayerAttackNpc(Index, mapnpcnum, Damage)
            Else
                PlayerMsg(Index, "Your attack does nothing.", ColorType.BrightRed)
            End If

        End If

    End Sub

    Public Function IsNpcDead(ByVal MapNum As Integer, ByVal MapNpcNum As Integer)
        IsNpcDead = False
        If MapNum < 0 Or MapNum > MAX_MAPS Or MapNpcNum < 0 Or MapNpcNum > MAX_MAP_NPCS Then Exit Function
        If MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) <= 0 Then IsNpcDead = True
    End Function

    Public Function IsPlayerDead(ByVal Index As Integer)
        IsPlayerDead = False
        If Index < 0 Or Index > MAX_PLAYERS Or Not TempPlayer(Index).InGame Then Exit Function
        If GetPlayerVital(Index, Vitals.HP) <= 0 Then IsPlayerDead = True
    End Function

    Public Sub DropNpcItems(ByVal MapNum As Integer, ByVal MapNpcNum As Integer)
        Dim NpcNum = MapNpc(MapNum).Npc(MapNpcNum).Num
        Dim tmpitem = Random(1, 5)
        Dim n = Int(Rnd() * Npc(NpcNum).DropChance(tmpitem)) + 1

        If n = 1 Then
            SpawnItem(Npc(NpcNum).DropItem(tmpitem), Npc(NpcNum).DropItemValue(tmpitem), MapNum, MapNpc(MapNum).Npc(MapNpcNum).x, MapNpc(MapNum).Npc(MapNpcNum).y)
        End If
    End Sub

    Public Sub HandlePlayerKillPlayer(ByVal Attacker As Integer, ByVal Victim As Integer)
        ' Notify everyone that our player has bit the dust.
        GlobalMsg(String.Format("{0} has been killed by {1}!", GetPlayerName(Victim), GetPlayerName(Attacker)))

        ' Hand out player experience
        HandlePlayerKillExperience(Attacker, Victim)

        ' Handle our PK outcomes.
        HandlePlayerKilledPK(Attacker, Victim)

        ' Remove our player from everyone's target list.
        For Each p In TempPlayer.Where(Function(x, i) x.InGame AndAlso GetPlayerMap(i + 1) = GetPlayerMap(Victim) AndAlso x.TargetType = TargetType.Player AndAlso x.Target = Victim).Select(Function(x, i) i + 1).ToArray()
            TempPlayer(p).Target = 0
            TempPlayer(p).TargetZone = 0
            TempPlayer(p).TargetType = TargetType.None
            SendTarget(p, 0, TargetType.None)
        Next

        ' Actually kill the player.
        OnDeath(Victim)

        ' Handle our quest system stuff.
        CheckTasks(Attacker, QUEST_TYPE_GOKILL, 0)
    End Sub

    Public Sub HandlePlayerKillNpc(ByVal MapNum As Integer, ByVal Index As Integer, ByVal MapNpcNum As Integer)
        ' Set our attacker's target to nothing.
        SendTarget(Index, 0, TargetType.None)

        ' Hand out player experience
        HandleNpcKillExperience(Index, MapNpcNum)

        ' Drop items if we can.
        DropNpcItems(MapNum, MapNpcNum)

        ' Handle quest tasks related to NPC death
        CheckTasks(Index, QUEST_TYPE_GOSLAY, MapNpc(MapNum).Npc(MapNpcNum).Num)

        ' Set our NPC's data to default so we know it's dead.
        MapNpc(MapNum).Npc(MapNpcNum).Num = 0
        MapNpc(MapNum).Npc(MapNpcNum).SpawnWait = GetTickCount()
        MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) = 0

        ' Notify all our clients that the NPC has died.
        SendNpcDead(MapNum, MapNpcNum)

        ' Check if our dead NPC is targetted by another player and remove their targets.
        For Each p In TempPlayer.Where(Function(x, i) x.InGame AndAlso GetPlayerMap(i + 1) = MapNum AndAlso x.TargetType = TargetType.Npc AndAlso x.Target = MapNpcNum).Select(Function(x, i) i + 1).ToArray()
            TempPlayer(p).Target = 0
            TempPlayer(p).TargetType = TargetType.None
            SendTarget(p, 0, TargetType.None)
        Next
    End Sub

    Public Sub HandlePlayerKilledPK(ByVal Attacker As Integer, ByVal Victim As Integer)
        ' TODO: Redo this method, it is horrendous.
        Dim z As Integer, eqcount As Integer, invcount, j As Integer
        If GetPlayerPK(Victim) = 0 Then
            If GetPlayerPK(Attacker) = 0 Then
                SetPlayerPK(Attacker, 1)
                SendPlayerData(Attacker)
                GlobalMsg(GetPlayerName(Attacker) & " has been deemed a Player Killer!!!")
            End If

        Else
            GlobalMsg(GetPlayerName(Victim) & " has paid the price for being a Player Killer!!!")
        End If

        If GetPlayerLevel(Victim) >= 10 Then

            For z = 1 To MAX_INV
                If GetPlayerInvItemNum(Victim, z) > 0 Then
                    invcount = invcount + 1
                End If
            Next

            For z = 1 To EquipmentType.Count - 1
                If GetPlayerEquipment(Victim, z) > 0 Then
                    eqcount = eqcount + 1
                End If
            Next
            z = Random(1, invcount + eqcount)

            If z = 0 Then z = 1
            If z > invcount + eqcount Then z = invcount + eqcount
            If z > invcount Then
                z = z - invcount

                For x = 1 To EquipmentType.Count - 1
                    If GetPlayerEquipment(Victim, x) > 0 Then
                        j = j + 1

                        If j = z Then
                            'Here it is, drop this piece of equipment!
                            PlayerMsg(Victim, "In death you lost grip on your " & Trim$(Item(GetPlayerEquipment(Victim, x)).Name), ColorType.BrightRed)
                            SpawnItem(GetPlayerEquipment(Victim, x), 1, GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))
                            SetPlayerEquipment(Victim, 0, x)
                            SendWornEquipment(Victim)
                            SendMapEquipment(Victim)
                        End If
                    End If
                Next
            Else

                For x = 1 To MAX_INV
                    If GetPlayerInvItemNum(Victim, x) > 0 Then
                        j = j + 1

                        If j = z Then
                            'Here it is, drop this item!
                            PlayerMsg(Victim, "In death you lost grip on your " & Trim$(Item(GetPlayerInvItemNum(Victim, x)).Name), ColorType.BrightRed)
                            SpawnItem(GetPlayerInvItemNum(Victim, x), GetPlayerInvItemValue(Victim, x), GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))
                            SetPlayerInvItemNum(Victim, x, 0)
                            SetPlayerInvItemValue(Victim, x, 0)
                            SendInventory(Victim)
                        End If
                    End If
                Next
            End If
        End If
    End Sub
End Module