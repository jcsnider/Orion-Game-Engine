Imports System.IO

Module ServerGeneral
    Public Declare Function GetQueueStatus Lib "user32" (ByVal fuFlags As Integer) As Integer
    Public ServerDestroyed As Boolean
    Public MyIPAddress As String

    Public Function GetTickCount()
        Return Environment.TickCount
    End Function

    Sub InitServer()
        Dim i As Integer, F As Integer, x As Integer
        Dim time1 As Integer, time2 As Integer
        x = 0

        If Debugger.IsAttached Then
            ' Since there is a debugger attached,
            ' assume we are running from the IDE
            Debugging = True
        Else
            ' Assume we aren't running from the IDE
            Dim currentDomain As AppDomain = AppDomain.CurrentDomain
            AddHandler currentDomain.UnhandledException, AddressOf ErrorHandler
        End If

        Console.Title = "Orion+ Server"
        Console.SetWindowSize(120, 20)

        handler = New ConsoleEventDelegate(AddressOf ConsoleEventCallback)
        SetConsoleCtrlHandler(handler, True)

        time1 = GetTickCount()

        ' Initialize the random-number generator
        Randomize()

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
            ReDim Bank(i).Item(MAX_BANK)
            ReDim Bank(i).ItemRand(MAX_BANK)
            For x = 1 To MAX_BANK
                ReDim Bank(i).ItemRand(x).Stat(Stats.Count - 1)
            Next
        Next

        ReDim Player(0 To MAX_PLAYERS)

        For i = 0 To MAX_PLAYERS
            'multi char
            ReDim Player(i).Character(MAX_CHARS)
            For x = 1 To MAX_CHARS
                ReDim Player(i).Character(x).Switches(MAX_SWITCHES)
                ReDim Player(i).Character(x).Variables(MAX_VARIABLES)
                ReDim Player(i).Character(x).Vital(Vitals.Count - 1)
                ReDim Player(i).Character(x).Stat(Stats.Count - 1)
                ReDim Player(i).Character(x).Equipment(EquipmentType.Count - 1)
                ReDim Player(i).Character(x).Inv(MAX_INV)
                ReDim Player(i).Character(x).Skill(MAX_PLAYER_SKILLS)
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
            ReDim TempPlayer(i).PetSkillCD(4)
        Next

        For i = 0 To MAX_PLAYERS
            ReDim TempPlayer(i).TradeOffer(0 To MAX_INV)
        Next

        LoadTilePrefab()

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

        'parties
        ClearParties()

        'pets
        ReDim Pet(MAX_PETS)
        ClearPets()

        ' Check if the directory is there, if its not make it
        CheckDir(Path.Combine(Application.StartupPath, "data"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "items"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "maps"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "npcs"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "shops"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "skills"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "accounts"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "resources"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "animations"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "banks"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "logs"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "quests"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "recipes"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "pets"))
        CheckDir(Path.Combine(Application.StartupPath, "data", "projectiles"))

        ' set quote character
        vbQuote = Chr(34) ' "

        ' load options, set if they dont exist
        If Not FileExist(Path.Combine(Application.StartupPath, "data", "options.ini")) Then
            Options.Game_Name = "Orion+"
            Options.Port = 7001
            Options.Motd = "Welcome to the Orion+ Engine"
            Options.Website = "http://ascensiongamedev.com/index.php"
            Options.StartMap = 1
            Options.StartX = 13
            Options.StartY = 7
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
        Console.Title = String.Format("{0} <IP {1}:{2}> ({3} Players Online) Current Errors: {4}", Options.Game_Name, MyIPAddress, Options.Port, GetPlayersOnline(), ErrorCount)
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

        'pets
        SetStatus("Clearing pets...")
        ClearPets()
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

        'pets
        LoadPets()
    End Sub

    Sub TextAdd(ByVal Msg As String)
        Console.WriteLine(Msg)
    End Sub

    ' Used for checking validity of names
    Function IsNameLegal(ByVal sInput As Integer) As Boolean

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
            GlobalMsg(String.Format("Server Shutdown in {0} seconds.", Secs))
            TextAdd(String.Format("Automated Server Shutdown in {0} seconds.", Secs))
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
        Dim myFilePath As String = Path.Combine(Application.StartupPath, "data", "logs", "ErrorLog.log")

        Using sw As New StreamWriter(File.Open(myFilePath, FileMode.Append))
            sw.WriteLine(DateTime.Now)
            sw.WriteLine(GetExceptionInfo(e))
        End Using

        ErrorCount = ErrorCount + 1

        UpdateCaption()
    End Sub

    Public Function GetExceptionInfo(ex As Exception) As String
        Dim Result As String
        Dim hr As Integer = Runtime.InteropServices.Marshal.GetHRForException(ex)
        Result = ex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine
        Dim st As StackTrace = New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                Result &= "Line:" & sf.GetFileLineNumber() & " Filename: " & IO.Path.GetFileName(sf.GetFileName) & Environment.NewLine
            End If
        Next
        Return Result
    End Function
End Module