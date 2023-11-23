
Partial Class SalesRules
    Inherits System.Web.UI.Page

    Dim dtSalesRules As Data.DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty()

            objBll.Ddl = ddlCustGrp
            objBll.ComboFill()

            objBll.CompanyId = "01" 'Session("loginCompanyId").ToString()
            gvSalesRuleHead.DataSource = objBll.GetSalesRuleHead()
            gvSalesRuleHead.DataBind()

            If (gvSalesRuleHead.Rows.Count > 0) Then
                lblRuleId.Text = Convert.ToInt32(gvSalesRuleHead.Rows(gvSalesRuleHead.Rows.Count - 1).Cells(1).Text.Trim()) + 1
            Else
                lblRuleId.Text = "1"
            End If
            'gvSalesRuleHead.Columns(1).Visible = False



        End If
    End Sub
    'Private Sub CreateTable()
    '    Dim dtSalesRules As New Data.DataTable

    '    dtSalesRules.Columns.Add("No", GetType(Integer))
    '    dtSalesRules.Columns.Add("Group", GetType(Char))
    '    dtSalesRules.Columns.Add("SubGroup", GetType(Char))
    '    dtSalesRules.Columns.Add("Category", GetType(Char))
    '    dtSalesRules.Columns.Add("Point", GetType(Char))
    '    dtSalesRules.Columns.Add("Item", GetType(String))
    '    dtSalesRules.Columns.Add("Discount", GetType(Decimal))

    '    Dim dr As Data.DataRow = dtSalesRules.NewRow
    '    dr(0) = 1
    '    dtSalesRules.Rows.Add(dr)
    '    ViewState.Add("dtSalesRules", dtSalesRules)

    '    gvSRDetail.DataSource = dtSalesRules
    '    gvSRDetail.DataBind()
    'End Sub
   
    Private Sub SaveDetails(ByVal ruleId As Integer, ByVal slNo As String)
        Dim objBll As New clsBllLoyalty()
        objBll.RuleId = ruleId
        objBll.CompanyId = "00" ' Session("loginCompanyId").ToString()
        objBll.Srl = 0 'getting the 'SlNo' from SP   'IIf(slNo <> "", slNo, (gvSRDetail.Rows.Count + 1))
        objBll.Grp = ddlGroups.SelectedValue.Trim()
        objBll.SubGrp = ddlSubGrp.SelectedValue.Trim()
        objBll.Category = txtCategory.Text.Trim().Trim()
        objBll.ItemCode = txtItem.Text.Trim().Trim()

        If (txtValue.Text.Trim() <> "") Then
            objBll.Amt = Convert.ToDecimal(txtValue.Text.Trim())
        Else
            objBll.Amt = 0
        End If

        If (txtPointDetail.Text.Trim() <> "") Then
            objBll.Points = Convert.ToDecimal(txtPointDetail.Text.Trim())
        Else
            objBll.Points = 0
        End If


        objBll.EntryBy = Session("loginUsername").ToString()

        If (txtDiscountDetail.Text.Trim() <> "") Then
            objBll.DiscPers = Convert.ToDecimal(txtDiscountDetail.Text.Trim())
        Else
            objBll.DiscPers = 0
        End If


        objBll.SetSalesRulesDetail()
    End Sub

    Protected Sub btnAddNewSalesRule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNewSalesRule.Click
        FillGroupsSubGroups()
    End Sub
    Private Sub FillGroupsSubGroups()
        Dim objBll As New clsBllLoyalty()
        objBll.ConnLocalSvr = clsUtilities.CreateConnString("01") 'Loading data from 'MAIN MADINA2 SERVER' b'se All the items are defining in this server
        Dim dsGroups = objBll.GetGroupDetails()

        If (dsGroups.Tables.Count > 0) Then
            ddlGroups.Items.Add("---Select One---")
            ddlGroups.Items(0).Value = "0"

            Dim li As ListItem
            For cnt As Integer = 0 To dsGroups.Tables(0).Rows.Count - 1
                li = New ListItem(dsGroups.Tables(0).Rows(cnt)("Des").ToString(), dsGroups.Tables(0).Rows(cnt)("Cd").ToString())
                ddlGroups.Items.Add(li)
            Next

            ddlSubGrp.Items.Add("---Select One---")
            ddlSubGrp.Items(0).Value = "0"
            For cnt As Integer = 0 To dsGroups.Tables(1).Rows.Count - 1
                li = New ListItem(dsGroups.Tables(1).Rows(cnt)("Des").ToString(), dsGroups.Tables(1).Rows(cnt)("Cd").ToString())
                ddlSubGrp.Items.Add(li)
            Next

            pnlNewSRule.Visible = True
            btnAddNewSalesRule.Visible = False
            gvSalesRuleHead.Visible = False
            gvSRDetail.Visible = False
            lblHeader.Text = "Sales Rule --> New Sales Rule"
            lblMsg.Text = ""
            lblHeaderDtl.Text = ""
            txtDes.Focus()
        Else
            lblMsg.Text = clsUtilities.showMessage("remoteConProblem")
        End If


    End Sub


    Protected Sub txtDiscountDetail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub txtToDt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvSalesRuleHead_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSalesRuleHead.RowCommand
        If e.CommandName <> "Delete" And e.CommandName <> "Select" Then
            lblMsg.Text = ""
            Dim selRow = Convert.ToInt32(e.CommandArgument)
            Dim objBll As New clsBllLoyalty
            Dim result = ""
            objBll.RuleId = gvSalesRuleHead.Rows(selRow).Cells(1).Text.Trim()
            objBll.CompanyId = "00" 'Session("loginCompanyId").ToString()
            objBll.Gv = gvSRDetail
            objBll.GridFill()
            gvSRDetail.Visible = True
            If gvSRDetail.Rows.Count > 0 Then
                lblHeaderDtl.Text = "Details of : " & CType(gvSalesRuleHead.Rows(selRow).FindControl("lbDes"), LinkButton).Text
            Else
                lblHeaderDtl.Text = ""
            End If


            ViewState.Add("selRuleId", gvSalesRuleHead.Rows(selRow).Cells(1).Text.Trim())
            gvSalesRuleHead.Rows(selRow).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")

            If e.CommandName = "Download" Then

                objBll.RuleId = gvSalesRuleHead.Rows(selRow).Cells(1).Text.Trim()
                objBll.CompanyId = Session("loginCompanyId").ToString()
                objBll.Des = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lbDes"), LinkButton)).Text.Trim()
                objBll.CustGrpCd = gvSalesRuleHead.Rows(selRow).Cells(12).Text.Trim()
                objBll.FromDt = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblFromDt"), Label)).Text.Trim()
                objBll.ToDt = (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblToDt"), Label)).Text.Trim()
                objBll.Points = gvSalesRuleHead.Rows(selRow).Cells(6).Text.Trim()
                objBll.DiscPers = gvSalesRuleHead.Rows(selRow).Cells(7).Text.Trim()
                'objBll.Points = gvSalesRuleHead.Rows(selRow).Cells(6).Text.Trim()

                ' objBll.DiscPers = gvSalesRuleHead.Rows(selRow).Cells(7).Text.Trim()
                objBll.EntryBy = gvSalesRuleHead.Rows(selRow).Cells(8).Text.Trim()
                objBll.EntryDt = Convert.ToDateTime((CType(gvSalesRuleHead.Rows(selRow).FindControl("lblEntryDt"), Label)).Text.Trim())
                objBll.EditBy = gvSalesRuleHead.Rows(selRow).Cells(10).Text.Trim()
                objBll.EditDt = IIf((CType(gvSalesRuleHead.Rows(selRow).FindControl("lblEditDt"), Label)).Text.Trim() <> "", (CType(gvSalesRuleHead.Rows(selRow).FindControl("lblEditDt"), Label)).Text.Trim(), "01/01/1900") '----Note replace '01/01/1900' will null
                objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)

                '---------Note:Apply Trans ||Commit-------------------------------- 
                objBll.UpdateSalesRulesHead_LocalMachine()

                For cnt As Integer = 0 To gvSRDetail.Rows.Count - 1
                    objBll.RuleId = gvSRDetail.Rows(cnt).Cells(0).Text.Trim()
                    objBll.CompanyId = Session("loginCompanyId").ToString()
                    objBll.Srl = CType(gvSRDetail.Rows(cnt).FindControl("lblSlNo"), Label).Text.Trim()
                    objBll.Grp = gvSRDetail.Rows(cnt).Cells(2).Text.Trim()

                    objBll.SubGrp = IIf((gvSRDetail.Rows(cnt).Cells(4).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSRDetail.Rows(cnt).Cells(4).Text.Trim())
                    objBll.Category = IIf((gvSRDetail.Rows(cnt).Cells(6).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSRDetail.Rows(cnt).Cells(6).Text.Trim())
                    objBll.ItemCode = IIf((gvSRDetail.Rows(cnt).Cells(8).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSRDetail.Rows(cnt).Cells(8).Text.Trim())

                    objBll.Amt = gvSRDetail.Rows(cnt).Cells(10).Text
                    objBll.Points = gvSRDetail.Rows(cnt).Cells(11).Text
                    objBll.DiscPers = gvSRDetail.Rows(cnt).Cells(12).Text

                    'If (gvSRDetail.Rows(cnt).Cells(12).Text <> "") Then

                    'Else
                    'objBll.DiscPers = 0
                    'End If

            ' objBll.DiscPers = gvSRDetail.Rows(cnt).Cells(13).Text
                    objBll.EntryBy = gvSRDetail.Rows(cnt).Cells(13).Text
                    objBll.EntryDt = gvSRDetail.Rows(cnt).Cells(14).Text
                    objBll.EditBy = IIf((gvSRDetail.Rows(cnt).Cells(15).Text.Trim() = "&nbsp;"), DBNull.Value.ToString(), gvSRDetail.Rows(cnt).Cells(15).Text.Trim())

            '--------Note:need to  check how to insert NULL instead of ''
                    If (gvSRDetail.Rows(cnt).Cells(16).Text.Trim() = "&nbsp;") Then
                        objBll.EditDt = "01/01/1900"
                    Else
                        objBll.EditDt = Convert.ToDateTime(gvSRDetail.Rows(cnt).Cells(16).Text.Trim())
                    End If



            result = objBll.UpdateSalesRulesDetail_LocalMachine()
                Next

                '-------------------------------------------------------------------------
                If result Is Nothing Then
                    lblMsg.Text = "Sales Rule Updated to your 'Local Server'..."
                    lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
                Else
                    lblMsg.Text = result
                End If

            End If
        End If

    End Sub

    
    Private Sub FillGridDetails()
        Dim objBll As New clsBllLoyalty
        objBll.RuleId = ViewState("selRuleId")
        objBll.CompanyId = "00" ' Session("loginCompanyId").ToString()
        objBll.Gv = gvSRDetail
        objBll.GridFill()

       
    End Sub
    Protected Sub gvSRDetail_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvSRDetail.RowUpdating
        SaveDetails(ViewState("selRuleId"), CType(gvSRDetail.Rows(e.RowIndex).FindControl("txtSlNoEdit"), TextBox).Text)
        lblHeader.Text = clsUtilities.showMessage("updated")
        'Dim aa As System.Collections.Specialized.IOrderedDictionary = e.OldValues


    End Sub
   
    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        If (txtDes.Text.Trim() <> "" And (ddlCustGrp.SelectedIndex > 0 Or ddlCustGrp.SelectedItem.Text <> "--Select One--") And txtPoints.Text.Trim() <> "" And txtfromDt.Text.Trim() <> "" And txtToDt.Text.Trim() <> "") Then
            gvSRDetail.Visible = True
            Dim objBll As New clsBllLoyalty()

            If (pnlSalesRuleHead.Enabled = True) Then
                objBll.RuleId = Convert.ToInt32(lblRuleId.Text.Trim())
                'objBll.CompanyId = "00" 'Session("loginCompanyId").ToString()
                objBll.CompanyId = Session("loginCompanyId").ToString()
                objBll.Des = txtDes.Text.Trim()
                objBll.CustGrp = ddlCustGrp.SelectedValue
                objBll.FromDt = Convert.ToDateTime(txtfromDt.Text.Trim())
                objBll.ToDt = Convert.ToDateTime(txtToDt.Text.Trim())
                objBll.Points = Val(txtPoints.Text.Trim())
                objBll.DiscPers = Val(txtDiscount.Text.Trim())
                objBll.EntryBy = Session("loginUsername").ToString()

                objBll.SetSalesRulesHead()
                pnlSalesRuleHead.Enabled = False
                ViewState.Add("selRuleId", lblRuleId.Text.Trim())
            End If

            If (ddlGroups.SelectedIndex > 0 Or txtItem.Text.Trim() <> "") And txtValue.Text.Trim() <> "" Then
                SaveDetails(Convert.ToInt32(lblRuleId.Text.Trim()), "")
                FillGridDetails()
            Else
                lblMsg.Text = clsUtilities.showMessage("invalidEntry")
            End If


            ddlGroups.SelectedIndex = 0
            ddlSubGrp.SelectedIndex = 0
            txtCategory.Text = ""
            txtPointDetail.Text = ""
            txtItem.Text = ""
            txtItemDes.Text = ""
            txtDiscountDetail.Text = ""
            txtValue.Text = ""
            ddlGroups.Focus()
        End If
    End Sub

    Protected Sub btnBrowse_Click(sender As Object, e As System.EventArgs) Handles btnBrowse.Click
        If txtItem.Text.Trim() <> "" Then
            Dim objBll As New clsBllLoyalty()
            objBll.ItemCode = txtItem.Text.Trim()
            objBll.ConnLocalSvr = clsUtilities.CreateConnString("01") 'Loading data from 'MAIN MADINA SERVER' b'se All the items are defining in this server
            objBll.GetItemDetails()
            txtItemDes.Text = objBll.ItemName
            txtDiscountDetail.Focus()
        End If
    End Sub

   
    Protected Sub gvSRDetail_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvSRDetail.RowDeleting
        deleteDetails(e)
    End Sub
    Private Sub deleteDetails(ByRef e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Dim objBll As New clsBllLoyalty()
        objBll.RuleId = gvSRDetail.Rows(e.RowIndex).Cells(0).Text
        objBll.CompanyId = CType(gvSRDetail.Rows(e.RowIndex).FindControl("lblCoCd"), Label).Text
        objBll.Srl = CType(gvSRDetail.Rows(e.RowIndex).FindControl("lblSrl"), Label).Text

        Dim result = objBll.DeleteSalesRule()
        If result Is Nothing Then
            lblMsg.Text = clsUtilities.showMessage("deleted")
            FillGridDetails()
        Else
            lblMsg.Text = "ERROR: " & result
        End If
    End Sub

    Protected Sub gvSalesRuleHead_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvSalesRuleHead.RowDeleting
        Dim objBll As New clsBllLoyalty()
        objBll.RuleId = gvSalesRuleHead.Rows(e.RowIndex).Cells(1).Text
        objBll.CompanyId = "00" 'Session("loginCompanyId").ToString()

        Dim result = objBll.DeleteSalesRuleHead()
        If result Is Nothing Then
            lblMsg.Text = clsUtilities.showMessage("deleted")

            objBll.CompanyId = "00" ' Session("loginCompanyId").ToString()
            gvSalesRuleHead.DataSource = objBll.GetSalesRuleHead()
            gvSalesRuleHead.DataBind()

            gvSRDetail.DataSource = Nothing
            gvSRDetail.DataBind()
            lblHeaderDtl.Text = ""
            If (gvSalesRuleHead.Rows.Count > 0) Then
                lblRuleId.Text = Convert.ToInt32(gvSalesRuleHead.Rows(gvSalesRuleHead.Rows.Count - 1).Cells(1).Text.Trim()) + 1
            Else
                lblRuleId.Text = "1"
            End If
        Else
            lblMsg.Text = "ERROR: " & result
        End If
    End Sub

    Protected Sub gvSalesRuleHead_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvSalesRuleHead.SelectedIndexChanged
        lblRuleId.Text = gvSalesRuleHead.SelectedRow.Cells(1).Text.Trim()
        FillGroupsSubGroups()
        lblHeader.Text = "Sales Rule --> Edit Sales Rule"
        txtDes.Text = CType(gvSalesRuleHead.SelectedRow.FindControl("lbDes"), LinkButton).Text
        ddlCustGrp.SelectedItem.Text = gvSalesRuleHead.SelectedRow.Cells(3).Text.Trim()
        txtPoints.Text = gvSalesRuleHead.SelectedRow.Cells(6).Text.Trim()
        txtDiscount.Text = gvSalesRuleHead.SelectedRow.Cells(7).Text.Trim()
        txtfromDt.Text = CType(gvSalesRuleHead.SelectedRow.FindControl("lblFromDt"), Label).Text
        txtToDt.Text = CType(gvSalesRuleHead.SelectedRow.FindControl("lblToDt"), Label).Text
        pnlSalesRuleHead.Enabled = False

        ViewState.Add("selRuleId", lblRuleId.Text.Trim())

        Dim objBll As New clsBllLoyalty()
        objBll.RuleId = gvSalesRuleHead.SelectedRow.Cells(1).Text.Trim()
        objBll.CompanyId = "00" 'Session("loginCompanyId").ToString()
        objBll.Gv = gvSRDetail
        objBll.GridFill()
        gvSRDetail.Visible = True
    End Sub

    
   
  
End Class
