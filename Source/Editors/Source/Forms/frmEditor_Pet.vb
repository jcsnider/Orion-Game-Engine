Public Class FrmEditor_Pet
#Region "Basics"
    Private Sub FrmEditor_Pet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Pet(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Pet(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub ScrlSprite_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSprite.Scroll
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

    Private Sub ScrlRange_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlRange.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblRange.Text = "Range: " & scrlRange.Value
        Pet(EditorIndex).Range = scrlRange.Value
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        PetEditorOk()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PetEditorCancel()
    End Sub
#End Region

#Region "Stats"
    Private Sub OptCustomStats_CheckedChanged(sender As Object, e As EventArgs) Handles optCustomStats.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optCustomStats.Checked = True Then
            pnlCustomStats.Visible = True
            Pet(EditorIndex).StatType = 1
        Else
            pnlCustomStats.Visible = False
            Pet(EditorIndex).StatType = 0
        End If
    End Sub

    Private Sub OptAdoptStats_CheckedChanged(sender As Object, e As EventArgs) Handles optAdoptStats.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optAdoptStats.Checked = True Then
            pnlCustomStats.Visible = False
            Pet(EditorIndex).StatType = 0
        Else
            pnlCustomStats.Visible = True
            Pet(EditorIndex).StatType = 1
        End If
    End Sub

    Private Sub ScrlStrength_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlStrength.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblStrength.Text = "Strength: " & scrlStrength.Value
        Pet(EditorIndex).Stat(Stats.Strength) = scrlStrength.Value
    End Sub

    Private Sub ScrlEndurance_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlEndurance.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblEndurance.Text = "Endurance: " & scrlEndurance.Value
        Pet(EditorIndex).Stat(Stats.Endurance) = scrlEndurance.Value
    End Sub

    Private Sub ScrlVitality_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlVitality.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblVitality.Text = "Vitality: " & scrlVitality.Value
        Pet(EditorIndex).Stat(Stats.Vitality) = scrlVitality.Value
    End Sub

    Private Sub ScrlLuck_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlLuck.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblLuck.Text = "Luck: " & scrlLuck.Value
        Pet(EditorIndex).Stat(Stats.Luck) = scrlLuck.Value
    End Sub

    Private Sub ScrlIntelligence_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlIntelligence.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblIntelligence.Text = "Intelligence: " & scrlIntelligence.Value
        Pet(EditorIndex).Stat(Stats.Intelligence) = scrlIntelligence.Value
    End Sub

    Private Sub ScrlSpirit_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSpirit.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblSpirit.Text = "Spirit: " & scrlSpirit.Value
        Pet(EditorIndex).Stat(Stats.Spirit) = scrlSpirit.Value
    End Sub

    Private Sub ScrlLevel_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlLevel.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblLevel.Text = "Level: " & scrlLevel.Value
        Pet(EditorIndex).Level = scrlLevel.Value
    End Sub
#End Region

#Region "Leveling"
    Private Sub ScrlPetExp_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlPetExp.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblPetExp.Text = "Exp Gain: " & scrlPetExp.Value & "%"
        Pet(EditorIndex).ExpGain = scrlPetExp.Value
    End Sub

    Private Sub ScrlPetPnts_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlPetPnts.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblPetPnts.Text = "Points Per Level: " & scrlPetPnts.Value
        Pet(EditorIndex).LevelPnts = scrlPetPnts.Value
    End Sub

    Private Sub ScrlMaxLevel_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlMaxLevel.Scroll
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        lblmaxlevel.Text = "Max Level: " & scrlMaxLevel.Value
        Pet(EditorIndex).MaxLevel = scrlMaxLevel.Value
    End Sub

    Private Sub OptLevel_CheckedChanged(sender As Object, e As EventArgs) Handles optLevel.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optLevel.Checked = True Then
            pnlPetlevel.Visible = True
            Pet(EditorIndex).LevelingType = 1
        End If
    End Sub

    Private Sub OptDoNotLevel_CheckedChanged(sender As Object, e As EventArgs) Handles optDoNotLevel.CheckedChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If optDoNotLevel.Checked = True Then
            pnlPetlevel.Visible = False
            Pet(EditorIndex).LevelingType = 0
        End If
    End Sub
#End Region

#Region "Skills"
    Private Sub ScrlSkill1_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill1.Scroll
        Dim prefix As String = "Skill " & 1 & ": "
        If scrlSkill1.Value = 0 Then
            lblSkill1.Text = prefix & "None"
        Else
            lblSkill1.Text = prefix & Trim$(Skill(scrlSkill1.Value).Name)
        End If

        Pet(EditorIndex).Skill(1) = scrlSkill1.Value
    End Sub

    Private Sub ScrlSkill2_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill2.Scroll
        Dim prefix As String = "Skill " & 2 & ": "
        If scrlSkill2.Value = 0 Then
            lblSkill2.Text = prefix & "None"
        Else
            lblSkill2.Text = prefix & Trim$(Skill(scrlSkill2.Value).Name)
        End If

        Pet(EditorIndex).Skill(2) = scrlSkill2.Value
    End Sub

    Private Sub ScrlSkill3_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill3.Scroll
        Dim prefix As String = "Skill " & 3 & ": "
        If scrlSkill3.Value = 0 Then
            lblSkill3.Text = prefix & "None"
        Else
            lblSkill3.Text = prefix & Trim$(Skill(scrlSkill3.Value).Name)
        End If

        Pet(EditorIndex).Skill(3) = scrlSkill3.Value
    End Sub

    Private Sub ScrlSkill4_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlSkill4.Scroll
        Dim prefix As String = "Skill " & 4 & ": "
        If scrlSkill4.Value = 0 Then
            lblSkill4.Text = prefix & "None"
        Else
            lblSkill4.Text = prefix & Trim$(Skill(scrlSkill4.Value).Name)
        End If

        Pet(EditorIndex).Skill(4) = scrlSkill4.Value
    End Sub

    Private Sub LstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub
        PetEditorInit()
    End Sub

    Private Sub ChkEvolve_CheckedChanged(sender As Object, e As EventArgs) Handles chkEvolve.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If chkEvolve.Checked = True Then
            Pet(EditorIndex).Evolvable = 1
        Else
            Pet(EditorIndex).Evolvable = 0
        End If

    End Sub

    Private Sub ScrlEvolveLvl_ValueChanged(sender As Object, e As EventArgs) Handles scrlEvolveLvl.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).EvolveLevel = scrlEvolveLvl.Value

        lblEvolveLvl.Text = "Evolves on Level: " & scrlEvolveLvl.Value
    End Sub

    Private Sub CmbEvolve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvolve.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).EvolveNum = cmbEvolve.SelectedIndex
    End Sub


#End Region
End Class