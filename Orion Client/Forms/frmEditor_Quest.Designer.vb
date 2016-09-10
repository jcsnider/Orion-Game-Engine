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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optTasks = New System.Windows.Forms.RadioButton()
        Me.optRewards = New System.Windows.Forms.RadioButton()
        Me.optRequirements = New System.Windows.Forms.RadioButton()
        Me.optSpeech = New System.Windows.Forms.RadioButton()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.fraText = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEndText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProgressText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStartText = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.fraRequirements = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkRepeat = New System.Windows.Forms.CheckBox()
        Me.scrlEndItemAmount = New System.Windows.Forms.HScrollBar()
        Me.scrlEndItemName = New System.Windows.Forms.HScrollBar()
        Me.lblEnditem = New System.Windows.Forms.Label()
        Me.scrlStartItemAmount = New System.Windows.Forms.HScrollBar()
        Me.scrlStartItemName = New System.Windows.Forms.HScrollBar()
        Me.lblStartItem = New System.Windows.Forms.Label()
        Me.scrlQuestRec = New System.Windows.Forms.HScrollBar()
        Me.lblQuestRec = New System.Windows.Forms.Label()
        Me.scrlItemRec = New System.Windows.Forms.HScrollBar()
        Me.lblItemReq = New System.Windows.Forms.Label()
        Me.fraRewards = New System.Windows.Forms.GroupBox()
        Me.scrlExpReward = New System.Windows.Forms.HScrollBar()
        Me.lblExpReward = New System.Windows.Forms.Label()
        Me.HScrollBar7 = New System.Windows.Forms.HScrollBar()
        Me.HScrollBar8 = New System.Windows.Forms.HScrollBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.HScrollBar5 = New System.Windows.Forms.HScrollBar()
        Me.HScrollBar6 = New System.Windows.Forms.HScrollBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HScrollBar3 = New System.Windows.Forms.HScrollBar()
        Me.HScrollBar4 = New System.Windows.Forms.HScrollBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.scrlItemRewValue1 = New System.Windows.Forms.HScrollBar()
        Me.scrlItemRew1 = New System.Windows.Forms.HScrollBar()
        Me.lblItemReward1 = New System.Windows.Forms.Label()
        Me.fraTasks = New System.Windows.Forms.GroupBox()
        Me.scrlTotalTasks = New System.Windows.Forms.HScrollBar()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.optTask7 = New System.Windows.Forms.RadioButton()
        Me.optTask6 = New System.Windows.Forms.RadioButton()
        Me.optTask5 = New System.Windows.Forms.RadioButton()
        Me.optTask4 = New System.Windows.Forms.RadioButton()
        Me.optTask3 = New System.Windows.Forms.RadioButton()
        Me.optTask2 = New System.Windows.Forms.RadioButton()
        Me.optTask1 = New System.Windows.Forms.RadioButton()
        Me.optTask0 = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkEnd = New System.Windows.Forms.CheckBox()
        Me.scrlAmount = New System.Windows.Forms.HScrollBar()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.scrlResource = New System.Windows.Forms.HScrollBar()
        Me.lblResource = New System.Windows.Forms.Label()
        Me.scrlMap = New System.Windows.Forms.HScrollBar()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.scrlItem = New System.Windows.Forms.HScrollBar()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.scrlNPC = New System.Windows.Forms.HScrollBar()
        Me.lblNpc = New System.Windows.Forms.Label()
        Me.txtTaskLog = New System.Windows.Forms.TextBox()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.txtSpeech = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtQuestLog = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.fraText.SuspendLayout()
        Me.fraRequirements.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraRewards.SuspendLayout()
        Me.fraTasks.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 499)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Quest List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(7, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(262, 472)
        Me.lstIndex.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox2.Controls.Add(Me.optTasks)
        Me.GroupBox2.Controls.Add(Me.optRewards)
        Me.GroupBox2.Controls.Add(Me.optRequirements)
        Me.GroupBox2.Controls.Add(Me.optSpeech)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Location = New System.Drawing.Point(288, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 74)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quest Title"
        '
        'optTasks
        '
        Me.optTasks.AutoSize = True
        Me.optTasks.Location = New System.Drawing.Point(295, 45)
        Me.optTasks.Name = "optTasks"
        Me.optTasks.Size = New System.Drawing.Size(59, 17)
        Me.optTasks.TabIndex = 4
        Me.optTasks.TabStop = True
        Me.optTasks.Text = "Tasks"
        Me.optTasks.UseVisualStyleBackColor = True
        '
        'optRewards
        '
        Me.optRewards.AutoSize = True
        Me.optRewards.Location = New System.Drawing.Point(210, 45)
        Me.optRewards.Name = "optRewards"
        Me.optRewards.Size = New System.Drawing.Size(74, 17)
        Me.optRewards.TabIndex = 3
        Me.optRewards.TabStop = True
        Me.optRewards.Text = "Rewards"
        Me.optRewards.UseVisualStyleBackColor = True
        '
        'optRequirements
        '
        Me.optRequirements.AutoSize = True
        Me.optRequirements.Location = New System.Drawing.Point(98, 45)
        Me.optRequirements.Name = "optRequirements"
        Me.optRequirements.Size = New System.Drawing.Size(102, 17)
        Me.optRequirements.TabIndex = 2
        Me.optRequirements.TabStop = True
        Me.optRequirements.Text = "Requirements"
        Me.optRequirements.UseVisualStyleBackColor = True
        '
        'optSpeech
        '
        Me.optSpeech.AutoSize = True
        Me.optSpeech.Location = New System.Drawing.Point(37, 45)
        Me.optSpeech.Name = "optSpeech"
        Me.optSpeech.Size = New System.Drawing.Size(50, 17)
        Me.optSpeech.TabIndex = 1
        Me.optSpeech.TabStop = True
        Me.optSpeech.Text = "Text"
        Me.optSpeech.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(7, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(390, 20)
        Me.txtName.TabIndex = 0
        '
        'fraText
        '
        Me.fraText.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.fraText.Controls.Add(Me.Label11)
        Me.fraText.Controls.Add(Me.txtEndText)
        Me.fraText.Controls.Add(Me.Label3)
        Me.fraText.Controls.Add(Me.txtProgressText)
        Me.fraText.Controls.Add(Me.Label2)
        Me.fraText.Controls.Add(Me.Label1)
        Me.fraText.Controls.Add(Me.txtStartText)
        Me.fraText.Location = New System.Drawing.Point(288, 82)
        Me.fraText.Name = "fraText"
        Me.fraText.Size = New System.Drawing.Size(405, 390)
        Me.fraText.TabIndex = 2
        Me.fraText.TabStop = False
        Me.fraText.Text = "Quest Text"
        Me.fraText.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(17, 362)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(264, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Use /questreset # to reset a quest for testing"
        '
        'txtEndText
        '
        Me.txtEndText.Location = New System.Drawing.Point(7, 221)
        Me.txtEndText.Multiline = True
        Me.txtEndText.Name = "txtEndText"
        Me.txtEndText.Size = New System.Drawing.Size(390, 65)
        Me.txtEndText.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "End Text:"
        '
        'txtProgressText
        '
        Me.txtProgressText.Location = New System.Drawing.Point(7, 127)
        Me.txtProgressText.Multiline = True
        Me.txtProgressText.Name = "txtProgressText"
        Me.txtProgressText.Size = New System.Drawing.Size(390, 65)
        Me.txtProgressText.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "In Progress Text:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start Text:"
        '
        'txtStartText
        '
        Me.txtStartText.Location = New System.Drawing.Point(7, 32)
        Me.txtStartText.Multiline = True
        Me.txtStartText.Name = "txtStartText"
        Me.txtStartText.Size = New System.Drawing.Size(390, 65)
        Me.txtStartText.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(320, 478)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(444, 478)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(570, 478)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'fraRequirements
        '
        Me.fraRequirements.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.fraRequirements.Controls.Add(Me.GroupBox3)
        Me.fraRequirements.Controls.Add(Me.scrlQuestRec)
        Me.fraRequirements.Controls.Add(Me.lblQuestRec)
        Me.fraRequirements.Controls.Add(Me.scrlItemRec)
        Me.fraRequirements.Controls.Add(Me.lblItemReq)
        Me.fraRequirements.Location = New System.Drawing.Point(703, 82)
        Me.fraRequirements.Name = "fraRequirements"
        Me.fraRequirements.Size = New System.Drawing.Size(426, 390)
        Me.fraRequirements.TabIndex = 6
        Me.fraRequirements.TabStop = False
        Me.fraRequirements.Text = "Requirements"
        Me.fraRequirements.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox3.Controls.Add(Me.chkRepeat)
        Me.GroupBox3.Controls.Add(Me.scrlEndItemAmount)
        Me.GroupBox3.Controls.Add(Me.scrlEndItemName)
        Me.GroupBox3.Controls.Add(Me.lblEnditem)
        Me.GroupBox3.Controls.Add(Me.scrlStartItemAmount)
        Me.GroupBox3.Controls.Add(Me.scrlStartItemName)
        Me.GroupBox3.Controls.Add(Me.lblStartItem)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 102)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(387, 282)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'chkRepeat
        '
        Me.chkRepeat.AutoSize = True
        Me.chkRepeat.Location = New System.Drawing.Point(7, 119)
        Me.chkRepeat.Name = "chkRepeat"
        Me.chkRepeat.Size = New System.Drawing.Size(98, 17)
        Me.chkRepeat.TabIndex = 7
        Me.chkRepeat.Text = "Repeatable?"
        Me.chkRepeat.UseVisualStyleBackColor = True
        '
        'scrlEndItemAmount
        '
        Me.scrlEndItemAmount.Location = New System.Drawing.Point(197, 87)
        Me.scrlEndItemAmount.Name = "scrlEndItemAmount"
        Me.scrlEndItemAmount.Size = New System.Drawing.Size(187, 17)
        Me.scrlEndItemAmount.TabIndex = 6
        '
        'scrlEndItemName
        '
        Me.scrlEndItemName.Location = New System.Drawing.Point(3, 87)
        Me.scrlEndItemName.Name = "scrlEndItemName"
        Me.scrlEndItemName.Size = New System.Drawing.Size(187, 17)
        Me.scrlEndItemName.TabIndex = 5
        '
        'lblEnditem
        '
        Me.lblEnditem.AutoSize = True
        Me.lblEnditem.Location = New System.Drawing.Point(7, 74)
        Me.lblEnditem.Name = "lblEnditem"
        Me.lblEnditem.Size = New System.Drawing.Size(163, 13)
        Me.lblEnditem.TabIndex = 4
        Me.lblEnditem.Text = "Take item on end: None (1)"
        '
        'scrlStartItemAmount
        '
        Me.scrlStartItemAmount.Location = New System.Drawing.Point(197, 38)
        Me.scrlStartItemAmount.Name = "scrlStartItemAmount"
        Me.scrlStartItemAmount.Size = New System.Drawing.Size(187, 17)
        Me.scrlStartItemAmount.TabIndex = 3
        '
        'scrlStartItemName
        '
        Me.scrlStartItemName.Location = New System.Drawing.Point(3, 38)
        Me.scrlStartItemName.Name = "scrlStartItemName"
        Me.scrlStartItemName.Size = New System.Drawing.Size(187, 17)
        Me.scrlStartItemName.TabIndex = 2
        '
        'lblStartItem
        '
        Me.lblStartItem.AutoSize = True
        Me.lblStartItem.Location = New System.Drawing.Point(7, 25)
        Me.lblStartItem.Name = "lblStartItem"
        Me.lblStartItem.Size = New System.Drawing.Size(164, 13)
        Me.lblStartItem.TabIndex = 0
        Me.lblStartItem.Text = "Give item on start: None (1)"
        '
        'scrlQuestRec
        '
        Me.scrlQuestRec.Location = New System.Drawing.Point(9, 80)
        Me.scrlQuestRec.Name = "scrlQuestRec"
        Me.scrlQuestRec.Size = New System.Drawing.Size(377, 17)
        Me.scrlQuestRec.TabIndex = 3
        '
        'lblQuestRec
        '
        Me.lblQuestRec.AutoSize = True
        Me.lblQuestRec.Location = New System.Drawing.Point(7, 62)
        Me.lblQuestRec.Name = "lblQuestRec"
        Me.lblQuestRec.Size = New System.Drawing.Size(153, 13)
        Me.lblQuestRec.TabIndex = 2
        Me.lblQuestRec.Text = "Quest Requirement: None"
        '
        'scrlItemRec
        '
        Me.scrlItemRec.Location = New System.Drawing.Point(9, 38)
        Me.scrlItemRec.Name = "scrlItemRec"
        Me.scrlItemRec.Size = New System.Drawing.Size(377, 17)
        Me.scrlItemRec.TabIndex = 1
        '
        'lblItemReq
        '
        Me.lblItemReq.AutoSize = True
        Me.lblItemReq.Location = New System.Drawing.Point(6, 16)
        Me.lblItemReq.Name = "lblItemReq"
        Me.lblItemReq.Size = New System.Drawing.Size(144, 13)
        Me.lblItemReq.TabIndex = 0
        Me.lblItemReq.Text = "Item Requirement: None"
        '
        'fraRewards
        '
        Me.fraRewards.Controls.Add(Me.scrlExpReward)
        Me.fraRewards.Controls.Add(Me.lblExpReward)
        Me.fraRewards.Controls.Add(Me.HScrollBar7)
        Me.fraRewards.Controls.Add(Me.HScrollBar8)
        Me.fraRewards.Controls.Add(Me.Label7)
        Me.fraRewards.Controls.Add(Me.HScrollBar5)
        Me.fraRewards.Controls.Add(Me.HScrollBar6)
        Me.fraRewards.Controls.Add(Me.Label6)
        Me.fraRewards.Controls.Add(Me.HScrollBar3)
        Me.fraRewards.Controls.Add(Me.HScrollBar4)
        Me.fraRewards.Controls.Add(Me.Label5)
        Me.fraRewards.Controls.Add(Me.scrlItemRewValue1)
        Me.fraRewards.Controls.Add(Me.scrlItemRew1)
        Me.fraRewards.Controls.Add(Me.lblItemReward1)
        Me.fraRewards.Location = New System.Drawing.Point(699, 12)
        Me.fraRewards.Name = "fraRewards"
        Me.fraRewards.Size = New System.Drawing.Size(405, 390)
        Me.fraRewards.TabIndex = 7
        Me.fraRewards.TabStop = False
        Me.fraRewards.Text = "Rewards"
        Me.fraRewards.Visible = False
        '
        'scrlExpReward
        '
        Me.scrlExpReward.Location = New System.Drawing.Point(201, 63)
        Me.scrlExpReward.Maximum = 10000000
        Me.scrlExpReward.Name = "scrlExpReward"
        Me.scrlExpReward.Size = New System.Drawing.Size(187, 17)
        Me.scrlExpReward.TabIndex = 17
        '
        'lblExpReward
        '
        Me.lblExpReward.AutoSize = True
        Me.lblExpReward.Location = New System.Drawing.Point(6, 67)
        Me.lblExpReward.Name = "lblExpReward"
        Me.lblExpReward.Size = New System.Drawing.Size(129, 13)
        Me.lblExpReward.TabIndex = 16
        Me.lblExpReward.Text = "Experience Gained: 0"
        '
        'HScrollBar7
        '
        Me.HScrollBar7.Location = New System.Drawing.Point(201, 367)
        Me.HScrollBar7.Name = "HScrollBar7"
        Me.HScrollBar7.Size = New System.Drawing.Size(187, 17)
        Me.HScrollBar7.TabIndex = 15
        Me.HScrollBar7.Visible = False
        '
        'HScrollBar8
        '
        Me.HScrollBar8.Location = New System.Drawing.Point(3, 367)
        Me.HScrollBar8.Name = "HScrollBar8"
        Me.HScrollBar8.Size = New System.Drawing.Size(187, 17)
        Me.HScrollBar8.TabIndex = 14
        Me.HScrollBar8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 354)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Give item on start: None (1)"
        Me.Label7.Visible = False
        '
        'HScrollBar5
        '
        Me.HScrollBar5.Location = New System.Drawing.Point(201, 322)
        Me.HScrollBar5.Name = "HScrollBar5"
        Me.HScrollBar5.Size = New System.Drawing.Size(187, 17)
        Me.HScrollBar5.TabIndex = 12
        Me.HScrollBar5.Visible = False
        '
        'HScrollBar6
        '
        Me.HScrollBar6.Location = New System.Drawing.Point(3, 322)
        Me.HScrollBar6.Name = "HScrollBar6"
        Me.HScrollBar6.Size = New System.Drawing.Size(187, 17)
        Me.HScrollBar6.TabIndex = 11
        Me.HScrollBar6.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 309)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Give item on start: None (1)"
        Me.Label6.Visible = False
        '
        'HScrollBar3
        '
        Me.HScrollBar3.Location = New System.Drawing.Point(201, 275)
        Me.HScrollBar3.Name = "HScrollBar3"
        Me.HScrollBar3.Size = New System.Drawing.Size(187, 17)
        Me.HScrollBar3.TabIndex = 9
        Me.HScrollBar3.Visible = False
        '
        'HScrollBar4
        '
        Me.HScrollBar4.Location = New System.Drawing.Point(3, 275)
        Me.HScrollBar4.Name = "HScrollBar4"
        Me.HScrollBar4.Size = New System.Drawing.Size(187, 17)
        Me.HScrollBar4.TabIndex = 8
        Me.HScrollBar4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(164, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Give item on start: None (1)"
        Me.Label5.Visible = False
        '
        'scrlItemRewValue1
        '
        Me.scrlItemRewValue1.Location = New System.Drawing.Point(201, 32)
        Me.scrlItemRewValue1.Maximum = 100000
        Me.scrlItemRewValue1.Name = "scrlItemRewValue1"
        Me.scrlItemRewValue1.Size = New System.Drawing.Size(187, 17)
        Me.scrlItemRewValue1.TabIndex = 6
        '
        'scrlItemRew1
        '
        Me.scrlItemRew1.Location = New System.Drawing.Point(3, 32)
        Me.scrlItemRew1.Name = "scrlItemRew1"
        Me.scrlItemRew1.Size = New System.Drawing.Size(187, 17)
        Me.scrlItemRew1.TabIndex = 5
        '
        'lblItemReward1
        '
        Me.lblItemReward1.AutoSize = True
        Me.lblItemReward1.Location = New System.Drawing.Point(10, 19)
        Me.lblItemReward1.Name = "lblItemReward1"
        Me.lblItemReward1.Size = New System.Drawing.Size(135, 13)
        Me.lblItemReward1.TabIndex = 4
        Me.lblItemReward1.Text = "Item Reward: None (1)"
        '
        'fraTasks
        '
        Me.fraTasks.Controls.Add(Me.scrlTotalTasks)
        Me.fraTasks.Controls.Add(Me.lblSelected)
        Me.fraTasks.Controls.Add(Me.GroupBox5)
        Me.fraTasks.Controls.Add(Me.GroupBox4)
        Me.fraTasks.Controls.Add(Me.txtQuestLog)
        Me.fraTasks.Controls.Add(Me.Label4)
        Me.fraTasks.Location = New System.Drawing.Point(1135, 12)
        Me.fraTasks.Name = "fraTasks"
        Me.fraTasks.Size = New System.Drawing.Size(405, 390)
        Me.fraTasks.TabIndex = 8
        Me.fraTasks.TabStop = False
        Me.fraTasks.Text = "Tasks"
        Me.fraTasks.Visible = False
        '
        'scrlTotalTasks
        '
        Me.scrlTotalTasks.LargeChange = 1
        Me.scrlTotalTasks.Location = New System.Drawing.Point(128, 45)
        Me.scrlTotalTasks.Maximum = 10
        Me.scrlTotalTasks.Minimum = 1
        Me.scrlTotalTasks.Name = "scrlTotalTasks"
        Me.scrlTotalTasks.Size = New System.Drawing.Size(269, 17)
        Me.scrlTotalTasks.TabIndex = 7
        Me.scrlTotalTasks.Value = 1
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelected.ForeColor = System.Drawing.Color.Firebrick
        Me.lblSelected.Location = New System.Drawing.Point(7, 47)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(104, 13)
        Me.lblSelected.TabIndex = 4
        Me.lblSelected.Text = "Selected Task: 1"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.optTask7)
        Me.GroupBox5.Controls.Add(Me.optTask6)
        Me.GroupBox5.Controls.Add(Me.optTask5)
        Me.GroupBox5.Controls.Add(Me.optTask4)
        Me.GroupBox5.Controls.Add(Me.optTask3)
        Me.GroupBox5.Controls.Add(Me.optTask2)
        Me.GroupBox5.Controls.Add(Me.optTask1)
        Me.GroupBox5.Controls.Add(Me.optTask0)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Location = New System.Drawing.Point(244, 67)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(155, 317)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'optTask7
        '
        Me.optTask7.AutoSize = True
        Me.optTask7.Location = New System.Drawing.Point(6, 199)
        Me.optTask7.Name = "optTask7"
        Me.optTask7.Size = New System.Drawing.Size(128, 17)
        Me.optTask7.TabIndex = 31
        Me.optTask7.TabStop = True
        Me.optTask7.Text = "Get Item from Npc"
        Me.optTask7.UseVisualStyleBackColor = True
        '
        'optTask6
        '
        Me.optTask6.AutoSize = True
        Me.optTask6.Location = New System.Drawing.Point(6, 176)
        Me.optTask6.Name = "optTask6"
        Me.optTask6.Size = New System.Drawing.Size(127, 17)
        Me.optTask6.TabIndex = 30
        Me.optTask6.TabStop = True
        Me.optTask6.Text = "Gather Resources"
        Me.optTask6.UseVisualStyleBackColor = True
        '
        'optTask5
        '
        Me.optTask5.AutoSize = True
        Me.optTask5.Location = New System.Drawing.Point(6, 153)
        Me.optTask5.Name = "optTask5"
        Me.optTask5.Size = New System.Drawing.Size(121, 17)
        Me.optTask5.TabIndex = 29
        Me.optTask5.TabStop = True
        Me.optTask5.Text = "Give Item to Npc"
        Me.optTask5.UseVisualStyleBackColor = True
        '
        'optTask4
        '
        Me.optTask4.AutoSize = True
        Me.optTask4.Location = New System.Drawing.Point(6, 130)
        Me.optTask4.Name = "optTask4"
        Me.optTask4.Size = New System.Drawing.Size(90, 17)
        Me.optTask4.TabIndex = 28
        Me.optTask4.TabStop = True
        Me.optTask4.Text = "Reach Map"
        Me.optTask4.UseVisualStyleBackColor = True
        '
        'optTask3
        '
        Me.optTask3.AutoSize = True
        Me.optTask3.Location = New System.Drawing.Point(6, 107)
        Me.optTask3.Name = "optTask3"
        Me.optTask3.Size = New System.Drawing.Size(92, 17)
        Me.optTask3.TabIndex = 27
        Me.optTask3.TabStop = True
        Me.optTask3.Text = "Talk to Npc"
        Me.optTask3.UseVisualStyleBackColor = True
        '
        'optTask2
        '
        Me.optTask2.AutoSize = True
        Me.optTask2.Location = New System.Drawing.Point(6, 84)
        Me.optTask2.Name = "optTask2"
        Me.optTask2.Size = New System.Drawing.Size(97, 17)
        Me.optTask2.TabIndex = 26
        Me.optTask2.TabStop = True
        Me.optTask2.Text = "Gather Items"
        Me.optTask2.UseVisualStyleBackColor = True
        '
        'optTask1
        '
        Me.optTask1.AutoSize = True
        Me.optTask1.Location = New System.Drawing.Point(6, 61)
        Me.optTask1.Name = "optTask1"
        Me.optTask1.Size = New System.Drawing.Size(90, 17)
        Me.optTask1.TabIndex = 25
        Me.optTask1.TabStop = True
        Me.optTask1.Text = "Defeat Npc"
        Me.optTask1.UseVisualStyleBackColor = True
        '
        'optTask0
        '
        Me.optTask0.AutoSize = True
        Me.optTask0.Location = New System.Drawing.Point(6, 19)
        Me.optTask0.Name = "optTask0"
        Me.optTask0.Size = New System.Drawing.Size(69, 17)
        Me.optTask0.TabIndex = 24
        Me.optTask0.TabStop = True
        Me.optTask0.Text = "Nothing"
        Me.optTask0.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "-------------------------------------------"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkEnd)
        Me.GroupBox4.Controls.Add(Me.scrlAmount)
        Me.GroupBox4.Controls.Add(Me.lblAmount)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.scrlResource)
        Me.GroupBox4.Controls.Add(Me.lblResource)
        Me.GroupBox4.Controls.Add(Me.scrlMap)
        Me.GroupBox4.Controls.Add(Me.lblMap)
        Me.GroupBox4.Controls.Add(Me.scrlItem)
        Me.GroupBox4.Controls.Add(Me.lblItem)
        Me.GroupBox4.Controls.Add(Me.scrlNPC)
        Me.GroupBox4.Controls.Add(Me.lblNpc)
        Me.GroupBox4.Controls.Add(Me.txtTaskLog)
        Me.GroupBox4.Controls.Add(Me.lblLog)
        Me.GroupBox4.Controls.Add(Me.txtSpeech)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 67)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(225, 317)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'chkEnd
        '
        Me.chkEnd.AutoSize = True
        Me.chkEnd.ForeColor = System.Drawing.Color.Green
        Me.chkEnd.Location = New System.Drawing.Point(6, 294)
        Me.chkEnd.Name = "chkEnd"
        Me.chkEnd.Size = New System.Drawing.Size(121, 17)
        Me.chkEnd.TabIndex = 25
        Me.chkEnd.Text = "End Quest Now?"
        Me.chkEnd.UseVisualStyleBackColor = True
        '
        'scrlAmount
        '
        Me.scrlAmount.LargeChange = 1
        Me.scrlAmount.Location = New System.Drawing.Point(6, 274)
        Me.scrlAmount.Maximum = 255
        Me.scrlAmount.Name = "scrlAmount"
        Me.scrlAmount.Size = New System.Drawing.Size(213, 17)
        Me.scrlAmount.TabIndex = 24
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(3, 261)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(64, 13)
        Me.lblAmount.TabIndex = 23
        Me.lblAmount.Text = "Amount: 0"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(22, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(182, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "-------------------------------------------"
        '
        'scrlResource
        '
        Me.scrlResource.LargeChange = 1
        Me.scrlResource.Location = New System.Drawing.Point(6, 201)
        Me.scrlResource.Maximum = 255
        Me.scrlResource.Name = "scrlResource"
        Me.scrlResource.Size = New System.Drawing.Size(213, 17)
        Me.scrlResource.TabIndex = 19
        '
        'lblResource
        '
        Me.lblResource.AutoSize = True
        Me.lblResource.Location = New System.Drawing.Point(3, 188)
        Me.lblResource.Name = "lblResource"
        Me.lblResource.Size = New System.Drawing.Size(76, 13)
        Me.lblResource.TabIndex = 18
        Me.lblResource.Text = "Resource: 0"
        '
        'scrlMap
        '
        Me.scrlMap.LargeChange = 1
        Me.scrlMap.Location = New System.Drawing.Point(6, 171)
        Me.scrlMap.Maximum = 255
        Me.scrlMap.Name = "scrlMap"
        Me.scrlMap.Size = New System.Drawing.Size(213, 17)
        Me.scrlMap.TabIndex = 17
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(3, 158)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(46, 13)
        Me.lblMap.TabIndex = 16
        Me.lblMap.Text = "Map: 0"
        '
        'scrlItem
        '
        Me.scrlItem.LargeChange = 1
        Me.scrlItem.Location = New System.Drawing.Point(6, 141)
        Me.scrlItem.Maximum = 255
        Me.scrlItem.Name = "scrlItem"
        Me.scrlItem.Size = New System.Drawing.Size(213, 17)
        Me.scrlItem.TabIndex = 15
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Location = New System.Drawing.Point(3, 128)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(46, 13)
        Me.lblItem.TabIndex = 14
        Me.lblItem.Text = "Item: 0"
        '
        'scrlNPC
        '
        Me.scrlNPC.LargeChange = 1
        Me.scrlNPC.Location = New System.Drawing.Point(6, 111)
        Me.scrlNPC.Maximum = 255
        Me.scrlNPC.Name = "scrlNPC"
        Me.scrlNPC.Size = New System.Drawing.Size(213, 17)
        Me.scrlNPC.TabIndex = 13
        '
        'lblNpc
        '
        Me.lblNpc.AutoSize = True
        Me.lblNpc.Location = New System.Drawing.Point(3, 98)
        Me.lblNpc.Name = "lblNpc"
        Me.lblNpc.Size = New System.Drawing.Size(45, 13)
        Me.lblNpc.TabIndex = 4
        Me.lblNpc.Text = "Npc: 0"
        '
        'txtTaskLog
        '
        Me.txtTaskLog.Location = New System.Drawing.Point(6, 75)
        Me.txtTaskLog.Name = "txtTaskLog"
        Me.txtTaskLog.Size = New System.Drawing.Size(213, 20)
        Me.txtTaskLog.TabIndex = 3
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(6, 59)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(64, 13)
        Me.lblLog.TabIndex = 2
        Me.lblLog.Text = "Task Log:"
        '
        'txtSpeech
        '
        Me.txtSpeech.Location = New System.Drawing.Point(6, 32)
        Me.txtSpeech.Name = "txtSpeech"
        Me.txtSpeech.Size = New System.Drawing.Size(213, 20)
        Me.txtSpeech.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Task Text:"
        '
        'txtQuestLog
        '
        Me.txtQuestLog.Location = New System.Drawing.Point(128, 13)
        Me.txtQuestLog.Name = "txtQuestLog"
        Me.txtQuestLog.Size = New System.Drawing.Size(269, 20)
        Me.txtQuestLog.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Starting Quest Log:"
        '
        'frmEditor_Quest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(1543, 507)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraRewards)
        Me.Controls.Add(Me.fraText)
        Me.Controls.Add(Me.fraTasks)
        Me.Controls.Add(Me.fraRequirements)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Quest"
        Me.Text = "Quest Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.fraText.ResumeLayout(False)
        Me.fraText.PerformLayout()
        Me.fraRequirements.ResumeLayout(False)
        Me.fraRequirements.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.fraRewards.ResumeLayout(False)
        Me.fraRewards.PerformLayout()
        Me.fraTasks.ResumeLayout(False)
        Me.fraTasks.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lstIndex As Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents optTasks As Windows.Forms.RadioButton
    Friend WithEvents optRewards As Windows.Forms.RadioButton
    Friend WithEvents optRequirements As Windows.Forms.RadioButton
    Friend WithEvents optSpeech As Windows.Forms.RadioButton
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents fraText As Windows.Forms.GroupBox
    Friend WithEvents txtEndText As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtProgressText As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtStartText As Windows.Forms.TextBox
    Friend WithEvents btnSave As Windows.Forms.Button
    Friend WithEvents btnDelete As Windows.Forms.Button
    Friend WithEvents btnCancel As Windows.Forms.Button
    Friend WithEvents fraRequirements As Windows.Forms.GroupBox
    Friend WithEvents scrlItemRec As Windows.Forms.HScrollBar
    Friend WithEvents lblItemReq As Windows.Forms.Label
    Friend WithEvents scrlQuestRec As Windows.Forms.HScrollBar
    Friend WithEvents lblQuestRec As Windows.Forms.Label
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents scrlStartItemAmount As Windows.Forms.HScrollBar
    Friend WithEvents scrlStartItemName As Windows.Forms.HScrollBar
    Friend WithEvents lblStartItem As Windows.Forms.Label
    Friend WithEvents scrlEndItemAmount As Windows.Forms.HScrollBar
    Friend WithEvents scrlEndItemName As Windows.Forms.HScrollBar
    Friend WithEvents lblEnditem As Windows.Forms.Label
    Friend WithEvents chkRepeat As Windows.Forms.CheckBox
    Friend WithEvents fraRewards As Windows.Forms.GroupBox
    Friend WithEvents HScrollBar7 As Windows.Forms.HScrollBar
    Friend WithEvents HScrollBar8 As Windows.Forms.HScrollBar
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents HScrollBar5 As Windows.Forms.HScrollBar
    Friend WithEvents HScrollBar6 As Windows.Forms.HScrollBar
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents HScrollBar3 As Windows.Forms.HScrollBar
    Friend WithEvents HScrollBar4 As Windows.Forms.HScrollBar
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents scrlItemRewValue1 As Windows.Forms.HScrollBar
    Friend WithEvents scrlItemRew1 As Windows.Forms.HScrollBar
    Friend WithEvents lblItemReward1 As Windows.Forms.Label
    Friend WithEvents fraTasks As Windows.Forms.GroupBox
    Friend WithEvents scrlTotalTasks As Windows.Forms.HScrollBar
    Friend WithEvents lblSelected As Windows.Forms.Label
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents scrlItem As Windows.Forms.HScrollBar
    Friend WithEvents lblItem As Windows.Forms.Label
    Friend WithEvents scrlNPC As Windows.Forms.HScrollBar
    Friend WithEvents lblNpc As Windows.Forms.Label
    Friend WithEvents txtTaskLog As Windows.Forms.TextBox
    Friend WithEvents lblLog As Windows.Forms.Label
    Friend WithEvents txtSpeech As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txtQuestLog As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents scrlResource As Windows.Forms.HScrollBar
    Friend WithEvents lblResource As Windows.Forms.Label
    Friend WithEvents scrlMap As Windows.Forms.HScrollBar
    Friend WithEvents lblMap As Windows.Forms.Label
    Friend WithEvents chkEnd As Windows.Forms.CheckBox
    Friend WithEvents scrlAmount As Windows.Forms.HScrollBar
    Friend WithEvents lblAmount As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents optTask7 As Windows.Forms.RadioButton
    Friend WithEvents optTask6 As Windows.Forms.RadioButton
    Friend WithEvents optTask5 As Windows.Forms.RadioButton
    Friend WithEvents optTask4 As Windows.Forms.RadioButton
    Friend WithEvents optTask3 As Windows.Forms.RadioButton
    Friend WithEvents optTask2 As Windows.Forms.RadioButton
    Friend WithEvents optTask1 As Windows.Forms.RadioButton
    Friend WithEvents optTask0 As Windows.Forms.RadioButton
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents scrlExpReward As Windows.Forms.HScrollBar
    Friend WithEvents lblExpReward As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
End Class
