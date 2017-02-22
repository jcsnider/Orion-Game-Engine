Imports System.IO

Module ServerHandleData

    Private Delegate Sub Packet_(ByVal Index As Integer, ByVal Data() As Byte)
    Private Packets As Dictionary(Of Integer, Packet_)

    Public Sub InitMessages()
        Packets = New Dictionary(Of Integer, Packet_)

        Packets.Add(ClientPackets.CNewAccount, AddressOf Packet_NewAccount)
        Packets.Add(ClientPackets.CDelAccount, AddressOf Packet_DeleteAccount)
        Packets.Add(ClientPackets.CLogin, AddressOf Packet_Login)
        Packets.Add(ClientPackets.CAddChar, AddressOf Packet_AddChar)
        Packets.Add(ClientPackets.CUseChar, AddressOf Packet_UseChar)
        Packets.Add(ClientPackets.CDelChar, AddressOf Packet_DeleteChar)
        Packets.Add(ClientPackets.CSayMsg, AddressOf Packet_SayMessage)
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
        Packets.Add(ClientPackets.CSaveMap, AddressOf Packet_MapData)
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

        Packets.Add(ClientPackets.CSetAccess, AddressOf Packet_SetAccess)
        Packets.Add(ClientPackets.CWhosOnline, AddressOf Packet_WhosOnline)
        Packets.Add(ClientPackets.CSetMotd, AddressOf Packet_SetMotd)
        Packets.Add(ClientPackets.CSearch, AddressOf Packet_PlayerSearch)
        Packets.Add(ClientPackets.CSkills, AddressOf Packet_Skills)
        Packets.Add(ClientPackets.CCast, AddressOf Packet_Cast)
        Packets.Add(ClientPackets.CQuit, AddressOf Packet_QuitGame)
        Packets.Add(ClientPackets.CSwapInvSlots, AddressOf Packet_SwapInvSlots)

        Packets.Add(ClientPackets.CCheckPing, AddressOf Packet_CheckPing)
        Packets.Add(ClientPackets.CUnequip, AddressOf Packet_Unequip)
        Packets.Add(ClientPackets.CRequestPlayerData, AddressOf Packet_RequestPlayerData)
        Packets.Add(ClientPackets.CRequestItems, AddressOf Packet_RequestItems)
        Packets.Add(ClientPackets.CRequestNPCS, AddressOf Packet_RequestNpcs)
        Packets.Add(ClientPackets.CRequestResources, AddressOf Packet_RequestResources)
        Packets.Add(ClientPackets.CSpawnItem, AddressOf Packet_SpawnItem)
        Packets.Add(ClientPackets.CTrainStat, AddressOf Packet_TrainStat)

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
        Packets.Add(ClientPackets.CRequestQuests, AddressOf Packet_RequestQuests)
        Packets.Add(ClientPackets.CQuestLogUpdate, AddressOf Packet_QuestLogUpdate)
        Packets.Add(ClientPackets.CPlayerHandleQuest, AddressOf Packet_PlayerHandleQuest)
        Packets.Add(ClientPackets.CQuestReset, AddressOf Packet_QuestReset)

        'Housing
        Packets.Add(ClientPackets.CBuyHouse, AddressOf Packet_BuyHouse)
        Packets.Add(ClientPackets.CVisit, AddressOf Packet_InviteToHouse)
        Packets.Add(ClientPackets.CAcceptVisit, AddressOf Packet_AcceptInvite)
        Packets.Add(ClientPackets.CPlaceFurniture, AddressOf Packet_PlaceFurniture)

        Packets.Add(ClientPackets.CSellHouse, AddressOf Packet_SellHouse)

        'hotbar
        Packets.Add(ClientPackets.CSetHotbarSlot, AddressOf Packet_SetHotBarSlot)
        Packets.Add(ClientPackets.CDeleteHotbarSlot, AddressOf Packet_DeleteHotBarSlot)
        Packets.Add(ClientPackets.CUseHotbarSlot, AddressOf Packet_UseHotBarSlot)

        'Events
        Packets.Add(ClientPackets.CEventChatReply, AddressOf Packet_EventChatReply)
        Packets.Add(ClientPackets.CEvent, AddressOf Packet_Event)
        Packets.Add(ClientPackets.CRequestSwitchesAndVariables, AddressOf Packet_RequestSwitchesAndVariables)
        Packets.Add(ClientPackets.CSwitchesAndVariables, AddressOf Packet_SwitchesAndVariables)
        Packets.Add(ClientPackets.CEventTouch, AddressOf Packet_EventTouch)

        'projectiles

        Packets.Add(ClientPackets.CRequestProjectiles, AddressOf HandleRequestProjectiles)
        Packets.Add(ClientPackets.CClearProjectile, AddressOf HandleClearProjectile)

        'craft
        Packets.Add(ClientPackets.CRequestRecipes, AddressOf Packet_RequestRecipes)

        Packets.Add(ClientPackets.CCloseCraft, AddressOf Packet_CloseCraft)
        Packets.Add(ClientPackets.CStartCraft, AddressOf Packet_StartCraft)

        Packets.Add(ClientPackets.CRequestClasses, AddressOf Packet_RequestClasses)

        'emotes
        Packets.Add(ClientPackets.CEmote, AddressOf Packet_Emote)

        'parties
        Packets.Add(ClientPackets.CRequestParty, AddressOf Packet_PartyRquest)
        Packets.Add(ClientPackets.CAcceptParty, AddressOf Packet_AcceptParty)
        Packets.Add(ClientPackets.CDeclineParty, AddressOf Packet_DeclineParty)
        Packets.Add(ClientPackets.CLeaveParty, AddressOf Packet_LeaveParty)
        Packets.Add(ClientPackets.CPartyChatMsg, AddressOf Packet_PartyChatMsg)

        'pets
        Packets.Add(ClientPackets.CRequestPets, AddressOf Packet_RequestPets)
        Packets.Add(ClientPackets.CSummonPet, AddressOf Packet_SummonPet)
        Packets.Add(ClientPackets.CPetMove, AddressOf Packet_PetMove)
        Packets.Add(ClientPackets.CSetBehaviour, AddressOf Packet_SetPetBehaviour)
        Packets.Add(ClientPackets.CReleasePet, AddressOf Packet_ReleasePet)
        Packets.Add(ClientPackets.CPetSkill, AddressOf Packet_PetSkill)
        Packets.Add(ClientPackets.CPetUseStatPoint, AddressOf Packet_UsePetStatPoint)

        'editor login
        Packets.Add(EditorPackets.EditorLogin, AddressOf Packet_EditorLogin)
        Packets.Add(EditorPackets.EditorRequestMap, AddressOf Packet_EditorRequestMap)
        Packets.Add(EditorPackets.EditorSaveMap, AddressOf Packet_EditorMapData)

        'editor
        Packets.Add(EditorPackets.RequestEditItem, AddressOf Packet_EditItem)
        Packets.Add(EditorPackets.SaveItem, AddressOf Packet_SaveItem)
        Packets.Add(EditorPackets.RequestEditNpc, AddressOf Packet_EditNpc)
        Packets.Add(EditorPackets.SaveNpc, AddressOf Packet_SaveNPC)
        Packets.Add(EditorPackets.RequestEditShop, AddressOf Packet_EditShop)
        Packets.Add(EditorPackets.SaveShop, AddressOf Packet_SaveShop)
        Packets.Add(EditorPackets.RequestEditSkill, AddressOf Packet_EditSkill)
        Packets.Add(EditorPackets.SaveSkill, AddressOf Packet_SaveSkill)
        Packets.Add(EditorPackets.RequestEditResource, AddressOf Packet_EditResource)
        Packets.Add(EditorPackets.SaveResource, AddressOf Packet_SaveResource)
        Packets.Add(EditorPackets.RequestEditAnimation, AddressOf Packet_EditAnimation)
        Packets.Add(EditorPackets.SaveAnimation, AddressOf Packet_SaveAnimation)
        Packets.Add(EditorPackets.RequestEditQuest, AddressOf Packet_RequestEditQuest)
        Packets.Add(EditorPackets.SaveQuest, AddressOf Packet_SaveQuest)
        Packets.Add(EditorPackets.RequestEditHouse, AddressOf Packet_RequestEditHouse)
        Packets.Add(EditorPackets.SaveHouses, AddressOf Packet_SaveHouses)
        Packets.Add(EditorPackets.RequestEditProjectiles, AddressOf HandleRequestEditProjectiles)
        Packets.Add(EditorPackets.SaveProjectile, AddressOf HandleSaveProjectile)
        Packets.Add(EditorPackets.RequestEditRecipes, AddressOf Packet_RequestEditRecipes)
        Packets.Add(EditorPackets.SaveRecipe, AddressOf Packet_SaveRecipe)
        Packets.Add(EditorPackets.RequestEditClasses, AddressOf Packet_RequestEditClasses)
        Packets.Add(EditorPackets.SaveClasses, AddressOf Packet_SaveClasses)
        Packets.Add(EditorPackets.RequestAutoMap, AddressOf Packet_RequestAutoMap)
        Packets.Add(EditorPackets.SaveAutoMap, AddressOf Packet_SaveAutoMap)

        'pet
        Packets.Add(EditorPackets.CRequestEditPet, AddressOf Packet_RequestEditPet)
        Packets.Add(EditorPackets.CSavePet, AddressOf Packet_SavePet)

    End Sub

    Public Sub HandleDataPackets(ByVal index As Integer, ByVal data() As Byte)
        Dim packetnum As Integer, buffer As ByteBuffer, Packet As Packet_
        Packet = Nothing
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        packetnum = buffer.ReadInteger
        buffer = Nothing
        If packetnum = 0 Then Exit Sub
        If packetnum <> ClientPackets.CCheckPing Then TempPlayer(index).DataPackets = TempPlayer(index).DataPackets + 1

        If Packets.TryGetValue(packetnum, Packet) Then
            Packet.Invoke(index, data)
        End If
    End Sub

    Private Sub Packet_NewAccount(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim username As String
        Dim password As String
        Dim i As Integer
        Dim n As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        'Make Sure that it is correct
        If buffer.ReadInteger <> ClientPackets.CNewAccount Then Exit Sub

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

                    If Not IsNameLegal(n) Then
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

    Private Sub Packet_DeleteAccount(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String
        'Dim Password As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CDelChar Then Exit Sub

        ' Get the data
        Name = Buffer.ReadString

        If GetPlayerLogin(index) = Trim$(Name) Then
            PlayerMsg(index, "You cannot delete your own account while online!", ColorType.BrightRed)
            Exit Sub
        End If

        For i = 1 To GetTotalPlayersOnline()
            If IsPlaying(i) Then
                If Trim$(Player(i).Login) = Trim$(Name) Then
                    AlertMsg(i, "Your account has been removed by an admin!")
                    ClearPlayer(i)
                End If
            End If
        Next
    End Sub

    Private Sub Packet_Login(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String
        Dim Password As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CLogin Then Exit Sub

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
                Buffer.WriteInteger(ServerPackets.SLoginOk)
                Buffer.WriteInteger(MAX_CHARS)

                For i = 1 To MAX_CHARS
                    If Player(index).Character(i).Classes <= 0 Then
                        Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                        Buffer.WriteInteger(Player(index).Character(i).Sprite)
                        Buffer.WriteInteger(Player(index).Character(i).Level)
                        Buffer.WriteString("")
                        Buffer.WriteInteger(0)
                    Else
                        Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                        Buffer.WriteInteger(Player(index).Character(i).Sprite)
                        Buffer.WriteInteger(Player(index).Character(i).Level)
                        Buffer.WriteString(Trim$(Classes(Player(index).Character(i).Classes).Name))
                        Buffer.WriteInteger(Player(index).Character(i).Sex)
                    End If

                Next

                SendDataTo(index, Buffer.ToArray)

                ' Show the player up on the socket status
                Addlog(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".", PLAYER_LOG)
                TextAdd(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".")

                '' Check if character data has been created
                'If Len(Trim$(Player(index).Character(TempPlayer(index).CurChar).Name)) > 0 Then
                '    ' we have a char!
                '    'HandleUseChar(index)
                'Else
                '    ' send new char shit
                '    If Not IsPlaying(index) Then
                '        SendNewCharClasses(index)
                '    End If
                'End If

                Buffer = Nothing
            End If
        End If
    End Sub

    Private Sub Packet_UseChar(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim slot As Byte

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CUseChar Then Exit Sub

        If Not IsPlaying(index) Then
            If IsLoggedIn(index) Then

                slot = Buffer.ReadInteger

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

    End Sub

    Private Sub Packet_AddChar(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String, slot As Byte
        Dim Sex As Integer
        Dim Classes As Integer
        Dim Sprite As Integer
        Dim i As Integer
        Dim n As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CAddChar Then Exit Sub

        If Not IsPlaying(index) Then
            slot = Buffer.ReadInteger
            Name = Buffer.ReadString
            Sex = Buffer.ReadInteger
            Classes = Buffer.ReadInteger
            Sprite = Buffer.ReadInteger

            ' Prevent hacking
            If Len(Trim$(Name)) < 3 Then
                AlertMsg(index, "Character name must be at least three characters in length.")
                Exit Sub
            End If

            ' Prevent hacking
            For i = 1 To Len(Name)
                n = AscW(Mid$(Name, i, 1))

                If Not IsNameLegal(n) Then
                    AlertMsg(index, "Invalid name, only letters, numbers, spaces, and _ allowed in names.")
                    Exit Sub
                End If

            Next

            ' Prevent hacking
            If (Sex < Enums.Sex.Male) Or (Sex > Enums.Sex.Female) Then Exit Sub

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

    End Sub

    Private Sub Packet_DeleteChar(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim slot As Byte

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CDelChar Then Exit Sub

        If Not IsPlaying(index) Then
            If IsLoggedIn(index) Then

                slot = Buffer.ReadInteger

                ' Check if character data has been created
                If Len(Trim$(Player(index).Character(slot).Name)) > 0 Then
                    ' we have a char!
                    DeleteName(Trim$(Player(index).Character(slot).Name))
                    ClearCharacter(index, slot)
                    SaveCharacter(index, slot)

                    Buffer = Nothing
                    Buffer = New ByteBuffer
                    Buffer.WriteInteger(ServerPackets.SLoginOk)
                    Buffer.WriteInteger(MAX_CHARS)

                    For i = 1 To MAX_CHARS
                        If Player(index).Character(i).Classes <= 0 Then
                            Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                            Buffer.WriteInteger(Player(index).Character(i).Sprite)
                            Buffer.WriteInteger(Player(index).Character(i).Level)
                            Buffer.WriteString("")
                            Buffer.WriteInteger(0)
                        Else
                            Buffer.WriteString(Trim$(Player(index).Character(i).Name))
                            Buffer.WriteInteger(Player(index).Character(i).Sprite)
                            Buffer.WriteInteger(Player(index).Character(i).Level)
                            Buffer.WriteString(Trim$(Classes(Player(index).Character(i).Classes).Name))
                            Buffer.WriteInteger(Player(index).Character(i).Sex)
                        End If

                    Next

                    SendDataTo(index, Buffer.ToArray)
                End If
            End If
        End If

    End Sub

    Private Sub Packet_SayMessage(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim msg As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CSayMsg Then Exit Sub
        'msg = Buffer.ReadString
        msg = Buffer.ReadUnicodeString()

        Addlog("Map #" & GetPlayerMap(index) & ": " & GetPlayerName(index) & " says, '" & msg & "'", PLAYER_LOG)

        SayMsg_Map(GetPlayerMap(index), index, msg, ColorType.White)
        SendChatBubble(GetPlayerMap(index), index, TargetType.Player, msg, ColorType.White)

        Buffer = Nothing
    End Sub

    Private Sub Packet_BroadCastMsg(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim msg As String
        Dim s As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CBroadcastMsg Then Exit Sub
        'msg = Buffer.ReadString
        msg = Buffer.ReadUnicodeString()

        s = "[Global]" & GetPlayerName(index) & ": " & msg
        SayMsg_Global(index, msg, ColorType.White)
        Addlog(s, PLAYER_LOG)
        TextAdd(s)

        Buffer = Nothing
    End Sub

    Public Sub Packet_PlayerMsg(ByVal index As Integer, ByVal Data() As Byte)
        Dim buffer As ByteBuffer, OtherPlayer As String, Msg As String, OtherPlayerIndex As Integer

        buffer = New ByteBuffer()
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ClientPackets.CPlayerMsg Then Exit Sub

        OtherPlayer = buffer.ReadString
        'Msg = buffer.ReadString
        Msg = buffer.ReadUnicodeString()
        buffer = Nothing

        OtherPlayerIndex = FindPlayer(OtherPlayer)
        If OtherPlayerIndex <> index Then
            If OtherPlayerIndex > 0 Then
                Addlog(GetPlayerName(index) & " tells " & GetPlayerName(index) & ", '" & Msg & "'", PLAYER_LOG)
                PlayerMsg(OtherPlayerIndex, GetPlayerName(index) & " tells you, '" & Msg & "'", ColorType.Pink)
                PlayerMsg(index, "You tell " & GetPlayerName(OtherPlayerIndex) & ", '" & Msg & "'", ColorType.Pink)
            Else
                PlayerMsg(index, "Player is not online.", ColorType.BrightRed)
            End If
        Else
            PlayerMsg(index, "Cannot message your self!", ColorType.BrightRed)
        End If
    End Sub

    Private Sub Packet_PlayerMove(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Dir As Integer
        Dim movement As Integer
        Dim tmpX As Integer, tmpY As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPlayerMove Then Exit Sub

        If TempPlayer(index).GettingMap = True Then Exit Sub

        Dir = Buffer.ReadInteger
        movement = Buffer.ReadInteger
        tmpX = Buffer.ReadInteger
        tmpY = Buffer.ReadInteger
        Buffer = Nothing

        ' Prevent hacking
        If Dir < Direction.Up Or Dir > Direction.Right Then Exit Sub

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

    Sub Packet_PlayerDirection(ByVal Index As Integer, ByVal Data() As Byte)
        Dim dir As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CPlayerDir Then Exit Sub

        If TempPlayer(Index).GettingMap = True Then Exit Sub

        dir = Buffer.ReadInteger
        Buffer = Nothing

        ' Prevent hacking
        If dir < Direction.Up Or dir > Direction.Right Then Exit Sub

        SetPlayerDir(Index, dir)

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPlayerDir)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(GetPlayerDir(Index))
        SendDataToMapBut(Index, GetPlayerMap(Index), Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub Packet_UseItem(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim invnum As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CUseItem Then Exit Sub

        invnum = Buffer.ReadInteger
        Buffer = Nothing

        UseItem(Index, invnum)
    End Sub

    Sub Packet_Attack(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Integer ', Shoot As Boolean
        Dim TempIndex As Integer
        Dim x As Integer, y As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CAttack Then Exit Sub

        ' can't attack whilst casting
        If TempPlayer(Index).SkillBuffer > 0 Then Exit Sub

        ' can't attack whilst stunned
        If TempPlayer(Index).StunDuration > 0 Then Exit Sub

        ' Send this packet so they can see the person attacking
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SAttack)
        Buffer.WriteInteger(Index)
        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray)
        Buffer = Nothing

        ' Projectile check
        If GetPlayerEquipment(Index, EquipmentType.Weapon) > 0 Then
            If Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Projectile > 0 Then 'Item has a projectile
                If Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Ammo > 0 Then
                    If HasItem(Index, Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Ammo) Then
                        TakeInvItem(Index, Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Ammo, 1)
                        PlayerFireProjectile(Index)
                        Exit Sub
                    Else
                        PlayerMsg(Index, "No More " & Item(Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Ammo).Name & " !", ColorType.BrightRed)
                        Exit Sub
                    End If
                Else
                    PlayerFireProjectile(Index)
                    Exit Sub
                End If
            End If
        End If

        ' Try to attack a player
        For i = 1 To GetTotalPlayersOnline()
            TempIndex = i

            ' Make sure we dont try to attack ourselves
            If TempIndex <> Index Then
                If IsPlaying(TempIndex) Then
                    TryPlayerAttackPlayer(Index, i)
                End If
            End If
        Next

        ' Try to attack a npc
        For i = 1 To MAX_MAP_NPCS
            TryPlayerAttackNpc(Index, i)
        Next

        ' Check tradeskills
        Select Case GetPlayerDir(Index)
            Case Direction.Up

                If GetPlayerY(Index) = 0 Then Exit Sub
                x = GetPlayerX(Index)
                y = GetPlayerY(Index) - 1
            Case Direction.Down

                If GetPlayerY(Index) = Map(GetPlayerMap(Index)).MaxY Then Exit Sub
                x = GetPlayerX(Index)
                y = GetPlayerY(Index) + 1
            Case Direction.Left

                If GetPlayerX(Index) = 0 Then Exit Sub
                x = GetPlayerX(Index) - 1
                y = GetPlayerY(Index)
            Case Direction.Right

                If GetPlayerX(Index) = Map(GetPlayerMap(Index)).MaxX Then Exit Sub
                x = GetPlayerX(Index) + 1
                y = GetPlayerY(Index)
        End Select

        CheckResource(Index, x, y)

        Buffer = Nothing
    End Sub

    Sub Packet_PlayerInfo(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Integer, n As Integer
        Dim name As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CPlayerInfoRequest Then Exit Sub
        name = Buffer.ReadString
        i = FindPlayer(name)

        If i > 0 Then
            PlayerMsg(Index, "Account: " & Trim$(Player(i).Login) & ", Name: " & GetPlayerName(i), ColorType.Yellow)

            If GetPlayerAccess(Index) > AdminType.Monitor Then
                PlayerMsg(Index, "-=- Stats for " & GetPlayerName(i) & " -=-", ColorType.Yellow)
                PlayerMsg(Index, "Level: " & GetPlayerLevel(i) & "  Exp: " & GetPlayerExp(i) & "/" & GetPlayerNextLevel(i), ColorType.Yellow)
                PlayerMsg(Index, "HP: " & GetPlayerVital(i, Vitals.HP) & "/" & GetPlayerMaxVital(i, Vitals.HP) & "  MP: " & GetPlayerVital(i, Vitals.MP) & "/" & GetPlayerMaxVital(i, Vitals.MP) & "  SP: " & GetPlayerVital(i, Vitals.SP) & "/" & GetPlayerMaxVital(i, Vitals.SP), ColorType.Yellow)
                PlayerMsg(Index, "Strength: " & GetPlayerStat(i, Stats.Strength) & "  Defense: " & GetPlayerStat(i, Stats.Endurance) & "  Magic: " & GetPlayerStat(i, Stats.Intelligence) & "  Speed: " & GetPlayerStat(i, Stats.Spirit), ColorType.Yellow)
                n = (GetPlayerStat(i, Stats.Strength) \ 2) + (GetPlayerLevel(i) \ 2)
                i = (GetPlayerStat(i, Stats.Endurance) \ 2) + (GetPlayerLevel(i) \ 2)

                If n > 100 Then n = 100
                If i > 100 Then i = 100
                PlayerMsg(Index, "Critical Hit Chance: " & n & "%, Block Chance: " & i & "%", ColorType.Yellow)
            End If

        Else
            PlayerMsg(Index, "Player is not online.", ColorType.BrightRed)
        End If

        Buffer = Nothing
    End Sub

    Sub Packet_WarpMeTo(ByVal Index As Integer, ByVal Data() As Byte)
        Dim n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CWarpMeTo Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then
            Exit Sub
        End If

        ' The player
        n = FindPlayer(Buffer.ReadString) 'Parse(1))
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                PlayerWarp(Index, GetPlayerMap(n), GetPlayerX(n), GetPlayerY(n))
                PlayerMsg(n, GetPlayerName(Index) & " has warped to you.", ColorType.Yellow)
                PlayerMsg(Index, "You have been warped to " & GetPlayerName(n) & ".", ColorType.Yellow)
                Addlog(GetPlayerName(Index) & " has warped to " & GetPlayerName(n) & ", map #" & GetPlayerMap(n) & ".", ADMIN_LOG)
            Else
                PlayerMsg(Index, "Player is not online.", ColorType.BrightRed)
            End If

        Else
            PlayerMsg(Index, "You cannot warp to yourself, dumbass!", ColorType.BrightRed)
        End If

    End Sub

    ' :::::::::::::::::::::::
    ' :: Warp to me packet ::
    ' :::::::::::::::::::::::
    Sub Packet_WarpToMe(ByVal Index As Integer, ByVal Data() As Byte)
        Dim n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CWarpToMe Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then Exit Sub

        ' The player
        n = FindPlayer(Buffer.ReadString)
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                PlayerWarp(n, GetPlayerMap(Index), GetPlayerX(Index), GetPlayerY(Index))
                PlayerMsg(n, "You have been summoned by " & GetPlayerName(Index) & ".", ColorType.Yellow)
                PlayerMsg(Index, GetPlayerName(n) & " has been summoned.", ColorType.Yellow)
                Addlog(GetPlayerName(Index) & " has warped " & GetPlayerName(n) & " to self, map #" & GetPlayerMap(Index) & ".", ADMIN_LOG)
            Else
                PlayerMsg(Index, "Player is not online.", ColorType.BrightRed)
            End If

        Else
            PlayerMsg(Index, "You cannot warp yourself to yourself, dumbass!", ColorType.BrightRed)
        End If

    End Sub

    Sub Packet_WarpTo(ByVal Index As Integer, ByVal Data() As Byte)
        Dim n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CWarpTo Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then Exit Sub

        ' The map
        n = Buffer.ReadInteger
        Buffer = Nothing

        ' Prevent hacking
        If n < 0 Or n > MAX_CACHED_MAPS Then Exit Sub

        PlayerWarp(Index, n, GetPlayerX(Index), GetPlayerY(Index))
        PlayerMsg(Index, "You have been warped to map #" & n, ColorType.Yellow)
        Addlog(GetPlayerName(Index) & " warped to map #" & n & ".", ADMIN_LOG)

    End Sub

    Sub Packet_SetSprite(ByVal Index As Integer, ByVal Data() As Byte)
        Dim n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CSetSprite Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then
            Exit Sub
        End If

        ' The sprite
        n = Buffer.ReadInteger 'CLng(Parse(1))
        Buffer = Nothing
        Call SetPlayerSprite(Index, n)
        Call SendPlayerData(Index)
        Exit Sub
    End Sub

    Sub Packet_GetStats(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Integer
        Dim n As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CGetStats Then Exit Sub

        PlayerMsg(Index, "-=- Stats for " & GetPlayerName(Index) & " -=-", ColorType.Yellow)
        PlayerMsg(Index, "Level: " & GetPlayerLevel(Index) & "  Exp: " & GetPlayerExp(Index) & "/" & GetPlayerNextLevel(Index), ColorType.Yellow)
        PlayerMsg(Index, "HP: " & GetPlayerVital(Index, Vitals.HP) & "/" & GetPlayerMaxVital(Index, Vitals.HP) & "  MP: " & GetPlayerVital(Index, Vitals.MP) & "/" & GetPlayerMaxVital(Index, Vitals.MP) & "  SP: " & GetPlayerVital(Index, Vitals.SP) & "/" & GetPlayerMaxVital(Index, Vitals.SP), ColorType.Yellow)
        PlayerMsg(Index, "STR: " & GetPlayerStat(Index, Stats.Strength) & "  DEF: " & GetPlayerStat(Index, Stats.Endurance) & "  MAGI: " & GetPlayerStat(Index, Stats.Intelligence) & "  Speed: " & GetPlayerStat(Index, Stats.Spirit), ColorType.Yellow)
        n = (GetPlayerStat(Index, Stats.Strength) \ 2) + (GetPlayerLevel(Index) \ 2)
        i = (GetPlayerStat(Index, Stats.Endurance) \ 2) + (GetPlayerLevel(Index) \ 2)

        If n > 100 Then n = 100
        If i > 100 Then i = 100
        PlayerMsg(Index, "Critical Hit Chance: " & n & "%, Block Chance: " & i & "%", ColorType.Yellow)
        Buffer = Nothing
    End Sub

    Sub Packet_RequestNewMap(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim dir As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CRequestNewMap Then Exit Sub
        dir = Buffer.ReadInteger
        Buffer = Nothing

        ' Prevent hacking
        If dir < Direction.Up Or dir > Direction.Right Then Exit Sub

        'Debug.Print("Server-RequestNewMap")

        PlayerMove(Index, dir, 1, True)
        Buffer = Nothing
    End Sub

    ' :::::::::::::::::::::
    ' :: Map data packet ::
    ' :::::::::::::::::::::
    Sub Packet_MapData(ByVal Index As Integer, ByVal Data() As Byte)
        Dim i As Integer
        Dim MapNum As Integer
        Dim x As Integer
        Dim y As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CSaveMap Then Exit Sub

        Data = Buffer.ReadBytes(Data.Length - 4)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(ArchaicIO.Compression.Decompress(Data))

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then Exit Sub

        Gettingmap = True

        MapNum = GetPlayerMap(Index)

        i = Map(MapNum).Revision + 1
        ClearMap(MapNum)

        Map(MapNum).Name = Buffer.ReadString
        Map(MapNum).Music = Buffer.ReadString
        Map(MapNum).Revision = i
        Map(MapNum).Moral = Buffer.ReadInteger
        Map(MapNum).Tileset = Buffer.ReadInteger
        Map(MapNum).Up = Buffer.ReadInteger
        Map(MapNum).Down = Buffer.ReadInteger
        Map(MapNum).Left = Buffer.ReadInteger
        Map(MapNum).Right = Buffer.ReadInteger
        Map(MapNum).BootMap = Buffer.ReadInteger
        Map(MapNum).BootX = Buffer.ReadInteger
        Map(MapNum).BootY = Buffer.ReadInteger
        Map(MapNum).MaxX = Buffer.ReadInteger
        Map(MapNum).MaxY = Buffer.ReadInteger
        Map(MapNum).WeatherType = Buffer.ReadInteger
        Map(MapNum).FogIndex = Buffer.ReadInteger
        Map(MapNum).WeatherIntensity = Buffer.ReadInteger
        Map(MapNum).FogAlpha = Buffer.ReadInteger
        Map(MapNum).FogSpeed = Buffer.ReadInteger
        Map(MapNum).HasMapTint = Buffer.ReadInteger
        Map(MapNum).MapTintR = Buffer.ReadInteger
        Map(MapNum).MapTintG = Buffer.ReadInteger
        Map(MapNum).MapTintB = Buffer.ReadInteger
        Map(MapNum).MapTintA = Buffer.ReadInteger

        Map(MapNum).Instanced = Buffer.ReadInteger
        Map(MapNum).Panorama = Buffer.ReadInteger
        Map(MapNum).Parallax = Buffer.ReadInteger

        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, MapNum)
            Map(MapNum).Npc(x) = Buffer.ReadInteger
        Next

        With Map(MapNum)
            For x = 0 To .MaxX
                For y = 0 To .MaxY
                    .Tile(x, y).Data1 = Buffer.ReadInteger
                    .Tile(x, y).Data2 = Buffer.ReadInteger
                    .Tile(x, y).Data3 = Buffer.ReadInteger
                    .Tile(x, y).DirBlock = Buffer.ReadInteger
                    ReDim .Tile(x, y).Layer(0 To MapLayer.Count - 1)
                    For i = 0 To MapLayer.Count - 1
                        .Tile(x, y).Layer(i).Tileset = Buffer.ReadInteger
                        .Tile(x, y).Layer(i).X = Buffer.ReadInteger
                        .Tile(x, y).Layer(i).Y = Buffer.ReadInteger
                        .Tile(x, y).Layer(i).AutoTile = Buffer.ReadInteger
                    Next
                    .Tile(x, y).Type = Buffer.ReadInteger
                Next
            Next

        End With

        'Event Data!
        Map(MapNum).EventCount = Buffer.ReadInteger

        If Map(MapNum).EventCount > 0 Then
            ReDim Map(MapNum).Events(0 To Map(MapNum).EventCount)
            For i = 1 To Map(MapNum).EventCount
                With Map(MapNum).Events(i)
                    .Name = Buffer.ReadString
                    .Globals = Buffer.ReadInteger
                    .X = Buffer.ReadInteger
                    .Y = Buffer.ReadInteger
                    .PageCount = Buffer.ReadInteger
                End With
                If Map(MapNum).Events(i).PageCount > 0 Then
                    ReDim Map(MapNum).Events(i).Pages(0 To Map(MapNum).Events(i).PageCount)
                    ReDim TempPlayer(i).EventMap.EventPages(0 To Map(MapNum).Events(i).PageCount)
                    For x = 1 To Map(MapNum).Events(i).PageCount
                        With Map(MapNum).Events(i).Pages(x)
                            .chkVariable = Buffer.ReadInteger
                            .VariableIndex = Buffer.ReadInteger
                            .VariableCondition = Buffer.ReadInteger
                            .VariableCompare = Buffer.ReadInteger

                            Map(MapNum).Events(i).Pages(x).chkSwitch = Buffer.ReadInteger
                            Map(MapNum).Events(i).Pages(x).SwitchIndex = Buffer.ReadInteger
                            .SwitchCompare = Buffer.ReadInteger

                            .chkHasItem = Buffer.ReadInteger
                            .HasItemIndex = Buffer.ReadInteger
                            .HasItemAmount = Buffer.ReadInteger

                            .chkSelfSwitch = Buffer.ReadInteger
                            .SelfSwitchIndex = Buffer.ReadInteger
                            .SelfSwitchCompare = Buffer.ReadInteger

                            .GraphicType = Buffer.ReadInteger
                            .Graphic = Buffer.ReadInteger
                            .GraphicX = Buffer.ReadInteger
                            .GraphicY = Buffer.ReadInteger
                            .GraphicX2 = Buffer.ReadInteger
                            .GraphicY2 = Buffer.ReadInteger

                            .MoveType = Buffer.ReadInteger
                            .MoveSpeed = Buffer.ReadInteger
                            .MoveFreq = Buffer.ReadInteger

                            .MoveRouteCount = Buffer.ReadInteger

                            .IgnoreMoveRoute = Buffer.ReadInteger
                            .RepeatMoveRoute = Buffer.ReadInteger

                            If .MoveRouteCount > 0 Then
                                ReDim Map(MapNum).Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = Buffer.ReadInteger
                                    .MoveRoute(y).Data1 = Buffer.ReadInteger
                                    .MoveRoute(y).Data2 = Buffer.ReadInteger
                                    .MoveRoute(y).Data3 = Buffer.ReadInteger
                                    .MoveRoute(y).Data4 = Buffer.ReadInteger
                                    .MoveRoute(y).Data5 = Buffer.ReadInteger
                                    .MoveRoute(y).Data6 = Buffer.ReadInteger
                                Next
                            End If

                            .WalkAnim = Buffer.ReadInteger
                            .DirFix = Buffer.ReadInteger
                            .WalkThrough = Buffer.ReadInteger
                            .ShowName = Buffer.ReadInteger
                            .Trigger = Buffer.ReadInteger
                            .CommandListCount = Buffer.ReadInteger

                            .Position = Buffer.ReadInteger
                            .QuestNum = Buffer.ReadInteger

                            .chkPlayerGender = Buffer.ReadInteger
                        End With

                        If Map(MapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map(MapNum).Events(i).Pages(x).CommandList(0 To Map(MapNum).Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map(MapNum).Events(i).Pages(x).CommandListCount
                                Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount = Buffer.ReadInteger
                                Map(MapNum).Events(i).Pages(x).CommandList(y).ParentList = Buffer.ReadInteger
                                If Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(0 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 1 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = Buffer.ReadInteger
                                            .Text1 = Buffer.ReadString
                                            .Text2 = Buffer.ReadString
                                            .Text3 = Buffer.ReadString
                                            .Text4 = Buffer.ReadString
                                            .Text5 = Buffer.ReadString
                                            .Data1 = Buffer.ReadInteger
                                            .Data2 = Buffer.ReadInteger
                                            .Data3 = Buffer.ReadInteger
                                            .Data4 = Buffer.ReadInteger
                                            .Data5 = Buffer.ReadInteger
                                            .Data6 = Buffer.ReadInteger
                                            .ConditionalBranch.CommandList = Buffer.ReadInteger
                                            .ConditionalBranch.Condition = Buffer.ReadInteger
                                            .ConditionalBranch.Data1 = Buffer.ReadInteger
                                            .ConditionalBranch.Data2 = Buffer.ReadInteger
                                            .ConditionalBranch.Data3 = Buffer.ReadInteger
                                            .ConditionalBranch.ElseCommandList = Buffer.ReadInteger
                                            .MoveRouteCount = Buffer.ReadInteger
                                            Dim tmpcount As Integer = .MoveRouteCount
                                            If tmpcount > 0 Then
                                                ReDim Preserve .MoveRoute(tmpcount)
                                                For w = 1 To tmpcount
                                                    .MoveRoute(w).Index = Buffer.ReadInteger
                                                    .MoveRoute(w).Data1 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data2 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data3 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data4 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data5 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data6 = Buffer.ReadInteger
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

        For i = 1 To GetTotalPlayersOnline()
            If IsPlaying(i) Then
                If Player(i).Character(TempPlayer(i).CurChar).Map = MapNum Then
                    SpawnMapEventsFor(i, MapNum)
                End If
            End If
        Next

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), MapItem(GetPlayerMap(Index), i).X, MapItem(GetPlayerMap(Index), i).Y)
            ClearMapItem(i, GetPlayerMap(Index))
        Next

        ' Respawn
        SpawnMapItems(GetPlayerMap(Index))

        ClearTempTile(MapNum)
        CacheResources(MapNum)

        ' Refresh map for everyone online
        For i = 1 To GetTotalPlayersOnline()
            If IsPlaying(i) And GetPlayerMap(i) = MapNum Then
                PlayerWarp(i, MapNum, GetPlayerX(i), GetPlayerY(i))
                ' Send map
                SendMapData(i, MapNum, True)
            End If
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_NeedMap(ByVal index As Integer, ByVal data() As Byte)
        Dim s As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CNeedMap Then Exit Sub

        ' Get yes/no value
        s = Buffer.ReadInteger
        Buffer = Nothing

        ' Check if map data is needed to be sent
        If s = 1 Then
            SendMapData(index, GetPlayerMap(index), True)
        Else
            SendMapData(index, GetPlayerMap(index), False)
        End If

        SpawnMapEventsFor(index, GetPlayerMap(index))
        SendJoinMap(index)
        TempPlayer(index).GettingMap = False
    End Sub

    Private Sub Packet_GetItem(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CMapGetItem Then Exit Sub

        PlayerMapGetItem(index)

        Buffer = Nothing
    End Sub

    Private Sub Packet_DropItem(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim InvNum As Integer, Amount As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadInteger <> ClientPackets.CMapDropItem Then Exit Sub
        InvNum = Buffer.ReadInteger
        Amount = Buffer.ReadInteger
        Buffer = Nothing

        If TempPlayer(index).InBank Or TempPlayer(index).InShop Then Exit Sub

        ' Prevent hacking
        If InvNum < 1 Or InvNum > MAX_INV Then Exit Sub
        If GetPlayerInvItemNum(index, InvNum) < 1 Or GetPlayerInvItemNum(index, InvNum) > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(index, InvNum)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(index, InvNum)).Stackable = 1 Then
            If Amount < 1 Or Amount > GetPlayerInvItemValue(index, InvNum) Then Exit Sub
        End If

        ' everything worked out fine
        Call PlayerMapDropItem(index, InvNum, Amount)
    End Sub

    Sub Packet_RespawnMap(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CMapRespawn Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then
            Exit Sub
        End If

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            Call SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), MapItem(GetPlayerMap(Index), i).X, MapItem(GetPlayerMap(Index), i).Y)
            Call ClearMapItem(i, GetPlayerMap(Index))
        Next

        ' Respawn
        Call SpawnMapItems(GetPlayerMap(Index))

        ' Respawn NPCS
        For i = 1 To MAX_MAP_NPCS
            Call SpawnNpc(i, GetPlayerMap(Index))
        Next

        CacheResources(GetPlayerMap(Index))
        Call PlayerMsg(Index, "Map respawned.", ColorType.BrightGreen)
        Call Addlog(GetPlayerName(Index) & " has respawned map #" & GetPlayerMap(Index), ADMIN_LOG)

        Buffer = Nothing
    End Sub

    ' ::::::::::::::::::::::::
    ' :: Kick player packet ::
    ' ::::::::::::::::::::::::
    Sub Packet_KickPlayer(ByVal Index As Integer, ByVal Data() As Byte)
        Dim n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CKickPlayer Then Exit Sub

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
                    GlobalMsg(GetPlayerName(n) & " has been kicked from " & Options.GameName & " by " & GetPlayerName(Index) & "!")
                    Addlog(GetPlayerName(Index) & " has kicked " & GetPlayerName(n) & ".", ADMIN_LOG)
                    AlertMsg(n, "You have been kicked by " & GetPlayerName(Index) & "!")
                Else
                    PlayerMsg(Index, "That is a higher or same access admin then you!", ColorType.BrightRed)
                End If

            Else
                PlayerMsg(Index, "Player is not online.", ColorType.BrightRed)
            End If

        Else
            PlayerMsg(Index, "You cannot kick yourself!", ColorType.BrightRed)
        End If
    End Sub

    Sub Packet_Banlist(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CBanList Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then
            Exit Sub
        End If

        PlayerMsg(Index, "Command /banlist is not available in Orion+... yet ;)", ColorType.Yellow)

        Buffer = Nothing
    End Sub

    Sub Packet_DestroyBans(ByVal Index As Integer, ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim filename As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CBanDestroy Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Creator Then
            Exit Sub
        End If

        filename = Path.Combine(Application.StartupPath, "data", "banlist.txt")

        If System.IO.File.Exists(filename) Then Kill(filename)

        PlayerMsg(Index, "Ban list destroyed.", ColorType.BrightGreen)

        Buffer = Nothing
    End Sub

    ' :::::::::::::::::::::::
    ' :: Ban player packet ::
    ' :::::::::::::::::::::::
    Sub Packet_BanPlayer(ByVal Index As Integer, ByVal Data() As Byte)
        Dim n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ClientPackets.CBanPlayer Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then
            Exit Sub
        End If

        ' The player index
        n = FindPlayer(Buffer.ReadString)
        Buffer = Nothing

        If n <> Index Then
            If n > 0 Then
                If GetPlayerAccess(n) < GetPlayerAccess(Index) Then
                    BanIndex(n, Index)
                Else
                    PlayerMsg(Index, "That is a higher or same access admin then you!", ColorType.BrightRed)
                End If

            Else
                PlayerMsg(Index, "Player is not online.", ColorType.BrightRed)
            End If

        Else
            PlayerMsg(Index, "You cannot ban yourself, dumbass!", ColorType.BrightRed)
        End If

    End Sub

    Private Sub Packet_EditMapRequest(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CRequestEditMap Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        If GetPlayerMap(index) > MAX_MAPS Then
            PlayerMsg(index, "Cant edit instanced maps!", ColorType.BrightRed)
            Exit Sub
        End If
        SendMapEventData(index)

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SEditMap)
        SendDataTo(index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Private Sub Packet_EditItem(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.RequestEditItem Then Exit Sub
        Buffer = Nothing

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then
            Exit Sub
        End If

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SItemEditor)
        SendDataTo(index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Private Sub Packet_SaveItem(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim n As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.SaveItem Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        n = Buffer.ReadInteger

        If n < 0 Or n > MAX_ITEMS Then
            Exit Sub
        End If

        ' Update the item
        Item(n).AccessReq = Buffer.ReadInteger()

        For i = 0 To Stats.Count - 1
            Item(n).Add_Stat(i) = Buffer.ReadInteger()
        Next

        Item(n).Animation = Buffer.ReadInteger()
        Item(n).BindType = Buffer.ReadInteger()
        Item(n).ClassReq = Buffer.ReadInteger()
        Item(n).Data1 = Buffer.ReadInteger()
        Item(n).Data2 = Buffer.ReadInteger()
        Item(n).Data3 = Buffer.ReadInteger()
        Item(n).TwoHanded = Buffer.ReadInteger()
        Item(n).LevelReq = Buffer.ReadInteger()
        Item(n).Mastery = Buffer.ReadInteger()
        Item(n).Name = Trim$(Buffer.ReadString)
        Item(n).Paperdoll = Buffer.ReadInteger()
        Item(n).Pic = Buffer.ReadInteger()
        Item(n).Price = Buffer.ReadInteger()
        Item(n).Rarity = Buffer.ReadInteger()
        Item(n).Speed = Buffer.ReadInteger()

        Item(n).Randomize = Buffer.ReadInteger()
        Item(n).RandomMin = Buffer.ReadInteger()
        Item(n).RandomMax = Buffer.ReadInteger()

        Item(n).Stackable = Buffer.ReadInteger()
        Item(n).Description = Trim$(Buffer.ReadString)

        For i = 0 To Stats.Count - 1
            Item(n).Stat_Req(i) = Buffer.ReadInteger()
        Next

        Item(n).Type = Buffer.ReadInteger()
        Item(n).SubType = Buffer.ReadInteger

        Item(n).ItemLevel = Buffer.ReadInteger

        'Housing
        Item(n).FurnitureWidth = Buffer.ReadInteger()
        Item(n).FurnitureHeight = Buffer.ReadInteger()

        For a = 1 To 3
            For b = 1 To 3
                Item(n).FurnitureBlocks(a, b) = Buffer.ReadInteger()
                Item(n).FurnitureFringe(a, b) = Buffer.ReadInteger()
            Next
        Next

        Item(n).KnockBack = Buffer.ReadInteger()
        Item(n).KnockBackTiles = Buffer.ReadInteger()

        Item(n).Projectile = Buffer.ReadInteger()
        Item(n).Ammo = Buffer.ReadInteger()

        ' Save it
        SendUpdateItemToAll(n)
        SaveItem(n)
        Addlog(GetPlayerLogin(index) & " saved item #" & n & ".", ADMIN_LOG)
        Buffer = Nothing
    End Sub

    Sub Packet_EditNpc(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.RequestEditNpc Then Exit Sub
        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SNpcEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveNPC(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim NpcNum As Integer, i As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.SaveNpc Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then
            Exit Sub
        End If

        NpcNum = buffer.ReadInteger

        ' Update the Npc
        Npc(NpcNum).Animation = buffer.ReadInteger()
        Npc(NpcNum).AttackSay = buffer.ReadString()
        Npc(NpcNum).Behaviour = buffer.ReadInteger()
        For i = 1 To 5
            Npc(NpcNum).DropChance(i) = buffer.ReadInteger()
            Npc(NpcNum).DropItem(i) = buffer.ReadInteger()
            Npc(NpcNum).DropItemValue(i) = buffer.ReadInteger()
        Next

        Npc(NpcNum).Exp = buffer.ReadInteger()
        Npc(NpcNum).Faction = buffer.ReadInteger()
        Npc(NpcNum).Hp = buffer.ReadInteger()
        Npc(NpcNum).Name = buffer.ReadString()
        Npc(NpcNum).Range = buffer.ReadInteger()
        Npc(NpcNum).SpawnSecs = buffer.ReadInteger()
        Npc(NpcNum).Sprite = buffer.ReadInteger()

        For i = 0 To Stats.Count - 1
            Npc(NpcNum).Stat(i) = buffer.ReadInteger()
        Next

        Npc(NpcNum).QuestNum = buffer.ReadInteger()

        For i = 1 To MAX_NPC_SKILLS
            Npc(NpcNum).Skill(i) = buffer.ReadInteger()
        Next

        Npc(NpcNum).Level = buffer.ReadInteger()
        Npc(NpcNum).Damage = buffer.ReadInteger()

        ' Save it
        SendUpdateNpcToAll(NpcNum)
        SaveNpc(NpcNum)
        Addlog(GetPlayerLogin(index) & " saved Npc #" & NpcNum & ".", ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_EditShop(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.RequestEditShop Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SShopEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveShop(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim ShopNum As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.SaveShop Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then
            Exit Sub
        End If

        ShopNum = buffer.ReadInteger

        ' Prevent hacking
        If ShopNum < 0 Or ShopNum > MAX_SHOPS Then
            Exit Sub
        End If

        Shop(ShopNum).BuyRate = buffer.ReadInteger()
        Shop(ShopNum).Name = buffer.ReadString()
        Shop(ShopNum).Face = buffer.ReadInteger()

        For i = 0 To MAX_TRADES
            Shop(ShopNum).TradeItem(i).CostItem = buffer.ReadInteger()
            Shop(ShopNum).TradeItem(i).CostValue = buffer.ReadInteger()
            Shop(ShopNum).TradeItem(i).Item = buffer.ReadInteger()
            Shop(ShopNum).TradeItem(i).ItemValue = buffer.ReadInteger()
        Next

        If Shop(ShopNum).Name Is Nothing Then Shop(ShopNum).Name = ""

        buffer = Nothing
        ' Save it
        Call SendUpdateShopToAll(ShopNum)
        Call SaveShop(ShopNum)
        Call Addlog(GetPlayerLogin(index) & " saving shop #" & ShopNum & ".", ADMIN_LOG)
    End Sub

    Sub Packet_EditSkill(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.RequestEditSkill Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SSkillEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveSkill(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim skillnum As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.SaveSkill Then Exit Sub

        skillnum = buffer.ReadInteger

        ' Prevent hacking
        If skillnum < 0 Or skillnum > MAX_SKILLS Then
            Exit Sub
        End If

        Skill(skillnum).AccessReq = buffer.ReadInteger()
        Skill(skillnum).AoE = buffer.ReadInteger()
        Skill(skillnum).CastAnim = buffer.ReadInteger()
        Skill(skillnum).CastTime = buffer.ReadInteger()
        Skill(skillnum).CdTime = buffer.ReadInteger()
        Skill(skillnum).ClassReq = buffer.ReadInteger()
        Skill(skillnum).Dir = buffer.ReadInteger()
        Skill(skillnum).Duration = buffer.ReadInteger()
        Skill(skillnum).Icon = buffer.ReadInteger()
        Skill(skillnum).Interval = buffer.ReadInteger()
        Skill(skillnum).IsAoE = buffer.ReadInteger()
        Skill(skillnum).LevelReq = buffer.ReadInteger()
        Skill(skillnum).Map = buffer.ReadInteger()
        Skill(skillnum).MpCost = buffer.ReadInteger()
        Skill(skillnum).Name = buffer.ReadString()
        Skill(skillnum).range = buffer.ReadInteger()
        Skill(skillnum).SkillAnim = buffer.ReadInteger()
        Skill(skillnum).StunDuration = buffer.ReadInteger()
        Skill(skillnum).Type = buffer.ReadInteger()
        Skill(skillnum).Vital = buffer.ReadInteger()
        Skill(skillnum).X = buffer.ReadInteger()
        Skill(skillnum).Y = buffer.ReadInteger()

        'projectiles
        Skill(skillnum).IsProjectile = buffer.ReadInteger()
        Skill(skillnum).Projectile = buffer.ReadInteger()

        Skill(skillnum).KnockBack = buffer.ReadInteger()
        Skill(skillnum).KnockBackTiles = buffer.ReadInteger()

        ' Save it
        SendUpdateSkillToAll(skillnum)
        SaveSkill(skillnum)
        Addlog(GetPlayerLogin(index) & " saved Skill #" & skillnum & ".", ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_SetAccess(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CSetAccess Then Exit Sub
        Dim n As Integer
        Dim i As Integer

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Creator Then Exit Sub

        ' The index
        n = FindPlayer(buffer.ReadString)
        ' The access
        i = buffer.ReadInteger

        ' Check for invalid access level
        If i >= 0 Or i <= 3 Then

            ' Check if player is on
            If n > 0 Then

                'check to see if same level access is trying to change another access of the very same level and boot them if they are.
                If GetPlayerAccess(n) = GetPlayerAccess(index) Then
                    PlayerMsg(index, "Invalid access level.", ColorType.BrightRed)
                    Exit Sub
                End If

                If GetPlayerAccess(n) <= 0 Then
                    GlobalMsg(GetPlayerName(n) & " has been blessed with administrative access.")
                End If

                SetPlayerAccess(n, i)
                SendPlayerData(n)
                Addlog(GetPlayerName(index) & " has modified " & GetPlayerName(n) & "'s access.", ADMIN_LOG)
            Else
                PlayerMsg(index, "Player is not online.", ColorType.BrightRed)
            End If

        Else
            PlayerMsg(index, "Invalid access level.", ColorType.BrightRed)
        End If

        buffer = Nothing
    End Sub

    Sub Packet_WhosOnline(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CWhosOnline Then Exit Sub

        SendWhosOnline(index)

        buffer = Nothing
    End Sub

    Sub Packet_SetMotd(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CSetMotd Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then
            Exit Sub
        End If

        Options.Motd = Trim$(buffer.ReadString)
        SaveOptions()

        GlobalMsg("MOTD changed to: " & Options.Motd)
        Addlog(GetPlayerName(index) & " changed MOTD to: " & Options.Motd, ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_PlayerSearch(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer, TargetFound As Byte, rclick As Byte
        Dim x As Integer, y As Integer, i As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CSearch Then Exit Sub

        x = buffer.ReadInteger
        y = buffer.ReadInteger
        rclick = buffer.ReadInteger

        ' Prevent subscript out of range
        If x < 0 Or x > Map(GetPlayerMap(index)).MaxX Or y < 0 Or y > Map(GetPlayerMap(index)).MaxY Then Exit Sub

        ' Check for a player
        For i = 1 To GetTotalPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(index) = GetPlayerMap(i) Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then

                            ' Consider the player
                            If i <> index Then
                                If GetPlayerLevel(i) >= GetPlayerLevel(index) + 5 Then
                                    PlayerMsg(index, "You wouldn't stand a chance.", ColorType.BrightRed)
                                Else

                                    If GetPlayerLevel(i) > GetPlayerLevel(index) Then
                                        PlayerMsg(index, "This one seems to have an advantage over you.", ColorType.Yellow)
                                    Else

                                        If GetPlayerLevel(i) = GetPlayerLevel(index) Then
                                            PlayerMsg(index, "This would be an even fight.", ColorType.White)
                                        Else

                                            If GetPlayerLevel(index) >= GetPlayerLevel(i) + 5 Then
                                                PlayerMsg(index, "You could slaughter that player.", ColorType.BrightBlue)
                                            Else

                                                If GetPlayerLevel(index) > GetPlayerLevel(i) Then
                                                    PlayerMsg(index, "You would have an advantage over that player.", ColorType.BrightCyan)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            ' Change target
                            TempPlayer(index).Target = i
                            TempPlayer(index).TargetType = TargetType.Player
                            PlayerMsg(index, "Your target is now " & GetPlayerName(i) & ".", ColorType.Yellow)
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
                If MapItem(GetPlayerMap(index), i).X = x Then
                    If MapItem(GetPlayerMap(index), i).Y = y Then
                        PlayerMsg(index, "You see " & CheckGrammar(Trim$(Item(MapItem(GetPlayerMap(index), i).Num).Name)) & ".", ColorType.White)
                        Exit Sub
                    End If
                End If
            End If

        Next

        ' Check for an npc
        For i = 1 To MAX_MAP_NPCS

            If MapNpc(GetPlayerMap(index)).Npc(i).Num > 0 Then
                If MapNpc(GetPlayerMap(index)).Npc(i).X = x Then
                    If MapNpc(GetPlayerMap(index)).Npc(i).Y = y Then
                        ' Change target
                        TempPlayer(index).Target = i
                        TempPlayer(index).TargetType = TargetType.Npc
                        PlayerMsg(index, "Your target is now " & CheckGrammar(Trim$(Npc(MapNpc(GetPlayerMap(index)).Npc(i).Num).Name)) & ".", ColorType.Yellow)
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
                                        PlayerMsg(index, "No inventory space available!", ColorType.BrightRed)
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

    Sub Packet_Skills(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CSkills Then Exit Sub

        SendPlayerSkills(index)

        buffer = Nothing
    End Sub

    Sub Packet_Cast(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CCast Then Exit Sub

        ' Skill slot
        n = buffer.ReadInteger
        buffer = Nothing

        ' set the skill buffer before castin
        BufferSkill(index, n)

        buffer = Nothing
    End Sub

    Sub Packet_QuitGame(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CQuit Then Exit Sub

        SendLeftGame(index)
        CloseSocket(index)

        buffer = Nothing
    End Sub

    Sub Packet_SwapInvSlots(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim oldSlot As Integer, newSlot As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CSwapInvSlots Then Exit Sub

        If TempPlayer(index).InTrade > 0 Or TempPlayer(index).InBank Or TempPlayer(index).InShop Then Exit Sub

        ' Old Slot
        oldSlot = buffer.ReadInteger
        newSlot = buffer.ReadInteger
        buffer = Nothing

        PlayerSwitchInvSlots(index, oldSlot, newSlot)

        buffer = Nothing
    End Sub

    Sub Packet_EditResource(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> EditorPackets.RequestEditResource Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SResourceEditor)
        SendDataTo(index, buffer.ToArray())

        buffer = Nothing
    End Sub

    Sub Packet_SaveResource(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim resourcenum As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> EditorPackets.SaveResource Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        resourcenum = buffer.ReadInteger

        ' Prevent hacking
        If resourcenum < 0 Or resourcenum > MAX_RESOURCES Then Exit Sub

        Resource(resourcenum).Animation = buffer.ReadInteger()
        Resource(resourcenum).EmptyMessage = buffer.ReadString()
        Resource(resourcenum).ExhaustedImage = buffer.ReadInteger()
        Resource(resourcenum).Health = buffer.ReadInteger()
        Resource(resourcenum).ExpReward = buffer.ReadInteger()
        Resource(resourcenum).ItemReward = buffer.ReadInteger()
        Resource(resourcenum).Name = buffer.ReadString()
        Resource(resourcenum).ResourceImage = buffer.ReadInteger()
        Resource(resourcenum).ResourceType = buffer.ReadInteger()
        Resource(resourcenum).RespawnTime = buffer.ReadInteger()
        Resource(resourcenum).SuccessMessage = buffer.ReadString()
        Resource(resourcenum).LvlRequired = buffer.ReadInteger()
        Resource(resourcenum).ToolRequired = buffer.ReadInteger()
        Resource(resourcenum).Walkthrough = buffer.ReadInteger()

        ' Save it
        SendUpdateResourceToAll(resourcenum)
        SaveResource(resourcenum)

        Addlog(GetPlayerLogin(index) & " saved Resource #" & resourcenum & ".", ADMIN_LOG)

        buffer = Nothing
    End Sub

    Sub Packet_CheckPing(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SSendPing)
        SendDataTo(index, buffer.ToArray)
        buffer = Nothing
    End Sub

    Sub Packet_Unequip(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CUnequip Then Exit Sub

        PlayerUnequipItem(index, buffer.ReadInteger)

        buffer = Nothing
    End Sub

    Sub Packet_RequestPlayerData(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestPlayerData Then Exit Sub

        SendPlayerData(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestItems(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestItems Then Exit Sub
        SendItems(index)
        buffer = Nothing
    End Sub

    Sub Packet_RequestNpcs(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestNPCS Then Exit Sub
        SendNpcs(index)
        buffer = Nothing
    End Sub

    Sub Packet_RequestResources(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestResources Then Exit Sub
        SendResources(index)
        buffer = Nothing
    End Sub

    Sub Packet_SpawnItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CSpawnItem Then Exit Sub
        Dim tmpItem As Integer
        Dim tmpAmount As Integer

        ' item
        tmpItem = buffer.ReadInteger
        tmpAmount = buffer.ReadInteger

        If GetPlayerAccess(index) < AdminType.Creator Then Exit Sub

        SpawnItem(tmpItem, tmpAmount, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))
        buffer = Nothing
    End Sub

    Sub Packet_TrainStat(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tmpstat As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CTrainStat Then Exit Sub
        ' check points
        If GetPlayerPOINTS(index) = 0 Then Exit Sub

        ' stat
        tmpstat = buffer.ReadInteger

        ' increment stat
        SetPlayerStat(index, tmpstat, GetPlayerRawStat(index, tmpstat) + 1)

        ' decrement points
        SetPlayerPOINTS(index, GetPlayerPOINTS(index) - 1)

        ' send player new data
        SendPlayerData(index)
        buffer = Nothing
    End Sub

    Sub Packet_EditAnimation(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.RequestEditAnimation Then Exit Sub
        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then
            Exit Sub
        End If

        buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SAnimationEditor)
        SendDataTo(index, buffer.ToArray())
        buffer = Nothing
    End Sub

    Sub Packet_SaveAnimation(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim AnimNum As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> EditorPackets.SaveAnimation Then Exit Sub

        AnimNum = buffer.ReadInteger

        ' Update the Animation
        For i = 0 To UBound(Animation(AnimNum).Frames)
            Animation(AnimNum).Frames(i) = buffer.ReadInteger()
        Next

        For i = 0 To UBound(Animation(AnimNum).LoopCount)
            Animation(AnimNum).LoopCount(i) = buffer.ReadInteger()
        Next

        For i = 0 To UBound(Animation(AnimNum).LoopTime)
            Animation(AnimNum).LoopTime(i) = buffer.ReadInteger()
        Next

        Animation(AnimNum).Name = buffer.ReadString()

        If Animation(AnimNum).Name Is Nothing Then Animation(AnimNum).Name = ""

        For i = 0 To UBound(Animation(AnimNum).Sprite)
            Animation(AnimNum).Sprite(i) = buffer.ReadInteger()
        Next

        buffer = Nothing

        ' Save it
        SaveAnimation(AnimNum)
        SendUpdateAnimationToAll(AnimNum)
        Addlog(GetPlayerLogin(index) & " saved Animation #" & AnimNum & ".", ADMIN_LOG)

    End Sub

    Sub Packet_RequestAnimations(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestAnimations Then Exit Sub

        SendAnimations(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestSkills(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestSkills Then Exit Sub

        SendSkills(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestShops(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestShops Then Exit Sub

        SendShops(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestLevelUp(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestLevelUp Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Creator Then
            Exit Sub
        End If

        SetPlayerExp(index, GetPlayerNextLevel(index))
        CheckPlayerLevelUp(index)

        buffer = Nothing
    End Sub

    Sub Packet_ForgetSkill(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer, skillslot As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CForgetSkill Then Exit Sub

        skillslot = buffer.ReadInteger

        ' Check for subscript out of range
        If skillslot < 1 Or skillslot > MAX_PLAYER_SKILLS Then
            Exit Sub
        End If

        ' dont let them forget a skill which is in CD
        If TempPlayer(index).SkillCD(skillslot) > 0 Then
            PlayerMsg(index, "Cannot forget a skill which is cooling down!", ColorType.BrightRed)
            Exit Sub
        End If

        ' dont let them forget a skill which is buffered
        If TempPlayer(index).SkillBuffer = skillslot Then
            PlayerMsg(index, "Cannot forget a skill which you are casting!", ColorType.BrightRed)
            Exit Sub
        End If

        Player(index).Character(TempPlayer(index).CurChar).Skill(skillslot) = 0
        SendPlayerSkills(index)

        buffer = Nothing
    End Sub

    Sub Packet_CloseShop(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CCloseShop Then Exit Sub

        TempPlayer(index).InShop = 0

        buffer = Nothing
    End Sub

    Sub Packet_BuyItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim shopslot As Integer, shopnum As Integer, itemamount As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CBuyItem Then Exit Sub

        shopslot = buffer.ReadInteger

        ' not in shop, exit out
        shopnum = TempPlayer(index).InShop
        If shopnum < 1 Or shopnum > MAX_SHOPS Then Exit Sub

        With Shop(shopnum).TradeItem(shopslot)
            ' check trade exists
            If .Item < 1 Then Exit Sub

            ' check has the cost item
            itemamount = HasItem(index, .CostItem)
            If itemamount = 0 Or itemamount < .CostValue Then
                PlayerMsg(index, "You do not have enough to buy this item.", ColorType.BrightRed)
                ResetShopAction(index)
                Exit Sub
            End If

            ' it's fine, let's go ahead
            TakeInvItem(index, .CostItem, .CostValue)
            GiveInvItem(index, .Item, .ItemValue)
        End With

        ' send confirmation message & reset their shop action
        PlayerMsg(index, "Trade successful.", ColorType.BrightGreen)
        ResetShopAction(index)

        buffer = Nothing
    End Sub

    Sub Packet_SellItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim invSlot As Integer
        Dim itemNum As Integer
        Dim price As Integer
        Dim multiplier As Double
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CSellItem Then Exit Sub

        invSlot = buffer.ReadInteger

        ' if invalid, exit out
        If invSlot < 1 Or invSlot > MAX_INV Then Exit Sub

        ' has item?
        If GetPlayerInvItemNum(index, invSlot) < 1 Or GetPlayerInvItemNum(index, invSlot) > MAX_ITEMS Then Exit Sub

        ' seems to be valid
        itemNum = GetPlayerInvItemNum(index, invSlot)

        ' work out price
        multiplier = Shop(TempPlayer(index).InShop).BuyRate / 100
        price = Item(itemNum).Price * multiplier

        ' item has cost?
        If price <= 0 Then
            PlayerMsg(index, "The shop doesn't want that item.", ColorType.Yellow)
            ResetShopAction(index)
            Exit Sub
        End If

        ' take item and give gold
        TakeInvItem(index, itemNum, 1)
        GiveInvItem(index, 1, price)

        ' send confirmation message & reset their shop action
        PlayerMsg(index, "Sold the " & Trim(Item(GetPlayerInvItemNum(index, invSlot)).Name) & " !", ColorType.BrightGreen)
        ResetShopAction(index)

        buffer = Nothing
    End Sub

    Sub Packet_ChangeBankSlots(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim oldslot As Integer, newslot As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CChangeBankSlots Then Exit Sub

        oldslot = buffer.ReadInteger
        newslot = buffer.ReadInteger

        PlayerSwitchBankSlots(index, oldslot, newslot)

        buffer = Nothing
    End Sub

    Sub Packet_DepositItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim invslot As Integer, amount As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CDepositItem Then Exit Sub

        invslot = buffer.ReadInteger
        amount = buffer.ReadInteger

        GiveBankItem(index, invslot, amount)

        buffer = Nothing
    End Sub

    Sub Packet_WithdrawItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim bankslot As Integer, amount As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CWithdrawItem Then Exit Sub

        bankslot = buffer.ReadInteger
        amount = buffer.ReadInteger

        TakeBankItem(index, bankslot, amount)

        buffer = Nothing
    End Sub

    Sub Packet_CloseBank(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CCloseBank Then Exit Sub

        SaveBank(index)
        SavePlayer(index)

        TempPlayer(index).InBank = False

        buffer = Nothing
    End Sub

    Sub Packet_AdminWarp(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim x As Integer, y As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CAdminWarp Then Exit Sub

        x = buffer.ReadInteger
        y = buffer.ReadInteger

        If GetPlayerAccess(index) >= AdminType.Mapper Then
            'Set the  Information
            SetPlayerX(index, x)
            SetPlayerY(index, y)

            'send the stuff
            SendPlayerXY(index)
        End If

        buffer = Nothing
    End Sub

    Sub Packet_TradeInvite(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim Name As String, tradetarget As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CTradeInvite Then Exit Sub

        Name = buffer.ReadString

        buffer = Nothing

        ' Check for a player

        tradetarget = FindPlayer(Name)

        ' make sure we don't error
        If tradetarget <= 0 Or tradetarget > MAX_PLAYERS Then Exit Sub

        ' can't trade with yourself..
        If tradetarget = index Then
            PlayerMsg(index, "You can't trade with yourself.", ColorType.BrightRed)
            Exit Sub
        End If

        ' send the trade request
        TempPlayer(index).TradeRequest = tradetarget
        TempPlayer(tradetarget).TradeRequest = index

        PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " has invited you to trade.", ColorType.Yellow)
        PlayerMsg(index, "You have invited " & Trim$(GetPlayerName(tradetarget)) & " to trade.", ColorType.BrightGreen)
        SendClearTradeTimer(index)

        SendTradeInvite(tradetarget, index)
    End Sub

    Sub Packet_TradeInviteAccept(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer, tradetarget As Integer, status As Byte
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CTradeInviteAccept Then Exit Sub

        status = buffer.ReadInteger

        buffer = Nothing

        If status = 0 Then Exit Sub

        tradetarget = TempPlayer(index).TradeRequest

        ' Let them trade!
        If TempPlayer(tradetarget).TradeRequest = index Then
            ' let them know they're trading
            PlayerMsg(index, "You have accepted " & Trim$(GetPlayerName(tradetarget)) & "'s trade request.", ColorType.Yellow)
            PlayerMsg(tradetarget, Trim$(GetPlayerName(index)) & " has accepted your trade request.", ColorType.BrightGreen)
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
            ReDim TempPlayer(tradetarget).TradeOffer(MAX_INV)
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

    Sub Packet_AcceptTrade(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer, itemNum As Integer
        Dim tradeTarget As Integer, i As Integer
        Dim tmpTradeItem(0 To MAX_INV) As PlayerInvRec
        Dim tmpTradeItem2(0 To MAX_INV) As PlayerInvRec

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CAcceptTrade Then Exit Sub

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

        PlayerMsg(index, "Trade completed.", ColorType.BrightGreen)
        PlayerMsg(tradeTarget, "Trade completed.", ColorType.BrightGreen)

        SendCloseTrade(index)
        SendCloseTrade(tradeTarget)

        buffer = Nothing
    End Sub

    Sub Packet_DeclineTrade(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tradeTarget As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CDeclineTrade Then Exit Sub

        tradeTarget = TempPlayer(index).InTrade

        For i = 1 To MAX_INV
            TempPlayer(index).TradeOffer(i).Num = 0
            TempPlayer(index).TradeOffer(i).Value = 0
            TempPlayer(tradeTarget).TradeOffer(i).Num = 0
            TempPlayer(tradeTarget).TradeOffer(i).Value = 0
        Next

        TempPlayer(index).InTrade = 0
        TempPlayer(tradeTarget).InTrade = 0

        PlayerMsg(index, "You declined the trade.", ColorType.Yellow)
        PlayerMsg(tradeTarget, GetPlayerName(index) & " has declined the trade.", ColorType.BrightRed)

        SendCloseTrade(index)
        SendCloseTrade(tradeTarget)

        buffer = Nothing
    End Sub

    Sub Packet_TradeItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As New ByteBuffer, itemnum As Integer
        Dim invslot As Integer, amount As Integer, emptyslot As Integer, i As Integer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CTradeItem Then Exit Sub

        invslot = buffer.ReadInteger
        amount = buffer.ReadInteger

        buffer = Nothing

        If invslot <= 0 Or invslot > MAX_INV Then Exit Sub

        itemnum = GetPlayerInvItemNum(index, invslot)

        If itemnum <= 0 Or itemnum > MAX_ITEMS Then Exit Sub

        ' make sure they have the amount they offer
        If amount < 0 Or amount > GetPlayerInvItemValue(index, invslot) Then Exit Sub

        If Item(itemnum).Type = ItemType.Currency Or Item(itemnum).Stackable = 1 Then

            ' check if already offering same currency item
            For i = 1 To MAX_INV

                If TempPlayer(index).TradeOffer(i).Num = invslot Then
                    ' add amount
                    TempPlayer(index).TradeOffer(i).Value = TempPlayer(index).TradeOffer(i).Value + amount

                    ' clamp to limits
                    If TempPlayer(index).TradeOffer(i).Value > GetPlayerInvItemValue(index, invslot) Then
                        TempPlayer(index).TradeOffer(i).Value = GetPlayerInvItemValue(index, invslot)
                    End If

                    ' cancel any trade agreement
                    TempPlayer(index).AcceptTrade = False
                    TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

                    SendTradeStatus(index, 0)
                    SendTradeStatus(TempPlayer(index).InTrade, 0)

                    SendTradeUpdate(index, 0)
                    SendTradeUpdate(TempPlayer(index).InTrade, 1)
                    ' exit early
                    Exit Sub
                End If
            Next
        Else
            ' make sure they're not already offering it
            For i = 1 To MAX_INV
                If TempPlayer(index).TradeOffer(i).Num = invslot Then
                    PlayerMsg(index, "You've already offered this item.", ColorType.BrightRed)
                    Exit Sub
                End If
            Next
        End If

        ' not already offering - find earliest empty slot
        For i = 1 To MAX_INV
            If TempPlayer(index).TradeOffer(i).Num = 0 Then
                emptyslot = i
                Exit For
            End If
        Next
        TempPlayer(index).TradeOffer(emptyslot).Num = invslot
        TempPlayer(index).TradeOffer(emptyslot).Value = amount

        ' cancel any trade agreement and send new data
        TempPlayer(index).AcceptTrade = False
        TempPlayer(TempPlayer(index).InTrade).AcceptTrade = False

        SendTradeStatus(index, 0)
        SendTradeStatus(TempPlayer(index).InTrade, 0)

        SendTradeUpdate(index, 0)
        SendTradeUpdate(TempPlayer(index).InTrade, 1)
    End Sub

    Sub Packet_UntradeItem(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim tradeslot As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CUntradeItem Then Exit Sub

        tradeslot = buffer.ReadInteger

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

    Public Sub HandleData(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer() As Byte
        Buffer = data.Clone
        Dim pLength As Integer

        If TempPlayer(index).Buffer Is Nothing Then TempPlayer(index).Buffer = New ByteBuffer
        TempPlayer(index).Buffer.WriteBytes(Buffer)

        If TempPlayer(index).Buffer.Count = 0 Then
            TempPlayer(index).Buffer.Clear()
            Exit Sub
        End If

        If TempPlayer(index).Buffer.Length >= 4 Then
            pLength = TempPlayer(index).Buffer.ReadInteger(False)

            If pLength <= 0 Then
                TempPlayer(index).Buffer.Clear()
                Exit Sub
            End If
        End If

        Do While pLength > 0 And pLength <= TempPlayer(index).Buffer.Length - 4

            If pLength <= TempPlayer(index).Buffer.Length - 4 Then
                TempPlayer(index).Buffer.ReadInteger()
                data = TempPlayer(index).Buffer.ReadBytes(pLength)
                HandleDataPackets(index, data)
            End If

            pLength = 0

            If TempPlayer(index).Buffer.Length >= 4 Then
                pLength = TempPlayer(index).Buffer.ReadInteger(False)

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

    Sub HackingAttempt(ByVal Index As Integer, ByVal Reason As String)

        If Index > 0 Then
            If IsPlaying(Index) Then
                Call GlobalMsg(GetPlayerLogin(Index) & "/" & GetPlayerName(Index) & " has been booted for (" & Reason & ")")
            End If

            Call AlertMsg(Index, "You have lost your connection with " & Options.GameName & ".")
        End If

    End Sub

    'Mapreport
    Sub Packet_MapReport(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CMapReport Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        SendMapReport(index)

        buffer = Nothing
    End Sub

    Sub Packet_Admin(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CAdmin Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub

        SendAdminPanel(index)

        buffer = Nothing
    End Sub

    Sub Packet_SetHotBarSlot(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer, slot As Integer, skill As Integer, type As Byte
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CSetHotbarSlot Then Exit Sub

        slot = buffer.ReadInteger
        skill = buffer.ReadInteger
        type = buffer.ReadInteger

        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot = skill
        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = type

        SendHotbar(index)

        buffer = Nothing
    End Sub

    Sub Packet_DeleteHotBarSlot(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As New ByteBuffer, slot As Integer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CDeleteHotbarSlot Then Exit Sub

        slot = buffer.ReadInteger

        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot = 0
        Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = 0

        SendHotbar(index)

        buffer = Nothing
    End Sub

    Sub Packet_UseHotBarSlot(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As New ByteBuffer, slot As Integer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CUseHotbarSlot Then Exit Sub

        slot = buffer.ReadInteger
        buffer = Nothing

        If Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot > 0 Then
            If Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = 1 Then 'skill
                BufferSkill(index, Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot)
            ElseIf Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).SlotType = 2 Then 'item
                UseItem(index, Player(index).Character(TempPlayer(index).CurChar).Hotbar(slot).Slot)
            End If
        End If

        SendHotbar(index)

    End Sub

    Sub Packet_RequestClasses(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ClientPackets.CRequestClasses Then Exit Sub

        SendClasses(index)

        buffer = Nothing
    End Sub

    Sub Packet_RequestEditClasses(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> EditorPackets.RequestEditClasses Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        SendClasses(index)

        SendClassEditor(index)

        buffer = Nothing
    End Sub

    Sub Packet_SaveClasses(ByVal index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer, i As Integer, z As Integer, x As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> EditorPackets.SaveClasses Then Exit Sub

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        ' Max classes
        Max_Classes = buffer.ReadInteger
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = buffer.ReadString
                .Desc = buffer.ReadString

                ' get array size
                z = buffer.ReadInteger

                ' redim array
                ReDim .MaleSprite(0 To z)
                ' loop-receive data
                For x = 0 To z
                    .MaleSprite(x) = buffer.ReadInteger
                Next

                ' get array size
                z = buffer.ReadInteger
                ' redim array
                ReDim .FemaleSprite(0 To z)
                ' loop-receive data
                For x = 0 To z
                    .FemaleSprite(x) = buffer.ReadInteger
                Next

                .Stat(Stats.Strength) = buffer.ReadInteger
                .Stat(Stats.Endurance) = buffer.ReadInteger
                .Stat(Stats.Vitality) = buffer.ReadInteger
                .Stat(Stats.Intelligence) = buffer.ReadInteger
                .Stat(Stats.Luck) = buffer.ReadInteger
                .Stat(Stats.Spirit) = buffer.ReadInteger

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = buffer.ReadInteger
                    .StartValue(q) = buffer.ReadInteger
                Next

                .StartMap = buffer.ReadInteger
                .StartX = buffer.ReadInteger
                .StartY = buffer.ReadInteger

                .BaseExp = buffer.ReadInteger
            End With

        Next

        buffer = Nothing

        SaveClasses()

        LoadClasses()

        SendClassesToAll()
    End Sub

    Private Sub Packet_EditorLogin(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Name As String, Password As String, Version As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.EditorLogin Then Exit Sub

        If Not IsLoggedIn(index) Then

            ' Get the data
            Name = Buffer.ReadString
            Password = Buffer.ReadString
            Version = Buffer.ReadString

            ' Check versions
            If Version <> Application.ProductVersion Then
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

            If GetPlayerAccess(index) > AdminType.Player Then
                SendEditorLoadOk(index)
                'SendMapData(index, 1, True)
                SendGameData(index)
                SendMapNames(index)
                SendProjectiles(index)
                SendQuests(index)
                SendRecipes(index)
                SendHouseConfigs(index)
                SendPets(index)
            Else
                AlertMsg(index, "not authorized.")
                Exit Sub
            End If

            ' Show the player up on the socket status
            Addlog(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".", PLAYER_LOG)

            TextAdd(GetPlayerLogin(index) & " has logged in from " & GetPlayerIP(index) & ".")

        End If

        Buffer = Nothing
    End Sub

    Private Sub Packet_EditorRequestMap(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim MapNum As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.EditorRequestMap Then Exit Sub

        MapNum = Buffer.ReadInteger

        Buffer = Nothing

        If GetPlayerAccess(index) > AdminType.Player Then
            SendMapData(index, MapNum, True)
            SendMapNames(index)

            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SEditMap)
            SendDataTo(index, Buffer.ToArray())
            Buffer = Nothing
        Else
            AlertMsg(index, "Not Allowed!")
        End If

    End Sub

    Sub Packet_EditorMapData(ByVal Index As Integer, ByVal Data() As Byte)
        Dim i As Integer
        Dim MapNum As Integer
        Dim x As Integer
        Dim y As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> EditorPackets.EditorSaveMap Then Exit Sub

        Data = Buffer.ReadBytes(Data.Length - 4)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(ArchaicIO.Compression.Decompress(Data))

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Mapper Then Exit Sub

        Gettingmap = True

        MapNum = Buffer.ReadInteger

        i = Map(MapNum).Revision + 1
        ClearMap(MapNum)

        Map(MapNum).Name = Buffer.ReadString
        Map(MapNum).Music = Buffer.ReadString
        Map(MapNum).Revision = i
        Map(MapNum).Moral = Buffer.ReadInteger
        Map(MapNum).Tileset = Buffer.ReadInteger
        Map(MapNum).Up = Buffer.ReadInteger
        Map(MapNum).Down = Buffer.ReadInteger
        Map(MapNum).Left = Buffer.ReadInteger
        Map(MapNum).Right = Buffer.ReadInteger
        Map(MapNum).BootMap = Buffer.ReadInteger
        Map(MapNum).BootX = Buffer.ReadInteger
        Map(MapNum).BootY = Buffer.ReadInteger
        Map(MapNum).MaxX = Buffer.ReadInteger
        Map(MapNum).MaxY = Buffer.ReadInteger
        Map(MapNum).WeatherType = Buffer.ReadInteger
        Map(MapNum).FogIndex = Buffer.ReadInteger
        Map(MapNum).WeatherIntensity = Buffer.ReadInteger
        Map(MapNum).FogAlpha = Buffer.ReadInteger
        Map(MapNum).FogSpeed = Buffer.ReadInteger
        Map(MapNum).HasMapTint = Buffer.ReadInteger
        Map(MapNum).MapTintR = Buffer.ReadInteger
        Map(MapNum).MapTintG = Buffer.ReadInteger
        Map(MapNum).MapTintB = Buffer.ReadInteger
        Map(MapNum).MapTintA = Buffer.ReadInteger
        Map(MapNum).Instanced = Buffer.ReadInteger

        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, MapNum)
            Map(MapNum).Npc(x) = Buffer.ReadInteger
        Next

        With Map(MapNum)
            For x = 0 To .MaxX
                For y = 0 To .MaxY
                    .Tile(x, y).Data1 = Buffer.ReadInteger
                    .Tile(x, y).Data2 = Buffer.ReadInteger
                    .Tile(x, y).Data3 = Buffer.ReadInteger
                    .Tile(x, y).DirBlock = Buffer.ReadInteger
                    ReDim .Tile(x, y).Layer(0 To MapLayer.Count - 1)
                    For i = 0 To MapLayer.Count - 1
                        .Tile(x, y).Layer(i).Tileset = Buffer.ReadInteger
                        .Tile(x, y).Layer(i).X = Buffer.ReadInteger
                        .Tile(x, y).Layer(i).Y = Buffer.ReadInteger
                        .Tile(x, y).Layer(i).AutoTile = Buffer.ReadInteger
                    Next
                    .Tile(x, y).Type = Buffer.ReadInteger
                Next
            Next

        End With

        'Event Data!
        Map(MapNum).EventCount = Buffer.ReadInteger

        If Map(MapNum).EventCount > 0 Then
            ReDim Map(MapNum).Events(0 To Map(MapNum).EventCount)
            For i = 1 To Map(MapNum).EventCount
                With Map(MapNum).Events(i)
                    .Name = Buffer.ReadString
                    .Globals = Buffer.ReadInteger
                    .X = Buffer.ReadInteger
                    .Y = Buffer.ReadInteger
                    .PageCount = Buffer.ReadInteger
                End With
                If Map(MapNum).Events(i).PageCount > 0 Then
                    ReDim Map(MapNum).Events(i).Pages(0 To Map(MapNum).Events(i).PageCount)
                    ReDim TempPlayer(i).EventMap.EventPages(0 To Map(MapNum).Events(i).PageCount)
                    For x = 1 To Map(MapNum).Events(i).PageCount
                        With Map(MapNum).Events(i).Pages(x)
                            .chkVariable = Buffer.ReadInteger
                            .VariableIndex = Buffer.ReadInteger
                            .VariableCondition = Buffer.ReadInteger
                            .VariableCompare = Buffer.ReadInteger

                            Map(MapNum).Events(i).Pages(x).chkSwitch = Buffer.ReadInteger
                            Map(MapNum).Events(i).Pages(x).SwitchIndex = Buffer.ReadInteger
                            .SwitchCompare = Buffer.ReadInteger

                            .chkHasItem = Buffer.ReadInteger
                            .HasItemIndex = Buffer.ReadInteger
                            .HasItemAmount = Buffer.ReadInteger

                            .chkSelfSwitch = Buffer.ReadInteger
                            .SelfSwitchIndex = Buffer.ReadInteger
                            .SelfSwitchCompare = Buffer.ReadInteger

                            .GraphicType = Buffer.ReadInteger
                            .Graphic = Buffer.ReadInteger
                            .GraphicX = Buffer.ReadInteger
                            .GraphicY = Buffer.ReadInteger
                            .GraphicX2 = Buffer.ReadInteger
                            .GraphicY2 = Buffer.ReadInteger

                            .MoveType = Buffer.ReadInteger
                            .MoveSpeed = Buffer.ReadInteger
                            .MoveFreq = Buffer.ReadInteger

                            .MoveRouteCount = Buffer.ReadInteger

                            .IgnoreMoveRoute = Buffer.ReadInteger
                            .RepeatMoveRoute = Buffer.ReadInteger

                            If .MoveRouteCount > 0 Then
                                ReDim Map(MapNum).Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 1 To .MoveRouteCount
                                    .MoveRoute(y).Index = Buffer.ReadInteger
                                    .MoveRoute(y).Data1 = Buffer.ReadInteger
                                    .MoveRoute(y).Data2 = Buffer.ReadInteger
                                    .MoveRoute(y).Data3 = Buffer.ReadInteger
                                    .MoveRoute(y).Data4 = Buffer.ReadInteger
                                    .MoveRoute(y).Data5 = Buffer.ReadInteger
                                    .MoveRoute(y).Data6 = Buffer.ReadInteger
                                Next
                            End If

                            .WalkAnim = Buffer.ReadInteger
                            .DirFix = Buffer.ReadInteger
                            .WalkThrough = Buffer.ReadInteger
                            .ShowName = Buffer.ReadInteger
                            .Trigger = Buffer.ReadInteger
                            .CommandListCount = Buffer.ReadInteger

                            .Position = Buffer.ReadInteger
                            .QuestNum = Buffer.ReadInteger

                            .chkPlayerGender = Buffer.ReadInteger
                        End With

                        If Map(MapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map(MapNum).Events(i).Pages(x).CommandList(0 To Map(MapNum).Events(i).Pages(x).CommandListCount)
                            For y = 1 To Map(MapNum).Events(i).Pages(x).CommandListCount
                                Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount = Buffer.ReadInteger
                                Map(MapNum).Events(i).Pages(x).CommandList(y).ParentList = Buffer.ReadInteger
                                If Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(0 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 1 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = Buffer.ReadInteger
                                            .Text1 = Buffer.ReadString
                                            .Text2 = Buffer.ReadString
                                            .Text3 = Buffer.ReadString
                                            .Text4 = Buffer.ReadString
                                            .Text5 = Buffer.ReadString
                                            .Data1 = Buffer.ReadInteger
                                            .Data2 = Buffer.ReadInteger
                                            .Data3 = Buffer.ReadInteger
                                            .Data4 = Buffer.ReadInteger
                                            .Data5 = Buffer.ReadInteger
                                            .Data6 = Buffer.ReadInteger
                                            .ConditionalBranch.CommandList = Buffer.ReadInteger
                                            .ConditionalBranch.Condition = Buffer.ReadInteger
                                            .ConditionalBranch.Data1 = Buffer.ReadInteger
                                            .ConditionalBranch.Data2 = Buffer.ReadInteger
                                            .ConditionalBranch.Data3 = Buffer.ReadInteger
                                            .ConditionalBranch.ElseCommandList = Buffer.ReadInteger
                                            .MoveRouteCount = Buffer.ReadInteger
                                            Dim tmpcount As Integer = .MoveRouteCount
                                            If tmpcount > 0 Then
                                                ReDim Preserve .MoveRoute(tmpcount)
                                                For w = 1 To tmpcount
                                                    .MoveRoute(w).Index = Buffer.ReadInteger
                                                    .MoveRoute(w).Data1 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data2 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data3 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data4 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data5 = Buffer.ReadInteger
                                                    .MoveRoute(w).Data6 = Buffer.ReadInteger
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

        For i = 1 To GetTotalPlayersOnline()
            If IsPlaying(i) Then
                If Player(i).Character(TempPlayer(i).CurChar).Map = MapNum Then
                    SpawnMapEventsFor(i, MapNum)
                End If
            End If
        Next

        ' Clear out it all
        For i = 1 To MAX_MAP_ITEMS
            SpawnItemSlot(i, 0, 0, GetPlayerMap(Index), MapItem(GetPlayerMap(Index), i).X, MapItem(GetPlayerMap(Index), i).Y)
            ClearMapItem(i, GetPlayerMap(Index))
        Next

        ' Respawn
        SpawnMapItems(MapNum)

        ClearTempTile(MapNum)
        CacheResources(MapNum)

        ' Refresh map for everyone online
        For i = 1 To GetTotalPlayersOnline()
            If IsPlaying(i) And GetPlayerMap(i) = MapNum Then
                PlayerWarp(i, MapNum, GetPlayerX(i), GetPlayerY(i))
                ' Send map
                SendMapData(i, MapNum, True)
            End If
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_RequestAutoMap(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.RequestAutoMap Then Exit Sub

        Buffer = Nothing

        If GetPlayerAccess(index) = AdminType.Player Then Exit Sub

        SendAutoMapper(index)
    End Sub

    Private Sub Packet_SaveAutoMap(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, Layer As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.SaveAutoMap Then Exit Sub

        If GetPlayerAccess(index) = AdminType.Player Then Exit Sub

        MapStart = Buffer.ReadInteger
        MapSize = Buffer.ReadInteger
        MapX = Buffer.ReadInteger
        MapY = Buffer.ReadInteger
        SandBorder = Buffer.ReadInteger
        DetailFreq = Buffer.ReadInteger
        ResourceFreq = Buffer.ReadInteger

        Dim myXml As New XmlClass With {
            .Filename = Application.StartupPath & "\Data\AutoMapper.xml",
            .Root = "Options"
        }

        myXml.WriteString("Resources", "ResourcesNum", Buffer.ReadString())

        For Prefab = 1 To TilePrefab.Count - 1
            ReDim Tile(Prefab).Layer(0 To MapLayer.Count - 1)

            Layer = Buffer.ReadInteger()
            myXml.WriteString("Prefab" & Prefab, "Layer" & Layer & "Tileset", Buffer.ReadInteger)
            myXml.WriteString("Prefab" & Prefab, "Layer" & Layer & "X", Buffer.ReadInteger)
            myXml.WriteString("Prefab" & Prefab, "Layer" & Layer & "Y", Buffer.ReadInteger)
            myXml.WriteString("Prefab" & Prefab, "Layer" & Layer & "Autotile", Buffer.ReadInteger)

            myXml.WriteString("Prefab" & Prefab, "Type", Buffer.ReadInteger)
        Next

        Buffer = Nothing

        StartAutomapper(MapStart, MapSize, MapX, MapY)

    End Sub

    Private Sub Packet_Emote(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Emote As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CEmote Then Exit Sub
        Emote = Buffer.ReadInteger

        SendEmote(index, Emote)

        Buffer = Nothing
    End Sub
End Module