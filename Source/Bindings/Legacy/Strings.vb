Imports System.IO

Public NotInheritable Class Strings
    Private Sub New()
    End Sub

    Public Enum OrionComponent
        Client = 0
        Editor
        Server
    End Enum

    Private Shared DefaultLanguage As Language
    Private Shared SelectedLanguage As Language

    Public Shared Sub Init(component As OrionComponent, language As String)
        Dim langDir As String = ""
        Dim defaultFile As String = ""
        Dim strComponent As String = ""

        Select Case component
            Case OrionComponent.Client
                strComponent = "Client"
                'defaultFile = Properties.Resources.Client_English

                If Not Directory.Exists("Data") Then
                    Directory.CreateDirectory("Data")
                End If

                langDir = Path.Combine("Data", "languages")
                If Not Directory.Exists(langDir) Then
                    Directory.CreateDirectory(langDir)
                End If
                Exit Select
            Case OrionComponent.Editor
                strComponent = "Editor"
                'defaultFile = Properties.Resources.Editor_English

                If Not Directory.Exists("Data") Then
                    Directory.CreateDirectory("Data")
                End If

                langDir = Path.Combine("Data", "languages")
                If Not Directory.Exists(langDir) Then
                    Directory.CreateDirectory(langDir)
                End If
                Exit Select
            Case OrionComponent.Server
                strComponent = "Server"
                'defaultFile = Properties.Resources.Server_English

                If Not Directory.Exists("data") Then
                    Directory.CreateDirectory("data")
                End If

                langDir = Path.Combine("data", "languages")
                If Not Directory.Exists(langDir) Then
                    Directory.CreateDirectory(langDir)
                End If
                Exit Select
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(component), component, Nothing)
        End Select

        'If we don't have the default language file, load it from resources
        If Not File.Exists(Path.Combine(langDir, strComponent & Convert.ToString("_English.xml"))) Then
            'Copy Client.English.xml from resources
            File.WriteAllText(Path.Combine(langDir, strComponent & Convert.ToString("_English.xml")), defaultFile)
        End If

        DefaultLanguage = New Language(Path.Combine(langDir, strComponent & Convert.ToString("._English.xml")))
        If File.Exists(Path.Combine(langDir, (Convert.ToString(strComponent & Convert.ToString("_")) & language) + ".xml")) Then
            SelectedLanguage = New Language(Path.Combine(langDir, (Convert.ToString(strComponent & Convert.ToString("_")) & language) + ".xml"))
        End If

    End Sub

    Public Shared Function [Get](section As String, id As String, ParamArray args As Object()) As String
        If SelectedLanguage IsNot Nothing AndAlso SelectedLanguage.Loaded() AndAlso SelectedLanguage.HasString(section, id) Then
            Return SelectedLanguage.GetString(section, id, args)
        End If
        If DefaultLanguage IsNot Nothing AndAlso DefaultLanguage.Loaded() AndAlso DefaultLanguage.HasString(section, id) Then
            Return DefaultLanguage.GetString(section, id, args)
        End If
        Return "Not Found"
    End Function
End Class