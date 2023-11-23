
Partial Class CustomerSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            'If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            txtKeyword.Focus()
            ' If Session("searchKey") <> Nothing Then
            'End If
        End If
    End Sub

    Protected Sub txtKeyword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKeyword.TextChanged
        Search()
    End Sub
    Protected Sub imgBtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim objBll As New clsBllLoyalty
        objBll.Cd = txtKeyword.Text.Trim()
        gvCustomers.DataSource = objBll.GetCustomerDetails()
        gvCustomers.DataBind()
        If gvCustomers.Rows.Count = 0 Then
            lblMsg.Text = clsUtilities.showMessage("emptyGrid")
        Else
            lblMsg.Text = ""
        End If
    End Sub
    
    Protected Sub gvCustomers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCustomers.RowCommand
        If Request.QueryString("src") = "custsearch" Then
            Session.Add("selCustCd", e.CommandArgument.ToString())
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "dd", "windowclose();", True)
        ElseIf (Request.QueryString("src") = "custSearchReports") Then
            Session.Add("selCustCd", e.CommandArgument.ToString())
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "dd", "windowcloseOpenReports();", True)
        Else
            Session.Add("selCustCd", e.CommandArgument.ToString())
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "dd", "windowcloseOpenRedeem();", True)
        End If
        
    End Sub
End Class
