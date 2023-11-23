
Partial Class GeneralSettings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        'need to do by JQuery
        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            FillSalesUpdnInterval()
            txtUser.Focus()

            'Dim objBll As New clsBllLoyalty
            'objBll.Gv = gvProfession
            'objBll.GridFill()

            'objBll.Gv = gvCustCompany
            'objBll.GridFill()

            'objBll.Gv = gvCustArea
            'objBll.GridFill()
        End If
    End Sub
    Private Sub FillSalesUpdnInterval()
        Dim objBll As New clsBllLoyalty
        objBll.CompanyId = Session("loginCompanyId")
        Dim ds = objBll.GetSalesUpdnDetails()

        If ds.Tables(0).Rows.Count = 1 Then ddlTimeInterval0.SelectedValue = Convert.ToInt32(ds.Tables(0).Rows(0).ItemArray(1))
    End Sub
    

    Protected Sub btnChangePwd_Click(sender As Object, e As System.EventArgs) Handles btnChangePwd.Click
        Dim objBll As New clsBllLoyalty
        objBll.Username = txtUser.Text.Trim()
        objBll.Pwd = txtOldPwd.Text.Trim()
        objBll.PwdNew = txtNewPwd.Text.Trim()

        lblMsg.Text = objBll.ChangePassword()
        lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")

       
    End Sub

    Protected Sub btnSaveInterval_Click(sender As Object, e As System.EventArgs) Handles btnSaveInterval0.Click
        Dim objBll As New clsBllLoyalty
        objBll.CompanyId = Session("loginCompanyId")
        objBll.UpdatingInterval = Convert.ToInt32(ddlTimeInterval0.SelectedValue)

        Dim result = objBll.UpdateSalesTransUpdnInterval()
        If result Is Nothing Then
            lblMsg.Text = clsUtilities.showMessage("updated")
            lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
        Else
            lblMsg.Text = result
        End If

        FillSalesUpdnInterval()
    End Sub

   
   
    'Protected Sub btnUpdateLy_Groups_Click(sender As Object, e As System.EventArgs) Handles btnUpdateLy_Groups.Click
    '    Dim objBll As New clsBllLoyalty
    '    objBll.CompanyId = "01"
    '    objBll.ConnLocalSvr = clsUtilities.CreateConnString(objBll.CompanyId)
    '    Dim result = objBll.Update_Ly_Groups()
    '    If result = "" Then
    '        lblMsg.Text = clsUtilities.showMessage("updated")
    '    Else
    '        lblMsg.Text = "ERROR: " & result
    '    End If

    '    lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
    'End Sub

    'Protected Sub btnSaveProfession_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveProfession.Click
    '    If txtprofession.Text.Trim() <> "" Then
    '        Dim objBll As New clsBllLoyalty
    '        objBll.ProfessionId = 0
    '        objBll.Profession = txtprofession.Text.Trim()

    '        Dim result = objBll.SetProfession()
    '        lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("saved"), result)

    '        txtprofession.Text = ""
    '        txtprofession.Focus()
    '        objBll.Gv = gvProfession
    '        objBll.GridFill()
    '    End If
    'End Sub

    

    'Protected Sub gvProfession_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProfession.RowCommand
    '    If e.CommandArgument <> "" Then
    '        Dim objBll As New clsBllLoyalty
    '        objBll.ProfessionId = e.CommandArgument
    '        Dim result = objBll.DeleteProfession()
    '        lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)
    '        objBll.Gv = gvProfession
    '        objBll.GridFill()
    '    End If
    'End Sub
    'Protected Sub btnSaveCustCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveCustCompany.Click
    '    If txtCustComp.Text.Trim() <> "" Then
    '        Dim objBll As New clsBllLoyalty
    '        objBll.CompanyId = ""
    '        objBll.CompanyName = txtCustComp.Text.Trim()
    '        objBll.Addr1 = txtCompAddr.Text.Trim()
    '        Dim result = objBll.SetCustCompany()

    '        lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("saved"), result)
    '        objBll.Gv = gvCustCompany
    '        objBll.GridFill()
    '        txtCustComp.Text = ""
    '        txtCompAddr.Text = ""
    '        txtCustComp.Focus()
    '    End If
    'End Sub

    'Protected Sub gvCustCompany_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCustCompany.RowCommand
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
    'End Sub
    'Protected Sub btnSaveArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveArea.Click
    '    If txtArea.Text <> "" Then
    '        Dim objBll As New clsBllLoyalty
    '        objBll.CustArea = 0
    '        objBll.Area = txtArea.Text.Trim()
    '        objBll.Addr1 = txtAreaAddr.Text.Trim()
    '        Dim result = objBll.SetCustLocation()
    '        lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("saved"), result)
    '        objBll.Gv = gvCustArea
    '        objBll.GridFill()

    '        txtArea.Text = ""
    '        txtAreaAddr.Text = ""
    '        txtArea.Focus()
    '    End If
    'End Sub

    'Protected Sub gvCustArea_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCustArea.RowCommand
    '    If e.CommandArgument <> "" Then
    '        Dim objBll As New clsBllLoyalty
    '        objBll.CustArea = e.CommandArgument
    '        Dim result = objBll.DeleteCustLocation()
    '        lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)
    '        objBll.Gv = gvCustArea
    '        objBll.GridFill()
    '    End If
    'End Sub
End Class
