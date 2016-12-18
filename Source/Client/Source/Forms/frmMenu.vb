Imports System.Drawing
Imports System.Windows.Forms

Public Class frmMenu
    Inherits Form

    Private Sub frmMenu_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed
        DestroyGame()
    End Sub

    Private Sub Frmmenu_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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

        LoadGuiGraphics()
        Connect()
    End Sub

    Private Function StringToArray(ByVal s As String, Optional ByVal style As System.Globalization.NumberStyles = Nothing) As Byte()
        Dim oEncoder As New System.Text.ASCIIEncoding()
        Dim bytes As Byte() = oEncoder.GetBytes(s)
        Return bytes
    End Function

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

    Private Sub pnlNewChar_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlNewChar.Paint
        'nada here
    End Sub

    Private Sub tmrCredits_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrCredits.Tick
        Dim credits As String
        Dim filepath As String
        filepath = Application.StartupPath & "\Data Files\credits.txt"
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

    Private Sub chkSavePass_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkSavePass.CheckedChanged
        chkSavePassChecked = chkSavePass.Checked
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClass.SelectedIndexChanged
        newCharClass = cmbClass.SelectedIndex + 1
        txtDescription.Text = Classes(newCharClass).Desc
        DrawCharacter()
    End Sub

    Private Sub rdoMale_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdoMale.CheckedChanged
        DrawCharacter()
    End Sub

    Private Sub rdoFemale_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdoFemale.CheckedChanged
        DrawCharacter()
    End Sub

    Private Sub lblNextChar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblNextChar.Click
        newCharSprite = newCharSprite + 1
        If rdoMale.Checked = True Then
            If newCharSprite > UBound(Classes(newCharClass).MaleSprite) Then newCharSprite = 1
        ElseIf rdoFemale.Checked = True Then
            If newCharSprite > UBound(Classes(newCharClass).FemaleSprite) Then newCharSprite = 1
        End If
        DrawCharacter()
    End Sub

    Private Sub lblPrevChar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblPrevChar.Click
        newCharSprite = newCharSprite - 1
        If rdoMale.Checked = True Then
            If newCharSprite = 0 Then newCharSprite = UBound(Classes(newCharClass).MaleSprite)
        ElseIf rdoFemale.Checked = True Then
            If newCharSprite = 0 Then newCharSprite = UBound(Classes(newCharClass).FemaleSprite)
        End If
        DrawCharacter()
    End Sub

    Private Sub tmrConnect_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrConnect.Tick
        Static i As Integer
        If IsConnected() = True Then
            lblServerStatus.ForeColor = Color.LightGreen
            lblServerStatus.Text = "Online"
        Else
            lblServerStatus.ForeColor = Color.Red
            i = i + 1
            If i = 5 Then
                Connect()
                lblServerStatus.Text = "Reconnecting"
                i = 0
            Else
                lblServerStatus.Text = "Offline"
            End If
        End If
    End Sub

    Private Sub txtLogin_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLogin.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(Me, Nothing)
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(Me, Nothing)
        End If
    End Sub

    Private Sub pnlNewChar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlNewChar.VisibleChanged
        DrawCharacter()
    End Sub

    Private Sub pnlCharSelect_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlCharSelect.VisibleChanged
        DrawCharacterSelect()
    End Sub

    Private Sub lblServerStatus_Click(sender As Object, e As EventArgs) Handles lblServerStatus.Click
        pnlCreditsVisible = False
        pnlLoginVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = False

        txtIP.Text = Options.IP
        txtPort.Text = Options.Port

        pnlIPConfig.Visible = True
    End Sub

#Region "Buttons"
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
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

    Private Sub btnPlay_MouseEnter(sender As Object, e As EventArgs) Handles btnPlay.MouseEnter
        btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnPlay_MouseLeave(sender As Object, e As EventArgs) Handles btnPlay.MouseLeave
        btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If IsConnected() = True Then
            PlaySound("Click.ogg")
            pnlRegisterVisible = True
            pnlLoginVisible = False
            pnlCharCreateVisible = False
            pnlCreditsVisible = False
            pnlIPConfig.Visible = False
        End If
    End Sub

    Private Sub btnRegister_MouseEnter(sender As Object, e As EventArgs) Handles btnRegister.MouseEnter
        btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnRegister_MouseLeave(sender As Object, e As EventArgs) Handles btnRegister.MouseLeave
        btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnCredits_Click(sender As Object, e As EventArgs) Handles btnCredits.Click
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

    Private Sub btnCredits_MouseEnter(sender As Object, e As EventArgs) Handles btnCredits.MouseEnter
        btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnCredits_MouseLeave(sender As Object, e As EventArgs) Handles btnCredits.MouseLeave
        btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        PlaySound("Click.ogg")
        DestroyGame()
    End Sub

    Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If isLoginLegal(txtLogin.Text, txtPassword.Text) Then
            MenuState(MENU_STATE_LOGIN)
        End If
    End Sub

    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        Dim Name As String
        Dim Password As String
        Dim PasswordAgain As String
        Name = Trim$(txtRuser.Text)
        Password = Trim$(txtRPass.Text)
        PasswordAgain = Trim$(txtRPass2.Text)

        If isLoginLegal(Name, Password) Then
            If Password <> PasswordAgain Then
                MsgBox("Passwords don't match.")
                Exit Sub
            End If

            If Not isStringLegal(Name) Then Exit Sub

            MenuState(MENU_STATE_NEWACCOUNT)
        End If
    End Sub

    Private Sub btnCreateAccount_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseEnter
        btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnCreateAccount_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseLeave
        btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnCreateCharacter_Click(sender As Object, e As EventArgs) Handles btnCreateCharacter.Click
        MenuState(MENU_STATE_ADDCHAR)
    End Sub

    Private Sub btnCreateCharacter_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateCharacter.MouseEnter
        btnCreateCharacter.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button_hover" & GFX_EXT)
    End Sub

    Private Sub btnCreateCharacter_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateCharacter.MouseLeave
        btnCreateCharacter.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_GUI_PATH & "Menu\button" & GFX_EXT)
    End Sub

    Private Sub btnSaveIP_Click(sender As Object, e As EventArgs) Handles btnSaveIP.Click
        Options.IP = txtIP.Text
        Options.Port = txtPort.Text

        pnlIPConfig.Visible = False
        SaveOptions()
    End Sub

    Private Sub picChar1_Click(sender As Object, e As EventArgs) Handles picChar1.Click
        SelectedChar = 1
        DrawCharacterSelect()
    End Sub

    Private Sub picChar2_Click(sender As Object, e As EventArgs) Handles picChar2.Click
        SelectedChar = 2
        DrawCharacterSelect()
    End Sub

    Private Sub picChar3_Click(sender As Object, e As EventArgs) Handles picChar3.Click
        SelectedChar = 3
        DrawCharacterSelect()
    End Sub

    Private Sub btnNewChar_Click(sender As Object, e As EventArgs) Handles btnNewChar.Click
        pnlCharCreateVisible = True
        pnlCharSelectVisible = False
        DrawChar = True
    End Sub

    Private Sub btnUseChar_Click(sender As Object, e As EventArgs) Handles btnUseChar.Click
        frmloadvisible = True
        frmmenuvisible = False

        Dim buffer As ByteBuffer
        buffer = New ByteBuffer
        buffer.WriteInteger(ClientPackets.CUseChar)
        buffer.WriteInteger(SelectedChar)
        SendData(buffer.ToArray)

        buffer = Nothing
    End Sub

    Private Sub btnDelChar_Click(sender As Object, e As EventArgs) Handles btnDelChar.Click
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
