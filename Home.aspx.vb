
Partial Class Home
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then


            Dim objBll As New clsBllLoyalty
            objBll.CompanyId = Session("loginCompanyId")
            Dim ds = objBll.GetSalesUpdnDetails()

            If ds.Tables(0).Rows.Count = 0 Then
                lblLastUpdt.Text = "Last Updated Date: (Not updated)"
                pnlMessage.Visible = True
            Else
                If DateTime.Now > Convert.ToDateTime(ds.Tables(0).Rows(0).ItemArray(0)).AddMinutes(Convert.ToInt32(ds.Tables(0).Rows(0).ItemArray(1))) Then
                    lblLastUpdt.Text = "Last Updated Date: " & ds.Tables(0).Rows(0).ItemArray(0).ToString()
                    pnlMessage.Visible = True
                Else
                    pnlMessage.Visible = False
                End If
            End If



        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If rbUpdateNow.Checked = True Then
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
        End If
        pnlMessage.Visible = False
    End Sub
End Class
