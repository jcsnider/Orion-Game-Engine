Imports System.Windows.Forms
Imports SFML.Graphics

Public Module ClientProjectiles
#Region "Defines"
    Public Const MAX_PROJECTILES As Integer = 255
    Public Projectiles(MAX_PROJECTILES) As ProjectileRec
    Public MapProjectiles(MAX_PROJECTILES) As MapProjectileRec
    Public NumProjectiles As Integer
    Public InitProjectileEditor As Boolean
    Public Const EDITOR_PROJECTILE As Byte = 10
    Public Projectile_Changed(MAX_PROJECTILES) As Boolean
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
        Dim dir As Byte
        Dim Range As Integer
        Dim TravelTime As Integer
        Dim Timer As Integer
    End Structure
#End Region

#Region "Sending"

    Sub SendRequestProjectiles()
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CRequestProjectiles)

        SendData(buffer.ToArray())
        buffer = Nothing

    End Sub

    Sub SendClearProjectile(ByVal ProjectileNum As Integer, ByVal CollisionIndex As Integer, ByVal CollisionType As Byte, ByVal CollisionZone As Integer)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CClearProjectile)
        buffer.WriteInteger(ProjectileNum)
        buffer.WriteInteger(CollisionIndex)
        buffer.WriteInteger(CollisionType)
        buffer.WriteInteger(CollisionZone)

        SendData(buffer.ToArray())
        buffer = Nothing

    End Sub

#End Region

#Region "Recieving"

    Public Sub HandleUpdateProjectile(ByVal data() As Byte)
        Dim ProjectileNum As Integer
        Dim buffer As New ByteBuffer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SUpdateProjectile Then Exit Sub

        ProjectileNum = buffer.ReadInteger

        Projectiles(ProjectileNum).Name = buffer.ReadString
        Projectiles(ProjectileNum).Sprite = buffer.ReadInteger
        Projectiles(ProjectileNum).Range = buffer.ReadInteger
        Projectiles(ProjectileNum).Speed = buffer.ReadInteger
        Projectiles(ProjectileNum).Damage = buffer.ReadInteger

        buffer = Nothing

    End Sub

    Public Sub HandleMapProjectile(ByVal data() As Byte)
        Dim buffer As New ByteBuffer
        Dim i As Integer

        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SMapProjectile Then Exit Sub

        i = buffer.ReadInteger

        With MapProjectiles(i)
            .ProjectileNum = buffer.ReadInteger
            .Owner = buffer.ReadInteger
            .OwnerType = buffer.ReadInteger
            .dir = buffer.ReadInteger
            .X = buffer.ReadInteger
            .Y = buffer.ReadInteger
            .Range = 0
            .Timer = GetTickCount() + 60000
        End With

        buffer = Nothing

    End Sub

#End Region

#Region "Database"
    Sub ClearProjectiles()
        Dim i As Integer

        For i = 1 To MAX_PROJECTILES
            ClearProjectile(i)
        Next

    End Sub

    Sub ClearProjectile(ByVal Index As Integer)

        Projectiles(Index).Name = ""
        Projectiles(Index).Sprite = 0
        Projectiles(Index).Range = 0
        Projectiles(Index).Speed = 0
        Projectiles(Index).Damage = 0

    End Sub

    Sub ClearMapProjectile(ByVal ProjectileNum As Integer)

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

    Public Sub CheckProjectiles()
        Dim i As Integer

        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "projectiles\" & i & GFX_EXT)

            NumProjectiles = NumProjectiles + 1
            i = i + 1
        End While

        If NumProjectiles = 0 Then Exit Sub

    End Sub

    Public Sub DrawProjectile(ByVal ProjectileNum As Integer)
        Dim rec As RECT
        Dim CanClearProjectile As Boolean
        Dim CollisionIndex As Integer
        Dim CollisionType As Byte
        Dim CollisionZone As Integer
        Dim XOffset As Integer, YOffset As Integer
        Dim X As Integer, Y As Integer
        Dim i As Integer
        Dim Sprite As Integer

        ' check to see if it's time to move the Projectile
        If GetTickCount() > MapProjectiles(ProjectileNum).TravelTime Then
            Select Case MapProjectiles(ProjectileNum).dir
                Case Direction.Up
                    MapProjectiles(ProjectileNum).Y = MapProjectiles(ProjectileNum).Y - 1
                Case Direction.Down
                    MapProjectiles(ProjectileNum).Y = MapProjectiles(ProjectileNum).Y + 1
                Case Direction.Left
                    MapProjectiles(ProjectileNum).X = MapProjectiles(ProjectileNum).X - 1
                Case Direction.Right
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
            If Map.Tile(X, Y).Type = TileType.Blocked Then CanClearProjectile = True
        End If

        'Check for npc collision
        For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).X = X And MapNpc(i).Y = Y Then
                CanClearProjectile = True
                CollisionIndex = i
                CollisionType = TargetType.Npc
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
                    CollisionType = TargetType.Player
                    CollisionZone = -1
                    If MapProjectiles(ProjectileNum).OwnerType = TargetType.Player Then
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
            If (MapProjectiles(ProjectileNum).OwnerType = TargetType.Player And MapProjectiles(ProjectileNum).Owner = MyIndex) Then
                SendClearProjectile(ProjectileNum, CollisionIndex, CollisionType, CollisionZone)
            End If

            ClearMapProjectile(ProjectileNum)
            Exit Sub
        End If

        Sprite = Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Sprite
        If Sprite < 1 Or Sprite > NumProjectiles Then Exit Sub

        If ProjectileGFXInfo(Sprite).IsLoaded = False Then
            LoadTexture(Sprite, 11)
        End If

        'seeying we still use it, lets update timer
        With ProjectileGFXInfo(Sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        ' src rect
        With rec
            .top = 0
            .bottom = ProjectileGFXInfo(Sprite).Height
            .left = MapProjectiles(ProjectileNum).dir * PIC_X
            .right = .left + PIC_X
        End With

        'Find the offset
        Select Case MapProjectiles(ProjectileNum).dir
            Case Direction.Up
                YOffset = ((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_Y
            Case Direction.Down
                YOffset = -((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_Y
            Case Direction.Left
                XOffset = ((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_X
            Case Direction.Right
                XOffset = -((MapProjectiles(ProjectileNum).TravelTime - GetTickCount()) / Projectiles(MapProjectiles(ProjectileNum).ProjectileNum).Speed) * PIC_X
        End Select

        X = ConvertMapX(X * PIC_X)
        Y = ConvertMapY(Y * PIC_Y)

        Dim tmpSprite As Sprite = New Sprite(ProjectileGFX(Sprite))
        tmpSprite.TextureRect = New IntRect(rec.left, rec.top, 32, 32)
        tmpSprite.Position = New SFML.Window.Vector2f(X, Y)
        GameWindow.Draw(tmpSprite)

    End Sub

#End Region
End Module