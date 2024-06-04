Imports System.Data.SqlClient

Public Class Daoclass
    Private conn As New SqlConnection
    Private da As SqlDataAdapter
    Private ds As DataSet

    Public Sub New()
        conn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryDB.mdf;Integrated Security=True"
        'conn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project_Inventory\Project_Inventory\InventoryDB.mdf;Integrated Security=True"
    End Sub
    Public Function loaddataset(ByVal str As String) As DataSet
        ds = New DataSet
        da = New SqlDataAdapter(str, conn)
        conn.Open()
        da.SelectCommand.ExecuteReader()
        conn.Close()
        da.Fill(ds)
        Return ds
    End Function
    Public Function validate_date(ByVal qry As String) As Boolean
        Dim f As Boolean = False
        Dim obj As SqlDataReader
        Dim cmd As New SqlCommand(qry, conn)
        conn.Open()
        obj = cmd.ExecuteReader
        While obj.Read
            f = True
            Exit While
        End While
        conn.Close()
        Return f
    End Function
    Public Sub adddata(ByVal qry As String)
        Dim cmd As New SqlCommand(qry, conn)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
    Public Function numbervalidate(ByVal c As Char, ByVal hc As Integer) As Boolean
        If (c <> "" AndAlso IsNumeric(c) Or hc = 524296) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function textvalidate(ByVal c As Char, ByVal hc As Integer) As Boolean
        If ((LCase(c) >= "a" And LCase(c) <= "z") Or hc = 524296 Or hc = 2097184) Then
            Return False
        Else
            Return True
        End If
    End Function
    '4194368 == @
    '3014702 == .
    Public Function alphaNumericvalidate(ByVal c As Char, ByVal hc As Integer) As Boolean
        If (IsNumeric(c) Or (LCase(c) >= "a" And LCase(c) <= "z") Or hc = 524296 Or hc = 2097184 Or hc = 524296 Or hc = 2097184) Then
            Return False
        Else
            Return True
        End If
    End Function
    'Friend Sub update_stock(ByVal id As Integer, ByVal qty As Integer, ByVal f As Boolean)
    '    Try
    '        Dim oqty As Double = 0
    '        Dim nqty As Double = 0
    '        Dim ds As New DataSet
    '        ds = loaddataset("select qty from stock_master where p_id = " & id)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            oqty = Val(ds.Tables(0).Rows(0).Item(0))
    '        End If
    '        If f Then
    '            nqty = oqty + qty
    '        Else
    '            nqty = oqty - qty
    '        End If
    '        adddata("update stock_master set qty =" & nqty & "where p_id =" & id)
    '    Catch ex As Exception

    '    End Try
    'End Sub

End Class
