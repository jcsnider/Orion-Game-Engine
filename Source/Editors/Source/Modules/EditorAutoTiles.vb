﻿Imports SFML.Graphics
Imports SFML.Window

Public Module EditorAutoTiles
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
    Public Const RENDER_STATE_NONE As Integer = 0
    Public Const RENDER_STATE_NORMAL As Integer = 1
    Public Const RENDER_STATE_AUTOTILE As Integer = 2

    ' autotiling
    Public autoInner(0 To 4) As PointRec
    Public autoNW(0 To 4) As PointRec
    Public autoNE(0 To 4) As PointRec
    Public autoSW(0 To 4) As PointRec
    Public autoSE(0 To 4) As PointRec

    ' Map animations
    Public waterfallFrame As Integer
    Public autoTileFrame As Integer

    Public Autotile(,) As AutotileRec

    Public Structure PointRec
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure QuarterTileRec
        Dim QuarterTile() As PointRec '1 To 4
        Dim renderState As Byte
        Dim srcX() As Integer '1 To 4
        Dim srcY() As Integer '1 To 4
    End Structure

    Public Structure AutotileRec
        Dim Layer() As QuarterTileRec '1 To MapLayer.Count - 1
        Dim ExLayer() As QuarterTileRec '1 To ExMapLayer.Count - 1
    End Structure
#End Region

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '   All of this code is for auto tiles and the math behind generating them.
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Sub PlaceAutotile(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal tileQuarter As Byte, ByVal autoTileLetter As String)

        If layerNum > MapLayer.Count - 1 Then
            layerNum = layerNum - (MapLayer.Count - 1)
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

    Public Sub InitAutotiles()
        Dim X As Integer, Y As Integer, layerNum As Integer
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
                ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)
                For i = 0 To MapLayer.Count - 1
                    ReDim Autotile(X, Y).Layer(i).srcX(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).srcY(0 To 4)
                    ReDim Autotile(X, Y).Layer(i).QuarterTile(0 To 4)
                Next
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
                For layerNum = 1 To MapLayer.Count - 1
                    ' calculate the subtile positions and place them
                    CalculateAutotile(X, Y, layerNum)
                    ' cache the rendering state of the tiles and set them
                    CacheRenderState(X, Y, layerNum)
                Next
            Next
        Next

    End Sub

    Public Sub CacheRenderState(ByVal X As Integer, ByVal Y As Integer, ByVal layerNum As Integer)
        Dim quarterNum As Integer

        ' exit out early

        If X < 0 Or X > Map.MaxX Or Y < 0 Or Y > Map.MaxY Then Exit Sub

        With Map.Tile(X, Y)
            ' check if the tile can be rendered
            If .Layer(layerNum).Tileset <= 0 Or .Layer(layerNum).Tileset > NumTileSets Then
                Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NONE
                Exit Sub
            End If
            ' check if it's a key - hide mask if key is closed
            If layerNum = MapLayer.Mask Then
                If .Type = TileType.Key Then
                    If TempTile(X, Y).DoorOpen = False Then
                        Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NONE
                        Exit Sub
                    Else
                        Autotile(X, Y).Layer(layerNum).renderState = RENDER_STATE_NORMAL
                        Exit Sub
                    End If
                End If
            End If
            ' check if it needs to be rendered as an autotile
            If .Layer(layerNum).AutoTile = AUTOTILE_NONE Or .Layer(layerNum).AutoTile = AUTOTILE_FAKE Then
                'ReDim Autotile(X, Y).Layer(0 To MapLayer.Count - 1)
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

    Public Sub CalculateAutotile(ByVal X As Integer, ByVal Y As Integer, ByVal layerNum As Integer)
        ' Right, so we've split the tile block in to an easy to remember
        ' collection of letters. We now need to do the calculations to find
        ' out which little lettered block needs to be rendered. We do this
        ' by reading the surrounding tiles to check for matches.
        ' First we check to make sure an autotile situation is actually there.
        ' Then we calculate exactly which situation has arisen.
        ' The situations are "inner", "outer", "horizontal", "vertical" and "fill".
        ' Exit out if we don't have an autotile

        If Map.Tile(X, Y).Layer(layerNum).AutoTile = 0 Then Exit Sub
        ' Okay, we have autotiling but which one?
        Select Case Map.Tile(X, Y).Layer(layerNum).AutoTile
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
    Public Sub CalculateNW_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North West

        If CheckTileMatch(layerNum, X, Y, X - 1, Y - 1) Then tmpTile(1) = True
        ' North
        If CheckTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(2) = True
        ' West
        If CheckTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 1, "e")
            Case AUTO_OUTER
                PlaceAutotile(layerNum, X, Y, 1, "a")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 1, "i")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 1, "m")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 1, "q")
        End Select

    End Sub

    Public Sub CalculateNE_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North

        If CheckTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(1) = True
        ' North East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y - 1) Then tmpTile(2) = True
        ' East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 2, "j")
            Case AUTO_OUTER
                PlaceAutotile(layerNum, X, Y, 2, "b")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 2, "f")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 2, "r")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 2, "n")
        End Select

    End Sub

    Public Sub CalculateSW_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' West

        If CheckTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(1) = True
        ' South West
        If CheckTileMatch(layerNum, X, Y, X - 1, Y + 1) Then tmpTile(2) = True
        ' South
        If CheckTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 3, "o")
            Case AUTO_OUTER
                PlaceAutotile(layerNum, X, Y, 3, "c")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 3, "s")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 3, "g")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 3, "k")
        End Select

    End Sub

    Public Sub CalculateSE_Normal(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' South

        If CheckTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(1) = True
        ' South East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y + 1) Then tmpTile(2) = True
        ' East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 4, "t")
            Case AUTO_OUTER
                PlaceAutotile(layerNum, X, Y, 4, "d")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 4, "p")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 4, "l")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 4, "h")
        End Select

    End Sub

    ' Waterfall autotiling
    Public Sub CalculateNW_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' West

        If CheckTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            PlaceAutotile(layerNum, X, Y, 1, "i")
        Else
            ' Edge
            PlaceAutotile(layerNum, X, Y, 1, "e")
        End If

    End Sub

    Public Sub CalculateNE_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' East

        If CheckTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            PlaceAutotile(layerNum, X, Y, 2, "f")
        Else
            ' Edge
            PlaceAutotile(layerNum, X, Y, 2, "j")
        End If

    End Sub

    Public Sub CalculateSW_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' West

        If CheckTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            PlaceAutotile(layerNum, X, Y, 3, "k")
        Else
            ' Edge
            PlaceAutotile(layerNum, X, Y, 3, "g")
        End If

    End Sub

    Public Sub CalculateSE_Waterfall(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile As Boolean
        ' East

        If CheckTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile = True
        ' Actually place the subtile
        If tmpTile Then
            ' Extended
            PlaceAutotile(layerNum, X, Y, 4, "h")
        Else
            ' Edge
            PlaceAutotile(layerNum, X, Y, 4, "l")
        End If

    End Sub

    ' Cliff autotiling
    Public Sub CalculateNW_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North West

        If CheckTileMatch(layerNum, X, Y, X - 1, Y - 1) Then tmpTile(1) = True
        ' North
        If CheckTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(2) = True
        ' West
        If CheckTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 1, "e")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 1, "i")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 1, "m")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 1, "q")
        End Select

    End Sub

    Public Sub CalculateNE_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' North

        If CheckTileMatch(layerNum, X, Y, X, Y - 1) Then tmpTile(1) = True
        ' North East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y - 1) Then tmpTile(2) = True
        ' East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 2, "j")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 2, "f")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 2, "r")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 2, "n")
        End Select

    End Sub

    Public Sub CalculateSW_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' West

        If CheckTileMatch(layerNum, X, Y, X - 1, Y) Then tmpTile(1) = True
        ' South West
        If CheckTileMatch(layerNum, X, Y, X - 1, Y + 1) Then tmpTile(2) = True
        ' South
        If CheckTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 3, "o")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 3, "s")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 3, "g")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 3, "k")
        End Select

    End Sub

    Public Sub CalculateSE_Cliff(ByVal layerNum As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim tmpTile(0 To 3) As Boolean
        Dim situation As Byte

        ' South

        If CheckTileMatch(layerNum, X, Y, X, Y + 1) Then tmpTile(1) = True
        ' South East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y + 1) Then tmpTile(2) = True
        ' East
        If CheckTileMatch(layerNum, X, Y, X + 1, Y) Then tmpTile(3) = True
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
                PlaceAutotile(layerNum, X, Y, 4, "t")
            Case AUTO_HORIZONTAL
                PlaceAutotile(layerNum, X, Y, 4, "p")
            Case AUTO_VERTICAL
                PlaceAutotile(layerNum, X, Y, 4, "l")
            Case AUTO_FILL
                PlaceAutotile(layerNum, X, Y, 4, "h")
        End Select

    End Sub

    Public Function CheckTileMatch(ByVal layerNum As Integer, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Boolean
        ' we'll exit out early if true
        Dim exTile As Boolean

        If layerNum > MapLayer.Count - 1 Then exTile = True : layerNum = layerNum - (MapLayer.Count - 1)
        CheckTileMatch = True
        ' if it's off the map then set it as autotile and exit out early
        If X2 < 0 Or X2 > Map.MaxX Or Y2 < 0 Or Y2 > Map.MaxY Then
            CheckTileMatch = True
            Exit Function
        End If

        ' fakes ALWAYS return true
        If Map.Tile(X2, Y2).Layer(layerNum).AutoTile = AUTOTILE_FAKE Then
            CheckTileMatch = True
            Exit Function
        End If
        ' End If

        ' check neighbour is an autotile
        If Map.Tile(X2, Y2).Layer(layerNum).AutoTile = 0 Then
            CheckTileMatch = False
            Exit Function
        End If
        ' End If

        ' check we're a matching
        If Map.Tile(X1, Y1).Layer(layerNum).Tileset <> Map.Tile(X2, Y2).Layer(layerNum).Tileset Then
            CheckTileMatch = False
            Exit Function
        End If

        ' check tiles match
        If Map.Tile(X1, Y1).Layer(layerNum).X <> Map.Tile(X2, Y2).Layer(layerNum).X Then
            CheckTileMatch = False
            Exit Function
        Else
            If Map.Tile(X1, Y1).Layer(layerNum).Y <> Map.Tile(X2, Y2).Layer(layerNum).Y Then
                CheckTileMatch = False
                Exit Function
            End If
        End If
    End Function

    Public Sub DrawAutoTile(ByVal layerNum As Integer, ByVal destX As Integer, ByVal destY As Integer, ByVal quarterNum As Integer, ByVal X As Integer, ByVal Y As Integer, Optional forceFrame As Integer = 0, Optional strict As Boolean = True, Optional ExLayer As Boolean = False)
        Dim YOffset As Integer, XOffset As Integer
        Dim srcrect As New Rectangle(0, 0, 0, 0)
        Dim tmpSprite As Sprite

        If GettingMap Then Exit Sub
        If MapData = False Then Exit Sub

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

        Select Case Map.Tile(X, Y).Layer(layerNum).AutoTile
            Case AUTOTILE_WATERFALL
                YOffset = (waterfallFrame - 1) * 32
            Case AUTOTILE_ANIM
                XOffset = autoTileFrame * 64
            Case AUTOTILE_CLIFF
                YOffset = -32
        End Select

        ' Draw the quarter
        tmpSprite = New Sprite(TileSetTexture(Map.Tile(X, Y).Layer(layerNum).Tileset))
        tmpSprite.TextureRect = New IntRect(Autotile(X, Y).Layer(layerNum).srcX(quarterNum) + XOffset, Autotile(X, Y).Layer(layerNum).srcY(quarterNum) + YOffset, 16, 16)
        tmpSprite.Position = New Vector2f(destX, destY)
        GameWindow.Draw(tmpSprite)

    End Sub
End Module