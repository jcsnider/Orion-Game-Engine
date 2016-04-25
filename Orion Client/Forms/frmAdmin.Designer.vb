<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnProjectiles = New System.Windows.Forms.Button()
        Me.btnhouseEditor = New System.Windows.Forms.Button()
        Me.btnQuest = New System.Windows.Forms.Button()
        Me.btnRespawn = New System.Windows.Forms.Button()
        Me.btnMapReport = New System.Windows.Forms.Button()
        Me.btnDelBans = New System.Windows.Forms.Button()
        Me.btnALoc = New System.Windows.Forms.Button()
        Me.btnLevelUp = New System.Windows.Forms.Button()
        Me.btnSpawnItem = New System.Windows.Forms.Button()
        Me.scrlSpawnItemAmount = New System.Windows.Forms.HScrollBar()
        Me.scrlSpawnItem = New System.Windows.Forms.HScrollBar()
        Me.lblSpawnItemAmount = New System.Windows.Forms.Label()
        Me.lblItemSpawn = New System.Windows.Forms.Label()
        Me.btnAnimationEditor = New System.Windows.Forms.Button()
        Me.btnShopEditor = New System.Windows.Forms.Button()
        Me.btnSpellEditor = New System.Windows.Forms.Button()
        Me.btnNPCEditor = New System.Windows.Forms.Button()
        Me.btnResourceEditor = New System.Windows.Forms.Button()
        Me.btnItemEditor = New System.Windows.Forms.Button()
        Me.btnMapEditor = New System.Windows.Forms.Button()
        Me.btnAdminSetSprite = New System.Windows.Forms.Button()
        Me.btnAdminWarpTo = New System.Windows.Forms.Button()
        Me.txtAdminSprite = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAdminMap = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdminSetAccess = New System.Windows.Forms.Button()
        Me.btnAdminWarpMe2 = New System.Windows.Forms.Button()
        Me.btnAdminWarp2Me = New System.Windows.Forms.Button()
        Me.btnAdminBan = New System.Windows.Forms.Button()
        Me.btnAdminKick = New System.Windows.Forms.Button()
        Me.txtAdminName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstMaps = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbAccess = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProjectiles
        '
        Me.btnProjectiles.Location = New System.Drawing.Point(124, 130)
        Me.btnProjectiles.Name = "btnProjectiles"
        Me.btnProjectiles.Size = New System.Drawing.Size(112, 25)
        Me.btnProjectiles.TabIndex = 37
        Me.btnProjectiles.Text = "Projectiles Editor"
        Me.btnProjectiles.UseVisualStyleBackColor = True
        '
        'btnhouseEditor
        '
        Me.btnhouseEditor.Location = New System.Drawing.Point(6, 130)
        Me.btnhouseEditor.Name = "btnhouseEditor"
        Me.btnhouseEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnhouseEditor.TabIndex = 36
        Me.btnhouseEditor.Text = "Houses Editor"
        Me.btnhouseEditor.UseVisualStyleBackColor = True
        '
        'btnQuest
        '
        Me.btnQuest.Location = New System.Drawing.Point(6, 6)
        Me.btnQuest.Name = "btnQuest"
        Me.btnQuest.Size = New System.Drawing.Size(112, 25)
        Me.btnQuest.TabIndex = 35
        Me.btnQuest.Text = "Quest Editor"
        Me.btnQuest.UseVisualStyleBackColor = True
        '
        'btnRespawn
        '
        Me.btnRespawn.Location = New System.Drawing.Point(14, 44)
        Me.btnRespawn.Name = "btnRespawn"
        Me.btnRespawn.Size = New System.Drawing.Size(228, 22)
        Me.btnRespawn.TabIndex = 34
        Me.btnRespawn.Text = "Respawn Map"
        Me.btnRespawn.UseVisualStyleBackColor = True
        '
        'btnMapReport
        '
        Me.btnMapReport.Location = New System.Drawing.Point(6, 339)
        Me.btnMapReport.Name = "btnMapReport"
        Me.btnMapReport.Size = New System.Drawing.Size(238, 22)
        Me.btnMapReport.TabIndex = 33
        Me.btnMapReport.Text = "Refresh List"
        Me.btnMapReport.UseVisualStyleBackColor = True
        '
        'btnDelBans
        '
        Me.btnDelBans.Location = New System.Drawing.Point(126, 16)
        Me.btnDelBans.Name = "btnDelBans"
        Me.btnDelBans.Size = New System.Drawing.Size(116, 22)
        Me.btnDelBans.TabIndex = 32
        Me.btnDelBans.Text = "Delete Bans"
        Me.btnDelBans.UseVisualStyleBackColor = True
        '
        'btnALoc
        '
        Me.btnALoc.Location = New System.Drawing.Point(14, 16)
        Me.btnALoc.Name = "btnALoc"
        Me.btnALoc.Size = New System.Drawing.Size(106, 22)
        Me.btnALoc.TabIndex = 31
        Me.btnALoc.Text = "Location"
        Me.btnALoc.UseVisualStyleBackColor = True
        '
        'btnLevelUp
        '
        Me.btnLevelUp.Location = New System.Drawing.Point(33, 265)
        Me.btnLevelUp.Name = "btnLevelUp"
        Me.btnLevelUp.Size = New System.Drawing.Size(188, 22)
        Me.btnLevelUp.TabIndex = 30
        Me.btnLevelUp.Text = "Level Up"
        Me.btnLevelUp.UseVisualStyleBackColor = True
        '
        'btnSpawnItem
        '
        Me.btnSpawnItem.Location = New System.Drawing.Point(14, 190)
        Me.btnSpawnItem.Name = "btnSpawnItem"
        Me.btnSpawnItem.Size = New System.Drawing.Size(228, 22)
        Me.btnSpawnItem.TabIndex = 29
        Me.btnSpawnItem.Text = "Spawn Item"
        Me.btnSpawnItem.UseVisualStyleBackColor = True
        '
        'scrlSpawnItemAmount
        '
        Me.scrlSpawnItemAmount.Location = New System.Drawing.Point(14, 157)
        Me.scrlSpawnItemAmount.Name = "scrlSpawnItemAmount"
        Me.scrlSpawnItemAmount.Size = New System.Drawing.Size(228, 17)
        Me.scrlSpawnItemAmount.TabIndex = 28
        '
        'scrlSpawnItem
        '
        Me.scrlSpawnItem.Location = New System.Drawing.Point(14, 108)
        Me.scrlSpawnItem.Name = "scrlSpawnItem"
        Me.scrlSpawnItem.Size = New System.Drawing.Size(228, 17)
        Me.scrlSpawnItem.TabIndex = 27
        '
        'lblSpawnItemAmount
        '
        Me.lblSpawnItemAmount.AutoSize = True
        Me.lblSpawnItemAmount.Location = New System.Drawing.Point(11, 144)
        Me.lblSpawnItemAmount.Name = "lblSpawnItemAmount"
        Me.lblSpawnItemAmount.Size = New System.Drawing.Size(55, 13)
        Me.lblSpawnItemAmount.TabIndex = 26
        Me.lblSpawnItemAmount.Text = "Amount: 1"
        '
        'lblItemSpawn
        '
        Me.lblItemSpawn.AutoSize = True
        Me.lblItemSpawn.Location = New System.Drawing.Point(11, 95)
        Me.lblItemSpawn.Name = "lblItemSpawn"
        Me.lblItemSpawn.Size = New System.Drawing.Size(95, 13)
        Me.lblItemSpawn.TabIndex = 25
        Me.lblItemSpawn.Text = "Spawn Item: None"
        '
        'btnAnimationEditor
        '
        Me.btnAnimationEditor.Location = New System.Drawing.Point(124, 99)
        Me.btnAnimationEditor.Name = "btnAnimationEditor"
        Me.btnAnimationEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnAnimationEditor.TabIndex = 24
        Me.btnAnimationEditor.Text = "Animation Editor"
        Me.btnAnimationEditor.UseVisualStyleBackColor = True
        '
        'btnShopEditor
        '
        Me.btnShopEditor.Location = New System.Drawing.Point(6, 99)
        Me.btnShopEditor.Name = "btnShopEditor"
        Me.btnShopEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnShopEditor.TabIndex = 23
        Me.btnShopEditor.Text = "Shop Editor"
        Me.btnShopEditor.UseVisualStyleBackColor = True
        '
        'btnSpellEditor
        '
        Me.btnSpellEditor.Location = New System.Drawing.Point(124, 68)
        Me.btnSpellEditor.Name = "btnSpellEditor"
        Me.btnSpellEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnSpellEditor.TabIndex = 22
        Me.btnSpellEditor.Text = "Spell Editor"
        Me.btnSpellEditor.UseVisualStyleBackColor = True
        '
        'btnNPCEditor
        '
        Me.btnNPCEditor.Location = New System.Drawing.Point(6, 68)
        Me.btnNPCEditor.Name = "btnNPCEditor"
        Me.btnNPCEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnNPCEditor.TabIndex = 21
        Me.btnNPCEditor.Text = "NPC Editor"
        Me.btnNPCEditor.UseVisualStyleBackColor = True
        '
        'btnResourceEditor
        '
        Me.btnResourceEditor.Location = New System.Drawing.Point(124, 37)
        Me.btnResourceEditor.Name = "btnResourceEditor"
        Me.btnResourceEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnResourceEditor.TabIndex = 20
        Me.btnResourceEditor.Text = "Resource Editor"
        Me.btnResourceEditor.UseVisualStyleBackColor = True
        '
        'btnItemEditor
        '
        Me.btnItemEditor.Location = New System.Drawing.Point(6, 37)
        Me.btnItemEditor.Name = "btnItemEditor"
        Me.btnItemEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnItemEditor.TabIndex = 19
        Me.btnItemEditor.Text = "Item Editor"
        Me.btnItemEditor.UseVisualStyleBackColor = True
        '
        'btnMapEditor
        '
        Me.btnMapEditor.Location = New System.Drawing.Point(124, 6)
        Me.btnMapEditor.Name = "btnMapEditor"
        Me.btnMapEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnMapEditor.TabIndex = 18
        Me.btnMapEditor.Text = "Map Editor"
        Me.btnMapEditor.UseVisualStyleBackColor = True
        '
        'btnAdminSetSprite
        '
        Me.btnAdminSetSprite.Location = New System.Drawing.Point(134, 178)
        Me.btnAdminSetSprite.Name = "btnAdminSetSprite"
        Me.btnAdminSetSprite.Size = New System.Drawing.Size(108, 22)
        Me.btnAdminSetSprite.TabIndex = 16
        Me.btnAdminSetSprite.Text = "Set Player Sprite"
        Me.btnAdminSetSprite.UseVisualStyleBackColor = True
        '
        'btnAdminWarpTo
        '
        Me.btnAdminWarpTo.Location = New System.Drawing.Point(134, 150)
        Me.btnAdminWarpTo.Name = "btnAdminWarpTo"
        Me.btnAdminWarpTo.Size = New System.Drawing.Size(108, 22)
        Me.btnAdminWarpTo.TabIndex = 15
        Me.btnAdminWarpTo.Text = "Warp To Map"
        Me.btnAdminWarpTo.UseVisualStyleBackColor = True
        '
        'txtAdminSprite
        '
        Me.txtAdminSprite.Location = New System.Drawing.Point(83, 178)
        Me.txtAdminSprite.Name = "txtAdminSprite"
        Me.txtAdminSprite.Size = New System.Drawing.Size(45, 20)
        Me.txtAdminSprite.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Sprite Number:"
        '
        'txtAdminMap
        '
        Me.txtAdminMap.Location = New System.Drawing.Point(83, 152)
        Me.txtAdminMap.Name = "txtAdminMap"
        Me.txtAdminMap.Size = New System.Drawing.Size(45, 20)
        Me.txtAdminMap.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Map Number:"
        '
        'btnAdminSetAccess
        '
        Me.btnAdminSetAccess.Location = New System.Drawing.Point(9, 120)
        Me.btnAdminSetAccess.Name = "btnAdminSetAccess"
        Me.btnAdminSetAccess.Size = New System.Drawing.Size(233, 22)
        Me.btnAdminSetAccess.TabIndex = 9
        Me.btnAdminSetAccess.Text = "Set Access"
        Me.btnAdminSetAccess.UseVisualStyleBackColor = True
        '
        'btnAdminWarpMe2
        '
        Me.btnAdminWarpMe2.Location = New System.Drawing.Point(127, 62)
        Me.btnAdminWarpMe2.Name = "btnAdminWarpMe2"
        Me.btnAdminWarpMe2.Size = New System.Drawing.Size(115, 22)
        Me.btnAdminWarpMe2.TabIndex = 8
        Me.btnAdminWarpMe2.Text = "Warp Me To Player"
        Me.btnAdminWarpMe2.UseVisualStyleBackColor = True
        '
        'btnAdminWarp2Me
        '
        Me.btnAdminWarp2Me.Location = New System.Drawing.Point(6, 62)
        Me.btnAdminWarp2Me.Name = "btnAdminWarp2Me"
        Me.btnAdminWarp2Me.Size = New System.Drawing.Size(115, 22)
        Me.btnAdminWarp2Me.TabIndex = 7
        Me.btnAdminWarp2Me.Text = "Warp Player To Me"
        Me.btnAdminWarp2Me.UseVisualStyleBackColor = True
        '
        'btnAdminBan
        '
        Me.btnAdminBan.Location = New System.Drawing.Point(127, 34)
        Me.btnAdminBan.Name = "btnAdminBan"
        Me.btnAdminBan.Size = New System.Drawing.Size(115, 22)
        Me.btnAdminBan.TabIndex = 6
        Me.btnAdminBan.Text = "Ban Player"
        Me.btnAdminBan.UseVisualStyleBackColor = True
        '
        'btnAdminKick
        '
        Me.btnAdminKick.Location = New System.Drawing.Point(6, 34)
        Me.btnAdminKick.Name = "btnAdminKick"
        Me.btnAdminKick.Size = New System.Drawing.Size(115, 22)
        Me.btnAdminKick.TabIndex = 5
        Me.btnAdminKick.Text = "Kick Player"
        Me.btnAdminKick.UseVisualStyleBackColor = True
        '
        'txtAdminName
        '
        Me.txtAdminName.Location = New System.Drawing.Point(82, 8)
        Me.txtAdminName.Name = "txtAdminName"
        Me.txtAdminName.Size = New System.Drawing.Size(160, 20)
        Me.txtAdminName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Access:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Player Name:"
        '
        'lstMaps
        '
        Me.lstMaps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstMaps.FullRowSelect = True
        Me.lstMaps.GridLines = True
        Me.lstMaps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMaps.HideSelection = False
        Me.lstMaps.Location = New System.Drawing.Point(6, 6)
        Me.lstMaps.MultiSelect = False
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(239, 330)
        Me.lstMaps.TabIndex = 4
        Me.lstMaps.UseCompatibleStateImageBehavior = False
        Me.lstMaps.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 200
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(258, 390)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbAccess)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtAdminName)
        Me.TabPage1.Controls.Add(Me.btnAdminKick)
        Me.TabPage1.Controls.Add(Me.btnAdminBan)
        Me.TabPage1.Controls.Add(Me.btnAdminWarp2Me)
        Me.TabPage1.Controls.Add(Me.btnAdminWarpMe2)
        Me.TabPage1.Controls.Add(Me.btnAdminSetAccess)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtAdminMap)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtAdminSprite)
        Me.TabPage1.Controls.Add(Me.btnAdminWarpTo)
        Me.TabPage1.Controls.Add(Me.btnAdminSetSprite)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(250, 364)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Moderation"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbAccess
        '
        Me.cmbAccess.FormattingEnabled = True
        Me.cmbAccess.Items.AddRange(New Object() {"Normal Player", "Monitor (GM)", "Mapper", "Developer", "Creator"})
        Me.cmbAccess.Location = New System.Drawing.Point(57, 93)
        Me.cmbAccess.Name = "cmbAccess"
        Me.cmbAccess.Size = New System.Drawing.Size(185, 21)
        Me.cmbAccess.TabIndex = 17
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnProjectiles)
        Me.TabPage2.Controls.Add(Me.btnQuest)
        Me.TabPage2.Controls.Add(Me.btnhouseEditor)
        Me.TabPage2.Controls.Add(Me.btnMapEditor)
        Me.TabPage2.Controls.Add(Me.btnItemEditor)
        Me.TabPage2.Controls.Add(Me.btnResourceEditor)
        Me.TabPage2.Controls.Add(Me.btnNPCEditor)
        Me.TabPage2.Controls.Add(Me.btnSpellEditor)
        Me.TabPage2.Controls.Add(Me.btnShopEditor)
        Me.TabPage2.Controls.Add(Me.btnAnimationEditor)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(250, 364)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Editors"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lstMaps)
        Me.TabPage3.Controls.Add(Me.btnMapReport)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(250, 364)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Map List"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnRespawn)
        Me.TabPage4.Controls.Add(Me.btnALoc)
        Me.TabPage4.Controls.Add(Me.lblItemSpawn)
        Me.TabPage4.Controls.Add(Me.btnDelBans)
        Me.TabPage4.Controls.Add(Me.lblSpawnItemAmount)
        Me.TabPage4.Controls.Add(Me.scrlSpawnItem)
        Me.TabPage4.Controls.Add(Me.btnLevelUp)
        Me.TabPage4.Controls.Add(Me.scrlSpawnItemAmount)
        Me.TabPage4.Controls.Add(Me.btnSpawnItem)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(250, 364)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Misc"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 395)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAdmin"
        Me.ShowIcon = False
        Me.Text = "Admin Panel"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnhouseEditor As Windows.Forms.Button
    Friend WithEvents btnQuest As Windows.Forms.Button
    Friend WithEvents btnRespawn As Windows.Forms.Button
    Friend WithEvents btnMapReport As Windows.Forms.Button
    Friend WithEvents btnDelBans As Windows.Forms.Button
    Friend WithEvents btnALoc As Windows.Forms.Button
    Friend WithEvents btnLevelUp As Windows.Forms.Button
    Friend WithEvents btnSpawnItem As Windows.Forms.Button
    Friend WithEvents scrlSpawnItemAmount As Windows.Forms.HScrollBar
    Friend WithEvents scrlSpawnItem As Windows.Forms.HScrollBar
    Friend WithEvents lblSpawnItemAmount As Windows.Forms.Label
    Friend WithEvents lblItemSpawn As Windows.Forms.Label
    Friend WithEvents btnAnimationEditor As Windows.Forms.Button
    Friend WithEvents btnShopEditor As Windows.Forms.Button
    Friend WithEvents btnSpellEditor As Windows.Forms.Button
    Friend WithEvents btnNPCEditor As Windows.Forms.Button
    Friend WithEvents btnResourceEditor As Windows.Forms.Button
    Friend WithEvents btnItemEditor As Windows.Forms.Button
    Friend WithEvents btnMapEditor As Windows.Forms.Button
    Friend WithEvents btnAdminSetSprite As Windows.Forms.Button
    Friend WithEvents btnAdminWarpTo As Windows.Forms.Button
    Friend WithEvents txtAdminSprite As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtAdminMap As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btnAdminSetAccess As Windows.Forms.Button
    Friend WithEvents btnAdminWarpMe2 As Windows.Forms.Button
    Friend WithEvents btnAdminWarp2Me As Windows.Forms.Button
    Friend WithEvents btnAdminBan As Windows.Forms.Button
    Friend WithEvents btnAdminKick As Windows.Forms.Button
    Friend WithEvents txtAdminName As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents lstMaps As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents btnProjectiles As Windows.Forms.Button
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents cmbAccess As Windows.Forms.ComboBox
End Class
