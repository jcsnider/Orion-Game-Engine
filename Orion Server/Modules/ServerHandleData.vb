Module ServerHandleData

    Private Delegate Sub Packet_(ByVal Index As Long, ByVal Data() As Byte)
    Private Packets As Dictionary(Of Integer, Packet_)

    Public Sub InitMessages()
        Packets = New Dictionary(Of Integer, Packet_)

        Packets.Add(ClientPackets.CNewAccount, AddressOf Packet_NewAccount)
        'Packets.Add(ClientPackets.CDelAccount, AddressOf Packet_DeleteAccount)
        Packets.Add(ClientPackets.CLogin, AddressOf Packet_Login)
        Packets.Add(ClientPackets.CAddChar, AddressOf Packet_AddChar)
        Packets.Add(ClientPackets.CUseChar, AddressOf Packet_UseChar)
        Packets.Add(ClientPackets.CDelChar, AddressOf Packet_DeleteChar)
        Packets.Add(ClientPackets.CSayMsg, AddressOf Packet_SayMessage)
        Packets.Add(ClientPackets.CEmoteMsg, AddressOf Packet_EmoteMsg)
        Packets.Add(ClientPackets.CBroadcastMsg, AddressOf Packet_BroadCastMsg)
        Packets.Add(ClientPackets.CPlayerMsg, AddressOf Packet_PlayerMsg)
        Packets.Add(ClientPackets.CPlayerMove, AddressOf Packet_PlayerMove)
        Packets.Add(ClientPackets.CPlayerDir, AddressOf Packet_PlayerDirection)
        Packets.Add(ClientPackets.CUseItem, AddressOf Packet_UseItem)
        Packets.Add(ClientPackets.CAttack, AddressOf Packet_Attack)
        Packets.Add(ClientPackets.CPlayerInfoRequest, AddressOf Packet_PlayerInfo)
        Packets.Add(ClientPackets.CWarpMeTo, AddressOf Packet_WarpMeTo)
        Packets.Add(ClientPackets.CWarpToMe, AddressOf Packet_WarpToMe)
        Packets.Add(ClientPackets.CWarpTo, AddressOf Packet_WarpTo)
        Packets.Add(ClientPackets.CSetSprite, AddressOf Packet_SetSprite)
        Packets.Add(ClientPackets.CGetStats, AddressOf Packet_GetStats)
        Packets.Add(ClientPackets.CRequestNewMap, AddressOf Packet_RequestNewMap)
        Packets.Add(ClientPackets.CMapData, AddressOf Packet_MapData)
        Packets.Add(ClientPackets.CNeedMap, AddressOf Packet_NeedMap)
        Packets.Add(ClientPackets.CMapGetItem, AddressOf Packet_GetItem)
        Packets.Add(ClientPackets.CMapDropItem, AddressOf Packet_DropItem)
        Packets.Add(ClientPackets.CMapRespawn, AddressOf Packet_RespawnMap)
        Packets.Add(ClientPackets.CMapReport, AddressOf Packet_MapReport) 'Mapreport
        Packets.Add(ClientPackets.CKickPlayer, AddressOf Packet_KickPlayer)
        Packets.Add(ClientPackets.CBanList, AddressOf Packet_Banlist)
        Packets.Add(ClientPackets.CBanDestroy, AddressOf Packet_DestroyBans)
        Packets.Add(ClientPackets.CBanPlayer, AddressOf Packet_BanPlayer)
        Packets.Add(ClientPackets.CRequestEditMap, AddressOf Packet_EditMapRequest)
        Packets.Add(ClientPackets.CRequestEditItem, AddressOf Packet_EditItem)
        Packets.Add(ClientPackets.CSaveItem, AddressOf Packet_SaveItem)
        Packets.Add(ClientPackets.CRequestEditNpc, AddressOf Packet_EditNpc)
        Packets.Add(ClientPackets.CSaveNpc, AddressOf Packet_SaveNPC)
        Packets.Add(ClientPackets.CRequestEditShop, AddressOf Packet_EditShop)
        Packets.Add(ClientPackets.CSaveShop, AddressOf Packet_SaveShop)
        Packets.Add(ClientPackets.CRequestEditSkill, AddressOf Packet_EditSkill)
        Packets.Add(ClientPackets.CSaveSkill, AddressOf Packet_SaveSkill)
        Packets.Add(ClientPackets.CSetAccess, AddressOf Packet_SetAccess)
        Packets.Add(ClientPackets.CWhosOnline, AddressOf Packet_WhosOnline)
        Packets.Add(ClientPackets.CSetMotd, AddressOf Packet_SetMotd)
        Packets.Add(ClientPackets.CSearch, AddressOf Packet_PlayerSearch)
        Packets.Add(ClientPackets.CParty, AddressOf Packet_Party)
        Packets.Add(ClientPackets.CJoinParty, AddressOf Packet_JoinParty)
        Packets.Add(ClientPackets.CLeaveParty, AddressOf Packet_LeaveParty)
        Packets.Add(ClientPackets.CSkills, AddressOf Packet_Skills)
        Packets.Add(ClientPackets.CCast, AddressOf Packet_Cast)
        Packets.Add(ClientPackets.CQuit, AddressOf Packet_QuitGame)
        Packets.Add(ClientPackets.CSwapInvSlots, AddressOf Packet_SwapInvSlots)
        Packets.Add(ClientPackets.CRequestEditResource, AddressOf Packet_EditResource)
        Packets.Add(ClientPackets.CSaveResource, AddressOf Packet_SaveResource)
        Packets.Add(ClientPackets.CCheckPing, AddressOf Packet_CheckPing)
        Packets.Add(ClientPackets.CUnequip, AddressOf Packet_Unequip)
        Packets.Add(ClientPackets.CRequestPlayerData, AddressOf Packet_RequestPlayerData)
        Packets.Add(ClientPackets.CRequestItems, AddressOf Packet_RequestItems)
        Packets.Add(ClientPackets.CRequestNPCS, AddressOf Packet_RequestNpcs)
        Packets.Add(ClientPackets.CRequestResources, AddressOf Packet_RequestResources)
        Packets.Add(ClientPackets.CSpawnItem, AddressOf Packet_SpawnItem)
        Packets.Add(ClientPackets.CTrainStat, AddressOf Packet_TrainStat)
        Packets.Add(ClientPackets.CRequestEditAnimation, AddressOf Packet_EditAnimation)
        Packets.Add(ClientPackets.CSaveAnimation, AddressOf Packet_SaveAnimation)
        Packets.Add(ClientPackets.CRequestAnimations, AddressOf Packet_RequestAnimations)
        Packets.Add(ClientPackets.CRequestSkills, AddressOf Packet_RequestSkills)
        Packets.Add(ClientPackets.CRequestShops, AddressOf Packet_RequestShops)
        Packets.Add(ClientPackets.CRequestLevelUp, AddressOf Packet_RequestLevelUp)
        Packets.Add(ClientPackets.CForgetSkill, AddressOf Packet_ForgetSkill)
        Packets.Add(ClientPackets.CCloseShop, AddressOf Packet_CloseShop)
        Packets.Add(ClientPackets.CBuyItem, AddressOf Packet_BuyItem)
        Packets.Add(ClientPackets.CSellItem, AddressOf Packet_SellItem)
        Packets.Add(ClientPackets.CChangeBankSlots, AddressOf Packet_ChangeBankSlots)
        Packets.Add(ClientPackets.CDepositItem, AddressOf Packet_DepositItem)
        Packets.Add(ClientPackets.CWithdrawItem, AddressOf Packet_WithdrawItem)
        Packets.Add(ClientPackets.CCloseBank, AddressOf Packet_CloseBank)
        Packets.Add(ClientPackets.CAdminWarp, AddressOf Packet_AdminWarp)

        Packets.Add(ClientPackets.CTradeInvite, AddressOf Packet_TradeInvite)
        Packets.Add(ClientPackets.CTradeInviteAccept, AddressOf Packet_TradeInviteAccept)
        Packets.Add(ClientPackets.CAcceptTrade, AddressOf Packet_AcceptTrade)
        Packets.Add(ClientPackets.CDeclineTrade, AddressOf Packet_DeclineTrade)
        Packets.Add(ClientPackets.CTradeItem, AddressOf Packet_TradeItem)
        Packets.Add(ClientPackets.CUntradeItem, AddressOf Packet_UntradeItem)

        Packets.Add(ClientPackets.CAdmin, AddressOf Packet_Admin)

        'quests
        Packets.Add(ClientPackets.CRequestEditQuest, AddressOf Packet_RequestEditQuest)
        Packets.Add(ClientPackets.CSaveQuest, AddressOf Packet_SaveQuest)
        Packets.Add(ClientPackets.CRequestQuests, AddressOf Packet_RequestQuests)
        Packets.Add(ClientPackets.CQuestLogUpdate, AddressOf Packet_QuestLogUpdate)
        Packets.Add(ClientPackets.CPlayerHandleQuest, AddressOf Packet_PlayerHandleQuest)
        Packets.Add(ClientPackets.CQuestReset, AddressOf Packet_QuestReset)

        'Housing
        Packets.Add(ClientPackets.CBuyHouse, AddressOf Packet_BuyHouse)
        Packets.Add(ClientPackets.CVisit, AddressOf Packet_InviteToHouse)
        Packets.Add(ClientPackets.CAcceptVisit, AddressOf Packet_AcceptInvite)
        Packets.Add(ClientPackets.CPlaceFurniture, AddressOf Packet_PlaceFurniture)
        Packets.Add(ClientPackets.CRequestEditHouse, AddressOf Packet_RequestEditHouse)
        Packets.Add(ClientPackets.CSaveHouses, AddressOf Packet_SaveHouses)
        Packets.Add(ClientPackets.CSellHouse, AddressOf Packet_SellHouse)

        'hotbar
        Packets.Add(ClientPackets.CSetHotbarSkill, AddressOf Packet_SetHotBarSkill)
        Packets.Add(ClientPackets.CDeleteHotbarSkill, AddressOf Packet_DeleteHotBarSkill)

        'Events
        Packets.Add(ClientPackets.CEventChatReply, AddressOf Packet_EventChatReply)
        Packets.Add(ClientPackets.CEvent, AddressOf Packet_Event)
        Packets.Add(ClientPackets.CRequestSwitchesAndVariables, AddressOf Packet_RequestSwitchesAndVariables)
        Packets.Add(ClientPackets.CSwitchesAndVariables, AddressOf Packet_SwitchesAndVariables)
        Packets.Add(ClientPackets.CEventTouch, AddressOf Packet_EventTouch)

        'projectiles
        Packets.Add(ClientPackets.CRequestEditProjectiles, AddressOf HandleRequestEditProjectiles)
        Packets.Add(ClientPackets.CSaveProjectile, AddressOf HandleSaveProjectile)
        Packets.Add(ClientPackets.CRequestProjectiles, AddressOf HandleRequestProjectiles)
        Packets.Add(ClientPackets.CClearProjectile, AddressOf HandleClearProjectile)

        'craft
        Packets.Add(ClientPackets.CRequestRecipes, AddressOf Packet_RequestRecipes)
        Packets.Add(ClientPackets.CRequestEditRecipes, AddressOf Packet_RequestEditRecipes)
        Packets.Add(ClientPackets.CSaveRecipe, AddressOf Packet_SaveRecipe)
        Packets.Add(ClientPackets.CCloseCraft, AddressOf Packet_CloseCraft)
        Packets.Add(ClientPackets.CStartCraft, AddressOf Packet_StartCraft)

        Packets.Add(ClientPackets.CRequestClasses, AddressOf Packet_RequestClasses)
        Packets.Add(ClientPackets.CRequestEditClasses, AddressOf Packet_RequestEditClasses)
        Packets.Add(ClientPackets.CSaveClasses, AddressOf Packet_SaveClasses)
    End Sub

    Public Sub HandleDataPackets(ByVal index As Long, ByVal data() As Byte)
        Dim packetnum As Long, buffer As ByteBuffer, Packet As Packet_
        Packet = Nothing
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        packetnum = buffer.ReadLong
        buffer = Nothing
        If packetnum = 0 Then Exit Sub
        If packetnum <> ClientPackets.CCheckPing Then TempPlayer(index).DataPackets = TempPlayer(index).DataPackets + 1

        If Packets.TryGetValue(packetnum, Packet) Then
            Packet.Invoke(index, data)
        End If
    End Sub

    Private Sub Packet_NewAccount(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim username As String
        Dim password As String
        Dim i As Long
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        'Make Sure that it is correct
        If buffer.ReadLong <> ClientPackets.CNewAccount Then Exit Sub

        If Not IsPlaying(index) Then
            If Not IsLoggedIn(index) Then
                'Get the Data
                username = buffer.ReadString
                password = buffer.ReadString
                ' Prevent hacking
                If Len(Trim$(username)) < 3 Or Len(Trim$(password)) < 3 Then
                    AlertMsg(index, "Your username and password must be at least three characters in length")
                    Exit Sub
                End If

                ' Prevent hacking
                For i = 1 To Len(username)
                    n = AscW(Mid$(username, i, 1))

                    If Not isNameLegal(n) Then
                        AlertMsg(index, "Invalid username, only letters, numbers, spaces, and _ allowed in usernames.")
                        Exit Sub
                    End If

                Next

                ' Check to see if account already exists
                If Not AccountExist(username) Then
                    AddAccount(index, username, password)

                    TextAdd("Account " & username & " has been created.")
                    Addlog("Account " & username & " has been created.", PLAYER_LOG)

                    ' Load the player
                    LoadPlayer(index, username)

                    ' Check if character data has been created
                    If Len(Trim$(Player(index).Character(TempPlayer(index).CurChar).Name)) > 0 Then
                        ' we have a char!
                        HandleUseChar(index)
                    Else
                        ' send new char shit
                        If Not IsPlaying(index) Then
                            SendNewCharClasses(index)
                        End If
                    End If

                    ' Show the player up on the socket status
                    Addlog(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".", PLAYER_LOG)
                    TextAdd(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".")
                Else
                    AlertMsg(index, "Sorry, that account username is already taken!")
                End If

                buffer = Nothing
            End If
        End If
    End Sub

    Private Sub Packet_Login(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String
        Dim Password As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CLogin Then Exit Sub

        If Not IsPlaying(index) Then
            If Not IsLoggedIn(index) Then

                ' Get the data
                Name = Buffer.ReadString
                Password = Buffer.ReadString

                ' Check versions
                If Buffer.ReadString <> Application.ProductVersion Then
                    AlertMsg(index, "Version outdated, please visit " & Options.Website)
                    Exit Sub
                End If

                If isShuttingDown Then
                    AlertMsg(index, "Server is either rebooting or being shutdown.")
                    Exit Sub
                End If

                If Len(Trim$(Name)) < 3 Or Len(Trim$(Password)) < 3 Then
                    AlertMsg(index, "Your name and password must be at least three characters in length")
                    Exit Sub
                End If

                If Not AccountExist(Name) Then
                    AlertMsg(index, "That account name does not exist.")
                    Exit Sub
                End If

                If Not PasswordOK(Name, Password) Then
                    AlertMsg(index, "Incorrect password.")
                    Exit Sub
                End If

                If IsMultiAccounts(Name) Then
                    AlertMsg(index, "Multiple account logins is not authorized.")
                    Exit Sub
                End If

                ' Load the player
                LoadPlayer(index, Name)
                ClearBank(index)
                LoadBank(index, Name)

                Buffer = Nothing
                Buffer = New ByteBuffer
                Buffer.WriteLong(ServerPackets.SSelChar)
                Buffer.WriteLong(MAX_CHARS)

                For i = 1 To MAX_CHARS
                    If Player(index).Character(i).Classes <= 0 Then
                        Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                        Buffer.WriteLong(Player(index).Character(i).Sprite)
                        Buffer.WriteLong(Player(index).Character(i).Level)
                        Buffer.WriteString("")
                        Buffer.WriteLong(0)
                    Else
                        Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                        Buffer.WriteLong(Player(index).Character(i).Sprite)
                        Buffer.WriteLong(Player(index).Character(i).Level)
                        Buffer.WriteString(Trim$(Classes(Player(index).Character(i).Classes).Name))
                        Buffer.WriteLong(Player(index).Character(i).Sex)
                    End If

                Next

                SendDataTo(index, Buffer.ToArray)

                '' Check if character data has been created
                'If Len(Trim$(Player(index).Character(TempPlayer(index).CurChar).Name)) > 0 Then
                '    ' we have a char!
                '    HandleUseChar(index)
                'Else
                '    ' send new char shit
                If Not IsPlaying(index) Then
                    Call SendNewCharClasses(index)
                End If
                'End If

                ' Show the player up on the socket status
                Call Addlog(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".", PLAYER_LOG)
                TextAdd(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".")

                Buffer = Nothing
            End If
        End If
        NeedToUpDatePlayerList = True
    End Sub

    Private Sub Packet_SayMessage(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim msg As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CSayMsg Then Exit Sub
        msg = Buffer.ReadString

        Call Addlog("Map #" & GetPlayerMap(index) & ": " & GetPlayerName(index) & " says, '" & msg & "'", PLAYER_LOG)

        Call SayMsg_Map(GetPlayerMap(index), index, msg, QBColor(White))

        Buffer = Nothing
    End Sub

    Private Sub Packet_EmoteMsg(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim msg As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CEmoteMsg Then Exit Sub
        msg = Buffer.ReadString

        Call Addlog("Map #" & GetPlayerMap(index) & ": " & GetPlayerName(index) & " " & msg, PLAYER_LOG)
        Call MapMsg(GetPlayerMap(index), GetPlayerName(index) & " " & Right$(msg, Len(msg) - 1), EmoteColor)

        Buffer = Nothing
    End Sub

    Private Sub Packet_BroadCastMsg(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim msg As String
        Dim s As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CBroadcastMsg Then Exit Sub
        msg = Buffer.ReadString

        s = "[Global]" & GetPlayerName(index) & ": " & msg
        Call SayMsg_Global(index, msg, QBColor(White))
        Call Addlog(s, PLAYER_LOG)
        Call TextAdd(s)
        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerMove(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Dir As Long
        Dim movement As Long
        Dim tmpX As Long, tmpY As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CPlayerMove Then Exit Sub

        If TempPlayer(index).GettingMap = YES Then Exit Sub

        Dir = Buffer.ReadLong
        movement = Buffer.ReadLong
        tmpX = Buffer.ReadLong
        tmpY = Buffer.ReadLong
        Buffer = Nothing

        ' Prevent hacking
        If Dir < DIR_UP Or Dir > DIR_RIGHT Then Exit Sub

        ' Prevent hacking
        If movement < 1 Or movement > 2 Then Exit Sub

        ' Prevent player from moving if they have casted a skill
        If TempPlayer(index).SkillBuffer > 0 Then
            SendPlayerXY(index)
            Exit Sub
        End If

        'Cant move if in the bank!
        If TempPlayer(index).InBank Then
            SendPlayerXY(index)
            Exit Sub
        End If

        ' if stunned, stop them moving
        If TempPlayer(index).StunDuration > 0 Then
            SendPlayerXY(index)
            Exit Sub
        End If

        ' Prever player from moving if in shop
        If TempPlayer(index).InShop > 0 Then
            SendPlayerXY(index)
            Exit Sub
        End If

        ' Desynced
        If GetPlayerX(index) <> tmpX Then
            SendPlayerXY(index)
            Exit Sub
        End If

        If GetPlayerY(index) <> tmpY Then
            SendPlayerXY(index)
            Exit Sub
        End If

        PlayerMove(index, Dir, movement, False)

        Buffer = Nothing
    End Sub

    Sub Packet_PlayerDirection(ByVal Index As Long, ByVal Data() As Byte)
        Dim dir As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CPlayerDir Then Exit Sub
        If TempPlayer(Index).GettingMap = YES Then Exit Sub

        dir = Buffer.ReadLong
        Buffer = Nothing

        ' Prevent hacking
        If dir < DIR_UP Or dir > DIR_RIGHT Then
            Exit Sub
        End If

        Call SetPlayerDir(Index, dir)
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SPlayerDir)
        Buffer.WriteLong(Index)
        Buffer.WriteLong(GetPlayerDir(Index))
        SendDataToMapBut(Index, GetPlayerMap(Index), Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub Packet_UseItem(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim invnum As Long, i As Long, n As Long, x As Long, y As Long, tempitem As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CUseItem Then Exit Sub

        invnum = Buffer.ReadLong
        Buffer = Nothing

        ' Prevent hacking
        If invnum < 1 Or invnum > MAX_ITEMS Then
            Exit Sub
        End If

        If (GetPlayerInvItemNum(Index, invnum) > 0) And (GetPlayerInvItemNum(Index, invnum) <= MAX_ITEMS) Then
            n = Item(GetPlayerInvItemNum(Index, invnum)).Data2

            ' Find out what kind of item it is
            Select Case Item(GetPlayerInvItemNum(Index, invnum)).Type
                Case ITEM_TYPE_ARMOR

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.")
                        Exit Sub
                    End If

                    If GetPlayerEquipment(Index, Equipment.Armor) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Armor)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Armor)
                    PlayerMsg(Index, "You equip " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 0)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    SendWornEquipment(Index)
                    SendMapEquipment(Index)
                Case ITEM_TYPE_WEAPON

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.")
                        Exit Sub
                    End If

                    If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Weapon)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Weapon)
                    PlayerMsg(Index, "You equip " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 1)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    SendWornEquipment(Index)
                    SendMapEquipment(Index)
                Case ITEM_TYPE_HELMET

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.")
                        Exit Sub
                    End If

                    If GetPlayerEquipment(Index, Equipment.Helmet) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Helmet)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Helmet)
                    PlayerMsg(Index, "You equip " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 1)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    SendWornEquipment(Index)
                    SendMapEquipment(Index)
                Case ITEM_TYPE_SHIELD

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.")
                        Exit Sub
                    End If

                    If GetPlayerEquipment(Index, Equipment.Shield) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Shield)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Shield)
                    PlayerMsg(Index, "You equip " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 1)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    SendWornEquipment(Index)
                    SendMapEquipment(Index)

                Case ITEM_TYPE_SHOES

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.")
                        Exit Sub
                    End If

                    If GetPlayerEquipment(Index, Equipment.Shoes) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Shoes)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Shoes)
                    PlayerMsg(Index, "You equip " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 1)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    SendWornEquipment(Index)
                    SendMapEquipment(Index)

                Case ITEM_TYPE_GLOVES

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to equip this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to equip this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to equip this item.")
                        Exit Sub
                    End If

                    If GetPlayerEquipment(Index, Equipment.Gloves) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Gloves)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Gloves)
                    PlayerMsg(Index, "You equip " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 1)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    SendWornEquipment(Index)
                    SendMapEquipment(Index)
                Case ITEM_TYPE_POTIONADDHP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    SendActionMsg(GetPlayerMap(Index), "+" & Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1, BrightGreen, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    SetPlayerVital(Index, Vitals.HP, GetPlayerVital(Index, Vitals.HP) + Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1)
                    TakeInvItem(Index, Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num, 0)
                    SendVital(Index, Vitals.HP)
                Case ITEM_TYPE_POTIONADDMP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    SendActionMsg(GetPlayerMap(Index), "+" & Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1, BrightBlue, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    SetPlayerVital(Index, Vitals.MP, GetPlayerVital(Index, Vitals.MP) + Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1)
                    TakeInvItem(Index, Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num, 0)
                    SendVital(Index, Vitals.MP)
                Case ITEM_TYPE_POTIONADDSP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    SetPlayerVital(Index, Vitals.SP, GetPlayerVital(Index, Vitals.SP) + Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1)
                    TakeInvItem(Index, Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num, 0)
                    SendVital(Index, Vitals.SP)
                Case ITEM_TYPE_POTIONSUBHP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    SendActionMsg(GetPlayerMap(Index), "-" & Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1, BrightRed, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    SetPlayerVital(Index, Vitals.HP, GetPlayerVital(Index, Vitals.HP) - Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1)
                    TakeInvItem(Index, Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num, 0)
                    SendVital(Index, Vitals.HP)
                Case ITEM_TYPE_POTIONSUBMP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    SendActionMsg(GetPlayerMap(Index), "-" & Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1, Blue, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    SetPlayerVital(Index, Vitals.MP, GetPlayerVital(Index, Vitals.MP) - Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1)
                    TakeInvItem(Index, Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num, 0)
                    SendVital(Index, Vitals.MP)
                Case ITEM_TYPE_POTIONSUBSP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    SetPlayerVital(Index, Vitals.SP, GetPlayerVital(Index, Vitals.SP) - Item(Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num).Data1)
                    TakeInvItem(Index, Player(Index).Character(TempPlayer(Index).CurChar).Inv(invnum).Num, 0)
                    SendVital(Index, Vitals.SP)
                Case ITEM_TYPE_KEY
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Make sure they are the right level
                    i = Item(GetPlayerInvItemNum(Index, invnum)).LevelReq

                    If i > GetPlayerLevel(Index) Then
                        PlayerMsg(Index, "You do not meet the level requirements to use this item.")
                        Exit Sub
                    End If

                    ' Make sure they are the right class
                    If Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = GetPlayerClass(Index) And Not Item(GetPlayerInvItemNum(Index, invnum)).ClassReq = 0 Then
                        PlayerMsg(Index, "You do not meet the class requirements to use this item.")
                        Exit Sub
                    End If

                    Select Case GetPlayerDir(Index)
                        Case DIR_UP

                            If GetPlayerY(Index) > 0 Then
                                x = GetPlayerX(Index)
                                y = GetPlayerY(Index) - 1
                            Else
                                Exit Sub
                            End If

                        Case DIR_DOWN

                            If GetPlayerY(Index) < Map(GetPlayerMap(Index)).MaxY Then
                                x = GetPlayerX(Index)
                                y = GetPlayerY(Index) + 1
                            Else
                                Exit Sub
                            End If

                        Case DIR_LEFT

                            If GetPlayerX(Index) > 0 Then
                                x = GetPlayerX(Index) - 1
                                y = GetPlayerY(Index)
                            Else
                                Exit Sub
                            End If

                        Case DIR_RIGHT

                            If GetPlayerX(Index) < Map(GetPlayerMap(Index)).MaxX Then
                                x = GetPlayerX(Index) + 1
                                y = GetPlayerY(Index)
                            Else
                                Exit Sub
                            End If

                    End Select

                    ' Check if a key exists
                    If Map(GetPlayerMap(Index)).Tile(x, y).Type = TILE_TYPE_KEY Then

                        ' Check if the key they are using matches the map key
                        If GetPlayerInvItemNum(Index, invnum) = Map(GetPlayerMap(Index)).Tile(x, y).Data1 Then
                            TempTile(GetPlayerMap(Index)).DoorOpen(x, y) = YES
                            TempTile(GetPlayerMap(Index)).DoorTimer = GetTickCount()
                            SendMapKey(Index, x, y, 1)
                            MapMsg(GetPlayerMap(Index), "A door has been unlocked.", White)

                            SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, x, y)

                            ' Check if we are supposed to take away the item
                            If Map(GetPlayerMap(Index)).Tile(x, y).Data2 = 1 Then
                                TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 0)
                                PlayerMsg(Index, "The key is destroyed in the lock.")
                            End If
                        End If
                    End If

                Case ITEM_TYPE_SKILL

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "You do not meet the stat requirements to use this item.")
                            Exit Sub
                        End If
                    Next

                    ' Get the skill num
                    n = Item(GetPlayerInvItemNum(Index, invnum)).Data1

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
                                        SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                                        TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 0)
                                        PlayerMsg(Index, "You study the skill carefully.")
                                        PlayerMsg(Index, "You have learned a new skill!")
                                    Else
                                        PlayerMsg(Index, "You have already learned this skill!")
                                    End If

                                Else
                                    PlayerMsg(Index, "You have learned all that you can learn!")
                                End If

                            Else
                                PlayerMsg(Index, "You must be level " & i & " to learn this skill.")
                            End If

                        Else
                            PlayerMsg(Index, "This skill can only be learned by " & CheckGrammar(GetClassName(Skill(n).ClassReq)) & ".")
                        End If

                    Else
                        PlayerMsg(Index, "This scroll is not connected to a skill, please inform an admin!")
                    End If
                Case ITEM_TYPE_FURNITURE
                    PlayerMsg(Index, "To place furniture, simply click on it in your inventory, then click in your house where you want it.")
                Case ITEM_TYPE_RECIPES
                    PlayerMsg(Index, "Lets learn this recipe :)")
                    ' Get the recipe num
                    n = Item(GetPlayerInvItemNum(Index, invnum)).Data1
                    LearnRecipe(Index, n, invnum)
            End Select

        End If
    End Sub

    Sub Packet_Attack(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Dim n As Long
        Dim Damage As Long
        Dim TempIndex As Long
        Dim x As Long, y As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CAttack Then Exit Sub

        ' can't attack whilst casting
        If TempPlayer(Index).SkillBuffer > 0 Then Exit Sub

        ' can't attack whilst stunned
        If TempPlayer(Index).StunDuration > 0 Then Exit Sub

        'projectiles
        ' Projectile check
        If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
            If Item(GetPlayerEquipment(Index, Equipment.Weapon)).Data1 > 0 Then 'Item has a projectile
                Call PlayerFireProjectile(Index)
                Exit Sub
            End If
        End If

        ' Try to attack a player
        For i = 1 To MAX_PLAYERS
            TempIndex = i

            ' Make sure we dont try to attack ourselves
            If TempIndex <> Index Then

                ' Can we attack the player?
                If CanAttackPlayer(Index, TempIndex) Then
                    If Not CanPlayerBlockHit(TempIndex) Then

                        ' Get the damage we can do
                        If Not CanPlayerCriticalHit(Index) Then
                            Damage = GetPlayerDamage(Index) - GetPlayerProtection(TempIndex)
                        Else
                            n = GetPlayerDamage(Index)
                            Damage = n + Int(Rnd() * (n \ 2)) + 1 - GetPlayerProtection(TempIndex)
                            PlayerMsg(Index, "You feel a surge of energy upon swinging!")
                            PlayerMsg(TempIndex, GetPlayerName(Index) & " swings with enormous might!")
                            SendActionMsg(GetPlayerMap(Index), "CRITICAL HIT!", BrightCyan, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                            SendCritical(Index)
                        End If

                        AttackPlayer(Index, TempIndex, Damage)
                    Else
                        PlayerMsg(Index, GetPlayerName(TempIndex) & "'s " & Trim$(Item(GetPlayerEquipment(TempIndex, Equipment.Shield)).Name) & " has blocked your hit!")
                        PlayerMsg(TempIndex, "Your " & Trim$(Item(GetPlayerEquipment(TempIndex, Equipment.Shield)).Name) & " has blocked " & GetPlayerName(Index) & "'s hit!")
                        SendActionMsg(GetPlayerMap(TempIndex), "BLOCK!", Pink, 1, (GetPlayerX(TempIndex) * 32), (GetPlayerY(TempIndex) * 32))
                    End If

                    Exit Sub
                End If
            End If
        Next

        ' Try to attack a npc
        For i = 1 To MAX_MAP_NPCS

            ' Can we attack the npc?
            If CanAttackNpc(Index, i) Then

                ' Get the damage we can do
                If Not CanPlayerCriticalHit(Index) Then
                    Damage = GetPlayerDamage(Index) - (Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Stat(Stats.endurance) \ 2)
                    'KnockBackNpc(Index, i)
                Else
                    n = GetPlayerDamage(Index)
                    Damage = n + Int(Rnd() * (n \ 2)) + 1 - (Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Stat(Stats.endurance) \ 2)
                    PlayerMsg(Index, "You feel a surge of energy upon swinging!")
                    SendActionMsg(GetPlayerMap(Index), "CRITICAL HIT!", BrightCyan, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                    SendCritical(Index)
                    KnockBackNpc(Index, i)
                End If

                If Damage > 0 Then
                    AttackNpc(Index, i, Damage)
                Else
                    PlayerMsg(Index, "Your attack does nothing.")
                End If

                Exit Sub
            End If

        Next

        ' Check tradeskills
        Select Case GetPlayerDir(Index)
            Case DIR_UP

                If GetPlayerY(Index) = 0 Then Exit Sub
                x = GetPlayerX(Index)
                y = GetPlayerY(Index) - 1
            Case DIR_DOWN

                If GetPlayerY(Index) = Map(GetPlayerMap(Index)).MaxY Then Exit Sub
                x = GetPlayerX(Index)
                y = GetPlayerY(Index) + 1
            Case DIR_LEFT

                If GetPlayerX(Index) = 0 Then Exit Sub
                x = GetPlayerX(Index) - 1
                y = GetPlayerY(Index)
            Case DIR_RIGHT

                If GetPlayerX(Index) = Map(GetPlayerMap(Index)).MaxX Then Exit Sub
                x = GetPlayerX(Index) + 1
                y = GetPlayerY(Index)
        End Select

        CheckResource(Index, x, y)

        Buffer = Nothing
    End Sub

    Sub Packet_PlayerInfo(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long, n As Long
        Dim name As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CPlayerInfoRequest Then Exit Sub
        name = Buffer.ReadString
        i = FindPlayer(name)

        If i > 0 Then
            PlayerMsg(Index, "Account: " & Trim$(Player(i).Login) & ", Name: " & GetPlayerName(i))

            If GetPlayerAccess(Index) > ADMIN_MONITOR Then
                PlayerMsg(Index, "-=- Stats for " & GetPlayerName(i) & " -=-")
                PlayerMsg(Index, "Level: " & GetPlayerLevel(i) & "  Exp: " & GetPlayerExp(i) & "/" & GetPlayerNextLevel(i))
                PlayerMsg(Index, "HP: " & GetPlayerVital(i, Vitals.HP) & "/" & GetPlayerMaxVital(i, Vitals.HP) & "  MP: " & GetPlayerVital(i, Vitals.MP) & "/" & GetPlayerMaxVital(i, Vitals.MP) & "  SP: " & GetPlayerVital(i, Vitals.SP) & "/" & GetPlayerMaxVital(i, Vitals.SP))
                PlayerMsg(Index, "Strength: " & GetPlayerStat(i, Stats.strength) & "  Defense: " & GetPlayerStat(i, Stats.endurance) & "  Magic: " & GetPlayerStat(i, Stats.intelligence) & "  Speed: " & GetPlayerStat(i, Stats.spirit))
                n = (GetPlayerStat(i, Stats.strength) \ 2) + (GetPlayerLevel(i) \ 2)
                i = (GetPlayerStat(i, Stats.endurance) \ 2) + (GetPlayerLevel(i) \ 2)

                If n > 100 Then n = 100
                If i > 100 Then i = 100
                PlayerMsg(Index, "Critical Hit Chance: " & n & "%, Block Chance: " & i & "%")
            End If

        Else
            PlayerMsg(Index, "Player is not online.")
        End If

        Buffer = Nothing
    End Sub

    Sub Packet_WarpMeTo(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CWarpMeTo Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        ' The player
        n = FindPlayer(Buffer.ReadString) 'Parse(1))
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                PlayerWarp(Index, GetPlayerMap(n), GetPlayerX(n), GetPlayerY(n))
                PlayerMsg(n, GetPlayerName(Index) & " has warped to you.")
                PlayerMsg(Index, "You have been warped to " & GetPlayerName(n) & ".")
                Addlog(GetPlayerName(Index) & " has warped to " & GetPlayerName(n) & ", map #" & GetPlayerMap(n) & ".", ADMIN_LOG)
            Else
                PlayerMsg(Index, "Player is not online.")
            End If

        Else
            PlayerMsg(Index, "You cannot warp to yourself, dumbass!")
        End If

    End Sub

    ' :::::::::::::::::::::::
    ' :: Warp to me packet ::
    ' :::::::::::::::::::::::
    Sub Packet_WarpToMe(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CWarpToMe Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then Exit Sub

        ' The player
        n = FindPlayer(Buffer.ReadString)
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                PlayerWarp(n, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
                PlayerMsg(n, "You have been summoned by " & GetPlayerName(Index) & ".")
                PlayerMsg(Index, GetPlayerName(n) & " has been summoned.")
                Addlog(GetPlayerName(Index) & " has warped " & GetPlayerName(n) & " to self, map #" & GetPlayerMap(Index) & ".", ADMIN_LOG)
            Else
                PlayerMsg(Index, "Player is not online.")
            End If

        Else
            PlayerMsg(Index, "You cannot warp yourself to yourself!")
        End If

    End Sub

    Sub Packet_WarpTo(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CWarpTo Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then Exit Sub

        ' The map
        n = Buffer.ReadLong
        Buffer = Nothing

        ' Prevent hacking
        If n < 0 Or n > MAX_MAPS Then Exit Sub

        PlayerWarp(Index, n, GetPlayerX(Index), GetPlayerY(Index))
        PlayerMsg(Index, "You have been warped to map #" & n)
        Addlog(GetPlayerName(Index) & " warped to map #" & n & ".", ADMIN_LOG)

    End Sub

    Sub Packet_SetSprite(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CSetSprite Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        ' The sprite
        n = Buffer.ReadLong 'CLng(Parse(1))
        Buffer = Nothing
        Call SetPlayerSprite(Index, n)
        Call SendPlayerData(Index)
        Exit Sub
    End Sub

    Sub Packet_GetStats(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CGetStats Then Exit Sub

        PlayerMsg(Index, "-=- Stats for " & GetPlayerName(Index) & " -=-")
        PlayerMsg(Index, "Level: " & GetPlayerLevel(Index) & "  Exp: " & GetPlayerExp(Index) & "/" & GetPlayerNextLevel(Index))
        PlayerMsg(Index, "HP: " & GetPlayerVital(Index, Vitals.HP) & "/" & GetPlayerMaxVital(Index, Vitals.HP) & "  MP: " & GetPlayerVital(Index, Vitals.MP) & "/" & GetPlayerMaxVital(Index, Vitals.MP) & "  SP: " & GetPlayerVital(Index, Vitals.SP) & "/" & GetPlayerMaxVital(Index, Vitals.SP))
        PlayerMsg(Index, "STR: " & GetPlayerStat(Index, Stats.strength) & "  DEF: " & GetPlayerStat(Index, Stats.endurance) & "  MAGI: " & GetPlayerStat(Index, Stats.intelligence) & "  Speed: " & GetPlayerStat(Index, Stats.spirit))
        n = (GetPlayerStat(Index, Stats.strength) \ 2) + (GetPlayerLevel(Index) \ 2)
        i = (GetPlayerStat(Index, Stats.endurance) \ 2) + (GetPlayerLevel(Index) \ 2)

        If n > 100 Then n = 100
        If i > 100 Then i = 100
        PlayerMsg(Index, "Critical Hit Chance: " & n & "%, Block Chance: " & i & "%")
        Buffer = Nothing
    End Sub

    Sub Packet_RequestNewMap(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim dir As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CRequestNewMap Then Exit Sub
        dir = Buffer.ReadLong
        Buffer = Nothing

        ' Prevent hacking
        If dir < DIR_UP Or dir > DIR_RIGHT Then Exit Sub

        'Debug.Print("Server-RequestNewMap")

        PlayerMove(Index, dir, 1, True)
        Buffer = Nothing
    End Sub

    ' :::::::::::::::::::::
    ' :: Map data packet ::
    ' :::::::::::::::::::::
    Sub Packet_MapData(ByVal Index As Long, ByVal Data() As Byte)
        Dim i As Long
        Dim MapNum As Long
        Dim x As Long
        Dim y As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CMapData Then Exit Sub

        Data = Buffer.ReadBytes(Data.Length - 8)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Decompress(Data))

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then Exit Sub

        Gettingmap = True

        MapNum = GetPlayerMap(Index)
        i = Map(MapNum).Revision + 1
        ClearMap(MapNum)

        Map(MapNum).Name = Buffer.ReadString
        Map(MapNum).Music = Buffer.ReadString
        Map(MapNum).Revision = i
        Map(MapNum).Moral = Buffer.ReadLong
        Map(MapNum).Tileset = Buffer.ReadLong
        Map(MapNum).Up = Buffer.ReadLong
        Map(MapNum).Down = Buffer.ReadLong
        Map(MapNum).Left = Buffer.ReadLong
        Map(MapNum).Right = Buffer.ReadLong
        Map(MapNum).BootMap = Buffer.ReadLong
        Map(MapNum).BootX = Buffer.ReadLong
        Map(MapNum).BootY = Buffer.ReadLong
        Map(MapNum).MaxX = Buffer.ReadLong
        Map(MapNum).MaxY = Buffer.ReadLong
        Map(MapNum).WeatherType = Buffer.ReadLong
        Map(MapNum).FogIndex = Buffer.ReadLong
        Map(MapNum).WeatherIntensity = Buffer.ReadLong
        Map(MapNum).FogAlpha = Buffer.ReadLong
        Map(MapNum).FogSpeed = Buffer.ReadLong
        Map(MapNum).HasMapTint = Buffer.ReadLong
        Map(MapNum).MapTintR = Buffer.ReadLong
        Map(MapNum).MapTintG = Buffer.ReadLong
        Map(MapNum).MapTintB = Buffer.ReadLong
        Map(MapNum).MapTintA = Buffer.ReadLong

        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, MapNum)
            Map(MapNum).Npc(x) = Buffer.ReadLong
        Next

        With Map(MapNum)
            For x = 0 To .MaxX
                For y = 0 To .MaxY
                    .Tile(x, y).Data1 = Buffer.ReadLong
                    .Tile(x, y).Data2 = Buffer.ReadLong
                    .Tile(x, y).Data3 = Buffer.ReadLong
                    .Tile(x, y).DirBlock = Buffer.ReadLong
                    ReDim .Tile(x, y).Layer(0 To MapLayer.Layer_Count - 1)
                    ReDim .Tile(x, y).Autotile(0 To MapLayer.Layer_Count - 1)
                    For i = 0 To MapLayer.Layer_Count - 1
                        .Tile(x, y).Layer(i).Tileset = Buffer.ReadLong
                        .Tile(x, y).Layer(i).x = Buffer.ReadLong
                        .Tile(x, y).Layer(i).y = Buffer.ReadLong
                        .Tile(x, y).Autotile(i) = Buffer.ReadLong
                    Next
                    .Tile(x, y).Type = Buffer.ReadLong
                Next
            Next


        End With

        'Event Data!
        Map(MapNum).EventCount = Buffer.ReadLong

        If Map(MapNum).EventCount > 0 Then
            ReDim Map(MapNum).Events(0 To Map(MapNum).EventCount)
            For i = 1 To Map(MapNum).EventCount
                With Map(MapNum).Events(i)
                    .Name = Buffer.ReadString
                    .Globals = Buffer.ReadLong
                    .X = Buffer.ReadLong
                    .Y = Buffer.ReadLong
                    .PageCount = Buffer.ReadLong
                End With
                If Map(MapNum).Events(i).PageCount > 0 Then
                    ReDim Map(MapNum).Events(i).Pages(0 To Map(MapNum).Events(i).PageCount)
                    ReDim TempPlayer(i).EventMap.EventPages(0 To Map(MapNum).Events(i).PageCount)
                    For x = 1 To Map(MapNum).Events(i).PageCount
                        With Map(MapNum).Events(i).Pages(x)
                            .chkVariable = Buffer.ReadLong
                            .VariableIndex = Buffer.ReadLong
                            .VariableCondition = Buffer.ReadLong
                            .VariableCompare = Buffer.ReadLong

                            Map(MapNum).Events(i).Pages(x).chkSwitch = Buffer.ReadLong
                            Map(MapNum).Events(i).Pages(x).SwitchIndex = Buffer.ReadLong
                            .SwitchCompare = Buffer.ReadLong

                            .chkHasItem = Buffer.ReadLong
                            .HasItemIndex = Buffer.ReadLong
                            .HasItemAmount = Buffer.ReadLong

                            .chkSelfSwitch = Buffer.ReadLong
                            .SelfSwitchIndex = Buffer.ReadLong
                            .SelfSwitchCompare = Buffer.ReadLong

                            .GraphicType = Buffer.ReadLong
                            .Graphic = Buffer.ReadLong
                            .GraphicX = Buffer.ReadLong
                            .GraphicY = Buffer.ReadLong
                            .GraphicX2 = Buffer.ReadLong
                            .GraphicY2 = Buffer.ReadLong

                            .MoveType = Buffer.ReadLong
                            .MoveSpeed = Buffer.ReadLong
                            .MoveFreq = Buffer.ReadLong

                            .MoveRouteCount = Buffer.ReadLong

                            .IgnoreMoveRoute = Buffer.ReadLong
                            .RepeatMoveRoute = Buffer.ReadLong

                            If .MoveRouteCount > 0 Then
                                ReDim Map(MapNum).Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = Buffer.ReadLong
                                    .MoveRoute(y).Data1 = Buffer.ReadLong
                                    .MoveRoute(y).Data2 = Buffer.ReadLong
                                    .MoveRoute(y).Data3 = Buffer.ReadLong
                                    .MoveRoute(y).Data4 = Buffer.ReadLong
                                    .MoveRoute(y).Data5 = Buffer.ReadLong
                                    .MoveRoute(y).Data6 = Buffer.ReadLong
                                Next
                            End If

                            .WalkAnim = Buffer.ReadLong
                            .DirFix = Buffer.ReadLong
                            .WalkThrough = Buffer.ReadLong
                            .ShowName = Buffer.ReadLong
                            .Trigger = Buffer.ReadLong
                            .CommandListCount = Buffer.ReadLong

                            .Position = Buffer.ReadLong
                            .QuestNum = Buffer.ReadLong
                        End With

                        If Map(MapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map(MapNum).Events(i).Pages(x).CommandList(0 To Map(MapNum).Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map(MapNum).Events(i).Pages(x).CommandListCount
                                Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount = Buffer.ReadLong
                                Map(MapNum).Events(i).Pages(x).CommandList(y).ParentList = Buffer.ReadLong
                                If Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(0 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 1 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = Buffer.ReadLong
                                            .Text1 = Buffer.ReadString
                                            .Text2 = Buffer.ReadString
                                            .Text3 = Buffer.ReadString
                                            .Text4 = Buffer.ReadString
                                            .Text5 = Buffer.ReadString
                                            .Data1 = Buffer.ReadLong
                                            .Data2 = Buffer.ReadLong
                                            .Data3 = Buffer.ReadLong
                                            .Data4 = Buffer.ReadLong
                                            .Data5 = Buffer.ReadLong
                                            .Data6 = Buffer.ReadLong
                                            .ConditionalBranch.CommandList = Buffer.ReadLong
                                            .ConditionalBranch.Condition = Buffer.ReadLong
                                            .ConditionalBranch.Data1 = Buffer.ReadLong
                                            .ConditionalBranch.Data2 = Buffer.ReadLong
                                            .ConditionalBranch.Data3 = Buffer.ReadLong
                                            .ConditionalBranch.ElseCommandList = Buffer.ReadLong
                                            .MoveRouteCount = Buffer.ReadLong
                                            Dim tmpcount As Long = .MoveRouteCount
                                            If tmpcount > 0 Then
                                                ReDim Preserve .MoveRoute(tmpcount)
                                                For w = 1 To tmpcount
                                                    .MoveRoute(w).Index = Buffer.ReadLong
                                                    .MoveRoute(w).Data1 = Buffer.ReadLong
                                                    .MoveRoute(w).Data2 = Buffer.ReadLong
                                                    .MoveRoute(w).Data3 = Buffer.ReadLong
                                                    .MoveRoute(w).Data4 = Buffer.ReadLong
                                                    .MoveRoute(w).Data5 = Buffer.ReadLong
                                                    .MoveRoute(w).Data6 = Buffer.ReadLong
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
        'End Event Data

        ' Save the map
        SaveMap(MapNum)

        Gettingmap = False

        SendMapNpcsToMap(MapNum)
        SpawnMapNpcs(MapNum)
        SpawnGlobalEvents(MapNum)

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If Player(i).Character(TempPlayer(i).CurChar).Map = MapNum Then
                    SpawnMapEventsFor(i, MapNum)
                End If
            End If
        Next

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), MapItem(GetPlayerMap(Index), i).x, MapItem(GetPlayerMap(Index), i).y)
            ClearMapItem(i, GetPlayerMap(Index))
        Next

        ' Respawn
        SpawnMapItems(GetPlayerMap(Index))


        ClearTempTile(MapNum)
        CacheResources(MapNum)

        ' Refresh map for everyone online
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = MapNum Then
                PlayerWarp(i, MapNum, GetPlayerX(i), GetPlayerY(i))
                ' Send map
                SendMapData(i, MapNum, True)
            End If
        Next i

        Buffer = Nothing
    End Sub

    Private Sub Packet_AddChar(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String, slot As Byte
        Dim Sex As Long
        Dim Classes As Long
        Dim Sprite As Long
        Dim i As Long
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CAddChar Then Exit Sub

        If Not IsPlaying(index) Then
            slot = Buffer.ReadLong
            Name = Buffer.ReadString
            Sex = Buffer.ReadLong
            Classes = Buffer.ReadLong
            Sprite = Buffer.ReadLong

            ' Prevent hacking
            If Len(Trim$(Name)) < 3 Then
                AlertMsg(index, "Character name must be at least three characters in length.")
                Exit Sub
            End If

            ' Prevent hacking
            For i = 1 To Len(Name)
                n = AscW(Mid$(Name, i, 1))

                If Not isNameLegal(n) Then
                    AlertMsg(index, "Invalid name, only letters, numbers, spaces, and _ allowed in names.")
                    Exit Sub
                End If

            Next

            ' Prevent hacking
            If (Sex < SEX_MALE) Or (Sex > SEX_FEMALE) Then Exit Sub

            ' Prevent hacking
            If Classes < 1 Or Classes > Max_Classes Then Exit Sub

            ' Check if char already exists in slot
            If CharExist(index, slot) Then
                AlertMsg(index, "Character already exists!")
                Exit Sub
            End If

            ' Check if name is already in use
            If FindChar(Name) Then
                AlertMsg(index, "Sorry, but that name is in use!")
                Exit Sub
            End If

            ' Everything went ok, add the character
            TempPlayer(index).CurChar = slot
            AddChar(index, slot, Name, Sex, Classes, Sprite)
            Addlog("Character " & Name & " added to " & GetPlayerLogin(index) & "'s account.", PLAYER_LOG)

            ' log them in!!
            HandleUseChar(index)

            Buffer = Nothing
        End If

        NeedToUpDatePlayerList = True
    End Sub

    Private Sub Packet_UseChar(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim slot As Byte

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CUseChar Then Exit Sub

        If Not IsPlaying(index) Then
            If IsLoggedIn(index) Then

                slot = Buffer.ReadLong

                ' Check if character data has been created
                If Len(Trim$(Player(index).Character(slot).Name)) > 0 Then
                    ' we have a char!
                    TempPlayer(index).CurChar = slot
                    HandleUseChar(index)
                    ClearBank(index)
                    LoadBank(index, Trim$(Player(index).Login))
                Else
                    ' send new char shit
                    If Not IsPlaying(index) Then
                        SendNewCharClasses(index)
                        TempPlayer(index).CurChar = slot
                    End If
                End If
            End If
        End If


        NeedToUpDatePlayerList = True
    End Sub

    Private Sub Packet_DeleteChar(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim slot As Byte

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CDelChar Then Exit Sub

        If Not IsPlaying(index) Then
            If IsLoggedIn(index) Then

                slot = Buffer.ReadLong

                ' Check if character data has been created
                If Len(Trim$(Player(index).Character(slot).Name)) > 0 Then
                    ' we have a char!
                    DeleteName(Trim$(Player(index).Character(slot).Name))
                    ClearCharacter(index, slot)
                    SaveCharacter(index, slot)

                    Buffer = Nothing
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ServerPackets.SSelChar)
                    Buffer.WriteLong(MAX_CHARS)

                    For i = 1 To MAX_CHARS
                        If Player(index).Character(i).Classes <= 0 Then
                            Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                            Buffer.WriteLong(Player(index).Character(i).Sprite)
                            Buffer.WriteLong(Player(index).Character(i).Level)
                            Buffer.WriteString("")
                            Buffer.WriteLong(0)
                        Else
                            Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                            Buffer.WriteLong(Player(index).Character(i).Sprite)
                            Buffer.WriteLong(Player(index).Character(i).Level)
                            Buffer.WriteString(Trim$(Classes(Player(index).Character(i).Classes).Name))
                            Buffer.WriteLong(Player(index).Character(i).Sex)
                        End If

                    Next

                    SendDataTo(index, Buffer.ToArray)
                End If
            End If
        End If

    End Sub

    Private Sub Packet_NeedMap(ByVal index As Long, ByVal data() As Byte)
        Dim s As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CNeedMap Then Exit Sub

        ' Get yes/no value
        s = Buffer.ReadLong
        Buffer = Nothing

        ' Check if map data is needed to be sent
        If s = 1 Then
            SendMapData(index, GetPlayerMap(index), True)
        Else
            SendMapData(index, GetPlayerMap(index), False)
        End If

        SpawnMapEventsFor(index, GetPlayerMap(index))
        SendJoinMap(index)
        TempPlayer(index).GettingMap = NO
    End Sub

    Private Sub Packet_GetItem(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CMapGetItem Then Exit Sub

        PlayerMapGetItem(index)

        Buffer = Nothing
    End Sub

    Private Sub Packet_DropItem(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim InvNum As Long, Amount As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ClientPackets.CMapDropItem Then Exit Sub
        InvNum = Buffer.ReadLong
        Amount = Buffer.ReadLong
        Buffer = Nothing

        If TempPlayer(index).InBank Or TempPlayer(index).InShop Then Exit Sub

        ' Prevent hacking
        If InvNum < 1 Or InvNum > MAX_INV Then Exit Sub
        If GetPlayerInvItemNum(index, InvNum) < 1 Or GetPlayerInvItemNum(index, InvNum) > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(index, InvNum)).Type = ITEM_TYPE_CURRENCY Or Item(GetPlayerInvItemNum(index, InvNum)).Stackable = 1 Then
            If Amount < 1 Or Amount > GetPlayerInvItemValue(index, InvNum) Then Exit Sub
        End If

        ' everything worked out fine
        Call PlayerMapDropItem(index, InvNum, Amount)
    End Sub

    Sub Packet_RespawnMap(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CMapRespawn Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            Call SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), MapItem(GetPlayerMap(Index), i).x, MapItem(GetPlayerMap(Index), i).y)
            Call ClearMapItem(i, GetPlayerMap(Index))
        Next

        ' Respawn
        Call SpawnMapItems(GetPlayerMap(Index))

        ' Respawn NPCS
        For i = 1 To MAX_MAP_NPCS
            Call SpawnNpc(i, GetPlayerMap(Index))
        Next

        CacheResources(GetPlayerMap(Index))
        Call PlayerMsg(Index, "Map respawned.")
        Call Addlog(GetPlayerName(Index) & " has respawned map #" & GetPlayerMap(Index), ADMIN_LOG)

        Buffer = Nothing
    End Sub

    ' ::::::::::::::::::::::::
    ' :: Kick player packet ::
    ' ::::::::::::::::::::::::
    Sub Packet_KickPlayer(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CKickPlayer Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) <= 0 Then
            Exit Sub
        End If

        ' The player index
        n = FindPlayer(Buffer.ReadString) 'Parse(1))
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                If GetPlayerAccess(n) < GetPlayerAccess(Index) Then
                    Call GlobalMsg(GetPlayerName(n) & " has been kicked from " & Options.Game_Name & " by " & GetPlayerName(Index) & "!")
                    Call Addlog(GetPlayerName(Index) & " has kicked " & GetPlayerName(n) & ".", ADMIN_LOG)
                    Call AlertMsg(n, "You have been kicked by " & GetPlayerName(Index) & "!")
                Else
                    Call PlayerMsg(Index, "That is a higher or same access admin then you!")
                End If

            Else
                Call PlayerMsg(Index, "Player is not online.")
            End If

        Else
            Call PlayerMsg(Index, "You cannot kick yourself!")
        End If
    End Sub

    Sub Packet_Banlist(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CBanList Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        PlayerMsg(Index, "Command /banlist is not available in EO.Net... yet ;).")

        Buffer = Nothing
    End Sub

    Sub Packet_DestroyBans(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim filename As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CBanDestroy Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_CREATOR Then
            Exit Sub
        End If

        filename = Application.StartupPath & "\data\banlist.txt"

        If System.IO.File.Exists(filename) Then Kill(filename)
        Call PlayerMsg(Index, "Ban list destroyed.")
        Buffer = Nothing
    End Sub

    ' :::::::::::::::::::::::
    ' :: Ban player packet ::
    ' :::::::::::::::::::::::
    Sub Packet_BanPlayer(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)


        If Buffer.ReadLong <> ClientPackets.CBanPlayer Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        ' The player index
        n = FindPlayer(Buffer.ReadString) 'Parse(1))
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                If GetPlayerAccess(n) < GetPlayerAccess(Index) Then
                    Call BanIndex(n, Index)
                Else
                    Call PlayerMsg(Index, "That is a higher or same access admin then you!")
                End If

            Else
                Call PlayerMsg(Index, "Player is not online.")
            End If

        Else
            Call PlayerMsg(Index, "You cannot ban yourself!")
        End If

    End Sub

    Private Sub Packet_EditMapRequest(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CRequestEditMap Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        SendMapEventData(index)

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SEditMap)
        SendDataTo(index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Private Sub Packet_EditItem(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CRequestEditItem Then Exit Sub
        Buffer = Nothing

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SItemEditor)
        SendDataTo(index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Private Sub Packet_SaveItem(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CSaveItem Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then Exit Sub

        n = Buffer.ReadLong

        If n < 0 Or n > MAX_ITEMS Then
            Exit Sub
        End If

        ' Update the item
        Item(n).AccessReq = Buffer.ReadLong()

        For i = 0 To Stats.Stat_Count - 1
            Item(n).Add_Stat(i) = Buffer.ReadLong()
        Next

        Item(n).Animation = Buffer.ReadLong()
        Item(n).BindType = Buffer.ReadLong()
        Item(n).ClassReq = Buffer.ReadLong()
        Item(n).Data1 = Buffer.ReadLong()
        Item(n).Data2 = Buffer.ReadLong()
        Item(n).Data3 = Buffer.ReadLong()
        Item(n).Handed = Buffer.ReadLong()
        Item(n).LevelReq = Buffer.ReadLong()
        Item(n).Mastery = Buffer.ReadLong()
        Item(n).Name = Trim$(Buffer.ReadString)
        Item(n).Paperdoll = Buffer.ReadLong()
        Item(n).Pic = Buffer.ReadLong()
        Item(n).price = Buffer.ReadLong()
        Item(n).Rarity = Buffer.ReadLong()
        Item(n).Speed = Buffer.ReadLong()

        Item(n).Randomize = Buffer.ReadLong()
        Item(n).RandomMin = Buffer.ReadLong()
        Item(n).RandomMax = Buffer.ReadLong()

        Item(n).Stackable = Buffer.ReadLong()
        Item(n).Description = Trim$(Buffer.ReadString)

        For i = 0 To Stats.Stat_Count - 1
            Item(n).Stat_Req(i) = Buffer.ReadLong()
        Next

        Item(n).Type = Buffer.ReadLong()

        'Housing
        Item(n).FurnitureWidth = Buffer.ReadLong()
        Item(n).FurnitureHeight = Buffer.ReadLong()

        For a = 1 To 3
            For b = 1 To 3
                Item(n).FurnitureBlocks(a, b) = Buffer.ReadLong()
                Item(n).FurnitureFringe(a, b) = Buffer.ReadLong()
            Next
        Next

        Item(n).KnockBack = Buffer.ReadLong()
        Item(n).KnockBackTiles = Buffer.ReadLong()

        ' Save it
        SendUpdateItemToAll(n)
        SaveItem(n)
        Addlog(GetPlayerName(index) & " saved item #" & n & ".", ADMIN_LOG)
        Buffer = Nothing
    End Sub

    Sub Packet_EditNpc(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestEditNpc Then Exit Sub
        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SNpcEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveNPC(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim NpcNum As Long, i As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSaveNpc Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        NpcNum = buffer.ReadLong

        ' Update the Npc
        Npc(NpcNum).Animation = buffer.ReadLong()
        Npc(NpcNum).AttackSay = buffer.ReadString()
        Npc(NpcNum).Behaviour = buffer.ReadLong()
        For i = 1 To 5
            Npc(NpcNum).DropChance(i) = buffer.ReadLong()
            Npc(NpcNum).DropItem(i) = buffer.ReadLong()
            Npc(NpcNum).DropItemValue(i) = buffer.ReadLong()
        Next

        Npc(NpcNum).Exp = buffer.ReadLong()
        Npc(NpcNum).Faction = buffer.ReadLong()
        Npc(NpcNum).HP = buffer.ReadLong()
        Npc(NpcNum).Name = buffer.ReadString()
        Npc(NpcNum).Range = buffer.ReadLong()
        Npc(NpcNum).SpawnSecs = buffer.ReadLong()
        Npc(NpcNum).Sprite = buffer.ReadLong()

        For i = 0 To Stats.Stat_Count - 1
            Npc(NpcNum).Stat(i) = buffer.ReadLong()
        Next

        Npc(NpcNum).QuestNum = buffer.ReadLong()

        ' Save it
        Call SendUpdateNpcToAll(NpcNum)
        Call SaveNpc(NpcNum)
        Call Addlog(GetPlayerName(index) & " saved Npc #" & NpcNum & ".", ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_EditShop(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestEditShop Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SShopEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveShop(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim ShopNum As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSaveShop Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        ShopNum = buffer.ReadLong

        ' Prevent hacking
        If ShopNum < 0 Or ShopNum > MAX_SHOPS Then
            Exit Sub
        End If

        Shop(ShopNum).BuyRate = buffer.ReadLong()
        Shop(ShopNum).Name = buffer.ReadString()
        Shop(ShopNum).Face = buffer.ReadLong()

        For i = 0 To MAX_TRADES
            Shop(ShopNum).TradeItem(i).costitem = buffer.ReadLong()
            Shop(ShopNum).TradeItem(i).costvalue = buffer.ReadLong()
            Shop(ShopNum).TradeItem(i).Item = buffer.ReadLong()
            Shop(ShopNum).TradeItem(i).ItemValue = buffer.ReadLong()
        Next

        If Shop(ShopNum).Name Is Nothing Then Shop(ShopNum).Name = ""


        buffer = Nothing
        ' Save it
        Call SendUpdateShopToAll(ShopNum)
        Call SaveShop(ShopNum)
        Call Addlog(GetPlayerName(index) & " saving shop #" & ShopNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_EditSkill(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestEditSkill Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SSkillEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveSkill(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim skillnum As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSaveSkill Then Exit Sub

        skillnum = buffer.ReadLong

        ' Prevent hacking
        If skillnum < 0 Or skillnum > MAX_SKILLS Then
            Exit Sub
        End If

        Skill(skillnum).AccessReq = buffer.ReadLong()
        Skill(skillnum).AoE = buffer.ReadLong()
        Skill(skillnum).CastAnim = buffer.ReadLong()
        Skill(skillnum).CastTime = buffer.ReadLong()
        Skill(skillnum).CDTime = buffer.ReadLong()
        Skill(skillnum).ClassReq = buffer.ReadLong()
        Skill(skillnum).Dir = buffer.ReadLong()
        Skill(skillnum).Duration = buffer.ReadLong()
        Skill(skillnum).Icon = buffer.ReadLong()
        Skill(skillnum).Interval = buffer.ReadLong()
        Skill(skillnum).IsAoE = buffer.ReadLong()
        Skill(skillnum).LevelReq = buffer.ReadLong()
        Skill(skillnum).Map = buffer.ReadLong()
        Skill(skillnum).MPCost = buffer.ReadLong()
        Skill(skillnum).Name = buffer.ReadString()
        Skill(skillnum).range = buffer.ReadLong()
        Skill(skillnum).SkillAnim = buffer.ReadLong()
        Skill(skillnum).StunDuration = buffer.ReadLong()
        Skill(skillnum).Type = buffer.ReadLong()
        Skill(skillnum).Vital = buffer.ReadLong()
        Skill(skillnum).x = buffer.ReadLong()
        Skill(skillnum).y = buffer.ReadLong()

        'projectiles
        Skill(skillnum).IsProjectile = buffer.ReadLong()
        Skill(skillnum).Projectile = buffer.ReadLong()

        Skill(skillnum).KnockBack = buffer.ReadLong()
        Skill(skillnum).KnockBackTiles = buffer.ReadLong()

        ' Save it
        SendUpdateSkillToAll(skillnum)
        SaveSkill(skillnum)
        Addlog(GetPlayerName(index) & " saved Skill #" & skillnum & ".", ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_SetAccess(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSetAccess Then Exit Sub
        Dim n As Long
        Dim i As Long

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_CREATOR Then
            Exit Sub
        End If

        ' The index
        n = FindPlayer(buffer.ReadString) 'Parse(1))
        ' The access
        i = buffer.ReadLong 'CLng(Parse(2))

        ' Check for invalid access level
        If i >= 0 Or i <= 3 Then

            ' Check if player is on
            If n > 0 Then

                'check to see if same level access is trying to change another access of the very same level and boot them if they are.
                If GetPlayerAccess(n) = GetPlayerAccess(index) Then
                    Call PlayerMsg(index, "Invalid access level.")
                    Exit Sub
                End If

                If GetPlayerAccess(n) <= 0 Then
                    Call GlobalMsg(GetPlayerName(n) & " has been blessed with administrative access.")
                End If

                Call SetPlayerAccess(n, i)
                Call SendPlayerData(n)
                Call Addlog(GetPlayerName(index) & " has modified " & GetPlayerName(n) & "'s access.", ADMIN_LOG)
            Else
                Call PlayerMsg(index, "Player is not online.")
            End If

        Else
            Call PlayerMsg(index, "Invalid access level.")
        End If

        buffer = Nothing
    End Sub

    Sub Packet_WhosOnline(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CWhosOnline Then Exit Sub

        SendWhosOnline(index)

        buffer = Nothing
    End Sub

    Sub Packet_SetMotd(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CSetMotd Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        Options.MOTD = Trim$(buffer.ReadString)
        SaveOptions()

        GlobalMsg("MOTD changed to: " & Options.MOTD)
        Addlog(GetPlayerName(index) & " changed MOTD to: " & Options.MOTD, ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_PlayerSearch(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, TargetFound As Byte, rclick As Byte
        Dim x As Long, y As Long, i As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CSearch Then Exit Sub

        x = buffer.ReadLong
        y = buffer.ReadLong
        rclick = buffer.ReadLong

        ' Prevent subscript out of range
        If x < 0 Or x > Map(GetPlayerMap(index)).MaxX Or y < 0 Or y > Map(GetPlayerMap(index)).MaxY Then Exit Sub

        ' Check for a player
        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerMap(index) = GetPlayerMap(i) Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then

                            ' Consider the player
                            If i <> index Then
                                If GetPlayerLevel(i) >= GetPlayerLevel(index) + 5 Then
                                    PlayerMsg(index, "You wouldn't stand a chance.")
                                Else

                                    If GetPlayerLevel(i) > GetPlayerLevel(index) Then
                                        PlayerMsg(index, "This one seems to have an advantage over you.")
                                    Else

                                        If GetPlayerLevel(i) = GetPlayerLevel(index) Then
                                            PlayerMsg(index, "This would be an even fight.")
                                        Else

                                            If GetPlayerLevel(index) >= GetPlayerLevel(i) + 5 Then
                                                PlayerMsg(index, "You could slaughter that player.")
                                            Else

                                                If GetPlayerLevel(index) > GetPlayerLevel(i) Then
                                                    PlayerMsg(index, "You would have an advantage over that player.")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            ' Change target
                            TempPlayer(index).Target = i
                            TempPlayer(index).TargetType = TARGET_TYPE_PLAYER
                            PlayerMsg(index, "Your target is now " & GetPlayerName(i) & ".")
                            SendTarget(index, TempPlayer(index).Target, TempPlayer(index).TargetType)
                            TargetFound = 1
                            If rclick = 1 Then SendRightClick(index)
                            Exit Sub
                        End If
                    End If
                End If
            End If

        Next

        ' Check for an item
        For i = 1 To MAX_MAP_ITEMS

            If MapItem(GetPlayerMap(index), i).Num > 0 Then
                If MapItem(GetPlayerMap(index), i).x = x Then
                    If MapItem(GetPlayerMap(index), i).y = y Then
                        PlayerMsg(index, "You see " & CheckGrammar(Trim$(Item(MapItem(GetPlayerMap(index), i).Num).Name)) & ".")
                        Exit Sub
                    End If
                End If
            End If

        Next

        ' Check for an npc
        For i = 1 To MAX_MAP_NPCS

            If MapNpc(GetPlayerMap(index)).Npc(i).Num > 0 Then
                If MapNpc(GetPlayerMap(index)).Npc(i).x = x Then
                    If MapNpc(GetPlayerMap(index)).Npc(i).y = y Then
                        ' Change target
                        TempPlayer(index).Target = i
                        TempPlayer(index).TargetType = TARGET_TYPE_NPC
                        PlayerMsg(index, "Your target is now " & CheckGrammar(Trim$(Npc(MapNpc(GetPlayerMap(index)).Npc(i).Num).Name)) & ".")
                        SendTarget(index, TempPlayer(index).Target, TempPlayer(index).TargetType)
                        TargetFound = 1
                        Exit Sub
                    End If
                End If
            End If

        Next

        'Housing
        If Player(index).Character(TempPlayer(index).CurChar).InHouse > 0 Then
            If Player(index).Character(TempPlayer(index).CurChar).InHouse = index Then
                If Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex > 0 Then
                    If Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount > 0 Then
                        For i = 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount
                            If x >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X And x <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X + Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                If y <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y And y >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y - Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
                                    'Found an Item, get the index and lets pick it up!
                                    x = FindOpenInvSlot(index, Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum)
                                    If x > 0 Then
                                        GiveInvItem(index, Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum, 0, True)
                                        Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount = Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount - 1
                                        For x = i + 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount + 1
                                            Player(index).Character(TempPlayer(index).CurChar).House.Furniture(x - 1) = Player(index).Character(TempPlayer(index).CurChar).House.Furniture(x)
                                        Next
                                        ReDim Preserve Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount)
                                        SendFurnitureToHouse(index)
                                        Exit Sub
                                    Else
                                        PlayerMsg(index, "No inventory space available!")
                                    End If
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If


        If TargetFound = 0 Then
            SendTarget(index, 0, 0)
        End If

        buffer = Nothing
    End Sub

    Sub Packet_Party(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CParty Then Exit Sub

        n = FindPlayer(buffer.ReadString)
        buffer = Nothing

        ' Prevent partying with self
        If n = index Then Exit Sub

        ' Check for a previous party and if so drop it
        If TempPlayer(index).InParty = YES Then
            PlayerMsg(index, "You are already in a party!")
            Exit Sub
        End If

        If n > 0 Then

            ' Check if its an admin
            If GetPlayerAccess(index) > ADMIN_MONITOR Then
                Call PlayerMsg(index, "You can't join a party, you are an admin!")
                Exit Sub
            End If

            If GetPlayerAccess(n) > ADMIN_MONITOR Then
                Call PlayerMsg(index, "Admins cannot join parties!")
                Exit Sub
            End If

            ' Make sure they are in right level range
            If GetPlayerLevel(index) + 5 < GetPlayerLevel(n) Or GetPlayerLevel(index) - 5 > GetPlayerLevel(n) Then
                Call PlayerMsg(index, "There is more then a 5 level gap between you two, party failed.")
                Exit Sub
            End If

            ' Check to see if player is already in a party
            If TempPlayer(n).InParty = NO Then
                Call PlayerMsg(index, "Party request has been sent to " & GetPlayerName(n) & ".")
                Call PlayerMsg(n, GetPlayerName(index) & " wants you to join their party.  Type /join to join, or /leave to decline.")
                TempPlayer(index).PartyStarter = YES
                TempPlayer(index).PartyPlayer = n
                TempPlayer(n).PartyPlayer = index
            Else
                Call PlayerMsg(index, "Player is already in a party!")
            End If

        Else
            Call PlayerMsg(index, "Player is not online.")
        End If
    End Sub

    Sub Packet_JoinParty(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CJoinParty Then Exit Sub
        n = TempPlayer(index).PartyPlayer

        If n > 0 Then

            ' Check to make sure they aren't the starter
            If TempPlayer(index).PartyStarter = NO Then

                ' Check to make sure that each of there party players match
                If TempPlayer(n).PartyPlayer = index Then
                    Call PlayerMsg(index, "You have joined " & GetPlayerName(n) & "'s party!")
                    Call PlayerMsg(n, GetPlayerName(index) & " has joined your party!")
                    TempPlayer(index).InParty = YES
                    TempPlayer(n).InParty = YES
                Else
                    Call PlayerMsg(index, "Party failed.")
                End If

            Else
                Call PlayerMsg(index, "You have not been invited to join a party!")
            End If

        Else
            Call PlayerMsg(index, "You have not been invited into a party!")
        End If

        buffer = Nothing
    End Sub

    Sub Packet_LeaveParty(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CLeaveParty Then Exit Sub

        n = TempPlayer(index).PartyPlayer

        If n > 0 Then
            If TempPlayer(index).InParty = YES Then
                PlayerMsg(index, "You have left the party.")
                PlayerMsg(n, GetPlayerName(index) & " has left the party.")
                TempPlayer(index).PartyPlayer = 0
                TempPlayer(index).PartyStarter = NO
                TempPlayer(index).InParty = NO
                TempPlayer(n).PartyPlayer = 0
                TempPlayer(n).PartyStarter = NO
                TempPlayer(n).InParty = NO
            Else
                PlayerMsg(index, "Declined party request.")
                PlayerMsg(n, GetPlayerName(index) & " declined your request.")
                TempPlayer(index).PartyPlayer = 0
                TempPlayer(index).PartyStarter = NO
                TempPlayer(index).InParty = NO
                TempPlayer(n).PartyPlayer = 0
                TempPlayer(n).PartyStarter = NO
                TempPlayer(n).InParty = NO
            End If

        Else
            PlayerMsg(index, "You are not in a party!")
        End If

        buffer = Nothing
    End Sub

    Sub Packet_Skills(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CSkills Then Exit Sub

        SendPlayerSkills(index)

        buffer = Nothing
    End Sub

    Sub Packet_Cast(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CCast Then Exit Sub

        ' Skill slot
        n = buffer.ReadLong
        buffer = Nothing

        ' set the skill buffer before castin
        BufferSkill(index, n)

        buffer = Nothing
    End Sub

    Sub Packet_QuitGame(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CQuit Then Exit Sub
        CloseSocket(index)
        buffer = Nothing
    End Sub

    Sub Packet_SwapInvSlots(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim oldSlot As Integer, newSlot As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSwapInvSlots Then Exit Sub

        If TempPlayer(index).InTrade > 0 Or TempPlayer(index).InBank Or TempPlayer(index).InShop Then Exit Sub

        ' Old Slot
        oldSlot = buffer.ReadInteger
        newSlot = buffer.ReadInteger
        buffer = Nothing

        PlayerSwitchInvSlots(index, oldSlot, newSlot)

        buffer = Nothing
    End Sub

    Sub Packet_EditResource(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CRequestEditResource Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then Exit Sub

        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SResourceEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveResource(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim resourcenum As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CSaveResource Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then Exit Sub

        resourcenum = buffer.ReadLong

        ' Prevent hacking
        If resourcenum < 0 Or resourcenum > MAX_RESOURCES Then Exit Sub

        Resource(resourcenum).Animation = buffer.ReadLong()
        Resource(resourcenum).EmptyMessage = buffer.ReadString()
        Resource(resourcenum).ExhaustedImage = buffer.ReadLong()
        Resource(resourcenum).Health = buffer.ReadLong()
        Resource(resourcenum).ExpReward = buffer.ReadLong()
        Resource(resourcenum).ItemReward = buffer.ReadLong()
        Resource(resourcenum).Name = buffer.ReadString()
        Resource(resourcenum).ResourceImage = buffer.ReadLong()
        Resource(resourcenum).ResourceType = buffer.ReadLong()
        Resource(resourcenum).RespawnTime = buffer.ReadLong()
        Resource(resourcenum).SuccessMessage = buffer.ReadString()
        Resource(resourcenum).LvlRequired = buffer.ReadLong()
        Resource(resourcenum).ToolRequired = buffer.ReadLong()
        Resource(resourcenum).Walkthrough = buffer.ReadLong()

        ' Save it
        SendUpdateResourceToAll(resourcenum)
        SaveResource(resourcenum)

        Addlog(GetPlayerName(index) & " saved Resource #" & resourcenum & ".", ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_CheckPing(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SSendPing)
        SendDataTo(index, buffer.ToArray)
        buffer = Nothing
    End Sub

    Sub Packet_Unequip(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CUnequip Then Exit Sub

        PlayerUnequipItem(index, buffer.ReadLong)

        buffer = Nothing
    End Sub

    Sub Packet_RequestPlayerData(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestPlayerData Then Exit Sub

        SendPlayerData(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestItems(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestItems Then Exit Sub
        SendItems(index)
        buffer = Nothing
    End Sub

    Sub Packet_RequestNpcs(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestNPCS Then Exit Sub
        SendNpcs(index)
        buffer = Nothing
    End Sub

    Sub Packet_RequestResources(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestResources Then Exit Sub
        SendResources(index)
        buffer = Nothing
    End Sub

    Sub Packet_SpawnItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSpawnItem Then Exit Sub
        Dim tmpItem As Long
        Dim tmpAmount As Long

        ' item
        tmpItem = buffer.ReadLong
        tmpAmount = buffer.ReadLong

        If GetPlayerAccess(index) < ADMIN_CREATOR Then Exit Sub

        SpawnItem(tmpItem, tmpAmount, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))
        buffer = Nothing
    End Sub

    Sub Packet_TrainStat(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tmpstat As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CTrainStat Then Exit Sub
        ' check points
        If GetPlayerPOINTS(index) = 0 Then Exit Sub

        ' stat
        tmpstat = buffer.ReadLong

        ' increment stat
        SetPlayerStat(index, tmpstat, GetPlayerRawStat(index, tmpstat) + 1)

        ' decrement points
        SetPlayerPOINTS(index, GetPlayerPOINTS(index) - 1)

        ' send player new data
        SendPlayerData(index)
        buffer = Nothing
    End Sub

    Sub Packet_EditAnimation(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestEditAnimation Then Exit Sub
        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SAnimationEditor)
        SendDataTo(index, buffer.ToArray())
        buffer = Nothing
    End Sub

    Sub Packet_SaveAnimation(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim AnimNum As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSaveAnimation Then Exit Sub

        AnimNum = buffer.ReadLong

        ' Update the Animation
        For i = 0 To UBound(Animation(AnimNum).Frames)
            Animation(AnimNum).Frames(i) = buffer.ReadLong()
        Next

        For i = 0 To UBound(Animation(AnimNum).LoopCount)
            Animation(AnimNum).LoopCount(i) = buffer.ReadLong()
        Next

        For i = 0 To UBound(Animation(AnimNum).LoopTime)
            Animation(AnimNum).LoopTime(i) = buffer.ReadLong()
        Next

        Animation(AnimNum).Name = buffer.ReadString()

        If Animation(AnimNum).Name Is Nothing Then Animation(AnimNum).Name = ""

        For i = 0 To UBound(Animation(AnimNum).Sprite)
            Animation(AnimNum).Sprite(i) = buffer.ReadLong()
        Next

        buffer = Nothing

        ' Save it
        SaveAnimation(AnimNum)
        SendUpdateAnimationToAll(AnimNum)
        Addlog(GetPlayerName(index) & " saved Animation #" & AnimNum & ".", ADMIN_LOG)

    End Sub

    Sub Packet_RequestAnimations(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestAnimations Then Exit Sub

        SendAnimations(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestSkills(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestSkills Then Exit Sub

        SendSkills(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestShops(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestShops Then Exit Sub

        SendShops(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestLevelUp(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestLevelUp Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_CREATOR Then
            Exit Sub
        End If

        SetPlayerExp(index, GetPlayerNextLevel(index))
        CheckPlayerLevelUp(index)

        buffer = Nothing
    End Sub

    Sub Packet_ForgetSkill(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, skillslot As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CForgetSkill Then Exit Sub

        skillslot = buffer.ReadLong

        ' Check for subscript out of range
        If skillslot < 1 Or skillslot > MAX_PLAYER_SKILLS Then
            Exit Sub
        End If

        ' dont let them forget a skill which is in CD
        If TempPlayer(index).SkillCD(skillslot) > 0 Then
            PlayerMsg(index, "Cannot forget a skill which is cooling down!")
            Exit Sub
        End If

        ' dont let them forget a skill which is buffered
        If TempPlayer(index).SkillBuffer = skillslot Then
            PlayerMsg(index, "Cannot forget a skill which you are casting!")
            Exit Sub
        End If

        Player(index).Character(TempPlayer(index).CurChar).Skill(skillslot) = 0
        SendPlayerSkills(index)

        buffer = Nothing
    End Sub

    Sub Packet_CloseShop(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CCloseShop Then Exit Sub

        TempPlayer(index).InShop = 0

        buffer = Nothing
    End Sub

    Sub Packet_BuyItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim shopslot As Long, shopnum As Long, itemamount As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CBuyItem Then Exit Sub

        shopslot = buffer.ReadLong

        ' not in shop, exit out
        shopnum = TempPlayer(index).InShop
        If shopnum < 1 Or shopnum > MAX_SHOPS Then Exit Sub

        With Shop(shopnum).TradeItem(shopslot)
            ' check trade exists
            If .Item < 1 Then Exit Sub

            ' check has the cost item
            itemamount = HasItem(index, .costitem)
            If itemamount = 0 Or itemamount < .costvalue Then
                PlayerMsg(index, "You do not have enough to buy this item.")
                ResetShopAction(index)
                Exit Sub
            End If

            ' it's fine, let's go ahead
            TakeInvItem(index, .costitem, .costvalue)
            GiveInvItem(index, .Item, .ItemValue)
        End With

        ' send confirmation message & reset their shop action
        PlayerMsg(index, "Trade successful.")
        ResetShopAction(index)

        buffer = Nothing
    End Sub

    Sub Packet_SellItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim invSlot As Long
        Dim itemNum As Long
        Dim price As Long
        Dim multiplier As Double
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSellItem Then Exit Sub

        invSlot = buffer.ReadLong

        ' if invalid, exit out
        If invSlot < 1 Or invSlot > MAX_INV Then Exit Sub

        ' has item?
        If GetPlayerInvItemNum(index, invSlot) < 1 Or GetPlayerInvItemNum(index, invSlot) > MAX_ITEMS Then Exit Sub

        ' seems to be valid
        itemNum = GetPlayerInvItemNum(index, invSlot)

        ' work out price
        multiplier = Shop(TempPlayer(index).InShop).BuyRate / 100
        price = Item(itemNum).price * multiplier

        ' item has cost?
        If price <= 0 Then
            PlayerMsg(index, "The shop doesn't want that item.")
            ResetShopAction(index)
            Exit Sub
        End If

        ' take item and give gold
        TakeInvItem(index, itemNum, 1)
        GiveInvItem(index, 1, price)

        ' send confirmation message & reset their shop action
        PlayerMsg(index, "Sold the " & Trim(Item(GetPlayerInvItemNum(index, invSlot)).Name) & " !")
        ResetShopAction(index)

        buffer = Nothing
    End Sub

    Sub Packet_ChangeBankSlots(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim oldslot As Long, newslot As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CChangeBankSlots Then Exit Sub

        oldslot = buffer.ReadLong
        newslot = buffer.ReadLong

        PlayerSwitchBankSlots(index, oldslot, newslot)

        buffer = Nothing
    End Sub

    Sub Packet_DepositItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim invslot As Long, amount As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CDepositItem Then Exit Sub

        invslot = buffer.ReadLong
        amount = buffer.ReadLong

        GiveBankItem(index, invslot, amount)

        buffer = Nothing
    End Sub

    Sub Packet_WithdrawItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim bankslot As Long, amount As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CWithdrawItem Then Exit Sub

        bankslot = buffer.ReadLong
        amount = buffer.ReadLong

        TakeBankItem(index, bankslot, amount)

        buffer = Nothing
    End Sub

    Sub Packet_CloseBank(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CCloseBank Then Exit Sub

        SaveBank(index)
        SavePlayer(index)

        TempPlayer(index).InBank = False

        buffer = Nothing
    End Sub

    Sub Packet_AdminWarp(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim x As Long, y As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CAdminWarp Then Exit Sub

        x = buffer.ReadLong
        y = buffer.ReadLong

        If GetPlayerAccess(index) >= ADMIN_MAPPER Then
            'Set the  Information
            SetPlayerX(index, x)
            SetPlayerY(index, y)

            'send the stuff
            SendPlayerXY(index)
        End If

        buffer = Nothing
    End Sub

    Sub Packet_TradeInvite(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim Name As String, tradetarget As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CTradeInvite Then Exit Sub

        Name = buffer.ReadString

        buffer = Nothing

        ' Check for a player

        tradetarget = FindPlayer(Name)

        ' make sure we don't error
        If tradetarget <= 0 Or tradetarget > MAX_PLAYERS Then Exit Sub

        ' can't trade with yourself..
        If tradetarget = index Then
            PlayerMsg(index, "You can't trade with yourself.")
            Exit Sub
        End If

        ' send the trade request
        TempPlayer(index).TradeRequest = tradetarget
        TempPlayer(tradetarget).TradeRequest = index

        PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " has invited you to trade.")
        PlayerMsg(index, "You have invited " & Trim$(GetPlayerName(tradetarget)) & " to trade.")
        SendClearTradeTimer(index)

        SendTradeInvite(tradetarget, index)
    End Sub

    Sub Packet_TradeInviteAccept(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, tradetarget As Long, status As Byte
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CTradeInviteAccept Then Exit Sub

        status = buffer.ReadLong

        buffer = Nothing

        If status = 0 Then  Exit Sub

        tradetarget = TempPlayer(index).TradeRequest

        ' Let them trade!
        If TempPlayer(tradetarget).TradeRequest = index Then
            ' let them know they're trading
            PlayerMsg(index, "You have accepted " & Trim$(GetPlayerName(tradetarget)) & "'s trade request.")
            PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " has accepted your trade request.")
            ' clear the trade timeout clientside
            SendClearTradeTimer(index)

            ' clear the tradeRequest server-side
            TempPlayer(index).TradeRequest = 0
            TempPlayer(tradetarget).TradeRequest = 0

            ' set that they're trading with each other
            TempPlayer(index).InTrade = tradetarget
            TempPlayer(tradetarget).InTrade = index

            ' clear out their trade offers
            ReDim TempPlayer(index).TradeOffer(MAX_INV)
            For i = 1 To MAX_INV
                TempPlayer(index).TradeOffer(i).Num = 0
                TempPlayer(index).TradeOffer(i).Value = 0
                TempPlayer(tradetarget).TradeOffer(i).Num = 0
                TempPlayer(tradetarget).TradeOffer(i).Value = 0
            Next
            ' Used to init the trade window clientside
            SendTrade(index, tradetarget)
            SendTrade(tradetarget, index)

            ' Send the offer data - Used to clear their client
            SendTradeUpdate(index, 0)
            SendTradeUpdate(index, 1)
            SendTradeUpdate(tradetarget, 0)
            SendTradeUpdate(tradetarget, 1)
            Exit Sub
        End If
    End Sub

    Sub Packet_AcceptTrade(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, itemNum As Long
        Dim tradeTarget As Long, i As Long
        Dim tmpTradeItem(0 To MAX_INV) As PlayerInvRec
        Dim tmpTradeItem2(0 To MAX_INV) As PlayerInvRec

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CAcceptTrade Then Exit Sub

        TempPlayer(index).AcceptTrade = True

        tradeTarget = TempPlayer(index).InTrade

        ' if not both of them accept, then exit
        If Not TempPlayer(tradeTarget).AcceptTrade Then
            SendTradeStatus(index, 2)
            SendTradeStatus(tradeTarget, 1)
            Exit Sub
        End If

        ' take their items
        For i = 1 To MAX_INV
            ' player
            If TempPlayer(index).TradeOffer(i).Num > 0 Then
                itemNum = Player(index).Character(TempPlayer(index).CurChar).Inv(TempPlayer(index).TradeOffer(i).Num).Num
                If itemNum > 0 Then
                    ' store temp
                    tmpTradeItem(i).Num = itemNum
                    tmpTradeItem(i).Value = TempPlayer(index).TradeOffer(i).Value
                    ' take item
                    TakeInvSlot(index, TempPlayer(index).TradeOffer(i).Num, tmpTradeItem(i).Value)
                End If
            End If
            ' target
            If TempPlayer(tradeTarget).TradeOffer(i).Num > 0 Then
                itemNum = GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)
                If itemNum > 0 Then
                    ' store temp
                    tmpTradeItem2(i).Num = itemNum
                    tmpTradeItem2(i).Value = TempPlayer(tradeTarget).TradeOffer(i).Value
                    ' take item
                    TakeInvSlot(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num, tmpTradeItem2(i).Value)
                End If
            End If
        Next

        ' taken all items. now they can't not get items because of no inventory space.
        For i = 1 To MAX_INV
            ' player
            If tmpTradeItem2(i).Num > 0 Then
                ' give away!
                GiveInvItem(index, tmpTradeItem2(i).Num, tmpTradeItem2(i).Value, False)
            End If
            ' target
            If tmpTradeItem(i).Num > 0 Then
                ' give away!
                GiveInvItem(tradeTarget, tmpTradeItem(i).Num, tmpTradeItem(i).Value, False)
            End If
        Next

        SendInventory(index)
        SendInventory(tradeTarget)

        ' they now have all the items. Clear out values + let them out of the trade.
        For i = 1 To MAX_INV
            TempPlayer(index).TradeOffer(i).Num = 0
            TempPlayer(index).TradeOffer(i).Value = 0
            TempPlayer(tradeTarget).TradeOffer(i).Num = 0
            TempPlayer(tradeTarget).TradeOffer(i).Value = 0
        Next

        TempPlayer(index).InTrade = 0
        TempPlayer(tradeTarget).InTrade = 0

        PlayerMsg(index, "Trade completed.")
        PlayerMsg(tradeTarget, "Trade completed.")

        SendCloseTrade(index)
        SendCloseTrade(tradeTarget)

        buffer = Nothing
    End Sub

    Sub Packet_DeclineTrade(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tradeTarget As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CDeclineTrade Then Exit Sub

        tradeTarget = TempPlayer(index).InTrade

        For i = 1 To MAX_INV
            TempPlayer(index).TradeOffer(i).Num = 0
            TempPlayer(index).TradeOffer(i).Value = 0
            TempPlayer(tradeTarget).TradeOffer(i).Num = 0
            TempPlayer(tradeTarget).TradeOffer(i).Value = 0
        Next

        TempPlayer(index).InTrade = 0
        TempPlayer(tradeTarget).InTrade = 0

        PlayerMsg(index, "You declined the trade.")
        PlayerMsg(tradeTarget, GetPlayerName(index) & " has declined the trade.")

        SendCloseTrade(index)
        SendCloseTrade(tradeTarget)

        buffer = Nothing
    End Sub

    Sub Packet_TradeItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim invslot As Long, amount As Long, emptyslot As Long, i As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CTradeItem Then Exit Sub

        invslot = buffer.ReadLong
        amount = buffer.ReadLong

        buffer = Nothing

        If invslot <= 0 Or invslot > MAX_INV Then Exit Sub
        If GetPlayerInvItemNum(index, invslot) <= 0 Then Exit Sub

        ' make sure they're not already offering it
        For i = 1 To MAX_INV
            If TempPlayer(index).TradeOffer(i).Num = invslot Then
                PlayerMsg(index, "You've already offered this item.")
                Exit Sub
            End If
        Next

        ' find open slot
        For i = 1 To MAX_INV
            If TempPlayer(index).TradeOffer(i).Num = 0 Then
                emptyslot = i
                Exit For
            End If
        Next

        If emptyslot <= 0 Or emptyslot > MAX_INV Then Exit Sub

        TempPlayer(index).TradeOffer(emptyslot).Num = invslot
        TempPlayer(index).TradeOffer(emptyslot).Value = amount

        If TempPlayer(index).AcceptTrade Then TempPlayer(index).AcceptTrade = False
        If TempPlayer(TempPlayer(index).InTrade).AcceptTrade Then TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

        SendTradeStatus(index, 0)
        SendTradeStatus(TempPlayer(index).InTrade, 0)

        SendTradeUpdate(index, 0)
        SendTradeUpdate(TempPlayer(index).InTrade, 1)
    End Sub

    Sub Packet_UntradeItem(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tradeslot As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CUntradeItem Then Exit Sub

        tradeslot = buffer.ReadLong

        buffer = Nothing

        If tradeslot <= 0 Or tradeslot > MAX_INV Then Exit Sub
        If TempPlayer(index).TradeOffer(tradeslot).Num <= 0 Then Exit Sub

        TempPlayer(index).TradeOffer(tradeslot).Num = 0
        TempPlayer(index).TradeOffer(tradeslot).Value = 0

        If TempPlayer(index).AcceptTrade Then TempPlayer(index).AcceptTrade = False
        If TempPlayer(TempPlayer(index).InTrade).AcceptTrade Then TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

        SendTradeStatus(index, 0)
        SendTradeStatus(TempPlayer(index).InTrade, 0)

        SendTradeUpdate(index, 0)
        SendTradeUpdate(TempPlayer(index).InTrade, 1)
    End Sub

    Public Sub Packet_PlayerMsg(ByVal index As Long, ByVal Data() As Byte)
        Dim buffer As ByteBuffer, OtherPlayer As String, Msg As String, OtherPlayerIndex As Long

        buffer = New ByteBuffer()
        buffer.WriteBytes(Data)
        If buffer.ReadLong <> ClientPackets.CPlayerMsg Then Exit Sub
        OtherPlayer = buffer.ReadString
        Msg = buffer.ReadString
        buffer = Nothing

        OtherPlayerIndex = FindPlayer(OtherPlayer)
        If OtherPlayerIndex <> index Then
            If OtherPlayerIndex > 0 Then
                Call Addlog(GetPlayerName(index) & " tells " & GetPlayerName(index) & ", '" & Msg & "'", PLAYER_LOG)
                Call PlayerMsg(OtherPlayerIndex, GetPlayerName(index) & " tells you, '" & Msg & "'")
                Call PlayerMsg(index, "You tell " & GetPlayerName(OtherPlayerIndex) & ", '" & Msg & "'")
            Else
                Call PlayerMsg(index, "Player is not online.")
            End If
        Else
            Call PlayerMsg(index, "Cannot message your self!")
        End If
    End Sub

    Public Sub HandleData(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer() As Byte
        Buffer = data.Clone
        Dim pLength As Long

        If TempPlayer(index).Buffer Is Nothing Then TempPlayer(index).Buffer = New ByteBuffer
        TempPlayer(index).Buffer.WriteBytes(Buffer)

        If TempPlayer(index).Buffer.Count = 0 Then
            TempPlayer(index).Buffer.Clear()
            Exit Sub
        End If

        If TempPlayer(index).Buffer.Length >= 4 Then
            pLength = TempPlayer(index).Buffer.ReadLong(False)

            If pLength <= 0 Then
                TempPlayer(index).Buffer.Clear()
                Exit Sub
            End If
        End If

        Do While pLength > 0 And pLength <= TempPlayer(index).Buffer.Length - 8

            If pLength <= TempPlayer(index).Buffer.Length - 8 Then
                TempPlayer(index).Buffer.ReadLong()
                data = TempPlayer(index).Buffer.ReadBytes(pLength)
                HandleDataPackets(index, data)
            End If

            pLength = 0

            If TempPlayer(index).Buffer.Length >= 4 Then
                pLength = TempPlayer(index).Buffer.ReadLong(False)

                If pLength < 0 Then
                    TempPlayer(index).Buffer.Clear()
                    Exit Sub
                End If
            End If

        Loop

        If GetPlayerAccess(index) <= 0 Then

            ' Check for data flooding
            If TempPlayer(index).DataBytes > 1000 Then
                HackingAttempt(index, "Data Flooding")
                Exit Sub
            End If

            ' Check for packet flooding
            If TempPlayer(index).DataPackets > 25 Then
                HackingAttempt(index, "Packet Flooding")
                Exit Sub
            End If
        End If

        ' Check if elapsed time has passed
        'Player(Index).DataBytes = Player(Index).DataBytes + DataLength
        If GetTickCount() >= TempPlayer(index).DataTimer Then
            TempPlayer(index).DataTimer = GetTickCount() + 1000
            TempPlayer(index).DataBytes = 0
            TempPlayer(index).DataPackets = 0
        End If

        If pLength <= 1 Then TempPlayer(index).Buffer.Clear()

        'seperates the data just in case 2 packets or more came in at one time, handles the data and makes sure
        'no one is packet flooding and stuff
    End Sub

    Sub HackingAttempt(ByVal Index As Long, ByVal Reason As String)

        If Index > 0 Then
            If IsPlaying(Index) Then
                Call GlobalMsg(GetPlayerLogin(Index) & "/" & GetPlayerName(Index) & " has been booted for (" & Reason & ")")
            End If

            Call AlertMsg(Index, "You have lost your connection with " & Options.Game_Name & ".")
        End If

    End Sub

    'Mapreport
    Sub Packet_MapReport(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CMapReport Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then Exit Sub

        SendMapReport(index)

        buffer = Nothing
    End Sub

    Sub Packet_Admin(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CAdmin Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then Exit Sub

        SendAdminPanel(index)

        buffer = Nothing
    End Sub

    Sub Packet_SetHotBarSkill(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, slot As Long, skill As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CSetHotbarSkill Then Exit Sub

        slot = buffer.ReadLong
        skill = buffer.ReadLong

        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot = skill
        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).sType = 1

        SendHotbar(index)

        buffer = Nothing
    End Sub

    Sub Packet_DeleteHotBarSkill(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, slot As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CDeleteHotbarSkill Then Exit Sub

        slot = buffer.ReadLong

        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot = 0
        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).sType = 0

        SendHotbar(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestClasses(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CRequestClasses Then Exit Sub

        SendClasses(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestEditClasses(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CRequestEditClasses Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then Exit Sub

        SendClasses(index)

        SendClassEditor(index)

        buffer = Nothing
    End Sub

    Sub Packet_SaveClasses(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, i As Long, z As Long, x As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ClientPackets.CSaveClasses Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then Exit Sub

        ' Max classes
        Max_Classes = buffer.ReadLong
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Stat_Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = buffer.ReadString

                ' get array size
                z = buffer.ReadLong

                ' redim array
                ReDim .MaleSprite(0 To z)
                ' loop-receive data
                For X = 0 To z
                    .MaleSprite(X) = buffer.ReadLong
                Next

                ' get array size
                z = buffer.ReadLong
                ' redim array
                ReDim .FemaleSprite(0 To z)
                ' loop-receive data
                For X = 0 To z
                    .FemaleSprite(X) = buffer.ReadLong
                Next

                .Stat(Stats.strength) = buffer.ReadLong
                .Stat(Stats.endurance) = buffer.ReadLong
                .Stat(Stats.vitality) = buffer.ReadLong
                .Stat(Stats.intelligence) = buffer.ReadLong
                .Stat(Stats.luck) = buffer.ReadLong
                .Stat(Stats.spirit) = buffer.ReadLong

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = buffer.ReadLong
                    .StartValue(q) = buffer.ReadLong
                Next

                .StartMap = buffer.ReadLong
                .StartX = buffer.ReadLong
                .StartY = buffer.ReadLong

                .BaseExp = buffer.ReadLong
            End With

        Next

        buffer = Nothing

        SaveClasses()

        LoadClasses()

        SendClassesToAll()
    End Sub

End Module
