Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Reporting.WebForms

Partial Class Reports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If (Not IsPostBack) Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty()

            If Not Session("selCustCd") Is Nothing Then txtCustNo.Text = Session("selCustCd").ToString()

            Try
                If (Request.QueryString(0).ToString() = "custTrans") Then lblCustNo.Text = "Customer Number"

                If (Request.QueryString(0).ToString() = "custTrans") Then
                    MultiView1.ActiveViewIndex = 0
                    txtDateFromCustTrans.Text = Date.Now.AddDays(-7).ToShortDateString()
                    txtDateToCustTrans.Text = Date.Now.ToShortDateString()
                    lblFrom.Visible = True
                    lblTo.Visible = True
                    txtDateFromCustTrans.Visible = True
                    txtDateToCustTrans.Visible = True
                    txtCustNo.Focus()

                ElseIf (Request.QueryString(0).ToString() = "custDtls") Then
                    MultiView1.ActiveViewIndex = 0
                    txtDateFromCustTrans.Text = Date.Now.AddDays(-7).ToShortDateString()
                    txtDateToCustTrans.Text = Date.Now.ToShortDateString()
                    lblFrom.Visible = False
                    lblTo.Visible = False
                    txtDateFromCustTrans.Visible = False
                    txtDateToCustTrans.Visible = False
                    txtCustNo.Focus()

                ElseIf (Request.QueryString("rpt").ToString() = "advdQry") Then
                    objBll.SelRpt = "advdQry"
                    objBll.Qry = Request.QueryString("qry").ToString()
                    objBll.RptVr = ReportViewer1
                    objBll.ShowReport()

                ElseIf (Request.QueryString("rpt").ToString() = "groupByReport") Then
                    objBll.SelRpt = "groupByReport"
                    objBll.Qry = Request.QueryString("qry").ToString()
                    objBll.Grp = Request.QueryString("grp").ToString()
                    objBll.RptVr = ReportViewer1
                    objBll.ShowReport()


                    'Redemption()
                ElseIf (Request.QueryString("rpt").ToString() = "redCustWise") Then
                    txtDateFrom.Text = Now.Date.AddDays(-15)
                    txtDateTo.Text = Now.Date.AddDays(1)
                    rblRedRptOptions.Visible = False
                    MultiView1.ActiveViewIndex = 1
                    objBll.SelRpt = "redCustWise"
                    'objBll.ShowReport()
                    RedemptionReport("redCustWise", "redCustWise")

                ElseIf ((Request.QueryString("rpt").ToString() = "redCompWiseCustWise") Or (Request.QueryString("rpt").ToString() = "redCompWiseSummary")) Then
                    txtDateFrom.Text = Now.Date.AddDays(-15)
                    txtDateTo.Text = Now.Date.AddDays(1)
                    rblRedRptOptions.Visible = True
                    MultiView1.ActiveViewIndex = 1
                    'objBll.ShowReport()
                    RedemptionReport(Request.QueryString("rpt").ToString(), "redCompWiseCustWise")

                ElseIf (Request.QueryString(0).ToString() = "dailyTrans") Then
                    MultiView1.ActiveViewIndex = 3

                    objBll.Ddl = ddlCompany
                    objBll.ComboFill()
                    ddlCompany.SelectedValue = Session("loginCompanyId").ToString()

                    txtDailyDt1.Text = Date.Now.ToShortDateString()
                    txtDailyDt2.Text = Date.Now.ToShortDateString()


                ElseIf (Request.QueryString("rpt").ToString() = "salesRules") Then
                    objBll.SelRpt = "salesRules"
                    objBll.CompanyId = IIf(rblSalesRules.SelectedValue = "0", Session("loginCompanyId").ToString(), "00")
                    objBll.ConnLocalSvr = ""
                    objBll.RptVr = ReportViewer1
                    MultiView1.ActiveViewIndex = 2
                    objBll.ShowReport()


                ElseIf (Request.QueryString("rpt").ToString() = "interBranch") Then
                    txtFromDtInterBr.Text = DateTime.Now.AddDays(-30).ToShortDateString()
                    txtToDtInterBr.Text = DateTime.Now.ToShortDateString()
                    MultiView1.ActiveViewIndex = 4
                    objBll.SelRpt = "interBranch"
                    InterBranchTrans(Request.QueryString("rpt").ToString())

                ElseIf (Request.QueryString("rpt").ToString() = "interBranchAmount") Then
                    MultiView1.ActiveViewIndex = 4
                    objBll.SelRpt = "interBranchAmount"
                    objBll.GetFirstRedeemDt()
                    txtFromDtInterBr.Text = objBll.TrnDate.ToShortDateString()
                    txtToDtInterBr.Text = DateTime.Now.ToShortDateString()
                    InterBranchTrans(Request.QueryString("rpt").ToString())


                ElseIf (Request.QueryString("rpt").ToString() = "redRules") Then
                    objBll.SelRpt = "redRules"
                    objBll.CompanyId = Session("loginCompanyId").ToString()
                    objBll.RptVr = ReportViewer1
                    objBll.ShowReport()

                    'objBll.Rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "")
                    'CrystalReportViewer1.ReportSource = objBll.Rpt

                End If

            Catch ex As Exception
                lblMsg.Text = ex.Message
            End Try
        End If

    End Sub
    Private Sub InterBranchTrans(detailORamount As String)
        Dim objBll As New clsBllLoyalty()

        If (detailORamount = "interBranch") Then
            objBll.SelRpt = "interBranch"
            If (txtCdInterBr.Text.Trim() = "") Then
                objBll.Cd = ""
                objBll.FromDt = Convert.ToDateTime(txtFromDtInterBr.Text.Trim())
                objBll.ToDt = Convert.ToDateTime(txtToDtInterBr.Text.Trim())
                objBll.RptVr = ReportViewer1
                objBll.ShowReport()
            Else
                objBll.Cd = txtCdInterBr.Text.Trim()
                objBll.FromDt = "01/01/1900"
                objBll.ToDt = "01/01/1900"
                objBll.RptVr = ReportViewer1
                objBll.ShowReport()
            End If
        ElseIf (detailORamount = "interBranchAmount") Then
            objBll.SelRpt = "interBranchAmount"
            objBll.Cd = txtCdInterBr.Text.Trim()
            objBll.FromDt = DateTime.Parse(txtFromDtInterBr.Text)
            objBll.ToDt = DateTime.Parse(txtToDtInterBr.Text)
            objBll.RptVr = ReportViewer1
            objBll.ShowReport()
        End If
    End Sub


    Private Sub RedemptionReport(ByVal qryStr As String, ByVal selRpt As String)

        If (qryStr = "redCustWise") Then
            Dim objBll As New clsBllLoyalty()
            objBll.SelRpt = qryStr
            objBll.CompanyId = Session("loginCompanyId").ToString()
            objBll.FromDt = txtDateFrom.Text.Trim()
            objBll.ToDt = Convert.ToDateTime(txtDateTo.Text.Trim()).AddDays(1)
            objBll.RptVr = ReportViewer1
            objBll.ShowReport()

        Else

            If (selRpt = "redCompWiseSummary" Or selRpt = "redCompWiseCustWise") Then
                Dim objBll As New clsBllLoyalty()
                objBll.SelRpt = selRpt
                objBll.CompanyId = Session("loginCompanyId").ToString()
                objBll.FromDt = txtDateFrom.Text.Trim()
                objBll.ToDt = Convert.ToDateTime(txtDateTo.Text.Trim()).AddDays(1)
                objBll.RptVr = ReportViewer1
                objBll.ShowReport()
            End If
        End If



    End Sub


    Protected Sub btnShowReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowReport.Click

        '-------------NOTE: validate customer
        'checkCustomerExists()

        If (Request.QueryString(0).ToString() = "custDtls") Then
            Dim objBll As New clsBllLoyalty()
            objBll.SelRpt = Request.QueryString(0).ToString()

            If txtCustNo.Text.Trim() = "" Then
                txtCustNo.Text = "00"
            End If
            'objBll.Qry = "WHERE CD=" & txtCustNo.Text.Trim() & " or Mobile=" & txtCustNo.Text.Trim()
            objBll.Qry = txtCustNo.Text.Trim()
            objBll.Cd = txtCustNo.Text.Trim()
            objBll.FromDt = Convert.ToDateTime(txtDateFromCustTrans.Text.Trim())
            objBll.ToDt = Convert.ToDateTime(txtDateToCustTrans.Text.Trim())
            objBll.RptVr = ReportViewer1
            objBll.ShowReport()
        ElseIf (Request.QueryString(0).ToString() = "custTrans") Then
            Dim objBll As New clsBllLoyalty()
            objBll.SelRpt = Request.QueryString(0).ToString()
            objBll.Qry = "WHERE CD=" & txtCustNo.Text.Trim() & " or Mobile=" & txtCustNo.Text.Trim()
            'objBll.Qry = txtCustNo.Text.Trim()
            objBll.Cd = txtCustNo.Text.Trim()
            objBll.FromDt = Convert.ToDateTime(txtDateFromCustTrans.Text.Trim())
            objBll.ToDt = Convert.ToDateTime(txtDateToCustTrans.Text.Trim())
            objBll.RptVr = ReportViewer1
            objBll.ShowReport()
        End If


    End Sub

    Protected Sub btnShowReportRedemption_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowReportRedemption.Click
        RedemptionReport(Request.QueryString("rpt").ToString(), rblRedRptOptions.SelectedValue)
    End Sub

   
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    '    rpt.Load(Server.MapPath("") & "\test1.rpt")
    '    CrystalReportViewer1.ReportSource = rpt

    'End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    '    rpt.Load(Server.MapPath("") & "\Reports\test.rpt")
    '    CrystalReportViewer1.ReportSource = rpt
    'End Sub

#Region "OldData"
    '------------------------------------------------------------------------------------------
    'Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    'Dim objBll As New clsBllLoyalty()

    'Try
    '    If (Request.QueryString(0).ToString() = "custTrans") Then lblCustNo.Text = "Customer Number"

    '    If (Request.QueryString(0).ToString() = "custTrans" Or Request.QueryString(0).ToString() = "custDtls") Then
    '        txtCustNo.Focus()
    '        If txtCustNo.Text.Trim() = "" Then
    '            MultiView1.ActiveViewIndex = 0
    '        Else 'Currently not in use, In future can make cust report with a query string
    '            MultiView1.ActiveViewIndex = 0
    '            objBll.SelRpt = "custDtls"
    '            objBll.Qry = "WHERE CD=" & txtCustNo.Text.Trim()

    '            objBll.Rpt = objBll.ShowReport()


    '            'ReportViewer1.ProcessingMode = ProcessingMode.Local
    '            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")
    '            'Dim dsCustomers As Data.DataSet = objBll.ShowReport_RDLC()
    '            'Dim datasource As New ReportDataSource("Customers", dsCustomers.Tables(0))
    '            'ReportViewer1.LocalReport.DataSources.Clear()
    '            'ReportViewer1.LocalReport.DataSources.Add(datasource)


    '            'objBll.Rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "")
    '            ' CrystalReportViewer1.ReportSource = objBll.Rpt
    '        End If

    '    ElseIf (Request.QueryString("rpt").ToString() = "advdQry") Then
    '        objBll.SelRpt = "advdQry"
    '        objBll.Qry = Request.QueryString("qry").ToString()

    '        objBll.Rpt = objBll.ShowReport()

    '        'objBll.Rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "")
    '        'rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    '        'CrystalReportViewer1.ReportSource = objBll.Rpt

    '    ElseIf (Request.QueryString("rpt").ToString() = "groupByReport") Then
    '        objBll.SelRpt = "groupByReport"
    '        objBll.Qry = Request.QueryString("qry").ToString()
    '        objBll.Grp = Request.QueryString("grp").ToString()
    '        objBll.Rpt = objBll.ShowReport()

    '        ' objBll.Rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "")
    '        'CrystalReportViewer1.ReportSource = objBll.Rpt

    '        'ElseIf (Request.QueryString("rpt").ToString() = "custCardType") Then
    '        '    objBll.SelRpt = "custCardType"
    '        '    objBll.Qry = Request.QueryString("qry").ToString()

    '        '    objBll.Rpt = objBll.ShowReport()
    '        '    CrystalReportViewer1.ReportSource = objBll.Rpt

    '        ' Redemption
    '    ElseIf (Request.QueryString("rpt").ToString() = "redCustWise") Then
    '        txtDateFrom.Text = Now.Date.AddDays(-15)
    '        txtDateTo.Text = Now.Date.AddDays(1)
    '        rblRedRptOptions.Visible = False
    '        RedemptionReport("redCustWise")


    '    ElseIf ((Request.QueryString("rpt").ToString() = "redCompWiseCustWise") Or (Request.QueryString("rpt").ToString() = "redCompWiseSummary")) Then
    '        txtDateFrom.Text = Now.Date.AddDays(-15)
    '        txtDateTo.Text = Now.Date.AddDays(1)
    '        rblRedRptOptions.Visible = Trued
    '        RedemptionReport(Request.QueryString("rpt").ToString())

    '    ElseIf (Request.QueryString("rpt").ToString() = "salesRules") Then
    '        objBll.SelRpt = "salesRules"
    '        objBll.CompanyId = Session("loginCompanyId").ToString()
    '        objBll.Rpt = objBll.ShowReport()

    '        ' objBll.Rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "")
    '        'CrystalReportViewer1.ReportSource = objBll.Rpt

    '    ElseIf (Request.QueryString("rpt").ToString() = "redRules") Then
    '        objBll.SelRpt = "redRules"
    '        objBll.CompanyId = Session("loginCompanyId").ToString()
    '        objBll.Rpt = objBll.ShowReport()

    '        'objBll.Rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "")
    '        'CrystalReportViewer1.ReportSource = objBll.Rpt

    '    End If
    'Catch ex As Exception
    '    lblMsg.Text = ex.Message
    'End Try

#End Region

    Protected Sub btnShowSalesRules_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowSalesRules.Click
        If (Request.QueryString("rpt").ToString() = "salesRules") Then
            Dim objBll As New clsBllLoyalty()
            objBll.SelRpt = "salesRules"
            objBll.CompanyId = IIf(rblSalesRules.SelectedValue = "0", Session("loginCompanyId").ToString(), "00")
            'objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)
            objBll.RptVr = ReportViewer1
            objBll.ShowReport()
        End If

    End Sub

    Protected Sub btnDailyTrans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDailyTrans.Click

        If (Request.QueryString(0).ToString() = "dailyTrans") Then
            Dim objBll As New clsBllLoyalty()
            objBll.SelRpt = Request.QueryString(0).ToString()
            'objBll.Qry = "WHERE CD=" & txtCus       tNo.Text.Trim() & " or Mobile=" & txtCustNo.Text.Trim()
            objBll.CompanyId = ddlCompany.SelectedValue.ToString()
            objBll.FromDt = Convert.ToDateTime(txtDailyDt1.Text.Trim())
            objBll.ToDt = Convert.ToDateTime(txtDailyDt2.Text.Trim())
            objBll.UserType = rdbSummaryDetail.SelectedValue


            objBll.RptVr = ReportViewer1
            objBll.ShowReport()
        End If
    End Sub

   
    Protected Sub btnInterBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInterBranch.Click
        InterBranchTrans(Request.QueryString("rpt").ToString())
        'If (Request.QueryString(0).ToString() = "interBranch") Then
        '    Dim objBll As New clsBllLoyalty()

        '    objBll.Cd = txtCdInterBr.Text.Trim() ' For future use
        '    objBll.FromDt = Convert.ToDateTime(txtFromDtInterBr.Text.Trim())
        '    objBll.ToDt = Convert.ToDateTime(txtToDtInterBr.Text.Trim())
        '    objBll.RptVr = ReportViewer1
        '    objBll.ShowReport()
        'End If
    End Sub
End Class
