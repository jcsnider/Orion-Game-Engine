<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisualWarp
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
        Me.btnWarpOK = New DarkUI.Controls.DarkButton()
        Me.DarkLabel15 = New DarkUI.Controls.DarkLabel()
        Me.lstMaps = New System.Windows.Forms.ListBox()
        Me.pnlPreview = New System.Windows.Forms.Panel()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.lblSelX = New DarkUI.Controls.DarkLabel()
        Me.lblSelY = New DarkUI.Controls.DarkLabel()
        Me.pnlPreview.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnWarpOK
        '
        Me.btnWarpOK.Location = New System.Drawing.Point(12, 504)
        Me.btnWarpOK.Name = "btnWarpOK"
        Me.btnWarpOK.Padding = New System.Windows.Forms.Padding(5)
        Me.btnWarpOK.Size = New System.Drawing.Size(167, 23)
        Me.btnWarpOK.TabIndex = 4
        Me.btnWarpOK.Text = "Ok"
        '
        'DarkLabel15
        '
        Me.DarkLabel15.AutoSize = True
        Me.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel15.Location = New System.Drawing.Point(12, 9)
        Me.DarkLabel15.Name = "DarkLabel15"
        Me.DarkLabel15.Size = New System.Drawing.Size(47, 13)
        Me.DarkLabel15.TabIndex = 3
        Me.DarkLabel15.Text = "Map List"
        '
        'lstMaps
        '
        Me.lstMaps.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lstMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMaps.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstMaps.FormattingEnabled = True
        Me.lstMaps.Location = New System.Drawing.Point(12, 25)
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(173, 275)
        Me.lstMaps.TabIndex = 2
        '
        'pnlPreview
        '
        Me.pnlPreview.AutoScroll = True
        Me.pnlPreview.Controls.Add(Me.picPreview)
        Me.pnlPreview.Location = New System.Drawing.Point(191, 12)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(589, 515)
        Me.pnlPreview.TabIndex = 1
        '
        'picPreview
        '
        Me.picPreview.Location = New System.Drawing.Point(3, 3)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(356, 376)
        Me.picPreview.TabIndex = 0
        Me.picPreview.TabStop = False
        '
        'lblSelX
        '
        Me.lblSelX.AutoSize = True
        Me.lblSelX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblSelX.Location = New System.Drawing.Point(12, 313)
        Me.lblSelX.Name = "lblSelX"
        Me.lblSelX.Size = New System.Drawing.Size(71, 13)
        Me.lblSelX.TabIndex = 5
        Me.lblSelX.Text = "Selected X: 0"
        '
        'lblSelY
        '
        Me.lblSelY.AutoSize = True
        Me.lblSelY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblSelY.Location = New System.Drawing.Point(12, 338)
        Me.lblSelY.Name = "lblSelY"
        Me.lblSelY.Size = New System.Drawing.Size(71, 13)
        Me.lblSelY.TabIndex = 6
        Me.lblSelY.Text = "Selected Y: 0"
        '
        'FrmVisualWarp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(788, 539)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSelY)
        Me.Controls.Add(Me.lblSelX)
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.btnWarpOK)
        Me.Controls.Add(Me.DarkLabel15)
        Me.Controls.Add(Me.lstMaps)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmVisualWarp"
        Me.Text = "Visual Warp"
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnWarpOK As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
    Friend WithEvents lstMaps As ListBox
    Friend WithEvents pnlPreview As Panel
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents lblSelX As DarkUI.Controls.DarkLabel
    Friend WithEvents lblSelY As DarkUI.Controls.DarkLabel
End Class
