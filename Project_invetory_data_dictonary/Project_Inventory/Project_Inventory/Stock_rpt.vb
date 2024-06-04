Imports CrystalDecisions.CrystalReports.Engine

Public Class Stock_rpt
    Private Sub Stock_rpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_combodata()
        load_dep()
        load_terminal()
        load_item()
    End Sub

    Private Sub load_combodata()

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
            ComboBox3.DataSource = ds.Tables(0)
            ComboBox3.DisplayMember = "cname"
            ComboBox3.ValueMember = "Id"
            ' ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try

            If IsNumeric(ComboBox3.SelectedValue) And ComboBox3.Items.Count > 0 Then
                Dim d As New Daoclass
                Dim ds As New DataSet
                ds = d.loaddataset("select iname,Id from Item_master where category='" & ComboBox3.Text & "' ")
                ComboBox4.DataSource = ds.Tables(0)
                ComboBox4.DisplayMember = "iname"
                ComboBox4.ValueMember = "Id"
                'ComboBox3.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From stock_master")
        DataGridView2.DataSource = ds.Tables(0)
    End Sub

    Dim dk As New DataSet







    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ComboBox1.Text <> "" Then
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select * from stock_master")
            ' ds = d.loaddataset("select * from Inward")
            ' TabControl1.SelectedIndex = 1
            loaddata()

            DataGridView2.DataSource = ds.Tables(0)
            dk = ds
        Else
            MessageBox.Show("Enter valid Supplier Name")
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If ComboBox2.Text <> "" Then
            If ComboBox1.Text <> "" Then
                If ComboBox4.Text <> "" Then
                    If ComboBox3.Text <> "" Then

                        Dim d As New Daoclass
                        Dim ds As New DataSet
                        ds = d.loaddataset("select * from stock_Master where tname='" & ComboBox2.Text & "' and  dname='" & ComboBox1.Text & "' and category='" & ComboBox3.Text & "' and iname='" & ComboBox4.Text & "'")
                        ' ds = d.loaddataset("select * from Inward")
                        ' TabControl1.SelectedIndex = 1
                        loaddata()

                        DataGridView2.DataSource = ds.Tables(0)
                        dk = ds
                    Else
                        MessageBox.Show("Enter valid Item Name")
                        ComboBox4.Focus()
                    End If
                Else
                    MessageBox.Show("Enter valid Category Name")
                    ComboBox1.Focus()
                End If
            Else
                MessageBox.Show("Enter valid Department Name")
                ComboBox3.Focus()
            End If
        Else
            MessageBox.Show("Enter valid Terminal Name")
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Try
            Dim d As New Stock_report

            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            CrystalReportViewer2.ReportSource = orpt
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

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            Dim ds As New DataSet
            Dim d As New Daoclass
            ds = d.loaddataset("select * from stock_Master")
            TabControl2.SelectedIndex = 1
            Dim d1 As New Stock_report
            d1.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d1.FileName)
            orpt.SetDataSource(ds.Tables(0))
            'orpt.PrintToPrinter()


            CrystalReportViewer2.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox4.KeyPress, ComboBox3.KeyPress, ComboBox2.KeyPress, ComboBox1.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = ComboBox2.Name Then
                ComboBox3.Focus()
            ElseIf sender.name = ComboBox3.Name Then
                ComboBox1.Focus()
            ElseIf sender.name = ComboBox1.Name Then
                ComboBox4.Focus()
            ElseIf sender.name = ComboBox4.Name Then
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
        If sender.name = ComboBox4.Name Then
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
        If sender.name = ComboBox3.Name Then
            Dim d As New Daoclass
            e.Handled = d.textvalidate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = ComboBox4.Name Then
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
    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class