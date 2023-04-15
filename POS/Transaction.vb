Imports System.Data.SqlClient

Public Class Transaction
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub LoadUsers()


        'Create a SqlConnection object and open the connection
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            'Create a SqlCommand object to retrieve all records from the Users table
            Dim query As String = "SELECT * FROM Transactions"
            Dim command As New SqlCommand(query, connection)

            'Create a SqlDataAdapter object and fill a DataTable with the query results
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            'Bind the DataTable to the DataGridView
            DataGridView1.DataSource = table
            '  DataGridView1.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Using
    End Sub




    Private Sub searchUser()
        Dim connection As New SqlConnection(connectionString)
        connection.Open()



        Dim query As String = "SELECT * FROM Transactions WHERE Transaction_id = @TransactionId"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@TransactionId", TextBoxID.Text)

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        connection.Close()
    End Sub





    Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click
        Try


            searchButton.Checked = True

            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Enabled = False


                End If
            Next


            TextBoxID.Enabled = True


            If TextBoxID.Text = "" Then
                LoadUsers()
            Else
                searchUser()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then ' Make sure the clicked cell is in a row (and not the header)
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim rowId = CInt(selectedRow.Cells("transaction_id").Value)
            TransactionItem.rowId = rowId

            TransactionItem.Show()

        End If
    End Sub
End Class