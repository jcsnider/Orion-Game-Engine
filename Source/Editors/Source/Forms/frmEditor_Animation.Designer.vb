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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picSprite1 = New System.Windows.Forms.PictureBox()
        Me.picSprite0 = New System.Windows.Forms.PictureBox()
        Me.scrlLoopTime1 = New System.Windows.Forms.HScrollBar()
        Me.lblLoopTime1 = New System.Windows.Forms.Label()
        Me.scrlFrameCount1 = New System.Windows.Forms.HScrollBar()
        Me.lblFrameCount1 = New System.Windows.Forms.Label()
        Me.scrlLoopCount1 = New System.Windows.Forms.HScrollBar()
        Me.lblLoopCount1 = New System.Windows.Forms.Label()
        Me.scrlLoopTime0 = New System.Windows.Forms.HScrollBar()
        Me.lblLoopTime0 = New System.Windows.Forms.Label()
        Me.scrlFrameCount0 = New System.Windows.Forms.HScrollBar()
        Me.lblFrameCount0 = New System.Windows.Forms.Label()
        Me.scrlLoopCount0 = New System.Windows.Forms.HScrollBar()
        Me.lblLoopCount0 = New System.Windows.Forms.Label()
        Me.scrlSprite1 = New System.Windows.Forms.HScrollBar()
        Me.lblSprite1 = New System.Windows.Forms.Label()
        Me.scrlSprite0 = New System.Windows.Forms.HScrollBar()
        Me.lblSprite0 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstIndex = New System.Windows.Forms.ListBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picSprite1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSprite0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(579, 421)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(490, 421)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(83, 25)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(401, 421)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 25)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picSprite1)
        Me.GroupBox2.Controls.Add(Me.picSprite0)
        Me.GroupBox2.Controls.Add(Me.scrlLoopTime1)
        Me.GroupBox2.Controls.Add(Me.lblLoopTime1)
        Me.GroupBox2.Controls.Add(Me.scrlFrameCount1)
        Me.GroupBox2.Controls.Add(Me.lblFrameCount1)
        Me.GroupBox2.Controls.Add(Me.scrlLoopCount1)
        Me.GroupBox2.Controls.Add(Me.lblLoopCount1)
        Me.GroupBox2.Controls.Add(Me.scrlLoopTime0)
        Me.GroupBox2.Controls.Add(Me.lblLoopTime0)
        Me.GroupBox2.Controls.Add(Me.scrlFrameCount0)
        Me.GroupBox2.Controls.Add(Me.lblFrameCount0)
        Me.GroupBox2.Controls.Add(Me.scrlLoopCount0)
        Me.GroupBox2.Controls.Add(Me.lblLoopCount0)
        Me.GroupBox2.Controls.Add(Me.scrlSprite1)
        Me.GroupBox2.Controls.Add(Me.lblSprite1)
        Me.GroupBox2.Controls.Add(Me.scrlSprite0)
        Me.GroupBox2.Controls.Add(Me.lblSprite0)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(201, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 412)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Animation Properties"
        '
        'picSprite1
        '
        Me.picSprite1.BackColor = System.Drawing.Color.Black
        Me.picSprite1.Location = New System.Drawing.Point(244, 232)
        Me.picSprite1.Name = "picSprite1"
        Me.picSprite1.Size = New System.Drawing.Size(205, 165)
        Me.picSprite1.TabIndex = 21
        Me.picSprite1.TabStop = False
        '
        'picSprite0
        '
        Me.picSprite0.BackColor = System.Drawing.Color.Black
        Me.picSprite0.Location = New System.Drawing.Point(15, 232)
        Me.picSprite0.Name = "picSprite0"
        Me.picSprite0.Size = New System.Drawing.Size(205, 165)
        Me.picSprite0.TabIndex = 20
        Me.picSprite0.TabStop = False
        '
        'scrlLoopTime1
        '
        Me.scrlLoopTime1.LargeChange = 1
        Me.scrlLoopTime1.Location = New System.Drawing.Point(244, 208)
        Me.scrlLoopTime1.Name = "scrlLoopTime1"
        Me.scrlLoopTime1.Size = New System.Drawing.Size(150, 17)
        Me.scrlLoopTime1.TabIndex = 19
        '
        'lblLoopTime1
        '
        Me.lblLoopTime1.AutoSize = True
        Me.lblLoopTime1.Location = New System.Drawing.Point(241, 195)
        Me.lblLoopTime1.Name = "lblLoopTime1"
        Me.lblLoopTime1.Size = New System.Drawing.Size(69, 13)
        Me.lblLoopTime1.TabIndex = 18
        Me.lblLoopTime1.Text = "Loop Time: 0"
        '
        'scrlFrameCount1
        '
        Me.scrlFrameCount1.LargeChange = 1
        Me.scrlFrameCount1.Location = New System.Drawing.Point(244, 171)
        Me.scrlFrameCount1.Name = "scrlFrameCount1"
        Me.scrlFrameCount1.Size = New System.Drawing.Size(150, 17)
        Me.scrlFrameCount1.TabIndex = 17
        '
        'lblFrameCount1
        '
        Me.lblFrameCount1.AutoSize = True
        Me.lblFrameCount1.Location = New System.Drawing.Point(241, 158)
        Me.lblFrameCount1.Name = "lblFrameCount1"
        Me.lblFrameCount1.Size = New System.Drawing.Size(79, 13)
        Me.lblFrameCount1.TabIndex = 16
        Me.lblFrameCount1.Text = "Frame Count: 0"
        '
        'scrlLoopCount1
        '
        Me.scrlLoopCount1.LargeChange = 1
        Me.scrlLoopCount1.Location = New System.Drawing.Point(244, 135)
        Me.scrlLoopCount1.Name = "scrlLoopCount1"
        Me.scrlLoopCount1.Size = New System.Drawing.Size(150, 17)
        Me.scrlLoopCount1.TabIndex = 15
        '
        'lblLoopCount1
        '
        Me.lblLoopCount1.AutoSize = True
        Me.lblLoopCount1.Location = New System.Drawing.Point(241, 122)
        Me.lblLoopCount1.Name = "lblLoopCount1"
        Me.lblLoopCount1.Size = New System.Drawing.Size(74, 13)
        Me.lblLoopCount1.TabIndex = 14
        Me.lblLoopCount1.Text = "Loop Count: 0"
        '
        'scrlLoopTime0
        '
        Me.scrlLoopTime0.LargeChange = 1
        Me.scrlLoopTime0.Location = New System.Drawing.Point(16, 208)
        Me.scrlLoopTime0.Name = "scrlLoopTime0"
        Me.scrlLoopTime0.Size = New System.Drawing.Size(150, 17)
        Me.scrlLoopTime0.TabIndex = 13
        '
        'lblLoopTime0
        '
        Me.lblLoopTime0.AutoSize = True
        Me.lblLoopTime0.Location = New System.Drawing.Point(13, 195)
        Me.lblLoopTime0.Name = "lblLoopTime0"
        Me.lblLoopTime0.Size = New System.Drawing.Size(69, 13)
        Me.lblLoopTime0.TabIndex = 12
        Me.lblLoopTime0.Text = "Loop Time: 0"
        '
        'scrlFrameCount0
        '
        Me.scrlFrameCount0.LargeChange = 1
        Me.scrlFrameCount0.Location = New System.Drawing.Point(16, 171)
        Me.scrlFrameCount0.Name = "scrlFrameCount0"
        Me.scrlFrameCount0.Size = New System.Drawing.Size(150, 17)
        Me.scrlFrameCount0.TabIndex = 11
        '
        'lblFrameCount0
        '
        Me.lblFrameCount0.AutoSize = True
        Me.lblFrameCount0.Location = New System.Drawing.Point(13, 158)
        Me.lblFrameCount0.Name = "lblFrameCount0"
        Me.lblFrameCount0.Size = New System.Drawing.Size(79, 13)
        Me.lblFrameCount0.TabIndex = 10
        Me.lblFrameCount0.Text = "Frame Count: 0"
        '
        'scrlLoopCount0
        '
        Me.scrlLoopCount0.LargeChange = 1
        Me.scrlLoopCount0.Location = New System.Drawing.Point(16, 135)
        Me.scrlLoopCount0.Name = "scrlLoopCount0"
        Me.scrlLoopCount0.Size = New System.Drawing.Size(150, 17)
        Me.scrlLoopCount0.TabIndex = 9
        '
        'lblLoopCount0
        '
        Me.lblLoopCount0.AutoSize = True
        Me.lblLoopCount0.Location = New System.Drawing.Point(13, 122)
        Me.lblLoopCount0.Name = "lblLoopCount0"
        Me.lblLoopCount0.Size = New System.Drawing.Size(74, 13)
        Me.lblLoopCount0.TabIndex = 8
        Me.lblLoopCount0.Text = "Loop Count: 0"
        '
        'scrlSprite1
        '
        Me.scrlSprite1.LargeChange = 1
        Me.scrlSprite1.Location = New System.Drawing.Point(244, 99)
        Me.scrlSprite1.Name = "scrlSprite1"
        Me.scrlSprite1.Size = New System.Drawing.Size(150, 17)
        Me.scrlSprite1.TabIndex = 7
        '
        'lblSprite1
        '
        Me.lblSprite1.AutoSize = True
        Me.lblSprite1.Location = New System.Drawing.Point(241, 86)
        Me.lblSprite1.Name = "lblSprite1"
        Me.lblSprite1.Size = New System.Drawing.Size(46, 13)
        Me.lblSprite1.TabIndex = 6
        Me.lblSprite1.Text = "Sprite: 0"
        '
        'scrlSprite0
        '
        Me.scrlSprite0.LargeChange = 1
        Me.scrlSprite0.Location = New System.Drawing.Point(16, 99)
        Me.scrlSprite0.Name = "scrlSprite0"
        Me.scrlSprite0.Size = New System.Drawing.Size(150, 17)
        Me.scrlSprite0.TabIndex = 5
        '
        'lblSprite0
        '
        Me.lblSprite0.AutoSize = True
        Me.lblSprite0.Location = New System.Drawing.Point(13, 86)
        Me.lblSprite0.Name = "lblSprite0"
        Me.lblSprite0.Size = New System.Drawing.Size(46, 13)
        Me.lblSprite0.TabIndex = 4
        Me.lblSprite0.Text = "Sprite: 0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Layer: 1 (Above Player)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Layer: 0 (Below Player)"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(60, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(167, 20)
        Me.txtName.TabIndex = 1
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 412)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Animation List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(7, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(180, 381)
        Me.lstIndex.TabIndex = 1
        '
        'frmEditor_Animation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 452)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Animation"
        Me.Text = "frmEditor_Animation"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picSprite1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSprite0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents picSprite1 As PictureBox
    Friend WithEvents picSprite0 As PictureBox
    Friend WithEvents scrlLoopTime1 As HScrollBar
    Friend WithEvents lblLoopTime1 As Label
    Friend WithEvents scrlFrameCount1 As HScrollBar
    Friend WithEvents lblFrameCount1 As Label
    Friend WithEvents scrlLoopCount1 As HScrollBar
    Friend WithEvents lblLoopCount1 As Label
    Friend WithEvents scrlLoopTime0 As HScrollBar
    Friend WithEvents lblLoopTime0 As Label
    Friend WithEvents scrlFrameCount0 As HScrollBar
    Friend WithEvents lblFrameCount0 As Label
    Friend WithEvents scrlLoopCount0 As HScrollBar
    Friend WithEvents lblLoopCount0 As Label
    Friend WithEvents scrlSprite1 As HScrollBar
    Friend WithEvents lblSprite1 As Label
    Friend WithEvents scrlSprite0 As HScrollBar
    Friend WithEvents lblSprite0 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstIndex As ListBox
End Class
