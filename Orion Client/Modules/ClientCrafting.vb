Imports System.Drawing
Imports System.Windows.Forms

Public Module ClientCrafting
#Region "Globals"
    Public Const ITEM_TYPE_RECIPES As Byte = 17
    Public Const TILE_TYPE_CRAFT As Byte = 15
    Public Const MAX_RECIPE As Long = 100
    Public Const MAX_INGREDIENT As Byte = 5
    Public Recipe_Changed(0 To MAX_RECIPE) As Boolean
    Public Recipe(MAX_RECIPE) As RecipeRec
    Public InitRecipeEditor As Boolean
    Public InitCrafting As Boolean
    Public InCraft As Boolean
    Public pnlCraftVisible As Boolean

    Public Const RecipeType_Herb As Byte = 0
    Public Const RecipeType_Wood As Byte = 1
    Public Const RecipeType_Metal As Byte = 2

    Public RecipeNames(MAX_RECIPE) As String

    Public chkKnownOnlyChecked As Boolean
    Public chkKnownOnlyEnabled As Boolean
    Public btnCraftEnabled As Boolean
    Public btnCraftStopEnabled As Boolean
    Public nudCraftAmountEnabled As Boolean
    Public lstRecipeEnabled As Boolean

    Public CraftAmountValue As Byte
    Public CraftProgressValue As Long
    Public picProductIndex As Long
    Public lblProductNameText As String
    Public lblProductAmountText As String

    Public picMaterialIndex(MAX_INGREDIENT) As Long
    Public lblMaterialName(MAX_INGREDIENT) As String
    Public lblMaterialAmount(MAX_INGREDIENT) As String

    Public SelectedRecipe As Long = 0

    Public Structure RecipeRec
        Dim Name As String
        Dim RecipeType As Byte
        Dim MakeItemNum As Long
        Dim MakeItemAmount As Long
        Dim Ingredients() As IngredientsRec
        Dim CreateTime As Byte
    End Structure

    Public Structure IngredientsRec
        Dim ItemNum As Long
        Dim Value As Long
    End Structure

#End Region

#Region "Database"
    Sub ClearRecipes()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            ClearRecipe(i)
        Next

    End Sub

    Sub ClearRecipe(ByVal Num As Long)
        Recipe(Num).Name = ""
        Recipe(Num).RecipeType = 0
        Recipe(Num).MakeItemNum = 0
        ReDim Recipe(Num).Ingredients(MAX_INGREDIENT)
    End Sub

    Public Sub ClearChanged_Recipe()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            Recipe_Changed(i) = Nothing
        Next

        ReDim Recipe_Changed(0 To MAX_RECIPE)
    End Sub
#End Region

#Region "Editor"
    Public Sub RecipeEditorPreInit()
        Dim i As Long

        With frmEditor_Recipe
            Editor = EDITOR_RECIPE
            .lstIndex.Items.Clear()

            ' Add the names
            For i = 1 To MAX_RECIPE
                .lstIndex.Items.Add(i & ": " & Trim$(Recipe(i).Name))
            Next

            'fill comboboxes
            .cmbMakeItem.Items.Clear()
            .cmbIngredient.Items.Clear()

            .cmbMakeItem.Items.Add("None")
            .cmbIngredient.Items.Add("None")
            For i = 1 To MAX_ITEMS
                .cmbMakeItem.Items.Add(Trim$(Item(i).Name))
                .cmbIngredient.Items.Add(Trim$(Item(i).Name))
            Next

            .Show()
            .lstIndex.SelectedIndex = 0
            RecipeEditorInit()
        End With
    End Sub

    Public Sub RecipeEditorInit()

        If frmEditor_Recipe.Visible = False Then Exit Sub
        EditorIndex = frmEditor_Recipe.lstIndex.SelectedIndex + 1

        With Recipe(EditorIndex)
            frmEditor_Recipe.txtName.Text = Trim$(.Name)

            frmEditor_Recipe.lstIngredients.Items.Clear()

            frmEditor_Recipe.cmbType.SelectedIndex = .RecipeType
            frmEditor_Recipe.cmbMakeItem.SelectedIndex = .MakeItemNum

            If .MakeItemAmount < 1 Then .MakeItemAmount = 1
            frmEditor_Recipe.nudAmount.Value = .MakeItemAmount

            If .CreateTime < 1 Then .CreateTime = 1
            frmEditor_Recipe.nudCreateTime.Value = .CreateTime

            UpdateIngredient()
        End With

        Recipe_Changed(EditorIndex) = True

    End Sub

    Public Sub RecipeEditorCancel()
        Editor = 0
        frmEditor_Recipe.Visible = False
        ClearChanged_Recipe()
        ClearRecipes()
        SendRequestRecipes()
    End Sub

    Public Sub RecipeEditorOk()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            If Recipe_Changed(i) Then
                SendSaveRecipe(i)
            End If
        Next

        frmEditor_Recipe.Visible = False
        Editor = 0
        ClearChanged_Recipe()
    End Sub

    Public Sub UpdateIngredient()
        Dim i As Long
        frmEditor_Recipe.lstIngredients.Items.Clear()

        For i = 1 To MAX_INGREDIENT
            With Recipe(EditorIndex).Ingredients(i)
                ' if none, show as none
                If .ItemNum = 0 And .Value = 0 Then
                    frmEditor_Recipe.lstIngredients.Items.Add("Empty")
                Else
                    frmEditor_Recipe.lstIngredients.Items.Add(Trim$(Item(.ItemNum).Name) & " X " & .Value)
                End If
            End With
        Next

        frmEditor_Shop.lstTradeItem.SelectedIndex = 0
    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_UpdateRecipe(ByVal data() As Byte)
        Dim n As Long, i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateRecipe Then Exit Sub

        'recipe index
        n = Buffer.ReadLong

        ' Update the Recipe
        Recipe(n).Name = Trim$(Buffer.ReadString)
        Recipe(n).RecipeType = Buffer.ReadLong
        Recipe(n).MakeItemNum = Buffer.ReadLong
        Recipe(n).MakeItemAmount = Buffer.ReadLong

        For i = 1 To MAX_INGREDIENT
            Recipe(n).Ingredients(i).ItemNum = Buffer.ReadLong()
            Recipe(n).Ingredients(i).Value = Buffer.ReadLong()
        Next

        Recipe(n).CreateTime = Buffer.ReadLong

        Buffer = Nothing

    End Sub

    Sub Packet_RecipeEditor(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SRecipeEditor Then Exit Sub

        InitRecipeEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_SendPlayerRecipe(ByVal data() As Byte)
        Dim Buffer As ByteBuffer, i As Long
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SSendPlayerRecipe Then Exit Sub

        For i = 1 To MAX_RECIPE
            Player(MyIndex).RecipeLearned(i) = Buffer.ReadLong
        Next

        Buffer = Nothing
    End Sub

    Sub Packet_OpenCraft(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SOpenCraft Then Exit Sub

        InitCrafting = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateCraft(ByVal data() As Byte)
        Dim Buffer As ByteBuffer, done As Byte
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ServerPackets.SUpdateCraft Then Exit Sub

        done = Buffer.ReadLong

        If done = 1 Then
            InitCrafting = True
        Else

            CraftProgressValue = 0
            CraftTimerEnabled = True
        End If

        Buffer = Nothing
    End Sub
#End Region

#Region "OutGoing Packets"
    Sub SendRequestRecipes()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ClientPackets.CRequestRecipes)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestEditRecipes()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ClientPackets.CRequestEditRecipes)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSaveRecipe(ByVal RecipeNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ClientPackets.CSaveRecipe)

        Buffer.WriteLong(RecipeNum)

        Buffer.WriteString(Trim$(Recipe(RecipeNum).Name))
        Buffer.WriteLong(Recipe(RecipeNum).RecipeType)
        Buffer.WriteLong(Recipe(RecipeNum).MakeItemNum)
        Buffer.WriteLong(Recipe(RecipeNum).MakeItemAmount)

        For i = 1 To MAX_INGREDIENT
            Buffer.WriteLong(Recipe(RecipeNum).Ingredients(i).ItemNum)
            Buffer.WriteLong(Recipe(RecipeNum).Ingredients(i).Value)
        Next

        Buffer.WriteLong(Recipe(RecipeNum).CreateTime)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendCraftIt(ByVal RecipeName As String, ByVal Amount As Long)
        Dim Buffer As ByteBuffer, i As Long
        Dim recipeindex As Long

        Buffer = New ByteBuffer

        recipeindex = GetRecipeIndex(RecipeName)

        If recipeindex <= 0 Then Exit Sub

        'check,check, double check

        'we dont even know the damn recipe xD
        If Player(MyIndex).RecipeLearned(recipeindex) = 0 Then Exit Sub

        'enough ingredients?
        For i = 1 To MAX_INGREDIENT
            If Recipe(recipeindex).Ingredients(i).ItemNum > 0 Then
                If HasItem(MyIndex, Recipe(recipeindex).Ingredients(i).ItemNum) < (Amount * Recipe(recipeindex).Ingredients(i).Value) Then
                    AddText("Not Enough Materials!", Red)
                    Exit Sub
                End If
            End If
        Next

        'all seems fine...

        Buffer.WriteLong(ClientPackets.CStartCraft)

        Buffer.WriteLong(recipeindex)
        Buffer.WriteLong(Amount)

        SendData(Buffer.ToArray())

        Buffer = Nothing

        CraftTimer = GetTickCount()
        CraftTimerEnabled = True

        btnCraftEnabled = False
        btnCraftStopEnabled = False
        btnCraftStopEnabled = False
        nudCraftAmountEnabled = False
        lstRecipeEnabled = False
        chkKnownOnlyEnabled = False
    End Sub

    Sub SendCloseCraft()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteLong(ClientPackets.CCloseCraft)

        SendData(Buffer.ToArray())

        Buffer = Nothing
    End Sub
#End Region

#Region "Functions"
    Public Sub CraftingInit()
        Dim i As Long, x As Long

        x = 1

        For i = 1 To MAX_RECIPE
            If chkKnownOnlyChecked = True Then
                If Player(MyIndex).RecipeLearned(i) = 1 Then
                    RecipeNames(x) = Trim$(Recipe(i).Name)
                    x = x + 1
                End If
            Else
                If Len(Trim(Recipe(i).Name)) > 0 Then
                    RecipeNames(x) = Trim$(Recipe(i).Name)
                    x = x + 1
                End If
            End If
        Next

        CraftAmountValue = 1

        InCraft = True

        LoadRecipe(RecipeNames(SelectedRecipe))

        pnlCraftVisible = True
    End Sub

    Sub LoadRecipe(ByVal RecipeName As String)
        Dim recipeindex As Long

        recipeindex = GetRecipeIndex(RecipeName)

        If recipeindex <= 0 Then Exit Sub

        picProductIndex = Item(Recipe(recipeindex).MakeItemNum).Pic
        lblProductNameText = Item(Recipe(recipeindex).MakeItemNum).Name
        lblProductAmountText = "X 1"

        For i = 1 To MAX_INGREDIENT
            If Recipe(recipeindex).Ingredients(i).ItemNum > 0 Then
                picMaterialIndex(i) = Item(Recipe(recipeindex).Ingredients(i).ItemNum).Pic
                lblMaterialName(i) = Item(Recipe(recipeindex).Ingredients(i).ItemNum).Name
                lblMaterialAmount(i) = "X " & HasItem(MyIndex, Recipe(recipeindex).Ingredients(i).ItemNum) & "/" & Recipe(recipeindex).Ingredients(i).Value
            Else
                picMaterialIndex(i) = 0
                lblMaterialName(i) = ""
                lblMaterialAmount(i) = ""
            End If
        Next

    End Sub

    Function GetRecipeIndex(ByVal RecipeName As String) As Long
        Dim i As Long

        GetRecipeIndex = 0

        For i = 1 To MAX_RECIPE
            If Trim$(Recipe(i).Name) = Trim$(RecipeName) Then
                GetRecipeIndex = i
                Exit For
            End If
        Next

    End Function

    Public Sub DrawCraftPanel()
        Dim i As Long, y As Long
        Dim rec As Rectangle, pgbvalue As Long

        'first render panel
        RenderTexture(CraftGFX, GameWindow, CraftPanelX, CraftPanelY, 0, 0, CraftGFXInfo.width, CraftGFXInfo.height)

        y = 10

        'draw recipe names
        For i = 1 To MAX_RECIPE
            If Len(Trim$(RecipeNames(i))) > 0 Then
                DrawText(CraftPanelX + 12, CraftPanelY + y, Trim$(RecipeNames(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 20
            End If
        Next

        If SelectedRecipe = 0 Then Exit Sub

        If picProductIndex > 0 Then
            If ItemsGFXInfo(picProductIndex).IsLoaded = False Then
                LoadTexture(picProductIndex, 4)
            End If

            'seeying we still use it, lets update timer
            With ItemsGFXInfo(picProductIndex)
                .TextureTimer = GetTickCount() + 100000
            End With

            RenderTexture(ItemsGFX(picProductIndex), GameWindow, CraftPanelX + 267, CraftPanelY + 20, 0, 0, ItemsGFXInfo(picProductIndex).width, ItemsGFXInfo(picProductIndex).height)

            DrawText(CraftPanelX + 310, CraftPanelY + 20, Trim$(lblProductNameText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

            DrawText(CraftPanelX + 310, CraftPanelY + 35, Trim$(lblProductAmountText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
        End If

        y = 107

        For i = 1 To MAX_INGREDIENT
            If picMaterialIndex(i) > 0 Then
                If ItemsGFXInfo(picMaterialIndex(i)).IsLoaded = False Then
                    LoadTexture(picMaterialIndex(i), 4)
                End If

                'seeying we still use it, lets update timer
                With ItemsGFXInfo(picMaterialIndex(i))
                    .TextureTimer = GetTickCount() + 100000
                End With


                RenderTexture(ItemsGFX(picMaterialIndex(i)), GameWindow, CraftPanelX + 275, CraftPanelY + y, 0, 0, ItemsGFXInfo(picMaterialIndex(i)).width, ItemsGFXInfo(picMaterialIndex(i)).height)

                DrawText(CraftPanelX + 315, CraftPanelY + y, Trim$(lblMaterialName(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

                DrawText(CraftPanelX + 315, CraftPanelY + y + 15, Trim$(lblMaterialAmount(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

                y = y + 63
            End If
        Next

        'progress bar
        pgbvalue = (CraftProgressValue / 100) * 100

        With rec
            .Y = 0
            .Height = ProgBarGFXInfo.height
            .X = 0
            .Width = pgbvalue * ProgBarGFXInfo.width / 100
        End With

        RenderTexture(ProgBarGFX, GameWindow, CraftPanelX + 410, CraftPanelY + 417, rec.X, rec.Y, rec.Width, rec.Height)

        'amount controls
        RenderTexture(CharPanelMinGFX, GameWindow, CraftPanelX + 340, CraftPanelY + 422, 0, 0, CharPanelMinGFXInfo.width, CharPanelMinGFXInfo.height)

        DrawText(CraftPanelX + 367, CraftPanelY + 418, Trim$(CraftAmountValue), SFML.Graphics.Color.Black, SFML.Graphics.Color.White, GameWindow)

        RenderTexture(CharPanelPlusGFX, GameWindow, CraftPanelX + 392, CraftPanelY + 422, 0, 0, CharPanelPlusGFXInfo.width, CharPanelPlusGFXInfo.height)
    End Sub

    Public Sub ResetCraftPanel()
        'reset the panel's info
        ReDim RecipeNames(MAX_RECIPE)

        For i = 1 To MAX_RECIPE
            RecipeNames(i) = ""
        Next

        CraftProgressValue = 0

        CraftAmountValue = 1

        picProductIndex = 0
        lblProductNameText = "None Selected"
        lblProductAmountText = "0"

        For i = 1 To MAX_INGREDIENT
            picMaterialIndex(i) = 0
            lblMaterialName(i) = ""
            lblMaterialAmount(i) = ""
        Next

        CraftTimerEnabled = False

        btnCraftEnabled = True
        btnCraftStopEnabled = True
        nudCraftAmountEnabled = True
        lstRecipeEnabled = True
        chkKnownOnlyEnabled = True

        SelectedRecipe = 0
    End Sub

#End Region

End Module
