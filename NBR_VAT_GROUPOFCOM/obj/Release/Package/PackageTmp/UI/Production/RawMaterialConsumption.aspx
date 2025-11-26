<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_RawMaterialConsumption, App_Web_zewpzv5m" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src="../../UserControls/Production.ascx" tagname="production" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 25px;
        }
        .style3
        {
            height: 24px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:UpdatePanel ID="updatePanelchallan" runat="server">
<ContentTemplate>
   
    <br />
<br />
<br />
    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3" class="brd_tbl_input" border="0px">
        <tr>
            <td class="page_title" colspan="5" align="center">
                Raw Material Consumption <uc1:production ID="production" runat="server" /></td>
        </tr>
         <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label5" runat="server" Text="Organization Name:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpOrganization" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="drpOrganization_SelectedIndexChanged" Width="200px">
                </asp:DropDownList>
                <asp:Label ID="lblOrgName" runat="server" Text="Technohaven Co Ltd" 
                    Visible="False"></asp:Label>
            </td>
            <td align="right" colspan="2">
                <asp:Label ID="Label8" runat="server" Text="BIN :"></asp:Label>
             </td>
            <td>
                <asp:Label ID="lblOrgBIN" runat="server" Width="200px"></asp:Label>
             </td>
       
        <tr>
            <td valign="top" align="right" class="style2">
                <asp:Label ID="Label30" runat="server" Text="Challan No :"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtChallanNo" runat="server" Width="195px"></asp:TextBox>
            </td>
            <td align="right" colspan="2" class="style2">
                <asp:Label ID="Label6" runat="server" Text="Address :"></asp:Label>
                </td>
            <td class="style2">
                <asp:Label ID="lblOrgAddress" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label32" runat="server" Text="Challan Date Time:"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="txtChallanDate" runat="server" 
                    DateFormat="dd/MM/yyyy" Width="80px"></ww:jQueryDatePicker>
                <asp:DropDownList ID="drpChDtHr" runat="server" Width="45px">
                </asp:DropDownList>
                <asp:DropDownList ID="drpChDtMin" runat="server" Width="45px">
                </asp:DropDownList>
            </td>
            <td align="right" colspan="2">
                <asp:Label ID="Label56" runat="server" Text="Unit :" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label61" runat="server" Text="Remarks :"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtRemarks" runat="server" Width="400px"></asp:TextBox>
            </td>
           
        </tr>
         <tr style="display:none">
            <td valign="top" align="left" colspan="2">
                &nbsp;</td>
           
            <td align="center" colspan="3">
                &nbsp;</td>
           
        </tr>
         
       
        <tr>
            <td class="style1" valign="top" colspan="5">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <table align="center" class="brd_tbl_input">
                  
                     <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Category :"></asp:Label>
                        </td>
                        <td align="left"  style="text-align: left">
                            <asp:DropDownList ID="drpCategory" runat="server" Width="100px" 
                                onselectedindexchanged="drpCategory_SelectedIndexChanged" 
                                AutoPostBack="True" TabIndex="1">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" Text="Quantity :"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:TextBox ID="txtQuantity" runat="server" Width="75px" AutoPostBack="True" 
                                ontextchanged="txtQuantity_TextChanged" TabIndex="4"></asp:TextBox>
                            <asp:Label ID="lblUnit" runat="server" Text="Unit " Font-Bold="True" 
                                Font-Size="Smaller" Width="30px"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" Text="Unit Price :" Visible="False"></asp:Label>
                         </td>
                            <td>
                                <asp:Label ID="lblUnitPrice" runat="server" Text="0.00" Visible="False"></asp:Label>
                         </td>
                         <td align="right" class="style5">
                              &nbsp;</td>
                          <td align="right" class="style5">
                              &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label51" runat="server" Text="Sub Category :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpSubCategory_SelectedIndexChanged" Width="100px" 
                                TabIndex="2">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label59" runat="server" Text="Available Stock :"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:Label ID="lblAvailStock" runat="server" Text="0.00"></asp:Label>
                        </td>
                        <td class="style5" align="right">
                            <asp:Label ID="Label58" runat="server" Text="NBR Confirmed Prc :" 
                                Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNBRPrice" runat="server" Text="0.00" Visible="False"></asp:Label>
                        </td>
                        <td align="right" class="style5">
                              &nbsp;</td>
                         <td align="right" class="style5">
                            <asp:Label ID="Label19" runat="server" Text="Total Price :" Font-Bold="True" 
                                 Visible="False"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTotalPrice" runat="server" Text="0.00" Font-Bold="True" 
                                Visible="False"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Item Name :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpItem" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpItem_SelectedIndexChanged" Width="100px" 
                                TabIndex="3">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label54" runat="server" Text="HS Code :"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblHSCode" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                Text="."></asp:Label>
                        </td>
                        <td align="right" class="style5">
                            <asp:Label ID="Label52" runat="server" Text="SD(%) :" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSD" runat="server" Text="0.00" Visible="False"></asp:Label>
                            </td>
                            <td align="right" class="style5">
                              &nbsp;</td>
                             <td align="right" class="style5">
                            <asp:Label ID="Label21" runat="server" Text="SD Amount :" Font-Bold="True" 
                                     Visible="False"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTotalSD" runat="server" Text="0.00" Font-Bold="True" 
                                Visible="False"></asp:Label>
                            </td>
                    </tr>
                    <tr style="display:none">
                        <td class="style3" align="right">
                            </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3" align="right">
                            </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3" align="right">
                            <asp:Label ID="Label53" runat="server" Text="VAT(%) :" Visible="False"></asp:Label>
                        </td>
                            <td class="style3">
                                <asp:Label ID="lblVAT" runat="server" Text="0.00" Visible="False"></asp:Label>
                        </td>
                        <td align="right" class="style5">
                              &nbsp;</td>
                         <td align="right" class="style5">
                            <asp:Label ID="Label23" runat="server" Text="VAT Amount :" Font-Bold="True" 
                                 Visible="False"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTotalVAT" runat="server" Text="0.00" Font-Bold="True" 
                                Visible="False"></asp:Label>
                            </td>
                    </tr >
                      <tr style="display:none">
                        <td align="right">
                            <asp:Label ID="lblProp5" runat="server" Text="Property 5" Visible="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpProp5" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpProp5_SelectedIndexChanged" Visible="False" 
                                Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblProp2" runat="server" Text="Property 2" Visible="False"></asp:Label>
                        </td>
                        <td align="center" class="style3">
                            <asp:DropDownList ID="drpProp2" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpProp2_SelectedIndexChanged" Visible="False" 
                                Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="center" class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                             <td align="right" class="style5">
                                 &nbsp;</td>
                        <td>
                            <asp:Label ID="Label60" runat="server" Text="Total Price incld VAT:" 
                                Font-Bold="True" Visible="False"></asp:Label>
                          </td>
                            <td align="right" class="style5">
                                <asp:Label ID="lblTotalSalePrc" runat="server" Text="0.00" Font-Bold="True" 
                                    Visible="False"></asp:Label>
                          </td>
                    </tr>
                    <tr style="display:none">
                        <td align="right" class="style3">
                            <asp:Label ID="lblProp1" runat="server" Text="Property 1:" Visible="False"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:DropDownList ID="drpProp1" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpProp1_SelectedIndexChanged" Visible="False" 
                                Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="right" class="style3">
                            <asp:Label ID="lblProp4" runat="server" Text="Property 4" Visible="False"></asp:Label>
                        </td>
                        <td align="center" class="style3">
                            <asp:DropDownList ID="drpProp4" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpProp4_SelectedIndexChanged" Visible="False" 
                                Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="center" class="style3">
                            <asp:Label ID="lblProp3" runat="server" Text="Property 3" Visible="False"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:DropDownList ID="drpProp3" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpProp3_SelectedIndexChanged" Visible="False" 
                                Width="100px">
                            </asp:DropDownList>
                        </td>
                         <td align="right" class="style3">
                             </td>
                        <td class="style3">
                            </td>
                            <td align="right" class="style3">
                              </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdPriceID" runat="server" />
            </td>
            <td align="right" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdUnitID" runat="server" />
            </td>
            <td align="right" colspan="4">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Button ID="btnAdd" runat="server" CssClass="button_sub" 
                        Text="Add Item" onclick="btnAddItem_Click" />
                    <asp:Button ID="btnClear" runat="server" CssClass="button_sub" 
                        Text="Clear" onclick="btnClear_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                    CssClass="sGrid" DataKeyNames="ItemID,RowNo" Width="100%" 
                    onselectedindexchanged="gvItem_SelectedIndexChanged" 
                    onprerender="gvItem_PreRender" onrowdatabound="gvItem_RowDataBound" 
                    onrowdeleting="gvItem_RowDeleting">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                              <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName"/>
                        <asp:BoundField HeaderText="Item" DataField="ItemName"/>
                        <asp:BoundField HeaderText="Property1" DataField="Property1" Visible="False"/>
                        <asp:BoundField HeaderText="Property2" DataField="Property2" Visible="False" />
                        <asp:BoundField HeaderText="Property3" DataField="Property3" Visible="False"/>
                        <asp:BoundField HeaderText="Property4" DataField="Property4" Visible="False" />
                        <asp:BoundField HeaderText="Property5" DataField="Property5" Visible="False" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity"/>
                        <asp:BoundField HeaderText="Unit" DataField="UnitName"/>
                        <asp:BoundField DataField="AvailStock" HeaderText="Current Stock" />
                        <asp:BoundField HeaderText="Unit Price" DataField="UnitPriceBDT" 
                            Visible="False" />
                        <asp:BoundField HeaderText="NBR Price" DataField="NBRPrice" Visible="False" />
                        <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" 
                            Visible="False" />
                        <asp:BoundField HeaderText="Total SD" DataField="SD" Visible="False" />
                        <asp:BoundField HeaderText="Total VAT" DataField="VAT" Visible="False" />
                        <asp:BoundField DataField="TotalSalePrice" 
                            HeaderText="Tot. Value including SD and VAT" Visible="False" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                   <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
             <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="right">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" 
                        Text="Refresh" onclick="btnRefreshChallan_Click" />
                </asp:Panel>
            </td>
        </tr>
    </table>
      <uc2:Msgbox ID="msgBox" runat="server" />
    <br />
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

