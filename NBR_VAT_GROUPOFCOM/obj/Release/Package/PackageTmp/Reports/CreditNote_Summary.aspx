<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_o1josinq" %>

<%@ Register Src="../UserControls/ReportsNav.ascx" TagName="ReportsNav" TagPrefix="uc1" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <br />
    <br />
    <br />
    <br />
    <br />
    <table align="center" class="brd_tbl_input">
        <tr>
            <td colspan="4" height="25" class="page_title">
                ক্রেডিট নোট সারসংক্ষেপ <uc1:ReportsNav ID="ReportsNav2" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="Label2" runat="server" Text="ক্রেডিট নোট প্রদানের তারিখ :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" Width="120px" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                <asp:Label ID="Label5" runat="server" Text="হইতে"></asp:Label>
                <ww:jQueryDatePicker ID="dtpDateTo" runat="server" Width="120px" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                <asp:Label ID="Label6" runat="server" Text="পর্যন্ত"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="2">
                &nbsp;
                <asp:Button ID="btnShow" runat="server" Text="Show Report" CssClass="button" OnClick="btnShow_Click" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <center>
<%--        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            HasCrystalLogo="False" ToolPanelView="None" HasToggleGroupTreeButton="False" />--%>
    </center>
</asp:Content>
