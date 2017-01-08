Imports System.Text
Imports System.Windows.Forms
Imports SFML.Graphics

Module EditorText
    Public Const MaxChatDisplayLines As Byte = 8
    Public Const ChatLineSpacing As Byte = 12 ' Should be same height as font
    Public Const MyChatTextLimit As Integer = 55
    Public Const MyAmountValueLimit As Integer = 3
    Public Const AllChatLineWidth As Integer = 55
    Public FirstLineIndex As Integer = 0
    Public LastLineIndex As Integer = 0
    Public ScrollMod As Integer = 0

    ' Game text buffer
    Public MyText As String = ""

    Public Sub DrawText(ByVal X As Integer, ByVal y As Integer, ByVal text As String, ByVal color As Color, ByVal BackColor As Color, ByRef target As RenderWindow, Optional TextSize As Byte = FONT_SIZE)
        Dim mystring As Text = New Text(text, SFMLGameFont)
        mystring.CharacterSize = TextSize

        mystring.Color = BackColor
        mystring.Position = New SFML.Window.Vector2f(X - 1, y - 1)
        target.Draw(mystring)

        mystring.Position = New SFML.Window.Vector2f(X - 1, y + 1)
        target.Draw(mystring)

        mystring.Position = New SFML.Window.Vector2f(X + 1, y + 1)
        target.Draw(mystring)

        mystring.Position = New SFML.Window.Vector2f(X + 1, y + -1)
        target.Draw(mystring)

        mystring.Color = color
        mystring.Position = New SFML.Window.Vector2f(X, y)
        target.Draw(mystring)

    End Sub

    Public Sub DrawNPCName(ByVal MapNpcNum As Integer)
        Dim TextX As Integer
        Dim TextY As Integer
        Dim color As Color, backcolor As Color
        Dim npcNum As Integer

        npcNum = MapNpc(MapNpcNum).Num

        Select Case Npc(npcNum).Behaviour
            Case 0 ' attack on sight
                color = Color.Red
                backcolor = Color.Black
            Case 1, 4 ' attack when attacked + guard
                color = Color.Green
                backcolor = Color.Black
            Case 2, 3, 5 ' friendly + shopkeeper + quest
                color = Color.Yellow
                backcolor = Color.Black
        End Select

        TextX = ConvertMapX(MapNpc(MapNpcNum).X * PIC_X) + MapNpc(MapNpcNum).XOffset + (PIC_X \ 2) - getTextWidth((Trim$(Npc(npcNum).Name))) / 2
        If Npc(npcNum).Sprite < 1 Or Npc(npcNum).Sprite > NumCharacters Then
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - 16
        Else
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - (CharacterGFXInfo(Npc(npcNum).Sprite).height / 4) + 16
        End If

        ' Draw name
        DrawText(TextX, TextY, Trim$(Npc(npcNum).Name), color, backcolor, GameWindow)
    End Sub

    Public Sub DrawEventName(ByVal Index As Integer)
        Dim TextX As Integer
        Dim TextY As Integer
        Dim color As Color, backcolor As Color
        Dim Name As String

        If InMapEditor Then Exit Sub

        color = Color.Yellow
        backcolor = Color.Black

        Name = Trim$(Map.MapEvents(Index).Name)
        ' calc pos
        TextX = ConvertMapX(Map.MapEvents(Index).X * PIC_X) + Map.MapEvents(Index).XOffset + (PIC_X \ 2) - getTextWidth(Trim$(Name)) / 2
        If Map.MapEvents(Index).GraphicType = 0 Then
            TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - 16
        ElseIf Map.MapEvents(Index).GraphicType = 1 Then
            If Map.MapEvents(Index).GraphicNum < 1 Or Map.MapEvents(Index).GraphicNum > NumCharacters Then
                TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - 16
            Else
                ' Determine location for text
                TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - (CharacterGFXInfo(Map.MapEvents(Index).GraphicNum).height / 4) + 16
            End If
        ElseIf Map.MapEvents(Index).GraphicType = 2 Then
            If Map.MapEvents(Index).GraphicY2 > 0 Then
                'TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - (((Map.MapEvents(Index).GraphicY2 * PIC_Y) - Map.MapEvents(Index).GraphicY * PIC_Y) * 32) + 16
                TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - (Map.MapEvents(Index).GraphicY2 * PIC_Y) + 16
            Else
                TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - 32 + 16
            End If
        End If

        ' Draw name
        DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)

    End Sub

    Public Sub DrawMapAttributes()
        Dim X As Integer, y As Integer
        Dim tX As Integer, tY As Integer
        Dim rec As New RectangleShape

        If SelectedTab = 2 Then
            For X = TileView.left To TileView.right
                For y = TileView.top To TileView.bottom
                    If IsValidMapPoint(X, y) Then
                        With Map.Tile(X, y)
                            tX = ((ConvertMapX(X * PIC_X)) - 4) + (PIC_X * 0.5)
                            tY = ((ConvertMapY(y * PIC_Y)) - 7) + (PIC_Y * 0.5)

                            rec.OutlineColor = New SFML.Graphics.Color(Color.White)
                            rec.OutlineThickness = 0.6

                            rec.Size = New SFML.Window.Vector2f((PIC_X), (PIC_X))
                            rec.Position = New SFML.Window.Vector2f(ConvertMapX((X) * PIC_X), ConvertMapY((y) * PIC_Y))

                            Select Case .Type
                                Case TileType.Blocked
                                    rec.FillColor = New SFML.Graphics.Color(255, 0, 0, 100)
                                    GameWindow.Draw(rec)
                                    DrawText(tX, tY, "B", (Color.White), (Color.Black), GameWindow)
                                Case TileType.Warp
                                    DrawText(tX, tY, "W", (Color.Blue), (Color.Black), GameWindow)
                                Case TileType.Item
                                    DrawText(tX, tY, "I", (Color.White), (Color.Black), GameWindow)
                                Case TileType.NpcAvoid
                                    DrawText(tX, tY, "N", (Color.White), (Color.Black), GameWindow)
                                Case TileType.Key
                                    DrawText(tX, tY, "K", (Color.White), (Color.Black), GameWindow)
                                Case TileType.KeyOpen
                                    DrawText(tX, tY, "KO", (Color.White), (Color.Black), GameWindow)
                                Case TileType.Resource
                                    DrawText(tX, tY, "R", (Color.Green), (Color.Black), GameWindow)
                                Case TileType.Door
                                    DrawText(tX, tY, "D", (Color.Black), (Color.Red), GameWindow)
                                Case TileType.NpcSpawn
                                    rec.FillColor = New SFML.Graphics.Color(255, 255, 0, 100)
                                    GameWindow.Draw(rec)
                                    DrawText(tX, tY, "S", (Color.White), (Color.Black), GameWindow)
                                Case TileType.Shop
                                    DrawText(tX, tY, "SH", (Color.Blue), (Color.Black), GameWindow)
                                Case TileType.Bank
                                    DrawText(tX, tY, "BA", (Color.Blue), (Color.Black), GameWindow)
                                Case TileType.Heal
                                    DrawText(tX, tY, "H", (Color.Green), (Color.Black), GameWindow)
                                Case TileType.Trap
                                    DrawText(tX, tY, "T", (Color.Red), (Color.Black), GameWindow)
                                Case TileType.House
                                    DrawText(tX, tY, "H", (Color.Green), (Color.Black), GameWindow)
                                Case TileType.Craft
                                    DrawText(tX, tY, "C", (Color.Green), (Color.Black), GameWindow)
                            End Select
                        End With
                    End If
                Next
            Next
        End If

    End Sub

    Public Function getTextWidth(ByVal text As String, Optional textsize As Byte = FONT_SIZE) As Integer
        Dim mystring As Text = New Text(text, SFMLGameFont)
        Dim textBounds As FloatRect
        mystring.CharacterSize = textsize
        textBounds = mystring.GetLocalBounds()
        Return textBounds.Width
    End Function

    Public Function GetSFMLColor(ByVal Color As Byte) As Color
        Select Case Color
            Case ColorType.Black
                Return SFML.Graphics.Color.Black
            Case ColorType.Blue
                Return New Color(73, 151, 208)
            Case ColorType.Green
                Return New Color(102, 255, 0, 180)
            Case ColorType.Cyan
                Return New Color(0, 139, 139)
            Case ColorType.Red
                Return New Color(255, 0, 0, 180)
            Case ColorType.Magenta
                Return SFML.Graphics.Color.Magenta
            Case ColorType.Brown
                Return New Color(139, 69, 19)
            Case ColorType.Gray
                Return New Color(211, 211, 211)
            Case ColorType.DarkGray
                Return New Color(169, 169, 169)
            Case ColorType.BrightBlue
                Return New Color(0, 191, 255)
            Case ColorType.BrightGreen
                Return New Color(0, 255, 0)
            Case ColorType.BrightCyan
                Return New Color(0, 255, 255)
            Case ColorType.BrightRed
                Return New Color(255, 0, 0)
            Case ColorType.Pink
                Return New Color(255, 192, 203)
            Case ColorType.Yellow
                Return SFML.Graphics.Color.Yellow
            Case ColorType.White
                Return SFML.Graphics.Color.White
            Case Else
                Return SFML.Graphics.Color.White
        End Select
    End Function

    Public SplitChars As Char() = New Char() {" "c, "-"c, ControlChars.Tab}

    Public Function WordWrap(str As String, width As Integer) As List(Of String)

        Dim words As String() = Explode(str, SplitChars)
        Dim curLineLength As Integer = 0
        Dim strBuilder As New StringBuilder()
        Dim i As Integer = 0
        Dim rtnString As New List(Of String)

        While i < words.Length
            Dim word As String = words(i)

            ' If adding the new word to the current line would be too Integer,
            ' then put it on a new line (and split it up if it's too Integer).
            If curLineLength + word.Length > width Then

                ' Only move down to a new line if we have text on the current line.
                ' Avoids situation where wrapped whitespace causes emptylines in text.
                If curLineLength > 0 Then
                    strBuilder.Append("|")
                    curLineLength = 0
                End If

                ' If the current word is too Integer to fit on a line even on it's own then
                ' split the word up.
                While word.Length > width
                    strBuilder.Append(word.Substring(0, width - 1) + "-")
                    word = word.Substring(width - 1)
                    strBuilder.Append("|")
                End While

                ' Remove leading whitespace from the word so the new line starts flush to the left.
                word = word.TrimStart()

            End If

            strBuilder.Append(word)
            curLineLength += word.Length
            i += 1
        End While

        Dim lines As String() = strBuilder.ToString.Split("|")
        For Each line As String In lines
            'line = Replace(line, "|", "")
            rtnString.Add(line.Replace("|", "")) ' & vbNewLine)
        Next

        Return rtnString

    End Function

    Public Function Explode(str As String, splitChars As Char()) As String()

        Dim parts As New List(Of String)()
        Dim startIndex As Integer = 0
        Explode = Nothing
        While True
            Dim index As Integer = str.IndexOfAny(splitChars, startIndex)

            If index = -1 Then
                parts.Add(str.Substring(startIndex))
                Return parts.ToArray()
            End If

            Dim word As String = str.Substring(startIndex, index - startIndex)
            Dim nextChar As Char = str.Substring(index, 1)(0)
            ' Dashes and the likes should stick to the word occuring before it. Whitespace doesn't have to.
            If Char.IsWhiteSpace(nextChar) Then
                parts.Add(word)
                parts.Add(nextChar.ToString())
            Else
                parts.Add(word + nextChar)
            End If

            startIndex = index + 1
        End While

    End Function

    Public Function KeyPressed(ByVal e As KeyEventArgs) As String

        Dim keyValue As String = ""

        If e.KeyCode = 32 Then ' Space
            keyValue = ChrW(e.KeyCode)

        ElseIf e.KeyCode >= 65 AndAlso e.KeyCode <= 90 Then ' Letters
            If e.Shift Then
                keyValue = ChrW(e.KeyCode)
            Else
                keyValue = ChrW(e.KeyCode + 32)
            End If

        ElseIf e.KeyCode = Keys.D0 Then
            If e.Shift Then
                keyValue = ")"
            Else
                keyValue = "0"
            End If

        ElseIf e.KeyCode = Keys.D1 Then
            If e.Shift Then
                keyValue = "!"
            Else
                keyValue = "1"
            End If

        ElseIf e.KeyCode = Keys.D2 Then
            If e.Shift Then
                keyValue = "@"
            Else
                keyValue = "2"
            End If

        ElseIf e.KeyCode = Keys.D3 Then
            If e.Shift Then
                keyValue = "#"
            Else
                keyValue = "3"
            End If

        ElseIf e.KeyCode = Keys.D4 Then
            If e.Shift Then
                keyValue = "$"
            Else
                keyValue = "4"
            End If

        ElseIf e.KeyCode = Keys.D5 Then
            If e.Shift Then
                keyValue = "%"
            Else
                keyValue = "5"
            End If

        ElseIf e.KeyCode = Keys.D6 Then
            If e.Shift Then
                keyValue = "^"
            Else
                keyValue = "6"
            End If

        ElseIf e.KeyCode = Keys.D7 Then
            If e.Shift Then
                keyValue = "&"
            Else
                keyValue = "7"
            End If

        ElseIf e.KeyCode = Keys.D8 Then
            If e.Shift Then
                keyValue = "*"
            Else
                keyValue = "8"
            End If

        ElseIf e.KeyCode = Keys.D9 Then
            If e.Shift Then
                keyValue = "("
            Else
                keyValue = "9"
            End If

        ElseIf e.KeyCode = Keys.OemPeriod Then
            If e.Shift Then
                keyValue = ">"
            Else
                keyValue = "."
            End If

        ElseIf e.KeyCode = Keys.OemPipe Then
            If e.Shift Then
                'keyValue= "|"
            Else
                keyValue = "\"
            End If

        ElseIf e.KeyCode = Keys.OemCloseBrackets Then
            If e.Shift Then
                keyValue = "}"
            Else
                keyValue = "]"
            End If

        ElseIf e.KeyCode = Keys.OemMinus Then
            If e.Shift Then
                keyValue = "_"
            Else
                keyValue = "-"
            End If

        ElseIf e.KeyCode = Keys.OemOpenBrackets Then
            If e.Shift Then
                keyValue = "{"
            Else
                keyValue = "["
            End If

        ElseIf e.KeyCode = Keys.OemQuestion Then
            If e.Shift Then
                keyValue = "?"
            Else
                keyValue = "/"
            End If

        ElseIf e.KeyCode = Keys.OemQuotes Then
            If e.Shift Then
                keyValue = Chr(34)
            Else
                keyValue = "'"
            End If

        ElseIf e.KeyCode = Keys.OemSemicolon Then
            If e.Shift Then
                keyValue = ":"
            Else
                keyValue = ";"
            End If

        ElseIf e.KeyCode = Keys.Oemcomma Then
            If e.Shift Then
                keyValue = "<"
            Else
                keyValue = ","
            End If

        ElseIf e.KeyCode = Keys.Oemplus Then
            If e.Shift Then
                keyValue = "+"
            Else
                keyValue = "="
            End If

        ElseIf e.KeyCode = Keys.Oemtilde Then
            If e.Shift Then
                keyValue = "~"
            Else
                keyValue = "`"
            End If

        End If

        Return keyValue

    End Function
End Module