<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_zewpzv5m" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/Production.ascx" tagname="production" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    
    <br />
<br />
<br />
<table align="center" id="tblCurrencyConvertion" runat="server"  bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input"  >
            <tr>
                <td colspan="2" class="page_title" height="30">
                    Bandroll<uc1:production ID="production" runat="server" /></td>
            </tr>
             <tr>
                <td class="input_item">
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="lblCurrencyID3" runat="server" Text="Bandroll Type :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="drpBandrollType" runat="server" Width="220px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="lblUnitName" runat="server" Text="Length :"></asp:Label>
                </td>
                <td align="left" >
        <asp:TextBox ID="txtUBandLength" runat="server" Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="lblUnitCode" runat="server" Text="Width :"></asp:Label>
                </td>
                <td align="left" >
        <asp:TextBox ID="txtBandWidth" runat="server" Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="Label1" runat="server" Text="Color Design :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:TextBox ID="txtBandColor" runat="server" TextMode="MultiLine" 
                        Width="215px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save"
                        height="30px" CssClass="button" Width="72px" onclick="btnSave_Click" />


                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        Height="30px" CssClass="button" Width="73px" onclick="btnCancel_Click" />
                    <asp:Button ID="btnShowHideData" runat="server" Text="Show All Record(s)" 
                        height="30px" CssClass="button" 
                        Width="160px" onclick="btnShowHideData_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="dgvBandrollItem" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="btype" HeaderText="Bandroll Type" />
                        <asp:BoundField DataField="length" HeaderText="Length" />
                        <asp:BoundField DataField="width" HeaderText="Width" />
                        <asp:BoundField DataField="color_design" HeaderText="Color Design" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
                </td>
            </tr>
            </table>

<uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

