Imports System.Collections.Concurrent
Imports System.Threading

Module ServerConsole
    Public Delegate Sub HandleConsoleCommand(ByVal line As String, ByVal command As String, ByVal parts As String())

    Private threadConsole As Thread
    Private consoleRunning As Boolean
    Private commandHandlers As ConcurrentDictionary(Of String, ConcurrentStack(Of HandleConsoleCommand))
    Private globalCommandHandlers As ConcurrentStack(Of HandleConsoleCommand)

    Sub Main()
        commandHandlers = New ConcurrentDictionary(Of String, ConcurrentStack(Of HandleConsoleCommand))
        globalCommandHandlers = New ConcurrentStack(Of HandleConsoleCommand)

        ' Spawn a thread for the console
        threadConsole = New Thread(New ThreadStart(AddressOf ConsoleThread))
        threadConsole.Start()

        ' Spin up the server on the main thread
        InitServer()
    End Sub

    Private Sub ConsoleThread()
        Dim line As String

        consoleRunning = True
        While (consoleRunning)
            line = Console.ReadLine()

            If (String.IsNullOrWhiteSpace(line)) Then
                consoleRunning = False
                Exit While
            Else
                ParseCommand(line)
            End If
        End While
    End Sub

    Private Sub ParseCommand(ByVal line As String)
        Dim parts As String() = line.Split(" ")

        ' This is just a double check, but if there are no parts to the command just skip
        If (parts.Length < 1) Then
            Return
        End If

        Dim command As String = parts(0)
        If (String.IsNullOrWhiteSpace(command)) Then
            Return
        End If

        FireEvent(globalCommandHandlers, line, command, parts)
        FireEvent(GetCommandHandlers(command), line, command, parts)
    End Sub

    Private Sub FireEvent(ByRef handlers As ConcurrentStack(Of HandleConsoleCommand), ByVal line As String, ByVal command As String, ByVal parts As String())
        For Each handler As HandleConsoleCommand In handlers
            handler.Invoke(line, command, parts)
        Next
    End Sub

    Private Function GetCommandHandlers(ByVal command As String) As ConcurrentStack(Of HandleConsoleCommand)
        Return commandHandlers.GetOrAdd(command, New ConcurrentStack(Of HandleConsoleCommand))
    End Function

    Public Sub AddGlobalHandler(ByRef handler As HandleConsoleCommand)
        globalCommandHandlers.Push(handler)
    End Sub

    Public Sub ClearGlobalHandlers(ByRef handler As HandleConsoleCommand)
        globalCommandHandlers.Clear()
    End Sub

    Public Sub AddCommandHandler(ByVal command As String, ByRef handler As HandleConsoleCommand)
        GetCommandHandlers(command).Push(handler)
    End Sub

    Public Sub ClearCommandHandlers(ByVal command As String)
        GetCommandHandlers(command).Clear()
    End Sub

#Region "Commands"
    Sub HandleCommandHelp(ByVal Line As String, ByVal Command As String, ByVal Parts As String())
        TextAdd("/help, Shows this message.")
        TextAdd("/exit, Closes down the server.")
        TextAdd("/setadmin, Sets player access level, use with '/setadmin playername powerlvl' powerlevel goes from 0 for player, to 4 to creator.")
    End Sub

    Sub HandleCommandExit(ByVal Line As String, ByVal Command As String, ByVal Parts As String())
        DestroyServer()
    End Sub

    Sub HandleCommandSetPower(ByVal Line As String, ByVal Command As String, ByVal Parts As String())
        Dim Name As String, Power As Integer

        If Parts.Length < 3 Then Exit Sub

        Name = Parts(1)
        Power = CInt(Parts(2))

        If Not FindPlayer(Name) > 0 Then Exit Sub

        Select Case Power
            Case 0
                SetPlayerAccess(FindPlayer(Name), Power)
                SendPlayerData(FindPlayer(Name))
                PlayerMsg(FindPlayer(Name), "Your PowerLevel has been set to Player Rank!")
                TextAdd("Successfully set the power level to " & Power & " for player " & Name)
            Case 1
                SetPlayerAccess(FindPlayer(Name), Power)
                SendPlayerData(FindPlayer(Name))
                PlayerMsg(FindPlayer(Name), "Your PowerLevel has been set to Monitor Rank!")
                TextAdd("Successfully set the power level to " & Power & " for player " & Name)
            Case 2
                SetPlayerAccess(FindPlayer(Name), Power)
                SendPlayerData(FindPlayer(Name))
                PlayerMsg(FindPlayer(Name), "Your PowerLevel has been set to Mapper Rank!")
                TextAdd("Successfully set the power level to " & Power & " for player " & Name)
            Case 3
                SetPlayerAccess(FindPlayer(Name), Power)
                SendPlayerData(FindPlayer(Name))
                PlayerMsg(FindPlayer(Name), "Your PowerLevel has been set to Developer Rank!")
                TextAdd("Successfully set the power level to " & Power & " for player " & Name)
            Case 4
                SetPlayerAccess(FindPlayer(Name), Power)
                SendPlayerData(FindPlayer(Name))
                PlayerMsg(FindPlayer(Name), "Your PowerLevel has been set to Creator Rank!")
                TextAdd("Successfully set the power level to " & Power & " for player " & Name)
            Case Else
                TextAdd("Failed to set the power level to " & Power & " for player " & Name)
        End Select

    End Sub


#End Region

End Module
