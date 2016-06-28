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

    Public Const RecipeType_Herb As Byte = 0
    Public Const RecipeType_Wood As Byte = 1
    Public Const RecipeType_Metal As Byte = 2

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

            frmMainGame.pgbCraftProgress.Value = 0
            frmMainGame.tmrCraft.Enabled = True
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
                If HasItem(MyIndex, Recipe(recipeindex).Ingredients(i).ItemNum) < (Amount * Recipe(recipeindex).Ingredients(i).Value) Then Exit Sub
            End If
        Next

        'all seems fine...

        Buffer.WriteLong(ClientPackets.CStartCraft)

        Buffer.WriteLong(recipeindex)
        Buffer.WriteLong(Amount)

        SendData(Buffer.ToArray())

        Buffer = Nothing
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
        Dim i As Long

        frmMainGame.lstRecipe.Items.Clear()

        For i = 1 To MAX_RECIPE
            If frmMainGame.chkKnownOnly.Checked = True Then
                If Player(MyIndex).RecipeLearned(i) = 1 Then
                    frmMainGame.lstRecipe.Items.Add(Trim(Recipe(i).Name))
                End If
            Else
                If Len(Trim(Recipe(i).Name)) > 0 Then
                    frmMainGame.lstRecipe.Items.Add(Trim(Recipe(i).Name))
                End If
            End If

        Next

        'reset the panel's info
        frmMainGame.pgbCraftProgress.Value = 0

        frmMainGame.picProduct.BackgroundImage = Nothing
        frmMainGame.lblProductName.Text = "None Selected"
        frmMainGame.lblProductAmount.Text = "0"

        frmMainGame.picMaterial1.BackgroundImage = Nothing
        frmMainGame.lblMaterialName1.Text = "Empty Slot"
        frmMainGame.lblMaterialAmount1.Text = "0"

        frmMainGame.picMaterial2.BackgroundImage = Nothing
        frmMainGame.lblMaterialName2.Text = "Empty Slot"
        frmMainGame.lblMaterialAmount2.Text = "0"

        frmMainGame.picMaterial3.BackgroundImage = Nothing
        frmMainGame.lblMaterialName3.Text = "Empty Slot"
        frmMainGame.lblMaterialAmount3.Text = "0"

        frmMainGame.picMaterial4.BackgroundImage = Nothing
        frmMainGame.lblMaterialName4.Text = "Empty Slot"
        frmMainGame.lblMaterialAmount4.Text = "0"

        frmMainGame.picMaterial5.BackgroundImage = Nothing
        frmMainGame.lblMaterialName5.Text = "Empty Slot"
        frmMainGame.lblMaterialAmount5.Text = "0"

        InCraft = True

        frmMainGame.tmrCraft.Enabled = False

        frmMainGame.btnCraft.Enabled = True
        frmMainGame.btnCraftStop.Enabled = True
        frmMainGame.btnCraftStop.Enabled = True
        frmMainGame.nudCraftAmount.Enabled = True
        frmMainGame.lstRecipe.Enabled = True
        frmMainGame.chkKnownOnly.Enabled = True

        frmMainGame.pnlCraft.Visible = True
    End Sub

    Sub LoadRecipe(ByVal RecipeName As String)
        Dim recipeindex As Long

        recipeindex = GetRecipeIndex(RecipeName)

        If recipeindex <= 0 Then Exit Sub

        frmMainGame.picProduct.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & Item(Recipe(recipeindex).MakeItemNum).Pic & GFX_EXT)
        frmMainGame.lblProductName.Text = Item(Recipe(recipeindex).MakeItemNum).Name
        frmMainGame.lblProductAmount.Text = "X 1"

        If Recipe(recipeindex).Ingredients(1).ItemNum > 0 Then
            frmMainGame.picMaterial1.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & Item(Recipe(recipeindex).Ingredients(1).ItemNum).Pic & GFX_EXT)
            frmMainGame.lblMaterialName1.Text = Item(Recipe(recipeindex).Ingredients(1).ItemNum).Name
            frmMainGame.lblMaterialAmount1.Text = "X " & Recipe(recipeindex).Ingredients(1).Value & "/" & HasItem(MyIndex, Recipe(recipeindex).Ingredients(1).ItemNum)
        Else
            frmMainGame.picMaterial1.BackgroundImage = Nothing
        End If

        If Recipe(recipeindex).Ingredients(2).ItemNum > 0 Then
            frmMainGame.picMaterial2.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & Item(Recipe(recipeindex).Ingredients(2).ItemNum).Pic & GFX_EXT)
            frmMainGame.lblMaterialName2.Text = Item(Recipe(recipeindex).Ingredients(2).ItemNum).Name
            frmMainGame.lblMaterialAmount2.Text = "X " & Recipe(recipeindex).Ingredients(2).Value & "/" & HasItem(MyIndex, Recipe(recipeindex).Ingredients(2).ItemNum)
        Else
            frmMainGame.picMaterial2.BackgroundImage = Nothing
        End If

        If Recipe(recipeindex).Ingredients(3).ItemNum > 0 Then
            frmMainGame.picMaterial3.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & Item(Recipe(recipeindex).Ingredients(3).ItemNum).Pic & GFX_EXT)
            frmMainGame.lblMaterialName3.Text = Item(Recipe(recipeindex).Ingredients(3).ItemNum).Name
            frmMainGame.lblMaterialAmount3.Text = "X " & Recipe(recipeindex).Ingredients(3).Value & "/" & HasItem(MyIndex, Recipe(recipeindex).Ingredients(3).ItemNum)
        Else
            frmMainGame.picMaterial3.BackgroundImage = Nothing
        End If

        If Recipe(recipeindex).Ingredients(4).ItemNum > 0 Then
            frmMainGame.picMaterial4.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & Item(Recipe(recipeindex).Ingredients(4).ItemNum).Pic & GFX_EXT)
            frmMainGame.lblMaterialName4.Text = Item(Recipe(recipeindex).Ingredients(4).ItemNum).Name
            frmMainGame.lblMaterialAmount4.Text = "X " & Recipe(recipeindex).Ingredients(4).Value & "/" & HasItem(MyIndex, Recipe(recipeindex).Ingredients(4).ItemNum)
        Else
            frmMainGame.picMaterial4.BackgroundImage = Nothing
        End If

        If Recipe(recipeindex).Ingredients(5).ItemNum > 0 Then
            frmMainGame.picMaterial5.BackgroundImage = Image.FromFile(Application.StartupPath & GFX_PATH & "items\" & Item(Recipe(recipeindex).Ingredients(5).ItemNum).Pic & GFX_EXT)
            frmMainGame.lblMaterialName5.Text = Item(Recipe(recipeindex).Ingredients(5).ItemNum).Name
            frmMainGame.lblMaterialAmount5.Text = "X " & Recipe(recipeindex).Ingredients(5).Value & "/" & HasItem(MyIndex, Recipe(recipeindex).Ingredients(5).ItemNum)
        Else
            frmMainGame.picMaterial5.BackgroundImage = Nothing
        End If

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

#End Region

End Module
