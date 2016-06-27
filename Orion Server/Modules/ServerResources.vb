Public Module ServerResources
    Public SkillExpTable(100) As Long

    Sub LoadSkillExp()
        Dim i As Long

        For i = 1 To 100
            SkillExpTable(i) = CLng(Getvar(Application.StartupPath & "\SkillExp.ini", "Level", i))
        Next
    End Sub

    Sub CheckResource(ByVal Index As Long, ByVal x As Long, ByVal y As Long)
        Dim Resource_num As Long, ResourceType As Byte
        Dim Resource_index As Long
        Dim rX As Long, rY As Long
        Dim i As Long
        Dim Damage As Long

        If Map(GetPlayerMap(Index)).Tile(x, y).Type = TILE_TYPE_RESOURCE Then
            Resource_num = 0
            Resource_index = Map(GetPlayerMap(Index)).Tile(x, y).Data1
            ResourceType = Resource(Resource_index).ResourceType

            ' Get the cache number
            For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count

                If ResourceCache(GetPlayerMap(Index)).ResourceData(i).x = x Then
                    If ResourceCache(GetPlayerMap(Index)).ResourceData(i).y = y Then
                        Resource_num = i
                    End If
                End If

            Next

            If Resource_num > 0 Then
                If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Or Resource(Resource_index).ToolRequired = 0 Then
                    If Item(GetPlayerEquipment(Index, Equipment.Weapon)).Data3 = Resource(Resource_index).ToolRequired Then

                        ' inv space?
                        If Resource(Resource_index).ItemReward > 0 Then
                            If FindOpenInvSlot(Index, Resource(Resource_index).ItemReward) = 0 Then
                                PlayerMsg(Index, "You have no inventory space.")
                                Exit Sub
                            End If
                        End If

                        'required lvl?
                        If Resource(Resource_index).LvlRequired > GetPlayerGatherSkillLvl(Index, ResourceType) Then
                            PlayerMsg(Index, "You're level is to low!")
                            Exit Sub
                        End If

                        ' check if already cut down
                        If ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceState = 0 Then

                            rX = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).x
                            rY = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).y

                            If Resource(Resource_index).ToolRequired = 0 Then
                                Damage = 1 * GetPlayerGatherSkillLvl(Index, ResourceType)
                            Else
                                Damage = Item(GetPlayerEquipment(Index, Equipment.Weapon)).Data2
                            End If


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
                                    SetPlayerGatherSkillExp(Index, ResourceType, GetPlayerGatherSkillExp(Index, ResourceType) + Resource(Resource_index).ExpReward)
                                    'send msg
                                    Select Case ResourceType
                                        Case ResourceSkills.Herbalist
                                            PlayerMsg(Index, "Your herbalist skill earned " & Resource(Resource_index).ExpReward & " Exp, " & GetPlayerGatherSkillExp(Index, ResourceType) & "/" & GetPlayerGatherSkillMaxExp(Index, ResourceType))
                                        Case ResourceSkills.WoodCutter
                                            PlayerMsg(Index, "Your woodcutter skill earned " & Resource(Resource_index).ExpReward & " Exp, " & GetPlayerGatherSkillExp(Index, ResourceType) & "/" & GetPlayerGatherSkillMaxExp(Index, ResourceType))
                                        Case ResourceSkills.Miner
                                            PlayerMsg(Index, "Your miner skill earned " & Resource(Resource_index).ExpReward & " Exp, " & GetPlayerGatherSkillExp(Index, ResourceType) & "/" & GetPlayerGatherSkillMaxExp(Index, ResourceType))
                                        Case ResourceSkills.Fisherman
                                            PlayerMsg(Index, "Your fishing skill earned " & Resource(Resource_index).ExpReward & " Exp, " & GetPlayerGatherSkillExp(Index, ResourceType) & "/" & GetPlayerGatherSkillMaxExp(Index, ResourceType))
                                    End Select
                                    SendPlayerData(Index)

                                    CheckResourceLevelUp(Index, ResourceType)
                                Else
                                    ' just do the damage
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health - Damage
                                    SendActionMsg(GetPlayerMap(Index), "-" & Damage, BrightRed, 1, (rX * 32), (rY * 32))
                                    SendAnimation(GetPlayerMap(Index), Resource(Resource_index).Animation, rX, rY)
                                End If
                                CheckTasks(Index, QUEST_TYPE_GOTRAIN, Resource_index)
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

    Function GetPlayerGatherSkillLvl(ByVal Index As Long, ByVal SkillSlot As Long) As Long

        GetPlayerGatherSkillLvl = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillLvl = Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillLevel
    End Function

    Function GetPlayerGatherSkillExp(ByVal Index As Long, ByVal SkillSlot As Long) As Long

        GetPlayerGatherSkillExp = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillExp = Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillCurExp
    End Function

    Function GetPlayerGatherSkillMaxExp(ByVal Index As Long, ByVal SkillSlot As Long) As Long

        GetPlayerGatherSkillMaxExp = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillMaxExp = Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillNextLvlExp
    End Function

    Sub SetPlayerGatherSkillLvl(ByVal Index As Long, ByVal SkillSlot As Long, ByVal lvl As Long)
        If Index > MAX_PLAYERS Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillLevel = lvl
    End Sub

    Sub SetPlayerGatherSkillExp(ByVal Index As Long, ByVal SkillSlot As Long, ByVal Exp As Long)
        If Index > MAX_PLAYERS Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillCurExp = Exp
    End Sub

    Sub SetPlayerGatherSkillMaxExp(ByVal Index As Long, ByVal SkillSlot As Long, ByVal MaxExp As Long)
        If Index > MAX_PLAYERS Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillNextLvlExp = MaxExp
    End Sub

    Sub CheckResourceLevelUp(ByVal Index As Long, ByVal SkillSlot As Long)
        Dim expRollover As Long, skillname As String = ""
        Dim level_count As Long

        level_count = 0

        If GetPlayerGatherSkillLvl(Index, SkillSlot) = 100 Then Exit Sub

        Do While GetPlayerGatherSkillExp(Index, SkillSlot) >= GetPlayerGatherSkillMaxExp(Index, SkillSlot)
            expRollover = GetPlayerGatherSkillExp(Index, SkillSlot) - GetPlayerGatherSkillMaxExp(Index, SkillSlot)
            SetPlayerGatherSkillLvl(Index, SkillSlot, GetPlayerGatherSkillLvl(Index, SkillSlot) + 1)
            SetPlayerGatherSkillExp(Index, SkillSlot, expRollover)
            SetPlayerGatherSkillMaxExp(Index, SkillSlot, GetSkillNextLevel(Index, SkillSlot))
            level_count = level_count + 1
        Loop

        Select Case SkillSlot
            Case ResourceSkills.Herbalist
                skillname = "herbalist"
            Case ResourceSkills.WoodCutter
                skillname = "woodcutter"
            Case ResourceSkills.Miner
                skillname = "miner"
            Case ResourceSkills.Fisherman
                skillname = "fishing"
        End Select

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                PlayerMsg(Index, "You're " & skillname & " has gained " & level_count & " level!")
            Else
                'plural
                PlayerMsg(Index, "You're " & skillname & " has gained " & level_count & " levels!")
            End If

            SavePlayer(Index)
            SendPlayerData(Index)
        End If
    End Sub

    Function GetSkillNextLevel(ByVal Index As Long, ByVal SkillSlot As Long) As Long
        GetSkillNextLevel = 0
        If Index < 0 Or Index > MAX_PLAYERS Then Exit Function

        GetSkillNextLevel = SkillExpTable(GetPlayerGatherSkillLvl(Index, SkillSlot) + 1)
    End Function
End Module
