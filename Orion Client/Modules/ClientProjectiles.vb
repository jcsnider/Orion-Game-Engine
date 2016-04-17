Imports System.Drawing
Imports System.Windows.Forms
Imports SFML.Graphics

Public Module ClientProjectiles
#Region "Defines"
    Public Const MAX_PROJECTILES As Long = 255
    Public Projectiles(0 To MAX_PROJECTILES) As ProjectileRec
    Public MapProjectiles(0 To MAX_PROJECTILES) As MapProjectileRec
    Public NumProjectiles As Long
    Public InitProjectileEditor As Boolean
    Public Const EDITOR_PROJECTILE As Byte = 10
    Public Projectile_Changed(0 To MAX_PROJECTILES) As Boolean
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
        Dim dir As Byte
        Dim Range As Long
        Dim TravelTime As Long
        Dim Timer As Long
    End Structure
#End Region

#Region "Sending"
    Sub SendRequestEditProjectiles()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CRequestEditProjectiles)
        SendData(buffer.ToArray())
        buffer = Nothing

    End Sub

    Sub SendSaveProjectile(ByVal ProjectileNum As Long)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CSaveProjectile)
        buffer.WriteLong(ProjectileNum)

        buffer.WriteString(Trim(Projectiles(ProjectileNum).Name))
        buffer.WriteLong(Projectiles(ProjectileNum).Sprite)
        buffer.WriteLong(Projectiles(ProjectileNum).Range)
        buffer.WriteLong(Projectiles(ProjectileNum).Speed)
        buffer.WriteLong(Projectiles(ProjectileNum).Damage)

        SendData(buffer.ToArray())
        buffer = Nothing

    End Sub

    Sub SendRequestProjectiles()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CRequestProjectiles)
        SendData(buffer.ToArray())
        buffer = Nothing

    End Sub

    Sub SendClearProjectile(ByVal ProjectileNum As Long, ByVal CollisionIndex As Long, ByVal CollisionType As Byte, ByVal CollisionZone As Long)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CClearProjectile)
        buffer.WriteLong(ProjectileNum)
        buffer.WriteLong(CollisionIndex)
        buffer.WriteLong(CollisionType)
        buffer.WriteLong(CollisionZone)
        SendData(buffer.ToArray())
        buffer = Nothing

    End Sub

#End Region

#Region "Recieving"
    Public Sub HandleProjectileEditor(ByVal data() As Byte)

        InitProjectileEditor = True

    End Sub

    Public Sub HandleUpdateProjectile(ByVal data() As Byte)
        Dim ProjectileNum As Long
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SUpdateProjectile Then Exit Sub

        ProjectileNum = buffer.ReadLong

        Projectiles(ProjectileNum).Name = buffer.ReadString
        Projectiles(ProjectileNum).Sprite = buffer.ReadLong
        Projectiles(ProjectileNum).Range = buffer.ReadLong
        Projectiles(ProjectileNum).Speed = buffer.ReadLong
        Projectiles(ProjectileNum).Damage = buffer.ReadLong

        buffer = Nothing

    End Sub

    Public Sub HandleMapProjectile(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim i As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SMapProjectile Then Exit Sub

        i = buffer.ReadLong

        With MapProjectiles(i)
            .ProjectileNum = buffer.ReadLong
            .Owner = buffer.ReadLong
            .OwnerType = buffer.ReadLong
            .dir = buffer.ReadLong
            .X = buffer.ReadLong
            .Y = buffer.ReadLong
            .Range = 0
            .Timer = GetTickCount() + 60000
        End With

        buffer = Nothing

    End Sub

#End Region

#Region "Database"
    Sub ClearProjectiles()
        Dim i As Long

        For i = 1 To MAX_PROJECTILES
            Call ClearProjectile(i)
        Next

    End Sub

    Sub ClearProjectile(ByVal Index As Long)

        Projectiles(Index).Name = vbNullString
        Projectiles(Index).Sprite = 0
        Projectiles(Index).Range = 0
        Projectiles(Index).Speed = 0
        Projectiles(Index).Damage = 0

    End Sub

    Sub ClearMapProjectile(ByVal ProjectileNum As Long)

        MapProjectiles(ProjectileNum).ProjectileNum = 0
        MapProjectiles(ProjectileNum).Owner = 0
        MapProjectiles(ProjectileNum).OwnerType = 0
        MapProjectiles(ProjectileNum).X = 0
        MapProjectiles(ProjectileNum).Y = 0
        MapProjectiles(ProjectileNum).dir = 0
        MapProjectiles(ProjectileNum).Timer = 0

    End Sub

#End Region

#Region "Drawing"

    'Public ProjectileGFX() As Texture
    'Public ProjectileGFXInfo() As GraphicInfo

    Public Sub CheckProjectiles()
        Dim i As Long

        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "projectiles\" & i & GFX_EXT)

            NumProjectiles = NumProjectiles + 1
            i = i + 1
        End While

        If NumProjectiles = 0 Then Exit Sub

    End Sub

    Public Sub EditorProjectile_DrawProjectile()
        Dim iconnum As Long

        iconnum = frmEditor_Projectile.scrlPic.Value

        If iconnum < 1 Or iconnum > NumProjectiles Then
            frmEditor_Projectile.picProjectile.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "Projectiles\" & iconnum & GFX_EXT) Then
            frmEditor_Projectile.picProjectile.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "Projectiles\" & iconnum & GFX_EXT)
        End If

    End Sub

    Public Sub DrawProjectile(ByVal ProjectileNum As Long)
        Dim rec As RECT
        Dim CanClearProjectile As Boolean
        Dim CollisionIndex As Long
        Dim CollisionType As Byte
        Dim CollisionZone As Long
        Dim XOffset As Long, YOffset As Long
        Dim X As Long, Y As Long
        Dim i As Long
        Dim Sprite As Long

        ' check to see if it's time to move the Projectile
        If GetTickCount() > MapProjectiles(ProjectileNum).TravelTime Then
            Select Case MapProjectiles(ProjectileNum).dir
                Case DIR_UP
                    MapProjectiles(ProjectileNum).Y = MapProjectiles(ProjectileNum).Y - 1
                Case DIR_DOWN
                    MapProjectiles(ProjectileNum).Y = MapProjectiles(ProjectileNum).Y + 1
                Case DIR_LEFT
                    MapProjectiles(ProjectileNum).X = MapProjectiles(ProjectileNum).X - 1
                Case DIR_RIGHT
                    MapProjectiles(ProjectileNum).X = MapProjectiles(ProjectileNum).X + 1
            End Select
            MapProjectiles(ProjectileNum).TravelTime = GetTickCount() + Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed
            MapProjectiles(ProjectileNum).Range = MapProjectiles(ProjectileNum).Range + 1
        End If

        X = MapProjectiles(ProjectileNum).X
        Y = MapProjectiles(ProjectileNum).Y

        'Check if its been going for over 1 minute, if so clear.
        If MapProjectiles(ProjectileNum).Timer < GetTickCount() Then CanClearProjectile = True

        If X > Map.MaxX Or X < 0 Then CanClearProjectile = True
        If Y > Map.MaxY Or Y < 0 Then CanClearProjectile = True

        'Check for blocked wall collision
        If CanClearProjectile = False Then 'Add a check to prevent crashing
            If Map.Tile(X, Y).Type = TILE_TYPE_BLOCKED Then CanClearProjectile = True
        End If

        'Check for npc collision
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).X = X And MapNpc(i).Y = Y Then
                CanClearProjectile = True
                CollisionIndex = i
                CollisionType = TARGET_TYPE_NPC
                CollisionZone = -1
                Exit For
            End If
        Next

        'Check for player collision
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                If GetPlayerX(i) = X And GetPlayerY(i) = Y Then
                    CanClearProjectile = True
                    CollisionIndex = i
                    CollisionType = TARGET_TYPE_PLAYER
                    CollisionZone = -1
                    If MapProjectiles(ProjectileNum).OwnerType = TARGET_TYPE_PLAYER Then
                        If MapProjectiles(ProjectileNum).Owner = i Then CanClearProjectile = False ' Reset if its the owner of projectile
                    End If
                    Exit For
                End If

            End If
        Next

        'Check if it has hit its maximum range
        If MapProjectiles(ProjectileNum).Range >= Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Range + 1 Then CanClearProjectile = True

        'Clear the projectile if possible
        If CanClearProjectile = True Then
            'Only send the clear to the server if you're the projectile caster or the one hit (only if owner is not a player)
            If (MapProjectiles(ProjectileNum).OwnerType = TARGET_TYPE_PLAYER And MapProjectiles(ProjectileNum).Owner = MyIndex) Then
                SendClearProjectile(ProjectileNum, CollisionIndex, CollisionType, CollisionZone)
            End If

            ClearMapProjectile(ProjectileNum)
            Exit Sub
        End If

        Sprite = Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Sprite
        If Sprite < 1 Or Sprite > NumProjectiles Then Exit Sub

        ' src rect
        With rec
            .top = 0
            .bottom = ProjectileGFXInfo(Sprite).height
            .left = MapProjectiles(ProjectileNum).dir * PIC_X
            .right = .left + PIC_X
        End With

        'Find the offset
        Select Case MapProjectiles(ProjectileNum).dir
            Case DIR_UP
                YOffset = ((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_Y
            Case DIR_DOWN
                YOffset = -((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_Y
            Case DIR_LEFT
                XOffset = ((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_X
            Case DIR_RIGHT
                XOffset = -((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_X
        End Select

        X = ConvertMapX(X * PIC_X)
        Y = ConvertMapY(Y * PIC_Y)

        'RenderTexture Tex_Projectiles(Sprite), X + XOffset, Y + YOffset, rec.left, rec.top, rec.right - rec.left, rec.bottom - rec.top, rec.right - rec.left, rec.bottom - rec.top, D3DColorRGBA(255, 255, 255, 255), True

        Dim tmpSprite As Sprite = New Sprite(ProjectileGFX(Sprite))
        'tmpSprite.TextureRect = New IntRect(rec.left, rec.top, rec.right, rec.bottom)
        tmpSprite.TextureRect = New IntRect(rec.left, rec.top, 32, 32)
        tmpSprite.Position = New SFML.Window.Vector2f(X, Y)
        GameWindow.Draw(tmpSprite)

    End Sub

#End Region

#Region "Projectile Editor"

    Public Sub ProjectileEditorInit()

        If frmEditor_Projectile.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Projectile.lstIndex.SelectedIndex + 1

        With Projectiles(EditorIndex)
            frmEditor_Projectile.txtName.Text = Trim$(.Name)
            frmEditor_Projectile.scrlPic.Value = .Sprite
            frmEditor_Projectile.scrlRange.Value = .Range
            frmEditor_Projectile.scrlSpeed.Value = .Speed
            frmEditor_Projectile.scrlDamage.Value = .Damage
        End With

        Projectile_Changed(EditorIndex) = True

    End Sub

    Public Sub ProjectileEditorOk()
        Dim i As Long

        For i = 1 To MAX_PROJECTILES
            If Projectile_Changed(i) Then
                Call SendSaveProjectile(i)
            End If
        Next

        frmEditor_Projectile.Dispose()
        Editor = 0
        ClearChanged_Projectile()

    End Sub

    Public Sub ProjectileEditorCancel()

        Editor = 0
        frmEditor_Projectile.Dispose()
        ClearChanged_Projectile()
        ClearProjectiles()
        SendRequestProjectiles()

    End Sub

    Public Sub ClearChanged_Projectile()
        Dim i As Long

        For i = 0 To MAX_PROJECTILES
            Projectile_Changed(i) = False
        Next

    End Sub

#End Region
End Module
