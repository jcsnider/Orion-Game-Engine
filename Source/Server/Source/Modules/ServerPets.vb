Module ServerPets
#Region "Declarations"

    Public Pet() As PetRec

    ' PET constants
    Public Const PET_BEHAVIOUR_FOLLOW As Byte = 0 'The pet will attack all npcs around
    Public Const PET_BEHAVIOUR_GOTO As Byte = 1 'If attacked, the pet will fight back
    Public Const PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT As Byte = 1 'The pet will attack all npcs around
    Public Const PET_ATTACK_BEHAVIOUR_GUARD As Byte = 2 'If attacked, the pet will fight back
    Public Const PET_ATTACK_BEHAVIOUR_DONOTHING As Byte = 3 'The pet will not attack even if attacked

    Public Structure PetRec

        Dim Num As Integer
        Dim Name As String
        Dim Sprite As Integer

        Dim Range As Integer

        Dim Level As Integer

        Dim MaxLevel As Integer
        Dim ExpGain As Integer
        Dim LevelPnts As Integer

        Dim StatType As Byte '1 for set stats, 2 for relation to owner's stats
        Dim LevelingType As Byte '0 for leveling on own, 1 for not leveling

        Dim stat() As Byte

        Dim Spell() As Integer

    End Structure

    Public Structure PlayerPetRec

        Dim Num As Integer
        Dim Health As Integer
        Dim Mana As Integer
        Dim Level As Integer
        Dim stat() As Byte
        Dim Spell() As Integer
        Dim x As Integer
        Dim y As Integer
        Dim Dir As Integer
        Dim Alive As Boolean
        Dim AttackBehaviour As Integer
        Dim AdoptiveStats As Boolean
        Dim Points As Integer
        Dim Exp As Integer

    End Structure
#End Region

#Region "Database"
    Sub SavePets()
        Dim i As Integer

        For i = 1 To MAX_PETS
            SavePet(i)
            DoEvents()
        Next

    End Sub

    Sub SavePet(ByVal PetNum As Integer)
        Dim filename As String, i As Integer

        filename = Application.StartupPath & "\data\pets\pet" & PetNum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Pet(PetNum).Num)
        writer.Write(Pet(PetNum).Name)
        writer.Write(Pet(PetNum).Sprite)
        writer.Write(Pet(PetNum).Range)
        writer.Write(Pet(PetNum).Level)
        writer.Write(Pet(PetNum).MaxLevel)
        writer.Write(Pet(PetNum).ExpGain)
        writer.Write(Pet(PetNum).LevelPnts)

        writer.Write(Pet(PetNum).StatType)
        writer.Write(Pet(PetNum).LevelingType)

        For i = 1 To Stats.Count - 1
            writer.Write(Pet(PetNum).stat(i))
        Next

        For i = 1 To 4
            writer.Write(Pet(PetNum).Spell(i))
        Next

        writer.Save(filename)

    End Sub

    Sub LoadPets()
        Dim i As Integer

        CheckPets()
        ClearPets()

        For i = 1 To MAX_PETS
            LoadPet(i)
            DoEvents()
        Next

    End Sub

    Sub LoadPet(ByVal PetNum As Integer)
        Dim filename As String, i As Integer

        filename = Application.StartupPath & "\data\pets\pet" & PetNum & ".dat"

        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Pet(PetNum).Num)
        reader.Read(Pet(PetNum).Name)
        reader.Read(Pet(PetNum).Sprite)
        reader.Read(Pet(PetNum).Range)
        reader.Read(Pet(PetNum).Level)
        reader.Read(Pet(PetNum).MaxLevel)
        reader.Read(Pet(PetNum).ExpGain)
        reader.Read(Pet(PetNum).LevelPnts)

        reader.Read(Pet(PetNum).StatType)
        reader.Read(Pet(PetNum).LevelingType)

        ReDim Pet(PetNum).stat(Stats.Count - 1)
        For i = 1 To Stats.Count - 1
            reader.Read(Pet(PetNum).stat(i))
        Next

        ReDim Pet(PetNum).Spell(4)
        For i = 1 To 4
            reader.Read(Pet(PetNum).Spell(i))
        Next

    End Sub

    Sub CheckPets()
        Dim i As Integer

        For i = 1 To MAX_PETS

            If Not FileExist(Application.StartupPath & "\Data\pets\pet" & i & ".dat") Then
                SavePet(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearPet(ByVal PetNum As Integer)

        Pet(PetNum).Name = vbNullString

        ReDim Pet(PetNum).stat(Stats.Count - 1)
        ReDim Pet(PetNum).Spell(4)
    End Sub

    Sub ClearPets()
        Dim i As Integer

        ReDim Pet(MAX_PETS)
        For i = 1 To MAX_PETS
            ClearPet(i)
        Next

    End Sub
#End Region

#Region "Outgoing Packets"
    Sub SendPets(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_PETS

            If Len(Trim$(Pet(i).Name)) > 0 Then
                SendUpdatePetTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdatePetToAll(ByVal PetNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdatePet)
        Buffer.WriteInteger(PetNum)

        With Pet(PetNum)
            Buffer.WriteInteger(.Num)
            Buffer.WriteString(.Name)
            Buffer.WriteInteger(.Sprite)
            Buffer.WriteInteger(.Range)
            Buffer.WriteInteger(.Level)
            Buffer.WriteInteger(.MaxLevel)
            Buffer.WriteInteger(.ExpGain)
            Buffer.WriteInteger(.LevelPnts)
            Buffer.WriteInteger(.StatType)
            Buffer.WriteInteger(.LevelingType)

            For i = 1 To Stats.Count - 1
                Buffer.WriteInteger(.stat(i))
            Next

            For i = 1 To 4
                Buffer.WriteInteger(.Spell(i))
            Next

        End With

        SendDataToAll(Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Sub SendUpdatePetTo(ByVal Index As Integer, ByVal petNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdatePet)
        Buffer.WriteInteger(petNum)

        With Pet(petNum)
            Buffer.WriteInteger(.Num)
            Buffer.WriteString(.Name)
            Buffer.WriteInteger(.Sprite)
            Buffer.WriteInteger(.Range)
            Buffer.WriteInteger(.Level)
            Buffer.WriteInteger(.MaxLevel)
            Buffer.WriteInteger(.ExpGain)
            Buffer.WriteInteger(.LevelPnts)
            Buffer.WriteInteger(.StatType)
            Buffer.WriteInteger(.LevelingType)

            For i = 1 To Stats.Count - 1
                Buffer.WriteInteger(.stat(i))
            Next

            For i = 1 To 4
                Buffer.WriteInteger(.Spell(i))
            Next

        End With

        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Public Sub SendUpdatePlayerPet(ByVal Index As Integer, ByVal OwnerOnly As Boolean)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdatePlayerPet)

        Buffer.WriteInteger(Index)

        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level)

        For i = 1 To Stats.Count - 1
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i))
        Next

        For i = 1 To 4
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Spell(i))
        Next

        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.y)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Dir)

        Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.HP))
        Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.MP))

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then
            Buffer.WriteInteger(1)
        Else
            Buffer.WriteInteger(0)
        End If

        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp)
        Buffer.WriteInteger(GetPetNextLevel(Index))

        If OwnerOnly Then
            SendDataTo(Index, Buffer.ToArray)
        Else
            SendDataToMap(GetPlayerMap(Index), Buffer.ToArray)
        End If

        Buffer = Nothing
    End Sub
#End Region

#Region "Incoming Packets"
    ' ::::::::::::::::::::::::::::::
    ' :: Request edit Pet  packet ::
    ' ::::::::::::::::::::::::::::::
    Sub Packet_RequestEditPet(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.CRequestEditPet Then Exit Sub

        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        Buffer = Nothing

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPetEditor)
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing

    End Sub

    ' :::::::::::::::::::::
    ' :: Save pet packet ::
    ' :::::::::::::::::::::
    Sub Packet_SavePet(ByVal Index As Integer, ByVal data() As Byte)
        Dim petNum As Integer
        Dim Buffer As ByteBuffer
        Dim i As Integer

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.CSavePet Then Exit Sub

        petNum = Buffer.ReadInteger

        ' Prevent hacking
        If petNum < 0 Or petNum > MAX_PETS Then Exit Sub

        With Pet(petNum)
            .Num = Buffer.ReadInteger
            .Name = Buffer.ReadString
            .Sprite = Buffer.ReadInteger
            .Range = Buffer.ReadInteger
            .Level = Buffer.ReadInteger
            .MaxLevel = Buffer.ReadInteger
            .ExpGain = Buffer.ReadInteger
            .LevelPnts = Buffer.ReadInteger
            .StatType = Buffer.ReadInteger
            .LevelingType = Buffer.ReadInteger

            For i = 1 To Stats.Count - 1
                .stat(i) = Buffer.ReadInteger
            Next

            For i = 1 To 4
                .Spell(i) = Buffer.ReadInteger
            Next

        End With

        ' Save it
        SendUpdatePetToAll(petNum)
        SavePet(petNum)
        Addlog(GetPlayerName(Index) & " saved Pet #" & petNum & ".", ADMIN_LOG)

    End Sub

    Sub Packet_RequestPets(ByVal Index As Integer, ByVal data() As Byte)

        SendPets(Index)

    End Sub

    Sub Packet_PetMove(ByVal Index As Integer, ByVal data() As Byte)
        Dim x As Integer, y As Integer, i As Integer
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPetMove Then Exit Sub

        x = Buffer.ReadInteger
        y = Buffer.ReadInteger

        ' Prevent subscript out of range
        If x < 0 Or x > Map(GetPlayerMap(Index)).MaxX Or y < 0 Or y > Map(GetPlayerMap(Index)).MaxY Then Exit Sub

        ' Check for a player
        For i = 1 To MAX_PLAYERS

            If IsPlaying(i) Then
                If GetPlayerMap(Index) = GetPlayerMap(i) Then
                    If GetPlayerX(i) = x Then
                        If GetPlayerY(i) = y Then
                            If i = Index Then

                                ' Change target
                                If TempPlayer(Index).PetTargetType = TargetType.Player And TempPlayer(Index).PetTarget = i Then
                                    TempPlayer(Index).PetTarget = 0
                                    TempPlayer(Index).PetTargetType = TargetType.None
                                    TempPlayer(Index).PetTargetZone = 0
                                    TempPlayer(Index).PetBehavior = PET_BEHAVIOUR_GOTO
                                    TempPlayer(Index).GoToX = x
                                    TempPlayer(Index).GoToY = y
                                    ' send target to player
                                    PlayerMsg(Index, "Your pet is no longer following you.", ColorType.BrightGreen)
                                Else
                                    TempPlayer(Index).PetTarget = i
                                    TempPlayer(Index).PetTargetType = TargetType.Player
                                    TempPlayer(Index).PetTargetZone = 0
                                    ' send target to player
                                    TempPlayer(Index).PetBehavior = PET_BEHAVIOUR_FOLLOW
                                    PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " is now following you.", ColorType.BrightGreen)
                                End If
                            Else
                                ' Change target
                                If TempPlayer(Index).PetTargetType = TargetType.Player And TempPlayer(Index).PetTarget = i Then
                                    TempPlayer(Index).PetTarget = 0
                                    TempPlayer(Index).PetTargetType = TargetType.None
                                    TempPlayer(Index).PetTargetZone = 0
                                    ' send target to player
                                    PlayerMsg(Index, "Your pet is no longer targetting " & Trim$(GetPlayerName(i)) & ".", ColorType.BrightGreen)
                                Else
                                    TempPlayer(Index).PetTarget = i
                                    TempPlayer(Index).PetTargetType = TargetType.Player
                                    TempPlayer(Index).PetTargetZone = 0
                                    ' send target to player
                                    PlayerMsg(Index, "Your pet is now targetting " & Trim$(GetPlayerName(i)) & ".", ColorType.BrightGreen)
                                End If
                            End If
                            Exit Sub
                        End If
                    End If

                    If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True And i <> Index Then
                        If Player(i).Character(TempPlayer(i).CurChar).Pet.x = x Then
                            If Player(i).Character(TempPlayer(i).CurChar).Pet.y = y Then

                                ' Change target
                                If TempPlayer(Index).PetTargetType = TargetType.Pet And TempPlayer(Index).PetTarget = i Then
                                    TempPlayer(Index).PetTarget = 0
                                    TempPlayer(Index).PetTargetType = TargetType.None
                                    TempPlayer(Index).PetTargetZone = 0
                                    ' send target to player
                                    PlayerMsg(Index, "Your pet is no longer targetting " & Trim$(GetPlayerName(i)) & "'s " & Trim$(Pet(Player(i).Character(TempPlayer(i).CurChar).Pet.Num).Name) & ".", ColorType.BrightGreen)
                                Else
                                    TempPlayer(Index).PetTarget = i
                                    TempPlayer(Index).PetTargetType = TargetType.Pet
                                    TempPlayer(Index).PetTargetZone = 0
                                    ' send target to player
                                    PlayerMsg(Index, "Your pet is now targetting " & Trim$(GetPlayerName(i)) & "'s " & Trim$(Pet(Player(i).Character(TempPlayer(i).CurChar).Pet.Num).Name) & ".", ColorType.BrightGreen)
                                End If
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        Next

        'Search For Target First
        ' Check for an npc
        For i = 1 To MAX_MAP_NPCS

            If MapNpc(GetPlayerMap(Index)).Npc(i).Num > 0 Then
                If MapNpc(GetPlayerMap(Index)).Npc(i).x = x Then
                    If MapNpc(GetPlayerMap(Index)).Npc(i).y = y Then
                        If TempPlayer(Index).PetTarget = i And TempPlayer(Index).PetTargetType = TargetType.Npc Then
                            ' Change target
                            TempPlayer(Index).PetTarget = 0
                            TempPlayer(Index).PetTargetType = TargetType.None
                            TempPlayer(Index).PetTargetZone = 0
                            ' send target to player
                            PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & "'s target is no longer a " & Trim$(Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Name) & "!", ColorType.BrightGreen)
                            Exit Sub
                        Else
                            ' Change target
                            TempPlayer(Index).PetTarget = i
                            TempPlayer(Index).PetTargetType = TargetType.Npc
                            TempPlayer(Index).PetTargetZone = 0
                            ' send target to player
                            PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & "'s target is now a " & Trim$(Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Name) & "!", ColorType.BrightGreen)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Next

        TempPlayer(Index).PetBehavior = PET_BEHAVIOUR_GOTO
        TempPlayer(Index).PetTargetType = 0
        TempPlayer(Index).PetTargetZone = 0
        TempPlayer(Index).PetTarget = 0
        TempPlayer(Index).GoToX = x
        TempPlayer(Index).GoToY = y

        If TempPlayer(Index).GoToX = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x And TempPlayer(Index).GoToY = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y Then

            Select Case Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour

                Case PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = PET_ATTACK_BEHAVIOUR_GUARD
                    SendActionMsg(GetPlayerMap(Index), "Defensive Mode!", ColorType.White, 0, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32, Index)

                Case PET_ATTACK_BEHAVIOUR_GUARD
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT
                    SendActionMsg(GetPlayerMap(Index), "Agressive Mode!", ColorType.White, 0, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32, Index)

                Case Else
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT
                    SendActionMsg(GetPlayerMap(Index), "Agressive Mode!", ColorType.White, 0, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32, Index)

            End Select

            TempPlayer(Index).GoToX = -1
            TempPlayer(Index).GoToY = -1
        Else
            PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " is moving to " & TempPlayer(Index).GoToX & "," & TempPlayer(Index).GoToY & ".", ColorType.BrightGreen)
        End If

        Buffer = Nothing

    End Sub

    Sub Packet_SetPetBehaviour(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CSetBehaviour Then Exit Sub

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = Buffer.ReadInteger

        Buffer = Nothing

    End Sub

    Sub Packet_ReleasePet(ByVal Index As Integer, ByVal data() As Byte)

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then ReleasePet(Index)

    End Sub

    Sub Packet_PetSpell(ByVal Index As Integer, ByVal data() As Byte)
        Dim n As Integer

        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPetSpell Then Exit Sub

        ' Spell slot
        n = Buffer.ReadInteger

        Buffer = Nothing

        ' set the spell buffer before castin
        'BufferPetSpell(Index, n)

    End Sub

    Sub Packet_UsePetStatPoint(ByVal Index As Integer, ByVal data() As Byte)
        Dim PointType As Byte

        Dim Buffer As ByteBuffer

        Dim sMes As String = ""

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPetUseStatPoint Then Exit Sub

        PointType = Buffer.ReadInteger
        Buffer = Nothing

        ' Prevent hacking
        If (PointType < 0) Or (PointType > Stats.Count) Then Exit Sub

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Sub

        ' Make sure they have points
        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points > 0 Then

            ' make sure they're not maxed#
            If Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) >= 255 Then
                PlayerMsg(Index, "You cannot spend any more points on that stat for your pet.", ColorType.BrightRed)
                Exit Sub
            End If

            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points - 1

            ' Everything is ok
            Select Case PointType

                Case Stats.Strength
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) + 1
                    sMes = "Strength"

                Case Stats.Endurance
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) + 1
                    sMes = "Endurance"

                Case Stats.Intelligence
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) + 1
                    sMes = "Intelligence"

                Case Stats.Luck
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) + 1
                    sMes = "Agility"

                Case Stats.Spirit
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(PointType) + 1
                    sMes = "Willpower"

            End Select

            SendActionMsg(GetPlayerMap(Index), "+1 " & sMes, ColorType.White, 1, (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32))

        Else
            Exit Sub

        End If

        ' Send the update
        SendUpdatePlayerPet(Index, True)

    End Sub

#End Region

#Region "Pet Functions"
    Sub ReleasePet(ByVal Index As Integer)
        Dim i As Integer

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Dir = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = 0

        TempPlayer(Index).PetTarget = 0
        TempPlayer(Index).PetTargetType = 0
        TempPlayer(Index).PetTargetZone = 0
        TempPlayer(Index).GoToX = -1
        TempPlayer(Index).GoToY = -1

        For i = 1 To 4
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Spell(i) = 0
        Next

        For i = 1 To Stats.Count - 1
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i) = 0
        Next

        SendUpdatePlayerPet(Index, False)

        For i = 1 To MAX_MAP_NPCS
            If MapNpc(GetPlayerMap(Index)).Npc(i).Vital(Vitals.HP) > 0 Then
                If MapNpc(GetPlayerMap(Index)).Npc(i).TargetType = TargetType.Pet Then
                    If MapNpc(GetPlayerMap(Index)).Npc(i).Target = Index Then
                        MapNpc(GetPlayerMap(Index)).Npc(i).TargetType = TargetType.Player
                        MapNpc(GetPlayerMap(Index)).Npc(i).Target = Index
                    End If
                End If
            End If
        Next

    End Sub

    Sub SummonPet(ByVal Index As Integer, ByVal PetNum As Integer)

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health > 0 Then
            If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num = 0 Then
                PlayerMsg(Index, "You have summoned a " & Trim$(Pet(PetNum).Name), ColorType.BrightGreen)
            Else
                Exit Sub
            End If
        End If

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num = PetNum

        For i = 1 To 4
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Spell(i) = Pet(PetNum).Spell(i)
        Next

        If Pet(PetNum).StatType = 0 Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = GetPlayerMaxVital(Index, Vitals.HP)
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = GetPlayerMaxVital(Index, Vitals.MP)
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = GetPlayerLevel(Index)

            For i = 1 To Stats.Count - 1
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i) = Player(Index).Character(TempPlayer(Index).CurChar).Stat(i)
            Next

            Player(Index).Character(TempPlayer(Index).CurChar).Pet.AdoptiveStats = True
        Else
            For i = 1 To Stats.Count - 1
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i) = Pet(PetNum).stat(i)
            Next

            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = Pet(PetNum).Level
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.AdoptiveStats = False
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = GetPetMaxVital(Index, Vitals.HP)
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = GetPetMaxVital(Index, Vitals.MP)
        End If

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = GetPlayerX(Index)
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = GetPlayerY(Index)

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp = 0

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = PET_ATTACK_BEHAVIOUR_GUARD 'By default it will guard but this can be changed

        SendUpdatePlayerPet(Index, False)

    End Sub

    Sub PetMove(ByVal Index As Integer, ByVal MapNum As Integer, ByVal Dir As Integer, ByVal movement As Integer)
        Dim Buffer As ByteBuffer

        If MapNum < 1 Or MapNum > MAX_MAPS Or Index <= 0 Or Index > MAX_PLAYERS Or Dir < Direction.Up Or Dir > Direction.Right Or movement < 1 Or movement > 2 Then
            Exit Sub
        End If

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Dir = Dir

        Select Case Dir

            Case Direction.Up
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y - 1

            Case Direction.Down
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y + 1

            Case Direction.Left
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x - 1

            Case Direction.Right
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x + 1

        End Select

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPetMove)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.y)
        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Dir)
        Buffer.WriteInteger(movement)
        SendDataToMap(MapNum, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Function CanPetMove(ByVal Index As Integer, ByVal MapNum As Integer, ByVal Dir As Byte) As Boolean
        Dim i As Integer, n As Integer
        Dim x As Integer, y As Integer

        If MapNum < 1 Or MapNum > MAX_MAPS Or Index <= 0 Or Index > MAX_PLAYERS Or Dir < Direction.Up Or Dir > Direction.Right Then
            Exit Function
        End If

        If Index <= 0 Or Index > MAX_PLAYERS Then Exit Function
        x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x
        y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y

        If x < 0 Or x > Map(MapNum).MaxX Then Exit Function
        If y < 0 Or y > Map(MapNum).MaxY Then Exit Function

        CanPetMove = True

        If TempPlayer(Index).PetspellBuffer.Spell > 0 Then
            CanPetMove = False
            Exit Function
        End If

        Select Case Dir

            Case Direction.Up
                ' Check to make sure not outside of boundries
                If y > 0 Then
                    n = Map(MapNum).Tile(x, y - 1).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TileType.None And n <> TileType.NpcSpawn Then
                        CanPetMove = False
                        Exit Function
                    End If

                    ' Check to make sure that there is not a player in the way
                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x + 1) And (GetPlayerY(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y - 1) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True And (GetPlayerMap(i) = MapNum) And (Player(i).Character(TempPlayer(i).CurChar).Pet.x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x) And (Player(i).Character(TempPlayer(i).CurChar).Pet.y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y - 1) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x) And (MapNpc(MapNum).Npc(i).y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y - 1) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y).DirBlock, Direction.Up + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

            Case Direction.Down

                ' Check to make sure not outside of boundries
                If y < Map(MapNum).MaxY Then
                    n = Map(MapNum).Tile(x, y + 1).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TileType.None And n <> TileType.NpcSpawn Then
                        CanPetMove = False
                        Exit Function
                    End If

                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x) And (GetPlayerY(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y + 1) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True And (GetPlayerMap(i) = MapNum) And (Player(i).Character(TempPlayer(i).CurChar).Pet.x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x) And (Player(i).Character(TempPlayer(i).CurChar).Pet.y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y + 1) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x) And (MapNpc(MapNum).Npc(i).y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y + 1) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y).DirBlock, Direction.Down + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

            Case Direction.Left

                ' Check to make sure not outside of boundries
                If x > 0 Then
                    n = Map(MapNum).Tile(x - 1, y).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TileType.None And n <> TileType.NpcSpawn Then
                        CanPetMove = False
                        Exit Function
                    End If

                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x - 1) And (GetPlayerY(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True And (GetPlayerMap(i) = MapNum) And (Player(i).Character(TempPlayer(i).CurChar).Pet.x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x - 1) And (Player(i).Character(TempPlayer(i).CurChar).Pet.y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x - 1) And (MapNpc(MapNum).Npc(i).y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y).DirBlock, Direction.Left + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

            Case Direction.Right

                ' Check to make sure not outside of boundries
                If x < Map(MapNum).MaxX Then
                    n = Map(MapNum).Tile(x + 1, y).Type

                    ' Check to make sure that the tile is walkable
                    If n <> TileType.None And n <> TileType.NpcSpawn Then
                        CanPetMove = False
                        Exit Function
                    End If

                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x + 1) And (GetPlayerY(i) = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True And (GetPlayerMap(i) = MapNum) And (Player(i).Character(TempPlayer(i).CurChar).Pet.x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x + 1) And (Player(i).Character(TempPlayer(i).CurChar).Pet.y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x + 1) And (MapNpc(MapNum).Npc(i).y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If isDirBlocked(Map(MapNum).Tile(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y).DirBlock, Direction.Right + 1) Then
                        CanPetMove = False
                        Exit Function
                    End If
                Else
                    CanPetMove = False
                End If

        End Select

    End Function

    Sub PetDir(ByVal Index As Integer, ByVal Dir As Integer)
        Dim Buffer As ByteBuffer

        If Index <= 0 Or Index > MAX_PLAYERS Or Dir < Direction.Up Or Dir > Direction.Right Then Exit Sub

        If TempPlayer(Index).PetspellBuffer.Spell > 0 Then Exit Sub

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Dir = Dir

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPetDir)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(Dir)
        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Function PetTryWalk(ByVal Index As Integer, ByVal TargetX As Integer, ByVal TargetY As Integer) As Boolean
        Dim i As Integer, x As Integer, didwalk As Boolean
        Dim MapNum As Integer

        MapNum = GetPlayerMap(Index)
        x = Index

        If IsOneBlockAway(TargetX, TargetY, CLng(Player(Index).Character(TempPlayer(Index).CurChar).Pet.x), CLng(Player(Index).Character(TempPlayer(Index).CurChar).Pet.y)) = False Then

            If PathfindingType = 1 Then
                i = Int(Rnd() * 5)

                ' Lets move the pet
                Select Case i
                    Case 0
                        ' Up
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y > TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Up) Then
                                PetMove(x, MapNum, Direction.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Down
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y < TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Down) Then
                                PetMove(x, MapNum, Direction.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Left
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x > TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Left) Then
                                PetMove(x, MapNum, Direction.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Right
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x < TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Right) Then
                                PetMove(x, MapNum, Direction.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If
                    Case 1

                        ' Right
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x < TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Right) Then
                                PetMove(x, MapNum, Direction.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Left
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x > TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Left) Then
                                PetMove(x, MapNum, Direction.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Down
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y < TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Down) Then
                                PetMove(x, MapNum, Direction.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Up
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y > TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Up) Then
                                PetMove(x, MapNum, Direction.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                    Case 2

                        ' Down
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y < TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Down) Then
                                PetMove(x, MapNum, Direction.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Up
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y > TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Up) Then
                                PetMove(x, MapNum, Direction.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Right
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x < TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Right) Then
                                PetMove(x, MapNum, Direction.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Left
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x > TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Left) Then
                                PetMove(x, MapNum, Direction.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                    Case 3

                        ' Left
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x > TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Left) Then
                                Call PetMove(x, MapNum, Direction.Left, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Right
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.x < TargetX And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Right) Then
                                PetMove(x, MapNum, Direction.Right, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Up
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y > TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Up) Then
                                PetMove(x, MapNum, Direction.Up, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                        ' Down
                        If Player(x).Character(TempPlayer(x).CurChar).Pet.y < TargetY And Not didwalk Then
                            If CanPetMove(x, MapNum, Direction.Down) Then
                                PetMove(x, MapNum, Direction.Down, MovementType.Walking)
                                didwalk = True
                            End If
                        End If

                End Select

                ' Check if we can't move and if Target is behind something and if we can just switch dirs
                If Not didwalk Then
                    If Player(x).Character(TempPlayer(x).CurChar).Pet.x - 1 = TargetX And Player(x).Character(TempPlayer(x).CurChar).Pet.y = TargetY Then

                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Dir <> Direction.Left Then
                            PetDir(x, Direction.Left)
                        End If

                        didwalk = True
                    End If

                    If Player(x).Character(TempPlayer(x).CurChar).Pet.x + 1 = TargetX And Player(x).Character(TempPlayer(x).CurChar).Pet.y = TargetY Then

                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Dir <> Direction.Right Then
                            PetDir(x, Direction.Right)
                        End If

                        didwalk = True
                    End If

                    If Player(x).Character(TempPlayer(x).CurChar).Pet.x = TargetX And Player(x).Character(TempPlayer(x).CurChar).Pet.y - 1 = TargetY Then

                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Dir <> Direction.Up Then
                            PetDir(x, Direction.Up)
                        End If

                        didwalk = True
                    End If

                    If Player(x).Character(TempPlayer(x).CurChar).Pet.x = TargetX And Player(x).Character(TempPlayer(x).CurChar).Pet.y + 1 = TargetY Then

                        If Player(x).Character(TempPlayer(x).CurChar).Pet.Dir <> Direction.Down Then
                            PetDir(x, Direction.Down)
                        End If

                        didwalk = True
                    End If
                End If
            Else
                'Pathfind
                i = FindPetPath(MapNum, x, TargetX, TargetY)

                If i < 4 Then 'Returned an answer. Move the pet
                    If CanPetMove(x, MapNum, i) Then
                        PetMove(x, MapNum, i, MovementType.Walking)
                        didwalk = True
                    End If
                End If
            End If
        Else

            'Look to target
            If Player(Index).Character(TempPlayer(Index).CurChar).Pet.x > TempPlayer(Index).GoToX Then
                If CanPetMove(x, MapNum, Direction.Left) Then
                    PetMove(x, MapNum, Direction.Left, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Left)
                    didwalk = True
                End If

            ElseIf Player(Index).Character(TempPlayer(Index).CurChar).Pet.x < TempPlayer(Index).GoToX Then

                If CanPetMove(x, MapNum, Direction.Right) Then
                    PetMove(x, MapNum, Direction.Right, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Right)
                    didwalk = True
                End If

            ElseIf Player(Index).Character(TempPlayer(Index).CurChar).Pet.y > TempPlayer(Index).GoToY Then

                If CanPetMove(x, MapNum, Direction.Up) Then
                    PetMove(x, MapNum, Direction.Up, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Up)
                    didwalk = True
                End If

            ElseIf Player(Index).Character(TempPlayer(Index).CurChar).Pet.y < TempPlayer(Index).GoToY Then

                If CanPetMove(x, MapNum, Direction.Down) Then
                    PetMove(x, MapNum, Direction.Down, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Down)
                    didwalk = True
                End If
            End If
        End If

        ' We could not move so Target must be behind something, walk randomly.
        If Not didwalk Then
            i = Int(Rnd() * 2)

            If i = 1 Then
                i = Int(Rnd() * 4)

                If CanPetMove(x, MapNum, i) Then
                    PetMove(x, MapNum, i, MovementType.Walking)
                End If
            End If
        End If

        PetTryWalk = didwalk

    End Function

    Function FindPetPath(ByVal MapNum As Integer, ByVal Index As Integer, ByVal TargetX As Integer, TargetY As Integer) As Integer

        Dim tim As Integer, sX As Integer, sY As Integer, pos(,) As Integer, reachable As Boolean, j As Integer, LastSum As Integer, Sum As Integer, FX As Integer, FY As Integer, i As Integer

        Dim path() As Point, LastX As Integer, LastY As Integer, did As Boolean

        'Initialization phase

        tim = 0
        sX = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x
        sY = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y

        FX = TargetX
        FY = TargetY

        If FX = -1 Then Exit Function
        If FY = -1 Then Exit Function

        ReDim pos(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)
        'pos = MapBlocks(MapNum).Blocks

        pos(sX, sY) = 100 + tim
        pos(FX, FY) = 2

        'reset reachable
        reachable = False

        'Do while reachable is false... if its set true in progress, we jump out
        'If the path is decided unreachable in process, we will use exit sub. Not proper,
        'but faster ;-)
        Do While reachable = False

            'we loop through all squares
            For j = 0 To Map(MapNum).MaxY
                For i = 0 To Map(MapNum).MaxX

                    'If j = 10 And i = 0 Then MsgBox "hi!"
                    'If they are to be extended, the pointer TIM is on them
                    If pos(i, j) = 100 + tim Then

                        'The part is to be extended, so do it
                        'We have to make sure that there is a pos(i+1,j) BEFORE we actually use it,
                        'because then we get error... If the square is on side, we dont test for this one!
                        If i < Map(MapNum).MaxX Then

                            'If there isnt a wall, or any other... thing
                            If pos(i + 1, j) = 0 Then
                                'Expand it, and make its pos equal to tim+1, so the next time we make this loop,
                                'It will exapand that square too! This is crucial part of the program
                                pos(i + 1, j) = 100 + tim + 1
                            ElseIf pos(i + 1, j) = 2 Then
                                'If the position is no 0 but its 2 (FINISH) then Reachable = true!!! We found end
                                reachable = True

                            End If

                        End If

                        'This is the same as the last one, as i said a lot of copy paste work and editing that
                        'This is simply another side that we have to test for... so instead of i+1 we have i-1
                        'Its actually pretty same then... I wont comment it therefore, because its only repeating
                        'same thing with minor changes to check sides
                        If i > 0 Then
                            If pos((i - 1), j) = 0 Then
                                pos(i - 1, j) = 100 + tim + 1
                            ElseIf pos(i - 1, j) = 2 Then
                                reachable = True

                            End If

                        End If

                        If j < Map(MapNum).MaxY Then
                            If pos(i, j + 1) = 0 Then
                                pos(i, j + 1) = 100 + tim + 1
                            ElseIf pos(i, j + 1) = 2 Then
                                reachable = True

                            End If

                        End If

                        If j > 0 Then
                            If pos(i, j - 1) = 0 Then
                                pos(i, j - 1) = 100 + tim + 1
                            ElseIf pos(i, j - 1) = 2 Then
                                reachable = True

                            End If

                        End If

                    End If

                    DoEvents()
                Next i
            Next j

            'If the reachable is STILL false, then
            If reachable = False Then
                'reset sum
                Sum = 0

                For j = 0 To Map(MapNum).MaxY
                    For i = 0 To Map(MapNum).MaxX
                        'we add up ALL the squares
                        Sum = Sum + pos(i, j)
                    Next i
                Next j

                'Now if the sum is euqal to the last sum, its not reachable, if it isnt, then we store
                'sum to lastsum
                If Sum = LastSum Then
                    FindPetPath = 4
                    Exit Function
                Else
                    LastSum = Sum

                End If

            End If

            'we increase the pointer to point to the next squares to be expanded
            tim = tim + 1
        Loop

        'We work backwards to find the way...
        LastX = FX
        LastY = FY

        ReDim path(tim + 1)

        'The following code may be a little bit confusing but ill try my best to explain it.
        'We are working backwards to find ONE of the shortest ways back to Start.
        'So we repeat the loop until the LastX and LastY arent in start. Look in the code to see
        'how LastX and LasY change
        Do While LastX <> sX Or LastY <> sY
            'We decrease tim by one, and then we are finding any adjacent square to the final one, that
            'has that value. So lets say the tim would be 5, because it takes 5 steps to get to the target.
            'Now everytime we decrease that, so we make it 4, and we look for any adjacent square that has
            'that value. When we find it, we just color it yellow as for the solution
            tim = tim - 1
            'reset did to false
            did = False

            'If we arent on edge
            If LastX < Map(MapNum).MaxX Then

                'check the square on the right of the solution. Is it a tim-1 one? or just a blank one
                If pos(LastX + 1, LastY) = 100 + tim Then
                    'if it, then make it yellow, and change did to true
                    LastX = LastX + 1
                    did = True

                End If

            End If

            'This will then only work if the previous part didnt execute, and did is still false. THen
            'we want to check another square, the on left. Is it a tim-1 one ?
            If did = False Then
                If LastX > 0 Then
                    If pos(LastX - 1, LastY) = 100 + tim Then
                        LastX = LastX - 1
                        did = True

                    End If

                End If

            End If

            'We check the one below it
            If did = False Then
                If LastY < Map(MapNum).MaxY Then
                    If pos(LastX, LastY + 1) = 100 + tim Then
                        LastY = LastY + 1
                        did = True

                    End If

                End If

            End If

            'And above it. One of these have to be it, since we have found the solution, we know that already
            'there is a way back.
            If did = False Then
                If LastY > 0 Then
                    If pos(LastX, LastY - 1) = 100 + tim Then
                        LastY = LastY - 1

                    End If

                End If

            End If

            path(tim).X = LastX
            path(tim).Y = LastY

            'Now we loop back and decrease tim, and look for the next square with lower value
            DoEvents()
        Loop

        'Ok we got a path. Now, lets look at the first step and see what direction we should take.
        If path(1).X > LastX Then
            FindPetPath = Direction.Right
        ElseIf path(1).Y > LastY Then
            FindPetPath = Direction.Down
        ElseIf path(1).Y < LastY Then
            FindPetPath = Direction.Up
        ElseIf path(1).X < LastX Then
            FindPetPath = Direction.Left
        End If

    End Function

#End Region

    Public Sub TryPetAttackNpc(ByVal Index As Integer, ByVal MapNpcNum As Integer)
        Dim blockAmount As Integer
        Dim npcnum As Integer
        Dim MapNum As Integer
        Dim Damage As Integer

        Damage = 0

        ' Can we attack the npc?
        If CanPetAttackNpc(Index, MapNpcNum) Then

            MapNum = GetPlayerMap(Index)
            npcnum = MapNpc(MapNum).Npc(MapNpcNum).Num

            ' check if NPC can avoid the attack
            If CanNpcDodge(npcnum) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
                Exit Sub
            End If

            If CanNpcParry(npcnum) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPetDamage(Index)

            ' if the npc blocks, take away the block amount
            blockAmount = CanNpcBlock(MapNpcNum)
            Damage = Damage - blockAmount

            ' take away armour
            Damage = Damage - Random(1, (Npc(npcnum).Stat(Stats.Luck) * 2))
            ' randomise from 1 to max hit
            Damage = Random(1, Damage)

            ' * 1.5 if it's a crit!
            If CanPetCrit(Index) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (GetPlayerX(Index) * 32), (GetPlayerY(Index) * 32))
            End If

            If Damage > 0 Then
                PetAttackNpc(Index, MapNpcNum, Damage)
            Else
                PlayerMsg(Index, "Your pet's attack does nothing.", ColorType.BrightRed)
            End If

        End If

    End Sub

    Public Function CanPetCrit(ByVal Index As Integer) As Boolean
        Dim rate As Integer
        Dim rndNum As Integer

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Function

        CanPetCrit = False

        rate = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Luck) / 3
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanPetCrit = True

    End Function

    Function GetPetDamage(ByVal Index As Integer) As Integer
        GetPetDamage = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Or Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then
            Exit Function
        End If

        GetPetDamage = (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Strength) * 2) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 3) + Random(0, 20)

    End Function

    Public Function CanPetAttackNpc(ByVal Attacker As Integer, ByVal mapnpcnum As Integer, Optional ByVal IsSpell As Boolean = False) As Boolean
        Dim MapNum As Integer
        Dim npcnum As Integer
        Dim NpcX As Integer
        Dim NpcY As Integer
        Dim attackspeed As Integer

        If IsPlaying(Attacker) = False Or mapnpcnum <= 0 Or mapnpcnum > MAX_MAP_NPCS Or Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Alive = False Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Attacker)).Npc(mapnpcnum).Num <= 0 Then Exit Function

        MapNum = GetPlayerMap(Attacker)
        npcnum = MapNpc(MapNum).Npc(mapnpcnum).Num

        ' Make sure the npc isn't already dead
        If MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) <= 0 Then Exit Function

        ' Make sure they are on the same map
        If IsPlaying(Attacker) Then

            If TempPlayer(Attacker).PetspellBuffer.Spell > 0 And IsSpell = False Then Exit Function

            ' exit out early
            If IsSpell Then
                If npcnum > 0 Then
                    If Npc(npcnum).Behaviour <> NpcBehavior.Friendly And Npc(npcnum).Behaviour <> NpcBehavior.ShopKeeper Then
                        CanPetAttackNpc = True
                        Exit Function
                    End If
                End If
            End If

            attackspeed = 1000 'Pet cannot wield a weapon

            If npcnum > 0 And GetTickCount() > TempPlayer(Attacker).PetAttackTimer + attackspeed Then

                ' Check if at same coordinates
                Select Case Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Dir

                    Case Direction.Up
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).x
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).y + 1

                    Case Direction.Down
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).x
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).y - 1

                    Case Direction.Left
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).x + 1
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).y

                    Case Direction.Right
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).x - 1
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).y

                End Select

                If NpcX = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x Then
                    If NpcY = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y Then
                        If Npc(npcnum).Behaviour <> NpcBehavior.Friendly And Npc(npcnum).Behaviour <> NpcBehavior.ShopKeeper Then
                            CanPetAttackNpc = True
                        Else
                            CanPetAttackNpc = False
                        End If
                    End If
                End If
            End If
        End If

    End Function

    Public Sub PetAttackNpc(ByVal Attacker As Integer, ByVal mapnpcnum As Integer, ByVal Damage As Integer, Optional ByVal Skillnum As Integer = 0, Optional ByVal overTime As Boolean = False)
        Dim Name As String, Exp As Integer
        Dim n As Integer, i As Integer
        Dim MapNum As Integer, npcnum As Integer

        Dim Buffer As ByteBuffer

        ' Check for subscript out of range

        If IsPlaying(Attacker) = False Or mapnpcnum <= 0 Or mapnpcnum > MAX_MAP_NPCS Or Damage < 0 Or Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Alive = False Then
            Exit Sub
        End If

        MapNum = GetPlayerMap(Attacker)
        npcnum = MapNpc(MapNum).Npc(mapnpcnum).Num
        Name = Trim$(Npc(npcnum).Name)

        If Skillnum = 0 Then
            ' Send this packet so they can see the pet attacking
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SAttack)
            Buffer.WriteInteger(Attacker)
            Buffer.WriteInteger(1)
            SendDataToMap(MapNum, Buffer.ToArray)
            Buffer = Nothing
        End If

        ' Check for weapon
        n = 0 'no weapon, pet :P

        ' set the regen timer
        TempPlayer(Attacker).PetstopRegen = True
        TempPlayer(Attacker).PetstopRegenTimer = GetTickCount()

        If Damage >= MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) Then

            SendActionMsg(GetPlayerMap(Attacker), "-" & MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP), ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(mapnpcnum).x * 32), (MapNpc(MapNum).Npc(mapnpcnum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y)

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Attacker, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y, SoundEntity.seSpell, Spellnum

            ' Calculate exp to give attacker
            Exp = Npc(npcnum).Exp

            ' Make sure we dont get less then 0
            If Exp < 0 Then
                Exp = 1
            End If

            ' in party?
            If TempPlayer(Attacker).InParty > 0 Then
                ' pass through party sharing function
                Party_ShareExp(TempPlayer(Attacker).InParty, Exp, Attacker, MapNum)
            Else
                ' no party - keep exp for self
                GivePlayerEXP(Attacker, Exp)
            End If

            For n = 1 To 20
                If MapNpc(MapNum).Npc(mapnpcnum).Num > 0 Then
                    'SpawnItem(MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num, MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value, MapNum, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y)
                    'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value = 0
                    'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num = 0
                End If

            Next

            ' Now set HP to 0 so we know to actually kill them in the server loop (this prevents subscript out of range)
            MapNpc(MapNum).Npc(mapnpcnum).Num = 0
            MapNpc(MapNum).Npc(mapnpcnum).SpawnWait = GetTickCount()
            MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) = 0
            MapNpc(MapNum).Npc(mapnpcnum).TargetType = 0
            MapNpc(MapNum).Npc(mapnpcnum).Target = 0

            '' clear DoTs and HoTs
            'For i = 1 To MAX_DOTS

            '    With MapNpc(MapNum).Npc(mapnpcnum).DoT(i)
            '        .Spell = 0
            '        .Timer = 0
            '        .Caster = 0
            '        .StartTime = 0
            '        .Used = False

            '    End With

            '    With MapNpc(MapNum).Npc(mapnpcnum).HoT(i)
            '        .Spell = 0
            '        .Timer = 0
            '        .Caster = 0
            '        .StartTime = 0
            '        .Used = False

            '    End With

            'Next

            ' send death to the map
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SNpcDead)
            Buffer.WriteInteger(0)
            Buffer.WriteInteger(mapnpcnum)
            SendDataToMap(MapNum, Buffer.ToArray)
            Buffer = Nothing

            'Loop through entire map and purge NPC from targets
            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) And IsConnected(i) Then
                    If GetPlayerMap(i) = MapNum Then
                        If TempPlayer(i).TargetType = TargetType.Npc Then
                            If TempPlayer(i).Target = mapnpcnum Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If

                        If TempPlayer(i).PetTargetType = TargetType.Npc Then
                            If TempPlayer(i).PetTarget = mapnpcnum Then
                                TempPlayer(i).PetTarget = 0
                                TempPlayer(i).PetTargetType = TargetType.None
                            End If
                        End If
                    End If
                End If
            Next
        Else
            ' NPC not dead, just do the damage
            MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) = MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) - Damage

            ' Check for a weapon and say damage
            SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(mapnpcnum).x * 32), (MapNpc(MapNum).Npc(mapnpcnum).y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y)

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Attacker, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y, SoundEntity.seSpell, Spellnum

            ' Set the NPC target to the player
            MapNpc(MapNum).Npc(mapnpcnum).TargetType = TargetType.Pet ' player's pet
            MapNpc(MapNum).Npc(mapnpcnum).Target = Attacker

            ' Now check for guard ai and if so have all onmap guards come after'm
            If Npc(MapNpc(MapNum).Npc(mapnpcnum).Num).Behaviour = NpcBehavior.Guard Then

                For i = 1 To MAX_MAP_NPCS

                    If MapNpc(MapNum).Npc(i).Num = MapNpc(MapNum).Npc(mapnpcnum).Num Then
                        MapNpc(MapNum).Npc(i).Target = Attacker
                        MapNpc(MapNum).Npc(i).TargetType = TargetType.Pet ' pet
                    End If
                Next
            End If

            ' set the regen timer
            MapNpc(MapNum).Npc(mapnpcnum).stopRegen = True
            MapNpc(MapNum).Npc(mapnpcnum).stopRegenTimer = GetTickCount()

            ' if stunning spell, stun the npc
            If Skillnum > 0 Then
                If Skill(Skillnum).StunDuration > 0 Then StunNPC(mapnpcnum, MapNum, Skillnum)
                ' DoT
                If Skill(Skillnum).Duration > 0 Then
                    'AddDoT_Npc MapNum, mapnpcnum, Spellnum, Attacker, 3
                End If
            End If

            SendMapNpcVitals(MapNum, mapnpcnum)
        End If

        If Skillnum = 0 Then
            ' Reset attack timer
            TempPlayer(Attacker).PetAttackTimer = GetTickCount()
        End If

    End Sub

    ' ###################################
    ' ##      NPC Attacking Pet        ##
    ' ###################################

    Public Sub TryNpcAttackPet(ByVal MapNpcNum As Integer, ByVal Index As Integer)

        Dim MapNum As Integer, npcnum As Integer, Damage As Integer

        ' Can the npc attack the pet?

        If CanNpcAttackPet(MapNpcNum, Index) Then
            MapNum = GetPlayerMap(Index)
            npcnum = MapNpc(MapNum).Npc(MapNpcNum).Num

            ' check if Pet can avoid the attack
            If CanPetDodge(Index) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetNpcDamage(npcnum)

            ' take away armour
            Damage = Damage - ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Spirit) * 2) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 3))

            ' * 1.5 if crit hit
            If CanNpcCrit(npcnum) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (MapNpc(MapNum).Npc(MapNpcNum).x * 32), (MapNpc(MapNum).Npc(MapNpcNum).y * 32))
            End If
        End If

        If Damage > 0 Then
            NpcAttackPet(MapNpcNum, Index, Damage)
        End If

    End Sub

    Function CanNpcAttackPet(ByVal MapNpcNum As Integer, ByVal Index As Integer) As Boolean
        Dim MapNum As Integer
        Dim npcnum As Integer

        CanNpcAttackPet = False

        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Not IsPlaying(Index) Or Not Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Index)).Npc(MapNpcNum).Num <= 0 Then Exit Function

        MapNum = GetPlayerMap(Index)
        npcnum = MapNpc(MapNum).Npc(MapNpcNum).Num

        ' Make sure the npc isn't already dead
        If MapNpc(MapNum).Npc(MapNpcNum).Vital(Vitals.HP) <= 0 Then Exit Function

        ' Make sure npcs dont attack more then once a second
        If GetTickCount() < MapNpc(MapNum).Npc(MapNpcNum).AttackTimer + 1000 Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Index).GettingMap = 1 Then Exit Function

        MapNpc(MapNum).Npc(MapNpcNum).AttackTimer = GetTickCount()

        ' Make sure they are on the same map
        If IsPlaying(Index) And Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then
            If npcnum > 0 Then

                ' Check if at same coordinates
                If (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y + 1 = MapNpc(MapNum).Npc(MapNpcNum).y) And (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                    CanNpcAttackPet = True
                Else

                    If (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y - 1 = MapNpc(MapNum).Npc(MapNpcNum).y) And (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                        CanNpcAttackPet = True
                    Else

                        If (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = MapNpc(MapNum).Npc(MapNpcNum).y) And (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x + 1 = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                            CanNpcAttackPet = True
                        Else

                            If (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = MapNpc(MapNum).Npc(MapNpcNum).y) And (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x - 1 = MapNpc(MapNum).Npc(MapNpcNum).x) Then
                                CanNpcAttackPet = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function

    Sub NpcAttackPet(ByVal mapnpcnum As Integer, ByVal Victim As Integer, ByVal Damage As Integer)
        Dim Name As String, MapNum As Integer

        Dim Buffer As ByteBuffer

        ' Check for subscript out of range

        If mapnpcnum <= 0 Or mapnpcnum > MAX_MAP_NPCS Or IsPlaying(Victim) = False Or Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Alive = False Then
            Exit Sub
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Victim)).Npc(mapnpcnum).Num <= 0 Then Exit Sub

        MapNum = GetPlayerMap(Victim)
        Name = Trim$(Npc(MapNpc(MapNum).Npc(mapnpcnum).Num).Name)

        ' Send this packet so they can see the npc attacking
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SNpcAttack)
        Buffer.WriteInteger(mapnpcnum)
        SendDataToMap(MapNum, Buffer.ToArray)
        Buffer = Nothing

        If Damage <= 0 Then Exit Sub

        ' set the regen timer
        MapNpc(MapNum).Npc(mapnpcnum).stopRegen = True
        MapNpc(MapNum).Npc(mapnpcnum).stopRegenTimer = GetTickCount()

        If Damage >= Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health Then
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health, ColorType.BrightRed, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))

            ' send the sound
            'SendMapSound(Victim, Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seNpc, MapNpc(MapNum).Npc(mapnpcnum).Num)

            ' kill pet
            PlayerMsg(Victim, "Your " & Trim$(Pet(Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Num).Name) & " was killed by a " & Trim$(Npc(MapNpc(MapNum).Npc(mapnpcnum).Num).Name) & ".", ColorType.BrightRed)
            ReleasePet(Victim)

            ' Now that pet is dead, go for owner
            MapNpc(MapNum).Npc(mapnpcnum).Target = Victim
            MapNpc(MapNum).Npc(mapnpcnum).TargetType = TargetType.Player
        Else
            ' Player not dead, just do the damage
            Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health = Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health - Damage
            SendPetVital(Victim, Vitals.HP)
            SendAnimation(MapNum, Npc(MapNpc(GetPlayerMap(Victim)).Npc(mapnpcnum).Num).Animation, 0, 0, TargetType.Pet, Victim)

            ' send the sound
            'SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seNpc, MapNpc(MapNum).Npc(mapnpcnum).Num

            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))
            SendBlood(GetPlayerMap(Victim), Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y)

            ' set the regen timer
            TempPlayer(Victim).stopRegen = True
            TempPlayer(Victim).stopRegenTimer = GetTickCount()
        End If

    End Sub

    Function CanPetAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, Optional ByVal IsSkill As Boolean = False) As Boolean

        If Not IsSkill Then
            If GetTickCount() < TempPlayer(Attacker).PetAttackTimer + 1000 Then Exit Function
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = 1 Then Exit Function

        If TempPlayer(Attacker).PetspellBuffer.Spell > 0 And IsSkill = False Then Exit Function

        If Not IsSkill Then
            ' Check if at same coordinates
            Select Case Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Dir
                Case Direction.Up
                    If Not ((GetPlayerY(Victim) + 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (GetPlayerX(Victim) = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Direction.Down
                    If Not ((GetPlayerY(Victim) - 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (GetPlayerX(Victim) = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Direction.Left
                    If Not ((GetPlayerY(Victim) = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (GetPlayerX(Victim) + 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Direction.Right
                    If Not ((GetPlayerY(Victim) = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (GetPlayerX(Victim) - 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Else
                    Exit Function
            End Select
        End If

        ' Check if map is attackable
        If Not Map(GetPlayerMap(Attacker)).Moral = MapMoral.None Then
            If GetPlayerPK(Victim) = 0 Then
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If GetPlayerVital(Victim, Vitals.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Monitor Then
            Call PlayerMsg(Attacker, "Admins cannot attack other players.", ColorType.Yellow)
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "!", ColorType.Yellow)
            Exit Function
        End If

        ' Don't attack a party member
        If TempPlayer(Attacker).InParty > 0 And TempPlayer(Victim).InParty > 0 Then
            If TempPlayer(Attacker).InParty = TempPlayer(Victim).InParty Then
                PlayerMsg(Attacker, "You can't attack another party member!", ColorType.Yellow)
                Exit Function
            End If
        End If

        CanPetAttackPlayer = True

    End Function

    'Pet Vital Stuffs
    Sub SendPetVital(ByVal Index As Integer, ByVal Vital As Vitals)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SPetVital)

        Buffer.WriteInteger(Index)

        If Vital = Vitals.HP Then
            Buffer.WriteInteger(1)
        ElseIf Vital = Vitals.MP Then
            Buffer.WriteInteger(2)
        End If

        Select Case Vital
            Case Vitals.HP
                Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.HP))
                Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health)

            Case Vitals.MP
                Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.MP))
                Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana)
        End Select

        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Public Sub BufferPetSkill(ByVal Index As Integer, ByVal SkillSlot As Integer)
        Dim Spellnum As Integer, MPCost As Integer, LevelReq As Integer
        Dim MapNum As Integer, SpellCastType As Integer
        Dim AccessReq As Integer, Range As Integer, HasBuffered As Boolean
        Dim TargetTypes As Byte, Target As Integer, TargetZone As Integer

        ' Prevent subscript out of range

        If SkillSlot <= 0 Or SkillSlot > 4 Then Exit Sub

        Spellnum = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Spell(SkillSlot)
        MapNum = GetPlayerMap(Index)

        If Spellnum <= 0 Or Spellnum > MAX_SKILLS Then Exit Sub

        ' see if cooldown has finished
        If TempPlayer(Index).PetSpellCD(SkillSlot) > GetTickCount() Then
            PlayerMsg(Index, Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & "'s Spell hasn't cooled down yet!", ColorType.BrightRed)
            Exit Sub
        End If

        MPCost = Skill(Spellnum).MPCost

        ' Check if they have enough MP
        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana < MPCost Then
            PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " does not have enough mana!", ColorType.BrightRed)
            Exit Sub
        End If

        LevelReq = Skill(Spellnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level Then
            PlayerMsg(Index, Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " must be level " & LevelReq & " to cast this spell.", ColorType.BrightRed)
            Exit Sub
        End If

        AccessReq = Skill(Spellnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(Index) Then
            PlayerMsg(Index, "You must be an administrator to cast this spell, even as a pet owner.", ColorType.BrightRed)
            Exit Sub
        End If

        ' find out what kind of spell it is! self cast, target or AOE
        If Skill(Spellnum).range > 0 Then

            ' ranged attack, single target or aoe?
            If Not Skill(Spellnum).IsAoE Then
                SpellCastType = 2 ' targetted
            Else
                SpellCastType = 3 ' targetted aoe
            End If
        Else
            If Not Skill(Spellnum).IsAoE Then
                SpellCastType = 0 ' self-cast
            Else
                SpellCastType = 1 ' self-cast AoE
            End If
        End If

        TargetTypes = TempPlayer(Index).PetTargetType
        Target = TempPlayer(Index).PetTarget
        TargetZone = TempPlayer(Index).PetTargetZone
        Range = Skill(Spellnum).range
        HasBuffered = False

        Select Case SpellCastType

            'PET
            Case 0, 1, SkillType.Pet ' self-cast & self-cast AOE
                HasBuffered = True

            Case 2, 3 ' targeted & targeted AOE

                ' check if have target
                If Not Target > 0 Then
                    If SpellCastType = SkillType.HealHp Or SpellCastType = SkillType.HealMp Then
                        Target = Index
                        TargetTypes = TargetType.Pet
                    Else
                        PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " does not have a target.", ColorType.Yellow)
                    End If
                End If

                If TargetTypes = TargetType.Player Then

                    ' if have target, check in range
                    If Not isInRange(Range, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, GetPlayerX(Target), GetPlayerY(Target)) Then
                        PlayerMsg(Index, "Target not in range of " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & ".", ColorType.Yellow)
                    Else
                        ' go through spell types
                        If Skill(Spellnum).Type <> SkillType.DamageHp And Skill(Spellnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPetAttackPlayer(Index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If

                ElseIf TargetTypes = TargetType.Npc Then

                    ' if have target, check in range
                    If Not isInRange(Range, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, MapNpc(MapNum).Npc(Target).x, MapNpc(MapNum).Npc(Target).y) Then
                        PlayerMsg(Index, "Target not in range of " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & ".", ColorType.Yellow)
                        HasBuffered = False
                    Else
                        ' go through spell types
                        If Skill(Spellnum).Type <> SkillType.DamageHp And Skill(Spellnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPetAttackNpc(Index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If

                    'PET
                ElseIf TargetTypes = TargetType.Pet Then

                    ' if have target, check in range
                    If Not isInRange(Range, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, Player(Target).Character(TempPlayer(Target).CurChar).Pet.x, Player(Target).Character(TempPlayer(Target).CurChar).Pet.y) Then
                        PlayerMsg(Index, "Target not in range of " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & ".", ColorType.Yellow)
                        HasBuffered = False
                    Else
                        ' go through spell types
                        If Skill(Spellnum).Type <> SkillType.DamageHp And Skill(Spellnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPetAttackPet(Index, Target, Spellnum) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                End If
        End Select

        If HasBuffered Then
            SendAnimation(MapNum, Skill(Spellnum).CastAnim, 0, 0, TargetType.Pet, Index)
            SendActionMsg(MapNum, "Casting " & Trim$(Skill(Spellnum).Name) & "!", ColorType.BrightRed, ActionMsgType.Scroll, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32)
            TempPlayer(Index).PetspellBuffer.Spell = SkillSlot
            TempPlayer(Index).PetspellBuffer.Timer = GetTickCount()
            TempPlayer(Index).PetspellBuffer.Target = Target
            TempPlayer(Index).PetspellBuffer.tType = TargetTypes
            TempPlayer(Index).PetspellBuffer.TargetZone = TargetZone
            Exit Sub
        Else
            SendClearPetSpellBuffer(Index)
        End If

    End Sub

    Sub SendClearPetSpellBuffer(ByVal Index As Integer)

        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SClearPetSkillBuffer)

        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Public Sub PetCastSpell(ByVal Index As Integer, ByVal Skillslot As Integer, ByVal Target As Integer, ByVal TargetTypes As Byte, Optional TakeMana As Boolean = True, Optional ZoneNum As Integer = 0)
        Dim Skillnum As Integer, MPCost As Integer, LevelReq As Integer
        Dim MapNum As Integer, Vital As Integer, DidCast As Boolean
        Dim AccessReq As Integer, i As Integer
        Dim AoE As Integer, Range As Integer, VitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer
        Dim SkillCastType As Integer

        DidCast = False

        ' Prevent subscript out of range
        If Skillslot <= 0 Or Skillslot > 4 Then Exit Sub

        Skillnum = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Spell(Skillslot)
        MapNum = GetPlayerMap(Index)

        MPCost = Skill(Skillnum).MPCost

        ' Check if they have enough MP
        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana < MPCost Then
            PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " does not have enough mana!", ColorType.BrightRed)
            Exit Sub
        End If

        LevelReq = Skill(Skillnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level Then
            PlayerMsg(Index, Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " must be level " & LevelReq & " to cast this spell.", ColorType.BrightRed)
            Exit Sub
        End If

        AccessReq = Skill(Skillnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(Index) Then
            PlayerMsg(Index, "You must be an administrator for even your pet to cast this spell.", ColorType.BrightRed)
            Exit Sub
        End If

        ' find out what kind of spell it is! self cast, target or AOE
        If Skill(Skillnum).IsProjectile = True Then
            SkillCastType = 4 ' Projectile
        ElseIf Skill(Skillnum).range > 0 Then
            ' ranged attack, single target or aoe?
            If Not Skill(Skillnum).IsAoE Then
                SkillCastType = 2 ' targetted
            Else
                SkillCastType = 3 ' targetted aoe
            End If
        Else
            If Not Skill(Skillnum).IsAoE Then
                SkillCastType = 0 ' self-cast
            Else
                SkillCastType = 1 ' self-cast AoE
            End If
        End If

        ' set the vital
        Vital = Skill(Skillnum).Vital
        AoE = Skill(Skillnum).AoE
        Range = Skill(Skillnum).range

        Select Case SkillCastType
            Case 0 ' self-cast target
                Select Case Skill(Skillnum).Type
                    Case SkillType.HealHp
                        SpellPet_Effect(Vitals.HP, True, Index, Vital, Skillnum)
                        DidCast = True
                    Case SkillType.HealMp
                        SpellPet_Effect(Vitals.MP, True, Index, Vital, Skillnum)
                        DidCast = True
                End Select

            Case 1, 3 ' self-cast AOE & targetted AOE

                If SkillCastType = 1 Then
                    x = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x
                    y = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y
                ElseIf SkillCastType = 3 Then

                    If TargetTypes = 0 Then Exit Sub
                    If Target = 0 Then Exit Sub

                    If TargetTypes = TargetType.Player Then
                        x = GetPlayerX(Target)
                        y = GetPlayerY(Target)
                    ElseIf TargetTypes = TargetType.Npc Then
                        x = MapNpc(MapNum).Npc(Target).x
                        y = MapNpc(MapNum).Npc(Target).y
                    ElseIf TargetTypes = TargetType.Pet Then
                        x = Player(Target).Character(TempPlayer(Target).CurChar).Pet.x
                        y = Player(Target).Character(TempPlayer(Target).CurChar).Pet.y
                    End If

                    If Not isInRange(Range, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, x, y) Then
                        PlayerMsg(Index, Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & "'s target not in range.", ColorType.Yellow)
                        SendClearPetSpellBuffer(Index)
                    End If
                End If

                Select Case Skill(Skillnum).Type

                    Case SkillType.DamageHp
                        DidCast = True

                        For i = 1 To MAX_PLAYERS

                            If IsPlaying(i) Then
                                If i <> Index Then
                                    If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                        If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                            If CanPetAttackPlayer(Index, i, True) And Index <> Target Then
                                                SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Player, i)
                                                PetAttackPlayer(Index, i, Vital, Skillnum)
                                            End If
                                        End If

                                        If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True Then
                                            If isInRange(AoE, x, y, Player(i).Character(TempPlayer(i).CurChar).Pet.x, Player(i).Character(TempPlayer(i).CurChar).Pet.y) Then

                                                If CanPetAttackPet(Index, i, Skillnum) Then
                                                    SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Pet, i)
                                                    PetAttackPet(Index, i, Vital, Skillnum)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        For i = 1 To MAX_MAP_NPCS

                            If MapNpc(MapNum).Npc(i).Num > 0 Then
                                If MapNpc(MapNum).Npc(i).Vital(Vitals.HP) > 0 Then
                                    If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).x, MapNpc(MapNum).Npc(i).y) Then
                                        If CanPetAttackNpc(Index, i, True) Then
                                            SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Npc, i)
                                            PetAttackNpc(Index, i, Vital, Skillnum)
                                        End If
                                    End If
                                End If
                            End If
                        Next

                    Case SkillType.HealHp, SkillType.HealMp, SkillType.DamageMp

                        If Skill(Skillnum).Type = SkillType.HealHp Then
                            VitalType = Vitals.HP
                            increment = True
                        ElseIf Skill(Skillnum).Type = SkillType.HealMp Then
                            VitalType = Vitals.MP
                            increment = True
                        ElseIf Skill(Skillnum).Type = SkillType.DamageMp Then
                            VitalType = Vitals.MP
                            increment = False
                        End If

                        DidCast = True

                        For i = 1 To MAX_PLAYERS

                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                    If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        SpellPlayer_Effect(VitalType, increment, i, Vital, Skillnum)
                                    End If

                                    If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive Then
                                        If isInRange(AoE, x, y, Player(i).Character(TempPlayer(i).CurChar).Pet.x, Player(i).Character(TempPlayer(i).CurChar).Pet.y) Then
                                            SpellPet_Effect(VitalType, increment, i, Vital, Skillnum)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                End Select

            Case 2 ' targetted

                If TargetTypes = 0 Then Exit Sub
                If Target = 0 Then Exit Sub

                If TargetTypes = TargetType.Player Then
                    x = GetPlayerX(Target)
                    y = GetPlayerY(Target)
                ElseIf TargetTypes = TargetType.Npc Then
                    x = MapNpc(MapNum).Npc(Target).x
                    y = MapNpc(MapNum).Npc(Target).y
                ElseIf TargetTypes = TargetType.Pet Then
                    x = Player(Target).Character(TempPlayer(Target).CurChar).Pet.x
                    y = Player(Target).Character(TempPlayer(Target).CurChar).Pet.y
                End If

                If Not isInRange(Range, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, x, y) Then
                    PlayerMsg(Index, "Target is not in range of your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & "!", ColorType.Yellow)
                    SendClearPetSpellBuffer(Index)
                    Exit Sub

                End If

                Select Case Skill(Skillnum).Type

                    Case SkillType.DamageHp

                        If TargetTypes = TargetType.Player Then
                            If CanPetAttackPlayer(Index, Target, True) And Index <> Target Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Player, Target)
                                    PetAttackPlayer(Index, Target, Vital, Skillnum)
                                    DidCast = True
                                End If
                            End If
                        ElseIf TargetTypes = TargetType.Npc Then

                            If CanPetAttackNpc(Index, Target, True) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Npc, Target)
                                    PetAttackNpc(Index, Target, Vital, Skillnum)
                                    DidCast = True

                                End If

                            End If
                        ElseIf TargetTypes = TargetType.Pet Then

                            If CanPetAttackPet(Index, Target, Skillnum) Then
                                If Vital > 0 Then
                                    SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Pet, Target)
                                    PetAttackPet(Index, Target, Vital, Skillnum)
                                    DidCast = True
                                End If
                            End If
                        End If

                    Case SkillType.DamageMp, SkillType.HealMp, SkillType.HealHp

                        If Skill(Skillnum).Type = SkillType.DamageMp Then
                            VitalType = Vitals.MP
                            increment = False
                        ElseIf Skill(Skillnum).Type = SkillType.HealMp Then
                            VitalType = Vitals.MP
                            increment = True
                        ElseIf Skill(Skillnum).Type = SkillType.HealHp Then
                            VitalType = Vitals.HP
                            increment = True
                        End If

                        If TargetTypes = TargetType.Player Then
                            If Skill(Skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackPlayer(Index, Target, True) Then
                                    SpellPlayer_Effect(VitalType, increment, Target, Vital, Skillnum)
                                End If
                            Else
                                SpellPlayer_Effect(VitalType, increment, Target, Vital, Skillnum)
                            End If

                        ElseIf TargetTypes = TargetType.Npc Then

                            If Skill(Skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackNpc(Index, Target, True) Then
                                    SpellNpc_Effect(VitalType, increment, Target, Vital, Skillnum, MapNum)
                                End If
                            Else
                                If Skill(Skillnum).Type = SkillType.HealHp Or Skill(Skillnum).Type = SkillType.HealMp Then
                                    SpellPet_Effect(VitalType, increment, Index, Vital, Skillnum)
                                Else
                                    SpellNpc_Effect(VitalType, increment, Target, Vital, Skillnum, MapNum)
                                End If
                            End If

                        ElseIf TargetTypes = TargetType.Pet Then

                            If Skill(Skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackPet(Index, Target, Skillnum) Then
                                    SpellPet_Effect(VitalType, increment, Target, Vital, Skillnum)
                                End If
                            Else
                                SpellPet_Effect(VitalType, increment, Target, Vital, Skillnum)
                                SendPetVital(Target, Vital)
                            End If
                        End If
                End Select

            Case 4 ' Projectile
                PetFireProjectile(Index, Skillnum)
                DidCast = True
        End Select

        If DidCast Then
            If TakeMana Then Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana - MPCost
            SendPetVital(Index, Vitals.MP)
            SendPetVital(Index, Vitals.HP)

            TempPlayer(Index).PetSpellCD(Skillslot) = GetTickCount() + (Skill(Skillnum).CDTime * 1000)

            SendActionMsg(MapNum, Trim$(Skill(Skillnum).Name) & "!", ColorType.BrightRed, ActionMsgType.Scroll, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32)

        End If

    End Sub

    Public Sub SpellPet_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Integer, ByVal Damage As Integer, ByVal Skillnum As Integer)
        Dim sSymbol As String
        Dim Colour As Integer

        If Damage > 0 Then
            If increment Then
                sSymbol = "+"
                If Vital = Vitals.HP Then Colour = ColorType.BrightGreen
                If Vital = Vitals.MP Then Colour = ColorType.BrightBlue
            Else
                sSymbol = "-"
                Colour = ColorType.Blue
            End If

            SendAnimation(GetPlayerMap(Index), Skill(Skillnum).SkillAnim, 0, 0, TargetType.Pet, Index)
            SendActionMsg(GetPlayerMap(Index), sSymbol & Damage, Colour, ActionMsgType.Scroll, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32)

            ' send the sound
            'SendMapSound(Index, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, SoundEntity.seSpell, Skillnum)

            If increment Then
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health + Damage

                If Skill(Skillnum).Duration > 0 Then
                    'AddHoT_Pet Index, Spellnum
                End If

            ElseIf Not increment Then
                If Vital = Vitals.HP Then
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health - Damage
                ElseIf Vital = Vitals.MP Then
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana - Damage
                End If
            End If
        End If

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health > GetPetMaxVital(Index, Vitals.HP) Then Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = GetPetMaxVital(Index, Vitals.HP)

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana > GetPetMaxVital(Index, Vitals.MP) Then Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = GetPetMaxVital(Index, Vitals.MP)

    End Sub

    '    Public Sub AddHoT_Pet(ByVal Index As Integer, ByVal Spellnum As Integer)

    '        Dim i As Integer

    '        On Error GoTo errorhandler

    '        For i = 1 To MAX_DOTS

    '            With TempPlayer(Index).PetHoT(i)

    '                If .Spell = Spellnum Then
    '                    .Timer = GetTickCount()
    '                    .StartTime = GetTickCount()
    '                    Exit Sub

    '                End If

    '                If .Used = False Then
    '                    .Spell = Spellnum
    '                    .Timer = GetTickCount()
    '                    .Used = True
    '                    .StartTime = GetTickCount()
    '                    Exit Sub

    '                End If

    '            End With

    '        Next

    '        On Error GoTo 0

    '        Exit Sub
    'errorhandler:
    '        HandleError "AddHoT_Pet", "modPets", Err.Number, Err.Description, Erl
    '    Err.Clear()

    '    End Sub

    '    Public Sub AddDoT_Pet(ByVal Index As Integer, ByVal Spellnum As Integer, ByVal Caster As Integer, AttackerType As Integer)

    '        Dim i As Integer

    '        On Error GoTo errorhandler

    '        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Sub

    '        For i = 1 To MAX_DOTS

    '            With TempPlayer(Index).PetDoT(i)

    '                If .Spell = Spellnum Then
    '                    .Timer = GetTickCount()
    '                    .Caster = Caster
    '                    .StartTime = GetTickCount()
    '                    .AttackerType = AttackerType
    '                    Exit Sub

    '                End If

    '                If .Used = False Then
    '                    .Spell = Spellnum
    '                    .Timer = GetTickCount()
    '                    .Caster = Caster
    '                    .Used = True
    '                    .StartTime = GetTickCount()
    '                    .AttackerType = AttackerType
    '                    Exit Sub

    '                End If

    '            End With

    '        Next

    '        On Error GoTo 0

    '        Exit Sub
    'errorhandler:
    '        HandleError "AddDoT_Pet", "modPets", Err.Number, Err.Description, Erl
    '    Err.Clear()

    '    End Sub

    Sub PetAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer, Optional ByVal SkillNum As Integer = 0)
        Dim Exp As Integer, n As Integer, i As Integer
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range

        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Or Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Alive = False Then
            Exit Sub
        End If

        ' Check for weapon
        n = 0 'No Weapon, PET!

        If SkillNum = 0 Then
            ' Send this packet so they can see the pet attacking
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SAttack)
            Buffer.WriteInteger(Attacker)
            Buffer.WriteInteger(1)
            SendDataToMap(GetPlayerMap(Victim), Buffer.ToArray)
            Buffer = Nothing
        End If

        ' set the regen timer
        TempPlayer(Attacker).PetstopRegen = True
        TempPlayer(Attacker).PetstopRegenTimer = GetTickCount()

        If Damage >= GetPlayerVital(Victim, Vitals.HP) Then
            SendActionMsg(GetPlayerMap(Victim), "-" & GetPlayerVital(Victim, Vitals.HP), ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            ' send the sound
            'If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

            ' Player is dead
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & GetPlayerName(Attacker) & "'s " & Trim$(Pet(Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Num).Name) & ".")

            ' Calculate exp to give attacker
            Exp = (GetPlayerExp(Victim) \ 10)

            ' Make sure we dont get less then 0
            If Exp < 0 Then
                Exp = 0
            End If

            If Exp = 0 Then
                PlayerMsg(Victim, "You lost no exp.", ColorType.BrightGreen)
                PlayerMsg(Attacker, "You received no exp.", ColorType.BrightRed)
            Else
                SetPlayerExp(Victim, GetPlayerExp(Victim) - Exp)
                SendExp(Victim)
                PlayerMsg(Victim, "You lost " & Exp & " exp.", ColorType.BrightRed)

                ' check if we're in a party
                If TempPlayer(Attacker).InParty > 0 Then
                    ' pass through party exp share function
                    Party_ShareExp(TempPlayer(Attacker).InParty, Exp, Attacker, GetPlayerMap(Attacker))
                Else
                    ' not in party, get exp for self
                    GivePlayerEXP(Attacker, Exp)
                End If
            End If

            ' purge target info of anyone who targetted dead guy
            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) And IsConnected(i) Then
                    If GetPlayerMap(i) = GetPlayerMap(Attacker) Then
                        If TempPlayer(i).TargetType = TargetType.Player Then
                            If TempPlayer(i).Target = Victim Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If

                        If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True Then
                            If TempPlayer(i).PetTargetType = TargetType.Player Then
                                If TempPlayer(i).PetTarget = Victim Then
                                    TempPlayer(i).PetTarget = 0
                                    TempPlayer(i).PetTargetType = TargetType.None
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            If GetPlayerPK(Victim) = 0 Then
                If GetPlayerPK(Attacker) = 0 Then
                    SetPlayerPK(Attacker, 1)
                    SendPlayerData(Attacker)
                    GlobalMsg(GetPlayerName(Attacker) & " has been deemed a Player Killer!!!")
                End If
            Else
                GlobalMsg(GetPlayerName(Victim) & " has paid the price for being a Player Killer!!!")
            End If

            OnDeath(Victim)
        Else
            ' Player not dead, just do the damage
            SetPlayerVital(Victim, Vitals.HP, GetPlayerVital(Victim, Vitals.HP) - Damage)
            SendVital(Victim, Vitals.HP)

            ' send vitals to party if in one
            If TempPlayer(Victim).InParty > 0 Then SendPartyVitals(TempPlayer(Victim).InParty, Victim)

            ' send the sound
            'If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
            SendBlood(GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))

            ' set the regen timer
            TempPlayer(Victim).stopRegen = True
            TempPlayer(Victim).stopRegenTimer = GetTickCount()

            'if a stunning spell, stun the player
            If SkillNum > 0 Then
                If Skill(SkillNum).StunDuration > 0 Then StunPlayer(Victim, SkillNum)

                ' DoT
                If Skill(SkillNum).Duration > 0 Then
                    'AddDoT_Player(Victim, SkillNum, Attacker)
                End If
            End If
        End If

        ' Reset attack timer
        TempPlayer(Attacker).PetAttackTimer = GetTickCount()

    End Sub

    Function CanPetAttackPet(ByVal Attacker As Integer, ByVal Victim As Integer, Optional ByVal IsSkill As Integer = 0) As Boolean

        If Not IsSkill Then
            If GetTickCount() < TempPlayer(Attacker).PetAttackTimer + 1000 Then Exit Function
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Or Not IsPlaying(Attacker) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = 1 Then Exit Function

        If TempPlayer(Attacker).PetspellBuffer.Spell > 0 And IsSkill = False Then Exit Function

        If Not IsSkill Then

            ' Check if at same coordinates
            Select Case Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Dir
                Case Direction.Up
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y - 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Direction.Down
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y + 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Direction.Left
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x + 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Direction.Right
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.y) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x - 1 = Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.x)) Then Exit Function

                Case Else
                    Exit Function
            End Select
        End If

        ' Check if map is attackable
        If Not Map(GetPlayerMap(Attacker)).Moral = MapMoral.None Then
            If GetPlayerPK(Victim) = 0 Then
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Monitor Then
            PlayerMsg(Attacker, "Admins cannot attack other players.", ColorType.BrightRed)
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "!", ColorType.BrightRed)
            Exit Function
        End If

        ' Don't attack a party member
        If TempPlayer(Attacker).InParty > 0 And TempPlayer(Victim).InParty > 0 Then
            If TempPlayer(Attacker).InParty = TempPlayer(Victim).InParty Then
                PlayerMsg(Attacker, "You can't attack another party member!", ColorType.BrightRed)
                Exit Function
            End If
        End If

        If TempPlayer(Attacker).InParty > 0 And TempPlayer(Victim).InParty > 0 And TempPlayer(Attacker).InParty = TempPlayer(Victim).InParty Then
            If IsSkill > 0 Then
                If Skill(IsSkill).Type = SkillType.HealMp Or Skill(IsSkill).Type = SkillType.HealHp Then
                    'Carry On :D
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
        End If

        CanPetAttackPet = True

    End Function

    Sub PetAttackPet(ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer, Optional ByVal Skillnum As Integer = 0)
        Dim Exp As Integer, n As Integer, i As Integer
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range

        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Or Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Alive = False Or Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Alive = False Then
            Exit Sub
        End If

        ' Check for weapon
        n = 0 'No Weapon, PET!

        If Skillnum = 0 Then
            ' Send this packet so they can see the pet attacking
            Buffer = New ByteBuffer
            Buffer.WriteInteger(ServerPackets.SAttack)
            Buffer.WriteInteger(Attacker)
            Buffer.WriteInteger(1)
            SendDataToMap(GetPlayerMap(Victim), Buffer.ToArray)
            Buffer = Nothing
        End If

        ' set the regen timer
        TempPlayer(Attacker).PetstopRegen = True
        TempPlayer(Attacker).PetstopRegenTimer = GetTickCount()

        If Damage >= Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health Then
            SendActionMsg(GetPlayerMap(Victim), "-" & Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health, ColorType.BrightRed, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            ' Player is dead
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & GetPlayerName(Attacker) & "'s " & Trim$(Pet(Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Num).Name) & ".")

            ' Calculate exp to give attacker
            Exp = (GetPlayerExp(Victim) \ 10)

            ' Make sure we dont get less then 0
            If Exp < 0 Then Exp = 0

            If Exp = 0 Then
                PlayerMsg(Victim, "You lost no exp.", ColorType.BrightGreen)
                PlayerMsg(Attacker, "You received no exp.", ColorType.Yellow)
            Else
                SetPlayerExp(Victim, GetPlayerExp(Victim) - Exp)
                SendExp(Victim)
                PlayerMsg(Victim, "You lost " & Exp & " exp.", ColorType.BrightRed)

                ' check if we're in a party
                If TempPlayer(Attacker).InParty > 0 Then
                    ' pass through party exp share function
                    Party_ShareExp(TempPlayer(Attacker).InParty, Exp, Attacker, GetPlayerMap(Attacker))
                Else
                    ' not in party, get exp for self
                    GivePlayerEXP(Attacker, Exp)
                End If
            End If

            ' purge target info of anyone who targetted dead guy
            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) And IsConnected(i) Then
                    If GetPlayerMap(i) = GetPlayerMap(Attacker) Then
                        If TempPlayer(i).TargetType = TargetType.Player Then
                            If TempPlayer(i).Target = Victim Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If

                        If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = True Then
                            If TempPlayer(i).PetTargetType = TargetType.Player Then
                                If TempPlayer(i).PetTarget = Victim Then
                                    TempPlayer(i).PetTarget = 0
                                    TempPlayer(i).PetTargetType = TargetType.None
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            If GetPlayerPK(Victim) = 0 Then
                If GetPlayerPK(Attacker) = 0 Then
                    SetPlayerPK(Attacker, 1)
                    SendPlayerData(Attacker)
                    GlobalMsg(GetPlayerName(Attacker) & " has been deemed a Player Killer!!!")
                End If
            Else
                GlobalMsg(GetPlayerName(Victim) & " has paid the price for being a Player Killer!!!")
            End If

            ' kill pet
            PlayerMsg(Victim, "Your " & Trim$(Pet(Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Num).Name) & " was killed by " & Trim$(GetPlayerName(Attacker)) & "'s " & Trim$(Pet(Player(Attacker).Character(TempPlayer(Attacker).CurChar).Pet.Num).Name) & "!", ColorType.BrightRed)
            ReleasePet(Victim)
        Else
            ' Player not dead, just do the damage
            Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health = Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health - Damage
            Call SendPetVital(Victim, Vitals.HP)

            'Set pet to begin attacking the other pet if it isn't dead or dosent have another target
            If TempPlayer(Victim).PetTarget <= 0 And TempPlayer(Victim).PetBehavior <> PET_BEHAVIOUR_GOTO Then
                TempPlayer(Victim).PetTarget = Attacker
                TempPlayer(Victim).PetTargetType = TargetType.Pet
            End If

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))
            SendBlood(GetPlayerMap(Victim), Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y)

            ' set the regen timer
            TempPlayer(Victim).PetstopRegen = True
            TempPlayer(Victim).PetstopRegenTimer = GetTickCount()

            'if a stunning spell, stun the player
            If Skillnum > 0 Then
                If Skill(Skillnum).StunDuration > 0 Then StunPet(Victim, Skillnum)
                ' DoT
                If Skill(Skillnum).Duration > 0 Then
                    'AddDoT_Pet(Victim, Skillnum, Attacker, TargetType.Pet)
                End If
            End If
        End If

        ' Reset attack timer
        TempPlayer(Attacker).PetAttackTimer = GetTickCount()

    End Sub

    Public Sub StunPet(ByVal Index As Integer, ByVal Skillnum As Integer)
        ' check if it's a stunning spell

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then
            If Skill(Skillnum).StunDuration > 0 Then
                ' set the values on index
                TempPlayer(Index).PetStunDuration = Skill(Skillnum).StunDuration
                TempPlayer(Index).PetStunTimer = GetTickCount()
                ' tell him he's stunned
                PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " has been stunned.", ColorType.Yellow)
            End If
        End If

    End Sub

    Public Sub HandleDoT_Pet(ByVal Index As Integer, ByVal dotNum As Integer)

        With TempPlayer(Index).PetDoT(dotNum)

            If .Used And .Spell > 0 Then

                ' time to tick?
                If GetTickCount() > .Timer + (Skill(.Spell).Interval * 1000) Then
                    If .AttackerType = TargetType.Pet Then
                        If CanPetAttackPet(.Caster, Index, .Spell) Then
                            PetAttackPet(.Caster, Index, Skill(.Spell).Vital)
                            SendPetVital(Index, Vitals.HP)
                            SendPetVital(Index, Vitals.MP)
                        End If
                    ElseIf .AttackerType = TargetType.Player Then
                        If CanPlayerAttackPet(.Caster, Index, .Spell) Then
                            PlayerAttackPet(.Caster, Index, Skill(.Spell).Vital)
                            SendPetVital(Index, Vitals.HP)
                            SendPetVital(Index, Vitals.MP)
                        End If
                    End If

                    .Timer = GetTickCount()

                    ' check if DoT is still active - if player died it'll have been purged
                    If .Used And .Spell > 0 Then

                        ' destroy DoT if finished
                        If GetTickCount() - .StartTime >= (Skill(.Spell).Duration * 1000) Then
                            .Used = False
                            .Spell = 0
                            .Timer = 0
                            .Caster = 0
                            .StartTime = 0
                        End If
                    End If
                End If
            End If
        End With

    End Sub

    Public Sub HandleHoT_Pet(ByVal Index As Integer, ByVal hotNum As Integer)

        With TempPlayer(Index).PetHoT(hotNum)

            If .Used And .Spell > 0 Then
                ' time to tick?
                If GetTickCount() > .Timer + (Skill(.Spell).Interval * 1000) Then
                    SendActionMsg(GetPlayerMap(Index), "+" & Skill(.Spell).Vital, ColorType.BrightGreen, ActionMsgType.Scroll, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32,)
                    Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health + Skill(.Spell).Vital

                    If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health > GetPetMaxVital(Index, Vitals.HP) Then Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = GetPetMaxVital(Index, Vitals.HP)

                    If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana > GetPetMaxVital(Index, Vitals.MP) Then Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = GetPetMaxVital(Index, Vitals.MP)
                    SendPetVital(Index, Vitals.HP)
                    SendPetVital(Index, Vitals.MP)
                    .Timer = GetTickCount()

                    ' check if DoT is still active - if player died it'll have been purged
                    If .Used And .Spell > 0 Then
                        ' destroy hoT if finished
                        If GetTickCount() - .StartTime >= (Skill(.Spell).Duration * 1000) Then
                            .Used = False
                            .Spell = 0
                            .Timer = 0
                            .Caster = 0
                            .StartTime = 0
                        End If
                    End If
                End If
            End If
        End With

    End Sub

    Public Sub TryPetAttackPlayer(ByVal Index As Integer, Victim As Integer)
        Dim MapNum As Integer, blockAmount As Integer, Damage As Integer

        If GetPlayerMap(Index) <> GetPlayerMap(Victim) Then Exit Sub

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Sub

        ' Can the npc attack the player?
        If CanPetAttackPlayer(Index, Victim) Then
            MapNum = GetPlayerMap(Index)

            ' check if PLAYER can avoid the attack
            If CanPlayerDodge(Victim) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            If CanPlayerParry(Victim) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPetDamage(Index)

            ' if the player blocks, take away the block amount
            blockAmount = CanPlayerBlockHit(Victim)
            Damage = Damage - blockAmount

            ' take away armour
            Damage = Damage - Random(1, (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Luck) * 2))

            ' randomise for up to 10% lower than max hit
            Damage = Random(1, Damage)

            ' * 1.5 if crit hit
            If CanPetCrit(Index) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32))
            End If

            If Damage > 0 Then
                PetAttackPlayer(Index, Victim, Damage)
            End If

        End If

    End Sub

    Public Function CanPetDodge(ByVal Index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Function

        CanPetDodge = False

        rate = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Luck) / 4
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPetDodge = True
        End If

    End Function

    Public Function CanPetParry(ByVal Index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Function

        CanPetParry = False

        rate = Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Luck) / 6
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPetParry = True
        End If

    End Function

    Public Sub TryPetAttackPet(ByVal Index As Integer, Victim As Integer)
        Dim MapNum As Integer, blockAmount As Integer, Damage As Integer

        If GetPlayerMap(Index) <> GetPlayerMap(Victim) Then Exit Sub

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Or Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Alive = False Then Exit Sub

        ' Can the npc attack the player?
        If CanPetAttackPet(Index, Victim) Then
            MapNum = GetPlayerMap(Index)

            ' check if Pet can avoid the attack
            If CanPetDodge(Victim) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))
                Exit Sub
            End If

            If CanPetParry(Victim) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPetDamage(Index)

            ' if the player blocks, take away the block amount
            Damage = Damage - blockAmount

            ' take away armour
            Damage = Damage - Random(1, (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Luck) * 2))

            ' randomise for up to 10% lower than max hit
            Damage = Random(1, Damage)

            ' * 1.5 if crit hit
            If CanPetCrit(Index) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32), (Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32))
            End If

            If Damage > 0 Then
                PetAttackPet(Index, Victim, Damage)
            End If

        End If

    End Sub

    Function CanPlayerAttackPet(ByVal Attacker As Integer, ByVal Victim As Integer, Optional ByVal IsSkill As Boolean = False) As Boolean

        If IsSkill = False Then
            ' Check attack timer
            If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
                If GetTickCount() < TempPlayer(Attacker).AttackTimer + Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Speed Then Exit Function
            Else
                If GetTickCount() < TempPlayer(Attacker).AttackTimer + 1000 Then Exit Function
            End If
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Then Exit Function

        If Not Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Alive Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = 1 Then Exit Function

        If IsSkill = False Then

            ' Check if at same coordinates
            Select Case GetPlayerDir(Attacker)

                Case Direction.Up
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y + 1 = GetPlayerY(Attacker)) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x = GetPlayerX(Attacker))) Then Exit Function

                Case Direction.Down
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y - 1 = GetPlayerY(Attacker)) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x = GetPlayerX(Attacker))) Then Exit Function

                Case Direction.Left
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y = GetPlayerY(Attacker)) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x + 1 = GetPlayerX(Attacker))) Then Exit Function

                Case Direction.Right
                    If Not ((Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y = GetPlayerY(Attacker)) And (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x - 1 = GetPlayerX(Attacker))) Then Exit Function

                Case Else
                    Exit Function
            End Select
        End If

        ' Check if map is attackable
        If Not Map(GetPlayerMap(Attacker)).Moral = MapMoral.None Then
            If GetPlayerPK(Victim) = 0 Then
                PlayerMsg(Attacker, "This is a safe zone!", ColorType.Yellow)
                Exit Function
            End If
        End If

        ' Make sure they have more then 0 hp
        If Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Monitor Then
            PlayerMsg(Attacker, "Admins cannot attack other players.", ColorType.BrightRed)
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "s " & Trim$(Pet(Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Num).Name) & "!", ColorType.BrightRed)
            Exit Function
        End If

        ' Don't attack a party member
        If TempPlayer(Attacker).InParty > 0 And TempPlayer(Victim).InParty > 0 Then
            If TempPlayer(Attacker).InParty = TempPlayer(Victim).InParty Then
                PlayerMsg(Attacker, "You can't attack another party member!", ColorType.BrightRed)
                Exit Function
            End If
        End If

        If TempPlayer(Attacker).InParty > 0 And TempPlayer(Victim).InParty > 0 And TempPlayer(Attacker).InParty = TempPlayer(Victim).InParty Then
            If IsSkill > 0 Then
                If Skill(IsSkill).Type = SkillType.HealMp Or Skill(IsSkill).Type = SkillType.HealHp Then
                    'Carry On :D
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
        End If

        CanPlayerAttackPet = True

    End Function

    Sub PlayerAttackPet(ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer, Optional ByVal Skillnum As Integer = 0)
        Dim Exp As Integer, n As Integer, i As Integer

        ' Check for subscript out of range

        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Or Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Alive = False Then
            Exit Sub
        End If

        ' Check for weapon
        n = 0

        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            n = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        ' set the regen timer
        TempPlayer(Attacker).stopRegen = True
        TempPlayer(Attacker).stopRegenTimer = GetTickCount()

        If Damage >= Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health Then
            SendActionMsg(GetPlayerMap(Victim), "-" & Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health, ColorType.BrightRed, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            ' Calculate exp to give attacker
            Exp = (GetPlayerExp(Victim) \ 10)

            ' Make sure we dont get less then 0
            If Exp < 0 Then Exp = 0

            If Exp = 0 Then
                PlayerMsg(Victim, "You lost no exp.", ColorType.BrightGreen)
                PlayerMsg(Attacker, "You received no exp.", ColorType.Yellow)
            Else
                SetPlayerExp(Victim, GetPlayerExp(Victim) - Exp)
                SendExp(Victim)
                PlayerMsg(Victim, "You lost " & Exp & " exp.", ColorType.BrightRed)

                ' check if we're in a party
                If TempPlayer(Attacker).InParty > 0 Then
                    ' pass through party exp share function
                    Party_ShareExp(TempPlayer(Attacker).InParty, Exp, Attacker, GetPlayerMap(Attacker))
                Else
                    ' not in party, get exp for self
                    GivePlayerEXP(Attacker, Exp)
                End If
            End If

            ' purge target info of anyone who targetted dead guy
            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) And IsConnected(i) Then
                    If GetPlayerMap(i) = GetPlayerMap(Attacker) Then
                        If TempPlayer(i).Target = TargetType.Pet Then
                            If TempPlayer(i).Target = Victim Then
                                TempPlayer(i).Target = 0
                                TempPlayer(i).TargetType = TargetType.None
                                SendTarget(i, 0, TargetType.None)
                            End If
                        End If
                    End If
                End If
            Next

            PlayerMsg(Victim, ("Your " & Trim$(Pet(Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Num).Name) & " was killed by  " & Trim$(GetPlayerName(Attacker)) & "."), ColorType.BrightRed)
            ReleasePet(Victim)
        Else
            ' Player not dead, just do the damage
            Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health = Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Health - Damage
            SendPetVital(Victim, Vitals.HP)

            'Set pet to begin attacking the other pet if it isn't dead or dosent have another target
            If TempPlayer(Victim).PetTarget <= 0 And TempPlayer(Victim).PetBehavior <> PET_BEHAVIOUR_GOTO Then
                TempPlayer(Victim).PetTarget = Attacker
                TempPlayer(Victim).PetTargetType = TargetType.Player
            End If

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x * 32), (Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y * 32))
            SendBlood(GetPlayerMap(Victim), Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.y)

            ' set the regen timer
            TempPlayer(Victim).PetstopRegen = True
            TempPlayer(Victim).PetstopRegenTimer = GetTickCount()

            'if a stunning spell, stun the player
            If Skillnum > 0 Then
                If Skill(Skillnum).StunDuration > 0 Then StunPet(Victim, Skillnum)

                ' DoT
                If Skill(Skillnum).Duration > 0 Then
                    'AddDoT_Pet(Victim, Skillnum, Attacker, TargetType.Player)
                End If
            End If
        End If

        ' Reset attack timer
        TempPlayer(Attacker).AttackTimer = GetTickCount()

    End Sub

    Function IsPetByPlayer(ByVal Index As Integer) As Boolean
        Dim x As Integer, y As Integer, x1 As Integer, y1 As Integer

        If Index <= 0 Or Index > MAX_PLAYERS Or Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then Exit Function

        IsPetByPlayer = False

        x = GetPlayerX(Index)
        y = GetPlayerY(Index)
        x1 = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x
        y1 = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y

        If x = x1 Then
            If y = y1 + 1 Or y = y1 - 1 Then
                IsPetByPlayer = True
            End If
        ElseIf y = y1 Then
            If x = x1 - 1 Or x = x1 + 1 Then
                IsPetByPlayer = True
            End If
        End If

    End Function

    Function GetPetVitalRegen(ByVal Index As Integer, ByVal Vital As Vitals) As Integer
        Dim i As Integer

        If Index <= 0 Or Index > MAX_PLAYERS Or Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = False Then
            GetPetVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                i = (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Spirit) * 0.8) + 6

            Case Vitals.MP
                i = (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Spirit) / 4) + 12.5
        End Select

        GetPetVitalRegen = i

    End Function

    Public Sub TryPlayerAttackPet(ByVal Attacker As Integer, ByVal Victim As Integer)
        Dim blockAmount As Integer, MapNum As Integer
        Dim Damage As Integer

        Damage = 0

        If Player(Victim).Character(TempPlayer(Victim).CurChar).Pet.Alive = False Then Exit Sub

        ' Can we attack the npc?
        If CanPlayerAttackPet(Attacker, Victim) Then

            MapNum = GetPlayerMap(Attacker)

            TempPlayer(Attacker).Target = Victim
            TempPlayer(Attacker).TargetType = TargetType.Pet

            ' check if NPC can avoid the attack
            If CanPetDodge(Victim) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            If CanPetParry(Victim) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPlayerDamage(Attacker)

            ' if the npc blocks, take away the block amount
            blockAmount = 0
            Damage = Damage - blockAmount

            ' take away armour
            Damage = Damage - Random(1, (GetPlayerStat(Victim, Stats.Luck) * 2))

            ' randomise for up to 10% lower than max hit
            Damage = Random(1, Damage)

            ' * 1.5 if can crit
            If CanPlayerCriticalHit(Attacker) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32))
            End If

            If Damage > 0 Then
                PlayerAttackPet(Attacker, Victim, Damage)
            Else
                PlayerMsg(Attacker, "Your attack does nothing.", ColorType.BrightRed)
            End If
        End If

    End Sub

    Function GetPetMaxVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer

        If Index > MAX_PLAYERS Then Exit Function

        Select Case Vital
            Case Vitals.HP
                GetPetMaxVital = ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 4) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Endurance) * 10)) + 150

            Case Vitals.MP
                GetPetMaxVital = ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 4) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(Stats.Spirit) / 2)) * 5 + 50
        End Select

    End Function

    Function GetPetNextLevel(ByVal Index As Integer) As Integer

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = True Then
            If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).MaxLevel Then GetPetNextLevel = 0 : Exit Function
            GetPetNextLevel = (50 / 3) * ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1) ^ 3 - (6 * (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1) ^ 2) + 17 * (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1) - 12)
        End If

    End Function

    Sub CheckPetLevelUp(ByVal Index As Integer)
        Dim expRollover As Integer, level_count As Integer

        level_count = 0

        Do While Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp >= GetPetNextLevel(Index)
            expRollover = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp - GetPetNextLevel(Index)

            ' can level up?
            If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level < 99 And Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level < Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).MaxLevel Then
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1
            End If

            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points + Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).LevelPnts
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp = expRollover
            level_count = level_count + 1
        Loop

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " has gained " & level_count & " level!", ColorType.BrightGreen)
            Else
                'plural
                PlayerMsg(Index, "Your " & Trim$(Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name) & " has gained " & level_count & " levels!", ColorType.BrightGreen)
            End If

            SendPlayerData(Index)
        End If

    End Sub

    Public Sub PetFireProjectile(ByVal Index As Integer, ByVal Spellnum As Integer)
        Dim ProjectileSlot As Integer, ProjectileNum As Integer
        Dim MapNum As Integer, i As Integer

        ' Prevent subscript out of range

        MapNum = GetPlayerMap(Index)

        'Find a free projectile
        For i = 1 To MAX_PROJECTILES

            If MapProjectiles(MapNum, i).ProjectileNum = 0 Then ' Free Projectile
                ProjectileSlot = i
                Exit For
            End If
        Next

        'Check for no projectile, if so just overwrite the first slot
        If ProjectileSlot = 0 Then ProjectileSlot = 1

        If Spellnum < 1 Or Spellnum > MAX_SKILLS Then Exit Sub

        ProjectileNum = Skill(Spellnum).Projectile

        With MapProjectiles(MapNum, ProjectileSlot)
            .ProjectileNum = ProjectileNum
            .Owner = Index
            .OwnerType = TargetType.Pet
            .Dir = Player(i).Character(TempPlayer(i).CurChar).Pet.Dir
            .X = Player(i).Character(TempPlayer(i).CurChar).Pet.x
            .Y = Player(i).Character(TempPlayer(i).CurChar).Pet.y
            .Timer = GetTickCount() + 60000
        End With

        SendProjectileToMap(MapNum, ProjectileSlot)

    End Sub

End Module