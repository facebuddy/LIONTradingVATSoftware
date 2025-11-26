<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="VMSXML_VMSXML, App_Web_t4sudhzn" %>

<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>

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
                VAT-16</td>
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
            <td class="style1" align="center" colspan="2">
                <asp:Button ID="GenerateXML" runat="server" Text="Generate XML" CssClass="button"
                    onclick="GenerateXML_Click2" />
                
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

