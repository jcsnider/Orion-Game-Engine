<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Lights
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
        Me.lstIndex = New System.Windows.Forms.ListView()
        Me.DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
        Me.DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        Me.DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        Me.cmbType = New DarkUI.Controls.DarkComboBox()
        Me.DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        Me.scrlAlpha = New DarkUI.Controls.DarkScrollBar()
        Me.lblAlpha = New DarkUI.Controls.DarkLabel()
        Me.scrlBlue = New DarkUI.Controls.DarkScrollBar()
        Me.lblBlue = New DarkUI.Controls.DarkLabel()
        Me.ScrlGreen = New DarkUI.Controls.DarkScrollBar()
        Me.lblGreen = New DarkUI.Controls.DarkLabel()
        Me.scrlRed = New DarkUI.Controls.DarkScrollBar()
        Me.lblRed = New DarkUI.Controls.DarkLabel()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.txtName = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.btnSave = New DarkUI.Controls.DarkButton()
        Me.btnCancel = New DarkUI.Controls.DarkButton()
        Me.DarkGroupBox1.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        Me.DarkGroupBox4.SuspendLayout()
        Me.DarkGroupBox3.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstIndex
        '
        Me.lstIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIndex.Location = New System.Drawing.Point(6, 19)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(188, 296)
        Me.lstIndex.TabIndex = 0
        Me.lstIndex.UseCompatibleStateImageBehavior = False
        '
        'DarkGroupBox1
        '
        Me.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox1.Controls.Add(Me.lstIndex)
        Me.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.DarkGroupBox1.Name = "DarkGroupBox1"
        Me.DarkGroupBox1.Size = New System.Drawing.Size(200, 321)
        Me.DarkGroupBox1.TabIndex = 1
        Me.DarkGroupBox1.TabStop = False
        Me.DarkGroupBox1.Text = "Lights List"
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox4)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox3)
        Me.DarkGroupBox2.Controls.Add(Me.picPreview)
        Me.DarkGroupBox2.Controls.Add(Me.txtName)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel1)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(208, 2)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Size = New System.Drawing.Size(378, 292)
        Me.DarkGroupBox2.TabIndex = 2
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "Settings"
        '
        'DarkGroupBox4
        '
        Me.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox4.Controls.Add(Me.cmbType)
        Me.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox4.Location = New System.Drawing.Point(254, 209)
        Me.DarkGroupBox4.Name = "DarkGroupBox4"
        Me.DarkGroupBox4.Size = New System.Drawing.Size(118, 77)
        Me.DarkGroupBox4.TabIndex = 4
        Me.DarkGroupBox4.TabStop = False
        Me.DarkGroupBox4.Text = "Light Type"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.cmbType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Normal", "Flickering", "Pulsating"})
        Me.cmbType.Location = New System.Drawing.Point(6, 19)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(106, 21)
        Me.cmbType.TabIndex = 0
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.scrlAlpha)
        Me.DarkGroupBox3.Controls.Add(Me.lblAlpha)
        Me.DarkGroupBox3.Controls.Add(Me.scrlBlue)
        Me.DarkGroupBox3.Controls.Add(Me.lblBlue)
        Me.DarkGroupBox3.Controls.Add(Me.ScrlGreen)
        Me.DarkGroupBox3.Controls.Add(Me.lblGreen)
        Me.DarkGroupBox3.Controls.Add(Me.scrlRed)
        Me.DarkGroupBox3.Controls.Add(Me.lblRed)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(254, 43)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Size = New System.Drawing.Size(118, 160)
        Me.DarkGroupBox3.TabIndex = 3
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Color Settings"
        '
        'scrlAlpha
        '
        Me.scrlAlpha.Location = New System.Drawing.Point(6, 140)
        Me.scrlAlpha.Maximum = 255
        Me.scrlAlpha.Name = "scrlAlpha"
        Me.scrlAlpha.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlAlpha.Size = New System.Drawing.Size(106, 17)
        Me.scrlAlpha.TabIndex = 9
        Me.scrlAlpha.Text = "DarkScrollBar4"
        '
        'lblAlpha
        '
        Me.lblAlpha.AutoSize = True
        Me.lblAlpha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblAlpha.Location = New System.Drawing.Point(6, 124)
        Me.lblAlpha.Name = "lblAlpha"
        Me.lblAlpha.Size = New System.Drawing.Size(43, 13)
        Me.lblAlpha.TabIndex = 8
        Me.lblAlpha.Text = "Alpha:0"
        '
        'scrlBlue
        '
        Me.scrlBlue.Location = New System.Drawing.Point(6, 104)
        Me.scrlBlue.Maximum = 255
        Me.scrlBlue.Name = "scrlBlue"
        Me.scrlBlue.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlBlue.Size = New System.Drawing.Size(106, 17)
        Me.scrlBlue.TabIndex = 7
        Me.scrlBlue.Text = "DarkScrollBar3"
        '
        'lblBlue
        '
        Me.lblBlue.AutoSize = True
        Me.lblBlue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblBlue.Location = New System.Drawing.Point(6, 88)
        Me.lblBlue.Name = "lblBlue"
        Me.lblBlue.Size = New System.Drawing.Size(37, 13)
        Me.lblBlue.TabIndex = 6
        Me.lblBlue.Text = "Blue:0"
        '
        'ScrlGreen
        '
        Me.ScrlGreen.Location = New System.Drawing.Point(6, 68)
        Me.ScrlGreen.Maximum = 255
        Me.ScrlGreen.Name = "ScrlGreen"
        Me.ScrlGreen.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.ScrlGreen.Size = New System.Drawing.Size(106, 17)
        Me.ScrlGreen.TabIndex = 5
        Me.ScrlGreen.Text = "DarkScrollBar2"
        '
        'lblGreen
        '
        Me.lblGreen.AutoSize = True
        Me.lblGreen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblGreen.Location = New System.Drawing.Point(6, 52)
        Me.lblGreen.Name = "lblGreen"
        Me.lblGreen.Size = New System.Drawing.Size(45, 13)
        Me.lblGreen.TabIndex = 4
        Me.lblGreen.Text = "Green:0"
        '
        'scrlRed
        '
        Me.scrlRed.Location = New System.Drawing.Point(6, 32)
        Me.scrlRed.Maximum = 255
        Me.scrlRed.Name = "scrlRed"
        Me.scrlRed.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal
        Me.scrlRed.Size = New System.Drawing.Size(106, 17)
        Me.scrlRed.TabIndex = 3
        Me.scrlRed.Text = "DarkScrollBar1"
        '
        'lblRed
        '
        Me.lblRed.AutoSize = True
        Me.lblRed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblRed.Location = New System.Drawing.Point(6, 16)
        Me.lblRed.Name = "lblRed"
        Me.lblRed.Size = New System.Drawing.Size(36, 13)
        Me.lblRed.TabIndex = 0
        Me.lblRed.Text = "Red:0"
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.DarkGray
        Me.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picPreview.Location = New System.Drawing.Point(6, 43)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(242, 242)
        Me.picPreview.TabIndex = 2
        Me.picPreview.TabStop = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(50, 17)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(322, 20)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(6, 19)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(38, 13)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Name:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(511, 300)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(429, 300)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'frmEditor_Lights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(591, 325)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DarkGroupBox2)
        Me.Controls.Add(Me.DarkGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Lights"
        Me.Text = "Lights Editor"
        Me.DarkGroupBox1.ResumeLayout(False)
        Me.DarkGroupBox2.ResumeLayout(False)
        Me.DarkGroupBox2.PerformLayout()
        Me.DarkGroupBox4.ResumeLayout(False)
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstIndex As ListView
    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents scrlAlpha As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblAlpha As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlBlue As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblBlue As DarkUI.Controls.DarkLabel
    Friend WithEvents ScrlGreen As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblGreen As DarkUI.Controls.DarkLabel
    Friend WithEvents scrlRed As DarkUI.Controls.DarkScrollBar
    Friend WithEvents lblRed As DarkUI.Controls.DarkLabel
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbType As DarkUI.Controls.DarkComboBox
End Class
