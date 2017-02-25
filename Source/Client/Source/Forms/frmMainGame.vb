Imports System.Windows.Forms
Imports Orion

Public Class FrmMainGame
#Region "Frm Code"
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    Private Sub FrmMainGame_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        RePositionGUI()

        frmAdmin.Visible = False
    End Sub

    Private Sub FrmMainGame_Closing(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub

    Private Sub FrmMainGame_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ChatInput.ProcessCharacter(e)
    End Sub

    Private Sub FrmMainGame_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If (ChatInput.ProcessKey(e)) Then
            If (e.KeyCode = Keys.Enter) Then
                HandlePressEnter()
            End If
        End If

        If ChatInput.Active Then
            If (e.KeyCode = Keys.Enter) Then
                HandlePressEnter()
            End If
        Else
            If e.KeyCode = Keys.S Then VbKeyDown = True
            If e.KeyCode = Keys.W Then VbKeyUp = True
            If e.KeyCode = Keys.A Then VbKeyLeft = True
            If e.KeyCode = Keys.D Then VbKeyRight = True
            If e.KeyCode = Keys.ShiftKey Then VbKeyShift = True
            If e.KeyCode = Keys.ControlKey Then VbKeyControl = True
            If e.KeyCode = Keys.Alt Then VbKeyAlt = True

            If e.KeyCode = Keys.Space Then
                CheckMapGetItem()
            End If
        End If
    End Sub

    Private Sub FrmMainGame_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        Dim skillnum As Integer
        If e.KeyCode = Keys.S Then VbKeyDown = False
        If e.KeyCode = Keys.W Then VbKeyUp = False
        If e.KeyCode = Keys.A Then VbKeyLeft = False
        If e.KeyCode = Keys.D Then VbKeyRight = False
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = False
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = False
        If e.KeyCode = Keys.Alt Then VbKeyAlt = False

        'hotbar
        If e.KeyCode = Keys.NumPad1 Then
            skillnum = Player(MyIndex).Hotbar(1).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad2 Then
            skillnum = Player(MyIndex).Hotbar(2).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad3 Then
            skillnum = Player(MyIndex).Hotbar(3).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad4 Then
            skillnum = Player(MyIndex).Hotbar(4).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad5 Then
            skillnum = Player(MyIndex).Hotbar(5).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad6 Then
            skillnum = Player(MyIndex).Hotbar(6).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad7 Then
            skillnum = Player(MyIndex).Hotbar(7).Slot

            If skillnum <> 0 Then
                PlayerCastSkill(skillnum)
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
            HideGui = Not HideGui
        End If

        'lets check for keys for inventory etc
        If Not ChatInput.Active Then
            'inventory
            If e.KeyCode = Keys.I Then
                pnlInventoryVisible = Not pnlInventoryVisible
            End If
            'Character window
            If e.KeyCode = Keys.C Then
                pnlCharacterVisible = Not pnlCharacterVisible
            End If
            'quest window
            If e.KeyCode = Keys.Q Then
                pnlQuestLogVisible = Not pnlQuestLogVisible
            End If
            'options window
            If e.KeyCode = Keys.O Then
                frmOptions.Visible = Not frmOptions.Visible
            End If
            'skill window
            If e.KeyCode = Keys.K Then
                pnlSkillsVisible = Not pnlSkillsVisible
            End If
        End If

    End Sub

    Private Sub LblCurrencyOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblCurrencyOk.Click
        If IsNumeric(txtCurrency.Text) Then
            Select Case CurrencyMenu
                Case 1 ' drop item
                    SendDropItem(tmpCurrencyItem, Val(txtCurrency.Text))
                Case 2 ' deposit item
                    DepositItem(tmpCurrencyItem, Val(txtCurrency.Text))
                Case 3 ' withdraw item
                    WithdrawItem(tmpCurrencyItem, Val(txtCurrency.Text))
                Case 4 ' trade item
                    TradeItem(tmpCurrencyItem, Val(txtCurrency.Text))
            End Select
        End If

        pnlCurrency.Visible = False
        tmpCurrencyItem = 0
        txtCurrency.Text = ""
        CurrencyMenu = 0 ' clear
    End Sub
#End Region

#Region "PicScreen Code"
    Private Sub Picscreen_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.MouseDown
        If Not CheckGuiClick(e.X, e.Y, e) Then

            If InMapEditor Then
                frmEditor_MapEditor.MapEditorMouseDown(e.Button, e.X, e.Y, False)
            End If

            ' left click
            If e.Button = MouseButtons.Left Then

                ' if we're in the middle of choose the trade target or not
                If Not TradeRequest Then
                    If PetAlive(MyIndex) Then
                        If IsInBounds() Then
                            PetMove(CurX, CurY)
                        End If
                    End If
                    ' targetting
                    PlayerSearch(CurX, CurY, 0)
                Else
                    ' trading
                    SendTradeRequest(Player(myTarget).Name)
                End If
                pnlRClickVisible = False
                ShowPetStats = False

                ' right click
            ElseIf e.Button = MouseButtons.Right Then
                If ShiftDown Or VbKeyShift = True Then
                    ' admin warp if we're pressing shift and right clicking
                    If GetPlayerAccess(MyIndex) >= 2 Then AdminWarp(CurX, CurY)
                Else
                    ' rightclick menu
                    If PetAlive(MyIndex) Then
                        If IsInBounds() AndAlso CurX = Player(MyIndex).Pet.X AndAlso CurY = Player(MyIndex).Pet.Y Then
                            ShowPetStats = True
                        End If
                    Else
                        PlayerSearch(CurX, CurY, 1)
                    End If
                End If
                FurnitureSelected = 0
            End If
        End If

        CheckGuiMouseDown(e.X, e.Y, e)

        If Not frmAdmin.Visible Or Not frmOptions.Visible Then Focus()

    End Sub

    Private Sub Picscreen_DoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.DoubleClick
        CheckGuiDoubleClick(e.X, e.Y, e)
    End Sub

    Private Overloads Sub Picscreen_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picscreen.Paint
        'This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
        Exit Sub
    End Sub

    Private Sub Picscreen_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.MouseMove
        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)
        CurMouseX = e.Location.X
        CurMouseY = e.Location.Y
        CheckGuiMove(e.X, e.Y)

        If InMapEditor Then
            If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
                frmEditor_MapEditor.MapEditorMouseDown(e.Button, e.X, e.Y)
            End If
        End If

    End Sub

    Private Sub Picscreen_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picscreen.MouseUp
        CurX = TileView.left + ((e.Location.X + Camera.Left) \ PIC_X)
        CurY = TileView.top + ((e.Location.Y + Camera.Top) \ PIC_Y)
        CheckGuiMouseUp(e.X, e.Y, e)
    End Sub

    Private Sub Picscreen_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles picscreen.KeyDown
        Dim num As Integer
        If e.KeyCode = Keys.S Then VbKeyDown = True
        If e.KeyCode = Keys.W Then VbKeyUp = True
        If e.KeyCode = Keys.A Then VbKeyLeft = True
        If e.KeyCode = Keys.D Then VbKeyRight = True
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = True
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = True
        If e.KeyCode = Keys.Alt Then VbKeyAlt = True

        'hotbar
        If e.KeyCode = Keys.NumPad1 Then
            num = Player(MyIndex).Hotbar(1).Slot

            If num <> 0 Then
                SendUseHotbarSlot(1)
            End If
        End If
        If e.KeyCode = Keys.NumPad2 Then
            num = Player(MyIndex).Hotbar(2).Slot

            If num <> 0 Then
                SendUseHotbarSlot(2)
            End If
        End If
        If e.KeyCode = Keys.NumPad3 Then
            num = Player(MyIndex).Hotbar(3).Slot

            If num <> 0 Then
                SendUseHotbarSlot(3)
            End If
        End If
        If e.KeyCode = Keys.NumPad4 Then
            num = Player(MyIndex).Hotbar(4).Slot

            If num <> 0 Then
                SendUseHotbarSlot(4)
            End If
        End If
        If e.KeyCode = Keys.NumPad5 Then
            num = Player(MyIndex).Hotbar(5).Slot

            If num <> 0 Then
                SendUseHotbarSlot(5)
            End If
        End If
        If e.KeyCode = Keys.NumPad6 Then
            num = Player(MyIndex).Hotbar(6).Slot

            If num <> 0 Then
                SendUseHotbarSlot(6)
            End If
        End If
        If e.KeyCode = Keys.NumPad7 Then
            num = Player(MyIndex).Hotbar(7).Slot

            If num <> 0 Then
                SendUseHotbarSlot(7)
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
            HideGui = Not HideGui
        End If

        If e.KeyCode = Keys.Enter Then
            ChatInput.ProcessKey(e)
            HandlePressEnter()
            CheckMapGetItem()
        End If
    End Sub

    Private Sub Picscreen_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles picscreen.KeyUp

        If e.KeyCode = Keys.S Then VbKeyDown = False
        If e.KeyCode = Keys.W Then VbKeyUp = False
        If e.KeyCode = Keys.A Then VbKeyLeft = False
        If e.KeyCode = Keys.D Then VbKeyRight = False
        If e.KeyCode = Keys.ShiftKey Then VbKeyShift = False
        If e.KeyCode = Keys.ControlKey Then VbKeyControl = False
        If e.KeyCode = Keys.Alt Then VbKeyAlt = False

        Dim keyData As Keys = e.KeyData
        If IsAcceptable(keyData) Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If

    End Sub

#End Region

#Region "Quest Code"

    Private Sub LblAbandonQuest_Click(sender As Object, e As EventArgs)
        'Dim QuestNum As Integer = GetQuestNum(Trim$(lstQuestLog.Text))
        'If Trim$(lstQuestLog.Text) = "" Then Exit Sub

        'PlayerHandleQuest(QuestNum, 2)
        'ResetQuestLog()
        'pnlQuestLog.Visible = False
    End Sub

#End Region

#Region "Misc"

    Private ReadOnly NonAcceptableKeys() As Keys = {Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9}

    Public Function IsAcceptable(ByVal keyData As Keys) As Boolean
        Dim index As Integer = Array.IndexOf(NonAcceptableKeys, keyData)
        Return index >= 0
    End Function

#End Region

#Region "Crafting"
    Private Sub ChkKnownOnly_CheckedChanged(sender As Object, e As EventArgs)
        CraftingInit()
    End Sub
#End Region
End Class