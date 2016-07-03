Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMainGame
#Region "Frm Code"
    Dim ShakeCount As Byte, LastDir As Byte

    Private Sub frmMainGame_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        RePositionGUI()

        frmAdmin.Visible = False
    End Sub

    Private Sub frmMainGame_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Disposed
        frmAdmin.Dispose()
        DestroyGame()
    End Sub

    Private Sub frmMainGame_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If inChat = True Then
            If e.KeyCode >= 32 And e.KeyCode <= 255 And Not e.KeyCode = Keys.Enter Then
                If MyText = Nothing Then MyText = ""
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

            If e.KeyCode = Keys.Space Then
                CheckMapGetItem()
            End If
        End If

        If e.KeyCode = Keys.Enter Then
            HandlePressEnter()

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
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad2 Then
            spellnum = Player(MyIndex).Hotbar(2).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad3 Then
            spellnum = Player(MyIndex).Hotbar(3).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad4 Then
            spellnum = Player(MyIndex).Hotbar(4).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad5 Then
            spellnum = Player(MyIndex).Hotbar(5).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad6 Then
            spellnum = Player(MyIndex).Hotbar(6).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad7 Then
            spellnum = Player(MyIndex).Hotbar(7).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
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
        If Not inChat Then
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
                pnlOptions.Visible = Not pnlOptions.Visible
            End If
            'spell window
            If e.KeyCode = Keys.K Then
                pnlSpellsVisible = Not pnlSpellsVisible
            End If
        End If

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
                        PlayerSearch(CurX, CurY, 0)
                    Else
                        ' trading
                        SendTradeRequest(Player(myTarget).Name)
                    End If
                    pnlRClickVisible = False

                    ' right click
                ElseIf e.Button = MouseButtons.Right Then
                    If ShiftDown Or VbKeyShift = True Then
                        ' admin warp if we're pressing shift and right clicking
                        If GetPlayerAccess(MyIndex) >= 2 Then AdminWarp(CurX, CurY)
                    Else
                        ' rightclick menu
                        PlayerSearch(CurX, CurY, 1)
                    End If
                    FurnitureSelected = 0
                End If
            End If

        End If

        CheckGuiMouseDown(e.X, e.Y, e)

        If Editor = 0 And Not InMapEditor And Not Adminvisible Then Focus()

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

        CurMouseX = e.Location.X
        CurMouseY = e.Location.Y

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
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad2 Then
            spellnum = Player(MyIndex).Hotbar(2).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad3 Then
            spellnum = Player(MyIndex).Hotbar(3).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad4 Then
            spellnum = Player(MyIndex).Hotbar(4).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad5 Then
            spellnum = Player(MyIndex).Hotbar(5).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad6 Then
            spellnum = Player(MyIndex).Hotbar(6).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
            End If
        End If
        If e.KeyCode = Keys.NumPad7 Then
            spellnum = Player(MyIndex).Hotbar(7).Slot

            If spellnum <> 0 Then
                PlayerCastSpell(spellnum)
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

#Region "Quest Code"

    Private Sub lblAbandonQuest_Click(sender As Object, e As EventArgs)
        'Dim QuestNum As Long = GetQuestNum(Trim$(lstQuestLog.Text))
        'If Trim$(lstQuestLog.Text) = vbNullString Then Exit Sub

        'PlayerHandleQuest(QuestNum, 2)
        'ResetQuestLog()
        'pnlQuestLog.Visible = False
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

#Region "Crafting"

    Private Sub chkKnownOnly_CheckedChanged(sender As Object, e As EventArgs)
        CraftingInit()
    End Sub

    Private Sub tmrCraft_Tick(sender As Object, e As EventArgs) Handles tmrCraft.Tick
        CraftProgressValue = CraftProgressValue + (100 / Recipe(GetRecipeIndex(RecipeNames(SelectedRecipe))).CreateTime)

        If CraftProgressValue >= 100 Then
            tmrCraft.Enabled = False
        End If

    End Sub

#End Region
End Class