Public Module ServerProjectiles

#Region "Defines"
    Public Const MAX_PROJECTILES As Long = 255
    Public Projectiles(0 To MAX_PROJECTILES) As ProjectileRec
    Public MapProjectiles(,) As MapProjectileRec
#End Region

#Region "Types"
    Public Structure ProjectileRec
        Dim Name As String
        Dim Sprite As Long
        Dim Range As Byte
        Dim Speed As Long
        Dim Damage As Long
    End Structure

    Public Structure MapProjectileRec
        Dim ProjectileNum As Long
        Dim Owner As Long
        Dim OwnerType As Byte
        Dim X As Long
        Dim Y As Long
        Dim Dir As Byte
        Dim Timer As Long
    End Structure
#End Region

#Region "Database"

    Sub SaveProjectiles()
        Dim i As Long

        For i = 1 To MAX_PROJECTILES
            Call SaveProjectile(i)
        Next

    End Sub

    Sub SaveProjectile(ByVal ProjectileNum As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\projectiles\Projectile" & ProjectileNum & ".dat"
        F = FreeFile()

        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Projectiles(ProjectileNum).Name)
        FilePutObject(F, Projectiles(ProjectileNum).Sprite)
        FilePutObject(F, Projectiles(ProjectileNum).Range)
        FilePutObject(F, Projectiles(ProjectileNum).Speed)
        FilePutObject(F, Projectiles(ProjectileNum).Damage)

        FileClose(F)

    End Sub

    Sub LoadProjectiles()
        Dim filename As String
        Dim i As Long
        Dim F As Long

        Call CheckProjectile()

        For i = 1 To MAX_PROJECTILES
            filename = Application.StartupPath & "\data\projectiles\Projectile" & i & ".dat"
            F = FreeFile()
            FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

            FileGetObject(F, Projectiles(i).Name)
            FileGetObject(F, Projectiles(i).Sprite)
            FileGetObject(F, Projectiles(i).Range)
            FileGetObject(F, Projectiles(i).Speed)
            FileGetObject(F, Projectiles(i).Damage)

            FileClose(F)

            DoEvents()
        Next

    End Sub

    Sub CheckProjectile()
        Dim i As Long

        For i = 1 To MAX_PROJECTILES
            If Not FileExist(Application.StartupPath & "\Data\projectiles\Projectile" & i & ".dat") Then
                Call SaveProjectile(i)
            End If
        Next

    End Sub

    Sub ClearMapProjectiles()
        Dim x As Long
        Dim y As Long

        ReDim MapProjectiles(MAX_MAPS, MAX_PROJECTILES)
        For x = 1 To MAX_MAPS
            For y = 1 To MAX_PROJECTILES
                ClearMapProjectile(x, y)
            Next
        Next

    End Sub

    Sub ClearMapProjectile(ByVal MapNum As Long, ByVal Index As Long)

        MapProjectiles(MapNum, Index).ProjectileNum = 0
        MapProjectiles(MapNum, Index).Owner = 0
        MapProjectiles(MapNum, Index).OwnerType = 0
        MapProjectiles(MapNum, Index).X = 0
        MapProjectiles(MapNum, Index).Y = 0
        MapProjectiles(MapNum, Index).Dir = 0
        MapProjectiles(MapNum, Index).Timer = 0

    End Sub

    Sub ClearProjectile(ByVal Index As Long)

        Projectiles(Index).Name = vbNullString
        Projectiles(Index).Sprite = 0
        Projectiles(Index).Range = 0
        Projectiles(Index).Speed = 0
        Projectiles(Index).Damage = 0

    End Sub

    Sub ClearProjectiles()
        Dim i As Long

        ReDim Projectiles(MAX_PROJECTILES)

        For i = 1 To MAX_PROJECTILES
            Call ClearProjectile(i)
        Next

    End Sub


#End Region

#Region "Incoming"
    Sub HandleRequestEditProjectiles(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SProjectileEditor)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub HandleSaveProjectile(ByVal Index As Long, ByVal data() As Byte)
        Dim ProjectileNum As Long
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CSaveProjectile Then Exit Sub

        If GetPlayerAccess(Index) < ADMIN_DEVELOPER Then
            Exit Sub
        End If


        ProjectileNum = Buffer.ReadLong

        ' Prevent hacking
        If ProjectileNum < 0 Or ProjectileNum > MAX_PROJECTILES Then
            Exit Sub
        End If

        Projectiles(ProjectileNum).Name = Buffer.ReadString
        Projectiles(ProjectileNum).Sprite = Buffer.ReadLong
        Projectiles(ProjectileNum).Range = Buffer.ReadLong
        Projectiles(ProjectileNum).Speed = Buffer.ReadLong
        Projectiles(ProjectileNum).Damage = Buffer.ReadLong

        ' Save it
        Call SendUpdateProjectileToAll(ProjectileNum)
        Call SaveProjectile(ProjectileNum)
        Call Addlog(GetPlayerName(Index) & " saved Projectile #" & ProjectileNum & ".", ADMIN_LOG)
        Buffer = Nothing

    End Sub

    Sub HandleRequestProjectiles(ByVal Index As Long, ByVal data() As Byte)

        SendProjectiles(Index)

    End Sub

    Sub HandleClearProjectile(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim ProjectileNum As Long
        Dim TargetIndex As Long
        Dim TargetType As Byte
        Dim TargetZone As Long
        Dim MapNum As Long
        Dim Damage As Long
        Dim armor As Long
        Dim npcnum As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CClearProjectile Then Exit Sub

        ProjectileNum = Buffer.ReadLong
        TargetIndex = Buffer.ReadLong
        TargetType = Buffer.ReadLong
        TargetZone = Buffer.ReadLong
        Buffer = Nothing

        MapNum = GetPlayerMap(Index)

        Select Case MapProjectiles(MapNum, ProjectileNum).OwnerType
            Case TARGET_TYPE_PLAYER
                If MapProjectiles(MapNum, ProjectileNum).Owner = Index Then
                    Select Case TargetType
                        Case TARGET_TYPE_PLAYER

                            If IsPlaying(TargetIndex) Then
                                If TargetIndex <> Index Then
                                    If CanAttackPlayer(Index, TargetIndex, True) = True Then

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

                        Case TARGET_TYPE_NPC
                            npcnum = MapNpc(MapNum).Npc(TargetIndex).Num
                            If CanAttackNpc(Index, TargetIndex, True) = True Then
                                ' Get the damage we can do
                                Damage = GetPlayerDamage(Index) + Projectiles(MapProjectiles(MapNum, ProjectileNum).ProjectileNum).Damage

                                ' if the npc blocks, take away the block amount
                                armor = 0
                                Damage = Damage - armor

                                ' randomise from 1 to max hit
                                Damage = Random(1, Damage)


                                If Damage < 1 Then Damage = 1

                                AttackNpc(Index, TargetIndex, Damage)
                            End If
                    End Select
                End If

        End Select

        ClearMapProjectile(MapNum, ProjectileNum)

    End Sub

#End Region

#Region "Outgoing"
    Sub SendUpdateProjectileToAll(ByVal ProjectileNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateProjectile)
        Buffer.WriteLong(ProjectileNum)
        Buffer.WriteString(Trim(Projectiles(ProjectileNum).Name))
        Buffer.WriteLong(Projectiles(ProjectileNum).Sprite)
        Buffer.WriteLong(Projectiles(ProjectileNum).Range)
        Buffer.WriteLong(Projectiles(ProjectileNum).Speed)
        Buffer.WriteLong(Projectiles(ProjectileNum).Damage)

        SendDataToAll(Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendUpdateProjectileTo(ByVal Index As Long, ByVal ProjectileNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ServerPackets.SUpdateProjectile)
        Buffer.WriteLong(ProjectileNum)
        Buffer.WriteString(Trim(Projectiles(ProjectileNum).Name))
        Buffer.WriteLong(Projectiles(ProjectileNum).Sprite)
        Buffer.WriteLong(Projectiles(ProjectileNum).Range)
        Buffer.WriteLong(Projectiles(ProjectileNum).Speed)
        Buffer.WriteLong(Projectiles(ProjectileNum).Damage)

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing

    End Sub

    Sub SendProjectiles(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_PROJECTILES
            If Len(Trim$(Projectiles(i).Name)) > 0 Then
                Call SendUpdateProjectileTo(Index, i)
            End If
        Next


    End Sub

    Sub SendProjectileToMap(ByVal MapNum As Long, ByVal ProjectileNum As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SMapProjectile)

        With MapProjectiles(MapNum, ProjectileNum)
            Buffer.WriteLong(ProjectileNum)
            Buffer.WriteLong(.ProjectileNum)
            Buffer.WriteLong(.Owner)
            Buffer.WriteLong(.OwnerType)
            Buffer.WriteLong(.Dir)
            Buffer.WriteLong(.X)
            Buffer.WriteLong(.Y)
        End With

        SendDataToMap(MapNum, Buffer.ToArray)
        Buffer = Nothing

    End Sub

#End Region

#Region "Functions"
    Public Sub PlayerFireProjectile(ByVal Index As Long, Optional ByVal IsSkill As Long = 0)
        Dim ProjectileSlot As Long
        Dim ProjectileNum As Long
        Dim MapNum As Long
        Dim i As Long

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
            ProjectileNum = Item(GetPlayerEquipment(Index, Equipment.Weapon)).Data1
        End If

        With MapProjectiles(MapNum, ProjectileSlot)
            .ProjectileNum = ProjectileNum
            .Owner = Index
            .OwnerType = TARGET_TYPE_PLAYER
            .Dir = GetPlayerDir(Index)
            .X = GetPlayerX(Index)
            .Y = GetPlayerY(Index)
            .Timer = GetTickCount() + 60000
        End With

        SendProjectileToMap(MapNum, ProjectileSlot)

    End Sub
#End Region

End Module
