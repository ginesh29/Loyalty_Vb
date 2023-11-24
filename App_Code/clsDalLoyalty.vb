Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Reporting.WebForms

Public Class clsDalLoyalty

    Public Sub GetCustArea(ByVal objBll As clsBllLoyalty)
        Dim cmd As New SqlCommand("[Ly_CustAccomdnArea_GetRow]")
        cmd.Parameters.Add("@AccAreaId", Data.SqlDbType.Int).Value = objBll.CustArea

        Dim objDB As New clsDBOperation
        Dim dt = objDB.executeQry(cmd, "").Tables(0)
        If dt.Rows.Count > 0 Then
            objBll.CustArea = dt.Rows(0)("AccAreaId").ToString()
            objBll.Area = dt.Rows(0)("AccArea").ToString()
            objBll.Addr1 = dt.Rows(0)("Addr").ToString()
        End If
    End Sub
    Public Function GetLocation(ByVal objBll As clsBllLoyalty) As String 'added by nitheesh
        Dim cmd As New SqlCommand("Ly_posterminals_locations_Getrow")
        cmd.Parameters.Add("@term_des", Data.SqlDbType.VarChar).Value = objBll.LocCd
        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "").Tables(0).Rows(0)(0).ToString()

        Return ds
    End Function
    Public Function GetCustomers(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("Ly_Customers_GetRow")
        cmd.Parameters.Add("@v_Cd", Data.SqlDbType.VarChar).Value = objBll.Cd

        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")
        If ds.Tables(0).Rows.Count > 0 Then
            objBll.Cd = ds.Tables(0).Rows(0)("Cd").ToString()
            objBll.Des = ds.Tables(0).Rows(0)("Des").ToString()
            objBll.FName = ds.Tables(0).Rows(0)("FName").ToString()
            objBll.LName = ds.Tables(0).Rows(0)("LName").ToString()
            objBll.MName = ds.Tables(0).Rows(0)("MName").ToString()
            objBll.CompanyId = ds.Tables(0).Rows(0)("CoCd").ToString()
            objBll.CompanyName = ds.Tables(0).Rows(0)("CompanyName").ToString()

            objBll.Gender = ds.Tables(0).Rows(0)("Gender").ToString()
            objBll.BirthDt = ds.Tables(0).Rows(0)("BirthDt").ToString()
            objBll.Addr1 = ds.Tables(0).Rows(0)("Addr1").ToString()
            objBll.Addr2 = ds.Tables(0).Rows(0)("Addr2").ToString()
            objBll.Addr3 = ds.Tables(0).Rows(0)("Addr3").ToString()

            objBll.CustCo = IIf(ds.Tables(0).Rows(0)("CustCoCd").ToString() <> "", ds.Tables(0).Rows(0)("CustCoCd").ToString(), 0)
            objBll.CustArea = IIf(ds.Tables(0).Rows(0)("AreaCd").ToString() <> "", ds.Tables(0).Rows(0)("AreaCd").ToString(), 0)
            objBll.Religion = IIf(ds.Tables(0).Rows(0)("Religion").ToString() <> "", ds.Tables(0).Rows(0)("Religion").ToString(), 0)
            objBll.Profession = IIf(ds.Tables(0).Rows(0)("Profession").ToString() <> "", ds.Tables(0).Rows(0)("Profession").ToString(), 0)

            objBll.Phone = ds.Tables(0).Rows(0)("Phone").ToString()
            objBll.Fax = ds.Tables(0).Rows(0)("Fax").ToString()
            objBll.Mobile = ds.Tables(0).Rows(0)("Mobile").ToString()
            objBll.Email = ds.Tables(0).Rows(0)("Email").ToString()
            objBll.UID = ds.Tables(0).Rows(0)("UID").ToString()
            objBll.IDType = ds.Tables(0).Rows(0)("IDType").ToString()

            objBll.Curr = ds.Tables(0).Rows(0)("Curr").ToString()

            objBll.Country = ds.Tables(0).Rows(0)("Country").ToString()
            objBll.CountryName = ds.Tables(0).Rows(0)("CountryName").ToString()
            objBll.Region = ds.Tables(0).Rows(0)("Region").ToString()
            objBll.CustGrp = ds.Tables(0).Rows(0)("CustGrp").ToString()
            objBll.CardType = ds.Tables(0).Rows(0)("CardType").ToString()
            objBll.Appr_Points = ds.Tables(0).Rows(0)("Appr_Points").ToString()
            objBll.Redm_Points = ds.Tables(0).Rows(0)("Redm_Points").ToString()
            objBll.Unappr_Points = ds.Tables(0).Rows(0)("Unappr_Points").ToString()
            objBll.MaxRedeemPnts = ds.Tables(0).Rows(0)("MaxRedeemPoints").ToString()

            objBll.Last_PurDt = ds.Tables(0).Rows(0)("Last_PurDt").ToString()
            objBll.Active = ds.Tables(0).Rows(0)("Active").ToString()
            objBll.BlackListed = ds.Tables(0).Rows(0)("BlackListed").ToString()

            objBll.CardIssued = ds.Tables(0).Rows(0)("CardIssued").ToString()
            objBll.Remarks = ds.Tables(0).Rows(0)("Remarks").ToString()

            objBll.EntryBy = ds.Tables(0).Rows(0)("EntryBy").ToString()
            objBll.EntryDt = ds.Tables(0).Rows(0)("EntryDt")
            objBll.EditBy = ds.Tables(0).Rows(0)("EditBy").ToString()

            objBll.CustGrpCd = ds.Tables(0).Rows(0)("CustGrpCd").ToString()
            ' objBll.EditDt =IsDBNull(ds.Tables(0).Rows(0)("EditDt")
            Return ds
        Else
            Return Nothing
        End If
    End Function

    Public Function SetCustomer(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_Customers_Update")
        cmd.Parameters.Add("@v_cd", Data.SqlDbType.VarChar).Value = objBll.Cd
        cmd.Parameters.Add("@v_Des", Data.SqlDbType.VarChar).Value = objBll.Des
        cmd.Parameters.Add("@v_FName", Data.SqlDbType.VarChar).Value = objBll.FName
        cmd.Parameters.Add("@v_LName", Data.SqlDbType.VarChar).Value = objBll.LName
        cmd.Parameters.Add("@v_MName", Data.SqlDbType.VarChar).Value = objBll.MName
        cmd.Parameters.Add("@v_CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId


        cmd.Parameters.Add("@v_Gender", Data.SqlDbType.Bit).Value = objBll.Gender
        cmd.Parameters.Add("@v_BirthDt", Data.SqlDbType.DateTime).Value = objBll.BirthDt
        cmd.Parameters.Add("@v_Addr1", Data.SqlDbType.VarChar).Value = objBll.Addr1
        cmd.Parameters.Add("@v_Addr2", Data.SqlDbType.VarChar).Value = objBll.Addr2
        cmd.Parameters.Add("@v_Addr3", Data.SqlDbType.VarChar).Value = objBll.Addr3

        cmd.Parameters.Add("@v_CustCoCd", Data.SqlDbType.Int).Value = objBll.CustCo
        cmd.Parameters.Add("@v_AreaCd", Data.SqlDbType.Int).Value = objBll.CustArea
        cmd.Parameters.Add("@v_Religion", Data.SqlDbType.Int).Value = objBll.Religion
        cmd.Parameters.Add("@v_Profession", Data.SqlDbType.Int).Value = objBll.Profession

        cmd.Parameters.Add("@v_Phone", Data.SqlDbType.VarChar).Value = objBll.Phone
        cmd.Parameters.Add("@v_Fax", Data.SqlDbType.VarChar).Value = objBll.Fax
        cmd.Parameters.Add("@v_Mobile", Data.SqlDbType.VarChar).Value = objBll.Mobile
        cmd.Parameters.Add("@v_Email", Data.SqlDbType.VarChar).Value = objBll.Email
        cmd.Parameters.Add("@v_UID", Data.SqlDbType.VarChar).Value = objBll.UID
        cmd.Parameters.Add("@v_IDType", Data.SqlDbType.VarChar).Value = objBll.IDType

        cmd.Parameters.Add("@v_Curr", Data.SqlDbType.VarChar).Value = objBll.Curr
        cmd.Parameters.Add("@v_Country", Data.SqlDbType.VarChar).Value = objBll.Country
        cmd.Parameters.Add("@v_Region", Data.SqlDbType.VarChar).Value = objBll.Region
        cmd.Parameters.Add("@v_CustGrp", Data.SqlDbType.VarChar).Value = objBll.CustGrp
        cmd.Parameters.Add("@v_CardType", Data.SqlDbType.VarChar).Value = objBll.CardType
        cmd.Parameters.Add("@v_Active", Data.SqlDbType.Bit).Value = objBll.Active
        cmd.Parameters.Add("@v_BlackListed", Data.SqlDbType.Bit).Value = objBll.BlackListed

        cmd.Parameters.Add("@v_CardIssued", Data.SqlDbType.Bit).Value = objBll.CardIssued
        cmd.Parameters.Add("@v_Remarks", Data.SqlDbType.VarChar).Value = objBll.Remarks

        cmd.Parameters.Add("@v_EntryBy", Data.SqlDbType.VarChar).Value = objBll.EntryBy
        cmd.Parameters.Add("@v_EditBy", Data.SqlDbType.VarChar).Value = objBll.EditBy
        cmd.Parameters.Add("@v_PImage", Data.SqlDbType.VarChar).Value = ""
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")
    End Function

    Public Sub ComboFill(ByVal objBll As clsBllLoyalty)
        Dim cmd As SqlCommand
        Dim objDB As New clsDBOperation

        If objBll.Ddl.ID = "ddlCustGrp" Then
            cmd = New SqlCommand("LY_CustGrp_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "")

        ElseIf objBll.Ddl.ID = "ddlCountry" Then
            cmd = New SqlCommand("Ly_Country_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "")

        ElseIf objBll.Ddl.ID = "ddlCompany" Then
            cmd = New SqlCommand("[Ly_Company_Getrow]")
            cmd.Parameters.Add("CoCd", Data.SqlDbType.VarChar).Value = ""
            objDB.comboFill(objBll.Ddl, cmd, "")

        ElseIf objBll.Ddl.ID = "ddlReligion" Then
            cmd = New SqlCommand("Ly_Religion_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "")

        ElseIf objBll.Ddl.ID = "ddlProfession" Then
            cmd = New SqlCommand("Ly_Profession_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "")

        ElseIf objBll.Ddl.ID = "ddlCustCompany" Then
            cmd = New SqlCommand("Ly_CustCompany_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "")

        ElseIf objBll.Ddl.ID = "ddlAccArea" Then
            cmd = New SqlCommand("Ly_CustAccomdnArea_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "")

            'combo-->GrpBy
        ElseIf objBll.Ddl.ID = "ddlCountryGrpBy" Then
            cmd = New SqlCommand("Ly_Country_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "", "All")

        ElseIf objBll.Ddl.ID = "ddlCustGrpGrpBy" Then
            cmd = New SqlCommand("LY_CustGrp_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "", "All")

        ElseIf objBll.Ddl.ID = "ddlCustCompanyGrpBy" Then
            cmd = New SqlCommand("Ly_CustCompany_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "", "All")

        ElseIf objBll.Ddl.ID = "ddlAccAreaGrpBy" Then
            cmd = New SqlCommand("Ly_CustAccomdnArea_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "", "All")

        ElseIf objBll.Ddl.ID = "ddlReligionGrpBy" Then
            cmd = New SqlCommand("Ly_Religion_GetRow")
            objDB.comboFill(objBll.Ddl, cmd, "", "All")

        ElseIf objBll.Ddl.ID = "ddlCompanyAll" Then
            cmd = New SqlCommand("[Ly_Company_Getrow]")
            cmd.Parameters.Add("CoCd", Data.SqlDbType.VarChar).Value = ""
            objDB.comboFill(objBll.Ddl, cmd, "", "All")

        ElseIf objBll.Ddl.ID = "ddlCounterNo" Then
            cmd = New SqlCommand("Ly_PosCounter_GetRow")
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
            objDB.comboFill(objBll.Ddl, cmd, "")

            'ElseIf objBll.Ddl.ID = "ddlGroups" Then  ' -Loading data from 'MAIN MADINA2 SERVER'
            '    cmd = New SqlCommand("")
            '    cmd.Parameters.Add("CoCd", Data.SqlDbType.VarChar).Value = ""
            '    objDB.comboFill(objBll.Ddl, cmd, "", "All")


        ElseIf objBll.Ddl.ID = "ddlCardType" Then
            'Advanced one 
        ElseIf objBll.Ddl.ID = "ddlCurr" Then
            'Advanced one
        End If
    End Sub

    Public Sub GridFill(ByVal objBll As clsBllLoyalty)
        Dim cmd As SqlCommand
        Dim objDB As New clsDBOperation

        If objBll.Gv.ID = "gvSaleRuleDetail" Then
            cmd = New SqlCommand("[Ly_SalesRulesDetail_GetRow]")
            cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
            objDB.gridFill(objBll.Gv, cmd, "")

        ElseIf objBll.Gv.ID = "gvCustTrans" Then
            cmd = New SqlCommand("Ly_CustTrans_GetRow")
            cmd.Parameters.Add("@CustCd", Data.SqlDbType.Char).Value = objBll.Cd
            cmd.Parameters.Add("@dtFrom", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@dtTo", Data.SqlDbType.DateTime).Value = objBll.ToDt
            objDB.gridFill(objBll.Gv, cmd, "")

        ElseIf objBll.Gv.ID = "gvSRDetail" Then
            cmd = New SqlCommand("Ly_SalesRulesDetail_GetRow")
            cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Char).Value = objBll.RuleId
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            objDB.gridFill(objBll.Gv, cmd, "")

        ElseIf objBll.Gv.ID = "gvProfession" Then
            cmd = New SqlCommand("Ly_Profession_GetRow")
            objDB.gridFill(objBll.Gv, cmd, "")

        ElseIf objBll.Gv.ID = "gvCustCompany" Then
            cmd = New SqlCommand("[Ly_CustCompany_GetRow]")
            objDB.gridFill(objBll.Gv, cmd, "")

        ElseIf objBll.Gv.ID = "gvCustArea" Then
            cmd = New SqlCommand("[Ly_CustAccomdnArea_GetRow]")
            'cmd.Parameters.Add("@AccAreaId", Data.SqlDbType.Int).Value = objBll.CustArea
            objDB.gridFill(objBll.Gv, cmd, "")


            'ElseIf objBll.Gv.ID = "gvRedRDetail" Then
            '    cmd = New SqlCommand("Ly_SalesRulesDetail_GetRow")
            '    cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Char).Value = objBll.RuleId
            '    cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            '    objDB.gridFill(objBll.Gv, cmd, "")


        ElseIf objBll.Gv.ID = "gvUserList" Then
            cmd = New SqlCommand("[Ly_Users_GetRow]")
            cmd.Parameters.Add("@UName", Data.SqlDbType.Char).Value = objBll.Username
            cmd.Parameters.Add("@UPwd", Data.SqlDbType.Char).Value = objBll.Pwd
            objDB.gridFill(objBll.Gv, cmd, "")

        End If
    End Sub

    'Public Function ValidateRedeemItems(ByVal objBal As clsBllLoyalty) As Boolean
    '    Dim cmd As New SqlCommand("[Ly_RedeemItems_GetRow]")
    '    cmd.Parameters.Add("@v_CustGrp", Data.SqlDbType.VarChar).Value = objBal.CustGrpCd
    '    cmd.Parameters.Add("@v_ItemCd", Data.SqlDbType.Char).Value = objBal.ItemCode

    '    Dim objDB As New clsDBOperation
    '    Dim obj = objDB.executeScalar(cmd, "loyaltyMainServer") '-----Note: check the server

    '    If obj Is Nothing Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function
    Public Function validateMobileNo(ByVal objBal As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_Customers_ValidateMobileNo")
        cmd.Parameters.Add("@cd", Data.SqlDbType.Char).Value = objBal.Cd
        cmd.Parameters.Add("@mobileNo", Data.SqlDbType.Char).Value = objBal.Mobile
        Dim objDB As New clsDBOperation
        objBal.Cd = objDB.executeScalar(cmd, "")
        Return objBal.Cd
    End Function
    Public Function setRedeemHead(ByVal objBll As clsBllLoyalty, ByVal serverName As String) As String
        Dim cmd As New SqlCommand("Ly_RedeemTransHead_Update")
        cmd.Parameters.Add("@v_TrnId", Data.SqlDbType.Int).Value = objBll.TrnId
        cmd.Parameters.Add("@v_TrnDt", Data.SqlDbType.DateTime).Value = objBll.TrnDate
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_CustCd", Data.SqlDbType.Char).Value = objBll.Cd
        cmd.Parameters.Add("@v_RedPoints", Data.SqlDbType.Decimal).Value = objBll.Redm_Points
        cmd.Parameters.Add("@v_Narr", Data.SqlDbType.VarChar).Value = objBll.Narration

        'cmd.Parameters.Add("@v_Loc", Data.SqlDbType.).Value = objBll.loc
        'cmd.Parameters.Add("@v_BalPoints", Data.SqlDbType.).Value = objBll.


        '-------NOTE: ask PK & create propery
        cmd.Parameters.Add("@v_RefDocTyp", Data.SqlDbType.Char).Value = "SI01"
        cmd.Parameters.Add("@v_DocStat", Data.SqlDbType.Char).Value = objBll.DocStatus

        cmd.Parameters.Add("@v_RefDocNo", Data.SqlDbType.VarChar).Value = objBll.RefDocNo
        cmd.Parameters.Add("@v_EntryBy", Data.SqlDbType.VarChar).Value = objBll.EntryBy

        'Returns last inserted AutoNumber field(TrnId) 

        Try
            Dim objDB As New clsDBOperation

            Return objDB.executeQry(cmd, serverName).Tables(0).Rows(0)(0).ToString()
        Catch ex As Exception
            Return "ERROR:" & ex.Message
        End Try

    End Function
    Public Function setRedeemDetail(ByVal objBll As clsBllLoyalty, ByVal serverName As String) As String
        Dim cmd As New SqlCommand("Ly_RedeemTransDetail_Update")
        cmd.Parameters.Add("@v_TrnAutoNo", Data.SqlDbType.Int).Value = objBll.TrnAutoNo
        cmd.Parameters.Add("@v_TrnId", Data.SqlDbType.Int).Value = objBll.TrnId
        cmd.Parameters.Add("@v_ItemCd", Data.SqlDbType.Char).Value = objBll.ItemCode
        cmd.Parameters.Add("@v_Qty", Data.SqlDbType.Int).Value = objBll.Qty
        cmd.Parameters.Add("@v_Unit", Data.SqlDbType.Char).Value = objBll.Unit
        cmd.Parameters.Add("@v_BaseQty", Data.SqlDbType.Int).Value = objBll.BaseQty
        cmd.Parameters.Add("@v_Points", Data.SqlDbType.Float).Value = objBll.Points
        cmd.Parameters.Add("@v_Cost", Data.SqlDbType.Decimal).Value = objBll.Cost
        cmd.Parameters.Add("@v_Narr", Data.SqlDbType.VarChar).Value = objBll.Narration
        Try
            Dim objDB As New clsDBOperation
            Return objDB.executeNonqry(cmd, serverName)
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function getRedeemHead(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("[Ly_RedeemTransHead_GetRow]")
        cmd.Parameters.Add("@custCd", Data.SqlDbType.VarChar).Value = objBll.Cd

        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")
        Return ds
    End Function

    Public Function GetRedeemDetails(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("Ly_RedeemTransDetail_GetRow")
        cmd.Parameters.Add("@v_TrnId", Data.SqlDbType.Int).Value = objBll.TrnId

        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")
        Return ds
    End Function

    Public Function getUserDetails(ByVal objBll As clsBllLoyalty) As Boolean
        Dim cmd As New SqlCommand("Ly_Users_GetRow")
        cmd.Parameters.Add("@UName", SqlDbType.VarChar).Value = objBll.Username
        cmd.Parameters.Add("@UPwd", SqlDbType.VarChar).Value = objBll.Pwd

        Try
            Dim objDB As New clsDBOperation
            Dim dt = objDB.executeQry(cmd, "").Tables(0)
            If (dt.Rows.Count > 0) Then
                objBll.Username = dt.Rows(0).ItemArray(1).ToString()
                objBll.CompanyId = dt.Rows(0).ItemArray(2).ToString()
                objBll.CompanyName = dt.Rows(0).ItemArray(3).ToString()
                objBll.UserType = dt.Rows(0).ItemArray(4).ToString()
                Return True
            Else
                objBll.ErrorMsg = clsUtilities.showMessage("InvalidUser")
                Return False
            End If
        Catch ex As Exception
            objBll.ErrorMsg = ex.Message
            Return False
        End Try

    End Function

    Public Function getSalesRules(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("[Ly_SalesRulesHead_GetRow]")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId

        Dim objDB As New clsDBOperation
        Return objDB.executeQry(cmd, "")
    End Function
    Public Function getRedRules(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("Ly_RedeemRulesHead_GetRow")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId

        Dim objDB As New clsDBOperation
        Return objDB.executeQry(cmd, "")
    End Function

    Public Function updateSalesRulesHead_LocalMachine(ByVal objBll As clsBllLoyalty) As String
        Dim sql = "delete from LY_SalesRulesHead where RuleId=" & objBll.RuleId
        sql += " insert into LY_SalesRulesHead Values(" & objBll.RuleId & ",'" & objBll.CompanyId & "','" & objBll.Des & "','" & objBll.CustGrpCd & "','" & objBll.FromDt.ToString("MM/dd/yyyy") & "','" & objBll.ToDt.ToString("MM/dd/yyyy") & "'," & objBll.Points & "," & objBll.DiscPers & ",'" & objBll.EntryBy & "','" & objBll.EntryDt.ToString("MM/dd/yyyy") & "','" & objBll.EditBy & "','" & objBll.EditDt.ToString("MM/dd/yyyy") & "')"
        sql += " delete from LY_SalesRulesDetail where RuleId=" & objBll.RuleId

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(sql, objBll.ConnLocalSvr)


        ' Dim cmd As New SqlCommand("[Ly_SalesRulesHead_Detail_Update_LocalServer]")
        ' cmd.Parameters.Add("@RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
        ' Dim objDB As New clsDBOperation
        'Return objDB.executeNonqry(cmd, clsUtilities.CreateConnString(objBll.CompanyId))
    End Function
    Public Function updateSalesRulesDetail_LocalMachine(ByVal objBll As clsBllLoyalty) As String
        Dim sql = "insert into LY_SalesRulesDetail Values('" & objBll.RuleId & "','" & objBll.CompanyId & "'," & objBll.Srl & ",'" & objBll.Grp & "','" & objBll.SubGrp & "','" & objBll.Category & "','" & objBll.ItemCode & "'," & objBll.Amt & "," & objBll.Points & "," & objBll.DiscPers & ",'" & objBll.EntryBy & "','" & objBll.EntryDt.ToString("MM/dd/yyyy") & "','" & objBll.EditBy & "','" & objBll.EditDt.ToString("MM/dd/yyyy") & "')"
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(sql, objBll.ConnLocalSvr)

    End Function
    Public Function updateRedRulesHead_LocalMachine(ByVal objBll As clsBllLoyalty) As String

        Dim sql = "delete from LY_RedeemRulesHead where RuleId=" & objBll.RuleId & " and CoCd='" & objBll.CompanyId & "'"
        sql += " insert into LY_RedeemRulesHead (RuleId,CoCd,Des,CustGrp,FromPoints,EntryBy,EntryDt,EditBy,EditDt) Values(" & objBll.RuleId & ",'" & objBll.CompanyId & "','" & objBll.Des & "'," & objBll.CustGrpCd & "," & objBll.Points & ",'" & objBll.EntryBy & "','" & objBll.EntryDt.ToString("MM/dd/yyyy") & "','" & objBll.EditBy & "','" & objBll.EditDt.ToString("MM/dd/yyyy") & "')"
        sql += " delete from LY_RedeemRulesDetail where RuleId=" & objBll.RuleId & " and CoCd='" & objBll.CompanyId & "'"

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(sql, objBll.ConnLocalSvr)


        ' Dim cmd As New SqlCommand("[Ly_SalesRulesHead_Detail_Update_LocalServer]")
        ' cmd.Parameters.Add("@RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
        ' Dim objDB As New clsDBOperation
        'Return objDB.executeNonqry(cmd, clsUtilities.CreateConnString(objBll.CompanyId))
    End Function
    Public Function updateRedRulesDetail_LocalMachine(ByVal objBll As clsBllLoyalty) As String
        Dim sql = "insert into LY_RedeemRulesDetail Values('" & objBll.RuleId & "','" & objBll.CompanyId & "'," & objBll.Srl & ",'" & objBll.ItemCode & "','" & objBll.ItemName & "','" & objBll.EntryBy & "','" & objBll.EntryDt.ToString("MM/dd/yyyy") & "','" & objBll.EditBy & "','" & objBll.EditDt & "')"
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(sql, objBll.ConnLocalSvr)

    End Function
    Public Sub getFirstRedeemDt(ByVal objBll As clsBllLoyalty)
        Dim sql = "select MIN(trndt) from Ly_RedeemTransBalance"
        Dim objDB As New clsDBOperation
        objBll.TrnDate = DateTime.Parse(objDB.executeQry(sql, "").Tables(0).Rows(0)(0))
    End Sub

    Public Sub getNextCustomerNo(ByVal objBll As clsBllLoyalty)
        Dim cmd As New SqlCommand("[Ly_Customers_GenerateID]")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId

        Dim objDB As New clsDBOperation
        objBll.Cd = objDB.executeScalar(cmd, "").ToString()
    End Sub
    Public Function getSalesUpdnDetails(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("Ly_CustTransUpdation_GetRow")
        cmd.Parameters.Add("@compId", Data.SqlDbType.Char).Value = objBll.CompanyId

        Dim objDB As New clsDBOperation
        Return objDB.executeQry(cmd, "")

        'If obj.ToString() <> "" Then
        '    objBll.TrnDate = Convert.ToString() '-----NOTE :ERROR when there is no entry in table Ly_CustTrans_Updation
        'Else
        '    objBll.TrnDate = ""
        'End If

    End Function
    Public Function updateCustTransactions(ByVal objBll As clsBllLoyalty) As String
        Dim sql = "select * from ly_custTrans where LyServerUpdtFlag=0"
        Dim objDB As New clsDBOperation

        Try
            Dim dtTobeUpdated As DataTable = objDB.executeQry(sql, objBll.ConnLocalSvr).Tables(0)


            '----------NOTE: needs Trans Commit-From here:------------------------------------
            For Each dr As DataRow In dtTobeUpdated.Rows
                Dim cmd1 As New SqlCommand("Ly_CustTrans_Update_LoyaltySvr")

                cmd1.Parameters.Add("@TrnId", Data.SqlDbType.Int).Value = dr.Item(1).ToString()
                cmd1.Parameters.Add("@CustCd", Data.SqlDbType.Char).Value = dr.Item(2).ToString()
                cmd1.Parameters.Add("@BillNo", Data.SqlDbType.Int).Value = dr.Item(3).ToString()
                cmd1.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId    'dr.Item(4).ToString()-------NOTE: modified(care during the handling of 'Auto transfer'(DTS))
                cmd1.Parameters.Add("@PosId", Data.SqlDbType.Int).Value = dr.Item(5).ToString()
                cmd1.Parameters.Add("@Loc", Data.SqlDbType.VarChar).Value = dr.Item(6).ToString()
                cmd1.Parameters.Add("@TrnDt", Data.SqlDbType.DateTime).Value = dr.Item(7).ToString()
                cmd1.Parameters.Add("@RuleId", Data.SqlDbType.Int).Value = dr.Item(8).ToString()
                cmd1.Parameters.Add("@ItemCd", Data.SqlDbType.VarChar).Value = dr.Item(9).ToString()
                cmd1.Parameters.Add("@Qty", Data.SqlDbType.Int).Value = dr.Item(10).ToString()
                cmd1.Parameters.Add("@Unit", Data.SqlDbType.VarChar).Value = dr.Item(11).ToString()
                cmd1.Parameters.Add("@SellPr", Data.SqlDbType.Decimal).Value = dr.Item(12).ToString()
                cmd1.Parameters.Add("@Amt", Data.SqlDbType.Decimal).Value = dr.Item(13).ToString()
                cmd1.Parameters.Add("@Points", Data.SqlDbType.Decimal).Value = dr.Item(14).ToString()
                cmd1.Parameters.Add("@Status", Data.SqlDbType.Char).Value = dr.Item(15).ToString()
                cmd1.Parameters.Add("@Value", Data.SqlDbType.Decimal).Value = dr.Item(16).ToString()
                cmd1.Parameters.Add("@flag", Data.SqlDbType.Char).Value = dr.Item(17).ToString()
                cmd1.Parameters.Add("@LyServerUpdtFlag", Data.SqlDbType.Bit).Value = dr.Item(18).ToString()

                objDB.executeNonqry(cmd1, "")
            Next

            'After the updation of all the New records to MainLoyaltyServer,
            '1. It is needed to update the flag of all the records in the 'LocalServer as 'Updated'
            '2. Keep the History of last updation

            sql = "update ly_custTrans set LyServerUpdtFlag=1 where LyServerUpdtFlag=0"
            objDB.executeNonqry(sql, objBll.ConnLocalSvr)

            Dim cmd2 As New SqlCommand("Ly_CustTrans_Update1_LoyaltySvr")
            cmd2.Parameters.Add("@compId", Data.SqlDbType.Char).Value = objBll.CompanyId
            cmd2.Parameters.Add("@UpdateBy", Data.SqlDbType.VarChar).Value = objBll.Username
            objDB.executeNonqry(cmd2, "")
            '----------NOTE: needs Trans Commit-To here:------------------------------------

        Catch ex As Exception
            Return ex.Message
        End Try

        Return "success"
    End Function
    'Public Function showReport(ByVal objBll As clsBllLoyalty, rptPath As String) As ReportDocument
    '    Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    '    Dim objDB As New clsDBOperation
    '    Dim ds As New Data.DataSet

    '    If (objBll.SelRpt = "custDtls") Then

    '        rpt.Load(rptPath & "\CustDetails.rpt")
    '        'rpt.Load(Server.MapPath("") + "\\CustDetails.rpt")

    '        'rpt.Load(HttpContext.Current.Server.MapPath("~/Reports/") + "CustDetails.rpt")
    '        'rpt.Load(clsUtilities.getReportsPath() + "CustDetails.rpt")
    '        Dim cmd As New SqlCommand("GetRepo_Ly_Customers")
    '        cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.Char).Value = objBll.Qry
    '        cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = ""
    '        ds = objDB.executeQry(cmd, "")
    '        rpt.SetDataSource(ds.Tables(0))
    '    End If
    '    Return rpt
    'End Function

    'Public Function showReport_RDLC(ByVal objBll As clsBllLoyalty) As Data.DataSet
    '    'Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    '    Dim objDB As New clsDBOperation
    '    Dim ds As New Data.DataSet

    '    If (objBll.SelRpt = "custDtls") Then

    '        'rpt.Load(HttpContext.Current.Server.MapPath("~/Reports/") + "CustDetails.rpt")
    '        Dim cmd As New SqlCommand("GetRepo_Ly_Customers")
    '        cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.Char).Value = objBll.Qry
    '        cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = ""
    '        ds = objDB.executeQry(cmd, "")
    '        'rpt.SetDataSource(ds.Tables(0))
    '        Return ds
    '        'ReportViewer1.ProcessingMode = ProcessingMode.Local
    '        'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
    '        'Dim dsCustomers As Data.DataSet = GetData("select top 20 * from customers")
    '        'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
    '        'ReportViewer1.LocalReport.DataSources.Clear()
    '        'ReportViewer1.LocalReport.DataSources.Add(datasource)

    '        'rpt.Load(HttpContext.Current.Server.MapPath("~/Reports/") + "CustDetails.rpt")
    '        'Dim cmd As New SqlCommand("GetRepo_Ly_Customers")
    '        'cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.Char).Value = objBll.Qry
    '        'cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = ""
    '        'ds = objDB.executeQry(cmd, "")
    '        'rpt.SetDataSource(ds.Tables(0))
    '    End If
    'End Function

    Public Sub createRDLCReport(ByVal objBll As clsBllLoyalty, ByVal reportName As String, ByVal bindedDataTable As String, ByVal dsName As DataSet)
        Dim rds As New ReportDataSource
        objBll.RptVr.ProcessingMode = ProcessingMode.Local
        objBll.RptVr.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/Reports/" & reportName)
        rds.Name = bindedDataTable
        rds.Value = dsName.Tables(0)
        objBll.RptVr.LocalReport.DataSources.Clear()
        objBll.RptVr.LocalReport.DataSources.Add(rds)
        objBll.RptVr.ZoomMode = ZoomMode.Percent
    End Sub

    Public Sub showReport(ByVal objBll As clsBllLoyalty)
        'Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Dim objDB As New clsDBOperation
        Dim ds As New Data.DataSet


        If (objBll.SelRpt = "custDtls") Then
            Dim cmd As New SqlCommand("GetRepo_Ly_Customers_New")
            cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.VarChar).Value = objBll.Qry


            'cmd.Parameters.AddWithValue("@sqlCondition", objBll.Qry)
            'cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = ""

            createRDLCReport(objBll, "Rpt_CustDetailsAdvd.rdlc", "DtCustDetials", objDB.executeQry(cmd, ""))
            'cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.Char).Value = objBll.Qry
            'cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = ""
            ''createRDLCReport(objBll, "Rpt_CustDetails.rdlc", "DtCustDetails", objDB.executeQry(cmd, ""))
            'createRDLCReport(objBll, "Rpt_CustDetailsAdvd.rdlc", "DtCustDetials", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "custTrans") Then
            Dim cmd As New SqlCommand("GetRepo_Ly_Cust_CustTrans")
            cmd.Parameters.Add("@v_Cd", Data.SqlDbType.Char).Value = objBll.Cd
            cmd.Parameters.Add("@dtFrom", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@dtTo", Data.SqlDbType.DateTime).Value = objBll.ToDt

            createRDLCReport(objBll, "Rpt_CustTrans.rdlc", "DtCustTrans", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "advdQry") Then
            Dim cmd As New SqlCommand("[GetRepo_Ly_Customers]")
            cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.VarChar).Value = objBll.Qry
            cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = ""

            createRDLCReport(objBll, "Rpt_CustDetailsAdvd.rdlc", "DtCustDetials", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "groupByReport") Then
            Dim cmd As New SqlCommand("[GetRepo_Ly_Customers]")
            cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.VarChar).Value = objBll.Qry
            cmd.Parameters.Add("@grpBy", Data.SqlDbType.VarChar).Value = objBll.Grp
            createRDLCReport(objBll, "Rpt_CustGroupByReport.rdlc", "DtCustDetails", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "custCardType") Then
            Dim cmd As New SqlCommand("[GetRepo_Ly_Customers]")
            cmd.Parameters.Add("@sqlCondition", Data.SqlDbType.VarChar).Value = objBll.Qry
            createRDLCReport(objBll, "Rpt_CustCardType.rdlc", "", objDB.executeQry(cmd, ""))

            'Redemption
        ElseIf (objBll.SelRpt = "redCustWise") Then
            Dim cmd As New SqlCommand("GetRepo_Ly_RedeemTransHead")
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            cmd.Parameters.Add("@dtFrom", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@dtto", Data.SqlDbType.DateTime).Value = objBll.ToDt
            createRDLCReport(objBll, "Rpt_RedemptionCustomerwise.rdlc", "dtCustwise", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "redCompWiseSummary") Then
            Dim cmd As New SqlCommand("GetRepo_Ly_RedeemTransHead_1")
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            cmd.Parameters.Add("@fromDt", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@toDt", Data.SqlDbType.DateTime).Value = objBll.ToDt
            cmd.Parameters.Add("@reportType", Data.SqlDbType.VarChar).Value = objBll.SelRpt
            createRDLCReport(objBll, "Rpt_RedemptionCompanyWise.rdlc", "dtCompwise", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "redCompWiseCustWise") Then
            Dim cmd As New SqlCommand("GetRepo_Ly_RedeemTransHead_1")
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            cmd.Parameters.Add("@fromDt", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@toDt", Data.SqlDbType.DateTime).Value = objBll.ToDt
            cmd.Parameters.Add("@reportType", Data.SqlDbType.VarChar).Value = objBll.SelRpt
            createRDLCReport(objBll, "Rpt_RdmCompCustwise.rdlc", "dtCompwiseCustwise", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "interBranch") Then
            Dim cmd As New SqlCommand("[GetRepo_Ly_RedeemTrans_Accounts]")
            cmd.Parameters.Add("@dtFrom", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@dtto", Data.SqlDbType.DateTime).Value = objBll.ToDt
            cmd.Parameters.Add("@custCd", Data.SqlDbType.Char).Value = objBll.Cd
            createRDLCReport(objBll, "Rpt_RedAccounts.rdlc", "dtInterBranch", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "interBranchAmount") Then
            Dim cmd As New SqlCommand("GetRepo_Ly_RedeemTrans_Accounts1")
            cmd.Parameters.Add("@dtFrom", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@dtTo", Data.SqlDbType.DateTime).Value = objBll.ToDt
            cmd.Parameters.Add("@custCd", Data.SqlDbType.Char).Value = objBll.Cd

            createRDLCReport(objBll, "Rpt_InterBranchAmount.rdlc", "dtInterBranchAmount", objDB.executeQry(cmd, ""))
            'acual dt--> "dtInterBranchAmount"
        ElseIf (objBll.SelRpt = "salesRules") Then

            Dim cmd As New SqlCommand("GetRepo_SalesRules")
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            createRDLCReport(objBll, "Rpt_SalesRules.rdlc", "DtSalesRules", objDB.executeQry(cmd, ""))


        ElseIf (objBll.SelRpt = "redRules") Then
            Dim cmd As New SqlCommand("GetRepo_RedRules")
            'cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            createRDLCReport(objBll, "Rpt_RedRules.rdlc", "DtRedRules", objDB.executeQry(cmd, ""))

        ElseIf (objBll.SelRpt = "dailyTrans") Then
            Dim cmd As New SqlCommand("[Ly_CustTrans_GetRow1]")
            cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId
            cmd.Parameters.Add("@dtFrom", Data.SqlDbType.DateTime).Value = objBll.FromDt
            cmd.Parameters.Add("@dtTo", Data.SqlDbType.DateTime).Value = objBll.ToDt
            cmd.Parameters.Add("@v_Typ", Data.SqlDbType.Char).Value = objBll.UserType
            If objBll.UserType.ToString = "0" Then
                createRDLCReport(objBll, "Rpt_DailyTrans.rdlc", "dsDailyTrans", objDB.executeQry(cmd, ""))
            Else
                createRDLCReport(objBll, "Rpt_DailyTransSumary.rdlc", "dsDailyTrans", objDB.executeQry(cmd, ""))
            End If


        End If


        'rpt.SetDatabaseLogon("sa", "mona", "newserver", "OnlineDN")
        'rpt.SetParameterValue(0, Session["loginLoc"].ToString())
        'CrystalReportViewer1.ReportSource = rpt
        'rpt.SetDatabaseLogon("sa", "123", "(local)", "LoyaltyMainServerDB")
        ' Dim aqq = ConfigurationManager.AppSettings("CrystRptPath").ToString()
    End Sub

    Public Function setSalesRulesHead(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_SalesRulesHead_Update")

        cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
        cmd.Parameters.Add("@v_CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_Des", Data.SqlDbType.VarChar).Value = objBll.Des
        cmd.Parameters.Add("@v_CustGrp", Data.SqlDbType.VarChar).Value = objBll.CustGrp
        cmd.Parameters.Add("@v_FromDt", Data.SqlDbType.DateTime).Value = objBll.FromDt
        cmd.Parameters.Add("@v_ToDt", Data.SqlDbType.DateTime).Value = objBll.ToDt
        cmd.Parameters.Add("@v_Points", Data.SqlDbType.Float).Value = objBll.Points
        cmd.Parameters.Add("@v_DiscPerc", Data.SqlDbType.Float).Value = objBll.DiscPers
        cmd.Parameters.Add("@v_EntryBy", Data.SqlDbType.VarChar).Value = objBll.EntryBy


        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "") '--inserting to loyaltyMainServer

    End Function
    Public Function setSalesRulesDetail(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_SalesRulesDetail_Update")

        cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
        cmd.Parameters.Add("@v_CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_Srl", Data.SqlDbType.Int).Value = objBll.Srl
        cmd.Parameters.Add("@v_Grp", Data.SqlDbType.VarChar).Value = objBll.Grp
        cmd.Parameters.Add("@v_Subgrp", Data.SqlDbType.VarChar).Value = objBll.SubGrp
        cmd.Parameters.Add("@v_Category", Data.SqlDbType.VarChar).Value = objBll.Category
        cmd.Parameters.Add("@v_ItemCd", Data.SqlDbType.VarChar).Value = objBll.ItemCode
        cmd.Parameters.Add("@v_Amt", Data.SqlDbType.Decimal).Value = objBll.Amt
        cmd.Parameters.Add("@v_Points", Data.SqlDbType.Float).Value = objBll.Points
        cmd.Parameters.Add("@v_EntryBy", Data.SqlDbType.VarChar).Value = objBll.EntryBy
        cmd.Parameters.Add("@v_DiscPerc", Data.SqlDbType.Float).Value = objBll.DiscPers

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "") '--inserting to loyaltyMainServer

    End Function
    Public Function setRedRules(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("LY_RedeemRulesHead_Update")

        cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
        cmd.Parameters.Add("@v_CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_Des", Data.SqlDbType.VarChar).Value = objBll.Des
        cmd.Parameters.Add("@v_CustGrp", Data.SqlDbType.Int).Value = objBll.CustGrpCd
        cmd.Parameters.Add("@v_FromPoints", Data.SqlDbType.Float).Value = objBll.Points
        cmd.Parameters.Add("@v_EntryBy", Data.SqlDbType.VarChar).Value = objBll.EntryBy
        cmd.Parameters.Add("@v_ItemCd", Data.SqlDbType.VarChar).Value = objBll.ItemCode

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "") '--inserting to loyaltyMainServer

    End Function

    Public Function setUser(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("[Ly_Users_Update]")

        cmd.Parameters.Add("@v_Cd", Data.SqlDbType.Int).Value = objBll.Cd
        cmd.Parameters.Add("@v_UPWD", Data.SqlDbType.VarChar).Value = objBll.Pwd
        cmd.Parameters.Add("@v_UName", Data.SqlDbType.VarChar).Value = objBll.Username
        cmd.Parameters.Add("@v_CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_EntryBy", Data.SqlDbType.VarChar).Value = objBll.EntryBy
        cmd.Parameters.Add("@v_UserType", Data.SqlDbType.Int).Value = objBll.UserType

        Try
            Dim objDB As New clsDBOperation
            Return objDB.executeQry(cmd, "").Tables(0).Rows(0)(0).ToString()
            'Return objDB.executeNonqry(cmd, "") '--inserting to loyaltyMainServer
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try

    End Function

    Public Sub GetRedeemItemDetails(ByVal objBll As clsBllLoyalty)
        Dim cmd As New SqlCommand("Ly_RedeemItems_GetRow")
        'cmd.Parameters.Add("@CoCd", Data.SqlDbType.Char).Value = objBll.CompanyId '--------Note:--Need to check
        cmd.Parameters.Add("@v_CustGrp", Data.SqlDbType.Char).Value = objBll.CustGrpCd
        cmd.Parameters.Add("@v_ItemCd", Data.SqlDbType.Char).Value = objBll.ItemCode

        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")

        If ds.Tables.Count > 0 Then
            objBll.ItemCode = ds.Tables(0).Rows(0)("ItemCd").ToString()
            objBll.ItemName = ds.Tables(0).Rows(0)("ItemName").ToString()
            objBll.Cost = ds.Tables(0).Rows(0)("Cost").ToString()
            objBll.Redm_Points = ds.Tables(0).Rows(0)("From").ToString()
        End If

    End Sub
    Public Function deleteUser(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_Users_Delete")
        cmd.Parameters.Add("@v_cd", Data.SqlDbType.Int).Value = objBll.Cd

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function


    Public Function checkUserExists(ByVal objBll As clsBllLoyalty) As Boolean
        Dim sql = "update Ly_CustTrans_Updation set UpdatingInterval=" & objBll.UpdatingInterval & " where compId='" & objBll.CompanyId & "'"
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(sql, "")
    End Function


    Public Function updateSalesTransUpdnInterval(ByVal objBll As clsBllLoyalty) As String
        Dim sql = "update Ly_CustTrans_Updation set UpdatingInterval=" & objBll.UpdatingInterval & " where compId='" & objBll.CompanyId & "'"
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(sql, "")
    End Function
    Public Function changePassword(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_Users_Update1")
        cmd.Parameters.Add("@v_UName", Data.SqlDbType.VarChar).Value = objBll.Username
        cmd.Parameters.Add("@v_UPWD", Data.SqlDbType.VarChar).Value = objBll.Pwd
        cmd.Parameters.Add("@v_UPWD1", Data.SqlDbType.VarChar).Value = objBll.PwdNew

        Dim objDB As New clsDBOperation
        Return objDB.executeQry(cmd, "").Tables(0).Rows(0).ItemArray(0).ToString()

    End Function

    Public Function getGroupDetails(ByVal objBll As clsBllLoyalty) As DataSet

        Dim objDB As New clsDBOperation
        'Return objDB.executeQry("SELECT  Cd,rtrim(CD)+' ('+[Des]+')' as Des FROM Groups where lvl=0 SELECT  Cd,rtrim(CD)+' ('+[Des]+')' as Des FROM Groups where lvl=1", objBll.ConnLocalSvr)
        Return objDB.executeQry("SELECT  Cd,rtrim(CD)+' ('+[Des]+')' as Des FROM Groups where lvl=0 SELECT  Cd,rtrim(CD)+' ('+[Des]+')' as Des FROM Groups where lvl=1", objBll.ConnLocalSvr)

    End Function
    Public Sub getItemDetails(ByVal objBll As clsBllLoyalty)
        Try
            Dim objDB As New clsDBOperation
            objBll.ItemName = objDB.executeQry("SELECT  Cd,SDes FROM Items where cd='" + objBll.ItemCode + "'", objBll.ConnLocalSvr).Tables(0).Rows(0)("SDes").ToString()
        Catch ex As Exception
            objBll.ItemName = clsUtilities.showMessage("itemnotfound")
        End Try
    End Sub

    Public Function deleteSalesRule(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("[Ly_SalesRulesDetail_Delete]")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Int).Value = objBll.RuleId
        cmd.Parameters.Add("@v_Srl", Data.SqlDbType.Int).Value = objBll.Srl
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function
    Public Function deleteSalesRuleHead(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_SalesRulesHead_Delete")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@v_RuleId", Data.SqlDbType.Int).Value = objBll.RuleId

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function

    Public Function update_Ly_Groups(ByVal objBll As clsBllLoyalty) As String
        Dim sql = "select * from Groups"
        Dim objDB As New clsDBOperation

        Try
            Dim dtGrp As DataTable = objDB.executeQry(sql, objBll.ConnLocalSvr).Tables(0)

            Dim sbc As New SqlBulkCopy(ConfigurationManager.ConnectionStrings("loyaltyMainServer").ConnectionString)
            sbc.DestinationTableName = "Ly_Groups"
            sbc.WriteToServer(dtGrp)
            sbc.Close()
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function GetCompany(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("Ly_Company_Getrow")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")
        If ds.Tables(0).Rows.Count > 0 Then
            objBll.CompanyId = ds.Tables(0).Rows(0)("CoCd").ToString()
            objBll.CompanyName = ds.Tables(0).Rows(0)("CoName").ToString()
            objBll.Addr1 = ds.Tables(0).Rows(0)("Add1").ToString()
            objBll.Addr2 = ds.Tables(0).Rows(0)("Add2").ToString()
            objBll.Addr3 = ds.Tables(0).Rows(0)("Add3").ToString()
            objBll.Phone = ds.Tables(0).Rows(0)("Phone").ToString()
            objBll.Fax = ds.Tables(0).Rows(0)("Fax").ToString()
            objBll.Email = ds.Tables(0).Rows(0)("Email").ToString()
            objBll.ServerName = ds.Tables(0).Rows(0)("ServerName").ToString()
            objBll.DBName = ds.Tables(0).Rows(0)("DBName").ToString()
            objBll.Username = ds.Tables(0).Rows(0)("UserName").ToString()
            objBll.Pwd = ds.Tables(0).Rows(0)("UserPwd").ToString()
            Return ds
        Else
            Return Nothing
        End If
    End Function

    Public Function setProfession(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_Profession_Update")
        cmd.Parameters.Add("@ProfessionId", Data.SqlDbType.Int).Value = objBll.ProfessionId
        cmd.Parameters.Add("@Profession", Data.SqlDbType.VarChar).Value = objBll.Profession
        cmd.Parameters.Add("@EntryBy", Data.SqlDbType.VarChar).Value = objBll.Username
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function

    Public Function deleteProfession(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_Profession_Delete")
        cmd.Parameters.Add("@ProfessionId", Data.SqlDbType.Int).Value = objBll.ProfessionId

        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function
    Public Function setCustCompany(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_CustCompany_Update")
        cmd.Parameters.Add("@custCoId", Data.SqlDbType.Char).Value = objBll.CompanyId
        cmd.Parameters.Add("@custCo", Data.SqlDbType.VarChar).Value = objBll.CompanyName
        cmd.Parameters.Add("@Addr", Data.SqlDbType.VarChar).Value = objBll.Addr1
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function
    Public Function deleteCustCompany(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_CustCompany_Delete")
        cmd.Parameters.Add("@custCoId", Data.SqlDbType.Int).Value = objBll.CompanyId
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function
    Public Function setCustLocation(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_CustAccomdnArea_Update")
        cmd.Parameters.Add("@AccAreaId", Data.SqlDbType.Int).Value = objBll.CustArea
        cmd.Parameters.Add("@AccArea", Data.SqlDbType.VarChar).Value = objBll.Area
        cmd.Parameters.Add("@Addr", Data.SqlDbType.VarChar).Value = objBll.Addr1
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function

    Public Function deleteCustLocation(ByVal objBll As clsBllLoyalty) As String
        Dim cmd As New SqlCommand("Ly_CustAccomdnArea_Delete")
        cmd.Parameters.Add("@AccAreaId", Data.SqlDbType.Int).Value = objBll.CustArea
        Dim objDB As New clsDBOperation
        Return objDB.executeNonqry(cmd, "")

    End Function
    Public Function getFailedTrans(ByVal objBll As clsBllLoyalty) As DataSet
        Dim cmd As New SqlCommand("Ly_CustTrans_Manual_GetRow")
        cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
        cmd.Parameters.Add("@CustCd", Data.SqlDbType.VarChar).Value = objBll.Cd
        cmd.Parameters.Add("@TrnDt", Data.SqlDbType.Date).Value = objBll.TrnDate
        cmd.Parameters.Add("@BillNo", Data.SqlDbType.VarChar).Value = objBll.BillNo
        cmd.Parameters.Add("@PosId", Data.SqlDbType.VarChar).Value = objBll.PosId
        cmd.Parameters.Add("@TrnLoc", Data.SqlDbType.VarChar).Value = objBll.TrnLoc

        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")
        If ds.Tables.Count > 0 Then
            Return ds
        Else
            Return Nothing
        End If
    End Function
    Public Sub getRedVoucherDetails(ByVal objBll As clsBllLoyalty)
        Dim cmd As New SqlCommand("GetRepo_Ly_RedeemTrans")
        cmd.Parameters.Add("@v_TrnId", Data.SqlDbType.Int).Value = objBll.TrnId

        Dim objDB As New clsDBOperation
        Dim ds = objDB.executeQry(cmd, "")
        If ds.Tables(0).Rows.Count > 0 Then
            objBll.TrnId = ds.Tables(0).Rows(0)("VoucherNo").ToString()

            objBll.TrnDate = Convert.ToDateTime(ds.Tables(0).Rows(0)("RedeemDt").ToString())
            objBll.Cd = ds.Tables(0).Rows(0)("CustCd").ToString()
            objBll.FName = ds.Tables(0).Rows(0)("CustName").ToString()
            objBll.CompanyId = ds.Tables(0).Rows(0)("CoCd").ToString()
            objBll.CompanyName = ds.Tables(0).Rows(0)("Company").ToString()
            objBll.Narration = ds.Tables(0).Rows(0)("Narr").ToString()
            objBll.Appr_Points = ds.Tables(0).Rows(0)("TotalPoints").ToString()
            objBll.Redm_Points = ds.Tables(0).Rows(0)("RedPoints").ToString()
            objBll.Curr = ds.Tables(0).Rows(0)("currentRed").ToString()
            objBll.RefDocNo = ds.Tables(0).Rows(0)("refDocNo").ToString()

            ' objBll.ba = ds.Tables(0).Rows(0)("BalPnts").ToString()
            objBll.ItemCode = ds.Tables(0).Rows(0)("ItemCode").ToString()
            objBll.ItemName = ds.Tables(0).Rows(0)("ItemName").ToString()
            objBll.Qty = ds.Tables(0).Rows(0)("Qty").ToString()
            objBll.Unit = ds.Tables(0).Rows(0)("Unit").ToString()
            objBll.Points = ds.Tables(0).Rows(0)("Points").ToString()
        End If
    End Sub

    Public Function updateFailedTrans(ByVal objBll As clsBllLoyalty) As String

        Try
            Dim objDB As New clsDBOperation
            Dim cmd As New SqlCommand("Ly_PosTransFailed_Update")

            cmd.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId
            cmd.Parameters.Add("@CustCd", Data.SqlDbType.VarChar).Value = objBll.Cd
            cmd.Parameters.Add("@TrnDt", Data.SqlDbType.Date).Value = objBll.TrnDate
            cmd.Parameters.Add("@BillNo", Data.SqlDbType.VarChar).Value = objBll.BillNo
            cmd.Parameters.Add("@v_PosId", Data.SqlDbType.VarChar).Value = objBll.PosId
            cmd.Parameters.Add("@TrnLoc", Data.SqlDbType.VarChar).Value = objBll.TrnLoc
            Return objDB.executeNonqry(cmd, "")

        Catch ex As Exception
            Return ex.Message
        End Try


        ''Try
        ''    Dim objDB As New clsDBOperation
        ''    Dim cmd As New SqlCommand("[Ly_CustTrans_Update_POS]")

        ''    cmd.Parameters.Add("@v_CustId", Data.SqlDbType.Char).Value = objBll.Cd
        ''    cmd.Parameters.Add("@v_BillNo", Data.SqlDbType.Int).Value = objBll.BillNo
        ''    cmd.Parameters.Add("@v_TrnPosId", Data.SqlDbType.VarChar).Value = objBll.PosId
        ''    cmd.Parameters.Add("@v_TrnDt", Data.SqlDbType.Int).Value = objBll.TrnDate
        ''    cmd.Parameters.Add("@v_Typ", Data.SqlDbType.VarChar).Value = "F"
        ''    cmd.Parameters.Add("@v_Loc", Data.SqlDbType.DateTime).Value = objBll.CompanyId

        ''Catch ex As Exception
        ''    Return ex.Message
        ''End Try

        ''Return ""

        '    '----------NOTE: needs Trans Commit-From here:------------------------------------
        '    For Each dr As DataRow In objBll.Dt.Rows
        '        Dim cmd1 As New SqlCommand("Ly_CustTrans_Update_LoyaltySvr")

        '        cmd1.Parameters.Add("@TrnId", Data.SqlDbType.Int).Value = dr.Item(0).ToString() 'NOTE---ask to pk
        '        cmd1.Parameters.Add("@CustCd", Data.SqlDbType.Char).Value = objBll.Cd
        '        cmd1.Parameters.Add("@BillNo", Data.SqlDbType.Int).Value = dr.Item(0).ToString()
        '        cmd1.Parameters.Add("@CoCd", Data.SqlDbType.VarChar).Value = objBll.CompanyId    'dr.Item(4).ToString()-------NOTE: modified(care during the handling of 'Auto transfer'(DTS))
        '        cmd1.Parameters.Add("@PosId", Data.SqlDbType.Int).Value = dr.Item(22).ToString()
        '        cmd1.Parameters.Add("@Loc", Data.SqlDbType.VarChar).Value = dr.Item(21).ToString() ' Location is not using for updation
        '        cmd1.Parameters.Add("@TrnDt", Data.SqlDbType.DateTime).Value = dr.Item(2).ToString()

        '        '--NOTE: how to get rule id --ask pk
        '        'cmd1.Parameters.Add("@RuleId", Data.SqlDbType.Int).Value = dr.Item().ToString()

        '        cmd1.Parameters.Add("@ItemCd", Data.SqlDbType.VarChar).Value = dr.Item(4).ToString()
        '        cmd1.Parameters.Add("@Qty", Data.SqlDbType.Int).Value = dr.Item(5).ToString()
        '        cmd1.Parameters.Add("@Unit", Data.SqlDbType.VarChar).Value = dr.Item(7).ToString()
        '        cmd1.Parameters.Add("@SellPr", Data.SqlDbType.Decimal).Value = dr.Item(6).ToString()
        '        cmd1.Parameters.Add("@Amt", Data.SqlDbType.Decimal).Value = dr.Item(17).ToString()

        '        '--ask pk
        '        'cmd1.Parameters.Add("@Points", Data.SqlDbType.Decimal).Value = dr.Item().ToString()

        '        '--ask pk
        '        cmd1.Parameters.Add("@Status", Data.SqlDbType.Char).Value = "N"
        '        ' dr.Item(15).ToString()

        '        '--ask pk
        '        'cmd1.Parameters.Add("@Value", Data.SqlDbType.Decimal).Value = dr.Item().ToString()
        '        cmd1.Parameters.Add("@flag", Data.SqlDbType.Char).Value = dr.Item(28).ToString()
        '        cmd1.Parameters.Add("@LyServerUpdtFlag", Data.SqlDbType.Bit).Value = True ' dr.Item(18).ToString()


        '        objDB.executeNonqry(cmd1, "")
        '    Next


        '    '----------NOTE: needs Trans Commit-To here:------------------------------------

        'Catch ex As Exception
        '    Return ex.Message
        'End Try

        'Return ""



        ''BulkCopy assumes same data structure for the table Ly_CustTrans in the source & destination
        'Try
        '    Dim objDB As New clsDBOperation
        '    Dim dtFailedtTrans As DataTable = objBll.Dt

        '    Dim sbc As New SqlBulkCopy(ConfigurationManager.ConnectionStrings("loyaltyMainServer").ConnectionString)
        '    sbc.DestinationTableName = "ly_Custtrans_02012014"
        '    sbc.WriteToServer(dtFailedtTrans)
        '    sbc.Close()
        '    Return ""
        'Catch ex As Exception
        '    Return ex.Message
        'End Try
    End Function
    'Public Function geCustTransactions(ByVal objBll As clsBllLoyalty) As DataSet
    '    Dim cmd As New SqlCommand("Ly_CustTrans_GetRow")
    '    cmd.Parameters.Add("@CustCd", Data.SqlDbType.Char).Value = objBll.Cd

    '    Dim objDB As New clsDBOperation
    '    Return objDB.executeQry(cmd, "")
    'End Function
#Region "Misc"
    'Public Sub Add(ByVal Ly_Customers As clsBllLoyalty)
    '    Dim arrParams(31) As System.Data.SqlClient.SqlParameter
    '    arrParams.SetValue(New SqlParameter("@Cd", Ly_Customers.Cd), 0)
    '    arrParams.SetValue(New SqlParameter("@Des", Ly_Customers.Des), 1)
    '    arrParams.SetValue(New SqlParameter("@FName", Ly_Customers.FName), 2)
    '    arrParams.SetValue(New SqlParameter("@LName", Ly_Customers.LName), 3)
    '    arrParams.SetValue(New SqlParameter("@MName", Ly_Customers.MName), 4)
    '    arrParams.SetValue(New SqlParameter("@Gender", Ly_Customers.Gender), 5)
    '    arrParams.SetValue(New SqlParameter("@BirthDt", Ly_Customers.BirthDt), 6)
    '    arrParams.SetValue(New SqlParameter("@Addr1", Ly_Customers.Addr1), 7)
    '    arrParams.SetValue(New SqlParameter("@Addr2", Ly_Customers.Addr2), 8)
    '    arrParams.SetValue(New SqlParameter("@Addr3", Ly_Customers.Addr3), 9)
    '    arrParams.SetValue(New SqlParameter("@Phone", Ly_Customers.Phone), 10)
    '    arrParams.SetValue(New SqlParameter("@Fax", Ly_Customers.Fax), 11)
    '    arrParams.SetValue(New SqlParameter("@Mobile", Ly_Customers.Mobile), 12)
    '    arrParams.SetValue(New SqlParameter("@Email", Ly_Customers.Email), 13)
    '    arrParams.SetValue(New SqlParameter("@UID", Ly_Customers.UID), 14)
    '    arrParams.SetValue(New SqlParameter("@Curr", Ly_Customers.Curr), 15)
    '    arrParams.SetValue(New SqlParameter("@Area", Ly_Customers.Area), 16)
    '    arrParams.SetValue(New SqlParameter("@Country", Ly_Customers.Country), 17)
    '    arrParams.SetValue(New SqlParameter("@Region", Ly_Customers.Region), 18)
    '    arrParams.SetValue(New SqlParameter("@CustGrp", Ly_Customers.CustGrp), 19)
    '    arrParams.SetValue(New SqlParameter("@CardType", Ly_Customers.CardType), 20)
    '    arrParams.SetValue(New SqlParameter("@Appr_Points", Ly_Customers.Appr_Points), 21)
    '    arrParams.SetValue(New SqlParameter("@Redm_Points", Ly_Customers.Redm_Points), 22)
    '    arrParams.SetValue(New SqlParameter("@Unappr_Points", Ly_Customers.Unappr_Points), 23)
    '    arrParams.SetValue(New SqlParameter("@Last_PurDt", Ly_Customers.Last_PurDt), 24)
    '    arrParams.SetValue(New SqlParameter("@Active", Ly_Customers.Active), 25)
    '    arrParams.SetValue(New SqlParameter("@BlackListed", Ly_Customers.BlackListed), 26)
    '    arrParams.SetValue(New SqlParameter("@EntryBy", Ly_Customers.EntryBy), 27)
    '    arrParams.SetValue(New SqlParameter("@EntryDt", Ly_Customers.EntryDt), 28)
    '    arrParams.SetValue(New SqlParameter("@EditBy", Ly_Customers.EditBy), 29)
    '    arrParams.SetValue(New SqlParameter("@EditDt", Ly_Customers.EditDt), 30)

    '    Try
    '        Dim storedProcedureName As String = "proc_Ly_CustomersInsert"
    '        Computan.Baseline.Model.DAL.Common.SqlHelper.ExecuteNonQuery(System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString, CommandType.StoredProcedure, storedProcedureName, arrParams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Public Function setCustomer(ByVal Cd As String, ByVal Des As String, ByVal FName As String, ByVal LName As String, ByVal MName As String, ByVal Gender As Boolean, ByVal BirthDt As DateTime, ByVal Addr1 As String, ByVal Addr2 As String, ByVal Addr3 As String, ByVal Phone As String, ByVal Fax As String, ByVal Mobile As String, ByVal Email As String, ByVal UID As String, ByVal Curr As String, ByVal Area As String, ByVal Country As String, ByVal Region As String, ByVal CustGrp As String, ByVal CardType As String, ByVal Active As Boolean, ByVal BlackListed As Boolean, ByVal EntryBy As String, ByVal EditBy As String) As String
#End Region
End Class
