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

''' <summary>
''' Reads binary files created by this library faster than
''' .net's initial built in handler at the cost of some memory.
''' </summary>
Class ArchaicSoftReader
    Private _data As Byte() = New Byte(0) {}
    Private _location As Integer

    ''' <summary>
    ''' Initializes and opens file/stores file data to be read.
    ''' </summary>
    Public Sub New(path As String)
        If Not System.IO.File.Exists(path) Then
            Return
        End If
        Using reader__1 = New BinaryReader(System.IO.File.Open(path, FileMode.Open))
            Dim length = reader__1.ReadInt32()
            _data = reader__1.ReadBytes(length)
        End Using
    End Sub

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

#Region "Read"
    Public Sub Read(ByRef bytes As Byte(), length As Integer)
        If _location + length > _data.Length Then
            Return
        End If
        bytes = New Byte(length - 1) {}
        Buffer.BlockCopy(_data, _location, bytes, 0, bytes.Length)
        _location += length
    End Sub
    Public Function ReadBytes(length As Integer) As Byte()
        If _location + length > _data.Length Then
            Return New Byte(-1) {}
        End If
        Dim bytes = New Byte(length - 1) {}
        Buffer.BlockCopy(_data, _location, bytes, 0, bytes.Length)
        _location += length
        Return bytes
    End Function
    Public Sub Read(ByRef [boolean] As Boolean)
        If _location + 1 > _data.Length Then
            Return
        End If
        [boolean] = BitConverter.ToBoolean(_data, _location)
        _location += 1
    End Sub
    Public ReadOnly Property ReadBoolean() As Boolean
        Get
            If _location + 1 > _data.Length Then
                Return False
            End If
            Dim [boolean] = BitConverter.ToBoolean(_data, _location)
            _location += 1
            Return [boolean]
        End Get
    End Property
    Public Sub Read(ByRef [Byte] As Byte)
        If _location + 1 > _data.Length Then
            Return
        End If
        [Byte] = _data(_location)
        _location += 1
    End Sub
    Public ReadOnly Property ReadByte() As Byte
        Get
            If _location + 1 > _data.Length Then
                Return 0
            End If
            Dim [Byte] = _data(_location)
            _location += 1
            Return [Byte]
        End Get
    End Property
    Public Sub Read(ByRef [sByte] As SByte)
        If _location + 1 > _data.Length Then
            Return
        End If
        [sByte] = CSByte(_data(_location) * -1)
        _location += 1
    End Sub
    Public ReadOnly Property ReadSByte() As SByte
        Get
            If _location + 1 > _data.Length Then
                Return 0
            End If
            Dim [sByte] = CSByte(_data(_location) * -1)
            _location += 1
            Return [sByte]
        End Get
    End Property
    Public Sub Read(ByRef [Short] As Short)
        If _location + 2 > _data.Length Then
            Return
        End If
        [Short] = BitConverter.ToInt16(_data, _location)
        _location += 2
    End Sub
    Public ReadOnly Property ReadShort() As Short
        Get
            If _location + 2 > _data.Length Then
                Return 0
            End If
            Dim [Short] = BitConverter.ToInt16(_data, _location)
            _location += 2
            Return [Short]
        End Get
    End Property
    Public Sub Read(ByRef [uShort] As UShort)
        If _location + 2 > _data.Length Then
            Return
        End If
        [uShort] = BitConverter.ToUInt16(_data, _location)
        _location += 2
    End Sub
    Public ReadOnly Property ReadUShort() As UShort
        Get
            If _location + 2 > _data.Length Then
                Return 0
            End If
            Dim [uShort] = BitConverter.ToUInt16(_data, _location)
            _location += 2
            Return [uShort]
        End Get
    End Property
    Public Sub Read(ByRef [integer] As Integer)
        If _location + 4 > _data.Length Then
            Return
        End If
        [integer] = BitConverter.ToInt32(_data, _location)
        _location += 4
    End Sub
    Public ReadOnly Property ReadInteger() As Integer
        Get
            If _location + 4 > _data.Length Then
                Return 0
            End If
            Dim [integer] = BitConverter.ToInt32(_data, _location)
            _location += 4
            Return [integer]
        End Get
    End Property
    Public Sub Read(ByRef [uInteger] As UInteger)
        If _location + 4 > _data.Length Then
            Return
        End If
        [uInteger] = BitConverter.ToUInt32(_data, _location)
        _location += 4
    End Sub
    Public ReadOnly Property ReadUInteger() As UInteger
        Get
            If _location + 4 > _data.Length Then
                Return 0
            End If
            Dim [uInteger] = BitConverter.ToUInt32(_data, _location)
            _location += 4
            Return [uInteger]
        End Get
    End Property
    Public Sub Read(ByRef Float As Single)
        If _location + 4 > _data.Length Then
            Return
        End If
        Float = BitConverter.ToSingle(_data, _location)
        _location += 4
    End Sub
    Public ReadOnly Property ReadFloat() As Single
        Get
            If _location + 4 > _data.Length Then
                Return 0F
            End If
            Dim Float = BitConverter.ToSingle(_data, _location)
            _location += 4
            Return Float
        End Get
    End Property
    Public ReadOnly Property ReadSingle() As Single
        Get
            If _location + 4 > _data.Length Then
                Return 0F
            End If
            Dim [single] = BitConverter.ToSingle(_data, _location)
            _location += 4
            Return [single]
        End Get
    End Property
    Public Sub Read(ByRef [Long] As Long)
        If _location + 8 > _data.Length Then
            Return
        End If
        [Long] = BitConverter.ToInt64(_data, _location)
        _location += 8
    End Sub
    Public ReadOnly Property ReadLong() As Long
        Get
            If _location + 8 > _data.Length Then
                Return 0
            End If
            Dim [Long] = BitConverter.ToInt64(_data, _location)
            _location += 8
            Return [Long]
        End Get
    End Property
    Public Sub Read(ByRef [uLong] As ULong)
        If _location + 8 > _data.Length Then
            Return
        End If
        [uLong] = BitConverter.ToUInt64(_data, _location)
        _location += 8
    End Sub
    Public ReadOnly Property ReadULong() As ULong
        Get
            If _location + 8 > _data.Length Then
                Return 0
            End If
            Dim [uLong] = BitConverter.ToUInt64(_data, _location)
            _location += 8
            Return [uLong]
        End Get
    End Property
    Public Sub Read(ByRef [Double] As Double)
        If _location + 8 > _data.Length Then
            Return
        End If
        [Double] = BitConverter.ToDouble(_data, _location)
        _location += 8
    End Sub
    Public ReadOnly Property ReadDouble() As Double
        Get
            If _location + 8 > _data.Length Then
                Return 0.0
            End If
            Dim [Double] = BitConverter.ToDouble(_data, _location)
            _location += 8
            Return [Double]
        End Get
    End Property
    Public Sub Read(ByRef character As Char)
        If _location + 2 > _data.Length Then
            Return
        End If
        character = BitConverter.ToChar(_data, _location)
        _location += 2
    End Sub
    Public ReadOnly Property ReadChar() As Char
        Get
            If _location + 2 > _data.Length Then
                Return ControlChars.NullChar
            End If
            Dim character = BitConverter.ToChar(_data, _location)
            _location += 2
            Return character
        End Get
    End Property
    Public Sub Read(ByRef [String] As String)
        If _location + 4 > _data.Length Then
            Return
        End If
        Dim len = BitConverter.ToInt32(_data, _location)
        _location += 4
        If _location + len > _data.Length Then
            Return
        End If
        [String] = Encoding.ASCII.GetString(_data, _location, len)
        _location += len
    End Sub
    Public ReadOnly Property ReadString() As String
        Get
            If _location + 4 > _data.Length Then
                Return String.Empty
            End If
            Dim len = BitConverter.ToInt32(_data, _location)
            _location += 4
            If _location + len > _data.Length Then
                Return String.Empty
            End If
            Dim [String] = Encoding.ASCII.GetString(_data, _location, len)
            _location += len
            Return [String]
        End Get
    End Property
    Public Sub Read(ByRef [Object] As Object)
        If _location + 4 > _data.Length Then
            Return
        End If
        Dim len = BitConverter.ToInt32(_data, _location)
        _location += 4
        If _location + len > _data.Length Then
            Return
        End If
        Dim memoryStream = New MemoryStream()
        memoryStream.SetLength(len)
        memoryStream.Read(_data, _location, len)
        _location += len
        [Object] = New BinaryFormatter().Deserialize(memoryStream)
        memoryStream.Dispose()
    End Sub
    Public ReadOnly Property ReadObject() As Object
        Get
            If _location + 4 > _data.Length Then
                Return Nothing
            End If
            Dim len = BitConverter.ToInt32(_data, _location)
            _location += 4
            If _location + len > _data.Length Then
                Return Nothing
            End If
            Dim memoryStream = New MemoryStream()
            memoryStream.SetLength(len)
            memoryStream.Read(_data, _location, len)
            _location += len
            Dim [Object] = New BinaryFormatter().Deserialize(memoryStream)
            memoryStream.Dispose()
            Return [Object]
        End Get
    End Property
#End Region
End Class