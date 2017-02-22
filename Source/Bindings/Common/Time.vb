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
    Public Enum TimeOfDay As Byte
        Day = 0
        Night = 1
        Dawn = 2
        Dusk = 3
    End Enum

    Public Delegate Sub HandleTimeEvent(ByRef source As Time)

    Public Class Time
        Private Shared mInstance As Time = Nothing
        Public Shared ReadOnly Property Instance As Time
            Get
                If (mInstance Is Nothing) Then
                    mInstance = New Time()
                End If

                Return mInstance
            End Get
        End Property

        Public Event OnTimeChanged As HandleTimeEvent
        Public Event OnTimeOfDayChanged As HandleTimeEvent
        Public Event OnTimeSync As HandleTimeEvent

        Private mTime As Date
        Public Property Time As Date
            Get
                Return mTime
            End Get
            Set(value As Date)
                mTime = value

                RaiseEvent OnTimeChanged(Me)

                If (Time.Second < GameSpeed) Then
                    If (Time.Ticks Mod TimeSpan.TicksPerMillisecond * SyncInterval = 0) Then
                        RaiseEvent OnTimeSync(Me)
                    End If
                End If

                Dim newTimeOfDay As TimeOfDay = GetTimeOfDay(Time.Hour)
                If (TimeOfDay <> newTimeOfDay) Then
                    TimeOfDay = newTimeOfDay
                    RaiseEvent OnTimeOfDayChanged(Me)
                End If
            End Set
        End Property

        Public Property SyncInterval As Integer
        Public Property GameSpeed As Integer
        Public Property TimeOfDay As TimeOfDay

        Public Sub New()
            SyncInterval = 600000
        End Sub

        Public Overrides Function ToString() As String
            Return Me.ToString("h:mm:ss tt")
        End Function

        Public Overloads Function ToString(ByRef format As String) As String
            Return Time.ToString(format)
        End Function

        Public Sub Reset()
            Time = New DateTime(0)
        End Sub

        Public Sub Tick()
            Time = Time.AddSeconds(GameSpeed)
        End Sub

        Public Shared Function GetTimeOfDay(ByRef hours As Integer) As TimeOfDay
            If (hours < 6) Then
                Return TimeOfDay.Night
            ElseIf (6 <= hours And hours <= 9) Then
                Return TimeOfDay.Dawn
            ElseIf (9 < hours And hours < 18) Then
                Return TimeOfDay.Day
            Else
                Return TimeOfDay.Dusk
            End If
        End Function
    End Class
End Namespace