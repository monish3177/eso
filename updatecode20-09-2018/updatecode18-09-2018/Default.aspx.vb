Imports nicmp.sch
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim InsertResult As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If User.Identity.IsAuthenticated Then
            Session.Abandon()
            FormsAuthentication.SignOut()
            Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", "You are signed out."))
            hdnisauthendicate.Value = 1
            ClientScript.RegisterStartupScript(Me.GetType(), "", "alert('You are now sign out.');window.location.reload(true);", True)
        End If
        If Session("StateID") > 0 Then
            Session("StateID") = 0
        End If
        FillData()
        CheckMenuPermission()
        'FillDataYear2012_13()
        'FillDataYear2011_12()
    End Sub
    Private Sub CheckMenuPermission()
        Dim fil_dst As New DataSet
        Dim FillDatas As New StateAdmin(ConfigurationManager.ConnectionStrings("SS8SCHP").ToString)
        ' Dim ID As Integer
        fil_dst = FillDatas.Process_Permission()
    
        If (fil_dst.Tables(0).Rows(0)("Studentregistertaion").ToString() = 0) Then
            studentreglnk.Visible = False
        Else
            studentreglnk.Visible = True
        End If

    End Sub
    Sub FillData()
        Dim fil_dst As New DataSet
        Dim FillData As New StateAdmin(ConfigurationManager.ConnectionStrings("SS8SCHP").ToString)
        fil_dst = FillData.ApplicationSummaryonInstituteSanctionLevel(0)
        If fil_dst.Tables(0).Rows.Count <> 0 Then
            'lblTApending.Text = fil_dst.Tables(0).Rows(0)("InsPend").ToString
            'lblTAaccepted.Text = fil_dst.Tables(0).Rows(0)("InsDP").ToString
            'lblTATRejected.Text = fil_dst.Tables(0).Rows(0)("InsTR").ToString
            'lblTAPRejected.Text = fil_dst.Tables(0).Rows(0)("InsPR").ToString
            'lblTALocked.Text = fil_dst.Tables(0).Rows(0)("SancPP").ToString
        End If
        If fil_dst.Tables(1).Rows.Count <> 0 Then
            'lblSTApending.Text = fil_dst.Tables(0).Rows(0)("SanPD").ToString
            'lblSTAAccepted.Text = fil_dst.Tables(1).Rows(0)("SancDS").ToString
            'lblSATRejected.Text = fil_dst.Tables(1).Rows(0)("SancTR").ToString
            'lblSAPRejected.Text = fil_dst.Tables(1).Rows(0)("SancPR").ToString
            'lblSTALocked.Text = fil_dst.Tables(1).Rows(0)("SancLS").ToString
        End If
    End Sub


    'Sub FillDataYear2012_13()
    '    Dim fil_dst As New DataSet
    '    Dim FillData As New StateAdmin(ConfigurationManager.ConnectionStrings("SS8SCHP").ToString)
    '    fil_dst = FillData.ApplicationSummaryonInstituteSanctionLevel(3)
    '    If fil_dst.Tables(0).Rows.Count <> 0 Then
    '        lbl1TApending.Text = fil_dst.Tables(0).Rows(0)("InsPend").ToString
    '        lbl1TAaccepted.Text = fil_dst.Tables(0).Rows(0)("InsDP").ToString
    '        lbl1TATRejected.Text = fil_dst.Tables(0).Rows(0)("InsTR").ToString
    '        lbl1TAPRejected.Text = fil_dst.Tables(0).Rows(0)("InsPR").ToString
    '        lbl1TALocked.Text = fil_dst.Tables(0).Rows(0)("SancPP").ToString
    '    End If
    '    If fil_dst.Tables(1).Rows.Count <> 0 Then
    '        lbl1STApending.Text = fil_dst.Tables(0).Rows(0)("SanPD").ToString
    '        lbl1STAAccepted.Text = fil_dst.Tables(1).Rows(0)("SancDS").ToString
    '        lbl1SATRejected.Text = fil_dst.Tables(1).Rows(0)("SancTR").ToString
    '        lbl1SAPRejected.Text = fil_dst.Tables(1).Rows(0)("SancPR").ToString
    '        lbl1STALocked.Text = fil_dst.Tables(1).Rows(0)("SancLS").ToString
    '    End If
    'End Sub


    'Sub FillDataYear2011_12()
    '    Dim fil_dst As New DataSet
    '    Dim FillData As New StateAdmin(ConfigurationManager.ConnectionStrings("SS8SCHP").ToString)
    '    fil_dst = FillData.ApplicationSummaryonInstituteSanctionLevel(2)
    '    If fil_dst.Tables(0).Rows.Count <> 0 Then
    '        lbl2TApending.Text = fil_dst.Tables(0).Rows(0)("InsPend").ToString
    '        lbl2TAaccepted.Text = fil_dst.Tables(0).Rows(0)("InsDP").ToString
    '        lbl2TATRejected.Text = fil_dst.Tables(0).Rows(0)("InsTR").ToString
    '        lbl2TAPRejected.Text = fil_dst.Tables(0).Rows(0)("InsPR").ToString
    '        lbl2TALocked.Text = fil_dst.Tables(0).Rows(0)("SancPP").ToString
    '    End If
    '    If fil_dst.Tables(1).Rows.Count <> 0 Then
    '        lbl2STApending.Text = fil_dst.Tables(0).Rows(0)("SanPD").ToString
    '        lbl2STAAccepted.Text = fil_dst.Tables(1).Rows(0)("SancDS").ToString
    '        lbl2SATRejected.Text = fil_dst.Tables(1).Rows(0)("SancTR").ToString
    '        lbl2SAPRejected.Text = fil_dst.Tables(1).Rows(0)("SancPR").ToString
    '        lbl2STALocked.Text = fil_dst.Tables(1).Rows(0)("SancLS").ToString
    '    End If
    'End Sub
    
 
   
End Class
