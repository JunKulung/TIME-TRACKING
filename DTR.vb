Public Class DTR
    Public Sub Search(Query As String)
        OpenDbCOnnection()
        dbcmd.CommandText = Query
        dbdatareader = dbcmd.ExecuteReader
        ListView1.Items.Clear()
        If dbdatareader.HasRows = True Then

            While dbdatareader.Read


                ListView1.Items.Add(dbdatareader.Item("attendanced"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("employeeno"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("firstname") & ", " & dbdatareader.Item("lastname") & " " & dbdatareader.Item("middlename"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("date"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("timein"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("timeout"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("status"))
            End While

        End If
        dbdatareader.Close()
        dbdatareader.Close()

    End Sub
    Private Sub DTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Clear()

        With ListView1
            .Columns.Add("attendanced", 0)
            .Columns.Add("Employee no", 191)
            .Columns.Add("Full Name", 191)
            .Columns.Add("Date", 191)
            .Columns.Add("Time in", 191)
            .Columns.Add("Time out", 191)
            .Columns.Add("Status", 191)

        End With
        Search("select * from tblattendance inner join tblemployee on tblattendance.employeeno=tblemployee.employeeno")
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        'Dim index As Integer = ListView1.FocusedItem.Index
        'Dim a As Integer
        'a = ListView1.Items(index).SubItems(4).Text.IndexOf(":")
        'TextBox2.Text = ListView1.Items(index).SubItems(4).Text.Remove(0, a + 1)
        'a = ListView1.Items(index).SubItems(5).Text.IndexOf(":")
        'TextBox3.Text = ListView1.Items(index).SubItems(5).Text.Remove(0, a + 1)
        'Dim answer As Integer
        'answer = Val(TextBox3.Text) - Val(TextBox2.Text)
        'MsgBox(answer)


    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        'Dim a As Integer
        'Dim s As Integer
        'If ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text.Contains("AM") Then
        '    a = 12 - Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text)

        '    s = a + Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text)
        '    MsgBox(s)

        'Else
        '    s = Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text) - Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text)










        'End If





    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged
        Search("select * from tblattendance inner join tblemployee on tblattendance.employeeno=tblemployee.employeeno where tblemployee.lastname LIKE '" & TextBox1.Text & "%' and  tblattendance.date >='" & dtStart.Text.Trim & "' and tblattendance.date <='" & dtEnd.Text.Trim & "';")

    End Sub

    Private Sub dtEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtEnd.ValueChanged
        Search("select * from tblattendance inner join tblemployee on tblattendance.employeeno=tblemployee.employeeno where tblemployee.lastname LIKE '" & TextBox1.Text & "%' and  tblattendance.date >='" & dtStart.Text.Trim & "' and tblattendance.date <='" & dtEnd.Text.Trim & "';")

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Search("select * from tblattendance inner join tblemployee on tblattendance.employeeno=tblemployee.employeeno where tblemployee.lastname LIKE '" & TextBox1.Text & "%' and  tblattendance.date >='" & dtStart.Text.Trim & "' and tblattendance.date <='" & dtEnd.Text.Trim & "';")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        frmprintattendance.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class