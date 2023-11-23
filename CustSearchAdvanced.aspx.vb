
Partial Class CustomerReports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If (Not IsPostBack) Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty()

            objBll.Ddl = ddlCountryGrpBy
            objBll.ComboFill()

            objBll.Ddl = ddlCustGrpGrpBy
            objBll.ComboFill()

            'objBll.Ddl = ddlReligionGrpBy
            'objBll.ComboFill()

            objBll.Ddl = ddlCompanyAll
            objBll.ComboFill()

            objBll.Ddl = ddlAccAreaGrpBy
            objBll.ComboFill()


        End If
    End Sub
    Protected Sub btnShowReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        Dim qry = "WHERE "

        If txtCardNo.Text.Trim() <> "" Then qry += "(CD ='" & txtCardNo.Text.Trim() & "'  or Mobile = '" & txtCardNo.Text.Trim() & "')  and "
        If rbListGender.SelectedValue <> "All" Then qry += " Gender=" + rbListGender.SelectedValue & " and "
        If txtPurDt.Text.Trim() <> "" Then qry += " convert(varchar(10),EntryDt,101)='" & Convert.ToDateTime(txtPurDt.Text.Trim()).ToString("MM/dd/yyyy") & "' and "

        'Top Points Earned Customers'
        'If chkEarnedPoints.Checked Then qry += " "   'And rbNationality.Checked = False And rbCardType.Checked = False And rbCustCompany.Checked = False And rbCustAccmnArea.Checked = False Then qry = "" : Response.Redirect("Reports.aspx?rpt=advdQry&qry=" + qry)

        If chkCardNotIssued.Checked Then qry += " CardIssued=0 and "
        If chkActive.Checked Then qry += " Active=1 and "
        If chkBL.Checked Then qry += " BlackListed=1 and "
        If txtPointsFrom.Text.Trim() <> "" Then qry += " Appr.Points>=" & Convert.ToInt32(txtPointsFrom.Text.Trim()) & " and "
        If txtPointsTo.Text.Trim() <> "" Then qry += " Appr.Points <" & Convert.ToInt32(txtPointsTo.Text.Trim()) & " and "

        'If (qry <> "WHERE ") Then qry += " and "

        If rbNationality.Checked = True Then
            If ddlCountryGrpBy.SelectedIndex > 0 Then qry += " Country=" & ddlCountryGrpBy.SelectedValue
            If qry = "WHERE " Then qry = ""
            Response.Redirect("Reports.aspx?rpt=groupByReport&grp=Nationality&qry=" + qry)
        End If

        If rbCardType.Checked = True Then
            If ddlCustGrpGrpBy.SelectedIndex > 0 Then qry += " CustGrp=" & ddlCustGrpGrpBy.SelectedValue
            If qry = "WHERE " Then qry = ""
            Response.Redirect("Reports.aspx?rpt=groupByReport&grp=Card Type&qry=" + qry)
        End If

        If rbCustCompany.Checked = True Then
            If ddlCompanyAll.SelectedIndex > 0 Then qry += " CoCd=" & ddlCompanyAll.SelectedValue
            If qry = "WHERE " Then qry = ""
            Response.Redirect("Reports.aspx?rpt=groupByReport&grp=Company&qry=" + qry)
        End If

        If rbCustAccmnArea.Checked = True Then
            If ddlAccAreaGrpBy.SelectedIndex > 0 Then qry += " AreaCd=" & ddlAccAreaGrpBy.SelectedValue
            If qry = "WHERE " Then qry = ""
            Response.Redirect("Reports.aspx?rpt=groupByReport&grp=Area&qry=" + qry)
        End If

        If rbReligion.Checked = True Then
            If ddlReligionGrpBy.SelectedIndex > 0 Then qry += " Religion=" & ddlReligionGrpBy.SelectedValue
            If qry = "WHERE " Then qry = ""
            Response.Redirect("Reports.aspx?rpt=groupByReport&grp=Religion&qry=" + qry)
        End If

        If qry = "WHERE " Then qry = "" Else qry = qry.Substring(0, qry.Length - 4)
        Response.Redirect("Reports.aspx?rpt=advdQry&qry=" + qry)
    End Sub

    Protected Sub rbNationality_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNationality.CheckedChanged
        ddlCountryGrpBy.Enabled = True

        ddlCustGrpGrpBy.Enabled = False
        ddlCompanyAll.Enabled = False

        ddlAccAreaGrpBy.Enabled = False
        ddlReligionGrpBy.Enabled = False
    End Sub

    Protected Sub rnCardType_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCardType.CheckedChanged
        ddlCustGrpGrpBy.Enabled = True

        ddlCountryGrpBy.Enabled = False
        ddlCompanyAll.Enabled = False
        ddlAccAreaGrpBy.Enabled = False
        ddlReligionGrpBy.Enabled = False
    End Sub

    Protected Sub rbCustCompany_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCustCompany.CheckedChanged
        ddlCompanyAll.Enabled = True

        ddlCountryGrpBy.Enabled = False
        ddlCustGrpGrpBy.Enabled = False
        ddlAccAreaGrpBy.Enabled = False
        ddlReligionGrpBy.Enabled = False
    End Sub

    Protected Sub rbCustAccmnArea_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCustAccmnArea.CheckedChanged
        ddlAccAreaGrpBy.Enabled = True

        ddlCountryGrpBy.Enabled = False
        ddlCustGrpGrpBy.Enabled = False
        ddlCompanyAll.Enabled = False
        ddlReligionGrpBy.Enabled = False
    End Sub

    Protected Sub rbReligion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbReligion.CheckedChanged
        ddlReligionGrpBy.Enabled = True

        ddlCountryGrpBy.Enabled = False
        ddlCustGrpGrpBy.Enabled = False
        ddlCompanyAll.Enabled = False
        ddlAccAreaGrpBy.Enabled = False
    End Sub
End Class
