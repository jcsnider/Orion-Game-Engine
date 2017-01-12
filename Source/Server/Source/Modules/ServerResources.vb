Imports System.IO

Public Module ServerResources
    Public SkillExpTable(100) As Integer

    Sub LoadSkillExp()
        Dim i As Integer
        Dim myXml As New XmlClass With {
            .Filename = Application.StartupPath & "\Data\SkillExp.xml",
            .Root = "Data"
        }

        For i = 1 To 100
            SkillExpTable(i) = myXml.ReadString("Level", i)
        Next
    End Sub

    Sub CheckResource(ByVal Index As Integer, ByVal x As Integer, ByVal y As Integer)
        Dim Resource_num As Integer, ResourceType As Byte
        Dim Resource_index As Integer
        Dim rX As Integer, rY As Integer
        Dim Damage As Integer

        If Map(GetPlayerMap(Index)).Tile(x, y).Type = TileType.Resource Then
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
                If GetPlayerEquipment(Index, EquipmentType.Weapon) > 0 Or Resource(Resource_index).ToolRequired = 0 Then
                    If Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Data3 = Resource(Resource_index).ToolRequired Then

                        ' inv space?
                        If Resource(Resource_index).ItemReward > 0 Then
                            If FindOpenInvSlot(Index, Resource(Resource_index).ItemReward) = 0 Then
                                PlayerMsg(Index, "You have no inventory space.", ColorType.Yellow)
                                Exit Sub
                            End If
                        End If

                        'required lvl?
                        If Resource(Resource_index).LvlRequired > GetPlayerGatherSkillLvl(Index, ResourceType) Then
                            PlayerMsg(Index, "Your level is too low!", ColorType.Yellow)
                            Exit Sub
                        End If

                        ' check if already cut down
                        If ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceState = 0 Then

                            rX = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).x
                            rY = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).y

                            If Resource(Resource_index).ToolRequired = 0 Then
                                Damage = 1 * GetPlayerGatherSkillLvl(Index, ResourceType)
                            Else
                                Damage = Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Data2
                            End If

                            ' check if damage is more than health
                            If Damage > 0 Then
                                ' cut it down!
                                If ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health - Damage <= 0 Then
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceState = 1 ' Cut
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).ResourceTimer = GetTickCount()
                                    SendResourceCacheToMap(GetPlayerMap(Index), Resource_num)
                                    SendActionMsg(GetPlayerMap(Index), Trim$(Resource(Resource_index).SuccessMessage), ColorType.BrightGreen, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                                    GiveInvItem(Index, Resource(Resource_index).ItemReward, 1)
                                    SendAnimation(GetPlayerMap(Index), Resource(Resource_index).Animation, rX, rY)
                                    SetPlayerGatherSkillExp(Index, ResourceType, GetPlayerGatherSkillExp(Index, ResourceType) + Resource(Resource_index).ExpReward)
                                    'send msg
                                    PlayerMsg(Index, String.Format("Your {0} has earned {1} experience. ({2}/{3})", GetResourceSkillName(ResourceType), Resource(Resource_index).ExpReward, GetPlayerGatherSkillExp(Index, ResourceType), GetPlayerGatherSkillMaxExp(Index, ResourceType)), ColorType.BrightGreen)
                                    SendPlayerData(Index)

                                    CheckResourceLevelUp(Index, ResourceType)
                                Else
                                    ' just do the damage
                                    ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health = ResourceCache(GetPlayerMap(Index)).ResourceData(Resource_num).cur_health - Damage
                                    SendActionMsg(GetPlayerMap(Index), "-" & Damage, ColorType.BrightRed, 1, (rX * 32), (rY * 32))
                                    SendAnimation(GetPlayerMap(Index), Resource(Resource_index).Animation, rX, rY)
                                End If
                                CheckTasks(Index, QUEST_TYPE_GOTRAIN, Resource_index)
                            Else
                                ' too weak
                                SendActionMsg(GetPlayerMap(Index), "Miss!", ColorType.BrightRed, 1, (rX * 32), (rY * 32))
                            End If
                        Else
                            SendActionMsg(GetPlayerMap(Index), Trim$(Resource(Resource_index).EmptyMessage), ColorType.BrightRed, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                        End If
                    Else
                        PlayerMsg(Index, "You have the wrong type of tool equiped.", ColorType.Yellow)
                    End If
                Else
                    PlayerMsg(Index, "You need a tool to interact with this resource.", ColorType.Yellow)
                End If
            End If
        End If
    End Sub

    Function GetPlayerGatherSkillLvl(ByVal Index As Integer, ByVal SkillSlot As Integer) As Integer

        GetPlayerGatherSkillLvl = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillLvl = Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillLevel
    End Function

    Function GetPlayerGatherSkillExp(ByVal Index As Integer, ByVal SkillSlot As Integer) As Integer

        GetPlayerGatherSkillExp = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillExp = Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillCurExp
    End Function

    Function GetPlayerGatherSkillMaxExp(ByVal Index As Integer, ByVal SkillSlot As Integer) As Integer

        GetPlayerGatherSkillMaxExp = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillMaxExp = Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillNextLvlExp
    End Function

    Sub SetPlayerGatherSkillLvl(ByVal Index As Integer, ByVal SkillSlot As Integer, ByVal lvl As Integer)
        If Index > MAX_PLAYERS Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillLevel = lvl
    End Sub

    Sub SetPlayerGatherSkillExp(ByVal Index As Integer, ByVal SkillSlot As Integer, ByVal Exp As Integer)
        If Index > MAX_PLAYERS Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillCurExp = Exp
    End Sub

    Sub SetPlayerGatherSkillMaxExp(ByVal Index As Integer, ByVal SkillSlot As Integer, ByVal MaxExp As Integer)
        If Index > MAX_PLAYERS Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).GatherSkills(SkillSlot).SkillNextLvlExp = MaxExp
    End Sub

    Sub CheckResourceLevelUp(ByVal Index As Integer, ByVal SkillSlot As Integer)
        Dim expRollover As Integer, skillname As String = ""
        Dim level_count As Integer

        level_count = 0

        If GetPlayerGatherSkillLvl(Index, SkillSlot) = 100 Then Exit Sub

        Do While GetPlayerGatherSkillExp(Index, SkillSlot) >= GetPlayerGatherSkillMaxExp(Index, SkillSlot)
            expRollover = GetPlayerGatherSkillExp(Index, SkillSlot) - GetPlayerGatherSkillMaxExp(Index, SkillSlot)
            SetPlayerGatherSkillLvl(Index, SkillSlot, GetPlayerGatherSkillLvl(Index, SkillSlot) + 1)
            SetPlayerGatherSkillExp(Index, SkillSlot, expRollover)
            SetPlayerGatherSkillMaxExp(Index, SkillSlot, GetSkillNextLevel(Index, SkillSlot))
            level_count = level_count + 1
        Loop

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                PlayerMsg(Index, String.Format("Your {0} has gone up a level!", GetResourceSkillName(SkillSlot)), ColorType.BrightGreen)
            Else
                'plural
                PlayerMsg(Index, String.Format("Your {0} has gone up by {1} levels!", GetResourceSkillName(SkillSlot), level_count), ColorType.BrightGreen)
            End If

            SavePlayer(Index)
            SendPlayerData(Index)
        End If
    End Sub

    Private Function GetResourceSkillName(ByVal ResSkill As ResourceSkills) As String
        Select Case ResSkill
            Case ResourceSkills.Herbalist
                GetResourceSkillName = "herbalism"
            Case ResourceSkills.WoodCutter
                GetResourceSkillName = "woodcutting"
            Case ResourceSkills.Miner
                GetResourceSkillName = "mining"
            Case ResourceSkills.Fisherman
                GetResourceSkillName = "fishing"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function

    Function GetSkillNextLevel(ByVal Index As Integer, ByVal SkillSlot As Integer) As Integer
        GetSkillNextLevel = 0
        If Index < 0 Or Index > MAX_PLAYERS Then Exit Function

        GetSkillNextLevel = SkillExpTable(GetPlayerGatherSkillLvl(Index, SkillSlot) + 1)
    End Function
End Module