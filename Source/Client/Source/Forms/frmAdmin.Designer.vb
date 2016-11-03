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
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRespawn
        '
        Me.btnRespawn.Location = New System.Drawing.Point(19, 54)
        Me.btnRespawn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRespawn.Name = "btnRespawn"
        Me.btnRespawn.Size = New System.Drawing.Size(304, 27)
        Me.btnRespawn.TabIndex = 34
        Me.btnRespawn.Text = "Respawn Map"
        Me.btnRespawn.UseVisualStyleBackColor = True
        '
        'btnMapReport
        '
        Me.btnMapReport.Location = New System.Drawing.Point(8, 417)
        Me.btnMapReport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMapReport.Name = "btnMapReport"
        Me.btnMapReport.Size = New System.Drawing.Size(317, 27)
        Me.btnMapReport.TabIndex = 33
        Me.btnMapReport.Text = "Refresh List"
        Me.btnMapReport.UseVisualStyleBackColor = True
        '
        'btnDelBans
        '
        Me.btnDelBans.Location = New System.Drawing.Point(168, 20)
        Me.btnDelBans.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelBans.Name = "btnDelBans"
        Me.btnDelBans.Size = New System.Drawing.Size(155, 27)
        Me.btnDelBans.TabIndex = 32
        Me.btnDelBans.Text = "Delete Bans"
        Me.btnDelBans.UseVisualStyleBackColor = True
        '
        'btnALoc
        '
        Me.btnALoc.Location = New System.Drawing.Point(19, 20)
        Me.btnALoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnALoc.Name = "btnALoc"
        Me.btnALoc.Size = New System.Drawing.Size(141, 27)
        Me.btnALoc.TabIndex = 31
        Me.btnALoc.Text = "Location"
        Me.btnALoc.UseVisualStyleBackColor = True
        '
        'btnLevelUp
        '
        Me.btnLevelUp.Location = New System.Drawing.Point(44, 326)
        Me.btnLevelUp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLevelUp.Name = "btnLevelUp"
        Me.btnLevelUp.Size = New System.Drawing.Size(251, 27)
        Me.btnLevelUp.TabIndex = 30
        Me.btnLevelUp.Text = "Level Up"
        Me.btnLevelUp.UseVisualStyleBackColor = True
        '
        'btnSpawnItem
        '
        Me.btnSpawnItem.Location = New System.Drawing.Point(19, 234)
        Me.btnSpawnItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSpawnItem.Name = "btnSpawnItem"
        Me.btnSpawnItem.Size = New System.Drawing.Size(304, 27)
        Me.btnSpawnItem.TabIndex = 29
        Me.btnSpawnItem.Text = "Spawn Item"
        Me.btnSpawnItem.UseVisualStyleBackColor = True
        '
        'scrlSpawnItemAmount
        '
        Me.scrlSpawnItemAmount.Location = New System.Drawing.Point(19, 193)
        Me.scrlSpawnItemAmount.Name = "scrlSpawnItemAmount"
        Me.scrlSpawnItemAmount.Size = New System.Drawing.Size(304, 17)
        Me.scrlSpawnItemAmount.TabIndex = 28
        '
        'scrlSpawnItem
        '
        Me.scrlSpawnItem.Location = New System.Drawing.Point(19, 133)
        Me.scrlSpawnItem.Name = "scrlSpawnItem"
        Me.scrlSpawnItem.Size = New System.Drawing.Size(304, 17)
        Me.scrlSpawnItem.TabIndex = 27
        '
        'lblSpawnItemAmount
        '
        Me.lblSpawnItemAmount.AutoSize = True
        Me.lblSpawnItemAmount.Location = New System.Drawing.Point(15, 177)
        Me.lblSpawnItemAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSpawnItemAmount.Name = "lblSpawnItemAmount"
        Me.lblSpawnItemAmount.Size = New System.Drawing.Size(72, 17)
        Me.lblSpawnItemAmount.TabIndex = 26
        Me.lblSpawnItemAmount.Text = "Amount: 1"
        '
        'lblItemSpawn
        '
        Me.lblItemSpawn.AutoSize = True
        Me.lblItemSpawn.Location = New System.Drawing.Point(15, 117)
        Me.lblItemSpawn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemSpawn.Name = "lblItemSpawn"
        Me.lblItemSpawn.Size = New System.Drawing.Size(122, 17)
        Me.lblItemSpawn.TabIndex = 25
        Me.lblItemSpawn.Text = "Spawn Item: None"
        '
        'btnAdminSetSprite
        '
        Me.btnAdminSetSprite.Location = New System.Drawing.Point(179, 219)
        Me.btnAdminSetSprite.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminSetSprite.Name = "btnAdminSetSprite"
        Me.btnAdminSetSprite.Size = New System.Drawing.Size(144, 27)
        Me.btnAdminSetSprite.TabIndex = 16
        Me.btnAdminSetSprite.Text = "Set Player Sprite"
        Me.btnAdminSetSprite.UseVisualStyleBackColor = True
        '
        'btnAdminWarpTo
        '
        Me.btnAdminWarpTo.Location = New System.Drawing.Point(179, 185)
        Me.btnAdminWarpTo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminWarpTo.Name = "btnAdminWarpTo"
        Me.btnAdminWarpTo.Size = New System.Drawing.Size(144, 27)
        Me.btnAdminWarpTo.TabIndex = 15
        Me.btnAdminWarpTo.Text = "Warp To Map"
        Me.btnAdminWarpTo.UseVisualStyleBackColor = True
        '
        'txtAdminSprite
        '
        Me.txtAdminSprite.Location = New System.Drawing.Point(111, 219)
        Me.txtAdminSprite.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAdminSprite.Name = "txtAdminSprite"
        Me.txtAdminSprite.Size = New System.Drawing.Size(59, 22)
        Me.txtAdminSprite.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 223)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Sprite Number:"
        '
        'txtAdminMap
        '
        Me.txtAdminMap.Location = New System.Drawing.Point(111, 187)
        Me.txtAdminMap.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAdminMap.Name = "txtAdminMap"
        Me.txtAdminMap.Size = New System.Drawing.Size(59, 22)
        Me.txtAdminMap.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 191)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Map Number:"
        '
        'btnAdminSetAccess
        '
        Me.btnAdminSetAccess.Location = New System.Drawing.Point(12, 148)
        Me.btnAdminSetAccess.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminSetAccess.Name = "btnAdminSetAccess"
        Me.btnAdminSetAccess.Size = New System.Drawing.Size(311, 27)
        Me.btnAdminSetAccess.TabIndex = 9
        Me.btnAdminSetAccess.Text = "Set Access"
        Me.btnAdminSetAccess.UseVisualStyleBackColor = True
        '
        'btnAdminWarpMe2
        '
        Me.btnAdminWarpMe2.Location = New System.Drawing.Point(169, 76)
        Me.btnAdminWarpMe2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminWarpMe2.Name = "btnAdminWarpMe2"
        Me.btnAdminWarpMe2.Size = New System.Drawing.Size(153, 27)
        Me.btnAdminWarpMe2.TabIndex = 8
        Me.btnAdminWarpMe2.Text = "Warp Me To Player"
        Me.btnAdminWarpMe2.UseVisualStyleBackColor = True
        '
        'btnAdminWarp2Me
        '
        Me.btnAdminWarp2Me.Location = New System.Drawing.Point(8, 76)
        Me.btnAdminWarp2Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminWarp2Me.Name = "btnAdminWarp2Me"
        Me.btnAdminWarp2Me.Size = New System.Drawing.Size(153, 27)
        Me.btnAdminWarp2Me.TabIndex = 7
        Me.btnAdminWarp2Me.Text = "Warp Player To Me"
        Me.btnAdminWarp2Me.UseVisualStyleBackColor = True
        '
        'btnAdminBan
        '
        Me.btnAdminBan.Location = New System.Drawing.Point(169, 42)
        Me.btnAdminBan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminBan.Name = "btnAdminBan"
        Me.btnAdminBan.Size = New System.Drawing.Size(153, 27)
        Me.btnAdminBan.TabIndex = 6
        Me.btnAdminBan.Text = "Ban Player"
        Me.btnAdminBan.UseVisualStyleBackColor = True
        '
        'btnAdminKick
        '
        Me.btnAdminKick.Location = New System.Drawing.Point(8, 42)
        Me.btnAdminKick.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdminKick.Name = "btnAdminKick"
        Me.btnAdminKick.Size = New System.Drawing.Size(153, 27)
        Me.btnAdminKick.TabIndex = 5
        Me.btnAdminKick.Text = "Kick Player"
        Me.btnAdminKick.UseVisualStyleBackColor = True
        '
        'txtAdminName
        '
        Me.txtAdminName.Location = New System.Drawing.Point(109, 10)
        Me.txtAdminName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAdminName.Name = "txtAdminName"
        Me.txtAdminName.Size = New System.Drawing.Size(212, 22)
        Me.txtAdminName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 118)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Access:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
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
        Me.lstMaps.Location = New System.Drawing.Point(8, 7)
        Me.lstMaps.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstMaps.MultiSelect = False
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(317, 405)
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
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(3, 2)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(344, 480)
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(336, 451)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Moderation"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbAccess
        '
        Me.cmbAccess.FormattingEnabled = True
        Me.cmbAccess.Items.AddRange(New Object() {"Normal Player", "Monitor (GM)", "Mapper", "Developer", "Creator"})
        Me.cmbAccess.Location = New System.Drawing.Point(76, 114)
        Me.cmbAccess.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbAccess.Name = "cmbAccess"
        Me.cmbAccess.Size = New System.Drawing.Size(245, 24)
        Me.cmbAccess.TabIndex = 17
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lstMaps)
        Me.TabPage3.Controls.Add(Me.btnMapReport)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Size = New System.Drawing.Size(336, 451)
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
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Size = New System.Drawing.Size(336, 451)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Misc"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 486)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmAdmin"
        Me.ShowIcon = False
        Me.Text = "Admin Panel"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents cmbAccess As Windows.Forms.ComboBox
End Class
