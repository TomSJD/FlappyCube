Public Class MenuState : Inherits State

    Private _titleScaleAnimation As Double = 1
    Private _titlePosition As PointF
    Private _animateDir As Boolean = True
    Private _endPos As Double = 3

    Private _changingState As Boolean = False

    Public Sub New()
        _titlePosition = New PointF(Program.WindowSize.Width / 2, Program.WindowSize.Height / 4)
    End Sub

    Public Overrides Sub Render(ByRef device As System.Drawing.Graphics)
        GlobalRender.Scale(_titleScaleAnimation, _titlePosition.X, _titlePosition.Y)
        GlobalRender.DrawCentredString("Flappy Cube", _titlePosition, Brushes.Black)
        GlobalRender.ResetTransform()

        GlobalRender.DrawCentredString("Press [space] to start a new game!", New PointF(Program.WindowSize.Width / 2, Program.WindowSize.Height / 2), Brushes.Black)
    End Sub

    Public Overrides Sub Update()
        AnimateTitle()

        If Not _changingState And KeyManager.IsPressed(Keys.Space) Then
            _changingState = True
            Program.ActiveState = New GameState()
        End If
    End Sub

    Private Sub AnimateTitle()
        If _titleScaleAnimation >= 3 Then
            _endPos = 1
            _animateDir = False
        ElseIf _titleScaleAnimation <= 1 Then
            _endPos = 3
            _animateDir = True
        End If
        _titleScaleAnimation = Utils.Animate(_titleScaleAnimation, _endPos, 0.05)
    End Sub
End Class
