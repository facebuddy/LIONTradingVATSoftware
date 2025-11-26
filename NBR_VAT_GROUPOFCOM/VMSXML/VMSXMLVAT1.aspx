<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="VMSXML_VMSXML, App_Web_vs2diukm" %>

<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <table align="center" class="brd_tbl_input">
        <tr>
            <td colspan="2" height="25" class="page_title">
                VMS XML
                VAT-1</td>
        </tr>
        <tr>
            <td class="style1" align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="Label4" runat="server" Text="XML For :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpPartyName" runat="server" Width="300px">
                    <asp:ListItem>VAT_1</asp:ListItem>
                    <asp:ListItem>VAT_11</asp:ListItem>
                    <asp:ListItem>VAT_16</asp:ListItem>
                    <asp:ListItem>VAT_17</asp:ListItem>
                    <asp:ListItem>VAT_18</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="Label5" runat="server" Text="XML For :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSessionValue" runat="server" Height="22px" Width="296px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
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
            <td class="style1" align="center" colspan="2">
                &nbsp;
                <asp:Button ID="GenerateXML" runat="server" Text="Generate XML" 
                    CssClass="button" onclick="GenerateXML_Click1"  />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <uc2:MsgBox ID="msgBox" runat="server" />
    <br />
</asp:Content>

