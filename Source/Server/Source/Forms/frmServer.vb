Public Class frmServer

    Private Sub frmServer_Closing(ByVal sender As Object, ByVal e As EventArgs) Handles Me.FormClosing
        DestroyServer()
    End Sub

    Public Function donothing()
        Return Nothing
    End Function

    Private Function ArrayToString(ByVal bytes() As Byte, Optional ByVal format As String = Nothing) As String
        If bytes.Length = 0 Then Return String.Empty
        Dim sb As New System.Text.StringBuilder(bytes.Length * 4)
        For Each b As Byte In bytes
            sb.Append(b.ToString(format))
            sb.Append(","c)
        Next
        sb.Length -= 1
        Return sb.ToString()
    End Function

    Private Sub frmServer_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        If NotifyIcon1 Is Nothing Then NotifyIcon1 = New NotifyIcon
        Select Case Me.WindowState
            Case FormWindowState.Minimized
                NotifyIcon1.Icon = (Me.Icon)
                NotifyIcon1.Visible = True
                Me.Visible = False
            Case FormWindowState.Normal
                NotifyIcon1.Icon = (Me.Icon)
                NotifyIcon1.Visible = False
        End Select
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NotifyIcon1.MouseClick
        notifyMenu.Show(New Point(MousePosition.X, MousePosition.Y))
    End Sub

    Private Sub NotifyIcon1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles NotifyIcon1.MouseMove
        NotifyIcon1.Text = GetPlayersOnline() & " Players are Online"
    End Sub

    Private Sub lstView_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstView.MouseClick
        If e.Button = MouseButtons.Right Then
            lstviewmenu.Show(New Point(MousePosition.X, MousePosition.Y))
        End If
    End Sub

    Private Sub MakeAdminToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MakeAdminToolStripMenuItem.Click
        'setplayer()
    End Sub

    Private Sub KickToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles KickToolStripMenuItem.Click
        AlertMsg(lstView.SelectedItems(0).Index + 1, "You have been kicked from " & Options.Game_Name)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Visible = True
        NotifyIcon1.Visible = False
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ShowServerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShowServerToolStripMenuItem.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ShutdownToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShutdownToolStripMenuItem1.Click
        DestroyServer()
    End Sub

    Private Sub KickToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles KickToolStripMenuItem1.Click
        Dim Name As String
        Name = Me.lstView.Items(lstView.SelectedItems(0).Index).SubItems(3).Text

        If Not Name = "Not Playing" Then
            AlertMsg(FindPlayer(Name), "You have been kicked by the server owner!")
        End If
    End Sub

    Private Sub DisconnectToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DisconnectToolStripMenuItem.Click
        Dim Name As String
        Name = Me.lstView.Items(lstView.SelectedItems(0).Index).SubItems(3).Text

        If Not Name = "Not Playing" Then
            CloseSocket(FindPlayer(Name))
        End If
    End Sub

    Private Sub BanToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BanToolStripMenuItem1.Click
        Dim Name As String
        Name = Me.lstView.Items(lstView.SelectedItems(0).Index).SubItems(3).Text

        If Not Name = "Not Playing" Then
            ServerBanIndex(FindPlayer(Name))
        End If
    End Sub

    Private Sub MakeAdminToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MakeAdminToolStripMenuItem1.Click
        Dim Name As String
        Name = Me.lstView.Items(lstView.SelectedItems(0).Index).SubItems(3).Text

        If Not Name = "Not Playing" Then
            SetPlayerAccess(FindPlayer(Name), 4)
            SendPlayerData(FindPlayer(Name))
            'PlayerMsg(FindPlayer(Name), "You have been granted administrator access.")
        End If
    End Sub

    Private Sub RemoveAdminToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveAdminToolStripMenuItem1.Click
        Dim Name As String
        Name = Me.lstView.Items(lstView.SelectedItems(0).Index).SubItems(3).Text

        If Not Name = "Not Playing" Then
            SetPlayerAccess(FindPlayer(Name), 0)
            SendPlayerData(FindPlayer(Name))
            'PlayerMsg(FindPlayer(Name), "You have had your administrator access revoked.")
        End If
    End Sub

    Private Sub btnReloadClasses_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadClasses.Click
        Dim i As Integer
        LoadClasses()
        TextAdd("All classes reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendClasses(i)
            End If
        Next
    End Sub

    Private Sub btnReloadMaps_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadMaps.Click
        Dim i As Integer
        LoadMaps()
        TextAdd("All maps reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                PlayerWarp(i, GetPlayerMap(i), GetPlayerX(i), GetPlayerY(i))
            End If
        Next
    End Sub

    Private Sub btnReloadSkills_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadSkills.Click
        Dim i As Integer
        LoadSkills()
        TextAdd("All skills reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendSkills(i)
            End If
        Next
    End Sub

    Private Sub btnReloadShops_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadShops.Click
        Dim i As Integer
        LoadShops()
        TextAdd("All shops reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendShops(i)
            End If
        Next
    End Sub

    Private Sub btnReloadNPCs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadNPCs.Click
        Dim i As Integer
        LoadNpcs()
        TextAdd("All npcs reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendNpcs(i)
            End If
        Next
    End Sub

    Private Sub btnReloadItems_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadItems.Click
        Dim i As Integer
        LoadItems()
        TextAdd("All items reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendItems(i)
            End If
        Next
    End Sub

    Private Sub btnReloadResources_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadResources.Click
        Dim i As Integer
        LoadResources()
        TextAdd("All Resources reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendResources(i)
            End If
        Next
    End Sub

    Private Sub btnReloadAnimations_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReloadAnimations.Click
        Dim i As Integer
        LoadAnimations()
        TextAdd("All Animations reloaded.")
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SendAnimations(i)
            End If
        Next
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        DestroyServer()
    End Sub

    Private Sub chkServerLog_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkServerLog.CheckedChanged
        If Not chkServerLog.Checked Then
            ServerLog = True
        Else
            ServerLog = False
        End If
    End Sub

    Private Sub txtChat_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtChat.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim$(txtChat.Text)) > 0 Then
                GlobalMsg(txtChat.Text)
                TextAdd("Server: " & txtChat.Text)
                txtChat.Text = ""
            End If
        End If
    End Sub

    Private Sub btnShutDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShutDown.Click
        If isShuttingDown Then
            isShuttingDown = False
            btnShutDown.Text = "Shutdown"
            notifyMenu.Items(1).Text = "Timed Shutdown"
            GlobalMsg("Shutdown canceled.")
        Else
            isShuttingDown = True
            btnShutDown.Text = "Cancel"
            notifyMenu.Items(1).Text = "Cancel"
        End If
    End Sub

    Private Sub TimedShutdownToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TimedShutdownToolStripMenuItem1.Click
        If isShuttingDown Then
            isShuttingDown = False
            btnShutDown.Text = "Shutdown"
            notifyMenu.Items(1).Text = "Timed Shutdown"
            GlobalMsg("Shutdown canceled.")
        Else
            isShuttingDown = True
            btnShutDown.Text = "Cancel"
            notifyMenu.Items(1).Text = "Cancel"
        End If
    End Sub

    Private Sub TabPage1_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles TabPage1.Validated
        Me.txtText.SelectionStart = Me.txtText.TextLength
        Me.txtText.ScrollToCaret()
    End Sub

    Private Sub frmServer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        InitServer()
    End Sub

    Private Sub tmrUpdatePlayerList_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrUpdatePlayerList.Tick
        NeedToUpDatePlayerList = True
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        SaveClasses()
        SaveItems()
        SaveMaps()
        SaveResources()
        SaveSkills()
        SaveAnimations()
        SaveShops()
        SaveNpcs()
        TextAdd("Saved All!")
    End Sub

End Class
