<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminalMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartMentMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoryMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemmasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuppliermasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseInwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminalInwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SupplierInwardReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterToolStripMenuItem, Me.InwardToolStripMenuItem, Me.OutwardToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1283, 42)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterToolStripMenuItem
        '
        Me.MasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TerminalMasterToolStripMenuItem, Me.DepartMentMasterToolStripMenuItem, Me.CategoryMasterToolStripMenuItem, Me.ItemmasterToolStripMenuItem, Me.SuppliermasterToolStripMenuItem})
        Me.MasterToolStripMenuItem.Image = Global.Project_Inventory.My.Resources.Resources.icons8_home_501
        Me.MasterToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 4, 4)
        Me.MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        Me.MasterToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.MasterToolStripMenuItem.Size = New System.Drawing.Size(85, 34)
        Me.MasterToolStripMenuItem.Text = "Master"
        '
        'TerminalMasterToolStripMenuItem
        '
        Me.TerminalMasterToolStripMenuItem.Name = "TerminalMasterToolStripMenuItem"
        Me.TerminalMasterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TerminalMasterToolStripMenuItem.Text = "Terminal_Master"
        '
        'DepartMentMasterToolStripMenuItem
        '
        Me.DepartMentMasterToolStripMenuItem.Name = "DepartMentMasterToolStripMenuItem"
        Me.DepartMentMasterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DepartMentMasterToolStripMenuItem.Text = "DepartMent_Master"
        '
        'CategoryMasterToolStripMenuItem
        '
        Me.CategoryMasterToolStripMenuItem.Name = "CategoryMasterToolStripMenuItem"
        Me.CategoryMasterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.CategoryMasterToolStripMenuItem.Text = "Category_Master"
        '
        'ItemmasterToolStripMenuItem
        '
        Me.ItemmasterToolStripMenuItem.Name = "ItemmasterToolStripMenuItem"
        Me.ItemmasterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ItemmasterToolStripMenuItem.Text = "Item_master"
        '
        'SuppliermasterToolStripMenuItem
        '
        Me.SuppliermasterToolStripMenuItem.Name = "SuppliermasterToolStripMenuItem"
        Me.SuppliermasterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SuppliermasterToolStripMenuItem.Text = "Supplier_master"
        '
        'InwardToolStripMenuItem
        '
        Me.InwardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseInwardToolStripMenuItem, Me.TerminalInwardToolStripMenuItem})
        Me.InwardToolStripMenuItem.Image = Global.Project_Inventory.My.Resources.Resources.inward1
        Me.InwardToolStripMenuItem.Name = "InwardToolStripMenuItem"
        Me.InwardToolStripMenuItem.Size = New System.Drawing.Size(85, 38)
        Me.InwardToolStripMenuItem.Text = "Inward"
        '
        'PurchaseInwardToolStripMenuItem
        '
        Me.PurchaseInwardToolStripMenuItem.Name = "PurchaseInwardToolStripMenuItem"
        Me.PurchaseInwardToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PurchaseInwardToolStripMenuItem.Text = "Purchase_Inward"
        '
        'TerminalInwardToolStripMenuItem
        '
        Me.TerminalInwardToolStripMenuItem.Name = "TerminalInwardToolStripMenuItem"
        Me.TerminalInwardToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.TerminalInwardToolStripMenuItem.Text = "Terminal_Inward"
        '
        'OutwardToolStripMenuItem
        '
        Me.OutwardToolStripMenuItem.Image = Global.Project_Inventory.My.Resources.Resources.issue1
        Me.OutwardToolStripMenuItem.Name = "OutwardToolStripMenuItem"
        Me.OutwardToolStripMenuItem.Size = New System.Drawing.Size(94, 38)
        Me.OutwardToolStripMenuItem.Text = "Outward"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem1.Image = Global.Project_Inventory.My.Resources.Resources.icons8_home_501
        Me.ToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(0, 0, 4, 4)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(77, 34)
        Me.ToolStripMenuItem1.Text = "Close"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockReportToolStripMenuItem, Me.SupplierInwardReportToolStripMenuItem})
        Me.ToolStripMenuItem2.Image = Global.Project_Inventory.My.Resources.Resources.reports1
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(89, 38)
        Me.ToolStripMenuItem2.Text = "Reports"
        '
        'StockReportToolStripMenuItem
        '
        Me.StockReportToolStripMenuItem.Name = "StockReportToolStripMenuItem"
        Me.StockReportToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.StockReportToolStripMenuItem.Text = "Stock Report"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 42)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(126, 640)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.BackColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.Project_Inventory.My.Resources.Resources.icons8_storage_tank_30
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton1.Text = "Terminal"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DoubleClickEnabled = True
        Me.ToolStripButton2.Image = Global.Project_Inventory.My.Resources.Resources.icons8_department_50
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton2.Text = "Department"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.Project_Inventory.My.Resources.Resources.icons8_category_30
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton3.Text = "Category"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.BackColor = System.Drawing.Color.White
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton4.Image = Global.Project_Inventory.My.Resources.Resources.icons8_new_product_48
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton4.Text = "Item"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.Project_Inventory.My.Resources.Resources.icons8_supplier_50
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton5.Text = "Supplier"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.Project_Inventory.My.Resources.Resources.user1
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton6.Text = "Admin"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = Global.Project_Inventory.My.Resources.Resources.icons8_enter_32
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton7.Text = "Add User"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Image = Global.Project_Inventory.My.Resources.Resources.icons8_exit_32
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(123, 34)
        Me.ToolStripButton8.Text = "Log Out"
        '
        'Timer1
        '
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(631, 330)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 22)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "0"
        Me.Label12.Visible = False
        '
        'SupplierInwardReportToolStripMenuItem
        '
        Me.SupplierInwardReportToolStripMenuItem.Name = "SupplierInwardReportToolStripMenuItem"
        Me.SupplierInwardReportToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SupplierInwardReportToolStripMenuItem.Text = "Supplier Inward Report"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Project_Inventory.My.Resources.Resources.bg_in1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1283, 682)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripButton8 As ToolStripButton
    Friend WithEvents MasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TerminalMasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartMentMasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoryMasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemmasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuppliermasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InwardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutwardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents PurchaseInwardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TerminalInwardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label12 As Label
    Friend WithEvents SupplierInwardReportToolStripMenuItem As ToolStripMenuItem
End Class
