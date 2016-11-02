Imports System.Net.Sockets
Imports System.IO

Module EditorTCP
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
        PlayerSocket.BeginConnect("localhost", 7001, New AsyncCallback(AddressOf ConnectCallback), PlayerSocket)
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
                    Exit Sub
                End If
                HandleData(myBytes)
                If PlayerSocket Is Nothing Then Exit Sub
                myStream.BeginRead(asyncBuff, 0, 8192, AddressOf OnReceive, Nothing)
            Catch ex As Exception
                MsgBox("Disconnected.")
                Exit Sub
            End Try
        End If
    End Sub

    Public Function IsConnected() As Boolean
        IsConnected = False

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

    Public Sub SendEditorLogin(ByVal Name As String, ByVal Password As String)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CEditorLogin)
        Buffer.WriteString(Name)
        Buffer.WriteString(Password)
        Buffer.WriteString(Application.ProductVersion)
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

    Public Sub SendEditorMap()
        Dim X As Integer
        Dim Y As Integer
        Dim i As Integer
        Dim data() As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(Map.MapNum)

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
        Buffer.WriteInteger(ClientPackets.CEditorMapData)
        Buffer.WriteBytes(ArchaicIO.Compression.Compress(data))

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

    Sub SendSaveItem(ByVal itemNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSaveItem)
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
        Buffer.WriteInteger(Item(itemNum).Handed)
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

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditItem()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditItem)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditResource()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditResource)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestResources()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestResources)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveResource(ByVal ResourceNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSaveResource)

        Buffer.WriteInteger(ResourceNum)
        Buffer.WriteInteger(Resource(ResourceNum).Animation)
        Buffer.WriteString(Trim(Resource(ResourceNum).EmptyMessage))
        Buffer.WriteInteger(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteInteger(Resource(ResourceNum).Health)
        Buffer.WriteInteger(Resource(ResourceNum).ExpReward)
        Buffer.WriteInteger(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Trim(Resource(ResourceNum).Name))
        Buffer.WriteInteger(Resource(ResourceNum).ResourceImage)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceType)
        Buffer.WriteInteger(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Trim(Resource(ResourceNum).SuccessMessage))
        Buffer.WriteInteger(Resource(ResourceNum).LvlRequired)
        Buffer.WriteInteger(Resource(ResourceNum).ToolRequired)
        Buffer.WriteInteger(Resource(ResourceNum).Walkthrough)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendRequestEditNpc()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditNpc)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveNpc(ByVal NpcNum As Integer)
        Dim Buffer As ByteBuffer, i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSaveNpc)
        Buffer.WriteInteger(NpcNum)

        Buffer.WriteInteger(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteInteger(Npc(NpcNum).Behaviour)
        For i = 1 To 5
            Buffer.WriteInteger(Npc(NpcNum).DropChance(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItem(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItemValue(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).EXP)
        Buffer.WriteInteger(Npc(NpcNum).Faction)
        Buffer.WriteInteger(Npc(NpcNum).HP)
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

    Public Sub SendRequestEditSkill()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditSkill)
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

    Public Sub SendSaveSkill(ByVal skillnum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CSaveSkill)
        Buffer.WriteInteger(skillnum)

        Buffer.WriteInteger(Skill(skillnum).AccessReq)
        Buffer.WriteInteger(Skill(skillnum).AoE)
        Buffer.WriteInteger(Skill(skillnum).CastAnim)
        Buffer.WriteInteger(Skill(skillnum).CastTime)
        Buffer.WriteInteger(Skill(skillnum).CDTime)
        Buffer.WriteInteger(Skill(skillnum).ClassReq)
        Buffer.WriteInteger(Skill(skillnum).Dir)
        Buffer.WriteInteger(Skill(skillnum).Duration)
        Buffer.WriteInteger(Skill(skillnum).Icon)
        Buffer.WriteInteger(Skill(skillnum).Interval)
        Buffer.WriteInteger(Skill(skillnum).IsAoE)
        Buffer.WriteInteger(Skill(skillnum).LevelReq)
        Buffer.WriteInteger(Skill(skillnum).Map)
        Buffer.WriteInteger(Skill(skillnum).MPCost)
        Buffer.WriteString(Skill(skillnum).Name)
        Buffer.WriteInteger(Skill(skillnum).Range)
        Buffer.WriteInteger(Skill(skillnum).SkillAnim)
        Buffer.WriteInteger(Skill(skillnum).StunDuration)
        Buffer.WriteInteger(Skill(skillnum).Type)
        Buffer.WriteInteger(Skill(skillnum).Vital)
        Buffer.WriteInteger(Skill(skillnum).X)
        Buffer.WriteInteger(Skill(skillnum).Y)

        Buffer.WriteInteger(Skill(skillnum).IsProjectile)
        Buffer.WriteInteger(Skill(skillnum).Projectile)

        Buffer.WriteInteger(Skill(skillnum).KnockBack)
        Buffer.WriteInteger(Skill(skillnum).KnockBackTiles)

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

    Public Sub SendSaveShop(ByVal shopnum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSaveShop)
        Buffer.WriteInteger(shopnum)

        Buffer.WriteInteger(Shop(shopnum).BuyRate)
        Buffer.WriteString(Shop(shopnum).Name)
        Buffer.WriteInteger(Shop(shopnum).Face)

        For i = 0 To MAX_TRADES
            Buffer.WriteInteger(Shop(shopnum).TradeItem(i).CostItem)
            Buffer.WriteInteger(Shop(shopnum).TradeItem(i).CostValue)
            Buffer.WriteInteger(Shop(shopnum).TradeItem(i).Item)
            Buffer.WriteInteger(Shop(shopnum).TradeItem(i).ItemValue)
        Next

        SendData(Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Public Sub SendRequestEditShop()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditShop)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveAnimation(ByVal Animationnum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSaveAnimation)
        Buffer.WriteInteger(Animationnum)

        For i = 0 To UBound(Animation(Animationnum).Frames)
            Buffer.WriteInteger(Animation(Animationnum).Frames(i))
        Next

        For i = 0 To UBound(Animation(Animationnum).LoopCount)
            Buffer.WriteInteger(Animation(Animationnum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(Animationnum).looptime)
            Buffer.WriteInteger(Animation(Animationnum).looptime(i))
        Next

        Buffer.WriteString(Trim(Animation(Animationnum).Name))

        For i = 0 To UBound(Animation(Animationnum).Sprite)
            Buffer.WriteInteger(Animation(Animationnum).Sprite(i))
        Next


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

    Public Sub SendRequestEditAnimation()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditAnimation)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    'Mapreport
    Public Sub SendRequestMapreport()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CMapReport)
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

    Public Sub SendRequestEditClass()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestEditClasses)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendSaveClasses()
        Dim i As Integer, n As Integer, q As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CSaveClasses)

        Buffer.WriteInteger(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(Trim$(Classes(i).Name))
            Buffer.WriteString(Trim$(Classes(i).Desc))

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

    Public Sub SendEditorRequestMap(ByVal MapNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CEditorRequestMap)
        Buffer.WriteInteger(MapNum)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

End Module
