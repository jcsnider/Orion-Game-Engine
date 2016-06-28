<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainGame
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainGame))
        Me.picscreen = New System.Windows.Forms.PictureBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbScreenSize = New System.Windows.Forms.ComboBox()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.scrlVolume = New System.Windows.Forms.HScrollBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optSOff = New System.Windows.Forms.RadioButton()
        Me.optSOn = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMOff = New System.Windows.Forms.RadioButton()
        Me.optMOn = New System.Windows.Forms.RadioButton()
        Me.pnlTmpInv = New System.Windows.Forms.Panel()
        Me.pnlCurrency = New System.Windows.Forms.Panel()
        Me.lblCurrencyCancel = New System.Windows.Forms.Label()
        Me.lblCurrencyOk = New System.Windows.Forms.Label()
        Me.txtCurrency = New System.Windows.Forms.TextBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.pnlTempBank = New System.Windows.Forms.Panel()
        Me.pnlQuestLog = New System.Windows.Forms.Panel()
        Me.lblQuestLogClose = New System.Windows.Forms.Label()
        Me.lblAbandonQuest = New System.Windows.Forms.Label()
        Me.lblQuestRewards = New System.Windows.Forms.Label()
        Me.lblQuestRequirements = New System.Windows.Forms.Label()
        Me.lblQuestStatus2 = New System.Windows.Forms.Label()
        Me.lblQuestStatus = New System.Windows.Forms.Label()
        Me.txtQuestDialog = New System.Windows.Forms.TextBox()
        Me.lblQuestDialog = New System.Windows.Forms.Label()
        Me.txtActualTask = New System.Windows.Forms.TextBox()
        Me.lblTaskLog = New System.Windows.Forms.Label()
        Me.lblActualTask = New System.Windows.Forms.Label()
        Me.lstQuestLog = New System.Windows.Forms.ListBox()
        Me.txtQuestTaskLog = New System.Windows.Forms.TextBox()
        Me.pnlTmpSkill = New System.Windows.Forms.Panel()
        Me.tmrShake = New System.Windows.Forms.Timer(Me.components)
        Me.pnlCraft = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.lblMaterialAmount5 = New System.Windows.Forms.Label()
        Me.lblMaterialName5 = New System.Windows.Forms.Label()
        Me.picMaterial5 = New System.Windows.Forms.PictureBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lblMaterialAmount4 = New System.Windows.Forms.Label()
        Me.lblMaterialName4 = New System.Windows.Forms.Label()
        Me.picMaterial4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.lblMaterialAmount3 = New System.Windows.Forms.Label()
        Me.lblMaterialName3 = New System.Windows.Forms.Label()
        Me.picMaterial3 = New System.Windows.Forms.PictureBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblMaterialAmount2 = New System.Windows.Forms.Label()
        Me.lblMaterialName2 = New System.Windows.Forms.Label()
        Me.picMaterial2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblMaterialAmount1 = New System.Windows.Forms.Label()
        Me.lblMaterialName1 = New System.Windows.Forms.Label()
        Me.picMaterial1 = New System.Windows.Forms.PictureBox()
        Me.btnCraftClose = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblProductAmount = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.pgbCraftProgress = New System.Windows.Forms.ProgressBar()
        Me.btnCraftStop = New System.Windows.Forms.Button()
        Me.btnCraft = New System.Windows.Forms.Button()
        Me.nudCraftAmount = New System.Windows.Forms.NumericUpDown()
        Me.chkKnownOnly = New System.Windows.Forms.CheckBox()
        Me.lblCraftExp = New System.Windows.Forms.Label()
        Me.lblCraftLvl = New System.Windows.Forms.Label()
        Me.lstRecipe = New System.Windows.Forms.ListBox()
        Me.tmrCraft = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picscreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOptions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCurrency.SuspendLayout()
        Me.pnlQuestLog.SuspendLayout()
        Me.pnlCraft.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.picMaterial5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.picMaterial4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.picMaterial3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.picMaterial2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.picMaterial1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCraftAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picscreen
        '
        Me.picscreen.Location = New System.Drawing.Point(0, 0)
        Me.picscreen.Name = "picscreen"
        Me.picscreen.Size = New System.Drawing.Size(1024, 768)
        Me.picscreen.TabIndex = 4
        Me.picscreen.TabStop = False
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.DimGray
        Me.pnlOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.btnSaveSettings)
        Me.pnlOptions.Controls.Add(Me.Label1)
        Me.pnlOptions.Controls.Add(Me.cmbScreenSize)
        Me.pnlOptions.Controls.Add(Me.lblVolume)
        Me.pnlOptions.Controls.Add(Me.scrlVolume)
        Me.pnlOptions.Controls.Add(Me.GroupBox2)
        Me.pnlOptions.Controls.Add(Me.GroupBox1)
        Me.pnlOptions.ForeColor = System.Drawing.Color.White
        Me.pnlOptions.Location = New System.Drawing.Point(776, 12)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(233, 275)
        Me.pnlOptions.TabIndex = 10
        Me.pnlOptions.Visible = False
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSaveSettings.Location = New System.Drawing.Point(12, 240)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(205, 23)
        Me.btnSaveSettings.TabIndex = 14
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "ScreenSize"
        '
        'cmbScreenSize
        '
        Me.cmbScreenSize.FormattingEnabled = True
        Me.cmbScreenSize.Items.AddRange(New Object() {"1024X768", "1152X864"})
        Me.cmbScreenSize.Location = New System.Drawing.Point(11, 115)
        Me.cmbScreenSize.Name = "cmbScreenSize"
        Me.cmbScreenSize.Size = New System.Drawing.Size(206, 21)
        Me.cmbScreenSize.TabIndex = 12
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.BackColor = System.Drawing.Color.Transparent
        Me.lblVolume.ForeColor = System.Drawing.Color.White
        Me.lblVolume.Location = New System.Drawing.Point(12, 53)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(48, 13)
        Me.lblVolume.TabIndex = 11
        Me.lblVolume.Text = "Volume: "
        '
        'scrlVolume
        '
        Me.scrlVolume.LargeChange = 1
        Me.scrlVolume.Location = New System.Drawing.Point(12, 68)
        Me.scrlVolume.Name = "scrlVolume"
        Me.scrlVolume.Size = New System.Drawing.Size(205, 17)
        Me.scrlVolume.TabIndex = 10
        Me.scrlVolume.Value = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSOff)
        Me.GroupBox2.Controls.Add(Me.optSOn)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(117, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(100, 38)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sound"
        '
        'optSOff
        '
        Me.optSOff.AutoSize = True
        Me.optSOff.Location = New System.Drawing.Point(49, 19)
        Me.optSOff.Name = "optSOff"
        Me.optSOff.Size = New System.Drawing.Size(39, 17)
        Me.optSOff.TabIndex = 5
        Me.optSOff.TabStop = True
        Me.optSOff.Text = "Off"
        Me.optSOff.UseVisualStyleBackColor = True
        '
        'optSOn
        '
        Me.optSOn.AutoSize = True
        Me.optSOn.Location = New System.Drawing.Point(4, 19)
        Me.optSOn.Name = "optSOn"
        Me.optSOn.Size = New System.Drawing.Size(39, 17)
        Me.optSOn.TabIndex = 4
        Me.optSOn.TabStop = True
        Me.optSOn.Text = "On"
        Me.optSOn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optMOff)
        Me.GroupBox1.Controls.Add(Me.optMOn)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(100, 39)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Music"
        '
        'optMOff
        '
        Me.optMOff.AutoSize = True
        Me.optMOff.Location = New System.Drawing.Point(49, 17)
        Me.optMOff.Name = "optMOff"
        Me.optMOff.Size = New System.Drawing.Size(39, 17)
        Me.optMOff.TabIndex = 2
        Me.optMOff.TabStop = True
        Me.optMOff.Text = "Off"
        Me.optMOff.UseVisualStyleBackColor = True
        '
        'optMOn
        '
        Me.optMOn.AutoSize = True
        Me.optMOn.Location = New System.Drawing.Point(4, 17)
        Me.optMOn.Name = "optMOn"
        Me.optMOn.Size = New System.Drawing.Size(39, 17)
        Me.optMOn.TabIndex = 1
        Me.optMOn.TabStop = True
        Me.optMOn.Text = "On"
        Me.optMOn.UseVisualStyleBackColor = True
        '
        'pnlTmpInv
        '
        Me.pnlTmpInv.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTmpInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTmpInv.Location = New System.Drawing.Point(1053, 491)
        Me.pnlTmpInv.Name = "pnlTmpInv"
        Me.pnlTmpInv.Size = New System.Drawing.Size(32, 32)
        Me.pnlTmpInv.TabIndex = 15
        Me.pnlTmpInv.Visible = False
        '
        'pnlCurrency
        '
        Me.pnlCurrency.BackColor = System.Drawing.Color.DimGray
        Me.pnlCurrency.Controls.Add(Me.lblCurrencyCancel)
        Me.pnlCurrency.Controls.Add(Me.lblCurrencyOk)
        Me.pnlCurrency.Controls.Add(Me.txtCurrency)
        Me.pnlCurrency.Controls.Add(Me.lblCurrency)
        Me.pnlCurrency.Location = New System.Drawing.Point(12, 471)
        Me.pnlCurrency.Name = "pnlCurrency"
        Me.pnlCurrency.Size = New System.Drawing.Size(480, 121)
        Me.pnlCurrency.TabIndex = 16
        Me.pnlCurrency.Visible = False
        '
        'lblCurrencyCancel
        '
        Me.lblCurrencyCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrencyCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyCancel.ForeColor = System.Drawing.Color.White
        Me.lblCurrencyCancel.Location = New System.Drawing.Point(147, 82)
        Me.lblCurrencyCancel.Name = "lblCurrencyCancel"
        Me.lblCurrencyCancel.Size = New System.Drawing.Size(180, 16)
        Me.lblCurrencyCancel.TabIndex = 4
        Me.lblCurrencyCancel.Text = "Cancel"
        Me.lblCurrencyCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrencyOk
        '
        Me.lblCurrencyOk.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrencyOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyOk.ForeColor = System.Drawing.Color.White
        Me.lblCurrencyOk.Location = New System.Drawing.Point(147, 66)
        Me.lblCurrencyOk.Name = "lblCurrencyOk"
        Me.lblCurrencyOk.Size = New System.Drawing.Size(180, 16)
        Me.lblCurrencyOk.TabIndex = 3
        Me.lblCurrencyOk.Text = "Okay"
        Me.lblCurrencyOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrency
        '
        Me.txtCurrency.Location = New System.Drawing.Point(147, 43)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(180, 20)
        Me.txtCurrency.TabIndex = 2
        '
        'lblCurrency
        '
        Me.lblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrency.ForeColor = System.Drawing.Color.White
        Me.lblCurrency.Location = New System.Drawing.Point(3, 16)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(474, 24)
        Me.lblCurrency.TabIndex = 1
        Me.lblCurrency.Text = "How many do you want to drop?"
        Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTempBank
        '
        Me.pnlTempBank.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTempBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTempBank.Location = New System.Drawing.Point(1057, 601)
        Me.pnlTempBank.Name = "pnlTempBank"
        Me.pnlTempBank.Size = New System.Drawing.Size(32, 32)
        Me.pnlTempBank.TabIndex = 20
        Me.pnlTempBank.Visible = False
        '
        'pnlQuestLog
        '
        Me.pnlQuestLog.BackColor = System.Drawing.Color.DimGray
        Me.pnlQuestLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlQuestLog.Controls.Add(Me.lblQuestLogClose)
        Me.pnlQuestLog.Controls.Add(Me.lblAbandonQuest)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestRewards)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestRequirements)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestStatus2)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestStatus)
        Me.pnlQuestLog.Controls.Add(Me.txtQuestDialog)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestDialog)
        Me.pnlQuestLog.Controls.Add(Me.txtActualTask)
        Me.pnlQuestLog.Controls.Add(Me.lblTaskLog)
        Me.pnlQuestLog.Controls.Add(Me.lblActualTask)
        Me.pnlQuestLog.Controls.Add(Me.lstQuestLog)
        Me.pnlQuestLog.Controls.Add(Me.txtQuestTaskLog)
        Me.pnlQuestLog.Location = New System.Drawing.Point(136, 81)
        Me.pnlQuestLog.Name = "pnlQuestLog"
        Me.pnlQuestLog.Size = New System.Drawing.Size(478, 382)
        Me.pnlQuestLog.TabIndex = 38
        Me.pnlQuestLog.Visible = False
        '
        'lblQuestLogClose
        '
        Me.lblQuestLogClose.AutoSize = True
        Me.lblQuestLogClose.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestLogClose.ForeColor = System.Drawing.Color.White
        Me.lblQuestLogClose.Location = New System.Drawing.Point(197, 360)
        Me.lblQuestLogClose.Name = "lblQuestLogClose"
        Me.lblQuestLogClose.Size = New System.Drawing.Size(82, 13)
        Me.lblQuestLogClose.TabIndex = 14
        Me.lblQuestLogClose.Text = "Close QuestLog"
        '
        'lblAbandonQuest
        '
        Me.lblAbandonQuest.AutoSize = True
        Me.lblAbandonQuest.BackColor = System.Drawing.Color.Transparent
        Me.lblAbandonQuest.ForeColor = System.Drawing.Color.Red
        Me.lblAbandonQuest.Location = New System.Drawing.Point(390, 360)
        Me.lblAbandonQuest.Name = "lblAbandonQuest"
        Me.lblAbandonQuest.Size = New System.Drawing.Size(81, 13)
        Me.lblAbandonQuest.TabIndex = 13
        Me.lblAbandonQuest.Text = "Abandon Quest"
        Me.lblAbandonQuest.Visible = False
        '
        'lblQuestRewards
        '
        Me.lblQuestRewards.AutoSize = True
        Me.lblQuestRewards.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestRewards.ForeColor = System.Drawing.Color.White
        Me.lblQuestRewards.Location = New System.Drawing.Point(197, 317)
        Me.lblQuestRewards.Name = "lblQuestRewards"
        Me.lblQuestRewards.Size = New System.Drawing.Size(52, 13)
        Me.lblQuestRewards.TabIndex = 12
        Me.lblQuestRewards.Text = "Rewards:"
        '
        'lblQuestRequirements
        '
        Me.lblQuestRequirements.AutoSize = True
        Me.lblQuestRequirements.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestRequirements.ForeColor = System.Drawing.Color.White
        Me.lblQuestRequirements.Location = New System.Drawing.Point(197, 290)
        Me.lblQuestRequirements.Name = "lblQuestRequirements"
        Me.lblQuestRequirements.Size = New System.Drawing.Size(75, 13)
        Me.lblQuestRequirements.TabIndex = 10
        Me.lblQuestRequirements.Text = "Requirements:"
        '
        'lblQuestStatus2
        '
        Me.lblQuestStatus2.AutoSize = True
        Me.lblQuestStatus2.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestStatus2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblQuestStatus2.Location = New System.Drawing.Point(274, 265)
        Me.lblQuestStatus2.Name = "lblQuestStatus2"
        Me.lblQuestStatus2.Size = New System.Drawing.Size(25, 13)
        Me.lblQuestStatus2.TabIndex = 9
        Me.lblQuestStatus2.Text = "???"
        '
        'lblQuestStatus
        '
        Me.lblQuestStatus.AutoSize = True
        Me.lblQuestStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestStatus.ForeColor = System.Drawing.Color.White
        Me.lblQuestStatus.Location = New System.Drawing.Point(197, 265)
        Me.lblQuestStatus.Name = "lblQuestStatus"
        Me.lblQuestStatus.Size = New System.Drawing.Size(71, 13)
        Me.lblQuestStatus.TabIndex = 8
        Me.lblQuestStatus.Text = "Quest Status:"
        '
        'txtQuestDialog
        '
        Me.txtQuestDialog.BackColor = System.Drawing.Color.Black
        Me.txtQuestDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuestDialog.ForeColor = System.Drawing.Color.White
        Me.txtQuestDialog.Location = New System.Drawing.Point(197, 211)
        Me.txtQuestDialog.Multiline = True
        Me.txtQuestDialog.Name = "txtQuestDialog"
        Me.txtQuestDialog.ReadOnly = True
        Me.txtQuestDialog.Size = New System.Drawing.Size(268, 51)
        Me.txtQuestDialog.TabIndex = 7
        '
        'lblQuestDialog
        '
        Me.lblQuestDialog.AutoSize = True
        Me.lblQuestDialog.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestDialog.ForeColor = System.Drawing.Color.White
        Me.lblQuestDialog.Location = New System.Drawing.Point(200, 195)
        Me.lblQuestDialog.Name = "lblQuestDialog"
        Me.lblQuestDialog.Size = New System.Drawing.Size(91, 13)
        Me.lblQuestDialog.TabIndex = 6
        Me.lblQuestDialog.Text = "Last Quest Dialog"
        '
        'txtActualTask
        '
        Me.txtActualTask.BackColor = System.Drawing.Color.Black
        Me.txtActualTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualTask.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtActualTask.Location = New System.Drawing.Point(197, 139)
        Me.txtActualTask.Multiline = True
        Me.txtActualTask.Name = "txtActualTask"
        Me.txtActualTask.ReadOnly = True
        Me.txtActualTask.Size = New System.Drawing.Size(268, 51)
        Me.txtActualTask.TabIndex = 5
        '
        'lblTaskLog
        '
        Me.lblTaskLog.AutoSize = True
        Me.lblTaskLog.BackColor = System.Drawing.Color.Transparent
        Me.lblTaskLog.ForeColor = System.Drawing.Color.White
        Me.lblTaskLog.Location = New System.Drawing.Point(200, 5)
        Me.lblTaskLog.Name = "lblTaskLog"
        Me.lblTaskLog.Size = New System.Drawing.Size(52, 13)
        Me.lblTaskLog.TabIndex = 4
        Me.lblTaskLog.Text = "Task Log"
        '
        'lblActualTask
        '
        Me.lblActualTask.AutoSize = True
        Me.lblActualTask.BackColor = System.Drawing.Color.Transparent
        Me.lblActualTask.ForeColor = System.Drawing.Color.White
        Me.lblActualTask.Location = New System.Drawing.Point(197, 123)
        Me.lblActualTask.Name = "lblActualTask"
        Me.lblActualTask.Size = New System.Drawing.Size(64, 13)
        Me.lblActualTask.TabIndex = 3
        Me.lblActualTask.Text = "Actual Task"
        '
        'lstQuestLog
        '
        Me.lstQuestLog.BackColor = System.Drawing.Color.Black
        Me.lstQuestLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstQuestLog.ForeColor = System.Drawing.Color.White
        Me.lstQuestLog.FormattingEnabled = True
        Me.lstQuestLog.Location = New System.Drawing.Point(3, 5)
        Me.lstQuestLog.Name = "lstQuestLog"
        Me.lstQuestLog.Size = New System.Drawing.Size(188, 366)
        Me.lstQuestLog.TabIndex = 2
        '
        'txtQuestTaskLog
        '
        Me.txtQuestTaskLog.BackColor = System.Drawing.Color.Black
        Me.txtQuestTaskLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuestTaskLog.ForeColor = System.Drawing.Color.Green
        Me.txtQuestTaskLog.Location = New System.Drawing.Point(197, 22)
        Me.txtQuestTaskLog.Multiline = True
        Me.txtQuestTaskLog.Name = "txtQuestTaskLog"
        Me.txtQuestTaskLog.ReadOnly = True
        Me.txtQuestTaskLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuestTaskLog.Size = New System.Drawing.Size(268, 95)
        Me.txtQuestTaskLog.TabIndex = 1
        '
        'pnlTmpSkill
        '
        Me.pnlTmpSkill.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTmpSkill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTmpSkill.Location = New System.Drawing.Point(1060, 541)
        Me.pnlTmpSkill.Name = "pnlTmpSkill"
        Me.pnlTmpSkill.Size = New System.Drawing.Size(32, 32)
        Me.pnlTmpSkill.TabIndex = 42
        Me.pnlTmpSkill.Visible = False
        '
        'tmrShake
        '
        Me.tmrShake.Interval = 50
        '
        'pnlCraft
        '
        Me.pnlCraft.BackColor = System.Drawing.Color.Gray
        Me.pnlCraft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlCraft.Controls.Add(Me.GroupBox5)
        Me.pnlCraft.Controls.Add(Me.btnCraftClose)
        Me.pnlCraft.Controls.Add(Me.GroupBox4)
        Me.pnlCraft.Controls.Add(Me.pgbCraftProgress)
        Me.pnlCraft.Controls.Add(Me.btnCraftStop)
        Me.pnlCraft.Controls.Add(Me.btnCraft)
        Me.pnlCraft.Controls.Add(Me.nudCraftAmount)
        Me.pnlCraft.Controls.Add(Me.chkKnownOnly)
        Me.pnlCraft.Controls.Add(Me.lblCraftExp)
        Me.pnlCraft.Controls.Add(Me.lblCraftLvl)
        Me.pnlCraft.Controls.Add(Me.lstRecipe)
        Me.pnlCraft.ForeColor = System.Drawing.Color.Black
        Me.pnlCraft.Location = New System.Drawing.Point(18, 14)
        Me.pnlCraft.Name = "pnlCraft"
        Me.pnlCraft.Size = New System.Drawing.Size(700, 500)
        Me.pnlCraft.TabIndex = 47
        Me.pnlCraft.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.GroupBox10)
        Me.GroupBox5.Controls.Add(Me.GroupBox9)
        Me.GroupBox5.Controls.Add(Me.GroupBox8)
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(259, 77)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(435, 333)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Required Materials"
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.lblMaterialAmount5)
        Me.GroupBox10.Controls.Add(Me.lblMaterialName5)
        Me.GroupBox10.Controls.Add(Me.picMaterial5)
        Me.GroupBox10.ForeColor = System.Drawing.Color.White
        Me.GroupBox10.Location = New System.Drawing.Point(7, 266)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(422, 57)
        Me.GroupBox10.TabIndex = 5
        Me.GroupBox10.TabStop = False
        '
        'lblMaterialAmount5
        '
        Me.lblMaterialAmount5.AutoSize = True
        Me.lblMaterialAmount5.Location = New System.Drawing.Point(51, 32)
        Me.lblMaterialAmount5.Name = "lblMaterialAmount5"
        Me.lblMaterialAmount5.Size = New System.Drawing.Size(83, 13)
        Me.lblMaterialAmount5.TabIndex = 2
        Me.lblMaterialAmount5.Text = "Product Amount"
        '
        'lblMaterialName5
        '
        Me.lblMaterialName5.AutoSize = True
        Me.lblMaterialName5.Location = New System.Drawing.Point(51, 13)
        Me.lblMaterialName5.Name = "lblMaterialName5"
        Me.lblMaterialName5.Size = New System.Drawing.Size(72, 13)
        Me.lblMaterialName5.TabIndex = 1
        Me.lblMaterialName5.Text = "ProductName"
        '
        'picMaterial5
        '
        Me.picMaterial5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMaterial5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMaterial5.Location = New System.Drawing.Point(9, 13)
        Me.picMaterial5.Name = "picMaterial5"
        Me.picMaterial5.Size = New System.Drawing.Size(32, 32)
        Me.picMaterial5.TabIndex = 0
        Me.picMaterial5.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.lblMaterialAmount4)
        Me.GroupBox9.Controls.Add(Me.lblMaterialName4)
        Me.GroupBox9.Controls.Add(Me.picMaterial4)
        Me.GroupBox9.ForeColor = System.Drawing.Color.White
        Me.GroupBox9.Location = New System.Drawing.Point(7, 203)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(422, 57)
        Me.GroupBox9.TabIndex = 4
        Me.GroupBox9.TabStop = False
        '
        'lblMaterialAmount4
        '
        Me.lblMaterialAmount4.AutoSize = True
        Me.lblMaterialAmount4.Location = New System.Drawing.Point(51, 32)
        Me.lblMaterialAmount4.Name = "lblMaterialAmount4"
        Me.lblMaterialAmount4.Size = New System.Drawing.Size(83, 13)
        Me.lblMaterialAmount4.TabIndex = 2
        Me.lblMaterialAmount4.Text = "Product Amount"
        '
        'lblMaterialName4
        '
        Me.lblMaterialName4.AutoSize = True
        Me.lblMaterialName4.Location = New System.Drawing.Point(51, 13)
        Me.lblMaterialName4.Name = "lblMaterialName4"
        Me.lblMaterialName4.Size = New System.Drawing.Size(72, 13)
        Me.lblMaterialName4.TabIndex = 1
        Me.lblMaterialName4.Text = "ProductName"
        '
        'picMaterial4
        '
        Me.picMaterial4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMaterial4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMaterial4.Location = New System.Drawing.Point(9, 13)
        Me.picMaterial4.Name = "picMaterial4"
        Me.picMaterial4.Size = New System.Drawing.Size(32, 32)
        Me.picMaterial4.TabIndex = 0
        Me.picMaterial4.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.lblMaterialAmount3)
        Me.GroupBox8.Controls.Add(Me.lblMaterialName3)
        Me.GroupBox8.Controls.Add(Me.picMaterial3)
        Me.GroupBox8.ForeColor = System.Drawing.Color.White
        Me.GroupBox8.Location = New System.Drawing.Point(7, 145)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(422, 57)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        '
        'lblMaterialAmount3
        '
        Me.lblMaterialAmount3.AutoSize = True
        Me.lblMaterialAmount3.Location = New System.Drawing.Point(51, 32)
        Me.lblMaterialAmount3.Name = "lblMaterialAmount3"
        Me.lblMaterialAmount3.Size = New System.Drawing.Size(83, 13)
        Me.lblMaterialAmount3.TabIndex = 2
        Me.lblMaterialAmount3.Text = "Product Amount"
        '
        'lblMaterialName3
        '
        Me.lblMaterialName3.AutoSize = True
        Me.lblMaterialName3.Location = New System.Drawing.Point(51, 13)
        Me.lblMaterialName3.Name = "lblMaterialName3"
        Me.lblMaterialName3.Size = New System.Drawing.Size(72, 13)
        Me.lblMaterialName3.TabIndex = 1
        Me.lblMaterialName3.Text = "ProductName"
        '
        'picMaterial3
        '
        Me.picMaterial3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMaterial3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMaterial3.Location = New System.Drawing.Point(9, 13)
        Me.picMaterial3.Name = "picMaterial3"
        Me.picMaterial3.Size = New System.Drawing.Size(32, 32)
        Me.picMaterial3.TabIndex = 0
        Me.picMaterial3.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.lblMaterialAmount2)
        Me.GroupBox7.Controls.Add(Me.lblMaterialName2)
        Me.GroupBox7.Controls.Add(Me.picMaterial2)
        Me.GroupBox7.ForeColor = System.Drawing.Color.White
        Me.GroupBox7.Location = New System.Drawing.Point(7, 82)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(422, 57)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        '
        'lblMaterialAmount2
        '
        Me.lblMaterialAmount2.AutoSize = True
        Me.lblMaterialAmount2.Location = New System.Drawing.Point(51, 32)
        Me.lblMaterialAmount2.Name = "lblMaterialAmount2"
        Me.lblMaterialAmount2.Size = New System.Drawing.Size(83, 13)
        Me.lblMaterialAmount2.TabIndex = 2
        Me.lblMaterialAmount2.Text = "Product Amount"
        '
        'lblMaterialName2
        '
        Me.lblMaterialName2.AutoSize = True
        Me.lblMaterialName2.Location = New System.Drawing.Point(51, 13)
        Me.lblMaterialName2.Name = "lblMaterialName2"
        Me.lblMaterialName2.Size = New System.Drawing.Size(72, 13)
        Me.lblMaterialName2.TabIndex = 1
        Me.lblMaterialName2.Text = "ProductName"
        '
        'picMaterial2
        '
        Me.picMaterial2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMaterial2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMaterial2.Location = New System.Drawing.Point(9, 13)
        Me.picMaterial2.Name = "picMaterial2"
        Me.picMaterial2.Size = New System.Drawing.Size(32, 32)
        Me.picMaterial2.TabIndex = 0
        Me.picMaterial2.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.lblMaterialAmount1)
        Me.GroupBox6.Controls.Add(Me.lblMaterialName1)
        Me.GroupBox6.Controls.Add(Me.picMaterial1)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(7, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(422, 57)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'lblMaterialAmount1
        '
        Me.lblMaterialAmount1.AutoSize = True
        Me.lblMaterialAmount1.Location = New System.Drawing.Point(51, 32)
        Me.lblMaterialAmount1.Name = "lblMaterialAmount1"
        Me.lblMaterialAmount1.Size = New System.Drawing.Size(83, 13)
        Me.lblMaterialAmount1.TabIndex = 2
        Me.lblMaterialAmount1.Text = "Product Amount"
        '
        'lblMaterialName1
        '
        Me.lblMaterialName1.AutoSize = True
        Me.lblMaterialName1.Location = New System.Drawing.Point(51, 13)
        Me.lblMaterialName1.Name = "lblMaterialName1"
        Me.lblMaterialName1.Size = New System.Drawing.Size(72, 13)
        Me.lblMaterialName1.TabIndex = 1
        Me.lblMaterialName1.Text = "ProductName"
        '
        'picMaterial1
        '
        Me.picMaterial1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picMaterial1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMaterial1.Location = New System.Drawing.Point(9, 13)
        Me.picMaterial1.Name = "picMaterial1"
        Me.picMaterial1.Size = New System.Drawing.Size(32, 32)
        Me.picMaterial1.TabIndex = 0
        Me.picMaterial1.TabStop = False
        '
        'btnCraftClose
        '
        Me.btnCraftClose.BackgroundImage = CType(resources.GetObject("btnCraftClose.BackgroundImage"), System.Drawing.Image)
        Me.btnCraftClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCraftClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCraftClose.Font = New System.Drawing.Font("Modern No. 20", 8.249999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCraftClose.ForeColor = System.Drawing.Color.White
        Me.btnCraftClose.Location = New System.Drawing.Point(615, 473)
        Me.btnCraftClose.Name = "btnCraftClose"
        Me.btnCraftClose.Size = New System.Drawing.Size(75, 24)
        Me.btnCraftClose.TabIndex = 9
        Me.btnCraftClose.Text = "Close"
        Me.btnCraftClose.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.lblProductAmount)
        Me.GroupBox4.Controls.Add(Me.lblProductName)
        Me.GroupBox4.Controls.Add(Me.picProduct)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(259, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(435, 68)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Product"
        '
        'lblProductAmount
        '
        Me.lblProductAmount.AutoSize = True
        Me.lblProductAmount.Location = New System.Drawing.Point(51, 38)
        Me.lblProductAmount.Name = "lblProductAmount"
        Me.lblProductAmount.Size = New System.Drawing.Size(83, 13)
        Me.lblProductAmount.TabIndex = 2
        Me.lblProductAmount.Text = "Product Amount"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(51, 19)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(72, 13)
        Me.lblProductName.TabIndex = 1
        Me.lblProductName.Text = "ProductName"
        '
        'picProduct
        '
        Me.picProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Location = New System.Drawing.Point(9, 19)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(32, 32)
        Me.picProduct.TabIndex = 0
        Me.picProduct.TabStop = False
        '
        'pgbCraftProgress
        '
        Me.pgbCraftProgress.ForeColor = System.Drawing.Color.Lime
        Me.pgbCraftProgress.Location = New System.Drawing.Point(410, 418)
        Me.pgbCraftProgress.Name = "pgbCraftProgress"
        Me.pgbCraftProgress.Size = New System.Drawing.Size(199, 20)
        Me.pgbCraftProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgbCraftProgress.TabIndex = 8
        Me.pgbCraftProgress.Value = 95
        '
        'btnCraftStop
        '
        Me.btnCraftStop.BackgroundImage = CType(resources.GetObject("btnCraftStop.BackgroundImage"), System.Drawing.Image)
        Me.btnCraftStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCraftStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCraftStop.ForeColor = System.Drawing.Color.White
        Me.btnCraftStop.Location = New System.Drawing.Point(615, 416)
        Me.btnCraftStop.Name = "btnCraftStop"
        Me.btnCraftStop.Size = New System.Drawing.Size(75, 24)
        Me.btnCraftStop.TabIndex = 7
        Me.btnCraftStop.Text = "Stop Craft"
        Me.btnCraftStop.UseVisualStyleBackColor = True
        '
        'btnCraft
        '
        Me.btnCraft.BackgroundImage = CType(resources.GetObject("btnCraft.BackgroundImage"), System.Drawing.Image)
        Me.btnCraft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCraft.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCraft.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCraft.ForeColor = System.Drawing.Color.Transparent
        Me.btnCraft.Location = New System.Drawing.Point(259, 416)
        Me.btnCraft.Name = "btnCraft"
        Me.btnCraft.Size = New System.Drawing.Size(75, 24)
        Me.btnCraft.TabIndex = 6
        Me.btnCraft.Text = "Craft"
        Me.btnCraft.UseVisualStyleBackColor = True
        '
        'nudCraftAmount
        '
        Me.nudCraftAmount.Location = New System.Drawing.Point(340, 418)
        Me.nudCraftAmount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCraftAmount.Name = "nudCraftAmount"
        Me.nudCraftAmount.Size = New System.Drawing.Size(64, 20)
        Me.nudCraftAmount.TabIndex = 5
        Me.nudCraftAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCraftAmount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
        Me.nudCraftAmount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkKnownOnly
        '
        Me.chkKnownOnly.AutoSize = True
        Me.chkKnownOnly.BackColor = System.Drawing.Color.Transparent
        Me.chkKnownOnly.ForeColor = System.Drawing.Color.White
        Me.chkKnownOnly.Location = New System.Drawing.Point(11, 444)
        Me.chkKnownOnly.Name = "chkKnownOnly"
        Me.chkKnownOnly.Size = New System.Drawing.Size(155, 17)
        Me.chkKnownOnly.TabIndex = 3
        Me.chkKnownOnly.Text = "Show Known Recipes Only"
        Me.chkKnownOnly.UseVisualStyleBackColor = False
        '
        'lblCraftExp
        '
        Me.lblCraftExp.AutoSize = True
        Me.lblCraftExp.BackColor = System.Drawing.Color.Transparent
        Me.lblCraftExp.ForeColor = System.Drawing.Color.White
        Me.lblCraftExp.Location = New System.Drawing.Point(407, 448)
        Me.lblCraftExp.Name = "lblCraftExp"
        Me.lblCraftExp.Size = New System.Drawing.Size(157, 13)
        Me.lblCraftExp.TabIndex = 2
        Me.lblCraftExp.Text = "Current Craft Experience: 1/100"
        '
        'lblCraftLvl
        '
        Me.lblCraftLvl.AutoSize = True
        Me.lblCraftLvl.BackColor = System.Drawing.Color.Transparent
        Me.lblCraftLvl.ForeColor = System.Drawing.Color.White
        Me.lblCraftLvl.Location = New System.Drawing.Point(256, 448)
        Me.lblCraftLvl.Name = "lblCraftLvl"
        Me.lblCraftLvl.Size = New System.Drawing.Size(107, 13)
        Me.lblCraftLvl.TabIndex = 1
        Me.lblCraftLvl.Text = "Current Craft Level: 1"
        '
        'lstRecipe
        '
        Me.lstRecipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.lstRecipe.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstRecipe.ForeColor = System.Drawing.Color.White
        Me.lstRecipe.FormattingEnabled = True
        Me.lstRecipe.Location = New System.Drawing.Point(11, 11)
        Me.lstRecipe.Name = "lstRecipe"
        Me.lstRecipe.Size = New System.Drawing.Size(229, 416)
        Me.lstRecipe.TabIndex = 0
        '
        'tmrCraft
        '
        Me.tmrCraft.Interval = 1000
        '
        'frmMainGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 604)
        Me.Controls.Add(Me.pnlCraft)
        Me.Controls.Add(Me.pnlOptions)
        Me.Controls.Add(Me.pnlQuestLog)
        Me.Controls.Add(Me.pnlCurrency)
        Me.Controls.Add(Me.picscreen)
        Me.Controls.Add(Me.pnlTempBank)
        Me.Controls.Add(Me.pnlTmpSkill)
        Me.Controls.Add(Me.pnlTmpInv)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMainGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMainGame"
        CType(Me.picscreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCurrency.ResumeLayout(False)
        Me.pnlCurrency.PerformLayout()
        Me.pnlQuestLog.ResumeLayout(False)
        Me.pnlQuestLog.PerformLayout()
        Me.pnlCraft.ResumeLayout(False)
        Me.pnlCraft.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.picMaterial5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.picMaterial4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.picMaterial3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.picMaterial2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.picMaterial1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCraftAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picscreen As System.Windows.Forms.PictureBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents optMOff As System.Windows.Forms.RadioButton
    Friend WithEvents optMOn As System.Windows.Forms.RadioButton
    Friend WithEvents optSOff As System.Windows.Forms.RadioButton
    Friend WithEvents optSOn As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTmpInv As System.Windows.Forms.Panel
    Friend WithEvents pnlCurrency As System.Windows.Forms.Panel
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyCancel As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyOk As System.Windows.Forms.Label
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents pnlTempBank As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlQuestLog As Windows.Forms.Panel
    Friend WithEvents lblQuestLogClose As Windows.Forms.Label
    Friend WithEvents lblAbandonQuest As Windows.Forms.Label
    Friend WithEvents lblQuestRewards As Windows.Forms.Label
    Friend WithEvents lblQuestRequirements As Windows.Forms.Label
    Friend WithEvents lblQuestStatus2 As Windows.Forms.Label
    Friend WithEvents lblQuestStatus As Windows.Forms.Label
    Friend WithEvents txtQuestDialog As Windows.Forms.TextBox
    Friend WithEvents lblQuestDialog As Windows.Forms.Label
    Friend WithEvents txtActualTask As Windows.Forms.TextBox
    Friend WithEvents lblTaskLog As Windows.Forms.Label
    Friend WithEvents lblActualTask As Windows.Forms.Label
    Friend WithEvents lstQuestLog As Windows.Forms.ListBox
    Friend WithEvents txtQuestTaskLog As Windows.Forms.TextBox
    Friend WithEvents pnlTmpSkill As Windows.Forms.Panel
    Friend WithEvents tmrShake As Windows.Forms.Timer
    Friend WithEvents lblVolume As Windows.Forms.Label
    Friend WithEvents scrlVolume As Windows.Forms.HScrollBar
    Friend WithEvents btnSaveSettings As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cmbScreenSize As Windows.Forms.ComboBox
    Friend WithEvents pnlCraft As Windows.Forms.Panel
    Friend WithEvents btnCraftClose As Windows.Forms.Button
    Friend WithEvents pgbCraftProgress As Windows.Forms.ProgressBar
    Friend WithEvents btnCraftStop As Windows.Forms.Button
    Friend WithEvents btnCraft As Windows.Forms.Button
    Friend WithEvents nudCraftAmount As Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As Windows.Forms.GroupBox
    Friend WithEvents lblMaterialAmount5 As Windows.Forms.Label
    Friend WithEvents lblMaterialName5 As Windows.Forms.Label
    Friend WithEvents picMaterial5 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox9 As Windows.Forms.GroupBox
    Friend WithEvents lblMaterialAmount4 As Windows.Forms.Label
    Friend WithEvents lblMaterialName4 As Windows.Forms.Label
    Friend WithEvents picMaterial4 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox8 As Windows.Forms.GroupBox
    Friend WithEvents lblMaterialAmount3 As Windows.Forms.Label
    Friend WithEvents lblMaterialName3 As Windows.Forms.Label
    Friend WithEvents picMaterial3 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox7 As Windows.Forms.GroupBox
    Friend WithEvents lblMaterialAmount2 As Windows.Forms.Label
    Friend WithEvents lblMaterialName2 As Windows.Forms.Label
    Friend WithEvents picMaterial2 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents lblMaterialAmount1 As Windows.Forms.Label
    Friend WithEvents lblMaterialName1 As Windows.Forms.Label
    Friend WithEvents picMaterial1 As Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents lblProductAmount As Windows.Forms.Label
    Friend WithEvents lblProductName As Windows.Forms.Label
    Friend WithEvents picProduct As Windows.Forms.PictureBox
    Friend WithEvents chkKnownOnly As Windows.Forms.CheckBox
    Friend WithEvents lblCraftExp As Windows.Forms.Label
    Friend WithEvents lblCraftLvl As Windows.Forms.Label
    Friend WithEvents lstRecipe As Windows.Forms.ListBox
    Friend WithEvents tmrCraft As Windows.Forms.Timer
End Class
