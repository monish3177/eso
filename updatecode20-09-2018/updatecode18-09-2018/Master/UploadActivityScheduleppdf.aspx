<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/Masters.master" AutoEventWireup="false" CodeFile="UploadActivityScheduleppdf.aspx.vb" Inherits="Masters_UploadActivityScheduleppdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="dpPH" Runat="Server">
    <center>

  <table><tr>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Solid"  />
            <asp:Button ID="btnUpload" CssClass="button" TabIndex="3"   style="cursor:pointer;" runat="server" Text="Upload"></asp:Button>
            <asp:Label ID="lblmsg" ForeColor ="Green" runat ="server" ></asp:Label>
        </td>
    </tr></table>
    </center>
</asp:Content>

