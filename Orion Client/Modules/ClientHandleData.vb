Module ClientHandleData
    Public PlayerBuffer As ByteBuffer
    Private Delegate Sub Packet_(ByVal Data() As Byte)
    Private Packets As Dictionary(Of Integer, Packet_)

    Public Sub HandleData(ByVal data() As Byte)
        Dim Buffer() As Byte
        Buffer = data.Clone
        Dim pLength As Long

        If PlayerBuffer Is Nothing Then PlayerBuffer = New ByteBuffer
        PlayerBuffer.WriteBytes(Buffer)

        If PlayerBuffer.Count = 0 Then
            PlayerBuffer.Clear()
            Exit Sub
        End If

        If PlayerBuffer.Length >= 8 Then
            pLength = PlayerBuffer.ReadLong(False)

            If pLength <= 0 Then
                PlayerBuffer.Clear()
                Exit Sub
            End If
        End If

        If PlayerBuffer.Length >= 8 Then
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
                    PlayerBuffer.Clear()
                    Exit Sub
                End If
            End If

        Loop
    End Sub

    Public Sub InitMessages()
        Packets = New Dictionary(Of Integer, Packet_)

        Packets.Add(ServerPackets.SAlertMsg, AddressOf Packet_AlertMSG)
        Packets.Add(ServerPackets.SLoginOk, AddressOf Packet_LoginOk)
        Packets.Add(ServerPackets.SNewCharClasses, AddressOf Packet_NewCharClasses)
        Packets.Add(ServerPackets.SClassesData, AddressOf Packet_ClassesData)
        Packets.Add(ServerPackets.SInGame, AddressOf Packet_InGame)
        Packets.Add(ServerPackets.SPlayerInv, AddressOf Packet_PlayerInv)
        Packets.Add(ServerPackets.SPlayerInvUpdate, AddressOf Packet_PlayerInvUpdate)
        Packets.Add(ServerPackets.SPlayerWornEq, AddressOf Packet_PlayerWornEquipment)
        Packets.Add(ServerPackets.SPlayerHp, AddressOf Packet_PlayerHP)
        Packets.Add(ServerPackets.SPlayerMp, AddressOf Packet_PlayerMP)
        Packets.Add(ServerPackets.SPlayerSp, AddressOf Packet_PlayerSP)
        Packets.Add(ServerPackets.SPlayerStats, AddressOf Packet_PlayerStats)
        Packets.Add(ServerPackets.SPlayerData, AddressOf Packet_PlayerData)
        Packets.Add(ServerPackets.SPlayerMove, AddressOf Packet_PlayerMove)
        Packets.Add(ServerPackets.SNpcMove, AddressOf Packet_NpcMove)
        Packets.Add(ServerPackets.SPlayerDir, AddressOf Packet_PlayerDir)
        Packets.Add(ServerPackets.SNpcDir, AddressOf Packet_NpcDir)
        Packets.Add(ServerPackets.SPlayerXY, AddressOf Packet_PlayerXY)
        Packets.Add(ServerPackets.SAttack, AddressOf Packet_Attack)
        Packets.Add(ServerPackets.SNpcAttack, AddressOf Packet_NpcAttack)
        Packets.Add(ServerPackets.SCheckforMap, AddressOf Packet_CheckMap)
        Packets.Add(ServerPackets.SMapData, AddressOf Packet_MapData)
        Packets.Add(ServerPackets.SMapNpcData, AddressOf Packet_MapNPCData)
        Packets.Add(ServerPackets.SMapNpcUpdate, AddressOf Packet_MapNPCUpdate)
        Packets.Add(ServerPackets.SMapDone, AddressOf Packet_MapDone)
        Packets.Add(ServerPackets.SGlobalMsg, AddressOf Packet_GlobalMessage)
        Packets.Add(ServerPackets.SPlayerMsg, AddressOf Packet_PlayerMessage)
        Packets.Add(ServerPackets.SMapMsg, AddressOf Packet_MapMessage)
        Packets.Add(ServerPackets.SSpawnItem, AddressOf Packet_SpawnItem)
        Packets.Add(ServerPackets.SItemEditor, AddressOf Packet_EditItem)
        Packets.Add(ServerPackets.SUpdateItem, AddressOf Packet_UpdateItem)
        Packets.Add(ServerPackets.SREditor, AddressOf Packet_ResourceEditor)
        Packets.Add(ServerPackets.SSpawnNpc, AddressOf Packet_SpawnNPC)
        Packets.Add(ServerPackets.SNpcDead, AddressOf Packet_NpcDead)
        Packets.Add(ServerPackets.SNpcEditor, AddressOf Packet_NPCEditor)
        Packets.Add(ServerPackets.SUpdateNpc, AddressOf Packet_UpdateNPC)
        Packets.Add(ServerPackets.SMapKey, AddressOf Packet_MapKey)
        Packets.Add(ServerPackets.SEditMap, AddressOf Packet_EditMap)
        Packets.Add(ServerPackets.SShopEditor, AddressOf Packet_EditShop)
        Packets.Add(ServerPackets.SUpdateShop, AddressOf Packet_UpdateShop)
        Packets.Add(ServerPackets.SSpellEditor, AddressOf Packet_EditSpell)
        Packets.Add(ServerPackets.SUpdateSpell, AddressOf Packet_UpdateSpell)
        Packets.Add(ServerPackets.SSpells, AddressOf Packet_Spells)
        Packets.Add(ServerPackets.SLeftMap, AddressOf Packet_LeftMap)
        Packets.Add(ServerPackets.SResourceCache, AddressOf Packet_ResourceCache)
        Packets.Add(ServerPackets.SResourceEditor, AddressOf Packet_ResourceEditor)
        Packets.Add(ServerPackets.SUpdateResource, AddressOf Packet_UpdateResource)
        Packets.Add(ServerPackets.SSendPing, AddressOf Packet_Ping)
        Packets.Add(ServerPackets.SDoorAnimation, AddressOf Packet_DoorAnimation)
        Packets.Add(ServerPackets.SActionMsg, AddressOf Packet_ActionMessage)
        Packets.Add(ServerPackets.SPlayerEXP, AddressOf Packet_PlayerExp)
        Packets.Add(ServerPackets.SBlood, AddressOf Packet_Blood)
        Packets.Add(ServerPackets.SAnimationEditor, AddressOf Packet_EditAnimation)
        Packets.Add(ServerPackets.SUpdateAnimation, AddressOf Packet_UpdateAnimation)
        Packets.Add(ServerPackets.SAnimation, AddressOf Packet_Animation)
        Packets.Add(ServerPackets.SMapNpcVitals, AddressOf Packet_NPCVitals)
        Packets.Add(ServerPackets.SCooldown, AddressOf Packet_Cooldown)
        Packets.Add(ServerPackets.SClearSpellBuffer, AddressOf Packet_ClearSpellBuffer)
        Packets.Add(ServerPackets.SSayMsg, AddressOf Packet_SayMessage)
        Packets.Add(ServerPackets.SOpenShop, AddressOf Packet_OpenShop)
        Packets.Add(ServerPackets.SResetShopAction, AddressOf Packet_ResetShopAction)
        Packets.Add(ServerPackets.SStunned, AddressOf Packet_Stunned)
        Packets.Add(ServerPackets.SMapWornEq, AddressOf Packet_MapWornEquipment)
        Packets.Add(ServerPackets.SBank, AddressOf Packet_OpenBank)
        Packets.Add(ServerPackets.SClearTradeTimer, AddressOf Packet_ClearTradeTimer)
        Packets.Add(ServerPackets.STrade, AddressOf Packet_Trade)
        Packets.Add(ServerPackets.SCloseTrade, AddressOf Packet_CloseTrade)
        Packets.Add(ServerPackets.STradeUpdate, AddressOf Packet_TradeUpdate)
        Packets.Add(ServerPackets.STradeStatus, AddressOf Packet_TradeStatus)
        Packets.Add(ServerPackets.SGameData, AddressOf Packet_GameData)
        Packets.Add(ServerPackets.SMapReport, AddressOf Packet_Mapreport) 'Mapreport
        Packets.Add(ServerPackets.STarget, AddressOf Packet_Target)

        Packets.Add(ServerPackets.SAdmin, AddressOf Packet_Admin)
        Packets.Add(ServerPackets.SMapNames, AddressOf Packet_MapNames)

        Packets.Add(ServerPackets.SCritical, AddressOf Packet_Critical)
        Packets.Add(ServerPackets.SNews, AddressOf Packet_News)

        'quests
        Packets.Add(ServerPackets.SQuestEditor, AddressOf Packet_QuestEditor)
        Packets.Add(ServerPackets.SUpdateQuest, AddressOf Packet_UpdateQuest)
        Packets.Add(ServerPackets.SPlayerQuest, AddressOf Packet_PlayerQuest)
        Packets.Add(ServerPackets.SPlayerQuests, AddressOf Packet_PlayerQuests)
        Packets.Add(ServerPackets.SQuestMessage, AddressOf Packet_QuestMessage)

        'Housing
        Packets.Add(ServerPackets.SHouseConfigs, AddressOf Packet_HouseConfigurations)
        Packets.Add(ServerPackets.SBuyHouse, AddressOf Packet_HouseOffer)
        Packets.Add(ServerPackets.SVisit, AddressOf Packet_Visit)
        Packets.Add(ServerPackets.SFurniture, AddressOf Packet_Furniture)
        Packets.Add(ServerPackets.SHouseEdit, AddressOf Packet_EditHouses)

        'hotbar
        Packets.Add(ServerPackets.SHotbar, AddressOf Packet_Hotbar)

        'Events
        Packets.Add(ServerPackets.SSpawnEvent, AddressOf Packet_SpawnEvent)
        Packets.Add(ServerPackets.SEventMove, AddressOf Packet_EventMove)
        Packets.Add(ServerPackets.SEventDir, AddressOf Packet_EventDir)
        Packets.Add(ServerPackets.SEventChat, AddressOf Packet_EventChat)
        Packets.Add(ServerPackets.SEventStart, AddressOf Packet_EventStart)
        Packets.Add(ServerPackets.SEventEnd, AddressOf Packet_EventEnd)
        Packets.Add(ServerPackets.SPlayBGM, AddressOf Packet_PlayBGM)
        Packets.Add(ServerPackets.SPlaySound, AddressOf Packet_PlaySound)
        Packets.Add(ServerPackets.SFadeoutBGM, AddressOf Packet_FadeoutBGM)
        Packets.Add(ServerPackets.SStopSound, AddressOf Packet_StopSound)
        Packets.Add(ServerPackets.SSwitchesAndVariables, AddressOf Packet_SwitchesAndVariables)
        Packets.Add(ServerPackets.SMapEventData, AddressOf Packet_MapEventData)
        'SChatBubble
        Packets.Add(ServerPackets.SSpecialEffect, AddressOf Packet_SpecialEffect)
        'SPic
        Packets.Add(ServerPackets.SHoldPlayer, AddressOf Packet_HoldPlayer)

        Packets.Add(ServerPackets.SProjectileEditor, AddressOf HandleProjectileEditor)
        Packets.Add(ServerPackets.SUpdateProjectile, AddressOf HandleUpdateProjectile)
        Packets.Add(ServerPackets.SMapProjectile, AddressOf HandleMapProjectile)
    End Sub

    Sub HandleDataPackets(ByVal data() As Byte)
        Dim packetnum As Long, buffer As ByteBuffer, Packet As Packet_
        Packet = Nothing
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        packetnum = buffer.ReadLong
        buffer = Nothing

        If Packets.TryGetValue(packetnum, Packet) Then
            Packet.Invoke(data)
        End If
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

        MsgBox(Msg, vbOKOnly, GAME_NAME)
        DestroyGame()
    End Sub

    Sub Packet_LoginOk(ByVal Data() As Byte)
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
        MyIndex = Buffer.ReadLong

        Buffer = Nothing

        frmloadvisible = True
        SetStatus("Receiving game data...")
    End Sub

    Sub Packet_NewCharClasses(ByVal data() As Byte)
        Dim i As Long, z As Long, X As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SNewCharClasses Then Exit Sub

        ' Max classes
        Max_Classes = Buffer.ReadLong
        ReDim Classes(0 To Max_Classes)

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
                .Stat(Stats.luck) = Buffer.ReadLong
                .Stat(Stats.spirit) = Buffer.ReadLong
            End With

        Next

        Buffer = Nothing

        ' Used for if the player is creating a new character
        frmmenuvisible = True
        frmloadvisible = False
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

    Private Sub Packet_ClassesData(ByVal data() As Byte)
        Dim i As Long
        Dim z As Long, X As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SClassesData Then Exit Sub

        ' Max classes
        Max_Classes = Buffer.ReadLong
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.stat_count - 1)
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Vital(0 To Vitals.Vital_Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Buffer.ReadString
                .Vital(Vitals.HP) = Buffer.ReadLong
                .Vital(Vitals.MP) = Buffer.ReadLong
                .Vital(Vitals.SP) = Buffer.ReadLong

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

                .Stat(Stats.strength) = Buffer.ReadLong
                .Stat(Stats.endurance) = Buffer.ReadLong
                .Stat(Stats.vitality) = Buffer.ReadLong
                .Stat(Stats.intelligence) = Buffer.ReadLong
                .Stat(Stats.luck) = Buffer.ReadLong
                .Stat(Stats.spirit) = Buffer.ReadLong
            End With

        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_InGame(ByVal data() As Byte)
        InGame = True
        CanMoveNow = True
        GameInit()
    End Sub

    Private Sub Packet_PlayerInv(ByVal data() As Byte)
        Dim i As Long
        Dim InvNum As Long, Amount As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerInv Then Exit Sub

        For i = 1 To MAX_INV
            InvNum = Buffer.ReadLong
            Amount = Buffer.ReadLong
            SetPlayerInvItemNum(MyIndex, i, InvNum)
            SetPlayerInvItemValue(MyIndex, i, Amount)
        Next

        ' changes to inventory, need to clear any drop menu
        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerInvUpdate(ByVal data() As Byte)
        Dim n As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerInvUpdate Then Exit Sub

        n = Buffer.ReadLong
        SetPlayerInvItemNum(MyIndex, n, Buffer.ReadLong)
        SetPlayerInvItemValue(MyIndex, n, Buffer.ReadLong)

        ' changes, clear drop menu
        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerWornEquipment(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerWornEq Then Exit Sub

        SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Armor)
        SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Weapon)
        SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Helmet)
        SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Shield)
        SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Shoes)
        SetPlayerEquipment(MyIndex, Buffer.ReadLong, Equipment.Gloves)

        ' changes to inventory, need to clear any drop menu

        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerHP(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadLong <> ServerPackets.SPlayerHp Then Exit Sub

        Player(MyIndex).MaxHP = Buffer.ReadLong

        SetPlayerVital(MyIndex, Vitals.HP, Buffer.ReadLong)

        If GetPlayerMaxVital(MyIndex, Vitals.HP) > 0 Then
            lblHPText = GetPlayerVital(MyIndex, Vitals.HP) & "/" & GetPlayerMaxVital(MyIndex, Vitals.HP)
            ' hp bar
            picHpWidth = Int(((GetPlayerVital(MyIndex, Vitals.HP) / 169) / (GetPlayerMaxVital(MyIndex, Vitals.HP) / 169)) * 169)
        End If

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerMP(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerMp Then Exit Sub

        Player(MyIndex).MaxMP = Buffer.ReadLong
        SetPlayerVital(MyIndex, Vitals.MP, Buffer.ReadLong)

        If GetPlayerMaxVital(MyIndex, Vitals.MP) > 0 Then
            lblManaText = GetPlayerVital(MyIndex, Vitals.MP) & "/" & GetPlayerMaxVital(MyIndex, Vitals.MP)
            ' mp bar
            picManaWidth = Int(((GetPlayerVital(MyIndex, Vitals.MP) / 169) / (GetPlayerMaxVital(MyIndex, Vitals.MP) / 169)) * 169)
        End If

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerSP(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SPlayerSp Then Exit Sub

        Player(MyIndex).MaxSP = Buffer.ReadLong
        SetPlayerVital(MyIndex, Vitals.SP, Buffer.ReadLong)

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerStats(ByVal data() As Byte)
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

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerData(ByVal Data() As Byte)
        Dim i As Long, X As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SPlayerData Then Exit Sub

        i = Buffer.ReadLong
        SetPlayerName(i, Buffer.ReadString)
        SetPlayerClass(i, Buffer.ReadLong)
        SetPlayerLevel(i, Buffer.ReadLong)
        SetPlayerPOINTS(i, Buffer.ReadLong)
        SetPlayerSprite(i, Buffer.ReadLong)
        SetPlayerMap(i, Buffer.ReadLong)
        SetPlayerX(i, Buffer.ReadLong)
        SetPlayerY(i, Buffer.ReadLong)
        SetPlayerDir(i, Buffer.ReadLong)
        SetPlayerAccess(i, Buffer.ReadLong)
        SetPlayerPK(i, Buffer.ReadLong)

        For X = 1 To Stats.stat_count - 1
            SetPlayerStat(i, X, Buffer.ReadLong)
        Next

        Player(i).InHouse = Buffer.ReadLong

        For X = 0 To ResourceSkills.Skill_Count - 1
            Player(i).GatherSkills(X).SkillLevel = Buffer.ReadLong
            Player(i).GatherSkills(X).SkillCurExp = Buffer.ReadLong
            Player(i).GatherSkills(X).SkillNextLvlExp = Buffer.ReadLong
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

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerMove(ByVal Data() As Byte)
        Dim i As Long, X As Long, Y As Long
        Dim Dir As Long, n As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SPlayerMove Then Exit Sub

        i = Buffer.ReadLong
        X = Buffer.ReadLong
        Y = Buffer.ReadLong
        Dir = Buffer.ReadLong
        n = Buffer.ReadLong

        SetPlayerX(i, X)
        SetPlayerY(i, Y)
        SetPlayerDir(i, Dir)
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

        'Debug.Print("Client-PlayerMove")

        Buffer = Nothing
    End Sub

    Private Sub Packet_NpcMove(ByVal Data() As Byte)
        Dim MapNpcNum As Long
        Dim Movement As Long
        Dim X As Long, Y As Long, Dir As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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

    Private Sub Packet_PlayerDir(ByVal Data() As Byte)
        Dim Dir As Long, i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SPlayerDir Then Exit Sub

        i = Buffer.ReadLong
        Dir = Buffer.ReadLong

        SetPlayerDir(i, Dir)

        With Player(i)
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_NpcDir(ByVal Data() As Byte)
        Dim Dir As Long, i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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

    Private Sub Packet_PlayerXY(ByVal Data() As Byte)
        Dim X As Long, Y As Long, Dir As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SPlayerXY Then Exit Sub

        X = Buffer.ReadLong
        Y = Buffer.ReadLong
        Dir = Buffer.ReadLong

        SetPlayerX(MyIndex, X)
        SetPlayerY(MyIndex, Y)
        SetPlayerDir(MyIndex, Dir)

        ' Make sure they aren't walking
        Player(MyIndex).Moving = 0
        Player(MyIndex).XOffset = 0
        Player(MyIndex).YOffset = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_Attack(ByVal Data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SAttack Then Exit Sub

        i = Buffer.ReadLong

        ' Set player to attacking
        Player(i).Attacking = 1
        Player(i).AttackTimer = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_NpcAttack(ByVal Data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SNpcAttack Then Exit Sub

        i = Buffer.ReadLong

        ' Set player to attacking
        MapNpc(i).Attacking = 1
        MapNpc(i).AttackTimer = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_CheckMap(ByVal Data() As Byte)
        Dim X As Long, Y As Long, i As Long
        Dim NeedMap As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SCheckforMap Then Exit Sub

        ' Erase all players except self
        For i = 1 To MAX_PLAYERS
            If i <> MyIndex Then
                SetPlayerMap(i, 0)
            End If
        Next

        ' Erase all temporary tile values
        ClearTempTile()
        ClearMapNpcs()
        ClearMapItems()
        ClearMap()

        ' Get map num
        X = Buffer.ReadLong
        ' Get revision
        Y = Buffer.ReadLong

        If FileExist(MAP_PATH & "map" & X & MAP_EXT) Then
            LoadMap(X)
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

    Private Sub Packet_MapData(ByVal Data() As Byte)
        Dim X As Long, Y As Long, i As Long
        Dim MapNum As Long, MusicFile As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapData Then Exit Sub

        Data = Buffer.ReadBytes(Buffer.Count - 8)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Decompress(Data))

        MapData = False

        SyncLock MapLock
            If Buffer.ReadLong = 1 Then

                MapNum = Buffer.ReadLong
                Map.Name = Trim(Buffer.ReadString)
                Map.Music = Trim(Buffer.ReadString)
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
                Map.WeatherType = Buffer.ReadLong
                Map.FogIndex = Buffer.ReadLong
                Map.WeatherIntensity = Buffer.ReadLong
                Map.FogAlpha = Buffer.ReadLong
                Map.FogSpeed = Buffer.ReadLong
                Map.HasMapTint = Buffer.ReadLong
                Map.MapTintR = Buffer.ReadLong
                Map.MapTintG = Buffer.ReadLong
                Map.MapTintB = Buffer.ReadLong
                Map.MapTintA = Buffer.ReadLong

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
                        ReDim Map.Tile(X, Y).Autotile(0 To MapLayer.Layer_Count - 1)

                        For i = 0 To MapLayer.Layer_Count - 1
                            Map.Tile(X, Y).Layer(i).tileset = Buffer.ReadLong
                            Map.Tile(X, Y).Layer(i).X = Buffer.ReadLong
                            Map.Tile(X, Y).Layer(i).Y = Buffer.ReadLong
                            Map.Tile(X, Y).Autotile(i) = Buffer.ReadLong
                        Next
                        Map.Tile(X, Y).Type = Buffer.ReadLong
                    Next
                Next

                'Event Data!
                ResetEventdata()

                Map.EventCount = Buffer.ReadLong

                If Map.EventCount > 0 Then
                    ReDim Map.Events(0 To Map.EventCount)
                    For i = 1 To Map.EventCount
                        With Map.Events(i)
                            .Name = Trim(Buffer.ReadString)
                            .Globals = Buffer.ReadLong
                            .X = Buffer.ReadLong
                            .Y = Buffer.ReadLong
                            .PageCount = Buffer.ReadLong
                        End With
                        If Map.Events(i).PageCount > 0 Then
                            ReDim Map.Events(i).Pages(0 To Map.Events(i).PageCount)
                            For X = 1 To Map.Events(i).PageCount
                                With Map.Events(i).Pages(X)
                                    .chkVariable = Buffer.ReadLong
                                    .VariableIndex = Buffer.ReadLong
                                    .VariableCondition = Buffer.ReadLong
                                    .VariableCompare = Buffer.ReadLong

                                    .chkSwitch = Buffer.ReadLong
                                    .SwitchIndex = Buffer.ReadLong
                                    .SwitchCompare = Buffer.ReadLong

                                    .chkHasItem = Buffer.ReadLong
                                    .HasItemIndex = Buffer.ReadLong
                                    .HasItemAmount = Buffer.ReadLong

                                    .chkSelfSwitch = Buffer.ReadLong
                                    .SelfSwitchIndex = Buffer.ReadLong
                                    .SelfSwitchCompare = Buffer.ReadLong

                                    .GraphicType = Buffer.ReadLong
                                    .Graphic = Buffer.ReadLong
                                    .GraphicX = Buffer.ReadLong
                                    .GraphicY = Buffer.ReadLong
                                    .GraphicX2 = Buffer.ReadLong
                                    .GraphicY2 = Buffer.ReadLong

                                    .MoveType = Buffer.ReadLong
                                    .MoveSpeed = Buffer.ReadLong
                                    .MoveFreq = Buffer.ReadLong

                                    .MoveRouteCount = Buffer.ReadLong

                                    .IgnoreMoveRoute = Buffer.ReadLong
                                    .RepeatMoveRoute = Buffer.ReadLong

                                    If .MoveRouteCount > 0 Then
                                        ReDim Map.Events(i).Pages(X).MoveRoute(0 To .MoveRouteCount)
                                        For Y = 1 To .MoveRouteCount
                                            .MoveRoute(Y).Index = Buffer.ReadLong
                                            .MoveRoute(Y).Data1 = Buffer.ReadLong
                                            .MoveRoute(Y).Data2 = Buffer.ReadLong
                                            .MoveRoute(Y).Data3 = Buffer.ReadLong
                                            .MoveRoute(Y).Data4 = Buffer.ReadLong
                                            .MoveRoute(Y).Data5 = Buffer.ReadLong
                                            .MoveRoute(Y).Data6 = Buffer.ReadLong
                                        Next
                                    End If

                                    .WalkAnim = Buffer.ReadLong
                                    .DirFix = Buffer.ReadLong
                                    .WalkThrough = Buffer.ReadLong
                                    .ShowName = Buffer.ReadLong
                                    .Trigger = Buffer.ReadLong
                                    .CommandListCount = Buffer.ReadLong

                                    .Position = Buffer.ReadLong
                                    .Questnum = Buffer.ReadLong
                                End With

                                If Map.Events(i).Pages(X).CommandListCount > 0 Then
                                    ReDim Map.Events(i).Pages(X).CommandList(0 To Map.Events(i).Pages(X).CommandListCount)
                                    For Y = 1 To Map.Events(i).Pages(X).CommandListCount
                                        Map.Events(i).Pages(X).CommandList(Y).CommandCount = Buffer.ReadLong
                                        Map.Events(i).Pages(X).CommandList(Y).ParentList = Buffer.ReadLong
                                        If Map.Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                            ReDim Map.Events(i).Pages(X).CommandList(Y).Commands(0 To Map.Events(i).Pages(X).CommandList(Y).CommandCount)
                                            For z = 1 To Map.Events(i).Pages(X).CommandList(Y).CommandCount
                                                With Map.Events(i).Pages(X).CommandList(Y).Commands(z)
                                                    .Index = Buffer.ReadLong
                                                    .Text1 = Trim(Buffer.ReadString)
                                                    .Text2 = Trim(Buffer.ReadString)
                                                    .Text3 = Trim(Buffer.ReadString)
                                                    .Text4 = Trim(Buffer.ReadString)
                                                    .Text5 = Trim(Buffer.ReadString)
                                                    .Data1 = Buffer.ReadLong
                                                    .Data2 = Buffer.ReadLong
                                                    .Data3 = Buffer.ReadLong
                                                    .Data4 = Buffer.ReadLong
                                                    .Data5 = Buffer.ReadLong
                                                    .Data6 = Buffer.ReadLong
                                                    .ConditionalBranch.CommandList = Buffer.ReadLong
                                                    .ConditionalBranch.Condition = Buffer.ReadLong
                                                    .ConditionalBranch.Data1 = Buffer.ReadLong
                                                    .ConditionalBranch.Data2 = Buffer.ReadLong
                                                    .ConditionalBranch.Data3 = Buffer.ReadLong
                                                    .ConditionalBranch.ElseCommandList = Buffer.ReadLong
                                                    .MoveRouteCount = Buffer.ReadLong
                                                    If .MoveRouteCount > 0 Then
                                                        ReDim Preserve .MoveRoute(.MoveRouteCount)
                                                        For w = 1 To .MoveRouteCount
                                                            .MoveRoute(w).Index = Buffer.ReadLong
                                                            .MoveRoute(w).Data1 = Buffer.ReadLong
                                                            .MoveRoute(w).Data2 = Buffer.ReadLong
                                                            .MoveRoute(w).Data3 = Buffer.ReadLong
                                                            .MoveRoute(w).Data4 = Buffer.ReadLong
                                                            .MoveRoute(w).Data5 = Buffer.ReadLong
                                                            .MoveRoute(w).Data6 = Buffer.ReadLong
                                                        Next
                                                    End If
                                                End With
                                            Next
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
                'End Event Data
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

        End SyncLock

        'Debug.Print("Client Handled mapdata")

        ' Save the map
        SaveMap(MapNum)

        initAutotiles()
        'Debug.Print("Client Handled Autotile Init")

        ' Check if we get a map from someone else and if we were editing a map cancel it out
        If InMapEditor Then
            InMapEditor = False
            frmEditor_Map.Visible = False

            ClearAttributeDialogue()
        End If

        MapData = True


        For i = 1 To MAX_BYTE
            ClearActionMsg(i)
        Next i

        CurrentWeather = Map.WeatherType
        CurrentWeatherIntensity = Map.WeatherIntensity
        CurrentFog = Map.FogIndex
        CurrentFogSpeed = Map.FogSpeed
        CurrentFogOpacity = Map.FogAlpha
        CurrentTintR = Map.MapTintR
        CurrentTintG = Map.MapTintG
        CurrentTintB = Map.MapTintB
        CurrentTintA = Map.MapTintA

        MusicFile = Trim$(Map.Music)
        PlayMusic(MusicFile)

        UpdateDrawMapName()

        GettingMap = False
        CanMoveNow = True

        'Debug.Print("PacketMapdata: " & GettingMap)
    End Sub

    Private Sub Packet_MapNPCData(ByVal Data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapNPCUpdate(ByVal Data() As Byte)
        Dim NpcNum As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapNpcUpdate Then Exit Sub

        npcnum = Buffer.ReadLong

        With MapNpc(npcnum)
            .Num = Buffer.ReadLong
            .X = Buffer.ReadLong
            .Y = Buffer.ReadLong
            .Dir = Buffer.ReadLong
            .Vital(Vitals.HP) = Buffer.ReadLong
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapDone(ByVal data() As Byte)
        Dim i As Long
        Dim MusicFile As String

        For i = 1 To MAX_BYTE
            ClearActionMsg(i)
        Next i

        CurrentWeather = Map.WeatherType
        CurrentWeatherIntensity = Map.WeatherIntensity
        CurrentFog = Map.FogIndex
        CurrentFogSpeed = Map.FogSpeed
        CurrentFogOpacity = Map.FogAlpha
        CurrentTintR = Map.MapTintR
        CurrentTintG = Map.MapTintG
        CurrentTintB = Map.MapTintB
        CurrentTintA = Map.MapTintA

        MusicFile = Trim$(Map.Music)
        PlayMusic(MusicFile)

        UpdateDrawMapName()

        GettingMap = False
        CanMoveNow = True

    End Sub

    Private Sub Packet_GlobalMessage(ByVal Data() As Byte)
        Dim Msg As String
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SGlobalMsg Then Exit Sub

        Msg = Trim(Buffer.ReadString)

        Buffer = Nothing

        AddText(Msg, GlobalColor)
    End Sub

    Private Sub Packet_MapMessage(ByVal Data() As Byte)
        Dim Msg As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapMsg Then Exit Sub

        Msg = Trim(Buffer.ReadString)

        Buffer = Nothing

        AddText(Msg, BroadcastColor)

    End Sub

    Private Sub Packet_SpawnItem(ByVal Data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SSpawnItem Then Exit Sub

        i = Buffer.ReadLong

        With MapItem(i)
            .Num = Buffer.ReadLong
            .Value = Buffer.ReadLong
            .X = Buffer.ReadLong
            .Y = Buffer.ReadLong
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_EditItem(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SItemEditor Then Exit Sub

        InitItemEditor = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerMessage(ByVal Data() As Byte)
        Dim Msg As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SPlayerMsg Then Exit Sub

        Msg = Trim(Buffer.ReadString)

        Buffer = Nothing

        AddText(Msg, TellColor)
    End Sub

    Sub Packet_UpdateItem(ByVal data() As Byte)
        Dim n As Long, i As Long
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
        Item(n).Name = Trim(Buffer.ReadString())
        Item(n).Paperdoll = Buffer.ReadLong()
        Item(n).Pic = Buffer.ReadLong()
        Item(n).Price = Buffer.ReadLong()
        Item(n).Rarity = Buffer.ReadLong()
        Item(n).Speed = Buffer.ReadLong()
        Item(n).Randomize = Buffer.ReadLong()
        Item(n).Stackable = Buffer.ReadLong()

        For i = 0 To Stats.stat_count - 1
            Item(n).Stat_Req(i) = Buffer.ReadLong()
        Next

        Item(n).Type = Buffer.ReadLong()

        'Housing
        Item(n).FurnitureWidth = Buffer.ReadLong()
        Item(n).FurnitureHeight = Buffer.ReadLong()

        For a = 1 To 3
            For b = 1 To 3
                Item(n).FurnitureBlocks(a, b) = Buffer.ReadLong()
                Item(n).FurnitureFringe(a, b) = Buffer.ReadLong()
            Next
        Next

        Item(n).KnockBack = Buffer.ReadLong()
        Item(n).KnockBackTiles = Buffer.ReadLong()

        Buffer = Nothing
        ' changes to inventory, need to clear any drop menu

        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

    End Sub

    Sub Packet_SpawnNPC(ByVal data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SSpawnNpc Then Exit Sub

        i = Buffer.ReadLong

        With MapNpc(i)
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
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SNpcDead Then Exit Sub

        i = Buffer.ReadLong
        ClearMapNpc(i)

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
        Dim i As Long, x As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateNpc Then Exit Sub

        i = Buffer.ReadLong
        ' Update the Npc
        Npc(i).Animation = Buffer.ReadLong()
        Npc(i).AttackSay = Trim(Buffer.ReadString())
        Npc(i).Behaviour = Buffer.ReadLong()
        ReDim Npc(i).DropChance(5)
        ReDim Npc(i).DropItem(5)
        ReDim Npc(i).DropItemValue(5)
        For x = 1 To 5
            Npc(i).DropChance(x) = Buffer.ReadLong()
            Npc(i).DropItem(x) = Buffer.ReadLong()
            Npc(i).DropItemValue(x) = Buffer.ReadLong()
        Next

        Npc(i).EXP = Buffer.ReadLong()
        Npc(i).faction = Buffer.ReadLong()
        Npc(i).HP = Buffer.ReadLong()
        Npc(i).Name = Trim(Buffer.ReadString())
        Npc(i).Range = Buffer.ReadLong()
        Npc(i).SpawnSecs = Buffer.ReadLong()
        Npc(i).Sprite = Buffer.ReadLong()

        For i = 0 To Stats.stat_count - 1
            Npc(i).Stat(i) = Buffer.ReadLong()
        Next

        Npc(i).QuestNum = Buffer.ReadLong()

        If Npc(i).AttackSay Is Nothing Then Npc(i).AttackSay = ""
        If Npc(i).Name Is Nothing Then Npc(i).Name = ""

        Buffer = Nothing
    End Sub

    Sub Packet_MapKey(ByVal data() As Byte)
        Dim n As Long, X As Long, Y As Long
        Dim Buffer As ByteBuffer
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
        Shop(shopnum).Name = Trim(Buffer.ReadString())
        Shop(shopnum).Face = Buffer.ReadLong()

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
        Spell(spellnum).Name = Trim(Buffer.ReadString())
        Spell(spellnum).Range = Buffer.ReadLong()
        Spell(spellnum).SpellAnim = Buffer.ReadLong()
        Spell(spellnum).StunDuration = Buffer.ReadLong()
        Spell(spellnum).Type = Buffer.ReadLong()
        Spell(spellnum).Vital = Buffer.ReadLong()
        Spell(spellnum).X = Buffer.ReadLong()
        Spell(spellnum).Y = Buffer.ReadLong()

        Spell(spellnum).IsProjectile = Buffer.ReadLong()
        Spell(spellnum).Projectile = Buffer.ReadLong()

        Spell(spellnum).KnockBack = Buffer.ReadLong()
        Spell(spellnum).KnockBackTiles = Buffer.ReadLong()

        If Spell(spellnum).Name Is Nothing Then Spell(spellnum).Name = ""

        Buffer = Nothing

    End Sub

    Sub Packet_Spells(ByVal data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SSpells Then Exit Sub

        For i = 1 To MAX_PLAYER_SPELLS
            PlayerSpells(i) = Buffer.ReadLong
        Next

        Buffer = Nothing
    End Sub

    Sub Packet_LeftMap(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadLong <> ServerPackets.SLeftMap Then Exit Sub

        ClearPlayer(Buffer.ReadLong)

        Buffer = Nothing
    End Sub

    Private Sub Packet_ResourceCache(ByVal Data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer

        ' if in map editor, we cache shit ourselves
        If InMapEditor Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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
        PingEnd = GetTickCount()
        Ping = PingEnd - PingStart
    End Sub

    Private Sub Packet_DoorAnimation(ByVal data() As Byte)
        Dim X As Long, Y As Long
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SDoorAnimation Then Exit Sub

        X = buffer.ReadLong
        Y = buffer.ReadLong
        With TempTile(X, Y)
            .DoorFrame = 1
            .DoorAnimate = 1 ' 0 = nothing| 1 = opening | 2 = closing
            .DoorTimer = GetTickCount()
        End With

        buffer = Nothing
    End Sub

    Private Sub Packet_ActionMessage(ByVal data() As Byte)
        Dim X As Long, Y As Long, message As String, color As Long, tmpType As Long
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadLong <> ServerPackets.SActionMsg Then Exit Sub

        message = Trim(buffer.ReadString)
        color = buffer.ReadLong
        tmpType = buffer.ReadLong
        X = buffer.ReadLong
        Y = buffer.ReadLong

        buffer = Nothing

        CreateActionMsg(message, color, tmpType, X, Y)
    End Sub

    Private Sub Packet_ResourceEditor(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SResourceEditor Then Exit Sub

        InitResourceEditor = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_UpdateResource(ByVal Data() As Byte)
        Dim ResourceNum As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SUpdateResource Then Exit Sub

        ResourceNum = Buffer.ReadLong

        Resource(ResourceNum).Animation = Buffer.ReadLong()
        Resource(ResourceNum).EmptyMessage = Trim(Buffer.ReadString())
        Resource(ResourceNum).ExhaustedImage = Buffer.ReadLong()
        Resource(ResourceNum).Health = Buffer.ReadLong()
        Resource(ResourceNum).ExpReward = Buffer.ReadLong()
        Resource(ResourceNum).ItemReward = Buffer.ReadLong()
        Resource(ResourceNum).Name = Trim(Buffer.ReadString())
        Resource(ResourceNum).ResourceImage = Buffer.ReadLong()
        Resource(ResourceNum).ResourceType = Buffer.ReadLong()
        Resource(ResourceNum).RespawnTime = Buffer.ReadLong()
        Resource(ResourceNum).SuccessMessage = Trim(Buffer.ReadString())
        Resource(ResourceNum).LvlRequired = Buffer.ReadLong()
        Resource(ResourceNum).ToolRequired = Buffer.ReadLong()
        Resource(ResourceNum).Walkthrough = Buffer.ReadLong()

        If Resource(ResourceNum).Name Is Nothing Then Resource(ResourceNum).Name = ""
        If Resource(ResourceNum).EmptyMessage Is Nothing Then Resource(ResourceNum).EmptyMessage = ""
        If Resource(ResourceNum).SuccessMessage Is Nothing Then Resource(ResourceNum).SuccessMessage = ""

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerExp(ByVal Data() As Byte)
        Dim index As Long, TNL As Long
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SPlayerEXP Then Exit Sub

        index = Buffer.ReadLong
        SetPlayerExp(index, Buffer.ReadLong)
        TNL = Buffer.ReadLong

        If TNL = 0 Then TNL = 1
        NextlevelExp = TNL

        Buffer = Nothing
    End Sub

    Private Sub Packet_Blood(ByVal Data() As Byte)
        Dim X As Long, Y As Long, Sprite As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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
            .Timer = GetTickCount()
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_EditAnimation(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)
        If Buffer.ReadLong <> ServerPackets.SAnimationEditor Then Exit Sub

        InitAnimationEditor = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_UpdateAnimation(ByVal Data() As Byte)
        Dim n As Long, i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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

        Animation(n).Name = Trim(Buffer.ReadString())

        If Animation(n).Name Is Nothing Then Animation(n).Name = ""

        For i = 0 To UBound(Animation(n).Sprite)
            Animation(n).Sprite(i) = Buffer.ReadLong()
        Next
        Buffer = Nothing
    End Sub

    Private Sub Packet_Animation(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

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

    Private Sub Packet_NPCVitals(ByVal Data() As Byte)
        Dim MapNpcNum As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapNpcVitals Then Exit Sub

        MapNpcNum = Buffer.ReadLong
        For i = 1 To Vitals.Vital_Count - 1
            MapNpc(MapNpcNum).Vital(i) = Buffer.ReadLong
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_Cooldown(ByVal Data() As Byte)
        Dim slot As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SCooldown Then Exit Sub

        slot = Buffer.ReadLong
        SpellCD(slot) = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_ClearSpellBuffer(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SClearSpellBuffer Then Exit Sub

        SpellBuffer = 0
        SpellBufferTimer = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_SayMessage(ByVal Data() As Byte)
        Dim Access As Long, Name As String, message As String
        'Dim colour As Long
        Dim Header As String, PK As Long
        'Dim saycolour As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SSayMsg Then Exit Sub

        Name = Trim(Buffer.ReadString)
        Access = Buffer.ReadLong
        PK = Buffer.ReadLong
        message = Trim(Buffer.ReadString)
        Header = Trim(Buffer.ReadString)

        AddText(Header & Name & ": " & message, SayColor)

        Buffer = Nothing
    End Sub

    Private Sub Packet_OpenShop(ByVal Data() As Byte)
        Dim shopnum As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SOpenShop Then Exit Sub

        shopnum = Buffer.ReadLong

        NeedToOpenShop = True
        NeedToOpenShopNum = shopnum

        Buffer = Nothing
    End Sub

    Private Sub Packet_ResetShopAction(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SResetShopAction Then Exit Sub

        ShopAction = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_Stunned(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SStunned Then Exit Sub

        StunDuration = Buffer.ReadLong

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapWornEquipment(ByVal Data() As Byte)
        Dim playernum As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapWornEq Then Exit Sub

        playernum = Buffer.ReadLong
        SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Armor)
        SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Weapon)
        SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Helmet)
        SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Shield)
        SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Shoes)
        SetPlayerEquipment(playernum, Buffer.ReadLong, Equipment.Gloves)

        Buffer = Nothing
    End Sub

    Private Sub Packet_OpenBank(ByVal Data() As Byte)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SBank Then Exit Sub

        For i = 1 To MAX_BANK
            Bank.Item(i).Num = Buffer.ReadLong
            Bank.Item(i).Value = Buffer.ReadLong
        Next

        NeedToOpenBank = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_ClearTradeTimer(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SClearTradeTimer Then Exit Sub

        TradeRequest = False
        TradeTimer = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_Trade(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.STrade Then Exit Sub

        NeedToOpenTrade = True
        Buffer.ReadLong()
        Tradername = Trim(Buffer.ReadString)
        pnlTradeVisible = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_CloseTrade(ByVal Data() As Byte)
        NeedtoCloseTrade = True
    End Sub

    Private Sub Packet_TradeUpdate(ByVal Data() As Byte)
        Dim datatype As Long
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadLong <> ServerPackets.STradeUpdate Then Exit Sub

        datatype = buffer.ReadLong

        If datatype = 0 Then ' ours!
            For i = 1 To MAX_INV
                TradeYourOffer(i).Num = buffer.ReadLong
                TradeYourOffer(i).Value = buffer.ReadLong
            Next
            YourWorth = "Total Worth: " & buffer.ReadLong & "g"
        ElseIf datatype = 1 Then 'theirs
            For i = 1 To MAX_INV
                TradeTheirOffer(i).Num = buffer.ReadLong
                TradeYourOffer(i).Value = buffer.ReadLong
            Next
            TheirWorth = "Total Worth: " & buffer.ReadLong & "g"
        End If

        NeedtoUpdateTrade = True

        buffer = Nothing
    End Sub

    Private Sub Packet_TradeStatus(ByVal Data() As Byte)
        Dim tradestatus As Long
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadLong <> ServerPackets.STradeStatus Then Exit Sub

        tradestatus = buffer.ReadLong

        Select Case tradestatus
            Case 0 ' clear
                'frmMainGame.lblTradeStatus.Text = vbNullString
            Case 1 ' they've accepted
                AddText("Other player has accepted.", White)
            Case 2 ' you've accepted
                AddText("Waiting for other player to accept.", White)
        End Select

        buffer = Nothing
    End Sub

    Private Sub Packet_GameData(ByVal Data() As Byte)
        Dim n As Long, i As Long, z As Long, x As Long, a As Long, b As Long
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadLong <> ServerPackets.SGameData Then Exit Sub

        Data = buffer.ReadBytes(buffer.Count - 8)
        Data = Decompress(Data)
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        '\\\Read Class Data\\\

        ' Max classes
        Max_Classes = buffer.ReadLong
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
                .Name = Trim(buffer.ReadString)
                .Vital(Vitals.HP) = buffer.ReadLong
                .Vital(Vitals.MP) = buffer.ReadLong
                .Vital(Vitals.SP) = buffer.ReadLong

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

                .Stat(Stats.strength) = buffer.ReadLong
                .Stat(Stats.endurance) = buffer.ReadLong
                .Stat(Stats.vitality) = buffer.ReadLong
                .Stat(Stats.intelligence) = buffer.ReadLong
                .Stat(Stats.luck) = buffer.ReadLong
                .Stat(Stats.spirit) = buffer.ReadLong
            End With

            n = n + 10
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\End Read Class Data\\\

        '\\\Read Item Data\\\\\\\
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
            Item(n).Name = Trim(buffer.ReadString())
            Item(n).Paperdoll = buffer.ReadLong()
            Item(n).Pic = buffer.ReadLong()
            Item(n).Price = buffer.ReadLong()
            Item(n).Rarity = buffer.ReadLong()
            Item(n).Speed = buffer.ReadLong()
            Item(n).Randomize = buffer.ReadLong()
            Item(n).Stackable = buffer.ReadLong()

            For z = 0 To Stats.stat_count - 1
                Item(n).Stat_Req(z) = buffer.ReadLong()
            Next

            Item(n).Type = buffer.ReadLong()

            'Housing
            Item(n).FurnitureWidth = buffer.ReadLong()
            Item(n).FurnitureHeight = buffer.ReadLong()

            For a = 1 To 3
                For b = 1 To 3
                    Item(n).FurnitureBlocks(a, b) = buffer.ReadLong()
                    Item(n).FurnitureFringe(a, b) = buffer.ReadLong()
                Next
            Next

            Item(n).KnockBack = buffer.ReadLong()
            Item(n).KnockBackTiles = buffer.ReadLong()
        Next

        ' changes to inventory, need to clear any drop menu

        frmMainGame.pnlCurrency.Visible = False
        frmMainGame.txtCurrency.Text = vbNullString
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Item Data\\\\\\\

        '\\\Read Animation Data\\\\\\\
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

            Animation(n).Name = Trim(buffer.ReadString())

            If Animation(n).Name Is Nothing Then Animation(n).Name = ""

            For z = 0 To UBound(Animation(n).Sprite)
                Animation(n).Sprite(z) = buffer.ReadLong()
            Next
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Animation Data\\\\\\\

        '\\\Read NPC Data\\\\\\\
        x = buffer.ReadLong
        For i = 1 To x
            n = buffer.ReadLong
            ' Update the Npc
            Npc(n).Animation = buffer.ReadLong()
            Npc(n).AttackSay = Trim(buffer.ReadString())
            Npc(n).Behaviour = buffer.ReadLong()
            For z = 1 To 5
                Npc(n).DropChance(z) = buffer.ReadLong()
                Npc(n).DropItem(z) = buffer.ReadLong()
                Npc(n).DropItemValue(z) = buffer.ReadLong()
            Next

            Npc(n).EXP = buffer.ReadLong()
            Npc(n).faction = buffer.ReadLong()
            Npc(n).HP = buffer.ReadLong()
            Npc(n).Name = Trim(buffer.ReadString())
            Npc(n).Range = buffer.ReadLong()
            Npc(n).SpawnSecs = buffer.ReadLong()
            Npc(n).Sprite = buffer.ReadLong()

            For z = 0 To Stats.stat_count - 1
                Npc(n).Stat(z) = buffer.ReadLong()
            Next

            Npc(n).QuestNum = buffer.ReadLong()

            If Npc(n).AttackSay Is Nothing Then Npc(n).AttackSay = ""
            If Npc(n).Name Is Nothing Then Npc(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read NPC Data\\\\\\\

        '\\\Read Shop Data\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong

            Shop(n).BuyRate = buffer.ReadLong()
            Shop(n).Name = Trim(buffer.ReadString())
            Shop(n).Face = buffer.ReadLong()

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

        '\\\End Read Shop Data\\\\\\\

        '\\\Read Spells Data\\\\\\\\\\
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
            Spell(n).Name = Trim(buffer.ReadString())
            Spell(n).Range = buffer.ReadLong()
            Spell(n).SpellAnim = buffer.ReadLong()
            Spell(n).StunDuration = buffer.ReadLong()
            Spell(n).Type = buffer.ReadLong()
            Spell(n).Vital = buffer.ReadLong()
            Spell(n).X = buffer.ReadLong()
            Spell(n).Y = buffer.ReadLong()

            Spell(n).IsProjectile = buffer.ReadLong()
            Spell(n).Projectile = buffer.ReadLong()

            Spell(n).KnockBack = buffer.ReadLong()
            Spell(n).KnockBackTiles = buffer.ReadLong()

            If Spell(n).Name Is Nothing Then Spell(n).Name = ""
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\End Read Spells Data\\\\\\\\\\

        '\\\Read Resource Data\\\\\\\\\\\\
        x = buffer.ReadLong

        For i = 1 To x
            n = buffer.ReadLong

            Resource(n).Animation = buffer.ReadLong()
            Resource(n).EmptyMessage = Trim(buffer.ReadString())
            Resource(n).ExhaustedImage = buffer.ReadLong()
            Resource(n).Health = buffer.ReadLong()
            Resource(n).ExpReward = buffer.ReadLong()
            Resource(n).ItemReward = buffer.ReadLong()
            Resource(n).Name = Trim(buffer.ReadString())
            Resource(n).ResourceImage = buffer.ReadLong()
            Resource(n).ResourceType = buffer.ReadLong()
            Resource(n).RespawnTime = buffer.ReadLong()
            Resource(n).SuccessMessage = Trim(buffer.ReadString())
            Resource(n).LvlRequired = buffer.ReadLong()
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

        '\\\End Read Resource Data\\\\\\\\\\\\

        buffer = Nothing
    End Sub

    Private Sub Packet_Target(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.STarget Then Exit Sub

        myTarget = Buffer.ReadLong
        myTargetType = Buffer.ReadLong

        Buffer = Nothing
    End Sub

    Private Sub Packet_Mapreport(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, I As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapReport Then Exit Sub

        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(Buffer.ReadString())
        Next

        UpdateMapnames = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_Admin(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SAdmin Then Exit Sub

        Adminvisible = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapNames(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, I As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SMapNames Then Exit Sub

        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(Buffer.ReadString())
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_Hotbar(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, i As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SHotbar Then Exit Sub

        For i = 1 To MAX_HOTBAR
            Player(MyIndex).Hotbar(i).Slot = Buffer.ReadLong
            Player(MyIndex).Hotbar(i).sType = Buffer.ReadLong
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_Critical(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SCritical Then Exit Sub

        ShakeTimer = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_News(ByVal Data() As Byte)

        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadLong <> ServerPackets.SNews Then Exit Sub

        News = Buffer.ReadString

        UpdateNews = True

        Buffer = Nothing
    End Sub
End Module
