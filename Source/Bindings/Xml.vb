Imports System.Xml
Imports System.IO

Imports System.Text


'Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

'2.        Dim myXml As New XmlClass

'3.        Dim BookMark As String = vbNullString

'4. 

'5.        myXml.Filename = "C:\out\book.xml"

'6.        myXml.Root = "Main"

'7.        'Write some data lets use a bookmark example.

'8. 

'9.        myXml.WriteString("Bookmark", "Name", "Google")

'10.        myXml.WriteString("Bookmark", "Website", "http://www.google.com")

'11.        myXml.WriteString("Bookmark", "Info", "Google Home Page!")

'12. 

'13.        'Read and show the boomark we just added.

'14.        BookMark = myXml.ReadString("Bookmark", "Website", "Error")

'15.        MessageBox.Show("BookMark: " & BookMark, "Example", MessageBoxButtons.OK, MessageBoxIcon.Information)

'16. 

'17.        'Remove bookmark.

'18.        myXml.RemoveNode("Bookmark", "Website")

'19. 

'20.        'Just show agian make sure it gone.

'21.        BookMark = myXml.ReadString("Bookmark", "Website", "http://www.localhost")

'22.        MessageBox.Show("BookMark: " & BookMark, "Example", MessageBoxButtons.OK, MessageBoxIcon.Information)

'23.    End Sub

Public Class XmlClass
    Private m_Filename As String = vbNullString
    Private m_Root As String = "Settings"

    Public Property Root As String
        Get
            Return m_Root
        End Get

        Set(ByVal value As String)
            m_Root = value
        End Set

    End Property

    Public Property Filename As String
        Get
            Return m_Filename
        End Get

        Set(ByVal value As String)
            m_Filename = value
        End Set

    End Property

    Private Sub NewXmlDocument()

        Dim xmlTextWrite As New XmlTextWriter(Me.Filename, Encoding.UTF8)

        'Write blank xml doucment.
        With xmlTextWrite
            .WriteStartDocument(True)
            .WriteStartElement(Root)
            .WriteEndElement()
            .WriteEndDocument()
            .Flush()
            .Close()
        End With

    End Sub

    Public Sub WriteString(ByVal Selection As String, ByVal Name As String, ByVal Value As String)
        Dim xmlDoc As New XmlDocument()

        'Check if xml filename is here.
        If Not File.Exists(Me.Filename) Then
            'Create new blank xml file.
            NewXmlDocument()
        End If

        'Load xml document.
        xmlDoc.Load(Me.Filename)

        'Check for settings selection.
        If xmlDoc.SelectSingleNode(Root & "/" & Selection) Is Nothing Then
            'Create selection.
            xmlDoc.DocumentElement.AppendChild(DirectCast(xmlDoc.CreateElement(Selection), XmlNode))
        End If

        'Check for element node
        Dim xmlNode As XmlNode = xmlDoc.SelectSingleNode(Root & "/" & Selection & "/Element[@Name='" & Name & "']")

        If XmlNode Is Nothing Then
            Dim element As XmlElement = xmlDoc.CreateElement("Element")
            'Write new element values.
            element.SetAttribute("Name", Name)
            element.SetAttribute("Value", Value)
            'Add new node.
            xmlDoc.DocumentElement(Selection).AppendChild(DirectCast(element, XmlNode))
        Else
            'Update node values.
            xmlNode.Attributes("Name").Value = Name
            xmlNode.Attributes("Value").Value = Value
        End If
        'Save xml data.

        xmlDoc.Save(Me.Filename)

        xmlDoc = Nothing
    End Sub

    Public Function ReadString(ByVal Selection As String, ByVal Name As String, Optional ByVal DefaultValue As String = "") As String
        Dim xmlDoc As New XmlDocument()

        If Not File.Exists(Me.Filename) Then
            Return DefaultValue
        Else
            'Load xml document.
            xmlDoc.Load(Filename)
            'Read node value.
            Dim XmlNode = xmlDoc.SelectSingleNode(Root & "/" & Selection & "/Element[@Name='" & Name & "']")

            'Check if node is here.
            If XmlNode Is Nothing Then
                Return DefaultValue
            Else
                'Return xml node value
                Return (XmlNode.Attributes("Value").Value)
                'Clean up
                xmlDoc = Nothing
            End If
        End If
    End Function

    Public Sub RemoveNode(ByVal Selection As String, ByVal Name As String)
        Dim xmlDoc As New XmlDocument()

        'Remove xml node
        If File.Exists(Me.Filename) Then
            'Load xml document.
            xmlDoc.Load(Filename)
            'Read node value.
            Dim XmlNode = xmlDoc.SelectSingleNode(Root & "/" & Selection & "/Element[@Name='" & Name & "']")
            'Check if node is here.
            If Not XmlNode Is Nothing Then
                xmlDoc.SelectSingleNode(Root & "/" & Selection).RemoveChild(XmlNode)
                'Update xml document.
                xmlDoc.Save(Filename)
            End If
        End If
    End Sub

End Class


