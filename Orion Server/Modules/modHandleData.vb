Module modHandleData

    Private Delegate Sub Packet_(ByVal Index As Long, ByVal Data() As Byte)
    Private Packets As Dictionary(Of Integer, Packet_)

    Public Sub InitMessages()
        Packets = New Dictionary(Of Integer, Packet_)

        Packets.Add(ClientPackets.CNewAccount, AddressOf Packet_NewAccount)
        Packets.Add(ClientPackets.CLogin, AddressOf Packet_Login)
        Packets.Add(ClientPackets.CAddChar, AddressOf Packet_AddChar)
        Packets.Add(ClientPackets.CSayMsg, AddressOf Packet_SayMessage)
        Packets.Add(ClientPackets.CEmoteMsg, AddressOf Packet_EmoteMsg)
        Packets.Add(ClientPackets.CPlayerMsg, AddressOf Packet_PlayerMsg)
        Packets.Add(ClientPackets.CBroadcastMsg, AddressOf Packet_BroadCastMsg)
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
        Packets.Add(ClientPackets.CRequestEditSpell, AddressOf Packet_EditSpell)
        Packets.Add(ClientPackets.CSaveSpell, AddressOf Packet_SaveSpell)
        Packets.Add(ClientPackets.CSetAccess, AddressOf Packet_SetAccess)
        Packets.Add(ClientPackets.CWhosOnline, AddressOf Packet_WhosOnline)
        Packets.Add(ClientPackets.CSetMotd, AddressOf Packet_SetMotd)
        Packets.Add(ClientPackets.CSearch, AddressOf Packet_PlayerSearch)
        Packets.Add(ClientPackets.CParty, AddressOf Packet_Party)
        Packets.Add(ClientPackets.CJoinParty, AddressOf Packet_JoinParty)
        Packets.Add(ClientPackets.CLeaveParty, AddressOf Packet_LeaveParty)
        Packets.Add(ClientPackets.CSpells, AddressOf Packet_Spells)
        Packets.Add(ClientPackets.CCast, AddressOf Packet_Cast)
        Packets.Add(ClientPackets.CQuit, AddressOf Packet_QuitGame)
        Packets.Add(ClientPackets.CSwapInvSlots, AddressOf Packet_SwapInvSlots)
        Packets.Add(ClientPackets.CRequestEditResource, AddressOf Packet_EditResource)
        Packets.Add(ClientPackets.CSaveResource, AddressOf Packet_SaveResource)
        Packets.Add(ClientPackets.CCheckPing, AddressOf Packet_CheckPing)
        Packets.Add(ClientPackets.CUnequip, AddressOf Packet_Unequip)
        Packets.Add(ClientPackets.CRequestPlayerData, AddressOf Packet_RequestPlayerData)
        Packets.Add(ClientPackets.CRequestItems, AddressOf Packet_RequestItems)
        Packets.Add(ClientPackets.CRequestNPCS, AddressOf Packet_RequestAnimations)
        Packets.Add(ClientPackets.CRequestResources, AddressOf Packet_RequestResources)
        Packets.Add(ClientPackets.CSpawnItem, AddressOf Packet_SpawnItem)
        Packets.Add(ClientPackets.CTrainStat, AddressOf Packet_TrainStat)
        Packets.Add(ClientPackets.CRequestEditAnimation, AddressOf Packet_EditAnimation)
        Packets.Add(ClientPackets.CSaveAnimation, AddressOf Packet_SaveAnimation)
        Packets.Add(ClientPackets.CRequestAnimations, AddressOf Packet_SaveAnimation)
        Packets.Add(ClientPackets.CRequestSpells, AddressOf Packet_RequestSpells)
        Packets.Add(ClientPackets.CRequestShops, AddressOf Packet_RequestShops)
        Packets.Add(ClientPackets.CRequestLevelUp, AddressOf Packet_RequestLevelUp)
        Packets.Add(ClientPackets.CForgetSpell, AddressOf Packet_ForgetSpell)
        Packets.Add(ClientPackets.CCloseShop, AddressOf Packet_CloseShop)
        Packets.Add(ClientPackets.CBuyItem, AddressOf Packet_BuyItem)
        Packets.Add(ClientPackets.CSellItem, AddressOf Packet_SellItem)
        Packets.Add(ClientPackets.CChangeBankSlots, AddressOf Packet_ChangeBankSlots)
        Packets.Add(ClientPackets.CDepositItem, AddressOf Packet_DepositItem)
        Packets.Add(ClientPackets.CWithdrawItem, AddressOf Packet_WithdrawItem)
        Packets.Add(ClientPackets.CAdminWarp, AddressOf Packet_AdminWarp)
        Packets.Add(ClientPackets.CTradeRequest, AddressOf Packet_TradeRequest)
        Packets.Add(ClientPackets.CAcceptTrade, AddressOf Packet_AcceptTrade)
        Packets.Add(ClientPackets.CDeclineTrade, AddressOf Packet_DeclineTrade)
        Packets.Add(ClientPackets.CTradeItem, AddressOf Packet_TradeItem)
        Packets.Add(ClientPackets.CUntradeItem, AddressOf Packet_UntradeItem)
    End Sub

    Public Sub HandleDataPackets(ByVal index As Long, ByVal data() As Byte)
        Dim packetnum As Long, buffer As ByteBuffer, Packet As Packet_
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
                    Call AlertMsg(index, "Votre nom d'utilisateur ou mot de passe doit avoir trois caractères au minmimum")
                    Exit Sub
                End If

                ' Prevent hacking
                For i = 1 To Len(username)
                    n = AscW(Mid$(username, i, 1))

                    If Not isNameLegal(n) Then
                        Call AlertMsg(index, "Nom invalide, seul les lettre, nombre, espace et _ sont autorisé dans le nom.")
                        Exit Sub
                    End If

                Next

                ' Check to see if account already exists
                If Not AccountExist(username) Then
                    Call AddAccount(index, username, password)
                    TextAdd("Compte " & username & " a bien été crée.")
                    Call Addlog("Compte " & username & " a bien été crée.", PLAYER_LOG)

                    ' Load the player
                    Call LoadPlayer(index, username)

                    ' Check if character data has been created
                    If Len(Trim$(Player(index).Name)) > 0 Then
                        ' we have a char!
                        HandleUseChar(index)
                    Else
                        ' send new char shit
                        If Not IsPlaying(index) Then
                            Call SendNewCharClasses(index)
                        End If
                    End If

                    ' Show the player up on the socket status
                    Call Addlog(GetPlayerLogin(index) & " s'est connecté depuis " & GetPlayerIP(index) & ".", PLAYER_LOG)
                    TextAdd(GetPlayerLogin(index) & " s'est connecté depuis " & GetPlayerIP(index) & ".")
                Else
                    Call AlertMsg(index, "Désolé, votre nom d'utilisateur est déjà utilisé!")
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
                    Call AlertMsg(index, "Cette version n'est pas à jour, veuillez visiter " & Options.Website)
                    Exit Sub
                End If

                If isShuttingDown Then
                    Call AlertMsg(index, "Le serveur est en cours de redémarrage ou et sur le point de s'éteindre.")
                    Exit Sub
                End If

                If Len(Trim$(Name)) < 3 Or Len(Trim$(Password)) < 3 Then
                    Call AlertMsg(index, "Votre nom d'utilisateur doit avoir au minimum trois characteres")
                    Exit Sub
                End If

                If Not AccountExist(Name) Then
                    Call AlertMsg(index, "Le compte n'existe pas.")
                    Exit Sub
                End If

                If Not PasswordOK(Name, Password) Then
                    Call AlertMsg(index, "Mot de passe incorrect.")
                    Exit Sub
                End If

                If IsMultiAccounts(Name) Then
                    Call AlertMsg(index, "Le multi compte n'est pas autorisé.")
                    Exit Sub
                End If

                ' Load the player
                Call LoadPlayer(index, Name)
                ClearBank(index)
                LoadBank(index, Name)

                ' Check if character data has been created
                If Len(Trim$(Player(index).Name)) > 0 Then
                    ' we have a char!
                    HandleUseChar(index)
                Else
                    ' send new char shit
                    If Not IsPlaying(index) Then
                        Call SendNewCharClasses(index)
                    End If
                End If

                ' Show the player up on the socket status
                Call Addlog(GetPlayerLogin(index) & " s'est connecté depuis " & GetPlayerIP(index) & ".", PLAYER_LOG)
                TextAdd(GetPlayerLogin(index) & " s'est connecté depuis " & GetPlayerIP(index) & ".")

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

        Call Addlog("Carte #" & GetPlayerMap(index) & ": " & GetPlayerName(index) & " dit, '" & msg & "'", PLAYER_LOG)

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

        Call Addlog("Carte #" & GetPlayerMap(index) & ": " & GetPlayerName(index) & " " & msg, PLAYER_LOG)
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

        If TempPlayer(index).GettingMap = YES Then
            Exit Sub
        End If

        Dir = Buffer.ReadLong 'CLng(Parse(1))
        movement = Buffer.ReadLong 'CLng(Parse(2))
        tmpX = Buffer.ReadLong
        tmpY = Buffer.ReadLong
        Buffer = Nothing

        ' Prevent hacking
        If Dir < DIR_UP Or Dir > DIR_RIGHT Then
            Exit Sub
        End If

        ' Prevent hacking
        If movement < 1 Or movement > 2 Then
            Exit Sub
        End If

        ' Prevent player from moving if they have casted a spell
        If TempPlayer(index).SpellBuffer > 0 Then
            Call SendPlayerXY(index)
            Exit Sub
        End If

        'Cant move if in the bank!
        If TempPlayer(index).InBank Then
            Call SendPlayerXY(index)
            Exit Sub
        End If

        ' if stunned, stop them moving
        If TempPlayer(index).StunDuration > 0 Then
            Call SendPlayerXY(index)
            Exit Sub
        End If

        ' Prever player from moving if in shop
        If TempPlayer(index).InShop > 0 Then
            Call SendPlayerXY(index)
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

        Call PlayerMove(index, Dir, movement)

        Buffer = Nothing
    End Sub

    Sub Packet_PlayerDirection(ByVal Index As Long, ByVal Data() As Byte)
        Dim dir As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CPlayerDir Then Exit Sub
        If TempPlayer(Index).GettingMap = YES Then
            Exit Sub
        End If

        dir = Buffer.ReadLong 'CLng(Parse(1))
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
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next

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

                    Call SendWornEquipment(Index)
                    Call SendMapEquipment(Index)
                Case ITEM_TYPE_WEAPON

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next

                    If GetPlayerEquipment(Index, Equipment.Weapon) > 0 Then
                        tempitem = GetPlayerEquipment(Index, Equipment.Weapon)
                    End If

                    SetPlayerEquipment(Index, GetPlayerInvItemNum(Index, invnum), Equipment.Weapon)
                    PlayerMsg(Index, "Vous équipez " & CheckGrammar(Item(GetPlayerInvItemNum(Index, invnum)).Name))
                    TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 1)

                    If tempitem > 0 Then
                        GiveInvItem(Index, tempitem, 0) ' give back the stored item
                        tempitem = 0
                    End If

                    Call SendWornEquipment(Index)
                    Call SendMapEquipment(Index)
                Case ITEM_TYPE_HELMET

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next

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

                    Call SendWornEquipment(Index)
                    Call SendMapEquipment(Index)
                Case ITEM_TYPE_SHIELD

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next

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

                    Call SendWornEquipment(Index)
                    Call SendMapEquipment(Index)
                Case ITEM_TYPE_POTIONADDHP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next
                    SendActionMsg(GetPlayerMap(Index), "+" & Item(Player(Index).Inv(invnum).Num).Data1, BrightGreen, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    Call SetPlayerVital(Index, Vitals.HP, GetPlayerVital(Index, Vitals.HP) + Item(Player(Index).Inv(invnum).Num).Data1)
                    Call TakeInvItem(Index, Player(Index).Inv(invnum).Num, 0)
                    Call SendVital(Index, Vitals.HP)
                Case ITEM_TYPE_POTIONADDMP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next
                    SendActionMsg(GetPlayerMap(Index), "+" & Item(Player(Index).Inv(invnum).Num).Data1, BrightBlue, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    Call SetPlayerVital(Index, Vitals.MP, GetPlayerVital(Index, Vitals.MP) + Item(Player(Index).Inv(invnum).Num).Data1)
                    Call TakeInvItem(Index, Player(Index).Inv(invnum).Num, 0)
                    Call SendVital(Index, Vitals.MP)
                Case ITEM_TYPE_POTIONADDSP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next
                    Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    Call SetPlayerVital(Index, Vitals.SP, GetPlayerVital(Index, Vitals.SP) + Item(Player(Index).Inv(invnum).Num).Data1)
                    Call TakeInvItem(Index, Player(Index).Inv(invnum).Num, 0)
                    Call SendVital(Index, Vitals.SP)
                Case ITEM_TYPE_POTIONSUBHP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next
                    SendActionMsg(GetPlayerMap(Index), "-" & Item(Player(Index).Inv(invnum).Num).Data1, BrightRed, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    Call SetPlayerVital(Index, Vitals.HP, GetPlayerVital(Index, Vitals.HP) - Item(Player(Index).Inv(invnum).Num).Data1)
                    Call TakeInvItem(Index, Player(Index).Inv(invnum).Num, 0)
                    Call SendVital(Index, Vitals.HP)
                Case ITEM_TYPE_POTIONSUBMP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next
                    SendActionMsg(GetPlayerMap(Index), "-" & Item(Player(Index).Inv(invnum).Num).Data1, Blue, ACTIONMSG_SCROLL, GetPlayerX(Index) * 32, GetPlayerY(Index) * 32)
                    Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    Call SetPlayerVital(Index, Vitals.MP, GetPlayerVital(Index, Vitals.MP) - Item(Player(Index).Inv(invnum).Num).Data1)
                    Call TakeInvItem(Index, Player(Index).Inv(invnum).Num, 0)
                    Call SendVital(Index, Vitals.MP)
                Case ITEM_TYPE_POTIONSUBSP
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next
                    Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                    Call SetPlayerVital(Index, Vitals.SP, GetPlayerVital(Index, Vitals.SP) - Item(Player(Index).Inv(invnum).Num).Data1)
                    Call TakeInvItem(Index, Player(Index).Inv(invnum).Num, 0)
                    Call SendVital(Index, Vitals.SP)
                Case ITEM_TYPE_KEY
                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next

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
                            Call MapMsg(GetPlayerMap(Index), "Une porté à été débloquée.", White)

                            Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, x, y)

                            ' Check if we are supposed to take away the item
                            If Map(GetPlayerMap(Index)).Tile(x, y).Data2 = 1 Then
                                Call TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 0)
                                Call PlayerMsg(Index, "La clée à été détruite dans la serrure.")
                            End If
                        End If
                    End If

                Case ITEM_TYPE_SPELL

                    For i = 1 To Stats.Stat_Count - 1
                        If GetPlayerStat(Index, i) < Item(GetPlayerInvItemNum(Index, invnum)).Stat_Req(i) Then
                            PlayerMsg(Index, "Vous n'avez pas les statistiques pré-requis pour vous équiper de cet objet.")
                            Exit Sub
                        End If
                    Next

                    ' Get the spell num
                    n = Item(GetPlayerInvItemNum(Index, invnum)).Data1

                    If n > 0 Then

                        ' Make sure they are the right class
                        If Spell(n).ClassReq = GetPlayerClass(Index) Or Spell(n).ClassReq = 0 Then
                            ' Make sure they are the right level
                            i = Spell(n).LevelReq

                            If i <= GetPlayerLevel(Index) Then
                                i = FindOpenSpellSlot(Index)

                                ' Make sure they have an open spell slot
                                If i > 0 Then

                                    ' Make sure they dont already have the spell
                                    If Not HasSpell(Index, n) Then
                                        Call SetPlayerSpell(Index, i, n)
                                        Call SendAnimation(GetPlayerMap(Index), Item(GetPlayerInvItemNum(Index, invnum)).Animation, 0, 0, TARGET_TYPE_PLAYER, Index)
                                        Call TakeInvItem(Index, GetPlayerInvItemNum(Index, invnum), 0)
                                        Call PlayerMsg(Index, "Vous étudiez attentivement le sort.")
                                        Call PlayerMsg(Index, "Vous avez appris un nouveau sort!")
                                    Else
                                        Call PlayerMsg(Index, "Vous avez déjà apprit ce sort!")
                                    End If

                                Else
                                    Call PlayerMsg(Index, "Vous avez apprit tout ce que vous pouviez apprendre!")
                                End If

                            Else
                                Call PlayerMsg(Index, "Vous avez besoins de monter de niveau " & i & " pour apprendre ce sort.")
                            End If

                        Else
                            Call PlayerMsg(Index, "Ce sort peut être uniquement apprit par " & CheckGrammar(GetClassName(Spell(n).ClassReq)) & ".")
                        End If

                    Else
                        Call PlayerMsg(Index, "This scroll is not connected to a spell, please inform an admin!")
                    End If

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
        If TempPlayer(Index).SpellBuffer > 0 Then Exit Sub

        ' can't attack whilst stunned
        If TempPlayer(Index).StunDuration > 0 Then Exit Sub

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
                            'Call PlayerMsg(Index, "You feel a surge of energy upon swinging!", BrightCyan)
                            'Call PlayerMsg(TempIndex, GetPlayerName(Index) & " swings with enormous might!", BrightCyan)
                            SendActionMsg(GetPlayerMap(Index), "ATTAQUE CRITIQUE!", BrightCyan, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                        End If

                        Call AttackPlayer(Index, TempIndex, Damage)
                    Else
                        'Call PlayerMsg(Index, GetPlayerName(TempIndex) & "'s " & Trim$(Item(GetPlayerEquipment(TempIndex, Shield)).Name) & " has blocked your hit!", BrightCyan)
                        'Call PlayerMsg(TempIndex, "Your " & Trim$(Item(GetPlayerEquipment(TempIndex, Shield)).Name) & " has blocked " & GetPlayerName(Index) & "'s hit!", BrightCyan)
                        SendActionMsg(GetPlayerMap(TempIndex), "BLOQUE!", Pink, 1, (GetPlayerX(TempIndex) * 32), (GetPlayerY(TempIndex) * 32))
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
                Else
                    n = GetPlayerDamage(Index)
                    Damage = n + Int(Rnd() * (n \ 2)) + 1 - (Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Stat(Stats.endurance) \ 2)
                    'Call PlayerMsg(Index, "You feel a surge of energy upon swinging!", BrightCyan)
                    SendActionMsg(GetPlayerMap(Index), "ATTAQUE CRITIQUE!", BrightCyan, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
                End If

                If Damage > 0 Then
                    Call AttackNpc(Index, i, Damage)
                Else
                    Call PlayerMsg(Index, "Votre attaque n'a rien fait.")
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
            Call PlayerMsg(Index, "Compte: " & Trim$(Player(i).Login) & ", Nom: " & GetPlayerName(i))

            If GetPlayerAccess(Index) > ADMIN_MONITOR Then
                Call PlayerMsg(Index, "-=- Statistique pour " & GetPlayerName(i) & " -=-")
                Call PlayerMsg(Index, "Niveau: " & GetPlayerLevel(i) & "  Exp: " & GetPlayerExp(i) & "/" & GetPlayerNextLevel(i))
                Call PlayerMsg(Index, "HP: " & GetPlayerVital(i, Vitals.HP) & "/" & GetPlayerMaxVital(i, Vitals.HP) & "  MP: " & GetPlayerVital(i, Vitals.MP) & "/" & GetPlayerMaxVital(i, Vitals.MP) & "  SP: " & GetPlayerVital(i, Vitals.SP) & "/" & GetPlayerMaxVital(i, Vitals.SP))
                Call PlayerMsg(Index, "Force: " & GetPlayerStat(i, Stats.strength) & "  Défense: " & GetPlayerStat(i, Stats.endurance) & "  Magie: " & GetPlayerStat(i, Stats.intelligence) & "  Vitesse: " & GetPlayerStat(i, Stats.spirit))
                n = (GetPlayerStat(i, Stats.strength) \ 2) + (GetPlayerLevel(i) \ 2)
                i = (GetPlayerStat(i, Stats.endurance) \ 2) + (GetPlayerLevel(i) \ 2)

                If n > 100 Then n = 100
                If i > 100 Then i = 100
                Call PlayerMsg(Index, "Chance de coup critique: " & n & "%, Chance de bloquer: " & i & "%")
            End If

        Else
            Call PlayerMsg(Index, "Le joueur n'est pas en ligne.")
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
                Call PlayerWarp(Index, GetPlayerMap(n), GetPlayerX(n), GetPlayerY(n))
                Call PlayerMsg(n, GetPlayerName(Index) & " A été téléporter à vous.")
                Call PlayerMsg(Index, "Vous avez été téléporté à " & GetPlayerName(n) & ".")
                Call Addlog(GetPlayerName(Index) & "  A été téléporter à " & GetPlayerName(n) & ", carte #" & GetPlayerMap(n) & ".", ADMIN_LOG)
            Else
                Call PlayerMsg(Index, "Le joueur n'est pas en ligne.")
            End If

        Else
            Call PlayerMsg(Index, "Vous ne pouvez pas vous téléporter à vous même!")
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
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        ' The player
        n = FindPlayer(Buffer.ReadString) 'Parse(1))
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                Call PlayerWarp(n, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
                Call PlayerMsg(n, "Vous avez été convoqué par " & GetPlayerName(Index) & ".")
                Call PlayerMsg(Index, GetPlayerName(n) & " a été convoqué.")
                Call Addlog(GetPlayerName(Index) & " a été téléporté " & GetPlayerName(n) & " pour servir, carte #" & GetPlayerMap(Index) & ".", ADMIN_LOG)
            Else
                Call PlayerMsg(Index, "Le joueur n'est pas en ligne.")
            End If

        Else
            Call PlayerMsg(Index, "Vous ne pouvez pas vous téléporter à vous même!")
        End If

    End Sub
    ' :::::::::::::::::::::::
    ' ::   Warp to Packet  ::
    ' :::::::::::::::::::::::
    Sub Packet_WarpTo(ByVal Index As Long, ByVal Data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CWarpTo Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        ' The map
        n = Buffer.ReadLong 'CLng(Parse(1))
        Buffer = Nothing

        ' Prevent hacking
        If n < 0 Or n > MAX_MAPS Then
            Exit Sub
        End If

        Call PlayerWarp(Index, n, GetPlayerX(Index), GetPlayerY(Index))
        Call PlayerMsg(Index, "Vous avez été téléporter à la carte #" & n)
        Call Addlog(GetPlayerName(Index) & " téléporté à la carte #" & n & ".", ADMIN_LOG)

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

        Call PlayerMsg(Index, "-=- Statistique pour " & GetPlayerName(Index) & " -=-")
        Call PlayerMsg(Index, "Niveau: " & GetPlayerLevel(Index) & "  Exp: " & GetPlayerExp(Index) & "/" & GetPlayerNextLevel(Index))
        Call PlayerMsg(Index, "HP: " & GetPlayerVital(Index, Vitals.HP) & "/" & GetPlayerMaxVital(Index, Vitals.HP) & "  MP: " & GetPlayerVital(Index, Vitals.MP) & "/" & GetPlayerMaxVital(Index, Vitals.MP) & "  SP: " & GetPlayerVital(Index, Vitals.SP) & "/" & GetPlayerMaxVital(Index, Vitals.SP))
        Call PlayerMsg(Index, "STR: " & GetPlayerStat(Index, Stats.strength) & "  DEF: " & GetPlayerStat(Index, Stats.endurance) & "  MAGI: " & GetPlayerStat(Index, Stats.intelligence) & "  Vitesse: " & GetPlayerStat(Index, Stats.spirit))
        n = (GetPlayerStat(Index, Stats.strength) \ 2) + (GetPlayerLevel(Index) \ 2)
        i = (GetPlayerStat(Index, Stats.endurance) \ 2) + (GetPlayerLevel(Index) \ 2)

        If n > 100 Then n = 100
        If i > 100 Then i = 100
        Call PlayerMsg(Index, "Chance de coup critique: " & n & "%, Chance de bloquer: " & i & "%")
        Buffer = Nothing
    End Sub

    Sub Packet_RequestNewMap(ByVal Index As Long, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim dir As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ClientPackets.CRequestNewMap Then Exit Sub
        dir = Buffer.ReadLong 'CLng(Parse(1))
        Buffer = Nothing

        ' Prevent hacking
        If dir < DIR_UP Or dir > DIR_RIGHT Then
            Exit Sub
        End If

        Call PlayerMove(Index, dir, 1)
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
        If GetPlayerAccess(Index) < ADMIN_MAPPER Then
            Exit Sub
        End If
        Try
            MapNum = GetPlayerMap(Index)
            i = Map(MapNum).Revision + 1
            Call ClearMap(MapNum)

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
            ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

            For x = 1 To MAX_MAP_NPCS
                Call ClearMapNpc(x, MapNum)
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
                        For i = 0 To MapLayer.Layer_Count - 1
                            .Tile(x, y).Layer(i).Tileset = Buffer.ReadLong
                            .Tile(x, y).Layer(i).x = Buffer.ReadLong
                            .Tile(x, y).Layer(i).y = Buffer.ReadLong
                        Next
                        .Tile(x, y).Type = Buffer.ReadLong
                    Next
                Next
            End With
        Catch exp As Exception
            Debug.Print("jcs: " & CStr(jcs) & " " & Buffer.Count & "  " & CStr(Buffer.GetReadPos))

        End Try


        Call SendMapNpcsToMap(MapNum)
        Call SpawnMapNpcs(MapNum)

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            Call SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), MapItem(GetPlayerMap(Index), i).x, MapItem(GetPlayerMap(Index), i).y)
            Call ClearMapItem(i, GetPlayerMap(Index))
        Next

        ' Respawn
        Call SpawnMapItems(GetPlayerMap(Index))
        ' Save the map
        Call SaveMap(MapNum)
        Call ClearTempTile(MapNum)
        Call CacheResources(MapNum)

        ' Refresh map for everyone online
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = MapNum Then
                Call PlayerWarp(i, MapNum, GetPlayerX(i), GetPlayerY(i))
            End If
        Next i

        Buffer = Nothing
    End Sub

    Private Sub Packet_AddChar(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String
        Dim Sex As Long
        Dim Classes As Long
        Dim Sprite As Long
        Dim i As Long
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CAddChar Then Exit Sub

        If Not IsPlaying(index) Then

            Name = Buffer.ReadString
            Sex = Buffer.ReadLong
            Classes = Buffer.ReadLong
            Sprite = Buffer.ReadLong

            ' Prevent hacking
            If Len(Trim$(Name)) < 3 Then
                Call AlertMsg(index, "Votre personnage doit avoir au moins trois charactères.")
                Exit Sub
            End If

            ' Prevent hacking
            For i = 1 To Len(Name)
                n = AscW(Mid$(Name, i, 1))

                If Not isNameLegal(n) Then
                    Call AlertMsg(index, "Nom invalide, seul les lettre, nombre, espace et _ sont autorisé dans le nom.")
                    Exit Sub
                End If

            Next

            ' Prevent hacking
            If (Sex < SEX_MALE) Or (Sex > SEX_FEMALE) Then
                Exit Sub
            End If

            ' Prevent hacking
            If Classes < 1 Or Classes > Max_Classes Then
                Exit Sub
            End If

            ' Check if char already exists in slot
            If CharExist(index) Then
                Call AlertMsg(index, "Le personnage existe déjà!")
                Exit Sub
            End If

            ' Check if name is already in use
            If FindChar(Name) Then
                Call AlertMsg(index, "Désolé, ce nom est déjà utilisé!")
                Exit Sub
            End If

            ' Everything went ok, add the character
            Call AddChar(index, Name, Sex, Classes, Sprite)
            Call Addlog("Le personnage " & Name & " ajouté " & GetPlayerLogin(index) & " au compte.", PLAYER_LOG)
            ' log them in!!
            HandleUseChar(index)

            Buffer = Nothing
        End If
        NeedToUpDatePlayerList = True
    End Sub

    Private Sub Packet_NeedMap(ByVal index As Long, ByVal data() As Byte)
        Dim s As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CNeedMap Then Exit Sub

        ' Get yes/no value
        s = Buffer.ReadLong 'Parse(1)
        Buffer = Nothing

        ' Check if map data is needed to be sent
        If s = 1 Then
            Call SendMapData(index, GetPlayerMap(index), True)
        Else
            Call SendMapData(index, GetPlayerMap(index), False)
        End If

        Call SendJoinMap(index)
        TempPlayer(index).GettingMap = NO
    End Sub

    Private Sub Packet_GetItem(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CMapGetItem Then Exit Sub
        Call PlayerMapGetItem(index)
        Buffer = Nothing
    End Sub

    Private Sub Packet_DropItem(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim InvNum As Long, Amount As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ClientPackets.CMapDropItem Then Exit Sub
        InvNum = Buffer.ReadLong 'CLng(Parse(1))
        Amount = Buffer.ReadLong 'CLng(Parse(2))
        Buffer = Nothing

        If TempPlayer(index).InBank Or TempPlayer(index).InShop Then Exit Sub

        ' Prevent hacking
        If InvNum < 1 Or InvNum > MAX_INV Then Exit Sub
        If GetPlayerInvItemNum(index, InvNum) < 1 Or GetPlayerInvItemNum(index, InvNum) > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(index, InvNum)).Type = ITEM_TYPE_CURRENCY Then
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
        Call PlayerMsg(Index, "Réaparition de la carte.")
        Call Addlog(GetPlayerName(Index) & " est réapparu sur la carte #" & GetPlayerMap(Index), ADMIN_LOG)

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
                    Call GlobalMsg(GetPlayerName(n) & " a été kicker depuis " & Options.Game_Name & " par " & GetPlayerName(Index) & "!")
                    Call Addlog(GetPlayerName(Index) & " a été kické " & GetPlayerName(n) & ".", ADMIN_LOG)
                    Call AlertMsg(n, "Vous avez été kické par " & GetPlayerName(Index) & "!")
                Else
                    Call PlayerMsg(Index, "That is a higher or same access admin then you!")
                End If

            Else
                Call PlayerMsg(Index, "Le joueur n'est pas en ligne.")
            End If

        Else
            Call PlayerMsg(Index, "Vous ne pouvez vous kicker!")
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

        PlayerMsg(Index, "La commande /banlist n'est pas disponible dans EO.Net... actuellement ;).")

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
        Call PlayerMsg(Index, "Liste des banni supprimée.")
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
                Call PlayerMsg(Index, "Le joueur n'est pas en ligne.")
            End If

        Else
            Call PlayerMsg(Index, "Vous ne pouvez vous bannir vous même!")
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
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        n = Buffer.ReadLong 'CLng(Parse(1))

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
        Item(n).Name = Buffer.ReadString()
        Item(n).Paperdoll = Buffer.ReadLong()
        Item(n).Pic = Buffer.ReadLong()
        Item(n).price = Buffer.ReadLong()
        Item(n).Rarity = Buffer.ReadLong()
        Item(n).Speed = Buffer.ReadLong()

        For i = 0 To Stats.Stat_Count - 1
            Item(n).Stat_Req(i) = Buffer.ReadLong()
        Next

        Item(n).Type = Buffer.ReadLong()

        ' Save it
        Call SendUpdateItemToAll(n)
        Call SaveItem(n)
        Call Addlog(GetPlayerName(index) & " a sauvegardé l'objet #" & n & ".", ADMIN_LOG)
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
        Dim NpcNum As Long
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
        Npc(NpcNum).DropChance = buffer.ReadLong()
        Npc(NpcNum).DropItem = buffer.ReadLong()
        Npc(NpcNum).DropItemValue = buffer.ReadLong()
        Npc(NpcNum).exp = buffer.ReadLong()
        Npc(NpcNum).faction = buffer.ReadLong()
        Npc(NpcNum).HP = buffer.ReadLong()
        Npc(NpcNum).Name = buffer.ReadString()
        Npc(NpcNum).range = buffer.ReadLong()
        Npc(NpcNum).SpawnSecs = buffer.ReadLong()
        Npc(NpcNum).Sprite = buffer.ReadLong()

        For i = 0 To Stats.Stat_Count - 1
            Npc(NpcNum).Stat(i) = buffer.ReadLong()
        Next

        ' Save it
        Call SendUpdateNpcToAll(NpcNum)
        Call SaveNpc(NpcNum)
        Call Addlog(GetPlayerName(index) & " à sauvegardé le PNJ #" & NpcNum & ".", ADMIN_LOG)

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
        Call Addlog(GetPlayerName(index) & " a sauvegardé le magasin #" & ShopNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_EditSpell(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestEditSpell Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SSpellEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveSpell(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim spellnum As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSaveSpell Then Exit Sub

        spellnum = buffer.ReadLong

        ' Prevent hacking
        If spellnum < 0 Or spellnum > MAX_SPELLS Then
            Exit Sub
        End If

        Spell(spellnum).AccessReq = buffer.ReadLong()
        Spell(spellnum).AoE = buffer.ReadLong()
        Spell(spellnum).CastAnim = buffer.ReadLong()
        Spell(spellnum).CastTime = buffer.ReadLong()
        Spell(spellnum).CDTime = buffer.ReadLong()
        Spell(spellnum).ClassReq = buffer.ReadLong()
        Spell(spellnum).Dir = buffer.ReadLong()
        Spell(spellnum).Duration = buffer.ReadLong()
        Spell(spellnum).Icon = buffer.ReadLong()
        Spell(spellnum).Interval = buffer.ReadLong()
        Spell(spellnum).IsAoE = buffer.ReadLong()
        Spell(spellnum).LevelReq = buffer.ReadLong()
        Spell(spellnum).Map = buffer.ReadLong()
        Spell(spellnum).MPCost = buffer.ReadLong()
        Spell(spellnum).Name = buffer.ReadString()
        Spell(spellnum).range = buffer.ReadLong()
        Spell(spellnum).SpellAnim = buffer.ReadLong()
        Spell(spellnum).StunDuration = buffer.ReadLong()
        Spell(spellnum).Type = buffer.ReadLong()
        Spell(spellnum).Vital = buffer.ReadLong()
        Spell(spellnum).x = buffer.ReadLong()
        Spell(spellnum).y = buffer.ReadLong()

        ' Save it
        Call SendUpdateSpellToAll(spellnum)
        Call SaveSpell(spellnum)
        Call Addlog(GetPlayerName(index) & " a sauvegardé les magies #" & spellnum & ".", ADMIN_LOG)

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
                    Call PlayerMsg(index, "Niveau d'accès inccorect.")
                    Exit Sub
                End If

                If GetPlayerAccess(n) <= 0 Then
                    Call GlobalMsg(GetPlayerName(n) & " a été bénie avec les droits adminisrateur.")
                End If

                Call SetPlayerAccess(n, i)
                Call SendPlayerData(n)
                Call Addlog(GetPlayerName(index) & " a modifié les acces de " & GetPlayerName(n) & " !", ADMIN_LOG)
            Else
                Call PlayerMsg(index, "Le joueur n'est pas en ligne.")
            End If

        Else
            Call PlayerMsg(index, "Niveau d'accès inccorect.")
        End If

        buffer = Nothing
    End Sub

    Sub Packet_WhosOnline(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CWhosOnline Then Exit Sub
        Call SendWhosOnline(index)
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

        Options.MOTD = Trim$(buffer.ReadString) 'Parse(1))
        SaveOptions()
        Call GlobalMsg("Le message d'accueil à été changé en: " & Options.MOTD)
        Call Addlog(GetPlayerName(index) & " a été changé en: " & Options.MOTD, ADMIN_LOG)
        buffer = Nothing
    End Sub

    Sub Packet_PlayerSearch(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim x As Long, y As Long, i As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSearch Then Exit Sub

        x = buffer.ReadLong
        y = buffer.ReadLong

        ' Prevent subscript out of range
        If x < 0 Or x > Map(GetPlayerMap(index)).MaxX Or y < 0 Or y > Map(GetPlayerMap(index)).MaxY Then
            Exit Sub
        End If

        ' Check for a player
        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerMap(index) = GetPlayerMap(i) Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then

                            ' Consider the player
                            If i <> index Then
                                If GetPlayerLevel(i) >= GetPlayerLevel(index) + 5 Then
                                    Call PlayerMsg(index, "Vous ne voudriez pas une chance.")
                                Else

                                    If GetPlayerLevel(i) > GetPlayerLevel(index) Then
                                        Call PlayerMsg(index, "Celui-ci semble avoir un avantage sur vous.")
                                    Else

                                        If GetPlayerLevel(i) = GetPlayerLevel(index) Then
                                            Call PlayerMsg(index, "Ce serait un combat même.")
                                        Else

                                            If GetPlayerLevel(index) >= GetPlayerLevel(i) + 5 Then
                                                Call PlayerMsg(index, "Vous pouvez abattre que le jeu.")
                                            Else

                                                If GetPlayerLevel(index) > GetPlayerLevel(i) Then
                                                    Call PlayerMsg(index, "Vous souhaitez avoir un avantage sur ce joueur.")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            ' Change target
                            TempPlayer(index).Target = i
                            TempPlayer(index).TargetType = TARGET_TYPE_PLAYER
                            Call PlayerMsg(index, "Votre cible est maintenant " & GetPlayerName(i) & ".")
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
                        Call PlayerMsg(index, "Vous voyez " & CheckGrammar(Trim$(Item(MapItem(GetPlayerMap(index), i).Num).Name)) & ".")
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
                        Call PlayerMsg(index, "Votre cible est maintenant " & CheckGrammar(Trim$(Npc(MapNpc(GetPlayerMap(index)).Npc(i).Num).Name)) & ".")
                        Exit Sub
                    End If
                End If
            End If

        Next

        buffer = Nothing
    End Sub

    Sub Packet_Party(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CParty Then Exit Sub

        n = FindPlayer(buffer.ReadString) 'Parse(1))
        buffer = Nothing

        ' Prevent partying with self
        If n = index Then
            Exit Sub
        End If

        ' Check for a previous party and if so drop it
        If TempPlayer(index).InParty = YES Then
            Call PlayerMsg(index, "Vous êtes déjà dans un groupe!")
            Exit Sub
        End If

        If n > 0 Then

            ' Check if its an admin
            If GetPlayerAccess(index) > ADMIN_MONITOR Then
                Call PlayerMsg(index, "Vous ne pouvez joindre un groupe, vous êtes un admin!")
                Exit Sub
            End If

            If GetPlayerAccess(n) > ADMIN_MONITOR Then
                Call PlayerMsg(index, "LEs admins ne peuvent joindre de groupe!")
                Exit Sub
            End If

            ' Make sure they are in right level range
            If GetPlayerLevel(index) + 5 < GetPlayerLevel(n) Or GetPlayerLevel(index) - 5 > GetPlayerLevel(n) Then
                Call PlayerMsg(index, "Il ya plus d'un écart de niveau 5 entre vous deux, création du groupe impossible.")
                Exit Sub
            End If

            ' Check to see if player is already in a party
            If TempPlayer(n).InParty = NO Then
                Call PlayerMsg(index, "Requète de groupe envoyé à " & GetPlayerName(n) & ".")
                Call PlayerMsg(n, GetPlayerName(index) & " souhaite rejoindre votre groupe. Tapez /join pour joindre ou /leave pour refuser.")
                TempPlayer(index).PartyStarter = YES
                TempPlayer(index).PartyPlayer = n
                TempPlayer(n).PartyPlayer = index
            Else
                Call PlayerMsg(index, "Ce joueur est déjà dans un groupe!")
            End If

        Else
            Call PlayerMsg(index, "Le joueur n'est pas en ligne.")
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
                    Call PlayerMsg(index, "Vous avez rejoinnt le groupe de " & GetPlayerName(n) & "!")
                    Call PlayerMsg(n, GetPlayerName(index) & " a rejoint votre groupe!")
                    TempPlayer(index).InParty = YES
                    TempPlayer(n).InParty = YES
                Else
                    Call PlayerMsg(index, "Création du groupé échoué.")
                End If

            Else
                Call PlayerMsg(index, "Vous n'avez pas été invité pour rejoindre un groupe!")
            End If

        Else
            Call PlayerMsg(index, "Vous n'avez pas été invité pour rejoindre un groupe!")
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
                Call PlayerMsg(index, "Vous avez quitté le groupe.")
                Call PlayerMsg(n, GetPlayerName(index) & " a quitté le groupe.")
                TempPlayer(index).PartyPlayer = 0
                TempPlayer(index).PartyStarter = NO
                TempPlayer(index).InParty = NO
                TempPlayer(n).PartyPlayer = 0
                TempPlayer(n).PartyStarter = NO
                TempPlayer(n).InParty = NO
            Else
                Call PlayerMsg(index, "Votre requète de groupé à été décliné.")
                Call PlayerMsg(n, GetPlayerName(index) & " décliner votre demande.")
                TempPlayer(index).PartyPlayer = 0
                TempPlayer(index).PartyStarter = NO
                TempPlayer(index).InParty = NO
                TempPlayer(n).PartyPlayer = 0
                TempPlayer(n).PartyStarter = NO
                TempPlayer(n).InParty = NO
            End If

        Else
            Call PlayerMsg(index, "Vous n'êtes pas dans un groupe!")
        End If

        buffer = Nothing
    End Sub

    Sub Packet_Spells(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSpells Then Exit Sub

        Call SendPlayerSpells(index)

        buffer = Nothing
    End Sub

    Sub Packet_Cast(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CCast Then Exit Sub

        ' Spell slot
        n = buffer.ReadLong 'CLng(Parse(1))
        buffer = Nothing
        ' set the spell buffer before castin
        Call BufferSpell(index, n)

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
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

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
        If GetPlayerAccess(index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        resourcenum = buffer.ReadLong

        ' Prevent hacking
        If resourcenum < 0 Or resourcenum > MAX_RESOURCES Then
            Exit Sub
        End If

        Resource(resourcenum).Animation = buffer.ReadLong()
        Resource(resourcenum).EmptyMessage = buffer.ReadString()
        Resource(resourcenum).ExhaustedImage = buffer.ReadLong()
        Resource(resourcenum).health = buffer.ReadLong()
        Resource(resourcenum).ItemReward = buffer.ReadLong()
        Resource(resourcenum).Name = buffer.ReadString()
        Resource(resourcenum).ResourceImage = buffer.ReadLong()
        Resource(resourcenum).ResourceType = buffer.ReadLong()
        Resource(resourcenum).RespawnTime = buffer.ReadLong()
        Resource(resourcenum).SuccessMessage = buffer.ReadString()
        Resource(resourcenum).ToolRequired = buffer.ReadLong()
        Resource(resourcenum).Walkthrough = buffer.ReadLong()

        ' Save it
        Call SendUpdateResourceToAll(resourcenum)
        Call SaveResource(resourcenum)
        Call Addlog(GetPlayerName(index) & " a sauvegarder les ressources #" & resourcenum & ".", ADMIN_LOG)
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
        Dim n As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CSaveAnimation Then Exit Sub

        n = buffer.ReadLong
        ' Update the Animation
        For i = 0 To UBound(Animation(n).Frames)
            Animation(n).Frames(i) = buffer.ReadLong()
        Next

        For i = 0 To UBound(Animation(n).LoopCount)
            Animation(n).LoopCount(i) = buffer.ReadLong()
        Next

        For i = 0 To UBound(Animation(n).LoopTime)
            Animation(n).LoopTime(i) = buffer.ReadLong()
        Next

        Animation(n).Name = buffer.ReadString()

        If Animation(n).Name Is Nothing Then Animation(n).Name = ""

        For i = 0 To UBound(Animation(n).Sprite)
            Animation(n).Sprite(i) = buffer.ReadLong()
        Next

        buffer = Nothing
    End Sub

    Sub Packet_RequestAnimations(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestAnimations Then Exit Sub

        SendAnimations(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestSpells(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CRequestSpells Then Exit Sub

        SendSpells(index)

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

    Sub Packet_ForgetSpell(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer, spellslot As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CForgetSpell Then Exit Sub

        spellslot = buffer.ReadLong

        ' Check for subscript out of range
        If spellslot < 1 Or spellslot > MAX_PLAYER_SPELLS Then
            Exit Sub
        End If

        ' dont let them forget a spell which is in CD
        If TempPlayer(index).SpellCD(spellslot) > 0 Then
            PlayerMsg(index, "Cannot forget a spell which is cooling down!")
            Exit Sub
        End If

        ' dont let them forget a spell which is buffered
        If TempPlayer(index).SpellBuffer = spellslot Then
            PlayerMsg(index, "Cannot forget a spell which you are casting!")
            Exit Sub
        End If

        Player(index).Spell(spellslot) = 0
        SendPlayerSpells(index)

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
                PlayerMsg(index, "Vous n'avez pas assez pour acheter cet objet.")
                ResetShopAction(index)
                Exit Sub
            End If

            ' it's fine, let's go ahead
            TakeInvItem(index, .costitem, .costvalue)
            GiveInvItem(index, .Item, .ItemValue)
        End With

        ' send confirmation message & reset their shop action
        PlayerMsg(index, "Echange effectué.")
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
            PlayerMsg(index, "Le magasin ne veut pas cet objet.")
            ResetShopAction(index)
            Exit Sub
        End If

        ' take item and give gold
        TakeInvItem(index, itemNum, 1)
        GiveInvItem(index, 1, price)

        ' send confirmation message & reset their shop action
        PlayerMsg(index, "Echange effectué.")
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
            PlayerWarp(index, GetPlayerMap(index), x, y)
        End If

        buffer = Nothing
    End Sub

    Sub Packet_TradeRequest(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim x As Long, y As Long, i As Long, tradetarget As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ClientPackets.CTradeRequest Then Exit Sub

        x = buffer.ReadLong
        y = buffer.ReadLong

        buffer = Nothing

        ' Prevent subscript out of range
        If x < 0 Or x > Map(GetPlayerMap(index)).MaxX Or y < 0 Or y > Map(GetPlayerMap(index)).MaxY Then
            Exit Sub
        End If

        ' Check for a player
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If GetPlayerMap(index) = GetPlayerMap(i) Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then
                            tradetarget = i
                        End If
                    End If
                End If
            End If
        Next

        ' make sure we don't error
        If tradetarget <= 0 Or tradetarget > MAX_PLAYERS Then Exit Sub

        ' can't trade with yourself..
        If tradetarget = index Then
            PlayerMsg(index, "Vous ne pouvez effectuer un échange avec vous même.")
            Exit Sub
        End If

        ' if the request accepts an open request, let them trade!
        If TempPlayer(tradetarget).TradeRequest = index Then
            ' let them know they're trading
            PlayerMsg(index, "Vous avez accepté l'échange de " & Trim$(GetPlayerName(tradetarget)) & ".")
            PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " a accepté votre demande d'échange.")
            ' clear the trade timeout clientside
            SendClearTradeTimer(index)
            ' clear the tradeRequest server-side
            TempPlayer(index).TradeRequest = 0
            TempPlayer(tradetarget).TradeRequest = 0
            ' set that they're trading with each other
            TempPlayer(index).InTrade = tradetarget
            TempPlayer(tradetarget).InTrade = index
            ' clear out their trade offers
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

        ' send the trade request
        TempPlayer(index).TradeRequest = tradetarget
        PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " vous a invité à l'échange.")
        PlayerMsg(index, "Vous avez invité " & Trim$(GetPlayerName(tradetarget)) & " à l'échange.")
        SendClearTradeTimer(index)
    End Sub

    Sub Packet_AcceptTrade(ByVal index As Long, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tradeTarget As Long
        Dim i As Long
        Dim tmpTradeItem(0 To MAX_INV) As PlayerInvRec
        Dim tmpTradeItem2(0 To MAX_INV) As PlayerInvRec
        Dim itemNum As Long
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
                itemNum = Player(index).Inv(TempPlayer(index).TradeOffer(i).Num).Num
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

        PlayerMsg(index, "Echange effectué.")
        PlayerMsg(tradeTarget, "Echange terminé.")

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

        PlayerMsg(index, "Vous avez refusé l'échange.")
        PlayerMsg(tradeTarget, GetPlayerName(index) & " a refusé votre échange.")

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
                PlayerMsg(index, "Vous avez déjà échangé cette offre.")
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
                Call Addlog(GetPlayerName(index) & " appel " & GetPlayerName(index) & ", '" & Msg & "'", PLAYER_LOG)
                Call PlayerMsg(OtherPlayerIndex, GetPlayerName(index) & " vous appel, '" & Msg & "'")
                Call PlayerMsg(index, "Vous appelez " & GetPlayerName(OtherPlayerIndex) & ", '" & Msg & "'")
            Else
                Call PlayerMsg(index, "Le joueur n'est pas en ligne.")
            End If
        Else
            Call PlayerMsg(index, "Impossible de s'envoyer un message à soit-même!")
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

            Call AlertMsg(Index, "Vous avez perdu la connection avec " & Options.Game_Name & ".")
        End If

    End Sub

End Module
