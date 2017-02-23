Imports System.Windows.Forms

Namespace Global.Orion
    Public Structure ChatCursor
        Public X As Integer
        Public Y As Integer
    End Structure

    Public Structure ChatData
        Public Active As Boolean
        Public HistoryLimit As Integer
        Public MessageLimit As Integer

        Public History As List(Of String)
        Public CachedMessage As String
        Public CurrentMessage As String
        Public Cursor As ChatCursor

        Public Function ProcessCharacter(ByRef evt As KeyPressEventArgs) As Boolean
            If Not Active Then
                Return False
            End If

            If CurrentMessage = Nothing Then CurrentMessage = ""

            Select Case evt.KeyChar
                Case vbBack
                    Exit Select

                Case Else
                    CurrentMessage = CurrentMessage + evt.KeyChar
                    If (CurrentMessage.Length > MessageLimit) Then
                        CurrentMessage = CurrentMessage.Substring(0, MessageLimit)
                    End If
            End Select

            Return True
        End Function

        Public Function ProcessKey(ByRef evt As KeyEventArgs) As Boolean
            If Not Active Then
                If (evt.KeyCode = Keys.Enter) Then
                    evt.Handled = True
                    evt.SuppressKeyPress = True
                    Active = True
                    Return True
                End If

                Return False
            End If

            If CurrentMessage = Nothing Then CurrentMessage = ""

            Select Case evt.KeyCode
                Case Keys.Enter
                    History.Add(CurrentMessage)
                    If (History.Count > HistoryLimit) Then
                        History.RemoveRange(0, History.Count - HistoryLimit)
                    End If
                    Cursor.Y = History.Count
                    Active = False
                    Exit Select

                Case Keys.Back
                    If CurrentMessage.Length > 0 Then
                        CurrentMessage = CurrentMessage.Remove(CurrentMessage.Length - 1)
                    End If
                    Exit Select

                Case Keys.Left
                    Cursor.X = Math.Max(0, Cursor.X - 1)
                    Exit Select

                Case Keys.Right
                    Cursor.X = Math.Min(CurrentMessage.Length, Cursor.X + 1)
                    Exit Select

                Case Keys.Down
                    Cursor.Y = Math.Min(History.Count, Cursor.Y + 1)
                    If (Cursor.Y = History.Count) Then
                        CurrentMessage = CachedMessage
                    Else
                        CurrentMessage = History(Cursor.Y)
                    End If
                    Exit Select

                Case Keys.Up
                    If (Cursor.Y = History.Count) Then
                        CachedMessage = CurrentMessage
                    End If

                    Cursor.Y = Math.Max(0, Cursor.Y - 1)
                    CurrentMessage = History(Cursor.Y)
                    Exit Select

                Case Else
                    If evt.KeyCode = Keys.V And evt.Modifiers = Keys.Control Then
                        CurrentMessage = CurrentMessage + Clipboard.GetText
                    End If

                    Dim keyName = [Enum].GetName(GetType(Keys), evt.KeyCode)
                    If (keyName.Length = 1) Then
                        Cursor.Y = History.Count
                    End If

                    CachedMessage = CurrentMessage
                    Exit Select
            End Select

            Return True
        End Function
    End Structure

    Module ChatModule
        Public ChatInput As ChatData = New ChatData With {.Active = False, .HistoryLimit = 10, .MessageLimit = 100, .History = New List(Of String)(.HistoryLimit + 1), .CurrentMessage = "", .Cursor = New ChatCursor() With {.X = 0, .Y = 0}}
    End Module
End Namespace
