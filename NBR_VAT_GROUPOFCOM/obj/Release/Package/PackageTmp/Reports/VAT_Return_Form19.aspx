<%@ page title="VAT Return" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_VAT_Return_Form19, App_Web_o1josinq" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
 
     <table style="width:100%;">
        <tr>
            <td>
              </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
</table>
<br />

<table style="width: 60%;margin:0px auto" class="brd_tbl_input">
        <tr>
            <td colspan="4" height="25" class="page_title"> VAT Return  <uc1:ReportsNav ID="ReportsNav1" runat="server" /> </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblYear" runat="server" Text="Year :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpYear" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblMonth" runat="server" Text="Month :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpMonth" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblOrganization" runat="server" Text="Organization :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpOrganization" runat="server">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>
                <asp:Button ID="btnShow" runat="server" CssClass="button" 
                        onclick="btnShow_Click" Text="Show Report" />
                </td>
        </tr>
</table>


<br />
<%--    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" HasCrystalLogo="False" ToolPanelView="None" 
        GroupTreeImagesFolderUrl="" Height="50px" 
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />--%>
    <br />
<uc2:MsgBox ID="msgBox" runat="server" />


</asp:Content>

