Public Class GameObjectManager

    Private _objects As List(Of GameObject) = New List(Of GameObject)
    ' Remove list for removing any game objects every update
    Private _removeList As List(Of GameObject) = New List(Of GameObject)

    Public Sub Update()
        HandleRemoveObjects()
        For Each gameObject In _objects
            gameObject.Update()
        Next
    End Sub

    Public Sub Render(ByVal device As Graphics)
        For Each gameObject In _objects
            gameObject.Render(device)
        Next
    End Sub

    Private Sub HandleRemoveObjects()
        For Each gameObj In _removeList
            _objects.Remove(gameObj)
        Next
        _removeList.Clear()
    End Sub

    Public Sub AddObject(ByVal gameObject As GameObject)
        _objects.Add(gameObject)
    End Sub

    Public Sub RemoveObject(ByVal gameObject As GameObject)
        _removeList.Add(gameObject)
    End Sub

    Public ReadOnly Property Objects As List(Of GameObject)
        Get
            Return _objects
        End Get
    End Property

    Public Sub ClearLevel()
        For i As Integer = 1 To _objects.Count - 1
            _removeList.Add(_objects(i))
        Next
        HandleRemoveObjects()
    End Sub

End Class
