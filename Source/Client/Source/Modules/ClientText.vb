﻿Imports System.Text
Imports SFML.Graphics
Imports SFML.Window

Module ClientText
    Public Const MaxChatDisplayLines As Byte = 8
    Public Const ChatLineSpacing As Byte = FONT_SIZE ' Should be same height as font
    Public Const MyChatTextLimit As Integer = 40
    Public Const MyAmountValueLimit As Integer = 3
    Public Const AllChatLineWidth As Integer = 40
    Public Const ChatboxPadding As Integer = 10 + 16 + 2 ' 10 = left and right border padding +2 each (3+2+3+2), 16 = scrollbar width, +2 for padding between scrollbar and text
    Public Const ChatEntryPadding As Integer = 10 ' 5 on left and right
    Public FirstLineIndex As Integer = 0
    Public LastLineIndex As Integer = 0
    Public ScrollMod As Integer = 0

    Public Sub DrawText(ByVal X As Integer, ByVal Y As Integer, ByVal text As String, ByVal color As Color, ByVal BackColor As Color, ByRef target As RenderWindow, Optional TextSize As Byte = FONT_SIZE)
        Dim BackString As Text = New Text(text, SFMLGameFont)
        Dim FrontString As Text = New Text(text, SFMLGameFont)
        BackString.CharacterSize = TextSize
        FrontString.CharacterSize = TextSize

        BackString.Color = BackColor
        BackString.Position = New Vector2f(X - 1, Y - 1)
        target.Draw(BackString)

        BackString.Position = New Vector2f(X - 1, Y + 1)
        target.Draw(BackString)

        BackString.Position = New Vector2f(X + 1, Y + 1)
        target.Draw(BackString)

        BackString.Position = New Vector2f(X + 1, Y - 1)
        target.Draw(BackString)

        FrontString.Color = color
        FrontString.Position = New Vector2f(X, Y)
        target.Draw(FrontString)
    End Sub

    Public Sub DrawPlayerName(ByVal Index As Integer)
        Dim TextX As Integer
        Dim TextY As Integer
        Dim color As Color, backcolor As Color
        Dim Name As String

        ' Check access level
        If GetPlayerPK(Index) = False Then

            Select Case GetPlayerAccess(Index)
                Case AdminType.Player
                    color = Color.Red
                    backcolor = Color.Black
                Case AdminType.Monitor
                    color = Color.Black
                    backcolor = Color.White
                Case AdminType.Mapper
                    color = Color.Cyan
                    backcolor = Color.Black
                Case AdminType.Developer
                    color = Color.Green
                    backcolor = Color.Black
                Case AdminType.Creator
                    color = Color.Yellow
                    backcolor = Color.Black
            End Select

        Else
            color = Color.Red
        End If

        Name = Trim$(Player(Index).Name)
        ' calc pos
        TextX = ConvertMapX(GetPlayerX(Index) * PIC_X) + Player(Index).XOffset + (PIC_X \ 2)
        TextX = TextX - (GetTextWidth((Trim$(Name))) / 2)
        If GetPlayerSprite(Index) < 1 Or GetPlayerSprite(Index) > NumCharacters Then
            TextY = ConvertMapY(GetPlayerY(Index) * PIC_Y) + Player(Index).YOffset - 16
        Else
            ' Determine location for text
            TextY = ConvertMapY(GetPlayerY(Index) * PIC_Y) + Player(Index).YOffset - (CharacterGFXInfo(GetPlayerSprite(Index)).Height / 4) + 16
        End If

        ' Draw name
        DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
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

        TextX = ConvertMapX(MapNpc(MapNpcNum).X * PIC_X) + MapNpc(MapNpcNum).XOffset + (PIC_X \ 2) - GetTextWidth((Trim$(Npc(npcNum).Name))) / 2
        If Npc(npcNum).Sprite < 1 Or Npc(npcNum).Sprite > NumCharacters Then
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - 16
        Else
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - (CharacterGFXInfo(Npc(npcNum).Sprite).Height / 4) + 16
        End If

        ' Draw name
        DrawText(TextX, TextY, Trim$(Npc(npcNum).Name), color, backcolor, GameWindow)
    End Sub

    Public Sub DrawEventName(ByVal Index As Integer)
        Dim TextX As Integer
        Dim TextY As Integer
        Dim color As Color, backcolor As Color
        Dim Name As String, i As Integer

        color = Color.Yellow
        backcolor = Color.Black

        Name = Trim$(Map.MapEvents(Index).Name)

        ' calc pos
        TextX = ConvertMapX(Map.MapEvents(Index).X * PIC_X) + Map.MapEvents(Index).XOffset + (PIC_X \ 2) - GetTextWidth(Trim$(Name)) \ 2
        If Map.MapEvents(Index).GraphicType = 0 Then
            TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - 16
        ElseIf Map.MapEvents(Index).GraphicType = 1 Then
            If Map.MapEvents(Index).GraphicNum < 1 Or Map.MapEvents(Index).GraphicNum > NumCharacters Then
                TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - 16
            Else
                ' Determine location for text
                TextY = ConvertMapY(Map.MapEvents(Index).Y * PIC_Y) + Map.MapEvents(Index).YOffset - (CharacterGFXInfo(Map.MapEvents(Index).GraphicNum).Height \ 4) + 16
            End If
        ElseIf Map.MapEvents(Index).GraphicType = 2 Then
            If Map.MapEvents(Index).GraphicY2 > 0 Then
                TextX = TextX + (Map.MapEvents(Index).GraphicY2 * PIC_Y) \ 2 - 16
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
            If Player(MyIndex).PlayerQuest(i).Status = QuestStatus.NotStarted Or Player(MyIndex).PlayerQuest(i).Status = QuestStatus.Repeatable Or (Player(MyIndex).PlayerQuest(i).Status = QuestStatus.Completed And Quest(i).Repeat = 1) Then
                'the npc gives this quest?
                If Map.MapEvents(Index).questnum = i Then
                    Name = "[!]"
                    TextX = ConvertMapX(Map.MapEvents(Index).X * PIC_X) + Map.MapEvents(Index).XOffset + (PIC_X \ 2) - GetTextWidth((Trim$("[!]"))) + 8
                    TextY = TextY - 16
                    If Quest(i).Repeat = 1 Then
                        DrawText(TextX, TextY, Trim$(Name), Color.White, backcolor, GameWindow)
                    Else
                        DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
                    End If
                    Exit For
                End If
            ElseIf Player(MyIndex).PlayerQuest(i).Status = QuestStatus.Started Then
                If Map.MapEvents(Index).questnum = i Then
                    Name = "[*]"
                    TextX = ConvertMapX(Map.MapEvents(Index).X * PIC_X) + Map.MapEvents(Index).XOffset + (PIC_X \ 2) - GetTextWidth((Trim$("[*]"))) + 8
                    TextY = TextY - 16
                    DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
                    Exit For
                End If
            End If
        Next

    End Sub

    Public Sub DrawMapAttributes()
        Dim X As Integer
        Dim y As Integer
        Dim tX As Integer
        Dim tY As Integer

        If frmEditor_MapEditor.tabpages.SelectedTab Is frmEditor_MapEditor.tpAttributes Then
            For X = TileView.left To TileView.right
                For y = TileView.top To TileView.bottom
                    If IsValidMapPoint(X, y) Then
                        With Map.Tile(X, y)
                            tX = ((ConvertMapX(X * PIC_X)) - 4) + (PIC_X * 0.5)
                            tY = ((ConvertMapY(y * PIC_Y)) - 7) + (PIC_Y * 0.5)
                            Select Case .Type
                                Case TileType.Blocked
                                    DrawText(tX, tY, "B", (Color.Red), (Color.Black), GameWindow)
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
                                    DrawText(tX, tY, "S", (Color.Yellow), (Color.Black), GameWindow)
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
                                Case TileType.Light
                                    DrawText(tX, tY, "L", (Color.Yellow), (Color.Black), GameWindow)
                            End Select
                        End With
                    End If
                Next
            Next
        End If

    End Sub

    Sub DrawActionMsg(ByVal Index As Integer)
        Dim X As Integer, y As Integer, i As Integer, Time As Integer

        ' how long we want each message to appear
        Select Case ActionMsg(Index).Type
            Case ActionMsgType.Static
                Time = 1500

                If ActionMsg(Index).Y > 0 Then
                    X = ActionMsg(Index).X + Int(PIC_X \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                    y = ActionMsg(Index).Y - Int(PIC_Y \ 2) - 2
                Else
                    X = ActionMsg(Index).X + Int(PIC_X \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                    y = ActionMsg(Index).Y - Int(PIC_Y \ 2) + 18
                End If

            Case ActionMsgType.Scroll
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

            Case ActionMsgType.Screen
                Time = 3000

                ' This will kill any action screen messages that there in the system
                For i = Byte.MaxValue To 1 Step -1
                    If ActionMsg(i).Type = ActionMsgType.Screen Then
                        If i <> Index Then
                            ClearActionMsg(Index)
                            Index = i
                        End If
                    End If
                Next
                X = (FrmMainGame.picscreen.Width \ 2) - ((Len(Trim$(ActionMsg(Index).message)) \ 2) * 8)
                y = 425

        End Select

        X = ConvertMapX(X)
        y = ConvertMapY(y)

        If GetTickCount() < ActionMsg(Index).Created + Time Then
            DrawText(X, y, ActionMsg(Index).message, GetSFMLColor(ActionMsg(Index).color), (Color.Black), GameWindow)
        Else
            ClearActionMsg(Index)
        End If

    End Sub

    Private ReadOnly widthTester As Text = New Text("", SFMLGameFont)
    Public Function GetTextWidth(ByVal Text As String, Optional TextSize As Byte = FONT_SIZE) As Integer
        widthTester.DisplayedString = Text
        widthTester.CharacterSize = TextSize
        Return widthTester.GetLocalBounds().Width
    End Function

    Public Sub AddText(ByVal Msg As String, ByVal Color As Integer)
        If txtChatAdd = "" Then
            txtChatAdd = txtChatAdd & Msg
            AddChatRec(Msg, Color)
        Else
            For Each str As String In WordWrap(Msg, MyChatWindowGFXInfo.Width - ChatboxPadding, WrapMode.Font)
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

    Public Enum WrapMode
        Characters
        Font
    End Enum

    Public Enum WrapType
        None
        BreakWord
        Whitespace
        Smart
    End Enum

    Public Function WordWrap(ByRef str As String, ByRef width As Integer, Optional ByRef mode As WrapMode = WrapMode.Font, Optional ByRef type As WrapType = WrapType.Smart, Optional ByRef size As Byte = FONT_SIZE) As List(Of String)
        Dim lines As New List(Of String)
        Dim line As String = ""
        Dim nextLine As String = ""

        For Each word In Explode(str, SplitChars)
            Dim trim = word.Trim()
            Dim currentType = type
            Do
                Dim baseLine = If(line.Length < 1, "", line + " ")
                Dim newLine = If(nextLine.Length < 1, baseLine + trim, nextLine)
                nextLine = ""

                Select Case If(mode = WrapMode.Font, GetTextWidth(newLine, size), newLine.Length)
                    Case < width
                        line = newLine
                        Exit Select

                    Case = width
                        lines.Add(newLine)
                        line = ""
                        Exit Select

                    Case Else
                        Select Case currentType
                            Case WrapType.None
                                line = newLine
                                Exit Select

                            Case WrapType.Whitespace
                                lines.Add(If(line.Length < 1, newLine, line))
                                line = If(line.Length < 1, "", trim)
                                Exit Select

                            Case WrapType.BreakWord
                                Dim remaining = trim
                                Do
                                    If If(mode = WrapMode.Font, GetTextWidth(baseLine, size), baseLine.Length) > width Then
                                        lines.Add(line)
                                        baseLine = ""
                                        line = ""
                                    End If

                                    Dim i = remaining.Length - 1
                                    While (-1 < i)
                                        Select Case mode
                                            Case WrapMode.Font
                                                If Not (width < GetTextWidth(baseLine + remaining.Substring(0, i) + "-", size)) Then
                                                    Exit While
                                                End If
                                                Exit Select

                                            Case WrapMode.Characters
                                                If Not (width < (baseLine + remaining.Substring(0, i) + "-").Length) Then
                                                    Exit While
                                                End If
                                                Exit Select
                                        End Select
                                        i -= 1
                                    End While

                                    line = baseLine + remaining.Substring(0, i + 1) + If(remaining.Length <= i + 1, "", "-")
                                    lines.Add(line)
                                    line = ""
                                    baseLine = ""
                                    remaining = remaining.Substring(i + 1)
                                Loop While (remaining.Length > 0) And (width < If(mode = WrapMode.Font, GetTextWidth(remaining, size), remaining.Length))
                                line = remaining
                                Exit Select

                            Case WrapType.Smart
                                If (line.Length < 1) Or (width < If(mode = WrapMode.Font, GetTextWidth(trim, size), trim.Length)) Then
                                    currentType = WrapType.BreakWord
                                Else
                                    currentType = WrapType.Whitespace
                                End If
                                nextLine = newLine

                                Exit Select

                        End Select
                        Exit Select
                End Select
            Loop While (nextLine.Length > 0)
        Next

        If (line.Length > 0) Then
            lines.Add(line)
        End If

        Return lines
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

    'Public Function KeyPressed(ByVal e As KeyEventArgs) As String

    '    Dim keyValue As String = ""
    '    Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("ru-RU")
    '    Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("ru-RU")
    '    Dim kc As New KeysConverter()
    '    If e.KeyCode = 32 Then ' Space
    '        keyValue = ChrW(e.KeyCode)

    '    ElseIf e.KeyCode >= 65 AndAlso e.KeyCode <= 90 Then ' Letters
    '        If e.Shift Then
    '            keyValue = ChrW(e.KeyCode)
    '        Else
    '            keyValue = ChrW(e.KeyCode + 32)
    '        End If
    '        keyValue = kc.ConvertToString(Nothing, Threading.Thread.CurrentThread.CurrentCulture, e.KeyCode)

    '    ElseIf e.KeyCode = Keys.D0 Then
    '        If e.Shift Then
    '            keyValue = ")"
    '        Else
    '            keyValue = "0"
    '        End If

    '    ElseIf e.KeyCode = Keys.D1 Then
    '        If e.Shift Then
    '            keyValue = "!"
    '        Else
    '            keyValue = "1"
    '        End If

    '    ElseIf e.KeyCode = Keys.D2 Then
    '        If e.Shift Then
    '            keyValue = "@"
    '        Else
    '            keyValue = "2"
    '        End If

    '    ElseIf e.KeyCode = Keys.D3 Then
    '        If e.Shift Then
    '            keyValue = "#"
    '        Else
    '            keyValue = "3"
    '        End If

    '    ElseIf e.KeyCode = Keys.D4 Then
    '        If e.Shift Then
    '            keyValue = "$"
    '        Else
    '            keyValue = "4"
    '        End If

    '    ElseIf e.KeyCode = Keys.D5 Then
    '        If e.Shift Then
    '            keyValue = "%"
    '        Else
    '            keyValue = "5"
    '        End If

    '    ElseIf e.KeyCode = Keys.D6 Then
    '        If e.Shift Then
    '            keyValue = "^"
    '        Else
    '            keyValue = "6"
    '        End If

    '    ElseIf e.KeyCode = Keys.D7 Then
    '        If e.Shift Then
    '            keyValue = "&"
    '        Else
    '            keyValue = "7"
    '        End If

    '    ElseIf e.KeyCode = Keys.D8 Then
    '        If e.Shift Then
    '            keyValue = "*"
    '        Else
    '            keyValue = "8"
    '        End If

    '    ElseIf e.KeyCode = Keys.D9 Then
    '        If e.Shift Then
    '            keyValue = "("
    '        Else
    '            keyValue = "9"
    '        End If

    '    ElseIf e.KeyCode = Keys.OemPeriod Then
    '        If e.Shift Then
    '            keyValue = ">"
    '        Else
    '            keyValue = "."
    '        End If

    '    ElseIf e.KeyCode = Keys.OemPipe Then
    '        If e.Shift Then
    '            'keyValue= "|"
    '        Else
    '            keyValue = "\"
    '        End If

    '    ElseIf e.KeyCode = Keys.OemCloseBrackets Then
    '        If e.Shift Then
    '            keyValue = "}"
    '        Else
    '            keyValue = "]"
    '        End If

    '    ElseIf e.KeyCode = Keys.OemMinus Then
    '        If e.Shift Then
    '            keyValue = "_"
    '        Else
    '            keyValue = "-"
    '        End If

    '    ElseIf e.KeyCode = Keys.OemOpenBrackets Then
    '        If e.Shift Then
    '            keyValue = "{"
    '        Else
    '            keyValue = "["
    '        End If

    '    ElseIf e.KeyCode = Keys.OemQuestion Then
    '        If e.Shift Then
    '            keyValue = "?"
    '        Else
    '            keyValue = "/"
    '        End If

    '    ElseIf e.KeyCode = Keys.OemQuotes Then
    '        If e.Shift Then
    '            keyValue = Chr(34)
    '        Else
    '            keyValue = "'"
    '        End If

    '    ElseIf e.KeyCode = Keys.OemSemicolon Then
    '        If e.Shift Then
    '            keyValue = ":"
    '        Else
    '            keyValue = ";"
    '        End If

    '    ElseIf e.KeyCode = Keys.Oemcomma Then
    '        If e.Shift Then
    '            keyValue = "<"
    '        Else
    '            keyValue = ","
    '        End If

    '    ElseIf e.KeyCode = Keys.Oemplus Then
    '        If e.Shift Then
    '            keyValue = "+"
    '        Else
    '            keyValue = "="
    '        End If

    '    ElseIf e.KeyCode = Keys.Oemtilde Then
    '        If e.Shift Then
    '            keyValue = "~"
    '        Else
    '            keyValue = "`"
    '        End If

    '    End If

    '    Return keyValue

    'End Function

    Public Sub DrawChatBubble(ByVal Index As Integer)
        Dim theArray As List(Of String), X As Integer, Y As Integer, i As Integer, MaxWidth As Integer, X2 As Integer, Y2 As Integer

        With chatBubble(Index)
            If .targetType = TargetType.Player Then
                ' it's a player
                If GetPlayerMap(.target) = GetPlayerMap(MyIndex) Then
                    ' it's on our map - get co-ords
                    X = ConvertMapX((Player(.target).X * 32) + Player(.target).XOffset) + 16
                    Y = ConvertMapY((Player(.target).Y * 32) + Player(.target).YOffset) - 40
                End If
            ElseIf .targetType = TargetType.Npc Then
                ' it's on our map - get co-ords
                X = ConvertMapX((MapNpc(.target).X * 32) + MapNpc(.target).XOffset) + 16
                Y = ConvertMapY((MapNpc(.target).Y * 32) + MapNpc(.target).YOffset) - 40
            ElseIf .targetType = TargetType.Event Then
                X = ConvertMapX((Map.MapEvents(.target).X * 32) + Map.MapEvents(.target).XOffset) + 16
                Y = ConvertMapY((Map.MapEvents(.target).Y * 32) + Map.MapEvents(.target).YOffset) - 40
            End If
            ' word wrap the text
            theArray = WordWrap(.Msg, ChatBubbleWidth, WrapMode.Font)
            ' find max width
            For i = 0 To theArray.Count - 1
                If GetTextWidth(theArray(i)) > MaxWidth Then MaxWidth = GetTextWidth(theArray(i))
            Next
            ' calculate the new position
            X2 = X - (MaxWidth \ 2)
            Y2 = Y - (theArray.Count * 12)

            ' render bubble - top left
            RenderTextures(ChatBubbleGFX, GameWindow, X2 - 9, Y2 - 5, 0, 0, 9, 5, 9, 5)
            ' top right
            RenderTextures(ChatBubbleGFX, GameWindow, X2 + MaxWidth, Y2 - 5, 119, 0, 9, 5, 9, 5)
            ' top
            RenderTextures(ChatBubbleGFX, GameWindow, X2, Y2 - 5, 10, 0, MaxWidth, 5, 5, 5)
            ' bottom left
            RenderTextures(ChatBubbleGFX, GameWindow, X2 - 9, Y, 0, 19, 9, 6, 9, 6)
            ' bottom right
            RenderTextures(ChatBubbleGFX, GameWindow, X2 + MaxWidth, Y, 119, 19, 9, 6, 9, 6)
            ' bottom - left half
            RenderTextures(ChatBubbleGFX, GameWindow, X2, Y, 10, 19, (MaxWidth \ 2) - 5, 6, 9, 6)
            ' bottom - right half
            RenderTextures(ChatBubbleGFX, GameWindow, X2 + (MaxWidth \ 2) + 6, Y, 10, 19, (MaxWidth \ 2) - 5, 6, 9, 6)
            ' left
            RenderTextures(ChatBubbleGFX, GameWindow, X2 - 9, Y2, 0, 6, 9, (theArray.Count * 12), 9, 1)
            ' right
            RenderTextures(ChatBubbleGFX, GameWindow, X2 + MaxWidth, Y2, 119, 6, 9, (theArray.Count * 12), 9, 1)
            ' center
            RenderTextures(ChatBubbleGFX, GameWindow, X2, Y2, 9, 5, MaxWidth, (theArray.Count * 12), 1, 1)
            ' little pointy bit
            RenderTextures(ChatBubbleGFX, GameWindow, X - 5, Y, 58, 19, 11, 11, 11, 11)

            ' render each line centralised
            For i = 0 To theArray.Count - 1
                DrawText(X - (GetTextWidth(theArray(i)) / 2), Y2, theArray(i), ToSFMLColor(Drawing.ColorTranslator.FromOle(QBColor(.colour))), Color.Black, GameWindow)
                Y2 = Y2 + 12
            Next
            ' check if it's timed out - close it if so
            If .Timer + 5000 < GetTickCount() Then
                .active = False
            End If
        End With

    End Sub

End Module