﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System
Imports System.Web.UI.WebControls

Public Class clsDBOperation
    Public conStr As String
    Public con As SqlConnection
    Public objAdptr As SqlDataAdapter

    Public Sub openDB(ByVal dbConnectionString As String)
        Try
            If (dbConnectionString = "") Then
                ' It will select the Default connection as  "loyaltyMainServer"
                conStr = ConfigurationManager.ConnectionStrings("loyaltyMainServer").ConnectionString
                con = New SqlConnection(conStr)
            Else
                'Some times the application need to connect to the Local server 
                'The local server connection string is generated by the function 'clsUtilities.CreateConnString()'
                conStr = dbConnectionString
                con = New SqlConnection(conStr)
            End If


            If con.State = System.Data.ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub closeDB()
        con.Close()
    End Sub
    Public Function executeNonqry(ByVal cmd As SqlCommand, ByVal dbConnectionString As String) As String
        Try
            openDB(dbConnectionString)
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            closeDB()
            Return Nothing
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
    Public Function executeNonqry(ByVal queryString As String, ByVal dbConnectionStr_EMPTYforLoyaltyMainServer_objBllConnLocalSvr_forLocalServer As String) As String
        Try
            openDB(dbConnectionStr_EMPTYforLoyaltyMainServer_objBllConnLocalSvr_forLocalServer)
            Dim cmd As New SqlCommand(queryString)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            closeDB()
            Return Nothing
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function executeQry(ByVal cmd As SqlCommand, ByVal dbConnectionString As String) As DataSet
        Dim ds As New DataSet()
        Try
            openDB(dbConnectionString)
            cmd.Connection = con
            cmd.CommandTimeout = 500
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            closeDB()
        Catch ex As Exception

        End Try
        Return ds
    End Function

    Public Function executeQry(ByVal queryString As String, ByVal dbConnectionStr_EMPTYforLoyaltyMainServer_objBllConnLocalSvr_forLocalServer As String) As DataSet
        Dim DS As New DataSet()
        Try
            openDB(dbConnectionStr_EMPTYforLoyaltyMainServer_objBllConnLocalSvr_forLocalServer)
            objAdptr = New SqlDataAdapter(queryString, con)
            objAdptr.Fill(DS)
            closeDB()
        Catch ex As Exception

        End Try

        Return DS
    End Function

    Public Function executeScalar(ByVal cmd As SqlCommand, ByVal dbConnectionString As String) As Object
        Try
            openDB(dbConnectionString)
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            Dim obj = cmd.ExecuteScalar()
            Return obj
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
    Public Sub comboFill(ByVal ddl As DropDownList, ByVal cmd As SqlCommand, ByVal dbConnectionString As String)
        openDB(dbConnectionString)
        ddl.Items.Clear()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        Dim objReader As SqlDataReader = cmd.ExecuteReader()
        While objReader.Read()
            ddl.Items.Add(New ListItem(objReader.GetValue(1).ToString().Trim(), objReader.GetValue(0).ToString().Trim()))
        End While

        ddl.Items.Insert(0, New ListItem("--Select One--", "0"))
        objReader.Close()
        closeDB()
    End Sub
    ' ComboFill -Default item as 'All' instead of 'Select One'
    Public Sub comboFill(ByVal ddl As DropDownList, ByVal cmd As SqlCommand, ByVal dbConnectionString As String, ByVal defaultItem As String)
        openDB(dbConnectionString)
        ddl.Items.Clear()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        Dim objReader As SqlDataReader = cmd.ExecuteReader()
        While objReader.Read()
            ddl.Items.Add(New ListItem(objReader.GetValue(1).ToString().Trim(), objReader.GetValue(0).ToString().Trim()))
        End While

        ddl.Items.Insert(0, New ListItem("--" + defaultItem + "--", "0"))
        objReader.Close()
        closeDB()
    End Sub

    Public Sub gridFill(ByVal objGridView As GridView, ByVal objCmd As SqlCommand, ByVal dbConnectionString As String)
        Try
            Dim ds As New Data.DataSet
            openDB(dbConnectionString)
            objCmd.Connection = con
            objCmd.CommandType = CommandType.StoredProcedure
            Dim objAdapter As New SqlDataAdapter(objCmd)
            ds.Clear()
            objAdapter.Fill(ds, "TableName")
            objGridView.DataSource = ds
            objGridView.DataBind()
            closeDB()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub openDBReports(ByVal dbConnectionString As String)
        conStr = ConfigurationManager.ConnectionStrings(dbConnectionString).ConnectionString
        con = New SqlConnection(conStr)
        If con.State = System.Data.ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
    End Sub
End Class
