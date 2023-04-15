Imports System.Data.SqlClient

Public Class Login
    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"

    Private Sub lastLogin(username As String, password As String)
        Dim connection As New SqlConnection(connectionString)
        connection.Open()

        Dim query As String = "UPDATE Users SET last_login = @last_login WHERE username = @username AND password = @password"

        Dim cmd As New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@last_login", DateTime.Now)
        cmd.Parameters.AddWithValue("@username", username)
        cmd.Parameters.AddWithValue("@password", password)

        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        If rowsAffected > 0 Then
            'MessageBox.Show("Last login time updated successfully!")
        Else
            '   MessageBox.Show("Error updating last login time.")
        End If

        connection.Close()
    End Sub


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sm As MaterialSkin.MaterialSkinManager
        sm = MaterialSkin.MaterialSkinManager.Instance
        sm.AddFormToManage(Me)
        sm.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT
        sm.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Cyan800, MaterialSkin.Primary.Cyan600, MaterialSkin.Primary.Cyan800, MaterialSkin.Accent.Cyan400, MaterialSkin.TextShade.WHITE)

    End Sub

    Private Sub MaterialLabel1_Click(sender As Object, e As EventArgs) Handles MaterialLabel1.Click

    End Sub

    Private Sub MaterialLabel2_Click(sender As Object, e As EventArgs) Handles MaterialLabel2.Click

    End Sub

    Private Sub userName_Click(sender As Object, e As EventArgs) Handles userName.Click

    End Sub

    Private Sub userPass_Click(sender As Object, e As EventArgs) Handles userPass.Click

    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click


        Dim username_ As String = userName.Text
        Dim password As String = userPass.Text
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"
        Dim conn As New SqlConnection(connectionString)
        conn.Open()

        'Check if the credentials are valid in the Admin_Login table
        Dim query As String = "SELECT COUNT(*) FROM users WHERE LOWER(Username) = LOWER(@Username) AND Password = @Password"
        Dim cmd As New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@Username", username_)
        cmd.Parameters.AddWithValue("@Password", password)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

        'If the credentials are valid, check if the user is an admin or a regular user
        If count > 0 Then


            'Check if the user is an admin or a regular user

            Dim query2 As String = "Select  Job FROM users WHERE LOWER(Username) = LOWER(@Username) AND Password = @Password"
            Dim cmd2 As New SqlCommand(query2, conn)
            cmd2.Parameters.AddWithValue("@Username", username_)
            cmd2.Parameters.AddWithValue("@Password", password)

            Dim result As Object = cmd2.ExecuteScalar()
            If result IsNot Nothing Then
                Dim job As String = result.ToString()
                'Console.WriteLine("Job: " & job)
                ' MessageBox.Show("Job: " & job)


                mainForm.ToolStripLabelName.Text = username_
                mainForm.ToolStripLabelPos.Text = job
                Dim testPos As String = job
                'MessageBox.Show(testPos + "    " + "Admin")
                lastLogin(username_, password)
                mainForm.lastLogin()
                If (String.Compare(testPos.Trim(), "Admin".Trim(), StringComparison.OrdinalIgnoreCase) = 0) Then

                    mainForm.ToolStripButton3.Enabled = True
                Else
                    mainForm.ToolStripButton3.Enabled = False
                End If
                ' MessageBox.Show(job)
            Else
                MessageBox.Show("No job found for username and password")
            End If


            'My.Forms.mainForm.Show()
            userName.Text = ""
            userPass.Text = ""
            Me.Close()

            'Open the appropriate form based on the user's role

        Else
            MsgBox("كلمة مرور او اسم المستخدم غير صحيح")
        End If


    End Sub



    Private Sub MaterialCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialCheckBox1.CheckedChanged
        If MaterialCheckBox1.Checked Then
            userPass.PasswordChar = ""
        Else
            userPass.PasswordChar = "*"
        End If
    End Sub



    Private Sub buttonEnd_Click(sender As Object, e As EventArgs) Handles buttonEnd.Click
        Dim result As DialogResult = MessageBox.Show("هل انت متأكد من الخروج من البرنامج؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            My.Forms.mainForm.Close()
        End If


    End Sub
End Class