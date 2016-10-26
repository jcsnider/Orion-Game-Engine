Module EditorLoop
    Sub GameLoop()
        Dim dest As Point = New Point(frmEditor_MapEditor.PointToScreen(frmEditor_MapEditor.picScreen.Location))
        Dim g As Graphics = frmEditor_MapEditor.picScreen.CreateGraphics
        Dim starttime As Integer, Tick As Integer ', fogtmr As Integer
        Dim FrameTime As Integer, tmr500 As Integer
        Dim destrect As Rectangle

        starttime = GetTickCount()

        Do
            If GameDestroyed = True Then End


            If GameStarted = True Then
                Tick = GetTickCount()

                frmLogin.Visible = True
                FrameTime = Tick
                If InMapEditor Then
                    SyncLock MapLock

                        ' fog scrolling
                        'If fogtmr < Tick Then
                        '    If CurrentFogSpeed > 0 Then
                        '        move
                        '        fogOffsetX = fogOffsetX - 1
                        '        fogOffsetY = fogOffsetY - 1
                        '        Reset()
                        '        If fogOffsetX < -256 Then fogOffsetX = 0
                        '        If fogOffsetY < -256 Then fogOffsetY = 0
                        '        fogtmr = Tick + 255 - CurrentFogSpeed
                        '    End If
                        'End If

                        If tmr500 < Tick Then
                            ' animate waterfalls
                            Select Case waterfallFrame
                                Case 0
                                    waterfallFrame = 1
                                Case 1
                                    waterfallFrame = 2
                                Case 2
                                    waterfallFrame = 0
                            End Select
                            ' animate autotiles
                            Select Case autoTileFrame
                                Case 0
                                    autoTileFrame = 1
                                Case 1
                                    autoTileFrame = 2
                                Case 2
                                    autoTileFrame = 0
                            End Select

                            tmr500 = Tick + 500
                        End If

                        ProcessWeather()

                        'Auctual Game Loop Stuff :/
                        Render_Graphics()

                        If FadeInSwitch = True Then
                            FadeIn()
                        End If

                        If FadeOutSwitch = True Then
                            FadeOut()
                        End If

                        destrect = New Rectangle(0, 0, ScreenX, ScreenY)
                        Application.DoEvents()


                        EditorMap_DrawTileset()
                    End SyncLock
                End If
            End If

            Application.DoEvents()
            Threading.Thread.Sleep(1)

        Loop
    End Sub
End Module
