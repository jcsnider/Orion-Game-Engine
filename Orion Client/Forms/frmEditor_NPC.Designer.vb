<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_NPC
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
        Me.scrlQuest = New System.Windows.Forms.HScrollBar()
        Me.lblQuest = New System.Windows.Forms.Label()
        Me.scrlAnimation = New System.Windows.Forms.HScrollBar()
        Me.lblAnimation = New System.Windows.Forms.Label()
        Me.txtSpawnSecs = New System.Windows.Forms.TextBox()
        Me.txtEXP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbFaction = New System.Windows.Forms.ComboBox()
        Me.cmbBehaviour = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picSprite = New System.Windows.Forms.PictureBox()
        Me.scrlRange = New System.Windows.Forms.HScrollBar()
        Me.scrlSprite = New System.Windows.Forms.HScrollBar()
        Me.lblRange = New System.Windows.Forms.Label()
        Me.lblSprite = New System.Windows.Forms.Label()
        Me.txtAttackSay = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbDropSlot = New System.Windows.Forms.ComboBox()
        Me.scrlValue = New System.Windows.Forms.HScrollBar()
        Me.scrlNum = New System.Windows.Forms.HScrollBar()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.txtChance = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblSpr = New System.Windows.Forms.Label()
        Me.scrlSpr = New System.Windows.Forms.HScrollBar()
        Me.lblVit = New System.Windows.Forms.Label()
        Me.scrlVit = New System.Windows.Forms.HScrollBar()
        Me.lblInt = New System.Windows.Forms.Label()
        Me.scrlInt = New System.Windows.Forms.HScrollBar()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.scrlEnd = New System.Windows.Forms.HScrollBar()
        Me.lblLuck = New System.Windows.Forms.Label()
        Me.scrlWill = New System.Windows.Forms.HScrollBar()
        Me.lblStr = New System.Windows.Forms.Label()
        Me.scrlStr = New System.Windows.Forms.HScrollBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 499)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NPC List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(6, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(219, 472)
        Me.lstIndex.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.scrlQuest)
        Me.GroupBox2.Controls.Add(Me.lblQuest)
        Me.GroupBox2.Controls.Add(Me.scrlAnimation)
        Me.GroupBox2.Controls.Add(Me.lblAnimation)
        Me.GroupBox2.Controls.Add(Me.txtSpawnSecs)
        Me.GroupBox2.Controls.Add(Me.txtEXP)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtHP)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbFaction)
        Me.GroupBox2.Controls.Add(Me.cmbBehaviour)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.picSprite)
        Me.GroupBox2.Controls.Add(Me.scrlRange)
        Me.GroupBox2.Controls.Add(Me.scrlSprite)
        Me.GroupBox2.Controls.Add(Me.lblRange)
        Me.GroupBox2.Controls.Add(Me.lblSprite)
        Me.GroupBox2.Controls.Add(Me.txtAttackSay)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(243, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(357, 246)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "NPC Properties"
        '
        'scrlQuest
        '
        Me.scrlQuest.LargeChange = 1
        Me.scrlQuest.Location = New System.Drawing.Point(267, 102)
        Me.scrlQuest.Name = "scrlQuest"
        Me.scrlQuest.Size = New System.Drawing.Size(84, 15)
        Me.scrlQuest.TabIndex = 53
        '
        'lblQuest
        '
        Me.lblQuest.AutoSize = True
        Me.lblQuest.Location = New System.Drawing.Point(199, 102)
        Me.lblQuest.Name = "lblQuest"
        Me.lblQuest.Size = New System.Drawing.Size(47, 13)
        Me.lblQuest.TabIndex = 52
        Me.lblQuest.Text = "Quest: 0"
        '
        'scrlAnimation
        '
        Me.scrlAnimation.LargeChange = 1
        Me.scrlAnimation.Location = New System.Drawing.Point(199, 122)
        Me.scrlAnimation.Name = "scrlAnimation"
        Me.scrlAnimation.Size = New System.Drawing.Size(152, 18)
        Me.scrlAnimation.TabIndex = 45
        '
        'lblAnimation
        '
        Me.lblAnimation.AutoSize = True
        Me.lblAnimation.Location = New System.Drawing.Point(10, 127)
        Me.lblAnimation.Name = "lblAnimation"
        Me.lblAnimation.Size = New System.Drawing.Size(85, 13)
        Me.lblAnimation.TabIndex = 44
        Me.lblAnimation.Text = "Animation: None"
        '
        'txtSpawnSecs
        '
        Me.txtSpawnSecs.Location = New System.Drawing.Point(132, 210)
        Me.txtSpawnSecs.Name = "txtSpawnSecs"
        Me.txtSpawnSecs.Size = New System.Drawing.Size(85, 20)
        Me.txtSpawnSecs.TabIndex = 3
        Me.txtSpawnSecs.Text = "0"
        '
        'txtEXP
        '
        Me.txtEXP.Location = New System.Drawing.Point(233, 210)
        Me.txtEXP.Name = "txtEXP"
        Me.txtEXP.Size = New System.Drawing.Size(100, 20)
        Me.txtEXP.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Spawn Rate (Seconds)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(233, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "EXP:"
        '
        'txtHP
        '
        Me.txtHP.Location = New System.Drawing.Point(233, 156)
        Me.txtHP.Name = "txtHP"
        Me.txtHP.Size = New System.Drawing.Size(100, 20)
        Me.txtHP.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(233, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Health:"
        '
        'cmbFaction
        '
        Me.cmbFaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFaction.FormattingEnabled = True
        Me.cmbFaction.Items.AddRange(New Object() {"None", "Baddies", "Goodies"})
        Me.cmbFaction.Location = New System.Drawing.Point(81, 182)
        Me.cmbFaction.Name = "cmbFaction"
        Me.cmbFaction.Size = New System.Drawing.Size(146, 21)
        Me.cmbFaction.TabIndex = 39
        '
        'cmbBehaviour
        '
        Me.cmbBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBehaviour.FormattingEnabled = True
        Me.cmbBehaviour.Items.AddRange(New Object() {"Attack on sight", "Attack when attacked", "Friendly", "Shop keeper", "Guard", "Quest"})
        Me.cmbBehaviour.Location = New System.Drawing.Point(81, 156)
        Me.cmbBehaviour.Name = "cmbBehaviour"
        Me.cmbBehaviour.Size = New System.Drawing.Size(146, 21)
        Me.cmbBehaviour.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Faction:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Behavior:"
        '
        'picSprite
        '
        Me.picSprite.BackColor = System.Drawing.Color.Black
        Me.picSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picSprite.Location = New System.Drawing.Point(282, 16)
        Me.picSprite.Name = "picSprite"
        Me.picSprite.Size = New System.Drawing.Size(67, 72)
        Me.picSprite.TabIndex = 8
        Me.picSprite.TabStop = False
        '
        'scrlRange
        '
        Me.scrlRange.LargeChange = 1
        Me.scrlRange.Location = New System.Drawing.Point(84, 102)
        Me.scrlRange.Name = "scrlRange"
        Me.scrlRange.Size = New System.Drawing.Size(84, 15)
        Me.scrlRange.TabIndex = 7
        '
        'scrlSprite
        '
        Me.scrlSprite.LargeChange = 1
        Me.scrlSprite.Location = New System.Drawing.Point(84, 75)
        Me.scrlSprite.Name = "scrlSprite"
        Me.scrlSprite.Size = New System.Drawing.Size(192, 15)
        Me.scrlSprite.TabIndex = 6
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Location = New System.Drawing.Point(10, 102)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(51, 13)
        Me.lblRange.TabIndex = 5
        Me.lblRange.Text = "Range: 0"
        '
        'lblSprite
        '
        Me.lblSprite.AutoSize = True
        Me.lblSprite.Location = New System.Drawing.Point(10, 77)
        Me.lblSprite.Name = "lblSprite"
        Me.lblSprite.Size = New System.Drawing.Size(46, 13)
        Me.lblSprite.TabIndex = 4
        Me.lblSprite.Text = "Sprite: 0"
        '
        'txtAttackSay
        '
        Me.txtAttackSay.Location = New System.Drawing.Point(57, 43)
        Me.txtAttackSay.Name = "txtAttackSay"
        Me.txtAttackSay.Size = New System.Drawing.Size(219, 20)
        Me.txtAttackSay.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(57, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(219, 20)
        Me.txtName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Say:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.cmbDropSlot)
        Me.GroupBox4.Controls.Add(Me.scrlValue)
        Me.GroupBox4.Controls.Add(Me.scrlNum)
        Me.GroupBox4.Controls.Add(Me.lblValue)
        Me.GroupBox4.Controls.Add(Me.lblNum)
        Me.GroupBox4.Controls.Add(Me.lblItemName)
        Me.GroupBox4.Controls.Add(Me.txtChance)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(243, 355)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(357, 119)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Drop"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Drop Slot: "
        '
        'cmbDropSlot
        '
        Me.cmbDropSlot.FormattingEnabled = True
        Me.cmbDropSlot.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cmbDropSlot.Location = New System.Drawing.Point(72, 16)
        Me.cmbDropSlot.Name = "cmbDropSlot"
        Me.cmbDropSlot.Size = New System.Drawing.Size(71, 21)
        Me.cmbDropSlot.TabIndex = 10
        '
        'scrlValue
        '
        Me.scrlValue.LargeChange = 1
        Me.scrlValue.Location = New System.Drawing.Point(118, 94)
        Me.scrlValue.Name = "scrlValue"
        Me.scrlValue.Size = New System.Drawing.Size(211, 15)
        Me.scrlValue.TabIndex = 9
        '
        'scrlNum
        '
        Me.scrlNum.LargeChange = 1
        Me.scrlNum.Location = New System.Drawing.Point(118, 67)
        Me.scrlNum.Name = "scrlNum"
        Me.scrlNum.Size = New System.Drawing.Size(211, 15)
        Me.scrlNum.TabIndex = 8
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(11, 92)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(46, 13)
        Me.lblValue.TabIndex = 6
        Me.lblValue.Text = "Value: 0"
        '
        'lblNum
        '
        Me.lblNum.AutoSize = True
        Me.lblNum.Location = New System.Drawing.Point(10, 69)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(41, 13)
        Me.lblNum.TabIndex = 5
        Me.lblNum.Text = "Num: 0"
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Location = New System.Drawing.Point(11, 46)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(59, 13)
        Me.lblItemName.TabIndex = 4
        Me.lblItemName.Text = "Item: None"
        '
        'txtChance
        '
        Me.txtChance.Location = New System.Drawing.Point(267, 16)
        Me.txtChance.Name = "txtChance"
        Me.txtChance.Size = New System.Drawing.Size(82, 20)
        Me.txtChance.TabIndex = 1
        Me.txtChance.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(178, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Chance 1 out of"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblSpr)
        Me.GroupBox3.Controls.Add(Me.scrlSpr)
        Me.GroupBox3.Controls.Add(Me.lblVit)
        Me.GroupBox3.Controls.Add(Me.scrlVit)
        Me.GroupBox3.Controls.Add(Me.lblInt)
        Me.GroupBox3.Controls.Add(Me.scrlInt)
        Me.GroupBox3.Controls.Add(Me.lblEnd)
        Me.GroupBox3.Controls.Add(Me.scrlEnd)
        Me.GroupBox3.Controls.Add(Me.lblLuck)
        Me.GroupBox3.Controls.Add(Me.scrlWill)
        Me.GroupBox3.Controls.Add(Me.lblStr)
        Me.GroupBox3.Controls.Add(Me.scrlStr)
        Me.GroupBox3.Location = New System.Drawing.Point(243, 258)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(357, 91)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stats"
        '
        'lblSpr
        '
        Me.lblSpr.AutoSize = True
        Me.lblSpr.Location = New System.Drawing.Point(264, 68)
        Me.lblSpr.Name = "lblSpr"
        Me.lblSpr.Size = New System.Drawing.Size(42, 13)
        Me.lblSpr.TabIndex = 11
        Me.lblSpr.Text = "Spirit: 0"
        '
        'scrlSpr
        '
        Me.scrlSpr.LargeChange = 1
        Me.scrlSpr.Location = New System.Drawing.Point(267, 55)
        Me.scrlSpr.Name = "scrlSpr"
        Me.scrlSpr.Size = New System.Drawing.Size(82, 13)
        Me.scrlSpr.TabIndex = 10
        '
        'lblVit
        '
        Me.lblVit.AutoSize = True
        Me.lblVit.Location = New System.Drawing.Point(264, 29)
        Me.lblVit.Name = "lblVit"
        Me.lblVit.Size = New System.Drawing.Size(49, 13)
        Me.lblVit.TabIndex = 9
        Me.lblVit.Text = "Vitality: 0"
        '
        'scrlVit
        '
        Me.scrlVit.LargeChange = 1
        Me.scrlVit.Location = New System.Drawing.Point(267, 16)
        Me.scrlVit.Name = "scrlVit"
        Me.scrlVit.Size = New System.Drawing.Size(82, 13)
        Me.scrlVit.TabIndex = 8
        '
        'lblInt
        '
        Me.lblInt.AutoSize = True
        Me.lblInt.Location = New System.Drawing.Point(132, 68)
        Me.lblInt.Name = "lblInt"
        Me.lblInt.Size = New System.Drawing.Size(73, 13)
        Me.lblInt.TabIndex = 7
        Me.lblInt.Text = "Intelligence: 0"
        '
        'scrlInt
        '
        Me.scrlInt.LargeChange = 1
        Me.scrlInt.Location = New System.Drawing.Point(135, 55)
        Me.scrlInt.Name = "scrlInt"
        Me.scrlInt.Size = New System.Drawing.Size(82, 13)
        Me.scrlInt.TabIndex = 6
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(132, 29)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(71, 13)
        Me.lblEnd.TabIndex = 5
        Me.lblEnd.Text = "Endurance: 0"
        '
        'scrlEnd
        '
        Me.scrlEnd.LargeChange = 1
        Me.scrlEnd.Location = New System.Drawing.Point(135, 16)
        Me.scrlEnd.Name = "scrlEnd"
        Me.scrlEnd.Size = New System.Drawing.Size(82, 13)
        Me.scrlEnd.TabIndex = 4
        '
        'lblLuck
        '
        Me.lblLuck.AutoSize = True
        Me.lblLuck.Location = New System.Drawing.Point(8, 68)
        Me.lblLuck.Name = "lblLuck"
        Me.lblLuck.Size = New System.Drawing.Size(43, 13)
        Me.lblLuck.TabIndex = 3
        Me.lblLuck.Text = "Luck: 0"
        '
        'scrlWill
        '
        Me.scrlWill.LargeChange = 1
        Me.scrlWill.Location = New System.Drawing.Point(11, 55)
        Me.scrlWill.Name = "scrlWill"
        Me.scrlWill.Size = New System.Drawing.Size(82, 13)
        Me.scrlWill.TabIndex = 2
        '
        'lblStr
        '
        Me.lblStr.AutoSize = True
        Me.lblStr.Location = New System.Drawing.Point(8, 29)
        Me.lblStr.Name = "lblStr"
        Me.lblStr.Size = New System.Drawing.Size(59, 13)
        Me.lblStr.TabIndex = 1
        Me.lblStr.Text = "Strenght: 0"
        '
        'scrlStr
        '
        Me.scrlStr.LargeChange = 1
        Me.scrlStr.Location = New System.Drawing.Point(11, 16)
        Me.scrlStr.Name = "scrlStr"
        Me.scrlStr.Size = New System.Drawing.Size(82, 13)
        Me.scrlStr.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(495, 480)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 25)
        Me.btnCancel.TabIndex = 40
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(370, 480)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 25)
        Me.btnDelete.TabIndex = 39
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(243, 480)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 25)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmEditor_NPC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 511)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_NPC"
        Me.Text = "Npc Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picSprite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picSprite As System.Windows.Forms.PictureBox
    Friend WithEvents scrlRange As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlSprite As System.Windows.Forms.HScrollBar
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents lblSprite As System.Windows.Forms.Label
    Friend WithEvents txtAttackSay As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFaction As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBehaviour As System.Windows.Forms.ComboBox
    Friend WithEvents txtEXP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents scrlAnimation As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAnimation As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStr As System.Windows.Forms.Label
    Friend WithEvents scrlStr As System.Windows.Forms.HScrollBar
    Friend WithEvents lblSpr As System.Windows.Forms.Label
    Friend WithEvents scrlSpr As System.Windows.Forms.HScrollBar
    Friend WithEvents lblVit As System.Windows.Forms.Label
    Friend WithEvents scrlVit As System.Windows.Forms.HScrollBar
    Friend WithEvents lblInt As System.Windows.Forms.Label
    Friend WithEvents scrlInt As System.Windows.Forms.HScrollBar
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents scrlEnd As System.Windows.Forms.HScrollBar
    Friend WithEvents lblLuck As System.Windows.Forms.Label
    Friend WithEvents scrlWill As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSpawnSecs As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtChance As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblNum As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents scrlValue As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlNum As System.Windows.Forms.HScrollBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents scrlQuest As Windows.Forms.HScrollBar
    Friend WithEvents lblQuest As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents cmbDropSlot As Windows.Forms.ComboBox
End Class
