<%@ page title="Current Account 18" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_Current_Account_Form18, App_Web_y1tsx4fu" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>

<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 


  <table style="width:100%;">
        <tr>
            <td>
              </td>
            <td></td><td></td>
        </tr>
</table>
<br />
<table style="width: 60%;margin:0px auto" class="brd_tbl_input">
        <tr>
            <td colspan="4" height="25" class="page_title"> Current Account 18  <uc1:ReportsNav ID="ReportsNav1" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblYear" runat="server" Text="From Date :"></asp:Label>
            </td>
            <td >
                <ww:jQueryDatePicker ID="txtFromDate" runat="server" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
            <td align="right">
                <asp:Label ID="lblMonth" runat="server" Text="To Date :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="txtToDate" runat="server" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lblOrganization" runat="server" Text="Organization :"></asp:Label>
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

<center>
<%--    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
        AutoDataBind="true" HasCrystalLogo="False" ToolPanelView="None" 
        HasToggleGroupTreeButton="False" />--%>
</center>
<uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

