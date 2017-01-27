Imports System.Windows.Forms
Imports SFML.Graphics

Public Module ClientHousing
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
        Dim buffer As New ByteBuffer, i As Integer

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

    Sub Packet_HouseOffer(ByVal Data() As Byte)
        Dim buffer As New ByteBuffer, i As Integer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SBuyHouse Then Exit Sub

        i = buffer.ReadInteger

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
        Dim buffer As New ByteBuffer, i As Integer

        buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If buffer.ReadInteger <> ServerPackets.SVisit Then Exit Sub

        i = buffer.ReadInteger

        DialogType = DIALOGUE_TYPE_VISIT

        DialogMsg1 = "You have been invited to visit " & Trim$(GetPlayerName(i)) & "'s house."
        DialogMsg2 = ""
        DialogMsg3 = ""

        buffer = Nothing

        UpdateDialog = True

    End Sub

    Sub Packet_Furniture(ByVal Data() As Byte)
        Dim buffer As New ByteBuffer, i As Integer

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
        Dim buffer As New ByteBuffer
        Dim i As Integer

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
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(EditorPackets.RequestEditHouse)

        SendData(buffer.ToArray)
        buffer = Nothing

    End Sub

    Public Sub SendBuyHouse(ByVal Accepted As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CBuyHouse)
        buffer.WriteInteger(Accepted)

        SendData(buffer.ToArray)
        buffer = Nothing
    End Sub

    Public Sub SendInvite(ByVal Name As String)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CVisit)
        buffer.WriteString(Name)

        SendData(buffer.ToArray)
        buffer = Nothing
    End Sub

    Public Sub SendVisit(ByVal Accepted As Byte)
        Dim buffer As New ByteBuffer

        buffer.WriteInteger(ClientPackets.CAcceptVisit)
        buffer.WriteInteger(Accepted)

        SendData(buffer.ToArray)
        buffer = Nothing
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
                    tmpSprite.Position = New SFML.System.Vector2f(X, Y)
                    GameWindow.Draw(tmpSprite)
                End If
            Next
        Next

    End Sub
#End Region

End Module