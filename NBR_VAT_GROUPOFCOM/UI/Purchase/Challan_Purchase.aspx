<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Purchase_Challan_Purchase, App_Web_attcokcq" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/Purchase.ascx" tagname="purchase" tagprefix="uc1" %>

<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td class="page_title" colspan="4" align="center">
                Purchase Challan (মূসক-১১)<uc1:purchase ID="purchase" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Text="Saler TIN :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerTIN" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Saler Name :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" class="style1">
                <asp:Label ID="Label2" runat="server" Text="Address :"></asp:Label>
            </td>
            <td class="style1" colspan="3">
                <asp:TextBox ID="txtAddress0" runat="server" Rows="1" TextMode="MultiLine" 
                    Width="410px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top" colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label14" runat="server" Text="Challan Sl. No. :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtCustomerTIN0" runat="server"></asp:TextBox>
            </td>
            <td class="input_field">
                <asp:Label ID="Label15" runat="server" Text="Date :"></asp:Label>
            </td>
            <td class="input_field">
                <ww:jQueryDatePicker ID="dtpDate" runat="server"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label27" runat="server" Text="Transport Type :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:DropDownList ID="ddlItem0" runat="server">
                    <asp:ListItem>Truck</asp:ListItem>
                    <asp:ListItem>Lorry</asp:ListItem>
                    <asp:ListItem>Van</asp:ListItem>
                    <asp:ListItem>Rickshwa</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="input_field">
                <asp:Label ID="Label28" runat="server" Text="Transport No :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtCustomerTIN1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label4" runat="server" Text="Shipping Address :"></asp:Label>
            </td>
            <td class="input_field" rowspan="3" valign="top">
                <asp:TextBox ID="txtAddress" runat="server" Rows="5" TextMode="MultiLine" 
                    Width="143px"></asp:TextBox>
            </td>
            <td class="input_field">
                <asp:Label ID="Label16" runat="server" Text="Time :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                &nbsp;</td>
            <td class="input_field">
                <asp:Label ID="Label5" runat="server" Text="Unload Real Date :"></asp:Label>
            </td>
            <td class="input_field">
                <ww:jQueryDatePicker ID="dtpUnloadRealDate" runat="server"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                &nbsp;</td>
            <td class="input_field">
                <asp:Label ID="Label6" runat="server" Text="Unload Real Time :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtUnloadRealTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top" colspan="4">
                <hr /></td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label18" runat="server" Text="Item :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:DropDownList ID="ddlItem" runat="server">
                </asp:DropDownList>
            </td>
            <td class="input_field">
                <asp:Label ID="Label19" runat="server" Text="Workorder No :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtEmail0" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label21" runat="server" Text="Bank Branch :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
            </td>
            <td class="input_field">
                <asp:Label ID="Label20" runat="server" Text="Workorder Date :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtEmail1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label22" runat="server" Text="Quantity :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtBankCode" runat="server"></asp:TextBox>
            </td>
            <td class="input_field">
                <asp:Label ID="Label23" runat="server" Text="SD :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtEmail2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label7" runat="server" Text="SD Price :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtAbbreviation" runat="server"></asp:TextBox>
            </td>
            <td class="input_field">
                <asp:Label ID="Label24" runat="server" Text="VAT Price :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtEmail3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label25" runat="server" Text="VAT :"></asp:Label>
            </td>
            <td style="text-align: left" class="style2">
                <asp:TextBox ID="txtEmail5" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: left" class="style2">
                <asp:Label ID="Label26" runat="server" Text="Total Price :"></asp:Label>
            </td>
            <td style="text-align: left" class="style2">
                <asp:TextBox ID="txtEmail4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right" colspan="3">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Button ID="btnSaveItem" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save Item" />
                    <asp:Button ID="btnRefreshItem" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                    <asp:Button ID="btnShowItemList" runat="server" CssClass="button" 
                    onclick="btnShowBankList_Click" Text="Show Item List" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvBank" runat="server" AutoGenerateColumns="False" 
                    CssClass="sGrid" DataKeyNames="bank_id" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="bank_id" HeaderText="Bank ID" Visible="False" />
                        <asp:BoundField DataField="Bank_Code" HeaderText="Bank Code" />
                        <asp:BoundField DataField="bank_name" HeaderText="Bank Name">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="abbr_name" HeaderText="Abbreviation" />
                        <asp:BoundField DataField="address" HeaderText="Address">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="phone" HeaderText="Phone" ItemStyle-Wrap="false">
                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="email" HeaderText="Email">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Url" HeaderText="Url" Visible="False">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
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
        <tr>
            <td colspan="4" align="right">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="btnSaveChallan" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save Challan" />
                    <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                </asp:Panel>
            </td>
        </tr>
    </table>
    </div>
        <p><br /></p>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

