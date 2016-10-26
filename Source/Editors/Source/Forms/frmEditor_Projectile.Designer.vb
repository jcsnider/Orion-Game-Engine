<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Projectile
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
        Me.scrlDamage = New System.Windows.Forms.HScrollBar()
        Me.lblDamage = New System.Windows.Forms.Label()
        Me.scrlSpeed = New System.Windows.Forms.HScrollBar()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.scrlRange = New System.Windows.Forms.HScrollBar()
        Me.lblRange = New System.Windows.Forms.Label()
        Me.scrlPic = New System.Windows.Forms.HScrollBar()
        Me.lblPic = New System.Windows.Forms.Label()
        Me.picProjectile = New System.Windows.Forms.PictureBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picProjectile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 387)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Projectile List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(6, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(233, 355)
        Me.lstIndex.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.scrlDamage)
        Me.GroupBox2.Controls.Add(Me.lblDamage)
        Me.GroupBox2.Controls.Add(Me.scrlSpeed)
        Me.GroupBox2.Controls.Add(Me.lblSpeed)
        Me.GroupBox2.Controls.Add(Me.scrlRange)
        Me.GroupBox2.Controls.Add(Me.lblRange)
        Me.GroupBox2.Controls.Add(Me.scrlPic)
        Me.GroupBox2.Controls.Add(Me.lblPic)
        Me.GroupBox2.Controls.Add(Me.picProjectile)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(263, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(245, 346)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Projectile Properties"
        '
        'scrlDamage
        '
        Me.scrlDamage.LargeChange = 1
        Me.scrlDamage.Location = New System.Drawing.Point(9, 218)
        Me.scrlDamage.Name = "scrlDamage"
        Me.scrlDamage.Size = New System.Drawing.Size(230, 17)
        Me.scrlDamage.TabIndex = 10
        '
        'lblDamage
        '
        Me.lblDamage.AutoSize = True
        Me.lblDamage.Location = New System.Drawing.Point(10, 202)
        Me.lblDamage.Name = "lblDamage"
        Me.lblDamage.Size = New System.Drawing.Size(108, 13)
        Me.lblDamage.TabIndex = 9
        Me.lblDamage.Text = "Additional Damage: 0"
        '
        'scrlSpeed
        '
        Me.scrlSpeed.LargeChange = 1
        Me.scrlSpeed.Location = New System.Drawing.Point(9, 176)
        Me.scrlSpeed.Name = "scrlSpeed"
        Me.scrlSpeed.Size = New System.Drawing.Size(230, 17)
        Me.scrlSpeed.TabIndex = 8
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Location = New System.Drawing.Point(10, 160)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(50, 13)
        Me.lblSpeed.TabIndex = 7
        Me.lblSpeed.Text = "Speed: 0"
        '
        'scrlRange
        '
        Me.scrlRange.LargeChange = 1
        Me.scrlRange.Location = New System.Drawing.Point(9, 139)
        Me.scrlRange.Name = "scrlRange"
        Me.scrlRange.Size = New System.Drawing.Size(230, 17)
        Me.scrlRange.TabIndex = 6
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Location = New System.Drawing.Point(10, 123)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(51, 13)
        Me.lblRange.TabIndex = 5
        Me.lblRange.Text = "Range: 0"
        '
        'scrlPic
        '
        Me.scrlPic.LargeChange = 1
        Me.scrlPic.Location = New System.Drawing.Point(9, 97)
        Me.scrlPic.Name = "scrlPic"
        Me.scrlPic.Size = New System.Drawing.Size(230, 17)
        Me.scrlPic.TabIndex = 4
        '
        'lblPic
        '
        Me.lblPic.AutoSize = True
        Me.lblPic.Location = New System.Drawing.Point(6, 81)
        Me.lblPic.Name = "lblPic"
        Me.lblPic.Size = New System.Drawing.Size(34, 13)
        Me.lblPic.TabIndex = 3
        Me.lblPic.Text = "Pic: 0"
        '
        'picProjectile
        '
        Me.picProjectile.BackColor = System.Drawing.Color.Black
        Me.picProjectile.Location = New System.Drawing.Point(102, 58)
        Me.picProjectile.Name = "picProjectile"
        Me.picProjectile.Size = New System.Drawing.Size(137, 36)
        Me.picProjectile.TabIndex = 2
        Me.picProjectile.TabStop = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(9, 32)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(230, 20)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(263, 376)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(433, 376)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditor_Projectile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 405)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Projectile"
        Me.Text = "Projectile Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picProjectile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents scrlPic As System.Windows.Forms.HScrollBar
    Friend WithEvents lblPic As System.Windows.Forms.Label
    Friend WithEvents picProjectile As System.Windows.Forms.PictureBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents scrlRange As System.Windows.Forms.HScrollBar
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents scrlDamage As System.Windows.Forms.HScrollBar
    Friend WithEvents lblDamage As System.Windows.Forms.Label
    Friend WithEvents scrlSpeed As System.Windows.Forms.HScrollBar
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
