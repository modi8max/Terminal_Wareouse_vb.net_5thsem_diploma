Imports CrystalDecisions.CrystalReports.Engine

Public Class Reports
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub
    Dim dk As New DataSet
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If ComboBox1.Text <> "" Then
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select * from Inward where sname='" & ComboBox1.Text & "' and (bill_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "')")
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

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Try
            Dim d As New Inward_Invoice

            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            CrystalReportViewer1.ReportSource = orpt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        load_sup()

    End Sub
    Private Sub load_sup()
        Try
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select sname,Id from Supplier_master")
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.DisplayMember = "sname"
            ComboBox1.ValueMember = "Id"
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


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub



    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        loaddata()

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub





    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        If ComboBox1.Text <> "" Then
            Dim d As New Daoclass
            Dim ds As New DataSet
            ds = d.loaddataset("select * from Inward where sname='" & ComboBox1.Text & "' and (bill_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "')")
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

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Try
            Dim d As New Inward_Invoice

            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))

            orpt.SetParameterValue("p1", "Mr Modi")
            orpt.SetParameterValue("p2", "Adipur")
            orpt.SetParameterValue("p3", "13-09-2021")
            orpt.SetParameterValue("p4", "12")
            orpt.SetParameterValue("p5", "3-09-2021")
            orpt.SetParameterValue("p6", "11")
            orpt.SetParameterValue("p7", "10*200")
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
End Class