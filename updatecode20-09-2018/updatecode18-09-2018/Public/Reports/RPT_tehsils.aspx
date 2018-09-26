<%@ Page Language="VB" MasterPageFile="~/MasterPages/Public.master" AutoEventWireup="false"
    CodeFile="RPT_tehsils.aspx.vb" Inherits="RPT_tehsils" Title="Scholarship Portal Punjab : List of Tehsils"
    Theme="ThemeRoller" %>
<%@ Register TagPrefix="cc" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="dpPH" runat="Server">
    <div id="GridPageHeader">
        <div class="ui-dialog ui-widget ui-widget-content ui-corner-all" style="width: 100%;
            min-height: 300px; position: relative;">
            <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
                <span id="ui-dialog-title-dialog" class="ui-dialog-title">
                    <%= Resources.Public.rptHeadingTehsil%></span> <a class="ui-dialog-titlebar-close ui-corner-all"
                        onclick="parent.history.back(); return false;">
                        <img src="http://mpsc.mp.nic.in/gacdn/Common/Images/button_cancel.png" style="width: 15px;"
                            alt="Close" /></a>
            </div>
            <div style="text-align: right">
                <asp:ImageButton ID="back" runat="server" Text="Back" ImageUrl="http://mpsc.mp.nic.in/gacdn/iccems/stylesheets/images/backbuttonicon.png" />
                <div style="min-height: 109px; width: 100%; text-align: center;" class="ui-dialog-content ui-widget-content">
                    <center>
                        <div style="width: 96%; text-align: center; background-color: White;" class="ui-widget-content">
                            HELP - This page displays list of tehsils under selected district of punjab. To
                            view the list of tehsils please select district.
                        </div>
                        <div style="width: 96%; padding-top: 6px;">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 20%; text-align: right;">
                                        <span class="ui-widget">
                                            <%=Resources.public.lblState %></span>
                                    </td>
                                    <td style="width: 30%; text-align: left;">
                                        <asp:DropDownList ID="DdlState" runat="server" DataSourceID="DtsState" DataTextField="State_Name"
                                            DataValueField="ID" AutoPostBack="true" Font-Bold="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20%; text-align: right;">
                                        <span class="ui-widget">
                                            <%=Resources.Public.lblDistrict  %></span>
                                    </td>
                                    <td style="width: 30%; text-align: left;">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" DataSourceID="DtsDistrict" DataTextField="District_Name"
                                            DataValueField="ID" AutoPostBack="true">
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
                                    <td colspan ="4">
                                        <center>
                                        <asp:Button ID="btnCheckAuthentication" runat="server" TabIndex ="4" Text="View"  CssClass="ui-button ui-button-text-only ui-widget ui-state-default ui-corner-all" OnClick="btnCheckAuthentication_Click" />
                                        </center> </td>  </tr>
                            </table>
                            <br />
                            <div class="ui-state-default" style="width: 96%;">
                                <h4>
                                    <%= Resources.Public.rptHeadingTehsil%></h4>
                            </div>
                            <div style="padding-top: 5px; width: 96%;">
                                <asp:GridView ID="GvTehsil" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                    AlternatingRowStyle-BackColor="LightBlue" RowStyle-Font-Size="11px" EmptyDataText="There are no record"
                                    Width="34%" AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                                <asp:HiddenField ID="Hdn_ID" runat="server" Value='<%#Eval("ID")%>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Tehsil_Name" HeaderText="<%$Resources:Masters,TehsilName %>"
                                            ItemStyle-HorizontalAlign="Left" SortExpression="Tehsil_Name" />
                                        <%--<asp:BoundField DataField="Tehsil_Name_LL" HeaderText="<%$Resources:Masters, TehsilNameLL%>"
                                        ItemStyle-HorizontalAlign="Left" SortExpression="Tehsil_Name_LL" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:SqlDataSource ID="dsgrTehsil" runat="server" ConnectionString="<%$ ConnectionStrings:SS8SCHP %>"
                                ProviderName="<%$ ConnectionStrings:SS8SCHP.ProviderName %>" SelectCommand="[Masters].[Tehsil_List]"
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="DtsDistrict" runat="server" ConnectionString="<%$ ConnectionStrings:SS8SCHP %>"
                                ProviderName="<%$ ConnectionStrings:SS8SCHP.ProviderName %>" SelectCommand="[Masters].[District_List]"
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnStID" DefaultValue="0" Name="State_ID" PropertyName="Value"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="DtsState" runat="server" ConnectionString="<%$ ConnectionStrings:SS8SCHP %>"
                                ProviderName="<%$ ConnectionStrings:SS8SCHP.ProviderName %>" SelectCommand="[Masters].[State_List]"
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                    </center>
                    <asp:HiddenField ID="hdnStID" runat="server" />
                    <asp:HiddenField ID="hdnDistID" runat="server" />
                </div>
            </div>
        </div>
        <%--    <div id="MsgFade" visible="false" class="ui-widget-overlay" runat="server">
    </div>
    <div id="LockMsg" runat="server" visible="false" class="ui-dialog ui-widget ui-widget-content ui-corner-all ui-resizable "
        style="width: 547px; z-index: 2000;">
      <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <span class="ui-dialog-title">Message</span><a class="ui-dialog-titlebar-close ui-corner-all"
                href="/public/reports/RPT_tehsils.aspx?SID=0&DISTID=0"> <span class="ui-icon ui-icon-closethick">
                    close</span></a>
        </div>
       <div class="ui-dialog-content ui-widget-content">
            <table width="100%">
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblLockInfo" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button runat="server" ID="btnOK" Text="OK" />
                    </td>
                </tr>
            </table>
        </div>--%>
        <%--</div>--%>
    </div>
</asp:Content>
