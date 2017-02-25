Imports System.Drawing

Public Module ClientHotBar
    Public SelHotbarSlot As Integer
    Public SelSkillSlot As Boolean

    Public Const MAX_HOTBAR As Byte = 7

    'hotbar constants
    Public Const HotbarTop As Byte = 2
    Public Const HotbarLeft As Byte = 2
    Public Const HotbarOffsetX As Byte = 2

    Public Structure HotbarRec
        Dim Slot As Integer
        Dim sType As Byte
    End Structure

    Public Function IsHotBarSlot(ByVal X As Single, ByVal Y As Single) As Integer
        Dim tempRec As Rect
        Dim i As Integer

        IsHotBarSlot = 0

        For i = 1 To MAX_HOTBAR
            With tempRec
                .top = HotbarY + HotbarTop
                .bottom = .top + PIC_Y
                .left = HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * (((i - 1) Mod MAX_HOTBAR)))
                .right = .left + PIC_X
            End With

            If X >= tempRec.left And X <= tempRec.right Then
                If Y >= tempRec.top And Y <= tempRec.bottom Then
                    IsHotBarSlot = i
                    Exit Function
                End If
            End If
        Next

    End Function

    Public Sub SendSetHotbarSlot(ByVal Slot As Integer, ByVal Num As Integer, ByVal Type As Integer)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CSetHotbarSlot)

        Buffer.WriteInteger(Slot)
        Buffer.WriteInteger(Num)
        Buffer.WriteInteger(Type)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendDeleteHotbar(ByVal Slot As Integer)
        Dim Buffer As New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CDeleteHotbarSlot)

        Buffer.WriteInteger(Slot)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendUseHotbarSlot(ByVal Slot As Integer)
        Dim Buffer As New ByteBuffer

        Buffer.WriteInteger(ClientPackets.CUseHotbarSlot)

        Buffer.WriteInteger(Slot)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub DrawHotbar()
        Dim i As Integer, num As Integer, pic As Integer
        Dim rec As Rectangle, rec_pos As Rectangle

        RenderSprite(HotBarSprite, GameWindow, HotbarX, HotbarY, 0, 0, HotBarGFXInfo.Width, HotBarGFXInfo.Height)

        For i = 1 To MAX_HOTBAR
            If Player(MyIndex).Hotbar(i).sType = 1 Then
                num = PlayerSkills(Player(MyIndex).Hotbar(i).Slot)

                If num > 0 Then
                    pic = Skill(num).Icon

                    If SkillIconsGFXInfo(pic).IsLoaded = False Then
                        LoadTexture(pic, 9)
                    End If

                    'seeying we still use it, lets update timer
                    With SkillIconsGFXInfo(pic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
                        .Width = 32
                    End With

                    If Not SkillCD(i) = 0 Then
                        rec.X = 32
                        rec.Width = 32
                    End If

                    With rec_pos
                        .Y = HotbarY + HotbarTop
                        .Height = PIC_Y
                        .X = HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * (((i - 1))))
                        .Width = PIC_X
                    End With

                    RenderSprite(SkillIconsSprite(pic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
                End If

            ElseIf Player(MyIndex).Hotbar(i).sType = 2 Then
                num = PlayerInv(Player(MyIndex).Hotbar(i).Slot).Num

                If num > 0 Then
                    pic = Item(num).Pic

                    If ItemsGFXInfo(pic).IsLoaded = False Then
                        LoadTexture(pic, 4)
                    End If

                    'seeying we still use it, lets update timer
                    With ItemsGFXInfo(pic)
                        .TextureTimer = GetTickCount() + 100000
                    End With

                    With rec
                        .Y = 0
                        .Height = 32
                        .X = 0
                        .Width = 32
                    End With

                    With rec_pos
                        .Y = HotbarY + HotbarTop
                        .Height = PIC_Y
                        .X = HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * (((i - 1))))
                        .Width = PIC_X
                    End With

                    RenderSprite(ItemsSprite(pic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
                End If
            End If
        Next

    End Sub
End Module