<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Item_Tax_Values, App_Web_jwpupl0k" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style6
        {
            height: 35px;
        }
        .sGrid
        {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <%--   <uc1:ItemNav ID="ItemNav" runat="server" />--%>

<div><table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="page_title" colspan="4">
                Set TAX Rate<uc1:ItemNav ID="ItemNav" runat="server" /></td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Category  Name :"></asp:Label>
                   <br />
                <asp:Label ID="Label4" runat="server" Text="Item Name :"></asp:Label>
                   <br />
                <asp:Label ID="Label3" runat="server" Text="Effective Date :"></asp:Label>
                   </td>
            <td style="text-align: left" align="right" valign="top">
                <asp:DropDownList ID="ddlCategory"  DataTextField="category_name" 
                    DataValueField="category_id" runat="server" Height="27px" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddlItemName"  DataTextField="ITEM_NAME" 
                    DataValueField="ITEM_ID" runat="server" Height="24px" 
                     Width="150px" AutoPostBack="True" 
                    onselectedindexchanged="ddlItemName_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                <br />
            <ww:jQueryDatePicker ID="dtpDate0" runat="server" Width="110px"></ww:jQueryDatePicker>
                <br />
                <br />
                <asp:Button ID="btnSave" runat="server" CssClass="button" 
                         Text="Save" onclick="btnSave_Click" />
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" 
                         Text="Refresh" onclick="btnRefresh_Click" />
                <asp:Button ID="btnShowList" runat="server" CssClass="button" 
                        onclick="btnShowList_Click" Text="Show Item Tax List" />
            </td>
            <td style="text-align: left" rowspan="4" valign="top">
                <asp:GridView ID="dgvItemTaxCategoryFalse" runat="server" AutoGenerateColumns="False" CssClass="sGrid" DataKeyNames="tax_id" 
                     Width="81%" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
                    <Columns>
                        <asp:BoundField DataField="tax_code" HeaderText="Tax Code" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Left" CssClass="grid_item" />
                        </asp:BoundField>
                       
                     <asp:TemplateField HeaderText=" Value">
                       <ItemTemplate>
                          <asp:TextBox ID="txtTaxVavue" runat="server" Width="60px" style="text-align:center"  Text="0" Height="18px" MaxLength="6" />
                       </ItemTemplate>
                       <ItemStyle CssClass="grid_item" />
                     </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                    <EmptyDataTemplate>
                                                    No Items Found.
                                                </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
            <td style="text-align: left" rowspan="4">
            <asp:GridView ID="dgvItemTaxCategoryTrue" runat="server" AutoGenerateColumns="False" CssClass="sGrid" DataKeyNames="tax_id"    
                     Width="100%" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
                    <Columns>
                    <asp:TemplateField HeaderText="CheckAll"  ItemStyle-HorizontalAlign="Left">
                     <HeaderTemplate>
                       <asp:CheckBox ID="chkSelectAll" runat="server"  AutoPostBack="true" oncheckedchanged="chkSelectAll_CheckedChanged"/>
                     </HeaderTemplate>
                     <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true"/>
                     </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle HorizontalAlign="Left" CssClass="grid_item"></ItemStyle>
                      </asp:TemplateField>

                      <asp:BoundField DataField="tax_code" HeaderText="Tax Code" ItemStyle-HorizontalAlign="Center">
                         <ItemStyle HorizontalAlign="Left" CssClass="grid_item"/>
                      </asp:BoundField>
                    </Columns>

                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                    <EmptyDataTemplate>
                            No Items Found.
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>

                </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                   &nbsp;</td>
            <td style="text-align: left" align="right" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" valign="top">
                   &nbsp;</td>
            <td style="text-align: left" align="right" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                   &nbsp;</td>
            <td style="text-align: left" class="style6" align="right" valign="top">
                &nbsp;</td>
        </tr>
                <tr>
                    <td colspan="4">
                    <asp:GridView ID="gvItemTaxValues" runat="server" AutoGenerateColumns="True" 
                                                CssClass="sGrid" 
                                              
                                          Width="81%" 
                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                    BorderWidth="1px" >
                    <Columns>

                   
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                    <EmptyDataTemplate>
                                                    No Items Found.
                                                </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:GridView ID="dgvCountry" runat="server" AutoGenerateColumns="False" 
                                                CssClass="sGrid" 
                                                onrowdeleting="dgvCountry_RowDeleting" Width="100%" >
                    <Columns>
                        <asp:BoundField DataField="hs_code" HeaderText="HS Code" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="item_name" HeaderText="Item Name" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                            <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="unit_code" HeaderText="Unit Code" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                            <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cd" HeaderText="CD">
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="rd" HeaderText="RD">
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sd" HeaderText="SD" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vat" HeaderText="VAT" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ait" HeaderText="AIT" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="atv" HeaderText="ATV" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tti" HeaderText="TTI" >
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="annx_1" HeaderText="Annx.-1">
                        <HeaderStyle CssClass="grid_item_header" Wrap="False" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" 
                            ShowSelectButton="True" Visible="False" >
                            <HeaderStyle CssClass="grid_item_header" />
                            <ItemStyle CssClass="grid_item" />
                            </asp:CommandField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" Visible="False" >
                            <HeaderStyle CssClass="grid_item_header" />
                            <ItemStyle CssClass="grid_item" />
                            </asp:CommandField>
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                                                    No Items Found.
                                                </EmptyDataTemplate>
                </asp:GridView>
                    </td>


        </tr>
    </table></div>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

