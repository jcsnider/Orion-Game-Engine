Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMenu
    Inherits Form
#Region "Form Functions"
    ''' <summary>
    ''' clean up and close the game.
    ''' </summary>
    Private Sub FrmMenu_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed
        DestroyGame()
    End Sub

    ''' <summary>
    ''' On load, get GUI ready.
    ''' </summary>
    Private Sub Frmmenu_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Strings.Init(0, "English")

        LoadMenuGraphics()

        pnlLoad.Width = 730
        pnlLoad.Height = 550

        Width = 730
        pnlLogin.Top = pnlMainMenu.Top
        pnlLogin.Left = pnlMainMenu.Left

        pnlNewChar.Top = pnlMainMenu.Top
        pnlNewChar.Left = pnlMainMenu.Left

        pnlRegister.Top = pnlMainMenu.Top
        pnlRegister.Left = pnlMainMenu.Left

        pnlCredits.Top = pnlMainMenu.Top
        pnlCredits.Left = pnlMainMenu.Left

        pnlIPConfig.Top = pnlMainMenu.Top
        pnlIPConfig.Left = pnlMainMenu.Left

        pnlCharSelect.Top = pnlMainMenu.Top
        pnlCharSelect.Left = pnlMainMenu.Left

        If started = False Then Call Startup()

        Connect()

    End Sub

    ''' <summary>
    ''' Draw Char select when its needed.
    ''' </summary>
    Private Sub PnlCharSelect_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlCharSelect.VisibleChanged
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Shows the IP config.
    ''' </summary>
    Private Sub LblServerStatus_Click(sender As Object, e As EventArgs) Handles lblServerStatus.Click
        pnlCreditsVisible = False
        pnlLoginVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = False

        txtIP.Text = Options.IP
        txtPort.Text = Options.Port

        pnlIPConfig.Visible = True
    End Sub
#End Region

#Region "Draw Functions"
    ''' <summary>
    ''' Preload the images in the menu.
    ''' </summary>
    Public Sub LoadMenuGraphics()

        'main menu
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\menu" & GFX_EXT) Then
            BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\menu" & GFX_EXT)
        End If

        'main menu buttons
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT) Then
            btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnExit.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnNewChar.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnUseChar.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnDelChar.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
            btnSaveIP.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
        End If

        'main menu panels
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT) Then
            pnlMainMenu.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
            pnlLogin.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
            pnlNewChar.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
            pnlCharSelect.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
            pnlRegister.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
            pnlCredits.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
            pnlIPConfig.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\panel" & GFX_EXT)
        End If

        'logo
        If FileExist(Application.StartupPath & GFX_GUI_PATH & "Menu\logo" & GFX_EXT) Then
            picLogo.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\logo" & GFX_EXT)
        End If

        'set text for controls from language file

        'main
        lblStatusHeader.Text = Strings.Get("mainmenu", "serverstatus")
        lblNewsHeader.Text = Strings.Get("mainmenu", "newsheader")
        lblNews.Text = Strings.Get("mainmenu", "news")
        btnPlay.Text = Strings.Get("mainmenu", "buttonplay")
        btnRegister.Text = Strings.Get("mainmenu", "buttonregister")
        btnCredits.Text = Strings.Get("mainmenu", "buttoncredits")
        btnExit.Text = Strings.Get("mainmenu", "buttonexit")

        'logon panel
        lblLogin.Text = Strings.Get("mainmenu", "login")
        lblLoginName.Text = Strings.Get("mainmenu", "loginname")
        lblLoginPass.Text = Strings.Get("mainmenu", "loginpass")
        chkSavePass.Text = Strings.Get("mainmenu", "loginchkbox")
        btnLogin.Text = Strings.Get("mainmenu", "loginbutton")

        'new char panel
        lblNewChar.Text = Strings.Get("mainmenu", "newchar")
        lblNewCharName.Text = Strings.Get("mainmenu", "newcharname")
        lblNewCharClass.Text = Strings.Get("mainmenu", "newcharclass")
        lblNewCharGender.Text = Strings.Get("mainmenu", "newchargender")
        rdoMale.Text = Strings.Get("mainmenu", "newcharmale")
        rdoFemale.Text = Strings.Get("mainmenu", "newcharfemale")
        lblNewCharSprite.Text = Strings.Get("mainmenu", "newcharsprite")
        btnCreateCharacter.Text = Strings.Get("mainmenu", "newcharbutton")

        'char select
        lblCharSelect.Text = Strings.Get("mainmenu", "selchar")
        btnNewChar.Text = Strings.Get("mainmenu", "selcharnew")
        btnUseChar.Text = Strings.Get("mainmenu", "selcharuse")
        btnDelChar.Text = Strings.Get("mainmenu", "selchardel")

        'new account
        lblNewAccount.Text = Strings.Get("mainmenu", "newacc")
        lblNewAccName.Text = Strings.Get("mainmenu", "newaccname")
        lblNewAccPass.Text = Strings.Get("mainmenu", "newaccpass")
        lblNewAccPass2.Text = Strings.Get("mainmenu", "newaccpass2")

        'credits
        lblCreditsTop.Text = Strings.Get("mainmenu", "credits")

        'ip config
        lblIpConfig.Text = Strings.Get("mainmenu", "ipconfig")
        lblIpAdress.Text = Strings.Get("mainmenu", "ipconfigadres")
        lblPort.Text = Strings.Get("mainmenu", "ipconfigport")
    End Sub

    ''' <summary>
    ''' Draw the Character for new char creation.
    ''' </summary>
    Sub DrawCharacter()
        If pnlNewChar.Visible = True Then
            Dim g As Graphics = pnlNewChar.CreateGraphics
            Dim filename As String
            Dim srcRect As Rectangle
            Dim destRect As Rectangle
            Dim charwidth As Integer
            Dim charheight As Integer

            If newCharClass = 0 Then newCharClass = 1
            If newCharSprite = 0 Then newCharSprite = 1

            If rdoMale.Checked = True Then
                filename = Application.StartupPath & GFX_PATH & "characters\" & Classes(newCharClass).MaleSprite(newCharSprite) & GFX_EXT
            Else
                filename = Application.StartupPath & GFX_PATH & "characters\" & Classes(newCharClass).FemaleSprite(newCharSprite) & GFX_EXT
            End If

            Dim charsprite As Bitmap = New Bitmap(filename)

            charwidth = charsprite.Width / 4
            charheight = charsprite.Height / 4

            srcRect = New Rectangle(0, 0, charwidth, charheight)
            destRect = New Rectangle(placeholderforsprite.Left, placeholderforsprite.Top, charwidth, charheight)

            charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

            If charwidth > 32 Then
                lblnextcharleft = (100 - (64 - charwidth))
            Else
                lblnextcharleft = 100
            End If
            pnlNewChar.Refresh()
            g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)
            g.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Draw the character for the char select screen.
    ''' </summary>
    Sub DrawCharacterSelect()
        Dim g As Graphics
        Dim srcRect As Rectangle
        Dim destRect As Rectangle

        If pnlCharSelect.Visible = True Then
            Dim filename As String
            Dim charwidth As Integer, charheight As Integer

            'first
            If CharSelection(1).Sprite > 0 Then
                g = picChar1.CreateGraphics

                filename = Application.StartupPath & GFX_PATH & "characters\" & CharSelection(1).Sprite & GFX_EXT

                Dim charsprite As Bitmap = New Bitmap(filename)

                charwidth = charsprite.Width / 4
                charheight = charsprite.Height / 4

                srcRect = New Rectangle(0, 0, charwidth, charheight)
                destRect = New Rectangle(0, 0, charwidth, charheight)

                charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

                picChar1.Refresh()
                g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

                If SelectedChar = 1 Then
                    g.DrawRectangle(Pens.Red, New Rectangle(0, 0, charwidth - 1, charheight))
                End If

                g.Dispose()
            Else
                picChar1.BorderStyle = BorderStyle.FixedSingle
                picChar1.Refresh()
            End If

            'second
            If CharSelection(2).Sprite > 0 Then
                g = picChar2.CreateGraphics

                filename = Application.StartupPath & GFX_PATH & "characters\" & CharSelection(2).Sprite & GFX_EXT

                Dim charsprite As Bitmap = New Bitmap(filename)

                charwidth = charsprite.Width / 4
                charheight = charsprite.Height / 4

                srcRect = New Rectangle(0, 0, charwidth, charheight)
                destRect = New Rectangle(0, 0, charwidth, charheight)

                charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

                picChar2.Refresh()
                g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

                If SelectedChar = 2 Then
                    g.DrawRectangle(Pens.Red, New Rectangle(0, 0, charwidth - 1, charheight))
                End If

                g.Dispose()
            Else
                picChar2.BorderStyle = BorderStyle.FixedSingle
                picChar2.Refresh()
            End If

            'third
            If CharSelection(3).Sprite > 0 Then
                g = picChar3.CreateGraphics

                filename = Application.StartupPath & GFX_PATH & "characters\" & CharSelection(3).Sprite & GFX_EXT

                Dim charsprite As Bitmap = New Bitmap(filename)

                charwidth = charsprite.Width / 4
                charheight = charsprite.Height / 4

                srcRect = New Rectangle(0, 0, charwidth, charheight)
                destRect = New Rectangle(0, 0, charwidth, charheight)

                charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

                picChar3.Refresh()
                g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

                If SelectedChar = 3 Then
                    g.DrawRectangle(Pens.Red, New Rectangle(0, 0, charwidth - 1, charheight))
                End If

                g.Dispose()
            Else
                picChar3.BorderStyle = BorderStyle.FixedSingle
                picChar3.Refresh()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Stop the NewChar panel from repainting itself.
    ''' </summary>
    Private Sub PnlNewChar_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlNewChar.Paint
        'nada here
    End Sub
#End Region

#Region "Credits"
    ''' <summary>
    ''' This timer handles the scrolling credits.
    ''' </summary>
    Private Sub TmrCredits_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrCredits.Tick
        Dim credits As String
        Dim filepath As String
        filepath = Application.StartupPath & "\Data\credits.txt"
        lblScrollingCredits.Top = 177
        If pnlCreditsVisible = True Then
            tmrCredits.Enabled = False
            credits = GetFileContents(filepath)
            lblScrollingCredits.Text = "" & vbNewLine & credits
            Do Until pnlCreditsVisible = False
                lblScrollingCredits.Top = lblScrollingCredits.Top - 1
                If lblScrollingCredits.Bottom <= lblCreditsTop.Bottom Then
                    lblScrollingCredits.Top = 177
                End If
                DoEvents()
                Threading.Thread.Sleep(100)
            Loop
        End If
    End Sub
#End Region

#Region "Login"
    ''' <summary>
    ''' Handles press enter on login name txtbox.
    ''' </summary>
    Private Sub TxtLogin_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLogin.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnLogin_Click(Me, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' Handles press enter on login password txtbox.
    ''' </summary>
    Private Sub TxtPassword_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnLogin_Click(Me, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' Handle the SavePas checkbox.
    ''' </summary>
    Private Sub ChkSavePass_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkSavePass.CheckedChanged
        chkSavePassChecked = chkSavePass.Checked
    End Sub
#End Region

#Region "Char Creation"
    ''' <summary>
    ''' Changes selected class.
    ''' </summary>
    Private Sub CmbClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClass.SelectedIndexChanged
        newCharClass = cmbClass.SelectedIndex + 1
        txtDescription.Text = Classes(newCharClass).Desc
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Switches to male gender.
    ''' </summary>
    Private Sub RdoMale_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdoMale.CheckedChanged
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Switches to female gender.
    ''' </summary>
    Private Sub RdoFemale_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdoFemale.CheckedChanged
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Switches sprite for selected class to next one, if any.
    ''' </summary>
    Private Sub LblNextChar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblNextChar.Click
        newCharSprite = newCharSprite + 1
        If rdoMale.Checked = True Then
            If newCharSprite > Classes(newCharClass).MaleSprite.Length - 1 Then newCharSprite = 1
        ElseIf rdoFemale.Checked = True Then
            If newCharSprite > Classes(newCharClass).FemaleSprite.Length - 1 Then newCharSprite = 1
        End If
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Switches sprite for selected class to previous one, if any.
    ''' </summary>
    Private Sub LblPrevChar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblPrevChar.Click
        newCharSprite = newCharSprite - 1
        If rdoMale.Checked = True Then
            If newCharSprite = 0 Then newCharSprite = Classes(newCharClass).MaleSprite.Length - 1
        ElseIf rdoFemale.Checked = True Then
            If newCharSprite = 0 Then newCharSprite = Classes(newCharClass).FemaleSprite.Length - 1
        End If
        DrawCharacter()
    End Sub

    ''' <summary>
    ''' Initial drawing of new char.
    ''' </summary>
    Private Sub PnlNewChar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlNewChar.VisibleChanged
        DrawCharacter()
    End Sub
#End Region

#Region "Buttons"
    ''' <summary>
    ''' Handle Play button press.
    ''' </summary>
    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        If IsConnected() = True Then
            PlaySound("Click.ogg")
            pnlRegisterVisible = False
            pnlLoginVisible = True
            pnlCharCreateVisible = False
            pnlCreditsVisible = False
            pnlIPConfig.Visible = False
            txtLogin.Focus()
            If Options.SavePass = True Then
                txtLogin.Text = Options.Username
                txtPassword.Text = Options.Password
                chkSavePass.Checked = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnPlay_MouseEnter(sender As Object, e As EventArgs) Handles btnPlay.MouseEnter
        btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnPlay_MouseLeave(sender As Object, e As EventArgs) Handles btnPlay.MouseLeave
        btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handle Register button press.
    ''' </summary>
    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If IsConnected() = True Then
            PlaySound("Click.ogg")
            pnlRegisterVisible = True
            pnlLoginVisible = False
            pnlCharCreateVisible = False
            pnlCreditsVisible = False
            pnlIPConfig.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnRegister_MouseEnter(sender As Object, e As EventArgs) Handles btnRegister.MouseEnter
        btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnRegister_MouseLeave(sender As Object, e As EventArgs) Handles btnRegister.MouseLeave
        btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handle Credits button press.
    ''' </summary>
    Private Sub BtnCredits_Click(sender As Object, e As EventArgs) Handles btnCredits.Click
        PlaySound("Click.ogg")
        If pnlCreditsVisible = False Then
            tmrCredits.Enabled = True
        End If
        pnlCreditsVisible = True
        pnlLoginVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = False
        pnlIPConfig.Visible = False
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnCredits_MouseEnter(sender As Object, e As EventArgs) Handles btnCredits.MouseEnter
        btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnCredits_MouseLeave(sender As Object, e As EventArgs) Handles btnCredits.MouseLeave
        btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handles Exit button press.
    ''' </summary>
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        PlaySound("Click.ogg")
        DestroyGame()
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handles Login button press.
    ''' </summary>
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsLoginLegal(txtLogin.Text, txtPassword.Text) Then
            MenuState(MENU_STATE_LOGIN)
        End If
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handles CreateAccount button press.
    ''' </summary>
    Private Sub BtnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim Name As String
        Dim Password As String
        Dim PasswordAgain As String
        Name = Trim$(txtRuser.Text)
        Password = Trim$(txtRPass.Text)
        PasswordAgain = Trim$(txtRPass2.Text)

        If IsLoginLegal(Name, Password) Then
            If Password <> PasswordAgain Then
                MsgBox("Passwords don't match.")
                Exit Sub
            End If

            If Not IsStringLegal(Name) Then Exit Sub

            MenuState(MENU_STATE_NEWACCOUNT)
        End If
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnCreateAccount_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseEnter
        btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnCreateAccount_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseLeave
        btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handles CreateCharacter button press.
    ''' </summary>
    Private Sub BtnCreateCharacter_Click(sender As Object, e As EventArgs) Handles btnCreateCharacter.Click
        MenuState(MENU_STATE_ADDCHAR)
    End Sub

    ''' <summary>
    ''' Changes to hover state on button.
    ''' </summary>
    Private Sub BtnCreateCharacter_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateCharacter.MouseEnter
        btnCreateCharacter.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Changes to normal state on button.
    ''' </summary>
    Private Sub BtnCreateCharacter_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateCharacter.MouseLeave
        btnCreateCharacter.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    ''' <summary>
    ''' Handles SaveIP button press.
    ''' </summary>
    Private Sub BtnSaveIP_Click(sender As Object, e As EventArgs) Handles btnSaveIP.Click
        Options.IP = txtIP.Text
        Options.Port = txtPort.Text

        pnlIPConfig.Visible = False
        SaveOptions()
    End Sub

    ''' <summary>
    ''' Handles selecting character 1.
    ''' </summary>
    Private Sub PicChar1_Click(sender As Object, e As EventArgs) Handles picChar1.Click
        SelectedChar = 1
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Handles selecting character 2.
    ''' </summary>
    Private Sub PicChar2_Click(sender As Object, e As EventArgs) Handles picChar2.Click
        SelectedChar = 2
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Handles selecting character 3.
    ''' </summary>
    Private Sub PicChar3_Click(sender As Object, e As EventArgs) Handles picChar3.Click
        SelectedChar = 3
        DrawCharacterSelect()
    End Sub

    ''' <summary>
    ''' Handles NewChar button press.
    ''' </summary>
    Private Sub BtnNewChar_Click(sender As Object, e As EventArgs) Handles btnNewChar.Click
        Dim i As Integer, NewSelectedChar As Byte

        NewSelectedChar = 0

        For i = 1 To MaxChars
            If CharSelection(i).Name = "" Then
                newselectedchar = i
                Exit For
            End If
        Next

        If NewSelectedChar > 0 Then
            SelectedChar = NewSelectedChar
        End If

        pnlCharCreateVisible = True
        pnlCharSelectVisible = False
        DrawChar = True
    End Sub

    ''' <summary>
    ''' Handles UseChar button press.
    ''' </summary>
    Private Sub BtnUseChar_Click(sender As Object, e As EventArgs) Handles btnUseChar.Click
        pnlloadvisible = True
        frmmenuvisible = False

        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CUseChar)
        buffer.WriteInteger(SelectedChar)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub

    ''' <summary>
    ''' Handles DelChar button press.
    ''' </summary>
    Private Sub BtnDelChar_Click(sender As Object, e As EventArgs) Handles btnDelChar.Click
        Dim buffer As ByteBuffer

        Dim result1 As DialogResult = MessageBox.Show("Sure you want to delete character " & SelectedChar & "?", "You sure?", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            buffer = New ByteBuffer
            buffer.WriteInteger(ClientPackets.CDelChar)
            buffer.WriteInteger(SelectedChar)
            SendData(buffer.ToArray)
        End If

        buffer = Nothing
    End Sub

#End Region

End Class