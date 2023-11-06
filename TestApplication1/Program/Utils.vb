Public Class Utils
    Public Shared Function RandomInRangeInt(ByVal lowerbound As Integer, ByVal upperbound As Integer)
        Randomize()
        Return Int((upperbound - lowerbound + 1) * Rnd() + lowerbound)
    End Function

    ' Simple linear animation function I ported from one of my java projects to VB :0
    Public Shared Function Animate(ByVal value As Double, ByVal endPos As Double, ByVal speed As Double) As Double
        Dim movement As Double = (endPos - value) * speed
        If movement > 0 Then
            movement = Math.Max(speed, movement)
            movement = Math.Min(endPos - value, movement)
        ElseIf movement < 0 Then
            movement = Math.Min(-speed, movement)
            movement = Math.Max(endPos - value, movement)
        End If
        Return value + movement
    End Function

End Class
