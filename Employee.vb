Imports MySql.Data.MySqlClient
Public Class Employee
    Public Sub Search(Query As String)
        OpenDbCOnnection()
        dbcmd.CommandText = Query
        dbdatareader = dbcmd.ExecuteReader
        ListView1.Items.Clear()
        If dbdatareader.HasRows = True Then

            While dbdatareader.Read


                ListView1.Items.Add(dbdatareader.Item("id"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("employeeno"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("firstname"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("lastname"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("middlename"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("department"))



            End While

        End If
        dbdatareader.Close()
        dbdatareader.Close()

    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        addnew.ShowDialog()
    End Sub

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbdatareader.Close()
        ListView1.Clear()
        With ListView1
            .Columns.Add("id", 0)
            .Columns.Add("Employee no", 200)
            .Columns.Add("First Name", 250)
            .Columns.Add("Last Name", 240)
            .Columns.Add("Middle Name", 200)
            .Columns.Add("Department", 240)

        End With
        Search("Select * from tblemployee")
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If TextBox1.Text = "" Then

            Search("Select * from tblemployee")
        Else

            Search("Select * from tblemployee where " & ComboBox1.Text & " LIKE '" & TextBox1.Text & "%'")

        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then

            Search("Select * from tblemployee")


        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim index As Integer = ListView1.FocusedItem.Index
        TextBox2.Text = ListView1.Items(index).SubItems(0).Text
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click


        Dim index As Integer = ListView1.FocusedItem.Index

        Form1.TextBox6.Text = ListView1.Items(index).SubItems(0).Text
        Form1.TextBox5.Text = ListView1.Items(index).SubItems(1).Text
        Form1.TextBox1.Text = ListView1.Items(index).SubItems(2).Text
        Form1.TextBox2.Text = ListView1.Items(index).SubItems(3).Text
        Form1.TextBox3.Text = ListView1.Items(index).SubItems(4).Text
        Form1.TextBox4.Text = ListView1.Items(index).SubItems(5).Text
        Dim adapter As New MySqlDataAdapter
        adapter.SelectCommand = dbcmd
        Dim data As DataTable
        Dim commandbuild As MySqlCommandBuilder
        data = New DataTable
        adapter = New MySqlDataAdapter("Select photo from tblemployee where id = '" & ListView1.FocusedItem.Text & "'", dbConn)
        commandbuild = New MySqlCommandBuilder(adapter)
        adapter.Fill(data)
        Dim lb() As Byte = data.Rows(0).Item("photo")
        Dim lstr As New System.IO.MemoryStream(lb)
        Form1.PictureBox1.Image = Image.FromStream(lstr)
        Form1.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        lstr.Close()



        Form1.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Select employee to delete.", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If MessageBox.Show("Arey ou sure you want to delete this?", "A2BOutsourcing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                OpenDbCOnnection()
                dbcmd.CommandText = "Delete from tblemployee where id='" & ListView1.FocusedItem.Text & "'"
                dbcmd.ExecuteNonQuery()
                Search("Select * from tblemployee")
                MessageBox.Show("Successfully deleted", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class