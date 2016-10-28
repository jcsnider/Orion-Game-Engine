<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor_MapEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditor_MapEditor))
        Me.picScreen = New System.Windows.Forms.PictureBox()
        Me.tabpages = New System.Windows.Forms.TabControl()
        Me.tpTiles = New System.Windows.Forms.TabPage()
        Me.cmbAutoTile = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbLayers = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTileSets = New System.Windows.Forms.ComboBox()
        Me.pnlBack = New System.Windows.Forms.Panel()
        Me.picBackSelect = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.scrlPictureX = New System.Windows.Forms.HScrollBar()
        Me.scrlPictureY = New System.Windows.Forms.VScrollBar()
        Me.tpAttributes = New System.Windows.Forms.TabPage()
        Me.optCraft = New System.Windows.Forms.RadioButton()
        Me.optHouse = New System.Windows.Forms.RadioButton()
        Me.btnClearAttribute = New System.Windows.Forms.Button()
        Me.optTrap = New System.Windows.Forms.RadioButton()
        Me.optBlocked = New System.Windows.Forms.RadioButton()
        Me.optHeal = New System.Windows.Forms.RadioButton()
        Me.optWarp = New System.Windows.Forms.RadioButton()
        Me.optBank = New System.Windows.Forms.RadioButton()
        Me.optItem = New System.Windows.Forms.RadioButton()
        Me.optShop = New System.Windows.Forms.RadioButton()
        Me.optNPCAvoid = New System.Windows.Forms.RadioButton()
        Me.optNPCSpawn = New System.Windows.Forms.RadioButton()
        Me.optKey = New System.Windows.Forms.RadioButton()
        Me.optDoor = New System.Windows.Forms.RadioButton()
        Me.optKeyOpen = New System.Windows.Forms.RadioButton()
        Me.optResource = New System.Windows.Forms.RadioButton()
        Me.tpNpcs = New System.Windows.Forms.TabPage()
        Me.fraNpcs = New System.Windows.Forms.GroupBox()
        Me.cmbNpcList = New System.Windows.Forms.ComboBox()
        Me.lstMapNpc = New System.Windows.Forms.ListBox()
        Me.ComboBox23 = New System.Windows.Forms.ComboBox()
        Me.tpDirBlock = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tpEvents = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.lstMusic = New System.Windows.Forms.ListBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMapGrid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFill = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.pnlAttributes = New System.Windows.Forms.Panel()
        Me.fraBuyHouse = New System.Windows.Forms.GroupBox()
        Me.btnHouseTileOk = New System.Windows.Forms.Button()
        Me.scrlBuyHouse = New System.Windows.Forms.HScrollBar()
        Me.lblHouseName = New System.Windows.Forms.Label()
        Me.fraKeyOpen = New System.Windows.Forms.GroupBox()
        Me.scrlKeyY = New System.Windows.Forms.HScrollBar()
        Me.lblKeyY = New System.Windows.Forms.Label()
        Me.btnMapKeyOpen = New System.Windows.Forms.Button()
        Me.scrlKeyX = New System.Windows.Forms.HScrollBar()
        Me.lblKeyX = New System.Windows.Forms.Label()
        Me.fraMapWarp = New System.Windows.Forms.GroupBox()
        Me.btnMapWarp = New System.Windows.Forms.Button()
        Me.scrlMapWarpY = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpX = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpMap = New System.Windows.Forms.HScrollBar()
        Me.lblMapWarpY = New System.Windows.Forms.Label()
        Me.lblMapWarpX = New System.Windows.Forms.Label()
        Me.lblMapWarpMap = New System.Windows.Forms.Label()
        Me.fraMapKey = New System.Windows.Forms.GroupBox()
        Me.chkMapKey = New System.Windows.Forms.CheckBox()
        Me.picMapKey = New System.Windows.Forms.PictureBox()
        Me.btnMapKey = New System.Windows.Forms.Button()
        Me.scrlMapKey = New System.Windows.Forms.HScrollBar()
        Me.lblMapKey = New System.Windows.Forms.Label()
        Me.fraNpcSpawn = New System.Windows.Forms.GroupBox()
        Me.lstNpc = New System.Windows.Forms.ComboBox()
        Me.btnNpcSpawn = New System.Windows.Forms.Button()
        Me.scrlNpcDir = New System.Windows.Forms.HScrollBar()
        Me.lblNpcDir = New System.Windows.Forms.Label()
        Me.fraHeal = New System.Windows.Forms.GroupBox()
        Me.scrlHeal = New System.Windows.Forms.HScrollBar()
        Me.lblHeal = New System.Windows.Forms.Label()
        Me.cmbHeal = New System.Windows.Forms.ComboBox()
        Me.btnHeal = New System.Windows.Forms.Button()
        Me.fraShop = New System.Windows.Forms.GroupBox()
        Me.cmbShop = New System.Windows.Forms.ComboBox()
        Me.btnShop = New System.Windows.Forms.Button()
        Me.fraResource = New System.Windows.Forms.GroupBox()
        Me.btnResourceOk = New System.Windows.Forms.Button()
        Me.scrlResource = New System.Windows.Forms.HScrollBar()
        Me.lblResource = New System.Windows.Forms.Label()
        Me.fraMapItem = New System.Windows.Forms.GroupBox()
        Me.picMapItem = New System.Windows.Forms.PictureBox()
        Me.btnMapItem = New System.Windows.Forms.Button()
        Me.scrlMapItemValue = New System.Windows.Forms.HScrollBar()
        Me.scrlMapItem = New System.Windows.Forms.HScrollBar()
        Me.lblMapItem = New System.Windows.Forms.Label()
        Me.fraTrap = New System.Windows.Forms.GroupBox()
        Me.btnTrap = New System.Windows.Forms.Button()
        Me.scrlTrap = New System.Windows.Forms.HScrollBar()
        Me.lblTrap = New System.Windows.Forms.Label()
        Me.pnlBack2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbMapList = New System.Windows.Forms.ComboBox()
        Me.btnLoadMap = New System.Windows.Forms.Button()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkUseTint = New System.Windows.Forms.CheckBox()
        Me.lblMapAlpha = New System.Windows.Forms.Label()
        Me.lblMapBlue = New System.Windows.Forms.Label()
        Me.lblMapGreen = New System.Windows.Forms.Label()
        Me.lblMapRed = New System.Windows.Forms.Label()
        Me.scrlMapAlpha = New System.Windows.Forms.HScrollBar()
        Me.scrlMapBlue = New System.Windows.Forms.HScrollBar()
        Me.scrlMapGreen = New System.Windows.Forms.HScrollBar()
        Me.scrlMapRed = New System.Windows.Forms.HScrollBar()
        Me.cmbMoral = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.scrlFogAlpha = New System.Windows.Forms.HScrollBar()
        Me.lblFogAlpha = New System.Windows.Forms.Label()
        Me.scrlFogSpeed = New System.Windows.Forms.HScrollBar()
        Me.lblFogSpeed = New System.Windows.Forms.Label()
        Me.scrlIntensity = New System.Windows.Forms.HScrollBar()
        Me.lblIntensity = New System.Windows.Forms.Label()
        Me.scrlFog = New System.Windows.Forms.HScrollBar()
        Me.lblFogIndex = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbWeather = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fraMaxSizes = New System.Windows.Forms.GroupBox()
        Me.txtMaxY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxX = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fraBootSettings = New System.Windows.Forms.GroupBox()
        Me.txtBootMap = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBootY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBootX = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.fraMapLinks = New System.Windows.Forms.GroupBox()
        Me.txtDown = New System.Windows.Forms.TextBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.txtUp = New System.Windows.Forms.TextBox()
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpages.SuspendLayout()
        Me.tpTiles.SuspendLayout()
        Me.pnlBack.SuspendLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAttributes.SuspendLayout()
        Me.tpNpcs.SuspendLayout()
        Me.fraNpcs.SuspendLayout()
        Me.tpDirBlock.SuspendLayout()
        Me.tpEvents.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.pnlAttributes.SuspendLayout()
        Me.fraBuyHouse.SuspendLayout()
        Me.fraKeyOpen.SuspendLayout()
        Me.fraMapWarp.SuspendLayout()
        Me.fraMapKey.SuspendLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraNpcSpawn.SuspendLayout()
        Me.fraHeal.SuspendLayout()
        Me.fraShop.SuspendLayout()
        Me.fraResource.SuspendLayout()
        Me.fraMapItem.SuspendLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraTrap.SuspendLayout()
        Me.pnlBack2.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraMaxSizes.SuspendLayout()
        Me.fraBootSettings.SuspendLayout()
        Me.fraMapLinks.SuspendLayout()
        Me.SuspendLayout()
        '
        'picScreen
        '
        Me.picScreen.BackColor = System.Drawing.Color.Black
        Me.picScreen.Location = New System.Drawing.Point(2, 2)
        Me.picScreen.Name = "picScreen"
        Me.picScreen.Size = New System.Drawing.Size(721, 545)
        Me.picScreen.TabIndex = 0
        Me.picScreen.TabStop = False
        '
        'tabpages
        '
        Me.tabpages.Controls.Add(Me.tpTiles)
        Me.tabpages.Controls.Add(Me.tpAttributes)
        Me.tabpages.Controls.Add(Me.tpNpcs)
        Me.tabpages.Controls.Add(Me.tpDirBlock)
        Me.tabpages.Controls.Add(Me.tpEvents)
        Me.tabpages.Location = New System.Drawing.Point(0, 61)
        Me.tabpages.Name = "tabpages"
        Me.tabpages.SelectedIndex = 0
        Me.tabpages.Size = New System.Drawing.Size(322, 521)
        Me.tabpages.TabIndex = 17
        '
        'tpTiles
        '
        Me.tpTiles.Controls.Add(Me.cmbAutoTile)
        Me.tpTiles.Controls.Add(Me.Label11)
        Me.tpTiles.Controls.Add(Me.Label10)
        Me.tpTiles.Controls.Add(Me.cmbLayers)
        Me.tpTiles.Controls.Add(Me.Label9)
        Me.tpTiles.Controls.Add(Me.cmbTileSets)
        Me.tpTiles.Controls.Add(Me.pnlBack)
        Me.tpTiles.Controls.Add(Me.Label1)
        Me.tpTiles.Controls.Add(Me.scrlPictureX)
        Me.tpTiles.Controls.Add(Me.scrlPictureY)
        Me.tpTiles.Location = New System.Drawing.Point(4, 22)
        Me.tpTiles.Name = "tpTiles"
        Me.tpTiles.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTiles.Size = New System.Drawing.Size(314, 495)
        Me.tpTiles.TabIndex = 0
        Me.tpTiles.Text = "Tiles"
        Me.tpTiles.UseVisualStyleBackColor = True
        '
        'cmbAutoTile
        '
        Me.cmbAutoTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAutoTile.FormattingEnabled = True
        Me.cmbAutoTile.Items.AddRange(New Object() {"Normal", "AutoTile (VX)", "Fake (VX)", "Animated (VX)", "Cliff (VX)", "Waterfall (VX)"})
        Me.cmbAutoTile.Location = New System.Drawing.Point(59, 470)
        Me.cmbAutoTile.Name = "cmbAutoTile"
        Me.cmbAutoTile.Size = New System.Drawing.Size(119, 21)
        Me.cmbAutoTile.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 473)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "AutoTile:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(142, 446)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Layer:"
        '
        'cmbLayers
        '
        Me.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayers.FormattingEnabled = True
        Me.cmbLayers.Items.AddRange(New Object() {"Ground", "Mask", "Mask 2", "Fringe", "Fringe 2"})
        Me.cmbLayers.Location = New System.Drawing.Point(184, 443)
        Me.cmbLayers.Name = "cmbLayers"
        Me.cmbLayers.Size = New System.Drawing.Size(121, 21)
        Me.cmbLayers.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 446)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Tileset:"
        '
        'cmbTileSets
        '
        Me.cmbTileSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTileSets.FormattingEnabled = True
        Me.cmbTileSets.Location = New System.Drawing.Point(53, 443)
        Me.cmbTileSets.Name = "cmbTileSets"
        Me.cmbTileSets.Size = New System.Drawing.Size(83, 21)
        Me.cmbTileSets.TabIndex = 12
        '
        'pnlBack
        '
        Me.pnlBack.BackColor = System.Drawing.Color.Black
        Me.pnlBack.Controls.Add(Me.picBackSelect)
        Me.pnlBack.Location = New System.Drawing.Point(6, 8)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(267, 397)
        Me.pnlBack.TabIndex = 9
        '
        'picBackSelect
        '
        Me.picBackSelect.BackColor = System.Drawing.Color.Black
        Me.picBackSelect.Location = New System.Drawing.Point(0, 0)
        Me.picBackSelect.Name = "picBackSelect"
        Me.picBackSelect.Size = New System.Drawing.Size(267, 397)
        Me.picBackSelect.TabIndex = 1
        Me.picBackSelect.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 423)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Drag Mouse to Select Multiple Tiles"
        '
        'scrlPictureX
        '
        Me.scrlPictureX.LargeChange = 1
        Me.scrlPictureX.Location = New System.Drawing.Point(3, 408)
        Me.scrlPictureX.Name = "scrlPictureX"
        Me.scrlPictureX.Size = New System.Drawing.Size(289, 16)
        Me.scrlPictureX.TabIndex = 1
        '
        'scrlPictureY
        '
        Me.scrlPictureY.LargeChange = 1
        Me.scrlPictureY.Location = New System.Drawing.Point(276, 8)
        Me.scrlPictureY.Name = "scrlPictureY"
        Me.scrlPictureY.Size = New System.Drawing.Size(16, 398)
        Me.scrlPictureY.TabIndex = 2
        '
        'tpAttributes
        '
        Me.tpAttributes.Controls.Add(Me.optCraft)
        Me.tpAttributes.Controls.Add(Me.optHouse)
        Me.tpAttributes.Controls.Add(Me.btnClearAttribute)
        Me.tpAttributes.Controls.Add(Me.optTrap)
        Me.tpAttributes.Controls.Add(Me.optBlocked)
        Me.tpAttributes.Controls.Add(Me.optHeal)
        Me.tpAttributes.Controls.Add(Me.optWarp)
        Me.tpAttributes.Controls.Add(Me.optBank)
        Me.tpAttributes.Controls.Add(Me.optItem)
        Me.tpAttributes.Controls.Add(Me.optShop)
        Me.tpAttributes.Controls.Add(Me.optNPCAvoid)
        Me.tpAttributes.Controls.Add(Me.optNPCSpawn)
        Me.tpAttributes.Controls.Add(Me.optKey)
        Me.tpAttributes.Controls.Add(Me.optDoor)
        Me.tpAttributes.Controls.Add(Me.optKeyOpen)
        Me.tpAttributes.Controls.Add(Me.optResource)
        Me.tpAttributes.Location = New System.Drawing.Point(4, 22)
        Me.tpAttributes.Name = "tpAttributes"
        Me.tpAttributes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAttributes.Size = New System.Drawing.Size(314, 495)
        Me.tpAttributes.TabIndex = 3
        Me.tpAttributes.Text = "Attributes"
        Me.tpAttributes.UseVisualStyleBackColor = True
        '
        'optCraft
        '
        Me.optCraft.AutoSize = True
        Me.optCraft.Location = New System.Drawing.Point(173, 85)
        Me.optCraft.Name = "optCraft"
        Me.optCraft.Size = New System.Drawing.Size(47, 17)
        Me.optCraft.TabIndex = 17
        Me.optCraft.TabStop = True
        Me.optCraft.Text = "Craft"
        Me.optCraft.UseVisualStyleBackColor = True
        '
        'optHouse
        '
        Me.optHouse.AutoSize = True
        Me.optHouse.Location = New System.Drawing.Point(173, 117)
        Me.optHouse.Name = "optHouse"
        Me.optHouse.Size = New System.Drawing.Size(77, 17)
        Me.optHouse.TabIndex = 15
        Me.optHouse.TabStop = True
        Me.optHouse.Text = "Buy House"
        Me.optHouse.UseVisualStyleBackColor = True
        '
        'btnClearAttribute
        '
        Me.btnClearAttribute.Location = New System.Drawing.Point(10, 462)
        Me.btnClearAttribute.Name = "btnClearAttribute"
        Me.btnClearAttribute.Size = New System.Drawing.Size(165, 25)
        Me.btnClearAttribute.TabIndex = 14
        Me.btnClearAttribute.Text = "Clear All Attributes"
        Me.btnClearAttribute.UseVisualStyleBackColor = True
        '
        'optTrap
        '
        Me.optTrap.AutoSize = True
        Me.optTrap.Location = New System.Drawing.Point(101, 85)
        Me.optTrap.Name = "optTrap"
        Me.optTrap.Size = New System.Drawing.Size(47, 17)
        Me.optTrap.TabIndex = 12
        Me.optTrap.TabStop = True
        Me.optTrap.Text = "Trap"
        Me.optTrap.UseVisualStyleBackColor = True
        '
        'optBlocked
        '
        Me.optBlocked.AutoSize = True
        Me.optBlocked.Location = New System.Drawing.Point(10, 14)
        Me.optBlocked.Name = "optBlocked"
        Me.optBlocked.Size = New System.Drawing.Size(64, 17)
        Me.optBlocked.TabIndex = 0
        Me.optBlocked.TabStop = True
        Me.optBlocked.Text = "Blocked"
        Me.optBlocked.UseVisualStyleBackColor = True
        '
        'optHeal
        '
        Me.optHeal.AutoSize = True
        Me.optHeal.Location = New System.Drawing.Point(10, 85)
        Me.optHeal.Name = "optHeal"
        Me.optHeal.Size = New System.Drawing.Size(47, 17)
        Me.optHeal.TabIndex = 11
        Me.optHeal.TabStop = True
        Me.optHeal.Text = "Heal"
        Me.optHeal.UseVisualStyleBackColor = True
        '
        'optWarp
        '
        Me.optWarp.AutoSize = True
        Me.optWarp.Location = New System.Drawing.Point(101, 14)
        Me.optWarp.Name = "optWarp"
        Me.optWarp.Size = New System.Drawing.Size(51, 17)
        Me.optWarp.TabIndex = 1
        Me.optWarp.TabStop = True
        Me.optWarp.Text = "Warp"
        Me.optWarp.UseVisualStyleBackColor = True
        '
        'optBank
        '
        Me.optBank.AutoSize = True
        Me.optBank.Location = New System.Drawing.Point(237, 85)
        Me.optBank.Name = "optBank"
        Me.optBank.Size = New System.Drawing.Size(50, 17)
        Me.optBank.TabIndex = 10
        Me.optBank.TabStop = True
        Me.optBank.Text = "Bank"
        Me.optBank.UseVisualStyleBackColor = True
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.Location = New System.Drawing.Point(173, 14)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(45, 17)
        Me.optItem.TabIndex = 2
        Me.optItem.TabStop = True
        Me.optItem.Text = "Item"
        Me.optItem.UseVisualStyleBackColor = True
        '
        'optShop
        '
        Me.optShop.AutoSize = True
        Me.optShop.Location = New System.Drawing.Point(101, 117)
        Me.optShop.Name = "optShop"
        Me.optShop.Size = New System.Drawing.Size(50, 17)
        Me.optShop.TabIndex = 9
        Me.optShop.TabStop = True
        Me.optShop.Text = "Shop"
        Me.optShop.UseVisualStyleBackColor = True
        '
        'optNPCAvoid
        '
        Me.optNPCAvoid.AutoSize = True
        Me.optNPCAvoid.Location = New System.Drawing.Point(237, 14)
        Me.optNPCAvoid.Name = "optNPCAvoid"
        Me.optNPCAvoid.Size = New System.Drawing.Size(77, 17)
        Me.optNPCAvoid.TabIndex = 3
        Me.optNPCAvoid.TabStop = True
        Me.optNPCAvoid.Text = "NPC Avoid"
        Me.optNPCAvoid.UseVisualStyleBackColor = True
        '
        'optNPCSpawn
        '
        Me.optNPCSpawn.AutoSize = True
        Me.optNPCSpawn.Location = New System.Drawing.Point(10, 117)
        Me.optNPCSpawn.Name = "optNPCSpawn"
        Me.optNPCSpawn.Size = New System.Drawing.Size(83, 17)
        Me.optNPCSpawn.TabIndex = 8
        Me.optNPCSpawn.TabStop = True
        Me.optNPCSpawn.Text = "NPC Spawn"
        Me.optNPCSpawn.UseVisualStyleBackColor = True
        '
        'optKey
        '
        Me.optKey.AutoSize = True
        Me.optKey.Location = New System.Drawing.Point(173, 50)
        Me.optKey.Name = "optKey"
        Me.optKey.Size = New System.Drawing.Size(43, 17)
        Me.optKey.TabIndex = 4
        Me.optKey.TabStop = True
        Me.optKey.Text = "Key"
        Me.optKey.UseVisualStyleBackColor = True
        '
        'optDoor
        '
        Me.optDoor.AutoSize = True
        Me.optDoor.Location = New System.Drawing.Point(101, 50)
        Me.optDoor.Name = "optDoor"
        Me.optDoor.Size = New System.Drawing.Size(48, 17)
        Me.optDoor.TabIndex = 7
        Me.optDoor.TabStop = True
        Me.optDoor.Text = "Door"
        Me.optDoor.UseVisualStyleBackColor = True
        '
        'optKeyOpen
        '
        Me.optKeyOpen.AutoSize = True
        Me.optKeyOpen.Location = New System.Drawing.Point(237, 50)
        Me.optKeyOpen.Name = "optKeyOpen"
        Me.optKeyOpen.Size = New System.Drawing.Size(72, 17)
        Me.optKeyOpen.TabIndex = 5
        Me.optKeyOpen.TabStop = True
        Me.optKeyOpen.Text = "Key Open"
        Me.optKeyOpen.UseVisualStyleBackColor = True
        '
        'optResource
        '
        Me.optResource.AutoSize = True
        Me.optResource.Location = New System.Drawing.Point(10, 50)
        Me.optResource.Name = "optResource"
        Me.optResource.Size = New System.Drawing.Size(71, 17)
        Me.optResource.TabIndex = 6
        Me.optResource.TabStop = True
        Me.optResource.Text = "Resource"
        Me.optResource.UseVisualStyleBackColor = True
        '
        'tpNpcs
        '
        Me.tpNpcs.Controls.Add(Me.fraNpcs)
        Me.tpNpcs.Location = New System.Drawing.Point(4, 22)
        Me.tpNpcs.Name = "tpNpcs"
        Me.tpNpcs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNpcs.Size = New System.Drawing.Size(314, 495)
        Me.tpNpcs.TabIndex = 1
        Me.tpNpcs.Text = "Npc's"
        Me.tpNpcs.UseVisualStyleBackColor = True
        '
        'fraNpcs
        '
        Me.fraNpcs.Controls.Add(Me.cmbNpcList)
        Me.fraNpcs.Controls.Add(Me.lstMapNpc)
        Me.fraNpcs.Controls.Add(Me.ComboBox23)
        Me.fraNpcs.Location = New System.Drawing.Point(6, 8)
        Me.fraNpcs.Name = "fraNpcs"
        Me.fraNpcs.Size = New System.Drawing.Size(305, 426)
        Me.fraNpcs.TabIndex = 11
        Me.fraNpcs.TabStop = False
        Me.fraNpcs.Text = "NPCs"
        '
        'cmbNpcList
        '
        Me.cmbNpcList.FormattingEnabled = True
        Me.cmbNpcList.Location = New System.Drawing.Point(178, 19)
        Me.cmbNpcList.Name = "cmbNpcList"
        Me.cmbNpcList.Size = New System.Drawing.Size(124, 21)
        Me.cmbNpcList.TabIndex = 70
        '
        'lstMapNpc
        '
        Me.lstMapNpc.FormattingEnabled = True
        Me.lstMapNpc.Location = New System.Drawing.Point(6, 19)
        Me.lstMapNpc.Name = "lstMapNpc"
        Me.lstMapNpc.Size = New System.Drawing.Size(166, 394)
        Me.lstMapNpc.TabIndex = 69
        '
        'ComboBox23
        '
        Me.ComboBox23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox23.FormattingEnabled = True
        Me.ComboBox23.Location = New System.Drawing.Point(341, 469)
        Me.ComboBox23.Name = "ComboBox23"
        Me.ComboBox23.Size = New System.Drawing.Size(133, 21)
        Me.ComboBox23.TabIndex = 68
        '
        'tpDirBlock
        '
        Me.tpDirBlock.Controls.Add(Me.Label12)
        Me.tpDirBlock.Location = New System.Drawing.Point(4, 22)
        Me.tpDirBlock.Name = "tpDirBlock"
        Me.tpDirBlock.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDirBlock.Size = New System.Drawing.Size(314, 495)
        Me.tpDirBlock.TabIndex = 4
        Me.tpDirBlock.Text = "Directional Block"
        Me.tpDirBlock.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(239, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Just press the arrows to block that side of the tile."
        '
        'tpEvents
        '
        Me.tpEvents.Controls.Add(Me.Label13)
        Me.tpEvents.Location = New System.Drawing.Point(4, 22)
        Me.tpEvents.Name = "tpEvents"
        Me.tpEvents.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEvents.Size = New System.Drawing.Size(314, 495)
        Me.tpEvents.TabIndex = 5
        Me.tpEvents.Text = "Events"
        Me.tpEvents.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(239, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Click on the map where you want to add a event."
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(132, 24)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(56, 23)
        Me.btnSaveSettings.TabIndex = 16
        Me.btnSaveSettings.Text = "Set Size"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPreview)
        Me.GroupBox2.Controls.Add(Me.lstMusic)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 617)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(197, 208)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Music"
        '
        'btnPreview
        '
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(25, 172)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(151, 29)
        Me.btnPreview.TabIndex = 4
        Me.btnPreview.Text = "Preview Music"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'lstMusic
        '
        Me.lstMusic.FormattingEnabled = True
        Me.lstMusic.Location = New System.Drawing.Point(6, 19)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.ScrollAlwaysVisible = True
        Me.lstMusic.Size = New System.Drawing.Size(188, 147)
        Me.lstMusic.TabIndex = 3
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbDiscard, Me.ToolStripSeparator1, Me.tsbMapGrid, Me.ToolStripSeparator2, Me.tsbFill, Me.tsbClear})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1285, 25)
        Me.ToolStrip.TabIndex = 16
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(51, 22)
        Me.tsbSave.Text = "Save"
        '
        'tsbDiscard
        '
        Me.tsbDiscard.Image = CType(resources.GetObject("tsbDiscard.Image"), System.Drawing.Image)
        Me.tsbDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDiscard.Name = "tsbDiscard"
        Me.tsbDiscard.Size = New System.Drawing.Size(66, 22)
        Me.tsbDiscard.Text = "Discard"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbMapGrid
        '
        Me.tsbMapGrid.Image = CType(resources.GetObject("tsbMapGrid.Image"), System.Drawing.Image)
        Me.tsbMapGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMapGrid.Name = "tsbMapGrid"
        Me.tsbMapGrid.Size = New System.Drawing.Size(76, 22)
        Me.tsbMapGrid.Text = "Map Grid"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFill
        '
        Me.tsbFill.Image = CType(resources.GetObject("tsbFill.Image"), System.Drawing.Image)
        Me.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFill.Name = "tsbFill"
        Me.tsbFill.Size = New System.Drawing.Size(73, 22)
        Me.tsbFill.Text = "Fill Layer"
        Me.tsbFill.ToolTipText = "Fill Layer"
        '
        'tsbClear
        '
        Me.tsbClear.Image = CType(resources.GetObject("tsbClear.Image"), System.Drawing.Image)
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(85, 22)
        Me.tsbClear.Text = "Clear Layer"
        '
        'pnlAttributes
        '
        Me.pnlAttributes.Controls.Add(Me.fraBuyHouse)
        Me.pnlAttributes.Controls.Add(Me.fraKeyOpen)
        Me.pnlAttributes.Controls.Add(Me.fraMapWarp)
        Me.pnlAttributes.Controls.Add(Me.fraMapKey)
        Me.pnlAttributes.Controls.Add(Me.fraNpcSpawn)
        Me.pnlAttributes.Controls.Add(Me.fraHeal)
        Me.pnlAttributes.Controls.Add(Me.fraShop)
        Me.pnlAttributes.Controls.Add(Me.fraResource)
        Me.pnlAttributes.Controls.Add(Me.fraMapItem)
        Me.pnlAttributes.Controls.Add(Me.fraTrap)
        Me.pnlAttributes.Location = New System.Drawing.Point(453, 58)
        Me.pnlAttributes.Name = "pnlAttributes"
        Me.pnlAttributes.Size = New System.Drawing.Size(482, 491)
        Me.pnlAttributes.TabIndex = 15
        Me.pnlAttributes.Visible = False
        '
        'fraBuyHouse
        '
        Me.fraBuyHouse.Controls.Add(Me.btnHouseTileOk)
        Me.fraBuyHouse.Controls.Add(Me.scrlBuyHouse)
        Me.fraBuyHouse.Controls.Add(Me.lblHouseName)
        Me.fraBuyHouse.Location = New System.Drawing.Point(13, 195)
        Me.fraBuyHouse.Name = "fraBuyHouse"
        Me.fraBuyHouse.Size = New System.Drawing.Size(252, 138)
        Me.fraBuyHouse.TabIndex = 17
        Me.fraBuyHouse.TabStop = False
        Me.fraBuyHouse.Text = "Buy House"
        '
        'btnHouseTileOk
        '
        Me.btnHouseTileOk.Location = New System.Drawing.Point(79, 97)
        Me.btnHouseTileOk.Name = "btnHouseTileOk"
        Me.btnHouseTileOk.Size = New System.Drawing.Size(90, 28)
        Me.btnHouseTileOk.TabIndex = 6
        Me.btnHouseTileOk.Text = "Accept"
        Me.btnHouseTileOk.UseVisualStyleBackColor = True
        '
        'scrlBuyHouse
        '
        Me.scrlBuyHouse.LargeChange = 1
        Me.scrlBuyHouse.Location = New System.Drawing.Point(26, 49)
        Me.scrlBuyHouse.Name = "scrlBuyHouse"
        Me.scrlBuyHouse.Size = New System.Drawing.Size(193, 18)
        Me.scrlBuyHouse.TabIndex = 3
        '
        'lblHouseName
        '
        Me.lblHouseName.AutoSize = True
        Me.lblHouseName.Location = New System.Drawing.Point(23, 29)
        Me.lblHouseName.Name = "lblHouseName"
        Me.lblHouseName.Size = New System.Drawing.Size(41, 13)
        Me.lblHouseName.TabIndex = 0
        Me.lblHouseName.Text = "House:"
        '
        'fraKeyOpen
        '
        Me.fraKeyOpen.Controls.Add(Me.scrlKeyY)
        Me.fraKeyOpen.Controls.Add(Me.lblKeyY)
        Me.fraKeyOpen.Controls.Add(Me.btnMapKeyOpen)
        Me.fraKeyOpen.Controls.Add(Me.scrlKeyX)
        Me.fraKeyOpen.Controls.Add(Me.lblKeyX)
        Me.fraKeyOpen.Location = New System.Drawing.Point(212, 328)
        Me.fraKeyOpen.Name = "fraKeyOpen"
        Me.fraKeyOpen.Size = New System.Drawing.Size(252, 138)
        Me.fraKeyOpen.TabIndex = 9
        Me.fraKeyOpen.TabStop = False
        Me.fraKeyOpen.Text = "Map Key Open"
        '
        'scrlKeyY
        '
        Me.scrlKeyY.Location = New System.Drawing.Point(9, 76)
        Me.scrlKeyY.Name = "scrlKeyY"
        Me.scrlKeyY.Size = New System.Drawing.Size(160, 18)
        Me.scrlKeyY.TabIndex = 8
        '
        'lblKeyY
        '
        Me.lblKeyY.AutoSize = True
        Me.lblKeyY.Location = New System.Drawing.Point(6, 61)
        Me.lblKeyY.Name = "lblKeyY"
        Me.lblKeyY.Size = New System.Drawing.Size(26, 13)
        Me.lblKeyY.TabIndex = 7
        Me.lblKeyY.Text = "Y: 0"
        '
        'btnMapKeyOpen
        '
        Me.btnMapKeyOpen.Location = New System.Drawing.Point(79, 97)
        Me.btnMapKeyOpen.Name = "btnMapKeyOpen"
        Me.btnMapKeyOpen.Size = New System.Drawing.Size(90, 28)
        Me.btnMapKeyOpen.TabIndex = 6
        Me.btnMapKeyOpen.Text = "Accept"
        Me.btnMapKeyOpen.UseVisualStyleBackColor = True
        '
        'scrlKeyX
        '
        Me.scrlKeyX.Location = New System.Drawing.Point(9, 37)
        Me.scrlKeyX.Name = "scrlKeyX"
        Me.scrlKeyX.Size = New System.Drawing.Size(160, 18)
        Me.scrlKeyX.TabIndex = 3
        '
        'lblKeyX
        '
        Me.lblKeyX.AutoSize = True
        Me.lblKeyX.Location = New System.Drawing.Point(6, 22)
        Me.lblKeyX.Name = "lblKeyX"
        Me.lblKeyX.Size = New System.Drawing.Size(26, 13)
        Me.lblKeyX.TabIndex = 0
        Me.lblKeyX.Text = "X: 0"
        '
        'fraMapWarp
        '
        Me.fraMapWarp.Controls.Add(Me.btnMapWarp)
        Me.fraMapWarp.Controls.Add(Me.scrlMapWarpY)
        Me.fraMapWarp.Controls.Add(Me.scrlMapWarpX)
        Me.fraMapWarp.Controls.Add(Me.scrlMapWarpMap)
        Me.fraMapWarp.Controls.Add(Me.lblMapWarpY)
        Me.fraMapWarp.Controls.Add(Me.lblMapWarpX)
        Me.fraMapWarp.Controls.Add(Me.lblMapWarpMap)
        Me.fraMapWarp.Location = New System.Drawing.Point(131, 125)
        Me.fraMapWarp.Name = "fraMapWarp"
        Me.fraMapWarp.Size = New System.Drawing.Size(252, 172)
        Me.fraMapWarp.TabIndex = 0
        Me.fraMapWarp.TabStop = False
        Me.fraMapWarp.Text = "Map Warp"
        '
        'btnMapWarp
        '
        Me.btnMapWarp.Location = New System.Drawing.Point(85, 138)
        Me.btnMapWarp.Name = "btnMapWarp"
        Me.btnMapWarp.Size = New System.Drawing.Size(90, 28)
        Me.btnMapWarp.TabIndex = 6
        Me.btnMapWarp.Text = "Accept"
        Me.btnMapWarp.UseVisualStyleBackColor = True
        '
        'scrlMapWarpY
        '
        Me.scrlMapWarpY.Location = New System.Drawing.Point(36, 107)
        Me.scrlMapWarpY.Name = "scrlMapWarpY"
        Me.scrlMapWarpY.Size = New System.Drawing.Size(202, 18)
        Me.scrlMapWarpY.TabIndex = 5
        '
        'scrlMapWarpX
        '
        Me.scrlMapWarpX.Location = New System.Drawing.Point(36, 70)
        Me.scrlMapWarpX.Name = "scrlMapWarpX"
        Me.scrlMapWarpX.Size = New System.Drawing.Size(202, 18)
        Me.scrlMapWarpX.TabIndex = 4
        '
        'scrlMapWarpMap
        '
        Me.scrlMapWarpMap.Location = New System.Drawing.Point(36, 38)
        Me.scrlMapWarpMap.Name = "scrlMapWarpMap"
        Me.scrlMapWarpMap.Size = New System.Drawing.Size(202, 18)
        Me.scrlMapWarpMap.TabIndex = 3
        '
        'lblMapWarpY
        '
        Me.lblMapWarpY.AutoSize = True
        Me.lblMapWarpY.Location = New System.Drawing.Point(7, 90)
        Me.lblMapWarpY.Name = "lblMapWarpY"
        Me.lblMapWarpY.Size = New System.Drawing.Size(26, 13)
        Me.lblMapWarpY.TabIndex = 2
        Me.lblMapWarpY.Text = "Y: 1"
        '
        'lblMapWarpX
        '
        Me.lblMapWarpX.AutoSize = True
        Me.lblMapWarpX.Location = New System.Drawing.Point(7, 56)
        Me.lblMapWarpX.Name = "lblMapWarpX"
        Me.lblMapWarpX.Size = New System.Drawing.Size(26, 13)
        Me.lblMapWarpX.TabIndex = 1
        Me.lblMapWarpX.Text = "X: 1"
        '
        'lblMapWarpMap
        '
        Me.lblMapWarpMap.AutoSize = True
        Me.lblMapWarpMap.Location = New System.Drawing.Point(6, 25)
        Me.lblMapWarpMap.Name = "lblMapWarpMap"
        Me.lblMapWarpMap.Size = New System.Drawing.Size(40, 13)
        Me.lblMapWarpMap.TabIndex = 0
        Me.lblMapWarpMap.Text = "Map: 1"
        '
        'fraMapKey
        '
        Me.fraMapKey.Controls.Add(Me.chkMapKey)
        Me.fraMapKey.Controls.Add(Me.picMapKey)
        Me.fraMapKey.Controls.Add(Me.btnMapKey)
        Me.fraMapKey.Controls.Add(Me.scrlMapKey)
        Me.fraMapKey.Controls.Add(Me.lblMapKey)
        Me.fraMapKey.Location = New System.Drawing.Point(208, 307)
        Me.fraMapKey.Name = "fraMapKey"
        Me.fraMapKey.Size = New System.Drawing.Size(252, 138)
        Me.fraMapKey.TabIndex = 8
        Me.fraMapKey.TabStop = False
        Me.fraMapKey.Text = "Map Key"
        '
        'chkMapKey
        '
        Me.chkMapKey.AutoSize = True
        Me.chkMapKey.Checked = True
        Me.chkMapKey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMapKey.Location = New System.Drawing.Point(9, 64)
        Me.chkMapKey.Name = "chkMapKey"
        Me.chkMapKey.Size = New System.Drawing.Size(152, 17)
        Me.chkMapKey.TabIndex = 8
        Me.chkMapKey.Text = "Take Key Away Upon Use"
        Me.chkMapKey.UseVisualStyleBackColor = True
        '
        'picMapKey
        '
        Me.picMapKey.BackColor = System.Drawing.Color.Black
        Me.picMapKey.Location = New System.Drawing.Point(197, 43)
        Me.picMapKey.Name = "picMapKey"
        Me.picMapKey.Size = New System.Drawing.Size(32, 32)
        Me.picMapKey.TabIndex = 7
        Me.picMapKey.TabStop = False
        '
        'btnMapKey
        '
        Me.btnMapKey.Location = New System.Drawing.Point(79, 97)
        Me.btnMapKey.Name = "btnMapKey"
        Me.btnMapKey.Size = New System.Drawing.Size(90, 28)
        Me.btnMapKey.TabIndex = 6
        Me.btnMapKey.Text = "Accept"
        Me.btnMapKey.UseVisualStyleBackColor = True
        '
        'scrlMapKey
        '
        Me.scrlMapKey.Location = New System.Drawing.Point(9, 37)
        Me.scrlMapKey.Name = "scrlMapKey"
        Me.scrlMapKey.Size = New System.Drawing.Size(160, 18)
        Me.scrlMapKey.TabIndex = 3
        '
        'lblMapKey
        '
        Me.lblMapKey.AutoSize = True
        Me.lblMapKey.Location = New System.Drawing.Point(6, 22)
        Me.lblMapKey.Name = "lblMapKey"
        Me.lblMapKey.Size = New System.Drawing.Size(59, 13)
        Me.lblMapKey.TabIndex = 0
        Me.lblMapKey.Text = "Item: None"
        '
        'fraNpcSpawn
        '
        Me.fraNpcSpawn.Controls.Add(Me.lstNpc)
        Me.fraNpcSpawn.Controls.Add(Me.btnNpcSpawn)
        Me.fraNpcSpawn.Controls.Add(Me.scrlNpcDir)
        Me.fraNpcSpawn.Controls.Add(Me.lblNpcDir)
        Me.fraNpcSpawn.Location = New System.Drawing.Point(3, 6)
        Me.fraNpcSpawn.Name = "fraNpcSpawn"
        Me.fraNpcSpawn.Size = New System.Drawing.Size(252, 158)
        Me.fraNpcSpawn.TabIndex = 11
        Me.fraNpcSpawn.TabStop = False
        Me.fraNpcSpawn.Text = "Npc Spawn"
        '
        'lstNpc
        '
        Me.lstNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstNpc.FormattingEnabled = True
        Me.lstNpc.Location = New System.Drawing.Point(30, 39)
        Me.lstNpc.Name = "lstNpc"
        Me.lstNpc.Size = New System.Drawing.Size(192, 21)
        Me.lstNpc.TabIndex = 37
        '
        'btnNpcSpawn
        '
        Me.btnNpcSpawn.Location = New System.Drawing.Point(87, 118)
        Me.btnNpcSpawn.Name = "btnNpcSpawn"
        Me.btnNpcSpawn.Size = New System.Drawing.Size(90, 28)
        Me.btnNpcSpawn.TabIndex = 6
        Me.btnNpcSpawn.Text = "Accept"
        Me.btnNpcSpawn.UseVisualStyleBackColor = True
        '
        'scrlNpcDir
        '
        Me.scrlNpcDir.LargeChange = 1
        Me.scrlNpcDir.Location = New System.Drawing.Point(29, 93)
        Me.scrlNpcDir.Maximum = 3
        Me.scrlNpcDir.Name = "scrlNpcDir"
        Me.scrlNpcDir.Size = New System.Drawing.Size(193, 18)
        Me.scrlNpcDir.TabIndex = 3
        '
        'lblNpcDir
        '
        Me.lblNpcDir.AutoSize = True
        Me.lblNpcDir.Location = New System.Drawing.Point(26, 78)
        Me.lblNpcDir.Name = "lblNpcDir"
        Me.lblNpcDir.Size = New System.Drawing.Size(69, 13)
        Me.lblNpcDir.TabIndex = 0
        Me.lblNpcDir.Text = "Direction: Up"
        '
        'fraHeal
        '
        Me.fraHeal.Controls.Add(Me.scrlHeal)
        Me.fraHeal.Controls.Add(Me.lblHeal)
        Me.fraHeal.Controls.Add(Me.cmbHeal)
        Me.fraHeal.Controls.Add(Me.btnHeal)
        Me.fraHeal.Location = New System.Drawing.Point(3, 336)
        Me.fraHeal.Name = "fraHeal"
        Me.fraHeal.Size = New System.Drawing.Size(252, 130)
        Me.fraHeal.TabIndex = 15
        Me.fraHeal.TabStop = False
        Me.fraHeal.Text = "Heal"
        '
        'scrlHeal
        '
        Me.scrlHeal.Location = New System.Drawing.Point(28, 74)
        Me.scrlHeal.Name = "scrlHeal"
        Me.scrlHeal.Size = New System.Drawing.Size(191, 17)
        Me.scrlHeal.TabIndex = 39
        '
        'lblHeal
        '
        Me.lblHeal.AutoSize = True
        Me.lblHeal.Location = New System.Drawing.Point(23, 57)
        Me.lblHeal.Name = "lblHeal"
        Me.lblHeal.Size = New System.Drawing.Size(55, 13)
        Me.lblHeal.TabIndex = 38
        Me.lblHeal.Text = "Amount: 0"
        '
        'cmbHeal
        '
        Me.cmbHeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHeal.FormattingEnabled = True
        Me.cmbHeal.Location = New System.Drawing.Point(28, 23)
        Me.cmbHeal.Name = "cmbHeal"
        Me.cmbHeal.Size = New System.Drawing.Size(192, 21)
        Me.cmbHeal.TabIndex = 37
        '
        'btnHeal
        '
        Me.btnHeal.Location = New System.Drawing.Point(75, 94)
        Me.btnHeal.Name = "btnHeal"
        Me.btnHeal.Size = New System.Drawing.Size(90, 28)
        Me.btnHeal.TabIndex = 6
        Me.btnHeal.Text = "Accept"
        Me.btnHeal.UseVisualStyleBackColor = True
        '
        'fraShop
        '
        Me.fraShop.Controls.Add(Me.cmbShop)
        Me.fraShop.Controls.Add(Me.btnShop)
        Me.fraShop.Location = New System.Drawing.Point(219, 268)
        Me.fraShop.Name = "fraShop"
        Me.fraShop.Size = New System.Drawing.Size(252, 113)
        Me.fraShop.TabIndex = 12
        Me.fraShop.TabStop = False
        Me.fraShop.Text = "Shop"
        '
        'cmbShop
        '
        Me.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShop.FormattingEnabled = True
        Me.cmbShop.Location = New System.Drawing.Point(30, 39)
        Me.cmbShop.Name = "cmbShop"
        Me.cmbShop.Size = New System.Drawing.Size(192, 21)
        Me.cmbShop.TabIndex = 37
        '
        'btnShop
        '
        Me.btnShop.Location = New System.Drawing.Point(87, 74)
        Me.btnShop.Name = "btnShop"
        Me.btnShop.Size = New System.Drawing.Size(90, 28)
        Me.btnShop.TabIndex = 6
        Me.btnShop.Text = "Accept"
        Me.btnShop.UseVisualStyleBackColor = True
        '
        'fraResource
        '
        Me.fraResource.Controls.Add(Me.btnResourceOk)
        Me.fraResource.Controls.Add(Me.scrlResource)
        Me.fraResource.Controls.Add(Me.lblResource)
        Me.fraResource.Location = New System.Drawing.Point(219, 14)
        Me.fraResource.Name = "fraResource"
        Me.fraResource.Size = New System.Drawing.Size(252, 138)
        Me.fraResource.TabIndex = 10
        Me.fraResource.TabStop = False
        Me.fraResource.Text = "Resource"
        '
        'btnResourceOk
        '
        Me.btnResourceOk.Location = New System.Drawing.Point(79, 97)
        Me.btnResourceOk.Name = "btnResourceOk"
        Me.btnResourceOk.Size = New System.Drawing.Size(90, 28)
        Me.btnResourceOk.TabIndex = 6
        Me.btnResourceOk.Text = "Accept"
        Me.btnResourceOk.UseVisualStyleBackColor = True
        '
        'scrlResource
        '
        Me.scrlResource.Location = New System.Drawing.Point(26, 49)
        Me.scrlResource.Name = "scrlResource"
        Me.scrlResource.Size = New System.Drawing.Size(193, 18)
        Me.scrlResource.TabIndex = 3
        '
        'lblResource
        '
        Me.lblResource.AutoSize = True
        Me.lblResource.Location = New System.Drawing.Point(23, 29)
        Me.lblResource.Name = "lblResource"
        Me.lblResource.Size = New System.Drawing.Size(41, 13)
        Me.lblResource.TabIndex = 0
        Me.lblResource.Text = "Object:"
        '
        'fraMapItem
        '
        Me.fraMapItem.Controls.Add(Me.picMapItem)
        Me.fraMapItem.Controls.Add(Me.btnMapItem)
        Me.fraMapItem.Controls.Add(Me.scrlMapItemValue)
        Me.fraMapItem.Controls.Add(Me.scrlMapItem)
        Me.fraMapItem.Controls.Add(Me.lblMapItem)
        Me.fraMapItem.Location = New System.Drawing.Point(33, 177)
        Me.fraMapItem.Name = "fraMapItem"
        Me.fraMapItem.Size = New System.Drawing.Size(252, 138)
        Me.fraMapItem.TabIndex = 7
        Me.fraMapItem.TabStop = False
        Me.fraMapItem.Text = "Map Item"
        '
        'picMapItem
        '
        Me.picMapItem.BackColor = System.Drawing.Color.Black
        Me.picMapItem.Location = New System.Drawing.Point(197, 43)
        Me.picMapItem.Name = "picMapItem"
        Me.picMapItem.Size = New System.Drawing.Size(32, 32)
        Me.picMapItem.TabIndex = 7
        Me.picMapItem.TabStop = False
        '
        'btnMapItem
        '
        Me.btnMapItem.Location = New System.Drawing.Point(79, 97)
        Me.btnMapItem.Name = "btnMapItem"
        Me.btnMapItem.Size = New System.Drawing.Size(90, 28)
        Me.btnMapItem.TabIndex = 6
        Me.btnMapItem.Text = "Accept"
        Me.btnMapItem.UseVisualStyleBackColor = True
        '
        'scrlMapItemValue
        '
        Me.scrlMapItemValue.Location = New System.Drawing.Point(9, 59)
        Me.scrlMapItemValue.Name = "scrlMapItemValue"
        Me.scrlMapItemValue.Size = New System.Drawing.Size(160, 18)
        Me.scrlMapItemValue.TabIndex = 4
        '
        'scrlMapItem
        '
        Me.scrlMapItem.Location = New System.Drawing.Point(9, 37)
        Me.scrlMapItem.Name = "scrlMapItem"
        Me.scrlMapItem.Size = New System.Drawing.Size(160, 18)
        Me.scrlMapItem.TabIndex = 3
        '
        'lblMapItem
        '
        Me.lblMapItem.AutoSize = True
        Me.lblMapItem.Location = New System.Drawing.Point(6, 22)
        Me.lblMapItem.Name = "lblMapItem"
        Me.lblMapItem.Size = New System.Drawing.Size(73, 13)
        Me.lblMapItem.TabIndex = 0
        Me.lblMapItem.Text = "Item: None x0"
        '
        'fraTrap
        '
        Me.fraTrap.Controls.Add(Me.btnTrap)
        Me.fraTrap.Controls.Add(Me.scrlTrap)
        Me.fraTrap.Controls.Add(Me.lblTrap)
        Me.fraTrap.Location = New System.Drawing.Point(131, 137)
        Me.fraTrap.Name = "fraTrap"
        Me.fraTrap.Size = New System.Drawing.Size(252, 113)
        Me.fraTrap.TabIndex = 16
        Me.fraTrap.TabStop = False
        Me.fraTrap.Text = "Trap"
        '
        'btnTrap
        '
        Me.btnTrap.Location = New System.Drawing.Point(80, 67)
        Me.btnTrap.Name = "btnTrap"
        Me.btnTrap.Size = New System.Drawing.Size(90, 28)
        Me.btnTrap.TabIndex = 42
        Me.btnTrap.Text = "Accept"
        Me.btnTrap.UseVisualStyleBackColor = True
        '
        'scrlTrap
        '
        Me.scrlTrap.Location = New System.Drawing.Point(32, 38)
        Me.scrlTrap.Name = "scrlTrap"
        Me.scrlTrap.Size = New System.Drawing.Size(191, 17)
        Me.scrlTrap.TabIndex = 41
        '
        'lblTrap
        '
        Me.lblTrap.AutoSize = True
        Me.lblTrap.Location = New System.Drawing.Point(27, 21)
        Me.lblTrap.Name = "lblTrap"
        Me.lblTrap.Size = New System.Drawing.Size(55, 13)
        Me.lblTrap.TabIndex = 40
        Me.lblTrap.Text = "Amount: 0"
        '
        'pnlBack2
        '
        Me.pnlBack2.AutoScroll = True
        Me.pnlBack2.BackColor = System.Drawing.Color.Black
        Me.pnlBack2.Controls.Add(Me.picScreen)
        Me.pnlBack2.Location = New System.Drawing.Point(324, 31)
        Me.pnlBack2.Name = "pnlBack2"
        Me.pnlBack2.Size = New System.Drawing.Size(727, 550)
        Me.pnlBack2.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Map:"
        '
        'cmbMapList
        '
        Me.cmbMapList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMapList.FormattingEnabled = True
        Me.cmbMapList.Location = New System.Drawing.Point(38, 32)
        Me.cmbMapList.Name = "cmbMapList"
        Me.cmbMapList.Size = New System.Drawing.Size(203, 21)
        Me.cmbMapList.TabIndex = 20
        '
        'btnLoadMap
        '
        Me.btnLoadMap.Location = New System.Drawing.Point(247, 31)
        Me.btnLoadMap.Name = "btnLoadMap"
        Me.btnLoadMap.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadMap.TabIndex = 21
        Me.btnLoadMap.Text = "Load"
        Me.btnLoadMap.UseVisualStyleBackColor = True
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoScroll = True
        Me.pnlSettings.Controls.Add(Me.grpSettings)
        Me.pnlSettings.Location = New System.Drawing.Point(1053, 5)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(230, 576)
        Me.pnlSettings.TabIndex = 23
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.GroupBox3)
        Me.grpSettings.Controls.Add(Me.GroupBox2)
        Me.grpSettings.Controls.Add(Me.cmbMoral)
        Me.grpSettings.Controls.Add(Me.GroupBox1)
        Me.grpSettings.Controls.Add(Me.Label8)
        Me.grpSettings.Controls.Add(Me.Label6)
        Me.grpSettings.Controls.Add(Me.fraMaxSizes)
        Me.grpSettings.Controls.Add(Me.fraBootSettings)
        Me.grpSettings.Controls.Add(Me.txtName)
        Me.grpSettings.Controls.Add(Me.fraMapLinks)
        Me.grpSettings.Location = New System.Drawing.Point(3, 3)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(206, 835)
        Me.grpSettings.TabIndex = 23
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Map Settings"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkUseTint)
        Me.GroupBox3.Controls.Add(Me.lblMapAlpha)
        Me.GroupBox3.Controls.Add(Me.lblMapBlue)
        Me.GroupBox3.Controls.Add(Me.lblMapGreen)
        Me.GroupBox3.Controls.Add(Me.lblMapRed)
        Me.GroupBox3.Controls.Add(Me.scrlMapAlpha)
        Me.GroupBox3.Controls.Add(Me.scrlMapBlue)
        Me.GroupBox3.Controls.Add(Me.scrlMapGreen)
        Me.GroupBox3.Controls.Add(Me.scrlMapRed)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 495)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(197, 116)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Map Tint"
        '
        'chkUseTint
        '
        Me.chkUseTint.AutoSize = True
        Me.chkUseTint.Location = New System.Drawing.Point(5, 17)
        Me.chkUseTint.Name = "chkUseTint"
        Me.chkUseTint.Size = New System.Drawing.Size(93, 17)
        Me.chkUseTint.TabIndex = 18
        Me.chkUseTint.Text = "Use MapTint?"
        Me.chkUseTint.UseVisualStyleBackColor = True
        '
        'lblMapAlpha
        '
        Me.lblMapAlpha.AutoSize = True
        Me.lblMapAlpha.Location = New System.Drawing.Point(4, 94)
        Me.lblMapAlpha.Name = "lblMapAlpha"
        Me.lblMapAlpha.Size = New System.Drawing.Size(46, 13)
        Me.lblMapAlpha.TabIndex = 17
        Me.lblMapAlpha.Text = "Alpha: 0"
        '
        'lblMapBlue
        '
        Me.lblMapBlue.AutoSize = True
        Me.lblMapBlue.Location = New System.Drawing.Point(4, 75)
        Me.lblMapBlue.Name = "lblMapBlue"
        Me.lblMapBlue.Size = New System.Drawing.Size(40, 13)
        Me.lblMapBlue.TabIndex = 16
        Me.lblMapBlue.Text = "Blue: 0"
        '
        'lblMapGreen
        '
        Me.lblMapGreen.AutoSize = True
        Me.lblMapGreen.Location = New System.Drawing.Point(4, 56)
        Me.lblMapGreen.Name = "lblMapGreen"
        Me.lblMapGreen.Size = New System.Drawing.Size(48, 13)
        Me.lblMapGreen.TabIndex = 15
        Me.lblMapGreen.Text = "Green: 0"
        '
        'lblMapRed
        '
        Me.lblMapRed.AutoSize = True
        Me.lblMapRed.Location = New System.Drawing.Point(2, 37)
        Me.lblMapRed.Name = "lblMapRed"
        Me.lblMapRed.Size = New System.Drawing.Size(39, 13)
        Me.lblMapRed.TabIndex = 14
        Me.lblMapRed.Text = "Red: 0"
        '
        'scrlMapAlpha
        '
        Me.scrlMapAlpha.LargeChange = 1
        Me.scrlMapAlpha.Location = New System.Drawing.Point(100, 90)
        Me.scrlMapAlpha.Maximum = 255
        Me.scrlMapAlpha.Name = "scrlMapAlpha"
        Me.scrlMapAlpha.Size = New System.Drawing.Size(94, 17)
        Me.scrlMapAlpha.TabIndex = 13
        '
        'scrlMapBlue
        '
        Me.scrlMapBlue.LargeChange = 1
        Me.scrlMapBlue.Location = New System.Drawing.Point(100, 71)
        Me.scrlMapBlue.Maximum = 255
        Me.scrlMapBlue.Name = "scrlMapBlue"
        Me.scrlMapBlue.Size = New System.Drawing.Size(94, 17)
        Me.scrlMapBlue.TabIndex = 12
        '
        'scrlMapGreen
        '
        Me.scrlMapGreen.LargeChange = 1
        Me.scrlMapGreen.Location = New System.Drawing.Point(100, 52)
        Me.scrlMapGreen.Maximum = 255
        Me.scrlMapGreen.Name = "scrlMapGreen"
        Me.scrlMapGreen.Size = New System.Drawing.Size(94, 17)
        Me.scrlMapGreen.TabIndex = 11
        '
        'scrlMapRed
        '
        Me.scrlMapRed.LargeChange = 1
        Me.scrlMapRed.Location = New System.Drawing.Point(100, 33)
        Me.scrlMapRed.Maximum = 255
        Me.scrlMapRed.Name = "scrlMapRed"
        Me.scrlMapRed.Size = New System.Drawing.Size(94, 17)
        Me.scrlMapRed.TabIndex = 10
        '
        'cmbMoral
        '
        Me.cmbMoral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoral.FormattingEnabled = True
        Me.cmbMoral.Items.AddRange(New Object() {"None", "Safe Zone"})
        Me.cmbMoral.Location = New System.Drawing.Point(41, 39)
        Me.cmbMoral.Name = "cmbMoral"
        Me.cmbMoral.Size = New System.Drawing.Size(157, 21)
        Me.cmbMoral.TabIndex = 37
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.scrlFogAlpha)
        Me.GroupBox1.Controls.Add(Me.lblFogAlpha)
        Me.GroupBox1.Controls.Add(Me.scrlFogSpeed)
        Me.GroupBox1.Controls.Add(Me.lblFogSpeed)
        Me.GroupBox1.Controls.Add(Me.scrlIntensity)
        Me.GroupBox1.Controls.Add(Me.lblIntensity)
        Me.GroupBox1.Controls.Add(Me.scrlFog)
        Me.GroupBox1.Controls.Add(Me.lblFogIndex)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmbWeather)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 335)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 154)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Map Weather"
        '
        'scrlFogAlpha
        '
        Me.scrlFogAlpha.LargeChange = 1
        Me.scrlFogAlpha.Location = New System.Drawing.Point(90, 124)
        Me.scrlFogAlpha.Maximum = 255
        Me.scrlFogAlpha.Name = "scrlFogAlpha"
        Me.scrlFogAlpha.Size = New System.Drawing.Size(99, 17)
        Me.scrlFogAlpha.TabIndex = 9
        '
        'lblFogAlpha
        '
        Me.lblFogAlpha.AutoSize = True
        Me.lblFogAlpha.Location = New System.Drawing.Point(6, 126)
        Me.lblFogAlpha.Name = "lblFogAlpha"
        Me.lblFogAlpha.Size = New System.Drawing.Size(79, 13)
        Me.lblFogAlpha.TabIndex = 8
        Me.lblFogAlpha.Text = "Fog Alpha: 255"
        '
        'scrlFogSpeed
        '
        Me.scrlFogSpeed.LargeChange = 1
        Me.scrlFogSpeed.Location = New System.Drawing.Point(90, 101)
        Me.scrlFogSpeed.Name = "scrlFogSpeed"
        Me.scrlFogSpeed.Size = New System.Drawing.Size(99, 17)
        Me.scrlFogSpeed.TabIndex = 7
        '
        'lblFogSpeed
        '
        Me.lblFogSpeed.AutoSize = True
        Me.lblFogSpeed.Location = New System.Drawing.Point(6, 105)
        Me.lblFogSpeed.Name = "lblFogSpeed"
        Me.lblFogSpeed.Size = New System.Drawing.Size(80, 13)
        Me.lblFogSpeed.TabIndex = 6
        Me.lblFogSpeed.Text = "FogSpeed: 100"
        '
        'scrlIntensity
        '
        Me.scrlIntensity.LargeChange = 1
        Me.scrlIntensity.Location = New System.Drawing.Point(90, 51)
        Me.scrlIntensity.Name = "scrlIntensity"
        Me.scrlIntensity.Size = New System.Drawing.Size(99, 17)
        Me.scrlIntensity.TabIndex = 5
        '
        'lblIntensity
        '
        Me.lblIntensity.AutoSize = True
        Me.lblIntensity.Location = New System.Drawing.Point(6, 53)
        Me.lblIntensity.Name = "lblIntensity"
        Me.lblIntensity.Size = New System.Drawing.Size(70, 13)
        Me.lblIntensity.TabIndex = 4
        Me.lblIntensity.Text = "Intensity: 100"
        '
        'scrlFog
        '
        Me.scrlFog.LargeChange = 1
        Me.scrlFog.Location = New System.Drawing.Point(90, 81)
        Me.scrlFog.Name = "scrlFog"
        Me.scrlFog.Size = New System.Drawing.Size(99, 17)
        Me.scrlFog.TabIndex = 3
        '
        'lblFogIndex
        '
        Me.lblFogIndex.AutoSize = True
        Me.lblFogIndex.Location = New System.Drawing.Point(6, 82)
        Me.lblFogIndex.Name = "lblFogIndex"
        Me.lblFogIndex.Size = New System.Drawing.Size(37, 13)
        Me.lblFogIndex.TabIndex = 2
        Me.lblFogIndex.Text = "Fog: 1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Weather Type:"
        '
        'cmbWeather
        '
        Me.cmbWeather.FormattingEnabled = True
        Me.cmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm", "Fog"})
        Me.cmbWeather.Location = New System.Drawing.Point(90, 22)
        Me.cmbWeather.Name = "cmbWeather"
        Me.cmbWeather.Size = New System.Drawing.Size(99, 21)
        Me.cmbWeather.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Moral:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Name:"
        '
        'fraMaxSizes
        '
        Me.fraMaxSizes.Controls.Add(Me.txtMaxY)
        Me.fraMaxSizes.Controls.Add(Me.btnSaveSettings)
        Me.fraMaxSizes.Controls.Add(Me.Label2)
        Me.fraMaxSizes.Controls.Add(Me.txtMaxX)
        Me.fraMaxSizes.Controls.Add(Me.Label7)
        Me.fraMaxSizes.Location = New System.Drawing.Point(3, 258)
        Me.fraMaxSizes.Name = "fraMaxSizes"
        Me.fraMaxSizes.Size = New System.Drawing.Size(195, 71)
        Me.fraMaxSizes.TabIndex = 12
        Me.fraMaxSizes.TabStop = False
        Me.fraMaxSizes.Text = "Map Sizes"
        '
        'txtMaxY
        '
        Me.txtMaxY.Location = New System.Drawing.Point(76, 42)
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.Size = New System.Drawing.Size(50, 20)
        Me.txtMaxY.TabIndex = 3
        Me.txtMaxY.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Maximum Y:"
        '
        'txtMaxX
        '
        Me.txtMaxX.Location = New System.Drawing.Point(76, 16)
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.Size = New System.Drawing.Size(50, 20)
        Me.txtMaxX.TabIndex = 1
        Me.txtMaxX.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Maximum X:"
        '
        'fraBootSettings
        '
        Me.fraBootSettings.Controls.Add(Me.txtBootMap)
        Me.fraBootSettings.Controls.Add(Me.Label5)
        Me.fraBootSettings.Controls.Add(Me.txtBootY)
        Me.fraBootSettings.Controls.Add(Me.Label3)
        Me.fraBootSettings.Controls.Add(Me.txtBootX)
        Me.fraBootSettings.Controls.Add(Me.Label4)
        Me.fraBootSettings.Location = New System.Drawing.Point(3, 170)
        Me.fraBootSettings.Name = "fraBootSettings"
        Me.fraBootSettings.Size = New System.Drawing.Size(197, 82)
        Me.fraBootSettings.TabIndex = 13
        Me.fraBootSettings.TabStop = False
        Me.fraBootSettings.Text = "Respawn Settings"
        '
        'txtBootMap
        '
        Me.txtBootMap.Location = New System.Drawing.Point(141, 12)
        Me.txtBootMap.Name = "txtBootMap"
        Me.txtBootMap.Size = New System.Drawing.Size(50, 20)
        Me.txtBootMap.TabIndex = 5
        Me.txtBootMap.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Respawn Map:"
        '
        'txtBootY
        '
        Me.txtBootY.Location = New System.Drawing.Point(141, 56)
        Me.txtBootY.Name = "txtBootY"
        Me.txtBootY.Size = New System.Drawing.Size(50, 20)
        Me.txtBootY.TabIndex = 3
        Me.txtBootY.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Respawn Y:"
        '
        'txtBootX
        '
        Me.txtBootX.Location = New System.Drawing.Point(141, 33)
        Me.txtBootX.Name = "txtBootX"
        Me.txtBootX.Size = New System.Drawing.Size(50, 20)
        Me.txtBootX.TabIndex = 1
        Me.txtBootX.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Respawn X:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(41, 13)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(159, 20)
        Me.txtName.TabIndex = 10
        '
        'fraMapLinks
        '
        Me.fraMapLinks.Controls.Add(Me.txtDown)
        Me.fraMapLinks.Controls.Add(Me.txtLeft)
        Me.fraMapLinks.Controls.Add(Me.lblMap)
        Me.fraMapLinks.Controls.Add(Me.txtRight)
        Me.fraMapLinks.Controls.Add(Me.txtUp)
        Me.fraMapLinks.Location = New System.Drawing.Point(3, 69)
        Me.fraMapLinks.Name = "fraMapLinks"
        Me.fraMapLinks.Size = New System.Drawing.Size(197, 94)
        Me.fraMapLinks.TabIndex = 14
        Me.fraMapLinks.TabStop = False
        Me.fraMapLinks.Text = "Map Links"
        '
        'txtDown
        '
        Me.txtDown.Location = New System.Drawing.Point(82, 65)
        Me.txtDown.Name = "txtDown"
        Me.txtDown.Size = New System.Drawing.Size(39, 20)
        Me.txtDown.TabIndex = 6
        Me.txtDown.Text = "0"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(8, 36)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(39, 20)
        Me.txtLeft.TabIndex = 5
        Me.txtLeft.Text = "0"
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(61, 39)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(65, 13)
        Me.lblMap.TabIndex = 4
        Me.lblMap.Text = "Curr. Map: 0"
        '
        'txtRight
        '
        Me.txtRight.Location = New System.Drawing.Point(152, 36)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(39, 20)
        Me.txtRight.TabIndex = 3
        Me.txtRight.Text = "0"
        '
        'txtUp
        '
        Me.txtUp.Location = New System.Drawing.Point(82, 14)
        Me.txtUp.Name = "txtUp"
        Me.txtUp.Size = New System.Drawing.Size(39, 20)
        Me.txtUp.TabIndex = 1
        Me.txtUp.Text = "0"
        '
        'frmEditor_MapEditor
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1285, 583)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlBack2)
        Me.Controls.Add(Me.pnlSettings)
        Me.Controls.Add(Me.btnLoadMap)
        Me.Controls.Add(Me.cmbMapList)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.tabpages)
        Me.Controls.Add(Me.pnlAttributes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_MapEditor"
        Me.Text = "Map Editor"
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpages.ResumeLayout(False)
        Me.tpTiles.ResumeLayout(False)
        Me.tpTiles.PerformLayout()
        Me.pnlBack.ResumeLayout(False)
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAttributes.ResumeLayout(False)
        Me.tpAttributes.PerformLayout()
        Me.tpNpcs.ResumeLayout(False)
        Me.fraNpcs.ResumeLayout(False)
        Me.tpDirBlock.ResumeLayout(False)
        Me.tpDirBlock.PerformLayout()
        Me.tpEvents.ResumeLayout(False)
        Me.tpEvents.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.pnlAttributes.ResumeLayout(False)
        Me.fraBuyHouse.ResumeLayout(False)
        Me.fraBuyHouse.PerformLayout()
        Me.fraKeyOpen.ResumeLayout(False)
        Me.fraKeyOpen.PerformLayout()
        Me.fraMapWarp.ResumeLayout(False)
        Me.fraMapWarp.PerformLayout()
        Me.fraMapKey.ResumeLayout(False)
        Me.fraMapKey.PerformLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraNpcSpawn.ResumeLayout(False)
        Me.fraNpcSpawn.PerformLayout()
        Me.fraHeal.ResumeLayout(False)
        Me.fraHeal.PerformLayout()
        Me.fraShop.ResumeLayout(False)
        Me.fraResource.ResumeLayout(False)
        Me.fraResource.PerformLayout()
        Me.fraMapItem.ResumeLayout(False)
        Me.fraMapItem.PerformLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraTrap.ResumeLayout(False)
        Me.fraTrap.PerformLayout()
        Me.pnlBack2.ResumeLayout(False)
        Me.pnlSettings.ResumeLayout(False)
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraMaxSizes.ResumeLayout(False)
        Me.fraMaxSizes.PerformLayout()
        Me.fraBootSettings.ResumeLayout(False)
        Me.fraBootSettings.PerformLayout()
        Me.fraMapLinks.ResumeLayout(False)
        Me.fraMapLinks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picScreen As PictureBox
    Friend WithEvents tabpages As TabControl
    Friend WithEvents tpTiles As TabPage
    Friend WithEvents cmbAutoTile As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbLayers As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbTileSets As ComboBox
    Friend WithEvents pnlBack As Panel
    Public WithEvents picBackSelect As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents scrlPictureX As HScrollBar
    Friend WithEvents scrlPictureY As VScrollBar
    Friend WithEvents tpAttributes As TabPage
    Friend WithEvents optCraft As RadioButton
    Friend WithEvents optHouse As RadioButton
    Friend WithEvents btnClearAttribute As Button
    Friend WithEvents optTrap As RadioButton
    Friend WithEvents optBlocked As RadioButton
    Friend WithEvents optHeal As RadioButton
    Friend WithEvents optWarp As RadioButton
    Friend WithEvents optBank As RadioButton
    Friend WithEvents optItem As RadioButton
    Friend WithEvents optShop As RadioButton
    Friend WithEvents optNPCAvoid As RadioButton
    Friend WithEvents optNPCSpawn As RadioButton
    Friend WithEvents optKey As RadioButton
    Friend WithEvents optDoor As RadioButton
    Friend WithEvents optKeyOpen As RadioButton
    Friend WithEvents optResource As RadioButton
    Friend WithEvents tpNpcs As TabPage
    Friend WithEvents fraNpcs As GroupBox
    Friend WithEvents cmbNpcList As ComboBox
    Friend WithEvents lstMapNpc As ListBox
    Friend WithEvents ComboBox23 As ComboBox
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnPreview As Button
    Friend WithEvents lstMusic As ListBox
    Friend WithEvents tpDirBlock As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents tpEvents As TabPage
    Friend WithEvents Label13 As Label
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents tsbSave As ToolStripButton
    Friend WithEvents tsbDiscard As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbMapGrid As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbFill As ToolStripButton
    Friend WithEvents tsbClear As ToolStripButton
    Friend WithEvents pnlAttributes As Panel
    Friend WithEvents fraBuyHouse As GroupBox
    Friend WithEvents btnHouseTileOk As Button
    Friend WithEvents scrlBuyHouse As HScrollBar
    Friend WithEvents lblHouseName As Label
    Friend WithEvents fraKeyOpen As GroupBox
    Friend WithEvents scrlKeyY As HScrollBar
    Friend WithEvents lblKeyY As Label
    Friend WithEvents btnMapKeyOpen As Button
    Friend WithEvents scrlKeyX As HScrollBar
    Friend WithEvents lblKeyX As Label
    Friend WithEvents fraMapWarp As GroupBox
    Friend WithEvents btnMapWarp As Button
    Friend WithEvents scrlMapWarpY As HScrollBar
    Friend WithEvents scrlMapWarpX As HScrollBar
    Friend WithEvents scrlMapWarpMap As HScrollBar
    Friend WithEvents lblMapWarpY As Label
    Friend WithEvents lblMapWarpX As Label
    Friend WithEvents lblMapWarpMap As Label
    Friend WithEvents fraMapKey As GroupBox
    Friend WithEvents chkMapKey As CheckBox
    Friend WithEvents picMapKey As PictureBox
    Friend WithEvents btnMapKey As Button
    Friend WithEvents scrlMapKey As HScrollBar
    Friend WithEvents lblMapKey As Label
    Friend WithEvents fraNpcSpawn As GroupBox
    Friend WithEvents lstNpc As ComboBox
    Friend WithEvents btnNpcSpawn As Button
    Friend WithEvents scrlNpcDir As HScrollBar
    Friend WithEvents lblNpcDir As Label
    Friend WithEvents fraHeal As GroupBox
    Friend WithEvents scrlHeal As HScrollBar
    Friend WithEvents lblHeal As Label
    Friend WithEvents cmbHeal As ComboBox
    Friend WithEvents btnHeal As Button
    Friend WithEvents fraShop As GroupBox
    Friend WithEvents cmbShop As ComboBox
    Friend WithEvents btnShop As Button
    Friend WithEvents fraResource As GroupBox
    Friend WithEvents btnResourceOk As Button
    Friend WithEvents scrlResource As HScrollBar
    Friend WithEvents lblResource As Label
    Friend WithEvents fraMapItem As GroupBox
    Friend WithEvents picMapItem As PictureBox
    Friend WithEvents btnMapItem As Button
    Friend WithEvents scrlMapItemValue As HScrollBar
    Friend WithEvents scrlMapItem As HScrollBar
    Friend WithEvents lblMapItem As Label
    Friend WithEvents fraTrap As GroupBox
    Friend WithEvents btnTrap As Button
    Friend WithEvents scrlTrap As HScrollBar
    Friend WithEvents lblTrap As Label
    Friend WithEvents pnlBack2 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbMapList As ComboBox
    Friend WithEvents btnLoadMap As Button
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents grpSettings As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkUseTint As CheckBox
    Friend WithEvents lblMapAlpha As Label
    Friend WithEvents lblMapBlue As Label
    Friend WithEvents lblMapGreen As Label
    Friend WithEvents lblMapRed As Label
    Friend WithEvents scrlMapAlpha As HScrollBar
    Friend WithEvents scrlMapBlue As HScrollBar
    Friend WithEvents scrlMapGreen As HScrollBar
    Friend WithEvents scrlMapRed As HScrollBar
    Friend WithEvents cmbMoral As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents scrlFogAlpha As HScrollBar
    Friend WithEvents lblFogAlpha As Label
    Friend WithEvents scrlFogSpeed As HScrollBar
    Friend WithEvents lblFogSpeed As Label
    Friend WithEvents scrlIntensity As HScrollBar
    Friend WithEvents lblIntensity As Label
    Friend WithEvents scrlFog As HScrollBar
    Friend WithEvents lblFogIndex As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbWeather As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents fraMaxSizes As GroupBox
    Friend WithEvents txtMaxY As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMaxX As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents fraBootSettings As GroupBox
    Friend WithEvents txtBootMap As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBootY As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBootX As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents fraMapLinks As GroupBox
    Friend WithEvents txtDown As TextBox
    Friend WithEvents txtLeft As TextBox
    Friend WithEvents lblMap As Label
    Friend WithEvents txtRight As TextBox
    Friend WithEvents txtUp As TextBox
End Class
