Public Class GameState : Inherits State

    Public Const DEBUG As Boolean = False

    Private Shared _gameObjManager As GameObjectManager
    Private Shared _player As CentreCube
    Public Shared GameOver As Boolean = False
    Private Shared _score As Integer = 0
    Public Shared ShouldStartAgain As Boolean = True

    Public Sub New()
        ' Init Game object manager
        _gameObjManager = New GameObjectManager()

        ' Init player
        _player = New CentreCube(New PointF((Program.WindowSize.Width / 2) - 25, (Program.WindowSize.Height / 2) - 25), New SizeF(50, 50))
        GameObjectManager.AddObject(_player)
    End Sub

    Public Overrides Sub Render(ByRef device As System.Drawing.Graphics)
        ' Render game objects
        GameObjectManager.Render(device)

        ' Render other game things like game over screen and score if the player has not lost.
        If GameOver Then
            GlobalRender.DrawCentredString("Game Over!", New PointF(Program.WindowSize.Width / 2, Program.WindowSize.Height / 2 - 100), Brushes.Black)
            GlobalRender.DrawCentredString("Your final score was " + _score.ToString() + ".", New PointF(Program.WindowSize.Width / 2, Program.WindowSize.Height / 2 - 80), Brushes.Black)
            GlobalRender.DrawCentredString("Press [space] to start a new game.", New PointF(Program.WindowSize.Width / 2, Program.WindowSize.Height / 2 - 60), Brushes.Black)
        Else
            GlobalRender.DrawCentredString("Score: " + _score.ToString(), New PointF(Program.WindowSize.Width / 2, 12), Brushes.Black)
        End If

        If Debug Then
            RenderDebug()
        End If
    End Sub

    Public Overrides Sub Update()
        If GameOver And KeyManager.IsPressed(Keys.Space) And ShouldStartAgain Then
            GameObjectManager.ClearLevel()
            _player.Position = New PointF((Program.WindowSize.Width / 2) - 25, (Program.WindowSize.Height / 2) - 25)
            _score = 0
            GameOver = False
        End If

        If Not GameOver Then
            If GameObjectManager.Objects.Count < 6 Then
                GameObjectManager.AddObject(New CollisionBar(New PointF(
                                            Program.WindowSize.Width + ((GameObjectManager.Objects.Count - 1) * 400), 0),
                                            New SizeF(100, 100)))
            End If
            GameObjectManager.Update()
        End If
    End Sub

    ' Player property
    ' Allows the player class to be accessed anywhere for game logic
    Public Shared ReadOnly Property Player As CentreCube
        Get
            Return _player
        End Get
    End Property

    ' Game object manager property
    ' Allows objects to be added or removed from anywhere in the game
    Public Shared ReadOnly Property GameObjectManager As GameObjectManager
        Get
            Return _gameObjManager
        End Get
    End Property

    Private Sub RenderDebug()
        Dim debug1 As String = "Objects: " + GameObjectManager.Objects.Count.ToString()
        GlobalRender.DrawString(debug1, New PointF(6, 6), Brushes.Black)
    End Sub

    Public Shared Sub IncrementScore()
        _score += 1
    End Sub
End Class
