Module ServerConstants

    ' Path constants
    Public Const ADMIN_LOG As String = "admin.log"
    Public Const PLAYER_LOG As String = "player.log"

    ' Version constants
    Public Const CLIENT_MAJOR As Byte = 4
    Public Const CLIENT_MINOR As Byte = 0
    Public Const CLIENT_REVISION As Byte = 0

    Public MAX_CHARS As Byte = 3

    ' General constants
    Public Const MAX_HOTBAR As Byte = 7

    Public Const StatPtsPerLvl As Byte = 3

    ' Map constants
    Public Const MAX_MAPX As Byte = 50
    Public Const MAX_MAPY As Byte = 50


    ' ********************************************
    ' Default starting location [Server Only]
    Public Const START_MAP As Integer = 1
    Public Const START_X As Integer = 13
    Public Const START_Y As Integer = 7
End Module
