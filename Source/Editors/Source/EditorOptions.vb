Imports Orion

Public Class EditorOptions
    Inherits AbstractOptions

    Public Const KEY_SAVEPASS As String = "savepass"
    Public Const KEY_PASSWORD As String = "password"
    Public Const KEY_USERNAME As String = "username"
    Public Const KEY_IP As String = "ip"
    Public Const KEY_PORT As String = "port"
    Public Const KEY_MENUMUSIC As String = "menumusic"
    Public Const KEY_MUSIC As String = "music"
    Public Const KEY_SOUND As String = "sound"
    Public Const KEY_VOLUME As String = "volume"
    Public Const KEY_SCREENSIZE As String = "screensize"

    Public Property SavePass As Boolean
        Get
            Return Options(KEY_SavePass)
        End Get
        Set(value As Boolean)
            Options(KEY_SavePass) = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return Options(KEY_Password)
        End Get
        Set(value As String)
            Options(KEY_Password) = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return Options(KEY_Username)
        End Get
        Set(value As String)
            Options(KEY_Username) = value
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
            Return Options(KEY_Port)
        End Get
        Set(value As Integer)
            Options(KEY_Port) = value
        End Set
    End Property

    Public Property MenuMusic As String
        Get
            Return Options(KEY_MenuMusic)
        End Get
        Set(value As String)
            Options(KEY_MenuMusic) = value
        End Set
    End Property

    Public Property Music As Byte
        Get
            Return Options(KEY_Music)
        End Get
        Set(value As Byte)
            Options(KEY_Music) = value
        End Set
    End Property

    Public Property Sound As Byte
        Get
            Return Options(KEY_Sound)
        End Get
        Set(value As Byte)
            Options(KEY_Sound) = value
        End Set
    End Property

    Public Property Volume As Single
        Get
            Return Options(KEY_Volume)
        End Get
        Set(value As Single)
            Options(KEY_Volume) = value
        End Set
    End Property

    Public Property ScreenSize As Byte
        Get
            Return Options(KEY_ScreenSize)
        End Get
        Set(value As Byte)
            Options(KEY_ScreenSize) = value
        End Set
    End Property

End Class
