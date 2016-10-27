Module EditorHandleData
    Public PlayerBuffer As ByteBuffer
    Private Delegate Sub Packet_(ByVal Data() As Byte)
    Private Packets As Dictionary(Of Integer, Packet_)

    Public Sub HandleData(ByVal data() As Byte)
        Dim Buffer() As Byte
        Buffer = data.Clone
        Dim pLength As Integer

        If PlayerBuffer Is Nothing Then PlayerBuffer = New ByteBuffer
        PlayerBuffer.WriteBytes(Buffer)

        If PlayerBuffer.Count = 0 Then
            PlayerBuffer.Clear()
            Exit Sub
        End If

        If PlayerBuffer.Length >= 4 Then
            pLength = PlayerBuffer.ReadInteger(False)

            If pLength <= 0 Then
                PlayerBuffer.Clear()
                Exit Sub
            End If
        End If

        If PlayerBuffer.Length >= 4 Then
            pLength = PlayerBuffer.ReadInteger(False)

            If pLength <= 0 Then
                PlayerBuffer.Clear()
                Exit Sub
            End If
        End If

        Do While pLength > 0 And pLength <= PlayerBuffer.Length - 4

            If pLength <= PlayerBuffer.Length - 4 Then
                PlayerBuffer.ReadInteger()
                data = PlayerBuffer.ReadBytes(pLength)
                HandleDataPackets(data)
            End If

            pLength = 0

            If PlayerBuffer.Length >= 4 Then
                pLength = PlayerBuffer.ReadInteger(False)

                If pLength < 0 Then
                    PlayerBuffer.Clear()
                    Exit Sub
                End If
            End If

        Loop
    End Sub

    Public Sub InitMessages()
        Packets = New Dictionary(Of Integer, Packet_)

        Packets.Add(ServerPackets.SAlertMsg, AddressOf Packet_AlertMSG)

        Packets.Add(ServerPackets.SLoginOk, AddressOf Packet_LoginOk)
        Packets.Add(ServerPackets.SClassesData, AddressOf Packet_ClassesData)

        Packets.Add(ServerPackets.SMapData, AddressOf Packet_MapData)

        Packets.Add(ServerPackets.SMapNpcData, AddressOf Packet_MapNPCData)
        Packets.Add(ServerPackets.SMapNpcUpdate, AddressOf Packet_MapNPCUpdate)

        Packets.Add(ServerPackets.SItemEditor, AddressOf Packet_EditItem)
        Packets.Add(ServerPackets.SUpdateItem, AddressOf Packet_UpdateItem)

        Packets.Add(ServerPackets.SREditor, AddressOf Packet_ResourceEditor)

        Packets.Add(ServerPackets.SNpcEditor, AddressOf Packet_NPCEditor)
        Packets.Add(ServerPackets.SUpdateNpc, AddressOf Packet_UpdateNPC)

        Packets.Add(ServerPackets.SEditMap, AddressOf Packet_EditMap)

        Packets.Add(ServerPackets.SShopEditor, AddressOf Packet_EditShop)
        Packets.Add(ServerPackets.SUpdateShop, AddressOf Packet_UpdateShop)

        Packets.Add(ServerPackets.SSkillEditor, AddressOf Packet_EditSkill)
        Packets.Add(ServerPackets.SUpdateSkill, AddressOf Packet_UpdateSkill)

        Packets.Add(ServerPackets.SResourceEditor, AddressOf Packet_ResourceEditor)
        Packets.Add(ServerPackets.SUpdateResource, AddressOf Packet_UpdateResource)

        Packets.Add(ServerPackets.SAnimationEditor, AddressOf Packet_EditAnimation)
        Packets.Add(ServerPackets.SUpdateAnimation, AddressOf Packet_UpdateAnimation)

        Packets.Add(ServerPackets.SGameData, AddressOf Packet_GameData)
        Packets.Add(ServerPackets.SMapReport, AddressOf Packet_Mapreport) 'Mapreport

        Packets.Add(ServerPackets.SMapNames, AddressOf Packet_MapNames)

        'quests
        Packets.Add(ServerPackets.SQuestEditor, AddressOf Packet_QuestEditor)
        Packets.Add(ServerPackets.SUpdateQuest, AddressOf Packet_UpdateQuest)

        'Housing
        Packets.Add(ServerPackets.SHouseConfigs, AddressOf Packet_HouseConfigurations)
        Packets.Add(ServerPackets.SFurniture, AddressOf Packet_Furniture)
        Packets.Add(ServerPackets.SHouseEdit, AddressOf Packet_EditHouses)

        'Events
        Packets.Add(ServerPackets.SSpawnEvent, AddressOf Packet_SpawnEvent)
        Packets.Add(ServerPackets.SEventMove, AddressOf Packet_EventMove)
        Packets.Add(ServerPackets.SEventDir, AddressOf Packet_EventDir)
        Packets.Add(ServerPackets.SEventChat, AddressOf Packet_EventChat)
        Packets.Add(ServerPackets.SEventStart, AddressOf Packet_EventStart)
        Packets.Add(ServerPackets.SEventEnd, AddressOf Packet_EventEnd)
        Packets.Add(ServerPackets.SSwitchesAndVariables, AddressOf Packet_SwitchesAndVariables)
        Packets.Add(ServerPackets.SMapEventData, AddressOf Packet_MapEventData)
        'SChatBubble
        'SPic
        Packets.Add(ServerPackets.SHoldPlayer, AddressOf Packet_HoldPlayer)

        Packets.Add(ServerPackets.SProjectileEditor, AddressOf HandleProjectileEditor)
        Packets.Add(ServerPackets.SUpdateProjectile, AddressOf HandleUpdateProjectile)
        Packets.Add(ServerPackets.SMapProjectile, AddressOf HandleMapProjectile)

        'craft
        Packets.Add(ServerPackets.SUpdateRecipe, AddressOf Packet_UpdateRecipe)
        Packets.Add(ServerPackets.SRecipeEditor, AddressOf Packet_RecipeEditor)

        Packets.Add(ServerPackets.SClassEditor, AddressOf Packet_ClassEditor)
    End Sub

    Sub HandleDataPackets(ByVal data() As Byte)
        Dim packetnum As Integer, buffer As ByteBuffer, Packet As Packet_
        Packet = Nothing
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        packetnum = buffer.ReadInteger
        buffer = Nothing

        If packetnum = ServerPackets.SNews Then Exit Sub

        If Packets.TryGetValue(packetnum, Packet) Then
            Packet.Invoke(data)
        End If
    End Sub

    Sub Packet_AlertMSG(ByVal data() As Byte)
        Dim Msg As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SAlertMsg Then Exit Sub

        Msg = Buffer.ReadString

        Buffer = Nothing

        MsgBox(Msg, vbOKOnly, "OrionClient+ Editors")

        CloseEditor()
    End Sub

    Sub Packet_LoginOk(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SLoginOk Then Exit Sub

        InitEditor = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_ClassesData(ByVal data() As Byte)
        Dim i As Integer
        Dim z As Integer, X As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SClassesData Then Exit Sub

        ' Max classes
        Max_Classes = Buffer.ReadInteger
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Vital(0 To Vitals.Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Trim$(Buffer.ReadString)
                .Desc = Trim$(Buffer.ReadString)

                .Vital(Vitals.HP) = Buffer.ReadInteger
                .Vital(Vitals.MP) = Buffer.ReadInteger
                .Vital(Vitals.SP) = Buffer.ReadInteger

                ' get array size
                z = Buffer.ReadInteger
                ' redim array
                ReDim .MaleSprite(0 To z)
                ' loop-receive data
                For X = 0 To z
                    .MaleSprite(X) = Buffer.ReadInteger
                Next

                ' get array size
                z = Buffer.ReadInteger
                ' redim array
                ReDim .FemaleSprite(0 To z)
                ' loop-receive data
                For X = 0 To z
                    .FemaleSprite(X) = Buffer.ReadInteger
                Next

                .Stat(Stats.strength) = Buffer.ReadInteger
                .Stat(Stats.endurance) = Buffer.ReadInteger
                .Stat(Stats.vitality) = Buffer.ReadInteger
                .Stat(Stats.intelligence) = Buffer.ReadInteger
                .Stat(Stats.luck) = Buffer.ReadInteger
                .Stat(Stats.spirit) = Buffer.ReadInteger

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = Buffer.ReadInteger
                    .StartValue(q) = Buffer.ReadInteger
                Next

                .StartMap = Buffer.ReadInteger
                .StartX = Buffer.ReadInteger
                .StartY = Buffer.ReadInteger

                .BaseExp = Buffer.ReadInteger
            End With

        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapData(ByVal Data() As Byte)
        Dim X As Integer, Y As Integer, i As Integer
        Dim MapNum As Integer, MusicFile As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapData Then Exit Sub

        Data = Buffer.ReadBytes(Buffer.Count - 4)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Decompress(Data))

        MapData = False

        SyncLock MapLock
            If Buffer.ReadInteger = 1 Then

                MapNum = Buffer.ReadInteger
                Map.Name = Trim(Buffer.ReadString)
                Map.Music = Trim(Buffer.ReadString)
                Map.Revision = Buffer.ReadInteger
                Map.Moral = Buffer.ReadInteger
                Map.tileset = Buffer.ReadInteger
                Map.Up = Buffer.ReadInteger
                Map.Down = Buffer.ReadInteger
                Map.Left = Buffer.ReadInteger
                Map.Right = Buffer.ReadInteger
                Map.BootMap = Buffer.ReadInteger
                Map.BootX = Buffer.ReadInteger
                Map.BootY = Buffer.ReadInteger
                Map.MaxX = Buffer.ReadInteger
                Map.MaxY = Buffer.ReadInteger
                Map.WeatherType = Buffer.ReadInteger
                Map.FogIndex = Buffer.ReadInteger
                Map.WeatherIntensity = Buffer.ReadInteger
                Map.FogAlpha = Buffer.ReadInteger
                Map.FogSpeed = Buffer.ReadInteger
                Map.HasMapTint = Buffer.ReadInteger
                Map.MapTintR = Buffer.ReadInteger
                Map.MapTintG = Buffer.ReadInteger
                Map.MapTintB = Buffer.ReadInteger
                Map.MapTintA = Buffer.ReadInteger

                ReDim Map.Tile(0 To Map.MaxX, 0 To Map.MaxY)

                For X = 1 To MAX_MAP_NPCS
                    Map.Npc(X) = Buffer.ReadInteger
                Next

                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Data1 = Buffer.ReadInteger
                        Map.Tile(X, Y).Data2 = Buffer.ReadInteger
                        Map.Tile(X, Y).Data3 = Buffer.ReadInteger
                        Map.Tile(X, Y).DirBlock = Buffer.ReadInteger

                        ReDim Map.Tile(X, Y).Layer(0 To MapLayer.Count - 1)

                        For i = 0 To MapLayer.Count - 1
                            Map.Tile(X, Y).Layer(i).Tileset = Buffer.ReadInteger
                            Map.Tile(X, Y).Layer(i).X = Buffer.ReadInteger
                            Map.Tile(X, Y).Layer(i).Y = Buffer.ReadInteger
                            Map.Tile(X, Y).Layer(i).AutoTile = Buffer.ReadInteger
                        Next
                        Map.Tile(X, Y).Type = Buffer.ReadInteger
                    Next
                Next

                'Event Data!
                ResetEventdata()

                Map.EventCount = Buffer.ReadInteger

                If Map.EventCount > 0 Then
                    ReDim Map.Events(0 To Map.EventCount)
                    For i = 1 To Map.EventCount
                        With Map.Events(i)
                            .Name = Trim(Buffer.ReadString)
                            .Globals = Buffer.ReadInteger
                            .X = Buffer.ReadInteger
                            .Y = Buffer.ReadInteger
                            .PageCount = Buffer.ReadInteger
                        End With
                        If Map.Events(i).PageCount > 0 Then
                            ReDim Map.Events(i).Pages(0 To Map.Events(i).PageCount)
                            For X = 1 To Map.Events(i).PageCount
                                With Map.Events(i).Pages(X)
                                    .chkVariable = Buffer.ReadInteger
                                    .VariableIndex = Buffer.ReadInteger
                                    .VariableCondition = Buffer.ReadInteger
                                    .VariableCompare = Buffer.ReadInteger

                                    .chkSwitch = Buffer.ReadInteger
                                    .SwitchIndex = Buffer.ReadInteger
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
                                        ReDim Map.Events(i).Pages(X).MoveRoute(0 To .MoveRouteCount)
                                        For Y = 1 To .MoveRouteCount
                                            .MoveRoute(Y).Index = Buffer.ReadInteger
                                            .MoveRoute(Y).Data1 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data2 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data3 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data4 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data5 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data6 = Buffer.ReadInteger
                                        Next
                                    End If

                                    .WalkAnim = Buffer.ReadInteger
                                    .DirFix = Buffer.ReadInteger
                                    .WalkThrough = Buffer.ReadInteger
                                    .ShowName = Buffer.ReadInteger
                                    .Trigger = Buffer.ReadInteger
                                    .CommandListCount = Buffer.ReadInteger

                                    .Position = Buffer.ReadInteger
                                    .Questnum = Buffer.ReadInteger

                                    .chkPlayerGender = Buffer.ReadInteger
                                End With

                                If Map.Events(i).Pages(X).CommandListCount > 0 Then
                                    ReDim Map.Events(i).Pages(X).CommandList(0 To Map.Events(i).Pages(X).CommandListCount)
                                    For Y = 1 To Map.Events(i).Pages(X).CommandListCount
                                        Map.Events(i).Pages(X).CommandList(Y).CommandCount = Buffer.ReadInteger
                                        Map.Events(i).Pages(X).CommandList(Y).ParentList = Buffer.ReadInteger
                                        If Map.Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                            ReDim Map.Events(i).Pages(X).CommandList(Y).Commands(0 To Map.Events(i).Pages(X).CommandList(Y).CommandCount)
                                            For z = 1 To Map.Events(i).Pages(X).CommandList(Y).CommandCount
                                                With Map.Events(i).Pages(X).CommandList(Y).Commands(z)
                                                    .Index = Buffer.ReadInteger
                                                    .Text1 = Trim(Buffer.ReadString)
                                                    .Text2 = Trim(Buffer.ReadString)
                                                    .Text3 = Trim(Buffer.ReadString)
                                                    .Text4 = Trim(Buffer.ReadString)
                                                    .Text5 = Trim(Buffer.ReadString)
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
                                                    If .MoveRouteCount > 0 Then
                                                        ReDim Preserve .MoveRoute(.MoveRouteCount)
                                                        For w = 1 To .MoveRouteCount
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

            End If

            For i = 1 To MAX_MAP_ITEMS
                MapItem(i).Num = Buffer.ReadInteger
                MapItem(i).Value = Buffer.ReadInteger()
                MapItem(i).X = Buffer.ReadInteger()
                MapItem(i).Y = Buffer.ReadInteger()
            Next

            For i = 1 To MAX_MAP_NPCS
                MapNpc(i).Num = Buffer.ReadInteger()
                MapNpc(i).X = Buffer.ReadInteger()
                MapNpc(i).Y = Buffer.ReadInteger()
                MapNpc(i).Dir = Buffer.ReadInteger()
                MapNpc(i).Vital(Vitals.HP) = Buffer.ReadInteger()
                MapNpc(i).Vital(Vitals.MP) = Buffer.ReadInteger()
            Next

            If Buffer.ReadInteger = 1 Then
                Resource_Index = Buffer.ReadInteger
                Resources_Init = False

                If Resource_Index > 0 Then
                    ReDim MapResource(0 To Resource_Index)

                    For i = 0 To Resource_Index
                        MapResource(i).ResourceState = Buffer.ReadInteger
                        MapResource(i).X = Buffer.ReadInteger
                        MapResource(i).Y = Buffer.ReadInteger
                    Next

                    Resources_Init = True
                Else
                    ReDim MapResource(0 To 1)
                End If
            End If

            Buffer = Nothing

        End SyncLock

        initAutotiles()
        'Debug.Print("Client Handled Autotile Init")

        MapData = True

        CurrentWeather = Map.WeatherType
        CurrentWeatherIntensity = Map.WeatherIntensity
        CurrentFog = Map.FogIndex
        CurrentFogSpeed = Map.FogSpeed
        CurrentFogOpacity = Map.FogAlpha
        CurrentTintR = Map.MapTintR
        CurrentTintG = Map.MapTintG
        CurrentTintB = Map.MapTintB
        CurrentTintA = Map.MapTintA

        MusicFile = Trim$(Map.Music)

    End Sub

    Private Sub Packet_MapNPCData(ByVal Data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNpcData Then Exit Sub

        For i = 1 To MAX_MAP_NPCS

            With MapNpc(i)
                .Num = Buffer.ReadInteger
                .X = Buffer.ReadInteger
                .Y = Buffer.ReadInteger
                .Dir = Buffer.ReadInteger
                .Vital(Vitals.HP) = Buffer.ReadInteger
                .Vital(Vitals.MP) = Buffer.ReadInteger
            End With

        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapNPCUpdate(ByVal Data() As Byte)
        Dim NpcNum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNpcUpdate Then Exit Sub

        NpcNum = Buffer.ReadInteger

        With MapNpc(NpcNum)
            .Num = Buffer.ReadInteger
            .X = Buffer.ReadInteger
            .Y = Buffer.ReadInteger
            .Dir = Buffer.ReadInteger
            .Vital(Vitals.HP) = Buffer.ReadInteger
            .Vital(Vitals.MP) = Buffer.ReadInteger
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_EditItem(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SItemEditor Then Exit Sub

        InitItemEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateItem(ByVal data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateItem Then Exit Sub

        n = Buffer.ReadInteger

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
        Item(n).Handed = Buffer.ReadInteger()
        Item(n).LevelReq = Buffer.ReadInteger()
        Item(n).Mastery = Buffer.ReadInteger()
        Item(n).Name = Trim$(Buffer.ReadString())
        Item(n).Paperdoll = Buffer.ReadInteger()
        Item(n).Pic = Buffer.ReadInteger()
        Item(n).Price = Buffer.ReadInteger()
        Item(n).Rarity = Buffer.ReadInteger()
        Item(n).Speed = Buffer.ReadInteger()

        Item(n).Randomize = Buffer.ReadInteger()
        Item(n).RandomMin = Buffer.ReadInteger()
        Item(n).RandomMax = Buffer.ReadInteger()

        Item(n).Stackable = Buffer.ReadInteger()
        Item(n).Description = Trim$(Buffer.ReadString())

        For i = 0 To Stats.Count - 1
            Item(n).Stat_Req(i) = Buffer.ReadInteger()
        Next

        Item(n).Type = Buffer.ReadInteger()

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

        Buffer = Nothing

    End Sub

    Sub Packet_NPCEditor(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SNpcEditor Then Exit Sub

        InitNPCEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateNPC(ByVal data() As Byte)
        Dim i As Integer, x As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateNpc Then Exit Sub

        i = Buffer.ReadInteger
        ' Update the Npc
        Npc(i).Animation = Buffer.ReadInteger()
        Npc(i).AttackSay = Trim(Buffer.ReadString())
        Npc(i).Behaviour = Buffer.ReadInteger()
        ReDim Npc(i).DropChance(5)
        ReDim Npc(i).DropItem(5)
        ReDim Npc(i).DropItemValue(5)
        For x = 1 To 5
            Npc(i).DropChance(x) = Buffer.ReadInteger()
            Npc(i).DropItem(x) = Buffer.ReadInteger()
            Npc(i).DropItemValue(x) = Buffer.ReadInteger()
        Next

        Npc(i).EXP = Buffer.ReadInteger()
        Npc(i).Faction = Buffer.ReadInteger()
        Npc(i).HP = Buffer.ReadInteger()
        Npc(i).Name = Trim(Buffer.ReadString())
        Npc(i).Range = Buffer.ReadInteger()
        Npc(i).SpawnSecs = Buffer.ReadInteger()
        Npc(i).Sprite = Buffer.ReadInteger()

        For i = 0 To Stats.Count - 1
            Npc(i).Stat(i) = Buffer.ReadInteger()
        Next

        Npc(i).QuestNum = Buffer.ReadInteger()

        For x = 1 To MAX_NPC_SKILLS
            Npc(i).Skill(x) = Buffer.ReadInteger()
        Next

        If Npc(i).AttackSay Is Nothing Then Npc(i).AttackSay = ""
        If Npc(i).Name Is Nothing Then Npc(i).Name = ""

        Buffer = Nothing
    End Sub

    Sub Packet_EditMap(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SEditMap Then Exit Sub

        InitMapEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_EditShop(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SShopEditor Then Exit Sub

        InitShopEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateShop(ByVal data() As Byte)
        Dim shopnum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateShop Then Exit Sub

        shopnum = Buffer.ReadInteger

        Shop(shopnum).BuyRate = Buffer.ReadInteger()
        Shop(shopnum).Name = Trim(Buffer.ReadString())
        Shop(shopnum).Face = Buffer.ReadInteger()

        For i = 0 To MAX_TRADES
            Shop(shopnum).TradeItem(i).CostItem = Buffer.ReadInteger()
            Shop(shopnum).TradeItem(i).CostValue = Buffer.ReadInteger()
            Shop(shopnum).TradeItem(i).Item = Buffer.ReadInteger()
            Shop(shopnum).TradeItem(i).ItemValue = Buffer.ReadInteger()
        Next

        If Shop(shopnum).Name Is Nothing Then Shop(shopnum).Name = ""

        Buffer = Nothing
    End Sub

    Sub Packet_EditSkill(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SSkillEditor Then Exit Sub

        InitSkillEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateSkill(ByVal data() As Byte)
        Dim skillnum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateSkill Then Exit Sub

        skillnum = Buffer.ReadInteger

        Skill(skillnum).AccessReq = Buffer.ReadInteger()
        Skill(skillnum).AoE = Buffer.ReadInteger()
        Skill(skillnum).CastAnim = Buffer.ReadInteger()
        Skill(skillnum).CastTime = Buffer.ReadInteger()
        Skill(skillnum).CDTime = Buffer.ReadInteger()
        Skill(skillnum).ClassReq = Buffer.ReadInteger()
        Skill(skillnum).Dir = Buffer.ReadInteger()
        Skill(skillnum).Duration = Buffer.ReadInteger()
        Skill(skillnum).Icon = Buffer.ReadInteger()
        Skill(skillnum).Interval = Buffer.ReadInteger()
        Skill(skillnum).IsAoE = Buffer.ReadInteger()
        Skill(skillnum).LevelReq = Buffer.ReadInteger()
        Skill(skillnum).Map = Buffer.ReadInteger()
        Skill(skillnum).MPCost = Buffer.ReadInteger()
        Skill(skillnum).Name = Trim(Buffer.ReadString())
        Skill(skillnum).Range = Buffer.ReadInteger()
        Skill(skillnum).SkillAnim = Buffer.ReadInteger()
        Skill(skillnum).StunDuration = Buffer.ReadInteger()
        Skill(skillnum).Type = Buffer.ReadInteger()
        Skill(skillnum).Vital = Buffer.ReadInteger()
        Skill(skillnum).X = Buffer.ReadInteger()
        Skill(skillnum).Y = Buffer.ReadInteger()

        Skill(skillnum).IsProjectile = Buffer.ReadInteger()
        Skill(skillnum).Projectile = Buffer.ReadInteger()

        Skill(skillnum).KnockBack = Buffer.ReadInteger()
        Skill(skillnum).KnockBackTiles = Buffer.ReadInteger()

        If Skill(skillnum).Name Is Nothing Then Skill(skillnum).Name = ""

        Buffer = Nothing

    End Sub

    Private Sub Packet_ResourceEditor(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SResourceEditor Then Exit Sub

        InitResourceEditor = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_UpdateResource(ByVal Data() As Byte)
        Dim ResourceNum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateResource Then Exit Sub

        ResourceNum = Buffer.ReadInteger

        Resource(ResourceNum).Animation = Buffer.ReadInteger()
        Resource(ResourceNum).EmptyMessage = Trim(Buffer.ReadString())
        Resource(ResourceNum).ExhaustedImage = Buffer.ReadInteger()
        Resource(ResourceNum).Health = Buffer.ReadInteger()
        Resource(ResourceNum).ExpReward = Buffer.ReadInteger()
        Resource(ResourceNum).ItemReward = Buffer.ReadInteger()
        Resource(ResourceNum).Name = Trim(Buffer.ReadString())
        Resource(ResourceNum).ResourceImage = Buffer.ReadInteger()
        Resource(ResourceNum).ResourceType = Buffer.ReadInteger()
        Resource(ResourceNum).RespawnTime = Buffer.ReadInteger()
        Resource(ResourceNum).SuccessMessage = Trim(Buffer.ReadString())
        Resource(ResourceNum).LvlRequired = Buffer.ReadInteger()
        Resource(ResourceNum).ToolRequired = Buffer.ReadInteger()
        Resource(ResourceNum).Walkthrough = Buffer.ReadInteger()

        If Resource(ResourceNum).Name Is Nothing Then Resource(ResourceNum).Name = ""
        If Resource(ResourceNum).EmptyMessage Is Nothing Then Resource(ResourceNum).EmptyMessage = ""
        If Resource(ResourceNum).SuccessMessage Is Nothing Then Resource(ResourceNum).SuccessMessage = ""

        Buffer = Nothing
    End Sub

    Private Sub Packet_EditAnimation(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadInteger <> ServerPackets.SAnimationEditor Then Exit Sub

        InitAnimationEditor = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_UpdateAnimation(ByVal Data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateAnimation Then Exit Sub

        n = Buffer.ReadInteger
        ' Update the Animation
        For i = 0 To UBound(Animation(n).Frames)
            Animation(n).Frames(i) = Buffer.ReadInteger()
        Next

        For i = 0 To UBound(Animation(n).LoopCount)
            Animation(n).LoopCount(i) = Buffer.ReadInteger()
        Next

        For i = 0 To UBound(Animation(n).looptime)
            Animation(n).looptime(i) = Buffer.ReadInteger()
        Next

        Animation(n).Name = Trim(Buffer.ReadString())

        If Animation(n).Name Is Nothing Then Animation(n).Name = ""

        For i = 0 To UBound(Animation(n).Sprite)
            Animation(n).Sprite(i) = Buffer.ReadInteger()
        Next
        Buffer = Nothing
    End Sub

    Private Sub Packet_GameData(ByVal Data() As Byte)
        Dim n As Integer, i As Integer, z As Integer, x As Integer, a As Integer, b As Integer
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ServerPackets.SGameData Then Exit Sub

        Data = buffer.ReadBytes(buffer.Count - 4)
        Data = Decompress(Data)
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        '\\\Read Class Data\\\

        ' Max classes
        Max_Classes = buffer.ReadInteger
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Vital(0 To Vitals.Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Trim(buffer.ReadString)
                .Desc = Trim$(buffer.ReadString)

                .Vital(Vitals.HP) = buffer.ReadInteger
                .Vital(Vitals.MP) = buffer.ReadInteger
                .Vital(Vitals.SP) = buffer.ReadInteger

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

                .Stat(Stats.strength) = buffer.ReadInteger
                .Stat(Stats.endurance) = buffer.ReadInteger
                .Stat(Stats.vitality) = buffer.ReadInteger
                .Stat(Stats.intelligence) = buffer.ReadInteger
                .Stat(Stats.luck) = buffer.ReadInteger
                .Stat(Stats.spirit) = buffer.ReadInteger

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

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\End Read Class Data\\\

        '\\\Read Item Data\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            ' Update the item
            Item(n).AccessReq = buffer.ReadInteger()

            For z = 0 To Stats.Count - 1
                Item(n).Add_Stat(z) = buffer.ReadInteger()
            Next

            Item(n).Animation = buffer.ReadInteger()
            Item(n).BindType = buffer.ReadInteger()
            Item(n).ClassReq = buffer.ReadInteger()
            Item(n).Data1 = buffer.ReadInteger()
            Item(n).Data2 = buffer.ReadInteger()
            Item(n).Data3 = buffer.ReadInteger()
            Item(n).Handed = buffer.ReadInteger()
            Item(n).LevelReq = buffer.ReadInteger()
            Item(n).Mastery = buffer.ReadInteger()
            Item(n).Name = Trim$(buffer.ReadString())
            Item(n).Paperdoll = buffer.ReadInteger()
            Item(n).Pic = buffer.ReadInteger()
            Item(n).Price = buffer.ReadInteger()
            Item(n).Rarity = buffer.ReadInteger()
            Item(n).Speed = buffer.ReadInteger()

            Item(n).Randomize = buffer.ReadInteger()
            Item(n).RandomMin = buffer.ReadInteger()
            Item(n).RandomMax = buffer.ReadInteger()

            Item(n).Stackable = buffer.ReadInteger()
            Item(n).Description = Trim$(buffer.ReadString())

            For z = 0 To Stats.Count - 1
                Item(n).Stat_Req(z) = buffer.ReadInteger()
            Next

            Item(n).Type = buffer.ReadInteger()

            'Housing
            Item(n).FurnitureWidth = buffer.ReadInteger()
            Item(n).FurnitureHeight = buffer.ReadInteger()

            For a = 1 To 3
                For b = 1 To 3
                    Item(n).FurnitureBlocks(a, b) = buffer.ReadInteger()
                    Item(n).FurnitureFringe(a, b) = buffer.ReadInteger()
                Next
            Next

            Item(n).KnockBack = buffer.ReadInteger()
            Item(n).KnockBackTiles = buffer.ReadInteger()
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Item Data\\\\\\\

        '\\\Read Animation Data\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger
            ' Update the Animation
            For z = 0 To UBound(Animation(n).Frames)
                Animation(n).Frames(z) = buffer.ReadInteger()
            Next

            For z = 0 To UBound(Animation(n).LoopCount)
                Animation(n).LoopCount(z) = buffer.ReadInteger()
            Next

            For z = 0 To UBound(Animation(n).looptime)
                Animation(n).looptime(z) = buffer.ReadInteger()
            Next

            Animation(n).Name = Trim(buffer.ReadString())

            If Animation(n).Name Is Nothing Then Animation(n).Name = ""

            For z = 0 To UBound(Animation(n).Sprite)
                Animation(n).Sprite(z) = buffer.ReadInteger()
            Next
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Animation Data\\\\\\\

        '\\\Read NPC Data\\\\\\\
        x = buffer.ReadInteger
        For i = 1 To x
            n = buffer.ReadInteger
            ' Update the Npc
            Npc(n).Animation = buffer.ReadInteger()
            Npc(n).AttackSay = Trim(buffer.ReadString())
            Npc(n).Behaviour = buffer.ReadInteger()
            For z = 1 To 5
                Npc(n).DropChance(z) = buffer.ReadInteger()
                Npc(n).DropItem(z) = buffer.ReadInteger()
                Npc(n).DropItemValue(z) = buffer.ReadInteger()
            Next

            Npc(n).EXP = buffer.ReadInteger()
            Npc(n).Faction = buffer.ReadInteger()
            Npc(n).HP = buffer.ReadInteger()
            Npc(n).Name = Trim(buffer.ReadString())
            Npc(n).Range = buffer.ReadInteger()
            Npc(n).SpawnSecs = buffer.ReadInteger()
            Npc(n).Sprite = buffer.ReadInteger()

            For z = 0 To Stats.Count - 1
                Npc(n).Stat(z) = buffer.ReadInteger()
            Next

            Npc(n).QuestNum = buffer.ReadInteger()

            ReDim Npc(n).Skill(MAX_NPC_SKILLS)
            For z = 1 To MAX_NPC_SKILLS
                Npc(n).Skill(z) = buffer.ReadInteger()
            Next

            If Npc(n).AttackSay Is Nothing Then Npc(n).AttackSay = ""
            If Npc(n).Name Is Nothing Then Npc(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read NPC Data\\\\\\\

        '\\\Read Shop Data\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            Shop(n).BuyRate = buffer.ReadInteger()
            Shop(n).Name = Trim(buffer.ReadString())
            Shop(n).Face = buffer.ReadInteger()

            For z = 0 To MAX_TRADES
                Shop(n).TradeItem(z).CostItem = buffer.ReadInteger()
                Shop(n).TradeItem(z).CostValue = buffer.ReadInteger()
                Shop(n).TradeItem(z).Item = buffer.ReadInteger()
                Shop(n).TradeItem(z).ItemValue = buffer.ReadInteger()
            Next

            If Shop(n).Name Is Nothing Then Shop(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Shop Data\\\\\\\

        '\\\Read Skills Data\\\\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            Skill(n).AccessReq = buffer.ReadInteger()
            Skill(n).AoE = buffer.ReadInteger()
            Skill(n).CastAnim = buffer.ReadInteger()
            Skill(n).CastTime = buffer.ReadInteger()
            Skill(n).CDTime = buffer.ReadInteger()
            Skill(n).ClassReq = buffer.ReadInteger()
            Skill(n).Dir = buffer.ReadInteger()
            Skill(n).Duration = buffer.ReadInteger()
            Skill(n).Icon = buffer.ReadInteger()
            Skill(n).Interval = buffer.ReadInteger()
            Skill(n).IsAoE = buffer.ReadInteger()
            Skill(n).LevelReq = buffer.ReadInteger()
            Skill(n).Map = buffer.ReadInteger()
            Skill(n).MPCost = buffer.ReadInteger()
            Skill(n).Name = Trim(buffer.ReadString())
            Skill(n).Range = buffer.ReadInteger()
            Skill(n).SkillAnim = buffer.ReadInteger()
            Skill(n).StunDuration = buffer.ReadInteger()
            Skill(n).Type = buffer.ReadInteger()
            Skill(n).Vital = buffer.ReadInteger()
            Skill(n).X = buffer.ReadInteger()
            Skill(n).Y = buffer.ReadInteger()

            Skill(n).IsProjectile = buffer.ReadInteger()
            Skill(n).Projectile = buffer.ReadInteger()

            Skill(n).KnockBack = buffer.ReadInteger()
            Skill(n).KnockBackTiles = buffer.ReadInteger()

            If Skill(n).Name Is Nothing Then Skill(n).Name = ""
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\End Read Skills Data\\\\\\\\\\

        '\\\Read Resource Data\\\\\\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            Resource(n).Animation = buffer.ReadInteger()
            Resource(n).EmptyMessage = Trim(buffer.ReadString())
            Resource(n).ExhaustedImage = buffer.ReadInteger()
            Resource(n).Health = buffer.ReadInteger()
            Resource(n).ExpReward = buffer.ReadInteger()
            Resource(n).ItemReward = buffer.ReadInteger()
            Resource(n).Name = Trim(buffer.ReadString())
            Resource(n).ResourceImage = buffer.ReadInteger()
            Resource(n).ResourceType = buffer.ReadInteger()
            Resource(n).RespawnTime = buffer.ReadInteger()
            Resource(n).SuccessMessage = Trim(buffer.ReadString())
            Resource(n).LvlRequired = buffer.ReadInteger()
            Resource(n).ToolRequired = buffer.ReadInteger()
            Resource(n).Walkthrough = buffer.ReadInteger()

            If Resource(n).Name Is Nothing Then Resource(n).Name = ""
            If Resource(n).EmptyMessage Is Nothing Then Resource(n).EmptyMessage = ""
            If Resource(n).SuccessMessage Is Nothing Then Resource(n).SuccessMessage = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Resource Data\\\\\\\\\\\\

        buffer = Nothing
    End Sub

    Private Sub Packet_Mapreport(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, I As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapReport Then Exit Sub

        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(Buffer.ReadString())
        Next

        UpdateMapnames = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapNames(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, I As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNames Then Exit Sub

        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(Buffer.ReadString())
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_ClassEditor(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SClassEditor Then Exit Sub

        InitClassEditor = True

        Buffer = Nothing
    End Sub

End Module
