<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Classes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditor_Classes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblFemaleSprite = New System.Windows.Forms.Label()
        Me.cmbFemaleSprite = New System.Windows.Forms.ComboBox()
        Me.btnAddFemaleSprite = New System.Windows.Forms.Button()
        Me.picFemale = New System.Windows.Forms.PictureBox()
        Me.btnDeleteFemaleSprite = New System.Windows.Forms.Button()
        Me.scrlFemaleSprite = New System.Windows.Forms.HScrollBar()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblMaleSprite = New System.Windows.Forms.Label()
        Me.cmbMaleSprite = New System.Windows.Forms.ComboBox()
        Me.picMale = New System.Windows.Forms.PictureBox()
        Me.scrlMaleSprite = New System.Windows.Forms.HScrollBar()
        Me.btnDeleteMaleSprite = New System.Windows.Forms.Button()
        Me.btnAddMaleSprite = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.numStartY = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numStartX = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numStartMap = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.numBaseExp = New System.Windows.Forms.NumericUpDown()
        Me.numSpirit = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numIntelligence = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numLuck = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numVitality = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numEndurance = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numStrength = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnItemAdd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numItemAmount = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbItems = New System.Windows.Forms.ComboBox()
        Me.lstStartItems = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnAddClass = New System.Windows.Forms.Button()
        Me.btnRemoveClass = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.picFemale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.picMale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.numStartY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.numBaseExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSpirit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIntelligence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLuck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVitality, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numEndurance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.numItemAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(177, 196)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Class List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(8, 16)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(162, 173)
        Me.lstIndex.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(1, 439)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(177, 30)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1, 403)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(177, 30)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDescription)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Location = New System.Drawing.Point(184, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 468)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Info"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(75, 39)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(259, 28)
        Me.txtDescription.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Description:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblFemaleSprite)
        Me.GroupBox7.Controls.Add(Me.cmbFemaleSprite)
        Me.GroupBox7.Controls.Add(Me.btnAddFemaleSprite)
        Me.GroupBox7.Controls.Add(Me.picFemale)
        Me.GroupBox7.Controls.Add(Me.btnDeleteFemaleSprite)
        Me.GroupBox7.Controls.Add(Me.scrlFemaleSprite)
        Me.GroupBox7.Location = New System.Drawing.Point(173, 73)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(161, 116)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Female Sprite"
        '
        'lblFemaleSprite
        '
        Me.lblFemaleSprite.AutoSize = True
        Me.lblFemaleSprite.Location = New System.Drawing.Point(3, 50)
        Me.lblFemaleSprite.Name = "lblFemaleSprite"
        Me.lblFemaleSprite.Size = New System.Drawing.Size(46, 13)
        Me.lblFemaleSprite.TabIndex = 20
        Me.lblFemaleSprite.Text = "Sprite: 1"
        '
        'cmbFemaleSprite
        '
        Me.cmbFemaleSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFemaleSprite.FormattingEnabled = True
        Me.cmbFemaleSprite.Location = New System.Drawing.Point(6, 89)
        Me.cmbFemaleSprite.Name = "cmbFemaleSprite"
        Me.cmbFemaleSprite.Size = New System.Drawing.Size(144, 21)
        Me.cmbFemaleSprite.TabIndex = 19
        '
        'btnAddFemaleSprite
        '
        Me.btnAddFemaleSprite.Image = CType(resources.GetObject("btnAddFemaleSprite.Image"), System.Drawing.Image)
        Me.btnAddFemaleSprite.Location = New System.Drawing.Point(6, 16)
        Me.btnAddFemaleSprite.Name = "btnAddFemaleSprite"
        Me.btnAddFemaleSprite.Size = New System.Drawing.Size(24, 23)
        Me.btnAddFemaleSprite.TabIndex = 17
        Me.btnAddFemaleSprite.UseVisualStyleBackColor = True
        '
        'picFemale
        '
        Me.picFemale.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.picFemale.Location = New System.Drawing.Point(107, 16)
        Me.picFemale.Name = "picFemale"
        Me.picFemale.Size = New System.Drawing.Size(48, 64)
        Me.picFemale.TabIndex = 8
        Me.picFemale.TabStop = False
        '
        'btnDeleteFemaleSprite
        '
        Me.btnDeleteFemaleSprite.Image = CType(resources.GetObject("btnDeleteFemaleSprite.Image"), System.Drawing.Image)
        Me.btnDeleteFemaleSprite.Location = New System.Drawing.Point(36, 16)
        Me.btnDeleteFemaleSprite.Name = "btnDeleteFemaleSprite"
        Me.btnDeleteFemaleSprite.Size = New System.Drawing.Size(24, 23)
        Me.btnDeleteFemaleSprite.TabIndex = 18
        Me.btnDeleteFemaleSprite.UseVisualStyleBackColor = True
        '
        'scrlFemaleSprite
        '
        Me.scrlFemaleSprite.LargeChange = 1
        Me.scrlFemaleSprite.Location = New System.Drawing.Point(6, 63)
        Me.scrlFemaleSprite.Name = "scrlFemaleSprite"
        Me.scrlFemaleSprite.Size = New System.Drawing.Size(98, 17)
        Me.scrlFemaleSprite.TabIndex = 10
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblMaleSprite)
        Me.GroupBox6.Controls.Add(Me.cmbMaleSprite)
        Me.GroupBox6.Controls.Add(Me.picMale)
        Me.GroupBox6.Controls.Add(Me.scrlMaleSprite)
        Me.GroupBox6.Controls.Add(Me.btnDeleteMaleSprite)
        Me.GroupBox6.Controls.Add(Me.btnAddMaleSprite)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 73)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(161, 116)
        Me.GroupBox6.TabIndex = 19
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Male Sprite"
        '
        'lblMaleSprite
        '
        Me.lblMaleSprite.AutoSize = True
        Me.lblMaleSprite.Location = New System.Drawing.Point(3, 50)
        Me.lblMaleSprite.Name = "lblMaleSprite"
        Me.lblMaleSprite.Size = New System.Drawing.Size(46, 13)
        Me.lblMaleSprite.TabIndex = 18
        Me.lblMaleSprite.Text = "Sprite: 1"
        '
        'cmbMaleSprite
        '
        Me.cmbMaleSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaleSprite.FormattingEnabled = True
        Me.cmbMaleSprite.Location = New System.Drawing.Point(6, 89)
        Me.cmbMaleSprite.Name = "cmbMaleSprite"
        Me.cmbMaleSprite.Size = New System.Drawing.Size(149, 21)
        Me.cmbMaleSprite.TabIndex = 17
        '
        'picMale
        '
        Me.picMale.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.picMale.Location = New System.Drawing.Point(107, 16)
        Me.picMale.Name = "picMale"
        Me.picMale.Size = New System.Drawing.Size(48, 64)
        Me.picMale.TabIndex = 7
        Me.picMale.TabStop = False
        '
        'scrlMaleSprite
        '
        Me.scrlMaleSprite.LargeChange = 1
        Me.scrlMaleSprite.Location = New System.Drawing.Point(6, 63)
        Me.scrlMaleSprite.Name = "scrlMaleSprite"
        Me.scrlMaleSprite.Size = New System.Drawing.Size(98, 17)
        Me.scrlMaleSprite.TabIndex = 9
        '
        'btnDeleteMaleSprite
        '
        Me.btnDeleteMaleSprite.Image = CType(resources.GetObject("btnDeleteMaleSprite.Image"), System.Drawing.Image)
        Me.btnDeleteMaleSprite.Location = New System.Drawing.Point(36, 17)
        Me.btnDeleteMaleSprite.Name = "btnDeleteMaleSprite"
        Me.btnDeleteMaleSprite.Size = New System.Drawing.Size(24, 23)
        Me.btnDeleteMaleSprite.TabIndex = 16
        Me.btnDeleteMaleSprite.UseVisualStyleBackColor = True
        '
        'btnAddMaleSprite
        '
        Me.btnAddMaleSprite.Image = CType(resources.GetObject("btnAddMaleSprite.Image"), System.Drawing.Image)
        Me.btnAddMaleSprite.Location = New System.Drawing.Point(6, 17)
        Me.btnAddMaleSprite.Name = "btnAddMaleSprite"
        Me.btnAddMaleSprite.Size = New System.Drawing.Size(24, 23)
        Me.btnAddMaleSprite.TabIndex = 15
        Me.btnAddMaleSprite.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.numStartY)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.numStartX)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.numStartMap)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 413)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(328, 49)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Start Map"
        '
        'numStartY
        '
        Me.numStartY.Location = New System.Drawing.Point(241, 19)
        Me.numStartY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartY.Name = "numStartY"
        Me.numStartY.Size = New System.Drawing.Size(41, 20)
        Me.numStartY.TabIndex = 5
        Me.numStartY.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(218, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Y:"
        '
        'numStartX
        '
        Me.numStartX.Location = New System.Drawing.Point(162, 19)
        Me.numStartX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartX.Name = "numStartX"
        Me.numStartX.Size = New System.Drawing.Size(41, 20)
        Me.numStartX.TabIndex = 3
        Me.numStartX.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(139, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "X:"
        '
        'numStartMap
        '
        Me.numStartMap.Location = New System.Drawing.Point(70, 19)
        Me.numStartMap.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartMap.Name = "numStartMap"
        Me.numStartMap.Size = New System.Drawing.Size(63, 20)
        Me.numStartMap.TabIndex = 1
        Me.numStartMap.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Start Map:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.numBaseExp)
        Me.GroupBox4.Controls.Add(Me.numSpirit)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.numIntelligence)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.numLuck)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.numVitality)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.numEndurance)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.numStrength)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 190)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(328, 100)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Start Stats"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Base Exp:"
        '
        'numBaseExp
        '
        Me.numBaseExp.Location = New System.Drawing.Point(69, 74)
        Me.numBaseExp.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numBaseExp.Name = "numBaseExp"
        Me.numBaseExp.Size = New System.Drawing.Size(75, 20)
        Me.numBaseExp.TabIndex = 12
        Me.numBaseExp.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'numSpirit
        '
        Me.numSpirit.Location = New System.Drawing.Point(259, 39)
        Me.numSpirit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSpirit.Name = "numSpirit"
        Me.numSpirit.Size = New System.Drawing.Size(35, 20)
        Me.numSpirit.TabIndex = 11
        Me.numSpirit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(191, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Spirit:"
        '
        'numIntelligence
        '
        Me.numIntelligence.Location = New System.Drawing.Point(69, 39)
        Me.numIntelligence.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numIntelligence.Name = "numIntelligence"
        Me.numIntelligence.Size = New System.Drawing.Size(35, 20)
        Me.numIntelligence.TabIndex = 9
        Me.numIntelligence.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Intelligence:"
        '
        'numLuck
        '
        Me.numLuck.Location = New System.Drawing.Point(150, 14)
        Me.numLuck.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLuck.Name = "numLuck"
        Me.numLuck.Size = New System.Drawing.Size(35, 20)
        Me.numLuck.TabIndex = 7
        Me.numLuck.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(110, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Luck:"
        '
        'numVitality
        '
        Me.numVitality.Location = New System.Drawing.Point(150, 39)
        Me.numVitality.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numVitality.Name = "numVitality"
        Me.numVitality.Size = New System.Drawing.Size(35, 20)
        Me.numVitality.TabIndex = 5
        Me.numVitality.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(110, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Vitality:"
        '
        'numEndurance
        '
        Me.numEndurance.Location = New System.Drawing.Point(259, 14)
        Me.numEndurance.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numEndurance.Name = "numEndurance"
        Me.numEndurance.Size = New System.Drawing.Size(35, 20)
        Me.numEndurance.TabIndex = 3
        Me.numEndurance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(191, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Endurance:"
        '
        'numStrength
        '
        Me.numStrength.Location = New System.Drawing.Point(69, 14)
        Me.numStrength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStrength.Name = "numStrength"
        Me.numStrength.Size = New System.Drawing.Size(35, 20)
        Me.numStrength.TabIndex = 1
        Me.numStrength.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Strength:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnItemAdd)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.numItemAmount)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cmbItems)
        Me.GroupBox3.Controls.Add(Me.lstStartItems)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 296)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(328, 111)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Starting Items"
        '
        'btnItemAdd
        '
        Me.btnItemAdd.Location = New System.Drawing.Point(183, 78)
        Me.btnItemAdd.Name = "btnItemAdd"
        Me.btnItemAdd.Size = New System.Drawing.Size(139, 23)
        Me.btnItemAdd.TabIndex = 5
        Me.btnItemAdd.Text = "Update List"
        Me.btnItemAdd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Amount:"
        '
        'numItemAmount
        '
        Me.numItemAmount.Location = New System.Drawing.Point(276, 52)
        Me.numItemAmount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numItemAmount.Name = "numItemAmount"
        Me.numItemAmount.Size = New System.Drawing.Size(46, 20)
        Me.numItemAmount.TabIndex = 3
        Me.numItemAmount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(183, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Start Item"
        '
        'cmbItems
        '
        Me.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItems.FormattingEnabled = True
        Me.cmbItems.Location = New System.Drawing.Point(183, 25)
        Me.cmbItems.Name = "cmbItems"
        Me.cmbItems.Size = New System.Drawing.Size(139, 21)
        Me.cmbItems.TabIndex = 1
        '
        'lstStartItems
        '
        Me.lstStartItems.FormattingEnabled = True
        Me.lstStartItems.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.lstStartItems.Location = New System.Drawing.Point(6, 19)
        Me.lstStartItems.Name = "lstStartItems"
        Me.lstStartItems.Size = New System.Drawing.Size(171, 82)
        Me.lstStartItems.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(50, 13)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(284, 20)
        Me.txtName.TabIndex = 3
        '
        'btnAddClass
        '
        Me.btnAddClass.Location = New System.Drawing.Point(1, 203)
        Me.btnAddClass.Name = "btnAddClass"
        Me.btnAddClass.Size = New System.Drawing.Size(177, 30)
        Me.btnAddClass.TabIndex = 15
        Me.btnAddClass.Text = "Add Class"
        Me.btnAddClass.UseVisualStyleBackColor = True
        '
        'btnRemoveClass
        '
        Me.btnRemoveClass.Location = New System.Drawing.Point(1, 239)
        Me.btnRemoveClass.Name = "btnRemoveClass"
        Me.btnRemoveClass.Size = New System.Drawing.Size(177, 30)
        Me.btnRemoveClass.TabIndex = 16
        Me.btnRemoveClass.Text = "Remove Class"
        Me.btnRemoveClass.UseVisualStyleBackColor = True
        '
        'frmEditor_Classes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 477)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRemoveClass)
        Me.Controls.Add(Me.btnAddClass)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Classes"
        Me.Text = "Class Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.picFemale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.picMale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.numStartY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.numBaseExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSpirit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIntelligence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLuck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVitality, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numEndurance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStrength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.numItemAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnItemAdd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numItemAmount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbItems As System.Windows.Forms.ComboBox
    Friend WithEvents lstStartItems As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents scrlFemaleSprite As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMaleSprite As System.Windows.Forms.HScrollBar
    Friend WithEvents picFemale As System.Windows.Forms.PictureBox
    Friend WithEvents picMale As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numStrength As System.Windows.Forms.NumericUpDown
    Friend WithEvents numVitality As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numEndurance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numSpirit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numIntelligence As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numLuck As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents numStartY As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numStartX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numStartMap As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAddClass As System.Windows.Forms.Button
    Friend WithEvents btnRemoveClass As System.Windows.Forms.Button
    Friend WithEvents btnDeleteMaleSprite As System.Windows.Forms.Button
    Friend WithEvents btnAddMaleSprite As System.Windows.Forms.Button
    Friend WithEvents btnDeleteFemaleSprite As System.Windows.Forms.Button
    Friend WithEvents btnAddFemaleSprite As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFemaleSprite As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMaleSprite As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents numBaseExp As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblFemaleSprite As System.Windows.Forms.Label
    Friend WithEvents lblMaleSprite As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
