Imports System.Drawing

Public Module ClientHotBar
    Public SelHotbarSlot As Integer
    Public SelSkillSlot As Boolean

    Public Const MAX_HOTBAR As Byte = 7

    'hotbar constants
    Public Const HotbarTop As Byte = 2
    Public Const HotbarLeft As Byte = 2
    Public Const HotbarOffsetX As Byte = 4

    Public Structure HotbarRec
        Dim Slot As Integer
        Dim sType As Byte
    End Structure

    Public Function IsHotBarSlot(ByVal X As Single, ByVal Y As Single) As Integer
        Dim tempRec As RECT
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

    Public Sub SendSetHotbarSkill(ByVal Slot As Integer, ByVal Skill As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CSetHotbarSkill)

        Buffer.WriteInteger(Slot)
        Buffer.WriteInteger(Skill)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Public Sub SendDeleteHotbar(ByVal Slot As Integer)
        Dim Buffer As ByteBuffer

        Buffer = New ByteBuffer
        Buffer.WriteInteger(ClientPackets.CDeleteHotbarSkill)

        Buffer.WriteInteger(Slot)

        SendData(Buffer.ToArray())
        Buffer = Nothing
    End Sub

    Sub DrawHotbar()
        Dim i As Integer, skillnum As Integer, skillpic As Integer
        Dim rec As Rectangle, rec_pos As Rectangle
        If NumItems = 0 Then Exit Sub

        RenderTextures(HotBarGFX, GameWindow, HotbarX, HotbarY, 0, 0, HotBarGFXInfo.Width, HotBarGFXInfo.Height)

        For i = 1 To MAX_HOTBAR
            skillnum = PlayerSkills(Player(MyIndex).Hotbar(i).Slot)

            If skillnum > 0 Then
                skillpic = Skill(skillnum).Icon

                If SkillIconsGFXInfo(skillpic).IsLoaded = False Then
                    LoadTexture(skillpic, 9)
                End If

                'seeying we still use it, lets update timer
                With SkillIconsGFXInfo(skillpic)
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

                RenderTextures(SkillIconsGFX(skillpic), GameWindow, rec_pos.X, rec_pos.Y, rec.X, rec.Y, rec.Width, rec.Height)
            End If

        Next

    End Sub
End Module
