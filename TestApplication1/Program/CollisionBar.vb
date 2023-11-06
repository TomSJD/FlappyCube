Public Class CollisionBar : Inherits GameObject

    Private _barOffset As Integer

    Private _topBarBounds As RectangleF = New RectangleF()
    Private _bottomBarBounds As RectangleF = New RectangleF()

    Private _pastPlayer As Boolean = False

    Public Sub New(ByVal position As PointF, ByVal size As SizeF)
        MyBase.New(position, size)
        _barOffset = Utils.RandomInRangeInt(Program.WindowSize.Height / 8, Program.WindowSize.Height / 1.5)
    End Sub

    Public Overrides Sub Render(ByVal device As System.Drawing.Graphics)
        ' Render top bar
        Dim renderPos As PointF = New PointF(Position.X, 0)
        Dim renderSize As SizeF = New SizeF(Bounds.Width, _barOffset)
        _topBarBounds = New RectangleF(renderPos, renderSize)
        GlobalRender.FillRect(Brushes.Blue, renderPos, renderSize)

        ' Render bottom bar
        renderPos = New PointF(Position.X, _barOffset + 160)
        renderSize = New SizeF(Bounds.Width, Program.WindowSize.Height - _barOffset - 160)
        _bottomBarBounds = New RectangleF(renderPos, renderSize)
        GlobalRender.FillRect(Brushes.Blue, renderPos, renderSize)
    End Sub

    Public Overrides Sub Update()
        Position = New PointF(Position.X - 10, Position.Y)

        ' Remove if off screen
        If Position.X < -100 Then
            GameState.GameObjectManager.RemoveObject(Me)
        End If

        If Not _pastPlayer And Position.X < Program.WindowSize.Width / 2 Then
            GameState.IncrementScore()
            _pastPlayer = True
        End If
    End Sub

    Public ReadOnly Property TopBounds As RectangleF
        Get
            Return _topBarBounds
        End Get
    End Property

    Public ReadOnly Property BottomBounds As RectangleF
        Get
            Return _bottomBarBounds
        End Get
    End Property
End Class
