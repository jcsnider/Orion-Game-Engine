Imports Orion

Public Class ClientOptions
    Inherits AbstractOptions

    Public Const KEY_SAVEPASS = "savepass"
    Public Const KEY_USERNAME = "username"
    Public Const KEY_PASSWORD = "password"
    Public Const KEY_IP = "ip"
    Public Const KEY_PORT = "port"
    Public Const KEY_MENUMUSIC = "menumusic"
    Public Const KEY_MUSIC = "music"
    Public Const KEY_SOUND = "sound"
    Public Const KEY_VOLUME = "volume"
    Public Const KEY_SCREENSIZE = "screensize"
    Public Const KEY_HIGHEND = "highend"
    Public Const KEY_SHOWNPCBAR = "shownpcbar"

    Public Property SavePass As Boolean
        Get
            Return Options(KEY_SAVEPASS)
        End Get
        Set(value As Boolean)
            Options(KEY_SAVEPASS) = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return Options(KEY_PASSWORD)
        End Get
        Set(value As String)
            Options(KEY_PASSWORD) = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return Options(KEY_USERNAME)
        End Get
        Set(value As String)
            Options(KEY_USERNAME) = value
        End Set
    End Property

    Public Property IP As String
        Get
            Return Options(KEY_IP)
        End Get
        Set(value As String)
            Options(KEY_IP) = value
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

    Public Property MenuMusic As String
        Get
            Return Options(KEY_MENUMUSIC)
        End Get
        Set(value As String)
            Options(KEY_MENUMUSIC) = value
        End Set
    End Property

    Public Property Music As Byte
        Get
            Return Options(KEY_MUSIC)
        End Get
        Set(value As Byte)
            Options(KEY_MUSIC) = value
        End Set
    End Property

    Public Property Sound As Byte
        Get
            Return Options(KEY_SOUND)
        End Get
        Set(value As Byte)
            Options(KEY_SOUND) = value
        End Set
    End Property

    Public Property Volume As Single
        Get
            Return Options(KEY_VOLUME)
        End Get
        Set(value As Single)
            Options(KEY_VOLUME) = value
        End Set
    End Property

    Public Property ScreenSize As Byte
        Get
            Return Options(KEY_SCREENSIZE)
        End Get
        Set(value As Byte)
            Options(KEY_SCREENSIZE) = value
        End Set
    End Property

    Public Property HighEnd As Byte
        Get
            Return Options(KEY_HIGHEND)
        End Get
        Set(value As Byte)
            Options(KEY_HIGHEND) = value
        End Set
    End Property

    Public Property ShowNpcBar As Byte
        Get
            Return Options(KEY_SHOWNPCBAR)
        End Get
        Set(value As Byte)
            Options(KEY_SHOWNPCBAR) = value
        End Set
    End Property
End Class
