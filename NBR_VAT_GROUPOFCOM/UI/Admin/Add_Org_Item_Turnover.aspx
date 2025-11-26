<%@ page title="" language="C#" theme="Theme1" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Add_Org_Item_Turnover, App_Web_fxp4hfg1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">

        .style1
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="page_title" colspan="2">
                Organization item turnover setup<uc1:admin ID="admin" runat="server" /></td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label3" runat="server" Text="Organization Name :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:DropDownList ID="ddlOrganization" runat="server" Width="302px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Item Name :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="True" Width="302px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="Label6" runat="server" Text="probable yearly turnover :"></asp:Label>
            </td>
            <td class="input_field">
                <asp:TextBox ID="txtTurnover" runat="server" Width="300px" MaxLength="16"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        onclick="btnSave_Click" Text="Save" />
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" 
                        onclick="btnRefresh_Click" Text="Refresh" />
                <asp:Button ID="btnShowList" runat="server" CssClass="button" 
                    Text="Show Turnover List" onclick="btnShowList_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:GridView ID="gvTurnover" runat="server" AutoGenerateColumns="False" 
                                                CssClass="sGrid" DataKeyNames="turnover_id" 
                    Width="100%" onrowdatabound="gvTurnover_RowDataBound" 
                    onrowdeleting="gvTurnover_RowDeleting" 
                    onselectedindexchanged="gvTurnover_SelectedIndexChanged" >
                    <Columns>
                        <asp:BoundField DataField="turnover_id" HeaderText="Turnover ID" 
                            Visible="False" />
                        <asp:BoundField DataField="Organization_Name" HeaderText="Organization Name">
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Item_name" HeaderText="Item Name" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="yearly_turnover" 
                            HeaderText="Probable Yearly Turnover" >
                        <ItemStyle />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" 
                            ShowSelectButton="True" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                                                    No Record Found.
                                                </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

