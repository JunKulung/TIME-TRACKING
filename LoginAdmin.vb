Public Class LoginAdmin

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Label4.Text = "INCORRECT USERNAME OR PASSWORD!"

            Label4.Visible = True
        ElseIf TextBox2.Text = "" Then
            Label4.Text = "INCORRECT USERNAME OR PASSWORD!"

            Label4.Visible = True

        End If
        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tbluser where username='" & TextBox1.Text & "'and password ='" & TextBox2.Text & "'"
        dbdatareader = dbcmd.ExecuteReader
        If dbdatareader.HasRows = True Then
            dbdatareader.Read()


            If dbdatareader("access") = "user" Then
                Me.Hide()
                UserInterface.ShowDialog()

            ElseIf dbdatareader("access") = "admin" Then
                Me.Hide()
                MDIParent1.ShowDialog()

            End If
        Else
            Label4.Text = "INCORRECT USERNAME OR PASSWORD!"

            Label4.Visible = True


        End If
        dbdatareader.Close()
        dbdatareader.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()

        End
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
      
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub LoginAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Focus()
    End Sub
End Class