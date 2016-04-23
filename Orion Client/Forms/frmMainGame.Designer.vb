<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainGame
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainGame))
        Me.picscreen = New System.Windows.Forms.PictureBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.scrlVolume = New System.Windows.Forms.HScrollBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optSOff = New System.Windows.Forms.RadioButton()
        Me.optSOn = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMOff = New System.Windows.Forms.RadioButton()
        Me.optMOn = New System.Windows.Forms.RadioButton()
        Me.pnlTmpInv = New System.Windows.Forms.Panel()
        Me.pnlCurrency = New System.Windows.Forms.Panel()
        Me.lblCurrencyCancel = New System.Windows.Forms.Label()
        Me.lblCurrencyOk = New System.Windows.Forms.Label()
        Me.txtCurrency = New System.Windows.Forms.TextBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.pnlShop = New System.Windows.Forms.Panel()
        Me.lblLeaveShop = New System.Windows.Forms.Label()
        Me.lblShopSell = New System.Windows.Forms.Label()
        Me.lblShopBuy = New System.Windows.Forms.Label()
        Me.pnlShopItems = New System.Windows.Forms.Panel()
        Me.lblShopName = New System.Windows.Forms.Label()
        Me.pnlBank = New System.Windows.Forms.Panel()
        Me.lblLeaveBank = New System.Windows.Forms.Label()
        Me.pnlTempBank = New System.Windows.Forms.Panel()
        Me.pnlTrade = New System.Windows.Forms.Panel()
        Me.lblTradeStatus = New System.Windows.Forms.Label()
        Me.lblDeclineTrade = New System.Windows.Forms.Label()
        Me.lblAcceptTrade = New System.Windows.Forms.Label()
        Me.lblTheirWorth = New System.Windows.Forms.Label()
        Me.lblYourWorth = New System.Windows.Forms.Label()
        Me.pnlTheirTrade = New System.Windows.Forms.Panel()
        Me.pnlYourTrade = New System.Windows.Forms.Panel()
        Me.lblTheirOffer = New System.Windows.Forms.Label()
        Me.lblYourOffer = New System.Windows.Forms.Label()
        Me.pnlMapreport = New System.Windows.Forms.Panel()
        Me.lstMaps = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblMapReportClose = New System.Windows.Forms.Label()
        Me.pnlQuestLog = New System.Windows.Forms.Panel()
        Me.lblQuestLogClose = New System.Windows.Forms.Label()
        Me.lblAbandonQuest = New System.Windows.Forms.Label()
        Me.lblQuestRewards = New System.Windows.Forms.Label()
        Me.lblQuestRequirements = New System.Windows.Forms.Label()
        Me.lblQuestStatus2 = New System.Windows.Forms.Label()
        Me.lblQuestStatus = New System.Windows.Forms.Label()
        Me.txtQuestDialog = New System.Windows.Forms.TextBox()
        Me.lblQuestDialog = New System.Windows.Forms.Label()
        Me.txtActualTask = New System.Windows.Forms.TextBox()
        Me.lblTaskLog = New System.Windows.Forms.Label()
        Me.lblActualTask = New System.Windows.Forms.Label()
        Me.lstQuestLog = New System.Windows.Forms.ListBox()
        Me.txtQuestTaskLog = New System.Windows.Forms.TextBox()
        Me.pnlQuestSpeech = New System.Windows.Forms.Panel()
        Me.lblQuestClose = New System.Windows.Forms.Label()
        Me.lblQuestSay = New System.Windows.Forms.Label()
        Me.lblQuestNameVisual = New System.Windows.Forms.Label()
        Me.lblQuestAccept = New System.Windows.Forms.Label()
        Me.lblQuestExtra = New System.Windows.Forms.Label()
        Me.pnlTmpSkill = New System.Windows.Forms.Panel()
        Me.tmrShake = New System.Windows.Forms.Timer(Me.components)
        Me.pnlEventChat = New System.Windows.Forms.Panel()
        Me.lblEventChat = New System.Windows.Forms.Label()
        Me.lblEventContinue = New System.Windows.Forms.Label()
        Me.lblResponse3 = New System.Windows.Forms.Label()
        Me.lblResponse4 = New System.Windows.Forms.Label()
        Me.lblResponse2 = New System.Windows.Forms.Label()
        Me.lblResponse1 = New System.Windows.Forms.Label()
        Me.picEventFace = New System.Windows.Forms.PictureBox()
        CType(Me.picscreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOptions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCurrency.SuspendLayout()
        Me.pnlShop.SuspendLayout()
        Me.pnlBank.SuspendLayout()
        Me.pnlTrade.SuspendLayout()
        Me.pnlMapreport.SuspendLayout()
        Me.pnlQuestLog.SuspendLayout()
        Me.pnlQuestSpeech.SuspendLayout()
        Me.pnlEventChat.SuspendLayout()
        CType(Me.picEventFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picscreen
        '
        Me.picscreen.Location = New System.Drawing.Point(0, 0)
        Me.picscreen.Name = "picscreen"
        Me.picscreen.Size = New System.Drawing.Size(1152, 864)
        Me.picscreen.TabIndex = 4
        Me.picscreen.TabStop = False
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.DimGray
        Me.pnlOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.lblVolume)
        Me.pnlOptions.Controls.Add(Me.scrlVolume)
        Me.pnlOptions.Controls.Add(Me.GroupBox2)
        Me.pnlOptions.Controls.Add(Me.GroupBox1)
        Me.pnlOptions.ForeColor = System.Drawing.Color.White
        Me.pnlOptions.Location = New System.Drawing.Point(22, 147)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(204, 275)
        Me.pnlOptions.TabIndex = 10
        Me.pnlOptions.Visible = False
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.BackColor = System.Drawing.Color.Transparent
        Me.lblVolume.ForeColor = System.Drawing.Color.White
        Me.lblVolume.Location = New System.Drawing.Point(15, 120)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(48, 13)
        Me.lblVolume.TabIndex = 11
        Me.lblVolume.Text = "Volume: "
        '
        'scrlVolume
        '
        Me.scrlVolume.LargeChange = 1
        Me.scrlVolume.Location = New System.Drawing.Point(15, 135)
        Me.scrlVolume.Name = "scrlVolume"
        Me.scrlVolume.Size = New System.Drawing.Size(172, 17)
        Me.scrlVolume.TabIndex = 10
        Me.scrlVolume.Value = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSOff)
        Me.GroupBox2.Controls.Add(Me.optSOn)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(11, 53)
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
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
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
        'pnlTmpInv
        '
        Me.pnlTmpInv.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTmpInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTmpInv.Location = New System.Drawing.Point(979, 491)
        Me.pnlTmpInv.Name = "pnlTmpInv"
        Me.pnlTmpInv.Size = New System.Drawing.Size(32, 32)
        Me.pnlTmpInv.TabIndex = 15
        Me.pnlTmpInv.Visible = False
        '
        'pnlCurrency
        '
        Me.pnlCurrency.BackColor = System.Drawing.Color.Black
        Me.pnlCurrency.Controls.Add(Me.lblCurrencyCancel)
        Me.pnlCurrency.Controls.Add(Me.lblCurrencyOk)
        Me.pnlCurrency.Controls.Add(Me.txtCurrency)
        Me.pnlCurrency.Controls.Add(Me.lblCurrency)
        Me.pnlCurrency.Location = New System.Drawing.Point(477, 692)
        Me.pnlCurrency.Name = "pnlCurrency"
        Me.pnlCurrency.Size = New System.Drawing.Size(480, 121)
        Me.pnlCurrency.TabIndex = 16
        Me.pnlCurrency.Visible = False
        '
        'lblCurrencyCancel
        '
        Me.lblCurrencyCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrencyCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyCancel.ForeColor = System.Drawing.Color.White
        Me.lblCurrencyCancel.Location = New System.Drawing.Point(147, 82)
        Me.lblCurrencyCancel.Name = "lblCurrencyCancel"
        Me.lblCurrencyCancel.Size = New System.Drawing.Size(180, 16)
        Me.lblCurrencyCancel.TabIndex = 4
        Me.lblCurrencyCancel.Text = "Cancel"
        Me.lblCurrencyCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrencyOk
        '
        Me.lblCurrencyOk.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrencyOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyOk.ForeColor = System.Drawing.Color.White
        Me.lblCurrencyOk.Location = New System.Drawing.Point(147, 66)
        Me.lblCurrencyOk.Name = "lblCurrencyOk"
        Me.lblCurrencyOk.Size = New System.Drawing.Size(180, 16)
        Me.lblCurrencyOk.TabIndex = 3
        Me.lblCurrencyOk.Text = "Okay"
        Me.lblCurrencyOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrency
        '
        Me.txtCurrency.Location = New System.Drawing.Point(147, 43)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(180, 20)
        Me.txtCurrency.TabIndex = 2
        '
        'lblCurrency
        '
        Me.lblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrency.ForeColor = System.Drawing.Color.White
        Me.lblCurrency.Location = New System.Drawing.Point(3, 16)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(474, 24)
        Me.lblCurrency.TabIndex = 1
        Me.lblCurrency.Text = "How many do you want to drop?"
        Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlShop
        '
        Me.pnlShop.BackgroundImage = CType(resources.GetObject("pnlShop.BackgroundImage"), System.Drawing.Image)
        Me.pnlShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlShop.Controls.Add(Me.lblLeaveShop)
        Me.pnlShop.Controls.Add(Me.lblShopSell)
        Me.pnlShop.Controls.Add(Me.lblShopBuy)
        Me.pnlShop.Controls.Add(Me.pnlShopItems)
        Me.pnlShop.Controls.Add(Me.lblShopName)
        Me.pnlShop.Location = New System.Drawing.Point(364, 55)
        Me.pnlShop.Name = "pnlShop"
        Me.pnlShop.Size = New System.Drawing.Size(280, 290)
        Me.pnlShop.TabIndex = 18
        Me.pnlShop.Visible = False
        '
        'lblLeaveShop
        '
        Me.lblLeaveShop.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveShop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeaveShop.ForeColor = System.Drawing.Color.White
        Me.lblLeaveShop.Location = New System.Drawing.Point(18, 245)
        Me.lblLeaveShop.Name = "lblLeaveShop"
        Me.lblLeaveShop.Size = New System.Drawing.Size(237, 18)
        Me.lblLeaveShop.TabIndex = 5
        Me.lblLeaveShop.Text = "Leave"
        Me.lblLeaveShop.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblShopSell
        '
        Me.lblShopSell.BackColor = System.Drawing.Color.Transparent
        Me.lblShopSell.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopSell.ForeColor = System.Drawing.Color.White
        Me.lblShopSell.Location = New System.Drawing.Point(18, 227)
        Me.lblShopSell.Name = "lblShopSell"
        Me.lblShopSell.Size = New System.Drawing.Size(237, 18)
        Me.lblShopSell.TabIndex = 4
        Me.lblShopSell.Text = "Sell Item"
        Me.lblShopSell.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblShopBuy
        '
        Me.lblShopBuy.BackColor = System.Drawing.Color.Transparent
        Me.lblShopBuy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopBuy.ForeColor = System.Drawing.Color.White
        Me.lblShopBuy.Location = New System.Drawing.Point(18, 210)
        Me.lblShopBuy.Name = "lblShopBuy"
        Me.lblShopBuy.Size = New System.Drawing.Size(237, 18)
        Me.lblShopBuy.TabIndex = 3
        Me.lblShopBuy.Text = "Buy Item"
        Me.lblShopBuy.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlShopItems
        '
        Me.pnlShopItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlShopItems.Location = New System.Drawing.Point(24, 36)
        Me.pnlShopItems.Name = "pnlShopItems"
        Me.pnlShopItems.Size = New System.Drawing.Size(231, 173)
        Me.pnlShopItems.TabIndex = 2
        '
        'lblShopName
        '
        Me.lblShopName.BackColor = System.Drawing.Color.Transparent
        Me.lblShopName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopName.ForeColor = System.Drawing.Color.White
        Me.lblShopName.Location = New System.Drawing.Point(3, 2)
        Me.lblShopName.Name = "lblShopName"
        Me.lblShopName.Size = New System.Drawing.Size(274, 35)
        Me.lblShopName.TabIndex = 1
        Me.lblShopName.Text = "Shop"
        Me.lblShopName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBank
        '
        Me.pnlBank.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlBank.Controls.Add(Me.lblLeaveBank)
        Me.pnlBank.Location = New System.Drawing.Point(319, 105)
        Me.pnlBank.Name = "pnlBank"
        Me.pnlBank.Size = New System.Drawing.Size(368, 368)
        Me.pnlBank.TabIndex = 19
        Me.pnlBank.Visible = False
        '
        'lblLeaveBank
        '
        Me.lblLeaveBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeaveBank.Location = New System.Drawing.Point(155, 342)
        Me.lblLeaveBank.Name = "lblLeaveBank"
        Me.lblLeaveBank.Size = New System.Drawing.Size(67, 18)
        Me.lblLeaveBank.TabIndex = 6
        Me.lblLeaveBank.Text = "Leave"
        Me.lblLeaveBank.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTempBank
        '
        Me.pnlTempBank.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTempBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTempBank.Location = New System.Drawing.Point(976, 601)
        Me.pnlTempBank.Name = "pnlTempBank"
        Me.pnlTempBank.Size = New System.Drawing.Size(32, 32)
        Me.pnlTempBank.TabIndex = 20
        Me.pnlTempBank.Visible = False
        '
        'pnlTrade
        '
        Me.pnlTrade.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlTrade.BackgroundImage = CType(resources.GetObject("pnlTrade.BackgroundImage"), System.Drawing.Image)
        Me.pnlTrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTrade.Controls.Add(Me.lblTradeStatus)
        Me.pnlTrade.Controls.Add(Me.lblDeclineTrade)
        Me.pnlTrade.Controls.Add(Me.lblAcceptTrade)
        Me.pnlTrade.Controls.Add(Me.lblTheirWorth)
        Me.pnlTrade.Controls.Add(Me.lblYourWorth)
        Me.pnlTrade.Controls.Add(Me.pnlTheirTrade)
        Me.pnlTrade.Controls.Add(Me.pnlYourTrade)
        Me.pnlTrade.Controls.Add(Me.lblTheirOffer)
        Me.pnlTrade.Controls.Add(Me.lblYourOffer)
        Me.pnlTrade.Location = New System.Drawing.Point(297, 102)
        Me.pnlTrade.Name = "pnlTrade"
        Me.pnlTrade.Size = New System.Drawing.Size(408, 344)
        Me.pnlTrade.TabIndex = 21
        Me.pnlTrade.Visible = False
        '
        'lblTradeStatus
        '
        Me.lblTradeStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblTradeStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTradeStatus.Location = New System.Drawing.Point(3, 305)
        Me.lblTradeStatus.Name = "lblTradeStatus"
        Me.lblTradeStatus.Size = New System.Drawing.Size(402, 17)
        Me.lblTradeStatus.TabIndex = 8
        Me.lblTradeStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDeclineTrade
        '
        Me.lblDeclineTrade.BackColor = System.Drawing.Color.Transparent
        Me.lblDeclineTrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeclineTrade.ForeColor = System.Drawing.Color.Red
        Me.lblDeclineTrade.Location = New System.Drawing.Point(205, 322)
        Me.lblDeclineTrade.Name = "lblDeclineTrade"
        Me.lblDeclineTrade.Size = New System.Drawing.Size(56, 16)
        Me.lblDeclineTrade.TabIndex = 7
        Me.lblDeclineTrade.Text = "Decline"
        '
        'lblAcceptTrade
        '
        Me.lblAcceptTrade.BackColor = System.Drawing.Color.Transparent
        Me.lblAcceptTrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptTrade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAcceptTrade.Location = New System.Drawing.Point(150, 322)
        Me.lblAcceptTrade.Name = "lblAcceptTrade"
        Me.lblAcceptTrade.Size = New System.Drawing.Size(49, 16)
        Me.lblAcceptTrade.TabIndex = 6
        Me.lblAcceptTrade.Text = "Accept"
        Me.lblAcceptTrade.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTheirWorth
        '
        Me.lblTheirWorth.BackColor = System.Drawing.Color.Transparent
        Me.lblTheirWorth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTheirWorth.ForeColor = System.Drawing.Color.White
        Me.lblTheirWorth.Location = New System.Drawing.Point(208, 288)
        Me.lblTheirWorth.Name = "lblTheirWorth"
        Me.lblTheirWorth.Size = New System.Drawing.Size(193, 16)
        Me.lblTheirWorth.TabIndex = 5
        Me.lblTheirWorth.Text = "Total Worth: 0g"
        Me.lblTheirWorth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblYourWorth
        '
        Me.lblYourWorth.BackColor = System.Drawing.Color.Transparent
        Me.lblYourWorth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYourWorth.ForeColor = System.Drawing.Color.White
        Me.lblYourWorth.Location = New System.Drawing.Point(8, 288)
        Me.lblYourWorth.Name = "lblYourWorth"
        Me.lblYourWorth.Size = New System.Drawing.Size(193, 16)
        Me.lblYourWorth.TabIndex = 4
        Me.lblYourWorth.Text = "Total Worth: 0g"
        Me.lblYourWorth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTheirTrade
        '
        Me.pnlTheirTrade.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTheirTrade.Location = New System.Drawing.Point(208, 24)
        Me.pnlTheirTrade.Name = "pnlTheirTrade"
        Me.pnlTheirTrade.Size = New System.Drawing.Size(191, 261)
        Me.pnlTheirTrade.TabIndex = 3
        '
        'pnlYourTrade
        '
        Me.pnlYourTrade.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlYourTrade.Location = New System.Drawing.Point(8, 24)
        Me.pnlYourTrade.Name = "pnlYourTrade"
        Me.pnlYourTrade.Size = New System.Drawing.Size(191, 261)
        Me.pnlYourTrade.TabIndex = 2
        '
        'lblTheirOffer
        '
        Me.lblTheirOffer.BackColor = System.Drawing.Color.Transparent
        Me.lblTheirOffer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTheirOffer.ForeColor = System.Drawing.Color.White
        Me.lblTheirOffer.Location = New System.Drawing.Point(208, 8)
        Me.lblTheirOffer.Name = "lblTheirOffer"
        Me.lblTheirOffer.Size = New System.Drawing.Size(193, 16)
        Me.lblTheirOffer.TabIndex = 1
        Me.lblTheirOffer.Text = "[Name]'s Offer"
        Me.lblTheirOffer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblYourOffer
        '
        Me.lblYourOffer.BackColor = System.Drawing.Color.Transparent
        Me.lblYourOffer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYourOffer.ForeColor = System.Drawing.Color.White
        Me.lblYourOffer.Location = New System.Drawing.Point(8, 8)
        Me.lblYourOffer.Name = "lblYourOffer"
        Me.lblYourOffer.Size = New System.Drawing.Size(193, 16)
        Me.lblYourOffer.TabIndex = 0
        Me.lblYourOffer.Text = "Your Offer"
        Me.lblYourOffer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlMapreport
        '
        Me.pnlMapreport.BackColor = System.Drawing.Color.Transparent
        Me.pnlMapreport.BackgroundImage = CType(resources.GetObject("pnlMapreport.BackgroundImage"), System.Drawing.Image)
        Me.pnlMapreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMapreport.Controls.Add(Me.lstMaps)
        Me.pnlMapreport.Controls.Add(Me.lblMapReportClose)
        Me.pnlMapreport.Location = New System.Drawing.Point(22, 146)
        Me.pnlMapreport.Name = "pnlMapreport"
        Me.pnlMapreport.Size = New System.Drawing.Size(204, 275)
        Me.pnlMapreport.TabIndex = 28
        Me.pnlMapreport.Visible = False
        '
        'lstMaps
        '
        Me.lstMaps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstMaps.FullRowSelect = True
        Me.lstMaps.GridLines = True
        Me.lstMaps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMaps.HideSelection = False
        Me.lstMaps.Location = New System.Drawing.Point(13, 10)
        Me.lstMaps.MultiSelect = False
        Me.lstMaps.Name = "lstMaps"
        Me.lstMaps.Size = New System.Drawing.Size(175, 243)
        Me.lstMaps.TabIndex = 4
        Me.lstMaps.UseCompatibleStateImageBehavior = False
        Me.lstMaps.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 120
        '
        'lblMapReportClose
        '
        Me.lblMapReportClose.AutoSize = True
        Me.lblMapReportClose.ForeColor = System.Drawing.Color.White
        Me.lblMapReportClose.Location = New System.Drawing.Point(73, 255)
        Me.lblMapReportClose.Name = "lblMapReportClose"
        Me.lblMapReportClose.Size = New System.Drawing.Size(33, 13)
        Me.lblMapReportClose.TabIndex = 1
        Me.lblMapReportClose.Text = "Close"
        '
        'pnlQuestLog
        '
        Me.pnlQuestLog.BackColor = System.Drawing.Color.Transparent
        Me.pnlQuestLog.BackgroundImage = CType(resources.GetObject("pnlQuestLog.BackgroundImage"), System.Drawing.Image)
        Me.pnlQuestLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlQuestLog.Controls.Add(Me.lblQuestLogClose)
        Me.pnlQuestLog.Controls.Add(Me.lblAbandonQuest)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestRewards)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestRequirements)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestStatus2)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestStatus)
        Me.pnlQuestLog.Controls.Add(Me.txtQuestDialog)
        Me.pnlQuestLog.Controls.Add(Me.lblQuestDialog)
        Me.pnlQuestLog.Controls.Add(Me.txtActualTask)
        Me.pnlQuestLog.Controls.Add(Me.lblTaskLog)
        Me.pnlQuestLog.Controls.Add(Me.lblActualTask)
        Me.pnlQuestLog.Controls.Add(Me.lstQuestLog)
        Me.pnlQuestLog.Controls.Add(Me.txtQuestTaskLog)
        Me.pnlQuestLog.Location = New System.Drawing.Point(232, 97)
        Me.pnlQuestLog.Name = "pnlQuestLog"
        Me.pnlQuestLog.Size = New System.Drawing.Size(478, 382)
        Me.pnlQuestLog.TabIndex = 38
        Me.pnlQuestLog.Visible = False
        '
        'lblQuestLogClose
        '
        Me.lblQuestLogClose.AutoSize = True
        Me.lblQuestLogClose.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestLogClose.ForeColor = System.Drawing.Color.White
        Me.lblQuestLogClose.Location = New System.Drawing.Point(197, 360)
        Me.lblQuestLogClose.Name = "lblQuestLogClose"
        Me.lblQuestLogClose.Size = New System.Drawing.Size(82, 13)
        Me.lblQuestLogClose.TabIndex = 14
        Me.lblQuestLogClose.Text = "Close QuestLog"
        '
        'lblAbandonQuest
        '
        Me.lblAbandonQuest.AutoSize = True
        Me.lblAbandonQuest.BackColor = System.Drawing.Color.Transparent
        Me.lblAbandonQuest.ForeColor = System.Drawing.Color.Red
        Me.lblAbandonQuest.Location = New System.Drawing.Point(390, 360)
        Me.lblAbandonQuest.Name = "lblAbandonQuest"
        Me.lblAbandonQuest.Size = New System.Drawing.Size(81, 13)
        Me.lblAbandonQuest.TabIndex = 13
        Me.lblAbandonQuest.Text = "Abandon Quest"
        Me.lblAbandonQuest.Visible = False
        '
        'lblQuestRewards
        '
        Me.lblQuestRewards.AutoSize = True
        Me.lblQuestRewards.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestRewards.ForeColor = System.Drawing.Color.White
        Me.lblQuestRewards.Location = New System.Drawing.Point(197, 317)
        Me.lblQuestRewards.Name = "lblQuestRewards"
        Me.lblQuestRewards.Size = New System.Drawing.Size(52, 13)
        Me.lblQuestRewards.TabIndex = 12
        Me.lblQuestRewards.Text = "Rewards:"
        '
        'lblQuestRequirements
        '
        Me.lblQuestRequirements.AutoSize = True
        Me.lblQuestRequirements.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestRequirements.ForeColor = System.Drawing.Color.White
        Me.lblQuestRequirements.Location = New System.Drawing.Point(197, 290)
        Me.lblQuestRequirements.Name = "lblQuestRequirements"
        Me.lblQuestRequirements.Size = New System.Drawing.Size(75, 13)
        Me.lblQuestRequirements.TabIndex = 10
        Me.lblQuestRequirements.Text = "Requirements:"
        '
        'lblQuestStatus2
        '
        Me.lblQuestStatus2.AutoSize = True
        Me.lblQuestStatus2.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestStatus2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblQuestStatus2.Location = New System.Drawing.Point(274, 265)
        Me.lblQuestStatus2.Name = "lblQuestStatus2"
        Me.lblQuestStatus2.Size = New System.Drawing.Size(25, 13)
        Me.lblQuestStatus2.TabIndex = 9
        Me.lblQuestStatus2.Text = "???"
        '
        'lblQuestStatus
        '
        Me.lblQuestStatus.AutoSize = True
        Me.lblQuestStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestStatus.ForeColor = System.Drawing.Color.White
        Me.lblQuestStatus.Location = New System.Drawing.Point(197, 265)
        Me.lblQuestStatus.Name = "lblQuestStatus"
        Me.lblQuestStatus.Size = New System.Drawing.Size(71, 13)
        Me.lblQuestStatus.TabIndex = 8
        Me.lblQuestStatus.Text = "Quest Status:"
        '
        'txtQuestDialog
        '
        Me.txtQuestDialog.BackColor = System.Drawing.Color.Black
        Me.txtQuestDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuestDialog.ForeColor = System.Drawing.Color.White
        Me.txtQuestDialog.Location = New System.Drawing.Point(197, 211)
        Me.txtQuestDialog.Multiline = True
        Me.txtQuestDialog.Name = "txtQuestDialog"
        Me.txtQuestDialog.ReadOnly = True
        Me.txtQuestDialog.Size = New System.Drawing.Size(268, 51)
        Me.txtQuestDialog.TabIndex = 7
        '
        'lblQuestDialog
        '
        Me.lblQuestDialog.AutoSize = True
        Me.lblQuestDialog.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestDialog.ForeColor = System.Drawing.Color.White
        Me.lblQuestDialog.Location = New System.Drawing.Point(200, 195)
        Me.lblQuestDialog.Name = "lblQuestDialog"
        Me.lblQuestDialog.Size = New System.Drawing.Size(91, 13)
        Me.lblQuestDialog.TabIndex = 6
        Me.lblQuestDialog.Text = "Last Quest Dialog"
        '
        'txtActualTask
        '
        Me.txtActualTask.BackColor = System.Drawing.Color.Black
        Me.txtActualTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualTask.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtActualTask.Location = New System.Drawing.Point(197, 139)
        Me.txtActualTask.Multiline = True
        Me.txtActualTask.Name = "txtActualTask"
        Me.txtActualTask.ReadOnly = True
        Me.txtActualTask.Size = New System.Drawing.Size(268, 51)
        Me.txtActualTask.TabIndex = 5
        '
        'lblTaskLog
        '
        Me.lblTaskLog.AutoSize = True
        Me.lblTaskLog.BackColor = System.Drawing.Color.Transparent
        Me.lblTaskLog.ForeColor = System.Drawing.Color.White
        Me.lblTaskLog.Location = New System.Drawing.Point(200, 5)
        Me.lblTaskLog.Name = "lblTaskLog"
        Me.lblTaskLog.Size = New System.Drawing.Size(52, 13)
        Me.lblTaskLog.TabIndex = 4
        Me.lblTaskLog.Text = "Task Log"
        '
        'lblActualTask
        '
        Me.lblActualTask.AutoSize = True
        Me.lblActualTask.BackColor = System.Drawing.Color.Transparent
        Me.lblActualTask.ForeColor = System.Drawing.Color.White
        Me.lblActualTask.Location = New System.Drawing.Point(197, 123)
        Me.lblActualTask.Name = "lblActualTask"
        Me.lblActualTask.Size = New System.Drawing.Size(64, 13)
        Me.lblActualTask.TabIndex = 3
        Me.lblActualTask.Text = "Actual Task"
        '
        'lstQuestLog
        '
        Me.lstQuestLog.BackColor = System.Drawing.Color.Black
        Me.lstQuestLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstQuestLog.ForeColor = System.Drawing.Color.White
        Me.lstQuestLog.FormattingEnabled = True
        Me.lstQuestLog.Location = New System.Drawing.Point(3, 5)
        Me.lstQuestLog.Name = "lstQuestLog"
        Me.lstQuestLog.Size = New System.Drawing.Size(188, 366)
        Me.lstQuestLog.TabIndex = 2
        '
        'txtQuestTaskLog
        '
        Me.txtQuestTaskLog.BackColor = System.Drawing.Color.Black
        Me.txtQuestTaskLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuestTaskLog.ForeColor = System.Drawing.Color.Green
        Me.txtQuestTaskLog.Location = New System.Drawing.Point(197, 22)
        Me.txtQuestTaskLog.Multiline = True
        Me.txtQuestTaskLog.Name = "txtQuestTaskLog"
        Me.txtQuestTaskLog.ReadOnly = True
        Me.txtQuestTaskLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuestTaskLog.Size = New System.Drawing.Size(268, 95)
        Me.txtQuestTaskLog.TabIndex = 1
        '
        'pnlQuestSpeech
        '
        Me.pnlQuestSpeech.BackColor = System.Drawing.Color.Black
        Me.pnlQuestSpeech.Controls.Add(Me.lblQuestClose)
        Me.pnlQuestSpeech.Controls.Add(Me.lblQuestSay)
        Me.pnlQuestSpeech.Controls.Add(Me.lblQuestNameVisual)
        Me.pnlQuestSpeech.Controls.Add(Me.lblQuestAccept)
        Me.pnlQuestSpeech.Controls.Add(Me.lblQuestExtra)
        Me.pnlQuestSpeech.Location = New System.Drawing.Point(248, 429)
        Me.pnlQuestSpeech.Name = "pnlQuestSpeech"
        Me.pnlQuestSpeech.Size = New System.Drawing.Size(479, 106)
        Me.pnlQuestSpeech.TabIndex = 39
        Me.pnlQuestSpeech.Visible = False
        '
        'lblQuestClose
        '
        Me.lblQuestClose.AutoSize = True
        Me.lblQuestClose.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblQuestClose.Location = New System.Drawing.Point(433, 87)
        Me.lblQuestClose.Name = "lblQuestClose"
        Me.lblQuestClose.Size = New System.Drawing.Size(43, 15)
        Me.lblQuestClose.TabIndex = 3
        Me.lblQuestClose.Text = "Close"
        '
        'lblQuestSay
        '
        Me.lblQuestSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestSay.ForeColor = System.Drawing.Color.White
        Me.lblQuestSay.Location = New System.Drawing.Point(3, 25)
        Me.lblQuestSay.Name = "lblQuestSay"
        Me.lblQuestSay.Size = New System.Drawing.Size(469, 49)
        Me.lblQuestSay.TabIndex = 1
        Me.lblQuestSay.Text = "..."
        '
        'lblQuestNameVisual
        '
        Me.lblQuestNameVisual.BackColor = System.Drawing.Color.Black
        Me.lblQuestNameVisual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestNameVisual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblQuestNameVisual.Location = New System.Drawing.Point(81, 2)
        Me.lblQuestNameVisual.Name = "lblQuestNameVisual"
        Me.lblQuestNameVisual.Size = New System.Drawing.Size(315, 23)
        Me.lblQuestNameVisual.TabIndex = 0
        Me.lblQuestNameVisual.Text = "Quest Name"
        Me.lblQuestNameVisual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQuestAccept
        '
        Me.lblQuestAccept.AutoSize = True
        Me.lblQuestAccept.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestAccept.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblQuestAccept.Location = New System.Drawing.Point(3, 87)
        Me.lblQuestAccept.Name = "lblQuestAccept"
        Me.lblQuestAccept.Size = New System.Drawing.Size(90, 15)
        Me.lblQuestAccept.TabIndex = 2
        Me.lblQuestAccept.Text = "Accept Quest"
        '
        'lblQuestExtra
        '
        Me.lblQuestExtra.AutoSize = True
        Me.lblQuestExtra.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestExtra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblQuestExtra.Location = New System.Drawing.Point(3, 87)
        Me.lblQuestExtra.Name = "lblQuestExtra"
        Me.lblQuestExtra.Size = New System.Drawing.Size(40, 15)
        Me.lblQuestExtra.TabIndex = 4
        Me.lblQuestExtra.Text = "Extra"
        Me.lblQuestExtra.Visible = False
        '
        'pnlTmpSkill
        '
        Me.pnlTmpSkill.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.pnlTmpSkill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTmpSkill.Location = New System.Drawing.Point(995, 541)
        Me.pnlTmpSkill.Name = "pnlTmpSkill"
        Me.pnlTmpSkill.Size = New System.Drawing.Size(32, 32)
        Me.pnlTmpSkill.TabIndex = 42
        Me.pnlTmpSkill.Visible = False
        '
        'tmrShake
        '
        Me.tmrShake.Interval = 50
        '
        'pnlEventChat
        '
        Me.pnlEventChat.BackColor = System.Drawing.Color.Black
        Me.pnlEventChat.BackgroundImage = CType(resources.GetObject("pnlEventChat.BackgroundImage"), System.Drawing.Image)
        Me.pnlEventChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlEventChat.Controls.Add(Me.lblEventChat)
        Me.pnlEventChat.Controls.Add(Me.lblEventContinue)
        Me.pnlEventChat.Controls.Add(Me.lblResponse3)
        Me.pnlEventChat.Controls.Add(Me.lblResponse4)
        Me.pnlEventChat.Controls.Add(Me.lblResponse2)
        Me.pnlEventChat.Controls.Add(Me.lblResponse1)
        Me.pnlEventChat.Controls.Add(Me.picEventFace)
        Me.pnlEventChat.Location = New System.Drawing.Point(251, 253)
        Me.pnlEventChat.Name = "pnlEventChat"
        Me.pnlEventChat.Size = New System.Drawing.Size(480, 175)
        Me.pnlEventChat.TabIndex = 43
        Me.pnlEventChat.Visible = False
        '
        'lblEventChat
        '
        Me.lblEventChat.BackColor = System.Drawing.Color.Transparent
        Me.lblEventChat.ForeColor = System.Drawing.Color.White
        Me.lblEventChat.Location = New System.Drawing.Point(113, 14)
        Me.lblEventChat.Name = "lblEventChat"
        Me.lblEventChat.Size = New System.Drawing.Size(356, 92)
        Me.lblEventChat.TabIndex = 6
        Me.lblEventChat.Text = "chat"
        '
        'lblEventContinue
        '
        Me.lblEventContinue.AutoSize = True
        Me.lblEventContinue.BackColor = System.Drawing.Color.Transparent
        Me.lblEventContinue.ForeColor = System.Drawing.Color.White
        Me.lblEventContinue.Location = New System.Drawing.Point(423, 156)
        Me.lblEventContinue.Name = "lblEventContinue"
        Me.lblEventContinue.Size = New System.Drawing.Size(49, 13)
        Me.lblEventContinue.TabIndex = 5
        Me.lblEventContinue.Text = "Continue"
        '
        'lblResponse3
        '
        Me.lblResponse3.AutoSize = True
        Me.lblResponse3.BackColor = System.Drawing.Color.Transparent
        Me.lblResponse3.ForeColor = System.Drawing.Color.White
        Me.lblResponse3.Location = New System.Drawing.Point(226, 124)
        Me.lblResponse3.Name = "lblResponse3"
        Me.lblResponse3.Size = New System.Drawing.Size(51, 13)
        Me.lblResponse3.TabIndex = 4
        Me.lblResponse3.Text = "reponse3"
        '
        'lblResponse4
        '
        Me.lblResponse4.AutoSize = True
        Me.lblResponse4.BackColor = System.Drawing.Color.Transparent
        Me.lblResponse4.ForeColor = System.Drawing.Color.White
        Me.lblResponse4.Location = New System.Drawing.Point(226, 146)
        Me.lblResponse4.Name = "lblResponse4"
        Me.lblResponse4.Size = New System.Drawing.Size(51, 13)
        Me.lblResponse4.TabIndex = 3
        Me.lblResponse4.Text = "reponse4"
        '
        'lblResponse2
        '
        Me.lblResponse2.AutoSize = True
        Me.lblResponse2.BackColor = System.Drawing.Color.Transparent
        Me.lblResponse2.ForeColor = System.Drawing.Color.White
        Me.lblResponse2.Location = New System.Drawing.Point(10, 146)
        Me.lblResponse2.Name = "lblResponse2"
        Me.lblResponse2.Size = New System.Drawing.Size(51, 13)
        Me.lblResponse2.TabIndex = 2
        Me.lblResponse2.Text = "reponse2"
        '
        'lblResponse1
        '
        Me.lblResponse1.AutoSize = True
        Me.lblResponse1.BackColor = System.Drawing.Color.Transparent
        Me.lblResponse1.ForeColor = System.Drawing.Color.White
        Me.lblResponse1.Location = New System.Drawing.Point(10, 124)
        Me.lblResponse1.Name = "lblResponse1"
        Me.lblResponse1.Size = New System.Drawing.Size(51, 13)
        Me.lblResponse1.TabIndex = 1
        Me.lblResponse1.Text = "reponse1"
        '
        'picEventFace
        '
        Me.picEventFace.BackColor = System.Drawing.Color.Transparent
        Me.picEventFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picEventFace.Location = New System.Drawing.Point(13, 12)
        Me.picEventFace.Name = "picEventFace"
        Me.picEventFace.Size = New System.Drawing.Size(94, 94)
        Me.picEventFace.TabIndex = 0
        Me.picEventFace.TabStop = False
        '
        'frmMainGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1152, 864)
        Me.Controls.Add(Me.picscreen)
        Me.Controls.Add(Me.pnlEventChat)
        Me.Controls.Add(Me.pnlMapreport)
        Me.Controls.Add(Me.pnlQuestLog)
        Me.Controls.Add(Me.pnlCurrency)
        Me.Controls.Add(Me.pnlQuestSpeech)
        Me.Controls.Add(Me.pnlBank)
        Me.Controls.Add(Me.pnlTempBank)
        Me.Controls.Add(Me.pnlTmpInv)
        Me.Controls.Add(Me.pnlTmpSkill)
        Me.Controls.Add(Me.pnlTrade)
        Me.Controls.Add(Me.pnlShop)
        Me.Controls.Add(Me.pnlOptions)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMainGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMainGame"
        CType(Me.picscreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCurrency.ResumeLayout(False)
        Me.pnlCurrency.PerformLayout()
        Me.pnlShop.ResumeLayout(False)
        Me.pnlBank.ResumeLayout(False)
        Me.pnlTrade.ResumeLayout(False)
        Me.pnlMapreport.ResumeLayout(False)
        Me.pnlMapreport.PerformLayout()
        Me.pnlQuestLog.ResumeLayout(False)
        Me.pnlQuestLog.PerformLayout()
        Me.pnlQuestSpeech.ResumeLayout(False)
        Me.pnlQuestSpeech.PerformLayout()
        Me.pnlEventChat.ResumeLayout(False)
        Me.pnlEventChat.PerformLayout()
        CType(Me.picEventFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picscreen As System.Windows.Forms.PictureBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents optMOff As System.Windows.Forms.RadioButton
    Friend WithEvents optMOn As System.Windows.Forms.RadioButton
    Friend WithEvents optSOff As System.Windows.Forms.RadioButton
    Friend WithEvents optSOn As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTmpInv As System.Windows.Forms.Panel
    Friend WithEvents pnlCurrency As System.Windows.Forms.Panel
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyCancel As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyOk As System.Windows.Forms.Label
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents pnlShop As System.Windows.Forms.Panel
    Friend WithEvents pnlShopItems As System.Windows.Forms.Panel
    Friend WithEvents lblShopName As System.Windows.Forms.Label
    Friend WithEvents lblLeaveShop As System.Windows.Forms.Label
    Friend WithEvents lblShopSell As System.Windows.Forms.Label
    Friend WithEvents lblShopBuy As System.Windows.Forms.Label
    Friend WithEvents pnlBank As System.Windows.Forms.Panel
    Friend WithEvents lblLeaveBank As System.Windows.Forms.Label
    Friend WithEvents pnlTempBank As System.Windows.Forms.Panel
    Friend WithEvents pnlTrade As System.Windows.Forms.Panel
    Friend WithEvents pnlYourTrade As System.Windows.Forms.Panel
    Friend WithEvents lblTheirOffer As System.Windows.Forms.Label
    Friend WithEvents lblYourOffer As System.Windows.Forms.Label
    Friend WithEvents lblDeclineTrade As System.Windows.Forms.Label
    Friend WithEvents lblAcceptTrade As System.Windows.Forms.Label
    Friend WithEvents lblTheirWorth As System.Windows.Forms.Label
    Friend WithEvents lblYourWorth As System.Windows.Forms.Label
    Friend WithEvents pnlTheirTrade As System.Windows.Forms.Panel
    Friend WithEvents lblTradeStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMapreport As Windows.Forms.Panel
    Friend WithEvents lstMaps As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents lblMapReportClose As Windows.Forms.Label
    Friend WithEvents pnlQuestLog As Windows.Forms.Panel
    Friend WithEvents lblQuestLogClose As Windows.Forms.Label
    Friend WithEvents lblAbandonQuest As Windows.Forms.Label
    Friend WithEvents lblQuestRewards As Windows.Forms.Label
    Friend WithEvents lblQuestRequirements As Windows.Forms.Label
    Friend WithEvents lblQuestStatus2 As Windows.Forms.Label
    Friend WithEvents lblQuestStatus As Windows.Forms.Label
    Friend WithEvents txtQuestDialog As Windows.Forms.TextBox
    Friend WithEvents lblQuestDialog As Windows.Forms.Label
    Friend WithEvents txtActualTask As Windows.Forms.TextBox
    Friend WithEvents lblTaskLog As Windows.Forms.Label
    Friend WithEvents lblActualTask As Windows.Forms.Label
    Friend WithEvents lstQuestLog As Windows.Forms.ListBox
    Friend WithEvents txtQuestTaskLog As Windows.Forms.TextBox
    Friend WithEvents pnlQuestSpeech As Windows.Forms.Panel
    Friend WithEvents lblQuestClose As Windows.Forms.Label
    Friend WithEvents lblQuestSay As Windows.Forms.Label
    Friend WithEvents lblQuestNameVisual As Windows.Forms.Label
    Friend WithEvents lblQuestAccept As Windows.Forms.Label
    Friend WithEvents lblQuestExtra As Windows.Forms.Label
    Friend WithEvents pnlTmpSkill As Windows.Forms.Panel
    Friend WithEvents tmrShake As Windows.Forms.Timer
    Friend WithEvents lblVolume As Windows.Forms.Label
    Friend WithEvents scrlVolume As Windows.Forms.HScrollBar
    Friend WithEvents pnlEventChat As Windows.Forms.Panel
    Friend WithEvents picEventFace As Windows.Forms.PictureBox
    Friend WithEvents lblResponse3 As Windows.Forms.Label
    Friend WithEvents lblResponse4 As Windows.Forms.Label
    Friend WithEvents lblResponse2 As Windows.Forms.Label
    Friend WithEvents lblResponse1 As Windows.Forms.Label
    Friend WithEvents lblEventContinue As Windows.Forms.Label
    Friend WithEvents lblEventChat As Windows.Forms.Label
End Class
