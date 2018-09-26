<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Public.master" AutoEventWireup="true" CodeFile="AadharAuthenticationaspx.aspx.cs" Inherits="Public_AadharAuthenticationaspx" %>
    <%@ Register TagPrefix="cc" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="dpPH" Runat="Server">


        <script type="text/javascript" src="../JavaScript/Validations.js"></script>
    <center>
    <br />
    <br />

        <h2>Aadhaar Authentication</h2>

     <table  style="width: 100%;">
         <tr>
            <td style="text-align: right;font:bold ";  align="center"><b>Aadhaar Number : </b></td>
            <td>
                <asp:TextBox ID="txtAadhaarNumber" Width ="180PX" runat="server" 
                     MaxLength="12" onkeypress="return NumberOnly(event)" TabIndex ="1" AutoPostBack="true"
                     OnTextChanged="txtAadhaarNumber_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right;font:bold ";  align="center"><b>Name : </b></td>
            <td>
                <asp:TextBox ID="txtname"   Width ="180PX" runat="server" onkeypress="return CharspaceOnly(event)" TabIndex ="2"></asp:TextBox></td>
        </tr>
         <tr>
           
            <td  style="text-align: right;font:bold ";    align="center"><b>Gender :</b> </td>
            <td>
                <asp:DropDownList ID="ddlGender"  Width ="180PX" runat="server" TabIndex ="3">
                    <asp:ListItem Value="0">Select  </asp:ListItem>
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
                </td> 
        </tr>
         <tr>
             <td colspan="4" style="border: thin double #FF0000; text-align: right;" align="center">
                 <%-- <div class="Slider">
                            </div>--%>
                 <cc:CaptchaControl ID="Captcha" runat="server" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXY3456789"
                                    CaptchaLength="4" LayoutStyle="Vertical" ShowSubmitButton="False" Font-Bold="True"
                                    Text="Please enter the code shown above " Font-Names="Arial" Font-Size="Small" TabIndex="31"></cc:CaptchaControl>
             </td>
         </tr>
        <tr>
            <td colspan ="2">
                <br />
                <center >
                <asp:Button ID="btnCheckAuthentication" runat="server" TabIndex ="4" Text="Authenticate"  CssClass="ui-button ui-button-text-only ui-widget ui-state-default ui-corner-all" OnClick="btnCheckAuthentication_Click" />
                    <asp:Button ID="Button1" runat="server"  PostBackUrl ="~/Default.aspx" CssClass="ui-button ui-button-text-only ui-widget ui-state-default ui-corner-all" Text="Back to Home Page" />
                    
                    <br />
           </center> </td>
        </tr>
         <tr>
             <td colspan ="2">
                 <center >
                     <asp:Label ID="lblmsg" runat="server" BackColor="Yellow" Font-Bold="True" Font-Size="Medium"></asp:Label>
                 </center>
             </td>
         </tr>
    </table>
        </center>
        
</asp:Content>

