Imports System.Drawing
Imports System.Windows.Forms

Public Class frmEditor_Classes

#Region "Frm Controls"
    Private Sub frmEditor_Classes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrlMaleSprite.Maximum = NumCharacters
        scrlFemaleSprite.Maximum = NumCharacters

        DrawPreview()
    End Sub

    Private Sub lstIndex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIndex.SelectedIndexChanged
        If lstIndex.SelectedIndex < 0 Then Exit Sub

        EditorIndex = lstIndex.SelectedIndex + 1

        LoadClassInfo = True
    End Sub

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
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
        ClassEditorInit()
    End Sub

    Private Sub btnRemoveClass_Click(sender As Object, e As EventArgs) Handles btnRemoveClass.Click
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ClassesEditorOk()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClassesEditorCancel()
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        Classes(EditorIndex).Desc = txtDescription.Text
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
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
    Private Sub btnAddMaleSprite_Click(sender As Object, e As EventArgs) Handles btnAddMaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).MaleSprite)

        ReDim Preserve Classes(EditorIndex).MaleSprite(tmpamount + 1)

        Classes(EditorIndex).MaleSprite(tmpamount + 1) = 1

        LoadClassInfo = True
    End Sub

    Private Sub btnDeleteMaleSprite_Click(sender As Object, e As EventArgs) Handles btnDeleteMaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).MaleSprite)

        ReDim Preserve Classes(EditorIndex).MaleSprite(tmpamount - 1)

        LoadClassInfo = True
    End Sub

    Private Sub btnAddFemaleSprite_Click(sender As Object, e As EventArgs) Handles btnAddFemaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).FemaleSprite)

        ReDim Preserve Classes(EditorIndex).FemaleSprite(tmpamount + 1)

        Classes(EditorIndex).FemaleSprite(tmpamount + 1) = 1

        LoadClassInfo = True
    End Sub

    Private Sub btnDeleteFemaleSprite_Click(sender As Object, e As EventArgs) Handles btnDeleteFemaleSprite.Click
        Dim tmpamount As Byte
        If EditorIndex = 0 Or EditorIndex > Max_Classes Then Exit Sub

        tmpamount = UBound(Classes(EditorIndex).FemaleSprite)

        ReDim Preserve Classes(EditorIndex).FemaleSprite(tmpamount - 1)

        LoadClassInfo = True
    End Sub

    Private Sub scrlMaleSprite_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMaleSprite.Scroll
        lblMaleSprite.Text = "Sprite: " & scrlMaleSprite.Value

        Classes(EditorIndex).MaleSprite(cmbMaleSprite.SelectedIndex) = scrlMaleSprite.Value

        DrawPreview()
    End Sub

    Private Sub scrlFemaleSprite_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlFemaleSprite.Scroll
        lblFemaleSprite.Text = "Sprite: " & scrlFemaleSprite.Value

        Classes(EditorIndex).FemaleSprite(cmbFemaleSprite.SelectedIndex) = scrlFemaleSprite.Value

        DrawPreview()
    End Sub

    Private Sub cmbMaleSprite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaleSprite.SelectedIndexChanged
        scrlMaleSprite.Value = Classes(EditorIndex).MaleSprite(cmbMaleSprite.SelectedIndex)
        lblMaleSprite.Text = "Sprite: " & scrlMaleSprite.Value
        DrawPreview()
    End Sub

    Private Sub cmbFemaleSprite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFemaleSprite.SelectedIndexChanged
        scrlFemaleSprite.Value = Classes(EditorIndex).FemaleSprite(cmbFemaleSprite.SelectedIndex)
        lblFemaleSprite.Text = "Sprite: " & scrlFemaleSprite.Value
        DrawPreview()
    End Sub

    Sub DrawPreview()
        Dim g As Graphics
        Dim Filename As String
        Dim srcRect As Rectangle, destRect As Rectangle
        Dim charwidth As Integer, charheight As Integer

        If FileExist(Application.StartupPath & GFX_PATH & "Characters\" & scrlMaleSprite.Value & GFX_EXT) Then
            g = picMale.CreateGraphics

            Filename = Application.StartupPath & GFX_PATH & "Characters\" & scrlMaleSprite.Value & GFX_EXT

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

        If FileExist(Application.StartupPath & GFX_PATH & "Characters\" & scrlFemaleSprite.Value & GFX_EXT) Then
            g = picFemale.CreateGraphics

            Filename = Application.StartupPath & GFX_PATH & "Characters\" & scrlFemaleSprite.Value & GFX_EXT

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
    Private Sub numStrength_ValueChanged(sender As Object, e As EventArgs) Handles numStrength.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Strength) = numStrength.Value
    End Sub

    Private Sub numLuck_ValueChanged(sender As Object, e As EventArgs) Handles numLuck.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Luck) = numLuck.Value
    End Sub

    Private Sub numEndurance_ValueChanged(sender As Object, e As EventArgs) Handles numEndurance.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Endurance) = numEndurance.Value
    End Sub

    Private Sub numIntelligence_ValueChanged(sender As Object, e As EventArgs) Handles numIntelligence.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Intelligence) = numIntelligence.Value
    End Sub

    Private Sub numVitality_ValueChanged(sender As Object, e As EventArgs) Handles numVitality.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Vitality) = numVitality.Value
    End Sub

    Private Sub numSpirit_ValueChanged(sender As Object, e As EventArgs) Handles numSpirit.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).Stat(Stats.Spirit) = numSpirit.Value
    End Sub

    Private Sub numBaseExp_ValueChanged(sender As Object, e As EventArgs) Handles numBaseExp.ValueChanged
        If EditorIndex >= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).BaseExp = numBaseExp.Value
    End Sub

#End Region

#Region "Start Items"
    Private Sub btnItemAdd_Click(sender As Object, e As EventArgs) Handles btnItemAdd.Click
        If lstStartItems.SelectedIndex < 0 Or cmbItems.SelectedIndex < 0 Then Exit Sub

        Classes(EditorIndex).StartItem(lstStartItems.SelectedIndex + 1) = cmbItems.SelectedIndex
        Classes(EditorIndex).StartValue(lstStartItems.SelectedIndex + 1) = numItemAmount.Value

        LoadClassInfo = True
    End Sub

#End Region

#Region "Starting Point"
    Private Sub numStartMap_ValueChanged(sender As Object, e As EventArgs) Handles numStartMap.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).StartMap = numStartMap.Value
    End Sub

    Private Sub numStartX_ValueChanged(sender As Object, e As EventArgs) Handles numStartX.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).StartX = numStartX.Value
    End Sub

    Private Sub numStartY_ValueChanged(sender As Object, e As EventArgs) Handles numStartY.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        Classes(EditorIndex).StartY = numStartY.Value
    End Sub

#End Region

#Region "Class Editor"

    Public Sub ClassesEditorOk()
        SendSaveClasses()

        frmEditor_Classes.Visible = False
        Editor = 0
    End Sub

    Public Sub ClassesEditorCancel()
        SendRequestClasses()
        frmEditor_Classes.Visible = False
        Editor = 0
    End Sub

    Public Sub ClassEditorInit()
        Dim i As Integer

        frmEditor_Classes.lstIndex.Items.Clear()

        For i = 1 To Max_Classes
            frmEditor_Classes.lstIndex.Items.Add(Trim(Classes(i).Name))
        Next

        Editor = EDITOR_CLASSES

        frmEditor_Classes.scrlMaleSprite.Maximum = NumCharacters
        frmEditor_Classes.scrlFemaleSprite.Maximum = NumCharacters

        frmEditor_Classes.cmbItems.Items.Clear()

        frmEditor_Classes.cmbItems.Items.Add("None")
        For i = 1 To MAX_ITEMS
            frmEditor_Classes.cmbItems.Items.Add(Trim(Item(i).Name))
        Next

        frmEditor_Classes.Visible = True
    End Sub

    Public Sub LoadClass()
        Dim i As Integer

        If EditorIndex <= 0 Or EditorIndex > Max_Classes Then Exit Sub

        frmEditor_Classes.txtName.Text = Classes(EditorIndex).Name
        frmEditor_Classes.txtDescription.Text = Classes(EditorIndex).Desc

        frmEditor_Classes.cmbMaleSprite.Items.Clear()

        For i = 0 To UBound(Classes(EditorIndex).MaleSprite)
            frmEditor_Classes.cmbMaleSprite.Items.Add("Sprite " & i + 1)
        Next

        frmEditor_Classes.cmbFemaleSprite.Items.Clear()

        For i = 0 To UBound(Classes(EditorIndex).FemaleSprite)
            frmEditor_Classes.cmbFemaleSprite.Items.Add("Sprite " & i + 1)
        Next

        frmEditor_Classes.scrlMaleSprite.Value = Classes(EditorIndex).MaleSprite(0)
        frmEditor_Classes.scrlFemaleSprite.Value = Classes(EditorIndex).FemaleSprite(0)

        frmEditor_Classes.cmbMaleSprite.SelectedIndex = 0
        frmEditor_Classes.cmbFemaleSprite.SelectedIndex = 0

        frmEditor_Classes.DrawPreview()

        frmEditor_Classes.numStrength.Value = Classes(EditorIndex).Stat(Stats.strength)
        frmEditor_Classes.numLuck.Value = Classes(EditorIndex).Stat(Stats.luck)
        frmEditor_Classes.numEndurance.Value = Classes(EditorIndex).Stat(Stats.endurance)
        frmEditor_Classes.numIntelligence.Value = Classes(EditorIndex).Stat(Stats.intelligence)
        frmEditor_Classes.numVitality.Value = Classes(EditorIndex).Stat(Stats.vitality)
        frmEditor_Classes.numSpirit.Value = Classes(EditorIndex).Stat(Stats.spirit)

        frmEditor_Classes.numBaseExp.Value = Classes(EditorIndex).BaseExp

        frmEditor_Classes.lstStartItems.Items.Clear()
        For i = 1 To 5
            If Classes(EditorIndex).StartItem(i) > 0 Then
                frmEditor_Classes.lstStartItems.Items.Add(Item(Classes(EditorIndex).StartItem(i)).Name & " X " & Classes(EditorIndex).StartValue(i))
            Else
                frmEditor_Classes.lstStartItems.Items.Add("None")
            End If
        Next

        frmEditor_Classes.numStartMap.Value = Classes(EditorIndex).StartMap
        frmEditor_Classes.numStartX.Value = Classes(EditorIndex).StartX
        frmEditor_Classes.numStartY.Value = Classes(EditorIndex).StartY
    End Sub

#End Region

End Class