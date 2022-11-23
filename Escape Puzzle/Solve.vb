Public Class Solve
    Private Sub Solve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Class State
        Dim p As Long
        Dim c As Long()
        Dim s As String(,)

        Private Sub Size(x As Long, y As Long)
            ReDim s(x, y)
        End Sub

        Private Function Place() As String(,)
            Return s
        End Function

        Private Sub SetP(n As Long)
            p = n
        End Sub

        Private Sub SetC(n As Long)
            ReDim Preserve c(c.Length)
            c(c.Length - 1) = n
        End Sub
    End Class
End Class