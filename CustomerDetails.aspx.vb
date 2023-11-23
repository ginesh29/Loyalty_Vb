
Partial Class CustomerDetails
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            If (clsUtilities.GetAccessPermn_and_MenuTabIndex(Me.ToString(), Session("loginUserType").ToString())) = False Then Server.Transfer("AccessDenied.aspx")
            Session.Add("MenuTabSelected", clsUtilities.MenuTabSelected)

            Dim objBll As New clsBllLoyalty()

            objBll.Ddl = ddlCountry
            objBll.ComboFill()

            objBll.Ddl = ddlCustGrp
            objBll.ComboFill()

            objBll.Ddl = ddlReligion
            objBll.ComboFill()

            objBll.Ddl = ddlCustCompany
            objBll.ComboFill()

            objBll.Ddl = ddlAccArea
            objBll.ComboFill()

            objBll.Ddl = ddlProfession
            objBll.ComboFill()

            ddlCustGrp.SelectedIndex = 1

            ddlDay.Items.Add("Day")
            For cnt = 1 To 31
                ddlDay.Items.Add(IIf((cnt.ToString().Length > 1), cnt.ToString(), "0" + cnt.ToString()))
            Next

            ddlYear.Items.Add("Year")
            For cnt = 1900 To DateTime.Now.Year
                ddlYear.Items.Add(cnt)
            Next

            If Request.QueryString("sel") = "newcust" Then
                SetNewCustomerProperties()

            ElseIf Request.QueryString("sel") = "search" Then
                imgBtnSearch.Attributes.Add("onClick", "window.open('CustomerSearch.aspx?src=custsearch',null,'toolbar=0,location=0,directories=0,status=1,scrollbars=1,resizable=1,width=790,height=350,left=40,top=50;help:no');")
                SetSearchProperties()

            ElseIf Not Session("selCustCd") Is Nothing Then
                GetCustDetails(Session("selCustCd").ToString())
                lblCustOrMobile.Text = "Customer No"
                imgBtnSearch.Visible = True
                txtConsumerNo.Focus()



                'If (gvCustTrans.Rows.Count = 0) Then
                '    lblNothing.Text = clsUtilities.showMessage("nothing")
                'Else
                '    lblNothing.Text = ""
                'End If
            End If
        End If
    End Sub
    Private Sub SetSearchProperties()
        lblCustOrMobile.Text = "Cust No / Mobile No"
        imgBtnSearch.Visible = True
        btnSave.Visible = False
        lblPageHeader.Text = "Loyalty --> Customer Search"
        btnTransDetails.Visible = False
        txtConsumerNo.Focus()
    End Sub
    Private Sub SetNewCustomerProperties()
        Dim objBll As New clsBllLoyalty()
        objBll.CompanyId = Session("loginCompanyId").ToString()
        objBll.GetNextCustomerNo()
        'If objBll.Cd.Length = 10 Then txtConsumerNo.Text = objBll.Cd Else lblMsg.Text = objBll.Cd

        txtConsumerNo.Enabled = True
        imgBtnSearch.Visible = False
        lblCustOrMobile.Text = "Customer No"
        btnSave.Visible = True
        lblPageHeader.Text = "Loyalty --> Add Customer"
        txtFName.Focus()
    End Sub
    'Public Function GetMenuTabIndex(formId As String) As String
    '    Dim dsXML As New Data.DataSet
    '    dsXML.ReadXml(Server.MapPath("") + "\\MenuStyle.xml")
    '    Dim dr() = dsXML.Tables(0).Select("id='" + formId + "'")
    '    Return Convert.ToInt32(dsXML.Tables(0).Select("id='" + formId + "'")(0).Item(0))
    'End Function


    Protected Sub txtConsumerNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsumerNo.TextChanged
        clsUtilities.ClearControls(pnlMain, "txtConsumerNo")
        lblCustOrMobile.Text = "Cust No / Mobile No"
        btnSave.Text = "Save"

        GetCustDetails(txtConsumerNo.Text.Trim())
    End Sub
    Private Sub GetCustDetails(ByVal custId As String)
        Dim objBll As New clsBllLoyalty
        objBll.Cd = custId
        Dim ds = objBll.GetCustomerDetails()

        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 1 Then
                Session.Add("dtSearchResult", ds.Tables(0))
                btnTransDetails.Visible = False

            ElseIf ds.Tables(0).Rows.Count = 1 Then
                txtConsumerNo.Text = objBll.Cd
                ddlSalutation.SelectedItem.Text = objBll.Des
                txtFName.Text = objBll.FName
                txtMName.Text = objBll.MName
                txtLName.Text = objBll.LName
                IIf(objBll.Gender = True, rbMale.Checked = True, rbFemale.Checked = True)

                ddlDay.Text = IIf(objBll.BirthDt.Day.ToString().Length = 1, ("0" & objBll.BirthDt.Day), objBll.BirthDt.Day)
                ddlMonth.SelectedValue = objBll.BirthDt.Month
                ddlYear.Text = objBll.BirthDt.Year
                txtAdd1.Text = objBll.Addr1
                'txtAdd2.Text = objBll.Addr2
                'txtAdd3.Text = objBll.Addr3
                ddlCustCompany.SelectedValue = objBll.CustCo
                ddlAccArea.SelectedValue = objBll.CustArea
                ddlReligion.SelectedValue = objBll.Religion
                ddlProfession.SelectedValue = objBll.Profession

                txtPhone.Text = objBll.Phone
                'txtFax.Text = objBll.Fax
                txtMobile.Text = objBll.Mobile
                txtEmail.Text = objBll.Email

                txtIdCardNo.Text = objBll.UID
                rblIdCardNo.SelectedValue = objBll.IDType
                ddlCountry.SelectedValue = objBll.Country
                ddlCustGrp.SelectedValue = objBll.CustGrpCd

                txtAppr_points.Text = objBll.Appr_Points
                txtRedmPoints.Text = objBll.Redm_Points
                txtUnapprPoints.Text = objBll.Unappr_Points
                txtLastPurDate.Text = IIf(objBll.Last_PurDt = "01/01/1951", "", objBll.Last_PurDt)
                txtEntryBy.Text = objBll.EntryBy
                txtEntryDt.Text = objBll.EntryDt

                If (objBll.Active = True) Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If

                If (objBll.BlackListed = True) Then
                    chkBlackList.Checked = True
                    chkBlackList.BackColor = Drawing.Color.Red
                    lblBlackList.BackColor = Drawing.Color.Red
                Else
                    chkBlackList.Checked = False
                    lblBlackList.BackColor = Drawing.Color.Transparent
                    chkBlackList.BackColor = Drawing.Color.Transparent
                End If

                If (objBll.CardIssued = True) Then
                    chkCardIssued.Checked = True
                Else
                    chkCardIssued.Checked = False
                End If

                txtRemarks.Text = objBll.Remarks
                If txtRemarks.Text.Trim <> "" Then
                    txtRemarks.BackColor = Drawing.Color.LightBlue
                Else
                    txtRemarks.BackColor = Drawing.Color.Transparent
                End If

                btnTransDetails.Visible = True
                Session.Add("selCust", txtConsumerNo.Text.Trim)
                Session.Add("selCustName", ddlSalutation.SelectedValue + " " + txtFName.Text + " " + txtMName.Text + " " + txtLName.Text)
                btnTransDetails.Attributes.Add("onClick", "window.open('CustTrans.aspx',null,'toolbar=0,location=0,directories=0,status=1,scrollbars=1,resizable=1,width=700,height=350,left=40,top=50;help:no');")

                lblCustOrMobile.Text = "Customer No"
                btnSave.Visible = True
                btnSave.Text = "Update"
                txtFName.Focus()
            Else
                btnTransDetails.Visible = False
            End If

        End If
    End Sub
    '1000014979
    'onkeypress="findAdmin(1);"
   
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objBll As New clsBllLoyalty
        objBll.Mobile = txtMobile.Text.Trim()
        objBll.Cd = IIf(btnSave.Text = "Update", txtConsumerNo.Text.Trim(), "")

        'If (ddlDay.SelectedIndex = 0 Or ddlMonth.SelectedIndex = 0 Or ddlYear.SelectedIndex = 0) Then
        '    lblMsg.Text = "Invalid Birth Date..."

        'ElseIf (Not objBll.ValidateMobileNo() Is Nothing) Then 'And btnSave.Text = "Save" Then
        '    lblMsg.Text = "Mobile Number already exists for the Customer Number: " & objBll.Cd

        'Else
        If (txtConsumerNo.Text.Trim() = "") Then
            lblMsg.Text = "Please Enter Valid Customer Number"
        Else
            objBll.Cd = txtConsumerNo.Text.Trim()
        End If

        objBll.Des = ddlSalutation.SelectedItem.Text.Trim()
        If (txtFName.Text.Trim() = "") Then
            lblMsg.Text = "Please Enter First Name"
        Else
            objBll.FName = txtFName.Text.Trim()
        End If

        objBll.MName = txtMName.Text.Trim()
        objBll.LName = txtLName.Text.Trim()
        objBll.CompanyId = Session("loginCompanyId").ToString()

        objBll.Gender = IIf((rbMale.Checked = True), True, False)
        'objBll.BirthDt = Convert.ToDateTime(ddlDay.Text.Trim() + "/" + ddlMonth.SelectedValue.Trim() + "/" + ddlYear.Text.Trim()) '.ToString("dd/MM/yyyy")
        If (ddlMonth.SelectedValue.ToString() = "0" And ddlDay.Text.Trim() = "Day" And ddlYear.Text.Trim() = "Year") Then
            objBll.BirthDt = DateString.ToString()
        Else
            objBll.BirthDt = Convert.ToDateTime(ddlMonth.SelectedValue.Trim() + "/" + ddlDay.Text.Trim() + "/" + ddlYear.Text.Trim())
        End If
        'objBll.BirthDt = Date.Now
        objBll.Addr1 = txtAdd1.Text.Trim()
        objBll.Addr2 = "" ' txtAdd2.Text.Trim()
        objBll.Addr3 = ""
        objBll.CustCo = ddlCustCompany.SelectedValue
        objBll.CustArea = ddlAccArea.SelectedValue
        objBll.Religion = ddlReligion.SelectedValue
        objBll.Profession = ddlProfession.SelectedValue

        objBll.Phone = txtPhone.Text.Trim()
        objBll.Fax = ""  'txtFax.Text.Trim()

        objBll.Email = txtEmail.Text.Trim()

        objBll.UID = txtIdCardNo.Text.Trim()
        objBll.IDType = rblIdCardNo.SelectedValue.Trim()
        objBll.Curr = "1"
        objBll.Region = ""
        objBll.CardType = ""

        objBll.Country = ddlCountry.SelectedValue
        objBll.CustGrp = ddlCustGrp.SelectedValue
        objBll.Active = IIf((chkActive.Checked), True, False)
        objBll.BlackListed = IIf((chkBlackList.Checked), True, False)

        objBll.CardIssued = IIf((chkCardIssued.Checked), True, False)
        objBll.Remarks = txtRemarks.Text.Trim()

        objBll.EntryBy = Session("loginUsername").ToString()
        objBll.EditBy = Session("loginUsername").ToString()


        Dim result = objBll.SetCustomer()
        If result Is Nothing Then

            If btnSave.Text = "Save" Then
                lblMsg.Text = clsUtilities.showMessage("saved")
                clsUtilities.ClearControls(pnlMain, "")
                SetNewCustomerProperties()


            ElseIf btnSave.Text = "Update" Then
                lblMsg.Text = clsUtilities.showMessage("updated")
                btnSave.Text = "Save"
                clsUtilities.ClearControls(pnlMain, "")
                SetSearchProperties()
            End If

            lblMsg.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFC0")
        Else
            lblMsg.Text = result
        End If
        'End If
    End Sub

    Protected Sub btnTransDetails_Click(sender As Object, e As System.EventArgs) Handles btnTransDetails.Click

    End Sub

    Protected Sub imgBtnSearch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSearch.Click

    End Sub
End Class
