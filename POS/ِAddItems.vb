Imports System.Data.SqlClient


Public Class AddItems
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub LoadItems()


        'Create a SqlConnection object and open the connection
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            'Create a SqlCommand object to retrieve all records from the Users table
            Dim query As String = "SELECT * FROM Products"
            Dim command As New SqlCommand(query, connection)

            'Create a SqlDataAdapter object and fill a DataTable with the query results
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            'Bind the DataTable to the DataGridView
            DataGridView1.DataSource = table
            DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        End Using
    End Sub


    Private Sub LoadCart()


        'Create a SqlConnection object and open the connection
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim lastT As String = GetLastTransactionId()
            'Create a SqlCommand object to retrieve all records from the Users table
            Dim query As String = "SELECT * FROM Transaction_Items  where transaction_id=" + lastT
            Dim command As New SqlCommand(query, connection)

            'Create a SqlDataAdapter object and fill a DataTable with the query results
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            'Bind the DataTable to the DataGridView
            DataGridView2.DataSource = table
            'DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        End Using
    End Sub
    Private Function GetLastTransactionId() As Integer
        Dim sql As String = "SELECT MAX(transaction_id) FROM Transactions"
        Dim conn As New SqlConnection(connectionString)

        conn.Open()
        Dim cmd As New SqlCommand(sql, conn)
        Dim result As Object = cmd.ExecuteScalar()
        conn.Close()

        If IsDBNull(result) Then
            ' No transactions have been added yet, return 0 or throw an exception
            Return 0
        Else
            Return CInt(result)
        End If
    End Function
    Private Sub searchItems()
        Dim connection As New SqlConnection(connectionString)
        connection.Open()



        Dim query As String = "SELECT * FROM Products WHERE Product_id = @productId"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@productId", TextBox1.Text)

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
        DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        connection.Close()
    End Sub

    Private Sub newTransaction()
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Dim sql As String = "INSERT INTO Transactions ( transaction_date, payment_type) " &
                    "VALUES ( @transactionDate,  @paymentType)"

        Dim cmd As New SqlCommand(sql, connection)

        ' Replace these with the values you want to insert
        Dim transactionId As Integer = 1
        Dim transactionDate As DateTime = DateTime.Now
        ' Dim customerId As Integer = null
        Dim paymentType As String = "Chash"

        ' cmd.Parameters.AddWithValue("@transactionId", transactionId)
        cmd.Parameters.AddWithValue("@transactionDate", transactionDate)
        'cmd.Parameters.AddWithValue("@customerId", null)
        cmd.Parameters.AddWithValue("@paymentType", paymentType)

        cmd.ExecuteNonQuery()
        connection.Close()
    End Sub
    Private Sub AddItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newTransaction()
        Label5.Text = GetLastTransactionId().ToString
    End Sub
    Private Sub AddItems_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Execute your function here
        posForm.LoadCart()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try



            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Enabled = False


                End If
            Next


            TextBox1.Enabled = True


            If TextBox1.Text = "" Then
                LoadItems()
            Else
                searchItems()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub dataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row from the DataGridView
            Dim selectedRow = DataGridView1.SelectedRows(0)

            ' Extract the values of the columns you need
            Dim productId = selectedRow.Cells("product_id").Value
            Dim productName = selectedRow.Cells("product_name").Value
            Dim price = selectedRow.Cells("price").Value
            Dim selectedQuantity = CInt(selectedRow.Cells("quantity").Value)

            ' Insert the selected row into the Transaction_Items table
            Dim sql = "INSERT INTO Transaction_Items (transaction_id, product_id, quantity, item_price) " &
                  "VALUES ( @transactionId, @productId, @quantity, @itemPrice)"
            Dim cmd As New SqlCommand(sql, connection)
            'cmd.Parameters.AddWithValue("@transactionItemId", 1) ' Replace this with your own method to generate a new transaction item ID
            cmd.Parameters.AddWithValue("@transactionId", GetLastTransactionId()) ' Replace this with your own method to get the last transaction ID
            cmd.Parameters.AddWithValue("@productId", productId)
            cmd.Parameters.AddWithValue("@quantity", selectedQuantity)
            cmd.Parameters.AddWithValue("@itemPrice", price)
            cmd.ExecuteNonQuery()
            LoadCart()
        End If
        connection.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class