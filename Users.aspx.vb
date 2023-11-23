
Partial Class Masters_Users
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.Ddl = ddlCompany
            objBll.ComboFill()

            objBll.Username = ""
            objBll.Pwd = ""
            objBll.Gv = gvUserList
            objBll.GridFill()

        End If
    End Sub

    Protected Sub btnCreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateUser.Click
        If ddlCompany.SelectedIndex > 0 Then
            Dim objBll As New clsBllLoyalty
            objBll.Cd = 0
            objBll.Pwd = txtPwd.Text.Trim()
            objBll.Username = txtUsername.Text.Trim()
            objBll.CompanyId = ddlCompany.SelectedValue
            objBll.EntryBy = Session("loginUsername").ToString()
            objBll.UserType = rbUserType.SelectedValue
            Dim result = objBll.SetUser()
            If IsNumeric(result) Then
                lblMsg.Text = clsUtilities.showMessage("saved")

                txtUsername.Text = ""
                ddlCompany.SelectedIndex = 0
                rbUserType.Items(1).Selected = False
                rbUserType.Items(0).Selected = True

                objBll.Username = ""
                objBll.Pwd = ""
                objBll.Gv = gvUserList
                objBll.GridFill()

            Else
                lblMsg.Text = clsUtilities.showMessage("userExists")
            End If
        Else
            lblMsg.Text = clsUtilities.showMessage("selectOne")
        End If
        lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
    End Sub

    Protected Sub gvUserList_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvUserList.RowDeleting
        Dim objBll As New clsBllLoyalty
        objBll.Cd = CType(gvUserList.Rows(e.RowIndex).FindControl("lblCd"), Label).Text
        Dim result = objBll.DeleteUser()

        If result Is Nothing Then
            lblMsg.Text = clsUtilities.showMessage("deleted")
            objBll.Username = ""
            objBll.Pwd = ""
            objBll.Gv = gvUserList
            objBll.GridFill()
        Else
            lblMsg.Text = "ERROR: " & result
        End If
        lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")

    End Sub


    'Protected Sub btnUpdateLy_Groups_Click(sender As Object, e As System.EventArgs) Handles btnUpdateLy_Groups.Click
    '    Dim objBll As New clsBllLoyalty
    '    objBll.CompanyId = "01"
    '    objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)
    '    Dim result = objBll.Update_Ly_Groups()
    '    If result = "" Then
    '        lblMsg.Text = clsUtilities.showMessage("saved")
    '    Else
    '        lblMsg.Text = "ERROR: " & result
    '    End If
    'End Sub
End Class
