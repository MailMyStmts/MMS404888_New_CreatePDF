Imports System.Data.SqlClient


Public Class MainSQLClass
    'Written by Wayne Musteen 12/4/2013
    Private MServerConnection As String
    Private MSQLQryString As String
    Private sqlcon As SqlConnection
    Private sqlcmd As New SqlCommand
    Private sqladapter As New SqlClient.SqlDataAdapter
    Private TmpMYDS As New DataSet
    Private TmpMYDT As New DataTable

    Private Sub OpenConn()
        sqlcon = New SqlConnection
        sqlcon.ConnectionString = "Server=ECLIPSESQL;Database=Statement;UID=PFHPrinter;PWD=1beech"
        sqlcon.Open()

    End Sub

    Friend Sub CloseConn()
        sqlcon.Close()
    End Sub
    Friend Sub SQLCommandTimeout(Optional ByVal TimeOutTime As Integer = 0)
        sqlcmd.CommandTimeout = TimeOutTime
    End Sub
    Friend Property ServerConnection() As String
        Get
            Return MServerConnection
        End Get
        Set(ByVal value As String)
            MServerConnection = value
        End Set
    End Property

    Friend Property SQLQryString() As String
        Get
            Return MSQLQryString
        End Get
        Set(ByVal value As String)
            MSQLQryString = value
        End Set
    End Property
    Friend Function TestConnect() As Boolean
        Try
            Call OpenConn()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Friend Function PopulateDataSet() As DataSet

        Call OpenConn()
        Call SetupSQLCommand()

        sqladapter.SelectCommand = sqlcmd
        sqladapter.Fill(TmpMYDS, "MyTable")

        Call CloseConn()

        Return TmpMYDS
    End Function
    Friend Function PopulateDataTable() As DataTable

        Call OpenConn()
        Call SetupSQLCommand()

        sqladapter.SelectCommand = sqlcmd
        sqladapter.Fill(TmpMYDT)

        Call CloseConn()

        Return TmpMYDT
    End Function

    Friend Function ReadData() As SqlDataReader
        Dim Myreader As SqlDataReader


        Call OpenConn()
        Call SetupSQLCommand()

        Myreader = sqlcmd.ExecuteReader()

        'Call ClossConn()

        Return Myreader

    End Function

    Private Sub SetupSQLCommand()
        sqlcmd.Connection = sqlcon
        sqlcmd.CommandText = MSQLQryString
    End Sub
    Friend Sub ExecuteQry()
        Call OpenConn()
        Call SetupSQLCommand()

        sqlcmd.ExecuteNonQuery()

        Call CloseConn()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
