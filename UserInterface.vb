Imports MySql.Data.MySqlClient
Public Class UserInterface



    Dim LL, II, PP As Integer
    Dim TXT As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        TextBox1.Focus()
        Label3.Text = Now.ToLongDateString
        dbdatareader.Close()

        TXT = "A2B OUTSOURCING"
        LL = Len(TXT)
        II = 1
        PP = 1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Clear()
            TextBox1.Focus()
        Else
            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox1.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()
               
                TextBox1.SelectAll()
                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox1.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Attendance" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = True Then
                    dbdatareader.Read()
                    MessageBox.Show("You are already in", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox1.SelectAll()
                    TextBox1.Focus()
                    PictureBox1.Image = Nothing
                    Label6.Visible = False
                    Label5.Visible = False

                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Insert into tblattendance(employeeno, date, timein, status)values('" & TextBox1.Text & "','" & Now.ToString("M/dd/yyy") & "','" & Label4.Text & "','" & "Attendance" & "')"
                    dbcmd.ExecuteNonQuery()
                    MessageBox.Show("Successfully in!", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox1.Clear()
                    TextBox1.Focus()
                    PictureBox1.Image = Nothing

                End If
                dbdatareader.Close()
                dbdatareader.Close()
            ElseIf dbdatareader.HasRows = False Then
                Label6.ResetText()
                Label5.ResetText()
                MessageBox.Show("Employee number not found", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.SelectAll()
                TextBox1.Focus()

            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
     

        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Clear()
            TextBox1.Focus()
        Else

            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox1.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()


                TextBox1.SelectAll()
                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox1.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Attendance" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = False Then

                    dbdatareader.Read()
                    MessageBox.Show("Please clocked in first", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox1.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Attendance" & "'"
                    dbdatareader = dbcmd.ExecuteReader
                    If dbdatareader.HasRows = True Then
                        dbdatareader.Read()
                        If dbdatareader.Item("timeout") <> "" Then
                            MessageBox.Show("You are already out", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TextBox1.SelectAll()
                            TextBox1.Focus()
                            PictureBox1.Image = Nothing
                            Label6.Visible = False
                            Label5.Visible = False
                        ElseIf dbdatareader.Item("timeout") = "" Then

                            dbdatareader.Close()
                            dbcmd.CommandText = "Update tblattendance set timeout='" & Label4.Text & "' where employeeno='" & TextBox1.Text & "' and date='" & Now.ToString("M/dd/yyy") & "'"
                            dbcmd.ExecuteNonQuery()
                            MessageBox.Show("Succesfully out", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)


                            'Dim a As Integer
                            'Dim s As Integer
                            'dbcmd.CommandText = "Update tblattendance set total='" & Label4.Text & "' where employeeno='" & TextBox1.Text & "' and date='" & Now.ToString("M/dd/yyy") & "'"
                            'dbcmd.ExecuteNonQuery()

                            'If ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text.Contains("AM") Then
                            '    a = 12 - Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text)

                            '    s = a + Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text)
                            '    MsgBox(s)

                            'Else
                            '    s = Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text) - Val(ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text)



                            TextBox1.Clear()
                            TextBox1.Focus()


                            'End If
                        End If

                    End If
                    dbdatareader.Close()
                    dbdatareader.Close()
                End If
            ElseIf dbdatareader.HasRows = False Then
                Label5.ResetText()
                Label6.ResetText()
                MessageBox.Show("Employee number not found!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.SelectAll()

                TextBox1.Focus()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox2.Clear()
            TextBox2.Focus()
        Else
            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox2.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()
                    dbdatareader.Close()
                    dbcmd.CommandText = "Insert into tblattendance(employeeno, date, timeout, status)values('" & TextBox2.Text & "','" & Now.ToString("M/dd/yyy") & "','" & Label4.Text & "','" & "Break" & "')"
                    dbcmd.ExecuteNonQuery()
                    MessageBox.Show("Successfully on break", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox2.Clear()
                    TextBox2.Focus()
                dbdatareader.Close()
                dbdatareader.Close()
            ElseIf dbdatareader.HasRows = False Then
                Label7.ResetText()
                Label8.ResetText()
                MessageBox.Show("Employee number not found", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PictureBox2.Image = Nothing
                TextBox2.Focus()
                TextBox2.SelectAll()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox2.Clear()
            TextBox2.Focus()
        Else

            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox2.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()
                TextBox2.SelectAll()
                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox2.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Break" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = False Then
                    dbdatareader.Read()
                    MessageBox.Show("You need to leave on break first", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Select * from tblattendance where status='" & "Break" & "' order by attendanced desc"
                    dbdatareader = dbcmd.ExecuteReader
                    If dbdatareader.HasRows = True Then
                        dbdatareader.Read()
                        Dim s As Integer = dbdatareader.Item("attendanced")
                        dbdatareader.Close()
                        dbcmd.CommandText = "Update tblattendance set timein='" & Label4.Text & "' where employeeno='" & TextBox2.Text & "' and attendanced='" & s & "' and status='" & "Break" & "'"
                        dbcmd.ExecuteNonQuery()
                        MessageBox.Show("Succesfully returned from break", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)





                        TextBox2.Clear()
                        TextBox2.Focus()
                    End If
                    dbdatareader.Close()
                End If
                    dbdatareader.Close()
                    dbdatareader.Close()

            ElseIf dbdatareader.HasRows = False Then
            Label7.ResetText()
            Label8.ResetText()
            MessageBox.Show("Employee number not found", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox2.Focus()
            TextBox2.SelectAll()
        End If
        dbdatareader.Close()
        dbdatareader.Close()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        If TextBox3.Text = "" Then
            MessageBox.Show("Please enter your employee number!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox3.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()
                Label12.Text = dbdatareader.Item("name")
                Label13.Text = dbdatareader.Item("department")
                Label11.Text = dbdatareader.Item("employeeno")
                TextBox3.SelectAll()
                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Lunch Break" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = True Then
                    dbdatareader.Read()
                    MessageBox.Show(Label12.Text & " Was already leave on break!", "Lunch Break", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox3.SelectAll()
                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Insert into tblattendance(employeeno, date, timein, status)values('" & TextBox3.Text & "','" & Now.ToString("M/dd/yyy") & "','" & Label4.Text & "','" & "Lunch Break" & "')"
                    dbcmd.ExecuteNonQuery()
                    MessageBox.Show("Successfully Leaved on break!", "Break", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
                dbdatareader.Close()
                dbdatareader.Close()
            ElseIf dbdatareader.HasRows = False Then
                Label12.ResetText()
                Label13.ResetText()
                MessageBox.Show("Employee number not found!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If TextBox3.Text = "" Then
            MessageBox.Show("Please enter your employee number!", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox3.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()
                Label12.Text = dbdatareader.Item("name")
                Label13.Text = dbdatareader.Item("department")
                Label11.Text = dbdatareader.Item("employeeno")
                TextBox3.SelectAll()

                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Lunch Break" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = False Then

                    dbdatareader.Read()
                    MessageBox.Show("Please Leave on break first!", "Lunch Break", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Lunch Break" & "'"
                    dbdatareader = dbcmd.ExecuteReader
                    If dbdatareader.HasRows = True Then
                        dbdatareader.Read()
                        If dbdatareader.Item("timeout") <> "" Then
                            MessageBox.Show(Label12.Text & " Had already returned from break", "Lunch Break", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ElseIf dbdatareader.Item("timeout") = "" Then

                            dbdatareader.Close()
                            dbcmd.CommandText = "Update tblattendance set timeout='" & Label4.Text & "' where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "'"
                            dbcmd.ExecuteNonQuery()
                            MessageBox.Show(Label12.Text & " Succesfully returned from break!", "Lunch Break", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If
                    dbdatareader.Close()
                    dbdatareader.Close()
                End If
            ElseIf dbdatareader.HasRows = False Then
                Label12.ResetText()
                Label13.ResetText()
                MessageBox.Show("Employee number not found!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.SelectAll()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
      

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click




        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            LoginAdmin.ShowDialog()
            LoginAdmin.Focus()
          
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
       
       






        If TextBox1.Text = "2018" Then
            Label15.Visible = True
        Else
            Label15.Visible = False


        End If




        If TextBox1.Text = "" Then
            PictureBox1.Image = Nothing
            Label6.ResetText()
            Label5.ResetText()
            Button1.Enabled = True
            Button2.Enabled = True
        End If

        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox1.Text & "'and date='" & Now.ToString("M/dd/yyy") & "' "
        dbdatareader = dbcmd.ExecuteReader



        If dbdatareader.HasRows = False Then
            dbdatareader.Read()
            Button1.Enabled = True
            Button2.Enabled = True
         
        Else
            dbdatareader.Read()
            If dbdatareader("timein") <> "" Then

                Button1.Enabled = False

            End If
        End If



        dbdatareader.Close()


        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox1.Text & "'"
        dbdatareader = dbcmd.ExecuteReader
        If dbdatareader.HasRows = True Then
            dbdatareader.Read()
            Label6.Visible = True
            Label5.Visible = True

            Label6.Text = dbdatareader.Item("firstname") & ", " & dbdatareader.Item("lastname") & " " & dbdatareader.Item("middlename") & "."
            Label5.Text = dbdatareader.Item("department")




            dbdatareader.Close()

            Dim adapter As New MySqlDataAdapter
            adapter.SelectCommand = dbcmd
            Dim data As DataTable
            Dim commandbuild As MySqlCommandBuilder
            data = New DataTable

            adapter = New MySqlDataAdapter("select photo from tblemployee where employeeno = '" & TextBox1.Text & "'", dbConn)
            commandbuild = New MySqlCommandBuilder(adapter)
            adapter.Fill(data)

            Dim lba() As Byte = data.Rows(0).Item("photo")
            Dim lstra As New System.IO.MemoryStream(lba)

            PictureBox1.Image = Image.FromStream(lstra)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Visible = True
            lstra.Close()


        Else
            Label6.Visible = False
            Label5.Visible = False
            PictureBox1.Image = Nothing
            Button1.Enabled = True
        End If
        dbdatareader.Close()
        dbdatareader.Close()
        dbdatareader.Close()

        If TextBox1.Text = "" Then
            Exit Sub
        ElseIf IsNumeric(TextBox1.Text) = False Then
            MsgBox("Please enter number data only.", MsgBoxStyle.Exclamation, "Validation")
            TextBox1.Clear()

        End If


    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text = "" Then
            Exit Sub
        ElseIf IsNumeric(TextBox2.Text) = False Then
            MsgBox("Please enter number data only.", MsgBoxStyle.Exclamation, "Validation")
            TextBox2.Clear()
            Exit Sub
        End If




        If TextBox2.Text = "" Then
            PictureBox2.Image = Nothing
            Label6.ResetText()
            Label5.ResetText()

        End If
        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox2.Text & "'"
        dbdatareader = dbcmd.ExecuteReader
        If dbdatareader.HasRows = True Then
            dbdatareader.Read()
            Label7.Visible = True
            Label8.Visible = True
            Label7.Text = dbdatareader.Item("firstname") & ", " & dbdatareader.Item("lastname") & " " & dbdatareader.Item("middlename") & "."
            Label8.Text = dbdatareader.Item("department")


            dbdatareader.Close()

            Dim adapter As New MySqlDataAdapter
            adapter.SelectCommand = dbcmd
            Dim data As DataTable
            Dim commandbuild As MySqlCommandBuilder
            data = New DataTable

            adapter = New MySqlDataAdapter("select photo from tblemployee where employeeno = '" & TextBox2.Text & "'", dbConn)
            commandbuild = New MySqlCommandBuilder(adapter)
            adapter.Fill(data)

            Dim lba() As Byte = data.Rows(0).Item("photo")
            Dim lstra As New System.IO.MemoryStream(lba)

            PictureBox2.Image = Image.FromStream(lstra)
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox2.Visible = True
            lstra.Close()



        Else
            Label7.Visible = False
            Label8.Visible = False

            PictureBox2.Image = Nothing
        End If

        dbdatareader.Close()
        dbdatareader.Close()
        dbdatareader.Close()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

        TextBox4.Focus()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

        TextBox3.Focus()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

        TextBox2.Focus()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click


        If TextBox3.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox3.Clear()
            TextBox3.Focus()
        Else
            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox3.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()

                TextBox2.SelectAll()
                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Lunch" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = True Then
                    dbdatareader.Read()
                    MessageBox.Show("You are already on lunchbreak", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox3.SelectAll()
                    TextBox3.Focus()
                    PictureBox3.Image = Nothing
                    Label9.Visible = False
                    Label20.Visible = False
                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Insert into tblattendance(employeeno, date, timeout, status)values('" & TextBox3.Text & "','" & Now.ToString("M/dd/yyy") & "','" & Label4.Text & "','" & "Lunch" & "')"
                    dbcmd.ExecuteNonQuery()
                    MessageBox.Show("Successfully on break", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox3.Clear()
                    TextBox3.Focus()

                End If
                dbdatareader.Close()
                dbdatareader.Close()
            ElseIf dbdatareader.HasRows = False Then
                Label9.ResetText()
                Label20.ResetText()
                MessageBox.Show("Employee number not found", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PictureBox3.Image = Nothing

                TextBox3.Focus()
                TextBox3.SelectAll()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If TextBox3.Text = "" Then
            Exit Sub
        ElseIf IsNumeric(TextBox3.Text) = False Then
            MsgBox("Please enter number data only.", MsgBoxStyle.Exclamation, "Validation")
            TextBox3.Clear()
            Exit Sub
        End If






        If TextBox3.Text = "" Then
            PictureBox3.Image = Nothing
            Label9.ResetText()
            Label20.ResetText()
        End If


        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox2.Text & "'and date='" & Now.ToString("M/dd/yyy") & "' "
        dbdatareader = dbcmd.ExecuteReader



        If dbdatareader.HasRows = False Then
            dbdatareader.Read()
            Button6.Enabled = True
            Button5.Enabled = True
        Else
            dbdatareader.Read()
            If dbdatareader("timein") <> "" Then

                Button6.Enabled = False

            End If
        End If






        dbdatareader.Close()







        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox3.Text & "'"
        dbdatareader = dbcmd.ExecuteReader
        If dbdatareader.HasRows = True Then
            dbdatareader.Read()
            Label9.Visible = True
            Label20.Visible = True
            Label9.Text = dbdatareader.Item("firstname") & ", " & dbdatareader.Item("lastname") & " " & dbdatareader.Item("middlename") & "."
            Label20.Text = dbdatareader.Item("department")


            dbdatareader.Close()

            Dim adapter As New MySqlDataAdapter
            adapter.SelectCommand = dbcmd
            Dim data As DataTable
            Dim commandbuild As MySqlCommandBuilder
            data = New DataTable

            adapter = New MySqlDataAdapter("select photo from tblemployee where employeeno = '" & TextBox3.Text & "'", dbConn)
            commandbuild = New MySqlCommandBuilder(adapter)
            adapter.Fill(data)

            Dim lba() As Byte = data.Rows(0).Item("photo")
            Dim lstra As New System.IO.MemoryStream(lba)

            PictureBox3.Image = Image.FromStream(lstra)
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox3.Visible = True
            lstra.Close()



        Else
            Label9.Visible = False
            Label20.Visible = False

            PictureBox3.Image = Nothing
        End If

        dbdatareader.Close()
        dbdatareader.Close()
        dbdatareader.Close()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox3.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox3.Clear()
            TextBox3.Focus()
        Else

            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox3.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()


                TextBox3.SelectAll()

                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Lunch" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = False Then

                    dbdatareader.Read()
                    MessageBox.Show("You need to out before in", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Lunch" & "'"
                    dbdatareader = dbcmd.ExecuteReader
                    If dbdatareader.HasRows = True Then
                        dbdatareader.Read()
                        If dbdatareader.Item("timein") <> "" Then
                            MessageBox.Show("You are already in", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TextBox3.SelectAll()
                            TextBox3.Focus()
                            PictureBox3.Image = Nothing
                            Label9.Visible = False
                            Label20.Visible = False
                        ElseIf dbdatareader.Item("timein") = "" Then

                            dbdatareader.Close()
                            dbcmd.CommandText = "Update tblattendance set timein='" & Label4.Text & "' where employeeno='" & TextBox3.Text & "' and date='" & Now.ToString("M/dd/yyy") & "'"
                            dbcmd.ExecuteNonQuery()
                            MessageBox.Show("Succesfully in", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TextBox3.Clear()
                            TextBox3.Focus()
                        End If

                    End If
                    dbdatareader.Close()
                    dbdatareader.Close()
                End If
            ElseIf dbdatareader.HasRows = False Then
                Label9.ResetText()
                Label20.ResetText()
                MessageBox.Show("Employee number not found", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox3.Focus()
                TextBox3.SelectAll()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text = "" Then
            Exit Sub
        ElseIf IsNumeric(TextBox4.Text) = False Then
            MsgBox("Please enter number data only.", MsgBoxStyle.Exclamation, "Validation")
            TextBox4.Clear()
            Exit Sub
        End If







        If TextBox4.Text = "" Then
            PictureBox4.Image = Nothing
            Label12.ResetText()
            Label13.ResetText()

        End If
        OpenDbCOnnection()
        dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox4.Text & "'"
        dbdatareader = dbcmd.ExecuteReader
        If dbdatareader.HasRows = True Then
            dbdatareader.Read()
            Label12.Visible = True
            Label13.Visible = True
            Label12.Text = dbdatareader.Item("firstname") & ", " & dbdatareader.Item("lastname") & " " & dbdatareader.Item("middlename") & "."
            Label13.Text = dbdatareader.Item("department")


            dbdatareader.Close()

            Dim adapter As New MySqlDataAdapter
            adapter.SelectCommand = dbcmd
            Dim data As DataTable
            Dim commandbuild As MySqlCommandBuilder
            data = New DataTable

            adapter = New MySqlDataAdapter("select photo from tblemployee where employeeno = '" & TextBox4.Text & "'", dbConn)
            commandbuild = New MySqlCommandBuilder(adapter)
            adapter.Fill(data)

            Dim lba() As Byte = data.Rows(0).Item("photo")
            Dim lstra As New System.IO.MemoryStream(lba)

            PictureBox4.Image = Image.FromStream(lstra)
            PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox4.Visible = True
            lstra.Close()



        Else
            Label12.Visible = False
            Label13.Visible = False

            PictureBox4.Image = Nothing
        End If

        dbdatareader.Close()
        dbdatareader.Close()
        dbdatareader.Close()
    End Sub


    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox4.Clear()
            TextBox4.Focus()
        Else
            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox4.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()

                TextBox4.SelectAll()
                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox4.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Restroom" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = True Then
                    dbdatareader.Read()
                    MessageBox.Show("You are already on restroom break", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox4.SelectAll()
                    TextBox4.Focus()
                    PictureBox3.Image = Nothing
                    Label12.Visible = False
                    Label13.Visible = False
                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Insert into tblattendance(employeeno, date, timeout, status)values('" & TextBox4.Text & "','" & Now.ToString("M/dd/yyy") & "','" & Label4.Text & "','" & "Restroom" & "')"
                    dbcmd.ExecuteNonQuery()
                    MessageBox.Show("Successfully on restroom break", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextBox4.Clear()
                    TextBox4.Focus()

                End If
                dbdatareader.Close()
                dbdatareader.Close()
            ElseIf dbdatareader.HasRows = False Then
                Label12.ResetText()
                Label13.ResetText()
                MessageBox.Show("Employee number not found", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PictureBox3.Image = Nothing

                TextBox4.Focus()
                TextBox4.SelectAll()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If

    End Sub
    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("Please enter your employee number", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox4.Clear()
            TextBox4.Focus()
        Else

            OpenDbCOnnection()
            dbcmd.CommandText = "Select * from tblemployee where employeeno='" & TextBox4.Text & "'"
            dbdatareader = dbcmd.ExecuteReader
            If dbdatareader.HasRows = True Then
                dbdatareader.Read()


                TextBox4.SelectAll()

                dbdatareader.Close()
                dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox4.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Restroom" & "'"
                dbdatareader = dbcmd.ExecuteReader
                If dbdatareader.HasRows = False Then

                    dbdatareader.Read()
                    MessageBox.Show("You need to out before in", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    dbdatareader.Close()
                    dbcmd.CommandText = "Select * from tblattendance where employeeno='" & TextBox4.Text & "' and date='" & Now.ToString("M/dd/yyy") & "' and status='" & "Restroom" & "'"
                    dbdatareader = dbcmd.ExecuteReader
                    If dbdatareader.HasRows = True Then
                        dbdatareader.Read()
                        If dbdatareader.Item("timeout") <> "" Then
                            MessageBox.Show("You are already out", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TextBox4.SelectAll()
                            TextBox4.Focus()
                            PictureBox3.Image = Nothing
                            Label12.Visible = False
                            Label13.Visible = False
                        ElseIf dbdatareader.Item("timeout") = "" Then

                            dbdatareader.Close()
                            dbcmd.CommandText = "Update tblattendance set timein='" & Label4.Text & "' where employeeno='" & TextBox4.Text & "' and date='" & Now.ToString("M/dd/yyy") & "'"
                            dbcmd.ExecuteNonQuery()
                            MessageBox.Show("Succesfully in", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TextBox4.Clear()
                            TextBox4.Focus()
                        End If

                    End If
                    dbdatareader.Close()
                    dbdatareader.Close()
                End If
            ElseIf dbdatareader.HasRows = False Then
                Label12.ResetText()
                Label13.ResetText()
                MessageBox.Show("Employee number not found", "A2BOutsourcing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox4.Focus()
                TextBox4.SelectAll()
            End If
            dbdatareader.Close()
            dbdatareader.Close()
        End If
    End Sub

  
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label19.Text = Label19.Text + Mid(TXT, II, 1)

        If II > LL Then
            II = 0
            Label19.Text = ""
        End If

        II = II + 1
    End Sub

    Private Sub Label15_Click_1(sender As Object, e As EventArgs) Handles Label15.Click
        LoginAdmin.Show()



    End Sub

    Private Sub TabPage1_Leave(sender As Object, e As EventArgs) Handles TabPage1.Leave

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class