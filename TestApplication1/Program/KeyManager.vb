Public Class KeyManager

    Private Shared keys(256) As Boolean

    Public Shared Sub OnKeyPress(ByVal key As Integer)
        keys(key) = True
    End Sub

    Public Shared Sub OnKeyRelease(ByVal key As Integer)
        keys(key) = False
        GameState.ShouldStartAgain = True
    End Sub

    Public Shared Function IsPressed(ByVal key As Integer) As Boolean
        Return keys(key)
    End Function

End Class
