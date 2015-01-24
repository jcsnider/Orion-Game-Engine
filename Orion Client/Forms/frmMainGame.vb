Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMainGame

    Private Sub picscreen_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picscreen.MouseDown
        If InMapEditor Then
            Call MapEditorMouseDown(e.Button, e.X, e.Y, False)
        Else
            ' left click
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ' if we're in the middle of choose the trade target or not
                If Not TradeRequest Then
                    ' targetting
                    Call PlayerSearch(CurX, CurY)
                Else
                    ' trading
                    Call SendTradeRequest(CurX, CurY)
                End If
                ' right click
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If ShiftDown Then
                    ' admin warp if we're pressing shift and right clicking
                    If GetPlayerAccess(MyIndex) >= 2 Then AdminWarp(CurX, CurY)
                End If
            End If
        End If

        Me.txtMeChat.Focus()
    End Sub
    Private Overloads Sub picscreen_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picscreen.Paint
        'This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
        Exit Sub
    End Sub

    Private Sub frmMainGame_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call DestroyGame()
    End Sub

    Private Sub frmMainGame_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Down Then VbKeyDown = True
        If e.KeyCode = Keys.Up Then VbKeyUp = True
        If e.KeyCode = Keys.Left Then VbKeyLeft = True
        If e.KeyCode = Keys.Right Then VbKeyRight = True
    End Sub

    Private Sub frmMainGame_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Then VbKeyDown = False
        If e.KeyCode = Keys.Up Then VbKeyUp = False
        If e.KeyCode = Keys.Left Then VbKeyLeft = False
        If e.KeyCode = Keys.Right Then VbKeyRight = False
    End Sub

    Private Sub frmMainGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picAdmin.Left = 10
        pnlCurrency.Left = txtChat.Left
        pnlCurrency.Top = txtChat.Top
        Me.Width = 745
        Me.Height = 565
        picInventory.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Inventory" & GFX_EXT
        picSkills.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Skills" & GFX_EXT
        picCharacter.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Character" & GFX_EXT
        picTrade.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Trade" & GFX_EXT
        picOptions.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Options" & GFX_EXT
        picExit.ImageLocation = Application.StartupPath & GFX_PATH & "actionbar\Exit" & GFX_EXT


    End Sub

    Private Sub txtChat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChat.KeyDown
        If e.KeyCode = Keys.Down Then VbKeyDown = True
        If e.KeyCode = Keys.Up Then VbKeyUp = True
        If e.KeyCode = Keys.Left Then VbKeyLeft = True
        If e.KeyCode = Keys.Right Then VbKeyRight = True
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = True
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = True
    End Sub

    Private Sub txtChat_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChat.KeyUp
        If e.KeyCode = Keys.Down Then VbKeyDown = False
        If e.KeyCode = Keys.Up Then VbKeyUp = False
        If e.KeyCode = Keys.Left Then VbKeyLeft = False
        If e.KeyCode = Keys.Right Then VbKeyRight = False
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = False
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = False
        If e.KeyCode = Keys.F1 Then
            If Player(MyIndex).Access > 0 Then
                picAdmin.Visible = Not picAdmin.Visible
                picAdmin.BringToFront()
            End If
        End If

    End Sub

    Private Sub pnlGeneral_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picGeneral.Paint
        'PlaceHolder
    End Sub

    Private Sub txtChat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChat.TextChanged

    End Sub

    Private Sub btnMapEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMapEditor.Click

        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditMap()
    End Sub

    Private Sub picscreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picscreen.Click

    End Sub

    Private Sub picscreen_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picscreen.MouseMove
        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

        If InMapEditor Then

            If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
                Call MapEditorMouseDown(e.Button, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeChat.KeyDown
        If e.KeyCode = Keys.Down Then VbKeyDown = True
        If e.KeyCode = Keys.Up Then VbKeyUp = True
        If e.KeyCode = Keys.Left Then VbKeyLeft = True
        If e.KeyCode = Keys.Right Then VbKeyRight = True
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = True
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = True
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeChat.KeyUp
        If e.KeyCode = Keys.Down Then VbKeyDown = False
        If e.KeyCode = Keys.Up Then VbKeyUp = False
        If e.KeyCode = Keys.Left Then VbKeyLeft = False
        If e.KeyCode = Keys.Right Then VbKeyRight = False
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = False
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = False
        If e.KeyCode = Keys.F1 Then
            If Player(MyIndex).Access > 0 Then
                picAdmin.Visible = Not picAdmin.Visible
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            HandlePressEnter()
            CheckMapGetItem()
            Me.txtMeChat.Text = ""
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub txtMeChat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeChat.TextChanged
        MyText = txtMeChat.Text
    End Sub

    Private Sub btnAdminWarpTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminWarpTo.Click
        Dim n As Long

        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminMap.Text)) < 1 Then
            Exit Sub
        End If

        If Not IsNumeric(Trim$(txtAdminMap.Text)) Then
            Exit Sub
        End If

        n = CLng(Trim$(txtAdminMap.Text))

        ' Check to make sure its a valid map #
        If n > 0 And n <= MAX_MAPS Then
            Call WarpTo(n)
        Else
            Call AddText("Invalid map number.")
        End If
    End Sub

    Private Sub btnAdminBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminBan.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        SendBan(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminKick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminKick.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        SendKick(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminWarp2Me_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminWarp2Me.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Then
            Exit Sub
        End If

        WarpToMe(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminWarpMe2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminWarpMe2.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Then
            Exit Sub
        End If

        WarpMeTo(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminSetAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminSetAccess.Click
        If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 2 Then
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Or Not IsNumeric(Trim$(txtAdminAccess.Text)) Then
            Exit Sub
        End If

        SendSetAccess(Trim$(txtAdminName.Text), CLng(Trim$(txtAdminAccess.Text)))
    End Sub

    Private Sub btnAdminSetSprite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminSetSprite.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        If Len(Trim$(txtAdminSprite.Text)) < 1 Then
            Exit Sub
        End If

        If Not IsNumeric(Trim$(txtAdminSprite.Text)) Then
            Exit Sub
        End If

        SendSetSprite(CLng(Trim$(txtAdminSprite.Text)))
    End Sub

    Private Sub scrlSpawnItem_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlSpawnItem.Scroll
        lblItemSpawn.Text = "Item: " & Trim$(Item(scrlSpawnItem.Value).Name)
        If Item(scrlSpawnItem.Value).Type = ITEM_TYPE_CURRENCY Then
            scrlSpawnItemAmount.Enabled = True
            Exit Sub
        End If
        scrlSpawnItemAmount.Enabled = False
    End Sub

    Private Sub scrlSpawnItemAmount_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlSpawnItemAmount.Scroll
        lblSpawnItemAmount.Text = "Amount: " & scrlSpawnItemAmount.Value
    End Sub

    Private Sub btnSpawnItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpawnItem.Click
        If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendSpawnItem(scrlSpawnItem.Value, scrlSpawnItemAmount.Value)
    End Sub

    Private Sub btnLevelUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLevelUp.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestLevelUp()
    End Sub

    Private Sub btnItemEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemEditor.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditItem()
    End Sub

    Private Sub btnResourceEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResourceEditor.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditResource()
    End Sub

    Private Sub btnNPCEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNPCEditor.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditNpc()
    End Sub

    Private Sub btnSpellEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpellEditor.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditSpell()
    End Sub

    Private Sub btnShopEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShopEditor.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditShop()
    End Sub

    Private Sub btnAnimationEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnimationEditor.Click
        If GetPlayerAccess(MyIndex) < ADMIN_DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendRequestEditAnimation()
    End Sub

    Private Sub btnALoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALoc.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        BLoc = Not BLoc
    End Sub

    Private Sub btnDelBans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelBans.Click
        If GetPlayerAccess(MyIndex) < ADMIN_CREATOR Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendBanDestroy()
    End Sub

    Private Sub btnRespawn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRespawn.Click
        If GetPlayerAccess(MyIndex) < ADMIN_MAPPER Then
            AddText("You need to be a high enough staff member to do this!")
            Exit Sub
        End If

        SendMapRespawn()
    End Sub

    Private Sub optMOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMOn.CheckedChanged
        Options.Music = 1
        ' start music playing
        PlayMusic(Trim$(Map.Music))
        ' save to config.ini
        SaveOptions()
    End Sub

    Private Sub optMOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMOff.CheckedChanged
        Options.Music = 0
        ' stop music playing
        StopMusic()
        ' save to config.ini
        SaveOptions()
    End Sub

    Private Sub optSOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSOn.CheckedChanged
        Options.Sound = 1
        ' save to config.ini
        SaveOptions()
    End Sub

    Private Sub optSOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSOff.CheckedChanged
        Options.Sound = 0
        ' save to config.ini
        SaveOptions()
    End Sub

    Private Sub lblTrainStr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainStr.Click
        If GetPlayerPOINTS(MyIndex) = 0 Then Exit Sub
        SendTrainStat(1)
    End Sub

    Private Sub lblTrainVit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainVit.Click
        If GetPlayerPOINTS(MyIndex) = 0 Then Exit Sub
        SendTrainStat(3)
    End Sub

    Private Sub lblTrainInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainInt.Click
        If GetPlayerPOINTS(MyIndex) = 0 Then Exit Sub
        SendTrainStat(5)
    End Sub

    Private Sub lblTrainEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainEnd.Click
        If GetPlayerPOINTS(MyIndex) = 0 Then Exit Sub
        SendTrainStat(2)
    End Sub

    Private Sub lblTrainWill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainWill.Click
        If GetPlayerPOINTS(MyIndex) = 0 Then Exit Sub
        SendTrainStat(4)
    End Sub

    Private Sub lblTrainSpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainSpr.Click
        If GetPlayerPOINTS(MyIndex) = 0 Then Exit Sub
        SendTrainStat(6)
    End Sub

    Private Sub picCharacter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCharacter.Click
        SendRequestPlayerData()
        pnlCharacter.Visible = True
        pnlInventory.Visible = False
        pnlSpells.Visible = False
        pnlOptions.Visible = False
        DrawEquipment()
    End Sub

    Private Sub picOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picOptions.Click
        pnlCharacter.Visible = False
        pnlInventory.Visible = False
        pnlSpells.Visible = False
        pnlOptions.Visible = True
    End Sub

    Private Sub picInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picInventory.Click
        pnlInventory.Visible = True
        pnlCharacter.Visible = False
        pnlSpells.Visible = False
        pnlOptions.Visible = False
        'DrawInventory()
    End Sub

    Private Sub picExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExit.Click
        Dim Buffer As ByteBuffer
        Dim i As Long

        isLogging = True
        InGame = False

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CQuit)
        SendData(Buffer.ToArray())
        Buffer = Nothing


        ' destroy the animations loaded
        For i = 1 To MAX_BYTE
            ClearAnimInstance(i)
        Next

        ' destroy temp values
        DragInvSlotNum = 0
        InvX = 0
        InvY = 0
        EqX = 0
        EqY = 0
        SpellX = 0
        SpellY = 0
        LastItemDesc = 0
        MyIndex = 0
        InventoryItemSelected = 0
        SpellBuffer = 0
        SpellBufferTimer = 0
        tmpCurrencyItem = 0

        txtChat.Text = vbNullString
        DestroyGame()
    End Sub

    Private Sub pnlInventory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInventory.DoubleClick
        Dim InvNum As Long
        Dim Value As Long
        Dim multiplier As Double
        Dim i As Long

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
                            AddText("You can sell this item for " & Value & " gold.")
                        Else
                            AddText("The shop does not want this item.")
                        End If
                    Case 2 ' 2 = sell
                        SellItem(InvNum)
                End Select

                Exit Sub
            End If

            ' in bank?
            If InBank Then
                If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Then
                    CurrencyMenu = 2 ' deposit
                    lblCurrency.Text = "How many do you want to deposit?"
                    tmpCurrencyItem = InvNum
                    txtCurrency.Text = vbNullString
                    pnlCurrency.Visible = True
                    txtCurrency.Focus()
                    Exit Sub
                End If
                Call DepositItem(InvNum, 0)
                Exit Sub
            End If

            ' in trade?
            If InTrade = True Then
                ' exit out if we're offering that item
                For i = 1 To MAX_INV
                    If TradeYourOffer(i).Num = InvNum Then
                        Exit Sub
                    End If
                Next
                If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Then
                    ' currency shit here brah
                    Exit Sub
                End If
                Call TradeItem(InvNum, 0)
                Exit Sub
            End If

            ' use item if not doing anything else
            If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_NONE Then Exit Sub
            Call SendUseItem(InvNum)
            Exit Sub
        End If
    End Sub

    Private Sub pnlInventory_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInventory.MouseDown
        Dim InvNum As Long
        InvNum = IsInvItem(e.Location.X, e.Location.Y)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            If InvNum <> 0 Then
                If InTrade Then Exit Sub
                If InBank Or InShop Then Exit Sub
                DragInvSlotNum = InvNum
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If Not InBank And Not InShop And Not InTrade Then
                If InvNum <> 0 Then
                    If Item(GetPlayerInvItemNum(MyIndex, InvNum)).Type = ITEM_TYPE_CURRENCY Then
                        If GetPlayerInvItemValue(MyIndex, InvNum) > 0 Then
                            CurrencyMenu = 1 ' drop
                            lblCurrency.Text = "How many do you want to drop?"
                            tmpCurrencyItem = InvNum
                            txtCurrency.Text = vbNullString
                            pnlCurrency.Visible = True
                            txtCurrency.Focus()
                        End If
                    Else
                        Call SendDropItem(InvNum, 0)
                    End If
                End If
            End If
        End If

        txtMeChat.Focus()
    End Sub

    Private Sub pnlInventory_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInventory.MouseMove
        Dim InvNum As Long
        Dim i As Long
        Dim x As Long
        Dim y As Long
        x = e.Location.X
        y = e.Location.Y


        InvX = x
        InvY = y

        If DragInvSlotNum > 0 Then
            If InTrade Then Exit Sub
            If InBank Or InShop Then Exit Sub
            Call DrawInventoryItem(CLng(x) + pnlInventory.Left, CLng(y) + pnlInventory.Top)
        Else
            InvNum = IsInvItem(x, y)

            If InvNum <> 0 Then
                ' exit out if we're offering that item
                For i = 1 To MAX_INV
                    If TradeYourOffer(i).Num = InvNum Then
                        Exit Sub
                    End If
                Next
                x = x + pnlInventory.Left + 6
                y = y + pnlInventory.Top + 6
                UpdateDescWindow(GetPlayerInvItemNum(MyIndex, InvNum), GetPlayerInvItemValue(MyIndex, InvNum), x, y)
                LastItemDesc = GetPlayerInvItemNum(MyIndex, InvNum) ' set it so you don't re-set values
                Exit Sub
            End If
        End If

        pnlItemDesc.Visible = False
        LastItemDesc = 0 ' no item was last loaded
        'DrawInventory()
    End Sub
    Private Function IsInvItem(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long
        IsInvItem = 0

        For i = 1 To MAX_INV

            If GetPlayerInvItemNum(MyIndex, i) > 0 And GetPlayerInvItemNum(MyIndex, i) <= MAX_ITEMS Then

                With tempRec
                    .top = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .bottom = .top + PIC_Y
                    .left = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
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

    Private Sub pnlInventory_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInventory.MouseUp
        Dim i As Long
        Dim rec_pos As Rectangle

        If InTrade > 0 Then Exit Sub
        If InBank Or InShop Then Exit Sub

        If DragInvSlotNum > 0 Then

            For i = 1 To MAX_INV

                With rec_pos
                    .Y = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .Height = PIC_Y
                    .X = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
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
        pnlTmpInv.Visible = False
    End Sub

    Private Overloads Sub pnlInventory_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlInventory.Paint
        Exit Sub
    End Sub

    Private Sub lblCurrencyOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCurrencyOk.Click
        If IsNumeric(txtCurrency.Text) Then
            Select Case CurrencyMenu
                Case 1 ' drop item
                    SendDropItem(tmpCurrencyItem, Val(txtCurrency.Text))
                Case 2 ' deposit item
                    DepositItem(tmpCurrencyItem, Val(txtCurrency.Text))
                Case 3 ' withdraw item
                    WithdrawItem(tmpCurrencyItem, Val(txtCurrency.Text))
            End Select
        End If

        pnlCurrency.Visible = False
        tmpCurrencyItem = 0
        txtCurrency.Text = vbNullString
        CurrencyMenu = 0 ' clear
    End Sub

    Private Sub lblShopBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShopBuy.Click
        If ShopAction = 1 Then Exit Sub
        ShopAction = 1 ' buying an item
        AddText("Click on the item in the shop you wish to buy.")
    End Sub

    Private Sub lblShopSell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShopSell.Click
        If ShopAction = 2 Then Exit Sub
        ShopAction = 2 ' selling an item
        AddText("Double-click on the item in your inventory you wish to sell.")
    End Sub

    Private Sub pnlShopItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlShopItems.MouseDown
        Dim shopItem As Long
        Dim x As Long, y As Long
        x = e.Location.X
        y = e.Location.Y
        shopItem = IsShopItem(x, y)

        If shopItem > 0 Then
            Select Case ShopAction
                Case 0 ' no action, give cost
                    With Shop(InShop).TradeItem(shopItem)
                        AddText("You can buy this item for " & .CostValue & " " & Trim$(Item(.CostItem).Name) & ".")
                    End With
                Case 1 ' buy item
                    ' buy item code
                    BuyItem(shopItem)
            End Select
        End If
    End Sub

    Private Sub pnlShopItems_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlShopItems.MouseMove
        Dim shopslot As Long
        Dim x2 As Long, y2 As Long
        Dim x As Long, y As Long

        x = e.Location.X
        y = e.Location.Y

        shopslot = IsShopItem(x, y)

        If shopslot <> 0 Then
            x2 = x + pnlShop.Left + pnlShopItems.Left + 3
            y2 = y + pnlShop.Top + pnlShopItems.Left + 19
            UpdateDescWindow(Shop(InShop).TradeItem(shopslot).Item, Shop(InShop).TradeItem(shopslot).ItemValue, x2, y2)
            LastItemDesc = Shop(InShop).TradeItem(shopslot).Item
            Exit Sub
        End If

        pnlItemDesc.Visible = False
        LastItemDesc = 0
    End Sub
    Private Function IsShopItem(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As Rectangle
        Dim i As Long
        IsShopItem = 0

        For i = 1 To MAX_TRADES

            If Shop(InShop).TradeItem(i).Item > 0 And Shop(InShop).TradeItem(i).Item <= MAX_ITEMS Then
                With tempRec
                    .Y = .Top = ShopTop + ((ShopOffsetY + 32) * ((i - 1) \ ShopColumns))
                    .Height = PIC_Y
                    .X = ShopLeft + ((ShopOffsetX + 32) * (((i - 1) Mod ShopColumns)))
                    .Width = PIC_X
                End With

                If X >= tempRec.Left And X <= tempRec.Right Then
                    If Y >= tempRec.Top And Y <= tempRec.Bottom Then
                        IsShopItem = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Private Sub pnlShopItems_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlShopItems.Paint
        'do nothing
    End Sub

    Private Sub lblLeaveShop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLeaveShop.Click
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CCloseShop)
        SendData(Buffer.ToArray())
        Buffer = Nothing
        pnlShop.Visible = False
        InShop = 0
        ShopAction = 0
    End Sub

    Private Sub pnlBank_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBank.DoubleClick
        Dim bankNum As Long

        DragBankSlotNum = 0

        bankNum = IsBankItem(BankX, BankY)
        If bankNum <> 0 Then
            If GetBankItemNum(bankNum) = ITEM_TYPE_NONE Then Exit Sub

            If Item(GetBankItemNum(bankNum)).Type = ITEM_TYPE_CURRENCY Then
                CurrencyMenu = 3 ' withdraw
                lblCurrency.Text = "How many do you want to withdraw?"
                tmpCurrencyItem = bankNum
                txtCurrency.Text = vbNullString
                pnlCurrency.Visible = True
                txtCurrency.Focus()
                Exit Sub
            End If

            WithdrawItem(bankNum, 0)
            Exit Sub
        End If
    End Sub
    Private Function IsBankItem(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long

        IsBankItem = 0

        For i = 1 To MAX_BANK
            If GetBankItemNum(i) > 0 And GetBankItemNum(i) <= MAX_ITEMS Then

                With tempRec
                    .top = BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                    .bottom = .top + PIC_Y
                    .left = BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                    .right = .left + PIC_X
                End With

                If X >= tempRec.left And X <= tempRec.right Then
                    If Y >= tempRec.top And Y <= tempRec.bottom Then

                        IsBankItem = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Private Sub pnlBank_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBank.MouseDown
        Dim bankNum As Long
        Dim x As Long, y As Long
        x = e.Location.X
        y = e.Location.Y
        bankNum = IsBankItem(x, y)

        If bankNum <> 0 Then

            If e.Button = Windows.Forms.MouseButtons.Left Then
                DragBankSlotNum = bankNum
            End If
        End If
    End Sub

    Private Sub pnlBank_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBank.MouseMove
        Dim bankNum As Long
        Dim x2 As Long, y2 As Long, x As Long, y As Long

        x = e.Location.X
        y = e.Location.Y

        BankX = x
        BankY = y

        If DragBankSlotNum > 0 Then
            Call DrawBankItem(x + pnlBank.Left, y + pnlBank.Top)
        Else
            bankNum = IsBankItem(x, y)

            If bankNum <> 0 Then

                x2 = x + pnlBank.Left + 6
                y2 = y + pnlBank.Top + 6
                UpdateDescWindow(Bank.Item(bankNum).Num, Bank.Item(bankNum).Value, x2, y2)
                Exit Sub
            End If
        End If

        Me.pnlItemDesc.Visible = False
        LastBankDesc = 0
    End Sub

    Private Sub pnlBank_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBank.MouseUp
        Dim i As Long
        Dim x As Long, y As Long
        Dim rec_pos As Rectangle

        x = e.Location.X
        y = e.Location.Y

        ' TODO : Add sub to change bankslots client side first so there's no delay in switching
        If DragBankSlotNum > 0 Then
            For i = 1 To MAX_BANK
                With rec_pos
                    .Y = BankTop + ((BankOffsetY + 32) * ((i - 1) \ BankColumns))
                    .Height = PIC_Y
                    .X = BankLeft + ((BankOffsetX + 32) * (((i - 1) Mod BankColumns)))
                    .Width = PIC_X
                End With

                If x >= rec_pos.Left And x <= rec_pos.Right Then
                    If y >= rec_pos.Top And y <= rec_pos.Bottom Then
                        If DragBankSlotNum <> i Then
                            ChangeBankSlots(DragBankSlotNum, i)
                            Exit For
                        End If
                    End If
                End If
            Next
        End If

        DragBankSlotNum = 0
        pnlTempBank.Visible = False
    End Sub

    Private Sub pnlBank_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBank.Paint
        'do nothing
    End Sub

    Private Sub lblLeaveBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLeaveBank.Click
        CloseBank()
    End Sub

    Private Sub picTrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTrade.Click
        AddText("Click on the player you wish to trade with.")
        TradeTimer = GetTickCount() + 10000 ' 10 seconds to click on the player
        TradeRequest = True
    End Sub

    Private Sub pnlYourTrade_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlYourTrade.DoubleClick
        Dim TradeNum As Long

        TradeNum = IsTradeItem(TradeX, TradeY, True)

        If TradeNum <> 0 Then
            UntradeItem(TradeNum)
        End If
    End Sub

    Private Sub pnlYourTrade_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlYourTrade.MouseMove
        Dim TradeNum As Long
        Dim x As Long, y As Long

        x = e.Location.X
        y = e.Location.Y

        TradeX = e.Location.X
        TradeY = e.Location.Y

        TradeNum = IsTradeItem(x, y, True)

        If TradeNum <> 0 Then
            x = x + pnlTrade.Left + pnlYourTrade.Left + 4
            y = y + pnlTrade.Top + pnlYourTrade.Top + 4
            UpdateDescWindow(GetPlayerInvItemNum(MyIndex, TradeYourOffer(TradeNum).Num), TradeYourOffer(TradeNum).Value, x, y)
            LastItemDesc = GetPlayerInvItemNum(MyIndex, TradeYourOffer(TradeNum).Num) ' set it so you don't re-set values
            Exit Sub
        End If

        pnlItemDesc.Visible = False
        LastItemDesc = 0 ' no item was last loaded
    End Sub

    Private Sub pnlYourTrade_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlYourTrade.Paint
        'do nothing
    End Sub
    Private Function IsTradeItem(ByVal X As Single, ByVal Y As Single, ByVal Yours As Boolean) As Long
        Dim tempRec As RECT
        Dim i As Long
        Dim itemnum As Long

        IsTradeItem = 0

        For i = 1 To MAX_INV

            If Yours Then
                itemnum = GetPlayerInvItemNum(MyIndex, TradeYourOffer(i).Num)
            Else
                itemnum = TradeTheirOffer(i).Num
            End If

            If itemnum > 0 And itemnum <= MAX_ITEMS Then

                With tempRec
                    .top = InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                    .bottom = .top + PIC_Y
                    .left = InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))
                    .right = .left + PIC_X
                End With

                If X >= tempRec.left And X <= tempRec.right Then
                    If Y >= tempRec.top And Y <= tempRec.bottom Then
                        IsTradeItem = i
                        Exit Function
                    End If
                End If
            End If

        Next

    End Function

    Private Sub pnlTheirTrade_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlTheirTrade.MouseMove
        Dim TradeNum As Long
        Dim x As Long, y As Long
        x = e.Location.X
        y = e.Location.Y

        TradeNum = IsTradeItem(x, y, False)

        If TradeNum <> 0 Then
            x = x + pnlTrade.Left + pnlTheirTrade.Left + 4
            y = y + pnlTrade.Top + pnlTheirTrade.Top + 4
            UpdateDescWindow(TradeTheirOffer(TradeNum).Num, TradeTheirOffer(TradeNum).Value, x, y)
            LastItemDesc = TradeTheirOffer(TradeNum).Num ' set it so you don't re-set values
            Exit Sub
        End If

        pnlItemDesc.Visible = False
        LastItemDesc = 0 ' no item was last loaded
    End Sub

    Private Sub pnlTheirTrade_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlTheirTrade.Paint
        'do nothing
    End Sub

    Private Sub lblAcceptTrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAcceptTrade.Click
        AcceptTrade()
    End Sub

    Private Sub pnlCharacter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCharacter.Click
        Dim EqNum As Long
        EqNum = IsEqItem(EqX, EqY)

        If EqNum <> 0 Then
            SendUnequip(EqNum)
        End If
    End Sub
    Private Function IsEqItem(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long
        IsEqItem = 0

        For i = 1 To Equipment.Equipment_Count - 1

            If GetPlayerEquipment(MyIndex, i) > 0 And GetPlayerEquipment(MyIndex, i) <= MAX_ITEMS Then

                With tempRec
                    .top = EqTop
                    .bottom = .top + PIC_Y
                    .left = EqLeft + ((EqOffsetX + 32) * (((i - 1) Mod EqColumns)))
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

    Private Sub pnlCharacter_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCharacter.MouseMove
        Dim EqNum As Long
        Dim x As Long, y As Long
        Dim x2 As Long, y2 As Long


        x = e.Location.X
        y = e.Location.Y

        EqX = x
        EqY = y
        EqNum = IsEqItem(x, y)

        If EqNum <> 0 Then
            y2 = y + pnlCharacter.Top - Me.pnlItemDesc.Height - 2
            x2 = x + pnlCharacter.Left + 2
            UpdateDescWindow(GetPlayerEquipment(MyIndex, EqNum), 0, x2, y2)
            LastItemDesc = GetPlayerEquipment(MyIndex, EqNum) ' set it so you don't re-set values
            Exit Sub
        End If

        pnlItemDesc.Visible = False
        LastItemDesc = 0 ' no item was last loaded
    End Sub

    Private Sub pnlSpells_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSpells.DoubleClick
        Dim spellnum As Long

        spellnum = IsPlayerSpell(SpellX, SpellY)

        If spellnum <> 0 Then
            Call CastSpell(spellnum)
            Exit Sub
        End If
    End Sub

    Private Sub pnlSpells_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSpells.MouseDown
        Dim spellnum As Long

        If e.Button = Windows.Forms.MouseButtons.Right Then ' right click
            spellnum = IsPlayerSpell(SpellX, SpellY)

            If spellnum <> 0 Then
                Call ForgetSpell(spellnum)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub pnlSpells_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSpells.MouseMove
        Dim spellslot As Long
        Dim x2 As Long, y2 As Long
        Dim x As Long, y As Long

        x = e.Location.X
        y = e.Location.Y

        SpellX = x
        SpellY = y

        spellslot = IsPlayerSpell(x, y)

        If spellslot <> 0 Then
            x2 = x + pnlSpells.Left + 2
            y2 = y + pnlSpells.Top + 2
            UpdateSpellWindow(PlayerSpells(spellslot), x2, y2)
            LastSpellDesc = PlayerSpells(spellslot)
            Exit Sub
        End If

        pnlSpellDesc.Visible = False
        LastSpellDesc = 0
    End Sub
    Private Function IsPlayerSpell(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long

        IsPlayerSpell = 0

        For i = 1 To MAX_PLAYER_SPELLS

            If PlayerSpells(i) > 0 And PlayerSpells(i) <= MAX_PLAYER_SPELLS Then

                With tempRec
                    .top = SpellTop + ((SpellOffsetY + 32) * ((i - 1) \ SpellColumns))
                    .bottom = .top + PIC_Y
                    .left = SpellLeft + ((SpellOffsetX + 32) * (((i - 1) Mod SpellColumns)))
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

    Private Sub pnlSpells_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlSpells.Paint
        'do nothing ;)
    End Sub

    Private Sub picSkills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSkills.Click
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSpells)
        SendData(Buffer.ToArray())
        Buffer = Nothing
        pnlSpells.Visible = True
        pnlInventory.Visible = False
        pnlCharacter.Visible = False
        pnlOptions.Visible = False
    End Sub

    Private Sub lblDeclineTrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDeclineTrade.Click
        DeclineTrade()
    End Sub
End Class