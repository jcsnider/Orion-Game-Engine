<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditor_Animation
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
        Me.DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        Me.DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        Me.scrlLoopTime1 = New DarkUI.Controls.DarkScrollBar()
        Me.lblLoopTime1 = New DarkUI.Controls.DarkLabel()
        Me.scrlFrameCount1 = New DarkUI.Controls.DarkScrollBar()
        Me.lblFrameCount1 = New DarkUI.Controls.DarkLabel()
        Me.scrlLoopCount1 = New DarkUI.Controls.DarkScrollBar()
        Me.lblLoopCount1 = New DarkUI.Controls.DarkLabel()
        Me.scrlSprite1 = New DarkUI.Controls.DarkScrollBar()
        Me.lblSprite1 = New DarkUI.Controls.DarkLabel()
        Me.picSprite1 = New System.Windows.Forms.PictureBox()
        Me.DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        Me.scrlLoopTime0 = New DarkUI.Controls.DarkScrollBar()
        Me.lblLoopTime0 = New DarkUI.Controls.DarkLabel()
        Me.scrlFrameCount0 = New DarkUI.Controls.DarkScrollBar()
        Me.lblFrameCount0 = New DarkUI.Controls.DarkLabel()
        Me.scrlLoopCount0 = New DarkUI.Controls.DarkScrollBar()
        Me.lblLoopCount0 = New DarkUI.Controls.DarkLabel()
        Me.scrlSprite0 = New DarkUI.Controls.DarkScrollBar()
        Me.lblSprite0 = New DarkUI.Controls.DarkLabel()
        Me.picSprite0 = New System.Windows.Forms.PictureBox()
        Me.txtName = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.btnSave = New DarkUI.Controls.DarkButton()
        Me.btnDelete = New DarkUI.Controls.DarkButton()
        Me.btnCancel = New DarkUI.Controls.DarkButton()
        Me.DarkGroupBox1.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        Me.DarkGroupBox4.SuspendLayout()
        CType(Me.picSprite1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkGroupBox3.SuspendLayout()
        CType(Me.picSprite0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DarkGroupBox1
        '
        Me.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox1.Controls.Add(Me.lstIndex)
        Me.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.DarkGroupBox1.Name = "DarkGroupBox1"
        Me.DarkGroupBox1.Size = New System.Drawing.Size(200, 436)
        Me.DarkGroupBox1.TabIndex = 0
        Me.DarkGroupBox1.TabStop = False
        Me.DarkGroupBox1.Text = "Animations List"
        '
        'lstIndex
        '
        Me.lstIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(6, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(188, 403)
        Me.lstIndex.TabIndex = 0
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox4)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox3)
        Me.DarkGroupBox2.Controls.Add(Me.txtName)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel1)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(208, 3)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Size = New System.Drawing.Size(494, 436)
        Me.DarkGroupBox2.TabIndex = 1
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "Animation Properties"
        '
        'DarkGroupBox4
        '
        Me.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox4.Controls.Add(Me.scrlLoopTime1)
        Me.DarkGroupBox4.Controls.Add(Me.lblLoopTime1)
        Me.DarkGroupBox4.Controls.Add(Me.scrlFrameCount1)
        Me.DarkGroupBox4.Controls.Add(Me.lblFrameCount1)
        Me.DarkGroupBox4.Controls.Add(Me.scrlLoopCount1)
        Me.DarkGroupBox4.Controls.Add(Me.lblLoopCount1)
        Me.DarkGroupBox4.Controls.Add(Me.scrlSprite1)
        Me.DarkGroupBox4.Controls.Add(Me.lblSprite1)
        Me.DarkGroupBox4.Controls.Add(Me.picSprite1)
        Me.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox4.Location = New System.Drawing.Point(6, 249)
        Me.DarkGroupBox4.Name = "DarkGroupBox4"
        Me.DarkGroupBox4.Size = New System.Drawing.Size(482, 180)
        Me.DarkGroupBox4.TabIndex = 23
        Me.DarkGroupBox4.TabStop = False
        Me.DarkGroupBox4.Text = "Layer 1 -Above Player"
        '
        'scrlLoopTime1
        '
        Me.scrlLoopTime1.Location = New System.Drawing.Point(111, 140)
        Me.scrlLoopTime1.Name = "scrlLoopTime1"
        Me.scrlLoopTime1.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlLoopTime1.Size = New System.Drawing.Size(154, 16)
        Me.scrlLoopTime1.TabIndex = 29
        Me.scrlLoopTime1.Text = "DarkScrollBar4"
        '
        'lblLoopTime1
        '
        Me.lblLoopTime1.AutoSize = True
        Me.lblLoopTime1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblLoopTime1.Location = New System.Drawing.Point(10, 140)
        Me.lblLoopTime1.Name = "lblLoopTime1"
        Me.lblLoopTime1.Size = New System.Drawing.Size(69, 13)
        Me.lblLoopTime1.TabIndex = 28
        Me.lblLoopTime1.Text = "Loop Time: 0"
        '
        'scrlFrameCount1
        '
        Me.scrlFrameCount1.Location = New System.Drawing.Point(111, 101)
        Me.scrlFrameCount1.Name = "scrlFrameCount1"
        Me.scrlFrameCount1.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlFrameCount1.Size = New System.Drawing.Size(155, 16)
        Me.scrlFrameCount1.TabIndex = 27
        Me.scrlFrameCount1.Text = "DarkScrollBar3"
        '
        'lblFrameCount1
        '
        Me.lblFrameCount1.AutoSize = True
        Me.lblFrameCount1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblFrameCount1.Location = New System.Drawing.Point(11, 101)
        Me.lblFrameCount1.Name = "lblFrameCount1"
        Me.lblFrameCount1.Size = New System.Drawing.Size(79, 13)
        Me.lblFrameCount1.TabIndex = 26
        Me.lblFrameCount1.Text = "Frame Count: 0"
        '
        'scrlLoopCount1
        '
        Me.scrlLoopCount1.Location = New System.Drawing.Point(111, 63)
        Me.scrlLoopCount1.Name = "scrlLoopCount1"
        Me.scrlLoopCount1.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlLoopCount1.Size = New System.Drawing.Size(155, 16)
        Me.scrlLoopCount1.TabIndex = 25
        Me.scrlLoopCount1.Text = "DarkScrollBar2"
        '
        'lblLoopCount1
        '
        Me.lblLoopCount1.AutoSize = True
        Me.lblLoopCount1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblLoopCount1.Location = New System.Drawing.Point(11, 63)
        Me.lblLoopCount1.Name = "lblLoopCount1"
        Me.lblLoopCount1.Size = New System.Drawing.Size(74, 13)
        Me.lblLoopCount1.TabIndex = 24
        Me.lblLoopCount1.Text = "Loop Count: 0"
        '
        'scrlSprite1
        '
        Me.scrlSprite1.Location = New System.Drawing.Point(111, 26)
        Me.scrlSprite1.Name = "scrlSprite1"
        Me.scrlSprite1.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlSprite1.Size = New System.Drawing.Size(154, 16)
        Me.scrlSprite1.TabIndex = 23
        Me.scrlSprite1.Text = "DarkScrollBar1"
        '
        'lblSprite1
        '
        Me.lblSprite1.AutoSize = True
        Me.lblSprite1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblSprite1.Location = New System.Drawing.Point(10, 26)
        Me.lblSprite1.Name = "lblSprite1"
        Me.lblSprite1.Size = New System.Drawing.Size(46, 13)
        Me.lblSprite1.TabIndex = 22
        Me.lblSprite1.Text = "Sprite: 0"
        '
        'picSprite1
        '
        Me.picSprite1.BackColor = System.Drawing.Color.Black
        Me.picSprite1.Location = New System.Drawing.Point(271, 10)
        Me.picSprite1.Name = "picSprite1"
        Me.picSprite1.Size = New System.Drawing.Size(205, 165)
        Me.picSprite1.TabIndex = 21
        Me.picSprite1.TabStop = False
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.scrlLoopTime0)
        Me.DarkGroupBox3.Controls.Add(Me.lblLoopTime0)
        Me.DarkGroupBox3.Controls.Add(Me.scrlFrameCount0)
        Me.DarkGroupBox3.Controls.Add(Me.lblFrameCount0)
        Me.DarkGroupBox3.Controls.Add(Me.scrlLoopCount0)
        Me.DarkGroupBox3.Controls.Add(Me.lblLoopCount0)
        Me.DarkGroupBox3.Controls.Add(Me.scrlSprite0)
        Me.DarkGroupBox3.Controls.Add(Me.lblSprite0)
        Me.DarkGroupBox3.Controls.Add(Me.picSprite0)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(6, 63)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Size = New System.Drawing.Size(482, 180)
        Me.DarkGroupBox3.TabIndex = 22
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Layer 0 - Beneath Player"
        '
        'scrlLoopTime0
        '
        Me.scrlLoopTime0.Location = New System.Drawing.Point(111, 140)
        Me.scrlLoopTime0.Name = "scrlLoopTime0"
        Me.scrlLoopTime0.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlLoopTime0.Size = New System.Drawing.Size(154, 16)
        Me.scrlLoopTime0.TabIndex = 29
        Me.scrlLoopTime0.Text = "DarkScrollBar4"
        '
        'lblLoopTime0
        '
        Me.lblLoopTime0.AutoSize = True
        Me.lblLoopTime0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblLoopTime0.Location = New System.Drawing.Point(10, 140)
        Me.lblLoopTime0.Name = "lblLoopTime0"
        Me.lblLoopTime0.Size = New System.Drawing.Size(69, 13)
        Me.lblLoopTime0.TabIndex = 28
        Me.lblLoopTime0.Text = "Loop Time: 0"
        '
        'scrlFrameCount0
        '
        Me.scrlFrameCount0.Location = New System.Drawing.Point(111, 101)
        Me.scrlFrameCount0.Name = "scrlFrameCount0"
        Me.scrlFrameCount0.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlFrameCount0.Size = New System.Drawing.Size(155, 16)
        Me.scrlFrameCount0.TabIndex = 27
        Me.scrlFrameCount0.Text = "DarkScrollBar3"
        '
        'lblFrameCount0
        '
        Me.lblFrameCount0.AutoSize = True
        Me.lblFrameCount0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblFrameCount0.Location = New System.Drawing.Point(11, 101)
        Me.lblFrameCount0.Name = "lblFrameCount0"
        Me.lblFrameCount0.Size = New System.Drawing.Size(79, 13)
        Me.lblFrameCount0.TabIndex = 26
        Me.lblFrameCount0.Text = "Frame Count: 0"
        '
        'scrlLoopCount0
        '
        Me.scrlLoopCount0.Location = New System.Drawing.Point(111, 63)
        Me.scrlLoopCount0.Name = "scrlLoopCount0"
        Me.scrlLoopCount0.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlLoopCount0.Size = New System.Drawing.Size(155, 16)
        Me.scrlLoopCount0.TabIndex = 25
        Me.scrlLoopCount0.Text = "DarkScrollBar2"
        '
        'lblLoopCount0
        '
        Me.lblLoopCount0.AutoSize = True
        Me.lblLoopCount0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblLoopCount0.Location = New System.Drawing.Point(11, 63)
        Me.lblLoopCount0.Name = "lblLoopCount0"
        Me.lblLoopCount0.Size = New System.Drawing.Size(74, 13)
        Me.lblLoopCount0.TabIndex = 24
        Me.lblLoopCount0.Text = "Loop Count: 0"
        '
        'scrlSprite0
        '
        Me.scrlSprite0.Location = New System.Drawing.Point(111, 26)
        Me.scrlSprite0.Name = "scrlSprite0"
        Me.scrlSprite0.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlSprite0.Size = New System.Drawing.Size(154, 16)
        Me.scrlSprite0.TabIndex = 23
        Me.scrlSprite0.Text = "DarkScrollBar1"
        '
        'lblSprite0
        '
        Me.lblSprite0.AutoSize = True
        Me.lblSprite0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblSprite0.Location = New System.Drawing.Point(10, 26)
        Me.lblSprite0.Name = "lblSprite0"
        Me.lblSprite0.Size = New System.Drawing.Size(46, 13)
        Me.lblSprite0.TabIndex = 22
        Me.lblSprite0.Text = "Sprite: 0"
        '
        'picSprite0
        '
        Me.picSprite0.BackColor = System.Drawing.Color.Black
        Me.picSprite0.Location = New System.Drawing.Point(271, 10)
        Me.picSprite0.Name = "picSprite0"
        Me.picSprite0.Size = New System.Drawing.Size(205, 165)
        Me.picSprite0.TabIndex = 21
        Me.picSprite0.TabStop = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(117, 28)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(371, 20)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(16, 30)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(87, 13)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Animation Name:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(470, 445)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(2, 445)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5)
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(627, 445)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'FrmEditor_Animation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(708, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DarkGroupBox2)
        Me.Controls.Add(Me.DarkGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmEditor_Animation"
        Me.Text = "Animation Editor"
        Me.DarkGroupBox1.ResumeLayout(False)
        Me.DarkGroupBox2.ResumeLayout(False)
        Me.DarkGroupBox2.PerformLayout()
        Me.DarkGroupBox4.ResumeLayout(False)
        Me.DarkGroupBox4.PerformLayout()
        CType(Me.picSprite1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        CType(Me.picSprite0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As ListBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents picSprite0 As PictureBox
    Friend WithEvents scrlLoopCount0 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblLoopCount0 As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlSprite0 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblSprite0 As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlLoopTime0 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblLoopTime0 As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlFrameCount0 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblFrameCount0 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents scrlLoopTime1 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblLoopTime1 As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlFrameCount1 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblFrameCount1 As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlLoopCount1 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblLoopCount1 As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlSprite1 As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblSprite1 As DarkUI.Controls.DarkLabel
    Friend WithEvents picSprite1 As PictureBox
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
End Class
