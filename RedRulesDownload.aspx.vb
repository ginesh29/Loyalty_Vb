
Partial Class RedRulesDownload
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")
        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.CompanyId = "00"
            gvRedRuleHead.DataSource = objBll.GetRedRulesHead()
            gvRedRuleHead.DataBind()

            If gvRedRuleHead.Rows.Count > 0 Then
                'gvRedRuleHead.Columns(1).Visible = False
                'gvRedRuleHead.Columns(13).Visible = False
            Else
                clsUtilities.showMessage("nothing")
            End If
        End If
    End Sub

    Protected Sub gvRedRuleHead_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRedRuleHead.RowCommand
        Dim selRow = Convert.ToInt32(e.CommandArgument) - 1
        Dim objBll As New clsBllLoyalty
        If CType(e.CommandSource, LinkButton).ID = "lnkDownload" Then

            objBll.RuleId = gvRedRuleHead.Rows(selRow).Cells(1).Text.Trim()
            objBll.CompanyId = Session("loginCompanyId").ToString()
            objBll.Des = gvRedRuleHead.Rows(selRow).Cells(2).Text.Trim()
            objBll.CustGrpCd = gvRedRuleHead.Rows(selRow).Cells(3).Text.Trim() 
            objBll.Points = gvRedRuleHead.Rows(selRow).Cells(5).Text.Trim()
            ' objBll.PointsTo = 0
            objBll.EntryBy = gvRedRuleHead.Rows(selRow).Cells(8).Text.Trim()
            objBll.EntryDt = Convert.ToDateTime(gvRedRuleHead.Rows(selRow).Cells(9).Text.Trim())
            objBll.EditBy = gvRedRuleHead.Rows(selRow).Cells(10).Text.Trim()
            If (gvRedRuleHead.Rows(selRow).Cells(11).Text.Trim() <> "&nbsp;") Then objBll.EditDt = Convert.ToDateTime(gvRedRuleHead.Rows(selRow).Cells(11).Text.Trim())
            objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)

            '---------Note:Apply Trans ||Commit-------------------------------- 
            Dim result = objBll.UpdateRedRulesHead_LocalMachine()
            If result Is Nothing Then
                objBll.Srl = 1
                objBll.ItemCode = gvRedRuleHead.Rows(selRow).Cells(6).Text.Trim()  ' IIf((gvRedRuleHead.Rows(selRow).Cells(6).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvRedRuleHead.Rows(selRow).Cells(6).Text.Trim())
                objBll.ItemName = gvRedRuleHead.Rows(selRow).Cells(7).Text.Trim()

                result = objBll.UpdateRedRulesDetail_LocalMachine()
            End If
            
            If result Is Nothing Then
                lblMsg.Text = "Redemption Rule Updated Successfully..."
                lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
            Else
                lblMsg.Text = result
            End If

        End If
    End Sub

    Protected Sub gvRedRuleHead_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRedRuleHead.SelectedIndexChanged

    End Sub

    Protected Sub lnkDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
