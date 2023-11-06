Public MustInherit Class State
    Public MustOverride Sub Update()
    Public MustOverride Sub Render(ByRef device As Graphics)
End Class
