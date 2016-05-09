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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Movement", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Wait", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Turning", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Speed", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Walk Animation", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Fixed Direction", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("WalkThrough", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup8 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Set Position", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup9 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Set Graphic", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Up")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Down")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move left")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Right")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move Randomly")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move To Player***")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Move from Player***")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Step Forwards")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Step Backwards")
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait 100Ms")
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait 500Ms")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait 1000Ms")
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Up")
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Down")
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Left")
        Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Right")
        Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn 90DG Right")
        Dim ListViewItem18 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn 90DG Left")
        Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn 180DG")
        Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn Randomly")
        Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn To Player***")
        Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Turn From Player***")
        Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 8x Slower")
        Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 4x Slower")
        Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 2x Slower")
        Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed To Normal")
        Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 2x Faster")
        Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Speed 4x Faster")
        Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Lowest")
        Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Lower")
        Dim ListViewItem31 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Normal")
        Dim ListViewItem32 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Higher")
        Dim ListViewItem33 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Freq. To Highest")
        Dim ListViewItem34 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walking Animation ON")
        Dim ListViewItem35 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walking Animation OFF")
        Dim ListViewItem36 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Fixed Direction ON")
        Dim ListViewItem37 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Fixed Direction OFF")
        Dim ListViewItem38 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walkthrough ON")
        Dim ListViewItem39 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Walkthrough ON")
        Dim ListViewItem40 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Position Below Player")
        Dim ListViewItem41 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set PositionWith Player")
        Dim ListViewItem42 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Position Above Player")
        Dim ListViewItem43 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Graphic...")
        Dim ListViewGroup10 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Messages", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup11 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Events Progressing", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup12 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Flow Control", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup13 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Player Options", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup14 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Movement", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup15 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Animation", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup16 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Questing", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup17 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Map Functions", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup18 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Music and Sound", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup19 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Etc...", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup20 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Shop and Bank", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup21 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Cut-scene Options", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem44 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Show Text")
        Dim ListViewItem45 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Show Choices")
        Dim ListViewItem46 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Add Chatbox Text")
        Dim ListViewItem47 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Show ChatBubble")
        Dim ListViewItem48 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Player Variable")
        Dim ListViewItem49 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Player Switch")
        Dim ListViewItem50 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Self Switch")
        Dim ListViewItem51 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Conditional Branch")
        Dim ListViewItem52 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Exit Event Process")
        Dim ListViewItem53 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Label")
        Dim ListViewItem54 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("GoTo Label")
        Dim ListViewItem55 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Items")
        Dim ListViewItem56 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Restore HP")
        Dim ListViewItem57 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Restore MP")
        Dim ListViewItem58 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Level Up")
        Dim ListViewItem59 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Level")
        Dim ListViewItem60 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Skills")
        Dim ListViewItem61 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Class")
        Dim ListViewItem62 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Sprite")
        Dim ListViewItem63 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change Gender")
        Dim ListViewItem64 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Change PK")
        Dim ListViewItem65 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Give Experience")
        Dim ListViewItem66 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Warp Player")
        Dim ListViewItem67 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Move Route")
        Dim ListViewItem68 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait for Route Completion")
        Dim ListViewItem69 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Force Spawn Npc")
        Dim ListViewItem70 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Hold Player")
        Dim ListViewItem71 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Release Player")
        Dim ListViewItem72 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Animation")
        Dim ListViewItem73 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Begin Quest")
        Dim ListViewItem74 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Complete Task")
        Dim ListViewItem75 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("End Quest")
        Dim ListViewItem76 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Fog")
        Dim ListViewItem77 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Weather")
        Dim ListViewItem78 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Map Tinting")
        Dim ListViewItem79 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Play BGM")
        Dim ListViewItem80 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Stop BGM")
        Dim ListViewItem81 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Play Sound")
        Dim ListViewItem82 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Stop Sounds")
        Dim ListViewItem83 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Wait...")
        Dim ListViewItem84 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Set Access")
        Dim ListViewItem85 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Custom Script")
        Dim ListViewItem86 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Open Bank")
        Dim ListViewItem87 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Open Shop")
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
        Me.lblGraphic = New System.Windows.Forms.Label()
        Me.scrlGraphic = New System.Windows.Forms.HScrollBar()
        Me.cmbGraphic = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel33 = New System.Windows.Forms.Label()
        Me.pnlGraphicSelect = New System.Windows.Forms.Panel()
        Me.picGraphicSel = New System.Windows.Forms.PictureBox()
        Me.pnlMoveRoute = New System.Windows.Forms.Panel()
        Me.fraMoveRoute = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel15 = New System.Windows.Forms.Label()
        Me.chkRepeatRoute = New System.Windows.Forms.CheckBox()
        Me.chkIgnoreMove = New System.Windows.Forms.CheckBox()
        Me.btnMoveRouteCancel = New System.Windows.Forms.Button()
        Me.btnMoveRouteOk = New System.Windows.Forms.Button()
        Me.fraRandom14 = New System.Windows.Forms.GroupBox()
        Me.lstvwMoveRoute = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.fraSpawnNpc = New System.Windows.Forms.GroupBox()
        Me.btnSpawnNpcOK = New System.Windows.Forms.Button()
        Me.btnSpawnNpcCancel = New System.Windows.Forms.Button()
        Me.cmbSpawnNPC = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel42 = New System.Windows.Forms.Label()
        Me.fraShowChoices = New System.Windows.Forms.GroupBox()
        Me.txtChoices4 = New System.Windows.Forms.TextBox()
        Me.txtChoices3 = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel21 = New System.Windows.Forms.Label()
        Me.lblRandomLabel20 = New System.Windows.Forms.Label()
        Me.txtChoices2 = New System.Windows.Forms.TextBox()
        Me.txtChoices1 = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel19 = New System.Windows.Forms.Label()
        Me.lblRandomLabel17 = New System.Windows.Forms.Label()
        Me.btnShowChoicesOk = New System.Windows.Forms.Button()
        Me.btnShowChoicesCancel = New System.Windows.Forms.Button()
        Me.scrlShowChoicesFace = New System.Windows.Forms.HScrollBar()
        Me.lblShowChoicesFace = New System.Windows.Forms.Label()
        Me.picShowChoicesFace = New System.Windows.Forms.PictureBox()
        Me.txtChoicePrompt = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel16 = New System.Windows.Forms.Label()
        Me.fraAddText = New System.Windows.Forms.GroupBox()
        Me.txtAddText_Text = New System.Windows.Forms.TextBox()
        Me.btnAddTextOk = New System.Windows.Forms.Button()
        Me.btnAddTextCancel = New System.Windows.Forms.Button()
        Me.optAddText_Global = New System.Windows.Forms.RadioButton()
        Me.optAddText_Map = New System.Windows.Forms.RadioButton()
        Me.optAddText_Player = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel10 = New System.Windows.Forms.Label()
        Me.lblAddText_Colour = New System.Windows.Forms.Label()
        Me.scrlAddText_Colour = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel34 = New System.Windows.Forms.Label()
        Me.fraConditionalBranch = New System.Windows.Forms.GroupBox()
        Me.btnConditionalBranchOk = New System.Windows.Forms.Button()
        Me.btnConditionalBranchCancel = New System.Windows.Forms.Button()
        Me.fraConditions_Quest = New System.Windows.Forms.GroupBox()
        Me.lblCondition_QuestTask = New System.Windows.Forms.Label()
        Me.optCondition_Quest1 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRandomLabel50 = New System.Windows.Forms.Label()
        Me.optCondition_Quest0 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_General = New System.Windows.Forms.ComboBox()
        Me.scrlCondition_QuestTask = New System.Windows.Forms.HScrollBar()
        Me.lblConditionQuest = New System.Windows.Forms.Label()
        Me.optCondition7 = New System.Windows.Forms.RadioButton()
        Me.optCondition6 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel2 = New System.Windows.Forms.Label()
        Me.optCondition5 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_LearntSkill = New System.Windows.Forms.ComboBox()
        Me.optCondition4 = New System.Windows.Forms.RadioButton()
        Me.cmbCondition_ClassIs = New System.Windows.Forms.ComboBox()
        Me.optCondition3 = New System.Windows.Forms.RadioButton()
        Me.scrlCondition_Quest = New System.Windows.Forms.HScrollBar()
        Me.scrlCondition_HasItem = New System.Windows.Forms.HScrollBar()
        Me.lblHasItemAmt = New System.Windows.Forms.Label()
        Me.optCondition2 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel35 = New System.Windows.Forms.Label()
        Me.lblRandomLabel1 = New System.Windows.Forms.Label()
        Me.cmbCondition_SelfSwitchCondition = New System.Windows.Forms.ComboBox()
        Me.cmbCondtion_PlayerSwitchCondition = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_LevelCompare = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_HasItem = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_SelfSwitch = New System.Windows.Forms.ComboBox()
        Me.cmbCondition_PlayerSwitch = New System.Windows.Forms.ComboBox()
        Me.optCondition1 = New System.Windows.Forms.RadioButton()
        Me.txtCondition_LevelAmount = New System.Windows.Forms.TextBox()
        Me.txtCondition_PlayerVarCondition = New System.Windows.Forms.TextBox()
        Me.cmbCondition_PlayerVarCompare = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel0 = New System.Windows.Forms.Label()
        Me.cmbCondition_PlayerVarIndex = New System.Windows.Forms.ComboBox()
        Me.optCondition0 = New System.Windows.Forms.RadioButton()
        Me.fraOpenShop = New System.Windows.Forms.GroupBox()
        Me.btnOpenShopOK = New System.Windows.Forms.Button()
        Me.btnOpenShopCancel = New System.Windows.Forms.Button()
        Me.cmbOpenShop = New System.Windows.Forms.ComboBox()
        Me.fraShowPic = New System.Windows.Forms.GroupBox()
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
        Me.btnShowPicOK = New System.Windows.Forms.Button()
        Me.btnShowPicCancel = New System.Windows.Forms.Button()
        Me.scrlShowPicture = New System.Windows.Forms.HScrollBar()
        Me.lblShowPic = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbPicIndex = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel52 = New System.Windows.Forms.Label()
        Me.fraCustomScript = New System.Windows.Forms.GroupBox()
        Me.btnCustomScriptOK = New System.Windows.Forms.Button()
        Me.btnCustomScriptCancel = New System.Windows.Forms.Button()
        Me.scrlCustomScript = New System.Windows.Forms.HScrollBar()
        Me.lblCustomScript = New System.Windows.Forms.Label()
        Me.fraSetAccess = New System.Windows.Forms.GroupBox()
        Me.btnSetAccessOK = New System.Windows.Forms.Button()
        Me.btnSetAccessCancel = New System.Windows.Forms.Button()
        Me.cmbSetAccess = New System.Windows.Forms.ComboBox()
        Me.fraSetWait = New System.Windows.Forms.GroupBox()
        Me.btnSetWaitOK = New System.Windows.Forms.Button()
        Me.btnSetWaitCancel = New System.Windows.Forms.Button()
        Me.scrlWaitAmount = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel44 = New System.Windows.Forms.Label()
        Me.lblWaitAmount = New System.Windows.Forms.Label()
        Me.fraPlaySound = New System.Windows.Forms.GroupBox()
        Me.btnPlaySoundOK = New System.Windows.Forms.Button()
        Me.btnPlaySoundCancel = New System.Windows.Forms.Button()
        Me.cmbPlaySound = New System.Windows.Forms.ComboBox()
        Me.fraPlayBGM = New System.Windows.Forms.GroupBox()
        Me.btnPlayBgmOK = New System.Windows.Forms.Button()
        Me.btnPlayBgmCancel = New System.Windows.Forms.Button()
        Me.cmbPlayBGM = New System.Windows.Forms.ComboBox()
        Me.fraMapTint = New System.Windows.Forms.GroupBox()
        Me.scrlMapTintData3 = New System.Windows.Forms.HScrollBar()
        Me.lblMapTintData3 = New System.Windows.Forms.Label()
        Me.scrlMapTintData2 = New System.Windows.Forms.HScrollBar()
        Me.lblMapTintData2 = New System.Windows.Forms.Label()
        Me.lblMapTintData1 = New System.Windows.Forms.Label()
        Me.scrlMapTintData1 = New System.Windows.Forms.HScrollBar()
        Me.btnMapTintOK = New System.Windows.Forms.Button()
        Me.btnMapTintCancel = New System.Windows.Forms.Button()
        Me.lblMapTintData0 = New System.Windows.Forms.Label()
        Me.scrlMapTintData0 = New System.Windows.Forms.HScrollBar()
        Me.fraSetWeather = New System.Windows.Forms.GroupBox()
        Me.btnSetWeatherOK = New System.Windows.Forms.Button()
        Me.btnSetWeatherCancel = New System.Windows.Forms.Button()
        Me.scrlWeatherIntensity = New System.Windows.Forms.HScrollBar()
        Me.lblWeatherIntensity = New System.Windows.Forms.Label()
        Me.CmbWeather = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel43 = New System.Windows.Forms.Label()
        Me.fraSetFog = New System.Windows.Forms.GroupBox()
        Me.ScrlFogData2 = New System.Windows.Forms.HScrollBar()
        Me.lblFogData2 = New System.Windows.Forms.Label()
        Me.lblFogData1 = New System.Windows.Forms.Label()
        Me.ScrlFogData1 = New System.Windows.Forms.HScrollBar()
        Me.btnSetFogOK = New System.Windows.Forms.Button()
        Me.btnSetFogCancel = New System.Windows.Forms.Button()
        Me.lblFogData0 = New System.Windows.Forms.Label()
        Me.ScrlFogData0 = New System.Windows.Forms.HScrollBar()
        Me.fraEndQuest = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel46 = New System.Windows.Forms.Label()
        Me.btnEndQuestOK = New System.Windows.Forms.Button()
        Me.btnEndQuestCancel = New System.Windows.Forms.Button()
        Me.cmbEndQuest = New System.Windows.Forms.ComboBox()
        Me.fraCompleteTask = New System.Windows.Forms.GroupBox()
        Me.btnCompleteQuestTaskOK = New System.Windows.Forms.Button()
        Me.btnCompleteQuestTaskCancel = New System.Windows.Forms.Button()
        Me.scrlCompleteQuestTask = New System.Windows.Forms.HScrollBar()
        Me.scrlCompleteQuestTaskQuest = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel48 = New System.Windows.Forms.Label()
        Me.lblRandomLabel47 = New System.Windows.Forms.Label()
        Me.fraBeginQuest = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel45 = New System.Windows.Forms.Label()
        Me.btnBeginQuestOK = New System.Windows.Forms.Button()
        Me.btnBeginQuestCancel = New System.Windows.Forms.Button()
        Me.cmbBeginQuest = New System.Windows.Forms.ComboBox()
        Me.fraPlayAnimation = New System.Windows.Forms.GroupBox()
        Me.cmbPlayAnimEvent = New System.Windows.Forms.ComboBox()
        Me.lblPlayAnimY = New System.Windows.Forms.Label()
        Me.scrlPlayAnimTileY = New System.Windows.Forms.HScrollBar()
        Me.cmbPlayAnim = New System.Windows.Forms.ComboBox()
        Me.btnPlayAnimationOK = New System.Windows.Forms.Button()
        Me.btnPlayAnimationCancel = New System.Windows.Forms.Button()
        Me.optPlayAnimTile = New System.Windows.Forms.RadioButton()
        Me.optPlayAnimEvent = New System.Windows.Forms.RadioButton()
        Me.optPlayAnimPlayer = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel31 = New System.Windows.Forms.Label()
        Me.lblPlayAnimX = New System.Windows.Forms.Label()
        Me.scrlPlayAnimTileX = New System.Windows.Forms.HScrollBar()
        Me.lblRandomLabel30 = New System.Windows.Forms.Label()
        Me.fraMoveRouteWait = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel59 = New System.Windows.Forms.Label()
        Me.btnMoveWaitOK = New System.Windows.Forms.Button()
        Me.btnMoveWaitCancel = New System.Windows.Forms.Button()
        Me.cmbMoveWait = New System.Windows.Forms.ComboBox()
        Me.fraChangePK = New System.Windows.Forms.GroupBox()
        Me.btnChangePkOK = New System.Windows.Forms.Button()
        Me.btnChangePkCancel = New System.Windows.Forms.Button()
        Me.optChangePKNo = New System.Windows.Forms.RadioButton()
        Me.optChangePKYes = New System.Windows.Forms.RadioButton()
        Me.fraChangeGender = New System.Windows.Forms.GroupBox()
        Me.btnChangeGenderOK = New System.Windows.Forms.Button()
        Me.btnChangeGenderCancel = New System.Windows.Forms.Button()
        Me.optChangeSexFemale = New System.Windows.Forms.RadioButton()
        Me.optChangeSexMale = New System.Windows.Forms.RadioButton()
        Me.fraChangeSkills = New System.Windows.Forms.GroupBox()
        Me.btnChangeSkillsOK = New System.Windows.Forms.Button()
        Me.btnChangeSkillsCancel = New System.Windows.Forms.Button()
        Me.optChangeSkillsRemove = New System.Windows.Forms.RadioButton()
        Me.optChangeSkillsAdd = New System.Windows.Forms.RadioButton()
        Me.cmbChangeSkills = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel28 = New System.Windows.Forms.Label()
        Me.fraChangeSprite = New System.Windows.Forms.GroupBox()
        Me.btnChangeSpriteOK = New System.Windows.Forms.Button()
        Me.btnChangeSpriteCancel = New System.Windows.Forms.Button()
        Me.scrlChangeSprite = New System.Windows.Forms.HScrollBar()
        Me.lblChangeSprite = New System.Windows.Forms.Label()
        Me.fraChangeClass = New System.Windows.Forms.GroupBox()
        Me.btnChangeClassOK = New System.Windows.Forms.Button()
        Me.btnChangeClassCancel = New System.Windows.Forms.Button()
        Me.cmbChangeClass = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel29 = New System.Windows.Forms.Label()
        Me.fraChangeLevel = New System.Windows.Forms.GroupBox()
        Me.btnChangeLevelOK = New System.Windows.Forms.Button()
        Me.btnChangeLevelCancel = New System.Windows.Forms.Button()
        Me.scrlChangeLevel = New System.Windows.Forms.HScrollBar()
        Me.lblChangeLevel = New System.Windows.Forms.Label()
        Me.fraChangeItems = New System.Windows.Forms.GroupBox()
        Me.btnChangeItemsOk = New System.Windows.Forms.Button()
        Me.btnChangeItemsCancel = New System.Windows.Forms.Button()
        Me.txtChangeItemsAmount = New System.Windows.Forms.TextBox()
        Me.optChangeItemRemove = New System.Windows.Forms.RadioButton()
        Me.optChangeItemAdd = New System.Windows.Forms.RadioButton()
        Me.optChangeItemSet = New System.Windows.Forms.RadioButton()
        Me.cmbChangeItemIndex = New System.Windows.Forms.ComboBox()
        Me.lblRandomLabel27 = New System.Windows.Forms.Label()
        Me.fraSetSelfSwitch = New System.Windows.Forms.GroupBox()
        Me.btnSelfswitchOk = New System.Windows.Forms.Button()
        Me.btnSelfswitchCancel = New System.Windows.Forms.Button()
        Me.lblRandomLabel26 = New System.Windows.Forms.Label()
        Me.lblRandomLabel24 = New System.Windows.Forms.Label()
        Me.cmbSetSelfSwitchTo = New System.Windows.Forms.ComboBox()
        Me.cmbSetSelfSwitch = New System.Windows.Forms.ComboBox()
        Me.fraPlayerVariable = New System.Windows.Forms.GroupBox()
        Me.btnPlayerVarOk = New System.Windows.Forms.Button()
        Me.btnPlayerVarCancel = New System.Windows.Forms.Button()
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
        Me.fraShowChatBubble = New System.Windows.Forms.GroupBox()
        Me.btnShowChatBubbleOK = New System.Windows.Forms.Button()
        Me.btnShowChatBubbleCancel = New System.Windows.Forms.Button()
        Me.cmbChatBubbleTarget = New System.Windows.Forms.ComboBox()
        Me.optChatBubbleTarget2 = New System.Windows.Forms.RadioButton()
        Me.optChatBubbleTarget1 = New System.Windows.Forms.RadioButton()
        Me.optChatBubbleTarget0 = New System.Windows.Forms.RadioButton()
        Me.lblRandomLabel39 = New System.Windows.Forms.Label()
        Me.txtChatbubbleText = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel38 = New System.Windows.Forms.Label()
        Me.fraGiveExp = New System.Windows.Forms.GroupBox()
        Me.btnGiveExpOK = New System.Windows.Forms.Button()
        Me.btnGiveExpCancel = New System.Windows.Forms.Button()
        Me.lblGiveExp = New System.Windows.Forms.Label()
        Me.scrlGiveExp = New System.Windows.Forms.HScrollBar()
        Me.fraShowText = New System.Windows.Forms.GroupBox()
        Me.btnShowTextOk = New System.Windows.Forms.Button()
        Me.btnShowTextCancel = New System.Windows.Forms.Button()
        Me.scrlShowTextFace = New System.Windows.Forms.HScrollBar()
        Me.lblShowTextFace = New System.Windows.Forms.Label()
        Me.picShowTextFace = New System.Windows.Forms.PictureBox()
        Me.txtShowText = New System.Windows.Forms.TextBox()
        Me.lblRandomLabel18 = New System.Windows.Forms.Label()
        Me.fraPlayerWarp = New System.Windows.Forms.GroupBox()
        Me.cmbWarpPlayerDir = New System.Windows.Forms.ComboBox()
        Me.scrlWPY = New System.Windows.Forms.HScrollBar()
        Me.lblWPY = New System.Windows.Forms.Label()
        Me.lblWPX = New System.Windows.Forms.Label()
        Me.scrlWPX = New System.Windows.Forms.HScrollBar()
        Me.btnPlayerWarpOK = New System.Windows.Forms.Button()
        Me.btnPlayerWarpCancel = New System.Windows.Forms.Button()
        Me.lblWPMap = New System.Windows.Forms.Label()
        Me.scrlWPMap = New System.Windows.Forms.HScrollBar()
        Me.fraHidePic = New System.Windows.Forms.GroupBox()
        Me.lblRandomLabel58 = New System.Windows.Forms.Label()
        Me.btnHidePicOK = New System.Windows.Forms.Button()
        Me.btnHidePicCancel = New System.Windows.Forms.Button()
        Me.cmbHidePic = New System.Windows.Forms.ComboBox()
        Me.fraPlayerSwitch = New System.Windows.Forms.GroupBox()
        Me.btnSetPlayerSwitchOk = New System.Windows.Forms.Button()
        Me.btnSetPlayerswitchCancel = New System.Windows.Forms.Button()
        Me.lblRandomLabel22 = New System.Windows.Forms.Label()
        Me.lblRandomLabel23 = New System.Windows.Forms.Label()
        Me.cmbPlayerSwitchSet = New System.Windows.Forms.ComboBox()
        Me.cmbSwitch = New System.Windows.Forms.ComboBox()
        Me.fraCreateLabel = New System.Windows.Forms.GroupBox()
        Me.btnCreatelabelOk = New System.Windows.Forms.Button()
        Me.txtLabelName = New System.Windows.Forms.TextBox()
        Me.btnCreateLabelCancel = New System.Windows.Forms.Button()
        Me.lblRandomLabel40 = New System.Windows.Forms.Label()
        Me.fraGoToLabel = New System.Windows.Forms.GroupBox()
        Me.btnGoToLabelOk = New System.Windows.Forms.Button()
        Me.txtGotoLabel = New System.Windows.Forms.TextBox()
        Me.btnGoToLabelCancel = New System.Windows.Forms.Button()
        Me.lblRandomLabel41 = New System.Windows.Forms.Label()
        Me.lblRandomLabel11 = New System.Windows.Forms.Label()
        Me.lblRandomLabel14 = New System.Windows.Forms.Label()
        Me.fraCommands = New System.Windows.Forms.Panel()
        Me.lstvCommands = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancelCommand = New System.Windows.Forms.Button()
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlVariableSwitches.SuspendLayout()
        Me.fraLabeling.SuspendLayout()
        Me.FraRenaming.SuspendLayout()
        Me.fraRandom10.SuspendLayout()
        Me.fraGraphic.SuspendLayout()
        Me.pnlGraphicSelect.SuspendLayout()
        CType(Me.picGraphicSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMoveRoute.SuspendLayout()
        Me.fraMoveRoute.SuspendLayout()
        Me.fraRandom14.SuspendLayout()
        Me.tabPages.SuspendLayout()
        Me.frarandom20.SuspendLayout()
        Me.fraDialogue.SuspendLayout()
        Me.fraSpawnNpc.SuspendLayout()
        Me.fraShowChoices.SuspendLayout()
        CType(Me.picShowChoicesFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraAddText.SuspendLayout()
        Me.fraConditionalBranch.SuspendLayout()
        Me.fraConditions_Quest.SuspendLayout()
        Me.fraOpenShop.SuspendLayout()
        Me.fraShowPic.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCustomScript.SuspendLayout()
        Me.fraSetAccess.SuspendLayout()
        Me.fraSetWait.SuspendLayout()
        Me.fraPlaySound.SuspendLayout()
        Me.fraPlayBGM.SuspendLayout()
        Me.fraMapTint.SuspendLayout()
        Me.fraSetWeather.SuspendLayout()
        Me.fraSetFog.SuspendLayout()
        Me.fraEndQuest.SuspendLayout()
        Me.fraCompleteTask.SuspendLayout()
        Me.fraBeginQuest.SuspendLayout()
        Me.fraPlayAnimation.SuspendLayout()
        Me.fraMoveRouteWait.SuspendLayout()
        Me.fraChangePK.SuspendLayout()
        Me.fraChangeGender.SuspendLayout()
        Me.fraChangeSkills.SuspendLayout()
        Me.fraChangeSprite.SuspendLayout()
        Me.fraChangeClass.SuspendLayout()
        Me.fraChangeLevel.SuspendLayout()
        Me.fraChangeItems.SuspendLayout()
        Me.fraSetSelfSwitch.SuspendLayout()
        Me.fraPlayerVariable.SuspendLayout()
        Me.fraShowChatBubble.SuspendLayout()
        Me.fraGiveExp.SuspendLayout()
        Me.fraShowText.SuspendLayout()
        CType(Me.picShowTextFace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPlayerWarp.SuspendLayout()
        Me.fraHidePic.SuspendLayout()
        Me.fraPlayerSwitch.SuspendLayout()
        Me.fraCreateLabel.SuspendLayout()
        Me.fraGoToLabel.SuspendLayout()
        Me.fraCommands.SuspendLayout()
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
        Me.pnlVariableSwitches.Size = New System.Drawing.Size(826, 601)
        Me.pnlVariableSwitches.TabIndex = 1
        Me.pnlVariableSwitches.Visible = False
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
        Me.fraLabeling.Location = New System.Drawing.Point(190, 12)
        Me.fraLabeling.Name = "fraLabeling"
        Me.fraLabeling.Size = New System.Drawing.Size(441, 364)
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
        Me.FraRenaming.Location = New System.Drawing.Point(228, 385)
        Me.FraRenaming.Name = "FraRenaming"
        Me.FraRenaming.Size = New System.Drawing.Size(364, 143)
        Me.FraRenaming.TabIndex = 1
        Me.FraRenaming.TabStop = False
        Me.FraRenaming.Text = "Renaming Variable/Switch"
        Me.FraRenaming.Visible = False
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
        Me.fraGraphic.Controls.Add(Me.lblGraphic)
        Me.fraGraphic.Controls.Add(Me.scrlGraphic)
        Me.fraGraphic.Controls.Add(Me.cmbGraphic)
        Me.fraGraphic.Controls.Add(Me.lblRandomLabel33)
        Me.fraGraphic.Controls.Add(Me.pnlGraphicSelect)
        Me.fraGraphic.Location = New System.Drawing.Point(2, 3)
        Me.fraGraphic.Name = "fraGraphic"
        Me.fraGraphic.Size = New System.Drawing.Size(433, 517)
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
        Me.cmbGraphic.Items.AddRange(New Object() {"None", "Character"})
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
        'pnlGraphicSelect
        '
        Me.pnlGraphicSelect.Controls.Add(Me.picGraphicSel)
        Me.pnlGraphicSelect.Location = New System.Drawing.Point(6, 39)
        Me.pnlGraphicSelect.Name = "pnlGraphicSelect"
        Me.pnlGraphicSelect.Size = New System.Drawing.Size(421, 436)
        Me.pnlGraphicSelect.TabIndex = 9
        '
        'picGraphicSel
        '
        Me.picGraphicSel.Location = New System.Drawing.Point(4, 4)
        Me.picGraphicSel.Name = "picGraphicSel"
        Me.picGraphicSel.Size = New System.Drawing.Size(149, 132)
        Me.picGraphicSel.TabIndex = 4
        Me.picGraphicSel.TabStop = False
        '
        'pnlMoveRoute
        '
        Me.pnlMoveRoute.Controls.Add(Me.fraMoveRoute)
        Me.pnlMoveRoute.Location = New System.Drawing.Point(5, 4)
        Me.pnlMoveRoute.Name = "pnlMoveRoute"
        Me.pnlMoveRoute.Size = New System.Drawing.Size(826, 636)
        Me.pnlMoveRoute.TabIndex = 2
        Me.pnlMoveRoute.Visible = False
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
        Me.fraMoveRoute.Location = New System.Drawing.Point(3, 3)
        Me.fraMoveRoute.Name = "fraMoveRoute"
        Me.fraMoveRoute.Size = New System.Drawing.Size(811, 513)
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
        Me.fraRandom14.Controls.Add(Me.lstvwMoveRoute)
        Me.fraRandom14.Location = New System.Drawing.Point(203, 19)
        Me.fraRandom14.Name = "fraRandom14"
        Me.fraRandom14.Size = New System.Drawing.Size(596, 421)
        Me.fraRandom14.TabIndex = 2
        Me.fraRandom14.TabStop = False
        Me.fraRandom14.Text = "Commands"
        '
        'lstvwMoveRoute
        '
        Me.lstvwMoveRoute.AutoArrange = False
        Me.lstvwMoveRoute.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstvwMoveRoute.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstvwMoveRoute.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstvwMoveRoute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ListViewGroup1.Header = "Movement"
        ListViewGroup1.Name = "lstVgMovement"
        ListViewGroup2.Header = "Wait"
        ListViewGroup2.Name = "lstVgWait"
        ListViewGroup3.Header = "Turning"
        ListViewGroup3.Name = "lstVgTurn"
        ListViewGroup4.Header = "Speed"
        ListViewGroup4.Name = "lstVgSpeed"
        ListViewGroup5.Header = "Walk Animation"
        ListViewGroup5.Name = "lstVgWalk"
        ListViewGroup6.Header = "Fixed Direction"
        ListViewGroup6.Name = "lstVgDirection"
        ListViewGroup7.Header = "WalkThrough"
        ListViewGroup7.Name = "lstVgWalkThrough"
        ListViewGroup8.Header = "Set Position"
        ListViewGroup8.Name = "lstVgSetposition"
        ListViewGroup9.Header = "Set Graphic"
        ListViewGroup9.Name = "lstVgSetGraphic"
        Me.lstvwMoveRoute.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7, ListViewGroup8, ListViewGroup9})
        Me.lstvwMoveRoute.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup1
        ListViewItem2.IndentCount = 1
        ListViewItem3.Group = ListViewGroup1
        ListViewItem4.Group = ListViewGroup1
        ListViewItem4.IndentCount = 1
        ListViewItem5.Group = ListViewGroup1
        ListViewItem6.Group = ListViewGroup1
        ListViewItem7.Group = ListViewGroup1
        ListViewItem8.Group = ListViewGroup1
        ListViewItem9.Group = ListViewGroup1
        ListViewItem10.Group = ListViewGroup2
        ListViewItem11.Group = ListViewGroup2
        ListViewItem12.Group = ListViewGroup2
        ListViewItem13.Group = ListViewGroup3
        ListViewItem14.Group = ListViewGroup3
        ListViewItem15.Group = ListViewGroup3
        ListViewItem16.Group = ListViewGroup3
        ListViewItem17.Group = ListViewGroup3
        ListViewItem18.Group = ListViewGroup3
        ListViewItem19.Group = ListViewGroup3
        ListViewItem20.Group = ListViewGroup3
        ListViewItem21.Group = ListViewGroup3
        ListViewItem22.Group = ListViewGroup3
        ListViewItem23.Group = ListViewGroup4
        ListViewItem24.Group = ListViewGroup4
        ListViewItem25.Group = ListViewGroup4
        ListViewItem26.Group = ListViewGroup4
        ListViewItem27.Group = ListViewGroup4
        ListViewItem28.Group = ListViewGroup4
        ListViewItem29.Group = ListViewGroup4
        ListViewItem30.Group = ListViewGroup4
        ListViewItem31.Group = ListViewGroup4
        ListViewItem32.Group = ListViewGroup4
        ListViewItem33.Group = ListViewGroup4
        ListViewItem34.Group = ListViewGroup5
        ListViewItem35.Group = ListViewGroup5
        ListViewItem36.Group = ListViewGroup6
        ListViewItem37.Group = ListViewGroup6
        ListViewItem38.Group = ListViewGroup7
        ListViewItem39.Group = ListViewGroup7
        ListViewItem40.Group = ListViewGroup8
        ListViewItem41.Group = ListViewGroup8
        ListViewItem42.Group = ListViewGroup8
        ListViewItem43.Group = ListViewGroup9
        Me.lstvwMoveRoute.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30, ListViewItem31, ListViewItem32, ListViewItem33, ListViewItem34, ListViewItem35, ListViewItem36, ListViewItem37, ListViewItem38, ListViewItem39, ListViewItem40, ListViewItem41, ListViewItem42, ListViewItem43})
        Me.lstvwMoveRoute.LabelWrap = False
        Me.lstvwMoveRoute.Location = New System.Drawing.Point(3, 16)
        Me.lstvwMoveRoute.MultiSelect = False
        Me.lstvwMoveRoute.Name = "lstvwMoveRoute"
        Me.lstvwMoveRoute.Size = New System.Drawing.Size(590, 397)
        Me.lstvwMoveRoute.TabIndex = 4
        Me.lstvwMoveRoute.UseCompatibleStateImageBehavior = False
        Me.lstvwMoveRoute.View = System.Windows.Forms.View.Tile
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 150
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
        Me.fraDialogue.Controls.Add(Me.fraSetFog)
        Me.fraDialogue.Controls.Add(Me.fraSpawnNpc)
        Me.fraDialogue.Controls.Add(Me.fraShowChoices)
        Me.fraDialogue.Controls.Add(Me.fraAddText)
        Me.fraDialogue.Controls.Add(Me.fraConditionalBranch)
        Me.fraDialogue.Controls.Add(Me.fraOpenShop)
        Me.fraDialogue.Controls.Add(Me.fraShowPic)
        Me.fraDialogue.Controls.Add(Me.fraCustomScript)
        Me.fraDialogue.Controls.Add(Me.fraSetAccess)
        Me.fraDialogue.Controls.Add(Me.fraSetWait)
        Me.fraDialogue.Controls.Add(Me.fraPlaySound)
        Me.fraDialogue.Controls.Add(Me.fraPlayBGM)
        Me.fraDialogue.Controls.Add(Me.fraMapTint)
        Me.fraDialogue.Controls.Add(Me.fraSetWeather)
        Me.fraDialogue.Controls.Add(Me.fraEndQuest)
        Me.fraDialogue.Controls.Add(Me.fraCompleteTask)
        Me.fraDialogue.Controls.Add(Me.fraBeginQuest)
        Me.fraDialogue.Controls.Add(Me.fraPlayAnimation)
        Me.fraDialogue.Controls.Add(Me.fraMoveRouteWait)
        Me.fraDialogue.Controls.Add(Me.fraChangePK)
        Me.fraDialogue.Controls.Add(Me.fraChangeGender)
        Me.fraDialogue.Controls.Add(Me.fraChangeSkills)
        Me.fraDialogue.Controls.Add(Me.fraChangeSprite)
        Me.fraDialogue.Controls.Add(Me.fraChangeClass)
        Me.fraDialogue.Controls.Add(Me.fraChangeLevel)
        Me.fraDialogue.Controls.Add(Me.fraChangeItems)
        Me.fraDialogue.Controls.Add(Me.fraSetSelfSwitch)
        Me.fraDialogue.Controls.Add(Me.fraPlayerVariable)
        Me.fraDialogue.Controls.Add(Me.fraShowChatBubble)
        Me.fraDialogue.Controls.Add(Me.fraGiveExp)
        Me.fraDialogue.Controls.Add(Me.fraShowText)
        Me.fraDialogue.Controls.Add(Me.fraPlayerWarp)
        Me.fraDialogue.Controls.Add(Me.fraHidePic)
        Me.fraDialogue.Controls.Add(Me.fraPlayerSwitch)
        Me.fraDialogue.Controls.Add(Me.fraCreateLabel)
        Me.fraDialogue.Controls.Add(Me.fraGoToLabel)
        Me.fraDialogue.Location = New System.Drawing.Point(850, 29)
        Me.fraDialogue.Name = "fraDialogue"
        Me.fraDialogue.Size = New System.Drawing.Size(815, 592)
        Me.fraDialogue.TabIndex = 6
        Me.fraDialogue.TabStop = False
        '
        'fraSpawnNpc
        '
        Me.fraSpawnNpc.Controls.Add(Me.btnSpawnNpcOK)
        Me.fraSpawnNpc.Controls.Add(Me.btnSpawnNpcCancel)
        Me.fraSpawnNpc.Controls.Add(Me.cmbSpawnNPC)
        Me.fraSpawnNpc.Controls.Add(Me.lblRandomLabel42)
        Me.fraSpawnNpc.Location = New System.Drawing.Point(259, 441)
        Me.fraSpawnNpc.Name = "fraSpawnNpc"
        Me.fraSpawnNpc.Size = New System.Drawing.Size(246, 80)
        Me.fraSpawnNpc.TabIndex = 20
        Me.fraSpawnNpc.TabStop = False
        Me.fraSpawnNpc.Text = "Spawn NPC"
        Me.fraSpawnNpc.Visible = False
        '
        'btnSpawnNpcOK
        '
        Me.btnSpawnNpcOK.Location = New System.Drawing.Point(57, 40)
        Me.btnSpawnNpcOK.Name = "btnSpawnNpcOK"
        Me.btnSpawnNpcOK.Size = New System.Drawing.Size(75, 23)
        Me.btnSpawnNpcOK.TabIndex = 26
        Me.btnSpawnNpcOK.Text = "Ok"
        Me.btnSpawnNpcOK.UseVisualStyleBackColor = True
        '
        'btnSpawnNpcCancel
        '
        Me.btnSpawnNpcCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnSpawnNpcCancel.Name = "btnSpawnNpcCancel"
        Me.btnSpawnNpcCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSpawnNpcCancel.TabIndex = 25
        Me.btnSpawnNpcCancel.Text = "Cancel"
        Me.btnSpawnNpcCancel.UseVisualStyleBackColor = True
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
        'fraShowChoices
        '
        Me.fraShowChoices.Controls.Add(Me.txtChoices4)
        Me.fraShowChoices.Controls.Add(Me.txtChoices3)
        Me.fraShowChoices.Controls.Add(Me.lblRandomLabel21)
        Me.fraShowChoices.Controls.Add(Me.lblRandomLabel20)
        Me.fraShowChoices.Controls.Add(Me.txtChoices2)
        Me.fraShowChoices.Controls.Add(Me.txtChoices1)
        Me.fraShowChoices.Controls.Add(Me.lblRandomLabel19)
        Me.fraShowChoices.Controls.Add(Me.lblRandomLabel17)
        Me.fraShowChoices.Controls.Add(Me.btnShowChoicesOk)
        Me.fraShowChoices.Controls.Add(Me.btnShowChoicesCancel)
        Me.fraShowChoices.Controls.Add(Me.scrlShowChoicesFace)
        Me.fraShowChoices.Controls.Add(Me.lblShowChoicesFace)
        Me.fraShowChoices.Controls.Add(Me.picShowChoicesFace)
        Me.fraShowChoices.Controls.Add(Me.txtChoicePrompt)
        Me.fraShowChoices.Controls.Add(Me.lblRandomLabel16)
        Me.fraShowChoices.Location = New System.Drawing.Point(5, 13)
        Me.fraShowChoices.Name = "fraShowChoices"
        Me.fraShowChoices.Size = New System.Drawing.Size(245, 357)
        Me.fraShowChoices.TabIndex = 16
        Me.fraShowChoices.TabStop = False
        Me.fraShowChoices.Text = "Show Choices"
        Me.fraShowChoices.Visible = False
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
        'btnShowChoicesOk
        '
        Me.btnShowChoicesOk.Location = New System.Drawing.Point(83, 328)
        Me.btnShowChoicesOk.Name = "btnShowChoicesOk"
        Me.btnShowChoicesOk.Size = New System.Drawing.Size(75, 23)
        Me.btnShowChoicesOk.TabIndex = 20
        Me.btnShowChoicesOk.Text = "Ok"
        Me.btnShowChoicesOk.UseVisualStyleBackColor = True
        '
        'btnShowChoicesCancel
        '
        Me.btnShowChoicesCancel.Location = New System.Drawing.Point(164, 328)
        Me.btnShowChoicesCancel.Name = "btnShowChoicesCancel"
        Me.btnShowChoicesCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnShowChoicesCancel.TabIndex = 19
        Me.btnShowChoicesCancel.Text = "Cancel"
        Me.btnShowChoicesCancel.UseVisualStyleBackColor = True
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
        Me.picShowChoicesFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
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
        'fraAddText
        '
        Me.fraAddText.Controls.Add(Me.txtAddText_Text)
        Me.fraAddText.Controls.Add(Me.btnAddTextOk)
        Me.fraAddText.Controls.Add(Me.btnAddTextCancel)
        Me.fraAddText.Controls.Add(Me.optAddText_Global)
        Me.fraAddText.Controls.Add(Me.optAddText_Map)
        Me.fraAddText.Controls.Add(Me.optAddText_Player)
        Me.fraAddText.Controls.Add(Me.lblRandomLabel10)
        Me.fraAddText.Controls.Add(Me.lblAddText_Colour)
        Me.fraAddText.Controls.Add(Me.scrlAddText_Colour)
        Me.fraAddText.Controls.Add(Me.lblRandomLabel34)
        Me.fraAddText.Location = New System.Drawing.Point(6, 13)
        Me.fraAddText.Name = "fraAddText"
        Me.fraAddText.Size = New System.Drawing.Size(245, 217)
        Me.fraAddText.TabIndex = 18
        Me.fraAddText.TabStop = False
        Me.fraAddText.Text = "Add Text"
        Me.fraAddText.Visible = False
        '
        'txtAddText_Text
        '
        Me.txtAddText_Text.Location = New System.Drawing.Point(6, 32)
        Me.txtAddText_Text.Multiline = True
        Me.txtAddText_Text.Name = "txtAddText_Text"
        Me.txtAddText_Text.Size = New System.Drawing.Size(233, 118)
        Me.txtAddText_Text.TabIndex = 1
        '
        'btnAddTextOk
        '
        Me.btnAddTextOk.Location = New System.Drawing.Point(42, 184)
        Me.btnAddTextOk.Name = "btnAddTextOk"
        Me.btnAddTextOk.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTextOk.TabIndex = 20
        Me.btnAddTextOk.Text = "Ok"
        Me.btnAddTextOk.UseVisualStyleBackColor = True
        '
        'btnAddTextCancel
        '
        Me.btnAddTextCancel.Location = New System.Drawing.Point(123, 184)
        Me.btnAddTextCancel.Name = "btnAddTextCancel"
        Me.btnAddTextCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTextCancel.TabIndex = 19
        Me.btnAddTextCancel.Text = "Cancel"
        Me.btnAddTextCancel.UseVisualStyleBackColor = True
        '
        'optAddText_Global
        '
        Me.optAddText_Global.AutoSize = True
        Me.optAddText_Global.Location = New System.Drawing.Point(184, 159)
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
        Me.optAddText_Map.Location = New System.Drawing.Point(127, 159)
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
        Me.optAddText_Player.Location = New System.Drawing.Point(65, 159)
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
        Me.lblRandomLabel10.Location = New System.Drawing.Point(10, 160)
        Me.lblRandomLabel10.Name = "lblRandomLabel10"
        Me.lblRandomLabel10.Size = New System.Drawing.Size(49, 13)
        Me.lblRandomLabel10.TabIndex = 14
        Me.lblRandomLabel10.Text = "Channel:"
        '
        'lblAddText_Colour
        '
        Me.lblAddText_Colour.AutoSize = True
        Me.lblAddText_Colour.Location = New System.Drawing.Point(6, 107)
        Me.lblAddText_Colour.Name = "lblAddText_Colour"
        Me.lblAddText_Colour.Size = New System.Drawing.Size(64, 13)
        Me.lblAddText_Colour.TabIndex = 13
        Me.lblAddText_Colour.Text = "Color: Black"
        '
        'scrlAddText_Colour
        '
        Me.scrlAddText_Colour.Location = New System.Drawing.Point(4, 123)
        Me.scrlAddText_Colour.Name = "scrlAddText_Colour"
        Me.scrlAddText_Colour.Size = New System.Drawing.Size(235, 17)
        Me.scrlAddText_Colour.TabIndex = 12
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
        'fraConditionalBranch
        '
        Me.fraConditionalBranch.Controls.Add(Me.btnConditionalBranchOk)
        Me.fraConditionalBranch.Controls.Add(Me.btnConditionalBranchCancel)
        Me.fraConditionalBranch.Controls.Add(Me.fraConditions_Quest)
        Me.fraConditionalBranch.Controls.Add(Me.lblConditionQuest)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition7)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition6)
        Me.fraConditionalBranch.Controls.Add(Me.lblRandomLabel2)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition5)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_LearntSkill)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition4)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_ClassIs)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition3)
        Me.fraConditionalBranch.Controls.Add(Me.scrlCondition_Quest)
        Me.fraConditionalBranch.Controls.Add(Me.scrlCondition_HasItem)
        Me.fraConditionalBranch.Controls.Add(Me.lblHasItemAmt)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition2)
        Me.fraConditionalBranch.Controls.Add(Me.lblRandomLabel35)
        Me.fraConditionalBranch.Controls.Add(Me.lblRandomLabel1)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_SelfSwitchCondition)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondtion_PlayerSwitchCondition)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_LevelCompare)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_HasItem)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_SelfSwitch)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_PlayerSwitch)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition1)
        Me.fraConditionalBranch.Controls.Add(Me.txtCondition_LevelAmount)
        Me.fraConditionalBranch.Controls.Add(Me.txtCondition_PlayerVarCondition)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_PlayerVarCompare)
        Me.fraConditionalBranch.Controls.Add(Me.lblRandomLabel0)
        Me.fraConditionalBranch.Controls.Add(Me.cmbCondition_PlayerVarIndex)
        Me.fraConditionalBranch.Controls.Add(Me.optCondition0)
        Me.fraConditionalBranch.Location = New System.Drawing.Point(7, 11)
        Me.fraConditionalBranch.Name = "fraConditionalBranch"
        Me.fraConditionalBranch.Size = New System.Drawing.Size(400, 484)
        Me.fraConditionalBranch.TabIndex = 35
        Me.fraConditionalBranch.TabStop = False
        Me.fraConditionalBranch.Text = "Conditional Branch"
        Me.fraConditionalBranch.Visible = False
        '
        'btnConditionalBranchOk
        '
        Me.btnConditionalBranchOk.Location = New System.Drawing.Point(234, 452)
        Me.btnConditionalBranchOk.Name = "btnConditionalBranchOk"
        Me.btnConditionalBranchOk.Size = New System.Drawing.Size(75, 23)
        Me.btnConditionalBranchOk.TabIndex = 21
        Me.btnConditionalBranchOk.Text = "Ok"
        Me.btnConditionalBranchOk.UseVisualStyleBackColor = True
        '
        'btnConditionalBranchCancel
        '
        Me.btnConditionalBranchCancel.Location = New System.Drawing.Point(315, 452)
        Me.btnConditionalBranchCancel.Name = "btnConditionalBranchCancel"
        Me.btnConditionalBranchCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnConditionalBranchCancel.TabIndex = 21
        Me.btnConditionalBranchCancel.Text = "Cancel"
        Me.btnConditionalBranchCancel.UseVisualStyleBackColor = True
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
        'optCondition7
        '
        Me.optCondition7.AutoSize = True
        Me.optCondition7.Location = New System.Drawing.Point(7, 325)
        Me.optCondition7.Name = "optCondition7"
        Me.optCondition7.Size = New System.Drawing.Size(86, 17)
        Me.optCondition7.TabIndex = 18
        Me.optCondition7.TabStop = True
        Me.optCondition7.Text = "Quest Status"
        Me.optCondition7.UseVisualStyleBackColor = True
        '
        'optCondition6
        '
        Me.optCondition6.AutoSize = True
        Me.optCondition6.Location = New System.Drawing.Point(7, 288)
        Me.optCondition6.Name = "optCondition6"
        Me.optCondition6.Size = New System.Drawing.Size(78, 17)
        Me.optCondition6.TabIndex = 18
        Me.optCondition6.TabStop = True
        Me.optCondition6.Text = "Self Switch"
        Me.optCondition6.UseVisualStyleBackColor = True
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
        'optCondition5
        '
        Me.optCondition5.AutoSize = True
        Me.optCondition5.Location = New System.Drawing.Point(6, 250)
        Me.optCondition5.Name = "optCondition5"
        Me.optCondition5.Size = New System.Drawing.Size(51, 17)
        Me.optCondition5.TabIndex = 16
        Me.optCondition5.TabStop = True
        Me.optCondition5.Text = "Level"
        Me.optCondition5.UseVisualStyleBackColor = True
        '
        'cmbCondition_LearntSkill
        '
        Me.cmbCondition_LearntSkill.FormattingEnabled = True
        Me.cmbCondition_LearntSkill.Location = New System.Drawing.Point(123, 214)
        Me.cmbCondition_LearntSkill.Name = "cmbCondition_LearntSkill"
        Me.cmbCondition_LearntSkill.Size = New System.Drawing.Size(267, 21)
        Me.cmbCondition_LearntSkill.TabIndex = 15
        '
        'optCondition4
        '
        Me.optCondition4.AutoSize = True
        Me.optCondition4.Location = New System.Drawing.Point(6, 215)
        Me.optCondition4.Name = "optCondition4"
        Me.optCondition4.Size = New System.Drawing.Size(79, 17)
        Me.optCondition4.TabIndex = 14
        Me.optCondition4.TabStop = True
        Me.optCondition4.Text = "Knows Skill"
        Me.optCondition4.UseVisualStyleBackColor = True
        '
        'cmbCondition_ClassIs
        '
        Me.cmbCondition_ClassIs.FormattingEnabled = True
        Me.cmbCondition_ClassIs.Location = New System.Drawing.Point(123, 184)
        Me.cmbCondition_ClassIs.Name = "cmbCondition_ClassIs"
        Me.cmbCondition_ClassIs.Size = New System.Drawing.Size(267, 21)
        Me.cmbCondition_ClassIs.TabIndex = 13
        '
        'optCondition3
        '
        Me.optCondition3.AutoSize = True
        Me.optCondition3.Location = New System.Drawing.Point(6, 185)
        Me.optCondition3.Name = "optCondition3"
        Me.optCondition3.Size = New System.Drawing.Size(61, 17)
        Me.optCondition3.TabIndex = 12
        Me.optCondition3.TabStop = True
        Me.optCondition3.Text = "Class Is"
        Me.optCondition3.UseVisualStyleBackColor = True
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
        'optCondition2
        '
        Me.optCondition2.AutoSize = True
        Me.optCondition2.Location = New System.Drawing.Point(6, 154)
        Me.optCondition2.Name = "optCondition2"
        Me.optCondition2.Size = New System.Drawing.Size(67, 17)
        Me.optCondition2.TabIndex = 9
        Me.optCondition2.TabStop = True
        Me.optCondition2.Text = "Has Item"
        Me.optCondition2.UseVisualStyleBackColor = True
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
        'optCondition1
        '
        Me.optCondition1.AutoSize = True
        Me.optCondition1.Location = New System.Drawing.Point(6, 92)
        Me.optCondition1.Name = "optCondition1"
        Me.optCondition1.Size = New System.Drawing.Size(89, 17)
        Me.optCondition1.TabIndex = 5
        Me.optCondition1.TabStop = True
        Me.optCondition1.Text = "Player Switch"
        Me.optCondition1.UseVisualStyleBackColor = True
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
        'optCondition0
        '
        Me.optCondition0.AutoSize = True
        Me.optCondition0.Location = New System.Drawing.Point(6, 25)
        Me.optCondition0.Name = "optCondition0"
        Me.optCondition0.Size = New System.Drawing.Size(95, 17)
        Me.optCondition0.TabIndex = 0
        Me.optCondition0.TabStop = True
        Me.optCondition0.Text = "Player Variable"
        Me.optCondition0.UseVisualStyleBackColor = True
        '
        'fraOpenShop
        '
        Me.fraOpenShop.Controls.Add(Me.btnOpenShopOK)
        Me.fraOpenShop.Controls.Add(Me.btnOpenShopCancel)
        Me.fraOpenShop.Controls.Add(Me.cmbOpenShop)
        Me.fraOpenShop.Location = New System.Drawing.Point(564, 185)
        Me.fraOpenShop.Name = "fraOpenShop"
        Me.fraOpenShop.Size = New System.Drawing.Size(242, 82)
        Me.fraOpenShop.TabIndex = 21
        Me.fraOpenShop.TabStop = False
        Me.fraOpenShop.Text = "Open Shop"
        Me.fraOpenShop.Visible = False
        '
        'btnOpenShopOK
        '
        Me.btnOpenShopOK.Location = New System.Drawing.Point(57, 40)
        Me.btnOpenShopOK.Name = "btnOpenShopOK"
        Me.btnOpenShopOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenShopOK.TabIndex = 26
        Me.btnOpenShopOK.Text = "Ok"
        Me.btnOpenShopOK.UseVisualStyleBackColor = True
        '
        'btnOpenShopCancel
        '
        Me.btnOpenShopCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnOpenShopCancel.Name = "btnOpenShopCancel"
        Me.btnOpenShopCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenShopCancel.TabIndex = 25
        Me.btnOpenShopCancel.Text = "Cancel"
        Me.btnOpenShopCancel.UseVisualStyleBackColor = True
        '
        'cmbOpenShop
        '
        Me.cmbOpenShop.FormattingEnabled = True
        Me.cmbOpenShop.Location = New System.Drawing.Point(42, 13)
        Me.cmbOpenShop.Name = "cmbOpenShop"
        Me.cmbOpenShop.Size = New System.Drawing.Size(171, 21)
        Me.cmbOpenShop.TabIndex = 2
        '
        'fraShowPic
        '
        Me.fraShowPic.Controls.Add(Me.txtPicOffset2)
        Me.fraShowPic.Controls.Add(Me.txtPicOffset1)
        Me.fraShowPic.Controls.Add(Me.lblRandomLabel57)
        Me.fraShowPic.Controls.Add(Me.lblRandomLabel56)
        Me.fraShowPic.Controls.Add(Me.lblRandomLabel55)
        Me.fraShowPic.Controls.Add(Me.optPic3)
        Me.fraShowPic.Controls.Add(Me.optPic2)
        Me.fraShowPic.Controls.Add(Me.optPic1)
        Me.fraShowPic.Controls.Add(Me.lblRandomLabel54)
        Me.fraShowPic.Controls.Add(Me.lblRandomLabel53)
        Me.fraShowPic.Controls.Add(Me.btnShowPicOK)
        Me.fraShowPic.Controls.Add(Me.btnShowPicCancel)
        Me.fraShowPic.Controls.Add(Me.scrlShowPicture)
        Me.fraShowPic.Controls.Add(Me.lblShowPic)
        Me.fraShowPic.Controls.Add(Me.PictureBox1)
        Me.fraShowPic.Controls.Add(Me.cmbPicIndex)
        Me.fraShowPic.Controls.Add(Me.lblRandomLabel52)
        Me.fraShowPic.Location = New System.Drawing.Point(564, 256)
        Me.fraShowPic.Name = "fraShowPic"
        Me.fraShowPic.Size = New System.Drawing.Size(245, 328)
        Me.fraShowPic.TabIndex = 17
        Me.fraShowPic.TabStop = False
        Me.fraShowPic.Text = "Show Picture"
        Me.fraShowPic.Visible = False
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
        'btnShowPicOK
        '
        Me.btnShowPicOK.Location = New System.Drawing.Point(83, 301)
        Me.btnShowPicOK.Name = "btnShowPicOK"
        Me.btnShowPicOK.Size = New System.Drawing.Size(75, 23)
        Me.btnShowPicOK.TabIndex = 25
        Me.btnShowPicOK.Text = "Ok"
        Me.btnShowPicOK.UseVisualStyleBackColor = True
        '
        'btnShowPicCancel
        '
        Me.btnShowPicCancel.Location = New System.Drawing.Point(164, 301)
        Me.btnShowPicCancel.Name = "btnShowPicCancel"
        Me.btnShowPicCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnShowPicCancel.TabIndex = 24
        Me.btnShowPicCancel.Text = "Cancel"
        Me.btnShowPicCancel.UseVisualStyleBackColor = True
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
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
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
        'fraCustomScript
        '
        Me.fraCustomScript.Controls.Add(Me.btnCustomScriptOK)
        Me.fraCustomScript.Controls.Add(Me.btnCustomScriptCancel)
        Me.fraCustomScript.Controls.Add(Me.scrlCustomScript)
        Me.fraCustomScript.Controls.Add(Me.lblCustomScript)
        Me.fraCustomScript.Location = New System.Drawing.Point(262, 324)
        Me.fraCustomScript.Name = "fraCustomScript"
        Me.fraCustomScript.Size = New System.Drawing.Size(243, 84)
        Me.fraCustomScript.TabIndex = 35
        Me.fraCustomScript.TabStop = False
        Me.fraCustomScript.Text = "Execute Custom Script"
        Me.fraCustomScript.Visible = False
        '
        'btnCustomScriptOK
        '
        Me.btnCustomScriptOK.Location = New System.Drawing.Point(83, 55)
        Me.btnCustomScriptOK.Name = "btnCustomScriptOK"
        Me.btnCustomScriptOK.Size = New System.Drawing.Size(75, 23)
        Me.btnCustomScriptOK.TabIndex = 28
        Me.btnCustomScriptOK.Text = "Ok"
        Me.btnCustomScriptOK.UseVisualStyleBackColor = True
        '
        'btnCustomScriptCancel
        '
        Me.btnCustomScriptCancel.Location = New System.Drawing.Point(164, 55)
        Me.btnCustomScriptCancel.Name = "btnCustomScriptCancel"
        Me.btnCustomScriptCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCustomScriptCancel.TabIndex = 27
        Me.btnCustomScriptCancel.Text = "Cancel"
        Me.btnCustomScriptCancel.UseVisualStyleBackColor = True
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
        'fraSetAccess
        '
        Me.fraSetAccess.Controls.Add(Me.btnSetAccessOK)
        Me.fraSetAccess.Controls.Add(Me.btnSetAccessCancel)
        Me.fraSetAccess.Controls.Add(Me.cmbSetAccess)
        Me.fraSetAccess.Location = New System.Drawing.Point(262, 259)
        Me.fraSetAccess.Name = "fraSetAccess"
        Me.fraSetAccess.Size = New System.Drawing.Size(243, 72)
        Me.fraSetAccess.TabIndex = 27
        Me.fraSetAccess.TabStop = False
        Me.fraSetAccess.Text = "Set Access"
        Me.fraSetAccess.Visible = False
        '
        'btnSetAccessOK
        '
        Me.btnSetAccessOK.Location = New System.Drawing.Point(57, 40)
        Me.btnSetAccessOK.Name = "btnSetAccessOK"
        Me.btnSetAccessOK.Size = New System.Drawing.Size(75, 23)
        Me.btnSetAccessOK.TabIndex = 26
        Me.btnSetAccessOK.Text = "Ok"
        Me.btnSetAccessOK.UseVisualStyleBackColor = True
        '
        'btnSetAccessCancel
        '
        Me.btnSetAccessCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnSetAccessCancel.Name = "btnSetAccessCancel"
        Me.btnSetAccessCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetAccessCancel.TabIndex = 25
        Me.btnSetAccessCancel.Text = "Cancel"
        Me.btnSetAccessCancel.UseVisualStyleBackColor = True
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
        'fraSetWait
        '
        Me.fraSetWait.Controls.Add(Me.btnSetWaitOK)
        Me.fraSetWait.Controls.Add(Me.btnSetWaitCancel)
        Me.fraSetWait.Controls.Add(Me.scrlWaitAmount)
        Me.fraSetWait.Controls.Add(Me.lblRandomLabel44)
        Me.fraSetWait.Controls.Add(Me.lblWaitAmount)
        Me.fraSetWait.Location = New System.Drawing.Point(260, 169)
        Me.fraSetWait.Name = "fraSetWait"
        Me.fraSetWait.Size = New System.Drawing.Size(245, 95)
        Me.fraSetWait.TabIndex = 34
        Me.fraSetWait.TabStop = False
        Me.fraSetWait.Text = "Wait..."
        Me.fraSetWait.Visible = False
        '
        'btnSetWaitOK
        '
        Me.btnSetWaitOK.Location = New System.Drawing.Point(57, 55)
        Me.btnSetWaitOK.Name = "btnSetWaitOK"
        Me.btnSetWaitOK.Size = New System.Drawing.Size(75, 23)
        Me.btnSetWaitOK.TabIndex = 28
        Me.btnSetWaitOK.Text = "Ok"
        Me.btnSetWaitOK.UseVisualStyleBackColor = True
        '
        'btnSetWaitCancel
        '
        Me.btnSetWaitCancel.Location = New System.Drawing.Point(138, 55)
        Me.btnSetWaitCancel.Name = "btnSetWaitCancel"
        Me.btnSetWaitCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetWaitCancel.TabIndex = 27
        Me.btnSetWaitCancel.Text = "Cancel"
        Me.btnSetWaitCancel.UseVisualStyleBackColor = True
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
        'fraPlaySound
        '
        Me.fraPlaySound.Controls.Add(Me.btnPlaySoundOK)
        Me.fraPlaySound.Controls.Add(Me.btnPlaySoundCancel)
        Me.fraPlaySound.Controls.Add(Me.cmbPlaySound)
        Me.fraPlaySound.Location = New System.Drawing.Point(563, 107)
        Me.fraPlaySound.Name = "fraPlaySound"
        Me.fraPlaySound.Size = New System.Drawing.Size(246, 77)
        Me.fraPlaySound.TabIndex = 22
        Me.fraPlaySound.TabStop = False
        Me.fraPlaySound.Text = "Play Sound"
        Me.fraPlaySound.Visible = False
        '
        'btnPlaySoundOK
        '
        Me.btnPlaySoundOK.Location = New System.Drawing.Point(57, 40)
        Me.btnPlaySoundOK.Name = "btnPlaySoundOK"
        Me.btnPlaySoundOK.Size = New System.Drawing.Size(75, 23)
        Me.btnPlaySoundOK.TabIndex = 26
        Me.btnPlaySoundOK.Text = "Ok"
        Me.btnPlaySoundOK.UseVisualStyleBackColor = True
        '
        'btnPlaySoundCancel
        '
        Me.btnPlaySoundCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnPlaySoundCancel.Name = "btnPlaySoundCancel"
        Me.btnPlaySoundCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnPlaySoundCancel.TabIndex = 25
        Me.btnPlaySoundCancel.Text = "Cancel"
        Me.btnPlaySoundCancel.UseVisualStyleBackColor = True
        '
        'cmbPlaySound
        '
        Me.cmbPlaySound.FormattingEnabled = True
        Me.cmbPlaySound.Location = New System.Drawing.Point(42, 13)
        Me.cmbPlaySound.Name = "cmbPlaySound"
        Me.cmbPlaySound.Size = New System.Drawing.Size(171, 21)
        Me.cmbPlaySound.TabIndex = 2
        '
        'fraPlayBGM
        '
        Me.fraPlayBGM.Controls.Add(Me.btnPlayBgmOK)
        Me.fraPlayBGM.Controls.Add(Me.btnPlayBgmCancel)
        Me.fraPlayBGM.Controls.Add(Me.cmbPlayBGM)
        Me.fraPlayBGM.Location = New System.Drawing.Point(563, 13)
        Me.fraPlayBGM.Name = "fraPlayBGM"
        Me.fraPlayBGM.Size = New System.Drawing.Size(246, 88)
        Me.fraPlayBGM.TabIndex = 26
        Me.fraPlayBGM.TabStop = False
        Me.fraPlayBGM.Text = "Play BGM"
        Me.fraPlayBGM.Visible = False
        '
        'btnPlayBgmOK
        '
        Me.btnPlayBgmOK.Location = New System.Drawing.Point(57, 40)
        Me.btnPlayBgmOK.Name = "btnPlayBgmOK"
        Me.btnPlayBgmOK.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayBgmOK.TabIndex = 26
        Me.btnPlayBgmOK.Text = "Ok"
        Me.btnPlayBgmOK.UseVisualStyleBackColor = True
        '
        'btnPlayBgmCancel
        '
        Me.btnPlayBgmCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnPlayBgmCancel.Name = "btnPlayBgmCancel"
        Me.btnPlayBgmCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayBgmCancel.TabIndex = 25
        Me.btnPlayBgmCancel.Text = "Cancel"
        Me.btnPlayBgmCancel.UseVisualStyleBackColor = True
        '
        'cmbPlayBGM
        '
        Me.cmbPlayBGM.FormattingEnabled = True
        Me.cmbPlayBGM.Location = New System.Drawing.Point(42, 13)
        Me.cmbPlayBGM.Name = "cmbPlayBGM"
        Me.cmbPlayBGM.Size = New System.Drawing.Size(171, 21)
        Me.cmbPlayBGM.TabIndex = 2
        '
        'fraMapTint
        '
        Me.fraMapTint.Controls.Add(Me.scrlMapTintData3)
        Me.fraMapTint.Controls.Add(Me.lblMapTintData3)
        Me.fraMapTint.Controls.Add(Me.scrlMapTintData2)
        Me.fraMapTint.Controls.Add(Me.lblMapTintData2)
        Me.fraMapTint.Controls.Add(Me.lblMapTintData1)
        Me.fraMapTint.Controls.Add(Me.scrlMapTintData1)
        Me.fraMapTint.Controls.Add(Me.btnMapTintOK)
        Me.fraMapTint.Controls.Add(Me.btnMapTintCancel)
        Me.fraMapTint.Controls.Add(Me.lblMapTintData0)
        Me.fraMapTint.Controls.Add(Me.scrlMapTintData0)
        Me.fraMapTint.Location = New System.Drawing.Point(3, 392)
        Me.fraMapTint.Name = "fraMapTint"
        Me.fraMapTint.Size = New System.Drawing.Size(245, 145)
        Me.fraMapTint.TabIndex = 25
        Me.fraMapTint.TabStop = False
        Me.fraMapTint.Text = "Map Overlay"
        Me.fraMapTint.Visible = False
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
        'btnMapTintOK
        '
        Me.btnMapTintOK.Location = New System.Drawing.Point(83, 114)
        Me.btnMapTintOK.Name = "btnMapTintOK"
        Me.btnMapTintOK.Size = New System.Drawing.Size(75, 23)
        Me.btnMapTintOK.TabIndex = 20
        Me.btnMapTintOK.Text = "Ok"
        Me.btnMapTintOK.UseVisualStyleBackColor = True
        '
        'btnMapTintCancel
        '
        Me.btnMapTintCancel.Location = New System.Drawing.Point(164, 114)
        Me.btnMapTintCancel.Name = "btnMapTintCancel"
        Me.btnMapTintCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnMapTintCancel.TabIndex = 19
        Me.btnMapTintCancel.Text = "Cancel"
        Me.btnMapTintCancel.UseVisualStyleBackColor = True
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
        'fraSetWeather
        '
        Me.fraSetWeather.Controls.Add(Me.btnSetWeatherOK)
        Me.fraSetWeather.Controls.Add(Me.btnSetWeatherCancel)
        Me.fraSetWeather.Controls.Add(Me.scrlWeatherIntensity)
        Me.fraSetWeather.Controls.Add(Me.lblWeatherIntensity)
        Me.fraSetWeather.Controls.Add(Me.CmbWeather)
        Me.fraSetWeather.Controls.Add(Me.lblRandomLabel43)
        Me.fraSetWeather.Location = New System.Drawing.Point(5, 281)
        Me.fraSetWeather.Name = "fraSetWeather"
        Me.fraSetWeather.Size = New System.Drawing.Size(246, 112)
        Me.fraSetWeather.TabIndex = 36
        Me.fraSetWeather.TabStop = False
        Me.fraSetWeather.Text = "Set Weather"
        Me.fraSetWeather.Visible = False
        '
        'btnSetWeatherOK
        '
        Me.btnSetWeatherOK.Location = New System.Drawing.Point(58, 83)
        Me.btnSetWeatherOK.Name = "btnSetWeatherOK"
        Me.btnSetWeatherOK.Size = New System.Drawing.Size(75, 23)
        Me.btnSetWeatherOK.TabIndex = 28
        Me.btnSetWeatherOK.Text = "Ok"
        Me.btnSetWeatherOK.UseVisualStyleBackColor = True
        '
        'btnSetWeatherCancel
        '
        Me.btnSetWeatherCancel.Location = New System.Drawing.Point(139, 83)
        Me.btnSetWeatherCancel.Name = "btnSetWeatherCancel"
        Me.btnSetWeatherCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetWeatherCancel.TabIndex = 27
        Me.btnSetWeatherCancel.Text = "Cancel"
        Me.btnSetWeatherCancel.UseVisualStyleBackColor = True
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
        'fraSetFog
        '
        Me.fraSetFog.Controls.Add(Me.ScrlFogData2)
        Me.fraSetFog.Controls.Add(Me.lblFogData2)
        Me.fraSetFog.Controls.Add(Me.lblFogData1)
        Me.fraSetFog.Controls.Add(Me.ScrlFogData1)
        Me.fraSetFog.Controls.Add(Me.btnSetFogOK)
        Me.fraSetFog.Controls.Add(Me.btnSetFogCancel)
        Me.fraSetFog.Controls.Add(Me.lblFogData0)
        Me.fraSetFog.Controls.Add(Me.ScrlFogData0)
        Me.fraSetFog.Location = New System.Drawing.Point(3, 167)
        Me.fraSetFog.Name = "fraSetFog"
        Me.fraSetFog.Size = New System.Drawing.Size(251, 114)
        Me.fraSetFog.TabIndex = 24
        Me.fraSetFog.TabStop = False
        Me.fraSetFog.Text = "Set Fog"
        Me.fraSetFog.Visible = False
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
        'btnSetFogOK
        '
        Me.btnSetFogOK.Location = New System.Drawing.Point(83, 85)
        Me.btnSetFogOK.Name = "btnSetFogOK"
        Me.btnSetFogOK.Size = New System.Drawing.Size(75, 23)
        Me.btnSetFogOK.TabIndex = 20
        Me.btnSetFogOK.Text = "Ok"
        Me.btnSetFogOK.UseVisualStyleBackColor = True
        '
        'btnSetFogCancel
        '
        Me.btnSetFogCancel.Location = New System.Drawing.Point(164, 85)
        Me.btnSetFogCancel.Name = "btnSetFogCancel"
        Me.btnSetFogCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetFogCancel.TabIndex = 19
        Me.btnSetFogCancel.Text = "Cancel"
        Me.btnSetFogCancel.UseVisualStyleBackColor = True
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
        'fraEndQuest
        '
        Me.fraEndQuest.Controls.Add(Me.lblRandomLabel46)
        Me.fraEndQuest.Controls.Add(Me.btnEndQuestOK)
        Me.fraEndQuest.Controls.Add(Me.btnEndQuestCancel)
        Me.fraEndQuest.Controls.Add(Me.cmbEndQuest)
        Me.fraEndQuest.Location = New System.Drawing.Point(3, 94)
        Me.fraEndQuest.Name = "fraEndQuest"
        Me.fraEndQuest.Size = New System.Drawing.Size(250, 72)
        Me.fraEndQuest.TabIndex = 29
        Me.fraEndQuest.TabStop = False
        Me.fraEndQuest.Text = "End Quest"
        Me.fraEndQuest.Visible = False
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
        'btnEndQuestOK
        '
        Me.btnEndQuestOK.Location = New System.Drawing.Point(57, 40)
        Me.btnEndQuestOK.Name = "btnEndQuestOK"
        Me.btnEndQuestOK.Size = New System.Drawing.Size(75, 23)
        Me.btnEndQuestOK.TabIndex = 26
        Me.btnEndQuestOK.Text = "Ok"
        Me.btnEndQuestOK.UseVisualStyleBackColor = True
        '
        'btnEndQuestCancel
        '
        Me.btnEndQuestCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnEndQuestCancel.Name = "btnEndQuestCancel"
        Me.btnEndQuestCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnEndQuestCancel.TabIndex = 25
        Me.btnEndQuestCancel.Text = "Cancel"
        Me.btnEndQuestCancel.UseVisualStyleBackColor = True
        '
        'cmbEndQuest
        '
        Me.cmbEndQuest.FormattingEnabled = True
        Me.cmbEndQuest.Location = New System.Drawing.Point(50, 13)
        Me.cmbEndQuest.Name = "cmbEndQuest"
        Me.cmbEndQuest.Size = New System.Drawing.Size(189, 21)
        Me.cmbEndQuest.TabIndex = 2
        '
        'fraCompleteTask
        '
        Me.fraCompleteTask.Controls.Add(Me.btnCompleteQuestTaskOK)
        Me.fraCompleteTask.Controls.Add(Me.btnCompleteQuestTaskCancel)
        Me.fraCompleteTask.Controls.Add(Me.scrlCompleteQuestTask)
        Me.fraCompleteTask.Controls.Add(Me.scrlCompleteQuestTaskQuest)
        Me.fraCompleteTask.Controls.Add(Me.lblRandomLabel48)
        Me.fraCompleteTask.Controls.Add(Me.lblRandomLabel47)
        Me.fraCompleteTask.Location = New System.Drawing.Point(258, 12)
        Me.fraCompleteTask.Name = "fraCompleteTask"
        Me.fraCompleteTask.Size = New System.Drawing.Size(247, 100)
        Me.fraCompleteTask.TabIndex = 2
        Me.fraCompleteTask.TabStop = False
        Me.fraCompleteTask.Text = "Complete Quest Task"
        Me.fraCompleteTask.Visible = False
        '
        'btnCompleteQuestTaskOK
        '
        Me.btnCompleteQuestTaskOK.Location = New System.Drawing.Point(57, 71)
        Me.btnCompleteQuestTaskOK.Name = "btnCompleteQuestTaskOK"
        Me.btnCompleteQuestTaskOK.Size = New System.Drawing.Size(75, 23)
        Me.btnCompleteQuestTaskOK.TabIndex = 15
        Me.btnCompleteQuestTaskOK.Text = "Ok"
        Me.btnCompleteQuestTaskOK.UseVisualStyleBackColor = True
        '
        'btnCompleteQuestTaskCancel
        '
        Me.btnCompleteQuestTaskCancel.Location = New System.Drawing.Point(138, 71)
        Me.btnCompleteQuestTaskCancel.Name = "btnCompleteQuestTaskCancel"
        Me.btnCompleteQuestTaskCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCompleteQuestTaskCancel.TabIndex = 14
        Me.btnCompleteQuestTaskCancel.Text = "Cancel"
        Me.btnCompleteQuestTaskCancel.UseVisualStyleBackColor = True
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
        'fraBeginQuest
        '
        Me.fraBeginQuest.Controls.Add(Me.lblRandomLabel45)
        Me.fraBeginQuest.Controls.Add(Me.btnBeginQuestOK)
        Me.fraBeginQuest.Controls.Add(Me.btnBeginQuestCancel)
        Me.fraBeginQuest.Controls.Add(Me.cmbBeginQuest)
        Me.fraBeginQuest.Location = New System.Drawing.Point(3, 11)
        Me.fraBeginQuest.Name = "fraBeginQuest"
        Me.fraBeginQuest.Size = New System.Drawing.Size(247, 85)
        Me.fraBeginQuest.TabIndex = 28
        Me.fraBeginQuest.TabStop = False
        Me.fraBeginQuest.Text = "Begin Quest"
        Me.fraBeginQuest.Visible = False
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
        'btnBeginQuestOK
        '
        Me.btnBeginQuestOK.Location = New System.Drawing.Point(57, 40)
        Me.btnBeginQuestOK.Name = "btnBeginQuestOK"
        Me.btnBeginQuestOK.Size = New System.Drawing.Size(75, 23)
        Me.btnBeginQuestOK.TabIndex = 26
        Me.btnBeginQuestOK.Text = "Ok"
        Me.btnBeginQuestOK.UseVisualStyleBackColor = True
        '
        'btnBeginQuestCancel
        '
        Me.btnBeginQuestCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnBeginQuestCancel.Name = "btnBeginQuestCancel"
        Me.btnBeginQuestCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnBeginQuestCancel.TabIndex = 25
        Me.btnBeginQuestCancel.Text = "Cancel"
        Me.btnBeginQuestCancel.UseVisualStyleBackColor = True
        '
        'cmbBeginQuest
        '
        Me.cmbBeginQuest.FormattingEnabled = True
        Me.cmbBeginQuest.Location = New System.Drawing.Point(50, 13)
        Me.cmbBeginQuest.Name = "cmbBeginQuest"
        Me.cmbBeginQuest.Size = New System.Drawing.Size(163, 21)
        Me.cmbBeginQuest.TabIndex = 2
        '
        'fraPlayAnimation
        '
        Me.fraPlayAnimation.Controls.Add(Me.cmbPlayAnimEvent)
        Me.fraPlayAnimation.Controls.Add(Me.lblPlayAnimY)
        Me.fraPlayAnimation.Controls.Add(Me.scrlPlayAnimTileY)
        Me.fraPlayAnimation.Controls.Add(Me.cmbPlayAnim)
        Me.fraPlayAnimation.Controls.Add(Me.btnPlayAnimationOK)
        Me.fraPlayAnimation.Controls.Add(Me.btnPlayAnimationCancel)
        Me.fraPlayAnimation.Controls.Add(Me.optPlayAnimTile)
        Me.fraPlayAnimation.Controls.Add(Me.optPlayAnimEvent)
        Me.fraPlayAnimation.Controls.Add(Me.optPlayAnimPlayer)
        Me.fraPlayAnimation.Controls.Add(Me.lblRandomLabel31)
        Me.fraPlayAnimation.Controls.Add(Me.lblPlayAnimX)
        Me.fraPlayAnimation.Controls.Add(Me.scrlPlayAnimTileX)
        Me.fraPlayAnimation.Controls.Add(Me.lblRandomLabel30)
        Me.fraPlayAnimation.Location = New System.Drawing.Point(262, 410)
        Me.fraPlayAnimation.Name = "fraPlayAnimation"
        Me.fraPlayAnimation.Size = New System.Drawing.Size(245, 174)
        Me.fraPlayAnimation.TabIndex = 23
        Me.fraPlayAnimation.TabStop = False
        Me.fraPlayAnimation.Text = "Play Animation"
        Me.fraPlayAnimation.Visible = False
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
        'btnPlayAnimationOK
        '
        Me.btnPlayAnimationOK.Location = New System.Drawing.Point(83, 146)
        Me.btnPlayAnimationOK.Name = "btnPlayAnimationOK"
        Me.btnPlayAnimationOK.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayAnimationOK.TabIndex = 20
        Me.btnPlayAnimationOK.Text = "Ok"
        Me.btnPlayAnimationOK.UseVisualStyleBackColor = True
        '
        'btnPlayAnimationCancel
        '
        Me.btnPlayAnimationCancel.Location = New System.Drawing.Point(164, 146)
        Me.btnPlayAnimationCancel.Name = "btnPlayAnimationCancel"
        Me.btnPlayAnimationCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayAnimationCancel.TabIndex = 19
        Me.btnPlayAnimationCancel.Text = "Cancel"
        Me.btnPlayAnimationCancel.UseVisualStyleBackColor = True
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
        'fraMoveRouteWait
        '
        Me.fraMoveRouteWait.Controls.Add(Me.lblRandomLabel59)
        Me.fraMoveRouteWait.Controls.Add(Me.btnMoveWaitOK)
        Me.fraMoveRouteWait.Controls.Add(Me.btnMoveWaitCancel)
        Me.fraMoveRouteWait.Controls.Add(Me.cmbMoveWait)
        Me.fraMoveRouteWait.Location = New System.Drawing.Point(263, 360)
        Me.fraMoveRouteWait.Name = "fraMoveRouteWait"
        Me.fraMoveRouteWait.Size = New System.Drawing.Size(242, 81)
        Me.fraMoveRouteWait.TabIndex = 30
        Me.fraMoveRouteWait.TabStop = False
        Me.fraMoveRouteWait.Text = "Wait for Move Route Completion"
        Me.fraMoveRouteWait.Visible = False
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
        'btnMoveWaitOK
        '
        Me.btnMoveWaitOK.Location = New System.Drawing.Point(57, 40)
        Me.btnMoveWaitOK.Name = "btnMoveWaitOK"
        Me.btnMoveWaitOK.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveWaitOK.TabIndex = 26
        Me.btnMoveWaitOK.Text = "Ok"
        Me.btnMoveWaitOK.UseVisualStyleBackColor = True
        '
        'btnMoveWaitCancel
        '
        Me.btnMoveWaitCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnMoveWaitCancel.Name = "btnMoveWaitCancel"
        Me.btnMoveWaitCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveWaitCancel.TabIndex = 25
        Me.btnMoveWaitCancel.Text = "Cancel"
        Me.btnMoveWaitCancel.UseVisualStyleBackColor = True
        '
        'cmbMoveWait
        '
        Me.cmbMoveWait.FormattingEnabled = True
        Me.cmbMoveWait.Location = New System.Drawing.Point(50, 13)
        Me.cmbMoveWait.Name = "cmbMoveWait"
        Me.cmbMoveWait.Size = New System.Drawing.Size(163, 21)
        Me.cmbMoveWait.TabIndex = 2
        '
        'fraChangePK
        '
        Me.fraChangePK.Controls.Add(Me.btnChangePkOK)
        Me.fraChangePK.Controls.Add(Me.btnChangePkCancel)
        Me.fraChangePK.Controls.Add(Me.optChangePKNo)
        Me.fraChangePK.Controls.Add(Me.optChangePKYes)
        Me.fraChangePK.Location = New System.Drawing.Point(257, 13)
        Me.fraChangePK.Name = "fraChangePK"
        Me.fraChangePK.Size = New System.Drawing.Size(248, 86)
        Me.fraChangePK.TabIndex = 13
        Me.fraChangePK.TabStop = False
        Me.fraChangePK.Text = "Set Player PK"
        Me.fraChangePK.Visible = False
        '
        'btnChangePkOK
        '
        Me.btnChangePkOK.Location = New System.Drawing.Point(57, 42)
        Me.btnChangePkOK.Name = "btnChangePkOK"
        Me.btnChangePkOK.Size = New System.Drawing.Size(75, 23)
        Me.btnChangePkOK.TabIndex = 16
        Me.btnChangePkOK.Text = "Ok"
        Me.btnChangePkOK.UseVisualStyleBackColor = True
        '
        'btnChangePkCancel
        '
        Me.btnChangePkCancel.Location = New System.Drawing.Point(138, 42)
        Me.btnChangePkCancel.Name = "btnChangePkCancel"
        Me.btnChangePkCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangePkCancel.TabIndex = 15
        Me.btnChangePkCancel.Text = "Cancel"
        Me.btnChangePkCancel.UseVisualStyleBackColor = True
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
        'fraChangeGender
        '
        Me.fraChangeGender.Controls.Add(Me.btnChangeGenderOK)
        Me.fraChangeGender.Controls.Add(Me.btnChangeGenderCancel)
        Me.fraChangeGender.Controls.Add(Me.optChangeSexFemale)
        Me.fraChangeGender.Controls.Add(Me.optChangeSexMale)
        Me.fraChangeGender.Location = New System.Drawing.Point(5, 517)
        Me.fraChangeGender.Name = "fraChangeGender"
        Me.fraChangeGender.Size = New System.Drawing.Size(249, 71)
        Me.fraChangeGender.TabIndex = 12
        Me.fraChangeGender.TabStop = False
        Me.fraChangeGender.Text = "Change Player Gender"
        Me.fraChangeGender.Visible = False
        '
        'btnChangeGenderOK
        '
        Me.btnChangeGenderOK.Location = New System.Drawing.Point(57, 42)
        Me.btnChangeGenderOK.Name = "btnChangeGenderOK"
        Me.btnChangeGenderOK.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeGenderOK.TabIndex = 16
        Me.btnChangeGenderOK.Text = "Ok"
        Me.btnChangeGenderOK.UseVisualStyleBackColor = True
        '
        'btnChangeGenderCancel
        '
        Me.btnChangeGenderCancel.Location = New System.Drawing.Point(138, 42)
        Me.btnChangeGenderCancel.Name = "btnChangeGenderCancel"
        Me.btnChangeGenderCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeGenderCancel.TabIndex = 15
        Me.btnChangeGenderCancel.Text = "Cancel"
        Me.btnChangeGenderCancel.UseVisualStyleBackColor = True
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
        'fraChangeSkills
        '
        Me.fraChangeSkills.Controls.Add(Me.btnChangeSkillsOK)
        Me.fraChangeSkills.Controls.Add(Me.btnChangeSkillsCancel)
        Me.fraChangeSkills.Controls.Add(Me.optChangeSkillsRemove)
        Me.fraChangeSkills.Controls.Add(Me.optChangeSkillsAdd)
        Me.fraChangeSkills.Controls.Add(Me.cmbChangeSkills)
        Me.fraChangeSkills.Controls.Add(Me.lblRandomLabel28)
        Me.fraChangeSkills.Location = New System.Drawing.Point(6, 425)
        Me.fraChangeSkills.Name = "fraChangeSkills"
        Me.fraChangeSkills.Size = New System.Drawing.Size(245, 98)
        Me.fraChangeSkills.TabIndex = 9
        Me.fraChangeSkills.TabStop = False
        Me.fraChangeSkills.Text = "Change Player Skills"
        Me.fraChangeSkills.Visible = False
        '
        'btnChangeSkillsOK
        '
        Me.btnChangeSkillsOK.Location = New System.Drawing.Point(83, 63)
        Me.btnChangeSkillsOK.Name = "btnChangeSkillsOK"
        Me.btnChangeSkillsOK.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeSkillsOK.TabIndex = 20
        Me.btnChangeSkillsOK.Text = "Ok"
        Me.btnChangeSkillsOK.UseVisualStyleBackColor = True
        '
        'btnChangeSkillsCancel
        '
        Me.btnChangeSkillsCancel.Location = New System.Drawing.Point(164, 63)
        Me.btnChangeSkillsCancel.Name = "btnChangeSkillsCancel"
        Me.btnChangeSkillsCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeSkillsCancel.TabIndex = 19
        Me.btnChangeSkillsCancel.Text = "Cancel"
        Me.btnChangeSkillsCancel.UseVisualStyleBackColor = True
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
        'fraChangeSprite
        '
        Me.fraChangeSprite.Controls.Add(Me.btnChangeSpriteOK)
        Me.fraChangeSprite.Controls.Add(Me.btnChangeSpriteCancel)
        Me.fraChangeSprite.Controls.Add(Me.scrlChangeSprite)
        Me.fraChangeSprite.Controls.Add(Me.lblChangeSprite)
        Me.fraChangeSprite.Location = New System.Drawing.Point(5, 238)
        Me.fraChangeSprite.Name = "fraChangeSprite"
        Me.fraChangeSprite.Size = New System.Drawing.Size(246, 67)
        Me.fraChangeSprite.TabIndex = 11
        Me.fraChangeSprite.TabStop = False
        Me.fraChangeSprite.Text = "Change Player Sprite"
        Me.fraChangeSprite.Visible = False
        '
        'btnChangeSpriteOK
        '
        Me.btnChangeSpriteOK.Location = New System.Drawing.Point(57, 39)
        Me.btnChangeSpriteOK.Name = "btnChangeSpriteOK"
        Me.btnChangeSpriteOK.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeSpriteOK.TabIndex = 24
        Me.btnChangeSpriteOK.Text = "Ok"
        Me.btnChangeSpriteOK.UseVisualStyleBackColor = True
        '
        'btnChangeSpriteCancel
        '
        Me.btnChangeSpriteCancel.Location = New System.Drawing.Point(138, 39)
        Me.btnChangeSpriteCancel.Name = "btnChangeSpriteCancel"
        Me.btnChangeSpriteCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeSpriteCancel.TabIndex = 23
        Me.btnChangeSpriteCancel.Text = "Cancel"
        Me.btnChangeSpriteCancel.UseVisualStyleBackColor = True
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
        'fraChangeClass
        '
        Me.fraChangeClass.Controls.Add(Me.btnChangeClassOK)
        Me.fraChangeClass.Controls.Add(Me.btnChangeClassCancel)
        Me.fraChangeClass.Controls.Add(Me.cmbChangeClass)
        Me.fraChangeClass.Controls.Add(Me.lblRandomLabel29)
        Me.fraChangeClass.Location = New System.Drawing.Point(5, 165)
        Me.fraChangeClass.Name = "fraChangeClass"
        Me.fraChangeClass.Size = New System.Drawing.Size(246, 73)
        Me.fraChangeClass.TabIndex = 10
        Me.fraChangeClass.TabStop = False
        Me.fraChangeClass.Text = "Change Player Class"
        Me.fraChangeClass.Visible = False
        '
        'btnChangeClassOK
        '
        Me.btnChangeClassOK.Location = New System.Drawing.Point(57, 43)
        Me.btnChangeClassOK.Name = "btnChangeClassOK"
        Me.btnChangeClassOK.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeClassOK.TabIndex = 22
        Me.btnChangeClassOK.Text = "Ok"
        Me.btnChangeClassOK.UseVisualStyleBackColor = True
        '
        'btnChangeClassCancel
        '
        Me.btnChangeClassCancel.Location = New System.Drawing.Point(138, 43)
        Me.btnChangeClassCancel.Name = "btnChangeClassCancel"
        Me.btnChangeClassCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeClassCancel.TabIndex = 21
        Me.btnChangeClassCancel.Text = "Cancel"
        Me.btnChangeClassCancel.UseVisualStyleBackColor = True
        '
        'cmbChangeClass
        '
        Me.cmbChangeClass.FormattingEnabled = True
        Me.cmbChangeClass.Location = New System.Drawing.Point(47, 16)
        Me.cmbChangeClass.Name = "cmbChangeClass"
        Me.cmbChangeClass.Size = New System.Drawing.Size(190, 21)
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
        'fraChangeLevel
        '
        Me.fraChangeLevel.Controls.Add(Me.btnChangeLevelOK)
        Me.fraChangeLevel.Controls.Add(Me.btnChangeLevelCancel)
        Me.fraChangeLevel.Controls.Add(Me.scrlChangeLevel)
        Me.fraChangeLevel.Controls.Add(Me.lblChangeLevel)
        Me.fraChangeLevel.Location = New System.Drawing.Point(7, 11)
        Me.fraChangeLevel.Name = "fraChangeLevel"
        Me.fraChangeLevel.Size = New System.Drawing.Size(244, 83)
        Me.fraChangeLevel.TabIndex = 8
        Me.fraChangeLevel.TabStop = False
        Me.fraChangeLevel.Text = "Change Level"
        Me.fraChangeLevel.Visible = False
        '
        'btnChangeLevelOK
        '
        Me.btnChangeLevelOK.Location = New System.Drawing.Point(57, 55)
        Me.btnChangeLevelOK.Name = "btnChangeLevelOK"
        Me.btnChangeLevelOK.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeLevelOK.TabIndex = 20
        Me.btnChangeLevelOK.Text = "Ok"
        Me.btnChangeLevelOK.UseVisualStyleBackColor = True
        '
        'btnChangeLevelCancel
        '
        Me.btnChangeLevelCancel.Location = New System.Drawing.Point(138, 55)
        Me.btnChangeLevelCancel.Name = "btnChangeLevelCancel"
        Me.btnChangeLevelCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeLevelCancel.TabIndex = 19
        Me.btnChangeLevelCancel.Text = "Cancel"
        Me.btnChangeLevelCancel.UseVisualStyleBackColor = True
        '
        'scrlChangeLevel
        '
        Me.scrlChangeLevel.Location = New System.Drawing.Point(4, 33)
        Me.scrlChangeLevel.Name = "scrlChangeLevel"
        Me.scrlChangeLevel.Size = New System.Drawing.Size(229, 17)
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
        'fraChangeItems
        '
        Me.fraChangeItems.Controls.Add(Me.btnChangeItemsOk)
        Me.fraChangeItems.Controls.Add(Me.btnChangeItemsCancel)
        Me.fraChangeItems.Controls.Add(Me.txtChangeItemsAmount)
        Me.fraChangeItems.Controls.Add(Me.optChangeItemRemove)
        Me.fraChangeItems.Controls.Add(Me.optChangeItemAdd)
        Me.fraChangeItems.Controls.Add(Me.optChangeItemSet)
        Me.fraChangeItems.Controls.Add(Me.cmbChangeItemIndex)
        Me.fraChangeItems.Controls.Add(Me.lblRandomLabel27)
        Me.fraChangeItems.Location = New System.Drawing.Point(3, 303)
        Me.fraChangeItems.Name = "fraChangeItems"
        Me.fraChangeItems.Size = New System.Drawing.Size(245, 118)
        Me.fraChangeItems.TabIndex = 7
        Me.fraChangeItems.TabStop = False
        Me.fraChangeItems.Text = "Change Items"
        Me.fraChangeItems.Visible = False
        '
        'btnChangeItemsOk
        '
        Me.btnChangeItemsOk.Location = New System.Drawing.Point(57, 88)
        Me.btnChangeItemsOk.Name = "btnChangeItemsOk"
        Me.btnChangeItemsOk.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeItemsOk.TabIndex = 14
        Me.btnChangeItemsOk.Text = "Ok"
        Me.btnChangeItemsOk.UseVisualStyleBackColor = True
        '
        'btnChangeItemsCancel
        '
        Me.btnChangeItemsCancel.Location = New System.Drawing.Point(138, 88)
        Me.btnChangeItemsCancel.Name = "btnChangeItemsCancel"
        Me.btnChangeItemsCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeItemsCancel.TabIndex = 13
        Me.btnChangeItemsCancel.Text = "Cancel"
        Me.btnChangeItemsCancel.UseVisualStyleBackColor = True
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
        'fraSetSelfSwitch
        '
        Me.fraSetSelfSwitch.Controls.Add(Me.btnSelfswitchOk)
        Me.fraSetSelfSwitch.Controls.Add(Me.btnSelfswitchCancel)
        Me.fraSetSelfSwitch.Controls.Add(Me.lblRandomLabel26)
        Me.fraSetSelfSwitch.Controls.Add(Me.lblRandomLabel24)
        Me.fraSetSelfSwitch.Controls.Add(Me.cmbSetSelfSwitchTo)
        Me.fraSetSelfSwitch.Controls.Add(Me.cmbSetSelfSwitch)
        Me.fraSetSelfSwitch.Location = New System.Drawing.Point(6, 368)
        Me.fraSetSelfSwitch.Name = "fraSetSelfSwitch"
        Me.fraSetSelfSwitch.Size = New System.Drawing.Size(245, 100)
        Me.fraSetSelfSwitch.TabIndex = 6
        Me.fraSetSelfSwitch.TabStop = False
        Me.fraSetSelfSwitch.Text = "Self Switch"
        Me.fraSetSelfSwitch.Visible = False
        '
        'btnSelfswitchOk
        '
        Me.btnSelfswitchOk.Location = New System.Drawing.Point(81, 71)
        Me.btnSelfswitchOk.Name = "btnSelfswitchOk"
        Me.btnSelfswitchOk.Size = New System.Drawing.Size(75, 23)
        Me.btnSelfswitchOk.TabIndex = 18
        Me.btnSelfswitchOk.Text = "Ok"
        Me.btnSelfswitchOk.UseVisualStyleBackColor = True
        '
        'btnSelfswitchCancel
        '
        Me.btnSelfswitchCancel.Location = New System.Drawing.Point(162, 71)
        Me.btnSelfswitchCancel.Name = "btnSelfswitchCancel"
        Me.btnSelfswitchCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSelfswitchCancel.TabIndex = 17
        Me.btnSelfswitchCancel.Text = "Cancel"
        Me.btnSelfswitchCancel.UseVisualStyleBackColor = True
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
        'fraPlayerVariable
        '
        Me.fraPlayerVariable.Controls.Add(Me.btnPlayerVarOk)
        Me.fraPlayerVariable.Controls.Add(Me.btnPlayerVarCancel)
        Me.fraPlayerVariable.Controls.Add(Me.lblRandomLabel37)
        Me.fraPlayerVariable.Controls.Add(Me.lblRandomLabel13)
        Me.fraPlayerVariable.Controls.Add(Me.txtVariableData4)
        Me.fraPlayerVariable.Controls.Add(Me.txtVariableData3)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction3)
        Me.fraPlayerVariable.Controls.Add(Me.txtVariableData2)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction2)
        Me.fraPlayerVariable.Controls.Add(Me.txtVariableData1)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction1)
        Me.fraPlayerVariable.Controls.Add(Me.txtVariableData0)
        Me.fraPlayerVariable.Controls.Add(Me.optVariableAction0)
        Me.fraPlayerVariable.Controls.Add(Me.cmbVariable)
        Me.fraPlayerVariable.Controls.Add(Me.lblRandomLabel)
        Me.fraPlayerVariable.Location = New System.Drawing.Point(5, 166)
        Me.fraPlayerVariable.Name = "fraPlayerVariable"
        Me.fraPlayerVariable.Size = New System.Drawing.Size(245, 171)
        Me.fraPlayerVariable.TabIndex = 1
        Me.fraPlayerVariable.TabStop = False
        Me.fraPlayerVariable.Text = "Player Variable"
        Me.fraPlayerVariable.Visible = False
        '
        'btnPlayerVarOk
        '
        Me.btnPlayerVarOk.Location = New System.Drawing.Point(83, 142)
        Me.btnPlayerVarOk.Name = "btnPlayerVarOk"
        Me.btnPlayerVarOk.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayerVarOk.TabIndex = 6
        Me.btnPlayerVarOk.Text = "Ok"
        Me.btnPlayerVarOk.UseVisualStyleBackColor = True
        '
        'btnPlayerVarCancel
        '
        Me.btnPlayerVarCancel.Location = New System.Drawing.Point(164, 142)
        Me.btnPlayerVarCancel.Name = "btnPlayerVarCancel"
        Me.btnPlayerVarCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayerVarCancel.TabIndex = 5
        Me.btnPlayerVarCancel.Text = "Cancel"
        Me.btnPlayerVarCancel.UseVisualStyleBackColor = True
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
        Me.optVariableAction0.Checked = True
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
        'fraShowChatBubble
        '
        Me.fraShowChatBubble.Controls.Add(Me.btnShowChatBubbleOK)
        Me.fraShowChatBubble.Controls.Add(Me.btnShowChatBubbleCancel)
        Me.fraShowChatBubble.Controls.Add(Me.cmbChatBubbleTarget)
        Me.fraShowChatBubble.Controls.Add(Me.optChatBubbleTarget2)
        Me.fraShowChatBubble.Controls.Add(Me.optChatBubbleTarget1)
        Me.fraShowChatBubble.Controls.Add(Me.optChatBubbleTarget0)
        Me.fraShowChatBubble.Controls.Add(Me.lblRandomLabel39)
        Me.fraShowChatBubble.Controls.Add(Me.txtChatbubbleText)
        Me.fraShowChatBubble.Controls.Add(Me.lblRandomLabel38)
        Me.fraShowChatBubble.Location = New System.Drawing.Point(6, 12)
        Me.fraShowChatBubble.Name = "fraShowChatBubble"
        Me.fraShowChatBubble.Size = New System.Drawing.Size(245, 153)
        Me.fraShowChatBubble.TabIndex = 19
        Me.fraShowChatBubble.TabStop = False
        Me.fraShowChatBubble.Text = "Show Chatbubble"
        Me.fraShowChatBubble.Visible = False
        '
        'btnShowChatBubbleOK
        '
        Me.btnShowChatBubbleOK.Location = New System.Drawing.Point(57, 122)
        Me.btnShowChatBubbleOK.Name = "btnShowChatBubbleOK"
        Me.btnShowChatBubbleOK.Size = New System.Drawing.Size(75, 23)
        Me.btnShowChatBubbleOK.TabIndex = 24
        Me.btnShowChatBubbleOK.Text = "Ok"
        Me.btnShowChatBubbleOK.UseVisualStyleBackColor = True
        '
        'btnShowChatBubbleCancel
        '
        Me.btnShowChatBubbleCancel.Location = New System.Drawing.Point(138, 122)
        Me.btnShowChatBubbleCancel.Name = "btnShowChatBubbleCancel"
        Me.btnShowChatBubbleCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnShowChatBubbleCancel.TabIndex = 23
        Me.btnShowChatBubbleCancel.Text = "Cancel"
        Me.btnShowChatBubbleCancel.UseVisualStyleBackColor = True
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
        Me.txtChatbubbleText.Size = New System.Drawing.Size(230, 20)
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
        'fraGiveExp
        '
        Me.fraGiveExp.Controls.Add(Me.btnGiveExpOK)
        Me.fraGiveExp.Controls.Add(Me.btnGiveExpCancel)
        Me.fraGiveExp.Controls.Add(Me.lblGiveExp)
        Me.fraGiveExp.Controls.Add(Me.scrlGiveExp)
        Me.fraGiveExp.Location = New System.Drawing.Point(260, 264)
        Me.fraGiveExp.Name = "fraGiveExp"
        Me.fraGiveExp.Size = New System.Drawing.Size(245, 91)
        Me.fraGiveExp.TabIndex = 14
        Me.fraGiveExp.TabStop = False
        Me.fraGiveExp.Text = "Give Experience"
        Me.fraGiveExp.Visible = False
        '
        'btnGiveExpOK
        '
        Me.btnGiveExpOK.Location = New System.Drawing.Point(57, 62)
        Me.btnGiveExpOK.Name = "btnGiveExpOK"
        Me.btnGiveExpOK.Size = New System.Drawing.Size(75, 23)
        Me.btnGiveExpOK.TabIndex = 18
        Me.btnGiveExpOK.Text = "Ok"
        Me.btnGiveExpOK.UseVisualStyleBackColor = True
        '
        'btnGiveExpCancel
        '
        Me.btnGiveExpCancel.Location = New System.Drawing.Point(138, 62)
        Me.btnGiveExpCancel.Name = "btnGiveExpCancel"
        Me.btnGiveExpCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnGiveExpCancel.TabIndex = 17
        Me.btnGiveExpCancel.Text = "Cancel"
        Me.btnGiveExpCancel.UseVisualStyleBackColor = True
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
        'fraShowText
        '
        Me.fraShowText.Controls.Add(Me.btnShowTextOk)
        Me.fraShowText.Controls.Add(Me.btnShowTextCancel)
        Me.fraShowText.Controls.Add(Me.scrlShowTextFace)
        Me.fraShowText.Controls.Add(Me.lblShowTextFace)
        Me.fraShowText.Controls.Add(Me.picShowTextFace)
        Me.fraShowText.Controls.Add(Me.txtShowText)
        Me.fraShowText.Controls.Add(Me.lblRandomLabel18)
        Me.fraShowText.Location = New System.Drawing.Point(6, 236)
        Me.fraShowText.Name = "fraShowText"
        Me.fraShowText.Size = New System.Drawing.Size(245, 319)
        Me.fraShowText.TabIndex = 15
        Me.fraShowText.TabStop = False
        Me.fraShowText.Text = "Show Text"
        Me.fraShowText.Visible = False
        '
        'btnShowTextOk
        '
        Me.btnShowTextOk.Location = New System.Drawing.Point(83, 293)
        Me.btnShowTextOk.Name = "btnShowTextOk"
        Me.btnShowTextOk.Size = New System.Drawing.Size(75, 23)
        Me.btnShowTextOk.TabIndex = 20
        Me.btnShowTextOk.Text = "Ok"
        Me.btnShowTextOk.UseVisualStyleBackColor = True
        '
        'btnShowTextCancel
        '
        Me.btnShowTextCancel.Location = New System.Drawing.Point(164, 293)
        Me.btnShowTextCancel.Name = "btnShowTextCancel"
        Me.btnShowTextCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnShowTextCancel.TabIndex = 19
        Me.btnShowTextCancel.Text = "Cancel"
        Me.btnShowTextCancel.UseVisualStyleBackColor = True
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
        Me.picShowTextFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
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
        'fraPlayerWarp
        '
        Me.fraPlayerWarp.Controls.Add(Me.cmbWarpPlayerDir)
        Me.fraPlayerWarp.Controls.Add(Me.scrlWPY)
        Me.fraPlayerWarp.Controls.Add(Me.lblWPY)
        Me.fraPlayerWarp.Controls.Add(Me.lblWPX)
        Me.fraPlayerWarp.Controls.Add(Me.scrlWPX)
        Me.fraPlayerWarp.Controls.Add(Me.btnPlayerWarpOK)
        Me.fraPlayerWarp.Controls.Add(Me.btnPlayerWarpCancel)
        Me.fraPlayerWarp.Controls.Add(Me.lblWPMap)
        Me.fraPlayerWarp.Controls.Add(Me.scrlWPMap)
        Me.fraPlayerWarp.Location = New System.Drawing.Point(260, 112)
        Me.fraPlayerWarp.Name = "fraPlayerWarp"
        Me.fraPlayerWarp.Size = New System.Drawing.Size(245, 145)
        Me.fraPlayerWarp.TabIndex = 32
        Me.fraPlayerWarp.TabStop = False
        Me.fraPlayerWarp.Text = "Warp Player"
        Me.fraPlayerWarp.Visible = False
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
        'btnPlayerWarpOK
        '
        Me.btnPlayerWarpOK.Location = New System.Drawing.Point(83, 116)
        Me.btnPlayerWarpOK.Name = "btnPlayerWarpOK"
        Me.btnPlayerWarpOK.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayerWarpOK.TabIndex = 20
        Me.btnPlayerWarpOK.Text = "Ok"
        Me.btnPlayerWarpOK.UseVisualStyleBackColor = True
        '
        'btnPlayerWarpCancel
        '
        Me.btnPlayerWarpCancel.Location = New System.Drawing.Point(164, 116)
        Me.btnPlayerWarpCancel.Name = "btnPlayerWarpCancel"
        Me.btnPlayerWarpCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnPlayerWarpCancel.TabIndex = 19
        Me.btnPlayerWarpCancel.Text = "Cancel"
        Me.btnPlayerWarpCancel.UseVisualStyleBackColor = True
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
        'fraHidePic
        '
        Me.fraHidePic.Controls.Add(Me.lblRandomLabel58)
        Me.fraHidePic.Controls.Add(Me.btnHidePicOK)
        Me.fraHidePic.Controls.Add(Me.btnHidePicCancel)
        Me.fraHidePic.Controls.Add(Me.cmbHidePic)
        Me.fraHidePic.Location = New System.Drawing.Point(272, 27)
        Me.fraHidePic.Name = "fraHidePic"
        Me.fraHidePic.Size = New System.Drawing.Size(219, 69)
        Me.fraHidePic.TabIndex = 31
        Me.fraHidePic.TabStop = False
        Me.fraHidePic.Text = "Hide Picture"
        Me.fraHidePic.Visible = False
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
        'btnHidePicOK
        '
        Me.btnHidePicOK.Location = New System.Drawing.Point(57, 40)
        Me.btnHidePicOK.Name = "btnHidePicOK"
        Me.btnHidePicOK.Size = New System.Drawing.Size(75, 23)
        Me.btnHidePicOK.TabIndex = 26
        Me.btnHidePicOK.Text = "Ok"
        Me.btnHidePicOK.UseVisualStyleBackColor = True
        '
        'btnHidePicCancel
        '
        Me.btnHidePicCancel.Location = New System.Drawing.Point(138, 40)
        Me.btnHidePicCancel.Name = "btnHidePicCancel"
        Me.btnHidePicCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnHidePicCancel.TabIndex = 25
        Me.btnHidePicCancel.Text = "Cancel"
        Me.btnHidePicCancel.UseVisualStyleBackColor = True
        '
        'cmbHidePic
        '
        Me.cmbHidePic.FormattingEnabled = True
        Me.cmbHidePic.Location = New System.Drawing.Point(88, 13)
        Me.cmbHidePic.Name = "cmbHidePic"
        Me.cmbHidePic.Size = New System.Drawing.Size(125, 21)
        Me.cmbHidePic.TabIndex = 2
        '
        'fraPlayerSwitch
        '
        Me.fraPlayerSwitch.Controls.Add(Me.btnSetPlayerSwitchOk)
        Me.fraPlayerSwitch.Controls.Add(Me.btnSetPlayerswitchCancel)
        Me.fraPlayerSwitch.Controls.Add(Me.lblRandomLabel22)
        Me.fraPlayerSwitch.Controls.Add(Me.lblRandomLabel23)
        Me.fraPlayerSwitch.Controls.Add(Me.cmbPlayerSwitchSet)
        Me.fraPlayerSwitch.Controls.Add(Me.cmbSwitch)
        Me.fraPlayerSwitch.Location = New System.Drawing.Point(5, 13)
        Me.fraPlayerSwitch.Name = "fraPlayerSwitch"
        Me.fraPlayerSwitch.Size = New System.Drawing.Size(245, 98)
        Me.fraPlayerSwitch.TabIndex = 5
        Me.fraPlayerSwitch.TabStop = False
        Me.fraPlayerSwitch.Text = "Player Switch"
        Me.fraPlayerSwitch.Visible = False
        '
        'btnSetPlayerSwitchOk
        '
        Me.btnSetPlayerSwitchOk.Location = New System.Drawing.Point(83, 70)
        Me.btnSetPlayerSwitchOk.Name = "btnSetPlayerSwitchOk"
        Me.btnSetPlayerSwitchOk.Size = New System.Drawing.Size(75, 23)
        Me.btnSetPlayerSwitchOk.TabIndex = 12
        Me.btnSetPlayerSwitchOk.Text = "Ok"
        Me.btnSetPlayerSwitchOk.UseVisualStyleBackColor = True
        '
        'btnSetPlayerswitchCancel
        '
        Me.btnSetPlayerswitchCancel.Location = New System.Drawing.Point(164, 70)
        Me.btnSetPlayerswitchCancel.Name = "btnSetPlayerswitchCancel"
        Me.btnSetPlayerswitchCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnSetPlayerswitchCancel.TabIndex = 11
        Me.btnSetPlayerswitchCancel.Text = "Cancel"
        Me.btnSetPlayerswitchCancel.UseVisualStyleBackColor = True
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
        'fraCreateLabel
        '
        Me.fraCreateLabel.Controls.Add(Me.btnCreatelabelOk)
        Me.fraCreateLabel.Controls.Add(Me.txtLabelName)
        Me.fraCreateLabel.Controls.Add(Me.btnCreateLabelCancel)
        Me.fraCreateLabel.Controls.Add(Me.lblRandomLabel40)
        Me.fraCreateLabel.Location = New System.Drawing.Point(254, 12)
        Me.fraCreateLabel.Name = "fraCreateLabel"
        Me.fraCreateLabel.Size = New System.Drawing.Size(219, 100)
        Me.fraCreateLabel.TabIndex = 3
        Me.fraCreateLabel.TabStop = False
        Me.fraCreateLabel.Text = "Create Label"
        Me.fraCreateLabel.Visible = False
        '
        'btnCreatelabelOk
        '
        Me.btnCreatelabelOk.Location = New System.Drawing.Point(57, 71)
        Me.btnCreatelabelOk.Name = "btnCreatelabelOk"
        Me.btnCreatelabelOk.Size = New System.Drawing.Size(75, 23)
        Me.btnCreatelabelOk.TabIndex = 6
        Me.btnCreatelabelOk.Text = "Ok"
        Me.btnCreatelabelOk.UseVisualStyleBackColor = True
        '
        'txtLabelName
        '
        Me.txtLabelName.Location = New System.Drawing.Point(6, 35)
        Me.txtLabelName.Name = "txtLabelName"
        Me.txtLabelName.Size = New System.Drawing.Size(207, 20)
        Me.txtLabelName.TabIndex = 1
        '
        'btnCreateLabelCancel
        '
        Me.btnCreateLabelCancel.Location = New System.Drawing.Point(138, 71)
        Me.btnCreateLabelCancel.Name = "btnCreateLabelCancel"
        Me.btnCreateLabelCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateLabelCancel.TabIndex = 5
        Me.btnCreateLabelCancel.Text = "Cancel"
        Me.btnCreateLabelCancel.UseVisualStyleBackColor = True
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
        'fraGoToLabel
        '
        Me.fraGoToLabel.Controls.Add(Me.btnGoToLabelOk)
        Me.fraGoToLabel.Controls.Add(Me.txtGotoLabel)
        Me.fraGoToLabel.Controls.Add(Me.btnGoToLabelCancel)
        Me.fraGoToLabel.Controls.Add(Me.lblRandomLabel41)
        Me.fraGoToLabel.Location = New System.Drawing.Point(253, 105)
        Me.fraGoToLabel.Name = "fraGoToLabel"
        Me.fraGoToLabel.Size = New System.Drawing.Size(219, 97)
        Me.fraGoToLabel.TabIndex = 4
        Me.fraGoToLabel.TabStop = False
        Me.fraGoToLabel.Text = "GoTo Label:"
        Me.fraGoToLabel.Visible = False
        '
        'btnGoToLabelOk
        '
        Me.btnGoToLabelOk.Location = New System.Drawing.Point(57, 69)
        Me.btnGoToLabelOk.Name = "btnGoToLabelOk"
        Me.btnGoToLabelOk.Size = New System.Drawing.Size(75, 23)
        Me.btnGoToLabelOk.TabIndex = 10
        Me.btnGoToLabelOk.Text = "Ok"
        Me.btnGoToLabelOk.UseVisualStyleBackColor = True
        '
        'txtGotoLabel
        '
        Me.txtGotoLabel.Location = New System.Drawing.Point(6, 33)
        Me.txtGotoLabel.Name = "txtGotoLabel"
        Me.txtGotoLabel.Size = New System.Drawing.Size(207, 20)
        Me.txtGotoLabel.TabIndex = 8
        '
        'btnGoToLabelCancel
        '
        Me.btnGoToLabelCancel.Location = New System.Drawing.Point(138, 69)
        Me.btnGoToLabelCancel.Name = "btnGoToLabelCancel"
        Me.btnGoToLabelCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnGoToLabelCancel.TabIndex = 9
        Me.btnGoToLabelCancel.Text = "Cancel"
        Me.btnGoToLabelCancel.UseVisualStyleBackColor = True
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
        Me.lblRandomLabel14.Location = New System.Drawing.Point(196, 627)
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
        ListViewGroup10.Header = "Messages"
        ListViewGroup10.Name = "lstVgMessages"
        ListViewGroup11.Header = "Events Progressing"
        ListViewGroup11.Name = "lstVgEvents"
        ListViewGroup12.Header = "Flow Control"
        ListViewGroup12.Name = "lstVgFlow"
        ListViewGroup13.Header = "Player Options"
        ListViewGroup13.Name = "lstVgPlayerOptions"
        ListViewGroup14.Header = "Movement"
        ListViewGroup14.Name = "lstVgMovement"
        ListViewGroup15.Header = "Animation"
        ListViewGroup15.Name = "lstVgAnimation"
        ListViewGroup16.Header = "Questing"
        ListViewGroup16.Name = "lstVgQuesting"
        ListViewGroup17.Header = "Map Functions"
        ListViewGroup17.Name = "lstVgMapFunctions"
        ListViewGroup18.Header = "Music and Sound"
        ListViewGroup18.Name = "lstVgSound"
        ListViewGroup19.Header = "Etc..."
        ListViewGroup19.Name = "lstVgEtc"
        ListViewGroup20.Header = "Shop and Bank"
        ListViewGroup20.Name = "lstVgShopBank"
        ListViewGroup21.Header = "Cut-scene Options"
        ListViewGroup21.Name = "lstVgCutScene"
        Me.lstvCommands.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup10, ListViewGroup11, ListViewGroup12, ListViewGroup13, ListViewGroup14, ListViewGroup15, ListViewGroup16, ListViewGroup17, ListViewGroup18, ListViewGroup19, ListViewGroup20, ListViewGroup21})
        Me.lstvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        ListViewItem44.Group = ListViewGroup10
        ListViewItem45.Group = ListViewGroup10
        ListViewItem45.IndentCount = 1
        ListViewItem46.Group = ListViewGroup10
        ListViewItem47.Group = ListViewGroup10
        ListViewItem47.IndentCount = 1
        ListViewItem48.Group = ListViewGroup11
        ListViewItem49.Group = ListViewGroup11
        ListViewItem50.Group = ListViewGroup11
        ListViewItem51.Group = ListViewGroup12
        ListViewItem52.Group = ListViewGroup12
        ListViewItem53.Group = ListViewGroup12
        ListViewItem54.Group = ListViewGroup12
        ListViewItem55.Group = ListViewGroup13
        ListViewItem56.Group = ListViewGroup13
        ListViewItem57.Group = ListViewGroup13
        ListViewItem58.Group = ListViewGroup13
        ListViewItem59.Group = ListViewGroup13
        ListViewItem60.Group = ListViewGroup13
        ListViewItem61.Group = ListViewGroup13
        ListViewItem62.Group = ListViewGroup13
        ListViewItem63.Group = ListViewGroup13
        ListViewItem64.Group = ListViewGroup13
        ListViewItem65.Group = ListViewGroup13
        ListViewItem66.Group = ListViewGroup14
        ListViewItem67.Group = ListViewGroup14
        ListViewItem68.Group = ListViewGroup14
        ListViewItem69.Group = ListViewGroup14
        ListViewItem70.Group = ListViewGroup14
        ListViewItem71.Group = ListViewGroup14
        ListViewItem72.Group = ListViewGroup15
        ListViewItem73.Group = ListViewGroup16
        ListViewItem74.Group = ListViewGroup16
        ListViewItem75.Group = ListViewGroup16
        ListViewItem76.Group = ListViewGroup17
        ListViewItem77.Group = ListViewGroup17
        ListViewItem78.Group = ListViewGroup17
        ListViewItem79.Group = ListViewGroup18
        ListViewItem80.Group = ListViewGroup18
        ListViewItem81.Group = ListViewGroup18
        ListViewItem82.Group = ListViewGroup18
        ListViewItem83.Group = ListViewGroup19
        ListViewItem84.Group = ListViewGroup19
        ListViewItem85.Group = ListViewGroup19
        ListViewItem86.Group = ListViewGroup20
        ListViewItem87.Group = ListViewGroup20
        Me.lstvCommands.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem44, ListViewItem45, ListViewItem46, ListViewItem47, ListViewItem48, ListViewItem49, ListViewItem50, ListViewItem51, ListViewItem52, ListViewItem53, ListViewItem54, ListViewItem55, ListViewItem56, ListViewItem57, ListViewItem58, ListViewItem59, ListViewItem60, ListViewItem61, ListViewItem62, ListViewItem63, ListViewItem64, ListViewItem65, ListViewItem66, ListViewItem67, ListViewItem68, ListViewItem69, ListViewItem70, ListViewItem71, ListViewItem72, ListViewItem73, ListViewItem74, ListViewItem75, ListViewItem76, ListViewItem77, ListViewItem78, ListViewItem79, ListViewItem80, ListViewItem81, ListViewItem82, ListViewItem83, ListViewItem84, ListViewItem85, ListViewItem86, ListViewItem87})
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
        Me.picGraphic.Location = New System.Drawing.Point(6, 17)
        Me.picGraphic.Name = "picGraphic"
        Me.picGraphic.Size = New System.Drawing.Size(161, 207)
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
        Me.cmbPlayerSwitchCompare.Items.AddRange(New Object() {"False = 0", "True = 1"})
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
        Me.Panel2.Size = New System.Drawing.Size(815, 516)
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
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(672, 616)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(753, 617)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditor_Events
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1681, 644)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tabPages)
        Me.Controls.Add(Me.frarandom20)
        Me.Controls.Add(Me.lblRandomLabel14)
        Me.Controls.Add(Me.lblRandomLabel11)
        Me.Controls.Add(Me.fraDialogue)
        Me.Controls.Add(Me.btnLabeling)
        Me.Controls.Add(Me.pnlVariableSwitches)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnlMoveRoute)
        Me.Controls.Add(Me.fraGraphic)
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
        Me.pnlGraphicSelect.ResumeLayout(False)
        CType(Me.picGraphicSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMoveRoute.ResumeLayout(False)
        Me.fraMoveRoute.ResumeLayout(False)
        Me.fraMoveRoute.PerformLayout()
        Me.fraRandom14.ResumeLayout(False)
        Me.tabPages.ResumeLayout(False)
        Me.frarandom20.ResumeLayout(False)
        Me.frarandom20.PerformLayout()
        Me.fraDialogue.ResumeLayout(False)
        Me.fraSpawnNpc.ResumeLayout(False)
        Me.fraSpawnNpc.PerformLayout()
        Me.fraShowChoices.ResumeLayout(False)
        Me.fraShowChoices.PerformLayout()
        CType(Me.picShowChoicesFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraAddText.ResumeLayout(False)
        Me.fraAddText.PerformLayout()
        Me.fraConditionalBranch.ResumeLayout(False)
        Me.fraConditionalBranch.PerformLayout()
        Me.fraConditions_Quest.ResumeLayout(False)
        Me.fraConditions_Quest.PerformLayout()
        Me.fraOpenShop.ResumeLayout(False)
        Me.fraShowPic.ResumeLayout(False)
        Me.fraShowPic.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCustomScript.ResumeLayout(False)
        Me.fraCustomScript.PerformLayout()
        Me.fraSetAccess.ResumeLayout(False)
        Me.fraSetWait.ResumeLayout(False)
        Me.fraSetWait.PerformLayout()
        Me.fraPlaySound.ResumeLayout(False)
        Me.fraPlayBGM.ResumeLayout(False)
        Me.fraMapTint.ResumeLayout(False)
        Me.fraMapTint.PerformLayout()
        Me.fraSetWeather.ResumeLayout(False)
        Me.fraSetWeather.PerformLayout()
        Me.fraSetFog.ResumeLayout(False)
        Me.fraSetFog.PerformLayout()
        Me.fraEndQuest.ResumeLayout(False)
        Me.fraEndQuest.PerformLayout()
        Me.fraCompleteTask.ResumeLayout(False)
        Me.fraCompleteTask.PerformLayout()
        Me.fraBeginQuest.ResumeLayout(False)
        Me.fraBeginQuest.PerformLayout()
        Me.fraPlayAnimation.ResumeLayout(False)
        Me.fraPlayAnimation.PerformLayout()
        Me.fraMoveRouteWait.ResumeLayout(False)
        Me.fraMoveRouteWait.PerformLayout()
        Me.fraChangePK.ResumeLayout(False)
        Me.fraChangePK.PerformLayout()
        Me.fraChangeGender.ResumeLayout(False)
        Me.fraChangeGender.PerformLayout()
        Me.fraChangeSkills.ResumeLayout(False)
        Me.fraChangeSkills.PerformLayout()
        Me.fraChangeSprite.ResumeLayout(False)
        Me.fraChangeSprite.PerformLayout()
        Me.fraChangeClass.ResumeLayout(False)
        Me.fraChangeClass.PerformLayout()
        Me.fraChangeLevel.ResumeLayout(False)
        Me.fraChangeLevel.PerformLayout()
        Me.fraChangeItems.ResumeLayout(False)
        Me.fraChangeItems.PerformLayout()
        Me.fraSetSelfSwitch.ResumeLayout(False)
        Me.fraSetSelfSwitch.PerformLayout()
        Me.fraPlayerVariable.ResumeLayout(False)
        Me.fraPlayerVariable.PerformLayout()
        Me.fraShowChatBubble.ResumeLayout(False)
        Me.fraShowChatBubble.PerformLayout()
        Me.fraGiveExp.ResumeLayout(False)
        Me.fraGiveExp.PerformLayout()
        Me.fraShowText.ResumeLayout(False)
        Me.fraShowText.PerformLayout()
        CType(Me.picShowTextFace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPlayerWarp.ResumeLayout(False)
        Me.fraPlayerWarp.PerformLayout()
        Me.fraHidePic.ResumeLayout(False)
        Me.fraHidePic.PerformLayout()
        Me.fraPlayerSwitch.ResumeLayout(False)
        Me.fraPlayerSwitch.PerformLayout()
        Me.fraCreateLabel.ResumeLayout(False)
        Me.fraCreateLabel.PerformLayout()
        Me.fraGoToLabel.ResumeLayout(False)
        Me.fraGoToLabel.PerformLayout()
        Me.fraCommands.ResumeLayout(False)
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
    Friend WithEvents fraCompleteTask As Windows.Forms.GroupBox
    Friend WithEvents btnCompleteQuestTaskOK As Windows.Forms.Button
    Friend WithEvents btnCompleteQuestTaskCancel As Windows.Forms.Button
    Friend WithEvents scrlCompleteQuestTask As Windows.Forms.HScrollBar
    Friend WithEvents scrlCompleteQuestTaskQuest As Windows.Forms.HScrollBar
    Friend WithEvents lblRandomLabel48 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel47 As Windows.Forms.Label
    Friend WithEvents fraPlayerVariable As Windows.Forms.GroupBox
    Friend WithEvents btnPlayerVarOk As Windows.Forms.Button
    Friend WithEvents btnPlayerVarCancel As Windows.Forms.Button
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
    Friend WithEvents fraGoToLabel As Windows.Forms.GroupBox
    Friend WithEvents btnGoToLabelOk As Windows.Forms.Button
    Friend WithEvents txtGotoLabel As Windows.Forms.TextBox
    Friend WithEvents btnGoToLabelCancel As Windows.Forms.Button
    Friend WithEvents lblRandomLabel41 As Windows.Forms.Label
    Friend WithEvents fraCreateLabel As Windows.Forms.GroupBox
    Friend WithEvents btnCreatelabelOk As Windows.Forms.Button
    Friend WithEvents txtLabelName As Windows.Forms.TextBox
    Friend WithEvents btnCreateLabelCancel As Windows.Forms.Button
    Friend WithEvents lblRandomLabel40 As Windows.Forms.Label
    Friend WithEvents fraChangeClass As Windows.Forms.GroupBox
    Friend WithEvents btnChangeClassOK As Windows.Forms.Button
    Friend WithEvents btnChangeClassCancel As Windows.Forms.Button
    Friend WithEvents cmbChangeClass As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel29 As Windows.Forms.Label
    Friend WithEvents fraChangeSkills As Windows.Forms.GroupBox
    Friend WithEvents btnChangeSkillsOK As Windows.Forms.Button
    Friend WithEvents btnChangeSkillsCancel As Windows.Forms.Button
    Friend WithEvents optChangeSkillsRemove As Windows.Forms.RadioButton
    Friend WithEvents optChangeSkillsAdd As Windows.Forms.RadioButton
    Friend WithEvents cmbChangeSkills As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel28 As Windows.Forms.Label
    Friend WithEvents fraChangeLevel As Windows.Forms.GroupBox
    Friend WithEvents btnChangeLevelOK As Windows.Forms.Button
    Friend WithEvents btnChangeLevelCancel As Windows.Forms.Button
    Friend WithEvents scrlChangeLevel As Windows.Forms.HScrollBar
    Friend WithEvents lblChangeLevel As Windows.Forms.Label
    Friend WithEvents fraChangeItems As Windows.Forms.GroupBox
    Friend WithEvents btnChangeItemsOk As Windows.Forms.Button
    Friend WithEvents btnChangeItemsCancel As Windows.Forms.Button
    Friend WithEvents txtChangeItemsAmount As Windows.Forms.TextBox
    Friend WithEvents optChangeItemRemove As Windows.Forms.RadioButton
    Friend WithEvents optChangeItemAdd As Windows.Forms.RadioButton
    Friend WithEvents optChangeItemSet As Windows.Forms.RadioButton
    Friend WithEvents cmbChangeItemIndex As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel27 As Windows.Forms.Label
    Friend WithEvents fraSetSelfSwitch As Windows.Forms.GroupBox
    Friend WithEvents btnSelfswitchOk As Windows.Forms.Button
    Friend WithEvents btnSelfswitchCancel As Windows.Forms.Button
    Friend WithEvents lblRandomLabel26 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel24 As Windows.Forms.Label
    Friend WithEvents cmbSetSelfSwitchTo As Windows.Forms.ComboBox
    Friend WithEvents cmbSetSelfSwitch As Windows.Forms.ComboBox
    Friend WithEvents fraPlayerSwitch As Windows.Forms.GroupBox
    Friend WithEvents btnSetPlayerSwitchOk As Windows.Forms.Button
    Friend WithEvents btnSetPlayerswitchCancel As Windows.Forms.Button
    Friend WithEvents lblRandomLabel22 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel23 As Windows.Forms.Label
    Friend WithEvents cmbPlayerSwitchSet As Windows.Forms.ComboBox
    Friend WithEvents cmbSwitch As Windows.Forms.ComboBox
    Friend WithEvents fraChangeGender As Windows.Forms.GroupBox
    Friend WithEvents fraChangeSprite As Windows.Forms.GroupBox
    Friend WithEvents btnChangeSpriteOK As Windows.Forms.Button
    Friend WithEvents btnChangeSpriteCancel As Windows.Forms.Button
    Friend WithEvents scrlChangeSprite As Windows.Forms.HScrollBar
    Friend WithEvents lblChangeSprite As Windows.Forms.Label
    Friend WithEvents fraShowChoices As Windows.Forms.GroupBox
    Friend WithEvents txtChoices4 As Windows.Forms.TextBox
    Friend WithEvents txtChoices3 As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel21 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel20 As Windows.Forms.Label
    Friend WithEvents txtChoices2 As Windows.Forms.TextBox
    Friend WithEvents txtChoices1 As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel19 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel17 As Windows.Forms.Label
    Friend WithEvents btnShowChoicesOk As Windows.Forms.Button
    Friend WithEvents btnShowChoicesCancel As Windows.Forms.Button
    Friend WithEvents scrlShowChoicesFace As Windows.Forms.HScrollBar
    Friend WithEvents lblShowChoicesFace As Windows.Forms.Label
    Friend WithEvents picShowChoicesFace As Windows.Forms.PictureBox
    Friend WithEvents txtChoicePrompt As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel16 As Windows.Forms.Label
    Friend WithEvents fraShowText As Windows.Forms.GroupBox
    Friend WithEvents btnShowTextOk As Windows.Forms.Button
    Friend WithEvents btnShowTextCancel As Windows.Forms.Button
    Friend WithEvents scrlShowTextFace As Windows.Forms.HScrollBar
    Friend WithEvents lblShowTextFace As Windows.Forms.Label
    Friend WithEvents picShowTextFace As Windows.Forms.PictureBox
    Friend WithEvents txtShowText As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel18 As Windows.Forms.Label
    Friend WithEvents fraGiveExp As Windows.Forms.GroupBox
    Friend WithEvents btnGiveExpOK As Windows.Forms.Button
    Friend WithEvents btnGiveExpCancel As Windows.Forms.Button
    Friend WithEvents lblGiveExp As Windows.Forms.Label
    Friend WithEvents scrlGiveExp As Windows.Forms.HScrollBar
    Friend WithEvents fraChangePK As Windows.Forms.GroupBox
    Friend WithEvents btnChangePkOK As Windows.Forms.Button
    Friend WithEvents btnChangePkCancel As Windows.Forms.Button
    Friend WithEvents optChangePKNo As Windows.Forms.RadioButton
    Friend WithEvents optChangePKYes As Windows.Forms.RadioButton
    Friend WithEvents btnChangeGenderOK As Windows.Forms.Button
    Friend WithEvents btnChangeGenderCancel As Windows.Forms.Button
    Friend WithEvents optChangeSexFemale As Windows.Forms.RadioButton
    Friend WithEvents optChangeSexMale As Windows.Forms.RadioButton
    Friend WithEvents fraAddText As Windows.Forms.GroupBox
    Friend WithEvents btnAddTextOk As Windows.Forms.Button
    Friend WithEvents btnAddTextCancel As Windows.Forms.Button
    Friend WithEvents optAddText_Global As Windows.Forms.RadioButton
    Friend WithEvents optAddText_Map As Windows.Forms.RadioButton
    Friend WithEvents optAddText_Player As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel10 As Windows.Forms.Label
    Friend WithEvents lblAddText_Colour As Windows.Forms.Label
    Friend WithEvents scrlAddText_Colour As Windows.Forms.HScrollBar
    Friend WithEvents txtAddText_Text As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel34 As Windows.Forms.Label
    Friend WithEvents fraShowPic As Windows.Forms.GroupBox
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
    Friend WithEvents btnShowPicOK As Windows.Forms.Button
    Friend WithEvents btnShowPicCancel As Windows.Forms.Button
    Friend WithEvents scrlShowPicture As Windows.Forms.HScrollBar
    Friend WithEvents lblShowPic As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents cmbPicIndex As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel52 As Windows.Forms.Label
    Friend WithEvents fraOpenShop As Windows.Forms.GroupBox
    Friend WithEvents btnOpenShopOK As Windows.Forms.Button
    Friend WithEvents btnOpenShopCancel As Windows.Forms.Button
    Friend WithEvents cmbOpenShop As Windows.Forms.ComboBox
    Friend WithEvents fraSpawnNpc As Windows.Forms.GroupBox
    Friend WithEvents btnSpawnNpcOK As Windows.Forms.Button
    Friend WithEvents btnSpawnNpcCancel As Windows.Forms.Button
    Friend WithEvents cmbSpawnNPC As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel42 As Windows.Forms.Label
    Friend WithEvents fraShowChatBubble As Windows.Forms.GroupBox
    Friend WithEvents btnShowChatBubbleOK As Windows.Forms.Button
    Friend WithEvents btnShowChatBubbleCancel As Windows.Forms.Button
    Friend WithEvents cmbChatBubbleTarget As Windows.Forms.ComboBox
    Friend WithEvents optChatBubbleTarget2 As Windows.Forms.RadioButton
    Friend WithEvents optChatBubbleTarget1 As Windows.Forms.RadioButton
    Friend WithEvents optChatBubbleTarget0 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel39 As Windows.Forms.Label
    Friend WithEvents txtChatbubbleText As Windows.Forms.TextBox
    Friend WithEvents lblRandomLabel38 As Windows.Forms.Label
    Friend WithEvents fraMapTint As Windows.Forms.GroupBox
    Friend WithEvents scrlMapTintData3 As Windows.Forms.HScrollBar
    Friend WithEvents lblMapTintData3 As Windows.Forms.Label
    Friend WithEvents scrlMapTintData2 As Windows.Forms.HScrollBar
    Friend WithEvents lblMapTintData2 As Windows.Forms.Label
    Friend WithEvents lblMapTintData1 As Windows.Forms.Label
    Friend WithEvents scrlMapTintData1 As Windows.Forms.HScrollBar
    Friend WithEvents btnMapTintOK As Windows.Forms.Button
    Friend WithEvents btnMapTintCancel As Windows.Forms.Button
    Friend WithEvents lblMapTintData0 As Windows.Forms.Label
    Friend WithEvents scrlMapTintData0 As Windows.Forms.HScrollBar
    Friend WithEvents fraSetFog As Windows.Forms.GroupBox
    Friend WithEvents ScrlFogData2 As Windows.Forms.HScrollBar
    Friend WithEvents lblFogData2 As Windows.Forms.Label
    Friend WithEvents lblFogData1 As Windows.Forms.Label
    Friend WithEvents ScrlFogData1 As Windows.Forms.HScrollBar
    Friend WithEvents btnSetFogOK As Windows.Forms.Button
    Friend WithEvents btnSetFogCancel As Windows.Forms.Button
    Friend WithEvents lblFogData0 As Windows.Forms.Label
    Friend WithEvents ScrlFogData0 As Windows.Forms.HScrollBar
    Friend WithEvents fraPlayAnimation As Windows.Forms.GroupBox
    Friend WithEvents lblPlayAnimY As Windows.Forms.Label
    Friend WithEvents scrlPlayAnimTileY As Windows.Forms.HScrollBar
    Friend WithEvents cmbPlayAnim As Windows.Forms.ComboBox
    Friend WithEvents btnPlayAnimationOK As Windows.Forms.Button
    Friend WithEvents btnPlayAnimationCancel As Windows.Forms.Button
    Friend WithEvents optPlayAnimTile As Windows.Forms.RadioButton
    Friend WithEvents optPlayAnimEvent As Windows.Forms.RadioButton
    Friend WithEvents optPlayAnimPlayer As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel31 As Windows.Forms.Label
    Friend WithEvents lblPlayAnimX As Windows.Forms.Label
    Friend WithEvents scrlPlayAnimTileX As Windows.Forms.HScrollBar
    Friend WithEvents lblRandomLabel30 As Windows.Forms.Label
    Friend WithEvents fraPlaySound As Windows.Forms.GroupBox
    Friend WithEvents btnPlaySoundOK As Windows.Forms.Button
    Friend WithEvents btnPlaySoundCancel As Windows.Forms.Button
    Friend WithEvents cmbPlaySound As Windows.Forms.ComboBox
    Friend WithEvents fraSetAccess As Windows.Forms.GroupBox
    Friend WithEvents btnSetAccessOK As Windows.Forms.Button
    Friend WithEvents btnSetAccessCancel As Windows.Forms.Button
    Friend WithEvents cmbSetAccess As Windows.Forms.ComboBox
    Friend WithEvents fraPlayBGM As Windows.Forms.GroupBox
    Friend WithEvents btnPlayBgmOK As Windows.Forms.Button
    Friend WithEvents btnPlayBgmCancel As Windows.Forms.Button
    Friend WithEvents cmbPlayBGM As Windows.Forms.ComboBox
    Friend WithEvents fraEndQuest As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel46 As Windows.Forms.Label
    Friend WithEvents btnEndQuestOK As Windows.Forms.Button
    Friend WithEvents btnEndQuestCancel As Windows.Forms.Button
    Friend WithEvents cmbEndQuest As Windows.Forms.ComboBox
    Friend WithEvents fraBeginQuest As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel45 As Windows.Forms.Label
    Friend WithEvents btnBeginQuestOK As Windows.Forms.Button
    Friend WithEvents btnBeginQuestCancel As Windows.Forms.Button
    Friend WithEvents cmbBeginQuest As Windows.Forms.ComboBox
    Friend WithEvents cmbPlayAnimEvent As Windows.Forms.ComboBox
    Friend WithEvents fraHidePic As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel58 As Windows.Forms.Label
    Friend WithEvents btnHidePicOK As Windows.Forms.Button
    Friend WithEvents btnHidePicCancel As Windows.Forms.Button
    Friend WithEvents cmbHidePic As Windows.Forms.ComboBox
    Friend WithEvents fraMoveRouteWait As Windows.Forms.GroupBox
    Friend WithEvents lblRandomLabel59 As Windows.Forms.Label
    Friend WithEvents btnMoveWaitOK As Windows.Forms.Button
    Friend WithEvents btnMoveWaitCancel As Windows.Forms.Button
    Friend WithEvents cmbMoveWait As Windows.Forms.ComboBox
    Friend WithEvents fraPlayerWarp As Windows.Forms.GroupBox
    Friend WithEvents cmbWarpPlayerDir As Windows.Forms.ComboBox
    Friend WithEvents scrlWPY As Windows.Forms.HScrollBar
    Friend WithEvents lblWPY As Windows.Forms.Label
    Friend WithEvents lblWPX As Windows.Forms.Label
    Friend WithEvents scrlWPX As Windows.Forms.HScrollBar
    Friend WithEvents btnPlayerWarpOK As Windows.Forms.Button
    Friend WithEvents btnPlayerWarpCancel As Windows.Forms.Button
    Friend WithEvents lblWPMap As Windows.Forms.Label
    Friend WithEvents scrlWPMap As Windows.Forms.HScrollBar
    Friend WithEvents fraSetWait As Windows.Forms.GroupBox
    Friend WithEvents btnSetWaitOK As Windows.Forms.Button
    Friend WithEvents btnSetWaitCancel As Windows.Forms.Button
    Friend WithEvents scrlWaitAmount As Windows.Forms.HScrollBar
    Friend WithEvents lblRandomLabel44 As Windows.Forms.Label
    Friend WithEvents lblWaitAmount As Windows.Forms.Label
    Friend WithEvents fraCustomScript As Windows.Forms.GroupBox
    Friend WithEvents btnCustomScriptOK As Windows.Forms.Button
    Friend WithEvents btnCustomScriptCancel As Windows.Forms.Button
    Friend WithEvents scrlCustomScript As Windows.Forms.HScrollBar
    Friend WithEvents lblCustomScript As Windows.Forms.Label
    Friend WithEvents fraConditionalBranch As Windows.Forms.GroupBox
    Friend WithEvents btnConditionalBranchOk As Windows.Forms.Button
    Friend WithEvents btnConditionalBranchCancel As Windows.Forms.Button
    Friend WithEvents fraConditions_Quest As Windows.Forms.GroupBox
    Friend WithEvents lblCondition_QuestTask As Windows.Forms.Label
    Friend WithEvents optCondition_Quest1 As Windows.Forms.RadioButton
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel50 As Windows.Forms.Label
    Friend WithEvents optCondition_Quest0 As Windows.Forms.RadioButton
    Friend WithEvents cmbCondition_General As Windows.Forms.ComboBox
    Friend WithEvents scrlCondition_QuestTask As Windows.Forms.HScrollBar
    Friend WithEvents lblConditionQuest As Windows.Forms.Label
    Friend WithEvents optCondition7 As Windows.Forms.RadioButton
    Friend WithEvents optCondition6 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel2 As Windows.Forms.Label
    Friend WithEvents optCondition5 As Windows.Forms.RadioButton
    Friend WithEvents cmbCondition_LearntSkill As Windows.Forms.ComboBox
    Friend WithEvents optCondition4 As Windows.Forms.RadioButton
    Friend WithEvents cmbCondition_ClassIs As Windows.Forms.ComboBox
    Friend WithEvents optCondition3 As Windows.Forms.RadioButton
    Friend WithEvents scrlCondition_Quest As Windows.Forms.HScrollBar
    Friend WithEvents scrlCondition_HasItem As Windows.Forms.HScrollBar
    Friend WithEvents lblHasItemAmt As Windows.Forms.Label
    Friend WithEvents optCondition2 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel35 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel1 As Windows.Forms.Label
    Friend WithEvents cmbCondition_SelfSwitchCondition As Windows.Forms.ComboBox
    Friend WithEvents cmbCondtion_PlayerSwitchCondition As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_LevelCompare As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_HasItem As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_SelfSwitch As Windows.Forms.ComboBox
    Friend WithEvents cmbCondition_PlayerSwitch As Windows.Forms.ComboBox
    Friend WithEvents optCondition1 As Windows.Forms.RadioButton
    Friend WithEvents txtCondition_LevelAmount As Windows.Forms.TextBox
    Friend WithEvents txtCondition_PlayerVarCondition As Windows.Forms.TextBox
    Friend WithEvents cmbCondition_PlayerVarCompare As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel0 As Windows.Forms.Label
    Friend WithEvents cmbCondition_PlayerVarIndex As Windows.Forms.ComboBox
    Friend WithEvents optCondition0 As Windows.Forms.RadioButton
    Friend WithEvents lblRandomLabel11 As Windows.Forms.Label
    Friend WithEvents lblRandomLabel14 As Windows.Forms.Label
    Friend WithEvents fraCommands As Windows.Forms.Panel
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
    Friend WithEvents pnlGraphicSelect As Windows.Forms.Panel
    Friend WithEvents fraSetWeather As Windows.Forms.GroupBox
    Friend WithEvents btnSetWeatherOK As Windows.Forms.Button
    Friend WithEvents btnSetWeatherCancel As Windows.Forms.Button
    Friend WithEvents scrlWeatherIntensity As Windows.Forms.HScrollBar
    Friend WithEvents lblWeatherIntensity As Windows.Forms.Label
    Friend WithEvents CmbWeather As Windows.Forms.ComboBox
    Friend WithEvents lblRandomLabel43 As Windows.Forms.Label
    Friend WithEvents lstvwMoveRoute As Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As Windows.Forms.ColumnHeader
    Friend WithEvents btnOK As Windows.Forms.Button
    Friend WithEvents btnCancel As Windows.Forms.Button
End Class
