<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Map
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
        Me.scrlPictureX = New System.Windows.Forms.HScrollBar()
        Me.scrlPictureY = New System.Windows.Forms.VScrollBar()
        Me.fraTileSet = New System.Windows.Forms.GroupBox()
        Me.scrlTileSet = New System.Windows.Forms.HScrollBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optBlocks = New System.Windows.Forms.RadioButton()
        Me.optAttributes = New System.Windows.Forms.RadioButton()
        Me.optLayers = New System.Windows.Forms.RadioButton()
        Me.btnProperties = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.fraLayers = New System.Windows.Forms.GroupBox()
        Me.btnFill = New System.Windows.Forms.Button()
        Me.btnClearLayer = New System.Windows.Forms.Button()
        Me.optFringe2 = New System.Windows.Forms.RadioButton()
        Me.optFringe = New System.Windows.Forms.RadioButton()
        Me.optMask2 = New System.Windows.Forms.RadioButton()
        Me.optMask = New System.Windows.Forms.RadioButton()
        Me.optGround = New System.Windows.Forms.RadioButton()
        Me.fraAttributes = New System.Windows.Forms.GroupBox()
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
        Me.fraKeyOpen = New System.Windows.Forms.GroupBox()
        Me.scrlKeyY = New System.Windows.Forms.HScrollBar()
        Me.lblKeyY = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.scrlKeyX = New System.Windows.Forms.HScrollBar()
        Me.lblKeyX = New System.Windows.Forms.Label()
        Me.fraMapKey = New System.Windows.Forms.GroupBox()
        Me.chkMapKey = New System.Windows.Forms.CheckBox()
        Me.picMapKey = New System.Windows.Forms.PictureBox()
        Me.btnMapKey = New System.Windows.Forms.Button()
        Me.scrlMapKey = New System.Windows.Forms.HScrollBar()
        Me.lblMapKey = New System.Windows.Forms.Label()
        Me.fraMapItem = New System.Windows.Forms.GroupBox()
        Me.picMapItem = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.scrlMapItemValue = New System.Windows.Forms.HScrollBar()
        Me.scrlMapItem = New System.Windows.Forms.HScrollBar()
        Me.lblMapItem = New System.Windows.Forms.Label()
        Me.fraMapWarp = New System.Windows.Forms.GroupBox()
        Me.btnMapWarp = New System.Windows.Forms.Button()
        Me.scrlMapWarpY = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpX = New System.Windows.Forms.HScrollBar()
        Me.scrlMapWarpMap = New System.Windows.Forms.HScrollBar()
        Me.lblMapWarpY = New System.Windows.Forms.Label()
        Me.lblMapWarpX = New System.Windows.Forms.Label()
        Me.lblMapWarpMap = New System.Windows.Forms.Label()
        Me.fraTrap = New System.Windows.Forms.GroupBox()
        Me.btnTrap = New System.Windows.Forms.Button()
        Me.scrlTrap = New System.Windows.Forms.HScrollBar()
        Me.lblTrap = New System.Windows.Forms.Label()
        Me.fraTileSet.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraLayers.SuspendLayout()
        Me.fraAttributes.SuspendLayout()
        Me.pnlBack.SuspendLayout()
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAttributes.SuspendLayout()
        Me.fraNpcSpawn.SuspendLayout()
        Me.fraHeal.SuspendLayout()
        Me.fraShop.SuspendLayout()
        Me.fraResource.SuspendLayout()
        Me.fraKeyOpen.SuspendLayout()
        Me.fraMapKey.SuspendLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraMapItem.SuspendLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraMapWarp.SuspendLayout()
        Me.fraTrap.SuspendLayout()
        Me.SuspendLayout()
        '
        'scrlPictureX
        '
        Me.scrlPictureX.LargeChange = 1
        Me.scrlPictureX.Location = New System.Drawing.Point(5, 361)
        Me.scrlPictureX.Name = "scrlPictureX"
        Me.scrlPictureX.Size = New System.Drawing.Size(352, 16)
        Me.scrlPictureX.TabIndex = 1
        '
        'scrlPictureY
        '
        Me.scrlPictureY.LargeChange = 1
        Me.scrlPictureY.Location = New System.Drawing.Point(360, 6)
        Me.scrlPictureY.Name = "scrlPictureY"
        Me.scrlPictureY.Size = New System.Drawing.Size(16, 352)
        Me.scrlPictureY.TabIndex = 2
        '
        'fraTileSet
        '
        Me.fraTileSet.Controls.Add(Me.scrlTileSet)
        Me.fraTileSet.Location = New System.Drawing.Point(5, 394)
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
        Me.GroupBox1.Controls.Add(Me.optBlocks)
        Me.GroupBox1.Controls.Add(Me.optAttributes)
        Me.GroupBox1.Controls.Add(Me.optLayers)
        Me.GroupBox1.Location = New System.Drawing.Point(379, 350)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 90)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type"
        '
        'optBlocks
        '
        Me.optBlocks.AutoSize = True
        Me.optBlocks.Location = New System.Drawing.Point(6, 65)
        Me.optBlocks.Name = "optBlocks"
        Me.optBlocks.Size = New System.Drawing.Size(83, 17)
        Me.optBlocks.TabIndex = 2
        Me.optBlocks.TabStop = True
        Me.optBlocks.Text = "Dir. Bloquée"
        Me.optBlocks.UseVisualStyleBackColor = True
        '
        'optAttributes
        '
        Me.optAttributes.AutoSize = True
        Me.optAttributes.Location = New System.Drawing.Point(6, 42)
        Me.optAttributes.Name = "optAttributes"
        Me.optAttributes.Size = New System.Drawing.Size(63, 17)
        Me.optAttributes.TabIndex = 1
        Me.optAttributes.TabStop = True
        Me.optAttributes.Text = "Attributs"
        Me.optAttributes.UseVisualStyleBackColor = True
        '
        'optLayers
        '
        Me.optLayers.AutoSize = True
        Me.optLayers.Location = New System.Drawing.Point(6, 19)
        Me.optLayers.Name = "optLayers"
        Me.optLayers.Size = New System.Drawing.Size(62, 17)
        Me.optLayers.TabIndex = 0
        Me.optLayers.TabStop = True
        Me.optLayers.Text = "Couche"
        Me.optLayers.UseVisualStyleBackColor = True
        '
        'btnProperties
        '
        Me.btnProperties.Location = New System.Drawing.Point(11, 447)
        Me.btnProperties.Name = "btnProperties"
        Me.btnProperties.Size = New System.Drawing.Size(180, 26)
        Me.btnProperties.TabIndex = 5
        Me.btnProperties.Text = "Propriété"
        Me.btnProperties.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(251, 448)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(109, 24)
        Me.btnSend.TabIndex = 6
        Me.btnSend.Text = "Envoyer"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(379, 449)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Annuler"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'fraLayers
        '
        Me.fraLayers.Controls.Add(Me.btnFill)
        Me.fraLayers.Controls.Add(Me.btnClearLayer)
        Me.fraLayers.Controls.Add(Me.optFringe2)
        Me.fraLayers.Controls.Add(Me.optFringe)
        Me.fraLayers.Controls.Add(Me.optMask2)
        Me.fraLayers.Controls.Add(Me.optMask)
        Me.fraLayers.Controls.Add(Me.optGround)
        Me.fraLayers.Location = New System.Drawing.Point(379, 6)
        Me.fraLayers.Name = "fraLayers"
        Me.fraLayers.Size = New System.Drawing.Size(103, 338)
        Me.fraLayers.TabIndex = 8
        Me.fraLayers.TabStop = False
        Me.fraLayers.Text = "Couches"
        '
        'btnFill
        '
        Me.btnFill.Location = New System.Drawing.Point(6, 307)
        Me.btnFill.Name = "btnFill"
        Me.btnFill.Size = New System.Drawing.Size(91, 25)
        Me.btnFill.TabIndex = 8
        Me.btnFill.Text = "Remplir"
        Me.btnFill.UseVisualStyleBackColor = True
        '
        'btnClearLayer
        '
        Me.btnClearLayer.Location = New System.Drawing.Point(6, 278)
        Me.btnClearLayer.Name = "btnClearLayer"
        Me.btnClearLayer.Size = New System.Drawing.Size(91, 25)
        Me.btnClearLayer.TabIndex = 5
        Me.btnClearLayer.Text = "Nettoyer"
        Me.btnClearLayer.UseVisualStyleBackColor = True
        '
        'optFringe2
        '
        Me.optFringe2.AutoSize = True
        Me.optFringe2.Location = New System.Drawing.Point(6, 111)
        Me.optFringe2.Name = "optFringe2"
        Me.optFringe2.Size = New System.Drawing.Size(67, 17)
        Me.optFringe2.TabIndex = 4
        Me.optFringe2.Text = "Frange 2"
        Me.optFringe2.UseVisualStyleBackColor = True
        '
        'optFringe
        '
        Me.optFringe.AutoSize = True
        Me.optFringe.Location = New System.Drawing.Point(6, 88)
        Me.optFringe.Name = "optFringe"
        Me.optFringe.Size = New System.Drawing.Size(58, 17)
        Me.optFringe.TabIndex = 3
        Me.optFringe.Text = "Frange"
        Me.optFringe.UseVisualStyleBackColor = True
        '
        'optMask2
        '
        Me.optMask2.AutoSize = True
        Me.optMask2.Location = New System.Drawing.Point(6, 65)
        Me.optMask2.Name = "optMask2"
        Me.optMask2.Size = New System.Drawing.Size(72, 17)
        Me.optMask2.TabIndex = 2
        Me.optMask2.Text = "Masque 2"
        Me.optMask2.UseVisualStyleBackColor = True
        '
        'optMask
        '
        Me.optMask.AutoSize = True
        Me.optMask.Location = New System.Drawing.Point(6, 42)
        Me.optMask.Name = "optMask"
        Me.optMask.Size = New System.Drawing.Size(63, 17)
        Me.optMask.TabIndex = 1
        Me.optMask.Text = "Masque"
        Me.optMask.UseVisualStyleBackColor = True
        '
        'optGround
        '
        Me.optGround.AutoSize = True
        Me.optGround.Checked = True
        Me.optGround.Location = New System.Drawing.Point(6, 19)
        Me.optGround.Name = "optGround"
        Me.optGround.Size = New System.Drawing.Size(50, 17)
        Me.optGround.TabIndex = 0
        Me.optGround.TabStop = True
        Me.optGround.Text = "Terre"
        Me.optGround.UseVisualStyleBackColor = True
        '
        'fraAttributes
        '
        Me.fraAttributes.Controls.Add(Me.btnClearAttribute)
        Me.fraAttributes.Controls.Add(Me.optTrap)
        Me.fraAttributes.Controls.Add(Me.optHeal)
        Me.fraAttributes.Controls.Add(Me.optBank)
        Me.fraAttributes.Controls.Add(Me.optShop)
        Me.fraAttributes.Controls.Add(Me.optNPCSpawn)
        Me.fraAttributes.Controls.Add(Me.optDoor)
        Me.fraAttributes.Controls.Add(Me.optResource)
        Me.fraAttributes.Controls.Add(Me.optKeyOpen)
        Me.fraAttributes.Controls.Add(Me.optKey)
        Me.fraAttributes.Controls.Add(Me.optNPCAvoid)
        Me.fraAttributes.Controls.Add(Me.optItem)
        Me.fraAttributes.Controls.Add(Me.optWarp)
        Me.fraAttributes.Controls.Add(Me.optBlocked)
        Me.fraAttributes.Location = New System.Drawing.Point(379, 6)
        Me.fraAttributes.Name = "fraAttributes"
        Me.fraAttributes.Size = New System.Drawing.Size(103, 338)
        Me.fraAttributes.TabIndex = 10
        Me.fraAttributes.TabStop = False
        Me.fraAttributes.Text = "Attributs"
        Me.fraAttributes.Visible = False
        '
        'btnClearAttribute
        '
        Me.btnClearAttribute.Location = New System.Drawing.Point(6, 313)
        Me.btnClearAttribute.Name = "btnClearAttribute"
        Me.btnClearAttribute.Size = New System.Drawing.Size(91, 25)
        Me.btnClearAttribute.TabIndex = 14
        Me.btnClearAttribute.Text = "Nettoyer"
        Me.btnClearAttribute.UseVisualStyleBackColor = True
        '
        'optTrap
        '
        Me.optTrap.AutoSize = True
        Me.optTrap.Location = New System.Drawing.Point(5, 227)
        Me.optTrap.Name = "optTrap"
        Me.optTrap.Size = New System.Drawing.Size(52, 17)
        Me.optTrap.TabIndex = 12
        Me.optTrap.TabStop = True
        Me.optTrap.Text = "Piège"
        Me.optTrap.UseVisualStyleBackColor = True
        '
        'optHeal
        '
        Me.optHeal.AutoSize = True
        Me.optHeal.Location = New System.Drawing.Point(5, 211)
        Me.optHeal.Name = "optHeal"
        Me.optHeal.Size = New System.Drawing.Size(46, 17)
        Me.optHeal.TabIndex = 11
        Me.optHeal.TabStop = True
        Me.optHeal.Text = "Soin"
        Me.optHeal.UseVisualStyleBackColor = True
        '
        'optBank
        '
        Me.optBank.AutoSize = True
        Me.optBank.Location = New System.Drawing.Point(5, 195)
        Me.optBank.Name = "optBank"
        Me.optBank.Size = New System.Drawing.Size(62, 17)
        Me.optBank.TabIndex = 10
        Me.optBank.TabStop = True
        Me.optBank.Text = "Banque"
        Me.optBank.UseVisualStyleBackColor = True
        '
        'optShop
        '
        Me.optShop.AutoSize = True
        Me.optShop.Location = New System.Drawing.Point(5, 177)
        Me.optShop.Name = "optShop"
        Me.optShop.Size = New System.Drawing.Size(65, 17)
        Me.optShop.TabIndex = 9
        Me.optShop.TabStop = True
        Me.optShop.Text = "Magasin"
        Me.optShop.UseVisualStyleBackColor = True
        '
        'optNPCSpawn
        '
        Me.optNPCSpawn.AutoSize = True
        Me.optNPCSpawn.Location = New System.Drawing.Point(5, 160)
        Me.optNPCSpawn.Name = "optNPCSpawn"
        Me.optNPCSpawn.Size = New System.Drawing.Size(98, 17)
        Me.optNPCSpawn.TabIndex = 8
        Me.optNPCSpawn.TabStop = True
        Me.optNPCSpawn.Text = "Appartion PNJs"
        Me.optNPCSpawn.UseVisualStyleBackColor = True
        '
        'optDoor
        '
        Me.optDoor.AutoSize = True
        Me.optDoor.Location = New System.Drawing.Point(5, 143)
        Me.optDoor.Name = "optDoor"
        Me.optDoor.Size = New System.Drawing.Size(50, 17)
        Me.optDoor.TabIndex = 7
        Me.optDoor.TabStop = True
        Me.optDoor.Text = "Porte"
        Me.optDoor.UseVisualStyleBackColor = True
        '
        'optResource
        '
        Me.optResource.AutoSize = True
        Me.optResource.Location = New System.Drawing.Point(5, 125)
        Me.optResource.Name = "optResource"
        Me.optResource.Size = New System.Drawing.Size(76, 17)
        Me.optResource.TabIndex = 6
        Me.optResource.TabStop = True
        Me.optResource.Text = "Ressource"
        Me.optResource.UseVisualStyleBackColor = True
        '
        'optKeyOpen
        '
        Me.optKeyOpen.AutoSize = True
        Me.optKeyOpen.Location = New System.Drawing.Point(5, 110)
        Me.optKeyOpen.Name = "optKeyOpen"
        Me.optKeyOpen.Size = New System.Drawing.Size(79, 17)
        Me.optKeyOpen.TabIndex = 5
        Me.optKeyOpen.TabStop = True
        Me.optKeyOpen.Text = "Clé ouverte"
        Me.optKeyOpen.UseVisualStyleBackColor = True
        '
        'optKey
        '
        Me.optKey.AutoSize = True
        Me.optKey.Location = New System.Drawing.Point(5, 92)
        Me.optKey.Name = "optKey"
        Me.optKey.Size = New System.Drawing.Size(40, 17)
        Me.optKey.TabIndex = 4
        Me.optKey.TabStop = True
        Me.optKey.Text = "Clé"
        Me.optKey.UseVisualStyleBackColor = True
        '
        'optNPCAvoid
        '
        Me.optNPCAvoid.AutoSize = True
        Me.optNPCAvoid.Location = New System.Drawing.Point(5, 74)
        Me.optNPCAvoid.Name = "optNPCAvoid"
        Me.optNPCAvoid.Size = New System.Drawing.Size(45, 17)
        Me.optNPCAvoid.TabIndex = 3
        Me.optNPCAvoid.TabStop = True
        Me.optNPCAvoid.Text = "PNJ"
        Me.optNPCAvoid.UseVisualStyleBackColor = True
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.Location = New System.Drawing.Point(5, 55)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(50, 17)
        Me.optItem.TabIndex = 2
        Me.optItem.TabStop = True
        Me.optItem.Text = "Objet"
        Me.optItem.UseVisualStyleBackColor = True
        '
        'optWarp
        '
        Me.optWarp.AutoSize = True
        Me.optWarp.Location = New System.Drawing.Point(5, 36)
        Me.optWarp.Name = "optWarp"
        Me.optWarp.Size = New System.Drawing.Size(87, 17)
        Me.optWarp.TabIndex = 1
        Me.optWarp.TabStop = True
        Me.optWarp.Text = "Téléportation"
        Me.optWarp.UseVisualStyleBackColor = True
        '
        'optBlocked
        '
        Me.optBlocked.AutoSize = True
        Me.optBlocked.Location = New System.Drawing.Point(5, 19)
        Me.optBlocked.Name = "optBlocked"
        Me.optBlocked.Size = New System.Drawing.Size(58, 17)
        Me.optBlocked.TabIndex = 0
        Me.optBlocked.TabStop = True
        Me.optBlocked.Text = "Bloqué"
        Me.optBlocked.UseVisualStyleBackColor = True
        '
        'pnlBack
        '
        Me.pnlBack.Controls.Add(Me.picBackSelect)
        Me.pnlBack.Location = New System.Drawing.Point(8, 6)
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
        Me.Label1.Location = New System.Drawing.Point(80, 378)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Glissez la souris pour selectionner plusieurs tiles"
        '
        'pnlAttributes
        '
        Me.pnlAttributes.Controls.Add(Me.fraNpcSpawn)
        Me.pnlAttributes.Controls.Add(Me.fraHeal)
        Me.pnlAttributes.Controls.Add(Me.fraShop)
        Me.pnlAttributes.Controls.Add(Me.fraResource)
        Me.pnlAttributes.Controls.Add(Me.fraKeyOpen)
        Me.pnlAttributes.Controls.Add(Me.fraMapKey)
        Me.pnlAttributes.Controls.Add(Me.fraMapItem)
        Me.pnlAttributes.Controls.Add(Me.fraMapWarp)
        Me.pnlAttributes.Controls.Add(Me.fraTrap)
        Me.pnlAttributes.Location = New System.Drawing.Point(487, 6)
        Me.pnlAttributes.Name = "pnlAttributes"
        Me.pnlAttributes.Size = New System.Drawing.Size(482, 470)
        Me.pnlAttributes.TabIndex = 12
        Me.pnlAttributes.Visible = False
        '
        'fraNpcSpawn
        '
        Me.fraNpcSpawn.Controls.Add(Me.lstNpc)
        Me.fraNpcSpawn.Controls.Add(Me.btnNpcSpawn)
        Me.fraNpcSpawn.Controls.Add(Me.scrlNpcDir)
        Me.fraNpcSpawn.Controls.Add(Me.lblNpcDir)
        Me.fraNpcSpawn.Location = New System.Drawing.Point(131, 132)
        Me.fraNpcSpawn.Name = "fraNpcSpawn"
        Me.fraNpcSpawn.Size = New System.Drawing.Size(252, 158)
        Me.fraNpcSpawn.TabIndex = 11
        Me.fraNpcSpawn.TabStop = False
        Me.fraNpcSpawn.Text = "Apparition des PNJs"
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
        Me.btnNpcSpawn.Text = "Accepter"
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
        Me.fraHeal.Location = New System.Drawing.Point(131, 136)
        Me.fraHeal.Name = "fraHeal"
        Me.fraHeal.Size = New System.Drawing.Size(252, 130)
        Me.fraHeal.TabIndex = 15
        Me.fraHeal.TabStop = False
        Me.fraHeal.Text = "Soin"
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
        Me.lblHeal.Size = New System.Drawing.Size(59, 13)
        Me.lblHeal.TabIndex = 38
        Me.lblHeal.Text = "Quantité: 0"
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
        Me.btnHeal.Text = "Accepter"
        Me.btnHeal.UseVisualStyleBackColor = True
        '
        'fraShop
        '
        Me.fraShop.Controls.Add(Me.cmbShop)
        Me.fraShop.Controls.Add(Me.btnShop)
        Me.fraShop.Location = New System.Drawing.Point(131, 134)
        Me.fraShop.Name = "fraShop"
        Me.fraShop.Size = New System.Drawing.Size(252, 113)
        Me.fraShop.TabIndex = 12
        Me.fraShop.TabStop = False
        Me.fraShop.Text = "Magasin"
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
        Me.fraResource.Location = New System.Drawing.Point(131, 131)
        Me.fraResource.Name = "fraResource"
        Me.fraResource.Size = New System.Drawing.Size(252, 138)
        Me.fraResource.TabIndex = 10
        Me.fraResource.TabStop = False
        Me.fraResource.Text = "Ressource"
        '
        'btnResourceOk
        '
        Me.btnResourceOk.Location = New System.Drawing.Point(79, 97)
        Me.btnResourceOk.Name = "btnResourceOk"
        Me.btnResourceOk.Size = New System.Drawing.Size(90, 28)
        Me.btnResourceOk.TabIndex = 6
        Me.btnResourceOk.Text = "Accepter"
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
        'fraKeyOpen
        '
        Me.fraKeyOpen.Controls.Add(Me.scrlKeyY)
        Me.fraKeyOpen.Controls.Add(Me.lblKeyY)
        Me.fraKeyOpen.Controls.Add(Me.Button3)
        Me.fraKeyOpen.Controls.Add(Me.scrlKeyX)
        Me.fraKeyOpen.Controls.Add(Me.lblKeyX)
        Me.fraKeyOpen.Location = New System.Drawing.Point(131, 129)
        Me.fraKeyOpen.Name = "fraKeyOpen"
        Me.fraKeyOpen.Size = New System.Drawing.Size(252, 138)
        Me.fraKeyOpen.TabIndex = 9
        Me.fraKeyOpen.TabStop = False
        Me.fraKeyOpen.Text = "Clée de la carte ouverte"
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
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(79, 97)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 28)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Accepter"
        Me.Button3.UseVisualStyleBackColor = True
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
        Me.fraMapKey.Location = New System.Drawing.Point(131, 127)
        Me.fraMapKey.Name = "fraMapKey"
        Me.fraMapKey.Size = New System.Drawing.Size(252, 138)
        Me.fraMapKey.TabIndex = 8
        Me.fraMapKey.TabStop = False
        Me.fraMapKey.Text = "Clée de la carte"
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
        Me.lblMapKey.Size = New System.Drawing.Size(64, 13)
        Me.lblMapKey.TabIndex = 0
        Me.lblMapKey.Text = "Objet: None"
        '
        'fraMapItem
        '
        Me.fraMapItem.Controls.Add(Me.picMapItem)
        Me.fraMapItem.Controls.Add(Me.Button2)
        Me.fraMapItem.Controls.Add(Me.scrlMapItemValue)
        Me.fraMapItem.Controls.Add(Me.scrlMapItem)
        Me.fraMapItem.Controls.Add(Me.lblMapItem)
        Me.fraMapItem.Location = New System.Drawing.Point(131, 126)
        Me.fraMapItem.Name = "fraMapItem"
        Me.fraMapItem.Size = New System.Drawing.Size(252, 138)
        Me.fraMapItem.TabIndex = 7
        Me.fraMapItem.TabStop = False
        Me.fraMapItem.Text = "Objet de la carte"
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(79, 97)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 28)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Accepter"
        Me.Button2.UseVisualStyleBackColor = True
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
        Me.lblMapItem.Size = New System.Drawing.Size(78, 13)
        Me.lblMapItem.TabIndex = 0
        Me.lblMapItem.Text = "Objet: None x0"
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
        Me.fraMapWarp.Text = "Téléportation de la carte"
        '
        'btnMapWarp
        '
        Me.btnMapWarp.Location = New System.Drawing.Point(85, 138)
        Me.btnMapWarp.Name = "btnMapWarp"
        Me.btnMapWarp.Size = New System.Drawing.Size(90, 28)
        Me.btnMapWarp.TabIndex = 6
        Me.btnMapWarp.Text = "Accepter"
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
        Me.lblMapWarpMap.Size = New System.Drawing.Size(44, 13)
        Me.lblMapWarpMap.TabIndex = 0
        Me.lblMapWarpMap.Text = "Carte: 1"
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
        Me.fraTrap.Text = "Piège"
        '
        'btnTrap
        '
        Me.btnTrap.Location = New System.Drawing.Point(80, 67)
        Me.btnTrap.Name = "btnTrap"
        Me.btnTrap.Size = New System.Drawing.Size(90, 28)
        Me.btnTrap.TabIndex = 42
        Me.btnTrap.Text = "Accepter"
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
        Me.lblTrap.Size = New System.Drawing.Size(59, 13)
        Me.lblTrap.TabIndex = 40
        Me.lblTrap.Text = "Quantité: 0"
        '
        'frmEditor_Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 479)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlAttributes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlBack)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.btnProperties)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraTileSet)
        Me.Controls.Add(Me.scrlPictureY)
        Me.Controls.Add(Me.scrlPictureX)
        Me.Controls.Add(Me.fraAttributes)
        Me.Controls.Add(Me.fraLayers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmEditor_Map"
        Me.Text = "Editeur de carte"
        Me.fraTileSet.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraLayers.ResumeLayout(False)
        Me.fraLayers.PerformLayout()
        Me.fraAttributes.ResumeLayout(False)
        Me.fraAttributes.PerformLayout()
        Me.pnlBack.ResumeLayout(False)
        CType(Me.picBackSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAttributes.ResumeLayout(False)
        Me.fraNpcSpawn.ResumeLayout(False)
        Me.fraNpcSpawn.PerformLayout()
        Me.fraHeal.ResumeLayout(False)
        Me.fraHeal.PerformLayout()
        Me.fraShop.ResumeLayout(False)
        Me.fraResource.ResumeLayout(False)
        Me.fraResource.PerformLayout()
        Me.fraKeyOpen.ResumeLayout(False)
        Me.fraKeyOpen.PerformLayout()
        Me.fraMapKey.ResumeLayout(False)
        Me.fraMapKey.PerformLayout()
        CType(Me.picMapKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraMapItem.ResumeLayout(False)
        Me.fraMapItem.PerformLayout()
        CType(Me.picMapItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraMapWarp.ResumeLayout(False)
        Me.fraMapWarp.PerformLayout()
        Me.fraTrap.ResumeLayout(False)
        Me.fraTrap.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents scrlPictureX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlPictureY As System.Windows.Forms.VScrollBar
    Friend WithEvents fraTileSet As System.Windows.Forms.GroupBox
    Friend WithEvents scrlTileSet As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optBlocks As System.Windows.Forms.RadioButton
    Friend WithEvents optAttributes As System.Windows.Forms.RadioButton
    Friend WithEvents optLayers As System.Windows.Forms.RadioButton
    Friend WithEvents btnProperties As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents fraLayers As System.Windows.Forms.GroupBox
    Friend WithEvents optFringe2 As System.Windows.Forms.RadioButton
    Friend WithEvents optFringe As System.Windows.Forms.RadioButton
    Friend WithEvents optMask2 As System.Windows.Forms.RadioButton
    Friend WithEvents optMask As System.Windows.Forms.RadioButton
    Friend WithEvents optGround As System.Windows.Forms.RadioButton
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
    Friend WithEvents fraAttributes As System.Windows.Forms.GroupBox
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
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
    Friend WithEvents Button3 As System.Windows.Forms.Button
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
End Class
