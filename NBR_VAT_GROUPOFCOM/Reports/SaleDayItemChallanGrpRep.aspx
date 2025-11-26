<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_SaleDayItemChallanGrpRep, App_Web_o1josinq" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
              
    <br />
    <br />
    <br />
    <br />
<table align="center" class="brd_tbl_input">
         <tr>
            <td colspan="2" height="25" class="page_title">
               Sale Statement <uc1:ReportsNav ID="ReportsNav1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Item :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlItem" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Date From :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" Width="300px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text=" Date To :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtpDateTo" runat="server" Width="300px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
        </tr>
         <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Challan No :"></asp:Label>
            </td>
            <td>
               
                <asp:TextBox ID="txtChallanNo" runat="server" Width="113px" ></asp:TextBox>
               
            &nbsp;<asp:RadioButton ID="rdItem" runat="server" Checked="True" 
                    GroupName="GroupBy" Text="By Item" />
                <asp:RadioButton ID="rdChlnNo" runat="server" GroupName="GroupBy" 
                    Text="By Challan No" />
               
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" 
                    Text="Show Report" CssClass="button" />
            </td>
        </tr>
        </table>
    <br />
<%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl="" 
        ToolPanelView="None" ToolPanelWidth="200px" Width="350px" 
        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
        onunload="CrystalReportViewer1_Unload" />--%>
</asp:Content>

