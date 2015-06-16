Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Public Class WorkTask

    Public Property Id As Integer
    <Required>
    Public Property Title As String
    Public Property Description As String

    Public Property Comments As ICollection(Of TaskComment)

End Class

Public Class TaskComment
    Public Property Id As Integer
    Public Property Comment As String
End Class


Public Class MainDbContext
    Inherits DbContext


    Public Property WorkTasks() As DbSet(Of WorkTask)
    Public Property TaskComments() As DbSet(Of TaskComment)

End Class