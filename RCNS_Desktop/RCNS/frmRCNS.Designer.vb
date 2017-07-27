<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRCNS
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BWRegisterCard = New System.ComponentModel.BackgroundWorker()
        Me.BWSearch = New System.ComponentModel.BackgroundWorker()
        Me.BWRetrieve = New System.ComponentModel.BackgroundWorker()
        Me.BWStats = New System.ComponentModel.BackgroundWorker()
        Me.WebControl1 = New Awesomium.Windows.Forms.WebControl(Me.components)
        Me.BWStats2 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'BWRegisterCard
        '
        Me.BWRegisterCard.WorkerReportsProgress = True
        '
        'BWSearch
        '
        Me.BWSearch.WorkerReportsProgress = True
        '
        'BWRetrieve
        '
        Me.BWRetrieve.WorkerReportsProgress = True
        '
        'BWStats
        '
        '
        'WebControl1
        '
        Me.WebControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebControl1.Location = New System.Drawing.Point(0, 0)
        Me.WebControl1.Size = New System.Drawing.Size(738, 571)
        Me.WebControl1.TabIndex = 0
        '
        'BWStats2
        '
        '
        'frmRCNS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 571)
        Me.Controls.Add(Me.WebControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmRCNS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RCNS"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BWRegisterCard As System.ComponentModel.BackgroundWorker
    Friend WithEvents BWSearch As System.ComponentModel.BackgroundWorker
    Friend WithEvents BWRetrieve As System.ComponentModel.BackgroundWorker
    Friend WithEvents BWStats As System.ComponentModel.BackgroundWorker
    Private WithEvents WebControl1 As Awesomium.Windows.Forms.WebControl
    Friend WithEvents BWStats2 As System.ComponentModel.BackgroundWorker

End Class
