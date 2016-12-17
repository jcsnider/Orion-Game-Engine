Imports System.IO
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
        Dim i As Integer

        ReDim Classes(0 To Max_Classes)

        For i = 1 To Max_Classes
            Classes(i) = Nothing
            Classes(i).Name = ""
            Classes(i).Desc = ""
        Next

        For i = 0 To Max_Classes
            ReDim Classes(i).Stat(0 To Stats.Count - 1)
            ReDim Classes(i).StartItem(0 To 5)
            ReDim Classes(i).StartValue(0 To 5)
        Next

    End Sub

    Sub LoadClasses()
        Dim filename As String
        Dim i As Integer, n As Integer
        Dim tmpSprite As String
        Dim tmpArray() As String
        Dim x As Integer

        filename = Application.StartupPath & "\data\classes.ini"

        If Not FileExist(filename) Then CreateClassesIni()

        Max_Classes = Val(Getvar(filename, "INIT", "MaxClasses"))
        'ReDim Classes(0 To Max_Classes)
        'For i = 0 To Max_Classes
        '    ReDim Classes(i).Stat(0 To Stats.Count - 1)
        '    ReDim Classes(i).StartItem(0 To 5)
        '    ReDim Classes(i).StartValue(0 To 5)
        'Next

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
            Classes(i).Stat(Stats.Endurance) = Val(Getvar(filename, "CLASS" & i, "End"))
            Classes(i).Stat(Stats.Vitality) = Val(Getvar(filename, "CLASS" & i, "Vit"))
            Classes(i).Stat(Stats.Luck) = Val(Getvar(filename, "CLASS" & i, "Luck"))
            Classes(i).Stat(Stats.intelligence) = Val(Getvar(filename, "CLASS" & i, "Int"))
            Classes(i).Stat(Stats.Speed) = Val(Getvar(filename, "CLASS" & i, "Speed"))

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
        Dim i As Integer
        Dim x As Integer

        filename = Application.StartupPath & "\data\classes.ini"

        PutVar(filename, "INIT", "MaxClasses", Str(Max_Classes))

        For i = 1 To Max_Classes
            PutVar(filename, "CLASS" & i, "Name", Trim$(Classes(i).Name))
            PutVar(filename, "CLASS" & i, "Desc", Trim$(Classes(i).Desc))

            tmpstring = ""

            For x = 0 To UBound(Classes(i).MaleSprite)
                tmpstring = tmpstring & CStr(Classes(i).MaleSprite(x)) & ","
            Next

            PutVar(filename, "CLASS" & i, "MaleSprite", tmpstring.TrimEnd(","))

            tmpstring = ""

            For x = 0 To UBound(Classes(i).FemaleSprite)
                tmpstring = tmpstring & CStr(Classes(i).FemaleSprite(x)) & ","
            Next
            PutVar(filename, "CLASS" & i, "FemaleSprite", tmpstring.TrimEnd(","))

            tmpstring = ""

            PutVar(filename, "CLASS" & i, "Str", Str(Classes(i).Stat(Stats.strength)))
            PutVar(filename, "CLASS" & i, "End", Str(Classes(i).Stat(Stats.Endurance)))
            PutVar(filename, "CLASS" & i, "Vit", Str(Classes(i).Stat(Stats.Vitality)))
            PutVar(filename, "CLASS" & i, "Luck", Str(Classes(i).Stat(Stats.Luck)))
            PutVar(filename, "CLASS" & i, "Int", Str(Classes(i).Stat(Stats.intelligence)))
            PutVar(filename, "CLASS" & i, "Speed", Str(Classes(i).Stat(Stats.Speed)))
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

    Function GetClassMaxVital(ByVal ClassNum As Integer, ByVal Vital As Vitals) As Integer
        GetClassMaxVital = 0

        Select Case Vital
            Case Vitals.HP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.Vitality) \ 2) + Classes(ClassNum).Stat(Stats.Vitality)) * 2
            Case Vitals.MP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.intelligence) \ 2) + Classes(ClassNum).Stat(Stats.intelligence)) * 2
            Case Vitals.SP
                GetClassMaxVital = (1 + (Classes(ClassNum).Stat(Stats.Speed) \ 2) + Classes(ClassNum).Stat(Stats.Speed)) * 2
        End Select

    End Function

    Function GetClassName(ByVal ClassNum As Integer) As String
        GetClassName = Trim$(Classes(ClassNum).Name)
    End Function
#End Region

#Region "Maps"
    Sub CheckMaps()
        Dim i As Integer

        For i = 1 To MAX_MAPS
            If Not FileExist(Application.StartupPath & "\Data\maps\map" & i & ".dat") Then
                SaveMap(i)
                DoEvents()
            End If
        Next

    End Sub

    Sub ClearMaps()
        Dim i As Integer

        For i = 1 To MAX_CACHED_MAPS
            ClearMap(i)
            DoEvents()
        Next

    End Sub

    Sub ClearMap(ByVal MapNum As Integer)
        Dim x As Integer
        Dim y As Integer
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
            Next
        Next

        Map(MapNum).EventCount = 0
        ReDim Map(MapNum).Events(0)

        ' Reset the values for if a player is on the map or not
        PlayersOnMap(MapNum) = False
        Map(MapNum).Tileset = 1
        Map(MapNum).Name = ""
        Map(MapNum).Music = ""
        Map(MapNum).MaxX = MAX_MAPX
        Map(MapNum).MaxY = MAX_MAPY

        ClearTempTile(MapNum)
        ' Reset the map cache array for this map.
        'MapCache(MapNum).Data = Nothing
    End Sub

    Sub SaveMaps()
        Dim i As Integer

        For i = 1 To MAX_MAPS
            SaveMap(i)
            DoEvents()
        Next

    End Sub

    Sub SaveMap(ByVal MapNum As Integer)
        Dim filename As String
        Dim x As Integer, y As Integer, l As Integer

        filename = Application.StartupPath & "\data\maps\map" & MapNum & ".dat"
        Dim writer As New ArchaicIO.File.BinaryStream.Writer()
        writer.Write(Map(MapNum).Name)
        writer.Write(Map(MapNum).Music)
        writer.Write(Map(MapNum).Revision)
        writer.Write(Map(MapNum).Moral)
        writer.Write(Map(MapNum).Tileset)
        writer.Write(Map(MapNum).Up)
        writer.Write(Map(MapNum).Down)
        writer.Write(Map(MapNum).Left)
        writer.Write(Map(MapNum).Right)
        writer.Write(Map(MapNum).BootMap)
        writer.Write(Map(MapNum).BootX)
        writer.Write(Map(MapNum).BootY)
        writer.Write(Map(MapNum).MaxX)
        writer.Write(Map(MapNum).MaxY)
        writer.Write(Map(MapNum).WeatherType)
        writer.Write(Map(MapNum).FogIndex)
        writer.Write(Map(MapNum).WeatherIntensity)
        writer.Write(Map(MapNum).FogAlpha)
        writer.Write(Map(MapNum).FogSpeed)
        writer.Write(Map(MapNum).HasMapTint)
        writer.Write(Map(MapNum).MapTintR)
        writer.Write(Map(MapNum).MapTintG)
        writer.Write(Map(MapNum).MapTintB)
        writer.Write(Map(MapNum).MapTintA)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                writer.Write(Map(MapNum).Tile(x, y).Data1)
                writer.Write(Map(MapNum).Tile(x, y).Data2)
                writer.Write(Map(MapNum).Tile(x, y).Data3)
                writer.Write(Map(MapNum).Tile(x, y).DirBlock)
                For l = 0 To MapLayer.Count - 1
                    writer.Write(Map(MapNum).Tile(x, y).Layer(l).Tileset)
                    writer.Write(Map(MapNum).Tile(x, y).Layer(l).x)
                    writer.Write(Map(MapNum).Tile(x, y).Layer(l).y)
                    writer.Write(Map(MapNum).Tile(x, y).Layer(l).AutoTile)
                Next
                writer.Write(Map(MapNum).Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            writer.Write(Map(MapNum).Npc(x))
        Next

        writer.Save(filename)

        SaveMapEvent(MapNum)
    End Sub

    Sub SaveMapEvent(ByVal MapNum As Integer)

        'This is for event saving, it is in .ini files because there are non-limited values (strings) that cannot easily be loaded/saved in the normal manner.
        Dim filename = Application.StartupPath & "\data\maps\map" & MapNum & "_eventdata.dat"
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

    Sub LoadMapEvent(ByVal MapNum As Integer)
        Dim filename = Application.StartupPath & "\data\maps\map" & MapNum & "_eventdata.dat"
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

    Sub LoadMaps()
        Dim i As Integer

        CheckMaps()

        For i = 1 To MAX_MAPS
            LoadMap(i)
            DoEvents()
        Next

    End Sub

    Sub LoadMap(ByVal MapNum As Integer)
        Dim filename As String
        Dim x As Integer
        Dim y As Integer
        Dim l As Integer

        filename = Application.StartupPath & "\data\maps\map" & MapNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Map(MapNum).Name)
        reader.Read(Map(MapNum).Music)
        reader.Read(Map(MapNum).Revision)
        reader.Read(Map(MapNum).Moral)
        reader.Read(Map(MapNum).Tileset)
        reader.Read(Map(MapNum).Up)
        reader.Read(Map(MapNum).Down)
        reader.Read(Map(MapNum).Left)
        reader.Read(Map(MapNum).Right)
        reader.Read(Map(MapNum).BootMap)
        reader.Read(Map(MapNum).BootX)
        reader.Read(Map(MapNum).BootY)
        reader.Read(Map(MapNum).MaxX)
        reader.Read(Map(MapNum).MaxY)
        reader.Read(Map(MapNum).WeatherType)
        reader.Read(Map(MapNum).FogIndex)
        reader.Read(Map(MapNum).WeatherIntensity)
        reader.Read(Map(MapNum).FogAlpha)
        reader.Read(Map(MapNum).FogSpeed)
        reader.Read(Map(MapNum).HasMapTint)
        reader.Read(Map(MapNum).MapTintR)
        reader.Read(Map(MapNum).MapTintG)
        reader.Read(Map(MapNum).MapTintB)
        reader.Read(Map(MapNum).MapTintA)

        ' have to set the tile()
        ReDim Map(MapNum).Tile(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                reader.Read(Map(MapNum).Tile(x, y).Data1)
                reader.Read(Map(MapNum).Tile(x, y).Data2)
                reader.Read(Map(MapNum).Tile(x, y).Data3)
                reader.Read(Map(MapNum).Tile(x, y).DirBlock)
                ReDim Map(MapNum).Tile(x, y).Layer(0 To MapLayer.Count - 1)
                For l = 0 To MapLayer.Count - 1
                    reader.Read(Map(MapNum).Tile(x, y).Layer(l).Tileset)
                    reader.Read(Map(MapNum).Tile(x, y).Layer(l).x)
                    reader.Read(Map(MapNum).Tile(x, y).Layer(l).y)
                    reader.Read(Map(MapNum).Tile(x, y).Layer(l).AutoTile)
                Next
                reader.Read(Map(MapNum).Tile(x, y).Type)
            Next
        Next

        For x = 1 To MAX_MAP_NPCS
            reader.Read(Map(MapNum).Npc(x))
            MapNpc(MapNum).Npc(x).Num = Map(MapNum).Npc(x)
        Next

        reader = Nothing

        ClearTempTile(MapNum)
        CacheResources(MapNum)

        If Map(MapNum).Name Is Nothing Then Map(MapNum).Name = ""
        If Map(MapNum).Music Is Nothing Then Map(MapNum).Music = ""

        LoadMapEvent(MapNum)
    End Sub

    Sub ClearTempTiles()
        Dim i As Integer

        ReDim TempTile(MAX_CACHED_MAPS)

        For i = 1 To MAX_CACHED_MAPS
            ClearTempTile(i)
        Next

    End Sub

    Sub ClearTempTile(ByVal MapNum As Integer)
        Dim y As Integer
        Dim x As Integer
        TempTile(MapNum).DoorTimer = 0
        ReDim TempTile(MapNum).DoorOpen(0 To Map(MapNum).MaxX, 0 To Map(MapNum).MaxY)

        For x = 0 To Map(MapNum).MaxX
            For y = 0 To Map(MapNum).MaxY
                TempTile(MapNum).DoorOpen(x, y) = False
            Next
        Next

    End Sub

    Sub ClearMapItem(ByVal Index As Integer, ByVal MapNum As Integer)
        MapItem(MapNum, Index) = Nothing
        MapItem(MapNum, Index).RandData.Prefix = ""
        MapItem(MapNum, Index).RandData.Suffix = ""
    End Sub

    Sub ClearMapItems()
        Dim x As Integer
        Dim y As Integer

        For y = 1 To MAX_CACHED_MAPS
            For x = 1 To MAX_MAP_ITEMS
                ClearMapItem(x, y)
            Next
        Next

    End Sub

#End Region

#Region "Items"
    Sub SaveItems()
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            SaveItem(i)
            DoEvents()
        Next

    End Sub

    Sub SaveItem(ByVal itemNum As Integer)
        Dim filename As String
        filename = Application.StartupPath & "\data\items\item" & itemNum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()
        writer.Write(Item(itemNum).Name)
        writer.Write(Item(itemNum).Pic)
        writer.Write(Item(itemNum).Description)

        writer.Write(Item(itemNum).Type)
        writer.Write(Item(itemNum).SubType)
        writer.Write(Item(itemNum).Data1)
        writer.Write(Item(itemNum).Data2)
        writer.Write(Item(itemNum).Data3)
        writer.Write(Item(itemNum).ClassReq)
        writer.Write(Item(itemNum).AccessReq)
        writer.Write(Item(itemNum).LevelReq)
        writer.Write(Item(itemNum).Mastery)
        writer.Write(Item(itemNum).price)

        For i = 0 To Stats.Count - 1
            writer.Write(Item(itemNum).Add_Stat(i))
        Next

        writer.Write(Item(itemNum).Rarity)
        writer.Write(Item(itemNum).Speed)
        writer.Write(Item(itemNum).TwoHanded)
        writer.Write(Item(itemNum).BindType)

        For i = 0 To Stats.Count - 1
            writer.Write(Item(itemNum).Stat_Req(i))
        Next

        writer.Write(Item(itemNum).Animation)
        writer.Write(Item(itemNum).Paperdoll)

        'Housing
        writer.Write(Item(itemNum).FurnitureWidth)
        writer.Write(Item(itemNum).FurnitureHeight)

        For a = 1 To 3
            For b = 1 To 3
                writer.Write(Item(itemNum).FurnitureBlocks(a, b))
                writer.Write(Item(itemNum).FurnitureFringe(a, b))
            Next
        Next

        writer.Write(Item(itemNum).KnockBack)
        writer.Write(Item(itemNum).KnockBackTiles)

        writer.Write(Item(itemNum).Randomize)
        writer.Write(Item(itemNum).RandomMin)
        writer.Write(Item(itemNum).RandomMax)

        writer.Write(Item(itemNum).Stackable)

        writer.Write(Item(itemNum).ItemLevel)

        writer.Save(filename)
    End Sub

    Sub LoadItems()
        Dim i As Integer

        CheckItems()

        For i = 1 To MAX_ITEMS
            LoadItem(i)
            DoEvents()
        Next
        'SaveItems()
    End Sub

    Sub LoadItem(ByVal ItemNum As Integer)
        Dim filename As String
        Dim F As Integer
        Dim s As Integer

        filename = Application.StartupPath & "\data\Items\Item" & ItemNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Item(ItemNum).Name)
        reader.Read(Item(ItemNum).Pic)
        reader.Read(Item(ItemNum).Description)

        reader.Read(Item(ItemNum).Type)
        reader.Read(Item(ItemNum).SubType)
        reader.Read(Item(ItemNum).Data1)
        reader.Read(Item(ItemNum).Data2)
        reader.Read(Item(ItemNum).Data3)
        reader.Read(Item(ItemNum).ClassReq)
        reader.Read(Item(ItemNum).AccessReq)
        reader.Read(Item(ItemNum).LevelReq)
        reader.Read(Item(ItemNum).Mastery)
        reader.Read(Item(ItemNum).price)

        For s = 0 To Stats.Count - 1
            reader.Read(Item(ItemNum).Add_Stat(s))
        Next

        reader.Read(Item(ItemNum).Rarity)
        reader.Read(Item(ItemNum).Speed)
        reader.Read(Item(ItemNum).TwoHanded)
        reader.Read(Item(ItemNum).BindType)

        For s = 0 To Stats.Count - 1
            reader.Read(Item(ItemNum).Stat_Req(s))
        Next

        reader.Read(Item(ItemNum).Animation)
        reader.Read(Item(ItemNum).Paperdoll)

        'Housing
        reader.Read(Item(ItemNum).FurnitureWidth)
        reader.Read(Item(ItemNum).FurnitureHeight)

        For a = 1 To 3
            For b = 1 To 3
                reader.Read(Item(ItemNum).FurnitureBlocks(a, b))
                reader.Read(Item(ItemNum).FurnitureFringe(a, b))
            Next
        Next

        reader.Read(Item(ItemNum).KnockBack)
        reader.Read(Item(ItemNum).KnockBackTiles)

        reader.Read(Item(ItemNum).Randomize)
        reader.Read(Item(ItemNum).RandomMin)
        reader.Read(Item(ItemNum).RandomMax)

        reader.Read(Item(ItemNum).Stackable)

        reader.Read(Item(ItemNum).ItemLevel)

        FileClose(F)

    End Sub

    Sub CheckItems()
        Dim i As Integer

        For i = 1 To MAX_ITEMS

            If Not FileExist(Application.StartupPath & "\Data\Items\Item" & i & ".dat") Then
                SaveItem(i)
            End If

        Next

    End Sub

    Sub ClearItem(ByVal Index As Integer)
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
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next

    End Sub

#End Region

#Region "Npc's"
    Sub SaveNpcs()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            SaveNpc(i)
            DoEvents()
        Next

    End Sub

    Sub SaveNpc(ByVal NpcNum As Integer)
        Dim filename As String
        Dim i As Integer
        filename = Application.StartupPath & "\data\npcs\npc" & NpcNum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()
        writer.Write(Npc(NpcNum).Name)
        writer.Write(Npc(NpcNum).AttackSay)
        writer.Write(Npc(NpcNum).Sprite)
        writer.Write(Npc(NpcNum).SpawnSecs)
        writer.Write(Npc(NpcNum).Behaviour)
        writer.Write(Npc(NpcNum).Range)

        For i = 1 To 5
            writer.Write(Npc(NpcNum).DropChance(i))
            writer.Write(Npc(NpcNum).DropItem(i))
            writer.Write(Npc(NpcNum).DropItemValue(i))
        Next

        For i = 0 To Stats.Count - 1
            writer.Write(Npc(NpcNum).Stat(i))
        Next

        writer.Write(Npc(NpcNum).Faction)
        writer.Write(Npc(NpcNum).HP)
        writer.Write(Npc(NpcNum).Exp)
        writer.Write(Npc(NpcNum).Animation)

        writer.Write(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            writer.Write(Npc(NpcNum).Skill(i))
        Next

        writer.Save(filename)
    End Sub

    Sub LoadNpcs()
        Dim i As Integer

        CheckNpcs()

        For i = 1 To MAX_NPCS
            LoadNpc(i)
            DoEvents()
        Next

    End Sub

    Sub LoadNpc(ByVal NpcNum As Integer)
        Dim filename As String
        Dim n As Integer

        filename = Application.StartupPath & "\data\npcs\npc" & NpcNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Npc(NpcNum).Name)
        reader.Read(Npc(NpcNum).AttackSay)
        reader.Read(Npc(NpcNum).Sprite)
        reader.Read(Npc(NpcNum).SpawnSecs)
        reader.Read(Npc(NpcNum).Behaviour)
        reader.Read(Npc(NpcNum).Range)

        For i = 1 To 5
            reader.Read(Npc(NpcNum).DropChance(i))
            reader.Read(Npc(NpcNum).DropItem(i))
            reader.Read(Npc(NpcNum).DropItemValue(i))
        Next

        For n = 0 To Stats.Count - 1
            reader.Read(Npc(NpcNum).Stat(n))
        Next

        reader.Read(Npc(NpcNum).Faction)
        reader.Read(Npc(NpcNum).HP)
        reader.Read(Npc(NpcNum).Exp)
        reader.Read(Npc(NpcNum).Animation)

        reader.Read(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            reader.Read(Npc(NpcNum).Skill(i))
        Next

        If Npc(NpcNum).Name Is Nothing Then Npc(NpcNum).Name = ""
        If Npc(NpcNum).AttackSay Is Nothing Then Npc(NpcNum).AttackSay = ""
    End Sub

    Sub CheckNpcs()
        Dim i As Integer

        For i = 1 To MAX_NPCS

            If Not FileExist(Application.StartupPath & "\Data\npcs\npc" & i & ".dat") Then
                SaveNpc(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearMapNpc(ByVal Index As Integer, ByVal MapNum As Integer)
        MapNpc(MapNum).Npc(Index) = Nothing

        ReDim MapNpc(MapNum).Npc(Index).Vital(0 To Vitals.Count)
        ReDim MapNpc(MapNum).Npc(Index).SkillCD(MAX_NPC_SKILLS)
    End Sub

    Sub ClearMapNpcs()
        Dim x As Integer
        Dim y As Integer

        For y = 1 To MAX_CACHED_MAPS
            For x = 1 To MAX_MAP_NPCS
                ClearMapNpc(x, y)
                DoEvents()
            Next
        Next

    End Sub

    Sub ClearNpc(ByVal Index As Integer)
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
        Dim i As Integer

        For i = 1 To MAX_NPCS
            ClearNpc(i)
            DoEvents()
        Next

    End Sub

#End Region

#Region "Resources"
    Sub SaveResources()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES
            SaveResource(i)
            DoEvents()
        Next

    End Sub

    Sub SaveResource(ByVal ResourceNum As Integer)
        Dim filename As String

        filename = Application.StartupPath & "\data\resources\resource" & ResourceNum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Resource(ResourceNum).Name)
        writer.Write(Resource(ResourceNum).SuccessMessage)
        writer.Write(Resource(ResourceNum).EmptyMessage)
        writer.Write(Resource(ResourceNum).ResourceType)
        writer.Write(Resource(ResourceNum).ResourceImage)
        writer.Write(Resource(ResourceNum).ExhaustedImage)
        writer.Write(Resource(ResourceNum).ExpReward)
        writer.Write(Resource(ResourceNum).ItemReward)
        writer.Write(Resource(ResourceNum).LvlRequired)
        writer.Write(Resource(ResourceNum).ToolRequired)
        writer.Write(Resource(ResourceNum).Health)
        writer.Write(Resource(ResourceNum).RespawnTime)
        writer.Write(Resource(ResourceNum).Walkthrough)
        writer.Write(Resource(ResourceNum).Animation)

        writer.Save(filename)
    End Sub

    Sub LoadResources()
        Dim i As Integer

        Call CheckResources()

        For i = 1 To MAX_RESOURCES
            LoadResource(i)
            DoEvents()
        Next

    End Sub

    Sub LoadResource(ByVal ResourceNum As Integer)
        Dim filename As String

        filename = Application.StartupPath & "\data\resources\resource" & ResourceNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Resource(ResourceNum).Name)
        reader.Read(Resource(ResourceNum).SuccessMessage)
        reader.Read(Resource(ResourceNum).EmptyMessage)
        reader.Read(Resource(ResourceNum).ResourceType)
        reader.Read(Resource(ResourceNum).ResourceImage)
        reader.Read(Resource(ResourceNum).ExhaustedImage)
        reader.Read(Resource(ResourceNum).ExpReward)
        reader.Read(Resource(ResourceNum).ItemReward)
        reader.Read(Resource(ResourceNum).LvlRequired)
        reader.Read(Resource(ResourceNum).ToolRequired)
        reader.Read(Resource(ResourceNum).Health)
        reader.Read(Resource(ResourceNum).RespawnTime)
        reader.Read(Resource(ResourceNum).Walkthrough)
        reader.Read(Resource(ResourceNum).Animation)

        If Resource(ResourceNum).Name Is Nothing Then Resource(ResourceNum).Name = ""
        If Resource(ResourceNum).EmptyMessage Is Nothing Then Resource(ResourceNum).EmptyMessage = ""
        If Resource(ResourceNum).SuccessMessage Is Nothing Then Resource(ResourceNum).SuccessMessage = ""

    End Sub

    Sub CheckResources()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES

            If Not FileExist(Application.StartupPath & "\Data\Resources\Resource" & i & ".dat") Then
                SaveResource(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearResource(ByVal Index As Integer)
        Resource(Index) = Nothing
        Resource(Index).Name = ""
        Resource(Index).EmptyMessage = ""
        Resource(Index).SuccessMessage = ""
    End Sub

    Sub ClearResources()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES
            ClearResource(i)
            DoEvents()
        Next
    End Sub

    Public Sub CacheResources(ByVal MapNum As Integer)
        Dim x As Integer, y As Integer, Resource_Count As Integer
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
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            SaveShop(i)
            DoEvents()
        Next

    End Sub

    Sub SaveShop(ByVal shopNum As Integer)
        Dim i As Integer
        Dim filename As String

        filename = Application.StartupPath & "\data\shops\shop" & shopNum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Shop(shopNum).Name)
        writer.Write(Shop(shopNum).Face)
        writer.Write(Shop(shopNum).BuyRate)

        For i = 1 To MAX_TRADES
            writer.Write(Shop(shopNum).TradeItem(i).Item)
            writer.Write(Shop(shopNum).TradeItem(i).ItemValue)
            writer.Write(Shop(shopNum).TradeItem(i).costitem)
            writer.Write(Shop(shopNum).TradeItem(i).costvalue)
        Next

        writer.Save(filename)
    End Sub

    Sub LoadShops()

        Dim i As Integer

        CheckShops()

        For i = 1 To MAX_SHOPS
            LoadShop(i)
            DoEvents()
        Next

    End Sub

    Sub LoadShop(ByVal ShopNum As Integer)
        Dim filename As String
        Dim x As Integer

        filename = Application.StartupPath & "\data\shops\shop" & ShopNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Shop(ShopNum).Name)
        reader.Read(Shop(ShopNum).Face)
        reader.Read(Shop(ShopNum).BuyRate)

        For x = 1 To MAX_TRADES
            reader.Read(Shop(ShopNum).TradeItem(x).Item)
            reader.Read(Shop(ShopNum).TradeItem(x).ItemValue)
            reader.Read(Shop(ShopNum).TradeItem(x).costitem)
            reader.Read(Shop(ShopNum).TradeItem(x).costvalue)
        Next

    End Sub

    Sub CheckShops()
        Dim i As Integer

        For i = 1 To MAX_SHOPS

            If Not FileExist(Application.StartupPath & "\Data\shops\shop" & i & ".dat") Then
                SaveShop(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearShop(ByVal Index As Integer)
        Dim i As Integer

        Shop(Index) = Nothing
        Shop(Index).Name = ""

        ReDim Shop(Index).TradeItem(MAX_TRADES)
        For i = 0 To MAX_SHOPS
            ReDim Shop(i).TradeItem(0 To MAX_TRADES)
        Next

    End Sub

    Sub ClearShops()
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            Call ClearShop(i)
        Next

    End Sub

#End Region

#Region "Skills"
    Sub SaveSkills()
        Dim i As Integer
        SetStatus("Saving skills... ")

        For i = 1 To MAX_SKILLS
            SaveSkill(i)
            DoEvents()
        Next

    End Sub

    Sub SaveSkill(ByVal skillnum As Integer)
        Dim filename As String
        filename = Application.StartupPath & "\data\skills\skills" & skillnum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Skill(skillnum).Name)
        writer.Write(Skill(skillnum).Type)
        writer.Write(Skill(skillnum).MPCost)
        writer.Write(Skill(skillnum).LevelReq)
        writer.Write(Skill(skillnum).AccessReq)
        writer.Write(Skill(skillnum).ClassReq)
        writer.Write(Skill(skillnum).CastTime)
        writer.Write(Skill(skillnum).CDTime)
        writer.Write(Skill(skillnum).Icon)
        writer.Write(Skill(skillnum).Map)
        writer.Write(Skill(skillnum).x)
        writer.Write(Skill(skillnum).y)
        writer.Write(Skill(skillnum).Dir)
        writer.Write(Skill(skillnum).Vital)
        writer.Write(Skill(skillnum).Duration)
        writer.Write(Skill(skillnum).Interval)
        writer.Write(Skill(skillnum).range)
        writer.Write(Skill(skillnum).IsAoE)
        writer.Write(Skill(skillnum).AoE)
        writer.Write(Skill(skillnum).CastAnim)
        writer.Write(Skill(skillnum).SkillAnim)
        writer.Write(Skill(skillnum).StunDuration)

        writer.Write(Skill(skillnum).IsProjectile)
        writer.Write(Skill(skillnum).Projectile)

        writer.Write(Skill(skillnum).KnockBack)
        writer.Write(Skill(skillnum).KnockBackTiles)

        writer.Save(filename)
    End Sub

    Sub LoadSkills()
        Dim i As Integer

        CheckSkills()

        For i = 1 To MAX_SKILLS
            LoadSkill(i)
            DoEvents()
        Next

    End Sub

    Sub LoadSkill(ByVal SkillNum As Integer)
        Dim filename As String

        filename = Application.StartupPath & "\data\skills\skills" & SkillNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Skill(SkillNum).Name)
        reader.Read(Skill(SkillNum).Type)
        reader.Read(Skill(SkillNum).MPCost)
        reader.Read(Skill(SkillNum).LevelReq)
        reader.Read(Skill(SkillNum).AccessReq)
        reader.Read(Skill(SkillNum).ClassReq)
        reader.Read(Skill(SkillNum).CastTime)
        reader.Read(Skill(SkillNum).CDTime)
        reader.Read(Skill(SkillNum).Icon)
        reader.Read(Skill(SkillNum).Map)
        reader.Read(Skill(SkillNum).x)
        reader.Read(Skill(SkillNum).y)
        reader.Read(Skill(SkillNum).Dir)
        reader.Read(Skill(SkillNum).Vital)
        reader.Read(Skill(SkillNum).Duration)
        reader.Read(Skill(SkillNum).Interval)
        reader.Read(Skill(SkillNum).range)
        reader.Read(Skill(SkillNum).IsAoE)
        reader.Read(Skill(SkillNum).AoE)
        reader.Read(Skill(SkillNum).CastAnim)
        reader.Read(Skill(SkillNum).SkillAnim)
        reader.Read(Skill(SkillNum).StunDuration)

        reader.Read(Skill(SkillNum).IsProjectile)
        reader.Read(Skill(SkillNum).Projectile)

        reader.Read(Skill(SkillNum).KnockBack)
        reader.Read(Skill(SkillNum).KnockBackTiles)

    End Sub

    Sub CheckSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS

            If Not FileExist(Application.StartupPath & "\Data\skills\skills" & i & ".dat") Then
                SaveSkill(i)
                DoEvents()
            End If

        Next

    End Sub

    Sub ClearSkill(ByVal Index As Integer)
        Skill(Index) = Nothing
        Skill(Index).Name = ""
        Skill(Index).LevelReq = 1 'Needs to be 1 for the skill editor
    End Sub

    Sub ClearSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            ClearSkill(i)
            DoEvents()
        Next

    End Sub

#End Region

#Region "Animations"
    Sub SaveAnimations()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS
            SaveAnimation(i)
            DoEvents()
        Next

    End Sub

    Sub SaveAnimation(ByVal AnimationNum As Integer)
        Dim filename As String
        Dim x As Integer

        filename = Application.StartupPath & "\data\animations\animation" & AnimationNum & ".dat"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Animation(AnimationNum).Name)

        For x = 0 To UBound(Animation(AnimationNum).Sprite)
            writer.Write(Animation(AnimationNum).Sprite(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).Frames)
            writer.Write(Animation(AnimationNum).Frames(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopCount)
            writer.Write(Animation(AnimationNum).LoopCount(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopTime)
            writer.Write(Animation(AnimationNum).LoopTime(x))
        Next

        writer.Save(filename)
    End Sub

    Sub LoadAnimations()
        Dim i As Integer

        Call CheckAnimations()

        For i = 1 To MAX_ANIMATIONS
            LoadAnimation(i)
            DoEvents()
        Next

    End Sub

    Sub LoadAnimation(ByVal AnimationNum As Integer)
        Dim filename As String

        filename = Application.StartupPath & "\data\animations\animation" & AnimationNum & ".dat"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Animation(AnimationNum).Name)

        For x = 0 To UBound(Animation(AnimationNum).Sprite)
            reader.Read(Animation(AnimationNum).Sprite(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).Frames)
            reader.Read(Animation(AnimationNum).Frames(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopCount)
            reader.Read(Animation(AnimationNum).LoopCount(x))
        Next

        For x = 0 To UBound(Animation(AnimationNum).LoopTime)
            reader.Read(Animation(AnimationNum).LoopTime(x))
        Next

        If Animation(AnimationNum).Name Is Nothing Then Animation(AnimationNum).Name = ""
    End Sub

    Sub CheckAnimations()
        Dim i As Integer

        For i = 1 To MAX_ANIMATIONS

            If Not FileExist(Application.StartupPath & "\Data\animations\animation" & i & ".dat") Then
                SaveAnimation(i)
                DoEvents()
            End If

        Next
    End Sub

    Sub ClearAnimation(ByVal Index As Integer)
        Animation(Index) = Nothing
        Animation(Index).Name = ""
        ReDim Animation(Index).Sprite(0 To 1)
        ReDim Animation(Index).Frames(0 To 1)
        ReDim Animation(Index).LoopCount(0 To 1)
        ReDim Animation(Index).LoopTime(0 To 1)
    End Sub

    Sub ClearAnimations()
        Dim i As Integer

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

        RightPassword = ""
        namecheck = ""
        PasswordOK = False

        If AccountExist(Name) Then
            filename = Application.StartupPath & "\data\accounts\" & Trim$(Name) & "\" & Trim$(Name) & ".bin"
            Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)
            reader.Read(namecheck)
            reader.Read(RightPassword)

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

    Sub AddAccount(ByVal Index As Integer, ByVal Name As String, ByVal Password As String)
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
        Dim i As Integer

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                SavePlayer(i)
                SaveBank(i)
                DoEvents()
            End If
        Next

    End Sub

    Sub SavePlayer(ByVal Index As Integer)
        Dim filename As String

        CheckDir(Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login))

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & "\" & Trim$(Player(Index).Login) & ".bin"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Player(Index).Login)
        writer.Write(Player(Index).Password)
        writer.Write(Player(Index).Access)

        writer.Save(filename)

        For i = 1 To MAX_CHARS
            SaveCharacter(Index, i)
        Next

    End Sub

    Sub LoadPlayer(ByVal Index As Integer, ByVal Name As String)
        Dim filename As String

        ClearPlayer(Index)

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Name) & "\" & Trim$(Name) & ".bin"
        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Player(Index).Login)
        reader.Read(Player(Index).Password)
        reader.Read(Player(Index).Access)

        For i = 1 To MAX_CHARS
            LoadCharacter(Index, i)
        Next

    End Sub

    Sub ClearPlayer(ByVal Index As Integer)
        Dim i As Integer

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
    Public Sub LoadBank(ByVal Index As Integer, ByVal Name As String)
        Dim filename As String

        ClearBank(Index)

        filename = Application.StartupPath & "\data\banks\" & Trim$(Name) & ".bin"

        If Not FileExist(filename) Then
            SaveBank(Index)
            Exit Sub
        End If

        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        For i = 0 To MAX_BANK
            reader.Read(Bank(Index).Item(i).Num)
            reader.Read(Bank(Index).Item(i).Value)
        Next
    End Sub

    Sub SaveBank(ByVal Index As Integer)
        Dim filename As String

        filename = Application.StartupPath & "\data\banks\" & Trim$(Player(Index).Login) & ".bin"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        For i = 0 To MAX_BANK
            writer.Write(Bank(Index).Item(i).Num)
            writer.Write(Bank(Index).Item(i).Value)
        Next

        writer.Save(filename)
    End Sub

    Sub ClearBank(ByVal Index As Integer)
        ReDim Bank(Index).Item(MAX_BANK)

        For i = 0 To MAX_BANK

            Bank(Index).Item(i).Num = 0
            Bank(Index).Item(i).Value = 0

        Next
    End Sub

#End Region

#Region "Characters"
    Sub ClearCharacter(ByVal Index As Integer, ByVal CharNum As Integer)
        Player(Index).Character(CharNum).Classes = 0
        Player(Index).Character(CharNum).Dir = 0

        For i = 0 To EquipmentType.Count - 1
            Player(Index).Character(CharNum).Equipment(i) = 0

            Player(Index).Character(CharNum).RandEquip(i).Prefix = ""
            Player(Index).Character(CharNum).RandEquip(i).Suffix = ""
            Player(Index).Character(CharNum).RandEquip(i).Rarity = 0
            Player(Index).Character(CharNum).RandEquip(i).Damage = 0
            Player(Index).Character(CharNum).RandEquip(i).Speed = 0

            ReDim Player(Index).Character(CharNum).RandEquip(i).Stat(Stats.Count - 1)
            For x = 1 To Stats.Count - 1
                Player(Index).Character(CharNum).RandEquip(i).Stat(x) = 0
            Next
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

        'random items
        ReDim Player(Index).Character(CharNum).RandInv(MAX_INV)
        For i = 1 To MAX_INV
            Player(Index).Character(CharNum).RandInv(i).Prefix = ""
            Player(Index).Character(CharNum).RandInv(i).Suffix = ""
            Player(Index).Character(CharNum).RandInv(i).Rarity = 0
            Player(Index).Character(CharNum).RandInv(i).Damage = 0
            Player(Index).Character(CharNum).RandInv(i).Speed = 0

            ReDim Player(Index).Character(CharNum).RandInv(i).Stat(Stats.Count - 1)
            For x = 1 To Stats.Count - 1
                Player(Index).Character(CharNum).RandInv(i).Stat(x) = 0
            Next
        Next

        ReDim Player(Index).Character(CharNum).RandEquip(EquipmentType.Count - 1)
        For i = 1 To EquipmentType.Count - 1
            Player(Index).Character(CharNum).RandEquip(i).Prefix = ""
            Player(Index).Character(CharNum).RandEquip(i).Suffix = ""
            Player(Index).Character(CharNum).RandEquip(i).Rarity = 0
            Player(Index).Character(CharNum).RandEquip(i).Damage = 0
            Player(Index).Character(CharNum).RandEquip(i).Speed = 0

            ReDim Player(Index).Character(CharNum).RandEquip(i).Stat(Stats.Count - 1)
            For x = 1 To Stats.Count - 1
                Player(Index).Character(CharNum).RandEquip(i).Stat(x) = 0
            Next
        Next
    End Sub

    Sub LoadCharacter(ByVal Index As Integer, ByVal CharNum As Integer)
        Dim filename As String

        ClearCharacter(Index, CharNum)

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & "\" & CharNum & ".bin"

        Dim reader As New ArchaicIO.File.BinaryStream.Reader(filename)

        reader.Read(Player(Index).Character(CharNum).Classes)
        reader.Read(Player(Index).Character(CharNum).Dir)

        For i = 1 To EquipmentType.Count - 1
            reader.Read(Player(Index).Character(CharNum).Equipment(i))
        Next

        reader.Read(Player(Index).Character(CharNum).exp)

        For i = 0 To MAX_INV
            reader.Read(Player(Index).Character(CharNum).Inv(i).Num)
            reader.Read(Player(Index).Character(CharNum).Inv(i).Value)
        Next

        reader.Read(Player(Index).Character(CharNum).Level)
        reader.Read(Player(Index).Character(CharNum).Map)
        reader.Read(Player(Index).Character(CharNum).Name)
        reader.Read(Player(Index).Character(CharNum).PK)
        reader.Read(Player(Index).Character(CharNum).POINTS)
        reader.Read(Player(Index).Character(CharNum).Sex)

        For i = 0 To MAX_PLAYER_SKILLS
            reader.Read(Player(Index).Character(CharNum).Skill(i))
        Next

        reader.Read(Player(Index).Character(CharNum).Sprite)

        For i = 0 To Stats.Count - 1
            reader.Read(Player(Index).Character(CharNum).Stat(i))
        Next

        For i = 0 To Vitals.Count - 1
            reader.Read(Player(Index).Character(CharNum).Vital(i))
        Next

        reader.Read(Player(Index).Character(CharNum).x)
        reader.Read(Player(Index).Character(CharNum).y)

        For i = 1 To MAX_QUESTS
            reader.Read(Player(Index).Character(CharNum).PlayerQuest(i).Status)
            reader.Read(Player(Index).Character(CharNum).PlayerQuest(i).ActualTask)
            reader.Read(Player(Index).Character(CharNum).PlayerQuest(i).CurrentCount)
        Next

        'Housing
        reader.Read(Player(Index).Character(CharNum).House.HouseIndex)
        reader.Read(Player(Index).Character(CharNum).House.FurnitureCount)
        ReDim Player(Index).Character(CharNum).House.Furniture(Player(Index).Character(CharNum).House.FurnitureCount)
        For i = 0 To Player(Index).Character(CharNum).House.FurnitureCount
            reader.Read(Player(Index).Character(CharNum).House.Furniture(i).ItemNum)
            reader.Read(Player(Index).Character(CharNum).House.Furniture(i).X)
            reader.Read(Player(Index).Character(CharNum).House.Furniture(i).Y)
        Next
        reader.Read(Player(Index).Character(CharNum).InHouse)
        reader.Read(Player(Index).Character(CharNum).LastMap)
        reader.Read(Player(Index).Character(CharNum).LastX)
        reader.Read(Player(Index).Character(CharNum).LastY)

        For i = 1 To MAX_HOTBAR
            reader.Read(Player(Index).Character(CharNum).Hotbar(i).Slot)
            reader.Read(Player(Index).Character(CharNum).Hotbar(i).sType)
        Next

        ReDim Player(Index).Character(CharNum).Switches(MAX_SWITCHES)
        For i = 1 To MAX_SWITCHES
            reader.Read(Player(Index).Character(CharNum).Switches(i))
        Next
        ReDim Player(Index).Character(CharNum).Variables(MAX_VARIABLES)
        For i = 1 To MAX_VARIABLES
            reader.Read(Player(Index).Character(CharNum).Variables(i))
        Next

        ReDim Player(Index).Character(CharNum).GatherSkills(ResourceSkills.Count - 1)
        For i = 0 To ResourceSkills.Count - 1
            reader.Read(Player(Index).Character(CharNum).GatherSkills(i).SkillLevel)
            reader.Read(Player(Index).Character(CharNum).GatherSkills(i).SkillCurExp)
            reader.Read(Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp)
            If Player(Index).Character(CharNum).GatherSkills(i).SkillLevel = 0 Then Player(Index).Character(CharNum).GatherSkills(i).SkillLevel = 1
            If Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 0 Then Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp = 100
        Next

        ReDim Player(Index).Character(CharNum).RecipeLearned(MAX_RECIPE)
        For i = 1 To MAX_RECIPE
            reader.Read(Player(Index).Character(CharNum).RecipeLearned(i))
        Next

        'random items
        ReDim Player(Index).Character(CharNum).RandInv(MAX_INV)
        For i = 1 To MAX_INV
            reader.Read(Player(Index).Character(CharNum).RandInv(i).Prefix)
            reader.Read(Player(Index).Character(CharNum).RandInv(i).Suffix)
            reader.Read(Player(Index).Character(CharNum).RandInv(i).Rarity)
            reader.Read(Player(Index).Character(CharNum).RandInv(i).Damage)
            reader.Read(Player(Index).Character(CharNum).RandInv(i).Speed)

            ReDim Player(Index).Character(CharNum).RandInv(i).Stat(Stats.Count - 1)
            For x = 1 To Stats.Count - 1
                reader.Read(Player(Index).Character(CharNum).RandInv(i).Stat(x))
            Next
        Next

        ReDim Player(Index).Character(CharNum).RandEquip(EquipmentType.Count - 1)
        For i = 1 To EquipmentType.Count - 1
            reader.Read(Player(Index).Character(CharNum).RandEquip(i).Prefix)
            reader.Read(Player(Index).Character(CharNum).RandEquip(i).Suffix)
            reader.Read(Player(Index).Character(CharNum).RandEquip(i).Rarity)
            reader.Read(Player(Index).Character(CharNum).RandEquip(i).Damage)
            reader.Read(Player(Index).Character(CharNum).RandEquip(i).Speed)

            ReDim Player(Index).Character(CharNum).RandEquip(i).Stat(Stats.Count - 1)
            For x = 1 To Stats.Count - 1
                reader.Read(Player(Index).Character(CharNum).RandEquip(i).Stat(x))
            Next
        Next
    End Sub

    Sub SaveCharacter(ByVal Index As Integer, ByVal CharNum As Integer)
        Dim filename As String

        filename = Application.StartupPath & "\data\accounts\" & Trim$(Player(Index).Login) & "\" & CharNum & ".bin"

        Dim writer As New ArchaicIO.File.BinaryStream.Writer()

        writer.Write(Player(Index).Character(CharNum).Classes)
        writer.Write(Player(Index).Character(CharNum).Dir)


        For i = 1 To EquipmentType.Count - 1
            writer.Write(Player(Index).Character(CharNum).Equipment(i))
        Next

        writer.Write(Player(Index).Character(CharNum).exp)

        For i = 0 To MAX_INV
            writer.Write(Player(Index).Character(CharNum).Inv(i).Num)
            writer.Write(Player(Index).Character(CharNum).Inv(i).Value)
        Next

        writer.Write(Player(Index).Character(CharNum).Level)
        writer.Write(Player(Index).Character(CharNum).Map)
        writer.Write(Player(Index).Character(CharNum).Name)
        writer.Write(Player(Index).Character(CharNum).PK)
        writer.Write(Player(Index).Character(CharNum).POINTS)
        writer.Write(Player(Index).Character(CharNum).Sex)

        For i = 0 To MAX_PLAYER_SKILLS
            writer.Write(Player(Index).Character(CharNum).Skill(i))
        Next

        writer.Write(Player(Index).Character(CharNum).Sprite)

        For i = 0 To Stats.Count - 1
            writer.Write(Player(Index).Character(CharNum).Stat(i))
        Next

        For i = 0 To Vitals.Count - 1
            writer.Write(Player(Index).Character(CharNum).Vital(i))
        Next

        writer.Write(Player(Index).Character(CharNum).x)
        writer.Write(Player(Index).Character(CharNum).y)

        For i = 1 To MAX_QUESTS
            writer.Write(Player(Index).Character(CharNum).PlayerQuest(i).Status)
            writer.Write(Player(Index).Character(CharNum).PlayerQuest(i).ActualTask)
            writer.Write(Player(Index).Character(CharNum).PlayerQuest(i).CurrentCount)
        Next

        'Housing
        writer.Write(Player(Index).Character(CharNum).House.HouseIndex)
        writer.Write(Player(Index).Character(CharNum).House.FurnitureCount)
        For i = 0 To Player(Index).Character(CharNum).House.FurnitureCount
            writer.Write(Player(Index).Character(CharNum).House.Furniture(i).ItemNum)
            writer.Write(Player(Index).Character(CharNum).House.Furniture(i).X)
            writer.Write(Player(Index).Character(CharNum).House.Furniture(i).Y)
        Next
        writer.Write(Player(Index).Character(CharNum).InHouse)
        writer.Write(Player(Index).Character(CharNum).LastMap)
        writer.Write(Player(Index).Character(CharNum).LastX)
        writer.Write(Player(Index).Character(CharNum).LastY)


        For i = 1 To MAX_HOTBAR
            writer.Write(Player(Index).Character(CharNum).Hotbar(i).Slot)
            writer.Write(Player(Index).Character(CharNum).Hotbar(i).sType)
        Next

        For i = 1 To MAX_SWITCHES
            writer.Write(Player(Index).Character(CharNum).Switches(i))
        Next

        For i = 1 To MAX_VARIABLES
            writer.Write(Player(Index).Character(CharNum).Variables(i))
        Next

        For i = 0 To ResourceSkills.Count - 1
            writer.Write(Player(Index).Character(CharNum).GatherSkills(i).SkillLevel)
            writer.Write(Player(Index).Character(CharNum).GatherSkills(i).SkillCurExp)
            writer.Write(Player(Index).Character(CharNum).GatherSkills(i).SkillNextLvlExp)
        Next

        For i = 1 To MAX_RECIPE
            writer.Write(Player(Index).Character(CharNum).RecipeLearned(i))
        Next

        'random items
        For i = 1 To MAX_INV
            writer.Write(Player(Index).Character(CharNum).RandInv(i).Prefix)
            writer.Write(Player(Index).Character(CharNum).RandInv(i).Suffix)
            writer.Write(Player(Index).Character(CharNum).RandInv(i).Rarity)
            writer.Write(Player(Index).Character(CharNum).RandInv(i).Damage)
            writer.Write(Player(Index).Character(CharNum).RandInv(i).Speed)
            For x = 1 To Stats.Count - 1
                writer.Write(Player(Index).Character(CharNum).RandInv(i).Stat(x))
            Next
        Next

        For i = 1 To EquipmentType.Count - 1
            writer.Write(Player(Index).Character(CharNum).RandEquip(i).Prefix)
            writer.Write(Player(Index).Character(CharNum).RandEquip(i).Suffix)
            writer.Write(Player(Index).Character(CharNum).RandEquip(i).Rarity)
            writer.Write(Player(Index).Character(CharNum).RandEquip(i).Damage)
            writer.Write(Player(Index).Character(CharNum).RandEquip(i).Speed)
            For x = 1 To Stats.Count - 1
                writer.Write(Player(Index).Character(CharNum).RandEquip(i).Stat(x))
            Next
        Next

        writer.Save(filename)
    End Sub

    Function CharExist(ByVal Index As Integer, ByVal CharNum As Integer) As Boolean

        If Len(Trim$(Player(Index).Character(CharNum).Name)) > 0 Then
            CharExist = True
        Else
            CharExist = False
        End If

    End Function

    Sub AddChar(ByVal Index As Integer, ByVal CharNum As Integer, ByVal Name As String, ByVal Sex As Byte, ByVal ClassNum As Byte, ByVal Sprite As Integer)
        Dim n As Integer, i As Integer
        Dim spritecheck As Boolean

        If Len(Trim$(Player(Index).Character(CharNum).Name)) = 0 Then

            spritecheck = False

            Player(Index).Character(CharNum).Name = Name
            Player(Index).Character(CharNum).Sex = Sex
            Player(Index).Character(CharNum).Classes = ClassNum

            If Player(Index).Character(CharNum).Sex = Enums.Sex.Male Then
                Player(Index).Character(CharNum).Sprite = Classes(ClassNum).MaleSprite(Sprite - 1)
            Else
                Player(Index).Character(CharNum).Sprite = Classes(ClassNum).FemaleSprite(Sprite - 1)
            End If

            Player(Index).Character(CharNum).Level = 1

            For n = 1 To Stats.Count - 1
                Player(Index).Character(CharNum).Stat(n) = Classes(ClassNum).Stat(n)
            Next n

            Player(Index).Character(CharNum).Dir = Direction.Down
            Player(Index).Character(CharNum).Map = Classes(ClassNum).StartMap
            Player(Index).Character(CharNum).x = Classes(ClassNum).StartX
            Player(Index).Character(CharNum).y = Classes(ClassNum).StartY
            Player(Index).Character(CharNum).Dir = Direction.Down
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

#Region "Banning"
    Sub ServerBanIndex(ByVal BanPlayerIndex As Integer)
        Dim filename As String
        Dim IP As String
        Dim F As Integer
        Dim i As Integer
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

    Sub BanIndex(ByVal BanPlayerIndex As Integer, ByVal BannedByIndex As Integer)
        Dim filename As String
        Dim IP As String
        Dim F As Integer
        Dim i As Integer
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
        Dim i As Integer, n As Integer, q As Integer
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(Max_Classes)

        For i = 1 To Max_Classes
            Buffer.WriteString(Trim$(GetClassName(i)))
            Buffer.WriteString(Trim(Classes(i).Desc))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.HP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.MP))
            Buffer.WriteInteger(GetClassMaxVital(i, Vitals.SP))

            ' set sprite array size
            n = UBound(Classes(i).MaleSprite)

            ' send array size
            Buffer.WriteInteger(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).MaleSprite(q))
            Next

            ' set sprite array size
            n = UBound(Classes(i).FemaleSprite)

            ' send array size
            Buffer.WriteInteger(n)

            ' loop around sending each sprite
            For q = 0 To n
                Buffer.WriteInteger(Classes(i).FemaleSprite(q))
            Next

            Buffer.WriteInteger(Classes(i).Stat(Stats.strength))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Endurance))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Vitality))
            Buffer.WriteInteger(Classes(i).Stat(Stats.intelligence))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Luck))
            Buffer.WriteInteger(Classes(i).Stat(Stats.Speed))

            For q = 1 To 5
                Buffer.WriteInteger(Classes(i).StartItem(q))
                Buffer.WriteInteger(Classes(i).StartValue(q))
            Next

            Buffer.WriteInteger(Classes(i).StartMap)
            Buffer.WriteInteger(Classes(i).StartX)
            Buffer.WriteInteger(Classes(i).StartY)

            Buffer.WriteInteger(Classes(i).BaseExp)
        Next

        Return Buffer.ToArray()
        Buffer = Nothing
    End Function

    Function ItemsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Integer
        buffer = New ByteBuffer

        For i = 1 To MAX_ITEMS

            If Len(Trim$(Item(i).Name)) > 0 Then
                buffer.WriteBytes(ItemData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing

    End Function

    Function ItemData(ByVal itemNum As Integer) As Byte()
        Dim Buffer As ByteBuffer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(itemNum)
        Buffer.WriteInteger(Item(itemNum).AccessReq)

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Item(itemNum).Add_Stat(i))
        Next

        Buffer.WriteInteger(Item(itemNum).Animation)
        Buffer.WriteInteger(Item(itemNum).BindType)
        Buffer.WriteInteger(Item(itemNum).ClassReq)
        Buffer.WriteInteger(Item(itemNum).Data1)
        Buffer.WriteInteger(Item(itemNum).Data2)
        Buffer.WriteInteger(Item(itemNum).Data3)
        Buffer.WriteInteger(Item(itemNum).TwoHanded)
        Buffer.WriteInteger(Item(itemNum).LevelReq)
        Buffer.WriteInteger(Item(itemNum).Mastery)
        Buffer.WriteString(Trim$(Item(itemNum).Name))
        Buffer.WriteInteger(Item(itemNum).Paperdoll)
        Buffer.WriteInteger(Item(itemNum).Pic)
        Buffer.WriteInteger(Item(itemNum).price)
        Buffer.WriteInteger(Item(itemNum).Rarity)
        Buffer.WriteInteger(Item(itemNum).Speed)

        Buffer.WriteInteger(Item(itemNum).Randomize)
        Buffer.WriteInteger(Item(itemNum).RandomMin)
        Buffer.WriteInteger(Item(itemNum).RandomMax)

        Buffer.WriteInteger(Item(itemNum).Stackable)
        Buffer.WriteString(Trim$(Item(itemNum).Description))

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Item(itemNum).Stat_Req(i))
        Next

        Buffer.WriteInteger(Item(itemNum).Type)
        Buffer.WriteInteger(Item(itemNum).SubType)

        'Housing
        Buffer.WriteInteger(Item(itemNum).FurnitureWidth)
        Buffer.WriteInteger(Item(itemNum).FurnitureHeight)

        For i = 1 To 3
            For x = 1 To 3
                Buffer.WriteInteger(Item(itemNum).FurnitureBlocks(i, x))
                Buffer.WriteInteger(Item(itemNum).FurnitureFringe(i, x))
            Next
        Next

        Buffer.WriteInteger(Item(itemNum).KnockBack)
        Buffer.WriteInteger(Item(itemNum).KnockBackTiles)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function AnimationsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Integer
        buffer = New ByteBuffer

        For i = 1 To MAX_ANIMATIONS

            If Len(Trim$(Animation(i).Name)) > 0 Then
                buffer.WriteBytes(AnimationData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function AnimationData(ByVal AnimationNum As Integer) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(AnimationNum)

        For i = 0 To UBound(Animation(AnimationNum).Frames)
            Buffer.WriteInteger(Animation(AnimationNum).Frames(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            Buffer.WriteInteger(Animation(AnimationNum).LoopCount(i))
        Next

        For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            Buffer.WriteInteger(Animation(AnimationNum).LoopTime(i))
        Next

        Buffer.WriteString(Animation(AnimationNum).Name)

        For i = 0 To UBound(Animation(AnimationNum).Sprite)
            Buffer.WriteInteger(Animation(AnimationNum).Sprite(i))
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function NpcsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Integer
        buffer = New ByteBuffer

        For i = 1 To MAX_NPCS

            If Len(Trim$(Npc(i).Name)) > 0 Then
                buffer.WriteBytes(NpcData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function NpcData(ByVal NpcNum As Integer) As Byte()
        Dim Buffer As ByteBuffer, i As Integer
        Buffer = New ByteBuffer
        Buffer.WriteInteger(NpcNum)
        Buffer.WriteInteger(Npc(NpcNum).Animation)
        Buffer.WriteString(Npc(NpcNum).AttackSay)
        Buffer.WriteInteger(Npc(NpcNum).Behaviour)

        For i = 1 To 5
            Buffer.WriteInteger(Npc(NpcNum).DropChance(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItem(i))
            Buffer.WriteInteger(Npc(NpcNum).DropItemValue(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).Exp)
        Buffer.WriteInteger(Npc(NpcNum).Faction)
        Buffer.WriteInteger(Npc(NpcNum).HP)
        Buffer.WriteString(Npc(NpcNum).Name)
        Buffer.WriteInteger(Npc(NpcNum).Range)
        Buffer.WriteInteger(Npc(NpcNum).SpawnSecs)
        Buffer.WriteInteger(Npc(NpcNum).Sprite)

        For i = 0 To Stats.Count - 1
            Buffer.WriteInteger(Npc(NpcNum).Stat(i))
        Next

        Buffer.WriteInteger(Npc(NpcNum).QuestNum)

        For i = 1 To MAX_NPC_SKILLS
            Buffer.WriteInteger(Npc(NpcNum).Skill(i))
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function ShopsData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Integer

        buffer = New ByteBuffer

        For i = 1 To MAX_SHOPS

            If Len(Trim$(Shop(i).Name)) > 0 Then
                buffer.WriteBytes(ShopData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function ShopData(ByVal shopNum As Integer) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(shopNum)
        Buffer.WriteInteger(Shop(shopNum).BuyRate)
        Buffer.WriteString(Shop(shopNum).Name)
        Buffer.WriteInteger(Shop(shopNum).Face)

        For i = 0 To MAX_TRADES
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).costitem)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).costvalue)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).Item)
            Buffer.WriteInteger(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function SkillsData() As Byte()
        Dim i As Integer
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

    Function SkillData(ByVal skillnum As Integer) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(skillnum)
        Buffer.WriteInteger(Skill(skillnum).AccessReq)
        Buffer.WriteInteger(Skill(skillnum).AoE)
        Buffer.WriteInteger(Skill(skillnum).CastAnim)
        Buffer.WriteInteger(Skill(skillnum).CastTime)
        Buffer.WriteInteger(Skill(skillnum).CDTime)
        Buffer.WriteInteger(Skill(skillnum).ClassReq)
        Buffer.WriteInteger(Skill(skillnum).Dir)
        Buffer.WriteInteger(Skill(skillnum).Duration)
        Buffer.WriteInteger(Skill(skillnum).Icon)
        Buffer.WriteInteger(Skill(skillnum).Interval)
        Buffer.WriteInteger(Skill(skillnum).IsAoE)
        Buffer.WriteInteger(Skill(skillnum).LevelReq)
        Buffer.WriteInteger(Skill(skillnum).Map)
        Buffer.WriteInteger(Skill(skillnum).MPCost)
        Buffer.WriteString(Skill(skillnum).Name)
        Buffer.WriteInteger(Skill(skillnum).range)
        Buffer.WriteInteger(Skill(skillnum).SkillAnim)
        Buffer.WriteInteger(Skill(skillnum).StunDuration)
        Buffer.WriteInteger(Skill(skillnum).Type)
        Buffer.WriteInteger(Skill(skillnum).Vital)
        Buffer.WriteInteger(Skill(skillnum).x)
        Buffer.WriteInteger(Skill(skillnum).y)

        Buffer.WriteInteger(Skill(skillnum).IsProjectile)
        Buffer.WriteInteger(Skill(skillnum).Projectile)

        Buffer.WriteInteger(Skill(skillnum).KnockBack)
        Buffer.WriteInteger(Skill(skillnum).KnockBackTiles)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

    Function ResourcesData() As Byte()
        Dim buffer As ByteBuffer
        Dim i As Integer

        buffer = New ByteBuffer

        For i = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(i).Name)) > 0 Then
                buffer.WriteBytes(ResourceData(i))
            End If

        Next

        Return buffer.ToArray
        buffer = Nothing
    End Function

    Function ResourceData(ByVal ResourceNum As Integer) As Byte()
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer

        Buffer.WriteInteger(ResourceNum)
        Buffer.WriteInteger(Resource(ResourceNum).Animation)
        Buffer.WriteString(Resource(ResourceNum).EmptyMessage)
        Buffer.WriteInteger(Resource(ResourceNum).ExhaustedImage)
        Buffer.WriteInteger(Resource(ResourceNum).Health)
        Buffer.WriteInteger(Resource(ResourceNum).ExpReward)
        Buffer.WriteInteger(Resource(ResourceNum).ItemReward)
        Buffer.WriteString(Resource(ResourceNum).Name)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceImage)
        Buffer.WriteInteger(Resource(ResourceNum).ResourceType)
        Buffer.WriteInteger(Resource(ResourceNum).RespawnTime)
        Buffer.WriteString(Resource(ResourceNum).SuccessMessage)
        Buffer.WriteInteger(Resource(ResourceNum).LvlRequired)
        Buffer.WriteInteger(Resource(ResourceNum).ToolRequired)
        Buffer.WriteInteger(Resource(ResourceNum).Walkthrough)

        Return Buffer.ToArray
        Buffer = Nothing
    End Function

#End Region

End Module
