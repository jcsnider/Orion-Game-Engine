Imports System.Drawing

Module ClientPets
#Region "Globals etc"
    Public Pet() As PetRec

    Public Const PetbarTop As Byte = 2
    Public Const PetbarLeft As Byte = 2
    Public Const PetbarOffsetX As Byte = 4
    Public Const MAX_PETBAR As Byte = 7
    Public Const PetHpBarWidth As Integer = 129
    Public Const PetMpBarWidth As Integer = 129

    Public PetSkillBuffer As Integer
    Public PetSkillBufferTimer As Integer
    Public PetSkillCD() As Integer

    Public ShowPetStats As Boolean

    'Pet Constants
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
        Dim Points As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Integer
        Dim MaxHp As Integer
        Dim MaxMP As Integer
        Dim Alive As Byte
        Dim AttackBehaviour As Integer
        Dim Exp As Integer
        Dim TNL As Integer

        'Client Use Only
        Dim XOffset As Integer
        Dim YOffset As Integer
        Dim Moving As Byte
        Dim Attacking As Byte
        Dim AttackTimer As Integer
        Dim Steps As Byte
        Dim Damage As Integer
    End Structure
#End Region

#Region "Database"
    Sub ClearPet(ByVal Index As Integer)

        Pet(Index).Name = ""

        ReDim Pet(Index).Stat(Stats.Count - 1)
        ReDim Pet(Index).Skill(4)
    End Sub

    Sub ClearPets()
        Dim i As Integer

        ReDim Pet(MAX_PETS)
        ReDim PetSkillCD(4)

        For i = 1 To MAX_PETS
            ClearPet(i)
        Next

    End Sub
#End Region

#Region "Outgoing Packets"
    Public Sub SendPetBehaviour(ByVal Index As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CSetBehaviour)

        buffer.WriteInteger(Index)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Sub SendTrainPetStat(ByVal StatNum As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CPetUseStatPoint)

        buffer.WriteInteger(StatNum)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Sub SendRequestPets()
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CRequestPets)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Sub SendUsePetSkill(ByVal skill As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CPetSkill)
        buffer.WriteInteger(skill)

        SendData(buffer.ToArray)
        buffer = Nothing

        PetSkillBuffer = skill
        PetSkillBufferTimer = GetTickCount()
    End Sub

    Sub SendSummonPet()
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CSummonPet)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Sub SendReleasePet()
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CReleasePet)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub
#End Region

#Region "Incoming Packets"
    Public Sub Packet_UpdatePlayerPet(ByVal Data() As Byte)
        Dim n As Integer, i As Long
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SUpdatePlayerPet Then Exit Sub

        n = buffer.ReadInteger

        'pet
        Player(n).Pet.Num = buffer.ReadInteger
        Player(n).Pet.Health = buffer.ReadInteger
        Player(n).Pet.Mana = buffer.ReadInteger
        Player(n).Pet.Level = buffer.ReadInteger

        For i = 1 To Stats.Count - 1
            Player(n).Pet.Stat(i) = buffer.ReadInteger
        Next

        For i = 1 To 4
            Player(n).Pet.Skill(i) = buffer.ReadInteger
        Next

        Player(n).Pet.X = buffer.ReadInteger
        Player(n).Pet.Y = buffer.ReadInteger
        Player(n).Pet.Dir = buffer.ReadInteger

        Player(n).Pet.MaxHp = buffer.ReadInteger
        Player(n).Pet.MaxMP = buffer.ReadInteger

        Player(n).Pet.Alive = buffer.ReadInteger

        Player(n).Pet.AttackBehaviour = buffer.ReadInteger
        Player(n).Pet.Points = buffer.ReadInteger
        Player(n).Pet.Exp = buffer.ReadInteger
        Player(n).Pet.TNL = buffer.ReadInteger

        buffer = Nothing
    End Sub

    Public Sub Packet_UpdatePet(ByVal Data() As Byte)
        Dim n As Integer, i As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SUpdatePet Then Exit Sub

        n = buffer.ReadInteger

        With Pet(n)
            .Num = buffer.ReadInteger
            .Name = buffer.ReadString
            .Sprite = buffer.ReadInteger
            .Range = buffer.ReadInteger
            .Level = buffer.ReadInteger
            .MaxLevel = buffer.ReadInteger
            .ExpGain = buffer.ReadInteger
            .LevelPnts = buffer.ReadInteger
            .StatType = buffer.ReadInteger
            .LevelingType = buffer.ReadInteger
            For i = 1 To Stats.Count - 1
                .Stat(i) = buffer.ReadInteger
            Next

            For i = 1 To 4
                .Skill(i) = buffer.ReadInteger
            Next

            .Evolvable = buffer.ReadInteger
            .EvolveLevel = buffer.ReadInteger
            .EvolveNum = buffer.ReadInteger
        End With

        buffer = Nothing

    End Sub

    Public Sub Packet_PetMove(ByVal data() As Byte)
        Dim i As Integer, X As Integer, Y As Integer
        Dim dir As Integer, Movement As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SPetMove Then Exit Sub

        i = buffer.ReadInteger
        X = buffer.ReadInteger
        Y = buffer.ReadInteger
        dir = buffer.ReadInteger
        Movement = buffer.ReadInteger

        With Player(i).Pet
            .X = X
            .Y = Y
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = Movement

            Select Case .Dir
                Case Direction.Up
                    .YOffset = PIC_Y
                Case Direction.Down
                    .YOffset = PIC_Y * -1
                Case Direction.Left
                    .XOffset = PIC_X
                Case Direction.Right
                    .XOffset = PIC_X * -1
            End Select
        End With

        buffer = Nothing
    End Sub

    Public Sub Packet_PetDir(ByVal Data() As Byte)
        Dim i As Integer
        Dim dir As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SPetDir Then Exit Sub

        i = buffer.ReadInteger
        dir = buffer.ReadInteger

        Player(i).Pet.Dir = dir

        buffer = Nothing
    End Sub

    Public Sub Packet_PetVital(ByVal Data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SPetVital Then Exit Sub

        i = buffer.ReadInteger

        If buffer.ReadInteger = 1 Then
            Player(i).Pet.MaxHp = buffer.ReadInteger
            Player(i).Pet.Health = buffer.ReadInteger
        Else
            Player(i).Pet.MaxMP = buffer.ReadInteger
            Player(i).Pet.Mana = buffer.ReadInteger
        End If

        buffer = Nothing

    End Sub

    Public Sub Packet_ClearPetSkillBuffer(ByVal Data() As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SClearPetSkillBuffer Then Exit Sub

        PetSkillBuffer = 0
        PetSkillBufferTimer = 0

        buffer = Nothing
    End Sub

    Public Sub Packet_PetAttack(ByVal Data() As Byte)
        Dim i As Integer
        Dim Buffer As New ByteBuffer

        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPetAttack Then Exit Sub

        i = Buffer.ReadInteger

        ' Set pet to attacking
        Player(i).Pet.Attacking = 1
        Player(i).Pet.AttackTimer = GetTickCount()

        Buffer = Nothing
    End Sub

    Public Sub Packet_PetXY(ByVal Data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SPetXY Then Exit Sub

        Player(i).Pet.X = buffer.ReadInteger
        Player(i).Pet.Y = buffer.ReadInteger

        buffer = Nothing
    End Sub

    Public Sub Packet_PetExperience(ByVal Data() As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SPetExp Then Exit Sub

        Player(MyIndex).Pet.Exp = buffer.ReadInteger
        Player(MyIndex).Pet.TNL = buffer.ReadInteger

        buffer = Nothing
    End Sub
#End Region

#Region "Movement"
    Sub ProcessPetMovement(ByVal Index As Integer)

        ' Check if pet is walking, and if so process moving them over

        If Player(Index).Pet.Moving = MovementType.Walking Then

            Select Case Player(Index).Pet.Dir
                Case Direction.Up
                    Player(Index).Pet.YOffset = Player(Index).Pet.YOffset - ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If Player(Index).Pet.YOffset < 0 Then Player(Index).Pet.YOffset = 0

                Case Direction.Down
                    Player(Index).Pet.YOffset = Player(Index).Pet.YOffset + ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If Player(Index).Pet.YOffset > 0 Then Player(Index).Pet.YOffset = 0

                Case Direction.Left
                    Player(Index).Pet.XOffset = Player(Index).Pet.XOffset - ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If Player(Index).Pet.XOffset < 0 Then Player(Index).Pet.XOffset = 0

                Case Direction.Right
                    Player(Index).Pet.XOffset = Player(Index).Pet.XOffset + ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
                    If Player(Index).Pet.XOffset > 0 Then Player(Index).Pet.XOffset = 0

            End Select

            ' Check if completed walking over to the next tile
            If Player(Index).Pet.Moving > 0 Then
                If Player(Index).Pet.Dir = Direction.Right Or Player(Index).Pet.Dir = Direction.Down Then
                    If (Player(Index).Pet.XOffset >= 0) And (Player(Index).Pet.YOffset >= 0) Then
                        Player(Index).Pet.Moving = 0
                        If Player(Index).Pet.Steps = 1 Then
                            Player(Index).Pet.Steps = 2
                        Else
                            Player(Index).Pet.Steps = 1
                        End If
                    End If
                Else
                    If (Player(Index).Pet.XOffset <= 0) And (Player(Index).Pet.YOffset <= 0) Then
                        Player(Index).Pet.Moving = 0
                        If Player(Index).Pet.Steps = 1 Then
                            Player(Index).Pet.Steps = 2
                        Else
                            Player(Index).Pet.Steps = 1
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub PetMove(ByVal X As Integer, ByVal Y As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CPetMove)

        buffer.WriteInteger(X)
        buffer.WriteInteger(Y)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

#End Region

#Region "Drawing"
    Public Sub DrawPet(ByVal Index As Integer)
        Dim Anim As Byte, X As Integer, Y As Integer
        Dim Sprite As Integer, spriteleft As Integer
        Dim srcrec As Rectangle
        Dim attackspeed As Integer

        Sprite = Pet(Player(Index).Pet.Num).Sprite

        If Sprite < 1 Or Sprite > NumCharacters Then Exit Sub

        attackspeed = 1000

        ' Reset frame
        If Player(Index).Pet.Steps = 3 Then
            Anim = 0
        ElseIf Player(Index).Pet.Steps = 1 Then
            Anim = 2
        ElseIf Player(Index).Pet.Steps = 2 Then
            Anim = 3
        End If

        ' Check for attacking animation
        If Player(Index).Pet.AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If Player(Index).Pet.Attacking = 1 Then
                Anim = 3
            End If
        Else
            ' If not attacking, walk normally
            Select Case Player(Index).Pet.Dir
                Case Direction.Up
                    If (Player(Index).Pet.YOffset > 8) Then Anim = Player(Index).Pet.Steps
                Case Direction.Down
                    If (Player(Index).Pet.YOffset < -8) Then Anim = Player(Index).Pet.Steps
                Case Direction.Left
                    If (Player(Index).Pet.XOffset > 8) Then Anim = Player(Index).Pet.Steps
                Case Direction.Right
                    If (Player(Index).Pet.XOffset < -8) Then Anim = Player(Index).Pet.Steps
            End Select
        End If

        ' Check to see if we want to stop making him attack
        With Player(Index).Pet
            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If
        End With

        ' Set the left
        Select Case Player(Index).Pet.Dir
            Case Direction.Up
                spriteleft = 3
            Case Direction.Right
                spriteleft = 2
            Case Direction.Down
                spriteleft = 0
            Case Direction.Left
                spriteleft = 1
        End Select

        srcrec = New Rectangle((Anim) * (CharacterGFXInfo(Sprite).Width / 4), spriteleft * (CharacterGFXInfo(Sprite).Height / 4), (CharacterGFXInfo(Sprite).Width / 4), (CharacterGFXInfo(Sprite).Height / 4))

        ' Calculate the X
        X = Player(Index).Pet.X * PIC_X + Player(Index).Pet.XOffset - ((CharacterGFXInfo(Sprite).Width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (CharacterGFXInfo(Sprite).Height / 4) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            Y = Player(Index).Pet.Y * PIC_Y + Player(Index).Pet.YOffset - ((CharacterGFXInfo(Sprite).Width / 4) - 32)
        Else
            ' Proceed as normal
            Y = Player(Index).Pet.Y * PIC_Y + Player(Index).Pet.YOffset
        End If

        ' render the actual sprite
        DrawCharacter(Sprite, X, Y, srcrec)

    End Sub

    Public Sub DrawPlayerPetName(ByVal Index As Integer)
        Dim TextX As Integer
        Dim TextY As Integer
        Dim color As SFML.Graphics.Color, backcolor As SFML.Graphics.Color
        Dim Name As String

        ' Check access level
        If GetPlayerPK(Index) = False Then

            Select Case GetPlayerAccess(Index)
                Case 0
                    color = SFML.Graphics.Color.Red
                    backcolor = SFML.Graphics.Color.Black
                Case 1
                    color = SFML.Graphics.Color.Black
                    backcolor = SFML.Graphics.Color.White
                Case 2
                    color = SFML.Graphics.Color.Cyan
                    backcolor = SFML.Graphics.Color.Black
                Case 3
                    color = SFML.Graphics.Color.Green
                    backcolor = SFML.Graphics.Color.Black
                Case 4
                    color = SFML.Graphics.Color.Yellow
                    backcolor = SFML.Graphics.Color.Black
            End Select

        Else
            color = SFML.Graphics.Color.Red
        End If

        Name = Trim$(GetPlayerName(Index)) & "'s " & Trim$(Pet(Player(Index).Pet.Num).Name)
        ' calc pos
        TextX = ConvertMapX(Player(Index).Pet.X * PIC_X) + Player(Index).Pet.XOffset + (PIC_X \ 2) - GetTextWidth(Name) / 2
        If Pet(Player(Index).Pet.Num).Sprite < 1 Or Pet(Player(Index).Pet.Num).Sprite > NumCharacters Then
            TextY = ConvertMapY(Player(Index).Pet.Y * PIC_Y) + Player(Index).Pet.YOffset - 16
        Else
            ' Determine location for text
            TextY = ConvertMapY(Player(Index).Pet.Y * PIC_Y) + Player(Index).Pet.YOffset - (CharacterGFXInfo(Pet(Player(Index).Pet.Num).Sprite).Height / 4) + 16
        End If

        ' Draw name
        DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)

    End Sub

    Sub DrawPetBar()
        Dim skillnum As Integer, skillpic As Integer
        Dim rec As Rectangle, rec_pos As Rectangle

        If Not HasPet(MyIndex) Then Exit Sub

        If Not PetAlive(MyIndex) Then
            RenderSprite(PetBarSprite, GameWindow, PetbarX, PetbarY, 0, 0, 32, PetbarGFXInfo.Height)
        Else
            RenderSprite(PetBarSprite, GameWindow, PetbarX, PetbarY, 0, 0, PetbarGFXInfo.Width, PetbarGFXInfo.Height)

            For i = 1 To 4
                skillnum = Player(MyIndex).Pet.Skill(i)

                If skillnum > 0 Then
                    skillpic = Skill(skillnum).Icon

                    If SkillIconsGFXInfo(skillpic).IsLoaded = False Then
                        LoadTexture(skillpic, 9)
                    End If

                    'seeying we still use it, lets update timer
                    With SkillIconsGFXInfo(skillpic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
                        .Width = 32
                    End With

                    If Not PetSkillCD(i) = 0 Then
                        rec.X = 32
                        rec.Width = 32
                    End If

                    With rec_pos
                        .Y = PetbarY + PetbarTop
                        .Height = PIC_Y
                        .X = PetbarX + PetbarLeft + ((PetbarOffsetX - 2) + 32) * (((i - 1) + 3))
                        .Width = PIC_X
                    End With

                    RenderSprite(SkillIconsSprite(skillpic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
                End If
            Next
        End If

    End Sub

    Sub DrawPetStats()
        Dim sprite As Integer, rec As Rectangle

        If Not HasPet(MyIndex) Then Exit Sub

        If Not ShowPetStats Then Exit Sub

        'draw panel
        RenderSprite(PetStatsSprite, GameWindow, PetStatX, PetStatY, 0, 0, PetStatsGFXInfo.Width, PetStatsGFXInfo.Height)

        'lets get player sprite to render
        sprite = Pet(Player(MyIndex).Pet.Num).Sprite

        With rec
            .Y = 0
            .Height = CharacterGFXInfo(sprite).Height / 4
            .X = 0
            .Width = CharacterGFXInfo(sprite).Width / 4
        End With

        Dim petname As String = Trim$(Pet(Player(MyIndex).Pet.Num).Name)

        DrawText(PetStatX + 70, PetStatY + 10, petname & " Lvl: " & Player(MyIndex).Pet.Level, SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)

        RenderSprite(CharacterSprite(sprite), GameWindow, PetStatX + 10, PetStatY + 10 + (PetStatsGFXInfo.Height / 4) - (rec.Height / 2), rec.X, rec.Y, rec.Width, rec.Height)

        'stats
        DrawText(PetStatX + 65, PetStatY + 50, "Strength: " & Player(MyIndex).Pet.Stat(Stats.Strength), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
        DrawText(PetStatX + 65, PetStatY + 65, "Endurance: " & Player(MyIndex).Pet.Stat(Stats.Endurance), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
        DrawText(PetStatX + 65, PetStatY + 80, "Vitality: " & Player(MyIndex).Pet.Stat(Stats.Vitality), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)

        DrawText(PetStatX + 165, PetStatY + 50, "Luck: " & Player(MyIndex).Pet.Stat(Stats.Luck), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
        DrawText(PetStatX + 165, PetStatY + 65, "Intelligence: " & Player(MyIndex).Pet.Stat(Stats.Intelligence), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
        DrawText(PetStatX + 165, PetStatY + 80, "Spirit: " & Player(MyIndex).Pet.Stat(Stats.Spirit), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)

        DrawText(PetStatX + 65, PetStatY + 95, "Experience: " & Player(MyIndex).Pet.Exp & "/" & Player(MyIndex).Pet.TNL, SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)
    End Sub

#End Region

#Region "Misc"
    Public Function PetAlive(ByVal index As Integer) As Boolean
        PetAlive = False

        If Player(index).Pet.Alive = 1 Then
            PetAlive = True
        End If

    End Function

    Public Function HasPet(ByVal index As Integer) As Boolean
        HasPet = False

        If Player(index).Pet.Num > 0 Then
            HasPet = True
        End If
    End Function

    Public Function IsPetBarSlot(ByVal X As Single, ByVal Y As Single) As Integer
        Dim tempRec As Rect
        Dim i As Integer

        IsPetBarSlot = 0

        For i = 1 To MAX_PETBAR

            With tempRec
                .top = PetbarY + PetbarTop
                .bottom = .top + PIC_Y
                .left = PetbarX + PetbarLeft + ((PetbarOffsetX + 32) * (((i - 1) Mod MAX_PETBAR)))
                .right = .left + PIC_X
            End With

            If X >= tempRec.left And X <= tempRec.right Then
                If Y >= tempRec.top And Y <= tempRec.bottom Then
                    IsPetBarSlot = i
                    Exit Function
                End If
            End If
        Next

    End Function
#End Region

End Module