Imports MySql.Data.MySqlClient
Public Class frmprintattendance
    Private Sub LoadLots()
        Dim y As Integer
        Dim s As Integer
        Dim a As Integer
        Try
            sqL = "select * from tblattendance inner join tblemployee on tblattendance.employeeno=tblemployee.employeeno where tblemployee.lastname LIKE '" & DTR.TextBox1.Text & "%' and  tblattendance.date >='" & DTR.dtStart.Text.Trim & "' and tblattendance.date <='" & DTR.dtEnd.Text.Trim & "';"
            OpenDbCOnnection()
            dbcmd = New MySqlCommand(sqL, dbConn)
            dbdatareader = dbcmd.ExecuteReader()
            dgw.Rows.Clear()
            y = 0
            Do While dbdatareader.Read = True
                dgw.Rows.Add(dbdatareader(1), dbdatareader(9) & ", " & dbdatareader(8) & " " & dbdatareader(10), dbdatareader(2), dbdatareader(3), dbdatareader(4), dbdatareader(5))
                y += 19
                s += 19
                a += 19
            Loop
            dgw.Height = dgw.Height + y
            Me.Height = Me.Height + s
            Panel1.Height = Panel1.Height + a

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            dbcmd.Dispose()
            dbConn.Close()
        End Try
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.Panel1.Width, Me.Panel1.Height)

        Panel1.DrawToBitmap(bm, New Rectangle(0, 0, Me.Panel1.Width, Me.Panel1.Height))

        e.Graphics.DrawImage(bm, 50, 60)
        Dim aPS As New PageSetupDialog
        aPS.Document = PrintDocument1

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        PrintDialog1.Document = Me.PrintDocument1

        Dim ButtonPressed As DialogResult = PrintDialog1.ShowDialog()
        If (ButtonPressed = DialogResult.OK) Then
            PrintDocument1.Print()

            Me.Close()



        End If
    End Sub
    Private Sub frmprintattendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLots()
    End Sub

    Private Sub LineShape1_Click(sender As Object, e As EventArgs) Handles LineShape1.Click

    End Sub
End Class