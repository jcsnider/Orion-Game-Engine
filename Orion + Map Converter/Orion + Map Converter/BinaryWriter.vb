'#########################################################################################################################################################
'# Copyright © 2016 ArchaicSoft, All rights reserved.                                                                                                    #
'#                                                                                                                                                       #
'# Redistribution And use In source And binary forms, with Or without modification, are permitted provided that the following conditions are met         #
'#                                                                                                                                                       #
'# 1. Redistributions of source code must retain the above copyright notice, this list of conditions And the following disclaimer.                       #
'#                                                                                                                                                       #
'# 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions And the following disclaimer in the              #
'# documentation And/Or other materials provided with the distribution.                                                                                  #
'#                                                                                                                                                       #
'# 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse Or promote products derived from this            #
'# software without specific prior written permission.                                                                                                   #
'#                                                                                                                                                       #
'# THIS SOFTWARE Is PROVIDED BY THE COPYRIGHT HOLDERS And CONTRIBUTORS "AS IS" And ANY EXPRESS Or IMPLIED WARRANTIES, INCLUDING, BUT Not LIMITED To,     #
'# THE IMPLIED WARRANTIES Of MERCHANTABILITY And FITNESS For A PARTICULAR PURPOSE ARE DISCLAIMED. In NO Event SHALL THE COPYRIGHT HOLDER Or              #
'# CONTRIBUTORS BE LIABLE For ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, Or CONSEQUENTIAL DAMAGES (INCLUDING, BUT Not LIMITED To, PROCUREMENT #
'# OF SUBSTITUTE GOODS Or SERVICES; LOSS OF USE, DATA, Or PROFITS; Or BUSINESS INTERRUPTION) HOWEVER CAUSED And ON ANY THEORY OF LIABILITY, WHETHER IN   #
'# CONTRACT, STRICT LIABILITY, Or TORT(INCLUDING NEGLIGENCE Or OTHERWISE) ARISING In ANY WAY OUT Of THE USE Of THIS SOFTWARE, EVEN IF ADVISED OF THE     #
'# POSSIBILITY OF SUCH DAMAGE.                                                                                                                           #
'#########################################################################################################################################################
'###################################################################
'# Converted by ArchaicSoft for permission of use by Orion Engine. #
'###################################################################

#Region "Imports"
Imports System
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
#End Region

'''<summary>
''' Writes binary files created by this library faster than
''' .net's initial built in handler at the cost of some memory.
''' </summary>
Class ArchaicSoftWriter
    Private _data As Byte() = New Byte(0) {}
    Private _location As Integer

    ''' <summary>
    ''' Gets or Sets the stream data as an array which can be 
    ''' modified before further handling.
    ''' </summary>
    Public Property FileData() As Byte()
        Get
            If _data.Length = _location Then
                Return _data
            End If
            Dim tmpData = New Byte(_location - 1) {}
            Buffer.BlockCopy(_data, 0, tmpData, 0, _location)
            _data = tmpData
            Return _data
        End Get
        Set
            _data = Value
        End Set
    End Property

    ''' <summary>
    ''' Writes binary files created by this library faster than
    ''' .net's initial built in handler at the cost of some memory.
    ''' </summary>
    Public Sub Save(path As String)
        Using writer = New BinaryWriter(System.IO.File.Open(path, FileMode.Create))
            writer.Write(_data.Length)
            writer.Write(_data)
        End Using
    End Sub

#Region "Buffer"
    Private Sub AddToBuffer(bytes As Byte())
        CheckSize(bytes.Length)
        Buffer.BlockCopy(bytes, 0, _data, _location, bytes.Length)
        _location += bytes.Length
    End Sub
    Private Sub AddToBuffer(bytes As Byte(), offset As Integer, size As Integer)
        CheckSize(size)
        Buffer.BlockCopy(bytes, offset, _data, _location, size)
        _location += size
    End Sub
    Private Sub CheckSize(length As Integer)
        If length + _location < _data.Length Then
            Return
        End If
        Dim size = _data.Length * 2
        While length + _location >= size
            size *= 2
        End While
        ResizeBuffer(size)
    End Sub
    Private Sub ResizeBuffer(length As Integer)
        Dim temp = New Byte(length - 1) {}
        Buffer.BlockCopy(_data, 0, temp, 0, _location)
        _data = temp
    End Sub
#End Region

#Region "Write"
    Public Sub Write(bytes As Byte(), offset As Integer, size As Integer)
        AddToBuffer(bytes, offset, size)
    End Sub
    Public Sub WriteBytes(bytes As Byte(), offset As Integer, size As Integer)
        AddToBuffer(bytes, offset, size)
    End Sub
    Public Sub Write(bytes As Byte())
        If _data.Length - _location <= bytes.Length Then
            Dim temp = New Byte(_data.Length + (bytes.Length - 1)) {}
            Buffer.BlockCopy(_data, 0, temp, 0, _data.Length)
            Buffer.BlockCopy(bytes, 0, temp, _data.Length, bytes.Length)
            _data = temp
            _location += bytes.Length
        Else
            Buffer.BlockCopy(bytes, 0, _data, _location, bytes.Length)
            _location += bytes.Length
        End If
    End Sub
    Public Sub WriteBytes(bytes As Byte())
        If _data.Length - _location <= bytes.Length Then
            Dim temp = New Byte(_data.Length + (bytes.Length - 1)) {}
            Buffer.BlockCopy(_data, 0, temp, 0, _data.Length)
            Buffer.BlockCopy(bytes, 0, temp, _data.Length, bytes.Length)
            _data = temp
            _location += bytes.Length
        Else
            Buffer.BlockCopy(bytes, 0, _data, _location, bytes.Length)
            _location += bytes.Length
        End If
    End Sub
    Public Sub Write([boolean] As Boolean)
        AddToBuffer(BitConverter.GetBytes([boolean]))
    End Sub
    Public Sub WriteBoolean([boolean] As Boolean)
        AddToBuffer(BitConverter.GetBytes([boolean]))
    End Sub
    Public Sub Write([Byte] As Byte)
        CheckSize(1)
        _data(_location) = [Byte]
        _location += 1
    End Sub
    Public Sub WriteByte([Byte] As Byte)
        CheckSize(1)
        _data(_location) = [Byte]
        _location += 1
    End Sub
    Public Sub Write([sByte] As SByte)
        CheckSize(1)
        _data(_location) = CByte(Math.Abs(CInt([sByte])))
        _location += 1
    End Sub
    Public Sub WriteSByte([sByte] As SByte)
        CheckSize(1)
        _data(_location) = CByte(Math.Abs(CInt([sByte])))
        _location += 1
    End Sub
    Public Sub Write([Short] As Short)
        AddToBuffer(BitConverter.GetBytes([Short]))
    End Sub
    Public Sub WriteShort([Short] As Short)
        AddToBuffer(BitConverter.GetBytes([Short]))
    End Sub
    Public Sub Write([uShort] As UShort)
        AddToBuffer(BitConverter.GetBytes([uShort]))
    End Sub
    Public Sub WriteUShort([uShort] As UShort)
        AddToBuffer(BitConverter.GetBytes([uShort]))
    End Sub
    Public Sub Write([integer] As Integer)
        AddToBuffer(BitConverter.GetBytes([integer]))
    End Sub
    Public Sub WriteInteger([integer] As Integer)
        AddToBuffer(BitConverter.GetBytes([integer]))
    End Sub
    Public Sub Write([uInteger] As UInteger)
        AddToBuffer(BitConverter.GetBytes([uInteger]))
    End Sub
    Public Sub WriteUInteger([uInteger] As UInteger)
        AddToBuffer(BitConverter.GetBytes([uInteger]))
    End Sub
    Public Sub Write(Float As Single)
        AddToBuffer(BitConverter.GetBytes(Float))
    End Sub
    Public Sub WriteFloat(Float As Single)
        AddToBuffer(BitConverter.GetBytes(Float))
    End Sub
    Public Sub WriteSingle(Float As Single)
        AddToBuffer(BitConverter.GetBytes(Float))
    End Sub
    Public Sub Write([Long] As Long)
        AddToBuffer(BitConverter.GetBytes([Long]))
    End Sub
    Public Sub WriteInteger([Long] As Long)
        AddToBuffer(BitConverter.GetBytes([Long]))
    End Sub
    Public Sub Write([uLong] As ULong)
        AddToBuffer(BitConverter.GetBytes([uLong]))
    End Sub
    Public Sub WriteULong([uLong] As ULong)
        AddToBuffer(BitConverter.GetBytes([uLong]))
    End Sub
    Public Sub Write([Double] As Double)
        AddToBuffer(BitConverter.GetBytes([Double]))
    End Sub
    Public Sub WriteDouble([Double] As Double)
        AddToBuffer(BitConverter.GetBytes([Double]))
    End Sub
    Public Sub Write([Char] As Char)
        AddToBuffer(BitConverter.GetBytes([Char]))
    End Sub
    Public Sub WriteCharacter([Char] As Char)
        AddToBuffer(BitConverter.GetBytes([Char]))
    End Sub
    Public Sub Write([String] As String)
        If [String] Is Nothing Then [String] = ""
        Dim temp = Encoding.UTF8.GetBytes([String])
        AddToBuffer(BitConverter.GetBytes(temp.Length))
        AddToBuffer(temp)
    End Sub
    Public Sub WriteString([String] As String)
        If [String] Is Nothing Then [String] = ""
        Dim temp = Encoding.UTF8.GetBytes([String])
        AddToBuffer(BitConverter.GetBytes(temp.Length))
        AddToBuffer(temp)
    End Sub
    Public Sub Write([Object] As Object)
        Dim memoryStream = New MemoryStream()
        Dim bf As New BinaryFormatter()
        bf.Serialize(memoryStream, [Object])
        AddToBuffer(BitConverter.GetBytes(CInt(memoryStream.Length)))
        Dim temp = New Byte(_data.Length + (memoryStream.ToArray().Length - 1)) {}
        Buffer.BlockCopy(_data, 0, temp, 0, _data.Length)
        Buffer.BlockCopy(memoryStream.ToArray(), 0, temp, _data.Length, memoryStream.ToArray().Length)
        _data = temp
        _location += memoryStream.ToArray().Length
        memoryStream.Dispose()
    End Sub
    Public Sub WriteObject([Object] As Object)
        Dim memoryStream = New MemoryStream()
        Dim bf As New BinaryFormatter()
        bf.Serialize(memoryStream, [Object])
        AddToBuffer(BitConverter.GetBytes(CInt(memoryStream.Length)))
        Dim temp = New Byte(_data.Length + (memoryStream.ToArray().Length - 1)) {}
        Buffer.BlockCopy(_data, 0, temp, 0, _data.Length)
        Buffer.BlockCopy(memoryStream.ToArray(), 0, temp, _data.Length, memoryStream.ToArray().Length)
        _data = temp
        _location += memoryStream.ToArray().Length
        memoryStream.Dispose()
    End Sub
#End Region
End Class
