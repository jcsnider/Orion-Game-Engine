Imports System.IO

Module ServerGeneral
    Public Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Integer) As Integer
    Public ServerDestroyed As Boolean
    Public MyIPAddress As String

    Public Function GetTickCount()
        Return Environment.TickCount
    End Function

    'Sub Main()
    '    InitServer()
    'End Sub

    Sub InitServer()
        Dim i As Integer, F As Integer, x As Integer
        Dim time1 As Integer, time2 As Integer
        x = 0

        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf ErrorHandler

        Console.Title = "Orion+ Server"
        Console.SetWindowSize(120, 20)

        handler = New ConsoleEventDelegate(AddressOf ConsoleEventCallback)
        SetConsoleCtrlHandler(handler, True)

        time1 = GetTickCount()
        'frmServer.Show()

        ' Initialize the random-number generator
        Randomize() ', seed

        ReDim Map(MAX_CACHED_MAPS)

        ReDim MapNpc(MAX_CACHED_MAPS)
        For i = 0 To MAX_CACHED_MAPS
            ReDim MapNpc(i).Npc(0 To MAX_MAP_NPCS)
            ReDim Map(i).Npc(0 To MAX_MAP_NPCS)
        Next

        'quests
        ReDim Quest(MAX_QUESTS)
        ClearQuests()

        'event
        ReDim Switches(0 To MAX_SWITCHES)
        ReDim Variables(0 To MAX_VARIABLES)
        ReDim TempEventMap(MAX_CACHED_MAPS)

        'Housing
        ReDim HouseConfig(0 To MAX_HOUSES)

        For i = 0 To MAX_CACHED_MAPS
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
                ReDim Player(i).Character(x).Equipment(0 To EquipmentType.Count - 1)
                ReDim Player(i).Character(x).Inv(0 To MAX_INV)
                ReDim Player(i).Character(x).Skill(0 To MAX_PLAYER_SKILLS)
                ReDim Player(i).Character(x).PlayerQuest(MAX_QUESTS)

                ReDim Player(i).Character(x).RandEquip(EquipmentType.Count - 1)
                ReDim Player(i).Character(x).RandInv(MAX_INV)
                For y = 1 To EquipmentType.Count - 1
                    ReDim Player(i).Character(x).RandEquip(y).Stat(Stats.Count - 1)
                Next
                For y = 1 To MAX_INV
                    ReDim Player(i).Character(x).RandInv(y).Stat(Stats.Count - 1)
                Next
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

        ReDim MapProjectiles(MAX_CACHED_MAPS, 0 To MAX_PROJECTILES)
        ReDim Projectiles(MAX_PROJECTILES)

        'partys
        ClearPartys()

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
            'frmServer.lstView.Items.Add(x)
            'frmServer.lstView.Items(x - 1).SubItems.Add("")
            'frmServer.lstView.Items(x - 1).SubItems.Add("")
            'frmServer.lstView.Items(x - 1).SubItems.Add("")
            ClearPlayer(x)
        Next

        'resource system
        LoadSkillExp()

        UpdateCaption()
        time2 = GetTickCount()

        Console.Clear()
        Console.WriteLine("  ____       _                        _____                          ")
        Console.WriteLine(" / __ \     (_)                _     / ____|                         ")
        Console.WriteLine("| |  | |_ __ _  ___  _ __    _| |_  | (___   ___ _ ____   _____ _ __ ")
        Console.WriteLine("| |  | | '__| |/ _ \| '_ \  |_   _|  \___ \ / _ \ '__\ \ / / _ \ '__|")
        Console.WriteLine("| |__| | |  | | (_) | | | |   |_|    ____) |  __/ |   \ V /  __/ |   ")
        Console.WriteLine(" \____/|_|  |_|\___/|_| |_|         |_____/ \___|_|    \_/ \___|_|   ")

        Console.WriteLine("")

        SetStatus("Initialization complete. Server loaded in " & time2 - time1 & "ms.")
        Console.WriteLine("")
        SetStatus("Use /help for the available commands.")

        MyIPAddress = GetIP()

        UpdateCaption()

        ' reset shutdown value
        isShuttingDown = False

        'init the console msg
        AddCommandHandler("/help", AddressOf HandleCommandHelp)
        AddCommandHandler("/exit", AddressOf HandleCommandExit)
        AddCommandHandler("/setadmin", AddressOf HandleCommandSetPower)
        AddCommandHandler("/kick", AddressOf HandleCommandKick)
        AddCommandHandler("/ban", AddressOf HandleCommandBan)

        ' Starts the server loop
        ServerLoop.ServerLoop()

    End Sub

    Private Function ConsoleEventCallback(eventType As Integer) As Boolean
        If eventType = 2 Then
            Console.WriteLine("Console window closing, death imminent")
            'cleanup and close
            DestroyServer()
        End If
        Return False
    End Function

    Private handler As ConsoleEventDelegate
    ' Keeps it from getting garbage collected
    ' Pinvoke
    Private Delegate Function ConsoleEventDelegate(eventType As Integer) As Boolean

    <Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True)>
    Private Function SetConsoleCtrlHandler(callback As ConsoleEventDelegate, add As Boolean) As Boolean
    End Function

    Sub UpdateCaption()
        Console.Title = Options.Game_Name & " <IP " & MyIPAddress & " Port " & Options.Port & "> (" & GetPlayersOnline() & " Players Online" & ")"
        'frmServer.Text = Options.Game_Name & " <IP " & MyIPAddress & " Port " & Options.Port & "> (" & GetPlayersOnline() & " Players Online" & ")"
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
        TextAdd(Status)
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
        Console.WriteLine(Msg)

        'If ConsoleText = "" Then
        '    ConsoleText = ConsoleText & Msg
        'Else
        '    ConsoleText = ConsoleText & vbNewLine & Msg
        'End If
        'Try
        'UpdateUI()
        'Catch ex As Exception
        '    'Dont handle error
        'End Try
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

    Sub ErrorHandler(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
        Dim e As Exception = DirectCast(args.ExceptionObject, Exception)
        Dim myFilePath As String = "\ErrorLog.log"

        Using sw As New StreamWriter(File.Open(myFilePath, FileMode.Append))
            sw.WriteLine(DateTime.Now)
            sw.WriteLine(e.Message)
        End Using

        MessageBox.Show("An unexpected error occured. Application will be terminated.")
        End
    End Sub

End Module

