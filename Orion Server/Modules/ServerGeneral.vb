Module ServerGeneral
    Public Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Long) As Long
    Public ServerDestroyed As Boolean
    Public MyIPAddress As String

    Public Function GetTickCount()
        Return Environment.TickCount
    End Function

    Sub Main()
        Call InitServer()
    End Sub

    Sub InitServer()
        Dim i As Long
        Dim F As Long
        Dim x As Integer
        x = 0
        Dim time1 As Long
        Dim time2 As Long
        'Call InitMessages()
        time1 = GetTickCount()
        frmServer.Show()
        ' Initialize the random-number generator
        Randomize() ', seed

        ReDim Map(0 To MAX_MAPS)
        ReDim MapNpc(0 To MAX_MAPS)
        For i = 0 To MAX_MAPS
            ReDim MapNpc(i).Npc(0 To MAX_MAP_NPCS)
            ReDim Map(i).Npc(0 To MAX_MAP_NPCS)
        Next

        'quests
        ReDim Quest(MAX_QUESTS)
        For i = 0 To MAX_QUESTS
            ReDim Quest(i).Requirement(3)
            ReDim Quest(i).Chat(3)
            ReDim Quest(i).Task(MAX_TASKS)
        Next

        'event
        ReDim Switches(0 To MAX_SWITCHES)
        ReDim Variables(0 To MAX_VARIABLES)
        ReDim TempEventMap(0 To MAX_MAPS)

        'Housing
        ReDim HouseConfig(0 To MAX_HOUSES)

        For i = 0 To MAX_MAPS
            For x = 0 To MAX_MAP_NPCS
                ReDim MapNpc(i).Npc(x).Vital(0 To Vitals.Vital_Count)
            Next
        Next

        ReDim Bank(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            ReDim Bank(i).Item(0 To MAX_BANK)
        Next

        ReDim Player(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).PlayerQuest(MAX_QUESTS)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).Switches(MAX_SWITCHES)
            ReDim Player(i).Variables(MAX_VARIABLES)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).Vital(0 To Vitals.Vital_Count - 1)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).Stat(0 To Stats.Stat_Count - 1)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).Equipment(0 To Equipment.Equipment_Count - 1)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).Inv(0 To MAX_INV)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim Player(i).Spell(0 To MAX_PLAYER_SPELLS)
        Next

        ReDim TempPlayer(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            ReDim TempPlayer(i).SpellCD(0 To MAX_PLAYER_SPELLS)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim TempPlayer(i).TradeOffer(0 To MAX_INV)
        Next

        If FileExist(Application.StartupPath & "\data\classes.ini") Then
            Max_Classes = CLng(Getvar(Application.StartupPath & "\data\classes.ini", "INIT", "MaxClasses"))
        Else
            Max_Classes = 2
        End If

        ReDim Classes(0 To Max_Classes)
        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Stat_Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

        For i = 0 To MAX_ITEMS
            ReDim Item(i).Add_Stat(0 To Stats.Stat_Count - 1)
            ReDim Item(i).Stat_Req(0 To Stats.Stat_Count - 1)
            ReDim Item(i).FurnitureBlocks(0 To 3, 0 To 3)
            ReDim Item(i).FurnitureFringe(0 To 3, 0 To 3)
        Next
        ReDim Npc(0 To MAX_NPCS).Stat(0 To Stats.Stat_Count - 1)


        ReDim Shop(0 To MAX_SHOPS).TradeItem(0 To MAX_TRADES)

        ReDim Animation(0 To MAX_ANIMATIONS).Sprite(0 To 1)
        ReDim Animation(0 To MAX_ANIMATIONS).Frames(0 To 1)
        ReDim Animation(0 To MAX_ANIMATIONS).LoopCount(0 To 1)
        ReDim Animation(0 To MAX_ANIMATIONS).LoopTime(0 To 1)



        ' Check if the directory is there, if its not make it
        If LCase$(Dir(Application.StartupPath & "\data", vbDirectory)) <> "data" Then
            Call MkDir(Application.StartupPath & "\data")
        End If

        If LCase$(Dir(Application.StartupPath & "\Data\items", vbDirectory)) <> "items" Then
            Call MkDir(Application.StartupPath & "\Data\items")
        End If

        If LCase$(Dir(Application.StartupPath & "\Data\maps", vbDirectory)) <> "maps" Then
            Call MkDir(Application.StartupPath & "\Data\maps")
        End If

        If LCase$(Dir(Application.StartupPath & "\Data\npcs", vbDirectory)) <> "npcs" Then
            Call MkDir(Application.StartupPath & "\Data\npcs")
        End If

        If LCase$(Dir(Application.StartupPath & "\Data\shops", vbDirectory)) <> "shops" Then
            Call MkDir(Application.StartupPath & "\Data\shops")
        End If

        If LCase$(Dir(Application.StartupPath & "\Data\spells", vbDirectory)) <> "spells" Then
            Call MkDir(Application.StartupPath & "\Data\spells")
        End If

        If LCase$(Dir(Application.StartupPath & "\data\accounts", vbDirectory)) <> "accounts" Then
            Call MkDir(Application.StartupPath & "\data\accounts")
        End If

        If LCase$(Dir(Application.StartupPath & "\data\resources", vbDirectory)) <> "resources" Then
            Call MkDir(Application.StartupPath & "\data\resources")
        End If

        If LCase$(Dir(Application.StartupPath & "\data\animations", vbDirectory)) <> "animations" Then
            Call MkDir(Application.StartupPath & "\data\animations")
        End If

        If LCase$(Dir(Application.StartupPath & "\data\banks", vbDirectory)) <> "banks" Then
            Call MkDir(Application.StartupPath & "\data\banks")
        End If

        If LCase$(Dir(Application.StartupPath & "\data\logs", vbDirectory)) <> "logs" Then
            Call MkDir(Application.StartupPath & "\data\logs")
        End If

        'quests
        If LCase$(Dir(Application.StartupPath & "\data\quests", vbDirectory)) <> "quests" Then
            Call MkDir(Application.StartupPath & "\data\quests")
        End If

        ' set quote character
        vbQuote = Chr(34) ' "

        ' load options, set if they dont exist
        If Not FileExist(Application.StartupPath & "\data\options.ini") Then
            Options.Game_Name = "Orion+"
            Options.Port = 7001
            Options.MOTD = "Welcome to the Orion+ Engine"
            Options.Website = "http://ascensiongamedev.com/index.php"
            Call SaveOptions()
        Else
            Call LoadOptions()
        End If


        ' Serves as a constructor
        Call ClearGameData()
        Call LoadGameData()
        Call SetStatus("Spawning map items...")
        Call SpawnAllMapsItems()
        Call SetStatus("Spawning map npcs...")
        Call SpawnAllMapNpcs()
        Call SetStatus("Creating map cache...")
        'Call CreateFullMapCache()

        ' Check if the master charlist file exists for checking duplicate names, and if it doesnt make it
        If Not FileExist("data\accounts\charlist.txt") Then
            F = FreeFile()
            'Open (Application.StartupPath & "\data\accounts\charlist.txt") For Output As #F
            'Close #F
        End If

        ' Get the listening socket ready to go
        InitMessages()
        InitNetwork()

        ' Init all the player sockets
        Call SetStatus("Initializing player array...")

        ReDim Clients(0 To MAX_PLAYERS)

        For x = 1 To MAX_PLAYERS
            Clients(x) = New Client
            frmServer.lstView.Items.Add(x)
            frmServer.lstView.Items(x - 1).SubItems.Add("")
            frmServer.lstView.Items(x - 1).SubItems.Add("")
            frmServer.lstView.Items(x - 1).SubItems.Add("")
            ClearPlayer(x)
        Next

        Call UpdateCaption()
        time2 = GetTickCount()
        Call SetStatus("Initialization complete. Server loaded in " & time2 - time1 & "ms.")

        MyIPAddress = GetIP()
        If MyIPAddress = "" Then
            'MyIPAddress = ServerSocket.
        End If

        UpdateCaption()

        ' reset shutdown value
        isShuttingDown = False

        ' Starts the server loop
        Call ServerLoop.ServerLoop()
    End Sub

    Sub UpdateCaption()
        frmServer.Text = Options.Game_Name & " <IP " & MyIPAddress & " Port " & Options.Port & "> (" & GetPlayersOnline() & " Players Online" & ")"
    End Sub

    Sub DestroyServer()
        ServerOnline = False
        Call SetStatus("Saving players online...")
        Call SaveAllPlayersOnline()
        Call ClearGameData()
        Call SetStatus("Unloading sockets...")
        ServerDestroyed = True
        Application.Exit()
    End Sub

    Sub SetStatus(ByVal Status As String)
        Call TextAdd(Status)
    End Sub

    Public Sub ClearGameData()
        Call SetStatus("Clearing temp tile fields...")
        Call ClearTempTiles()
        Call SetStatus("Clearing Maps...")
        Call ClearMaps()
        Call SetStatus("Clearing Map Items...")
        Call ClearMapItems()
        Call SetStatus("Clearing Map Npc's...")
        Call ClearMapNpcs()
        Call SetStatus("Clearing Npc's...")
        Call ClearNpcs()
        Call SetStatus("Clearing Resources...")
        Call ClearResources()
        Call SetStatus("Clearing Items...")
        Call ClearItems()
        Call SetStatus("Clearing Shops...")
        Call ClearShops()
        Call SetStatus("Clearing Spells...")
        Call ClearSpells()
        Call SetStatus("Clearing Animations...")
        Call ClearAnimations()
        'quests
        Call SetStatus("Clearing Quests...")
        Call ClearQuests()
    End Sub

    Private Sub LoadGameData()
        Call SetStatus("Loading Classes...")
        Call LoadClasses()
        Call SetStatus("Loading Maps...")
        Call LoadMaps()
        Call SetStatus("Loading Items...")
        Call LoadItems()
        Call SetStatus("Loading Npc's...")
        Call LoadNpcs()
        Call SetStatus("Loading Resources...")
        Call LoadResources()
        Call SetStatus("Loading Shops...")
        Call LoadShops()
        Call SetStatus("Loading Spells...")
        Call LoadSpells()
        Call SetStatus("Loading Animations...")
        Call LoadAnimations()
        'quests
        Call SetStatus("Loading Quests...")
        Call LoadQuests()
        'Housing
        Call SetStatus("Loading House Configurations...")
        Call LoadHouses()
        'switches
        Call SetStatus("Loading Switches...")
        Call LoadSwitches()
        'variables
        Call SetStatus("Loading Variables...")
        Call LoadVariables()
        'Events
        Call SetStatus("Spawning global events...")
        Call SpawnAllMapGlobalEvents()
    End Sub

    Sub TextAdd(ByVal Msg As String)
        If ConsoleText = "" Then
            ConsoleText = ConsoleText & Msg
        Else
            ConsoleText = ConsoleText & vbNewLine & Msg
        End If
        Try
            UpdateUI()
        Catch ex As Exception
            'Dont handle error
        End Try
    End Sub

    ' Used for checking validity of names
    Function isNameLegal(ByVal sInput As Integer) As Boolean

        If (sInput >= 65 And sInput <= 90) Or (sInput >= 97 And sInput <= 122) Or (sInput = 95) Or (sInput = 32) Or (sInput >= 48 And sInput <= 57) Then
            Return True
        Else
            Return False
        End If

    End Function

    Function FileExist(ByVal file_path) As Boolean
        FileExist = IO.File.Exists(file_path)
    End Function

    Public Sub DoEvents()
        Application.DoEvents()
    End Sub

    Public Sub Sleep(ByVal milleseconds As Long)
        Threading.Thread.Sleep(milleseconds)
    End Sub

    Public Sub HandleShutdown()

        If Secs <= 0 Then Secs = 30
        If Secs Mod 5 = 0 Or Secs <= 5 Then
            Call GlobalMsg("Server Shutdown in " & Secs & " seconds.")
            Call TextAdd("Automated Server Shutdown in " & Secs & " seconds.")
        End If

        Secs = Secs - 1

        If Secs <= 0 Then
            Call GlobalMsg("Server Shutdown.")
            Call DestroyServer()
        End If

    End Sub

End Module
