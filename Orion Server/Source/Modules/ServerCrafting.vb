Public Module ServerCrafting
#Region "Globals"
    'Public Const ItemType.RECIPES As Byte = 17
    'Public Const TILE_TYPE_CRAFT As Byte = 15
    'Public Const MAX_RECIPE As Long = 100
    Public Const MAX_INGREDIENT As Byte = 5
    Public Recipe(MAX_RECIPE) As RecipeRec

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
    Sub CheckRecipes()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            If Not FileExist(Application.StartupPath & "\Data\recipes\recipe" & i & ".dat") Then
                SaveRecipe(i)
                DoEvents()
            End If
        Next

    End Sub

    Sub SaveRecipes()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            SaveRecipe(i)
            DoEvents()
        Next

    End Sub

    Sub SaveRecipe(ByVal RecipeNum As Long)
        Dim filename As String
        Dim F As Long, i As Long

        filename = Application.StartupPath & "\Data\recipes\recipe" & RecipeNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Recipe(RecipeNum).Name)
        FilePutObject(F, Recipe(RecipeNum).RecipeType)
        FilePutObject(F, Recipe(RecipeNum).MakeItemNum)
        FilePutObject(F, Recipe(RecipeNum).MakeItemAmount)

        For i = 1 To MAX_INGREDIENT
            FilePutObject(F, Recipe(RecipeNum).Ingredients(i).ItemNum)
            FilePutObject(F, Recipe(RecipeNum).Ingredients(i).Value)
        Next

        FilePutObject(F, Recipe(RecipeNum).CreateTime)

        FileClose(F)
    End Sub

    Sub LoadRecipes()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            LoadRecipe(i)
            DoEvents()
        Next

    End Sub

    Sub LoadRecipe(ByVal RecipeNum As Long)
        Dim filename As String
        Dim F As Long, i As Long

        CheckRecipes()

        filename = Application.StartupPath & "\Data\recipes\recipe" & RecipeNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Recipe(RecipeNum).Name)
        FileGetObject(F, Recipe(RecipeNum).RecipeType)
        FileGetObject(F, Recipe(RecipeNum).MakeItemNum)
        FileGetObject(F, Recipe(RecipeNum).MakeItemAmount)

        ReDim Recipe(RecipeNum).Ingredients(MAX_INGREDIENT)
        For i = 1 To MAX_INGREDIENT
            FileGetObject(F, Recipe(RecipeNum).Ingredients(i).ItemNum)
            FileGetObject(F, Recipe(RecipeNum).Ingredients(i).Value)
        Next

        FileGetObject(F, Recipe(RecipeNum).CreateTime)

        FileClose(F)
    End Sub

    Sub ClearRecipes()
        Dim i As Long

        For i = 1 To MAX_RECIPE
            ClearRecipe(i)
            DoEvents()
        Next

    End Sub

    Sub ClearRecipe(ByVal Num As Long)
        Recipe(Num).Name = ""
        Recipe(Num).RecipeType = 0
        Recipe(Num).MakeItemNum = 0
        Recipe(Num).MakeItemAmount = 0
        Recipe(Num).CreateTime = 0
        ReDim Recipe(Num).Ingredients(MAX_INGREDIENT)
    End Sub

#End Region

#Region "Incoming Packets"
    Sub Packet_RequestRecipes(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)


        If Buffer.ReadLong <> ClientPackets.CRequestRecipes Then Exit Sub

        SendRecipes(Index)

        Buffer = Nothing

    End Sub

    Sub Packet_RequestEditRecipes(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_DEVELOPER Then Exit Sub

        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SRecipeEditor)
        SendDataTo(Index, Buffer.ToArray())
        Buffer = Nothing

    End Sub

    Sub Packet_SaveRecipe(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer, n As Long
        Buffer = New ByteBuffer

        ' Prevent hacking
        If GetPlayerAccess(Index) < ADMIN_DEVELOPER Then Exit Sub

        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CSaveRecipe Then Exit Sub

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

        'save
        SaveRecipe(n)

        'send to all
        SendUpdateRecipeToAll(n)

        Buffer = Nothing

    End Sub

    Sub Packet_CloseCraft(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CCloseCraft Then Exit Sub

        TempPlayer(Index).IsCrafting = False

        Buffer = Nothing

    End Sub

    Sub Packet_StartCraft(ByVal Index As Long, ByVal data() As Byte)
        Dim Buffer As ByteBuffer
        Dim recipeindex As Long, amount As Long

        Buffer = New ByteBuffer
        Buffer.WriteBytes(data)

        If Buffer.ReadLong <> ClientPackets.CStartCraft Then Exit Sub

        recipeindex = Buffer.ReadLong
        amount = Buffer.ReadLong

        If TempPlayer(Index).IsCrafting = False Then Exit Sub

        If recipeindex = 0 Or amount = 0 Then Exit Sub

        If Not CheckLearnedRecipe(Index, recipeindex) Then Exit Sub

        StartCraft(Index, recipeindex, amount)

        Buffer = Nothing

    End Sub

#End Region

#Region "Outgoing Packets"
    Sub SendRecipes(ByVal Index As Long)
        Dim i As Long

        For i = 1 To MAX_RECIPE

            If Len(Trim$(Recipe(i).Name)) > 0 Then
                SendUpdateRecipeTo(Index, i)
            End If

        Next

    End Sub

    Sub SendUpdateRecipeTo(ByVal Index As Long, ByVal RecipeNum As Long)
        Dim Buffer As ByteBuffer, i As Long
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateRecipe)
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

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendUpdateRecipeToAll(ByVal RecipeNum As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateRecipe)
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

        SendDataToAll(Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendPlayerRecipes(ByVal Index As Long)
        Dim i As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SSendPlayerRecipe)

        For i = 1 To MAX_RECIPE
            Buffer.WriteLong(Player(Index).Character(TempPlayer(Index).CurChar).RecipeLearned(i))
        Next

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendOpenCraft(ByVal Index As Long)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SOpenCraft)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub

    Sub SendCraftUpdate(ByVal Index As Long, ByVal done As Byte)
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(ServerPackets.SUpdateCraft)

        Buffer.WriteLong(done)

        SendDataTo(Index, Buffer.ToArray())

        Buffer = Nothing
    End Sub
#End Region

#Region "Functions"

    Public Function CheckLearnedRecipe(ByVal Index As Long, ByVal RecipeNum As Long) As Boolean
        CheckLearnedRecipe = False

        If Player(Index).Character(TempPlayer(Index).CurChar).RecipeLearned(RecipeNum) = 1 Then
            CheckLearnedRecipe = True
        End If
    End Function

    Public Sub LearnRecipe(ByVal Index As Long, ByVal RecipeNum As Long, ByVal InvNum As Long)
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

    Public Sub StartCraft(ByVal Index As Long, ByVal RecipeNum As Long, ByVal Amount As Long)

        If TempPlayer?(Index).IsCrafting Then
            TempPlayer(Index).CraftRecipe = RecipeNum
            TempPlayer(Index).CraftAmount = Amount

            TempPlayer(Index).CraftTimer = GetTickCount()
            TempPlayer(Index).CraftTimeNeeded = Recipe(RecipeNum).CreateTime

            TempPlayer(Index).CraftIt = 1
        End If

    End Sub

    Public Sub UpdateCraft(ByVal Index As Long)
        Dim i As Long

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
