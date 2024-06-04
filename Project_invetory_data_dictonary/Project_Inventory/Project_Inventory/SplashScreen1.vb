Public NotInheritable Class SplashScreen1


    '  End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub SplashScreen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()
        Timer1.Interval = 10
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label3.Text = Val(Label3.Text) + 1
        ' Label3.Text += 10
        If (ProgressBar1.Value = 100) Then
            Timer1.Stop()
            'Login_form.Show()
            Me.Hide()
        End If
        'If Label3.Text < 100 Then
        '    Label3.Text += 10
        'Else
        '    Label3.Text = 0
        'End If
        'ProgressBar1.Value = Label3.Text
    End Sub
End Class
