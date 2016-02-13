Imports SFML.Graphics

Module ClientText
    'DirectX Text Drawing to GraphicsCard
    Public Sub DrawText(ByVal X As Integer, ByVal y As Integer, ByVal text As String, ByVal color As Color, ByVal BackColor As Color, ByRef target As RenderWindow)
        Dim mystring As Text = New Text(text, SFMLGameFont)
        mystring.CharacterSize = FONT_SIZE

        mystring.Color = BackColor
        mystring.Position = New SFML.System.Vector2f(X - 1, y - 1)
        target.Draw(mystring)

        mystring.Position = New SFML.System.Vector2f(X - 1, y + 1)
        target.Draw(mystring)

        mystring.Position = New SFML.System.Vector2f(X + 1, y + 1)
        target.Draw(mystring)

        mystring.Position = New SFML.System.Vector2f(X + 1, y + -1)
        target.Draw(mystring)

        mystring.Color = color
        mystring.Position = New SFML.System.Vector2f(X, y)
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
        TextX = TextX - (getWidth((Trim$(Name))) / 2)
        If GetPlayerSprite(Index) < 1 Or GetPlayerSprite(Index) > NumCharacters Then
            TextY = ConvertMapY(GetPlayerY(Index) * PIC_Y) + Player(Index).YOffset - 16
        Else
            ' Determine location for text
            TextY = ConvertMapY(GetPlayerY(Index) * PIC_Y) + Player(Index).YOffset - (SpritesGFXInfo(GetPlayerSprite(Index)).height / 4) + 16
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

        TextX = ConvertMapX(MapNpc(MapNpcNum).X * PIC_X) + MapNpc(MapNpcNum).XOffset + (PIC_X \ 2) - getWidth((Trim$(Npc(npcNum).Name))) / 2
        If Npc(npcNum).Sprite < 1 Or Npc(npcNum).Sprite > NumCharacters Then
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - 16
        Else
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - (SpritesGFXInfo(Npc(npcNum).Sprite).height / 4) + 16
        End If

        ' Draw name
        Call DrawText(TextX, TextY, Trim$(Npc(npcNum).Name), color, backcolor, GameWindow)
    End Sub

    Public Sub DrawMapAttributes()
        Dim X As Long
        Dim y As Long
        Dim tX As Long
        Dim tY As Long

        If frmEditor_Map.optAttributes.Checked Then
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

    Public Function getWidth(ByVal text As String) As Long
        Dim mystring As Text = New Text(text, SFMLGameFont)
        Dim textBounds As FloatRect
        mystring.CharacterSize = FONT_SIZE
        textBounds = mystring.GetLocalBounds()
        Return textBounds.Width
    End Function

    Public Sub AddText(ByVal Msg As String)
        If txtChatAdd = "" Then
            txtChatAdd = txtChatAdd & Msg
        Else
            txtChatAdd = txtChatAdd & vbNewLine & Msg
        End If
    End Sub

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

    Public Sub WordWrap_Array(ByVal Text As String, ByVal MaxLineLen As Long, ByRef theArray() As String)
        Dim lineCount As Long, i As Long, size As Long, lastSpace As Long, b As Long

        'Too small of text

        If Len(Text) < 2 Then
            ReDim theArray(0 To 1)
            theArray(1) = Text
            Exit Sub
        End If
        ' default values
        b = 1
        lastSpace = 1
        size = 0
        For i = 1 To Len(Text)
            ' if it's a space, store it
            Select Case Mid$(Text, i, 1)
                Case " " : lastSpace = i
                Case "_" : lastSpace = i
                Case "-" : lastSpace = i
            End Select
            'Add up the size
            size = size + getWidth(Asc(Mid$(Text, i, 1)))
            'Check for too large of a size
            If size > MaxLineLen Then
                'Check if the last space was too far back
                If i - lastSpace > 12 Then
                    'Too far away to the last space, so break at the last character
                    lineCount = lineCount + 1
                    ReDim Preserve theArray(0 To lineCount)
                    theArray(lineCount) = Trim$(Mid$(Text, b, (i - 1) - b))
                    b = i - 1
                    size = 0
                Else
                    'Break at the last space to preserve the word
                    lineCount = lineCount + 1
                    ReDim Preserve theArray(0 To lineCount)
                    theArray(lineCount) = Trim$(Mid$(Text, b, lastSpace - b))
                    b = lastSpace + 1
                    'Count all the words we ignored (the ones that weren't printed, but are before "i")
                    size = getWidth(Mid$(Text, lastSpace, i - lastSpace))
                End If
            End If
            ' Remainder
            If i = Len(Text) Then
                If b <> i Then
                    lineCount = lineCount + 1
                    ReDim Preserve theArray(0 To lineCount)
                    theArray(lineCount) = theArray(lineCount) & Mid$(Text, b, i)
                End If
            End If
        Next

    End Sub

    Public Function WordWrap(ByVal Text As String, ByVal MaxLineLen As Integer) As String
        Dim TempSplit() As String
        Dim TSLoop As Long
        Dim lastSpace As Long
        Dim size As Long
        Dim i As Long
        Dim b As Long

        WordWrap = ""

        'Too small of text
        If Len(Text) < 2 Then
            WordWrap = Text
            Exit Function
        End If

        'Check if there are any line breaks - if so, we will support them
        TempSplit = Split(Text, vbNewLine)
        For TSLoop = 0 To UBound(TempSplit)
            'Clear the values for the new line
            size = 0
            b = 1
            lastSpace = 1
            'Add back in the vbNewLines
            If TSLoop < UBound(TempSplit) Then TempSplit(TSLoop) = TempSplit(TSLoop) & vbNewLine
            'Only check lines with a space
            If InStr(1, TempSplit(TSLoop), " ") Or InStr(1, TempSplit(TSLoop), "-") Or InStr(1, TempSplit(TSLoop), "_") Then
                'Loop through all the characters
                For i = 1 To Len(TempSplit(TSLoop))
                    'If it is a space, store it so we can easily break at it
                    Select Case Mid$(TempSplit(TSLoop), i, 1)
                        Case " " : lastSpace = i
                        Case "_" : lastSpace = i
                        Case "-" : lastSpace = i
                    End Select
                    'Add up the size
                    size = size + getWidth(Asc(Mid$(TempSplit(TSLoop), i, 1)))

                    'Check for too large of a size
                    If size > MaxLineLen Then
                        'Check if the last space was too far back
                        If i - lastSpace > 12 Then
                            'Too far away to the last space, so break at the last character
                            WordWrap = WordWrap & Trim$(Mid$(TempSplit(TSLoop), b, (i - 1) - b)) & vbNewLine
                            b = i - 1
                            size = 0
                        Else
                            'Break at the last space to preserve the word
                            WordWrap = WordWrap & Trim$(Mid$(TempSplit(TSLoop), b, lastSpace - b)) & vbNewLine
                            b = lastSpace + 1
                            'Count all the words we ignored (the ones that weren't printed, but are before "i")
                            size = getWidth(Mid$(TempSplit(TSLoop), lastSpace, i - lastSpace))
                        End If
                    End If
                    'This handles the remainder
                    If i = Len(TempSplit(TSLoop)) Then
                        If b <> i Then
                            WordWrap = WordWrap & Mid$(TempSplit(TSLoop), b, i)
                        End If
                    End If
                Next i
            Else
                WordWrap = WordWrap & TempSplit(TSLoop)
            End If
        Next

    End Function
End Module
