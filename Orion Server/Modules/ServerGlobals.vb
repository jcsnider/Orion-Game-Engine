Module ServerGlobals

    Public ConsoleText As String

    ' Used for closing key doors again
    Public KeyTimer As Long
    ' Used for gradually giving back npcs hp
    Public GiveNPCHPTimer As Long
    ' Used for logging
    Public ServerLog As Boolean
    ' Text vars
    Public vbQuote As String
    ' Maximum classes
    Public Max_Classes As Byte
    ' Used for server loop
    Public ServerOnline As Boolean
    ' Used for outputting text
    Public NumLines As Long
    ' Used to handle shutting down server with countdown.
    Public isShuttingDown As Boolean
    Public Secs As Long
    Public TotalPlayersOnline As Long

    Public Game_Port As Long

    Public TempMapData As Byte

    Public NeedToUpDatePlayerList As Boolean

    Public Gettingmap As Boolean
End Module
