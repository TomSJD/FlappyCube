Public MustInherit Class GameObject

    Private _position As PointF
    Private _bounds As RectangleF

    Public Sub New(ByVal position As PointF, ByVal size As SizeF)
        Me._position = position
        Me._bounds = New RectangleF(_position.X, _position.Y, size.Width, size.Height)
    End Sub

    Public MustOverride Sub Update()
    Public MustOverride Sub Render(ByVal device As Graphics)

    Public Property Position As PointF
        Get
            Return _position
        End Get
        Set(ByVal value As PointF)
            Me._position = value
        End Set
    End Property

    Public Property Bounds As RectangleF
        Get
            Return Me._bounds
        End Get
        Set(ByVal value As RectangleF)
            Me._bounds = value
        End Set
    End Property

    Public Function GetSize() As SizeF
        Return New SizeF(Bounds.Width, Bounds.Height)
    End Function
End Class
