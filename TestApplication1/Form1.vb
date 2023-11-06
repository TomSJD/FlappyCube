Public Class Form1

    Protected Property Program() As Program

    Private WithEvents _timer As Timer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Program = New Program(Me, "Flappy Cube", New Size(800, 600))
        Program.InitTimer(1000 / 60D)
        Me._timer = Program.UpdateTimer

    End Sub

    Public Sub TimerUpdate(ByVal sender As Object, ByVal e As EventArgs) Handles _timer.Tick
        Program.Update()
        Program.Draw()
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.FormClosed
        Program() = Nothing
    End Sub

    Private Sub KeyDownEvent(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        KeyManager.OnKeyPress(e.KeyCode)
    End Sub

    Private Sub KeyUpEvent(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        KeyManager.OnKeyRelease(e.KeyCode)
    End Sub
End Class
