<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_Challan, App_Web_pj2ymx2u" %>
<%--<%@ Register Assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <table style="width:100%;">
        <tr>
            <td>
               <uc1:ReportsNav ID="ReportsNav1" runat="server" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <br />
<%--    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" ToolPanelView="None" />--%>
</asp:Content>

