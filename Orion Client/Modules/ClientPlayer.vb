Public Module ClientPlayer
    Sub CheckAttack()
        Dim attackspeed As Long, X As Long, Y As Long
        Dim Buffer As ByteBuffer

        If VbKeyControl Then
            If InEvent = True Then Exit Sub
            If SpellBuffer > 0 Then Exit Sub ' currently casting a spell, can't attack
            If StunDuration > 0 Then Exit Sub ' stunned, can't attack

            ' speed from weapon
            If GetPlayerEquipment(MyIndex, Equipment.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(MyIndex, Equipment.Weapon)).Speed * 1000
            Else
                attackspeed = 1000
            End If

            If Player(MyIndex).AttackTimer + attackspeed < GetTickCount() Then
                If Player(MyIndex).Attacking = 0 Then

                    With Player(MyIndex)
                        .Attacking = 1
                        .AttackTimer = GetTickCount()
                    End With

                    SendAttack()
                End If
            End If

            Select Case Player(MyIndex).Dir
                Case DIR_UP
                    X = GetPlayerX(MyIndex)
                    Y = GetPlayerY(MyIndex) - 1
                Case DIR_DOWN
                    X = GetPlayerX(MyIndex)
                    Y = GetPlayerY(MyIndex) + 1
                Case DIR_LEFT
                    X = GetPlayerX(MyIndex) - 1
                    Y = GetPlayerY(MyIndex)
                Case DIR_RIGHT
                    X = GetPlayerX(MyIndex) + 1
                    Y = GetPlayerY(MyIndex)
            End Select

            If GetTickCount() > Player(MyIndex).EventTimer Then
                For i = 1 To Map.CurrentEvents
                    If Map.MapEvents(i).Visible = 1 Then
                        If Map.MapEvents(i).X = X And Map.MapEvents(i).Y = Y Then
                            Buffer = New ByteBuffer
                            Buffer.WriteLong(ClientPackets.CEvent)
                            Buffer.WriteLong(i)
                            SendData(Buffer.ToArray)
                            Buffer = Nothing
                            Player(MyIndex).EventTimer = GetTickCount() + 200
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Sub CheckMovement()

        If IsTryingToMove() Then
            If CanMove() Then

                ' Check if player has the shift key down for running
                If VbKeyShift Then
                    Player(MyIndex).Moving = MOVING_RUNNING
                Else
                    Player(MyIndex).Moving = MOVING_WALKING
                End If

                Select Case GetPlayerDir(MyIndex)
                    Case DIR_UP
                        Call SendPlayerMove()
                        Player(MyIndex).YOffset = PIC_Y
                        Call SetPlayerY(MyIndex, GetPlayerY(MyIndex) - 1)
                    Case DIR_DOWN
                        Call SendPlayerMove()
                        Player(MyIndex).YOffset = PIC_Y * -1
                        Call SetPlayerY(MyIndex, GetPlayerY(MyIndex) + 1)
                    Case DIR_LEFT
                        Call SendPlayerMove()
                        Player(MyIndex).XOffset = PIC_X
                        Call SetPlayerX(MyIndex, GetPlayerX(MyIndex) - 1)
                    Case DIR_RIGHT
                        Call SendPlayerMove()
                        Player(MyIndex).XOffset = PIC_X * -1
                        Call SetPlayerX(MyIndex, GetPlayerX(MyIndex) + 1)
                End Select

                If Player(MyIndex).XOffset = 0 Then
                    If Player(MyIndex).YOffset = 0 Then
                        If Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).Type = TILE_TYPE_WARP Then
                            GettingMap = True
                            Debug.Print("CheckMovement: " & GettingMap)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Function IsTryingToMove() As Boolean

        If DirUp Or DirDown Or DirLeft Or DirRight Then
            IsTryingToMove = True
        End If

    End Function

    Function CanMove() As Boolean
        Dim d As Long
        CanMove = True

        If GettingMap = True Then
            CanMove = False
            Exit Function
        End If

        ' Make sure they aren't trying to move when they are already moving
        If Player(MyIndex).Moving <> 0 Then
            CanMove = False
            Exit Function
        End If

        ' Make sure they haven't just casted a spell
        If SpellBuffer > 0 Then
            CanMove = False
            Exit Function
        End If

        ' make sure they're not stunned
        If StunDuration > 0 Then
            CanMove = False
            Exit Function
        End If

        If InEvent Then
            CanMove = False
            Exit Function
        End If

        ' make sure they're not in a shop
        If InShop > 0 Then
            CanMove = False
            Exit Function
        End If

        If InTrade Then
            CanMove = False
            Exit Function
        End If

        ' not in bank
        If InBank Then
            CanMove = False
            Exit Function
        End If

        d = GetPlayerDir(MyIndex)

        If DirUp Then
            SetPlayerDir(MyIndex, DIR_UP)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerY(MyIndex) > 0 Then
                If CheckDirection(DIR_UP) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_UP Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Up > 0 Then
                    MapEditorLeaveMap()
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirDown Then
            SetPlayerDir(MyIndex, DIR_DOWN)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerY(MyIndex) < Map.MaxY Then
                If CheckDirection(DIR_DOWN) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_DOWN Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Down > 0 Then
                    MapEditorLeaveMap()
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirLeft Then
            SetPlayerDir(MyIndex, DIR_LEFT)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerX(MyIndex) > 0 Then
                If CheckDirection(DIR_LEFT) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_LEFT Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Left > 0 Then
                    MapEditorLeaveMap()
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirRight Then
            SetPlayerDir(MyIndex, DIR_RIGHT)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerX(MyIndex) < Map.MaxX Then
                If CheckDirection(DIR_RIGHT) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DIR_RIGHT Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If

            Else

                ' Check if they can warp to a new map
                If Map.Right > 0 Then
                    MapEditorLeaveMap()
                    SendPlayerRequestNewMap()
                    GettingMap = True
                    CanMoveNow = False
                End If

                CanMove = False
                Exit Function
            End If
        End If

    End Function

    Function CheckDirection(ByVal Direction As Byte) As Boolean
        Dim X As Long, Y As Long
        Dim i As Long, z As Long
        Dim Buffer As ByteBuffer

        CheckDirection = False

        ' check directional blocking
        If isDirBlocked(Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).DirBlock, Direction + 1) Then
            CheckDirection = True
            Exit Function
        End If

        Select Case Direction
            Case DIR_UP
                X = GetPlayerX(MyIndex)
                Y = GetPlayerY(MyIndex) - 1
            Case DIR_DOWN
                X = GetPlayerX(MyIndex)
                Y = GetPlayerY(MyIndex) + 1
            Case DIR_LEFT
                X = GetPlayerX(MyIndex) - 1
                Y = GetPlayerY(MyIndex)
            Case DIR_RIGHT
                X = GetPlayerX(MyIndex) + 1
                Y = GetPlayerY(MyIndex)
        End Select

        ' Check to see if the map tile is blocked or not
        If Map.Tile(X, Y).Type = TILE_TYPE_BLOCKED Then
            CheckDirection = True
            Exit Function
        End If

        ' Check to see if the map tile is tree or not
        If Map.Tile(X, Y).Type = TILE_TYPE_RESOURCE Then
            CheckDirection = True
            Exit Function
        End If

        ' Check to see if the key door is open or not
        If Map.Tile(X, Y).Type = TILE_TYPE_KEY Then

            ' This actually checks if its open or not
            If TempTile(X, Y).DoorOpen = NO Then
                CheckDirection = True
                Exit Function
            End If
        End If

        If FurnitureHouse > 0 Then
            If FurnitureHouse = Player(MyIndex).InHouse Then
                If FurnitureCount > 0 Then
                    For i = 1 To FurnitureCount
                        If Item(Furniture(i).ItemNum).Data3 = 0 Then
                            If X >= Furniture(i).X And X <= Furniture(i).X + Item(Furniture(i).ItemNum).FurnitureWidth - 1 Then
                                If Y <= Furniture(i).Y And Y >= Furniture(i).Y - Item(Furniture(i).ItemNum).FurnitureHeight Then
                                    z = Item(Furniture(i).ItemNum).FurnitureBlocks(X - Furniture(i).X, ((Furniture(i).Y - Y) * -1) + Item(Furniture(i).ItemNum).FurnitureHeight)
                                    If z = 1 Then CheckDirection = True : Exit Function
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        End If

        ' Check to see if a player is already on that tile
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                If GetPlayerX(i) = X Then
                    If GetPlayerY(i) = Y Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If
        Next i

        ' Check to see if a npc is already on that tile
        For i = 1 To MAX_MAP_NPCS

            If MapNpc(i).Num > 0 Then
                If MapNpc(i).X = X Then
                    If MapNpc(i).Y = Y Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If

        Next

        For i = 1 To Map.CurrentEvents
            If Map.MapEvents(i).Visible = 1 Then
                If Map.MapEvents(i).X = X Then
                    If Map.MapEvents(i).Y = Y Then
                        'We are walking on top of OR tried to touch an event. Time to Handle the commands
                        Buffer = New ByteBuffer
                        Buffer.WriteLong(ClientPackets.CEventTouch)
                        Buffer.WriteLong(i)
                        SendData(Buffer.ToArray)
                        Buffer = Nothing
                        If Map.MapEvents(i).WalkThrough = 0 Then
                            CheckDirection = True
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next

    End Function

    Sub ProcessMovement(ByVal Index As Long)
        Dim MovementSpeed As Long

        ' Check if player is walking, and if so process moving them over
        Select Case Player(Index).Moving
            Case MOVING_WALKING : MovementSpeed = ((ElapsedTime / 1000) * (WALK_SPEED * SIZE_X))
            Case MOVING_RUNNING : MovementSpeed = ((ElapsedTime / 1000) * (RUN_SPEED * SIZE_X))
            Case Else : Exit Sub
        End Select

        Select Case GetPlayerDir(Index)
            Case DIR_UP
                Player(Index).YOffset = Player(Index).YOffset - MovementSpeed
                If Player(Index).YOffset < 0 Then Player(Index).YOffset = 0
            Case DIR_DOWN
                Player(Index).YOffset = Player(Index).YOffset + MovementSpeed
                If Player(Index).YOffset > 0 Then Player(Index).YOffset = 0
            Case DIR_LEFT
                Player(Index).XOffset = Player(Index).XOffset - MovementSpeed
                If Player(Index).XOffset < 0 Then Player(Index).XOffset = 0
            Case DIR_RIGHT
                Player(Index).XOffset = Player(Index).XOffset + MovementSpeed
                If Player(Index).XOffset > 0 Then Player(Index).XOffset = 0
        End Select

        ' Check if completed walking over to the next tile
        If Player(Index).Moving > 0 Then
            If GetPlayerDir(Index) = DIR_RIGHT Or GetPlayerDir(Index) = DIR_DOWN Then
                If (Player(Index).XOffset >= 0) And (Player(Index).YOffset >= 0) Then
                    Player(Index).Moving = 0
                    If Player(Index).Steps = 1 Then
                        Player(Index).Steps = 3
                    Else
                        Player(Index).Steps = 1
                    End If
                End If
            Else
                If (Player(Index).XOffset <= 0) And (Player(Index).YOffset <= 0) Then
                    Player(Index).Moving = 0
                    If Player(Index).Steps = 1 Then
                        Player(Index).Steps = 3
                    Else
                        Player(Index).Steps = 1
                    End If
                End If
            End If
        End If

    End Sub

    Function GetPlayerDir(ByVal Index As Long) As Long

        If Index > MAX_PLAYERS Then Exit Function
        GetPlayerDir = Player(Index).Dir
    End Function

    Function GetPlayerGatherSkillLvl(ByVal Index As Long, ByVal SkillSlot As Long) As Long

        GetPlayerGatherSkillLvl = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillLvl = Player(Index).GatherSkills(SkillSlot).SkillLevel
    End Function

    Function GetPlayerGatherSkillExp(ByVal Index As Long, ByVal SkillSlot As Long) As Long

        GetPlayerGatherSkillExp = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillExp = Player(Index).GatherSkills(SkillSlot).SkillCurExp
    End Function

    Function GetPlayerGatherSkillMaxExp(ByVal Index As Long, ByVal SkillSlot As Long) As Long

        GetPlayerGatherSkillMaxExp = 0

        If Index > MAX_PLAYERS Then Exit Function

        GetPlayerGatherSkillMaxExp = Player(Index).GatherSkills(SkillSlot).SkillNextLvlExp
    End Function

    Public Sub PlayerCastSpell(ByVal spellslot As Long)
        Dim Buffer As ByteBuffer

        ' Check for subscript out of range
        If spellslot < 1 Or spellslot > MAX_PLAYER_SPELLS Then
            Exit Sub
        End If

        If SpellCD(spellslot) > 0 Then
            AddText("Spell has not cooled down yet!", AlertColor)
            Exit Sub
        End If

        ' Check if player has enough MP
        If GetPlayerVital(MyIndex, Vitals.MP) < Spell(PlayerSpells(spellslot)).MPCost Then
            AddText("Not enough MP to cast " & Trim$(Spell(PlayerSpells(spellslot)).Name) & ".", AlertColor)
            Exit Sub
        End If

        If PlayerSpells(spellslot) > 0 Then
            If GetTickCount() > Player(MyIndex).AttackTimer + 1000 Then
                If Player(MyIndex).Moving = 0 Then
                    Buffer = New ByteBuffer
                    Buffer.WriteLong(ClientPackets.CCast)
                    Buffer.WriteLong(spellslot)
                    SendData(Buffer.ToArray())
                    Buffer = Nothing
                    SpellBuffer = spellslot
                    SpellBufferTimer = GetTickCount()
                Else
                    AddText("Cannot cast while walking!", AlertColor)
                End If
            End If
        Else
            AddText("No spell here.", AlertColor)
        End If

    End Sub
End Module
