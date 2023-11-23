
Partial Class SalesRulesDownload
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.CompanyId = Session("loginCompanyId").ToString()
            gvSalesRuleHead.DataSource = objBll.GetSalesRuleHead()
            gvSalesRuleHead.DataBind()

            If gvSalesRuleHead.Rows.Count > 0 Then
                gvSalesRuleHead.Columns(1).Visible = False
                gvSalesRuleHead.Columns(13).Visible = False
            Else
                clsUtilities.showMessage("nothing")
            End If

        End If
    End Sub

    Protected Sub gvSalesRuleHead_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSalesRuleHead.RowCommand
        Dim selRow = Convert.ToInt32(e.CommandArgument)
        Dim objBll As New clsBllLoyalty
        Dim result = ""
        objBll.RuleId = gvSalesRuleHead.Rows(selRow).Cells(1).Text.Trim()
        objBll.CompanyId = Session("loginCompanyId").ToString()
        objBll.Gv = gvSaleRuleDetail
        objBll.GridFill()

        lblHeader.Text = "Details of : " & CType(gvSalesRuleHead.Rows(selRow).FindControl("lbDes"), LinkButton).Text

        If CType(e.CommandSource, LinkButton).ID = "lbDownload" Then

            objBll.RuleId = gvSalesRuleHead.Rows(selRow).Cells(1).Text.Trim()
            objBll.CompanyId = Session("loginCompanyId").ToString()
            objBll.Des = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lbDes"), LinkButton)).Text.Trim()
            objBll.CustGrpCd = gvSalesRuleHead.Rows(selRow).Cells(13).Text.Trim()
            objBll.FromDt = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblFromDt"), Label)).Text.Trim()
            objBll.ToDt = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblToDt"), Label)).Text.Trim()
            objBll.Points = gvSalesRuleHead.Rows(selRow).Cells(6).Text.Trim()
            objBll.DiscPers = gvSalesRuleHead.Rows(selRow).Cells(7).Text.Trim()
            'objBll.Points = gvSalesRuleHead.Rows(selRow).Cells(6).Text.Trim()

            ' objBll.DiscPers = gvSalesRuleHead.Rows(selRow).Cells(7).Text.Trim()
            objBll.EntryBy = gvSalesRuleHead.Rows(selRow).Cells(8).Text.Trim()
            objBll.EntryDt = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblEntryDt"), Label)).Text.Trim()
            objBll.EditBy = gvSalesRuleHead.Rows(selRow).Cells(10).Text.Trim()
            objBll.EditDt = IIf((CType(gvSalesRuleHead.Rows(selRow).FindControl("lblEditDt"), Label)).Text.Trim() <> "", (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblEditDt"), Label)).Text.Trim(), "01/01/1900") '----Note replace '01/01/1900' will null
            objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)

            '---------Note:Apply Trans ||Commit-------------------------------- 
            objBll.UpdateSalesRulesHead_LocalMachine()

            For cnt As Integer = 0 To gvSaleRuleDetail.Rows.Count - 1
                objBll.RuleId = gvSaleRuleDetail.Rows(cnt).Cells(0).Text.Trim()
                objBll.CompanyId = gvSaleRuleDetail.Rows(cnt).Cells(1).Text.Trim()
                objBll.Srl = gvSaleRuleDetail.Rows(cnt).Cells(2).Text.Trim()

                objBll.Grp = gvSaleRuleDetail.Rows(cnt).Cells(3).Text.Trim()
                objBll.SubGrp = IIf((gvSaleRuleDetail.Rows(cnt).Cells(5).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSaleRuleDetail.Rows(cnt).Cells(5).Text.Trim())
                objBll.Category = IIf((gvSaleRuleDetail.Rows(cnt).Cells(6).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSaleRuleDetail.Rows(cnt).Cells(6).Text.Trim())
                objBll.ItemCode = IIf((gvSaleRuleDetail.Rows(cnt).Cells(9).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSaleRuleDetail.Rows(cnt).Cells(9).Text.Trim())

                objBll.Amt = gvSaleRuleDetail.Rows(cnt).Cells(11).Text
                objBll.Points = gvSaleRuleDetail.Rows(cnt).Cells(12).Text
                objBll.DiscPers = gvSaleRuleDetail.Rows(cnt).Cells(13).Text
                objBll.EntryBy = gvSaleRuleDetail.Rows(cnt).Cells(14).Text
                objBll.EntryDt = gvSaleRuleDetail.Rows(cnt).Cells(15).Text
                objBll.EditBy = IIf((gvSaleRuleDetail.Rows(cnt).Cells(16).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSaleRuleDetail.Rows(cnt).Cells(16).Text.Trim())

                '--------Note:need to  check how to insert NULL instead of ''
                If (gvSaleRuleDetail.Rows(cnt).Cells(17).Text.Trim() = "&nbsp;") Then
                    objBll.EditDt = "01/01/1900"
                Else
                    objBll.EditDt = Convert.ToDateTime(gvSaleRuleDetail.Rows(cnt).Cells(17).Text.Trim())
                End If



                result = objBll.UpdateSalesRulesDetail_LocalMachine()
            Next

            '-------------------------------------------------------------------------
            If result Is Nothing Then
                lblMsg.Text = "Sales Rule Updated Successfully..."
                lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
            Else
                lblMsg.Text = result
            End If

        End If
    End Sub

    Protected Sub lbDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
