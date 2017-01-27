Imports System.Drawing
Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Module ClientParties

#Region "Types and Globals"
    Public Party As PartyRec

    Public Structure PartyRec
        Dim Leader As Integer
        Dim Member() As Integer
        Dim MemberCount As Integer
    End Structure
#End Region

#Region "Incoming Packets"
    Sub Packet_PartyInvite(ByVal Data() As Byte)
        Dim Buffer As New ByteBuffer, Name As String

        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPartyInvite Then Exit Sub

        Name = Buffer.ReadString

        DialogType = DIALOGUE_TYPE_PARTY

        DialogMsg1 = "Party Invite"
        DialogMsg2 = Trim$(Name) & " has invited you to a party. Would you like to join?"

        UpdateDialog = True

        Buffer = Nothing
    End Sub

    Sub Packet_PartyUpdate(ByVal Data() As Byte)
        Dim Buffer As New ByteBuffer, I As Integer, InParty As Integer

        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPartyUpdate Then Exit Sub

        InParty = Buffer.ReadInteger

        ' exit out if we're not in a party
        If InParty = 0 Then
            ClearParty()
            ' exit out early
            Buffer = Nothing
            Exit Sub
        End If

        ' carry on otherwise
        Party.Leader = Buffer.ReadInteger
        For I = 1 To MAX_PARTY_MEMBERS
            Party.Member(I) = Buffer.ReadInteger
        Next
        Party.MemberCount = Buffer.ReadInteger

        Buffer = Nothing
    End Sub

    Sub Packet_PartyVitals(ByVal Data() As Byte)
        Dim Buffer As New ByteBuffer
        Dim playerNum As Integer, partyIndex As Integer

        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPartyVitals Then Exit Sub

        ' which player?
        playerNum = Buffer.ReadInteger

        ' find the party number
        For I = 1 To MAX_PARTY_MEMBERS
            If Party.Member(I) = playerNum Then
                partyIndex = I
            End If
        Next

        ' exit out if wrong data
        If partyIndex <= 0 Or partyIndex > MAX_PARTY_MEMBERS Then Exit Sub

        ' set vitals
        Player(playerNum).MaxHP = Buffer.ReadInteger
        Player(playerNum).Vital(Vitals.HP) = Buffer.ReadInteger

        Player(playerNum).MaxMP = Buffer.ReadInteger
        Player(playerNum).Vital(Vitals.MP) = Buffer.ReadInteger

        Player(playerNum).MaxSP = Buffer.ReadInteger
        Player(playerNum).Vital(Vitals.SP) = Buffer.ReadInteger

        Buffer = Nothing
    End Sub
#End Region

#Region "Outgoing Packets"
    Public Sub SendPartyRequest(ByVal Name As String)
        Dim Buffer As New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CRequestParty)
        Buffer.WriteString(Name)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendAcceptParty()
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CAcceptParty)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendDeclineParty()
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CDeclineParty)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendLeaveParty()
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CLeaveParty)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendPartyChatMsg(ByVal Text As String)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CPartyChatMsg)
        Buffer.WriteString(Text)

        SendData(Buffer.ToArray)
        Buffer = Nothing
    End Sub
#End Region

    Sub ClearParty()
        Party = New PartyRec With {
            .Leader = 0,
            .MemberCount = 0
        }
        ReDim Party.Member(MAX_PARTY_MEMBERS)
    End Sub

    Public Sub DrawParty()
        Dim I As Long, X As Long, Y As Long, barwidth As Long, playerNum As Long, theName As String
        Dim rec(1) As Rectangle

        ' render the window

        ' draw the bars
        If Party.Leader > 0 Then ' make sure we're in a party
            ' draw leader
            playerNum = Party.Leader
            ' name
            theName = Trim$(GetPlayerName(playerNum))
            ' draw name
            Y = 100
            X = 10
            DrawText(X, Y, theName, SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow)

            ' draw hp
            If Player(playerNum).Vital(Vitals.HP) > 0 Then
                ' calculate the width to fill
                barwidth = ((Player(playerNum).Vital(Vitals.HP) / (GetPlayerMaxVital(playerNum, Vitals.HP)) * 64))
                ' draw bars
                rec(1) = New Rectangle(X, Y, barwidth, 6)
                Dim rectShape As New RectangleShape(New Vector2f(barwidth, 6))
                rectShape.Position = New Vector2f(X, Y + 15)
                rectShape.FillColor = SFML.Graphics.Color.Red
                GameWindow.Draw(rectShape)
            End If
            ' draw mp
            If Player(playerNum).Vital(Vitals.MP) > 0 Then
                ' calculate the width to fill
                barwidth = ((Player(playerNum).Vital(Vitals.MP) / (GetPlayerMaxVital(playerNum, Vitals.MP)) * 64))
                ' draw bars
                rec(1) = New Rectangle(X, Y, barwidth, 6)
                Dim rectShape2 As New RectangleShape(New Vector2f(barwidth, 6))
                rectShape2.Position = New Vector2f(X, Y + 24)
                rectShape2.FillColor = SFML.Graphics.Color.Blue
                GameWindow.Draw(rectShape2)
            End If

            ' draw members
            For I = 1 To MAX_PARTY_MEMBERS
                If Party.Member(I) > 0 Then
                    If Party.Member(I) <> Party.Leader Then
                        ' cache the index
                        playerNum = Party.Member(I)
                        ' name
                        theName = Trim$(GetPlayerName(playerNum))
                        ' draw name
                        Y = 100 + ((I - 1) * 30)

                        DrawText(X, Y, theName, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                        ' draw hp
                        Y = 115 + ((I - 1) * 30)

                        ' make sure we actually have the data before rendering
                        If GetPlayerVital(playerNum, Vitals.HP) > 0 And GetPlayerMaxVital(playerNum, Vitals.HP) > 0 Then
                            barwidth = ((Player(playerNum).Vital(Vitals.HP) / (GetPlayerMaxVital(playerNum, Vitals.HP)) * 64))
                        End If
                        rec(1) = New Rectangle(X, Y, barwidth, 6)
                        Dim rectShape As New RectangleShape(New Vector2f(barwidth, 6))
                        rectShape.Position = New Vector2f(X, Y)
                        rectShape.FillColor = SFML.Graphics.Color.Red
                        GameWindow.Draw(rectShape)
                        ' draw mp
                        Y = 115 + ((I - 1) * 30)
                        ' make sure we actually have the data before rendering
                        If GetPlayerVital(playerNum, Vitals.MP) > 0 And GetPlayerMaxVital(playerNum, Vitals.MP) > 0 Then
                            barwidth = ((Player(playerNum).Vital(Vitals.MP) / (GetPlayerMaxVital(playerNum, Vitals.MP)) * 64))
                        End If
                        rec(1) = New Rectangle(X, Y, barwidth, 6)
                        Dim rectShape2 As New RectangleShape(New Vector2f(barwidth, 6))
                        rectShape2.Position = New Vector2f(X, Y + 8)
                        rectShape2.FillColor = SFML.Graphics.Color.Blue
                        GameWindow.Draw(rectShape2)
                    End If
                End If
            Next
        End If
    End Sub
End Module