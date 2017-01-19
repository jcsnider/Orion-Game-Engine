<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditor_MapEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditor_MapEditor))
        Me.DarkDockPanel1 = New DarkUI.Docking.DarkDockPanel()
        Me.ToolStripContainer2 = New System.Windows.Forms.ToolStripContainer()
        Me.ssInfo = New DarkUI.Controls.DarkStatusStrip()
        Me.tslCurMap = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslCurXY = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsCurFps = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DarkSectionPanel1 = New DarkUI.Controls.DarkSectionPanel()
        Me.pnlTiles = New System.Windows.Forms.Panel()
        Me.cmbAutoTile = New System.Windows.Forms.ComboBox()
        Me.DarkLabel4 = New DarkUI.Controls.DarkLabel()
        Me.cmbLayers = New System.Windows.Forms.ComboBox()
        Me.pnlBack = New System.Windows.Forms.Panel()
        Me.picBackSelect = New System.Windows.Forms.PictureBox()
        Me.DarkLabel3 = New DarkUI.Controls.DarkLabel()
        Me.scrlPictureY = New DarkUI.Controls.DarkScrollBar()
        Me.cmbTileSets = New System.Windows.Forms.ComboBox()
        Me.scrlPictureX = New DarkUI.Controls.DarkScrollBar()
        Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.pnlAttribute = New System.Windows.Forms.Panel()
        Me.btnClearAttribute = New DarkUI.Controls.DarkButton()
        Me.optHouse = New DarkUI.Controls.DarkRadioButton()
        Me.optShop = New DarkUI.Controls.DarkRadioButton()
        Me.optNpcSpawn = New DarkUI.Controls.DarkRadioButton()
        Me.optBank = New DarkUI.Controls.DarkRadioButton()
        Me.optCraft = New DarkUI.Controls.DarkRadioButton()
        Me.optTrap = New DarkUI.Controls.DarkRadioButton()
        Me.optHeal = New DarkUI.Controls.DarkRadioButton()
        Me.optKeyOpen = New DarkUI.Controls.DarkRadioButton()
        Me.optKey = New DarkUI.Controls.DarkRadioButton()
        Me.optDoor = New DarkUI.Controls.DarkRadioButton()
        Me.optResource = New DarkUI.Controls.DarkRadioButton()
        Me.optNpcAvoid = New DarkUI.Controls.DarkRadioButton()
        Me.optItem = New DarkUI.Controls.DarkRadioButton()
        Me.optWarp = New DarkUI.Controls.DarkRadioButton()
        Me.optBlocked = New DarkUI.Controls.DarkRadioButton()
        Me.pnlNpc = New System.Windows.Forms.Panel()
        Me.cmbNpcList = New System.Windows.Forms.ComboBox()
        Me.lstMapNpc = New System.Windows.Forms.ListBox()
        Me.pnlDirBlock = New System.Windows.Forms.Panel()
        Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
        Me.pnlEvents = New System.Windows.Forms.Panel()
        Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
        Me.btnEvents = New DarkUI.Controls.DarkButton()
        Me.btnDirBlock = New DarkUI.Controls.DarkButton()
        Me.btnNpc = New DarkUI.Controls.DarkButton()
        Me.btnAttributes = New DarkUI.Controls.DarkButton()
        Me.btnTiles = New DarkUI.Controls.DarkButton()
        Me.DarkSectionPanel2 = New DarkUI.Controls.DarkSectionPanel()
        Me.pnlMoreOptions = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkUseTint = New System.Windows.Forms.CheckBox()
        Me.scrlMapAlpha = New DarkUI.Controls.DarkScrollBar()
        Me.lblMapAlpha = New DarkUI.Controls.DarkLabel()
        Me.scrlMapBlue = New DarkUI.Controls.DarkScrollBar()
        Me.lblMapBlue = New DarkUI.Controls.DarkLabel()
        Me.scrlMapGreen = New DarkUI.Controls.DarkScrollBar()
        Me.lblMapGreen = New DarkUI.Controls.DarkLabel()
        Me.scrlMapRed = New DarkUI.Controls.DarkScrollBar()
        Me.lblMapRed = New DarkUI.Controls.DarkLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.scrlFogAlpha = New DarkUI.Controls.DarkScrollBar()
        Me.lblFogAlpha = New DarkUI.Controls.DarkLabel()
        Me.scrlFogSpeed = New DarkUI.Controls.DarkScrollBar()
        Me.lblFogSpeed = New DarkUI.Controls.DarkLabel()
        Me.scrlFog = New DarkUI.Controls.DarkScrollBar()
        Me.lblFogIndex = New DarkUI.Controls.DarkLabel()
        Me.scrlIntensity = New DarkUI.Controls.DarkScrollBar()
        Me.lblIntensity = New DarkUI.Controls.DarkLabel()
        Me.cmbWeather = New System.Windows.Forms.ComboBox()
        Me.DarkLabel14 = New DarkUI.Controls.DarkLabel()
        Me.btnMoreOptions = New DarkUI.Controls.DarkButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnPreview = New DarkUI.Controls.DarkButton()
        Me.lstMusic = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSetSize = New DarkUI.Controls.DarkButton()
        Me.txtMaxY = New DarkUI.Controls.DarkTextBox()
        Me.txtMaxX = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel13 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel12 = New DarkUI.Controls.DarkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSpawnY = New DarkUI.Controls.DarkTextBox()
        Me.txtSpawnX = New DarkUI.Controls.DarkTextBox()
        Me.txtSpawnMap = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel11 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel10 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel9 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel7 = New DarkUI.Controls.DarkLabel()
        Me.chkInstance = New DarkUI.Controls.DarkCheckBox()
        Me.txtName = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel8 = New DarkUI.Controls.DarkLabel()
        Me.fraMapLinks = New System.Windows.Forms.GroupBox()
        Me.lblMap = New DarkUI.Controls.DarkLabel()
        Me.txtRight = New DarkUI.Controls.DarkTextBox()
        Me.txtLeft = New DarkUI.Controls.DarkTextBox()
        Me.txtDown = New DarkUI.Controls.DarkTextBox()
        Me.txtUp = New DarkUI.Controls.DarkTextBox()
        Me.cmbMoral = New System.Windows.Forms.ComboBox()
        Me.ToolStrip = New DarkUI.Controls.DarkToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMapGrid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFill = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbMapList = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbScreenShot = New System.Windows.Forms.ToolStripButton()
        Me.pnlBack2 = New DarkUI.Controls.DarkSectionPanel()
        Me.pnlAttributes = New System.Windows.Forms.Panel()
        Me.fraMapWarp = New System.Windows.Forms.GroupBox()
        Me.btnMapWarp = New System.Windows.Forms.Button()
        Me.scrlMapWarpY = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpX = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpMap = New System.Windows.Forms.HScrollBar()
        Me.lblMapWarpY = New System.Windows.Forms.Label()
        Me.lblMapWarpX = New System.Windows.Forms.Label()
        Me.lblMapWarpMap = New System.Windows.Forms.Label()
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
        Me.scrlMapViewV = New DarkUI.Controls.DarkScrollBar()
        Me.scrlMapViewH = New DarkUI.Controls.DarkScrollBar()
        Me.picScreen = New System.Windows.Forms.PictureBox()
        Me.ToolStripContainer2.ContentPanel.SuspendLayout()
        Me.ToolStripContainer2.SuspendLayout()
        Me.ssInfo.SuspendLayout()
        Me.DarkSectionPanel1.SuspendLayout()
        Me.pnlTiles.SuspendLayout()
        Me.pnlBack.SuspendLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAttribute.SuspendLayout()
        Me.pnlNpc.SuspendLayout()
        Me.pnlDirBlock.SuspendLayout()
        Me.pnlEvents.SuspendLayout()
        Me.DarkSectionPanel2.SuspendLayout()
        Me.pnlMoreOptions.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraMapLinks.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.pnlBack2.SuspendLayout()
        Me.pnlAttributes.SuspendLayout()
        Me.fraMapWarp.SuspendLayout()
        Me.fraBuyHouse.SuspendLayout()
        Me.fraKeyOpen.SuspendLayout()
        Me.fraMapKey.SuspendLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraNpcSpawn.SuspendLayout()
        Me.fraHeal.SuspendLayout()
        Me.fraShop.SuspendLayout()
        Me.fraResource.SuspendLayout()
        Me.fraMapItem.SuspendLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraTrap.SuspendLayout()
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DarkDockPanel1
        '
        Me.DarkDockPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.DarkDockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DarkDockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DarkDockPanel1.Name = "DarkDockPanel1"
        Me.DarkDockPanel1.Size = New System.Drawing.Size(1292, 626)
        Me.DarkDockPanel1.TabIndex = 0
        '
        'ToolStripContainer2
        '
        '
        'ToolStripContainer2.ContentPanel
        '
        Me.ToolStripContainer2.ContentPanel.Controls.Add(Me.ssInfo)
        Me.ToolStripContainer2.ContentPanel.Size = New System.Drawing.Size(1292, 28)
        Me.ToolStripContainer2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStripContainer2.LeftToolStripPanelVisible = False
        Me.ToolStripContainer2.Location = New System.Drawing.Point(0, 598)
        Me.ToolStripContainer2.Name = "ToolStripContainer2"
        Me.ToolStripContainer2.RightToolStripPanelVisible = False
        Me.ToolStripContainer2.Size = New System.Drawing.Size(1292, 28)
        Me.ToolStripContainer2.TabIndex = 6
        Me.ToolStripContainer2.Text = "ToolStripContainer2"
        Me.ToolStripContainer2.TopToolStripPanelVisible = False
        '
        'ssInfo
        '
        Me.ssInfo.AutoSize = False
        Me.ssInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ssInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ssInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ssInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslCurMap, Me.tslCurXY, Me.tsCurFps})
        Me.ssInfo.Location = New System.Drawing.Point(0, 0)
        Me.ssInfo.Name = "ssInfo"
        Me.ssInfo.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
        Me.ssInfo.Size = New System.Drawing.Size(1292, 28)
        Me.ssInfo.SizingGrip = False
        Me.ssInfo.TabIndex = 0
        Me.ssInfo.Text = "DarkStatusStrip1"
        '
        'tslCurMap
        '
        Me.tslCurMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tslCurMap.Name = "tslCurMap"
        Me.tslCurMap.Size = New System.Drawing.Size(86, 15)
        Me.tslCurMap.Text = "Current Map: 1"
        '
        'tslCurXY
        '
        Me.tslCurXY.Name = "tslCurXY"
        Me.tslCurXY.Size = New System.Drawing.Size(50, 15)
        Me.tslCurXY.Text = "X:1 - Y:1"
        '
        'tsCurFps
        '
        Me.tsCurFps.Name = "tsCurFps"
        Me.tsCurFps.Size = New System.Drawing.Size(81, 15)
        Me.tsCurFps.Text = "Current FPS: 0"
        '
        'DarkSectionPanel1
        '
        Me.DarkSectionPanel1.Controls.Add(Me.pnlTiles)
        Me.DarkSectionPanel1.Controls.Add(Me.pnlAttribute)
        Me.DarkSectionPanel1.Controls.Add(Me.pnlNpc)
        Me.DarkSectionPanel1.Controls.Add(Me.pnlDirBlock)
        Me.DarkSectionPanel1.Controls.Add(Me.pnlEvents)
        Me.DarkSectionPanel1.Controls.Add(Me.btnEvents)
        Me.DarkSectionPanel1.Controls.Add(Me.btnDirBlock)
        Me.DarkSectionPanel1.Controls.Add(Me.btnNpc)
        Me.DarkSectionPanel1.Controls.Add(Me.btnAttributes)
        Me.DarkSectionPanel1.Controls.Add(Me.btnTiles)
        Me.DarkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DarkSectionPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DarkSectionPanel1.Name = "DarkSectionPanel1"
        Me.DarkSectionPanel1.SectionHeader = "Map Layers"
        Me.DarkSectionPanel1.Size = New System.Drawing.Size(318, 598)
        Me.DarkSectionPanel1.TabIndex = 7
        '
        'pnlTiles
        '
        Me.pnlTiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlTiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlTiles.Controls.Add(Me.cmbAutoTile)
        Me.pnlTiles.Controls.Add(Me.DarkLabel4)
        Me.pnlTiles.Controls.Add(Me.cmbLayers)
        Me.pnlTiles.Controls.Add(Me.pnlBack)
        Me.pnlTiles.Controls.Add(Me.DarkLabel3)
        Me.pnlTiles.Controls.Add(Me.scrlPictureY)
        Me.pnlTiles.Controls.Add(Me.cmbTileSets)
        Me.pnlTiles.Controls.Add(Me.scrlPictureX)
        Me.pnlTiles.Controls.Add(Me.DarkLabel2)
        Me.pnlTiles.Controls.Add(Me.DarkLabel1)
        Me.pnlTiles.Location = New System.Drawing.Point(1, 51)
        Me.pnlTiles.Name = "pnlTiles"
        Me.pnlTiles.Size = New System.Drawing.Size(316, 546)
        Me.pnlTiles.TabIndex = 0
        '
        'cmbAutoTile
        '
        Me.cmbAutoTile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbAutoTile.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbAutoTile.ForeColor = System.Drawing.Color.LightGray
        Me.cmbAutoTile.FormattingEnabled = True
        Me.cmbAutoTile.Items.AddRange(New Object() {"Normal", "AutoTile (VX)", "Fake (VX)", "Animated (VX)", "Cliff (VX)", "Waterfall (VX)"})
        Me.cmbAutoTile.Location = New System.Drawing.Point(51, 513)
        Me.cmbAutoTile.Name = "cmbAutoTile"
        Me.cmbAutoTile.Size = New System.Drawing.Size(123, 21)
        Me.cmbAutoTile.TabIndex = 19
        '
        'DarkLabel4
        '
        Me.DarkLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.BackColor = System.Drawing.Color.Transparent
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(3, 516)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(49, 13)
        Me.DarkLabel4.TabIndex = 18
        Me.DarkLabel4.Text = "AutoTile:"
        '
        'cmbLayers
        '
        Me.cmbLayers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbLayers.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbLayers.ForeColor = System.Drawing.Color.LightGray
        Me.cmbLayers.FormattingEnabled = True
        Me.cmbLayers.Items.AddRange(New Object() {"Ground", "Mask", "Mask2", "Fringe", "Fringe2"})
        Me.cmbLayers.Location = New System.Drawing.Point(180, 486)
        Me.cmbLayers.Name = "cmbLayers"
        Me.cmbLayers.Size = New System.Drawing.Size(130, 21)
        Me.cmbLayers.TabIndex = 17
        '
        'pnlBack
        '
        Me.pnlBack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlBack.BackColor = System.Drawing.Color.Black
        Me.pnlBack.Controls.Add(Me.picBackSelect)
        Me.pnlBack.Location = New System.Drawing.Point(3, 3)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(286, 442)
        Me.pnlBack.TabIndex = 10
        '
        'picBackSelect
        '
        Me.picBackSelect.BackColor = System.Drawing.Color.Black
        Me.picBackSelect.Location = New System.Drawing.Point(0, 0)
        Me.picBackSelect.Name = "picBackSelect"
        Me.picBackSelect.Size = New System.Drawing.Size(283, 451)
        Me.picBackSelect.TabIndex = 1
        Me.picBackSelect.TabStop = False
        '
        'DarkLabel3
        '
        Me.DarkLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.BackColor = System.Drawing.Color.Transparent
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(138, 489)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(36, 13)
        Me.DarkLabel3.TabIndex = 16
        Me.DarkLabel3.Text = "Layer:"
        '
        'scrlPictureY
        '
        Me.scrlPictureY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.scrlPictureY.BackColor = System.Drawing.SystemColors.ControlDark
        Me.scrlPictureY.Location = New System.Drawing.Point(292, 3)
        Me.scrlPictureY.Name = "scrlPictureY"
        Me.scrlPictureY.Size = New System.Drawing.Size(18, 442)
        Me.scrlPictureY.TabIndex = 12
        '
        'cmbTileSets
        '
        Me.cmbTileSets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbTileSets.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbTileSets.ForeColor = System.Drawing.Color.LightGray
        Me.cmbTileSets.FormattingEnabled = True
        Me.cmbTileSets.Location = New System.Drawing.Point(51, 486)
        Me.cmbTileSets.Name = "cmbTileSets"
        Me.cmbTileSets.Size = New System.Drawing.Size(81, 21)
        Me.cmbTileSets.TabIndex = 15
        '
        'scrlPictureX
        '
        Me.scrlPictureX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.scrlPictureX.BackColor = System.Drawing.SystemColors.ControlDark
        Me.scrlPictureX.Location = New System.Drawing.Point(3, 451)
        Me.scrlPictureX.Name = "scrlPictureX"
        Me.scrlPictureX.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlPictureX.Size = New System.Drawing.Size(283, 16)
        Me.scrlPictureX.TabIndex = 11
        '
        'DarkLabel2
        '
        Me.DarkLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(3, 489)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(43, 13)
        Me.DarkLabel2.TabIndex = 14
        Me.DarkLabel2.Text = "TileSet:"
        '
        'DarkLabel1
        '
        Me.DarkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.DarkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(57, 470)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(174, 13)
        Me.DarkLabel1.TabIndex = 13
        Me.DarkLabel1.Text = "Drag Mouse to Select Multiple Tiles"
        '
        'pnlAttribute
        '
        Me.pnlAttribute.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlAttribute.Controls.Add(Me.btnClearAttribute)
        Me.pnlAttribute.Controls.Add(Me.optHouse)
        Me.pnlAttribute.Controls.Add(Me.optShop)
        Me.pnlAttribute.Controls.Add(Me.optNpcSpawn)
        Me.pnlAttribute.Controls.Add(Me.optBank)
        Me.pnlAttribute.Controls.Add(Me.optCraft)
        Me.pnlAttribute.Controls.Add(Me.optTrap)
        Me.pnlAttribute.Controls.Add(Me.optHeal)
        Me.pnlAttribute.Controls.Add(Me.optKeyOpen)
        Me.pnlAttribute.Controls.Add(Me.optKey)
        Me.pnlAttribute.Controls.Add(Me.optDoor)
        Me.pnlAttribute.Controls.Add(Me.optResource)
        Me.pnlAttribute.Controls.Add(Me.optNpcAvoid)
        Me.pnlAttribute.Controls.Add(Me.optItem)
        Me.pnlAttribute.Controls.Add(Me.optWarp)
        Me.pnlAttribute.Controls.Add(Me.optBlocked)
        Me.pnlAttribute.Location = New System.Drawing.Point(2, 50)
        Me.pnlAttribute.Name = "pnlAttribute"
        Me.pnlAttribute.Size = New System.Drawing.Size(314, 548)
        Me.pnlAttribute.TabIndex = 9
        '
        'btnClearAttribute
        '
        Me.btnClearAttribute.Location = New System.Drawing.Point(10, 470)
        Me.btnClearAttribute.Name = "btnClearAttribute"
        Me.btnClearAttribute.Padding = New System.Windows.Forms.Padding(5)
        Me.btnClearAttribute.Size = New System.Drawing.Size(297, 23)
        Me.btnClearAttribute.TabIndex = 15
        Me.btnClearAttribute.Text = "Clear Attributes"
        '
        'optHouse
        '
        Me.optHouse.AutoSize = True
        Me.optHouse.BackColor = System.Drawing.Color.Transparent
        Me.optHouse.Location = New System.Drawing.Point(163, 139)
        Me.optHouse.Name = "optHouse"
        Me.optHouse.Size = New System.Drawing.Size(56, 17)
        Me.optHouse.TabIndex = 14
        Me.optHouse.TabStop = True
        Me.optHouse.Text = "House"
        '
        'optShop
        '
        Me.optShop.AutoSize = True
        Me.optShop.BackColor = System.Drawing.Color.Transparent
        Me.optShop.Location = New System.Drawing.Point(97, 139)
        Me.optShop.Name = "optShop"
        Me.optShop.Size = New System.Drawing.Size(50, 17)
        Me.optShop.TabIndex = 13
        Me.optShop.TabStop = True
        Me.optShop.Text = "Shop"
        '
        'optNpcSpawn
        '
        Me.optNpcSpawn.AutoSize = True
        Me.optNpcSpawn.BackColor = System.Drawing.Color.Transparent
        Me.optNpcSpawn.Location = New System.Drawing.Point(10, 139)
        Me.optNpcSpawn.Name = "optNpcSpawn"
        Me.optNpcSpawn.Size = New System.Drawing.Size(81, 17)
        Me.optNpcSpawn.TabIndex = 12
        Me.optNpcSpawn.TabStop = True
        Me.optNpcSpawn.Text = "Npc Spawn"
        '
        'optBank
        '
        Me.optBank.AutoSize = True
        Me.optBank.BackColor = System.Drawing.Color.Transparent
        Me.optBank.Location = New System.Drawing.Point(235, 94)
        Me.optBank.Name = "optBank"
        Me.optBank.Size = New System.Drawing.Size(50, 17)
        Me.optBank.TabIndex = 11
        Me.optBank.TabStop = True
        Me.optBank.Text = "Bank"
        '
        'optCraft
        '
        Me.optCraft.AutoSize = True
        Me.optCraft.BackColor = System.Drawing.Color.Transparent
        Me.optCraft.Location = New System.Drawing.Point(163, 94)
        Me.optCraft.Name = "optCraft"
        Me.optCraft.Size = New System.Drawing.Size(47, 17)
        Me.optCraft.TabIndex = 10
        Me.optCraft.TabStop = True
        Me.optCraft.Text = "Craft"
        '
        'optTrap
        '
        Me.optTrap.AutoSize = True
        Me.optTrap.BackColor = System.Drawing.Color.Transparent
        Me.optTrap.Location = New System.Drawing.Point(97, 94)
        Me.optTrap.Name = "optTrap"
        Me.optTrap.Size = New System.Drawing.Size(47, 17)
        Me.optTrap.TabIndex = 9
        Me.optTrap.TabStop = True
        Me.optTrap.Text = "Trap"
        '
        'optHeal
        '
        Me.optHeal.AutoSize = True
        Me.optHeal.BackColor = System.Drawing.Color.Transparent
        Me.optHeal.Location = New System.Drawing.Point(10, 94)
        Me.optHeal.Name = "optHeal"
        Me.optHeal.Size = New System.Drawing.Size(47, 17)
        Me.optHeal.TabIndex = 8
        Me.optHeal.TabStop = True
        Me.optHeal.Text = "Heal"
        '
        'optKeyOpen
        '
        Me.optKeyOpen.AutoSize = True
        Me.optKeyOpen.BackColor = System.Drawing.Color.Transparent
        Me.optKeyOpen.Location = New System.Drawing.Point(235, 50)
        Me.optKeyOpen.Name = "optKeyOpen"
        Me.optKeyOpen.Size = New System.Drawing.Size(72, 17)
        Me.optKeyOpen.TabIndex = 7
        Me.optKeyOpen.TabStop = True
        Me.optKeyOpen.Text = "Key Open"
        '
        'optKey
        '
        Me.optKey.AutoSize = True
        Me.optKey.BackColor = System.Drawing.Color.Transparent
        Me.optKey.Location = New System.Drawing.Point(163, 50)
        Me.optKey.Name = "optKey"
        Me.optKey.Size = New System.Drawing.Size(43, 17)
        Me.optKey.TabIndex = 6
        Me.optKey.TabStop = True
        Me.optKey.Text = "Key"
        '
        'optDoor
        '
        Me.optDoor.AutoSize = True
        Me.optDoor.BackColor = System.Drawing.Color.Transparent
        Me.optDoor.Location = New System.Drawing.Point(97, 50)
        Me.optDoor.Name = "optDoor"
        Me.optDoor.Size = New System.Drawing.Size(48, 17)
        Me.optDoor.TabIndex = 5
        Me.optDoor.TabStop = True
        Me.optDoor.Text = "Door"
        '
        'optResource
        '
        Me.optResource.AutoSize = True
        Me.optResource.BackColor = System.Drawing.Color.Transparent
        Me.optResource.Location = New System.Drawing.Point(10, 50)
        Me.optResource.Name = "optResource"
        Me.optResource.Size = New System.Drawing.Size(71, 17)
        Me.optResource.TabIndex = 4
        Me.optResource.TabStop = True
        Me.optResource.Text = "Resource"
        '
        'optNpcAvoid
        '
        Me.optNpcAvoid.AutoSize = True
        Me.optNpcAvoid.BackColor = System.Drawing.Color.Transparent
        Me.optNpcAvoid.Location = New System.Drawing.Point(235, 7)
        Me.optNpcAvoid.Name = "optNpcAvoid"
        Me.optNpcAvoid.Size = New System.Drawing.Size(75, 17)
        Me.optNpcAvoid.TabIndex = 3
        Me.optNpcAvoid.TabStop = True
        Me.optNpcAvoid.Text = "Npc Avoid"
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.BackColor = System.Drawing.Color.Transparent
        Me.optItem.Location = New System.Drawing.Point(163, 7)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(66, 17)
        Me.optItem.TabIndex = 2
        Me.optItem.TabStop = True
        Me.optItem.Text = "MapItem"
        '
        'optWarp
        '
        Me.optWarp.AutoSize = True
        Me.optWarp.BackColor = System.Drawing.Color.Transparent
        Me.optWarp.Location = New System.Drawing.Point(97, 7)
        Me.optWarp.Name = "optWarp"
        Me.optWarp.Size = New System.Drawing.Size(51, 17)
        Me.optWarp.TabIndex = 1
        Me.optWarp.TabStop = True
        Me.optWarp.Text = "Warp"
        '
        'optBlocked
        '
        Me.optBlocked.AutoSize = True
        Me.optBlocked.BackColor = System.Drawing.Color.Transparent
        Me.optBlocked.Location = New System.Drawing.Point(10, 7)
        Me.optBlocked.Name = "optBlocked"
        Me.optBlocked.Size = New System.Drawing.Size(64, 17)
        Me.optBlocked.TabIndex = 0
        Me.optBlocked.TabStop = True
        Me.optBlocked.Text = "Blocked"
        '
        'pnlNpc
        '
        Me.pnlNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlNpc.Controls.Add(Me.cmbNpcList)
        Me.pnlNpc.Controls.Add(Me.lstMapNpc)
        Me.pnlNpc.Location = New System.Drawing.Point(2, 50)
        Me.pnlNpc.Name = "pnlNpc"
        Me.pnlNpc.Size = New System.Drawing.Size(314, 548)
        Me.pnlNpc.TabIndex = 8
        '
        'cmbNpcList
        '
        Me.cmbNpcList.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbNpcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNpcList.ForeColor = System.Drawing.Color.LightGray
        Me.cmbNpcList.FormattingEnabled = True
        Me.cmbNpcList.Location = New System.Drawing.Point(126, 441)
        Me.cmbNpcList.Name = "cmbNpcList"
        Me.cmbNpcList.Size = New System.Drawing.Size(184, 21)
        Me.cmbNpcList.TabIndex = 18
        '
        'lstMapNpc
        '
        Me.lstMapNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lstMapNpc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMapNpc.ForeColor = System.Drawing.Color.LightGray
        Me.lstMapNpc.FormattingEnabled = True
        Me.lstMapNpc.Location = New System.Drawing.Point(3, 4)
        Me.lstMapNpc.Name = "lstMapNpc"
        Me.lstMapNpc.Size = New System.Drawing.Size(307, 431)
        Me.lstMapNpc.TabIndex = 0
        '
        'pnlDirBlock
        '
        Me.pnlDirBlock.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlDirBlock.Controls.Add(Me.DarkLabel6)
        Me.pnlDirBlock.Location = New System.Drawing.Point(2, 51)
        Me.pnlDirBlock.Name = "pnlDirBlock"
        Me.pnlDirBlock.Size = New System.Drawing.Size(314, 548)
        Me.pnlDirBlock.TabIndex = 7
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(8, 8)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(239, 13)
        Me.DarkLabel6.TabIndex = 0
        Me.DarkLabel6.Text = "Just press the arrows to block that side of the tile."
        '
        'pnlEvents
        '
        Me.pnlEvents.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlEvents.Controls.Add(Me.DarkLabel5)
        Me.pnlEvents.Location = New System.Drawing.Point(4, 50)
        Me.pnlEvents.Name = "pnlEvents"
        Me.pnlEvents.Size = New System.Drawing.Size(314, 548)
        Me.pnlEvents.TabIndex = 6
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(8, 8)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(233, 13)
        Me.DarkLabel5.TabIndex = 0
        Me.DarkLabel5.Text = "Click on the map where you want to ad a event."
        '
        'btnEvents
        '
        Me.btnEvents.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnEvents.Location = New System.Drawing.Point(264, 28)
        Me.btnEvents.Name = "btnEvents"
        Me.btnEvents.Padding = New System.Windows.Forms.Padding(5)
        Me.btnEvents.Size = New System.Drawing.Size(52, 23)
        Me.btnEvents.TabIndex = 4
        Me.btnEvents.Text = "Events"
        '
        'btnDirBlock
        '
        Me.btnDirBlock.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnDirBlock.Location = New System.Drawing.Point(163, 28)
        Me.btnDirBlock.Name = "btnDirBlock"
        Me.btnDirBlock.Padding = New System.Windows.Forms.Padding(5)
        Me.btnDirBlock.Size = New System.Drawing.Size(100, 23)
        Me.btnDirBlock.TabIndex = 3
        Me.btnDirBlock.Text = "Directional Block"
        '
        'btnNpc
        '
        Me.btnNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnNpc.Location = New System.Drawing.Point(118, 28)
        Me.btnNpc.Name = "btnNpc"
        Me.btnNpc.Padding = New System.Windows.Forms.Padding(5)
        Me.btnNpc.Size = New System.Drawing.Size(44, 23)
        Me.btnNpc.TabIndex = 2
        Me.btnNpc.Text = "Npc's"
        '
        'btnAttributes
        '
        Me.btnAttributes.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnAttributes.Location = New System.Drawing.Point(49, 28)
        Me.btnAttributes.Name = "btnAttributes"
        Me.btnAttributes.Padding = New System.Windows.Forms.Padding(5)
        Me.btnAttributes.Size = New System.Drawing.Size(68, 23)
        Me.btnAttributes.TabIndex = 1
        Me.btnAttributes.Text = "Attributes"
        '
        'btnTiles
        '
        Me.btnTiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnTiles.Location = New System.Drawing.Point(4, 28)
        Me.btnTiles.Name = "btnTiles"
        Me.btnTiles.Padding = New System.Windows.Forms.Padding(5)
        Me.btnTiles.Size = New System.Drawing.Size(44, 23)
        Me.btnTiles.TabIndex = 0
        Me.btnTiles.Text = "Tiles"
        '
        'DarkSectionPanel2
        '
        Me.DarkSectionPanel2.AutoScroll = True
        Me.DarkSectionPanel2.Controls.Add(Me.pnlMoreOptions)
        Me.DarkSectionPanel2.Controls.Add(Me.btnMoreOptions)
        Me.DarkSectionPanel2.Controls.Add(Me.GroupBox3)
        Me.DarkSectionPanel2.Controls.Add(Me.GroupBox2)
        Me.DarkSectionPanel2.Controls.Add(Me.GroupBox1)
        Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel7)
        Me.DarkSectionPanel2.Controls.Add(Me.chkInstance)
        Me.DarkSectionPanel2.Controls.Add(Me.txtName)
        Me.DarkSectionPanel2.Controls.Add(Me.DarkLabel8)
        Me.DarkSectionPanel2.Controls.Add(Me.fraMapLinks)
        Me.DarkSectionPanel2.Controls.Add(Me.cmbMoral)
        Me.DarkSectionPanel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DarkSectionPanel2.Location = New System.Drawing.Point(1076, 0)
        Me.DarkSectionPanel2.Name = "DarkSectionPanel2"
        Me.DarkSectionPanel2.SectionHeader = "Map Settings"
        Me.DarkSectionPanel2.Size = New System.Drawing.Size(216, 598)
        Me.DarkSectionPanel2.TabIndex = 8
        '
        'pnlMoreOptions
        '
        Me.pnlMoreOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.pnlMoreOptions.Controls.Add(Me.GroupBox5)
        Me.pnlMoreOptions.Controls.Add(Me.GroupBox4)
        Me.pnlMoreOptions.Location = New System.Drawing.Point(4, 26)
        Me.pnlMoreOptions.Name = "pnlMoreOptions"
        Me.pnlMoreOptions.Size = New System.Drawing.Size(208, 540)
        Me.pnlMoreOptions.TabIndex = 31
        Me.pnlMoreOptions.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkUseTint)
        Me.GroupBox5.Controls.Add(Me.scrlMapAlpha)
        Me.GroupBox5.Controls.Add(Me.lblMapAlpha)
        Me.GroupBox5.Controls.Add(Me.scrlMapBlue)
        Me.GroupBox5.Controls.Add(Me.lblMapBlue)
        Me.GroupBox5.Controls.Add(Me.scrlMapGreen)
        Me.GroupBox5.Controls.Add(Me.lblMapGreen)
        Me.GroupBox5.Controls.Add(Me.scrlMapRed)
        Me.GroupBox5.Controls.Add(Me.lblMapRed)
        Me.GroupBox5.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox5.Location = New System.Drawing.Point(5, 167)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 154)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Map Tinting"
        '
        'chkUseTint
        '
        Me.chkUseTint.AutoSize = True
        Me.chkUseTint.Checked = True
        Me.chkUseTint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseTint.Location = New System.Drawing.Point(6, 20)
        Me.chkUseTint.Name = "chkUseTint"
        Me.chkUseTint.Size = New System.Drawing.Size(93, 17)
        Me.chkUseTint.TabIndex = 25
        Me.chkUseTint.Text = "Use MapTint?"
        Me.chkUseTint.UseVisualStyleBackColor = True
        '
        'scrlMapAlpha
        '
        Me.scrlMapAlpha.BackColor = System.Drawing.Color.LightGray
        Me.scrlMapAlpha.ForeColor = System.Drawing.Color.DimGray
        Me.scrlMapAlpha.Location = New System.Drawing.Point(91, 127)
        Me.scrlMapAlpha.Maximum = 255
        Me.scrlMapAlpha.Name = "scrlMapAlpha"
        Me.scrlMapAlpha.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlMapAlpha.Size = New System.Drawing.Size(103, 15)
        Me.scrlMapAlpha.TabIndex = 24
        '
        'lblMapAlpha
        '
        Me.lblMapAlpha.AutoSize = True
        Me.lblMapAlpha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblMapAlpha.Location = New System.Drawing.Point(6, 129)
        Me.lblMapAlpha.Name = "lblMapAlpha"
        Me.lblMapAlpha.Size = New System.Drawing.Size(46, 13)
        Me.lblMapAlpha.TabIndex = 23
        Me.lblMapAlpha.Text = "Alpha: 0"
        '
        'scrlMapBlue
        '
        Me.scrlMapBlue.BackColor = System.Drawing.Color.LightGray
        Me.scrlMapBlue.ForeColor = System.Drawing.Color.DimGray
        Me.scrlMapBlue.Location = New System.Drawing.Point(92, 101)
        Me.scrlMapBlue.Name = "scrlMapBlue"
        Me.scrlMapBlue.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlMapBlue.Size = New System.Drawing.Size(103, 15)
        Me.scrlMapBlue.TabIndex = 22
        '
        'lblMapBlue
        '
        Me.lblMapBlue.AutoSize = True
        Me.lblMapBlue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblMapBlue.Location = New System.Drawing.Point(7, 101)
        Me.lblMapBlue.Name = "lblMapBlue"
        Me.lblMapBlue.Size = New System.Drawing.Size(40, 13)
        Me.lblMapBlue.TabIndex = 21
        Me.lblMapBlue.Text = "Blue: 0"
        '
        'scrlMapGreen
        '
        Me.scrlMapGreen.BackColor = System.Drawing.Color.LightGray
        Me.scrlMapGreen.ForeColor = System.Drawing.Color.DimGray
        Me.scrlMapGreen.Location = New System.Drawing.Point(91, 74)
        Me.scrlMapGreen.Name = "scrlMapGreen"
        Me.scrlMapGreen.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlMapGreen.Size = New System.Drawing.Size(103, 15)
        Me.scrlMapGreen.TabIndex = 20
        '
        'lblMapGreen
        '
        Me.lblMapGreen.AutoSize = True
        Me.lblMapGreen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblMapGreen.Location = New System.Drawing.Point(6, 74)
        Me.lblMapGreen.Name = "lblMapGreen"
        Me.lblMapGreen.Size = New System.Drawing.Size(48, 13)
        Me.lblMapGreen.TabIndex = 19
        Me.lblMapGreen.Text = "Green: 0"
        '
        'scrlMapRed
        '
        Me.scrlMapRed.BackColor = System.Drawing.Color.LightGray
        Me.scrlMapRed.ForeColor = System.Drawing.Color.DimGray
        Me.scrlMapRed.Location = New System.Drawing.Point(91, 48)
        Me.scrlMapRed.Name = "scrlMapRed"
        Me.scrlMapRed.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlMapRed.Size = New System.Drawing.Size(103, 15)
        Me.scrlMapRed.TabIndex = 18
        '
        'lblMapRed
        '
        Me.lblMapRed.AutoSize = True
        Me.lblMapRed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblMapRed.Location = New System.Drawing.Point(6, 48)
        Me.lblMapRed.Name = "lblMapRed"
        Me.lblMapRed.Size = New System.Drawing.Size(39, 13)
        Me.lblMapRed.TabIndex = 17
        Me.lblMapRed.Text = "Red: 0"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.scrlFogAlpha)
        Me.GroupBox4.Controls.Add(Me.lblFogAlpha)
        Me.GroupBox4.Controls.Add(Me.scrlFogSpeed)
        Me.GroupBox4.Controls.Add(Me.lblFogSpeed)
        Me.GroupBox4.Controls.Add(Me.scrlFog)
        Me.GroupBox4.Controls.Add(Me.lblFogIndex)
        Me.GroupBox4.Controls.Add(Me.scrlIntensity)
        Me.GroupBox4.Controls.Add(Me.lblIntensity)
        Me.GroupBox4.Controls.Add(Me.cmbWeather)
        Me.GroupBox4.Controls.Add(Me.DarkLabel14)
        Me.GroupBox4.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox4.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 154)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Weather Options"
        '
        'scrlFogAlpha
        '
        Me.scrlFogAlpha.BackColor = System.Drawing.Color.LightGray
        Me.scrlFogAlpha.ForeColor = System.Drawing.Color.DimGray
        Me.scrlFogAlpha.Location = New System.Drawing.Point(91, 127)
        Me.scrlFogAlpha.Maximum = 255
        Me.scrlFogAlpha.Name = "scrlFogAlpha"
        Me.scrlFogAlpha.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlFogAlpha.Size = New System.Drawing.Size(103, 15)
        Me.scrlFogAlpha.TabIndex = 24
        '
        'lblFogAlpha
        '
        Me.lblFogAlpha.AutoSize = True
        Me.lblFogAlpha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblFogAlpha.Location = New System.Drawing.Point(6, 129)
        Me.lblFogAlpha.Name = "lblFogAlpha"
        Me.lblFogAlpha.Size = New System.Drawing.Size(67, 13)
        Me.lblFogAlpha.TabIndex = 23
        Me.lblFogAlpha.Text = "Fog Alpha: 0"
        '
        'scrlFogSpeed
        '
        Me.scrlFogSpeed.BackColor = System.Drawing.Color.LightGray
        Me.scrlFogSpeed.ForeColor = System.Drawing.Color.DimGray
        Me.scrlFogSpeed.Location = New System.Drawing.Point(92, 101)
        Me.scrlFogSpeed.Name = "scrlFogSpeed"
        Me.scrlFogSpeed.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlFogSpeed.Size = New System.Drawing.Size(103, 15)
        Me.scrlFogSpeed.TabIndex = 22
        '
        'lblFogSpeed
        '
        Me.lblFogSpeed.AutoSize = True
        Me.lblFogSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblFogSpeed.Location = New System.Drawing.Point(7, 101)
        Me.lblFogSpeed.Name = "lblFogSpeed"
        Me.lblFogSpeed.Size = New System.Drawing.Size(71, 13)
        Me.lblFogSpeed.TabIndex = 21
        Me.lblFogSpeed.Text = "Fog Speed: 0"
        '
        'scrlFog
        '
        Me.scrlFog.BackColor = System.Drawing.Color.LightGray
        Me.scrlFog.ForeColor = System.Drawing.Color.DimGray
        Me.scrlFog.Location = New System.Drawing.Point(91, 74)
        Me.scrlFog.Name = "scrlFog"
        Me.scrlFog.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlFog.Size = New System.Drawing.Size(103, 15)
        Me.scrlFog.TabIndex = 20
        '
        'lblFogIndex
        '
        Me.lblFogIndex.AutoSize = True
        Me.lblFogIndex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblFogIndex.Location = New System.Drawing.Point(6, 74)
        Me.lblFogIndex.Name = "lblFogIndex"
        Me.lblFogIndex.Size = New System.Drawing.Size(37, 13)
        Me.lblFogIndex.TabIndex = 19
        Me.lblFogIndex.Text = "Fog: 0"
        '
        'scrlIntensity
        '
        Me.scrlIntensity.BackColor = System.Drawing.Color.LightGray
        Me.scrlIntensity.ForeColor = System.Drawing.Color.DimGray
        Me.scrlIntensity.Location = New System.Drawing.Point(91, 48)
        Me.scrlIntensity.Name = "scrlIntensity"
        Me.scrlIntensity.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlIntensity.Size = New System.Drawing.Size(103, 15)
        Me.scrlIntensity.TabIndex = 18
        '
        'lblIntensity
        '
        Me.lblIntensity.AutoSize = True
        Me.lblIntensity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblIntensity.Location = New System.Drawing.Point(6, 48)
        Me.lblIntensity.Name = "lblIntensity"
        Me.lblIntensity.Size = New System.Drawing.Size(70, 13)
        Me.lblIntensity.TabIndex = 17
        Me.lblIntensity.Text = "Intensity: 100"
        '
        'cmbWeather
        '
        Me.cmbWeather.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbWeather.ForeColor = System.Drawing.Color.LightGray
        Me.cmbWeather.FormattingEnabled = True
        Me.cmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm", "Fog"})
        Me.cmbWeather.Location = New System.Drawing.Point(91, 17)
        Me.cmbWeather.Name = "cmbWeather"
        Me.cmbWeather.Size = New System.Drawing.Size(103, 21)
        Me.cmbWeather.TabIndex = 16
        '
        'DarkLabel14
        '
        Me.DarkLabel14.AutoSize = True
        Me.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel14.Location = New System.Drawing.Point(7, 22)
        Me.DarkLabel14.Name = "DarkLabel14"
        Me.DarkLabel14.Size = New System.Drawing.Size(78, 13)
        Me.DarkLabel14.TabIndex = 0
        Me.DarkLabel14.Text = "Weather Type:"
        '
        'btnMoreOptions
        '
        Me.btnMoreOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnMoreOptions.Location = New System.Drawing.Point(9, 571)
        Me.btnMoreOptions.Name = "btnMoreOptions"
        Me.btnMoreOptions.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMoreOptions.Size = New System.Drawing.Size(203, 23)
        Me.btnMoreOptions.TabIndex = 30
        Me.btnMoreOptions.Text = "More Options"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnPreview)
        Me.GroupBox3.Controls.Add(Me.lstMusic)
        Me.GroupBox3.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox3.Location = New System.Drawing.Point(9, 406)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(203, 160)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Music"
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.Location = New System.Drawing.Point(10, 128)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Padding = New System.Windows.Forms.Padding(5)
        Me.btnPreview.Size = New System.Drawing.Size(185, 23)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Preview Music"
        Me.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPreview.UseMnemonic = False
        '
        'lstMusic
        '
        Me.lstMusic.FormattingEnabled = True
        Me.lstMusic.Location = New System.Drawing.Point(6, 14)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.ScrollAlwaysVisible = True
        Me.lstMusic.Size = New System.Drawing.Size(191, 108)
        Me.lstMusic.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnSetSize)
        Me.GroupBox2.Controls.Add(Me.txtMaxY)
        Me.GroupBox2.Controls.Add(Me.txtMaxX)
        Me.GroupBox2.Controls.Add(Me.DarkLabel13)
        Me.GroupBox2.Controls.Add(Me.DarkLabel12)
        Me.GroupBox2.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Location = New System.Drawing.Point(9, 305)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(203, 95)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Map Size"
        '
        'btnSetSize
        '
        Me.btnSetSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnSetSize.Location = New System.Drawing.Point(10, 62)
        Me.btnSetSize.Name = "btnSetSize"
        Me.btnSetSize.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSetSize.Size = New System.Drawing.Size(75, 23)
        Me.btnSetSize.TabIndex = 4
        Me.btnSetSize.Text = "Set Size"
        '
        'txtMaxY
        '
        Me.txtMaxY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMaxY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMaxY.Location = New System.Drawing.Point(108, 40)
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.Size = New System.Drawing.Size(89, 20)
        Me.txtMaxY.TabIndex = 3
        '
        'txtMaxX
        '
        Me.txtMaxX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMaxX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMaxX.Location = New System.Drawing.Point(108, 14)
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.Size = New System.Drawing.Size(89, 20)
        Me.txtMaxX.TabIndex = 2
        '
        'DarkLabel13
        '
        Me.DarkLabel13.AutoSize = True
        Me.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel13.Location = New System.Drawing.Point(6, 42)
        Me.DarkLabel13.Name = "DarkLabel13"
        Me.DarkLabel13.Size = New System.Drawing.Size(64, 13)
        Me.DarkLabel13.TabIndex = 1
        Me.DarkLabel13.Text = "Maximum Y:"
        '
        'DarkLabel12
        '
        Me.DarkLabel12.AutoSize = True
        Me.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel12.Location = New System.Drawing.Point(6, 16)
        Me.DarkLabel12.Name = "DarkLabel12"
        Me.DarkLabel12.Size = New System.Drawing.Size(64, 13)
        Me.DarkLabel12.TabIndex = 0
        Me.DarkLabel12.Text = "Maximum X:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtSpawnY)
        Me.GroupBox1.Controls.Add(Me.txtSpawnX)
        Me.GroupBox1.Controls.Add(Me.txtSpawnMap)
        Me.GroupBox1.Controls.Add(Me.DarkLabel11)
        Me.GroupBox1.Controls.Add(Me.DarkLabel10)
        Me.GroupBox1.Controls.Add(Me.DarkLabel9)
        Me.GroupBox1.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox1.Location = New System.Drawing.Point(9, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 85)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Respawn Settings"
        '
        'txtSpawnY
        '
        Me.txtSpawnY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtSpawnY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpawnY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtSpawnY.Location = New System.Drawing.Point(108, 59)
        Me.txtSpawnY.Name = "txtSpawnY"
        Me.txtSpawnY.Size = New System.Drawing.Size(87, 20)
        Me.txtSpawnY.TabIndex = 5
        Me.txtSpawnY.Text = "0"
        '
        'txtSpawnX
        '
        Me.txtSpawnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtSpawnX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpawnX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtSpawnX.Location = New System.Drawing.Point(108, 36)
        Me.txtSpawnX.Name = "txtSpawnX"
        Me.txtSpawnX.Size = New System.Drawing.Size(87, 20)
        Me.txtSpawnX.TabIndex = 4
        Me.txtSpawnX.Text = "0"
        '
        'txtSpawnMap
        '
        Me.txtSpawnMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtSpawnMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpawnMap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtSpawnMap.Location = New System.Drawing.Point(108, 13)
        Me.txtSpawnMap.Name = "txtSpawnMap"
        Me.txtSpawnMap.Size = New System.Drawing.Size(87, 20)
        Me.txtSpawnMap.TabIndex = 3
        Me.txtSpawnMap.Text = "0"
        '
        'DarkLabel11
        '
        Me.DarkLabel11.AutoSize = True
        Me.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel11.Location = New System.Drawing.Point(6, 60)
        Me.DarkLabel11.Name = "DarkLabel11"
        Me.DarkLabel11.Size = New System.Drawing.Size(65, 13)
        Me.DarkLabel11.TabIndex = 2
        Me.DarkLabel11.Text = "Respawn Y:"
        '
        'DarkLabel10
        '
        Me.DarkLabel10.AutoSize = True
        Me.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel10.Location = New System.Drawing.Point(6, 41)
        Me.DarkLabel10.Name = "DarkLabel10"
        Me.DarkLabel10.Size = New System.Drawing.Size(65, 13)
        Me.DarkLabel10.TabIndex = 1
        Me.DarkLabel10.Text = "Respawn X:"
        '
        'DarkLabel9
        '
        Me.DarkLabel9.AutoSize = True
        Me.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel9.Location = New System.Drawing.Point(6, 22)
        Me.DarkLabel9.Name = "DarkLabel9"
        Me.DarkLabel9.Size = New System.Drawing.Size(79, 13)
        Me.DarkLabel9.TabIndex = 0
        Me.DarkLabel9.Text = "Respawn Map:"
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.BackColor = System.Drawing.Color.Transparent
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(6, 33)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(38, 13)
        Me.DarkLabel7.TabIndex = 21
        Me.DarkLabel7.Text = "Name:"
        '
        'chkInstance
        '
        Me.chkInstance.AutoSize = True
        Me.chkInstance.Location = New System.Drawing.Point(9, 85)
        Me.chkInstance.Name = "chkInstance"
        Me.chkInstance.Size = New System.Drawing.Size(79, 17)
        Me.chkInstance.TabIndex = 26
        Me.chkInstance.Text = "Instanced?"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(50, 31)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(162, 20)
        Me.txtName.TabIndex = 22
        '
        'DarkLabel8
        '
        Me.DarkLabel8.AutoSize = True
        Me.DarkLabel8.BackColor = System.Drawing.Color.Transparent
        Me.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel8.Location = New System.Drawing.Point(8, 60)
        Me.DarkLabel8.Name = "DarkLabel8"
        Me.DarkLabel8.Size = New System.Drawing.Size(36, 13)
        Me.DarkLabel8.TabIndex = 25
        Me.DarkLabel8.Text = "Moral:"
        '
        'fraMapLinks
        '
        Me.fraMapLinks.BackColor = System.Drawing.Color.Transparent
        Me.fraMapLinks.Controls.Add(Me.lblMap)
        Me.fraMapLinks.Controls.Add(Me.txtRight)
        Me.fraMapLinks.Controls.Add(Me.txtLeft)
        Me.fraMapLinks.Controls.Add(Me.txtDown)
        Me.fraMapLinks.Controls.Add(Me.txtUp)
        Me.fraMapLinks.ForeColor = System.Drawing.Color.LightGray
        Me.fraMapLinks.Location = New System.Drawing.Point(9, 105)
        Me.fraMapLinks.Name = "fraMapLinks"
        Me.fraMapLinks.Size = New System.Drawing.Size(203, 100)
        Me.fraMapLinks.TabIndex = 23
        Me.fraMapLinks.TabStop = False
        Me.fraMapLinks.Text = "Map Links"
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblMap.Location = New System.Drawing.Point(72, 44)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(65, 13)
        Me.lblMap.TabIndex = 4
        Me.lblMap.Text = "Curr. Map: 0"
        '
        'txtRight
        '
        Me.txtRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtRight.Location = New System.Drawing.Point(147, 42)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(50, 20)
        Me.txtRight.TabIndex = 3
        '
        'txtLeft
        '
        Me.txtLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeft.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtLeft.Location = New System.Drawing.Point(6, 42)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(50, 20)
        Me.txtLeft.TabIndex = 2
        '
        'txtDown
        '
        Me.txtDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDown.Location = New System.Drawing.Point(75, 74)
        Me.txtDown.Name = "txtDown"
        Me.txtDown.Size = New System.Drawing.Size(50, 20)
        Me.txtDown.TabIndex = 1
        '
        'txtUp
        '
        Me.txtUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtUp.Location = New System.Drawing.Point(75, 11)
        Me.txtUp.Name = "txtUp"
        Me.txtUp.Size = New System.Drawing.Size(50, 20)
        Me.txtUp.TabIndex = 0
        '
        'cmbMoral
        '
        Me.cmbMoral.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbMoral.ForeColor = System.Drawing.Color.LightGray
        Me.cmbMoral.FormattingEnabled = True
        Me.cmbMoral.Items.AddRange(New Object() {"None", "Safe Zone", "Indoors"})
        Me.cmbMoral.Location = New System.Drawing.Point(50, 57)
        Me.cmbMoral.Name = "cmbMoral"
        Me.cmbMoral.Size = New System.Drawing.Size(162, 21)
        Me.cmbMoral.TabIndex = 24
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbDiscard, Me.ToolStripSeparator1, Me.tsbMapGrid, Me.ToolStripSeparator2, Me.tsbFill, Me.tsbClear, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.cmbMapList, Me.ToolStripSeparator4, Me.tsbScreenShot})
        Me.ToolStrip.Location = New System.Drawing.Point(318, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.ToolStrip.Size = New System.Drawing.Size(758, 25)
        Me.ToolStrip.Stretch = True
        Me.ToolStrip.TabIndex = 11
        Me.ToolStrip.Text = "DarkToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(78, 22)
        Me.tsbSave.Text = "Save Map"
        '
        'tsbDiscard
        '
        Me.tsbDiscard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tsbDiscard.Image = CType(resources.GetObject("tsbDiscard.Image"), System.Drawing.Image)
        Me.tsbDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDiscard.Name = "tsbDiscard"
        Me.tsbDiscard.Size = New System.Drawing.Size(66, 22)
        Me.tsbDiscard.Text = "Discard"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbMapGrid
        '
        Me.tsbMapGrid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tsbMapGrid.Image = CType(resources.GetObject("tsbMapGrid.Image"), System.Drawing.Image)
        Me.tsbMapGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMapGrid.Name = "tsbMapGrid"
        Me.tsbMapGrid.Size = New System.Drawing.Size(76, 22)
        Me.tsbMapGrid.Text = "Map Grid"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator2.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFill
        '
        Me.tsbFill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tsbFill.Image = CType(resources.GetObject("tsbFill.Image"), System.Drawing.Image)
        Me.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFill.Name = "tsbFill"
        Me.tsbFill.Size = New System.Drawing.Size(73, 22)
        Me.tsbFill.Text = "Fill Layer"
        '
        'tsbClear
        '
        Me.tsbClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tsbClear.Image = CType(resources.GetObject("tsbClear.Image"), System.Drawing.Image)
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(85, 22)
        Me.tsbClear.Text = "Clear Layer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator3.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel1.Text = "Map:"
        '
        'cmbMapList
        '
        Me.cmbMapList.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.cmbMapList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cmbMapList.Name = "cmbMapList"
        Me.cmbMapList.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator4.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbScreenShot
        '
        Me.tsbScreenShot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tsbScreenShot.Image = CType(resources.GetObject("tsbScreenShot.Image"), System.Drawing.Image)
        Me.tsbScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbScreenShot.Name = "tsbScreenShot"
        Me.tsbScreenShot.Size = New System.Drawing.Size(86, 22)
        Me.tsbScreenShot.Text = "ScreenShot"
        '
        'pnlBack2
        '
        Me.pnlBack2.Controls.Add(Me.pnlAttributes)
        Me.pnlBack2.Controls.Add(Me.scrlMapViewV)
        Me.pnlBack2.Controls.Add(Me.scrlMapViewH)
        Me.pnlBack2.Controls.Add(Me.picScreen)
        Me.pnlBack2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBack2.Location = New System.Drawing.Point(318, 25)
        Me.pnlBack2.Name = "pnlBack2"
        Me.pnlBack2.SectionHeader = "MapView"
        Me.pnlBack2.Size = New System.Drawing.Size(758, 573)
        Me.pnlBack2.TabIndex = 12
        '
        'pnlAttributes
        '
        Me.pnlAttributes.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.pnlAttributes.Controls.Add(Me.fraMapWarp)
        Me.pnlAttributes.Controls.Add(Me.fraBuyHouse)
        Me.pnlAttributes.Controls.Add(Me.fraKeyOpen)
        Me.pnlAttributes.Controls.Add(Me.fraMapKey)
        Me.pnlAttributes.Controls.Add(Me.fraNpcSpawn)
        Me.pnlAttributes.Controls.Add(Me.fraHeal)
        Me.pnlAttributes.Controls.Add(Me.fraShop)
        Me.pnlAttributes.Controls.Add(Me.fraResource)
        Me.pnlAttributes.Controls.Add(Me.fraMapItem)
        Me.pnlAttributes.Controls.Add(Me.fraTrap)
        Me.pnlAttributes.ForeColor = System.Drawing.Color.LightGray
        Me.pnlAttributes.Location = New System.Drawing.Point(6, 34)
        Me.pnlAttributes.Name = "pnlAttributes"
        Me.pnlAttributes.Size = New System.Drawing.Size(709, 516)
        Me.pnlAttributes.TabIndex = 11
        Me.pnlAttributes.Visible = False
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
        Me.fraMapWarp.ForeColor = System.Drawing.Color.LightGray
        Me.fraMapWarp.Location = New System.Drawing.Point(428, 134)
        Me.fraMapWarp.Name = "fraMapWarp"
        Me.fraMapWarp.Size = New System.Drawing.Size(211, 112)
        Me.fraMapWarp.TabIndex = 18
        Me.fraMapWarp.TabStop = False
        Me.fraMapWarp.Text = "Map Warp"
        '
        'btnMapWarp
        '
        Me.btnMapWarp.ForeColor = System.Drawing.Color.Black
        Me.btnMapWarp.Location = New System.Drawing.Point(84, 81)
        Me.btnMapWarp.Name = "btnMapWarp"
        Me.btnMapWarp.Size = New System.Drawing.Size(90, 28)
        Me.btnMapWarp.TabIndex = 6
        Me.btnMapWarp.Text = "Accept"
        Me.btnMapWarp.UseVisualStyleBackColor = True
        '
        'scrlMapWarpY
        '
        Me.scrlMapWarpY.Location = New System.Drawing.Point(58, 60)
        Me.scrlMapWarpY.Name = "scrlMapWarpY"
        Me.scrlMapWarpY.Size = New System.Drawing.Size(144, 18)
        Me.scrlMapWarpY.TabIndex = 5
        '
        'scrlMapWarpX
        '
        Me.scrlMapWarpX.Location = New System.Drawing.Point(58, 38)
        Me.scrlMapWarpX.Name = "scrlMapWarpX"
        Me.scrlMapWarpX.Size = New System.Drawing.Size(144, 18)
        Me.scrlMapWarpX.TabIndex = 4
        '
        'scrlMapWarpMap
        '
        Me.scrlMapWarpMap.Location = New System.Drawing.Point(58, 16)
        Me.scrlMapWarpMap.Name = "scrlMapWarpMap"
        Me.scrlMapWarpMap.Size = New System.Drawing.Size(144, 18)
        Me.scrlMapWarpMap.TabIndex = 3
        '
        'lblMapWarpY
        '
        Me.lblMapWarpY.AutoSize = True
        Me.lblMapWarpY.Location = New System.Drawing.Point(7, 62)
        Me.lblMapWarpY.Name = "lblMapWarpY"
        Me.lblMapWarpY.Size = New System.Drawing.Size(26, 13)
        Me.lblMapWarpY.TabIndex = 2
        Me.lblMapWarpY.Text = "Y: 1"
        '
        'lblMapWarpX
        '
        Me.lblMapWarpX.AutoSize = True
        Me.lblMapWarpX.Location = New System.Drawing.Point(7, 41)
        Me.lblMapWarpX.Name = "lblMapWarpX"
        Me.lblMapWarpX.Size = New System.Drawing.Size(26, 13)
        Me.lblMapWarpX.TabIndex = 1
        Me.lblMapWarpX.Text = "X: 1"
        '
        'lblMapWarpMap
        '
        Me.lblMapWarpMap.AutoSize = True
        Me.lblMapWarpMap.Location = New System.Drawing.Point(6, 21)
        Me.lblMapWarpMap.Name = "lblMapWarpMap"
        Me.lblMapWarpMap.Size = New System.Drawing.Size(40, 13)
        Me.lblMapWarpMap.TabIndex = 0
        Me.lblMapWarpMap.Text = "Map: 1"
        '
        'fraBuyHouse
        '
        Me.fraBuyHouse.Controls.Add(Me.btnHouseTileOk)
        Me.fraBuyHouse.Controls.Add(Me.scrlBuyHouse)
        Me.fraBuyHouse.Controls.Add(Me.lblHouseName)
        Me.fraBuyHouse.ForeColor = System.Drawing.Color.LightGray
        Me.fraBuyHouse.Location = New System.Drawing.Point(428, 9)
        Me.fraBuyHouse.Name = "fraBuyHouse"
        Me.fraBuyHouse.Size = New System.Drawing.Size(211, 119)
        Me.fraBuyHouse.TabIndex = 27
        Me.fraBuyHouse.TabStop = False
        Me.fraBuyHouse.Text = "Buy House"
        '
        'btnHouseTileOk
        '
        Me.btnHouseTileOk.ForeColor = System.Drawing.Color.Black
        Me.btnHouseTileOk.Location = New System.Drawing.Point(58, 85)
        Me.btnHouseTileOk.Name = "btnHouseTileOk"
        Me.btnHouseTileOk.Size = New System.Drawing.Size(90, 28)
        Me.btnHouseTileOk.TabIndex = 6
        Me.btnHouseTileOk.Text = "Accept"
        Me.btnHouseTileOk.UseVisualStyleBackColor = True
        '
        'scrlBuyHouse
        '
        Me.scrlBuyHouse.LargeChange = 1
        Me.scrlBuyHouse.Location = New System.Drawing.Point(9, 36)
        Me.scrlBuyHouse.Name = "scrlBuyHouse"
        Me.scrlBuyHouse.Size = New System.Drawing.Size(193, 18)
        Me.scrlBuyHouse.TabIndex = 3
        '
        'lblHouseName
        '
        Me.lblHouseName.AutoSize = True
        Me.lblHouseName.Location = New System.Drawing.Point(6, 16)
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
        Me.fraKeyOpen.ForeColor = System.Drawing.Color.LightGray
        Me.fraKeyOpen.Location = New System.Drawing.Point(3, 369)
        Me.fraKeyOpen.Name = "fraKeyOpen"
        Me.fraKeyOpen.Size = New System.Drawing.Size(207, 138)
        Me.fraKeyOpen.TabIndex = 21
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
        Me.btnMapKeyOpen.ForeColor = System.Drawing.Color.Black
        Me.btnMapKeyOpen.Location = New System.Drawing.Point(53, 105)
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
        'fraMapKey
        '
        Me.fraMapKey.Controls.Add(Me.chkMapKey)
        Me.fraMapKey.Controls.Add(Me.picMapKey)
        Me.fraMapKey.Controls.Add(Me.btnMapKey)
        Me.fraMapKey.Controls.Add(Me.scrlMapKey)
        Me.fraMapKey.Controls.Add(Me.lblMapKey)
        Me.fraMapKey.ForeColor = System.Drawing.Color.LightGray
        Me.fraMapKey.Location = New System.Drawing.Point(216, 369)
        Me.fraMapKey.Name = "fraMapKey"
        Me.fraMapKey.Size = New System.Drawing.Size(206, 138)
        Me.fraMapKey.TabIndex = 20
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
        Me.picMapKey.Location = New System.Drawing.Point(172, 25)
        Me.picMapKey.Name = "picMapKey"
        Me.picMapKey.Size = New System.Drawing.Size(32, 32)
        Me.picMapKey.TabIndex = 7
        Me.picMapKey.TabStop = False
        '
        'btnMapKey
        '
        Me.btnMapKey.ForeColor = System.Drawing.Color.Black
        Me.btnMapKey.Location = New System.Drawing.Point(54, 103)
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
        Me.fraNpcSpawn.ForeColor = System.Drawing.Color.LightGray
        Me.fraNpcSpawn.Location = New System.Drawing.Point(3, 8)
        Me.fraNpcSpawn.Name = "fraNpcSpawn"
        Me.fraNpcSpawn.Size = New System.Drawing.Size(207, 120)
        Me.fraNpcSpawn.TabIndex = 23
        Me.fraNpcSpawn.TabStop = False
        Me.fraNpcSpawn.Text = "Npc Spawn"
        '
        'lstNpc
        '
        Me.lstNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstNpc.FormattingEnabled = True
        Me.lstNpc.Location = New System.Drawing.Point(6, 21)
        Me.lstNpc.Name = "lstNpc"
        Me.lstNpc.Size = New System.Drawing.Size(192, 21)
        Me.lstNpc.TabIndex = 37
        '
        'btnNpcSpawn
        '
        Me.btnNpcSpawn.BackColor = System.Drawing.SystemColors.Control
        Me.btnNpcSpawn.ForeColor = System.Drawing.Color.Black
        Me.btnNpcSpawn.Location = New System.Drawing.Point(53, 86)
        Me.btnNpcSpawn.Name = "btnNpcSpawn"
        Me.btnNpcSpawn.Size = New System.Drawing.Size(90, 28)
        Me.btnNpcSpawn.TabIndex = 6
        Me.btnNpcSpawn.Text = "Accept"
        Me.btnNpcSpawn.UseVisualStyleBackColor = False
        '
        'scrlNpcDir
        '
        Me.scrlNpcDir.LargeChange = 1
        Me.scrlNpcDir.Location = New System.Drawing.Point(6, 64)
        Me.scrlNpcDir.Maximum = 3
        Me.scrlNpcDir.Name = "scrlNpcDir"
        Me.scrlNpcDir.Size = New System.Drawing.Size(193, 18)
        Me.scrlNpcDir.TabIndex = 3
        '
        'lblNpcDir
        '
        Me.lblNpcDir.AutoSize = True
        Me.lblNpcDir.Location = New System.Drawing.Point(3, 49)
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
        Me.fraHeal.ForeColor = System.Drawing.Color.LightGray
        Me.fraHeal.Location = New System.Drawing.Point(3, 252)
        Me.fraHeal.Name = "fraHeal"
        Me.fraHeal.Size = New System.Drawing.Size(207, 111)
        Me.fraHeal.TabIndex = 25
        Me.fraHeal.TabStop = False
        Me.fraHeal.Text = "Heal"
        '
        'scrlHeal
        '
        Me.scrlHeal.Location = New System.Drawing.Point(7, 56)
        Me.scrlHeal.Name = "scrlHeal"
        Me.scrlHeal.Size = New System.Drawing.Size(191, 17)
        Me.scrlHeal.TabIndex = 39
        '
        'lblHeal
        '
        Me.lblHeal.AutoSize = True
        Me.lblHeal.Location = New System.Drawing.Point(8, 43)
        Me.lblHeal.Name = "lblHeal"
        Me.lblHeal.Size = New System.Drawing.Size(55, 13)
        Me.lblHeal.TabIndex = 38
        Me.lblHeal.Text = "Amount: 0"
        '
        'cmbHeal
        '
        Me.cmbHeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHeal.FormattingEnabled = True
        Me.cmbHeal.Items.AddRange(New Object() {"Hp", "Mp"})
        Me.cmbHeal.Location = New System.Drawing.Point(7, 19)
        Me.cmbHeal.Name = "cmbHeal"
        Me.cmbHeal.Size = New System.Drawing.Size(192, 21)
        Me.cmbHeal.TabIndex = 37
        '
        'btnHeal
        '
        Me.btnHeal.ForeColor = System.Drawing.Color.Black
        Me.btnHeal.Location = New System.Drawing.Point(53, 76)
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
        Me.fraShop.ForeColor = System.Drawing.Color.LightGray
        Me.fraShop.Location = New System.Drawing.Point(216, 252)
        Me.fraShop.Name = "fraShop"
        Me.fraShop.Size = New System.Drawing.Size(206, 111)
        Me.fraShop.TabIndex = 24
        Me.fraShop.TabStop = False
        Me.fraShop.Text = "Shop"
        '
        'cmbShop
        '
        Me.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShop.FormattingEnabled = True
        Me.cmbShop.Location = New System.Drawing.Point(6, 19)
        Me.cmbShop.Name = "cmbShop"
        Me.cmbShop.Size = New System.Drawing.Size(192, 21)
        Me.cmbShop.TabIndex = 37
        '
        'btnShop
        '
        Me.btnShop.ForeColor = System.Drawing.Color.Black
        Me.btnShop.Location = New System.Drawing.Point(54, 76)
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
        Me.fraResource.ForeColor = System.Drawing.Color.LightGray
        Me.fraResource.Location = New System.Drawing.Point(216, 8)
        Me.fraResource.Name = "fraResource"
        Me.fraResource.Size = New System.Drawing.Size(206, 120)
        Me.fraResource.TabIndex = 22
        Me.fraResource.TabStop = False
        Me.fraResource.Text = "Resources"
        '
        'btnResourceOk
        '
        Me.btnResourceOk.ForeColor = System.Drawing.Color.Black
        Me.btnResourceOk.Location = New System.Drawing.Point(56, 86)
        Me.btnResourceOk.Name = "btnResourceOk"
        Me.btnResourceOk.Size = New System.Drawing.Size(90, 28)
        Me.btnResourceOk.TabIndex = 6
        Me.btnResourceOk.Text = "Accept"
        Me.btnResourceOk.UseVisualStyleBackColor = True
        '
        'scrlResource
        '
        Me.scrlResource.Location = New System.Drawing.Point(9, 49)
        Me.scrlResource.Name = "scrlResource"
        Me.scrlResource.Size = New System.Drawing.Size(182, 18)
        Me.scrlResource.TabIndex = 3
        '
        'lblResource
        '
        Me.lblResource.AutoSize = True
        Me.lblResource.Location = New System.Drawing.Point(6, 29)
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
        Me.fraMapItem.ForeColor = System.Drawing.Color.LightGray
        Me.fraMapItem.Location = New System.Drawing.Point(216, 134)
        Me.fraMapItem.Name = "fraMapItem"
        Me.fraMapItem.Size = New System.Drawing.Size(206, 112)
        Me.fraMapItem.TabIndex = 19
        Me.fraMapItem.TabStop = False
        Me.fraMapItem.Text = "Map Item"
        '
        'picMapItem
        '
        Me.picMapItem.BackColor = System.Drawing.Color.Black
        Me.picMapItem.Location = New System.Drawing.Point(161, 31)
        Me.picMapItem.Name = "picMapItem"
        Me.picMapItem.Size = New System.Drawing.Size(32, 32)
        Me.picMapItem.TabIndex = 7
        Me.picMapItem.TabStop = False
        '
        'btnMapItem
        '
        Me.btnMapItem.ForeColor = System.Drawing.Color.Black
        Me.btnMapItem.Location = New System.Drawing.Point(58, 78)
        Me.btnMapItem.Name = "btnMapItem"
        Me.btnMapItem.Size = New System.Drawing.Size(90, 28)
        Me.btnMapItem.TabIndex = 6
        Me.btnMapItem.Text = "Accept"
        Me.btnMapItem.UseVisualStyleBackColor = True
        '
        'scrlMapItemValue
        '
        Me.scrlMapItemValue.Location = New System.Drawing.Point(9, 53)
        Me.scrlMapItemValue.Name = "scrlMapItemValue"
        Me.scrlMapItemValue.Size = New System.Drawing.Size(149, 18)
        Me.scrlMapItemValue.TabIndex = 4
        '
        'scrlMapItem
        '
        Me.scrlMapItem.Location = New System.Drawing.Point(9, 31)
        Me.scrlMapItem.Name = "scrlMapItem"
        Me.scrlMapItem.Size = New System.Drawing.Size(149, 18)
        Me.scrlMapItem.TabIndex = 3
        '
        'lblMapItem
        '
        Me.lblMapItem.AutoSize = True
        Me.lblMapItem.Location = New System.Drawing.Point(6, 16)
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
        Me.fraTrap.ForeColor = System.Drawing.Color.LightGray
        Me.fraTrap.Location = New System.Drawing.Point(3, 133)
        Me.fraTrap.Name = "fraTrap"
        Me.fraTrap.Size = New System.Drawing.Size(207, 113)
        Me.fraTrap.TabIndex = 26
        Me.fraTrap.TabStop = False
        Me.fraTrap.Text = "Trap"
        '
        'btnTrap
        '
        Me.btnTrap.ForeColor = System.Drawing.Color.Black
        Me.btnTrap.Location = New System.Drawing.Point(53, 79)
        Me.btnTrap.Name = "btnTrap"
        Me.btnTrap.Size = New System.Drawing.Size(90, 28)
        Me.btnTrap.TabIndex = 42
        Me.btnTrap.Text = "Accept"
        Me.btnTrap.UseVisualStyleBackColor = True
        '
        'scrlTrap
        '
        Me.scrlTrap.Location = New System.Drawing.Point(11, 32)
        Me.scrlTrap.Name = "scrlTrap"
        Me.scrlTrap.Size = New System.Drawing.Size(191, 17)
        Me.scrlTrap.TabIndex = 41
        '
        'lblTrap
        '
        Me.lblTrap.AutoSize = True
        Me.lblTrap.Location = New System.Drawing.Point(6, 15)
        Me.lblTrap.Name = "lblTrap"
        Me.lblTrap.Size = New System.Drawing.Size(55, 13)
        Me.lblTrap.TabIndex = 40
        Me.lblTrap.Text = "Amount: 0"
        '
        'scrlMapViewV
        '
        Me.scrlMapViewV.BackColor = System.Drawing.SystemColors.ControlDark
        Me.scrlMapViewV.Dock = System.Windows.Forms.DockStyle.Right
        Me.scrlMapViewV.Location = New System.Drawing.Point(741, 25)
        Me.scrlMapViewV.Name = "scrlMapViewV"
        Me.scrlMapViewV.Size = New System.Drawing.Size(16, 531)
        Me.scrlMapViewV.TabIndex = 10
        Me.scrlMapViewV.Text = "DarkScrollBar1"
        '
        'scrlMapViewH
        '
        Me.scrlMapViewH.BackColor = System.Drawing.SystemColors.ControlDark
        Me.scrlMapViewH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.scrlMapViewH.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.scrlMapViewH.Location = New System.Drawing.Point(1, 556)
        Me.scrlMapViewH.Name = "scrlMapViewH"
        Me.scrlMapViewH.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlMapViewH.Size = New System.Drawing.Size(756, 16)
        Me.scrlMapViewH.TabIndex = 3
        '
        'picScreen
        '
        Me.picScreen.BackColor = System.Drawing.Color.Black
        Me.picScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picScreen.Location = New System.Drawing.Point(1, 25)
        Me.picScreen.Name = "picScreen"
        Me.picScreen.Size = New System.Drawing.Size(598, 413)
        Me.picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picScreen.TabIndex = 2
        Me.picScreen.TabStop = False
        '
        'FrmEditor_MapEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1292, 626)
        Me.Controls.Add(Me.pnlBack2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.DarkSectionPanel2)
        Me.Controls.Add(Me.DarkSectionPanel1)
        Me.Controls.Add(Me.ToolStripContainer2)
        Me.Controls.Add(Me.DarkDockPanel1)
        Me.Name = "FrmEditor_MapEditor"
        Me.Text = "Map Editor"
        Me.ToolStripContainer2.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer2.ResumeLayout(False)
        Me.ToolStripContainer2.PerformLayout()
        Me.ssInfo.ResumeLayout(False)
        Me.ssInfo.PerformLayout()
        Me.DarkSectionPanel1.ResumeLayout(False)
        Me.pnlTiles.ResumeLayout(False)
        Me.pnlTiles.PerformLayout()
        Me.pnlBack.ResumeLayout(False)
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAttribute.ResumeLayout(False)
        Me.pnlAttribute.PerformLayout()
        Me.pnlNpc.ResumeLayout(False)
        Me.pnlDirBlock.ResumeLayout(False)
        Me.pnlDirBlock.PerformLayout()
        Me.pnlEvents.ResumeLayout(False)
        Me.pnlEvents.PerformLayout()
        Me.DarkSectionPanel2.ResumeLayout(False)
        Me.DarkSectionPanel2.PerformLayout()
        Me.pnlMoreOptions.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraMapLinks.ResumeLayout(False)
        Me.fraMapLinks.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.pnlBack2.ResumeLayout(False)
        Me.pnlAttributes.ResumeLayout(False)
        Me.fraMapWarp.ResumeLayout(False)
        Me.fraMapWarp.PerformLayout()
        Me.fraBuyHouse.ResumeLayout(False)
        Me.fraBuyHouse.PerformLayout()
        Me.fraKeyOpen.ResumeLayout(False)
        Me.fraKeyOpen.PerformLayout()
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
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DarkDockPanel1 As DarkUI.Docking.DarkDockPanel
    Friend WithEvents ToolStripContainer2 As ToolStripContainer
    Friend WithEvents DarkSectionPanel1 As DarkUI.Controls.DarkSectionPanel
    Friend WithEvents DarkSectionPanel2 As DarkUI.Controls.DarkSectionPanel
    Friend WithEvents ToolStrip As DarkUI.Controls.DarkToolStrip
    Friend WithEvents tsbSave As ToolStripButton
    Friend WithEvents tsbDiscard As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbMapGrid As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbFill As ToolStripButton
    Friend WithEvents tsbClear As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents pnlBack2 As DarkUI.Controls.DarkSectionPanel
    Friend WithEvents picScreen As PictureBox
    Friend WithEvents ssInfo As DarkUI.Controls.DarkStatusStrip
    Friend WithEvents tslCurMap As ToolStripStatusLabel
    Friend WithEvents cmbMapList As ToolStripComboBox
    Friend WithEvents btnAttributes As DarkUI.Controls.DarkButton
    Friend WithEvents btnTiles As DarkUI.Controls.DarkButton
    Friend WithEvents scrlMapViewH As DarkUI.Controls.DarkScrollBar
    Friend WithEvents btnNpc As DarkUI.Controls.DarkButton
    Friend WithEvents btnDirBlock As DarkUI.Controls.DarkButton
    Friend WithEvents btnEvents As DarkUI.Controls.DarkButton
    Friend WithEvents scrlMapViewV As DarkUI.Controls.DarkScrollBar
    Friend WithEvents pnlBack As Panel
    Public WithEvents picBackSelect As PictureBox
    Friend WithEvents scrlPictureY As DarkUI.Controls.DarkScrollBar
    Friend WithEvents scrlPictureX As DarkUI.Controls.DarkScrollBar
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbTileSets As ComboBox
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbLayers As ComboBox
    Friend WithEvents pnlTiles As Panel
    Friend WithEvents cmbAutoTile As ComboBox
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents pnlEvents As Panel
    Friend WithEvents pnlDirBlock As Panel
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents pnlNpc As Panel
    Friend WithEvents lstMapNpc As ListBox
    Friend WithEvents cmbNpcList As ComboBox
    Friend WithEvents pnlAttribute As Panel
    Friend WithEvents optBlocked As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optNpcAvoid As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optItem As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optWarp As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optHouse As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optShop As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optNpcSpawn As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optBank As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optCraft As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTrap As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optHeal As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optKeyOpen As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optKey As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optDoor As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optResource As DarkUI.Controls.DarkRadioButton
    Friend WithEvents tslCurXY As ToolStripStatusLabel
    Friend WithEvents btnClearAttribute As DarkUI.Controls.DarkButton
    Friend WithEvents pnlAttributes As Panel
    Friend WithEvents fraMapWarp As GroupBox
    Friend WithEvents btnMapWarp As Button
    Friend WithEvents scrlMapWarpY As HScrollBar
    Friend WithEvents scrlMapWarpX As HScrollBar
    Friend WithEvents scrlMapWarpMap As HScrollBar
    Friend WithEvents lblMapWarpY As Label
    Friend WithEvents lblMapWarpX As Label
    Friend WithEvents lblMapWarpMap As Label
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
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents chkInstance As DarkUI.Controls.DarkCheckBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraMapLinks As GroupBox
    Friend WithEvents cmbMoral As ComboBox
    Friend WithEvents lblMap As DarkUI.Controls.DarkLabel
    Friend WithEvents txtRight As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtLeft As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtDown As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtUp As DarkUI.Controls.DarkTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtSpawnY As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtSpawnX As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtSpawnMap As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtMaxY As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtMaxX As DarkUI.Controls.DarkTextBox
    Friend WithEvents btnSetSize As DarkUI.Controls.DarkButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnPreview As DarkUI.Controls.DarkButton
    Friend WithEvents lstMusic As ListBox
    Friend WithEvents pnlMoreOptions As Panel
    Friend WithEvents btnMoreOptions As DarkUI.Controls.DarkButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cmbWeather As ComboBox
    Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblIntensity As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlFog As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblFogIndex As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlIntensity As DarkUI.Controls.DarkScrollBar
    Friend WithEvents scrlFogSpeed As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblFogSpeed As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlFogAlpha As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblFogAlpha As DarkUI.Controls.DarkLabel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chkUseTint As CheckBox
    Friend WithEvents scrlMapAlpha As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblMapAlpha As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlMapBlue As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblMapBlue As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlMapGreen As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblMapGreen As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlMapRed As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblMapRed As DarkUI.Controls.DarkLabel
    Friend WithEvents tsCurFps As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbScreenShot As ToolStripButton
End Class
