Imports System.Runtime.InteropServices.Marshal
Imports Orion

Public Module ClientTime
    Sub Packet_Clock(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SClock Then Exit Sub

        Time.Instance.GameSpeed = Buffer.ReadInteger()
        Time.Instance.Time = New Date(BitConverter.ToInt64(Buffer.ReadBytes(SizeOf(GetType(Long))), 0))

        Buffer = Nothing
    End Sub

    Sub Packet_Time(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.STime Then Exit Sub

        Time.Instance.TimeOfDay = Buffer.ReadByte

        Select Case Time.Instance.TimeOfDay
            Case TimeOfDay.Dawn
                AddText("A chilling, refreshing, breeze has come with the morning.", ColorType.BrightBlue)
                Exit Select

            Case TimeOfDay.Day
                AddText("Day has dawned in this region.", ColorType.Yellow)
                Exit Select

            Case TimeOfDay.Dusk
                AddText("Dusk has begun darkening the skies...", ColorType.BrightRed)
                Exit Select

            Case Else
                AddText("Night has fallen upon the weary travelers.", ColorType.DarkGray)
                Exit Select
        End Select

        Buffer = Nothing
    End Sub
End Module
