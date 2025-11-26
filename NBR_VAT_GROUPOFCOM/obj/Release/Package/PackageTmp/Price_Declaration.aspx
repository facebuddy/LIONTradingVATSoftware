<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Price_Declaration, App_Web_qr4mw4bg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style3
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td class="page_title" colspan="9" align="center">
                Price Declaration (মূসক-১)</td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" class="style3">
                <asp:Label ID="Label8" runat="server" Text="Registration Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label86" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="M/S. Minuddin &amp; Sons"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:Label ID="Label14" runat="server" Text="Registration No."></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label89" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Text="5141024740"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="Label27" runat="server" Text="Area Code"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label90" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label28" runat="server" Text="50401"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" class="style3">
                <asp:Label ID="Label9" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label87" runat="server" Text=":"></asp:Label>
            </td>
            <td colspan="4">
                <asp:Label ID="Label12" runat="server" Text="70 Green Road, Dhaka"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="Label10" runat="server" Text="Telephone"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label91" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label30" runat="server" Text="9564162"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" class="style3">
                <asp:Label ID="Label29" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label88" runat="server" Text=":"></asp:Label>
            </td>
            <td colspan="4">
                <asp:Label ID="Label32" runat="server" Text="admin@minuddinsons.com"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="Label16" runat="server" Text="Fax"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label92" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label31" runat="server" Text="880-2-9567845"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" class="style3">
                <asp:Label ID="Label3" runat="server" Text="Price Declaration No."></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label85" runat="server" Text=":"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtDeclaratioNo" runat="server" Width="100px"></asp:TextBox>
                /<asp:TextBox ID="txtDeclarationYear" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" colspan="9">
                <hr /></td>
        </tr>
        <tr>
            <td valign="top" colspan="9">
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" 
                    border="0px">
        <tr>
            <td valign="top">
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td valign="top" colspan="4" class="page_title">
                <asp:Label ID="Label84" runat="server" Text="Items"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label66" runat="server" Text="H.S.Code"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label81" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList8" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label67" runat="server" Text="Description"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label68" runat="server" Text="Name"></asp:Label>
            </td>
            <td >
                <asp:Label ID="Label80" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBankName3" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td rowspan="2" valign="top">
                <asp:TextBox ID="txtAddress4" runat="server" Rows="2" TextMode="MultiLine" 
                    Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label69" runat="server" Text="Unit"></asp:Label>
            </td>
            <td class="style1">
                <asp:Label ID="Label79" runat="server" Text=":"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="DropDownList9" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top" colspan="4">
                <hr /></td>
        </tr>
        <tr>
            <td class="style1" valign="top" colspan="4">
                <asp:Panel ID="Panel3" runat="server">
                    <asp:Button ID="btnSaveItem0" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save Item" />
                    <asp:Button ID="btnRefreshItem0" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                    <asp:Button ID="btnShowItemList0" runat="server" CssClass="button" 
                    onclick="btnShowBankList_Click" Text="Show Item List" />
                </asp:Panel>
            </td>
        </tr>
        </table>
            </td>
            <td valign="top">
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td valign="top" colspan="6" class="page_title">
                Raw Meterials</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label55" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label73" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerTIN4" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label70" runat="server" Text="Unit"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label78" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label56" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label74" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerTIN11" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label71" runat="server" Text="U_Price"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label77" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerTIN10" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label58" runat="server" Text="Deprication"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label75" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerTIN12" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label72" runat="server" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label76" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBankName1" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top" colspan="6">
                <hr /></td>
        </tr>
        <tr>
            <td valign="top" colspan="6">
                <asp:Panel ID="Panel4" runat="server">
                    <asp:Button ID="btnSaveItem1" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save" />
                    <asp:Button ID="btnRefreshItem1" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                    <asp:Button ID="btnShowItemList1" runat="server" CssClass="button" 
                    onclick="btnShowBankList_Click" Text="Show Raw Meterial List" />
                </asp:Panel>
            </td>
        </tr>
        </table>
            </td>
            <td valign="top">
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td valign="top" colspan="3" class="page_title">
                <asp:Label ID="Label83" runat="server" Text="Value Added"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label49" runat="server" Text="Item Name"></asp:Label>
            </td>
            <td class="style1">
                :</td>
            <td class="style1">
                <asp:TextBox ID="txtCustomerTIN2" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label51" runat="server" Text="Amount"></asp:Label>
            </td>
            <td>
                :</td>
            <td class="style1">
                <asp:TextBox ID="txtCustomerTIN3" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                <hr /></td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                <asp:Panel ID="Panel5" runat="server">
                    <asp:Button ID="btnSaveItem2" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save" />
                    <asp:Button ID="btnRefreshItem2" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                    <asp:Button ID="btnShowItemList2" runat="server" CssClass="button" 
                    onclick="btnShowBankList_Click" Text="Show Item List" />
                </asp:Panel>
            </td>
        </tr>
        </table>
            </td>
        </tr>
        </table>
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <hr /></td>
        </tr>
        <tr>
            <td colspan="9" style="text-align: right">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="btnSaveChallan" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save Declaration" />
                    <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="9">
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
            <td colspan="9" align="right">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    <p><br /></p>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

