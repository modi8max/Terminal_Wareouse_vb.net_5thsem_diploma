Public Class Category_master
    Dim savefile As Integer = 0
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        'new button
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        savefile = 0
        loaddata()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If TextBox1.Text <> "" Then
                If savefile = 0 Then
                    'insert
                    Dim dss As New Daoclass
                    dss.adddata("Insert into Category_master(cname) values ( '" & TextBox1.Text & "' ) ")
                    MessageBox.Show("Record Inserted")
                Else
                    'update
                    If TextBox2.Text <> "" AndAlso IsNumeric(TextBox2.Text) Then
                        Dim da As New Daoclass
                        da.adddata("update Category_master set cname ='" & TextBox1.Text & "' where Id= " & TextBox2.Text)
                        MessageBox.Show("Record Updated")
                    Else
                        MessageBox.Show("Select valid Record")
                        ToolStripButton1_Click(sender, e)

                    End If
                End If
            Else
                    MessageBox.Show("Enter Valid Catagory Name")
                    TextBox1.Focus()
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        'delete
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Category_master where Id=" & DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value)
                    loaddata()
                    MessageBox.Show("Record Deleted")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ToolStripButton1_Click(sender, e)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = TextBox1.Name Then
                ToolStripButton2_Click(sender, e)
            End If
        End If

        If sender.name = TextBox1.Name Then
            Dim d As New Daoclass
            e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If

    End Sub



    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        sender.backcolor = Color.Aquamarine
    End Sub


    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        sender.backcolor = Color.White
    End Sub

    Private Sub Category_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()

    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Category_master")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox2.Text = DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value

            TextBox1.Text = DataGridView1.Item("Cname", DataGridView1.CurrentCell.RowIndex).Value
            TextBox1.Focus()
            savefile = 1
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
    ' Dim d As Integer = TextBox1_TextChanged(sender,e)
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class