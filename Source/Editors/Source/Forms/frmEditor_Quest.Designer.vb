<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Quest
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
        Me.fraQuestList = New DarkUI.Controls.DarkGroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        Me.DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
        Me.btnRemoveTask = New DarkUI.Controls.DarkButton()
        Me.btnAddTask = New DarkUI.Controls.DarkButton()
        Me.lstTasks = New System.Windows.Forms.ListBox()
        Me.DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        Me.lstRequirements = New System.Windows.Forms.ListBox()
        Me.btnRemoveRequirement = New DarkUI.Controls.DarkButton()
        Me.btnAddRequirement = New DarkUI.Controls.DarkButton()
        Me.DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        Me.nudItemRewValue = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel7 = New DarkUI.Controls.DarkLabel()
        Me.cmbItemReward = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
        Me.nudExpReward = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
        Me.btnRemoveReward = New DarkUI.Controls.DarkButton()
        Me.btnAddReward = New DarkUI.Controls.DarkButton()
        Me.lstRewards = New System.Windows.Forms.ListBox()
        Me.DarkLabel4 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel3 = New DarkUI.Controls.DarkLabel()
        Me.txtEndText = New DarkUI.Controls.DarkTextBox()
        Me.txtProgressText = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
        Me.txtStartText = New DarkUI.Controls.DarkTextBox()
        Me.chkQuestCancel = New DarkUI.Controls.DarkCheckBox()
        Me.chkRepeat = New DarkUI.Controls.DarkCheckBox()
        Me.txtName = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel8 = New DarkUI.Controls.DarkLabel()
        Me.btnSave = New DarkUI.Controls.DarkButton()
        Me.btnCancel = New DarkUI.Controls.DarkButton()
        Me.fraTasks = New DarkUI.Controls.DarkGroupBox()
        Me.btnCancelTask = New DarkUI.Controls.DarkButton()
        Me.btnSaveTask = New DarkUI.Controls.DarkButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optTask7 = New DarkUI.Controls.DarkRadioButton()
        Me.optTask6 = New DarkUI.Controls.DarkRadioButton()
        Me.optTask5 = New DarkUI.Controls.DarkRadioButton()
        Me.optTask4 = New DarkUI.Controls.DarkRadioButton()
        Me.optTask3 = New DarkUI.Controls.DarkRadioButton()
        Me.optTask2 = New DarkUI.Controls.DarkRadioButton()
        Me.DarkLabel16 = New DarkUI.Controls.DarkLabel()
        Me.optTask1 = New DarkUI.Controls.DarkRadioButton()
        Me.optTask0 = New DarkUI.Controls.DarkRadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbResource = New DarkUI.Controls.DarkComboBox()
        Me.cmbMap = New DarkUI.Controls.DarkComboBox()
        Me.cmbItem = New DarkUI.Controls.DarkComboBox()
        Me.cmbNpc = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel17 = New DarkUI.Controls.DarkLabel()
        Me.lblTaskNum = New DarkUI.Controls.DarkLabel()
        Me.nudAmount = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel15 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel14 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel13 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel12 = New DarkUI.Controls.DarkLabel()
        Me.DarkLabel11 = New DarkUI.Controls.DarkLabel()
        Me.chkEnd = New DarkUI.Controls.DarkCheckBox()
        Me.txtTaskSpeech = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel10 = New DarkUI.Controls.DarkLabel()
        Me.txtTaskLog = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel9 = New DarkUI.Controls.DarkLabel()
        Me.fraRequirements = New DarkUI.Controls.DarkGroupBox()
        Me.DarkGroupBox6 = New DarkUI.Controls.DarkGroupBox()
        Me.btnRequirementCancel = New DarkUI.Controls.DarkButton()
        Me.btnRequirementSave = New DarkUI.Controls.DarkButton()
        Me.nudTakeAmount = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel23 = New DarkUI.Controls.DarkLabel()
        Me.cmbEndItem = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel24 = New DarkUI.Controls.DarkLabel()
        Me.nudGiveAmount = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel22 = New DarkUI.Controls.DarkLabel()
        Me.cmbStartItem = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel21 = New DarkUI.Controls.DarkLabel()
        Me.cmbClassReq = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel20 = New DarkUI.Controls.DarkLabel()
        Me.rdbClassReq = New DarkUI.Controls.DarkRadioButton()
        Me.cmbQuestReq = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel19 = New DarkUI.Controls.DarkLabel()
        Me.rdbQuestReq = New DarkUI.Controls.DarkRadioButton()
        Me.cmbItemReq = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel18 = New DarkUI.Controls.DarkLabel()
        Me.rdbItemReq = New DarkUI.Controls.DarkRadioButton()
        Me.rdbNoneReq = New DarkUI.Controls.DarkRadioButton()
        Me.fraQuestList.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        Me.DarkGroupBox5.SuspendLayout()
        Me.DarkGroupBox4.SuspendLayout()
        Me.DarkGroupBox3.SuspendLayout()
        CType(Me.nudItemRewValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExpReward, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraTasks.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraRequirements.SuspendLayout()
        Me.DarkGroupBox6.SuspendLayout()
        CType(Me.nudTakeAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGiveAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraQuestList
        '
        Me.fraQuestList.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraQuestList.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.fraQuestList.Controls.Add(Me.lstIndex)
        Me.fraQuestList.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraQuestList.Location = New System.Drawing.Point(3, 3)
        Me.fraQuestList.Name = "fraQuestList"
        Me.fraQuestList.Size = New System.Drawing.Size(212, 486)
        Me.fraQuestList.TabIndex = 0
        Me.fraQuestList.TabStop = False
        Me.fraQuestList.Text = "Quest List"
        '
        'lstIndex
        '
        Me.lstIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(9, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(194, 457)
        Me.lstIndex.TabIndex = 1
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox5)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox4)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox3)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel4)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel3)
        Me.DarkGroupBox2.Controls.Add(Me.txtEndText)
        Me.DarkGroupBox2.Controls.Add(Me.txtProgressText)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel2)
        Me.DarkGroupBox2.Controls.Add(Me.txtStartText)
        Me.DarkGroupBox2.Controls.Add(Me.chkQuestCancel)
        Me.DarkGroupBox2.Controls.Add(Me.chkRepeat)
        Me.DarkGroupBox2.Controls.Add(Me.txtName)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel1)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(221, 3)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Size = New System.Drawing.Size(497, 458)
        Me.DarkGroupBox2.TabIndex = 1
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "General Settings"
        '
        'DarkGroupBox5
        '
        Me.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox5.Controls.Add(Me.btnRemoveTask)
        Me.DarkGroupBox5.Controls.Add(Me.btnAddTask)
        Me.DarkGroupBox5.Controls.Add(Me.lstTasks)
        Me.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox5.Location = New System.Drawing.Point(249, 254)
        Me.DarkGroupBox5.Name = "DarkGroupBox5"
        Me.DarkGroupBox5.Size = New System.Drawing.Size(243, 199)
        Me.DarkGroupBox5.TabIndex = 12
        Me.DarkGroupBox5.TabStop = False
        Me.DarkGroupBox5.Text = "Quest Tasks"
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Location = New System.Drawing.Point(121, 170)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Padding = New System.Windows.Forms.Padding(5)
        Me.btnRemoveTask.Size = New System.Drawing.Size(118, 23)
        Me.btnRemoveTask.TabIndex = 5
        Me.btnRemoveTask.Text = "Remove Task"
        '
        'btnAddTask
        '
        Me.btnAddTask.Location = New System.Drawing.Point(4, 170)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Padding = New System.Windows.Forms.Padding(5)
        Me.btnAddTask.Size = New System.Drawing.Size(111, 23)
        Me.btnAddTask.TabIndex = 4
        Me.btnAddTask.Text = "Add Task"
        '
        'lstTasks
        '
        Me.lstTasks.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstTasks.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstTasks.FormattingEnabled = True
        Me.lstTasks.Location = New System.Drawing.Point(6, 19)
        Me.lstTasks.Name = "lstTasks"
        Me.lstTasks.Size = New System.Drawing.Size(231, 145)
        Me.lstTasks.TabIndex = 3
        '
        'DarkGroupBox4
        '
        Me.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox4.Controls.Add(Me.lstRequirements)
        Me.DarkGroupBox4.Controls.Add(Me.btnRemoveRequirement)
        Me.DarkGroupBox4.Controls.Add(Me.btnAddRequirement)
        Me.DarkGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox4.Location = New System.Drawing.Point(0, 254)
        Me.DarkGroupBox4.Name = "DarkGroupBox4"
        Me.DarkGroupBox4.Size = New System.Drawing.Size(243, 199)
        Me.DarkGroupBox4.TabIndex = 11
        Me.DarkGroupBox4.TabStop = False
        Me.DarkGroupBox4.Text = "Quest Requirements"
        '
        'lstRequirements
        '
        Me.lstRequirements.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstRequirements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstRequirements.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstRequirements.FormattingEnabled = True
        Me.lstRequirements.Location = New System.Drawing.Point(6, 19)
        Me.lstRequirements.Name = "lstRequirements"
        Me.lstRequirements.Size = New System.Drawing.Size(231, 145)
        Me.lstRequirements.TabIndex = 2
        '
        'btnRemoveRequirement
        '
        Me.btnRemoveRequirement.Location = New System.Drawing.Point(110, 170)
        Me.btnRemoveRequirement.Name = "btnRemoveRequirement"
        Me.btnRemoveRequirement.Padding = New System.Windows.Forms.Padding(5)
        Me.btnRemoveRequirement.Size = New System.Drawing.Size(129, 23)
        Me.btnRemoveRequirement.TabIndex = 1
        Me.btnRemoveRequirement.Text = "Remove Requirement"
        '
        'btnAddRequirement
        '
        Me.btnAddRequirement.Location = New System.Drawing.Point(4, 170)
        Me.btnAddRequirement.Name = "btnAddRequirement"
        Me.btnAddRequirement.Padding = New System.Windows.Forms.Padding(5)
        Me.btnAddRequirement.Size = New System.Drawing.Size(102, 23)
        Me.btnAddRequirement.TabIndex = 0
        Me.btnAddRequirement.Text = "Add Requirement"
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.nudItemRewValue)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel7)
        Me.DarkGroupBox3.Controls.Add(Me.cmbItemReward)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel6)
        Me.DarkGroupBox3.Controls.Add(Me.nudExpReward)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel5)
        Me.DarkGroupBox3.Controls.Add(Me.btnRemoveReward)
        Me.DarkGroupBox3.Controls.Add(Me.btnAddReward)
        Me.DarkGroupBox3.Controls.Add(Me.lstRewards)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(6, 143)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Size = New System.Drawing.Size(485, 105)
        Me.DarkGroupBox3.TabIndex = 10
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Rewards"
        '
        'nudItemRewValue
        '
        Me.nudItemRewValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudItemRewValue.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudItemRewValue.Location = New System.Drawing.Point(380, 79)
        Me.nudItemRewValue.Name = "nudItemRewValue"
        Me.nudItemRewValue.Size = New System.Drawing.Size(99, 20)
        Me.nudItemRewValue.TabIndex = 8
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(328, 81)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(46, 13)
        Me.DarkLabel7.TabIndex = 7
        Me.DarkLabel7.Text = "Amount:"
        '
        'cmbItemReward
        '
        Me.cmbItemReward.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbItemReward.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbItemReward.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbItemReward.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbItemReward.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemReward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbItemReward.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbItemReward.FormattingEnabled = True
        Me.cmbItemReward.Location = New System.Drawing.Point(364, 52)
        Me.cmbItemReward.Name = "cmbItemReward"
        Me.cmbItemReward.Size = New System.Drawing.Size(115, 21)
        Me.cmbItemReward.TabIndex = 6
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(328, 55)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(30, 13)
        Me.DarkLabel6.TabIndex = 5
        Me.DarkLabel6.Text = "Item:"
        '
        'nudExpReward
        '
        Me.nudExpReward.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudExpReward.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudExpReward.Location = New System.Drawing.Point(399, 22)
        Me.nudExpReward.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.nudExpReward.Name = "nudExpReward"
        Me.nudExpReward.Size = New System.Drawing.Size(80, 20)
        Me.nudExpReward.TabIndex = 4
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(328, 24)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(65, 13)
        Me.DarkLabel5.TabIndex = 3
        Me.DarkLabel5.Text = "Exp Gained:"
        '
        'btnRemoveReward
        '
        Me.btnRemoveReward.Location = New System.Drawing.Point(247, 76)
        Me.btnRemoveReward.Name = "btnRemoveReward"
        Me.btnRemoveReward.Padding = New System.Windows.Forms.Padding(5)
        Me.btnRemoveReward.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveReward.TabIndex = 2
        Me.btnRemoveReward.Text = "Remove"
        '
        'btnAddReward
        '
        Me.btnAddReward.Location = New System.Drawing.Point(247, 19)
        Me.btnAddReward.Name = "btnAddReward"
        Me.btnAddReward.Padding = New System.Windows.Forms.Padding(5)
        Me.btnAddReward.Size = New System.Drawing.Size(75, 23)
        Me.btnAddReward.TabIndex = 1
        Me.btnAddReward.Text = "Add"
        '
        'lstRewards
        '
        Me.lstRewards.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstRewards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstRewards.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstRewards.FormattingEnabled = True
        Me.lstRewards.Location = New System.Drawing.Point(6, 19)
        Me.lstRewards.Name = "lstRewards"
        Me.lstRewards.Size = New System.Drawing.Size(235, 80)
        Me.lstRewards.TabIndex = 0
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(323, 56)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(50, 13)
        Me.DarkLabel4.TabIndex = 9
        Me.DarkLabel4.Text = "End Text"
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(163, 56)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(84, 13)
        Me.DarkLabel3.TabIndex = 8
        Me.DarkLabel3.Text = "In Progress Text"
        '
        'txtEndText
        '
        Me.txtEndText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtEndText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtEndText.Location = New System.Drawing.Point(326, 72)
        Me.txtEndText.Multiline = True
        Me.txtEndText.Name = "txtEndText"
        Me.txtEndText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEndText.Size = New System.Drawing.Size(154, 65)
        Me.txtEndText.TabIndex = 7
        '
        'txtProgressText
        '
        Me.txtProgressText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtProgressText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProgressText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtProgressText.Location = New System.Drawing.Point(166, 72)
        Me.txtProgressText.Multiline = True
        Me.txtProgressText.Name = "txtProgressText"
        Me.txtProgressText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProgressText.Size = New System.Drawing.Size(154, 65)
        Me.txtProgressText.TabIndex = 6
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(6, 56)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(53, 13)
        Me.DarkLabel2.TabIndex = 5
        Me.DarkLabel2.Text = "Start Text"
        '
        'txtStartText
        '
        Me.txtStartText.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtStartText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtStartText.Location = New System.Drawing.Point(6, 72)
        Me.txtStartText.Multiline = True
        Me.txtStartText.Name = "txtStartText"
        Me.txtStartText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStartText.Size = New System.Drawing.Size(154, 65)
        Me.txtStartText.TabIndex = 4
        '
        'chkQuestCancel
        '
        Me.chkQuestCancel.AutoSize = True
        Me.chkQuestCancel.Location = New System.Drawing.Point(372, 20)
        Me.chkQuestCancel.Name = "chkQuestCancel"
        Me.chkQuestCancel.Size = New System.Drawing.Size(90, 17)
        Me.chkQuestCancel.TabIndex = 3
        Me.chkQuestCancel.Text = "Cancel Quest"
        '
        'chkRepeat
        '
        Me.chkRepeat.AutoSize = True
        Me.chkRepeat.Location = New System.Drawing.Point(279, 20)
        Me.chkRepeat.Name = "chkRepeat"
        Me.chkRepeat.Size = New System.Drawing.Size(87, 17)
        Me.chkRepeat.TabIndex = 2
        Me.chkRepeat.Text = "Repeatable?"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(81, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(192, 20)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(6, 21)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(69, 13)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Quest Name:"
        '
        'DarkLabel8
        '
        Me.DarkLabel8.AutoSize = True
        Me.DarkLabel8.ForeColor = System.Drawing.Color.Red
        Me.DarkLabel8.Location = New System.Drawing.Point(221, 464)
        Me.DarkLabel8.Name = "DarkLabel8"
        Me.DarkLabel8.Size = New System.Drawing.Size(218, 13)
        Me.DarkLabel8.TabIndex = 2
        Me.DarkLabel8.Text = "Use /questreset # to reset a quest for testing"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(553, 467)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(634, 467)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'fraTasks
        '
        Me.fraTasks.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraTasks.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.fraTasks.Controls.Add(Me.btnCancelTask)
        Me.fraTasks.Controls.Add(Me.btnSaveTask)
        Me.fraTasks.Controls.Add(Me.Panel2)
        Me.fraTasks.Controls.Add(Me.Panel1)
        Me.fraTasks.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraTasks.Location = New System.Drawing.Point(724, 3)
        Me.fraTasks.Name = "fraTasks"
        Me.fraTasks.Size = New System.Drawing.Size(719, 497)
        Me.fraTasks.TabIndex = 5
        Me.fraTasks.TabStop = False
        Me.fraTasks.Text = "Tasks"
        '
        'btnCancelTask
        '
        Me.btnCancelTask.Location = New System.Drawing.Point(139, 345)
        Me.btnCancelTask.Name = "btnCancelTask"
        Me.btnCancelTask.Padding = New System.Windows.Forms.Padding(5)
        Me.btnCancelTask.Size = New System.Drawing.Size(112, 23)
        Me.btnCancelTask.TabIndex = 3
        Me.btnCancelTask.Text = "Cancel Task"
        '
        'btnSaveTask
        '
        Me.btnSaveTask.Location = New System.Drawing.Point(6, 345)
        Me.btnSaveTask.Name = "btnSaveTask"
        Me.btnSaveTask.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSaveTask.Size = New System.Drawing.Size(110, 23)
        Me.btnSaveTask.TabIndex = 2
        Me.btnSaveTask.Text = "Save Task"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optTask7)
        Me.Panel2.Controls.Add(Me.optTask6)
        Me.Panel2.Controls.Add(Me.optTask5)
        Me.Panel2.Controls.Add(Me.optTask4)
        Me.Panel2.Controls.Add(Me.optTask3)
        Me.Panel2.Controls.Add(Me.optTask2)
        Me.Panel2.Controls.Add(Me.DarkLabel16)
        Me.Panel2.Controls.Add(Me.optTask1)
        Me.Panel2.Controls.Add(Me.optTask0)
        Me.Panel2.Location = New System.Drawing.Point(257, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(154, 197)
        Me.Panel2.TabIndex = 1
        '
        'optTask7
        '
        Me.optTask7.AutoSize = True
        Me.optTask7.Location = New System.Drawing.Point(6, 175)
        Me.optTask7.Name = "optTask7"
        Me.optTask7.Size = New System.Drawing.Size(111, 17)
        Me.optTask7.TabIndex = 8
        Me.optTask7.TabStop = True
        Me.optTask7.Text = "Get Item from Npc"
        '
        'optTask6
        '
        Me.optTask6.AutoSize = True
        Me.optTask6.Location = New System.Drawing.Point(6, 152)
        Me.optTask6.Name = "optTask6"
        Me.optTask6.Size = New System.Drawing.Size(111, 17)
        Me.optTask6.TabIndex = 7
        Me.optTask6.TabStop = True
        Me.optTask6.Text = "Gather Resources"
        '
        'optTask5
        '
        Me.optTask5.AutoSize = True
        Me.optTask5.Location = New System.Drawing.Point(6, 129)
        Me.optTask5.Name = "optTask5"
        Me.optTask5.Size = New System.Drawing.Size(105, 17)
        Me.optTask5.TabIndex = 6
        Me.optTask5.TabStop = True
        Me.optTask5.Text = "Give Item to Npc"
        '
        'optTask4
        '
        Me.optTask4.AutoSize = True
        Me.optTask4.Location = New System.Drawing.Point(6, 106)
        Me.optTask4.Name = "optTask4"
        Me.optTask4.Size = New System.Drawing.Size(81, 17)
        Me.optTask4.TabIndex = 5
        Me.optTask4.TabStop = True
        Me.optTask4.Text = "Reach Map"
        '
        'optTask3
        '
        Me.optTask3.AutoSize = True
        Me.optTask3.Location = New System.Drawing.Point(6, 83)
        Me.optTask3.Name = "optTask3"
        Me.optTask3.Size = New System.Drawing.Size(85, 17)
        Me.optTask3.TabIndex = 4
        Me.optTask3.TabStop = True
        Me.optTask3.Text = "Talk To Npc"
        '
        'optTask2
        '
        Me.optTask2.AutoSize = True
        Me.optTask2.Location = New System.Drawing.Point(6, 60)
        Me.optTask2.Name = "optTask2"
        Me.optTask2.Size = New System.Drawing.Size(85, 17)
        Me.optTask2.TabIndex = 3
        Me.optTask2.TabStop = True
        Me.optTask2.Text = "Gather Items"
        '
        'DarkLabel16
        '
        Me.DarkLabel16.AutoSize = True
        Me.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel16.Location = New System.Drawing.Point(3, 25)
        Me.DarkLabel16.Name = "DarkLabel16"
        Me.DarkLabel16.Size = New System.Drawing.Size(145, 13)
        Me.DarkLabel16.TabIndex = 2
        Me.DarkLabel16.Text = "----------------------------------------------"
        '
        'optTask1
        '
        Me.optTask1.AutoSize = True
        Me.optTask1.Location = New System.Drawing.Point(6, 37)
        Me.optTask1.Name = "optTask1"
        Me.optTask1.Size = New System.Drawing.Size(87, 17)
        Me.optTask1.TabIndex = 1
        Me.optTask1.TabStop = True
        Me.optTask1.Text = "Defeat Npc's"
        '
        'optTask0
        '
        Me.optTask0.AutoSize = True
        Me.optTask0.Location = New System.Drawing.Point(6, 5)
        Me.optTask0.Name = "optTask0"
        Me.optTask0.Size = New System.Drawing.Size(62, 17)
        Me.optTask0.TabIndex = 0
        Me.optTask0.TabStop = True
        Me.optTask0.Text = "Nothing"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbResource)
        Me.Panel1.Controls.Add(Me.cmbMap)
        Me.Panel1.Controls.Add(Me.cmbItem)
        Me.Panel1.Controls.Add(Me.cmbNpc)
        Me.Panel1.Controls.Add(Me.DarkLabel17)
        Me.Panel1.Controls.Add(Me.lblTaskNum)
        Me.Panel1.Controls.Add(Me.nudAmount)
        Me.Panel1.Controls.Add(Me.DarkLabel15)
        Me.Panel1.Controls.Add(Me.DarkLabel14)
        Me.Panel1.Controls.Add(Me.DarkLabel13)
        Me.Panel1.Controls.Add(Me.DarkLabel12)
        Me.Panel1.Controls.Add(Me.DarkLabel11)
        Me.Panel1.Controls.Add(Me.chkEnd)
        Me.Panel1.Controls.Add(Me.txtTaskSpeech)
        Me.Panel1.Controls.Add(Me.DarkLabel10)
        Me.Panel1.Controls.Add(Me.txtTaskLog)
        Me.Panel1.Controls.Add(Me.DarkLabel9)
        Me.Panel1.Location = New System.Drawing.Point(6, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(245, 320)
        Me.Panel1.TabIndex = 0
        '
        'cmbResource
        '
        Me.cmbResource.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbResource.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbResource.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbResource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbResource.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbResource.FormattingEnabled = True
        Me.cmbResource.Location = New System.Drawing.Point(62, 199)
        Me.cmbResource.Name = "cmbResource"
        Me.cmbResource.Size = New System.Drawing.Size(121, 21)
        Me.cmbResource.TabIndex = 20
        '
        'cmbMap
        '
        Me.cmbMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMap.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbMap.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMap.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMap.FormattingEnabled = True
        Me.cmbMap.Location = New System.Drawing.Point(62, 173)
        Me.cmbMap.Name = "cmbMap"
        Me.cmbMap.Size = New System.Drawing.Size(121, 21)
        Me.cmbMap.TabIndex = 19
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbItem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbItem.FormattingEnabled = True
        Me.cmbItem.Location = New System.Drawing.Point(62, 147)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(121, 21)
        Me.cmbItem.TabIndex = 18
        '
        'cmbNpc
        '
        Me.cmbNpc.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbNpc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbNpc.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbNpc.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbNpc.FormattingEnabled = True
        Me.cmbNpc.Location = New System.Drawing.Point(62, 121)
        Me.cmbNpc.Name = "cmbNpc"
        Me.cmbNpc.Size = New System.Drawing.Size(121, 21)
        Me.cmbNpc.TabIndex = 17
        '
        'DarkLabel17
        '
        Me.DarkLabel17.AutoSize = True
        Me.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel17.Location = New System.Drawing.Point(7, 223)
        Me.DarkLabel17.Name = "DarkLabel17"
        Me.DarkLabel17.Size = New System.Drawing.Size(232, 13)
        Me.DarkLabel17.TabIndex = 16
        Me.DarkLabel17.Text = "---------------------------------------------------------------------------"
        '
        'lblTaskNum
        '
        Me.lblTaskNum.AutoSize = True
        Me.lblTaskNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblTaskNum.Location = New System.Drawing.Point(3, 297)
        Me.lblTaskNum.Name = "lblTaskNum"
        Me.lblTaskNum.Size = New System.Drawing.Size(74, 13)
        Me.lblTaskNum.TabIndex = 15
        Me.lblTaskNum.Text = "Task Number:"
        '
        'nudAmount
        '
        Me.nudAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudAmount.Location = New System.Drawing.Point(63, 239)
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(120, 20)
        Me.nudAmount.TabIndex = 14
        '
        'DarkLabel15
        '
        Me.DarkLabel15.AutoSize = True
        Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel15.Location = New System.Drawing.Point(3, 241)
        Me.DarkLabel15.Name = "DarkLabel15"
        Me.DarkLabel15.Size = New System.Drawing.Size(46, 13)
        Me.DarkLabel15.TabIndex = 13
        Me.DarkLabel15.Text = "Amount:"
        '
        'DarkLabel14
        '
        Me.DarkLabel14.AutoSize = True
        Me.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel14.Location = New System.Drawing.Point(3, 202)
        Me.DarkLabel14.Name = "DarkLabel14"
        Me.DarkLabel14.Size = New System.Drawing.Size(56, 13)
        Me.DarkLabel14.TabIndex = 11
        Me.DarkLabel14.Text = "Resource:"
        '
        'DarkLabel13
        '
        Me.DarkLabel13.AutoSize = True
        Me.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel13.Location = New System.Drawing.Point(3, 176)
        Me.DarkLabel13.Name = "DarkLabel13"
        Me.DarkLabel13.Size = New System.Drawing.Size(31, 13)
        Me.DarkLabel13.TabIndex = 9
        Me.DarkLabel13.Text = "Map:"
        '
        'DarkLabel12
        '
        Me.DarkLabel12.AutoSize = True
        Me.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel12.Location = New System.Drawing.Point(3, 150)
        Me.DarkLabel12.Name = "DarkLabel12"
        Me.DarkLabel12.Size = New System.Drawing.Size(30, 13)
        Me.DarkLabel12.TabIndex = 7
        Me.DarkLabel12.Text = "Item:"
        '
        'DarkLabel11
        '
        Me.DarkLabel11.AutoSize = True
        Me.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel11.Location = New System.Drawing.Point(3, 124)
        Me.DarkLabel11.Name = "DarkLabel11"
        Me.DarkLabel11.Size = New System.Drawing.Size(30, 13)
        Me.DarkLabel11.TabIndex = 5
        Me.DarkLabel11.Text = "Npc:"
        '
        'chkEnd
        '
        Me.chkEnd.AutoSize = True
        Me.chkEnd.ForeColor = System.Drawing.Color.Lime
        Me.chkEnd.Location = New System.Drawing.Point(3, 86)
        Me.chkEnd.Name = "chkEnd"
        Me.chkEnd.Size = New System.Drawing.Size(107, 17)
        Me.chkEnd.TabIndex = 4
        Me.chkEnd.Text = "End Quest Now?"
        '
        'txtTaskSpeech
        '
        Me.txtTaskSpeech.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtTaskSpeech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaskSpeech.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtTaskSpeech.Location = New System.Drawing.Point(3, 60)
        Me.txtTaskSpeech.Name = "txtTaskSpeech"
        Me.txtTaskSpeech.Size = New System.Drawing.Size(236, 20)
        Me.txtTaskSpeech.TabIndex = 3
        '
        'DarkLabel10
        '
        Me.DarkLabel10.AutoSize = True
        Me.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel10.Location = New System.Drawing.Point(3, 44)
        Me.DarkLabel10.Name = "DarkLabel10"
        Me.DarkLabel10.Size = New System.Drawing.Size(71, 13)
        Me.DarkLabel10.TabIndex = 2
        Me.DarkLabel10.Text = "Task Speech"
        '
        'txtTaskLog
        '
        Me.txtTaskLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtTaskLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaskLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtTaskLog.Location = New System.Drawing.Point(3, 21)
        Me.txtTaskLog.Name = "txtTaskLog"
        Me.txtTaskLog.Size = New System.Drawing.Size(236, 20)
        Me.txtTaskLog.TabIndex = 1
        '
        'DarkLabel9
        '
        Me.DarkLabel9.AutoSize = True
        Me.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel9.Location = New System.Drawing.Point(3, 5)
        Me.DarkLabel9.Name = "DarkLabel9"
        Me.DarkLabel9.Size = New System.Drawing.Size(52, 13)
        Me.DarkLabel9.TabIndex = 0
        Me.DarkLabel9.Text = "Task Log"
        '
        'fraRequirements
        '
        Me.fraRequirements.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.fraRequirements.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.fraRequirements.Controls.Add(Me.DarkGroupBox6)
        Me.fraRequirements.Controls.Add(Me.cmbClassReq)
        Me.fraRequirements.Controls.Add(Me.DarkLabel20)
        Me.fraRequirements.Controls.Add(Me.rdbClassReq)
        Me.fraRequirements.Controls.Add(Me.cmbQuestReq)
        Me.fraRequirements.Controls.Add(Me.DarkLabel19)
        Me.fraRequirements.Controls.Add(Me.rdbQuestReq)
        Me.fraRequirements.Controls.Add(Me.cmbItemReq)
        Me.fraRequirements.Controls.Add(Me.DarkLabel18)
        Me.fraRequirements.Controls.Add(Me.rdbItemReq)
        Me.fraRequirements.Controls.Add(Me.rdbNoneReq)
        Me.fraRequirements.ForeColor = System.Drawing.Color.Gainsboro
        Me.fraRequirements.Location = New System.Drawing.Point(724, 3)
        Me.fraRequirements.Name = "fraRequirements"
        Me.fraRequirements.Size = New System.Drawing.Size(719, 497)
        Me.fraRequirements.TabIndex = 6
        Me.fraRequirements.TabStop = False
        Me.fraRequirements.Text = "Requirements"
        '
        'DarkGroupBox6
        '
        Me.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox6.Controls.Add(Me.btnRequirementCancel)
        Me.DarkGroupBox6.Controls.Add(Me.btnRequirementSave)
        Me.DarkGroupBox6.Controls.Add(Me.nudTakeAmount)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel23)
        Me.DarkGroupBox6.Controls.Add(Me.cmbEndItem)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel24)
        Me.DarkGroupBox6.Controls.Add(Me.nudGiveAmount)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel22)
        Me.DarkGroupBox6.Controls.Add(Me.cmbStartItem)
        Me.DarkGroupBox6.Controls.Add(Me.DarkLabel21)
        Me.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox6.Location = New System.Drawing.Point(6, 159)
        Me.DarkGroupBox6.Name = "DarkGroupBox6"
        Me.DarkGroupBox6.Size = New System.Drawing.Size(338, 288)
        Me.DarkGroupBox6.TabIndex = 10
        Me.DarkGroupBox6.TabStop = False
        Me.DarkGroupBox6.Text = "Items Needed For Quest"
        '
        'btnRequirementCancel
        '
        Me.btnRequirementCancel.Location = New System.Drawing.Point(257, 259)
        Me.btnRequirementCancel.Name = "btnRequirementCancel"
        Me.btnRequirementCancel.Padding = New System.Windows.Forms.Padding(5)
        Me.btnRequirementCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnRequirementCancel.TabIndex = 9
        Me.btnRequirementCancel.Text = "Cancel"
        '
        'btnRequirementSave
        '
        Me.btnRequirementSave.Location = New System.Drawing.Point(176, 259)
        Me.btnRequirementSave.Name = "btnRequirementSave"
        Me.btnRequirementSave.Padding = New System.Windows.Forms.Padding(5)
        Me.btnRequirementSave.Size = New System.Drawing.Size(75, 23)
        Me.btnRequirementSave.TabIndex = 8
        Me.btnRequirementSave.Text = "Save"
        '
        'nudTakeAmount
        '
        Me.nudTakeAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudTakeAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudTakeAmount.Location = New System.Drawing.Point(262, 73)
        Me.nudTakeAmount.Name = "nudTakeAmount"
        Me.nudTakeAmount.Size = New System.Drawing.Size(70, 20)
        Me.nudTakeAmount.TabIndex = 7
        '
        'DarkLabel23
        '
        Me.DarkLabel23.AutoSize = True
        Me.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel23.Location = New System.Drawing.Point(210, 75)
        Me.DarkLabel23.Name = "DarkLabel23"
        Me.DarkLabel23.Size = New System.Drawing.Size(46, 13)
        Me.DarkLabel23.TabIndex = 6
        Me.DarkLabel23.Text = "Amount:"
        '
        'cmbEndItem
        '
        Me.cmbEndItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbEndItem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbEndItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbEndItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEndItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEndItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbEndItem.FormattingEnabled = True
        Me.cmbEndItem.Location = New System.Drawing.Point(67, 72)
        Me.cmbEndItem.Name = "cmbEndItem"
        Me.cmbEndItem.Size = New System.Drawing.Size(137, 21)
        Me.cmbEndItem.TabIndex = 5
        '
        'DarkLabel24
        '
        Me.DarkLabel24.AutoSize = True
        Me.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel24.Location = New System.Drawing.Point(6, 75)
        Me.DarkLabel24.Name = "DarkLabel24"
        Me.DarkLabel24.Size = New System.Drawing.Size(58, 13)
        Me.DarkLabel24.TabIndex = 4
        Me.DarkLabel24.Text = "Take Item:"
        '
        'nudGiveAmount
        '
        Me.nudGiveAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudGiveAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudGiveAmount.Location = New System.Drawing.Point(262, 29)
        Me.nudGiveAmount.Name = "nudGiveAmount"
        Me.nudGiveAmount.Size = New System.Drawing.Size(70, 20)
        Me.nudGiveAmount.TabIndex = 3
        '
        'DarkLabel22
        '
        Me.DarkLabel22.AutoSize = True
        Me.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel22.Location = New System.Drawing.Point(210, 31)
        Me.DarkLabel22.Name = "DarkLabel22"
        Me.DarkLabel22.Size = New System.Drawing.Size(46, 13)
        Me.DarkLabel22.TabIndex = 2
        Me.DarkLabel22.Text = "Amount:"
        '
        'cmbStartItem
        '
        Me.cmbStartItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbStartItem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbStartItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbStartItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStartItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStartItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbStartItem.FormattingEnabled = True
        Me.cmbStartItem.Location = New System.Drawing.Point(67, 28)
        Me.cmbStartItem.Name = "cmbStartItem"
        Me.cmbStartItem.Size = New System.Drawing.Size(137, 21)
        Me.cmbStartItem.TabIndex = 1
        '
        'DarkLabel21
        '
        Me.DarkLabel21.AutoSize = True
        Me.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel21.Location = New System.Drawing.Point(6, 31)
        Me.DarkLabel21.Name = "DarkLabel21"
        Me.DarkLabel21.Size = New System.Drawing.Size(55, 13)
        Me.DarkLabel21.TabIndex = 0
        Me.DarkLabel21.Text = "Give Item:"
        '
        'cmbClassReq
        '
        Me.cmbClassReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbClassReq.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbClassReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbClassReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbClassReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClassReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbClassReq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbClassReq.FormattingEnabled = True
        Me.cmbClassReq.Location = New System.Drawing.Point(185, 127)
        Me.cmbClassReq.Name = "cmbClassReq"
        Me.cmbClassReq.Size = New System.Drawing.Size(159, 21)
        Me.cmbClassReq.TabIndex = 9
        '
        'DarkLabel20
        '
        Me.DarkLabel20.AutoSize = True
        Me.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel20.Location = New System.Drawing.Point(80, 130)
        Me.DarkLabel20.Name = "DarkLabel20"
        Me.DarkLabel20.Size = New System.Drawing.Size(98, 13)
        Me.DarkLabel20.TabIndex = 8
        Me.DarkLabel20.Text = "Class Requirement:"
        '
        'rdbClassReq
        '
        Me.rdbClassReq.AutoSize = True
        Me.rdbClassReq.Location = New System.Drawing.Point(10, 128)
        Me.rdbClassReq.Name = "rdbClassReq"
        Me.rdbClassReq.Size = New System.Drawing.Size(50, 17)
        Me.rdbClassReq.TabIndex = 7
        Me.rdbClassReq.TabStop = True
        Me.rdbClassReq.Text = "Class"
        '
        'cmbQuestReq
        '
        Me.cmbQuestReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbQuestReq.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbQuestReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbQuestReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbQuestReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuestReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbQuestReq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbQuestReq.FormattingEnabled = True
        Me.cmbQuestReq.Location = New System.Drawing.Point(185, 91)
        Me.cmbQuestReq.Name = "cmbQuestReq"
        Me.cmbQuestReq.Size = New System.Drawing.Size(159, 21)
        Me.cmbQuestReq.TabIndex = 6
        '
        'DarkLabel19
        '
        Me.DarkLabel19.AutoSize = True
        Me.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel19.Location = New System.Drawing.Point(80, 94)
        Me.DarkLabel19.Name = "DarkLabel19"
        Me.DarkLabel19.Size = New System.Drawing.Size(101, 13)
        Me.DarkLabel19.TabIndex = 5
        Me.DarkLabel19.Text = "Quest Requirement:"
        '
        'rdbQuestReq
        '
        Me.rdbQuestReq.AutoSize = True
        Me.rdbQuestReq.Location = New System.Drawing.Point(10, 92)
        Me.rdbQuestReq.Name = "rdbQuestReq"
        Me.rdbQuestReq.Size = New System.Drawing.Size(53, 17)
        Me.rdbQuestReq.TabIndex = 4
        Me.rdbQuestReq.TabStop = True
        Me.rdbQuestReq.Text = "Quest"
        '
        'cmbItemReq
        '
        Me.cmbItemReq.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbItemReq.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbItemReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbItemReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbItemReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbItemReq.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbItemReq.FormattingEnabled = True
        Me.cmbItemReq.Location = New System.Drawing.Point(185, 55)
        Me.cmbItemReq.Name = "cmbItemReq"
        Me.cmbItemReq.Size = New System.Drawing.Size(159, 21)
        Me.cmbItemReq.TabIndex = 3
        '
        'DarkLabel18
        '
        Me.DarkLabel18.AutoSize = True
        Me.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel18.Location = New System.Drawing.Point(80, 58)
        Me.DarkLabel18.Name = "DarkLabel18"
        Me.DarkLabel18.Size = New System.Drawing.Size(93, 13)
        Me.DarkLabel18.TabIndex = 2
        Me.DarkLabel18.Text = "Item Requirement:"
        '
        'rdbItemReq
        '
        Me.rdbItemReq.AutoSize = True
        Me.rdbItemReq.Location = New System.Drawing.Point(10, 56)
        Me.rdbItemReq.Name = "rdbItemReq"
        Me.rdbItemReq.Size = New System.Drawing.Size(45, 17)
        Me.rdbItemReq.TabIndex = 1
        Me.rdbItemReq.TabStop = True
        Me.rdbItemReq.Text = "Item"
        '
        'rdbNoneReq
        '
        Me.rdbNoneReq.AutoSize = True
        Me.rdbNoneReq.Location = New System.Drawing.Point(10, 21)
        Me.rdbNoneReq.Name = "rdbNoneReq"
        Me.rdbNoneReq.Size = New System.Drawing.Size(51, 17)
        Me.rdbNoneReq.TabIndex = 0
        Me.rdbNoneReq.TabStop = True
        Me.rdbNoneReq.Text = "None"
        '
        'frmEditor_Quest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(724, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DarkLabel8)
        Me.Controls.Add(Me.DarkGroupBox2)
        Me.Controls.Add(Me.fraQuestList)
        Me.Controls.Add(Me.fraRequirements)
        Me.Controls.Add(Me.fraTasks)
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Quest"
        Me.Text = "Quest Editor"
        Me.fraQuestList.ResumeLayout(False)
        Me.DarkGroupBox2.ResumeLayout(False)
        Me.DarkGroupBox2.PerformLayout()
        Me.DarkGroupBox5.ResumeLayout(False)
        Me.DarkGroupBox4.ResumeLayout(False)
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        CType(Me.nudItemRewValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExpReward, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraTasks.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraRequirements.ResumeLayout(False)
        Me.fraRequirements.PerformLayout()
        Me.DarkGroupBox6.ResumeLayout(False)
        Me.DarkGroupBox6.PerformLayout()
        CType(Me.nudTakeAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGiveAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fraQuestList As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As ListBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents chkRepeat As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkQuestCancel As DarkUI.Controls.DarkCheckBox
    Friend WithEvents txtStartText As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtEndText As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtProgressText As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstRewards As ListBox
    Friend WithEvents btnAddReward As DarkUI.Controls.DarkButton
    Friend WithEvents btnRemoveReward As DarkUI.Controls.DarkButton
    Friend WithEvents nudExpReward As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudItemRewValue As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbItemReward As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnAddRequirement As DarkUI.Controls.DarkButton
    Friend WithEvents btnRemoveRequirement As DarkUI.Controls.DarkButton
    Friend WithEvents lstRequirements As ListBox
    Friend WithEvents lstTasks As ListBox
    Friend WithEvents btnRemoveTask As DarkUI.Controls.DarkButton
    Friend WithEvents btnAddTask As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraTasks As DarkUI.Controls.DarkGroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtTaskLog As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtTaskSpeech As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
    Friend WithEvents chkEnd As DarkUI.Controls.DarkCheckBox
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblTaskNum As DarkUI.Controls.DarkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents optTask0 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
    Friend WithEvents optTask1 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTask2 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTask3 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTask4 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTask5 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTask6 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optTask7 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents DarkLabel17 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraRequirements As DarkUI.Controls.DarkGroupBox
    Friend WithEvents rdbNoneReq As DarkUI.Controls.DarkRadioButton
    Friend WithEvents rdbItemReq As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbItemReq As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel18 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbQuestReq As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel19 As DarkUI.Controls.DarkLabel
    Friend WithEvents rdbQuestReq As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbClassReq As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel20 As DarkUI.Controls.DarkLabel
    Friend WithEvents rdbClassReq As DarkUI.Controls.DarkRadioButton
    Friend WithEvents DarkGroupBox6 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbStartItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel21 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudGiveAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel22 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudTakeAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel23 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbEndItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel24 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnRequirementSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnRequirementCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancelTask As DarkUI.Controls.DarkButton
    Friend WithEvents btnSaveTask As DarkUI.Controls.DarkButton
    Friend WithEvents cmbResource As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbMap As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbNpc As DarkUI.Controls.DarkComboBox
End Class
