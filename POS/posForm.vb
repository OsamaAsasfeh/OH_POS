Imports System.Data.SqlClient

Public Class posForm
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"
    Dim lastT As String = GetLastTransactionId()
    Public Sub LoadCart()


        'Create a SqlConnection object and open the connection
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            lastT = GetLastTransactionId()


            ' Create a SqlCommand object to retrieve the sum of item_price for a specific transaction_id
            Dim query As String = "SELECT SUM(item_price) FROM Transaction_Items WHERE transaction_id = @transactionId"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@transactionId", lastT)

            ' Execute the query and get the result as a string
            Dim result As Object = command.ExecuteScalar()
            Dim totalPrice As String = If(IsDBNull(result), "0.00", String.Format("{0:0.00}", result))

            ' Create a new DataTable to hold the transaction items for the selected transaction_id
            query = "SELECT * FROM Transaction_Items WHERE transaction_id = @transactionId"
            command = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@transactionId", lastT)

            ' Create a SqlDataAdapter object and fill a DataTable with the query results
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            ' Bind the DataTable to the DataGridView
            DataGridView1.DataSource = table
            ' Set the width of the last column to fill the available space
            DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            ' Display the total price in a label or text box
            pricelabel.Text = "Total Price: $" & totalPrice

            connection.Close()
            Label4.Text = lastT
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
    Private Sub posForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCart()
        Label4.Text = lastT
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        AddItems.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadCart()
    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim result As DialogResult = MessageBox.Show("هل تريج حذف عنصر من سلة المشتريات؟", "حذف عنصر من سلة المشتريات", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim transactionItemId = selectedRow.Cells("transaction_item_id").Value

            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim sql = "DELETE FROM Transaction_Items WHERE transaction_item_id = @transactionItemId"
                Dim cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@transactionItemId", transactionItemId)
                cmd.ExecuteNonQuery()

                conn.Close()
                LoadCart()
            End Using

            MessageBox.Show("تم حذف العنصر بنجاح", "حذف عنصر", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class