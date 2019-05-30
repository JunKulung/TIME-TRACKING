Imports MySql.Data.MySqlClient
Module CONNECT
    Public sqL As String
    Public dbConn As New MySqlConnection
    Public dbcmd As New MySqlCommand
    Public dbdatareader As MySqlDataReader
    Private dbHost, dbName, dbUser, dbPass, dbPort As String

    Public Sub OpenDbCOnnection()
        dbHost = "localhost"
        dbName = "a2bdb"
        dbUser = "root"
        dbPass = vbNullString
        dbPort = "3306"

        Try
            If dbConn.State = ConnectionState.Closed Then
                dbConn.ConnectionString = "Data Source='" & dbHost & "'; Database='" & dbName & "'; User='" & dbUser & "'; Password='" & dbPass & "'; Port='" & dbPort & "';"
                dbConn.Open()
                dbcmd.Connection = dbConn

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




End Module
