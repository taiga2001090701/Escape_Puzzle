<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Play
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.BA = New System.Windows.Forms.Button()
        Me.BL = New System.Windows.Forms.Button()
        Me.LaC = New System.Windows.Forms.Label()
        Me.BR = New System.Windows.Forms.Button()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToResizeColumns = False
        Me.DGV.AllowUserToResizeRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.BackgroundColor = System.Drawing.Color.White
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.ColumnHeadersVisible = False
        Me.DGV.Location = New System.Drawing.Point(12, 79)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RowHeadersVisible = False
        Me.DGV.RowTemplate.Height = 21
        Me.DGV.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGV.Size = New System.Drawing.Size(760, 760)
        Me.DGV.TabIndex = 0
        '
        'BA
        '
        Me.BA.BackColor = System.Drawing.Color.Gray
        Me.BA.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BA.ForeColor = System.Drawing.Color.White
        Me.BA.Location = New System.Drawing.Point(12, 12)
        Me.BA.Name = "BA"
        Me.BA.Size = New System.Drawing.Size(120, 60)
        Me.BA.TabIndex = 1
        Me.BA.Text = "Answer"
        Me.BA.UseVisualStyleBackColor = False
        '
        'BL
        '
        Me.BL.BackColor = System.Drawing.Color.Gray
        Me.BL.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BL.ForeColor = System.Drawing.Color.White
        Me.BL.Location = New System.Drawing.Point(138, 12)
        Me.BL.Name = "BL"
        Me.BL.Size = New System.Drawing.Size(120, 60)
        Me.BL.TabIndex = 2
        Me.BL.Text = "◀"
        Me.BL.UseVisualStyleBackColor = False
        '
        'LaC
        '
        Me.LaC.AutoSize = True
        Me.LaC.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.LaC.ForeColor = System.Drawing.Color.Gray
        Me.LaC.Location = New System.Drawing.Point(390, 29)
        Me.LaC.Margin = New System.Windows.Forms.Padding(3)
        Me.LaC.Name = "LaC"
        Me.LaC.Size = New System.Drawing.Size(70, 27)
        Me.LaC.TabIndex = 3
        Me.LaC.Text = "0 / 0"
        '
        'BR
        '
        Me.BR.BackColor = System.Drawing.Color.Gray
        Me.BR.Font = New System.Drawing.Font("MS UI Gothic", 20.0!)
        Me.BR.ForeColor = System.Drawing.Color.White
        Me.BR.Location = New System.Drawing.Point(264, 12)
        Me.BR.Name = "BR"
        Me.BR.Size = New System.Drawing.Size(120, 60)
        Me.BR.TabIndex = 4
        Me.BR.Text = "▶"
        Me.BR.UseVisualStyleBackColor = False
        '
        'Play
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 851)
        Me.Controls.Add(Me.BR)
        Me.Controls.Add(Me.LaC)
        Me.Controls.Add(Me.BL)
        Me.Controls.Add(Me.BA)
        Me.Controls.Add(Me.DGV)
        Me.Name = "Play"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Play"
        Me.TopMost = True
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV As Windows.Forms.DataGridView
    Friend WithEvents BA As Windows.Forms.Button
    Friend WithEvents BL As Windows.Forms.Button
    Friend WithEvents LaC As Windows.Forms.Label
    Friend WithEvents BR As Windows.Forms.Button
End Class
