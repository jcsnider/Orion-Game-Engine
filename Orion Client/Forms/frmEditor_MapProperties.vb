Imports System.Windows.Forms

Public Class frmEditor_MapProperties
    Public cmbNpcs() As cmbNpc
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmEditor_MapProperties_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Dim X As Long
        'Dim Y As Long
        'Dim i As Long
        'Dim di As New IO.DirectoryInfo(Application.StartupPath & MUSIC_PATH)
        'Dim aryFi As IO.FileInfo() = di.GetFiles("*.*")
        'Dim fi As IO.FileInfo
        'ReDim cmbNpcs(0 To 30)
        'Dim StartX
        'Dim StartY
        'StartX = 6
        'StartY = 19


        'txtName.Text = Trim$(Map.Name)
        '' find the music we have set
        'lstMusic.Items.Clear()
        'lstMusic.Items.Add("None")

        'For Each fi In aryFi
        '    lstMusic.Items.Add(fi.Name)
        'Next

        'If Trim$(Map.Music) = "None" Then
        '    lstMusic.SelectedIndex = 0
        'Else
        '    For i = 1 To lstMusic.Items.Count
        '        If lstMusic.Items(i - 1).ToString = Trim$(Map.Music) Then
        '            lstMusic.SelectedIndex = i - 1
        '            Exit For
        '        End If
        '    Next
        'End If

        '' rest of it
        'txtUp.Text = CStr(Map.Up)
        'txtDown.Text = CStr(Map.Down)
        'txtLeft.Text = CStr(Map.Left)
        'txtRight.Text = CStr(Map.Right)
        'cmbMoral.SelectedIndex = Map.Moral
        'txtBootMap.Text = CStr(Map.BootMap)
        'txtBootX.Text = CStr(Map.BootX)
        'txtBootY.Text = CStr(Map.BootY)


        'For i = 1 To 15
        '    cmbNpcs(i) = New cmbNpc
        '    cmbNpcs(i).cmbNpc = New ComboBox
        '    cmbNpcs(i).cmbNpc.Width = 133
        '    cmbNpcs(i).cmbNpc.Height = 21
        '    cmbNpcs(i).cmbNpc.Left = StartX
        '    cmbNpcs(i).cmbNpc.Top = StartY + ((i - 1) * 27)
        '    Me.Controls.Add(cmbNpcs(i).cmbNpc)
        '    cmbNpcs(i).cmbNpc.DropDownStyle = ComboBoxStyle.DropDownList
        '    cmbNpcs(i).cmbNpc.Parent = Me.fraNpcs
        'Next
        'StartX = 165
        'For i = 16 To 30
        '    cmbNpcs(i) = New cmbNpc
        '    cmbNpcs(i).cmbNpc = New ComboBox
        '    cmbNpcs(i).cmbNpc.Width = 133
        '    cmbNpcs(i).cmbNpc.Height = 21
        '    cmbNpcs(i).cmbNpc.Left = StartX
        '    cmbNpcs(i).cmbNpc.Top = StartY + ((i - 16) * 27)
        '    Me.Controls.Add(cmbNpcs(i).cmbNpc)
        '    cmbNpcs(i).cmbNpc.DropDownStyle = ComboBoxStyle.DropDownList
        '    cmbNpcs(i).cmbNpc.Parent = Me.fraNpcs
        'Next

        'For X = 1 To MAX_MAP_NPCS
        '    cmbNpcs(X).cmbNpc.Items.Add("No NPC")
        'Next


        'For Y = 1 To MAX_NPCS
        '    For X = 1 To MAX_MAP_NPCS
        '        cmbNpcs(X).cmbNpc.Items.Add(Y & ": " & Trim$(Npc(Y).Name))
        '    Next
        'Next

        'For i = 1 To MAX_MAP_NPCS
        '    cmbNpcs(i).cmbNpc.SelectedIndex = Map.Npc(i)
        'Next

        'lblMap.Text = "Current map: " & GetPlayerMap(MyIndex)
        'txtMaxX.Text = Map.MaxX
        'txtMaxY.Text = Map.MaxY
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
        Dim i As Long
        Dim sTemp As Long
        Dim X As Long, x2 As Long
        Dim Y As Long, y2 As Long
        Dim tempArr(,) As TileRec ' , tempArr2(,) As ExTileRec

        If Not IsNumeric(txtMaxX.Text) Then txtMaxX.Text = Map.MaxX
        If Val(txtMaxX.Text) < MAX_MAPX Then txtMaxX.Text = MAX_MAPX
        If Val(txtMaxX.Text) > MAX_BYTE Then txtMaxX.Text = MAX_BYTE
        If Not IsNumeric(txtMaxY.Text) Then txtMaxY.Text = Map.MaxY
        If Val(txtMaxY.Text) < MAX_MAPY Then txtMaxY.Text = MAX_MAPY
        If Val(txtMaxY.Text) > MAX_BYTE Then txtMaxY.Text = MAX_BYTE

        With Map
            .Name = Trim$(txtName.Text)
            If lstMusic.SelectedIndex >= 0 Then
                .Music = lstMusic.Items(lstMusic.SelectedIndex).ToString
            Else
                .Music = vbNullString
            End If
            .Up = Val(txtUp.Text)
            .Down = Val(txtDown.Text)
            .Left = Val(txtLeft.Text)
            .Right = Val(txtRight.Text)
            .Moral = cmbMoral.SelectedIndex
            .BootMap = Val(txtBootMap.Text)
            .BootX = Val(txtBootX.Text)
            .BootY = Val(txtBootY.Text)

            For i = 1 To MAX_MAP_NPCS
                If cmbNpcs(i).cmbNpc.SelectedIndex > 0 Then
                    sTemp = InStr(1, Trim$(cmbNpcs(i).cmbNpc.Text), ":", vbTextCompare)

                    If Len(Trim$(cmbNpcs(i).cmbNpc.Text)) = sTemp Then
                        cmbNpcs(i).cmbNpc.SelectedIndex = 0
                    End If
                End If
            Next

            For i = 1 To MAX_MAP_NPCS
                .Npc(i) = cmbNpcs(i).cmbNpc.SelectedIndex
            Next

            ' set the data before changing it
            tempArr = Map.Tile.Clone
            'tempArr2 = Map.exTile.Clone

            x2 = Map.MaxX
            y2 = Map.MaxY
            ' change the data
            .MaxX = Val(txtMaxX.Text)
            .MaxY = Val(txtMaxY.Text)
            ReDim Map.Tile(0 To .MaxX, 0 To .MaxY)
            'ReDim Map.exTile(0 To .MaxX, 0 To .MaxY)

            ReDim Autotile(0 To .MaxX, 0 To .MaxY)

            If x2 > .MaxX Then x2 = .MaxX
            If y2 > .MaxY Then y2 = .MaxY

            For X = 0 To .MaxX
                For Y = 0 To .MaxY
                    ReDim .Tile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
                    ReDim .Tile(X, Y).Autotile(0 To MapLayer.Layer_Count - 1)
                    'ReDim .exTile(X, Y).Layer(0 To ExMapLayer.Layer_Count - 1)
                    'ReDim .exTile(X, Y).Autotile(0 To ExMapLayer.Layer_Count - 1)

                    ReDim Autotile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
                    ' ReDim Autotile(X, Y).ExLayer(0 To ExMapLayer.Layer_Count - 1)

                    If X <= x2 Then
                        If Y <= y2 Then
                            .Tile(X, Y) = tempArr(X, Y)
                            '.exTile(X, Y) = tempArr2(X, Y)
                        End If
                    End If
                Next
            Next

            ClearTempTile()
        End With

        Me.Dispose()
    End Sub

    Private Sub lstMusic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMusic.SelectedIndexChanged

    End Sub
End Class
Public Class cmbNpc
    Public WithEvents cmbNpc As ComboBox

End Class