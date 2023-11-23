
Partial Class Profession
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")
        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty
            objBll.Gv = gvProfession
            objBll.GridFill()

            If gvProfession.Rows.Count = 0 Then lblMsg.Text = clsUtilities.showMessage("emptyGrid")

        End If
    End Sub

    Protected Sub btnSaveProfession_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveProfession.Click

        If txtprofession.Text.Trim() <> "" Then
            Dim objBll As New clsBllLoyalty
            objBll.Profession = txtprofession.Text.Trim()
            objBll.Username = Session("loginUsername").ToString()

            If ((CType(sender, Button).Text = "Confirm Delete")) Then
                objBll.ProfessionId = Convert.ToInt32(txtprofessionId.Text)
                Dim result = objBll.DeleteProfession()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)

            ElseIf ((CType(sender, Button).Text = "Update")) Then
                objBll.ProfessionId = Convert.ToInt32(txtprofessionId.Text)
                Dim result = objBll.SetProfession()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("updated"), result)


            ElseIf ((CType(sender, Button).Text = "Save")) Then
                objBll.ProfessionId = 0
                Dim result = objBll.SetProfession()
                lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("saved"), result)
            End If

            txtprofession.Text = ""
            btnSaveProfession.Text = "Save"
            objBll.Gv = gvProfession
            objBll.GridFill()
            txtprofession.Focus()

        End If

        'Dim objBll As New clsBllLoyalty
        'objBll.ProfessionId = CType(gvProfession.Rows(e.RowIndex).FindControl("lblProfessionId"), Label).Text.Trim()
        'Dim result = objBll.DeleteProfession()
        'lblMsg.Text = IIf(result Is Nothing, clsUtilities.showMessage("deleted"), result)
        'objBll.Gv = gvProfession
        'objBll.GridFill()
    End Sub

    Protected Sub gvProfession_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProfession.RowCommand
        txtprofessionId.Text = gvProfession.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        txtprofession.Text = gvProfession.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
        btnSaveProfession.Text = IIf(CType(e.CommandSource, ImageButton).ID = "imgDelete", "Confirm Delete", "Update")
        lblMsg.Text = ""
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtprofessionId.Text = ""
        txtprofession.Text = ""
        btnSaveProfession.Text = "Save"
        lblMsg.Text = ""
    End Sub
End Class
