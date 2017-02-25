' MIT License
' 
' Copyright (c) 2017 Robert Lodico
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

Namespace Global.Orion
    Public MustInherit Class AbstractOptions
        Private mOptions As Dictionary(Of String, Object)
        Public ReadOnly Property Map() As Dictionary(Of String, Object)
            Get
                If (mOptions Is Nothing) Then
                    mOptions = New Dictionary(Of String, Object)()
                End If

                Return mOptions
            End Get
        End Property

        Default Public Overloads Property Options(ByVal key As String, Optional defaultValue As Object = Nothing) As Object
            Get
                Return Map(key)
            End Get
            Set(value As Object)
                Map(key) = value
            End Set
        End Property

        Public Function GetOption(Of T)(ByRef key As String, Optional defaultValue As T = Nothing) As T
            Dim value As T = Options(key)
            If (value Is Nothing) Then
                Return defaultValue
            End If

            Return value
        End Function

        Public Function GetBoolean(ByRef key As String, Optional defaultValue As Boolean = 0) As Boolean
            Return GetOption(Of Boolean)(key, defaultValue)
        End Function

        Public Function GetByte(ByRef key As String, Optional defaultValue As Byte = 0) As Byte
            Return GetOption(Of Byte)(key, defaultValue)
        End Function

        Public Function GetBytes(ByRef key As String, Optional defaultValue As Byte() = Nothing) As Byte()
            Return GetOption(Of Byte())(key, If(defaultValue, New Byte() {}))
        End Function

        Public Function GetChar(ByRef key As String, Optional defaultValue As Char = ChrW(0)) As Char
            Return GetOption(Of Char)(key, defaultValue)
        End Function

        Public Function GetDate(ByRef key As String, Optional defaultValue As Date = Nothing) As Date
            Return GetOption(Of Date)(key, defaultValue)
        End Function

        Public Function GetDecimal(ByRef key As String, Optional defaultValue As Decimal = 0) As Decimal
            Return GetOption(Of Decimal)(key, defaultValue)
        End Function

        Public Function GetDouble(ByRef key As String, Optional defaultValue As Double = 0) As Double
            Return GetOption(Of Double)(key, defaultValue)
        End Function

        Public Function GetInteger(ByRef key As String, Optional defaultValue As Integer = 0) As Integer
            Return GetOption(Of Integer)(key, defaultValue)
        End Function

        Public Function GetLong(ByRef key As String, Optional defaultValue As Long = 0) As Long
            Return GetOption(Of Long)(key, defaultValue)
        End Function

        Public Function GetShort(ByRef key As String, Optional defaultValue As Short = 0) As Short
            Return GetOption(Of Short)(key, defaultValue)
        End Function

        Public Function GetSingle(ByRef key As String, Optional defaultValue As Single = 0) As Single
            Return GetOption(Of Single)(key, defaultValue)
        End Function

        Public Function GetString(ByRef key As String, Optional defaultValue As String = Nothing) As String
            Return GetOption(Of String)(key, defaultValue)
        End Function

        Public Function GetUInteger(ByRef key As String, Optional defaultValue As UInteger = 0) As UInteger
            Return GetOption(Of UInteger)(key, defaultValue)
        End Function

        Public Function GetULong(ByRef key As String, Optional defaultValue As ULong = 0) As ULong
            Return GetOption(Of ULong)(key, defaultValue)
        End Function

        Public Function GetUShort(ByRef key As String, Optional defaultValue As UShort = 0) As UShort
            Return GetOption(Of UShort)(key, defaultValue)
        End Function

        Public Sub SetOption(ByRef key As String, ByRef value As Object)
            Options(key) = value
        End Sub

        Public Sub SetOption(Of T)(ByRef key As String, ByRef value As T)
            Options(key) = value
        End Sub

        Public Function TrySetOption(ByRef key As String, ByRef value As Object) As Boolean
            If (Map.ContainsKey(key)) Then
                Return False
            End If

            SetOption(key, value)
            Return True
        End Function
    End Class
End Namespace
