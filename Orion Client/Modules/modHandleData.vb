Module modHandleData
    Public PlayerBuffer As ByteBuffer
    Public Sub HandleData(ByVal data() As Byte)
        Dim Buffer() As Byte
        Buffer = data.Clone
        Dim pLength As Long
        Dim i As Long
        Dim tmpdata() As Byte

        If PlayerBuffer Is Nothing Then PlayerBuffer = New ByteBuffer
        PlayerBuffer.WriteBytes(Buffer)

        If PlayerBuffer.Count = 0 Then
            PlayerBuffer.Clear()
            Exit Sub
        End If

        If PlayerBuffer.Length >= 4 Then
            pLength = PlayerBuffer.ReadLong(False)

            If pLength <= 0 Then
                PlayerBuffer.Clear()
                Exit Sub
            End If
        End If

        Do While pLength > 0 And pLength <= PlayerBuffer.Length - 8

            If pLength <= PlayerBuffer.Length - 8 Then
                PlayerBuffer.ReadLong()
                data = PlayerBuffer.ReadBytes(pLength)
                HandleDataPackets(data)
            End If

            pLength = 0

            If PlayerBuffer.Length >= 8 Then
                pLength = PlayerBuffer.ReadLong(False)

                If pLength < 0 Then
                    Exit Sub
                End If
            Else
                If PlayerBuffer.GetReadPos >= PlayerBuffer.Length Then
                    PlayerBuffer.Clear()
                    Exit Sub
                Else
                    If Buffer(PlayerBuffer.GetReadPos) > 0 Then
                        i = PlayerBuffer.GetReadPos
                        ReDim tmpdata(PlayerBuffer.Length - 1)
                        Array.Copy(Buffer, PlayerBuffer.GetReadPos, tmpdata, 0, PlayerBuffer.Length - 1)
                        PlayerBuffer.Clear()
                        PlayerBuffer.WriteBytes(tmpdata)
                        Exit Sub
                    End If
                End If
            End If

        Loop

        If pLength <= 1 Then PlayerBuffer.Clear()
    End Sub
    Sub HandleDataPackets(ByVal data() As Byte)
        Dim packetnum As Long
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        packetnum = buffer.ReadLong
        buffer = Nothing
        If packetnum = 0 Then Exit Sub
        If packetnum = ServerPackets.SAlertMsg Then Call Packet_AlertMSG(data)
        If packetnum = ServerPackets.SLoginOk Then Call Packet_LoginOk(data)
        If packetnum = ServerPackets.SNewCharClasses Then Call Packet_NewCharClasses(data)
        If packetnum = ServerPackets.SClassesData Then Call Packet_ClassesData(data)
        If packetnum = ServerPackets.SInGame Then Call Packet_InGame(data)
        If packetnum = ServerPackets.SPlayerInv Then Call Packet_PlayerInv(data)
        If packetnum = ServerPackets.SPlayerInvUpdate Then Call Packet_PlayerInvUpdate(data)
        If packetnum = ServerPackets.SPlayerWornEq Then Packet_PlayerWornEquipment(data)
        If packetnum = ServerPackets.SPlayerHp Then Call Packet_PlayerHP(data)
        If packetnum = ServerPackets.SPlayerMp Then Call Packet_PlayerMP(data)
        If packetnum = ServerPackets.SPlayerSp Then Call Packet_PlayerSP(data)
        If packetnum = ServerPackets.SPlayerStats Then Call Packet_PlayerStats(data)
        If packetnum = ServerPackets.SPlayerData Then Call Packet_PlayerData(data)
        If packetnum = ServerPackets.SPlayerMove Then Call Packet_PlayerMove(data)
        If packetnum = ServerPackets.SNpcMove Then Call Packet_NpcMove(data)
        If packetnum = ServerPackets.SPlayerDir Then Call Packet_PlayerDir(data)
        If packetnum = ServerPackets.SNpcDir Then Call Packet_NpcDir(data)
        If packetnum = ServerPackets.SPlayerXY Then Call Packet_PlayerXY(data)
        If packetnum = ServerPackets.SAttack Then Call Packet_Attack(data)
        If packetnum = ServerPackets.SNpcAttack Then Call Packet_NpcAttack(data)
        If packetnum = ServerPackets.SCheckforMap Then Call Packet_CheckMap(data)
        If packetnum = ServerPackets.SMapData Then Call Packet_MapData(data)
        If packetnum = ServerPackets.SMapNpcData Then Call Packet_MapNPCData(data)
        If packetnum = ServerPackets.SMapDone Then Call Packet_MapDone(data)
        If packetnum = ServerPackets.SGlobalMsg Then Call Packet_GlobalMessage(data)
        If packetnum = ServerPackets.SPlayerMsg Then Call Packet_PlayerMessage(data)
        If packetnum = ServerPackets.SMapMsg Then Call Packet_MapMessage(data)
        If packetnum = ServerPackets.SSpawnItem Then Call Packet_SpawnItem(data)
        If packetnum = ServerPackets.SItemEditor Then Call Packet_EditItem(data)
        If packetnum = ServerPackets.SUpdateItem Then Call Packet_UpdateItem(data)
        If packetnum = ServerPackets.SSpawnNpc Then Call Packet_SpawnNPC(data)
        If packetnum = ServerPackets.SNpcDead Then Call Packet_NpcDead(data)
        If packetnum = ServerPackets.SNpcEditor Then Call Packet_NPCEditor(data)
        If packetnum = ServerPackets.SUpdateNpc Then Call Packet_UpdateNPC(data)
        If packetnum = ServerPackets.SMapKey Then Call Packet_MapKey(data)
        If packetnum = ServerPackets.SEditMap Then Call Packet_EditMap(data)
        If packetnum = ServerPackets.SShopEditor Then Call Packet_EditShop(data)
        If packetnum = ServerPackets.SUpdateShop Then Call Packet_UpdateShop(data)
        If packetnum = ServerPackets.SSpellEditor Then Call Packet_EditSpell(data)
        If packetnum = ServerPackets.SUpdateSpell Then Call Packet_UpdateSpell(data)
        If packetnum = ServerPackets.SSpells Then Call Packet_Spells(data)
        If packetnum = ServerPackets.SLeft Then Call Packet_LeftMap(data)
        If packetnum = ServerPackets.SResourceCache Then Call Packet_ResourceCache(data)
        If packetnum = ServerPackets.SResourceEditor Then Call Packet_ResourceEditor(data)
        If packetnum = ServerPackets.SUpdateResource Then Call Packet_UpdateResource(data)
        If packetnum = ServerPackets.SSendPing Then Call Packet_Ping(data)
        If packetnum = ServerPackets.SDoorAnimation Then Call Packet_DoorAnimation(data)
        If packetnum = ServerPackets.SActionMsg Then Call Packet_ActionMessage(data)
        If packetnum = ServerPackets.SPlayerEXP Then Call Packet_PlayerExp(data)
        If packetnum = ServerPackets.SBlood Then Call Packet_Blood(data)
        If packetnum = ServerPackets.SAnimationEditor Then Call Packet_EditAnimation(data)
        If packetnum = ServerPackets.SUpdateAnimation Then Call Packet_UpdateAnimation(data)
        If packetnum = ServerPackets.SAnimation Then Call Packet_Animation(data)
        If packetnum = ServerPackets.SMapNpcVitals Then Call Packet_NPCVitals(data)
        If packetnum = ServerPackets.SCooldown Then Call Packet_Cooldown(data)
        If packetnum = ServerPackets.SClearSpellBuffer Then Call Packet_ClearSpellBuffer(data)
        If packetnum = ServerPackets.SSayMsg Then Call Packet_SayMessage(data)
        If packetnum = ServerPackets.SOpenShop Then Call Packet_OpenShop(data)
        If packetnum = ServerPackets.SResetShopAction Then Call Packet_ResetShopAction(data)
        If packetnum = ServerPackets.SStunned Then Call Packet_Stunned(data)
        If packetnum = ServerPackets.SMapWornEq Then Call Packet_MapWornEquipment(data)
        If packetnum = ServerPackets.SBank Then Call Packet_OpenBank(data)
        If packetnum = ServerPackets.SClearTradeTimer Then Call Packet_ClearTradeTimer(data)
        If packetnum = ServerPackets.STrade Then Call Packet_Trade(data)
        If packetnum = ServerPackets.SCloseTrade Then Call Packet_CloseTrade(data)
        If packetnum = ServerPackets.STradeUpdate Then Call Packet_TradeUpdate(data)
        If packetnum = ServerPackets.STradeStatus Then Call Packet_TradeStatus(data)
        If packetnum = ServerPackets.SGameData Then Call Packet_GameData(data)
    End Sub
    Sub Packet_AlertMSG(ByVal data() As Byte)
        Dim Msg As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SAlertMsg Then Exit Sub
        frmloadvisible = False

        If frmMenu.Visible = False Then
            frmmenuvisible = True
        End If

        pnlCharCreateVisible = False
        pnlLoginVisible = False
        pnlRegisterVisible = False

        Msg = Buffer.ReadString
        Buffer = Nothing
        Call MsgBox(Msg, vbOKOnly, GAME_NAME)
        DestroyGame()
    End Sub
    Sub Packet_LoginOk(ByRef Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SLoginOk Then Exit Sub

        ' save options
        Options.SavePass = chkSavePassChecked
        Options.Username = Trim$(tempUserName)

        If chkSavePassChecked = False Then
            Options.Password = vbNullString
        Else
            Options.Password = Trim$(tempPassword)
        End If

        SaveOptions()

        ' Now we can receive game data
        MyIndex = Buffer.ReadLong 'CLng(Parse(1))
        Buffer = Nothing
        frmloadvisible = True
        Call SetStatus("Receiving game data...")
    End Sub
    Sub Packet_NewCharClasses(ByVal data() As Byte)
        Dim n As Long, i As Long, z As Long, X As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SNewCharClasses Then Exit Sub
        n = 1
        ' Max classes
        Max_Classes = Buffer.ReadLong
        ReDim Classes(0 To Max_Classes)
        n = n + 1
        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Buffer.ReadString

                ReDim .Vital(0 To Vitals.Vital_Count - 1)

                .Vital(Vitals.HP) = Buffer.ReadLong
                .Vital(Vitals.MP) = Buffer.ReadLong
                .Vital(Vitals.SP) = Buffer.ReadLong

                ' get array size
                z = Buffer.ReadLong
                ' redim array
                ReDim .MaleSprite(0 To z + 1)
                ' loop-receive data
                For X = 1 To z + 1
                    .MaleSprite(X) = Buffer.ReadLong
                Next

                ' get array size
                z = Buffer.ReadLong
                ' redim array
                ReDim .FemaleSprite(0 To z + 1)
                ' loop-receive data
                For X = 1 To z + 1
                    .FemaleSprite(X) = Buffer.ReadLong
                Next

                ReDim .Stat(0 To Stats.stat_count - 1)

                .Stat(Stats.strength) = Buffer.ReadLong
                .Stat(Stats.endurance) = Buffer.ReadLong
                .Stat(Stats.vitality) = Buffer.ReadLong
                .Stat(Stats.intelligence) = Buffer.ReadLong
                .Stat(Stats.willpower) = Buffer.ReadLong
                .Stat(Stats.spirit) = Buffer.ReadLong
            End With

            n = n + 10
        Next

        Buffer = Nothing

        ' Used for if the player is creating a new character
        frmmenuvisible = True
        frmLoadvisible = False
        pnlCreditsVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = True
        pnlLoginVisible = False

        ReDim cmbclass(0 To Max_Classes)

        For i = 1 To Max_Classes
            cmbclass(i) = Classes(i).Name
        Next

        newCharSprite = 1
    End Sub
    Private Sub Packet_ClassesData(ByRef data() As Byte)
        Dim n As Long
        Dim i As Long
        Dim z As Long, X As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        n = 1

        If Buffer.ReadLong <> ServerPackets.SClassesData Then Exit Sub

        ' Max classes
        Max_Classes = Buffer.ReadLong 'CByte(Parse(n))
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.stat_count - 1)
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Vital(0 To Vitals.Vital_Count - 1)
        Next

        n = n + 1

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Buffer.ReadString 'Trim$(Parse(n))
                .Vital(Vitals.HP) = Buffer.ReadLong 'CLng(Parse(n + 1))
                .Vital(Vitals.MP) = Buffer.ReadLong 'CLng(Parse(n + 2))
                .Vital(Vitals.SP) = Buffer.ReadLong 'CLng(Parse(n + 3))

                ' get array size
                z = Buffer.ReadLong
                ' redim array
                ReDim .MaleSprite(0 To z)
                ' loop-receive data
                For X = 0 To z
                    .MaleSprite(X) = Buffer.ReadLong
                Next

                ' get array size
                z = Buffer.ReadLong
                ' redim array
                ReDim .FemaleSprite(0 To z)
                ' loop-receive data
                For X = 0 To z
                    .FemaleSprite(X) = Buffer.ReadLong
                Next

                .Stat(Stats.strength) = Buffer.ReadLong 'CLng(Parse(n + 4))
                .Stat(Stats.endurance) = Buffer.ReadLong
                .Stat(Stats.vitality) = Buffer.ReadLong
                .Stat(Stats.intelligence) = Buffer.ReadLong
                .Stat(Stats.willpower) = Buffer.ReadLong
                .Stat(Stats.spirit) = Buffer.ReadLong
            End With

            n = n + 10
        Next

        Buffer = Nothing
    End Sub
    Private Sub Packet_InGame(ByRef data() As Byte)
        InGame = True
        CanMoveNow = True
        Call GameInit()
    End Sub
    Private Sub Packet_PlayerInv(ByRef data() As Byte)
        Dim n As Long
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerInv Then Exit Sub
        n = 1

        For i = 1 To MAX_INV
            Call SetPlayerInvItemNum(MyIndex, i, Buffer.ReadLong)
            Call SetPlayerInvItemValue(MyIndex, i, Buffer.ReadLong)
            n = n + 2
        Next

        ' changes to inventory, need to clear any drop menu
        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
        'DrawInventory()
    End Sub
    Private Sub Packet_PlayerInvUpdate(ByRef data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerInvUpdate Then Exit Sub

        n = Buffer.ReadLong 'CLng(Parse(1))
        Call SetPlayerInvItemNum(MyIndex, n, Buffer.ReadLong) 'CLng(Parse(2)))
        Call SetPlayerInvItemValue(MyIndex, n, Buffer.ReadLong) 'CLng(Parse(3)))
        ' changes, clear drop menu
        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        'DrawInventory()

        Buffer = Nothing
        'DrawInventory()
    End Sub
    Private Sub Packet_PlayerWornEquipment(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerWornEq Then Exit Sub

        Call SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Armor)
        Call SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Weapon)
        Call SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Helmet)
        Call SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Shield)

        ' changes to inventory, need to clear any drop menu

        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        'DrawInventory()
        DrawEquipment()

        Buffer = Nothing
    End Sub
    Private Sub Packet_PlayerHP(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerHp Then Exit Sub

        Player(MyIndex).MaxHP = Buffer.ReadLong

        Call SetPlayerVital(MyIndex, Vitals.HP, Buffer.ReadLong)

        If GetPlayerMaxVital(MyIndex, Vitals.HP) > 0 Then
            lblHPText = GetPlayerVital(MyIndex, Vitals.HP) & "/" & GetPlayerMaxVital(MyIndex, Vitals.HP)
            ' hp bar
            picHpWidth = Int(((GetPlayerVital(MyIndex, Vitals.HP) / 169) / (GetPlayerMaxVital(MyIndex, Vitals.HP) / 169)) * 169)
        End If
        Buffer = Nothing
    End Sub
    Private Sub Packet_PlayerMP(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerMp Then Exit Sub
        Player(MyIndex).MaxMP = Buffer.ReadLong
        Call SetPlayerVital(MyIndex, Vitals.MP, Buffer.ReadLong)

        If GetPlayerMaxVital(MyIndex, Vitals.MP) > 0 Then
            lblManaText = GetPlayerVital(MyIndex, Vitals.MP) & "/" & GetPlayerMaxVital(MyIndex, Vitals.MP)
            ' mp bar
            picManaWidth = Int(((GetPlayerVital(MyIndex, Vitals.MP) / 169) / (GetPlayerMaxVital(MyIndex, Vitals.MP) / 169)) * 169)
        End If
    End Sub
    Private Sub Packet_PlayerSP(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerSp Then Exit Sub
        Player(MyIndex).MaxSP = Buffer.ReadLong
        Call SetPlayerVital(MyIndex, Vitals.SP, Buffer.ReadLong)
    End Sub
    Private Sub Packet_PlayerStats(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Dim index As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerStats Then Exit Sub

        index = Buffer.ReadLong
        For i = 1 To Stats.stat_count - 1
            SetPlayerStat(index, i, Buffer.ReadLong)
        Next
        UpdateCharacterPanel = True
    End Sub
    Private Sub Packet_PlayerData(ByRef data() As Byte)
        Dim i As Long, X As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerData Then Exit Sub

        i = Buffer.ReadLong
        Call SetPlayerName(i, Buffer.ReadString)
        Call SetPlayerLevel(i, Buffer.ReadLong)
        Call SetPlayerPOINTS(i, Buffer.ReadLong)
        Call SetPlayerSprite(i, Buffer.ReadLong)
        Call SetPlayerMap(i, Buffer.ReadLong)
        Call SetPlayerX(i, Buffer.ReadLong)
        Call SetPlayerY(i, Buffer.ReadLong)
        Call SetPlayerDir(i, Buffer.ReadLong)
        Call SetPlayerAccess(i, Buffer.ReadLong)
        Call SetPlayerPK(i, Buffer.ReadLong)

        For X = 1 To Stats.stat_count - 1
            SetPlayerStat(i, X, Buffer.ReadLong)
        Next

        ' Check if the player is the client player
        If i = MyIndex Then
            ' Reset directions
            DirUp = False
            DirDown = False
            DirLeft = False
            DirRight = False

            UpdateCharacterPanel = True
        End If

        ' Make sure they aren't walking
        Player(i).Moving = 0
        Player(i).XOffset = 0
        Player(i).YOffset = 0

        If i = MyIndex Then PlayerData = True
    End Sub
    Private Sub Packet_PlayerMove(ByRef data() As Byte)
        Dim i As Long
        Dim X As Long
        Dim Y As Long
        Dim Dir As Long
        Dim n As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerMove Then Exit Sub
        i = Buffer.ReadLong
        X = Buffer.ReadLong
        Y = Buffer.ReadLong
        Dir = Buffer.ReadLong
        n = Buffer.ReadLong
        Call SetPlayerX(i, X)
        Call SetPlayerY(i, Y)
        Call SetPlayerDir(i, Dir)
        Player(i).XOffset = 0
        Player(i).YOffset = 0
        Player(i).Moving = n

        Select Case GetPlayerDir(i)
            Case DIR_UP
                Player(i).YOffset = PIC_Y
            Case DIR_DOWN
                Player(i).YOffset = PIC_Y * -1
            Case DIR_LEFT
                Player(i).XOffset = PIC_X
            Case DIR_RIGHT
                Player(i).XOffset = PIC_X * -1
        End Select
        Buffer = Nothing
    End Sub
    Private Sub Packet_NpcMove(ByRef data() As Byte)
        Dim MapNpcNum As Long
        Dim Movement As Long
        Dim X As Long
        Dim Y As Long
        Dim Dir As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SNpcMove Then Exit Sub

        MapNpcNum = Buffer.ReadLong
        X = Buffer.ReadLong
        Y = Buffer.ReadLong
        Dir = Buffer.ReadLong
        Movement = Buffer.ReadLong

        With MapNpc(MapNpcNum)
            .X = X
            .Y = Y
            .Dir = Dir
            .XOffset = 0
            .YOffset = 0
            .Moving = Movement

            Select Case .Dir
                Case DIR_UP
                    .YOffset = PIC_Y
                Case DIR_DOWN
                    .YOffset = PIC_Y * -1
                Case DIR_LEFT
                    .XOffset = PIC_X
                Case DIR_RIGHT
                    .XOffset = PIC_X * -1
            End Select
        End With

        Buffer = Nothing
    End Sub
    Private Sub Packet_PlayerDir(ByRef data() As Byte)
        Dim Dir As Long
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerDir Then Exit Sub
        i = Buffer.ReadLong
        Dir = Buffer.ReadLong
        Call SetPlayerDir(i, Dir)

        With Player(i)
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With
        Buffer = Nothing
    End Sub
    Private Sub Packet_NpcDir(ByRef data() As Byte)
        Dim Dir As Long
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SNpcDir Then Exit Sub

        i = Buffer.ReadLong
        Dir = Buffer.ReadLong

        With MapNpc(i)
            .Dir = Dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        Buffer = Nothing
    End Sub
    Private Sub Packet_PlayerXY(ByRef data() As Byte)
        Dim X As Long
        Dim Y As Long
        Dim Dir As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerXY Then Exit Sub
        X = Buffer.ReadLong
        Y = Buffer.ReadLong
        Dir = Buffer.ReadLong
        Call SetPlayerX(MyIndex, X)
        Call SetPlayerY(MyIndex, Y)
        Call SetPlayerDir(MyIndex, Dir)
        ' Make sure they aren't walking
        Player(MyIndex).Moving = 0
        Player(MyIndex).XOffset = 0
        Player(MyIndex).YOffset = 0
        Buffer = Nothing
    End Sub
    Private Sub Packet_Attack(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SAttack Then Exit Sub

        i = Buffer.ReadLong
        ' Set player to attacking
        Player(i).Attacking = 1
        Player(i).AttackTimer = GetTickCount

        Buffer = Nothing
    End Sub
    Private Sub Packet_NpcAttack(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SNpcAttack Then Exit Sub

        i = Buffer.ReadLong
        ' Set player to attacking
        MapNpc(i).Attacking = 1
        MapNpc(i).AttackTimer = GetTickCount

        Buffer = Nothing
    End Sub
    Private Sub Packet_CheckMap(ByRef data() As Byte)
        Dim X As Long
        Dim Y As Long
        Dim i As Long
        Dim NeedMap As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SCheckforMap Then Exit Sub

        ' Erase all players except self
        For i = 1 To MAX_PLAYERS
            If i <> MyIndex Then
                Call SetPlayerMap(i, 0)
            End If
        Next

        ' Erase all temporary tile values
        Call ClearTempTile()
        Call ClearMapNpcs()
        Call ClearMapItems()
        Call ClearMap()
        ' Get map num
        X = Buffer.ReadLong
        ' Get revision
        Y = Buffer.ReadLong

        If FileExist(MAP_PATH & "map" & X & MAP_EXT) Then
            Call LoadMap(X)
            ' Check to see if the revisions match
            NeedMap = 1

            If Map.Revision = Y Then
                NeedMap = 0
                MapData = True
            End If

        Else
            NeedMap = 1
            GettingMap = True
        End If
        NeedMap = 1
        GettingMap = True

        ' Either the revisions didn't match or we dont have the map, so we need it
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CNeedMap)
        Buffer.WriteLong(NeedMap)
        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub
    Private Sub Packet_MapData(ByRef data() As Byte)
        Dim X As Long
        Dim Y As Long
        Dim i As Long
        Dim Buffer As ByteBuffer
        Dim MapNum As Long

        Buffer = New ByteBuffer

        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SMapData Then Exit Sub

        data = Buffer.ReadBytes(Buffer.Count - 8)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Decompress(data))

        MapData = False

        If Buffer.ReadLong = 1 Then

            MapNum = Buffer.ReadLong
            Map.Name = Buffer.ReadString
            Map.Music = Buffer.ReadString
            Map.Revision = Buffer.ReadLong
            Map.Moral = Buffer.ReadLong
            Map.tileset = Buffer.ReadLong
            Map.Up = Buffer.ReadLong
            Map.Down = Buffer.ReadLong
            Map.Left = Buffer.ReadLong
            Map.Right = Buffer.ReadLong
            Map.BootMap = Buffer.ReadLong
            Map.BootX = Buffer.ReadLong
            Map.BootY = Buffer.ReadLong
            Map.MaxX = Buffer.ReadLong
            Map.MaxY = Buffer.ReadLong

            ReDim Map.Tile(0 To Map.MaxX, 0 To Map.MaxY)

            For X = 1 To MAX_MAP_NPCS
                Map.Npc(X) = Buffer.ReadLong
            Next

            For X = 0 To Map.MaxX
                For Y = 0 To Map.MaxY
                    Map.Tile(X, Y).Data1 = Buffer.ReadLong
                    Map.Tile(X, Y).Data2 = Buffer.ReadLong
                    Map.Tile(X, Y).Data3 = Buffer.ReadLong
                    Map.Tile(X, Y).DirBlock = Buffer.ReadLong
                    ReDim Map.Tile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
                    For i = 0 To MapLayer.Layer_Count - 1
                        Map.Tile(X, Y).Layer(i).tileset = Buffer.ReadLong
                        Map.Tile(X, Y).Layer(i).X = Buffer.ReadLong
                        Map.Tile(X, Y).Layer(i).Y = Buffer.ReadLong
                    Next
                    Map.Tile(X, Y).Type = Buffer.ReadLong
                Next
            Next
        End If

        For i = 1 To MAX_MAP_ITEMS
            MapItem(i).Num = Buffer.ReadLong
            MapItem(i).Value = Buffer.ReadLong()
            MapItem(i).X = Buffer.ReadLong()
            MapItem(i).Y = Buffer.ReadLong()
        Next

        For i = 1 To MAX_MAP_NPCS
            MapNpc(i).Num = Buffer.ReadLong()
            MapNpc(i).X = Buffer.ReadLong()
            MapNpc(i).Y = Buffer.ReadLong()
            MapNpc(i).Dir = Buffer.ReadLong()
            MapNpc(i).Vital(Vitals.HP) = Buffer.ReadLong()
        Next

        If Buffer.ReadLong = 1 Then
            Resource_Index = Buffer.ReadLong
            Resources_Init = False

            If Resource_Index > 0 Then
                ReDim MapResource(0 To Resource_Index)

                For i = 0 To Resource_Index
                    MapResource(i).ResourceState = Buffer.ReadLong
                    MapResource(i).X = Buffer.ReadLong
                    MapResource(i).Y = Buffer.ReadLong
                Next

                Resources_Init = True
            Else
                ReDim MapResource(0 To 1)
            End If
        End If


        ClearTempTile()

        Buffer = Nothing

        ' Save the map
        Call SaveMap(MapNum)

        ' Check if we get a map from someone else and if we were editing a map cancel it out
        If InMapEditor Then
            InMapEditor = False
            frmEditor_Map.Visible = False

            ClearAttributeDialogue()

            If frmEditor_MapProperties.Visible Then
                frmEditor_MapProperties.Visible = False
            End If
        End If



        MapData = True
        Dim MusicFile As String

        For i = 1 To MAX_BYTE
            ClearActionMsg(i)
        Next i


        MusicFile = Trim$(Map.Music)
        PlayMusic(MusicFile)

        Call UpdateDrawMapName()

        GettingMap = False
        CanMoveNow = True
    End Sub
    Private Sub Packet_MapNPCData(ByRef data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SMapNpcData Then Exit Sub

        For i = 1 To MAX_MAP_NPCS

            With MapNpc(i)
                .Num = Buffer.ReadLong
                .X = Buffer.ReadLong
                .Y = Buffer.ReadLong
                .Dir = Buffer.ReadLong
                .Vital(Vitals.HP) = Buffer.ReadLong
            End With

        Next
    End Sub
    Private Sub Packet_MapDone(ByVal data() As Byte)
        Dim i As Long
        Dim MusicFile As String

        For i = 1 To MAX_BYTE
            ClearActionMsg(i)
        Next i


        MusicFile = Trim$(Map.Music)
        PlayMusic(MusicFile)

        Call UpdateDrawMapName()

        GettingMap = False
        CanMoveNow = True
    End Sub
    Private Sub Packet_GlobalMessage(ByRef Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Msg As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadLong <> ServerPackets.SGlobalMsg Then Exit Sub
        Msg = Buffer.ReadString
        Call AddText(Msg)
    End Sub
    Private Sub Packet_MapMessage(ByRef Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Msg As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadLong <> ServerPackets.SMapMsg Then Exit Sub
        Msg = Buffer.ReadString
        Call AddText(Msg)
        Buffer = Nothing
    End Sub
    Private Sub Packet_SpawnItem(ByRef Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadLong <> ServerPackets.SSpawnItem Then Exit Sub

        n = Buffer.ReadLong

        With MapItem(n)
            .Num = Buffer.ReadLong
            .Value = Buffer.ReadLong
            .X = Buffer.ReadLong
            .Y = Buffer.ReadLong
        End With

        Buffer = Nothing
    End Sub
    Private Sub Packet_EditItem(ByRef Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadLong <> ServerPackets.SItemEditor Then Exit Sub

        InitItemEditor = True

        Buffer = Nothing
    End Sub
    Private Sub Packet_PlayerMessage(ByRef Data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Msg As String
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadLong <> ServerPackets.SPlayerMsg Then Exit Sub
        Msg = Buffer.ReadString
        Call AddText(Msg)
    End Sub
    Sub Packet_UpdateItem(ByVal data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateItem Then Exit Sub

        n = Buffer.ReadLong

        ' Update the item
        Item(n).AccessReq = Buffer.ReadLong()

        For i = 0 To Stats.stat_count - 1
            Item(n).Add_Stat(i) = Buffer.ReadLong()
        Next

        Item(n).Animation = Buffer.ReadLong()
        Item(n).BindType = Buffer.ReadLong()
        Item(n).ClassReq = Buffer.ReadLong()
        Item(n).Data1 = Buffer.ReadLong()
        Item(n).Data2 = Buffer.ReadLong()
        Item(n).Data3 = Buffer.ReadLong()
        Item(n).Handed = Buffer.ReadLong()
        Item(n).LevelReq = Buffer.ReadLong()
        Item(n).Mastery = Buffer.ReadLong()
        Item(n).Name = Buffer.ReadString()
        Item(n).Paperdoll = Buffer.ReadLong()
        Item(n).Pic = Buffer.ReadLong()
        Item(n).Price = Buffer.ReadLong()
        Item(n).Rarity = Buffer.ReadLong()
        Item(n).Speed = Buffer.ReadLong()

        For i = 0 To Stats.stat_count - 1
            Item(n).Stat_Req(i) = Buffer.ReadLong()
        Next

        Item(n).Type = Buffer.ReadLong()
        Buffer = Nothing
        ' changes to inventory, need to clear any drop menu

        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        'y()
    End Sub
    Sub Packet_SpawnNPC(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SSpawnNpc Then Exit Sub

        n = Buffer.ReadLong

        With MapNpc(n)
            .Num = Buffer.ReadLong
            .X = Buffer.ReadLong
            .Y = Buffer.ReadLong
            .Dir = Buffer.ReadLong
            ' Client use only
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With


        Buffer = Nothing
    End Sub
    Sub Packet_NpcDead(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim n As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SNpcDead Then Exit Sub

        n = Buffer.ReadLong
        Call ClearMapNpc(n)

        Buffer = Nothing
    End Sub
    Sub Packet_NPCEditor(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SNpcEditor Then Exit Sub

        InitNPCEditor = True

        Buffer = Nothing
    End Sub
    Sub Packet_UpdateNPC(ByVal data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateNpc Then Exit Sub

        n = Buffer.ReadLong
        ' Update the Npc
        Npc(n).Animation = Buffer.ReadLong()
        Npc(n).AttackSay = Buffer.ReadString()
        Npc(n).Behaviour = Buffer.ReadLong()
        Npc(n).DropChance = Buffer.ReadLong()
        Npc(n).DropItem = Buffer.ReadLong()
        Npc(n).DropItemValue = Buffer.ReadLong()
        Npc(n).EXP = Buffer.ReadLong()
        Npc(n).faction = Buffer.ReadLong()
        Npc(n).HP = Buffer.ReadLong()
        Npc(n).Name = Buffer.ReadString()
        Npc(n).Range = Buffer.ReadLong()
        Npc(n).SpawnSecs = Buffer.ReadLong()
        Npc(n).Sprite = Buffer.ReadLong()

        For i = 0 To Stats.stat_count - 1
            Npc(n).Stat(i) = Buffer.ReadLong()
        Next

        If Npc(n).AttackSay Is Nothing Then Npc(n).AttackSay = ""
        If Npc(n).Name Is Nothing Then Npc(n).Name = ""
        Buffer = Nothing
    End Sub
    Sub Packet_MapKey(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim n As Long
        Dim X As Long
        Dim Y As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SMapKey Then Exit Sub

        X = Buffer.ReadLong
        Y = Buffer.ReadLong
        n = Buffer.ReadLong
        TempTile(X, Y).DoorOpen = n

        Buffer = Nothing
    End Sub
    Sub Packet_EditMap(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SEditMap Then Exit Sub

        InitMapEditor = True

        Buffer = Nothing
    End Sub
    Sub Packet_EditShop(ByVal data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SShopEditor Then Exit Sub

        InitShopEditor = True

        Buffer = Nothing
    End Sub
    Sub Packet_UpdateShop(ByVal data() As Byte)
        Dim shopnum As Long
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateShop Then Exit Sub

        shopnum = Buffer.ReadLong

        Shop(shopnum).BuyRate = Buffer.ReadLong()
        Shop(shopnum).Name = Buffer.ReadString()

        For i = 0 To MAX_TRADES
            Shop(shopnum).TradeItem(i).CostItem = Buffer.ReadLong()
            Shop(shopnum).TradeItem(i).CostValue = Buffer.ReadLong()
            Shop(shopnum).TradeItem(i).Item = Buffer.ReadLong()
            Shop(shopnum).TradeItem(i).ItemValue = Buffer.ReadLong()
        Next

        If Shop(shopnum).Name Is Nothing Then Shop(shopnum).Name = ""

        Buffer = Nothing
    End Sub
    Sub Packet_EditSpell(ByVal data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SSpellEditor Then Exit Sub

        InitSpellEditor = True

        Buffer = Nothing
    End Sub
    Sub Packet_UpdateSpell(ByVal data() As Byte)
        Dim spellnum As Long
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateSpell Then Exit Sub

        spellnum = Buffer.ReadLong

        Spell(spellnum).AccessReq = Buffer.ReadLong()
        Spell(spellnum).AoE = Buffer.ReadLong()
        Spell(spellnum).CastAnim = Buffer.ReadLong()
        Spell(spellnum).CastTime = Buffer.ReadLong()
        Spell(spellnum).CDTime = Buffer.ReadLong()
        Spell(spellnum).ClassReq = Buffer.ReadLong()
        Spell(spellnum).Dir = Buffer.ReadLong()
        Spell(spellnum).Duration = Buffer.ReadLong()
        Spell(spellnum).Icon = Buffer.ReadLong()
        Spell(spellnum).Interval = Buffer.ReadLong()
        Spell(spellnum).IsAoE = Buffer.ReadLong()
        Spell(spellnum).LevelReq = Buffer.ReadLong()
        Spell(spellnum).Map = Buffer.ReadLong()
        Spell(spellnum).MPCost = Buffer.ReadLong()
        Spell(spellnum).Name = Buffer.ReadString()
        Spell(spellnum).Range = Buffer.ReadLong()
        Spell(spellnum).SpellAnim = Buffer.ReadLong()
        Spell(spellnum).StunDuration = Buffer.ReadLong()
        Spell(spellnum).Type = Buffer.ReadLong()
        Spell(spellnum).Vital = Buffer.ReadLong()
        Spell(spellnum).X = Buffer.ReadLong()
        Spell(spellnum).Y = Buffer.ReadLong()

        If Spell(spellnum).Name Is Nothing Then Spell(spellnum).Name = ""

        Buffer = Nothing

    End Sub
    Sub Packet_Spells(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SSpells Then Exit Sub

        For i = 1 To MAX_PLAYER_SPELLS
            PlayerSpells(i) = Buffer.ReadLong
        Next

        DrawPlayerSpells()

        Buffer = Nothing
    End Sub
    Sub Packet_LeftMap(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SLeft Then Exit Sub
        Call ClearPlayer(Buffer.ReadLong)
        Buffer = Nothing
    End Sub
    Private Sub Packet_ResourceCache(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Long

        ' if in map editor, we cache shit ourselves
        If InMapEditor Then Exit Sub
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SResourceCache Then Exit Sub

        Resource_Index = Buffer.ReadLong
        Resources_Init = False

        If Resource_Index > 0 Then
            ReDim Preserve MapResource(0 To Resource_Index)

            For i = 0 To Resource_Index
                MapResource(i).ResourceState = Buffer.ReadLong
                MapResource(i).X = Buffer.ReadLong
                MapResource(i).Y = Buffer.ReadLong
            Next

            Resources_Init = True
        Else
            ReDim MapResource(0 To 1)
        End If

        Buffer = Nothing
    End Sub
    Private Sub Packet_Ping(ByVal data() As Byte)
        PingEnd = GetTickCount
        Ping = PingEnd - PingStart
    End Sub
    Private Sub Packet_DoorAnimation(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim X As Long, Y As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SDoorAnimation Then Exit Sub

        X = buffer.ReadLong
        Y = buffer.ReadLong
        With TempTile(X, Y)
            .DoorFrame = 1
            .DoorAnimate = 1 ' 0 = nothing| 1 = opening | 2 = closing
            .DoorTimer = GetTickCount
        End With

        buffer = Nothing
    End Sub
    Private Sub Packet_ActionMessage(ByVal data() As Byte)
        Dim buffer As ByteBuffer
        Dim X As Long, Y As Long, message As String, color As Long, tmpType As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SActionMsg Then Exit Sub

        message = buffer.ReadString
        color = buffer.ReadLong
        tmpType = buffer.ReadLong
        X = buffer.ReadLong
        Y = buffer.ReadLong

        buffer = Nothing

        CreateActionMsg(message, color, tmpType, X, Y)
    End Sub
    Private Sub Packet_ResourceEditor(ByRef data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SResourceEditor Then Exit Sub

        InitResourceEditor = True

        Buffer = Nothing
    End Sub
    Private Sub Packet_UpdateResource(ByRef data() As Byte)
        Dim ResourceNum As Long
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateResource Then Exit Sub

        ResourceNum = Buffer.ReadLong

        Resource(ResourceNum).Animation = Buffer.ReadLong()
        Resource(ResourceNum).EmptyMessage = Buffer.ReadString()
        Resource(ResourceNum).ExhaustedImage = Buffer.ReadLong()
        Resource(ResourceNum).Health = Buffer.ReadLong()
        Resource(ResourceNum).ItemReward = Buffer.ReadLong()
        Resource(ResourceNum).Name = Buffer.ReadString()
        Resource(ResourceNum).ResourceImage = Buffer.ReadLong()
        Resource(ResourceNum).ResourceType = Buffer.ReadLong()
        Resource(ResourceNum).RespawnTime = Buffer.ReadLong()
        Resource(ResourceNum).SuccessMessage = Buffer.ReadString()
        Resource(ResourceNum).ToolRequired = Buffer.ReadLong()
        Resource(ResourceNum).Walkthrough = Buffer.ReadLong()

        If Resource(ResourceNum).Name Is Nothing Then Resource(ResourceNum).Name = ""
        If Resource(ResourceNum).EmptyMessage Is Nothing Then Resource(ResourceNum).EmptyMessage = ""
        If Resource(ResourceNum).SuccessMessage Is Nothing Then Resource(ResourceNum).SuccessMessage = ""


        Buffer = Nothing
    End Sub
    Private Sub Packet_PlayerExp(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim TNL As Long
        Dim index As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerEXP Then Exit Sub
        index = Buffer.ReadLong
        SetPlayerExp(index, Buffer.ReadLong)
        TNL = Buffer.ReadLong
        If TNL = 0 Then TNL = 1
        lblEXPText = GetPlayerExp(index) & "\" & TNL
        ' mp bar
        picEXPWidth = Int(((GetPlayerExp(MyIndex) / 169) / (TNL / 169)) * 169)
        Buffer = Nothing
    End Sub
    Private Sub Packet_Blood(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim X As Long, Y As Long, Sprite As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SBlood Then Exit Sub

        X = Buffer.ReadLong
        Y = Buffer.ReadLong

        Buffer = Nothing

        ' randomise sprite
        Sprite = Rand(1, 3)

        BloodIndex = BloodIndex + 1
        If BloodIndex >= MAX_BYTE Then BloodIndex = 1

        With Blood(BloodIndex)
            .X = X
            .Y = Y
            .Sprite = Sprite
            .Timer = GetTickCount
        End With

        Buffer = Nothing
    End Sub
    Private Sub Packet_EditAnimation(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SAnimationEditor Then Exit Sub

        InitAnimationEditor = True

        Buffer = Nothing
    End Sub
    Private Sub Packet_UpdateAnimation(ByRef data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SUpdateAnimation Then Exit Sub
        n = Buffer.ReadLong
        ' Update the Animation
        For i = 0 To UBound(Animation(n).Frames)
            Animation(n).Frames(i) = Buffer.ReadLong()
        Next

        For i = 0 To UBound(Animation(n).LoopCount)
            Animation(n).LoopCount(i) = Buffer.ReadLong()
        Next

        For i = 0 To UBound(Animation(n).looptime)
            Animation(n).looptime(i) = Buffer.ReadLong()
        Next

        Animation(n).Name = Buffer.ReadString()

        If Animation(n).Name Is Nothing Then Animation(n).Name = ""

        For i = 0 To UBound(Animation(n).Sprite)
            Animation(n).Sprite(i) = Buffer.ReadLong()
        Next
        Buffer = Nothing
    End Sub
    Private Sub Packet_Animation(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SAnimation Then Exit Sub

        AnimationIndex = AnimationIndex + 1
        If AnimationIndex >= MAX_BYTE Then AnimationIndex = 1

        With AnimInstance(AnimationIndex)
            .Animation = Buffer.ReadLong
            .X = Buffer.ReadLong
            .Y = Buffer.ReadLong
            .LockType = Buffer.ReadLong
            .lockindex = Buffer.ReadLong
            .Used(0) = True
            .Used(1) = True
        End With

        Buffer = Nothing
    End Sub
    Private Sub Packet_NPCVitals(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim MapNpcNum As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SMapNpcVitals Then Exit Sub

        MapNpcNum = Buffer.ReadLong
        For i = 1 To Vitals.Vital_Count - 1
            MapNpc(MapNpcNum).Vital(i) = Buffer.ReadLong
        Next

        Buffer = Nothing
    End Sub
    Private Sub Packet_Cooldown(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim slot As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SCooldown Then Exit Sub

        slot = Buffer.ReadLong
        SpellCD(slot) = GetTickCount

        DrawPlayerSpells()

        Buffer = Nothing
    End Sub
    Private Sub Packet_ClearSpellBuffer(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SClearSpellBuffer Then Exit Sub

        SpellBuffer = 0
        SpellBufferTimer = 0

        Buffer = Nothing
    End Sub
    Private Sub Packet_SayMessage(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim Access As Long
        Dim Name As String
        Dim message As String
        'Dim colour As Long
        Dim Header As String
        Dim PK As Long
        'Dim saycolour As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SSayMsg Then Exit Sub

        Name = Buffer.ReadString
        Access = Buffer.ReadLong
        PK = Buffer.ReadLong
        message = Buffer.ReadString
        Header = Buffer.ReadString

        AddText(Header & Name & ": " & message)
        Buffer = Nothing
    End Sub
    Private Sub Packet_OpenShop(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim shopnum As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SOpenShop Then Exit Sub
        shopnum = Buffer.ReadLong

        NeedToOpenShop = True
        NeedToOpenShopNum = shopnum

        Buffer = Nothing
    End Sub
    Private Sub Packet_ResetShopAction(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SResetShopAction Then Exit Sub
        ShopAction = 0
        Buffer = Nothing
    End Sub
    Private Sub Packet_Stunned(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SStunned Then Exit Sub

        StunDuration = Buffer.ReadLong

        Buffer = Nothing
    End Sub
    Private Sub Packet_MapWornEquipment(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Dim playernum As Long
        Buffer = New ByteBuffer

        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SMapWornEq Then Exit Sub

        playernum = Buffer.ReadLong
        Call SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Armor)
        Call SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Weapon)
        Call SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Helmet)
        Call SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Shield)

        Buffer = Nothing
    End Sub
    Private Sub Packet_OpenBank(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SBank Then Exit Sub

        For i = 1 To MAX_BANK
            Bank.Item(i).Num = Buffer.ReadLong
            Bank.Item(i).Value = Buffer.ReadLong
        Next

        NeedToOpenBank = True

        Buffer = Nothing
    End Sub
    Private Sub Packet_ClearTradeTimer(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SClearTradeTimer Then Exit Sub

        TradeRequest = False
        TradeTimer = 0

        Buffer = Nothing
    End Sub
    Private Sub Packet_Trade(ByRef data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.STrade Then Exit Sub

        NeedToOpenTrade = True
        Buffer.ReadLong()
        Tradername = Buffer.ReadString
        frmMainGame.picTrade.Visible = True

        Buffer = Nothing
    End Sub
    Private Sub Packet_CloseTrade(ByRef data() As Byte)
        NeedtoCloseTrade = True
        ' re-blt any items we were offering
        'DrawInventory()
    End Sub
    Private Sub Packet_TradeUpdate(ByRef data() As Byte)
        Dim buffer As ByteBuffer
        Dim datatype As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ServerPackets.STradeUpdate Then Exit Sub

        dataType = buffer.ReadLong

        If dataType = 0 Then ' ours!
            For i = 1 To MAX_INV
                TradeYourOffer(i).Num = buffer.ReadLong
                TradeYourOffer(i).Value = buffer.ReadLong
            Next
            frmMainGame.lblYourWorth.Text = "Total Worth: " & buffer.ReadLong & "g"
            ' remove any items we're offering
            'DrawInventory()
        ElseIf dataType = 1 Then 'theirs
            For i = 1 To MAX_INV
                TradeTheirOffer(i).Num = buffer.ReadLong
                TradeYourOffer(i).Value = buffer.ReadLong
            Next
            frmMainGame.lblTheirWorth.Text = "Total Worth: " & buffer.ReadLong & "g"
        End If

        DrawTrade()

        buffer = Nothing
    End Sub
    Private Sub Packet_TradeStatus(ByRef data() As Byte)
        Dim buffer As ByteBuffer
        Dim tradestatus As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ServerPackets.STradeStatus Then Exit Sub

        tradestatus = buffer.ReadLong

        Select Case tradestatus
            Case 0 ' clear
                frmMainGame.lblTradeStatus.Text = vbNullString
            Case 1 ' they've accepted
                frmMainGame.lblTradeStatus.Text = "Other player has accepted."
            Case 2 ' you've accepted
                frmMainGame.lblTradeStatus.Text = "Waiting for other player to accept."
        End Select

        buffer = Nothing
    End Sub
    Private Sub Packet_GameData(ByRef data() As Byte)
        Dim buffer As ByteBuffer
        Dim n As Long, i As Long, z As Long, x As Long
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        If buffer.ReadLong <> ServerPackets.SGameData Then Exit Sub
        data = buffer.ReadBytes(buffer.Count - 8)
        data = Decompress(data)
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        '\\\\\\\\\\\\\\\\\\\\\
        '\\\Read Class Data\\\
        '\\\\\\\\\\\\\\\\\\\\\\

        ' Max classes
        Max_Classes = buffer.ReadLong 'CByte(Parse(n))
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.stat_count - 1)
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Vital(0 To Vitals.Vital_Count - 1)
        Next

        n = n + 1

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = buffer.ReadString 'Trim$(Parse(n))
                .Vital(Vitals.HP) = buffer.ReadLong 'CLng(Parse(n + 1))
                .Vital(Vitals.MP) = buffer.ReadLong 'CLng(Parse(n + 2))
                .Vital(Vitals.SP) = buffer.ReadLong 'CLng(Parse(n + 3))

                ' get array size
                z = buffer.ReadLong
                ' redim array
                ReDim .MaleSprite(0 To z)
                ' loop-receive data
                For x = 0 To z
                    .MaleSprite(x) = buffer.ReadLong
                Next

                ' get array size
                z = buffer.ReadLong
                ' redim array
                ReDim .FemaleSprite(0 To z)
                ' loop-receive data
                For x = 0 To z
                    .FemaleSprite(x) = buffer.ReadLong
                Next

                .Stat(Stats.strength) = buffer.ReadLong 'CLng(Parse(n + 4))
                .Stat(Stats.endurance) = buffer.ReadLong
                .Stat(Stats.vitality) = buffer.ReadLong
                .Stat(Stats.intelligence) = buffer.ReadLong
                .Stat(Stats.willpower) = buffer.ReadLong
                .Stat(Stats.spirit) = buffer.ReadLong
            End With

            n = n + 10
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read Class Data\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\

        '\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\Read Item Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong

            ' Update the item
            Item(n).AccessReq = buffer.ReadLong()

            For z = 0 To Stats.stat_count - 1
                Item(n).Add_Stat(z) = buffer.ReadLong()
            Next

            Item(n).Animation = buffer.ReadLong()
            Item(n).BindType = buffer.ReadLong()
            Item(n).ClassReq = buffer.ReadLong()
            Item(n).Data1 = buffer.ReadLong()
            Item(n).Data2 = buffer.ReadLong()
            Item(n).Data3 = buffer.ReadLong()
            Item(n).Handed = buffer.ReadLong()
            Item(n).LevelReq = buffer.ReadLong()
            Item(n).Mastery = buffer.ReadLong()
            Item(n).Name = buffer.ReadString()
            Item(n).Paperdoll = buffer.ReadLong()
            Item(n).Pic = buffer.ReadLong()
            Item(n).Price = buffer.ReadLong()
            Item(n).Rarity = buffer.ReadLong()
            Item(n).Speed = buffer.ReadLong()

            For z = 0 To Stats.stat_count - 1
                Item(n).Stat_Req(z) = buffer.ReadLong()
            Next

            Item(n).Type = buffer.ReadLong()
        Next

        ' changes to inventory, need to clear any drop menu

        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        'DrawInventory()

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read Item Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\Read Animation Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong
            ' Update the Animation
            For z = 0 To UBound(Animation(n).Frames)
                Animation(n).Frames(z) = buffer.ReadLong()
            Next

            For z = 0 To UBound(Animation(n).LoopCount)
                Animation(n).LoopCount(z) = buffer.ReadLong()
            Next

            For z = 0 To UBound(Animation(n).looptime)
                Animation(n).looptime(z) = buffer.ReadLong()
            Next

            Animation(n).Name = buffer.ReadString()

            If Animation(n).Name Is Nothing Then Animation(n).Name = ""

            For z = 0 To UBound(Animation(n).Sprite)
                Animation(n).Sprite(z) = buffer.ReadLong()
            Next
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read Animation Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        '\\\\\\\\\\\\\\\\\\\\\\
        '\\\Read NPC Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\
        x = buffer.ReadLong
        For i = 1 To x
            n = buffer.ReadLong
            ' Update the Npc
            Npc(n).Animation = buffer.ReadLong()
            Npc(n).AttackSay = buffer.ReadString()
            Npc(n).Behaviour = buffer.ReadLong()
            Npc(n).DropChance = buffer.ReadLong()
            Npc(n).DropItem = buffer.ReadLong()
            Npc(n).DropItemValue = buffer.ReadLong()
            Npc(n).EXP = buffer.ReadLong()
            Npc(n).faction = buffer.ReadLong()
            Npc(n).HP = buffer.ReadLong()
            Npc(n).Name = buffer.ReadString()
            Npc(n).Range = buffer.ReadLong()
            Npc(n).SpawnSecs = buffer.ReadLong()
            Npc(n).Sprite = buffer.ReadLong()

            For z = 0 To Stats.stat_count - 1
                Npc(n).Stat(z) = buffer.ReadLong()
            Next

            If Npc(n).AttackSay Is Nothing Then Npc(n).AttackSay = ""
            If Npc(n).Name Is Nothing Then Npc(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read NPC Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        '\\\\\\\\\\\\\\\\\\\\\\\
        '\\\Read Shop Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong

            Shop(n).BuyRate = buffer.ReadLong()
            Shop(n).Name = buffer.ReadString()

            For z = 0 To MAX_TRADES
                Shop(n).TradeItem(z).CostItem = buffer.ReadLong()
                Shop(n).TradeItem(z).CostValue = buffer.ReadLong()
                Shop(n).TradeItem(z).Item = buffer.ReadLong()
                Shop(n).TradeItem(z).ItemValue = buffer.ReadLong()
            Next

            If Shop(n).Name Is Nothing Then Shop(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read Shop Data\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\Read Spells Data\\\\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong

            Spell(n).AccessReq = buffer.ReadLong()
            Spell(n).AoE = buffer.ReadLong()
            Spell(n).CastAnim = buffer.ReadLong()
            Spell(n).CastTime = buffer.ReadLong()
            Spell(n).CDTime = buffer.ReadLong()
            Spell(n).ClassReq = buffer.ReadLong()
            Spell(n).Dir = buffer.ReadLong()
            Spell(n).Duration = buffer.ReadLong()
            Spell(n).Icon = buffer.ReadLong()
            Spell(n).Interval = buffer.ReadLong()
            Spell(n).IsAoE = buffer.ReadLong()
            Spell(n).LevelReq = buffer.ReadLong()
            Spell(n).Map = buffer.ReadLong()
            Spell(n).MPCost = buffer.ReadLong()
            Spell(n).Name = buffer.ReadString()
            Spell(n).Range = buffer.ReadLong()
            Spell(n).SpellAnim = buffer.ReadLong()
            Spell(n).StunDuration = buffer.ReadLong()
            Spell(n).Type = buffer.ReadLong()
            Spell(n).Vital = buffer.ReadLong()
            Spell(n).X = buffer.ReadLong()
            Spell(n).Y = buffer.ReadLong()

            If Spell(n).Name Is Nothing Then Spell(n).Name = ""
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read Spells Data\\\\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\Read Resource Data\\\\\\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong

            Resource(n).Animation = buffer.ReadLong()
            Resource(n).EmptyMessage = buffer.ReadString()
            Resource(n).ExhaustedImage = buffer.ReadLong()
            Resource(n).Health = buffer.ReadLong()
            Resource(n).ItemReward = buffer.ReadLong()
            Resource(n).Name = buffer.ReadString()
            Resource(n).ResourceImage = buffer.ReadLong()
            Resource(n).ResourceType = buffer.ReadLong()
            Resource(n).RespawnTime = buffer.ReadLong()
            Resource(n).SuccessMessage = buffer.ReadString()
            Resource(n).ToolRequired = buffer.ReadLong()
            Resource(n).Walkthrough = buffer.ReadLong()

            If Resource(n).Name Is Nothing Then Resource(n).Name = ""
            If Resource(n).EmptyMessage Is Nothing Then Resource(n).EmptyMessage = ""
            If Resource(n).SuccessMessage Is Nothing Then Resource(n).SuccessMessage = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '\\\End Read Resource Data\\\\\\\\\\\\
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        buffer = Nothing
    End Sub
End Module
