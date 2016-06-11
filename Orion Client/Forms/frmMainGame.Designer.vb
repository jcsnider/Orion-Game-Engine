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
        CType(Me.picscreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOptions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCurrency.SuspendLayout()
        Me.pnlQuestLog.SuspendLayout()
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
        'frmMainGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 604)
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
End Class
