Imports System.Data.SqlClient

Public Class addProduct
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub LoadUsers()


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
    Private Function GetLastUserID() As String
        Dim query As String = "SELECT MAX(Product_id) FROM Products"
        Dim lastID As String = ""

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            connection.Open()
            Dim result As Object = command.ExecuteScalar()
            If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                lastID = result.ToString()
            End If
            connection.Close()
        End Using

        Return lastID
    End Function
    Private Sub deleteUsers()
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Open the database connection
            connection.Open()

            ' Create the SQL command with parameters
            Dim sql As String = "DELETE FROM Products WHERE product_id = @ProductId"
            Dim command As New SqlCommand(sql, connection)
            command.Parameters.AddWithValue("@ProductId", TextBoxID.Text)

            ' Execute the SQL command
            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            ' Check if any rows were deleted
            If rowsAffected > 0 Then
                MessageBox.Show("item deleted")
            Else

            End If
        Catch ex As Exception
            ' Handle any errors that occur
            MessageBox.Show("Error deleting user: " & ex.Message)

        Finally
            ' Close the database connection
            connection.Close()
        End Try
    End Sub

    Private Sub AddUsers()
        Try


            Dim connection As New SqlConnection(connectionString)
            connection.Open()

            'Create a SqlCommand object with parameterized values for the new user
            Dim query As String = "INSERT INTO Products (product_id, product_name, price, description, category,quantity) VALUES (@productId, @productName, @price, @description, @category, @quantity)"

            Dim cmd As New SqlCommand(query, connection)
            ' (@productId, @productName, @price, @description, @category, @quantity)"



            cmd.Parameters.AddWithValue("@productId", TextBoxID.Text)
            cmd.Parameters.AddWithValue("@productName", TextBoxUserName.Text)
            cmd.Parameters.AddWithValue("@price", TextBoxPassword.Text)
            cmd.Parameters.AddWithValue("@description", TextBoxFirstName.Text)
            cmd.Parameters.AddWithValue("@category", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@quantity", TextBoxEmail.Text)


            'Execute the insert command and get the number of rows affected
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("New item added successfully!")
            Else
                MessageBox.Show("Error adding new user.")
            End If

            'Close the connection
            connection.Close()
        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        End Try
    End Sub
    Private Sub addProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()

        AddButton.Checked = True

        TextBoxID.Text = GetLastUserID() + 1

    End Sub
    Private Sub searchUser()
        Dim connection As New SqlConnection(connectionString)
        connection.Open()



        Dim query As String = "SELECT * FROM Products WHERE Product_id = @productId"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@productId", TextBoxID.Text)

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
        DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        connection.Close()
    End Sub
    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = True
            End If
        Next

        searchButton.Checked = False
        DeleteButton.Checked = False
        AddButton.Checked = True

        TextBoxID.Text = GetLastUserID() + 1
        Dim cont As Int64 = 0
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If String.IsNullOrEmpty(CType(ctrl, TextBox).Text) Then

                Else
                    cont += 1

                End If
            End If
        Next
        If ComboBox1.Text IsNot "" Then
            cont += 1
        End If
        If cont = 6 Then
            AddUsers()
            LoadUsers()
            TextBoxID.Text = ""
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Text = ""


                End If
            Next

        Else
            MessageBox.Show("تأكد من ملء جميع الحقول، يرجى المحاولة مرة أخرى ")
        End If


    End Sub

    Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click
        Try


            searchButton.Checked = True
            DeleteButton.Checked = False
            AddButton.Checked = False
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



    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click

        searchButton.Checked = False
        DeleteButton.Checked = True
        AddButton.Checked = False
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = False
            End If
        Next

        TextBoxID.Enabled = True
        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من حذف المستخدم؟", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            deleteUsers()
            LoadUsers()
        Else
            ' Code to cancel the delete operation
        End If

    End Sub

    Private Sub TextBoxLastName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class