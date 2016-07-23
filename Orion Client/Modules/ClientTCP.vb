
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
            buffer.WriteLong(UBound(bytes) - LBound(bytes) + 1)
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
        Buffer.WriteLong(ClientPackets.CNewAccount)
        Buffer.WriteString(Name)
        Buffer.WriteString(Password)
        SendData(Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Public Sub SendAddChar(ByVal Slot As Long, ByVal Name As String, ByVal Sex As Long, ByVal ClassNum As Long, ByVal Sprite As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CAddChar)
        Buffer.WriteLong(Slot)
        Buffer.WriteString(Name)
        Buffer.WriteLong(Sex)
        Buffer.WriteLong(ClassNum)
        Buffer.WriteLong(Sprite)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendLogin(ByVal Name As String, ByVal Password As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CLogin)
        Buffer.WriteString(Name)
        Buffer.WriteString(Password)
        Buffer.WriteString(Application.ProductVersion)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Function IsPlaying(ByVal Index As Long) As Boolean

        ' if the player doesn't exist, the name will equal 0
        If Len(GetPlayerName(Index)) > 0 Then
            IsPlaying = True
        End If

    End Function

    Function GetPlayerName(ByVal Index As Long) As String
        GetPlayerName = ""
        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerName = Trim$(Player(Index).Name)
    End Function

    Sub GetPing()
        Dim Buffer As ByteBuffer
        PingStart = GetTickCount()
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CCheckPing)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditMap()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditMap)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendMap()
        Dim X As Long
        Dim Y As Long
        Dim i As Long
        Dim data() As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        CanMoveNow = False

        Buffer.WriteString(Trim$(Map.Name))
        Buffer.WriteString(Trim$(Map.Music))
        Buffer.WriteLong(Map.Moral)
        Buffer.WriteLong(Map.tileset)
        Buffer.WriteLong(Map.Up)
        Buffer.WriteLong(Map.Down)
        Buffer.WriteLong(Map.Left)
        Buffer.WriteLong(Map.Right)
        Buffer.WriteLong(Map.BootMap)
        Buffer.WriteLong(Map.BootX)
        Buffer.WriteLong(Map.BootY)
        Buffer.WriteLong(Map.MaxX)
        Buffer.WriteLong(Map.MaxY)
        Buffer.WriteLong(Map.WeatherType)
        Buffer.WriteLong(Map.FogIndex)
        Buffer.WriteLong(Map.WeatherIntensity)
        Buffer.WriteLong(Map.FogAlpha)
        Buffer.WriteLong(Map.FogSpeed)
        Buffer.WriteLong(Map.HasMapTint)
        Buffer.WriteLong(Map.MapTintR)
        Buffer.WriteLong(Map.MapTintG)
        Buffer.WriteLong(Map.MapTintB)
        Buffer.WriteLong(Map.MapTintA)

        For i = 1 To MAX_MAP_NPCS
            Buffer.WriteLong(Map.Npc(i))
        Next

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                Buffer.WriteLong(Map.Tile(X, Y).Data1)
                Buffer.WriteLong(Map.Tile(X, Y).Data2)
                Buffer.WriteLong(Map.Tile(X, Y).Data3)
                Buffer.WriteLong(Map.Tile(X, Y).DirBlock)
                For i = 0 To MapLayer.Layer_Count - 1
                    Buffer.WriteLong(Map.Tile(X, Y).Layer(i).tileset)
                    Buffer.WriteLong(Map.Tile(X, Y).Layer(i).X)
                    Buffer.WriteLong(Map.Tile(X, Y).Layer(i).Y)
                    Buffer.WriteLong(Map.Tile(X, Y).Autotile(i))
                Next
                Buffer.WriteLong(Map.Tile(X, Y).Type)
            Next
        Next

        'Event Data
        Buffer.WriteLong(Map.EventCount)
        If Map.EventCount > 0 Then
            For i = 1 To Map.EventCount
                With Map.Events(i)
                    Buffer.WriteString(Trim$(.Name))
                    Buffer.WriteLong(.Globals)
                    Buffer.WriteLong(.X)
                    Buffer.WriteLong(.Y)
                    Buffer.WriteLong(.PageCount)
                End With
                If Map.Events(i).PageCount > 0 Then
                    For X = 1 To Map.Events(i).PageCount
                        With Map.Events(i).Pages(X)
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
                            Buffer.WriteLong(Map.Events(i).Pages(X).MoveRouteCount)
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
                            Buffer.WriteLong(.Questnum)
                        End With
                        If Map.Events(i).Pages(X).CommandListCount > 0 Then
                            For Y = 1 To Map.Events(i).Pages(X).CommandListCount
                                Buffer.WriteLong(Map.Events(i).Pages(X).CommandList(Y).CommandCount)
                                Buffer.WriteLong(Map.Events(i).Pages(X).CommandList(Y).ParentList)
                                If Map.Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                    For z = 1 To Map.Events(i).Pages(X).CommandList(Y).CommandCount
                                        With Map.Events(i).Pages(X).CommandList(Y).Commands(z)
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

        data = Buffer.ToArray

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CMapData)
        Buffer.WriteBytes(Compress(data))

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerMove()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CPlayerMove)
        Buffer.WriteLong(GetPlayerDir(MyIndex))
        Buffer.WriteLong(Player(MyIndex).Moving)
        Buffer.WriteLong(Player(MyIndex).X)
        Buffer.WriteLong(Player(MyIndex).Y)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SayMsg(ByVal text As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSayMsg)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendKick(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CKickPlayer)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendBan(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CBanPlayer)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WarpMeTo(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CWarpMeTo)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WarpToMe(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CWarpToMe)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WarpTo(ByVal MapNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CWarpTo)
        Buffer.WriteLong(MapNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestLevelUp()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestLevelUp)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSpawnItem(ByVal tmpItem As Long, ByVal tmpAmount As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSpawnItem)
        Buffer.WriteLong(tmpItem)
        Buffer.WriteLong(tmpAmount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSetSprite(ByVal SpriteNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSetSprite)
        Buffer.WriteLong(SpriteNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSetAccess(ByVal Name As String, ByVal Access As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSetAccess)
        Buffer.WriteString(Name)
        Buffer.WriteLong(Access)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendAttack()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CAttack)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestItems()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestItems)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSaveItem(ByVal itemNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSaveItem)
        Buffer.WriteLong(itemNum)
        Buffer.WriteLong(Item(itemNum).AccessReq)

        For i = 0 To Stats.stat_count - 1
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
        Buffer.WriteString(Trim$(Item(itemNum).Name))
        Buffer.WriteLong(Item(itemNum).Paperdoll)
        Buffer.WriteLong(Item(itemNum).Pic)
        Buffer.WriteLong(Item(itemNum).Price)
        Buffer.WriteLong(Item(itemNum).Rarity)
        Buffer.WriteLong(Item(itemNum).Speed)

        Buffer.WriteLong(Item(itemNum).Randomize)
        Buffer.WriteLong(Item(itemNum).RandomMin)
        Buffer.WriteLong(Item(itemNum).RandomMax)

        Buffer.WriteLong(Item(itemNum).Stackable)
        Buffer.WriteString(Trim$(Item(itemNum).Description))

        For i = 0 To Stats.stat_count - 1
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

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditItem()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditItem)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerDir()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CPlayerDir)
        Buffer.WriteLong(GetPlayerDir(MyIndex))
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPlayerRequestNewMap()
        If GettingMap Then Exit Sub
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestNewMap)
        Buffer.WriteLong(GetPlayerDir(MyIndex))
        SendData(Buffer.ToArray())
        Buffer = Nothing

        'Debug.Print("Client-PlayerRequestNewMap")
    End Sub

    Public Sub SendRequestEditResource()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditResource)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestResources()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestResources)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveResource(ByVal ResourceNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSaveResource)

        Buffer.WriteLong(ResourceNum)
        Buffer.WriteLong(Resource(ResourceNum).Animation)
        Buffer.WriteString(Trim(Resource(ResourceNum).EmptyMessage))
        Buffer.WriteLong(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteLong(Resource(ResourceNum).Health)
        Buffer.WriteLong(Resource(ResourceNum).ExpReward)
        Buffer.WriteLong(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Trim(Resource(ResourceNum).Name))
        Buffer.WriteLong(Resource(ResourceNum).ResourceImage)
        Buffer.WriteLong(Resource(ResourceNum).ResourceType)
        Buffer.WriteLong(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Trim(Resource(ResourceNum).SuccessMessage))
        Buffer.WriteLong(Resource(ResourceNum).LvlRequired)
        Buffer.WriteLong(Resource(ResourceNum).ToolRequired)
        Buffer.WriteLong(Resource(ResourceNum).Walkthrough)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditNpc()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditNpc)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveNpc(ByVal NpcNum As Long)
        Dim Buffer As ByteBuffer, i As Long
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSaveNpc)
        Buffer.WriteLong(NpcNum)

        Buffer.WriteLong(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteLong(Npc(NpcNum).Behaviour)
        For i = 1 To 5
            Buffer.WriteLong(Npc(NpcNum).DropChance(i))
            Buffer.WriteLong(Npc(NpcNum).DropItem(i))
            Buffer.WriteLong(Npc(NpcNum).DropItemValue(i))
        Next

        Buffer.WriteLong(Npc(NpcNum).EXP)
        Buffer.WriteLong(Npc(NpcNum).faction)
        Buffer.WriteLong(Npc(NpcNum).HP)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteLong(Npc(NpcNum).Range)
        Buffer.WriteLong(Npc(NpcNum).SpawnSecs)
        Buffer.WriteLong(Npc(NpcNum).Sprite)

        For i = 0 To Stats.stat_count - 1
            Buffer.WriteLong(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteLong(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            Buffer.WriteLong(Npc(NpcNum).Skill(i))
        Next

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestNPCS()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestNPCS)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditSkill()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditSkill)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestSkills()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestSkills)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveSkill(ByVal skillnum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ClientPackets.CSaveSkill)
        Buffer.WriteLong(skillnum)

        Buffer.WriteLong(Skill(skillnum).AccessReq)
        Buffer.WriteLong(Skill(skillnum).AoE)
        Buffer.WriteLong(Skill(skillnum).CastAnim)
        Buffer.WriteLong(Skill(skillnum).CastTime)
        Buffer.WriteLong(Skill(skillnum).CDTime)
        Buffer.WriteLong(Skill(skillnum).ClassReq)
        Buffer.WriteLong(Skill(skillnum).Dir)
        Buffer.WriteLong(Skill(skillnum).Duration)
        Buffer.WriteLong(Skill(skillnum).Icon)
        Buffer.WriteLong(Skill(skillnum).Interval)
        Buffer.WriteLong(Skill(skillnum).IsAoE)
        Buffer.WriteLong(Skill(skillnum).LevelReq)
        Buffer.WriteLong(Skill(skillnum).Map)
        Buffer.WriteLong(Skill(skillnum).MPCost)
        Buffer.WriteString(Skill(skillnum).Name)
        Buffer.WriteLong(Skill(skillnum).Range)
        Buffer.WriteLong(Skill(skillnum).SkillAnim)
        Buffer.WriteLong(Skill(skillnum).StunDuration)
        Buffer.WriteLong(Skill(skillnum).Type)
        Buffer.WriteLong(Skill(skillnum).Vital)
        Buffer.WriteLong(Skill(skillnum).X)
        Buffer.WriteLong(Skill(skillnum).Y)

        Buffer.WriteLong(Skill(skillnum).IsProjectile)
        Buffer.WriteLong(Skill(skillnum).Projectile)

        Buffer.WriteLong(Skill(skillnum).KnockBack)
        Buffer.WriteLong(Skill(skillnum).KnockBackTiles)

        SendData(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendRequestShops()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestShops)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveShop(ByVal shopnum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSaveShop)
        Buffer.WriteLong(shopnum)

        Buffer.WriteLong(Shop(shopnum).BuyRate)
        Buffer.WriteString(Shop(shopnum).Name)
        Buffer.WriteLong(Shop(shopnum).Face)

        For i = 0 To MAX_TRADES
            Buffer.WriteLong(Shop(shopnum).TradeItem(i).CostItem)
            Buffer.WriteLong(Shop(shopnum).TradeItem(i).CostValue)
            Buffer.WriteLong(Shop(shopnum).TradeItem(i).Item)
            Buffer.WriteLong(Shop(shopnum).TradeItem(i).ItemValue)
        Next

        SendData(Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Public Sub SendRequestEditShop()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditShop)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveAnimation(ByVal Animationnum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSaveAnimation)
        Buffer.WriteLong(Animationnum)

        For i = 0 To UBound(Animation(Animationnum).Frames)
            Buffer.WriteLong(Animation(Animationnum).Frames(i))
        Next

        For i = 0 To UBound(Animation(Animationnum).LoopCount)
            Buffer.WriteLong(Animation(Animationnum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(Animationnum).looptime)
            Buffer.WriteLong(Animation(Animationnum).looptime(i))
        Next

        Buffer.WriteString(Trim(Animation(Animationnum).Name))

        For i = 0 To UBound(Animation(Animationnum).Sprite)
            Buffer.WriteLong(Animation(Animationnum).Sprite(i))
        Next


        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestAnimations()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestAnimations)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditAnimation()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditAnimation)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendBanDestroy()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CBanDestroy)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendMapRespawn()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CMapRespawn)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendTrainStat(ByVal StatNum As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CTrainStat)
        Buffer.WriteLong(StatNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestPlayerData()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestPlayerData)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub BroadcastMsg(ByVal text As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CBroadcastMsg)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub EmoteMsg(ByVal text As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CEmoteMsg)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub PlayerMsg(ByVal text As String, ByVal MsgTo As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CPlayerMsg)
        Buffer.WriteString(MsgTo)
        Buffer.WriteString(text)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendWhosOnline()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CWhosOnline)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendMOTDChange(ByVal MOTD As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSetMotd)
        Buffer.WriteString(MOTD)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendBanList()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CBanList)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendChangeInvSlots(ByVal OldSlot As Integer, ByVal NewSlot As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSwapInvSlots)
        Buffer.WriteInteger(OldSlot)
        Buffer.WriteInteger(NewSlot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendUseItem(ByVal InvNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CUseItem)
        Buffer.WriteLong(InvNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendDropItem(ByVal InvNum As Long, ByVal Amount As Long)
        Dim Buffer As ByteBuffer

        If InBank Or InShop Then Exit Sub

        ' do basic checks
        If InvNum < 1 Or InvNum > MAX_INV Then Exit Sub
        If PlayerInv(InvNum).Num < 1 Or PlayerInv(InvNum).Num > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Or Item(GetPlayerInvItemNum(MyIndex, InvNum)).Stackable = 1 Then
            If Amount < 1 Or Amount > PlayerInv(InvNum).Value Then Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CMapDropItem)
        Buffer.WriteLong(InvNum)
        Buffer.WriteLong(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub BuyItem(ByVal shopslot As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CBuyItem)
        Buffer.WriteLong(shopslot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SellItem(ByVal invslot As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSellItem)
        Buffer.WriteLong(invslot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub DepositItem(ByVal invslot As Long, ByVal Amount As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CDepositItem)
        Buffer.WriteLong(invslot)
        Buffer.WriteLong(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub WithdrawItem(ByVal bankslot As Long, ByVal Amount As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CWithdrawItem)
        Buffer.WriteLong(bankslot)
        Buffer.WriteLong(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub ChangeBankSlots(ByVal OldSlot As Long, ByVal NewSlot As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CChangeBankSlots)
        Buffer.WriteLong(OldSlot)
        Buffer.WriteLong(NewSlot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub CloseBank()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CCloseBank)
        SendData(Buffer.ToArray())
        Buffer = Nothing
        InBank = False
        pnlBankVisible = False
    End Sub

    Sub PlayerSearch(ByVal CurX As Integer, ByVal CurY As Integer, ByVal RClick As Byte)
        Dim Buffer As ByteBuffer

        If isInBounds() Then
            Buffer = New ByteBuffer
            Buffer.WriteLong(ClientPackets.CSearch)
            Buffer.WriteLong(CurX)
            Buffer.WriteLong(CurY)
            Buffer.WriteLong(RClick)
            SendData(Buffer.ToArray())
            Buffer = Nothing
        End If

    End Sub

    Public Sub AdminWarp(ByVal X As Long, ByVal Y As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CAdminWarp)
        Buffer.WriteLong(X)
        Buffer.WriteLong(Y)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendTradeRequest(ByVal Name As String)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CTradeInvite)

        Buffer.WriteString(Name)

        SendData(Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub SendTradeInviteAccept(ByVal Awnser As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CTradeInviteAccept)

        Buffer.WriteLong(Awnser)

        SendData(Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Public Sub TradeItem(ByVal invslot As Long, ByVal Amount As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CTradeItem)
        Buffer.WriteLong(invslot)
        Buffer.WriteLong(Amount)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub UntradeItem(ByVal invslot As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CUntradeItem)
        Buffer.WriteLong(invslot)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub AcceptTrade()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CAcceptTrade)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub DeclineTrade()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CDeclineTrade)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPartyRequest(ByVal Name As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CParty)
        Buffer.WriteString(Name)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendJoinParty()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CJoinParty)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendLeaveGame()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CQuit)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendLeaveParty()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CLeaveParty)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendUnequip(ByVal EqNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CUnequip)
        Buffer.WriteLong(EqNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub ForgetSkill(ByVal skillslot As Long)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If skillslot < 1 Or skillslot > MAX_PLAYER_SKILLS Then
            Exit Sub
        End If

        ' dont let them forget a skill which is in CD
        If SkillCD(skillslot) > 0 Then
            AddText("Cannot forget a skill which is cooling down!", AlertColor)
            Exit Sub
        End If

        ' dont let them forget a skill which is buffered
        If SkillBuffer = skillslot Then
            AddText("Cannot forget a skill which you are casting!", AlertColor)
            Exit Sub
        End If

        If PlayerSkills(skillslot) > 0 Then
            Buffer = New ByteBuffer
            Buffer.WriteLong(ClientPackets.CForgetSkill)
            Buffer.WriteLong(skillslot)
            SendData(Buffer.ToArray())
            Buffer = Nothing
        Else
            AddText("No skill found.", AlertColor)
        End If
    End Sub

    'Mapreport
    Public Sub SendRequestMapreport()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CMapReport)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestAdmin()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CAdmin)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestClasses()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestClasses)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditClass()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CRequestEditClasses)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveClasses()
        Dim i As Long, n As Long, q As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ClientPackets.CSaveClasses)

        Buffer.WriteLong(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(Trim$(Classes(i).Name))
            Buffer.WriteString(Trim$(Classes(i).Desc))

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
            Buffer.WriteLong(Classes(i).Stat(Stats.luck))
            Buffer.WriteLong(Classes(i).Stat(Stats.spirit))

            For q = 1 To 5
                Buffer.WriteLong(Classes(i).StartItem(q))
                Buffer.WriteLong(Classes(i).StartValue(q))
            Next

            Buffer.WriteLong(Classes(i).StartMap)
            Buffer.WriteLong(Classes(i).StartX)
            Buffer.WriteLong(Classes(i).StartY)

            Buffer.WriteLong(Classes(i).BaseExp)
        Next

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub
End Module
