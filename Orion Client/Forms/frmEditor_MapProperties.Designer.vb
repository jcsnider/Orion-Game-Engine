<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_MapProperties
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstMusic = New System.Windows.Forms.ListBox()
        Me.fraMaxSizes = New System.Windows.Forms.GroupBox()
        Me.txtMaxY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraBootSettings = New System.Windows.Forms.GroupBox()
        Me.txtBootMap = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBootY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBootX = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fraMapLinks = New System.Windows.Forms.GroupBox()
        Me.txtDown = New System.Windows.Forms.TextBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.lblMap = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.txtUp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.fraMapSettings = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMoral = New System.Windows.Forms.ComboBox()
        Me.fraNpcs = New System.Windows.Forms.GroupBox()
        Me.ComboBox23 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.fraMaxSizes.SuspendLayout()
        Me.fraBootSettings.SuspendLayout()
        Me.fraMapLinks.SuspendLayout()
        Me.fraMapSettings.SuspendLayout()
        Me.fraNpcs.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(6, 469)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(82, 469)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Annuler"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstMusic)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 321)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 136)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Musique"
        '
        'lstMusic
        '
        Me.lstMusic.FormattingEnabled = True
        Me.lstMusic.Location = New System.Drawing.Point(6, 19)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.ScrollAlwaysVisible = True
        Me.lstMusic.Size = New System.Drawing.Size(139, 108)
        Me.lstMusic.TabIndex = 3
        '
        'fraMaxSizes
        '
        Me.fraMaxSizes.Controls.Add(Me.txtMaxY)
        Me.fraMaxSizes.Controls.Add(Me.Label2)
        Me.fraMaxSizes.Controls.Add(Me.txtMaxX)
        Me.fraMaxSizes.Controls.Add(Me.Label1)
        Me.fraMaxSizes.Location = New System.Drawing.Point(11, 237)
        Me.fraMaxSizes.Name = "fraMaxSizes"
        Me.fraMaxSizes.Size = New System.Drawing.Size(149, 75)
        Me.fraMaxSizes.TabIndex = 4
        Me.fraMaxSizes.TabStop = False
        Me.fraMaxSizes.Text = "Map Sizes"
        '
        'txtMaxY
        '
        Me.txtMaxY.Location = New System.Drawing.Point(56, 42)
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.Size = New System.Drawing.Size(50, 20)
        Me.txtMaxY.TabIndex = 3
        Me.txtMaxY.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Max Y:"
        '
        'txtMaxX
        '
        Me.txtMaxX.Location = New System.Drawing.Point(56, 16)
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.Size = New System.Drawing.Size(50, 20)
        Me.txtMaxX.TabIndex = 1
        Me.txtMaxX.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Max X:"
        '
        'fraBootSettings
        '
        Me.fraBootSettings.Controls.Add(Me.txtBootMap)
        Me.fraBootSettings.Controls.Add(Me.Label5)
        Me.fraBootSettings.Controls.Add(Me.txtBootY)
        Me.fraBootSettings.Controls.Add(Me.Label3)
        Me.fraBootSettings.Controls.Add(Me.txtBootX)
        Me.fraBootSettings.Controls.Add(Me.Label4)
        Me.fraBootSettings.Location = New System.Drawing.Point(12, 133)
        Me.fraBootSettings.Name = "fraBootSettings"
        Me.fraBootSettings.Size = New System.Drawing.Size(149, 98)
        Me.fraBootSettings.TabIndex = 5
        Me.fraBootSettings.TabStop = False
        Me.fraBootSettings.Text = "Boot Settings"
        '
        'txtBootMap
        '
        Me.txtBootMap.Location = New System.Drawing.Point(89, 13)
        Me.txtBootMap.Name = "txtBootMap"
        Me.txtBootMap.Size = New System.Drawing.Size(50, 20)
        Me.txtBootMap.TabIndex = 5
        Me.txtBootMap.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Boot Map:"
        '
        'txtBootY
        '
        Me.txtBootY.Location = New System.Drawing.Point(89, 72)
        Me.txtBootY.Name = "txtBootY"
        Me.txtBootY.Size = New System.Drawing.Size(50, 20)
        Me.txtBootY.TabIndex = 3
        Me.txtBootY.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Boot Y:"
        '
        'txtBootX
        '
        Me.txtBootX.Location = New System.Drawing.Point(89, 46)
        Me.txtBootX.Name = "txtBootX"
        Me.txtBootX.Size = New System.Drawing.Size(50, 20)
        Me.txtBootX.TabIndex = 1
        Me.txtBootX.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Boot X:"
        '
        'fraMapLinks
        '
        Me.fraMapLinks.Controls.Add(Me.txtDown)
        Me.fraMapLinks.Controls.Add(Me.txtLeft)
        Me.fraMapLinks.Controls.Add(Me.lblMap)
        Me.fraMapLinks.Controls.Add(Me.txtRight)
        Me.fraMapLinks.Controls.Add(Me.txtUp)
        Me.fraMapLinks.Location = New System.Drawing.Point(12, 43)
        Me.fraMapLinks.Name = "fraMapLinks"
        Me.fraMapLinks.Size = New System.Drawing.Size(149, 84)
        Me.fraMapLinks.TabIndex = 6
        Me.fraMapLinks.TabStop = False
        Me.fraMapLinks.Text = "Liens de la carte"
        '
        'txtDown
        '
        Me.txtDown.Location = New System.Drawing.Point(43, 58)
        Me.txtDown.Name = "txtDown"
        Me.txtDown.Size = New System.Drawing.Size(50, 20)
        Me.txtDown.TabIndex = 6
        Me.txtDown.Text = "0"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(6, 46)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(43, 20)
        Me.txtLeft.TabIndex = 5
        Me.txtLeft.Text = "0"
        '
        'lblMap
        '
        Me.lblMap.AutoSize = True
        Me.lblMap.Location = New System.Drawing.Point(6, 16)
        Me.lblMap.Name = "lblMap"
        Me.lblMap.Size = New System.Drawing.Size(84, 13)
        Me.lblMap.TabIndex = 4
        Me.lblMap.Text = "Carte actuelle: 0"
        '
        'txtRight
        '
        Me.txtRight.Location = New System.Drawing.Point(93, 46)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(50, 20)
        Me.txtRight.TabIndex = 3
        Me.txtRight.Text = "0"
        '
        'txtUp
        '
        Me.txtUp.Location = New System.Drawing.Point(43, 32)
        Me.txtUp.Name = "txtUp"
        Me.txtUp.Size = New System.Drawing.Size(50, 20)
        Me.txtUp.TabIndex = 1
        Me.txtUp.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Nom:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(65, 6)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(415, 20)
        Me.txtName.TabIndex = 8
        '
        'fraMapSettings
        '
        Me.fraMapSettings.Controls.Add(Me.Label7)
        Me.fraMapSettings.Controls.Add(Me.cmbMoral)
        Me.fraMapSettings.Location = New System.Drawing.Point(176, 33)
        Me.fraMapSettings.Name = "fraMapSettings"
        Me.fraMapSettings.Size = New System.Drawing.Size(304, 39)
        Me.fraMapSettings.TabIndex = 9
        Me.fraMapSettings.TabStop = False
        Me.fraMapSettings.Text = "Paramètres de la carte"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Moral:"
        '
        'cmbMoral
        '
        Me.cmbMoral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoral.FormattingEnabled = True
        Me.cmbMoral.Items.AddRange(New Object() {"None", "Safe Zone"})
        Me.cmbMoral.Location = New System.Drawing.Point(77, 12)
        Me.cmbMoral.Name = "cmbMoral"
        Me.cmbMoral.Size = New System.Drawing.Size(221, 21)
        Me.cmbMoral.TabIndex = 37
        '
        'fraNpcs
        '
        Me.fraNpcs.Controls.Add(Me.ComboBox23)
        Me.fraNpcs.Location = New System.Drawing.Point(176, 72)
        Me.fraNpcs.Name = "fraNpcs"
        Me.fraNpcs.Size = New System.Drawing.Size(304, 426)
        Me.fraNpcs.TabIndex = 10
        Me.fraNpcs.TabStop = False
        Me.fraNpcs.Text = "PNJs"
        '
        'ComboBox23
        '
        Me.ComboBox23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox23.FormattingEnabled = True
        Me.ComboBox23.Location = New System.Drawing.Point(341, 469)
        Me.ComboBox23.Name = "ComboBox23"
        Me.ComboBox23.Size = New System.Drawing.Size(133, 21)
        Me.ComboBox23.TabIndex = 68
        '
        'frmEditor_MapProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraNpcs)
        Me.Controls.Add(Me.fraMapSettings)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.fraMapLinks)
        Me.Controls.Add(Me.fraBootSettings)
        Me.Controls.Add(Me.fraMaxSizes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmEditor_MapProperties"
        Me.Text = "Editeur de carte - Propriété"
        Me.GroupBox1.ResumeLayout(False)
        Me.fraMaxSizes.ResumeLayout(False)
        Me.fraMaxSizes.PerformLayout()
        Me.fraBootSettings.ResumeLayout(False)
        Me.fraBootSettings.PerformLayout()
        Me.fraMapLinks.ResumeLayout(False)
        Me.fraMapLinks.PerformLayout()
        Me.fraMapSettings.ResumeLayout(False)
        Me.fraMapSettings.PerformLayout()
        Me.fraNpcs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstMusic As System.Windows.Forms.ListBox
    Friend WithEvents fraMaxSizes As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMaxX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fraBootSettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtBootY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBootX As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBootMap As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fraMapLinks As System.Windows.Forms.GroupBox
    Friend WithEvents txtDown As System.Windows.Forms.TextBox
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents lblMap As System.Windows.Forms.Label
    Friend WithEvents txtRight As System.Windows.Forms.TextBox
    Friend WithEvents txtUp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents fraMapSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbMoral As System.Windows.Forms.ComboBox
    Friend WithEvents fraNpcs As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox23 As System.Windows.Forms.ComboBox
End Class
