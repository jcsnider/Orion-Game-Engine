Imports System.Windows.Forms
Imports SFML.Graphics

Public Module ClientHousing
#Region "Globals & Types"
    Public MAX_HOUSES As Long = 100

    Public FurnitureCount As Long
    Public FurnitureHouse As Long
    Public FurnitureSelected As Long
    Public HouseTileIndex As Long

    Public House() As HouseRec
    Public HouseConfig() As HouseRec
    Public Furniture() As FurnitureRec
    Public NumFurniture As Long
    Public House_Changed(0 To MAX_HOUSES) As Boolean
    Public HouseEdit As Boolean

    Structure HouseRec
        Dim ConfigName As String
        Dim BaseMap As Long
        Dim Price As Long
        Dim MaxFurniture As Long
        Dim X As Long
        Dim Y As Long
    End Structure

    Structure FurnitureRec
        Dim ItemNum As Long
        Dim X As Long
        Dim Y As Long
    End Structure

    Structure PlayerHouseRec
        Dim HouseIndex As Long
        Dim FurnitureCount As Long
        Dim Furniture() As FurnitureRec
    End Structure
#End Region

#Region "Incoming Packets"
    Sub Packet_HouseConfigurations(ByVal Data() As Byte)
        Dim buffer As ByteBuffer, i As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadLong <> ServerPackets.SHouseConfigs Then Exit Sub

        For i = 1 To MAX_HOUSES
            HouseConfig(i).ConfigName = buffer.ReadString
            HouseConfig(i).BaseMap = buffer.ReadLong
            HouseConfig(i).MaxFurniture = buffer.ReadLong
            HouseConfig(i).Price = buffer.ReadLong
        Next
        buffer = Nothing

    End Sub

    Sub Packet_HouseOffer(ByVal Data() As Byte)
        Dim buffer As ByteBuffer, i As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadLong <> ServerPackets.SBuyHouse Then Exit Sub

        i = buffer.ReadLong

        buffer = Nothing

        DialogType = DIALOGUE_TYPE_BUYHOME
        If HouseConfig(i).MaxFurniture > 0 Then
            ' ask to buy house
            DialogMsg1 = "Would you like to buy the house: " & Trim$(HouseConfig(i).ConfigName)
            DialogMsg2 = "Cost: " & HouseConfig(i).Price
            DialogMsg3 = "Furniture Limit: " & HouseConfig(i).MaxFurniture
        Else
            DialogMsg1 = "Would you like to buy the house: " & Trim$(HouseConfig(i).ConfigName)
            DialogMsg2 = "Cost: " & HouseConfig(i).Price
            DialogMsg3 = "Furniture Limit: None."
        End If

        UpdateDialog = True

        buffer = Nothing

    End Sub

    Sub Packet_Visit(ByVal Data() As Byte)
        Dim buffer As ByteBuffer, i As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadLong <> ServerPackets.SVisit Then Exit Sub

        i = buffer.ReadLong

        DialogType = DIALOGUE_TYPE_VISIT

        DialogMsg1 = "You have been invited to visit " & Trim$(GetPlayerName(i)) & "'s house."
        DialogMsg2 = vbNullString
        DialogMsg3 = vbNullString

        buffer = Nothing

    End Sub

    Sub Packet_Furniture(ByVal Data() As Byte)
        Dim buffer As ByteBuffer, i As Long

        buffer = New ByteBuffer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadLong <> ServerPackets.SFurniture Then Exit Sub

        FurnitureHouse = buffer.ReadLong
        FurnitureCount = buffer.ReadLong

        ReDim Furniture(FurnitureCount)
        If FurnitureCount > 0 Then
            For i = 1 To FurnitureCount
                Furniture(i).ItemNum = buffer.ReadLong
                Furniture(i).X = buffer.ReadLong
                Furniture(i).Y = buffer.ReadLong
            Next
        End If

        buffer = Nothing

    End Sub

    Sub Packet_EditHouses(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim i As Long

        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If buffer.ReadLong <> ServerPackets.SHouseEdit Then Exit Sub

        For i = 1 To MAX_HOUSES
            With House(i)
                .ConfigName = Trim$(buffer.ReadString)
                .BaseMap = buffer.ReadLong
                .X = buffer.ReadLong
                .Y = buffer.ReadLong
                .Price = buffer.ReadLong
                .MaxFurniture = buffer.ReadLong
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

        buffer.WriteLong(ClientPackets.CRequestEditHouse)
        SendData(buffer.ToArray)

        buffer = Nothing

    End Sub

    Public Sub SendBuyHouse(ByVal Accepted As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CBuyHouse)
        buffer.WriteLong(Accepted)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub

    Public Sub SendInvite(ByVal Name As String)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CVisit)
        buffer.WriteString(Name)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub

    Public Sub SendVisit(ByVal Accepted As Byte)
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CAcceptVisit)
        buffer.WriteLong(Accepted)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub
#End Region

#Region "Editor"
    Public Sub HouseEditorInit()
        Dim i As Long

        If frmEditor_House.Visible = False Then Exit Sub

        EditorIndex = frmEditor_House.lstIndex.SelectedIndex + 1
        i = EditorIndex

        With House(EditorIndex)
            frmEditor_House.txtName.Text = Trim$(.ConfigName)
            frmEditor_House.txtBaseMap.Text = Trim$(.BaseMap)
            frmEditor_House.txtXEntrance.Text = Trim$(.X)
            frmEditor_House.txtYEntrance.Text = Trim$(.Y)
            frmEditor_House.txtHousePrice.Text = Trim$(.Price)
            frmEditor_House.txtHouseFurniture.Text = Trim$(.MaxFurniture)
        End With

        House_Changed(EditorIndex) = True

    End Sub

    Public Sub HouseEditorCancel()

        Editor = 0
        frmEditor_House.Dispose()

        ClearChanged_House()

    End Sub

    Public Sub HouseEditorOk()
        Dim i As Long, buffer As ByteBuffer, count As Long
        buffer = New ByteBuffer

        buffer.WriteLong(ClientPackets.CSaveHouses)

        For i = 1 To MAX_HOUSES
            If House_Changed(i) Then count = count + 1
        Next

        buffer.WriteLong(count)

        If count > 0 Then
            For i = 1 To MAX_HOUSES
                If House_Changed(i) Then
                    buffer.WriteLong(i)
                    buffer.WriteString(Trim$(House(i).ConfigName))
                    buffer.WriteLong(House(i).BaseMap)
                    buffer.WriteLong(House(i).X)
                    buffer.WriteLong(House(i).Y)
                    buffer.WriteLong(House(i).Price)
                    buffer.WriteLong(House(i).MaxFurniture)
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
        Dim i As Long
        i = 1

        While FileExist(Application.StartupPath & GFX_PATH & "Furniture\" & i & GFX_EXT)
            NumFurniture = NumFurniture + 1
            i = i + 1
        End While

        If NumFurniture = 0 Then Exit Sub
    End Sub

    Public Sub DrawFurniture(ByVal Index As Long, Layer As Long)
        Dim i As Long, ItemNum As Long
        Dim X As Long, Y As Long, Width As Long, Height As Long, X1 As Long, Y1 As Long

        ItemNum = Furniture(Index).ItemNum

        If Item(ItemNum).Type <> ItemType.Furniture Then Exit Sub

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
                    tmpSprite.Position = New SFML.Window.Vector2f(X, Y)
                    GameWindow.Draw(tmpSprite)
                End If
            Next
        Next

    End Sub
#End Region

End Module
