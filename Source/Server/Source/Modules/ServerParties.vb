Module ServerParties
#Region "Types and Globals"
    Public Party(MAX_PARTIES) As PartyRec

    Public Structure PartyRec
        Dim Leader As Long
        Dim Member() As Long
        Dim MemberCount As Long
    End Structure
#End Region

#Region "Outgoing Packets"
    Sub SendDataToParty(ByVal PartyNum As Integer, ByRef Data() As Byte)
        Dim i As Integer

        For i = 1 To Party(PartyNum).MemberCount
            If Party(PartyNum).Member(i) > 0 Then
                SendDataTo(Party(PartyNum).Member(i), Data)
            End If
        Next
    End Sub

    Sub SendPartyInvite(ByVal Index As Integer, ByVal Target As Integer)
        Dim Buffer As New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPartyInvite)

        Buffer.WriteString(Trim$(Player(Target).Character(TempPlayer(Target).CurChar).Name))

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub SendPartyUpdate(ByVal PartyNum As Integer)
        Dim Buffer As New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPartyUpdate)

        Buffer.WriteInteger(1)
        Buffer.WriteInteger(Party(PartyNum).Leader)
        For i = 1 To MAX_PARTY_MEMBERS
            Buffer.WriteInteger(Party(PartyNum).Member(i))
        Next
        Buffer.WriteInteger(Party(PartyNum).MemberCount)

        SendDataToParty(PartyNum, Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendPartyUpdateTo(ByVal Index As Integer)
        Dim Buffer As New ByteBuffer, i As Integer, partyNum As Integer

        Buffer.WriteInteger(ServerPackets.SPartyUpdate)

        ' check if we're in a party
        partyNum = TempPlayer(Index).InParty
        If partyNum > 0 Then
            ' send party data
            Buffer.WriteInteger(1)
            Buffer.WriteInteger(Party(partyNum).Leader)
            For i = 1 To MAX_PARTY_MEMBERS
                Buffer.WriteInteger(Party(partyNum).Member(i))
            Next
            Buffer.WriteInteger(Party(partyNum).MemberCount)
        Else
            ' send clear command
            Buffer.WriteInteger(0)
        End If

        SendDataTo(Index, Buffer.ToArray)
        Buffer = Nothing
    End Sub

    Sub SendPartyVitals(ByVal PartyNum As Integer, ByVal Index As Integer)
        Dim Buffer As ByteBuffer, i As Integer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SPartyVitals)
        Buffer.WriteInteger(Index)

        For i = 1 To Vitals.Count - 1
            Buffer.WriteInteger(GetPlayerMaxVital(Index, i))
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).Vital(i))
        Next

        SendDataToParty(PartyNum, Buffer.ToArray)
        Buffer = Nothing
    End Sub
#End Region

#Region "Incoming Packets"
    Public Sub Packet_PartyRquest(ByVal Index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Integer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CRequestParty Then Exit Sub

        n = FindPlayer(buffer.ReadString)
        buffer = Nothing

        ' Prevent partying with self
        If TempPlayer(Index).Target = Index Then Exit Sub
        ' make sure it's a valid target
        If TempPlayer(Index).TargetType <> TargetType.Player Then Exit Sub

        ' make sure they're connected and on the same map
        If Not IsConnected(TempPlayer(Index).Target) Or Not IsPlaying(TempPlayer(Index).Target) Then Exit Sub
        If GetPlayerMap(TempPlayer(Index).Target) <> GetPlayerMap(Index) Then Exit Sub

        ' init the request
        Party_Invite(Index, TempPlayer(Index).Target)
    End Sub

    Public Sub Packet_AcceptParty(ByVal Index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CAcceptParty Then Exit Sub

        Party_InviteAccept(TempPlayer(Index).PartyInvite, Index)

        buffer = Nothing
    End Sub

    Public Sub Packet_DeclineParty(ByVal Index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CDeclineParty Then Exit Sub

        Party_InviteDecline(TempPlayer(Index).PartyInvite, Index)

        buffer = Nothing
    End Sub

    Public Sub Packet_LeaveParty(ByVal Index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CLeaveParty Then Exit Sub

        Party_PlayerLeave(Index)

        buffer = Nothing
    End Sub

    Public Sub Packet_PartyChatMsg(ByVal Index As Integer, ByVal data() As Byte)
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadInteger <> ClientPackets.CPartyChatMsg Then Exit Sub

        PartyMsg(Index, buffer.ReadString)

        buffer = Nothing
    End Sub
#End Region

    Sub ClearParties()
        Dim i As Integer

        For i = 1 To MAX_PARTIES
            ClearParty(i)
        Next

    End Sub

    Sub ClearParty(ByVal PartyNum As Integer)
        Party(PartyNum) = Nothing
        Party(PartyNum).Leader = 0
        Party(PartyNum).MemberCount = 0
        ReDim Party(PartyNum).Member(MAX_PARTY_MEMBERS)
    End Sub

    Public Sub PartyMsg(ByVal PartyNum As Integer, ByVal Msg As String)
        Dim i As Integer

        ' send message to all people
        For i = 1 To MAX_PARTY_MEMBERS
            ' exist?
            If Party(PartyNum).Member(i) > 0 Then
                ' make sure they're logged on
                If IsConnected(Party(PartyNum).Member(i)) And IsPlaying(Party(PartyNum).Member(i)) Then
                    PlayerMsg(Party(PartyNum).Member(i), Msg, ColorType.BrightBlue)
                End If
            End If
        Next
    End Sub

    Private Sub Party_RemoveFromParty(ByVal Index As Integer, ByVal PartyNum As Integer)
        For i = 1 To MAX_PARTY_MEMBERS
            If Party(PartyNum).Member(i) = Index Then
                Party(PartyNum).Member(i) = 0
                TempPlayer(Index).InParty = 0
                TempPlayer(Index).PartyInvite = 0
                Exit For
            End If
        Next
        Party_CountMembers(PartyNum)
        SendPartyUpdate(PartyNum)
        SendPartyUpdateTo(Index)
    End Sub

    Public Sub Party_PlayerLeave(ByVal Index As Integer)
        Dim PartyNum As Integer, i As Integer

        PartyNum = TempPlayer(Index).InParty

        If PartyNum > 0 Then
            ' find out how many members we have
            Party_CountMembers(PartyNum)
            ' make sure there's more than 2 people
            If Party(PartyNum).MemberCount > 2 Then

                ' check if leader
                If Party(PartyNum).Leader = Index Then
                    ' set next person down as leader
                    For i = 1 To MAX_PARTY_MEMBERS
                        If Party(PartyNum).Member(i) > 0 And Party(PartyNum).Member(i) <> Index Then
                            Party(PartyNum).Leader = Party(PartyNum).Member(i)
                            PartyMsg(PartyNum, String.Format("{0} is now the party leader.", GetPlayerName(i)))
                            Exit For
                        End If
                    Next
                    ' leave party
                    PartyMsg(PartyNum, String.Format("{0} has left the party.", GetPlayerName(Index)))
                    Party_RemoveFromParty(Index, PartyNum)
                Else
                    ' not the leader, just leave
                    PartyMsg(PartyNum, String.Format("{0} has left the party.", GetPlayerName(Index)))
                    Party_RemoveFromParty(Index, PartyNum)
                End If
            Else
                ' find out how many members we have
                Party_CountMembers(PartyNum)
                ' only 2 people, disband
                PartyMsg(PartyNum, "The party has been disbanded.")

                ' clear out everyone's party
                For i = 1 To MAX_PARTY_MEMBERS
                    Index = Party(PartyNum).Member(i)
                    ' player exist?
                    If Index > 0 Then
                        Party_RemoveFromParty(Index, PartyNum)
                    End If
                Next
                ' clear out the party itself
                ClearParty(PartyNum)
            End If
        End If
    End Sub

    Public Sub Party_Invite(ByVal Index As Integer, ByVal Target As Integer)
        Dim PartyNum As Integer, i As Integer

        ' check if the person is a valid target
        If Not IsConnected(Target) Or Not IsPlaying(Target) Then Exit Sub

        ' make sure they're not busy
        If TempPlayer(Target).PartyInvite > 0 Or TempPlayer(Target).TradeRequest > 0 Then
            ' they've already got a request for trade/party
            PlayerMsg(Index, "This player is busy.", ColorType.BrightRed)
            ' exit out early
            Exit Sub
        End If
        ' make syure they're not in a party
        If TempPlayer(Target).InParty > 0 Then
            ' they're already in a party
            PlayerMsg(Index, "This player is already in a party.", ColorType.BrightRed)
            'exit out early
            Exit Sub
        End If

        ' check if we're in a party
        If TempPlayer(Index).InParty > 0 Then
            PartyNum = TempPlayer(Index).InParty
            ' make sure we're the leader
            If Party(PartyNum).Leader = Index Then
                ' got a blank slot?
                For i = 1 To MAX_PARTY_MEMBERS
                    If Party(PartyNum).Member(i) = 0 Then
                        ' send the invitation
                        SendPartyInvite(Target, Index)
                        ' set the invite target
                        TempPlayer(Target).PartyInvite = Index
                        ' let them know
                        PlayerMsg(Index, "Invitation sent.", ColorType.Yellow)
                        Exit Sub
                    End If
                Next
                ' no room
                PlayerMsg(Index, "Party is full.", ColorType.BrightRed)
                Exit Sub
            Else
                ' not the leader
                PlayerMsg(Index, "You are not the party leader.", ColorType.BrightRed)
                Exit Sub
            End If
        Else
            ' not in a party - doesn't matter!
            SendPartyInvite(Target, Index)
            ' set the invite target
            TempPlayer(Target).PartyInvite = Index
            ' let them know
            PlayerMsg(Index, "Invitation sent.", ColorType.Yellow)
            Exit Sub
        End If
    End Sub

    Public Sub Party_InviteAccept(ByVal Index As Integer, ByVal Target As Integer)
        Dim partyNum As Integer, i As Integer

        ' check if already in a party
        If TempPlayer(Index).InParty > 0 Then
            ' get the partynumber
            partyNum = TempPlayer(Index).InParty
            ' got a blank slot?
            For i = 1 To MAX_PARTY_MEMBERS
                If Party(partyNum).Member(i) = 0 Then
                    'add to the party
                    Party(partyNum).Member(i) = Target
                    ' recount party
                    Party_CountMembers(partyNum)
                    ' send update to all - including new player
                    SendPartyUpdate(partyNum)
                    SendPartyVitals(partyNum, Target)
                    ' let everyone know they've joined
                    PartyMsg(partyNum, String.Format("{0} has joined the party.", GetPlayerName(Target)))
                    ' add them in
                    TempPlayer(Target).InParty = partyNum
                    Exit Sub
                End If
            Next
            ' no empty slots - let them know
            PlayerMsg(Index, "Party is full.", ColorType.BrightRed)
            PlayerMsg(Target, "Party is full.", ColorType.BrightRed)
            Exit Sub
        Else
            ' not in a party. Create one with the new person.
            For i = 1 To MAX_PARTIES
                ' find blank party
                If Not Party(i).Leader > 0 Then
                    partyNum = i
                    Exit For
                End If
            Next
            ' create the party
            Party(partyNum).MemberCount = 2
            Party(partyNum).Leader = Index
            Party(partyNum).Member(1) = Index
            Party(partyNum).Member(2) = Target
            SendPartyUpdate(partyNum)
            SendPartyVitals(partyNum, Index)
            SendPartyVitals(partyNum, Target)

            ' let them know it's created
            PartyMsg(partyNum, "Party created.")
            PartyMsg(partyNum, String.Format("{0} has joined the party.", GetPlayerName(Index)))

            ' clear the invitation
            TempPlayer(Target).PartyInvite = 0

            ' add them to the party
            TempPlayer(Index).InParty = partyNum
            TempPlayer(Target).InParty = partyNum
            Exit Sub
        End If
    End Sub

    Public Sub Party_InviteDecline(ByVal Index As Integer, ByVal Target As Integer)
        PlayerMsg(Index, String.Format("{0} has declined to join your party.", GetPlayerName(Target)), ColorType.BrightRed)
        PlayerMsg(Target, "You declined to join the party.", ColorType.Yellow)
        ' clear the invitation
        TempPlayer(Target).PartyInvite = 0
    End Sub

    Public Sub Party_CountMembers(ByVal PartyNum As Integer)
        Dim i As Integer, highIndex As Integer, x As Integer

        ' find the high index
        For i = MAX_PARTY_MEMBERS To 1 Step -1
            If Party(PartyNum).Member(i) > 0 Then
                highIndex = i
                Exit For
            End If
        Next
        ' count the members
        For i = 1 To MAX_PARTY_MEMBERS
            ' we've got a blank member
            If Party(PartyNum).Member(i) = 0 Then
                ' is it lower than the high index?
                If i < highIndex Then
                    ' move everyone down a slot
                    For x = i To MAX_PARTY_MEMBERS - 1
                        Party(PartyNum).Member(x) = Party(PartyNum).Member(x + 1)
                        Party(PartyNum).Member(x + 1) = 0
                    Next
                Else
                    ' not lower - highindex is count
                    Party(PartyNum).MemberCount = highIndex
                    Exit Sub
                End If
            End If
            ' check if we've reached the max
            If i = MAX_PARTY_MEMBERS Then
                If highIndex = i Then
                    Party(PartyNum).MemberCount = MAX_PARTY_MEMBERS
                    Exit Sub
                End If
            End If
        Next
        ' if we're here it means that we need to re-count again
        Party_CountMembers(PartyNum)
    End Sub

    Public Sub Party_ShareExp(ByVal PartyNum As Integer, ByVal Exp As Integer, ByVal Index As Integer, ByVal MapNum As Integer)
        Dim expShare As Integer, leftOver As Integer, i As Integer, tmpIndex As Integer, LoseMemberCount As Byte

        ' check if it's worth sharing
        If Not Exp >= Party(PartyNum).MemberCount Then
            ' no party - keep exp for self
            GivePlayerEXP(Index, Exp)
            Exit Sub
        End If

        ' check members in others maps
        For i = 1 To MAX_PARTY_MEMBERS
            tmpIndex = Party(PartyNum).Member(i)
            If tmpIndex > 0 Then
                If IsConnected(tmpIndex) And IsPlaying(tmpIndex) Then
                    If GetPlayerMap(tmpIndex) <> MapNum Then
                        LoseMemberCount = LoseMemberCount + 1
                    End If
                End If
            End If
        Next

        ' find out the equal share
        expShare = Exp \ (Party(PartyNum).MemberCount - LoseMemberCount)
        leftOver = Exp Mod (Party(PartyNum).MemberCount - LoseMemberCount)

        ' loop through and give everyone exp
        For i = 1 To MAX_PARTY_MEMBERS
            tmpIndex = Party(PartyNum).Member(i)
            ' existing member?
            If tmpIndex > 0 Then
                ' playing?
                If IsConnected(tmpIndex) And IsPlaying(tmpIndex) Then
                    If GetPlayerMap(tmpIndex) = MapNum Then
                        ' give them their share
                        GivePlayerEXP(tmpIndex, expShare)
                    End If
                End If
            End If
        Next

        ' give the remainder to a random member
        If Not leftOver = 0 Then
            tmpIndex = Party(PartyNum).Member(Random(1, Party(PartyNum).MemberCount))
            ' give the exp
            GivePlayerEXP(tmpIndex, leftOver)
        End If

    End Sub

    Sub PartyWarp(ByVal Index As Long, ByVal MapNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim i As Integer

        If TempPlayer(Index).InParty Then
            If Party(TempPlayer(Index).InParty).Leader Then
                For i = 1 To Party(TempPlayer(Index).InParty).MemberCount
                    PlayerWarp(Party(TempPlayer(Index).InParty).Member(i), MapNum, X, Y)
                Next
            End If
        End If

    End Sub

    Public Function IsPlayerInParty(ByVal Index As Integer) As Boolean
        If Index < 0 Or Index > MAX_PLAYERS Or Not TempPlayer(Index).InGame Then Exit Function
        If TempPlayer(Index).InParty > 0 Then IsPlayerInParty = True
    End Function

    Public Function GetPlayerParty(ByVal Index As Integer) As Integer
        If Index < 0 Or Index > MAX_PLAYERS Or Not TempPlayer(Index).InGame Then Exit Function
        GetPlayerParty = TempPlayer(Index).InParty
    End Function

End Module