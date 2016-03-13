<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Resource
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
        Me.scrlAnimation = New System.Windows.Forms.HScrollBar()
        Me.lblAnim = New System.Windows.Forms.Label()
        Me.scrlRespawn = New System.Windows.Forms.HScrollBar()
        Me.lblRespawn = New System.Windows.Forms.Label()
        Me.scrlHealth = New System.Windows.Forms.HScrollBar()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.scrlTool = New System.Windows.Forms.HScrollBar()
        Me.lblTool = New System.Windows.Forms.Label()
        Me.scrlReward = New System.Windows.Forms.HScrollBar()
        Me.lblReward = New System.Windows.Forms.Label()
        Me.picExhaustedPic = New System.Windows.Forms.PictureBox()
        Me.picNormalpic = New System.Windows.Forms.PictureBox()
        Me.scrlExhaustedPic = New System.Windows.Forms.HScrollBar()
        Me.scrlNormalPic = New System.Windows.Forms.HScrollBar()
        Me.lblExhaustedPic = New System.Windows.Forms.Label()
        Me.lblNormalPic = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.txtMessage2 = New System.Windows.Forms.TextBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picExhaustedPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNormalpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 505)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resource List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(8, 16)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(196, 485)
        Me.lstIndex.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.scrlAnimation)
        Me.GroupBox2.Controls.Add(Me.lblAnim)
        Me.GroupBox2.Controls.Add(Me.scrlRespawn)
        Me.GroupBox2.Controls.Add(Me.lblRespawn)
        Me.GroupBox2.Controls.Add(Me.scrlHealth)
        Me.GroupBox2.Controls.Add(Me.lblHealth)
        Me.GroupBox2.Controls.Add(Me.scrlTool)
        Me.GroupBox2.Controls.Add(Me.lblTool)
        Me.GroupBox2.Controls.Add(Me.scrlReward)
        Me.GroupBox2.Controls.Add(Me.lblReward)
        Me.GroupBox2.Controls.Add(Me.picExhaustedPic)
        Me.GroupBox2.Controls.Add(Me.picNormalpic)
        Me.GroupBox2.Controls.Add(Me.scrlExhaustedPic)
        Me.GroupBox2.Controls.Add(Me.scrlNormalPic)
        Me.GroupBox2.Controls.Add(Me.lblExhaustedPic)
        Me.GroupBox2.Controls.Add(Me.lblNormalPic)
        Me.GroupBox2.Controls.Add(Me.cmbType)
        Me.GroupBox2.Controls.Add(Me.txtMessage2)
        Me.GroupBox2.Controls.Add(Me.txtMessage)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(219, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 505)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resource Properties"
        '
        'scrlAnimation
        '
        Me.scrlAnimation.LargeChange = 1
        Me.scrlAnimation.Location = New System.Drawing.Point(11, 481)
        Me.scrlAnimation.Maximum = 10000
        Me.scrlAnimation.Name = "scrlAnimation"
        Me.scrlAnimation.Size = New System.Drawing.Size(315, 17)
        Me.scrlAnimation.TabIndex = 53
        '
        'lblAnim
        '
        Me.lblAnim.AutoSize = True
        Me.lblAnim.Location = New System.Drawing.Point(10, 468)
        Me.lblAnim.Name = "lblAnim"
        Me.lblAnim.Size = New System.Drawing.Size(85, 13)
        Me.lblAnim.TabIndex = 52
        Me.lblAnim.Text = "Animation: None"
        '
        'scrlRespawn
        '
        Me.scrlRespawn.LargeChange = 1
        Me.scrlRespawn.Location = New System.Drawing.Point(11, 442)
        Me.scrlRespawn.Maximum = 10000
        Me.scrlRespawn.Name = "scrlRespawn"
        Me.scrlRespawn.Size = New System.Drawing.Size(315, 17)
        Me.scrlRespawn.TabIndex = 51
        '
        'lblRespawn
        '
        Me.lblRespawn.AutoSize = True
        Me.lblRespawn.Location = New System.Drawing.Point(8, 429)
        Me.lblRespawn.Name = "lblRespawn"
        Me.lblRespawn.Size = New System.Drawing.Size(138, 13)
        Me.lblRespawn.TabIndex = 50
        Me.lblRespawn.Text = "Respawn Time(Seconds): 0"
        '
        'scrlHealth
        '
        Me.scrlHealth.LargeChange = 1
        Me.scrlHealth.Location = New System.Drawing.Point(11, 401)
        Me.scrlHealth.Maximum = 10000
        Me.scrlHealth.Name = "scrlHealth"
        Me.scrlHealth.Size = New System.Drawing.Size(315, 17)
        Me.scrlHealth.TabIndex = 49
        '
        'lblHealth
        '
        Me.lblHealth.AutoSize = True
        Me.lblHealth.Location = New System.Drawing.Point(10, 388)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(50, 13)
        Me.lblHealth.TabIndex = 48
        Me.lblHealth.Text = "Health: 0"
        '
        'scrlTool
        '
        Me.scrlTool.LargeChange = 1
        Me.scrlTool.Location = New System.Drawing.Point(13, 354)
        Me.scrlTool.Maximum = 3
        Me.scrlTool.Name = "scrlTool"
        Me.scrlTool.Size = New System.Drawing.Size(319, 17)
        Me.scrlTool.TabIndex = 47
        '
        'lblTool
        '
        Me.lblTool.AutoSize = True
        Me.lblTool.Location = New System.Drawing.Point(12, 335)
        Me.lblTool.Name = "lblTool"
        Me.lblTool.Size = New System.Drawing.Size(106, 13)
        Me.lblTool.TabIndex = 46
        Me.lblTool.Text = "Tool Required: None"
        '
        'scrlReward
        '
        Me.scrlReward.Location = New System.Drawing.Point(11, 309)
        Me.scrlReward.Name = "scrlReward"
        Me.scrlReward.Size = New System.Drawing.Size(322, 17)
        Me.scrlReward.TabIndex = 45
        '
        'lblReward
        '
        Me.lblReward.AutoSize = True
        Me.lblReward.Location = New System.Drawing.Point(10, 290)
        Me.lblReward.Name = "lblReward"
        Me.lblReward.Size = New System.Drawing.Size(99, 13)
        Me.lblReward.TabIndex = 44
        Me.lblReward.Text = "Item Reward: None"
        '
        'picExhaustedPic
        '
        Me.picExhaustedPic.BackColor = System.Drawing.Color.Black
        Me.picExhaustedPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picExhaustedPic.Location = New System.Drawing.Point(182, 165)
        Me.picExhaustedPic.Name = "picExhaustedPic"
        Me.picExhaustedPic.Size = New System.Drawing.Size(152, 112)
        Me.picExhaustedPic.TabIndex = 43
        Me.picExhaustedPic.TabStop = False
        '
        'picNormalpic
        '
        Me.picNormalpic.BackColor = System.Drawing.Color.Black
        Me.picNormalpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picNormalpic.Location = New System.Drawing.Point(13, 165)
        Me.picNormalpic.Name = "picNormalpic"
        Me.picNormalpic.Size = New System.Drawing.Size(152, 112)
        Me.picNormalpic.TabIndex = 42
        Me.picNormalpic.TabStop = False
        '
        'scrlExhaustedPic
        '
        Me.scrlExhaustedPic.LargeChange = 1
        Me.scrlExhaustedPic.Location = New System.Drawing.Point(182, 139)
        Me.scrlExhaustedPic.Name = "scrlExhaustedPic"
        Me.scrlExhaustedPic.Size = New System.Drawing.Size(152, 18)
        Me.scrlExhaustedPic.TabIndex = 41
        '
        'scrlNormalPic
        '
        Me.scrlNormalPic.LargeChange = 1
        Me.scrlNormalPic.Location = New System.Drawing.Point(13, 139)
        Me.scrlNormalPic.Name = "scrlNormalPic"
        Me.scrlNormalPic.Size = New System.Drawing.Size(152, 18)
        Me.scrlNormalPic.TabIndex = 40
        '
        'lblExhaustedPic
        '
        Me.lblExhaustedPic.AutoSize = True
        Me.lblExhaustedPic.Location = New System.Drawing.Point(179, 123)
        Me.lblExhaustedPic.Name = "lblExhaustedPic"
        Me.lblExhaustedPic.Size = New System.Drawing.Size(101, 13)
        Me.lblExhaustedPic.TabIndex = 39
        Me.lblExhaustedPic.Text = "Exhausted Image: 0"
        '
        'lblNormalPic
        '
        Me.lblNormalPic.AutoSize = True
        Me.lblNormalPic.Location = New System.Drawing.Point(8, 123)
        Me.lblNormalPic.Name = "lblNormalPic"
        Me.lblNormalPic.Size = New System.Drawing.Size(84, 13)
        Me.lblNormalPic.TabIndex = 38
        Me.lblNormalPic.Text = "Normal Image: 0"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"None", "Tree", "Mine", "Fishing Spot"})
        Me.cmbType.Location = New System.Drawing.Point(58, 99)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(276, 21)
        Me.cmbType.TabIndex = 37
        '
        'txtMessage2
        '
        Me.txtMessage2.Location = New System.Drawing.Point(58, 72)
        Me.txtMessage2.Name = "txtMessage2"
        Me.txtMessage2.Size = New System.Drawing.Size(276, 20)
        Me.txtMessage2.TabIndex = 6
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(58, 46)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(276, 20)
        Me.txtMessage.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(58, 17)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(276, 20)
        Me.txtName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Empty:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sucess:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(219, 513)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 25)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(330, 513)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 25)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(441, 513)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditor_Resource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 544)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmEditor_Resource"
        Me.Text = "frmEditor_Resource"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picExhaustedPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNormalpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMessage2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents picExhaustedPic As System.Windows.Forms.PictureBox
    Friend WithEvents picNormalpic As System.Windows.Forms.PictureBox
    Friend WithEvents scrlExhaustedPic As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlNormalPic As System.Windows.Forms.HScrollBar
    Friend WithEvents lblExhaustedPic As System.Windows.Forms.Label
    Friend WithEvents lblNormalPic As System.Windows.Forms.Label
    Friend WithEvents scrlReward As System.Windows.Forms.HScrollBar
    Friend WithEvents lblReward As System.Windows.Forms.Label
    Friend WithEvents scrlTool As System.Windows.Forms.HScrollBar
    Friend WithEvents lblTool As System.Windows.Forms.Label
    Friend WithEvents scrlAnimation As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAnim As System.Windows.Forms.Label
    Friend WithEvents scrlRespawn As System.Windows.Forms.HScrollBar
    Friend WithEvents lblRespawn As System.Windows.Forms.Label
    Friend WithEvents scrlHealth As System.Windows.Forms.HScrollBar
    Friend WithEvents lblHealth As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
