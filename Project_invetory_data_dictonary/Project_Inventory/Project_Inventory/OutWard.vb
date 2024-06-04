Imports CrystalDecisions.CrystalReports.Engine

Public Class OutWard
    Dim savefile As Integer = 0
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Cat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles iname.SelectedIndexChanged
        If IsNumeric(iname.SelectedValue) And iname.Items.Count > 0 Then

            Dim d As New Daoclass
            Dim ds As New DataSet
            'ds = d.loaddataset("select * from Item_master where Id='" & ComboBox3.Text & "' ")

            ds = d.loaddataset("select * from Item_master where " & "Id =" & iname.SelectedValue)
            If ds.Tables(0).Rows.Count > 0 Then
                Uom.Text = ds.Tables(0).Rows(0).Item("uom")
                Qty.Text = ds.Tables(0).Rows(0).Item("qty")
            Else
                iname.Focus()
            End If
        End If
    End Sub

    Private Sub OutWard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_terminal()
        load_terminal1()
        load_item()
        load_dep()
        load_dep1()
        load_terminal2()
        loaddep3()
        '  load_Supplier()
        loaddata()
        Ino.Focus()
    End Sub
    Private Sub loaddep3()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select dname,Id from Department_master")
            ComboBox4.DataSource = ds.Tables(0)
            ComboBox4.DisplayMember = "dname"
            ComboBox4.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_terminal2()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select tname,Id from terminal_master")
            ComboBox3.DataSource = ds.Tables(0)
            ComboBox3.DisplayMember = "tname"
            ComboBox3.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub load_Supplier()
    '    Try
    '        Dim d As New Daoclass
    '        Dim ds As New DataSet
    '        ds = d.loaddataset("select distinct(sname) from Supplier_master")
    '        ComboBox1.DataSource = ds.Tables(0)
    '        ComboBox1.DisplayMember = "sname"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub load_terminal()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select tname,Id from terminal_master")
            Ter1.DataSource = ds.Tables(0)
            Ter1.DisplayMember = "tname"
            Ter1.ValueMember = "Id"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_terminal1()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select tname,Id from terminal_master")
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.DisplayMember = "tname"
            ComboBox1.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_item()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select iname,Id from Item_master")
            iname.DataSource = ds.Tables(0)
            iname.DisplayMember = "iname"
            iname.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_dep()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select dname,Id from Department_master")
            dname.DataSource = ds.Tables(0)
            dname.DisplayMember = "dname"
            dname.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_dep1()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select dname,Id from Department_master")
            ComboBox2.DataSource = ds.Tables(0)
            ComboBox2.DisplayMember = "dname"
            ComboBox2.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Uom_TextChanged(sender As Object, e As EventArgs) Handles Uom.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
    Dim flag As Boolean = True

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged, RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            flag = False

        Else
            flag = True
            'ToolStripButton2_Click(sender, e)
            Ino.Text = " "
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Ino.Text = ""
        Idate.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        Ter1.Text = ""
        dname.Text = ""
        iname.Text = ""
        Uom.Text = ""
        Qty.Text = ""
        Uom.Text = ""


        'savefile = 0
        ' loaddata()
    End Sub
    Private Sub OutWard_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Uom.KeyPress, Ter1.KeyPress, RadioButton2.KeyPress, RadioButton1.KeyPress, Qty.KeyPress, MyBase.KeyPress, Ino.KeyPress, iname.KeyPress, Idate.KeyPress, dname.KeyPress, ComboBox2.KeyPress, ComboBox1.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = Ino.Name Then
                Idate.Focus()
            ElseIf sender.name = Idate.Name Then
                ComboBox1.Focus()
            ElseIf sender.name = ComboBox1.Name Then
                ComboBox2.Focus()
            ElseIf sender.name = ComboBox2.Name Then
                Ter1.Focus()
            ElseIf sender.name = Ter1.Name Then
                dname.Focus()
            ElseIf sender.name = dname.Name Then
                iname.Focus()
            ElseIf sender.name = iname.Name Then
                Uom.Focus()
            ElseIf sender.name = Uom.Name Then
                Qty.Focus()
                'ElseIf sender.name = Qty.Name Then
                '    RadioButton1.Focus()
                'ElseIf sender.name = RadioButton1.Name Then
                '    RadioButton2.Focus()
            ElseIf sender.name = Qty.Name Then
                ToolStripButton2_Click(sender, e)

            End If
        End If
        If sender.name = Ter1.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = dname.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = ComboBox1.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = ComboBox2.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = Ino.Name Then
                Dim d As New Daoclass
                e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = qty.Name Then
                Dim d As New Daoclass
                e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = iname.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = ComboBox1.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = ComboBox2.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Ter1.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = dname.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Uom.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If

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
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'save button
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If Ino.Text <> "" Then
                If Idate.Text <> "" Then
                    If ComboBox1.Text <> "" Then
                        If ComboBox2.Text <> "" Then
                            If Ter1.Text <> "" Then
                                If dname.Text <> "" Then
                                    If iname.Text <> "" Then
                                        If Uom.Text <> "" Then
                                            If Qty.Text <> "" Then



                                                If savefile = 0 Then
                                                    'insert
                                                    Dim dss As New Daoclass
                                                    Check_stock()
                                                    If f Then
                                                        dss.adddata("Insert into Outward(issue_no,issue_date,rec_byt,rec_byd,terminal,department,iname,uom,qty) values ( '" & Ino.Text & "' , '" & Idate.Text & "','" & ComboBox1.Text & "' , '" & ComboBox2.Text & "','" & Ter1.Text & "' , '" & dname.Text & "', '" & iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "') ")
                                                        MessageBox.Show("Record Inserted")
                                                        'If flag Then
                                                        '    dss.adddata("Insert into stock_master(tname,dname,iname,uom,qty,category) values (  '" & ComboBox1.Text & "','" & ComboBox2.Text & "',  '" & iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "') ")

                                                        'End If
                                                    End If


                                                Else
                                                    'update
                                                    If TextBox1.Text <> "" AndAlso IsNumeric(TextBox1.Text) Then
                                                        Dim da As New Daoclass
                                                        Check_stock()
                                                        If f Then
                                                            da.adddata("update OutWard set issue_no ='" & Ino.Text & "',issue_date ='" & Idate.Text & "',rec_byt ='" & ComboBox1.Text & "',rec_byd ='" & ComboBox2.Text & "',terminal ='" & Ter1.Text & "',department ='" & dname.Text & "',iname ='" & iname.Text & "',uom ='" & Uom.Text & "',qty ='" & Qty.Text & "'where Id= " & TextBox1.Text)
                                                            ' Check_stock()
                                                            MessageBox.Show("Record Updated")
                                                        End If
                                                    Else
                                                        MessageBox.Show("Select valid Record")
                                                        ToolStripButton3_Click(sender, e)

                                                    End If
                                                End If

                                            Else
                                                MessageBox.Show("Enter Valid Qty")
                                                Qty.Focus()
                                            End If
                                        Else
                                            MessageBox.Show("Enter Valid uom")
                                            Uom.Focus()
                                        End If
                                    Else
                                        MessageBox.Show("Enter Valid Item Name")
                                        iname.Focus()
                                    End If
                                Else
                                    MessageBox.Show("Enter Valid Department")
                                    dname.Focus()
                                End If
                            Else
                                MessageBox.Show("Enter Valid terminal")
                                Ter1.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid Rec By department")
                            ComboBox2.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid Rec By Terminal")
                        ComboBox1.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid issue date")
                    Idate.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid issue no")
                Ino.Focus()
            End If
            loaddata()
        End If
    End Sub
    Dim f As Boolean = True
    Dim f1 As Boolean = True
    Private Sub Check_stock()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            Dim oqty As Double = 0
            Dim nqty As Double = 0
            ds = d.loaddataset("select qty from stock_master where iname ='" & iname.Text & "' And tname ='" & Ter1.Text & "' And dname ='" & dname.Text & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                If Val(ds.Tables(0).Rows(0).Item(0)) < Val(Qty.Text) Then
                    MessageBox.Show("Stock Not Available")
                    f = False
                Else
                    f = True
                    oqty = Val(ds.Tables(0).Rows(0).Item(0))
                    nqty = oqty - Val(Qty.Text)

                    d.adddata("update stock_master set qty =" & nqty & "where iname ='" & iname.Text & "' And tname ='" & Ter1.Text & "' And dname ='" & dname.Text & "'")

                End If
            Else
                d.adddata("Insert into stock_master(tname,dname,iname,uom,qty) values (  '" & Ter1.Text & "','" & dname.Text & "',  '" & iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "') ")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        ToolStripButton2_Click(sender, e)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub dname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dname.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Outward")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value
            Ino.Text = DataGridView1.Item("I_no", DataGridView1.CurrentCell.RowIndex).Value
            Idate.Text = DataGridView1.Item("I_date", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox1.Text = DataGridView1.Item("r_byt", DataGridView1.CurrentCell.RowIndex).Value
            ComboBox2.Text = DataGridView1.Item("r_byd", DataGridView1.CurrentCell.RowIndex).Value
            Ter1.Text = DataGridView1.Item("T_name", DataGridView1.CurrentCell.RowIndex).Value
            dname.Text = DataGridView1.Item("Dept", DataGridView1.CurrentCell.RowIndex).Value
            iname.Text = DataGridView1.Item("i_name", DataGridView1.CurrentCell.RowIndex).Value
            Uom.Text = DataGridView1.Item("uom_", DataGridView1.CurrentCell.RowIndex).Value
            Qty.Text = DataGridView1.Item("qty_", DataGridView1.CurrentCell.RowIndex).Value
            savefile = 1
            loaddata()
        End If
    End Sub







    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from outward")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Outward_rpt1
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", Ino.Text)
            orpt.SetParameterValue("p2", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p3", ComboBox1.Text)
            orpt.SetParameterValue("p4", ComboBox2.Text)
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from outward where terminal ='" & Ter1.Text & "' And department ='" & dname.Text & "' And iname ='" & iname.Text & "'And  uom ='" & Uom.Text & "' And qty ='" & Qty.Text & "'")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Outward_rpt1
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", Ino.Text)
            orpt.SetParameterValue("p2", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p3", ComboBox1.Text)
            orpt.SetParameterValue("p4", ComboBox2.Text)
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label21_Click_1(sender As Object, e As EventArgs) Handles Label21.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label20_Click_1(sender As Object, e As EventArgs) Handles Label20.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Label22_Click_1(sender As Object, e As EventArgs) Handles Label22.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub
    Dim dk As New DataSet
    Private Sub ToolStripButton15_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If ComboBox1.Text <> "" Then
            If ComboBox2.Text <> "" Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select * from Outward where terminal='" & ComboBox3.Text & "' and department='" & ComboBox4.Text & "' and (issue_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "')")
                ' ds = d.loaddataset("select * from Inward")
                ' TabControl1.SelectedIndex = 1
                loaddata()

                DataGridView2.DataSource = ds.Tables(0)
                dk = ds
            Else
                MessageBox.Show("Enter valid Department")
                ComboBox2.Focus()
            End If
        Else
            MessageBox.Show("Enter valid Terminal")
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub ToolStripButton14_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Try
            Dim d As New Outward_rpt1

            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            orpt.SetParameterValue("p1", Ino.Text)
            orpt.SetParameterValue("p2", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p3", ComboBox1.Text)
            orpt.SetParameterValue("p4", ComboBox2.Text)



            CrystalReportViewer2.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class