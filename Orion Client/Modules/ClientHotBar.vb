Imports System.Drawing
Imports SFML.Graphics

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
        Dim rec As Rectangle, rec2 As Rectangle, rec_pos As Rectangle
        Dim tmpSprite2 As Sprite = New Sprite(HotBarGFX)
        If NumItems = 0 Then Exit Sub

        HotbarWindow.Clear(ToSFMLColor(frmMainGame.pnlHotBar.BackColor))

        With rec2
            .Y = 0
            .Height = frmMainGame.pnlHotBar.Height
            .X = 0
            .Width = frmMainGame.pnlHotBar.Width
        End With

        tmpSprite2.TextureRect = New IntRect(rec2.X, rec2.Y, rec2.Width, rec2.Height)
        tmpSprite2.Position = New SFML.System.Vector2f(0, 0)
        HotbarWindow.Draw(tmpSprite2)

        For i = 1 To MAX_HOTBAR
            spellnum = Player(MyIndex).Hotbar(i).Slot

            If spellnum > 0 Then
                spellpic = Spell(spellnum).Icon

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
                    .Y = HotbarTop
                    .Height = PIC_Y
                    .X = HotbarLeft + ((HotbarOffsetX + 32) * (((i - 1))))
                    .Width = PIC_X
                End With

                Dim tmpSprite As Sprite = New Sprite(SpellIconsGFX(spellpic))
                tmpSprite.TextureRect = New IntRect(rec.X, rec.Y, rec.Width, rec.Height)
                tmpSprite.Position = New SFML.System.Vector2f(rec_pos.X, rec_pos.Y)
                HotbarWindow.Draw(tmpSprite)
            End If

        Next
        HotbarWindow.Display()
    End Sub
End Module
