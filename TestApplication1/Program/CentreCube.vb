Public Class CentreCube : Inherits GameObject

    Private velocity As Double = 0
    Private carryVelocity As Double = 0

    Public Sub New(ByVal position As PointF, ByVal size As SizeF)
        MyBase.New(position, size)
    End Sub

    Public Overrides Sub Update()
        HandleCollisions()
        If KeyManager.IsPressed(Keys.Space) Then
            velocity = -6 + carryVelocity
            carryVelocity = Math.Min(carryVelocity - 0.1, -2)
        Else
            carryVelocity = 0
        End If

        velocity += 1
        Position = New PointF(Position.X, Position.Y + velocity)
    End Sub

    ' Bad way of doing this but it's a crap game so who cares
    ' Accessing the GameObjectManager here isn't the most efficient
    Private Sub HandleCollisions()
        ' Check to see if player leaves the screen up or down on y
        If Position.Y >= Program.WindowSize.Height - Bounds.Height Or Position.Y < 0 Then
            Die()
        End If

        ' Check collisions for collision bars
        For Each obj As GameObject In GameState.GameObjectManager.Objects
            If obj.GetType() Is GetType(CollisionBar) Then
                Dim collisionBar As CollisionBar = TryCast(obj, CollisionBar)
                Dim currentBounds As RectangleF = New RectangleF(Position, New SizeF(Bounds.Width, Bounds.Height))

                If currentBounds.IntersectsWith(collisionBar.TopBounds) Or currentBounds.IntersectsWith(collisionBar.BottomBounds) Then
                    Die()
                End If
            End If
        Next
    End Sub

    Public Overrides Sub Render(ByVal device As System.Drawing.Graphics)
        GlobalRender.FillRect(Brushes.Red, Position, GetSize())
    End Sub

    Private Sub Die()
        If KeyManager.IsPressed(Keys.Space) Then
            GameState.ShouldStartAgain = False
        End If
        GameState.GameOver = True
    End Sub
End Class
