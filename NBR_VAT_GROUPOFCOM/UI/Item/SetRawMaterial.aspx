<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_SetRawMaterial, App_Web_ovuzd3bo" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>

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
            <td class="page_title" colspan="6" align="center">
                Set Raw Materials for Finished Goods <uc1:ItemNav ID="ItemNav" runat="server" /></td>
        </tr>
         <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label5" runat="server" Text="Organization Name:"></asp:Label>
            </td>
             <td class="style2">
                 <asp:DropDownList ID="drpOrganization" runat="server" AutoPostBack="True" 
                     onselectedindexchanged="drpOrganization_SelectedIndexChanged" 
                     Width="150px">
                 </asp:DropDownList>
             </td>
                 <td align="right">
                     <asp:Label ID="Label8" runat="server" Text="BIN :"></asp:Label>
             </td>
            <td>
                <asp:Label ID="lblOrgBIN" runat="server" Width="165px"></asp:Label>
            </td>
            <td align="right" >
                <asp:Label ID="Label6" runat="server" Text="Address :" Visible="False"></asp:Label>
             </td>
            <td>
                <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
             </td>
       
        <tr>
            <td valign="top" align="right" class="style2">
                <asp:Label ID="Label62" runat="server" Text="Category :"></asp:Label>
            </td>
             <td valign="top" align="left" class="style2">
                 <asp:DropDownList ID="drpCatFin" runat="server" AutoPostBack="True" 
                     onselectedindexchanged="drpCatFin_SelectedIndexChanged" 
                     Width="150px">
                 </asp:DropDownList>
            </td>
             <td valign="top" align="right" class="style2">
                 <asp:Label ID="Label63" runat="server" Text="Sub Category :"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="drpSubCatFin" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="drpSubCatFin_SelectedIndexChanged" 
                    Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right" class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label64" runat="server" Text="Finished Good :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpItemFin" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="drpItemFin_SelectedIndexChanged" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label65" runat="server" Text="HS Code :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblHSCodeFin" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                    Text="."></asp:Label>
            </td>
                 <td>
                &nbsp;</td>
                 <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                &nbsp;</td>
            <td >
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
         <tr style="display:none">
            <td valign="top" align="left" >
                &nbsp;</td>
           
            <td align="center" >
                <asp:Label ID="Label56" runat="server" Text="Unit :" Visible="False"></asp:Label>
                <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px">
                </asp:DropDownList>
             </td>
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
            <td class="style1" valign="top" colspan="6">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <table align="center" class="brd_tbl_input">
                  
                     <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Category :"></asp:Label>
                        </td>
                        <td align="left"  style="text-align: left">
                            <asp:DropDownList ID="drpCatRaw" runat="server" Width="150px" 
                                onselectedindexchanged="drpCategory_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label51" runat="server" Text="Sub Category :"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:DropDownList ID="drpSubCatRaw" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpSubCategory_SelectedIndexChanged" 
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                            <td>
                                &nbsp;</td>
                         <td align="right" class="style5">
                              &nbsp;</td>
                          <td align="right" class="style5">
                              &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Raw Material :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpItemRaw" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="drpItem_SelectedIndexChanged" 
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label54" runat="server" Text="HS Code :"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:Label ID="lblHSCodeRaw" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                Text="."></asp:Label>
                        </td>
                        <td class="style5" align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right" class="style5">
                              &nbsp;</td>
                         <td align="right" class="style5">
                             &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label61" runat="server" Text="Remarks :"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txtRemarks" runat="server" Width="385px"></asp:TextBox>
                        </td>
                      
                        <td align="right" class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td align="right" class="style5">
                              &nbsp;</td>
                             <td align="right" class="style5">
                                 &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr >
                        <td class="style3" align="right">
                            </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3" align="right">
                            </td>
                        <td class="style3">
                            <asp:CheckBox ID="chkCompulsory" runat="server" Text="Compulsory Material" />
                        </td>
                        <td class="style3" align="right">
                            &nbsp;</td>
                            <td class="style3">
                                &nbsp;</td>
                        <td align="right" class="style5">
                              &nbsp;</td>
                         <td align="right" class="style5">
                             &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
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
                            <asp:Label ID="Label11" runat="server" Text="Quantity :" Visible="False"></asp:Label>
                          </td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server" TabIndex="4" Visible="False" 
                                Width="75px"></asp:TextBox>
                            <asp:Label ID="lblUnit" runat="server" Font-Bold="True" Font-Size="Smaller" 
                                Text="Unit " Visible="False" Width="30px"></asp:Label>
                          </td>
                             <td align="right" class="style5">
                                 &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td align="right" class="style5">
                                &nbsp;</td>
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
            <td align="right" colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdUnitID" runat="server" />
            </td>
            <td align="right" colspan="5">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Button ID="btnAdd" runat="server" CssClass="button_sub" 
                        Text="Add Item" onclick="btnAddItem_Click" />
                    <asp:Button ID="btnClear" runat="server" CssClass="button_sub" 
                        Text="Clear" onclick="btnClear_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="gvRawMaterial" runat="server" AutoGenerateColumns="False" 
                    CssClass="sGrid" DataKeyNames="RawMaterialID,RowNo" Width="100%" 
                    onselectedindexchanged="gvItem_SelectedIndexChanged" 
                    onprerender="gvItem_PreRender" onrowdatabound="gvItem_RowDataBound" 
                    onrowdeleting="gvItem_RowDeleting">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                              <asp:BoundField HeaderText="Category" DataField="CategoryNameRaw" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryNameRaw"/>
                        <asp:BoundField HeaderText="Raw Material" DataField="RawMaterialName"/>
                        <asp:BoundField HeaderText="Property1" DataField="Property1" Visible="False"/>
                        <asp:BoundField HeaderText="Property2" DataField="Property2" Visible="False" />
                        <asp:BoundField HeaderText="Property3" DataField="Property3" Visible="False"/>
                        <asp:BoundField HeaderText="Property4" DataField="Property4" Visible="False" />
                        <asp:BoundField HeaderText="Property5" DataField="Property5" Visible="False" />
                        <asp:BoundField HeaderText="Remarks" DataField="remarks"/>
                        <asp:BoundField DataField="IsCompulsory" HeaderText="Is Compulsory" />
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
            <td colspan="6" align="center">
             <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="6" align="right">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" 
                        Text="Refresh" onclick="btnRefreshChallan_Click" />
                         <asp:Button ID="btnSearch" runat="server" CssClass="button" 
                        Text="Search" onclick="btnSearch_Click"/>
                </asp:Panel>
            </td>
        </tr>
            
    </table>
      <uc2:Msgbox ID="msgBox" runat="server" />
    <br />
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

