<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Shop
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
        Me.lstTradeItem = New System.Windows.Forms.ListBox()
        Me.btnDeleteTrade = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.cmbCostItem = New System.Windows.Forms.ComboBox()
        Me.cmbItem = New System.Windows.Forms.ComboBox()
        Me.txtCostValue = New System.Windows.Forms.TextBox()
        Me.txtItemValue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.scrlBuy = New System.Windows.Forms.HScrollBar()
        Me.lblBuy = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.picFace = New System.Windows.Forms.PictureBox()
        Me.lblFace = New System.Windows.Forms.Label()
        Me.scrlFace = New System.Windows.Forms.HScrollBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 369)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shop List"
        '
        'lstIndex
        '
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(8, 16)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(196, 342)
        Me.lstIndex.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.scrlFace)
        Me.GroupBox2.Controls.Add(Me.lblFace)
        Me.GroupBox2.Controls.Add(Me.picFace)
        Me.GroupBox2.Controls.Add(Me.lstTradeItem)
        Me.GroupBox2.Controls.Add(Me.btnDeleteTrade)
        Me.GroupBox2.Controls.Add(Me.btnUpdate)
        Me.GroupBox2.Controls.Add(Me.cmbCostItem)
        Me.GroupBox2.Controls.Add(Me.cmbItem)
        Me.GroupBox2.Controls.Add(Me.txtCostValue)
        Me.GroupBox2.Controls.Add(Me.txtItemValue)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.scrlBuy)
        Me.GroupBox2.Controls.Add(Me.lblBuy)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(228, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(374, 369)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shop Properties"
        '
        'lstTradeItem
        '
        Me.lstTradeItem.FormattingEnabled = True
        Me.lstTradeItem.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6.", "7.", "8."})
        Me.lstTradeItem.Location = New System.Drawing.Point(6, 229)
        Me.lstTradeItem.Name = "lstTradeItem"
        Me.lstTradeItem.Size = New System.Drawing.Size(360, 134)
        Me.lstTradeItem.TabIndex = 42
        '
        'btnDeleteTrade
        '
        Me.btnDeleteTrade.Location = New System.Drawing.Point(190, 197)
        Me.btnDeleteTrade.Name = "btnDeleteTrade"
        Me.btnDeleteTrade.Size = New System.Drawing.Size(117, 21)
        Me.btnDeleteTrade.TabIndex = 41
        Me.btnDeleteTrade.Text = "Delete"
        Me.btnDeleteTrade.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(51, 197)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(117, 21)
        Me.btnUpdate.TabIndex = 40
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'cmbCostItem
        '
        Me.cmbCostItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCostItem.FormattingEnabled = True
        Me.cmbCostItem.Location = New System.Drawing.Point(54, 167)
        Me.cmbCostItem.Name = "cmbCostItem"
        Me.cmbCostItem.Size = New System.Drawing.Size(210, 21)
        Me.cmbCostItem.TabIndex = 39
        '
        'cmbItem
        '
        Me.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItem.FormattingEnabled = True
        Me.cmbItem.Location = New System.Drawing.Point(54, 138)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(210, 21)
        Me.cmbItem.TabIndex = 38
        '
        'txtCostValue
        '
        Me.txtCostValue.Location = New System.Drawing.Point(313, 165)
        Me.txtCostValue.Name = "txtCostValue"
        Me.txtCostValue.Size = New System.Drawing.Size(47, 20)
        Me.txtCostValue.TabIndex = 9
        Me.txtCostValue.Text = "0"
        '
        'txtItemValue
        '
        Me.txtItemValue.Location = New System.Drawing.Point(313, 139)
        Me.txtItemValue.Name = "txtItemValue"
        Me.txtItemValue.Size = New System.Drawing.Size(47, 20)
        Me.txtItemValue.TabIndex = 8
        Me.txtItemValue.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(293, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "X"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(293, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "X"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Price:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Item:"
        '
        'scrlBuy
        '
        Me.scrlBuy.LargeChange = 1
        Me.scrlBuy.Location = New System.Drawing.Point(111, 95)
        Me.scrlBuy.Maximum = 1000
        Me.scrlBuy.Name = "scrlBuy"
        Me.scrlBuy.Size = New System.Drawing.Size(255, 17)
        Me.scrlBuy.TabIndex = 3
        Me.scrlBuy.Value = 100
        '
        'lblBuy
        '
        Me.lblBuy.AutoSize = True
        Me.lblBuy.Location = New System.Drawing.Point(108, 75)
        Me.lblBuy.Name = "lblBuy"
        Me.lblBuy.Size = New System.Drawing.Size(111, 13)
        Me.lblBuy.TabIndex = 2
        Me.lblBuy.Text = "Buy Back Rate: 100%"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(180, 16)
        Me.txtName.MaxLength = 30
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(186, 20)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(108, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Shop Name:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(497, 387)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(363, 387)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 25)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(228, 387)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 25)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'picFace
        '
        Me.picFace.BackColor = System.Drawing.Color.Black
        Me.picFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFace.Location = New System.Drawing.Point(6, 16)
        Me.picFace.Name = "picFace"
        Me.picFace.Size = New System.Drawing.Size(96, 96)
        Me.picFace.TabIndex = 43
        Me.picFace.TabStop = False
        '
        'lblFace
        '
        Me.lblFace.AutoSize = True
        Me.lblFace.Location = New System.Drawing.Point(108, 51)
        Me.lblFace.Name = "lblFace"
        Me.lblFace.Size = New System.Drawing.Size(43, 13)
        Me.lblFace.TabIndex = 44
        Me.lblFace.Text = "Face: 1"
        '
        'scrlFace
        '
        Me.scrlFace.LargeChange = 1
        Me.scrlFace.Location = New System.Drawing.Point(180, 47)
        Me.scrlFace.Maximum = 1000
        Me.scrlFace.Name = "scrlFace"
        Me.scrlFace.Size = New System.Drawing.Size(186, 17)
        Me.scrlFace.TabIndex = 45
        Me.scrlFace.Value = 100
        '
        'frmEditor_Shop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 417)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Shop"
        Me.Text = "Shop Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents scrlBuy As System.Windows.Forms.HScrollBar
    Friend WithEvents lblBuy As System.Windows.Forms.Label
    Friend WithEvents txtItemValue As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCostValue As System.Windows.Forms.TextBox
    Friend WithEvents cmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCostItem As System.Windows.Forms.ComboBox
    Friend WithEvents lstTradeItem As System.Windows.Forms.ListBox
    Friend WithEvents btnDeleteTrade As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents scrlFace As System.Windows.Forms.HScrollBar
    Friend WithEvents lblFace As System.Windows.Forms.Label
    Friend WithEvents picFace As System.Windows.Forms.PictureBox
End Class
