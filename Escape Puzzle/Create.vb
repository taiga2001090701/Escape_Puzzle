Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class Create
    Dim gc, gr, lc, lr, cn, sc, ss As Integer 'Grid Column, Grid Row, Current Column, Current Row, Last Column, Last Row, Color Number, Space Check, Space Sum
    Dim cd(,), cdt(,), gm() As Integer 'Cell Data, Cell Data Temporary
    Dim mm, cs As Byte 'Move Mode, Create Step
    Dim ap, dgvs(,) As String 'Answer Pattern
    Dim sfd As New SaveFileDialog()
    Dim rd() As Byte = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 170, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}
    Dim gd() As Byte = {0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255, 0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255, 0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255, 0, 0, 0, 0, 85, 85, 85, 85, 170, 170, 170, 170, 255, 255, 255, 255}
    Dim bd() As Byte = {0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255, 0, 85, 170, 255}
    Private Sub Create_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV.ColumnCount = 10
        DGV.RowCount = 10
        TBC.Maximum = 100
        TBC.Minimum = 3
        TBC.Value = 10
        gc = TBC.Value
        TBR.Maximum = 100
        TBR.Minimum = 3
        TBR.Value = 10
        gr = TBR.Value
        DGV.DefaultCellStyle.SelectionBackColor = Color.White
        DGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.DefaultCellStyle.ForeColor = Color.Gray
        DGV.DefaultCellStyle.Font = New Font("MS UI Gothic", 16, FontStyle.Bold)
        DGV_S(gc, gr, DGV.Width, DGV.Height)
        For i = 1 To 62
            Controls.Find("Button" & i, True)(0).BackColor = Color.FromArgb(rd(i), gd(i), bd(i))
        Next
        cs = 1
        G1.Enabled = True
        G2.Enabled = False
        G3.Enabled = False
        DGV.Enabled = False
    End Sub

    Private Sub BNS_Click(sender As Object, e As EventArgs) Handles BNS.Click
        If cs = 1 Then
            ReDim cd(gc - 1, gr - 1)
            ReDim cdt(gc - 1, gr - 1)
            ReDim dgvs(gc - 1, gr - 1)
            For a = 0 To gc - 1
                For b = 0 To gr - 1
                    cd(a, b) = 63
                Next
            Next
            cs = 2
            G1.Enabled = False
            G2.Enabled = True
            G3.Enabled = False
            DGV.Enabled = True
            DGV.DefaultCellStyle.SelectionBackColor = Color.Gray
        ElseIf cs = 2 Then
            If CheckBlack(gc, gr, cd) Then
                If CheckSide(gc, gr, cd, 0) Then
                    Dim fet As Byte
                    Dim ggn As Integer
                    fet = 0
                    ggn = 0
                    For a = 0 To gc - 1
                        For b = 0 To gr - 1
                            If cd(a, b) = 0 Then
                                If b = 0 Then
                                    For c = 0 To gc - 1
                                        For d = 0 To gr - 1
                                            If cd(c, d) = 0 Then
                                                DGV(c, 0).Value = "GOAL"
                                                ggn += 1
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    ReDim gm(ggn)
                                    gm(0) = 1
                                    For i = 0 To gc - 1
                                        If DGV(i, 0).Value = "GOAL" Then
                                            For ig = 0 To ggn - 1
                                                For ii = 0 To gr - 1
                                                    If cd(i + ig, ii) = 0 Then
                                                        gm(ig + 1) = ii + 1
                                                    End If
                                                Next
                                            Next
                                            Exit For
                                        End If
                                    Next
                                    fet = 1
                                    Exit For
                                ElseIf a = gc - 1 Then
                                    For d = 0 To gr - 1
                                        For c = 0 To gc - 1
                                            If cd(c, d) = 0 Then
                                                DGV(gc - 1, d).Value = "GOAL"
                                                ggn += 1
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    ReDim gm(ggn)
                                    gm(0) = 2
                                    For i = 0 To gr - 1
                                        If DGV(gc - 1, i).Value = "GOAL" Then
                                            For ig = 0 To ggn - 1
                                                For ii = 0 To gr - 1
                                                    If cd(gc - ii - 1, i + ig) = 0 Then
                                                        gm(ig + 1) = ii + 1
                                                    End If
                                                Next
                                            Next
                                            Exit For
                                        End If
                                    Next
                                    fet = 1
                                    Exit For
                                ElseIf b = gr - 1 Then
                                    For c = 0 To gc - 1
                                        For d = 0 To gr - 1
                                            If cd(c, d) = 0 Then
                                                DGV(c, gr - 1).Value = "GOAL"
                                                ggn += 1
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    ReDim gm(ggn)
                                    gm(0) = 3
                                    For i = 0 To gc - 1
                                        If DGV(i, gr - 1).Value = "GOAL" Then
                                            For ig = 0 To ggn - 1
                                                For ii = 0 To gr - 1
                                                    If cd(i + ig, gr - ii - 1) = 0 Then
                                                        gm(ig + 1) = ii + 1
                                                    End If
                                                Next
                                            Next
                                            Exit For
                                        End If
                                    Next
                                    fet = 1
                                    Exit For
                                ElseIf a = 0 Then
                                    For d = 0 To gr - 1
                                        For c = 0 To gc - 1
                                            If cd(c, d) = 0 Then
                                                DGV(0, d).Value = "GOAL"
                                                ggn += 1
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    ReDim gm(ggn)
                                    gm(0) = 4
                                    For i = 0 To gr - 1
                                        If DGV(0, i).Value = "GOAL" Then
                                            For ig = 0 To ggn - 1
                                                For ii = 0 To gr - 1
                                                    If cd(ii, i + ig) = 0 Then
                                                        gm(ig + 1) = ii + 1
                                                    End If
                                                Next
                                            Next
                                            Exit For
                                        End If
                                    Next
                                    fet = 1
                                    Exit For
                                End If
                            End If
                        Next
                        If fet = 1 Then
                            Exit For
                        End If
                    Next
                    cs = 3
                    G1.Enabled = False
                    G2.Enabled = False
                    G3.Enabled = True
                    DGV.Enabled = True
                Else
                    MsgBox("それぞれのブロックは同色のブロックと一塊になっている必要があります")
                End If
            Else
                MsgBox("黒ブロックを少なくとも一つ側面に置く必要があります")
            End If
        ElseIf cs = 3 Then
            For i = 1 To 62
                If CheckSide(gc, gr, cd, i) = False Then
                    MsgBox("それぞれのブロックは同色のブロックと一塊になっている必要があります")
                    Exit Sub
                End If
            Next
            For a = 0 To gc - 1
                For b = 0 To gr - 1
                    dgvs(a, b) = DGV(a, b).Value
                Next
            Next
            If CheckGoal(gc, gr, cd, gm, dgvs) Then
                cs = 4
                ap = ""
                G1.Enabled = False
                G2.Enabled = False
                G3.Enabled = False
                DGV.Enabled = True
                BNS.Text = "Export"
            Else
                MsgBox("黒ブロックがゴールできる状態である必要があります")
            End If
        ElseIf cs = 4 Then
            For a = 0 To gc - 1
                For b = 0 To gr - 1
                    dgvs(a, b) = DGV(a, b).Value
                Next
            Next
            If CheckGoal(gc, gr, cd, gm, dgvs) = False Then
                Directory.CreateDirectory("Data")
                sfd.FileName = "P0000.epp"
                sfd.InitialDirectory = "\Data"
                sfd.Filter = "EPPファイル(*.epp)|*.epp"
                sfd.Title = "保存先のファイルを選択してください"
                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim swt As String
                    Dim sw As New StreamWriter(sfd.FileName)
                    sw.WriteLine("<Size>")
                    sw.WriteLine(gc & "-" & gr)
                    sw.WriteLine("<Block>")
                    swt = ""
                    For b = 0 To gr - 1
                        For a = 0 To gc - 1
                            If cd(a, b) < 10 Then
                                swt &= "0" & cd(a, b)
                            Else
                                swt &= cd(a, b)
                            End If
                        Next
                        If b < gr - 1 Then
                            swt &= "-"
                        End If
                    Next
                    sw.WriteLine(swt)
                    sw.WriteLine("<Goal>")
                    swt = ""
                    For a = 0 To gc - 1
                        For b = 0 To gr - 1
                            If DGV(a, b).Value = "GOAL" Then
                                If swt = "" Then
                                    swt = a & "-" & b
                                Else
                                    swt &= "," & a & "-" & b
                                End If
                            End If
                        Next
                    Next
                    sw.WriteLine(swt)
                    swt = gm(0)
                    For i = 1 To gm.Length - 1
                        swt &= "," & gm(i)
                    Next
                    sw.WriteLine(swt)
                    sw.WriteLine("<Answer>")
                    sw.Write(ap)
                    sw.Close()
                    G1.Enabled = False
                    G2.Enabled = False
                    G3.Enabled = False
                    DGV.Enabled = False
                End If
            Else
                MsgBox("黒ブロックがゴールできる状態ではない必要があります")
            End If
        End If
    End Sub

    Public Shared Function CheckBlack(c As Integer, r As Integer, cdt(,) As Integer) As Boolean
        Dim tcb As Integer
        tcb = 0
        For a = 0 To c - 1
            For b = 0 To r - 1
                If cdt(a, b) = 0 Then
                    If a = 0 OrElse b = 0 OrElse a = c - 1 OrElse b = r - 1 Then
                        tcb = 1
                    End If
                End If
            Next
        Next
        If tcb = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function CheckSide(c As Integer, r As Integer, cdt(,) As Integer, t As Integer) As Boolean
        Dim tt, ttt, tx, rm, lm, bm, tm, pff, bc As Integer
        Dim sbm, sbmt As String
        tx = 0
        rm = -1
        lm = -1
        bm = -1
        tm = -1
        For a = 0 To c - 1
            For b = 0 To r - 1
                If cdt(a, b) = t Then
                    If rm = -1 Then
                        rm = a
                        lm = a
                        bm = b
                        tm = b
                    Else
                        If a > rm Then
                            rm = a
                        ElseIf a < lm Then
                            lm = a
                        End If
                        If b > bm Then
                            bm = b
                        ElseIf b < tm Then
                            tm = b
                        End If
                    End If
                    tx += 1
                End If
            Next
        Next
        If tx > 1 Then
            tt = 0
            pff = 0
            For a = 0 To c - 1
                For b = 0 To r - 1
                    If cdt(a, b) = t Then
                        bc = 1
                        sbm = a & "-" & b
                        sbmt = CheckAll(a, b, cdt, t, rm, lm, bm, tm, sbm, bc)
                        If sbmt.Substring(0, sbmt.IndexOf(",")) = tx Then
                            tt = 1
                        End If
                        pff = 1
                        Exit For
                    End If
                Next
                If pff = 1 Then
                    Exit For
                End If
            Next
        Else
            tt = 1
        End If
        If tt = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Shared Function CheckAll(jc As Integer, jr As Integer, cdt(,) As Integer, t As Integer, rm As Integer, lm As Integer, bm As Integer, tm As Integer, sbm As String, bc As Integer) As String
        Dim sbmt As String
        Dim sbmtio As Integer
        If jc < rm AndAlso cdt(jc + 1, jr) = t AndAlso sbm.Contains((jc + 1) & "-" & jr) = False Then
            bc += 1
            sbm &= "/" & (jc + 1) & "-" & jr
            sbmt = CheckAll(jc + 1, jr, cdt, t, rm, lm, bm, tm, sbm, bc)
            sbmtio = sbmt.IndexOf(",")
            bc = sbmt.Substring(0, sbmtio)
            sbm = sbmt.Substring(sbmtio + 1)
        End If
        If jc > lm AndAlso cdt(jc - 1, jr) = t AndAlso sbm.Contains((jc - 1) & "-" & jr) = False Then
            bc += 1
            sbm &= "/" & (jc - 1) & "-" & jr
            sbmt = CheckAll(jc - 1, jr, cdt, t, rm, lm, bm, tm, sbm, bc)
            sbmtio = sbmt.IndexOf(",")
            bc = sbmt.Substring(0, sbmtio)
            sbm = sbmt.Substring(sbmtio + 1)
        End If
        If jr < bm AndAlso cdt(jc, jr + 1) = t AndAlso sbm.Contains(jc & "-" & (jr + 1)) = False Then
            bc += 1
            sbm &= "/" & jc & "-" & (jr + 1)
            sbmt = CheckAll(jc, jr + 1, cdt, t, rm, lm, bm, tm, sbm, bc)
            sbmtio = sbmt.IndexOf(",")
            bc = sbmt.Substring(0, sbmtio)
            sbm = sbmt.Substring(sbmtio + 1)
        End If
        If jr > tm AndAlso cdt(jc, jr - 1) = t AndAlso sbm.Contains(jc & "-" & (jr - 1)) = False Then
            bc += 1
            sbm &= "/" & jc & "-" & (jr - 1)
            sbmt = CheckAll(jc, jr - 1, cdt, t, rm, lm, bm, tm, sbm, bc)
            sbmtio = sbmt.IndexOf(",")
            bc = sbmt.Substring(0, sbmtio)
            sbm = sbmt.Substring(sbmtio + 1)
        End If
        Return bc & "," & sbm
    End Function

    Private Shared Function CheckGoal(c As Integer, r As Integer, cdt(,) As Integer, gmt() As Integer, dgvt(,) As String) As Boolean
        For a = 0 To c - 1
            For b = 0 To r - 1
                If dgvt(a, b) = "GOAL" Then
                    Dim ict As Integer
                    ict = 0
                    Select Case gmt(0)
                        Case 1
                            For i = 1 To gmt.Length - 1
                                For ii = 0 To gmt(i) - 1
                                    If Not cdt(a + i - 1, ii) = 0 Then
                                        If Not cdt(a + i - 1, ii) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gmt(i) - 1 Then
                                        If Not cdt(a + i - 1, ii) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                        Case 2
                            For i = 1 To gmt.Length - 1
                                For ii = 0 To gmt(i) - 1
                                    If Not cdt(c - ii - 1, b + i - 1) = 0 Then
                                        If Not cdt(c - ii - 1, b + i - 1) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gmt(i) - 1 Then
                                        If Not cdt(c - ii - 1, b + i - 1) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                        Case 3
                            For i = 1 To gmt.Length - 1
                                For ii = 0 To gmt(i) - 1
                                    If Not cdt(a + i - 1, r - ii - 1) = 0 Then
                                        If Not cdt(a + i - 1, r - ii - 1) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gmt(i) - 1 Then
                                        If Not cdt(a + i - 1, r - ii - 1) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                        Case 4
                            For i = 1 To gmt.Length - 1
                                For ii = 0 To gmt(i) - 1
                                    If Not cdt(ii, b + i - 1) = 0 Then
                                        If Not cdt(ii, b + i - 1) = 63 Then
                                            ict = 1
                                        End If
                                    End If
                                    If ii = gmt(i) - 1 Then
                                        If Not cdt(ii, b + i - 1) = 0 Then
                                            ict = 1
                                        End If
                                    End If
                                Next
                            Next
                    End Select
                    If ict = 1 Then
                        Return False
                    Else
                        Return True
                    End If
                    Exit Function
                End If
            Next
        Next
        Return True
    End Function

    Private Sub DGV_SizeChanged(sender As Object, e As EventArgs) Handles DGV.SizeChanged
        DGV_S(gc, gr, DGV.Width, DGV.Height)
    End Sub

    Private Sub DGV_Click(sender As Object, e As EventArgs) Handles DGV.Click
        If cs = 4 Then
            DGV_C(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex)
        End If
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
            If cc = lc AndAlso cr < lr Then 'Up
                mm = 1
            ElseIf cc > lc AndAlso cr = lr Then 'Right
                mm = 2
            ElseIf cc = lc AndAlso cr > lr Then 'Down
                mm = 3
            ElseIf cc < lc AndAlso cr = lr Then 'Left
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
                    If ap = "" Then
                        ap = cc & "-" & cr & "," & lc & "-" & lr
                    Else
                        If ap.Substring(0, ap.IndexOf(",")) = lc & "-" & lr Then
                            ap = cc & "-" & cr & "," & ap
                        Else
                            ap = cc & "-" & cr & "," & lc & "-" & lr & "," & ap
                        End If
                    End If
                End If
            End If
            lc = cc
            lr = cr
            BackColor = DGV(cc, cr).Style.BackColor
        End If
    End Sub

    Private Sub TBC_Scroll(sender As Object, e As EventArgs) Handles TBC.Scroll
        gc = TBC.Value
        DGV.ColumnCount = gc
        LC2.Text = gc
        DGV_S(gc, gr, DGV.Width, DGV.Height)
    End Sub

    Private Sub TBR_Scroll(sender As Object, e As EventArgs) Handles TBR.Scroll
        gr = TBR.Value
        DGV.RowCount = gr
        LR2.Text = gr
        DGV_S(gc, gr, DGV.Width, DGV.Height)
    End Sub

    Private Sub B2P_Click(sender As Object, e As EventArgs) Handles B2P.Click
        If DGV.CurrentCell IsNot Nothing Then
            GCC(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex, 0)
            DGV.CurrentCell = Nothing
        End If
    End Sub

    Private Sub B2C_Click(sender As Object, e As EventArgs) Handles B2C.Click
        If DGV.CurrentCell IsNot Nothing Then
            GCC(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex, 63)
            DGV.CurrentCell = Nothing
        End If
    End Sub

    Private Sub B2R_Click(sender As Object, e As EventArgs) Handles B2R.Click
        For a = 0 To gc - 1
            For b = 0 To gr - 1
                cd(a, b) = 63
                DGV(a, b).Style.BackColor = Color.FromArgb(rd(cd(a, b)), gd(cd(a, b)), bd(cd(a, b)))
            Next
        Next
    End Sub

    Private Sub GCC(a As Integer, b As Integer, c As Integer)
        cd(a, b) = c
        DGV(a, b).Style.BackColor = Color.FromArgb(rd(cd(a, b)), gd(cd(a, b)), bd(cd(a, b)))
    End Sub

    Private Sub BCB_Click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button62.Click, Button61.Click, Button60.Click, Button6.Click, Button59.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click, Button50.Click, Button5.Click, Button49.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click, Button41.Click, Button40.Click, Button4.Click, Button39.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click, Button1.Click
        If DGV.CurrentCell IsNot Nothing Then
            If Not DGV.CurrentCell.Style.BackColor = Color.FromArgb(0, 0, 0) Then
                GCC(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex, sender.Name.Substring(6))
                DGV.CurrentCell = Nothing
            End If
        End If
    End Sub

    Private Sub B3C_Click(sender As Object, e As EventArgs) Handles B3C.Click
        If DGV.CurrentCell IsNot Nothing Then
            If Not DGV.CurrentCell.Style.BackColor = Color.FromArgb(0, 0, 0) Then
                GCC(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex, 63)
                DGV.CurrentCell = Nothing
            End If
        End If
    End Sub

    Private Sub B3R_Click(sender As Object, e As EventArgs) Handles B3R.Click
        For a = 0 To gc - 1
            For b = 0 To gr - 1
                If Not cd(a, b) = 0 Then
                    cd(a, b) = 63
                    DGV(a, b).Style.BackColor = Color.FromArgb(rd(cd(a, b)), gd(cd(a, b)), bd(cd(a, b)))
                End If
            Next
        Next
    End Sub
End Class