Imports System.Windows.Forms

Module modGeneral
    Public Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Long) As Long
    Public started As Boolean
    Public Function GetTickCount()
        Return System.Environment.TickCount
    End Function
    Sub startup()

        ReDim Player(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            For x = 0 To Vitals.Vital_Count - 1
                ReDim Player(i).Vital(x)
            Next
            For x = 0 To Stats.stat_count - 1
                ReDim Player(i).Stat(x)
            Next
            For x = 0 To Equipment.Equipment_Count - 1
                ReDim Player(i).Equipment(x)
            Next

            ReDim Item(0 To MAX_BANK)
            For x = 0 To Stats.stat_count - 1
                ReDim Item(i).Add_Stat(x)
            Next
            For x = 0 To Stats.stat_count - 1
                ReDim Item(i).Stat_Req(x)
            Next
        Next

        'Layer(1 To MapLayer.Layer_Count - 1) 'tilerec
        ReDim Map.Npc(0 To MAX_MAP_NPCS)

        ReDim Item(0 To MAX_ITEMS)
        For i = 0 To MAX_ITEMS
            For x = 0 To Stats.stat_count - 1
                ReDim Item(i).Add_Stat(x)
            Next
            For x = 0 To Stats.stat_count - 1
                ReDim Item(i).Stat_Req(x)
            Next
        Next

        ReDim Npc(0 To MAX_NPCS)
        For i = 0 To MAX_NPCS
            For x = 0 To Stats.stat_count - 1
                ReDim Npc(i).Stat(x)
            Next
        Next

        ReDim MapNpc(0 To MAX_MAP_NPCS)
        For i = 0 To MAX_MAP_NPCS
            For x = 0 To Vitals.Vital_Count - 1
                ReDim MapNpc(i).Vital(x)
            Next
        Next

        ReDim Shop(0 To MAX_SHOPS)
        For i = 0 To MAX_SHOPS
            For x = 0 To MAX_TRADES
                ReDim Shop(i).TradeItem(x)
            Next
        Next

        ReDim Animation(0 To MAX_ANIMATIONS)
        For i = 0 To MAX_ANIMATIONS
            For x = 0 To 1
                ReDim Animation(i).Sprite(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).Frames(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).LoopCount(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).looptime(x)
            Next
        Next

        ReDim AnimInstance(0 To MAX_ANIMATIONS)
        For i = 0 To MAX_ANIMATIONS
            For x = 0 To 1
                ReDim AnimInstance(i).Timer(x)
            Next
            For x = 0 To 1
                ReDim AnimInstance(i).Used(x)
            Next
            For x = 0 To 1
                ReDim AnimInstance(i).LoopIndex(x)
            Next
            For x = 0 To 1
                ReDim AnimInstance(i).FrameIndex(x)
            Next
        Next

        ReDim Item(0 To MAX_ITEMS)
        ReDim Bank.Item(0 To MAX_BANK)
        ClearItems()

        Call SetStatus("Loading...")
        GettingMap = True
        vbQuote = Chr(34) ' "

        ' Update the form with the game's name before it's loaded
        frmMainGame.Text = GAME_NAME

        Call SetStatus("Loading Options...")

        ' load options
        LoadOptions()


        ' randomize rnd's seed
        Randomize()

        Call SetStatus("Initializing Network...")

        frmMenu.Text = GAME_NAME

        ' DX7 Master Object is already created, early binding
        Call SetStatus("Initializing Graphics...")
        Call CheckTilesets()
        Call CheckCharacters()
        Call CheckPaperdolls()
        Call CheckAnimations()
        Call CheckItems()
        Call CheckResources()
        Call CheckSpellIcons()

        InitGraphics()

        ' check if we have main-menu music
        If Len(Trim$(Options.MenuMusic)) > 0 Then PlayMusic(Trim$(Options.MenuMusic))

        ' Reset values
        Ping = -1

        ' set values for directional blocking arrows
        DirArrowX(1) = 12 ' up
        DirArrowY(1) = 0
        DirArrowX(2) = 12 ' down
        DirArrowY(2) = 23
        DirArrowX(3) = 0 ' left
        DirArrowY(3) = 12
        DirArrowX(4) = 23 ' right
        DirArrowY(4) = 12

        Call SetStatus("Starting Game...")
        started = True
        frmmenuvisible = True
        frmloadvisible = False
        Call GameLoop()
    End Sub
    Public Function isLoginLegal(ByVal Username As String, ByVal Password As String) As Boolean
        If Len(Trim$(Username)) >= 3 Then
            If Len(Trim$(Password)) >= 3 Then
                isLoginLegal = True
            Else
                isLoginLegal = False
            End If
        Else
            isLoginLegal = False
        End If

    End Function

    Public Function isStringLegal(ByVal sInput As String) As Boolean
        Dim i As Long

        ' Prevent high ascii chars
        For i = 1 To Len(sInput)

            If (Asc(Mid$(sInput, i, 1))) < 32 Or Asc(Mid$(sInput, i, 1)) > 126 Then
                Call MsgBox("You cannot use high ASCII characters in your name, please re-enter.", vbOKOnly, GAME_NAME)
                isStringLegal = False
                Exit Function
            End If

        Next

        isStringLegal = True
    End Function
    Sub GameInit()
        frmloadvisible = False

        ' Set the focus
        frmMainGame.txtMeChat.Focus()

        ' set values for amdin panel
        frmMainGame.scrlSpawnItem.Maximum = MAX_ITEMS
        frmMainGame.scrlSpawnItem.Value = 1

        'stop the song playing
        StopMusic()
    End Sub
    Public Sub SetStatus(ByVal Caption As String)
        frmLoad.lblStatus.Text = Caption
    End Sub
    Public Sub MenuState(ByVal State As Long)
        frmloadvisible = True
        frmmenuvisible = False
        Select Case State
            Case MENU_STATE_ADDCHAR
                pnlCharCreateVisible = False
                pnlLoginVisible = False
                pnlRegisterVisible = False
                pnlCreditsVisible = False

                If ConnectToServer(1) Then
                    Call SetStatus("Connected, sending character addition data...")

                    If frmMenu.rdoMale.Checked = True Then
                        Call SendAddChar(frmMenu.txtCharName.Text, SEX_MALE, frmMenu.cmbClass.SelectedIndex + 1, newCharSprite)
                    Else
                        Call SendAddChar(frmMenu.txtCharName.Text, SEX_FEMALE, frmMenu.cmbClass.SelectedIndex + 1, newCharSprite)
                    End If
                End If

            Case MENU_STATE_NEWACCOUNT
                pnlLoginVisible = False
                pnlCharCreateVisible = False
                pnlRegisterVisible = False
                pnlCreditsVisible = False

                If ConnectToServer(1) Then
                    Call SetStatus("Connected, sending new account information...")
                    Call SendNewAccount(frmMenu.txtRuser.Text, frmMenu.txtRPass.Text)
                End If

            Case MENU_STATE_LOGIN
                pnlLoginVisible = False
                pnlCharCreateVisible = False
                pnlRegisterVisible = False
                pnlCreditsVisible = False
                tempUserName = frmMenu.txtLogin.Text
                tempPassword = frmMenu.txtPassword.Text

                If ConnectToServer(1) Then
                    Call SetStatus("Connected, sending login information...")
                    Call SendLogin(frmMenu.txtLogin.Text, frmMenu.txtPassword.Text)
                    Exit Sub
                End If
        End Select

    End Sub
    Public Function ConnectToServer(ByVal i As Long) As Boolean
        Dim Wait As Long
        ConnectToServer = False

        ' Check to see if we are already connected, if so just exit
        If IsConnected() Then
            ConnectToServer = True
            Exit Function
        End If

        If i = 4 Then Exit Function
        Wait = GetTickCount()

        Connect()

        Call SetStatus("Connecting to server...(" & i & ")")

        ' Wait until connected or a few seconds have passed and report the server being down
        Do While (Not IsConnected()) And (GetTickCount() <= Wait + 3500)
            DoEvents()
            Sleep(20)
        Loop

        ' return value
        If IsConnected() Then
            ConnectToServer = True
        End If

        If Not ConnectToServer Then
            Call ConnectToServer(i + 1)
        End If

    End Function
    Public Sub Sleep(ByVal milleseconds As Long)
        System.Threading.Thread.Sleep(milleseconds)
    End Sub

    Public Sub DoEvents()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Function FileExist(ByVal file_path) As Boolean
        FileExist = System.IO.File.Exists(file_path)
    End Function
    Public Sub DestroyGame()
        ' break out of GameLoop
        InGame = False
        PlayerSocket.Close()
        PlayerSocket = Nothing
        Call DestroyGraphics()
        GameDestroyed = True
        Application.Exit()
        End
    End Sub
End Module
