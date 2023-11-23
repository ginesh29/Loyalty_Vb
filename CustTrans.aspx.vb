
Partial Class CustTrans
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            txtId.Text = Session("selCust").ToString()
            txtName.Text = Session("selCustName").ToString()

            txtFrom.Text = Now.AddDays(-7).ToShortDateString()
            txtTo.Text = DateTime.Now.ToShortDateString()
            FillGrid()
            
        End If
    End Sub
    Private Sub FillGrid()
        Dim objBll As New clsBllLoyalty()
        objBll.Gv = gvCustTrans
        objBll.Cd = txtId.Text
        objBll.FromDt = Convert.ToDateTime(txtFrom.Text.Trim())
        objBll.ToDt = Convert.ToDateTime(txtTo.Text.Trim())
        objBll.GridFill()

        If (gvCustTrans.Rows.Count = 0) Then
            lblNothing.Text = clsUtilities.showMessage("nothing")
        Else
            lblNothing.Text = ""
        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        FillGrid()
    End Sub
End Class
