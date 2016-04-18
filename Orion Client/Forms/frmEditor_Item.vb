Imports System.Windows.Forms

Public Class frmEditor_Item
    Private Sub scrlPic_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPic.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPic.Text = "Pic: " & scrlPic.Value
        Item(EditorIndex).Pic = scrlPic.Value
        Call EditorItem_DrawItem()
    End Sub

    Private Sub cmbBind_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBind.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).BindType = cmbBind.SelectedIndex
    End Sub

    Private Sub scrlRarity_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlRarity.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblRarity.Text = "Rarity: " & scrlRarity.Value
        Item(EditorIndex).Rarity = scrlRarity.Value
    End Sub

    Private Sub scrlAnim_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAnim.ValueChanged
        Dim sString As String
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        If scrlAnim.Value = 0 Then
            sString = "None"
        Else
            sString = Trim$(Animation(scrlAnim.Value).Name)
        End If
        lblAnim.Text = "Anim: " & sString
        Item(EditorIndex).Animation = scrlAnim.Value
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        If (cmbType.SelectedIndex >= ITEM_TYPE_WEAPON) And (cmbType.SelectedIndex <= ITEM_TYPE_SHIELD) Then
            fraEquipment.Visible = True
            'scrlDamage_Change
        Else
            fraEquipment.Visible = False
        End If

        If (cmbType.SelectedIndex >= ITEM_TYPE_POTIONADDHP) And (cmbType.SelectedIndex <= ITEM_TYPE_POTIONSUBSP) Then
            fraVitals.Visible = True
            'scrlVitalMod_Change
        Else
            fraVitals.Visible = False
        End If

        If (cmbType.SelectedIndex = ITEM_TYPE_SPELL) Then
            fraSpell.Visible = True
        Else
            fraSpell.Visible = False
        End If

        If cmbType.SelectedIndex = ITEM_TYPE_FURNITURE Then
            fraFurniture.Visible = True
        Else
            fraFurniture.Visible = False
        End If

        Item(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub cmbClassReq_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClassReq.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).ClassReq = cmbClassReq.SelectedIndex
    End Sub

    Private Sub scrlAccessReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAccessReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAccessReq.Text = "Access Req: " & scrlAccessReq.Value
        Item(EditorIndex).AccessReq = scrlAccessReq.Value
    End Sub

    Private Sub scrlLevelReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlLevelReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblLevelReq.Text = "Level req: " & scrlLevelReq.Value
        Item(EditorIndex).LevelReq = scrlLevelReq.Value
    End Sub

    Private Sub scrlStrReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlStrReq.ValueChanged
        lblStrReq.Text = "Str: " & scrlStrReq.Value
        Item(EditorIndex).Stat_Req(Stats.strength) = scrlStrReq.Value
    End Sub

    Private Sub scrlEndReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlEndReq.ValueChanged
        lblEndReq.Text = "End: " & scrlEndReq.Value
        Item(EditorIndex).Stat_Req(Stats.endurance) = scrlEndReq.Value
    End Sub

    Private Sub scrlVitReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlVitReq.ValueChanged
        lblVitReq.Text = "Vit: " & scrlVitReq.Value
        Item(EditorIndex).Stat_Req(Stats.vitality) = scrlVitReq.Value
    End Sub

    Private Sub scrlWillReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlWillReq.ValueChanged
        lblWillReq.Text = "Will: " & scrlWillReq.Value
        Item(EditorIndex).Stat_Req(Stats.willpower) = scrlWillReq.Value
    End Sub

    Private Sub scrlIntReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlIntReq.ValueChanged
        lblIntReq.Text = "Int: " & scrlStrReq.Value
        Item(EditorIndex).Stat_Req(Stats.intelligence) = scrlIntReq.Value
    End Sub

    Private Sub scrlSprReq_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSprReq.ValueChanged
        lblSprReq.Text = "Spr: " & scrlSprReq.Value
        Item(EditorIndex).Stat_Req(Stats.spirit) = scrlSprReq.Value
    End Sub

    Private Sub scrlVitalMod_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlVitalMod.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblVitalMod.Text = "Vital Mod: " & scrlVitalMod.Value
        Item(EditorIndex).Data1 = scrlVitalMod.Value
    End Sub

    Private Sub scrlSpell_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSpell.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        If Len(Trim$(Spell(scrlSpell.Value).Name)) > 0 Then
            lblSpellName.Text = "Name: " & Trim$(Spell(scrlSpell.Value).Name)
        Else
            lblSpellName.Text = "Name: None"
        End If

        lblSpell.Text = "Spell: " & scrlSpell.Value

        Item(EditorIndex).Data1 = scrlSpell.Value
    End Sub

    Private Sub cmbTool_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTool.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).Data3 = cmbTool.SelectedIndex
    End Sub

    Private Sub scrlDamage_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlDamage.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblDamage.Text = "Damage: " & scrlDamage.Value
        Item(EditorIndex).Data2 = scrlDamage.Value
    End Sub

    Private Sub scrlSpeed_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlSpeed.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblSpeed.Text = "Speed: " & scrlSpeed.Value / 1000 & " sec"
        Item(EditorIndex).Speed = scrlSpeed.Value
    End Sub

    Private Sub scrlPaperdoll_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPaperdoll.ValueChanged, scrlPaperdoll.Scroll
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPaperDoll.Text = "Paperdoll: " & scrlPaperdoll.Value
        Item(EditorIndex).Paperdoll = scrlPaperdoll.Value
        EditorItem_DrawPaperdoll()
    End Sub

    Private Sub scrlAddStr_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAddStr.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAddStr.Text = "+Str: " & scrlAddStr.Value
        Item(EditorIndex).Add_Stat(Stats.strength) = scrlAddStr.Value
    End Sub

    Private Sub scrlAddWill_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAddWill.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAddWill.Text = "+Will: " & scrlAddWill.Value
        Item(EditorIndex).Add_Stat(Stats.willpower) = scrlAddWill.Value
    End Sub

    Private Sub scrlAddEnd_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAddEnd.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAddEnd.Text = "+End: " & scrlAddEnd.Value
        Item(EditorIndex).Add_Stat(Stats.endurance) = scrlAddEnd.Value
    End Sub

    Private Sub scrlAddInt_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAddInt.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAddInt.Text = "+Int: " & scrlAddInt.Value
        Item(EditorIndex).Add_Stat(Stats.intelligence) = scrlAddInt.Value
    End Sub

    Private Sub scrlAddVit_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAddVit.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAddVit.Text = "+Vit: " & scrlAddVit.Value
        Item(EditorIndex).Add_Stat(Stats.vitality) = scrlAddVit.Value
    End Sub

    Private Sub scrlAddSpr_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlAddSpr.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAddSpr.Text = "+Spr: " & scrlAddSpr.Value
        Item(EditorIndex).Add_Stat(Stats.spirit) = scrlAddSpr.Value
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        ItemEditorOk()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        ItemEditorCancel()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        ClearItem(EditorIndex + 1)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ItemEditorInit()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Item(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lstIndex.Click
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        ItemEditorInit()
    End Sub

    Private Sub scrlPrice_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scrlPrice.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPrice.Text = "Price: " & scrlPrice.Value
        Item(EditorIndex).Price = scrlPrice.Value
    End Sub

    Private Sub picItem_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picItem.Paint
        'Dont let it auto paint ;)
    End Sub

    Private Sub picPaperdoll_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picPaperdoll.Paint
        'Dont let it auto paint :0
    End Sub

    Private Sub tmrDrawPicPaperdoll_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If Me.Visible = True Then
            If Me.WindowState = FormWindowState.Normal Then
                EditorItem_DrawItem()
                EditorItem_DrawPaperdoll()
                EditorItem_DrawFurniture()
            End If
        End If
    End Sub

    Private Sub frmEditor_Item_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        scrlPic.Maximum = NumItems
        scrlPic.LargeChange = 1
        scrlAnim.Maximum = MAX_ANIMATIONS
        scrlPaperdoll.Maximum = NumPaperdolls
        scrlFurniture.Maximum = NumFurniture
        cmbFurnitureType.SelectedIndex = 0
    End Sub

    Private Sub scrlPrice_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlPrice.Scroll
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPrice.Text = "Price: " & scrlPrice.Value
        Item(EditorIndex).Price = scrlPrice.Value
    End Sub

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

    Private Sub scrlFurniture_Scroll(sender As Object, e As ScrollEventArgs) Handles scrlFurniture.Scroll
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblFurniture.Text = "Furniture: " & scrlFurniture.Value
        Item(EditorIndex).Data2 = scrlFurniture.Value

        If scrlFurniture.Value > 0 And scrlFurniture.Value <= NumFurniture Then
            Item(EditorIndex).FurnitureWidth = FurnitureGFXInfo(scrlFurniture.Value).width / 32
            Item(EditorIndex).FurnitureHeight = FurnitureGFXInfo(scrlFurniture.Value).height / 32
            If Item(EditorIndex).FurnitureHeight > 1 Then Item(EditorIndex).FurnitureHeight = Item(EditorIndex).FurnitureHeight - 1
        Else
            Item(EditorIndex).FurnitureWidth = 1
            Item(EditorIndex).FurnitureHeight = 1
        End If

        EditorItem_DrawFurniture()
    End Sub

    Private Sub picFurniture_MouseDown(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs) Handles picFurniture.MouseDown
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Dim X As Long, Y As Long
        X = e.X / 32
        Y = e.Y / 32

        If X > 3 Then Exit Sub
        If Y > 3 Then Exit Sub

        If optSetBlocks.Checked = True Then
            If Item(EditorIndex).FurnitureBlocks(X, Y) = 1 Then
                Item(EditorIndex).FurnitureBlocks(X, Y) = 0
            Else
                Item(EditorIndex).FurnitureBlocks(X, Y) = 1
            End If
        ElseIf optSetFringe.Checked = True Then
            If Item(EditorIndex).FurnitureFringe(X, Y) = 1 Then
                Item(EditorIndex).FurnitureFringe(X, Y) = 0
            Else
                Item(EditorIndex).FurnitureFringe(X, Y) = 1
            End If
        End If
        EditorItem_DrawFurniture()
    End Sub

    Private Sub picFurniture_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picFurniture.Paint
        'Dont let it auto paint ;)
    End Sub

    Private Sub scrlProjectile_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles scrlProjectile.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        If scrlProjectile.Value = 0 Then
            lblProjectile.Text = "Projectile: 0 None"
        Else
            lblProjectile.Text = "Projectile: " & scrlProjectile.Value & " " & Trim$(Projectiles(scrlProjectile.Value).Name)
        End If
        Item(EditorIndex).Data1 = scrlProjectile.Value
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
End Class