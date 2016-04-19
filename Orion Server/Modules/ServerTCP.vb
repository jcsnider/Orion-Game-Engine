Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Public Class Client
    Public index As Long
    Public IP As String
    Public Socket As TcpClient
    Public myStream As NetworkStream
    Public Closing As Boolean
    Private readBuff As Byte()

    Public Sub Start()
        Socket.SendBufferSize = 4096
        Socket.ReceiveBufferSize = 4096
        myStream = Socket.GetStream()
        ReDim readBuff(Socket.ReceiveBufferSize - 1)
        myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, AddressOf OnReceiveData, Nothing)
        Closing = False
    End Sub

    Private Sub OnReceiveData(ar As IAsyncResult)
        Try
            Dim readbytes As Integer = myStream.EndRead(ar)
            If Socket Is Nothing Then Exit Sub
            If (readbytes <= 0) Then
                CloseSocket(index) 'Disconnect
                Exit Sub
            End If
            Dim newBytes As Byte()
            ReDim newBytes(readbytes - 1)
            Buffer.BlockCopy(readBuff, 0, newBytes, 0, readbytes)
            HandleData(index, newBytes)
            If Socket Is Nothing Then Exit Sub
            myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, AddressOf OnReceiveData, Nothing)
        Catch ex As Exception
            CloseSocket(index) 'Disconnect
            Exit Sub
        End Try

    End Sub
End Class
Module ServerTCP
    Public Clients() As Client
    Public ServerSocket As TcpListener

    Public Sub InitNetwork()
        ServerSocket = New TcpListener(IPAddress.Any, Options.Port)
        ServerSocket.Start()
        ServerSocket.BeginAcceptTcpClient(AddressOf OnClientConnect, Nothing)
    End Sub

    Private Sub OnClientConnect(ar As IAsyncResult)
        Dim client As TcpClient = ServerSocket.EndAcceptTcpClient(ar)
        client.NoDelay = False
        ServerSocket.BeginAcceptTcpClient(AddressOf OnClientConnect, Nothing)
        For i = 1 To MAX_PLAYERS
            If Clients(i).Socket Is Nothing Then
                Clients(i).Socket = client
                Clients(i).index = i
                Clients(i).IP = DirectCast(client.Client.RemoteEndPoint, IPEndPoint).Address.ToString
                Clients(i).Start()
                TextAdd("Connection received from " & Clients(i).IP)
                NeedToUpDatePlayerList = True
                SendNews(i)
                Exit For
            End If
        Next
    End Sub

    Public Sub SendDataTo(ByVal Index As Long, ByRef Data() As Byte)
        Try
            If Not IsConnected(Index) Then Exit Sub
            Dim buffer As ByteBuffer
            buffer = New ByteBuffer
            buffer.WriteLong((UBound(Data) - LBound(Data)) + 1)
            buffer.WriteBytes(Data)
            Clients(Index).myStream.BeginWrite(buffer.ToArray, 0, buffer.ToArray.Length, Nothing, Nothing)
            buffer = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SendDataToAll(ByRef data() As Byte)
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                Call SendDataTo(i, data)
            End If

        Next
    End Sub
    Sub SendDataToAllBut(ByVal Index As Long, ByRef Data() As Byte)
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If i <> Index Then
                    Call SendDataTo(i, Data)
                End If
            End If

        Next

    End Sub
    Sub SendDataToMapBut(ByVal Index As Long, ByVal MapNum As Long, ByRef Data() As Byte)
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerMap(i) = MapNum Then
                    If i <> Index Then
                        Call SendDataTo(i, Data)
                    End If
                End If
            End If

        Next

    End Sub
    Sub SendDataToMap(ByVal MapNum As Long, ByRef Data() As Byte)
        Dim i As Long

        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerMap(i) = MapNum Then
                    Call SendDataTo(i, Data)
                End If
            End If

        Next

    End Sub
    Private Function GetIPAddr() As String
        'This function will return the users IP address as a string
        'Note: If the user is on a machine with multiple IPs, it will ONLY
        '   return the TOP element in the list (.AddressList(0))
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = Dns.GetHostName()
        strIPAddress = Dns.GetHostEntry(strHostName).AddressList(0).ToString()
        GetIPAddr = strIPAddress
    End Function
    Public Sub AlertMsg(ByVal Index As Long, ByVal Msg As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SAlertMsg)
        Buffer.WriteString(Msg)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub
    Public Sub GlobalMsg(ByVal Msg As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SGlobalMsg)
        Buffer.WriteString(Msg)
        SendDataToAll(Buffer.ToArray)

        Buffer = Nothing
    End Sub
    Public Sub PlayerMsg(ByVal Index As Long, ByVal Msg As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SPlayerMsg)
        Buffer.WriteString(Msg)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub
    Sub SendAnimations(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(i).Name)) > 0 Then
                Call SendUpdateAnimationTo(Index, i)
            End If

        Next

    End Sub
    Sub SendNewCharClasses(ByVal Index As Long)
        Dim i As Long, n As Long, q As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SNewCharClasses)
        Buffer.WriteLong(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(GetClassName(i))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)
            ' send array size
            Buffer.WriteLong(n)
            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)
            ' send array size
            Buffer.WriteLong(n)
            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteLong(Classes(i).Stat(Stats.strength))
            Buffer.WriteLong(Classes(i).Stat(Stats.endurance))
            Buffer.WriteLong(Classes(i).Stat(Stats.vitality))
            Buffer.WriteLong(Classes(i).Stat(Stats.willpower))
            Buffer.WriteLong(Classes(i).Stat(Stats.intelligence))
            Buffer.WriteLong(Classes(i).Stat(Stats.spirit))
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Public Function GetClientIP(ByVal index As Long) As String
        GetClientIP = Clients(index).IP
    End Function
    Sub SendCloseTrade(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SCloseTrade)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendEXP(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SPlayerEXP)
        Buffer.WriteLong(Index)
        Buffer.WriteLong(GetPlayerExp(Index))
        Buffer.WriteLong(GetPlayerNextLevel(Index))

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub CloseSocket(ByVal Index As Long)
        Try
            If Index > 0 Then
                If (Clients(Index).Closing = True) Then Exit Sub
                Clients(Index).Closing = True
                Call LeftGame(Index)
                Call TextAdd("Connection from " & GetPlayerIP(Index) & " has been terminated.")
                Clients(Index).Socket.Close()
                Clients(Index).Socket = Nothing
                Call ClearPlayer(Index)
                NeedToUpDatePlayerList = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function IsPlaying(ByVal Index As Long) As Boolean
        IsPlaying = False
        If TempPlayer(Index).InGame = True Then
            IsPlaying = True
        End If

    End Function

    Function IsLoggedIn(ByVal Index As Long) As Boolean
        IsLoggedIn = False
        If Len(Trim$(Player(Index).Login)) > 0 Then
            IsLoggedIn = True
        End If

    End Function
    Public Function IsConnected(ByVal Index As Long) As Boolean
        If Clients(Index).Socket.Connected Then
            IsConnected = True
        Else
            IsConnected = False
        End If
    End Function
    Function IsMultiAccounts(ByVal Login As String) As Boolean
        Dim i As Long

        IsMultiAccounts = False

        For i = 1 To MAX_PLAYERS
            If LCase$(Trim$(Player(i).Login)) = LCase$(Login) Then
                IsMultiAccounts = True
                Exit Function
            Else
                IsMultiAccounts = False
                Exit Function
            End If

        Next

    End Function
    Sub SendLoginOk(ByVal index As Long)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteLong(ServerPackets.SLoginOk)
        buffer.WriteLong(index)
        SendDataTo(index, buffer.ToArray)
        buffer = Nothing
    End Sub
    Sub SendClasses(ByVal Index As Long)
        Dim i As Long, n As Long, q As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SClassesData)
        Buffer.WriteLong(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(GetClassName(i))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)

            ' send array size
            Buffer.WriteLong(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)

            ' send array size
            Buffer.WriteLong(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteLong(Classes(i).Stat(Stats.strength))
            Buffer.WriteLong(Classes(i).Stat(Stats.endurance))
            Buffer.WriteLong(Classes(i).Stat(Stats.vitality))
            Buffer.WriteLong(Classes(i).Stat(Stats.intelligence))
            Buffer.WriteLong(Classes(i).Stat(Stats.willpower))
            Buffer.WriteLong(Classes(i).Stat(Stats.spirit))
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendInventory(ByVal Index As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SPlayerInv)

        For i = 1 To MAX_INV
            Buffer.WriteLong(GetPlayerInvItemNum(Index, i))
            Buffer.WriteLong(GetPlayerInvItemValue(Index, i))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendItems(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_ITEMS

            If Len(Trim$(Item(i).Name)) > 0 Then
                SendUpdateItemTo(Index, i)
            End If

        Next

    End Sub
    Sub SendUpdateItemTo(ByVal Index As Long, ByVal itemNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateItem)
        Buffer.WriteLong(itemNum)
        Buffer.WriteLong(Item(itemNum).AccessReq)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteLong(Item(itemNum).Animation)
        Buffer.WriteLong(Item(itemNum).BindType)
        Buffer.WriteLong(Item(itemNum).ClassReq)
        Buffer.WriteLong(Item(itemNum).Data1)
        Buffer.WriteLong(Item(itemNum).Data2)
        Buffer.WriteLong(Item(itemNum).Data3)
        Buffer.WriteLong(Item(itemNum).Handed)
        Buffer.WriteLong(Item(itemNum).LevelReq)
        Buffer.WriteLong(Item(itemNum).Mastery)
        Buffer.WriteString(Item(itemNum).Name)
        Buffer.WriteLong(Item(itemNum).Paperdoll)
        Buffer.WriteLong(Item(itemNum).Pic)
        Buffer.WriteLong(Item(itemNum).price)
        Buffer.WriteLong(Item(itemNum).Rarity)
        Buffer.WriteLong(Item(itemNum).Speed)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteLong(Item(itemNum).Type)

        'Housing
        Buffer.WriteLong(Item(itemNum).FurnitureWidth)
        Buffer.WriteLong(Item(itemNum).FurnitureHeight)

        For i = 1 To 3
            For x = 1 To 3
                Buffer.WriteLong(Item(itemNum).FurnitureBlocks(i, x))
                Buffer.WriteLong(Item(itemNum).FurnitureFringe(i, x))
            Next
        Next

        Buffer.WriteLong(Item(itemNum).KnockBack)
        Buffer.WriteLong(Item(itemNum).KnockBackTiles)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendUpdateItemToAll(ByVal itemNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateItem)
        Buffer.WriteLong(itemNum)
        Buffer.WriteLong(Item(itemNum).AccessReq)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteLong(Item(itemNum).Animation)
        Buffer.WriteLong(Item(itemNum).BindType)
        Buffer.WriteLong(Item(itemNum).ClassReq)
        Buffer.WriteLong(Item(itemNum).Data1)
        Buffer.WriteLong(Item(itemNum).Data2)
        Buffer.WriteLong(Item(itemNum).Data3)
        Buffer.WriteLong(Item(itemNum).Handed)
        Buffer.WriteLong(Item(itemNum).LevelReq)
        Buffer.WriteLong(Item(itemNum).Mastery)
        Buffer.WriteString(Item(itemNum).Name)
        Buffer.WriteLong(Item(itemNum).Paperdoll)
        Buffer.WriteLong(Item(itemNum).Pic)
        Buffer.WriteLong(Item(itemNum).price)
        Buffer.WriteLong(Item(itemNum).Rarity)
        Buffer.WriteLong(Item(itemNum).Speed)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteLong(Item(itemNum).Type)

        'Housing
        Buffer.WriteLong(Item(itemNum).FurnitureWidth)
        Buffer.WriteLong(Item(itemNum).FurnitureHeight)

        For i = 1 To 3
            For x = 1 To 3
                Buffer.WriteLong(Item(itemNum).FurnitureBlocks(i, x))
                Buffer.WriteLong(Item(itemNum).FurnitureFringe(i, x))
            Next
        Next

        Buffer.WriteLong(Item(itemNum).KnockBack)
        Buffer.WriteLong(Item(itemNum).KnockBackTiles)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendLeftGame(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SLeftMap)
        Buffer.WriteLong(Index)
        Buffer.WriteString("")
        Buffer.WriteLong(0)
        Buffer.WriteLong(0)
        Buffer.WriteLong(0)
        Buffer.WriteLong(0)
        Buffer.WriteLong(0)
        Buffer.WriteLong(0)
        Buffer.WriteLong(0)
        SendDataToAllBut(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendMapEquipment(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapWornEq)
        Buffer.WriteLong(Index)
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Armor))
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Weapon))
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Helmet))
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Shield))

        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendMapEquipmentTo(ByVal PlayerNum As Long, ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapWornEq)
        Buffer.WriteLong(PlayerNum)
        Buffer.WriteLong(GetPlayerEquipment(PlayerNum, Equipment.Armor))
        Buffer.WriteLong(GetPlayerEquipment(PlayerNum, Equipment.Weapon))
        Buffer.WriteLong(GetPlayerEquipment(PlayerNum, Equipment.Helmet))
        Buffer.WriteLong(GetPlayerEquipment(PlayerNum, Equipment.Shield))

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendNpcs(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_NPCS

            If Len(Trim$(Npc(i).Name)) > 0 Then
                Call SendUpdateNpcTo(Index, i)
            End If

        Next

    End Sub
    Sub SendUpdateNpcTo(ByVal Index As Long, ByVal NpcNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateNpc)
        Buffer.WriteLong(NpcNum)
        Buffer.WriteLong(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteLong(Npc(NpcNum).Behaviour)
        Buffer.WriteLong(Npc(NpcNum).DropChance)
        Buffer.WriteLong(Npc(NpcNum).DropItem)
        Buffer.WriteLong(Npc(NpcNum).DropItemValue)
        Buffer.WriteLong(Npc(NpcNum).Exp)
        Buffer.WriteLong(Npc(NpcNum).Faction)
        Buffer.WriteLong(Npc(NpcNum).HP)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteLong(Npc(NpcNum).Range)
        Buffer.WriteLong(Npc(NpcNum).SpawnSecs)
        Buffer.WriteLong(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteLong(Npc(NpcNum).QuestNum)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendUpdateNpcToAll(ByVal NpcNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateNpc)
        Buffer.WriteLong(NpcNum)
        Buffer.WriteLong(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteLong(Npc(NpcNum).Behaviour)
        Buffer.WriteLong(Npc(NpcNum).DropChance)
        Buffer.WriteLong(Npc(NpcNum).DropItem)
        Buffer.WriteLong(Npc(NpcNum).DropItemValue)
        Buffer.WriteLong(Npc(NpcNum).Exp)
        Buffer.WriteLong(Npc(NpcNum).Faction)
        Buffer.WriteLong(Npc(NpcNum).HP)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteLong(Npc(NpcNum).Range)
        Buffer.WriteLong(Npc(NpcNum).SpawnSecs)
        Buffer.WriteLong(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Stat_Count - 1
            Buffer.WriteLong(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteLong(Npc(NpcNum).QuestNum)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendResourceCacheTo(ByVal Index As Long, ByVal Resource_num As Long)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SResourceCache)
        Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).Resource_Count)

        If ResourceCache(GetPlayerMap(Index)).Resource_Count > 0 Then

            For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count
                Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).ResourceData(i).ResourceState)
                Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).ResourceData(i).x)
                Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).ResourceData(i).y)
            Next

        End If

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendResources(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(i).Name)) > 0 Then
                Call SendUpdateResourceTo(Index, i)
            End If

        Next

    End Sub
    Sub SendUpdateResourceTo(ByVal Index As Long, ByVal ResourceNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateResource)
        Buffer.WriteLong(ResourceNum)
        Buffer.WriteLong(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteLong(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteLong(Resource(ResourceNum).health)
        Buffer.WriteLong(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteLong(Resource(ResourceNum).ResourceImage)
        Buffer.WriteLong(Resource(ResourceNum).ResourceType)
        Buffer.WriteLong(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteLong(Resource(ResourceNum).ToolRequired)
        Buffer.WriteLong(Resource(ResourceNum).Walkthrough)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendShops(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_SHOPS

            If Len(Trim$(Shop(i).Name)) > 0 Then
                Call SendUpdateShopTo(Index, i)
            End If

        Next

    End Sub
    Sub SendUpdateShopTo(ByVal Index As Long, ByVal shopNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer


        Buffer.WriteLong(ServerPackets.SUpdateShop)
        Buffer.WriteLong(shopNum)
        Buffer.WriteLong(Shop(shopNum).BuyRate)
        Buffer.WriteString(Shop(shopNum).Name)

        For i = 0 To MAX_TRADES
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costitem)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costvalue)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendUpdateShopToAll(ByVal shopNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer


        Buffer.WriteLong(ServerPackets.SUpdateShop)
        Buffer.WriteLong(shopNum)
        Buffer.WriteLong(Shop(shopNum).BuyRate)
        Buffer.WriteString(Shop(shopNum).Name)

        For i = 0 To MAX_TRADES
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costitem)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costvalue)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendSpells(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_SPELLS

            If Len(Trim$(Spell(i).Name)) > 0 Then
                SendUpdateSpellTo(Index, i)
            End If

        Next

    End Sub
    Sub SendUpdateSpellTo(ByVal Index As Long, ByVal spellnum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateSpell)
        Buffer.WriteLong(spellnum)
        Buffer.WriteLong(Spell(spellnum).AccessReq)
        Buffer.WriteLong(Spell(spellnum).AoE)
        Buffer.WriteLong(Spell(spellnum).CastAnim)
        Buffer.WriteLong(Spell(spellnum).CastTime)
        Buffer.WriteLong(Spell(spellnum).CDTime)
        Buffer.WriteLong(Spell(spellnum).ClassReq)
        Buffer.WriteLong(Spell(spellnum).Dir)
        Buffer.WriteLong(Spell(spellnum).Duration)
        Buffer.WriteLong(Spell(spellnum).Icon)
        Buffer.WriteLong(Spell(spellnum).Interval)
        Buffer.WriteLong(Spell(spellnum).IsAoE)
        Buffer.WriteLong(Spell(spellnum).LevelReq)
        Buffer.WriteLong(Spell(spellnum).Map)
        Buffer.WriteLong(Spell(spellnum).MPCost)
        Buffer.WriteString(Spell(spellnum).Name)
        Buffer.WriteLong(Spell(spellnum).range)
        Buffer.WriteLong(Spell(spellnum).SpellAnim)
        Buffer.WriteLong(Spell(spellnum).StunDuration)
        Buffer.WriteLong(Spell(spellnum).Type)
        Buffer.WriteLong(Spell(spellnum).Vital)
        Buffer.WriteLong(Spell(spellnum).x)
        Buffer.WriteLong(Spell(spellnum).y)

        'projectiles
        Buffer.WriteLong(Spell(spellnum).IsProjectile)
        Buffer.WriteLong(Spell(spellnum).Projectile)

        Buffer.WriteLong(Spell(spellnum).KnockBack)
        Buffer.WriteLong(Spell(spellnum).KnockBackTiles)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendUpdateSpellToAll(ByVal spellnum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateSpell)
        Buffer.WriteLong(spellnum)
        Buffer.WriteLong(Spell(spellnum).AccessReq)
        Buffer.WriteLong(Spell(spellnum).AoE)
        Buffer.WriteLong(Spell(spellnum).CastAnim)
        Buffer.WriteLong(Spell(spellnum).CastTime)
        Buffer.WriteLong(Spell(spellnum).CDTime)
        Buffer.WriteLong(Spell(spellnum).ClassReq)
        Buffer.WriteLong(Spell(spellnum).Dir)
        Buffer.WriteLong(Spell(spellnum).Duration)
        Buffer.WriteLong(Spell(spellnum).Icon)
        Buffer.WriteLong(Spell(spellnum).Interval)
        Buffer.WriteLong(Spell(spellnum).IsAoE)
        Buffer.WriteLong(Spell(spellnum).LevelReq)
        Buffer.WriteLong(Spell(spellnum).Map)
        Buffer.WriteLong(Spell(spellnum).MPCost)
        Buffer.WriteString(Spell(spellnum).Name)
        Buffer.WriteLong(Spell(spellnum).range)
        Buffer.WriteLong(Spell(spellnum).SpellAnim)
        Buffer.WriteLong(Spell(spellnum).StunDuration)
        Buffer.WriteLong(Spell(spellnum).Type)
        Buffer.WriteLong(Spell(spellnum).Vital)
        Buffer.WriteLong(Spell(spellnum).x)
        Buffer.WriteLong(Spell(spellnum).y)

        'projectiles
        Buffer.WriteLong(Spell(spellnum).IsProjectile)
        Buffer.WriteLong(Spell(spellnum).Projectile)

        Buffer.WriteLong(Spell(spellnum).KnockBack)
        Buffer.WriteLong(Spell(spellnum).KnockBackTiles)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendStats(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SPlayerStats)
        Buffer.WriteLong(Index)
        Buffer.WriteLong(GetPlayerStat(Index, Stats.strength))
        Buffer.WriteLong(GetPlayerStat(Index, Stats.endurance))
        Buffer.WriteLong(GetPlayerStat(Index, Stats.vitality))
        Buffer.WriteLong(GetPlayerStat(Index, Stats.willpower))
        Buffer.WriteLong(GetPlayerStat(Index, Stats.intelligence))
        Buffer.WriteLong(GetPlayerStat(Index, Stats.spirit))
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateAnimationTo(ByVal Index As Long, ByVal AnimationNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateAnimation)
        Buffer.WriteLong(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteLong(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteLong(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteLong(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteLong(Animation(AnimationNum).Sprite(i))
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateAnimationToAll(ByVal AnimationNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateAnimation)
        Buffer.WriteLong(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteLong(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteLong(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteLong(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteLong(Animation(AnimationNum).Sprite(i))
        Next

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendVital(ByVal Index As Long, ByVal Vital As Vitals)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Select Case Vital
            Case Vitals.HP
                Buffer.WriteLong(ServerPackets.SPlayerHp)
                Buffer.WriteLong(GetPlayerMaxVital(Index, Vitals.HP))
                Buffer.WriteLong(GetPlayerVital(Index, Vitals.HP))
            Case Vitals.MP
                Buffer.WriteLong(ServerPackets.SPlayerMp)
                Buffer.WriteLong(GetPlayerMaxVital(Index, Vitals.MP))
                Buffer.WriteLong(GetPlayerVital(Index, Vitals.MP))
            Case Vitals.SP
                Buffer.WriteLong(ServerPackets.SPlayerSp)
                Buffer.WriteLong(GetPlayerMaxVital(Index, Vitals.SP))
                Buffer.WriteLong(GetPlayerVital(Index, Vitals.SP))
        End Select

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendWelcome(ByVal Index As Long)

        ' Send them MOTD
        If Len(Options.MOTD) > 0 Then
            PlayerMsg(Index, Options.MOTD)
        End If

        ' Send whos online
        SendWhosOnline(Index)
    End Sub
    Sub SendWhosOnline(ByVal Index As Long)
        Dim s As String
        Dim n As Long
        Dim i As Long
        s = ""
        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If i <> Index Then
                    s = s & GetPlayerName(i) & ", "
                    n = n + 1
                End If
            End If

        Next

        If n = 0 Then
            s = "There are no other players online."
        Else
            s = Mid$(s, 1, Len(s) - 2)
            s = "There are " & n & " other players online: " & s & "."
        End If

        PlayerMsg(Index, s)
    End Sub

    Sub SendWornEquipment(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SPlayerWornEq)
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Armor))
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Weapon))
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Helmet))
        Buffer.WriteLong(GetPlayerEquipment(Index, Equipment.Shield))
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapData(ByVal Index As Long, ByVal MapNum As Long, ByVal SendMap As Boolean)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Dim data() As Byte

        If SendMap Then
            Buffer.WriteLong(1)
            Buffer.WriteLong(MapNum)
            Buffer.WriteString(Map(MapNum).Name)
            Buffer.WriteString(Map(MapNum).Music)
            Buffer.WriteLong(Map(MapNum).Revision)
            Buffer.WriteLong(Map(MapNum).Moral)
            Buffer.WriteLong(Map(MapNum).Tileset)
            Buffer.WriteLong(Map(MapNum).Up)
            Buffer.WriteLong(Map(MapNum).Down)
            Buffer.WriteLong(Map(MapNum).Left)
            Buffer.WriteLong(Map(MapNum).Right)
            Buffer.WriteLong(Map(MapNum).BootMap)
            Buffer.WriteLong(Map(MapNum).BootX)
            Buffer.WriteLong(Map(MapNum).BootY)
            Buffer.WriteLong(Map(MapNum).MaxX)
            Buffer.WriteLong(Map(MapNum).MaxY)

            For i = 1 To MAX_MAP_NPCS
                Buffer.WriteLong(Map(MapNum).Npc(i))
            Next

            For x = 0 To Map(MapNum).MaxX
                For y = 0 To Map(MapNum).MaxY
                    Buffer.WriteLong(Map(MapNum).Tile(x, y).Data1)
                    Buffer.WriteLong(Map(MapNum).Tile(x, y).Data2)
                    Buffer.WriteLong(Map(MapNum).Tile(x, y).Data3)
                    Buffer.WriteLong(Map(MapNum).Tile(x, y).DirBlock)
                    For i = 0 To MapLayer.Layer_Count - 1
                        Buffer.WriteLong(Map(MapNum).Tile(x, y).Layer(i).Tileset)
                        Buffer.WriteLong(Map(MapNum).Tile(x, y).Layer(i).x)
                        Buffer.WriteLong(Map(MapNum).Tile(x, y).Layer(i).y)
                        Buffer.WriteLong(Map(MapNum).Tile(x, y).Autotile(i))
                    Next
                    Buffer.WriteLong(Map(MapNum).Tile(x, y).Type)

                Next
            Next

            'Event Data
            Buffer.WriteLong(Map(MapNum).EventCount)
            If Map(MapNum).EventCount > 0 Then
                For i = 1 To Map(MapNum).EventCount
                    With Map(MapNum).Events(i)
                        Buffer.WriteString(Trim$(.Name))
                        Buffer.WriteLong(.Globals)
                        Buffer.WriteLong(.X)
                        Buffer.WriteLong(.Y)
                        Buffer.WriteLong(.PageCount)
                    End With
                    If Map(MapNum).Events(i).PageCount > 0 Then
                        For X = 1 To Map(MapNum).Events(i).PageCount
                            With Map(MapNum).Events(i).Pages(X)
                                Buffer.WriteLong(.chkVariable)
                                Buffer.WriteLong(.VariableIndex)
                                Buffer.WriteLong(.VariableCondition)
                                Buffer.WriteLong(.VariableCompare)
                                Buffer.WriteLong(.chkSwitch)
                                Buffer.WriteLong(.SwitchIndex)
                                Buffer.WriteLong(.SwitchCompare)
                                Buffer.WriteLong(.chkHasItem)
                                Buffer.WriteLong(.HasItemIndex)
                                Buffer.WriteLong(.HasItemAmount)
                                Buffer.WriteLong(.chkSelfSwitch)
                                Buffer.WriteLong(.SelfSwitchIndex)
                                Buffer.WriteLong(.SelfSwitchCompare)
                                Buffer.WriteLong(.GraphicType)
                                Buffer.WriteLong(.Graphic)
                                Buffer.WriteLong(.GraphicX)
                                Buffer.WriteLong(.GraphicY)
                                Buffer.WriteLong(.GraphicX2)
                                Buffer.WriteLong(.GraphicY2)
                                Buffer.WriteLong(.MoveType)
                                Buffer.WriteLong(.MoveSpeed)
                                Buffer.WriteLong(.MoveFreq)
                                Buffer.WriteLong(.MoveRouteCount)
                                Buffer.WriteLong(.IgnoreMoveRoute)
                                Buffer.WriteLong(.RepeatMoveRoute)
                                If .MoveRouteCount > 0 Then
                                    For Y = 1 To .MoveRouteCount
                                        Buffer.WriteLong(.MoveRoute(Y).Index)
                                        Buffer.WriteLong(.MoveRoute(Y).Data1)
                                        Buffer.WriteLong(.MoveRoute(Y).Data2)
                                        Buffer.WriteLong(.MoveRoute(Y).Data3)
                                        Buffer.WriteLong(.MoveRoute(Y).Data4)
                                        Buffer.WriteLong(.MoveRoute(Y).Data5)
                                        Buffer.WriteLong(.MoveRoute(Y).Data6)
                                    Next
                                End If
                                Buffer.WriteLong(.WalkAnim)
                                Buffer.WriteLong(.DirFix)
                                Buffer.WriteLong(.WalkThrough)
                                Buffer.WriteLong(.ShowName)
                                Buffer.WriteLong(.Trigger)
                                Buffer.WriteLong(.CommandListCount)
                                Buffer.WriteLong(.Position)
                                Buffer.WriteLong(.QuestNum)
                            End With
                            If Map(MapNum).Events(i).Pages(X).CommandListCount > 0 Then
                                For Y = 1 To Map(MapNum).Events(i).Pages(X).CommandListCount
                                    Buffer.WriteLong(Map(MapNum).Events(i).Pages(X).CommandList(Y).CommandCount)
                                    Buffer.WriteLong(Map(MapNum).Events(i).Pages(X).CommandList(Y).ParentList)
                                    If Map(MapNum).Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                        For z = 1 To Map(MapNum).Events(i).Pages(X).CommandList(Y).CommandCount
                                            With Map(MapNum).Events(i).Pages(X).CommandList(Y).Commands(z)
                                                Buffer.WriteLong(.Index)
                                                Buffer.WriteString(Trim$(.Text1))
                                                Buffer.WriteString(Trim$(.Text2))
                                                Buffer.WriteString(Trim$(.Text3))
                                                Buffer.WriteString(Trim$(.Text4))
                                                Buffer.WriteString(Trim$(.Text5))
                                                Buffer.WriteLong(.Data1)
                                                Buffer.WriteLong(.Data2)
                                                Buffer.WriteLong(.Data3)
                                                Buffer.WriteLong(.Data4)
                                                Buffer.WriteLong(.Data5)
                                                Buffer.WriteLong(.Data6)
                                                Buffer.WriteLong(.ConditionalBranch.CommandList)
                                                Buffer.WriteLong(.ConditionalBranch.Condition)
                                                Buffer.WriteLong(.ConditionalBranch.Data1)
                                                Buffer.WriteLong(.ConditionalBranch.Data2)
                                                Buffer.WriteLong(.ConditionalBranch.Data3)
                                                Buffer.WriteLong(.ConditionalBranch.ElseCommandList)
                                                Buffer.WriteLong(.MoveRouteCount)
                                                If .MoveRouteCount > 0 Then
                                                    For w = 1 To .MoveRouteCount
                                                        Buffer.WriteLong(.MoveRoute(w).Index)
                                                        Buffer.WriteLong(.MoveRoute(w).Data1)
                                                        Buffer.WriteLong(.MoveRoute(w).Data2)
                                                        Buffer.WriteLong(.MoveRoute(w).Data3)
                                                        Buffer.WriteLong(.MoveRoute(w).Data4)
                                                        Buffer.WriteLong(.MoveRoute(w).Data5)
                                                        Buffer.WriteLong(.MoveRoute(w).Data6)
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
        Else
            Buffer.WriteLong(0)
        End If

        For i = 1 To MAX_MAP_ITEMS
            Buffer.WriteLong(MapItem(MapNum, i).Num)
            Buffer.WriteLong(MapItem(MapNum, i).Value)
            Buffer.WriteLong(MapItem(MapNum, i).x)
            Buffer.WriteLong(MapItem(MapNum, i).y)
        Next

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Num)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).x)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).y)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Dir)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Vital(Vitals.HP))
        Next


        'send Resource cache
        If ResourceCache(GetPlayerMap(Index)).Resource_Count > 0 Then
            Buffer.WriteLong(1)
            Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).Resource_Count)

            For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count
                Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).ResourceData(i).ResourceState)
                Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).ResourceData(i).x)
                Buffer.WriteLong(ResourceCache(GetPlayerMap(Index)).ResourceData(i).y)
            Next
        Else
            Buffer.WriteLong(0)
        End If

        data = Compress(Buffer.ToArray)
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapData)
        Buffer.WriteBytes(data)
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Sub SendJoinMap(ByVal Index As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        ' Send all players on current map to index
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If i <> Index Then
                    If GetPlayerMap(i) = GetPlayerMap(Index) Then
                        SendDataTo(Index, PlayerData(i))
                    End If
                End If
            End If
        Next

        ' Send index's player data to everyone on the map including himself
        SendDataToMap(GetPlayerMap(Index), PlayerData(Index))

        Buffer = Nothing
    End Sub

    Function PlayerData(ByVal Index As Long) As Byte()
        Dim Buffer As ByteBuffer, i As Long
        PlayerData = Nothing
        If Index > MAX_PLAYERS Then Exit Function
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SPlayerData)
        Buffer.WriteLong(Index)
        Buffer.WriteString(GetPlayerName(Index))
        Buffer.WriteLong(GetPlayerClass(Index))
        Buffer.WriteLong(GetPlayerLevel(Index))
        Buffer.WriteLong(GetPlayerPOINTS(Index))
        Buffer.WriteLong(GetPlayerSprite(Index))
        Buffer.WriteLong(GetPlayerMap(Index))
        Buffer.WriteLong(GetPlayerX(Index))
        Buffer.WriteLong(GetPlayerY(Index))
        Buffer.WriteLong(GetPlayerDir(Index))
        Buffer.WriteLong(GetPlayerAccess(Index))
        Buffer.WriteLong(GetPlayerPK(Index))

        For i = 1 To Stats.Stat_Count - 1
            Buffer.WriteLong(GetPlayerStat(Index, i))
        Next

        Buffer.WriteLong(Player(Index).InHouse)

        PlayerData = Buffer.ToArray()

        Buffer = Nothing
    End Function
    Sub SendMapItemsTo(ByVal Index As Long, ByVal MapNum As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapItemData)

        For i = 1 To MAX_MAP_ITEMS
            Buffer.WriteLong(MapItem(MapNum, i).Num)
            Buffer.WriteLong(MapItem(MapNum, i).Value)
            Buffer.WriteLong(MapItem(MapNum, i).x)
            Buffer.WriteLong(MapItem(MapNum, i).y)
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendMapNpcsTo(ByVal Index As Long, ByVal MapNum As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapNpcData)

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Num)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).x)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).y)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Dir)
            Buffer.WriteLong(MapNpc(MapNum).Npc(i).Vital(Vitals.HP))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendPlayerXY(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SPlayerXY)
        Buffer.WriteLong(GetPlayerX(Index))
        Buffer.WriteLong(GetPlayerY(Index))
        Buffer.WriteLong(GetPlayerDir(Index))
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Sub SendPlayerMove(ByVal Index As Long, ByVal movement As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SPlayerMove)
        Buffer.WriteLong(Index)
        Buffer.WriteLong(GetPlayerX(Index))
        Buffer.WriteLong(GetPlayerY(Index))
        Buffer.WriteLong(GetPlayerDir(Index))
        Buffer.WriteLong(movement)
        SendDataToMapBut(Index, GetPlayerMap(Index), Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendDoorAnimation(ByVal MapNum As Long, ByVal x As Long, ByVal y As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SDoorAnimation)
        Buffer.WriteLong(x)
        Buffer.WriteLong(y)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Sub SendMapKey(ByVal Index As Long, ByVal x As Long, ByVal y As Long, ByVal Value As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapKey)
        Buffer.WriteLong(x)
        Buffer.WriteLong(y)
        Buffer.WriteLong(Value)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
    Public Sub MapMsg(ByVal MapNum As Long, ByVal Msg As String, ByVal color As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapMsg)
        Buffer.WriteString(Msg)

        SendDataToMap(MapNum, Buffer.ToArray)

        Buffer = Nothing
    End Sub
    Sub SendActionMsg(ByVal MapNum As Long, ByVal message As String, ByVal color As Long, ByVal MsgType As Long, ByVal x As Long, ByVal y As Long, Optional ByVal PlayerOnlyNum As Long = 0)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SActionMsg)
        Buffer.WriteString(message)
        Buffer.WriteLong(color)
        Buffer.WriteLong(MsgType)
        Buffer.WriteLong(x)
        Buffer.WriteLong(y)

        If PlayerOnlyNum > 0 Then
            SendDataTo(PlayerOnlyNum, Buffer.ToArray())
        Else
            SendDataToMap(MapNum, Buffer.ToArray())
        End If

        Buffer = Nothing
    End Sub
    Sub SayMsg_Map(ByVal MapNum As Long, ByVal Index As Long, ByVal message As String, ByVal saycolour As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SSayMsg)
        Buffer.WriteString(GetPlayerName(Index))
        Buffer.WriteLong(GetPlayerAccess(Index))
        Buffer.WriteLong(GetPlayerPK(Index))
        Buffer.WriteString(message)
        Buffer.WriteString("[Map] ")
        Buffer.WriteLong(saycolour)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerData(ByVal Index As Long)
        SendDataToMap(GetPlayerMap(Index), PlayerData(Index))
    End Sub

    Sub SendUpdateResourceToAll(ByVal ResourceNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer


        Buffer.WriteLong(ServerPackets.SUpdateResource)
        Buffer.WriteLong(ResourceNum)

        Buffer.WriteLong(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteLong(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteLong(Resource(ResourceNum).health)
        Buffer.WriteLong(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteLong(Resource(ResourceNum).ResourceImage)
        Buffer.WriteLong(Resource(ResourceNum).ResourceType)
        Buffer.WriteLong(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteLong(Resource(ResourceNum).ToolRequired)
        Buffer.WriteLong(Resource(ResourceNum).Walkthrough)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendMapNpcVitals(ByVal MapNum As Long, ByVal MapNpcNum As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapNpcVitals)
        Buffer.WriteLong(MapNpcNum)

        For i = 1 To Vitals.Vital_Count - 1
            Buffer.WriteLong(MapNpc(MapNum).Npc(MapNpcNum).Vital(i))
        Next

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapKeyToMap(ByVal MapNum As Long, ByVal x As Long, ByVal y As Long, ByVal Value As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapKey)
        Buffer.WriteLong(x)
        Buffer.WriteLong(y)
        Buffer.WriteLong(Value)
        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendResourceCacheToMap(ByVal MapNum As Long, ByVal Resource_num As Long)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SResourceCache)
        Buffer.WriteLong(ResourceCache(MapNum).Resource_Count)

        If ResourceCache(MapNum).Resource_Count > 0 Then

            For i = 0 To ResourceCache(MapNum).Resource_Count
                Buffer.WriteLong(ResourceCache(MapNum).ResourceData(i).ResourceState)
                Buffer.WriteLong(ResourceCache(MapNum).ResourceData(i).x)
                Buffer.WriteLong(ResourceCache(MapNum).ResourceData(i).y)
            Next

        End If

        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendGameData(ByVal index As Long)
        Dim buffer As ByteBuffer
        Dim i As Long
        Dim data() As Byte
        buffer = New ByteBuffer

        buffer.WriteBytes(ClassData)

        i = 0

        For x = 1 To MAX_ITEMS
            If Len(Trim$(Item(x).Name)) > 0 Then
                i = i + 1
            End If
        Next

        'Write Number of Items it is Sending and then The Item Data
        buffer.WriteLong(i)
        buffer.WriteBytes(ItemsData)

        i = 0

        For x = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(x).Name)) > 0 Then
                i = i + 1
            End If

        Next

        buffer.WriteLong(i)
        buffer.WriteBytes(AnimationsData)

        i = 0

        For x = 1 To MAX_NPCS

            If Len(Trim$(Npc(x).Name)) > 0 Then
                i = i + 1
            End If

        Next

        buffer.WriteLong(i)
        buffer.WriteBytes(NpcsData)

        i = 0

        For x = 1 To MAX_SHOPS

            If Len(Trim$(Shop(x).Name)) > 0 Then
                i = i + 1
            End If

        Next

        buffer.WriteLong(i)
        buffer.WriteBytes(ShopsData)

        i = 0

        For x = 1 To MAX_SPELLS

            If Len(Trim$(Spell(x).Name)) > 0 Then
                i = i + 1
            End If

        Next

        buffer.WriteLong(i)
        buffer.WriteBytes(SpellsData)

        i = 0

        For x = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(x).Name)) > 0 Then
                i = i + 1
            End If

        Next

        buffer.WriteLong(i)
        buffer.WriteBytes(ResourcesData)

        data = buffer.ToArray

        data = Compress(data)

        buffer = New ByteBuffer

        buffer.WriteLong(ServerPackets.SGameData)

        buffer.WriteBytes(data)

        SendDataTo(index, buffer.ToArray)

        buffer = Nothing
    End Sub

    Sub SayMsg_Global(ByVal Index As Long, ByVal message As String, ByVal saycolour As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SSayMsg)
        Buffer.WriteString(GetPlayerName(Index))
        Buffer.WriteLong(GetPlayerAccess(Index))
        Buffer.WriteLong(GetPlayerPK(Index))
        Buffer.WriteString(message)
        Buffer.WriteString("[Global] ")
        Buffer.WriteLong(saycolour)

        SendDataToAll(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendInventoryUpdate(ByVal Index As Long, ByVal invSlot As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SPlayerInvUpdate)
        Buffer.WriteLong(invSlot)
        Buffer.WriteLong(GetPlayerInvItemNum(Index, invSlot))
        Buffer.WriteLong(GetPlayerInvItemValue(Index, invSlot))
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendAnimation(ByVal MapNum As Long, ByVal Anim As Long, ByVal x As Long, ByVal y As Long, Optional ByVal LockType As Byte = 0, Optional ByVal LockIndex As Long = 0)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SAnimation)
        Buffer.WriteLong(Anim)
        Buffer.WriteLong(x)
        Buffer.WriteLong(y)
        Buffer.WriteLong(LockType)
        Buffer.WriteLong(LockIndex)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendOpenShop(ByVal Index As Long, ByVal shopNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SOpenShop)
        Buffer.WriteLong(shopNum)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub ResetShopAction(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SResetShopAction)

        SendDataToAll(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendBank(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Dim i As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SBank)

        For i = 1 To MAX_BANK
            Buffer.WriteLong(Bank(Index).Item(i).Num)
            Buffer.WriteLong(Bank(Index).Item(i).Value)
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendClearSpellBuffer(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SClearSpellBuffer)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendClearTradeTimer(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SClearTradeTimer)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTrade(ByVal Index As Long, ByVal tradeTarget As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.STrade)
        Buffer.WriteLong(tradeTarget)
        Buffer.WriteString(Trim$(GetPlayerName(tradeTarget)))
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTradeUpdate(ByVal Index As Long, ByVal dataType As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Dim tradeTarget As Long
        Dim totalWorth As Long

        tradeTarget = TempPlayer(Index).InTrade

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.STradeUpdate)
        Buffer.WriteLong(dataType)

        If dataType = 0 Then ' own inventory
            For i = 1 To MAX_INV
                Buffer.WriteLong(TempPlayer(Index).TradeOffer(i).Num)
                Buffer.WriteLong(TempPlayer(Index).TradeOffer(i).Value)
                ' add total worth
                If TempPlayer(Index).TradeOffer(i).Num > 0 Then
                    totalWorth = totalWorth + Item(GetPlayerInvItemNum(Index, TempPlayer(Index).TradeOffer(i).Num)).price
                End If
            Next
        ElseIf dataType = 1 Then ' other inventory
            For i = 1 To MAX_INV
                Buffer.WriteLong(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num))
                Buffer.WriteLong(TempPlayer(tradeTarget).TradeOffer(i).Value)
                ' add total worth
                If GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num) > 0 Then
                    totalWorth = totalWorth + Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).price
                End If
            Next
        End If

        ' send total worth of trade
        Buffer.WriteLong(totalWorth)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTradeStatus(ByVal Index As Long, ByVal Status As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.STradeStatus)
        Buffer.WriteLong(Status)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapItemsToAll(ByVal MapNum As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SMapItemData)

        For i = 1 To MAX_MAP_ITEMS
            Buffer.WriteLong(MapItem(MapNum, i).Num)
            Buffer.WriteLong(MapItem(MapNum, i).Value)
            Buffer.WriteLong(MapItem(MapNum, i).x)
            Buffer.WriteLong(MapItem(MapNum, i).y)
        Next

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendStunned(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SStunned)
        Buffer.WriteLong(TempPlayer(Index).StunDuration)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendBlood(ByVal MapNum As Long, ByVal x As Long, ByVal y As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SBlood)
        Buffer.WriteLong(x)
        Buffer.WriteLong(y)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerSpells(ByVal Index As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SSpells)

        For i = 1 To MAX_PLAYER_SPELLS
            Buffer.WriteLong(GetPlayerSpell(Index, i))
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendCooldown(ByVal Index As Long, ByVal Slot As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SCooldown)
        Buffer.WriteLong(Slot)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Public Function GetIP() As String

        Dim uri_val As New Uri("http://ascensionforums.com/resources/myip.php")
        Dim request As HttpWebRequest = HttpWebRequest.Create(uri_val)

        request.Method = WebRequestMethods.Http.Get

        Try
            Dim response As HttpWebResponse = request.GetResponse()
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim myIP As String = reader.ReadToEnd()
            response.Close()
            Return myIP
        Catch e As Exception
            Return "127.0.0.1"
        End Try
    End Function

    Sub SendTarget(ByVal Index As Long, ByVal Target As Long, ByVal TargetType As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.STarget)
        Buffer.WriteLong(Target)
        Buffer.WriteLong(TargetType)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    'Mapreport
    Sub SendMapReport(ByVal Index As Long)
        Dim Buffer As ByteBuffer, I As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapReport)

        For I = 1 To MAX_MAPS
            Buffer.WriteString(Trim(Map(I).Name))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendAdminPanel(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SAdmin)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapNames(ByVal Index As Long)
        Dim Buffer As ByteBuffer, I As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapNames)

        For I = 1 To MAX_MAPS
            Buffer.WriteString(Trim(Map(I).Name))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendHotbar(ByVal Index As Long)
        Dim Buffer As ByteBuffer, i As Long

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SHotbar)

        For i = 1 To MAX_HOTBAR
            Buffer.WriteLong(Player(Index).Hotbar(i).Slot)
            Buffer.WriteLong(Player(Index).Hotbar(i).sType)
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendCritical(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SCritical)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendNews(ByVal Index As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SNews)

        Buffer.WriteString(Trim(GetFileContents(Application.StartupPath & "\news.txt")))

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
End Module
