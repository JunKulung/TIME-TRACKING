Public Class Admin
    Public Sub Search(Query As String)
        OpenDbCOnnection()
        dbcmd.CommandText = Query
        dbdatareader = dbcmd.ExecuteReader
        ListView1.Items.Clear()
        If dbdatareader.HasRows = True Then

            While dbdatareader.Read


                ListView1.Items.Add(dbdatareader.Item("id"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("name"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("username"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("password"))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dbdatareader.Item("access"))





            End While

        End If
        dbdatareader.Close()
        dbdatareader.Close()
    End Sub
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripButton1.Enabled = False
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton5.Enabled = False
        ListView1.Clear()
        With ListView1
            .Columns.Add("id", 0)
            .Columns.Add(" Name", 240)
            .Columns.Add("Username", 240)
            .Columns.Add("Password", 0)
            .Columns.Add("Access Level", 240)



        End With
        Search("Select * from tbluser")
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.LightBlue
        Else
            TextBox1.BackColor = SystemColors.Info
            TextBox1.ForeColor = Color.Black
        End If
        If TextBox5.Text = "" Then
            TextBox5.BackColor = Color.LightBlue
        Else
            TextBox5.BackColor = SystemColors.Info
            TextBox5.ForeColor = Color.Black
        End If
        If TextBox3.Text = "" Then
            TextBox3.BackColor = Color.LightBlue
        Else
            TextBox3.BackColor = SystemColors.Info
            TextBox3.ForeColor = Color.Black
        End If
        If ComboBox1.Text = "" Then
            ComboBox1.BackColor = Color.LightBlue
        Else
            ComboBox1.BackColor = SystemColors.Info
            ComboBox1.ForeColor = Color.Black
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
        If TextBox3.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox3, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox3, "")
        End If
        If TextBox5.Text = "" Then
            Me.ErrorProvider1.SetError(Me.TextBox5, "All fields are require")
            Return
        Else
            Me.ErrorProvider1.SetError(Me.TextBox5, "")
        End If
       
        If TextBox1.Text <> "" And TextBox3.Text <> "" And TextBox5.Text <> "" And ComboBox1.Text <> "" Then




            OpenDbCOnnection()
            Dim mstream As New System.IO.MemoryStream()

            Dim arrimag() As Byte = mstream.GetBuffer
            mstream.Close()
            dbcmd.CommandText = "Select * from tbluser where id= '" & TextBox2.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                MessageBox.Show("Employee number has already in the list", "Adding Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dbdatareader.Close()
                dbcmd.Parameters.Clear()
                dbcmd.CommandText = "Insert into tblemployee (id, username,password, status, name) Values('" & TextBox5.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox3.Text & "','" & ComboBox1.SelectedItem.text & "')"

                dbcmd.ExecuteNonQuery()

                MessageBox.Show("Successfully Saved ", "Adding Employee", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Employee.Search("select * from tbluser")
            End If
        End If
        dbdatareader.Close()
        dbdatareader.Close()

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        TextBox1.Clear()
        TextBox5.Clear()
        TextBox3.Clear()
        ComboBox1.Text = Nothing
        GroupBox1.Enabled = False
        ToolStripButton4.Enabled = True
        ToolStripButton2.Enabled = False
        ToolStripButton1.Enabled = False
        ListView1.Enabled = True
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        GroupBox1.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton1.Enabled = True
        ToolStripButton4.Enabled = False
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 0 Then
            ToolStripButton3.Enabled = True
            GroupBox1.Enabled = True
            ToolStripButton1.Enabled = True

        End If
        Dim index As Integer = ListView1.FocusedItem.Index

        TextBox2.Text = ListView1.Items(index).SubItems(0).Text

        TextBox5.Text = ListView1.Items(index).SubItems(1).Text
        TextBox1.Text = ListView1.Items(index).SubItems(2).Text
        TextBox3.Text = ListView1.Items(index).SubItems(3).Text
        ComboBox1.SelectedItem = ListView1.Items(index).SubItems(4).Text




    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        OpenDbCOnnection()
        dbcmd.CommandText = "Update tbluser set name='" & TextBox5.Text & "', username='" & TextBox1.Text & "', password='" & TextBox3.Text & "', access='" & ComboBox1.SelectedItem & "' where id = '" & TextBox2.Text & "'"
        dbcmd.ExecuteNonQuery()
        MessageBox.Show("Information Successfully Updated.", "Updating User", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Search("select * from tbluser")
        TextBox1.Clear()
        TextBox5.Clear()
        TextBox3.Clear()
        ToolStripButton1.Enabled = False
   

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class