Public Class addnew

    Private Sub txtLotPrize_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub txtDPayment_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub lblMonthly_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub addnew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If PictureBox1.Image Is Nothing Then
            PictureBox1.BackColor = Color.LightBlue
        Else
            PictureBox1.BackColor = Color.White


        End If
        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.LightBlue
        Else
            TextBox1.BackColor = SystemColors.Info
            TextBox1.ForeColor = Color.Black
        End If
        If TextBox2.Text = "" Then
            TextBox2.BackColor = Color.LightBlue
        Else
            TextBox2.BackColor = SystemColors.Info
            TextBox2.ForeColor = Color.Black
        End If
        If TextBox3.Text = "" Then
            TextBox3.BackColor = Color.LightBlue
        Else
            TextBox3.BackColor = SystemColors.Info
            TextBox3.ForeColor = Color.Black
        End If
        If TextBox4.Text = "" Then
            TextBox4.BackColor = Color.LightBlue
        Else
            TextBox4.BackColor = SystemColors.Info
            TextBox4.ForeColor = Color.Black
        End If
        If TextBox5.Text = "" Then
            TextBox5.BackColor = Color.LightBlue
        Else
            TextBox5.BackColor = SystemColors.Info
            TextBox5.ForeColor = Color.Black
        End If
        If TextBox5.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox5, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox5, "")
        End If
        If TextBox1.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox1, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox1, "")
        End If
        If TextBox2.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox2, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox2, "")
        End If
        If TextBox3.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox3, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox3, "")
        End If
        If TextBox4.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox4, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox4, "")
        End If
        If Not PictureBox1.Image Is Nothing And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then
            OpenDbCOnnection()
            Dim mstream As New System.IO.MemoryStream()
            PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim arrimag() As Byte = mstream.GetBuffer
            mstream.Close()
            dbcmd.CommandText = "Select * from tblemployee where id= '" & Label6.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                MessageBox.Show("employee has already in the list", "Adding Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dbdatareader.Close()
                dbcmd.Parameters.Clear()
                dbcmd.CommandText = "Insert into tblemployee (employeeno, firstname,lastname, middlename, department, photo) Values('" & TextBox5.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "', @photo)"
                dbcmd.Parameters.AddWithValue("@photo", arrimag)
                dbcmd.ExecuteNonQuery()

                MessageBox.Show("Successfully Saved ", "Adding Employee", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Employee.Search("select * from tblemployee")
            End If
        End If
        dbdatareader.Close()
        dbdatareader.Close()







    End Sub
    'Dim OpenFileDialog1 As New OpenFileDialog
    Dim UserPicpath As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        OpenFileDialog1.Filter = "JPEG FILES(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png| ALL Image Files (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            UserPicpath = OpenFileDialog1.FileName
            PictureBox1.Image = Image.FromFile(UserPicpath)
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        Me.close
    End Sub
End Class