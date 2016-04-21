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

        LoadGuiGraphics()
        CheckDirectories()
        Connect()
    End Sub

    Private Function StringToArray(ByVal s As String, Optional ByVal style As System.Globalization.NumberStyles = Nothing) As Byte()
        Dim oEncoder As New System.Text.ASCIIEncoding()
        Dim bytes As Byte() = oEncoder.GetBytes(s)
        Return bytes
    End Function

    Private Sub lblCreateAcc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblCreateAcc.Click
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

    Sub DrawCharacter()
        If pnlNewChar.Visible = True Then
            Dim g As Graphics = pnlNewChar.CreateGraphics
            Dim filename As String
            Dim srcRect As Rectangle
            Dim destRect As Rectangle
            Dim charwidth As Long
            Dim charheight As Long

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
                lblnextcharleft = (370 - (64 - charwidth))
            Else
                lblnextcharleft = 370
            End If
            pnlNewChar.Refresh()
            g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)
            g.Dispose()
        End If
    End Sub

    Private Sub lblSendLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
        If isLoginLegal(txtLogin.Text, txtPassword.Text) Then
            MenuState(MENU_STATE_LOGIN)
        End If
    End Sub

    Private Sub lblCreateChar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblCreateChar.Click
        MenuState(MENU_STATE_ADDCHAR)
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
        Static i As Long
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
            lblSendLogin_Click(Me, Nothing)
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblSendLogin_Click(Me, Nothing)
        End If
    End Sub

    Private Sub pnlNewChar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlNewChar.VisibleChanged
        DrawCharacter()
    End Sub

    Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPlay.Click
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

    Private Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegister.Click
        If IsConnected() = True Then
            PlaySound("Click.ogg")
            pnlRegisterVisible = True
            pnlLoginVisible = False
            pnlCharCreateVisible = False
            pnlCreditsVisible = False
            pnlIPConfig.Visible = False
        End If
    End Sub

    Private Sub btnCredits_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCredits.Click
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

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        PlaySound("Click.ogg")
        DestroyGame()
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

    Private Sub lblSaveIP_Click(sender As Object, e As EventArgs) Handles lblSaveIP.Click
        Options.IP = txtIP.Text
        Options.Port = txtPort.Text

        pnlIPConfig.Visible = False
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If isLoginLegal(txtLogin.Text, txtPassword.Text) Then
            MenuState(MENU_STATE_LOGIN)
        End If
    End Sub

End Class
