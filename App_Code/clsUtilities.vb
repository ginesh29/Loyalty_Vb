Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class clsUtilities
    Private Shared _MenuTabSelected As Integer
    Public Shared Property MenuTabSelected As Integer
        Get
            Return _MenuTabSelected
        End Get
        Set(ByVal value As Integer)
            _MenuTabSelected = value
        End Set
    End Property


    Public Shared Sub CreateConfirmBox(ByVal btn As System.Web.UI.WebControls.Button, ByVal strMessage As String)
        btn.Attributes.Add("onclick", "return confirm('" + strMessage + "');")
    End Sub

    Public Shared Sub CreateConfirmBoxLinkButton(ByVal btn As System.Web.UI.WebControls.LinkButton, ByVal strMessage As String)
        btn.Attributes.Add("onclick", "return confirm('" + strMessage + "');")
    End Sub

    Public Shared Function showMessage(ByVal saved_updated_deleted_selectRow_emptyGrid As String) As String
        Return ConfigurationManager.AppSettings(saved_updated_deleted_selectRow_emptyGrid).ToString()
    End Function
    Public Shared Function CreateConnString(ByVal CoCd As String) As String
        Dim objDB = New clsDBOperation()
        Dim cmd As New SqlCommand("Ly_Company_Getrow")
        cmd.Parameters.Add("@CoCd", SqlDbType.VarChar).Value = CoCd
        Dim dt = objDB.executeQry(cmd, "").Tables(0)

        Return "data source=" + dt.Rows(0).ItemArray(0).ToString() + ";Initial catalog=" + dt.Rows(0).ItemArray(1).ToString() + ";user id=" + dt.Rows(0).ItemArray(2).ToString() + "; password=" + dt.Rows(0).ItemArray(3).ToString()
        'data source=(local);Initial catalog=Loyalty;user id=sa; password=123"
    End Function

    Public Shared Function GetMenuTabIndex(ByVal formId As String) As String
        Dim dsXML As New Data.DataSet
        dsXML.ReadXml(HttpContext.Current.Request.PhysicalApplicationPath + "\\MenuStyle.xml")
        Dim dr() = dsXML.Tables(0).Select("id='" + formId + "'")

        If dr.Length >= 1 Then
            Return Convert.ToInt32(dr(0).Item(0))
        Else
            Return 0 'b'se of no entry in XML
        End If

    End Function
    Public Shared Function GetAccessPermn_and_MenuTabIndex(ByVal formId As String, ByVal userType As Integer) As String
        Dim dsXML As New Data.DataSet
        dsXML.ReadXml(HttpContext.Current.Request.PhysicalApplicationPath + "\\MenuStyle.xml")

        Dim dr() = dsXML.Tables(0).Select("id='" + formId + "'")
        If dr.Length >= 1 Then
            MenuTabSelected = Convert.ToInt32(dr(0).Item(0)) 'Setting value to the 'Shared' variable
        Else
            MenuTabSelected = 0 'b'se of no entry in XML
        End If


        Dim drAccess() = dsXML.Tables(0).Select("id='" & formId & "' and accessPermission<=" & userType)
        If drAccess.Length >= 1 Then
            Return True
        Else
            Return False 'No Access Permission for this user type
        End If

    End Function
    Public Shared Function getReportsPath() As String
        Return ConfigurationManager.AppSettings("CrystRptPath").ToString()
    End Function
    Public Shared Function ClearControls(ByRef objPanel As Panel, ByVal exceptFieldValues As String) As Boolean
        Dim objTextBox As TextBox
        Dim objDropDown As DropDownList
        Dim objCheckBox As CheckBox
        Dim objControl As Control


        For Each objControl In objPanel.Controls


            Select Case objControl.GetType().Name.ToLower()
                Case "textbox"
                    objTextBox = CType(objControl, TextBox)
                    If Not exceptFieldValues.Contains(objTextBox.ID) Then
                        objTextBox.Text = ""
                    End If

                Case "dropdownlist"
                    objDropDown = Nothing
                    objDropDown = CType(objControl, DropDownList)
                    Try
                        'If objDropDown.Items.Count > 0 Then
                        '    objDropDown.SelectedValue = Nothing
                        'Else
                        '    objDropDown.Text = ""
                        'End If
                        objDropDown.SelectedValue = Nothing
                    Catch ex As Exception

                    End Try

                Case "checkbox"
                    objCheckBox = CType(objControl, CheckBox)
                    objCheckBox.Checked = False
            End Select

        Next
        Return True
    End Function
    Public Shared Sub gDocumentNo_Generator(ByVal proc1 As String, ByVal proc2 As String, ByVal txt As TextBox)
        Dim gMyCommand As SqlCommand
        Dim connstring As String = ConfigurationManager.ConnectionStrings("loyaltyMainServer").ConnectionString
        Dim myConnection As New SqlConnection(connstring)
        Dim gDr As SqlDataReader
        Dim vPrefix As String
        Dim vDefLoc As String
        Dim dr1 As SqlDataReader
        Dim vAutoGen As String
        Dim vMaxDocNo As String
        Dim vLFind As String

        Dim YrLD As String = ""
        Dim Yr As String = ""
        Dim mm As String = ""
        Dim i As Integer = 0
        Dim Mid As String = ""
        gMyCommand = New SqlCommand("YearCode_GetRow '" + Trim(Now.Year.ToString) + "','" + Trim(Now.Month.ToString) + "'", myConnection)
        If myConnection.State = Data.ConnectionState.Closed Then myConnection.Open()
        gDr = gMyCommand.ExecuteReader
        If gDr.Read Then
            Yr = gDr(0).ToString
            mm = gDr(1).ToString
        End If
        gDr.Close()
        myConnection.Close()
        gMyCommand.Dispose()

        gMyCommand = New SqlCommand(proc1, myConnection)
        If myConnection.State = Data.ConnectionState.Closed Then myConnection.Open()
        gDr = gMyCommand.ExecuteReader
        If gDr.Read Then
            If IsDBNull(gDr("DocPrefix")) Then
                vPrefix = ""
            Else
                vPrefix = Trim(gDr("DocPrefix").ToString)
            End If
            If IsDBNull(gDr("Def_Loc")) Then
                vDefLoc = ""
            Else
                vDefLoc = Trim(gDr("Def_Loc").ToString)
            End If
            If IsDBNull("AutoGen") Then
                vAutoGen = ""
            Else
                vAutoGen = Trim(gDr("AutoGen").ToString)
            End If
            vMaxDocNo = 0
            gDr.Close()
            If vAutoGen = "Y" Then
                txt.ReadOnly = True
                gMyCommand = New SqlCommand(proc2, myConnection)
                dr1 = gMyCommand.ExecuteReader
                If dr1.Read Then
                    If IsDBNull(dr1(2)) Then
                        vMaxDocNo = "0001"
                    Else
                        vMaxDocNo = Trim(dr1(2).ToString)
                    End If
                    If IsDBNull(dr1(1)) Then
                        vDefLoc = "00"
                    Else
                        vDefLoc = Trim(dr1(1).ToString)
                    End If
                    If IsDBNull(dr1(0)) Then
                        vPrefix = "XX"
                    Else
                        vPrefix = Trim(dr1(0).ToString)
                    End If
                    YrLD = Trim(dr1(3).ToString)
                End If
                'If YrLD <> Yr Then
                '    vMaxDocNo = "0001"
                'End If
                ' txt.Text = Trim(vPrefix) & Trim(vDefLoc) & Trim(Yr) & Trim(mm) & Trim(vMaxDocNo)
                i = 1
                Mid = ""
                While i <= (10 - (Len(vPrefix) + Len(vMaxDocNo)))
                    Mid = Mid & "0"
                    i = i + 1
                End While
                txt.Text = Trim(vPrefix) & Trim(Mid) & Trim(vMaxDocNo)
            Else
                txt.ReadOnly = False
            End If
        End If
        'dr1.Close()
        myConnection.Close()
        vPrefix = ""
        vDefLoc = ""
        vAutoGen = ""
        vMaxDocNo = "0"
        vLFind = ""
    End Sub
End Class
