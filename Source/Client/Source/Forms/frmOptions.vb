Public Class frmOptions
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

        If chkHighEnd.Checked Then
            Options.HighEnd = 1
        Else
            Options.HighEnd = 0
        End If

        If chkNpcBars.Checked Then
            Options.ShowNpcBar = 1
        Else
            Options.ShowNpcBar = 0
        End If

        ' save to config.ini
        SaveOptions()

        'reload options
        LoadOptions()

        RePositionGUI()

        Me.Visible = False
    End Sub

#End Region
End Class