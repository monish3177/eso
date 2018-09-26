Imports NicMp.sch
Partial Class Masters_UploadActivityScheduleppdf
      Inherits SCHBase

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim folderpath As String = Server.MapPath("~/Public/")
        If Not Directory.Exists(folderpath) Then
            Directory.CreateDirectory(folderpath)
        End If
        Dim filename As String
        filename = "Scholarship_Activity_Schedule.pdf"
        FileUpload1.SaveAs(folderpath & Path.GetFileName(filename))
        lblmsg.Text = Path.GetFileName(FileUpload1.FileName) + "has been uploaded"
    End Sub
End Class
