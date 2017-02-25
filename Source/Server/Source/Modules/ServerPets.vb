﻿Module ServerPets
#Region "Declarations"

    Public Pet() As PetRec

    ' PET constants
    Public Const PET_BEHAVIOUR_FOLLOW As Byte = 0 'The pet will attack all npcs around
    Public Const PET_BEHAVIOUR_GOTO As Byte = 1 'If attacked, the pet will fight back
    Public Const PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT As Byte = 2 'The pet will attack all npcs around
    Public Const PET_ATTACK_BEHAVIOUR_GUARD As Byte = 3 'If attacked, the pet will fight back
    Public Const PET_ATTACK_BEHAVIOUR_DONOTHING As Byte = 4 'The pet will not attack even if attacked

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

        Dim Stat() As Byte

        Dim Skill() As Integer

        Dim Evolvable As Byte
        Dim EvolveLevel As Integer
        Dim EvolveNum As Integer
    End Structure

    Public Structure PlayerPetRec

        Dim Num As Integer
        Dim Health As Integer
        Dim Mana As Integer
        Dim Level As Integer
        Dim Stat() As Byte
        Dim Skill() As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Integer
        Dim Alive As Byte
        Dim AttackBehaviour As Integer
        Dim AdoptiveStats As Byte
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
        writer.Write(Trim$(Pet(PetNum).Name))
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
            writer.Write(Pet(PetNum).Skill(i))
        Next

        writer.Write(Pet(PetNum).Evolvable)
        writer.Write(Pet(PetNum).EvolveLevel)
        writer.Write(Pet(PetNum).EvolveNum)

        writer.Save(filename)

    End Sub

    Sub LoadPets()
        Dim i As Integer

        ClearPets()
        CheckPets()

        For i = 1 To MAX_PETS
            LoadPet(i)
            DoEvents()
        Next
        'SavePets()
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

        ReDim Pet(PetNum).Skill(4)
        For i = 1 To 4
            reader.Read(Pet(PetNum).Skill(i))
        Next

        reader.Read(Pet(PetNum).Evolvable)
        reader.Read(Pet(PetNum).EvolveLevel)
        reader.Read(Pet(PetNum).EvolveNum)

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

        Pet(PetNum).Name = ""

        ReDim Pet(PetNum).stat(Stats.Count - 1)
        ReDim Pet(PetNum).Skill(4)
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
        Dim Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdatePet)

        Buffer.WriteInteger(PetNum)

        With Pet(PetNum)
            Buffer.WriteInteger(.Num)
            Buffer.WriteString(Trim$(.Name))
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
                Buffer.WriteInteger(.Skill(i))
            Next

            Buffer.WriteInteger(.Evolvable)
            Buffer.WriteInteger(.EvolveLevel)
            Buffer.WriteInteger(.EvolveNum)
        End With

        SendDataToAll(Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Sub SendUpdatePetTo(ByVal Index As Integer, ByVal petNum As Integer)
        Dim Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdatePet)

        Buffer.WriteInteger(petNum)

        With Pet(petNum)
            Buffer.WriteInteger(.Num)
            Buffer.WriteString(Trim$(.Name))
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
                Buffer.WriteInteger(.Skill(i))
            Next

            Buffer.WriteInteger(.Evolvable)
            Buffer.WriteInteger(.EvolveLevel)
            Buffer.WriteInteger(.EvolveNum)
        End With

        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Public Sub SendUpdatePlayerPet(ByVal Index As Integer, ByVal OwnerOnly As Boolean)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdatePlayerPet)

        Buffer.WriteInteger(Index)

        Buffer.WriteInteger(GetPetNum(Index))
        Buffer.WriteInteger(GetPetVital(Index, Vitals.HP))
        Buffer.WriteInteger(GetPetVital(Index, Vitals.MP))
        Buffer.WriteInteger(GetPetLevel(Index))

        For i = 1 To Stats.Count - 1
            Buffer.WriteInteger(GetPetStat(Index, i))
        Next

        For i = 1 To 4
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Skill(i))
        Next

        Buffer.WriteInteger(GetPetX(Index))
        Buffer.WriteInteger(GetPetY(Index))
        Buffer.WriteInteger(GetPetDir(Index))

        Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.HP))
        Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.MP))

        Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive)

        Buffer.WriteInteger(GetPetBehaviour(Index))
        Buffer.WriteInteger(GetPetPoints(Index))
        Buffer.WriteInteger(GetPetExp(Index))
        Buffer.WriteInteger(GetPetNextLevel(Index))

        If OwnerOnly Then
            SendDataTo(Index, Buffer.ToArray)
        Else
            SendDataToMap(GetPlayerMap(Index), Buffer.ToArray)
        End If

        Buffer = Nothing
    End Sub

    Sub SendPetAttack(ByVal Index As Integer, ByVal MapNum As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ServerPackets.SPetAttack)
        buffer.WriteInteger(Index)
        SendDataToMap(MapNum, buffer.ToArray)
        buffer = Nothing
    End Sub

    Sub SendPetXY(ByVal Index As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ServerPackets.SPetXY)
        buffer.WriteInteger(Index)
        buffer.WriteInteger(X)
        buffer.WriteInteger(Y)
        SendDataToMap(GetPlayerMap(Index), buffer.ToArray)
        buffer = Nothing
    End Sub

    Sub SendPetExp(ByVal Index As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ServerPackets.SPetExp)
        buffer.WriteInteger(GetPetExp(Index))
        buffer.WriteInteger(GetPetNextLevel(Index))
        SendDataTo(Index, buffer.ToArray)
        buffer = Nothing
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_RequestEditPet(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.CRequestEditPet Then Exit Sub

        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        Buffer = Nothing

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPetEditor)
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing

    End Sub

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
                .Skill(i) = Buffer.ReadInteger
            Next

            .Evolvable = Buffer.ReadInteger
            .EvolveLevel = Buffer.ReadInteger
            .EvolveNum = Buffer.ReadInteger
        End With

        ' Save it
        SendUpdatePetToAll(petNum)
        SavePet(petNum)
        Addlog(GetPlayerLogin(Index) & " saved Pet #" & petNum & ".", ADMIN_LOG)
        SendPets(Index)
    End Sub

    Sub Packet_RequestPets(ByVal Index As Integer, ByVal data() As Byte)

        SendPets(Index)

    End Sub

    Sub Packet_SummonPet(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CSummonPet Then Exit Sub

        If PetAlive(Index) Then
            RecallPet(Index)
        Else
            SummonPet(Index)
        End If
    End Sub

    Sub Packet_PetMove(ByVal Index As Integer, ByVal data() As Byte)
        Dim x As Integer, y As Integer, i As Integer
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPetMove Then Exit Sub

        x = Buffer.ReadInteger
        y = Buffer.ReadInteger

        ' Prevent subscript out of range
        If x < 0 Or x > Map(GetPlayerMap(Index)).MaxX Or y < 0 Or y > Map(GetPlayerMap(Index)).MaxY Then Exit Sub

        ' Check for a player
        For i = 1 To GetTotalPlayersOnline()

            If IsPlaying(i) Then
                If GetPlayerMap(Index) = GetPlayerMap(i) AndAlso GetPlayerX(i) = x AndAlso GetPlayerY(i) = y Then
                    If i = Index Then
                        ' Change target
                        If TempPlayer(Index).PetTargetType = TargetType.Player And TempPlayer(Index).PetTarget = i Then
                            TempPlayer(Index).PetTarget = 0
                            TempPlayer(Index).PetTargetType = TargetType.None
                            TempPlayer(Index).PetBehavior = PET_BEHAVIOUR_GOTO
                            TempPlayer(Index).GoToX = x
                            TempPlayer(Index).GoToY = y
                            ' send target to player
                            PlayerMsg(Index, "Your pet is no longer following you.", ColorType.BrightGreen)
                        Else
                            TempPlayer(Index).PetTarget = i
                            TempPlayer(Index).PetTargetType = TargetType.Player
                            ' send target to player
                            TempPlayer(Index).PetBehavior = PET_BEHAVIOUR_FOLLOW
                            PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " is now following you.", ColorType.BrightGreen)
                        End If
                    Else
                        ' Change target
                        If TempPlayer(Index).PetTargetType = TargetType.Player And TempPlayer(Index).PetTarget = i Then
                            TempPlayer(Index).PetTarget = 0
                            TempPlayer(Index).PetTargetType = TargetType.None
                            ' send target to player
                            PlayerMsg(Index, "Your pet is no longer targetting " & Trim$(GetPlayerName(i)) & ".", ColorType.BrightGreen)
                        Else
                            TempPlayer(Index).PetTarget = i
                            TempPlayer(Index).PetTargetType = TargetType.Player
                            ' send target to player
                            PlayerMsg(Index, "Your pet is now targetting " & Trim$(GetPlayerName(i)) & ".", ColorType.BrightGreen)
                        End If
                    End If
                    Exit Sub
                End If
            End If

            If PetAlive(i) And i <> Index Then
                If GetPetX(i) = x AndAlso GetPetY(i) = y Then
                    ' Change target
                    If TempPlayer(Index).PetTargetType = TargetType.Pet And TempPlayer(Index).PetTarget = i Then
                        TempPlayer(Index).PetTarget = 0
                        TempPlayer(Index).PetTargetType = TargetType.None
                        ' send target to player
                        PlayerMsg(Index, "Your pet is no longer targetting " & Trim$(GetPlayerName(i)) & "'s " & Trim$(GetPetName(i)) & ".", ColorType.BrightGreen)
                    Else
                        TempPlayer(Index).PetTarget = i
                        TempPlayer(Index).PetTargetType = TargetType.Pet
                        ' send target to player
                        PlayerMsg(Index, "Your pet is now targetting " & Trim$(GetPlayerName(i)) & "'s " & Trim$(GetPetName(i)) & ".", ColorType.BrightGreen)
                    End If
                    Exit Sub
                End If
            End If
        Next

        'Search For Target First
        ' Check for an npc
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(GetPlayerMap(Index)).Npc(i).Num > 0 AndAlso MapNpc(GetPlayerMap(Index)).Npc(i).X = x AndAlso MapNpc(GetPlayerMap(Index)).Npc(i).Y = y Then
                If TempPlayer(Index).PetTarget = i And TempPlayer(Index).PetTargetType = TargetType.Npc Then
                    ' Change target
                    TempPlayer(Index).PetTarget = 0
                    TempPlayer(Index).PetTargetType = TargetType.None
                    ' send target to player
                    PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & "'s target is no longer a " & Trim$(Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Name) & "!", ColorType.BrightGreen)
                    Exit Sub
                Else
                    ' Change target
                    TempPlayer(Index).PetTarget = i
                    TempPlayer(Index).PetTargetType = TargetType.Npc
                    ' send target to player
                    PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & "'s target is now a " & Trim$(Npc(MapNpc(GetPlayerMap(Index)).Npc(i).Num).Name) & "!", ColorType.BrightGreen)
                    Exit Sub
                End If
            End If
        Next

        TempPlayer(Index).PetBehavior = PET_BEHAVIOUR_GOTO
        TempPlayer(Index).PetTargetType = 0
        TempPlayer(Index).PetTarget = 0
        TempPlayer(Index).GoToX = x
        TempPlayer(Index).GoToY = y

        Buffer = Nothing

    End Sub

    Sub Packet_SetPetBehaviour(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As New ByteBuffer, behaviour As Integer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CSetBehaviour Then Exit Sub

        behaviour = Buffer.ReadInteger

        If PetAlive(Index) Then
            Select Case behaviour
                Case PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT
                    SetPetBehaviour(Index, PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT)
                    SendActionMsg(GetPlayerMap(Index), "Agressive Mode!", ColorType.White, 0, GetPetX(Index) * 32, GetPetY(Index) * 32, Index)
                Case PET_ATTACK_BEHAVIOUR_GUARD
                    SetPetBehaviour(Index, PET_ATTACK_BEHAVIOUR_GUARD)
                    SendActionMsg(GetPlayerMap(Index), "Defensive Mode!", ColorType.White, 0, GetPetX(Index) * 32, GetPetY(Index) * 32, Index)
            End Select
        End If

        Buffer = Nothing

    End Sub

    Sub Packet_ReleasePet(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CReleasePet Then Exit Sub

        Buffer = Nothing

        If GetPetNum(Index) > 0 Then ReleasePet(Index)

    End Sub

    Sub Packet_PetSkill(ByVal Index As Integer, ByVal data() As Byte)
        Dim n As Integer
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPetSkill Then Exit Sub

        ' Skill slot
        n = Buffer.ReadInteger

        Buffer = Nothing

        ' set the skill buffer before castin
        BufferPetSkill(Index, n)

    End Sub

    Sub Packet_UsePetStatPoint(ByVal Index As Integer, ByVal data() As Byte)
        Dim PointType As Byte
        Dim sMes As String = ""
        Dim Buffer As New ByteBuffer

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CPetUseStatPoint Then Exit Sub

        PointType = Buffer.ReadInteger
        Buffer = Nothing

        ' Prevent hacking
        If (PointType < 0) Or (PointType > Stats.Count) Then Exit Sub

        If Not PetAlive(Index) Then Exit Sub

        ' Make sure they have points
        If GetPetPoints(Index) > 0 Then

            ' make sure they're not maxed#
            If GetPetStat(Index, PointType) >= 255 Then
                PlayerMsg(Index, "You cannot spend any more points on that stat for your pet.", ColorType.BrightRed)
                Exit Sub
            End If

            SetPetPoints(Index, GetPetPoints(Index) - 1)

            ' Everything is ok
            Select Case PointType
                Case Stats.Strength
                    SetPetStat(Index, PointType, GetPetStat(Index, PointType) + 1)
                    sMes = "Strength"
                Case Stats.Endurance
                    SetPetStat(Index, PointType, GetPetStat(Index, PointType) + 1)
                    sMes = "Endurance"
                Case Stats.Intelligence
                    SetPetStat(Index, PointType, GetPetStat(Index, PointType) + 1)
                    sMes = "Intelligence"
                Case Stats.Luck
                    SetPetStat(Index, PointType, GetPetStat(Index, PointType) + 1)
                    sMes = "Agility"
                Case Stats.Spirit
                    SetPetStat(Index, PointType, GetPetStat(Index, PointType) + 1)
                    sMes = "Willpower"
            End Select

            SendActionMsg(GetPlayerMap(Index), "+1 " & sMes, ColorType.White, 1, (GetPetX(Index) * 32), (GetPetY(Index) * 32))
        Else
            Exit Sub
        End If

        ' Send the update
        SendUpdatePlayerPet(Index, True)

    End Sub

#End Region

#Region "Pet Functions"

    Public Sub UpdatePetAI()
        Dim DidWalk As Boolean, GivePetHPTimer As Integer, PlayerIndex As Integer
        Dim MapNum As Integer, TickCount As Integer, i As Integer, n As Integer
        Dim DistanceX As Integer, DistanceY As Integer, tmpdir As Integer
        Dim Target As Integer, TargetTypes As Byte, TargetX As Integer, TargetY As Integer, target_verify As Boolean

        For MapNum = 1 To MAX_CACHED_MAPS
            For PlayerIndex = 1 To GetTotalPlayersOnline()
                TickCount = GetTickCount()

                If GetPlayerMap(PlayerIndex) = MapNum AndAlso PetAlive(PlayerIndex) Then
                    ' // This is used for ATTACKING ON SIGHT //

                    ' If the npc is a attack on sight, search for a player on the map
                    If GetPetBehaviour(PlayerIndex) <> PET_ATTACK_BEHAVIOUR_DONOTHING Then

                        ' make sure it's not stunned
                        If Not TempPlayer(PlayerIndex).PetStunDuration > 0 Then

                            For i = 1 To MAX_PLAYERS
                                If TempPlayer(PlayerIndex).PetTargetType > 0 Then
                                    If TempPlayer(PlayerIndex).PetTargetType = 1 And TempPlayer(PlayerIndex).PetTarget = PlayerIndex Then
                                    Else
                                        Exit For
                                    End If
                                End If

                                If IsPlaying(i) And i <> PlayerIndex Then
                                    If GetPlayerMap(i) = MapNum And GetPlayerAccess(i) <= AdminType.Monitor Then
                                        If PetAlive(i) Then
                                            n = GetPetRange(PlayerIndex)
                                            DistanceX = GetPetX(PlayerIndex) - GetPetX(i)
                                            DistanceY = GetPetY(PlayerIndex) - GetPetY(i)

                                            ' Make sure we get a positive value
                                            If DistanceX < 0 Then DistanceX = DistanceX * -1
                                            If DistanceY < 0 Then DistanceY = DistanceY * -1

                                            ' Are they in range?  if so GET'M!
                                            If DistanceX <= n And DistanceY <= n Then
                                                If GetPetBehaviour(PlayerIndex) = PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT Then
                                                    TempPlayer(PlayerIndex).PetTargetType = TargetType.Pet ' pet
                                                    TempPlayer(PlayerIndex).PetTarget = i
                                                End If
                                            End If
                                        Else
                                            n = GetPetRange(PlayerIndex)
                                            DistanceX = GetPetX(PlayerIndex) - GetPlayerX(i)
                                            DistanceY = GetPetY(PlayerIndex) - GetPlayerY(i)

                                            ' Make sure we get a positive value
                                            If DistanceX < 0 Then DistanceX = DistanceX * -1
                                            If DistanceY < 0 Then DistanceY = DistanceY * -1

                                            ' Are they in range?  if so GET'M!
                                            If DistanceX <= n And DistanceY <= n Then
                                                If GetPetBehaviour(PlayerIndex) = PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT Then
                                                    TempPlayer(PlayerIndex).PetTargetType = TargetType.Player ' player
                                                    TempPlayer(PlayerIndex).PetTarget = i
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            If TempPlayer(PlayerIndex).PetTargetType = 0 Then
                                For i = 1 To MAX_MAP_NPCS

                                    If TempPlayer(PlayerIndex).PetTargetType > 0 Then Exit For
                                    If PetAlive(PlayerIndex) Then
                                        n = GetPetRange(PlayerIndex)
                                        DistanceX = GetPetX(PlayerIndex) - MapNpc(GetPlayerMap(PlayerIndex)).Npc(i).X
                                        DistanceY = GetPetY(PlayerIndex) - MapNpc(GetPlayerMap(PlayerIndex)).Npc(i).Y

                                        ' Make sure we get a positive value
                                        If DistanceX < 0 Then DistanceX = DistanceX * -1
                                        If DistanceY < 0 Then DistanceY = DistanceY * -1

                                        ' Are they in range?  if so GET'M!
                                        If DistanceX <= n And DistanceY <= n Then
                                            If GetPetBehaviour(PlayerIndex) = PET_ATTACK_BEHAVIOUR_ATTACKONSIGHT Then
                                                TempPlayer(PlayerIndex).PetTargetType = TargetType.Npc ' npc
                                                TempPlayer(PlayerIndex).PetTarget = i
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If

                        target_verify = False

                        ' // This is used for Pet walking/targetting //

                        ' Make sure theres a npc with the map
                        If TempPlayer(PlayerIndex).PetStunDuration > 0 Then
                            ' check if we can unstun them
                            If GetTickCount() > TempPlayer(PlayerIndex).PetStunTimer + (TempPlayer(PlayerIndex).PetStunDuration * 1000) Then
                                TempPlayer(PlayerIndex).PetStunDuration = 0
                                TempPlayer(PlayerIndex).PetStunTimer = 0
                            End If
                        Else
                            Target = TempPlayer(PlayerIndex).PetTarget
                            TargetTypes = TempPlayer(PlayerIndex).PetTargetType

                            ' Check to see if its time for the npc to walk
                            If GetPetBehaviour(PlayerIndex) <> PET_ATTACK_BEHAVIOUR_DONOTHING Then

                                If TargetTypes = TargetType.Player Then ' player
                                    ' Check to see if we are following a player or not
                                    If Target > 0 Then

                                        ' Check if the player is even playing, if so follow'm
                                        If IsPlaying(Target) And GetPlayerMap(Target) = MapNum Then
                                            If Target <> PlayerIndex Then
                                                DidWalk = False
                                                target_verify = True
                                                TargetY = GetPlayerY(Target)
                                                TargetX = GetPlayerX(Target)
                                            End If
                                        Else
                                            TempPlayer(PlayerIndex).PetTargetType = TargetType.None ' clear
                                            TempPlayer(PlayerIndex).PetTarget = 0
                                        End If
                                    End If
                                ElseIf TargetTypes = TargetType.Npc Then 'npc
                                    If Target > 0 Then
                                        If MapNpc(MapNum).Npc(Target).Num > 0 Then
                                            DidWalk = False
                                            target_verify = True
                                            TargetY = MapNpc(MapNum).Npc(Target).Y
                                            TargetX = MapNpc(MapNum).Npc(Target).X
                                        Else
                                            TempPlayer(PlayerIndex).PetTargetType = TargetType.None ' clear
                                            TempPlayer(PlayerIndex).PetTarget = 0
                                        End If
                                    End If
                                ElseIf TargetTypes = TargetType.Pet Then 'other pet
                                    If Target > 0 Then
                                        If IsPlaying(Target) And GetPlayerMap(Target) = MapNum And PetAlive(Target) Then
                                            DidWalk = False
                                            target_verify = True
                                            TargetY = GetPetY(Target)
                                            TargetX = GetPetX(Target)
                                        Else
                                            TempPlayer(PlayerIndex).PetTargetType = TargetType.None ' clear
                                            TempPlayer(PlayerIndex).PetTarget = 0
                                        End If
                                    End If
                                End If
                            End If

                            If target_verify Then
                                DidWalk = False

                                If IsOneBlockAway(GetPetX(PlayerIndex), GetPetY(PlayerIndex), TargetX, TargetY) Then
                                    If GetPetX(PlayerIndex) < TargetX Then
                                        PetDir(PlayerIndex, Direction.Right)
                                        DidWalk = True
                                    ElseIf GetPetX(PlayerIndex) > TargetX Then
                                        PetDir(PlayerIndex, Direction.Left)
                                        DidWalk = True
                                    ElseIf GetPetY(PlayerIndex) < TargetY Then
                                        PetDir(PlayerIndex, Direction.Up)
                                        DidWalk = True
                                    ElseIf GetPetY(PlayerIndex) > TargetY Then
                                        PetDir(PlayerIndex, Direction.Down)
                                        DidWalk = True
                                    End If

                                Else
                                    DidWalk = PetTryWalk(PlayerIndex, TargetX, TargetY)
                                End If

                            ElseIf TempPlayer(PlayerIndex).PetBehavior = PET_BEHAVIOUR_GOTO And target_verify = False Then

                                If GetPetX(PlayerIndex) = TempPlayer(PlayerIndex).GoToX And GetPetY(PlayerIndex) = TempPlayer(PlayerIndex).GoToY Then
                                    'Unblock these for the random turning
                                    'i = Int(Rnd * 4)
                                    'Call PetDir(x, i)
                                Else
                                    DidWalk = False
                                    TargetX = TempPlayer(PlayerIndex).GoToX
                                    TargetY = TempPlayer(PlayerIndex).GoToY
                                    DidWalk = PetTryWalk(PlayerIndex, TargetX, TargetY)

                                    If DidWalk = False Then
                                        tmpdir = Int(Rnd() * 4)

                                        If tmpdir = 1 Then
                                            tmpdir = Int(Rnd() * 4)
                                            If CanPetMove(PlayerIndex, MapNum, tmpdir) Then
                                                PetMove(PlayerIndex, MapNum, tmpdir, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If

                            ElseIf TempPlayer(PlayerIndex).PetBehavior = PET_BEHAVIOUR_FOLLOW Then

                                If IsPetByPlayer(PlayerIndex) Then
                                    'Unblock these to enable random turning
                                    'i = Int(Rnd * 4)
                                    'Call PetDir(x, i)
                                Else
                                    DidWalk = False
                                    TargetX = GetPlayerX(PlayerIndex)
                                    TargetY = GetPlayerY(PlayerIndex)
                                    DidWalk = PetTryWalk(PlayerIndex, TargetX, TargetY)

                                    If DidWalk = False Then
                                        tmpdir = Int(Rnd() * 4)
                                        If tmpdir = 1 Then
                                            tmpdir = Int(Rnd() * 4)
                                            If CanPetMove(PlayerIndex, MapNum, tmpdir) Then
                                                PetMove(PlayerIndex, MapNum, tmpdir, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                        ' // This is used for pets to attack targets //

                        ' Make sure theres a npc with the map
                        Target = TempPlayer(PlayerIndex).PetTarget
                        TargetTypes = TempPlayer(PlayerIndex).PetTargetType

                        ' Check if the pet can attack the targeted player
                        If Target > 0 Then
                            If TargetTypes = TargetType.Player Then ' player
                                ' Is the target playing and on the same map?
                                If IsPlaying(Target) And GetPlayerMap(Target) = MapNum Then
                                    If PlayerIndex <> Target Then TryPetAttackPlayer(PlayerIndex, Target)
                                Else
                                    ' Player left map or game, set target to 0
                                    TempPlayer(PlayerIndex).PetTarget = 0
                                    TempPlayer(PlayerIndex).PetTargetType = TargetType.None ' clear

                                End If
                            ElseIf TargetTypes = TargetType.Npc Then 'npc
                                If MapNpc(GetPlayerMap(PlayerIndex)).Npc(TempPlayer(PlayerIndex).PetTarget).Num > 0 Then
                                    TryPetAttackNpc(PlayerIndex, TempPlayer(PlayerIndex).PetTarget)
                                Else
                                    ' Player left map or game, set target to 0
                                    TempPlayer(PlayerIndex).PetTarget = 0
                                    TempPlayer(PlayerIndex).PetTargetType = TargetType.None ' clear
                                End If
                            ElseIf TargetTypes = TargetType.Pet Then 'pet
                                ' Is the target playing and on the same map? And is pet alive??
                                If IsPlaying(Target) And GetPlayerMap(Target) = MapNum And PetAlive(Target) Then
                                    TryPetAttackPet(PlayerIndex, Target)
                                Else
                                    ' Player left map or game, set target to 0
                                    TempPlayer(PlayerIndex).PetTarget = 0
                                    TempPlayer(PlayerIndex).PetTargetType = TargetType.None ' clear
                                End If
                            End If
                        End If

                        ' ////////////////////////////////////////////
                        ' // This is used for regenerating Pet's HP //
                        ' ////////////////////////////////////////////
                        ' Check to see if we want to regen some of the npc's hp
                        If Not TempPlayer(PlayerIndex).PetstopRegen Then
                            If PetAlive(PlayerIndex) And TickCount > GivePetHPTimer + 10000 Then
                                If GetPetVital(PlayerIndex, Vitals.HP) > 0 Then
                                    SetPetVital(PlayerIndex, Vitals.HP, GetPetVital(PlayerIndex, Vitals.HP) + GetPetVitalRegen(PlayerIndex, Vitals.HP))
                                    SetPetVital(PlayerIndex, Vitals.MP, GetPetVital(PlayerIndex, Vitals.MP) + GetPetVitalRegen(PlayerIndex, Vitals.MP))

                                    ' Check if they have more then they should and if so just set it to max
                                    If GetPetVital(PlayerIndex, Vitals.HP) > GetPetMaxVital(PlayerIndex, Vitals.HP) Then
                                        SetPetVital(PlayerIndex, Vitals.HP, GetPetMaxVital(PlayerIndex, Vitals.HP))
                                    End If

                                    If GetPetVital(PlayerIndex, Vitals.MP) > GetPetMaxVital(PlayerIndex, Vitals.MP) Then
                                        SetPetVital(PlayerIndex, Vitals.MP, GetPetMaxVital(PlayerIndex, Vitals.MP))
                                    End If

                                    SendPetVital(PlayerIndex, Vitals.HP)
                                    SendPetVital(PlayerIndex, Vitals.MP)
                                End If
                            End If
                        End If
                    End If
                End If
                DoEvents()
            Next
            DoEvents()
        Next

        ' Make sure we reset the timer for npc hp regeneration
        If GetTickCount() > GivePetHPTimer + 10000 Then
            GivePetHPTimer = GetTickCount()
        End If
    End Sub

    Sub SummonPet(ByVal Index As Integer)
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = 1
        PlayerMsg(Index, "You summoned your " & Trim$(GetPetName(Index)) & "!", ColorType.BrightGreen)
        SendUpdatePlayerPet(Index, False)
    End Sub

    Sub ReCallPet(ByVal Index As Integer)
        PlayerMsg(Index, "You recalled your " & Trim$(GetPetName(Index)) & "!", ColorType.BrightGreen)
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = 0
        SendUpdatePlayerPet(Index, False)
    End Sub

    Sub ReleasePet(ByVal Index As Integer)
        Dim i As Integer

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = 0
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
        TempPlayer(Index).GoToX = -1
        TempPlayer(Index).GoToY = -1

        For i = 1 To 4
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Skill(i) = 0
        Next

        For i = 1 To Stats.Count - 1
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i) = 0
        Next

        SendUpdatePlayerPet(Index, False)

        SavePlayer(Index)

        PlayerMsg(Index, "You released your pet!", ColorType.BrightGreen)

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

    Sub AdoptPet(ByVal Index As Integer, ByVal PetNum As Integer)

        If GetPetNum(Index) = 0 Then
            PlayerMsg(Index, "You have adopted a " & Trim$(Pet(PetNum).Name), ColorType.BrightGreen)
        Else
            PlayerMsg(Index, "You allready have a " & Trim$(Pet(PetNum).Name) & ", release your old pet first!", ColorType.BrightGreen)
            Exit Sub
        End If

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num = PetNum

        For i = 1 To 4
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Skill(i) = Pet(PetNum).Skill(i)
        Next

        If Pet(PetNum).StatType = 0 Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = GetPlayerMaxVital(Index, Vitals.HP)
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = GetPlayerMaxVital(Index, Vitals.MP)
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = GetPlayerLevel(Index)

            For i = 1 To Stats.Count - 1
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i) = Player(Index).Character(TempPlayer(Index).CurChar).Stat(i)
            Next

            Player(Index).Character(TempPlayer(Index).CurChar).Pet.AdoptiveStats = 1
        Else
            For i = 1 To Stats.Count - 1
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.stat(i) = Pet(PetNum).stat(i)
            Next

            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = Pet(PetNum).Level
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.AdoptiveStats = 0
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = GetPetMaxVital(Index, Vitals.HP)
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = GetPetMaxVital(Index, Vitals.MP)
        End If

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.x = GetPlayerX(Index)
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.y = GetPlayerY(Index)

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = 1
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points = 0
        Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp = 0

        Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = PET_ATTACK_BEHAVIOUR_GUARD 'By default it will guard but this can be changed

        SavePlayer(Index)

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
                SetPetY(Index, GetPetY(Index) - 1)

            Case Direction.Down
                SetPetY(Index, GetPetY(Index) + 1)

            Case Direction.Left
                SetPetX(Index, GetPetX(Index) - 1)

            Case Direction.Right
                SetPetX(Index, GetPetX(Index) + 1)
        End Select

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPetMove)
        Buffer.WriteInteger(Index)
        Buffer.WriteInteger(GetPetX(Index))
        Buffer.WriteInteger(GetPetY(Index))
        Buffer.WriteInteger(GetPetDir(Index))
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

        x = GetPetX(Index)
        y = GetPetY(Index)

        If x < 0 Or x > Map(MapNum).MaxX Then Exit Function
        If y < 0 Or y > Map(MapNum).MaxY Then Exit Function

        CanPetMove = True

        If TempPlayer(Index).PetskillBuffer.Skill > 0 Then
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
                    For i = 1 To GetTotalPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = GetPetX(Index) + 1) And (GetPlayerY(i) = GetPetY(Index) - 1) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) And (GetPlayerMap(i) = MapNum) And (GetPetX(i) = GetPetX(Index)) And (GetPetY(i) = GetPetY(Index) - 1) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).X = GetPetX(Index)) And (MapNpc(MapNum).Npc(i).Y = GetPetY(Index) - 1) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If IsDirBlocked(Map(MapNum).Tile(GetPetX(Index), GetPetY(Index)).DirBlock, Direction.Up + 1) Then
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

                    For i = 1 To GetTotalPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = GetPetX(Index)) And (GetPlayerY(i) = GetPetY(Index) + 1) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) And (GetPlayerMap(i) = MapNum) And (GetPetX(i) = GetPetX(Index)) And (GetPetY(i) = GetPetY(Index) + 1) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).X = GetPetX(Index)) And (MapNpc(MapNum).Npc(i).Y = GetPetY(Index) + 1) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If IsDirBlocked(Map(MapNum).Tile(GetPetX(Index), GetPetY(Index)).DirBlock, Direction.Down + 1) Then
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

                    For i = 1 To GetTotalPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = GetPetX(Index) - 1) And (GetPlayerY(i) = GetPetY(Index)) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) And (GetPlayerMap(i) = MapNum) And (GetPetX(i) = GetPetX(Index) - 1) And (GetPetY(i) = GetPetY(Index)) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).X = GetPetX(Index) - 1) And (MapNpc(MapNum).Npc(i).Y = GetPetY(Index)) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If IsDirBlocked(Map(MapNum).Tile(GetPetX(Index), GetPetY(Index)).DirBlock, Direction.Left + 1) Then
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

                    For i = 1 To GetTotalPlayersOnline()
                        If IsPlaying(i) Then
                            If (GetPlayerMap(i) = MapNum) And (GetPlayerX(i) = GetPetX(Index) + 1) And (GetPlayerY(i) = GetPetY(Index)) Then
                                CanPetMove = False
                                Exit Function
                            ElseIf PetAlive(i) And (GetPlayerMap(i) = MapNum) And (GetPetX(i) = GetPetX(Index) + 1) And (GetPetY(i) = GetPetY(Index)) Then
                                CanPetMove = False
                                Exit Function
                            End If
                        End If
                    Next

                    ' Check to make sure that there is not another npc in the way
                    For i = 1 To MAX_MAP_NPCS
                        If (MapNpc(MapNum).Npc(i).Num > 0) And (MapNpc(MapNum).Npc(i).X = GetPetX(Index) + 1) And (MapNpc(MapNum).Npc(i).Y = GetPetY(Index)) Then
                            CanPetMove = False
                            Exit Function
                        End If
                    Next

                    ' Directional blocking
                    If IsDirBlocked(Map(MapNum).Tile(GetPetX(Index), GetPetY(Index)).DirBlock, Direction.Right + 1) Then
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

        If TempPlayer(Index).PetskillBuffer.Skill > 0 Then Exit Sub

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

        If IsOneBlockAway(TargetX, TargetY, GetPetX(Index), GetPetY(Index)) = False Then

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
                    If GetPetX(x) - 1 = TargetX And GetPetY(x) = TargetY Then

                        If GetPetDir(x) <> Direction.Left Then
                            PetDir(x, Direction.Left)
                        End If

                        didwalk = True
                    End If

                    If GetPetX(x) + 1 = TargetX And GetPetY(x) = TargetY Then

                        If GetPetDir(x) <> Direction.Right Then
                            PetDir(x, Direction.Right)
                        End If

                        didwalk = True
                    End If

                    If GetPetX(x) = TargetX And GetPetY(x) - 1 = TargetY Then

                        If GetPetDir(x) <> Direction.Up Then
                            PetDir(x, Direction.Up)
                        End If

                        didwalk = True
                    End If

                    If GetPetX(x) = TargetX And GetPetY(x) + 1 = TargetY Then

                        If GetPetDir(x) <> Direction.Down Then
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
            If GetPetX(Index) > TempPlayer(Index).GoToX Then
                If CanPetMove(x, MapNum, Direction.Left) Then
                    PetMove(x, MapNum, Direction.Left, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Left)
                    didwalk = True
                End If

            ElseIf GetPetX(Index) < TempPlayer(Index).GoToX Then

                If CanPetMove(x, MapNum, Direction.Right) Then
                    PetMove(x, MapNum, Direction.Right, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Right)
                    didwalk = True
                End If

            ElseIf GetPetY(Index) > TempPlayer(Index).GoToY Then

                If CanPetMove(x, MapNum, Direction.Up) Then
                    PetMove(x, MapNum, Direction.Up, MovementType.Walking)
                    didwalk = True
                Else
                    PetDir(x, Direction.Up)
                    didwalk = True
                End If

            ElseIf GetPetY(Index) < TempPlayer(Index).GoToY Then

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
        sX = GetPetX(Index)
        sY = GetPetY(Index)

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
                Next
            Next

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

    Function GetPetDamage(ByVal Index As Integer) As Integer
        GetPetDamage = 0

        ' Check for subscript out of range
        If IsPlaying(Index) = False Or Index <= 0 Or Index > MAX_PLAYERS Or Not PetAlive(Index) Then
            Exit Function
        End If

        GetPetDamage = (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Stat(Stats.Strength) * 2) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 3) + Random(0, 20)

    End Function

    Public Function CanPetCrit(ByVal Index As Integer) As Boolean
        Dim rate As Integer
        Dim rndNum As Integer

        If Not PetAlive(Index) Then Exit Function

        CanPetCrit = False

        rate = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Stat(Stats.Luck) / 3
        rndNum = Random(1, 100)

        If rndNum <= rate Then CanPetCrit = True

    End Function
#End Region

#Region "Pet > Npc"
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
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (MapNpc(MapNum).Npc(MapNpcNum).X * 32), (MapNpc(MapNum).Npc(MapNpcNum).Y * 32))
                Exit Sub
            End If

            If CanNpcParry(npcnum) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (MapNpc(MapNum).Npc(MapNpcNum).X * 32), (MapNpc(MapNum).Npc(MapNpcNum).Y * 32))
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

    Public Function CanPetAttackNpc(ByVal Attacker As Integer, ByVal mapnpcnum As Integer, Optional ByVal IsSpell As Boolean = False) As Boolean
        Dim MapNum As Integer
        Dim npcnum As Integer
        Dim NpcX As Integer
        Dim NpcY As Integer
        Dim attackspeed As Integer

        If IsPlaying(Attacker) = False Or mapnpcnum <= 0 Or mapnpcnum > MAX_MAP_NPCS Or Not PetAlive(Attacker) Then
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

            If TempPlayer(Attacker).PetskillBuffer.Skill > 0 And IsSpell = False Then Exit Function

            ' exit out early
            If IsSpell AndAlso npcnum > 0 Then
                If Npc(npcnum).Behaviour <> NpcBehavior.Friendly And Npc(npcnum).Behaviour <> NpcBehavior.ShopKeeper Then
                    CanPetAttackNpc = True
                    Exit Function
                End If
            End If

            attackspeed = 1000 'Pet cannot wield a weapon

            If npcnum > 0 And GetTickCount() > TempPlayer(Attacker).PetAttackTimer + attackspeed Then

                ' Check if at same coordinates
                Select Case GetPetDir(Attacker)

                    Case Direction.Up
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).X
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).Y + 1

                    Case Direction.Down
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).X
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).Y - 1

                    Case Direction.Left
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).X + 1
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).Y

                    Case Direction.Right
                        NpcX = MapNpc(MapNum).Npc(mapnpcnum).X - 1
                        NpcY = MapNpc(MapNum).Npc(mapnpcnum).Y

                End Select

                If NpcX = GetPetX(Attacker) AndAlso NpcY = GetPetY(Attacker) Then
                    If Npc(npcnum).Behaviour <> NpcBehavior.Friendly And Npc(npcnum).Behaviour <> NpcBehavior.ShopKeeper Then
                        CanPetAttackNpc = True
                    Else
                        CanPetAttackNpc = False
                    End If
                End If
            End If
        End If

    End Function

    Public Sub PetAttackNpc(ByVal Attacker As Integer, ByVal mapnpcnum As Integer, ByVal Damage As Integer, Optional ByVal Skillnum As Integer = 0, Optional ByVal overTime As Boolean = False)
        Dim Name As String, Exp As Integer
        Dim n As Integer, i As Integer
        Dim MapNum As Integer, npcnum As Integer

        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or mapnpcnum <= 0 Or mapnpcnum > MAX_MAP_NPCS Or Damage < 0 Or Not PetAlive(Attacker) Then
            Exit Sub
        End If

        MapNum = GetPlayerMap(Attacker)
        npcnum = MapNpc(MapNum).Npc(mapnpcnum).Num
        Name = Trim$(Npc(npcnum).Name)

        If Skillnum = 0 Then
            ' Send this packet so they can see the pet attacking
            SendPetAttack(Attacker, MapNum)
        End If

        ' Check for weapon
        n = 0 'no weapon, pet :P

        ' set the regen timer
        TempPlayer(Attacker).PetstopRegen = True
        TempPlayer(Attacker).PetstopRegenTimer = GetTickCount()

        If Damage >= MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) Then

            SendActionMsg(GetPlayerMap(Attacker), "-" & MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP), ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(mapnpcnum).X * 32), (MapNpc(MapNum).Npc(mapnpcnum).Y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(mapnpcnum).X, MapNpc(MapNum).Npc(mapnpcnum).Y)

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

            'For n = 1 To 20
            '    If MapNpc(MapNum).Npc(mapnpcnum).Num > 0 Then
            '        'SpawnItem(MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num, MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value, MapNum, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y)
            '        'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value = 0
            '        'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num = 0
            '    End If
            'Next

            ' Now set HP to 0 so we know to actually kill them in the server loop (this prevents subscript out of range)
            MapNpc(MapNum).Npc(mapnpcnum).Num = 0
            MapNpc(MapNum).Npc(mapnpcnum).SpawnWait = GetTickCount()
            MapNpc(MapNum).Npc(mapnpcnum).Vital(Vitals.HP) = 0
            MapNpc(MapNum).Npc(mapnpcnum).TargetType = 0
            MapNpc(MapNum).Npc(mapnpcnum).Target = 0

            ' clear DoTs and HoTs
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
            SendNpcDead(MapNum, mapnpcnum)

            'Loop through entire map and purge NPC from targets
            For i = 1 To MAX_PLAYERS

                If IsPlaying(i) Then
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
            SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNpc(MapNum).Npc(mapnpcnum).X * 32), (MapNpc(MapNum).Npc(mapnpcnum).Y * 32))
            SendBlood(GetPlayerMap(Attacker), MapNpc(MapNum).Npc(mapnpcnum).X, MapNpc(MapNum).Npc(mapnpcnum).Y)

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
            MapNpc(MapNum).Npc(mapnpcnum).StopRegen = True
            MapNpc(MapNum).Npc(mapnpcnum).StopRegenTimer = GetTickCount()

            ' if stunning spell, stun the npc
            If Skillnum > 0 Then
                If Skill(Skillnum).StunDuration > 0 Then StunNPC(mapnpcnum, MapNum, Skillnum)
                ' DoT
                If Skill(Skillnum).Duration > 0 Then
                    'AddDoT_Npc(MapNum, mapnpcnum, Skillnum, Attacker, 3)
                End If
            End If

            SendMapNpcVitals(MapNum, mapnpcnum)
        End If

        If Skillnum = 0 Then
            ' Reset attack timer
            TempPlayer(Attacker).PetAttackTimer = GetTickCount()
        End If

    End Sub

#End Region

#Region "Npc > Pet"
    Public Sub TryNpcAttackPet(ByVal MapNpcNum As Integer, ByVal Index As Integer)

        Dim MapNum As Integer, npcnum As Integer, Damage As Integer

        ' Can the npc attack the pet?

        If CanNpcAttackPet(MapNpcNum, Index) Then
            MapNum = GetPlayerMap(Index)
            npcnum = MapNpc(MapNum).Npc(MapNpcNum).Num

            ' check if Pet can avoid the attack
            If CanPetDodge(Index) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, ActionMsgType.Scroll, (GetPetX(Index) * 32), (GetPetY(Index) * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetNpcDamage(npcnum)

            ' take away armour
            Damage = Damage - ((GetPetStat(Index, Stats.Endurance) * 2) + (GetPetLevel(Index) * 2))

            ' * 1.5 if crit hit
            If CanNpcCrit(npcnum) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, ActionMsgType.Scroll, (MapNpc(MapNum).Npc(MapNpcNum).X * 32), (MapNpc(MapNum).Npc(MapNpcNum).Y * 32))
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

        If MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Not IsPlaying(Index) Or Not PetAlive(Index) Then
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
        If IsPlaying(Index) And PetAlive(Index) Then
            If npcnum > 0 Then

                ' Check if at same coordinates
                If (GetPetY(Index) + 1 = MapNpc(MapNum).Npc(MapNpcNum).Y) And (GetPetX(Index) = MapNpc(MapNum).Npc(MapNpcNum).X) Then
                    CanNpcAttackPet = True
                Else

                    If (GetPetY(Index) - 1 = MapNpc(MapNum).Npc(MapNpcNum).Y) And (GetPetX(Index) = MapNpc(MapNum).Npc(MapNpcNum).X) Then
                        CanNpcAttackPet = True
                    Else

                        If (GetPetY(Index) = MapNpc(MapNum).Npc(MapNpcNum).Y) And (GetPetX(Index) + 1 = MapNpc(MapNum).Npc(MapNpcNum).X) Then
                            CanNpcAttackPet = True
                        Else

                            If (GetPetY(Index) = MapNpc(MapNum).Npc(MapNpcNum).Y) And (GetPetX(Index) - 1 = MapNpc(MapNum).Npc(MapNpcNum).X) Then
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

        ' Check for subscript out of range
        If mapnpcnum <= 0 Or mapnpcnum > MAX_MAP_NPCS Or IsPlaying(Victim) = False Or Not PetAlive(Victim) Then
            Exit Sub
        End If

        ' Check for subscript out of range
        If MapNpc(GetPlayerMap(Victim)).Npc(mapnpcnum).Num <= 0 Then Exit Sub

        MapNum = GetPlayerMap(Victim)
        Name = Trim$(Npc(MapNpc(MapNum).Npc(mapnpcnum).Num).Name)

        ' Send this packet so they can see the npc attacking
        SendNpcAttack(Victim, mapnpcnum)

        If Damage <= 0 Then Exit Sub

        ' set the regen timer
        MapNpc(MapNum).Npc(mapnpcnum).StopRegen = True
        MapNpc(MapNum).Npc(mapnpcnum).StopRegenTimer = GetTickCount()

        If Damage >= GetPetVital(Victim, Vitals.HP) Then
            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & GetPetVital(Victim, Vitals.HP), ColorType.BrightRed, ActionMsgType.Scroll, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))

            ' kill pet
            PlayerMsg(Victim, "Your " & Trim$(GetPetName(Victim)) & " was killed by a " & Trim$(Npc(MapNpc(MapNum).Npc(mapnpcnum).Num).Name) & ".", ColorType.BrightRed)
            RecallPet(Victim)

            ' Now that pet is dead, go for owner
            MapNpc(MapNum).Npc(mapnpcnum).Target = Victim
            MapNpc(MapNum).Npc(mapnpcnum).TargetType = TargetType.Player
        Else
            ' Pet not dead, just do the damage
            SetPetVital(Victim, Vitals.HP, GetPetVital(Victim, Vitals.HP) - Damage)
            SendPetVital(Victim, Vitals.HP)
            SendAnimation(MapNum, Npc(MapNpc(GetPlayerMap(Victim)).Npc(mapnpcnum).Num).Animation, 0, 0, TargetType.Pet, Victim)

            ' Say damage
            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, ActionMsgType.Scroll, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))
            SendBlood(GetPlayerMap(Victim), GetPetX(Victim), GetPetY(Victim))

            ' set the regen timer
            TempPlayer(Victim).PetstopRegen = True
            TempPlayer(Victim).PetstopRegenTimer = GetTickCount()

            'pet gets attacked, lets set this target
            TempPlayer(Victim).PetTarget = mapnpcnum
            TempPlayer(Victim).PetTargetType = TargetType.Npc
        End If

    End Sub
#End Region


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

        If TempPlayer(Attacker).PetskillBuffer.Skill > 0 And IsSkill = False Then Exit Function

        If Not IsSkill Then
            ' Check if at same coordinates
            Select Case GetPetDir(Attacker)
                Case Direction.Up
                    If Not (GetPlayerY(Victim) + 1 = GetPetY(Attacker)) And (GetPlayerX(Victim) = GetPetX(Attacker)) Then Exit Function

                Case Direction.Down
                    If Not (GetPlayerY(Victim) - 1 = GetPetY(Attacker)) And (GetPlayerX(Victim) = GetPetX(Attacker)) Then Exit Function

                Case Direction.Left
                    If Not (GetPlayerY(Victim) = GetPetY(Attacker)) And (GetPlayerX(Victim) + 1 = GetPetX(Attacker)) Then Exit Function

                Case Direction.Right
                    If Not (GetPlayerY(Victim) = GetPetY(Attacker)) And (GetPlayerX(Victim) - 1 = GetPetX(Attacker)) Then Exit Function

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
            PlayerMsg(Attacker, "Admins cannot attack other players.", ColorType.Yellow)
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
                Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.HP))

            Case Vitals.MP
                Buffer.WriteInteger(GetPetMaxVital(Index, Vitals.MP))
                Buffer.WriteInteger(GetPetVital(Index, Vitals.MP))
        End Select

        SendDataToMap(GetPlayerMap(Index), Buffer.ToArray)

        Buffer = Nothing

    End Sub

    Public Sub BufferPetSkill(ByVal Index As Integer, ByVal SkillSlot As Integer)
        Dim Skillnum As Integer, MPCost As Integer, LevelReq As Integer
        Dim MapNum As Integer, SkillCastType As Integer
        Dim AccessReq As Integer, Range As Integer, HasBuffered As Boolean
        Dim TargetTypes As Byte, Target As Integer

        ' Prevent subscript out of range

        If SkillSlot <= 0 Or SkillSlot > 4 Then Exit Sub

        Skillnum = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Skill(SkillSlot)
        MapNum = GetPlayerMap(Index)

        If Skillnum <= 0 Or Skillnum > MAX_SKILLS Then Exit Sub

        ' see if cooldown has finished
        If TempPlayer(Index).PetSkillCD(SkillSlot) > GetTickCount() Then
            PlayerMsg(Index, Trim$(GetPetName(Index)) & "'s Skill hasn't cooled down yet!", ColorType.BrightRed)
            Exit Sub
        End If

        MPCost = Skill(Skillnum).MpCost

        ' Check if they have enough MP
        If GetPetVital(Index, Vitals.MP) < MPCost Then
            PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " does not have enough mana!", ColorType.BrightRed)
            Exit Sub
        End If

        LevelReq = Skill(Skillnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > GetPetLevel(Index) Then
            PlayerMsg(Index, Trim$(GetPetName(Index)) & " must be level " & LevelReq & " to cast this skill.", ColorType.BrightRed)
            Exit Sub
        End If

        AccessReq = Skill(Skillnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(Index) Then
            PlayerMsg(Index, "You must be an administrator to cast this spell, even as a pet owner.", ColorType.BrightRed)
            Exit Sub
        End If

        ' find out what kind of spell it is! self cast, target or AOE
        If Skill(Skillnum).range > 0 Then

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

        TargetTypes = TempPlayer(Index).PetTargetType
        Target = TempPlayer(Index).PetTarget
        Range = Skill(Skillnum).range
        HasBuffered = False

        Select Case SkillCastType

            'PET
            Case 0, 1, SkillType.Pet ' self-cast & self-cast AOE
                HasBuffered = True

            Case 2, 3 ' targeted & targeted AOE

                ' check if have target
                If Not Target > 0 Then
                    If SkillCastType = SkillType.HealHp Or SkillCastType = SkillType.HealMp Then
                        Target = Index
                        TargetTypes = TargetType.Pet
                    Else
                        PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " does not have a target.", ColorType.Yellow)
                    End If
                End If

                If TargetTypes = TargetType.Player Then

                    ' if have target, check in range
                    If Not isInRange(Range, GetPetX(Index), GetPetY(Index), GetPlayerX(Target), GetPlayerY(Target)) Then
                        PlayerMsg(Index, "Target not in range of " & Trim$(GetPetName(Index)) & ".", ColorType.Yellow)
                    Else
                        ' go through spell types
                        If Skill(Skillnum).Type <> SkillType.DamageHp And Skill(Skillnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPetAttackPlayer(Index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If

                ElseIf TargetTypes = TargetType.Npc Then

                    ' if have target, check in range
                    If Not isInRange(Range, GetPetX(Index), GetPetY(Index), MapNpc(MapNum).Npc(Target).X, MapNpc(MapNum).Npc(Target).Y) Then
                        PlayerMsg(Index, "Target not in range of " & Trim$(GetPetName(Index)) & ".", ColorType.Yellow)
                        HasBuffered = False
                    Else
                        ' go through spell types
                        If Skill(Skillnum).Type <> SkillType.DamageHp And Skill(Skillnum).Type <> SkillType.DamageMp Then
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
                    If Not isInRange(Range, GetPetX(Index), GetPetY(Index), GetPetX(Target), GetPetY(Target)) Then
                        PlayerMsg(Index, "Target not in range of " & Trim$(GetPetName(Index)) & ".", ColorType.Yellow)
                        HasBuffered = False
                    Else
                        ' go through spell types
                        If Skill(Skillnum).Type <> SkillType.DamageHp And Skill(Skillnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPetAttackPet(Index, Target, Skillnum) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                End If
        End Select

        If HasBuffered Then
            SendAnimation(MapNum, Skill(Skillnum).CastAnim, 0, 0, TargetType.Pet, Index)
            SendActionMsg(MapNum, "Casting " & Trim$(Skill(Skillnum).Name) & "!", ColorType.BrightRed, ActionMsgType.Scroll, GetPetX(Index) * 32, GetPetY(Index) * 32)
            TempPlayer(Index).PetskillBuffer.Skill = SkillSlot
            TempPlayer(Index).PetskillBuffer.Timer = GetTickCount()
            TempPlayer(Index).PetskillBuffer.Target = Target
            TempPlayer(Index).PetskillBuffer.TargetTypes = TargetTypes
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

    Public Sub PetCastSkill(ByVal Index As Integer, ByVal Skillslot As Integer, ByVal Target As Integer, ByVal TargetTypes As Byte, Optional TakeMana As Boolean = True)
        Dim Skillnum As Integer, MPCost As Integer, LevelReq As Integer
        Dim MapNum As Integer, Vital As Integer, DidCast As Boolean
        Dim AccessReq As Integer, i As Integer
        Dim AoE As Integer, Range As Integer, VitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer
        Dim SkillCastType As Integer

        DidCast = False

        ' Prevent subscript out of range
        If Skillslot <= 0 Or Skillslot > 4 Then Exit Sub

        Skillnum = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Skill(Skillslot)
        MapNum = GetPlayerMap(Index)

        MPCost = Skill(Skillnum).MpCost

        ' Check if they have enough MP
        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana < MPCost Then
            PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " does not have enough mana!", ColorType.BrightRed)
            Exit Sub
        End If

        LevelReq = Skill(Skillnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level Then
            PlayerMsg(Index, Trim$(GetPetName(Index)) & " must be level " & LevelReq & " to cast this spell.", ColorType.BrightRed)
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
                        SkillPet_Effect(Vitals.HP, True, Index, Vital, Skillnum)
                        DidCast = True
                    Case SkillType.HealMp
                        SkillPet_Effect(Vitals.MP, True, Index, Vital, Skillnum)
                        DidCast = True
                End Select

            Case 1, 3 ' self-cast AOE & targetted AOE

                If SkillCastType = 1 Then
                    x = GetPetX(Index)
                    y = GetPetY(Index)
                ElseIf SkillCastType = 3 Then

                    If TargetTypes = 0 Then Exit Sub
                    If Target = 0 Then Exit Sub

                    If TargetTypes = TargetType.Player Then
                        x = GetPlayerX(Target)
                        y = GetPlayerY(Target)
                    ElseIf TargetTypes = TargetType.Npc Then
                        x = MapNpc(MapNum).Npc(Target).X
                        y = MapNpc(MapNum).Npc(Target).Y
                    ElseIf TargetTypes = TargetType.Pet Then
                        x = GetPetX(Target)
                        y = GetPetY(Target)
                    End If

                    If Not isInRange(Range, GetPetX(Index), GetPetY(Index), x, y) Then
                        PlayerMsg(Index, Trim$(GetPetName(Index)) & "'s target not in range.", ColorType.Yellow)
                        SendClearPetSpellBuffer(Index)
                    End If
                End If

                Select Case Skill(Skillnum).Type

                    Case SkillType.DamageHp
                        DidCast = True

                        For i = 1 To GetTotalPlayersOnline()
                            If IsPlaying(i) AndAlso i <> Index Then
                                If GetPlayerMap(i) = GetPlayerMap(Index) Then
                                    If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        If CanPetAttackPlayer(Index, i, True) And Index <> Target Then
                                            SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Player, i)
                                            PetAttackPlayer(Index, i, Vital, Skillnum)
                                        End If
                                    End If

                                    If PetAlive(i) Then
                                        If isInRange(AoE, x, y, GetPetX(i), GetPetY(i)) Then

                                            If CanPetAttackPet(Index, i, Skillnum) Then
                                                SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Pet, i)
                                                PetAttackPet(Index, i, Vital, Skillnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        For i = 1 To MAX_MAP_NPCS
                            If MapNpc(MapNum).Npc(i).Num > 0 AndAlso MapNpc(MapNum).Npc(i).Vital(Vitals.HP) > 0 Then
                                If isInRange(AoE, x, y, MapNpc(MapNum).Npc(i).X, MapNpc(MapNum).Npc(i).Y) Then
                                    If CanPetAttackNpc(Index, i, True) Then
                                        SendAnimation(MapNum, Skill(Skillnum).SkillAnim, 0, 0, TargetType.Npc, i)
                                        PetAttackNpc(Index, i, Vital, Skillnum)
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

                        For i = 1 To GetTotalPlayersOnline()
                            If IsPlaying(i) AndAlso GetPlayerMap(i) = GetPlayerMap(Index) Then
                                If isInRange(AoE, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                    SpellPlayer_Effect(VitalType, increment, i, Vital, Skillnum)
                                End If

                                If PetAlive(i) Then
                                    If isInRange(AoE, x, y, GetPetX(i), GetPetY(i)) Then
                                        SkillPet_Effect(VitalType, increment, i, Vital, Skillnum)
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
                    x = MapNpc(MapNum).Npc(Target).X
                    y = MapNpc(MapNum).Npc(Target).Y
                ElseIf TargetTypes = TargetType.Pet Then
                    x = GetPetX(Target)
                    y = GetPetY(Target)
                End If

                If Not isInRange(Range, GetPetX(Index), GetPetY(Index), x, y) Then
                    PlayerMsg(Index, "Target is not in range of your " & Trim$(GetPetName(Index)) & "!", ColorType.Yellow)
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
                                    SkillPet_Effect(VitalType, increment, Index, Vital, Skillnum)
                                Else
                                    SpellNpc_Effect(VitalType, increment, Target, Vital, Skillnum, MapNum)
                                End If
                            End If

                        ElseIf TargetTypes = TargetType.Pet Then

                            If Skill(Skillnum).Type = SkillType.DamageMp Then
                                If CanPetAttackPet(Index, Target, Skillnum) Then
                                    SkillPet_Effect(VitalType, increment, Target, Vital, Skillnum)
                                End If
                            Else
                                SkillPet_Effect(VitalType, increment, Target, Vital, Skillnum)
                                SendPetVital(Target, Vital)
                            End If
                        End If
                End Select

            Case 4 ' Projectile
                PetFireProjectile(Index, Skillnum)
                DidCast = True
        End Select

        If DidCast Then
            If TakeMana Then SetPetVital(Index, Vitals.MP, GetPetVital(Index, Vitals.MP) - MPCost)
            SendPetVital(Index, Vitals.MP)
            SendPetVital(Index, Vitals.HP)

            TempPlayer(Index).PetSkillCD(Skillslot) = GetTickCount() + (Skill(Skillnum).CdTime * 1000)

            SendActionMsg(MapNum, Trim$(Skill(Skillnum).Name) & "!", ColorType.BrightRed, ActionMsgType.Scroll, GetPetX(Index) * 32, GetPetY(Index) * 32)
        End If

    End Sub

    Public Sub SkillPet_Effect(ByVal Vital As Byte, ByVal increment As Boolean, ByVal Index As Integer, ByVal Damage As Integer, ByVal Skillnum As Integer)
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
            SendActionMsg(GetPlayerMap(Index), sSymbol & Damage, Colour, ActionMsgType.Scroll, GetPetX(Index) * 32, GetPetY(Index) * 32)

            ' send the sound
            'SendMapSound(Index, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, SoundEntity.seSpell, Skillnum)

            If increment Then
                SetPetVital(Index, Vitals.HP, GetPetVital(Index, Vitals.HP) + Damage)

                If Skill(Skillnum).Duration > 0 Then
                    AddHoT_Pet(Index, Skillnum)
                End If

            ElseIf Not increment Then
                If Vital = Vitals.HP Then
                    SetPetVital(Index, Vitals.HP, GetPetVital(Index, Vitals.HP) - Damage)
                ElseIf Vital = Vitals.MP Then
                    SetPetVital(Index, Vitals.MP, GetPetVital(Index, Vitals.MP) - Damage)
                End If
            End If
        End If

        If GetPetVital(Index, Vitals.HP) > GetPetMaxVital(Index, Vitals.HP) Then SetPetVital(Index, Vitals.HP, GetPetMaxVital(Index, Vitals.HP))

        If GetPetVital(Index, Vitals.MP) > GetPetMaxVital(Index, Vitals.MP) Then SetPetVital(Index, Vitals.MP, GetPetMaxVital(Index, Vitals.MP))

    End Sub

    Public Sub AddHoT_Pet(ByVal Index As Integer, ByVal Skillnum As Integer)
        Dim i As Integer

        For i = 1 To MAX_DOTS
            With TempPlayer(Index).PetHoT(i)

                If .Skill = Skillnum Then
                    .Timer = GetTickCount()
                    .StartTime = GetTickCount()
                    Exit Sub
                End If

                If .Used = False Then
                    .Skill = Skillnum
                    .Timer = GetTickCount()
                    .Used = True
                    .StartTime = GetTickCount()
                    Exit Sub
                End If
            End With
        Next

    End Sub

    Public Sub AddDoT_Pet(ByVal Index As Integer, ByVal Skillnum As Integer, ByVal Caster As Integer, AttackerType As Integer)
        Dim i As Integer

        If Not PetAlive(Index) Then Exit Sub

        For i = 1 To MAX_DOTS
            With TempPlayer(Index).PetDoT(i)
                If .Skill = Skillnum Then
                    .Timer = GetTickCount()
                    .Caster = Caster
                    .StartTime = GetTickCount()
                    .AttackerType = AttackerType
                    Exit Sub
                End If

                If .Used = False Then
                    .Skill = Skillnum
                    .Timer = GetTickCount()
                    .Caster = Caster
                    .Used = True
                    .StartTime = GetTickCount()
                    .AttackerType = AttackerType
                    Exit Sub
                End If
            End With
        Next

    End Sub

    Sub PetAttackPlayer(ByVal Attacker As Integer, ByVal Victim As Integer, ByVal Damage As Integer, Optional ByVal SkillNum As Integer = 0)
        Dim Exp As Integer, n As Integer, i As Integer

        ' Check for subscript out of range

        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Or PetAlive(Attacker) = False Then
            Exit Sub
        End If

        ' Check for weapon
        n = 0 'No Weapon, PET!

        If SkillNum = 0 Then
            ' Send this packet so they can see the pet attacking
            SendPetAttack(Attacker, Victim)
        End If

        ' set the regen timer
        TempPlayer(Attacker).PetstopRegen = True
        TempPlayer(Attacker).PetstopRegenTimer = GetTickCount()

        If Damage >= GetPlayerVital(Victim, Vitals.HP) Then
            SendActionMsg(GetPlayerMap(Victim), "-" & GetPlayerVital(Victim, Vitals.HP), ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))

            ' send the sound
            'If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

            ' Player is dead
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & GetPlayerName(Attacker) & "'s " & Trim$(GetPetName(Attacker)) & ".")

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

                        If Player(i).Character(TempPlayer(i).CurChar).Pet.Alive = 1 Then
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
            TempPlayer(Victim).StopRegen = True
            TempPlayer(Victim).StopRegenTimer = GetTickCount()

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

        If TempPlayer(Attacker).PetskillBuffer.Skill > 0 And IsSkill = False Then Exit Function

        If Not IsSkill Then

            ' Check if at same coordinates
            Select Case GetPetDir(Attacker)
                Case Direction.Up
                    If Not ((GetPetY(Victim) - 1 = GetPetY(Attacker)) And (GetPetX(Victim) = GetPetX(Attacker))) Then Exit Function

                Case Direction.Down
                    If Not ((GetPetY(Victim) + 1 = GetPetY(Attacker)) And (GetPetX(Victim) = GetPetX(Attacker))) Then Exit Function

                Case Direction.Left
                    If Not ((GetPetY(Victim) = GetPetY(Attacker)) And (GetPetX(Victim) + 1 = GetPetX(Attacker))) Then Exit Function

                Case Direction.Right
                    If Not ((GetPetY(Victim) = GetPetY(Attacker)) And (GetPetX(Victim) - 1 = GetPetX(Attacker))) Then Exit Function

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
        Dim Buffer As New ByteBuffer

        ' Check for subscript out of range

        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Or PetAlive(Attacker) = False Or PetAlive(Victim) = False Then
            Exit Sub
        End If

        ' Check for weapon
        n = 0 'No Weapon, PET!

        If Skillnum = 0 Then
            ' Send this packet so they can see the pet attacking
            SendPetAttack(Attacker, Victim)
        End If

        ' set the regen timer
        TempPlayer(Attacker).PetstopRegen = True
        TempPlayer(Attacker).PetstopRegenTimer = GetTickCount()

        If Damage >= GetPetVital(Victim, Vitals.HP) Then
            SendActionMsg(GetPlayerMap(Victim), "-" & GetPetVital(Victim, Vitals.HP), ColorType.BrightRed, ActionMsgType.Scroll, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            ' Player is dead
            GlobalMsg(GetPlayerName(Victim) & " has been killed by " & GetPlayerName(Attacker) & "'s " & Trim$(GetPetName(Attacker)) & ".")

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

                        If PetAlive(i) Then
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
            PlayerMsg(Victim, "Your " & Trim$(GetPetName(Victim)) & " was killed by " & Trim$(GetPlayerName(Attacker)) & "'s " & Trim$(GetPetName(Attacker)) & "!", ColorType.BrightRed)
            ReleasePet(Victim)
        Else
            ' Player not dead, just do the damage
            SetPetVital(Victim, Vitals.HP, GetPetVital(Victim, Vitals.HP) - Damage)
            SendPetVital(Victim, Vitals.HP)

            'Set pet to begin attacking the other pet if it isn't dead or dosent have another target
            If TempPlayer(Victim).PetTarget <= 0 And TempPlayer(Victim).PetBehavior <> PET_BEHAVIOUR_GOTO Then
                TempPlayer(Victim).PetTarget = Attacker
                TempPlayer(Victim).PetTargetType = TargetType.Pet
            End If

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))
            SendBlood(GetPlayerMap(Victim), GetPetX(Victim), GetPetY(Victim))

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

        If PetAlive(Index) Then
            If Skill(Skillnum).StunDuration > 0 Then
                ' set the values on index
                TempPlayer(Index).PetStunDuration = Skill(Skillnum).StunDuration
                TempPlayer(Index).PetStunTimer = GetTickCount()
                ' tell him he's stunned
                PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " has been stunned.", ColorType.Yellow)
            End If
        End If

    End Sub

    Public Sub HandleDoT_Pet(ByVal Index As Integer, ByVal dotNum As Integer)

        With TempPlayer(Index).PetDoT(dotNum)

            If .Used And .Skill > 0 Then
                ' time to tick?
                If GetTickCount() > .Timer + (Skill(.Skill).Interval * 1000) Then
                    If .AttackerType = TargetType.Pet Then
                        If CanPetAttackPet(.Caster, Index, .Skill) Then
                            PetAttackPet(.Caster, Index, Skill(.Skill).Vital)
                            SendPetVital(Index, Vitals.HP)
                            SendPetVital(Index, Vitals.MP)
                        End If
                    ElseIf .AttackerType = TargetType.Player Then
                        If CanPlayerAttackPet(.Caster, Index, .Skill) Then
                            PlayerAttackPet(.Caster, Index, Skill(.Skill).Vital)
                            SendPetVital(Index, Vitals.HP)
                            SendPetVital(Index, Vitals.MP)
                        End If
                    End If

                    .Timer = GetTickCount()

                    ' check if DoT is still active - if player died it'll have been purged
                    If .Used And .Skill > 0 Then
                        ' destroy DoT if finished
                        If GetTickCount() - .StartTime >= (Skill(.Skill).Duration * 1000) Then
                            .Used = False
                            .Skill = 0
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

            If .Used And .Skill > 0 Then
                ' time to tick?
                If GetTickCount() > .Timer + (Skill(.Skill).Interval * 1000) Then
                    SendActionMsg(GetPlayerMap(Index), "+" & Skill(.Skill).Vital, ColorType.BrightGreen, ActionMsgType.Scroll, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x * 32, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y * 32,)
                    SetPetVital(Index, Vitals.HP, GetPetVital(Index, Vitals.HP) + Skill(.Skill).Vital)

                    If GetPetVital(Index, Vitals.HP) > GetPetMaxVital(Index, Vitals.HP) Then SetPetVital(Index, Vitals.HP, GetPetMaxVital(Index, Vitals.HP))

                    If GetPetVital(Index, Vitals.MP) > GetPetMaxVital(Index, Vitals.MP) Then SetPetVital(Index, Vitals.MP, GetPetMaxVital(Index, Vitals.MP))

                    SendPetVital(Index, Vitals.HP)
                    SendPetVital(Index, Vitals.MP)
                    .Timer = GetTickCount()

                    ' check if DoT is still active - if player died it'll have been purged
                    If .Used And .Skill > 0 Then
                        ' destroy hoT if finished
                        If GetTickCount() - .StartTime >= (Skill(.Skill).Duration * 1000) Then
                            .Used = False
                            .Skill = 0
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

        If Not PetAlive(Index) Then Exit Sub

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
            Damage = Damage - Random(1, (GetPetStat(Index, Stats.Luck)) * 2)

            ' randomise for up to 10% lower than max hit
            Damage = Random(1, Damage)

            ' * 1.5 if crit hit
            If CanPetCrit(Index) Then
                Damage = Damage * 1.5
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (GetPetX(Index) * 32), (GetPetY(Index) * 32))
            End If

            If Damage > 0 Then
                PetAttackPlayer(Index, Victim, Damage)
            End If

        End If

    End Sub

    Public Function CanPetDodge(ByVal Index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        If Not PetAlive(Index) Then Exit Function

        CanPetDodge = False

        rate = GetPetStat(Index, Stats.Luck) / 4
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPetDodge = True
        End If

    End Function

    Public Function CanPetParry(ByVal Index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        If Not PetAlive(Index) Then Exit Function

        CanPetParry = False

        rate = GetPetStat(Index, Stats.Luck) / 6
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPetParry = True
        End If

    End Function

    Public Sub TryPetAttackPet(ByVal Index As Integer, Victim As Integer)
        Dim MapNum As Integer, blockAmount As Integer, Damage As Integer

        If GetPlayerMap(Index) <> GetPlayerMap(Victim) Then Exit Sub

        If Not PetAlive(Index) Or Not PetAlive(Victim) Then Exit Sub

        ' Can the npc attack the player?
        If CanPetAttackPet(Index, Victim) Then
            MapNum = GetPlayerMap(Index)

            ' check if Pet can avoid the attack
            If CanPetDodge(Victim) Then
                SendActionMsg(MapNum, "Dodge!", ColorType.Pink, 1, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))
                Exit Sub
            End If

            If CanPetParry(Victim) Then
                SendActionMsg(MapNum, "Parry!", ColorType.Pink, 1, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))
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
                SendActionMsg(MapNum, "Critical!", ColorType.BrightCyan, 1, (GetPetX(Index) * 32), (GetPetY(Index) * 32))
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

        If Not PetAlive(Victim) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = 1 Then Exit Function

        If IsSkill = False Then

            ' Check if at same coordinates
            Select Case GetPlayerDir(Attacker)

                Case Direction.Up
                    If Not ((GetPetY(Victim) + 1 = GetPlayerY(Attacker)) And (GetPetX(Victim) = GetPlayerX(Attacker))) Then Exit Function

                Case Direction.Down
                    If Not ((GetPetY(Victim) - 1 = GetPlayerY(Attacker)) And (GetPetX(Victim) = GetPlayerX(Attacker))) Then Exit Function

                Case Direction.Left
                    If Not ((GetPetY(Victim) = GetPlayerY(Attacker)) And (GetPetX(Victim) + 1 = GetPlayerX(Attacker))) Then Exit Function

                Case Direction.Right
                    If Not ((GetPetY(Victim) = GetPlayerY(Attacker)) And (GetPetX(Victim) - 1 = GetPlayerX(Attacker))) Then Exit Function

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
        If GetPetVital(Victim, Vitals.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Monitor Then
            PlayerMsg(Attacker, "Admins cannot attack other players.", ColorType.BrightRed)
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Monitor Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "s " & Trim$(GetPetName(Victim)) & "!", ColorType.BrightRed)
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

        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Or Not PetAlive(Victim) Then Exit Sub
        ' Check for weapon
        n = 0

        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            n = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        ' set the regen timer
        TempPlayer(Attacker).StopRegen = True
        TempPlayer(Attacker).StopRegenTimer = GetTickCount()

        If Damage >= GetPetVital(Victim, Vitals.HP) Then
            SendActionMsg(GetPlayerMap(Victim), "-" & GetPetVital(Victim, Vitals.HP), ColorType.BrightRed, 1, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))

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
            For i = 1 To GetTotalPlayersOnline()
                If IsPlaying(i) And IsConnected(i) AndAlso GetPlayerMap(i) = GetPlayerMap(Attacker) Then
                    If TempPlayer(i).Target = TargetType.Pet AndAlso TempPlayer(i).Target = Victim Then
                        TempPlayer(i).Target = 0
                        TempPlayer(i).TargetType = TargetType.None
                        SendTarget(i, 0, TargetType.None)
                    End If
                End If
            Next

            PlayerMsg(Victim, ("Your " & Trim$(GetPetName(Victim)) & " was killed by  " & Trim$(GetPlayerName(Attacker)) & "."), ColorType.BrightRed)
            RecallPet(Victim)
        Else
            ' Pet not dead, just do the damage
            SetPetVital(Victim, Vitals.HP, GetPetVital(Victim, Vitals.HP) - Damage)
            SendPetVital(Victim, Vitals.HP)

            'Set pet to begin attacking the other pet if it isn't dead or dosent have another target
            If TempPlayer(Victim).PetTarget <= 0 And TempPlayer(Victim).PetBehavior <> PET_BEHAVIOUR_GOTO Then
                TempPlayer(Victim).PetTarget = Attacker
                TempPlayer(Victim).PetTargetType = TargetType.Player
            End If

            ' send the sound
            'If Spellnum > 0 Then SendMapSound Victim, GetPetX(Victim), GetPety(Victim), SoundEntity.seSpell, Spellnum

            SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPetX(Victim) * 32), (GetPetY(Victim) * 32))
            SendBlood(GetPlayerMap(Victim), GetPetX(Victim), GetPetY(Victim))

            ' set the regen timer
            TempPlayer(Victim).PetstopRegen = True
            TempPlayer(Victim).PetstopRegenTimer = GetTickCount()

            'if a stunning spell, stun the player
            If Skillnum > 0 Then
                If Skill(Skillnum).StunDuration > 0 Then StunPet(Victim, Skillnum)

                ' DoT
                If Skill(Skillnum).Duration > 0 Then
                    AddDoT_Pet(Victim, Skillnum, Attacker, TargetType.Player)
                End If
            End If
        End If

        ' Reset attack timer
        TempPlayer(Attacker).AttackTimer = GetTickCount()

    End Sub

    Function IsPetByPlayer(ByVal Index As Integer) As Boolean
        Dim x As Integer, y As Integer, x1 As Integer, y1 As Integer

        If Index <= 0 Or Index > MAX_PLAYERS Or Not PetAlive(Index) Then Exit Function

        IsPetByPlayer = False

        x = GetPlayerX(Index)
        y = GetPlayerY(Index)
        x1 = GetPetX(Index)
        y1 = GetPetY(Index)

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

        If Index <= 0 Or Index > MAX_PLAYERS Or Not PetAlive(Index) Then
            GetPetVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case Vitals.HP
                i = (GetPlayerStat(Index, Stats.Spirit) * 0.8) + 6

            Case Vitals.MP
                i = (GetPlayerStat(Index, Stats.Spirit) / 4) + 12.5
        End Select

        GetPetVitalRegen = i

    End Function

    Public Sub TryPlayerAttackPet(ByVal Attacker As Integer, ByVal Victim As Integer)
        Dim blockAmount As Integer, MapNum As Integer
        Dim Damage As Integer

        Damage = 0

        If Not PetAlive(Victim) Then Exit Sub

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

    Sub CheckPetLevelUp(ByVal Index As Integer)
        Dim expRollover As Integer, level_count As Integer

        level_count = 0

        Do While GetPetExp(Index) >= GetPetNextLevel(Index)
            expRollover = GetPetExp(Index) - GetPetNextLevel(Index)

            ' can level up?
            If GetPetLevel(Index) < 99 And GetPetLevel(Index) < Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).MaxLevel Then
                SetPetLevel(Index, GetPetLevel(Index) + 1)
            End If

            SetPetPoints(Index, GetPetPoints(Index) + Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).LevelPnts)
            SetPetExp(Index, expRollover)
            level_count = level_count + 1
        Loop

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " has gained " & level_count & " level!", ColorType.BrightGreen)
            Else
                'plural
                PlayerMsg(Index, "Your " & Trim$(GetPetName(Index)) & " has gained " & level_count & " levels!", ColorType.BrightGreen)
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

#Region "Data Functions"
    Public Function PetAlive(ByVal Index As Integer) As Boolean
        PetAlive = False

        If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Alive = 1 Then
            PetAlive = True
        End If

    End Function

    Public Function GetPetName(ByVal Index As Integer) As String
        GetPetName = ""

        If PetAlive(Index) Then
            GetPetName = Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Name
        End If

    End Function

    Public Function GetPetNum(ByVal Index As Integer) As Integer
        GetPetNum = 0

        GetPetNum = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num

    End Function

    Public Function GetPetRange(ByVal Index As Integer) As Integer
        GetPetRange = 0

        If PetAlive(Index) Then
            GetPetRange = Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).Range
        End If

    End Function

    Public Function GetPetLevel(ByVal Index As Integer) As Integer
        GetPetLevel = 0

        If PetAlive(Index) Then
            GetPetLevel = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level
        End If

    End Function

    Public Sub SetPetLevel(ByVal Index As Integer, ByVal Newlvl As Integer)
        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = Newlvl
        End If
    End Sub

    Public Function GetPetX(ByVal Index As Integer) As Integer
        GetPetX = 0

        If PetAlive(Index) Then
            GetPetX = Player(Index).Character(TempPlayer(Index).CurChar).Pet.x
        End If

    End Function

    Public Sub SetPetX(ByVal Index As Integer, ByVal X As Integer)
        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.X = X
        End If
    End Sub

    Public Function GetPetY(ByVal Index As Integer) As Integer
        GetPetY = 0

        If PetAlive(Index) Then
            GetPetY = Player(Index).Character(TempPlayer(Index).CurChar).Pet.y
        End If

    End Function

    Public Sub SetPetY(ByVal Index As Integer, ByVal Y As Integer)
        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Y = Y
        End If
    End Sub

    Public Function GetPetDir(ByVal Index As Integer) As Integer
        GetPetDir = 0

        If PetAlive(Index) Then
            GetPetDir = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Dir
        End If

    End Function

    Public Function GetPetBehaviour(ByVal Index As Integer) As Integer
        GetPetBehaviour = 0

        If PetAlive(Index) Then
            GetPetBehaviour = Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour
        End If

    End Function

    Public Sub SetPetBehaviour(ByVal Index As Integer, ByVal Behaviour As Byte)
        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.AttackBehaviour = Behaviour
        End If
    End Sub

    Public Function GetPetStat(ByVal Index As Integer, ByVal Stat As Stats) As Integer
        GetPetStat = 0

        If PetAlive(Index) Then
            GetPetStat = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Stat(Stat)
        End If

    End Function

    Public Sub SetPetStat(ByVal Index As Integer, ByVal Stat As Stats, ByVal Amount As Integer)

        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Stat(Stat) = Amount
        End If

    End Sub

    Public Function GetPetPoints(ByVal Index As Integer) As Integer
        GetPetPoints = 0

        If PetAlive(Index) Then
            GetPetPoints = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points
        End If

    End Function

    Public Sub SetPetPoints(ByVal Index As Integer, ByVal Amount As Integer)

        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Points = Amount
        End If

    End Sub

    Public Function GetPetExp(ByVal Index As Integer) As Integer
        GetPetExp = 0

        If PetAlive(Index) Then
            GetPetExp = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp
        End If

    End Function

    Public Sub SetPetExp(ByVal Index As Integer, ByVal Amount As Integer)
        If PetAlive(Index) Then
            Player(Index).Character(TempPlayer(Index).CurChar).Pet.Exp = Amount
        End If
    End Sub

    Function GetPetVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer

        If Index > MAX_PLAYERS Then Exit Function

        Select Case Vital
            Case Vitals.HP
                GetPetVital = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health

            Case Vitals.MP
                GetPetVital = Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana
        End Select

    End Function

    Sub SetPetVital(ByVal Index As Integer, ByVal Vital As Vitals, ByVal Amount As Integer)

        If Index > MAX_PLAYERS Then Exit Sub

        Select Case Vital
            Case Vitals.HP
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.Health = Amount

            Case Vitals.MP
                Player(Index).Character(TempPlayer(Index).CurChar).Pet.Mana = Amount
        End Select

    End Sub

    Function GetPetMaxVital(ByVal Index As Integer, ByVal Vital As Vitals) As Integer

        If Index > MAX_PLAYERS Then Exit Function

        Select Case Vital
            Case Vitals.HP
                GetPetMaxVital = ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 4) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Stat(Stats.Endurance) * 10)) + 150

            Case Vitals.MP
                GetPetMaxVital = ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level * 4) + (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Stat(Stats.Spirit) / 2)) * 5 + 50
        End Select

    End Function

    Function GetPetNextLevel(ByVal Index As Integer) As Integer

        If PetAlive(Index) Then
            If Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level = Pet(Player(Index).Character(TempPlayer(Index).CurChar).Pet.Num).MaxLevel Then GetPetNextLevel = 0 : Exit Function
            GetPetNextLevel = (50 / 3) * ((Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1) ^ 3 - (6 * (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1) ^ 2) + 17 * (Player(Index).Character(TempPlayer(Index).CurChar).Pet.Level + 1) - 12)
        End If

    End Function
#End Region

End Module