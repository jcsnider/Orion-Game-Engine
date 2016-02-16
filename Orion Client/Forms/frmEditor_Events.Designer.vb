<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Events
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Messages", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Events Progressing", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Flow Control", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Player Options", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Movement", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Animation", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Questing", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Show Text")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Show Choices")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Add Chatbox Text")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Show ChatBubble")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Player Variable")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Player Switch")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Self Switch")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Conditional Branch")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Exit Event Process")
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Label")
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("GoTo Label")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Items")
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Restore HP")
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Restore MP")
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Level Up")
        Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Level")
        Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Skills")
        Dim ListViewItem18 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Class")
        Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Sprite")
        Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Gender")
        Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change PK")
        Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Give Experience")
        Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Warp Player")
        Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Move Route")
        Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait for Route Completion")
        Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Force Spawn Npc")
        Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Hold Player")
        Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Release Player")
        Me.pnlVariableSwitches = New System.Windows.Forms.Panel()
        Me.fraLabeling = New System.Windows.Forms.GroupBox()
        Me.btnLabel_Cancel = New System.Windows.Forms.Button()
        Me.btnLabel_Ok = New System.Windows.Forms.Button()
        Me.btnRenameSwitch = New System.Windows.Forms.Button()
        Me.btnRenameVariable = New System.Windows.Forms.Button()
        Me.lstSwitches = New System.Windows.Forms.ListBox()
        Me.lstVariables = New System.Windows.Forms.ListBox()
        Me.lblRandomLabel36 = New System.Windows.Forms.Label()
        Me.lblRandomLabel25 = New System.Windows.Forms.Label()
        Me.FraRenaming = New System.Windows.Forms.GroupBox()
        Me.btnRename_Cancel = New System.Windows.Forms.Button()
        Me.btnRename_Ok = New System.Windows.Forms.Button()
        Me.fraRandom10 = New System.Windows.Forms.GroupBox()
        Me.txtRename = New System.Windows.Forms.TextBox()
        Me.lblEditing = New System.Windows.Forms.Label()
        Me.fraGraphic = New System.Windows.Forms.GroupBox()
        Me.btnGraphicCancel = New System.Windows.Forms.Button()
        Me.btnGraphicOk = New System.Windows.Forms.Button()
        Me.hScrlGraphicSel = New System.Windows.Forms.HScrollBar()
        Me.vScrlGraphicSel = New System.Windows.Forms.VScrollBar()
        Me.picGraphicSel = New System.Windows.Forms.PictureBox()
        Me.lblGraphic = New System.Windows.Forms.Label()
        Me.scrlGraphic = New System.Windows.Forms.HScrollBar()
        Me.cmbGraphic = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel33 = New System.Windows.Forms.Label()
        Me.pnlMoveRoute = New System.Windows.Forms.Panel()
        Me.fraMoveRoute = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel15 = New System.Windows.Forms.Label()
        Me.chkRepeatRoute = New System.Windows.Forms.CheckBox()
        Me.chkIgnoreMove = New System.Windows.Forms.CheckBox()
        Me.btnMoveRouteCancel = New System.Windows.Forms.Button()
        Me.btnMoveRouteOk = New System.Windows.Forms.Button()
        Me.fraRandom14 = New System.Windows.Forms.GroupBox()
        Me.btnAddMoveRoute43 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute42 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute41 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute40 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute39 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute38 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute37 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute36 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute35 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute34 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute33 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute32 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute31 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute30 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute29 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute28 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute27 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute26 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute25 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute24 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute23 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute22 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute21 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute20 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute19 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute18 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute17 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute16 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute15 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute14 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute13 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute12 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute11 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute10 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute9 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute8 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute7 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute6 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute5 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute4 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute3 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute2 = New System.Windows.Forms.Button()
        Me.btnAddMoveRoute1 = New System.Windows.Forms.Button()
        Me.lstMoveRoute = New System.Windows.Forms.ListBox()
        Me.cmbEvent = New System.Windows.Forms.ComboBox()
        Me.tabPages = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.frarandom20 = New System.Windows.Forms.GroupBox()
        Me.btnClearPage = New System.Windows.Forms.Button()
        Me.btnDeletePage = New System.Windows.Forms.Button()
        Me.btnPastePage = New System.Windows.Forms.Button()
        Me.btnCopyPage = New System.Windows.Forms.Button()
        Me.btnNewPage = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblRandomlabel32 = New System.Windows.Forms.Label()
        Me.btnLabeling = New System.Windows.Forms.Button()
        Me.fraDialogue = New System.Windows.Forms.GroupBox()
        Me.fraCommand7 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok29 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel29 = New System.Windows.Forms.Button()
        Me.fraConditions_Quest = New System.Windows.Forms.GroupBox()
        Me.lblCondition_QuestTask = New System.Windows.Forms.Label()
        Me.optCondition_Quest1 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRandomLabel50 = New System.Windows.Forms.Label()
        Me.optCondition_Quest0 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_General = New System.Windows.Forms.ComboBox()
        Me.scrlCondition_QuestTask = New System.Windows.Forms.HScrollBar()
        Me.lblConditionQuest = New System.Windows.Forms.Label()
        Me.optCondition_Index7 = New System.Windows.Forms.RadioButton()
        Me.optCondition_Index6 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel2 = New System.Windows.Forms.Label()
        Me.optCondition_Index5 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_LearntSkill = New System.Windows.Forms.ComboBox()
        Me.optCondition_Index4 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_ClassIs = New System.Windows.Forms.ComboBox()
        Me.optCondition_Index3 = New System.Windows.Forms.RadioButton()
        Me.scrlCondition_Quest = New System.Windows.Forms.HScrollBar()
        Me.scrlCondition_HasItem = New System.Windows.Forms.HScrollBar()
        Me.lblHasItemAmt = New System.Windows.Forms.Label()
        Me.optCondition_Index2 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel35 = New System.Windows.Forms.Label()
        Me.lblRandomLabel1 = New System.Windows.Forms.Label()
        Me.cmbCondition_SelfSwitchCondition = New System.Windows.Forms.ComboBox()
        Me.cmbCondtion_PlayerSwitchCondition = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_LevelCompare = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_HasItem = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_SelfSwitch = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_PlayerSwitch = New System.Windows.Forms.ComboBox()
        Me.optCondition_Index1 = New System.Windows.Forms.RadioButton()
        Me.txtCondition_LevelAmount = New System.Windows.Forms.TextBox()
        Me.txtCondition_PlayerVarCondition = New System.Windows.Forms.TextBox()
        Me.cmbCondition_PlayerVarCompare = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel0 = New System.Windows.Forms.Label()
        Me.cmbCondition_PlayerVarIndex = New System.Windows.Forms.ComboBox()
        Me.optCondition_Index0 = New System.Windows.Forms.RadioButton()
        Me.fraCommand27 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok26 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel26 = New System.Windows.Forms.Button()
        Me.scrlWaitAmount = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel44 = New System.Windows.Forms.Label()
        Me.lblWaitAmount = New System.Windows.Forms.Label()
        Me.fraCommand23 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok22 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel22 = New System.Windows.Forms.Button()
        Me.scrlWeatherIntensity = New System.Windows.Forms.HScrollBar()
        Me.lblWeatherIntensity = New System.Windows.Forms.Label()
        Me.CmbWeather = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel43 = New System.Windows.Forms.Label()
        Me.fraCommand18 = New System.Windows.Forms.GroupBox()
        Me.cmbWarpPlayerDir = New System.Windows.Forms.ComboBox()
        Me.scrlWPY = New System.Windows.Forms.HScrollBar()
        Me.lblWPY = New System.Windows.Forms.Label()
        Me.lblWPX = New System.Windows.Forms.Label()
        Me.scrlWPX = New System.Windows.Forms.HScrollBar()
        Me.btnCommand_Ok17 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel17 = New System.Windows.Forms.Button()
        Me.lblWPMap = New System.Windows.Forms.Label()
        Me.scrlWPMap = New System.Windows.Forms.HScrollBar()
        Me.fraCommand34 = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel58 = New System.Windows.Forms.Label()
        Me.btnCommand_Ok34 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel34 = New System.Windows.Forms.Button()
        Me.cmbHidePic = New System.Windows.Forms.ComboBox()
        Me.fraCommand35 = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel59 = New System.Windows.Forms.Label()
        Me.btnCommand_Ok35 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel35 = New System.Windows.Forms.Button()
        Me.cmbMoveWait = New System.Windows.Forms.ComboBox()
        Me.fraCommand20 = New System.Windows.Forms.GroupBox()
        Me.fraCommand29 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok28 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel28 = New System.Windows.Forms.Button()
        Me.scrlCustomScript = New System.Windows.Forms.HScrollBar()
        Me.lblCustomScript = New System.Windows.Forms.Label()
        Me.cmbPlayAnimEvent = New System.Windows.Forms.ComboBox()
        Me.lblPlayAnimY = New System.Windows.Forms.Label()
        Me.scrlPlayAnimTileY = New System.Windows.Forms.HScrollBar()
        Me.cmbPlayAnim = New System.Windows.Forms.ComboBox()
        Me.btnCommand_Ok19 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel19 = New System.Windows.Forms.Button()
        Me.optPlayAnimTile = New System.Windows.Forms.RadioButton()
        Me.optPlayAnimEvent = New System.Windows.Forms.RadioButton()
        Me.optPlayAnimPlayer = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel31 = New System.Windows.Forms.Label()
        Me.lblPlayAnimX = New System.Windows.Forms.Label()
        Me.scrlPlayAnimTileX = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel30 = New System.Windows.Forms.Label()
        Me.fraCommand31 = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel46 = New System.Windows.Forms.Label()
        Me.btnCommand_Ok31 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel31 = New System.Windows.Forms.Button()
        Me.cmbEndQuest = New System.Windows.Forms.ComboBox()
        Me.fraCommand30 = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel45 = New System.Windows.Forms.Label()
        Me.btnCommand_Ok32 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel32 = New System.Windows.Forms.Button()
        Me.cmbBeginQuest = New System.Windows.Forms.ComboBox()
        Me.fraCommand28 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok27 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel27 = New System.Windows.Forms.Button()
        Me.cmbSetAccess = New System.Windows.Forms.ComboBox()
        Me.fraCommand25 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok24 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel24 = New System.Windows.Forms.Button()
        Me.cmbPlayBGM = New System.Windows.Forms.ComboBox()
        Me.fraCommand24 = New System.Windows.Forms.GroupBox()
        Me.scrlMapTintData3 = New System.Windows.Forms.HScrollBar()
        Me.lblMapTintData3 = New System.Windows.Forms.Label()
        Me.scrlMapTintData2 = New System.Windows.Forms.HScrollBar()
        Me.lblMapTintData2 = New System.Windows.Forms.Label()
        Me.lblMapTintData1 = New System.Windows.Forms.Label()
        Me.scrlMapTintData1 = New System.Windows.Forms.HScrollBar()
        Me.btnCommand_Ok23 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel23 = New System.Windows.Forms.Button()
        Me.lblMapTintData0 = New System.Windows.Forms.Label()
        Me.scrlMapTintData0 = New System.Windows.Forms.HScrollBar()
        Me.fraCommand22 = New System.Windows.Forms.GroupBox()
        Me.ScrlFogData2 = New System.Windows.Forms.HScrollBar()
        Me.lblFogData2 = New System.Windows.Forms.Label()
        Me.lblFogData1 = New System.Windows.Forms.Label()
        Me.ScrlFogData1 = New System.Windows.Forms.HScrollBar()
        Me.btnCommand_Ok21 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel21 = New System.Windows.Forms.Button()
        Me.lblFogData0 = New System.Windows.Forms.Label()
        Me.ScrlFogData0 = New System.Windows.Forms.HScrollBar()
        Me.fraCommand26 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok25 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel25 = New System.Windows.Forms.Button()
        Me.cmbPlaySound = New System.Windows.Forms.ComboBox()
        Me.fraCommand21 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok20 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel20 = New System.Windows.Forms.Button()
        Me.cmbOpenShop = New System.Windows.Forms.ComboBox()
        Me.fraCommand19 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok18 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel18 = New System.Windows.Forms.Button()
        Me.cmbSpawnNPC = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel42 = New System.Windows.Forms.Label()
        Me.fraCommand3 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok3 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel3 = New System.Windows.Forms.Button()
        Me.cmbChatBubbleTarget = New System.Windows.Forms.ComboBox()
        Me.optChatBubbleTarget2 = New System.Windows.Forms.RadioButton()
        Me.optChatBubbleTarget1 = New System.Windows.Forms.RadioButton()
        Me.optChatBubbleTarget0 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel39 = New System.Windows.Forms.Label()
        Me.txtChatbubbleText = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel38 = New System.Windows.Forms.Label()
        Me.fraCommand2 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok2 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel2 = New System.Windows.Forms.Button()
        Me.optAddText_Global = New System.Windows.Forms.RadioButton()
        Me.optAddText_Map = New System.Windows.Forms.RadioButton()
        Me.optAddText_Player = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel10 = New System.Windows.Forms.Label()
        Me.lblAddText_Colour = New System.Windows.Forms.Label()
        Me.scrlAddText_Colour = New System.Windows.Forms.HScrollBar()
        Me.txtAddText_Text = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel34 = New System.Windows.Forms.Label()
        Me.fraCommand33 = New System.Windows.Forms.GroupBox()
        Me.txtPicOffset2 = New System.Windows.Forms.TextBox()
        Me.txtPicOffset1 = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel57 = New System.Windows.Forms.Label()
        Me.lblRandomLabel56 = New System.Windows.Forms.Label()
        Me.lblRandomLabel55 = New System.Windows.Forms.Label()
        Me.optPic3 = New System.Windows.Forms.RadioButton()
        Me.optPic2 = New System.Windows.Forms.RadioButton()
        Me.optPic1 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel54 = New System.Windows.Forms.Label()
        Me.lblRandomLabel53 = New System.Windows.Forms.Label()
        Me.btnCommand_Ok33 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel33 = New System.Windows.Forms.Button()
        Me.scrlShowPicture = New System.Windows.Forms.HScrollBar()
        Me.lblShowPic = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbPicIndex = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel52 = New System.Windows.Forms.Label()
        Me.fraCommand1 = New System.Windows.Forms.GroupBox()
        Me.txtChoices4 = New System.Windows.Forms.TextBox()
        Me.txtChoices3 = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel21 = New System.Windows.Forms.Label()
        Me.lblRandomLabel20 = New System.Windows.Forms.Label()
        Me.txtChoices2 = New System.Windows.Forms.TextBox()
        Me.txtChoices1 = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel19 = New System.Windows.Forms.Label()
        Me.lblRandomLabel17 = New System.Windows.Forms.Label()
        Me.btnCommand_Ok1 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel1 = New System.Windows.Forms.Button()
        Me.scrlShowChoicesFace = New System.Windows.Forms.HScrollBar()
        Me.lblShowChoicesFace = New System.Windows.Forms.Label()
        Me.picShowChoicesFace = New System.Windows.Forms.PictureBox()
        Me.txtChoicePrompt = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel16 = New System.Windows.Forms.Label()
        Me.fraCommand0 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok0 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel0 = New System.Windows.Forms.Button()
        Me.scrlShowTextFace = New System.Windows.Forms.HScrollBar()
        Me.lblShowTextFace = New System.Windows.Forms.Label()
        Me.picShowTextFace = New System.Windows.Forms.PictureBox()
        Me.txtShowText = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel18 = New System.Windows.Forms.Label()
        Me.fraCommand17 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok16 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel16 = New System.Windows.Forms.Button()
        Me.lblGiveExp = New System.Windows.Forms.Label()
        Me.scrlGiveExp = New System.Windows.Forms.HScrollBar()
        Me.fraCommand16 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok15 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel15 = New System.Windows.Forms.Button()
        Me.optChangePKNo = New System.Windows.Forms.RadioButton()
        Me.optChangePKYes = New System.Windows.Forms.RadioButton()
        Me.fraCommand15 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok14 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel14 = New System.Windows.Forms.Button()
        Me.optChangeSexFemale = New System.Windows.Forms.RadioButton()
        Me.optChangeSexMale = New System.Windows.Forms.RadioButton()
        Me.fraCommand14 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok13 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel13 = New System.Windows.Forms.Button()
        Me.scrlChangeSprite = New System.Windows.Forms.HScrollBar()
        Me.lblChangeSprite = New System.Windows.Forms.Label()
        Me.fraCommand13 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok12 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel12 = New System.Windows.Forms.Button()
        Me.cmbChangeClass = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel29 = New System.Windows.Forms.Label()
        Me.fraCommand12 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok11 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel11 = New System.Windows.Forms.Button()
        Me.optChangeSkillsRemove = New System.Windows.Forms.RadioButton()
        Me.optChangeSkillsAdd = New System.Windows.Forms.RadioButton()
        Me.cmbChangeSkills = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel28 = New System.Windows.Forms.Label()
        Me.fraCommand11 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok10 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel10 = New System.Windows.Forms.Button()
        Me.scrlChangeLevel = New System.Windows.Forms.HScrollBar()
        Me.lblChangeLevel = New System.Windows.Forms.Label()
        Me.fraCommand10 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok9 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel9 = New System.Windows.Forms.Button()
        Me.txtChangeItemsAmount = New System.Windows.Forms.TextBox()
        Me.optChangeItemRemove = New System.Windows.Forms.RadioButton()
        Me.optChangeItemAdd = New System.Windows.Forms.RadioButton()
        Me.optChangeItemSet = New System.Windows.Forms.RadioButton()
        Me.cmbChangeItemIndex = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel27 = New System.Windows.Forms.Label()
        Me.fraCommand6 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok6 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel6 = New System.Windows.Forms.Button()
        Me.lblRandomLabel26 = New System.Windows.Forms.Label()
        Me.lblRandomLabel24 = New System.Windows.Forms.Label()
        Me.cmbSetSelfSwitchTo = New System.Windows.Forms.ComboBox()
        Me.cmbSetSelfSwitch = New System.Windows.Forms.ComboBox()
        Me.fraCommand5 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok5 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel5 = New System.Windows.Forms.Button()
        Me.lblRandomLabel22 = New System.Windows.Forms.Label()
        Me.lblRandomLabel23 = New System.Windows.Forms.Label()
        Me.cmbPlayerSwitchSet = New System.Windows.Forms.ComboBox()
        Me.cmbSwitch = New System.Windows.Forms.ComboBox()
        Me.fraCommand9 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok8 = New System.Windows.Forms.Button()
        Me.txtGotoLabel = New System.Windows.Forms.TextBox()
        Me.btnCommand_Cancel8 = New System.Windows.Forms.Button()
        Me.lblRandomLabel41 = New System.Windows.Forms.Label()
        Me.fraCommand8 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok7 = New System.Windows.Forms.Button()
        Me.txtLabelName = New System.Windows.Forms.TextBox()
        Me.btnCommand_Cancel7 = New System.Windows.Forms.Button()
        Me.lblRandomLabel40 = New System.Windows.Forms.Label()
        Me.fraCommand32 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok30 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel30 = New System.Windows.Forms.Button()
        Me.scrlCompleteQuestTask = New System.Windows.Forms.HScrollBar()
        Me.scrlCompleteQuestTaskQuest = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel48 = New System.Windows.Forms.Label()
        Me.lblRandomLabel47 = New System.Windows.Forms.Label()
        Me.fraCommand4 = New System.Windows.Forms.GroupBox()
        Me.btnCommand_Ok4 = New System.Windows.Forms.Button()
        Me.btnCommand_Cancel4 = New System.Windows.Forms.Button()
        Me.lblRandomLabel37 = New System.Windows.Forms.Label()
        Me.lblRandomLabel13 = New System.Windows.Forms.Label()
        Me.txtVariableData4 = New System.Windows.Forms.TextBox()
        Me.txtVariableData3 = New System.Windows.Forms.TextBox()
        Me.optVariableAction3 = New System.Windows.Forms.RadioButton()
        Me.txtVariableData2 = New System.Windows.Forms.TextBox()
        Me.optVariableAction2 = New System.Windows.Forms.RadioButton()
        Me.txtVariableData1 = New System.Windows.Forms.TextBox()
        Me.optVariableAction1 = New System.Windows.Forms.RadioButton()
        Me.txtVariableData0 = New System.Windows.Forms.TextBox()
        Me.optVariableAction0 = New System.Windows.Forms.RadioButton()
        Me.cmbVariable = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel = New System.Windows.Forms.Label()
        Me.lblRandomLabel11 = New System.Windows.Forms.Label()
        Me.lblRandomLabel14 = New System.Windows.Forms.Label()
        Me.fraCommands = New System.Windows.Forms.Panel()
        Me.lstvCommands = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancelCommand = New System.Windows.Forms.Button()
        Me.tabCommands = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.fraRandom2 = New System.Windows.Forms.GroupBox()
        Me.btnCommands10 = New System.Windows.Forms.Button()
        Me.btnCommands9 = New System.Windows.Forms.Button()
        Me.btnCommands8 = New System.Windows.Forms.Button()
        Me.btnCommands7 = New System.Windows.Forms.Button()
        Me.fraRandom1 = New System.Windows.Forms.GroupBox()
        Me.btnCommands6 = New System.Windows.Forms.Button()
        Me.btnCommands5 = New System.Windows.Forms.Button()
        Me.btnCommands4 = New System.Windows.Forms.Button()
        Me.fraRandom3 = New System.Windows.Forms.GroupBox()
        Me.btnCommands21 = New System.Windows.Forms.Button()
        Me.btnCommands20 = New System.Windows.Forms.Button()
        Me.btnCommands19 = New System.Windows.Forms.Button()
        Me.btnCommands18 = New System.Windows.Forms.Button()
        Me.btnCommands17 = New System.Windows.Forms.Button()
        Me.btnCommands16 = New System.Windows.Forms.Button()
        Me.btnCommands15 = New System.Windows.Forms.Button()
        Me.btnCommands14 = New System.Windows.Forms.Button()
        Me.btnCommands13 = New System.Windows.Forms.Button()
        Me.btnCommands12 = New System.Windows.Forms.Button()
        Me.btnCommands11 = New System.Windows.Forms.Button()
        Me.fraRandom21 = New System.Windows.Forms.GroupBox()
        Me.btnCommands3 = New System.Windows.Forms.Button()
        Me.btnCommands2 = New System.Windows.Forms.Button()
        Me.btnCommands1 = New System.Windows.Forms.Button()
        Me.btnCommands0 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.fraRandom8 = New System.Windows.Forms.GroupBox()
        Me.btnCommands41 = New System.Windows.Forms.Button()
        Me.btnCommands40 = New System.Windows.Forms.Button()
        Me.btnCommands39 = New System.Windows.Forms.Button()
        Me.frarandom7 = New System.Windows.Forms.GroupBox()
        Me.btnCommands38 = New System.Windows.Forms.Button()
        Me.btnCommands37 = New System.Windows.Forms.Button()
        Me.btnCommands36 = New System.Windows.Forms.Button()
        Me.btnCommands35 = New System.Windows.Forms.Button()
        Me.fraRandom12 = New System.Windows.Forms.GroupBox()
        Me.btnCommands34 = New System.Windows.Forms.Button()
        Me.btnCommands33 = New System.Windows.Forms.Button()
        Me.btnCommands32 = New System.Windows.Forms.Button()
        Me.frarandom25 = New System.Windows.Forms.GroupBox()
        Me.btnCommands31 = New System.Windows.Forms.Button()
        Me.btnCommands30 = New System.Windows.Forms.Button()
        Me.btnCommands29 = New System.Windows.Forms.Button()
        Me.fraRandom5 = New System.Windows.Forms.GroupBox()
        Me.btnCommands28 = New System.Windows.Forms.Button()
        Me.fraRandom4 = New System.Windows.Forms.GroupBox()
        Me.btnCommands27 = New System.Windows.Forms.Button()
        Me.btnCommands26 = New System.Windows.Forms.Button()
        Me.btnCommands25 = New System.Windows.Forms.Button()
        Me.btnCommands24 = New System.Windows.Forms.Button()
        Me.btnCommands23 = New System.Windows.Forms.Button()
        Me.btnCommands22 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.fraRandom6 = New System.Windows.Forms.GroupBox()
        Me.btnCommands49 = New System.Windows.Forms.Button()
        Me.btnCommands48 = New System.Windows.Forms.Button()
        Me.btnCommands47 = New System.Windows.Forms.Button()
        Me.fraRandom11 = New System.Windows.Forms.GroupBox()
        Me.btnCommands46 = New System.Windows.Forms.Button()
        Me.btnCommands45 = New System.Windows.Forms.Button()
        Me.btnCommands44 = New System.Windows.Forms.Button()
        Me.btnCommands43 = New System.Windows.Forms.Button()
        Me.btnCommands42 = New System.Windows.Forms.Button()
        Me.fraRandom17 = New System.Windows.Forms.GroupBox()
        Me.chkGlobal = New System.Windows.Forms.CheckBox()
        Me.fraRandom16 = New System.Windows.Forms.GroupBox()
        Me.chkShowName = New System.Windows.Forms.CheckBox()
        Me.chkWalkThrough = New System.Windows.Forms.CheckBox()
        Me.chkDirFix = New System.Windows.Forms.CheckBox()
        Me.chkWalkAnim = New System.Windows.Forms.CheckBox()
        Me.fraRandom18 = New System.Windows.Forms.GroupBox()
        Me.cmbTrigger = New System.Windows.Forms.ComboBox()
        Me.fraRandom19 = New System.Windows.Forms.GroupBox()
        Me.cmbPositioning = New System.Windows.Forms.ComboBox()
        Me.fraRandom15 = New System.Windows.Forms.GroupBox()
        Me.cmbMoveFreq = New System.Windows.Forms.ComboBox()
        Me.cmbMoveSpeed = New System.Windows.Forms.ComboBox()
        Me.btnMoveRoute = New System.Windows.Forms.Button()
        Me.cmbMoveType = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel8 = New System.Windows.Forms.Label()
        Me.lblRandomLabel7 = New System.Windows.Forms.Label()
        Me.lblRandomLabel6 = New System.Windows.Forms.Label()
        Me.frarandom13 = New System.Windows.Forms.GroupBox()
        Me.picGraphic = New System.Windows.Forms.PictureBox()
        Me.fraRandom0 = New System.Windows.Forms.GroupBox()
        Me.cmbSelfSwitchCompare = New System.Windows.Forms.ComboBox()
        Me.cmbPlayerSwitchCompare = New System.Windows.Forms.ComboBox()
        Me.txtPlayerVariable = New System.Windows.Forms.TextBox()
        Me.cmbPlayervarCompare = New System.Windows.Forms.ComboBox()
        Me.lblRandomlabel4 = New System.Windows.Forms.Label()
        Me.lblRandomlabel3 = New System.Windows.Forms.Label()
        Me.lblRandomLabel5 = New System.Windows.Forms.Label()
        Me.cmbSelfSwitch = New System.Windows.Forms.ComboBox()
        Me.cmbHasItem = New System.Windows.Forms.ComboBox()
        Me.cmbPlayerSwitch = New System.Windows.Forms.ComboBox()
        Me.cmbPlayerVar = New System.Windows.Forms.ComboBox()
        Me.chkSelfSwitch = New System.Windows.Forms.CheckBox()
        Me.chkHasItem = New System.Windows.Forms.CheckBox()
        Me.chkPlayerSwitch = New System.Windows.Forms.CheckBox()
        Me.chkPlayerVar = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fraRandom9 = New System.Windows.Forms.GroupBox()
        Me.btnClearCommand = New System.Windows.Forms.Button()
        Me.btnDeleteComand = New System.Windows.Forms.Button()
        Me.btnEditCommand = New System.Windows.Forms.Button()
        Me.btnAddCommand = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEventQuest = New System.Windows.Forms.ComboBox()
        Me.lstCommands = New System.Windows.Forms.ListBox()
        Me.pnlVariableSwitches.SuspendLayout()
        Me.fraLabeling.SuspendLayout()
        Me.FraRenaming.SuspendLayout()
        Me.fraRandom10.SuspendLayout()
        Me.fraGraphic.SuspendLayout()
        CType(Me.picGraphicSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMoveRoute.SuspendLayout()
        Me.fraMoveRoute.SuspendLayout()
        Me.fraRandom14.SuspendLayout()
        Me.tabPages.SuspendLayout()
        Me.frarandom20.SuspendLayout()
        Me.fraDialogue.SuspendLayout()
        Me.fraCommand7.SuspendLayout()
        Me.fraConditions_Quest.SuspendLayout()
        Me.fraCommand27.SuspendLayout()
        Me.fraCommand23.SuspendLayout()
        Me.fraCommand18.SuspendLayout()
        Me.fraCommand34.SuspendLayout()
        Me.fraCommand35.SuspendLayout()
        Me.fraCommand20.SuspendLayout()
        Me.fraCommand29.SuspendLayout()
        Me.fraCommand31.SuspendLayout()
        Me.fraCommand30.SuspendLayout()
        Me.fraCommand28.SuspendLayout()
        Me.fraCommand25.SuspendLayout()
        Me.fraCommand24.SuspendLayout()
        Me.fraCommand22.SuspendLayout()
        Me.fraCommand26.SuspendLayout()
        Me.fraCommand21.SuspendLayout()
        Me.fraCommand19.SuspendLayout()
        Me.fraCommand3.SuspendLayout()
        Me.fraCommand2.SuspendLayout()
        Me.fraCommand33.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCommand1.SuspendLayout()
        CType(Me.picShowChoicesFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCommand0.SuspendLayout()
        CType(Me.picShowTextFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCommand17.SuspendLayout()
        Me.fraCommand16.SuspendLayout()
        Me.fraCommand15.SuspendLayout()
        Me.fraCommand14.SuspendLayout()
        Me.fraCommand13.SuspendLayout()
        Me.fraCommand12.SuspendLayout()
        Me.fraCommand11.SuspendLayout()
        Me.fraCommand10.SuspendLayout()
        Me.fraCommand6.SuspendLayout()
        Me.fraCommand5.SuspendLayout()
        Me.fraCommand9.SuspendLayout()
        Me.fraCommand8.SuspendLayout()
        Me.fraCommand32.SuspendLayout()
        Me.fraCommand4.SuspendLayout()
        Me.fraCommands.SuspendLayout()
        Me.tabCommands.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.fraRandom2.SuspendLayout()
        Me.fraRandom1.SuspendLayout()
        Me.fraRandom3.SuspendLayout()
        Me.fraRandom21.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.fraRandom8.SuspendLayout()
        Me.frarandom7.SuspendLayout()
        Me.fraRandom12.SuspendLayout()
        Me.frarandom25.SuspendLayout()
        Me.fraRandom5.SuspendLayout()
        Me.fraRandom4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.fraRandom6.SuspendLayout()
        Me.fraRandom11.SuspendLayout()
        Me.fraRandom17.SuspendLayout()
        Me.fraRandom16.SuspendLayout()
        Me.fraRandom18.SuspendLayout()
        Me.fraRandom19.SuspendLayout()
        Me.fraRandom15.SuspendLayout()
        Me.frarandom13.SuspendLayout()
        CType(Me.picGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraRandom0.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.fraRandom9.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVariableSwitches
        '
        Me.pnlVariableSwitches.Controls.Add(Me.fraLabeling)
        Me.pnlVariableSwitches.Controls.Add(Me.FraRenaming)
        Me.pnlVariableSwitches.Location = New System.Drawing.Point(5, 4)
        Me.pnlVariableSwitches.Name = "pnlVariableSwitches"
        Me.pnlVariableSwitches.Size = New System.Drawing.Size(827, 636)
        Me.pnlVariableSwitches.TabIndex = 1
        '
        'fraLabeling
        '
        Me.fraLabeling.Controls.Add(Me.btnLabel_Cancel)
        Me.fraLabeling.Controls.Add(Me.btnLabel_Ok)
        Me.fraLabeling.Controls.Add(Me.btnRenameSwitch)
        Me.fraLabeling.Controls.Add(Me.btnRenameVariable)
        Me.fraLabeling.Controls.Add(Me.lstSwitches)
        Me.fraLabeling.Controls.Add(Me.lstVariables)
        Me.fraLabeling.Controls.Add(Me.lblRandomLabel36)
        Me.fraLabeling.Controls.Add(Me.lblRandomLabel25)
        Me.fraLabeling.Location = New System.Drawing.Point(9, 158)
        Me.fraLabeling.Name = "fraLabeling"
        Me.fraLabeling.Size = New System.Drawing.Size(439, 363)
        Me.fraLabeling.TabIndex = 2
        Me.fraLabeling.TabStop = False
        Me.fraLabeling.Text = "Labeling Variables and Switches"
        '
        'btnLabel_Cancel
        '
        Me.btnLabel_Cancel.Location = New System.Drawing.Point(228, 331)
        Me.btnLabel_Cancel.Name = "btnLabel_Cancel"
        Me.btnLabel_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btnLabel_Cancel.TabIndex = 7
        Me.btnLabel_Cancel.Text = "Cancel"
        Me.btnLabel_Cancel.UseVisualStyleBackColor = True
        '
        'btnLabel_Ok
        '
        Me.btnLabel_Ok.Location = New System.Drawing.Point(136, 331)
        Me.btnLabel_Ok.Name = "btnLabel_Ok"
        Me.btnLabel_Ok.Size = New System.Drawing.Size(75, 23)
        Me.btnLabel_Ok.TabIndex = 6
        Me.btnLabel_Ok.Text = "Ok"
        Me.btnLabel_Ok.UseVisualStyleBackColor = True
        '
        'btnRenameSwitch
        '
        Me.btnRenameSwitch.Location = New System.Drawing.Point(324, 331)
        Me.btnRenameSwitch.Name = "btnRenameSwitch"
        Me.btnRenameSwitch.Size = New System.Drawing.Size(109, 23)
        Me.btnRenameSwitch.TabIndex = 5
        Me.btnRenameSwitch.Text = "Rename Switch"
        Me.btnRenameSwitch.UseVisualStyleBackColor = True
        '
        'btnRenameVariable
        '
        Me.btnRenameVariable.Location = New System.Drawing.Point(6, 331)
        Me.btnRenameVariable.Name = "btnRenameVariable"
        Me.btnRenameVariable.Size = New System.Drawing.Size(106, 23)
        Me.btnRenameVariable.TabIndex = 4
        Me.btnRenameVariable.Text = "Rename Variable"
        Me.btnRenameVariable.UseVisualStyleBackColor = True
        '
        'lstSwitches
        '
        Me.lstSwitches.FormattingEnabled = True
        Me.lstSwitches.Location = New System.Drawing.Point(228, 35)
        Me.lstSwitches.Name = "lstSwitches"
        Me.lstSwitches.Size = New System.Drawing.Size(205, 290)
        Me.lstSwitches.TabIndex = 3
        '
        'lstVariables
        '
        Me.lstVariables.FormattingEnabled = True
        Me.lstVariables.Location = New System.Drawing.Point(6, 35)
        Me.lstVariables.Name = "lstVariables"
        Me.lstVariables.Size = New System.Drawing.Size(205, 290)
        Me.lstVariables.TabIndex = 2
        '
        'lblRandomLabel36
        '
        Me.lblRandomLabel36.AutoSize = True
        Me.lblRandomLabel36.Location = New System.Drawing.Point(285, 19)
        Me.lblRandomLabel36.Name = "lblRandomLabel36"
        Me.lblRandomLabel36.Size = New System.Drawing.Size(82, 13)
        Me.lblRandomLabel36.TabIndex = 1
        Me.lblRandomLabel36.Text = "Player Switches"
        '
        'lblRandomLabel25
        '
        Me.lblRandomLabel25.AutoSize = True
        Me.lblRandomLabel25.Location = New System.Drawing.Point(6, 19)
        Me.lblRandomLabel25.Name = "lblRandomLabel25"
        Me.lblRandomLabel25.Size = New System.Drawing.Size(82, 13)
        Me.lblRandomLabel25.TabIndex = 0
        Me.lblRandomLabel25.Text = "Player Variables"
        '
        'FraRenaming
        '
        Me.FraRenaming.Controls.Add(Me.btnRename_Cancel)
        Me.FraRenaming.Controls.Add(Me.btnRename_Ok)
        Me.FraRenaming.Controls.Add(Me.fraRandom10)
        Me.FraRenaming.Location = New System.Drawing.Point(9, 9)
        Me.FraRenaming.Name = "FraRenaming"
        Me.FraRenaming.Size = New System.Drawing.Size(364, 143)
        Me.FraRenaming.TabIndex = 1
        Me.FraRenaming.TabStop = False
        Me.FraRenaming.Text = "Renaming Variable/Switch"
        '
        'btnRename_Cancel
        '
        Me.btnRename_Cancel.Location = New System.Drawing.Point(229, 102)
        Me.btnRename_Cancel.Name = "btnRename_Cancel"
        Me.btnRename_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btnRename_Cancel.TabIndex = 2
        Me.btnRename_Cancel.Text = "Cancel"
        Me.btnRename_Cancel.UseVisualStyleBackColor = True
        '
        'btnRename_Ok
        '
        Me.btnRename_Ok.Location = New System.Drawing.Point(54, 102)
        Me.btnRename_Ok.Name = "btnRename_Ok"
        Me.btnRename_Ok.Size = New System.Drawing.Size(75, 23)
        Me.btnRename_Ok.TabIndex = 1
        Me.btnRename_Ok.Text = "Ok"
        Me.btnRename_Ok.UseVisualStyleBackColor = True
        '
        'fraRandom10
        '
        Me.fraRandom10.Controls.Add(Me.txtRename)
        Me.fraRandom10.Controls.Add(Me.lblEditing)
        Me.fraRandom10.Location = New System.Drawing.Point(6, 19)
        Me.fraRandom10.Name = "fraRandom10"
        Me.fraRandom10.Size = New System.Drawing.Size(352, 77)
        Me.fraRandom10.TabIndex = 0
        Me.fraRandom10.TabStop = False
        Me.fraRandom10.Text = "Editing Variable/Switch"
        '
        'txtRename
        '
        Me.txtRename.Location = New System.Drawing.Point(6, 41)
        Me.txtRename.Name = "txtRename"
        Me.txtRename.Size = New System.Drawing.Size(340, 20)
        Me.txtRename.TabIndex = 1
        '
        'lblEditing
        '
        Me.lblEditing.AutoSize = True
        Me.lblEditing.Location = New System.Drawing.Point(3, 25)
        Me.lblEditing.Name = "lblEditing"
        Me.lblEditing.Size = New System.Drawing.Size(100, 13)
        Me.lblEditing.TabIndex = 0
        Me.lblEditing.Text = "Naming Variable #1"
        '
        'fraGraphic
        '
        Me.fraGraphic.Controls.Add(Me.btnGraphicCancel)
        Me.fraGraphic.Controls.Add(Me.btnGraphicOk)
        Me.fraGraphic.Controls.Add(Me.hScrlGraphicSel)
        Me.fraGraphic.Controls.Add(Me.vScrlGraphicSel)
        Me.fraGraphic.Controls.Add(Me.picGraphicSel)
        Me.fraGraphic.Controls.Add(Me.lblGraphic)
        Me.fraGraphic.Controls.Add(Me.scrlGraphic)
        Me.fraGraphic.Controls.Add(Me.cmbGraphic)
        Me.fraGraphic.Controls.Add(Me.lblRandomLabel33)
        Me.fraGraphic.Location = New System.Drawing.Point(2, 3)
        Me.fraGraphic.Name = "fraGraphic"
        Me.fraGraphic.Size = New System.Drawing.Size(54, 44)
        Me.fraGraphic.TabIndex = 3
        Me.fraGraphic.TabStop = False
        Me.fraGraphic.Text = "Graphic Selection"
        Me.fraGraphic.Visible = False
        '
        'btnGraphicCancel
        '
        Me.btnGraphicCancel.Location = New System.Drawing.Point(349, 483)
        Me.btnGraphicCancel.Name = "btnGraphicCancel"
        Me.btnGraphicCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnGraphicCancel.TabIndex = 8
        Me.btnGraphicCancel.Text = "Cancel"
        Me.btnGraphicCancel.UseVisualStyleBackColor = True
        '
        'btnGraphicOk
        '
        Me.btnGraphicOk.Location = New System.Drawing.Point(268, 483)
        Me.btnGraphicOk.Name = "btnGraphicOk"
        Me.btnGraphicOk.Size = New System.Drawing.Size(75, 23)
        Me.btnGraphicOk.TabIndex = 7
        Me.btnGraphicOk.Text = "Ok"
        Me.btnGraphicOk.UseVisualStyleBackColor = True
        '
        'hScrlGraphicSel
        '
        Me.hScrlGraphicSel.Location = New System.Drawing.Point(9, 463)
        Me.hScrlGraphicSel.Name = "hScrlGraphicSel"
        Me.hScrlGraphicSel.Size = New System.Drawing.Size(395, 17)
        Me.hScrlGraphicSel.TabIndex = 6
        '
        'vScrlGraphicSel
        '
        Me.vScrlGraphicSel.Location = New System.Drawing.Point(407, 40)
        Me.vScrlGraphicSel.Name = "vScrlGraphicSel"
        Me.vScrlGraphicSel.Size = New System.Drawing.Size(17, 420)
        Me.vScrlGraphicSel.TabIndex = 5
        '
        'picGraphicSel
        '
        Me.picGraphicSel.Location = New System.Drawing.Point(9, 40)
        Me.picGraphicSel.Name = "picGraphicSel"
        Me.picGraphicSel.Size = New System.Drawing.Size(395, 420)
        Me.picGraphicSel.TabIndex = 4
        Me.picGraphicSel.TabStop = False
        '
        'lblGraphic
        '
        Me.lblGraphic.AutoSize = True
        Me.lblGraphic.Location = New System.Drawing.Point(187, 16)
        Me.lblGraphic.Name = "lblGraphic"
        Me.lblGraphic.Size = New System.Drawing.Size(56, 13)
        Me.lblGraphic.TabIndex = 3
        Me.lblGraphic.Text = "Number: 1"
        '
        'scrlGraphic
        '
        Me.scrlGraphic.Location = New System.Drawing.Point(256, 17)
        Me.scrlGraphic.Name = "scrlGraphic"
        Me.scrlGraphic.Size = New System.Drawing.Size(151, 17)
        Me.scrlGraphic.TabIndex = 2
        '
        'cmbGraphic
        '
        Me.cmbGraphic.FormattingEnabled = True
        Me.cmbGraphic.Items.AddRange(New Object() {"None", "Character", "Tileset"})
        Me.cmbGraphic.Location = New System.Drawing.Point(46, 13)
        Me.cmbGraphic.Name = "cmbGraphic"
        Me.cmbGraphic.Size = New System.Drawing.Size(121, 21)
        Me.cmbGraphic.TabIndex = 1
        '
        'lblRandomLabel33
        '
        Me.lblRandomLabel33.AutoSize = True
        Me.lblRandomLabel33.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel33.Name = "lblRandomLabel33"
        Me.lblRandomLabel33.Size = New System.Drawing.Size(34, 13)
        Me.lblRandomLabel33.TabIndex = 0
        Me.lblRandomLabel33.Text = "Type:"
        '
        'pnlMoveRoute
        '
        Me.pnlMoveRoute.Controls.Add(Me.fraMoveRoute)
        Me.pnlMoveRoute.Location = New System.Drawing.Point(5, 4)
        Me.pnlMoveRoute.Name = "pnlMoveRoute"
        Me.pnlMoveRoute.Size = New System.Drawing.Size(827, 635)
        Me.pnlMoveRoute.TabIndex = 2
        '
        'fraMoveRoute
        '
        Me.fraMoveRoute.Controls.Add(Me.lblRandomLabel15)
        Me.fraMoveRoute.Controls.Add(Me.chkRepeatRoute)
        Me.fraMoveRoute.Controls.Add(Me.chkIgnoreMove)
        Me.fraMoveRoute.Controls.Add(Me.btnMoveRouteCancel)
        Me.fraMoveRoute.Controls.Add(Me.btnMoveRouteOk)
        Me.fraMoveRoute.Controls.Add(Me.fraRandom14)
        Me.fraMoveRoute.Controls.Add(Me.lstMoveRoute)
        Me.fraMoveRoute.Controls.Add(Me.cmbEvent)
        Me.fraMoveRoute.Location = New System.Drawing.Point(6, 3)
        Me.fraMoveRoute.Name = "fraMoveRoute"
        Me.fraMoveRoute.Size = New System.Drawing.Size(815, 530)
        Me.fraMoveRoute.TabIndex = 0
        Me.fraMoveRoute.TabStop = False
        Me.fraMoveRoute.Text = "Move Route"
        Me.fraMoveRoute.Visible = False
        '
        'lblRandomLabel15
        '
        Me.lblRandomLabel15.AutoSize = True
        Me.lblRandomLabel15.ForeColor = System.Drawing.Color.Red
        Me.lblRandomLabel15.Location = New System.Drawing.Point(3, 491)
        Me.lblRandomLabel15.Name = "lblRandomLabel15"
        Me.lblRandomLabel15.Size = New System.Drawing.Size(262, 13)
        Me.lblRandomLabel15.TabIndex = 7
        Me.lblRandomLabel15.Text = "*** These commands will not process on global events"
        '
        'chkRepeatRoute
        '
        Me.chkRepeatRoute.AutoSize = True
        Me.chkRepeatRoute.Location = New System.Drawing.Point(6, 463)
        Me.chkRepeatRoute.Name = "chkRepeatRoute"
        Me.chkRepeatRoute.Size = New System.Drawing.Size(93, 17)
        Me.chkRepeatRoute.TabIndex = 6
        Me.chkRepeatRoute.Text = "Repeat Route"
        Me.chkRepeatRoute.UseVisualStyleBackColor = True
        '
        'chkIgnoreMove
        '
        Me.chkIgnoreMove.AutoSize = True
        Me.chkIgnoreMove.Location = New System.Drawing.Point(6, 446)
        Me.chkIgnoreMove.Name = "chkIgnoreMove"
        Me.chkIgnoreMove.Size = New System.Drawing.Size(149, 17)
        Me.chkIgnoreMove.TabIndex = 5
        Me.chkIgnoreMove.Text = "Ignore if event can't move"
        Me.chkIgnoreMove.UseVisualStyleBackColor = True
        '
        'btnMoveRouteCancel
        '
        Me.btnMoveRouteCancel.Location = New System.Drawing.Point(727, 481)
        Me.btnMoveRouteCancel.Name = "btnMoveRouteCancel"
        Me.btnMoveRouteCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveRouteCancel.TabIndex = 4
        Me.btnMoveRouteCancel.Text = "Cancel"
        Me.btnMoveRouteCancel.UseVisualStyleBackColor = True
        '
        'btnMoveRouteOk
        '
        Me.btnMoveRouteOk.Location = New System.Drawing.Point(646, 481)
        Me.btnMoveRouteOk.Name = "btnMoveRouteOk"
        Me.btnMoveRouteOk.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveRouteOk.TabIndex = 3
        Me.btnMoveRouteOk.Text = "Ok"
        Me.btnMoveRouteOk.UseVisualStyleBackColor = True
        '
        'fraRandom14
        '
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute43)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute42)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute41)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute40)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute39)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute38)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute37)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute36)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute35)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute34)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute33)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute32)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute31)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute30)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute29)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute28)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute27)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute26)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute25)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute24)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute23)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute22)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute21)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute20)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute19)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute18)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute17)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute16)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute15)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute14)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute13)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute12)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute11)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute10)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute9)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute8)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute7)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute6)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute5)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute4)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute3)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute2)
        Me.fraRandom14.Controls.Add(Me.btnAddMoveRoute1)
        Me.fraRandom14.Location = New System.Drawing.Point(203, 19)
        Me.fraRandom14.Name = "fraRandom14"
        Me.fraRandom14.Size = New System.Drawing.Size(596, 421)
        Me.fraRandom14.TabIndex = 2
        Me.fraRandom14.TabStop = False
        Me.fraRandom14.Text = "Commands"
        '
        'btnAddMoveRoute43
        '
        Me.btnAddMoveRoute43.Location = New System.Drawing.Point(408, 384)
        Me.btnAddMoveRoute43.Name = "btnAddMoveRoute43"
        Me.btnAddMoveRoute43.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute43.TabIndex = 42
        Me.btnAddMoveRoute43.Text = "Set Graphic..."
        Me.btnAddMoveRoute43.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute42
        '
        Me.btnAddMoveRoute42.Location = New System.Drawing.Point(408, 339)
        Me.btnAddMoveRoute42.Name = "btnAddMoveRoute42"
        Me.btnAddMoveRoute42.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute42.TabIndex = 41
        Me.btnAddMoveRoute42.Text = "Set Pos. Above Player"
        Me.btnAddMoveRoute42.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute41
        '
        Me.btnAddMoveRoute41.Location = New System.Drawing.Point(408, 310)
        Me.btnAddMoveRoute41.Name = "btnAddMoveRoute41"
        Me.btnAddMoveRoute41.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute41.TabIndex = 40
        Me.btnAddMoveRoute41.Text = "Set Pos. With Player"
        Me.btnAddMoveRoute41.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute40
        '
        Me.btnAddMoveRoute40.Location = New System.Drawing.Point(408, 281)
        Me.btnAddMoveRoute40.Name = "btnAddMoveRoute40"
        Me.btnAddMoveRoute40.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute40.TabIndex = 39
        Me.btnAddMoveRoute40.Text = "Set Pos. Below Player"
        Me.btnAddMoveRoute40.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute39
        '
        Me.btnAddMoveRoute39.Location = New System.Drawing.Point(408, 223)
        Me.btnAddMoveRoute39.Name = "btnAddMoveRoute39"
        Me.btnAddMoveRoute39.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute39.TabIndex = 38
        Me.btnAddMoveRoute39.Text = "Walkthrough OFF"
        Me.btnAddMoveRoute39.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute38
        '
        Me.btnAddMoveRoute38.Location = New System.Drawing.Point(408, 194)
        Me.btnAddMoveRoute38.Name = "btnAddMoveRoute38"
        Me.btnAddMoveRoute38.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute38.TabIndex = 37
        Me.btnAddMoveRoute38.Text = "Walkthrough ON"
        Me.btnAddMoveRoute38.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute37
        '
        Me.btnAddMoveRoute37.Location = New System.Drawing.Point(408, 136)
        Me.btnAddMoveRoute37.Name = "btnAddMoveRoute37"
        Me.btnAddMoveRoute37.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute37.TabIndex = 36
        Me.btnAddMoveRoute37.Text = "Fixed Direction OFF"
        Me.btnAddMoveRoute37.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute36
        '
        Me.btnAddMoveRoute36.Location = New System.Drawing.Point(408, 107)
        Me.btnAddMoveRoute36.Name = "btnAddMoveRoute36"
        Me.btnAddMoveRoute36.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute36.TabIndex = 35
        Me.btnAddMoveRoute36.Text = "Fixed Direction ON"
        Me.btnAddMoveRoute36.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute35
        '
        Me.btnAddMoveRoute35.Location = New System.Drawing.Point(408, 48)
        Me.btnAddMoveRoute35.Name = "btnAddMoveRoute35"
        Me.btnAddMoveRoute35.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute35.TabIndex = 34
        Me.btnAddMoveRoute35.Text = "Walk. Anim. OFF"
        Me.btnAddMoveRoute35.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute34
        '
        Me.btnAddMoveRoute34.Location = New System.Drawing.Point(408, 19)
        Me.btnAddMoveRoute34.Name = "btnAddMoveRoute34"
        Me.btnAddMoveRoute34.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute34.TabIndex = 33
        Me.btnAddMoveRoute34.Text = "Walking Anim. ON"
        Me.btnAddMoveRoute34.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute33
        '
        Me.btnAddMoveRoute33.Location = New System.Drawing.Point(274, 310)
        Me.btnAddMoveRoute33.Name = "btnAddMoveRoute33"
        Me.btnAddMoveRoute33.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute33.TabIndex = 32
        Me.btnAddMoveRoute33.Text = "Set Freq. to Highest"
        Me.btnAddMoveRoute33.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute32
        '
        Me.btnAddMoveRoute32.Location = New System.Drawing.Point(274, 281)
        Me.btnAddMoveRoute32.Name = "btnAddMoveRoute32"
        Me.btnAddMoveRoute32.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute32.TabIndex = 31
        Me.btnAddMoveRoute32.Text = "Set Freq. to Higher"
        Me.btnAddMoveRoute32.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute31
        '
        Me.btnAddMoveRoute31.Location = New System.Drawing.Point(274, 252)
        Me.btnAddMoveRoute31.Name = "btnAddMoveRoute31"
        Me.btnAddMoveRoute31.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute31.TabIndex = 30
        Me.btnAddMoveRoute31.Text = "Set Freq. to Normal"
        Me.btnAddMoveRoute31.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute30
        '
        Me.btnAddMoveRoute30.Location = New System.Drawing.Point(274, 223)
        Me.btnAddMoveRoute30.Name = "btnAddMoveRoute30"
        Me.btnAddMoveRoute30.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute30.TabIndex = 29
        Me.btnAddMoveRoute30.Text = "Set Freq. to Lower"
        Me.btnAddMoveRoute30.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute29
        '
        Me.btnAddMoveRoute29.Location = New System.Drawing.Point(274, 194)
        Me.btnAddMoveRoute29.Name = "btnAddMoveRoute29"
        Me.btnAddMoveRoute29.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute29.TabIndex = 28
        Me.btnAddMoveRoute29.Text = "Set Freq. to Lowest"
        Me.btnAddMoveRoute29.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute28
        '
        Me.btnAddMoveRoute28.Location = New System.Drawing.Point(274, 165)
        Me.btnAddMoveRoute28.Name = "btnAddMoveRoute28"
        Me.btnAddMoveRoute28.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute28.TabIndex = 27
        Me.btnAddMoveRoute28.Text = "Set Speed 4x Faster"
        Me.btnAddMoveRoute28.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute27
        '
        Me.btnAddMoveRoute27.Location = New System.Drawing.Point(274, 136)
        Me.btnAddMoveRoute27.Name = "btnAddMoveRoute27"
        Me.btnAddMoveRoute27.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute27.TabIndex = 26
        Me.btnAddMoveRoute27.Text = "Set Speed 2x Faster"
        Me.btnAddMoveRoute27.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute26
        '
        Me.btnAddMoveRoute26.Location = New System.Drawing.Point(274, 107)
        Me.btnAddMoveRoute26.Name = "btnAddMoveRoute26"
        Me.btnAddMoveRoute26.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute26.TabIndex = 25
        Me.btnAddMoveRoute26.Text = "Set Speed to Normal"
        Me.btnAddMoveRoute26.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute25
        '
        Me.btnAddMoveRoute25.Location = New System.Drawing.Point(274, 77)
        Me.btnAddMoveRoute25.Name = "btnAddMoveRoute25"
        Me.btnAddMoveRoute25.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute25.TabIndex = 24
        Me.btnAddMoveRoute25.Text = "Set Speed 2x Slower"
        Me.btnAddMoveRoute25.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute24
        '
        Me.btnAddMoveRoute24.Location = New System.Drawing.Point(274, 48)
        Me.btnAddMoveRoute24.Name = "btnAddMoveRoute24"
        Me.btnAddMoveRoute24.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute24.TabIndex = 23
        Me.btnAddMoveRoute24.Text = "Set Speed 4x Slower"
        Me.btnAddMoveRoute24.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute23
        '
        Me.btnAddMoveRoute23.Location = New System.Drawing.Point(274, 19)
        Me.btnAddMoveRoute23.Name = "btnAddMoveRoute23"
        Me.btnAddMoveRoute23.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute23.TabIndex = 22
        Me.btnAddMoveRoute23.Text = "Set Speed 8x Slower"
        Me.btnAddMoveRoute23.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute22
        '
        Me.btnAddMoveRoute22.Location = New System.Drawing.Point(140, 281)
        Me.btnAddMoveRoute22.Name = "btnAddMoveRoute22"
        Me.btnAddMoveRoute22.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute22.TabIndex = 21
        Me.btnAddMoveRoute22.Text = "Turn From Player***"
        Me.btnAddMoveRoute22.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute21
        '
        Me.btnAddMoveRoute21.Location = New System.Drawing.Point(140, 252)
        Me.btnAddMoveRoute21.Name = "btnAddMoveRoute21"
        Me.btnAddMoveRoute21.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute21.TabIndex = 20
        Me.btnAddMoveRoute21.Text = "Turn To Player***"
        Me.btnAddMoveRoute21.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute20
        '
        Me.btnAddMoveRoute20.Location = New System.Drawing.Point(140, 223)
        Me.btnAddMoveRoute20.Name = "btnAddMoveRoute20"
        Me.btnAddMoveRoute20.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute20.TabIndex = 19
        Me.btnAddMoveRoute20.Text = "Turn Randomly"
        Me.btnAddMoveRoute20.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute19
        '
        Me.btnAddMoveRoute19.Location = New System.Drawing.Point(140, 194)
        Me.btnAddMoveRoute19.Name = "btnAddMoveRoute19"
        Me.btnAddMoveRoute19.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute19.TabIndex = 18
        Me.btnAddMoveRoute19.Text = "Turn 180 °"
        Me.btnAddMoveRoute19.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute18
        '
        Me.btnAddMoveRoute18.Location = New System.Drawing.Point(140, 165)
        Me.btnAddMoveRoute18.Name = "btnAddMoveRoute18"
        Me.btnAddMoveRoute18.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute18.TabIndex = 17
        Me.btnAddMoveRoute18.Text = "Turn 90 ° Left"
        Me.btnAddMoveRoute18.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute17
        '
        Me.btnAddMoveRoute17.Location = New System.Drawing.Point(140, 136)
        Me.btnAddMoveRoute17.Name = "btnAddMoveRoute17"
        Me.btnAddMoveRoute17.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute17.TabIndex = 16
        Me.btnAddMoveRoute17.Text = "Turn 90 ° Right"
        Me.btnAddMoveRoute17.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute16
        '
        Me.btnAddMoveRoute16.Location = New System.Drawing.Point(140, 107)
        Me.btnAddMoveRoute16.Name = "btnAddMoveRoute16"
        Me.btnAddMoveRoute16.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute16.TabIndex = 15
        Me.btnAddMoveRoute16.Text = "Turn Right"
        Me.btnAddMoveRoute16.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute15
        '
        Me.btnAddMoveRoute15.Location = New System.Drawing.Point(140, 77)
        Me.btnAddMoveRoute15.Name = "btnAddMoveRoute15"
        Me.btnAddMoveRoute15.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute15.TabIndex = 14
        Me.btnAddMoveRoute15.Text = "Turn Left"
        Me.btnAddMoveRoute15.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute14
        '
        Me.btnAddMoveRoute14.Location = New System.Drawing.Point(140, 48)
        Me.btnAddMoveRoute14.Name = "btnAddMoveRoute14"
        Me.btnAddMoveRoute14.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute14.TabIndex = 13
        Me.btnAddMoveRoute14.Text = "Turn Down"
        Me.btnAddMoveRoute14.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute13
        '
        Me.btnAddMoveRoute13.Location = New System.Drawing.Point(140, 19)
        Me.btnAddMoveRoute13.Name = "btnAddMoveRoute13"
        Me.btnAddMoveRoute13.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute13.TabIndex = 12
        Me.btnAddMoveRoute13.Text = "Turn Up"
        Me.btnAddMoveRoute13.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute12
        '
        Me.btnAddMoveRoute12.Location = New System.Drawing.Point(6, 368)
        Me.btnAddMoveRoute12.Name = "btnAddMoveRoute12"
        Me.btnAddMoveRoute12.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute12.TabIndex = 11
        Me.btnAddMoveRoute12.Text = "Wait 1000Ms"
        Me.btnAddMoveRoute12.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute11
        '
        Me.btnAddMoveRoute11.Location = New System.Drawing.Point(6, 339)
        Me.btnAddMoveRoute11.Name = "btnAddMoveRoute11"
        Me.btnAddMoveRoute11.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute11.TabIndex = 10
        Me.btnAddMoveRoute11.Text = "Wait 500Ms"
        Me.btnAddMoveRoute11.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute10
        '
        Me.btnAddMoveRoute10.Location = New System.Drawing.Point(6, 310)
        Me.btnAddMoveRoute10.Name = "btnAddMoveRoute10"
        Me.btnAddMoveRoute10.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute10.TabIndex = 9
        Me.btnAddMoveRoute10.Text = "Wait 100Ms"
        Me.btnAddMoveRoute10.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute9
        '
        Me.btnAddMoveRoute9.Location = New System.Drawing.Point(6, 252)
        Me.btnAddMoveRoute9.Name = "btnAddMoveRoute9"
        Me.btnAddMoveRoute9.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute9.TabIndex = 8
        Me.btnAddMoveRoute9.Text = "Step Back"
        Me.btnAddMoveRoute9.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute8
        '
        Me.btnAddMoveRoute8.Location = New System.Drawing.Point(6, 223)
        Me.btnAddMoveRoute8.Name = "btnAddMoveRoute8"
        Me.btnAddMoveRoute8.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute8.TabIndex = 7
        Me.btnAddMoveRoute8.Text = "Step Forward"
        Me.btnAddMoveRoute8.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute7
        '
        Me.btnAddMoveRoute7.Location = New System.Drawing.Point(6, 194)
        Me.btnAddMoveRoute7.Name = "btnAddMoveRoute7"
        Me.btnAddMoveRoute7.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute7.TabIndex = 6
        Me.btnAddMoveRoute7.Text = "Move From Player***"
        Me.btnAddMoveRoute7.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute6
        '
        Me.btnAddMoveRoute6.Location = New System.Drawing.Point(6, 165)
        Me.btnAddMoveRoute6.Name = "btnAddMoveRoute6"
        Me.btnAddMoveRoute6.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute6.TabIndex = 5
        Me.btnAddMoveRoute6.Text = "Move To Player***"
        Me.btnAddMoveRoute6.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute5
        '
        Me.btnAddMoveRoute5.Location = New System.Drawing.Point(6, 136)
        Me.btnAddMoveRoute5.Name = "btnAddMoveRoute5"
        Me.btnAddMoveRoute5.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute5.TabIndex = 4
        Me.btnAddMoveRoute5.Text = "Move Randomly"
        Me.btnAddMoveRoute5.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute4
        '
        Me.btnAddMoveRoute4.Location = New System.Drawing.Point(6, 107)
        Me.btnAddMoveRoute4.Name = "btnAddMoveRoute4"
        Me.btnAddMoveRoute4.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute4.TabIndex = 3
        Me.btnAddMoveRoute4.Text = "Move Right"
        Me.btnAddMoveRoute4.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute3
        '
        Me.btnAddMoveRoute3.Location = New System.Drawing.Point(6, 77)
        Me.btnAddMoveRoute3.Name = "btnAddMoveRoute3"
        Me.btnAddMoveRoute3.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute3.TabIndex = 2
        Me.btnAddMoveRoute3.Text = "Move Left"
        Me.btnAddMoveRoute3.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute2
        '
        Me.btnAddMoveRoute2.Location = New System.Drawing.Point(6, 48)
        Me.btnAddMoveRoute2.Name = "btnAddMoveRoute2"
        Me.btnAddMoveRoute2.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute2.TabIndex = 1
        Me.btnAddMoveRoute2.Text = "Move Down"
        Me.btnAddMoveRoute2.UseVisualStyleBackColor = True
        '
        'btnAddMoveRoute1
        '
        Me.btnAddMoveRoute1.Location = New System.Drawing.Point(6, 19)
        Me.btnAddMoveRoute1.Name = "btnAddMoveRoute1"
        Me.btnAddMoveRoute1.Size = New System.Drawing.Size(128, 23)
        Me.btnAddMoveRoute1.TabIndex = 0
        Me.btnAddMoveRoute1.Text = "Move Up"
        Me.btnAddMoveRoute1.UseVisualStyleBackColor = True
        '
        'lstMoveRoute
        '
        Me.lstMoveRoute.FormattingEnabled = True
        Me.lstMoveRoute.Location = New System.Drawing.Point(6, 46)
        Me.lstMoveRoute.Name = "lstMoveRoute"
        Me.lstMoveRoute.Size = New System.Drawing.Size(191, 394)
        Me.lstMoveRoute.TabIndex = 1
        '
        'cmbEvent
        '
        Me.cmbEvent.FormattingEnabled = True
        Me.cmbEvent.Location = New System.Drawing.Point(6, 19)
        Me.cmbEvent.Name = "cmbEvent"
        Me.cmbEvent.Size = New System.Drawing.Size(191, 21)
        Me.cmbEvent.TabIndex = 0
        '
        'tabPages
        '
        Me.tabPages.Controls.Add(Me.Tab1)
        Me.tabPages.Location = New System.Drawing.Point(12, 64)
        Me.tabPages.Name = "tabPages"
        Me.tabPages.SelectedIndex = 0
        Me.tabPages.Size = New System.Drawing.Size(819, 23)
        Me.tabPages.TabIndex = 3
        '
        'Tab1
        '
        Me.Tab1.Location = New System.Drawing.Point(4, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(811, 0)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "1"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'frarandom20
        '
        Me.frarandom20.Controls.Add(Me.btnClearPage)
        Me.frarandom20.Controls.Add(Me.btnDeletePage)
        Me.frarandom20.Controls.Add(Me.btnPastePage)
        Me.frarandom20.Controls.Add(Me.btnCopyPage)
        Me.frarandom20.Controls.Add(Me.btnNewPage)
        Me.frarandom20.Controls.Add(Me.txtName)
        Me.frarandom20.Controls.Add(Me.lblRandomlabel32)
        Me.frarandom20.Location = New System.Drawing.Point(12, 12)
        Me.frarandom20.Name = "frarandom20"
        Me.frarandom20.Size = New System.Drawing.Size(815, 50)
        Me.frarandom20.TabIndex = 4
        Me.frarandom20.TabStop = False
        Me.frarandom20.Text = "General"
        '
        'btnClearPage
        '
        Me.btnClearPage.Location = New System.Drawing.Point(702, 17)
        Me.btnClearPage.Name = "btnClearPage"
        Me.btnClearPage.Size = New System.Drawing.Size(75, 23)
        Me.btnClearPage.TabIndex = 6
        Me.btnClearPage.Text = "Clear Page"
        Me.btnClearPage.UseVisualStyleBackColor = True
        '
        'btnDeletePage
        '
        Me.btnDeletePage.Location = New System.Drawing.Point(621, 17)
        Me.btnDeletePage.Name = "btnDeletePage"
        Me.btnDeletePage.Size = New System.Drawing.Size(75, 23)
        Me.btnDeletePage.TabIndex = 5
        Me.btnDeletePage.Text = "Delete Page"
        Me.btnDeletePage.UseVisualStyleBackColor = True
        '
        'btnPastePage
        '
        Me.btnPastePage.Location = New System.Drawing.Point(540, 17)
        Me.btnPastePage.Name = "btnPastePage"
        Me.btnPastePage.Size = New System.Drawing.Size(75, 23)
        Me.btnPastePage.TabIndex = 4
        Me.btnPastePage.Text = "Paste Page"
        Me.btnPastePage.UseVisualStyleBackColor = True
        '
        'btnCopyPage
        '
        Me.btnCopyPage.Location = New System.Drawing.Point(459, 17)
        Me.btnCopyPage.Name = "btnCopyPage"
        Me.btnCopyPage.Size = New System.Drawing.Size(75, 23)
        Me.btnCopyPage.TabIndex = 3
        Me.btnCopyPage.Text = "Copy Page"
        Me.btnCopyPage.UseVisualStyleBackColor = True
        '
        'btnNewPage
        '
        Me.btnNewPage.Location = New System.Drawing.Point(378, 17)
        Me.btnNewPage.Name = "btnNewPage"
        Me.btnNewPage.Size = New System.Drawing.Size(75, 23)
        Me.btnNewPage.TabIndex = 2
        Me.btnNewPage.Text = "New Page"
        Me.btnNewPage.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(50, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(256, 20)
        Me.txtName.TabIndex = 1
        '
        'lblRandomlabel32
        '
        Me.lblRandomlabel32.AutoSize = True
        Me.lblRandomlabel32.Location = New System.Drawing.Point(6, 22)
        Me.lblRandomlabel32.Name = "lblRandomlabel32"
        Me.lblRandomlabel32.Size = New System.Drawing.Size(38, 13)
        Me.lblRandomlabel32.TabIndex = 0
        Me.lblRandomlabel32.Text = "Name:"
        '
        'btnLabeling
        '
        Me.btnLabeling.Location = New System.Drawing.Point(12, 608)
        Me.btnLabeling.Name = "btnLabeling"
        Me.btnLabeling.Size = New System.Drawing.Size(142, 23)
        Me.btnLabeling.TabIndex = 5
        Me.btnLabeling.Text = "Label Variables/Switches"
        Me.btnLabeling.UseVisualStyleBackColor = True
        '
        'fraDialogue
        '
        Me.fraDialogue.Controls.Add(Me.fraCommand7)
        Me.fraDialogue.Controls.Add(Me.fraCommand27)
        Me.fraDialogue.Controls.Add(Me.fraCommand23)
        Me.fraDialogue.Controls.Add(Me.fraCommand18)
        Me.fraDialogue.Controls.Add(Me.fraCommand34)
        Me.fraDialogue.Controls.Add(Me.fraCommand35)
        Me.fraDialogue.Controls.Add(Me.fraCommand20)
        Me.fraDialogue.Controls.Add(Me.fraCommand31)
        Me.fraDialogue.Controls.Add(Me.fraCommand30)
        Me.fraDialogue.Controls.Add(Me.fraCommand28)
        Me.fraDialogue.Controls.Add(Me.fraCommand25)
        Me.fraDialogue.Controls.Add(Me.fraCommand24)
        Me.fraDialogue.Controls.Add(Me.fraCommand22)
        Me.fraDialogue.Controls.Add(Me.fraCommand26)
        Me.fraDialogue.Controls.Add(Me.fraCommand21)
        Me.fraDialogue.Controls.Add(Me.fraCommand19)
        Me.fraDialogue.Controls.Add(Me.fraCommand3)
        Me.fraDialogue.Controls.Add(Me.fraCommand2)
        Me.fraDialogue.Controls.Add(Me.fraCommand33)
        Me.fraDialogue.Controls.Add(Me.fraCommand1)
        Me.fraDialogue.Controls.Add(Me.fraCommand0)
        Me.fraDialogue.Controls.Add(Me.fraCommand17)
        Me.fraDialogue.Controls.Add(Me.fraCommand16)
        Me.fraDialogue.Controls.Add(Me.fraCommand15)
        Me.fraDialogue.Controls.Add(Me.fraCommand14)
        Me.fraDialogue.Controls.Add(Me.fraCommand13)
        Me.fraDialogue.Controls.Add(Me.fraCommand12)
        Me.fraDialogue.Controls.Add(Me.fraCommand11)
        Me.fraDialogue.Controls.Add(Me.fraCommand10)
        Me.fraDialogue.Controls.Add(Me.fraCommand6)
        Me.fraDialogue.Controls.Add(Me.fraCommand5)
        Me.fraDialogue.Controls.Add(Me.fraCommand9)
        Me.fraDialogue.Controls.Add(Me.fraCommand8)
        Me.fraDialogue.Controls.Add(Me.fraCommand32)
        Me.fraDialogue.Controls.Add(Me.fraCommand4)
        Me.fraDialogue.Location = New System.Drawing.Point(850, 29)
        Me.fraDialogue.Name = "fraDialogue"
        Me.fraDialogue.Size = New System.Drawing.Size(1419, 566)
        Me.fraDialogue.TabIndex = 6
        Me.fraDialogue.TabStop = False
        '
        'fraCommand7
        '
        Me.fraCommand7.Controls.Add(Me.btnCommand_Ok29)
        Me.fraCommand7.Controls.Add(Me.btnCommand_Cancel29)
        Me.fraCommand7.Controls.Add(Me.fraConditions_Quest)
        Me.fraCommand7.Controls.Add(Me.lblConditionQuest)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index7)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index6)
        Me.fraCommand7.Controls.Add(Me.lblRandomLabel2)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index5)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_LearntSkill)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index4)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_ClassIs)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index3)
        Me.fraCommand7.Controls.Add(Me.scrlCondition_Quest)
        Me.fraCommand7.Controls.Add(Me.scrlCondition_HasItem)
        Me.fraCommand7.Controls.Add(Me.lblHasItemAmt)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index2)
        Me.fraCommand7.Controls.Add(Me.lblRandomLabel35)
        Me.fraCommand7.Controls.Add(Me.lblRandomLabel1)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_SelfSwitchCondition)
        Me.fraCommand7.Controls.Add(Me.cmbCondtion_PlayerSwitchCondition)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_LevelCompare)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_HasItem)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_SelfSwitch)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_PlayerSwitch)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index1)
        Me.fraCommand7.Controls.Add(Me.txtCondition_LevelAmount)
        Me.fraCommand7.Controls.Add(Me.txtCondition_PlayerVarCondition)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_PlayerVarCompare)
        Me.fraCommand7.Controls.Add(Me.lblRandomLabel0)
        Me.fraCommand7.Controls.Add(Me.cmbCondition_PlayerVarIndex)
        Me.fraCommand7.Controls.Add(Me.optCondition_Index0)
        Me.fraCommand7.Location = New System.Drawing.Point(6, 13)
        Me.fraCommand7.Name = "fraCommand7"
        Me.fraCommand7.Size = New System.Drawing.Size(400, 484)
        Me.fraCommand7.TabIndex = 35
        Me.fraCommand7.TabStop = False
        Me.fraCommand7.Text = "Conditional Branch"
        '
        'btnCommand_Ok29
        '
        Me.btnCommand_Ok29.Location = New System.Drawing.Point(234, 452)
        Me.btnCommand_Ok29.Name = "btnCommand_Ok29"
        Me.btnCommand_Ok29.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok29.TabIndex = 21
        Me.btnCommand_Ok29.Text = "Ok"
        Me.btnCommand_Ok29.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel29
        '
        Me.btnCommand_Cancel29.Location = New System.Drawing.Point(315, 452)
        Me.btnCommand_Cancel29.Name = "btnCommand_Cancel29"
        Me.btnCommand_Cancel29.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel29.TabIndex = 21
        Me.btnCommand_Cancel29.Text = "Cancel"
        Me.btnCommand_Cancel29.UseVisualStyleBackColor = True
        '
        'fraConditions_Quest
        '
        Me.fraConditions_Quest.Controls.Add(Me.lblCondition_QuestTask)
        Me.fraConditions_Quest.Controls.Add(Me.optCondition_Quest1)
        Me.fraConditions_Quest.Controls.Add(Me.Label2)
        Me.fraConditions_Quest.Controls.Add(Me.lblRandomLabel50)
        Me.fraConditions_Quest.Controls.Add(Me.optCondition_Quest0)
        Me.fraConditions_Quest.Controls.Add(Me.cmbCondition_General)
        Me.fraConditions_Quest.Controls.Add(Me.scrlCondition_QuestTask)
        Me.fraConditions_Quest.Location = New System.Drawing.Point(6, 345)
        Me.fraConditions_Quest.Name = "fraConditions_Quest"
        Me.fraConditions_Quest.Size = New System.Drawing.Size(384, 93)
        Me.fraConditions_Quest.TabIndex = 20
        Me.fraConditions_Quest.TabStop = False
        Me.fraConditions_Quest.Text = "Quest Conditions"
        Me.fraConditions_Quest.Visible = False
        '
        'lblCondition_QuestTask
        '
        Me.lblCondition_QuestTask.AutoSize = True
        Me.lblCondition_QuestTask.Location = New System.Drawing.Point(214, 61)
        Me.lblCondition_QuestTask.Name = "lblCondition_QuestTask"
        Me.lblCondition_QuestTask.Size = New System.Drawing.Size(20, 13)
        Me.lblCondition_QuestTask.TabIndex = 20
        Me.lblCondition_QuestTask.Text = "#1"
        '
        'optCondition_Quest1
        '
        Me.optCondition_Quest1.AutoSize = True
        Me.optCondition_Quest1.Location = New System.Drawing.Point(5, 59)
        Me.optCondition_Quest1.Name = "optCondition_Quest1"
        Me.optCondition_Quest1.Size = New System.Drawing.Size(49, 17)
        Me.optCondition_Quest1.TabIndex = 1
        Me.optCondition_Quest1.TabStop = True
        Me.optCondition_Quest1.Text = "Task"
        Me.optCondition_Quest1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Player is on task..."
        '
        'lblRandomLabel50
        '
        Me.lblRandomLabel50.AutoSize = True
        Me.lblRandomLabel50.Location = New System.Drawing.Point(104, 27)
        Me.lblRandomLabel50.Name = "lblRandomLabel50"
        Me.lblRandomLabel50.Size = New System.Drawing.Size(104, 13)
        Me.lblRandomLabel50.TabIndex = 19
        Me.lblRandomLabel50.Text = "If selected quest is..."
        '
        'optCondition_Quest0
        '
        Me.optCondition_Quest0.AutoSize = True
        Me.optCondition_Quest0.Location = New System.Drawing.Point(5, 25)
        Me.optCondition_Quest0.Name = "optCondition_Quest0"
        Me.optCondition_Quest0.Size = New System.Drawing.Size(62, 17)
        Me.optCondition_Quest0.TabIndex = 0
        Me.optCondition_Quest0.TabStop = True
        Me.optCondition_Quest0.Text = "General"
        Me.optCondition_Quest0.UseVisualStyleBackColor = True
        '
        'cmbCondition_General
        '
        Me.cmbCondition_General.FormattingEnabled = True
        Me.cmbCondition_General.Items.AddRange(New Object() {"Not Started", "Started", "Completed", "Can Start", "Can End"})
        Me.cmbCondition_General.Location = New System.Drawing.Point(257, 24)
        Me.cmbCondition_General.Name = "cmbCondition_General"
        Me.cmbCondition_General.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_General.TabIndex = 6
        '
        'scrlCondition_QuestTask
        '
        Me.scrlCondition_QuestTask.Location = New System.Drawing.Point(257, 59)
        Me.scrlCondition_QuestTask.Name = "scrlCondition_QuestTask"
        Me.scrlCondition_QuestTask.Size = New System.Drawing.Size(121, 17)
        Me.scrlCondition_QuestTask.TabIndex = 11
        '
        'lblConditionQuest
        '
        Me.lblConditionQuest.AutoSize = True
        Me.lblConditionQuest.Location = New System.Drawing.Point(120, 310)
        Me.lblConditionQuest.Name = "lblConditionQuest"
        Me.lblConditionQuest.Size = New System.Drawing.Size(47, 13)
        Me.lblConditionQuest.TabIndex = 19
        Me.lblConditionQuest.Text = "Quest: 1"
        '
        'optCondition_Index7
        '
        Me.optCondition_Index7.AutoSize = True
        Me.optCondition_Index7.Location = New System.Drawing.Point(7, 325)
        Me.optCondition_Index7.Name = "optCondition_Index7"
        Me.optCondition_Index7.Size = New System.Drawing.Size(86, 17)
        Me.optCondition_Index7.TabIndex = 18
        Me.optCondition_Index7.TabStop = True
        Me.optCondition_Index7.Text = "Quest Status"
        Me.optCondition_Index7.UseVisualStyleBackColor = True
        '
        'optCondition_Index6
        '
        Me.optCondition_Index6.AutoSize = True
        Me.optCondition_Index6.Location = New System.Drawing.Point(7, 288)
        Me.optCondition_Index6.Name = "optCondition_Index6"
        Me.optCondition_Index6.Size = New System.Drawing.Size(78, 17)
        Me.optCondition_Index6.TabIndex = 18
        Me.optCondition_Index6.TabStop = True
        Me.optCondition_Index6.Text = "Self Switch"
        Me.optCondition_Index6.UseVisualStyleBackColor = True
        '
        'lblRandomLabel2
        '
        Me.lblRandomLabel2.AutoSize = True
        Me.lblRandomLabel2.Location = New System.Drawing.Point(63, 252)
        Me.lblRandomLabel2.Name = "lblRandomLabel2"
        Me.lblRandomLabel2.Size = New System.Drawing.Size(14, 13)
        Me.lblRandomLabel2.TabIndex = 17
        Me.lblRandomLabel2.Text = "is"
        '
        'optCondition_Index5
        '
        Me.optCondition_Index5.AutoSize = True
        Me.optCondition_Index5.Location = New System.Drawing.Point(6, 250)
        Me.optCondition_Index5.Name = "optCondition_Index5"
        Me.optCondition_Index5.Size = New System.Drawing.Size(51, 17)
        Me.optCondition_Index5.TabIndex = 16
        Me.optCondition_Index5.TabStop = True
        Me.optCondition_Index5.Text = "Level"
        Me.optCondition_Index5.UseVisualStyleBackColor = True
        '
        'cmbCondition_LearntSkill
        '
        Me.cmbCondition_LearntSkill.FormattingEnabled = True
        Me.cmbCondition_LearntSkill.Location = New System.Drawing.Point(123, 214)
        Me.cmbCondition_LearntSkill.Name = "cmbCondition_LearntSkill"
        Me.cmbCondition_LearntSkill.Size = New System.Drawing.Size(267, 21)
        Me.cmbCondition_LearntSkill.TabIndex = 15
        '
        'optCondition_Index4
        '
        Me.optCondition_Index4.AutoSize = True
        Me.optCondition_Index4.Location = New System.Drawing.Point(6, 215)
        Me.optCondition_Index4.Name = "optCondition_Index4"
        Me.optCondition_Index4.Size = New System.Drawing.Size(79, 17)
        Me.optCondition_Index4.TabIndex = 14
        Me.optCondition_Index4.TabStop = True
        Me.optCondition_Index4.Text = "Knows Skill"
        Me.optCondition_Index4.UseVisualStyleBackColor = True
        '
        'cmbCondition_ClassIs
        '
        Me.cmbCondition_ClassIs.FormattingEnabled = True
        Me.cmbCondition_ClassIs.Location = New System.Drawing.Point(123, 184)
        Me.cmbCondition_ClassIs.Name = "cmbCondition_ClassIs"
        Me.cmbCondition_ClassIs.Size = New System.Drawing.Size(267, 21)
        Me.cmbCondition_ClassIs.TabIndex = 13
        '
        'optCondition_Index3
        '
        Me.optCondition_Index3.AutoSize = True
        Me.optCondition_Index3.Location = New System.Drawing.Point(6, 185)
        Me.optCondition_Index3.Name = "optCondition_Index3"
        Me.optCondition_Index3.Size = New System.Drawing.Size(61, 17)
        Me.optCondition_Index3.TabIndex = 12
        Me.optCondition_Index3.TabStop = True
        Me.optCondition_Index3.Text = "Class Is"
        Me.optCondition_Index3.UseVisualStyleBackColor = True
        '
        'scrlCondition_Quest
        '
        Me.scrlCondition_Quest.Location = New System.Drawing.Point(123, 325)
        Me.scrlCondition_Quest.Name = "scrlCondition_Quest"
        Me.scrlCondition_Quest.Size = New System.Drawing.Size(267, 17)
        Me.scrlCondition_Quest.TabIndex = 11
        '
        'scrlCondition_HasItem
        '
        Me.scrlCondition_HasItem.Location = New System.Drawing.Point(123, 152)
        Me.scrlCondition_HasItem.Name = "scrlCondition_HasItem"
        Me.scrlCondition_HasItem.Size = New System.Drawing.Size(267, 17)
        Me.scrlCondition_HasItem.TabIndex = 11
        '
        'lblHasItemAmt
        '
        Me.lblHasItemAmt.AutoSize = True
        Me.lblHasItemAmt.Location = New System.Drawing.Point(79, 156)
        Me.lblHasItemAmt.Name = "lblHasItemAmt"
        Me.lblHasItemAmt.Size = New System.Drawing.Size(24, 13)
        Me.lblHasItemAmt.TabIndex = 10
        Me.lblHasItemAmt.Text = "x: 1"
        '
        'optCondition_Index2
        '
        Me.optCondition_Index2.AutoSize = True
        Me.optCondition_Index2.Location = New System.Drawing.Point(6, 154)
        Me.optCondition_Index2.Name = "optCondition_Index2"
        Me.optCondition_Index2.Size = New System.Drawing.Size(67, 17)
        Me.optCondition_Index2.TabIndex = 9
        Me.optCondition_Index2.TabStop = True
        Me.optCondition_Index2.Text = "Has Item"
        Me.optCondition_Index2.UseVisualStyleBackColor = True
        '
        'lblRandomLabel35
        '
        Me.lblRandomLabel35.AutoSize = True
        Me.lblRandomLabel35.Location = New System.Drawing.Point(249, 287)
        Me.lblRandomLabel35.Name = "lblRandomLabel35"
        Me.lblRandomLabel35.Size = New System.Drawing.Size(14, 13)
        Me.lblRandomLabel35.TabIndex = 8
        Me.lblRandomLabel35.Text = "is"
        '
        'lblRandomLabel1
        '
        Me.lblRandomLabel1.AutoSize = True
        Me.lblRandomLabel1.Location = New System.Drawing.Point(249, 94)
        Me.lblRandomLabel1.Name = "lblRandomLabel1"
        Me.lblRandomLabel1.Size = New System.Drawing.Size(14, 13)
        Me.lblRandomLabel1.TabIndex = 8
        Me.lblRandomLabel1.Text = "is"
        '
        'cmbCondition_SelfSwitchCondition
        '
        Me.cmbCondition_SelfSwitchCondition.FormattingEnabled = True
        Me.cmbCondition_SelfSwitchCondition.Items.AddRange(New Object() {"True", "False"})
        Me.cmbCondition_SelfSwitchCondition.Location = New System.Drawing.Point(269, 284)
        Me.cmbCondition_SelfSwitchCondition.Name = "cmbCondition_SelfSwitchCondition"
        Me.cmbCondition_SelfSwitchCondition.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_SelfSwitchCondition.TabIndex = 7
        '
        'cmbCondtion_PlayerSwitchCondition
        '
        Me.cmbCondtion_PlayerSwitchCondition.FormattingEnabled = True
        Me.cmbCondtion_PlayerSwitchCondition.Items.AddRange(New Object() {"True", "False"})
        Me.cmbCondtion_PlayerSwitchCondition.Location = New System.Drawing.Point(269, 91)
        Me.cmbCondtion_PlayerSwitchCondition.Name = "cmbCondtion_PlayerSwitchCondition"
        Me.cmbCondtion_PlayerSwitchCondition.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondtion_PlayerSwitchCondition.TabIndex = 7
        '
        'cmbCondition_LevelCompare
        '
        Me.cmbCondition_LevelCompare.FormattingEnabled = True
        Me.cmbCondition_LevelCompare.Items.AddRange(New Object() {"Equal To", "Great Than Or Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"})
        Me.cmbCondition_LevelCompare.Location = New System.Drawing.Point(123, 249)
        Me.cmbCondition_LevelCompare.Name = "cmbCondition_LevelCompare"
        Me.cmbCondition_LevelCompare.Size = New System.Drawing.Size(203, 21)
        Me.cmbCondition_LevelCompare.TabIndex = 6
        '
        'cmbCondition_HasItem
        '
        Me.cmbCondition_HasItem.FormattingEnabled = True
        Me.cmbCondition_HasItem.Location = New System.Drawing.Point(123, 118)
        Me.cmbCondition_HasItem.Name = "cmbCondition_HasItem"
        Me.cmbCondition_HasItem.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_HasItem.TabIndex = 6
        '
        'cmbCondition_SelfSwitch
        '
        Me.cmbCondition_SelfSwitch.FormattingEnabled = True
        Me.cmbCondition_SelfSwitch.Location = New System.Drawing.Point(123, 284)
        Me.cmbCondition_SelfSwitch.Name = "cmbCondition_SelfSwitch"
        Me.cmbCondition_SelfSwitch.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_SelfSwitch.TabIndex = 6
        '
        'cmbCondition_PlayerSwitch
        '
        Me.cmbCondition_PlayerSwitch.FormattingEnabled = True
        Me.cmbCondition_PlayerSwitch.Location = New System.Drawing.Point(123, 91)
        Me.cmbCondition_PlayerSwitch.Name = "cmbCondition_PlayerSwitch"
        Me.cmbCondition_PlayerSwitch.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_PlayerSwitch.TabIndex = 6
        '
        'optCondition_Index1
        '
        Me.optCondition_Index1.AutoSize = True
        Me.optCondition_Index1.Location = New System.Drawing.Point(6, 92)
        Me.optCondition_Index1.Name = "optCondition_Index1"
        Me.optCondition_Index1.Size = New System.Drawing.Size(89, 17)
        Me.optCondition_Index1.TabIndex = 5
        Me.optCondition_Index1.TabStop = True
        Me.optCondition_Index1.Text = "Player Switch"
        Me.optCondition_Index1.UseVisualStyleBackColor = True
        '
        'txtCondition_LevelAmount
        '
        Me.txtCondition_LevelAmount.Location = New System.Drawing.Point(332, 249)
        Me.txtCondition_LevelAmount.Name = "txtCondition_LevelAmount"
        Me.txtCondition_LevelAmount.Size = New System.Drawing.Size(58, 20)
        Me.txtCondition_LevelAmount.TabIndex = 4
        Me.txtCondition_LevelAmount.Text = "0"
        '
        'txtCondition_PlayerVarCondition
        '
        Me.txtCondition_PlayerVarCondition.Location = New System.Drawing.Point(269, 51)
        Me.txtCondition_PlayerVarCondition.Name = "txtCondition_PlayerVarCondition"
        Me.txtCondition_PlayerVarCondition.Size = New System.Drawing.Size(100, 20)
        Me.txtCondition_PlayerVarCondition.TabIndex = 4
        Me.txtCondition_PlayerVarCondition.Text = "0"
        '
        'cmbCondition_PlayerVarCompare
        '
        Me.cmbCondition_PlayerVarCompare.FormattingEnabled = True
        Me.cmbCondition_PlayerVarCompare.Items.AddRange(New Object() {"Equal To", "Great Than Or Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"})
        Me.cmbCondition_PlayerVarCompare.Location = New System.Drawing.Point(123, 51)
        Me.cmbCondition_PlayerVarCompare.Name = "cmbCondition_PlayerVarCompare"
        Me.cmbCondition_PlayerVarCompare.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_PlayerVarCompare.TabIndex = 3
        '
        'lblRandomLabel0
        '
        Me.lblRandomLabel0.Location = New System.Drawing.Point(250, 25)
        Me.lblRandomLabel0.Name = "lblRandomLabel0"
        Me.lblRandomLabel0.Size = New System.Drawing.Size(115, 20)
        Me.lblRandomLabel0.TabIndex = 2
        Me.lblRandomLabel0.Text = "is"
        '
        'cmbCondition_PlayerVarIndex
        '
        Me.cmbCondition_PlayerVarIndex.FormattingEnabled = True
        Me.cmbCondition_PlayerVarIndex.Location = New System.Drawing.Point(123, 24)
        Me.cmbCondition_PlayerVarIndex.Name = "cmbCondition_PlayerVarIndex"
        Me.cmbCondition_PlayerVarIndex.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition_PlayerVarIndex.TabIndex = 1
        '
        'optCondition_Index0
        '
        Me.optCondition_Index0.AutoSize = True
        Me.optCondition_Index0.Location = New System.Drawing.Point(6, 25)
        Me.optCondition_Index0.Name = "optCondition_Index0"
        Me.optCondition_Index0.Size = New System.Drawing.Size(95, 17)
        Me.optCondition_Index0.TabIndex = 0
        Me.optCondition_Index0.TabStop = True
        Me.optCondition_Index0.Text = "Player Variable"
        Me.optCondition_Index0.UseVisualStyleBackColor = True
        '
        'fraCommand27
        '
        Me.fraCommand27.Controls.Add(Me.btnCommand_Ok26)
        Me.fraCommand27.Controls.Add(Me.btnCommand_Cancel26)
        Me.fraCommand27.Controls.Add(Me.scrlWaitAmount)
        Me.fraCommand27.Controls.Add(Me.lblRandomLabel44)
        Me.fraCommand27.Controls.Add(Me.lblWaitAmount)
        Me.fraCommand27.Location = New System.Drawing.Point(432, 288)
        Me.fraCommand27.Name = "fraCommand27"
        Me.fraCommand27.Size = New System.Drawing.Size(220, 84)
        Me.fraCommand27.TabIndex = 34
        Me.fraCommand27.TabStop = False
        Me.fraCommand27.Text = "Wait..."
        Me.fraCommand27.Visible = False
        '
        'btnCommand_Ok26
        '
        Me.btnCommand_Ok26.Location = New System.Drawing.Point(57, 55)
        Me.btnCommand_Ok26.Name = "btnCommand_Ok26"
        Me.btnCommand_Ok26.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok26.TabIndex = 28
        Me.btnCommand_Ok26.Text = "Ok"
        Me.btnCommand_Ok26.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel26
        '
        Me.btnCommand_Cancel26.Location = New System.Drawing.Point(138, 55)
        Me.btnCommand_Cancel26.Name = "btnCommand_Cancel26"
        Me.btnCommand_Cancel26.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel26.TabIndex = 27
        Me.btnCommand_Cancel26.Text = "Cancel"
        Me.btnCommand_Cancel26.UseVisualStyleBackColor = True
        '
        'scrlWaitAmount
        '
        Me.scrlWaitAmount.Location = New System.Drawing.Point(3, 35)
        Me.scrlWaitAmount.Name = "scrlWaitAmount"
        Me.scrlWaitAmount.Size = New System.Drawing.Size(211, 17)
        Me.scrlWaitAmount.TabIndex = 17
        '
        'lblRandomLabel44
        '
        Me.lblRandomLabel44.AutoSize = True
        Me.lblRandomLabel44.Location = New System.Drawing.Point(83, 14)
        Me.lblRandomLabel44.Name = "lblRandomLabel44"
        Me.lblRandomLabel44.Size = New System.Drawing.Size(131, 13)
        Me.lblRandomLabel44.TabIndex = 16
        Me.lblRandomLabel44.Text = "Hint: 1000 Ms = 1 Second"
        '
        'lblWaitAmount
        '
        Me.lblWaitAmount.AutoSize = True
        Me.lblWaitAmount.Location = New System.Drawing.Point(6, 16)
        Me.lblWaitAmount.Name = "lblWaitAmount"
        Me.lblWaitAmount.Size = New System.Drawing.Size(58, 13)
        Me.lblWaitAmount.TabIndex = 14
        Me.lblWaitAmount.Text = "Wait: 0 Ms"
        '
        'fraCommand23
        '
        Me.fraCommand23.Controls.Add(Me.btnCommand_Ok22)
        Me.fraCommand23.Controls.Add(Me.btnCommand_Cancel22)
        Me.fraCommand23.Controls.Add(Me.scrlWeatherIntensity)
        Me.fraCommand23.Controls.Add(Me.lblWeatherIntensity)
        Me.fraCommand23.Controls.Add(Me.CmbWeather)
        Me.fraCommand23.Controls.Add(Me.lblRandomLabel43)
        Me.fraCommand23.Location = New System.Drawing.Point(432, 170)
        Me.fraCommand23.Name = "fraCommand23"
        Me.fraCommand23.Size = New System.Drawing.Size(220, 112)
        Me.fraCommand23.TabIndex = 33
        Me.fraCommand23.TabStop = False
        Me.fraCommand23.Text = "Set Weather"
        Me.fraCommand23.Visible = False
        '
        'btnCommand_Ok22
        '
        Me.btnCommand_Ok22.Location = New System.Drawing.Point(58, 83)
        Me.btnCommand_Ok22.Name = "btnCommand_Ok22"
        Me.btnCommand_Ok22.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok22.TabIndex = 28
        Me.btnCommand_Ok22.Text = "Ok"
        Me.btnCommand_Ok22.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel22
        '
        Me.btnCommand_Cancel22.Location = New System.Drawing.Point(139, 83)
        Me.btnCommand_Cancel22.Name = "btnCommand_Cancel22"
        Me.btnCommand_Cancel22.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel22.TabIndex = 27
        Me.btnCommand_Cancel22.Text = "Cancel"
        Me.btnCommand_Cancel22.UseVisualStyleBackColor = True
        '
        'scrlWeatherIntensity
        '
        Me.scrlWeatherIntensity.Location = New System.Drawing.Point(85, 57)
        Me.scrlWeatherIntensity.Name = "scrlWeatherIntensity"
        Me.scrlWeatherIntensity.Size = New System.Drawing.Size(128, 17)
        Me.scrlWeatherIntensity.TabIndex = 17
        '
        'lblWeatherIntensity
        '
        Me.lblWeatherIntensity.AutoSize = True
        Me.lblWeatherIntensity.Location = New System.Drawing.Point(6, 59)
        Me.lblWeatherIntensity.Name = "lblWeatherIntensity"
        Me.lblWeatherIntensity.Size = New System.Drawing.Size(58, 13)
        Me.lblWeatherIntensity.TabIndex = 16
        Me.lblWeatherIntensity.Text = "Intensity: 0"
        '
        'CmbWeather
        '
        Me.CmbWeather.FormattingEnabled = True
        Me.CmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm"})
        Me.CmbWeather.Location = New System.Drawing.Point(6, 33)
        Me.CmbWeather.Name = "CmbWeather"
        Me.CmbWeather.Size = New System.Drawing.Size(207, 21)
        Me.CmbWeather.TabIndex = 15
        '
        'lblRandomLabel43
        '
        Me.lblRandomLabel43.AutoSize = True
        Me.lblRandomLabel43.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel43.Name = "lblRandomLabel43"
        Me.lblRandomLabel43.Size = New System.Drawing.Size(78, 13)
        Me.lblRandomLabel43.TabIndex = 14
        Me.lblRandomLabel43.Text = "Weather Type:"
        '
        'fraCommand18
        '
        Me.fraCommand18.Controls.Add(Me.cmbWarpPlayerDir)
        Me.fraCommand18.Controls.Add(Me.scrlWPY)
        Me.fraCommand18.Controls.Add(Me.lblWPY)
        Me.fraCommand18.Controls.Add(Me.lblWPX)
        Me.fraCommand18.Controls.Add(Me.scrlWPX)
        Me.fraCommand18.Controls.Add(Me.btnCommand_Ok17)
        Me.fraCommand18.Controls.Add(Me.btnCommand_Cancel17)
        Me.fraCommand18.Controls.Add(Me.lblWPMap)
        Me.fraCommand18.Controls.Add(Me.scrlWPMap)
        Me.fraCommand18.Location = New System.Drawing.Point(418, 84)
        Me.fraCommand18.Name = "fraCommand18"
        Me.fraCommand18.Size = New System.Drawing.Size(245, 145)
        Me.fraCommand18.TabIndex = 32
        Me.fraCommand18.TabStop = False
        Me.fraCommand18.Text = "Warp Player"
        Me.fraCommand18.Visible = False
        '
        'cmbWarpPlayerDir
        '
        Me.cmbWarpPlayerDir.FormattingEnabled = True
        Me.cmbWarpPlayerDir.Location = New System.Drawing.Point(10, 85)
        Me.cmbWarpPlayerDir.Name = "cmbWarpPlayerDir"
        Me.cmbWarpPlayerDir.Size = New System.Drawing.Size(229, 21)
        Me.cmbWarpPlayerDir.TabIndex = 26
        '
        'scrlWPY
        '
        Me.scrlWPY.Location = New System.Drawing.Point(96, 65)
        Me.scrlWPY.Name = "scrlWPY"
        Me.scrlWPY.Size = New System.Drawing.Size(143, 17)
        Me.scrlWPY.TabIndex = 25
        '
        'lblWPY
        '
        Me.lblWPY.AutoSize = True
        Me.lblWPY.Location = New System.Drawing.Point(5, 68)
        Me.lblWPY.Name = "lblWPY"
        Me.lblWPY.Size = New System.Drawing.Size(26, 13)
        Me.lblWPY.TabIndex = 24
        Me.lblWPY.Text = "Y: 0"
        '
        'lblWPX
        '
        Me.lblWPX.AutoSize = True
        Me.lblWPX.Location = New System.Drawing.Point(6, 42)
        Me.lblWPX.Name = "lblWPX"
        Me.lblWPX.Size = New System.Drawing.Size(26, 13)
        Me.lblWPX.TabIndex = 23
        Me.lblWPX.Text = "X: 0"
        '
        'scrlWPX
        '
        Me.scrlWPX.Location = New System.Drawing.Point(96, 39)
        Me.scrlWPX.Name = "scrlWPX"
        Me.scrlWPX.Size = New System.Drawing.Size(143, 17)
        Me.scrlWPX.TabIndex = 22
        '
        'btnCommand_Ok17
        '
        Me.btnCommand_Ok17.Location = New System.Drawing.Point(83, 116)
        Me.btnCommand_Ok17.Name = "btnCommand_Ok17"
        Me.btnCommand_Ok17.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok17.TabIndex = 20
        Me.btnCommand_Ok17.Text = "Ok"
        Me.btnCommand_Ok17.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel17
        '
        Me.btnCommand_Cancel17.Location = New System.Drawing.Point(164, 116)
        Me.btnCommand_Cancel17.Name = "btnCommand_Cancel17"
        Me.btnCommand_Cancel17.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel17.TabIndex = 19
        Me.btnCommand_Cancel17.Text = "Cancel"
        Me.btnCommand_Cancel17.UseVisualStyleBackColor = True
        '
        'lblWPMap
        '
        Me.lblWPMap.AutoSize = True
        Me.lblWPMap.Location = New System.Drawing.Point(6, 16)
        Me.lblWPMap.Name = "lblWPMap"
        Me.lblWPMap.Size = New System.Drawing.Size(40, 13)
        Me.lblWPMap.TabIndex = 13
        Me.lblWPMap.Text = "Map: 0"
        '
        'scrlWPMap
        '
        Me.scrlWPMap.Location = New System.Drawing.Point(96, 14)
        Me.scrlWPMap.Name = "scrlWPMap"
        Me.scrlWPMap.Size = New System.Drawing.Size(143, 17)
        Me.scrlWPMap.TabIndex = 12
        '
        'fraCommand34
        '
        Me.fraCommand34.Controls.Add(Me.lblRandomLabel58)
        Me.fraCommand34.Controls.Add(Me.btnCommand_Ok34)
        Me.fraCommand34.Controls.Add(Me.btnCommand_Cancel34)
        Me.fraCommand34.Controls.Add(Me.cmbHidePic)
        Me.fraCommand34.Location = New System.Drawing.Point(432, 11)
        Me.fraCommand34.Name = "fraCommand34"
        Me.fraCommand34.Size = New System.Drawing.Size(219, 69)
        Me.fraCommand34.TabIndex = 31
        Me.fraCommand34.TabStop = False
        Me.fraCommand34.Text = "Hide Picture"
        Me.fraCommand34.Visible = False
        '
        'lblRandomLabel58
        '
        Me.lblRandomLabel58.AutoSize = True
        Me.lblRandomLabel58.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel58.Name = "lblRandomLabel58"
        Me.lblRandomLabel58.Size = New System.Drawing.Size(71, 13)
        Me.lblRandomLabel58.TabIndex = 27
        Me.lblRandomLabel58.Text = "Picture index:"
        '
        'btnCommand_Ok34
        '
        Me.btnCommand_Ok34.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok34.Name = "btnCommand_Ok34"
        Me.btnCommand_Ok34.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok34.TabIndex = 26
        Me.btnCommand_Ok34.Text = "Ok"
        Me.btnCommand_Ok34.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel34
        '
        Me.btnCommand_Cancel34.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel34.Name = "btnCommand_Cancel34"
        Me.btnCommand_Cancel34.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel34.TabIndex = 25
        Me.btnCommand_Cancel34.Text = "Cancel"
        Me.btnCommand_Cancel34.UseVisualStyleBackColor = True
        '
        'cmbHidePic
        '
        Me.cmbHidePic.FormattingEnabled = True
        Me.cmbHidePic.Location = New System.Drawing.Point(88, 13)
        Me.cmbHidePic.Name = "cmbHidePic"
        Me.cmbHidePic.Size = New System.Drawing.Size(125, 21)
        Me.cmbHidePic.TabIndex = 2
        '
        'fraCommand35
        '
        Me.fraCommand35.Controls.Add(Me.lblRandomLabel59)
        Me.fraCommand35.Controls.Add(Me.btnCommand_Ok35)
        Me.fraCommand35.Controls.Add(Me.btnCommand_Cancel35)
        Me.fraCommand35.Controls.Add(Me.cmbMoveWait)
        Me.fraCommand35.Location = New System.Drawing.Point(433, 11)
        Me.fraCommand35.Name = "fraCommand35"
        Me.fraCommand35.Size = New System.Drawing.Size(219, 69)
        Me.fraCommand35.TabIndex = 30
        Me.fraCommand35.TabStop = False
        Me.fraCommand35.Text = "Wait for Move Route Completion"
        Me.fraCommand35.Visible = False
        '
        'lblRandomLabel59
        '
        Me.lblRandomLabel59.AutoSize = True
        Me.lblRandomLabel59.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel59.Name = "lblRandomLabel59"
        Me.lblRandomLabel59.Size = New System.Drawing.Size(38, 13)
        Me.lblRandomLabel59.TabIndex = 27
        Me.lblRandomLabel59.Text = "Event:"
        '
        'btnCommand_Ok35
        '
        Me.btnCommand_Ok35.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok35.Name = "btnCommand_Ok35"
        Me.btnCommand_Ok35.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok35.TabIndex = 26
        Me.btnCommand_Ok35.Text = "Ok"
        Me.btnCommand_Ok35.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel35
        '
        Me.btnCommand_Cancel35.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel35.Name = "btnCommand_Cancel35"
        Me.btnCommand_Cancel35.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel35.TabIndex = 25
        Me.btnCommand_Cancel35.Text = "Cancel"
        Me.btnCommand_Cancel35.UseVisualStyleBackColor = True
        '
        'cmbMoveWait
        '
        Me.cmbMoveWait.FormattingEnabled = True
        Me.cmbMoveWait.Location = New System.Drawing.Point(50, 13)
        Me.cmbMoveWait.Name = "cmbMoveWait"
        Me.cmbMoveWait.Size = New System.Drawing.Size(163, 21)
        Me.cmbMoveWait.TabIndex = 2
        '
        'fraCommand20
        '
        Me.fraCommand20.Controls.Add(Me.fraCommand29)
        Me.fraCommand20.Controls.Add(Me.cmbPlayAnimEvent)
        Me.fraCommand20.Controls.Add(Me.lblPlayAnimY)
        Me.fraCommand20.Controls.Add(Me.scrlPlayAnimTileY)
        Me.fraCommand20.Controls.Add(Me.cmbPlayAnim)
        Me.fraCommand20.Controls.Add(Me.btnCommand_Ok19)
        Me.fraCommand20.Controls.Add(Me.btnCommand_Cancel19)
        Me.fraCommand20.Controls.Add(Me.optPlayAnimTile)
        Me.fraCommand20.Controls.Add(Me.optPlayAnimEvent)
        Me.fraCommand20.Controls.Add(Me.optPlayAnimPlayer)
        Me.fraCommand20.Controls.Add(Me.lblRandomLabel31)
        Me.fraCommand20.Controls.Add(Me.lblPlayAnimX)
        Me.fraCommand20.Controls.Add(Me.scrlPlayAnimTileX)
        Me.fraCommand20.Controls.Add(Me.lblRandomLabel30)
        Me.fraCommand20.Location = New System.Drawing.Point(418, 14)
        Me.fraCommand20.Name = "fraCommand20"
        Me.fraCommand20.Size = New System.Drawing.Size(245, 174)
        Me.fraCommand20.TabIndex = 23
        Me.fraCommand20.TabStop = False
        Me.fraCommand20.Text = "Play Animation"
        Me.fraCommand20.Visible = False
        '
        'fraCommand29
        '
        Me.fraCommand29.Controls.Add(Me.btnCommand_Ok28)
        Me.fraCommand29.Controls.Add(Me.btnCommand_Cancel28)
        Me.fraCommand29.Controls.Add(Me.scrlCustomScript)
        Me.fraCommand29.Controls.Add(Me.lblCustomScript)
        Me.fraCommand29.Location = New System.Drawing.Point(0, 3)
        Me.fraCommand29.Name = "fraCommand29"
        Me.fraCommand29.Size = New System.Drawing.Size(245, 84)
        Me.fraCommand29.TabIndex = 35
        Me.fraCommand29.TabStop = False
        Me.fraCommand29.Text = "Execute Custom Script"
        Me.fraCommand29.Visible = False
        '
        'btnCommand_Ok28
        '
        Me.btnCommand_Ok28.Location = New System.Drawing.Point(83, 55)
        Me.btnCommand_Ok28.Name = "btnCommand_Ok28"
        Me.btnCommand_Ok28.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok28.TabIndex = 28
        Me.btnCommand_Ok28.Text = "Ok"
        Me.btnCommand_Ok28.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel28
        '
        Me.btnCommand_Cancel28.Location = New System.Drawing.Point(164, 55)
        Me.btnCommand_Cancel28.Name = "btnCommand_Cancel28"
        Me.btnCommand_Cancel28.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel28.TabIndex = 27
        Me.btnCommand_Cancel28.Text = "Cancel"
        Me.btnCommand_Cancel28.UseVisualStyleBackColor = True
        '
        'scrlCustomScript
        '
        Me.scrlCustomScript.Location = New System.Drawing.Point(3, 35)
        Me.scrlCustomScript.Name = "scrlCustomScript"
        Me.scrlCustomScript.Size = New System.Drawing.Size(234, 17)
        Me.scrlCustomScript.TabIndex = 17
        '
        'lblCustomScript
        '
        Me.lblCustomScript.AutoSize = True
        Me.lblCustomScript.Location = New System.Drawing.Point(6, 16)
        Me.lblCustomScript.Name = "lblCustomScript"
        Me.lblCustomScript.Size = New System.Drawing.Size(43, 13)
        Me.lblCustomScript.TabIndex = 14
        Me.lblCustomScript.Text = "Case: 1"
        '
        'cmbPlayAnimEvent
        '
        Me.cmbPlayAnimEvent.FormattingEnabled = True
        Me.cmbPlayAnimEvent.Location = New System.Drawing.Point(67, 74)
        Me.cmbPlayAnimEvent.Name = "cmbPlayAnimEvent"
        Me.cmbPlayAnimEvent.Size = New System.Drawing.Size(175, 21)
        Me.cmbPlayAnimEvent.TabIndex = 24
        '
        'lblPlayAnimY
        '
        Me.lblPlayAnimY.AutoSize = True
        Me.lblPlayAnimY.Location = New System.Drawing.Point(6, 124)
        Me.lblPlayAnimY.Name = "lblPlayAnimY"
        Me.lblPlayAnimY.Size = New System.Drawing.Size(61, 13)
        Me.lblPlayAnimY.TabIndex = 23
        Me.lblPlayAnimY.Text = "Map Tile Y:"
        '
        'scrlPlayAnimTileY
        '
        Me.scrlPlayAnimTileY.Location = New System.Drawing.Point(70, 123)
        Me.scrlPlayAnimTileY.Name = "scrlPlayAnimTileY"
        Me.scrlPlayAnimTileY.Size = New System.Drawing.Size(169, 17)
        Me.scrlPlayAnimTileY.TabIndex = 22
        '
        'cmbPlayAnim
        '
        Me.cmbPlayAnim.FormattingEnabled = True
        Me.cmbPlayAnim.Location = New System.Drawing.Point(64, 13)
        Me.cmbPlayAnim.Name = "cmbPlayAnim"
        Me.cmbPlayAnim.Size = New System.Drawing.Size(175, 21)
        Me.cmbPlayAnim.TabIndex = 21
        '
        'btnCommand_Ok19
        '
        Me.btnCommand_Ok19.Location = New System.Drawing.Point(83, 146)
        Me.btnCommand_Ok19.Name = "btnCommand_Ok19"
        Me.btnCommand_Ok19.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok19.TabIndex = 20
        Me.btnCommand_Ok19.Text = "Ok"
        Me.btnCommand_Ok19.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel19
        '
        Me.btnCommand_Cancel19.Location = New System.Drawing.Point(164, 146)
        Me.btnCommand_Cancel19.Name = "btnCommand_Cancel19"
        Me.btnCommand_Cancel19.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel19.TabIndex = 19
        Me.btnCommand_Cancel19.Text = "Cancel"
        Me.btnCommand_Cancel19.UseVisualStyleBackColor = True
        '
        'optPlayAnimTile
        '
        Me.optPlayAnimTile.AutoSize = True
        Me.optPlayAnimTile.Location = New System.Drawing.Point(128, 58)
        Me.optPlayAnimTile.Name = "optPlayAnimTile"
        Me.optPlayAnimTile.Size = New System.Drawing.Size(42, 17)
        Me.optPlayAnimTile.TabIndex = 17
        Me.optPlayAnimTile.TabStop = True
        Me.optPlayAnimTile.Text = "Tile"
        Me.optPlayAnimTile.UseVisualStyleBackColor = True
        '
        'optPlayAnimEvent
        '
        Me.optPlayAnimEvent.AutoSize = True
        Me.optPlayAnimEvent.Location = New System.Drawing.Point(71, 58)
        Me.optPlayAnimEvent.Name = "optPlayAnimEvent"
        Me.optPlayAnimEvent.Size = New System.Drawing.Size(53, 17)
        Me.optPlayAnimEvent.TabIndex = 16
        Me.optPlayAnimEvent.TabStop = True
        Me.optPlayAnimEvent.Text = "Event"
        Me.optPlayAnimEvent.UseVisualStyleBackColor = True
        '
        'optPlayAnimPlayer
        '
        Me.optPlayAnimPlayer.AutoSize = True
        Me.optPlayAnimPlayer.Location = New System.Drawing.Point(9, 58)
        Me.optPlayAnimPlayer.Name = "optPlayAnimPlayer"
        Me.optPlayAnimPlayer.Size = New System.Drawing.Size(54, 17)
        Me.optPlayAnimPlayer.TabIndex = 15
        Me.optPlayAnimPlayer.TabStop = True
        Me.optPlayAnimPlayer.Text = "Player"
        Me.optPlayAnimPlayer.UseVisualStyleBackColor = True
        '
        'lblRandomLabel31
        '
        Me.lblRandomLabel31.AutoSize = True
        Me.lblRandomLabel31.Location = New System.Drawing.Point(6, 42)
        Me.lblRandomLabel31.Name = "lblRandomLabel31"
        Me.lblRandomLabel31.Size = New System.Drawing.Size(68, 13)
        Me.lblRandomLabel31.TabIndex = 14
        Me.lblRandomLabel31.Text = "Target Type:"
        '
        'lblPlayAnimX
        '
        Me.lblPlayAnimX.AutoSize = True
        Me.lblPlayAnimX.Location = New System.Drawing.Point(6, 98)
        Me.lblPlayAnimX.Name = "lblPlayAnimX"
        Me.lblPlayAnimX.Size = New System.Drawing.Size(61, 13)
        Me.lblPlayAnimX.TabIndex = 13
        Me.lblPlayAnimX.Text = "Map Tile X:"
        '
        'scrlPlayAnimTileX
        '
        Me.scrlPlayAnimTileX.Location = New System.Drawing.Point(70, 97)
        Me.scrlPlayAnimTileX.Name = "scrlPlayAnimTileX"
        Me.scrlPlayAnimTileX.Size = New System.Drawing.Size(169, 17)
        Me.scrlPlayAnimTileX.TabIndex = 12
        '
        'lblRandomLabel30
        '
        Me.lblRandomLabel30.AutoSize = True
        Me.lblRandomLabel30.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel30.Name = "lblRandomLabel30"
        Me.lblRandomLabel30.Size = New System.Drawing.Size(56, 13)
        Me.lblRandomLabel30.TabIndex = 0
        Me.lblRandomLabel30.Text = "Animation:"
        '
        'fraCommand31
        '
        Me.fraCommand31.Controls.Add(Me.lblRandomLabel46)
        Me.fraCommand31.Controls.Add(Me.btnCommand_Ok31)
        Me.fraCommand31.Controls.Add(Me.btnCommand_Cancel31)
        Me.fraCommand31.Controls.Add(Me.cmbEndQuest)
        Me.fraCommand31.Location = New System.Drawing.Point(432, 82)
        Me.fraCommand31.Name = "fraCommand31"
        Me.fraCommand31.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand31.TabIndex = 29
        Me.fraCommand31.TabStop = False
        Me.fraCommand31.Text = "End Quest"
        Me.fraCommand31.Visible = False
        '
        'lblRandomLabel46
        '
        Me.lblRandomLabel46.AutoSize = True
        Me.lblRandomLabel46.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel46.Name = "lblRandomLabel46"
        Me.lblRandomLabel46.Size = New System.Drawing.Size(38, 13)
        Me.lblRandomLabel46.TabIndex = 27
        Me.lblRandomLabel46.Text = "Quest:"
        '
        'btnCommand_Ok31
        '
        Me.btnCommand_Ok31.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok31.Name = "btnCommand_Ok31"
        Me.btnCommand_Ok31.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok31.TabIndex = 26
        Me.btnCommand_Ok31.Text = "Ok"
        Me.btnCommand_Ok31.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel31
        '
        Me.btnCommand_Cancel31.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel31.Name = "btnCommand_Cancel31"
        Me.btnCommand_Cancel31.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel31.TabIndex = 25
        Me.btnCommand_Cancel31.Text = "Cancel"
        Me.btnCommand_Cancel31.UseVisualStyleBackColor = True
        '
        'cmbEndQuest
        '
        Me.cmbEndQuest.FormattingEnabled = True
        Me.cmbEndQuest.Location = New System.Drawing.Point(50, 13)
        Me.cmbEndQuest.Name = "cmbEndQuest"
        Me.cmbEndQuest.Size = New System.Drawing.Size(163, 21)
        Me.cmbEndQuest.TabIndex = 2
        '
        'fraCommand30
        '
        Me.fraCommand30.Controls.Add(Me.lblRandomLabel45)
        Me.fraCommand30.Controls.Add(Me.btnCommand_Ok32)
        Me.fraCommand30.Controls.Add(Me.btnCommand_Cancel32)
        Me.fraCommand30.Controls.Add(Me.cmbBeginQuest)
        Me.fraCommand30.Location = New System.Drawing.Point(432, 11)
        Me.fraCommand30.Name = "fraCommand30"
        Me.fraCommand30.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand30.TabIndex = 28
        Me.fraCommand30.TabStop = False
        Me.fraCommand30.Text = "Begin Quest"
        Me.fraCommand30.Visible = False
        '
        'lblRandomLabel45
        '
        Me.lblRandomLabel45.AutoSize = True
        Me.lblRandomLabel45.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel45.Name = "lblRandomLabel45"
        Me.lblRandomLabel45.Size = New System.Drawing.Size(38, 13)
        Me.lblRandomLabel45.TabIndex = 27
        Me.lblRandomLabel45.Text = "Quest:"
        '
        'btnCommand_Ok32
        '
        Me.btnCommand_Ok32.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok32.Name = "btnCommand_Ok32"
        Me.btnCommand_Ok32.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok32.TabIndex = 26
        Me.btnCommand_Ok32.Text = "Ok"
        Me.btnCommand_Ok32.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel32
        '
        Me.btnCommand_Cancel32.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel32.Name = "btnCommand_Cancel32"
        Me.btnCommand_Cancel32.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel32.TabIndex = 25
        Me.btnCommand_Cancel32.Text = "Cancel"
        Me.btnCommand_Cancel32.UseVisualStyleBackColor = True
        '
        'cmbBeginQuest
        '
        Me.cmbBeginQuest.FormattingEnabled = True
        Me.cmbBeginQuest.Location = New System.Drawing.Point(50, 13)
        Me.cmbBeginQuest.Name = "cmbBeginQuest"
        Me.cmbBeginQuest.Size = New System.Drawing.Size(163, 21)
        Me.cmbBeginQuest.TabIndex = 2
        '
        'fraCommand28
        '
        Me.fraCommand28.Controls.Add(Me.btnCommand_Ok27)
        Me.fraCommand28.Controls.Add(Me.btnCommand_Cancel27)
        Me.fraCommand28.Controls.Add(Me.cmbSetAccess)
        Me.fraCommand28.Location = New System.Drawing.Point(433, 10)
        Me.fraCommand28.Name = "fraCommand28"
        Me.fraCommand28.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand28.TabIndex = 27
        Me.fraCommand28.TabStop = False
        Me.fraCommand28.Text = "Set Access"
        Me.fraCommand28.Visible = False
        '
        'btnCommand_Ok27
        '
        Me.btnCommand_Ok27.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok27.Name = "btnCommand_Ok27"
        Me.btnCommand_Ok27.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok27.TabIndex = 26
        Me.btnCommand_Ok27.Text = "Ok"
        Me.btnCommand_Ok27.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel27
        '
        Me.btnCommand_Cancel27.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel27.Name = "btnCommand_Cancel27"
        Me.btnCommand_Cancel27.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel27.TabIndex = 25
        Me.btnCommand_Cancel27.Text = "Cancel"
        Me.btnCommand_Cancel27.UseVisualStyleBackColor = True
        '
        'cmbSetAccess
        '
        Me.cmbSetAccess.FormattingEnabled = True
        Me.cmbSetAccess.Items.AddRange(New Object() {"0: No Access", "1: Monitor", "2: Mapper", "3: Developer", "4: Creator"})
        Me.cmbSetAccess.Location = New System.Drawing.Point(42, 13)
        Me.cmbSetAccess.Name = "cmbSetAccess"
        Me.cmbSetAccess.Size = New System.Drawing.Size(171, 21)
        Me.cmbSetAccess.TabIndex = 2
        '
        'fraCommand25
        '
        Me.fraCommand25.Controls.Add(Me.btnCommand_Ok24)
        Me.fraCommand25.Controls.Add(Me.btnCommand_Cancel24)
        Me.fraCommand25.Controls.Add(Me.cmbPlayBGM)
        Me.fraCommand25.Location = New System.Drawing.Point(432, 10)
        Me.fraCommand25.Name = "fraCommand25"
        Me.fraCommand25.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand25.TabIndex = 26
        Me.fraCommand25.TabStop = False
        Me.fraCommand25.Text = "Play BGM"
        Me.fraCommand25.Visible = False
        '
        'btnCommand_Ok24
        '
        Me.btnCommand_Ok24.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok24.Name = "btnCommand_Ok24"
        Me.btnCommand_Ok24.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok24.TabIndex = 26
        Me.btnCommand_Ok24.Text = "Ok"
        Me.btnCommand_Ok24.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel24
        '
        Me.btnCommand_Cancel24.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel24.Name = "btnCommand_Cancel24"
        Me.btnCommand_Cancel24.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel24.TabIndex = 25
        Me.btnCommand_Cancel24.Text = "Cancel"
        Me.btnCommand_Cancel24.UseVisualStyleBackColor = True
        '
        'cmbPlayBGM
        '
        Me.cmbPlayBGM.FormattingEnabled = True
        Me.cmbPlayBGM.Location = New System.Drawing.Point(42, 13)
        Me.cmbPlayBGM.Name = "cmbPlayBGM"
        Me.cmbPlayBGM.Size = New System.Drawing.Size(171, 21)
        Me.cmbPlayBGM.TabIndex = 2
        '
        'fraCommand24
        '
        Me.fraCommand24.Controls.Add(Me.scrlMapTintData3)
        Me.fraCommand24.Controls.Add(Me.lblMapTintData3)
        Me.fraCommand24.Controls.Add(Me.scrlMapTintData2)
        Me.fraCommand24.Controls.Add(Me.lblMapTintData2)
        Me.fraCommand24.Controls.Add(Me.lblMapTintData1)
        Me.fraCommand24.Controls.Add(Me.scrlMapTintData1)
        Me.fraCommand24.Controls.Add(Me.btnCommand_Ok23)
        Me.fraCommand24.Controls.Add(Me.btnCommand_Cancel23)
        Me.fraCommand24.Controls.Add(Me.lblMapTintData0)
        Me.fraCommand24.Controls.Add(Me.scrlMapTintData0)
        Me.fraCommand24.Location = New System.Drawing.Point(418, 148)
        Me.fraCommand24.Name = "fraCommand24"
        Me.fraCommand24.Size = New System.Drawing.Size(245, 145)
        Me.fraCommand24.TabIndex = 25
        Me.fraCommand24.TabStop = False
        Me.fraCommand24.Text = "Map Overlay"
        Me.fraCommand24.Visible = False
        '
        'scrlMapTintData3
        '
        Me.scrlMapTintData3.Location = New System.Drawing.Point(96, 89)
        Me.scrlMapTintData3.Name = "scrlMapTintData3"
        Me.scrlMapTintData3.Size = New System.Drawing.Size(143, 17)
        Me.scrlMapTintData3.TabIndex = 27
        '
        'lblMapTintData3
        '
        Me.lblMapTintData3.AutoSize = True
        Me.lblMapTintData3.Location = New System.Drawing.Point(6, 92)
        Me.lblMapTintData3.Name = "lblMapTintData3"
        Me.lblMapTintData3.Size = New System.Drawing.Size(55, 13)
        Me.lblMapTintData3.TabIndex = 26
        Me.lblMapTintData3.Text = "Opacity: 0"
        '
        'scrlMapTintData2
        '
        Me.scrlMapTintData2.Location = New System.Drawing.Point(96, 65)
        Me.scrlMapTintData2.Name = "scrlMapTintData2"
        Me.scrlMapTintData2.Size = New System.Drawing.Size(143, 17)
        Me.scrlMapTintData2.TabIndex = 25
        '
        'lblMapTintData2
        '
        Me.lblMapTintData2.AutoSize = True
        Me.lblMapTintData2.Location = New System.Drawing.Point(5, 68)
        Me.lblMapTintData2.Name = "lblMapTintData2"
        Me.lblMapTintData2.Size = New System.Drawing.Size(40, 13)
        Me.lblMapTintData2.TabIndex = 24
        Me.lblMapTintData2.Text = "Blue: 0"
        '
        'lblMapTintData1
        '
        Me.lblMapTintData1.AutoSize = True
        Me.lblMapTintData1.Location = New System.Drawing.Point(6, 42)
        Me.lblMapTintData1.Name = "lblMapTintData1"
        Me.lblMapTintData1.Size = New System.Drawing.Size(48, 13)
        Me.lblMapTintData1.TabIndex = 23
        Me.lblMapTintData1.Text = "Green: 0"
        '
        'scrlMapTintData1
        '
        Me.scrlMapTintData1.Location = New System.Drawing.Point(96, 39)
        Me.scrlMapTintData1.Name = "scrlMapTintData1"
        Me.scrlMapTintData1.Size = New System.Drawing.Size(143, 17)
        Me.scrlMapTintData1.TabIndex = 22
        '
        'btnCommand_Ok23
        '
        Me.btnCommand_Ok23.Location = New System.Drawing.Point(83, 114)
        Me.btnCommand_Ok23.Name = "btnCommand_Ok23"
        Me.btnCommand_Ok23.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok23.TabIndex = 20
        Me.btnCommand_Ok23.Text = "Ok"
        Me.btnCommand_Ok23.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel23
        '
        Me.btnCommand_Cancel23.Location = New System.Drawing.Point(164, 114)
        Me.btnCommand_Cancel23.Name = "btnCommand_Cancel23"
        Me.btnCommand_Cancel23.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel23.TabIndex = 19
        Me.btnCommand_Cancel23.Text = "Cancel"
        Me.btnCommand_Cancel23.UseVisualStyleBackColor = True
        '
        'lblMapTintData0
        '
        Me.lblMapTintData0.AutoSize = True
        Me.lblMapTintData0.Location = New System.Drawing.Point(6, 16)
        Me.lblMapTintData0.Name = "lblMapTintData0"
        Me.lblMapTintData0.Size = New System.Drawing.Size(39, 13)
        Me.lblMapTintData0.TabIndex = 13
        Me.lblMapTintData0.Text = "Red: 0"
        '
        'scrlMapTintData0
        '
        Me.scrlMapTintData0.Location = New System.Drawing.Point(96, 14)
        Me.scrlMapTintData0.Name = "scrlMapTintData0"
        Me.scrlMapTintData0.Size = New System.Drawing.Size(143, 17)
        Me.scrlMapTintData0.TabIndex = 12
        '
        'fraCommand22
        '
        Me.fraCommand22.Controls.Add(Me.ScrlFogData2)
        Me.fraCommand22.Controls.Add(Me.lblFogData2)
        Me.fraCommand22.Controls.Add(Me.lblFogData1)
        Me.fraCommand22.Controls.Add(Me.ScrlFogData1)
        Me.fraCommand22.Controls.Add(Me.btnCommand_Ok21)
        Me.fraCommand22.Controls.Add(Me.btnCommand_Cancel21)
        Me.fraCommand22.Controls.Add(Me.lblFogData0)
        Me.fraCommand22.Controls.Add(Me.ScrlFogData0)
        Me.fraCommand22.Location = New System.Drawing.Point(418, 187)
        Me.fraCommand22.Name = "fraCommand22"
        Me.fraCommand22.Size = New System.Drawing.Size(245, 114)
        Me.fraCommand22.TabIndex = 24
        Me.fraCommand22.TabStop = False
        Me.fraCommand22.Text = "Set Fog"
        Me.fraCommand22.Visible = False
        '
        'ScrlFogData2
        '
        Me.ScrlFogData2.Location = New System.Drawing.Point(96, 65)
        Me.ScrlFogData2.Name = "ScrlFogData2"
        Me.ScrlFogData2.Size = New System.Drawing.Size(143, 17)
        Me.ScrlFogData2.TabIndex = 25
        '
        'lblFogData2
        '
        Me.lblFogData2.AutoSize = True
        Me.lblFogData2.Location = New System.Drawing.Point(5, 68)
        Me.lblFogData2.Name = "lblFogData2"
        Me.lblFogData2.Size = New System.Drawing.Size(76, 13)
        Me.lblFogData2.TabIndex = 24
        Me.lblFogData2.Text = "Fog Opacity: 0"
        '
        'lblFogData1
        '
        Me.lblFogData1.AutoSize = True
        Me.lblFogData1.Location = New System.Drawing.Point(6, 42)
        Me.lblFogData1.Name = "lblFogData1"
        Me.lblFogData1.Size = New System.Drawing.Size(71, 13)
        Me.lblFogData1.TabIndex = 23
        Me.lblFogData1.Text = "Fog Speed: 0"
        '
        'ScrlFogData1
        '
        Me.ScrlFogData1.Location = New System.Drawing.Point(96, 39)
        Me.ScrlFogData1.Name = "ScrlFogData1"
        Me.ScrlFogData1.Size = New System.Drawing.Size(143, 17)
        Me.ScrlFogData1.TabIndex = 22
        '
        'btnCommand_Ok21
        '
        Me.btnCommand_Ok21.Location = New System.Drawing.Point(83, 85)
        Me.btnCommand_Ok21.Name = "btnCommand_Ok21"
        Me.btnCommand_Ok21.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok21.TabIndex = 20
        Me.btnCommand_Ok21.Text = "Ok"
        Me.btnCommand_Ok21.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel21
        '
        Me.btnCommand_Cancel21.Location = New System.Drawing.Point(164, 85)
        Me.btnCommand_Cancel21.Name = "btnCommand_Cancel21"
        Me.btnCommand_Cancel21.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel21.TabIndex = 19
        Me.btnCommand_Cancel21.Text = "Cancel"
        Me.btnCommand_Cancel21.UseVisualStyleBackColor = True
        '
        'lblFogData0
        '
        Me.lblFogData0.AutoSize = True
        Me.lblFogData0.Location = New System.Drawing.Point(6, 16)
        Me.lblFogData0.Name = "lblFogData0"
        Me.lblFogData0.Size = New System.Drawing.Size(57, 13)
        Me.lblFogData0.TabIndex = 13
        Me.lblFogData0.Text = "Fog: None"
        '
        'ScrlFogData0
        '
        Me.ScrlFogData0.Location = New System.Drawing.Point(96, 14)
        Me.ScrlFogData0.Name = "ScrlFogData0"
        Me.ScrlFogData0.Size = New System.Drawing.Size(143, 17)
        Me.ScrlFogData0.TabIndex = 12
        '
        'fraCommand26
        '
        Me.fraCommand26.Controls.Add(Me.btnCommand_Ok25)
        Me.fraCommand26.Controls.Add(Me.btnCommand_Cancel25)
        Me.fraCommand26.Controls.Add(Me.cmbPlaySound)
        Me.fraCommand26.Location = New System.Drawing.Point(433, 12)
        Me.fraCommand26.Name = "fraCommand26"
        Me.fraCommand26.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand26.TabIndex = 22
        Me.fraCommand26.TabStop = False
        Me.fraCommand26.Text = "Play Sound"
        Me.fraCommand26.Visible = False
        '
        'btnCommand_Ok25
        '
        Me.btnCommand_Ok25.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok25.Name = "btnCommand_Ok25"
        Me.btnCommand_Ok25.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok25.TabIndex = 26
        Me.btnCommand_Ok25.Text = "Ok"
        Me.btnCommand_Ok25.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel25
        '
        Me.btnCommand_Cancel25.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel25.Name = "btnCommand_Cancel25"
        Me.btnCommand_Cancel25.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel25.TabIndex = 25
        Me.btnCommand_Cancel25.Text = "Cancel"
        Me.btnCommand_Cancel25.UseVisualStyleBackColor = True
        '
        'cmbPlaySound
        '
        Me.cmbPlaySound.FormattingEnabled = True
        Me.cmbPlaySound.Location = New System.Drawing.Point(42, 13)
        Me.cmbPlaySound.Name = "cmbPlaySound"
        Me.cmbPlaySound.Size = New System.Drawing.Size(171, 21)
        Me.cmbPlaySound.TabIndex = 2
        '
        'fraCommand21
        '
        Me.fraCommand21.Controls.Add(Me.btnCommand_Ok20)
        Me.fraCommand21.Controls.Add(Me.btnCommand_Cancel20)
        Me.fraCommand21.Controls.Add(Me.cmbOpenShop)
        Me.fraCommand21.Location = New System.Drawing.Point(433, 92)
        Me.fraCommand21.Name = "fraCommand21"
        Me.fraCommand21.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand21.TabIndex = 21
        Me.fraCommand21.TabStop = False
        Me.fraCommand21.Text = "Open Shop"
        Me.fraCommand21.Visible = False
        '
        'btnCommand_Ok20
        '
        Me.btnCommand_Ok20.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok20.Name = "btnCommand_Ok20"
        Me.btnCommand_Ok20.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok20.TabIndex = 26
        Me.btnCommand_Ok20.Text = "Ok"
        Me.btnCommand_Ok20.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel20
        '
        Me.btnCommand_Cancel20.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel20.Name = "btnCommand_Cancel20"
        Me.btnCommand_Cancel20.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel20.TabIndex = 25
        Me.btnCommand_Cancel20.Text = "Cancel"
        Me.btnCommand_Cancel20.UseVisualStyleBackColor = True
        '
        'cmbOpenShop
        '
        Me.cmbOpenShop.FormattingEnabled = True
        Me.cmbOpenShop.Location = New System.Drawing.Point(42, 13)
        Me.cmbOpenShop.Name = "cmbOpenShop"
        Me.cmbOpenShop.Size = New System.Drawing.Size(171, 21)
        Me.cmbOpenShop.TabIndex = 2
        '
        'fraCommand19
        '
        Me.fraCommand19.Controls.Add(Me.btnCommand_Ok18)
        Me.fraCommand19.Controls.Add(Me.btnCommand_Cancel18)
        Me.fraCommand19.Controls.Add(Me.cmbSpawnNPC)
        Me.fraCommand19.Controls.Add(Me.lblRandomLabel42)
        Me.fraCommand19.Location = New System.Drawing.Point(432, 11)
        Me.fraCommand19.Name = "fraCommand19"
        Me.fraCommand19.Size = New System.Drawing.Size(219, 72)
        Me.fraCommand19.TabIndex = 20
        Me.fraCommand19.TabStop = False
        Me.fraCommand19.Text = "Spawn NPC"
        Me.fraCommand19.Visible = False
        '
        'btnCommand_Ok18
        '
        Me.btnCommand_Ok18.Location = New System.Drawing.Point(57, 40)
        Me.btnCommand_Ok18.Name = "btnCommand_Ok18"
        Me.btnCommand_Ok18.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok18.TabIndex = 26
        Me.btnCommand_Ok18.Text = "Ok"
        Me.btnCommand_Ok18.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel18
        '
        Me.btnCommand_Cancel18.Location = New System.Drawing.Point(138, 40)
        Me.btnCommand_Cancel18.Name = "btnCommand_Cancel18"
        Me.btnCommand_Cancel18.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel18.TabIndex = 25
        Me.btnCommand_Cancel18.Text = "Cancel"
        Me.btnCommand_Cancel18.UseVisualStyleBackColor = True
        '
        'cmbSpawnNPC
        '
        Me.cmbSpawnNPC.FormattingEnabled = True
        Me.cmbSpawnNPC.Location = New System.Drawing.Point(42, 13)
        Me.cmbSpawnNPC.Name = "cmbSpawnNPC"
        Me.cmbSpawnNPC.Size = New System.Drawing.Size(171, 21)
        Me.cmbSpawnNPC.TabIndex = 2
        '
        'lblRandomLabel42
        '
        Me.lblRandomLabel42.AutoSize = True
        Me.lblRandomLabel42.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel42.Name = "lblRandomLabel42"
        Me.lblRandomLabel42.Size = New System.Drawing.Size(30, 13)
        Me.lblRandomLabel42.TabIndex = 0
        Me.lblRandomLabel42.Text = "Npc:"
        '
        'fraCommand3
        '
        Me.fraCommand3.Controls.Add(Me.btnCommand_Ok3)
        Me.fraCommand3.Controls.Add(Me.btnCommand_Cancel3)
        Me.fraCommand3.Controls.Add(Me.cmbChatBubbleTarget)
        Me.fraCommand3.Controls.Add(Me.optChatBubbleTarget2)
        Me.fraCommand3.Controls.Add(Me.optChatBubbleTarget1)
        Me.fraCommand3.Controls.Add(Me.optChatBubbleTarget0)
        Me.fraCommand3.Controls.Add(Me.lblRandomLabel39)
        Me.fraCommand3.Controls.Add(Me.txtChatbubbleText)
        Me.fraCommand3.Controls.Add(Me.lblRandomLabel38)
        Me.fraCommand3.Location = New System.Drawing.Point(432, 12)
        Me.fraCommand3.Name = "fraCommand3"
        Me.fraCommand3.Size = New System.Drawing.Size(219, 153)
        Me.fraCommand3.TabIndex = 19
        Me.fraCommand3.TabStop = False
        Me.fraCommand3.Text = "Show Chatbubble"
        Me.fraCommand3.Visible = False
        '
        'btnCommand_Ok3
        '
        Me.btnCommand_Ok3.Location = New System.Drawing.Point(57, 122)
        Me.btnCommand_Ok3.Name = "btnCommand_Ok3"
        Me.btnCommand_Ok3.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok3.TabIndex = 24
        Me.btnCommand_Ok3.Text = "Ok"
        Me.btnCommand_Ok3.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel3
        '
        Me.btnCommand_Cancel3.Location = New System.Drawing.Point(138, 122)
        Me.btnCommand_Cancel3.Name = "btnCommand_Cancel3"
        Me.btnCommand_Cancel3.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel3.TabIndex = 23
        Me.btnCommand_Cancel3.Text = "Cancel"
        Me.btnCommand_Cancel3.UseVisualStyleBackColor = True
        '
        'cmbChatBubbleTarget
        '
        Me.cmbChatBubbleTarget.FormattingEnabled = True
        Me.cmbChatBubbleTarget.Location = New System.Drawing.Point(37, 95)
        Me.cmbChatBubbleTarget.Name = "cmbChatBubbleTarget"
        Me.cmbChatBubbleTarget.Size = New System.Drawing.Size(176, 21)
        Me.cmbChatBubbleTarget.TabIndex = 22
        '
        'optChatBubbleTarget2
        '
        Me.optChatBubbleTarget2.AutoSize = True
        Me.optChatBubbleTarget2.Location = New System.Drawing.Point(125, 71)
        Me.optChatBubbleTarget2.Name = "optChatBubbleTarget2"
        Me.optChatBubbleTarget2.Size = New System.Drawing.Size(53, 17)
        Me.optChatBubbleTarget2.TabIndex = 21
        Me.optChatBubbleTarget2.TabStop = True
        Me.optChatBubbleTarget2.Text = "Event"
        Me.optChatBubbleTarget2.UseVisualStyleBackColor = True
        '
        'optChatBubbleTarget1
        '
        Me.optChatBubbleTarget1.AutoSize = True
        Me.optChatBubbleTarget1.Location = New System.Drawing.Point(68, 71)
        Me.optChatBubbleTarget1.Name = "optChatBubbleTarget1"
        Me.optChatBubbleTarget1.Size = New System.Drawing.Size(45, 17)
        Me.optChatBubbleTarget1.TabIndex = 20
        Me.optChatBubbleTarget1.TabStop = True
        Me.optChatBubbleTarget1.Text = "Npc"
        Me.optChatBubbleTarget1.UseVisualStyleBackColor = True
        '
        'optChatBubbleTarget0
        '
        Me.optChatBubbleTarget0.AutoSize = True
        Me.optChatBubbleTarget0.Location = New System.Drawing.Point(6, 71)
        Me.optChatBubbleTarget0.Name = "optChatBubbleTarget0"
        Me.optChatBubbleTarget0.Size = New System.Drawing.Size(54, 17)
        Me.optChatBubbleTarget0.TabIndex = 19
        Me.optChatBubbleTarget0.TabStop = True
        Me.optChatBubbleTarget0.Text = "Player"
        Me.optChatBubbleTarget0.UseVisualStyleBackColor = True
        '
        'lblRandomLabel39
        '
        Me.lblRandomLabel39.AutoSize = True
        Me.lblRandomLabel39.Location = New System.Drawing.Point(3, 55)
        Me.lblRandomLabel39.Name = "lblRandomLabel39"
        Me.lblRandomLabel39.Size = New System.Drawing.Size(68, 13)
        Me.lblRandomLabel39.TabIndex = 18
        Me.lblRandomLabel39.Text = "Target Type:"
        '
        'txtChatbubbleText
        '
        Me.txtChatbubbleText.Location = New System.Drawing.Point(6, 32)
        Me.txtChatbubbleText.Name = "txtChatbubbleText"
        Me.txtChatbubbleText.Size = New System.Drawing.Size(207, 20)
        Me.txtChatbubbleText.TabIndex = 1
        '
        'lblRandomLabel38
        '
        Me.lblRandomLabel38.AutoSize = True
        Me.lblRandomLabel38.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel38.Name = "lblRandomLabel38"
        Me.lblRandomLabel38.Size = New System.Drawing.Size(88, 13)
        Me.lblRandomLabel38.TabIndex = 0
        Me.lblRandomLabel38.Text = "Chatbubble Text:"
        '
        'fraCommand2
        '
        Me.fraCommand2.Controls.Add(Me.btnCommand_Ok2)
        Me.fraCommand2.Controls.Add(Me.btnCommand_Cancel2)
        Me.fraCommand2.Controls.Add(Me.optAddText_Global)
        Me.fraCommand2.Controls.Add(Me.optAddText_Map)
        Me.fraCommand2.Controls.Add(Me.optAddText_Player)
        Me.fraCommand2.Controls.Add(Me.lblRandomLabel10)
        Me.fraCommand2.Controls.Add(Me.lblAddText_Colour)
        Me.fraCommand2.Controls.Add(Me.scrlAddText_Colour)
        Me.fraCommand2.Controls.Add(Me.txtAddText_Text)
        Me.fraCommand2.Controls.Add(Me.lblRandomLabel34)
        Me.fraCommand2.Location = New System.Drawing.Point(418, 44)
        Me.fraCommand2.Name = "fraCommand2"
        Me.fraCommand2.Size = New System.Drawing.Size(245, 254)
        Me.fraCommand2.TabIndex = 18
        Me.fraCommand2.TabStop = False
        Me.fraCommand2.Text = "Add Text"
        Me.fraCommand2.Visible = False
        '
        'btnCommand_Ok2
        '
        Me.btnCommand_Ok2.Location = New System.Drawing.Point(83, 225)
        Me.btnCommand_Ok2.Name = "btnCommand_Ok2"
        Me.btnCommand_Ok2.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok2.TabIndex = 20
        Me.btnCommand_Ok2.Text = "Ok"
        Me.btnCommand_Ok2.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel2
        '
        Me.btnCommand_Cancel2.Location = New System.Drawing.Point(164, 225)
        Me.btnCommand_Cancel2.Name = "btnCommand_Cancel2"
        Me.btnCommand_Cancel2.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel2.TabIndex = 19
        Me.btnCommand_Cancel2.Text = "Cancel"
        Me.btnCommand_Cancel2.UseVisualStyleBackColor = True
        '
        'optAddText_Global
        '
        Me.optAddText_Global.AutoSize = True
        Me.optAddText_Global.Location = New System.Drawing.Point(125, 205)
        Me.optAddText_Global.Name = "optAddText_Global"
        Me.optAddText_Global.Size = New System.Drawing.Size(55, 17)
        Me.optAddText_Global.TabIndex = 17
        Me.optAddText_Global.TabStop = True
        Me.optAddText_Global.Text = "Global"
        Me.optAddText_Global.UseVisualStyleBackColor = True
        '
        'optAddText_Map
        '
        Me.optAddText_Map.AutoSize = True
        Me.optAddText_Map.Location = New System.Drawing.Point(68, 205)
        Me.optAddText_Map.Name = "optAddText_Map"
        Me.optAddText_Map.Size = New System.Drawing.Size(46, 17)
        Me.optAddText_Map.TabIndex = 16
        Me.optAddText_Map.TabStop = True
        Me.optAddText_Map.Text = "Map"
        Me.optAddText_Map.UseVisualStyleBackColor = True
        '
        'optAddText_Player
        '
        Me.optAddText_Player.AutoSize = True
        Me.optAddText_Player.Location = New System.Drawing.Point(6, 205)
        Me.optAddText_Player.Name = "optAddText_Player"
        Me.optAddText_Player.Size = New System.Drawing.Size(54, 17)
        Me.optAddText_Player.TabIndex = 15
        Me.optAddText_Player.TabStop = True
        Me.optAddText_Player.Text = "Player"
        Me.optAddText_Player.UseVisualStyleBackColor = True
        '
        'lblRandomLabel10
        '
        Me.lblRandomLabel10.AutoSize = True
        Me.lblRandomLabel10.Location = New System.Drawing.Point(3, 189)
        Me.lblRandomLabel10.Name = "lblRandomLabel10"
        Me.lblRandomLabel10.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel10.TabIndex = 14
        Me.lblRandomLabel10.Text = "Channel:"
        '
        'lblAddText_Colour
        '
        Me.lblAddText_Colour.AutoSize = True
        Me.lblAddText_Colour.Location = New System.Drawing.Point(6, 153)
        Me.lblAddText_Colour.Name = "lblAddText_Colour"
        Me.lblAddText_Colour.Size = New System.Drawing.Size(64, 13)
        Me.lblAddText_Colour.TabIndex = 13
        Me.lblAddText_Colour.Text = "Color: Black"
        '
        'scrlAddText_Colour
        '
        Me.scrlAddText_Colour.Location = New System.Drawing.Point(4, 169)
        Me.scrlAddText_Colour.Name = "scrlAddText_Colour"
        Me.scrlAddText_Colour.Size = New System.Drawing.Size(235, 17)
        Me.scrlAddText_Colour.TabIndex = 12
        '
        'txtAddText_Text
        '
        Me.txtAddText_Text.Location = New System.Drawing.Point(6, 32)
        Me.txtAddText_Text.Multiline = True
        Me.txtAddText_Text.Name = "txtAddText_Text"
        Me.txtAddText_Text.Size = New System.Drawing.Size(233, 118)
        Me.txtAddText_Text.TabIndex = 1
        '
        'lblRandomLabel34
        '
        Me.lblRandomLabel34.AutoSize = True
        Me.lblRandomLabel34.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel34.Name = "lblRandomLabel34"
        Me.lblRandomLabel34.Size = New System.Drawing.Size(31, 13)
        Me.lblRandomLabel34.TabIndex = 0
        Me.lblRandomLabel34.Text = "Text:"
        '
        'fraCommand33
        '
        Me.fraCommand33.Controls.Add(Me.txtPicOffset2)
        Me.fraCommand33.Controls.Add(Me.txtPicOffset1)
        Me.fraCommand33.Controls.Add(Me.lblRandomLabel57)
        Me.fraCommand33.Controls.Add(Me.lblRandomLabel56)
        Me.fraCommand33.Controls.Add(Me.lblRandomLabel55)
        Me.fraCommand33.Controls.Add(Me.optPic3)
        Me.fraCommand33.Controls.Add(Me.optPic2)
        Me.fraCommand33.Controls.Add(Me.optPic1)
        Me.fraCommand33.Controls.Add(Me.lblRandomLabel54)
        Me.fraCommand33.Controls.Add(Me.lblRandomLabel53)
        Me.fraCommand33.Controls.Add(Me.btnCommand_Ok33)
        Me.fraCommand33.Controls.Add(Me.btnCommand_Cancel33)
        Me.fraCommand33.Controls.Add(Me.scrlShowPicture)
        Me.fraCommand33.Controls.Add(Me.lblShowPic)
        Me.fraCommand33.Controls.Add(Me.PictureBox1)
        Me.fraCommand33.Controls.Add(Me.cmbPicIndex)
        Me.fraCommand33.Controls.Add(Me.lblRandomLabel52)
        Me.fraCommand33.Location = New System.Drawing.Point(418, 31)
        Me.fraCommand33.Name = "fraCommand33"
        Me.fraCommand33.Size = New System.Drawing.Size(245, 328)
        Me.fraCommand33.TabIndex = 17
        Me.fraCommand33.TabStop = False
        Me.fraCommand33.Text = "Show Picture"
        Me.fraCommand33.Visible = False
        '
        'txtPicOffset2
        '
        Me.txtPicOffset2.Location = New System.Drawing.Point(142, 275)
        Me.txtPicOffset2.Name = "txtPicOffset2"
        Me.txtPicOffset2.Size = New System.Drawing.Size(100, 20)
        Me.txtPicOffset2.TabIndex = 34
        '
        'txtPicOffset1
        '
        Me.txtPicOffset1.Location = New System.Drawing.Point(21, 275)
        Me.txtPicOffset1.Name = "txtPicOffset1"
        Me.txtPicOffset1.Size = New System.Drawing.Size(100, 20)
        Me.txtPicOffset1.TabIndex = 33
        '
        'lblRandomLabel57
        '
        Me.lblRandomLabel57.AutoSize = True
        Me.lblRandomLabel57.Location = New System.Drawing.Point(127, 278)
        Me.lblRandomLabel57.Name = "lblRandomLabel57"
        Me.lblRandomLabel57.Size = New System.Drawing.Size(17, 13)
        Me.lblRandomLabel57.TabIndex = 32
        Me.lblRandomLabel57.Text = "Y:"
        '
        'lblRandomLabel56
        '
        Me.lblRandomLabel56.AutoSize = True
        Me.lblRandomLabel56.Location = New System.Drawing.Point(6, 278)
        Me.lblRandomLabel56.Name = "lblRandomLabel56"
        Me.lblRandomLabel56.Size = New System.Drawing.Size(17, 13)
        Me.lblRandomLabel56.TabIndex = 32
        Me.lblRandomLabel56.Text = "X:"
        '
        'lblRandomLabel55
        '
        Me.lblRandomLabel55.AutoSize = True
        Me.lblRandomLabel55.Location = New System.Drawing.Point(4, 252)
        Me.lblRandomLabel55.Name = "lblRandomLabel55"
        Me.lblRandomLabel55.Size = New System.Drawing.Size(105, 13)
        Me.lblRandomLabel55.TabIndex = 31
        Me.lblRandomLabel55.Text = "Offset from Location:"
        '
        'optPic3
        '
        Me.optPic3.AutoSize = True
        Me.optPic3.Location = New System.Drawing.Point(7, 224)
        Me.optPic3.Name = "optPic3"
        Me.optPic3.Size = New System.Drawing.Size(115, 17)
        Me.optPic3.TabIndex = 30
        Me.optPic3.TabStop = True
        Me.optPic3.Text = "Centered on Player"
        Me.optPic3.UseVisualStyleBackColor = True
        '
        'optPic2
        '
        Me.optPic2.AutoSize = True
        Me.optPic2.Location = New System.Drawing.Point(127, 203)
        Me.optPic2.Name = "optPic2"
        Me.optPic2.Size = New System.Drawing.Size(93, 17)
        Me.optPic2.TabIndex = 29
        Me.optPic2.TabStop = True
        Me.optPic2.Text = "Center Screen"
        Me.optPic2.UseVisualStyleBackColor = True
        '
        'optPic1
        '
        Me.optPic1.AutoSize = True
        Me.optPic1.Location = New System.Drawing.Point(7, 202)
        Me.optPic1.Name = "optPic1"
        Me.optPic1.Size = New System.Drawing.Size(114, 17)
        Me.optPic1.TabIndex = 28
        Me.optPic1.TabStop = True
        Me.optPic1.Text = "Top Left of Screen"
        Me.optPic1.UseVisualStyleBackColor = True
        '
        'lblRandomLabel54
        '
        Me.lblRandomLabel54.AutoSize = True
        Me.lblRandomLabel54.Location = New System.Drawing.Point(6, 183)
        Me.lblRandomLabel54.Name = "lblRandomLabel54"
        Me.lblRandomLabel54.Size = New System.Drawing.Size(51, 13)
        Me.lblRandomLabel54.TabIndex = 27
        Me.lblRandomLabel54.Text = "Location:"
        '
        'lblRandomLabel53
        '
        Me.lblRandomLabel53.AutoSize = True
        Me.lblRandomLabel53.Location = New System.Drawing.Point(6, 54)
        Me.lblRandomLabel53.Name = "lblRandomLabel53"
        Me.lblRandomLabel53.Size = New System.Drawing.Size(43, 13)
        Me.lblRandomLabel53.TabIndex = 26
        Me.lblRandomLabel53.Text = "Picture:"
        '
        'btnCommand_Ok33
        '
        Me.btnCommand_Ok33.Location = New System.Drawing.Point(83, 301)
        Me.btnCommand_Ok33.Name = "btnCommand_Ok33"
        Me.btnCommand_Ok33.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok33.TabIndex = 25
        Me.btnCommand_Ok33.Text = "Ok"
        Me.btnCommand_Ok33.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel33
        '
        Me.btnCommand_Cancel33.Location = New System.Drawing.Point(164, 301)
        Me.btnCommand_Cancel33.Name = "btnCommand_Cancel33"
        Me.btnCommand_Cancel33.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel33.TabIndex = 24
        Me.btnCommand_Cancel33.Text = "Cancel"
        Me.btnCommand_Cancel33.UseVisualStyleBackColor = True
        '
        'scrlShowPicture
        '
        Me.scrlShowPicture.Location = New System.Drawing.Point(112, 149)
        Me.scrlShowPicture.Name = "scrlShowPicture"
        Me.scrlShowPicture.Size = New System.Drawing.Size(130, 17)
        Me.scrlShowPicture.TabIndex = 23
        '
        'lblShowPic
        '
        Me.lblShowPic.AutoSize = True
        Me.lblShowPic.Location = New System.Drawing.Point(115, 132)
        Me.lblShowPic.Name = "lblShowPic"
        Me.lblShowPic.Size = New System.Drawing.Size(52, 13)
        Me.lblShowPic.TabIndex = 22
        Me.lblShowPic.Text = "Picture: 1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(9, 73)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 93)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'cmbPicIndex
        '
        Me.cmbPicIndex.FormattingEnabled = True
        Me.cmbPicIndex.Location = New System.Drawing.Point(83, 13)
        Me.cmbPicIndex.Name = "cmbPicIndex"
        Me.cmbPicIndex.Size = New System.Drawing.Size(154, 21)
        Me.cmbPicIndex.TabIndex = 2
        '
        'lblRandomLabel52
        '
        Me.lblRandomLabel52.AutoSize = True
        Me.lblRandomLabel52.Location = New System.Drawing.Point(3, 17)
        Me.lblRandomLabel52.Name = "lblRandomLabel52"
        Me.lblRandomLabel52.Size = New System.Drawing.Size(72, 13)
        Me.lblRandomLabel52.TabIndex = 0
        Me.lblRandomLabel52.Text = "Picture Index:"
        '
        'fraCommand1
        '
        Me.fraCommand1.Controls.Add(Me.txtChoices4)
        Me.fraCommand1.Controls.Add(Me.txtChoices3)
        Me.fraCommand1.Controls.Add(Me.lblRandomLabel21)
        Me.fraCommand1.Controls.Add(Me.lblRandomLabel20)
        Me.fraCommand1.Controls.Add(Me.txtChoices2)
        Me.fraCommand1.Controls.Add(Me.txtChoices1)
        Me.fraCommand1.Controls.Add(Me.lblRandomLabel19)
        Me.fraCommand1.Controls.Add(Me.lblRandomLabel17)
        Me.fraCommand1.Controls.Add(Me.btnCommand_Ok1)
        Me.fraCommand1.Controls.Add(Me.btnCommand_Cancel1)
        Me.fraCommand1.Controls.Add(Me.scrlShowChoicesFace)
        Me.fraCommand1.Controls.Add(Me.lblShowChoicesFace)
        Me.fraCommand1.Controls.Add(Me.picShowChoicesFace)
        Me.fraCommand1.Controls.Add(Me.txtChoicePrompt)
        Me.fraCommand1.Controls.Add(Me.lblRandomLabel16)
        Me.fraCommand1.Location = New System.Drawing.Point(418, 16)
        Me.fraCommand1.Name = "fraCommand1"
        Me.fraCommand1.Size = New System.Drawing.Size(245, 357)
        Me.fraCommand1.TabIndex = 16
        Me.fraCommand1.TabStop = False
        Me.fraCommand1.Text = "Show Choices"
        Me.fraCommand1.Visible = False
        '
        'txtChoices4
        '
        Me.txtChoices4.Location = New System.Drawing.Point(139, 202)
        Me.txtChoices4.Name = "txtChoices4"
        Me.txtChoices4.Size = New System.Drawing.Size(100, 20)
        Me.txtChoices4.TabIndex = 27
        '
        'txtChoices3
        '
        Me.txtChoices3.Location = New System.Drawing.Point(6, 201)
        Me.txtChoices3.Name = "txtChoices3"
        Me.txtChoices3.Size = New System.Drawing.Size(100, 20)
        Me.txtChoices3.TabIndex = 26
        '
        'lblRandomLabel21
        '
        Me.lblRandomLabel21.AutoSize = True
        Me.lblRandomLabel21.Location = New System.Drawing.Point(138, 186)
        Me.lblRandomLabel21.Name = "lblRandomLabel21"
        Me.lblRandomLabel21.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel21.TabIndex = 24
        Me.lblRandomLabel21.Text = "Choice 4"
        '
        'lblRandomLabel20
        '
        Me.lblRandomLabel20.AutoSize = True
        Me.lblRandomLabel20.Location = New System.Drawing.Point(6, 185)
        Me.lblRandomLabel20.Name = "lblRandomLabel20"
        Me.lblRandomLabel20.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel20.TabIndex = 25
        Me.lblRandomLabel20.Text = "Choice 3"
        '
        'txtChoices2
        '
        Me.txtChoices2.Location = New System.Drawing.Point(139, 163)
        Me.txtChoices2.Name = "txtChoices2"
        Me.txtChoices2.Size = New System.Drawing.Size(100, 20)
        Me.txtChoices2.TabIndex = 23
        '
        'txtChoices1
        '
        Me.txtChoices1.Location = New System.Drawing.Point(6, 162)
        Me.txtChoices1.Name = "txtChoices1"
        Me.txtChoices1.Size = New System.Drawing.Size(100, 20)
        Me.txtChoices1.TabIndex = 22
        '
        'lblRandomLabel19
        '
        Me.lblRandomLabel19.AutoSize = True
        Me.lblRandomLabel19.Location = New System.Drawing.Point(138, 147)
        Me.lblRandomLabel19.Name = "lblRandomLabel19"
        Me.lblRandomLabel19.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel19.TabIndex = 21
        Me.lblRandomLabel19.Text = "Choice 2"
        '
        'lblRandomLabel17
        '
        Me.lblRandomLabel17.AutoSize = True
        Me.lblRandomLabel17.Location = New System.Drawing.Point(6, 146)
        Me.lblRandomLabel17.Name = "lblRandomLabel17"
        Me.lblRandomLabel17.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel17.TabIndex = 21
        Me.lblRandomLabel17.Text = "Choice 1"
        '
        'btnCommand_Ok1
        '
        Me.btnCommand_Ok1.Location = New System.Drawing.Point(83, 328)
        Me.btnCommand_Ok1.Name = "btnCommand_Ok1"
        Me.btnCommand_Ok1.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok1.TabIndex = 20
        Me.btnCommand_Ok1.Text = "Ok"
        Me.btnCommand_Ok1.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel1
        '
        Me.btnCommand_Cancel1.Location = New System.Drawing.Point(164, 328)
        Me.btnCommand_Cancel1.Name = "btnCommand_Cancel1"
        Me.btnCommand_Cancel1.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel1.TabIndex = 19
        Me.btnCommand_Cancel1.Text = "Cancel"
        Me.btnCommand_Cancel1.UseVisualStyleBackColor = True
        '
        'scrlShowChoicesFace
        '
        Me.scrlShowChoicesFace.Location = New System.Drawing.Point(109, 299)
        Me.scrlShowChoicesFace.Name = "scrlShowChoicesFace"
        Me.scrlShowChoicesFace.Size = New System.Drawing.Size(130, 17)
        Me.scrlShowChoicesFace.TabIndex = 12
        '
        'lblShowChoicesFace
        '
        Me.lblShowChoicesFace.AutoSize = True
        Me.lblShowChoicesFace.Location = New System.Drawing.Point(112, 280)
        Me.lblShowChoicesFace.Name = "lblShowChoicesFace"
        Me.lblShowChoicesFace.Size = New System.Drawing.Size(63, 13)
        Me.lblShowChoicesFace.TabIndex = 3
        Me.lblShowChoicesFace.Text = "Face: None"
        '
        'picShowChoicesFace
        '
        Me.picShowChoicesFace.BackColor = System.Drawing.Color.Black
        Me.picShowChoicesFace.Location = New System.Drawing.Point(6, 227)
        Me.picShowChoicesFace.Name = "picShowChoicesFace"
        Me.picShowChoicesFace.Size = New System.Drawing.Size(100, 93)
        Me.picShowChoicesFace.TabIndex = 2
        Me.picShowChoicesFace.TabStop = False
        '
        'txtChoicePrompt
        '
        Me.txtChoicePrompt.Location = New System.Drawing.Point(6, 31)
        Me.txtChoicePrompt.Multiline = True
        Me.txtChoicePrompt.Name = "txtChoicePrompt"
        Me.txtChoicePrompt.Size = New System.Drawing.Size(231, 112)
        Me.txtChoicePrompt.TabIndex = 1
        '
        'lblRandomLabel16
        '
        Me.lblRandomLabel16.AutoSize = True
        Me.lblRandomLabel16.Location = New System.Drawing.Point(7, 15)
        Me.lblRandomLabel16.Name = "lblRandomLabel16"
        Me.lblRandomLabel16.Size = New System.Drawing.Size(43, 13)
        Me.lblRandomLabel16.TabIndex = 0
        Me.lblRandomLabel16.Text = "Prompt:"
        '
        'fraCommand0
        '
        Me.fraCommand0.Controls.Add(Me.btnCommand_Ok0)
        Me.fraCommand0.Controls.Add(Me.btnCommand_Cancel0)
        Me.fraCommand0.Controls.Add(Me.scrlShowTextFace)
        Me.fraCommand0.Controls.Add(Me.lblShowTextFace)
        Me.fraCommand0.Controls.Add(Me.picShowTextFace)
        Me.fraCommand0.Controls.Add(Me.txtShowText)
        Me.fraCommand0.Controls.Add(Me.lblRandomLabel18)
        Me.fraCommand0.Location = New System.Drawing.Point(418, 16)
        Me.fraCommand0.Name = "fraCommand0"
        Me.fraCommand0.Size = New System.Drawing.Size(245, 319)
        Me.fraCommand0.TabIndex = 15
        Me.fraCommand0.TabStop = False
        Me.fraCommand0.Text = "Show Text"
        Me.fraCommand0.Visible = False
        '
        'btnCommand_Ok0
        '
        Me.btnCommand_Ok0.Location = New System.Drawing.Point(83, 293)
        Me.btnCommand_Ok0.Name = "btnCommand_Ok0"
        Me.btnCommand_Ok0.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok0.TabIndex = 20
        Me.btnCommand_Ok0.Text = "Ok"
        Me.btnCommand_Ok0.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel0
        '
        Me.btnCommand_Cancel0.Location = New System.Drawing.Point(164, 293)
        Me.btnCommand_Cancel0.Name = "btnCommand_Cancel0"
        Me.btnCommand_Cancel0.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel0.TabIndex = 19
        Me.btnCommand_Cancel0.Text = "Cancel"
        Me.btnCommand_Cancel0.UseVisualStyleBackColor = True
        '
        'scrlShowTextFace
        '
        Me.scrlShowTextFace.Location = New System.Drawing.Point(109, 264)
        Me.scrlShowTextFace.Name = "scrlShowTextFace"
        Me.scrlShowTextFace.Size = New System.Drawing.Size(130, 17)
        Me.scrlShowTextFace.TabIndex = 12
        '
        'lblShowTextFace
        '
        Me.lblShowTextFace.AutoSize = True
        Me.lblShowTextFace.Location = New System.Drawing.Point(112, 245)
        Me.lblShowTextFace.Name = "lblShowTextFace"
        Me.lblShowTextFace.Size = New System.Drawing.Size(63, 13)
        Me.lblShowTextFace.TabIndex = 3
        Me.lblShowTextFace.Text = "Face: None"
        '
        'picShowTextFace
        '
        Me.picShowTextFace.BackColor = System.Drawing.Color.Black
        Me.picShowTextFace.Location = New System.Drawing.Point(6, 192)
        Me.picShowTextFace.Name = "picShowTextFace"
        Me.picShowTextFace.Size = New System.Drawing.Size(100, 93)
        Me.picShowTextFace.TabIndex = 2
        Me.picShowTextFace.TabStop = False
        '
        'txtShowText
        '
        Me.txtShowText.Location = New System.Drawing.Point(6, 31)
        Me.txtShowText.Multiline = True
        Me.txtShowText.Name = "txtShowText"
        Me.txtShowText.Size = New System.Drawing.Size(231, 155)
        Me.txtShowText.TabIndex = 1
        '
        'lblRandomLabel18
        '
        Me.lblRandomLabel18.AutoSize = True
        Me.lblRandomLabel18.Location = New System.Drawing.Point(7, 15)
        Me.lblRandomLabel18.Name = "lblRandomLabel18"
        Me.lblRandomLabel18.Size = New System.Drawing.Size(31, 13)
        Me.lblRandomLabel18.TabIndex = 0
        Me.lblRandomLabel18.Text = "Text:"
        '
        'fraCommand17
        '
        Me.fraCommand17.Controls.Add(Me.btnCommand_Ok16)
        Me.fraCommand17.Controls.Add(Me.btnCommand_Cancel16)
        Me.fraCommand17.Controls.Add(Me.lblGiveExp)
        Me.fraCommand17.Controls.Add(Me.scrlGiveExp)
        Me.fraCommand17.Location = New System.Drawing.Point(432, 50)
        Me.fraCommand17.Name = "fraCommand17"
        Me.fraCommand17.Size = New System.Drawing.Size(219, 91)
        Me.fraCommand17.TabIndex = 14
        Me.fraCommand17.TabStop = False
        Me.fraCommand17.Text = "Give Experience"
        Me.fraCommand17.Visible = False
        '
        'btnCommand_Ok16
        '
        Me.btnCommand_Ok16.Location = New System.Drawing.Point(57, 62)
        Me.btnCommand_Ok16.Name = "btnCommand_Ok16"
        Me.btnCommand_Ok16.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok16.TabIndex = 18
        Me.btnCommand_Ok16.Text = "Ok"
        Me.btnCommand_Ok16.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel16
        '
        Me.btnCommand_Cancel16.Location = New System.Drawing.Point(138, 62)
        Me.btnCommand_Cancel16.Name = "btnCommand_Cancel16"
        Me.btnCommand_Cancel16.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel16.TabIndex = 17
        Me.btnCommand_Cancel16.Text = "Cancel"
        Me.btnCommand_Cancel16.UseVisualStyleBackColor = True
        '
        'lblGiveExp
        '
        Me.lblGiveExp.AutoSize = True
        Me.lblGiveExp.Location = New System.Drawing.Point(6, 17)
        Me.lblGiveExp.Name = "lblGiveExp"
        Me.lblGiveExp.Size = New System.Drawing.Size(62, 13)
        Me.lblGiveExp.TabIndex = 13
        Me.lblGiveExp.Text = "Give Exp: 0"
        '
        'scrlGiveExp
        '
        Me.scrlGiveExp.Location = New System.Drawing.Point(3, 42)
        Me.scrlGiveExp.Name = "scrlGiveExp"
        Me.scrlGiveExp.Size = New System.Drawing.Size(213, 17)
        Me.scrlGiveExp.TabIndex = 12
        '
        'fraCommand16
        '
        Me.fraCommand16.Controls.Add(Me.btnCommand_Ok15)
        Me.fraCommand16.Controls.Add(Me.btnCommand_Cancel15)
        Me.fraCommand16.Controls.Add(Me.optChangePKNo)
        Me.fraCommand16.Controls.Add(Me.optChangePKYes)
        Me.fraCommand16.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand16.Name = "fraCommand16"
        Me.fraCommand16.Size = New System.Drawing.Size(219, 71)
        Me.fraCommand16.TabIndex = 13
        Me.fraCommand16.TabStop = False
        Me.fraCommand16.Text = "Set Player PK"
        Me.fraCommand16.Visible = False
        '
        'btnCommand_Ok15
        '
        Me.btnCommand_Ok15.Location = New System.Drawing.Point(57, 42)
        Me.btnCommand_Ok15.Name = "btnCommand_Ok15"
        Me.btnCommand_Ok15.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok15.TabIndex = 16
        Me.btnCommand_Ok15.Text = "Ok"
        Me.btnCommand_Ok15.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel15
        '
        Me.btnCommand_Cancel15.Location = New System.Drawing.Point(138, 42)
        Me.btnCommand_Cancel15.Name = "btnCommand_Cancel15"
        Me.btnCommand_Cancel15.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel15.TabIndex = 15
        Me.btnCommand_Cancel15.Text = "Cancel"
        Me.btnCommand_Cancel15.UseVisualStyleBackColor = True
        '
        'optChangePKNo
        '
        Me.optChangePKNo.AutoSize = True
        Me.optChangePKNo.Location = New System.Drawing.Point(128, 19)
        Me.optChangePKNo.Name = "optChangePKNo"
        Me.optChangePKNo.Size = New System.Drawing.Size(39, 17)
        Me.optChangePKNo.TabIndex = 1
        Me.optChangePKNo.TabStop = True
        Me.optChangePKNo.Text = "No"
        Me.optChangePKNo.UseVisualStyleBackColor = True
        '
        'optChangePKYes
        '
        Me.optChangePKYes.AutoSize = True
        Me.optChangePKYes.Location = New System.Drawing.Point(38, 19)
        Me.optChangePKYes.Name = "optChangePKYes"
        Me.optChangePKYes.Size = New System.Drawing.Size(43, 17)
        Me.optChangePKYes.TabIndex = 0
        Me.optChangePKYes.TabStop = True
        Me.optChangePKYes.Text = "Yes"
        Me.optChangePKYes.UseVisualStyleBackColor = True
        '
        'fraCommand15
        '
        Me.fraCommand15.Controls.Add(Me.btnCommand_Ok14)
        Me.fraCommand15.Controls.Add(Me.btnCommand_Cancel14)
        Me.fraCommand15.Controls.Add(Me.optChangeSexFemale)
        Me.fraCommand15.Controls.Add(Me.optChangeSexMale)
        Me.fraCommand15.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand15.Name = "fraCommand15"
        Me.fraCommand15.Size = New System.Drawing.Size(219, 71)
        Me.fraCommand15.TabIndex = 12
        Me.fraCommand15.TabStop = False
        Me.fraCommand15.Text = "Change Player Gender"
        Me.fraCommand15.Visible = False
        '
        'btnCommand_Ok14
        '
        Me.btnCommand_Ok14.Location = New System.Drawing.Point(57, 42)
        Me.btnCommand_Ok14.Name = "btnCommand_Ok14"
        Me.btnCommand_Ok14.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok14.TabIndex = 16
        Me.btnCommand_Ok14.Text = "Ok"
        Me.btnCommand_Ok14.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel14
        '
        Me.btnCommand_Cancel14.Location = New System.Drawing.Point(138, 42)
        Me.btnCommand_Cancel14.Name = "btnCommand_Cancel14"
        Me.btnCommand_Cancel14.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel14.TabIndex = 15
        Me.btnCommand_Cancel14.Text = "Cancel"
        Me.btnCommand_Cancel14.UseVisualStyleBackColor = True
        '
        'optChangeSexFemale
        '
        Me.optChangeSexFemale.AutoSize = True
        Me.optChangeSexFemale.Location = New System.Drawing.Point(128, 19)
        Me.optChangeSexFemale.Name = "optChangeSexFemale"
        Me.optChangeSexFemale.Size = New System.Drawing.Size(59, 17)
        Me.optChangeSexFemale.TabIndex = 1
        Me.optChangeSexFemale.TabStop = True
        Me.optChangeSexFemale.Text = "Female"
        Me.optChangeSexFemale.UseVisualStyleBackColor = True
        '
        'optChangeSexMale
        '
        Me.optChangeSexMale.AutoSize = True
        Me.optChangeSexMale.Location = New System.Drawing.Point(38, 19)
        Me.optChangeSexMale.Name = "optChangeSexMale"
        Me.optChangeSexMale.Size = New System.Drawing.Size(48, 17)
        Me.optChangeSexMale.TabIndex = 0
        Me.optChangeSexMale.TabStop = True
        Me.optChangeSexMale.Text = "Male"
        Me.optChangeSexMale.UseVisualStyleBackColor = True
        '
        'fraCommand14
        '
        Me.fraCommand14.Controls.Add(Me.btnCommand_Ok13)
        Me.fraCommand14.Controls.Add(Me.btnCommand_Cancel13)
        Me.fraCommand14.Controls.Add(Me.scrlChangeSprite)
        Me.fraCommand14.Controls.Add(Me.lblChangeSprite)
        Me.fraCommand14.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand14.Name = "fraCommand14"
        Me.fraCommand14.Size = New System.Drawing.Size(219, 67)
        Me.fraCommand14.TabIndex = 11
        Me.fraCommand14.TabStop = False
        Me.fraCommand14.Text = "Change Player Sprite"
        Me.fraCommand14.Visible = False
        '
        'btnCommand_Ok13
        '
        Me.btnCommand_Ok13.Location = New System.Drawing.Point(57, 39)
        Me.btnCommand_Ok13.Name = "btnCommand_Ok13"
        Me.btnCommand_Ok13.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok13.TabIndex = 24
        Me.btnCommand_Ok13.Text = "Ok"
        Me.btnCommand_Ok13.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel13
        '
        Me.btnCommand_Cancel13.Location = New System.Drawing.Point(138, 39)
        Me.btnCommand_Cancel13.Name = "btnCommand_Cancel13"
        Me.btnCommand_Cancel13.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel13.TabIndex = 23
        Me.btnCommand_Cancel13.Text = "Cancel"
        Me.btnCommand_Cancel13.UseVisualStyleBackColor = True
        '
        'scrlChangeSprite
        '
        Me.scrlChangeSprite.Location = New System.Drawing.Point(57, 19)
        Me.scrlChangeSprite.Name = "scrlChangeSprite"
        Me.scrlChangeSprite.Size = New System.Drawing.Size(159, 17)
        Me.scrlChangeSprite.TabIndex = 12
        '
        'lblChangeSprite
        '
        Me.lblChangeSprite.AutoSize = True
        Me.lblChangeSprite.Location = New System.Drawing.Point(8, 20)
        Me.lblChangeSprite.Name = "lblChangeSprite"
        Me.lblChangeSprite.Size = New System.Drawing.Size(46, 13)
        Me.lblChangeSprite.TabIndex = 0
        Me.lblChangeSprite.Text = "Sprite: 1"
        '
        'fraCommand13
        '
        Me.fraCommand13.Controls.Add(Me.btnCommand_Ok12)
        Me.fraCommand13.Controls.Add(Me.btnCommand_Cancel12)
        Me.fraCommand13.Controls.Add(Me.cmbChangeClass)
        Me.fraCommand13.Controls.Add(Me.lblRandomLabel29)
        Me.fraCommand13.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand13.Name = "fraCommand13"
        Me.fraCommand13.Size = New System.Drawing.Size(219, 73)
        Me.fraCommand13.TabIndex = 10
        Me.fraCommand13.TabStop = False
        Me.fraCommand13.Text = "Change Player Class"
        Me.fraCommand13.Visible = False
        '
        'btnCommand_Ok12
        '
        Me.btnCommand_Ok12.Location = New System.Drawing.Point(57, 43)
        Me.btnCommand_Ok12.Name = "btnCommand_Ok12"
        Me.btnCommand_Ok12.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok12.TabIndex = 22
        Me.btnCommand_Ok12.Text = "Ok"
        Me.btnCommand_Ok12.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel12
        '
        Me.btnCommand_Cancel12.Location = New System.Drawing.Point(138, 43)
        Me.btnCommand_Cancel12.Name = "btnCommand_Cancel12"
        Me.btnCommand_Cancel12.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel12.TabIndex = 21
        Me.btnCommand_Cancel12.Text = "Cancel"
        Me.btnCommand_Cancel12.UseVisualStyleBackColor = True
        '
        'cmbChangeClass
        '
        Me.cmbChangeClass.FormattingEnabled = True
        Me.cmbChangeClass.Location = New System.Drawing.Point(47, 16)
        Me.cmbChangeClass.Name = "cmbChangeClass"
        Me.cmbChangeClass.Size = New System.Drawing.Size(166, 21)
        Me.cmbChangeClass.TabIndex = 3
        '
        'lblRandomLabel29
        '
        Me.lblRandomLabel29.AutoSize = True
        Me.lblRandomLabel29.Location = New System.Drawing.Point(6, 21)
        Me.lblRandomLabel29.Name = "lblRandomLabel29"
        Me.lblRandomLabel29.Size = New System.Drawing.Size(35, 13)
        Me.lblRandomLabel29.TabIndex = 0
        Me.lblRandomLabel29.Text = "Class:"
        '
        'fraCommand12
        '
        Me.fraCommand12.Controls.Add(Me.btnCommand_Ok11)
        Me.fraCommand12.Controls.Add(Me.btnCommand_Cancel11)
        Me.fraCommand12.Controls.Add(Me.optChangeSkillsRemove)
        Me.fraCommand12.Controls.Add(Me.optChangeSkillsAdd)
        Me.fraCommand12.Controls.Add(Me.cmbChangeSkills)
        Me.fraCommand12.Controls.Add(Me.lblRandomLabel28)
        Me.fraCommand12.Location = New System.Drawing.Point(418, 16)
        Me.fraCommand12.Name = "fraCommand12"
        Me.fraCommand12.Size = New System.Drawing.Size(245, 94)
        Me.fraCommand12.TabIndex = 9
        Me.fraCommand12.TabStop = False
        Me.fraCommand12.Text = "Change Player Skills"
        Me.fraCommand12.Visible = False
        '
        'btnCommand_Ok11
        '
        Me.btnCommand_Ok11.Location = New System.Drawing.Point(83, 63)
        Me.btnCommand_Ok11.Name = "btnCommand_Ok11"
        Me.btnCommand_Ok11.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok11.TabIndex = 20
        Me.btnCommand_Ok11.Text = "Ok"
        Me.btnCommand_Ok11.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel11
        '
        Me.btnCommand_Cancel11.Location = New System.Drawing.Point(164, 63)
        Me.btnCommand_Cancel11.Name = "btnCommand_Cancel11"
        Me.btnCommand_Cancel11.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel11.TabIndex = 19
        Me.btnCommand_Cancel11.Text = "Cancel"
        Me.btnCommand_Cancel11.UseVisualStyleBackColor = True
        '
        'optChangeSkillsRemove
        '
        Me.optChangeSkillsRemove.AutoSize = True
        Me.optChangeSkillsRemove.Location = New System.Drawing.Point(106, 42)
        Me.optChangeSkillsRemove.Name = "optChangeSkillsRemove"
        Me.optChangeSkillsRemove.Size = New System.Drawing.Size(65, 17)
        Me.optChangeSkillsRemove.TabIndex = 4
        Me.optChangeSkillsRemove.TabStop = True
        Me.optChangeSkillsRemove.Text = "Remove"
        Me.optChangeSkillsRemove.UseVisualStyleBackColor = True
        '
        'optChangeSkillsAdd
        '
        Me.optChangeSkillsAdd.AutoSize = True
        Me.optChangeSkillsAdd.Location = New System.Drawing.Point(6, 42)
        Me.optChangeSkillsAdd.Name = "optChangeSkillsAdd"
        Me.optChangeSkillsAdd.Size = New System.Drawing.Size(56, 17)
        Me.optChangeSkillsAdd.TabIndex = 3
        Me.optChangeSkillsAdd.TabStop = True
        Me.optChangeSkillsAdd.Text = "Teach"
        Me.optChangeSkillsAdd.UseVisualStyleBackColor = True
        '
        'cmbChangeSkills
        '
        Me.cmbChangeSkills.FormattingEnabled = True
        Me.cmbChangeSkills.Location = New System.Drawing.Point(44, 15)
        Me.cmbChangeSkills.Name = "cmbChangeSkills"
        Me.cmbChangeSkills.Size = New System.Drawing.Size(195, 21)
        Me.cmbChangeSkills.TabIndex = 2
        '
        'lblRandomLabel28
        '
        Me.lblRandomLabel28.AutoSize = True
        Me.lblRandomLabel28.Location = New System.Drawing.Point(6, 19)
        Me.lblRandomLabel28.Name = "lblRandomLabel28"
        Me.lblRandomLabel28.Size = New System.Drawing.Size(26, 13)
        Me.lblRandomLabel28.TabIndex = 0
        Me.lblRandomLabel28.Text = "Skill"
        '
        'fraCommand11
        '
        Me.fraCommand11.Controls.Add(Me.btnCommand_Ok10)
        Me.fraCommand11.Controls.Add(Me.btnCommand_Cancel10)
        Me.fraCommand11.Controls.Add(Me.scrlChangeLevel)
        Me.fraCommand11.Controls.Add(Me.lblChangeLevel)
        Me.fraCommand11.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand11.Name = "fraCommand11"
        Me.fraCommand11.Size = New System.Drawing.Size(219, 83)
        Me.fraCommand11.TabIndex = 8
        Me.fraCommand11.TabStop = False
        Me.fraCommand11.Text = "Change Level"
        Me.fraCommand11.Visible = False
        '
        'btnCommand_Ok10
        '
        Me.btnCommand_Ok10.Location = New System.Drawing.Point(57, 55)
        Me.btnCommand_Ok10.Name = "btnCommand_Ok10"
        Me.btnCommand_Ok10.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok10.TabIndex = 20
        Me.btnCommand_Ok10.Text = "Ok"
        Me.btnCommand_Ok10.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel10
        '
        Me.btnCommand_Cancel10.Location = New System.Drawing.Point(138, 55)
        Me.btnCommand_Cancel10.Name = "btnCommand_Cancel10"
        Me.btnCommand_Cancel10.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel10.TabIndex = 19
        Me.btnCommand_Cancel10.Text = "Cancel"
        Me.btnCommand_Cancel10.UseVisualStyleBackColor = True
        '
        'scrlChangeLevel
        '
        Me.scrlChangeLevel.Location = New System.Drawing.Point(3, 35)
        Me.scrlChangeLevel.Name = "scrlChangeLevel"
        Me.scrlChangeLevel.Size = New System.Drawing.Size(210, 17)
        Me.scrlChangeLevel.TabIndex = 12
        '
        'lblChangeLevel
        '
        Me.lblChangeLevel.AutoSize = True
        Me.lblChangeLevel.Location = New System.Drawing.Point(6, 16)
        Me.lblChangeLevel.Name = "lblChangeLevel"
        Me.lblChangeLevel.Size = New System.Drawing.Size(45, 13)
        Me.lblChangeLevel.TabIndex = 0
        Me.lblChangeLevel.Text = "Level: 0"
        '
        'fraCommand10
        '
        Me.fraCommand10.Controls.Add(Me.btnCommand_Ok9)
        Me.fraCommand10.Controls.Add(Me.btnCommand_Cancel9)
        Me.fraCommand10.Controls.Add(Me.txtChangeItemsAmount)
        Me.fraCommand10.Controls.Add(Me.optChangeItemRemove)
        Me.fraCommand10.Controls.Add(Me.optChangeItemAdd)
        Me.fraCommand10.Controls.Add(Me.optChangeItemSet)
        Me.fraCommand10.Controls.Add(Me.cmbChangeItemIndex)
        Me.fraCommand10.Controls.Add(Me.lblRandomLabel27)
        Me.fraCommand10.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand10.Name = "fraCommand10"
        Me.fraCommand10.Size = New System.Drawing.Size(219, 118)
        Me.fraCommand10.TabIndex = 7
        Me.fraCommand10.TabStop = False
        Me.fraCommand10.Text = "Change Items"
        Me.fraCommand10.Visible = False
        '
        'btnCommand_Ok9
        '
        Me.btnCommand_Ok9.Location = New System.Drawing.Point(57, 88)
        Me.btnCommand_Ok9.Name = "btnCommand_Ok9"
        Me.btnCommand_Ok9.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok9.TabIndex = 14
        Me.btnCommand_Ok9.Text = "Ok"
        Me.btnCommand_Ok9.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel9
        '
        Me.btnCommand_Cancel9.Location = New System.Drawing.Point(138, 88)
        Me.btnCommand_Cancel9.Name = "btnCommand_Cancel9"
        Me.btnCommand_Cancel9.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel9.TabIndex = 13
        Me.btnCommand_Cancel9.Text = "Cancel"
        Me.btnCommand_Cancel9.UseVisualStyleBackColor = True
        '
        'txtChangeItemsAmount
        '
        Me.txtChangeItemsAmount.Location = New System.Drawing.Point(6, 62)
        Me.txtChangeItemsAmount.Name = "txtChangeItemsAmount"
        Me.txtChangeItemsAmount.Size = New System.Drawing.Size(207, 20)
        Me.txtChangeItemsAmount.TabIndex = 12
        Me.txtChangeItemsAmount.Text = "0"
        '
        'optChangeItemRemove
        '
        Me.optChangeItemRemove.AutoSize = True
        Me.optChangeItemRemove.Location = New System.Drawing.Point(134, 39)
        Me.optChangeItemRemove.Name = "optChangeItemRemove"
        Me.optChangeItemRemove.Size = New System.Drawing.Size(79, 17)
        Me.optChangeItemRemove.TabIndex = 11
        Me.optChangeItemRemove.TabStop = True
        Me.optChangeItemRemove.Text = "Take Away"
        Me.optChangeItemRemove.UseVisualStyleBackColor = True
        '
        'optChangeItemAdd
        '
        Me.optChangeItemAdd.AutoSize = True
        Me.optChangeItemAdd.Location = New System.Drawing.Point(85, 39)
        Me.optChangeItemAdd.Name = "optChangeItemAdd"
        Me.optChangeItemAdd.Size = New System.Drawing.Size(47, 17)
        Me.optChangeItemAdd.TabIndex = 10
        Me.optChangeItemAdd.TabStop = True
        Me.optChangeItemAdd.Text = "Give"
        Me.optChangeItemAdd.UseVisualStyleBackColor = True
        '
        'optChangeItemSet
        '
        Me.optChangeItemSet.AutoSize = True
        Me.optChangeItemSet.Location = New System.Drawing.Point(6, 39)
        Me.optChangeItemSet.Name = "optChangeItemSet"
        Me.optChangeItemSet.Size = New System.Drawing.Size(80, 17)
        Me.optChangeItemSet.TabIndex = 9
        Me.optChangeItemSet.TabStop = True
        Me.optChangeItemSet.Text = "Set Amount"
        Me.optChangeItemSet.UseVisualStyleBackColor = True
        '
        'cmbChangeItemIndex
        '
        Me.cmbChangeItemIndex.FormattingEnabled = True
        Me.cmbChangeItemIndex.Location = New System.Drawing.Point(71, 12)
        Me.cmbChangeItemIndex.Name = "cmbChangeItemIndex"
        Me.cmbChangeItemIndex.Size = New System.Drawing.Size(142, 21)
        Me.cmbChangeItemIndex.TabIndex = 8
        '
        'lblRandomLabel27
        '
        Me.lblRandomLabel27.AutoSize = True
        Me.lblRandomLabel27.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel27.Name = "lblRandomLabel27"
        Me.lblRandomLabel27.Size = New System.Drawing.Size(59, 13)
        Me.lblRandomLabel27.TabIndex = 0
        Me.lblRandomLabel27.Text = "Item Index:"
        '
        'fraCommand6
        '
        Me.fraCommand6.Controls.Add(Me.btnCommand_Ok6)
        Me.fraCommand6.Controls.Add(Me.btnCommand_Cancel6)
        Me.fraCommand6.Controls.Add(Me.lblRandomLabel26)
        Me.fraCommand6.Controls.Add(Me.lblRandomLabel24)
        Me.fraCommand6.Controls.Add(Me.cmbSetSelfSwitchTo)
        Me.fraCommand6.Controls.Add(Me.cmbSetSelfSwitch)
        Me.fraCommand6.Location = New System.Drawing.Point(418, 16)
        Me.fraCommand6.Name = "fraCommand6"
        Me.fraCommand6.Size = New System.Drawing.Size(245, 100)
        Me.fraCommand6.TabIndex = 6
        Me.fraCommand6.TabStop = False
        Me.fraCommand6.Text = "Self Switch"
        Me.fraCommand6.Visible = False
        '
        'btnCommand_Ok6
        '
        Me.btnCommand_Ok6.Location = New System.Drawing.Point(81, 71)
        Me.btnCommand_Ok6.Name = "btnCommand_Ok6"
        Me.btnCommand_Ok6.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok6.TabIndex = 18
        Me.btnCommand_Ok6.Text = "Ok"
        Me.btnCommand_Ok6.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel6
        '
        Me.btnCommand_Cancel6.Location = New System.Drawing.Point(162, 71)
        Me.btnCommand_Cancel6.Name = "btnCommand_Cancel6"
        Me.btnCommand_Cancel6.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel6.TabIndex = 17
        Me.btnCommand_Cancel6.Text = "Cancel"
        Me.btnCommand_Cancel6.UseVisualStyleBackColor = True
        '
        'lblRandomLabel26
        '
        Me.lblRandomLabel26.AutoSize = True
        Me.lblRandomLabel26.Location = New System.Drawing.Point(8, 51)
        Me.lblRandomLabel26.Name = "lblRandomLabel26"
        Me.lblRandomLabel26.Size = New System.Drawing.Size(38, 13)
        Me.lblRandomLabel26.TabIndex = 13
        Me.lblRandomLabel26.Text = "Set to:"
        '
        'lblRandomLabel24
        '
        Me.lblRandomLabel24.AutoSize = True
        Me.lblRandomLabel24.Location = New System.Drawing.Point(8, 18)
        Me.lblRandomLabel24.Name = "lblRandomLabel24"
        Me.lblRandomLabel24.Size = New System.Drawing.Size(60, 13)
        Me.lblRandomLabel24.TabIndex = 14
        Me.lblRandomLabel24.Text = "Self Switch"
        '
        'cmbSetSelfSwitchTo
        '
        Me.cmbSetSelfSwitchTo.FormattingEnabled = True
        Me.cmbSetSelfSwitchTo.Items.AddRange(New Object() {"On", "Off"})
        Me.cmbSetSelfSwitchTo.Location = New System.Drawing.Point(58, 44)
        Me.cmbSetSelfSwitchTo.Name = "cmbSetSelfSwitchTo"
        Me.cmbSetSelfSwitchTo.Size = New System.Drawing.Size(179, 21)
        Me.cmbSetSelfSwitchTo.TabIndex = 15
        '
        'cmbSetSelfSwitch
        '
        Me.cmbSetSelfSwitch.FormattingEnabled = True
        Me.cmbSetSelfSwitch.Items.AddRange(New Object() {"A", "B", "C", "D"})
        Me.cmbSetSelfSwitch.Location = New System.Drawing.Point(80, 15)
        Me.cmbSetSelfSwitch.Name = "cmbSetSelfSwitch"
        Me.cmbSetSelfSwitch.Size = New System.Drawing.Size(157, 21)
        Me.cmbSetSelfSwitch.TabIndex = 16
        '
        'fraCommand5
        '
        Me.fraCommand5.Controls.Add(Me.btnCommand_Ok5)
        Me.fraCommand5.Controls.Add(Me.btnCommand_Cancel5)
        Me.fraCommand5.Controls.Add(Me.lblRandomLabel22)
        Me.fraCommand5.Controls.Add(Me.lblRandomLabel23)
        Me.fraCommand5.Controls.Add(Me.cmbPlayerSwitchSet)
        Me.fraCommand5.Controls.Add(Me.cmbSwitch)
        Me.fraCommand5.Location = New System.Drawing.Point(418, 16)
        Me.fraCommand5.Name = "fraCommand5"
        Me.fraCommand5.Size = New System.Drawing.Size(245, 98)
        Me.fraCommand5.TabIndex = 5
        Me.fraCommand5.TabStop = False
        Me.fraCommand5.Text = "Player Switch"
        Me.fraCommand5.Visible = False
        '
        'btnCommand_Ok5
        '
        Me.btnCommand_Ok5.Location = New System.Drawing.Point(83, 70)
        Me.btnCommand_Ok5.Name = "btnCommand_Ok5"
        Me.btnCommand_Ok5.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok5.TabIndex = 12
        Me.btnCommand_Ok5.Text = "Ok"
        Me.btnCommand_Ok5.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel5
        '
        Me.btnCommand_Cancel5.Location = New System.Drawing.Point(164, 70)
        Me.btnCommand_Cancel5.Name = "btnCommand_Cancel5"
        Me.btnCommand_Cancel5.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel5.TabIndex = 11
        Me.btnCommand_Cancel5.Text = "Cancel"
        Me.btnCommand_Cancel5.UseVisualStyleBackColor = True
        '
        'lblRandomLabel22
        '
        Me.lblRandomLabel22.AutoSize = True
        Me.lblRandomLabel22.Location = New System.Drawing.Point(10, 50)
        Me.lblRandomLabel22.Name = "lblRandomLabel22"
        Me.lblRandomLabel22.Size = New System.Drawing.Size(38, 13)
        Me.lblRandomLabel22.TabIndex = 0
        Me.lblRandomLabel22.Text = "Set to:"
        '
        'lblRandomLabel23
        '
        Me.lblRandomLabel23.AutoSize = True
        Me.lblRandomLabel23.Location = New System.Drawing.Point(10, 17)
        Me.lblRandomLabel23.Name = "lblRandomLabel23"
        Me.lblRandomLabel23.Size = New System.Drawing.Size(39, 13)
        Me.lblRandomLabel23.TabIndex = 0
        Me.lblRandomLabel23.Text = "Switch"
        '
        'cmbPlayerSwitchSet
        '
        Me.cmbPlayerSwitchSet.FormattingEnabled = True
        Me.cmbPlayerSwitchSet.Items.AddRange(New Object() {"True", "False"})
        Me.cmbPlayerSwitchSet.Location = New System.Drawing.Point(60, 43)
        Me.cmbPlayerSwitchSet.Name = "cmbPlayerSwitchSet"
        Me.cmbPlayerSwitchSet.Size = New System.Drawing.Size(179, 21)
        Me.cmbPlayerSwitchSet.TabIndex = 1
        '
        'cmbSwitch
        '
        Me.cmbSwitch.FormattingEnabled = True
        Me.cmbSwitch.Location = New System.Drawing.Point(60, 14)
        Me.cmbSwitch.Name = "cmbSwitch"
        Me.cmbSwitch.Size = New System.Drawing.Size(179, 21)
        Me.cmbSwitch.TabIndex = 1
        '
        'fraCommand9
        '
        Me.fraCommand9.Controls.Add(Me.btnCommand_Ok8)
        Me.fraCommand9.Controls.Add(Me.txtGotoLabel)
        Me.fraCommand9.Controls.Add(Me.btnCommand_Cancel8)
        Me.fraCommand9.Controls.Add(Me.lblRandomLabel41)
        Me.fraCommand9.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand9.Name = "fraCommand9"
        Me.fraCommand9.Size = New System.Drawing.Size(219, 97)
        Me.fraCommand9.TabIndex = 4
        Me.fraCommand9.TabStop = False
        Me.fraCommand9.Text = "GoTo Label:"
        Me.fraCommand9.Visible = False
        '
        'btnCommand_Ok8
        '
        Me.btnCommand_Ok8.Location = New System.Drawing.Point(57, 69)
        Me.btnCommand_Ok8.Name = "btnCommand_Ok8"
        Me.btnCommand_Ok8.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok8.TabIndex = 10
        Me.btnCommand_Ok8.Text = "Ok"
        Me.btnCommand_Ok8.UseVisualStyleBackColor = True
        '
        'txtGotoLabel
        '
        Me.txtGotoLabel.Location = New System.Drawing.Point(6, 33)
        Me.txtGotoLabel.Name = "txtGotoLabel"
        Me.txtGotoLabel.Size = New System.Drawing.Size(207, 20)
        Me.txtGotoLabel.TabIndex = 8
        '
        'btnCommand_Cancel8
        '
        Me.btnCommand_Cancel8.Location = New System.Drawing.Point(138, 69)
        Me.btnCommand_Cancel8.Name = "btnCommand_Cancel8"
        Me.btnCommand_Cancel8.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel8.TabIndex = 9
        Me.btnCommand_Cancel8.Text = "Cancel"
        Me.btnCommand_Cancel8.UseVisualStyleBackColor = True
        '
        'lblRandomLabel41
        '
        Me.lblRandomLabel41.AutoSize = True
        Me.lblRandomLabel41.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel41.Name = "lblRandomLabel41"
        Me.lblRandomLabel41.Size = New System.Drawing.Size(67, 13)
        Me.lblRandomLabel41.TabIndex = 7
        Me.lblRandomLabel41.Text = "Label Name:"
        '
        'fraCommand8
        '
        Me.fraCommand8.Controls.Add(Me.btnCommand_Ok7)
        Me.fraCommand8.Controls.Add(Me.txtLabelName)
        Me.fraCommand8.Controls.Add(Me.btnCommand_Cancel7)
        Me.fraCommand8.Controls.Add(Me.lblRandomLabel40)
        Me.fraCommand8.Location = New System.Drawing.Point(432, 13)
        Me.fraCommand8.Name = "fraCommand8"
        Me.fraCommand8.Size = New System.Drawing.Size(219, 100)
        Me.fraCommand8.TabIndex = 3
        Me.fraCommand8.TabStop = False
        Me.fraCommand8.Text = "Create Label"
        Me.fraCommand8.Visible = False
        '
        'btnCommand_Ok7
        '
        Me.btnCommand_Ok7.Location = New System.Drawing.Point(57, 71)
        Me.btnCommand_Ok7.Name = "btnCommand_Ok7"
        Me.btnCommand_Ok7.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok7.TabIndex = 6
        Me.btnCommand_Ok7.Text = "Ok"
        Me.btnCommand_Ok7.UseVisualStyleBackColor = True
        '
        'txtLabelName
        '
        Me.txtLabelName.Location = New System.Drawing.Point(6, 35)
        Me.txtLabelName.Name = "txtLabelName"
        Me.txtLabelName.Size = New System.Drawing.Size(207, 20)
        Me.txtLabelName.TabIndex = 1
        '
        'btnCommand_Cancel7
        '
        Me.btnCommand_Cancel7.Location = New System.Drawing.Point(138, 71)
        Me.btnCommand_Cancel7.Name = "btnCommand_Cancel7"
        Me.btnCommand_Cancel7.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel7.TabIndex = 5
        Me.btnCommand_Cancel7.Text = "Cancel"
        Me.btnCommand_Cancel7.UseVisualStyleBackColor = True
        '
        'lblRandomLabel40
        '
        Me.lblRandomLabel40.AutoSize = True
        Me.lblRandomLabel40.Location = New System.Drawing.Point(6, 18)
        Me.lblRandomLabel40.Name = "lblRandomLabel40"
        Me.lblRandomLabel40.Size = New System.Drawing.Size(67, 13)
        Me.lblRandomLabel40.TabIndex = 0
        Me.lblRandomLabel40.Text = "Label Name:"
        '
        'fraCommand32
        '
        Me.fraCommand32.Controls.Add(Me.btnCommand_Ok30)
        Me.fraCommand32.Controls.Add(Me.btnCommand_Cancel30)
        Me.fraCommand32.Controls.Add(Me.scrlCompleteQuestTask)
        Me.fraCommand32.Controls.Add(Me.scrlCompleteQuestTaskQuest)
        Me.fraCommand32.Controls.Add(Me.lblRandomLabel48)
        Me.fraCommand32.Controls.Add(Me.lblRandomLabel47)
        Me.fraCommand32.Location = New System.Drawing.Point(432, 12)
        Me.fraCommand32.Name = "fraCommand32"
        Me.fraCommand32.Size = New System.Drawing.Size(219, 100)
        Me.fraCommand32.TabIndex = 2
        Me.fraCommand32.TabStop = False
        Me.fraCommand32.Text = "Complete Quest Task"
        Me.fraCommand32.Visible = False
        '
        'btnCommand_Ok30
        '
        Me.btnCommand_Ok30.Location = New System.Drawing.Point(57, 71)
        Me.btnCommand_Ok30.Name = "btnCommand_Ok30"
        Me.btnCommand_Ok30.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok30.TabIndex = 15
        Me.btnCommand_Ok30.Text = "Ok"
        Me.btnCommand_Ok30.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel30
        '
        Me.btnCommand_Cancel30.Location = New System.Drawing.Point(138, 71)
        Me.btnCommand_Cancel30.Name = "btnCommand_Cancel30"
        Me.btnCommand_Cancel30.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel30.TabIndex = 14
        Me.btnCommand_Cancel30.Text = "Cancel"
        Me.btnCommand_Cancel30.UseVisualStyleBackColor = True
        '
        'scrlCompleteQuestTask
        '
        Me.scrlCompleteQuestTask.LargeChange = 1
        Me.scrlCompleteQuestTask.Location = New System.Drawing.Point(56, 46)
        Me.scrlCompleteQuestTask.Maximum = 10
        Me.scrlCompleteQuestTask.Name = "scrlCompleteQuestTask"
        Me.scrlCompleteQuestTask.Size = New System.Drawing.Size(160, 17)
        Me.scrlCompleteQuestTask.TabIndex = 13
        '
        'scrlCompleteQuestTaskQuest
        '
        Me.scrlCompleteQuestTaskQuest.LargeChange = 1
        Me.scrlCompleteQuestTaskQuest.Location = New System.Drawing.Point(56, 14)
        Me.scrlCompleteQuestTaskQuest.Maximum = 50
        Me.scrlCompleteQuestTaskQuest.Name = "scrlCompleteQuestTaskQuest"
        Me.scrlCompleteQuestTaskQuest.Size = New System.Drawing.Size(160, 17)
        Me.scrlCompleteQuestTaskQuest.TabIndex = 12
        '
        'lblRandomLabel48
        '
        Me.lblRandomLabel48.AutoSize = True
        Me.lblRandomLabel48.Location = New System.Drawing.Point(6, 48)
        Me.lblRandomLabel48.Name = "lblRandomLabel48"
        Me.lblRandomLabel48.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel48.TabIndex = 1
        Me.lblRandomLabel48.Text = "Task:  1."
        '
        'lblRandomLabel47
        '
        Me.lblRandomLabel47.AutoSize = True
        Me.lblRandomLabel47.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel47.Name = "lblRandomLabel47"
        Me.lblRandomLabel47.Size = New System.Drawing.Size(50, 13)
        Me.lblRandomLabel47.TabIndex = 0
        Me.lblRandomLabel47.Text = "Quest: 1."
        '
        'fraCommand4
        '
        Me.fraCommand4.Controls.Add(Me.btnCommand_Ok4)
        Me.fraCommand4.Controls.Add(Me.btnCommand_Cancel4)
        Me.fraCommand4.Controls.Add(Me.lblRandomLabel37)
        Me.fraCommand4.Controls.Add(Me.lblRandomLabel13)
        Me.fraCommand4.Controls.Add(Me.txtVariableData4)
        Me.fraCommand4.Controls.Add(Me.txtVariableData3)
        Me.fraCommand4.Controls.Add(Me.optVariableAction3)
        Me.fraCommand4.Controls.Add(Me.txtVariableData2)
        Me.fraCommand4.Controls.Add(Me.optVariableAction2)
        Me.fraCommand4.Controls.Add(Me.txtVariableData1)
        Me.fraCommand4.Controls.Add(Me.optVariableAction1)
        Me.fraCommand4.Controls.Add(Me.txtVariableData0)
        Me.fraCommand4.Controls.Add(Me.optVariableAction0)
        Me.fraCommand4.Controls.Add(Me.cmbVariable)
        Me.fraCommand4.Controls.Add(Me.lblRandomLabel)
        Me.fraCommand4.Location = New System.Drawing.Point(418, 15)
        Me.fraCommand4.Name = "fraCommand4"
        Me.fraCommand4.Size = New System.Drawing.Size(245, 171)
        Me.fraCommand4.TabIndex = 1
        Me.fraCommand4.TabStop = False
        Me.fraCommand4.Text = "Player Variable"
        Me.fraCommand4.Visible = False
        '
        'btnCommand_Ok4
        '
        Me.btnCommand_Ok4.Location = New System.Drawing.Point(83, 142)
        Me.btnCommand_Ok4.Name = "btnCommand_Ok4"
        Me.btnCommand_Ok4.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Ok4.TabIndex = 6
        Me.btnCommand_Ok4.Text = "Ok"
        Me.btnCommand_Ok4.UseVisualStyleBackColor = True
        '
        'btnCommand_Cancel4
        '
        Me.btnCommand_Cancel4.Location = New System.Drawing.Point(164, 142)
        Me.btnCommand_Cancel4.Name = "btnCommand_Cancel4"
        Me.btnCommand_Cancel4.Size = New System.Drawing.Size(75, 23)
        Me.btnCommand_Cancel4.TabIndex = 5
        Me.btnCommand_Cancel4.Text = "Cancel"
        Me.btnCommand_Cancel4.UseVisualStyleBackColor = True
        '
        'lblRandomLabel37
        '
        Me.lblRandomLabel37.AutoSize = True
        Me.lblRandomLabel37.Location = New System.Drawing.Point(157, 119)
        Me.lblRandomLabel37.Name = "lblRandomLabel37"
        Me.lblRandomLabel37.Size = New System.Drawing.Size(29, 13)
        Me.lblRandomLabel37.TabIndex = 4
        Me.lblRandomLabel37.Text = "High"
        '
        'lblRandomLabel13
        '
        Me.lblRandomLabel13.AutoSize = True
        Me.lblRandomLabel13.Location = New System.Drawing.Point(77, 119)
        Me.lblRandomLabel13.Name = "lblRandomLabel13"
        Me.lblRandomLabel13.Size = New System.Drawing.Size(27, 13)
        Me.lblRandomLabel13.TabIndex = 4
        Me.lblRandomLabel13.Text = "Low"
        '
        'txtVariableData4
        '
        Me.txtVariableData4.Location = New System.Drawing.Point(194, 116)
        Me.txtVariableData4.Name = "txtVariableData4"
        Me.txtVariableData4.Size = New System.Drawing.Size(45, 20)
        Me.txtVariableData4.TabIndex = 3
        Me.txtVariableData4.Text = "0"
        '
        'txtVariableData3
        '
        Me.txtVariableData3.Location = New System.Drawing.Point(106, 116)
        Me.txtVariableData3.Name = "txtVariableData3"
        Me.txtVariableData3.Size = New System.Drawing.Size(45, 20)
        Me.txtVariableData3.TabIndex = 3
        Me.txtVariableData3.Text = "0"
        '
        'optVariableAction3
        '
        Me.optVariableAction3.AutoSize = True
        Me.optVariableAction3.Location = New System.Drawing.Point(6, 117)
        Me.optVariableAction3.Name = "optVariableAction3"
        Me.optVariableAction3.Size = New System.Drawing.Size(65, 17)
        Me.optVariableAction3.TabIndex = 2
        Me.optVariableAction3.TabStop = True
        Me.optVariableAction3.Text = "Random"
        Me.optVariableAction3.UseVisualStyleBackColor = True
        '
        'txtVariableData2
        '
        Me.txtVariableData2.Location = New System.Drawing.Point(106, 87)
        Me.txtVariableData2.Name = "txtVariableData2"
        Me.txtVariableData2.Size = New System.Drawing.Size(133, 20)
        Me.txtVariableData2.TabIndex = 3
        Me.txtVariableData2.Text = "0"
        '
        'optVariableAction2
        '
        Me.optVariableAction2.AutoSize = True
        Me.optVariableAction2.Location = New System.Drawing.Point(6, 91)
        Me.optVariableAction2.Name = "optVariableAction2"
        Me.optVariableAction2.Size = New System.Drawing.Size(65, 17)
        Me.optVariableAction2.TabIndex = 2
        Me.optVariableAction2.TabStop = True
        Me.optVariableAction2.Text = "Subtract"
        Me.optVariableAction2.UseVisualStyleBackColor = True
        '
        'txtVariableData1
        '
        Me.txtVariableData1.Location = New System.Drawing.Point(106, 62)
        Me.txtVariableData1.Name = "txtVariableData1"
        Me.txtVariableData1.Size = New System.Drawing.Size(133, 20)
        Me.txtVariableData1.TabIndex = 3
        Me.txtVariableData1.Text = "0"
        '
        'optVariableAction1
        '
        Me.optVariableAction1.AutoSize = True
        Me.optVariableAction1.Location = New System.Drawing.Point(6, 66)
        Me.optVariableAction1.Name = "optVariableAction1"
        Me.optVariableAction1.Size = New System.Drawing.Size(44, 17)
        Me.optVariableAction1.TabIndex = 2
        Me.optVariableAction1.TabStop = True
        Me.optVariableAction1.Text = "Add"
        Me.optVariableAction1.UseVisualStyleBackColor = True
        '
        'txtVariableData0
        '
        Me.txtVariableData0.Location = New System.Drawing.Point(106, 36)
        Me.txtVariableData0.Name = "txtVariableData0"
        Me.txtVariableData0.Size = New System.Drawing.Size(133, 20)
        Me.txtVariableData0.TabIndex = 3
        Me.txtVariableData0.Text = "0"
        '
        'optVariableAction0
        '
        Me.optVariableAction0.AutoSize = True
        Me.optVariableAction0.Location = New System.Drawing.Point(6, 40)
        Me.optVariableAction0.Name = "optVariableAction0"
        Me.optVariableAction0.Size = New System.Drawing.Size(41, 17)
        Me.optVariableAction0.TabIndex = 2
        Me.optVariableAction0.TabStop = True
        Me.optVariableAction0.Text = "Set"
        Me.optVariableAction0.UseVisualStyleBackColor = True
        '
        'cmbVariable
        '
        Me.cmbVariable.FormattingEnabled = True
        Me.cmbVariable.Location = New System.Drawing.Point(60, 13)
        Me.cmbVariable.Name = "cmbVariable"
        Me.cmbVariable.Size = New System.Drawing.Size(179, 21)
        Me.cmbVariable.TabIndex = 1
        '
        'lblRandomLabel
        '
        Me.lblRandomLabel.AutoSize = True
        Me.lblRandomLabel.Location = New System.Drawing.Point(6, 16)
        Me.lblRandomLabel.Name = "lblRandomLabel"
        Me.lblRandomLabel.Size = New System.Drawing.Size(48, 13)
        Me.lblRandomLabel.TabIndex = 0
        Me.lblRandomLabel.Text = "Variable:"
        '
        'lblRandomLabel11
        '
        Me.lblRandomLabel11.AutoSize = True
        Me.lblRandomLabel11.ForeColor = System.Drawing.Color.Red
        Me.lblRandomLabel11.Location = New System.Drawing.Point(198, 608)
        Me.lblRandomLabel11.Name = "lblRandomLabel11"
        Me.lblRandomLabel11.Size = New System.Drawing.Size(308, 13)
        Me.lblRandomLabel11.TabIndex = 7
        Me.lblRandomLabel11.Text = "* Self Switches are always global and will reset on server restart."
        '
        'lblRandomLabel14
        '
        Me.lblRandomLabel14.AutoSize = True
        Me.lblRandomLabel14.ForeColor = System.Drawing.Color.Red
        Me.lblRandomLabel14.Location = New System.Drawing.Point(198, 627)
        Me.lblRandomLabel14.Name = "lblRandomLabel14"
        Me.lblRandomLabel14.Size = New System.Drawing.Size(432, 13)
        Me.lblRandomLabel14.TabIndex = 7
        Me.lblRandomLabel14.Text = "** If global, only the first page will be processed. For shop keepers and such.(E" &
    "xperimental)"
        '
        'fraCommands
        '
        Me.fraCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fraCommands.Controls.Add(Me.lstvCommands)
        Me.fraCommands.Controls.Add(Me.btnCancelCommand)
        Me.fraCommands.Location = New System.Drawing.Point(413, 7)
        Me.fraCommands.Name = "fraCommands"
        Me.fraCommands.Size = New System.Drawing.Size(397, 503)
        Me.fraCommands.TabIndex = 10
        Me.fraCommands.Visible = False
        '
        'lstvCommands
        '
        Me.lstvCommands.AutoArrange = False
        Me.lstvCommands.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstvCommands.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstvCommands.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstvCommands.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ListViewGroup1.Header = "Messages"
        ListViewGroup1.Name = "lstVgMessages"
        ListViewGroup2.Header = "Events Progressing"
        ListViewGroup2.Name = "lstVgEvents"
        ListViewGroup3.Header = "Flow Control"
        ListViewGroup3.Name = "lstVgFlow"
        ListViewGroup4.Header = "Player Options"
        ListViewGroup4.Name = "lstVgPlayerOptions"
        ListViewGroup5.Header = "Movement"
        ListViewGroup5.Name = "lstVgMovement"
        ListViewGroup6.Header = "Animation"
        ListViewGroup6.Name = "lstVgAnimation"
        ListViewGroup7.Header = "Questing"
        ListViewGroup7.Name = "lstVgQuesting"
        Me.lstvCommands.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7})
        Me.lstvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup1
        ListViewItem2.IndentCount = 1
        ListViewItem3.Group = ListViewGroup1
        ListViewItem4.Group = ListViewGroup1
        ListViewItem4.IndentCount = 1
        ListViewItem5.Group = ListViewGroup2
        ListViewItem6.Group = ListViewGroup2
        ListViewItem7.Group = ListViewGroup2
        ListViewItem8.Group = ListViewGroup3
        ListViewItem9.Group = ListViewGroup3
        ListViewItem10.Group = ListViewGroup3
        ListViewItem11.Group = ListViewGroup3
        ListViewItem12.Group = ListViewGroup4
        ListViewItem13.Group = ListViewGroup4
        ListViewItem14.Group = ListViewGroup4
        ListViewItem15.Group = ListViewGroup4
        ListViewItem16.Group = ListViewGroup4
        ListViewItem17.Group = ListViewGroup4
        ListViewItem18.Group = ListViewGroup4
        ListViewItem19.Group = ListViewGroup4
        ListViewItem20.Group = ListViewGroup4
        ListViewItem21.Group = ListViewGroup4
        ListViewItem22.Group = ListViewGroup4
        ListViewItem23.Group = ListViewGroup5
        ListViewItem24.Group = ListViewGroup5
        ListViewItem25.Group = ListViewGroup5
        ListViewItem26.Group = ListViewGroup5
        ListViewItem27.Group = ListViewGroup5
        ListViewItem28.Group = ListViewGroup5
        Me.lstvCommands.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28})
        Me.lstvCommands.LabelWrap = False
        Me.lstvCommands.Location = New System.Drawing.Point(0, 0)
        Me.lstvCommands.MultiSelect = False
        Me.lstvCommands.Name = "lstvCommands"
        Me.lstvCommands.Size = New System.Drawing.Size(395, 471)
        Me.lstvCommands.TabIndex = 3
        Me.lstvCommands.UseCompatibleStateImageBehavior = False
        Me.lstvCommands.View = System.Windows.Forms.View.Tile
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.Width = 150
        '
        'btnCancelCommand
        '
        Me.btnCancelCommand.Location = New System.Drawing.Point(318, 477)
        Me.btnCancelCommand.Name = "btnCancelCommand"
        Me.btnCancelCommand.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelCommand.TabIndex = 1
        Me.btnCancelCommand.Text = "Cancel"
        Me.btnCancelCommand.UseVisualStyleBackColor = True
        '
        'tabCommands
        '
        Me.tabCommands.Controls.Add(Me.TabPage1)
        Me.tabCommands.Controls.Add(Me.TabPage2)
        Me.tabCommands.Controls.Add(Me.TabPage3)
        Me.tabCommands.Location = New System.Drawing.Point(838, 10)
        Me.tabCommands.Name = "tabCommands"
        Me.tabCommands.SelectedIndex = 0
        Me.tabCommands.Size = New System.Drawing.Size(393, 468)
        Me.tabCommands.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.fraRandom2)
        Me.TabPage1.Controls.Add(Me.fraRandom1)
        Me.TabPage1.Controls.Add(Me.fraRandom3)
        Me.TabPage1.Controls.Add(Me.fraRandom21)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(385, 442)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'fraRandom2
        '
        Me.fraRandom2.Controls.Add(Me.btnCommands10)
        Me.fraRandom2.Controls.Add(Me.btnCommands9)
        Me.fraRandom2.Controls.Add(Me.btnCommands8)
        Me.fraRandom2.Controls.Add(Me.btnCommands7)
        Me.fraRandom2.Location = New System.Drawing.Point(6, 261)
        Me.fraRandom2.Name = "fraRandom2"
        Me.fraRandom2.Size = New System.Drawing.Size(180, 133)
        Me.fraRandom2.TabIndex = 3
        Me.fraRandom2.TabStop = False
        Me.fraRandom2.Text = "Flow Control"
        '
        'btnCommands10
        '
        Me.btnCommands10.Location = New System.Drawing.Point(6, 104)
        Me.btnCommands10.Name = "btnCommands10"
        Me.btnCommands10.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands10.TabIndex = 3
        Me.btnCommands10.Text = "GoTo Label"
        Me.btnCommands10.UseVisualStyleBackColor = True
        '
        'btnCommands9
        '
        Me.btnCommands9.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands9.Name = "btnCommands9"
        Me.btnCommands9.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands9.TabIndex = 2
        Me.btnCommands9.Text = "Label"
        Me.btnCommands9.UseVisualStyleBackColor = True
        '
        'btnCommands8
        '
        Me.btnCommands8.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands8.Name = "btnCommands8"
        Me.btnCommands8.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands8.TabIndex = 1
        Me.btnCommands8.Text = "Exit Event Process"
        Me.btnCommands8.UseVisualStyleBackColor = True
        '
        'btnCommands7
        '
        Me.btnCommands7.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands7.Name = "btnCommands7"
        Me.btnCommands7.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands7.TabIndex = 0
        Me.btnCommands7.Text = "Conditional Branch"
        Me.btnCommands7.UseVisualStyleBackColor = True
        '
        'fraRandom1
        '
        Me.fraRandom1.Controls.Add(Me.btnCommands6)
        Me.fraRandom1.Controls.Add(Me.btnCommands5)
        Me.fraRandom1.Controls.Add(Me.btnCommands4)
        Me.fraRandom1.Location = New System.Drawing.Point(6, 145)
        Me.fraRandom1.Name = "fraRandom1"
        Me.fraRandom1.Size = New System.Drawing.Size(180, 110)
        Me.fraRandom1.TabIndex = 2
        Me.fraRandom1.TabStop = False
        Me.fraRandom1.Text = "Event Progression"
        '
        'btnCommands6
        '
        Me.btnCommands6.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands6.Name = "btnCommands6"
        Me.btnCommands6.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands6.TabIndex = 2
        Me.btnCommands6.Text = "Self Switch"
        Me.btnCommands6.UseVisualStyleBackColor = True
        '
        'btnCommands5
        '
        Me.btnCommands5.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands5.Name = "btnCommands5"
        Me.btnCommands5.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands5.TabIndex = 1
        Me.btnCommands5.Text = "Player Switch"
        Me.btnCommands5.UseVisualStyleBackColor = True
        '
        'btnCommands4
        '
        Me.btnCommands4.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands4.Name = "btnCommands4"
        Me.btnCommands4.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands4.TabIndex = 0
        Me.btnCommands4.Text = "Player Variable"
        Me.btnCommands4.UseVisualStyleBackColor = True
        '
        'fraRandom3
        '
        Me.fraRandom3.Controls.Add(Me.btnCommands21)
        Me.fraRandom3.Controls.Add(Me.btnCommands20)
        Me.fraRandom3.Controls.Add(Me.btnCommands19)
        Me.fraRandom3.Controls.Add(Me.btnCommands18)
        Me.fraRandom3.Controls.Add(Me.btnCommands17)
        Me.fraRandom3.Controls.Add(Me.btnCommands16)
        Me.fraRandom3.Controls.Add(Me.btnCommands15)
        Me.fraRandom3.Controls.Add(Me.btnCommands14)
        Me.fraRandom3.Controls.Add(Me.btnCommands13)
        Me.fraRandom3.Controls.Add(Me.btnCommands12)
        Me.fraRandom3.Controls.Add(Me.btnCommands11)
        Me.fraRandom3.Location = New System.Drawing.Point(192, 6)
        Me.fraRandom3.Name = "fraRandom3"
        Me.fraRandom3.Size = New System.Drawing.Size(187, 415)
        Me.fraRandom3.TabIndex = 1
        Me.fraRandom3.TabStop = False
        Me.fraRandom3.Text = "Player Control"
        '
        'btnCommands21
        '
        Me.btnCommands21.Location = New System.Drawing.Point(12, 303)
        Me.btnCommands21.Name = "btnCommands21"
        Me.btnCommands21.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands21.TabIndex = 14
        Me.btnCommands21.Text = "Give Experience"
        Me.btnCommands21.UseVisualStyleBackColor = True
        '
        'btnCommands20
        '
        Me.btnCommands20.Location = New System.Drawing.Point(12, 274)
        Me.btnCommands20.Name = "btnCommands20"
        Me.btnCommands20.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands20.TabIndex = 13
        Me.btnCommands20.Text = "Change PK"
        Me.btnCommands20.UseVisualStyleBackColor = True
        '
        'btnCommands19
        '
        Me.btnCommands19.Location = New System.Drawing.Point(12, 247)
        Me.btnCommands19.Name = "btnCommands19"
        Me.btnCommands19.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands19.TabIndex = 12
        Me.btnCommands19.Text = "Change Gender"
        Me.btnCommands19.UseVisualStyleBackColor = True
        '
        'btnCommands18
        '
        Me.btnCommands18.Enabled = False
        Me.btnCommands18.Location = New System.Drawing.Point(12, 218)
        Me.btnCommands18.Name = "btnCommands18"
        Me.btnCommands18.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands18.TabIndex = 11
        Me.btnCommands18.Text = "Change Sprite"
        Me.btnCommands18.UseVisualStyleBackColor = True
        '
        'btnCommands17
        '
        Me.btnCommands17.Location = New System.Drawing.Point(12, 189)
        Me.btnCommands17.Name = "btnCommands17"
        Me.btnCommands17.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands17.TabIndex = 10
        Me.btnCommands17.Text = "Change Class"
        Me.btnCommands17.UseVisualStyleBackColor = True
        '
        'btnCommands16
        '
        Me.btnCommands16.Location = New System.Drawing.Point(12, 160)
        Me.btnCommands16.Name = "btnCommands16"
        Me.btnCommands16.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands16.TabIndex = 9
        Me.btnCommands16.Text = "Change Skills"
        Me.btnCommands16.UseVisualStyleBackColor = True
        '
        'btnCommands15
        '
        Me.btnCommands15.Location = New System.Drawing.Point(12, 133)
        Me.btnCommands15.Name = "btnCommands15"
        Me.btnCommands15.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands15.TabIndex = 8
        Me.btnCommands15.Text = "Change Level"
        Me.btnCommands15.UseVisualStyleBackColor = True
        '
        'btnCommands14
        '
        Me.btnCommands14.Enabled = False
        Me.btnCommands14.Location = New System.Drawing.Point(12, 104)
        Me.btnCommands14.Name = "btnCommands14"
        Me.btnCommands14.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands14.TabIndex = 7
        Me.btnCommands14.Text = "Level Up"
        Me.btnCommands14.UseVisualStyleBackColor = True
        '
        'btnCommands13
        '
        Me.btnCommands13.Location = New System.Drawing.Point(12, 75)
        Me.btnCommands13.Name = "btnCommands13"
        Me.btnCommands13.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands13.TabIndex = 6
        Me.btnCommands13.Text = "Restore MP"
        Me.btnCommands13.UseVisualStyleBackColor = True
        '
        'btnCommands12
        '
        Me.btnCommands12.Location = New System.Drawing.Point(12, 46)
        Me.btnCommands12.Name = "btnCommands12"
        Me.btnCommands12.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands12.TabIndex = 5
        Me.btnCommands12.Text = "Restore HP"
        Me.btnCommands12.UseVisualStyleBackColor = True
        '
        'btnCommands11
        '
        Me.btnCommands11.Location = New System.Drawing.Point(12, 19)
        Me.btnCommands11.Name = "btnCommands11"
        Me.btnCommands11.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands11.TabIndex = 4
        Me.btnCommands11.Text = "Change Items"
        Me.btnCommands11.UseVisualStyleBackColor = True
        '
        'fraRandom21
        '
        Me.fraRandom21.Controls.Add(Me.btnCommands3)
        Me.fraRandom21.Controls.Add(Me.btnCommands2)
        Me.fraRandom21.Controls.Add(Me.btnCommands1)
        Me.fraRandom21.Controls.Add(Me.btnCommands0)
        Me.fraRandom21.Location = New System.Drawing.Point(6, 6)
        Me.fraRandom21.Name = "fraRandom21"
        Me.fraRandom21.Size = New System.Drawing.Size(180, 133)
        Me.fraRandom21.TabIndex = 0
        Me.fraRandom21.TabStop = False
        Me.fraRandom21.Text = "Message"
        '
        'btnCommands3
        '
        Me.btnCommands3.Enabled = False
        Me.btnCommands3.Location = New System.Drawing.Point(6, 104)
        Me.btnCommands3.Name = "btnCommands3"
        Me.btnCommands3.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands3.TabIndex = 3
        Me.btnCommands3.Text = "Show ChatBubble"
        Me.btnCommands3.UseVisualStyleBackColor = True
        '
        'btnCommands2
        '
        Me.btnCommands2.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands2.Name = "btnCommands2"
        Me.btnCommands2.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands2.TabIndex = 2
        Me.btnCommands2.Text = "Add Chatbox Text"
        Me.btnCommands2.UseVisualStyleBackColor = True
        '
        'btnCommands1
        '
        Me.btnCommands1.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands1.Name = "btnCommands1"
        Me.btnCommands1.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands1.TabIndex = 1
        Me.btnCommands1.Text = "Show Choices"
        Me.btnCommands1.UseVisualStyleBackColor = True
        '
        'btnCommands0
        '
        Me.btnCommands0.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands0.Name = "btnCommands0"
        Me.btnCommands0.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands0.TabIndex = 0
        Me.btnCommands0.Text = "Show Text"
        Me.btnCommands0.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.fraRandom8)
        Me.TabPage2.Controls.Add(Me.frarandom7)
        Me.TabPage2.Controls.Add(Me.fraRandom12)
        Me.TabPage2.Controls.Add(Me.frarandom25)
        Me.TabPage2.Controls.Add(Me.fraRandom5)
        Me.TabPage2.Controls.Add(Me.fraRandom4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(385, 442)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'fraRandom8
        '
        Me.fraRandom8.Controls.Add(Me.btnCommands41)
        Me.fraRandom8.Controls.Add(Me.btnCommands40)
        Me.fraRandom8.Controls.Add(Me.btnCommands39)
        Me.fraRandom8.Location = New System.Drawing.Point(192, 262)
        Me.fraRandom8.Name = "fraRandom8"
        Me.fraRandom8.Size = New System.Drawing.Size(180, 110)
        Me.fraRandom8.TabIndex = 9
        Me.fraRandom8.TabStop = False
        Me.fraRandom8.Text = "Etc..."
        '
        'btnCommands41
        '
        Me.btnCommands41.Location = New System.Drawing.Point(6, 74)
        Me.btnCommands41.Name = "btnCommands41"
        Me.btnCommands41.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands41.TabIndex = 2
        Me.btnCommands41.Text = "Custom Script"
        Me.btnCommands41.UseVisualStyleBackColor = True
        '
        'btnCommands40
        '
        Me.btnCommands40.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands40.Name = "btnCommands40"
        Me.btnCommands40.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands40.TabIndex = 1
        Me.btnCommands40.Text = "Set Access"
        Me.btnCommands40.UseVisualStyleBackColor = True
        '
        'btnCommands39
        '
        Me.btnCommands39.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands39.Name = "btnCommands39"
        Me.btnCommands39.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands39.TabIndex = 0
        Me.btnCommands39.Text = "Wait..."
        Me.btnCommands39.UseVisualStyleBackColor = True
        '
        'frarandom7
        '
        Me.frarandom7.Controls.Add(Me.btnCommands38)
        Me.frarandom7.Controls.Add(Me.btnCommands37)
        Me.frarandom7.Controls.Add(Me.btnCommands36)
        Me.frarandom7.Controls.Add(Me.btnCommands35)
        Me.frarandom7.Location = New System.Drawing.Point(192, 122)
        Me.frarandom7.Name = "frarandom7"
        Me.frarandom7.Size = New System.Drawing.Size(180, 134)
        Me.frarandom7.TabIndex = 8
        Me.frarandom7.TabStop = False
        Me.frarandom7.Text = "Music and Sound"
        '
        'btnCommands38
        '
        Me.btnCommands38.Location = New System.Drawing.Point(6, 104)
        Me.btnCommands38.Name = "btnCommands38"
        Me.btnCommands38.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands38.TabIndex = 3
        Me.btnCommands38.Text = "Stop Sounds"
        Me.btnCommands38.UseVisualStyleBackColor = True
        '
        'btnCommands37
        '
        Me.btnCommands37.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands37.Name = "btnCommands37"
        Me.btnCommands37.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands37.TabIndex = 2
        Me.btnCommands37.Text = "Play Sound"
        Me.btnCommands37.UseVisualStyleBackColor = True
        '
        'btnCommands36
        '
        Me.btnCommands36.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands36.Name = "btnCommands36"
        Me.btnCommands36.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands36.TabIndex = 1
        Me.btnCommands36.Text = "Fadeout BGM"
        Me.btnCommands36.UseVisualStyleBackColor = True
        '
        'btnCommands35
        '
        Me.btnCommands35.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands35.Name = "btnCommands35"
        Me.btnCommands35.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands35.TabIndex = 0
        Me.btnCommands35.Text = "Play BGM"
        Me.btnCommands35.UseVisualStyleBackColor = True
        '
        'fraRandom12
        '
        Me.fraRandom12.Controls.Add(Me.btnCommands34)
        Me.fraRandom12.Controls.Add(Me.btnCommands33)
        Me.fraRandom12.Controls.Add(Me.btnCommands32)
        Me.fraRandom12.Location = New System.Drawing.Point(192, 6)
        Me.fraRandom12.Name = "fraRandom12"
        Me.fraRandom12.Size = New System.Drawing.Size(180, 110)
        Me.fraRandom12.TabIndex = 7
        Me.fraRandom12.TabStop = False
        Me.fraRandom12.Text = "Map Functions"
        '
        'btnCommands34
        '
        Me.btnCommands34.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands34.Name = "btnCommands34"
        Me.btnCommands34.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands34.TabIndex = 2
        Me.btnCommands34.Text = "Set Map Tinting"
        Me.btnCommands34.UseVisualStyleBackColor = True
        '
        'btnCommands33
        '
        Me.btnCommands33.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands33.Name = "btnCommands33"
        Me.btnCommands33.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands33.TabIndex = 1
        Me.btnCommands33.Text = "Set Weather"
        Me.btnCommands33.UseVisualStyleBackColor = True
        '
        'btnCommands32
        '
        Me.btnCommands32.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands32.Name = "btnCommands32"
        Me.btnCommands32.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands32.TabIndex = 0
        Me.btnCommands32.Text = "Set Fog"
        Me.btnCommands32.UseVisualStyleBackColor = True
        '
        'frarandom25
        '
        Me.frarandom25.Controls.Add(Me.btnCommands31)
        Me.frarandom25.Controls.Add(Me.btnCommands30)
        Me.frarandom25.Controls.Add(Me.btnCommands29)
        Me.frarandom25.Location = New System.Drawing.Point(6, 262)
        Me.frarandom25.Name = "frarandom25"
        Me.frarandom25.Size = New System.Drawing.Size(180, 110)
        Me.frarandom25.TabIndex = 6
        Me.frarandom25.TabStop = False
        Me.frarandom25.Text = "Questing"
        '
        'btnCommands31
        '
        Me.btnCommands31.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands31.Name = "btnCommands31"
        Me.btnCommands31.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands31.TabIndex = 2
        Me.btnCommands31.Text = "End Quest"
        Me.btnCommands31.UseVisualStyleBackColor = True
        '
        'btnCommands30
        '
        Me.btnCommands30.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands30.Name = "btnCommands30"
        Me.btnCommands30.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands30.TabIndex = 1
        Me.btnCommands30.Text = "Complete Give/Talk Task"
        Me.btnCommands30.UseVisualStyleBackColor = True
        '
        'btnCommands29
        '
        Me.btnCommands29.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands29.Name = "btnCommands29"
        Me.btnCommands29.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands29.TabIndex = 0
        Me.btnCommands29.Text = "Begin Quest"
        Me.btnCommands29.UseVisualStyleBackColor = True
        '
        'fraRandom5
        '
        Me.fraRandom5.Controls.Add(Me.btnCommands28)
        Me.fraRandom5.Location = New System.Drawing.Point(6, 206)
        Me.fraRandom5.Name = "fraRandom5"
        Me.fraRandom5.Size = New System.Drawing.Size(180, 50)
        Me.fraRandom5.TabIndex = 5
        Me.fraRandom5.TabStop = False
        Me.fraRandom5.Text = "Animation"
        '
        'btnCommands28
        '
        Me.btnCommands28.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands28.Name = "btnCommands28"
        Me.btnCommands28.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands28.TabIndex = 0
        Me.btnCommands28.Text = "Play Animation"
        Me.btnCommands28.UseVisualStyleBackColor = True
        '
        'fraRandom4
        '
        Me.fraRandom4.Controls.Add(Me.btnCommands27)
        Me.fraRandom4.Controls.Add(Me.btnCommands26)
        Me.fraRandom4.Controls.Add(Me.btnCommands25)
        Me.fraRandom4.Controls.Add(Me.btnCommands24)
        Me.fraRandom4.Controls.Add(Me.btnCommands23)
        Me.fraRandom4.Controls.Add(Me.btnCommands22)
        Me.fraRandom4.Location = New System.Drawing.Point(6, 6)
        Me.fraRandom4.Name = "fraRandom4"
        Me.fraRandom4.Size = New System.Drawing.Size(180, 194)
        Me.fraRandom4.TabIndex = 4
        Me.fraRandom4.TabStop = False
        Me.fraRandom4.Text = "Movement"
        '
        'btnCommands27
        '
        Me.btnCommands27.Location = New System.Drawing.Point(6, 162)
        Me.btnCommands27.Name = "btnCommands27"
        Me.btnCommands27.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands27.TabIndex = 5
        Me.btnCommands27.Text = "Release Player"
        Me.btnCommands27.UseVisualStyleBackColor = True
        '
        'btnCommands26
        '
        Me.btnCommands26.Location = New System.Drawing.Point(6, 133)
        Me.btnCommands26.Name = "btnCommands26"
        Me.btnCommands26.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands26.TabIndex = 4
        Me.btnCommands26.Text = "Hold Player"
        Me.btnCommands26.UseVisualStyleBackColor = True
        '
        'btnCommands25
        '
        Me.btnCommands25.Location = New System.Drawing.Point(6, 104)
        Me.btnCommands25.Name = "btnCommands25"
        Me.btnCommands25.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands25.TabIndex = 3
        Me.btnCommands25.Text = "Force Spawn NPC"
        Me.btnCommands25.UseVisualStyleBackColor = True
        '
        'btnCommands24
        '
        Me.btnCommands24.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands24.Name = "btnCommands24"
        Me.btnCommands24.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands24.TabIndex = 2
        Me.btnCommands24.Text = "Wait for Route Completion"
        Me.btnCommands24.UseVisualStyleBackColor = True
        '
        'btnCommands23
        '
        Me.btnCommands23.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands23.Name = "btnCommands23"
        Me.btnCommands23.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands23.TabIndex = 1
        Me.btnCommands23.Text = "Set Move Route"
        Me.btnCommands23.UseVisualStyleBackColor = True
        '
        'btnCommands22
        '
        Me.btnCommands22.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands22.Name = "btnCommands22"
        Me.btnCommands22.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands22.TabIndex = 0
        Me.btnCommands22.Text = "Warp Player"
        Me.btnCommands22.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.fraRandom6)
        Me.TabPage3.Controls.Add(Me.fraRandom11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(385, 442)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'fraRandom6
        '
        Me.fraRandom6.Controls.Add(Me.btnCommands49)
        Me.fraRandom6.Controls.Add(Me.btnCommands48)
        Me.fraRandom6.Controls.Add(Me.btnCommands47)
        Me.fraRandom6.Location = New System.Drawing.Point(6, 182)
        Me.fraRandom6.Name = "fraRandom6"
        Me.fraRandom6.Size = New System.Drawing.Size(176, 110)
        Me.fraRandom6.TabIndex = 1
        Me.fraRandom6.TabStop = False
        Me.fraRandom6.Text = "Shop and Bank"
        '
        'btnCommands49
        '
        Me.btnCommands49.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands49.Name = "btnCommands49"
        Me.btnCommands49.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands49.TabIndex = 10
        Me.btnCommands49.Text = "Open Mailbox"
        Me.btnCommands49.UseVisualStyleBackColor = True
        '
        'btnCommands48
        '
        Me.btnCommands48.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands48.Name = "btnCommands48"
        Me.btnCommands48.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands48.TabIndex = 9
        Me.btnCommands48.Text = "Open Shop"
        Me.btnCommands48.UseVisualStyleBackColor = True
        '
        'btnCommands47
        '
        Me.btnCommands47.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands47.Name = "btnCommands47"
        Me.btnCommands47.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands47.TabIndex = 8
        Me.btnCommands47.Text = "Open Bank"
        Me.btnCommands47.UseVisualStyleBackColor = True
        '
        'fraRandom11
        '
        Me.fraRandom11.Controls.Add(Me.btnCommands46)
        Me.fraRandom11.Controls.Add(Me.btnCommands45)
        Me.fraRandom11.Controls.Add(Me.btnCommands44)
        Me.fraRandom11.Controls.Add(Me.btnCommands43)
        Me.fraRandom11.Controls.Add(Me.btnCommands42)
        Me.fraRandom11.Location = New System.Drawing.Point(6, 8)
        Me.fraRandom11.Name = "fraRandom11"
        Me.fraRandom11.Size = New System.Drawing.Size(176, 168)
        Me.fraRandom11.TabIndex = 0
        Me.fraRandom11.TabStop = False
        Me.fraRandom11.Text = "Cut-Scene Options"
        '
        'btnCommands46
        '
        Me.btnCommands46.Location = New System.Drawing.Point(6, 133)
        Me.btnCommands46.Name = "btnCommands46"
        Me.btnCommands46.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands46.TabIndex = 9
        Me.btnCommands46.Text = "Hide Picture"
        Me.btnCommands46.UseVisualStyleBackColor = True
        '
        'btnCommands45
        '
        Me.btnCommands45.Location = New System.Drawing.Point(6, 104)
        Me.btnCommands45.Name = "btnCommands45"
        Me.btnCommands45.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands45.TabIndex = 8
        Me.btnCommands45.Text = "Show Picture"
        Me.btnCommands45.UseVisualStyleBackColor = True
        '
        'btnCommands44
        '
        Me.btnCommands44.Location = New System.Drawing.Point(6, 75)
        Me.btnCommands44.Name = "btnCommands44"
        Me.btnCommands44.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands44.TabIndex = 7
        Me.btnCommands44.Text = "Flash White"
        Me.btnCommands44.UseVisualStyleBackColor = True
        '
        'btnCommands43
        '
        Me.btnCommands43.Location = New System.Drawing.Point(6, 46)
        Me.btnCommands43.Name = "btnCommands43"
        Me.btnCommands43.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands43.TabIndex = 6
        Me.btnCommands43.Text = "Fade Out"
        Me.btnCommands43.UseVisualStyleBackColor = True
        '
        'btnCommands42
        '
        Me.btnCommands42.Location = New System.Drawing.Point(6, 19)
        Me.btnCommands42.Name = "btnCommands42"
        Me.btnCommands42.Size = New System.Drawing.Size(165, 23)
        Me.btnCommands42.TabIndex = 5
        Me.btnCommands42.Text = "Fade In"
        Me.btnCommands42.UseVisualStyleBackColor = True
        '
        'fraRandom17
        '
        Me.fraRandom17.Controls.Add(Me.chkGlobal)
        Me.fraRandom17.Location = New System.Drawing.Point(183, 398)
        Me.fraRandom17.Name = "fraRandom17"
        Me.fraRandom17.Size = New System.Drawing.Size(217, 40)
        Me.fraRandom17.TabIndex = 6
        Me.fraRandom17.TabStop = False
        Me.fraRandom17.Text = "Global?"
        '
        'chkGlobal
        '
        Me.chkGlobal.AutoSize = True
        Me.chkGlobal.Location = New System.Drawing.Point(9, 19)
        Me.chkGlobal.Name = "chkGlobal"
        Me.chkGlobal.Size = New System.Drawing.Size(67, 17)
        Me.chkGlobal.TabIndex = 4
        Me.chkGlobal.Text = "Global **"
        Me.chkGlobal.UseVisualStyleBackColor = True
        '
        'fraRandom16
        '
        Me.fraRandom16.Controls.Add(Me.chkShowName)
        Me.fraRandom16.Controls.Add(Me.chkWalkThrough)
        Me.fraRandom16.Controls.Add(Me.chkDirFix)
        Me.fraRandom16.Controls.Add(Me.chkWalkAnim)
        Me.fraRandom16.Location = New System.Drawing.Point(4, 386)
        Me.fraRandom16.Name = "fraRandom16"
        Me.fraRandom16.Size = New System.Drawing.Size(173, 107)
        Me.fraRandom16.TabIndex = 5
        Me.fraRandom16.TabStop = False
        Me.fraRandom16.Text = "Options"
        '
        'chkShowName
        '
        Me.chkShowName.AutoSize = True
        Me.chkShowName.Location = New System.Drawing.Point(6, 86)
        Me.chkShowName.Name = "chkShowName"
        Me.chkShowName.Size = New System.Drawing.Size(84, 17)
        Me.chkShowName.TabIndex = 6
        Me.chkShowName.Text = "Show Name"
        Me.chkShowName.UseVisualStyleBackColor = True
        '
        'chkWalkThrough
        '
        Me.chkWalkThrough.AutoSize = True
        Me.chkWalkThrough.Location = New System.Drawing.Point(6, 63)
        Me.chkWalkThrough.Name = "chkWalkThrough"
        Me.chkWalkThrough.Size = New System.Drawing.Size(94, 17)
        Me.chkWalkThrough.TabIndex = 5
        Me.chkWalkThrough.Text = "Walk Through"
        Me.chkWalkThrough.UseVisualStyleBackColor = True
        '
        'chkDirFix
        '
        Me.chkDirFix.AutoSize = True
        Me.chkDirFix.Location = New System.Drawing.Point(6, 40)
        Me.chkDirFix.Name = "chkDirFix"
        Me.chkDirFix.Size = New System.Drawing.Size(84, 17)
        Me.chkDirFix.TabIndex = 4
        Me.chkDirFix.Text = "Direction Fix"
        Me.chkDirFix.UseVisualStyleBackColor = True
        '
        'chkWalkAnim
        '
        Me.chkWalkAnim.AutoSize = True
        Me.chkWalkAnim.Location = New System.Drawing.Point(6, 17)
        Me.chkWalkAnim.Name = "chkWalkAnim"
        Me.chkWalkAnim.Size = New System.Drawing.Size(111, 17)
        Me.chkWalkAnim.TabIndex = 3
        Me.chkWalkAnim.Text = "No Walking Anim."
        Me.chkWalkAnim.UseVisualStyleBackColor = True
        '
        'fraRandom18
        '
        Me.fraRandom18.Controls.Add(Me.cmbTrigger)
        Me.fraRandom18.Location = New System.Drawing.Point(183, 343)
        Me.fraRandom18.Name = "fraRandom18"
        Me.fraRandom18.Size = New System.Drawing.Size(217, 49)
        Me.fraRandom18.TabIndex = 4
        Me.fraRandom18.TabStop = False
        Me.fraRandom18.Text = "Trigger"
        '
        'cmbTrigger
        '
        Me.cmbTrigger.FormattingEnabled = True
        Me.cmbTrigger.Items.AddRange(New Object() {"Action Button", "Player Touch", "Parallel Process"})
        Me.cmbTrigger.Location = New System.Drawing.Point(6, 19)
        Me.cmbTrigger.Name = "cmbTrigger"
        Me.cmbTrigger.Size = New System.Drawing.Size(205, 21)
        Me.cmbTrigger.TabIndex = 16
        '
        'fraRandom19
        '
        Me.fraRandom19.Controls.Add(Me.cmbPositioning)
        Me.fraRandom19.Location = New System.Drawing.Point(183, 288)
        Me.fraRandom19.Name = "fraRandom19"
        Me.fraRandom19.Size = New System.Drawing.Size(217, 49)
        Me.fraRandom19.TabIndex = 3
        Me.fraRandom19.TabStop = False
        Me.fraRandom19.Text = "Positioning"
        '
        'cmbPositioning
        '
        Me.cmbPositioning.FormattingEnabled = True
        Me.cmbPositioning.Items.AddRange(New Object() {"Below Characters", "Same as Characters", "Above Characters"})
        Me.cmbPositioning.Location = New System.Drawing.Point(6, 19)
        Me.cmbPositioning.Name = "cmbPositioning"
        Me.cmbPositioning.Size = New System.Drawing.Size(205, 21)
        Me.cmbPositioning.TabIndex = 16
        '
        'fraRandom15
        '
        Me.fraRandom15.Controls.Add(Me.cmbMoveFreq)
        Me.fraRandom15.Controls.Add(Me.cmbMoveSpeed)
        Me.fraRandom15.Controls.Add(Me.btnMoveRoute)
        Me.fraRandom15.Controls.Add(Me.cmbMoveType)
        Me.fraRandom15.Controls.Add(Me.lblRandomLabel8)
        Me.fraRandom15.Controls.Add(Me.lblRandomLabel7)
        Me.fraRandom15.Controls.Add(Me.lblRandomLabel6)
        Me.fraRandom15.Location = New System.Drawing.Point(183, 151)
        Me.fraRandom15.Name = "fraRandom15"
        Me.fraRandom15.Size = New System.Drawing.Size(217, 133)
        Me.fraRandom15.TabIndex = 2
        Me.fraRandom15.TabStop = False
        Me.fraRandom15.Text = "Movement"
        '
        'cmbMoveFreq
        '
        Me.cmbMoveFreq.FormattingEnabled = True
        Me.cmbMoveFreq.Items.AddRange(New Object() {"Lowest", "Lower", "Normal", "Higher", "Highest"})
        Me.cmbMoveFreq.Location = New System.Drawing.Point(55, 100)
        Me.cmbMoveFreq.Name = "cmbMoveFreq"
        Me.cmbMoveFreq.Size = New System.Drawing.Size(156, 21)
        Me.cmbMoveFreq.TabIndex = 18
        '
        'cmbMoveSpeed
        '
        Me.cmbMoveSpeed.FormattingEnabled = True
        Me.cmbMoveSpeed.Items.AddRange(New Object() {"8x Slower", "4x Slower", "2x Slower", "Normal", "2x Faster", "4x Faster"})
        Me.cmbMoveSpeed.Location = New System.Drawing.Point(55, 73)
        Me.cmbMoveSpeed.Name = "cmbMoveSpeed"
        Me.cmbMoveSpeed.Size = New System.Drawing.Size(156, 21)
        Me.cmbMoveSpeed.TabIndex = 17
        '
        'btnMoveRoute
        '
        Me.btnMoveRoute.Location = New System.Drawing.Point(136, 44)
        Me.btnMoveRoute.Name = "btnMoveRoute"
        Me.btnMoveRoute.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveRoute.TabIndex = 16
        Me.btnMoveRoute.Text = "Move Route"
        Me.btnMoveRoute.UseVisualStyleBackColor = True
        '
        'cmbMoveType
        '
        Me.cmbMoveType.FormattingEnabled = True
        Me.cmbMoveType.Items.AddRange(New Object() {"Fixed Position", "Random", "Move Route"})
        Me.cmbMoveType.Location = New System.Drawing.Point(55, 17)
        Me.cmbMoveType.Name = "cmbMoveType"
        Me.cmbMoveType.Size = New System.Drawing.Size(156, 21)
        Me.cmbMoveType.TabIndex = 15
        '
        'lblRandomLabel8
        '
        Me.lblRandomLabel8.AutoSize = True
        Me.lblRandomLabel8.Location = New System.Drawing.Point(6, 103)
        Me.lblRandomLabel8.Name = "lblRandomLabel8"
        Me.lblRandomLabel8.Size = New System.Drawing.Size(31, 13)
        Me.lblRandomLabel8.TabIndex = 2
        Me.lblRandomLabel8.Text = "Freq:"
        '
        'lblRandomLabel7
        '
        Me.lblRandomLabel7.AutoSize = True
        Me.lblRandomLabel7.Location = New System.Drawing.Point(6, 76)
        Me.lblRandomLabel7.Name = "lblRandomLabel7"
        Me.lblRandomLabel7.Size = New System.Drawing.Size(41, 13)
        Me.lblRandomLabel7.TabIndex = 1
        Me.lblRandomLabel7.Text = "Speed:"
        '
        'lblRandomLabel6
        '
        Me.lblRandomLabel6.AutoSize = True
        Me.lblRandomLabel6.Location = New System.Drawing.Point(6, 20)
        Me.lblRandomLabel6.Name = "lblRandomLabel6"
        Me.lblRandomLabel6.Size = New System.Drawing.Size(34, 13)
        Me.lblRandomLabel6.TabIndex = 0
        Me.lblRandomLabel6.Text = "Type:"
        '
        'frarandom13
        '
        Me.frarandom13.Controls.Add(Me.picGraphic)
        Me.frarandom13.Location = New System.Drawing.Point(4, 151)
        Me.frarandom13.Name = "frarandom13"
        Me.frarandom13.Size = New System.Drawing.Size(173, 231)
        Me.frarandom13.TabIndex = 1
        Me.frarandom13.TabStop = False
        Me.frarandom13.Text = "Graphic"
        '
        'picGraphic
        '
        Me.picGraphic.Location = New System.Drawing.Point(25, 19)
        Me.picGraphic.Name = "picGraphic"
        Me.picGraphic.Size = New System.Drawing.Size(121, 193)
        Me.picGraphic.TabIndex = 0
        Me.picGraphic.TabStop = False
        '
        'fraRandom0
        '
        Me.fraRandom0.Controls.Add(Me.cmbSelfSwitchCompare)
        Me.fraRandom0.Controls.Add(Me.cmbPlayerSwitchCompare)
        Me.fraRandom0.Controls.Add(Me.txtPlayerVariable)
        Me.fraRandom0.Controls.Add(Me.cmbPlayervarCompare)
        Me.fraRandom0.Controls.Add(Me.lblRandomlabel4)
        Me.fraRandom0.Controls.Add(Me.lblRandomlabel3)
        Me.fraRandom0.Controls.Add(Me.lblRandomLabel5)
        Me.fraRandom0.Controls.Add(Me.cmbSelfSwitch)
        Me.fraRandom0.Controls.Add(Me.cmbHasItem)
        Me.fraRandom0.Controls.Add(Me.cmbPlayerSwitch)
        Me.fraRandom0.Controls.Add(Me.cmbPlayerVar)
        Me.fraRandom0.Controls.Add(Me.chkSelfSwitch)
        Me.fraRandom0.Controls.Add(Me.chkHasItem)
        Me.fraRandom0.Controls.Add(Me.chkPlayerSwitch)
        Me.fraRandom0.Controls.Add(Me.chkPlayerVar)
        Me.fraRandom0.Location = New System.Drawing.Point(4, 6)
        Me.fraRandom0.Name = "fraRandom0"
        Me.fraRandom0.Size = New System.Drawing.Size(396, 142)
        Me.fraRandom0.TabIndex = 0
        Me.fraRandom0.TabStop = False
        Me.fraRandom0.Text = "Conditions"
        '
        'cmbSelfSwitchCompare
        '
        Me.cmbSelfSwitchCompare.FormattingEnabled = True
        Me.cmbSelfSwitchCompare.Items.AddRange(New Object() {"True", "False"})
        Me.cmbSelfSwitchCompare.Location = New System.Drawing.Point(234, 110)
        Me.cmbSelfSwitchCompare.Name = "cmbSelfSwitchCompare"
        Me.cmbSelfSwitchCompare.Size = New System.Drawing.Size(100, 21)
        Me.cmbSelfSwitchCompare.TabIndex = 14
        '
        'cmbPlayerSwitchCompare
        '
        Me.cmbPlayerSwitchCompare.FormattingEnabled = True
        Me.cmbPlayerSwitchCompare.Items.AddRange(New Object() {"True", "False"})
        Me.cmbPlayerSwitchCompare.Location = New System.Drawing.Point(234, 48)
        Me.cmbPlayerSwitchCompare.Name = "cmbPlayerSwitchCompare"
        Me.cmbPlayerSwitchCompare.Size = New System.Drawing.Size(100, 21)
        Me.cmbPlayerSwitchCompare.TabIndex = 13
        '
        'txtPlayerVariable
        '
        Me.txtPlayerVariable.Location = New System.Drawing.Point(340, 17)
        Me.txtPlayerVariable.Name = "txtPlayerVariable"
        Me.txtPlayerVariable.Size = New System.Drawing.Size(48, 20)
        Me.txtPlayerVariable.TabIndex = 12
        '
        'cmbPlayervarCompare
        '
        Me.cmbPlayervarCompare.FormattingEnabled = True
        Me.cmbPlayervarCompare.Items.AddRange(New Object() {"Equal To", "Great Than Or Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"})
        Me.cmbPlayervarCompare.Location = New System.Drawing.Point(234, 17)
        Me.cmbPlayervarCompare.Name = "cmbPlayervarCompare"
        Me.cmbPlayervarCompare.Size = New System.Drawing.Size(100, 21)
        Me.cmbPlayervarCompare.TabIndex = 11
        '
        'lblRandomlabel4
        '
        Me.lblRandomlabel4.AutoSize = True
        Me.lblRandomlabel4.Location = New System.Drawing.Point(214, 113)
        Me.lblRandomlabel4.Name = "lblRandomlabel4"
        Me.lblRandomlabel4.Size = New System.Drawing.Size(14, 13)
        Me.lblRandomlabel4.TabIndex = 10
        Me.lblRandomlabel4.Text = "is"
        '
        'lblRandomlabel3
        '
        Me.lblRandomlabel3.AutoSize = True
        Me.lblRandomlabel3.Location = New System.Drawing.Point(214, 51)
        Me.lblRandomlabel3.Name = "lblRandomlabel3"
        Me.lblRandomlabel3.Size = New System.Drawing.Size(14, 13)
        Me.lblRandomlabel3.TabIndex = 9
        Me.lblRandomlabel3.Text = "is"
        '
        'lblRandomLabel5
        '
        Me.lblRandomLabel5.AutoSize = True
        Me.lblRandomLabel5.Location = New System.Drawing.Point(214, 20)
        Me.lblRandomLabel5.Name = "lblRandomLabel5"
        Me.lblRandomLabel5.Size = New System.Drawing.Size(14, 13)
        Me.lblRandomLabel5.TabIndex = 8
        Me.lblRandomLabel5.Text = "is"
        '
        'cmbSelfSwitch
        '
        Me.cmbSelfSwitch.FormattingEnabled = True
        Me.cmbSelfSwitch.Items.AddRange(New Object() {"None", "1 - A", "2 - B", "3 - C", "4 - D"})
        Me.cmbSelfSwitch.Location = New System.Drawing.Point(108, 110)
        Me.cmbSelfSwitch.Name = "cmbSelfSwitch"
        Me.cmbSelfSwitch.Size = New System.Drawing.Size(100, 21)
        Me.cmbSelfSwitch.TabIndex = 7
        '
        'cmbHasItem
        '
        Me.cmbHasItem.FormattingEnabled = True
        Me.cmbHasItem.Location = New System.Drawing.Point(108, 79)
        Me.cmbHasItem.Name = "cmbHasItem"
        Me.cmbHasItem.Size = New System.Drawing.Size(100, 21)
        Me.cmbHasItem.TabIndex = 6
        '
        'cmbPlayerSwitch
        '
        Me.cmbPlayerSwitch.FormattingEnabled = True
        Me.cmbPlayerSwitch.Location = New System.Drawing.Point(108, 48)
        Me.cmbPlayerSwitch.Name = "cmbPlayerSwitch"
        Me.cmbPlayerSwitch.Size = New System.Drawing.Size(100, 21)
        Me.cmbPlayerSwitch.TabIndex = 5
        '
        'cmbPlayerVar
        '
        Me.cmbPlayerVar.FormattingEnabled = True
        Me.cmbPlayerVar.Location = New System.Drawing.Point(108, 17)
        Me.cmbPlayerVar.Name = "cmbPlayerVar"
        Me.cmbPlayerVar.Size = New System.Drawing.Size(100, 21)
        Me.cmbPlayerVar.TabIndex = 4
        '
        'chkSelfSwitch
        '
        Me.chkSelfSwitch.AutoSize = True
        Me.chkSelfSwitch.Location = New System.Drawing.Point(6, 112)
        Me.chkSelfSwitch.Name = "chkSelfSwitch"
        Me.chkSelfSwitch.Size = New System.Drawing.Size(83, 17)
        Me.chkSelfSwitch.TabIndex = 3
        Me.chkSelfSwitch.Text = "Self Switch*"
        Me.chkSelfSwitch.UseVisualStyleBackColor = True
        '
        'chkHasItem
        '
        Me.chkHasItem.AutoSize = True
        Me.chkHasItem.Location = New System.Drawing.Point(6, 81)
        Me.chkHasItem.Name = "chkHasItem"
        Me.chkHasItem.Size = New System.Drawing.Size(68, 17)
        Me.chkHasItem.TabIndex = 2
        Me.chkHasItem.Text = "Has Item"
        Me.chkHasItem.UseVisualStyleBackColor = True
        '
        'chkPlayerSwitch
        '
        Me.chkPlayerSwitch.AutoSize = True
        Me.chkPlayerSwitch.Location = New System.Drawing.Point(6, 50)
        Me.chkPlayerSwitch.Name = "chkPlayerSwitch"
        Me.chkPlayerSwitch.Size = New System.Drawing.Size(90, 17)
        Me.chkPlayerSwitch.TabIndex = 1
        Me.chkPlayerSwitch.Text = "Player Switch"
        Me.chkPlayerSwitch.UseVisualStyleBackColor = True
        '
        'chkPlayerVar
        '
        Me.chkPlayerVar.AutoSize = True
        Me.chkPlayerVar.Location = New System.Drawing.Point(6, 19)
        Me.chkPlayerVar.Name = "chkPlayerVar"
        Me.chkPlayerVar.Size = New System.Drawing.Size(96, 17)
        Me.chkPlayerVar.TabIndex = 0
        Me.chkPlayerVar.Text = "Player Variable"
        Me.chkPlayerVar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.fraCommands)
        Me.Panel2.Controls.Add(Me.fraRandom9)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.fraRandom17)
        Me.Panel2.Controls.Add(Me.fraRandom0)
        Me.Panel2.Controls.Add(Me.fraRandom16)
        Me.Panel2.Controls.Add(Me.frarandom13)
        Me.Panel2.Controls.Add(Me.fraRandom18)
        Me.Panel2.Controls.Add(Me.fraRandom15)
        Me.Panel2.Controls.Add(Me.fraRandom19)
        Me.Panel2.Controls.Add(Me.lstCommands)
        Me.Panel2.Location = New System.Drawing.Point(12, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(818, 516)
        Me.Panel2.TabIndex = 9
        '
        'fraRandom9
        '
        Me.fraRandom9.Controls.Add(Me.btnClearCommand)
        Me.fraRandom9.Controls.Add(Me.btnDeleteComand)
        Me.fraRandom9.Controls.Add(Me.btnEditCommand)
        Me.fraRandom9.Controls.Add(Me.btnAddCommand)
        Me.fraRandom9.Location = New System.Drawing.Point(413, 446)
        Me.fraRandom9.Name = "fraRandom9"
        Me.fraRandom9.Size = New System.Drawing.Size(396, 55)
        Me.fraRandom9.TabIndex = 15
        Me.fraRandom9.TabStop = False
        Me.fraRandom9.Text = "Commands"
        '
        'btnClearCommand
        '
        Me.btnClearCommand.Location = New System.Drawing.Point(315, 19)
        Me.btnClearCommand.Name = "btnClearCommand"
        Me.btnClearCommand.Size = New System.Drawing.Size(75, 23)
        Me.btnClearCommand.TabIndex = 3
        Me.btnClearCommand.Text = "Clear"
        Me.btnClearCommand.UseVisualStyleBackColor = True
        '
        'btnDeleteComand
        '
        Me.btnDeleteComand.Location = New System.Drawing.Point(212, 19)
        Me.btnDeleteComand.Name = "btnDeleteComand"
        Me.btnDeleteComand.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteComand.TabIndex = 2
        Me.btnDeleteComand.Text = "Delete"
        Me.btnDeleteComand.UseVisualStyleBackColor = True
        '
        'btnEditCommand
        '
        Me.btnEditCommand.Location = New System.Drawing.Point(109, 19)
        Me.btnEditCommand.Name = "btnEditCommand"
        Me.btnEditCommand.Size = New System.Drawing.Size(75, 23)
        Me.btnEditCommand.TabIndex = 1
        Me.btnEditCommand.Text = "Edit"
        Me.btnEditCommand.UseVisualStyleBackColor = True
        '
        'btnAddCommand
        '
        Me.btnAddCommand.Location = New System.Drawing.Point(6, 19)
        Me.btnAddCommand.Name = "btnAddCommand"
        Me.btnAddCommand.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCommand.TabIndex = 0
        Me.btnAddCommand.Text = "Add"
        Me.btnAddCommand.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmbEventQuest)
        Me.GroupBox2.Location = New System.Drawing.Point(180, 444)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 49)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quest Icon?"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Quest Num:"
        '
        'cmbEventQuest
        '
        Me.cmbEventQuest.FormattingEnabled = True
        Me.cmbEventQuest.Items.AddRange(New Object() {"Action Button", "Player Touch", "Parallel Process"})
        Me.cmbEventQuest.Location = New System.Drawing.Point(82, 19)
        Me.cmbEventQuest.Name = "cmbEventQuest"
        Me.cmbEventQuest.Size = New System.Drawing.Size(129, 21)
        Me.cmbEventQuest.TabIndex = 16
        '
        'lstCommands
        '
        Me.lstCommands.FormattingEnabled = True
        Me.lstCommands.Location = New System.Drawing.Point(416, 7)
        Me.lstCommands.Name = "lstCommands"
        Me.lstCommands.Size = New System.Drawing.Size(394, 433)
        Me.lstCommands.TabIndex = 13
        '
        'frmEditor_Events
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2033, 644)
        Me.Controls.Add(Me.tabCommands)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblRandomLabel14)
        Me.Controls.Add(Me.lblRandomLabel11)
        Me.Controls.Add(Me.fraGraphic)
        Me.Controls.Add(Me.fraDialogue)
        Me.Controls.Add(Me.btnLabeling)
        Me.Controls.Add(Me.frarandom20)
        Me.Controls.Add(Me.tabPages)
        Me.Controls.Add(Me.pnlMoveRoute)
        Me.Controls.Add(Me.pnlVariableSwitches)
        Me.Name = "frmEditor_Events"
        Me.Text = "Event Editor"
        Me.pnlVariableSwitches.ResumeLayout(False)
        Me.fraLabeling.ResumeLayout(False)
        Me.fraLabeling.PerformLayout()
        Me.FraRenaming.ResumeLayout(False)
        Me.fraRandom10.ResumeLayout(False)
        Me.fraRandom10.PerformLayout()
        Me.fraGraphic.ResumeLayout(False)
        Me.fraGraphic.PerformLayout()
        CType(Me.picGraphicSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMoveRoute.ResumeLayout(False)
        Me.fraMoveRoute.ResumeLayout(False)
        Me.fraMoveRoute.PerformLayout()
        Me.fraRandom14.ResumeLayout(False)
        Me.tabPages.ResumeLayout(False)
        Me.frarandom20.ResumeLayout(False)
        Me.frarandom20.PerformLayout()
        Me.fraDialogue.ResumeLayout(False)
        Me.fraCommand7.ResumeLayout(False)
        Me.fraCommand7.PerformLayout()
        Me.fraConditions_Quest.ResumeLayout(False)
        Me.fraConditions_Quest.PerformLayout()
        Me.fraCommand27.ResumeLayout(False)
        Me.fraCommand27.PerformLayout()
        Me.fraCommand23.ResumeLayout(False)
        Me.fraCommand23.PerformLayout()
        Me.fraCommand18.ResumeLayout(False)
        Me.fraCommand18.PerformLayout()
        Me.fraCommand34.ResumeLayout(False)
        Me.fraCommand34.PerformLayout()
        Me.fraCommand35.ResumeLayout(False)
        Me.fraCommand35.PerformLayout()
        Me.fraCommand20.ResumeLayout(False)
        Me.fraCommand20.PerformLayout()
        Me.fraCommand29.ResumeLayout(False)
        Me.fraCommand29.PerformLayout()
        Me.fraCommand31.ResumeLayout(False)
        Me.fraCommand31.PerformLayout()
        Me.fraCommand30.ResumeLayout(False)
        Me.fraCommand30.PerformLayout()
        Me.fraCommand28.ResumeLayout(False)
        Me.fraCommand25.ResumeLayout(False)
        Me.fraCommand24.ResumeLayout(False)
        Me.fraCommand24.PerformLayout()
        Me.fraCommand22.ResumeLayout(False)
        Me.fraCommand22.PerformLayout()
        Me.fraCommand26.ResumeLayout(False)
        Me.fraCommand21.ResumeLayout(False)
        Me.fraCommand19.ResumeLayout(False)
        Me.fraCommand19.PerformLayout()
        Me.fraCommand3.ResumeLayout(False)
        Me.fraCommand3.PerformLayout()
        Me.fraCommand2.ResumeLayout(False)
        Me.fraCommand2.PerformLayout()
        Me.fraCommand33.ResumeLayout(False)
        Me.fraCommand33.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCommand1.ResumeLayout(False)
        Me.fraCommand1.PerformLayout()
        CType(Me.picShowChoicesFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCommand0.ResumeLayout(False)
        Me.fraCommand0.PerformLayout()
        CType(Me.picShowTextFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCommand17.ResumeLayout(False)
        Me.fraCommand17.PerformLayout()
        Me.fraCommand16.ResumeLayout(False)
        Me.fraCommand16.PerformLayout()
        Me.fraCommand15.ResumeLayout(False)
        Me.fraCommand15.PerformLayout()
        Me.fraCommand14.ResumeLayout(False)
        Me.fraCommand14.PerformLayout()
        Me.fraCommand13.ResumeLayout(False)
        Me.fraCommand13.PerformLayout()
        Me.fraCommand12.ResumeLayout(False)
        Me.fraCommand12.PerformLayout()
        Me.fraCommand11.ResumeLayout(False)
        Me.fraCommand11.PerformLayout()
        Me.fraCommand10.ResumeLayout(False)
        Me.fraCommand10.PerformLayout()
        Me.fraCommand6.ResumeLayout(False)
        Me.fraCommand6.PerformLayout()
        Me.fraCommand5.ResumeLayout(False)
        Me.fraCommand5.PerformLayout()
        Me.fraCommand9.ResumeLayout(False)
        Me.fraCommand9.PerformLayout()
        Me.fraCommand8.ResumeLayout(False)
        Me.fraCommand8.PerformLayout()
        Me.fraCommand32.ResumeLayout(False)
        Me.fraCommand32.PerformLayout()
        Me.fraCommand4.ResumeLayout(False)
        Me.fraCommand4.PerformLayout()
        Me.fraCommands.ResumeLayout(False)
        Me.tabCommands.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.fraRandom2.ResumeLayout(False)
        Me.fraRandom1.ResumeLayout(False)
        Me.fraRandom3.ResumeLayout(False)
        Me.fraRandom21.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.fraRandom8.ResumeLayout(False)
        Me.frarandom7.ResumeLayout(False)
        Me.fraRandom12.ResumeLayout(False)
        Me.frarandom25.ResumeLayout(False)
        Me.fraRandom5.ResumeLayout(False)
        Me.fraRandom4.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.fraRandom6.ResumeLayout(False)
        Me.fraRandom11.ResumeLayout(False)
        Me.fraRandom17.ResumeLayout(False)
        Me.fraRandom17.PerformLayout()
        Me.fraRandom16.ResumeLayout(False)
        Me.fraRandom16.PerformLayout()
        Me.fraRandom18.ResumeLayout(False)
        Me.fraRandom19.ResumeLayout(False)
        Me.fraRandom15.ResumeLayout(False)
        Me.fraRandom15.PerformLayout()
        Me.frarandom13.ResumeLayout(False)
        CType(Me.picGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraRandom0.ResumeLayout(False)
        Me.fraRandom0.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.fraRandom9.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlVariableSwitches As Windows.Forms.Panel
    Friend WithEvents fraGraphic As Windows.Forms.GroupBox
    Friend WithEvents btnGraphicCancel As Windows.Forms.Button
    Friend WithEvents btnGraphicOk As Windows.Forms.Button
    Friend WithEvents hScrlGraphicSel As Windows.Forms.HScrollBar
    Friend WithEvents vScrlGraphicSel As Windows.Forms.VScrollBar
    Friend WithEvents picGraphicSel As Windows.Forms.PictureBox
    Friend WithEvents lblGraphic As Windows.Forms.Label
    Friend WithEvents scrlGraphic As Windows.Forms.HScrollBar
    Friend WithEvents cmbGraphic As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel33 As Windows.Forms.Label
    Friend WithEvents fraLabeling As Windows.Forms.GroupBox
    Friend WithEvents btnLabel_Cancel As Windows.Forms.Button
    Friend WithEvents btnLabel_Ok As Windows.Forms.Button
    Friend WithEvents btnRenameSwitch As Windows.Forms.Button
    Friend WithEvents btnRenameVariable As Windows.Forms.Button
    Friend WithEvents lstSwitches As Windows.Forms.ListBox
    Friend WithEvents lstVariables As Windows.Forms.ListBox
    Friend WithEvents lblRandomLabel36 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel25 As Windows.Forms.Label
    Friend WithEvents FraRenaming As Windows.Forms.GroupBox
    Friend WithEvents btnRename_Cancel As Windows.Forms.Button
    Friend WithEvents btnRename_Ok As Windows.Forms.Button
    Friend WithEvents fraRandom10 As Windows.Forms.GroupBox
    Friend WithEvents txtRename As Windows.Forms.TextBox
    Friend WithEvents lblEditing As Windows.Forms.Label
    Friend WithEvents pnlMoveRoute As Windows.Forms.Panel
    Friend WithEvents fraMoveRoute As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel15 As Windows.Forms.Label
    Friend WithEvents chkRepeatRoute As Windows.Forms.CheckBox
    Friend WithEvents chkIgnoreMove As Windows.Forms.CheckBox
    Friend WithEvents btnMoveRouteCancel As Windows.Forms.Button
    Friend WithEvents btnMoveRouteOk As Windows.Forms.Button
    Friend WithEvents fraRandom14 As Windows.Forms.GroupBox
    Friend WithEvents btnAddMoveRoute43 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute42 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute41 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute40 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute39 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute38 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute37 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute36 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute35 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute34 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute33 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute32 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute31 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute30 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute29 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute28 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute27 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute26 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute25 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute24 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute23 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute22 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute21 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute20 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute19 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute18 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute17 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute16 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute15 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute14 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute13 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute12 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute11 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute10 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute9 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute8 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute7 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute6 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute5 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute4 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute3 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute2 As Windows.Forms.Button
    Friend WithEvents btnAddMoveRoute1 As Windows.Forms.Button
    Friend WithEvents lstMoveRoute As Windows.Forms.ListBox
    Friend WithEvents cmbEvent As Windows.Forms.ComboBox
    Friend WithEvents tabPages As Windows.Forms.TabControl
    Friend WithEvents frarandom20 As Windows.Forms.GroupBox
    Friend WithEvents btnClearPage As Windows.Forms.Button
    Friend WithEvents btnDeletePage As Windows.Forms.Button
    Friend WithEvents btnPastePage As Windows.Forms.Button
    Friend WithEvents btnCopyPage As Windows.Forms.Button
    Friend WithEvents btnNewPage As Windows.Forms.Button
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents lblRandomlabel32 As Windows.Forms.Label
    Friend WithEvents btnLabeling As Windows.Forms.Button
    Friend WithEvents fraDialogue As Windows.Forms.GroupBox
    Friend WithEvents fraCommand32 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok30 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel30 As Windows.Forms.Button
    Friend WithEvents scrlCompleteQuestTask As Windows.Forms.HScrollBar
    Friend WithEvents scrlCompleteQuestTaskQuest As Windows.Forms.HScrollBar
    Friend WithEvents lblRandomLabel48 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel47 As Windows.Forms.Label
    Friend WithEvents fraCommand4 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok4 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel4 As Windows.Forms.Button
    Friend WithEvents lblRandomLabel37 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel13 As Windows.Forms.Label
    Friend WithEvents txtVariableData4 As Windows.Forms.TextBox
    Friend WithEvents txtVariableData3 As Windows.Forms.TextBox
    Friend WithEvents optVariableAction3 As Windows.Forms.RadioButton
    Friend WithEvents txtVariableData2 As Windows.Forms.TextBox
    Friend WithEvents optVariableAction2 As Windows.Forms.RadioButton
    Friend WithEvents txtVariableData1 As Windows.Forms.TextBox
    Friend WithEvents optVariableAction1 As Windows.Forms.RadioButton
    Friend WithEvents txtVariableData0 As Windows.Forms.TextBox
    Friend WithEvents optVariableAction0 As Windows.Forms.RadioButton
    Friend WithEvents cmbVariable As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel As Windows.Forms.Label
    Friend WithEvents fraCommand9 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok8 As Windows.Forms.Button
    Friend WithEvents txtGotoLabel As Windows.Forms.TextBox
    Friend WithEvents btnCommand_Cancel8 As Windows.Forms.Button
    Friend WithEvents lblRandomLabel41 As Windows.Forms.Label
    Friend WithEvents fraCommand8 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok7 As Windows.Forms.Button
    Friend WithEvents txtLabelName As Windows.Forms.TextBox
    Friend WithEvents btnCommand_Cancel7 As Windows.Forms.Button
    Friend WithEvents lblRandomLabel40 As Windows.Forms.Label
    Friend WithEvents fraCommand13 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok12 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel12 As Windows.Forms.Button
    Friend WithEvents cmbChangeClass As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel29 As Windows.Forms.Label
    Friend WithEvents fraCommand12 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok11 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel11 As Windows.Forms.Button
    Friend WithEvents optChangeSkillsRemove As Windows.Forms.RadioButton
    Friend WithEvents optChangeSkillsAdd As Windows.Forms.RadioButton
    Friend WithEvents cmbChangeSkills As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel28 As Windows.Forms.Label
    Friend WithEvents fraCommand11 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok10 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel10 As Windows.Forms.Button
    Friend WithEvents scrlChangeLevel As Windows.Forms.HScrollBar
    Friend WithEvents lblChangeLevel As Windows.Forms.Label
    Friend WithEvents fraCommand10 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok9 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel9 As Windows.Forms.Button
    Friend WithEvents txtChangeItemsAmount As Windows.Forms.TextBox
    Friend WithEvents optChangeItemRemove As Windows.Forms.RadioButton
    Friend WithEvents optChangeItemAdd As Windows.Forms.RadioButton
    Friend WithEvents optChangeItemSet As Windows.Forms.RadioButton
    Friend WithEvents cmbChangeItemIndex As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel27 As Windows.Forms.Label
    Friend WithEvents fraCommand6 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok6 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel6 As Windows.Forms.Button
    Friend WithEvents lblRandomLabel26 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel24 As Windows.Forms.Label
    Friend WithEvents cmbSetSelfSwitchTo As Windows.Forms.ComboBox
    Friend WithEvents cmbSetSelfSwitch As Windows.Forms.ComboBox
    Friend WithEvents fraCommand5 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok5 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel5 As Windows.Forms.Button
    Friend WithEvents lblRandomLabel22 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel23 As Windows.Forms.Label
    Friend WithEvents cmbPlayerSwitchSet As Windows.Forms.ComboBox
    Friend WithEvents cmbSwitch As Windows.Forms.ComboBox
    Friend WithEvents fraCommand15 As Windows.Forms.GroupBox
    Friend WithEvents fraCommand14 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok13 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel13 As Windows.Forms.Button
    Friend WithEvents scrlChangeSprite As Windows.Forms.HScrollBar
    Friend WithEvents lblChangeSprite As Windows.Forms.Label
    Friend WithEvents fraCommand1 As Windows.Forms.GroupBox
    Friend WithEvents txtChoices4 As Windows.Forms.TextBox
    Friend WithEvents txtChoices3 As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel21 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel20 As Windows.Forms.Label
    Friend WithEvents txtChoices2 As Windows.Forms.TextBox
    Friend WithEvents txtChoices1 As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel19 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel17 As Windows.Forms.Label
    Friend WithEvents btnCommand_Ok1 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel1 As Windows.Forms.Button
    Friend WithEvents scrlShowChoicesFace As Windows.Forms.HScrollBar
    Friend WithEvents lblShowChoicesFace As Windows.Forms.Label
    Friend WithEvents picShowChoicesFace As Windows.Forms.PictureBox
    Friend WithEvents txtChoicePrompt As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel16 As Windows.Forms.Label
    Friend WithEvents fraCommand0 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok0 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel0 As Windows.Forms.Button
    Friend WithEvents scrlShowTextFace As Windows.Forms.HScrollBar
    Friend WithEvents lblShowTextFace As Windows.Forms.Label
    Friend WithEvents picShowTextFace As Windows.Forms.PictureBox
    Friend WithEvents txtShowText As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel18 As Windows.Forms.Label
    Friend WithEvents fraCommand17 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok16 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel16 As Windows.Forms.Button
    Friend WithEvents lblGiveExp As Windows.Forms.Label
    Friend WithEvents scrlGiveExp As Windows.Forms.HScrollBar
    Friend WithEvents fraCommand16 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok15 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel15 As Windows.Forms.Button
    Friend WithEvents optChangePKNo As Windows.Forms.RadioButton
    Friend WithEvents optChangePKYes As Windows.Forms.RadioButton
    Friend WithEvents btnCommand_Ok14 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel14 As Windows.Forms.Button
    Friend WithEvents optChangeSexFemale As Windows.Forms.RadioButton
    Friend WithEvents optChangeSexMale As Windows.Forms.RadioButton
    Friend WithEvents fraCommand2 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok2 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel2 As Windows.Forms.Button
    Friend WithEvents optAddText_Global As Windows.Forms.RadioButton
    Friend WithEvents optAddText_Map As Windows.Forms.RadioButton
    Friend WithEvents optAddText_Player As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel10 As Windows.Forms.Label
    Friend WithEvents lblAddText_Colour As Windows.Forms.Label
    Friend WithEvents scrlAddText_Colour As Windows.Forms.HScrollBar
    Friend WithEvents txtAddText_Text As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel34 As Windows.Forms.Label
    Friend WithEvents fraCommand33 As Windows.Forms.GroupBox
    Friend WithEvents txtPicOffset2 As Windows.Forms.TextBox
    Friend WithEvents txtPicOffset1 As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel57 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel56 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel55 As Windows.Forms.Label
    Friend WithEvents optPic3 As Windows.Forms.RadioButton
    Friend WithEvents optPic2 As Windows.Forms.RadioButton
    Friend WithEvents optPic1 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel54 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel53 As Windows.Forms.Label
    Friend WithEvents btnCommand_Ok33 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel33 As Windows.Forms.Button
    Friend WithEvents scrlShowPicture As Windows.Forms.HScrollBar
    Friend WithEvents lblShowPic As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents cmbPicIndex As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel52 As Windows.Forms.Label
    Friend WithEvents fraCommand21 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok20 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel20 As Windows.Forms.Button
    Friend WithEvents cmbOpenShop As Windows.Forms.ComboBox
    Friend WithEvents fraCommand19 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok18 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel18 As Windows.Forms.Button
    Friend WithEvents cmbSpawnNPC As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel42 As Windows.Forms.Label
    Friend WithEvents fraCommand3 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok3 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel3 As Windows.Forms.Button
    Friend WithEvents cmbChatBubbleTarget As Windows.Forms.ComboBox
    Friend WithEvents optChatBubbleTarget2 As Windows.Forms.RadioButton
    Friend WithEvents optChatBubbleTarget1 As Windows.Forms.RadioButton
    Friend WithEvents optChatBubbleTarget0 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel39 As Windows.Forms.Label
    Friend WithEvents txtChatbubbleText As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel38 As Windows.Forms.Label
    Friend WithEvents fraCommand24 As Windows.Forms.GroupBox
    Friend WithEvents scrlMapTintData3 As Windows.Forms.HScrollBar
    Friend WithEvents lblMapTintData3 As Windows.Forms.Label
    Friend WithEvents scrlMapTintData2 As Windows.Forms.HScrollBar
    Friend WithEvents lblMapTintData2 As Windows.Forms.Label
    Friend WithEvents lblMapTintData1 As Windows.Forms.Label
    Friend WithEvents scrlMapTintData1 As Windows.Forms.HScrollBar
    Friend WithEvents btnCommand_Ok23 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel23 As Windows.Forms.Button
    Friend WithEvents lblMapTintData0 As Windows.Forms.Label
    Friend WithEvents scrlMapTintData0 As Windows.Forms.HScrollBar
    Friend WithEvents fraCommand22 As Windows.Forms.GroupBox
    Friend WithEvents ScrlFogData2 As Windows.Forms.HScrollBar
    Friend WithEvents lblFogData2 As Windows.Forms.Label
    Friend WithEvents lblFogData1 As Windows.Forms.Label
    Friend WithEvents ScrlFogData1 As Windows.Forms.HScrollBar
    Friend WithEvents btnCommand_Ok21 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel21 As Windows.Forms.Button
    Friend WithEvents lblFogData0 As Windows.Forms.Label
    Friend WithEvents ScrlFogData0 As Windows.Forms.HScrollBar
    Friend WithEvents fraCommand20 As Windows.Forms.GroupBox
    Friend WithEvents lblPlayAnimY As Windows.Forms.Label
    Friend WithEvents scrlPlayAnimTileY As Windows.Forms.HScrollBar
    Friend WithEvents cmbPlayAnim As Windows.Forms.ComboBox
    Friend WithEvents btnCommand_Ok19 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel19 As Windows.Forms.Button
    Friend WithEvents optPlayAnimTile As Windows.Forms.RadioButton
    Friend WithEvents optPlayAnimEvent As Windows.Forms.RadioButton
    Friend WithEvents optPlayAnimPlayer As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel31 As Windows.Forms.Label
    Friend WithEvents lblPlayAnimX As Windows.Forms.Label
    Friend WithEvents scrlPlayAnimTileX As Windows.Forms.HScrollBar
    Friend WithEvents lblRandomLabel30 As Windows.Forms.Label
    Friend WithEvents fraCommand26 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok25 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel25 As Windows.Forms.Button
    Friend WithEvents cmbPlaySound As Windows.Forms.ComboBox
    Friend WithEvents fraCommand28 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok27 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel27 As Windows.Forms.Button
    Friend WithEvents cmbSetAccess As Windows.Forms.ComboBox
    Friend WithEvents fraCommand25 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok24 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel24 As Windows.Forms.Button
    Friend WithEvents cmbPlayBGM As Windows.Forms.ComboBox
    Friend WithEvents fraCommand31 As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel46 As Windows.Forms.Label
    Friend WithEvents btnCommand_Ok31 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel31 As Windows.Forms.Button
    Friend WithEvents cmbEndQuest As Windows.Forms.ComboBox
    Friend WithEvents fraCommand30 As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel45 As Windows.Forms.Label
    Friend WithEvents btnCommand_Ok32 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel32 As Windows.Forms.Button
    Friend WithEvents cmbBeginQuest As Windows.Forms.ComboBox
    Friend WithEvents cmbPlayAnimEvent As Windows.Forms.ComboBox
    Friend WithEvents fraCommand34 As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel58 As Windows.Forms.Label
    Friend WithEvents btnCommand_Ok34 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel34 As Windows.Forms.Button
    Friend WithEvents cmbHidePic As Windows.Forms.ComboBox
    Friend WithEvents fraCommand35 As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel59 As Windows.Forms.Label
    Friend WithEvents btnCommand_Ok35 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel35 As Windows.Forms.Button
    Friend WithEvents cmbMoveWait As Windows.Forms.ComboBox
    Friend WithEvents fraCommand18 As Windows.Forms.GroupBox
    Friend WithEvents cmbWarpPlayerDir As Windows.Forms.ComboBox
    Friend WithEvents scrlWPY As Windows.Forms.HScrollBar
    Friend WithEvents lblWPY As Windows.Forms.Label
    Friend WithEvents lblWPX As Windows.Forms.Label
    Friend WithEvents scrlWPX As Windows.Forms.HScrollBar
    Friend WithEvents btnCommand_Ok17 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel17 As Windows.Forms.Button
    Friend WithEvents lblWPMap As Windows.Forms.Label
    Friend WithEvents scrlWPMap As Windows.Forms.HScrollBar
    Friend WithEvents fraCommand23 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok22 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel22 As Windows.Forms.Button
    Friend WithEvents scrlWeatherIntensity As Windows.Forms.HScrollBar
    Friend WithEvents lblWeatherIntensity As Windows.Forms.Label
    Friend WithEvents CmbWeather As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel43 As Windows.Forms.Label
    Friend WithEvents fraCommand27 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok26 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel26 As Windows.Forms.Button
    Friend WithEvents scrlWaitAmount As Windows.Forms.HScrollBar
    Friend WithEvents lblRandomLabel44 As Windows.Forms.Label
    Friend WithEvents lblWaitAmount As Windows.Forms.Label
    Friend WithEvents fraCommand29 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok28 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel28 As Windows.Forms.Button
    Friend WithEvents scrlCustomScript As Windows.Forms.HScrollBar
    Friend WithEvents lblCustomScript As Windows.Forms.Label
    Friend WithEvents fraCommand7 As Windows.Forms.GroupBox
    Friend WithEvents btnCommand_Ok29 As Windows.Forms.Button
    Friend WithEvents btnCommand_Cancel29 As Windows.Forms.Button
    Friend WithEvents fraConditions_Quest As Windows.Forms.GroupBox
    Friend WithEvents lblCondition_QuestTask As Windows.Forms.Label
    Friend WithEvents optCondition_Quest1 As Windows.Forms.RadioButton
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel50 As Windows.Forms.Label
    Friend WithEvents optCondition_Quest0 As Windows.Forms.RadioButton
    Friend WithEvents cmbCondition_General As Windows.Forms.ComboBox
    Friend WithEvents scrlCondition_QuestTask As Windows.Forms.HScrollBar
    Friend WithEvents lblConditionQuest As Windows.Forms.Label
    Friend WithEvents optCondition_Index7 As Windows.Forms.RadioButton
    Friend WithEvents optCondition_Index6 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel2 As Windows.Forms.Label
    Friend WithEvents optCondition_Index5 As Windows.Forms.RadioButton
    Friend WithEvents cmbCondition_LearntSkill As Windows.Forms.ComboBox
    Friend WithEvents optCondition_Index4 As Windows.Forms.RadioButton
    Friend WithEvents cmbCondition_ClassIs As Windows.Forms.ComboBox
    Friend WithEvents optCondition_Index3 As Windows.Forms.RadioButton
    Friend WithEvents scrlCondition_Quest As Windows.Forms.HScrollBar
    Friend WithEvents scrlCondition_HasItem As Windows.Forms.HScrollBar
    Friend WithEvents lblHasItemAmt As Windows.Forms.Label
    Friend WithEvents optCondition_Index2 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel35 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel1 As Windows.Forms.Label
    Friend WithEvents cmbCondition_SelfSwitchCondition As Windows.Forms.ComboBox
    Friend WithEvents cmbCondtion_PlayerSwitchCondition As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_LevelCompare As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_HasItem As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_SelfSwitch As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_PlayerSwitch As Windows.Forms.ComboBox
    Friend WithEvents optCondition_Index1 As Windows.Forms.RadioButton
    Friend WithEvents txtCondition_LevelAmount As Windows.Forms.TextBox
    Friend WithEvents txtCondition_PlayerVarCondition As Windows.Forms.TextBox
    Friend WithEvents cmbCondition_PlayerVarCompare As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel0 As Windows.Forms.Label
    Friend WithEvents cmbCondition_PlayerVarIndex As Windows.Forms.ComboBox
    Friend WithEvents optCondition_Index0 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel11 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel14 As Windows.Forms.Label
    Friend WithEvents fraCommands As Windows.Forms.Panel
    Friend WithEvents tabCommands As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents fraRandom2 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands10 As Windows.Forms.Button
    Friend WithEvents btnCommands9 As Windows.Forms.Button
    Friend WithEvents btnCommands8 As Windows.Forms.Button
    Friend WithEvents btnCommands7 As Windows.Forms.Button
    Friend WithEvents fraRandom1 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands6 As Windows.Forms.Button
    Friend WithEvents btnCommands5 As Windows.Forms.Button
    Friend WithEvents btnCommands4 As Windows.Forms.Button
    Friend WithEvents fraRandom3 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands21 As Windows.Forms.Button
    Friend WithEvents btnCommands20 As Windows.Forms.Button
    Friend WithEvents btnCommands19 As Windows.Forms.Button
    Friend WithEvents btnCommands18 As Windows.Forms.Button
    Friend WithEvents btnCommands17 As Windows.Forms.Button
    Friend WithEvents btnCommands16 As Windows.Forms.Button
    Friend WithEvents btnCommands15 As Windows.Forms.Button
    Friend WithEvents btnCommands14 As Windows.Forms.Button
    Friend WithEvents btnCommands13 As Windows.Forms.Button
    Friend WithEvents btnCommands12 As Windows.Forms.Button
    Friend WithEvents btnCommands11 As Windows.Forms.Button
    Friend WithEvents fraRandom21 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands3 As Windows.Forms.Button
    Friend WithEvents btnCommands2 As Windows.Forms.Button
    Friend WithEvents btnCommands1 As Windows.Forms.Button
    Friend WithEvents btnCommands0 As Windows.Forms.Button
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents fraRandom8 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands41 As Windows.Forms.Button
    Friend WithEvents btnCommands40 As Windows.Forms.Button
    Friend WithEvents btnCommands39 As Windows.Forms.Button
    Friend WithEvents frarandom7 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands38 As Windows.Forms.Button
    Friend WithEvents btnCommands37 As Windows.Forms.Button
    Friend WithEvents btnCommands36 As Windows.Forms.Button
    Friend WithEvents btnCommands35 As Windows.Forms.Button
    Friend WithEvents fraRandom12 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands34 As Windows.Forms.Button
    Friend WithEvents btnCommands33 As Windows.Forms.Button
    Friend WithEvents btnCommands32 As Windows.Forms.Button
    Friend WithEvents frarandom25 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands31 As Windows.Forms.Button
    Friend WithEvents btnCommands30 As Windows.Forms.Button
    Friend WithEvents btnCommands29 As Windows.Forms.Button
    Friend WithEvents fraRandom5 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands28 As Windows.Forms.Button
    Friend WithEvents fraRandom4 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands27 As Windows.Forms.Button
    Friend WithEvents btnCommands26 As Windows.Forms.Button
    Friend WithEvents btnCommands25 As Windows.Forms.Button
    Friend WithEvents btnCommands24 As Windows.Forms.Button
    Friend WithEvents btnCommands23 As Windows.Forms.Button
    Friend WithEvents btnCommands22 As Windows.Forms.Button
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents fraRandom6 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands49 As Windows.Forms.Button
    Friend WithEvents btnCommands48 As Windows.Forms.Button
    Friend WithEvents btnCommands47 As Windows.Forms.Button
    Friend WithEvents fraRandom11 As Windows.Forms.GroupBox
    Friend WithEvents btnCommands46 As Windows.Forms.Button
    Friend WithEvents btnCommands45 As Windows.Forms.Button
    Friend WithEvents btnCommands44 As Windows.Forms.Button
    Friend WithEvents btnCommands43 As Windows.Forms.Button
    Friend WithEvents btnCommands42 As Windows.Forms.Button
    Friend WithEvents btnCancelCommand As Windows.Forms.Button
    Friend WithEvents fraRandom17 As Windows.Forms.GroupBox
    Friend WithEvents chkGlobal As Windows.Forms.CheckBox
    Friend WithEvents fraRandom16 As Windows.Forms.GroupBox
    Friend WithEvents chkShowName As Windows.Forms.CheckBox
    Friend WithEvents chkWalkThrough As Windows.Forms.CheckBox
    Friend WithEvents chkDirFix As Windows.Forms.CheckBox
    Friend WithEvents chkWalkAnim As Windows.Forms.CheckBox
    Friend WithEvents fraRandom18 As Windows.Forms.GroupBox
    Friend WithEvents cmbTrigger As Windows.Forms.ComboBox
    Friend WithEvents fraRandom19 As Windows.Forms.GroupBox
    Friend WithEvents cmbPositioning As Windows.Forms.ComboBox
    Friend WithEvents fraRandom15 As Windows.Forms.GroupBox
    Friend WithEvents cmbMoveFreq As Windows.Forms.ComboBox
    Friend WithEvents cmbMoveSpeed As Windows.Forms.ComboBox
    Friend WithEvents btnMoveRoute As Windows.Forms.Button
    Friend WithEvents cmbMoveType As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel8 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel7 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel6 As Windows.Forms.Label
    Friend WithEvents frarandom13 As Windows.Forms.GroupBox
    Friend WithEvents picGraphic As Windows.Forms.PictureBox
    Friend WithEvents fraRandom0 As Windows.Forms.GroupBox
    Friend WithEvents cmbSelfSwitchCompare As Windows.Forms.ComboBox
    Friend WithEvents cmbPlayerSwitchCompare As Windows.Forms.ComboBox
    Friend WithEvents txtPlayerVariable As Windows.Forms.TextBox
    Friend WithEvents cmbPlayervarCompare As Windows.Forms.ComboBox
    Friend WithEvents lblRandomlabel4 As Windows.Forms.Label
    Friend WithEvents lblRandomlabel3 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel5 As Windows.Forms.Label
    Friend WithEvents cmbSelfSwitch As Windows.Forms.ComboBox
    Friend WithEvents cmbHasItem As Windows.Forms.ComboBox
    Friend WithEvents cmbPlayerSwitch As Windows.Forms.ComboBox
    Friend WithEvents cmbPlayerVar As Windows.Forms.ComboBox
    Friend WithEvents chkSelfSwitch As Windows.Forms.CheckBox
    Friend WithEvents chkHasItem As Windows.Forms.CheckBox
    Friend WithEvents chkPlayerSwitch As Windows.Forms.CheckBox
    Friend WithEvents chkPlayerVar As Windows.Forms.CheckBox
    Friend WithEvents Tab1 As Windows.Forms.TabPage
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents fraRandom9 As Windows.Forms.GroupBox
    Friend WithEvents btnClearCommand As Windows.Forms.Button
    Friend WithEvents btnDeleteComand As Windows.Forms.Button
    Friend WithEvents btnEditCommand As Windows.Forms.Button
    Friend WithEvents btnAddCommand As Windows.Forms.Button
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cmbEventQuest As Windows.Forms.ComboBox
    Friend WithEvents lstCommands As Windows.Forms.ListBox
    Friend WithEvents lstvCommands As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
End Class
