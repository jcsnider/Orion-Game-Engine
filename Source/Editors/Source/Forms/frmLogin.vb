Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub

    Private Sub frmLogin_UnLoad(sender As Object, e As EventArgs) Handles MyBase.Closing
        CloseEditor()
    End Sub

    Private Sub tmrConnect_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrConnect.Tick
        Static i As Integer
        If IsConnected() = True Then
            lblConnectionStatus.ForeColor = Color.Green
            lblConnectionStatus.Text = "Online..."

            tmrConnect.Stop()
        Else
            lblConnectionStatus.ForeColor = Color.Red
            i = i + 1
            If i = 5 Then
                Connect()
                lblConnectionStatus.Text = "Reconnecting..."
                lblConnectionStatus.ForeColor = Color.Orange
                i = 0
            Else
                lblConnectionStatus.Text = "Offline..."
            End If
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsConnected() Then
            SendEditorLogin(txtLogin.Text, txtPassword.Text)
            Exit Sub
        End If
    End Sub

#Region "Editors"
    Private Sub btnMapEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMapEditor.Click
        SendRequestEditMap()
    End Sub
    Private Sub btnItemEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnItemEditor.Click
        SendRequestItems()
        SendRequestEditItem()
    End Sub

    Private Sub btnResourceEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResourceEditor.Click
        SendRequestResources()
        SendRequestEditResource()
    End Sub

    Private Sub btnNPCEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNPCEditor.Click
        SendRequestNPCS()
        SendRequestEditNpc()
    End Sub

    Private Sub btnSkillEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSkillEditor.Click
        SendRequestSkills()
        SendRequestEditSkill()
    End Sub

    Private Sub btnShopEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShopEditor.Click
        SendRequestShops()
        SendRequestEditShop()
    End Sub

    Private Sub btnAnimationEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnimationEditor.Click
        SendRequestAnimations()
        SendRequestEditAnimation()
    End Sub

    Private Sub btnQuest_Click(sender As Object, e As EventArgs) Handles btnQuest.Click
        SendRequestQuests()
        SendRequestEditQuest()
    End Sub

    Private Sub btnhouseEditor_Click(sender As Object, e As EventArgs) Handles btnhouseEditor.Click
        SendRequestEditHouse()
    End Sub

    Private Sub btnProjectiles_Click(sender As Object, e As EventArgs) Handles btnProjectiles.Click
        SendRequestProjectiles()
        SendRequestEditProjectiles()
    End Sub

    Private Sub btnClassEditor_Click(sender As Object, e As EventArgs) Handles btnClassEditor.Click
        SendRequestClasses()
        SendRequestEditClass()
    End Sub
#End Region

End Class
