Public Class Add_User
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub passwd_TextChanged(sender As Object, e As EventArgs) Handles passwd.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        TextBox1.Text = ""
        uname.Text = ""
        passwd.Text = ""
        ter.Text = ""
        dep.Text = ""
    End Sub

    Private Sub Add_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            loaddata()
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select distinct (tname) from terminal_master")
            ter.DataSource = ds.Tables(0)
            ter.ValueMember = "tname"
            ds = d.loaddataset("select distinct (dname) from Department_master")
            dep.DataSource = ds.Tables(0)
            dep.ValueMember = "dname"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim savefile As Integer = 0
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If uname.Text <> "" Then
                If passwd.Text <> "" Then
                    If ter.Text <> "" Then
                        If dep.Text <> "" Then
                            If savefile = 0 Then
                                'insert
                                Dim dss As New Daoclass
                                dss.adddata("Insert into Login_master(uname,password,terminal,department) values ( '" & uname.Text & "' , '" & passwd.Text & "','" & ter.Text & "' , '" & dep.Text & "') ")
                                MessageBox.Show("Record Inserted")
                            Else
                                'update
                                If TextBox1.Text <> "" AndAlso IsNumeric(TextBox1.Text) Then
                                    Dim da As New Daoclass
                                    da.adddata("update Login_master set uname ='" & uname.Text & "',password ='" & passwd.Text & "',terminal ='" & ter.Text & "',department ='" & dep.Text & "' where Id= " & TextBox1.Text)
                                    MessageBox.Show("Record Updated")
                                Else
                                    MessageBox.Show("Select valid Record")
                                    ToolStripButton1_Click(sender, e)

                                End If
                            End If
                        Else
                            MessageBox.Show("Enter Valid Department")
                            dep.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid Terminal")
                        ter.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid Password")
                    passwd.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid User Name")
                uname.Focus()
            End If
        End If
        loaddata()
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
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Login_master")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            uname.Text = DataGridView1.Item("u_name", DataGridView1.CurrentCell.RowIndex).Value
            passwd.Text = DataGridView1.Item("psw", DataGridView1.CurrentCell.RowIndex).Value
            ter.Text = DataGridView1.Item("terminal", DataGridView1.CurrentCell.RowIndex).Value
            dep.Text = DataGridView1.Item("Dept", DataGridView1.CurrentCell.RowIndex).Value
            TextBox1.Text = DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value
            uname.Focus()
            savefile = 1
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Login_master where Id=" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value)
                    loaddata()
                    MessageBox.Show("Record Deleted")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        loaddata()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub uname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uname.KeyPress, ter.KeyPress, passwd.KeyPress, dep.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = uname.Name Then
                passwd.Focus()
            ElseIf sender.name = passwd.name Then
                ter.Focus()
            ElseIf sender.name = ter.name Then
                dep.Focus()
            ElseIf sender.name = dep.name Then
                ToolStripButton2_Click(sender, e)

            End If
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class