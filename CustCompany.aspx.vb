
Partial Class CustCompany
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")
        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.Gv = gvCustCompany
            objBll.GridFill()
        End If
    End Sub

    Protected Sub btnSaveCustCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveCustCompany.Click
        If txtCustComp.Text.Trim() <> "" Then
            Dim objBll As New clsBllLoyalty
            objBll.Username = Session("loginUsername").ToString()

            If ((CType(sender, Button).Text = "Confirm Delete")) Then
                objBll.CompanyId = txtCustCompId.Text.Trim()
                objBll.CompanyName = txtCustComp.Text.Trim()
                objBll.Addr1 = txtCompAddr.Text.Trim()
                Dim result = objBll.SetCustCompany()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)

            ElseIf ((CType(sender, Button).Text = "Update")) Then
                objBll.CompanyId = txtCustCompId.Text.Trim()
                objBll.CompanyName = txtCustComp.Text.Trim()
                objBll.Addr1 = txtCompAddr.Text.Trim()
                Dim result = objBll.SetCustCompany()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("updated"), result)


            ElseIf ((CType(sender, Button).Text = "Save")) Then
                objBll.CompanyId = ""
                objBll.CompanyName = txtCustComp.Text.Trim()
                objBll.Addr1 = txtCompAddr.Text.Trim()
                Dim result = objBll.SetCustCompany()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("saved"), result)
            End If

            txtCustCompId.Text = ""
            txtCustComp.Text = ""
            txtCompAddr.Text = ""
            btnSaveCustCompany.Text = "Save"

            objBll.Gv = gvCustCompany
            objBll.GridFill()
            txtCustComp.Focus()

        End If
    End Sub

    Protected Sub gvCustCompany_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCustCompany.RowCommand
        txtCustCompId.Text = gvCustCompany.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        txtCustComp.Text = gvCustCompany.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
        txtCompAddr.Text = gvCustCompany.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text

        btnSaveCustCompany.Text = IIf(CType(e.CommandSource, ImageButton).ID = "imgDelete", "Confirm Delete", "Update")
        lblMsg.Text = ""
        '    If e.CommandArgument <> "" Then
        '        Dim objBll As New clsBllLoyalty
        '        objBll.CompanyId = e.CommandArgument
        '        Dim result = objBll.DeleteCustCompany()
        '        lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)
        '        objBll.Gv = gvCustCompany
        '        objBll.GridFill()
        '        txtCustComp.Text = ""
        '        txtCompAddr.Text = ""
        '    End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtCustCompId.Text = ""
        txtCustComp.Text = ""
        txtCompAddr.Text = ""
        btnSaveCustCompany.Text = "Save"
        lblMsg.Text = ""
    End Sub
End Class
