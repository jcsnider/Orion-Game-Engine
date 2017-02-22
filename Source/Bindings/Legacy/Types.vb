Module Types
    Public Structure RandInvRec
        Dim Prefix As String
        Dim Suffix As String
        Dim Stat() As Integer
        Dim Rarity As Integer
        Dim Damage As Integer
        Dim Speed As Integer
    End Structure

    Public Structure ResourceSkillsRec
        Dim SkillLevel As Integer
        Dim SkillCurExp As Integer
        Dim SkillNextLvlExp As Integer
    End Structure

    Public Structure AnimationRec
        Dim Name As String
        Dim Sprite() As Integer
        Dim Frames() As Integer
        Dim LoopCount() As Integer
        Dim LoopTime() As Integer
    End Structure

    Public Structure Rect
        Dim Top As Integer
        Dim Left As Integer
        Dim Right As Integer
        Dim Bottom As Integer
    End Structure

    Public Structure ResourceRec
        Dim Name As String
        Dim SuccessMessage As String
        Dim EmptyMessage As String
        Dim ResourceType As Integer
        Dim ResourceImage As Integer
        Dim ExhaustedImage As Integer
        Dim ExpReward As Integer
        Dim ItemReward As Integer
        Dim LvlRequired As Integer
        Dim ToolRequired As Integer
        Dim Health As Integer
        Dim RespawnTime As Integer
        Dim Walkthrough As Boolean
        Dim Animation As Integer
    End Structure

    Public Structure SkillRec
        Dim Name As String
        Dim Type As Byte
        Dim MpCost As Integer
        Dim LevelReq As Integer
        Dim AccessReq As Integer
        Dim ClassReq As Integer
        Dim CastTime As Integer
        Dim CdTime As Integer
        Dim Icon As Integer
        Dim Map As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Dir As Byte
        Dim Vital As Integer
        Dim Duration As Integer
        Dim Interval As Integer
        Dim Range As Integer
        Dim IsAoE As Boolean
        Dim AoE As Integer
        Dim CastAnim As Integer
        Dim SkillAnim As Integer
        Dim StunDuration As Integer

        'projectiles
        Dim IsProjectile As Integer '0 is no, 1 is yes
        Dim Projectile As Integer

        Dim KnockBack As Byte '0 is no, 1 is yes
        Dim KnockBackTiles As Byte
    End Structure

    Public Structure ShopRec
        Dim Name As String
        Dim Face As Byte
        Dim BuyRate As Integer
        Dim TradeItem() As TradeItemRec
    End Structure
End Module
