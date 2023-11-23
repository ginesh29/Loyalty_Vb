
Partial Class Masters_Company
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            GetCompanydetails()
        End If

    End Sub
    Private Sub GetCompanydetails()
        Dim objBll As New clsBllLoyalty
        objBll.CompanyId = Session("loginCompanyId").ToString()
        Dim ds = objBll.GetCompanydetails()
        lblCompanyCode.Text = objBll.CompanyId
        txtCompanyName.Text = objBll.CompanyName
        txtAdd1.Text = objBll.Addr1
        txtAdd2.Text = objBll.Addr2
        txtAdd3.Text = objBll.Addr3
        txtPhone.Text = objBll.Phone
        txtFax.Text = objBll.Fax
        txtEmail.Text = objBll.Email
        txtServerName.Text = objBll.ServerName
        txtDbName.Text = objBll.DBName
        txtUserName.Text = objBll.Username


    End Sub
End Class
