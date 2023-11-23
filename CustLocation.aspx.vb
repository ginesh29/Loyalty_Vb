
Partial Class CustLocation
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")
        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.Gv = gvCustArea
            objBll.GridFill()
        End If
    End Sub

    Protected Sub btnSaveArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveArea.Click
        If txtArea.Text.Trim() <> "" Then
            Dim objBll As New clsBllLoyalty
            'objBll.Username = Session("loginUsername").ToString()

            If ((CType(sender, Button).Text = "Confirm Delete")) Then
                objBll.CustArea = Convert.ToInt32(txtAreaCd.Text.Trim())
               
                Dim result = objBll.DeleteCustLocation()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)

            ElseIf ((CType(sender, Button).Text = "Update")) Then
                objBll.CustArea = Convert.ToInt32(txtAreaCd.Text.Trim())
                objBll.Area = txtArea.Text.Trim()
                objBll.Addr1 = txtAreaAddr.Text.Trim()
                Dim result = objBll.SetCustLocation()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("updated"), result)


            ElseIf ((CType(sender, Button).Text = "Save")) Then
                objBll.CustArea = 0
                objBll.Area = txtArea.Text.Trim()
                objBll.Addr1 = txtAreaAddr.Text.Trim()
                Dim result = objBll.SetCustLocation()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("saved"), result)
            End If

            objBll.Gv = gvCustArea
            objBll.GridFill()

            txtAreaCd.Text = ""
            txtArea.Text = ""
            txtAreaAddr.Text = ""
            btnSaveArea.Text = "Save"
            txtArea.Focus()
        End If
       
    End Sub

    Protected Sub gvCustArea_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCustArea.RowCommand
        If e.CommandSource.ToString() = "System.Web.UI.WebControls.ImageButton" Then

            Dim objBll As New clsBllLoyalty
            objBll.CustArea = Convert.ToInt32(e.CommandArgument)
            objBll.GetCustArea()
            txtAreaCd.Text = objBll.CustArea
            txtArea.Text = objBll.Area
            txtAreaAddr.Text = objBll.Addr1

            btnSaveArea.Text = IIf(CType(e.CommandSource, ImageButton).ID = "imgDelete", "Confirm Delete", "Update")
            lblMsg.Text = ""
            'If e.CommandArgument <> "" Then
            '    Dim objBll As New clsBllLoyalty
            '    objBll.CustArea = e.CommandArgument
            '    Dim result = objBll.DeleteCustLocation()
            '    lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)
            '    objBll.Gv = gvCustArea
            '    objBll.GridFill()
            'End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtAreaCd.Text = ""
        txtArea.Text = ""
        txtAreaAddr.Text = ""
        btnSaveArea.Text = "Save"
        lblMsg.Text = ""
    End Sub

    Protected Sub gvCustArea_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCustArea.PageIndexChanging
        gvCustArea.PageIndex = e.NewPageIndex
        Dim objBll As New clsBllLoyalty
        objBll.Gv = gvCustArea
        objBll.GridFill()
        'gvCustArea.PageIndex = e.NewPageIndex
    End Sub
End Class
