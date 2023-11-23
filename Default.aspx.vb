
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtUsername.Focus()
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim objBll As New clsBllLoyalty
        objBll.Username = txtUsername.Text.Trim()
        objBll.Pwd = txtPwd.Text.Trim()
        If objBll.Username.Trim() <> "" And objBll.Pwd.Trim() <> "" Then
            If (objBll.ValidateLogin()) Then
                Session.Add("loginUsername", objBll.Username)
                Session.Add("loginCompanyId", objBll.CompanyId)
                Session.Add("loginCompany", objBll.CompanyName)
                Session.Add("loginUserType", objBll.UserType)
                lblLogin.Text = ""
                Response.Redirect("~/Home.aspx")
            Else
                lblLogin.Text = objBll.ErrorMsg
            End If
        End If
    End Sub
End Class
