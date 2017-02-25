<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Recipe
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
        Me.btnCancel = New DarkUI.Controls.DarkButton()
        Me.btnDelete = New DarkUI.Controls.DarkButton()
        Me.btnSave = New DarkUI.Controls.DarkButton()
        Me.nudCreateTime = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel7 = New DarkUI.Controls.DarkLabel()
        Me.DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        Me.btnIngredientAdd = New DarkUI.Controls.DarkButton()
        Me.numItemAmount = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel6 = New DarkUI.Controls.DarkLabel()
        Me.cmbIngredient = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel5 = New DarkUI.Controls.DarkLabel()
        Me.lstIngredients = New System.Windows.Forms.ListBox()
        Me.nudAmount = New DarkUI.Controls.DarkNumericUpDown()
        Me.DarkLabel4 = New DarkUI.Controls.DarkLabel()
        Me.cmbMakeItem = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel3 = New DarkUI.Controls.DarkLabel()
        Me.cmbType = New DarkUI.Controls.DarkComboBox()
        Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
        Me.txtName = New DarkUI.Controls.DarkTextBox()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.DarkGroupBox1.SuspendLayout()
        Me.DarkGroupBox2.SuspendLayout()
        CType(Me.nudCreateTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DarkGroupBox3.SuspendLayout()
        CType(Me.numItemAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DarkGroupBox1
        '
        Me.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox1.Controls.Add(Me.lstIndex)
        Me.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.DarkGroupBox1.Name = "DarkGroupBox1"
        Me.DarkGroupBox1.Size = New System.Drawing.Size(208, 337)
        Me.DarkGroupBox1.TabIndex = 0
        Me.DarkGroupBox1.TabStop = False
        Me.DarkGroupBox1.Text = "Recipe List"
        '
        'lstIndex
        '
        Me.lstIndex.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIndex.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIndex.FormattingEnabled = True
        Me.lstIndex.Location = New System.Drawing.Point(6, 15)
        Me.lstIndex.Name = "lstIndex"
        Me.lstIndex.Size = New System.Drawing.Size(196, 314)
        Me.lstIndex.TabIndex = 1
        '
        'DarkGroupBox2
        '
        Me.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox2.Controls.Add(Me.btnCancel)
        Me.DarkGroupBox2.Controls.Add(Me.btnDelete)
        Me.DarkGroupBox2.Controls.Add(Me.btnSave)
        Me.DarkGroupBox2.Controls.Add(Me.nudCreateTime)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel7)
        Me.DarkGroupBox2.Controls.Add(Me.DarkGroupBox3)
        Me.DarkGroupBox2.Controls.Add(Me.nudAmount)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel4)
        Me.DarkGroupBox2.Controls.Add(Me.cmbMakeItem)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel3)
        Me.DarkGroupBox2.Controls.Add(Me.cmbType)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel2)
        Me.DarkGroupBox2.Controls.Add(Me.txtName)
        Me.DarkGroupBox2.Controls.Add(Me.DarkLabel1)
        Me.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox2.Location = New System.Drawing.Point(217, 2)
        Me.DarkGroupBox2.Name = "DarkGroupBox2"
        Me.DarkGroupBox2.Size = New System.Drawing.Size(364, 337)
        Me.DarkGroupBox2.TabIndex = 1
        Me.DarkGroupBox2.TabStop = False
        Me.DarkGroupBox2.Text = "Settings"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(279, 306)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(143, 306)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5)
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(9, 306)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        '
        'nudCreateTime
        '
        Me.nudCreateTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudCreateTime.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudCreateTime.Location = New System.Drawing.Point(171, 118)
        Me.nudCreateTime.Name = "nudCreateTime"
        Me.nudCreateTime.Size = New System.Drawing.Size(120, 20)
        Me.nudCreateTime.TabIndex = 10
        '
        'DarkLabel7
        '
        Me.DarkLabel7.AutoSize = True
        Me.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel7.Location = New System.Drawing.Point(6, 120)
        Me.DarkLabel7.Name = "DarkLabel7"
        Me.DarkLabel7.Size = New System.Drawing.Size(106, 13)
        Me.DarkLabel7.TabIndex = 9
        Me.DarkLabel7.Text = "Create Time In Secs:"
        '
        'DarkGroupBox3
        '
        Me.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.DarkGroupBox3.Controls.Add(Me.btnIngredientAdd)
        Me.DarkGroupBox3.Controls.Add(Me.numItemAmount)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel6)
        Me.DarkGroupBox3.Controls.Add(Me.cmbIngredient)
        Me.DarkGroupBox3.Controls.Add(Me.DarkLabel5)
        Me.DarkGroupBox3.Controls.Add(Me.lstIngredients)
        Me.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.DarkGroupBox3.Location = New System.Drawing.Point(9, 144)
        Me.DarkGroupBox3.Name = "DarkGroupBox3"
        Me.DarkGroupBox3.Size = New System.Drawing.Size(345, 138)
        Me.DarkGroupBox3.TabIndex = 8
        Me.DarkGroupBox3.TabStop = False
        Me.DarkGroupBox3.Text = "Ingredients"
        '
        'btnIngredientAdd
        '
        Me.btnIngredientAdd.Location = New System.Drawing.Point(175, 102)
        Me.btnIngredientAdd.Name = "btnIngredientAdd"
        Me.btnIngredientAdd.Padding = New System.Windows.Forms.Padding(5)
        Me.btnIngredientAdd.Size = New System.Drawing.Size(144, 23)
        Me.btnIngredientAdd.TabIndex = 6
        Me.btnIngredientAdd.Text = "Update List"
        '
        'numItemAmount
        '
        Me.numItemAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.numItemAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.numItemAmount.Location = New System.Drawing.Point(286, 62)
        Me.numItemAmount.Name = "numItemAmount"
        Me.numItemAmount.Size = New System.Drawing.Size(53, 20)
        Me.numItemAmount.TabIndex = 5
        '
        'DarkLabel6
        '
        Me.DarkLabel6.AutoSize = True
        Me.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel6.Location = New System.Drawing.Point(158, 64)
        Me.DarkLabel6.Name = "DarkLabel6"
        Me.DarkLabel6.Size = New System.Drawing.Size(87, 13)
        Me.DarkLabel6.TabIndex = 4
        Me.DarkLabel6.Text = "Amount Needed:"
        '
        'cmbIngredient
        '
        Me.cmbIngredient.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbIngredient.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbIngredient.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbIngredient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIngredient.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbIngredient.FormattingEnabled = True
        Me.cmbIngredient.Location = New System.Drawing.Point(161, 35)
        Me.cmbIngredient.Name = "cmbIngredient"
        Me.cmbIngredient.Size = New System.Drawing.Size(178, 21)
        Me.cmbIngredient.TabIndex = 3
        '
        'DarkLabel5
        '
        Me.DarkLabel5.AutoSize = True
        Me.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel5.Location = New System.Drawing.Point(158, 19)
        Me.DarkLabel5.Name = "DarkLabel5"
        Me.DarkLabel5.Size = New System.Drawing.Size(93, 13)
        Me.DarkLabel5.TabIndex = 2
        Me.DarkLabel5.Text = "Choose Ingredient"
        '
        'lstIngredients
        '
        Me.lstIngredients.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lstIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstIngredients.ForeColor = System.Drawing.Color.Gainsboro
        Me.lstIngredients.FormattingEnabled = True
        Me.lstIngredients.Location = New System.Drawing.Point(6, 19)
        Me.lstIngredients.Name = "lstIngredients"
        Me.lstIngredients.Size = New System.Drawing.Size(146, 106)
        Me.lstIngredients.TabIndex = 1
        '
        'nudAmount
        '
        Me.nudAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.nudAmount.ForeColor = System.Drawing.Color.Gainsboro
        Me.nudAmount.Location = New System.Drawing.Point(312, 86)
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(42, 20)
        Me.nudAmount.TabIndex = 7
        '
        'DarkLabel4
        '
        Me.DarkLabel4.AutoSize = True
        Me.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel4.Location = New System.Drawing.Point(297, 88)
        Me.DarkLabel4.Name = "DarkLabel4"
        Me.DarkLabel4.Size = New System.Drawing.Size(14, 13)
        Me.DarkLabel4.TabIndex = 6
        Me.DarkLabel4.Text = "X"
        '
        'cmbMakeItem
        '
        Me.cmbMakeItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbMakeItem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbMakeItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbMakeItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMakeItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMakeItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMakeItem.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbMakeItem.FormattingEnabled = True
        Me.cmbMakeItem.Location = New System.Drawing.Point(87, 85)
        Me.cmbMakeItem.Name = "cmbMakeItem"
        Me.cmbMakeItem.Size = New System.Drawing.Size(204, 21)
        Me.cmbMakeItem.TabIndex = 5
        '
        'DarkLabel3
        '
        Me.DarkLabel3.AutoSize = True
        Me.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel3.Location = New System.Drawing.Point(6, 88)
        Me.DarkLabel3.Name = "DarkLabel3"
        Me.DarkLabel3.Size = New System.Drawing.Size(69, 13)
        Me.DarkLabel3.TabIndex = 4
        Me.DarkLabel3.Text = "Creates Item:"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.cmbType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cmbType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbType.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Herbalist", "WoodWorking", "MetalWorking"})
        Me.cmbType.Location = New System.Drawing.Point(87, 54)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(267, 21)
        Me.cmbType.TabIndex = 3
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(6, 57)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(71, 13)
        Me.DarkLabel2.TabIndex = 2
        Me.DarkLabel2.Text = "Recipe Type:"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtName.Location = New System.Drawing.Point(87, 25)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(267, 20)
        Me.txtName.TabIndex = 1
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(6, 27)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(75, 13)
        Me.DarkLabel1.TabIndex = 0
        Me.DarkLabel1.Text = "Recipe Name:"
        '
        'frmEditor_Recipe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(588, 346)
        Me.ControlBox = False
        Me.Controls.Add(Me.DarkGroupBox2)
        Me.Controls.Add(Me.DarkGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditor_Recipe"
        Me.Text = "Recipe Editor"
        Me.DarkGroupBox1.ResumeLayout(False)
        Me.DarkGroupBox2.ResumeLayout(False)
        Me.DarkGroupBox2.PerformLayout()
        CType(Me.nudCreateTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DarkGroupBox3.ResumeLayout(False)
        Me.DarkGroupBox3.PerformLayout()
        CType(Me.numItemAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As ListBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbType As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbMakeItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIngredients As ListBox
    Friend WithEvents cmbIngredient As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents numItemAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents btnIngredientAdd As DarkUI.Controls.DarkButton
    Friend WithEvents nudCreateTime As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
End Class
