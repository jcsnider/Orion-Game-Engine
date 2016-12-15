Imports System.Windows.Forms

Public Class frmAdmin
    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set values for admin panel
        scrlSpawnItem.Maximum = MAX_ITEMS
        scrlSpawnItem.Value = 1
    End Sub

#Region "Moderation"
    Private Sub btnAdminWarpTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminWarpTo.Click
        Dim n As Integer

        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminMap.Text)) < 1 Then
            Exit Sub
        End If

        If Not IsNumeric(Trim$(txtAdminMap.Text)) Then
            Exit Sub
        End If

        n = Trim$(txtAdminMap.Text)

        ' Check to make sure its a valid map #
        If n > 0 And n <= MAX_MAPS Then
            WarpTo(n)
        Else
            AddText("Invalid map number.", ColorType.BrightRed)
        End If
    End Sub

    Private Sub btnAdminBan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminBan.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        SendBan(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminKick_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminKick.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        SendKick(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminWarp2Me_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminWarp2Me.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Then
            Exit Sub
        End If

        WarpToMe(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminWarpMe2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminWarpMe2.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 1 Then
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Then
            Exit Sub
        End If

        WarpMeTo(Trim$(txtAdminName.Text))
    End Sub

    Private Sub btnAdminSetAccess_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminSetAccess.Click
        If GetPlayerAccess(MyIndex) < AdminType.CREATOR Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminName.Text)) < 2 Then
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Or cmbAccess.SelectedIndex < 0 Then
            Exit Sub
        End If

        SendSetAccess(Trim$(txtAdminName.Text), cmbAccess.SelectedIndex)
    End Sub

    Private Sub btnAdminSetSprite_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdminSetSprite.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        If Len(Trim$(txtAdminSprite.Text)) < 1 Then
            Exit Sub
        End If

        If Not IsNumeric(Trim$(txtAdminSprite.Text)) Then
            Exit Sub
        End If

        SendSetSprite(Trim$(txtAdminSprite.Text))
    End Sub
#End Region

#Region "Editors"
    Private Sub btnMapEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapEditor.Click

        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        SendRequestEditMap()
    End Sub
    'Private Sub btnItemEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnItemEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
    '        Exit Sub
    '    End If

    '    SendRequestEditItem()
    'End Sub

    'Private Sub btnResourceEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResourceEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
    '        Exit Sub
    '    End If

    '    SendRequestEditResource()
    'End Sub

    'Private Sub btnNPCEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNPCEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
    '        Exit Sub
    '    End If

    '    SendRequestEditNpc()
    'End Sub

    'Private Sub btnSkillEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSkillEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
    '        Exit Sub
    '    End If

    '    SendRequestEditSkill()
    'End Sub

    'Private Sub btnShopEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShopEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
    '        Exit Sub
    '    End If

    '    SendRequestEditShop()
    'End Sub

    'Private Sub btnAnimationEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnimationEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
    '        Exit Sub
    '    End If

    '    SendRequestEditAnimation()
    'End Sub

    'Private Sub btnQuest_Click(sender As Object, e As EventArgs) Handles btnQuest.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        Exit Sub
    '    End If

    '    SendRequestEditQuest()
    'End Sub

    'Private Sub btnhouseEditor_Click(sender As Object, e As EventArgs) Handles btnhouseEditor.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
    '        Exit Sub
    '    End If
    '    SendRequestEditHouse()
    'End Sub

    'Private Sub btnProjectiles_Click(sender As Object, e As EventArgs) Handles btnProjectiles.Click
    '    If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
    '        Exit Sub
    '    End If
    '    SendRequestEditProjectiles()
    'End Sub
#End Region

#Region "Map Report"
    Private Sub btnMapReport_Click(sender As Object, e As EventArgs) Handles btnMapReport.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If
        SendRequestMapreport()
    End Sub

    Private Sub lstMaps_DoubleClick(sender As Object, e As EventArgs) Handles lstMaps.DoubleClick
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        ' Check to make sure its a valid map #
        If lstMaps.FocusedItem.Index + 1 > 0 And lstMaps.FocusedItem.Index + 1 <= MAX_MAPS Then
            WarpTo(lstMaps.FocusedItem.Index + 1)
        Else
            AddText("Invalid map number: " & lstMaps.FocusedItem.Index + 1, QColorType.AlertColor)
        End If
    End Sub
#End Region

#Region "Misc"
    Private Sub scrlSpawnItem_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlSpawnItem.Scroll
        lblItemSpawn.Text = "Item: " & Trim$(Item(scrlSpawnItem.Value).Name)
        If Item(scrlSpawnItem.Value).Type = ItemType.CURRENCY Or Item(scrlSpawnItem.Value).Stackable = 1 Then
            scrlSpawnItemAmount.Enabled = True
            scrlSpawnItemAmount.Maximum = 100000
            Exit Sub
        End If
        scrlSpawnItemAmount.Enabled = False
    End Sub

    Private Sub scrlSpawnItemAmount_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles scrlSpawnItemAmount.Scroll
        lblSpawnItemAmount.Text = "Amount: " & scrlSpawnItemAmount.Value
    End Sub

    Private Sub btnSpawnItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSpawnItem.Click
        If GetPlayerAccess(MyIndex) < AdminType.CREATOR Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        SendSpawnItem(scrlSpawnItem.Value, scrlSpawnItemAmount.Value)
    End Sub

    Private Sub btnLevelUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLevelUp.Click
        If GetPlayerAccess(MyIndex) < AdminType.DEVELOPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        SendRequestLevelUp()

    End Sub

    Private Sub btnALoc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnALoc.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        BLoc = Not BLoc
    End Sub

    Private Sub btnDelBans_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelBans.Click
        If GetPlayerAccess(MyIndex) < AdminType.CREATOR Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        SendBanDestroy()
    End Sub

    Private Sub btnRespawn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRespawn.Click
        If GetPlayerAccess(MyIndex) < AdminType.MAPPER Then
            AddText("You need to be a high enough staff member to do this!", QColorType.AlertColor)
            Exit Sub
        End If

        SendMapRespawn()
    End Sub

#End Region





End Class