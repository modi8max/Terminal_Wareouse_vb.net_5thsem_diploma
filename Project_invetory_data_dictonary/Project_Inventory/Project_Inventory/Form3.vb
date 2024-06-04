Imports CrystalDecisions.CrystalReports.Engine

Public Class Form3
    Dim savefile As Integer = 0
    Private Sub FlowLayoutPanel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loaddata()
        load_item()
        ' load_id()
        load_terminal()
        load_dep()
        load_Supplier()
    End Sub
    Private Sub load_dep()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select dname,Id from Department_master")
            dept.DataSource = ds.Tables(0)
            dept.DisplayMember = "dname"
            dept.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Inward")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub load_terminal()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select tname,Id from terminal_master")
            Ter1.DataSource = ds.Tables(0)
            Ter1.DisplayMember = "tname"
            Ter1.ValueMember = "Id"
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
            Cat.DataSource = ds.Tables(0)
            Cat.DisplayMember = "cname"
            Cat.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub load_id()
    '    Try
    '        Dim d As New Daoclass
    '        Dim ds As New DataSet
    '        ds = d.loaddataset("select p_id,Id from stock_Master")
    '        ComboBox1.DataSource = ds.Tables(0)
    '        ComboBox1.DisplayMember = "p_id"
    '        ComboBox1.ValueMember = "Id"
    '        'ComboBox1.Text = " "
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub load_Supplier()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select distinct(sname) from Supplier_master")
            Sname.DataSource = ds.Tables(0)
            Sname.DisplayMember = "sname"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Sname.SelectedIndexChanged
        Try

            If Sname.Text <> "" Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select sadd from Supplier_master where sname ='" & Sname.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    Sadd.Text = ds.Tables(0).Rows(0).Item(0)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cat.SelectedIndexChanged
        Try

            If IsNumeric(Cat.SelectedValue) And Cat.Items.Count > 0 Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select iname,Id from Item_master where category='" & Cat.Text & "' ")
                Iname.DataSource = ds.Tables(0)
                Iname.DisplayMember = "iname"
                Iname.ValueMember = "Id"
                'ComboBox3.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If IsNumeric(ToolStripButton5.Text) Then
                Dim d As New Daoclass
                Dim ds As New DataSet

                ds = d.loaddataset("select * from Item_master where " & "Id ='" & ToolStripButton5.Text & "'")

                If ds.Tables(0).Rows.Count > 0 Then
                    Cat.Text = ds.Tables(0).Rows(0).Item("category")
                    Iname.Text = ds.Tables(0).Rows(0).Item("iname")
                    Uom.Text = ds.Tables(0).Rows(0).Item("uom")
                    Qty.Text = ds.Tables(0).Rows(0).Item("qty")


                End If

            Else
                ToolStripButton5.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        ToolStripButton4_Click(sender, e)
        'loaddata()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Iname.SelectedIndexChanged
        If IsNumeric(Iname.SelectedValue) And Iname.Items.Count > 0 Then

            Dim d As New Daoclass
            Dim ds As New DataSet
            'ds = d.loaddataset("select * from Item_master where Id='" & ComboBox3.Text & "' ")

            ds = d.loaddataset("select * from Item_master where " & "Id =" & Iname.SelectedValue)
            If ds.Tables(0).Rows.Count > 0 Then
                Uom.Text = ds.Tables(0).Rows(0).Item("uom")
                Qty.Text = ds.Tables(0).Rows(0).Item("qty")
            Else
                Iname.Focus()
            End If
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged

    End Sub

    'Private Sub calculate_price()
    '    Try
    '        Dim dis_amt As Double = 0
    '        dis_amt = Math.Round(Val(TextBox6.Text) * Val(TextBox5.Text) / 100, 2)
    '        Dim brate As Double = Val(TextBox5.Text) - dis_amt
    '        ' TextBox5.Text = brate
    '        Dim tot As Double = brate * Val(TextBox10.Text)
    '        Dim gst_tot As Double = Math.Round(tot * Val(TextBox8.Text) / 100, 2)
    '        TextBox9.Text = gst_tot + tot
    '    Catch ex As Exception

    '    End Try
    'End Sub



    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'save button
        Dim d As Integer
        d = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If d = 6 Then
            If Sname.Text <> "" Then
                If Sadd.Text <> "" Then
                    If Ino.Text <> "" Then
                        If Bno.Text <> "" Then
                            If Ter1.Text <> "" Then
                                If dept.Text <> "" Then
                                    If Cat.Text <> "" Then
                                        If Iname.Text <> "" Then
                                            If Uom.Text <> "" Then
                                                If Qty.Text <> "" Then
                                                    If Rate.Text <> "" Then


                                                        If savefile = 0 Then
                                                            'insert
                                                            Dim dss As New Daoclass
                                                            Dim f As Boolean = dss.validate_date("Select id from Inward where ino='" & Ino.Text & "'")

                                                            dss.adddata("Insert into Inward(sname,sadd,idate,ino,bill_no,bill_date,tname,dname,category,iname,uom,qty,rate) values ( '" & Sname.Text & "' , '" & Sadd.Text & "','" & Idate.Text & "' , '" & Ino.Text & "','" & Bno.Text & "' , '" & Bdate.Text & "', '" & Ter1.Text & "','" & dept.Text & "', '" & Cat.Text & "', '" & Iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "', '" & Rate.Text & "') ")
                                                            MessageBox.Show("Record Inserted")
                                                            Check_stock()


                                                        Else
                                                            'update
                                                            If TextBox1.Text <> "" AndAlso IsNumeric(TextBox1.Text) Then
                                                                Dim da As New Daoclass
                                                                da.adddata("update Inward set sname ='" & Sname.Text & "',sadd ='" & Sadd.Text & "',idate ='" & Idate.Text & "',ino ='" & Ino.Text & "',bill_no ='" & Bno.Text & "',bill_date ='" & Bdate.Text & "',tname ='" & Ter1.Text & "',dname ='" & dept.Text & "',category ='" & Cat.Text & "',iname ='" & Iname.Text & "',uom ='" & Uom.Text & "',qty ='" & Qty.Text & "',rate ='" & Rate.Text & "'where Id= " & TextBox1.Text)
                                                                MessageBox.Show("Record Updated")
                                                                Check_stock()

                                                            Else
                                                                MessageBox.Show("Select valid Record")
                                                                ToolStripButton3_Click(sender, e)

                                                            End If
                                                        End If
                                                    Else
                                                        MessageBox.Show("Enter Valid rate")
                                                        Rate.Focus()
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
                                            Iname.Focus()
                                        End If
                                    Else
                                        MessageBox.Show("Enter Valid category")
                                        Cat.Focus()
                                    End If
                                Else
                                    MessageBox.Show("Enter Valid Department")
                                    dept.Focus()
                                End If
                            Else
                                MessageBox.Show("Enter Valid terminal")
                                Ter1.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid Bill No")
                            Bno.Focus()
                        End If

                    Else
                        MessageBox.Show("Enter Valid Inward No")
                        Ino.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid Address")
                    Sadd.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Supplier Name")
                Sname.Focus()
            End If
            loaddata()
        End If
    End Sub
    Dim f As Boolean = 0
    'Private Sub update_data()
    '    Try
    '        Dim oqty As Double = 0
    '        Dim nqty As Double = 0
    '        Dim d As New Daoclass
    '        Dim ds As New DataSet
    '        ds = d.loaddataset("select qty from stock_master where iname ='" & Iname.Text & "' And tname ='" & Ter1.Text & "' And dname ='" & dept.Text & "'")
    '        'Dim dd As Integer = Val(Id)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            oqty = Val(ds.Tables(0).Rows(0).Item(0))
    '        End If
    '        If f Then
    '            nqty = oqty + Val(Qty.Text)
    '        Else
    '            nqty = oqty - Val(Qty.Text)
    '        End If
    '        d.adddata("update stock_Master set qty =" & nqty & " where iname ='" & Iname.Text & "'And tname ='" & Ter1.Text & "' And dname ='" & dept.Text & "'")
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub Check_stock()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            Dim oqty As Double = 0
            Dim nqty As Double = 0
            ds = d.loaddataset("select qty from stock_master where iname ='" & Iname.Text & "' And tname ='" & Ter1.Text & "' And dname ='" & dept.Text & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                oqty = Val(ds.Tables(0).Rows(0).Item(0))

                nqty = oqty + Val(Qty.Text)

                d.adddata("update stock_master set qty =" & nqty & "where iname ='" & Iname.Text & "' And tname ='" & Ter1.Text & "' And dname ='" & dept.Text & "'")
            Else
                d.adddata("Insert into stock_master(tname,dname,category,iname,uom,qty) values (  '" & Ter1.Text & "','" & dept.Text & "', '" & Cat.Text & "', '" & Iname.Text & "', '" & Uom.Text & "', '" & Qty.Text & "') ")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        'new button
        Sname.Text = ""
        Sadd.Text = ""
        Bdate.Text = ""
        Bno.Text = ""
        Idate.Text = ""
        Ino.Text = ""
        Ter1.Text = ""
        dept.Text = ""
        Cat.Text = ""
        Iname.Text = ""
        Uom.Text = ""
        Rate.Text = ""
        Qty.Text = ""
        Tot.Text = ""
        Sname.Focus()
        savefile = 0
        loaddata()
        TextBox1.Text = ""

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles Idate.ValueChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Uom.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            TextBox1.Text = DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value
            Sname.Text = DataGridView1.Item("sname_", DataGridView1.CurrentCell.RowIndex).Value
            Sadd.Text = DataGridView1.Item("sadd_", DataGridView1.CurrentCell.RowIndex).Value
            Idate.Text = DataGridView1.Item("idate_", DataGridView1.CurrentCell.RowIndex).Value
            Ino.Text = DataGridView1.Item("Ino_", DataGridView1.CurrentCell.RowIndex).Value
            Bno.Text = DataGridView1.Item("bill_no_", DataGridView1.CurrentCell.RowIndex).Value
            Bdate.Text = DataGridView1.Item("bill_date_", DataGridView1.CurrentCell.RowIndex).Value
            Ter1.Text = DataGridView1.Item("tname_", DataGridView1.CurrentCell.RowIndex).Value
            dept.Text = DataGridView1.Item("dept1", DataGridView1.CurrentCell.RowIndex).Value
            Cat.Text = DataGridView1.Item("category_", DataGridView1.CurrentCell.RowIndex).Value
            Iname.Text = DataGridView1.Item("iname_", DataGridView1.CurrentCell.RowIndex).Value
            Uom.Text = DataGridView1.Item("uom_", DataGridView1.CurrentCell.RowIndex).Value
            Qty.Text = DataGridView1.Item("qty_", DataGridView1.CurrentCell.RowIndex).Value
            Rate.Text = DataGridView1.Item("rate_", DataGridView1.CurrentCell.RowIndex).Value
            savefile = 1
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'new button
        Sname.Text = ""
        Sadd.Text = ""
        Bdate.Text = ""
        Bno.Text = ""
        Idate.Text = ""
        Ino.Text = ""
        Ter1.Text = ""
        dept.Text = ""
        Cat.Text = ""
        Iname.Text = ""
        Uom.Text = ""
        Rate.Text = ""
        Qty.Text = ""
        Tot.Text = ""
        Sname.Focus()
        savefile = 0
        loaddata()
        TextBox1.Text = ""
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Rate_TextChanged(sender As Object, e As EventArgs) Handles Rate.TextChanged

    End Sub

    Private Sub Rate_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = Sname.Name Then
                '    Sadd.Focus()
                'ElseIf sender.name = Sadd.Name Then
                Idate.Focus()
            ElseIf sender.name = Idate.Name Then
                Ino.Focus()
            ElseIf sender.name = Ino.Name Then
                Bno.Focus()
            ElseIf sender.name = Bno.Name Then
                Bdate.Focus()
            ElseIf sender.name = Bdate.Name Then
                Ter1.Focus()
            ElseIf sender.name = Ter1.Name Then
                dept.Focus()
            ElseIf sender.name = dept.Name Then
                Cat.Focus()
            ElseIf sender.name = Cat.Name Then
                Iname.Focus()
            ElseIf sender.name = Iname.Name Then
                Uom.Focus()
            ElseIf sender.name = Uom.Name Then
                Qty.Focus()
            ElseIf sender.name = Qty.Name Then
                Rate.Focus()
            ElseIf sender.name = Rate.Name Then
                Tot.Focus()
            ElseIf sender.name = Tot.Name Then
                ToolStripButton2_Click(sender, e)

            End If
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim d As Integer = MessageBox.Show("Do you Want To Delete ?" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value & "?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If d = 6 Then
                    Dim da As New Daoclass
                    da.adddata("delete from Inward where Id=" & DataGridView1.Item("id_", DataGridView1.CurrentCell.RowIndex).Value)
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

    'Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
    '    Try
    '        If Ter1.Text <> "" And dept.Text <> "" And Cat.Text <> "" And Iname.Text <> "" Then
    '            Dim d As New Daoclass
    '            Dim ds As New DataSet

    '            ds = d.loaddataset("select tname,dname,category,iname from stock_master where " & "p_id ='" & Label17.Text & "'")

    '            If ds.Tables(0).Rows.Count > 0 Then
    '                Label17.Text = ds.Tables(0).Rows(0).Item("p_id")
    '                ComboBox1.Text = ds.Tables(0).Rows(0).Item("p_id")


    '            End If

    '        Else
    '            ToolStripButton5.Focus()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        ' ToolStripButton7_Click(sender, e)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dept.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from Inward where tname ='" & Ter1.Text & "' And dname ='" & dept.Text & "' And category ='" & Cat.Text & "'And iname ='" & Iname.Text & "' And uom ='" & Uom.Text & "' And category ='" & Cat.Text & "'")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Inward_Invoice
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", Sname.Text)
            orpt.SetParameterValue("p2", Sadd.Text)
            orpt.SetParameterValue("p3", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p4", Ino.Text)
            orpt.SetParameterValue("p5", Bdate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p6", Bno.Text)
            orpt.SetParameterValue("p7", Val(Qty.Text) * Val(Rate.Text))
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Tot.TextChanged, Rate.TextChanged, Qty.TextChanged
        Tot.Text = Val(Qty.Text) * Val(Rate.Text)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles Inward.Click

    End Sub

    Private Sub ToolStripButton9_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from Inward where tname ='" & Ter1.Text & "' And dname ='" & dept.Text & "' And category ='" & Cat.Text & "'And iname ='" & Iname.Text & "' And uom ='" & Uom.Text & "' And category ='" & Cat.Text & "'")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Inward_Invoice
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", Sname.Text)
            orpt.SetParameterValue("p2", Sadd.Text)
            orpt.SetParameterValue("p3", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p4", Ino.Text)
            orpt.SetParameterValue("p5", Bdate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p6", Bno.Text)
            orpt.SetParameterValue("p7", Val(Qty.Text) * Val(Rate.Text))
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from Inward")
            TabControl1.SelectedIndex = 1
            Dim d1 As New Inward_Invoice
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()

            orpt.SetParameterValue("p1", Sname.Text)
            orpt.SetParameterValue("p2", Sadd.Text)
            orpt.SetParameterValue("p3", Idate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p4", Ino.Text)
            orpt.SetParameterValue("p5", Bdate.Value.ToString("dd-mm-yyyy"))
            orpt.SetParameterValue("p6", Bno.Text)
            orpt.SetParameterValue("p7", Val(Qty.Text) * Val(Rate.Text))
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Sname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Uom.KeyPress, Tot.KeyPress, Ter1.KeyPress, Sname.KeyPress, Sadd.KeyPress, Rate.KeyPress, Qty.KeyPress, Ino.KeyPress, Iname.KeyPress, Idate.KeyPress, dept.KeyPress, Cat.KeyPress, Bno.KeyPress, Bdate.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = Sname.Name Then
                '    Sadd.Focus()
                'ElseIf sender.name = Sadd.Name Then
                Idate.Focus()
            ElseIf sender.name = Idate.Name Then
                Ino.Focus()
            ElseIf sender.name = Ino.Name Then
                Bno.Focus()
            ElseIf sender.name = Bno.Name Then
                Bdate.Focus()
            ElseIf sender.name = Bdate.Name Then
                Ter1.Focus()
            ElseIf sender.name = Ter1.Name Then
                dept.Focus()
            ElseIf sender.name = dept.Name Then
                Cat.Focus()
            ElseIf sender.name = Cat.Name Then
                Iname.Focus()
            ElseIf sender.name = Iname.Name Then
                Uom.Focus()
            ElseIf sender.name = Uom.Name Then
                Qty.Focus()
            ElseIf sender.name = Qty.Name Then
                Rate.Focus()
            ElseIf sender.name = Rate.Name Then
                Tot.Focus()
            ElseIf sender.name = Tot.Name Then
                ToolStripButton2_Click(sender, e)
            End If
        End If
        If sender.name = Ter1.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = Sname.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = ComboBox1.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = Cat.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = Iname.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = dept.Name Then
                AutoSearch(sender, e, True)
            End If
            If sender.name = Ino.Name Then
                Dim d As New Daoclass
                e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Bno.Name Then
                Dim d As New Daoclass
                e.Handled = d.alphaNumericvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Qty.Name Then
                Dim d As New Daoclass
                e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Rate.Name Then
                Dim d As New Daoclass
                e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Tot.Name Then
                Dim d As New Daoclass
                e.Handled = d.numbervalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Iname.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = ComboBox1.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Sname.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Ter1.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = dept.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Uom.Name Then
                Dim d As New Daoclass
                e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
            End If
            If sender.name = Sname.Name Then
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
    'Private Sub TabControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tot.KeyPress, Ter1.KeyPress, TabControl1.KeyPress, Sname.KeyPress, Rate.KeyPress, Ino.KeyPress, Iname.KeyPress, Idate.KeyPress, dept.KeyPress, Cat.KeyPress, Bno.KeyPress, Bdate.KeyPress
    '    If e.KeyChar.GetHashCode = 851981 Then
    '        If sender.name = ComboBox2.Name Then
    '            ComboBox1.Focus()
    '        ElseIf sender.name = ComboBox1.Name Then
    '            DateTimePicker1.Focus()
    '        ElseIf sender.name = DateTimePicker1.Name Then
    '            DateTimePicker2.Focus()
    '        ElseIf sender.name = DateTimePicker2.Name Then
    '            ToolStripButton15_Click(sender, e)

    '        End If
    '    End If

    'End Sub
End Class