Imports System.Drawing

Module modUpdateUI

    Public GameDestroyed As Boolean
    Public ReloadFrmMain As Boolean
    Public pnlRegisterVisible As Boolean
    Public pnlCharCreateVisible As Boolean
    Public pnlLoginVisible As Boolean
    Public pnlCreditsVisible As Boolean
    Public frmmenuvisible As Boolean
    Public frmmaingamevisible As Boolean
    Public frmloadvisible As Boolean
    Public lblnextcharleft As Long
    Public cmbclass() As String
    Public txtChatAdd As String
    Public chkSavePassChecked As Boolean
    Public tempUserName As String
    Public tempPassword As String

    Public VbKeyRight As Boolean
    Public VbKeyLeft As Boolean
    Public VbKeyUp As Boolean
    Public VbKeyDown As Boolean
    Public VbKeyShift As Boolean
    Public VbKeyControl As Boolean

    Public picHpWidth As Long
    Public picManaWidth As Long
    Public picEXPWidth As Long

    Public lblHPText As String
    Public lblManaText As String
    Public lblEXPText As String

    'Editors
    Public InitMapEditor As Boolean
    Public InitItemEditor As Boolean
    Public InitResourceEditor As Boolean
    Public InitNPCEditor As Boolean
    Public InitSpellEditor As Boolean
    Public InitShopEditor As Boolean
    Public InitAnimationEditor As Boolean

    Public UpdateCharacterPanel As Boolean

    Public NeedToOpenShop As Boolean
    Public NeedToOpenShopNum As Long
    Public NeedToOpenBank As Boolean
    Public NeedToOpenTrade As Boolean
    Public NeedtoCloseTrade As Boolean

    Public Tradername As String


    Sub DrawStatBars()
        Dim g As Graphics = Graphics.FromImage(StatBarBackbuffer)
        Dim fnt As New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        g.DrawImage(EmptyHPBar, New Point(12, 12))
        g.DrawImage(EmptyManaBar, New Point(12, 35))
        g.DrawImage(EmptyEXPBar, New Point(12, 58))
        g.DrawImage(HPBar, New Rectangle(12, 15, picHpWidth, HPBar.Height), New Rectangle(0, 0, picHpWidth, HPBar.Height), GraphicsUnit.Pixel)
        g.DrawImage(ManaBar, New Rectangle(12, 38, picManaWidth, ManaBar.Height), New Rectangle(0, 0, picManaWidth, ManaBar.Height), GraphicsUnit.Pixel)
        g.DrawImage(EXPBar, New Rectangle(12, 61, picEXPWidth, EXPBar.Height), New Rectangle(0, 0, picEXPWidth, EXPBar.Height), GraphicsUnit.Pixel)
        g.DrawString(lblHPText, fnt, New SolidBrush(Color.Black), 40, 15)
        g.DrawString(lblManaText, fnt, New SolidBrush(Color.Black), 40, 38)
        g.DrawString(lblEXPText, fnt, New SolidBrush(Color.Black), 40, 63)
        g.Dispose()

        g = frmMainGame.picGeneral.CreateGraphics
        g.DrawImage(StatBarBackbuffer, New Point(0, 0))
        g.Dispose()
    End Sub
End Module
