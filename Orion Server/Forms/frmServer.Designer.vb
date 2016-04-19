<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblNotifications = New System.Windows.Forms.Label()
        Me.btnSaveHouse = New System.Windows.Forms.Button()
        Me.txtHouseFurniture = New System.Windows.Forms.TextBox()
        Me.txtHousePrice = New System.Windows.Forms.TextBox()
        Me.txtYEntrance = New System.Windows.Forms.TextBox()
        Me.txtXEntrance = New System.Windows.Forms.TextBox()
        Me.txtBaseMap = New System.Windows.Forms.TextBox()
        Me.txtHouseName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstHouses = New System.Windows.Forms.ListBox()
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
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.TabPage2.Text = "Players"
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
        Me.colIPAddress.Text = "IP Address"
        Me.colIPAddress.Width = 150
        '
        'colAccount
        '
        Me.colAccount.Text = "Account"
        Me.colAccount.Width = 140
        '
        'colCharacter
        '
        Me.colCharacter.Text = "Character"
        Me.colCharacter.Width = 140
        '
        'MakeAdminToolStripMenuItem
        '
        Me.MakeAdminToolStripMenuItem.Name = "MakeAdminToolStripMenuItem"
        Me.MakeAdminToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MakeAdminToolStripMenuItem.Text = "Make Admin"
        '
        'RemoveAdminToolStripMenuItem
        '
        Me.RemoveAdminToolStripMenuItem.Name = "RemoveAdminToolStripMenuItem"
        Me.RemoveAdminToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RemoveAdminToolStripMenuItem.Text = "Remove Admin"
        '
        'KickToolStripMenuItem
        '
        Me.KickToolStripMenuItem.Name = "KickToolStripMenuItem"
        Me.KickToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.KickToolStripMenuItem.Text = "Kick"
        '
        'BanToolStripMenuItem
        '
        Me.BanToolStripMenuItem.Name = "BanToolStripMenuItem"
        Me.BanToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.BanToolStripMenuItem.Text = "Ban"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
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
        Me.TabPage3.Text = "Control"
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
        Me.GroupBox2.Text = "Server"
        '
        'chkServerLog
        '
        Me.chkServerLog.AutoSize = True
        Me.chkServerLog.Location = New System.Drawing.Point(6, 92)
        Me.chkServerLog.Name = "chkServerLog"
        Me.chkServerLog.Size = New System.Drawing.Size(78, 17)
        Me.chkServerLog.TabIndex = 11
        Me.chkServerLog.Text = "Server Log"
        Me.chkServerLog.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(6, 55)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(109, 31)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShutDown
        '
        Me.btnShutDown.Location = New System.Drawing.Point(6, 19)
        Me.btnShutDown.Name = "btnShutDown"
        Me.btnShutDown.Size = New System.Drawing.Size(109, 31)
        Me.btnShutDown.TabIndex = 9
        Me.btnShutDown.Text = "ShutDown"
        Me.btnShutDown.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSaveAll)
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
        Me.GroupBox1.Text = "Reload"
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
        Me.btnReloadResources.Text = "Resources"
        Me.btnReloadResources.UseVisualStyleBackColor = True
        '
        'btnReloadItems
        '
        Me.btnReloadItems.Location = New System.Drawing.Point(96, 20)
        Me.btnReloadItems.Name = "btnReloadItems"
        Me.btnReloadItems.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadItems.TabIndex = 5
        Me.btnReloadItems.Text = "Items"
        Me.btnReloadItems.UseVisualStyleBackColor = True
        '
        'btnReloadNPCs
        '
        Me.btnReloadNPCs.Location = New System.Drawing.Point(7, 168)
        Me.btnReloadNPCs.Name = "btnReloadNPCs"
        Me.btnReloadNPCs.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadNPCs.TabIndex = 4
        Me.btnReloadNPCs.Text = "NPCs"
        Me.btnReloadNPCs.UseVisualStyleBackColor = True
        '
        'btnReloadShops
        '
        Me.btnReloadShops.Location = New System.Drawing.Point(6, 131)
        Me.btnReloadShops.Name = "btnReloadShops"
        Me.btnReloadShops.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadShops.TabIndex = 3
        Me.btnReloadShops.Text = "Shops"
        Me.btnReloadShops.UseVisualStyleBackColor = True
        '
        'btnReloadSpells
        '
        Me.btnReloadSpells.Location = New System.Drawing.Point(7, 94)
        Me.btnReloadSpells.Name = "btnReloadSpells"
        Me.btnReloadSpells.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadSpells.TabIndex = 2
        Me.btnReloadSpells.Text = "Spells"
        Me.btnReloadSpells.UseVisualStyleBackColor = True
        '
        'btnReloadMaps
        '
        Me.btnReloadMaps.Location = New System.Drawing.Point(6, 57)
        Me.btnReloadMaps.Name = "btnReloadMaps"
        Me.btnReloadMaps.Size = New System.Drawing.Size(83, 31)
        Me.btnReloadMaps.TabIndex = 1
        Me.btnReloadMaps.Text = "Maps"
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
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(517, 231)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Housing"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblNotifications)
        Me.GroupBox3.Controls.Add(Me.btnSaveHouse)
        Me.GroupBox3.Controls.Add(Me.txtHouseFurniture)
        Me.GroupBox3.Controls.Add(Me.txtHousePrice)
        Me.GroupBox3.Controls.Add(Me.txtYEntrance)
        Me.GroupBox3.Controls.Add(Me.txtXEntrance)
        Me.GroupBox3.Controls.Add(Me.txtBaseMap)
        Me.GroupBox3.Controls.Add(Me.txtHouseName)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lstHouses)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(505, 219)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "House Setup"
        '
        'lblNotifications
        '
        Me.lblNotifications.AutoSize = True
        Me.lblNotifications.Location = New System.Drawing.Point(6, 195)
        Me.lblNotifications.Name = "lblNotifications"
        Me.lblNotifications.Size = New System.Drawing.Size(65, 13)
        Me.lblNotifications.TabIndex = 14
        Me.lblNotifications.Text = "Notifications"
        '
        'btnSaveHouse
        '
        Me.btnSaveHouse.Location = New System.Drawing.Point(424, 182)
        Me.btnSaveHouse.Name = "btnSaveHouse"
        Me.btnSaveHouse.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveHouse.TabIndex = 13
        Me.btnSaveHouse.Text = "Save"
        Me.btnSaveHouse.UseVisualStyleBackColor = True
        '
        'txtHouseFurniture
        '
        Me.txtHouseFurniture.Location = New System.Drawing.Point(321, 155)
        Me.txtHouseFurniture.Name = "txtHouseFurniture"
        Me.txtHouseFurniture.Size = New System.Drawing.Size(178, 20)
        Me.txtHouseFurniture.TabIndex = 12
        '
        'txtHousePrice
        '
        Me.txtHousePrice.Location = New System.Drawing.Point(321, 129)
        Me.txtHousePrice.Name = "txtHousePrice"
        Me.txtHousePrice.Size = New System.Drawing.Size(178, 20)
        Me.txtHousePrice.TabIndex = 11
        '
        'txtYEntrance
        '
        Me.txtYEntrance.Location = New System.Drawing.Point(321, 103)
        Me.txtYEntrance.Name = "txtYEntrance"
        Me.txtYEntrance.Size = New System.Drawing.Size(178, 20)
        Me.txtYEntrance.TabIndex = 10
        '
        'txtXEntrance
        '
        Me.txtXEntrance.Location = New System.Drawing.Point(321, 77)
        Me.txtXEntrance.Name = "txtXEntrance"
        Me.txtXEntrance.Size = New System.Drawing.Size(178, 20)
        Me.txtXEntrance.TabIndex = 9
        '
        'txtBaseMap
        '
        Me.txtBaseMap.Location = New System.Drawing.Point(321, 51)
        Me.txtBaseMap.Name = "txtBaseMap"
        Me.txtBaseMap.Size = New System.Drawing.Size(178, 20)
        Me.txtBaseMap.TabIndex = 8
        '
        'txtHouseName
        '
        Me.txtHouseName.Location = New System.Drawing.Point(321, 25)
        Me.txtHouseName.Name = "txtHouseName"
        Me.txtHouseName.Size = New System.Drawing.Size(178, 20)
        Me.txtHouseName.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(173, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Max Furniture, 0 for no max:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(173, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Price:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Entrance Y:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Entrance X:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Base Map:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(173, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "House Name:"
        '
        'lstHouses
        '
        Me.lstHouses.FormattingEnabled = True
        Me.lstHouses.Location = New System.Drawing.Point(6, 19)
        Me.lstHouses.Name = "lstHouses"
        Me.lstHouses.Size = New System.Drawing.Size(161, 173)
        Me.lstHouses.TabIndex = 0
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.ToolStripMenuItem1.Text = "Show Server"
        '
        'TimedShutdownToolStripMenuItem
        '
        Me.TimedShutdownToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomMessageToolStripMenuItem})
        Me.TimedShutdownToolStripMenuItem.Name = "TimedShutdownToolStripMenuItem"
        Me.TimedShutdownToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.TimedShutdownToolStripMenuItem.Text = "Timed Shutdown"
        '
        'CustomMessageToolStripMenuItem
        '
        Me.CustomMessageToolStripMenuItem.Name = "CustomMessageToolStripMenuItem"
        Me.CustomMessageToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.CustomMessageToolStripMenuItem.Text = "Custom Message?"
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ShutdownToolStripMenuItem.Text = "Shutdown"
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
        Me.lstviewmenu.Size = New System.Drawing.Size(157, 114)
        '
        'KickToolStripMenuItem1
        '
        Me.KickToolStripMenuItem1.Name = "KickToolStripMenuItem1"
        Me.KickToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.KickToolStripMenuItem1.Text = "Kick"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.DisconnectToolStripMenuItem.Text = "Disconnect"
        '
        'BanToolStripMenuItem1
        '
        Me.BanToolStripMenuItem1.Name = "BanToolStripMenuItem1"
        Me.BanToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.BanToolStripMenuItem1.Text = "Ban"
        '
        'MakeAdminToolStripMenuItem1
        '
        Me.MakeAdminToolStripMenuItem1.Name = "MakeAdminToolStripMenuItem1"
        Me.MakeAdminToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.MakeAdminToolStripMenuItem1.Text = "Make Admin"
        '
        'RemoveAdminToolStripMenuItem1
        '
        Me.RemoveAdminToolStripMenuItem1.Name = "RemoveAdminToolStripMenuItem1"
        Me.RemoveAdminToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.RemoveAdminToolStripMenuItem1.Text = "Remove Admin"
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
        Me.ShowServerToolStripMenuItem.Text = "Show Server"
        '
        'TimedShutdownToolStripMenuItem1
        '
        Me.TimedShutdownToolStripMenuItem1.Name = "TimedShutdownToolStripMenuItem1"
        Me.TimedShutdownToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.TimedShutdownToolStripMenuItem1.Text = "Timed Shutdown"
        '
        'ShutdownToolStripMenuItem1
        '
        Me.ShutdownToolStripMenuItem1.Name = "ShutdownToolStripMenuItem1"
        Me.ShutdownToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.ShutdownToolStripMenuItem1.Text = "Shutdown"
        '
        'tmrUpdatePlayerList
        '
        Me.tmrUpdatePlayerList.Interval = 5000
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Location = New System.Drawing.Point(96, 131)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(83, 31)
        Me.btnSaveAll.TabIndex = 8
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
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
        Me.Text = "Server"
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lstHouses As ListBox
    Friend WithEvents btnSaveHouse As Button
    Friend WithEvents txtHouseFurniture As TextBox
    Friend WithEvents txtHousePrice As TextBox
    Friend WithEvents txtYEntrance As TextBox
    Friend WithEvents txtXEntrance As TextBox
    Friend WithEvents txtBaseMap As TextBox
    Friend WithEvents txtHouseName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNotifications As Label
    Friend WithEvents btnSaveAll As Button
End Class
