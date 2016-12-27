<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor_Item
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.scrlAnim = New System.Windows.Forms.HScrollBar()
        Me.scrlRarity = New System.Windows.Forms.HScrollBar()
        Me.cmbBind = New System.Windows.Forms.ComboBox()
        Me.lblAnim = New System.Windows.Forms.Label()
        Me.lblRarity = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picItem = New System.Windows.Forms.PictureBox()
        Me.scrlPic = New System.Windows.Forms.HScrollBar()
        Me.lblPic = New System.Windows.Forms.Label()
        Me.scrlPrice = New System.Windows.Forms.HScrollBar()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.scrlSprReq = New System.Windows.Forms.HScrollBar()
        Me.lblSprReq = New System.Windows.Forms.Label()
        Me.scrlVitReq = New System.Windows.Forms.HScrollBar()
        Me.lblVitReq = New System.Windows.Forms.Label()
        Me.scrlIntReq = New System.Windows.Forms.HScrollBar()
        Me.lblIntReq = New System.Windows.Forms.Label()
        Me.scrlEndReq = New System.Windows.Forms.HScrollBar()
        Me.lblEndReq = New System.Windows.Forms.Label()
        Me.scrlLuckReq = New System.Windows.Forms.HScrollBar()
        Me.lblLuckReq = New System.Windows.Forms.Label()
        Me.scrlStrReq = New System.Windows.Forms.HScrollBar()
        Me.lblStrReq = New System.Windows.Forms.Label()
        Me.scrlLevelReq = New System.Windows.Forms.HScrollBar()
        Me.scrlAccessReq = New System.Windows.Forms.HScrollBar()
        Me.cmbClassReq = New System.Windows.Forms.ComboBox()
        Me.lblLevelReq = New System.Windows.Forms.Label()
        Me.lblAccessReq = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fraEquipment = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.scrlAmmo = New System.Windows.Forms.HScrollBar()
        Me.lblAmmo = New System.Windows.Forms.Label()
        Me.scrlProjectile = New System.Windows.Forms.HScrollBar()
        Me.lblProjectile = New System.Windows.Forms.Label()
        Me.numMax = New System.Windows.Forms.NumericUpDown()
        Me.numMin = New System.Windows.Forms.NumericUpDown()
        Me.chkRandomize = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbKnockBackTiles = New System.Windows.Forms.ComboBox()
        Me.chkKnockBack = New System.Windows.Forms.CheckBox()
        Me.scrlPaperdoll = New System.Windows.Forms.HScrollBar()
        Me.lblPaperDoll = New System.Windows.Forms.Label()
        Me.picPaperdoll = New System.Windows.Forms.PictureBox()
        Me.scrlAddSpr = New System.Windows.Forms.HScrollBar()
        Me.lblAddSpr = New System.Windows.Forms.Label()
        Me.scrlAddVit = New System.Windows.Forms.HScrollBar()
        Me.lblAddVit = New System.Windows.Forms.Label()
        Me.scrlAddInt = New System.Windows.Forms.HScrollBar()
        Me.lblAddInt = New System.Windows.Forms.Label()
        Me.scrlAddEnd = New System.Windows.Forms.HScrollBar()
        Me.lblAddEnd = New System.Windows.Forms.Label()
        Me.scrlAddLuck = New System.Windows.Forms.HScrollBar()
        Me.lblAddLuck = New System.Windows.Forms.Label()
        Me.scrlAddStr = New System.Windows.Forms.HScrollBar()
        Me.lblAddStr = New System.Windows.Forms.Label()
        Me.scrlSpeed = New System.Windows.Forms.HScrollBar()
        Me.scrlDamage = New System.Windows.Forms.HScrollBar()
        Me.cmbTool = New System.Windows.Forms.ComboBox()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.lblDamage = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.fraSkill = New System.Windows.Forms.GroupBox()
        Me.scrlSkill = New System.Windows.Forms.HScrollBar()
        Me.lblSkill = New System.Windows.Forms.Label()
        Me.lblSkillName = New System.Windows.Forms.Label()
        Me.lblVitalMod = New System.Windows.Forms.Label()
        Me.scrlVitalMod = New System.Windows.Forms.HScrollBar()
        Me.fraVitals = New System.Windows.Forms.GroupBox()
        Me.fraFurniture = New System.Windows.Forms.GroupBox()
        Me.scrlFurniture = New System.Windows.Forms.HScrollBar()
        Me.lblFurniture = New System.Windows.Forms.Label()
        Me.picFurniture = New System.Windows.Forms.PictureBox()
        Me.lblSetOption = New System.Windows.Forms.Label()
        Me.optSetFringe = New System.Windows.Forms.RadioButton()
        Me.optSetBlocks = New System.Windows.Forms.RadioButton()
        Me.optNoFurnitureEditing = New System.Windows.Forms.RadioButton()
        Me.cmbFurnitureType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabInfo = New System.Windows.Forms.TabControl()
        Me.tabPageInfo = New System.Windows.Forms.TabPage()
        Me.lblItemLvl = New System.Windows.Forms.Label()
        Me.scrlItemLevel = New System.Windows.Forms.HScrollBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbSubType = New System.Windows.Forms.ComboBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fraRecipe = New System.Windows.Forms.GroupBox()
        Me.scrlRecipe = New System.Windows.Forms.HScrollBar()
        Me.lblRecipename = New System.Windows.Forms.Label()
        Me.chkStackable = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fraPets = New System.Windows.Forms.GroupBox()
        Me.scrlPetNum = New System.Windows.Forms.HScrollBar()
        Me.lblPetNum = New System.Windows.Forms.Label()
        Me.lblPetName = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraEquipment.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPaperdoll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraSkill.SuspendLayout()
        Me.fraVitals.SuspendLayout()
        Me.fraFurniture.SuspendLayout()
        CType(Me.picFurniture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInfo.SuspendLayout()
        Me.tabPageInfo.SuspendLayout()
        Me.fraRecipe.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.fraPets.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 505)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(8, 16)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(196, 485)
        Me.lstIndex.TabIndex = 0
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"None", "Equipment", "Consumables", "Key", "Currency", "Skill", "Furniture", "Recipe", "Pet"})
        Me.cmbType.Location = New System.Drawing.Point(50, 35)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(171, 21)
        Me.cmbType.TabIndex = 40
        '
        'scrlAnim
        '
        Me.scrlAnim.LargeChange = 1
        Me.scrlAnim.Location = New System.Drawing.Point(94, 112)
        Me.scrlAnim.Name = "scrlAnim"
        Me.scrlAnim.Size = New System.Drawing.Size(127, 19)
        Me.scrlAnim.TabIndex = 39
        '
        'scrlRarity
        '
        Me.scrlRarity.LargeChange = 1
        Me.scrlRarity.Location = New System.Drawing.Point(300, 71)
        Me.scrlRarity.Name = "scrlRarity"
        Me.scrlRarity.Size = New System.Drawing.Size(123, 17)
        Me.scrlRarity.TabIndex = 38
        '
        'cmbBind
        '
        Me.cmbBind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBind.FormattingEnabled = True
        Me.cmbBind.Items.AddRange(New Object() {"None", "Bind on Pickup", "Bind on Equip"})
        Me.cmbBind.Location = New System.Drawing.Point(300, 47)
        Me.cmbBind.Name = "cmbBind"
        Me.cmbBind.Size = New System.Drawing.Size(123, 21)
        Me.cmbBind.TabIndex = 37
        '
        'lblAnim
        '
        Me.lblAnim.AutoSize = True
        Me.lblAnim.Location = New System.Drawing.Point(6, 115)
        Me.lblAnim.Name = "lblAnim"
        Me.lblAnim.Size = New System.Drawing.Size(85, 13)
        Me.lblAnim.TabIndex = 9
        Me.lblAnim.Text = "Animation: None"
        '
        'lblRarity
        '
        Me.lblRarity.AutoSize = True
        Me.lblRarity.Location = New System.Drawing.Point(238, 75)
        Me.lblRarity.Name = "lblRarity"
        Me.lblRarity.Size = New System.Drawing.Size(46, 13)
        Me.lblRarity.TabIndex = 8
        Me.lblRarity.Text = "Rarity: 0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(238, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Bind Type:"
        '
        'picItem
        '
        Me.picItem.BackColor = System.Drawing.Color.Black
        Me.picItem.Location = New System.Drawing.Point(393, 9)
        Me.picItem.Name = "picItem"
        Me.picItem.Size = New System.Drawing.Size(32, 32)
        Me.picItem.TabIndex = 6
        Me.picItem.TabStop = False
        '
        'scrlPic
        '
        Me.scrlPic.Location = New System.Drawing.Point(285, 10)
        Me.scrlPic.Name = "scrlPic"
        Me.scrlPic.Size = New System.Drawing.Size(89, 19)
        Me.scrlPic.TabIndex = 5
        '
        'lblPic
        '
        Me.lblPic.AutoSize = True
        Me.lblPic.Location = New System.Drawing.Point(238, 12)
        Me.lblPic.Name = "lblPic"
        Me.lblPic.Size = New System.Drawing.Size(34, 13)
        Me.lblPic.TabIndex = 4
        Me.lblPic.Text = "Pic: 0"
        '
        'scrlPrice
        '
        Me.scrlPrice.Location = New System.Drawing.Point(78, 86)
        Me.scrlPrice.Maximum = 100000
        Me.scrlPrice.Name = "scrlPrice"
        Me.scrlPrice.Size = New System.Drawing.Size(143, 18)
        Me.scrlPrice.TabIndex = 3
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(6, 86)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(60, 13)
        Me.lblPrice.TabIndex = 2
        Me.lblPrice.Text = "SellPrice: 0"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(50, 9)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(171, 20)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'scrlSprReq
        '
        Me.scrlSprReq.LargeChange = 1
        Me.scrlSprReq.Location = New System.Drawing.Point(272, 217)
        Me.scrlSprReq.Name = "scrlSprReq"
        Me.scrlSprReq.Size = New System.Drawing.Size(84, 15)
        Me.scrlSprReq.TabIndex = 55
        '
        'lblSprReq
        '
        Me.lblSprReq.AutoSize = True
        Me.lblSprReq.Location = New System.Drawing.Point(197, 217)
        Me.lblSprReq.Name = "lblSprReq"
        Me.lblSprReq.Size = New System.Drawing.Size(42, 13)
        Me.lblSprReq.TabIndex = 54
        Me.lblSprReq.Text = "Spirit: 0"
        '
        'scrlVitReq
        '
        Me.scrlVitReq.LargeChange = 1
        Me.scrlVitReq.Location = New System.Drawing.Point(69, 217)
        Me.scrlVitReq.Name = "scrlVitReq"
        Me.scrlVitReq.Size = New System.Drawing.Size(84, 15)
        Me.scrlVitReq.TabIndex = 53
        '
        'lblVitReq
        '
        Me.lblVitReq.AutoSize = True
        Me.lblVitReq.Location = New System.Drawing.Point(7, 217)
        Me.lblVitReq.Name = "lblVitReq"
        Me.lblVitReq.Size = New System.Drawing.Size(49, 13)
        Me.lblVitReq.TabIndex = 52
        Me.lblVitReq.Text = "Vitality: 0"
        '
        'scrlIntReq
        '
        Me.scrlIntReq.LargeChange = 1
        Me.scrlIntReq.Location = New System.Drawing.Point(273, 188)
        Me.scrlIntReq.Name = "scrlIntReq"
        Me.scrlIntReq.Size = New System.Drawing.Size(83, 15)
        Me.scrlIntReq.TabIndex = 51
        '
        'lblIntReq
        '
        Me.lblIntReq.AutoSize = True
        Me.lblIntReq.Location = New System.Drawing.Point(197, 188)
        Me.lblIntReq.Name = "lblIntReq"
        Me.lblIntReq.Size = New System.Drawing.Size(73, 13)
        Me.lblIntReq.TabIndex = 50
        Me.lblIntReq.Text = "Intelligence: 0"
        '
        'scrlEndReq
        '
        Me.scrlEndReq.LargeChange = 1
        Me.scrlEndReq.Location = New System.Drawing.Point(272, 160)
        Me.scrlEndReq.Name = "scrlEndReq"
        Me.scrlEndReq.Size = New System.Drawing.Size(84, 14)
        Me.scrlEndReq.TabIndex = 49
        '
        'lblEndReq
        '
        Me.lblEndReq.AutoSize = True
        Me.lblEndReq.Location = New System.Drawing.Point(197, 161)
        Me.lblEndReq.Name = "lblEndReq"
        Me.lblEndReq.Size = New System.Drawing.Size(71, 13)
        Me.lblEndReq.TabIndex = 48
        Me.lblEndReq.Text = "Endurance: 0"
        '
        'scrlLuckReq
        '
        Me.scrlLuckReq.LargeChange = 1
        Me.scrlLuckReq.Location = New System.Drawing.Point(69, 188)
        Me.scrlLuckReq.Name = "scrlLuckReq"
        Me.scrlLuckReq.Size = New System.Drawing.Size(84, 15)
        Me.scrlLuckReq.TabIndex = 47
        '
        'lblLuckReq
        '
        Me.lblLuckReq.AutoSize = True
        Me.lblLuckReq.Location = New System.Drawing.Point(7, 188)
        Me.lblLuckReq.Name = "lblLuckReq"
        Me.lblLuckReq.Size = New System.Drawing.Size(43, 13)
        Me.lblLuckReq.TabIndex = 46
        Me.lblLuckReq.Text = "Luck: 0"
        '
        'scrlStrReq
        '
        Me.scrlStrReq.LargeChange = 1
        Me.scrlStrReq.Location = New System.Drawing.Point(69, 159)
        Me.scrlStrReq.Name = "scrlStrReq"
        Me.scrlStrReq.Size = New System.Drawing.Size(84, 15)
        Me.scrlStrReq.TabIndex = 45
        '
        'lblStrReq
        '
        Me.lblStrReq.AutoSize = True
        Me.lblStrReq.Location = New System.Drawing.Point(7, 160)
        Me.lblStrReq.Name = "lblStrReq"
        Me.lblStrReq.Size = New System.Drawing.Size(59, 13)
        Me.lblStrReq.TabIndex = 44
        Me.lblStrReq.Text = "Strenght: 0"
        '
        'scrlLevelReq
        '
        Me.scrlLevelReq.LargeChange = 1
        Me.scrlLevelReq.Location = New System.Drawing.Point(150, 77)
        Me.scrlLevelReq.Name = "scrlLevelReq"
        Me.scrlLevelReq.Size = New System.Drawing.Size(273, 20)
        Me.scrlLevelReq.TabIndex = 43
        '
        'scrlAccessReq
        '
        Me.scrlAccessReq.LargeChange = 1
        Me.scrlAccessReq.Location = New System.Drawing.Point(150, 44)
        Me.scrlAccessReq.Name = "scrlAccessReq"
        Me.scrlAccessReq.Size = New System.Drawing.Size(273, 20)
        Me.scrlAccessReq.TabIndex = 42
        '
        'cmbClassReq
        '
        Me.cmbClassReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClassReq.FormattingEnabled = True
        Me.cmbClassReq.Location = New System.Drawing.Point(150, 10)
        Me.cmbClassReq.Name = "cmbClassReq"
        Me.cmbClassReq.Size = New System.Drawing.Size(273, 21)
        Me.cmbClassReq.TabIndex = 41
        '
        'lblLevelReq
        '
        Me.lblLevelReq.AutoSize = True
        Me.lblLevelReq.Location = New System.Drawing.Point(7, 81)
        Me.lblLevelReq.Name = "lblLevelReq"
        Me.lblLevelReq.Size = New System.Drawing.Size(113, 13)
        Me.lblLevelReq.TabIndex = 2
        Me.lblLevelReq.Text = "Level Requirements: 0"
        '
        'lblAccessReq
        '
        Me.lblAccessReq.AutoSize = True
        Me.lblAccessReq.Location = New System.Drawing.Point(6, 47)
        Me.lblAccessReq.Name = "lblAccessReq"
        Me.lblAccessReq.Size = New System.Drawing.Size(122, 13)
        Me.lblAccessReq.TabIndex = 1
        Me.lblAccessReq.Text = "Access Requirements: 0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Class Requirement:"
        '
        'fraEquipment
        '
        Me.fraEquipment.BackColor = System.Drawing.Color.White
        Me.fraEquipment.Controls.Add(Me.GroupBox2)
        Me.fraEquipment.Controls.Add(Me.numMax)
        Me.fraEquipment.Controls.Add(Me.numMin)
        Me.fraEquipment.Controls.Add(Me.chkRandomize)
        Me.fraEquipment.Controls.Add(Me.Label5)
        Me.fraEquipment.Controls.Add(Me.cmbKnockBackTiles)
        Me.fraEquipment.Controls.Add(Me.chkKnockBack)
        Me.fraEquipment.Controls.Add(Me.scrlPaperdoll)
        Me.fraEquipment.Controls.Add(Me.lblPaperDoll)
        Me.fraEquipment.Controls.Add(Me.picPaperdoll)
        Me.fraEquipment.Controls.Add(Me.scrlAddSpr)
        Me.fraEquipment.Controls.Add(Me.lblAddSpr)
        Me.fraEquipment.Controls.Add(Me.scrlAddVit)
        Me.fraEquipment.Controls.Add(Me.lblAddVit)
        Me.fraEquipment.Controls.Add(Me.scrlAddInt)
        Me.fraEquipment.Controls.Add(Me.lblAddInt)
        Me.fraEquipment.Controls.Add(Me.scrlAddEnd)
        Me.fraEquipment.Controls.Add(Me.lblAddEnd)
        Me.fraEquipment.Controls.Add(Me.scrlAddLuck)
        Me.fraEquipment.Controls.Add(Me.lblAddLuck)
        Me.fraEquipment.Controls.Add(Me.scrlAddStr)
        Me.fraEquipment.Controls.Add(Me.lblAddStr)
        Me.fraEquipment.Controls.Add(Me.scrlSpeed)
        Me.fraEquipment.Controls.Add(Me.scrlDamage)
        Me.fraEquipment.Controls.Add(Me.cmbTool)
        Me.fraEquipment.Controls.Add(Me.lblSpeed)
        Me.fraEquipment.Controls.Add(Me.lblDamage)
        Me.fraEquipment.Controls.Add(Me.Label12)
        Me.fraEquipment.Location = New System.Drawing.Point(228, 282)
        Me.fraEquipment.Name = "fraEquipment"
        Me.fraEquipment.Size = New System.Drawing.Size(437, 228)
        Me.fraEquipment.TabIndex = 4
        Me.fraEquipment.TabStop = False
        Me.fraEquipment.Text = "Equipment Data"
        Me.fraEquipment.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.scrlAmmo)
        Me.GroupBox2.Controls.Add(Me.lblAmmo)
        Me.GroupBox2.Controls.Add(Me.scrlProjectile)
        Me.GroupBox2.Controls.Add(Me.lblProjectile)
        Me.GroupBox2.Location = New System.Drawing.Point(251, 126)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 96)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Projectiles"
        '
        'scrlAmmo
        '
        Me.scrlAmmo.LargeChange = 1
        Me.scrlAmmo.Location = New System.Drawing.Point(3, 69)
        Me.scrlAmmo.Name = "scrlAmmo"
        Me.scrlAmmo.Size = New System.Drawing.Size(173, 18)
        Me.scrlAmmo.TabIndex = 64
        '
        'lblAmmo
        '
        Me.lblAmmo.AutoSize = True
        Me.lblAmmo.Location = New System.Drawing.Point(6, 52)
        Me.lblAmmo.Name = "lblAmmo"
        Me.lblAmmo.Size = New System.Drawing.Size(77, 13)
        Me.lblAmmo.TabIndex = 63
        Me.lblAmmo.Text = "Ammo: 0 None"
        '
        'scrlProjectile
        '
        Me.scrlProjectile.LargeChange = 1
        Me.scrlProjectile.Location = New System.Drawing.Point(3, 29)
        Me.scrlProjectile.Name = "scrlProjectile"
        Me.scrlProjectile.Size = New System.Drawing.Size(173, 18)
        Me.scrlProjectile.TabIndex = 62
        '
        'lblProjectile
        '
        Me.lblProjectile.AutoSize = True
        Me.lblProjectile.Location = New System.Drawing.Point(6, 16)
        Me.lblProjectile.Name = "lblProjectile"
        Me.lblProjectile.Size = New System.Drawing.Size(91, 13)
        Me.lblProjectile.TabIndex = 61
        Me.lblProjectile.Text = "Projectile: 0 None"
        '
        'numMax
        '
        Me.numMax.Location = New System.Drawing.Point(515, 170)
        Me.numMax.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numMax.Name = "numMax"
        Me.numMax.Size = New System.Drawing.Size(50, 20)
        Me.numMax.TabIndex = 68
        Me.numMax.Value = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numMax.Visible = False
        '
        'numMin
        '
        Me.numMin.Location = New System.Drawing.Point(452, 170)
        Me.numMin.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMin.Name = "numMin"
        Me.numMin.Size = New System.Drawing.Size(50, 20)
        Me.numMin.TabIndex = 67
        Me.numMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMin.Visible = False
        '
        'chkRandomize
        '
        Me.chkRandomize.AutoSize = True
        Me.chkRandomize.Location = New System.Drawing.Point(6, 127)
        Me.chkRandomize.Name = "chkRandomize"
        Me.chkRandomize.Size = New System.Drawing.Size(106, 17)
        Me.chkRandomize.TabIndex = 66
        Me.chkRandomize.Text = "Randomize Stats"
        Me.chkRandomize.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "X Tiles"
        '
        'cmbKnockBackTiles
        '
        Me.cmbKnockBackTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKnockBackTiles.FormattingEnabled = True
        Me.cmbKnockBackTiles.Items.AddRange(New Object() {"No KnockBack", "1 Tile", "2 Tiles", "3 Tiles", "4 Tiles", "5 Tiles"})
        Me.cmbKnockBackTiles.Location = New System.Drawing.Point(310, 57)
        Me.cmbKnockBackTiles.Name = "cmbKnockBackTiles"
        Me.cmbKnockBackTiles.Size = New System.Drawing.Size(93, 21)
        Me.cmbKnockBackTiles.TabIndex = 64
        '
        'chkKnockBack
        '
        Me.chkKnockBack.AutoSize = True
        Me.chkKnockBack.Location = New System.Drawing.Point(267, 34)
        Me.chkKnockBack.Name = "chkKnockBack"
        Me.chkKnockBack.Size = New System.Drawing.Size(104, 17)
        Me.chkKnockBack.TabIndex = 63
        Me.chkKnockBack.Text = "Has KnockBack"
        Me.chkKnockBack.UseVisualStyleBackColor = True
        '
        'scrlPaperdoll
        '
        Me.scrlPaperdoll.LargeChange = 1
        Me.scrlPaperdoll.Location = New System.Drawing.Point(10, 189)
        Me.scrlPaperdoll.Name = "scrlPaperdoll"
        Me.scrlPaperdoll.Size = New System.Drawing.Size(104, 18)
        Me.scrlPaperdoll.TabIndex = 58
        '
        'lblPaperDoll
        '
        Me.lblPaperDoll.AutoSize = True
        Me.lblPaperDoll.Location = New System.Drawing.Point(10, 169)
        Me.lblPaperDoll.Name = "lblPaperDoll"
        Me.lblPaperDoll.Size = New System.Drawing.Size(63, 13)
        Me.lblPaperDoll.TabIndex = 57
        Me.lblPaperDoll.Text = "Paperdoll: 0"
        '
        'picPaperdoll
        '
        Me.picPaperdoll.BackColor = System.Drawing.Color.Black
        Me.picPaperdoll.Location = New System.Drawing.Point(139, 170)
        Me.picPaperdoll.Name = "picPaperdoll"
        Me.picPaperdoll.Size = New System.Drawing.Size(107, 48)
        Me.picPaperdoll.TabIndex = 56
        Me.picPaperdoll.TabStop = False
        '
        'scrlAddSpr
        '
        Me.scrlAddSpr.LargeChange = 1
        Me.scrlAddSpr.Location = New System.Drawing.Point(360, 107)
        Me.scrlAddSpr.Name = "scrlAddSpr"
        Me.scrlAddSpr.Size = New System.Drawing.Size(73, 15)
        Me.scrlAddSpr.TabIndex = 55
        '
        'lblAddSpr
        '
        Me.lblAddSpr.AutoSize = True
        Me.lblAddSpr.Location = New System.Drawing.Point(307, 108)
        Me.lblAddSpr.Name = "lblAddSpr"
        Me.lblAddSpr.Size = New System.Drawing.Size(48, 13)
        Me.lblAddSpr.TabIndex = 54
        Me.lblAddSpr.Text = "+Spirit: 0"
        '
        'scrlAddVit
        '
        Me.scrlAddVit.LargeChange = 1
        Me.scrlAddVit.Location = New System.Drawing.Point(75, 109)
        Me.scrlAddVit.Name = "scrlAddVit"
        Me.scrlAddVit.Size = New System.Drawing.Size(73, 15)
        Me.scrlAddVit.TabIndex = 53
        '
        'lblAddVit
        '
        Me.lblAddVit.AutoSize = True
        Me.lblAddVit.Location = New System.Drawing.Point(10, 109)
        Me.lblAddVit.Name = "lblAddVit"
        Me.lblAddVit.Size = New System.Drawing.Size(55, 13)
        Me.lblAddVit.TabIndex = 52
        Me.lblAddVit.Text = "+Vitality: 0"
        '
        'scrlAddInt
        '
        Me.scrlAddInt.LargeChange = 1
        Me.scrlAddInt.Location = New System.Drawing.Point(231, 107)
        Me.scrlAddInt.Name = "scrlAddInt"
        Me.scrlAddInt.Size = New System.Drawing.Size(73, 15)
        Me.scrlAddInt.TabIndex = 51
        '
        'lblAddInt
        '
        Me.lblAddInt.AutoSize = True
        Me.lblAddInt.Location = New System.Drawing.Point(151, 108)
        Me.lblAddInt.Name = "lblAddInt"
        Me.lblAddInt.Size = New System.Drawing.Size(79, 13)
        Me.lblAddInt.TabIndex = 50
        Me.lblAddInt.Text = "+Intelligence: 0"
        '
        'scrlAddEnd
        '
        Me.scrlAddEnd.LargeChange = 1
        Me.scrlAddEnd.Location = New System.Drawing.Point(231, 81)
        Me.scrlAddEnd.Name = "scrlAddEnd"
        Me.scrlAddEnd.Size = New System.Drawing.Size(73, 15)
        Me.scrlAddEnd.TabIndex = 49
        '
        'lblAddEnd
        '
        Me.lblAddEnd.AutoSize = True
        Me.lblAddEnd.Location = New System.Drawing.Point(151, 83)
        Me.lblAddEnd.Name = "lblAddEnd"
        Me.lblAddEnd.Size = New System.Drawing.Size(77, 13)
        Me.lblAddEnd.TabIndex = 48
        Me.lblAddEnd.Text = "+Endurance: 0"
        '
        'scrlAddLuck
        '
        Me.scrlAddLuck.LargeChange = 1
        Me.scrlAddLuck.Location = New System.Drawing.Point(360, 81)
        Me.scrlAddLuck.Name = "scrlAddLuck"
        Me.scrlAddLuck.Size = New System.Drawing.Size(69, 15)
        Me.scrlAddLuck.TabIndex = 47
        '
        'lblAddLuck
        '
        Me.lblAddLuck.AutoSize = True
        Me.lblAddLuck.Location = New System.Drawing.Point(307, 83)
        Me.lblAddLuck.Name = "lblAddLuck"
        Me.lblAddLuck.Size = New System.Drawing.Size(49, 13)
        Me.lblAddLuck.TabIndex = 46
        Me.lblAddLuck.Text = "+Luck: 0"
        '
        'scrlAddStr
        '
        Me.scrlAddStr.LargeChange = 1
        Me.scrlAddStr.Location = New System.Drawing.Point(75, 81)
        Me.scrlAddStr.Name = "scrlAddStr"
        Me.scrlAddStr.Size = New System.Drawing.Size(73, 15)
        Me.scrlAddStr.TabIndex = 45
        '
        'lblAddStr
        '
        Me.lblAddStr.AutoSize = True
        Me.lblAddStr.Location = New System.Drawing.Point(7, 83)
        Me.lblAddStr.Name = "lblAddStr"
        Me.lblAddStr.Size = New System.Drawing.Size(65, 13)
        Me.lblAddStr.TabIndex = 44
        Me.lblAddStr.Text = "+Strenght: 0"
        '
        'scrlSpeed
        '
        Me.scrlSpeed.LargeChange = 1
        Me.scrlSpeed.Location = New System.Drawing.Point(102, 42)
        Me.scrlSpeed.Maximum = 2000
        Me.scrlSpeed.Name = "scrlSpeed"
        Me.scrlSpeed.Size = New System.Drawing.Size(156, 19)
        Me.scrlSpeed.TabIndex = 43
        '
        'scrlDamage
        '
        Me.scrlDamage.LargeChange = 1
        Me.scrlDamage.Location = New System.Drawing.Point(326, 13)
        Me.scrlDamage.Name = "scrlDamage"
        Me.scrlDamage.Size = New System.Drawing.Size(103, 18)
        Me.scrlDamage.TabIndex = 42
        '
        'cmbTool
        '
        Me.cmbTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTool.FormattingEnabled = True
        Me.cmbTool.Items.AddRange(New Object() {"None", "Hatchet", "Rod", "Pickaxe"})
        Me.cmbTool.Location = New System.Drawing.Point(102, 13)
        Me.cmbTool.Name = "cmbTool"
        Me.cmbTool.Size = New System.Drawing.Size(156, 21)
        Me.cmbTool.TabIndex = 41
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Location = New System.Drawing.Point(7, 42)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(79, 13)
        Me.lblSpeed.TabIndex = 2
        Me.lblSpeed.Text = "Speed: 0.1 sec"
        '
        'lblDamage
        '
        Me.lblDamage.AutoSize = True
        Me.lblDamage.Location = New System.Drawing.Point(264, 16)
        Me.lblDamage.Name = "lblDamage"
        Me.lblDamage.Size = New System.Drawing.Size(59, 13)
        Me.lblDamage.TabIndex = 1
        Me.lblDamage.Text = "Damage: 0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Object Tool:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(337, 516)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 30)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(444, 516)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(101, 30)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(551, 516)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 30)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'fraSkill
        '
        Me.fraSkill.Controls.Add(Me.scrlSkill)
        Me.fraSkill.Controls.Add(Me.lblSkill)
        Me.fraSkill.Controls.Add(Me.lblSkillName)
        Me.fraSkill.Location = New System.Drawing.Point(227, 134)
        Me.fraSkill.Name = "fraSkill"
        Me.fraSkill.Size = New System.Drawing.Size(198, 70)
        Me.fraSkill.TabIndex = 8
        Me.fraSkill.TabStop = False
        Me.fraSkill.Text = "Skill Data"
        Me.fraSkill.Visible = False
        '
        'scrlSkill
        '
        Me.scrlSkill.Location = New System.Drawing.Point(79, 46)
        Me.scrlSkill.Name = "scrlSkill"
        Me.scrlSkill.Size = New System.Drawing.Size(93, 13)
        Me.scrlSkill.TabIndex = 2
        '
        'lblSkill
        '
        Me.lblSkill.AutoSize = True
        Me.lblSkill.Location = New System.Drawing.Point(10, 46)
        Me.lblSkill.Name = "lblSkill"
        Me.lblSkill.Size = New System.Drawing.Size(41, 13)
        Me.lblSkill.TabIndex = 1
        Me.lblSkill.Text = "Num: 0"
        '
        'lblSkillName
        '
        Me.lblSkillName.AutoSize = True
        Me.lblSkillName.Location = New System.Drawing.Point(10, 22)
        Me.lblSkillName.Name = "lblSkillName"
        Me.lblSkillName.Size = New System.Drawing.Size(67, 13)
        Me.lblSkillName.TabIndex = 0
        Me.lblSkillName.Text = "Name: None"
        '
        'lblVitalMod
        '
        Me.lblVitalMod.AutoSize = True
        Me.lblVitalMod.Location = New System.Drawing.Point(10, 22)
        Me.lblVitalMod.Name = "lblVitalMod"
        Me.lblVitalMod.Size = New System.Drawing.Size(63, 13)
        Me.lblVitalMod.TabIndex = 0
        Me.lblVitalMod.Text = "Vital Mod: 0"
        '
        'scrlVitalMod
        '
        Me.scrlVitalMod.LargeChange = 1
        Me.scrlVitalMod.Location = New System.Drawing.Point(92, 18)
        Me.scrlVitalMod.Name = "scrlVitalMod"
        Me.scrlVitalMod.Size = New System.Drawing.Size(102, 17)
        Me.scrlVitalMod.TabIndex = 2
        '
        'fraVitals
        '
        Me.fraVitals.Controls.Add(Me.scrlVitalMod)
        Me.fraVitals.Controls.Add(Me.lblVitalMod)
        Me.fraVitals.Location = New System.Drawing.Point(227, 130)
        Me.fraVitals.Name = "fraVitals"
        Me.fraVitals.Size = New System.Drawing.Size(200, 45)
        Me.fraVitals.TabIndex = 9
        Me.fraVitals.TabStop = False
        Me.fraVitals.Text = "Vitals"
        Me.fraVitals.Visible = False
        '
        'fraFurniture
        '
        Me.fraFurniture.Controls.Add(Me.scrlFurniture)
        Me.fraFurniture.Controls.Add(Me.lblFurniture)
        Me.fraFurniture.Controls.Add(Me.picFurniture)
        Me.fraFurniture.Controls.Add(Me.lblSetOption)
        Me.fraFurniture.Controls.Add(Me.optSetFringe)
        Me.fraFurniture.Controls.Add(Me.optSetBlocks)
        Me.fraFurniture.Controls.Add(Me.optNoFurnitureEditing)
        Me.fraFurniture.Controls.Add(Me.cmbFurnitureType)
        Me.fraFurniture.Controls.Add(Me.Label4)
        Me.fraFurniture.Location = New System.Drawing.Point(228, 282)
        Me.fraFurniture.Name = "fraFurniture"
        Me.fraFurniture.Size = New System.Drawing.Size(437, 213)
        Me.fraFurniture.TabIndex = 10
        Me.fraFurniture.TabStop = False
        Me.fraFurniture.Text = "Furniture"
        Me.fraFurniture.Visible = False
        '
        'scrlFurniture
        '
        Me.scrlFurniture.LargeChange = 1
        Me.scrlFurniture.Location = New System.Drawing.Point(249, 191)
        Me.scrlFurniture.Name = "scrlFurniture"
        Me.scrlFurniture.Size = New System.Drawing.Size(150, 18)
        Me.scrlFurniture.TabIndex = 8
        '
        'lblFurniture
        '
        Me.lblFurniture.AutoSize = True
        Me.lblFurniture.Location = New System.Drawing.Point(246, 170)
        Me.lblFurniture.Name = "lblFurniture"
        Me.lblFurniture.Size = New System.Drawing.Size(60, 13)
        Me.lblFurniture.TabIndex = 7
        Me.lblFurniture.Text = "Furniture: 1"
        '
        'picFurniture
        '
        Me.picFurniture.BackColor = System.Drawing.Color.Black
        Me.picFurniture.Location = New System.Drawing.Point(249, 13)
        Me.picFurniture.Name = "picFurniture"
        Me.picFurniture.Size = New System.Drawing.Size(150, 150)
        Me.picFurniture.TabIndex = 6
        Me.picFurniture.TabStop = False
        '
        'lblSetOption
        '
        Me.lblSetOption.Location = New System.Drawing.Point(12, 145)
        Me.lblSetOption.Name = "lblSetOption"
        Me.lblSetOption.Size = New System.Drawing.Size(189, 62)
        Me.lblSetOption.TabIndex = 5
        Me.lblSetOption.Text = "Set Blocks: Os are passable and Xs are not. Simply place Xs where you do not want" &
    " the player to walk."
        '
        'optSetFringe
        '
        Me.optSetFringe.AutoSize = True
        Me.optSetFringe.Location = New System.Drawing.Point(13, 119)
        Me.optSetFringe.Name = "optSetFringe"
        Me.optSetFringe.Size = New System.Drawing.Size(73, 17)
        Me.optSetFringe.TabIndex = 4
        Me.optSetFringe.Text = "Set Fringe"
        Me.optSetFringe.UseVisualStyleBackColor = True
        '
        'optSetBlocks
        '
        Me.optSetBlocks.AutoSize = True
        Me.optSetBlocks.Checked = True
        Me.optSetBlocks.Location = New System.Drawing.Point(13, 96)
        Me.optSetBlocks.Name = "optSetBlocks"
        Me.optSetBlocks.Size = New System.Drawing.Size(76, 17)
        Me.optSetBlocks.TabIndex = 3
        Me.optSetBlocks.TabStop = True
        Me.optSetBlocks.Text = "Set Blocks"
        Me.optSetBlocks.UseVisualStyleBackColor = True
        '
        'optNoFurnitureEditing
        '
        Me.optNoFurnitureEditing.AutoSize = True
        Me.optNoFurnitureEditing.Location = New System.Drawing.Point(13, 73)
        Me.optNoFurnitureEditing.Name = "optNoFurnitureEditing"
        Me.optNoFurnitureEditing.Size = New System.Drawing.Size(74, 17)
        Me.optNoFurnitureEditing.TabIndex = 2
        Me.optNoFurnitureEditing.Text = "No Editing"
        Me.optNoFurnitureEditing.UseVisualStyleBackColor = True
        '
        'cmbFurnitureType
        '
        Me.cmbFurnitureType.FormattingEnabled = True
        Me.cmbFurnitureType.Items.AddRange(New Object() {"Standard"})
        Me.cmbFurnitureType.Location = New System.Drawing.Point(13, 46)
        Me.cmbFurnitureType.Name = "cmbFurnitureType"
        Me.cmbFurnitureType.Size = New System.Drawing.Size(188, 21)
        Me.cmbFurnitureType.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Furniture Type:"
        '
        'tabInfo
        '
        Me.tabInfo.Controls.Add(Me.tabPageInfo)
        Me.tabInfo.Controls.Add(Me.TabPage2)
        Me.tabInfo.Location = New System.Drawing.Point(228, 5)
        Me.tabInfo.Name = "tabInfo"
        Me.tabInfo.SelectedIndex = 0
        Me.tabInfo.Size = New System.Drawing.Size(437, 271)
        Me.tabInfo.TabIndex = 11
        '
        'tabPageInfo
        '
        Me.tabPageInfo.Controls.Add(Me.fraPets)
        Me.tabPageInfo.Controls.Add(Me.lblItemLvl)
        Me.tabPageInfo.Controls.Add(Me.scrlItemLevel)
        Me.tabPageInfo.Controls.Add(Me.Label9)
        Me.tabPageInfo.Controls.Add(Me.cmbSubType)
        Me.tabPageInfo.Controls.Add(Me.fraSkill)
        Me.tabPageInfo.Controls.Add(Me.txtDescription)
        Me.tabPageInfo.Controls.Add(Me.Label8)
        Me.tabPageInfo.Controls.Add(Me.fraRecipe)
        Me.tabPageInfo.Controls.Add(Me.chkStackable)
        Me.tabPageInfo.Controls.Add(Me.fraVitals)
        Me.tabPageInfo.Controls.Add(Me.Label6)
        Me.tabPageInfo.Controls.Add(Me.Label1)
        Me.tabPageInfo.Controls.Add(Me.Label2)
        Me.tabPageInfo.Controls.Add(Me.cmbType)
        Me.tabPageInfo.Controls.Add(Me.scrlPic)
        Me.tabPageInfo.Controls.Add(Me.picItem)
        Me.tabPageInfo.Controls.Add(Me.txtName)
        Me.tabPageInfo.Controls.Add(Me.lblRarity)
        Me.tabPageInfo.Controls.Add(Me.lblPic)
        Me.tabPageInfo.Controls.Add(Me.scrlAnim)
        Me.tabPageInfo.Controls.Add(Me.lblAnim)
        Me.tabPageInfo.Controls.Add(Me.scrlPrice)
        Me.tabPageInfo.Controls.Add(Me.cmbBind)
        Me.tabPageInfo.Controls.Add(Me.scrlRarity)
        Me.tabPageInfo.Controls.Add(Me.lblPrice)
        Me.tabPageInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabPageInfo.Name = "tabPageInfo"
        Me.tabPageInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageInfo.Size = New System.Drawing.Size(429, 245)
        Me.tabPageInfo.TabIndex = 0
        Me.tabPageInfo.Text = "Info"
        Me.tabPageInfo.UseVisualStyleBackColor = True
        '
        'lblItemLvl
        '
        Me.lblItemLvl.AutoSize = True
        Me.lblItemLvl.Location = New System.Drawing.Point(239, 115)
        Me.lblItemLvl.Name = "lblItemLvl"
        Me.lblItemLvl.Size = New System.Drawing.Size(59, 13)
        Me.lblItemLvl.TabIndex = 75
        Me.lblItemLvl.Text = "Item Level:"
        '
        'scrlItemLevel
        '
        Me.scrlItemLevel.Location = New System.Drawing.Point(326, 111)
        Me.scrlItemLevel.Minimum = 1
        Me.scrlItemLevel.Name = "scrlItemLevel"
        Me.scrlItemLevel.Size = New System.Drawing.Size(97, 19)
        Me.scrlItemLevel.TabIndex = 74
        Me.scrlItemLevel.Value = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "SubType:"
        '
        'cmbSubType
        '
        Me.cmbSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubType.FormattingEnabled = True
        Me.cmbSubType.Items.AddRange(New Object() {"None", "Weapon", "Armor", "Helmet", "Shield", "Shoes", "Gloves", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Key", "Currency", "Skill", "Furniture", "Recipe"})
        Me.cmbSubType.Location = New System.Drawing.Point(65, 60)
        Me.cmbSubType.Name = "cmbSubType"
        Me.cmbSubType.Size = New System.Drawing.Size(156, 21)
        Me.cmbSubType.TabIndex = 72
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(9, 156)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(212, 80)
        Me.txtDescription.TabIndex = 71
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Item Description"
        '
        'fraRecipe
        '
        Me.fraRecipe.Controls.Add(Me.scrlRecipe)
        Me.fraRecipe.Controls.Add(Me.lblRecipename)
        Me.fraRecipe.Location = New System.Drawing.Point(227, 180)
        Me.fraRecipe.Name = "fraRecipe"
        Me.fraRecipe.Size = New System.Drawing.Size(198, 56)
        Me.fraRecipe.TabIndex = 69
        Me.fraRecipe.TabStop = False
        Me.fraRecipe.Text = "Recipe"
        Me.fraRecipe.Visible = False
        '
        'scrlRecipe
        '
        Me.scrlRecipe.Location = New System.Drawing.Point(3, 29)
        Me.scrlRecipe.Name = "scrlRecipe"
        Me.scrlRecipe.Size = New System.Drawing.Size(190, 15)
        Me.scrlRecipe.TabIndex = 4
        '
        'lblRecipename
        '
        Me.lblRecipename.AutoSize = True
        Me.lblRecipename.Location = New System.Drawing.Point(6, 16)
        Me.lblRecipename.Name = "lblRecipename"
        Me.lblRecipename.Size = New System.Drawing.Size(67, 13)
        Me.lblRecipename.TabIndex = 1
        Me.lblRecipename.Text = "Name: None"
        '
        'chkStackable
        '
        Me.chkStackable.AutoSize = True
        Me.chkStackable.Location = New System.Drawing.Point(300, 91)
        Me.chkStackable.Name = "chkStackable"
        Me.chkStackable.Size = New System.Drawing.Size(74, 17)
        Me.chkStackable.TabIndex = 67
        Me.chkStackable.Text = "Stackable"
        Me.chkStackable.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Type:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.scrlSprReq)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.lblSprReq)
        Me.TabPage2.Controls.Add(Me.lblAccessReq)
        Me.TabPage2.Controls.Add(Me.scrlVitReq)
        Me.TabPage2.Controls.Add(Me.lblLevelReq)
        Me.TabPage2.Controls.Add(Me.lblVitReq)
        Me.TabPage2.Controls.Add(Me.cmbClassReq)
        Me.TabPage2.Controls.Add(Me.scrlIntReq)
        Me.TabPage2.Controls.Add(Me.scrlAccessReq)
        Me.TabPage2.Controls.Add(Me.lblIntReq)
        Me.TabPage2.Controls.Add(Me.scrlLevelReq)
        Me.TabPage2.Controls.Add(Me.scrlEndReq)
        Me.TabPage2.Controls.Add(Me.lblStrReq)
        Me.TabPage2.Controls.Add(Me.lblEndReq)
        Me.TabPage2.Controls.Add(Me.scrlStrReq)
        Me.TabPage2.Controls.Add(Me.scrlLuckReq)
        Me.TabPage2.Controls.Add(Me.lblLuckReq)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(429, 245)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Requirements"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Stat Requirements"
        '
        'fraPets
        '
        Me.fraPets.Controls.Add(Me.scrlPetNum)
        Me.fraPets.Controls.Add(Me.lblPetNum)
        Me.fraPets.Controls.Add(Me.lblPetName)
        Me.fraPets.Location = New System.Drawing.Point(228, 157)
        Me.fraPets.Name = "fraPets"
        Me.fraPets.Size = New System.Drawing.Size(198, 70)
        Me.fraPets.TabIndex = 76
        Me.fraPets.TabStop = False
        Me.fraPets.Text = "Pets"
        Me.fraPets.Visible = False
        '
        'scrlPetNum
        '
        Me.scrlPetNum.Location = New System.Drawing.Point(79, 46)
        Me.scrlPetNum.Name = "scrlPetNum"
        Me.scrlPetNum.Size = New System.Drawing.Size(93, 13)
        Me.scrlPetNum.TabIndex = 2
        '
        'lblPetNum
        '
        Me.lblPetNum.AutoSize = True
        Me.lblPetNum.Location = New System.Drawing.Point(10, 46)
        Me.lblPetNum.Name = "lblPetNum"
        Me.lblPetNum.Size = New System.Drawing.Size(41, 13)
        Me.lblPetNum.TabIndex = 1
        Me.lblPetNum.Text = "Num: 0"
        '
        'lblPetName
        '
        Me.lblPetName.AutoSize = True
        Me.lblPetName.Location = New System.Drawing.Point(10, 22)
        Me.lblPetName.Name = "lblPetName"
        Me.lblPetName.Size = New System.Drawing.Size(67, 13)
        Me.lblPetName.TabIndex = 0
        Me.lblPetName.Text = "Name: None"
        '
        'frmEditor_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 551)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabInfo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fraEquipment)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraFurniture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Item"
        Me.Text = "Item Editor"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraEquipment.ResumeLayout(False)
        Me.fraEquipment.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPaperdoll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraSkill.ResumeLayout(False)
        Me.fraSkill.PerformLayout()
        Me.fraVitals.ResumeLayout(False)
        Me.fraVitals.PerformLayout()
        Me.fraFurniture.ResumeLayout(False)
        Me.fraFurniture.PerformLayout()
        CType(Me.picFurniture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInfo.ResumeLayout(False)
        Me.tabPageInfo.ResumeLayout(False)
        Me.tabPageInfo.PerformLayout()
        Me.fraRecipe.ResumeLayout(False)
        Me.fraRecipe.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.fraPets.ResumeLayout(False)
        Me.fraPets.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents picItem As System.Windows.Forms.PictureBox
    Friend WithEvents scrlPic As System.Windows.Forms.HScrollBar
    Friend WithEvents lblPic As System.Windows.Forms.Label
    Friend WithEvents scrlPrice As System.Windows.Forms.HScrollBar
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAnim As System.Windows.Forms.Label
    Friend WithEvents lblRarity As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents scrlAnim As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlRarity As System.Windows.Forms.HScrollBar
    Friend WithEvents cmbBind As System.Windows.Forms.ComboBox
    Friend WithEvents scrlLevelReq As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlAccessReq As System.Windows.Forms.HScrollBar
    Friend WithEvents cmbClassReq As System.Windows.Forms.ComboBox
    Friend WithEvents lblLevelReq As System.Windows.Forms.Label
    Friend WithEvents lblAccessReq As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblStrReq As System.Windows.Forms.Label
    Friend WithEvents scrlStrReq As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlSprReq As System.Windows.Forms.HScrollBar
    Friend WithEvents lblSprReq As System.Windows.Forms.Label
    Friend WithEvents scrlVitReq As System.Windows.Forms.HScrollBar
    Friend WithEvents lblVitReq As System.Windows.Forms.Label
    Friend WithEvents scrlIntReq As System.Windows.Forms.HScrollBar
    Friend WithEvents lblIntReq As System.Windows.Forms.Label
    Friend WithEvents scrlEndReq As System.Windows.Forms.HScrollBar
    Friend WithEvents lblEndReq As System.Windows.Forms.Label
    Friend WithEvents scrlLuckReq As System.Windows.Forms.HScrollBar
    Friend WithEvents lblLuckReq As System.Windows.Forms.Label
    Friend WithEvents fraEquipment As System.Windows.Forms.GroupBox
    Friend WithEvents scrlAddSpr As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddSpr As System.Windows.Forms.Label
    Friend WithEvents scrlAddVit As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddVit As System.Windows.Forms.Label
    Friend WithEvents scrlAddInt As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddInt As System.Windows.Forms.Label
    Friend WithEvents scrlAddEnd As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddEnd As System.Windows.Forms.Label
    Friend WithEvents scrlAddLuck As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddLuck As System.Windows.Forms.Label
    Friend WithEvents scrlAddStr As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddStr As System.Windows.Forms.Label
    Friend WithEvents scrlSpeed As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlDamage As System.Windows.Forms.HScrollBar
    Friend WithEvents cmbTool As System.Windows.Forms.ComboBox
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents lblDamage As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents picPaperdoll As System.Windows.Forms.PictureBox
    Friend WithEvents scrlPaperdoll As System.Windows.Forms.HScrollBar
    Friend WithEvents lblPaperDoll As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents fraSkill As System.Windows.Forms.GroupBox
    Friend WithEvents scrlSkill As System.Windows.Forms.HScrollBar
    Friend WithEvents lblSkill As System.Windows.Forms.Label
    Friend WithEvents lblSkillName As System.Windows.Forms.Label
    Friend WithEvents lblVitalMod As System.Windows.Forms.Label
    Friend WithEvents scrlVitalMod As System.Windows.Forms.HScrollBar
    Friend WithEvents fraVitals As System.Windows.Forms.GroupBox
    Friend WithEvents fraFurniture As System.Windows.Forms.GroupBox
    Friend WithEvents scrlFurniture As System.Windows.Forms.HScrollBar
    Friend WithEvents lblFurniture As System.Windows.Forms.Label
    Friend WithEvents picFurniture As System.Windows.Forms.PictureBox
    Friend WithEvents lblSetOption As System.Windows.Forms.Label
    Friend WithEvents optSetFringe As System.Windows.Forms.RadioButton
    Friend WithEvents optSetBlocks As System.Windows.Forms.RadioButton
    Friend WithEvents optNoFurnitureEditing As System.Windows.Forms.RadioButton
    Friend WithEvents cmbFurnitureType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents scrlProjectile As System.Windows.Forms.HScrollBar
    Friend WithEvents lblProjectile As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbKnockBackTiles As System.Windows.Forms.ComboBox
    Friend WithEvents chkKnockBack As System.Windows.Forms.CheckBox
    Friend WithEvents tabInfo As System.Windows.Forms.TabControl
    Friend WithEvents tabPageInfo As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkRandomize As System.Windows.Forms.CheckBox
    Friend WithEvents chkStackable As System.Windows.Forms.CheckBox
    Friend WithEvents fraRecipe As System.Windows.Forms.GroupBox
    Friend WithEvents scrlRecipe As System.Windows.Forms.HScrollBar
    Friend WithEvents lblRecipename As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbSubType As ComboBox
    Friend WithEvents lblItemLvl As Label
    Friend WithEvents scrlItemLevel As HScrollBar
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents scrlAmmo As HScrollBar
    Friend WithEvents lblAmmo As Label
    Friend WithEvents fraPets As GroupBox
    Friend WithEvents scrlPetNum As HScrollBar
    Friend WithEvents lblPetNum As Label
    Friend WithEvents lblPetName As Label
End Class
