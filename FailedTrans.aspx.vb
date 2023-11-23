Imports System.Data.SqlClient
Partial Class FailedTrans
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.CompanyId = Session("loginCompanyId").ToString()
            objBll.Ddl = ddlCounterNo
            objBll.ComboFill()
            txtCompany.Text = Session("loginCompanyId").ToString() + " " + Session("loginCompany").ToString()
            txtCustNo.Focus()
        End If
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Dim objBll As New clsBllLoyalty
        objBll.CompanyId = Session("loginCompanyId").ToString().Trim()
        'objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)
        objBll.Cd = txtCustNo.Text.Trim()
        objBll.TrnDate = Convert.ToDateTime(txtTrnDt.Text.Trim())
        'objBll.TrnDate = CDate("05/29/2016")
        objBll.BillNo = txtBillNo.Text.Trim()
        objBll.PosId = ddlCounterNo.SelectedItem.Text.ToString()
        objBll.TrnLoc = txtTrnLoc.Text.Trim()

        Label1.Text = objBll.CompanyId
        Label2.Text = objBll.Cd
        Label3.Text = objBll.TrnDate
        Label4.Text = objBll.BillNo
        Label5.Text = objBll.PosId
        Label6.Text = objBll.TrnLoc

        gvFailedTrans.DataSource = Nothing
        gvFailedTrans.DataBind()

        Dim ds As New Data.DataSet
        ds = objBll.GetFailedTrans()

        If ds.Tables(0).Rows.Count = 0 Then
            lblMsg.Text = clsUtilities.showMessage("emptyGrid")
            btnApprove.Enabled = False
        Else
            lblMsg.Text = ""
            btnApprove.Enabled = True
            gvFailedTrans.DataSource = ds
            gvFailedTrans.DataBind()

            Dim totalNetVal As Double = 0.0
            'Dim totalPrice = 0

            For Each gvr As GridViewRow In gvFailedTrans.Rows
                'totalPrice += Convert.ToDecimal(gvr.Cells(6).Text)
                totalNetVal += Convert.ToDecimal(gvr.Cells(8).Text)
            Next

            gvFailedTrans.FooterRow.Cells(7).Text = "TOTAL:"
            gvFailedTrans.FooterRow.Cells(8).Text = totalNetVal.ToString()

            'ViewState.Add("dtFT", ds.Tables(0))
        End If
    End Sub
    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Dim objBll As New clsBllLoyalty
        'objBll.Dt = CType(ViewState("dtFT"), Data.DataTable)
        objBll.Cd = txtCustNo.Text.Trim()
        objBll.BillNo = txtBillNo.Text
        'objBll.PosId = ddlCounterNo.SelectedValue
        objBll.PosId = ddlCounterNo.SelectedItem.Text.ToString()
        objBll.TrnDate = Convert.ToDateTime(txtTrnDt.Text)
        'objBll.TrnDate = CDate("05/29/2016")
        objBll.CompanyId = Session("loginCompanyId").ToString()
        objBll.TrnLoc = txtTrnLoc.Text.Trim()

        Dim result = objBll.UpdateFailedTrans()
        If result = "" Then
            lblMsg.Text = clsUtilities.showMessage("updated")
            txtBillNo.Text = ""
            txtCustNo.Text = ""
            txtTrnDt.Text = ""
            ddlCounterNo.SelectedIndex = 0
            gvFailedTrans.DataSource = Nothing
            gvFailedTrans.DataBind()
            btnApprove.Enabled = False
        Else
            lblMsg.Text = "ERROR: " & result
        End If
    End Sub

    Protected Sub ddlCounterNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCounterNo.SelectedIndexChanged
        Dim objBll As New clsBllLoyalty
        objBll.LocCd = ddlCounterNo.SelectedItem.Text.ToString()
        txtTrnLoc.Text = objBll.GetLocation()
    End Sub
End Class
