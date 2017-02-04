Public Class frmEditor_Pet
#Region "Basics"
    Private Sub FrmEditor_Pet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EditorPet_DrawPet()

        nudSprite.Maximum = NumCharacters
        nudRange.Maximum = 50
        nudLevel.Maximum = MAX_LEVELS
        nudMaxLevel.Maximum = MAX_LEVELS

    End Sub

    Private Sub LstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub
        PetEditorInit()
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

    Private Sub nudSprite_ValueChanged(sender As Object, e As EventArgs) Handles nudSprite.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Sprite = nudSprite.Value

        EditorPet_DrawPet()
    End Sub

    Public Sub EditorPet_DrawPet()
        Dim petnum As Integer

        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        petnum = nudSprite.Value

        If petnum < 1 Or petnum > NumCharacters Then
            picSprite.BackgroundImage = Nothing
            Exit Sub
        End If

        If FileExist(Application.StartupPath & GFX_PATH & "Characters\" & petnum & GFX_EXT) Then
            picSprite.BackgroundImage = Drawing.Image.FromFile(Application.StartupPath & GFX_PATH & "Characters\" & petnum & GFX_EXT)
        End If

    End Sub

    Private Sub nudRange_ValueChanged(sender As Object, e As EventArgs) Handles nudRange.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Range = nudRange.Value
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

    Private Sub nudStrength_ValueChanged(sender As Object, e As EventArgs) Handles nudStrength.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Stat(Stats.Strength) = nudStrength.Value
    End Sub

    Private Sub nudEndurance_ValueChanged(sender As Object, e As EventArgs) Handles nudEndurance.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Stat(Stats.Endurance) = nudEndurance.Value
    End Sub

    Private Sub nudVitality_ValueChanged(sender As Object, e As EventArgs) Handles nudVitality.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Stat(Stats.Vitality) = nudVitality.Value
    End Sub

    Private Sub nudLuck_ValueChanged(sender As Object, e As EventArgs) Handles nudLuck.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Stat(Stats.Luck) = nudLuck.Value
    End Sub

    Private Sub nudIntelligence_ValueChanged(sender As Object, e As EventArgs) Handles nudIntelligence.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Stat(Stats.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub nudSpirit_ValueChanged(sender As Object, e As EventArgs) Handles nudSpirit.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Stat(Stats.Spirit) = nudSpirit.Value
    End Sub

    Private Sub nudLevel_ValueChanged(sender As Object, e As EventArgs) Handles nudLevel.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Level = nudLevel.Value
    End Sub
#End Region

#Region "Leveling"
    Private Sub nudPetExp_ValueChanged(sender As Object, e As EventArgs) Handles nudPetExp.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).ExpGain = nudPetExp.Value
    End Sub

    Private Sub nudPetPnts_ValueChanged(sender As Object, e As EventArgs) Handles nudPetPnts.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).LevelPnts = nudPetPnts.Value
    End Sub

    Private Sub nudMaxLevel_ValueChanged(sender As Object, e As EventArgs) Handles nudMaxLevel.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).MaxLevel = nudMaxLevel.Value
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
    Private Sub cmbSkill1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill1.SelectedIndexChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Skill(1) = cmbSkill1.SelectedIndex
    End Sub

    Private Sub cmbSkill2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill2.SelectedIndexChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Skill(2) = cmbSkill2.SelectedIndex
    End Sub

    Private Sub cmbSkill3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill3.SelectedIndexChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Skill(3) = cmbSkill3.SelectedIndex
    End Sub

    Private Sub cmbSkill4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill4.SelectedIndexChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).Skill(4) = cmbSkill4.SelectedIndex
    End Sub

#End Region

#Region "Evolving"
    Private Sub ChkEvolve_CheckedChanged(sender As Object, e As EventArgs) Handles chkEvolve.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub

        If chkEvolve.Checked = True Then
            Pet(EditorIndex).Evolvable = 1
        Else
            Pet(EditorIndex).Evolvable = 0
        End If

    End Sub

    Private Sub nudEvolveLvl_ValueChanged(sender As Object, e As EventArgs) Handles nudEvolveLvl.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).EvolveLevel = nudEvolveLvl.Value
    End Sub

    Private Sub CmbEvolve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvolve.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_PETS Then Exit Sub

        Pet(EditorIndex).EvolveNum = cmbEvolve.SelectedIndex
    End Sub
#End Region

End Class