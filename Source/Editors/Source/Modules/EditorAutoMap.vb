Module EditorAutoMap
    ' Automapper System
    ' Version: 1.0
    ' Author: Lucas Tardivo (boasfesta)
    ' Map analysis and tips: Richard Johnson, Luan Meireles (Alenzinho)

    'Private MapOrientation() As MapOrientationRec

    Public MapStart As Integer = 1
    Public MapSize As Integer = 4
    Public MapX As Integer = 50
    Public MapY As Integer = 50

    Public SandBorder As Integer = 4
    Public DetailFreq As Integer = 10
    Public ResourceFreq As Integer = 20

    Public DetailsChecked As Boolean = True
    Public PathsChecked As Boolean = True
    Public RiversChecked As Boolean = True
    Public MountainsChecked As Boolean = True
    Public OverGrassChecked As Boolean = True
    Public ResourcesChecked As Boolean = True

    Enum TilePrefab
        Water = 1
        Sand
        Grass
        Passing
        Overgrass
        River
        Mountain
        Count
    End Enum

    'Distance between mountains and the map limit, so the player can walk freely when teleport between maps
    Private Const MountainBorder As Byte = 5

    Public Tile(0 To TilePrefab.Count - 1) As TileRec
    Public Detail() As DetailRec
    Public ResourcesNum As String
    Private Resources() As String
    Private ActualMap As Integer

    Enum MountainTile
        UpLeftBorder = 0
        UpMidBorder
        UpRightBorder
        MidLeftBorder
        Middle
        MidRightBorder
        BottomLeftBorder
        BottomMidBorder
        BottomRightBorder
        LeftBody
        MiddleBody
        RightBody
        LeftFoot
        MiddleFoot
        RightFoot
    End Enum

    Enum MapPrefab
        Undefined = 0
        UpLeftQuarter
        UpBorder
        UpRightQuarter
        RightBorder
        DownRightQuarter
        BottomBorder
        DownLeftQuarter
        LeftBorder
        Common
    End Enum

    Structure DetailRec
        Dim DetailBase As Byte
        Dim Tile As TileRec
    End Structure

    Structure MapOrientationRec
        Dim Prefab As Integer
        Dim TileStartX As Integer
        Dim TileStartY As Integer
        Dim TileEndX As Integer
        Dim TileEndY As Integer
        Dim Tile(,) As TilePrefab
    End Structure

    Sub OpenAutomapper()
        LoadTilePrefab()
        FrmAutoMapper.Visible = True
    End Sub

    Sub LoadTilePrefab()
        Dim Prefab As Integer, Layer As Integer

        Dim myXml As New XmlClass With {
            .Filename = IO.Path.Combine(Application.StartupPath, "Data Files", "AutoMapper.xml"),
            .Root = "Options"
        }

        ReDim Tile(TilePrefab.Count - 1)
        For Prefab = 1 To TilePrefab.Count - 1

            ReDim Tile(Prefab).Layer(0 To MapLayer.Count - 1)
            For Layer = 1 To MapLayer.Count - 1
                Tile(Prefab).Layer(Layer).Tileset = Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Tileset"))
                Tile(Prefab).Layer(Layer).X = Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "X"))
                Tile(Prefab).Layer(Layer).Y = Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Y"))
                Tile(Prefab).Layer(Layer).AutoTile = Val(myXml.ReadString("Prefab" & Prefab, "Layer" & Layer & "Autotile"))
            Next
            Tile(Prefab).Type = Val(myXml.ReadString("Prefab" & Prefab, "Type"))
        Next Prefab

        ResourcesNum = myXml.ReadString("Resources", "ResourcesNum")
        Resources = Split(ResourcesNum, ";")

    End Sub

    Sub LoadDetail(ByVal Prefab As TilePrefab, ByVal Tileset As Integer, ByVal X As Integer, ByVal Y As Integer, Optional TileType As Integer = 0, Optional EndX As Integer = 0, Optional EndY As Integer = 0)
        If EndX = 0 Then EndX = X
        If EndY = 0 Then EndY = Y

        Dim pX As Integer, pY As Integer
        For pX = X To EndX
            For pY = Y To EndY
                AddDetail(Prefab, Tileset, pX, pY, TileType)
            Next pY
        Next pX

    End Sub

    Sub AddDetail(ByVal Prefab As TilePrefab, ByVal Tileset As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal TileType As Integer)
        Dim DetailCount As Integer
        DetailCount = UBound(Detail) + 1

        ReDim Preserve Detail(0 To DetailCount)
        ReDim Preserve Detail(DetailCount).Tile.Layer(0 To MapLayer.Count - 1)

        Detail(DetailCount).DetailBase = Prefab
        Detail(DetailCount).Tile.Type = TileType
        Detail(DetailCount).Tile.Layer(3).Tileset = Tileset
        Detail(DetailCount).Tile.Layer(3).x = X
        Detail(DetailCount).Tile.Layer(3).y = Y
    End Sub

    Sub LoadDetails()
        ReDim Detail(0 To 1)

        'Detail config area
        'Use: LoadDetail TilePrefab, Tileset, StartTilesetX, StartTilesetY, TileType, EndTilesetX, EndTilesetY
        LoadDetail(TilePrefab.Grass, 9, 0, 0, TileType.None, 7, 7)
        LoadDetail(TilePrefab.Grass, 9, 0, 10, TileType.None, 6, 15)
        LoadDetail(TilePrefab.Grass, 9, 0, 13, TileType.None, 7, 14)
        LoadDetail(TilePrefab.Sand, 10, 0, 13, TileType.None, 7, 14)
        LoadDetail(TilePrefab.Sand, 11, 0, 0, TileType.None, 1, 1)
    End Sub

End Module
