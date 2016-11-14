<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoMapper
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
        Me.mnsMenu = New System.Windows.Forms.MenuStrip()
        Me.ConfigurationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TilesetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiversToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MountainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverGrassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourcesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMapStart = New System.Windows.Forms.TextBox()
        Me.txtMapSize = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSandBorder = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResourceFreq = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblMapTime = New System.Windows.Forms.Label()
        Me.lblPathTime = New System.Windows.Forms.Label()
        Me.lblRiversTime = New System.Windows.Forms.Label()
        Me.lblMountainsTime = New System.Windows.Forms.Label()
        Me.lblOvergrassTime = New System.Windows.Forms.Label()
        Me.lblResourcesTime = New System.Windows.Forms.Label()
        Me.lblCacheTime = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbPrefab = New System.Windows.Forms.ComboBox()
        Me.cmbLayer = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTileset = New System.Windows.Forms.TextBox()
        Me.txtTileX = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTileY = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAutotile = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkBlocked = New System.Windows.Forms.CheckBox()
        Me.btmTileSetClose = New System.Windows.Forms.Button()
        Me.btnTileSetSave = New System.Windows.Forms.Button()
        Me.mnsMenu.SuspendLayout()
        Me.pnlResources.SuspendLayout()
        Me.pnlTileConfig.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnsMenu
        '
        Me.mnsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationsToolStripMenuItem, Me.GenerateToolStripMenuItem})
        Me.mnsMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnsMenu.Name = "mnsMenu"
        Me.mnsMenu.Size = New System.Drawing.Size(390, 24)
        Me.mnsMenu.TabIndex = 0
        Me.mnsMenu.Text = "MenuStrip1"
        '
        'ConfigurationsToolStripMenuItem
        '
        Me.ConfigurationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TilesetsToolStripMenuItem, Me.ResourcesToolStripMenuItem})
        Me.ConfigurationsToolStripMenuItem.Name = "ConfigurationsToolStripMenuItem"
        Me.ConfigurationsToolStripMenuItem.Size = New System.Drawing.Size(98, 20)
        Me.ConfigurationsToolStripMenuItem.Text = "Configurations"
        '
        'TilesetsToolStripMenuItem
        '
        Me.TilesetsToolStripMenuItem.Name = "TilesetsToolStripMenuItem"
        Me.TilesetsToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.TilesetsToolStripMenuItem.Text = "Tilesets"
        '
        'ResourcesToolStripMenuItem
        '
        Me.ResourcesToolStripMenuItem.Name = "ResourcesToolStripMenuItem"
        Me.ResourcesToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ResourcesToolStripMenuItem.Text = "Resources"
        '
        'GenerateToolStripMenuItem
        '
        Me.GenerateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PathsToolStripMenuItem, Me.RiversToolStripMenuItem, Me.MountainsToolStripMenuItem, Me.OverGrassToolStripMenuItem, Me.ResourcesToolStripMenuItem1, Me.DetailsToolStripMenuItem})
        Me.GenerateToolStripMenuItem.Name = "GenerateToolStripMenuItem"
        Me.GenerateToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.GenerateToolStripMenuItem.Text = "Generate"
        '
        'PathsToolStripMenuItem
        '
        Me.PathsToolStripMenuItem.Checked = True
        Me.PathsToolStripMenuItem.CheckOnClick = True
        Me.PathsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PathsToolStripMenuItem.Name = "PathsToolStripMenuItem"
        Me.PathsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.PathsToolStripMenuItem.Text = "Paths"
        '
        'RiversToolStripMenuItem
        '
        Me.RiversToolStripMenuItem.Checked = True
        Me.RiversToolStripMenuItem.CheckOnClick = True
        Me.RiversToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RiversToolStripMenuItem.Name = "RiversToolStripMenuItem"
        Me.RiversToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.RiversToolStripMenuItem.Text = "Rivers"
        '
        'MountainsToolStripMenuItem
        '
        Me.MountainsToolStripMenuItem.Checked = True
        Me.MountainsToolStripMenuItem.CheckOnClick = True
        Me.MountainsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MountainsToolStripMenuItem.Name = "MountainsToolStripMenuItem"
        Me.MountainsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.MountainsToolStripMenuItem.Text = "Mountains"
        '
        'OverGrassToolStripMenuItem
        '
        Me.OverGrassToolStripMenuItem.Checked = True
        Me.OverGrassToolStripMenuItem.CheckOnClick = True
        Me.OverGrassToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OverGrassToolStripMenuItem.Name = "OverGrassToolStripMenuItem"
        Me.OverGrassToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.OverGrassToolStripMenuItem.Text = "OverGrass"
        '
        'ResourcesToolStripMenuItem1
        '
        Me.ResourcesToolStripMenuItem1.Checked = True
        Me.ResourcesToolStripMenuItem1.CheckOnClick = True
        Me.ResourcesToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ResourcesToolStripMenuItem1.Name = "ResourcesToolStripMenuItem1"
        Me.ResourcesToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.ResourcesToolStripMenuItem1.Text = "Resources"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Checked = True
        Me.DetailsToolStripMenuItem.CheckOnClick = True
        Me.DetailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start Map:"
        '
        'txtMapStart
        '
        Me.txtMapStart.Location = New System.Drawing.Point(145, 31)
        Me.txtMapStart.Name = "txtMapStart"
        Me.txtMapStart.Size = New System.Drawing.Size(236, 20)
        Me.txtMapStart.TabIndex = 2
        Me.txtMapStart.Text = "1"
        '
        'txtMapSize
        '
        Me.txtMapSize.Location = New System.Drawing.Point(145, 57)
        Me.txtMapSize.Name = "txtMapSize"
        Me.txtMapSize.Size = New System.Drawing.Size(236, 20)
        Me.txtMapSize.TabIndex = 4
        Me.txtMapSize.Text = "4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Island Area:"
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(145, 83)
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(236, 20)
        Me.txtX.TabIndex = 6
        Me.txtX.Text = "50"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "MapSize X:"
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(145, 109)
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(236, 20)
        Me.txtY.TabIndex = 8
        Me.txtY.Text = "50"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "MapSize Y:"
        '
        'txtSandBorder
        '
        Me.txtSandBorder.Location = New System.Drawing.Point(145, 135)
        Me.txtSandBorder.Name = "txtSandBorder"
        Me.txtSandBorder.Size = New System.Drawing.Size(236, 20)
        Me.txtSandBorder.TabIndex = 10
        Me.txtSandBorder.Text = "4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Sand Border:"
        '
        'txtDetail
        '
        Me.txtDetail.Location = New System.Drawing.Point(145, 161)
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.Size = New System.Drawing.Size(236, 20)
        Me.txtDetail.TabIndex = 12
        Me.txtDetail.Text = "10"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Detail Frequency 1 of "
        '
        'txtResourceFreq
        '
        Me.txtResourceFreq.Location = New System.Drawing.Point(145, 187)
        Me.txtResourceFreq.Name = "txtResourceFreq"
        Me.txtResourceFreq.Size = New System.Drawing.Size(236, 20)
        Me.txtResourceFreq.TabIndex = 14
        Me.txtResourceFreq.Text = "20"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Resource Frequency 1 of"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(15, 213)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(369, 23)
        Me.btnStart.TabIndex = 15
        Me.btnStart.Text = "Create The World"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblMapTime
        '
        Me.lblMapTime.AutoSize = True
        Me.lblMapTime.Location = New System.Drawing.Point(12, 250)
        Me.lblMapTime.Name = "lblMapTime"
        Me.lblMapTime.Size = New System.Drawing.Size(75, 13)
        Me.lblMapTime.TabIndex = 16
        Me.lblMapTime.Text = "Map Time Log"
        '
        'lblPathTime
        '
        Me.lblPathTime.AutoSize = True
        Me.lblPathTime.Location = New System.Drawing.Point(12, 273)
        Me.lblPathTime.Name = "lblPathTime"
        Me.lblPathTime.Size = New System.Drawing.Size(76, 13)
        Me.lblPathTime.TabIndex = 17
        Me.lblPathTime.Text = "Path Time Log"
        '
        'lblRiversTime
        '
        Me.lblRiversTime.AutoSize = True
        Me.lblRiversTime.Location = New System.Drawing.Point(12, 297)
        Me.lblRiversTime.Name = "lblRiversTime"
        Me.lblRiversTime.Size = New System.Drawing.Size(84, 13)
        Me.lblRiversTime.TabIndex = 18
        Me.lblRiversTime.Text = "Rivers Time Log"
        '
        'lblMountainsTime
        '
        Me.lblMountainsTime.AutoSize = True
        Me.lblMountainsTime.Location = New System.Drawing.Point(12, 321)
        Me.lblMountainsTime.Name = "lblMountainsTime"
        Me.lblMountainsTime.Size = New System.Drawing.Size(103, 13)
        Me.lblMountainsTime.TabIndex = 19
        Me.lblMountainsTime.Text = "Mountains Time Log"
        '
        'lblOvergrassTime
        '
        Me.lblOvergrassTime.AutoSize = True
        Me.lblOvergrassTime.Location = New System.Drawing.Point(12, 349)
        Me.lblOvergrassTime.Name = "lblOvergrassTime"
        Me.lblOvergrassTime.Size = New System.Drawing.Size(104, 13)
        Me.lblOvergrassTime.TabIndex = 20
        Me.lblOvergrassTime.Text = "OverGrass Time Log"
        '
        'lblResourcesTime
        '
        Me.lblResourcesTime.AutoSize = True
        Me.lblResourcesTime.Location = New System.Drawing.Point(12, 374)
        Me.lblResourcesTime.Name = "lblResourcesTime"
        Me.lblResourcesTime.Size = New System.Drawing.Size(105, 13)
        Me.lblResourcesTime.TabIndex = 21
        Me.lblResourcesTime.Text = "Resources Time Log"
        '
        'lblCacheTime
        '
        Me.lblCacheTime.AutoSize = True
        Me.lblCacheTime.Location = New System.Drawing.Point(12, 400)
        Me.lblCacheTime.Name = "lblCacheTime"
        Me.lblCacheTime.Size = New System.Drawing.Size(85, 13)
        Me.lblCacheTime.TabIndex = 22
        Me.lblCacheTime.Text = "Cache Time Log"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(12, 425)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(78, 13)
        Me.lblTime.TabIndex = 23
        Me.lblTime.Text = "Total Time Log"
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
        Me.pnlResources.Location = New System.Drawing.Point(5, 28)
        Me.pnlResources.Name = "pnlResources"
        Me.pnlResources.Size = New System.Drawing.Size(379, 424)
        Me.pnlResources.TabIndex = 24
        Me.pnlResources.Visible = False
        '
        'btnSaveResource
        '
        Me.btnSaveResource.Location = New System.Drawing.Point(254, 398)
        Me.btnSaveResource.Name = "btnSaveResource"
        Me.btnSaveResource.Size = New System.Drawing.Size(122, 23)
        Me.btnSaveResource.TabIndex = 7
        Me.btnSaveResource.Text = "Save"
        Me.btnSaveResource.UseVisualStyleBackColor = True
        '
        'btnCloseResource
        '
        Me.btnCloseResource.Location = New System.Drawing.Point(3, 398)
        Me.btnCloseResource.Name = "btnCloseResource"
        Me.btnCloseResource.Size = New System.Drawing.Size(122, 23)
        Me.btnCloseResource.TabIndex = 6
        Me.btnCloseResource.Text = "Close"
        Me.btnCloseResource.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(254, 227)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(122, 23)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update Resource"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(254, 198)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(122, 23)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove Resource"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(254, 169)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(122, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add Resource"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtResource
        '
        Me.txtResource.Location = New System.Drawing.Point(109, 166)
        Me.txtResource.Name = "txtResource"
        Me.txtResource.Size = New System.Drawing.Size(100, 20)
        Me.txtResource.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 169)
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
        Me.lstResources.Size = New System.Drawing.Size(373, 160)
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
        Me.pnlTileConfig.Location = New System.Drawing.Point(5, 28)
        Me.pnlTileConfig.Name = "pnlTileConfig"
        Me.pnlTileConfig.Size = New System.Drawing.Size(379, 424)
        Me.pnlTileConfig.TabIndex = 25
        Me.pnlTileConfig.Visible = False
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
        'cmbPrefab
        '
        Me.cmbPrefab.FormattingEnabled = True
        Me.cmbPrefab.Items.AddRange(New Object() {"Water", "Sand", "Grass", "Passing", "Overgrass", "River", "Mountain"})
        Me.cmbPrefab.Location = New System.Drawing.Point(115, 7)
        Me.cmbPrefab.Name = "cmbPrefab"
        Me.cmbPrefab.Size = New System.Drawing.Size(252, 21)
        Me.cmbPrefab.TabIndex = 1
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "TileSet Number:"
        '
        'txtTileset
        '
        Me.txtTileset.Location = New System.Drawing.Point(108, 19)
        Me.txtTileset.Name = "txtTileset"
        Me.txtTileset.Size = New System.Drawing.Size(252, 20)
        Me.txtTileset.TabIndex = 1
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
        'btmTileSetClose
        '
        Me.btmTileSetClose.Location = New System.Drawing.Point(10, 392)
        Me.btmTileSetClose.Name = "btmTileSetClose"
        Me.btmTileSetClose.Size = New System.Drawing.Size(75, 23)
        Me.btmTileSetClose.TabIndex = 5
        Me.btmTileSetClose.Text = "Close"
        Me.btmTileSetClose.UseVisualStyleBackColor = True
        '
        'btnTileSetSave
        '
        Me.btnTileSetSave.Location = New System.Drawing.Point(292, 392)
        Me.btnTileSetSave.Name = "btnTileSetSave"
        Me.btnTileSetSave.Size = New System.Drawing.Size(75, 23)
        Me.btnTileSetSave.TabIndex = 6
        Me.btnTileSetSave.Text = "Save"
        Me.btnTileSetSave.UseVisualStyleBackColor = True
        '
        'frmAutoMapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 464)
        Me.Controls.Add(Me.pnlTileConfig)
        Me.Controls.Add(Me.pnlResources)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblCacheTime)
        Me.Controls.Add(Me.lblResourcesTime)
        Me.Controls.Add(Me.lblOvergrassTime)
        Me.Controls.Add(Me.lblMountainsTime)
        Me.Controls.Add(Me.lblRiversTime)
        Me.Controls.Add(Me.lblPathTime)
        Me.Controls.Add(Me.lblMapTime)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtResourceFreq)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDetail)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSandBorder)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtY)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtX)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMapSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMapStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mnsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.mnsMenu
        Me.Name = "frmAutoMapper"
        Me.Text = "Auto Mapper"
        Me.mnsMenu.ResumeLayout(False)
        Me.mnsMenu.PerformLayout()
        Me.pnlResources.ResumeLayout(False)
        Me.pnlResources.PerformLayout()
        Me.pnlTileConfig.ResumeLayout(False)
        Me.pnlTileConfig.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnsMenu As MenuStrip
    Friend WithEvents ConfigurationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TilesetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResourcesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PathsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiversToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MountainsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OverGrassToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResourcesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMapStart As TextBox
    Friend WithEvents txtMapSize As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtX As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSandBorder As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDetail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtResourceFreq As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents lblMapTime As Label
    Friend WithEvents lblPathTime As Label
    Friend WithEvents lblRiversTime As Label
    Friend WithEvents lblMountainsTime As Label
    Friend WithEvents lblOvergrassTime As Label
    Friend WithEvents lblResourcesTime As Label
    Friend WithEvents lblCacheTime As Label
    Friend WithEvents lblTime As Label
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
End Class
