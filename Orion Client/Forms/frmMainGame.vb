Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMainGame
#Region "Frm Code"
    Dim ShakeCount As Byte, LastDir As Byte

    Private Sub frmMainGame_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Disposed
        frmAdmin.Dispose()
        DestroyGame()
    End Sub

    Private Sub frmMainGame_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown


        If inChat = True Then
            If e.KeyCode >= 32 And e.KeyCode <= 255 And Not e.KeyCode = Keys.Enter Then
                If MyText.Length < 100 Then
                    MyText = MyText + KeyPressed(e)
                End If
            End If

            If e.KeyCode = Keys.Back Then
                If MyText.Length > 0 Then
                    MyText = MyText.Remove(MyText.Length - 1)
                End If

            End If
        Else
            If e.KeyCode = Keys.S Then VbKeyDown = True
            If e.KeyCode = Keys.W Then VbKeyUp = True
            If e.KeyCode = Keys.A Then VbKeyLeft = True
            If e.KeyCode = Keys.D Then VbKeyRight = True
            If e.KeyCode = Keys.ShiftKey Then VbKeyShift = True
            If e.KeyCode = Keys.ControlKey Then VbKeyControl = True
        End If

        If e.KeyCode = Keys.Enter Then
            HandlePressEnter()
            CheckMapGetItem()
            inChat = Not inChat
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub frmMainGame_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        Dim spellnum As Long
        If e.KeyCode = Keys.S Then VbKeyDown = False
        If e.KeyCode = Keys.W Then VbKeyUp = False
        If e.KeyCode = Keys.A Then VbKeyLeft = False
        If e.KeyCode = Keys.D Then VbKeyRight = False
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = False
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = False

        'hotbar
        If e.KeyCode = Keys.NumPad1 Then
            spellnum = Player(MyIndex).Hotbar(1).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad2 Then
            spellnum = Player(MyIndex).Hotbar(2).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad3 Then
            spellnum = Player(MyIndex).Hotbar(3).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad4 Then
            spellnum = Player(MyIndex).Hotbar(4).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad5 Then
            spellnum = Player(MyIndex).Hotbar(5).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad6 Then
            spellnum = Player(MyIndex).Hotbar(6).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad7 Then
            spellnum = Player(MyIndex).Hotbar(7).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If

        'admin
        If e.KeyCode = Keys.Insert Then
            If Player(MyIndex).Access > 0 Then
                SendRequestAdmin()
            End If
        End If
        'hide gui
        If e.KeyCode = Keys.F10 Then
            HideGui = True
        End If

        'lets check for keys for inventory etc
        If Not inChat Then
            If e.KeyCode = Keys.I Then
                pnlInventoryVisible = Not pnlInventoryVisible
            End If

        End If

    End Sub

    Private Sub frmMainGame_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        RePositionGUI()

        frmAdmin.Visible = False

    End Sub

    Private Sub lblCurrencyOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblCurrencyOk.Click
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

#End Region

#Region "PicScreen Code"
    Private Sub picscreen_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.MouseDown
        If InMapEditor Then
            MapEditorMouseDown(e.Button, e.X, e.Y, False)
        Else
            If Not CheckGuiClick(e.X, e.Y, e) Then
                ' left click
                If e.Button = MouseButtons.Left Then
                    ' if we're in the middle of choose the trade target or not
                    If Not TradeRequest Then
                        ' targetting
                        PlayerSearch(CurX, CurY)
                    Else
                        ' trading
                        SendTradeRequest(CurX, CurY)
                    End If
                    ' right click
                ElseIf e.Button = MouseButtons.Right Then
                    If ShiftDown Or VbKeyShift = True Then
                        ' admin warp if we're pressing shift and right clicking
                        If GetPlayerAccess(MyIndex) >= 2 Then AdminWarp(CurX, CurY)
                    End If
                    FurnitureSelected = 0
                End If
            End If

        End If

        CheckGuiMouseDown(e.X, e.Y, e)

        Me.Focus()

    End Sub

    Private Sub picscreen_DoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.DoubleClick
        CheckGuiDoubleClick(e.X, e.Y, e)
    End Sub

    Private Overloads Sub picscreen_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picscreen.Paint
        'This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
        Exit Sub
    End Sub

    Private Sub picscreen_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.MouseMove

        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

        If InMapEditor Then
            If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
                MapEditorMouseDown(e.Button, e.X, e.Y)
            End If
        End If

        CheckGuiMove(e.X, e.Y)

    End Sub

    Private Sub picscreen_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.MouseUp

        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)

        CheckGuiMouseUp(e.X, e.Y, e)
    End Sub

    Private Sub picscreen_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles picscreen.KeyDown
        Dim spellnum As Long

        If e.KeyCode = Keys.S Then VbKeyDown = True
        If e.KeyCode = Keys.W Then VbKeyUp = True
        If e.KeyCode = Keys.A Then VbKeyLeft = True
        If e.KeyCode = Keys.D Then VbKeyRight = True
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = True
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = True

        If inChat = True Then
            If e.KeyCode >= 32 And e.KeyCode <= 255 Then
                MyText = MyText + KeyPressed(e)
                e.Handled = True
                e.SuppressKeyPress = True
            End If

            If e.KeyCode = Keys.Back Then
                If MyText.Length > 0 Then
                    MyText = MyText.Remove(MyText.Length - 1)
                End If

            End If
        End If

        'hotbar
        If e.KeyCode = Keys.NumPad1 Then
            spellnum = Player(MyIndex).Hotbar(1).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad2 Then
            spellnum = Player(MyIndex).Hotbar(2).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad3 Then
            spellnum = Player(MyIndex).Hotbar(3).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad4 Then
            spellnum = Player(MyIndex).Hotbar(4).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad5 Then
            spellnum = Player(MyIndex).Hotbar(5).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad6 Then
            spellnum = Player(MyIndex).Hotbar(6).Slot

            If spellnum <> 0 Then
                Call CastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad7 Then
            spellnum = Player(MyIndex).Hotbar(7).Slot

            If spellnum <> 0 Then
                CastSpell(spellnum)
            End If
        End If

        'admin
        If e.KeyCode = Keys.Insert Then
            If Player(MyIndex).Access > 0 Then
                SendRequestAdmin()
            End If
        End If
        'hide gui
        If e.KeyCode = Keys.F10 Then
            HideGui = True
        End If

        If e.KeyCode = Keys.Enter Then
            HandlePressEnter()
            CheckMapGetItem()
            inChat = Not inChat
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub picscreen_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles picscreen.KeyUp

        If e.KeyCode = Keys.S Then VbKeyDown = False
        If e.KeyCode = Keys.W Then VbKeyUp = False
        If e.KeyCode = Keys.A Then VbKeyLeft = False
        If e.KeyCode = Keys.D Then VbKeyRight = False
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = False
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = False

        Dim keyData As Keys = e.KeyData
        If IsAcceptable(keyData) Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If

    End Sub

#End Region

#Region "Options"

    Private Sub scrlVolume_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scrlVolume.ValueChanged
        Options.Volume = scrlVolume.Value

        MaxVolume = Options.Volume

        lblVolume.Text = "Volume: " & Options.Volume

        If Not MusicPlayer Is Nothing Then MusicPlayer.Volume() = MaxVolume

    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        'music
        If optMOn.Checked = True Then
            Options.Music = 1
            ' start music playing
            PlayMusic(Trim$(Map.Music))
        Else
            Options.Music = 0
            ' stop music playing
            StopMusic()
            CurMusic = ""
        End If

        'sound
        If optSOn.Checked = True Then
            Options.Sound = 1
        Else
            Options.Sound = 0
            StopSound()
        End If

        'screensize
        Options.ScreenSize = cmbScreenSize.SelectedIndex

        ' save to config.ini
        SaveOptions()

        'reload options
        LoadOptions()

        RePositionGUI()

        pnlOptions.Visible = False
    End Sub


#End Region

#Region "Shop Code"
    Private Sub lblShopBuy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblShopBuy.Click
        If ShopAction = 1 Then Exit Sub
        ShopAction = 1 ' buying an item
        AddText("Click on the item in the shop you wish to buy.", Yellow)
    End Sub

    Private Sub lblShopSell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblShopSell.Click
        If ShopAction = 2 Then Exit Sub
        ShopAction = 2 ' selling an item
        AddText("Double-click on the item in your inventory you wish to sell.", Yellow)
    End Sub

    Private Sub pnlShopItems_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlShopItems.MouseDown
        Dim shopItem As Long
        Dim x As Long, y As Long
        x = e.Location.X
        y = e.Location.Y
        shopItem = IsShopItem(x, y)

        If shopItem > 0 Then
            Select Case ShopAction
                Case 0 ' no action, give cost
                    With Shop(InShop).TradeItem(shopItem)
                        AddText("You can buy this item for " & .CostValue & " " & Trim$(Item(.CostItem).Name) & ".", Yellow)
                    End With
                Case 1 ' buy item
                    ' buy item code
                    BuyItem(shopItem)
            End Select
        End If
    End Sub

    Private Sub pnlShopItems_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlShopItems.MouseMove
        Dim shopslot As Long
        Dim x2 As Long, y2 As Long
        Dim x As Long, y As Long

        x = e.Location.X
        y = e.Location.Y

        shopslot = IsShopItem(x, y)

        If shopslot <> 0 Then
            x2 = x + pnlShop.Left + pnlShopItems.Left + 3
            y2 = y + pnlShop.Top + pnlShopItems.Left + 19
            UpdateDescWindow(Shop(InShop).TradeItem(shopslot).Item, Shop(InShop).TradeItem(shopslot).ItemValue)
            LastItemDesc = Shop(InShop).TradeItem(shopslot).Item
            ShowItemDesc = True
            Exit Sub
        End If

        ShowItemDesc = False
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

    Private Sub pnlShopItems_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlShopItems.Paint
        'do nothing
    End Sub

    Private Sub lblLeaveShop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblLeaveShop.Click
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CCloseShop)
        SendData(Buffer.ToArray())
        Buffer = Nothing
        pnlShop.Visible = False
        InShop = 0
        ShopAction = 0
    End Sub
#End Region

#Region "Bank Code"
    Private Sub pnlBank_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles pnlBank.DoubleClick
        Dim bankNum As Long

        DragBankSlotNum = 0

        bankNum = IsBankItem(BankX, BankY)
        If bankNum <> 0 Then
            If GetBankItemNum(bankNum) = ITEM_TYPE_NONE Then Exit Sub

            If Item(GetBankItemNum(bankNum)).Type = ITEM_TYPE_CURRENCY Or Item(GetBankItemNum(bankNum)).Stackable = 1 Then
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

    Private Sub pnlBank_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlBank.MouseDown
        Dim bankNum As Long
        Dim x As Long, y As Long
        x = e.Location.X
        y = e.Location.Y
        bankNum = IsBankItem(x, y)

        If bankNum <> 0 Then

            If e.Button = MouseButtons.Left Then
                DragBankSlotNum = bankNum
            End If
        End If
    End Sub

    Private Sub pnlBank_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlBank.MouseMove
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
                UpdateDescWindow(Bank.Item(bankNum).Num, Bank.Item(bankNum).Value)
                ShowItemDesc = True
                Exit Sub
            End If
        End If

        ShowItemDesc = False
        LastBankDesc = 0
    End Sub

    Private Sub pnlBank_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlBank.MouseUp
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

    Private Sub pnlBank_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlBank.Paint
        'do nothing
    End Sub

    Private Sub lblLeaveBank_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblLeaveBank.Click
        CloseBank()
    End Sub
#End Region

#Region "Trade Code"
    Private Sub pnlYourTrade_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles pnlYourTrade.DoubleClick
        Dim TradeNum As Long

        TradeNum = IsTradeItem(TradeX, TradeY, True)

        If TradeNum <> 0 Then
            UntradeItem(TradeNum)
        End If
    End Sub

    Private Sub pnlYourTrade_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlYourTrade.MouseMove
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
            UpdateDescWindow(GetPlayerInvItemNum(MyIndex, TradeYourOffer(TradeNum).Num), TradeYourOffer(TradeNum).Value)
            LastItemDesc = GetPlayerInvItemNum(MyIndex, TradeYourOffer(TradeNum).Num) ' set it so you don't re-set values
            ShowItemDesc = True
            Exit Sub
        End If

        ShowItemDesc = False
        LastItemDesc = 0 ' no item was last loaded
    End Sub

    Private Sub pnlYourTrade_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlYourTrade.Paint
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

    Private Sub pnlTheirTrade_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pnlTheirTrade.MouseMove
        Dim TradeNum As Long
        Dim x As Long, y As Long
        x = e.Location.X
        y = e.Location.Y

        TradeNum = IsTradeItem(x, y, False)

        If TradeNum <> 0 Then
            x = x + pnlTrade.Left + pnlTheirTrade.Left + 4
            y = y + pnlTrade.Top + pnlTheirTrade.Top + 4
            UpdateDescWindow(TradeTheirOffer(TradeNum).Num, TradeTheirOffer(TradeNum).Value)
            LastItemDesc = TradeTheirOffer(TradeNum).Num ' set it so you don't re-set values
            ShowItemDesc = True
            Exit Sub
        End If

        ShowItemDesc = False
        LastItemDesc = 0 ' no item was last loaded
    End Sub

    Private Sub pnlTheirTrade_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlTheirTrade.Paint
        'do nothing
    End Sub

    Private Sub lblAcceptTrade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblAcceptTrade.Click
        AcceptTrade()
    End Sub

    Private Sub lblDeclineTrade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblDeclineTrade.Click
        DeclineTrade()
    End Sub
#End Region

#Region "Quest Code"

    Private Sub lblQuestClose_Click(sender As Object, e As EventArgs) Handles lblQuestClose.Click
        pnlQuestSpeech.Visible = False
        lblQuestExtra.Visible = False
        lblQuestAccept.Visible = False
        lblQuestAccept.Tag = vbNullString
        lblQuestSay.Text = "-"
    End Sub

    Private Sub lblQuestAccept_Click(sender As Object, e As EventArgs) Handles lblQuestAccept.Click
        PlayerHandleQuest(lblQuestAccept.Tag, 1)
        pnlQuestSpeech.Visible = False
        lblQuestAccept.Visible = False
        lblQuestAccept.Tag = vbNullString
        lblQuestSay.Text = "-"
        RefreshQuestLog()
    End Sub

    Private Sub lblQuestExtra_Click(sender As Object, e As EventArgs) Handles lblQuestExtra.Click
        RunQuestDialogueExtraLabel()
    End Sub

    Private Sub lstQuestLog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstQuestLog.SelectedIndexChanged
        UpdateQuestWindow = True
    End Sub

    Private Sub lblQuestLogClose_Click(sender As Object, e As EventArgs) Handles lblQuestLogClose.Click
        ResetQuestLog()
        pnlQuestLog.Visible = False
    End Sub

    Private Sub lblAbandonQuest_Click(sender As Object, e As EventArgs) Handles lblAbandonQuest.Click
        Dim QuestNum As Long = GetQuestNum(Trim$(lstQuestLog.Text))
        If Trim$(lstQuestLog.Text) = vbNullString Then Exit Sub

        PlayerHandleQuest(QuestNum, 2)
        ResetQuestLog()
        pnlQuestLog.Visible = False
    End Sub

#End Region

#Region "Misc"

    Private Sub tmrShake_Tick(sender As Object, e As EventArgs) Handles tmrShake.Tick
        If ShakeCount < 10 Then

            If LastDir = 0 Then
                picscreen.Location = New Point(picscreen.Location.X + 20, picscreen.Location.Y)
                LastDir = 1
            Else
                picscreen.Location = New Point(picscreen.Location.X - 20, picscreen.Location.Y)
                LastDir = 0
            End If

        Else
            picscreen.Location = New Point(0, 0)
            ShakeCount = 0
            tmrShake.Enabled = False
        End If

        ShakeCount += 1
    End Sub

    Private ReadOnly NonAcceptableKeys() As Keys = {Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9}

    Public Function IsAcceptable(ByVal keyData As Keys) As Boolean
        Dim index As Integer = Array.IndexOf(NonAcceptableKeys, keyData)
        Return index >= 0
    End Function

#End Region

#Region "Event Code"
    Private Sub lblResponse1_Click(sender As Object, e As EventArgs) Handles lblResponse1.Click
        Dim buffer As ByteBuffer

        If EventChoiceVisible(1) Then
            'Response1
            buffer = New ByteBuffer
            buffer.WriteLong(ClientPackets.CEventChatReply)
            buffer.WriteLong(EventReplyID)
            buffer.WriteLong(EventReplyPage)
            buffer.WriteLong(1)
            SendData(buffer.ToArray)
            buffer = Nothing
            ClearEventChat()
            InEvent = False
            Exit Sub
        End If

    End Sub

    Private Sub lblResponse2_Click(sender As Object, e As EventArgs) Handles lblResponse2.Click
        Dim buffer As ByteBuffer

        If EventChoiceVisible(2) Then
            'Response2
            buffer = New ByteBuffer
            buffer.WriteLong(ClientPackets.CEventChatReply)
            buffer.WriteLong(EventReplyID)
            buffer.WriteLong(EventReplyPage)
            buffer.WriteLong(2)
            SendData(buffer.ToArray)
            buffer = Nothing
            ClearEventChat()
            InEvent = False
            Exit Sub
        End If

    End Sub

    Private Sub lblResponse3_Click(sender As Object, e As EventArgs) Handles lblResponse3.Click
        Dim buffer As ByteBuffer

        If EventChoiceVisible(3) Then
            'Response3
            buffer = New ByteBuffer
            buffer.WriteLong(ClientPackets.CEventChatReply)
            buffer.WriteLong(EventReplyID)
            buffer.WriteLong(EventReplyPage)
            buffer.WriteLong(3)
            SendData(buffer.ToArray)
            buffer = Nothing
            ClearEventChat()
            InEvent = False
            Exit Sub
        End If
    End Sub

    Private Sub lblResponse4_Click(sender As Object, e As EventArgs) Handles lblResponse4.Click
        Dim buffer As ByteBuffer

        If EventChoiceVisible(4) Then
            'Response4
            buffer = New ByteBuffer
            buffer.WriteLong(ClientPackets.CEventChatReply)
            buffer.WriteLong(EventReplyID)
            buffer.WriteLong(EventReplyPage)
            buffer.WriteLong(4)
            SendData(buffer.ToArray)
            buffer = Nothing
            ClearEventChat()
            InEvent = False
            Exit Sub
        End If
    End Sub

    Private Sub lblEventContinue_Click(sender As Object, e As EventArgs) Handles lblEventContinue.Click
        Dim buffer As ByteBuffer

        'continue
        buffer = New ByteBuffer
        buffer.WriteLong(ClientPackets.CEventChatReply)
        buffer.WriteLong(EventReplyID)
        buffer.WriteLong(EventReplyPage)
        buffer.WriteLong(0)
        SendData(buffer.ToArray)
        buffer = Nothing
        ClearEventChat()
        InEvent = False
        Exit Sub

    End Sub



#End Region

End Class