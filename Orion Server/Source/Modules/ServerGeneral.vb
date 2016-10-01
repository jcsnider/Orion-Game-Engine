Module ServerGeneral
    Public Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Long) As Long
    Public ServerDestroyed As Boolean
    Public MyIPAddress As String

    Public Function GetTickCount()
        Return Environment.TickCount
    End Function

    Sub Main()
        InitServer()
    End Sub

    Sub InitServer()
        Dim i As Long, F As Long, x As Integer
        Dim time1 As Long, time2 As Long
        x = 0

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
                ReDim MapNpc(i).Npc(x).Vital(0 To Vitals.Count)
            Next
        Next

        ReDim Bank(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            ReDim Bank(i).Item(0 To MAX_BANK)
        Next

        ReDim Player(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            'multi char
            ReDim Player(i).Character(MAX_CHARS)
            For x = 1 To MAX_CHARS
                ReDim Player(i).Character(x).Switches(MAX_SWITCHES)
                ReDim Player(i).Character(x).Variables(MAX_VARIABLES)
                ReDim Player(i).Character(x).Vital(0 To Vitals.Count - 1)
                ReDim Player(i).Character(x).Stat(0 To Stats.Count - 1)
                ReDim Player(i).Character(x).Equipment(0 To Equipment.Count - 1)
                ReDim Player(i).Character(x).Inv(0 To MAX_INV)
                ReDim Player(i).Character(x).Skill(0 To MAX_PLAYER_SKILLS)
                ReDim Player(i).Character(x).PlayerQuest(MAX_QUESTS)
            Next
        Next

        ReDim TempPlayer(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            ReDim TempPlayer(i).SkillCD(0 To MAX_PLAYER_SKILLS)
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
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

        For i = 0 To MAX_ITEMS
            ReDim Item(i).Add_Stat(0 To Stats.Count - 1)
            ReDim Item(i).Stat_Req(0 To Stats.Count - 1)
            ReDim Item(i).FurnitureBlocks(0 To 3, 0 To 3)
            ReDim Item(i).FurnitureFringe(0 To 3, 0 To 3)
        Next
        ReDim Npc(0 To MAX_NPCS).Stat(0 To Stats.Count - 1)


        ReDim Shop(0 To MAX_SHOPS).TradeItem(0 To MAX_TRADES)

        ReDim Animation(0 To MAX_ANIMATIONS).Sprite(0 To 1)
        ReDim Animation(0 To MAX_ANIMATIONS).Frames(0 To 1)
        ReDim Animation(0 To MAX_ANIMATIONS).LoopCount(0 To 1)
        ReDim Animation(0 To MAX_ANIMATIONS).LoopTime(0 To 1)

        ReDim MapProjectiles(0 To MAX_MAPS, 0 To MAX_PROJECTILES)
        ReDim Projectiles(MAX_PROJECTILES)

        ' Check if the directory is there, if its not make it
        CheckDir(Application.StartupPath & "\data")

        CheckDir(Application.StartupPath & "\Data\items")

        CheckDir(Application.StartupPath & "\Data\maps")

        CheckDir(Application.StartupPath & "\Data\npcs")

        CheckDir(Application.StartupPath & "\Data\shops")

        CheckDir(Application.StartupPath & "\Data\skills")

        CheckDir(Application.StartupPath & "\data\accounts")

        CheckDir(Application.StartupPath & "\data\resources")

        CheckDir(Application.StartupPath & "\data\animations")

        CheckDir(Application.StartupPath & "\data\banks")

        CheckDir(Application.StartupPath & "\data\logs")

        CheckDir(Application.StartupPath & "\data\quests")

        CheckDir(Application.StartupPath & "\data\projectiles")

        CheckDir(Application.StartupPath & "\data\recipes")

        ' set quote character
        vbQuote = Chr(34) ' "

        ' load options, set if they dont exist
        If Not FileExist(Application.StartupPath & "\data\options.ini") Then
            Options.Game_Name = "Orion+"
            Options.Port = 7001
            Options.MOTD = "Welcome to the Orion+ Engine"
            Options.Website = "http://ascensiongamedev.com/index.php"
            SaveOptions()
        Else
            LoadOptions()
        End If


        ' Serves as a constructor
        ClearGameData()
        LoadGameData()
        SetStatus("Spawning map items...")
        SpawnAllMapsItems()
        SetStatus("Spawning map npcs...")
        SpawnAllMapNpcs()

        ' Check if the master charlist file exists for checking duplicate names, and if it doesnt make it
        If Not FileExist("data\accounts\charlist.txt") Then
            F = FreeFile()
        End If

        ' Get the listening socket ready to go
        InitMessages()
        InitNetwork()

        ' Init all the player sockets
        SetStatus("Initializing player array...")

        ReDim Clients(0 To MAX_PLAYERS)

        For x = 1 To MAX_PLAYERS
            Clients(x) = New Client
            frmServer.lstView.Items.Add(x)
            frmServer.lstView.Items(x - 1).SubItems.Add("")
            frmServer.lstView.Items(x - 1).SubItems.Add("")
            frmServer.lstView.Items(x - 1).SubItems.Add("")
            ClearPlayer(x)
        Next

        'resource system
        LoadSkillExp()

        UpdateCaption()
        time2 = GetTickCount()
        SetStatus("Initialization complete. Server loaded in " & time2 - time1 & "ms.")

        MyIPAddress = GetIP()

        UpdateCaption()

        ' reset shutdown value
        isShuttingDown = False

        ' Starts the server loop
        ServerLoop.ServerLoop()
    End Sub

    Sub UpdateCaption()
        frmServer.Text = Options.Game_Name & " <IP " & MyIPAddress & " Port " & Options.Port & "> (" & GetPlayersOnline() & " Players Online" & ")"
    End Sub

    Sub DestroyServer()
        ServerOnline = False
        SetStatus("Saving players online...")
        SaveAllPlayersOnline()
        ClearGameData()
        SetStatus("Unloading sockets...")
        ServerDestroyed = True
        Application.Exit()
    End Sub

    Sub SetStatus(ByVal Status As String)
        Call TextAdd(Status)
    End Sub

    Public Sub ClearGameData()
        SetStatus("Clearing temp tile fields...")
        ClearTempTiles()
        SetStatus("Clearing Maps...")
        ClearMaps()
        SetStatus("Clearing Map Items...")
        ClearMapItems()
        SetStatus("Clearing Map Npc's...")
        ClearMapNpcs()
        SetStatus("Clearing Npc's...")
        ClearNpcs()
        SetStatus("Clearing Resources...")
        ClearResources()
        SetStatus("Clearing Items...")
        ClearItems()
        SetStatus("Clearing Shops...")
        ClearShops()
        SetStatus("Clearing Skills...")
        ClearSkills()
        SetStatus("Clearing Animations...")
        ClearAnimations()
        'quests
        SetStatus("Clearing Quests...")
        ClearQuests()

        'projectiles
        SetStatus("Clearing map projectiles...")
        ClearMapProjectiles()
        SetStatus("Clearing projectiles...")
        ClearProjectiles()

        'recipes
        ClearRecipes()
    End Sub

    Private Sub LoadGameData()
        SetStatus("Loading Classes...")
        LoadClasses()
        SetStatus("Loading Maps...")
        LoadMaps()
        SetStatus("Loading Items...")
        LoadItems()
        SetStatus("Loading Npc's...")
        LoadNpcs()
        SetStatus("Loading Resources...")
        LoadResources()
        SetStatus("Loading Shops...")
        LoadShops()
        SetStatus("Loading Skills...")
        LoadSkills()
        SetStatus("Loading Animations...")
        LoadAnimations()
        'quests
        SetStatus("Loading Quests...")
        LoadQuests()
        'Housing
        SetStatus("Loading House Configurations...")
        LoadHouses()
        'switches
        SetStatus("Loading Switches...")
        LoadSwitches()
        'variables
        SetStatus("Loading Variables...")
        LoadVariables()
        'Events
        SetStatus("Spawning global events...")
        SpawnAllMapGlobalEvents()

        'projectiles
        SetStatus("Loading projectiles...")
        LoadProjectiles()

        'recipes
        LoadRecipes()
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
            GlobalMsg("Server Shutdown in " & Secs & " seconds.")
            TextAdd("Automated Server Shutdown in " & Secs & " seconds.")
        End If

        Secs = Secs - 1

        If Secs <= 0 Then
            GlobalMsg("Server Shutdown.")
            DestroyServer()
        End If

    End Sub

    Public Sub CheckDir(ByVal DirPath As String)

        If Not IO.Directory.Exists(DirPath) Then
            IO.Directory.CreateDirectory(DirPath)
        End If

    End Sub
End Module
