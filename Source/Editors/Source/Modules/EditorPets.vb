Module EditorPets
#Region "Globals etc"
    Public Pet(MAX_PETS) As PetRec
    Public Const EDITOR_PET As Byte = 7
    Public Pet_Changed() As Boolean

    Public Const PetHpBarWidth As Integer = 129
    Public Const PetMpBarWidth As Integer = 129

    Public PetSpellBuffer As Integer
    Public PetSpellBufferTimer As Integer
    Public PetSpellCD() As Integer

    Public InitPetEditor As Boolean

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

        Dim stat() As Byte

        Dim skill() As Integer
    End Structure

    Public Structure PlayerPetRec
        Dim Num As Integer
        Dim Health As Integer
        Dim Mana As Integer
        Dim Level As Integer
        Dim stat() As Byte
        Dim spell() As Integer
        Dim Points As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim dir As Integer
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

#Region "Outgoing Packets"
    Sub SendRequestPets()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CRequestPets)
        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub SendRequestEditPet()
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteInteger(EditorPackets.CRequestEditPet)

        SendData(buffer.ToArray)

        buffer = Nothing

    End Sub

    Public Sub SendSavePet(ByVal petNum As Integer)
        Dim buffer As ByteBuffer
        Dim i As Integer

        buffer = New ByteBuffer
        buffer.WriteInteger(EditorPackets.CSavePet)
        buffer.WriteInteger(petNum)

        With Pet(petNum)
            buffer.WriteInteger(.Num)
            buffer.WriteString(Trim$(.Name))
            buffer.WriteInteger(.Sprite)
            buffer.WriteInteger(.Range)
            buffer.WriteInteger(.Level)
            buffer.WriteInteger(.MaxLevel)
            buffer.WriteInteger(.ExpGain)
            buffer.WriteInteger(.LevelPnts)
            buffer.WriteInteger(.StatType)
            buffer.WriteInteger(.LevelingType)

            For i = 1 To Stats.Count - 1
                buffer.WriteInteger(.stat(i))
            Next

            For i = 1 To 4
                buffer.WriteInteger(.skill(i))
            Next

        End With

        SendData(buffer.ToArray)

        buffer = Nothing

    End Sub
#End Region

#Region "Incoming Packets"
    Public Sub Packet_PetEditor(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SPetEditor Then Exit Sub

        InitPetEditor = True

    End Sub

    Public Sub Packet_UpdatePet(ByVal Data() As Byte)
        Dim n As Integer, i As Long
        Dim buffer = New ByteBuffer
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
                .stat(i) = buffer.ReadInteger
            Next
            For i = 1 To 4
                .skill(i) = buffer.ReadInteger
            Next
        End With

        buffer = Nothing

    End Sub

#End Region

#Region "Editor"
    Public Sub PetEditorInit()
        Dim prefix As String

        If frmEditor_Pet.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Pet.lstIndex.SelectedIndex + 1

        ReDim Pet(EditorIndex).stat(Stats.Count - 1)
        ReDim Pet(EditorIndex).skill(4)

        With frmEditor_Pet
            .txtName.Text = Trim$(Pet(EditorIndex).Name)
            If Pet(EditorIndex).Sprite < 0 Or Pet(EditorIndex).Sprite > .scrlSprite.Maximum Then Pet(EditorIndex).Sprite = 0
            .scrlSprite.Value = Pet(EditorIndex).Sprite
            .scrlRange.Value = Pet(EditorIndex).Range

            .scrlStrength.Value = Pet(EditorIndex).stat(Stats.Strength)
            .scrlEndurance.Value = Pet(EditorIndex).stat(Stats.Endurance)
            .scrlVitality.Value = Pet(EditorIndex).stat(Stats.Vitality)
            .scrlLuck.Value = Pet(EditorIndex).stat(Stats.Luck)
            .scrlIntelligence.Value = Pet(EditorIndex).stat(Stats.Intelligence)
            .scrlSpirit.Value = Pet(EditorIndex).stat(Stats.Spirit)
            .scrlLevel.Value = Pet(EditorIndex).Level

            If Pet(EditorIndex).StatType = 1 Then
                .optCustomStats.Checked = True
                .pnlCustomStats.Visible = True
            Else
                .optAdoptStats.Checked = True
                .pnlCustomStats.Visible = False
            End If

            'Set skills
            .scrlSpell1.Value = Pet(EditorIndex).skill(1)
            prefix = "Skill " & 1 & ": "

            If .scrlSpell1.Value = 0 Then
                .lblSpell1.Text = prefix & "None"
            Else
                .lblSpell1.Text = prefix & Trim$(Skill(.scrlSpell1.Value).Name)
            End If

            .scrlSpell2.Value = Pet(EditorIndex).skill(2)
            prefix = "Skill " & 2 & ": "

            If .scrlSpell2.Value = 0 Then
                .lblSpell2.Text = prefix & "None"
            Else
                .lblSpell2.Text = prefix & Trim$(Skill(.scrlSpell2.Value).Name)
            End If

            .scrlSpell3.Value = Pet(EditorIndex).skill(3)
            prefix = "Skill " & 3 & ": "

            If .scrlSpell3.Value = 0 Then
                .lblSpell3.Text = prefix & "None"
            Else
                .lblSpell3.Text = prefix & Trim$(Skill(.scrlSpell3.Value).Name)
            End If

            .scrlSpell4.Value = Pet(EditorIndex).skill(4)
            prefix = "Skill " & 4 & ": "

            If .scrlSpell4.Value = 0 Then
                .lblSpell4.Text = prefix & "None"
            Else
                .lblSpell4.Text = prefix & Trim$(Skill(.scrlSpell4.Value).Name)
            End If

            If Pet(EditorIndex).LevelingType = 0 Then
                .optLevel.Checked = True
                .pnlPetlevel.Visible = True
                .scrlPetExp.Value = Pet(EditorIndex).ExpGain
                If Pet(EditorIndex).MaxLevel > 0 Then .scrlMaxLevel.Value = Pet(EditorIndex).MaxLevel
                .scrlPetPnts.Value = Pet(EditorIndex).LevelPnts
            Else
                .optDoNotLevel.Checked = True
                .pnlPetlevel.Visible = False
                .scrlPetExp.Value = Pet(EditorIndex).ExpGain
                .scrlMaxLevel.Value = Pet(EditorIndex).MaxLevel
                .scrlPetPnts.Value = Pet(EditorIndex).LevelPnts
            End If
        End With

        ClearChanged_Pet()

        Pet_Changed(EditorIndex) = True

    End Sub

    Public Sub PetEditorOk()
        Dim i As Integer

        For i = 1 To MAX_PETS
            If Pet_Changed(i) Then
                SendSavePet(i)
            End If
        Next

        frmEditor_Pet.Dispose()

        Editor = 0
        ClearChanged_Pet()

    End Sub

    Public Sub PetEditorCancel()

        Editor = 0

        frmEditor_Pet.Dispose()

        ClearChanged_Pet()
        ClearPets()
        SendRequestPets()

    End Sub

    Public Sub ClearChanged_Pet()

        ReDim Pet_Changed(MAX_PETS)

    End Sub
#End Region

    Sub ClearPet(ByVal Index As Integer)

        Pet(Index).Name = ""

        ReDim Pet(Index).stat(Stats.Count - 1)
        ReDim Pet(Index).skill(4)
    End Sub

    Sub ClearPets()
        Dim i As Integer

        ReDim Pet(MAX_PETS)

        For i = 1 To MAX_PETS
            ClearPet(i)
        Next

    End Sub

End Module