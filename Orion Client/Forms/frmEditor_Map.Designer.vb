<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor_Map
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
        Me.scrlPictureX = New System.Windows.Forms.HScrollBar()
        Me.scrlPictureY = New System.Windows.Forms.VScrollBar()
        Me.fraTileSet = New System.Windows.Forms.GroupBox()
        Me.scrlTileSet = New System.Windows.Forms.HScrollBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optEvent = New System.Windows.Forms.RadioButton()
        Me.optBlocks = New System.Windows.Forms.RadioButton()
        Me.fraLayers = New System.Windows.Forms.GroupBox()
        Me.scrlAutotile = New System.Windows.Forms.HScrollBar()
        Me.lblAutotile = New System.Windows.Forms.Label()
        Me.btnFill = New System.Windows.Forms.Button()
        Me.btnClearLayer = New System.Windows.Forms.Button()
        Me.optFringe2 = New System.Windows.Forms.RadioButton()
        Me.optFringe = New System.Windows.Forms.RadioButton()
        Me.optMask2 = New System.Windows.Forms.RadioButton()
        Me.optMask = New System.Windows.Forms.RadioButton()
        Me.optGround = New System.Windows.Forms.RadioButton()
        Me.optHouse = New System.Windows.Forms.RadioButton()
        Me.btnClearAttribute = New System.Windows.Forms.Button()
        Me.optTrap = New System.Windows.Forms.RadioButton()
        Me.optHeal = New System.Windows.Forms.RadioButton()
        Me.optBank = New System.Windows.Forms.RadioButton()
        Me.optShop = New System.Windows.Forms.RadioButton()
        Me.optNPCSpawn = New System.Windows.Forms.RadioButton()
        Me.optDoor = New System.Windows.Forms.RadioButton()
        Me.optResource = New System.Windows.Forms.RadioButton()
        Me.optKeyOpen = New System.Windows.Forms.RadioButton()
        Me.optKey = New System.Windows.Forms.RadioButton()
        Me.optNPCAvoid = New System.Windows.Forms.RadioButton()
        Me.optItem = New System.Windows.Forms.RadioButton()
        Me.optWarp = New System.Windows.Forms.RadioButton()
        Me.optBlocked = New System.Windows.Forms.RadioButton()
        Me.pnlBack = New System.Windows.Forms.Panel()
        Me.picBackSelect = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabpages = New System.Windows.Forms.TabControl()
        Me.tpTiles = New System.Windows.Forms.TabPage()
        Me.tpAttributes = New System.Windows.Forms.TabPage()
        Me.tpNpcs = New System.Windows.Forms.TabPage()
        Me.fraNpcs = New System.Windows.Forms.GroupBox()
        Me.cmbNpcList = New System.Windows.Forms.ComboBox()
        Me.lstMapNpc = New System.Windows.Forms.ListBox()
        Me.ComboBox23 = New System.Windows.Forms.ComboBox()
        Me.tpSettings = New System.Windows.Forms.TabPage()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.fraMapSettings = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbMoral = New System.Windows.Forms.ComboBox()
        Me.fraMapLinks = New System.Windows.Forms.GroupBox()
        Me.txtDown = New System.Windows.Forms.TextBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.txtUp = New System.Windows.Forms.TextBox()
        Me.fraBootSettings = New System.Windows.Forms.GroupBox()
        Me.txtBootMap = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBootY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBootX = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fraMaxSizes = New System.Windows.Forms.GroupBox()
        Me.txtMaxY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxX = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstMusic = New System.Windows.Forms.ListBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fraTileSet.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraLayers.SuspendLayout()
        Me.pnlBack.SuspendLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.SuspendLayout()
        Me.tabpages.SuspendLayout()
        Me.tpTiles.SuspendLayout()
        Me.tpAttributes.SuspendLayout()
        Me.tpNpcs.SuspendLayout()
        Me.fraNpcs.SuspendLayout()
        Me.tpSettings.SuspendLayout()
        Me.fraMapSettings.SuspendLayout()
        Me.fraMapLinks.SuspendLayout()
        Me.fraBootSettings.SuspendLayout()
        Me.fraMaxSizes.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'scrlPictureX
        '
        Me.scrlPictureX.LargeChange = 1
        Me.scrlPictureX.Location = New System.Drawing.Point(3, 363)
        Me.scrlPictureX.Name = "scrlPictureX"
        Me.scrlPictureX.Size = New System.Drawing.Size(352, 16)
        Me.scrlPictureX.TabIndex = 1
        '
        'scrlPictureY
        '
        Me.scrlPictureY.LargeChange = 1
        Me.scrlPictureY.Location = New System.Drawing.Point(358, 8)
        Me.scrlPictureY.Name = "scrlPictureY"
        Me.scrlPictureY.Size = New System.Drawing.Size(16, 352)
        Me.scrlPictureY.TabIndex = 2
        '
        'fraTileSet
        '
        Me.fraTileSet.Controls.Add(Me.scrlTileSet)
        Me.fraTileSet.Location = New System.Drawing.Point(3, 396)
        Me.fraTileSet.Name = "fraTileSet"
        Me.fraTileSet.Size = New System.Drawing.Size(352, 46)
        Me.fraTileSet.TabIndex = 3
        Me.fraTileSet.TabStop = False
        Me.fraTileSet.Text = "Tileset: 0"
        '
        'scrlTileSet
        '
        Me.scrlTileSet.LargeChange = 1
        Me.scrlTileSet.Location = New System.Drawing.Point(18, 16)
        Me.scrlTileSet.Name = "scrlTileSet"
        Me.scrlTileSet.Size = New System.Drawing.Size(308, 18)
        Me.scrlTileSet.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optEvent)
        Me.GroupBox1.Controls.Add(Me.optBlocks)
        Me.GroupBox1.Location = New System.Drawing.Point(377, 329)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 113)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type"
        '
        'optEvent
        '
        Me.optEvent.AutoSize = True
        Me.optEvent.Location = New System.Drawing.Point(6, 87)
        Me.optEvent.Name = "optEvent"
        Me.optEvent.Size = New System.Drawing.Size(58, 17)
        Me.optEvent.TabIndex = 3
        Me.optEvent.TabStop = True
        Me.optEvent.Text = "Events"
        Me.optEvent.UseVisualStyleBackColor = True
        '
        'optBlocks
        '
        Me.optBlocks.AutoSize = True
        Me.optBlocks.Location = New System.Drawing.Point(6, 65)
        Me.optBlocks.Name = "optBlocks"
        Me.optBlocks.Size = New System.Drawing.Size(73, 17)
        Me.optBlocks.TabIndex = 2
        Me.optBlocks.TabStop = True
        Me.optBlocks.Text = "Dir Blocks"
        Me.optBlocks.UseVisualStyleBackColor = True
        '
        'fraLayers
        '
        Me.fraLayers.Controls.Add(Me.scrlAutotile)
        Me.fraLayers.Controls.Add(Me.lblAutotile)
        Me.fraLayers.Controls.Add(Me.btnFill)
        Me.fraLayers.Controls.Add(Me.btnClearLayer)
        Me.fraLayers.Controls.Add(Me.optFringe2)
        Me.fraLayers.Controls.Add(Me.optFringe)
        Me.fraLayers.Controls.Add(Me.optMask2)
        Me.fraLayers.Controls.Add(Me.optMask)
        Me.fraLayers.Controls.Add(Me.optGround)
        Me.fraLayers.Location = New System.Drawing.Point(377, 8)
        Me.fraLayers.Name = "fraLayers"
        Me.fraLayers.Size = New System.Drawing.Size(103, 315)
        Me.fraLayers.TabIndex = 8
        Me.fraLayers.TabStop = False
        Me.fraLayers.Text = "Layers"
        '
        'scrlAutotile
        '
        Me.scrlAutotile.LargeChange = 1
        Me.scrlAutotile.Location = New System.Drawing.Point(12, 197)
        Me.scrlAutotile.Maximum = 5
        Me.scrlAutotile.Name = "scrlAutotile"
        Me.scrlAutotile.Size = New System.Drawing.Size(85, 18)
        Me.scrlAutotile.TabIndex = 10
        '
        'lblAutotile
        '
        Me.lblAutotile.AutoSize = True
        Me.lblAutotile.Location = New System.Drawing.Point(35, 181)
        Me.lblAutotile.Name = "lblAutotile"
        Me.lblAutotile.Size = New System.Drawing.Size(40, 13)
        Me.lblAutotile.TabIndex = 9
        Me.lblAutotile.Text = "Normal"
        '
        'btnFill
        '
        Me.btnFill.Location = New System.Drawing.Point(6, 273)
        Me.btnFill.Name = "btnFill"
        Me.btnFill.Size = New System.Drawing.Size(91, 25)
        Me.btnFill.TabIndex = 8
        Me.btnFill.Text = "Fill"
        Me.btnFill.UseVisualStyleBackColor = True
        '
        'btnClearLayer
        '
        Me.btnClearLayer.Location = New System.Drawing.Point(6, 244)
        Me.btnClearLayer.Name = "btnClearLayer"
        Me.btnClearLayer.Size = New System.Drawing.Size(91, 25)
        Me.btnClearLayer.TabIndex = 5
        Me.btnClearLayer.Text = "Clear"
        Me.btnClearLayer.UseVisualStyleBackColor = True
        '
        'optFringe2
        '
        Me.optFringe2.AutoSize = True
        Me.optFringe2.Location = New System.Drawing.Point(6, 111)
        Me.optFringe2.Name = "optFringe2"
        Me.optFringe2.Size = New System.Drawing.Size(63, 17)
        Me.optFringe2.TabIndex = 4
        Me.optFringe2.Text = "Fringe 2"
        Me.optFringe2.UseVisualStyleBackColor = True
        '
        'optFringe
        '
        Me.optFringe.AutoSize = True
        Me.optFringe.Location = New System.Drawing.Point(6, 88)
        Me.optFringe.Name = "optFringe"
        Me.optFringe.Size = New System.Drawing.Size(54, 17)
        Me.optFringe.TabIndex = 3
        Me.optFringe.Text = "Fringe"
        Me.optFringe.UseVisualStyleBackColor = True
        '
        'optMask2
        '
        Me.optMask2.AutoSize = True
        Me.optMask2.Location = New System.Drawing.Point(6, 65)
        Me.optMask2.Name = "optMask2"
        Me.optMask2.Size = New System.Drawing.Size(60, 17)
        Me.optMask2.TabIndex = 2
        Me.optMask2.Text = "Mask 2"
        Me.optMask2.UseVisualStyleBackColor = True
        '
        'optMask
        '
        Me.optMask.AutoSize = True
        Me.optMask.Location = New System.Drawing.Point(6, 42)
        Me.optMask.Name = "optMask"
        Me.optMask.Size = New System.Drawing.Size(51, 17)
        Me.optMask.TabIndex = 1
        Me.optMask.Text = "Mask"
        Me.optMask.UseVisualStyleBackColor = True
        '
        'optGround
        '
        Me.optGround.AutoSize = True
        Me.optGround.Checked = True
        Me.optGround.Location = New System.Drawing.Point(6, 19)
        Me.optGround.Name = "optGround"
        Me.optGround.Size = New System.Drawing.Size(60, 17)
        Me.optGround.TabIndex = 0
        Me.optGround.TabStop = True
        Me.optGround.Text = "Ground"
        Me.optGround.UseVisualStyleBackColor = True
        '
        'optHouse
        '
        Me.optHouse.AutoSize = True
        Me.optHouse.Location = New System.Drawing.Point(320, 49)
        Me.optHouse.Name = "optHouse"
        Me.optHouse.Size = New System.Drawing.Size(77, 17)
        Me.optHouse.TabIndex = 15
        Me.optHouse.TabStop = True
        Me.optHouse.Text = "Buy House"
        Me.optHouse.UseVisualStyleBackColor = True
        '
        'btnClearAttribute
        '
        Me.btnClearAttribute.Location = New System.Drawing.Point(320, 437)
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
        'optBank
        '
        Me.optBank.AutoSize = True
        Me.optBank.Location = New System.Drawing.Point(409, 49)
        Me.optBank.Name = "optBank"
        Me.optBank.Size = New System.Drawing.Size(50, 17)
        Me.optBank.TabIndex = 10
        Me.optBank.TabStop = True
        Me.optBank.Text = "Bank"
        Me.optBank.UseVisualStyleBackColor = True
        '
        'optShop
        '
        Me.optShop.AutoSize = True
        Me.optShop.Location = New System.Drawing.Point(409, 14)
        Me.optShop.Name = "optShop"
        Me.optShop.Size = New System.Drawing.Size(50, 17)
        Me.optShop.TabIndex = 9
        Me.optShop.TabStop = True
        Me.optShop.Text = "Shop"
        Me.optShop.UseVisualStyleBackColor = True
        '
        'optNPCSpawn
        '
        Me.optNPCSpawn.AutoSize = True
        Me.optNPCSpawn.Location = New System.Drawing.Point(320, 14)
        Me.optNPCSpawn.Name = "optNPCSpawn"
        Me.optNPCSpawn.Size = New System.Drawing.Size(83, 17)
        Me.optNPCSpawn.TabIndex = 8
        Me.optNPCSpawn.TabStop = True
        Me.optNPCSpawn.Text = "NPC Spawn"
        Me.optNPCSpawn.UseVisualStyleBackColor = True
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
        'pnlBack
        '
        Me.pnlBack.Controls.Add(Me.picBackSelect)
        Me.pnlBack.Location = New System.Drawing.Point(6, 8)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(352, 352)
        Me.pnlBack.TabIndex = 9
        '
        'picBackSelect
        '
        Me.picBackSelect.BackColor = System.Drawing.Color.Black
        Me.picBackSelect.Location = New System.Drawing.Point(0, 0)
        Me.picBackSelect.Name = "picBackSelect"
        Me.picBackSelect.Size = New System.Drawing.Size(352, 352)
        Me.picBackSelect.TabIndex = 1
        Me.picBackSelect.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 380)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Drag Mouse to Select Multiple Tiles"
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
        Me.pnlAttributes.Location = New System.Drawing.Point(509, 28)
        Me.pnlAttributes.Name = "pnlAttributes"
        Me.pnlAttributes.Size = New System.Drawing.Size(482, 491)
        Me.pnlAttributes.TabIndex = 12
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
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbDiscard, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1210, 25)
        Me.ToolStrip.TabIndex = 13
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.Image = Global.OrionClient.My.Resources.Resources.Save
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(51, 22)
        Me.tsbSave.Text = "Save"
        '
        'tsbDiscard
        '
        Me.tsbDiscard.Image = Global.OrionClient.My.Resources.Resources.Discard
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
        'tabpages
        '
        Me.tabpages.Controls.Add(Me.tpTiles)
        Me.tabpages.Controls.Add(Me.tpAttributes)
        Me.tabpages.Controls.Add(Me.tpNpcs)
        Me.tabpages.Controls.Add(Me.tpSettings)
        Me.tabpages.Location = New System.Drawing.Point(4, 28)
        Me.tabpages.Name = "tabpages"
        Me.tabpages.SelectedIndex = 0
        Me.tabpages.Size = New System.Drawing.Size(499, 494)
        Me.tabpages.TabIndex = 14
        '
        'tpTiles
        '
        Me.tpTiles.Controls.Add(Me.pnlBack)
        Me.tpTiles.Controls.Add(Me.fraLayers)
        Me.tpTiles.Controls.Add(Me.Label1)
        Me.tpTiles.Controls.Add(Me.scrlPictureX)
        Me.tpTiles.Controls.Add(Me.scrlPictureY)
        Me.tpTiles.Controls.Add(Me.fraTileSet)
        Me.tpTiles.Controls.Add(Me.GroupBox1)
        Me.tpTiles.Location = New System.Drawing.Point(4, 22)
        Me.tpTiles.Name = "tpTiles"
        Me.tpTiles.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTiles.Size = New System.Drawing.Size(491, 468)
        Me.tpTiles.TabIndex = 0
        Me.tpTiles.Text = "Tiles"
        Me.tpTiles.UseVisualStyleBackColor = True
        '
        'tpAttributes
        '
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
        Me.tpAttributes.Size = New System.Drawing.Size(491, 468)
        Me.tpAttributes.TabIndex = 3
        Me.tpAttributes.Text = "Attributes"
        Me.tpAttributes.UseVisualStyleBackColor = True
        '
        'tpNpcs
        '
        Me.tpNpcs.Controls.Add(Me.fraNpcs)
        Me.tpNpcs.Location = New System.Drawing.Point(4, 22)
        Me.tpNpcs.Name = "tpNpcs"
        Me.tpNpcs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNpcs.Size = New System.Drawing.Size(491, 468)
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
        Me.fraNpcs.Size = New System.Drawing.Size(479, 426)
        Me.fraNpcs.TabIndex = 11
        Me.fraNpcs.TabStop = False
        Me.fraNpcs.Text = "NPCs"
        '
        'cmbNpcList
        '
        Me.cmbNpcList.FormattingEnabled = True
        Me.cmbNpcList.Location = New System.Drawing.Point(260, 19)
        Me.cmbNpcList.Name = "cmbNpcList"
        Me.cmbNpcList.Size = New System.Drawing.Size(213, 21)
        Me.cmbNpcList.TabIndex = 70
        '
        'lstMapNpc
        '
        Me.lstMapNpc.FormattingEnabled = True
        Me.lstMapNpc.Location = New System.Drawing.Point(6, 19)
        Me.lstMapNpc.Name = "lstMapNpc"
        Me.lstMapNpc.Size = New System.Drawing.Size(181, 394)
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
        'tpSettings
        '
        Me.tpSettings.Controls.Add(Me.btnSaveSettings)
        Me.tpSettings.Controls.Add(Me.fraMapSettings)
        Me.tpSettings.Controls.Add(Me.fraMapLinks)
        Me.tpSettings.Controls.Add(Me.fraBootSettings)
        Me.tpSettings.Controls.Add(Me.fraMaxSizes)
        Me.tpSettings.Controls.Add(Me.GroupBox2)
        Me.tpSettings.Controls.Add(Me.txtName)
        Me.tpSettings.Controls.Add(Me.Label6)
        Me.tpSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpSettings.Name = "tpSettings"
        Me.tpSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSettings.Size = New System.Drawing.Size(491, 468)
        Me.tpSettings.TabIndex = 2
        Me.tpSettings.Text = "Settings"
        Me.tpSettings.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(366, 435)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(108, 23)
        Me.btnSaveSettings.TabIndex = 16
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'fraMapSettings
        '
        Me.fraMapSettings.Controls.Add(Me.Label8)
        Me.fraMapSettings.Controls.Add(Me.cmbMoral)
        Me.fraMapSettings.Location = New System.Drawing.Point(6, 32)
        Me.fraMapSettings.Name = "fraMapSettings"
        Me.fraMapSettings.Size = New System.Drawing.Size(304, 39)
        Me.fraMapSettings.TabIndex = 15
        Me.fraMapSettings.TabStop = False
        Me.fraMapSettings.Text = "Map Settings"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Moral:"
        '
        'cmbMoral
        '
        Me.cmbMoral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoral.FormattingEnabled = True
        Me.cmbMoral.Items.AddRange(New Object() {"None", "Safe Zone"})
        Me.cmbMoral.Location = New System.Drawing.Point(77, 12)
        Me.cmbMoral.Name = "cmbMoral"
        Me.cmbMoral.Size = New System.Drawing.Size(221, 21)
        Me.cmbMoral.TabIndex = 37
        '
        'fraMapLinks
        '
        Me.fraMapLinks.Controls.Add(Me.txtDown)
        Me.fraMapLinks.Controls.Add(Me.txtLeft)
        Me.fraMapLinks.Controls.Add(Me.lblMap)
        Me.fraMapLinks.Controls.Add(Me.txtRight)
        Me.fraMapLinks.Controls.Add(Me.txtUp)
        Me.fraMapLinks.Location = New System.Drawing.Point(6, 79)
        Me.fraMapLinks.Name = "fraMapLinks"
        Me.fraMapLinks.Size = New System.Drawing.Size(149, 84)
        Me.fraMapLinks.TabIndex = 14
        Me.fraMapLinks.TabStop = False
        Me.fraMapLinks.Text = "Map Links"
        '
        'txtDown
        '
        Me.txtDown.Location = New System.Drawing.Point(43, 58)
        Me.txtDown.Name = "txtDown"
        Me.txtDown.Size = New System.Drawing.Size(50, 20)
        Me.txtDown.TabIndex = 6
        Me.txtDown.Text = "0"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(6, 46)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(43, 20)
        Me.txtLeft.TabIndex = 5
        Me.txtLeft.Text = "0"
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(6, 16)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(77, 13)
        Me.lblMap.TabIndex = 4
        Me.lblMap.Text = "Current Map: 0"
        '
        'txtRight
        '
        Me.txtRight.Location = New System.Drawing.Point(93, 46)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(50, 20)
        Me.txtRight.TabIndex = 3
        Me.txtRight.Text = "0"
        '
        'txtUp
        '
        Me.txtUp.Location = New System.Drawing.Point(43, 32)
        Me.txtUp.Name = "txtUp"
        Me.txtUp.Size = New System.Drawing.Size(50, 20)
        Me.txtUp.TabIndex = 1
        Me.txtUp.Text = "0"
        '
        'fraBootSettings
        '
        Me.fraBootSettings.Controls.Add(Me.txtBootMap)
        Me.fraBootSettings.Controls.Add(Me.Label5)
        Me.fraBootSettings.Controls.Add(Me.txtBootY)
        Me.fraBootSettings.Controls.Add(Me.Label3)
        Me.fraBootSettings.Controls.Add(Me.txtBootX)
        Me.fraBootSettings.Controls.Add(Me.Label4)
        Me.fraBootSettings.Location = New System.Drawing.Point(174, 79)
        Me.fraBootSettings.Name = "fraBootSettings"
        Me.fraBootSettings.Size = New System.Drawing.Size(149, 98)
        Me.fraBootSettings.TabIndex = 13
        Me.fraBootSettings.TabStop = False
        Me.fraBootSettings.Text = "Boot Settings"
        '
        'txtBootMap
        '
        Me.txtBootMap.Location = New System.Drawing.Point(89, 13)
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
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Boot Map:"
        '
        'txtBootY
        '
        Me.txtBootY.Location = New System.Drawing.Point(89, 72)
        Me.txtBootY.Name = "txtBootY"
        Me.txtBootY.Size = New System.Drawing.Size(50, 20)
        Me.txtBootY.TabIndex = 3
        Me.txtBootY.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Boot Y:"
        '
        'txtBootX
        '
        Me.txtBootX.Location = New System.Drawing.Point(89, 46)
        Me.txtBootX.Name = "txtBootX"
        Me.txtBootX.Size = New System.Drawing.Size(50, 20)
        Me.txtBootX.TabIndex = 1
        Me.txtBootX.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Boot X:"
        '
        'fraMaxSizes
        '
        Me.fraMaxSizes.Controls.Add(Me.txtMaxY)
        Me.fraMaxSizes.Controls.Add(Me.Label2)
        Me.fraMaxSizes.Controls.Add(Me.txtMaxX)
        Me.fraMaxSizes.Controls.Add(Me.Label7)
        Me.fraMaxSizes.Location = New System.Drawing.Point(6, 212)
        Me.fraMaxSizes.Name = "fraMaxSizes"
        Me.fraMaxSizes.Size = New System.Drawing.Size(149, 75)
        Me.fraMaxSizes.TabIndex = 12
        Me.fraMaxSizes.TabStop = False
        Me.fraMaxSizes.Text = "Map Sizes"
        '
        'txtMaxY
        '
        Me.txtMaxY.Location = New System.Drawing.Point(56, 42)
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.Size = New System.Drawing.Size(50, 20)
        Me.txtMaxY.TabIndex = 3
        Me.txtMaxY.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Max Y:"
        '
        'txtMaxX
        '
        Me.txtMaxX.Location = New System.Drawing.Point(56, 16)
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.Size = New System.Drawing.Size(50, 20)
        Me.txtMaxX.TabIndex = 1
        Me.txtMaxX.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Max X:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstMusic)
        Me.GroupBox2.Location = New System.Drawing.Point(174, 186)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 136)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Music"
        '
        'lstMusic
        '
        Me.lstMusic.FormattingEnabled = True
        Me.lstMusic.Location = New System.Drawing.Point(6, 19)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.ScrollAlwaysVisible = True
        Me.lstMusic.Size = New System.Drawing.Size(139, 108)
        Me.lstMusic.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(53, 6)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(432, 20)
        Me.txtName.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Name:"
        '
        'frmEditor_Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 527)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabpages)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.pnlAttributes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmEditor_Map"
        Me.Text = "Map Editor"
        Me.fraTileSet.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraLayers.ResumeLayout(False)
        Me.fraLayers.PerformLayout()
        Me.pnlBack.ResumeLayout(False)
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.tabpages.ResumeLayout(False)
        Me.tpTiles.ResumeLayout(False)
        Me.tpTiles.PerformLayout()
        Me.tpAttributes.ResumeLayout(False)
        Me.tpAttributes.PerformLayout()
        Me.tpNpcs.ResumeLayout(False)
        Me.fraNpcs.ResumeLayout(False)
        Me.tpSettings.ResumeLayout(False)
        Me.tpSettings.PerformLayout()
        Me.fraMapSettings.ResumeLayout(False)
        Me.fraMapSettings.PerformLayout()
        Me.fraMapLinks.ResumeLayout(False)
        Me.fraMapLinks.PerformLayout()
        Me.fraBootSettings.ResumeLayout(False)
        Me.fraBootSettings.PerformLayout()
        Me.fraMaxSizes.ResumeLayout(False)
        Me.fraMaxSizes.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents scrlPictureX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlPictureY As System.Windows.Forms.VScrollBar
    Friend WithEvents fraTileSet As System.Windows.Forms.GroupBox
    Friend WithEvents scrlTileSet As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optBlocks As System.Windows.Forms.RadioButton
    Friend WithEvents fraLayers As System.Windows.Forms.GroupBox
    Friend WithEvents optFringe2 As System.Windows.Forms.RadioButton
    Friend WithEvents optFringe As System.Windows.Forms.RadioButton
    Friend WithEvents optMask2 As System.Windows.Forms.RadioButton
    Friend WithEvents optMask As System.Windows.Forms.RadioButton
    Friend WithEvents optGround As System.Windows.Forms.RadioButton
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
    Friend WithEvents optTrap As System.Windows.Forms.RadioButton
    Friend WithEvents optHeal As System.Windows.Forms.RadioButton
    Friend WithEvents optBank As System.Windows.Forms.RadioButton
    Friend WithEvents optShop As System.Windows.Forms.RadioButton
    Friend WithEvents optNPCSpawn As System.Windows.Forms.RadioButton
    Friend WithEvents optDoor As System.Windows.Forms.RadioButton
    Friend WithEvents optResource As System.Windows.Forms.RadioButton
    Friend WithEvents optKeyOpen As System.Windows.Forms.RadioButton
    Friend WithEvents optKey As System.Windows.Forms.RadioButton
    Friend WithEvents optNPCAvoid As System.Windows.Forms.RadioButton
    Friend WithEvents optItem As System.Windows.Forms.RadioButton
    Friend WithEvents optWarp As System.Windows.Forms.RadioButton
    Friend WithEvents optBlocked As System.Windows.Forms.RadioButton
    Friend WithEvents btnClearLayer As System.Windows.Forms.Button
    Public WithEvents picBackSelect As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClearAttribute As System.Windows.Forms.Button
    Friend WithEvents btnFill As System.Windows.Forms.Button
    Friend WithEvents pnlAttributes As System.Windows.Forms.Panel
    Friend WithEvents fraMapWarp As System.Windows.Forms.GroupBox
    Friend WithEvents lblMapWarpY As System.Windows.Forms.Label
    Friend WithEvents lblMapWarpX As System.Windows.Forms.Label
    Friend WithEvents lblMapWarpMap As System.Windows.Forms.Label
    Friend WithEvents scrlMapWarpY As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapWarpX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapWarpMap As System.Windows.Forms.HScrollBar
    Friend WithEvents btnMapWarp As System.Windows.Forms.Button
    Friend WithEvents fraMapItem As System.Windows.Forms.GroupBox
    Friend WithEvents btnMapItem As System.Windows.Forms.Button
    Friend WithEvents scrlMapItemValue As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapItem As System.Windows.Forms.HScrollBar
    Friend WithEvents lblMapItem As System.Windows.Forms.Label
    Friend WithEvents picMapItem As System.Windows.Forms.PictureBox
    Friend WithEvents fraMapKey As System.Windows.Forms.GroupBox
    Friend WithEvents chkMapKey As System.Windows.Forms.CheckBox
    Friend WithEvents picMapKey As System.Windows.Forms.PictureBox
    Friend WithEvents btnMapKey As System.Windows.Forms.Button
    Friend WithEvents scrlMapKey As System.Windows.Forms.HScrollBar
    Friend WithEvents lblMapKey As System.Windows.Forms.Label
    Friend WithEvents fraKeyOpen As System.Windows.Forms.GroupBox
    Friend WithEvents btnMapKeyOpen As System.Windows.Forms.Button
    Friend WithEvents scrlKeyX As System.Windows.Forms.HScrollBar
    Friend WithEvents lblKeyX As System.Windows.Forms.Label
    Friend WithEvents scrlKeyY As System.Windows.Forms.HScrollBar
    Friend WithEvents lblKeyY As System.Windows.Forms.Label
    Friend WithEvents fraResource As System.Windows.Forms.GroupBox
    Friend WithEvents btnResourceOk As System.Windows.Forms.Button
    Friend WithEvents scrlResource As System.Windows.Forms.HScrollBar
    Friend WithEvents lblResource As System.Windows.Forms.Label
    Friend WithEvents fraNpcSpawn As System.Windows.Forms.GroupBox
    Friend WithEvents btnNpcSpawn As System.Windows.Forms.Button
    Friend WithEvents scrlNpcDir As System.Windows.Forms.HScrollBar
    Friend WithEvents lblNpcDir As System.Windows.Forms.Label
    Friend WithEvents lstNpc As System.Windows.Forms.ComboBox
    Friend WithEvents fraShop As System.Windows.Forms.GroupBox
    Friend WithEvents cmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents btnShop As System.Windows.Forms.Button
    Friend WithEvents fraHeal As System.Windows.Forms.GroupBox
    Friend WithEvents lblHeal As System.Windows.Forms.Label
    Friend WithEvents cmbHeal As System.Windows.Forms.ComboBox
    Friend WithEvents btnHeal As System.Windows.Forms.Button
    Friend WithEvents scrlHeal As System.Windows.Forms.HScrollBar
    Friend WithEvents fraTrap As System.Windows.Forms.GroupBox
    Friend WithEvents btnTrap As System.Windows.Forms.Button
    Friend WithEvents scrlTrap As System.Windows.Forms.HScrollBar
    Friend WithEvents lblTrap As System.Windows.Forms.Label
    Friend WithEvents scrlAutotile As Windows.Forms.HScrollBar
    Friend WithEvents lblAutotile As Windows.Forms.Label
    Friend WithEvents optHouse As Windows.Forms.RadioButton
    Friend WithEvents fraBuyHouse As Windows.Forms.GroupBox
    Friend WithEvents btnHouseTileOk As Windows.Forms.Button
    Friend WithEvents scrlBuyHouse As Windows.Forms.HScrollBar
    Friend WithEvents lblHouseName As Windows.Forms.Label
    Friend WithEvents optEvent As Windows.Forms.RadioButton
    Friend WithEvents ToolStrip As Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As Windows.Forms.ToolStripButton
    Friend WithEvents tsbDiscard As Windows.Forms.ToolStripButton
    Friend WithEvents tabpages As Windows.Forms.TabControl
    Friend WithEvents tpTiles As Windows.Forms.TabPage
    Friend WithEvents tpNpcs As Windows.Forms.TabPage
    Friend WithEvents tpSettings As Windows.Forms.TabPage
    Friend WithEvents fraNpcs As Windows.Forms.GroupBox
    Friend WithEvents ComboBox23 As Windows.Forms.ComboBox
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents fraMapLinks As Windows.Forms.GroupBox
    Friend WithEvents txtDown As Windows.Forms.TextBox
    Friend WithEvents txtLeft As Windows.Forms.TextBox
    Friend WithEvents lblMap As Windows.Forms.Label
    Friend WithEvents txtRight As Windows.Forms.TextBox
    Friend WithEvents txtUp As Windows.Forms.TextBox
    Friend WithEvents fraBootSettings As Windows.Forms.GroupBox
    Friend WithEvents txtBootMap As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtBootY As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtBootX As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents fraMaxSizes As Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtMaxX As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents lstMusic As Windows.Forms.ListBox
    Friend WithEvents fraMapSettings As Windows.Forms.GroupBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cmbMoral As Windows.Forms.ComboBox
    Friend WithEvents btnSaveSettings As Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbNpcList As Windows.Forms.ComboBox
    Friend WithEvents lstMapNpc As Windows.Forms.ListBox
    Friend WithEvents tpAttributes As Windows.Forms.TabPage
End Class
