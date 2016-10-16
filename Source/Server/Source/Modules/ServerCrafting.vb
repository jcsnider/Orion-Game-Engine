Public Module ServerCrafting
#Region "Globals"
    Public Recipe(MAX_RECIPE) As RecipeRec

    Public Const RecipeType_Herb As Byte = 0
    Public Const RecipeType_Wood As Byte = 1
    Public Const RecipeType_Metal As Byte = 2

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
    Sub CheckRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            If Not FileExist(Application.StartupPath & "\Data\recipes\recipe" & i & ".dat") Then
                SaveRecipe(i)
                DoEvents()
            End If
        Next

    End Sub

    Sub SaveRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            SaveRecipe(i)
            DoEvents()
        Next

    End Sub

    Sub SaveRecipe(ByVal RecipeNum As Integer)
        Dim filename As String
        Dim i As Integer

        filename = Application.StartupPath & "\Data\recipes\recipe" & RecipeNum & ".dat"

        Dim writer As New ArchaicSoftWriter()

        writer.Write(Recipe(RecipeNum).Name)
        writer.Write(Recipe(RecipeNum).RecipeType)
        writer.Write(Recipe(RecipeNum).MakeItemNum)
        writer.Write(Recipe(RecipeNum).MakeItemAmount)

        For i = 1 To MAX_INGREDIENT
            writer.Write(Recipe(RecipeNum).Ingredients(i).ItemNum)
            writer.Write(Recipe(RecipeNum).Ingredients(i).Value)
        Next

        writer.Write(Recipe(RecipeNum).CreateTime)

        writer.Save(filename)
    End Sub

    Sub LoadRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            LoadRecipe(i)
            DoEvents()
        Next

    End Sub

    Sub LoadRecipe(ByVal RecipeNum As Integer)
        Dim filename As String
        Dim i As Integer

        CheckRecipes()

        filename = Application.StartupPath & "\Data\recipes\recipe" & RecipeNum & ".dat"
        Dim reader As New ArchaicSoftReader(filename)

        reader.Read(Recipe(RecipeNum).Name)
        reader.Read(Recipe(RecipeNum).RecipeType)
        reader.Read(Recipe(RecipeNum).MakeItemNum)
        reader.Read(Recipe(RecipeNum).MakeItemAmount)

        ReDim Recipe(RecipeNum).Ingredients(MAX_INGREDIENT)
        For i = 1 To MAX_INGREDIENT
            reader.Read(Recipe(RecipeNum).Ingredients(i).ItemNum)
            reader.Read(Recipe(RecipeNum).Ingredients(i).Value)
        Next

        reader.Read(Recipe(RecipeNum).CreateTime)

    End Sub

    Sub ClearRecipes()
        Dim i As Integer

        For i = 1 To MAX_RECIPE
            ClearRecipe(i)
            DoEvents()
        Next

    End Sub

    Sub ClearRecipe(ByVal Num As Integer)
        Recipe(Num).Name = ""
        Recipe(Num).RecipeType = 0
        Recipe(Num).MakeItemNum = 0
        Recipe(Num).MakeItemAmount = 0
        Recipe(Num).CreateTime = 0
        ReDim Recipe(Num).Ingredients(MAX_INGREDIENT)
    End Sub

#End Region

#Region "Incoming Packets"
    Sub Packet_RequestRecipes(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)


        If Buffer.ReadInteger <> ClientPackets.CRequestRecipes Then Exit Sub

        SendRecipes(Index)

        Buffer = Nothing

    End Sub

    Sub Packet_RequestEditRecipes(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.DEVELOPER Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SRecipeEditor)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub Packet_SaveRecipe(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, n As Integer
        Buffer = New ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < AdminType.DEVELOPER Then Exit Sub

        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CSaveRecipe Then Exit Sub

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

        'save
        SaveRecipe(n)

        'send to all
        SendUpdateRecipeToAll(n)

        Buffer = Nothing

    End Sub

    Sub Packet_CloseCraft(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CCloseCraft Then Exit Sub

        TempPlayer(Index).IsCrafting = False

        Buffer = Nothing

    End Sub

    Sub Packet_StartCraft(ByVal Index As Integer, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim recipeindex As Integer, amount As Integer

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadInteger <> ClientPackets.CStartCraft Then Exit Sub

        recipeindex = Buffer.ReadInteger
        amount = Buffer.ReadInteger

        If TempPlayer(Index).IsCrafting = False Then Exit Sub

        If recipeindex = 0 Or amount = 0 Then Exit Sub

        If Not CheckLearnedRecipe(Index, recipeindex) Then Exit Sub

        StartCraft(Index, recipeindex, amount)

        Buffer = Nothing

    End Sub

#End Region

#Region "Outgoing Packets"
    Sub SendRecipes(ByVal Index As Integer)
        Dim i As Integer

        For i = 1 To MAX_RECIPE

            If Len(Trim$(Recipe(i).Name)) > 0 Then
                SendUpdateRecipeTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateRecipeTo(ByVal Index As Integer, ByVal RecipeNum As Integer)
        Dim Buffer As ByteBuffer, i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateRecipe)
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

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendUpdateRecipeToAll(ByVal RecipeNum As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateRecipe)
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

        SendDataToAll(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerRecipes(ByVal Index As Integer)
        Dim i As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SSendPlayerRecipe)

        For i = 1 To MAX_RECIPE
            Buffer.WriteInteger(Player(Index).Character(TempPlayer(Index).CurChar).RecipeLearned(i))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendOpenCraft(ByVal Index As Integer)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SOpenCraft)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendCraftUpdate(ByVal Index As Integer, ByVal done As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(ServerPackets.SUpdateCraft)

        Buffer.WriteInteger(done)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
#End Region

#Region "Functions"

    Public Function CheckLearnedRecipe(ByVal Index As Integer, ByVal RecipeNum As Integer) As Boolean
        CheckLearnedRecipe = False

        If Player(Index).Character(TempPlayer(Index).CurChar).RecipeLearned(RecipeNum) = 1 Then
            CheckLearnedRecipe = True
        End If
    End Function

    Public Sub LearnRecipe(ByVal Index As Integer, ByVal RecipeNum As Integer, ByVal InvNum As Integer)
        If CheckLearnedRecipe(Index, RecipeNum) Then ' we know this one allready
            PlayerMsg(Index, "You allready know this recipe!")
        Else ' lets learn it
            Player(Index).Character(TempPlayer(Index).CurChar).RecipeLearned(RecipeNum) = 1

            PlayerMsg(Index, "You learned the " & Recipe(RecipeNum).Name & " recipe!")

            TakeInvItem(Index, GetPlayerInvItemNum(Index, InvNum), 0)

            SavePlayer(Index)
            SendPlayerData(Index)
        End If
    End Sub

    Public Sub StartCraft(ByVal Index As Integer, ByVal RecipeNum As Integer, ByVal Amount As Integer)

        If TempPlayer?(Index).IsCrafting Then
            TempPlayer(Index).CraftRecipe = RecipeNum
            TempPlayer(Index).CraftAmount = Amount

            TempPlayer(Index).CraftTimer = GetTickCount()
            TempPlayer(Index).CraftTimeNeeded = Recipe(RecipeNum).CreateTime

            TempPlayer(Index).CraftIt = 1
        End If

    End Sub

    Public Sub UpdateCraft(ByVal Index As Integer)
        Dim i As Integer

        'ok, we made the item, give and take the shit
        If GiveInvItem(Index, Recipe(TempPlayer(Index).CraftRecipe).MakeItemNum, Recipe(TempPlayer(Index).CraftRecipe).MakeItemAmount, True) Then
            For i = 1 To MAX_INGREDIENT
                TakeInvItem(Index, Recipe(TempPlayer(Index).CraftRecipe).Ingredients(i).ItemNum, Recipe(TempPlayer(Index).CraftRecipe).Ingredients(i).Value)
            Next
            PlayerMsg(Index, "You created " & Trim(Item(Recipe(TempPlayer(Index).CraftRecipe).MakeItemNum).Name) & " X " & Recipe(TempPlayer(Index).CraftRecipe).MakeItemAmount)
        End If

        If TempPlayer?(Index).IsCrafting Then
            TempPlayer(Index).CraftAmount = TempPlayer(Index).CraftAmount - 1

            If TempPlayer(Index).CraftAmount > 0 Then
                TempPlayer(Index).CraftTimer = GetTickCount()
                TempPlayer(Index).CraftTimeNeeded = Recipe(TempPlayer(Index).CraftRecipe).CreateTime

                TempPlayer(Index).CraftIt = 1

                SendCraftUpdate(Index, 0)
            End If

            SendCraftUpdate(Index, 1)
        End If

    End Sub

#End Region
End Module
