Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Added_TaskComment
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.TaskComments",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Comment = c.String(),
                        .WorkTask_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.WorkTasks", Function(t) t.WorkTask_Id) _
                .Index(Function(t) t.WorkTask_Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.TaskComments", "WorkTask_Id", "dbo.WorkTasks")
            DropIndex("dbo.TaskComments", New String() { "WorkTask_Id" })
            DropTable("dbo.TaskComments")
        End Sub
    End Class
End Namespace
