Public Module ServerHousing
#Region "Globals & Types"
    Public MAX_HOUSES As Long = 100

    Public HouseConfig() As HouseRec

    Structure HouseRec
        Dim ConfigName As String
        Dim BaseMap As Long
        Dim Price As Long
        Dim MaxFurniture As Long
        Dim X As Long
        Dim Y As Long
    End Structure

    Structure FurnitureRec
        Dim ItemNum As Long
        Dim X As Long
        Dim Y As Long
    End Structure

    Structure PlayerHouseRec
        Dim HouseIndex As Long
        Dim FurnitureCount As Long
        Dim Furniture() As FurnitureRec
    End Structure
#End Region

#Region "DataBase"
    Sub LoadHouses()
        Dim i As Long, filepath As String

        filepath = Application.StartupPath & "\data\HouseConfig.ini"
        frmServer.lstHouses.Items.Clear()

        For i = 1 To MAX_HOUSES

            HouseConfig(i).BaseMap = Val(Getvar(filepath, "House" & i, "BaseMap"))
            HouseConfig(i).ConfigName = Trim$(Getvar(filepath, "House" & i, "Name"))
            HouseConfig(i).MaxFurniture = Val(Getvar(filepath, "House" & i, "MaxFurniture"))
            HouseConfig(i).Price = Val(Getvar(filepath, "House" & i, "Price"))
            HouseConfig(i).X = Val(Getvar(filepath, "House" & i, "X"))
            HouseConfig(i).Y = Val(Getvar(filepath, "House" & i, "Y"))
            frmServer.lstHouses.Items.Add(i & ". " & HouseConfig(i).ConfigName)
            DoEvents()
        Next
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendHouseConfigs(i)
            End If
        Next

    End Sub

    Sub SaveHouse(Index As Long)
        Dim filepath As String

        filepath = Application.StartupPath & "\data\HouseConfig.ini"
        If Index > 0 And Index <= MAX_HOUSES Then
            Call PutVar(filepath, "House" & Index, "BaseMap", HouseConfig(Index).BaseMap)
            Call PutVar(filepath, "House" & Index, "Name", HouseConfig(Index).ConfigName)
            Call PutVar(filepath, "House" & Index, "MaxFurniture", HouseConfig(Index).MaxFurniture)
            Call PutVar(filepath, "House" & Index, "Price", HouseConfig(Index).Price)
            Call PutVar(filepath, "House" & Index, "X", HouseConfig(Index).X)
            Call PutVar(filepath, "House" & Index, "Y", HouseConfig(Index).Y)
        End If
        LoadHouses()

    End Sub

    Sub SaveHouses()
        Dim i As Long

        For i = 1 To MAX_HOUSES
            SaveHouse(i)
        Next

    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_BuyHouse(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long, price As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CBuyHouse Then Exit Sub

        i = Buffer.ReadLong

        If i = 1 Then
            If TempPlayer(index).BuyHouseIndex > 0 Then
                price = HouseConfig(TempPlayer(index).BuyHouseIndex).Price
                If HasItem(index, 1) >= price Then
                    TakeInvItem(index, 1, price)
                    Player(index).House.HouseIndex = TempPlayer(index).BuyHouseIndex
                    PlayerMsg(index, "You just bought the " & Trim$(HouseConfig(TempPlayer(index).BuyHouseIndex).ConfigName) & " house!")
                    Player(index).LastMap = GetPlayerMap(index)
                    Player(index).LastX = GetPlayerX(index)
                    Player(index).LastY = GetPlayerY(index)
                    Player(index).InHouse = index
                    Call PlayerWarp(index, HouseConfig(Player(index).House.HouseIndex).BaseMap, HouseConfig(Player(index).House.HouseIndex).X, HouseConfig(Player(index).House.HouseIndex).Y, True)
                    SavePlayer(index)
                Else
                    PlayerMsg(index, "You cannot afford this house!")
                End If
            End If
        End If

        TempPlayer(index).BuyHouseIndex = 0

        Buffer = Nothing

    End Sub

    Sub Packet_InviteToHouse(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, invitee As Long, Name As String

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CVisit Then Exit Sub

        Name = Trim$(Buffer.ReadString)
        invitee = FindPlayer(Name)
        Buffer = Nothing

        If invitee = 0 Then
            PlayerMsg(index, "Player not found.")
            Exit Sub
        End If

        If index = invitee Then
            PlayerMsg(index, "You cannot invite yourself to you own house!")
            Exit Sub
        End If

        If TempPlayer(invitee).InvitationIndex > 0 Then
            If TempPlayer(invitee).InvitationTimer > GetTickCount() Then
                PlayerMsg(index, Trim$(GetPlayerName(invitee)) & " is currently busy!")
                Exit Sub
            End If
        End If

        If Player(index).House.HouseIndex > 0 Then
            If Player(index).InHouse > 0 Then
                If Player(index).InHouse = index Then
                    If Player(invitee).InHouse > 0 Then
                        If Player(invitee).InHouse = index Then
                            PlayerMsg(index, Trim$(GetPlayerName(invitee)) & " is already in your house!")
                        Else
                            PlayerMsg(index, Trim$(GetPlayerName(invitee)) & " is already visiting someone elses house!")
                        End If
                    Else
                        'Send invite
                        Buffer = New ByteBuffer
                        Buffer.WriteLong(ServerPackets.SVisit)
                        Buffer.WriteLong(index)
                        SendDataTo(invitee, Buffer.ToArray)
                        TempPlayer(invitee).InvitationIndex = index
                        TempPlayer(invitee).InvitationTimer = GetTickCount() + 15000
                        Buffer = Nothing
                    End If
                Else
                    PlayerMsg(index, "Only the house owner can invite other players into their house.")
                End If
            Else
                PlayerMsg(index, "You must be inside your house before you can invite someone to visit!")
            End If
        Else
            PlayerMsg(index, "You do not have a house to invite anyone to!")
        End If

    End Sub

    Sub Packet_AcceptInvite(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, response As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CAcceptVisit Then Exit Sub

        response = Buffer.ReadLong
        Buffer = Nothing

        If response = 1 Then
            If TempPlayer(index).InvitationIndex > 0 Then
                If TempPlayer(index).InvitationTimer > GetTickCount() Then
                    'Accept this invite
                    If IsPlaying(TempPlayer(index).InvitationIndex) Then
                        Player(index).InHouse = TempPlayer(index).InvitationIndex
                        Player(index).LastX = GetPlayerX(index)
                        Player(index).LastY = GetPlayerY(index)
                        Player(index).LastMap = GetPlayerMap(index)
                        TempPlayer(index).InvitationTimer = 0
                        PlayerWarp(index, Player(TempPlayer(index).InvitationIndex).Map, HouseConfig(Player(TempPlayer(index).InvitationIndex).House.HouseIndex).X, HouseConfig(Player(TempPlayer(index).InvitationIndex).House.HouseIndex).Y, True)
                    Else
                        TempPlayer(index).InvitationTimer = 0
                        PlayerMsg(index, "Cannot find player!")
                    End If
                Else
                    PlayerMsg(index, "Your invitation has expired, have your friend re-invite you.")
                End If
            Else

            End If
        Else
            If IsPlaying(TempPlayer(index).InvitationIndex) Then
                TempPlayer(index).InvitationTimer = 0
                PlayerMsg(TempPlayer(index).InvitationIndex, Trim$(GetPlayerName(index)) & " rejected your invitation")
            End If
        End If


    End Sub

    Sub Packet_PlaceFurniture(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long, x As Long, y As Long, invslot As Long
        Dim ItemNum As Long, x1 As Long, y1 As Long, widthoffset As Long


        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CPlaceFurniture Then Exit Sub

        x = Buffer.ReadLong
        y = Buffer.ReadLong
        invslot = Buffer.ReadLong
        Buffer = Nothing

        ItemNum = Player(index).Inv(invslot).Num

        ' Prevent hacking
        If ItemNum < 1 Or ItemNum > MAX_ITEMS Then
            Exit Sub
        End If

        If Player(index).InHouse = index Then
            If Item(ItemNum).Type = ITEM_TYPE_FURNITURE Then
                ' stat requirements
                For i = 1 To Stats.Stat_Count - 1
                    If GetPlayerRawStat(index, i) < Item(ItemNum).Stat_Req(i) Then
                        PlayerMsg(index, "You do not meet the stat requirements to use this item.")
                        Exit Sub
                    End If
                Next

                ' level requirement
                If GetPlayerLevel(index) < Item(ItemNum).LevelReq Then
                    PlayerMsg(index, "You do not meet the level requirement to use this item.")
                    Exit Sub
                End If

                ' class requirement
                If Item(ItemNum).ClassReq > 0 Then
                    If Not GetPlayerClass(index) = Item(ItemNum).ClassReq Then
                        PlayerMsg(index, "You do not meet the class requirement to use this item.")
                        Exit Sub
                    End If
                End If

                ' access requirement
                If Not GetPlayerAccess(index) >= Item(ItemNum).AccessReq Then
                    PlayerMsg(index, "You do not meet the access requirement to use this item.")
                    Exit Sub
                End If

                'Ok, now we got to see what can be done about this furniture :/
                If Player(index).InHouse <> index Then
                    PlayerMsg(index, "You must be inside your house to place furniture!")
                    Exit Sub
                End If

                If Player(index).House.FurnitureCount >= HouseConfig(Player(index).House.HouseIndex).MaxFurniture Then
                    If HouseConfig(Player(index).House.HouseIndex).MaxFurniture > 0 Then
                        PlayerMsg(index, "Your house cannot hold any more furniture!")
                        Exit Sub
                    End If
                End If

                If x < 0 Or x > Map(GetPlayerMap(index)).MaxX Then Exit Sub
                If y < 0 Or y > Map(GetPlayerMap(index)).MaxY Then Exit Sub

                If Item(ItemNum).FurnitureWidth > 2 Then
                    x1 = x + (Item(ItemNum).FurnitureWidth / 2)
                    widthoffset = x1 - x
                    x1 = x1 - (Item(ItemNum).FurnitureWidth - widthoffset)
                Else
                    x1 = x
                End If

                x1 = x
                widthoffset = 0

                y1 = y

                If widthoffset > 0 Then

                    For x = x1 To x1 + widthoffset
                        For y = y1 To y1 - Item(ItemNum).FurnitureHeight + 1 Step -1
                            If Map(GetPlayerMap(index)).Tile(x, y).Type = TILE_TYPE_BLOCKED Then Exit Sub

                            For i = 1 To MAX_PLAYERS
                                If IsPlaying(i) Then
                                    If i <> index Then
                                        If GetPlayerMap(i) = GetPlayerMap(index) Then
                                            If Player(i).InHouse = Player(index).InHouse Then
                                                If Player(i).x = x And Player(i).y = y Then
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If Player(index).House.FurnitureCount > 0 Then
                                For i = 1 To Player(index).House.FurnitureCount
                                    If x >= Player(index).House.Furniture(i).X And x <= Player(index).House.Furniture(i).X + Item(Player(index).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                        If y <= Player(index).House.Furniture(i).Y And y >= Player(index).House.Furniture(i).Y - Item(Player(index).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
                                            'Blocked!
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next

                    For x = x1 To x1 - (Item(ItemNum).FurnitureWidth - widthoffset) Step -1
                        For y = y1 To y1 - Item(ItemNum).FurnitureHeight + 1 Step -1
                            If Map(GetPlayerMap(index)).Tile(x, y).Type = TILE_TYPE_BLOCKED Then Exit Sub

                            For i = 1 To MAX_PLAYERS
                                If IsPlaying(i) Then
                                    If i <> index Then
                                        If GetPlayerMap(i) = GetPlayerMap(index) Then
                                            If Player(i).InHouse = Player(index).InHouse Then
                                                If Player(i).x = x And Player(i).y = y Then
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If Player(index).House.FurnitureCount > 0 Then
                                For i = 1 To Player(index).House.FurnitureCount
                                    If x >= Player(index).House.Furniture(i).X And x <= Player(index).House.Furniture(i).X + Item(Player(index).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                        If y <= Player(index).House.Furniture(i).Y And y >= Player(index).House.Furniture(i).Y - Item(Player(index).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
                                            'Blocked!
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                Else
                    For x = x1 To x1 + Item(ItemNum).FurnitureWidth - 1
                        For y = y1 To y1 - Item(ItemNum).FurnitureHeight + 1 Step -1
                            If Map(GetPlayerMap(index)).Tile(x, y).Type = TILE_TYPE_BLOCKED Then Exit Sub

                            For i = 1 To MAX_PLAYERS
                                If IsPlaying(i) Then
                                    If i <> index Then
                                        If GetPlayerMap(i) = GetPlayerMap(index) Then
                                            If Player(i).InHouse = Player(index).InHouse Then
                                                If Player(i).x = x And Player(i).y = y Then
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If Player(index).House.FurnitureCount > 0 Then
                                For i = 1 To Player(index).House.FurnitureCount
                                    If x >= Player(index).House.Furniture(i).X And x <= Player(index).House.Furniture(i).X + Item(Player(index).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                        If y <= Player(index).House.Furniture(i).Y And y >= Player(index).House.Furniture(i).Y - Item(Player(index).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
                                            'Blocked!
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

                x = x1
                y = y1

                'If all checks out, place furniture and send the update to everyone in the player's house.
                Player(index).House.FurnitureCount = Player(index).House.FurnitureCount + 1
                ReDim Preserve Player(index).House.Furniture(Player(index).House.FurnitureCount)
                Player(index).House.Furniture(Player(index).House.FurnitureCount).ItemNum = ItemNum
                Player(index).House.Furniture(Player(index).House.FurnitureCount).X = x
                Player(index).House.Furniture(Player(index).House.FurnitureCount).Y = y


                Call TakeInvItem(index, ItemNum, 0)

                SendFurnitureToHouse(Player(index).InHouse)

                SavePlayer(index)
            End If
        Else
            PlayerMsg(index, "You cannot place furniture unless you are in your own house!")
        End If

    End Sub

    Sub Packet_RequestEditHouse(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CRequestEditHouse Then Exit Sub

        Buffer = Nothing

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SHouseEdit)
        For i = 1 To MAX_HOUSES
            Buffer.WriteString(Trim$(HouseConfig(i).ConfigName))
            Buffer.WriteLong(HouseConfig(i).BaseMap)
            Buffer.WriteLong(HouseConfig(i).X)
            Buffer.WriteLong(HouseConfig(i).Y)
            Buffer.WriteLong(HouseConfig(i).Price)
            Buffer.WriteLong(HouseConfig(i).MaxFurniture)
        Next
        SendDataTo(index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub Packet_SaveHouses(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long, x As Long, Count As Long, z As Long

        ' Prevent hacking
        If GetPlayerAccess(index) < ADMIN_MAPPER Then
            Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CSaveHouses Then Exit Sub

        Count = Buffer.ReadLong
        If Count > 0 Then
            For z = 1 To Count
                i = Buffer.ReadLong
                HouseConfig(i).ConfigName = Trim$(Buffer.ReadString)
                HouseConfig(i).BaseMap = Buffer.ReadLong
                HouseConfig(i).X = Buffer.ReadLong
                HouseConfig(i).Y = Buffer.ReadLong
                HouseConfig(i).Price = Buffer.ReadLong
                HouseConfig(i).MaxFurniture = Buffer.ReadLong
                Call SaveHouse(i)
                For x = 1 To MAX_PLAYERS
                    If IsPlaying(x) Then
                        If Player(x).InHouse = i Then

                        End If
                    End If
                Next
            Next
        End If

        Buffer = Nothing

    End Sub

    Sub Packet_SellHouse(ByVal index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long, refund As Long
        Dim TmpIndex As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ClientPackets.CSellHouse Then Exit Sub

        TmpIndex = Player(index).House.HouseIndex
        If TmpIndex > 0 Then
            'get some money back
            refund = HouseConfig(TmpIndex).Price / 2

            Player(index).House.HouseIndex = 0
            Player(index).House.FurnitureCount = 0
            ReDim Player(index).House.Furniture(Player(index).House.FurnitureCount)

            For i = 0 To Player(index).House.FurnitureCount
                Player(index).House.Furniture(i).ItemNum = 0
                Player(index).House.Furniture(i).X = 0
                Player(index).House.Furniture(i).Y = 0
            Next

            If Player(index).InHouse = TmpIndex Then
                Call PlayerWarp(index, Player(index).LastMap, Player(index).LastX, Player(index).LastY)
            End If

            SavePlayer(index)

            PlayerMsg(index, "You sold your House for " & refund & " Gold!")
            GiveInvItem(index, 1, refund)
        Else
            PlayerMsg(index, "You dont own a House!")
        End If

        Buffer = Nothing

    End Sub

#End Region

#Region "OutGoing Packets"
    Sub SendHouseConfigs(ByVal Index As Long)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SHouseConfigs)

        For i = 1 To MAX_HOUSES
            Buffer.WriteString(Trim(HouseConfig(i).ConfigName))
            Buffer.WriteLong(HouseConfig(i).BaseMap)
            Buffer.WriteLong(HouseConfig(i).MaxFurniture)
            Buffer.WriteLong(HouseConfig(i).Price)
        Next

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendFurnitureToHouse(HouseIndex As Long)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SFurniture)
        Buffer.WriteLong(HouseIndex)
        Buffer.WriteLong(Player(HouseIndex).House.FurnitureCount)
        If Player(HouseIndex).House.FurnitureCount > 0 Then
            For i = 1 To Player(HouseIndex).House.FurnitureCount
                Buffer.WriteLong(Player(HouseIndex).House.Furniture(i).ItemNum)
                Buffer.WriteLong(Player(HouseIndex).House.Furniture(i).X)
                Buffer.WriteLong(Player(HouseIndex).House.Furniture(i).Y)
            Next
        End If

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If Player(i).InHouse = HouseIndex Then
                    SendDataTo(i, Buffer.ToArray)
                End If
            End If
        Next

        Buffer = Nothing

    End Sub
#End Region

End Module
