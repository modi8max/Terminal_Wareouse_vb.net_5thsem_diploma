Public Class Depatment_Master
    Dim savefile As Integer = 0

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'new button
        id.Text = ""
        dname.Text = ""
        dname.Focus()
        savefile = 0
        loaddata()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'save button
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then

            If dname.Text <> "" Then
                    If savefile = 0 Then
                        'insert
                        Dim dss As New Daoclass
                    dss.adddata("Insert into Department_master(dname,tname) values ( '" & dname.Text & "','" & tname.Text & "' ) ")
                    MessageBox.Show("Record Inserted")
                    Else
                    'update
                    If id.Text <> "" AndAlso IsNumeric(id.Text) Then
                        Dim da As New Daoclass
                        da.adddata("update Department_master set dname ='" & dname.Text & "',tname ='" & tname.Text & "' where Id= " & id.Text)
                        MessageBox.Show("Record Updated")
                    Else
                        MessageBox.Show("Select valid Record")
                        ToolStripButton1_Click(sender, e)

                    End If
                End If

                Else
                    MessageBox.Show("Enter Valid Department Name")
                    dname.Focus()
                End If

            End If
        loaddata()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ToolStripButton1_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ToolStripButton2_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ToolStripButton3_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Department_master where Id=" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value)
                    loaddata()
                    MessageBox.Show("Record Deleted")
                End If
            End If
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
    Private Sub dname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dname.KeyPress, tname.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = dname.Name Then
                tname.Focus()
            ElseIf sender.name = tname.Name Then

                ToolStripButton2_Click(sender, e)

            End If

        End If
        If sender.name = dname.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = tname.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        'If sender.name = dname.Name Then
        '    AutoSearch(sender, e, True)
        'End If

    End Sub

    Private Sub dname_GotFocus(sender As Object, e As EventArgs) Handles dname.GotFocus
        sender.backcolor = Color.LightBlue



    End Sub

    Private Sub dname_lostFocus(sender As Object, e As EventArgs) Handles dname.LostFocus
        sender.backcolor = Color.White

    End Sub

    Private Sub Depatment_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        Try

            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select distinct (tname) from terminal_master")
            tname.DataSource = ds.Tables(0)
            tname.ValueMember = "tname"
            'ds = d.loaddataset("select distinct (dname) from Department_master")
            'ComboBox3.DataSource = ds.Tables(0)
            'ComboBox3.ValueMember = "dname"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Department_master")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If DataGridView1.Rows.Count > 0 Then
            id.Text = DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value
            dname.Text = DataGridView1.Item("d_name", DataGridView1.CurrentCell.RowIndex).Value
            tname.Text = DataGridView1.Item("t_name", DataGridView1.CurrentCell.RowIndex).Value
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            id.Text = DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value
            dname.Text = DataGridView1.Item("d_name", DataGridView1.CurrentCell.RowIndex).Value
            tname.Text = DataGridView1.Item("t_name", DataGridView1.CurrentCell.RowIndex).Value
            dname.Focus()
            savefile = 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class