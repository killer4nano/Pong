<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.objPlayer1 = New System.Windows.Forms.Label()
        Me.objPlayer2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Location = New System.Drawing.Point(183, 30)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(0, 13)
        Me.lblIP.TabIndex = 0
        '
        'objPlayer1
        '
        Me.objPlayer1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.objPlayer1.Location = New System.Drawing.Point(12, 112)
        Me.objPlayer1.Name = "objPlayer1"
        Me.objPlayer1.Size = New System.Drawing.Size(20, 112)
        Me.objPlayer1.TabIndex = 1
        Me.objPlayer1.Text = "Label1"
        '
        'objPlayer2
        '
        Me.objPlayer2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.objPlayer2.Location = New System.Drawing.Point(531, 112)
        Me.objPlayer2.Name = "objPlayer2"
        Me.objPlayer2.Size = New System.Drawing.Size(20, 112)
        Me.objPlayer2.TabIndex = 2
        Me.objPlayer2.Text = "Label1"
        '
        'Timer1
        '
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 403)
        Me.Controls.Add(Me.objPlayer2)
        Me.Controls.Add(Me.objPlayer1)
        Me.Controls.Add(Me.lblIP)
        Me.Name = "Game"
        Me.Text = "Game"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents objPlayer1 As System.Windows.Forms.Label
    Friend WithEvents objPlayer2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
