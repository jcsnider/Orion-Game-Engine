<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.chkHighEnd = New System.Windows.Forms.CheckBox()
        Me.chkNpcBars = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSaveSettings.Location = New System.Drawing.Point(11, 205)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(205, 23)
        Me.btnSaveSettings.TabIndex = 14
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "ScreenSize"
        '
        'cmbScreenSize
        '
        Me.cmbScreenSize.FormattingEnabled = True
        Me.cmbScreenSize.Items.AddRange(New Object() {"800X600", "1024X768", "1152X864"})
        Me.cmbScreenSize.Location = New System.Drawing.Point(11, 116)
        Me.cmbScreenSize.Name = "cmbScreenSize"
        Me.cmbScreenSize.Size = New System.Drawing.Size(206, 21)
        Me.cmbScreenSize.TabIndex = 12
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.BackColor = System.Drawing.Color.Transparent
        Me.lblVolume.ForeColor = System.Drawing.Color.Black
        Me.lblVolume.Location = New System.Drawing.Point(12, 54)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(48, 13)
        Me.lblVolume.TabIndex = 11
        Me.lblVolume.Text = "Volume: "
        '
        'scrlVolume
        '
        Me.scrlVolume.LargeChange = 1
        Me.scrlVolume.Location = New System.Drawing.Point(12, 69)
        Me.scrlVolume.Name = "scrlVolume"
        Me.scrlVolume.Size = New System.Drawing.Size(205, 17)
        Me.scrlVolume.TabIndex = 10
        Me.scrlVolume.Value = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSOff)
        Me.GroupBox2.Controls.Add(Me.optSOn)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(118, 13)
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
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
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
        'chkHighEnd
        '
        Me.chkHighEnd.AutoSize = True
        Me.chkHighEnd.Location = New System.Drawing.Point(12, 143)
        Me.chkHighEnd.Name = "chkHighEnd"
        Me.chkHighEnd.Size = New System.Drawing.Size(90, 17)
        Me.chkHighEnd.TabIndex = 15
        Me.chkHighEnd.Text = "HighEnd PC?"
        Me.chkHighEnd.UseVisualStyleBackColor = True
        '
        'chkNpcBars
        '
        Me.chkNpcBars.AutoSize = True
        Me.chkNpcBars.Location = New System.Drawing.Point(11, 166)
        Me.chkNpcBars.Name = "chkNpcBars"
        Me.chkNpcBars.Size = New System.Drawing.Size(106, 17)
        Me.chkNpcBars.TabIndex = 16
        Me.chkNpcBars.Text = "Show Npc Bars?"
        Me.chkNpcBars.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 239)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkNpcBars)
        Me.Controls.Add(Me.chkHighEnd)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbScreenSize)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblVolume)
        Me.Controls.Add(Me.scrlVolume)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmOptions"
        Me.ShowInTaskbar = False
        Me.Text = "Game Options"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveSettings As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cmbScreenSize As Windows.Forms.ComboBox
    Friend WithEvents lblVolume As Windows.Forms.Label
    Friend WithEvents scrlVolume As Windows.Forms.HScrollBar
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents optSOff As Windows.Forms.RadioButton
    Friend WithEvents optSOn As Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents optMOff As Windows.Forms.RadioButton
    Friend WithEvents optMOn As Windows.Forms.RadioButton
    Friend WithEvents chkHighEnd As Windows.Forms.CheckBox
    Friend WithEvents chkNpcBars As Windows.Forms.CheckBox
End Class
