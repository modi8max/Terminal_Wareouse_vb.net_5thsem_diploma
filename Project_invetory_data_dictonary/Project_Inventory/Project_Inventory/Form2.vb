Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" Then

            If TextBox2.Text <> "" Then
                Dim ds As New Data.DataSet
                Dim da As New Daoclass
                ds = da.loaddataset("select * from Table1 where u_name='" & ComboBox1.Text & "' and u_pass= '" & TextBox2.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    'load admin home page
                    Dim d As New Form1
                    Me.Hide()
                    d.Show()
                Else
                    MessageBox.Show("Enter Valid Password", "message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox2.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid User Name", "message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox1.Focus()
            End If

        End If
    End Sub
End Class