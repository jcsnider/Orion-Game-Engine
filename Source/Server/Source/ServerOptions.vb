Imports Orion

Public Class ServerOptions
    Inherits AbstractOptions

    Public Const KEY_GAMENAME As String = "gamename"
    Public Const KEY_MOTD As String = "motd"
    Public Const KEY_PORT As String = "port"
    Public Const KEY_WEBSITE As String = "website"
    Public Const KEY_STARTMAP As String = "startmap"
    Public Const KEY_STARTX As String = "startx"
    Public Const KEY_STARTY As String = "starty"

    Public Property GameName As String
        Get
            Return Options(KEY_GAMENAME)
        End Get
        Set(value As String)
            Options(KEY_GAMENAME) = value
        End Set
    End Property

    Public Property Motd As String
        Get
            Return Options(KEY_MOTD)
        End Get
        Set(value As String)
            Options(KEY_MOTD) = value
        End Set
    End Property

    Public Property Port As Integer
        Get
            Return Options(KEY_PORT)
        End Get
        Set(value As Integer)
            Options(KEY_PORT) = value
        End Set
    End Property

    Public Property Website As String
        Get
            Return Options(KEY_WEBSITE)
        End Get
        Set(value As String)
            Options(KEY_WEBSITE) = value
        End Set
    End Property

    Public Property StartMap As Integer
        Get
            Return Options(KEY_STARTMAP)
        End Get
        Set(value As Integer)
            Options(KEY_STARTMAP) = value
        End Set
    End Property

    Public Property StartX As Integer
        Get
            Return Options(KEY_STARTX)
        End Get
        Set(value As Integer)
            Options(KEY_STARTX) = value
        End Set
    End Property

    Public Property StartY As Integer
        Get
            Return Options(KEY_STARTY)
        End Get
        Set(value As Integer)
            Options(KEY_STARTY) = value
        End Set
    End Property

End Class
