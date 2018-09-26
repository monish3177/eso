Imports nicmp.sch

Partial Class RPT_tehsils
    Inherits SCHBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("idq1") IsNot Nothing Then
                'Dim decbuff As Byte() = Convert.FromBase64String(Request.QueryString("idq1"))
                'Dim qsdata As String = System.Text.Encoding.UTF8.GetString(decbuff)
                'Dim i As Integer = qsdata.Length
                ' If qsdata <> String.Empty Then
                'Dim data As String() = qsdata.Split("|"c)
                If CommonMethods.CheckNumericString(Session("idq1")) Then
                    hdnDistID.Value = CommonMethods.Validate_String(Session("idq1"))
                    DdlState.DataSourceID = "DtsState"
                    DdlState.DataBind()
                    DdlState.SelectedValue = CommonMethods.Validate_String(20)
                    hdnStID.Value = 20
                    DdlState.Enabled = False
                    ddlDistrict.DataSourceID = "DtsDistrict"
                    ddlDistrict.DataBind()
                    ddlDistrict.SelectedValue = CommonMethods.Validate_String(Convert.ToString(hdnDistID.Value))
                    ddlDistrict.Enabled = False
                    GvTehsil.DataSourceID = "dsgrTehsil"
                    GvTehsil.DataBind()
                    back.Visible = True
                    Session.Abandon()
                Else
                    Response.Redirect("RPT_District.aspx")
                End If
                'Else
                '    DdlState.DataSourceID = "DtsState"
                '    DdlState.DataBind()
                '    DdlState.SelectedValue = CommonMethods.Validate_String(20)
                '    hdnStID.Value = CommonMethods.Validate_String(20)
                '    DdlState.Enabled = False
                '    ddlDistrict.DataSourceID = "DtsDistrict"
                '    ddlDistrict.DataBind()
                '    ddlDistrict.Enabled = True
                'End If
            Else
                DdlState.DataSourceID = "DtsState"
                DdlState.DataBind()
                DdlState.SelectedValue = CommonMethods.Validate_String(20)
                hdnStID.Value = CommonMethods.Validate_String(20)
                DdlState.Enabled = False
                ddlDistrict.DataSourceID = "DtsDistrict"
                ddlDistrict.DataBind()
                ddlDistrict.Enabled = True
                back.Visible = False
            End If
        End If
    End Sub
    Protected Sub DdlState_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlState.DataBound
        DdlState.Items.Insert(0, New ListItem("--Select--", "0"))
    End Sub
    Protected Sub DdlState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlState.SelectedIndexChanged
        hdnStID.Value = DdlState.SelectedValue
    End Sub
    Protected Sub ddlDistrict_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDistrict.DataBound
        ddlDistrict.Items.Insert(0, New ListItem("--Select--", "0"))
    End Sub
    Protected Sub ddlDistrict_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDistrict.SelectedIndexChanged
        'If CommonMethods.CheckNumericString(DdlState.SelectedValue) = True Then
        '    hdnStID.Value = CommonMethods.Validate_String(DdlState.SelectedValue)
        'Else
        '    hdnStID.Value = "0"
        'End If
        'If CommonMethods.CheckNumericString(ddlDistrict.SelectedValue) = True Then
        '    hdnDistID.Value = CommonMethods.Validate_String(ddlDistrict.SelectedValue)
        'Else
        '    hdnDistID.Value = "0"
        'End If

        'GvTehsil.DataSourceID = "dsgrTehsil"
        'GvTehsil.DataBind()
    End Sub
    Protected Sub dsgrTehsil_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles dsgrTehsil.Selecting
        e.Command.Parameters.Clear()
        e.Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@District_ID", CommonMethods.Validate_String(hdnDistID.Value)))
    End Sub
    Protected Sub back_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles back.Click

        Response.Redirect("RPT_District.aspx")
    End Sub
    Protected Sub btnCheckAuthentication_Click(sender As Object, e As EventArgs) Handles btnCheckAuthentication.Click
        If(ddlDistrict.SelectedIndex=0)
            MessageBox.Show("Select District First.")
            Exit Sub
        End If
        If Captcha.UserValidated Then
        If CommonMethods.CheckNumericString(DdlState.SelectedValue) = True Then
            hdnStID.Value = CommonMethods.Validate_String(DdlState.SelectedValue)
        Else
            hdnStID.Value = "0"
        End If
        If CommonMethods.CheckNumericString(ddlDistrict.SelectedValue) = True Then
            hdnDistID.Value = CommonMethods.Validate_String(ddlDistrict.SelectedValue)
        Else
            hdnDistID.Value = "0"
        End If
        GvTehsil.DataSourceID = "dsgrTehsil"
        GvTehsil.DataBind()
            Else 
                MessageBox.Show("ERROR:Please enter the code shown in image ")
        End If
    End Sub
End Class
