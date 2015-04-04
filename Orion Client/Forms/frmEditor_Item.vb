Imports System.Windows.Forms

Public Class frmEditor_Item
    Private Sub scrlPic_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlPic.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPic.Text = "Pic: " & scrlPic.Value
        Item(EditorIndex).Pic = scrlPic.Value
        Call EditorItem_DrawItem()
    End Sub

    Private Sub cmbBind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBind.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).BindType = cmbBind.SelectedIndex
    End Sub

    Private Sub scrlRarity_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlRarity.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblRarity.Text = "Rarity: " & scrlRarity.Value
        Item(EditorIndex).Rarity = scrlRarity.Value
    End Sub

    Private Sub scrlAnim_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAnim.ValueChanged
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

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
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

        Item(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub cmbClassReq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassReq.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).ClassReq = cmbClassReq.SelectedIndex
    End Sub

    Private Sub scrlAccessReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAccessReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblAccessReq.Text = "Access Req: " & scrlAccessReq.Value
        Item(EditorIndex).AccessReq = scrlAccessReq.Value
    End Sub

    Private Sub scrlLevelReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlLevelReq.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblLevelReq.Text = "Level req: " & scrlLevelReq.Value
        Item(EditorIndex).LevelReq = scrlLevelReq.Value
    End Sub

    Private Sub scrlStrReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlStrReq.ValueChanged
        lblStrReq.Text = "Str: " & scrlStrReq.Value
        Item(EditorIndex).Stat_Req(Stats.strength) = scrlStrReq.Value
    End Sub

    Private Sub scrlEndReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlEndReq.ValueChanged
        lblEndReq.Text = "End: " & scrlEndReq.Value
        Item(EditorIndex).Stat_Req(Stats.endurance) = scrlEndReq.Value
    End Sub

    Private Sub scrlVitReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlVitReq.ValueChanged
        lblVitReq.Text = "Vit: " & scrlVitReq.Value
        Item(EditorIndex).Stat_Req(Stats.vitality) = scrlVitReq.Value
    End Sub

    Private Sub scrlWillReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlWillReq.ValueChanged
        lblWillReq.Text = "Will: " & scrlWillReq.Value
        Item(EditorIndex).Stat_Req(Stats.willpower) = scrlWillReq.Value
    End Sub

    Private Sub scrlIntReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlIntReq.ValueChanged
        lblIntReq.Text = "Int: " & scrlStrReq.Value
        Item(EditorIndex).Stat_Req(Stats.intelligence) = scrlIntReq.Value
    End Sub

    Private Sub scrlSprReq_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlSprReq.ValueChanged
        lblSprReq.Text = "Spr: " & scrlSprReq.Value
        Item(EditorIndex).Stat_Req(Stats.spirit) = scrlSprReq.Value
    End Sub

    Private Sub scrlVitalMod_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlVitalMod.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblVitalMod.Text = "Vital Mod: " & scrlVitalMod.Value
        Item(EditorIndex).Data1 = scrlVitalMod.Value
    End Sub

    Private Sub scrlSpell_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlSpell.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        If Len(Trim$(Spell(scrlSpell.Value).Name)) > 0 Then
            lblSpellName.Text = "Name: " & Trim$(Spell(scrlSpell.Value).Name)
        Else
            lblSpellName.Text = "Name: None"
        End If

        lblSpell.Text = "Spell: " & scrlSpell.Value

        Item(EditorIndex).Data1 = scrlSpell.Value
    End Sub

    Private Sub cmbTool_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTool.SelectedIndexChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        Item(EditorIndex).Data3 = cmbTool.SelectedIndex
    End Sub

    Private Sub scrlDamage_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlDamage.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblDamage.Text = "Damage: " & scrlDamage.Value
        Item(EditorIndex).Data2 = scrlDamage.Value
    End Sub

    Private Sub scrlSpeed_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlSpeed.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblSpeed.Text = "Speed: " & scrlSpeed.Value / 1000 & " sec"
        Item(EditorIndex).Speed = scrlSpeed.Value
    End Sub

    Private Sub scrlPaperdoll_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlPaperdoll.ValueChanged, scrlPaperdoll.Scroll
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPaperDoll.Text = "Paperdoll: " & scrlPaperdoll.Value
        Item(EditorIndex).Paperdoll = scrlPaperdoll.Value
        Call EditorItem_DrawPaperdoll()
    End Sub

    Private Sub scrlAddStr_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAddStr.ValueChanged
        lblAddStr.Text = "+Str: " & scrlAddStr.Value
        Item(EditorIndex).Add_Stat(Stats.strength) = scrlAddStr.Value
    End Sub

    Private Sub scrlAddWill_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAddWill.ValueChanged
        lblAddWill.Text = "+Will: " & scrlAddWill.Value
        Item(EditorIndex).Add_Stat(Stats.willpower) = scrlAddWill.Value
    End Sub

    Private Sub scrlAddEnd_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAddEnd.ValueChanged
        lblAddEnd.Text = "+End: " & scrlAddEnd.Value
        Item(EditorIndex).Add_Stat(Stats.endurance) = scrlAddEnd.Value
    End Sub

    Private Sub scrlAddInt_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAddInt.ValueChanged
        lblAddInt.Text = "+Int: " & scrlAddInt.Value
        Item(EditorIndex).Add_Stat(Stats.intelligence) = scrlAddInt.Value
    End Sub

    Private Sub scrlAddVit_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAddVit.ValueChanged
        lblAddVit.Text = "+Vit: " & scrlAddVit.Value
        Item(EditorIndex).Add_Stat(Stats.vitality) = scrlAddVit.Value
    End Sub

    Private Sub scrlAddSpr_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlAddSpr.ValueChanged
        lblAddSpr.Text = "+Spr: " & scrlAddSpr.Value
        Item(EditorIndex).Add_Stat(Stats.spirit) = scrlAddSpr.Value
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call ItemEditorOk()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call ItemEditorCancel()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tmpIndex As Long

        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub

        ClearItem(EditorIndex + 1)

        tmpIndex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex

        ItemEditorInit()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        Dim tmpIndex As Long
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        tmpIndex = lstIndex.SelectedIndex
        Item(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpIndex
    End Sub

    Private Sub lstIndex_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstIndex.Click
        ItemEditorInit()
    End Sub

    Private Sub scrlPrice_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scrlPrice.ValueChanged
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPrice.Text = "Price: " & scrlPrice.Value
        Item(EditorIndex).Price = scrlPrice.Value
    End Sub

    Private Sub picItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picItem.Paint
        'Dont let it auto paint ;)
    End Sub

    Private Sub picPaperdoll_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picPaperdoll.Paint
        'Dont let it auto paint :0
    End Sub

    Private Sub tmrDrawPicPaperdoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Visible = True Then
            If Me.WindowState = FormWindowState.Normal Then
                EditorItem_DrawItem()
                EditorItem_DrawPaperdoll()
            End If
        End If
    End Sub

    Private Sub frmEditor_Item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        scrlPic.Maximum = NumItems
        scrlPic.LargeChange = 1
        scrlAnim.Maximum = MAX_ANIMATIONS
        scrlPaperdoll.Maximum = NumPaperdolls
    End Sub

    Private Sub scrlPrice_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles scrlPrice.Scroll
        If EditorIndex = 0 Or EditorIndex > MAX_ITEMS Then Exit Sub
        lblPrice.Text = "Price: " & scrlPrice.Value
        Item(EditorIndex).Price = scrlPrice.Value
    End Sub

    Private Sub lstIndex_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIndex.SelectedIndexChanged

    End Sub
End Class