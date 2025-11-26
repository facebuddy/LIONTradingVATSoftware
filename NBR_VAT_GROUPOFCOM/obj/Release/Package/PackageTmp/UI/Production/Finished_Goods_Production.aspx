<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Admin_Finished_Product_Consumption, App_Web_pn05akvb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/admin.ascx" tagname="admin" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" 
        cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="page_title" colspan="10">
                Finished Goods Production</td>
        </tr>
    
       
           <tr>
            <td class="style18" valign="top" align="right" colspan="1">
                <asp:Label ID="Label1" runat="server" Text="Organization Name :"></asp:Label>
               </td>
            <td class="input_field" colspan="1">
                <asp:DropDownList ID="drpOrganization" runat="server" 
                    Width="170px">
                </asp:DropDownList>
                </td>
            <td align="right">
                &nbsp;</td>
            <td class="style13" colspan="1">
                <asp:Label ID="Label8" runat="server" Text="Production Date :"></asp:Label>
                </td>
            <td >
            <ww:jQueryDatePicker ID="txtProductionDt" runat="server" Width="115px"></ww:jQueryDatePicker>
                </td>
                 <td >
                            &nbsp;</td>
                 <td >
                                &nbsp;</td>
               
        </tr>
           <tr>
            <td class="style18" valign="top" align="right" colspan="1">
                <asp:Label ID="lblChallanNo" runat="server" Text="Challan/ Batch :"></asp:Label>
               </td>
            <td class="input_field" colspan="1">
                <asp:TextBox ID="txtChallanNo" runat="server" Width="165px"></asp:TextBox>
                </td>
            <td align="right">
                &nbsp;</td>
            <td class="style13" colspan="1" align="right">
                <asp:Label ID="lblRemarks" runat="server" Text="Remarks :"></asp:Label>
                </td>
            <td colspan="2">
                <asp:TextBox ID="txtRemarks" runat="server" Width="240px"></asp:TextBox>
                </td>
                
                 <td >
                                &nbsp;</td>
               
        </tr>
        <tr>
            <td class="style17" valign="top">
               </td>
            <td class="input_field" colspan="4">
                &nbsp;</td>
            <td class="style13">
                &nbsp;</td>
            <td class="input_field" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style18" valign="top" align="right" colspan="1">
                <asp:Label ID="Label2" runat="server" Text="Category :"></asp:Label>
               </td>
            <td class="input_field" colspan="1">
                <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="category_name" 
                    DataValueField="category_id" Height="20px" Width="170px" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </td>
            <td align="right">
                &nbsp;</td>
            <td colspan="1" align="right">
                <asp:Label ID="Label6" runat="server" Text="Quantity :"></asp:Label>
                </td>
            <td >
                <asp:TextBox ID="txtQuantity" runat="server" Width="132px"  
                    AutoPostBack="True" ontextchanged="txtQuantity_TextChanged"></asp:TextBox>
                </td>
                 <td >
                            <asp:Label ID="Label59" runat="server" Text="Available Stock :"></asp:Label>
                         </td>
                 <td align="left" >
                                <asp:Label ID="lblAvailStock" runat="server" Text="0.00"></asp:Label>
                         </td>
               
        </tr>
            <tr>
            <td class="style18" valign="top" align="right" colspan="1">
                <asp:Label ID="Label3" runat="server" Text="Item Name :"></asp:Label>
               </td>
            <td class="input_field" colspan="1">
                <asp:DropDownList ID="ddlItemName" DataTextField="item_name" 
                    DataValueField="item_id" runat="server" 
                    onselectedindexchanged="ddlItemName_SelectedIndexChanged" Width="170px" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </td>
            <td align="right">
                <asp:Label ID="lblUnit" runat="server" Font-Bold="True" Font-Size="8pt" 
                    Width="50px"></asp:Label>
                </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label9" runat="server" Text="Unit Price :"></asp:Label>
                </td>
            <td >
                            <asp:Label ID="lblNBRPrice" runat="server" Text="0.00"></asp:Label>
                </td>
                 <td align="right" >
                            <asp:Label ID="Label52" runat="server" Text="SD(%) :"></asp:Label>
                        </td>
                 <td >
                            <asp:Label ID="lblSD" runat="server" Text="0.00"></asp:Label>
                            </td>
               
        </tr>
          <tr>
            <td class="style18" valign="top" align="right" colspan="1">
                <asp:Label ID="Label11" runat="server" Text="HS Code :"></asp:Label>
               </td>
            <td class="input_field" colspan="1">
                <asp:Label ID="lblHSCode" runat="server"></asp:Label>
                </td>
            <td align="right">
                &nbsp;</td>
            <td colspan="1" align="right">
                <asp:Label ID="Label10" runat="server" Text="Total Price :"></asp:Label>
                </td>
            <td >
                            <asp:Label ID="lblTotalPrice" runat="server" Text="0.00" Font-Bold="False"></asp:Label>
                </td>
                 <td align="right" >
                            <asp:Label ID="Label53" runat="server" Text="VAT(%) :"></asp:Label>
                        </td>
                 <td >
                                <asp:Label ID="lblVAT" runat="server" Text="0.00"></asp:Label>
                        </td>
               
        </tr>
         
        
      
        <tr>
            <td class="style20" valign="top" align="center">
                &nbsp;</td>
            <td class="style21" align="center" colspan="4">
                &nbsp;</td>
            <td class="style21" colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style19" valign="top">
                <asp:TextBox ID="txtUnitPrice" runat="server" Width="50px" AutoPostBack="True" 
                    Visible="False"></asp:TextBox>
                <asp:Label ID="lblTotlaPrice"  runat="server" Visible="False">0</asp:Label>
            </td>
            <td class="style10" colspan="3">
                <asp:HiddenField ID="HFUnitId" runat="server" />
            </td>
            <td align="right" colspan="6" >
                <asp:Button ID="btnAddItem" runat="server" Text="Add item" 
                    onclick="btnSave_Click" CssClass="button" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="button" 
                    onclick="btnRefresh_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                    CssClass="button" />
                </td>
        </tr>
        </table>
       
      <table align="center" bgcolor="WhiteSmoke" border="2" cellpadding="1" cellspacing="3" class="brd_tbl_input">
        <tr>
            <td class="style1" valign="top" align="center">
                   Item Details</td>
        </tr>
        <tr>
            <td class="style1" valign="top" align="right">
               <asp:GridView ID="gvShowItemDetails" runat="server" AutoGenerateColumns="False" 
                                                CssClass="sGrid"   DataKeyNames="item_id,unit_id"
                                              
                                                
                   Width="100%" 
                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                    BorderWidth="1px" >
                    <Columns>
                        <%--<asp:BoundField DataField="item_id" HeaderText="Item ID" />--%>
                        <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                       <%-- <asp:BoundField DataField="unit_id" HeaderText="Unit ID" />--%>
                        <asp:BoundField DataField="unit_name" HeaderText="Unit" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="quantity" HeaderText="Qty" >
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="unit_price" HeaderText="Unit Price" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" 
                            ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                    <EmptyDataTemplate>
                                                    No Item Found.
                                                </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
        </tr>
        </table>
       
        </div>

    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

