Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports VBASPNETMVC5Playground

Namespace Controllers
    Public Class WorkTasksController
        Inherits System.Web.Mvc.Controller

        Private db As New MainDbContext

        ' GET: WorkTasks
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.WorkTasks.ToListAsync())
        End Function

        ' GET: WorkTasks/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workTask As WorkTask = Await db.WorkTasks.FindAsync(id)
            If IsNothing(workTask) Then
                Return HttpNotFound()
            End If
            Return View(workTask)
        End Function

        ' GET: WorkTasks/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: WorkTasks/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Id,Title,Description")> ByVal workTask As WorkTask) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.WorkTasks.Add(workTask)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(workTask)
        End Function

        ' GET: WorkTasks/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workTask As WorkTask = Await db.WorkTasks.FindAsync(id)
            If IsNothing(workTask) Then
                Return HttpNotFound()
            End If
            Return View(workTask)
        End Function

        ' POST: WorkTasks/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="Id,Title,Description")> ByVal workTask As WorkTask) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(workTask).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(workTask)
        End Function

        ' GET: WorkTasks/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workTask As WorkTask = Await db.WorkTasks.FindAsync(id)
            If IsNothing(workTask) Then
                Return HttpNotFound()
            End If
            Return View(workTask)
        End Function

        ' POST: WorkTasks/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim workTask As WorkTask = Await db.WorkTasks.FindAsync(id)
            db.WorkTasks.Remove(workTask)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
