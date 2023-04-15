Imports System.Data.SqlClient

Public Class TransactionItem
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"
    Public rowId As Integer = 1
    Private Sub LoadUsers()


        'Create a SqlConnection object and open the connection
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            'Create a SqlCommand object to retrieve all records from the Users table
            Dim query As String = "SELECT * FROM Transaction_Items"
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



        Dim query As String = "SELECT * FROM Transaction_Items WHERE Transaction_id = @TransactionId"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@TransactionId", rowId)

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        connection.Close()
    End Sub





    Private Sub searchButton_Click(sender As Object, e As EventArgs)
        Try



            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Enabled = False


                End If
            Next


            '  TextBoxID.Enabled = True


            '  If TextBoxID.Text = "" Then
            '  LoadUsers()
            '   Else
            'searchUser()

            '  End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TransactionItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        searchUser()
        Label4.Text = rowId
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class