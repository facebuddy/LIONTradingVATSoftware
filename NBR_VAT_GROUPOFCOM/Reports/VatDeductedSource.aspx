<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_VatDeductedSource, App_Web_y1tsx4fu" %>
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
        
       .table_report ,.table_report th,.table_report td {
            border: 1px solid black;
            border-collapse: collapse;
        }
        .bold-text td{font-weight:700;}
        .text-right
        {
            text-align:right;
        }
        .text-center
        {
            text-align:center;
        }
        .table_report
        {
            width: 95%;  
            margin-left:10px; 
            margin-right:10px;
                     
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table align="center" class="brd_tbl_input">
 <tr>
            <td colspan="2" height="25" class="page_title">
               VAT Deducted at Source Summary Report<uc1:ReportsNav ID="ReportsNav1" runat="server" />
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
                &nbsp;</td>
            <td>
                <asp:Button ID="btnShow" runat="server"  Text="Show Report" CssClass="button" 
                    onclick="btnShow_Click" />
            </td>
        </tr>
        </table>
        <br>
        <asp:Literal runat="server" ID="lt_VatSourceDeducted"></asp:Literal>
</asp:Content>

