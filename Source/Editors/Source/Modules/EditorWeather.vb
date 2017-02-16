Imports SFML.Audio
Imports SFML.Graphics
Imports SFML.Window

Public Module EditorWeather
    Public Const MAX_WEATHER_PARTICLES As Integer = 100

    Public WeatherParticle(0 To MAX_WEATHER_PARTICLES) As WeatherParticleRec
    Public WeatherSoundPlayer As Sound
    Public CurWeatherMusic As String

    Public Structure WeatherParticleRec
        Dim type As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Velocity As Integer
        Dim InUse As Integer
    End Structure

    Sub ProcessWeather()
        Dim i As Integer, x As Integer

        If CurrentWeather > 0 Then
            If CurrentWeather = Weather.Rain Or CurrentWeather = Weather.Storm Then
                PlayWeatherSound("Rain.ogg", True)
            End If
            x = Rand(1, 101 - CurrentWeatherIntensity)
            If x = 1 Then
                'Add a new particle
                For i = 1 To MAX_WEATHER_PARTICLES
                    If WeatherParticle(i).InUse = 0 Then
                        If Rand(1, 3) = 1 Then
                            WeatherParticle(i).InUse = 1
                            WeatherParticle(i).type = CurrentWeather
                            WeatherParticle(i).Velocity = Rand(8, 14)
                            WeatherParticle(i).X = (TileView.left * 32) - 32
                            WeatherParticle(i).Y = ((TileView.top * 32) + Rand(-32, GameWindow.Size.Y))
                        Else
                            WeatherParticle(i).InUse = 1
                            WeatherParticle(i).type = CurrentWeather
                            WeatherParticle(i).Velocity = Rand(10, 15)
                            WeatherParticle(i).X = ((TileView.left * 32) + Rand(-32, GameWindow.Size.X))
                            WeatherParticle(i).Y = (TileView.top * 32) - 32
                        End If
                        'Exit For
                    End If
                Next
            End If
        Else
            StopWeatherSound()
        End If
        If CurrentWeather = Weather.Storm Then
            x = Rand(1, 400 - CurrentWeatherIntensity)
            If x = 1 Then
                'Draw Thunder
                DrawThunder = Rand(15, 22)
                PlayExtraSound("Thunder.ogg")
            End If
        End If
        For i = 1 To MAX_WEATHER_PARTICLES
            If WeatherParticle(i).InUse = 1 Then
                If WeatherParticle(i).X > TileView.right * 32 Or WeatherParticle(i).Y > TileView.bottom * 32 Then
                    WeatherParticle(i).InUse = 0
                Else
                    WeatherParticle(i).X = WeatherParticle(i).X + WeatherParticle(i).Velocity
                    WeatherParticle(i).Y = WeatherParticle(i).Y + WeatherParticle(i).Velocity
                End If
            End If
        Next

    End Sub

    Public Sub DrawThunderEffect()
        If InMapEditor Then Exit Sub

        If DrawThunder > 0 Then
            Dim tmpSprite As Sprite
            tmpSprite = New Sprite(New Texture(New SFML.Graphics.Image(GameWindow.Size.X, GameWindow.Size.Y, SFML.Graphics.Color.White)))
            tmpSprite.Color = New Color(255, 255, 255, 150)
            tmpSprite.TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y)

            tmpSprite.Position = New Vector2f(0, 0)

            GameWindow.Draw(tmpSprite) '

            DrawThunder = DrawThunder - 1

            tmpSprite.Dispose()
        End If
    End Sub

    Public Sub DrawWeather()
        Dim i As Integer, SpriteLeft As Integer

        'If InMapEditor Then Exit Sub

        For i = 1 To MAX_WEATHER_PARTICLES
            If WeatherParticle(i).InUse Then
                If WeatherParticle(i).type = Weather.Storm Then
                    SpriteLeft = 0
                Else
                    SpriteLeft = WeatherParticle(i).type - 1
                End If
                RenderSprite(WeatherSprite, GameWindow, ConvertMapX(WeatherParticle(i).X), ConvertMapY(WeatherParticle(i).Y), SpriteLeft * 32, 0, 32, 32)
            End If
        Next

    End Sub

    Public Sub DrawFog()
        Dim fogNum As Integer

        'If InMapEditor Then Exit Sub

        fogNum = CurrentFog
        If fogNum <= 0 Or fogNum > NumFogs Then Exit Sub

        Dim horz As Integer = 0
        Dim vert As Integer = 0

        For x = TileView.left To TileView.right + 1
            For y = TileView.top To TileView.bottom + 1
                If IsValidMapPoint(x, y) Then
                    horz = -x
                    vert = -y
                End If
            Next
        Next

        If FogGFXInfo(fogNum).IsLoaded = False Then
            LoadTexture(fogNum, 8)
        End If

        'seeying we still use it, lets update timer
        With FogGFXInfo(fogNum)
            .TextureTimer = GetTickCount() + 100000
        End With

        Dim tmpSprite As Sprite
        tmpSprite = New Sprite(FogGFX(fogNum))
        tmpSprite.Color = New Color(255, 255, 255, CurrentFogOpacity)
        tmpSprite.TextureRect = New IntRect(0, 0, GameWindow.Size.X + 200, GameWindow.Size.Y + 200)

        tmpSprite.Position = New Vector2f((horz * 2.5) + 50, (vert * 3.5) + 50)
        tmpSprite.Scale = (New Vector2f(CDbl((GameWindow.Size.X + 200) / FogGFXInfo(fogNum).width), CDbl((GameWindow.Size.Y + 200) / FogGFXInfo(fogNum).height)))

        GameWindow.Draw(tmpSprite) '

    End Sub

    Sub PlayWeatherSound(ByVal FileName As String, Optional Looped As Boolean = False)
        If Not Options.Sound = 1 Or Not FileExist(Application.StartupPath & SOUND_PATH & FileName) Then Exit Sub
        If CurWeatherMusic = FileName Then Exit Sub

        Dim buffer As SoundBuffer
        If WeatherSoundPlayer Is Nothing Then
            WeatherSoundPlayer = New Sound()
        Else
            WeatherSoundPlayer.Stop()
        End If

        buffer = New SoundBuffer(Application.StartupPath & SOUND_PATH & FileName)
        WeatherSoundPlayer.SoundBuffer = buffer
        If Looped = True Then
            WeatherSoundPlayer.Loop() = True
        Else
            WeatherSoundPlayer.Loop() = False
        End If
        WeatherSoundPlayer.Volume() = MaxVolume
        WeatherSoundPlayer.Play()

        CurWeatherMusic = FileName
    End Sub

    Sub StopWeatherSound()
        If WeatherSoundPlayer Is Nothing Then Exit Sub
        WeatherSoundPlayer.Dispose()
        WeatherSoundPlayer = Nothing

        CurWeatherMusic = ""
    End Sub
End Module