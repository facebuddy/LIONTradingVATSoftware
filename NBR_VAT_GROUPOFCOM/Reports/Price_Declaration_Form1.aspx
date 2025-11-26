<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_Price_Declaration_Form1, App_Web_xijeoyc2" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register Assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
    <%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
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
            <td class="page_title" colspan="2">
                মূল্য ঘোষণাপত্র - (মূসক-১) <uc1:ReportsNav ID="ReportsNav1" runat="server" /></td>
        </tr>
        <tr>
            <td class="style1">
              
                <asp:Label ID="Label1" runat="server" Text="পণ্যের নাম - "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlItemName" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlItemName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblPriceDeclarationNumber0" runat="server"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:Label ID="lblPriceDeclarationNumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Button ID="btnShow" runat="server" CssClass="button" 
                    onclick="btnShow_Click" Text="Show Report" />
            </td>
        </tr>
        </table>

    <br />
<%--<cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl="" 
        ToolPanelView="None" ToolPanelWidth="200px" Width="350px" 
        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
        onunload="CrystalReportViewer1_Unload" />--%>
        <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

