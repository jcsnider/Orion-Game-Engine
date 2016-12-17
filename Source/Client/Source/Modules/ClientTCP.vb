
Imports System.Net.Sockets
Imports System.IO
Imports System.Windows.Forms

Module ClientTCP
    Private PlayerBuffer As ByteBuffer = New ByteBuffer
    Public PlayerSocket As TcpClient
    Private SckConnecting As Boolean
    Private SckConnected As Boolean
    Private myStream As NetworkStream
    Private myReader As StreamReader
    Private myWriter As StreamWriter
    Private asyncBuff As Byte()
    Private asyncBuffs As New List(Of Byte())
    Public shouldHandleData As Boolean

    Public Sub Connect()
        If Not PlayerSocket Is Nothing Then
            Try
                If PlayerSocket.Connected Or SckConnecting Then Exit Sub
                PlayerSocket.Close()
                PlayerSocket = Nothing
            Catch ex As Exception

            End Try
        End If
        PlayerSocket = New TcpClient()
        PlayerSocket.ReceiveBufferSize = 4096
        PlayerSocket.SendBufferSize = 4096
        PlayerSocket.NoDelay = False
        ReDim asyncBuff(8192)
        PlayerSocket.BeginConnect(Options.IP, Options.Port, New AsyncCallback(AddressOf ConnectCallback), PlayerSocket)
        SckConnecting = True
    End Sub

    Sub ConnectCallback(asyncConnect As IAsyncResult)
        If Not PlayerSocket Is Nothing Then
            Try
                PlayerSocket.EndConnect(asyncConnect)
                If (PlayerSocket.Connected = False) Then
                    SckConnecting = False
                    SckConnected = False
                    Exit Sub
                Else
                    PlayerSocket.NoDelay = True
                    myStream = PlayerSocket.GetStream()
                    myStream.BeginRead(asyncBuff, 0, 8192, AddressOf OnReceive, Nothing)
                    SckConnected = True
                    SckConnecting = False
                End If
            Catch ex As Exception
                SckConnecting = False
                SckConnected = False
            End Try
        End If
    End Sub

    Sub OnReceive(ar As IAsyncResult)
        If Not PlayerSocket Is Nothing Then
            Try
                If PlayerSocket Is Nothing Then Exit Sub
                Dim byteAmt As Integer = myStream.EndRead(ar)
                Dim myBytes() As Byte
                ReDim myBytes(byteAmt - 1)
                Buffer.BlockCopy(asyncBuff, 0, myBytes, 0, byteAmt)
                If byteAmt = 0 Then
                    MsgBox("Disconnected.")
                    DestroyGame()
                    Exit Sub
                End If
                HandleData(myBytes)
                If PlayerSocket Is Nothing Then Exit Sub
                myStream.BeginRead(asyncBuff, 0, 8192, AddressOf OnReceive, Nothing)
            Catch ex As Exception
                MsgBox("Disconnected.")
                DestroyGame()
            End Try
        End If
    End Sub

    Public Function IsConnected() As Boolean
        If PlayerSocket Is Nothing Then Exit Function
        If PlayerSocket.Connected = True Then
            IsConnected = True
        Else
            IsConnected = False
        End If

    End Function

    Public Sub SendData(ByVal bytes() As Byte)
        Try
            If IsConnected() = False Then Exit Sub
            Dim buffer As ByteBuffer
            buffer = New ByteBuffer
            buffer.WriteInteger(UBound(bytes) - LBound(bytes) + 1)
            buffer.WriteBytes(bytes)
            'Send data in the socket stream to the server
            myStream.Write(buffer.ToArray, 0, buffer.ToArray.Length)
            buffer = Nothing
            'writes the packet size and sends the data.....
        Catch ex As Exception
            MsgBox("Disconnected.")
            Application.Exit()
        End Try
    End Sub

    Public Sub SendNewAccount(ByVal Name As String, ByVal Password As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CNewAccount)
        Buffer.WriteString(Name)
        Buffer.WriteString(Password)
        SendData(Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Public Sub SendAddChar(ByVal Slot As Integer, ByVal Name As String, ByVal Sex As Integer, ByVal ClassNum As Integer, ByVal Sprite As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CAddChar)
        Buffer.WriteInteger(Slot)
        Buffer.WriteString(Name)
        Buffer.WriteInteger(Sex)
        Buffer.WriteInteger(ClassNum)
        Buffer.WriteInteger(Sprite)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendLogin(ByVal Name As String, ByVal Password As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CLogin)
        Buffer.WriteString(Name)
        Buffer.WriteString(Password)
        Buffer.WriteString(Application.ProductVersion)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Function IsPlaying(ByVal Index As Integer) As Boolean

        ' if the player doesn't exist, the name will equal 0
        If Len(GetPlayerName(Index)) > 0 Then
            IsPlaying = True
        End If

    End Function

    Function GetPlayerName(ByVal Index As Integer) As String
        GetPlayerName = ""
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerName = Trim$(Player(Index).Name)
    End Function

    Sub GetPing()
        Dim Buffer As ByteBuffer
        PingStart = GetTickCount()
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CCheckPing)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditMap()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditMap)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendMap()
        Dim X As Integer
        Dim Y As Integer
        Dim i As Integer
        Dim data() As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        CanMoveNow = False

        Buffer.WriteString(Trim$(Map.Name))
        Buffer.WriteString(Trim$(Map.Music))
        Buffer.WriteInteger(Map.Moral)
        Buffer.WriteInteger(Map.tileset)
        Buffer.WriteInteger(Map.Up)
        Buffer.WriteInteger(Map.Down)
        Buffer.WriteInteger(Map.Left)
        Buffer.WriteInteger(Map.Right)
        Buffer.WriteInteger(Map.BootMap)
        Buffer.WriteInteger(Map.BootX)
        Buffer.WriteInteger(Map.BootY)
        Buffer.WriteInteger(Map.MaxX)
        Buffer.WriteInteger(Map.MaxY)
        Buffer.WriteInteger(Map.WeatherType)
        Buffer.WriteInteger(Map.FogIndex)
        Buffer.WriteInteger(Map.WeatherIntensity)
        Buffer.WriteInteger(Map.FogAlpha)
        Buffer.WriteInteger(Map.FogSpeed)
        Buffer.WriteInteger(Map.HasMapTint)
        Buffer.WriteInteger(Map.MapTintR)
        Buffer.WriteInteger(Map.MapTintG)
        Buffer.WriteInteger(Map.MapTintB)
        Buffer.WriteInteger(Map.MapTintA)

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteInteger(Map.Npc(i))
        Next

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                Buffer.WriteInteger(Map.Tile(X, Y).Data1)
                Buffer.WriteInteger(Map.Tile(X, Y).Data2)
                Buffer.WriteInteger(Map.Tile(X, Y).Data3)
                Buffer.WriteInteger(Map.Tile(X, Y).DirBlock)
                For i = 0 To MapLayer.Count - 1
                    Buffer.WriteInteger(Map.Tile(X, Y).Layer(i).Tileset)
                    Buffer.WriteInteger(Map.Tile(X, Y).Layer(i).X)
                    Buffer.WriteInteger(Map.Tile(X, Y).Layer(i).Y)
                    Buffer.WriteInteger(Map.Tile(X, Y).Layer(i).AutoTile)
                Next
                Buffer.WriteInteger(Map.Tile(X, Y).Type)
            Next
        Next

        'Event Data
        Buffer.WriteInteger(Map.EventCount)
        If Map.EventCount > 0 Then
            For i = 1 To Map.EventCount
                With Map.Events(i)
                    Buffer.WriteString(Trim$(.Name))
                    Buffer.WriteInteger(.Globals)
                    Buffer.WriteInteger(.X)
                    Buffer.WriteInteger(.Y)
                    Buffer.WriteInteger(.PageCount)
                End With
                If Map.Events(i).PageCount > 0 Then
                    For X = 1 To Map.Events(i).PageCount
                        With Map.Events(i).Pages(X)
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
                            Buffer.WriteInteger(Map.Events(i).Pages(X).MoveRouteCount)
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
                            Buffer.WriteInteger(.Questnum)

                            Buffer.WriteInteger(.chkPlayerGender)
                        End With
                        If Map.Events(i).Pages(X).CommandListCount > 0 Then
                            For Y = 1 To Map.Events(i).Pages(X).CommandListCount
                                Buffer.WriteInteger(Map.Events(i).Pages(X).CommandList(Y).CommandCount)
                                Buffer.WriteInteger(Map.Events(i).Pages(X).CommandList(Y).ParentList)
                                If Map.Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                    For z = 1 To Map.Events(i).Pages(X).CommandList(Y).CommandCount
                                        With Map.Events(i).Pages(X).CommandList(Y).Commands(z)
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

        data = Buffer.ToArray

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSaveMap)
        Buffer.WriteBytes(ArchaicIO.Compression.Compress(data))

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerMove()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CPlayerMove)
        Buffer.WriteInteger(GetPlayerDir(MyIndex))
        Buffer.WriteInteger(Player(MyIndex).Moving)
        Buffer.WriteInteger(Player(MyIndex).X)
        Buffer.WriteInteger(Player(MyIndex).Y)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SayMsg(ByVal text As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSayMsg)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendKick(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CKickPlayer)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendBan(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CBanPlayer)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WarpMeTo(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CWarpMeTo)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WarpToMe(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CWarpToMe)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WarpTo(ByVal MapNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CWarpTo)
        Buffer.WriteInteger(MapNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestLevelUp()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestLevelUp)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSpawnItem(ByVal tmpItem As Integer, ByVal tmpAmount As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSpawnItem)
        Buffer.WriteInteger(tmpItem)
        Buffer.WriteInteger(tmpAmount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSetSprite(ByVal SpriteNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSetSprite)
        Buffer.WriteInteger(SpriteNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSetAccess(ByVal Name As String, ByVal Access As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSetAccess)
        Buffer.WriteString(Name)
        Buffer.WriteInteger(Access)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendAttack()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CAttack)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestItems()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestItems)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerDir()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CPlayerDir)
        Buffer.WriteInteger(GetPlayerDir(MyIndex))
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerRequestNewMap()
        If GettingMap Then Exit Sub
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestNewMap)
        Buffer.WriteInteger(GetPlayerDir(MyIndex))
        SendData(Buffer.ToArray())
        Buffer = Nothing

        'Debug.Print("Client-PlayerRequestNewMap")
    End Sub

    Sub SendRequestResources()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestResources)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestNPCS()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestNPCS)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestSkills()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestSkills)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestShops()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestShops)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestAnimations()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestAnimations)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendMapRespawn()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CMapRespawn)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendTrainStat(ByVal StatNum As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CTrainStat)
        Buffer.WriteInteger(StatNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestPlayerData()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestPlayerData)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub BroadcastMsg(ByVal text As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CBroadcastMsg)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub PlayerMsg(ByVal text As String, ByVal MsgTo As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CPlayerMsg)
        Buffer.WriteString(MsgTo)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendWhosOnline()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CWhosOnline)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendMOTDChange(ByVal MOTD As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSetMotd)
        Buffer.WriteString(MOTD)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendBanList()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CBanList)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendChangeInvSlots(ByVal OldSlot As Integer, ByVal NewSlot As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSwapInvSlots)
        Buffer.WriteInteger(OldSlot)
        Buffer.WriteInteger(NewSlot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendUseItem(ByVal InvNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CUseItem)
        Buffer.WriteInteger(InvNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendDropItem(ByVal InvNum As Integer, ByVal Amount As Integer)
        Dim Buffer As ByteBuffer

        If InBank Or InShop Then Exit Sub

        ' do basic checks
        If InvNum < 1 Or InvNum > MAX_INV Then Exit Sub
        If PlayerInv(InvNum).Num < 1 Or PlayerInv(InvNum).Num > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(MyIndex, InvNum)).Stackable = 1 Then
            If Amount < 1 Or Amount > PlayerInv(InvNum).Value Then Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CMapDropItem)
        Buffer.WriteInteger(InvNum)
        Buffer.WriteInteger(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub BuyItem(ByVal shopslot As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CBuyItem)
        Buffer.WriteInteger(shopslot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SellItem(ByVal invslot As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSellItem)
        Buffer.WriteInteger(invslot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub DepositItem(ByVal invslot As Integer, ByVal Amount As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CDepositItem)
        Buffer.WriteInteger(invslot)
        Buffer.WriteInteger(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WithdrawItem(ByVal bankslot As Integer, ByVal Amount As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CWithdrawItem)
        Buffer.WriteInteger(bankslot)
        Buffer.WriteInteger(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub ChangeBankSlots(ByVal OldSlot As Integer, ByVal NewSlot As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CChangeBankSlots)
        Buffer.WriteInteger(OldSlot)
        Buffer.WriteInteger(NewSlot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub CloseBank()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CCloseBank)
        SendData(Buffer.ToArray())
        Buffer = Nothing
        InBank = False
        pnlBankVisible = False
    End Sub

    Sub PlayerSearch(ByVal CurX As Integer, ByVal CurY As Integer, ByVal RClick As Byte)
        Dim Buffer As ByteBuffer

        If isInBounds() Then
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ClientPackets.CSearch)
            Buffer.WriteInteger(CurX)
            Buffer.WriteInteger(CurY)
            Buffer.WriteInteger(RClick)
            SendData(Buffer.ToArray())
            Buffer = Nothing
        End If

    End Sub

    Public Sub AdminWarp(ByVal X As Integer, ByVal Y As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CAdminWarp)
        Buffer.WriteInteger(X)
        Buffer.WriteInteger(Y)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendTradeRequest(ByVal Name As String)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CTradeInvite)

        Buffer.WriteString(Name)

        SendData(Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub SendTradeInviteAccept(ByVal Awnser As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CTradeInviteAccept)

        Buffer.WriteInteger(Awnser)

        SendData(Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Public Sub TradeItem(ByVal invslot As Integer, ByVal Amount As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CTradeItem)
        Buffer.WriteInteger(invslot)
        Buffer.WriteInteger(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub UntradeItem(ByVal invslot As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CUntradeItem)
        Buffer.WriteInteger(invslot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub AcceptTrade()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CAcceptTrade)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub DeclineTrade()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CDeclineTrade)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendLeaveGame()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CQuit)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUnequip(ByVal EqNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CUnequip)
        Buffer.WriteInteger(EqNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub ForgetSkill(ByVal skillslot As Integer)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If skillslot < 1 Or skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        ' dont let them forget a skill which is in CD
        If SkillCD(skillslot) > 0 Then
            AddText("Cannot forget a skill which is cooling down!", QColorType.AlertColor)
            Exit Sub
        End If

        ' dont let them forget a skill which is buffered
        If SkillBuffer = skillslot Then
            AddText("Cannot forget a skill which you are casting!", QColorType.AlertColor)
            Exit Sub
        End If

        If PlayerSkills(skillslot) > 0 Then
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ClientPackets.CForgetSkill)
            Buffer.WriteInteger(skillslot)
            SendData(Buffer.ToArray())
            Buffer = Nothing
        Else
            AddText("No skill found.", QColorType.AlertColor)
        End If
    End Sub

    'Mapreport
    Public Sub SendRequestMapreport()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CMapReport)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestAdmin()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CAdmin)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestClasses()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestClasses)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendUseEmote(ByVal Emote As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CEmote)
        Buffer.WriteInteger(Emote)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub
End Module
