Imports CrystalDecisions.CrystalReports.Engine

Public Class Terminal_Inward
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub
    Dim savefile As Integer = 0
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        'new button
        ino.Text = ""
        i_date.Text = ""
        Idate.Text = ""
        tname.Text = ""
        dname.Text = ""
        in_no.Text = ""
        t_name.Text = ""
        d_name.Text = ""
        cat_.Text = ""
        iname.Text = ""
        Uom.Text = ""
        Rate.Text = ""
        Qty.Text = ""
        Tot.Text = ""
        ino.Focus()
        savefile = 0
        loaddata()
        id.Text = ""

    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From TInward")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView2.DataSource = ds.Tables(0)
        ino.Focus()
    End Sub
    Private Sub ino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ino.SelectedIndexChanged
        Try

            If ino.Text <> "" Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select issue_date,rec_byt,rec_byd,terminal,department,iname from Outward where issue_no ='" & ino.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    i_date.Value = ds.Tables(0).Rows(0).Item("issue_date")
                    tname.Text = ds.Tables(0).Rows(0).Item("rec_byt")
                    dname.Text = ds.Tables(0).Rows(0).Item("rec_byd")
                    t_name.Text = ds.Tables(0).Rows(0).Item("terminal")
                    d_name.Text = ds.Tables(0).Rows(0).Item("department")
                    '  iname.Text = ds.Tables(0).Rows(0).Item("iname")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Terminal_Inward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_issue_no()
        load_item()
        loaddata()
        load_terminal()
        load_dep()
    End Sub
    Private Sub load_dep()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select dname,Id from Department_master")
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.DisplayMember = "dname"
            ComboBox1.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_terminal()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select tname,Id from terminal_master")
            ComboBox2.DataSource = ds.Tables(0)
            ComboBox2.DisplayMember = "tname"
            ComboBox2.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_item()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select cname,Id from category_master")
            cat_.DataSource = ds.Tables(0)
            cat_.DisplayMember = "cname"
            cat_.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub load_issue_no()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select distinct(issue_no) from Outward")
            ino.DataSource = ds.Tables(0)
            ino.DisplayMember = "issue_no"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub iname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles iname.SelectedIndexChanged
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

    Private Sub cat__SelectedIndexChanged(sender As Object, e As EventArgs) Handles cat_.SelectedIndexChanged
        Try

            If IsNumeric(cat_.SelectedValue) And cat_.Items.Count > 0 Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select iname,Id from Item_master where category='" & cat_.Text & "' ")
                iname.DataSource = ds.Tables(0)
                iname.DisplayMember = "iname"
                iname.ValueMember = "Id"
                'ComboBox3.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Rate_TextChanged(sender As Object, e As EventArgs) Handles Rate.TextChanged
        Tot.Text = Val(Qty.Text) * Val(Rate.Text)

    End Sub

    Private Sub Tot_TextChanged(sender As Object, e As EventArgs) Handles Tot.TextChanged
        Tot.Text = Val(Qty.Text) * Val(Rate.Text)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            id.Text = DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value
            ino.Text = DataGridView1.Item("issue_no_", DataGridView1.CurrentCell.RowIndex).Value
            i_date.Text = DataGridView1.Item("issue_date_", DataGridView1.CurrentCell.RowIndex).Value
            Idate.Text = DataGridView1.Item("idate_", DataGridView1.CurrentCell.RowIndex).Value
            tname.Text = DataGridView1.Item("rec_byt", DataGridView1.CurrentCell.RowIndex).Value
            dname.Text = DataGridView1.Item("rec_byd_", DataGridView1.CurrentCell.RowIndex).Value
            in_no.Text = DataGridView1.Item("ino_", DataGridView1.CurrentCell.RowIndex).Value
            t_name.Text = DataGridView1.Item("tname_", DataGridView1.CurrentCell.RowIndex).Value
            d_name.Text = DataGridView1.Item("dname_", DataGridView1.CurrentCell.RowIndex).Value
            cat_.Text = DataGridView1.Item("category_", DataGridView1.CurrentCell.RowIndex).Value
            iname.Text = DataGridView1.Item("iname_", DataGridView1.CurrentCell.RowIndex).Value
            Uom.Text = DataGridView1.Item("uom_", DataGridView1.CurrentCell.RowIndex).Value
            Qty.Text = DataGridView1.Item("qty_", DataGridView1.CurrentCell.RowIndex).Value
            Rate.Text = DataGridView1.Item("rate_", DataGridView1.CurrentCell.RowIndex).Value
            savefile = 1
        End If
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If ino.Text <> "" Then
                If i_date.Text <> "" Then
                    If Idate.Text <> "" Then
                        If tname.Text <> "" Then
                            If dname.Text <> "" Then
                                If in_no.Text <> "" Then
                                    If t_name.Text <> "" Then
                                        If d_name.Text <> "" Then
                                            If cat_.Text <> "" Then

                                                If iname.Text <> "" Then
                                                    If Uom.Text <> "" Then
                                                        If Qty.Text <> "" Then



                                                            If savefile = 0 Then
                                                                'insert
                                                                Dim dss As New Daoclass
                                                                Dim f As Boolean = dss.validate_date("Select id from Inward where ino='" & ino.Text & "'")

                                                                dss.adddata("Insert into Tinward(issue_no,issue_date,idate,rec_byt,rec_byd,ino,tname,dname,category,iname,uom,qty,rate) values ( '" & ino.Text & "' , '" & i_date.Text & "','" & Idate.Text & "' , '" & tname.Text & "','" & dname.Text & "' , '" & in_no.Text & "', '" & t_name.Text & "','" & d_name.Text & "', '" & cat_.Text & "', '" & iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "', '" & Rate.Text & "') ")
                                                                MessageBox.Show("Record Inserted")
                                                                Check_stock()


                                                            Else
                                                                'update
                                                                If id.Text <> "" AndAlso IsNumeric(id.Text) Then
                                                                    Dim da As New Daoclass
                                                                    da.adddata("update Tinward set issue_no ='" & ino.Text & "',issue_date ='" & i_date.Text & "',idate ='" & Idate.Text & "',rec_byt ='" & tname.Text & "',rec_byd ='" & dname.Text & "',ino ='" & in_no.Text & "',tname ='" & t_name.Text & "',dname ='" & d_name.Text & "',category ='" & cat_.Text & "',iname ='" & iname.Text & "',uom ='" & Uom.Text & "',qty ='" & Qty.Text & "',rate ='" & Rate.Text & "'where Id= " & id.Text)
                                                                    MessageBox.Show("Record Updated")
                                                                    Check_stock()
                                                                Else
                                                                    MessageBox.Show("Select valid Record")
                                                                    'ToolStripButton3_Click(sender, e)

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
                                                d_name.Focus()
                                            End If
                                        Else
                                            MessageBox.Show("Enter Valid terminal")
                                            t_name.Focus()
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
                                tname.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid Rec By department")
                            dname.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid Rec By Terminal")
                        Idate.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid issue date")
                    i_date.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid issue no")
                ino.Focus()
            End If
            loaddata()
        End If

    End Sub
    Private Sub Check_stock()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            Dim oqty As Double = 0
            Dim nqty As Double = 0
            ds = d.loaddataset("select qty from stock_master where iname ='" & iname.Text & "' And tname ='" & tname.Text & "' And dname ='" & dname.Text & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                oqty = Val(ds.Tables(0).Rows(0).Item(0))

                nqty = oqty + Val(Qty.Text)

                d.adddata("update stock_master set qty =" & nqty & "where iname ='" & iname.Text & "' And tname ='" & tname.Text & "' And dname ='" & dname.Text & "'")
            Else
                d.adddata("Insert into stock_master(tname,dname,category,iname,uom,qty) values (  '" & tname.Text & "','" & dname.Text & "', '" & cat_.Text & "', '" & iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "') ")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from TInward where Id=" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value)
                    loaddata()
                    MessageBox.Show("Record Deleted")
                    ToolStripButton3_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        loaddata()
    End Sub

    Private Sub Terminal_Inward_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Uom.KeyPress, Tot.KeyPress, tname.KeyPress, t_name.KeyPress, Rate.KeyPress, Qty.KeyPress, ino.KeyPress, iname.KeyPress, in_no.KeyPress, Idate.KeyPress, i_date.KeyPress, dname.KeyPress, d_name.KeyPress, cat_.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = ino.Name Then
                i_date.Focus()
            ElseIf sender.name = i_date.Name Then
                Idate.Focus()
            ElseIf sender.name = Idate.Name Then
                tname.Focus()

            ElseIf sender.name = tname.Name Then
                dname.Focus()
            ElseIf sender.name = dname.Name Then
                in_no.Focus()
            ElseIf sender.name = in_no.Name Then
                t_name.Focus()
            ElseIf sender.name = t_name.Name Then
                d_name.Focus()
            ElseIf sender.name = d_name.Name Then
                cat_.Focus()
            ElseIf sender.name = cat_.Name Then
                iname.Focus()
            ElseIf sender.name = iname.Name Then
                Uom.Focus()
            ElseIf sender.name = Uom.Name Then
                Qty.Focus()
            ElseIf sender.name = Qty.Name Then
                Rate.Focus()
            ElseIf sender.name = Rate.Name Then
                Tot.Focus()
            ElseIf sender.name = Tot.Name Then
                ToolStripButton2_Click_1(sender, e)
            End If
        End If
        If sender.name = ino.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = dname.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = tname.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = t_name.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = d_name.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = cat_.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = iname.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = ino.Name Then
            Dim d As New Daoclass
            e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = Qty.Name Then
            Dim d As New Daoclass
            e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = iname.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = d_name.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = t_name.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = tname.Name Then
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
        If sender.name = Rate.Name Then
            Dim d As New Daoclass
            e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = Tot.Name Then
            Dim d As New Daoclass
            e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
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
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_KeyPress_1(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Dim dk As New DataSet
    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    If ComboBox1.Text <> "" Then
    '        If ComboBox2.Text <> "" Then
    '            Dim d As New Daoclass
    '            Dim ds As New DataSet
    '            ds = d.loaddataset("select * from TInward where tname='" & ComboBox2.Text & "' and dname='" & ComboBox1.Text & "' and (issue_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "')")
    '            ' ds = d.loaddataset("select * from Inward")
    '            ' TabControl1.SelectedIndex = 1
    '            loaddata()

    '            DataGridView2.DataSource = ds.Tables(0)
    '            dk = ds
    '        Else
    '            MessageBox.Show("Enter valid Department")
    '            ComboBox2.Focus()
    '        End If
    '    Else
    '        MessageBox.Show("Enter valid Terminal")
    '        ComboBox1.Focus()
    '    End If
    'End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    'Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
    '    Try
    '        Dim d As New Terminal_Inward_rpt

    '        d.Load()
    '        Dim orpt As New ReportDocument
    '        orpt.Load(d.FileName)
    '        orpt.SetDataSource(dk.Tables(0))
    '        CrystalReportViewer2.ReportSource = orpt
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        loaddata()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub





    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Button1_Click(sender, e)
    End Sub



    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from TInward where tname ='" & t_name.Text & "' And dname ='" & d_name.Text & "' And category ='" & cat_.Text & "'And iname ='" & iname.Text & "' And  uom ='" & Uom.Text & "' And qty ='" & Qty.Text & "'And   rate ='" & Rate.Text & "'")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Terminal_Inward_rpt
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", ino.Text)
            orpt.SetParameterValue("p2", i_date.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p3", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p4", tname.Text)
            orpt.SetParameterValue("p5", dname.Text)
            orpt.SetParameterValue("p6", in_no.Text)
            orpt.SetParameterValue("p7", Val(Qty.Text) * Val(Rate.Text))
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton7_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from TInward")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Terminal_Inward_rpt
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", ino.Text)
            orpt.SetParameterValue("p2", i_date.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p3", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p4", tname.Text)
            orpt.SetParameterValue("p5", dname.Text)
            orpt.SetParameterValue("p6", in_no.Text)
            orpt.SetParameterValue("p7", Val(Qty.Text) * Val(Rate.Text))
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If ComboBox1.Text <> "" Then
            If ComboBox2.Text <> "" Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select * from TInward where tname='" & ComboBox2.Text & "' and dname='" & ComboBox1.Text & "' and (issue_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "')")
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

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Try
            Dim d As New Terminal_Inward_rpt

            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            orpt.SetParameterValue("p1", ino.Text)
            orpt.SetParameterValue("p2", i_date.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p3", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p4", tname.Text)
            orpt.SetParameterValue("p5", dname.Text)
            orpt.SetParameterValue("p6", in_no.Text)
            orpt.SetParameterValue("p7", Val(Qty.Text) * Val(Rate.Text))
            CrystalReportViewer1.ReportSource = orpt
            CrystalReportViewer2.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub






    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.WindowState = FormWindowState.Maximized
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

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker2.KeyPress, DateTimePicker1.KeyPress, ComboBox2.KeyPress, ComboBox1.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = ComboBox1.Name Then
                ComboBox2.Focus()
            ElseIf sender.name = Combobox2.Name Then
                DateTimePicker1.Focus()
            ElseIf sender.name = DateTimePicker1.Name Then
                DateTimePicker2.Focus()

            ElseIf sender.name = tname.Name Then
                ToolStripButton2_Click_1(sender, e)
            End If
        End If
        If sender.name = ComboBox2.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = ComboBox1.Name Then
            AutoSearch(sender, e, True)
        End If
        If sender.name = ComboBox1.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = ComboBox2.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If

    End Sub
End Class