Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        OpenDbCOnnection()
        dbcmd.CommandText = "Update tblemployee set employeeno='" & TextBox5.Text & "', firstname='" & TextBox1.Text & "', lastname='" & TextBox2.Text & "', middlename='" & TextBox3.Text & "', department='" & TextBox4.Text & "' where id='" & TextBox6.Text & "'"
        dbcmd.ExecuteNonQuery()
        MessageBox.Show("Employee Information Successfully Updated.", "Updating Employee", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Employee.Search("select * from tblemployee")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

        TextBox5.Clear()


        Me.Close()






    End Sub
End Class