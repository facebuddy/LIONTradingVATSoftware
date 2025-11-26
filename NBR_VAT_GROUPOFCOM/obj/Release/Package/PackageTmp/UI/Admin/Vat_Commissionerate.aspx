<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_4urmxq31" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="page_title" colspan="4">
                VAT Commissionerate<uc1:admin ID="admin" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top" class="style1">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" class="style1" align="right">
                    <asp:Label ID="lblCommName" runat="server" Text="Commissonerate Name : "></asp:Label>
            </td>
            <td>
                    <asp:TextBox ID="txtCommName" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td align="right">
                    <asp:Label ID="lblDiv" runat="server" Text="Commissionerate Code : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCommCode" runat="server" Width="80px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1" valign="top" rowspan="3" align="right">
                    <asp:Label ID="lblComAdd" runat="server" Text="Address : "></asp:Label>
            </td>
            <td class="input_field" rowspan="3">
                    <asp:TextBox ID="txtComAdd" runat="server" TextMode="MultiLine" 
                    Height="70px" Width="250px"></asp:TextBox>
            </td>
            <td class="input_field" align="right">
                    <asp:Label ID="lblComPhone" runat="server" Text="Phone # : "></asp:Label>
            </td>
            <td class="input_field">
                    <asp:TextBox ID="txtComPhone" runat="server" Width="130px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="input_field" align="right">
                    <asp:Label ID="lblCommUpazillaId" runat="server" Text="Upazilla Name : "></asp:Label>
            </td>
            <td class="input_field">
                    <asp:DropDownList ID="drpUpazillaName" runat="server" Width="130px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="drpUpazillaName_SelectedIndexChanged">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="input_field" align="right">
                    <asp:Label ID="lblComUnionId" runat="server" Text="Union/Ward Name : "></asp:Label>
            </td>
            <td class="input_field">
                    <asp:DropDownList ID="drpUnionWardName" runat="server" Width="130px" 
                        onselectedindexchanged="drpUnionWardName_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="4">
                <asp:Button ID="btnSave" runat="server" CssClass="button" 
                     Text="Save" onclick="btnSave_Click"  />
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" 
                     Text="Refresh" onclick="btnRefresh_Click" />
                <asp:Button ID="btnShowCommissionerateList" runat="server" CssClass="button" 
                     Text="Show Commissionerate List" 
                    onclick="btnShowCommissionerateList_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                <center>
                <asp:GridView ID="dgvVatCommissonerate" runat="server" AutoGenerateColumns="False" 
                    CssClass="sGrid" DataKeyNames="comm_id" Width="600px" 
                        onrowdeleting="dgvVatCommissonerate_RowDeleting" 
                        onselectedindexchanged="dgvVatCommissonerate_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="comm_id" HeaderText="Commissionerate ID" 
                            Visible="False" />
                        <asp:BoundField DataField="comm_name" HeaderText="Commissionerate Name" 
                            DataFormatString="{0:000}" />
                        <asp:BoundField DataField="comm_code" HeaderText="Commissionerate Code">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="address" HeaderText="Address" />
                        <asp:BoundField DataField="phone_no" HeaderText="Phone No">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="uName" HeaderText="Upazilla" 
                            ItemStyle-Wrap="false">
                        <ItemStyle HorizontalAlign="Left" Wrap="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="uwName" HeaderText="Union/Ward">
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
                </center>
            </td>
        </tr>
    </table>
    <br />
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

