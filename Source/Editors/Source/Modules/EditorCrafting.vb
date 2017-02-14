
Public Module EditorCrafting
#Region "Globals"

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
    Public CraftProgressValue As Integer
    Public picProductIndex As Integer
    Public lblProductNameText As String
    Public lblProductAmountText As String

    Public picMaterialIndex(MAX_INGREDIENT) As Integer
    Public lblMaterialName(MAX_INGREDIENT) As String
    Public lblMaterialAmount(MAX_INGREDIENT) As String

    Public SelectedRecipe As Integer = 0

    Public Structure RecipeRec
        Dim Name As String
        Dim RecipeType As Byte
        Dim MakeItemNum As Integer
        Dim MakeItemAmount As Integer
        Dim Ingredients() As IngredientsRec
        Dim CreateTime As Byte
    End Structure

    Public Structure IngredientsRec
        Dim ItemNum As Integer
        Dim Value As Integer
    End Structure

#End Region

#Region "Database"
    Sub ClearRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            ClearRecipe(i)
        Next

    End Sub

    Sub ClearRecipe(ByVal Num As Integer)
        Recipe(Num).Name = ""
        Recipe(Num).RecipeType = 0
        Recipe(Num).MakeItemNum = 0
        ReDim Recipe(Num).Ingredients(MAX_INGREDIENT)
    End Sub

    Public Sub ClearChanged_Recipe()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            Recipe_Changed(i) = Nothing
        Next

        ReDim Recipe_Changed(0 To MAX_RECIPE)
    End Sub
#End Region

#Region "Editor"
    Public Sub RecipeEditorPreInit()
        Dim i As Integer

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
        Dim i As Integer

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
        Dim i As Integer
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

        frmEditor_Recipe.lstIngredients.SelectedIndex = 0
    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_UpdateRecipe(ByVal data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateRecipe Then Exit Sub

        'recipe index
        n = Buffer.ReadInteger

        ' Update the Recipe
        Recipe(n).Name = Trim$(Buffer.ReadString)
        Recipe(n).RecipeType = Buffer.ReadInteger
        Recipe(n).MakeItemNum = Buffer.ReadInteger
        Recipe(n).MakeItemAmount = Buffer.ReadInteger

        For i = 1 To MAX_INGREDIENT
            Recipe(n).Ingredients(i).ItemNum = Buffer.ReadInteger()
            Recipe(n).Ingredients(i).Value = Buffer.ReadInteger()
        Next

        Recipe(n).CreateTime = Buffer.ReadInteger

        Buffer = Nothing

    End Sub

    Sub Packet_RecipeEditor(ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SRecipeEditor Then Exit Sub

        InitRecipeEditor = True

        Buffer = Nothing
    End Sub

#End Region

#Region "OutGoing Packets"
    Sub SendRequestRecipes()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CRequestRecipes)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestEditRecipes()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(EditorPackets.RequestEditRecipes)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSaveRecipe(ByVal RecipeNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer

        Buffer.WriteInteger(EditorPackets.SaveRecipe)

        Buffer.WriteInteger(RecipeNum)

        Buffer.WriteString(Trim$(Recipe(RecipeNum).Name))
        Buffer.WriteInteger(Recipe(RecipeNum).RecipeType)
        Buffer.WriteInteger(Recipe(RecipeNum).MakeItemNum)
        Buffer.WriteInteger(Recipe(RecipeNum).MakeItemAmount)

        For i = 1 To MAX_INGREDIENT
            Buffer.WriteInteger(Recipe(RecipeNum).Ingredients(i).ItemNum)
            Buffer.WriteInteger(Recipe(RecipeNum).Ingredients(i).Value)
        Next

        Buffer.WriteInteger(Recipe(RecipeNum).CreateTime)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

#End Region

#Region "Functions"

    Function GetRecipeIndex(ByVal RecipeName As String) As Integer
        Dim i As Integer

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
