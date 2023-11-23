Imports System
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Partial Class RedVoucher
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loginUsername") Is Nothing Then Response.Redirect("~/Default.aspx")

        If Not IsPostBack Then
            Dim objBll As New clsBllLoyalty
            objBll.TrnId = IIf(Request.QueryString("id") Is Nothing, 0, Convert.ToInt32(Request.QueryString("id")))
            objBll.GetRedVoucherDetails()

            'lblCompany.Text = objBll.CompanyName
            lblCompany.Text = Session("loginCompany").ToString()
            lblVoucherNo.Text = objBll.RefDocNo
            lblRedDt.Text = objBll.TrnDate.ToString()
            lblCustCd.Text = objBll.Cd
            lblCustName.Text = objBll.FName
            lblNarration.Text = objBll.Narration
            lblAccPnts.Text = objBll.Appr_Points
            lblRedPnts.Text = objBll.Redm_Points
            lblCurrentRed.Text = objBll.Curr

            lblBalancePnts.Text = Convert.ToString(objBll.Appr_Points - objBll.Redm_Points) ' round to 2 decimal places(1010000211)

            lblSlNo.Text = "1"
            lblItemcd.Text = objBll.ItemCode
            lblItem.Text = objBll.ItemName
            lblQty.Text = objBll.Qty
            lblUnit.Text = objBll.Unit
            lblPoints.Text = objBll.Points


            ShowPDF()

        End If
    End Sub
    Sub ShowPDF()
        Dim doc As Document = New Document
        PdfWriter.GetInstance(doc, New FileStream(Request.PhysicalApplicationPath + "\PDF\" + "Voucher.pdf", FileMode.Create))
        doc.Open()
        'doc.AddCreationDate()
        Dim leng = 53

        If Session("loginCompanyId").ToString() = "01" Then
            leng = 53
        ElseIf Session("loginCompanyId").ToString() = "02" Then
            leng = 50
        ElseIf Session("loginCompanyId").ToString() = "03" Then
            leng = 55
        End If

        doc.Add(New Paragraph(Space(50) + "AL MADINA HYPERMARKET"))
        doc.Add(New Paragraph(Space(leng) + "Branch: " + lblCompany.Text))
        doc.Add(New Paragraph(Space(54) + "Redemption Voucher "))


        doc.Add(New Paragraph(Space(400)))
        doc.Add(New Paragraph(Space(82) + "Print Date: " + Now.ToString("dd-MM-yyyy hh:mm:ss tt")))
        doc.Add(New Paragraph(Space(100)))

        doc.Add(New Paragraph("Customer Code" + Space(6) + ": " + lblCustCd.Text.Trim()))
        doc.Add(New Paragraph("Name" + Space(21) + ": " + lblCustName.Text.Trim()))
        doc.Add(New Paragraph("Redeemed Date" + Space(5) + ": " + Convert.ToDateTime(lblRedDt.Text).ToString("dd-MM-yyyy hh:mm:ss tt")))
        doc.Add(New Paragraph("Voucher Number" + Space(4) + ": " + lblVoucherNo.Text.Trim()))
        doc.Add(New Paragraph("Accumulated Pnts" + Space(2) + ": " + lblAccPnts.Text.Trim()))
        doc.Add(New Paragraph("Total Red. Pnts" + Space(6) + ": " + lblRedPnts.Text.Trim()))
        doc.Add(New Paragraph("Current Redemption: " + lblCurrentRed.Text.Trim()))
        doc.Add(New Paragraph("Balance Points" + Space(7) + ": " + lblBalancePnts.Text.Trim()))
        doc.Add(New Paragraph("Narration" + Space(16) + ": " + lblNarration.Text.Trim()))



        Dim table As Table = New Table(6)
        'table.BorderWidth = 0
        table.BorderColor = New Color(0, 0, 255)

        table.Padding = 2
        table.Spacing = 1

        'Dim cell As Cell = New Cell("header")
        'cell.Header = True
        'cell.Colspan = 4
        'table.AddCell(cell)

        table.AddCell(Space(8) + "No")
        table.AddCell(" Item Code")
        table.AddCell(" Description")
        table.AddCell("  Quantity")
        table.AddCell(Space(6) + "Unit")
        table.AddCell(Space(4) + "Points")


        table.AddCell((Space(9) + lblSlNo.Text.Trim()))
        table.AddCell(lblItemcd.Text)
        table.AddCell(lblItem.Text)
        table.AddCell((Space(8) + lblQty.Text))
        table.AddCell((Space(5) + lblUnit.Text))
        table.AddCell((Space(3) + lblPoints.Text))

        '--Table----------
        'table.AddCell("No")
        'table.AddCell(lblVoucherNo.Text.Trim())
        'table.AddCell("Accumulated Points")
        'table.AddCell("cell")

        doc.Add(table)


        doc.Add(New Paragraph(Space(4000)))


        '--------------------------
        'Footer
        Dim tableF As Table = New Table(4)
        tableF.BorderWidth = 0

        tableF.BorderColor = New Color(0, 0, 255)

        tableF.Padding = 2
        tableF.Spacing = 1


        Dim cell As Cell = New Cell("Voucher No:")
        cell.Header = True
        cell.Colspan = 4
        tableF.AddCell(cell)

        cell = New Cell(Space(150) + "Prepared By")
        'cell.Rowspan = 2
        'cell.Colspan = 2
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.BackgroundColor = New Color(192, 192, 192)
        tableF.AddCell(cell)

        cell = New Cell(Space(150) + "Checked By")
        'cell.Rowspan = 2
        'cell.Colspan = 2
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.BackgroundColor = New Color(192, 192, 192)
        tableF.AddCell(cell)


        cell = New Cell(Space(150) + "Approved By")
        'cell.Rowspan = 2
        'cell.Colspan = 2
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.BackgroundColor = New Color(192, 192, 192)
        tableF.AddCell(cell)

        cell = New Cell(Space(150) + "Received By")
        'cell.Rowspan = 2
        'cell.Colspan = 2
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.BackgroundColor = New Color(192, 192, 192)
        tableF.AddCell(cell)


        doc.Add(tableF)


        Dim a As TableFooterRow = New TableFooterRow()
        'a.Control.Add(New Paragraph("z"))

        doc.Close()
        Response.Redirect("~/PDF/Voucher.pdf")
    End Sub
    'Sub ShowHello()
    '    Dim doc As Document = New Document
    '    PdfWriter.GetInstance(doc, New FileStream(Request.PhysicalApplicationPath + "\PDF\" + "1.pdf", FileMode.Create))
    '    doc.Open()
    '    doc.Add(New Paragraph("Hello World"))
    '    doc.Close()
    '    Response.Redirect("~/PDF/1.pdf")
    'End Sub
    Sub ShowTable()
        Dim doc As Document = New Document
        PdfWriter.GetInstance(doc, New FileStream(Request.PhysicalApplicationPath + "\2.pdf", FileMode.Create))
        doc.Open()
        Dim table As Table = New Table(3)
        table.BorderWidth = 1
        table.BorderColor = New Color(0, 0, 255)
        table.Padding = 3
        table.Spacing = 1

        Dim cell As Cell = New Cell("header")
        cell.Header = True
        cell.Colspan = 3
        table.AddCell(cell)

        cell = New Cell("example cell with colspan 1 and rowspan 2")
        cell.Rowspan = 2
        cell.BorderColor = New Color(255, 0, 0)
        table.AddCell(cell)
        table.AddCell("1.1")
        table.AddCell("2.1")
        table.AddCell("1.2")
        table.AddCell("2.2")
        table.AddCell("cell test1")

        cell = New Cell("big cell")
        cell.Rowspan = 2
        cell.Colspan = 2
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        cell.BackgroundColor = New Color(192, 192, 192)
        table.AddCell(cell)
        table.AddCell("cell test2")
        doc.Add(table)
        doc.Close()
        Response.Redirect("~/2.pdf")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ShowTable()
        '    'Create Document class obejct and set its size to letter and give space left, right, Top, Bottom Margin
        '    Dim doc As New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)
        '    Try
        '        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("F:\Test11.pdf", FileMode.Create))
        '        'Open Document to write
        '        doc.Open()

        '        'Write some content
        '        Dim paragraph As New Paragraph("This is my firstd line using Paragraph.")
        '        Dim pharse As New Phrase("This is my second line using Pharse.")
        '        Dim chunk As New Chunk(" This is my third line using Chunk.")
        '        ' Now add the above created text using different class object to our pdf document
        '        doc.Add(paragraph)
        '        doc.Add(pharse)
        '        doc.Add(chunk)
        '    Catch dex As DocumentException


        '        'Handle document exception
        '    Catch ioex As IOException
        '        'Handle IO exception
        '    Catch ex As Exception
        '        'Handle Other Exception
        '    Finally
        '        'Close document
        '        doc.Close()
        '    End Try
    End Sub
End Class
