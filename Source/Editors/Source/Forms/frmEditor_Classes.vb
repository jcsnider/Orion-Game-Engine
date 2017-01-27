Public Class FrmEditor_Classes

#Region "Frm Controls"
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub FrmEditor_Classes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudMaleSprite.Maximum = NumCharacters
        nudFemaleSprite.Maximum = NumCharacters

        DrawPreview()
    End Sub

    Private Sub LstIndex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIndex.SelectedIndexChanged
        If lstIndex.SelectedIndex < 0 Then Exit Sub

        EditorIndex = lstIndex.SelectedIndex + 1

        LoadClassInfo = True
    End Sub

    Private Sub BtnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
        Max_Classes = Max_Classes + 1

        ReDim Preserve Classes(Max_Classes)

        Classes(Max_Classes).Name = "New Class"

        ReDim Classes(Max_Classes).Stat(0 To Stats.Count - 1)

        ReDim Classes(Max_Classes).Vital(0 To Vitals.Count - 1)

        ReDim Classes(Max_Classes).MaleSprite(1)
        ReDim Classes(Max_Classes).FemaleSprite(1)

        For i = 1 To Stats.Count - 1
            Classes(Max_Classes).Stat(i) = 1
        Next

        ReDim Classes(Max_Classes).StartItem(5)
        ReDim Classes(Max_Classes).StartValue(5)

        Classes(Max_Classes).StartMap = 1
        Classes(Max_Classes).StartX = 1
        Classes(Max_Classes).StartY = 1

        ClassEditorInit()
    End Sub

    Private Sub BtnRemoveClass_Click(sender As Object, e As EventArgs) Handles btnRemoveClass.Click
        Dim i As Integer

        'If its The Last class, its simple, just remove and redim
        If EditorIndex = Max_Classes Then
            Max_Classes = Max_Classes - 1
            ReDim Preserve Classes(Max_Classes)
        Else
            'but if its somewhere in the middle, or beginning, it gets harder xD
            For i = 1 To Max_Classes
                'we shift everything thats beneath the selected class, up 1 slot
                Classes(EditorIndex) = Classes(EditorIndex + 1)
            Next

            'and then we remove it, and redim
            Max_Classes = Max_Classes - 1
            ReDim Preserve Classes(Max_Classes)
        End If

        ClassEditorInit()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ClassesEditorOk()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClassesEditorCancel()
    End Sub

    Private Sub TxtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        Classes(EditorIndex).Desc = txtDescription.Text
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpIndex = lstIndex.SelectedIndex
        Classes(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, Trim(Classes(EditorIndex).Name))
        lstIndex.SelectedIndex = tmpIndex
    End Sub
#End Region

#Region "Sprites"
    Private Sub BtnAddMaleSprite_Click(sender As Object, e As EventArgs) Handles btnAddMaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).MaleSprite)

        ReDim Preserve Classes(EditorIndex).MaleSprite(tmpamount + 1)

        Classes(EditorIndex).MaleSprite(tmpamount + 1) = 1

        LoadClassInfo = True
    End Sub

    Private Sub BtnDeleteMaleSprite_Click(sender As Object, e As EventArgs) Handles btnDeleteMaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).MaleSprite)

        ReDim Preserve Classes(EditorIndex).MaleSprite(tmpamount - 1)

        LoadClassInfo = True
    End Sub

    Private Sub BtnAddFemaleSprite_Click(sender As Object, e As EventArgs) Handles btnAddFemaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).FemaleSprite)

        ReDim Preserve Classes(EditorIndex).FemaleSprite(tmpamount + 1)

        Classes(EditorIndex).FemaleSprite(tmpamount + 1) = 1

        LoadClassInfo = True
    End Sub

    Private Sub BtnDeleteFemaleSprite_Click(sender As Object, e As EventArgs) Handles btnDeleteFemaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).FemaleSprite)

        ReDim Preserve Classes(EditorIndex).FemaleSprite(tmpamount - 1)

        LoadClassInfo = True
    End Sub

    Private Sub NudMaleSprite_ValueChanged(sender As Object, e As EventArgs) Handles nudMaleSprite.ValueChanged
        If cmbMaleSprite.SelectedIndex < 0 Then Exit Sub

        Classes(EditorIndex).MaleSprite(cmbMaleSprite.SelectedIndex) = nudMaleSprite.Value

        DrawPreview()
    End Sub

    Private Sub NudFemaleSprite_ValueChanged(sender As Object, e As EventArgs) Handles nudFemaleSprite.ValueChanged
        If cmbFemaleSprite.SelectedIndex < 0 Then Exit Sub

        Classes(EditorIndex).FemaleSprite(cmbFemaleSprite.SelectedIndex) = nudFemaleSprite.Value

        DrawPreview()
    End Sub

    Private Sub CmbMaleSprite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaleSprite.SelectedIndexChanged
        nudMaleSprite.Value = Classes(EditorIndex).MaleSprite(cmbMaleSprite.SelectedIndex)
        DrawPreview()
    End Sub

    Private Sub CmbFemaleSprite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFemaleSprite.SelectedIndexChanged
        nudFemaleSprite.Value = Classes(EditorIndex).FemaleSprite(cmbFemaleSprite.SelectedIndex)
        DrawPreview()
    End Sub

    Sub DrawPreview()
        Dim g As Graphics
        Dim Filename As String
        Dim srcRect As Rectangle, destRect As Rectangle
        Dim charwidth As Integer, charheight As Integer

        If FileExist(Application.StartupPath & GFX_PATH & "Characters\" & nudMaleSprite.Value & GFX_EXT) Then
            g = picMale.CreateGraphics

            Filename = Application.StartupPath & GFX_PATH & "Characters\" & nudMaleSprite.Value & GFX_EXT

            Dim charsprite As Bitmap = New Bitmap(Filename)

            charwidth = charsprite.Width / 4
            charheight = charsprite.Height / 4

            srcRect = New Rectangle(0, 0, charwidth, charheight)
            destRect = New Rectangle(0, 0, charwidth, charheight)

            charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

            picMale.Refresh()
            g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

            g.Dispose()
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "Characters\" & nudFemaleSprite.Value & GFX_EXT) Then
            g = picFemale.CreateGraphics

            Filename = Application.StartupPath & GFX_PATH & "Characters\" & nudFemaleSprite.Value & GFX_EXT

            Dim charsprite As Bitmap = New Bitmap(Filename)

            charwidth = charsprite.Width / 4
            charheight = charsprite.Height / 4

            srcRect = New Rectangle(0, 0, charwidth, charheight)
            destRect = New Rectangle(0, 0, charwidth, charheight)

            charsprite.MakeTransparent(charsprite.GetPixel(0, 0))

            picFemale.Refresh()
            g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel)

            g.Dispose()
        End If

    End Sub
#End Region

#Region "Stats"
    Private Sub NumStrength_ValueChanged(sender As Object, e As EventArgs) Handles nudStrength.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Strength) = nudStrength.Value
    End Sub

    Private Sub NumLuck_ValueChanged(sender As Object, e As EventArgs) Handles nudLuck.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Luck) = nudLuck.Value
    End Sub

    Private Sub NumEndurance_ValueChanged(sender As Object, e As EventArgs) Handles nudEndurance.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Endurance) = nudEndurance.Value
    End Sub

    Private Sub NumIntelligence_ValueChanged(sender As Object, e As EventArgs) Handles nudIntelligence.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub NumVitality_ValueChanged(sender As Object, e As EventArgs) Handles nudVitality.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Vitality) = nudVitality.Value
    End Sub

    Private Sub NumSpirit_ValueChanged(sender As Object, e As EventArgs) Handles nudSpirit.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Spirit) = nudSpirit.Value
    End Sub

    Private Sub NumBaseExp_ValueChanged(sender As Object, e As EventArgs) Handles nudBaseExp.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).BaseExp = nudBaseExp.Value
    End Sub

#End Region

#Region "Start Items"
    Private Sub BtnItemAdd_Click(sender As Object, e As EventArgs) Handles btnItemAdd.Click
        If lstStartItems.SelectedIndex < 0 Or cmbItems.SelectedIndex < 0 Then Exit Sub

        Classes(EditorIndex).StartItem(lstStartItems.SelectedIndex + 1) = cmbItems.SelectedIndex
        Classes(EditorIndex).StartValue(lstStartItems.SelectedIndex + 1) = nudItemAmount.Value

        LoadClassInfo = True
    End Sub

#End Region

#Region "Starting Point"
    Private Sub NumStartMap_ValueChanged(sender As Object, e As EventArgs) Handles nudStartMap.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).StartMap = nudStartMap.Value
    End Sub

    Private Sub NumStartX_ValueChanged(sender As Object, e As EventArgs) Handles nudStartX.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).StartX = nudStartX.Value
    End Sub

    Private Sub NumStartY_ValueChanged(sender As Object, e As EventArgs) Handles nudStartY.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).StartY = nudStartY.Value
    End Sub

#End Region
End Class