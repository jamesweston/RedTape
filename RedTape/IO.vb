Namespace IO
    Public Class Serialize
        Public Sub SerializeToFile(ByVal path As String, ByVal obj As Object)
            Using fs As New Global.System.IO.FileStream(path, Global.System.IO.FileMode.Create)
                Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing, _
                   New Runtime.Serialization.StreamingContext(Runtime.Serialization.StreamingContextStates.File))
                bf.Serialize(fs, obj)
            End Using
        End Sub
        Public Function DeSerializeFromFile(ByVal path As String) As Object
            Using fs As New Global.System.IO.FileStream(path, Global.System.IO.FileMode.Open)
                Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing, _
                   New Runtime.Serialization.StreamingContext(Runtime.Serialization.StreamingContextStates.File))
                Return DirectCast(bf.Deserialize(fs), Object)
            End Using
        End Function
    End Class
End Namespace
