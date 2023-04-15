Imports System.Data.SqlClient

Public Class mainForm

    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mcc\Desktop\my_projects\myVbProjects\POS\POS\POS.mdf;Integrated Security=True;Connect Timeout=30"

    Public myposition As String = "empty"
    Public myname As String = "empty"
    Public Sub lastLogin()
        Dim conn As New SqlConnection(connectionString)
        conn.Open()

        Dim query As String = "SELECT TOP 6 first_name, username, job, last_login FROM Users ORDER BY last_login DESC"
        Dim cmd As New SqlCommand(query, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)

        DataGridView1.DataSource = table
        DataGridView1.Columns(0).HeaderText = "الاسم"
        DataGridView1.Columns(1).HeaderText = "اسم المستخدم"
        DataGridView1.Columns(2).HeaderText = "المسمى الوظيفي"
        DataGridView1.Columns(3).HeaderText = "اخر تسجيل دخول"
        ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns("last_login").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        conn.Close()







    End Sub



    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dim sm As MaterialSkin.MaterialSkinManager
        'sm = MaterialSkin.MaterialSkinManager.Instance
        'sm.AddFormToManage(Me)
        ' sm.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK
        ' sm.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Orange100, MaterialSkin.Primary.Orange600, MaterialSkin.Primary.Orange100, MaterialSkin.Accent.Lime400, MaterialSkin.TextShade.WHITE)
        myposition = "empty"
        myname = "empty"
        dateLabel.Text = Date.Now.ToString("dddd") & " - " & Date.Now.ToString("MMM dd, yyyy")
        My.Forms.Login.ShowDialog()








    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timeLabel.Text = Format(Date.Now, "Long Time")        'frmLogin.ShowDialog()
        'MessageBox.Show("test+" + Login.myposition)


    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'My.Forms.custmoersForm.Show()
        customersForm.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        My.Forms.addEmp.ShowDialog()
    End Sub

    Private Sub ToolStripButtonRefresh_Click_1(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        Me.Refresh()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ToolStripButtonExit_Click_1(sender As Object, e As EventArgs) Handles ToolStripButtonExit.Click
        Login.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        addProduct.ShowDialog()
    End Sub

    Private Sub ButtonPOS_Click(sender As Object, e As EventArgs) Handles ButtonPOS.Click
        posForm.ShowDialog()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Transaction.ShowDialog()
    End Sub
End Class
