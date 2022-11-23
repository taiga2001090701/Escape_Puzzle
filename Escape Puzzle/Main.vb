Public Class Main
    Private Sub BP_Click(sender As Object, e As EventArgs) Handles BP.Click
        Hide()
        Dim fp As New Play
        fp.ShowDialog(Me)
        fp.Dispose()
        Show()
    End Sub

    Private Sub BC_Click(sender As Object, e As EventArgs) Handles BC.Click
        Hide()
        Dim fc As New Create
        fc.ShowDialog(Me)
        fc.Dispose()
        Show()
    End Sub

    Private Sub BS_Click(sender As Object, e As EventArgs) Handles BS.Click
        Hide()
        Dim fs As New Solve
        fs.ShowDialog(Me)
        fs.Dispose()
        Show()
    End Sub
End Class