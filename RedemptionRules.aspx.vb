
Partial Class RedemptionRules
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")


        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty()

            objBll.Ddl = ddlCustGrp
            objBll.ComboFill()

            BindGridRuleHead()
        End If
    End Sub
    Private Sub BindGridRuleHead()
        Dim objBll As New clsBllLoyalty()
        objBll.CompanyId = "00"
        gvRedRuleHead.DataSource = objBll.GetRedRulesHead()
        gvRedRuleHead.DataBind()

        If (gvRedRuleHead.Rows.Count > 0) Then
            ' gvSalesRuleHead.Columns(1).Visible = True
            lblRuleId.Text = Convert.ToInt32(gvRedRuleHead.Rows(0).Cells(1).Text.Trim()) + 1
        Else
            lblRuleId.Text = "1"
        End If
        'gvSalesRuleHead.Columns(1).Visible = False
    End Sub

    Protected Sub btnAddNew_Click(sender As Object, e As System.EventArgs) Handles btnAddNew.Click
        pnlRedRule.Visible = True
        txtDes.Focus()
    End Sub

    'Protected Sub gvRedRuleHead_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRedRuleHead.RowCommand
    '    Dim selRow = Convert.ToInt32(e.CommandArgument)
    '    Dim objBll As New clsBllLoyalty
    '    Dim result = ""
    '    objBll.RuleId = gvRedRuleHead.Rows(selRow).Cells(1).Text.Trim()
    '    objBll.CompanyId = "00"
    '    objBll.Gv = gvRedRDetail
    '    objBll.GridFill()

    '    ViewState.Add("selRuleId", gvRedRuleHead.Rows(selRow).Cells(1).Text.Trim())
    '    gvRedRuleHead.Rows(selRow).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
    'End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        If (txtDes.Text.Trim() <> "" And ddlCustGrp.SelectedIndex > 0 And txtPoints.Text.Trim() <> "" And txtItem.Text.Trim() <> "") Then
            'If (ValidateRedeemItemDetails()) Then
            Dim objBll As New clsBllLoyalty()
            objBll.RuleId = Convert.ToInt32(lblRuleId.Text.Trim())
            objBll.CompanyId = "00"
            objBll.Des = txtDes.Text.Trim()
            objBll.CustGrpCd = ddlCustGrp.SelectedValue
            objBll.Points = txtPoints.Text.Trim()
            objBll.EntryBy = Session("loginUsername")
            objBll.ItemCode = txtItem.Text.Trim()

            Dim result = objBll.SetRedRules()
            If result Is Nothing Then
                lblMsg.Text = clsUtilities.showMessage("saved")

                BindGridRuleHead()

                txtDes.Text = ""
                txtPoints.Text = ""
                txtItem.Text = ""
                txtItemDes.Text = ""
            Else
                lblMsg.Text = "ERROR: " + result
            End If
            lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
            txtDes.Focus()
        End If
        
    End Sub


    Private Function ValidateRedeemItemDetails() As Boolean
        If (txtDes.Text.Trim() <> "" And ddlCustGrp.SelectedIndex > 0 And txtPoints.Text.Trim() <> "" And txtItem.Text.Trim() <> "") Then
            Dim objBll As New clsBllLoyalty
            'objBll.CompanyId = Session("loginCompanyId").ToString()
            objBll.CustGrpCd = ddlCustGrp.SelectedValue
            objBll.ItemCode = txtItem.Text.Trim()


            objBll.GetRedeemItemDetails()
            If objBll.ItemName = "" Then
                txtItem.Text = clsUtilities.showMessage("chkItemOrCust")
                txtItem.BackColor = Drawing.Color.Red
                Return False
            Else
                txtItem.Text = objBll.ItemName
                txtItem.BackColor = Drawing.Color.White
                Return True
            End If
        End If

        Return False
    End Function
   
    Protected Sub gvRedRuleHead_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRedRuleHead.RowCommand
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
            objBll.EntryDt = CType(gvRedRuleHead.Rows(selRow).FindControl("lblEntryDt"), Label).Text     'IIf(gvRedRuleHead.Rows(selRow).Cells(9).Text.Trim() = "", "01/01/1990", gvRedRuleHead.Rows(selRow).Cells(9).Text.Trim())
            objBll.EditBy = gvRedRuleHead.Rows(selRow).Cells(10).Text.Trim()

            objBll.EditDt = IIf(CType(gvRedRuleHead.Rows(selRow).FindControl("lblEditDt"), Label).Text = "", "01/01/1990", CType(gvRedRuleHead.Rows(selRow).FindControl("lblEditDt"), Label).Text)     'IIf(gvRedRuleHead.Rows(selRow).Cells(11).Text.Trim()="","01/01/1990",gvRedRuleHead.Rows(selRow).Cells(11).Text.Trim())
            'If (gvRedRuleHead.Rows(selRow).Cells(11).Text.Trim() <> "&nbsp;") Then objBll.EditDt = gvRedRuleHead.Rows(selRow).Cells(11).Text.Trim()
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

  
End Class
