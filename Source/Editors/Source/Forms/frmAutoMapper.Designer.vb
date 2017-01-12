<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutoMapper
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
        Me.pnlResources = New System.Windows.Forms.Panel()
        Me.btnSaveResource = New System.Windows.Forms.Button()
        Me.btnCloseResource = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtResource = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstResources = New System.Windows.Forms.ListBox()
        Me.pnlTileConfig = New System.Windows.Forms.Panel()
        Me.btnTileSetSave = New System.Windows.Forms.Button()
        Me.btmTileSetClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkBlocked = New System.Windows.Forms.CheckBox()
        Me.txtAutotile = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTileY = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTileX = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTileset = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbLayer = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbPrefab = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DarkMenu = New DarkUI.Controls.DarkMenuStrip()
        Me.ConfigurationsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TilesetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PathsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiversToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MountainsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverGrassToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourcesToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel3 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel4 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel7 = New DarkUI.Controls.DarkLabel()
        Me.txtMapStart = New DarkUI.Controls.DarkTextBox()
        Me.txtMapSize = New DarkUI.Controls.DarkTextBox()
        Me.txtMapX = New DarkUI.Controls.DarkTextBox()
        Me.txtMapY = New DarkUI.Controls.DarkTextBox()
        Me.txtSandBorder = New DarkUI.Controls.DarkTextBox()
        Me.txtDetail = New DarkUI.Controls.DarkTextBox()
        Me.txtResourceFreq = New DarkUI.Controls.DarkTextBox()
        Me.btnStart = New DarkUI.Controls.DarkButton()
        Me.pnlResources.SuspendLayout()
        Me.pnlTileConfig.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.DarkMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlResources
        '
        Me.pnlResources.Controls.Add(Me.btnSaveResource)
        Me.pnlResources.Controls.Add(Me.btnCloseResource)
        Me.pnlResources.Controls.Add(Me.btnUpdate)
        Me.pnlResources.Controls.Add(Me.btnRemove)
        Me.pnlResources.Controls.Add(Me.btnAdd)
        Me.pnlResources.Controls.Add(Me.txtResource)
        Me.pnlResources.Controls.Add(Me.Label8)
        Me.pnlResources.Controls.Add(Me.lstResources)
        Me.pnlResources.Location = New System.Drawing.Point(387, 28)
        Me.pnlResources.Name = "pnlResources"
        Me.pnlResources.Size = New System.Drawing.Size(380, 267)
        Me.pnlResources.TabIndex = 24
        Me.pnlResources.Visible = False
        '
        'btnSaveResource
        '
        Me.btnSaveResource.Location = New System.Drawing.Point(254, 243)
        Me.btnSaveResource.Name = "btnSaveResource"
        Me.btnSaveResource.Size = New System.Drawing.Size(122, 23)
        Me.btnSaveResource.TabIndex = 7
        Me.btnSaveResource.Text = "Save"
        Me.btnSaveResource.UseVisualStyleBackColor = True
        '
        'btnCloseResource
        '
        Me.btnCloseResource.Location = New System.Drawing.Point(3, 243)
        Me.btnCloseResource.Name = "btnCloseResource"
        Me.btnCloseResource.Size = New System.Drawing.Size(122, 23)
        Me.btnCloseResource.TabIndex = 6
        Me.btnCloseResource.Text = "Close"
        Me.btnCloseResource.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(254, 214)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(122, 23)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update Resource"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(254, 185)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(122, 23)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove Resource"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(254, 156)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(122, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add Resource"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtResource
        '
        Me.txtResource.Location = New System.Drawing.Point(109, 153)
        Me.txtResource.Name = "txtResource"
        Me.txtResource.Size = New System.Drawing.Size(100, 20)
        Me.txtResource.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Resource Number:"
        '
        'lstResources
        '
        Me.lstResources.FormattingEnabled = True
        Me.lstResources.Location = New System.Drawing.Point(3, 3)
        Me.lstResources.Name = "lstResources"
        Me.lstResources.Size = New System.Drawing.Size(373, 147)
        Me.lstResources.TabIndex = 0
        '
        'pnlTileConfig
        '
        Me.pnlTileConfig.Controls.Add(Me.btnTileSetSave)
        Me.pnlTileConfig.Controls.Add(Me.btmTileSetClose)
        Me.pnlTileConfig.Controls.Add(Me.GroupBox1)
        Me.pnlTileConfig.Controls.Add(Me.cmbLayer)
        Me.pnlTileConfig.Controls.Add(Me.Label10)
        Me.pnlTileConfig.Controls.Add(Me.cmbPrefab)
        Me.pnlTileConfig.Controls.Add(Me.Label9)
        Me.pnlTileConfig.Location = New System.Drawing.Point(773, 27)
        Me.pnlTileConfig.Name = "pnlTileConfig"
        Me.pnlTileConfig.Size = New System.Drawing.Size(380, 270)
        Me.pnlTileConfig.TabIndex = 25
        Me.pnlTileConfig.Visible = False
        '
        'btnTileSetSave
        '
        Me.btnTileSetSave.Location = New System.Drawing.Point(298, 241)
        Me.btnTileSetSave.Name = "btnTileSetSave"
        Me.btnTileSetSave.Size = New System.Drawing.Size(75, 23)
        Me.btnTileSetSave.TabIndex = 6
        Me.btnTileSetSave.Text = "Save"
        Me.btnTileSetSave.UseVisualStyleBackColor = True
        '
        'btmTileSetClose
        '
        Me.btmTileSetClose.Location = New System.Drawing.Point(7, 241)
        Me.btmTileSetClose.Name = "btmTileSetClose"
        Me.btmTileSetClose.Size = New System.Drawing.Size(75, 23)
        Me.btmTileSetClose.TabIndex = 5
        Me.btmTileSetClose.Text = "Close"
        Me.btmTileSetClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkBlocked)
        Me.GroupBox1.Controls.Add(Me.txtAutotile)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtTileY)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtTileX)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtTileset)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 169)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tile Settings"
        '
        'chkBlocked
        '
        Me.chkBlocked.AutoSize = True
        Me.chkBlocked.Location = New System.Drawing.Point(6, 132)
        Me.chkBlocked.Name = "chkBlocked"
        Me.chkBlocked.Size = New System.Drawing.Size(89, 17)
        Me.chkBlocked.TabIndex = 8
        Me.chkBlocked.Text = "Is it blocked?"
        Me.chkBlocked.UseVisualStyleBackColor = True
        '
        'txtAutotile
        '
        Me.txtAutotile.Location = New System.Drawing.Point(108, 97)
        Me.txtAutotile.Name = "txtAutotile"
        Me.txtAutotile.Size = New System.Drawing.Size(252, 20)
        Me.txtAutotile.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "AutoTile:"
        '
        'txtTileY
        '
        Me.txtTileY.Location = New System.Drawing.Point(108, 71)
        Me.txtTileY.Name = "txtTileY"
        Me.txtTileY.Size = New System.Drawing.Size(252, 20)
        Me.txtTileY.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "TileSet Y:"
        '
        'txtTileX
        '
        Me.txtTileX.Location = New System.Drawing.Point(108, 45)
        Me.txtTileX.Name = "txtTileX"
        Me.txtTileX.Size = New System.Drawing.Size(252, 20)
        Me.txtTileX.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "TileSet X:"
        '
        'txtTileset
        '
        Me.txtTileset.Location = New System.Drawing.Point(108, 19)
        Me.txtTileset.Name = "txtTileset"
        Me.txtTileset.Size = New System.Drawing.Size(252, 20)
        Me.txtTileset.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "TileSet Number:"
        '
        'cmbLayer
        '
        Me.cmbLayer.FormattingEnabled = True
        Me.cmbLayer.Items.AddRange(New Object() {"Ground", "Mask", "Mask 2", "Fringe", "Fringe 2"})
        Me.cmbLayer.Location = New System.Drawing.Point(115, 34)
        Me.cmbLayer.Name = "cmbLayer"
        Me.cmbLayer.Size = New System.Drawing.Size(252, 21)
        Me.cmbLayer.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Choose The Layer:"
        '
        'cmbPrefab
        '
        Me.cmbPrefab.FormattingEnabled = True
        Me.cmbPrefab.Items.AddRange(New Object() {"Water", "Sand", "Grass", "Passing", "Overgrass", "River", "Mountain"})
        Me.cmbPrefab.Location = New System.Drawing.Point(115, 7)
        Me.cmbPrefab.Name = "cmbPrefab"
        Me.cmbPrefab.Size = New System.Drawing.Size(252, 21)
        Me.cmbPrefab.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Choose The Prefab:"
        '
        'DarkMenu
        '
        Me.DarkMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationsToolStripMenuItem2, Me.GenerateToolStripMenuItem1})
        Me.DarkMenu.Location = New System.Drawing.Point(0, 0)
        Me.DarkMenu.Name = "DarkMenu"
        Me.DarkMenu.Padding = New System.Windows.Forms.Padding(3, 2, 0, 2)
        Me.DarkMenu.Size = New System.Drawing.Size(1295, 24)
        Me.DarkMenu.TabIndex = 27
        '
        'ConfigurationsToolStripMenuItem2
        '
        Me.ConfigurationsToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TilesetsToolStripMenuItem, Me.ResourcesToolStripMenuItem})
        Me.ConfigurationsToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ConfigurationsToolStripMenuItem2.Name = "ConfigurationsToolStripMenuItem2"
        Me.ConfigurationsToolStripMenuItem2.Size = New System.Drawing.Size(93, 20)
        Me.ConfigurationsToolStripMenuItem2.Text = "Configuration"
        '
        'TilesetsToolStripMenuItem
        '
        Me.TilesetsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TilesetsToolStripMenuItem.Name = "TilesetsToolStripMenuItem"
        Me.TilesetsToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.TilesetsToolStripMenuItem.Text = "Tilesets"
        '
        'ResourcesToolStripMenuItem
        '
        Me.ResourcesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ResourcesToolStripMenuItem.Name = "ResourcesToolStripMenuItem"
        Me.ResourcesToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ResourcesToolStripMenuItem.Text = "Resources"
        '
        'GenerateToolStripMenuItem1
        '
        Me.GenerateToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PathsToolStripMenuItem1, Me.RiversToolStripMenuItem1, Me.MountainsToolStripMenuItem1, Me.OverGrassToolStripMenuItem1, Me.ResourcesToolStripMenuItem3, Me.DetailsToolStripMenuItem1})
        Me.GenerateToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.GenerateToolStripMenuItem1.Name = "GenerateToolStripMenuItem1"
        Me.GenerateToolStripMenuItem1.Size = New System.Drawing.Size(66, 20)
        Me.GenerateToolStripMenuItem1.Text = "Generate"
        '
        'PathsToolStripMenuItem1
        '
        Me.PathsToolStripMenuItem1.Checked = True
        Me.PathsToolStripMenuItem1.CheckOnClick = True
        Me.PathsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PathsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.PathsToolStripMenuItem1.Name = "PathsToolStripMenuItem1"
        Me.PathsToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.PathsToolStripMenuItem1.Text = "Paths"
        '
        'RiversToolStripMenuItem1
        '
        Me.RiversToolStripMenuItem1.Checked = True
        Me.RiversToolStripMenuItem1.CheckOnClick = True
        Me.RiversToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RiversToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RiversToolStripMenuItem1.Name = "RiversToolStripMenuItem1"
        Me.RiversToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.RiversToolStripMenuItem1.Text = "Rivers"
        '
        'MountainsToolStripMenuItem1
        '
        Me.MountainsToolStripMenuItem1.Checked = True
        Me.MountainsToolStripMenuItem1.CheckOnClick = True
        Me.MountainsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MountainsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.MountainsToolStripMenuItem1.Name = "MountainsToolStripMenuItem1"
        Me.MountainsToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.MountainsToolStripMenuItem1.Text = "Mountains"
        '
        'OverGrassToolStripMenuItem1
        '
        Me.OverGrassToolStripMenuItem1.Checked = True
        Me.OverGrassToolStripMenuItem1.CheckOnClick = True
        Me.OverGrassToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OverGrassToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.OverGrassToolStripMenuItem1.Name = "OverGrassToolStripMenuItem1"
        Me.OverGrassToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.OverGrassToolStripMenuItem1.Text = "OverGrass"
        '
        'ResourcesToolStripMenuItem3
        '
        Me.ResourcesToolStripMenuItem3.Checked = True
        Me.ResourcesToolStripMenuItem3.CheckOnClick = True
        Me.ResourcesToolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ResourcesToolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ResourcesToolStripMenuItem3.Name = "ResourcesToolStripMenuItem3"
        Me.ResourcesToolStripMenuItem3.Size = New System.Drawing.Size(131, 22)
        Me.ResourcesToolStripMenuItem3.Text = "Resources"
        '
        'DetailsToolStripMenuItem1
        '
        Me.DetailsToolStripMenuItem1.Checked = True
        Me.DetailsToolStripMenuItem1.CheckOnClick = True
        Me.DetailsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DetailsToolStripMenuItem1.Name = "DetailsToolStripMenuItem1"
        Me.DetailsToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.DetailsToolStripMenuItem1.Text = "Details"
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(12, 31)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(56, 13)
        Me.DarkLabel1.TabIndex = 28
        Me.DarkLabel1.Text = "Start Map:"
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(12, 57)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(63, 13)
        Me.DarkLabel2.TabIndex = 29
        Me.DarkLabel2.Text = "Island Area:"
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(13, 83)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(63, 13)
        Me.DarkLabel3.TabIndex = 30
        Me.DarkLabel3.Text = "Max Size X:"
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(12, 109)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(64, 13)
        Me.DarkLabel4.TabIndex = 31
        Me.DarkLabel4.Text = "Map Size Y:"
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(13, 135)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(69, 13)
        Me.DarkLabel5.TabIndex = 32
        Me.DarkLabel5.Text = "Sand Border:"
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(13, 161)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(111, 13)
        Me.DarkLabel6.TabIndex = 33
        Me.DarkLabel6.Text = "Detail Frequency 1 of "
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(12, 187)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(127, 13)
        Me.DarkLabel7.TabIndex = 34
        Me.DarkLabel7.Text = "Resource Frequency 1 of"
        '
        'txtMapStart
        '
        Me.txtMapStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapStart.Location = New System.Drawing.Point(145, 28)
        Me.txtMapStart.Name = "txtMapStart"
        Me.txtMapStart.Size = New System.Drawing.Size(236, 20)
        Me.txtMapStart.TabIndex = 35
        Me.txtMapStart.Text = "1"
        '
        'txtMapSize
        '
        Me.txtMapSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapSize.Location = New System.Drawing.Point(145, 54)
        Me.txtMapSize.Name = "txtMapSize"
        Me.txtMapSize.Size = New System.Drawing.Size(236, 20)
        Me.txtMapSize.TabIndex = 36
        Me.txtMapSize.Text = "4"
        '
        'txtMapX
        '
        Me.txtMapX.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapX.Location = New System.Drawing.Point(145, 80)
        Me.txtMapX.Name = "txtMapX"
        Me.txtMapX.Size = New System.Drawing.Size(236, 20)
        Me.txtMapX.TabIndex = 37
        Me.txtMapX.Text = "50"
        '
        'txtMapY
        '
        Me.txtMapY.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtMapY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMapY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtMapY.Location = New System.Drawing.Point(145, 106)
        Me.txtMapY.Name = "txtMapY"
        Me.txtMapY.Size = New System.Drawing.Size(236, 20)
        Me.txtMapY.TabIndex = 38
        Me.txtMapY.Text = "50"
        '
        'txtSandBorder
        '
        Me.txtSandBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtSandBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSandBorder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtSandBorder.Location = New System.Drawing.Point(145, 132)
        Me.txtSandBorder.Name = "txtSandBorder"
        Me.txtSandBorder.Size = New System.Drawing.Size(236, 20)
        Me.txtSandBorder.TabIndex = 39
        Me.txtSandBorder.Text = "4"
        '
        'txtDetail
        '
        Me.txtDetail.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDetail.Location = New System.Drawing.Point(145, 158)
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.Size = New System.Drawing.Size(236, 20)
        Me.txtDetail.TabIndex = 40
        Me.txtDetail.Text = "10"
        '
        'txtResourceFreq
        '
        Me.txtResourceFreq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtResourceFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResourceFreq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtResourceFreq.Location = New System.Drawing.Point(145, 184)
        Me.txtResourceFreq.Name = "txtResourceFreq"
        Me.txtResourceFreq.Size = New System.Drawing.Size(236, 20)
        Me.txtResourceFreq.TabIndex = 41
        Me.txtResourceFreq.Text = "20"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(16, 216)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Padding = New System.Windows.Forms.Padding(5)
        Me.btnStart.Size = New System.Drawing.Size(365, 23)
        Me.btnStart.TabIndex = 42
        Me.btnStart.Text = "Create The World"
        '
        'FrmAutoMapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1295, 411)
        Me.Controls.Add(Me.pnlResources)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtResourceFreq)
        Me.Controls.Add(Me.txtDetail)
        Me.Controls.Add(Me.txtSandBorder)
        Me.Controls.Add(Me.txtMapY)
        Me.Controls.Add(Me.txtMapX)
        Me.Controls.Add(Me.txtMapSize)
        Me.Controls.Add(Me.txtMapStart)
        Me.Controls.Add(Me.DarkLabel7)
        Me.Controls.Add(Me.DarkLabel6)
        Me.Controls.Add(Me.DarkLabel5)
        Me.Controls.Add(Me.DarkLabel4)
        Me.Controls.Add(Me.DarkLabel3)
        Me.Controls.Add(Me.DarkLabel2)
        Me.Controls.Add(Me.DarkLabel1)
        Me.Controls.Add(Me.pnlTileConfig)
        Me.Controls.Add(Me.DarkMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmAutoMapper"
        Me.Text = "Auto Mapper"
        Me.pnlResources.ResumeLayout(False)
        Me.pnlResources.PerformLayout()
        Me.pnlTileConfig.ResumeLayout(False)
        Me.pnlTileConfig.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.DarkMenu.ResumeLayout(False)
        Me.DarkMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlResources As Panel
    Friend WithEvents btnSaveResource As Button
    Friend WithEvents btnCloseResource As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtResource As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lstResources As ListBox
    Friend WithEvents pnlTileConfig As Panel
    Friend WithEvents cmbLayer As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbPrefab As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtTileY As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTileX As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTileset As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnTileSetSave As Button
    Friend WithEvents btmTileSetClose As Button
    Friend WithEvents chkBlocked As CheckBox
    Friend WithEvents txtAutotile As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents DarkMenu As DarkUI.Controls.DarkMenuStrip
    Friend WithEvents ConfigurationsToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents TilesetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResourcesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PathsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RiversToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MountainsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OverGrassToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ResourcesToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtMapStart As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtMapSize As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtMapX As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtMapY As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtSandBorder As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtDetail As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtResourceFreq As DarkUI.Controls.DarkTextBox
    Friend WithEvents btnStart As DarkUI.Controls.DarkButton
End Class
