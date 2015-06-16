Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Public Class WorkTask

    Public Property Id As Integer
    <Required>
    Public Property Title As String
    Public Property Description As String

End Class


Public Class MainDbContext
    Inherits DbContext


    Public Property WorkTasks() As DbSet(Of WorkTask)

End Class