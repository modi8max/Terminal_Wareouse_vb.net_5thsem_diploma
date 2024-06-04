Public Class Supplier_master
    Dim savefile As Integer = 0

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'new button
        TextBox1.Text = ""
        sname.Text = ""
        add.Text = ""
        city.Text = ""
        s_phn.Text = ""
        email.Text = ""
        gst_no.Text = ""
        sname.Focus()
        savefile = 0
    End Sub

    Private Sub Supplier_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'save button
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If sname.Text <> "" Then
                If add.Text <> "" Then
                    If city.Text <> "" Then
                        If s_phn.Text <> "" Then
                            If email.Text <> "" Then
                                If gst_no.Text <> "" Then

                                    If savefile = 0 Then
                                        'insert
                                        Dim dss As New Daoclass
                                        dss.adddata("Insert into Supplier_master(sname,sadd,city,s_phn,email,gst_no) values ( '" & sname.Text & "' , '" & add.Text & "','" & city.Text & "' , '" & s_phn.Text & "','" & email.Text & "' , '" & gst_no.Text & "') ")
                                        MessageBox.Show("Record Inserted")
                                    Else
                                        'update
                                        If TextBox1.Text <> "" AndAlso IsNumeric(TextBox1.Text) Then
                                            Dim da As New Daoclass
                                            da.adddata("update Supplier_master set sname ='" & sname.Text & "',sadd ='" & add.Text & "',city ='" & city.Text & "',s_phn ='" & s_phn.Text & "',email ='" & email.Text & "',gst_no ='" & gst_no.Text & "' where Id= " & TextBox1.Text)
                                            MessageBox.Show("Record Updated")
                                        Else
                                            MessageBox.Show("Select valid Record")
                                            ToolStripButton1_Click(sender, e)

                                        End If
                                    End If
                                Else
                                    MessageBox.Show("Enter Valid Gst No")
                                    gst_no.Focus()
                                End If
                            Else
                                MessageBox.Show("Enter Valid Email")
                                email.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid Contact No")
                            s_phn.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid City")
                        city.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid Address")
                    add.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Supplier Name")
                sname.Focus()
            End If
            loaddata()
        End If
    End Sub

    Private Sub sname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sname.KeyPress, add.KeyPress, city.KeyPress, s_phn.KeyPress, email.KeyPress, gst_no.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = sname.Name Then
                add.Focus()
            ElseIf sender.name = add.Name Then
                city.Focus()
            ElseIf sender.name = city.Name Then
                s_phn.Focus()
            ElseIf sender.name = s_phn.Name Then
                email.Focus()
            ElseIf sender.name = email.Name Then
                gst_no.Focus()
            ElseIf sender.name = gst_no.Name Then
                ToolStripButton2_Click(sender, e)

            End If
        End If

        If sender.name = s_phn.Name Then
            Dim d As New Daoclass
            e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = sname.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = city.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = add.Name Or sender.name = gst_no.Name Or sender.name = email.Name Then
            Dim d As New Daoclass
            ' e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            Dim f As Boolean = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            'e.Handled = f
            'If f Then
            '    sender.backcolor = Color.Red
            'Else
            '    sender.backcolor = Color.Black
            '    sender.forecolor = Color.White
            'End If
        End If
    End Sub

    Private Sub sname_TextChanged(sender As Object, e As EventArgs) Handles sname.TextChanged

    End Sub

    Private Sub sname_GotFocus(sender As Object, e As EventArgs) Handles sname.GotFocus, add.GotFocus, city.GotFocus, s_phn.GotFocus, email.GotFocus, gst_no.GotFocus
        sender.backcolor = Color.Black
        ' sender.color = Color.White
        sender.ForeColor = Color.White
    End Sub

    Private Sub sname_LostFocus(sender As Object, e As EventArgs) Handles sname.LostFocus, add.LostFocus, city.LostFocus, s_phn.LostFocus, email.LostFocus, gst_no.LostFocus
        sender.backcolor = Color.White
        sender.ForeColor = Color.Black
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ToolStripButton1_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ToolStripButton2_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ToolStripButton3_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Supplier_master where Id=" & DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value)
                    loaddata()
                    MessageBox.Show("Record Deleted")
                    ToolStripButton1_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        loaddata()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Supplier_master")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value
            sname.Text = DataGridView1.Item("s_name", DataGridView1.CurrentCell.RowIndex).Value
            add.Text = DataGridView1.Item("s_add", DataGridView1.CurrentCell.RowIndex).Value
            city.Text = DataGridView1.Item("city_", DataGridView1.CurrentCell.RowIndex).Value
            s_phn.Text = DataGridView1.Item("S_phnno", DataGridView1.CurrentCell.RowIndex).Value
            email.Text = DataGridView1.Item("e_mail", DataGridView1.CurrentCell.RowIndex).Value
            gst_no.Text = DataGridView1.Item("gstno", DataGridView1.CurrentCell.RowIndex).Value

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub DataGridView1_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value
            sname.Text = DataGridView1.Item("s_name", DataGridView1.CurrentCell.RowIndex).Value
            add.Text = DataGridView1.Item("s_add", DataGridView1.CurrentCell.RowIndex).Value
            city.Text = DataGridView1.Item("city_", DataGridView1.CurrentCell.RowIndex).Value
            s_phn.Text = DataGridView1.Item("S_phnno", DataGridView1.CurrentCell.RowIndex).Value
            email.Text = DataGridView1.Item("e_mail", DataGridView1.CurrentCell.RowIndex).Value
            gst_no.Text = DataGridView1.Item("gstno", DataGridView1.CurrentCell.RowIndex).Value
            sname.Focus()
            savefile = 1
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub AddToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ToolStripButton1_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ToolStripButton2_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ToolStripButton3_Click(sender, e)
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