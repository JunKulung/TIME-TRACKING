Imports System.Windows.Forms

Public Class MDIParent1

   

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Employee.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        DTR.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Me.Close()

        LoginAdmin.TextBox1.Clear()
        LoginAdmin.TextBox2.Clear()
        LoginAdmin.TextBox1.Focus()
        UserInterface.TextBox1.SelectAll()
        UserInterface.Label15.Visible = False
    End Sub


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Board.ShowDialog()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Admin.ShowDialog()
    End Sub


End Class
