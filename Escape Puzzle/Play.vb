Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class Play
    Dim gc, gr, lc, lr, cn, sc, ss As Integer 'Grid Column, Grid Row, Current Column, Current Row, Last Column, Last Row, Color Number, Space Check, Space Sum
    Dim cd(,), cdt(,), gl() As Integer 'Cell Data, Cell Data Temporary, Goal Length
    Dim mm As Byte 'Move Mode
    Dim ap, dp As String 'Answer Pattern, Default Pattern
    Dim ts, ms As String
    Dim mc, ac, nc As Integer 'Way, Move Count, Answer Count, Now Count
    Dim ofd As New OpenFileDialog()
    Dim rd() As Byte = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}
    Dim gd() As Byte = {0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255, 0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255, 0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255, 0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255}
    Dim bd() As Byte = {0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255}
    Private Sub Play_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Directory.CreateDirectory("Data")
        ofd.FileName = "*.epp"
        ofd.InitialDirectory = "\Data"
        ofd.Filter = "EPPファイル(*.epp)|*.epp"
        ofd.Title = "開くファイルを選択してください"
        If ofd.ShowDialog() = DialogResult.OK Then
            Console.WriteLine(ofd.FileName)
            Dim ti As Integer
            Dim sr As New StreamReader(ofd.FileName)
            ts = sr.ReadLine
            If ts = "<Size>" Then
                ts = sr.ReadLine
                Try
                    gc = CInt(ts.Substring(0, ts.IndexOf("-")))
                    gr = CInt(ts.Substring(ts.IndexOf("-") + 1, ts.Length - ts.IndexOf("-") - 1))
                Catch ex As Exception
                    MsgBox("ファイルが破損しています(E6)" & vbCrLf & "(" & ex.Message & ")")
                    sr.Close()
                    Close()
                    Exit Sub
                End Try
                ReDim cd(gc - 1, gr - 1)
                ReDim cdt(gc - 1, gr - 1)
                DGV.ColumnCount = gc
                DGV.RowCount = gr
                ts = sr.ReadLine
                If ts = "<Block>" Then
                    ts = sr.ReadLine
                    dp = ts
                    If CountChar(ts, "-") = gr - 1 Then
                        For b = 0 To gr - 1
                            ms = ts.Substring(2 * gc * b + b)
                            For a = 0 To gc - 1
                                Try
                                    cd(a, b) = ms.Substring(2 * a, 2)
                                Catch ex As Exception
                                    MsgBox("ファイルが破損しています(E7)" & vbCrLf & "(" & ex.Message & ")")
                                    sr.Close()
                                    Close()
                                    Exit Sub
                                End Try
                            Next
                        Next
                        ts = sr.ReadLine
                        If ts = "<Goal>" Then
                            ts = sr.ReadLine
                            ti = CountChar(ts, ",")
                            For i = 0 To ti
                                Try
                                    If i = ti Then
                                        ms = ts
                                    Else
                                        ms = ts.Substring(0, ts.IndexOf(","))
                                        ts = ts.Substring(ts.IndexOf(",") + 1)
                                    End If
                                    DGV(CInt(ms.Substring(0, ms.IndexOf("-"))), CInt(ms.Substring(ms.IndexOf("-") + 1))).Value = "GOAL"
                                Catch ex As Exception
                                    MsgBox("ファイルが破損しています(E8)" & vbCrLf & "(" & ex.Message & ")")
                                    sr.Close()
                                    Close()
                                    Exit Sub
                                End Try
                            Next
                            Try
                                ts = sr.ReadLine
                                ti = CountChar(ts, ",")
                                ReDim gl(ti)
                                For i = 0 To ti
                                    If i = ti Then
                                        gl(i) = ts
                                    Else
                                        gl(i) = ts.Substring(0, ts.IndexOf(","))
                                        ts = ts.Substring(ts.IndexOf(",") + 1)
                                    End If
                                Next
                            Catch ex As Exception
                                MsgBox("ファイルが破損しています(E9)" & vbCrLf & "(" & ex.Message & ")")
                                sr.Close()
                                Close()
                                Exit Sub
                            End Try
                            ts = sr.ReadLine
                            If ts = "<Answer>" Then
                                ap = sr.ReadLine
                                ac = CountChar(ap, "-")
                                sr.Close()
                            Else
                                MsgBox("ファイルが破損しています(E5)")
                                sr.Close()
                                Close()
                            End If
                        Else
                            MsgBox("ファイルが破損しています(E4)")
                            sr.Close()
                            Close()
                        End If
                    Else
                        MsgBox("ファイルが破損しています(E3)")
                        sr.Close()
                        Close()
                    End If
                Else
                    MsgBox("ファイルが破損しています(E2)")
                    sr.Close()
                    Close()
                End If
            Else
                MsgBox("ファイルが破損しています(E1)")
                sr.Close()
                Close()
            End If
            lc = 0
            lr = 0
            mc = 0
            For a = 0 To gc - 1
                For b = 0 To gr - 1
                    DGV(a, b).Style.BackColor = Color.FromArgb(rd(cd(a, b)), gd(cd(a, b)), bd(cd(a, b)))
                Next
            Next
            DGV_S(gc, gr, DGV.Width, DGV.Height)
            DGV.DefaultCellStyle.SelectionBackColor = Color.Gray
            DGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGV.DefaultCellStyle.ForeColor = Color.Gray
            DGV.DefaultCellStyle.Font = New Font("MS UI Gothic", 16, FontStyle.Bold)
            BackColor = DGV(0, 0).Style.BackColor
            LaC.Text = mc & " Time"
        Else
            Close()
        End If
        BL.Enabled = False
        BR.Enabled = False
    End Sub

    Public Shared Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString(), "").Length
    End Function

    Private Sub DGV_SizeChanged(sender As Object, e As EventArgs) Handles DGV.SizeChanged
        DGV_S(gc, gr, DGV.Width, DGV.Height)
    End Sub

    Private Sub DGV_Click(sender As Object, e As EventArgs) Handles DGV.Click
        DGV_C(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex)
        DGV_G()
    End Sub

    Private Sub DGV_S(c As Integer, r As Integer, w As Integer, h As Integer)
        For i = 0 To c - 1
            DGV.Columns(i).Width = w / c
        Next
        For i = 0 To r - 1
            DGV.Rows(i).Height = h / r
        Next
    End Sub

    Private Sub DGV_C(cc As Integer, cr As Integer)
        DGV.CurrentCell = Nothing
        cn = cd(lc, lr)
        If cd(cc, cr) < 63 AndAlso cd(cc, cr) <> cn Then
            lc = cc
            lr = cr
            BackColor = DGV(cc, cr).Style.BackColor
        ElseIf cd(cc, cr) = 63 AndAlso cn = 63 Then
            lc = cc
            lr = cr
        Else
            sc = 0
            ss = 0
            For a = 0 To gc - 1
                For b = 0 To gr - 1
                    If cd(a, b) = cn Then
                        ss += 1
                    End If
                Next
            Next
            mm = 0
            If cc = lc AndAlso cr = lr - 1 Then 'Up
                mm = 1
            ElseIf cc = lc + 1 AndAlso cr = lr Then 'Right
                mm = 2
            ElseIf cc = lc AndAlso cr = lr + 1 Then 'Down
                mm = 3
            ElseIf cc = lc - 1 AndAlso cr = lr Then 'Left
                mm = 4
            End If
            If mm > 0 Then
                For a = 0 To gc - 1
                    For b = 0 To gr - 1
                        If cd(a, b) <> cn Then
                            cdt(a, b) = cd(a, b)
                        Else
                            cdt(a, b) = 63
                        End If
                        If cd(a, b) = cn Then
                            Select Case mm
                                Case 1
                                    If b > 0 Then
                                        If cd(a, b - 1) = 63 OrElse cd(a, b - 1) = cn Then
                                            sc += 1
                                        End If
                                    End If
                                Case 2
                                    If a < gc - 1 Then
                                        If cd(a + 1, b) = 63 OrElse cd(a + 1, b) = cn Then
                                            sc += 1
                                        End If
                                    End If
                                Case 3
                                    If b < gr - 1 Then
                                        If cd(a, b + 1) = 63 OrElse cd(a, b + 1) = cn Then
                                            sc += 1
                                        End If
                                    End If
                                Case 4
                                    If a > 0 Then
                                        If cd(a - 1, b) = 63 OrElse cd(a - 1, b) = cn Then
                                            sc += 1
                                        End If
                                    End If
                            End Select
                        End If
                    Next
                Next
                If sc = ss Then
                    For a = 0 To gc - 1
                        For b = 0 To gr - 1
                            If cd(a, b) = cn Then
                                DGV(a, b).Style.BackColor = Color.FromArgb(rd(63), gd(63), bd(63))
                            End If
                        Next
                    Next
                    For a = 0 To gc - 1
                        For b = 0 To gr - 1
                            If cd(a, b) = cn Then
                                Select Case mm
                                    Case 1
                                        If b > 0 Then
                                            If cd(a, b - 1) = 63 OrElse cd(a, b - 1) = cn Then
                                                cdt(a, b - 1) = cn
                                                DGV(a, b - 1).Style.BackColor = Color.FromArgb(rd(cn), gd(cn), bd(cn))
                                            End If
                                        End If
                                    Case 2
                                        If a < gc - 1 Then
                                            If cd(a + 1, b) = 63 OrElse cd(a + 1, b) = cn Then
                                                cdt(a + 1, b) = cn
                                                DGV(a + 1, b).Style.BackColor = Color.FromArgb(rd(cn), gd(cn), bd(cn))
                                            End If
                                        End If
                                    Case 3
                                        If b < gr - 1 Then
                                            If cd(a, b + 1) = 63 OrElse cd(a, b + 1) = cn Then
                                                cdt(a, b + 1) = cn
                                                DGV(a, b + 1).Style.BackColor = Color.FromArgb(rd(cn), gd(cn), bd(cn))
                                            End If
                                        End If
                                    Case 4
                                        If a > 0 Then
                                            If cd(a - 1, b) = 63 OrElse cd(a - 1, b) = cn Then
                                                cdt(a - 1, b) = cn
                                                DGV(a - 1, b).Style.BackColor = Color.FromArgb(rd(cn), gd(cn), bd(cn))
                                            End If
                                        End If
                                End Select

                            End If
                        Next
                    Next
                    For a = 0 To gc - 1
                        For b = 0 To gr - 1
                            cd(a, b) = cdt(a, b)
                        Next
                    Next
                    mc += 1
                    If DGV.Enabled Then
                        If mc <= 1 Then
                            LaC.Text = mc & " Time"
                        Else
                            LaC.Text = mc & " Times"
                        End If
                    End If
                End If
            End If
            lc = cc
            lr = cr
            BackColor = DGV(cc, cr).Style.BackColor
        End If
    End Sub

    Private Sub DGV_G()
        For a = 0 To gc - 1
            For b = 0 To gr - 1
                If DGV(a, b).Value = "GOAL" Then
                    Dim ict As Integer
                    ict = 0
                    Select Case gl(0)
                        Case 1
                            For i = 1 To gl.Length - 1
                                For ii = 0 To gl(i) - 1
                                    If Not cd(a + i - 1, ii) = 0 Then
                                        If Not cd(a + i - 1, ii) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gl(i) - 1 Then
                                        If Not cd(a + i - 1, ii) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                        Case 2
                            For i = 1 To gl.Length - 1
                                For ii = 0 To gl(i) - 1
                                    If Not cd(gc - ii - 1, b + i - 1) = 0 Then
                                        If Not cd(gc - ii - 1, b + i - 1) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gl(i) - 1 Then
                                        If Not cd(gc - ii - 1, b + i - 1) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                        Case 3
                            For i = 1 To gl.Length - 1
                                For ii = 0 To gl(i) - 1
                                    If Not cd(a + i - 1, gr - ii - 1) = 0 Then
                                        If Not cd(a + i - 1, gr - ii - 1) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gl(i) - 1 Then
                                        If Not cd(a + i - 1, gr - ii - 1) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                        Case 4
                            For i = 1 To gl.Length - 1
                                For ii = 0 To gl(i) - 1
                                    If Not cd(ii, b + i - 1) = 0 Then
                                        If Not cd(ii, b + i - 1) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gl(i) - 1 Then
                                        If Not cd(ii, b + i - 1) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                    End Select
                    If ict = 0 Then
                        Refresh()
                        Threading.Thread.Sleep(500)
                        For c = 0 To gc - 1
                            For d = 0 To gr - 1
                                If cd(c, d) = 0 Then
                                    cd(c, d) = 63
                                    DGV(c, d).Style.BackColor = Color.FromArgb(rd(cd(c, d)), gd(cd(c, d)), bd(cd(c, d)))
                                End If
                            Next
                        Next
                        DGV.CurrentCell = Nothing
                        MsgBox("脱出成功！")
                    End If
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub BA_Click(sender As Object, e As EventArgs) Handles BA.Click
        If DGV.Enabled Then
            Dim result As DialogResult = MessageBox.Show("答えを表示しますか？" & vbCrLf & "現在の進行状況は削除されます", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If result = DialogResult.Yes Then
                For b = 0 To gr - 1
                    ms = dp.Substring(2 * gc * b + b)
                    For a = 0 To gc - 1
                        cd(a, b) = ms.Substring(2 * a, 2)
                        DGV(a, b).Style.BackColor = Color.FromArgb(rd(cd(a, b)), gd(cd(a, b)), bd(cd(a, b)))
                    Next
                Next
                LaC.Text = "Answer Mode"
                DGV.CurrentCell = Nothing
                nc = 1
                mc = 0
                DGV.Enabled = False
                BA.Text = "Play"
                BL.Enabled = False
                BR.Enabled = True
                AMS()
            End If
        Else
            If nc = ac Then
                For b = 0 To gr - 1
                    ms = dp.Substring(2 * gc * b + b)
                    For a = 0 To gc - 1
                        cd(a, b) = ms.Substring(2 * a, 2)
                        DGV(a, b).Style.BackColor = Color.FromArgb(rd(cd(a, b)), gd(cd(a, b)), bd(cd(a, b)))
                    Next
                Next
                mc = 0
            Else
                mc = nc - 1
            End If
            If mc <= 1 Then
                LaC.Text = mc & " Time"
            Else
                LaC.Text = mc & " Times"
            End If
            DGV.Enabled = True
            BA.Text = "Answer"
            BL.Enabled = False
            BR.Enabled = False
        End If
    End Sub

    Private Sub BL_Click(sender As Object, e As EventArgs) Handles BL.Click
        nc -= 1
        AMS()
        If nc = 1 Then
            BL.Enabled = False
        End If
        If nc = ac - 1 Then
            BR.Enabled = True
        End If
    End Sub

    Private Sub BR_Click(sender As Object, e As EventArgs) Handles BR.Click
        nc += 1
        AMS()
        If nc = 2 Then
            BL.Enabled = True
        End If
        If nc = ac Then
            DGV_G()
            BL.Enabled = False
            BR.Enabled = False
        End If
    End Sub

    Private Sub AMS()
        ms = ap
        Try
            If nc > 1 Then
                For i = 2 To nc
                    ms = ms.Substring(ms.IndexOf(",") + 1)
                Next
            End If
            If ms.Contains(",") Then
                ms = ms.Substring(0, ms.IndexOf(","))
            End If
            DGV_C(ms.Substring(0, ms.IndexOf("-")), ms.Substring(ms.IndexOf("-") + 1))
        Catch ex As Exception
            MsgBox("ファイルが破損しています" & vbCrLf & "(" & ex.Message & ")")
            Close()
        End Try
    End Sub
End Class