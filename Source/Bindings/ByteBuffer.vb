Imports System.Text
Public Class ByteBuffer
    Implements IDisposable
    Dim Buff As List(Of Byte)
    Dim readBuff As Byte()
    Dim readpos As Integer
    Dim buffUpdated = False
    Public Sub New()
        Buff = New List(Of Byte)
        readpos = 0
    End Sub
    Public Function GetReadPos() As Integer
        GetReadPos = readpos
    End Function
    Public Function ToArray() As Byte()
        Return Buff.ToArray
    End Function
    Public Function Count() As Integer
        Return Buff.Count
    End Function
    Public Function Length() As Integer
        Length = Count() - readpos
    End Function
    Public Sub Clear()
        Buff.Clear()
        readpos = 0
    End Sub
    Public Sub WriteBytes(ByVal Input() As Byte)
        Buff.AddRange(Input)
        buffUpdated = True
    End Sub

    Public Sub WriteShort(ByVal Input As Short)
        Buff.AddRange(BitConverter.GetBytes(Input))
        buffUpdated = True
    End Sub
    Public Sub WriteInteger(ByVal Input As Integer)
        Buff.AddRange(BitConverter.GetBytes(Input))
        buffUpdated = True
    End Sub
    Public Sub WriteString(ByVal Input As String)
        Buff.AddRange(BitConverter.GetBytes(Input.Length))
        Buff.AddRange(Encoding.ASCII.GetBytes(Input))
        buffUpdated = True
    End Sub
    Public Function ReadString(Optional ByVal Peek As Boolean = True) As String
        Dim Len As Integer = ReadInteger(True)
        If buffUpdated Then
            readBuff = Buff.ToArray
            buffUpdated = False
        End If
        Dim ret As String = Encoding.ASCII.GetString(readBuff, readpos, Len)
        If Peek And Buff.Count > readpos Then
            If ret.Length > 0 Then
                readpos += Len
            End If
        End If
        Return ret
    End Function
    Public Function ReadBytes(ByVal Length As Integer, Optional ByRef Peek As Boolean = True) As Byte()
        If buffUpdated Then
            readBuff = Buff.ToArray
            buffUpdated = False
        End If
        Dim ret() As Byte = Buff.GetRange(readpos, Length).ToArray
        If Peek Then readpos += Length
        Return ret
    End Function
    Public Function ReadShort(Optional ByVal peek As Boolean = True) As Short
        If Buff.Count > readpos Then 'check to see if this passes the byte count
            If buffUpdated Then
                readBuff = Buff.ToArray
                buffUpdated = False
            End If
            Dim ret As Short = BitConverter.ToInt16(readBuff, readpos)
            If peek And Buff.Count > readpos Then
                readpos += 2
            End If
            Return ret
        Else
            Throw New Exception("Byte Buffer Past Limit!") 'past byte count throw a new exception
        End If
    End Function

    Public Function ReadInteger(Optional ByVal peek As Boolean = True) As Integer
        If Buff.Count > readpos Then 'check to see if this passes the byte count
            If buffUpdated Then
                readBuff = Buff.ToArray
                buffUpdated = False
            End If
            Dim ret As Integer = BitConverter.ToInt32(readBuff, readpos)
            If peek And Buff.Count > readpos Then
                readpos += 4
            End If
            Return ret
        Else
            Throw New Exception("Byte Buffer Past Limit!") 'past byte count throw a new exception
        End If
    End Function

    Public Function ReadUnicodeString(Optional ByVal Peek As Boolean = True) As String
        Try
            Dim Len As Integer = ReadInteger(True)

            If buffUpdated Then
                readBuff = Buff.ToArray
                buffUpdated = False
            End If

            Dim ret As String = Encoding.ASCII.GetString(readBuff, readpos, Len)

            If Peek And Buff.Count > readpos Then
                If ret.Length > 0 Then
                    readpos += Len
                End If
            End If

            Return Conv_String(ret)
        Catch ex As Exception
            ReadUnicodeString = "Null"
            Exit Function
        End Try
    End Function

    Public Sub WriteUnicodeString(ByVal Input As String)

        Try
            If Input = vbNullString Then Exit Sub
            Input = Conv_Uni(Input)
            Buff.AddRange(BitConverter.GetBytes(Input.Length))
            Buff.AddRange(Encoding.ASCII.GetBytes(Input))
            buffUpdated = True
        Catch ex As Exception
            MsgBox("WriteUnicodeString")
        End Try

    End Sub

    Public Function Conv_String(ByVal message As String) As String
        Conv_String = ""

        Try
            Dim split As String() = message.Split(New [Char]() {" "c, ","c, "."c, ";"c, CChar(vbTab)})
            For Each s As String In split
                If s.Trim() <> "" Then
                    Conv_String = Conv_String & ChrW(s)
                End If
            Next s
        Catch ex As Exception

        End Try

        Return Conv_String

    End Function

    'Convert a Unicode String to Unicode
    Function Conv_Uni(ByVal inx As String) As String
        Dim i As Integer
        Conv_Uni = ""

        If inx = vbNullString Or inx = "" Then
            Conv_Uni = "I miss this."
            Return Conv_Uni
            Exit Function
        End If

        For i = 0 To inx.Length - 1
            Conv_Uni += AscW(inx.Chars(i)) & ";"
        Next

    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Buff.Clear()
            End If
            readpos = 0
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
'+-------------------------End Class-------------------+