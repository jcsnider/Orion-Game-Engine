Imports System.IO
Imports System.IO.Compression
Imports System.Linq

Module ServerDatabase

#Region "Classes"
    Public Sub CreateClassesIni()
        Dim filename As String
        filename = Application.StartupPath & "\data\classes.ini"
        Max_Classes = 1

        If Not FileExist(filename) Then
            PutVar(filename, "INIT", "MaxClasses", Max_Classes)
            PutVar(filename, "CLASS1", "Name", "Warrior")
            PutVar(filename, "CLASS1", "Desc", "Warrior Description")
            PutVar(filename, "CLASS1", "Malesprite", "1")
            PutVar(filename, "CLASS1", "Femalesprite", "2")
            PutVar(filename, "CLASS1", "Str", "5")
            PutVar(filename, "CLASS1", "End", "5")
            PutVar(filename, "CLASS1", "Vit", "5")
            PutVar(filename, "CLASS1", "Luck", "5")
            PutVar(filename, "CLASS1", "Int", "5")
            PutVar(filename, "CLASS1", "Spir", "5")
            PutVar(filename, "CLASS1", "BaseExp", "25")

            PutVar(filename, "CLASS1", "StartMap", START_MAP)
            PutVar(filename, "CLASS1", "StartX", START_X)
            PutVar(filename, "CLASS1", "StartY", START_Y)
        End If
    End Sub

    Sub ClearClasses()
        Dim i As Long

        For i = 1 To Max_Classes
            Classes(i) = Nothing
            Classes(i).Name = vbNullString
            Classes(i).Desc = vbNullString
        Next

        ReDim Classes(0 To Max_Classes)
        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

    End Sub

    Sub LoadClasses()
        Dim filename As String
        Dim i As Long, n As Long
        Dim tmpSprite As String
        Dim tmpArray() As String
        Dim x As Long

        filename = Application.StartupPath & "\data\classes.ini"

        If Not FileExist(filename) Then CreateClassesIni()

        Max_Classes = Val(Getvar(filename, "INIT", "MaxClasses"))
        ReDim Classes(0 To Max_Classes)
        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

        ClearClasses()

        For i = 1 To Max_Classes
            Classes(i).Name = Getvar(filename, "CLASS" & i, "Name")
            Classes(i).Desc = Getvar(filename, "CLASS" & i, "Desc")

            ' read string of sprites
            tmpSprite = Getvar(filename, "CLASS" & i, "MaleSprite")
            ' split into an array of strings
            tmpArray = Split(tmpSprite, ",")
            ' redim the class sprite array
            ReDim Classes(i).MaleSprite(0 To UBound(tmpArray))
            ' loop through converting strings to values and store in the sprite array
            For n = 0 To UBound(tmpArray)
                Classes(i).MaleSprite(n) = Val(tmpArray(n))
            Next

            ' read string of sprites
            tmpSprite = Getvar(filename, "CLASS" & i, "FemaleSprite")
            ' split into an array of strings
            tmpArray = Split(tmpSprite, ",")
            ' redim the class sprite array
            ReDim Classes(i).FemaleSprite(0 To UBound(tmpArray))
            ' loop through converting strings to values and store in the sprite array
            For n = 0 To UBound(tmpArray)
                Classes(i).FemaleSprite(n) = Val(tmpArray(n))
            Next

            ' continue
            Classes(i).Stat(Stats.strength) = Val(Getvar(filename, "CLASS" & i, "Str"))
            Classes(i).Stat(Stats.endurance) = Val(Getvar(filename, "CLASS" & i, "End"))
            Classes(i).Stat(Stats.vitality) = Val(Getvar(filename, "CLASS" & i, "Vit"))
            Classes(i).Stat(Stats.luck) = Val(Getvar(filename, "CLASS" & i, "Luck"))
            Classes(i).Stat(Stats.intelligence) = Val(Getvar(filename, "CLASS" & i, "Int"))
            Classes(i).Stat(Stats.spirit) = Val(Getvar(filename, "CLASS" & i, "Spir"))

            ' loop for items & values
            For x = 1 To 5
                Classes(i).StartItem(x) = Val(Getvar(filename, "CLASS" & i, "StartItem" & x))
                Classes(i).StartValue(x) = Val(Getvar(filename, "CLASS" & i, "StartValue" & x))
            Next

            Classes(i).StartMap = Val(Getvar(filename, "CLASS" & i, "StartMap"))
            Classes(i).StartX = Val(Getvar(filename, "CLASS" & i, "StartX"))
            Classes(i).StartY = Val(Getvar(filename, "CLASS" & i, "StartY"))

            Classes(i).BaseExp = Val(Getvar(filename, "CLASS" & i, "BaseExp"))

            DoEvents()
        Next

    End Sub

    Sub SaveClasses()
        Dim filename As String, tmpstring As String = ""
        Dim i As Long
        Dim x As Long

        filename = Application.StartupPath & "\data\classes.ini"

        For i = 1 To Max_Classes
            PutVar(filename, "CLASS" & i, "Name", Trim$(Classes(i).Name))
            PutVar(filename, "CLASS" & i, "Desc", Trim$(Classes(i).Desc))

            For x = 0 To UBound(Classes(i).MaleSprite)
                tmpstring = tmpstring & CStr(Classes(i).MaleSprite(x)) & ","
            Next

            PutVar(filename, "CLASS" & i, "MaleSprite", tmpstring.TrimEnd(","))

            tmpstring = ""

            For x = 0 To UBound(Classes(i).FemaleSprite)
                tmpstring = tmpstring & CStr(Classes(i).FemaleSprite(x)) & ","
            Next
            PutVar(filename, "CLASS" & i, "FemaleSprite", tmpstring.TrimEnd(","))

            PutVar(filename, "CLASS" & i, "Str", Str(Classes(i).Stat(Stats.strength)))
            PutVar(filename, "CLASS" & i, "End", Str(Classes(i).Stat(Stats.endurance)))
            PutVar(filename, "CLASS" & i, "Vit", Str(Classes(i).Stat(Stats.vitality)))
            PutVar(filename, "CLASS" & i, "Luck", Str(Classes(i).Stat(Stats.luck)))
            PutVar(filename, "CLASS" & i, "Int", Str(Classes(i).Stat(Stats.intelligence)))
            PutVar(filename, "CLASS" & i, "Spir", Str(Classes(i).Stat(Stats.spirit)))
            ' loop for items & values
            For x = 1 To 5
                PutVar(filename, "CLASS" & i, "StartItem" & x, Str(Classes(i).StartItem(x)))
                PutVar(filename, "CLASS" & i, "StartValue" & x, Str(Classes(i).StartValue(x)))
            Next

            PutVar(filename, "CLASS" & i, "StartMap", Str(Classes(i).StartMap))
            PutVar(filename, "CLASS" & i, "StartX", Str(Classes(i).StartX))
            PutVar(filename, "CLASS" & i, "StartY", Str(Classes(i).StartY))

            DoEvents()
        Next

    End Sub

    Function GetClassMaxVital(ByVal ClassNum As Long, ByVal Vital As Vitals) As Long
        GetClassMaxVital = 0

        Select Case Vital
            Case Vitals.HP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.vitality) \ 2) + Classes(ClassNum).Stat(Stats.vitality)) * 2
            Case Vitals.MP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.intelligence) \ 2) + Classes(ClassNum).Stat(Stats.intelligence)) * 2
            Case Vitals.SP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.spirit) \ 2) + Classes(ClassNum).Stat(Stats.spirit)) * 2
        End Select

    End Function

    Function GetClassName(ByVal ClassNum As Long) As String
        GetClassName = Trim$(Classes(ClassNum).Name)
    End Function
#End Region

#Region "Maps"
    Sub CheckMaps()
        Dim i As Long

        For i = 1 To MAX_MAPS
            If Not FileExist(Application.StartupPath & "\Data\maps\map" & i & ".dat") Then
                SaveMap(i)
                DoEvents()
            End If
        Next

    End Sub

    Sub ClearMaps()
        Dim i As Long

        For i = 1 To MAX_MAPS
            ClearMap(i)
            DoEvents()
        Next

    End Sub

    Sub ClearMap(ByVal MapNum As Long)
        Dim x As Long
        Dim y As Long
        Map(MapNum) = Nothing
        Map(MapNum).Tileset = 1
        Map(MapNum).Name = ""
        Map(MapNum).MaxX = MAX_MAPX
        Map(MapNum).MaxY = MAX_MAPY
        ReDim Map(MapNum).Npc(0 To MAX_MAP_NPCS)
        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 0 To MAX_MAPX
            For y = 0 To MAX_MAPY
                ReDim Map(MapNum).Tile(x, y).Layer(0 To MapLayer.Count - 1)
                'ReDim Map(MapNum).Tile(x, y).Autotile(0 To MapLayer.Count - 1)
            Next
        Next

        Map(MapNum).EventCount = 0
        ReDim Map(MapNum).Events(0)

        ' Reset the values for if a player is on the map or not
        PlayersOnMap(MapNum) = NO
        Map(MapNum).Tileset = 1
        Map(MapNum).Name = ""
        Map(MapNum).Music = ""
        Map(MapNum).MaxX = MAX_MAPX
        Map(MapNum).MaxY = MAX_MAPY
        ' Reset the map cache array for this map.
        MapCache(MapNum).Data = Nothing
    End Sub

    Sub SaveMaps()
        Dim i As Long

        For i = 1 To MAX_MAPS
            SaveMap(i)
            DoEvents()
        Next

    End Sub

    Sub SaveMap(ByVal MapNum As Long)
        Dim filename As String
        Dim F As Long, x As Long, y As Long, l As Long

        filename = Application.StartupPath & "\data\maps\map" & MapNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Map(MapNum).Name)
        FilePutObject(F, Map(MapNum).Music)
        FilePutObject(F, Map(MapNum).Revision)
        FilePutObject(F, Map(MapNum).Moral)
        FilePutObject(F, Map(MapNum).Tileset)
        FilePutObject(F, Map(MapNum).Up)
        FilePutObject(F, Map(MapNum).Down)
        FilePutObject(F, Map(MapNum).Left)
        FilePutObject(F, Map(MapNum).Right)
        FilePutObject(F, Map(MapNum).BootMap)
        FilePutObject(F, Map(MapNum).BootX)
        FilePutObject(F, Map(MapNum).BootY)
        FilePutObject(F, Map(MapNum).MaxX)
        FilePutObject(F, Map(MapNum).MaxY)
        FilePutObject(F, Map(MapNum).WeatherType)
        FilePutObject(F, Map(MapNum).FogIndex)
        FilePutObject(F, Map(MapNum).WeatherIntensity)
        FilePutObject(F, Map(MapNum).FogAlpha)
        FilePutObject(F, Map(MapNum).FogSpeed)
        FilePutObject(F, Map(MapNum).HasMapTint)
        FilePutObject(F, Map(MapNum).MapTintR)
        FilePutObject(F, Map(MapNum).MapTintG)
        FilePutObject(F, Map(MapNum).MapTintB)
        FilePutObject(F, Map(MapNum).MapTintA)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                FilePutObject(F, Map(MapNum).Tile(x, y).Data1)
                FilePutObject(F, Map(MapNum).Tile(x, y).Data2)
                FilePutObject(F, Map(MapNum).Tile(x, y).Data3)
                FilePutObject(F, Map(MapNum).Tile(x, y).DirBlock)
                For l = 0 To MapLayer.Count - 1
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).Tileset)
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).X)
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).Y)
                    FilePutObject(F, Map(MapNum).Tile(x, y).Layer(l).Autotile)
                Next
                FilePutObject(F, Map(MapNum).Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            FilePutObject(F, Map(MapNum).Npc(x))
        Next

        FileClose(F)

        'This is for event saving, it is in .ini files because there are non-limited values (strings) that cannot easily be loaded/saved in the normal manner.
        filename = Application.StartupPath & "\data\maps\map" & MapNum & "_eventdata.dat"
        PutVar(filename, "Events", "EventCount", Val(Map(MapNum).EventCount))

        If Map(MapNum).EventCount > 0 Then
            For i = 1 To Map(MapNum).EventCount
                With Map(MapNum).Events(i)
                    PutVar(filename, "Event" & i, "Name", .Name)
                    PutVar(filename, "Event" & i, "Global", Val(.Globals))
                    PutVar(filename, "Event" & i, "x", Val(.X))
                    PutVar(filename, "Event" & i, "y", Val(.Y))
                    PutVar(filename, "Event" & i, "PageCount", Val(.PageCount))
                End With
                If Map(MapNum).Events(i).PageCount > 0 Then
                    For x = 1 To Map(MapNum).Events(i).PageCount
                        With Map(MapNum).Events(i).Pages(x)
                            PutVar(filename, "Event" & i & "Page" & x, "chkVariable", Val(.chkVariable))
                            PutVar(filename, "Event" & i & "Page" & x, "VariableIndex", Val(.VariableIndex))
                            PutVar(filename, "Event" & i & "Page" & x, "VariableCondition", Val(.VariableCondition))
                            PutVar(filename, "Event" & i & "Page" & x, "VariableCompare", Val(.VariableCompare))

                            PutVar(filename, "Event" & i & "Page" & x, "chkSwitch", Val(.chkSwitch))
                            PutVar(filename, "Event" & i & "Page" & x, "SwitchIndex", Val(.SwitchIndex))
                            PutVar(filename, "Event" & i & "Page" & x, "SwitchCompare", Val(.SwitchCompare))

                            PutVar(filename, "Event" & i & "Page" & x, "chkHasItem", Val(.chkHasItem))
                            PutVar(filename, "Event" & i & "Page" & x, "HasItemIndex", Val(.HasItemIndex))
                            PutVar(filename, "Event" & i & "Page" & x, "HasItemAmount", Val(.HasItemAmount))

                            PutVar(filename, "Event" & i & "Page" & x, "chkSelfSwitch", Val(.chkSelfSwitch))
                            PutVar(filename, "Event" & i & "Page" & x, "SelfSwitchIndex", Val(.SelfSwitchIndex))
                            PutVar(filename, "Event" & i & "Page" & x, "SelfSwitchCompare", Val(.SelfSwitchCompare))

                            PutVar(filename, "Event" & i & "Page" & x, "GraphicType", Val(.GraphicType))
                            PutVar(filename, "Event" & i & "Page" & x, "Graphic", Val(.Graphic))
                            PutVar(filename, "Event" & i & "Page" & x, "GraphicX", Val(.GraphicX))
                            PutVar(filename, "Event" & i & "Page" & x, "GraphicY", Val(.GraphicY))
                            PutVar(filename, "Event" & i & "Page" & x, "GraphicX2", Val(.GraphicX2))
                            PutVar(filename, "Event" & i & "Page" & x, "GraphicY2", Val(.GraphicY2))

                            PutVar(filename, "Event" & i & "Page" & x, "MoveType", Val(.MoveType))
                            PutVar(filename, "Event" & i & "Page" & x, "MoveSpeed", Val(.MoveSpeed))
                            PutVar(filename, "Event" & i & "Page" & x, "MoveFreq", Val(.MoveFreq))

                            PutVar(filename, "Event" & i & "Page" & x, "IgnoreMoveRoute", Val(.IgnoreMoveRoute))
                            PutVar(filename, "Event" & i & "Page" & x, "RepeatMoveRoute", Val(.RepeatMoveRoute))

                            PutVar(filename, "Event" & i & "Page" & x, "MoveRouteCount", Val(.MoveRouteCount))

                            If .MoveRouteCount > 0 Then
                                For y = 1 To .MoveRouteCount
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Index", Val(.MoveRoute(y).Index))
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data1", Val(.MoveRoute(y).Data1))
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data2", Val(.MoveRoute(y).Data2))
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data3", Val(.MoveRoute(y).Data3))
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data4", Val(.MoveRoute(y).Data4))
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data5", Val(.MoveRoute(y).Data5))
                                    PutVar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data6", Val(.MoveRoute(y).Data6))
                                Next
                            End If

                            PutVar(filename, "Event" & i & "Page" & x, "WalkAnim", Val(.WalkAnim))
                            PutVar(filename, "Event" & i & "Page" & x, "DirFix", Val(.DirFix))
                            PutVar(filename, "Event" & i & "Page" & x, "WalkThrough", Val(.WalkThrough))
                            PutVar(filename, "Event" & i & "Page" & x, "ShowName", Val(.ShowName))
                            PutVar(filename, "Event" & i & "Page" & x, "Trigger", Val(.Trigger))
                            PutVar(filename, "Event" & i & "Page" & x, "CommandListCount", Val(.CommandListCount))

                            PutVar(filename, "Event" & i & "Page" & x, "Position", Val(.Position))
                            PutVar(filename, "Event" & i & "Page" & x, "QuestNum", Val(.QuestNum))

                            PutVar(filename, "Event" & i & "Page" & x, "PlayerGender", Val(.chkPlayerGender))
                        End With

                        If Map(MapNum).Events(i).Pages(x).CommandListCount > 0 Then
                            For y = 1 To Map(MapNum).Events(i).Pages(x).CommandListCount
                                PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "CommandCount", Val(Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount))
                                PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "ParentList", Val(Map(MapNum).Events(i).Pages(x).CommandList(y).ParentList))
                                If Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    For z = 1 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(z)
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Index", Val(.Index))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text1", .Text1)
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text2", .Text2)
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text3", .Text3)
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text4", .Text4)
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Text5", .Text5)
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data1", Val(.Data1))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data2", Val(.Data2))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data3", Val(.Data3))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data4", Val(.Data4))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data5", Val(.Data5))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "Data6", Val(.Data6))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchCommandList", Val(.ConditionalBranch.CommandList))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchCondition", Val(.ConditionalBranch.Condition))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchData1", Val(.ConditionalBranch.Data1))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchData2", Val(.ConditionalBranch.Data2))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchData3", Val(.ConditionalBranch.Data3))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "ConditionalBranchElseCommandList", Val(.ConditionalBranch.ElseCommandList))
                                            PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRouteCount", Val(.MoveRouteCount))
                                            If .MoveRouteCount > 0 Then
                                                For w = 1 To .MoveRouteCount
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Index", Val(.MoveRoute(w).Index))
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data1", Val(.MoveRoute(w).Data1))
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data2", Val(.MoveRoute(w).Data2))
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data3", Val(.MoveRoute(w).Data3))
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data4", Val(.MoveRoute(w).Data4))
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data5", Val(.MoveRoute(w).Data5))
                                                    PutVar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & z & "MoveRoute" & w & "Data6", Val(.MoveRoute(w).Data6))
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
                DoEvents()
            Next
        End If
    End Sub

    Sub LoadMaps()
        Dim i As Long

        CheckMaps()

        For i = 1 To MAX_MAPS
            LoadMap(i)
            DoEvents()
        Next

    End Sub

    Sub LoadMap(ByVal MapNum As Long)
        Dim filename As String

        Dim F As Long
        Dim x As Long
        Dim y As Long
        Dim l As Long

        filename = Application.StartupPath & "\data\maps\map" & MapNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        FileGetObject(F, Map(MapNum).Name)
        FileGetObject(F, Map(MapNum).Music)
        FileGetObject(F, Map(MapNum).Revision)
        FileGetObject(F, Map(MapNum).Moral)
        FileGetObject(F, Map(MapNum).Tileset)
        FileGetObject(F, Map(MapNum).Up)
        FileGetObject(F, Map(MapNum).Down)
        FileGetObject(F, Map(MapNum).Left)
        FileGetObject(F, Map(MapNum).Right)
        FileGetObject(F, Map(MapNum).BootMap)
        FileGetObject(F, Map(MapNum).BootX)
        FileGetObject(F, Map(MapNum).BootY)
        FileGetObject(F, Map(MapNum).MaxX)
        FileGetObject(F, Map(MapNum).MaxY)
        FileGetObject(F, Map(MapNum).WeatherType)
        FileGetObject(F, Map(MapNum).FogIndex)
        FileGetObject(F, Map(MapNum).WeatherIntensity)
        FileGetObject(F, Map(MapNum).FogAlpha)
        FileGetObject(F, Map(MapNum).FogSpeed)
        FileGetObject(F, Map(MapNum).HasMapTint)
        FileGetObject(F, Map(MapNum).MapTintR)
        FileGetObject(F, Map(MapNum).MapTintG)
        FileGetObject(F, Map(MapNum).MapTintB)
        FileGetObject(F, Map(MapNum).MapTintA)

        ' have to set the tile()
        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                FileGetObject(F, Map(MapNum).Tile(x, y).Data1)
                FileGetObject(F, Map(MapNum).Tile(x, y).Data2)
                FileGetObject(F, Map(MapNum).Tile(x, y).Data3)
                FileGetObject(F, Map(MapNum).Tile(x, y).DirBlock)
                ReDim Map(MapNum).Tile(x, y).Layer(0 To MapLayer.Count - 1)
                'ReDim Map(MapNum).Tile(x, y).Autotile(0 To MapLayer.Count - 1)
                For l = 0 To MapLayer.Count - 1
                    FileGetObject(F, Map(MapNum).Tile(x, y).Layer(l).Tileset)
                    FileGetObject(F, Map(MapNum).Tile(x, y).Layer(l).X)
                    FileGetObject(F, Map(MapNum).Tile(x, y).Layer(l).Y)
                    FileGetObject(F, Map(MapNum).Tile(x, y).Layer(l).Autotile)
                Next
                FileGetObject(F, Map(MapNum).Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            FileGetObject(F, Map(MapNum).Npc(x))
            MapNpc(MapNum).Npc(x).Num = Map(MapNum).Npc(x)
        Next

        FileClose(F)

        ClearTempTile(MapNum)
        CacheResources(MapNum)

        If Map(MapNum).Name Is Nothing Then Map(MapNum).Name = ""
        If Map(MapNum).Music Is Nothing Then Map(MapNum).Music = ""


        filename = Application.StartupPath & "\data\maps\map" & MapNum & "_eventdata.dat"
        Map(MapNum).EventCount = Val(Getvar(filename, "Events", "EventCount"))

        If Map(MapNum).EventCount > 0 Then
            ReDim Map(MapNum).Events(0 To Map(MapNum).EventCount)
            For i = 1 To Map(MapNum).EventCount
                If Val(Getvar(filename, "Event" & i, "PageCount")) > 0 Then
                    With Map(MapNum).Events(i)
                        .Name = Getvar(filename, "Event" & i, "Name")
                        .Globals = Val(Getvar(filename, "Event" & i, "Global"))
                        .X = Val(Getvar(filename, "Event" & i, "x"))
                        .Y = Val(Getvar(filename, "Event" & i, "y"))
                        .PageCount = Val(Getvar(filename, "Event" & i, "PageCount"))
                    End With
                    If Map(MapNum).Events(i).PageCount > 0 Then
                        ReDim Map(MapNum).Events(i).Pages(0 To Map(MapNum).Events(i).PageCount)
                        For x = 1 To Map(MapNum).Events(i).PageCount
                            With Map(MapNum).Events(i).Pages(x)
                                .chkVariable = Val(Getvar(filename, "Event" & i & "Page" & x, "chkVariable"))
                                .VariableIndex = Val(Getvar(filename, "Event" & i & "Page" & x, "VariableIndex"))
                                .VariableCondition = Val(Getvar(filename, "Event" & i & "Page" & x, "VariableCondition"))
                                .VariableCompare = Val(Getvar(filename, "Event" & i & "Page" & x, "VariableCompare"))

                                .chkSwitch = Val(Getvar(filename, "Event" & i & "Page" & x, "chkSwitch"))
                                .SwitchIndex = Val(Getvar(filename, "Event" & i & "Page" & x, "SwitchIndex"))
                                .SwitchCompare = Val(Getvar(filename, "Event" & i & "Page" & x, "SwitchCompare"))

                                .chkHasItem = Val(Getvar(filename, "Event" & i & "Page" & x, "chkHasItem"))
                                .HasItemIndex = Val(Getvar(filename, "Event" & i & "Page" & x, "HasItemIndex"))
                                .HasItemAmount = Val(Getvar(filename, "Event" & i & "Page" & x, "HasItemAmount"))

                                .chkSelfSwitch = Val(Getvar(filename, "Event" & i & "Page" & x, "chkSelfSwitch"))
                                .SelfSwitchIndex = Val(Getvar(filename, "Event" & i & "Page" & x, "SelfSwitchIndex"))
                                .SelfSwitchCompare = Val(Getvar(filename, "Event" & i & "Page" & x, "SelfSwitchCompare"))

                                .GraphicType = Val(Getvar(filename, "Event" & i & "Page" & x, "GraphicType"))
                                .Graphic = Val(Getvar(filename, "Event" & i & "Page" & x, "Graphic"))
                                .GraphicX = Val(Getvar(filename, "Event" & i & "Page" & x, "GraphicX"))
                                .GraphicY = Val(Getvar(filename, "Event" & i & "Page" & x, "GraphicY"))
                                .GraphicX2 = Val(Getvar(filename, "Event" & i & "Page" & x, "GraphicX2"))
                                .GraphicY2 = Val(Getvar(filename, "Event" & i & "Page" & x, "GraphicY2"))

                                .MoveType = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveType"))
                                .MoveSpeed = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveSpeed"))
                                .MoveFreq = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveFreq"))

                                .IgnoreMoveRoute = Val(Getvar(filename, "Event" & i & "Page" & x, "IgnoreMoveRoute"))
                                .RepeatMoveRoute = Val(Getvar(filename, "Event" & i & "Page" & x, "RepeatMoveRoute"))

                                .MoveRouteCount = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRouteCount"))

                                If .MoveRouteCount > 0 Then
                                    ReDim Map(MapNum).Events(i).Pages(x).MoveRoute(0 To .MoveRouteCount)
                                    For y = 1 To .MoveRouteCount
                                        .MoveRoute(y).Index = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Index"))
                                        .MoveRoute(y).Data1 = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data1"))
                                        .MoveRoute(y).Data2 = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data2"))
                                        .MoveRoute(y).Data3 = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data3"))
                                        .MoveRoute(y).Data4 = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data4"))
                                        .MoveRoute(y).Data5 = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data5"))
                                        .MoveRoute(y).Data6 = Val(Getvar(filename, "Event" & i & "Page" & x, "MoveRoute" & y & "Data6"))
                                    Next
                                End If

                                .WalkAnim = Val(Getvar(filename, "Event" & i & "Page" & x, "WalkAnim"))
                                .DirFix = Val(Getvar(filename, "Event" & i & "Page" & x, "DirFix"))
                                .WalkThrough = Val(Getvar(filename, "Event" & i & "Page" & x, "WalkThrough"))
                                .ShowName = Val(Getvar(filename, "Event" & i & "Page" & x, "ShowName"))
                                .Trigger = Val(Getvar(filename, "Event" & i & "Page" & x, "Trigger"))
                                .CommandListCount = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandListCount"))

                                .Position = Val(Getvar(filename, "Event" & i & "Page" & x, "Position"))
                                .QuestNum = Val(Getvar(filename, "Event" & i & "Page" & x, "QuestNum"))

                                .chkPlayerGender = Val(Getvar(filename, "Event" & i & "Page" & x, "PlayerGender"))
                            End With

                            If Map(MapNum).Events(i).Pages(x).CommandListCount > 0 Then
                                ReDim Map(MapNum).Events(i).Pages(x).CommandList(0 To Map(MapNum).Events(i).Pages(x).CommandListCount)
                                For y = 1 To Map(MapNum).Events(i).Pages(x).CommandListCount
                                    Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "CommandCount"))
                                    Map(MapNum).Events(i).Pages(x).CommandList(y).ParentList = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "ParentList"))
                                    If Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                        ReDim Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount)
                                        For p = 1 To Map(MapNum).Events(i).Pages(x).CommandList(y).CommandCount
                                            With Map(MapNum).Events(i).Pages(x).CommandList(y).Commands(p)
                                                .Index = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Index"))
                                                .Text1 = Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text1")
                                                .Text2 = Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text2")
                                                .Text3 = Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text3")
                                                .Text4 = Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text4")
                                                .Text5 = Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Text5")
                                                .Data1 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data1"))
                                                .Data2 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data2"))
                                                .Data3 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data3"))
                                                .Data4 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data4"))
                                                .Data5 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data5"))
                                                .Data6 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "Data6"))
                                                .ConditionalBranch.CommandList = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchCommandList"))
                                                .ConditionalBranch.Condition = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchCondition"))
                                                .ConditionalBranch.Data1 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchData1"))
                                                .ConditionalBranch.Data2 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchData2"))
                                                .ConditionalBranch.Data3 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchData3"))
                                                .ConditionalBranch.ElseCommandList = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "ConditionalBranchElseCommandList"))
                                                .MoveRouteCount = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRouteCount"))
                                                If .MoveRouteCount > 0 Then
                                                    ReDim .MoveRoute(0 To .MoveRouteCount)
                                                    For w = 1 To .MoveRouteCount
                                                        .MoveRoute(w).Index = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Index"))
                                                        .MoveRoute(w).Data1 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data1"))
                                                        .MoveRoute(w).Data2 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data2"))
                                                        .MoveRoute(w).Data3 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data3"))
                                                        .MoveRoute(w).Data4 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data4"))
                                                        .MoveRoute(w).Data5 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data5"))
                                                        .MoveRoute(w).Data6 = Val(Getvar(filename, "Event" & i & "Page" & x, "CommandList" & y & "Command" & p & "MoveRoute" & w & "Data6"))
                                                    Next
                                                End If
                                            End With
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If
                DoEvents()
            Next
        End If

    End Sub

    Sub ClearTempTiles()
        Dim i As Long

        For i = 1 To MAX_MAPS
            ClearTempTile(i)
        Next

    End Sub

    Sub ClearTempTile(ByVal MapNum As Long)
        Dim y As Long
        Dim x As Long
        TempTile(MapNum).DoorTimer = 0
        ReDim TempTile(MapNum).DoorOpen(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                TempTile(MapNum).DoorOpen(x, y) = NO
            Next
        Next

    End Sub

    Sub ClearMapItem(ByVal Index As Long, ByVal MapNum As Long)
        MapItem(MapNum, Index) = Nothing

    End Sub

    Sub ClearMapItems()
        Dim x As Long
        Dim y As Long

        For y = 1 To MAX_MAPS
            For x = 1 To MAX_MAP_ITEMS
                ClearMapItem(x, y)
            Next
        Next

    End Sub

#End Region

#Region "Items"
    Sub SaveItems()
        Dim i As Long

        For i = 1 To MAX_ITEMS
            SaveItem(i)
            DoEvents()
        Next

    End Sub

    Sub SaveItem(ByVal itemNum As Long)
        Dim filename As String
        Dim F As Long
        filename = Application.StartupPath & "\data\items\item" & itemNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)
        FilePutObject(F, Item(itemNum).Name)
        FilePutObject(F, Item(itemNum).Pic)
        FilePutObject(F, Item(itemNum).Description)

        FilePutObject(F, Item(itemNum).Type)
        FilePutObject(F, Item(itemNum).Data1)
        FilePutObject(F, Item(itemNum).Data2)
        FilePutObject(F, Item(itemNum).Data3)
        FilePutObject(F, Item(itemNum).ClassReq)
        FilePutObject(F, Item(itemNum).AccessReq)
        FilePutObject(F, Item(itemNum).LevelReq)
        FilePutObject(F, Item(itemNum).Mastery)
        FilePutObject(F, Item(itemNum).price)

        For i = 0 To Stats.Count - 1
            FilePutObject(F, Item(itemNum).Add_Stat(i))
        Next

        FilePutObject(F, Item(itemNum).Rarity)
        FilePutObject(F, Item(itemNum).Speed)
        FilePutObject(F, Item(itemNum).Handed)
        FilePutObject(F, Item(itemNum).BindType)

        For i = 0 To Stats.Count - 1
            FilePutObject(F, Item(itemNum).Stat_Req(i))
        Next

        FilePutObject(F, Item(itemNum).Animation)
        FilePutObject(F, Item(itemNum).Paperdoll)

        'Housing
        FilePutObject(F, Item(itemNum).FurnitureWidth)
        FilePutObject(F, Item(itemNum).FurnitureHeight)

        For a = 1 To 3
            For b = 1 To 3
                FilePutObject(F, Item(itemNum).FurnitureBlocks(a, b))
                FilePutObject(F, Item(itemNum).FurnitureFringe(a, b))
            Next
        Next

        FilePutObject(F, Item(itemNum).KnockBack)
        FilePutObject(F, Item(itemNum).KnockBackTiles)

        FilePutObject(F, Item(itemNum).Randomize)
        FilePutObject(F, Item(itemNum).RandomMin)
        FilePutObject(F, Item(itemNum).RandomMax)

        FilePutObject(F, Item(itemNum).Stackable)

        FileClose(F)
    End Sub

    Sub LoadItems()
        Dim i As Long

        CheckItems()

        For i = 1 To MAX_ITEMS
            LoadItem(i)
            DoEvents()
        Next

    End Sub

    Sub LoadItem(ByVal ItemNum As Long)
        Dim filename As String
        Dim F As Long
        Dim s As Long

        filename = Application.StartupPath & "\data\Items\Item" & ItemNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        FileGetObject(F, Item(ItemNum).Name)
        FileGetObject(F, Item(ItemNum).Pic)
        FileGetObject(F, Item(ItemNum).Description)

        FileGetObject(F, Item(ItemNum).Type)
        FileGetObject(F, Item(ItemNum).Data1)
        FileGetObject(F, Item(ItemNum).Data2)
        FileGetObject(F, Item(ItemNum).Data3)
        FileGetObject(F, Item(ItemNum).ClassReq)
        FileGetObject(F, Item(ItemNum).AccessReq)
        FileGetObject(F, Item(ItemNum).LevelReq)
        FileGetObject(F, Item(ItemNum).Mastery)
        FileGetObject(F, Item(ItemNum).price)

        For s = 0 To Stats.Count - 1
            FileGetObject(F, Item(ItemNum).Add_Stat(s))
        Next

        FileGetObject(F, Item(ItemNum).Rarity)
        FileGetObject(F, Item(ItemNum).Speed)
        FileGetObject(F, Item(ItemNum).Handed)
        FileGetObject(F, Item(ItemNum).BindType)

        For s = 0 To Stats.Count - 1
            FileGetObject(F, Item(ItemNum).Stat_Req(s))
        Next

        FileGetObject(F, Item(ItemNum).Animation)
        FileGetObject(F, Item(ItemNum).Paperdoll)

        'Housing
        FileGetObject(F, Item(ItemNum).FurnitureWidth)
        FileGetObject(F, Item(ItemNum).FurnitureHeight)

        For a = 1 To 3
            For b = 1 To 3
                FileGetObject(F, Item(ItemNum).FurnitureBlocks(a, b))
                FileGetObject(F, Item(ItemNum).FurnitureFringe(a, b))
            Next
        Next

        FileGetObject(F, Item(ItemNum).KnockBack)
        FileGetObject(F, Item(ItemNum).KnockBackTiles)

        FileGetObject(F, Item(ItemNum).Randomize)
        FileGetObject(F, Item(ItemNum).RandomMin)
        FileGetObject(F, Item(ItemNum).RandomMax)

        FileGetObject(F, Item(ItemNum).Stackable)

        FileClose(F)

    End Sub

    Sub CheckItems()
        Dim i As Long

        For i = 1 To MAX_ITEMS

            If Not FileExist(Application.StartupPath & "\Data\Items\Item" & i & ".dat") Then
                SaveItem(i)
            End If

        Next

    End Sub

    Sub ClearItem(ByVal Index As Long)
        Item(Index) = Nothing
        Item(Index).Name = ""
        Item(Index).Description = ""

        For i = 0 To MAX_ITEMS
            ReDim Item(i).Add_Stat(0 To Stats.Count - 1)
            ReDim Item(i).Stat_Req(0 To Stats.Count - 1)
            ReDim Item(i).FurnitureBlocks(0 To 3, 0 To 3)
            ReDim Item(i).FurnitureFringe(0 To 3, 0 To 3)
        Next

    End Sub

    Sub ClearItems()
        Dim i As Long

        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next

    End Sub

#End Region

#Region "Npc's"
    Sub SaveNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS
            SaveNpc(i)
            DoEvents()
        Next

    End Sub

    Sub SaveNpc(ByVal NpcNum As Long)
        Dim filename As String
        Dim F As Long
        Dim i As Long
        filename = Application.StartupPath & "\data\npcs\npc" & NpcNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Npc(NpcNum).Name)
        FilePutObject(F, Npc(NpcNum).AttackSay)
        FilePutObject(F, Npc(NpcNum).Sprite)
        FilePutObject(F, Npc(NpcNum).SpawnSecs)
        FilePutObject(F, Npc(NpcNum).Behaviour)
        FilePutObject(F, Npc(NpcNum).Range)

        For i = 1 To 5
            FilePutObject(F, Npc(NpcNum).DropChance(i))
            FilePutObject(F, Npc(NpcNum).DropItem(i))
            FilePutObject(F, Npc(NpcNum).DropItemValue(i))
        Next

        For i = 0 To Stats.Count - 1
            FilePutObject(F, Npc(NpcNum).Stat(i))
        Next

        FilePutObject(F, Npc(NpcNum).Faction)
        FilePutObject(F, Npc(NpcNum).HP)
        FilePutObject(F, Npc(NpcNum).Exp)
        FilePutObject(F, Npc(NpcNum).Animation)

        FilePutObject(F, Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            FilePutObject(F, Npc(NpcNum).Skill(i))
        Next

        FileClose(F)
    End Sub

    Sub LoadNpcs()
        Dim i As Long

        CheckNpcs()

        For i = 1 To MAX_NPCS
            LoadNpc(i)
            DoEvents()
        Next

    End Sub

    Sub LoadNpc(ByVal NpcNum As Long)
        Dim filename As String
        Dim F As Long
        Dim n As Long

        filename = Application.StartupPath & "\data\npcs\npc" & NpcNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Npc(NpcNum).Name)
        FileGetObject(F, Npc(NpcNum).AttackSay)
        FileGetObject(F, Npc(NpcNum).Sprite)
        FileGetObject(F, Npc(NpcNum).SpawnSecs)
        FileGetObject(F, Npc(NpcNum).Behaviour)
        FileGetObject(F, Npc(NpcNum).Range)

        For i = 1 To 5
            FileGetObject(F, Npc(NpcNum).DropChance(i))
            FileGetObject(F, Npc(NpcNum).DropItem(i))
            FileGetObject(F, Npc(NpcNum).DropItemValue(i))
        Next

        For n = 0 To Stats.Count - 1
            FileGetObject(F, Npc(NpcNum).Stat(n))
        Next

        FileGetObject(F, Npc(NpcNum).Faction)
        FileGetObject(F, Npc(NpcNum).HP)
        FileGetObject(F, Npc(NpcNum).Exp)
        FileGetObject(F, Npc(NpcNum).Animation)

        FileGetObject(F, Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            FileGetObject(F, Npc(NpcNum).Skill(i))
        Next

        FileClose(F)

        If Npc(NpcNum).Name Is Nothing Then Npc(NpcNum).Name = ""
        If Npc(NpcNum).AttackSay Is Nothing Then Npc(NpcNum).AttackSay = ""
    End Sub

    Sub CheckNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS

            If Not FileExist(Application.StartupPath & "\Data\npcs\npc" & i & ".dat") Then
                SaveNpc(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearMapNpc(ByVal Index As Long, ByVal MapNum As Long)
        MapNpc(MapNum).Npc(Index) = Nothing

        ReDim MapNpc(MapNum).Npc(Index).Vital(0 To Vitals.Count)
        ReDim MapNpc(MapNum).Npc(Index).SkillCD(MAX_NPC_SKILLS)
    End Sub

    Sub ClearMapNpcs()
        Dim x As Long
        Dim y As Long

        For y = 1 To MAX_MAPS
            For x = 1 To MAX_MAP_NPCS
                ClearMapNpc(x, y)
                DoEvents()
            Next
        Next

    End Sub

    Sub ClearNpc(ByVal Index As Long)
        Npc(Index) = Nothing
        Npc(Index).Name = ""
        Npc(Index).AttackSay = ""
        ReDim Npc(Index).Stat(0 To Stats.Count - 1)
        For i = 1 To 5
            ReDim Npc(Index).DropChance(5)
            ReDim Npc(Index).DropItem(5)
            ReDim Npc(Index).DropItemValue(5)
            ReDim Npc(Index).Skill(MAX_NPC_SKILLS)
        Next
    End Sub

    Sub ClearNpcs()
        Dim i As Long

        For i = 1 To MAX_NPCS
            ClearNpc(i)
            DoEvents()
        Next

    End Sub

#End Region

#Region "Resources"
    Sub SaveResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES
            SaveResource(i)
            DoEvents()
        Next

    End Sub

    Sub SaveResource(ByVal ResourceNum As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\resources\resource" & ResourceNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Resource(ResourceNum).Name)
        FilePutObject(F, Resource(ResourceNum).SuccessMessage)
        FilePutObject(F, Resource(ResourceNum).EmptyMessage)
        FilePutObject(F, Resource(ResourceNum).ResourceType)
        FilePutObject(F, Resource(ResourceNum).ResourceImage)
        FilePutObject(F, Resource(ResourceNum).ExhaustedImage)
        FilePutObject(F, Resource(ResourceNum).ExpReward)
        FilePutObject(F, Resource(ResourceNum).ItemReward)
        FilePutObject(F, Resource(ResourceNum).LvlRequired)
        FilePutObject(F, Resource(ResourceNum).ToolRequired)
        FilePutObject(F, Resource(ResourceNum).Health)
        FilePutObject(F, Resource(ResourceNum).RespawnTime)
        FilePutObject(F, Resource(ResourceNum).Walkthrough)
        FilePutObject(F, Resource(ResourceNum).Animation)

        FileClose(F)
    End Sub

    Sub LoadResources()
        Dim i As Long

        Call CheckResources()

        For i = 1 To MAX_RESOURCES
            LoadResource(i)
            DoEvents()
        Next

    End Sub

    Sub LoadResource(ByVal ResourceNum As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\resources\resource" & ResourceNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Resource(ResourceNum).Name)
        FileGetObject(F, Resource(ResourceNum).SuccessMessage)
        FileGetObject(F, Resource(ResourceNum).EmptyMessage)
        FileGetObject(F, Resource(ResourceNum).ResourceType)
        FileGetObject(F, Resource(ResourceNum).ResourceImage)
        FileGetObject(F, Resource(ResourceNum).ExhaustedImage)
        FileGetObject(F, Resource(ResourceNum).ExpReward)
        FileGetObject(F, Resource(ResourceNum).ItemReward)
        FileGetObject(F, Resource(ResourceNum).LvlRequired)
        FileGetObject(F, Resource(ResourceNum).ToolRequired)
        FileGetObject(F, Resource(ResourceNum).Health)
        FileGetObject(F, Resource(ResourceNum).RespawnTime)
        FileGetObject(F, Resource(ResourceNum).Walkthrough)
        FileGetObject(F, Resource(ResourceNum).Animation)

        FileClose(F)

        If Resource(ResourceNum).Name Is Nothing Then Resource(ResourceNum).Name = ""
        If Resource(ResourceNum).EmptyMessage Is Nothing Then Resource(ResourceNum).EmptyMessage = ""
        If Resource(ResourceNum).SuccessMessage Is Nothing Then Resource(ResourceNum).SuccessMessage = ""

    End Sub

    Sub CheckResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES

            If Not FileExist(Application.StartupPath & "\Data\Resources\Resource" & i & ".dat") Then
                SaveResource(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearResource(ByVal Index As Long)
        Resource(Index) = Nothing
        Resource(Index).Name = ""
        Resource(Index).EmptyMessage = ""
        Resource(Index).SuccessMessage = ""
    End Sub

    Sub ClearResources()
        Dim i As Long

        For i = 1 To MAX_RESOURCES
            ClearResource(i)
            DoEvents()
        Next
    End Sub

    Public Sub CacheResources(ByVal MapNum As Long)
        Dim x As Long, y As Long, Resource_Count As Long
        Resource_Count = 0

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY

                If Map(MapNum).Tile(x, y).Type = TileType.Resource Then
                    Resource_Count = Resource_Count + 1
                    ReDim Preserve ResourceCache(MapNum).ResourceData(0 To Resource_Count)
                    ResourceCache(MapNum).ResourceData(Resource_Count).x = x
                    ResourceCache(MapNum).ResourceData(Resource_Count).y = y
                    ResourceCache(MapNum).ResourceData(Resource_Count).cur_health = Resource(Map(MapNum).Tile(x, y).Data1).Health
                End If

            Next
        Next

        ResourceCache(MapNum).Resource_Count = Resource_Count
    End Sub

#End Region

#Region "Shops"
    Sub SaveShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS
            SaveShop(i)
            DoEvents()
        Next

    End Sub

    Sub SaveShop(ByVal shopNum As Long)
        Dim i As Long
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\shops\shop" & shopNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Shop(shopNum).Name)
        FilePutObject(F, Shop(shopNum).Face)
        FilePutObject(F, Shop(shopNum).BuyRate)

        For i = 1 To MAX_TRADES
            FilePutObject(F, Shop(shopNum).TradeItem(i).Item)
            FilePutObject(F, Shop(shopNum).TradeItem(i).ItemValue)
            FilePutObject(F, Shop(shopNum).TradeItem(i).costitem)
            FilePutObject(F, Shop(shopNum).TradeItem(i).costvalue)
        Next

        FileClose(F)
    End Sub

    Sub LoadShops()

        Dim i As Long

        CheckShops()

        For i = 1 To MAX_SHOPS
            LoadShop(i)
            DoEvents()
        Next

    End Sub

    Sub LoadShop(ByVal ShopNum As Long)
        Dim filename As String
        Dim x As Long
        Dim F As Long

        filename = Application.StartupPath & "\data\shops\shop" & ShopNum & ".dat"
        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Shop(ShopNum).Name)
        FileGetObject(F, Shop(ShopNum).Face)
        FileGetObject(F, Shop(ShopNum).BuyRate)

        For x = 1 To MAX_TRADES
            FileGetObject(F, Shop(ShopNum).TradeItem(x).Item)
            FileGetObject(F, Shop(ShopNum).TradeItem(x).ItemValue)
            FileGetObject(F, Shop(ShopNum).TradeItem(x).costitem)
            FileGetObject(F, Shop(ShopNum).TradeItem(x).costvalue)
        Next

        FileClose(F)
    End Sub

    Sub CheckShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS

            If Not FileExist(Application.StartupPath & "\Data\shops\shop" & i & ".dat") Then
                SaveShop(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearShop(ByVal Index As Long)
        Dim i As Long

        Shop(Index) = Nothing
        Shop(Index).Name = vbNullString

        ReDim Shop(Index).TradeItem(MAX_TRADES)
        For i = 0 To MAX_SHOPS
            ReDim Shop(i).TradeItem(0 To MAX_TRADES)
        Next

    End Sub

    Sub ClearShops()
        Dim i As Long

        For i = 1 To MAX_SHOPS
            Call ClearShop(i)
        Next

    End Sub

#End Region

#Region "Skills"
    Sub SaveSkills()
        Dim i As Long
        SetStatus("Saving skills... ")

        For i = 1 To MAX_SKILLS
            SaveSkill(i)
            DoEvents()
        Next

    End Sub

    Sub SaveSkill(ByVal skillnum As Long)
        Dim filename As String
        Dim F As Long
        filename = Application.StartupPath & "\data\skills\skills" & skillnum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Skill(skillnum).Name)
        FilePutObject(F, Skill(skillnum).Type)
        FilePutObject(F, Skill(skillnum).MPCost)
        FilePutObject(F, Skill(skillnum).LevelReq)
        FilePutObject(F, Skill(skillnum).AccessReq)
        FilePutObject(F, Skill(skillnum).ClassReq)
        FilePutObject(F, Skill(skillnum).CastTime)
        FilePutObject(F, Skill(skillnum).CDTime)
        FilePutObject(F, Skill(skillnum).Icon)
        FilePutObject(F, Skill(skillnum).Map)
        FilePutObject(F, Skill(skillnum).x)
        FilePutObject(F, Skill(skillnum).y)
        FilePutObject(F, Skill(skillnum).Dir)
        FilePutObject(F, Skill(skillnum).Vital)
        FilePutObject(F, Skill(skillnum).Duration)
        FilePutObject(F, Skill(skillnum).Interval)
        FilePutObject(F, Skill(skillnum).range)
        FilePutObject(F, Skill(skillnum).IsAoE)
        FilePutObject(F, Skill(skillnum).AoE)
        FilePutObject(F, Skill(skillnum).CastAnim)
        FilePutObject(F, Skill(skillnum).SkillAnim)
        FilePutObject(F, Skill(skillnum).StunDuration)

        FilePutObject(F, Skill(skillnum).IsProjectile)
        FilePutObject(F, Skill(skillnum).Projectile)

        FilePutObject(F, Skill(skillnum).KnockBack)
        FilePutObject(F, Skill(skillnum).KnockBackTiles)

        FileClose(F)
    End Sub

    Sub LoadSkills()
        Dim i As Long

        CheckSkills()

        For i = 1 To MAX_SKILLS
            LoadSkill(i)
            DoEvents()
        Next

    End Sub

    Sub LoadSkill(ByVal SkillNum As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\skills\skills" & SkillNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Skill(SkillNum).Name)
        FileGetObject(F, Skill(SkillNum).Type)
        FileGetObject(F, Skill(SkillNum).MPCost)
        FileGetObject(F, Skill(SkillNum).LevelReq)
        FileGetObject(F, Skill(SkillNum).AccessReq)
        FileGetObject(F, Skill(SkillNum).ClassReq)
        FileGetObject(F, Skill(SkillNum).CastTime)
        FileGetObject(F, Skill(SkillNum).CDTime)
        FileGetObject(F, Skill(SkillNum).Icon)
        FileGetObject(F, Skill(SkillNum).Map)
        FileGetObject(F, Skill(SkillNum).x)
        FileGetObject(F, Skill(SkillNum).y)
        FileGetObject(F, Skill(SkillNum).Dir)
        FileGetObject(F, Skill(SkillNum).Vital)
        FileGetObject(F, Skill(SkillNum).Duration)
        FileGetObject(F, Skill(SkillNum).Interval)
        FileGetObject(F, Skill(SkillNum).range)
        FileGetObject(F, Skill(SkillNum).IsAoE)
        FileGetObject(F, Skill(SkillNum).AoE)
        FileGetObject(F, Skill(SkillNum).CastAnim)
        FileGetObject(F, Skill(SkillNum).SkillAnim)
        FileGetObject(F, Skill(SkillNum).StunDuration)

        FileGetObject(F, Skill(SkillNum).IsProjectile)
        FileGetObject(F, Skill(SkillNum).Projectile)

        FileGetObject(F, Skill(SkillNum).KnockBack)
        FileGetObject(F, Skill(SkillNum).KnockBackTiles)

        FileClose(F)
    End Sub

    Sub CheckSkills()
        Dim i As Long

        For i = 1 To MAX_SKILLS

            If Not FileExist(Application.StartupPath & "\Data\skills\skills" & i & ".dat") Then
                SaveSkill(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearSkill(ByVal Index As Long)
        Skill(Index) = Nothing
        Skill(Index).Name = vbNullString
        Skill(Index).LevelReq = 1 'Needs to be 1 for the skill editor
    End Sub

    Sub ClearSkills()
        Dim i As Long

        For i = 1 To MAX_SKILLS
            ClearSkill(i)
            DoEvents()
        Next

    End Sub

#End Region

#Region "Animations"
    Sub SaveAnimations()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS
            SaveAnimation(i)
            DoEvents()
        Next

    End Sub

    Sub SaveAnimation(ByVal AnimationNum As Long)
        Dim filename As String
        Dim F As Long
        Dim x As Long

        filename = Application.StartupPath & "\data\animations\animation" & AnimationNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Animation(AnimationNum).Name)

        For x = 0 To UBound(Animation(AnimationNum).Sprite)
            FilePutObject(F, Animation(AnimationNum).Sprite(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).Frames)
            FilePutObject(F, Animation(AnimationNum).Frames(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopCount)
            FilePutObject(F, Animation(AnimationNum).LoopCount(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopTime)
            FilePutObject(F, Animation(AnimationNum).LoopTime(x))
        Next

        FileClose(F)
    End Sub

    Sub LoadAnimations()
        Dim i As Long

        Call CheckAnimations()

        For i = 1 To MAX_ANIMATIONS
            LoadAnimation(i)
            DoEvents()
        Next

    End Sub

    Sub LoadAnimation(ByVal AnimationNum As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\animations\animation" & AnimationNum & ".dat"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Animation(AnimationNum).Name)

        For x = 0 To UBound(Animation(AnimationNum).Sprite)
            FileGetObject(F, Animation(AnimationNum).Sprite(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).Frames)
            FileGetObject(F, Animation(AnimationNum).Frames(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopCount)
            FileGetObject(F, Animation(AnimationNum).LoopCount(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopTime)
            FileGetObject(F, Animation(AnimationNum).LoopTime(x))
        Next

        FileClose(F)

        If Animation(AnimationNum).Name Is Nothing Then Animation(AnimationNum).Name = ""
    End Sub

    Sub CheckAnimations()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS

            If Not FileExist(Application.StartupPath & "\Data\animations\animation" & i & ".dat") Then
                SaveAnimation(i)
                DoEvents()
            End If

        Next
    End Sub

    Sub ClearAnimation(ByVal Index As Long)
        Animation(Index) = Nothing
        Animation(Index).Name = ""
        ReDim Animation(Index).Sprite(0 To 1)
        ReDim Animation(Index).Frames(0 To 1)
        ReDim Animation(Index).LoopCount(0 To 1)
        ReDim Animation(Index).LoopTime(0 To 1)
    End Sub

    Sub ClearAnimations()
        Dim i As Long

        For i = 1 To MAX_ANIMATIONS
            ClearAnimation(i)
            DoEvents()
        Next
    End Sub

#End Region

#Region "Accounts"
    Function AccountExist(ByVal Name As String) As Boolean
        Dim filename As String
        filename = Application.StartupPath & "\data\accounts\" & Trim$(Name) & "\" & Trim$(Name) & ".bin"

        If FileExist(filename) Then
            AccountExist = True
        Else
            AccountExist = False
        End If
    End Function

    Function PasswordOK(ByVal Name As String, ByVal Password As String) As Boolean
        Dim filename As String
        Dim RightPassword As String
        Dim namecheck As String
        Dim nFileNum As Integer

        RightPassword = ""
        namecheck = ""
        PasswordOK = False

        If AccountExist(Name) Then
            filename = Application.StartupPath & "\data\accounts\" & Trim$(Name) & "\" & Trim$(Name) & ".bin"
            nFileNum = FreeFile()
            FileOpen(nFileNum, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared)
            FileGetObject(nFileNum, namecheck)
            FileGetObject(nFileNum, RightPassword)
            FileClose()

            If Trim(namecheck) <> Trim(Name) Then
                Exit Function
            End If

            If UCase$(Trim$(Password)) = UCase$(Trim$(RightPassword)) Then
                PasswordOK = True
            Else
                PasswordOK = False
            End If
        End If
    End Function

    Sub AddAccount(ByVal Index As Long, ByVal Name As String, ByVal Password As String)
        ClearPlayer(Index)

        Player(Index).Login = Name
        Player(Index).Password = Password

        SavePlayer(Index)
    End Sub

    Sub DeleteName(ByVal Name As String)

        Dim fileName As String = Application.StartupPath & "\data\accounts\charlist.txt"

        ' Read the file line by line
        Dim fileContents = File.ReadAllLines(fileName).ToList

        ' Remove unwanted stuff
        For i = 0 To fileContents.Count - 1
            If fileContents(i).Contains(Trim$(LCase$(Name))) Then
                fileContents.RemoveAt(i)
            End If
        Next

        ' Write the file to disk
        File.WriteAllLines(fileName, fileContents.ToArray)
    End Sub

#End Region

#Region "Players"
    Sub SaveAllPlayersOnline()
        Dim i As Long

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SavePlayer(i)
                SaveBank(i)
                DoEvents()
            End If
        Next

    End Sub

    Sub SavePlayer(ByVal Index As Long)
        Dim filename As String
        Dim F As Long

        CheckDir(Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login))

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & "\" & Trim$(Player(Index).Login) & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Player(Index).Login)
        FilePutObject(F, Player(Index).Password)
        FilePutObject(F, Player(Index).Access)

        FileClose(F)

        For i = 1 To MAX_CHARS
            SaveCharacter(Index, i)
        Next

    End Sub

    Sub LoadPlayer(ByVal Index As Long, ByVal Name As String)
        Dim filename As String
        Dim F As Long

        ClearPlayer(Index)

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Name) & "\" & Trim$(Name) & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Player(Index).Login)
        FileGetObject(F, Player(Index).Password)
        FileGetObject(F, Player(Index).Access)

        FileClose(F)

        For i = 1 To MAX_CHARS
            LoadCharacter(Index, i)
        Next

    End Sub

    Sub ClearPlayer(ByVal Index As Long)
        Dim i As Long

        TempPlayer(Index).Buffer = New ByteBuffer

        Player(Index).Login = ""
        Player(Index).Password = ""

        Player(Index).Access = 0

        For i = 1 To MAX_CHARS
            ClearCharacter(Index, i)
        Next

    End Sub

#End Region

#Region "Bank"
    Public Sub LoadBank(ByVal Index As Long, ByVal Name As String)
        Dim filename As String
        Dim F As Long

        ClearBank(Index)

        filename = Application.StartupPath & "\data\banks\" & Trim$(Name) & ".bin"

        If Not FileExist(filename) Then
            SaveBank(Index)
            Exit Sub
        End If

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)


        For i = 0 To MAX_BANK
            FileGetObject(F, Bank(Index).Item(i).Num)
            FileGetObject(F, Bank(Index).Item(i).Value)
        Next

        FileClose(F)
    End Sub

    Sub SaveBank(ByVal Index As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\banks\" & Trim$(Player(Index).Login) & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        For i = 0 To MAX_BANK
            FilePutObject(F, Bank(Index).Item(i).Num)
            FilePutObject(F, Bank(Index).Item(i).Value)
        Next

        FileClose(F)
    End Sub

    Sub ClearBank(ByVal Index As Long)
        ReDim Bank(Index).Item(MAX_BANK)

        For i = 0 To MAX_BANK

            Bank(Index).Item(i).Num = 0
            Bank(Index).Item(i).Value = 0

        Next
    End Sub

#End Region

#Region "Characters"
    Sub ClearCharacter(ByVal Index As Long, ByVal CharNum As Long)
        Player(Index).Character(CharNum).Classes = 0
        Player(Index).Character(CharNum).Dir = 0

        For i = 0 To Equipment.Count - 1
            Player(Index).Character(CharNum).Equipment(i) = 0
        Next

        For i = 0 To MAX_INV
            Player(Index).Character(CharNum).Inv(i).Num = 0
            Player(Index).Character(CharNum).Inv(i).Value = 0
        Next

        Player(Index).Character(CharNum).exp = 0
        Player(Index).Character(CharNum).Level = 0
        Player(Index).Character(CharNum).Map = 0
        Player(Index).Character(CharNum).Name = ""
        Player(Index).Character(CharNum).PK = 0
        Player(Index).Character(CharNum).POINTS = 0
        Player(Index).Character(CharNum).Sex = 0

        For i = 0 To MAX_PLAYER_SKILLS
            Player(Index).Character(CharNum).Skill(i) = 0
        Next

        Player(Index).Character(CharNum).Sprite = 0

        For i = 0 To Stats.Count - 1
            Player(Index).Character(CharNum).Stat(i) = 0
        Next

        For i = 0 To Vitals.Count - 1
            Player(Index).Character(CharNum).Vital(i) = 0
        Next

        Player(Index).Character(CharNum).x = 0
        Player(Index).Character(CharNum).y = 0

        ReDim Player(Index).Character(CharNum).PlayerQuest(MAX_QUESTS)
        For i = 1 To MAX_QUESTS
            Player(Index).Character(CharNum).PlayerQuest(i).Status = 0
            Player(Index).Character(CharNum).PlayerQuest(i).ActualTask = 0
            Player(Index).Character(CharNum).PlayerQuest(i).CurrentCount = 0
        Next

        'Housing
        Player(Index).Character(CharNum).House.HouseIndex = 0
        Player(Index).Character(CharNum).House.FurnitureCount = 0
        ReDim Player(Index).Character(CharNum).House.Furniture(Player(Index).Character(CharNum).House.FurnitureCount)

        For i = 0 To Player(Index).Character(CharNum).House.FurnitureCount
            Player(Index).Character(CharNum).House.Furniture(i).ItemNum = 0
            Player(Index).Character(CharNum).House.Furniture(i).X = 0
            Player(Index).Character(CharNum).House.Furniture(i).Y = 0
        Next

        Player(Index).Character(CharNum).InHouse = 0
        Player(Index).Character(CharNum).LastMap = 0
        Player(Index).Character(CharNum).LastX = 0
        Player(Index).Character(CharNum).LastY = 0

        ReDim Player(Index).Character(CharNum).Hotbar(MAX_HOTBAR)
        For i = 1 To MAX_HOTBAR
            Player(Index).Character(CharNum).Hotbar(i).Slot = 0
            Player(Index).Character(CharNum).Hotbar(i).sType = 0
        Next

        ReDim Player(Index).Character(CharNum).Switches(MAX_SWITCHES)
        For i = 1 To MAX_SWITCHES
            Player(Index).Character(CharNum).Switches(i) = 0
        Next
        ReDim Player(Index).Character(CharNum).Variables(MAX_VARIABLES)
        For i = 1 To MAX_VARIABLES
            Player(Index).Character(CharNum).Variables(i) = 0
        Next

        ReDim Player(Index).Character(CharNum).GatherSkills(ResourceSkills.Count - 1)
        For i = 0 To ResourceSkills.Count - 1
            Player(Index).Character(CharNum).GatherSkills(i).SkillLevel = 1
            Player(Index).Character(CharNum).GatherSkills(i).SkillCurExp = 0
            Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 100
        Next

        ReDim Player(Index).Character(CharNum).RecipeLearned(MAX_RECIPE)
        For i = 1 To MAX_RECIPE
            Player(Index).Character(CharNum).RecipeLearned(i) = 0
        Next

    End Sub

    Sub LoadCharacter(ByVal Index As Long, ByVal CharNum As Long)
        Dim filename As String
        Dim F As Long

        ClearCharacter(Index, CharNum)

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & "\" & CharNum & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)

        FileGetObject(F, Player(Index).Character(CharNum).Classes)
        FileGetObject(F, Player(Index).Character(CharNum).Dir)
        FileGetObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Armor))
        FileGetObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Helmet))
        FileGetObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Shield))
        FileGetObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Weapon))
        FileGetObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Shoes))
        FileGetObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Gloves))
        FileGetObject(F, Player(Index).Character(CharNum).exp)

        For i = 0 To MAX_INV
            FileGetObject(F, Player(Index).Character(CharNum).Inv(i).Num)
            FileGetObject(F, Player(Index).Character(CharNum).Inv(i).Value)
        Next

        FileGetObject(F, Player(Index).Character(CharNum).Level)
        FileGetObject(F, Player(Index).Character(CharNum).Map)
        FileGetObject(F, Player(Index).Character(CharNum).Name)
        FileGetObject(F, Player(Index).Character(CharNum).PK)
        FileGetObject(F, Player(Index).Character(CharNum).POINTS)
        FileGetObject(F, Player(Index).Character(CharNum).Sex)

        For i = 0 To MAX_PLAYER_SKILLS
            FileGetObject(F, Player(Index).Character(CharNum).Skill(i))
        Next

        FileGetObject(F, Player(Index).Character(CharNum).Sprite)

        For i = 0 To Stats.Count - 1
            FileGetObject(F, Player(Index).Character(CharNum).Stat(i))
        Next

        For i = 0 To Vitals.Count - 1
            FileGetObject(F, Player(Index).Character(CharNum).Vital(i))
        Next

        FileGetObject(F, Player(Index).Character(CharNum).x)
        FileGetObject(F, Player(Index).Character(CharNum).y)

        For i = 1 To MAX_QUESTS
            FileGetObject(F, Player(Index).Character(CharNum).PlayerQuest(i).Status)
            FileGetObject(F, Player(Index).Character(CharNum).PlayerQuest(i).ActualTask)
            FileGetObject(F, Player(Index).Character(CharNum).PlayerQuest(i).CurrentCount)
        Next

        'Housing
        FileGetObject(F, Player(Index).Character(CharNum).House.HouseIndex)
        FileGetObject(F, Player(Index).Character(CharNum).House.FurnitureCount)
        ReDim Player(Index).Character(CharNum).House.Furniture(Player(Index).Character(CharNum).House.FurnitureCount)
        For i = 0 To Player(Index).Character(CharNum).House.FurnitureCount
            FileGetObject(F, Player(Index).Character(CharNum).House.Furniture(i).ItemNum)
            FileGetObject(F, Player(Index).Character(CharNum).House.Furniture(i).X)
            FileGetObject(F, Player(Index).Character(CharNum).House.Furniture(i).Y)
        Next
        FileGetObject(F, Player(Index).Character(CharNum).InHouse)
        FileGetObject(F, Player(Index).Character(CharNum).LastMap)
        FileGetObject(F, Player(Index).Character(CharNum).LastX)
        FileGetObject(F, Player(Index).Character(CharNum).LastY)

        For i = 1 To MAX_HOTBAR
            FileGetObject(F, Player(Index).Character(CharNum).Hotbar(i).Slot)
            FileGetObject(F, Player(Index).Character(CharNum).Hotbar(i).sType)
        Next

        ReDim Player(Index).Character(CharNum).Switches(MAX_SWITCHES)
        For i = 1 To MAX_SWITCHES
            FileGetObject(F, Player(Index).Character(CharNum).Switches(i))
        Next
        ReDim Player(Index).Character(CharNum).Variables(MAX_VARIABLES)
        For i = 1 To MAX_VARIABLES
            FileGetObject(F, Player(Index).Character(CharNum).Variables(i))
        Next

        ReDim Player(Index).Character(CharNum).GatherSkills(ResourceSkills.Count - 1)
        For i = 0 To ResourceSkills.Count - 1
            FileGetObject(F, Player(Index).Character(CharNum).GatherSkills(i).SkillLevel)
            FileGetObject(F, Player(Index).Character(CharNum).GatherSkills(i).SkillCurExp)
            FileGetObject(F, Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp)
            If Player(Index).Character(CharNum).GatherSkills(i).SkillLevel = 0 Then Player(Index).Character(CharNum).GatherSkills(i).SkillLevel = 1
            If Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 0 Then Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 100
        Next

        ReDim Player(Index).Character(CharNum).RecipeLearned(MAX_RECIPE)
        For i = 1 To MAX_RECIPE
            FileGetObject(F, Player(Index).Character(CharNum).RecipeLearned(i))
        Next

        FileClose(F)
    End Sub

    Sub SaveCharacter(ByVal Index As Long, ByVal CharNum As Long)
        Dim filename As String
        Dim F As Long

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & "\" & CharNum & ".bin"

        F = FreeFile()
        FileOpen(F, filename, OpenMode.Binary, OpenAccess.Write, OpenShare.Default)

        FilePutObject(F, Player(Index).Character(CharNum).Classes)
        FilePutObject(F, Player(Index).Character(CharNum).Dir)
        FilePutObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Armor))
        FilePutObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Helmet))
        FilePutObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Shield))
        FilePutObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Weapon))
        FilePutObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Shoes))
        FilePutObject(F, Player(Index).Character(CharNum).Equipment(Equipment.Gloves))
        FilePutObject(F, Player(Index).Character(CharNum).exp)

        For i = 0 To MAX_INV
            FilePutObject(F, Player(Index).Character(CharNum).Inv(i).Num)
            FilePutObject(F, Player(Index).Character(CharNum).Inv(i).Value)
        Next

        FilePutObject(F, Player(Index).Character(CharNum).Level)
        FilePutObject(F, Player(Index).Character(CharNum).Map)
        FilePutObject(F, Player(Index).Character(CharNum).Name)
        FilePutObject(F, Player(Index).Character(CharNum).PK)
        FilePutObject(F, Player(Index).Character(CharNum).POINTS)
        FilePutObject(F, Player(Index).Character(CharNum).Sex)

        For i = 0 To MAX_PLAYER_SKILLS
            FilePutObject(F, Player(Index).Character(CharNum).Skill(i))
        Next

        FilePutObject(F, Player(Index).Character(CharNum).Sprite)

        For i = 0 To Stats.Count - 1
            FilePutObject(F, Player(Index).Character(CharNum).Stat(i))
        Next

        For i = 0 To Vitals.Count - 1
            FilePutObject(F, Player(Index).Character(CharNum).Vital(i))
        Next

        FilePutObject(F, Player(Index).Character(CharNum).x)
        FilePutObject(F, Player(Index).Character(CharNum).y)

        For i = 1 To MAX_QUESTS
            FilePutObject(F, Player(Index).Character(CharNum).PlayerQuest(i).Status)
            FilePutObject(F, Player(Index).Character(CharNum).PlayerQuest(i).ActualTask)
            FilePutObject(F, Player(Index).Character(CharNum).PlayerQuest(i).CurrentCount)
        Next

        'Housing
        FilePutObject(F, Player(Index).Character(CharNum).House.HouseIndex)
        FilePutObject(F, Player(Index).Character(CharNum).House.FurnitureCount)
        For i = 0 To Player(Index).Character(CharNum).House.FurnitureCount
            FilePutObject(F, Player(Index).Character(CharNum).House.Furniture(i).ItemNum)
            FilePutObject(F, Player(Index).Character(CharNum).House.Furniture(i).X)
            FilePutObject(F, Player(Index).Character(CharNum).House.Furniture(i).Y)
        Next
        FilePutObject(F, Player(Index).Character(CharNum).InHouse)
        FilePutObject(F, Player(Index).Character(CharNum).LastMap)
        FilePutObject(F, Player(Index).Character(CharNum).LastX)
        FilePutObject(F, Player(Index).Character(CharNum).LastY)


        For i = 1 To MAX_HOTBAR
            FilePutObject(F, Player(Index).Character(CharNum).Hotbar(i).Slot)
            FilePutObject(F, Player(Index).Character(CharNum).Hotbar(i).sType)
        Next

        For i = 1 To MAX_SWITCHES
            FilePutObject(F, Player(Index).Character(CharNum).Switches(i))
        Next

        For i = 1 To MAX_VARIABLES
            FilePutObject(F, Player(Index).Character(CharNum).Variables(i))
        Next

        For i = 0 To ResourceSkills.Count - 1
            FilePutObject(F, Player(Index).Character(CharNum).GatherSkills(i).SkillLevel)
            FilePutObject(F, Player(Index).Character(CharNum).GatherSkills(i).SkillCurExp)
            FilePutObject(F, Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp)
        Next

        For i = 1 To MAX_RECIPE
            FilePutObject(F, Player(Index).Character(CharNum).RecipeLearned(i))
        Next

        FileClose(F)
    End Sub

    Function CharExist(ByVal Index As Long, ByVal CharNum As Long) As Boolean

        If Len(Trim$(Player(Index).Character(CharNum).Name)) > 0 Then
            CharExist = True
        Else
            CharExist = False
        End If

    End Function

    Sub AddChar(ByVal Index As Long, ByVal CharNum As Long, ByVal Name As String, ByVal Sex As Byte, ByVal ClassNum As Byte, ByVal Sprite As Long)
        Dim n As Long, i As Long
        Dim spritecheck As Boolean

        If Len(Trim$(Player(Index).Character(CharNum).Name)) = 0 Then

            spritecheck = False

            Player(Index).Character(CharNum).Name = Name
            Player(Index).Character(CharNum).Sex = Sex
            Player(Index).Character(CharNum).Classes = ClassNum

            If Player(Index).Character(CharNum).Sex = SexType.Male Then
                Player(Index).Character(CharNum).Sprite = Classes(ClassNum).MaleSprite(Sprite - 1)
            Else
                Player(Index).Character(CharNum).Sprite = Classes(ClassNum).FemaleSprite(Sprite - 1)
            End If

            Player(Index).Character(CharNum).Level = 1

            For n = 1 To Stats.Count - 1
                Player(Index).Character(CharNum).Stat(n) = Classes(ClassNum).Stat(n)
            Next n

            Player(Index).Character(CharNum).Dir = DIR_DOWN
            Player(Index).Character(CharNum).Map = Classes(ClassNum).StartMap
            Player(Index).Character(CharNum).x = Classes(ClassNum).StartX
            Player(Index).Character(CharNum).y = Classes(ClassNum).StartY
            Player(Index).Character(CharNum).Dir = DIR_DOWN
            Player(Index).Character(CharNum).Vital(Vitals.HP) = GetPlayerMaxVital(Index, Vitals.HP)
            Player(Index).Character(CharNum).Vital(Vitals.MP) = GetPlayerMaxVital(Index, Vitals.MP)
            Player(Index).Character(CharNum).Vital(Vitals.SP) = GetPlayerMaxVital(Index, Vitals.SP)

            ' set starter equipment
            For n = 1 To 5
                If Classes(ClassNum).StartItem(n) > 0 Then
                    Player(Index).Character(CharNum).Inv(n).Num = Classes(ClassNum).StartItem(n)
                    Player(Index).Character(CharNum).Inv(n).Value = Classes(ClassNum).StartValue(n)
                End If
            Next

            'set skills
            ReDim Player(Index).Character(CharNum).GatherSkills(ResourceSkills.Count - 1)
            For i = 0 To ResourceSkills.Count - 1
                Player(Index).Character(CharNum).GatherSkills(i).SkillLevel = 1
                Player(Index).Character(CharNum).GatherSkills(i).SkillCurExp = 0
                Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 100
            Next

            ' Append name to file
            AddTextToFile(Name, "accounts\charlist.txt")

            SavePlayer(Index)
            Exit Sub
        End If

    End Sub

    Function FindChar(ByVal Name As String) As Boolean
        FindChar = False
        Dim characters() As String
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False

        fullpath = Application.StartupPath & "\data\accounts\charlist.txt"

        Contents = GetFileContents(fullpath)
        characters = Split(Contents, vbNewLine)

        For i = 0 To UBound(characters)
            If Trim$(LCase(characters(i)) = Trim$(LCase(Name))) Then
                FindChar = True
            End If
        Next

        Return FindChar
    End Function

#End Region

#Region "IniReading"
    Public Sub SaveOptions()
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Game_Name", Options.Game_Name)
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Port", Str(Options.Port))
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "MOTD", Options.MOTD)
        PutVar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Website", Options.Website)
    End Sub

    Public Sub LoadOptions()
        Options.Game_Name = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Game_Name")
        Options.Port = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Port")
        Options.MOTD = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "MOTD")
        Options.Website = Getvar(Application.StartupPath & "\data\options.ini", "OPTIONS", "Website")
    End Sub

#End Region

#Region "Logs"

    Public Function GetFileContents(ByVal FullPath As String,
               Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader
        strContents = ""
        If Not File.Exists(FullPath) Then
            Dim fs As FileStream = File.Create(FullPath)
            fs.Close()
            fs.Dispose()
        End If
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return strContents
    End Function

    Public Function Addlog(ByVal strData As String, ByVal FN As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        fullpath = Application.StartupPath & "\data\logs\" & FN
        Contents = GetFileContents(fullpath)
        Contents = Contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(Contents)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function

    Public Function AddTextToFile(ByVal strData As String, ByVal FN As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim fullpath As String
        Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        fullpath = Application.StartupPath & "\data\" & FN
        Contents = GetFileContents(fullpath)
        Contents = Contents & vbNewLine & strData
        Try
            objReader = New StreamWriter(fullpath)
            objReader.Write(Contents)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function

#End Region

#Region "Compression"
    Public Function Compress(ByVal b() As Byte) As Byte()
        Dim ms As New MemoryStream()
        Dim gzipstream As New GZipStream(ms, CompressionMode.Compress)
        gzipstream.Write(b, 0, b.Length)
        gzipstream.Flush()
        gzipstream.Close()
        Dim ret() As Byte = ms.ToArray()
        gzipstream.Close()
        gzipstream.Dispose()
        ms.Close()
        ms.Dispose()
        Return ret
    End Function

    Public Function Decompress(ByVal bytes() As Byte) As Byte()
        Dim ms As New MemoryStream(bytes)
        Dim gz As New GZipStream(ms, CompressionMode.Decompress)
        Dim bt(3) As Byte
        ms.Position = ms.Length - 4
        ms.Read(bt, 0, 4)
        ms.Position = 0
        Dim size As Integer = BitConverter.ToInt32(bt, 0)
        Dim buffer(size + 100) As Byte
        Dim offset As Integer = 0
        Dim total As Integer = 0
        While (True)
            Dim j As Integer = gz.Read(buffer, offset, 100)
            If j = 0 Then Exit While
            offset += j
            total += j
        End While
        gz.Close()
        gz.Dispose()
        ms.Close()
        ms.Dispose()
        Dim ra(total - 1) As Byte
        Array.ConstrainedCopy(buffer, 0, ra, 0, total)
        Return ra
    End Function
#End Region

#Region "Banning"
    Sub ServerBanIndex(ByVal BanPlayerIndex As Long)
        Dim filename As String
        Dim IP As String
        Dim F As Long
        Dim i As Long
        filename = Application.StartupPath & "data\banlist.txt"

        ' Make sure the file exists
        If Not FileExist("data\banlist.txt") Then
            F = FreeFile()
            'COME HERE!!!
        End If

        ' Cut off last portion of ip
        IP = GetPlayerIP(BanPlayerIndex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP & "," & "Server", "banlist.txt")
        GlobalMsg(GetPlayerName(BanPlayerIndex) & " has been banned from " & Options.Game_Name & " by " & "the Server" & "!")
        Addlog("The Server" & " has banned " & GetPlayerName(BanPlayerIndex) & ".", ADMIN_LOG)
        AlertMsg(BanPlayerIndex, "You have been banned by " & "The Server" & "!")
    End Sub

    Sub BanIndex(ByVal BanPlayerIndex As Long, ByVal BannedByIndex As Long)
        Dim filename As String
        Dim IP As String
        Dim F As Long
        Dim i As Long
        filename = Application.StartupPath & "\data\banlist.txt"

        ' Make sure the file exists
        If Not FileExist("data\banlist.txt") Then
            F = FreeFile()
        End If

        ' Cut off last portion of ip
        IP = GetPlayerIP(BanPlayerIndex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP & "," & GetPlayerName(BannedByIndex), "banlist.txt")
        GlobalMsg(GetPlayerName(BanPlayerIndex) & " has been banned from " & Options.Game_Name & " by " & GetPlayerName(BannedByIndex) & "!")
        Addlog(GetPlayerName(BannedByIndex) & " has banned " & GetPlayerName(BanPlayerIndex) & ".", ADMIN_LOG)
        AlertMsg(BanPlayerIndex, "You have been banned by " & GetPlayerName(BannedByIndex) & "!")
    End Sub
#End Region

#Region "Data Functions"
    Function ClassData() As Byte()
        Dim i As Long, n As Long, q As Long
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(Trim$(GetClassName(i)))
            Buffer.WriteString(Trim(Classes(i).Desc))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteLong(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)

            ' send array size
            Buffer.WriteLong(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)

            ' send array size
            Buffer.WriteLong(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteLong(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteLong(Classes(i).Stat(Stats.strength))
            Buffer.WriteLong(Classes(i).Stat(Stats.endurance))
            Buffer.WriteLong(Classes(i).Stat(Stats.vitality))
            Buffer.WriteLong(Classes(i).Stat(Stats.intelligence))
            Buffer.WriteLong(Classes(i).Stat(Stats.luck))
            Buffer.WriteLong(Classes(i).Stat(Stats.spirit))

            For q = 1 To 5
                Buffer.WriteLong(Classes(i).StartItem(q))
                Buffer.WriteLong(Classes(i).StartValue(q))
            Next

            Buffer.WriteLong(Classes(i).StartMap)
            Buffer.WriteLong(Classes(i).StartX)
            Buffer.WriteLong(Classes(i).StartY)

            Buffer.WriteLong(Classes(i).BaseExp)
        Next

        Return Buffer.ToArray()
        Buffer = Nothing
    End Function

    Function ItemsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long
        buffer = New ByteBuffer

        For i = 1 To MAX_ITEMS

            If Len(Trim$(Item(i).Name)) > 0 Then
                buffer.WriteBytes(ItemData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing

    End Function

    Function ItemData(ByVal itemNum As Long) As Byte()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteLong(itemNum)
        Buffer.WriteLong(Item(itemNum).AccessReq)

        For i = 0 To Stats.Count - 1
            Buffer.WriteLong(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteLong(Item(itemNum).Animation)
        Buffer.WriteLong(Item(itemNum).BindType)
        Buffer.WriteLong(Item(itemNum).ClassReq)
        Buffer.WriteLong(Item(itemNum).Data1)
        Buffer.WriteLong(Item(itemNum).Data2)
        Buffer.WriteLong(Item(itemNum).Data3)
        Buffer.WriteLong(Item(itemNum).Handed)
        Buffer.WriteLong(Item(itemNum).LevelReq)
        Buffer.WriteLong(Item(itemNum).Mastery)
        Buffer.WriteString(Trim$(Item(itemNum).Name))
        Buffer.WriteLong(Item(itemNum).Paperdoll)
        Buffer.WriteLong(Item(itemNum).Pic)
        Buffer.WriteLong(Item(itemNum).price)
        Buffer.WriteLong(Item(itemNum).Rarity)
        Buffer.WriteLong(Item(itemNum).Speed)

        Buffer.WriteLong(Item(itemNum).Randomize)
        Buffer.WriteLong(Item(itemNum).RandomMin)
        Buffer.WriteLong(Item(itemNum).RandomMax)

        Buffer.WriteLong(Item(itemNum).Stackable)
        Buffer.WriteString(Trim$(Item(itemNum).Description))

        For i = 0 To Stats.Count - 1
            Buffer.WriteLong(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteLong(Item(itemNum).Type)

        'Housing
        Buffer.WriteLong(Item(itemNum).FurnitureWidth)
        Buffer.WriteLong(Item(itemNum).FurnitureHeight)

        For i = 1 To 3
            For x = 1 To 3
                Buffer.WriteLong(Item(itemNum).FurnitureBlocks(i, x))
                Buffer.WriteLong(Item(itemNum).FurnitureFringe(i, x))
            Next
        Next

        Buffer.WriteLong(Item(itemNum).KnockBack)
        Buffer.WriteLong(Item(itemNum).KnockBackTiles)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function AnimationsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long
        buffer = New ByteBuffer

        For i = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(i).Name)) > 0 Then
                buffer.WriteBytes(AnimationData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function AnimationData(ByVal AnimationNum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteLong(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteLong(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteLong(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteLong(Animation(AnimationNum).Sprite(i))
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function NpcsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long
        buffer = New ByteBuffer

        For i = 1 To MAX_NPCS

            If Len(Trim$(Npc(i).Name)) > 0 Then
                buffer.WriteBytes(NpcData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function NpcData(ByVal NpcNum As Long) As Byte()
        Dim Buffer As ByteBuffer, i As Long
        Buffer = New ByteBuffer
        Buffer.WriteLong(NpcNum)
        Buffer.WriteLong(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteLong(Npc(NpcNum).Behaviour)

        For i = 1 To 5
            Buffer.WriteLong(Npc(NpcNum).DropChance(i))
            Buffer.WriteLong(Npc(NpcNum).DropItem(i))
            Buffer.WriteLong(Npc(NpcNum).DropItemValue(i))
        Next

        Buffer.WriteLong(Npc(NpcNum).Exp)
        Buffer.WriteLong(Npc(NpcNum).Faction)
        Buffer.WriteLong(Npc(NpcNum).HP)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteLong(Npc(NpcNum).Range)
        Buffer.WriteLong(Npc(NpcNum).SpawnSecs)
        Buffer.WriteLong(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Count - 1
            Buffer.WriteLong(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteLong(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            Buffer.WriteLong(Npc(NpcNum).Skill(i))
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function ShopsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long

        buffer = New ByteBuffer

        For i = 1 To MAX_SHOPS

            If Len(Trim$(Shop(i).Name)) > 0 Then
                buffer.WriteBytes(ShopData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function ShopData(ByVal shopNum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(shopNum)
        Buffer.WriteLong(Shop(shopNum).BuyRate)
        Buffer.WriteString(Shop(shopNum).Name)
        Buffer.WriteLong(Shop(shopNum).Face)

        For i = 0 To MAX_TRADES
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costitem)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).costvalue)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteLong(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function SkillsData() As Byte()
        Dim i As Long
        Dim buffer As ByteBuffer

        buffer = New ByteBuffer

        For i = 1 To MAX_SKILLS

            If Len(Trim$(Skill(i).Name)) > 0 Then
                buffer.WriteBytes(SkillData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function SkillData(ByVal skillnum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(skillnum)
        Buffer.WriteLong(Skill(skillnum).AccessReq)
        Buffer.WriteLong(Skill(skillnum).AoE)
        Buffer.WriteLong(Skill(skillnum).CastAnim)
        Buffer.WriteLong(Skill(skillnum).CastTime)
        Buffer.WriteLong(Skill(skillnum).CDTime)
        Buffer.WriteLong(Skill(skillnum).ClassReq)
        Buffer.WriteLong(Skill(skillnum).Dir)
        Buffer.WriteLong(Skill(skillnum).Duration)
        Buffer.WriteLong(Skill(skillnum).Icon)
        Buffer.WriteLong(Skill(skillnum).Interval)
        Buffer.WriteLong(Skill(skillnum).IsAoE)
        Buffer.WriteLong(Skill(skillnum).LevelReq)
        Buffer.WriteLong(Skill(skillnum).Map)
        Buffer.WriteLong(Skill(skillnum).MPCost)
        Buffer.WriteString(Skill(skillnum).Name)
        Buffer.WriteLong(Skill(skillnum).range)
        Buffer.WriteLong(Skill(skillnum).SkillAnim)
        Buffer.WriteLong(Skill(skillnum).StunDuration)
        Buffer.WriteLong(Skill(skillnum).Type)
        Buffer.WriteLong(Skill(skillnum).Vital)
        Buffer.WriteLong(Skill(skillnum).x)
        Buffer.WriteLong(Skill(skillnum).y)

        Buffer.WriteLong(Skill(skillnum).IsProjectile)
        Buffer.WriteLong(Skill(skillnum).Projectile)

        Buffer.WriteLong(Skill(skillnum).KnockBack)
        Buffer.WriteLong(Skill(skillnum).KnockBackTiles)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function ResourcesData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Long

        buffer = New ByteBuffer

        For i = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(i).Name)) > 0 Then
                buffer.WriteBytes(ResourceData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function ResourceData(ByVal ResourceNum As Long) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteLong(ResourceNum)
        Buffer.WriteLong(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteLong(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteLong(Resource(ResourceNum).Health)
        Buffer.WriteLong(Resource(ResourceNum).ExpReward)
        Buffer.WriteLong(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteLong(Resource(ResourceNum).ResourceImage)
        Buffer.WriteLong(Resource(ResourceNum).ResourceType)
        Buffer.WriteLong(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteLong(Resource(ResourceNum).LvlRequired)
        Buffer.WriteLong(Resource(ResourceNum).ToolRequired)
        Buffer.WriteLong(Resource(ResourceNum).Walkthrough)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

#End Region

End Module
