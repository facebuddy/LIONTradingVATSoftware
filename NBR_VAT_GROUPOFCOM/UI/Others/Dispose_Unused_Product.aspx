<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Dispose_Dispose_Unused_Product, App_Web_0aej32q1" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            text-align: center;
        }
     .style3
     {
         height: 158px;
     }
     .style4
     {
         height: 31px;
     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td class="page_title" colspan="4" align="center">
                Application for the disposal of Unused Products</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                &nbsp;
                <asp:Label ID="Label51" runat="server" Text="Business Center Name :"></asp:Label>
            </td>
             &nbsp;
            <td>
                <asp:DropDownList ID="ddlOrganizationName" DataTextField="Organization_name" 
                    DataValueField="Organization_id" runat="server" Width="200px" 
                    onselectedindexchanged="ddlOrganizationName_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label52" runat="server" Text="Address :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="lblTelephone" runat="server" Text="Telephone No :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTelephoneNo" runat="server"></asp:Label>
            </td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" valign="top" colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="style3">
                <table align="center" class="brd_tbl_input">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label46" runat="server" Text="Item Category :"></asp:Label>
                        </td>
                        <td align="left" colspan="3" style="text-align: left">
                            <asp:DropDownList ID="ddlItemCategory" runat="server" Width="170px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlItemCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label48" runat="server" Text="Item Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlItemName" runat="server" Width="170px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlItemName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label50" runat="server" Text="Dispose Reason :"></asp:Label>
                        </td>
                        <td  align="left" colspan="3">
                            <asp:DropDownList ID="ddlReason" DataValueField="code_id_d" 
                                DataTextField="code_short_name" runat="server" Width="170px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label49" runat="server" Text="Purchase Challan No :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlChallanNo"  DataTextField="Challan_No" 
                                DataValueField="Challan_No" runat="server" Width="170px" 
                                onselectedindexchanged="ddlChallanNo_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                <asp:Label ID="Label32" runat="server" Text="Disposal Date :"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                <ww:jQueryDatePicker ID="dtpDisposeDate" runat="server" Width="150px" 
                                DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="center">
                            <asp:Label ID="Label59" runat="server" Text="Disposal Challan No :"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtDisposalChallanNo" runat="server" Width="170px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style2" colspan="2">
                            <asp:HiddenField ID="hdDeatilId" runat="server" />
                        </td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style2">
                            <asp:HiddenField ID="hdLotNo" runat="server" />
                        </td>
                        <td class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label53" runat="server" Text="Available Qty :"></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblPurchasedQty" runat="server">0</asp:Label>
                            <asp:Label ID="lblUnit" runat="server"></asp:Label>
                        </td>
                        <td align="right" >
                            <asp:Label ID="Label58" runat="server" Text="Total Vat :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVat" runat="server" Text="0.0"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label57" runat="server" Text="Dispose Qty :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDisposeQty" runat="server" style="text-align:center;"  
                                Width="170px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label54" runat="server" Text="Unit Price :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblActualPrice" runat="server">0.0</asp:Label>
                        </td>
                        <td align="right">
                            <asp:HiddenField ID="HFUnitId" runat="server" />
                        </td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            <asp:Label ID="Label56" runat="server" Text="Dispose Unit Price :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPresentPrice" runat="server" style="text-align:center;" 
                                Width="170px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right" >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right" colspan="3">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Button ID="btnSaveItem" runat="server" CssClass="button_sub" 
                        Text="Dispose Item" onclick="btnSaveItem_Click1" />
                    <asp:Button ID="btnRefreshItem" runat="server" CssClass="button_sub" 
                        Text="Refresh" onclick="btnRefreshItem_Click" />
                    <asp:Button ID="btnShowItemList" runat="server" CssClass="button_sub" 
                        Text="Show Item List" onclick="btnShowItemList_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvUnusedProduct" runat="server" AutoGenerateColumns="False" 
                    CssClass="sGrid"  Width="100%" BackColor="White" DataKeyNames="ItemID,UnitID,LotNo,DetailId" BorderColor="#CCCCCC">
                    <Columns>
                        <asp:BoundField DataField="ItemName" HeaderText="Item name" />
                        <asp:BoundField DataField="Quantity" HeaderText="Act.Qty" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Disp.Qty" SortExpression="Reason">
                         <ItemTemplate>
                          <asp:Label ID="lblDisposeQty" runat="server" Width="60px" style="text-align:center" Text='<%# Bind("DisposeQty") %>' Height="18px" />
                       </ItemTemplate>
                     
                       </asp:TemplateField>
                        <asp:BoundField DataField="ActualPrice" HeaderText="Act. Price">
                         <ItemStyle HorizontalAlign="Center"/>
                         </asp:BoundField>
                        <asp:BoundField DataField="VAT" HeaderText="vat">
                        <ItemStyle HorizontalAlign="Center"/>
                         </asp:BoundField>
                        <asp:TemplateField HeaderText="Prest Price" SortExpression="Present Price">
                         <ItemTemplate>
                          <asp:Label ID="txtPresentPrice" runat="server" Width="70px" style="text-align:center" Text='<%# Bind("CurrenttPrice") %>' AutoPostBack="false" Height="20px"/>
                       </ItemTemplate>
                     
                       </asp:TemplateField>

                       <asp:TemplateField HeaderText="Reason" SortExpression="Reason">
                         <ItemTemplate>
                          <asp:Label ID="lblReason" runat="server" Width="60px" style="text-align:center" Text='<%# Bind("Reason") %>' Height="18px" />
                       </ItemTemplate>
                     
                       </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>

                    <%--<HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />--%>

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
        </tr>
        <tr>
            <td colspan="4" align="center">
                <hr />
                <asp:Label ID="lblMessage" runat="server" ForeColor="#990000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right" class="style4">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="btnSaveChallan" runat="server" CssClass="button" 
                        Text="Save " onclick="btnSaveChallan_Click" />
                    <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" 
                        Text="Refresh" />
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

