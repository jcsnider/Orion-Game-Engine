Public Class frmEditor_Item

#Region "Form Code"
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        ItemEditorOk()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        ItemEditorCancel()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Integer

        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        ClearItem(EditorIndex + 1)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ItemEditorInit()
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        ItemEditorInit()
    End Sub

    Private Sub picItem_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picItem.Paint
        'Dont let it auto paint ;)
    End Sub

    Private Sub picPaperdoll_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picPaperdoll.Paint
        'Dont let it auto paint :0
    End Sub

    Private Sub picFurniture_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picFurniture.Paint
        'Dont let it auto paint ;)
    End Sub

    Private Sub frmEditor_Item_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        nudPic.Maximum = NumItems
        nudPaperdoll.Maximum = NumPaperdolls
        nudFurniture.Maximum = NumFurniture
        cmbFurnitureType.SelectedIndex = 0
    End Sub

    Private Sub btnBasics_Click(sender As Object, e As EventArgs) Handles btnBasics.Click
        fraBasics.Visible = True
        fraRequirements.Visible = False
    End Sub

    Private Sub btnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        fraBasics.Visible = False
        fraRequirements.Visible = True
    End Sub
#End Region

#Region "Basics"
    Private Sub nudPic_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudPic.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Pic = nudPic.Value
        EditorItem_DrawItem()
    End Sub

    Private Sub cmbBind_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBind.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).BindType = cmbBind.SelectedIndex
    End Sub

    Private Sub nudRarity_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudRarity.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Rarity = nudRarity.Value
    End Sub

    Private Sub cmbAnimation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAnimation.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Animation = cmbAnimation.SelectedIndex
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        cmbSubType.Enabled = False

        If (cmbType.SelectedIndex = ItemType.Equipment) Then
            fraEquipment.Visible = True

            ' Build subtype cmb
            cmbSubType.Items.Clear()
            cmbSubType.Items.Add("None")

            cmbSubType.Items.Add("Weapon")
            cmbSubType.Items.Add("Armor")
            cmbSubType.Items.Add("Helmet")
            cmbSubType.Items.Add("Shield")
            cmbSubType.Items.Add("Shoes")
            cmbSubType.Items.Add("Gloves")

            cmbSubType.Enabled = True
            cmbSubType.SelectedIndex = Item(EditorIndex).SubType
        Else
            fraEquipment.Visible = False
        End If

        If (cmbType.SelectedIndex = ItemType.Consumable) Then
            fraVitals.Visible = True

            ' Build subtype cmb
            cmbSubType.Items.Clear()
            cmbSubType.Items.Add("None")

            cmbSubType.Items.Add("Hp")
            cmbSubType.Items.Add("Mp")
            cmbSubType.Items.Add("Sp")
            cmbSubType.Items.Add("Exp")

            cmbSubType.Enabled = True
            cmbSubType.SelectedIndex = Item(EditorIndex).SubType
        Else
            fraVitals.Visible = False
        End If

        If (cmbType.SelectedIndex = ItemType.Skill) Then
            fraSkill.Visible = True
        Else
            fraSkill.Visible = False
        End If

        If cmbType.SelectedIndex = ItemType.Furniture Then
            fraFurniture.Visible = True
        Else
            fraFurniture.Visible = False
        End If

        If cmbType.SelectedIndex = ItemType.Recipe Then
            fraRecipe.Visible = True
        Else
            fraRecipe.Visible = False
        End If

        Item(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub nudVitalMod_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudVitalMod.ValueChanged
        If EditorIndex <= 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Data1 = nudVitalMod.Value
    End Sub

    Private Sub cmbSkills_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSkills.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Data1 = cmbSkills.SelectedIndex
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Integer
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Item(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub nudPrice_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudPrice.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Price = nudPrice.Value
    End Sub

    Private Sub chkStackable_CheckedChanged(sender As Object, e As EventArgs) Handles chkStackable.CheckedChanged
        If chkStackable.Checked = True Then
            Item(EditorIndex).Stackable = 1
        Else
            Item(EditorIndex).Stackable = 0
        End If
    End Sub

    Private Sub cmbRecipe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRecipe.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Data1 = cmbRecipe.SelectedIndex
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Description = Trim$(txtDescription.Text)
    End Sub

    Private Sub cmbSubType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubType.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).SubType = cmbSubType.SelectedIndex
    End Sub

    Private Sub nudItemLvl_ValueChanged(sender As Object, e As EventArgs) Handles nudItemLvl.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).ItemLevel = nudItemLvl.Value
    End Sub

    Private Sub cmbPet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPet.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Data1 = cmbPet.SelectedIndex
    End Sub
#End Region

#Region "Requirements"
    Private Sub cmbClassReq_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClassReq.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).ClassReq = cmbClassReq.SelectedIndex
    End Sub

    Private Sub cmbAccessReq_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAccessReq.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).AccessReq = cmbAccessReq.SelectedIndex
    End Sub

    Private Sub nudLevelReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLevelReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).LevelReq = nudLevelReq.Value
    End Sub

    Private Sub nudStrReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudStrReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Stat_Req(Stats.Strength) = nudStrReq.Value
    End Sub

    Private Sub nudEndReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudEndReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Stat_Req(Stats.Endurance) = nudEndReq.Value
    End Sub

    Private Sub nudVitReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudVitReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Stat_Req(Stats.Vitality) = nudVitReq.Value
    End Sub

    Private Sub nudLuckReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLuckReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Stat_Req(Stats.Luck) = nudLuckReq.Value
    End Sub

    Private Sub nudIntReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudIntReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Stat_Req(Stats.Intelligence) = nudIntReq.Value
    End Sub

    Private Sub nudSprReq_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSprReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Stat_Req(Stats.Spirit) = nudSprReq.Value
    End Sub
#End Region

#Region "Equipment"
    Private Sub cmbTool_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTool.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).Data3 = cmbTool.SelectedIndex
    End Sub

    Private Sub nudDamage_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudDamage.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Data2 = nudDamage.Value
    End Sub

    Private Sub nudSpeed_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSpeed.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblSpeed.Text = "Speed: " & nudSpeed.Value / 1000 & " sec"
        Item(EditorIndex).Speed = nudSpeed.Value
    End Sub

    Private Sub nudPaperdoll_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudPaperdoll.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Paperdoll = nudPaperdoll.Value
        EditorItem_DrawPaperdoll()
    End Sub

    Private Sub nudStrength_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudStrength.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Add_Stat(Stats.Strength) = nudStrength.Value
    End Sub

    Private Sub nudLuck_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudLuck.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Add_Stat(Stats.Luck) = nudLuck.Value
    End Sub

    Private Sub nudEndurance_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudEndurance.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Add_Stat(Stats.Endurance) = nudEndurance.Value
    End Sub

    Private Sub nudIntelligence_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudIntelligence.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Add_Stat(Stats.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub nudVitality_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudVitality.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Add_Stat(Stats.Vitality) = nudVitality.Value
    End Sub

    Private Sub nudSpirit_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSpirit.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Add_Stat(Stats.Spirit) = nudSpirit.Value
    End Sub

    Private Sub chkKnockBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkKnockBack.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        If chkKnockBack.Checked = True Then
            Item(EditorIndex).KnockBack = 1
        Else
            Item(EditorIndex).KnockBack = 0
        End If
    End Sub

    Private Sub cmbKnockBackTiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKnockBackTiles.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).KnockBackTiles = cmbKnockBackTiles.SelectedIndex
    End Sub

    Private Sub chkRandomize_CheckedChanged(sender As Object, e As EventArgs) Handles chkRandomize.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        If chkRandomize.Checked = True Then
            Item(EditorIndex).Randomize = 1
        Else
            Item(EditorIndex).Randomize = 0
        End If
    End Sub

    Private Sub cmbProjectile_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProjectile.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Projectile = cmbProjectile.SelectedIndex
    End Sub

    Private Sub cmbAmmo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAmmo.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Ammo = cmbAmmo.SelectedIndex
    End Sub
#End Region

#Region "Furniture"
    Private Sub cmbFurnitureType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFurnitureType.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).Data1 = cmbFurnitureType.SelectedIndex
    End Sub

    Private Sub optNoFurnitureEditing_CheckedChanged(sender As Object, e As EventArgs) Handles optNoFurnitureEditing.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        If optNoFurnitureEditing.Checked = True Then
            lblSetOption.Text = "No Editing: Lets you look at the image without setting any options (blocks/fringes)."
        End If
    End Sub

    Private Sub optSetBlocks_CheckedChanged(sender As Object, e As EventArgs) Handles optSetBlocks.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        If optSetBlocks.Checked = True Then
            lblSetOption.Text = "Set Blocks: Os are passable and Xs are not. Simply place Xs where you do not want the player to walk."
        End If
    End Sub

    Private Sub optSetFringe_CheckedChanged(sender As Object, e As EventArgs) Handles optSetFringe.CheckedChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        If optSetFringe.Checked = True Then
            lblSetOption.Text = "Set Fringe: Os are draw on the fringe layer (the player can walk behind)."
        End If
    End Sub

    Private Sub nudFurniture_ValueChanged(sender As Object, e As EventArgs) Handles nudFurniture.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        Item(EditorIndex).Data2 = nudFurniture.Value

        If nudFurniture.Value > 0 And nudFurniture.Value <= NumFurniture Then
            Item(EditorIndex).FurnitureWidth = FurnitureGFXInfo(nudFurniture.Value).width / 32
            Item(EditorIndex).FurnitureHeight = FurnitureGFXInfo(nudFurniture.Value).height / 32
            If Item(EditorIndex).FurnitureHeight > 1 Then Item(EditorIndex).FurnitureHeight = Item(EditorIndex).FurnitureHeight - 1
        Else
            Item(EditorIndex).FurnitureWidth = 1
            Item(EditorIndex).FurnitureHeight = 1
        End If

        EditorItem_DrawFurniture()
    End Sub
#End Region

End Class