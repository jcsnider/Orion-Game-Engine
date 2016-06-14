Imports System.Text
Imports System.Windows.Forms
Imports SFML.Graphics

Module ClientText
    Public Const MaxChatDisplayLines As Byte = 8
    Public Const ChatLineSpacing As Byte = 12 ' Should be same height as font
    Public Const MyChatTextLimit As Integer = 55
    Public Const MyAmountValueLimit As Integer = 3
    Public Const AllChatLineWidth As Integer = 55
    Public FirstLineIndex As Long = 0
    Public LastLineIndex As Long = 0
    Public ScrollMod As Long = 0

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

    Public Sub DrawPlayerName(ByVal Index As Long)
        Dim TextX As Long
        Dim TextY As Long
        Dim color As Color, backcolor As Color
        Dim Name As String

        ' Check access level
        If GetPlayerPK(Index) = NO Then

            Select Case GetPlayerAccess(Index)
                Case 0
                    color = Color.Red
                    backcolor = Color.Black
                Case 1
                    color = Color.Black
                    backcolor = Color.White
                Case 2
                    color = Color.Cyan
                    backcolor = Color.Black
                Case 3
                    color = Color.Green
                    backcolor = Color.Black
                Case 4
                    color = Color.Yellow
                    backcolor = Color.Black
            End Select

        Else
            color = Color.Red
        End If

        Name = Trim$(Player(Index).Name)
        ' calc pos
        TextX = ConvertMapX(GetPlayerX(Index) * PIC_X) + Player(Index).XOffset + (PIC_X \ 2)
        TextX = TextX - (getTextWidth((Trim$(Name))) / 2)
        If GetPlayerSprite(Index) < 1 Or GetPlayerSprite(Index) > NumCharacters Then
            TextY = ConvertMapY(GetPlayerY(Index) * PIC_Y) + Player(Index).YOffset - 16
        Else
            ' Determine location for text
            TextY = ConvertMapY(GetPlayerY(Index) * PIC_Y) + Player(Index).YOffset - (CharacterGFXInfo(GetPlayerSprite(Index)).height / 4) + 16
        End If

        ' Draw name
        Call DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
    End Sub

    Public Sub DrawNPCName(ByVal MapNpcNum As Long)
        Dim TextX As Long
        Dim TextY As Long
        Dim color As Color, backcolor As Color
        Dim npcNum As Long

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

    Public Sub DrawEventName(ByVal Index As Long)
        Dim TextX As Long
        Dim TextY As Long
        Dim color As Color, backcolor As Color
        Dim Name As String, i As Long

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

        For i = 1 To MAX_QUESTS
            'check if the npc is the starter to any quest: [!] symbol
            'can accept the quest as a new one?
            If Player(MyIndex).PlayerQuest(i).Status = QUEST_NOT_STARTED Or Player(MyIndex).PlayerQuest(i).Status = QUEST_COMPLETED_BUT Or (Player(MyIndex).PlayerQuest(i).Status = QUEST_COMPLETED And Quest(i).Repeat = 1) Then
                'the npc gives this quest?
                If Map.MapEvents(Index).questnum = i Then
                    Name = "[!]"
                    TextX = ConvertMapX(Map.MapEvents(Index).X * PIC_X) + Map.MapEvents(Index).XOffset + (PIC_X \ 2) - getTextWidth((Trim$("[!]"))) + 8
                    TextY = TextY - 16
                    If Quest(i).Repeat = 1 Then
                        DrawText(TextX, TextY, Trim$(Name), Color.White, backcolor, GameWindow)
                    Else
                        DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
                    End If
                    Exit For
                End If
            ElseIf Player(MyIndex).PlayerQuest(i).Status = QUEST_STARTED Then
                If Map.MapEvents(Index).questnum = i Then
                    Name = "[*]"
                    TextX = ConvertMapX(Map.MapEvents(Index).X * PIC_X) + Map.MapEvents(Index).XOffset + (PIC_X \ 2) - getTextWidth((Trim$("[*]"))) + 8
                    TextY = TextY - 16
                    DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
                    Exit For
                End If
            End If
        Next

    End Sub

    Public Sub DrawMapAttributes()
        Dim X As Long
        Dim y As Long
        Dim tX As Long
        Dim tY As Long

        If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpAttributes Then
            For X = TileView.left To TileView.right
                For y = TileView.top To TileView.bottom
                    If IsValidMapPoint(X, y) Then
                        With Map.Tile(X, y)
                            tX = ((ConvertMapX(X * PIC_X)) - 4) + (PIC_X * 0.5)
                            tY = ((ConvertMapY(y * PIC_Y)) - 7) + (PIC_Y * 0.5)
                            Select Case .Type
                                Case TILE_TYPE_BLOCKED
                                    DrawText(tX, tY, "B", (Color.Red), (Color.Black), GameWindow)
                                Case TILE_TYPE_WARP
                                    DrawText(tX, tY, "W", (Color.Blue), (Color.Black), GameWindow)
                                Case TILE_TYPE_ITEM
                                    DrawText(tX, tY, "I", (Color.White), (Color.Black), GameWindow)
                                Case TILE_TYPE_NPCAVOID
                                    DrawText(tX, tY, "N", (Color.White), (Color.Black), GameWindow)
                                Case TILE_TYPE_KEY
                                    DrawText(tX, tY, "K", (Color.White), (Color.Black), GameWindow)
                                Case TILE_TYPE_KEYOPEN
                                    DrawText(tX, tY, "KO", (Color.White), (Color.Black), GameWindow)
                                Case TILE_TYPE_RESOURCE
                                    DrawText(tX, tY, "R", (Color.Green), (Color.Black), GameWindow)
                                Case TILE_TYPE_DOOR
                                    DrawText(tX, tY, "D", (Color.Black), (Color.Red), GameWindow)
                                Case TILE_TYPE_NPCSPAWN
                                    DrawText(tX, tY, "S", (Color.Yellow), (Color.Black), GameWindow)
                                Case TILE_TYPE_SHOP
                                    DrawText(tX, tY, "SH", (Color.Blue), (Color.Black), GameWindow)
                                Case TILE_TYPE_BANK
                                    DrawText(tX, tY, "BA", (Color.Blue), (Color.Black), GameWindow)
                                Case TILE_TYPE_HEAL
                                    DrawText(tX, tY, "H", (Color.Green), (Color.Black), GameWindow)
                                Case TILE_TYPE_TRAP
                                    DrawText(tX, tY, "T", (Color.Red), (Color.Black), GameWindow)
                                Case TILE_TYPE_HOUSE
                                    DrawText(tX, tY, "H", (Color.Green), (Color.Black), GameWindow)
                            End Select
                        End With
                    End If
                Next
            Next
        End If

    End Sub

    Sub DrawActionMsg(ByVal Index As Long)
        Dim X As Long, y As Long, i As Long, Time As Long

        ' how long we want each message to appear
        Select Case ActionMsg(Index).Type
            Case ACTIONMSG_STATIC
                Time = 1500

                If ActionMsg(Index).Y > 0 Then
                    X = ActionMsg(Index).X + Int(PIC_X \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                    y = ActionMsg(Index).Y - Int(PIC_Y \ 2) - 2
                Else
                    X = ActionMsg(Index).X + Int(PIC_X \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                    y = ActionMsg(Index).Y - Int(PIC_Y \ 2) + 18
                End If

            Case ACTIONMSG_SCROLL
                Time = 1500

                If ActionMsg(Index).Y > 0 Then
                    X = ActionMsg(Index).X + Int(PIC_X \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                    y = ActionMsg(Index).Y - Int(PIC_Y \ 2) - 2 - (ActionMsg(Index).Scroll * 0.6)
                    ActionMsg(Index).Scroll = ActionMsg(Index).Scroll + 1
                Else
                    X = ActionMsg(Index).X + Int(PIC_X \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                    y = ActionMsg(Index).Y - Int(PIC_Y \ 2) + 18 + (ActionMsg(Index).Scroll * 0.6)
                    ActionMsg(Index).Scroll = ActionMsg(Index).Scroll + 1
                End If

            Case ACTIONMSG_SCREEN
                Time = 3000

                ' This will kill any action screen messages that there in the system
                For i = MAX_BYTE To 1 Step -1
                    If ActionMsg(i).Type = ACTIONMSG_SCREEN Then
                        If i <> Index Then
                            ClearActionMsg(Index)
                            Index = i
                        End If
                    End If
                Next
                X = (frmMainGame.picscreen.Width \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                y = 425

        End Select

        X = ConvertMapX(X)
        y = ConvertMapY(y)

        If GetTickCount() < ActionMsg(Index).Created + Time Then
            DrawText(X, y, ActionMsg(Index).message, ToSFMLColor(Drawing.ColorTranslator.FromOle(QBColor(ActionMsg(Index).color))), (Color.Black), GameWindow) 'Drawing.ColorTranslator.FromOle(QBColor(ActionMsg(Index).color))
        Else
            ClearActionMsg(Index)
        End If

    End Sub

    Public Function getTextWidth(ByVal text As String, Optional textsize As Byte = FONT_SIZE) As Long
        Dim mystring As Text = New Text(text, SFMLGameFont)
        Dim textBounds As FloatRect
        mystring.CharacterSize = textsize
        textBounds = mystring.GetLocalBounds()
        Return textBounds.Width
    End Function

    Public Sub AddText(ByVal Msg As String, ByVal Color As Long)
        If txtChatAdd = "" Then
            txtChatAdd = txtChatAdd & Msg
            AddChatRec(Msg, Color)
        Else
            For Each str As String In WordWrap(Msg, AllChatLineWidth)
                txtChatAdd = txtChatAdd & vbNewLine & str
                AddChatRec(str, Color)
            Next

        End If
    End Sub

    Public Sub AddChatRec(ByVal Msg As String, ByVal Color As Integer)
        Dim struct As ChatRec
        struct.Text = Msg
        struct.Color = Color
        Chat.Add(struct)
    End Sub

    Public Function GetSFMLColor(ByVal Color As Byte) As Color
        Select Case Color
            Case Black
                Return SFML.Graphics.Color.Black
            Case Blue
                Return New Color(73, 151, 208)
            Case Green
                Return New Color(102, 255, 0, 180)
            Case Cyan
                Return New Color(0, 139, 139)
            Case Red
                Return New Color(255, 0, 0, 180)
            Case Magenta
                Return SFML.Graphics.Color.Magenta
            Case Brown
                Return New Color(139, 69, 19)
            Case Grey
                Return New Color(211, 211, 211)
            Case DarkGrey
                Return New Color(169, 169, 169)
            Case BrightBlue
                Return New Color(0, 191, 255)
            Case BrightGreen
                Return New Color(0, 255, 0)
            Case BrightCyan
                Return New Color(0, 255, 255)
            Case BrightRed
                Return New Color(255, 0, 0)
            Case Pink
                Return New Color(255, 192, 203)
            Case Yellow
                Return SFML.Graphics.Color.Yellow
            Case White
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

            ' If adding the new word to the current line would be too long,
            ' then put it on a new line (and split it up if it's too long).
            If curLineLength + word.Length > width Then

                ' Only move down to a new line if we have text on the current line.
                ' Avoids situation where wrapped whitespace causes emptylines in text.
                If curLineLength > 0 Then
                    strBuilder.Append("|")
                    curLineLength = 0
                End If

                ' If the current word is too long to fit on a line even on it's own then
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

    'Public Sub DrawChatBubble(ByVal Index As Long)
    '    Dim theArray() As String, X As Long, Y As Long, i As Long, MaxWidth As Long, X2 As Long, Y2 As Long


    '    With chatBubble(Index)
    '        If .targetType = TARGET_TYPE_PLAYER Then
    '            ' it's a player
    '            If GetPlayerMap(.target) = GetPlayerMap(MyIndex) Then
    '                ' it's on our map - get co-ords
    '                X = ConvertMapX((Player(.target).X * 32) + Player(.target).XOffset) + 16
    '                Y = ConvertMapY((Player(.target).Y * 32) + Player(.target).YOffset) - 40
    '            End If
    '        ElseIf .targetType = TARGET_TYPE_NPC Then
    '            ' it's on our map - get co-ords
    '            X = ConvertMapX((MapNpc(.target).X * 32) + MapNpc(.target).XOffset) + 16
    '            Y = ConvertMapY((MapNpc(.target).Y * 32) + MapNpc(.target).YOffset) - 40
    '        ElseIf .targetType = TARGET_TYPE_EVENT Then
    '            X = ConvertMapX((Map.MapEvents(.target).X * 32) + Map.MapEvents(.target).XOffset) + 16
    '            Y = ConvertMapY((Map.MapEvents(.target).Y * 32) + Map.MapEvents(.target).YOffset) - 40
    '        End If
    '        ' word wrap the text
    '        WordWrap_Array(.Msg, ChatBubbleWidth, theArray)
    '        ' find max width
    '        For i = 1 To UBound(theArray)
    '            If getWidth(theArray(i)) > MaxWidth Then MaxWidth = getWidth(theArray(i))
    '        Next
    '        ' calculate the new position
    '        X2 = X - (MaxWidth \ 2)
    '        Y2 = Y - (UBound(theArray) * 12)
    '        ' render bubble - top left
    '        RenderTexture Tex_ChatBubble, X2 - 9, Y2 - 5, 0, 0, 9, 5, 9, 5, -1, True
    '    ' top right
    '        RenderTexture Tex_ChatBubble, X2 + MaxWidth, Y2 - 5, 119, 0, 9, 5, 9, 5, -1, True
    '    ' top
    '        RenderTexture Tex_ChatBubble, X2, Y2 - 5, 10, 0, MaxWidth, 5, 5, 5, -1, True
    '    ' bottom left
    '        RenderTexture Tex_ChatBubble, X2 - 9, Y, 0, 19, 9, 6, 9, 6, -1, True
    '    ' bottom right
    '        RenderTexture Tex_ChatBubble, X2 + MaxWidth, Y, 119, 19, 9, 6, 9, 6, -1, True
    '    ' bottom - left half
    '        RenderTexture Tex_ChatBubble, X2, Y, 10, 19, (MaxWidth \ 2) - 5, 6, 9, 6, -1, True
    '    ' bottom - right half
    '        RenderTexture Tex_ChatBubble, X2 + (MaxWidth \ 2) + 6, Y, 10, 19, (MaxWidth \ 2) - 5, 6, 9, 6, -1, True
    '    ' left
    '        RenderTexture Tex_ChatBubble, X2 - 9, Y2, 0, 6, 9, (UBound(theArray) * 12), 9, 1, -1, True
    '    ' right
    '        RenderTexture Tex_ChatBubble, X2 + MaxWidth, Y2, 119, 6, 9, (UBound(theArray) * 12), 9, 1, -1, True
    '    ' center
    '        RenderTexture Tex_ChatBubble, X2, Y2, 9, 5, MaxWidth, (UBound(theArray) * 12), 1, 1, -1, True
    '    ' little pointy bit
    '        RenderTexture Tex_ChatBubble, X - 5, Y, 58, 19, 11, 11, 11, 11, -1, True
    '                ' render each line centralised
    '        For i = 1 To UBound(theArray)
    '            RenderText Font_Georgia, theArray(i), X - (getWidth(theArray(i)) / 2), Y2, DarkGrey, 0, True, True
    '        Y2 = Y2 + 12
    '        Next
    '        ' check if it's timed out - close it if so
    '        If .Timer + 5000 < GetTickCount() Then
    '            .active = False
    '        End If
    '    End With

    'End Sub


End Module
