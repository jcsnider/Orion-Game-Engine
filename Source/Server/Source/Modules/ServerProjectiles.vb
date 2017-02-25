﻿Imports System.IO

Public Module ServerProjectiles

#Region "Defines"
    Public Const MAX_PROJECTILES As Integer = 255
    Public Projectiles(0 To MAX_PROJECTILES) As ProjectileRec
    Public MapProjectiles(,) As MapProjectileRec
#End Region

#Region "Types"
    Public Structure ProjectileRec
        Dim Name As String
        Dim Sprite As Integer
        Dim Range As Byte
        Dim Speed As Integer
        Dim Damage As Integer
    End Structure

    Public Structure MapProjectileRec
        Dim ProjectileNum As Integer
        Dim Owner As Integer
        Dim OwnerType As Byte
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Byte
        Dim Timer As Integer
    End Structure
#End Region

#Region "Database"
    Sub SaveProjectiles()
        Dim i As Integer

        For i = 1 To MAX_PROJECTILES
            SaveProjectile(i)
        Next

    End Sub

    Sub SaveProjectile(ByVal ProjectileNum As Integer)
        Dim filename As String

        filename = Path.Combine(Application.StartupPath, "data", "projectiles", String.Format("projectile{0}.dat", ProjectileNum))

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Projectiles(ProjectileNum).Name)
        writer.Write(Projectiles(ProjectileNum).Sprite)
        writer.Write(Projectiles(ProjectileNum).Range)
        writer.Write(Projectiles(ProjectileNum).Speed)
        writer.Write(Projectiles(ProjectileNum).Damage)

        writer.Save(filename)

    End Sub

    Sub LoadProjectiles()
        Dim filename As String
        Dim i As Integer

        CheckProjectile()

        For i = 1 To MAX_PROJECTILES
            filename = Path.Combine(Application.StartupPath, "data", "projectiles", String.Format("projectile{0}.dat", i))
            Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

            reader.Read(Projectiles(i).Name)
            reader.Read(Projectiles(i).Sprite)
            reader.Read(Projectiles(i).Range)
            reader.Read(Projectiles(i).Speed)
            reader.Read(Projectiles(i).Damage)

            DoEvents()
        Next

    End Sub

    Sub CheckProjectile()
        Dim i As Integer

        For i = 1 To MAX_PROJECTILES
            If Not FileExist(Path.Combine(Application.StartupPath, "data", "projectiles", String.Format("projectile{0}.dat", i))) Then
                SaveProjectile(i)
            End If
        Next

    End Sub

    Sub ClearMapProjectiles()
        Dim x As Integer
        Dim y As Integer

        ReDim MapProjectiles(MAX_MAPS, MAX_PROJECTILES)
        For x = 1 To MAX_MAPS
            For y = 1 To MAX_PROJECTILES
                ClearMapProjectile(x, y)
            Next
        Next

    End Sub

    Sub ClearMapProjectile(ByVal MapNum As Integer, ByVal Index As Integer)

        MapProjectiles(MapNum, Index).ProjectileNum = 0
        MapProjectiles(MapNum, Index).Owner = 0
        MapProjectiles(MapNum, Index).OwnerType = 0
        MapProjectiles(MapNum, Index).X = 0
        MapProjectiles(MapNum, Index).Y = 0
        MapProjectiles(MapNum, Index).Dir = 0
        MapProjectiles(MapNum, Index).Timer = 0

    End Sub

    Sub ClearProjectile(ByVal Index As Integer)

        Projectiles(Index).Name = ""
        Projectiles(Index).Sprite = 0
        Projectiles(Index).Range = 0
        Projectiles(Index).Speed = 0
        Projectiles(Index).Damage = 0

    End Sub

    Sub ClearProjectiles()
        Dim i As Integer

        ReDim Projectiles(MAX_PROJECTILES)

        For i = 1 To MAX_PROJECTILES
            ClearProjectile(i)
        Next

    End Sub

#End Region

#Region "Incoming"
    Sub HandleRequestEditProjectiles(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As New ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        Buffer.WriteInteger(ServerPackets.SProjectileEditor)

        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub HandleSaveProjectile(ByVal Index As Integer, ByVal data() As Byte)
        Dim ProjectileNum As Integer
        Dim Buffer As New ByteBuffer

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> EditorPackets.SaveProjectile Then Exit Sub

        If GetPlayerAccess(Index) < AdminType.Developer Then Exit Sub

        ProjectileNum = Buffer.ReadInteger

        ' Prevent hacking
        If ProjectileNum < 0 Or ProjectileNum > MAX_PROJECTILES Then
            Exit Sub
        End If

        Projectiles(ProjectileNum).Name = Buffer.ReadString
        Projectiles(ProjectileNum).Sprite = Buffer.ReadInteger
        Projectiles(ProjectileNum).Range = Buffer.ReadInteger
        Projectiles(ProjectileNum).Speed = Buffer.ReadInteger
        Projectiles(ProjectileNum).Damage = Buffer.ReadInteger

        ' Save it
        SendUpdateProjectileToAll(ProjectileNum)
        SaveProjectile(ProjectileNum)
        Addlog(GetPlayerLogin(Index) & " saved Projectile #" & ProjectileNum & ".", ADMIN_LOG)
        Buffer = Nothing

    End Sub

    Sub HandleRequestProjectiles(ByVal Index As Integer, ByVal data() As Byte)

        SendProjectiles(Index)

    End Sub

    Sub HandleClearProjectile(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim ProjectileNum As Integer
        Dim TargetIndex As Integer
        Dim TargetType As TargetType
        Dim TargetZone As Integer
        Dim MapNum As Integer
        Dim Damage As Integer
        Dim armor As Integer
        Dim npcnum As Integer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CClearProjectile Then Exit Sub

        ProjectileNum = Buffer.ReadInteger
        TargetIndex = Buffer.ReadInteger
        TargetType = Buffer.ReadInteger
        TargetZone = Buffer.ReadInteger
        Buffer = Nothing

        MapNum = GetPlayerMap(Index)

        Select Case MapProjectiles(MapNum, ProjectileNum).OwnerType
            Case TargetType.Player
                If MapProjectiles(MapNum, ProjectileNum).Owner = Index Then
                    Select Case TargetType
                        Case TargetType.Player

                            If IsPlaying(TargetIndex) Then
                                If TargetIndex <> Index Then
                                    If CanPlayerAttackPlayer(Index, TargetIndex, True) = True Then

                                        ' Get the damage we can do
                                        Damage = GetPlayerDamage(Index) + Projectiles(MapProjectiles(MapNum, ProjectileNum).ProjectileNum).Damage

                                        ' if the npc blocks, take away the block amount
                                        armor = CanPlayerBlockHit(TargetIndex)
                                        Damage = Damage - armor

                                        ' randomise for up to 10% lower than max hit
                                        Damage = Random(1, Damage)

                                        If Damage < 1 Then Damage = 1

                                        AttackPlayer(Index, TargetIndex, Damage)
                                    End If
                                End If
                            End If

                        Case TargetType.Npc
                            npcnum = MapNpc(MapNum).Npc(TargetIndex).Num
                            If CanPlayerAttackNpc(Index, TargetIndex, True) = True Then
                                ' Get the damage we can do
                                Damage = GetPlayerDamage(Index) + Projectiles(MapProjectiles(MapNum, ProjectileNum).ProjectileNum).Damage

                                ' if the npc blocks, take away the block amount
                                armor = 0
                                Damage = Damage - armor

                                ' randomise from 1 to max hit
                                Damage = Random(1, Damage)

                                If Damage < 1 Then Damage = 1

                                PlayerAttackNpc(Index, TargetIndex, Damage)
                            End If
                    End Select
                End If

        End Select

        ClearMapProjectile(MapNum, ProjectileNum)

    End Sub

#End Region

#Region "Outgoing"
    Sub SendUpdateProjectileToAll(ByVal ProjectileNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateProjectile)
        Buffer.WriteInteger(ProjectileNum)
        Buffer.WriteString(Trim(Projectiles(ProjectileNum).Name))
        Buffer.WriteInteger(Projectiles(ProjectileNum).Sprite)
        Buffer.WriteInteger(Projectiles(ProjectileNum).Range)
        Buffer.WriteInteger(Projectiles(ProjectileNum).Speed)
        Buffer.WriteInteger(Projectiles(ProjectileNum).Damage)

        SendDataToAll(Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendUpdateProjectileTo(ByVal Index As Integer, ByVal ProjectileNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SUpdateProjectile)
        Buffer.WriteInteger(ProjectileNum)
        Buffer.WriteString(Trim(Projectiles(ProjectileNum).Name))
        Buffer.WriteInteger(Projectiles(ProjectileNum).Sprite)
        Buffer.WriteInteger(Projectiles(ProjectileNum).Range)
        Buffer.WriteInteger(Projectiles(ProjectileNum).Speed)
        Buffer.WriteInteger(Projectiles(ProjectileNum).Damage)

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendProjectiles(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_PROJECTILES
            If Len(Trim$(Projectiles(i).Name)) > 0 Then
                Call SendUpdateProjectileTo(Index, i)
            End If
        Next

    End Sub

    Sub SendProjectileToMap(ByVal MapNum As Integer, ByVal ProjectileNum As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SMapProjectile)

        With MapProjectiles(MapNum, ProjectileNum)
            Buffer.WriteInteger(ProjectileNum)
            Buffer.WriteInteger(.ProjectileNum)
            Buffer.WriteInteger(.Owner)
            Buffer.WriteInteger(.OwnerType)
            Buffer.WriteInteger(.Dir)
            Buffer.WriteInteger(.X)
            Buffer.WriteInteger(.Y)
        End With

        SendDataToMap(MapNum, Buffer.ToArray)
        Buffer = Nothing

    End Sub

#End Region

#Region "Functions"
    Public Sub PlayerFireProjectile(ByVal Index As Integer, Optional ByVal IsSkill As Integer = 0)
        Dim ProjectileSlot As Integer
        Dim ProjectileNum As Integer
        Dim MapNum As Integer
        Dim i As Integer

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

        'Check for skill, if so then load data acordingly
        If IsSkill > 0 Then
            ProjectileNum = Skill(IsSkill).Projectile
        Else
            ProjectileNum = Item(GetPlayerEquipment(Index, EquipmentType.Weapon)).Projectile
        End If

        If ProjectileNum = 0 Then Exit Sub

        With MapProjectiles(MapNum, ProjectileSlot)
            .ProjectileNum = ProjectileNum
            .Owner = Index
            .OwnerType = TargetType.Player
            .Dir = GetPlayerDir(Index)
            .X = GetPlayerX(Index)
            .Y = GetPlayerY(Index)
            .Timer = GetTickCount() + 60000
        End With

        SendProjectileToMap(MapNum, ProjectileSlot)

    End Sub

    Public Function Engine_GetAngle(ByVal CenterX As Integer, ByVal CenterY As Integer, ByVal targetX As Integer, ByVal targetY As Integer) As Single
        '************************************************************
        'Gets the angle between two points in a 2d plane
        '************************************************************
        Dim SideA As Single
        Dim SideC As Single

        On Error GoTo ErrOut

        'Check for horizontal lines (90 or 270 degrees)
        If CenterY = targetY Then
            'Check for going right (90 degrees)
            If CenterX < targetX Then
                Engine_GetAngle = 90
                'Check for going left (270 degrees)
            Else
                Engine_GetAngle = 270
            End If

            'Exit the function
            Exit Function
        End If

        'Check for horizontal lines (360 or 180 degrees)
        If CenterX = targetX Then
            'Check for going up (360 degrees)
            If CenterY > targetY Then
                Engine_GetAngle = 360

                'Check for going down (180 degrees)
            Else
                Engine_GetAngle = 180
            End If

            'Exit the function
            Exit Function
        End If

        'Calculate Side C
        SideC = Math.Sqrt(Math.Abs(targetX - CenterX) ^ 2 + Math.Abs(targetY - CenterY) ^ 2)

        'Side B = CenterY

        'Calculate Side A
        SideA = Math.Sqrt(Math.Abs(targetX - CenterX) ^ 2 + targetY ^ 2)

        'Calculate the angle
        Engine_GetAngle = (SideA ^ 2 - CenterY ^ 2 - SideC ^ 2) / (CenterY * SideC * -2)
        Engine_GetAngle = (Math.Atan(-Engine_GetAngle / Math.Sqrt(-Engine_GetAngle * Engine_GetAngle + 1)) + 1.5708) * 57.29583

        'If the angle is >180, subtract from 360
        If targetX < CenterX Then Engine_GetAngle = 360 - Engine_GetAngle

        'Exit function
        Exit Function

        'Check for error
ErrOut:

        'Return a 0 saying there was an error
        Engine_GetAngle = 0

        Exit Function
    End Function
#End Region

End Module