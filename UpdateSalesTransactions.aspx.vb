
Partial Class UpdateSalesTransactions
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.CompanyId = Session("loginCompanyId")
            Dim ds = objBll.GetSalesUpdnDetails()

            If ds.Tables(0).Rows.Count = 0 Then
                lblLastUpdt.Text = "Last Updated Date: (Not updated)"
            Else
                lblLastUpdt.Text = "Last Updated Date: " & ds.Tables(0).Rows(0).ItemArray(0).ToString()
            End If

            'Dim lastUpdn = objBll.GetLastUpdateDate()

            'If lastUpdn Is Nothing Then
            '    lblLastUpdt.Text = "Last Updated Date: (Not updated)"
            '    pnlMessage.Visible = True
            'Else
            '    lblLastUpdt.Text = "Last Updated Date: " + lastUpdn.ToString()
            'End If

        End If
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim objBll As New clsBllLoyalty
        objBll.Username = Session("loginUsername").ToString()
        objBll.CompanyId = Session("loginCompanyId").ToString()
        objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)

        Dim result = objBll.UpdateCustTransactions()
        If result = "success" Then
            lblMsg.Text = clsUtilities.showMessage("LyServerUpdated")
        Else
            lblMsg.Text = "ERROR: " + result
        End If

        pnlMessage.Visible = False

    End Sub
End Class
