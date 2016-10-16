Module ServerGlobals

    Public ConsoleText As String

    ' Used for closing key doors again
    Public KeyTimer As Integer
    ' Used for gradually giving back npcs hp
    Public GiveNPCHPTimer As Integer
    ' Used for logging
    Public ServerLog As Boolean
    ' Text vars
    Public vbQuote As String
    ' Maximum classes
    Public Max_Classes As Byte
    ' Used for server loop
    Public ServerOnline As Boolean
    ' Used for outputting text
    Public NumLines As Integer
    ' Used to handle shutting down server with countdown.
    Public isShuttingDown As Boolean
    Public Secs As Integer
    Public TotalPlayersOnline As Integer

    Public Game_Port As Integer

    Public TempMapData As Byte

    Public NeedToUpDatePlayerList As Boolean

    Public Gettingmap As Boolean
End Module
