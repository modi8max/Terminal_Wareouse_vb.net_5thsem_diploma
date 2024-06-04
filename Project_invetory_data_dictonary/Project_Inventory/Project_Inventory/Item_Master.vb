Public Class Item_Master
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        TextBox1.Text = ""
        iname.Text = ""
        Cat.Text = ""
        u_o_m.Text = ""
        qty.Text = ""
        iname.Focus()
        savefile = 0
        loaddata()
    End Sub
    Dim savefile As Integer = 0
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If iname.Text <> "" Then
                If u_o_m.Text <> "" Then
                    If Cat.Text <> "" Then
                        If qty.Text <> "" Then
                            If savefile = 0 Then
                                'insert
                                Dim dss As New Daoclass
                                dss.adddata("Insert into Item_master(iname,uom,category,qty) values ( '" & iname.Text & "' , '" & u_o_m.Text & "','" & Cat.Text & "' , '" & qty.Text & "') ")
                                MessageBox.Show("Record Inserted")
                            Else
                                'update
                                If TextBox1.Text <> "" AndAlso IsNumeric(TextBox1.Text) Then
                                    Dim da As New Daoclass
                                    da.adddata("update Item_master set iname ='" & iname.Text & "',uom ='" & u_o_m.Text & "',category ='" & Cat.Text & "',qty ='" & qty.Text & "' where Id= " & TextBox1.Text)
                                    MessageBox.Show("Record Updated")
                                Else
                                    MessageBox.Show("Select valid Record")
                                    ToolStripButton1_Click(sender, e)

                                End If
                            End If
                        Else
                            MessageBox.Show("Enter Valid qty")
                            qty.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid catagory")
                        Cat.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid UnitOf Mesurement")
                    u_o_m.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Item Name")
                iname.Focus()
            End If
        End If
        loaddata()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ToolStripButton1_Click(sender, e)

    End Sub

    Private Sub Item_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            loaddata()
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select distinct (cname) from category_master")
            Cat.DataSource = ds.Tables(0)
            Cat.ValueMember = "cname"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles qty.KeyPress, iname.KeyPress, Cat.KeyPress, u_o_m.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = iname.Name Then
                u_o_m.Focus()
            ElseIf sender.name = u_o_m.Name Then
                Cat.Focus()
            ElseIf sender.name = Cat.Name Then
                qty.Focus()
            ElseIf sender.name = qty.Name Then
                ToolStripButton2_Click(sender, e)
            End If
        End If
        If sender.name = u_o_m.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = Cat.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = qty.Name Then
            Dim d As New Daoclass
            e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = iname.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = Cat.Name Then
            Dim d As New Daoclass
            e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = u_o_m.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        'If sender.name = add.Name Or sender.name = gst_no.Name Or sender.name = email.Name Then
        '    Dim d As New Daoclass
        '    ' e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        '    Dim f As Boolean = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        '    e.Handled = f
        '    If f Then
        '        sender.backcolor = Color.Red
        '    Else
        '        sender.backcolor = Color.Yellow
        '        sender.forecolor = Color.Black
        '    End If
        'End If
    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Item_master")
        DataGridView1.DataSource = ds.Tables(0)
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

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub



    Private Sub DataGridView1_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            iname.Text = DataGridView1.Item("i_name", DataGridView1.CurrentCell.RowIndex).Value
            u_o_m.Text = DataGridView1.Item("u_of_m", DataGridView1.CurrentCell.RowIndex).Value
            Cat.Text = DataGridView1.Item("categoyy", DataGridView1.CurrentCell.RowIndex).Value
            qty.Text = DataGridView1.Item("qty_", DataGridView1.CurrentCell.RowIndex).Value
            TextBox1.Text = DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value
            iname.Focus()
            savefile = 1
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ToolStripButton3_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ToolStripButton2_Click(sender, e)

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Item_master where Id=" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value)
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

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Cat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cat.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class