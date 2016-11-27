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
        Me.fraRewards = New System.Windows.Forms.GroupBox()
        Me.btnRemoveReward = New System.Windows.Forms.Button()
        Me.btnAddReward = New System.Windows.Forms.Button()
        Me.lstRewards = New System.Windows.Forms.ListBox()
        Me.scrlExpReward = New System.Windows.Forms.HScrollBar()
        Me.lblExpReward = New System.Windows.Forms.Label()
        Me.scrlItemRewValue = New System.Windows.Forms.HScrollBar()
        Me.scrlItemReward = New System.Windows.Forms.HScrollBar()
        Me.lblItemReward = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEndText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProgressText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStartText = New System.Windows.Forms.TextBox()
        Me.fraTasks = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.txtTaskSpeech = New System.Windows.Forms.TextBox()
        Me.txtTaskLog = New System.Windows.Forms.TextBox()
        Me.scrlAmount = New System.Windows.Forms.HScrollBar()
        Me.lblNpc = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.scrlNPC = New System.Windows.Forms.HScrollBar()
        Me.chkEnd = New System.Windows.Forms.CheckBox()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.scrlItem = New System.Windows.Forms.HScrollBar()
        Me.scrlResource = New System.Windows.Forms.HScrollBar()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.lblResource = New System.Windows.Forms.Label()
        Me.scrlMap = New System.Windows.Forms.HScrollBar()
        Me.btnCancelTask = New System.Windows.Forms.Button()
        Me.btnSaveTask = New System.Windows.Forms.Button()
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
        Me.fraRequirements = New System.Windows.Forms.GroupBox()
        Me.rdbNoneReq = New System.Windows.Forms.RadioButton()
        Me.scrlClassRec = New System.Windows.Forms.HScrollBar()
        Me.lblClassRec = New System.Windows.Forms.Label()
        Me.rdbClassReq = New System.Windows.Forms.RadioButton()
        Me.rdbQuestReq = New System.Windows.Forms.RadioButton()
        Me.rdbItemReq = New System.Windows.Forms.RadioButton()
        Me.btnRequirementSave = New System.Windows.Forms.Button()
        Me.btnRequirementCancel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
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
        Me.chkRepeat = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fraGeneral = New System.Windows.Forms.GroupBox()
        Me.chkQuestCancel = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.lstTasks = New System.Windows.Forms.ListBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnRemoveRequirement = New System.Windows.Forms.Button()
        Me.btnAddRequirement = New System.Windows.Forms.Button()
        Me.lstRequirements = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.lblTaskNum = New System.Windows.Forms.Label()
        Me.fraRewards.SuspendLayout()
        Me.fraTasks.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.fraRequirements.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraGeneral.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraRewards
        '
        Me.fraRewards.Controls.Add(Me.btnRemoveReward)
        Me.fraRewards.Controls.Add(Me.btnAddReward)
        Me.fraRewards.Controls.Add(Me.lstRewards)
        Me.fraRewards.Controls.Add(Me.scrlExpReward)
        Me.fraRewards.Controls.Add(Me.lblExpReward)
        Me.fraRewards.Controls.Add(Me.scrlItemRewValue)
        Me.fraRewards.Controls.Add(Me.scrlItemReward)
        Me.fraRewards.Controls.Add(Me.lblItemReward)
        Me.fraRewards.Location = New System.Drawing.Point(6, 146)
        Me.fraRewards.Name = "fraRewards"
        Me.fraRewards.Size = New System.Drawing.Size(488, 102)
        Me.fraRewards.TabIndex = 16
        Me.fraRewards.TabStop = False
        Me.fraRewards.Text = "Rewards"
        '
        'btnRemoveReward
        '
        Me.btnRemoveReward.Location = New System.Drawing.Point(243, 74)
        Me.btnRemoveReward.Name = "btnRemoveReward"
        Me.btnRemoveReward.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveReward.TabIndex = 20
        Me.btnRemoveReward.Text = "Remove"
        Me.btnRemoveReward.UseVisualStyleBackColor = True
        '
        'btnAddReward
        '
        Me.btnAddReward.Location = New System.Drawing.Point(243, 15)
        Me.btnAddReward.Name = "btnAddReward"
        Me.btnAddReward.Size = New System.Drawing.Size(75, 23)
        Me.btnAddReward.TabIndex = 19
        Me.btnAddReward.Text = "Add"
        Me.btnAddReward.UseVisualStyleBackColor = True
        '
        'lstRewards
        '
        Me.lstRewards.FormattingEnabled = True
        Me.lstRewards.Location = New System.Drawing.Point(6, 15)
        Me.lstRewards.Name = "lstRewards"
        Me.lstRewards.Size = New System.Drawing.Size(231, 82)
        Me.lstRewards.TabIndex = 18
        '
        'scrlExpReward
        '
        Me.scrlExpReward.Location = New System.Drawing.Point(332, 23)
        Me.scrlExpReward.Maximum = 10000000
        Me.scrlExpReward.Name = "scrlExpReward"
        Me.scrlExpReward.Size = New System.Drawing.Size(96, 17)
        Me.scrlExpReward.TabIndex = 17
        '
        'lblExpReward
        '
        Me.lblExpReward.AutoSize = True
        Me.lblExpReward.Location = New System.Drawing.Point(329, 8)
        Me.lblExpReward.Name = "lblExpReward"
        Me.lblExpReward.Size = New System.Drawing.Size(109, 13)
        Me.lblExpReward.TabIndex = 16
        Me.lblExpReward.Text = "Experience Gained: 0"
        '
        'scrlItemRewValue
        '
        Me.scrlItemRewValue.Location = New System.Drawing.Point(330, 80)
        Me.scrlItemRewValue.Maximum = 100000
        Me.scrlItemRewValue.Name = "scrlItemRewValue"
        Me.scrlItemRewValue.Size = New System.Drawing.Size(151, 17)
        Me.scrlItemRewValue.TabIndex = 6
        '
        'scrlItemReward
        '
        Me.scrlItemReward.Location = New System.Drawing.Point(330, 58)
        Me.scrlItemReward.Name = "scrlItemReward"
        Me.scrlItemReward.Size = New System.Drawing.Size(151, 17)
        Me.scrlItemReward.TabIndex = 5
        '
        'lblItemReward
        '
        Me.lblItemReward.AutoSize = True
        Me.lblItemReward.Location = New System.Drawing.Point(329, 42)
        Me.lblItemReward.Name = "lblItemReward"
        Me.lblItemReward.Size = New System.Drawing.Size(114, 13)
        Me.lblItemReward.TabIndex = 4
        Me.lblItemReward.Text = "Item Reward: None (1)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(213, 477)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(218, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Use /questreset # to reset a quest for testing"
        '
        'txtEndText
        '
        Me.txtEndText.Location = New System.Drawing.Point(336, 75)
        Me.txtEndText.Multiline = True
        Me.txtEndText.Name = "txtEndText"
        Me.txtEndText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEndText.Size = New System.Drawing.Size(158, 65)
        Me.txtEndText.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(323, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "End Text:"
        '
        'txtProgressText
        '
        Me.txtProgressText.Location = New System.Drawing.Point(171, 75)
        Me.txtProgressText.Multiline = True
        Me.txtProgressText.Name = "txtProgressText"
        Me.txtProgressText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProgressText.Size = New System.Drawing.Size(159, 65)
        Me.txtProgressText.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "In Progress Text:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start Text:"
        '
        'txtStartText
        '
        Me.txtStartText.Location = New System.Drawing.Point(6, 75)
        Me.txtStartText.Multiline = True
        Me.txtStartText.Name = "txtStartText"
        Me.txtStartText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStartText.Size = New System.Drawing.Size(159, 65)
        Me.txtStartText.TabIndex = 0
        '
        'fraTasks
        '
        Me.fraTasks.Controls.Add(Me.lblTaskNum)
        Me.fraTasks.Controls.Add(Me.Panel1)
        Me.fraTasks.Controls.Add(Me.btnCancelTask)
        Me.fraTasks.Controls.Add(Me.btnSaveTask)
        Me.fraTasks.Controls.Add(Me.GroupBox5)
        Me.fraTasks.Location = New System.Drawing.Point(731, -1)
        Me.fraTasks.Name = "fraTasks"
        Me.fraTasks.Size = New System.Drawing.Size(507, 497)
        Me.fraTasks.TabIndex = 17
        Me.fraTasks.TabStop = False
        Me.fraTasks.Text = "Tasks"
        Me.fraTasks.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblLog)
        Me.Panel1.Controls.Add(Me.txtTaskSpeech)
        Me.Panel1.Controls.Add(Me.txtTaskLog)
        Me.Panel1.Controls.Add(Me.scrlAmount)
        Me.Panel1.Controls.Add(Me.lblNpc)
        Me.Panel1.Controls.Add(Me.lblAmount)
        Me.Panel1.Controls.Add(Me.scrlNPC)
        Me.Panel1.Controls.Add(Me.chkEnd)
        Me.Panel1.Controls.Add(Me.lblItem)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.scrlItem)
        Me.Panel1.Controls.Add(Me.scrlResource)
        Me.Panel1.Controls.Add(Me.lblMap)
        Me.Panel1.Controls.Add(Me.lblResource)
        Me.Panel1.Controls.Add(Me.scrlMap)
        Me.Panel1.Location = New System.Drawing.Point(6, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(221, 325)
        Me.Panel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Task Speech:"
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(4, 6)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(55, 13)
        Me.lblLog.TabIndex = 2
        Me.lblLog.Text = "Task Log:"
        '
        'txtTaskSpeech
        '
        Me.txtTaskSpeech.Location = New System.Drawing.Point(4, 63)
        Me.txtTaskSpeech.Name = "txtTaskSpeech"
        Me.txtTaskSpeech.Size = New System.Drawing.Size(212, 20)
        Me.txtTaskSpeech.TabIndex = 26
        '
        'txtTaskLog
        '
        Me.txtTaskLog.Location = New System.Drawing.Point(4, 22)
        Me.txtTaskLog.Name = "txtTaskLog"
        Me.txtTaskLog.Size = New System.Drawing.Size(213, 20)
        Me.txtTaskLog.TabIndex = 3
        '
        'scrlAmount
        '
        Me.scrlAmount.LargeChange = 1
        Me.scrlAmount.Location = New System.Drawing.Point(7, 264)
        Me.scrlAmount.Maximum = 255
        Me.scrlAmount.Name = "scrlAmount"
        Me.scrlAmount.Size = New System.Drawing.Size(213, 17)
        Me.scrlAmount.TabIndex = 24
        '
        'lblNpc
        '
        Me.lblNpc.AutoSize = True
        Me.lblNpc.Location = New System.Drawing.Point(4, 122)
        Me.lblNpc.Name = "lblNpc"
        Me.lblNpc.Size = New System.Drawing.Size(39, 13)
        Me.lblNpc.TabIndex = 4
        Me.lblNpc.Text = "Npc: 0"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(4, 251)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(55, 13)
        Me.lblAmount.TabIndex = 23
        Me.lblAmount.Text = "Amount: 0"
        '
        'scrlNPC
        '
        Me.scrlNPC.LargeChange = 1
        Me.scrlNPC.Location = New System.Drawing.Point(7, 135)
        Me.scrlNPC.Maximum = 255
        Me.scrlNPC.Name = "scrlNPC"
        Me.scrlNPC.Size = New System.Drawing.Size(213, 17)
        Me.scrlNPC.TabIndex = 13
        '
        'chkEnd
        '
        Me.chkEnd.AutoSize = True
        Me.chkEnd.ForeColor = System.Drawing.Color.Green
        Me.chkEnd.Location = New System.Drawing.Point(5, 97)
        Me.chkEnd.Name = "chkEnd"
        Me.chkEnd.Size = New System.Drawing.Size(107, 17)
        Me.chkEnd.TabIndex = 25
        Me.chkEnd.Text = "End Quest Now?"
        Me.chkEnd.UseVisualStyleBackColor = True
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Location = New System.Drawing.Point(4, 152)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(39, 13)
        Me.lblItem.TabIndex = 14
        Me.lblItem.Text = "Item: 0"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(23, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(182, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "-------------------------------------------"
        '
        'scrlItem
        '
        Me.scrlItem.LargeChange = 1
        Me.scrlItem.Location = New System.Drawing.Point(7, 165)
        Me.scrlItem.Maximum = 255
        Me.scrlItem.Name = "scrlItem"
        Me.scrlItem.Size = New System.Drawing.Size(213, 17)
        Me.scrlItem.TabIndex = 15
        '
        'scrlResource
        '
        Me.scrlResource.LargeChange = 1
        Me.scrlResource.Location = New System.Drawing.Point(7, 225)
        Me.scrlResource.Maximum = 255
        Me.scrlResource.Name = "scrlResource"
        Me.scrlResource.Size = New System.Drawing.Size(213, 17)
        Me.scrlResource.TabIndex = 19
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(4, 182)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(40, 13)
        Me.lblMap.TabIndex = 16
        Me.lblMap.Text = "Map: 0"
        '
        'lblResource
        '
        Me.lblResource.AutoSize = True
        Me.lblResource.Location = New System.Drawing.Point(4, 212)
        Me.lblResource.Name = "lblResource"
        Me.lblResource.Size = New System.Drawing.Size(65, 13)
        Me.lblResource.TabIndex = 18
        Me.lblResource.Text = "Resource: 0"
        '
        'scrlMap
        '
        Me.scrlMap.LargeChange = 1
        Me.scrlMap.Location = New System.Drawing.Point(7, 195)
        Me.scrlMap.Maximum = 255
        Me.scrlMap.Name = "scrlMap"
        Me.scrlMap.Size = New System.Drawing.Size(213, 17)
        Me.scrlMap.TabIndex = 17
        '
        'btnCancelTask
        '
        Me.btnCancelTask.Location = New System.Drawing.Point(343, 465)
        Me.btnCancelTask.Name = "btnCancelTask"
        Me.btnCancelTask.Size = New System.Drawing.Size(155, 23)
        Me.btnCancelTask.TabIndex = 5
        Me.btnCancelTask.Text = "Cancel"
        Me.btnCancelTask.UseVisualStyleBackColor = True
        '
        'btnSaveTask
        '
        Me.btnSaveTask.Location = New System.Drawing.Point(163, 465)
        Me.btnSaveTask.Name = "btnSaveTask"
        Me.btnSaveTask.Size = New System.Drawing.Size(155, 23)
        Me.btnSaveTask.TabIndex = 4
        Me.btnSaveTask.Text = "Save Task"
        Me.btnSaveTask.UseVisualStyleBackColor = True
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
        Me.GroupBox5.Location = New System.Drawing.Point(244, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(155, 222)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'optTask7
        '
        Me.optTask7.AutoSize = True
        Me.optTask7.Location = New System.Drawing.Point(6, 199)
        Me.optTask7.Name = "optTask7"
        Me.optTask7.Size = New System.Drawing.Size(111, 17)
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
        Me.optTask6.Size = New System.Drawing.Size(111, 17)
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
        Me.optTask5.Size = New System.Drawing.Size(105, 17)
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
        Me.optTask4.Size = New System.Drawing.Size(81, 17)
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
        Me.optTask3.Size = New System.Drawing.Size(81, 17)
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
        Me.optTask2.Size = New System.Drawing.Size(85, 17)
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
        Me.optTask1.Size = New System.Drawing.Size(80, 17)
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
        Me.optTask0.Size = New System.Drawing.Size(62, 17)
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
        'fraRequirements
        '
        Me.fraRequirements.BackColor = System.Drawing.SystemColors.Window
        Me.fraRequirements.Controls.Add(Me.rdbNoneReq)
        Me.fraRequirements.Controls.Add(Me.scrlClassRec)
        Me.fraRequirements.Controls.Add(Me.lblClassRec)
        Me.fraRequirements.Controls.Add(Me.rdbClassReq)
        Me.fraRequirements.Controls.Add(Me.rdbQuestReq)
        Me.fraRequirements.Controls.Add(Me.rdbItemReq)
        Me.fraRequirements.Controls.Add(Me.btnRequirementSave)
        Me.fraRequirements.Controls.Add(Me.btnRequirementCancel)
        Me.fraRequirements.Controls.Add(Me.GroupBox3)
        Me.fraRequirements.Controls.Add(Me.scrlQuestRec)
        Me.fraRequirements.Controls.Add(Me.lblQuestRec)
        Me.fraRequirements.Controls.Add(Me.scrlItemRec)
        Me.fraRequirements.Controls.Add(Me.lblItemReq)
        Me.fraRequirements.Location = New System.Drawing.Point(729, 2)
        Me.fraRequirements.Name = "fraRequirements"
        Me.fraRequirements.Size = New System.Drawing.Size(505, 497)
        Me.fraRequirements.TabIndex = 15
        Me.fraRequirements.TabStop = False
        Me.fraRequirements.Text = "Requirements"
        Me.fraRequirements.Visible = False
        '
        'rdbNoneReq
        '
        Me.rdbNoneReq.AutoSize = True
        Me.rdbNoneReq.Checked = True
        Me.rdbNoneReq.Location = New System.Drawing.Point(8, 16)
        Me.rdbNoneReq.Name = "rdbNoneReq"
        Me.rdbNoneReq.Size = New System.Drawing.Size(51, 17)
        Me.rdbNoneReq.TabIndex = 12
        Me.rdbNoneReq.TabStop = True
        Me.rdbNoneReq.Text = "None"
        Me.rdbNoneReq.UseVisualStyleBackColor = True
        '
        'scrlClassRec
        '
        Me.scrlClassRec.Enabled = False
        Me.scrlClassRec.Location = New System.Drawing.Point(74, 165)
        Me.scrlClassRec.Name = "scrlClassRec"
        Me.scrlClassRec.Size = New System.Drawing.Size(204, 17)
        Me.scrlClassRec.TabIndex = 11
        '
        'lblClassRec
        '
        Me.lblClassRec.AutoSize = True
        Me.lblClassRec.Location = New System.Drawing.Point(72, 147)
        Me.lblClassRec.Name = "lblClassRec"
        Me.lblClassRec.Size = New System.Drawing.Size(127, 13)
        Me.lblClassRec.TabIndex = 10
        Me.lblClassRec.Text = "Class Requirement: None"
        '
        'rdbClassReq
        '
        Me.rdbClassReq.AutoSize = True
        Me.rdbClassReq.Location = New System.Drawing.Point(8, 154)
        Me.rdbClassReq.Name = "rdbClassReq"
        Me.rdbClassReq.Size = New System.Drawing.Size(50, 17)
        Me.rdbClassReq.TabIndex = 9
        Me.rdbClassReq.Text = "Class"
        Me.rdbClassReq.UseVisualStyleBackColor = True
        '
        'rdbQuestReq
        '
        Me.rdbQuestReq.AutoSize = True
        Me.rdbQuestReq.Location = New System.Drawing.Point(8, 103)
        Me.rdbQuestReq.Name = "rdbQuestReq"
        Me.rdbQuestReq.Size = New System.Drawing.Size(53, 17)
        Me.rdbQuestReq.TabIndex = 8
        Me.rdbQuestReq.Text = "Quest"
        Me.rdbQuestReq.UseVisualStyleBackColor = True
        '
        'rdbItemReq
        '
        Me.rdbItemReq.AutoSize = True
        Me.rdbItemReq.Location = New System.Drawing.Point(8, 52)
        Me.rdbItemReq.Name = "rdbItemReq"
        Me.rdbItemReq.Size = New System.Drawing.Size(45, 17)
        Me.rdbItemReq.TabIndex = 7
        Me.rdbItemReq.Text = "Item"
        Me.rdbItemReq.UseVisualStyleBackColor = True
        '
        'btnRequirementSave
        '
        Me.btnRequirementSave.Location = New System.Drawing.Point(256, 468)
        Me.btnRequirementSave.Name = "btnRequirementSave"
        Me.btnRequirementSave.Size = New System.Drawing.Size(75, 23)
        Me.btnRequirementSave.TabIndex = 6
        Me.btnRequirementSave.Text = "Save"
        Me.btnRequirementSave.UseVisualStyleBackColor = True
        '
        'btnRequirementCancel
        '
        Me.btnRequirementCancel.Location = New System.Drawing.Point(359, 468)
        Me.btnRequirementCancel.Name = "btnRequirementCancel"
        Me.btnRequirementCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnRequirementCancel.TabIndex = 5
        Me.btnRequirementCancel.Text = "Cancel"
        Me.btnRequirementCancel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox3.Controls.Add(Me.scrlEndItemAmount)
        Me.GroupBox3.Controls.Add(Me.scrlEndItemName)
        Me.GroupBox3.Controls.Add(Me.lblEnditem)
        Me.GroupBox3.Controls.Add(Me.scrlStartItemAmount)
        Me.GroupBox3.Controls.Add(Me.scrlStartItemName)
        Me.GroupBox3.Controls.Add(Me.lblStartItem)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 194)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(387, 229)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Items Needed For Quest"
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
        Me.lblEnditem.Size = New System.Drawing.Size(137, 13)
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
        Me.lblStartItem.Size = New System.Drawing.Size(136, 13)
        Me.lblStartItem.TabIndex = 0
        Me.lblStartItem.Text = "Give item on start: None (1)"
        '
        'scrlQuestRec
        '
        Me.scrlQuestRec.Enabled = False
        Me.scrlQuestRec.Location = New System.Drawing.Point(75, 113)
        Me.scrlQuestRec.Name = "scrlQuestRec"
        Me.scrlQuestRec.Size = New System.Drawing.Size(204, 17)
        Me.scrlQuestRec.TabIndex = 3
        '
        'lblQuestRec
        '
        Me.lblQuestRec.AutoSize = True
        Me.lblQuestRec.Location = New System.Drawing.Point(73, 95)
        Me.lblQuestRec.Name = "lblQuestRec"
        Me.lblQuestRec.Size = New System.Drawing.Size(130, 13)
        Me.lblQuestRec.TabIndex = 2
        Me.lblQuestRec.Text = "Quest Requirement: None"
        '
        'scrlItemRec
        '
        Me.scrlItemRec.Enabled = False
        Me.scrlItemRec.Location = New System.Drawing.Point(76, 61)
        Me.scrlItemRec.Name = "scrlItemRec"
        Me.scrlItemRec.Size = New System.Drawing.Size(204, 17)
        Me.scrlItemRec.TabIndex = 1
        '
        'lblItemReq
        '
        Me.lblItemReq.AutoSize = True
        Me.lblItemReq.Location = New System.Drawing.Point(73, 39)
        Me.lblItemReq.Name = "lblItemReq"
        Me.lblItemReq.Size = New System.Drawing.Size(122, 13)
        Me.lblItemReq.TabIndex = 0
        Me.lblItemReq.Text = "Item Requirement: None"
        '
        'chkRepeat
        '
        Me.chkRepeat.AutoSize = True
        Me.chkRepeat.Location = New System.Drawing.Point(298, 21)
        Me.chkRepeat.Name = "chkRepeat"
        Me.chkRepeat.Size = New System.Drawing.Size(87, 17)
        Me.chkRepeat.TabIndex = 7
        Me.chkRepeat.Text = "Repeatable?"
        Me.chkRepeat.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(616, 467)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(523, 467)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 23)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'fraGeneral
        '
        Me.fraGeneral.BackColor = System.Drawing.SystemColors.Window
        Me.fraGeneral.Controls.Add(Me.chkQuestCancel)
        Me.fraGeneral.Controls.Add(Me.fraRewards)
        Me.fraGeneral.Controls.Add(Me.GroupBox7)
        Me.fraGeneral.Controls.Add(Me.GroupBox6)
        Me.fraGeneral.Controls.Add(Me.txtStartText)
        Me.fraGeneral.Controls.Add(Me.chkRepeat)
        Me.fraGeneral.Controls.Add(Me.txtEndText)
        Me.fraGeneral.Controls.Add(Me.Label12)
        Me.fraGeneral.Controls.Add(Me.Label3)
        Me.fraGeneral.Controls.Add(Me.txtName)
        Me.fraGeneral.Controls.Add(Me.txtProgressText)
        Me.fraGeneral.Controls.Add(Me.Label1)
        Me.fraGeneral.Controls.Add(Me.Label2)
        Me.fraGeneral.Location = New System.Drawing.Point(216, 2)
        Me.fraGeneral.Name = "fraGeneral"
        Me.fraGeneral.Size = New System.Drawing.Size(505, 459)
        Me.fraGeneral.TabIndex = 10
        Me.fraGeneral.TabStop = False
        Me.fraGeneral.Text = "General"
        '
        'chkQuestCancel
        '
        Me.chkQuestCancel.AutoSize = True
        Me.chkQuestCancel.Location = New System.Drawing.Point(391, 21)
        Me.chkQuestCancel.Name = "chkQuestCancel"
        Me.chkQuestCancel.Size = New System.Drawing.Size(96, 17)
        Me.chkQuestCancel.TabIndex = 28
        Me.chkQuestCancel.Text = "Cancel Quest?"
        Me.chkQuestCancel.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnRemoveTask)
        Me.GroupBox7.Controls.Add(Me.btnAddTask)
        Me.GroupBox7.Controls.Add(Me.lstTasks)
        Me.GroupBox7.Location = New System.Drawing.Point(255, 254)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(243, 199)
        Me.GroupBox7.TabIndex = 27
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Quest Tasks"
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Location = New System.Drawing.Point(114, 172)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Size = New System.Drawing.Size(123, 23)
        Me.btnRemoveTask.TabIndex = 4
        Me.btnRemoveTask.Text = "Remove Task"
        Me.btnRemoveTask.UseVisualStyleBackColor = True
        '
        'btnAddTask
        '
        Me.btnAddTask.Location = New System.Drawing.Point(6, 172)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Size = New System.Drawing.Size(102, 23)
        Me.btnAddTask.TabIndex = 3
        Me.btnAddTask.Text = "Add Task"
        Me.btnAddTask.UseVisualStyleBackColor = True
        '
        'lstTasks
        '
        Me.lstTasks.FormattingEnabled = True
        Me.lstTasks.Location = New System.Drawing.Point(6, 19)
        Me.lstTasks.Name = "lstTasks"
        Me.lstTasks.Size = New System.Drawing.Size(228, 147)
        Me.lstTasks.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnRemoveRequirement)
        Me.GroupBox6.Controls.Add(Me.btnAddRequirement)
        Me.GroupBox6.Controls.Add(Me.lstRequirements)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 254)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(243, 199)
        Me.GroupBox6.TabIndex = 26
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Quest Requirements"
        '
        'btnRemoveRequirement
        '
        Me.btnRemoveRequirement.Location = New System.Drawing.Point(114, 172)
        Me.btnRemoveRequirement.Name = "btnRemoveRequirement"
        Me.btnRemoveRequirement.Size = New System.Drawing.Size(123, 23)
        Me.btnRemoveRequirement.TabIndex = 2
        Me.btnRemoveRequirement.Text = "Remove Requirement"
        Me.btnRemoveRequirement.UseVisualStyleBackColor = True
        '
        'btnAddRequirement
        '
        Me.btnAddRequirement.Location = New System.Drawing.Point(6, 172)
        Me.btnAddRequirement.Name = "btnAddRequirement"
        Me.btnAddRequirement.Size = New System.Drawing.Size(102, 23)
        Me.btnAddRequirement.TabIndex = 1
        Me.btnAddRequirement.Text = "Add Requirement"
        Me.btnAddRequirement.UseVisualStyleBackColor = True
        '
        'lstRequirements
        '
        Me.lstRequirements.FormattingEnabled = True
        Me.lstRequirements.Location = New System.Drawing.Point(6, 19)
        Me.lstRequirements.Name = "lstRequirements"
        Me.lstRequirements.Size = New System.Drawing.Size(231, 147)
        Me.lstRequirements.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Quest Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(81, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(211, 20)
        Me.txtName.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 488)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Quest List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(7, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(194, 459)
        Me.lstIndex.TabIndex = 0
        '
        'lblTaskNum
        '
        Me.lblTaskNum.AutoSize = True
        Me.lblTaskNum.Location = New System.Drawing.Point(6, 340)
        Me.lblTaskNum.Name = "lblTaskNum"
        Me.lblTaskNum.Size = New System.Drawing.Size(74, 13)
        Me.lblTaskNum.TabIndex = 7
        Me.lblTaskNum.Text = "Task Number:"
        '
        'frmEditor_Quest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1175, 502)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraGeneral)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraTasks)
        Me.Controls.Add(Me.fraRequirements)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Quest"
        Me.Text = "Quest Editor"
        Me.fraRewards.ResumeLayout(False)
        Me.fraRewards.PerformLayout()
        Me.fraTasks.ResumeLayout(False)
        Me.fraTasks.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.fraRequirements.ResumeLayout(False)
        Me.fraRequirements.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.fraGeneral.ResumeLayout(False)
        Me.fraGeneral.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fraRewards As GroupBox
    Friend WithEvents scrlExpReward As HScrollBar
    Friend WithEvents lblExpReward As Label
    Friend WithEvents scrlItemRewValue As HScrollBar
    Friend WithEvents scrlItemReward As HScrollBar
    Friend WithEvents lblItemReward As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEndText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProgressText As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStartText As TextBox
    Friend WithEvents fraTasks As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents optTask7 As RadioButton
    Friend WithEvents optTask6 As RadioButton
    Friend WithEvents optTask5 As RadioButton
    Friend WithEvents optTask4 As RadioButton
    Friend WithEvents optTask3 As RadioButton
    Friend WithEvents optTask2 As RadioButton
    Friend WithEvents optTask1 As RadioButton
    Friend WithEvents optTask0 As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents chkEnd As CheckBox
    Friend WithEvents scrlAmount As HScrollBar
    Friend WithEvents lblAmount As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents scrlResource As HScrollBar
    Friend WithEvents lblResource As Label
    Friend WithEvents scrlMap As HScrollBar
    Friend WithEvents lblMap As Label
    Friend WithEvents scrlItem As HScrollBar
    Friend WithEvents lblItem As Label
    Friend WithEvents scrlNPC As HScrollBar
    Friend WithEvents lblNpc As Label
    Friend WithEvents txtTaskLog As TextBox
    Friend WithEvents lblLog As Label
    Friend WithEvents fraRequirements As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkRepeat As CheckBox
    Friend WithEvents scrlEndItemAmount As HScrollBar
    Friend WithEvents scrlEndItemName As HScrollBar
    Friend WithEvents lblEnditem As Label
    Friend WithEvents scrlStartItemAmount As HScrollBar
    Friend WithEvents scrlStartItemName As HScrollBar
    Friend WithEvents lblStartItem As Label
    Friend WithEvents scrlQuestRec As HScrollBar
    Friend WithEvents lblQuestRec As Label
    Friend WithEvents scrlItemRec As HScrollBar
    Friend WithEvents lblItemReq As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents fraGeneral As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstIndex As ListBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkQuestCancel As CheckBox
    Friend WithEvents btnRemoveTask As Button
    Friend WithEvents btnAddTask As Button
    Friend WithEvents lstTasks As ListBox
    Friend WithEvents btnRemoveRequirement As Button
    Friend WithEvents btnAddRequirement As Button
    Friend WithEvents lstRequirements As ListBox
    Friend WithEvents txtTaskSpeech As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCancelTask As Button
    Friend WithEvents btnSaveTask As Button
    Friend WithEvents btnRequirementSave As Button
    Friend WithEvents btnRequirementCancel As Button
    Friend WithEvents scrlClassRec As HScrollBar
    Friend WithEvents lblClassRec As Label
    Friend WithEvents rdbClassReq As RadioButton
    Friend WithEvents rdbQuestReq As RadioButton
    Friend WithEvents rdbItemReq As RadioButton
    Friend WithEvents rdbNoneReq As RadioButton
    Friend WithEvents btnRemoveReward As Button
    Friend WithEvents btnAddReward As Button
    Friend WithEvents lstRewards As ListBox
    Friend WithEvents lblTaskNum As Label
End Class
