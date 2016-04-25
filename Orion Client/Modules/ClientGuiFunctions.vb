Imports System.Drawing
Imports System.Windows.Forms

Public Module ClientGuiFunctions
    Public Sub CheckGuiMove(ByVal X As Long, ByVal Y As Long)
        Dim eqNum As Long, InvNum As Long, spellslot As Long

        If InMapEditor Then Exit Sub
        ShowItemDesc = False
        'Charpanel
        If pnlCharacterVisible Then
            If X > CharWindowX And X < CharWindowX + CharPanelGFXInfo.width Then
                If Y > CharWindowY And Y < CharWindowY + CharPanelGFXInfo.height Then
                    eqNum = IsEqItem(X, Y)
                    If eqNum <> 0 Then
                        UpdateDescWindow(GetPlayerEquipment(MyIndex, eqNum), 0)
                        LastItemDesc = GetPlayerEquipment(MyIndex, eqNum) ' set it so you don't re-set values
                        ShowItemDesc = True
                        Exit Sub
                    Else
                        ShowItemDesc = False
                        LastItemDesc = 0 ' no item was last loaded
                    End If
                End If
            End If
        ElseIf pnlInventoryVisible Then
            If AboveInvpanel(X, Y) Then
                InvX = X
                InvY = Y

                If DragInvSlotNum > 0 Then
                    If InTrade Then Exit Sub
                    If InBank Or InShop Then Exit Sub
                    DrawInventoryItem(X, Y)
                    ShowItemDesc = False
                    LastItemDesc = 0 ' no item was last loaded
                Else
                    InvNum = IsInvItem(X, Y)

                    If InvNum <> 0 Then
                        ' exit out if we're offering that item
                        For i = 1 To MAX_INV
                            If TradeYourOffer(i).Num = InvNum Then
                                Exit Sub
                            End If
                        Next
                        UpdateDescWindow(GetPlayerInvItemNum(MyIndex, InvNum), GetPlayerInvItemValue(MyIndex, InvNum))
                        LastItemDesc = GetPlayerInvItemNum(MyIndex, InvNum) ' set it so you don't re-set values
                        ShowItemDesc = True
                        Exit Sub
                    Else
                        ShowItemDesc = False
                        LastItemDesc = 0 ' no item was last loaded
                    End If
                End If
            End If
        ElseIf pnlSpellsVisible = True Then
            If AboveSpellpanel(X, Y) Then
                SpellX = X
                SpellY = Y

                If DragSpellSlotNum > 0 Then
                    If InTrade Then Exit Sub
                    If InBank Or InShop Then Exit Sub
                    DrawSpellItem(X, Y)
                    LastSpellDesc = 0 ' no item was last loaded
                    ShowSpellDesc = False
                Else
                    spellslot = IsPlayerSpell(X, Y)

                    If spellslot <> 0 Then
                        UpdateSpellWindow(PlayerSpells(spellslot))
                        LastSpellDesc = PlayerSpells(spellslot)
                        ShowSpellDesc = True
                        Exit Sub
                    Else
                        LastSpellDesc = 0
                        ShowSpellDesc = False
                    End If
                End If

            End If
        Else
            ShowItemDesc = False
            ShowSpellDesc = False
        End If

    End Sub

    Public Function CheckGuiClick(ByVal X As Long, ByVal Y As Long, ByVal e As MouseEventArgs) As Boolean
        Dim EqNum As Long, InvNum As Long
        Dim spellnum As Long, hotbarslot As Long
        Dim Buffer As ByteBuffer

        CheckGuiClick = False
        If InMapEditor Then Exit Function

        'action panel
        If HUDVisible Then
            If AboveActionPanel(X, Y) Then
                ' left click
                If e.Button = MouseButtons.Left Then
                    'Inventory
                    If X > ActionPanelX + InvBtnX And X < ActionPanelX + InvBtnX + 32 And Y > ActionPanelY + InvBtnY And Y < ActionPanelY + InvBtnY + 32 Then
                        PlaySound("Click.ogg")
                        pnlInventoryVisible = Not pnlInventoryVisible
                        pnlCharacterVisible = False
                        pnlSpellsVisible = False
                        frmMainGame.pnlOptions.Visible = False
                        CheckGuiClick = True
                        'Skills
                    ElseIf X > ActionPanelX + SkillBtnX And X < ActionPanelX + SkillBtnX + 32 And Y > ActionPanelY + SkillBtnY And Y < ActionPanelY + SkillBtnY + 32 Then
                        PlaySound("Click.ogg")
                        Buffer = New ByteBuffer
                        Buffer.WriteLong(ClientPackets.CSpells)
                        SendData(Buffer.ToArray())
                        Buffer = Nothing
                        pnlSpellsVisible = Not pnlSpellsVisible
                        pnlInventoryVisible = False
                        pnlCharacterVisible = False
                        frmMainGame.pnlOptions.Visible = False
                        CheckGuiClick = True
                        'Char
                    ElseIf X > ActionPanelX + CharBtnX And X < ActionPanelX + CharBtnX + 32 And Y > ActionPanelY + CharBtnY And Y < ActionPanelY + CharBtnY + 32 Then
                        PlaySound("Click.ogg")
                        SendRequestPlayerData()
                        pnlCharacterVisible = Not pnlCharacterVisible
                        pnlInventoryVisible = False
                        pnlSpellsVisible = False
                        frmMainGame.pnlOptions.Visible = False
                        CheckGuiClick = True
                        'Quest
                    ElseIf X > ActionPanelX + QuestBtnX And X < ActionPanelX + QuestBtnX + 32 And Y > ActionPanelY + QuestBtnY And Y < ActionPanelY + QuestBtnY + 32 Then
                        UpdateQuestLog()
                        ' show the window
                        pnlInventoryVisible = False
                        pnlCharacterVisible = False
                        frmMainGame.pnlOptions.Visible = False
                        RefreshQuestLog()
                        frmMainGame.pnlQuestLog.Visible = Not frmMainGame.pnlQuestLog.Visible
                        frmMainGame.pnlQuestLog.BringToFront()
                        CheckGuiClick = True
                        'Trade
                    ElseIf X > ActionPanelX + TradeBtnX And X < ActionPanelX + TradeBtnX + 32 And Y > ActionPanelY + TradeBtnY And Y < ActionPanelY + TradeBtnY + 32 Then
                        PlaySound("Click.ogg")
                        AddText("Click on the player you wish to trade with.", TellColor)
                        TradeTimer = GetTickCount() + 10000 ' 10 seconds to click on the player
                        TradeRequest = True
                        CheckGuiClick = True
                        'Options
                    ElseIf X > ActionPanelX + OptBtnX And X < ActionPanelX + OptBtnX + 32 And Y > ActionPanelY + OptBtnY And Y < ActionPanelY + OptBtnY + 32 Then
                        PlaySound("Click.ogg")
                        pnlCharacterVisible = False
                        pnlInventoryVisible = False
                        pnlSpellsVisible = False
                        frmMainGame.pnlOptions.BringToFront()
                        frmMainGame.pnlOptions.Visible = Not frmMainGame.pnlOptions.Visible
                        CheckGuiClick = True
                        'Exit
                    ElseIf X > ActionPanelX + ExitBtnX And X < ActionPanelX + ExitBtnX + 32 And Y > ActionPanelY + ExitBtnY And Y < ActionPanelY + ExitBtnY + 32 Then
                        PlaySound("Click.ogg")
                        frmAdmin.Dispose()
                        DestroyGame()
                        CheckGuiClick = True
                    End If
                End If
            End If

            'hotbar
            If AboveHotbar(X, Y) Then

                hotbarslot = IsHotBarSlot(e.Location.X, e.Location.Y)

                If e.Button = MouseButtons.Left Then
                    If hotbarslot > 0 Then
                        spellnum = PlayerSpells(Player(MyIndex).Hotbar(hotbarslot).Slot)

                        If spellnum <> 0 Then
                            CastSpell(spellnum)
                        End If
                    End If
                ElseIf e.Button = MouseButtons.Right Then ' right click
                    If Player(MyIndex).Hotbar(hotbarslot).Slot > 0 Then
                        'forget hotbar skill
                        SendDeleteHotbar(IsHotBarSlot(e.Location.X, e.Location.Y))
                        CheckGuiClick = True
                    Else
                        Buffer = New ByteBuffer
                        Buffer.WriteLong(ClientPackets.CSpells)
                        SendData(Buffer.ToArray())
                        Buffer = Nothing
                        pnlSpellsVisible = True
                        AddText("Click on the skill you want to place here", TellColor)
                        SelSpellSlot = True
                        SelHotbarSlot = IsHotBarSlot(e.Location.X, e.Location.Y)
                    End If
                End If
                CheckGuiClick = True
            End If
        End If

        'Charpanel
        If pnlCharacterVisible Then
            If AboveCharpanel(X, Y) Then
                ' left click
                If e.Button = MouseButtons.Left Then
                    'first check for equip
                    EqNum = IsEqItem(X, Y)

                    If EqNum <> 0 Then
                        SendUnequip(EqNum)
                    End If

                    'lets see if they want to upgrade
                    'Strenght
                    If X > CharWindowX + StrengthUpgradeX And X < CharWindowX + StrengthUpgradeX + 10 And Y > CharWindowY + StrengthUpgradeY And Y < CharWindowY + StrengthUpgradeY + 10 Then
                        If Not GetPlayerPOINTS(MyIndex) = 0 Then
                            SendTrainStat(1)
                        End If
                    End If
                    'Endurance
                    If X > CharWindowX + EnduranceUpgradeX And X < CharWindowX + EnduranceUpgradeX + 10 And Y > CharWindowY + EnduranceUpgradeY And Y < CharWindowY + EnduranceUpgradeY + 10 Then
                        If Not GetPlayerPOINTS(MyIndex) = 0 Then
                            SendTrainStat(2)
                        End If
                    End If
                    'Vitality
                    If X > CharWindowX + VitalityUpgradeX And X < CharWindowX + VitalityUpgradeX + 10 And Y > CharWindowY + VitalityUpgradeY And Y < CharWindowY + VitalityUpgradeY + 10 Then
                        If Not GetPlayerPOINTS(MyIndex) = 0 Then
                            SendTrainStat(3)
                        End If
                    End If
                    'WillPower
                    If X > CharWindowX + LuckUpgradeX And X < CharWindowX + LuckUpgradeX + 10 And Y > CharWindowY + LuckUpgradeY And Y < CharWindowY + LuckUpgradeY + 10 Then
                        If Not GetPlayerPOINTS(MyIndex) = 0 Then
                            SendTrainStat(4)
                        End If
                    End If
                    'Intellect
                    If X > CharWindowX + IntellectUpgradeX And X < CharWindowX + IntellectUpgradeX + 10 And Y > CharWindowY + IntellectUpgradeY And Y < CharWindowY + IntellectUpgradeY + 10 Then
                        If Not GetPlayerPOINTS(MyIndex) = 0 Then
                            SendTrainStat(5)
                        End If
                    End If
                    'Spirit
                    If X > CharWindowX + SpiritUpgradeX And X < CharWindowX + SpiritUpgradeX + 10 And Y > CharWindowY + SpiritUpgradeY And Y < CharWindowY + SpiritUpgradeY + 10 Then
                        If Not GetPlayerPOINTS(MyIndex) = 0 Then
                            SendTrainStat(6)
                        End If
                    End If
                    CheckGuiClick = True
                End If
            End If

            'Inventory panel
        ElseIf pnlInventoryVisible Then
            If AboveInvpanel(X, Y) Then
                InvNum = IsInvItem(e.Location.X, e.Location.Y)

                If e.Button = MouseButtons.Left Then
                    If InvNum <> 0 Then
                        If InTrade Then Exit Function
                        If InBank Or InShop Then Exit Function

                        If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_FURNITURE Then
                            FurnitureSelected = InvNum
                            CheckGuiClick = True
                        End If

                    End If
                End If
            End If
            'Spell panel
            'ElseIf pnlSpellsVisible = True Then
            '    If AboveSpellpanel(X, Y) Then
            '        If SelSpellSlot = True Then
            '            spellnum = IsPlayerSpell(SpellX, SpellY)

            '            If spellnum <> 0 Then
            '                SendSetHotbarSkill(SelHotbarSlot, spellnum)
            '            End If
            '        End If
            '    End If

        End If

        If DialogPanelVisible Then
            'ok button
            If X > DialogPanelX + OkButtonX And X < DialogPanelX + OkButtonX + ButtonGFXInfo.width And Y > DialogPanelY + OkButtonY And Y < DialogPanelY + OkButtonY + ButtonGFXInfo.height Then
                VbKeyDown = False
                VbKeyUp = False
                VbKeyLeft = False
                VbKeyRight = False

                If DialogType = DIALOGUE_TYPE_BUYHOME Then 'house offer
                    SendBuyHouse(1)
                ElseIf DIALOGUE_TYPE_VISIT Then
                    SendVisit(1)
                ElseIf DIALOGUE_TYPE_PARTY Then
                    SendJoinParty()
                End If

                DialogPanelVisible = False
            End If
            'cancel button
            If X > DialogPanelX + CancelButtonX And X < DialogPanelX + CancelButtonX + ButtonGFXInfo.width And Y > DialogPanelY + CancelButtonY And Y < DialogPanelY + CancelButtonY + ButtonGFXInfo.height Then
                VbKeyDown = False
                VbKeyUp = False
                VbKeyLeft = False
                VbKeyRight = False

                If DialogType = DIALOGUE_TYPE_BUYHOME Then 'house offer declined
                    SendBuyHouse(0)
                ElseIf DIALOGUE_TYPE_VISIT Then 'visit declined
                    SendVisit(0)
                ElseIf DIALOGUE_TYPE_PARTY Then 'party declined
                    SendLeaveParty()
                End If

                DialogPanelVisible = False
            End If
            CheckGuiClick = True
        End If



    End Function

    Public Function CheckGuiDoubleClick(ByVal X As Long, ByVal Y As Long, ByVal e As MouseEventArgs) As Boolean
        Dim InvNum As Long, spellnum As Long
        Dim Value As Long
        Dim multiplier As Double
        Dim i As Long

        If pnlInventoryVisible Then
            If AboveInvpanel(X, Y) Then
                DragInvSlotNum = 0
                InvNum = IsInvItem(InvX, InvY)

                If InvNum <> 0 Then

                    ' are we in a shop?
                    If InShop > 0 Then
                        Select Case ShopAction
                            Case 0 ' nothing, give value
                                multiplier = Shop(InShop).BuyRate / 100
                                Value = Item(GetPlayerInvItemNum(MyIndex, InvNum)).Price * multiplier
                                If Value > 0 Then
                                    AddText("You can sell this item for " & Value & " gold.", TellColor)
                                Else
                                    AddText("The shop does not want this item.", AlertColor)
                                End If
                            Case 2 ' 2 = sell
                                SellItem(InvNum)
                        End Select

                        Exit Function
                    End If

                    ' in bank?
                    If InBank Then
                        If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Or Item(GetPlayerInvItemNum(MyIndex, InvNum)).Stackable = 1 Then
                            CurrencyMenu = 2 ' deposit
                            frmMainGame.lblCurrency.Text = "How many do you want to deposit?"
                            tmpCurrencyItem = InvNum
                            frmMainGame.txtCurrency.Text = vbNullString
                            frmMainGame.pnlCurrency.Visible = True
                            frmMainGame.txtCurrency.Focus()
                            Exit Function
                        End If
                        DepositItem(InvNum, 0)
                        Exit Function
                    End If

                    ' in trade?
                    If InTrade = True Then
                        ' exit out if we're offering that item
                        For i = 1 To MAX_INV
                            If TradeYourOffer(i).Num = InvNum Then
                                Exit Function
                            End If
                        Next
                        If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Or Item(GetPlayerInvItemNum(MyIndex, InvNum)).Stackable = 1 Then
                            ' currency shit here brah
                            Exit Function
                        End If
                        TradeItem(InvNum, 0)
                        Exit Function
                    End If

                    ' use item if not doing anything else
                    If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_NONE Then Exit Function
                    SendUseItem(InvNum)
                    Exit Function
                End If
            End If
            'Spell panel
        ElseIf pnlSpellsVisible = True Then
            If AboveSpellpanel(X, Y) Then

                spellnum = IsPlayerSpell(SpellX, SpellY)

                If spellnum <> 0 Then
                    CastSpell(spellnum)
                    Exit Function
                End If
            End If
        End If

    End Function

    Public Function CheckGuiMouseUp(ByVal X As Long, ByVal Y As Long, ByVal e As MouseEventArgs) As Boolean
        Dim i As Long, rec_pos As Rectangle, buffer As ByteBuffer
        'Inventory
        If pnlInventoryVisible Then
            If AboveInvpanel(X, Y) Then
                If InTrade > 0 Then Exit Function
                If InBank Or InShop Then Exit Function

                If DragInvSlotNum > 0 Then

                    For i = 1 To MAX_INV

                        With rec_pos
                            .Y = InvWindowY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                            .Height = PIC_Y
                            .X = InvWindowX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                            .Width = PIC_X
                        End With

                        If e.Location.X >= rec_pos.Left And e.Location.X <= rec_pos.Right Then
                            If e.Location.Y >= rec_pos.Top And e.Location.Y <= rec_pos.Bottom Then '
                                If DragInvSlotNum <> i Then
                                    SendChangeInvSlots(DragInvSlotNum, i)
                                    Exit For
                                End If
                            End If
                        End If

                    Next

                End If

                DragInvSlotNum = 0
                frmMainGame.pnlTmpInv.Visible = False
            Else
                If FurnitureSelected > 0 Then
                    If Player(MyIndex).InHouse = MyIndex Then
                        If Item(PlayerInv(FurnitureSelected).Num).Type = ITEM_TYPE_FURNITURE Then
                            Buffer = New ByteBuffer
                            Buffer.WriteLong(ClientPackets.CPlaceFurniture)
                            i = CurX
                            Buffer.WriteLong(i)
                            i = CurY
                            Buffer.WriteLong(i)
                            Buffer.WriteLong(FurnitureSelected)
                            SendData(Buffer.ToArray)
                            Buffer = Nothing

                            FurnitureSelected = 0
                        End If
                    End If
                End If
            End If
        ElseIf pnlspellsVisible Then
            If AboveSpellpanel(X, Y) Then
                If InTrade > 0 Then Exit Function
                If InBank Or InShop Then Exit Function

                If DragSpellSlotNum > 0 Then

                    For i = 1 To MAX_PLAYER_SPELLS

                        With rec_pos
                            .Y = SpellWindowY + SpellTop + ((SpellOffsetY + 32) * ((i - 1) \ SpellColumns))
                            .Height = PIC_Y
                            .X = SpellWindowX + SpellLeft + ((SpellOffsetX + 32) * (((i - 1) Mod SpellColumns)))
                            .Width = PIC_X
                        End With

                        If e.Location.X >= rec_pos.Left And e.Location.X <= rec_pos.Right Then
                            If e.Location.Y >= rec_pos.Top And e.Location.Y <= rec_pos.Bottom Then '
                                If DragSpellSlotNum <> i Then
                                    'SendChangeSpellSlots(DragSpellSlotNum, i)
                                    Exit For
                                End If
                            End If
                        End If

                    Next

                End If

                DragSpellSlotNum = 0
                frmMainGame.pnlTmpSkill.Visible = False
            End If
        End If

    End Function

    Public Function CheckGuiMouseDown(ByVal X As Long, ByVal Y As Long, ByVal e As MouseEventArgs) As Boolean
        Dim InvNum As Long, spellnum As Long

        'Inventory
        If pnlInventoryVisible Then
            If AboveInvpanel(X, Y) Then
                InvNum = IsInvItem(e.Location.X, e.Location.Y)

                If e.Button = MouseButtons.Left Then
                    If InvNum <> 0 Then
                        If InTrade Then Exit Function
                        If InBank Or InShop Then Exit Function
                        DragInvSlotNum = InvNum
                    End If
                ElseIf e.Button = MouseButtons.Right Then
                    If Not InBank And Not InShop And Not InTrade Then
                        If InvNum <> 0 Then
                            If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Or Item(GetPlayerInvItemNum(MyIndex, InvNum)).Stackable = 1 Then
                                If GetPlayerInvItemValue(MyIndex, InvNum) > 0 Then
                                    CurrencyMenu = 1 ' drop
                                    frmMainGame.lblCurrency.Text = "How many do you want to drop?"
                                    tmpCurrencyItem = InvNum
                                    frmMainGame.txtCurrency.Text = vbNullString
                                    frmMainGame.pnlCurrency.Visible = True
                                    frmMainGame.txtCurrency.Focus()
                                End If
                            Else
                                SendDropItem(InvNum, 0)
                            End If
                        End If
                    End If
                End If
            End If
        ElseIf pnlSpellsVisible = True Then
            If AboveSpellpanel(X, Y) Then
                spellnum = IsPlayerSpell(e.Location.X, e.Location.Y)

                If e.Button = MouseButtons.Left Then
                    If spellnum <> 0 Then
                        If InTrade Then Exit Function

                        DragSpellSlotNum = spellnum

                        If SelSpellSlot = True Then
                            SendSetHotbarSkill(SelHotbarSlot, spellnum)
                        End If
                    End If
                ElseIf e.Button = MouseButtons.Right Then ' right click

                    If spellnum <> 0 Then
                        ForgetSpell(spellnum)
                        Exit Function
                    End If
                End If
            End If
        End If


    End Function

#Region "Support Functions"
    Function IsEqItem(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long
        IsEqItem = 0

        For i = 1 To Equipment.Equipment_Count - 1

            If GetPlayerEquipment(MyIndex, i) > 0 And GetPlayerEquipment(MyIndex, i) <= MAX_ITEMS Then

                With tempRec
                    .top = CharWindowY + EqTop + ((EqOffsetY + 32) * ((i - 1) \ EqColumns))
                    .bottom = .top + PIC_Y
                    .left = CharWindowX + EqLeft + ((EqOffsetX + 32) * (((i - 1) Mod EqColumns)))
                    .right = .left + PIC_X
                End With

                If X >= tempRec.left And X <= tempRec.right Then
                    If Y >= tempRec.top And Y <= tempRec.bottom Then
                        IsEqItem = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Function IsInvItem(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long
        IsInvItem = 0

        For i = 1 To MAX_INV

            If GetPlayerInvItemNum(MyIndex, i) > 0 And GetPlayerInvItemNum(MyIndex, i) <= MAX_ITEMS Then

                With tempRec
                    .top = InvWindowY + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .bottom = .top + PIC_Y
                    .left = InvWindowX + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                    .right = .left + PIC_X
                End With

                If X >= tempRec.left And X <= tempRec.right Then
                    If Y >= tempRec.top And Y <= tempRec.bottom Then
                        IsInvItem = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Function IsPlayerSpell(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long

        IsPlayerSpell = 0

        For i = 1 To MAX_PLAYER_SPELLS

            If PlayerSpells(i) > 0 And PlayerSpells(i) <= MAX_PLAYER_SPELLS Then

                With tempRec
                    .top = SpellWindowY + SpellTop + ((SpellOffsetY + 32) * ((i - 1) \ SpellColumns))
                    .bottom = .top + PIC_Y
                    .left = SpellWindowX + SpellLeft + ((SpellOffsetX + 32) * (((i - 1) Mod SpellColumns)))
                    .right = .left + PIC_X
                End With

                If X >= tempRec.left And X <= tempRec.right Then
                    If Y >= tempRec.top And Y <= tempRec.bottom Then
                        IsPlayerSpell = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Function AboveActionPanel(ByVal X As Single, ByVal Y As Single) As Boolean
        AboveActionPanel = False

        If X > ActionPanelX And X < ActionPanelX + ActionPanelGFXInfo.width Then
            If Y > ActionPanelY And Y < ActionPanelY + ActionPanelGFXInfo.height Then
                AboveActionPanel = True
            End If
        End If
    End Function

    Function AboveHotbar(ByVal X As Single, ByVal Y As Single) As Boolean
        AboveHotbar = False

        If X > HotbarX And X < HotbarX + HotBarGFXInfo.width Then
            If Y > HotbarY And Y < HotbarY + HotBarGFXInfo.height Then
                AboveHotbar = True
            End If
        End If
    End Function

    Function AboveInvpanel(ByVal X As Single, ByVal Y As Single) As Boolean
        AboveInvpanel = False

        If X > InvWindowX And X < InvWindowX + InvPanelGFXInfo.width Then
            If Y > InvWindowY And Y < InvWindowY + InvPanelGFXInfo.height Then
                AboveInvpanel = True
            End If
        End If
    End Function

    Function AboveCharpanel(ByVal X As Single, ByVal Y As Single) As Boolean
        AboveCharpanel = False

        If X > CharWindowX And X < CharWindowX + CharPanelGFXInfo.width Then
            If Y > CharWindowY And Y < CharWindowY + CharPanelGFXInfo.height Then
                AboveCharpanel = True
            End If
        End If
    End Function

    Function AboveSpellpanel(ByVal X As Single, ByVal Y As Single) As Boolean
        AboveSpellpanel = False

        If X > SpellWindowX And X < SpellWindowX + SpellPanelGFXInfo.width Then
            If Y > SpellWindowY And Y < SpellWindowY + SpellPanelGFXInfo.height Then
                AboveSpellpanel = True
            End If
        End If
    End Function
#End Region


End Module
