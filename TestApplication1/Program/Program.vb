Public Class Program

    Private _form As Form
    Private _title As String
    Private Shared _windowSize As Size

    Private Property Device() As Graphics

    Private _pb As PictureBox
    Private _surface As Bitmap

    ' States
    Private Shared _state As State

    Public WithEvents UpdateTimer As Timer

    Public Sub New(ByRef form As Form, ByVal title As String, ByVal size As Size)
        Me._form = form
        Me._title = title
        _windowSize = size

        _pb = New PictureBox With {
        .Parent = Me._form,
        .Dock = DockStyle.Fill,
        .Location = New Point(0, 0),
        .Size = _windowSize,
        .BackColor = Color.White
        }

        Me._form.Text = Me._title
        Me._form.FormBorderStyle = FormBorderStyle.FixedSingle
        Me._form.MaximizeBox = False
        Me._form.Size = _windowSize

        Me._surface = New Bitmap(Me._form.Size.Width, Me._form.Size.Height)
        Me._pb.Image = Me._surface

        Device() = Graphics.FromImage(Me._surface)

        ' Init font renderer
        GlobalRender.InitFont("Arial", 18, FontStyle.Bold)

        _state = New MenuState()
    End Sub

    Public Sub InitTimer(ByVal tickRate As Double)
        UpdateTimer = New Timer With {
        .Interval = tickRate,
        .Enabled = True
        }
    End Sub

    Public Sub Update()
        _state.Update()
    End Sub

    Public Sub Draw()
        GlobalRender.UpdateDevice(Device())
        GlobalRender.ClearDisplay(_windowSize)

        _state.Render(Device)

        Me._pb.Image = Me._surface
    End Sub

    Protected Overrides Sub Finalize()
        Me.Device.Dispose()
        Me._surface.Dispose()
        Me._pb.Dispose()
        Me.UpdateTimer.Dispose()
    End Sub

    Public Shared ReadOnly Property WindowSize As SizeF
        Get
            Return _windowSize
        End Get
    End Property

    Public Shared Property ActiveState As State
        Get
            Return _state
        End Get
        Set(ByVal value As State)
            _state = value
        End Set
    End Property

End Class
