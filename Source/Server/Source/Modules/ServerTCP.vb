Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Public Class Client
    Public Index As Integer
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

    Private Sub OnReceiveData(ByVal ar As IAsyncResult)
        Try
            Dim readbytes As Integer = myStream.EndRead(ar)
            If Socket Is Nothing Then Exit Sub
            If (readbytes <= 0) Then
                CloseSocket(Index) 'Disconnect
                Exit Sub
            End If
            Dim newBytes As Byte()
            ReDim newBytes(readbytes - 1)
            Buffer.BlockCopy(readBuff, 0, newBytes, 0, readbytes)
            HandleData(Index, newBytes)
            If Socket Is Nothing Then Exit Sub
            myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, AddressOf OnReceiveData, Nothing)
        Catch ex As Exception
            TextAdd(GetExceptionInfo(ex))
            CloseSocket(Index) 'Disconnect
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

    Private Sub OnClientConnect(ByVal ar As IAsyncResult)
        Dim client As TcpClient = ServerSocket.EndAcceptTcpClient(ar)
        client.NoDelay = False
        ServerSocket.BeginAcceptTcpClient(AddressOf OnClientConnect, Nothing)
        For i = 1 To MAX_PLAYERS
            If Clients(i).Socket Is Nothing Then
                Clients(i).Socket = client
                Clients(i).Index = i
                Clients(i).IP = DirectCast(client.Client.RemoteEndPoint, IPEndPoint).Address.ToString
                Clients(i).Start()
                TextAdd("Connection received from " & Clients(i).IP)
                SendNews(i)
                Exit For
            End If
        Next
    End Sub

    Public Sub SendDataTo(ByVal Index As Integer, ByRef Data() As Byte)
        Try
            If Not IsConnected(Index) Then Exit Sub
            Dim buffer As ByteBuffer
            buffer = New ByteBuffer
            buffer.WriteInteger((UBound(Data) - LBound(Data)) + 1)
            buffer.WriteBytes(Data)
            Clients(Index).myStream.BeginWrite(buffer.ToArray, 0, buffer.ToArray.Length, Nothing, Nothing)
            buffer = Nothing
        Catch ex As Exception
            TextAdd(GetExceptionInfo(ex))
        End Try
    End Sub

    Public Sub SendDataToAll(ByRef data() As Byte)
        Dim i As Integer

        For i = 1 To GetTotalPlayersOnline()

            If IsPlaying(i) Then
                SendDataTo(i, data)
            End If

        Next
    End Sub

    Sub SendDataToAllBut(ByVal Index As Integer, ByRef Data() As Byte)
        Dim i As Integer

        For i = 1 To GetTotalPlayersOnline()

            If IsPlaying(i) Then
                If i <> Index Then
                    SendDataTo(i, Data)
                End If
            End If

        Next

    End Sub

    Sub SendDataToMapBut(ByVal Index As Integer, ByVal MapNum As Integer, ByRef Data() As Byte)
        Dim i As Integer

        For i = 1 To GetTotalPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(i) = MapNum Then
                    If i <> Index Then
                        SendDataTo(i, Data)
                    End If
                End If
            End If

        Next

    End Sub

    Sub SendDataToMap(ByVal MapNum As Integer, ByRef Data() As Byte)
        Dim i As Integer

        For i = 1 To GetTotalPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(i) = MapNum Then
                    SendDataTo(i, Data)
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

    Public Sub AlertMsg(ByVal Index As Integer, ByVal Msg As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SAlertMsg)
        Buffer.WriteString(Msg)
        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Public Sub GlobalMsg(ByVal Msg As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SGlobalMsg)
        'Buffer.WriteString(Msg)
        Buffer.WriteUnicodeString(Msg)
        SendDataToAll(Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Public Sub PlayerMsg(ByVal Index As Integer, ByVal Msg As String, ByVal Colour As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPlayerMsg)
        'Buffer.WriteString(Msg)
        Buffer.WriteUnicodeString(Msg)
        Buffer.WriteInteger(Colour)

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub SendAnimations(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(i).Name)) > 0 Then
                SendUpdateAnimationTo(Index, i)
            End If

        Next

    End Sub

    Sub SendNewCharClasses(ByVal Index As Integer)
        Dim i As Integer, n As Integer, q As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SNewCharClasses)
        Buffer.WriteInteger(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(GetClassName(i))
            Buffer.WriteString(Trim$(Classes(i).Desc))

            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)
            ' send array size
            Buffer.WriteInteger(n)
            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)
            ' send array size
            Buffer.WriteInteger(n)
            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteInteger(Classes(i).Stat(Stats.Strength))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Endurance))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Vitality))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Luck))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Intelligence))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Spirit))

            For q = 1 To 5
                Buffer.WriteInteger(Classes(i).StartItem(q))
                Buffer.WriteInteger(Classes(i).StartValue(q))
            Next

            Buffer.WriteInteger(Classes(i).StartMap)
            Buffer.WriteInteger(Classes(i).StartX)
            Buffer.WriteInteger(Classes(i).StartY)

            Buffer.WriteInteger(Classes(i).BaseExp)
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Function GetClientIP(ByVal index As Integer) As String
        GetClientIP = Clients(index).IP
    End Function

    Sub SendCloseTrade(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SCloseTrade)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendExp(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPlayerEXP)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(GetPlayerExp(Index))
        Buffer.WriteInteger(GetPlayerNextLevel(Index))

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub CloseSocket(ByVal Index As Integer)
        Try
            If Index > 0 Then
                If (Clients(Index).Closing = True) Then Exit Sub
                Clients(Index).Closing = True
                LeftGame(Index)
                TextAdd("Connection from " & GetPlayerIP(Index) & " has been terminated.")
                Clients(Index).Socket.Close()
                Clients(Index).Socket = Nothing
                ClearPlayer(Index)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Function IsPlaying(ByVal Index As Integer) As Boolean
        IsPlaying = False
        If TempPlayer(Index).InGame = True Then
            IsPlaying = True
        End If

    End Function

    Function IsLoggedIn(ByVal Index As Integer) As Boolean
        IsLoggedIn = False
        If Len(Trim$(Player(Index).Login)) > 0 Then
            IsLoggedIn = True
        End If

    End Function

    Public Function IsConnected(ByVal Index As Integer) As Boolean
        If Clients(Index).Socket.Connected Then
            IsConnected = True
        Else
            IsConnected = False
        End If
    End Function

    Function IsMultiAccounts(ByVal Login As String) As Boolean
        Dim i As Integer

        IsMultiAccounts = False

        For i = 1 To GetTotalPlayersOnline()
            If LCase$(Trim$(Player(i).Login)) = LCase$(Login) Then
                IsMultiAccounts = True
                Exit Function
            Else
                IsMultiAccounts = False
                Exit Function
            End If

        Next

    End Function

    Sub SendLoadCharOk(ByVal index As Integer)
        Dim buffer = New ByteBuffer
        buffer.WriteInteger(ServerPackets.SLoadCharOk)
        buffer.WriteInteger(index)
        SendDataTo(index, buffer.ToArray)
        buffer = Nothing
    End Sub

    Sub SendEditorLoadOk(ByVal index As Integer)
        Dim Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SLoginOk)
        Buffer.WriteInteger(index)
        SendDataTo(index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub SendInGame(ByVal Index As Integer)
        Dim Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SInGame)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendClasses(ByVal Index As Integer)
        Dim i As Integer, n As Integer, q As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SClassesData)
        Buffer.WriteInteger(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(Trim$(GetClassName(i)))
            Buffer.WriteString(Trim$(Classes(i).Desc))

            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)

            ' send array size
            Buffer.WriteInteger(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)

            ' send array size
            Buffer.WriteInteger(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteInteger(Classes(i).Stat(Stats.Strength))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Endurance))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Vitality))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Intelligence))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Luck))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Spirit))

            For q = 1 To 5
                Buffer.WriteInteger(Classes(i).StartItem(q))
                Buffer.WriteInteger(Classes(i).StartValue(q))
            Next

            Buffer.WriteInteger(Classes(i).StartMap)
            Buffer.WriteInteger(Classes(i).StartX)
            Buffer.WriteInteger(Classes(i).StartY)

            Buffer.WriteInteger(Classes(i).BaseExp)
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendClassesToAll()
        Dim i As Integer, n As Integer, q As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SClassesData)
        Buffer.WriteInteger(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(GetClassName(i))
            Buffer.WriteString(Trim$(Classes(i).Desc))

            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)

            ' send array size
            Buffer.WriteInteger(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)

            ' send array size
            Buffer.WriteInteger(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteInteger(Classes(i).Stat(Stats.Strength))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Endurance))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Vitality))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Intelligence))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Luck))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Spirit))

            For q = 1 To 5
                Buffer.WriteInteger(Classes(i).StartItem(q))
                Buffer.WriteInteger(Classes(i).StartValue(q))
            Next

            Buffer.WriteInteger(Classes(i).StartMap)
            Buffer.WriteInteger(Classes(i).StartX)
            Buffer.WriteInteger(Classes(i).StartY)

            Buffer.WriteInteger(Classes(i).BaseExp)
        Next

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendInventory(ByVal Index As Integer)
        Dim i As Integer, n As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPlayerInv)

        For i = 1 To MAX_INV
            Buffer.WriteInteger(GetPlayerInvItemNum(Index, i))
            Buffer.WriteInteger(GetPlayerInvItemValue(Index, i))
            Buffer.WriteString(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(i).Prefix)
            Buffer.WriteString(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(i).Suffix)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(i).Rarity)
            For n = 1 To Stats.Count - 1
                Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(i).Stat(n))
            Next
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(i).Damage)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(i).Speed)
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendItems(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_ITEMS

            If Len(Trim$(Item(i).Name)) > 0 Then
                SendUpdateItemTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateItemTo(ByVal Index As Integer, ByVal itemNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateItem)
        Buffer.WriteInteger(itemNum)
        Buffer.WriteInteger(Item(itemNum).AccessReq)

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteInteger(Item(itemNum).Animation)
        Buffer.WriteInteger(Item(itemNum).BindType)
        Buffer.WriteInteger(Item(itemNum).ClassReq)
        Buffer.WriteInteger(Item(itemNum).Data1)
        Buffer.WriteInteger(Item(itemNum).Data2)
        Buffer.WriteInteger(Item(itemNum).Data3)
        Buffer.WriteInteger(Item(itemNum).TwoHanded)
        Buffer.WriteInteger(Item(itemNum).LevelReq)
        Buffer.WriteInteger(Item(itemNum).Mastery)
        Buffer.WriteString(Trim$(Item(itemNum).Name))
        Buffer.WriteInteger(Item(itemNum).Paperdoll)
        Buffer.WriteInteger(Item(itemNum).Pic)
        Buffer.WriteInteger(Item(itemNum).Price)
        Buffer.WriteInteger(Item(itemNum).Rarity)
        Buffer.WriteInteger(Item(itemNum).Speed)

        Buffer.WriteInteger(Item(itemNum).Randomize)
        Buffer.WriteInteger(Item(itemNum).RandomMin)
        Buffer.WriteInteger(Item(itemNum).RandomMax)

        Buffer.WriteInteger(Item(itemNum).Stackable)
        Buffer.WriteString(Trim$(Item(itemNum).Description))

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteInteger(Item(itemNum).Type)
        Buffer.WriteInteger(Item(itemNum).SubType)

        Buffer.WriteInteger(Item(itemNum).ItemLevel)

        'Housing
        Buffer.WriteInteger(Item(itemNum).FurnitureWidth)
        Buffer.WriteInteger(Item(itemNum).FurnitureHeight)

        For i = 1 To 3
            For x = 1 To 3
                Buffer.WriteInteger(Item(itemNum).FurnitureBlocks(i, x))
                Buffer.WriteInteger(Item(itemNum).FurnitureFringe(i, x))
            Next
        Next

        Buffer.WriteInteger(Item(itemNum).KnockBack)
        Buffer.WriteInteger(Item(itemNum).KnockBackTiles)

        Buffer.WriteInteger(Item(itemNum).Projectile)
        Buffer.WriteInteger(Item(itemNum).Ammo)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateItemToAll(ByVal itemNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateItem)
        Buffer.WriteInteger(itemNum)
        Buffer.WriteInteger(Item(itemNum).AccessReq)

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteInteger(Item(itemNum).Animation)
        Buffer.WriteInteger(Item(itemNum).BindType)
        Buffer.WriteInteger(Item(itemNum).ClassReq)
        Buffer.WriteInteger(Item(itemNum).Data1)
        Buffer.WriteInteger(Item(itemNum).Data2)
        Buffer.WriteInteger(Item(itemNum).Data3)
        Buffer.WriteInteger(Item(itemNum).TwoHanded)
        Buffer.WriteInteger(Item(itemNum).LevelReq)
        Buffer.WriteInteger(Item(itemNum).Mastery)
        Buffer.WriteString(Trim$(Item(itemNum).Name))
        Buffer.WriteInteger(Item(itemNum).Paperdoll)
        Buffer.WriteInteger(Item(itemNum).Pic)
        Buffer.WriteInteger(Item(itemNum).Price)
        Buffer.WriteInteger(Item(itemNum).Rarity)
        Buffer.WriteInteger(Item(itemNum).Speed)

        Buffer.WriteInteger(Item(itemNum).Randomize)
        Buffer.WriteInteger(Item(itemNum).RandomMin)
        Buffer.WriteInteger(Item(itemNum).RandomMax)

        Buffer.WriteInteger(Item(itemNum).Stackable)
        Buffer.WriteString(Trim$(Item(itemNum).Description))

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteInteger(Item(itemNum).Type)
        Buffer.WriteInteger(Item(itemNum).SubType)

        Buffer.WriteInteger(Item(itemNum).ItemLevel)

        'Housing
        Buffer.WriteInteger(Item(itemNum).FurnitureWidth)
        Buffer.WriteInteger(Item(itemNum).FurnitureHeight)

        For i = 1 To 3
            For x = 1 To 3
                Buffer.WriteInteger(Item(itemNum).FurnitureBlocks(i, x))
                Buffer.WriteInteger(Item(itemNum).FurnitureFringe(i, x))
            Next
        Next

        Buffer.WriteInteger(Item(itemNum).KnockBack)
        Buffer.WriteInteger(Item(itemNum).KnockBackTiles)

        Buffer.WriteInteger(Item(itemNum).Projectile)
        Buffer.WriteInteger(Item(itemNum).Ammo)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendLeftMap(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SLeftMap)
        Buffer.WriteInteger(Index)
        Buffer.WriteString("")
        Buffer.WriteInteger(0)
        Buffer.WriteInteger(0)
        Buffer.WriteInteger(0)
        Buffer.WriteInteger(0)
        Buffer.WriteInteger(0)
        Buffer.WriteInteger(0)
        Buffer.WriteInteger(0)
        SendDataToAllBut(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendLeftGame(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SLeftGame)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendMapEquipment(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapWornEq)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Armor))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Weapon))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Helmet))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Shield))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Shoes))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Gloves))

        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapEquipmentTo(ByVal PlayerNum As Integer, ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapWornEq)
        Buffer.WriteInteger(PlayerNum)
        Buffer.WriteInteger(GetPlayerEquipment(PlayerNum, EquipmentType.Armor))
        Buffer.WriteInteger(GetPlayerEquipment(PlayerNum, EquipmentType.Weapon))
        Buffer.WriteInteger(GetPlayerEquipment(PlayerNum, EquipmentType.Helmet))
        Buffer.WriteInteger(GetPlayerEquipment(PlayerNum, EquipmentType.Shield))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Shoes))
        Buffer.WriteInteger(GetPlayerEquipment(Index, EquipmentType.Gloves))

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendNpcs(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_NPCS

            If Len(Trim$(Npc(i).Name)) > 0 Then
                SendUpdateNpcTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateNpcTo(ByVal Index As Integer, ByVal NpcNum As Integer)
        Dim Buffer As ByteBuffer, i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateNpc)

        Buffer.WriteInteger(NpcNum)
        Buffer.WriteInteger(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteInteger(Npc(NpcNum).Behaviour)

        For i = 1 To 5
            Buffer.WriteInteger(Npc(NpcNum).DropChance(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItem(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItemValue(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).Exp)
        Buffer.WriteInteger(Npc(NpcNum).Faction)
        Buffer.WriteInteger(Npc(NpcNum).Hp)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteInteger(Npc(NpcNum).Range)
        Buffer.WriteInteger(Npc(NpcNum).SpawnSecs)
        Buffer.WriteInteger(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            Buffer.WriteInteger(Npc(NpcNum).Skill(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).Level)
        Buffer.WriteInteger(Npc(NpcNum).Damage)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateNpcToAll(ByVal NpcNum As Integer)
        Dim Buffer As ByteBuffer, i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateNpc)

        Buffer.WriteInteger(NpcNum)
        Buffer.WriteInteger(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteInteger(Npc(NpcNum).Behaviour)

        For i = 1 To 5
            Buffer.WriteInteger(Npc(NpcNum).DropChance(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItem(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItemValue(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).Exp)
        Buffer.WriteInteger(Npc(NpcNum).Faction)
        Buffer.WriteInteger(Npc(NpcNum).Hp)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteInteger(Npc(NpcNum).Range)
        Buffer.WriteInteger(Npc(NpcNum).SpawnSecs)
        Buffer.WriteInteger(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            Buffer.WriteInteger(Npc(NpcNum).Skill(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).Level)
        Buffer.WriteInteger(Npc(NpcNum).Damage)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendResourceCacheTo(ByVal Index As Integer, ByVal Resource_num As Integer)
        Dim Buffer As ByteBuffer
        Dim i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SResourceCache)
        Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).Resource_Count)

        If ResourceCache(GetPlayerMap(Index)).Resource_Count > 0 Then

            For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count
                Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).ResourceData(i).ResourceState)
                Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).ResourceData(i).X)
                Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).ResourceData(i).Y)
            Next

        End If

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendResources(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(i).Name)) > 0 Then
                SendUpdateResourceTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateResourceTo(ByVal Index As Integer, ByVal ResourceNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateResource)
        Buffer.WriteInteger(ResourceNum)
        Buffer.WriteInteger(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteInteger(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteInteger(Resource(ResourceNum).Health)
        Buffer.WriteInteger(Resource(ResourceNum).ExpReward)
        Buffer.WriteInteger(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceImage)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceType)
        Buffer.WriteInteger(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteInteger(Resource(ResourceNum).LvlRequired)
        Buffer.WriteInteger(Resource(ResourceNum).ToolRequired)
        Buffer.WriteInteger(Resource(ResourceNum).Walkthrough)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendShops(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_SHOPS

            If Len(Trim$(Shop(i).Name)) > 0 Then
                SendUpdateShopTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateShopTo(ByVal Index As Integer, ByVal shopNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateShop)
        Buffer.WriteInteger(shopNum)
        Buffer.WriteInteger(Shop(shopNum).BuyRate)
        Buffer.WriteString(Trim(Shop(shopNum).Name))
        Buffer.WriteInteger(Shop(shopNum).Face)

        For i = 0 To MAX_TRADES
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).CostItem)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).CostValue)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateShopToAll(ByVal shopNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateShop)
        Buffer.WriteInteger(shopNum)
        Buffer.WriteInteger(Shop(shopNum).BuyRate)
        Buffer.WriteString(Shop(shopNum).Name)
        Buffer.WriteInteger(Shop(shopNum).Face)

        For i = 0 To MAX_TRADES
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).CostItem)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).CostValue)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSkills(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_SKILLS

            If Len(Trim$(Skill(i).Name)) > 0 Then
                SendUpdateSkillTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateSkillTo(ByVal Index As Integer, ByVal skillnum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateSkill)
        Buffer.WriteInteger(skillnum)
        Buffer.WriteInteger(Skill(skillnum).AccessReq)
        Buffer.WriteInteger(Skill(skillnum).AoE)
        Buffer.WriteInteger(Skill(skillnum).CastAnim)
        Buffer.WriteInteger(Skill(skillnum).CastTime)
        Buffer.WriteInteger(Skill(skillnum).CdTime)
        Buffer.WriteInteger(Skill(skillnum).ClassReq)
        Buffer.WriteInteger(Skill(skillnum).Dir)
        Buffer.WriteInteger(Skill(skillnum).Duration)
        Buffer.WriteInteger(Skill(skillnum).Icon)
        Buffer.WriteInteger(Skill(skillnum).Interval)
        Buffer.WriteInteger(Skill(skillnum).IsAoE)
        Buffer.WriteInteger(Skill(skillnum).LevelReq)
        Buffer.WriteInteger(Skill(skillnum).Map)
        Buffer.WriteInteger(Skill(skillnum).MpCost)
        Buffer.WriteString(Trim(Skill(skillnum).Name))
        Buffer.WriteInteger(Skill(skillnum).range)
        Buffer.WriteInteger(Skill(skillnum).SkillAnim)
        Buffer.WriteInteger(Skill(skillnum).StunDuration)
        Buffer.WriteInteger(Skill(skillnum).Type)
        Buffer.WriteInteger(Skill(skillnum).Vital)
        Buffer.WriteInteger(Skill(skillnum).X)
        Buffer.WriteInteger(Skill(skillnum).Y)

        'projectiles
        Buffer.WriteInteger(Skill(skillnum).IsProjectile)
        Buffer.WriteInteger(Skill(skillnum).Projectile)

        Buffer.WriteInteger(Skill(skillnum).KnockBack)
        Buffer.WriteInteger(Skill(skillnum).KnockBackTiles)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateSkillToAll(ByVal skillnum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateSkill)
        Buffer.WriteInteger(skillnum)
        Buffer.WriteInteger(Skill(skillnum).AccessReq)
        Buffer.WriteInteger(Skill(skillnum).AoE)
        Buffer.WriteInteger(Skill(skillnum).CastAnim)
        Buffer.WriteInteger(Skill(skillnum).CastTime)
        Buffer.WriteInteger(Skill(skillnum).CdTime)
        Buffer.WriteInteger(Skill(skillnum).ClassReq)
        Buffer.WriteInteger(Skill(skillnum).Dir)
        Buffer.WriteInteger(Skill(skillnum).Duration)
        Buffer.WriteInteger(Skill(skillnum).Icon)
        Buffer.WriteInteger(Skill(skillnum).Interval)
        Buffer.WriteInteger(Skill(skillnum).IsAoE)
        Buffer.WriteInteger(Skill(skillnum).LevelReq)
        Buffer.WriteInteger(Skill(skillnum).Map)
        Buffer.WriteInteger(Skill(skillnum).MpCost)
        Buffer.WriteString(Skill(skillnum).Name)
        Buffer.WriteInteger(Skill(skillnum).range)
        Buffer.WriteInteger(Skill(skillnum).SkillAnim)
        Buffer.WriteInteger(Skill(skillnum).StunDuration)
        Buffer.WriteInteger(Skill(skillnum).Type)
        Buffer.WriteInteger(Skill(skillnum).Vital)
        Buffer.WriteInteger(Skill(skillnum).X)
        Buffer.WriteInteger(Skill(skillnum).Y)

        'projectiles
        Buffer.WriteInteger(Skill(skillnum).IsProjectile)
        Buffer.WriteInteger(Skill(skillnum).Projectile)

        Buffer.WriteInteger(Skill(skillnum).KnockBack)
        Buffer.WriteInteger(Skill(skillnum).KnockBackTiles)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendStats(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPlayerStats)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(GetPlayerStat(Index, Stats.Strength))
        Buffer.WriteInteger(GetPlayerStat(Index, Stats.Endurance))
        Buffer.WriteInteger(GetPlayerStat(Index, Stats.Vitality))
        Buffer.WriteInteger(GetPlayerStat(Index, Stats.Luck))
        Buffer.WriteInteger(GetPlayerStat(Index, Stats.Intelligence))
        Buffer.WriteInteger(GetPlayerStat(Index, Stats.Spirit))
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateAnimationTo(ByVal Index As Integer, ByVal AnimationNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateAnimation)
        Buffer.WriteInteger(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteInteger(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteInteger(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteInteger(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteInteger(Animation(AnimationNum).Sprite(i))
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUpdateAnimationToAll(ByVal AnimationNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateAnimation)
        Buffer.WriteInteger(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteInteger(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteInteger(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteInteger(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteInteger(Animation(AnimationNum).Sprite(i))
        Next

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendVitals(ByVal Index As Integer)
        For i = 1 To Vitals.Count - 1
            SendVital(Index, i)
        Next
    End Sub

    Sub SendVital(ByVal Index As Integer, ByVal Vital As Vitals)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        ' Get our packet type.
        Select Case Vital
            Case Vitals.HP
                Buffer.WriteInteger(ServerPackets.SPlayerHp)
            Case Vitals.MP
                Buffer.WriteInteger(ServerPackets.SPlayerMp)
            Case Vitals.SP
                Buffer.WriteInteger(ServerPackets.SPlayerSp)
        End Select

        ' Set and send related data.
        Buffer.WriteInteger(GetPlayerMaxVital(Index, Vital))
        Buffer.WriteInteger(GetPlayerVital(Index, Vital))
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendWelcome(ByVal Index As Integer)

        ' Send them MOTD
        If Len(Options.Motd) > 0 Then
            PlayerMsg(Index, Options.Motd, ColorType.BrightCyan)
        End If

        ' Send whos online
        SendWhosOnline(Index)
    End Sub

    Sub SendWhosOnline(ByVal Index As Integer)
        Dim s As String
        Dim n As Integer
        Dim i As Integer
        s = ""
        For i = 1 To GetTotalPlayersOnline()

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

        PlayerMsg(Index, s, ColorType.White)
    End Sub

    Sub SendWornEquipment(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPlayerWornEq)

        For i = 1 To EquipmentType.Count - 1
            Buffer.WriteInteger(GetPlayerEquipment(Index, i))
        Next

        For i = 1 To EquipmentType.Count - 1
            Buffer.WriteString(Player(Index).Character(TempPlayer(Index).CurChar).RandEquip(i).Prefix)
            Buffer.WriteString(Player(Index).Character(TempPlayer(Index).CurChar).RandEquip(i).Suffix)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandEquip(i).Damage)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandEquip(i).Speed)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandEquip(i).Rarity)
            For n = 1 To Stats.Count - 1
                Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandEquip(i).Stat(n))
            Next
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapData(ByVal Index As Integer, ByVal MapNum As Integer, ByVal SendMap As Boolean)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Dim data() As Byte

        If SendMap Then
            Buffer.WriteInteger(1)
            Buffer.WriteInteger(MapNum)
            Buffer.WriteString(Map(MapNum).Name)
            Buffer.WriteString(Map(MapNum).Music)
            Buffer.WriteInteger(Map(MapNum).Revision)
            Buffer.WriteInteger(Map(MapNum).Moral)
            Buffer.WriteInteger(Map(MapNum).Tileset)
            Buffer.WriteInteger(Map(MapNum).Up)
            Buffer.WriteInteger(Map(MapNum).Down)
            Buffer.WriteInteger(Map(MapNum).Left)
            Buffer.WriteInteger(Map(MapNum).Right)
            Buffer.WriteInteger(Map(MapNum).BootMap)
            Buffer.WriteInteger(Map(MapNum).BootX)
            Buffer.WriteInteger(Map(MapNum).BootY)
            Buffer.WriteInteger(Map(MapNum).MaxX)
            Buffer.WriteInteger(Map(MapNum).MaxY)
            Buffer.WriteInteger(Map(MapNum).WeatherType)
            Buffer.WriteInteger(Map(MapNum).FogIndex)
            Buffer.WriteInteger(Map(MapNum).WeatherIntensity)
            Buffer.WriteInteger(Map(MapNum).FogAlpha)
            Buffer.WriteInteger(Map(MapNum).FogSpeed)
            Buffer.WriteInteger(Map(MapNum).HasMapTint)
            Buffer.WriteInteger(Map(MapNum).MapTintR)
            Buffer.WriteInteger(Map(MapNum).MapTintG)
            Buffer.WriteInteger(Map(MapNum).MapTintB)
            Buffer.WriteInteger(Map(MapNum).MapTintA)
            Buffer.WriteInteger(Map(MapNum).Instanced)

            For i = 1 To MAX_MAP_NPCS
                Buffer.WriteInteger(Map(MapNum).Npc(i))
            Next

            For x = 0 To Map(MapNum).MaxX
                For y = 0 To Map(MapNum).MaxY
                    Buffer.WriteInteger(Map(MapNum).Tile(x, y).Data1)
                    Buffer.WriteInteger(Map(MapNum).Tile(x, y).Data2)
                    Buffer.WriteInteger(Map(MapNum).Tile(x, y).Data3)
                    Buffer.WriteInteger(Map(MapNum).Tile(x, y).DirBlock)
                    For i = 0 To MapLayer.Count - 1
                        Buffer.WriteInteger(Map(MapNum).Tile(x, y).Layer(i).Tileset)
                        Buffer.WriteInteger(Map(MapNum).Tile(x, y).Layer(i).X)
                        Buffer.WriteInteger(Map(MapNum).Tile(x, y).Layer(i).Y)
                        Buffer.WriteInteger(Map(MapNum).Tile(x, y).Layer(i).AutoTile)
                    Next
                    Buffer.WriteInteger(Map(MapNum).Tile(x, y).Type)

                Next
            Next

            'Event Data
            Buffer.WriteInteger(Map(MapNum).EventCount)
            If Map(MapNum).EventCount > 0 Then
                For i = 1 To Map(MapNum).EventCount
                    With Map(MapNum).Events(i)
                        Buffer.WriteString(Trim$(.Name))
                        Buffer.WriteInteger(.Globals)
                        Buffer.WriteInteger(.X)
                        Buffer.WriteInteger(.Y)
                        Buffer.WriteInteger(.PageCount)
                    End With
                    If Map(MapNum).Events(i).PageCount > 0 Then
                        For X = 1 To Map(MapNum).Events(i).PageCount
                            With Map(MapNum).Events(i).Pages(X)
                                Buffer.WriteInteger(.chkVariable)
                                Buffer.WriteInteger(.VariableIndex)
                                Buffer.WriteInteger(.VariableCondition)
                                Buffer.WriteInteger(.VariableCompare)
                                Buffer.WriteInteger(.chkSwitch)
                                Buffer.WriteInteger(.SwitchIndex)
                                Buffer.WriteInteger(.SwitchCompare)
                                Buffer.WriteInteger(.chkHasItem)
                                Buffer.WriteInteger(.HasItemIndex)
                                Buffer.WriteInteger(.HasItemAmount)
                                Buffer.WriteInteger(.chkSelfSwitch)
                                Buffer.WriteInteger(.SelfSwitchIndex)
                                Buffer.WriteInteger(.SelfSwitchCompare)
                                Buffer.WriteInteger(.GraphicType)
                                Buffer.WriteInteger(.Graphic)
                                Buffer.WriteInteger(.GraphicX)
                                Buffer.WriteInteger(.GraphicY)
                                Buffer.WriteInteger(.GraphicX2)
                                Buffer.WriteInteger(.GraphicY2)
                                Buffer.WriteInteger(.MoveType)
                                Buffer.WriteInteger(.MoveSpeed)
                                Buffer.WriteInteger(.MoveFreq)
                                Buffer.WriteInteger(.MoveRouteCount)
                                Buffer.WriteInteger(.IgnoreMoveRoute)
                                Buffer.WriteInteger(.RepeatMoveRoute)
                                If .MoveRouteCount > 0 Then
                                    For Y = 1 To .MoveRouteCount
                                        Buffer.WriteInteger(.MoveRoute(Y).Index)
                                        Buffer.WriteInteger(.MoveRoute(Y).Data1)
                                        Buffer.WriteInteger(.MoveRoute(Y).Data2)
                                        Buffer.WriteInteger(.MoveRoute(Y).Data3)
                                        Buffer.WriteInteger(.MoveRoute(Y).Data4)
                                        Buffer.WriteInteger(.MoveRoute(Y).Data5)
                                        Buffer.WriteInteger(.MoveRoute(Y).Data6)
                                    Next
                                End If
                                Buffer.WriteInteger(.WalkAnim)
                                Buffer.WriteInteger(.DirFix)
                                Buffer.WriteInteger(.WalkThrough)
                                Buffer.WriteInteger(.ShowName)
                                Buffer.WriteInteger(.Trigger)
                                Buffer.WriteInteger(.CommandListCount)
                                Buffer.WriteInteger(.Position)
                                Buffer.WriteInteger(.QuestNum)

                                Buffer.WriteInteger(.chkPlayerGender)
                            End With
                            If Map(MapNum).Events(i).Pages(X).CommandListCount > 0 Then
                                For Y = 1 To Map(MapNum).Events(i).Pages(X).CommandListCount
                                    Buffer.WriteInteger(Map(MapNum).Events(i).Pages(X).CommandList(Y).CommandCount)
                                    Buffer.WriteInteger(Map(MapNum).Events(i).Pages(X).CommandList(Y).ParentList)
                                    If Map(MapNum).Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                        For z = 1 To Map(MapNum).Events(i).Pages(X).CommandList(Y).CommandCount
                                            With Map(MapNum).Events(i).Pages(X).CommandList(Y).Commands(z)
                                                Buffer.WriteInteger(.Index)
                                                Buffer.WriteString(Trim$(.Text1))
                                                Buffer.WriteString(Trim$(.Text2))
                                                Buffer.WriteString(Trim$(.Text3))
                                                Buffer.WriteString(Trim$(.Text4))
                                                Buffer.WriteString(Trim$(.Text5))
                                                Buffer.WriteInteger(.Data1)
                                                Buffer.WriteInteger(.Data2)
                                                Buffer.WriteInteger(.Data3)
                                                Buffer.WriteInteger(.Data4)
                                                Buffer.WriteInteger(.Data5)
                                                Buffer.WriteInteger(.Data6)
                                                Buffer.WriteInteger(.ConditionalBranch.CommandList)
                                                Buffer.WriteInteger(.ConditionalBranch.Condition)
                                                Buffer.WriteInteger(.ConditionalBranch.Data1)
                                                Buffer.WriteInteger(.ConditionalBranch.Data2)
                                                Buffer.WriteInteger(.ConditionalBranch.Data3)
                                                Buffer.WriteInteger(.ConditionalBranch.ElseCommandList)
                                                Buffer.WriteInteger(.MoveRouteCount)
                                                If .MoveRouteCount > 0 Then
                                                    For w = 1 To .MoveRouteCount
                                                        Buffer.WriteInteger(.MoveRoute(w).Index)
                                                        Buffer.WriteInteger(.MoveRoute(w).Data1)
                                                        Buffer.WriteInteger(.MoveRoute(w).Data2)
                                                        Buffer.WriteInteger(.MoveRoute(w).Data3)
                                                        Buffer.WriteInteger(.MoveRoute(w).Data4)
                                                        Buffer.WriteInteger(.MoveRoute(w).Data5)
                                                        Buffer.WriteInteger(.MoveRoute(w).Data6)
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
            Buffer.WriteInteger(0)
        End If

        For i = 1 To MAX_MAP_ITEMS
            Buffer.WriteInteger(MapItem(MapNum, i).Num)
            Buffer.WriteInteger(MapItem(MapNum, i).Value)
            Buffer.WriteInteger(MapItem(MapNum, i).X)
            Buffer.WriteInteger(MapItem(MapNum, i).Y)
        Next

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Num)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).X)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Y)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Dir)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Vital(Vitals.HP))
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Vital(Vitals.MP))
        Next

        'send Resource cache
        If ResourceCache(GetPlayerMap(Index)).Resource_Count > 0 Then
            Buffer.WriteInteger(1)
            Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).Resource_Count)

            For i = 0 To ResourceCache(GetPlayerMap(Index)).Resource_Count
                Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).ResourceData(i).ResourceState)
                Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).ResourceData(i).X)
                Buffer.WriteInteger(ResourceCache(GetPlayerMap(Index)).ResourceData(i).Y)
            Next
        Else
            Buffer.WriteInteger(0)
        End If

        data = ArchaicIO.Compression.Compress(Buffer.ToArray)
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SMapData)
        Buffer.WriteBytes(data)
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Sub SendJoinMap(ByVal Index As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        ' Send all players on current map to index
        For i = 1 To GetTotalPlayersOnline()
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

    Function PlayerData(ByVal Index As Integer) As Byte()
        Dim Buffer As ByteBuffer, i As Integer
        PlayerData = Nothing
        If Index > MAX_PLAYERS Then Exit Function
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPlayerData)
        Buffer.WriteInteger(Index)
        Buffer.WriteString(GetPlayerName(Index))
        Buffer.WriteInteger(GetPlayerClass(Index))
        Buffer.WriteInteger(GetPlayerLevel(Index))
        Buffer.WriteInteger(GetPlayerPOINTS(Index))
        Buffer.WriteInteger(GetPlayerSprite(Index))
        Buffer.WriteInteger(GetPlayerMap(Index))
        Buffer.WriteInteger(GetPlayerX(Index))
        Buffer.WriteInteger(GetPlayerY(Index))
        Buffer.WriteInteger(GetPlayerDir(Index))
        Buffer.WriteInteger(GetPlayerAccess(Index))
        Buffer.WriteInteger(GetPlayerPK(Index))

        For i = 1 To Stats.Count - 1
            Buffer.WriteInteger(GetPlayerStat(Index, i))
        Next

        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).InHouse)

        For i = 0 To ResourceSkills.Count - 1
            Buffer.WriteInteger(GetPlayerGatherSkillLvl(Index, i))
            Buffer.WriteInteger(GetPlayerGatherSkillExp(Index, i))
            Buffer.WriteInteger(GetPlayerGatherSkillMaxExp(Index, i))
        Next

        For i = 1 To MAX_RECIPE
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RecipeLearned(i))
        Next

        PlayerData = Buffer.ToArray()

        Buffer = Nothing
    End Function

    Sub SendMapItemsTo(ByVal Index As Integer, ByVal MapNum As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapItemData)

        For i = 1 To MAX_MAP_ITEMS
            Buffer.WriteInteger(MapItem(MapNum, i).Num)
            Buffer.WriteInteger(MapItem(MapNum, i).Value)
            Buffer.WriteInteger(MapItem(MapNum, i).X)
            Buffer.WriteInteger(MapItem(MapNum, i).Y)
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapNpcsTo(ByVal Index As Integer, ByVal MapNum As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapNpcData)

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Num)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).X)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Y)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Dir)
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Vital(Vitals.HP))
            Buffer.WriteInteger(MapNpc(MapNum).Npc(i).Vital(Vitals.MP))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapNpcTo(ByVal MapNum As Integer, ByVal MapNpcNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapNpcUpdate)

        Buffer.WriteInteger(MapNpcNum)

        With MapNpc(MapNum).Npc(MapNpcNum)
            Buffer.WriteInteger(.Num)
            Buffer.WriteInteger(.X)
            Buffer.WriteInteger(.Y)
            Buffer.WriteInteger(.Dir)
            Buffer.WriteInteger(.Vital(Vitals.HP))
            Buffer.WriteInteger(.Vital(Vitals.MP))
        End With

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerXY(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPlayerXY)
        Buffer.WriteInteger(GetPlayerX(Index))
        Buffer.WriteInteger(GetPlayerY(Index))
        Buffer.WriteInteger(GetPlayerDir(Index))
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendPlayerMove(ByVal Index As Integer, ByVal Movement As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPlayerMove)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(GetPlayerX(Index))
        Buffer.WriteInteger(GetPlayerY(Index))
        Buffer.WriteInteger(GetPlayerDir(Index))
        Buffer.WriteInteger(Movement)
        SendDataToMapBut(Index, GetPlayerMap(Index), Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendDoorAnimation(ByVal MapNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SDoorAnimation)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapKey(ByVal Index As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal Value As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SMapKey)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)
        Buffer.WriteInteger(Value)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Public Sub MapMsg(ByVal MapNum As Integer, ByVal Msg As String, ByVal Color As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapMsg)
        'Buffer.WriteString(Msg)
        Buffer.WriteUnicodeString(Msg)

        SendDataToMap(MapNum, Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Sub SendActionMsg(ByVal MapNum As Integer, ByVal Message As String, ByVal Color As Integer, ByVal MsgType As Integer, ByVal X As Integer, ByVal Y As Integer, Optional ByVal PlayerOnlyNum As Integer = 0)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SActionMsg)
        'Buffer.WriteString(Message)
        Buffer.WriteUnicodeString(Message)
        Buffer.WriteInteger(Color)
        Buffer.WriteInteger(MsgType)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)

        If PlayerOnlyNum > 0 Then
            SendDataTo(PlayerOnlyNum, Buffer.ToArray())
        Else
            SendDataToMap(MapNum, Buffer.ToArray())
        End If

        Buffer = Nothing
    End Sub

    Sub SayMsg_Map(ByVal MapNum As Integer, ByVal Index As Integer, ByVal Message As String, ByVal SayColour As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SSayMsg)
        Buffer.WriteString(GetPlayerName(Index))
        Buffer.WriteInteger(GetPlayerAccess(Index))
        Buffer.WriteInteger(GetPlayerPK(Index))
        'Buffer.WriteString(Message)
        Buffer.WriteUnicodeString(Message)
        Buffer.WriteString("[Map] ")
        Buffer.WriteInteger(SayColour)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerData(ByVal Index As Integer)
        SendDataToMap(GetPlayerMap(Index), PlayerData(Index))
    End Sub

    Sub SendUpdateResourceToAll(ByVal ResourceNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateResource)
        Buffer.WriteInteger(ResourceNum)

        Buffer.WriteInteger(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteInteger(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteInteger(Resource(ResourceNum).Health)
        Buffer.WriteInteger(Resource(ResourceNum).ExpReward)
        Buffer.WriteInteger(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceImage)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceType)
        Buffer.WriteInteger(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteInteger(Resource(ResourceNum).LvlRequired)
        Buffer.WriteInteger(Resource(ResourceNum).ToolRequired)
        Buffer.WriteInteger(Resource(ResourceNum).Walkthrough)

        SendDataToAll(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendMapNpcVitals(ByVal MapNum As Integer, ByVal MapNpcNum As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapNpcVitals)
        Buffer.WriteInteger(MapNpcNum)

        For i = 1 To Vitals.Count - 1
            Buffer.WriteInteger(MapNpc(MapNum).Npc(MapNpcNum).Vital(i))
        Next

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapKeyToMap(ByVal MapNum As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal Value As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SMapKey)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)
        Buffer.WriteInteger(Value)
        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendResourceCacheToMap(ByVal MapNum As Integer, ByVal Resource_num As Integer)
        Dim Buffer As ByteBuffer
        Dim i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SResourceCache)
        Buffer.WriteInteger(ResourceCache(MapNum).Resource_Count)

        If ResourceCache(MapNum).Resource_Count > 0 Then

            For i = 0 To ResourceCache(MapNum).Resource_Count
                Buffer.WriteInteger(ResourceCache(MapNum).ResourceData(i).ResourceState)
                Buffer.WriteInteger(ResourceCache(MapNum).ResourceData(i).X)
                Buffer.WriteInteger(ResourceCache(MapNum).ResourceData(i).Y)
            Next

        End If

        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendGameData(ByVal index As Integer)
        Dim buffer As ByteBuffer
        Dim i As Integer
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
        buffer.WriteInteger(i)
        buffer.WriteBytes(ItemsData)

        i = 0

        For x = 1 To MAX_ANIMATIONS
            If Len(Trim$(Animation(x).Name)) > 0 Then
                i = i + 1
            End If
        Next

        buffer.WriteInteger(i)
        buffer.WriteBytes(AnimationsData)

        i = 0

        For x = 1 To MAX_NPCS
            If Len(Trim$(Npc(x).Name)) > 0 Then
                i = i + 1
            End If
        Next

        buffer.WriteInteger(i)
        buffer.WriteBytes(NpcsData)

        i = 0

        For x = 1 To MAX_SHOPS
            If Len(Trim$(Shop(x).Name)) > 0 Then
                i = i + 1
            End If
        Next

        buffer.WriteInteger(i)
        buffer.WriteBytes(ShopsData)

        i = 0

        For x = 1 To MAX_SKILLS
            If Len(Trim$(Skill(x).Name)) > 0 Then
                i = i + 1
            End If
        Next

        buffer.WriteInteger(i)
        buffer.WriteBytes(SkillsData)

        i = 0

        For x = 1 To MAX_RESOURCES
            If Len(Trim$(Resource(x).Name)) > 0 Then
                i = i + 1
            End If
        Next

        buffer.WriteInteger(i)
        buffer.WriteBytes(ResourcesData)

        data = buffer.ToArray

        data = ArchaicIO.Compression.Compress(data)

        buffer = New ByteBuffer

        buffer.WriteInteger(ServerPackets.SGameData)

        buffer.WriteBytes(data)

        SendDataTo(index, buffer.ToArray)

        buffer = Nothing
    End Sub

    Sub SayMsg_Global(ByVal Index As Integer, ByVal Message As String, ByVal SayColour As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SSayMsg)
        Buffer.WriteString(GetPlayerName(Index))
        Buffer.WriteInteger(GetPlayerAccess(Index))
        Buffer.WriteInteger(GetPlayerPK(Index))
        'Buffer.WriteString(Message)
        Buffer.WriteUnicodeString(Message)
        Buffer.WriteString("[Global] ")
        Buffer.WriteInteger(SayColour)

        SendDataToAll(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendInventoryUpdate(ByVal Index As Integer, ByVal InvSlot As Integer)
        Dim Buffer As ByteBuffer, n As Integer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPlayerInvUpdate)
        Buffer.WriteInteger(InvSlot)
        Buffer.WriteInteger(GetPlayerInvItemNum(Index, InvSlot))
        Buffer.WriteInteger(GetPlayerInvItemValue(Index, InvSlot))

        Buffer.WriteString(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(InvSlot).Prefix)
        Buffer.WriteString(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(InvSlot).Suffix)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(InvSlot).Rarity)
        For n = 1 To Stats.Count - 1
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(InvSlot).Stat(n))
        Next n
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(InvSlot).Damage)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RandInv(InvSlot).Speed)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendAnimation(ByVal MapNum As Integer, ByVal Anim As Integer, ByVal X As Integer, ByVal Y As Integer, Optional ByVal LockType As Byte = 0, Optional ByVal LockIndex As Integer = 0)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SAnimation)
        Buffer.WriteInteger(Anim)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)
        Buffer.WriteInteger(LockType)
        Buffer.WriteInteger(LockIndex)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendOpenShop(ByVal Index As Integer, ByVal ShopNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SOpenShop)
        Buffer.WriteInteger(ShopNum)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub ResetShopAction(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SResetShopAction)

        SendDataToAll(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendBank(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Dim i As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SBank)

        For i = 1 To MAX_BANK
            Buffer.WriteInteger(Bank(Index).Item(i).Num)
            Buffer.WriteInteger(Bank(Index).Item(i).Value)

            Buffer.WriteString(Bank(Index).ItemRand(i).Prefix)
            Buffer.WriteString(Bank(Index).ItemRand(i).Suffix)
            Buffer.WriteInteger(Bank(Index).ItemRand(i).Rarity)
            Buffer.WriteInteger(Bank(Index).ItemRand(i).Damage)
            Buffer.WriteInteger(Bank(Index).ItemRand(i).Speed)

            For x = 1 To Stats.Count - 1
                Buffer.WriteInteger(Bank(Index).ItemRand(i).Stat(x))
            Next
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendClearSkillBuffer(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SClearSkillBuffer)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendClearTradeTimer(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SClearTradeTimer)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTradeInvite(ByVal Index As Integer, ByVal TradeIndex As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.STradeInvite)

        Buffer.WriteInteger(TradeIndex)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTrade(ByVal Index As Integer, ByVal TradeTarget As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.STrade)
        Buffer.WriteInteger(TradeTarget)
        Buffer.WriteString(Trim$(GetPlayerName(TradeTarget)))
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTradeUpdate(ByVal Index As Integer, ByVal DataType As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Integer
        Dim tradeTarget As Integer
        Dim totalWorth As Integer

        tradeTarget = TempPlayer(Index).InTrade

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.STradeUpdate)
        Buffer.WriteInteger(DataType)

        If DataType = 0 Then ' own inventory

            For i = 1 To MAX_INV
                Buffer.WriteInteger(TempPlayer(Index).TradeOffer(i).Num)
                Buffer.WriteInteger(TempPlayer(Index).TradeOffer(i).Value)

                ' add total worth
                If TempPlayer(Index).TradeOffer(i).Num > 0 Then
                    ' currency?
                    If Item(TempPlayer(Index).TradeOffer(i).Num).Type = ItemType.Currency Or Item(TempPlayer(Index).TradeOffer(i).Num).Stackable = 1 Then
                        If TempPlayer(Index).TradeOffer(i).Value = 0 Then TempPlayer(Index).TradeOffer(i).Value = 1
                        totalWorth = totalWorth + (Item(GetPlayerInvItemNum(Index, TempPlayer(Index).TradeOffer(i).Num)).Price * TempPlayer(Index).TradeOffer(i).Value)
                    Else
                        totalWorth = totalWorth + Item(GetPlayerInvItemNum(Index, TempPlayer(Index).TradeOffer(i).Num)).Price
                    End If
                End If
            Next
        ElseIf DataType = 1 Then ' other inventory

            For i = 1 To MAX_INV
                Buffer.WriteInteger(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num))
                Buffer.WriteInteger(TempPlayer(tradeTarget).TradeOffer(i).Value)

                ' add total worth
                If GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num) > 0 Then
                    ' currency?
                    If Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Stackable = 1 Then
                        If TempPlayer(tradeTarget).TradeOffer(i).Value = 0 Then TempPlayer(tradeTarget).TradeOffer(i).Value = 1
                        totalWorth = totalWorth + (Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Price * TempPlayer(tradeTarget).TradeOffer(i).Value)
                    Else
                        totalWorth = totalWorth + Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Price
                    End If
                End If
            Next
        End If

        ' send total worth of trade
        Buffer.WriteInteger(totalWorth)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendTradeStatus(ByVal Index As Integer, ByVal Status As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.STradeStatus)
        Buffer.WriteInteger(Status)
        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapItemsToAll(ByVal MapNum As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SMapItemData)

        For i = 1 To MAX_MAP_ITEMS
            Buffer.WriteInteger(MapItem(MapNum, i).Num)
            Buffer.WriteInteger(MapItem(MapNum, i).Value)
            Buffer.WriteInteger(MapItem(MapNum, i).X)
            Buffer.WriteInteger(MapItem(MapNum, i).Y)
        Next

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendStunned(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SStunned)
        Buffer.WriteInteger(TempPlayer(Index).StunDuration)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendBlood(ByVal MapNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SBlood)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)

        SendDataToMap(MapNum, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerSkills(ByVal Index As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SSkills)

        For i = 1 To MAX_PLAYER_SKILLS
            Buffer.WriteInteger(GetPlayerSkill(Index, i))
        Next

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendCooldown(ByVal Index As Integer, ByVal Slot As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SCooldown)
        Buffer.WriteInteger(Slot)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Public Function GetIP() As String

        'Return "127.0.0.1"

        Dim uri_val As New Uri("http://ascensiongamedev.com/resources/myip.php")
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

    Sub SendTarget(ByVal Index As Integer, ByVal Target As Integer, ByVal TargetType As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.STarget)
        Buffer.WriteInteger(Target)
        Buffer.WriteInteger(TargetType)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    'Mapreport
    Sub SendMapReport(ByVal Index As Integer)
        Dim Buffer As ByteBuffer, I As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SMapReport)

        For I = 1 To MAX_MAPS
            Buffer.WriteString(Trim(Map(I).Name))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendAdminPanel(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SAdmin)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendMapNames(ByVal Index As Integer)
        Dim Buffer As ByteBuffer, I As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SMapNames)

        For I = 1 To MAX_MAPS
            Buffer.WriteString(Trim(Map(I).Name))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendHotbar(ByVal Index As Integer)
        Dim Buffer As ByteBuffer, i As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SHotbar)

        For i = 1 To MAX_HOTBAR
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Hotbar(i).Slot)
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Hotbar(i).SlotType)
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendCritical(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SCritical)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendNews(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SNews)

        Buffer.WriteString(Trim(Options.Game_Name))
        Buffer.WriteString(Trim(GetFileContents(Path.Combine(Application.StartupPath, "data", "news.txt"))))

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendRightClick(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SrClick)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendClassEditor(ByVal Index As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SClassEditor)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendAutoMapper(ByVal Index As Integer)
        Dim Buffer As ByteBuffer, Prefab As Integer
        Dim myXml As New XmlClass With {
            .Filename = Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
            .Root = "Options"
        }
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SAutoMapper)

        Buffer.WriteInteger(MapStart)
        Buffer.WriteInteger(MapSize)
        Buffer.WriteInteger(MapX)
        Buffer.WriteInteger(MapY)
        Buffer.WriteInteger(SandBorder)
        Buffer.WriteInteger(DetailFreq)
        Buffer.WriteInteger(ResourceFreq)

        'send ini info
        Buffer.WriteString(myXml.ReadString("Resources", "ResourcesNum"))

        For Prefab = 1 To TilePrefab.Count - 1
            For Layer = 1 To MapLayer.Count - 1
                If Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Tileset")) > 0 Then
                    Buffer.WriteInteger(Layer)
                    Buffer.WriteInteger(Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Tileset")))
                    Buffer.WriteInteger(Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "X")))
                    Buffer.WriteInteger(Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Y")))
                    Buffer.WriteInteger(Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Autotile")))
                End If
            Next
            Buffer.WriteInteger(Val(myXml.ReadString("Prefab" & Prefab, "Type")))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendEmote(ByVal Index As Integer, ByVal Emote As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SEmote)

        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(Emote)

        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendChatBubble(ByVal MapNum As Integer, ByVal Target As Integer, ByVal TargetType As Integer, ByVal Message As String, ByVal Colour As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SChatBubble)

        Buffer.WriteInteger(Target)
        Buffer.WriteInteger(TargetType)
        'Buffer.WriteString(Message)
        Buffer.WriteUnicodeString(Message)
        Buffer.WriteInteger(Colour)
        SendDataToMap(MapNum, Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Public Sub SendPlayerAttack(ByVal Index As Integer)
        Dim Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SAttack)
        Buffer.WriteInteger(Index)
        SendDataToMapBut(Index, GetPlayerMap(Index), Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendNpcDead(ByVal MapNum As Integer, ByVal Index As Integer)
        Dim Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SNpcDead)
        Buffer.WriteInteger(Index)
        SendDataToMap(MapNum, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendTotalOnlineTo(ByVal Index As Integer)
        Dim Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.STotalOnline)
        Buffer.WriteInteger(GetTotalPlayersOnline)
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Public Sub SendTotalOnlineToAll()
        Dim Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.STotalOnline)
        Buffer.WriteInteger(GetTotalPlayersOnline)
        SendDataToAll(Buffer.ToArray)

        Buffer = Nothing
    End Sub
End Module