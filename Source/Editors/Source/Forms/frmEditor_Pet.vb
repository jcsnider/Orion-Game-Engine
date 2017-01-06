Public Class frmEditor_Pet
#Region "Basics"
    Private Sub frmEditor_Pet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EditorPet_DrawPet()

        scrlSprite.Maximum = NumCharacters
        scrlRange.Maximum = 50
        scrlLevel.Maximum = MAX_LEVELS
        scrlMaxLevel.Maximum = MAX_LEVELS

        scrlSkill1.Maximum = MAX_SKILLS
        scrlSkill2.Maximum = MAX_SKILLS
        scrlSkill3.Maximum = MAX_SKILLS
        scrlSkill4.Maximum = MAX_SKILLS
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Pet(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Pet(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub scrlSprite_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSprite.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblSprite.Text = "Sprite: " & scrlSprite.Value
        Pet(EditorIndex).Sprite = scrlSprite.Value

        EditorPet_DrawPet()
    End Sub

    Public Sub EditorPet_DrawPet()
        Dim petnum As Integer

        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        petnum = scrlSprite.Value

        If petnum < 1 Or petnum > NumCharacters Then
            picSprite.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "Characters\" & petnum & GFX_EXT) Then
            picSprite.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "Characters\" & petnum & GFX_EXT)
        End If

    End Sub

    Private Sub scrlRange_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlRange.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblRange.Text = "Range: " & scrlRange.Value
        Pet(EditorIndex).Range = scrlRange.Value
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        PetEditorOk()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PetEditorCancel()
    End Sub
#End Region

#Region "Stats"
    Private Sub optCustomStats_CheckedChanged(sender As Object, e As EventArgs) Handles optCustomStats.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optCustomStats.Checked = True Then
            pnlCustomStats.Visible = True
            Pet(EditorIndex).StatType = 1
        Else
            pnlCustomStats.Visible = False
            Pet(EditorIndex).StatType = 0
        End If
    End Sub

    Private Sub optAdoptStats_CheckedChanged(sender As Object, e As EventArgs) Handles optAdoptStats.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optAdoptStats.Checked = True Then
            pnlCustomStats.Visible = False
            Pet(EditorIndex).StatType = 0
        Else
            pnlCustomStats.Visible = True
            Pet(EditorIndex).StatType = 1
        End If
    End Sub

    Private Sub scrlStrength_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlStrength.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblStrength.Text = "Strength: " & scrlStrength.Value
        Pet(EditorIndex).stat(Stats.Strength) = scrlStrength.Value
    End Sub

    Private Sub scrlEndurance_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlEndurance.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblEndurance.Text = "Endurance: " & scrlEndurance.Value
        Pet(EditorIndex).stat(Stats.Endurance) = scrlEndurance.Value
    End Sub

    Private Sub scrlVitality_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlVitality.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblVitality.Text = "Vitality: " & scrlVitality.Value
        Pet(EditorIndex).stat(Stats.Vitality) = scrlVitality.Value
    End Sub

    Private Sub scrlLuck_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlLuck.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblLuck.Text = "Luck: " & scrlLuck.Value
        Pet(EditorIndex).stat(Stats.Luck) = scrlLuck.Value
    End Sub

    Private Sub scrlIntelligence_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlIntelligence.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblIntelligence.Text = "Intelligence: " & scrlIntelligence.Value
        Pet(EditorIndex).stat(Stats.Intelligence) = scrlIntelligence.Value
    End Sub

    Private Sub scrlSpirit_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSpirit.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblSpirit.Text = "Spirit: " & scrlSpirit.Value
        Pet(EditorIndex).stat(Stats.Spirit) = scrlSpirit.Value
    End Sub

    Private Sub scrlLevel_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlLevel.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblLevel.Text = "Level: " & scrlLevel.Value
        Pet(EditorIndex).Level = scrlLevel.Value
    End Sub
#End Region

#Region "Leveling"
    Private Sub scrlPetExp_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlPetExp.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblPetExp.Text = "Exp Gain: " & scrlPetExp.Value & "%"
        Pet(EditorIndex).ExpGain = scrlPetExp.Value
    End Sub

    Private Sub scrlPetPnts_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlPetPnts.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblPetPnts.Text = "Points Per Level: " & scrlPetPnts.Value
        Pet(EditorIndex).LevelPnts = scrlPetPnts.Value
    End Sub

    Private Sub scrlMaxLevel_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMaxLevel.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblmaxlevel.Text = "Max Level: " & scrlMaxLevel.Value
        Pet(EditorIndex).MaxLevel = scrlMaxLevel.Value
    End Sub

    Private Sub optLevel_CheckedChanged(sender As Object, e As EventArgs) Handles optLevel.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optLevel.Checked = True Then
            pnlPetlevel.Visible = True
            Pet(EditorIndex).LevelingType = 1
        End If
    End Sub

    Private Sub optDoNotLevel_CheckedChanged(sender As Object, e As EventArgs) Handles optDoNotLevel.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optDoNotLevel.Checked = True Then
            pnlPetlevel.Visible = False
            Pet(EditorIndex).LevelingType = 0
        End If
    End Sub
#End Region

#Region "Skills"
    Private Sub scrlSkill1_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill1.Scroll
        Dim prefix As String = "Skill " & 1 & ": "
        If scrlSkill1.Value = 0 Then
            lblSkill1.Text = prefix & "None"
        Else
            lblSkill1.Text = prefix & Trim$(Skill(scrlSkill1.Value).Name)
        End If

        Pet(EditorIndex).skill(1) = scrlSkill1.Value
    End Sub

    Private Sub scrlSkill2_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill2.Scroll
        Dim prefix As String = "Skill " & 2 & ": "
        If scrlSkill2.Value = 0 Then
            lblSkill2.Text = prefix & "None"
        Else
            lblSkill2.Text = prefix & Trim$(Skill(scrlSkill2.Value).Name)
        End If

        Pet(EditorIndex).skill(2) = scrlSkill2.Value
    End Sub

    Private Sub scrlSkill3_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill3.Scroll
        Dim prefix As String = "Skill " & 3 & ": "
        If scrlSkill3.Value = 0 Then
            lblSkill3.Text = prefix & "None"
        Else
            lblSkill3.Text = prefix & Trim$(Skill(scrlSkill3.Value).Name)
        End If

        Pet(EditorIndex).skill(3) = scrlSkill3.Value
    End Sub

    Private Sub scrlSkill4_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill4.Scroll
        Dim prefix As String = "Skill " & 4 & ": "
        If scrlSkill4.Value = 0 Then
            lblSkill4.Text = prefix & "None"
        Else
            lblSkill4.Text = prefix & Trim$(Skill(scrlSkill4.Value).Name)
        End If

        Pet(EditorIndex).skill(4) = scrlSkill4.Value
    End Sub

    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub
        PetEditorInit()
    End Sub
#End Region
End Class