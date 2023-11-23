
Partial Class Redemption
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")
        imgBtnSearch.Attributes.Add("onClick", "window.open('CustomerSearch.aspx',null,'toolbar=0,location=0,directories=0,status=1,scrollbars=1,resizable=1,width=790,height=350,left=40,top=50;help:no');")

        If (Not IsPostBack) Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            txtCostomerNo.Focus()
            txtRedeemDate.Text = DateTime.Now
            imgBtnSearch.Attributes.Add("onClick", "window.open('CustomerSearch.aspx',null,'toolbar=0,location=0,directories=0,status=1,scrollbars=1,resizable=1,width=790,height=350,left=40,top=50;help:no');")
            '---------connection to multiple sp, tables like 'StkHeaad.DocNo'
            ' vRefDocNo_Generate()

            If Not Session("selCustCd") Is Nothing Then
                GetCustDetails(Session("selCustCd").ToString())
                lblCustOrMobile.Text = "Customer No"
            End If
        End If
    End Sub
    Private Sub GetCustDetails(ByVal custId As String)
        Dim objBll As New clsBllLoyalty
        objBll.Cd = custId
        Dim ds = objBll.GetCustomerDetails()

        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count = 1 Then
                txtCostomerNo.Text = objBll.Cd
                lblCustOrMobile.Text = "Customer No"
                lblName.Text = objBll.Des + " " + objBll.FName + " " + objBll.MName + " " + objBll.LName
                lblAddr1.Text = objBll.Addr1 + " " + objBll.Addr2 + " " + objBll.Addr3
                lblCompName.Text = objBll.CompanyName
                lblMobile.Text = objBll.Mobile
                lblIDCardNo.Text = objBll.UID
                lblNationality.Text = objBll.CountryName
                lblCustGrp.Text = objBll.CustGrp
                lblCustGrpCd.Text = objBll.CustGrpCd

                lblApprPnts.Text = objBll.Appr_Points
                lblRedmpnPnts.Text = objBll.Redm_Points
                lblUnApprPnts.Text = objBll.Unappr_Points
                'txtRedeemPoints.Text = objBll.MaxRedeemPnts -----commented b'se Customers might have to redeem partialy

                If (objBll.BlackListed) Then
                    lblBlackList.Visible = True
                    lblBlackListResult.Text = "Yes"
                Else
                    lblBlackList.Visible = False
                    lblBlackListResult.Text = ""
                End If
            End If
            FillRedeemHistory(txtCostomerNo.Text.Trim())
        Else
            lblName.Text = ""
            lblAddr1.Text = ""
            lblCompName.Text = ""
            lblMobile.Text = ""
            lblIDCardNo.Text = ""
            lblNationality.Text = ""
            lblCustGrp.Text = ""
            lblCustGrpCd.Text = ""
            lblApprPnts.Text = ""
            lblRedmpnPnts.Text = ""
            lblUnApprPnts.Text = ""
            lblBlackList.Visible = False

            gvRedeemHistoryHd.DataSource = ""
            gvRedeemHistoryHd.DataBind()

            gvRedeemHistoryDetail.DataSource = ""
            gvRedeemHistoryDetail.DataBind()
        End If

    End Sub
    Private Sub vRefDocNo_Generate()
        ' clsUtilities.gDocumentNo_Generator("DocTypes_GetRow_Remote 'SI01'", "Ly_StkHead_H_DocTyp_Getrow_Remote 'SI01'", txtIssueDocNo)

        'clsUtilities.gDocumentNo_Generator("DocTypes_GetRow_Remote '" + Trim(DDIssueDocTyp.SelectedValue.ToString) + "'", "Ly_StkHead_H_DocTyp_Getrow_Remote '" + Trim(DDIssueDocTyp.SelectedValue.ToString) + "'", txtIssueDocNo)
    End Sub
    Private Sub FillRedeemHistory(ByVal cd As String)
        Dim objBll As New clsBllLoyalty
        objBll.Cd = cd
        gvRedeemHistoryHd.DataSource = objBll.GetRedeemHead()
        gvRedeemHistoryHd.DataBind()

        If gvRedeemHistoryHd.Rows.Count = 0 Then
            lblMsgNothing.Text = clsUtilities.showMessage("emptyGrid")
        Else
            lblMsgNothing.Text = ""
        End If


    End Sub


    Protected Sub txtCostomerNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostomerNo.TextChanged
        
        GetCustDetails(txtCostomerNo.Text.Trim())

    End Sub
    Private Function SetRedeem_Head_Detail(ByVal serverName As String) As String
        Dim objBll As New clsBllLoyalty
        objBll.TrnId = 0
        Dim d As DateTime
        d = Convert.ToDateTime(txtRedeemDate.Text.Trim())
        objBll.TrnDate = Convert.ToDateTime(txtRedeemDate.Text.Trim())
        objBll.CompanyId = Session("loginCompanyId").ToString()
        objBll.Cd = txtCostomerNo.Text.Trim()
        objBll.Redm_Points = txtRedeemPoints.Text.Trim()
        objBll.Narration = txtNarration.Text.Trim()
        objBll.RefDocNo = txtVoucherNo.Text.Trim()
        objBll.DocStatus = ddlDocStatus.SelectedValue
        objBll.EntryBy = Session("loginUsername").ToString()

        'If the result is a numeric value:Then it shows insertion success otherwise fail
        '(The result returns '@@identity' value)
        Dim result = objBll.SetRedeemHead(serverName)
        ViewState.Add("lastInsertedAutoNo", result)

        'Inserting to RedeemDetail
        If IsNumeric(result) Then
            objBll.TrnAutoNo = 0
            objBll.TrnId = Convert.ToInt32(result)
            objBll.ItemCode = txtItemCode.Text.Trim()
            objBll.Qty = Convert.ToInt32(txtQty.Text.Trim())
            objBll.Unit = ddlUnits.SelectedValue
            objBll.BaseQty = 0       ' Convert.ToInt32(txtBaseQty.Text.Trim())
            objBll.Points = Convert.ToDecimal(txtRedeemPoints.Text.Trim())
            objBll.Narration = txtNarration.Text.Trim()
            objBll.Cost = Convert.ToDecimal(txtCost.Text.Trim())

            result = objBll.SetRedeemDetail(serverName)
        End If
        Return result

    End Function
   
  Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim result = ""
       
        If txtCostomerNo.Text.Trim() = "" Or lblName.Text.Trim() = "" Then
            lblMsg.Text = "Invalid Customer Number..."
        Else
            If txtItemCode.Text.Trim() = "" Or txtItemName.Text.Trim() = "" Or txtQty.Text.Trim() = "" Or Not RedeemItemDetails() Then
                lblMsg.Text = "Invalid Redeem Item Details..."
            Else
                If Val(lblUnApprPnts.Text.Trim()) < Val(txtRedeemPoints.Text.Trim()) Then
                    lblMsg.Text = clsUtilities.showMessage("insufficientRedPoints") ' "Your Redemption point is too low to redeem this item..."
                Else


                    'Insert into 'MAIN LOYALTY SERVER'
                    result = SetRedeem_Head_Detail("")

                    'If result Is Nothing Then
                    '    ''Insert into 'LOCAL' SERVER
                    '    result = SetRedeem_Head_Detail(clsUtilities.CreateConnString(Session("loginCompanyId").ToString()))
                    'End If


                    If result Is Nothing Then
                        lblMsg.Text = clsUtilities.showMessage("saved")

                        GetCustDetails(txtCostomerNo.Text.Trim())
                        FillRedeemHistory(txtCostomerNo.Text.Trim())

                        Response.Redirect("RedVoucher.aspx?id=" + ViewState("lastInsertedAutoNo"))
                    Else
                        lblMsg.Text = result
                    End If

                    GetCustDetails(txtCostomerNo.Text.Trim())
                    FillRedeemHistory(txtCostomerNo.Text.Trim())
                End If
            End If
        End If
        lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
    End Sub

    Protected Sub gvRedeemHistoryHd_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRedeemHistoryHd.RowCommand
        'CType(e.CommandSource,(ImageButton)
        If CType(e.CommandSource, ImageButton).ID = "imgBtnPrnt" Then
            Response.Redirect("RedVoucher.aspx?id=" + e.CommandArgument.ToString())
        Else

            Dim objBll As New clsBllLoyalty
            objBll.TrnId = Convert.ToInt32(e.CommandArgument)
            gvRedeemHistoryDetail.DataSource = objBll.GetRedeemDetails()
            gvRedeemHistoryDetail.DataBind()
            If gvRedeemHistoryDetail.Rows.Count > 0 Then
                lblHisDetails.Visible = True
            Else
                lblHisDetails.Visible = False
            End If
        End If
    End Sub


    Private Function RedeemItemDetails() As Boolean
        If (txtItemCode.Text.Trim() <> "") Then
            Dim objBll As New clsBllLoyalty
            'objBll.CompanyId = Session("loginCompanyId").ToString()
            objBll.CustGrpCd = lblCustGrpCd.Text.Trim()
            objBll.ItemCode = txtItemCode.Text.Trim()


            objBll.GetRedeemItemDetails()
            If objBll.ItemName = "" Then
                txtItemName.Text = clsUtilities.showMessage("chkItemOrCust")
                txtItemName.BackColor = Drawing.Color.Cyan
                Return False
            Else
                txtItemName.Text = objBll.ItemName
                txtCost.Text = objBll.Cost
                ddlUnits.SelectedValue = objBll.Unit
                txtRedeemPoints.Text = objBll.Redm_Points

                txtItemName.BackColor = Drawing.Color.White
                txtItemName.ForeColor = Drawing.Color.DarkBlue

                txtCost.BackColor = Drawing.Color.White
                txtCost.ForeColor = Drawing.Color.DarkBlue

                txtRedeemPoints.BackColor = Drawing.Color.White
                txtRedeemPoints.ForeColor = Drawing.Color.DarkBlue
                Return True
            End If
        End If

        Return False
    End Function

    Protected Sub btnItemDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnItemDetails.Click
        If txtCostomerNo.Text.Trim() <> "" Or lblName.Text.Trim() <> "" Then
            RedeemItemDetails()
        Else
            lblMsgInvalidCust.Text = "Pls Check Customer Number..."
        End If
    End Sub


End Class
