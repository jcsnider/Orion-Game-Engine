Imports SFML.Graphics
Module modText
    'DirectX Text Drawing to GraphicsCard
    Public Sub DrawText(ByVal X As Integer, ByVal y As Integer, ByVal text As String, ByVal color As Color, ByRef target As RenderWindow)
        Dim mystring As SFML.Graphics.Text = New SFML.Graphics.Text(text, SFMLGameFont)
        mystring.CharacterSize = FONT_SIZE
        mystring.Color = color
        mystring.Position = New SFML.System.Vector2f(X, y)
        target.Draw(mystring)
    End Sub

    Public Sub DrawPlayerName(ByVal Index As Long)
        Dim TextX As Long
        Dim TextY As Long
        Dim color As Color
        Dim Name As String

        ' Check access level
        If GetPlayerPK(Index) = NO Then

            Select Case GetPlayerAccess(Index)
                Case 0
                    color = color.Red
                Case 1
                    color = color.Black
                Case 2
                    color = color.Cyan
                Case 3
                    color = color.Green
                Case 4
                    color = color.Yellow
            End Select

        Else
            color = color.Red
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
        Call DrawText(TextX, TextY, Trim$(Name), color, GameWindow)
    End Sub
    Public Sub DrawNPCName(ByVal MapNpcNum As Long)
        Dim TextX As Long
        Dim TextY As Long
        Dim color As Color
        Dim npcNum As Long

        npcNum = MapNpc(MapNpcNum).Num


        Select Case Npc(npcNum).Behaviour
            Case 0 ' attack on sight
                color = color.Red
            Case 1, 4 ' attack when attacked + guard
                color = color.Yellow
            Case 2, 3 ' friendly + shopkeeper
                color = color.Green
        End Select

        TextX = ConvertMapX(MapNpc(MapNpcNum).X * PIC_X) + MapNpc(MapNpcNum).XOffset + (PIC_X \ 2) - getWidth((Trim$(Npc(npcNum).Name))) / 2
        If Npc(npcNum).Sprite < 1 Or Npc(npcNum).Sprite > NumCharacters Then
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - 16
        Else
            TextY = ConvertMapY(MapNpc(MapNpcNum).Y * PIC_Y) + MapNpc(MapNpcNum).YOffset - (SpritesGFXInfo(Npc(npcNum).Sprite).height / 4) + 16
        End If

        ' Draw name
        Call DrawText(TextX, TextY, Trim$(Npc(npcNum).Name), color, GameWindow)
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
                                    DrawText(tX, tY, "B", (Color.Red), GameWindow)
                                Case TILE_TYPE_WARP
                                    DrawText(tX, tY, "W", (Color.Blue), GameWindow)
                                Case TILE_TYPE_ITEM
                                    DrawText(tX, tY, "I", (Color.White), GameWindow)
                                Case TILE_TYPE_NPCAVOID
                                    DrawText(tX, tY, "N", (Color.White), GameWindow)
                                Case TILE_TYPE_KEY
                                    DrawText(tX, tY, "K", (Color.White), GameWindow)
                                Case TILE_TYPE_KEYOPEN
                                    DrawText(tX, tY, "O", (Color.White), GameWindow)
                                Case TILE_TYPE_RESOURCE
                                    DrawText(tX, tY, "O", (Color.Green), GameWindow)
                                Case TILE_TYPE_DOOR
                                    DrawText(tX, tY, "D", (Color.Black), GameWindow)
                                Case TILE_TYPE_NPCSPAWN
                                    DrawText(tX, tY, "S", (Color.Yellow), GameWindow)
                                Case TILE_TYPE_SHOP
                                    DrawText(tX, tY, "S", (Color.Blue), GameWindow)
                                Case TILE_TYPE_BANK
                                    DrawText(tX, tY, "B", (Color.Blue), GameWindow)
                                Case TILE_TYPE_HEAL
                                    DrawText(tX, tY, "H", (Color.Green), GameWindow)
                                Case TILE_TYPE_TRAP
                                    DrawText(tX, tY, "T", (Color.Red), GameWindow)
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
            Call DrawText(X, y, ActionMsg(Index).message, Color.Red, GameWindow) 'QBColor(ActionMsg(Index).color))
        Else
            ClearActionMsg(Index)
        End If

    End Sub

    Public Function getWidth(ByVal text As String) As Long
        Dim mystring As SFML.Graphics.Text = New SFML.Graphics.Text(text, SFMLGameFont)
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
End Module
