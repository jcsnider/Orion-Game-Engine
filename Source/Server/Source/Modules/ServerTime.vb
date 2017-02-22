Imports Orion

Public Module ServerTime
    Sub InitTime()
        ' Add handlers to time events
        AddHandler Time.Instance.OnTimeChanged, AddressOf HandleTimeChanged
        AddHandler Time.Instance.OnTimeOfDayChanged, AddressOf HandleTimeOfDayChanged
        AddHandler Time.Instance.OnTimeSync, AddressOf HandleTimeOfDayChanged

        ' Prepare the time instance
        Time.Instance.Time = Date.Now
        Time.Instance.GameSpeed = 1
    End Sub

    Sub HandleTimeChanged(ByRef source As Time)
        UpdateCaption()
    End Sub

    Sub HandleTimeOfDayChanged(ByRef source As Time)
        SendTimeToAll()
    End Sub

    Sub HandleTimeSync(ByRef source As Time)
        SendGameClockToAll()
    End Sub

    Sub SendGameClockTo(ByVal Index As Integer)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SClock)
        Buffer.WriteInteger(Time.Instance.GameSpeed)
        Buffer.WriteBytes(BitConverter.GetBytes(Time.Instance.Time.Ticks))
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Sub SendGameClockToAll()
        Dim I As Integer

        For I = 1 To GetTotalPlayersOnline()
            If IsPlaying(I) Then
                SendGameClockTo(I)
            End If
        Next
    End Sub

    Sub SendTimeTo(ByVal Index As Integer)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ServerPackets.STime)
        Buffer.WriteByte(Time.Instance.TimeOfDay)
        SendDataTo(Index, Buffer.ToArray)

        Buffer = Nothing
    End Sub

    Sub SendTimeToAll()
        Dim I As Integer

        For I = 1 To GetTotalPlayersOnline()
            If IsPlaying(I) Then
                SendTimeTo(I)
            End If
        Next

    End Sub
End Module
