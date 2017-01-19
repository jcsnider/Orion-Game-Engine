Public Module ClientTime

    ' Keep track of time
    Public Hours As Integer
    Public Minutes As Integer
    Public Seconds As Integer
    Public GameSpeed As Integer
    Public GameTime As Integer
    Public CurTime As String

    Sub Packet_Clock(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SClock Then Exit Sub

        GameSpeed = Buffer.ReadInteger
        Hours = Buffer.ReadInteger
        Minutes = Buffer.ReadInteger
        Seconds = Buffer.ReadInteger

        Buffer = Nothing
    End Sub

    Sub Packet_Time(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.STime Then Exit Sub

        GameTime = Buffer.ReadInteger

        If GameTime = Time.Dawn Then
            AddText("A chilling, refreshing, breeze has come with the morning.", ColorType.BrightBlue)
        ElseIf GameTime = TIME.Day Then
            AddText("Day has dawned in this region.", ColorType.Yellow)
        ElseIf GameTime = TIME.Dusk Then
            AddText("Dusk has begun darkening the skies...", ColorType.BrightRed)
        Else 'night
            AddText("Night has fallen upon the weary travelers.", ColorType.DarkGray)
        End If

        Buffer = Nothing
    End Sub

    Sub IncrementGameClock()

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
            CurTime = CStr(Hours - 12)
        Else
            CurTime = Hours
        End If

        If Minutes < 10 Then
            CurTime = CurTime & ":0" & Minutes
        Else
            CurTime = CurTime & ":" & Minutes
        End If

        'If Hours > 12 Then
        '    CurTime = CurTime & " Pm"
        'Else
        '    CurTime = CurTime & " Am"
        'End If

    End Sub

End Module

