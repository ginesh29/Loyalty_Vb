
Partial Class MasterPageLoyalty
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            If Session("loginUsername") Is Nothing Or Session("loginCompanyId") Is Nothing Then
                Response.Redirect("Default.aspx")
            Else
                'Session("loginCompanyId") = "01"
                'imgBannerHead.ImageUrl = "~/Images/" + Session("loginCompanyId").ToString() + ".png"  'Server.MapPath("") + "\Images\" + 
                lblWelcome.Text = "Welcome: " & Session("loginUsername").ToString()
                'lblCompany.Text = Session("loginCompany").ToString()
            End If

            Accordion2.SelectedIndex = Convert.ToInt32(Session("MenuTabSelected"))

            'Dim aaa= Accordion2.TabIndex[1].ID.ToString()
            ' Dim saaa = CType(AccordionPane1.FindControl("abc"), HtmlAnchor).TagName
            ' Dim str1 = CType(Accordion2.FindControl("search"), Button).Text

            'imgBannerHead.ImageUrl = "~/Images/" + Session("loginCompanyId").ToString() + ".png"  'Server.MapPath("") + "\Images\" + 
        End If
    End Sub

    
    Protected Sub lnkLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Session.Clear()
        Response.Redirect("~/Default.aspx")
    End Sub
End Class

