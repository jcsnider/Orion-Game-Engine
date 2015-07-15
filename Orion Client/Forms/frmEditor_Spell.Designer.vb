<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Spell
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.scrlAOE = New System.Windows.Forms.HScrollBar()
        Me.lblAOE = New System.Windows.Forms.Label()
        Me.scrlStun = New System.Windows.Forms.HScrollBar()
        Me.lblStun = New System.Windows.Forms.Label()
        Me.scrlAnim = New System.Windows.Forms.HScrollBar()
        Me.lblAnim = New System.Windows.Forms.Label()
        Me.scrlAnimCast = New System.Windows.Forms.HScrollBar()
        Me.lblAnimCast = New System.Windows.Forms.Label()
        Me.chkAOE = New System.Windows.Forms.CheckBox()
        Me.scrlRange = New System.Windows.Forms.HScrollBar()
        Me.lblRange = New System.Windows.Forms.Label()
        Me.scrlInterval = New System.Windows.Forms.HScrollBar()
        Me.scrlDuration = New System.Windows.Forms.HScrollBar()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.scrlVital = New System.Windows.Forms.HScrollBar()
        Me.lblVital = New System.Windows.Forms.Label()
        Me.scrlY = New System.Windows.Forms.HScrollBar()
        Me.scrlX = New System.Windows.Forms.HScrollBar()
        Me.scrlDir = New System.Windows.Forms.HScrollBar()
        Me.scrlMap = New System.Windows.Forms.HScrollBar()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblDir = New System.Windows.Forms.Label()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.picSprite = New System.Windows.Forms.PictureBox()
        Me.scrlIcon = New System.Windows.Forms.HScrollBar()
        Me.lblIcon = New System.Windows.Forms.Label()
        Me.scrlCool = New System.Windows.Forms.HScrollBar()
        Me.lblCool = New System.Windows.Forms.Label()
        Me.scrlCast = New System.Windows.Forms.HScrollBar()
        Me.lblCast = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.scrlAccess = New System.Windows.Forms.HScrollBar()
        Me.lblAccess = New System.Windows.Forms.Label()
        Me.scrlLevel = New System.Windows.Forms.HScrollBar()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.scrlMP = New System.Windows.Forms.HScrollBar()
        Me.lblMP = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 442)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Liste des magies"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(6, 16)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(196, 420)
        Me.lstIndex.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(228, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(482, 442)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Propriétés de la magie"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.scrlAOE)
        Me.GroupBox4.Controls.Add(Me.lblAOE)
        Me.GroupBox4.Controls.Add(Me.scrlStun)
        Me.GroupBox4.Controls.Add(Me.lblStun)
        Me.GroupBox4.Controls.Add(Me.scrlAnim)
        Me.GroupBox4.Controls.Add(Me.lblAnim)
        Me.GroupBox4.Controls.Add(Me.scrlAnimCast)
        Me.GroupBox4.Controls.Add(Me.lblAnimCast)
        Me.GroupBox4.Controls.Add(Me.chkAOE)
        Me.GroupBox4.Controls.Add(Me.scrlRange)
        Me.GroupBox4.Controls.Add(Me.lblRange)
        Me.GroupBox4.Controls.Add(Me.scrlInterval)
        Me.GroupBox4.Controls.Add(Me.scrlDuration)
        Me.GroupBox4.Controls.Add(Me.lblInterval)
        Me.GroupBox4.Controls.Add(Me.lblDuration)
        Me.GroupBox4.Controls.Add(Me.scrlVital)
        Me.GroupBox4.Controls.Add(Me.lblVital)
        Me.GroupBox4.Controls.Add(Me.scrlY)
        Me.GroupBox4.Controls.Add(Me.scrlX)
        Me.GroupBox4.Controls.Add(Me.scrlDir)
        Me.GroupBox4.Controls.Add(Me.scrlMap)
        Me.GroupBox4.Controls.Add(Me.lblY)
        Me.GroupBox4.Controls.Add(Me.lblX)
        Me.GroupBox4.Controls.Add(Me.lblDir)
        Me.GroupBox4.Controls.Add(Me.lblMap)
        Me.GroupBox4.Location = New System.Drawing.Point(262, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(210, 419)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Data"
        '
        'scrlAOE
        '
        Me.scrlAOE.LargeChange = 1
        Me.scrlAOE.Location = New System.Drawing.Point(13, 264)
        Me.scrlAOE.Maximum = 32767
        Me.scrlAOE.Name = "scrlAOE"
        Me.scrlAOE.Size = New System.Drawing.Size(166, 16)
        Me.scrlAOE.TabIndex = 25
        '
        'lblAOE
        '
        Me.lblAOE.AutoSize = True
        Me.lblAOE.Location = New System.Drawing.Point(10, 251)
        Me.lblAOE.Name = "lblAOE"
        Me.lblAOE.Size = New System.Drawing.Size(75, 13)
        Me.lblAOE.TabIndex = 24
        Me.lblAOE.Text = "AoE: Self-Cast"
        '
        'scrlStun
        '
        Me.scrlStun.LargeChange = 1
        Me.scrlStun.Location = New System.Drawing.Point(13, 393)
        Me.scrlStun.Maximum = 32767
        Me.scrlStun.Name = "scrlStun"
        Me.scrlStun.Size = New System.Drawing.Size(166, 16)
        Me.scrlStun.TabIndex = 23
        '
        'lblStun
        '
        Me.lblStun.AutoSize = True
        Me.lblStun.Location = New System.Drawing.Point(10, 380)
        Me.lblStun.Name = "lblStun"
        Me.lblStun.Size = New System.Drawing.Size(104, 13)
        Me.lblStun.TabIndex = 22
        Me.lblStun.Text = "Stun Duration: None"
        '
        'scrlAnim
        '
        Me.scrlAnim.LargeChange = 1
        Me.scrlAnim.Location = New System.Drawing.Point(13, 347)
        Me.scrlAnim.Maximum = 32767
        Me.scrlAnim.Name = "scrlAnim"
        Me.scrlAnim.Size = New System.Drawing.Size(166, 16)
        Me.scrlAnim.TabIndex = 21
        '
        'lblAnim
        '
        Me.lblAnim.AutoSize = True
        Me.lblAnim.Location = New System.Drawing.Point(10, 334)
        Me.lblAnim.Name = "lblAnim"
        Me.lblAnim.Size = New System.Drawing.Size(85, 13)
        Me.lblAnim.TabIndex = 20
        Me.lblAnim.Text = "Animation: None"
        '
        'scrlAnimCast
        '
        Me.scrlAnimCast.LargeChange = 1
        Me.scrlAnimCast.Location = New System.Drawing.Point(13, 301)
        Me.scrlAnimCast.Maximum = 32767
        Me.scrlAnimCast.Name = "scrlAnimCast"
        Me.scrlAnimCast.Size = New System.Drawing.Size(166, 16)
        Me.scrlAnimCast.TabIndex = 19
        '
        'lblAnimCast
        '
        Me.lblAnimCast.AutoSize = True
        Me.lblAnimCast.Location = New System.Drawing.Point(10, 288)
        Me.lblAnimCast.Name = "lblAnimCast"
        Me.lblAnimCast.Size = New System.Drawing.Size(109, 13)
        Me.lblAnimCast.TabIndex = 18
        Me.lblAnimCast.Text = "Cast Animation: None"
        '
        'chkAOE
        '
        Me.chkAOE.AutoSize = True
        Me.chkAOE.Location = New System.Drawing.Point(17, 231)
        Me.chkAOE.Name = "chkAOE"
        Me.chkAOE.Size = New System.Drawing.Size(123, 17)
        Me.chkAOE.TabIndex = 17
        Me.chkAOE.Text = "Area of Effect Spell?"
        Me.chkAOE.UseVisualStyleBackColor = True
        '
        'scrlRange
        '
        Me.scrlRange.LargeChange = 1
        Me.scrlRange.Location = New System.Drawing.Point(13, 209)
        Me.scrlRange.Maximum = 32767
        Me.scrlRange.Name = "scrlRange"
        Me.scrlRange.Size = New System.Drawing.Size(166, 16)
        Me.scrlRange.TabIndex = 16
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Location = New System.Drawing.Point(10, 196)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(87, 13)
        Me.lblRange.TabIndex = 15
        Me.lblRange.Text = "Range: Self-Cast"
        '
        'scrlInterval
        '
        Me.scrlInterval.LargeChange = 1
        Me.scrlInterval.Location = New System.Drawing.Point(112, 159)
        Me.scrlInterval.Maximum = 60
        Me.scrlInterval.Name = "scrlInterval"
        Me.scrlInterval.Size = New System.Drawing.Size(67, 16)
        Me.scrlInterval.TabIndex = 14
        '
        'scrlDuration
        '
        Me.scrlDuration.LargeChange = 1
        Me.scrlDuration.Location = New System.Drawing.Point(13, 158)
        Me.scrlDuration.Maximum = 60
        Me.scrlDuration.Name = "scrlDuration"
        Me.scrlDuration.Size = New System.Drawing.Size(67, 16)
        Me.scrlDuration.TabIndex = 13
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(109, 146)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(59, 13)
        Me.lblInterval.TabIndex = 12
        Me.lblInterval.Text = "Interval: 0s"
        '
        'lblDuration
        '
        Me.lblDuration.AutoSize = True
        Me.lblDuration.Location = New System.Drawing.Point(10, 145)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(64, 13)
        Me.lblDuration.TabIndex = 11
        Me.lblDuration.Text = "Duration: 0s"
        '
        'scrlVital
        '
        Me.scrlVital.LargeChange = 1
        Me.scrlVital.Location = New System.Drawing.Point(12, 114)
        Me.scrlVital.Maximum = 32767
        Me.scrlVital.Name = "scrlVital"
        Me.scrlVital.Size = New System.Drawing.Size(166, 16)
        Me.scrlVital.TabIndex = 10
        '
        'lblVital
        '
        Me.lblVital.AutoSize = True
        Me.lblVital.Location = New System.Drawing.Point(9, 101)
        Me.lblVital.Name = "lblVital"
        Me.lblVital.Size = New System.Drawing.Size(39, 13)
        Me.lblVital.TabIndex = 9
        Me.lblVital.Text = "Vital: 0"
        '
        'scrlY
        '
        Me.scrlY.LargeChange = 1
        Me.scrlY.Location = New System.Drawing.Point(111, 70)
        Me.scrlY.Maximum = 32767
        Me.scrlY.Name = "scrlY"
        Me.scrlY.Size = New System.Drawing.Size(67, 16)
        Me.scrlY.TabIndex = 8
        '
        'scrlX
        '
        Me.scrlX.LargeChange = 1
        Me.scrlX.Location = New System.Drawing.Point(12, 69)
        Me.scrlX.Maximum = 32767
        Me.scrlX.Name = "scrlX"
        Me.scrlX.Size = New System.Drawing.Size(67, 16)
        Me.scrlX.TabIndex = 7
        '
        'scrlDir
        '
        Me.scrlDir.LargeChange = 1
        Me.scrlDir.Location = New System.Drawing.Point(111, 35)
        Me.scrlDir.Maximum = 5
        Me.scrlDir.Name = "scrlDir"
        Me.scrlDir.Size = New System.Drawing.Size(67, 16)
        Me.scrlDir.TabIndex = 5
        '
        'scrlMap
        '
        Me.scrlMap.LargeChange = 1
        Me.scrlMap.Location = New System.Drawing.Point(13, 35)
        Me.scrlMap.Name = "scrlMap"
        Me.scrlMap.Size = New System.Drawing.Size(67, 16)
        Me.scrlMap.TabIndex = 4
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(108, 57)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(26, 13)
        Me.lblY.TabIndex = 3
        Me.lblY.Text = "Y: 0"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(9, 56)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(26, 13)
        Me.lblX.TabIndex = 2
        Me.lblX.Text = "X: 0"
        '
        'lblDir
        '
        Me.lblDir.AutoSize = True
        Me.lblDir.Location = New System.Drawing.Point(108, 20)
        Me.lblDir.Name = "lblDir"
        Me.lblDir.Size = New System.Drawing.Size(54, 13)
        Me.lblDir.TabIndex = 1
        Me.lblDir.Text = "Dir: Down"
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(9, 19)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(40, 13)
        Me.lblMap.TabIndex = 0
        Me.lblMap.Text = "Map: 0"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.picSprite)
        Me.GroupBox3.Controls.Add(Me.scrlIcon)
        Me.GroupBox3.Controls.Add(Me.lblIcon)
        Me.GroupBox3.Controls.Add(Me.scrlCool)
        Me.GroupBox3.Controls.Add(Me.lblCool)
        Me.GroupBox3.Controls.Add(Me.scrlCast)
        Me.GroupBox3.Controls.Add(Me.lblCast)
        Me.GroupBox3.Controls.Add(Me.cmbClass)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.scrlAccess)
        Me.GroupBox3.Controls.Add(Me.lblAccess)
        Me.GroupBox3.Controls.Add(Me.scrlLevel)
        Me.GroupBox3.Controls.Add(Me.lblLevel)
        Me.GroupBox3.Controls.Add(Me.scrlMP)
        Me.GroupBox3.Controls.Add(Me.lblMP)
        Me.GroupBox3.Controls.Add(Me.cmbType)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtName)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(250, 419)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informatique basique"
        '
        'picSprite
        '
        Me.picSprite.BackColor = System.Drawing.Color.Black
        Me.picSprite.Location = New System.Drawing.Point(203, 372)
        Me.picSprite.Name = "picSprite"
        Me.picSprite.Size = New System.Drawing.Size(32, 32)
        Me.picSprite.TabIndex = 54
        Me.picSprite.TabStop = False
        '
        'scrlIcon
        '
        Me.scrlIcon.LargeChange = 1
        Me.scrlIcon.Location = New System.Drawing.Point(12, 387)
        Me.scrlIcon.Name = "scrlIcon"
        Me.scrlIcon.Size = New System.Drawing.Size(184, 17)
        Me.scrlIcon.TabIndex = 53
        '
        'lblIcon
        '
        Me.lblIcon.AutoSize = True
        Me.lblIcon.Location = New System.Drawing.Point(9, 374)
        Me.lblIcon.Name = "lblIcon"
        Me.lblIcon.Size = New System.Drawing.Size(60, 13)
        Me.lblIcon.TabIndex = 52
        Me.lblIcon.Text = "Icon: None"
        '
        'scrlCool
        '
        Me.scrlCool.LargeChange = 1
        Me.scrlCool.Location = New System.Drawing.Point(14, 312)
        Me.scrlCool.Name = "scrlCool"
        Me.scrlCool.Size = New System.Drawing.Size(221, 17)
        Me.scrlCool.TabIndex = 51
        '
        'lblCool
        '
        Me.lblCool.AutoSize = True
        Me.lblCool.Location = New System.Drawing.Point(11, 299)
        Me.lblCool.Name = "lblCool"
        Me.lblCool.Size = New System.Drawing.Size(97, 13)
        Me.lblCool.TabIndex = 50
        Me.lblCool.Text = "Cooldown Time: 0s"
        '
        'scrlCast
        '
        Me.scrlCast.LargeChange = 1
        Me.scrlCast.Location = New System.Drawing.Point(14, 279)
        Me.scrlCast.Maximum = 32767
        Me.scrlCast.Name = "scrlCast"
        Me.scrlCast.Size = New System.Drawing.Size(221, 17)
        Me.scrlCast.TabIndex = 49
        '
        'lblCast
        '
        Me.lblCast.AutoSize = True
        Me.lblCast.Location = New System.Drawing.Point(11, 266)
        Me.lblCast.Name = "lblCast"
        Me.lblCast.Size = New System.Drawing.Size(85, 13)
        Me.lblCast.TabIndex = 48
        Me.lblCast.Text = "Casting Time: 0s"
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(14, 231)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(224, 21)
        Me.cmbClass.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Classe requise:"
        '
        'scrlAccess
        '
        Me.scrlAccess.LargeChange = 1
        Me.scrlAccess.Location = New System.Drawing.Point(14, 192)
        Me.scrlAccess.Maximum = 5
        Me.scrlAccess.Name = "scrlAccess"
        Me.scrlAccess.Size = New System.Drawing.Size(221, 17)
        Me.scrlAccess.TabIndex = 45
        '
        'lblAccess
        '
        Me.lblAccess.AutoSize = True
        Me.lblAccess.Location = New System.Drawing.Point(11, 179)
        Me.lblAccess.Name = "lblAccess"
        Me.lblAccess.Size = New System.Drawing.Size(100, 13)
        Me.lblAccess.TabIndex = 44
        Me.lblAccess.Text = "Accès requis: None"
        '
        'scrlLevel
        '
        Me.scrlLevel.LargeChange = 1
        Me.scrlLevel.Location = New System.Drawing.Point(14, 158)
        Me.scrlLevel.Name = "scrlLevel"
        Me.scrlLevel.Size = New System.Drawing.Size(221, 17)
        Me.scrlLevel.TabIndex = 43
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Location = New System.Drawing.Point(11, 145)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(104, 13)
        Me.lblLevel.TabIndex = 42
        Me.lblLevel.Text = "Niveau requis: None"
        '
        'scrlMP
        '
        Me.scrlMP.LargeChange = 1
        Me.scrlMP.Location = New System.Drawing.Point(14, 125)
        Me.scrlMP.Maximum = 32767
        Me.scrlMP.Name = "scrlMP"
        Me.scrlMP.Size = New System.Drawing.Size(221, 17)
        Me.scrlMP.TabIndex = 41
        '
        'lblMP
        '
        Me.lblMP.AutoSize = True
        Me.lblMP.Location = New System.Drawing.Point(11, 112)
        Me.lblMP.Name = "lblMP"
        Me.lblMP.Size = New System.Drawing.Size(66, 13)
        Me.lblMP.TabIndex = 40
        Me.lblMP.Text = "Cout en MP:"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Damage HP", "Damage MP", "Heal HP", "Heal MP", "Warp"})
        Me.cmbType.Location = New System.Drawing.Point(12, 81)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(224, 21)
        Me.cmbType.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(11, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(225, 20)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(601, 459)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Annuler"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(490, 459)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 25)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Supprimer"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(379, 459)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 25)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Sauvegarder"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmEditor_Spell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 496)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmEditor_Spell"
        Me.Text = "frmEditor_Spell"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picSprite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblMP As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents scrlMP As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlAccess As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAccess As System.Windows.Forms.Label
    Friend WithEvents scrlLevel As System.Windows.Forms.HScrollBar
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picSprite As System.Windows.Forms.PictureBox
    Friend WithEvents scrlIcon As System.Windows.Forms.HScrollBar
    Friend WithEvents lblIcon As System.Windows.Forms.Label
    Friend WithEvents scrlCool As System.Windows.Forms.HScrollBar
    Friend WithEvents lblCool As System.Windows.Forms.Label
    Friend WithEvents scrlCast As System.Windows.Forms.HScrollBar
    Friend WithEvents lblCast As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblDir As System.Windows.Forms.Label
    Friend WithEvents lblMap As System.Windows.Forms.Label
    Friend WithEvents scrlDir As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMap As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlY As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlRange As System.Windows.Forms.HScrollBar
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents scrlInterval As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlDuration As System.Windows.Forms.HScrollBar
    Friend WithEvents lblInterval As System.Windows.Forms.Label
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents scrlVital As System.Windows.Forms.HScrollBar
    Friend WithEvents lblVital As System.Windows.Forms.Label
    Friend WithEvents chkAOE As System.Windows.Forms.CheckBox
    Friend WithEvents scrlAOE As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAOE As System.Windows.Forms.Label
    Friend WithEvents scrlStun As System.Windows.Forms.HScrollBar
    Friend WithEvents lblStun As System.Windows.Forms.Label
    Friend WithEvents scrlAnim As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAnim As System.Windows.Forms.Label
    Friend WithEvents scrlAnimCast As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAnimCast As System.Windows.Forms.Label
End Class
