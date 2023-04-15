<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    ' Inherits System.Windows.Forms.Form
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.loginButton = New MaterialSkin.Controls.MaterialFlatButton()
        Me.userName = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.userPass = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MaterialCheckBox1 = New MaterialSkin.Controls.MaterialCheckBox()
        Me.buttonEnd = New MaterialSkin.Controls.MaterialFlatButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'loginButton
        '
        Me.loginButton.AutoSize = True
        Me.loginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.loginButton.Depth = 0
        Me.loginButton.Location = New System.Drawing.Point(512, 376)
        Me.loginButton.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.loginButton.MouseState = MaterialSkin.MouseState.HOVER
        Me.loginButton.Name = "loginButton"
        Me.loginButton.Primary = False
        Me.loginButton.Size = New System.Drawing.Size(98, 36)
        Me.loginButton.TabIndex = 0
        Me.loginButton.Text = "تسجيل الدخول"
        Me.loginButton.UseVisualStyleBackColor = True
        '
        'userName
        '
        Me.userName.Depth = 0
        Me.userName.Hint = ""
        Me.userName.Location = New System.Drawing.Point(331, 288)
        Me.userName.MouseState = MaterialSkin.MouseState.HOVER
        Me.userName.Name = "userName"
        Me.userName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.userName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.userName.SelectedText = ""
        Me.userName.SelectionLength = 0
        Me.userName.SelectionStart = 0
        Me.userName.Size = New System.Drawing.Size(289, 28)
        Me.userName.TabIndex = 1
        Me.userName.UseSystemPasswordChar = False
        '
        'userPass
        '
        Me.userPass.Depth = 0
        Me.userPass.Hint = ""
        Me.userPass.Location = New System.Drawing.Point(331, 342)
        Me.userPass.MouseState = MaterialSkin.MouseState.HOVER
        Me.userPass.Name = "userPass"
        Me.userPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.userPass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.userPass.SelectedText = ""
        Me.userPass.SelectionLength = 0
        Me.userPass.SelectionStart = 0
        Me.userPass.Size = New System.Drawing.Size(289, 28)
        Me.userPass.TabIndex = 2
        Me.userPass.UseSystemPasswordChar = False
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(646, 288)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MaterialLabel1.Size = New System.Drawing.Size(92, 24)
        Me.MaterialLabel1.TabIndex = 3
        Me.MaterialLabel1.Text = "اسم المستخدم:"
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel2.Location = New System.Drawing.Point(646, 342)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MaterialLabel2.Size = New System.Drawing.Size(72, 24)
        Me.MaterialLabel2.TabIndex = 4
        Me.MaterialLabel2.Text = "كلمة السر:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(369, 96)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(203, 186)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'MaterialCheckBox1
        '
        Me.MaterialCheckBox1.AutoSize = True
        Me.MaterialCheckBox1.Depth = 0
        Me.MaterialCheckBox1.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.MaterialCheckBox1.Location = New System.Drawing.Point(646, 382)
        Me.MaterialCheckBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.MaterialCheckBox1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.MaterialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCheckBox1.Name = "MaterialCheckBox1"
        Me.MaterialCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MaterialCheckBox1.Ripple = True
        Me.MaterialCheckBox1.Size = New System.Drawing.Size(128, 30)
        Me.MaterialCheckBox1.TabIndex = 8
        Me.MaterialCheckBox1.Text = "اظهار كلمة السر"
        Me.MaterialCheckBox1.UseVisualStyleBackColor = True
        '
        'buttonEnd
        '
        Me.buttonEnd.AutoSize = True
        Me.buttonEnd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.buttonEnd.Depth = 0
        Me.buttonEnd.Location = New System.Drawing.Point(378, 376)
        Me.buttonEnd.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.buttonEnd.MouseState = MaterialSkin.MouseState.HOVER
        Me.buttonEnd.Name = "buttonEnd"
        Me.buttonEnd.Primary = False
        Me.buttonEnd.Size = New System.Drawing.Size(40, 36)
        Me.buttonEnd.TabIndex = 9
        Me.buttonEnd.Text = "الغاء"
        Me.buttonEnd.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.buttonEnd)
        Me.Controls.Add(Me.MaterialCheckBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MaterialLabel2)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.userPass)
        Me.Controls.Add(Me.userName)
        Me.Controls.Add(Me.loginButton)
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RightToLeftLayout = True
        Me.Sizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تسجيل الدخول"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents loginButton As MaterialSkin.Controls.MaterialFlatButton
    Friend WithEvents userName As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents userPass As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MaterialCheckBox1 As MaterialSkin.Controls.MaterialCheckBox
    Friend WithEvents buttonEnd As MaterialSkin.Controls.MaterialFlatButton
End Class
