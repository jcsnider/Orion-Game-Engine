<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.tmrConnect = New System.Windows.Forms.Timer(Me.components)
        Me.lblConnectionStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.pnlAdmin = New System.Windows.Forms.Panel()
        Me.btnAutoMapper = New System.Windows.Forms.Button()
        Me.btnClassEditor = New System.Windows.Forms.Button()
        Me.btnRecipeEditor = New System.Windows.Forms.Button()
        Me.btnProjectiles = New System.Windows.Forms.Button()
        Me.btnQuest = New System.Windows.Forms.Button()
        Me.btnhouseEditor = New System.Windows.Forms.Button()
        Me.btnMapEditor = New System.Windows.Forms.Button()
        Me.btnItemEditor = New System.Windows.Forms.Button()
        Me.btnResourceEditor = New System.Windows.Forms.Button()
        Me.btnNPCEditor = New System.Windows.Forms.Button()
        Me.btnSkillEditor = New System.Windows.Forms.Button()
        Me.btnShopEditor = New System.Windows.Forms.Button()
        Me.btnAnimationEditor = New System.Windows.Forms.Button()
        Me.btnPetEditor = New System.Windows.Forms.Button()
        Me.pnlAdmin.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrConnect
        '
        Me.tmrConnect.Enabled = True
        Me.tmrConnect.Interval = 1000
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.AutoSize = True
        Me.lblConnectionStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblConnectionStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectionStatus.ForeColor = System.Drawing.Color.Orange
        Me.lblConnectionStatus.Location = New System.Drawing.Point(12, 235)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(149, 17)
        Me.lblConnectionStatus.TabIndex = 0
        Me.lblConnectionStatus.Text = "Connecting to Server..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(16, 84)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(159, 20)
        Me.txtLogin.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(16, 123)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(159, 20)
        Me.txtPassword.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(16, 161)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(159, 23)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'pnlAdmin
        '
        Me.pnlAdmin.BackColor = System.Drawing.Color.Transparent
        Me.pnlAdmin.Controls.Add(Me.btnPetEditor)
        Me.pnlAdmin.Controls.Add(Me.btnAutoMapper)
        Me.pnlAdmin.Controls.Add(Me.btnClassEditor)
        Me.pnlAdmin.Controls.Add(Me.btnRecipeEditor)
        Me.pnlAdmin.Controls.Add(Me.btnProjectiles)
        Me.pnlAdmin.Controls.Add(Me.btnQuest)
        Me.pnlAdmin.Controls.Add(Me.btnhouseEditor)
        Me.pnlAdmin.Controls.Add(Me.btnMapEditor)
        Me.pnlAdmin.Controls.Add(Me.btnItemEditor)
        Me.pnlAdmin.Controls.Add(Me.btnResourceEditor)
        Me.pnlAdmin.Controls.Add(Me.btnNPCEditor)
        Me.pnlAdmin.Controls.Add(Me.btnSkillEditor)
        Me.pnlAdmin.Controls.Add(Me.btnShopEditor)
        Me.pnlAdmin.Controls.Add(Me.btnAnimationEditor)
        Me.pnlAdmin.Location = New System.Drawing.Point(12, 12)
        Me.pnlAdmin.Name = "pnlAdmin"
        Me.pnlAdmin.Size = New System.Drawing.Size(505, 189)
        Me.pnlAdmin.TabIndex = 6
        Me.pnlAdmin.Visible = False
        '
        'btnAutoMapper
        '
        Me.btnAutoMapper.Location = New System.Drawing.Point(154, 3)
        Me.btnAutoMapper.Name = "btnAutoMapper"
        Me.btnAutoMapper.Size = New System.Drawing.Size(112, 25)
        Me.btnAutoMapper.TabIndex = 53
        Me.btnAutoMapper.Text = "Auto Mapper"
        Me.btnAutoMapper.UseVisualStyleBackColor = True
        '
        'btnClassEditor
        '
        Me.btnClassEditor.Location = New System.Drawing.Point(390, 158)
        Me.btnClassEditor.Name = "btnClassEditor"
        Me.btnClassEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnClassEditor.TabIndex = 52
        Me.btnClassEditor.Text = "Class Editor"
        Me.btnClassEditor.UseVisualStyleBackColor = True
        '
        'btnRecipeEditor
        '
        Me.btnRecipeEditor.Location = New System.Drawing.Point(272, 158)
        Me.btnRecipeEditor.Name = "btnRecipeEditor"
        Me.btnRecipeEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnRecipeEditor.TabIndex = 51
        Me.btnRecipeEditor.Text = "Recipe Editor"
        Me.btnRecipeEditor.UseVisualStyleBackColor = True
        '
        'btnProjectiles
        '
        Me.btnProjectiles.Location = New System.Drawing.Point(390, 127)
        Me.btnProjectiles.Name = "btnProjectiles"
        Me.btnProjectiles.Size = New System.Drawing.Size(112, 25)
        Me.btnProjectiles.TabIndex = 50
        Me.btnProjectiles.Text = "Projectiles Editor"
        Me.btnProjectiles.UseVisualStyleBackColor = True
        '
        'btnQuest
        '
        Me.btnQuest.Location = New System.Drawing.Point(272, 3)
        Me.btnQuest.Name = "btnQuest"
        Me.btnQuest.Size = New System.Drawing.Size(112, 25)
        Me.btnQuest.TabIndex = 48
        Me.btnQuest.Text = "Quest Editor"
        Me.btnQuest.UseVisualStyleBackColor = True
        '
        'btnhouseEditor
        '
        Me.btnhouseEditor.Location = New System.Drawing.Point(272, 127)
        Me.btnhouseEditor.Name = "btnhouseEditor"
        Me.btnhouseEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnhouseEditor.TabIndex = 49
        Me.btnhouseEditor.Text = "Houses Editor"
        Me.btnhouseEditor.UseVisualStyleBackColor = True
        '
        'btnMapEditor
        '
        Me.btnMapEditor.Location = New System.Drawing.Point(390, 3)
        Me.btnMapEditor.Name = "btnMapEditor"
        Me.btnMapEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnMapEditor.TabIndex = 41
        Me.btnMapEditor.Text = "Map Editor"
        Me.btnMapEditor.UseVisualStyleBackColor = True
        '
        'btnItemEditor
        '
        Me.btnItemEditor.Location = New System.Drawing.Point(272, 34)
        Me.btnItemEditor.Name = "btnItemEditor"
        Me.btnItemEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnItemEditor.TabIndex = 42
        Me.btnItemEditor.Text = "Item Editor"
        Me.btnItemEditor.UseVisualStyleBackColor = True
        '
        'btnResourceEditor
        '
        Me.btnResourceEditor.Location = New System.Drawing.Point(390, 34)
        Me.btnResourceEditor.Name = "btnResourceEditor"
        Me.btnResourceEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnResourceEditor.TabIndex = 43
        Me.btnResourceEditor.Text = "Resource Editor"
        Me.btnResourceEditor.UseVisualStyleBackColor = True
        '
        'btnNPCEditor
        '
        Me.btnNPCEditor.Location = New System.Drawing.Point(272, 65)
        Me.btnNPCEditor.Name = "btnNPCEditor"
        Me.btnNPCEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnNPCEditor.TabIndex = 44
        Me.btnNPCEditor.Text = "NPC Editor"
        Me.btnNPCEditor.UseVisualStyleBackColor = True
        '
        'btnSkillEditor
        '
        Me.btnSkillEditor.Location = New System.Drawing.Point(390, 65)
        Me.btnSkillEditor.Name = "btnSkillEditor"
        Me.btnSkillEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnSkillEditor.TabIndex = 45
        Me.btnSkillEditor.Text = "Skill Editor"
        Me.btnSkillEditor.UseVisualStyleBackColor = True
        '
        'btnShopEditor
        '
        Me.btnShopEditor.Location = New System.Drawing.Point(272, 96)
        Me.btnShopEditor.Name = "btnShopEditor"
        Me.btnShopEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnShopEditor.TabIndex = 46
        Me.btnShopEditor.Text = "Shop Editor"
        Me.btnShopEditor.UseVisualStyleBackColor = True
        '
        'btnAnimationEditor
        '
        Me.btnAnimationEditor.Location = New System.Drawing.Point(390, 96)
        Me.btnAnimationEditor.Name = "btnAnimationEditor"
        Me.btnAnimationEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnAnimationEditor.TabIndex = 47
        Me.btnAnimationEditor.Text = "Animation Editor"
        Me.btnAnimationEditor.UseVisualStyleBackColor = True
        '
        'btnPetEditor
        '
        Me.btnPetEditor.Location = New System.Drawing.Point(154, 34)
        Me.btnPetEditor.Name = "btnPetEditor"
        Me.btnPetEditor.Size = New System.Drawing.Size(112, 25)
        Me.btnPetEditor.TabIndex = 54
        Me.btnPetEditor.Text = "Pet Editor"
        Me.btnPetEditor.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(529, 261)
        Me.Controls.Add(Me.pnlAdmin)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblConnectionStatus)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Orion+ Editors"
        Me.pnlAdmin.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrConnect As Timer
    Friend WithEvents lblConnectionStatus As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents pnlAdmin As Panel
    Friend WithEvents btnClassEditor As Button
    Friend WithEvents btnRecipeEditor As Button
    Friend WithEvents btnProjectiles As Button
    Friend WithEvents btnQuest As Button
    Friend WithEvents btnhouseEditor As Button
    Friend WithEvents btnMapEditor As Button
    Friend WithEvents btnItemEditor As Button
    Friend WithEvents btnResourceEditor As Button
    Friend WithEvents btnNPCEditor As Button
    Friend WithEvents btnSkillEditor As Button
    Friend WithEvents btnShopEditor As Button
    Friend WithEvents btnAnimationEditor As Button
    Friend WithEvents btnAutoMapper As Button
    Friend WithEvents btnPetEditor As Button
End Class
