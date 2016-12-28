Module ServerGlobals
    Public Debugging As Boolean

    Public ConsoleText As String
    Public ErrorCount As Integer

    ' Used for closing key doors again
    Public KeyTimer As Integer
    ' Used for gradually giving back npcs hp
    Public GiveNPCHPTimer As Integer
    Public GiveNPCMPTimer As Integer

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
    Public TempMapData As Byte

    Public Gettingmap As Boolean
End Module