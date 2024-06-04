Public Class Terminal_Master
    Dim savefile As Integer = 0
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'new button
        TextBox1.Text = ""
        tid.Text = ""
        tname.Text = ""

        tid.Focus()
        savefile = 0
        loaddata()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'save button
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If tid.Text <> "" Then
                If tname.Text <> "" Then
                    If savefile = 0 Then
                        'insert
                        Dim dss As New Daoclass
                        dss.adddata("Insert into Terminal_master(tid,tname) values ( '" & tid.Text & "' , '" & tname.Text & "' ) ")
                        MessageBox.Show("Record Inserted")
                    Else
                        'update
                        If TextBox1.Text <> "" AndAlso IsNumeric(TextBox1.Text) Then
                            Dim da As New Daoclass
                            da.adddata("update Terminal_master set tid ='" & tid.Text & "',tname ='" & tname.Text & "' where Id= " & TextBox1.Text)
                            MessageBox.Show("Record Updated")
                        Else
                            MessageBox.Show("Select valid Record")
                            ToolStripButton1_Click(sender, e)

                        End If

                    End If

                Else
                    MessageBox.Show("Enter Valid terminal Name")
                    tname.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Company id")
                tid.Focus()
            End If
        End If
        loaddata()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("Id", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Terminal_master where Id=" & DataGridView1.Item("Id", DataGridView1.CurrentCell.RowIndex).Value)
                    loaddata()
                    MessageBox.Show("Record Deleted")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ToolStripButton1_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ToolStripButton3_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ToolStripButton2_Click(sender, e)
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Terminal_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Terminal_master")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tname.KeyPress, tid.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = tid.Name Then
                tname.Focus()
            ElseIf sender.name = tname.Name Then
                ToolStripButton2_Click(sender, e)

            End If
        End If
        If sender.name = tid.Name Then
            Dim d As New Daoclass
            e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = tname.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If

    End Sub



    Private Sub id_GotFocus(sender As Object, e As EventArgs) Handles tid.GotFocus, tname.GotFocus
        sender.backcolor = Color.Aquamarine

    End Sub

    Private Sub id_lostFocus(sender As Object, e As EventArgs) Handles tid.LostFocus, tname.LostFocus
        sender.backcolor = Color.White

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value
            tid.Text = DataGridView1.Item("t_id", DataGridView1.CurrentCell.RowIndex).Value
            tname.Text = DataGridView1.Item("t_name", DataGridView1.CurrentCell.RowIndex).Value
            tid.Focus()
            savefile = 1
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class