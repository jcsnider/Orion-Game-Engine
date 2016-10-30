Public Module ServerHousing
#Region "Globals & Types"
    Public MAX_HOUSES As Integer = 100

    Public HouseConfig() As HouseRec

    Structure HouseRec
        Dim ConfigName As String
        Dim BaseMap As Integer
        Dim Price As Integer
        Dim MaxFurniture As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Structure FurnitureRec
        Dim ItemNum As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Structure PlayerHouseRec
        Dim HouseIndex As Integer
        Dim FurnitureCount As Integer
        Dim Furniture() As FurnitureRec
    End Structure
#End Region

#Region "DataBase"
    Sub LoadHouses()
        Dim i As Integer, filepath As String

        filepath = Application.StartupPath & "\data\HouseConfig.ini"
        'frmServer.lstHouses.Items.Clear()

        For i = 1 To MAX_HOUSES

            HouseConfig(i).BaseMap = Val(Getvar(filepath, "House" & i, "BaseMap"))
            HouseConfig(i).ConfigName = Trim$(Getvar(filepath, "House" & i, "Name"))
            HouseConfig(i).MaxFurniture = Val(Getvar(filepath, "House" & i, "MaxFurniture"))
            HouseConfig(i).Price = Val(Getvar(filepath, "House" & i, "Price"))
            HouseConfig(i).X = Val(Getvar(filepath, "House" & i, "X"))
            HouseConfig(i).Y = Val(Getvar(filepath, "House" & i, "Y"))
            'frmServer.lstHouses.Items.Add(i & ". " & HouseConfig(i).ConfigName)
            DoEvents()
        Next
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendHouseConfigs(i)
            End If
        Next

    End Sub

    Sub SaveHouse(Index As Integer)
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
        Dim i As Integer

        For i = 1 To MAX_HOUSES
            SaveHouse(i)
        Next

    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_BuyHouse(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer, price As Integer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CBuyHouse Then Exit Sub

        i = Buffer.ReadInteger

        If i = 1 Then
            If TempPlayer(index).BuyHouseIndex > 0 Then
                price = HouseConfig(TempPlayer(index).BuyHouseIndex).Price
                If HasItem(index, 1) >= price Then
                    TakeInvItem(index, 1, price)
                    Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex = TempPlayer(index).BuyHouseIndex
                    PlayerMsg(index, "You just bought the " & Trim$(HouseConfig(TempPlayer(index).BuyHouseIndex).ConfigName) & " house!")
                    Player(index).Character(TempPlayer(index).CurChar).LastMap = GetPlayerMap(index)
                    Player(index).Character(TempPlayer(index).CurChar).LastX = GetPlayerX(index)
                    Player(index).Character(TempPlayer(index).CurChar).LastY = GetPlayerY(index)
                    Player(index).Character(TempPlayer(index).CurChar).InHouse = index

                    PlayerWarp(index, HouseConfig(Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex).BaseMap, HouseConfig(Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex).X, HouseConfig(Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex).Y, True)
                    SavePlayer(index)
                Else
                    PlayerMsg(index, "You cannot afford this house!")
                End If
            End If
        End If

        TempPlayer(index).BuyHouseIndex = 0

        Buffer = Nothing

    End Sub

    Sub Packet_InviteToHouse(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, invitee As Integer, Name As String

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CVisit Then Exit Sub

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

        If Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex > 0 Then
            If Player(index).Character(TempPlayer(index).CurChar).InHouse > 0 Then
                If Player(index).Character(TempPlayer(index).CurChar).InHouse = index Then
                    If Player(invitee).Character(TempPlayer(invitee).CurChar).InHouse > 0 Then
                        If Player(invitee).Character(TempPlayer(invitee).CurChar).InHouse = index Then
                            PlayerMsg(index, Trim$(GetPlayerName(invitee)) & " is already in your house!")
                        Else
                            PlayerMsg(index, Trim$(GetPlayerName(invitee)) & " is already visiting someone elses house!")
                        End If
                    Else
                        'Send invite
                        Buffer = New ByteBuffer
                        Buffer.WriteInteger(ServerPackets.SVisit)
                        Buffer.WriteInteger(index)
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

    Sub Packet_AcceptInvite(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, response As Integer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CAcceptVisit Then Exit Sub

        response = Buffer.ReadInteger
        Buffer = Nothing

        If response = 1 Then
            If TempPlayer(index).InvitationIndex > 0 Then
                If TempPlayer(index).InvitationTimer > GetTickCount() Then
                    'Accept this invite
                    If IsPlaying(TempPlayer(index).InvitationIndex) Then
                        Player(index).Character(TempPlayer(index).CurChar).InHouse = TempPlayer(index).InvitationIndex
                        Player(index).Character(TempPlayer(index).CurChar).LastX = GetPlayerX(index)
                        Player(index).Character(TempPlayer(index).CurChar).LastY = GetPlayerY(index)
                        Player(index).Character(TempPlayer(index).CurChar).LastMap = GetPlayerMap(index)
                        TempPlayer(index).InvitationTimer = 0
                        PlayerWarp(index, Player(TempPlayer(index).InvitationIndex).Character(TempPlayer(index).CurChar).Map, HouseConfig(Player(TempPlayer(index).InvitationIndex).Character(TempPlayer(TempPlayer(index).InvitationIndex).CurChar).House.HouseIndex).X, HouseConfig(Player(TempPlayer(index).InvitationIndex).Character(TempPlayer(TempPlayer(index).InvitationIndex).CurChar).House.HouseIndex).Y, True)
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

    Sub Packet_PlaceFurniture(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer, x As Integer, y As Integer, invslot As Integer
        Dim ItemNum As Integer, x1 As Integer, y1 As Integer, widthoffset As Integer


        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CPlaceFurniture Then Exit Sub

        x = Buffer.ReadInteger
        y = Buffer.ReadInteger
        invslot = Buffer.ReadInteger
        Buffer = Nothing

        ItemNum = Player(index).Character(TempPlayer(index).CurChar).Inv(invslot).Num

        ' Prevent hacking
        If ItemNum < 1 Or ItemNum > MAX_ITEMS Then
            Exit Sub
        End If

        If Player(index).Character(TempPlayer(index).CurChar).InHouse = index Then
            If Item(ItemNum).Type = ItemType.FURNITURE Then
                ' stat requirements
                For i = 1 To Stats.Count - 1
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
                If Player(index).Character(TempPlayer(index).CurChar).InHouse <> index Then
                    PlayerMsg(index, "You must be inside your house to place furniture!")
                    Exit Sub
                End If

                If Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount >= HouseConfig(Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex).MaxFurniture Then
                    If HouseConfig(Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex).MaxFurniture > 0 Then
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
                            If Map(GetPlayerMap(index)).Tile(x, y).Type = TileType.BLOCKED Then Exit Sub

                            For i = 1 To MAX_PLAYERS
                                If IsPlaying(i) Then
                                    If i <> index Then
                                        If GetPlayerMap(i) = GetPlayerMap(index) Then
                                            If Player(i).Character(TempPlayer(i).CurChar).InHouse = Player(index).Character(TempPlayer(index).CurChar).InHouse Then
                                                If Player(i).Character(TempPlayer(i).CurChar).x = x And Player(i).Character(TempPlayer(i).CurChar).y = y Then
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount > 0 Then
                                For i = 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount
                                    If x >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X And x <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X + Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                        If y <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y And y >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y - Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
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
                            If Map(GetPlayerMap(index)).Tile(x, y).Type = TileType.BLOCKED Then Exit Sub

                            For i = 1 To MAX_PLAYERS
                                If IsPlaying(i) Then
                                    If i <> index Then
                                        If GetPlayerMap(i) = GetPlayerMap(index) Then
                                            If Player(i).Character(TempPlayer(i).CurChar).InHouse = Player(index).Character(TempPlayer(index).CurChar).InHouse Then
                                                If Player(i).Character(TempPlayer(i).CurChar).x = x And Player(i).Character(TempPlayer(i).CurChar).y = y Then
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount > 0 Then
                                For i = 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount
                                    If x >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X And x <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X + Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                        If y <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y And y >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y - Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
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
                            If Map(GetPlayerMap(index)).Tile(x, y).Type = TileType.BLOCKED Then Exit Sub

                            For i = 1 To MAX_PLAYERS
                                If IsPlaying(i) Then
                                    If i <> index Then
                                        If GetPlayerMap(i) = GetPlayerMap(index) Then
                                            If Player(i).Character(TempPlayer(i).CurChar).InHouse = Player(index).Character(TempPlayer(index).CurChar).InHouse Then
                                                If Player(i).Character(TempPlayer(i).CurChar).x = x And Player(i).Character(TempPlayer(i).CurChar).y = y Then
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount > 0 Then
                                For i = 1 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount
                                    If x >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X And x <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X + Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                        If y <= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y And y >= Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y - Item(Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum).FurnitureHeight + 1 Then
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
                Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount = Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount + 1
                ReDim Preserve Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount)
                Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount).ItemNum = ItemNum
                Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount).X = x
                Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount).Y = y

                TakeInvItem(index, ItemNum, 0)

                SendFurnitureToHouse(Player(index).Character(TempPlayer(index).CurChar).InHouse)

                SavePlayer(index)
            End If
        Else
            PlayerMsg(index, "You cannot place furniture unless you are in your own house!")
        End If

    End Sub

    Sub Packet_RequestEditHouse(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CRequestEditHouse Then Exit Sub

        Buffer = Nothing

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.MAPPER Then
            Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SHouseEdit)
        For i = 1 To MAX_HOUSES
            Buffer.WriteString(Trim$(HouseConfig(i).ConfigName))
            Buffer.WriteInteger(HouseConfig(i).BaseMap)
            Buffer.WriteInteger(HouseConfig(i).X)
            Buffer.WriteInteger(HouseConfig(i).Y)
            Buffer.WriteInteger(HouseConfig(i).Price)
            Buffer.WriteInteger(HouseConfig(i).MaxFurniture)
        Next
        SendDataTo(index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub Packet_SaveHouses(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer, x As Integer, Count As Integer, z As Integer

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.MAPPER Then
            Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CSaveHouses Then Exit Sub

        Count = Buffer.ReadInteger
        If Count > 0 Then
            For z = 1 To Count
                i = Buffer.ReadInteger
                HouseConfig(i).ConfigName = Trim$(Buffer.ReadString)
                HouseConfig(i).BaseMap = Buffer.ReadInteger
                HouseConfig(i).X = Buffer.ReadInteger
                HouseConfig(i).Y = Buffer.ReadInteger
                HouseConfig(i).Price = Buffer.ReadInteger
                HouseConfig(i).MaxFurniture = Buffer.ReadInteger
                SaveHouse(i)

                For x = 1 To MAX_PLAYERS
                    If IsPlaying(x) Then
                        If Player(x).Character(TempPlayer(x).CurChar).InHouse = i Then

                        End If
                    End If
                Next
            Next
        End If

        Buffer = Nothing

    End Sub

    Sub Packet_SellHouse(ByVal index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer, refund As Integer
        Dim TmpIndex As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ClientPackets.CSellHouse Then Exit Sub

        TmpIndex = Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex
        If TmpIndex > 0 Then
            'get some money back
            refund = HouseConfig(TmpIndex).Price / 2

            Player(index).Character(TempPlayer(index).CurChar).House.HouseIndex = 0
            Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount = 0
            ReDim Player(index).Character(TempPlayer(index).CurChar).House.Furniture(Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount)

            For i = 0 To Player(index).Character(TempPlayer(index).CurChar).House.FurnitureCount
                Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).ItemNum = 0
                Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).X = 0
                Player(index).Character(TempPlayer(index).CurChar).House.Furniture(i).Y = 0
            Next

            If Player(index).Character(TempPlayer(index).CurChar).InHouse = TmpIndex Then
                PlayerWarp(index, Player(index).Character(TempPlayer(index).CurChar).LastMap, Player(index).Character(TempPlayer(index).CurChar).LastX, Player(index).Character(TempPlayer(index).CurChar).LastY)
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
    Sub SendHouseConfigs(ByVal Index As Integer)
        Dim Buffer As ByteBuffer, i As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SHouseConfigs)

        For i = 1 To MAX_HOUSES
            Buffer.WriteString(Trim(HouseConfig(i).ConfigName))
            Buffer.WriteInteger(HouseConfig(i).BaseMap)
            Buffer.WriteInteger(HouseConfig(i).MaxFurniture)
            Buffer.WriteInteger(HouseConfig(i).Price)
        Next

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendFurnitureToHouse(HouseIndex As Integer)
        Dim Buffer As ByteBuffer, i As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SFurniture)
        Buffer.WriteInteger(HouseIndex)
        Buffer.WriteInteger(Player(HouseIndex).Character(TempPlayer(HouseIndex).CurChar).House.FurnitureCount)
        If Player(HouseIndex).Character(TempPlayer(HouseIndex).CurChar).House.FurnitureCount > 0 Then
            For i = 1 To Player(HouseIndex).Character(TempPlayer(HouseIndex).CurChar).House.FurnitureCount
                Buffer.WriteInteger(Player(HouseIndex).Character(TempPlayer(HouseIndex).CurChar).House.Furniture(i).ItemNum)
                Buffer.WriteInteger(Player(HouseIndex).Character(TempPlayer(HouseIndex).CurChar).House.Furniture(i).X)
                Buffer.WriteInteger(Player(HouseIndex).Character(TempPlayer(HouseIndex).CurChar).House.Furniture(i).Y)
            Next
        End If

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If Player(i).Character(TempPlayer(i).CurChar).InHouse = HouseIndex Then
                    SendDataTo(i, Buffer.ToArray)
                End If
            End If
        Next

        Buffer = Nothing

    End Sub
#End Region

End Module
