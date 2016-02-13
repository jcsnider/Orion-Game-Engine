Imports System.Drawing
Imports SFML.Graphics

Public Module ClientAutoTiles
#Region "Globals and Types"
    ' Autotiles
    Public Const AUTO_INNER As Byte = 1
    Public Const AUTO_OUTER As Byte = 2
    Public Const AUTO_HORIZONTAL As Byte = 3
    Public Const AUTO_VERTICAL As Byte = 4
    Public Const AUTO_FILL As Byte = 5

    ' Autotile types
    Public Const AUTOTILE_NONE As Byte = 0
    Public Const AUTOTILE_NORMAL As Byte = 1
    Public Const AUTOTILE_FAKE As Byte = 2
    Public Const AUTOTILE_ANIM As Byte = 3
    Public Const AUTOTILE_CLIFF As Byte = 4
    Public Const AUTOTILE_WATERFALL As Byte = 5

    ' Rendering
    Public Const RENDER_STATE_NONE As Long = 0
    Public Const RENDER_STATE_NORMAL As Long = 1
    Public Const RENDER_STATE_AUTOTILE As Long = 2

    ' autotiling
    Public autoInner(0 To 4) As PointRec
    Public autoNW(0 To 4) As PointRec
    Public autoNE(0 To 4) As PointRec
    Public autoSW(0 To 4) As PointRec
    Public autoSE(0 To 4) As PointRec

    ' Map animations
    Public waterfallFrame As Long
    Public autoTileFrame As Long

    Public Autotile(,) As AutotileRec

    Public Structure PointRec
        Dim X As Long
        Dim Y As Long
    End Structure

    Public Structure QuarterTileRec
        Dim QuarterTile() As PointRec '1 To 4
        Dim renderState As Byte
        Dim srcX() As Long '1 To 4
        Dim srcY() As Long '1 To 4
    End Structure

    Public Structure AutotileRec
        Dim Layer() As QuarterTileRec '1 To MapLayer.Layer_Count - 1
        Dim ExLayer() As QuarterTileRec '1 To ExMapLayer.Layer_Count - 1
    End Structure
#End Region

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '   All of this code is for auto tiles and the math behind generating them.
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Sub placeAutotile(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long, ByVal tileQuarter As Byte, ByVal autoTileLetter As String)

        If layerNum > MapLayer.Layer_Count - 1 Then
            layerNum = layerNum - (MapLayer.Layer_Count - 1)
            With Autotile(X, Y).ExLayer(layerNum).QuarterTile(tileQuarter)
                Select Case autoTileLetter
                    Case "a"
                        .X = autoInner(1).X
                        .Y = autoInner(1).Y
                    Case "b"
                        .X = autoInner(2).X
                        .Y = autoInner(2).Y
                    Case "c"
                        .X = autoInner(3).X
                        .Y = autoInner(3).Y
                    Case "d"
                        .X = autoInner(4).X
                        .Y = autoInner(4).Y
                    Case "e"
                        .X = autoNW(1).X
                        .Y = autoNW(1).Y
                    Case "f"
                        .X = autoNW(2).X
                        .Y = autoNW(2).Y
                    Case "g"
                        .X = autoNW(3).X
                        .Y = autoNW(3).Y
                    Case "h"
                        .X = autoNW(4).X
                        .Y = autoNW(4).Y
                    Case "i"
                        .X = autoNE(1).X
                        .Y = autoNE(1).Y
                    Case "j"
                        .X = autoNE(2).X
                        .Y = autoNE(2).Y
                    Case "k"
                        .X = autoNE(3).X
                        .Y = autoNE(3).Y
                    Case "l"
                        .X = autoNE(4).X
                        .Y = autoNE(4).Y
                    Case "m"
                        .X = autoSW(1).X
                        .Y = autoSW(1).Y
                    Case "n"
                        .X = autoSW(2).X
                        .Y = autoSW(2).Y
                    Case "o"
                        .X = autoSW(3).X
                        .Y = autoSW(3).Y
                    Case "p"
                        .X = autoSW(4).X
                        .Y = autoSW(4).Y
                    Case "q"
                        .X = autoSE(1).X
                        .Y = autoSE(1).Y
                    Case "r"
                        .X = autoSE(2).X
                        .Y = autoSE(2).Y
                    Case "s"
                        .X = autoSE(3).X
                        .Y = autoSE(3).Y
                    Case "t"
                        .X = autoSE(4).X
                        .Y = autoSE(4).Y
                End Select
            End With
        Else
            With Autotile(X, Y).Layer(layerNum).QuarterTile(tileQuarter)
                Select Case autoTileLetter
                    Case "a"
                        .X = autoInner(1).X
                        .Y = autoInner(1).Y
                    Case "b"
                        .X = autoInner(2).X
                        .Y = autoInner(2).Y
                    Case "c"
                        .X = autoInner(3).X
                        .Y = autoInner(3).Y
                    Case "d"
                        .X = autoInner(4).X
                        .Y = autoInner(4).Y
                    Case "e"
                        .X = autoNW(1).X
                        .Y = autoNW(1).Y
                    Case "f"
                        .X = autoNW(2).X
                        .Y = autoNW(2).Y
                    Case "g"
                        .X = autoNW(3).X
                        .Y = autoNW(3).Y
                    Case "h"
                        .X = autoNW(4).X
                        .Y = autoNW(4).Y
                    Case "i"
                        .X = autoNE(1).X
                        .Y = autoNE(1).Y
                    Case "j"
                        .X = autoNE(2).X
                        .Y = autoNE(2).Y
                    Case "k"
                        .X = autoNE(3).X
                        .Y = autoNE(3).Y
                    Case "l"
                        .X = autoNE(4).X
                        .Y = autoNE(4).Y
                    Case "m"
                        .X = autoSW(1).X
                        .Y = autoSW(1).Y
                    Case "n"
                        .X = autoSW(2).X
                        .Y = autoSW(2).Y
                    Case "o"
                        .X = autoSW(3).X
                        .Y = autoSW(3).Y
                    Case "p"
                        .X = autoSW(4).X
                        .Y = autoSW(4).Y
                    Case "q"
                        .X = autoSE(1).X
                        .Y = autoSE(1).Y
                    Case "r"
                        .X = autoSE(2).X
                        .Y = autoSE(2).Y
                    Case "s"
                        .X = autoSE(3).X
                        .Y = autoSE(3).Y
                    Case "t"
                        .X = autoSE(4).X
                        .Y = autoSE(4).Y
                End Select
            End With
        End If

    End Sub

    Public Sub initAutotiles()
        Dim X As Long, Y As Long, layerNum As Long
        ' Procedure used to cache autotile positions. All positioning is
        ' independant from the tileset. Calculations are convoluted and annoying.
        ' Maths is not my strong point. Luckily we're caching them so it's a one-off
        ' thing when the map is originally loaded. As such optimisation isn't an issue.
        ' For simplicity's sake we cache all subtile SOURCE positions in to an array.
        ' We also give letters to each subtile for easy rendering tweaks. ;]
        ' First, we need to re-size the array

        ReDim Autotile(0 To Map.MaxX, 0 To Map.MaxY)
        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                ReDim Autotile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
                For i = 0 To MapLayer.Layer_Count - 1
                    ReDim Autotile(X, Y).Layer(i).srcX(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).srcY(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).QuarterTile(0 To 4)
                Next

                'ReDim Autotile(X, Y).ExLayer(0 To ExMapLayer.Layer_Count - 1)
                'For i = 0 To ExMapLayer.Layer_Count - 1
                '    ReDim Autotile(X, Y).ExLayer(i).srcX(0 To 4)
                '    ReDim Autotile(X, Y).ExLayer(i).srcY(0 To 4)
                '    ReDim Autotile(X, Y).ExLayer(i).QuarterTile(0 To 4)
                'Next

            Next
        Next

        ' Inner tiles (Top right subtile region)
        ' NW - a
        autoInner(1).X = 32
        autoInner(1).Y = 0
        ' NE - b
        autoInner(2).X = 48
        autoInner(2).Y = 0
        ' SW - c
        autoInner(3).X = 32
        autoInner(3).Y = 16
        ' SE - d
        autoInner(4).X = 48
        autoInner(4).Y = 16
        ' Outer Tiles - NW (bottom subtile region)
        ' NW - e
        autoNW(1).X = 0
        autoNW(1).Y = 32
        ' NE - f
        autoNW(2).X = 16
        autoNW(2).Y = 32
        ' SW - g
        autoNW(3).X = 0
        autoNW(3).Y = 48
        ' SE - h
        autoNW(4).X = 16
        autoNW(4).Y = 48
        ' Outer Tiles - NE (bottom subtile region)
        ' NW - i
        autoNE(1).X = 32
        autoNE(1).Y = 32
        ' NE - g
        autoNE(2).X = 48
        autoNE(2).Y = 32
        ' SW - k
        autoNE(3).X = 32
        autoNE(3).Y = 48
        ' SE - l
        autoNE(4).X = 48
        autoNE(4).Y = 48
        ' Outer Tiles - SW (bottom subtile region)
        ' NW - m
        autoSW(1).X = 0
        autoSW(1).Y = 64
        ' NE - n
        autoSW(2).X = 16
        autoSW(2).Y = 64
        ' SW - o
        autoSW(3).X = 0
        autoSW(3).Y = 80
        ' SE - p
        autoSW(4).X = 16
        autoSW(4).Y = 80
        ' Outer Tiles - SE (bottom subtile region)
        ' NW - q
        autoSE(1).X = 32
        autoSE(1).Y = 64
        ' NE - r
        autoSE(2).X = 48
        autoSE(2).Y = 64
        ' SW - s
        autoSE(3).X = 32
        autoSE(3).Y = 80
        ' SE - t
        autoSE(4).X = 48
        autoSE(4).Y = 80

        For X = 0 To Map.MaxX
            For Y = 0 To Map.MaxY
                For layerNum = 1 To MapLayer.Layer_Count - 1
                    ' calculate the subtile positions and place them
                    CalculateAutotile(X, Y, layerNum)
                    ' cache the rendering state of the tiles and set them
                    CacheRenderState(X, Y, layerNum)
                Next
                'For layerNum = 1 To ExMapLayer.Layer_Count - 1
                '    ' calculate the subtile positions and place them
                '    CalculateAutotile(X, Y, layerNum + (MapLayer.Layer_Count - 1))
                '    ' cache the rendering state of the tiles and set them
                '    CacheRenderState(X, Y, layerNum + (MapLayer.Layer_Count - 1))
                'Next
            Next
        Next

    End Sub

    Public Sub CacheRenderState(ByVal X As Long, ByVal Y As Long, ByVal layerNum As Long)
        Dim quarterNum As Long

        ' exit out early

        If X < 0 Or X > Map.MaxX Or Y < 0 Or Y > Map.MaxY Then Exit Sub

        ' If layerNum > MapLayer.Layer_Count - 1 Then
        ' layerNum = layerNum - (MapLayer.Layer_Count - 1)
        'With Map.exTile(X, Y)
        '    ' check if the tile can be rendered
        '    If .Layer(layerNum).tileset <= 0 Or .Layer(layerNum).tileset > NumTileSets Then
        '        'ReDim Autotile(X, Y).ExLayer(0 To MapLayer.Layer_Count - 1)
        '        Autotile(X, Y).ExLayer(layerNum).renderState = RENDER_STATE_NONE
        '        Exit Sub
        '    End If
        '    ' check if it needs to be rendered as an autotile
        '    If .Autotile(layerNum) = AUTOTILE_NONE Or .Autotile(layerNum) = AUTOTILE_FAKE Then
        '        ' default to... default
        '        Autotile(X, Y).ExLayer(layerNum).renderState = RENDER_STATE_NORMAL
        '    Else
        '        Autotile(X, Y).ExLayer(layerNum).renderState = RENDER_STATE_AUTOTILE
        '        ' cache tileset positioning
        '        For quarterNum = 1 To 4
        '            Autotile(X, Y).ExLayer(layerNum).srcX(quarterNum) = (Map.exTile(X, Y).Layer(layerNum).X * 32) + Autotile(X, Y).ExLayer(layerNum).QuarterTile(quarterNum).X
        '            Autotile(X, Y).ExLayer(layerNum).srcY(quarterNum) = (Map.exTile(X, Y).Layer(layerNum).Y * 32) + Autotile(X, Y).ExLayer(layerNum).QuarterTile(quarterNum).Y
        '        Next
        '    End If
        'End With
        ' Else
        With Map.Tile(X, Y)
                ' check if the tile can be rendered
                If .Layer(layerNum).tileset <= 0 Or .Layer(layerNum).tileset > NumTileSets Then
                    Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NONE
                    Exit Sub
                End If
                ' check if it's a key - hide mask if key is closed
                If layerNum = MapLayer.Mask Then
                    If .Type = TILE_TYPE_KEY Then
                        If TempTile(X, Y).DoorOpen = NO Then
                            Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NONE
                            Exit Sub
                        Else
                            Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NORMAL
                            Exit Sub
                        End If
                    End If
                End If
                ' check if it needs to be rendered as an autotile
                If .Autotile(layerNum) = AUTOTILE_NONE Or .Autotile(layerNum) = AUTOTILE_FAKE Then
                    'ReDim Autotile(X, Y).Layer(0 To MapLayer.Layer_Count - 1)
                    ' default to... default
                    Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NORMAL
                Else
                    Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_AUTOTILE
                    ' cache tileset positioning
                    For quarterNum = 1 To 4
                        Autotile(X, Y).Layer(layerNum).srcX(quarterNum) = (Map.Tile(X, Y).Layer(layerNum).X * 32) + Autotile(X, Y).Layer(layerNum).QuarterTile(quarterNum).X
                        Autotile(X, Y).Layer(layerNum).srcY(quarterNum) = (Map.Tile(X, Y).Layer(layerNum).Y * 32) + Autotile(X, Y).Layer(layerNum).QuarterTile(quarterNum).Y
                    Next
                End If
            End With
        ' End If

    End Sub

    Public Sub CalculateAutotile(ByVal X As Long, ByVal Y As Long, ByVal layerNum As Long)
        ' Right, so we've split the tile block in to an easy to remember
        ' collection of letters. We now need to do the calculations to find
        ' out which little lettered block needs to be rendered. We do this
        ' by reading the surrounding tiles to check for matches.
        ' First we check to make sure an autotile situation is actually there.
        ' Then we calculate exactly which situation has arisen.
        ' The situations are "inner", "outer", "horizontal", "vertical" and "fill".
        ' Exit out if we don't have an autotile

        'If layerNum > MapLayer.Layer_Count - 1 Then
        '    If Map.exTile(X, Y).Autotile(layerNum - (MapLayer.Layer_Count - 1)) = 0 Then Exit Sub
        '    ' Okay, we have autotiling but which one?
        '    Select Case Map.exTile(X, Y).Autotile(layerNum - (MapLayer.Layer_Count - 1))
        '        ' Normal or animated - same difference
        '        Case AUTOTILE_NORMAL, AUTOTILE_ANIM
        '            ' North West Quarter
        '            CalculateNW_Normal(layerNum, X, Y)
        '            ' North East Quarter
        '            CalculateNE_Normal(layerNum, X, Y)
        '            ' South West Quarter
        '            CalculateSW_Normal(layerNum, X, Y)
        '            ' South East Quarter
        '            CalculateSE_Normal(layerNum, X, Y)
        '        ' Cliff
        '        Case AUTOTILE_CLIFF
        '            ' North West Quarter
        '            CalculateNW_Cliff(layerNum, X, Y)
        '            ' North East Quarter
        '            CalculateNE_Cliff(layerNum, X, Y)
        '            ' South West Quarter
        '            CalculateSW_Cliff(layerNum, X, Y)
        '            ' South East Quarter
        '            CalculateSE_Cliff(layerNum, X, Y)
        '        ' Waterfalls
        '        Case AUTOTILE_WATERFALL
        '            ' North West Quarter
        '            CalculateNW_Waterfall(layerNum, X, Y)
        '            ' North East Quarter
        '            CalculateNE_Waterfall(layerNum, X, Y)
        '            ' South West Quarter
        '            CalculateSW_Waterfall(layerNum, X, Y)
        '            ' South East Quarter
        '            CalculateSE_Waterfall(layerNum, X, Y)
        '        ' Anything else
        '        Case Else
        '            ' Don't need to render anything... it's fake or not an autotile
        '    End Select
        'Else
        If Map.Tile(X, Y).Autotile(layerNum) = 0 Then Exit Sub
            ' Okay, we have autotiling but which one?
            Select Case Map.Tile(X, Y).Autotile(layerNum)
                ' Normal or animated - same difference
                Case AUTOTILE_NORMAL, AUTOTILE_ANIM
                    ' North West Quarter
                    CalculateNW_Normal(layerNum, X, Y)
                    ' North East Quarter
                    CalculateNE_Normal(layerNum, X, Y)
                    ' South West Quarter
                    CalculateSW_Normal(layerNum, X, Y)
                    ' South East Quarter
                    CalculateSE_Normal(layerNum, X, Y)
                ' Cliff
                Case AUTOTILE_CLIFF
                    ' North West Quarter
                    CalculateNW_Cliff(layerNum, X, Y)
                    ' North East Quarter
                    CalculateNE_Cliff(layerNum, X, Y)
                    ' South West Quarter
                    CalculateSW_Cliff(layerNum, X, Y)
                    ' South East Quarter
                    CalculateSE_Cliff(layerNum, X, Y)
                ' Waterfalls
                Case AUTOTILE_WATERFALL
                    ' North West Quarter
                    CalculateNW_Waterfall(layerNum, X, Y)
                    ' North East Quarter
                    CalculateNE_Waterfall(layerNum, X, Y)
                    ' South West Quarter
                    CalculateSW_Waterfall(layerNum, X, Y)
                    ' South East Quarter
                    CalculateSE_Waterfall(layerNum, X, Y)
                ' Anything else
                Case Else
                    ' Don't need to render anything... it's fake or not an autotile
            End Select
        ' End If

    End Sub

    ' Normal autotiling
    Public Sub CalculateNW_Normal(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North West

        If checkTileMatch(layerNum, X, Y, X - 1, Y - 1) Then tmpTile(1) = True
        ' North
        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(2) = True
        ' West
        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(2) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If Not tmpTile(2) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(2) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If Not tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 1, "e")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 1, "a")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 1, "i")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 1, "m")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 1, "q")
        End Select

    End Sub

    Public Sub CalculateNE_Normal(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North

        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(1) = True
        ' North East
        If checkTileMatch(layerNum, X, Y, X + 1, Y - 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If tmpTile(1) And Not tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 2, "j")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 2, "b")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 2, "f")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 2, "r")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 2, "n")
        End Select

    End Sub

    Public Sub CalculateSW_Normal(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(1) = True
        ' South West
        If checkTileMatch(layerNum, X, Y, X - 1, Y + 1) Then tmpTile(2) = True
        ' South
        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If tmpTile(1) And Not tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 3, "o")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 3, "c")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 3, "s")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 3, "g")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 3, "k")
        End Select

    End Sub

    Public Sub CalculateSE_Normal(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' South

        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(1) = True
        ' South East
        If checkTileMatch(layerNum, X, Y, X + 1, Y + 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        ' Calculate Situation - Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Outer
        If tmpTile(1) And Not tmpTile(2) And tmpTile(3) Then situation = AUTO_OUTER
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 4, "t")
            Case AUTO_OUTER
                placeAutotile(layerNum, X, Y, 4, "d")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 4, "p")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 4, "l")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 4, "h")
        End Select

    End Sub

    ' Waterfall autotiling
    Public Sub CalculateNW_Waterfall(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile As Boolean
        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 1, "i")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 1, "e")
        End If

    End Sub

    Public Sub CalculateNE_Waterfall(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile As Boolean
        ' East

        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 2, "f")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 2, "j")
        End If

    End Sub

    Public Sub CalculateSW_Waterfall(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile As Boolean
        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 3, "k")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 3, "g")
        End If

    End Sub

    Public Sub CalculateSE_Waterfall(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile As Boolean
        ' East

        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            placeAutotile(layerNum, X, Y, 4, "h")
        Else
            ' Edge
            placeAutotile(layerNum, X, Y, 4, "l")
        End If

    End Sub

    ' Cliff autotiling
    Public Sub CalculateNW_Cliff(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North West

        If checkTileMatch(layerNum, X, Y, X - 1, Y - 1) Then tmpTile(1) = True
        ' North
        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(2) = True
        ' West
        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation - Horizontal
        If Not tmpTile(2) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(2) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(2) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 1, "e")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 1, "i")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 1, "m")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 1, "q")
        End Select

    End Sub

    Public Sub CalculateNE_Cliff(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North

        If checkTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(1) = True
        ' North East
        If checkTileMatch(layerNum, X, Y, X + 1, Y - 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation - Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 2, "j")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 2, "f")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 2, "r")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 2, "n")
        End Select

    End Sub

    Public Sub CalculateSW_Cliff(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' West

        If checkTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(1) = True
        ' South West
        If checkTileMatch(layerNum, X, Y, X - 1, Y + 1) Then tmpTile(2) = True
        ' South
        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation - Horizontal
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 3, "o")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 3, "s")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 3, "g")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 3, "k")
        End Select

    End Sub

    Public Sub CalculateSE_Cliff(ByVal layerNum As Long, ByVal X As Long, ByVal Y As Long)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' South

        If checkTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(1) = True
        ' South East
        If checkTileMatch(layerNum, X, Y, X + 1, Y + 1) Then tmpTile(2) = True
        ' East
        If checkTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
        situation = AUTO_FILL
        ' Calculate Situation -  Horizontal
        If Not tmpTile(1) And tmpTile(3) Then situation = AUTO_HORIZONTAL
        ' Vertical
        If tmpTile(1) And Not tmpTile(3) Then situation = AUTO_VERTICAL
        ' Fill
        If tmpTile(1) And tmpTile(2) And tmpTile(3) Then situation = AUTO_FILL
        ' Inner
        If Not tmpTile(1) And Not tmpTile(3) Then situation = AUTO_INNER
        ' Actually place the subtile
        Select Case situation
            Case AUTO_INNER
                placeAutotile(layerNum, X, Y, 4, "t")
            Case AUTO_HORIZONTAL
                placeAutotile(layerNum, X, Y, 4, "p")
            Case AUTO_VERTICAL
                placeAutotile(layerNum, X, Y, 4, "l")
            Case AUTO_FILL
                placeAutotile(layerNum, X, Y, 4, "h")
        End Select

    End Sub

    Public Function checkTileMatch(ByVal layerNum As Long, ByVal X1 As Long, ByVal Y1 As Long, ByVal X2 As Long, ByVal Y2 As Long) As Boolean
        ' we'll exit out early if true
        Dim exTile As Boolean

        If layerNum > MapLayer.Layer_Count - 1 Then exTile = True : layerNum = layerNum - (MapLayer.Layer_Count - 1)
        checkTileMatch = True
        ' if it's off the map then set it as autotile and exit out early
        If X2 < 0 Or X2 > Map.MaxX Or Y2 < 0 Or Y2 > Map.MaxY Then
            checkTileMatch = True
            Exit Function
        End If
        'If exTile Then
        '    ' fakes ALWAYS return true
        '    If Map.exTile(X2, Y2).Autotile(layerNum) = AUTOTILE_FAKE Then
        '        checkTileMatch = True
        '        Exit Function
        '    End If
        'Else
        ' fakes ALWAYS return true
        If Map.Tile(X2, Y2).Autotile(layerNum) = AUTOTILE_FAKE Then
                checkTileMatch = True
                Exit Function
            End If
        ' End If
        'If exTile Then
        '    ' check neighbour is an autotile
        '    If Map.exTile(X2, Y2).Autotile(layerNum) = 0 Then
        '        checkTileMatch = False
        '        Exit Function
        '    End If
        'Else
        ' check neighbour is an autotile
        If Map.Tile(X2, Y2).Autotile(layerNum) = 0 Then
                checkTileMatch = False
                Exit Function
            End If
        ' End If
        'If exTile Then
        '    ' check we're a matching
        '    If Map.exTile(X1, Y1).Layer(layerNum).tileset <> Map.exTile(X2, Y2).Layer(layerNum).tileset Then
        '        checkTileMatch = False
        '        Exit Function
        '    End If
        '    ' check tiles match
        '    If Map.exTile(X1, Y1).Layer(layerNum).X <> Map.exTile(X2, Y2).Layer(layerNum).X Then
        '        checkTileMatch = False
        '        Exit Function
        '    End If
        '    If Map.exTile(X1, Y1).Layer(layerNum).Y <> Map.exTile(X2, Y2).Layer(layerNum).Y Then
        '        checkTileMatch = False
        '        Exit Function
        '    End If
        'Else
        ' check we're a matching
        If Map.Tile(X1, Y1).Layer(layerNum).tileset <> Map.Tile(X2, Y2).Layer(layerNum).tileset Then
                checkTileMatch = False
                Exit Function
            End If
            ' check tiles match
            If Map.Tile(X1, Y1).Layer(layerNum).X <> Map.Tile(X2, Y2).Layer(layerNum).X Then
                checkTileMatch = False
                Exit Function
            End If
            If Map.Tile(X1, Y1).Layer(layerNum).Y <> Map.Tile(X2, Y2).Layer(layerNum).Y Then
                checkTileMatch = False
                Exit Function
            End If
        ' End If

    End Function

    Public Sub DrawAutoTile(ByVal layerNum As Long, ByVal destX As Long, ByVal destY As Long, ByVal quarterNum As Long, ByVal X As Long, ByVal Y As Long, Optional forceFrame As Long = 0, Optional strict As Boolean = True, Optional ExLayer As Boolean = False)
        Dim YOffset As Long, XOffset As Long
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim tmpSprite As Sprite

        ' calculate the offset
        If forceFrame > 0 Then
            Select Case forceFrame - 1
                Case 0
                    waterfallFrame = 1
                Case 1
                    waterfallFrame = 2
                Case 2
                    waterfallFrame = 0
            End Select
            ' animate autotiles
            Select Case forceFrame - 1
                Case 0
                    autoTileFrame = 1
                Case 1
                    autoTileFrame = 2
                Case 2
                    autoTileFrame = 0
            End Select
        End If

        'If ExLayer Then
        '    Select Case Map.exTile(X, Y).Autotile(layerNum)
        '        Case AUTOTILE_WATERFALL
        '            YOffset = (waterfallFrame - 1) * 32
        '        Case AUTOTILE_ANIM
        '            XOffset = autoTileFrame * 64
        '        Case AUTOTILE_CLIFF
        '            YOffset = -32
        '    End Select
        '    ' Draw the quarter
        '    tmpSprite = New Sprite(TileSetTexture(Map.exTile(X, Y).Layer(layerNum).tileset))
        '    tmpSprite.TextureRect = New IntRect(Autotile(X, Y).Layer(layerNum).srcX(quarterNum) + XOffset, Autotile(X, Y).Layer(layerNum).srcY(quarterNum) + YOffset, 16, 16)
        '    tmpSprite.Position = New SFML.System.Vector2f(destX, destY)
        '    GameWindow.Draw(tmpSprite)
        'Else

        Select Case Map.Tile(X, Y).Autotile(layerNum)
                Case AUTOTILE_WATERFALL
                    YOffset = (waterfallFrame - 1) * 32
                Case AUTOTILE_ANIM
                    XOffset = autoTileFrame * 64
                Case AUTOTILE_CLIFF
                    YOffset = -32
            End Select
            ' Draw the quarter
            tmpSprite = New Sprite(TileSetTexture(Map.Tile(X, Y).Layer(layerNum).tileset))
            tmpSprite.TextureRect = New IntRect(Autotile(X, Y).Layer(layerNum).srcX(quarterNum) + XOffset, Autotile(X, Y).Layer(layerNum).srcY(quarterNum) + YOffset, 16, 16)
            tmpSprite.Position = New SFML.System.Vector2f(destX, destY)
            GameWindow.Draw(tmpSprite)
        ' End If

    End Sub
End Module
