Imports System.Data.SqlClient

Public Class addEmp
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub LoadUsers()


        'Create a SqlConnection object and open the connection
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            'Create a SqlCommand object to retrieve all records from the Users table
            Dim query As String = "SELECT * FROM Users"
            Dim command As New SqlCommand(query, connection)

            'Create a SqlDataAdapter object and fill a DataTable with the query results
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            'Bind the DataTable to the DataGridView
            DataGridView1.DataSource = table
            '  DataGridView1.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        End Using
    End Sub
    Private Function GetLastUserID() As String
        Dim query As String = "SELECT MAX(user_id) FROM Users"
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
            Dim sql As String = "DELETE FROM Users WHERE user_id = @userId"
            Dim command As New SqlCommand(sql, connection)
            command.Parameters.AddWithValue("@userId", TextBoxID.Text)

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
            Dim query As String = "INSERT INTO Users (username, password, first_name, last_name, email, address, phone_number, job) VALUES (@username, @password, @first_name, @last_name, @email, @address, @phone_number, @job)"

            Dim cmd As New SqlCommand(query, connection)



            'cmd.Parameters.AddWithValue("@user_id", TextBoxID.Text)
            cmd.Parameters.AddWithValue("@username", TextBoxUserName.Text)
            cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text)
            cmd.Parameters.AddWithValue("@first_name", TextBoxFirstName.Text)
            cmd.Parameters.AddWithValue("@last_name", TextBoxLastName.Text)
            cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text)
            cmd.Parameters.AddWithValue("@address", TextBoxAddress.Text)
            cmd.Parameters.AddWithValue("@phone_number", TextBoxPhoneNumber.Text)
            cmd.Parameters.AddWithValue("@job", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@last_login", DateTime.Now)
            'Execute the insert command and get the number of rows affected
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("New user added successfully!")
            Else
                MessageBox.Show("Error adding new user.")
            End If

            'Close the connection
            connection.Close()
        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        End Try
    End Sub
    Private Sub addEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()

        AddButton.Checked = True
        TextBoxID.Enabled = False
        TextBoxID.Text = GetLastUserID() + 1

    End Sub
    Private Sub searchUser()
        Dim connection As New SqlConnection(connectionString)
        connection.Open()



        Dim query As String = "SELECT * FROM Users WHERE user_id = @UserId"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@UserId", TextBoxID.Text)

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
        ' DataGridView1.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        connection.Close()
    End Sub
    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = True
            End If
        Next
        ComboBox1.Enabled = True
        searchButton.Checked = False
        DeleteButton.Checked = False
        AddButton.Checked = True
        TextBoxID.Enabled = False
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
        If cont = 9 Then
            AddUsers()
            LoadUsers()
            TextBoxID.Text = ""
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Text = ""


                End If
            Next
            ComboBox1.Text = ""
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
            ComboBox1.Enabled = False

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
        ComboBox1.Enabled = False
        TextBoxID.Enabled = True
        Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من حذف المستخدم؟", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            deleteUsers()
            LoadUsers()
        Else
            ' Code to cancel the delete operation
        End If

    End Sub
End Class