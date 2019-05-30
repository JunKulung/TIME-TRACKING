Public Class Board


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
    Private Sub Board_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbdatareader.Close()

        ListView1.Clear()

        With ListView1
            .Columns.Add("attendanced", 0)
            .Columns.Add("Employee no", 250)
            .Columns.Add("Full Name", 300)
            .Columns.Add("Date", 0)
            .Columns.Add("Time in", 250)
            .Columns.Add("Time out", 0)
            .Columns.Add("Status", 0)

        End With

        Search("select  * from tblattendance inner join tblemployee on tblattendance.employeeno=tblemployee.employeeno where status='" & "Attendance" & "' and date='" & Now.ToString("M/dd/yyy") & "' ")
        Label2.Text = (ListView1.Items.Count)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)



    End Sub
End Class