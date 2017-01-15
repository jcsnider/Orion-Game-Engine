<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenu))
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.chkSavePass = New System.Windows.Forms.CheckBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblLoginPass = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lblLoginName = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.pnlRegister = New System.Windows.Forms.Panel()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.txtRPass2 = New System.Windows.Forms.TextBox()
        Me.lblNewAccPass2 = New System.Windows.Forms.Label()
        Me.txtRPass = New System.Windows.Forms.TextBox()
        Me.lblNewAccPass = New System.Windows.Forms.Label()
        Me.txtRuser = New System.Windows.Forms.TextBox()
        Me.lblNewAccName = New System.Windows.Forms.Label()
        Me.lblNewAccount = New System.Windows.Forms.Label()
        Me.pnlCredits = New System.Windows.Forms.Panel()
        Me.lblCreditsTop = New System.Windows.Forms.Label()
        Me.lblScrollingCredits = New System.Windows.Forms.Label()
        Me.tmrCredits = New System.Windows.Forms.Timer(Me.components)
        Me.pnlNewChar = New System.Windows.Forms.Panel()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblNewCharSprite = New System.Windows.Forms.Label()
        Me.btnCreateCharacter = New System.Windows.Forms.Button()
        Me.placeholderforsprite = New System.Windows.Forms.PictureBox()
        Me.lblNextChar = New System.Windows.Forms.Label()
        Me.lblPrevChar = New System.Windows.Forms.Label()
        Me.rdoFemale = New System.Windows.Forms.RadioButton()
        Me.rdoMale = New System.Windows.Forms.RadioButton()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.lblNewCharGender = New System.Windows.Forms.Label()
        Me.lblNewCharClass = New System.Windows.Forms.Label()
        Me.txtCharName = New System.Windows.Forms.TextBox()
        Me.lblNewCharName = New System.Windows.Forms.Label()
        Me.lblNewChar = New System.Windows.Forms.Label()
        Me.lblStatusHeader = New System.Windows.Forms.Label()
        Me.lblServerStatus = New System.Windows.Forms.Label()
        Me.pnlMainMenu = New System.Windows.Forms.Panel()
        Me.lblNewsHeader = New System.Windows.Forms.Label()
        Me.lblNews = New System.Windows.Forms.Label()
        Me.pnlIPConfig = New System.Windows.Forms.Panel()
        Me.btnSaveIP = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.lblIpAdress = New System.Windows.Forms.Label()
        Me.lblIpConfig = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnCredits = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pnlCharSelect = New System.Windows.Forms.Panel()
        Me.btnUseChar = New System.Windows.Forms.Button()
        Me.btnDelChar = New System.Windows.Forms.Button()
        Me.btnNewChar = New System.Windows.Forms.Button()
        Me.picChar3 = New System.Windows.Forms.PictureBox()
        Me.picChar2 = New System.Windows.Forms.PictureBox()
        Me.picChar1 = New System.Windows.Forms.PictureBox()
        Me.lblCharSelect = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlLoad = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pnlLogin.SuspendLayout()
        Me.pnlRegister.SuspendLayout()
        Me.pnlCredits.SuspendLayout()
        Me.pnlNewChar.SuspendLayout()
        CType(Me.placeholderforsprite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainMenu.SuspendLayout()
        Me.pnlIPConfig.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCharSelect.SuspendLayout()
        CType(Me.picChar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoad.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.Transparent
        Me.pnlLogin.BackgroundImage = CType(resources.GetObject("pnlLogin.BackgroundImage"), System.Drawing.Image)
        Me.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.chkSavePass)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Controls.Add(Me.lblLoginPass)
        Me.pnlLogin.Controls.Add(Me.txtLogin)
        Me.pnlLogin.Controls.Add(Me.lblLoginName)
        Me.pnlLogin.Controls.Add(Me.lblLogin)
        Me.pnlLogin.ForeColor = System.Drawing.Color.White
        Me.pnlLogin.Location = New System.Drawing.Point(737, 6)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(400, 192)
        Me.pnlLogin.TabIndex = 37
        Me.pnlLogin.Visible = False
        '
        'btnLogin
        '
        Me.btnLogin.BackgroundImage = CType(resources.GetObject("btnLogin.BackgroundImage"), System.Drawing.Image)
        Me.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogin.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLogin.Location = New System.Drawing.Point(180, 153)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(110, 26)
        Me.btnLogin.TabIndex = 49
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'chkSavePass
        '
        Me.chkSavePass.AutoSize = True
        Me.chkSavePass.BackColor = System.Drawing.Color.Transparent
        Me.chkSavePass.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSavePass.Location = New System.Drawing.Point(110, 128)
        Me.chkSavePass.Name = "chkSavePass"
        Me.chkSavePass.Size = New System.Drawing.Size(108, 19)
        Me.chkSavePass.TabIndex = 25
        Me.chkSavePass.Text = "Save Password?"
        Me.chkSavePass.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(180, 98)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(110, 20)
        Me.txtPassword.TabIndex = 24
        '
        'lblLoginPass
        '
        Me.lblLoginPass.AutoSize = True
        Me.lblLoginPass.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginPass.Location = New System.Drawing.Point(107, 101)
        Me.lblLoginPass.Name = "lblLoginPass"
        Me.lblLoginPass.Size = New System.Drawing.Size(59, 15)
        Me.lblLoginPass.TabIndex = 23
        Me.lblLoginPass.Text = "Password:"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(180, 63)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(110, 20)
        Me.txtLogin.TabIndex = 17
        '
        'lblLoginName
        '
        Me.lblLoginName.AutoSize = True
        Me.lblLoginName.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginName.Location = New System.Drawing.Point(107, 66)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(40, 15)
        Me.lblLoginName.TabIndex = 16
        Me.lblLoginName.Text = "Name:"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(170, 12)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(90, 31)
        Me.lblLogin.TabIndex = 15
        Me.lblLogin.Text = "Login"
        '
        'pnlRegister
        '
        Me.pnlRegister.BackColor = System.Drawing.Color.Transparent
        Me.pnlRegister.BackgroundImage = CType(resources.GetObject("pnlRegister.BackgroundImage"), System.Drawing.Image)
        Me.pnlRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlRegister.Controls.Add(Me.btnCreateAccount)
        Me.pnlRegister.Controls.Add(Me.txtRPass2)
        Me.pnlRegister.Controls.Add(Me.lblNewAccPass2)
        Me.pnlRegister.Controls.Add(Me.txtRPass)
        Me.pnlRegister.Controls.Add(Me.lblNewAccPass)
        Me.pnlRegister.Controls.Add(Me.txtRuser)
        Me.pnlRegister.Controls.Add(Me.lblNewAccName)
        Me.pnlRegister.Controls.Add(Me.lblNewAccount)
        Me.pnlRegister.ForeColor = System.Drawing.Color.White
        Me.pnlRegister.Location = New System.Drawing.Point(1143, 6)
        Me.pnlRegister.Name = "pnlRegister"
        Me.pnlRegister.Size = New System.Drawing.Size(400, 192)
        Me.pnlRegister.TabIndex = 38
        Me.pnlRegister.Visible = False
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.BackgroundImage = CType(resources.GetObject("btnCreateAccount.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreateAccount.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAccount.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCreateAccount.Location = New System.Drawing.Point(180, 157)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(110, 26)
        Me.btnCreateAccount.TabIndex = 23
        Me.btnCreateAccount.Text = "Create Account"
        Me.btnCreateAccount.UseVisualStyleBackColor = True
        '
        'txtRPass2
        '
        Me.txtRPass2.Location = New System.Drawing.Point(180, 125)
        Me.txtRPass2.Name = "txtRPass2"
        Me.txtRPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRPass2.Size = New System.Drawing.Size(110, 20)
        Me.txtRPass2.TabIndex = 21
        '
        'lblNewAccPass2
        '
        Me.lblNewAccPass2.AutoSize = True
        Me.lblNewAccPass2.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccPass2.Location = New System.Drawing.Point(70, 128)
        Me.lblNewAccPass2.Name = "lblNewAccPass2"
        Me.lblNewAccPass2.Size = New System.Drawing.Size(98, 15)
        Me.lblNewAccPass2.TabIndex = 20
        Me.lblNewAccPass2.Text = "Retype Password:"
        '
        'txtRPass
        '
        Me.txtRPass.Location = New System.Drawing.Point(180, 97)
        Me.txtRPass.Name = "txtRPass"
        Me.txtRPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRPass.Size = New System.Drawing.Size(110, 20)
        Me.txtRPass.TabIndex = 19
        '
        'lblNewAccPass
        '
        Me.lblNewAccPass.AutoSize = True
        Me.lblNewAccPass.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccPass.Location = New System.Drawing.Point(107, 100)
        Me.lblNewAccPass.Name = "lblNewAccPass"
        Me.lblNewAccPass.Size = New System.Drawing.Size(59, 15)
        Me.lblNewAccPass.TabIndex = 18
        Me.lblNewAccPass.Text = "Password:"
        '
        'txtRuser
        '
        Me.txtRuser.Location = New System.Drawing.Point(180, 63)
        Me.txtRuser.Name = "txtRuser"
        Me.txtRuser.Size = New System.Drawing.Size(110, 20)
        Me.txtRuser.TabIndex = 17
        '
        'lblNewAccName
        '
        Me.lblNewAccName.AutoSize = True
        Me.lblNewAccName.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccName.Location = New System.Drawing.Point(107, 65)
        Me.lblNewAccName.Name = "lblNewAccName"
        Me.lblNewAccName.Size = New System.Drawing.Size(62, 15)
        Me.lblNewAccName.TabIndex = 16
        Me.lblNewAccName.Text = "Username:"
        '
        'lblNewAccount
        '
        Me.lblNewAccount.AutoSize = True
        Me.lblNewAccount.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewAccount.Location = New System.Drawing.Point(122, 12)
        Me.lblNewAccount.Name = "lblNewAccount"
        Me.lblNewAccount.Size = New System.Drawing.Size(168, 31)
        Me.lblNewAccount.TabIndex = 15
        Me.lblNewAccount.Text = "New Account"
        '
        'pnlCredits
        '
        Me.pnlCredits.BackColor = System.Drawing.Color.Transparent
        Me.pnlCredits.BackgroundImage = CType(resources.GetObject("pnlCredits.BackgroundImage"), System.Drawing.Image)
        Me.pnlCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCredits.Controls.Add(Me.lblCreditsTop)
        Me.pnlCredits.Controls.Add(Me.lblScrollingCredits)
        Me.pnlCredits.ForeColor = System.Drawing.Color.White
        Me.pnlCredits.Location = New System.Drawing.Point(1143, 204)
        Me.pnlCredits.Name = "pnlCredits"
        Me.pnlCredits.Size = New System.Drawing.Size(400, 192)
        Me.pnlCredits.TabIndex = 39
        Me.pnlCredits.Visible = False
        '
        'lblCreditsTop
        '
        Me.lblCreditsTop.BackColor = System.Drawing.Color.Transparent
        Me.lblCreditsTop.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditsTop.Location = New System.Drawing.Point(78, 6)
        Me.lblCreditsTop.Name = "lblCreditsTop"
        Me.lblCreditsTop.Size = New System.Drawing.Size(247, 33)
        Me.lblCreditsTop.TabIndex = 15
        Me.lblCreditsTop.Text = "Credits"
        Me.lblCreditsTop.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblScrollingCredits
        '
        Me.lblScrollingCredits.AutoSize = True
        Me.lblScrollingCredits.BackColor = System.Drawing.Color.Transparent
        Me.lblScrollingCredits.Location = New System.Drawing.Point(70, 179)
        Me.lblScrollingCredits.Name = "lblScrollingCredits"
        Me.lblScrollingCredits.Size = New System.Drawing.Size(0, 13)
        Me.lblScrollingCredits.TabIndex = 17
        Me.lblScrollingCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrCredits
        '
        Me.tmrCredits.Enabled = True
        Me.tmrCredits.Interval = 1000
        '
        'pnlNewChar
        '
        Me.pnlNewChar.BackColor = System.Drawing.Color.Transparent
        Me.pnlNewChar.BackgroundImage = CType(resources.GetObject("pnlNewChar.BackgroundImage"), System.Drawing.Image)
        Me.pnlNewChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlNewChar.Controls.Add(Me.txtDescription)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharSprite)
        Me.pnlNewChar.Controls.Add(Me.btnCreateCharacter)
        Me.pnlNewChar.Controls.Add(Me.placeholderforsprite)
        Me.pnlNewChar.Controls.Add(Me.lblNextChar)
        Me.pnlNewChar.Controls.Add(Me.lblPrevChar)
        Me.pnlNewChar.Controls.Add(Me.rdoFemale)
        Me.pnlNewChar.Controls.Add(Me.rdoMale)
        Me.pnlNewChar.Controls.Add(Me.cmbClass)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharGender)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharClass)
        Me.pnlNewChar.Controls.Add(Me.txtCharName)
        Me.pnlNewChar.Controls.Add(Me.lblNewCharName)
        Me.pnlNewChar.Controls.Add(Me.lblNewChar)
        Me.pnlNewChar.ForeColor = System.Drawing.Color.White
        Me.pnlNewChar.Location = New System.Drawing.Point(737, 204)
        Me.pnlNewChar.Name = "pnlNewChar"
        Me.pnlNewChar.Size = New System.Drawing.Size(400, 192)
        Me.pnlNewChar.TabIndex = 43
        Me.pnlNewChar.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(227, 76)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(157, 62)
        Me.txtDescription.TabIndex = 44
        '
        'lblNewCharSprite
        '
        Me.lblNewCharSprite.AutoSize = True
        Me.lblNewCharSprite.Location = New System.Drawing.Point(56, 75)
        Me.lblNewCharSprite.Name = "lblNewCharSprite"
        Me.lblNewCharSprite.Size = New System.Drawing.Size(34, 13)
        Me.lblNewCharSprite.TabIndex = 43
        Me.lblNewCharSprite.Text = "Sprite"
        '
        'btnCreateCharacter
        '
        Me.btnCreateCharacter.BackgroundImage = CType(resources.GetObject("btnCreateCharacter.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreateCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreateCharacter.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateCharacter.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCreateCharacter.Location = New System.Drawing.Point(263, 150)
        Me.btnCreateCharacter.Name = "btnCreateCharacter"
        Me.btnCreateCharacter.Size = New System.Drawing.Size(121, 26)
        Me.btnCreateCharacter.TabIndex = 42
        Me.btnCreateCharacter.Text = "Create Character"
        Me.btnCreateCharacter.UseVisualStyleBackColor = True
        '
        'placeholderforsprite
        '
        Me.placeholderforsprite.Location = New System.Drawing.Point(50, 91)
        Me.placeholderforsprite.Name = "placeholderforsprite"
        Me.placeholderforsprite.Size = New System.Drawing.Size(48, 60)
        Me.placeholderforsprite.TabIndex = 41
        Me.placeholderforsprite.TabStop = False
        Me.placeholderforsprite.Visible = False
        '
        'lblNextChar
        '
        Me.lblNextChar.AutoSize = True
        Me.lblNextChar.Location = New System.Drawing.Point(100, 156)
        Me.lblNextChar.Name = "lblNextChar"
        Me.lblNextChar.Size = New System.Drawing.Size(13, 13)
        Me.lblNextChar.TabIndex = 40
        Me.lblNextChar.Text = ">"
        '
        'lblPrevChar
        '
        Me.lblPrevChar.AutoSize = True
        Me.lblPrevChar.Location = New System.Drawing.Point(37, 156)
        Me.lblPrevChar.Name = "lblPrevChar"
        Me.lblPrevChar.Size = New System.Drawing.Size(13, 13)
        Me.lblPrevChar.TabIndex = 39
        Me.lblPrevChar.Text = "<"
        '
        'rdoFemale
        '
        Me.rdoFemale.AutoSize = True
        Me.rdoFemale.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFemale.Location = New System.Drawing.Point(135, 118)
        Me.rdoFemale.Name = "rdoFemale"
        Me.rdoFemale.Size = New System.Drawing.Size(63, 19)
        Me.rdoFemale.TabIndex = 38
        Me.rdoFemale.TabStop = True
        Me.rdoFemale.Text = "Female"
        Me.rdoFemale.UseVisualStyleBackColor = True
        '
        'rdoMale
        '
        Me.rdoMale.AutoSize = True
        Me.rdoMale.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoMale.Location = New System.Drawing.Point(135, 93)
        Me.rdoMale.Name = "rdoMale"
        Me.rdoMale.Size = New System.Drawing.Size(51, 19)
        Me.rdoMale.TabIndex = 37
        Me.rdoMale.TabStop = True
        Me.rdoMale.Text = "Male"
        Me.rdoMale.UseVisualStyleBackColor = True
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(227, 43)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(157, 21)
        Me.cmbClass.TabIndex = 36
        '
        'lblNewCharGender
        '
        Me.lblNewCharGender.AutoSize = True
        Me.lblNewCharGender.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharGender.Location = New System.Drawing.Point(133, 75)
        Me.lblNewCharGender.Name = "lblNewCharGender"
        Me.lblNewCharGender.Size = New System.Drawing.Size(47, 15)
        Me.lblNewCharGender.TabIndex = 34
        Me.lblNewCharGender.Text = "Gender:"
        '
        'lblNewCharClass
        '
        Me.lblNewCharClass.AutoSize = True
        Me.lblNewCharClass.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharClass.Location = New System.Drawing.Point(186, 45)
        Me.lblNewCharClass.Name = "lblNewCharClass"
        Me.lblNewCharClass.Size = New System.Drawing.Size(37, 15)
        Me.lblNewCharClass.TabIndex = 33
        Me.lblNewCharClass.Text = "Class:"
        '
        'txtCharName
        '
        Me.txtCharName.Location = New System.Drawing.Point(59, 42)
        Me.txtCharName.Name = "txtCharName"
        Me.txtCharName.Size = New System.Drawing.Size(121, 20)
        Me.txtCharName.TabIndex = 32
        '
        'lblNewCharName
        '
        Me.lblNewCharName.AutoSize = True
        Me.lblNewCharName.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewCharName.ForeColor = System.Drawing.Color.White
        Me.lblNewCharName.Location = New System.Drawing.Point(13, 45)
        Me.lblNewCharName.Name = "lblNewCharName"
        Me.lblNewCharName.Size = New System.Drawing.Size(40, 15)
        Me.lblNewCharName.TabIndex = 31
        Me.lblNewCharName.Text = "Name:"
        '
        'lblNewChar
        '
        Me.lblNewChar.AutoSize = True
        Me.lblNewChar.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewChar.ForeColor = System.Drawing.Color.White
        Me.lblNewChar.Location = New System.Drawing.Point(90, 8)
        Me.lblNewChar.Name = "lblNewChar"
        Me.lblNewChar.Size = New System.Drawing.Size(207, 31)
        Me.lblNewChar.TabIndex = 30
        Me.lblNewChar.Text = "Create Character"
        '
        'lblStatusHeader
        '
        Me.lblStatusHeader.AutoSize = True
        Me.lblStatusHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusHeader.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusHeader.ForeColor = System.Drawing.Color.White
        Me.lblStatusHeader.Location = New System.Drawing.Point(482, 9)
        Me.lblStatusHeader.Name = "lblStatusHeader"
        Me.lblStatusHeader.Size = New System.Drawing.Size(109, 18)
        Me.lblStatusHeader.TabIndex = 44
        Me.lblStatusHeader.Text = "Server Status:"
        '
        'lblServerStatus
        '
        Me.lblServerStatus.AutoSize = True
        Me.lblServerStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblServerStatus.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerStatus.ForeColor = System.Drawing.Color.Red
        Me.lblServerStatus.Location = New System.Drawing.Point(589, 9)
        Me.lblServerStatus.Name = "lblServerStatus"
        Me.lblServerStatus.Size = New System.Drawing.Size(62, 18)
        Me.lblServerStatus.TabIndex = 45
        Me.lblServerStatus.Text = "Offline"
        '
        'pnlMainMenu
        '
        Me.pnlMainMenu.BackColor = System.Drawing.Color.Transparent
        Me.pnlMainMenu.BackgroundImage = CType(resources.GetObject("pnlMainMenu.BackgroundImage"), System.Drawing.Image)
        Me.pnlMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMainMenu.Controls.Add(Me.lblNewsHeader)
        Me.pnlMainMenu.Controls.Add(Me.lblNews)
        Me.pnlMainMenu.ForeColor = System.Drawing.Color.White
        Me.pnlMainMenu.Location = New System.Drawing.Point(160, 180)
        Me.pnlMainMenu.Name = "pnlMainMenu"
        Me.pnlMainMenu.Size = New System.Drawing.Size(400, 192)
        Me.pnlMainMenu.TabIndex = 46
        '
        'lblNewsHeader
        '
        Me.lblNewsHeader.AutoSize = True
        Me.lblNewsHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblNewsHeader.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsHeader.Location = New System.Drawing.Point(112, 16)
        Me.lblNewsHeader.Name = "lblNewsHeader"
        Me.lblNewsHeader.Size = New System.Drawing.Size(156, 31)
        Me.lblNewsHeader.TabIndex = 36
        Me.lblNewsHeader.Text = "Latest News"
        '
        'lblNews
        '
        Me.lblNews.BackColor = System.Drawing.Color.Transparent
        Me.lblNews.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNews.Location = New System.Drawing.Point(17, 55)
        Me.lblNews.Name = "lblNews"
        Me.lblNews.Size = New System.Drawing.Size(366, 121)
        Me.lblNews.TabIndex = 37
        Me.lblNews.Text = resources.GetString("lblNews.Text")
        Me.lblNews.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlIPConfig
        '
        Me.pnlIPConfig.BackColor = System.Drawing.Color.Transparent
        Me.pnlIPConfig.BackgroundImage = CType(resources.GetObject("pnlIPConfig.BackgroundImage"), System.Drawing.Image)
        Me.pnlIPConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlIPConfig.Controls.Add(Me.btnSaveIP)
        Me.pnlIPConfig.Controls.Add(Me.txtPort)
        Me.pnlIPConfig.Controls.Add(Me.lblPort)
        Me.pnlIPConfig.Controls.Add(Me.txtIP)
        Me.pnlIPConfig.Controls.Add(Me.lblIpAdress)
        Me.pnlIPConfig.Controls.Add(Me.lblIpConfig)
        Me.pnlIPConfig.Controls.Add(Me.Label13)
        Me.pnlIPConfig.ForeColor = System.Drawing.Color.White
        Me.pnlIPConfig.Location = New System.Drawing.Point(1143, 402)
        Me.pnlIPConfig.Name = "pnlIPConfig"
        Me.pnlIPConfig.Size = New System.Drawing.Size(400, 133)
        Me.pnlIPConfig.TabIndex = 51
        Me.pnlIPConfig.Visible = False
        '
        'btnSaveIP
        '
        Me.btnSaveIP.BackgroundImage = CType(resources.GetObject("btnSaveIP.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveIP.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveIP.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnSaveIP.Location = New System.Drawing.Point(157, 101)
        Me.btnSaveIP.Name = "btnSaveIP"
        Me.btnSaveIP.Size = New System.Drawing.Size(110, 22)
        Me.btnSaveIP.TabIndex = 50
        Me.btnSaveIP.Text = "Save IP"
        Me.btnSaveIP.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(157, 71)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPort.Size = New System.Drawing.Size(110, 20)
        Me.txtPort.TabIndex = 28
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort.Location = New System.Drawing.Point(84, 74)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(33, 15)
        Me.lblPort.TabIndex = 27
        Me.lblPort.Text = "Port:"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(157, 39)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(192, 20)
        Me.txtIP.TabIndex = 26
        '
        'lblIpAdress
        '
        Me.lblIpAdress.AutoSize = True
        Me.lblIpAdress.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIpAdress.Location = New System.Drawing.Point(84, 42)
        Me.lblIpAdress.Name = "lblIpAdress"
        Me.lblIpAdress.Size = New System.Drawing.Size(57, 15)
        Me.lblIpAdress.TabIndex = 25
        Me.lblIpAdress.Text = "IP Adres:"
        '
        'lblIpConfig
        '
        Me.lblIpConfig.BackColor = System.Drawing.Color.Transparent
        Me.lblIpConfig.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIpConfig.Location = New System.Drawing.Point(86, 4)
        Me.lblIpConfig.Name = "lblIpConfig"
        Me.lblIpConfig.Size = New System.Drawing.Size(247, 32)
        Me.lblIpConfig.TabIndex = 15
        Me.lblIpConfig.Text = "IPConfig"
        Me.lblIpConfig.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(70, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.BackgroundImage = CType(resources.GetObject("picLogo.BackgroundImage"), System.Drawing.Image)
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picLogo.Location = New System.Drawing.Point(77, 30)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(560, 144)
        Me.picLogo.TabIndex = 52
        Me.picLogo.TabStop = False
        '
        'btnPlay
        '
        Me.btnPlay.BackgroundImage = CType(resources.GetObject("btnPlay.BackgroundImage"), System.Drawing.Image)
        Me.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPlay.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.ForeColor = System.Drawing.Color.White
        Me.btnPlay.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPlay.Location = New System.Drawing.Point(142, 490)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(106, 37)
        Me.btnPlay.TabIndex = 53
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnRegister
        '
        Me.btnRegister.BackgroundImage = CType(resources.GetObject("btnRegister.BackgroundImage"), System.Drawing.Image)
        Me.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRegister.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnRegister.Location = New System.Drawing.Point(254, 490)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(106, 37)
        Me.btnRegister.TabIndex = 54
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'btnCredits
        '
        Me.btnCredits.BackgroundImage = CType(resources.GetObject("btnCredits.BackgroundImage"), System.Drawing.Image)
        Me.btnCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCredits.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCredits.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCredits.ForeColor = System.Drawing.Color.White
        Me.btnCredits.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCredits.Location = New System.Drawing.Point(366, 490)
        Me.btnCredits.Name = "btnCredits"
        Me.btnCredits.Size = New System.Drawing.Size(106, 37)
        Me.btnCredits.TabIndex = 55
        Me.btnCredits.Text = "Credits"
        Me.btnCredits.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnExit.Location = New System.Drawing.Point(478, 490)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(106, 37)
        Me.btnExit.TabIndex = 56
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'pnlCharSelect
        '
        Me.pnlCharSelect.BackColor = System.Drawing.Color.Transparent
        Me.pnlCharSelect.BackgroundImage = CType(resources.GetObject("pnlCharSelect.BackgroundImage"), System.Drawing.Image)
        Me.pnlCharSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCharSelect.Controls.Add(Me.btnUseChar)
        Me.pnlCharSelect.Controls.Add(Me.btnDelChar)
        Me.pnlCharSelect.Controls.Add(Me.btnNewChar)
        Me.pnlCharSelect.Controls.Add(Me.picChar3)
        Me.pnlCharSelect.Controls.Add(Me.picChar2)
        Me.pnlCharSelect.Controls.Add(Me.picChar1)
        Me.pnlCharSelect.Controls.Add(Me.lblCharSelect)
        Me.pnlCharSelect.Controls.Add(Me.Label16)
        Me.pnlCharSelect.ForeColor = System.Drawing.Color.White
        Me.pnlCharSelect.Location = New System.Drawing.Point(737, 342)
        Me.pnlCharSelect.Name = "pnlCharSelect"
        Me.pnlCharSelect.Size = New System.Drawing.Size(400, 192)
        Me.pnlCharSelect.TabIndex = 57
        Me.pnlCharSelect.Visible = False
        '
        'btnUseChar
        '
        Me.btnUseChar.BackgroundImage = CType(resources.GetObject("btnUseChar.BackgroundImage"), System.Drawing.Image)
        Me.btnUseChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUseChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUseChar.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUseChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnUseChar.Location = New System.Drawing.Point(147, 154)
        Me.btnUseChar.Name = "btnUseChar"
        Me.btnUseChar.Size = New System.Drawing.Size(110, 26)
        Me.btnUseChar.TabIndex = 52
        Me.btnUseChar.Text = "Use Character"
        Me.btnUseChar.UseVisualStyleBackColor = True
        '
        'btnDelChar
        '
        Me.btnDelChar.BackgroundImage = CType(resources.GetObject("btnDelChar.BackgroundImage"), System.Drawing.Image)
        Me.btnDelChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelChar.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnDelChar.Location = New System.Drawing.Point(263, 154)
        Me.btnDelChar.Name = "btnDelChar"
        Me.btnDelChar.Size = New System.Drawing.Size(119, 26)
        Me.btnDelChar.TabIndex = 51
        Me.btnDelChar.Text = "Delete Character"
        Me.btnDelChar.UseVisualStyleBackColor = True
        '
        'btnNewChar
        '
        Me.btnNewChar.BackgroundImage = CType(resources.GetObject("btnNewChar.BackgroundImage"), System.Drawing.Image)
        Me.btnNewChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNewChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewChar.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnNewChar.Location = New System.Drawing.Point(20, 154)
        Me.btnNewChar.Name = "btnNewChar"
        Me.btnNewChar.Size = New System.Drawing.Size(121, 26)
        Me.btnNewChar.TabIndex = 50
        Me.btnNewChar.Text = "New Character"
        Me.btnNewChar.UseVisualStyleBackColor = True
        '
        'picChar3
        '
        Me.picChar3.BackColor = System.Drawing.Color.Transparent
        Me.picChar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picChar3.Location = New System.Drawing.Point(300, 52)
        Me.picChar3.Name = "picChar3"
        Me.picChar3.Size = New System.Drawing.Size(48, 60)
        Me.picChar3.TabIndex = 44
        Me.picChar3.TabStop = False
        '
        'picChar2
        '
        Me.picChar2.BackColor = System.Drawing.Color.Transparent
        Me.picChar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picChar2.Location = New System.Drawing.Point(175, 52)
        Me.picChar2.Name = "picChar2"
        Me.picChar2.Size = New System.Drawing.Size(48, 60)
        Me.picChar2.TabIndex = 43
        Me.picChar2.TabStop = False
        '
        'picChar1
        '
        Me.picChar1.BackColor = System.Drawing.Color.Transparent
        Me.picChar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picChar1.Location = New System.Drawing.Point(52, 52)
        Me.picChar1.Name = "picChar1"
        Me.picChar1.Size = New System.Drawing.Size(48, 60)
        Me.picChar1.TabIndex = 42
        Me.picChar1.TabStop = False
        '
        'lblCharSelect
        '
        Me.lblCharSelect.BackColor = System.Drawing.Color.Transparent
        Me.lblCharSelect.Font = New System.Drawing.Font("Modern No. 20", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharSelect.Location = New System.Drawing.Point(44, 12)
        Me.lblCharSelect.Name = "lblCharSelect"
        Me.lblCharSelect.Size = New System.Drawing.Size(312, 33)
        Me.lblCharSelect.TabIndex = 15
        Me.lblCharSelect.Text = "Character Selection"
        Me.lblCharSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(70, 179)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLoad
        '
        Me.pnlLoad.BackgroundImage = CType(resources.GetObject("pnlLoad.BackgroundImage"), System.Drawing.Image)
        Me.pnlLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLoad.Controls.Add(Me.lblStatus)
        Me.pnlLoad.Location = New System.Drawing.Point(-2, 1)
        Me.pnlLoad.Name = "pnlLoad"
        Me.pnlLoad.Size = New System.Drawing.Size(54, 48)
        Me.pnlLoad.TabIndex = 58
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(224, 261)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(280, 30)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Loading text"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(708, 541)
        Me.Controls.Add(Me.pnlLoad)
        Me.Controls.Add(Me.pnlCharSelect)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCredits)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.pnlIPConfig)
        Me.Controls.Add(Me.lblServerStatus)
        Me.Controls.Add(Me.lblStatusHeader)
        Me.Controls.Add(Me.pnlCredits)
        Me.Controls.Add(Me.pnlRegister)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.pnlMainMenu)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.pnlNewChar)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMenu"
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.pnlRegister.ResumeLayout(False)
        Me.pnlRegister.PerformLayout()
        Me.pnlCredits.ResumeLayout(False)
        Me.pnlCredits.PerformLayout()
        Me.pnlNewChar.ResumeLayout(False)
        Me.pnlNewChar.PerformLayout()
        CType(Me.placeholderforsprite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainMenu.ResumeLayout(False)
        Me.pnlMainMenu.PerformLayout()
        Me.pnlIPConfig.ResumeLayout(False)
        Me.pnlIPConfig.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCharSelect.ResumeLayout(False)
        Me.pnlCharSelect.PerformLayout()
        CType(Me.picChar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoad.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents pnlLogin As System.Windows.Forms.Panel
    Friend WithEvents chkSavePass As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblLoginPass As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents lblLoginName As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents pnlRegister As System.Windows.Forms.Panel
    Friend WithEvents txtRPass2 As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAccPass2 As System.Windows.Forms.Label
    Friend WithEvents txtRPass As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAccPass As System.Windows.Forms.Label
    Friend WithEvents txtRuser As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAccName As System.Windows.Forms.Label
    Friend WithEvents lblNewAccount As System.Windows.Forms.Label
    Public WithEvents pnlCredits As System.Windows.Forms.Panel
    Friend WithEvents lblCreditsTop As System.Windows.Forms.Label
    Friend WithEvents lblScrollingCredits As System.Windows.Forms.Label
    Friend WithEvents tmrCredits As System.Windows.Forms.Timer
    Public WithEvents pnlNewChar As System.Windows.Forms.Panel
    Friend WithEvents placeholderforsprite As System.Windows.Forms.PictureBox
    Friend WithEvents lblNextChar As System.Windows.Forms.Label
    Friend WithEvents lblPrevChar As System.Windows.Forms.Label
    Friend WithEvents rdoFemale As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMale As System.Windows.Forms.RadioButton
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblNewCharGender As System.Windows.Forms.Label
    Friend WithEvents lblNewCharClass As System.Windows.Forms.Label
    Friend WithEvents txtCharName As System.Windows.Forms.TextBox
    Friend WithEvents lblNewCharName As System.Windows.Forms.Label
    Friend WithEvents lblNewChar As System.Windows.Forms.Label
    Friend WithEvents lblStatusHeader As System.Windows.Forms.Label
    Friend WithEvents lblServerStatus As System.Windows.Forms.Label
    Public WithEvents pnlMainMenu As System.Windows.Forms.Panel
    Friend WithEvents lblNewsHeader As System.Windows.Forms.Label
    Friend WithEvents lblNews As System.Windows.Forms.Label
    Public WithEvents pnlIPConfig As Windows.Forms.Panel
    Friend WithEvents txtPort As Windows.Forms.TextBox
    Friend WithEvents lblPort As Windows.Forms.Label
    Friend WithEvents txtIP As Windows.Forms.TextBox
    Friend WithEvents lblIpAdress As Windows.Forms.Label
    Friend WithEvents lblIpConfig As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents picLogo As Windows.Forms.PictureBox
    Friend WithEvents btnLogin As Windows.Forms.Button
    Friend WithEvents btnCreateAccount As Windows.Forms.Button
    Friend WithEvents btnPlay As Windows.Forms.Button
    Friend WithEvents btnRegister As Windows.Forms.Button
    Friend WithEvents btnCredits As Windows.Forms.Button
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents btnCreateCharacter As Windows.Forms.Button
    Friend WithEvents btnSaveIP As Windows.Forms.Button
    Public WithEvents pnlCharSelect As Windows.Forms.Panel
    Friend WithEvents lblCharSelect As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents picChar3 As Windows.Forms.PictureBox
    Friend WithEvents picChar2 As Windows.Forms.PictureBox
    Friend WithEvents picChar1 As Windows.Forms.PictureBox
    Friend WithEvents btnDelChar As Windows.Forms.Button
    Friend WithEvents btnNewChar As Windows.Forms.Button
    Friend WithEvents btnUseChar As Windows.Forms.Button
    Friend WithEvents txtDescription As Windows.Forms.TextBox
    Friend WithEvents lblNewCharSprite As Windows.Forms.Label
    Friend WithEvents pnlLoad As Windows.Forms.Panel
    Friend WithEvents lblStatus As Windows.Forms.Label
End Class
