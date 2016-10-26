Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SFML.CSFML.Activate()

        CheckTilesets()
        CheckCharacters()
        CheckPaperdolls()
        CheckAnimations()
        CheckItems()
        CheckResources()
        CheckSkillIcons()
        CheckFaces()
        CheckFog()
        CacheMusic()
        CacheSound()

        CheckFurniture()
        CheckProjectiles()

        InitGraphics()
        InitMessages()

        ReDim Autotile(0 To Map.MaxX, 0 To Map.MaxY)

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)
                For i = 0 To MapLayer.Count - 1
                    ReDim Autotile(X, Y).Layer(i).srcX(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).srcY(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).QuarterTile(0 To 4)
                Next
            Next
        Next

        ''Housing
        ReDim House(0 To MAX_HOUSES)
        ReDim HouseConfig(0 To MAX_HOUSES)

        'quests
        ReDim Quest(MAX_QUESTS)
        For i = 0 To MAX_QUESTS
            ReDim Quest(i).Requirement(3)
            ReDim Quest(i).Chat(3)
            ReDim Quest(i).Task(MAX_TASKS)
        Next

        ReDim Map.Npc(0 To MAX_MAP_NPCS)

        ReDim Item(0 To MAX_ITEMS)
        For i = 0 To MAX_ITEMS
            For x = 0 To Stats.Count - 1
                ReDim Item(i).Add_Stat(x)
            Next
            For x = 0 To Stats.Count - 1
                ReDim Item(i).Stat_Req(x)
            Next

            ReDim Item(i).FurnitureBlocks(0 To 3, 0 To 3)
            ReDim Item(i).FurnitureFringe(0 To 3, 0 To 3)
        Next

        ReDim Npc(0 To MAX_NPCS)
        For i = 0 To MAX_NPCS
            For x = 0 To Stats.Count - 1
                ReDim Npc(i).Stat(x)
            Next

            ReDim Npc(i).DropChance(5)
            ReDim Npc(i).DropItem(5)
            ReDim Npc(i).DropItemValue(5)

            ReDim Npc(i).Skill(6)
        Next

        ReDim MapNpc(0 To MAX_MAP_NPCS)
        For i = 0 To MAX_MAP_NPCS
            For x = 0 To Vitals.Count - 1
                ReDim MapNpc(i).Vital(x)
            Next
        Next

        ReDim Shop(0 To MAX_SHOPS)
        For i = 0 To MAX_SHOPS
            For x = 0 To MAX_TRADES
                ReDim Shop(i).TradeItem(x)
            Next
        Next

        ReDim Animation(0 To MAX_ANIMATIONS)
        For i = 0 To MAX_ANIMATIONS
            For x = 0 To 1
                ReDim Animation(i).Sprite(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).Frames(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).LoopCount(x)
            Next
            For x = 0 To 1
                ReDim Animation(i).looptime(x)
            Next
        Next

        'craft
        ClearRecipes()

        GameDestroyed = False
        GameStarted = True

        GameLoop()
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

    Private Sub tmrThread_Tick(sender As Object, e As EventArgs) Handles tmrThread.Tick

        If InitEditor = True Then
            pnlAdmin.Visible = True
            InitEditor = False
        End If

        If QuestEditorShow = True Then
            With frmEditor_Quest
                Editor = EDITOR_TASKS
                .lstIndex.Items.Clear()

                ' Add the names
                For I = 1 To MAX_QUESTS
                    .lstIndex.Items.Add(I & ": " & Trim$(Quest(I).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                QuestEditorInit()
            End With
            QuestEditorShow = False
        End If

        If InitAnimationEditor = True Then
            With frmEditor_Animation
                Editor = EDITOR_ANIMATION
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_ANIMATIONS
                    .lstIndex.Items.Add(i & ": " & Trim$(Animation(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                AnimationEditorInit()
            End With
            InitAnimationEditor = False
        End If

        If InitMapEditor = True Then
            MapEditorInit()
            InitMapEditor = False
        End If

        If InitMapProperties = True Then
            MapPropertiesInit()
            InitMapProperties = False
        End If

        If InitItemEditor = True Then
            ItemEditorPreInit()
            InitItemEditor = False
        End If

        If InitRecipeEditor = True Then
            RecipeEditorPreInit()
            InitRecipeEditor = False
        End If

        If InitClassEditor = True Then
            ClassEditorInit()
            InitClassEditor = False
        End If

        If LoadClassInfo = True Then
            LoadClass()
            LoadClassInfo = False
        End If

        If InitResourceEditor = True Then
            Dim i As Integer

            With frmEditor_Resource
                Editor = EDITOR_RESOURCE
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_RESOURCES
                    If Resource(i).Name Is Nothing Then Resource(i).Name = ""
                    If Resource(i).SuccessMessage Is Nothing Then Resource(i).SuccessMessage = ""
                    If Resource(i).EmptyMessage Is Nothing Then Resource(i).EmptyMessage = ""
                    .lstIndex.Items.Add(i & ": " & Trim$(Resource(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                ResourceEditorInit()
            End With
            InitResourceEditor = False
        End If

        If InitNPCEditor = True Then
            With frmEditor_NPC
                Editor = EDITOR_NPC
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_NPCS
                    .lstIndex.Items.Add(i & ": " & Trim$(Npc(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                NpcEditorInit()
            End With
            InitNPCEditor = False
        End If

        If InitSkillEditor = True Then
            With frmEditor_Skill
                Editor = EDITOR_SKILL
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_SKILLS
                    .lstIndex.Items.Add(i & ": " & Trim$(Skill(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                SkillEditorInit()
            End With
            InitSkillEditor = False
        End If

        If InitShopEditor = True Then
            With frmEditor_Shop
                Editor = EDITOR_SHOP
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_SHOPS
                    .lstIndex.Items.Add(i & ": " & Trim$(Shop(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                ShopEditorInit()
            End With
            InitShopEditor = False
        End If

        If InitAnimationEditor = True Then
            With frmEditor_Animation
                Editor = EDITOR_ANIMATION
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_ANIMATIONS
                    .lstIndex.Items.Add(i & ": " & Trim$(Animation(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                AnimationEditorInit()
            End With
            InitAnimationEditor = False
        End If

        If HouseEdit = True Then
            With frmEditor_House
                Editor = EDITOR_HOUSE
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_HOUSES
                    .lstIndex.Items.Add(i & ": " & Trim$(House(i).ConfigName))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
            End With

            HouseEditorInit()

            HouseEdit = False
        End If

        If InitEventEditorForm = True Then
            frmEditor_Events.InitEventEditorForm()

            ' populate form
            With frmEditor_Events
                ' set the tabs
                .tabPages.TabPages.Clear()

                For i = 1 To tmpEvent.PageCount
                    .tabPages.TabPages.Add(Str(i))
                Next
                ' items
                .cmbHasItem.Items.Clear()
                .cmbHasItem.Items.Add("None")
                For i = 1 To MAX_ITEMS
                    .cmbHasItem.Items.Add(i & ": " & Trim$(Item(i).Name))
                Next
                ' variables
                .cmbPlayerVar.Items.Clear()
                .cmbPlayerVar.Items.Add("None")
                For i = 1 To MAX_VARIABLES
                    .cmbPlayerVar.Items.Add(i & ". " & Variables(i))
                Next
                ' variables
                .cmbPlayerSwitch.Items.Clear()
                .cmbPlayerSwitch.Items.Add("None")
                For i = 1 To MAX_SWITCHES
                    .cmbPlayerSwitch.Items.Add(i & ". " & Switches(i))
                Next
                ' name
                .txtName.Text = tmpEvent.Name
                ' enable delete button
                If tmpEvent.PageCount > 1 Then
                    .btnDeletePage.Enabled = True
                Else
                    .btnDeletePage.Enabled = False
                End If
                .btnPastePage.Enabled = False
                ' Load page 1 to start off with
                curPageNum = 1
                EventEditorLoadPage(curPageNum)

                .scrlShowTextFace.Maximum = NumFaces
                .scrlShowChoicesFace.Maximum = NumFaces
            End With
            ' show the editor
            frmEditor_Events.Show()

            InitEventEditorForm = False
        End If

        If InitProjectileEditor = True Then
            With frmEditor_Projectile
                Editor = EDITOR_PROJECTILE
                .lstIndex.Items.Clear()

                ' Add the names
                For i = 1 To MAX_PROJECTILES
                    .lstIndex.Items.Add(i & ": " & Trim$(Projectiles(i).Name))
                Next

                .Show()
                .lstIndex.SelectedIndex = 0
                ProjectileEditorInit()
            End With

            InitProjectileEditor = False
        End If

        If frmEditor_Projectile.Visible Then
            EditorProjectile_DrawProjectile()
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
