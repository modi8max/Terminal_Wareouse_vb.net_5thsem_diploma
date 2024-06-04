Public Class Formlogin
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button2_Disposed(sender As Object, e As EventArgs) Handles Button2.Disposed
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" Then

            If TextBox1.Text <> "" Then
                Dim ds As New Data.DataSet
                Dim da As New Daoclass
                ds = da.loaddataset("select * from Loginmaster where uname='" & ComboBox1.Text & "' and password= '" & TextBox1.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    'load admin home page
                    Dim d As New admin
                    Me.Hide()
                    d.Show()
                Else
                    MessageBox.Show("Enter Valid Password", "message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox1.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid User Name", "message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox1.Focus()
            End If

        End If
    End Sub
End Class