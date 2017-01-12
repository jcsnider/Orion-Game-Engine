Module ClientHandleData
    Public PlayerBuffer As ByteBuffer
    Private Delegate Sub Packet_(ByVal Data() As Byte)
    Private Packets As Dictionary(Of Integer, Packet_)

    Public Sub HandleData(ByVal data() As Byte)
        Dim Buffer() As Byte
        Buffer = data.Clone
        Dim pLength As Integer

        If PlayerBuffer Is Nothing Then PlayerBuffer = New ByteBuffer
        PlayerBuffer.WriteBytes(Buffer)

        If PlayerBuffer.Count = 0 Then
            PlayerBuffer.Clear()
            Exit Sub
        End If

        If PlayerBuffer.Length >= 4 Then
            pLength = PlayerBuffer.ReadInteger(False)

            If pLength <= 0 Then
                PlayerBuffer.Clear()
                Exit Sub
            End If
        End If

        If PlayerBuffer.Length >= 4 Then
            pLength = PlayerBuffer.ReadInteger(False)

            If pLength <= 0 Then
                PlayerBuffer.Clear()
                Exit Sub
            End If
        End If

        Do While pLength > 0 And pLength <= PlayerBuffer.Length - 4

            If pLength <= PlayerBuffer.Length - 4 Then
                PlayerBuffer.ReadInteger()
                data = PlayerBuffer.ReadBytes(pLength)
                HandleDataPackets(data)
            End If

            pLength = 0

            If PlayerBuffer.Length >= 4 Then
                pLength = PlayerBuffer.ReadInteger(False)

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
        Packets.Add(ServerPackets.SLoadCharOk, AddressOf Packet_LoadCharOk)
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
        Packets.Add(ServerPackets.SCheckForMap, AddressOf Packet_CheckMap)
        Packets.Add(ServerPackets.SMapData, AddressOf Packet_MapData)
        Packets.Add(ServerPackets.SMapNpcData, AddressOf Packet_MapNPCData)
        Packets.Add(ServerPackets.SMapNpcUpdate, AddressOf Packet_MapNPCUpdate)
        Packets.Add(ServerPackets.SMapDone, AddressOf Packet_MapDone)
        Packets.Add(ServerPackets.SGlobalMsg, AddressOf Packet_GlobalMessage)
        Packets.Add(ServerPackets.SPlayerMsg, AddressOf Packet_PlayerMessage)
        Packets.Add(ServerPackets.SMapMsg, AddressOf Packet_MapMessage)
        Packets.Add(ServerPackets.SSpawnItem, AddressOf Packet_SpawnItem)
        Packets.Add(ServerPackets.SUpdateItem, AddressOf Packet_UpdateItem)
        Packets.Add(ServerPackets.SSpawnNpc, AddressOf Packet_SpawnNPC)
        Packets.Add(ServerPackets.SNpcDead, AddressOf Packet_NpcDead)
        Packets.Add(ServerPackets.SUpdateNpc, AddressOf Packet_UpdateNPC)
        Packets.Add(ServerPackets.SMapKey, AddressOf Packet_MapKey)
        Packets.Add(ServerPackets.SEditMap, AddressOf Packet_EditMap)
        Packets.Add(ServerPackets.SUpdateShop, AddressOf Packet_UpdateShop)
        Packets.Add(ServerPackets.SUpdateSkill, AddressOf Packet_UpdateSkill)
        Packets.Add(ServerPackets.SSkills, AddressOf Packet_Skills)
        Packets.Add(ServerPackets.SLeftMap, AddressOf Packet_LeftMap)
        Packets.Add(ServerPackets.SResourceCache, AddressOf Packet_ResourceCache)
        Packets.Add(ServerPackets.SUpdateResource, AddressOf Packet_UpdateResource)
        Packets.Add(ServerPackets.SSendPing, AddressOf Packet_Ping)
        Packets.Add(ServerPackets.SDoorAnimation, AddressOf Packet_DoorAnimation)
        Packets.Add(ServerPackets.SActionMsg, AddressOf Packet_ActionMessage)
        Packets.Add(ServerPackets.SPlayerEXP, AddressOf Packet_PlayerExp)
        Packets.Add(ServerPackets.SBlood, AddressOf Packet_Blood)
        Packets.Add(ServerPackets.SUpdateAnimation, AddressOf Packet_UpdateAnimation)
        Packets.Add(ServerPackets.SAnimation, AddressOf Packet_Animation)
        Packets.Add(ServerPackets.SMapNpcVitals, AddressOf Packet_NPCVitals)
        Packets.Add(ServerPackets.SCooldown, AddressOf Packet_Cooldown)
        Packets.Add(ServerPackets.SClearSkillBuffer, AddressOf Packet_ClearSkillBuffer)
        Packets.Add(ServerPackets.SSayMsg, AddressOf Packet_SayMessage)
        Packets.Add(ServerPackets.SOpenShop, AddressOf Packet_OpenShop)
        Packets.Add(ServerPackets.SResetShopAction, AddressOf Packet_ResetShopAction)
        Packets.Add(ServerPackets.SStunned, AddressOf Packet_Stunned)
        Packets.Add(ServerPackets.SMapWornEq, AddressOf Packet_MapWornEquipment)
        Packets.Add(ServerPackets.SBank, AddressOf Packet_OpenBank)
        Packets.Add(ServerPackets.SLeftGame, AddressOf Packet_LeftGame)

        Packets.Add(ServerPackets.SClearTradeTimer, AddressOf Packet_ClearTradeTimer)
        Packets.Add(ServerPackets.STradeInvite, AddressOf Packet_TradeInvite)
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
        Packets.Add(ServerPackets.SrClick, AddressOf Packet_RClick)
        Packets.Add(ServerPackets.STotalOnline, AddressOf Packet_TotalOnline)

        'quests
        Packets.Add(ServerPackets.SUpdateQuest, AddressOf Packet_UpdateQuest)
        Packets.Add(ServerPackets.SPlayerQuest, AddressOf Packet_PlayerQuest)
        Packets.Add(ServerPackets.SPlayerQuests, AddressOf Packet_PlayerQuests)
        Packets.Add(ServerPackets.SQuestMessage, AddressOf Packet_QuestMessage)

        'Housing
        Packets.Add(ServerPackets.SHouseConfigs, AddressOf Packet_HouseConfigurations)
        Packets.Add(ServerPackets.SBuyHouse, AddressOf Packet_HouseOffer)
        Packets.Add(ServerPackets.SVisit, AddressOf Packet_Visit)
        Packets.Add(ServerPackets.SFurniture, AddressOf Packet_Furniture)

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
        Packets.Add(ServerPackets.SFadeoutBGM, AddressOf Packet_FadeOutBGM)
        Packets.Add(ServerPackets.SStopSound, AddressOf Packet_StopSound)
        Packets.Add(ServerPackets.SSwitchesAndVariables, AddressOf Packet_SwitchesAndVariables)
        Packets.Add(ServerPackets.SMapEventData, AddressOf Packet_MapEventData)
        'SChatBubble
        Packets.Add(ServerPackets.SChatBubble, AddressOf Packet_ChatBubble)
        Packets.Add(ServerPackets.SSpecialEffect, AddressOf Packet_SpecialEffect)
        'SPic
        Packets.Add(ServerPackets.SHoldPlayer, AddressOf Packet_HoldPlayer)

        Packets.Add(ServerPackets.SUpdateProjectile, AddressOf HandleUpdateProjectile)
        Packets.Add(ServerPackets.SMapProjectile, AddressOf HandleMapProjectile)

        'craft
        Packets.Add(ServerPackets.SUpdateRecipe, AddressOf Packet_UpdateRecipe)
        Packets.Add(ServerPackets.SSendPlayerRecipe, AddressOf Packet_SendPlayerRecipe)
        Packets.Add(ServerPackets.SOpenCraft, AddressOf Packet_OpenCraft)
        Packets.Add(ServerPackets.SUpdateCraft, AddressOf Packet_UpdateCraft)

        'emotes
        Packets.Add(ServerPackets.SEmote, AddressOf Packet_Emote)

        'party
        Packets.Add(ServerPackets.SPartyInvite, AddressOf Packet_PartyInvite)
        Packets.Add(ServerPackets.SPartyUpdate, AddressOf Packet_PartyUpdate)
        Packets.Add(ServerPackets.SPartyVitals, AddressOf Packet_PartyVitals)

        'pets
        Packets.Add(ServerPackets.SUpdatePet, AddressOf Packet_UpdatePet)
        Packets.Add(ServerPackets.SUpdatePlayerPet, AddressOf Packet_UpdatePlayerPet)
        Packets.Add(ServerPackets.SPetMove, AddressOf Packet_PetMove)
        Packets.Add(ServerPackets.SPetDir, AddressOf Packet_PetDir)
        Packets.Add(ServerPackets.SPetVital, AddressOf Packet_PetVital)
        Packets.Add(ServerPackets.SClearPetSkillBuffer, AddressOf Packet_ClearPetSkillBuffer)
        Packets.Add(ServerPackets.SPetAttack, AddressOf Packet_PetAttack)
    End Sub

    Sub HandleDataPackets(ByVal data() As Byte)
        Dim packetnum As Integer, buffer As ByteBuffer, Packet As Packet_
        Packet = Nothing
        buffer = New ByteBuffer
        buffer.WriteBytes(data)
        packetnum = buffer.ReadInteger
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
        If Buffer.ReadInteger <> ServerPackets.SAlertMsg Then Exit Sub

        pnlloadvisible = False

        If FrmMenu.Visible = False Then
            frmmenuvisible = True
        End If

        pnlCharCreateVisible = False
        pnlLoginVisible = False
        pnlRegisterVisible = False

        Msg = Trim(Buffer.ReadString)

        Buffer = Nothing

        MsgBox(Msg, vbOKOnly, GAME_NAME)
        DestroyGame()
    End Sub

    Sub Packet_LoadCharOk(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SLoadCharOk Then Exit Sub

        ' Now we can receive game data
        MyIndex = Buffer.ReadInteger

        Buffer = Nothing

        pnlloadvisible = True
        SetStatus("Receiving game data...")
    End Sub

    Sub Packet_LoginOk(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, MaxChars As Byte, CharName As String, Sprite As Integer, Level As Integer, ClassName As String, Gender As Byte
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SLoginOk Then Exit Sub

        ' save options
        Options.SavePass = chkSavePassChecked
        Options.Username = Trim$(tempUserName)

        If chkSavePassChecked = False Then
            Options.Password = ""
        Else
            Options.Password = Trim$(tempPassword)
        End If

        SaveOptions()

        ' Request classes.
        SendRequestClasses()

        ' Now we can receive char data
        MaxChars = Buffer.ReadInteger
        ReDim CharSelection(MaxChars)

        SelectedChar = 1

        'reset for deleting chars
        For i = 1 To MaxChars
            CharSelection(i).Name = ""
            CharSelection(i).Sprite = 0
            CharSelection(i).Level = 0
            CharSelection(i).ClassName = ""
            CharSelection(i).Gender = 0
        Next

        For i = 1 To MaxChars
            CharName = Buffer.ReadString
            Sprite = Buffer.ReadInteger
            Level = Buffer.ReadInteger
            ClassName = Buffer.ReadString
            Gender = Buffer.ReadInteger

            CharSelection(i).Name = CharName
            CharSelection(i).Sprite = Sprite
            CharSelection(i).Level = Level
            CharSelection(i).ClassName = ClassName
            CharSelection(i).Gender = Gender
        Next

        Buffer = Nothing
        ' Used for if the player is creating a new character
        frmmenuvisible = True
        pnlloadvisible = False
        pnlCreditsVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = False
        pnlLoginVisible = False

        pnlCharSelectVisible = True

        FrmMenu.DrawCharacter()

        DrawCharSelect = True

    End Sub

    Sub Packet_NewCharClasses(ByVal data() As Byte)
        Dim i As Integer, z As Integer, X As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SNewCharClasses Then Exit Sub

        ' Max classes
        Max_Classes = Buffer.ReadInteger
        ReDim Classes(0 To Max_Classes)

        SelectedChar = 1

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Trim(Buffer.ReadString)
                .Desc = Trim(Buffer.ReadString)

                ReDim .Vital(0 To Vitals.Count - 1)

                .Vital(Vitals.HP) = Buffer.ReadInteger
                .Vital(Vitals.MP) = Buffer.ReadInteger
                .Vital(Vitals.SP) = Buffer.ReadInteger

                ' get array size
                z = Buffer.ReadInteger
                ' redim array
                ReDim .MaleSprite(0 To z + 1)
                ' loop-receive data
                For X = 1 To z + 1
                    .MaleSprite(X) = Buffer.ReadInteger
                Next

                ' get array size
                z = Buffer.ReadInteger
                ' redim array
                ReDim .FemaleSprite(0 To z + 1)
                ' loop-receive data
                For X = 1 To z + 1
                    .FemaleSprite(X) = Buffer.ReadInteger
                Next

                ReDim .Stat(0 To Stats.Count - 1)

                .Stat(Stats.Strength) = Buffer.ReadInteger
                .Stat(Stats.Endurance) = Buffer.ReadInteger
                .Stat(Stats.Vitality) = Buffer.ReadInteger
                .Stat(Stats.Intelligence) = Buffer.ReadInteger
                .Stat(Stats.Luck) = Buffer.ReadInteger
                .Stat(Stats.Spirit) = Buffer.ReadInteger

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = Buffer.ReadInteger
                    .StartValue(q) = Buffer.ReadInteger
                Next

                .StartMap = Buffer.ReadInteger
                .StartX = Buffer.ReadInteger
                .StartY = Buffer.ReadInteger

                .BaseExp = Buffer.ReadInteger
            End With

        Next

        Buffer = Nothing

        ' Used for if the player is creating a new character
        frmmenuvisible = True
        pnlloadvisible = False
        pnlCreditsVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = True
        pnlLoginVisible = False
        'pnlCharSelectVisible = True

        ReDim cmbclass(0 To Max_Classes)

        For i = 1 To Max_Classes
            cmbclass(i) = Classes(i).Name
        Next

        FrmMenu.DrawCharacter()

        newCharSprite = 1
    End Sub

    Private Sub Packet_ClassesData(ByVal data() As Byte)
        Dim i As Integer
        Dim z As Integer, X As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SClassesData Then Exit Sub

        ' Max classes
        Max_Classes = Buffer.ReadInteger
        ReDim Classes(0 To Max_Classes)

        SelectedChar = 1

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Trim(Buffer.ReadString)
                .Desc = Trim(Buffer.ReadString)

                ReDim .Vital(0 To Vitals.Count - 1)

                .Vital(Vitals.HP) = Buffer.ReadInteger
                .Vital(Vitals.MP) = Buffer.ReadInteger
                .Vital(Vitals.SP) = Buffer.ReadInteger

                ' get array size
                z = Buffer.ReadInteger
                ' redim array
                ReDim .MaleSprite(0 To z + 1)
                ' loop-receive data
                For X = 1 To z + 1
                    .MaleSprite(X) = Buffer.ReadInteger
                Next

                ' get array size
                z = Buffer.ReadInteger
                ' redim array
                ReDim .FemaleSprite(0 To z + 1)
                ' loop-receive data
                For X = 1 To z + 1
                    .FemaleSprite(X) = Buffer.ReadInteger
                Next

                ReDim .Stat(0 To Stats.Count - 1)

                .Stat(Stats.Strength) = Buffer.ReadInteger
                .Stat(Stats.Endurance) = Buffer.ReadInteger
                .Stat(Stats.Vitality) = Buffer.ReadInteger
                .Stat(Stats.Intelligence) = Buffer.ReadInteger
                .Stat(Stats.Luck) = Buffer.ReadInteger
                .Stat(Stats.Spirit) = Buffer.ReadInteger

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = Buffer.ReadInteger
                    .StartValue(q) = Buffer.ReadInteger
                Next

                .StartMap = Buffer.ReadInteger
                .StartX = Buffer.ReadInteger
                .StartY = Buffer.ReadInteger

                .BaseExp = Buffer.ReadInteger
            End With

        Next

        ReDim cmbclass(0 To Max_Classes)
        For i = 1 To Max_Classes
            cmbclass(i) = Classes(i).Name
        Next
        FrmMenu.DrawCharacter()
        newCharSprite = 1

        Buffer = Nothing
    End Sub

    Private Sub Packet_InGame(ByVal data() As Byte)
        InGame = True
        CanMoveNow = True
        GameInit()
    End Sub

    Private Sub Packet_PlayerInv(ByVal data() As Byte)
        Dim i As Integer
        Dim InvNum As Integer, Amount As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerInv Then Exit Sub

        For i = 1 To MAX_INV
            InvNum = Buffer.ReadInteger
            Amount = Buffer.ReadInteger
            SetPlayerInvItemNum(MyIndex, i, InvNum)
            SetPlayerInvItemValue(MyIndex, i, Amount)

            Player(MyIndex).RandInv(i).Prefix = Buffer.ReadString
            Player(MyIndex).RandInv(i).Suffix = Buffer.ReadString
            Player(MyIndex).RandInv(i).Rarity = Buffer.ReadInteger
            For n = 1 To Stats.Count - 1
                Player(MyIndex).RandInv(i).Stat(n) = Buffer.ReadInteger
            Next
            Player(MyIndex).RandInv(i).Damage = Buffer.ReadInteger
            Player(MyIndex).RandInv(i).Speed = Buffer.ReadInteger
        Next

        ' changes to inventory, need to clear any drop menu
        FrmMainGame.pnlCurrency.Visible = False
        FrmMainGame.txtCurrency.Text = ""
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerInvUpdate(ByVal data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerInvUpdate Then Exit Sub

        n = Buffer.ReadInteger
        SetPlayerInvItemNum(MyIndex, n, Buffer.ReadInteger)
        SetPlayerInvItemValue(MyIndex, n, Buffer.ReadInteger)

        Player(MyIndex).RandInv(n).Prefix = Buffer.ReadString
        Player(MyIndex).RandInv(n).Suffix = Buffer.ReadString
        Player(MyIndex).RandInv(n).Rarity = Buffer.ReadInteger
        For i = 1 To Stats.Count - 1
            Player(MyIndex).RandInv(n).Stat(i) = Buffer.ReadInteger
        Next
        Player(MyIndex).RandInv(n).Damage = Buffer.ReadInteger
        Player(MyIndex).RandInv(n).Speed = Buffer.ReadInteger

        ' changes, clear drop menu
        FrmMainGame.pnlCurrency.Visible = False
        FrmMainGame.txtCurrency.Text = ""
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerWornEquipment(ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer, n As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerWornEq Then Exit Sub

        For i = 1 To EquipmentType.Count - 1
            SetPlayerEquipment(MyIndex, Buffer.ReadInteger, i)
        Next

        For i = 1 To EquipmentType.Count - 1
            Player(MyIndex).RandEquip(i).Prefix = Buffer.ReadString
            Player(MyIndex).RandEquip(i).Suffix = Buffer.ReadString
            Player(MyIndex).RandEquip(i).Damage = Buffer.ReadInteger
            Player(MyIndex).RandEquip(i).Speed = Buffer.ReadInteger
            Player(MyIndex).RandEquip(i).Rarity = Buffer.ReadInteger

            For n = 1 To Stats.Count - 1
                Player(MyIndex).RandEquip(i).Stat(n) = Buffer.ReadInteger
            Next
        Next

        ' changes to inventory, need to clear any drop menu

        FrmMainGame.pnlCurrency.Visible = False
        FrmMainGame.txtCurrency.Text = ""
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerHP(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)
        If Buffer.ReadInteger <> ServerPackets.SPlayerHp Then Exit Sub

        Player(MyIndex).MaxHP = Buffer.ReadInteger

        SetPlayerVital(MyIndex, Vitals.HP, Buffer.ReadInteger)

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

        If Buffer.ReadInteger <> ServerPackets.SPlayerMp Then Exit Sub

        Player(MyIndex).MaxMP = Buffer.ReadInteger
        SetPlayerVital(MyIndex, Vitals.MP, Buffer.ReadInteger)

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

        If Buffer.ReadInteger <> ServerPackets.SPlayerSp Then Exit Sub

        Player(MyIndex).MaxSP = Buffer.ReadInteger
        SetPlayerVital(MyIndex, Vitals.SP, Buffer.ReadInteger)

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerStats(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim i As Integer
        Dim index As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerStats Then Exit Sub

        index = Buffer.ReadInteger
        For i = 1 To Stats.Count - 1
            SetPlayerStat(index, i, Buffer.ReadInteger)
        Next
        UpdateCharacterPanel = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerData(ByVal Data() As Byte)
        Dim i As Integer, X As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerData Then Exit Sub

        i = Buffer.ReadInteger
        SetPlayerName(i, Buffer.ReadString)
        SetPlayerClass(i, Buffer.ReadInteger)
        SetPlayerLevel(i, Buffer.ReadInteger)
        SetPlayerPOINTS(i, Buffer.ReadInteger)
        SetPlayerSprite(i, Buffer.ReadInteger)
        SetPlayerMap(i, Buffer.ReadInteger)
        SetPlayerX(i, Buffer.ReadInteger)
        SetPlayerY(i, Buffer.ReadInteger)
        SetPlayerDir(i, Buffer.ReadInteger)
        SetPlayerAccess(i, Buffer.ReadInteger)
        SetPlayerPK(i, Buffer.ReadInteger)

        For X = 1 To Stats.Count - 1
            SetPlayerStat(i, X, Buffer.ReadInteger)
        Next

        Player(i).InHouse = Buffer.ReadInteger

        For X = 0 To ResourceSkills.Count - 1
            Player(i).GatherSkills(X).SkillLevel = Buffer.ReadInteger
            Player(i).GatherSkills(X).SkillCurExp = Buffer.ReadInteger
            Player(i).GatherSkills(X).SkillNextLvlExp = Buffer.ReadInteger
        Next

        For X = 1 To MAX_RECIPE
            Player(i).RecipeLearned(X) = Buffer.ReadInteger
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
        Dim i As Integer, X As Integer, Y As Integer
        Dim Dir As Integer, n As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerMove Then Exit Sub

        i = Buffer.ReadInteger
        X = Buffer.ReadInteger
        Y = Buffer.ReadInteger
        Dir = Buffer.ReadInteger
        n = Buffer.ReadInteger

        SetPlayerX(i, X)
        SetPlayerY(i, Y)
        SetPlayerDir(i, Dir)
        Player(i).XOffset = 0
        Player(i).YOffset = 0
        Player(i).Moving = n

        Select Case GetPlayerDir(i)
            Case Direction.Up
                Player(i).YOffset = PIC_Y
            Case Direction.Down
                Player(i).YOffset = PIC_Y * -1
            Case Direction.Left
                Player(i).XOffset = PIC_X
            Case Direction.Right
                Player(i).XOffset = PIC_X * -1
        End Select

        'Debug.Print("Client-PlayerMove")

        Buffer = Nothing
    End Sub

    Private Sub Packet_NpcMove(ByVal Data() As Byte)
        Dim MapNpcNum As Integer
        Dim Movement As Integer
        Dim X As Integer, Y As Integer, Dir As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SNpcMove Then Exit Sub

        MapNpcNum = Buffer.ReadInteger
        X = Buffer.ReadInteger
        Y = Buffer.ReadInteger
        Dir = Buffer.ReadInteger
        Movement = Buffer.ReadInteger

        With MapNpc(MapNpcNum)
            .X = X
            .Y = Y
            .Dir = Dir
            .XOffset = 0
            .YOffset = 0
            .Moving = Movement

            Select Case .Dir
                Case Direction.Up
                    .YOffset = PIC_Y
                Case Direction.Down
                    .YOffset = PIC_Y * -1
                Case Direction.Left
                    .XOffset = PIC_X
                Case Direction.Right
                    .XOffset = PIC_X * -1
            End Select
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerDir(ByVal Data() As Byte)
        Dim Dir As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerDir Then Exit Sub

        i = Buffer.ReadInteger
        Dir = Buffer.ReadInteger

        SetPlayerDir(i, Dir)

        With Player(i)
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_NpcDir(ByVal Data() As Byte)
        Dim Dir As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SNpcDir Then Exit Sub

        i = Buffer.ReadInteger
        Dir = Buffer.ReadInteger

        With MapNpc(i)
            .Dir = Dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerXY(ByVal Data() As Byte)
        Dim X As Integer, Y As Integer, Dir As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerXY Then Exit Sub

        X = Buffer.ReadInteger
        Y = Buffer.ReadInteger
        Dir = Buffer.ReadInteger

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
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SAttack Then Exit Sub

        i = Buffer.ReadInteger

        ' Set player to attacking
        Player(i).Attacking = 1
        Player(i).AttackTimer = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_NpcAttack(ByVal Data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SNpcAttack Then Exit Sub

        i = Buffer.ReadInteger

        ' Set npc to attacking
        MapNpc(i).Attacking = 1
        MapNpc(i).AttackTimer = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_CheckMap(ByVal Data() As Byte)
        Dim X As Integer, Y As Integer, i As Integer
        Dim NeedMap As Byte
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SCheckForMap Then Exit Sub

        GettingMap = True

        ' Erase all players except self
        For i = 1 To TotalOnline 'MAX_PLAYERS
            If i <> MyIndex Then
                SetPlayerMap(i, 0)
            End If
        Next

        ' Erase all temporary tile values
        ClearTempTile()
        ClearMapNpcs()
        ClearMapItems()
        ClearBlood()
        ClearMap()

        ' Get map num
        X = Buffer.ReadInteger
        ' Get revision
        Y = Buffer.ReadInteger

        NeedMap = 1

        ' Either the revisions didn't match or we dont have the map, so we need it
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CNeedMap)
        Buffer.WriteInteger(NeedMap)
        SendData(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapData(ByVal Data() As Byte)
        Dim X As Integer, Y As Integer, i As Integer
        Dim MapNum As Integer, MusicFile As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapData Then Exit Sub

        Data = Buffer.ReadBytes(Buffer.Count - 4)
        Buffer = New ByteBuffer
        Buffer.WriteBytes(ArchaicIO.Compression.Decompress(Data))

        MapData = False

        ClearMap()

        SyncLock MapLock
            If Buffer.ReadInteger = 1 Then

                MapNum = Buffer.ReadInteger
                Map.Name = Trim(Buffer.ReadString)
                Map.Music = Trim(Buffer.ReadString)
                Map.Revision = Buffer.ReadInteger
                Map.Moral = Buffer.ReadInteger
                Map.tileset = Buffer.ReadInteger
                Map.Up = Buffer.ReadInteger
                Map.Down = Buffer.ReadInteger
                Map.Left = Buffer.ReadInteger
                Map.Right = Buffer.ReadInteger
                Map.BootMap = Buffer.ReadInteger
                Map.BootX = Buffer.ReadInteger
                Map.BootY = Buffer.ReadInteger
                Map.MaxX = Buffer.ReadInteger
                Map.MaxY = Buffer.ReadInteger
                Map.WeatherType = Buffer.ReadInteger
                Map.FogIndex = Buffer.ReadInteger
                Map.WeatherIntensity = Buffer.ReadInteger
                Map.FogAlpha = Buffer.ReadInteger
                Map.FogSpeed = Buffer.ReadInteger
                Map.HasMapTint = Buffer.ReadInteger
                Map.MapTintR = Buffer.ReadInteger
                Map.MapTintG = Buffer.ReadInteger
                Map.MapTintB = Buffer.ReadInteger
                Map.MapTintA = Buffer.ReadInteger
                Map.Instanced = Buffer.ReadInteger

                ReDim Map.Tile(0 To Map.MaxX, 0 To Map.MaxY)

                For X = 1 To MAX_MAP_NPCS
                    Map.Npc(X) = Buffer.ReadInteger
                Next

                For X = 0 To Map.MaxX
                    For Y = 0 To Map.MaxY
                        Map.Tile(X, Y).Data1 = Buffer.ReadInteger
                        Map.Tile(X, Y).Data2 = Buffer.ReadInteger
                        Map.Tile(X, Y).Data3 = Buffer.ReadInteger
                        Map.Tile(X, Y).DirBlock = Buffer.ReadInteger

                        ReDim Map.Tile(X, Y).Layer(0 To MapLayer.Count - 1)

                        For i = 0 To MapLayer.Count - 1
                            Map.Tile(X, Y).Layer(i).Tileset = Buffer.ReadInteger
                            Map.Tile(X, Y).Layer(i).X = Buffer.ReadInteger
                            Map.Tile(X, Y).Layer(i).Y = Buffer.ReadInteger
                            Map.Tile(X, Y).Layer(i).AutoTile = Buffer.ReadInteger
                        Next
                        Map.Tile(X, Y).Type = Buffer.ReadInteger
                    Next
                Next

                'Event Data!
                ResetEventdata()

                Map.EventCount = Buffer.ReadInteger

                If Map.EventCount > 0 Then
                    ReDim Map.Events(0 To Map.EventCount)
                    For i = 1 To Map.EventCount
                        With Map.Events(i)
                            .Name = Trim(Buffer.ReadString)
                            .Globals = Buffer.ReadInteger
                            .X = Buffer.ReadInteger
                            .Y = Buffer.ReadInteger
                            .PageCount = Buffer.ReadInteger
                        End With
                        If Map.Events(i).PageCount > 0 Then
                            ReDim Map.Events(i).Pages(0 To Map.Events(i).PageCount)
                            For X = 1 To Map.Events(i).PageCount
                                With Map.Events(i).Pages(X)
                                    .chkVariable = Buffer.ReadInteger
                                    .VariableIndex = Buffer.ReadInteger
                                    .VariableCondition = Buffer.ReadInteger
                                    .VariableCompare = Buffer.ReadInteger

                                    .chkSwitch = Buffer.ReadInteger
                                    .SwitchIndex = Buffer.ReadInteger
                                    .SwitchCompare = Buffer.ReadInteger

                                    .chkHasItem = Buffer.ReadInteger
                                    .HasItemIndex = Buffer.ReadInteger
                                    .HasItemAmount = Buffer.ReadInteger

                                    .chkSelfSwitch = Buffer.ReadInteger
                                    .SelfSwitchIndex = Buffer.ReadInteger
                                    .SelfSwitchCompare = Buffer.ReadInteger

                                    .GraphicType = Buffer.ReadInteger
                                    .Graphic = Buffer.ReadInteger
                                    .GraphicX = Buffer.ReadInteger
                                    .GraphicY = Buffer.ReadInteger
                                    .GraphicX2 = Buffer.ReadInteger
                                    .GraphicY2 = Buffer.ReadInteger

                                    .MoveType = Buffer.ReadInteger
                                    .MoveSpeed = Buffer.ReadInteger
                                    .MoveFreq = Buffer.ReadInteger

                                    .MoveRouteCount = Buffer.ReadInteger

                                    .IgnoreMoveRoute = Buffer.ReadInteger
                                    .RepeatMoveRoute = Buffer.ReadInteger

                                    If .MoveRouteCount > 0 Then
                                        ReDim Map.Events(i).Pages(X).MoveRoute(0 To .MoveRouteCount)
                                        For Y = 1 To .MoveRouteCount
                                            .MoveRoute(Y).Index = Buffer.ReadInteger
                                            .MoveRoute(Y).Data1 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data2 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data3 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data4 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data5 = Buffer.ReadInteger
                                            .MoveRoute(Y).Data6 = Buffer.ReadInteger
                                        Next
                                    End If

                                    .WalkAnim = Buffer.ReadInteger
                                    .DirFix = Buffer.ReadInteger
                                    .WalkThrough = Buffer.ReadInteger
                                    .ShowName = Buffer.ReadInteger
                                    .Trigger = Buffer.ReadInteger
                                    .CommandListCount = Buffer.ReadInteger

                                    .Position = Buffer.ReadInteger
                                    .Questnum = Buffer.ReadInteger

                                    .chkPlayerGender = Buffer.ReadInteger
                                End With

                                If Map.Events(i).Pages(X).CommandListCount > 0 Then
                                    ReDim Map.Events(i).Pages(X).CommandList(0 To Map.Events(i).Pages(X).CommandListCount)
                                    For Y = 1 To Map.Events(i).Pages(X).CommandListCount
                                        Map.Events(i).Pages(X).CommandList(Y).CommandCount = Buffer.ReadInteger
                                        Map.Events(i).Pages(X).CommandList(Y).ParentList = Buffer.ReadInteger
                                        If Map.Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                            ReDim Map.Events(i).Pages(X).CommandList(Y).Commands(0 To Map.Events(i).Pages(X).CommandList(Y).CommandCount)
                                            For z = 1 To Map.Events(i).Pages(X).CommandList(Y).CommandCount
                                                With Map.Events(i).Pages(X).CommandList(Y).Commands(z)
                                                    .Index = Buffer.ReadInteger
                                                    .Text1 = Trim(Buffer.ReadString)
                                                    .Text2 = Trim(Buffer.ReadString)
                                                    .Text3 = Trim(Buffer.ReadString)
                                                    .Text4 = Trim(Buffer.ReadString)
                                                    .Text5 = Trim(Buffer.ReadString)
                                                    .Data1 = Buffer.ReadInteger
                                                    .Data2 = Buffer.ReadInteger
                                                    .Data3 = Buffer.ReadInteger
                                                    .Data4 = Buffer.ReadInteger
                                                    .Data5 = Buffer.ReadInteger
                                                    .Data6 = Buffer.ReadInteger
                                                    .ConditionalBranch.CommandList = Buffer.ReadInteger
                                                    .ConditionalBranch.Condition = Buffer.ReadInteger
                                                    .ConditionalBranch.Data1 = Buffer.ReadInteger
                                                    .ConditionalBranch.Data2 = Buffer.ReadInteger
                                                    .ConditionalBranch.Data3 = Buffer.ReadInteger
                                                    .ConditionalBranch.ElseCommandList = Buffer.ReadInteger
                                                    .MoveRouteCount = Buffer.ReadInteger
                                                    If .MoveRouteCount > 0 Then
                                                        ReDim Preserve .MoveRoute(.MoveRouteCount)
                                                        For w = 1 To .MoveRouteCount
                                                            .MoveRoute(w).Index = Buffer.ReadInteger
                                                            .MoveRoute(w).Data1 = Buffer.ReadInteger
                                                            .MoveRoute(w).Data2 = Buffer.ReadInteger
                                                            .MoveRoute(w).Data3 = Buffer.ReadInteger
                                                            .MoveRoute(w).Data4 = Buffer.ReadInteger
                                                            .MoveRoute(w).Data5 = Buffer.ReadInteger
                                                            .MoveRoute(w).Data6 = Buffer.ReadInteger
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
                MapItem(i).Num = Buffer.ReadInteger
                MapItem(i).Value = Buffer.ReadInteger()
                MapItem(i).X = Buffer.ReadInteger()
                MapItem(i).Y = Buffer.ReadInteger()
            Next

            For i = 1 To MAX_MAP_NPCS
                MapNpc(i).Num = Buffer.ReadInteger()
                MapNpc(i).X = Buffer.ReadInteger()
                MapNpc(i).Y = Buffer.ReadInteger()
                MapNpc(i).Dir = Buffer.ReadInteger()
                MapNpc(i).Vital(Vitals.HP) = Buffer.ReadInteger()
                MapNpc(i).Vital(Vitals.MP) = Buffer.ReadInteger()
            Next

            If Buffer.ReadInteger = 1 Then
                Resource_Index = Buffer.ReadInteger
                Resources_Init = False

                If Resource_Index > 0 Then
                    ReDim MapResource(0 To Resource_Index)

                    For i = 0 To Resource_Index
                        MapResource(i).ResourceState = Buffer.ReadInteger
                        MapResource(i).X = Buffer.ReadInteger
                        MapResource(i).Y = Buffer.ReadInteger
                    Next

                    Resources_Init = True
                Else
                    ReDim MapResource(0 To 1)
                End If
            End If

            ClearTempTile()

            Buffer = Nothing

        End SyncLock

        InitAutotiles()

        MapData = True

        For i = 1 To Byte.MaxValue
            ClearActionMsg(i)
        Next

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
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNpcData Then Exit Sub

        For i = 1 To MAX_MAP_NPCS

            With MapNpc(i)
                .Num = Buffer.ReadInteger
                .X = Buffer.ReadInteger
                .Y = Buffer.ReadInteger
                .Dir = Buffer.ReadInteger
                .Vital(Vitals.HP) = Buffer.ReadInteger
                .Vital(Vitals.MP) = Buffer.ReadInteger
            End With

        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapNPCUpdate(ByVal Data() As Byte)
        Dim NpcNum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNpcUpdate Then Exit Sub

        NpcNum = Buffer.ReadInteger

        With MapNpc(NpcNum)
            .Num = Buffer.ReadInteger
            .X = Buffer.ReadInteger
            .Y = Buffer.ReadInteger
            .Dir = Buffer.ReadInteger
            .Vital(Vitals.HP) = Buffer.ReadInteger
            .Vital(Vitals.MP) = Buffer.ReadInteger
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapDone(ByVal data() As Byte)
        Dim i As Integer
        Dim MusicFile As String

        For i = 1 To Byte.MaxValue
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

        If Buffer.ReadInteger <> ServerPackets.SGlobalMsg Then Exit Sub

        'Msg = Trim(Buffer.ReadString)
        Msg = Trim(Buffer.ReadUnicodeString)

        Buffer = Nothing

        AddText(Msg, QColorType.GlobalColor)
    End Sub

    Private Sub Packet_MapMessage(ByVal Data() As Byte)
        Dim Msg As String
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapMsg Then Exit Sub

        'Msg = Trim(Buffer.ReadString)
        Msg = Trim(Buffer.ReadUnicodeString)

        Buffer = Nothing

        AddText(Msg, QColorType.BroadcastColor)

    End Sub

    Private Sub Packet_SpawnItem(ByVal Data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SSpawnItem Then Exit Sub

        i = Buffer.ReadInteger

        With MapItem(i)
            .Num = Buffer.ReadInteger
            .Value = Buffer.ReadInteger
            .X = Buffer.ReadInteger
            .Y = Buffer.ReadInteger
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerMessage(ByVal Data() As Byte)
        Dim Msg As String, colour As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerMsg Then Exit Sub

        'Msg = Trim(Buffer.ReadString)
        Msg = Trim(Buffer.ReadUnicodeString)

        colour = Buffer.ReadInteger
        Buffer = Nothing

        AddText(Msg, colour)
    End Sub

    Sub Packet_UpdateItem(ByVal data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateItem Then Exit Sub

        n = Buffer.ReadInteger

        ' Update the item
        Item(n).AccessReq = Buffer.ReadInteger()

        For i = 0 To Stats.Count - 1
            Item(n).Add_Stat(i) = Buffer.ReadInteger()
        Next

        Item(n).Animation = Buffer.ReadInteger()
        Item(n).BindType = Buffer.ReadInteger()
        Item(n).ClassReq = Buffer.ReadInteger()
        Item(n).Data1 = Buffer.ReadInteger()
        Item(n).Data2 = Buffer.ReadInteger()
        Item(n).Data3 = Buffer.ReadInteger()
        Item(n).TwoHanded = Buffer.ReadInteger()
        Item(n).LevelReq = Buffer.ReadInteger()
        Item(n).Mastery = Buffer.ReadInteger()
        Item(n).Name = Trim$(Buffer.ReadString())
        Item(n).Paperdoll = Buffer.ReadInteger()
        Item(n).Pic = Buffer.ReadInteger()
        Item(n).Price = Buffer.ReadInteger()
        Item(n).Rarity = Buffer.ReadInteger()
        Item(n).Speed = Buffer.ReadInteger()

        Item(n).Randomize = Buffer.ReadInteger()
        Item(n).RandomMin = Buffer.ReadInteger()
        Item(n).RandomMax = Buffer.ReadInteger()

        Item(n).Stackable = Buffer.ReadInteger()
        Item(n).Description = Trim$(Buffer.ReadString())

        For i = 0 To Stats.Count - 1
            Item(n).Stat_Req(i) = Buffer.ReadInteger()
        Next

        Item(n).Type = Buffer.ReadInteger()
        Item(n).SubType = Buffer.ReadInteger

        'Housing
        Item(n).FurnitureWidth = Buffer.ReadInteger()
        Item(n).FurnitureHeight = Buffer.ReadInteger()

        For a = 1 To 3
            For b = 1 To 3
                Item(n).FurnitureBlocks(a, b) = Buffer.ReadInteger()
                Item(n).FurnitureFringe(a, b) = Buffer.ReadInteger()
            Next
        Next

        Item(n).KnockBack = Buffer.ReadInteger()
        Item(n).KnockBackTiles = Buffer.ReadInteger()

        Item(n).Projectile = Buffer.ReadInteger()
        Item(n).Ammo = Buffer.ReadInteger()

        Buffer = Nothing
        ' changes to inventory, need to clear any drop menu

        FrmMainGame.pnlCurrency.Visible = False
        FrmMainGame.txtCurrency.Text = ""
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

    End Sub

    Sub Packet_SpawnNPC(ByVal data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SSpawnNpc Then Exit Sub

        i = Buffer.ReadInteger

        With MapNpc(i)
            .Num = Buffer.ReadInteger
            .X = Buffer.ReadInteger
            .Y = Buffer.ReadInteger
            .Dir = Buffer.ReadInteger

            For i = 1 To Vitals.Count - 1
                .Vital(i) = Buffer.ReadInteger
            Next
            ' Client use only
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        Buffer = Nothing
    End Sub

    Sub Packet_NpcDead(ByVal data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SNpcDead Then Exit Sub

        i = Buffer.ReadInteger
        ClearMapNpc(i)

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateNPC(ByVal data() As Byte)
        Dim i As Integer, x As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateNpc Then Exit Sub

        i = Buffer.ReadInteger
        ' Update the Npc
        Npc(i).Animation = Buffer.ReadInteger()
        Npc(i).AttackSay = Trim(Buffer.ReadString())
        Npc(i).Behaviour = Buffer.ReadInteger()
        ReDim Npc(i).DropChance(5)
        ReDim Npc(i).DropItem(5)
        ReDim Npc(i).DropItemValue(5)
        For x = 1 To 5
            Npc(i).DropChance(x) = Buffer.ReadInteger()
            Npc(i).DropItem(x) = Buffer.ReadInteger()
            Npc(i).DropItemValue(x) = Buffer.ReadInteger()
        Next

        Npc(i).EXP = Buffer.ReadInteger()
        Npc(i).Faction = Buffer.ReadInteger()
        Npc(i).HP = Buffer.ReadInteger()
        Npc(i).Name = Trim(Buffer.ReadString())
        Npc(i).Range = Buffer.ReadInteger()
        Npc(i).SpawnSecs = Buffer.ReadInteger()
        Npc(i).Sprite = Buffer.ReadInteger()

        For i = 0 To Stats.Count - 1
            Npc(i).Stat(i) = Buffer.ReadInteger()
        Next

        Npc(i).QuestNum = Buffer.ReadInteger()

        For x = 1 To MAX_NPC_SKILLS
            Npc(i).Skill(x) = Buffer.ReadInteger()
        Next

        Npc(i).Level = Buffer.ReadInteger()
        Npc(i).Damage = Buffer.ReadInteger()

        If Npc(i).AttackSay Is Nothing Then Npc(i).AttackSay = ""
        If Npc(i).Name Is Nothing Then Npc(i).Name = ""

        Buffer = Nothing
    End Sub

    Sub Packet_MapKey(ByVal data() As Byte)
        Dim n As Integer, X As Integer, Y As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SMapKey Then Exit Sub

        X = Buffer.ReadInteger
        Y = Buffer.ReadInteger
        n = Buffer.ReadInteger
        TempTile(X, Y).DoorOpen = n

        Buffer = Nothing
    End Sub

    Sub Packet_EditMap(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SEditMap Then Exit Sub

        InitMapEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateShop(ByVal data() As Byte)
        Dim shopnum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateShop Then Exit Sub

        shopnum = Buffer.ReadInteger

        Shop(shopnum).BuyRate = Buffer.ReadInteger()
        Shop(shopnum).Name = Trim(Buffer.ReadString())
        Shop(shopnum).Face = Buffer.ReadInteger()

        For i = 0 To MAX_TRADES
            Shop(shopnum).TradeItem(i).CostItem = Buffer.ReadInteger()
            Shop(shopnum).TradeItem(i).CostValue = Buffer.ReadInteger()
            Shop(shopnum).TradeItem(i).Item = Buffer.ReadInteger()
            Shop(shopnum).TradeItem(i).ItemValue = Buffer.ReadInteger()
        Next

        If Shop(shopnum).Name Is Nothing Then Shop(shopnum).Name = ""

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateSkill(ByVal data() As Byte)
        Dim skillnum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateSkill Then Exit Sub

        skillnum = Buffer.ReadInteger

        Skill(skillnum).AccessReq = Buffer.ReadInteger()
        Skill(skillnum).AoE = Buffer.ReadInteger()
        Skill(skillnum).CastAnim = Buffer.ReadInteger()
        Skill(skillnum).CastTime = Buffer.ReadInteger()
        Skill(skillnum).CDTime = Buffer.ReadInteger()
        Skill(skillnum).ClassReq = Buffer.ReadInteger()
        Skill(skillnum).Dir = Buffer.ReadInteger()
        Skill(skillnum).Duration = Buffer.ReadInteger()
        Skill(skillnum).Icon = Buffer.ReadInteger()
        Skill(skillnum).Interval = Buffer.ReadInteger()
        Skill(skillnum).IsAoE = Buffer.ReadInteger()
        Skill(skillnum).LevelReq = Buffer.ReadInteger()
        Skill(skillnum).Map = Buffer.ReadInteger()
        Skill(skillnum).MPCost = Buffer.ReadInteger()
        Skill(skillnum).Name = Trim(Buffer.ReadString())
        Skill(skillnum).Range = Buffer.ReadInteger()
        Skill(skillnum).SkillAnim = Buffer.ReadInteger()
        Skill(skillnum).StunDuration = Buffer.ReadInteger()
        Skill(skillnum).Type = Buffer.ReadInteger()
        Skill(skillnum).Vital = Buffer.ReadInteger()
        Skill(skillnum).X = Buffer.ReadInteger()
        Skill(skillnum).Y = Buffer.ReadInteger()

        Skill(skillnum).IsProjectile = Buffer.ReadInteger()
        Skill(skillnum).Projectile = Buffer.ReadInteger()

        Skill(skillnum).KnockBack = Buffer.ReadInteger()
        Skill(skillnum).KnockBackTiles = Buffer.ReadInteger()

        If Skill(skillnum).Name Is Nothing Then Skill(skillnum).Name = ""

        Buffer = Nothing

    End Sub

    Sub Packet_Skills(ByVal data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SSkills Then Exit Sub

        For i = 1 To MAX_PLAYER_SKILLS
            PlayerSkills(i) = Buffer.ReadInteger
        Next

        Buffer = Nothing
    End Sub

    Sub Packet_LeftMap(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        ' Confirm it is the right packet
        If Buffer.ReadInteger <> ServerPackets.SLeftMap Then Exit Sub

        ClearPlayer(Buffer.ReadInteger)

        Buffer = Nothing
    End Sub

    Private Sub Packet_ResourceCache(ByVal Data() As Byte)
        Dim i As Integer
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SResourceCache Then Exit Sub

        Resource_Index = Buffer.ReadInteger
        Resources_Init = False

        If Resource_Index > 0 Then
            ReDim Preserve MapResource(0 To Resource_Index)

            For i = 0 To Resource_Index
                MapResource(i).ResourceState = Buffer.ReadInteger
                MapResource(i).X = Buffer.ReadInteger
                MapResource(i).Y = Buffer.ReadInteger
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
        Dim X As Integer, Y As Integer
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SDoorAnimation Then Exit Sub

        X = buffer.ReadInteger
        Y = buffer.ReadInteger
        With TempTile(X, Y)
            .DoorFrame = 1
            .DoorAnimate = 1 ' 0 = nothing| 1 = opening | 2 = closing
            .DoorTimer = GetTickCount()
        End With

        buffer = Nothing
    End Sub

    Private Sub Packet_ActionMessage(ByVal data() As Byte)
        Dim X As Integer, Y As Integer, message As String, color As Integer, tmpType As Integer
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(data)

        If buffer.ReadInteger <> ServerPackets.SActionMsg Then Exit Sub

        message = Trim(buffer.ReadunicodeString)
        color = buffer.ReadInteger
        tmpType = buffer.ReadInteger
        X = buffer.ReadInteger
        Y = buffer.ReadInteger

        buffer = Nothing

        CreateActionMsg(message, color, tmpType, X, Y)
    End Sub

    Private Sub Packet_UpdateResource(ByVal Data() As Byte)
        Dim ResourceNum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateResource Then Exit Sub

        ResourceNum = Buffer.ReadInteger

        Resource(ResourceNum).Animation = Buffer.ReadInteger()
        Resource(ResourceNum).EmptyMessage = Trim(Buffer.ReadString())
        Resource(ResourceNum).ExhaustedImage = Buffer.ReadInteger()
        Resource(ResourceNum).Health = Buffer.ReadInteger()
        Resource(ResourceNum).ExpReward = Buffer.ReadInteger()
        Resource(ResourceNum).ItemReward = Buffer.ReadInteger()
        Resource(ResourceNum).Name = Trim(Buffer.ReadString())
        Resource(ResourceNum).ResourceImage = Buffer.ReadInteger()
        Resource(ResourceNum).ResourceType = Buffer.ReadInteger()
        Resource(ResourceNum).RespawnTime = Buffer.ReadInteger()
        Resource(ResourceNum).SuccessMessage = Trim(Buffer.ReadString())
        Resource(ResourceNum).LvlRequired = Buffer.ReadInteger()
        Resource(ResourceNum).ToolRequired = Buffer.ReadInteger()
        Resource(ResourceNum).Walkthrough = Buffer.ReadInteger()

        If Resource(ResourceNum).Name Is Nothing Then Resource(ResourceNum).Name = ""
        If Resource(ResourceNum).EmptyMessage Is Nothing Then Resource(ResourceNum).EmptyMessage = ""
        If Resource(ResourceNum).SuccessMessage Is Nothing Then Resource(ResourceNum).SuccessMessage = ""

        Buffer = Nothing
    End Sub

    Private Sub Packet_PlayerExp(ByVal Data() As Byte)
        Dim index As Integer, TNL As Integer
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SPlayerEXP Then Exit Sub

        index = Buffer.ReadInteger
        SetPlayerExp(index, Buffer.ReadInteger)
        TNL = Buffer.ReadInteger

        If TNL = 0 Then TNL = 1
        NextlevelExp = TNL

        Buffer = Nothing
    End Sub

    Private Sub Packet_Blood(ByVal Data() As Byte)
        Dim X As Integer, Y As Integer, Sprite As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SBlood Then Exit Sub

        X = Buffer.ReadInteger
        Y = Buffer.ReadInteger

        Buffer = Nothing

        ' randomise sprite
        Sprite = Rand(1, 3)

        BloodIndex = BloodIndex + 1
        If BloodIndex >= Byte.MaxValue Then BloodIndex = 1

        With Blood(BloodIndex)
            .X = X
            .Y = Y
            .Sprite = Sprite
            .Timer = GetTickCount()
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_UpdateAnimation(ByVal Data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateAnimation Then Exit Sub

        n = Buffer.ReadInteger
        ' Update the Animation
        For i = 0 To UBound(Animation(n).Frames)
            Animation(n).Frames(i) = Buffer.ReadInteger()
        Next

        For i = 0 To UBound(Animation(n).LoopCount)
            Animation(n).LoopCount(i) = Buffer.ReadInteger()
        Next

        For i = 0 To UBound(Animation(n).looptime)
            Animation(n).looptime(i) = Buffer.ReadInteger()
        Next

        Animation(n).Name = Trim(Buffer.ReadString())

        If Animation(n).Name Is Nothing Then Animation(n).Name = ""

        For i = 0 To UBound(Animation(n).Sprite)
            Animation(n).Sprite(i) = Buffer.ReadInteger()
        Next
        Buffer = Nothing
    End Sub

    Private Sub Packet_Animation(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SAnimation Then Exit Sub

        AnimationIndex = AnimationIndex + 1
        If AnimationIndex >= Byte.MaxValue Then AnimationIndex = 1

        With AnimInstance(AnimationIndex)
            .Animation = Buffer.ReadInteger
            .X = Buffer.ReadInteger
            .Y = Buffer.ReadInteger
            .LockType = Buffer.ReadInteger
            .lockindex = Buffer.ReadInteger
            .Used(0) = True
            .Used(1) = True
        End With

        Buffer = Nothing
    End Sub

    Private Sub Packet_NPCVitals(ByVal Data() As Byte)
        Dim MapNpcNum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNpcVitals Then Exit Sub

        MapNpcNum = Buffer.ReadInteger
        For i = 1 To Vitals.Count - 1
            MapNpc(MapNpcNum).Vital(i) = Buffer.ReadInteger
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_Cooldown(ByVal Data() As Byte)
        Dim slot As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SCooldown Then Exit Sub

        slot = Buffer.ReadInteger
        SkillCD(slot) = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_ClearSkillBuffer(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SClearSkillBuffer Then Exit Sub

        SkillBuffer = 0
        SkillBufferTimer = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_SayMessage(ByVal Data() As Byte)
        Dim Access As Integer, Name As String, message As String
        'Dim colour As Integer
        Dim Header As String, PK As Integer
        'Dim saycolour As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SSayMsg Then Exit Sub

        Name = Trim(Buffer.ReadString)
        Access = Buffer.ReadInteger
        PK = Buffer.ReadInteger
        'message = Trim(Buffer.ReadString)
        message = Trim(Buffer.ReadUnicodeString)
        Header = Trim(Buffer.ReadString)

        AddText(Header & Name & ": " & message, QColorType.SayColor)

        Buffer = Nothing
    End Sub

    Private Sub Packet_OpenShop(ByVal Data() As Byte)
        Dim shopnum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SOpenShop Then Exit Sub

        shopnum = Buffer.ReadInteger

        NeedToOpenShop = True
        NeedToOpenShopNum = shopnum

        Buffer = Nothing
    End Sub

    Private Sub Packet_ResetShopAction(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SResetShopAction Then Exit Sub

        ShopAction = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_Stunned(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SStunned Then Exit Sub

        StunDuration = Buffer.ReadInteger

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapWornEquipment(ByVal Data() As Byte)
        Dim playernum As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapWornEq Then Exit Sub

        playernum = Buffer.ReadInteger
        SetPlayerEquipment(playernum, Buffer.ReadInteger, EquipmentType.Armor)
        SetPlayerEquipment(playernum, Buffer.ReadInteger, EquipmentType.Weapon)
        SetPlayerEquipment(playernum, Buffer.ReadInteger, EquipmentType.Helmet)
        SetPlayerEquipment(playernum, Buffer.ReadInteger, EquipmentType.Shield)
        SetPlayerEquipment(playernum, Buffer.ReadInteger, EquipmentType.Shoes)
        SetPlayerEquipment(playernum, Buffer.ReadInteger, EquipmentType.Gloves)

        Buffer = Nothing
    End Sub

    Private Sub Packet_OpenBank(ByVal Data() As Byte)
        Dim i As Integer, x As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SBank Then Exit Sub

        For i = 1 To MAX_BANK
            Bank.Item(i).Num = Buffer.ReadInteger
            Bank.Item(i).Value = Buffer.ReadInteger

            Bank.ItemRand(i).Prefix = Buffer.ReadString
            Bank.ItemRand(i).Suffix = Buffer.ReadString
            Bank.ItemRand(i).Rarity = Buffer.ReadInteger
            Bank.ItemRand(i).Damage = Buffer.ReadInteger
            Bank.ItemRand(i).Speed = Buffer.ReadInteger

            For x = 1 To Stats.Count - 1
                Bank.ItemRand(i).Stat(x) = Buffer.ReadInteger
            Next
        Next

        NeedToOpenBank = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_ClearTradeTimer(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SClearTradeTimer Then Exit Sub

        TradeRequest = False
        TradeTimer = 0

        Buffer = Nothing
    End Sub

    Private Sub Packet_TradeInvite(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, requester As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.STradeInvite Then Exit Sub

        requester = Buffer.ReadInteger

        DialogType = DIALOGUE_TYPE_TRADE

        DialogMsg1 = Trim$(Player(requester).Name) & " invites you to a trade!"

        UpdateDialog = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_Trade(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.STrade Then Exit Sub

        NeedToOpenTrade = True
        Buffer.ReadInteger()
        Tradername = Trim(Buffer.ReadString)
        pnlTradeVisible = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_CloseTrade(ByVal Data() As Byte)
        NeedtoCloseTrade = True
    End Sub

    Private Sub Packet_TradeUpdate(ByVal Data() As Byte)
        Dim datatype As Integer
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ServerPackets.STradeUpdate Then Exit Sub

        datatype = buffer.ReadInteger

        If datatype = 0 Then ' ours!
            For i = 1 To MAX_INV
                TradeYourOffer(i).Num = buffer.ReadInteger
                TradeYourOffer(i).Value = buffer.ReadInteger
            Next
            YourWorth = "Total Worth: " & buffer.ReadInteger & "g"
        ElseIf datatype = 1 Then 'theirs
            For i = 1 To MAX_INV
                TradeTheirOffer(i).Num = buffer.ReadInteger
                TradeYourOffer(i).Value = buffer.ReadInteger
            Next
            TheirWorth = "Total Worth: " & buffer.ReadInteger & "g"
        End If

        NeedtoUpdateTrade = True

        buffer = Nothing
    End Sub

    Private Sub Packet_TradeStatus(ByVal Data() As Byte)
        Dim tradestatus As Integer
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ServerPackets.STradeStatus Then Exit Sub

        tradestatus = buffer.ReadInteger

        Select Case tradestatus
            Case 0 ' clear
                'frmMainGame.lblTradeStatus.Text = ""
            Case 1 ' they've accepted
                AddText("Other player has accepted.", ColorType.White)
            Case 2 ' you've accepted
                AddText("Waiting for other player to accept.", ColorType.White)
        End Select

        buffer = Nothing
    End Sub

    Private Sub Packet_GameData(ByVal Data() As Byte)
        Dim n As Integer, i As Integer, z As Integer, x As Integer, a As Integer, b As Integer
        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ServerPackets.SGameData Then Exit Sub

        Data = buffer.ReadBytes(buffer.Count - 4)
        Data = ArchaicIO.Compression.Decompress(Data)
        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        '\\\Read Class Data\\\

        ' Max classes
        Max_Classes = buffer.ReadInteger
        ReDim Classes(0 To Max_Classes)

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Vital(0 To Vitals.Count - 1)
        Next

        For i = 1 To Max_Classes

            With Classes(i)
                .Name = Trim(buffer.ReadString)
                .Desc = Trim$(buffer.ReadString)

                .Vital(Vitals.HP) = buffer.ReadInteger
                .Vital(Vitals.MP) = buffer.ReadInteger
                .Vital(Vitals.SP) = buffer.ReadInteger

                ' get array size
                z = buffer.ReadInteger
                ' redim array
                ReDim .MaleSprite(0 To z)
                ' loop-receive data
                For x = 0 To z
                    .MaleSprite(x) = buffer.ReadInteger
                Next

                ' get array size
                z = buffer.ReadInteger
                ' redim array
                ReDim .FemaleSprite(0 To z)
                ' loop-receive data
                For x = 0 To z
                    .FemaleSprite(x) = buffer.ReadInteger
                Next

                .Stat(Stats.Strength) = buffer.ReadInteger
                .Stat(Stats.Endurance) = buffer.ReadInteger
                .Stat(Stats.Vitality) = buffer.ReadInteger
                .Stat(Stats.Intelligence) = buffer.ReadInteger
                .Stat(Stats.Luck) = buffer.ReadInteger
                .Stat(Stats.Spirit) = buffer.ReadInteger

                ReDim .StartItem(5)
                ReDim .StartValue(5)
                For q = 1 To 5
                    .StartItem(q) = buffer.ReadInteger
                    .StartValue(q) = buffer.ReadInteger
                Next

                .StartMap = buffer.ReadInteger
                .StartX = buffer.ReadInteger
                .StartY = buffer.ReadInteger

                .BaseExp = buffer.ReadInteger
            End With

        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\End Read Class Data\\\

        '\\\Read Item Data\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            ' Update the item
            Item(n).AccessReq = buffer.ReadInteger()

            For z = 0 To Stats.Count - 1
                Item(n).Add_Stat(z) = buffer.ReadInteger()
            Next

            Item(n).Animation = buffer.ReadInteger()
            Item(n).BindType = buffer.ReadInteger()
            Item(n).ClassReq = buffer.ReadInteger()
            Item(n).Data1 = buffer.ReadInteger()
            Item(n).Data2 = buffer.ReadInteger()
            Item(n).Data3 = buffer.ReadInteger()
            Item(n).TwoHanded = buffer.ReadInteger()
            Item(n).LevelReq = buffer.ReadInteger()
            Item(n).Mastery = buffer.ReadInteger()
            Item(n).Name = Trim$(buffer.ReadString())
            Item(n).Paperdoll = buffer.ReadInteger()
            Item(n).Pic = buffer.ReadInteger()
            Item(n).Price = buffer.ReadInteger()
            Item(n).Rarity = buffer.ReadInteger()
            Item(n).Speed = buffer.ReadInteger()

            Item(n).Randomize = buffer.ReadInteger()
            Item(n).RandomMin = buffer.ReadInteger()
            Item(n).RandomMax = buffer.ReadInteger()

            Item(n).Stackable = buffer.ReadInteger()
            Item(n).Description = Trim$(buffer.ReadString())

            For z = 0 To Stats.Count - 1
                Item(n).Stat_Req(z) = buffer.ReadInteger()
            Next

            Item(n).Type = buffer.ReadInteger()
            Item(n).SubType = buffer.ReadInteger

            Item(n).ItemLevel = buffer.ReadInteger

            'Housing
            Item(n).FurnitureWidth = buffer.ReadInteger()
            Item(n).FurnitureHeight = buffer.ReadInteger()

            For a = 1 To 3
                For b = 1 To 3
                    Item(n).FurnitureBlocks(a, b) = buffer.ReadInteger()
                    Item(n).FurnitureFringe(a, b) = buffer.ReadInteger()
                Next
            Next

            Item(n).KnockBack = buffer.ReadInteger()
            Item(n).KnockBackTiles = buffer.ReadInteger()

            Item(n).Projectile = buffer.ReadInteger()
            Item(n).Ammo = buffer.ReadInteger()
        Next

        ' changes to inventory, need to clear any drop menu

        FrmMainGame.pnlCurrency.Visible = False
        FrmMainGame.txtCurrency.Text = ""
        tmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Item Data\\\\\\\

        '\\\Read Animation Data\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger
            ' Update the Animation
            For z = 0 To UBound(Animation(n).Frames)
                Animation(n).Frames(z) = buffer.ReadInteger()
            Next

            For z = 0 To UBound(Animation(n).LoopCount)
                Animation(n).LoopCount(z) = buffer.ReadInteger()
            Next

            For z = 0 To UBound(Animation(n).looptime)
                Animation(n).looptime(z) = buffer.ReadInteger()
            Next

            Animation(n).Name = Trim(buffer.ReadString())

            If Animation(n).Name Is Nothing Then Animation(n).Name = ""

            For z = 0 To UBound(Animation(n).Sprite)
                Animation(n).Sprite(z) = buffer.ReadInteger()
            Next
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Animation Data\\\\\\\

        '\\\Read NPC Data\\\\\\\
        x = buffer.ReadInteger
        For i = 1 To x
            n = buffer.ReadInteger
            ' Update the Npc
            Npc(n).Animation = buffer.ReadInteger()
            Npc(n).AttackSay = Trim(buffer.ReadString())
            Npc(n).Behaviour = buffer.ReadInteger()
            For z = 1 To 5
                Npc(n).DropChance(z) = buffer.ReadInteger()
                Npc(n).DropItem(z) = buffer.ReadInteger()
                Npc(n).DropItemValue(z) = buffer.ReadInteger()
            Next

            Npc(n).EXP = buffer.ReadInteger()
            Npc(n).Faction = buffer.ReadInteger()
            Npc(n).HP = buffer.ReadInteger()
            Npc(n).Name = Trim(buffer.ReadString())
            Npc(n).Range = buffer.ReadInteger()
            Npc(n).SpawnSecs = buffer.ReadInteger()
            Npc(n).Sprite = buffer.ReadInteger()

            For z = 0 To Stats.Count - 1
                Npc(n).Stat(z) = buffer.ReadInteger()
            Next

            Npc(n).QuestNum = buffer.ReadInteger()

            ReDim Npc(n).Skill(MAX_NPC_SKILLS)
            For z = 1 To MAX_NPC_SKILLS
                Npc(n).Skill(z) = buffer.ReadInteger()
            Next

            Npc(i).Level = buffer.ReadInteger()
            Npc(i).Damage = buffer.ReadInteger()

            If Npc(n).AttackSay Is Nothing Then Npc(n).AttackSay = ""
            If Npc(n).Name Is Nothing Then Npc(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read NPC Data\\\\\\\

        '\\\Read Shop Data\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            Shop(n).BuyRate = buffer.ReadInteger()
            Shop(n).Name = Trim(buffer.ReadString())
            Shop(n).Face = buffer.ReadInteger()

            For z = 0 To MAX_TRADES
                Shop(n).TradeItem(z).CostItem = buffer.ReadInteger()
                Shop(n).TradeItem(z).CostValue = buffer.ReadInteger()
                Shop(n).TradeItem(z).Item = buffer.ReadInteger()
                Shop(n).TradeItem(z).ItemValue = buffer.ReadInteger()
            Next

            If Shop(n).Name Is Nothing Then Shop(n).Name = ""
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        '\\\End Read Shop Data\\\\\\\

        '\\\Read Skills Data\\\\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            Skill(n).AccessReq = buffer.ReadInteger()
            Skill(n).AoE = buffer.ReadInteger()
            Skill(n).CastAnim = buffer.ReadInteger()
            Skill(n).CastTime = buffer.ReadInteger()
            Skill(n).CDTime = buffer.ReadInteger()
            Skill(n).ClassReq = buffer.ReadInteger()
            Skill(n).Dir = buffer.ReadInteger()
            Skill(n).Duration = buffer.ReadInteger()
            Skill(n).Icon = buffer.ReadInteger()
            Skill(n).Interval = buffer.ReadInteger()
            Skill(n).IsAoE = buffer.ReadInteger()
            Skill(n).LevelReq = buffer.ReadInteger()
            Skill(n).Map = buffer.ReadInteger()
            Skill(n).MPCost = buffer.ReadInteger()
            Skill(n).Name = Trim(buffer.ReadString())
            Skill(n).Range = buffer.ReadInteger()
            Skill(n).SkillAnim = buffer.ReadInteger()
            Skill(n).StunDuration = buffer.ReadInteger()
            Skill(n).Type = buffer.ReadInteger()
            Skill(n).Vital = buffer.ReadInteger()
            Skill(n).X = buffer.ReadInteger()
            Skill(n).Y = buffer.ReadInteger()

            Skill(n).IsProjectile = buffer.ReadInteger()
            Skill(n).Projectile = buffer.ReadInteger()

            Skill(n).KnockBack = buffer.ReadInteger()
            Skill(n).KnockBackTiles = buffer.ReadInteger()

            If Skill(n).Name Is Nothing Then Skill(n).Name = ""
        Next

        i = 0
        x = 0
        n = 0
        z = 0

        '\\\End Read Skills Data\\\\\\\\\\

        '\\\Read Resource Data\\\\\\\\\\\\
        x = buffer.ReadInteger

        For i = 1 To x
            n = buffer.ReadInteger

            Resource(n).Animation = buffer.ReadInteger()
            Resource(n).EmptyMessage = Trim(buffer.ReadString())
            Resource(n).ExhaustedImage = buffer.ReadInteger()
            Resource(n).Health = buffer.ReadInteger()
            Resource(n).ExpReward = buffer.ReadInteger()
            Resource(n).ItemReward = buffer.ReadInteger()
            Resource(n).Name = Trim(buffer.ReadString())
            Resource(n).ResourceImage = buffer.ReadInteger()
            Resource(n).ResourceType = buffer.ReadInteger()
            Resource(n).RespawnTime = buffer.ReadInteger()
            Resource(n).SuccessMessage = Trim(buffer.ReadString())
            Resource(n).LvlRequired = buffer.ReadInteger()
            Resource(n).ToolRequired = buffer.ReadInteger()
            Resource(n).Walkthrough = buffer.ReadInteger()

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

        If Buffer.ReadInteger <> ServerPackets.STarget Then Exit Sub

        myTarget = Buffer.ReadInteger
        myTargetType = Buffer.ReadInteger

        Buffer = Nothing
    End Sub

    Private Sub Packet_Mapreport(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, I As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapReport Then Exit Sub

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

        If Buffer.ReadInteger <> ServerPackets.SAdmin Then Exit Sub

        Adminvisible = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_MapNames(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, I As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SMapNames Then Exit Sub

        For I = 1 To MAX_MAPS
            MapNames(I) = Trim(Buffer.ReadString())
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_Hotbar(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer, i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SHotbar Then Exit Sub

        For i = 1 To MAX_HOTBAR
            Player(MyIndex).Hotbar(i).Slot = Buffer.ReadInteger
            Player(MyIndex).Hotbar(i).sType = Buffer.ReadInteger
        Next

        Buffer = Nothing
    End Sub

    Private Sub Packet_Critical(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SCritical Then Exit Sub

        ShakeTimerEnabled = True
        ShakeTimer = GetTickCount()

        Buffer = Nothing
    End Sub

    Private Sub Packet_News(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SNews Then Exit Sub

        GAME_NAME = Buffer.ReadString
        News = Buffer.ReadString

        UpdateNews = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_RClick(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SrClick Then Exit Sub

        ShowRClick = True

        Buffer = Nothing
    End Sub

    Private Sub Packet_TotalOnline(ByVal Data() As Byte)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.STotalOnline Then Exit Sub

        TotalOnline = Buffer.ReadInteger

        Buffer = Nothing
    End Sub

    Private Sub Packet_Emote(ByVal Data() As Byte)
        Dim buffer As ByteBuffer
        Dim index As Integer, emote As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ServerPackets.SEmote Then Exit Sub

        index = buffer.ReadInteger
        emote = buffer.ReadInteger

        With Player(index)
            .Emote = emote
            .EmoteTimer = GetTickCount() + 5000
        End With

        buffer = Nothing

    End Sub

    Private Sub Packet_ChatBubble(ByVal Data() As Byte)
        Dim buffer As ByteBuffer
        Dim targetType As Integer, target As Integer, Message As String, colour As Integer

        buffer = New ByteBuffer
        buffer.WriteBytes(Data)

        If buffer.ReadInteger <> ServerPackets.SChatBubble Then Exit Sub

        target = buffer.ReadInteger
        targetType = buffer.ReadInteger
        'Message = buffer.ReadString
        Message = Trim(buffer.ReadUnicodeString)
        colour = buffer.ReadInteger
        AddChatBubble(target, targetType, Message, colour)

        buffer = Nothing

    End Sub

    Private Sub Packet_LeftGame(ByVal Data() As Byte)
        Dim Buffer As New ByteBuffer

        Buffer.WriteBytes(Data)

        If Buffer.ReadInteger <> ServerPackets.SLeftGame Then Exit Sub

        DestroyGame()

        Buffer = Nothing
    End Sub
End Module