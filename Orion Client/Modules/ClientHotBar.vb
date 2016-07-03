Imports System.Drawing

Public Module ClientHotBar
    Public SelHotbarSlot As Long
    Public SelSpellSlot As Boolean

    Public Const MAX_HOTBAR As Byte = 7

    'hotbar constants
    Public Const HotbarTop As Byte = 2
    Public Const HotbarLeft As Byte = 2
    Public Const HotbarOffsetX As Byte = 4

    Public Structure HotbarRec
        Dim Slot As Long
        Dim sType As Byte
    End Structure

    Public Function IsHotBarSlot(ByVal X As Single, ByVal Y As Single) As Long
        Dim tempRec As RECT
        Dim i As Long

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

    Public Sub SendSetHotbarSkill(ByVal Slot As Long, ByVal Skill As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CSetHotbarSkill)

        Buffer.WriteLong(Slot)
        Buffer.WriteLong(Skill)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendDeleteHotbar(ByVal Slot As Long)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteLong(ClientPackets.CDeleteHotbarSkill)

        Buffer.WriteLong(Slot)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub DrawHotbar()
        Dim i As Long, spellnum As Long, spellpic As Long
        Dim rec As Rectangle, rec_pos As Rectangle
        If NumItems = 0 Then Exit Sub

        RenderTexture(HotBarGFX, GameWindow, HotbarX, HotbarY, 0, 0, HotBarGFXInfo.width, HotBarGFXInfo.height)

        For i = 1 To MAX_HOTBAR
            spellnum = Player(MyIndex).Hotbar(i).Slot

            If spellnum > 0 Then
                spellpic = Spell(spellnum).Icon

                If SpellIconsGFXInfo(spellpic).IsLoaded = False Then
                    LoadTexture(spellpic, 9)
                End If

                'seeying we still use it, lets update timer
                With SpellIconsGFXInfo(spellpic)
                    .TextureTimer = GetTickCount() + 100000
                End With

                With rec
                    .Y = 0
                    .Height = 32
                    .X = 0
                    .Width = 32
                End With

                If Not SpellCD(i) = 0 Then
                    rec.X = 32
                    rec.Width = 32
                End If

                With rec_pos
                    .Y = HotbarY + HotbarTop
                    .Height = PIC_Y
                    .X = HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * (((i - 1))))
                    .Width = PIC_X
                End With

                RenderTexture(SpellIconsGFX(spellpic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
            End If

        Next

    End Sub
End Module
