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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
        Me.picAdmin = New System.Windows.Forms.Panel()
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
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.txtAdminAccess = New System.Windows.Forms.TextBox()
        Me.txtAdminName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMapreport = New System.Windows.Forms.Panel()
        Me.lstMaps = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblMapReportClose = New System.Windows.Forms.Label()
        Me.btnProjectiles = New System.Windows.Forms.Button()
        Me.picAdmin.SuspendLayout()
        Me.pnlMapreport.SuspendLayout()
        Me.SuspendLayout()
        '
        'picAdmin
        '
        Me.picAdmin.BackColor = System.Drawing.Color.Silver
        Me.picAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAdmin.Controls.Add(Me.btnProjectiles)
        Me.picAdmin.Controls.Add(Me.btnhouseEditor)
        Me.picAdmin.Controls.Add(Me.btnQuest)
        Me.picAdmin.Controls.Add(Me.btnRespawn)
        Me.picAdmin.Controls.Add(Me.btnMapReport)
        Me.picAdmin.Controls.Add(Me.btnDelBans)
        Me.picAdmin.Controls.Add(Me.btnALoc)
        Me.picAdmin.Controls.Add(Me.btnLevelUp)
        Me.picAdmin.Controls.Add(Me.btnSpawnItem)
        Me.picAdmin.Controls.Add(Me.scrlSpawnItemAmount)
        Me.picAdmin.Controls.Add(Me.scrlSpawnItem)
        Me.picAdmin.Controls.Add(Me.lblSpawnItemAmount)
        Me.picAdmin.Controls.Add(Me.lblItemSpawn)
        Me.picAdmin.Controls.Add(Me.btnAnimationEditor)
        Me.picAdmin.Controls.Add(Me.btnShopEditor)
        Me.picAdmin.Controls.Add(Me.btnSpellEditor)
        Me.picAdmin.Controls.Add(Me.btnNPCEditor)
        Me.picAdmin.Controls.Add(Me.btnResourceEditor)
        Me.picAdmin.Controls.Add(Me.btnItemEditor)
        Me.picAdmin.Controls.Add(Me.btnMapEditor)
        Me.picAdmin.Controls.Add(Me.Label6)
        Me.picAdmin.Controls.Add(Me.btnAdminSetSprite)
        Me.picAdmin.Controls.Add(Me.btnAdminWarpTo)
        Me.picAdmin.Controls.Add(Me.txtAdminSprite)
        Me.picAdmin.Controls.Add(Me.Label5)
        Me.picAdmin.Controls.Add(Me.txtAdminMap)
        Me.picAdmin.Controls.Add(Me.Label4)
        Me.picAdmin.Controls.Add(Me.btnAdminSetAccess)
        Me.picAdmin.Controls.Add(Me.btnAdminWarpMe2)
        Me.picAdmin.Controls.Add(Me.btnAdminWarp2Me)
        Me.picAdmin.Controls.Add(Me.btnAdminBan)
        Me.picAdmin.Controls.Add(Me.btnAdminKick)
        Me.picAdmin.Controls.Add(Me.txtAdminAccess)
        Me.picAdmin.Controls.Add(Me.txtAdminName)
        Me.picAdmin.Controls.Add(Me.Label3)
        Me.picAdmin.Controls.Add(Me.Label2)
        Me.picAdmin.Controls.Add(Me.Label1)
        Me.picAdmin.Location = New System.Drawing.Point(3, 3)
        Me.picAdmin.Name = "picAdmin"
        Me.picAdmin.Size = New System.Drawing.Size(230, 523)
        Me.picAdmin.TabIndex = 10
        '
        'btnhouseEditor
        '
        Me.btnhouseEditor.Location = New System.Drawing.Point(22, 318)
        Me.btnhouseEditor.Name = "btnhouseEditor"
        Me.btnhouseEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnhouseEditor.TabIndex = 36
        Me.btnhouseEditor.Text = "Houses"
        Me.btnhouseEditor.UseVisualStyleBackColor = True
        '
        'btnQuest
        '
        Me.btnQuest.Location = New System.Drawing.Point(22, 226)
        Me.btnQuest.Name = "btnQuest"
        Me.btnQuest.Size = New System.Drawing.Size(84, 22)
        Me.btnQuest.TabIndex = 35
        Me.btnQuest.Text = "Quest"
        Me.btnQuest.UseVisualStyleBackColor = True
        '
        'btnRespawn
        '
        Me.btnRespawn.Location = New System.Drawing.Point(126, 370)
        Me.btnRespawn.Name = "btnRespawn"
        Me.btnRespawn.Size = New System.Drawing.Size(84, 22)
        Me.btnRespawn.TabIndex = 34
        Me.btnRespawn.Text = "Respawn"
        Me.btnRespawn.UseVisualStyleBackColor = True
        '
        'btnMapReport
        '
        Me.btnMapReport.Location = New System.Drawing.Point(126, 344)
        Me.btnMapReport.Name = "btnMapReport"
        Me.btnMapReport.Size = New System.Drawing.Size(84, 22)
        Me.btnMapReport.TabIndex = 33
        Me.btnMapReport.Text = "Map Report"
        Me.btnMapReport.UseVisualStyleBackColor = True
        '
        'btnDelBans
        '
        Me.btnDelBans.Location = New System.Drawing.Point(22, 370)
        Me.btnDelBans.Name = "btnDelBans"
        Me.btnDelBans.Size = New System.Drawing.Size(84, 22)
        Me.btnDelBans.TabIndex = 32
        Me.btnDelBans.Text = "Del Bans"
        Me.btnDelBans.UseVisualStyleBackColor = True
        '
        'btnALoc
        '
        Me.btnALoc.Location = New System.Drawing.Point(22, 344)
        Me.btnALoc.Name = "btnALoc"
        Me.btnALoc.Size = New System.Drawing.Size(84, 22)
        Me.btnALoc.TabIndex = 31
        Me.btnALoc.Text = "Loc"
        Me.btnALoc.UseVisualStyleBackColor = True
        '
        'btnLevelUp
        '
        Me.btnLevelUp.Location = New System.Drawing.Point(19, 496)
        Me.btnLevelUp.Name = "btnLevelUp"
        Me.btnLevelUp.Size = New System.Drawing.Size(188, 22)
        Me.btnLevelUp.TabIndex = 30
        Me.btnLevelUp.Text = "Level Up"
        Me.btnLevelUp.UseVisualStyleBackColor = True
        '
        'btnSpawnItem
        '
        Me.btnSpawnItem.Location = New System.Drawing.Point(17, 469)
        Me.btnSpawnItem.Name = "btnSpawnItem"
        Me.btnSpawnItem.Size = New System.Drawing.Size(190, 22)
        Me.btnSpawnItem.TabIndex = 29
        Me.btnSpawnItem.Text = "Spawn Item"
        Me.btnSpawnItem.UseVisualStyleBackColor = True
        '
        'scrlSpawnItemAmount
        '
        Me.scrlSpawnItemAmount.Location = New System.Drawing.Point(21, 448)
        Me.scrlSpawnItemAmount.Name = "scrlSpawnItemAmount"
        Me.scrlSpawnItemAmount.Size = New System.Drawing.Size(187, 17)
        Me.scrlSpawnItemAmount.TabIndex = 28
        '
        'scrlSpawnItem
        '
        Me.scrlSpawnItem.Location = New System.Drawing.Point(21, 415)
        Me.scrlSpawnItem.Name = "scrlSpawnItem"
        Me.scrlSpawnItem.Size = New System.Drawing.Size(187, 17)
        Me.scrlSpawnItem.TabIndex = 27
        '
        'lblSpawnItemAmount
        '
        Me.lblSpawnItemAmount.AutoSize = True
        Me.lblSpawnItemAmount.Location = New System.Drawing.Point(19, 435)
        Me.lblSpawnItemAmount.Name = "lblSpawnItemAmount"
        Me.lblSpawnItemAmount.Size = New System.Drawing.Size(55, 13)
        Me.lblSpawnItemAmount.TabIndex = 26
        Me.lblSpawnItemAmount.Text = "Amount: 1"
        '
        'lblItemSpawn
        '
        Me.lblItemSpawn.AutoSize = True
        Me.lblItemSpawn.Location = New System.Drawing.Point(19, 400)
        Me.lblItemSpawn.Name = "lblItemSpawn"
        Me.lblItemSpawn.Size = New System.Drawing.Size(95, 13)
        Me.lblItemSpawn.TabIndex = 25
        Me.lblItemSpawn.Text = "Spawn Item: None"
        '
        'btnAnimationEditor
        '
        Me.btnAnimationEditor.Location = New System.Drawing.Point(126, 295)
        Me.btnAnimationEditor.Name = "btnAnimationEditor"
        Me.btnAnimationEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnAnimationEditor.TabIndex = 24
        Me.btnAnimationEditor.Text = "Animation"
        Me.btnAnimationEditor.UseVisualStyleBackColor = True
        '
        'btnShopEditor
        '
        Me.btnShopEditor.Location = New System.Drawing.Point(22, 295)
        Me.btnShopEditor.Name = "btnShopEditor"
        Me.btnShopEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnShopEditor.TabIndex = 23
        Me.btnShopEditor.Text = "Shop"
        Me.btnShopEditor.UseVisualStyleBackColor = True
        '
        'btnSpellEditor
        '
        Me.btnSpellEditor.Location = New System.Drawing.Point(126, 272)
        Me.btnSpellEditor.Name = "btnSpellEditor"
        Me.btnSpellEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnSpellEditor.TabIndex = 22
        Me.btnSpellEditor.Text = "Spell"
        Me.btnSpellEditor.UseVisualStyleBackColor = True
        '
        'btnNPCEditor
        '
        Me.btnNPCEditor.Location = New System.Drawing.Point(22, 272)
        Me.btnNPCEditor.Name = "btnNPCEditor"
        Me.btnNPCEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnNPCEditor.TabIndex = 21
        Me.btnNPCEditor.Text = "NPC"
        Me.btnNPCEditor.UseVisualStyleBackColor = True
        '
        'btnResourceEditor
        '
        Me.btnResourceEditor.Location = New System.Drawing.Point(126, 249)
        Me.btnResourceEditor.Name = "btnResourceEditor"
        Me.btnResourceEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnResourceEditor.TabIndex = 20
        Me.btnResourceEditor.Text = "Resource"
        Me.btnResourceEditor.UseVisualStyleBackColor = True
        '
        'btnItemEditor
        '
        Me.btnItemEditor.Location = New System.Drawing.Point(22, 249)
        Me.btnItemEditor.Name = "btnItemEditor"
        Me.btnItemEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnItemEditor.TabIndex = 19
        Me.btnItemEditor.Text = "Item"
        Me.btnItemEditor.UseVisualStyleBackColor = True
        '
        'btnMapEditor
        '
        Me.btnMapEditor.Location = New System.Drawing.Point(126, 226)
        Me.btnMapEditor.Name = "btnMapEditor"
        Me.btnMapEditor.Size = New System.Drawing.Size(84, 22)
        Me.btnMapEditor.TabIndex = 18
        Me.btnMapEditor.Text = "Map"
        Me.btnMapEditor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(93, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Editors:"
        '
        'btnAdminSetSprite
        '
        Me.btnAdminSetSprite.Location = New System.Drawing.Point(127, 190)
        Me.btnAdminSetSprite.Name = "btnAdminSetSprite"
        Me.btnAdminSetSprite.Size = New System.Drawing.Size(84, 22)
        Me.btnAdminSetSprite.TabIndex = 16
        Me.btnAdminSetSprite.Text = "Set Sprite"
        Me.btnAdminSetSprite.UseVisualStyleBackColor = True
        '
        'btnAdminWarpTo
        '
        Me.btnAdminWarpTo.Location = New System.Drawing.Point(22, 190)
        Me.btnAdminWarpTo.Name = "btnAdminWarpTo"
        Me.btnAdminWarpTo.Size = New System.Drawing.Size(84, 22)
        Me.btnAdminWarpTo.TabIndex = 15
        Me.btnAdminWarpTo.Text = "Warp To"
        Me.btnAdminWarpTo.UseVisualStyleBackColor = True
        '
        'txtAdminSprite
        '
        Me.txtAdminSprite.Location = New System.Drawing.Point(165, 164)
        Me.txtAdminSprite.Name = "txtAdminSprite"
        Me.txtAdminSprite.Size = New System.Drawing.Size(45, 20)
        Me.txtAdminSprite.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(124, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Sprite#"
        '
        'txtAdminMap
        '
        Me.txtAdminMap.Location = New System.Drawing.Point(60, 164)
        Me.txtAdminMap.Name = "txtAdminMap"
        Me.txtAdminMap.Size = New System.Drawing.Size(45, 20)
        Me.txtAdminMap.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Map#"
        '
        'btnAdminSetAccess
        '
        Me.btnAdminSetAccess.Location = New System.Drawing.Point(21, 134)
        Me.btnAdminSetAccess.Name = "btnAdminSetAccess"
        Me.btnAdminSetAccess.Size = New System.Drawing.Size(190, 22)
        Me.btnAdminSetAccess.TabIndex = 9
        Me.btnAdminSetAccess.Text = "Set Access"
        Me.btnAdminSetAccess.UseVisualStyleBackColor = True
        '
        'btnAdminWarpMe2
        '
        Me.btnAdminWarpMe2.Location = New System.Drawing.Point(127, 106)
        Me.btnAdminWarpMe2.Name = "btnAdminWarpMe2"
        Me.btnAdminWarpMe2.Size = New System.Drawing.Size(84, 22)
        Me.btnAdminWarpMe2.TabIndex = 8
        Me.btnAdminWarpMe2.Text = "WarpMe2"
        Me.btnAdminWarpMe2.UseVisualStyleBackColor = True
        '
        'btnAdminWarp2Me
        '
        Me.btnAdminWarp2Me.Location = New System.Drawing.Point(21, 106)
        Me.btnAdminWarp2Me.Name = "btnAdminWarp2Me"
        Me.btnAdminWarp2Me.Size = New System.Drawing.Size(84, 22)
        Me.btnAdminWarp2Me.TabIndex = 7
        Me.btnAdminWarp2Me.Text = "Warp2Me"
        Me.btnAdminWarp2Me.UseVisualStyleBackColor = True
        '
        'btnAdminBan
        '
        Me.btnAdminBan.Location = New System.Drawing.Point(126, 80)
        Me.btnAdminBan.Name = "btnAdminBan"
        Me.btnAdminBan.Size = New System.Drawing.Size(85, 22)
        Me.btnAdminBan.TabIndex = 6
        Me.btnAdminBan.Text = "Ban"
        Me.btnAdminBan.UseVisualStyleBackColor = True
        '
        'btnAdminKick
        '
        Me.btnAdminKick.Location = New System.Drawing.Point(21, 80)
        Me.btnAdminKick.Name = "btnAdminKick"
        Me.btnAdminKick.Size = New System.Drawing.Size(84, 22)
        Me.btnAdminKick.TabIndex = 5
        Me.btnAdminKick.Text = "Kick"
        Me.btnAdminKick.UseVisualStyleBackColor = True
        '
        'txtAdminAccess
        '
        Me.txtAdminAccess.Location = New System.Drawing.Point(126, 58)
        Me.txtAdminAccess.Name = "txtAdminAccess"
        Me.txtAdminAccess.Size = New System.Drawing.Size(85, 20)
        Me.txtAdminAccess.TabIndex = 4
        '
        'txtAdminName
        '
        Me.txtAdminName.Location = New System.Drawing.Point(21, 58)
        Me.txtAdminName.Name = "txtAdminName"
        Me.txtAdminName.Size = New System.Drawing.Size(84, 20)
        Me.txtAdminName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(123, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Access:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Admin Panel"
        '
        'pnlMapreport
        '
        Me.pnlMapreport.BackColor = System.Drawing.Color.Transparent
        Me.pnlMapreport.BackgroundImage = CType(resources.GetObject("pnlMapreport.BackgroundImage"), System.Drawing.Image)
        Me.pnlMapreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMapreport.Controls.Add(Me.lstMaps)
        Me.pnlMapreport.Controls.Add(Me.lblMapReportClose)
        Me.pnlMapreport.Location = New System.Drawing.Point(15, 42)
        Me.pnlMapreport.Name = "pnlMapreport"
        Me.pnlMapreport.Size = New System.Drawing.Size(204, 275)
        Me.pnlMapreport.TabIndex = 37
        Me.pnlMapreport.Visible = False
        '
        'lstMaps
        '
        Me.lstMaps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstMaps.FullRowSelect = True
        Me.lstMaps.GridLines = True
        Me.lstMaps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMaps.HideSelection = False
        Me.lstMaps.Location = New System.Drawing.Point(13, 10)
        Me.lstMaps.MultiSelect = False
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(175, 243)
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
        Me.ColumnHeader2.Width = 120
        '
        'lblMapReportClose
        '
        Me.lblMapReportClose.AutoSize = True
        Me.lblMapReportClose.ForeColor = System.Drawing.Color.White
        Me.lblMapReportClose.Location = New System.Drawing.Point(73, 255)
        Me.lblMapReportClose.Name = "lblMapReportClose"
        Me.lblMapReportClose.Size = New System.Drawing.Size(33, 13)
        Me.lblMapReportClose.TabIndex = 1
        Me.lblMapReportClose.Text = "Close"
        '
        'btnProjectiles
        '
        Me.btnProjectiles.Location = New System.Drawing.Point(126, 318)
        Me.btnProjectiles.Name = "btnProjectiles"
        Me.btnProjectiles.Size = New System.Drawing.Size(84, 22)
        Me.btnProjectiles.TabIndex = 37
        Me.btnProjectiles.Text = "Projectiles"
        Me.btnProjectiles.UseVisualStyleBackColor = True
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 530)
        Me.Controls.Add(Me.pnlMapreport)
        Me.Controls.Add(Me.picAdmin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAdmin"
        Me.ShowIcon = False
        Me.Text = "frmAdmin"
        Me.picAdmin.ResumeLayout(False)
        Me.picAdmin.PerformLayout()
        Me.pnlMapreport.ResumeLayout(False)
        Me.pnlMapreport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picAdmin As Windows.Forms.Panel
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
    Friend WithEvents Label6 As Windows.Forms.Label
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
    Friend WithEvents txtAdminAccess As Windows.Forms.TextBox
    Friend WithEvents txtAdminName As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlMapreport As Windows.Forms.Panel
    Friend WithEvents lstMaps As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents lblMapReportClose As Windows.Forms.Label
    Friend WithEvents btnProjectiles As Windows.Forms.Button
End Class
