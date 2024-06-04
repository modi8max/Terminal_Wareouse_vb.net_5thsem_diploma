Public Class Login_master
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" Then

            If TextBox1.Text <> "" Then
                Dim ds As New Data.DataSet
                Dim da As New Daoclass
                ds = da.loaddataset("select * from Login_master where uname='" & ComboBox1.Text & "' and password= '" & TextBox1.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dss As New Daoclass
                    dss.adddata("Insert into Login_master(uname,password,terminal,department) values ( '" & ComboBox1.Text & "','" & TextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "' ) ")

                    MessageBox.Show("Login Successful")
                    Timer1.Start()
                    SplashScreen1.Show()
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

    Private Sub Login_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Stop()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select distinct (uname) from Login_master")
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.ValueMember = "uname"
            ds = d.loaddataset("select distinct (tname) from terminal_master")
            ComboBox2.DataSource = ds.Tables(0)
            ComboBox2.ValueMember = "tname"
            ds = d.loaddataset("select distinct (dname) from Department_master")
            ComboBox3.DataSource = ds.Tables(0)
            ComboBox3.ValueMember = "dname"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub AutoSearch(ByRef xcb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal blnLimitToList As Boolean)

        Dim strFindStr As String = ""
        If e.KeyChar = ChrW(8) Then
            If (xcb.SelectionStart <= 1) Then
                xcb.Text = ""
                Exit Sub
            End If
            If (xcb.SelectionLength = 0) Then
                strFindStr = xcb.Text.Substring(0, xcb.Text.Length - 1)
            Else
                strFindStr = xcb.Text.Substring(0, xcb.SelectionStart - 1)
            End If
        Else
            If (xcb.SelectionLength = 0) Then
                strFindStr = xcb.Text + e.KeyChar
            Else
                strFindStr = xcb.Text.Substring(0, xcb.SelectionStart) + e.KeyChar
            End If

            Dim intIdx As Integer = -1
            ' Search the string in the ComboBox list.  

            intIdx = xcb.FindString(strFindStr)
            If (intIdx <> -1) Then
                xcb.SelectedText = ""
                xcb.SelectedIndex = intIdx
                xcb.SelectionStart = strFindStr.Length
                xcb.SelectionLength = xcb.Text.Length
                e.Handled = True
            Else
                e.Handled = blnLimitToList
            End If
        End If
    End Sub

    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, ComboBox3.KeyPress, ComboBox2.KeyPress, ComboBox1.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = ComboBox1.Name Then
                TextBox1.Focus()
            ElseIf sender.name = TextBox1.Name Then
                ComboBox2.Focus()
            ElseIf sender.name = ComboBox2.Name Then
                ComboBox3.Focus()
            ElseIf sender.name = ComboBox3.Name Then
                Button1.Focus()
            End If
        End If
        If sender.name = ComboBox1.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = ComboBox2.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = ComboBox3.Name Then
            AutoSearch(sender, e, True)
        End If
    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label12.Text = Val(Label12.Text) + 1
        ' Label3.Text += 10
        If (Label12.Text = 10) Then
            Timer1.Stop()
            'Login_form.Show()
            SplashScreen1.Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        End
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class