Public Class GlobalRender

    Private Shared Property Device() As Graphics
    Private Shared _renderFont As Font

    Public Shared Sub UpdateDevice(ByRef device As Graphics)
        GlobalRender.Device = device
    End Sub

    Public Shared Sub ClearDisplay(ByRef size As Size)
        Device.FillRectangle(Brushes.White, New Rectangle(0, 0, size.Width, size.Height))
    End Sub

    Public Shared Sub FillRect(ByVal brush As Brush, ByRef position As PointF, ByRef size As SizeF)
        Device.FillRectangle(brush, New RectangleF(position, size))
    End Sub

    Public Shared Sub ResetTransform()
        Device.ResetTransform()
    End Sub

    Public Shared Sub Scale(ByVal scale As Double, ByVal x As Double, ByVal y As Double)
        ResetTransform()
        Device.TranslateTransform(x, y)
        Device.ScaleTransform(scale, scale)
        Device.TranslateTransform(-x, -y)
    End Sub

    ' Font rendering
    Public Shared Sub InitFont(ByVal name As String, ByVal size As Integer, ByVal style As FontStyle)
        _renderFont = New Font(name, size, style)
    End Sub

    Public Shared Sub DrawString(ByVal text As String, ByVal position As PointF, ByVal colour As Brush)
        Device.DrawString(text, _renderFont, colour, position)
    End Sub

    Public Shared Sub DrawCentredString(ByVal text As String, ByVal position As PointF, ByVal colour As Brush)
        Dim stringBounds As SizeF = Device.MeasureString(text, _renderFont)
        Dim centre As PointF = New PointF(position.X - (stringBounds.Width / 2), position.Y - (stringBounds.Height / 2))
        Device.DrawString(text, _renderFont, colour, centre)
    End Sub
End Class
