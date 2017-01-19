Public Module ServerTime

    'Time System
    Public GameClock As String
    Public GameSpeed As Integer
    Public GameTime As Integer
    Public Hours As Integer
    Public Seconds As Integer
    Public Minutes As Integer

    Sub IncrementClock()
        Dim AMorPM As String
        Dim TempSeconds As Integer
        Dim PrintSeconds As String
        Dim PrintSeconds2 As String
        Dim PrintMinutes As String
        Dim PrintMinutes2 As String
        Dim PrintHours As Integer

        Seconds = Seconds + (1 * GameSpeed)

        If Seconds > 59 Then
            Minutes = Minutes + 1
            Seconds = Seconds - 60
        End If

        If Minutes > 59 Then
            Hours = Hours + 1
            Minutes = 0
        End If
        If Hours > 24 Then
            Hours = 1
        End If

        If Hours > 12 Then
            AMorPM = "PM"
            PrintHours = Hours - 12
        Else
            AMorPM = "AM"
            PrintHours = Hours
        End If

        If Hours = 24 Then
            AMorPM = "AM"
        End If

        TempSeconds = Seconds

        If Seconds > 9 Then
            PrintSeconds = TempSeconds
        Else
            PrintSeconds = "0" & Seconds
        End If

        If Seconds > 50 Then
            PrintSeconds2 = "0" & 60 - TempSeconds
        Else
            PrintSeconds2 = 60 - TempSeconds
        End If

        If Minutes > 9 Then
            PrintMinutes = Minutes
        Else
            PrintMinutes = "0" & Minutes
        End If

        If Minutes > 50 Then
            PrintMinutes2 = "0" & 60 - Minutes
        Else
            PrintMinutes2 = 60 - Minutes
        End If

        If Hours <= 9 AndAlso Hours >= 6 Then
            If GameTime = Time.Night Then
                GameTime = Time.Dawn

                SendTimeToAll()
            End If
        ElseIf Hours < 19 AndAlso Hours > 9 Then
            If GameTime = Time.Dawn Then
                GameTime = Time.Day
                SendTimeToAll()
            End If
        ElseIf Hours < 24 AndAlso Hours >= 19 Then
            If GameTime = Time.Day Then
                GameTime = Time.Dusk
                SendTimeToAll()
            End If
        ElseIf Hours >= 24 AndAlso Hours <= 6 Then
            If GameTime = Time.Dusk Then
                GameTime = Time.Night
                SendTimeToAll()
            End If
        End If

        If Hours > 11 Then
            GameClock = Hours - 12 & ":" & PrintMinutes & ":" & PrintSeconds & " " & AMorPM
        Else
            GameClock = Hours & ":" & PrintMinutes & ":" & PrintSeconds & " " & AMorPM
        End If

        UpdateCaption()

        ' Sync game clock every 10 minutes
        If Minutes Mod 10 = 0 Then
            SendGameClockToAll()
        End If
    End Sub

    Sub SendGameClockTo(ByVal Index As Integer)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ServerPackets.SClock)
        Buffer.WriteInteger(GameSpeed)
        Buffer.WriteInteger(Hours)
        Buffer.WriteInteger(Minutes)
        Buffer.WriteInteger(Seconds)
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
        Buffer.WriteInteger(GameTime)
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
