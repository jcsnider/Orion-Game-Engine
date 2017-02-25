﻿Imports System.Drawing

Public Module ClientCrafting
#Region "Globals"

    Public Recipe_Changed(MAX_RECIPE) As Boolean
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

        ReDim Recipe(MAX_RECIPE)

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

        ReDim Recipe_Changed(MAX_RECIPE)
    End Sub
#End Region

#Region "Incoming Packets"
    Sub Packet_UpdateRecipe(ByVal data() As Byte)
        Dim n As Integer, i As Integer
        Dim Buffer As New ByteBuffer

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
        Dim Buffer As New ByteBuffer

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SRecipeEditor Then Exit Sub

        InitRecipeEditor = True

        Buffer = Nothing
    End Sub

    Sub Packet_SendPlayerRecipe(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer, i As Integer

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SSendPlayerRecipe Then Exit Sub

        For i = 1 To MAX_RECIPE
            Player(MyIndex).RecipeLearned(i) = Buffer.ReadInteger
        Next

        Buffer = Nothing
    End Sub

    Sub Packet_OpenCraft(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SOpenCraft Then Exit Sub

        InitCrafting = True

        Buffer = Nothing
    End Sub

    Sub Packet_UpdateCraft(ByVal data() As Byte)
        Dim Buffer As New ByteBuffer, done As Byte

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ServerPackets.SUpdateCraft Then Exit Sub

        done = Buffer.ReadInteger

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
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CRequestRecipes)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendRequestEditRecipes()
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(EditorPackets.RequestEditRecipes)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub SendSaveRecipe(ByVal RecipeNum As Integer)
        Dim Buffer As New ByteBuffer

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

    Public Sub SendCraftIt(ByVal RecipeName As String, ByVal Amount As Integer)
        Dim Buffer As New ByteBuffer, i As Integer
        Dim recipeindex As Integer

        recipeindex = GetRecipeIndex(RecipeName)

        If recipeindex <= 0 Then Exit Sub

        'check,check, double check

        'we dont even know the damn recipe xD
        If Player(MyIndex).RecipeLearned(recipeindex) = 0 Then Exit Sub

        'enough ingredients?
        For i = 1 To MAX_INGREDIENT
            If Recipe(recipeindex).Ingredients(i).ItemNum > 0 AndAlso HasItem(MyIndex, Recipe(recipeindex).Ingredients(i).ItemNum) < (Amount * Recipe(recipeindex).Ingredients(i).Value) Then
                AddText(Strings.Get("crafting", "notenough"), ColorType.Red)
                Exit Sub
            End If
        Next

        'all seems fine...

        Buffer.WriteInteger(ClientPackets.CStartCraft)

        Buffer.WriteInteger(recipeindex)
        Buffer.WriteInteger(Amount)

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
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CCloseCraft)

        SendData(Buffer.ToArray())

        Buffer = Nothing
    End Sub
#End Region

#Region "Functions"
    Public Sub CraftingInit()
        Dim i As Integer, x As Integer

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
        Dim recipeindex As Integer

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

    Public Sub DrawCraftPanel()
        Dim i As Integer, y As Integer
        Dim rec As Rectangle, pgbvalue As Integer

        'first render panel
        RenderSprite(CraftSprite, GameWindow, CraftPanelX, CraftPanelY, 0, 0, CraftGFXInfo.Width, CraftGFXInfo.Height)

        y = 10

        'draw recipe names
        For i = 1 To MAX_RECIPE
            If Len(Trim$(RecipeNames(i))) > 0 Then
                DrawText(CraftPanelX + 12, CraftPanelY + y, Trim$(RecipeNames(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
                y = y + 20
            End If
        Next

        'progress bar
        pgbvalue = (CraftProgressValue / 100) * 100

        With rec
            .Y = 0
            .Height = ProgBarGFXInfo.Height
            .X = 0
            .Width = pgbvalue * ProgBarGFXInfo.Width / 100
        End With

        RenderSprite(ProgBarSprite, GameWindow, CraftPanelX + 410, CraftPanelY + 417, rec.X, rec.Y, rec.Width, rec.Height)

        'amount controls
        RenderSprite(CharPanelMinSprite, GameWindow, CraftPanelX + 340, CraftPanelY + 422, 0, 0, CharPanelMinGFXInfo.Width, CharPanelMinGFXInfo.Height)

        DrawText(CraftPanelX + 367, CraftPanelY + 418, Trim$(CraftAmountValue), SFML.Graphics.Color.Black, SFML.Graphics.Color.White, GameWindow)

        RenderSprite(CharPanelPlusSprite, GameWindow, CraftPanelX + 392, CraftPanelY + 422, 0, 0, CharPanelPlusGFXInfo.Width, CharPanelPlusGFXInfo.Height)

        If SelectedRecipe = 0 Then Exit Sub

        If picProductIndex > 0 Then
            If ItemsGFXInfo(picProductIndex).IsLoaded = False Then
                LoadTexture(picProductIndex, 4)
            End If

            'seeying we still use it, lets update timer
            With ItemsGFXInfo(picProductIndex)
                .TextureTimer = GetTickCount() + 100000
            End With

            RenderSprite(ItemsSprite(picProductIndex), GameWindow, CraftPanelX + 267, CraftPanelY + 20, 0, 0, ItemsGFXInfo(picProductIndex).Width, ItemsGFXInfo(picProductIndex).Height)

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

                RenderSprite(ItemsSprite(picMaterialIndex(i)), GameWindow, CraftPanelX + 275, CraftPanelY + y, 0, 0, ItemsGFXInfo(picMaterialIndex(i)).Width, ItemsGFXInfo(picMaterialIndex(i)).Height)

                DrawText(CraftPanelX + 315, CraftPanelY + y, Trim$(lblMaterialName(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

                DrawText(CraftPanelX + 315, CraftPanelY + y + 15, Trim$(lblMaterialAmount(i)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)

                y = y + 63
            End If
        Next

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
        lblProductNameText = Strings.Get("crafting", "noneselected")
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