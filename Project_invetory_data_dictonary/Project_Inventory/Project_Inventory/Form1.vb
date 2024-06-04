Public Class Form1
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        TerminalMasterToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub TerminalMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalMasterToolStripMenuItem.Click
        Dim d As New Terminal_Master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        DepartMentMasterToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DepartMentMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartMentMasterToolStripMenuItem.Click
        Dim d As New Depatment_Master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

        Dim d As New Login_master
        ' d.MdiParent = Me
        Me.Hide()
        Timer1.Start()
        SplashScreen1.Show()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim d As New Add_User
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim d As New Category_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim d As New Item_Master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim d As New Supplier_master
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.WindowState = FormWindowState.Maximized
        Timer1.Stop()
    End Sub

    Private Sub CategoryMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryMasterToolStripMenuItem.Click
        ToolStripButton3_Click(sender, e)
    End Sub

    Private Sub ItemmasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemmasterToolStripMenuItem.Click
        ToolStripButton4_Click(sender, e)
    End Sub
    Private Sub SuppliermasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliermasterToolStripMenuItem.Click
        ToolStripButton5_Click(sender, e)
    End Sub

    'Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
    '    End
    'End Sub

    Private Sub ToolStripButton1_MouseHover(sender As Object, e As EventArgs) Handles ToolStripButton1.MouseHover, ToolStripButton2.MouseHover, ToolStripButton3.MouseHover, ToolStripButton4.MouseHover, ToolStripButton5.MouseHover, ToolStripButton6.MouseHover, ToolStripButton7.MouseHover, ToolStripButton8.MouseHover

        Dim f As Boolean = 0
        '   e.Handled = f
        If f Then
            sender.backcolor = Color.White
            sender.forecolor = Color.Black

        Else
            sender.backcolor = Color.Black
            sender.ForeColor = Color.White
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim d As New Combobox12
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub InwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InwardToolStripMenuItem.Click

    End Sub

    Private Sub OutwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutwardToolStripMenuItem.Click
        Dim d As New OutWard
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

    End Sub



    Private Sub PurchaseInwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseInwardToolStripMenuItem.Click
        Dim d As New Form3
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub TerminalInwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalInwardToolStripMenuItem.Click
        Dim d As New Terminal_Inward
        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub



    Private Sub InwardToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim d As New Terminal_Inward

        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub StockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockReportToolStripMenuItem.Click
        Dim d As New Stock_rpt

        d.MdiParent = Me
        d.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label12.Text = Val(Label12.Text) + 1
        ' Label3.Text += 10
        If (Label12.Text = 10) Then
            Timer1.Stop()
            'Login_form.Show()
            SplashScreen1.Hide()
            Login_master.Show()
        End If
    End Sub

    Private Sub SupplierInwardReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierInwardReportToolStripMenuItem.Click
        Dim d As New Reports


        d.MdiParent = Me
        d.Show()
    End Sub

    'Private Sub ToolStripButton1_MouseMove(sender As Object, e As MouseEventArgs) Handles ToolStripButton1.MouseMove
    '    sender.backcolor = Color.White
    '    sender.ForeColor = Color.Black
    'End Sub
End Class
