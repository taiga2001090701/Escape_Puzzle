<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.BP = New System.Windows.Forms.Button()
        Me.BC = New System.Windows.Forms.Button()
        Me.BS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BP
        '
        Me.BP.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
        Me.BP.Location = New System.Drawing.Point(12, 12)
        Me.BP.Name = "BP"
        Me.BP.Size = New System.Drawing.Size(400, 120)
        Me.BP.TabIndex = 0
        Me.BP.Text = "Play"
        Me.BP.UseVisualStyleBackColor = True
        '
        'BC
        '
        Me.BC.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
        Me.BC.Location = New System.Drawing.Point(12, 138)
        Me.BC.Name = "BC"
        Me.BC.Size = New System.Drawing.Size(400, 120)
        Me.BC.TabIndex = 1
        Me.BC.Text = "Create"
        Me.BC.UseVisualStyleBackColor = True
        '
        'BS
        '
        Me.BS.Font = New System.Drawing.Font("MS UI Gothic", 24.0!)
        Me.BS.Location = New System.Drawing.Point(12, 264)
        Me.BS.Margin = New System.Windows.Forms.Padding(3, 3, 12, 12)
        Me.BS.Name = "BS"
        Me.BS.Size = New System.Drawing.Size(400, 120)
        Me.BS.TabIndex = 2
        Me.BS.Text = "Solve"
        Me.BS.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(427, 413)
        Me.Controls.Add(Me.BS)
        Me.Controls.Add(Me.BC)
        Me.Controls.Add(Me.BP)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BP As Windows.Forms.Button
    Friend WithEvents BC As Windows.Forms.Button
    Friend WithEvents BS As Windows.Forms.Button
End Class
