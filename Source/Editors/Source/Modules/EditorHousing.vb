Imports System.Windows.Forms
Imports SFML.Graphics

Public Module EditorHousing
#Region "Globals & Types"
    Public MAX_HOUSES As Integer = 100

    Public FurnitureCount As Integer
    Public FurnitureHouse As Integer
    Public FurnitureSelected As Integer
    Public HouseTileIndex As Integer

    Public House() As HouseRec
    Public HouseConfig() As HouseRec
    Public Furniture() As FurnitureRec
    Public NumFurniture As Integer
    Public House_Changed(0 To MAX_HOUSES) As Boolean
    Public HouseEdit As Boolean

    Structure HouseRec
        Dim ConfigName As String
        Dim BaseMap As Integer
        Dim Price As Integer
        Dim MaxFurniture As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Structure FurnitureRec
        Dim ItemNum As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Structure PlayerHouseRec
        Dim HouseIndex As Integer
        Dim FurnitureCount As Integer
        Dim Furniture() As FurnitureRec
    End Structure
#End Region

#Region "Incoming Packets"
    Sub Packet_HouseConfigurations(ByVal Data() As Byte)
        Dim buffer As ByteBuffer, i As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SHouseConfigs Then Exit Sub

        For i = 1 To MAX_HOUSES
            HouseConfig(i).ConfigName = buffer.ReadString
            HouseConfig(i).BaseMap = buffer.ReadInteger
            HouseConfig(i).MaxFurniture = buffer.ReadInteger
            HouseConfig(i).Price = buffer.ReadInteger
        Next
        buffer = Nothing

    End Sub

    Sub Packet_Furniture(ByVal Data() As Byte)
        Dim buffer As ByteBuffer, i As Integer

        buffer = New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SFurniture Then Exit Sub

        FurnitureHouse = buffer.ReadInteger
        FurnitureCount = buffer.ReadInteger

        ReDim Furniture(FurnitureCount)
        If FurnitureCount > 0 Then
            For i = 1 To FurnitureCount
                Furniture(i).ItemNum = buffer.ReadInteger
                Furniture(i).X = buffer.ReadInteger
                Furniture(i).Y = buffer.ReadInteger
            Next
        End If

        buffer = Nothing

    End Sub

    Sub Packet_EditHouses(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim i As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SHouseEdit Then Exit Sub

        For i = 1 To MAX_HOUSES
            With House(i)
                .ConfigName = Trim$(buffer.ReadString)
                .BaseMap = buffer.ReadInteger
                .X = buffer.ReadInteger
                .Y = buffer.ReadInteger
                .Price = buffer.ReadInteger
                .MaxFurniture = buffer.ReadInteger
            End With
        Next

        HouseEdit = True

        buffer = Nothing

    End Sub
#End Region

#Region "Outgoing Packets"
    Public Sub SendRequestEditHouse()
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        buffer.WriteInteger(EditorPackets.RequestEditHouse)
        SendData(buffer.ToArray)

        buffer = Nothing

    End Sub

    Public Sub SendBuyHouse(ByVal Accepted As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteInteger(ClientPackets.CBuyHouse)
        buffer.WriteInteger(Accepted)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub

    Public Sub SendInvite(ByVal Name As String)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteInteger(ClientPackets.CVisit)
        buffer.WriteString(Name)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub

    Public Sub SendVisit(ByVal Accepted As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteInteger(ClientPackets.CAcceptVisit)
        buffer.WriteInteger(Accepted)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub
#End Region

#Region "Editor"
    Public Sub HouseEditorInit()
        Dim i As Integer

        If frmEditor_House.Visible = False Then Exit Sub

        EditorIndex = frmEditor_House.lstIndex.SelectedIndex + 1
        i = EditorIndex

        With House(EditorIndex)
            frmEditor_House.txtName.Text = Trim$(.ConfigName)
            FrmEditor_House.nudBaseMap.Value = .BaseMap
            FrmEditor_House.nudX.Value = .X
            FrmEditor_House.nudY.Value = .Y
            FrmEditor_House.nudPrice.Value = .Price
            FrmEditor_House.nudFurniture.Value = .MaxFurniture
        End With

        House_Changed(EditorIndex) = True

    End Sub

    Public Sub HouseEditorCancel()

        Editor = 0
        frmEditor_House.Dispose()

        ClearChanged_House()

    End Sub

    Public Sub HouseEditorOk()
        Dim i As Integer, buffer As ByteBuffer, count As Integer
        buffer = New ByteBuffer

        buffer.WriteInteger(EditorPackets.SaveHouses)

        For i = 1 To MAX_HOUSES
            If House_Changed(i) Then count = count + 1
        Next

        buffer.WriteInteger(count)

        If count > 0 Then
            For i = 1 To MAX_HOUSES
                If House_Changed(i) Then
                    buffer.WriteInteger(i)
                    buffer.WriteString(Trim$(House(i).ConfigName))
                    buffer.WriteInteger(House(i).BaseMap)
                    buffer.WriteInteger(House(i).X)
                    buffer.WriteInteger(House(i).Y)
                    buffer.WriteInteger(House(i).Price)
                    buffer.WriteInteger(House(i).MaxFurniture)
                End If
            Next
        End If

        SendData(buffer.ToArray)
        buffer = Nothing
        frmEditor_House.Dispose()
        Editor = 0

        ClearChanged_House()

    End Sub

    Public Sub ClearChanged_House()

        For i = 1 To MAX_HOUSES
            House_Changed(i) = Nothing
        Next i

        ReDim House_Changed(0 To MAX_HOUSES)
    End Sub

#End Region

#Region "Drawing"
    Public Sub CheckFurniture()
        Dim i As Integer
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Furniture\" & i & GFX_EXT)
            NumFurniture = NumFurniture + 1
            i = i + 1
        End While

        If NumFurniture = 0 Then Exit Sub
    End Sub

    Public Sub DrawFurniture(ByVal Index As Integer, Layer As Integer)
        Dim i As Integer, ItemNum As Integer
        Dim X As Integer, Y As Integer, Width As Integer, Height As Integer, X1 As Integer, Y1 As Integer

        ItemNum = Furniture(Index).ItemNum

        If Item(ItemNum).Type <> ItemType.FURNITURE Then Exit Sub

        i = Item(ItemNum).Data2

        If FurnitureGFXInfo(i).IsLoaded = False Then
            LoadTexture(i, 10)
        End If

        'seeying we still use it, lets update timer
        With SkillIconsGFXInfo(i)
            .TextureTimer = GetTickCount() + 100000
        End With

        Width = Item(ItemNum).FurnitureWidth
        Height = Item(ItemNum).FurnitureHeight

        If Width > 4 Then Width = 4
        If Height > 4 Then Height = 4
        If i <= 0 Or i > NumFurniture Then Exit Sub

        ' make sure it's not out of map
        If Furniture(Index).X > Map.MaxX Then Exit Sub
        If Furniture(Index).Y > Map.MaxY Then Exit Sub

        For X1 = 0 To Width - 1
            For Y1 = 0 To Height
                If Item(Furniture(Index).ItemNum).FurnitureFringe(X1, Y1) = Layer Then
                    ' Set base x + y, then the offset due to size
                    X = (Furniture(Index).X * 32) + (X1 * 32)
                    Y = (Furniture(Index).Y * 32 - (Height * 32)) + (Y1 * 32)
                    X = ConvertMapX(X)
                    Y = ConvertMapY(Y)

                    Dim tmpSprite As Sprite = New Sprite(FurnitureGFX(i))
                    tmpSprite.TextureRect = New IntRect(0 + (X1 * 32), 0 + (Y1 * 32), 32, 32)
                    tmpSprite.Position = New SFML.System.Vector2f(X, Y)
                    GameWindow.Draw(tmpSprite)
                End If
            Next
        Next

    End Sub
#End Region

End Module
