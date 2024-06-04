Public Class Combobox12
    Private Sub Combobox12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Dim d As New Daoclass
            'Dim ds As New Data.DataSet
            'ds = d.loaddataset("select Id,uname,Password,terminal,departmen from Login_master")

            'DataGridView1.DataSource = ds.Tables(0)
            loaddata()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub loaddata()
        Dim d As New Daoclass
        Dim ds As New DataSet
        ds = d.loaddataset("Select * From Login_master")
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Form1
        d.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton6_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class