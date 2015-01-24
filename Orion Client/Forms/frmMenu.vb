Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmMenu
    Inherits System.Windows.Forms.Form

    Private Sub frmMenu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DestroyGame()
    End Sub
    Private Sub Frmmenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckDirectories()
        Connect()
    End Sub
    Private Function StringToArray(ByVal s As String, Optional ByVal style As System.Globalization.NumberStyles = Nothing) As Byte()
        Dim oEncoder As New System.Text.ASCIIEncoding()
        Dim bytes As Byte() = oEncoder.GetBytes(s)
        Return bytes
    End Function

    Private Sub lblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExit.Click
        DestroyGame()
    End Sub

    Private Sub lblCreateAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateAcc.Click
        Dim Name As String
        Dim Password As String
        Dim PasswordAgain As String
        Name = Trim$(txtRuser.Text)
        Password = Trim$(txtRPass.Text)
        PasswordAgain = Trim$(txtRPass2.Text)

        If isLoginLegal(Name, Password) Then
            If Password <> PasswordAgain Then
                Call MsgBox("Passwords don't match.")
                Exit Sub
            End If

            If Not isStringLegal(Name) Then
                Exit Sub
            End If

            Call MenuState(MENU_STATE_NEWACCOUNT)
        End If
    End Sub

    Private Sub lblRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRegister.Click
        pnlRegisterVisible = True
        pnlLoginVisible = False
        pnlCharCreateVisible = False
        pnlCreditsVisible = False
    End Sub
    Sub DrawCharacter()
        If pnlNewChar.Visible = True Then
            Dim g As Graphics = Me.pnlNewChar.CreateGraphics
            Dim filename As String
            Dim srcRect As Rectangle
            Dim destRect As Rectangle
            Dim charwidth As Long
            Dim charheight As Long

            If newCharClass = 0 Then newCharClass = 1
            If newCharSprite = 0 Then newCharSprite = 1

            If rdoMale.Checked = True Then
                filename = Application.StartupPath & GFX_PATH & "characters\" & CStr(Classes(newCharClass).MaleSprite(newCharSprite)) & GFX_EXT
            Else
                filename = Application.StartupPath & GFX_PATH & "characters\" & CStr(Classes(newCharClass).FemaleSprite(newCharSprite)) & GFX_EXT
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

    Private Sub rdoFemale_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        newCharSprite = 1
        pnlNewChar.Refresh()
        DrawCharacter()
    End Sub

    Private Sub rdoMale_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        newCharSprite = 1
        pnlNewChar.Refresh()
        DrawCharacter()
    End Sub
    Private Sub lblPrevChar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If newCharSprite = 1 Then
            If rdoMale.Checked = True Then
                newCharSprite = UBound(Classes(newCharClass).MaleSprite)
            Else
                newCharSprite = UBound(Classes(newCharClass).FemaleSprite)
            End If
        Else
            newCharSprite = newCharSprite - 1
        End If
        pnlNewChar.Refresh()
        DrawCharacter()
    End Sub

    Private Sub cmbClass_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        newCharSprite = 1
        newCharClass = cmbClass.SelectedIndex + 1
        pnlNewChar.Refresh()
        DrawCharacter()
    End Sub

    Private Sub lblLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogin.Click
        pnlRegisterVisible = False
        pnlLoginVisible = True
        pnlCharCreateVisible = False
        pnlCreditsVisible = False
        txtLogin.Focus()
        If Options.SavePass = True Then
            Me.txtLogin.Text = Options.Username
            Me.txtPassword.Text = Options.Password
            Me.chkSavePass.Checked = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlNewChar.Visible = True
    End Sub

    Private Sub lblSendLogin_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSendLogin.Click
        If isLoginLegal(txtLogin.Text, txtPassword.Text) Then
            Call MenuState(MENU_STATE_LOGIN)
        End If
    End Sub

    Private Sub lblCreateChar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCreateChar.Click
        Call MenuState(MENU_STATE_ADDCHAR)
    End Sub

    Private Sub pnlNewChar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlNewChar.Paint
        'nada here
    End Sub
    Private Sub tmrCredits_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCredits.Tick
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
                If lblScrollingCredits.Bottom <= lblCreditsTop.Top Then
                    lblScrollingCredits.Top = 177
                End If
                DoEvents()
                System.Threading.Thread.Sleep(100)
            Loop
        End If
    End Sub

    Private Sub lblCredits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCredits.Click
        If pnlCreditsVisible = False Then
            tmrCredits.Enabled = True
        End If
        pnlCreditsVisible = True
        pnlLoginVisible = False
        pnlRegisterVisible = False
        pnlCharCreateVisible = False
    End Sub

    Private Sub chkSavePass_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSavePass.CheckedChanged
        chkSavePassChecked = chkSavePass.Checked
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.SelectedIndexChanged
        newCharClass = cmbClass.SelectedIndex + 1
        DrawCharacter()

    End Sub

    Private Sub rdoMale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMale.CheckedChanged
        DrawCharacter()

    End Sub

    Private Sub rdoFemale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFemale.CheckedChanged
        DrawCharacter()
    End Sub

    Private Sub lblNextChar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNextChar.Click
        newCharSprite = newCharSprite + 1
        If rdoMale.Checked = True Then
            If newCharSprite > UBound(Classes(newCharClass).MaleSprite) Then newCharSprite = 1
        ElseIf rdoFemale.Checked = True Then
            If newCharSprite > UBound(Classes(newCharClass).FemaleSprite) Then newCharSprite = 1
        End If
        DrawCharacter()
    End Sub

    Private Sub lblPrevChar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPrevChar.Click
        newCharSprite = newCharSprite - 1
        If rdoMale.Checked = True Then
            If newCharSprite = 0 Then newCharSprite = UBound(Classes(newCharClass).MaleSprite)
        ElseIf rdoFemale.Checked = True Then
            If newCharSprite = 0 Then newCharSprite = UBound(Classes(newCharClass).FemaleSprite)
        End If
        DrawCharacter()
    End Sub

    Private Sub tmrConnect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrConnect.Tick
        Static i As Long
        If IsConnected() = True Then
            lblServerStatus.ForeColor = Color.Green
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

    Private Sub txtLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLogin.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblSendLogin_Click_1(Me, Nothing)
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblSendLogin_Click_1(Me, Nothing)
        End If
    End Sub

    Private Sub pnlNewChar_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNewChar.VisibleChanged
        DrawCharacter()
    End Sub

    Private Sub tmrDrawCharacter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDrawCharacter.Tick
        DrawCharacter()
    End Sub
End Class
