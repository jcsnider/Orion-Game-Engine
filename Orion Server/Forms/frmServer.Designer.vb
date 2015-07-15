<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServer
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
        Me.components = New System.ComponentModel.Container()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstView = New System.Windows.Forms.ListView()
        Me.colIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIPAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAccount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCharacter = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MakeAdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtChat = New System.Windows.Forms.TextBox()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkServerLog = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnShutDown = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReloadAnimations = New System.Windows.Forms.Button()
        Me.btnReloadResources = New System.Windows.Forms.Button()
        Me.btnReloadItems = New System.Windows.Forms.Button()
        Me.btnReloadNPCs = New System.Windows.Forms.Button()
        Me.btnReloadShops = New System.Windows.Forms.Button()
        Me.btnReloadSpells = New System.Windows.Forms.Button()
        Me.btnReloadMaps = New System.Windows.Forms.Button()
        Me.btnReloadClasses = New System.Windows.Forms.Button()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimedShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lstviewmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KickToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MakeAdminToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAdminToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.notifyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimedShutdownToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrUpdatePlayerList = New System.Windows.Forms.Timer(Me.components)
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.lstviewmenu.SuspendLayout()
        Me.notifyMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstView)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(517, 231)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Joueurs"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstView
        '
        Me.lstView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIndex, Me.colIPAddress, Me.colAccount, Me.colCharacter})
        Me.lstView.FullRowSelect = True
        Me.lstView.GridLines = True
        Me.lstView.HideSelection = False
        Me.lstView.Location = New System.Drawing.Point(6, 6)
        Me.lstView.MultiSelect = False
        Me.lstView.Name = "lstView"
        Me.lstView.Size = New System.Drawing.Size(510, 219)
        Me.lstView.TabIndex = 1
        Me.lstView.UseCompatibleStateImageBehavior = False
        Me.lstView.View = System.Windows.Forms.View.Details
        '
        'colIndex
        '
        Me.colIndex.Text = "Index"
        Me.colIndex.Width = 50
        '
        'colIPAddress
        '
        Me.colIPAddress.Text = "Adresse IP"
        Me.colIPAddress.Width = 150
        '
        'colAccount
        '
        Me.colAccount.Text = "Compte"
        Me.colAccount.Width = 140
        '
        'colCharacter
        '
        Me.colCharacter.Text = "Personnage"
        Me.colCharacter.Width = 140
        '
        'MakeAdminToolStripMenuItem
        '
        Me.MakeAdminToolStripMenuItem.Name = "MakeAdminToolStripMenuItem"
        Me.MakeAdminToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MakeAdminToolStripMenuItem.Text = "Mettre les droit administrateur"
        '
        'RemoveAdminToolStripMenuItem
        '
        Me.RemoveAdminToolStripMenuItem.Name = "RemoveAdminToolStripMenuItem"
        Me.RemoveAdminToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RemoveAdminToolStripMenuItem.Text = "Supprimer les droits administrateur"
        '
        'KickToolStripMenuItem
        '
        Me.KickToolStripMenuItem.Name = "KickToolStripMenuItem"
        Me.KickToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.KickToolStripMenuItem.Text = "Kicker"
        '
        'BanToolStripMenuItem
        '
        Me.BanToolStripMenuItem.Name = "BanToolStripMenuItem"
        Me.BanToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.BanToolStripMenuItem.Text = "Bannir"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(525, 257)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtChat)
        Me.TabPage1.Controls.Add(Me.txtText)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(517, 231)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Console"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtChat
        '
        Me.txtChat.Location = New System.Drawing.Point(13, 193)
        Me.txtChat.Name = "txtChat"
        Me.txtChat.Size = New System.Drawing.Size(481, 20)
        Me.txtChat.TabIndex = 1
        '
        'txtText
        '
        Me.txtText.BackColor = System.Drawing.SystemColors.Control
        Me.txtText.Location = New System.Drawing.Point(13, 6)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.ReadOnly = True
        Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtText.Size = New System.Drawing.Size(482, 169)
        Me.txtText.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(517, 231)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Controle"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkServerLog)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnShutDown)
        Me.GroupBox2.Location = New System.Drawing.Point(209, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 122)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Serveur"
        '
        'chkServerLog
        '
        Me.chkServerLog.AutoSize = True
        Me.chkServerLog.Location = New System.Drawing.Point(6, 92)
        Me.chkServerLog.Name = "chkServerLog"
        Me.chkServerLog.Size = New System.Drawing.Size(97, 17)
        Me.chkServerLog.TabIndex = 11
        Me.chkServerLog.Text = "Log du serveur"
        Me.chkServerLog.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(6, 55)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(109, 31)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Quitter"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShutDown
        '
        Me.btnShutDown.Location = New System.Drawing.Point(6, 19)
        Me.btnShutDown.Name = "btnShutDown"
        Me.btnShutDown.Size = New System.Drawing.Size(109, 31)
        Me.btnShutDown.TabIndex = 9
        Me.btnShutDown.Text = "Eteindre"
        Me.btnShutDown.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReloadAnimations)
        Me.GroupBox1.Controls.Add(Me.btnReloadResources)
        Me.GroupBox1.Controls.Add(Me.btnReloadItems)
        Me.GroupBox1.Controls.Add(Me.btnReloadNPCs)
        Me.GroupBox1.Controls.Add(Me.btnReloadShops)
        Me.GroupBox1.Controls.Add(Me.btnReloadSpells)
        Me.GroupBox1.Controls.Add(Me.btnReloadMaps)
        Me.GroupBox1.Controls.Add(Me.btnReloadClasses)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 207)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recharger"
        '
        'btnReloadAnimations
        '
        Me.btnReloadAnimations.Location = New System.Drawing.Point(96, 94)
        Me.btnReloadAnimations.Name = "btnReloadAnimations"
        Me.btnReloadAnimations.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadAnimations.TabIndex = 7
        Me.btnReloadAnimations.Text = "Animations"
        Me.btnReloadAnimations.UseVisualStyleBackColor = True
        '
        'btnReloadResources
        '
        Me.btnReloadResources.Location = New System.Drawing.Point(96, 57)
        Me.btnReloadResources.Name = "btnReloadResources"
        Me.btnReloadResources.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadResources.TabIndex = 6
        Me.btnReloadResources.Text = "Ressources"
        Me.btnReloadResources.UseVisualStyleBackColor = True
        '
        'btnReloadItems
        '
        Me.btnReloadItems.Location = New System.Drawing.Point(96, 20)
        Me.btnReloadItems.Name = "btnReloadItems"
        Me.btnReloadItems.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadItems.TabIndex = 5
        Me.btnReloadItems.Text = "Objets"
        Me.btnReloadItems.UseVisualStyleBackColor = True
        '
        'btnReloadNPCs
        '
        Me.btnReloadNPCs.Location = New System.Drawing.Point(7, 168)
        Me.btnReloadNPCs.Name = "btnReloadNPCs"
        Me.btnReloadNPCs.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadNPCs.TabIndex = 4
        Me.btnReloadNPCs.Text = "PNJ"
        Me.btnReloadNPCs.UseVisualStyleBackColor = True
        '
        'btnReloadShops
        '
        Me.btnReloadShops.Location = New System.Drawing.Point(6, 131)
        Me.btnReloadShops.Name = "btnReloadShops"
        Me.btnReloadShops.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadShops.TabIndex = 3
        Me.btnReloadShops.Text = "Magasins"
        Me.btnReloadShops.UseVisualStyleBackColor = True
        '
        'btnReloadSpells
        '
        Me.btnReloadSpells.Location = New System.Drawing.Point(7, 94)
        Me.btnReloadSpells.Name = "btnReloadSpells"
        Me.btnReloadSpells.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadSpells.TabIndex = 2
        Me.btnReloadSpells.Text = "Magies"
        Me.btnReloadSpells.UseVisualStyleBackColor = True
        '
        'btnReloadMaps
        '
        Me.btnReloadMaps.Location = New System.Drawing.Point(6, 57)
        Me.btnReloadMaps.Name = "btnReloadMaps"
        Me.btnReloadMaps.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadMaps.TabIndex = 1
        Me.btnReloadMaps.Text = "Cartes"
        Me.btnReloadMaps.UseVisualStyleBackColor = True
        '
        'btnReloadClasses
        '
        Me.btnReloadClasses.Location = New System.Drawing.Point(7, 20)
        Me.btnReloadClasses.Name = "btnReloadClasses"
        Me.btnReloadClasses.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadClasses.TabIndex = 0
        Me.btnReloadClasses.Text = "Classes"
        Me.btnReloadClasses.UseVisualStyleBackColor = True
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.ToolStripMenuItem1.Text = "Afficher le serveur"
        '
        'TimedShutdownToolStripMenuItem
        '
        Me.TimedShutdownToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomMessageToolStripMenuItem})
        Me.TimedShutdownToolStripMenuItem.Name = "TimedShutdownToolStripMenuItem"
        Me.TimedShutdownToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.TimedShutdownToolStripMenuItem.Text = "Arret programmé"
        '
        'CustomMessageToolStripMenuItem
        '
        Me.CustomMessageToolStripMenuItem.Name = "CustomMessageToolStripMenuItem"
        Me.CustomMessageToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.CustomMessageToolStripMenuItem.Text = "Message personnalisé ?"
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ShutdownToolStripMenuItem.Text = "Arret"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon2"
        Me.NotifyIcon1.Visible = True
        '
        'lstviewmenu
        '
        Me.lstviewmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KickToolStripMenuItem1, Me.DisconnectToolStripMenuItem, Me.BanToolStripMenuItem1, Me.MakeAdminToolStripMenuItem1, Me.RemoveAdminToolStripMenuItem1})
        Me.lstviewmenu.Name = "ContextMenuStrip1"
        Me.lstviewmenu.Size = New System.Drawing.Size(265, 114)
        '
        'KickToolStripMenuItem1
        '
        Me.KickToolStripMenuItem1.Name = "KickToolStripMenuItem1"
        Me.KickToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.KickToolStripMenuItem1.Text = "Kicker"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.DisconnectToolStripMenuItem.Text = "Déconnecter"
        '
        'BanToolStripMenuItem1
        '
        Me.BanToolStripMenuItem1.Name = "BanToolStripMenuItem1"
        Me.BanToolStripMenuItem1.Size = New System.Drawing.Size(240, 22)
        Me.BanToolStripMenuItem1.Text = "Bannir"
        '
        'MakeAdminToolStripMenuItem1
        '
        Me.MakeAdminToolStripMenuItem1.Name = "MakeAdminToolStripMenuItem1"
        Me.MakeAdminToolStripMenuItem1.Size = New System.Drawing.Size(264, 22)
        Me.MakeAdminToolStripMenuItem1.Text = "Donner les droits Administrateur"
        '
        'RemoveAdminToolStripMenuItem1
        '
        Me.RemoveAdminToolStripMenuItem1.Name = "RemoveAdminToolStripMenuItem1"
        Me.RemoveAdminToolStripMenuItem1.Size = New System.Drawing.Size(264, 22)
        Me.RemoveAdminToolStripMenuItem1.Text = "Supprimer les droits administrateurs"
        '
        'notifyMenu
        '
        Me.notifyMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowServerToolStripMenuItem, Me.TimedShutdownToolStripMenuItem1, Me.ShutdownToolStripMenuItem1})
        Me.notifyMenu.Name = "notifyMenu"
        Me.notifyMenu.Size = New System.Drawing.Size(166, 70)
        '
        'ShowServerToolStripMenuItem
        '
        Me.ShowServerToolStripMenuItem.Name = "ShowServerToolStripMenuItem"
        Me.ShowServerToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ShowServerToolStripMenuItem.Text = "Afficher le serveur"
        '
        'TimedShutdownToolStripMenuItem1
        '
        Me.TimedShutdownToolStripMenuItem1.Name = "TimedShutdownToolStripMenuItem1"
        Me.TimedShutdownToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.TimedShutdownToolStripMenuItem1.Text = "Arret programmé"
        '
        'ShutdownToolStripMenuItem1
        '
        Me.ShutdownToolStripMenuItem1.Name = "ShutdownToolStripMenuItem1"
        Me.ShutdownToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.ShutdownToolStripMenuItem1.Text = "Arret"
        '
        'tmrUpdatePlayerList
        '
        Me.tmrUpdatePlayerList.Interval = 5000
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 277)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serveur"
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.lstviewmenu.ResumeLayout(False)
        Me.notifyMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtChat As System.Windows.Forms.TextBox
    Public WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents lstView As System.Windows.Forms.ListView
    Friend WithEvents colIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIPAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAccount As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCharacter As System.Windows.Forms.ColumnHeader
    Friend WithEvents MakeAdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveAdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KickToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimedShutdownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstviewmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents KickToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MakeAdminToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveAdminToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents notifyMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimedShutdownToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReloadNPCs As System.Windows.Forms.Button
    Friend WithEvents btnReloadShops As System.Windows.Forms.Button
    Friend WithEvents btnReloadSpells As System.Windows.Forms.Button
    Friend WithEvents btnReloadMaps As System.Windows.Forms.Button
    Friend WithEvents btnReloadClasses As System.Windows.Forms.Button
    Friend WithEvents btnReloadAnimations As System.Windows.Forms.Button
    Friend WithEvents btnReloadResources As System.Windows.Forms.Button
    Friend WithEvents btnReloadItems As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkServerLog As System.Windows.Forms.CheckBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnShutDown As System.Windows.Forms.Button
    Friend WithEvents tmrUpdatePlayerList As System.Windows.Forms.Timer

End Class
