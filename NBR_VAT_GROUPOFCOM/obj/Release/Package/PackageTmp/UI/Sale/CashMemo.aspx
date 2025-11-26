<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_lqwzozjx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src="../../UserControls/Production.ascx" tagname="production" tagprefix="uc1" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table align="center" id="tblCurrencyConvertion" runat="server"  bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input"  >
            <tr>
                <td colspan="4" class="page_title" height="30">
                    বিক্রয় ক্যাশমেমো <uc1:production ID="production" runat="server" /></td>
            </tr>
             <tr>
                <td class="input_item">
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="Label1" runat="server" Text="প্রতিষ্ঠানের নাম :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="drpOrgName" runat="server" Width="100px" 
                        AutoPostBack="True" onselectedindexchanged="drpOrgName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" >
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="Label2" runat="server" Text="ঠিকানা :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:Label ID="lblOrgAddress" runat="server"></asp:Label>
                </td>
                <td align="right" >
                    <asp:Label ID="Label3" runat="server" Text="করদাতা সনাক্তকরণ সংখ্যা :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="Label4" runat="server" Text="ক্রেতার নাম :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="drpPartyName" runat="server" Width="100px" 
                        AutoPostBack="True" onselectedindexchanged="drpPartyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" >
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="Label5" runat="server" Text="ঠিকানা :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:Label ID="lblPartyAddress" runat="server"></asp:Label>
                </td>
                <td align="right" >
                    <asp:Label ID="Label6" runat="server" Text="করদাতা সনাক্তকরণ সংখ্যা :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:Label ID="lblPartyTIN" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="input_item" colspan="4">
                    <hr /></td>
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="Label7" runat="server" Text="ক্রমিক নং :"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtSerialNo" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                </td>
                <td align="right" >
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="Label8" runat="server" Text="ক্যাশমেমো প্রদানের তারিখ :"></asp:Label>
                </td>
                <td >
                    <ww:jquerydatepicker ID="dtpCashMemoDate" runat="server" 
                      DateFormat="dd/MM/yyyy" Width="80px"></ww:jquerydatepicker></td>
                <td align="right" >
                    <asp:Label ID="Label9" runat="server" Text="ক্যাশমেমো প্রদানের সময় :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="drpCashMemoHr" runat="server" Width="40px">
                    </asp:DropDownList>
                    <asp:Label ID="Label10" runat="server" Text="Hour  "></asp:Label>
                    <asp:DropDownList ID="drpCashMemoMin" runat="server" Width="40px">
                    </asp:DropDownList>
                    <asp:Label ID="Label11" runat="server" Text="Minute"></asp:Label>
                </td>
            </tr>
            <tr>
              <td align="center" colspan="4" >
                <table align="center" class="brd_tbl_input">
                      <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="center" class="style3">
                            &nbsp;</td>
                        <td align="center" class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                         <td align="right" class="style5">
                             &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td align="right" class="style5">
                              &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" Text="Category :"></asp:Label>
                        </td>
                        <td align="left"  style="text-align: left">
                            <asp:DropDownList ID="drpCategory" runat="server" Width="150px" 
                                onselectedindexchanged="drpCategory_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" Text="Quantity :"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:TextBox ID="txtQuantity" runat="server" Width="75px" AutoPostBack="True" 
                                ontextchanged="txtQuantity_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblUnit" runat="server" Text="Unit " Font-Bold="True" 
                                Font-Size="Smaller" Width="30px"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label59" runat="server" Text="Available Stock :"></asp:Label>
                         </td>
                            <td>
                                <asp:Label ID="lblAvailStock" runat="server" Text="0.00"></asp:Label>
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
                                onselectedindexchanged="drpSubCategory_SelectedIndexChanged" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" Text="Unit Price Incld VAT :"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="txtNBRPrice" runat="server" AutoPostBack="True" 
                                ontextchanged="txtUnitPrice_TextChanged" Width="75px"></asp:TextBox>
                        </td>
                        <td class="style5" align="right">
                            <asp:Label ID="Label58" runat="server" Text="Unit Price :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUnitPrice" runat="server" Text="0.00"></asp:Label>
                        </td>
                        <td align="right" class="style5">
                              &nbsp;</td>
                         <td align="right" class="style5">
                             <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Total Price :"></asp:Label>
                        </td>
                        <td align="right">
                              <asp:Label ID="lblTotalPrice" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="style3">
                            <asp:Label ID="Label17" runat="server" Text="Item Name :"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                              <asp:DropDownList ID="drpItem" runat="server" AutoPostBack="True" 
                                  Width="150px" onselectedindexchanged="drpItem_SelectedIndexChanged">
                              </asp:DropDownList>
                        </td>
                        <td align="right" class="style3">
                            <asp:Label ID="Label54" runat="server" Text="HS Code :"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblHSCode" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                                Text="."></asp:Label>
                        </td>
                        <td align="right" class="style3">
                            <asp:Label ID="Label18" runat="server" Text="SD(%) :"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblSD" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td align="right" class="style3">
                              </td>
                             <td align="right" class="style3">
                            <asp:Label ID="Label21" runat="server" Text="SD Amount :" Font-Bold="True"></asp:Label>
                        </td>
                        <td align="right" class="style3">
                            <asp:Label ID="lblTotalSD" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="style3" align="right">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3" align="right">
                            </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3" align="right">
                            <asp:Label ID="Label29" runat="server" Text="VAT(%) :"></asp:Label>
                        </td>
                            <td class="style3">
                                <asp:Label ID="lblVAT" runat="server" Text="0.00"></asp:Label>
                        </td>
                        <td align="right" class="style5">
                              &nbsp;</td>
                         <td align="right" class="style5">
                            <asp:Label ID="Label23" runat="server" Text="VAT Amount :" Font-Bold="True"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTotalVAT" runat="server" Text="0.00" Font-Bold="True"></asp:Label>
                            </td>
                    </tr>
                      <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                             <td align="right" class="style5">
                                 &nbsp;</td>
                        <td>
                            <asp:Label ID="Label60" runat="server" Font-Bold="True" 
                                Text="Total Sale Price :"></asp:Label>
                          </td>
                            <td align="right" class="style5">
                                <asp:Label ID="lblTotalSalePrc" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                          </td>
                    </tr>
                
                </table>
              </td>
              </tr>
               <tr>
            <td colspan="4" align="right">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="btnAddItem" runat="server" Text="Add Item"
                        height="30px" CssClass="button" Width="72px" 
    onclick="btnAddItem_Click" />
                    <asp:Button ID="btnClear" runat="server" CssClass="button" Height="30px" 
                        onclick="btnClear_Click" Text="Clear Item" Width="73px" />
                </asp:Panel>
            </td>
        </tr>
              <tr style="display:none">
                <td align="center" colspan="4" >
                    <table align="center" class="brd_tbl_input">
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label12" runat="server" Text="পণ্যের নাম ও বিবরণ :"></asp:Label>
                          </td>
                          <td align="left" style="text-align: left">
                              &nbsp;</td>
                          <td align="right">
                              &nbsp;</td>
                          <td align="left" class="style3">
                              <asp:HiddenField ID="hfUnitPrice" runat="server" />
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label52" runat="server" Text="পণ্যের পরিমাণ :"></asp:Label>
                          </td>
                          <td align="left" style="text-align: left">
                              <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" Width="100px" 
                                  ontextchanged="txtQty_TextChanged"></asp:TextBox>
                              <asp:Label ID="lblItemUnit" runat="server"></asp:Label>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label53" runat="server" Text="মোট মূল্য :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:Label ID="Label56" runat="server" Text="Tk."></asp:Label>
                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                              <asp:HiddenField ID="hdUnitId" runat="server" />
                    <asp:HiddenField ID="hdBookId" runat="server" />
                    <asp:HiddenField ID="hdPageNo" runat="server" />
                              <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>


                <asp:HiddenField ID="hdPriceID" runat="server" />
                <asp:HiddenField ID="hdUnitSDAmt" runat="server" />
                <asp:HiddenField ID="hdUnitVATAmt" runat="server" />
                    <asp:HiddenField ID="hdItemType" runat="server" />


                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                              &nbsp;</td>
                      </tr>
                      </table>
                </td>
            </tr>
            <tr>
                <td  colspan="4" align="right">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
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
                        <asp:BoundField HeaderText="Unit Price" DataField="UnitPriceBDT" />
                        <asp:BoundField HeaderText="NBR Price" DataField="NBRPrice" />
                        <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" />
                        <asp:BoundField HeaderText="Total SD" DataField="SD" />
                        <asp:BoundField HeaderText="Total VAT" DataField="VAT" />
                        <asp:BoundField DataField="TotalSalePrice" 
                            HeaderText="Total Sale Price" />
                        <asp:BoundField HeaderText="Src VAT Deducted" DataField="IsSrcTAXDeduct" 
                            Visible="False" />
                        <asp:BoundField HeaderText="Exempted" DataField="IsExempted" Visible="False" />
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
                <td colspan="4" align="right">
                    <asp:Button ID="btnSave" runat="server" Text="Save"
                        height="30px" CssClass="button" Width="72px" onclick="btnSave_Click" />


                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                        Height="30px" CssClass="button" Width="73px" onclick="btnRefresh_Click" />
                </td>
            </tr>
            </table>
<uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

