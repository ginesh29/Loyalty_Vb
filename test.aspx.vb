
Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Response.Write(Now.Date.ToString("dd-MM-yyyy hh:mm:ss tt"))
        Response.Write(Now.ToString("dd-MM-yyyy hh:mm:ss tt"))
    End Sub
End Class
