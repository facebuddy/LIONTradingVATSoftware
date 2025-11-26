<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Challan, App_Web_0aej32q1" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            height: 25px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel ID="updatePanelchallan" runat="server">
<ContentTemplate>
      <table align="center" bgcolor="WhiteSmoke" border="0px" border="0" 
        cellpadding="0" cellspacing="3" class="brd_tbl_input">

          <tr>
              <td class="page_title" colspan="5" align="center">
                  Challan (মূসক-১১) Bill of Entry Form</td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="Label5" runat="server" Text="Organization Name:"></asp:Label>
              </td>
              <td class="style2">
                  <asp:DropDownList ID="drpOrgName" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpOrgName_SelectedIndexChanged" Width="182px">
                  </asp:DropDownList>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="Label8" runat="server" Text="BIN :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:Label ID="lblOrgTIN" runat="server"></asp:Label>
              </td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="Label6" runat="server" Text="Address :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:Label ID="lblOrgAddress" runat="server"></asp:Label>
              </td>
              <td align="right" class="style2" colspan="2">
                  &nbsp;</td>
              <td class="style2">
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="lblChallanNo" runat="server" Text="Challan No :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtClnNo" runat="server" Width="170px"></asp:TextBox>
              </td>
              <td align="right" class="style2" colspan="2">
                  &nbsp;</td>
              <td class="style2">
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="lblBillofEntryNo" runat="server" Text="Bill of Entry No :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtChallanNo" runat="server" Width="170px"></asp:TextBox>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="lblBillofEntryDate" runat="server" Text="Bill of Entry Date :"></asp:Label>
              </td>
              <td class="style2">
                  <ww:jQueryDatePicker ID="dtpBillOfEntryDate" runat="server" Width="150px" 
                      DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
              </td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="lblPortCode" runat="server" Text="Port Code :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:DropDownList ID="drpPortCode" runat="server" Width="182px">
                  </asp:DropDownList>
              </td>
              <td align="right" class="style2" colspan="2">
                  &nbsp;</td>
              <td class="style2">
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="lblPortFrom" runat="server" Text="Port From :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtPortFrom" runat="server" Width="170px"></asp:TextBox>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="lblPortTo" runat="server" Text="Port To :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtPortTo" runat="server" Width="170px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="lblLCNo" runat="server" Text="LC No :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtLCNo" runat="server" Width="170px"></asp:TextBox>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="lblLCDate" runat="server" Text="LC Date :"></asp:Label>
              </td>
              <td class="style2">
                  <ww:jQueryDatePicker ID="dtpLCDate" runat="server" Width="150px" 
                      DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
              </td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="Label58" runat="server" Text="Bank :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:DropDownList ID="drpBank" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpBank_SelectedIndexChanged" Width="182px">
                  </asp:DropDownList>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="Label59" runat="server" Text="Branch :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:DropDownList ID="drpBankBranch" runat="server" Width="182px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="lblLCAmount" runat="server" Text="LC Amount :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtLCAmount" runat="server" Width="170px"></asp:TextBox>
                  <asp:Label ID="Label92" runat="server" Text="Tk."></asp:Label>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="lblLCCurrency" runat="server" Text="LC Amount &amp; Currency :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtForeignAmount" runat="server" Width="85px"></asp:TextBox>
                  <asp:DropDownList ID="drpCurrencyUnit" runat="server" Width="85px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td align="right" class="style2" valign="top">
                  <asp:Label ID="Label82" runat="server" Text="Insurance Number :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtInsuranceNo" runat="server" Width="170px"></asp:TextBox>
              </td>
              <td align="right" class="style2" colspan="2">
                  <asp:Label ID="lblInsurance" runat="server" Text="Insurance Amount :"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="txtInsuranceAmount" runat="server" Width="170px"></asp:TextBox>
                  <asp:Label ID="Label94" runat="server" Text="Tk."></asp:Label>
              </td>
          </tr>
          <tr>
              <td align="right" valign="top">
                  <asp:Label ID="Label32" runat="server" Text="Shipment Date Time:"></asp:Label>
              </td>
              <td>
                  <ww:jQueryDatePicker ID="txtChallanDate" runat="server" AutoPostBack="True" 
                      DateFormat="dd/MM/yyyy" ontextchanged="txtChallanDate_TextChanged" 
                      Width="70px"></ww:jQueryDatePicker>
                  <asp:DropDownList ID="drpChDtHr" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpChDtHr_SelectedIndexChanged" Width="40px">
                  </asp:DropDownList>
                  <asp:DropDownList ID="drpChDtMin" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpChDtMin_SelectedIndexChanged" Width="40px">
                  </asp:DropDownList>
              </td>
              <td align="right" colspan="2">
                  <asp:Label ID="Label33" runat="server" Text="Delivery Date Time :"></asp:Label>
              </td>
              <td>
                  <ww:jQueryDatePicker ID="txtDeliveryDate" runat="server" AutoPostBack="True" 
                      DateFormat="dd/MM/yyyy" ontextchanged="txtDeliveryDate_TextChanged" 
                      Width="70px"></ww:jQueryDatePicker>
                  <asp:DropDownList ID="drpDlDtHr" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpDlDtHr_SelectedIndexChanged" Width="40px">
                  </asp:DropDownList>
                  <asp:DropDownList ID="drpDlDtMin" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpDlDtMin_SelectedIndexChanged" Width="40px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td align="right" valign="top">
                  &nbsp;</td>
              <td>
                  <asp:Label ID="lblShipment" runat="server"></asp:Label>
              </td>
              <td align="right" colspan="2">
                  &nbsp;</td>
              <td>
                  <asp:Label ID="lblDelivery" runat="server"></asp:Label>
              </td>
          </tr>
          <tr>
              <td align="right" valign="top">
                  <asp:Label ID="Label1" runat="server" Text="Supplier Name :"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="drpParty" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="drpParty_SelectedIndexChanged" Width="182px">
                  </asp:DropDownList>
                  <asp:Button ID="btnAddParty" runat="server" CssClass="button_sub" 
                      onclick="btnAddParty_Click" Text="New" Width="50px" />
                  <br />
                  <asp:TextBox ID="txtPartyName" runat="server" Visible="False" Width="170px"></asp:TextBox>
              </td>
              <td align="right" colspan="2">
                  <asp:Label ID="Label60" runat="server" Text="Supplier Country :"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="drpCountry" runat="server" AutoPostBack="True" 
                      Width="182px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td align="right" class="style1" valign="top">
                  <asp:Label ID="Label2" runat="server" Text="Supplier Address :"></asp:Label>
              </td>
              <td class="style1" colspan="2">
                  <asp:TextBox ID="txtAddress" runat="server" Rows="2" TextMode="MultiLine" 
                      Width="170px"></asp:TextBox>
              </td>
              <td align="right" valign="top">
                  <asp:Label ID="Label34" runat="server" Text="Ultimate Destination :"></asp:Label>
              </td>
              <td class="style1">
                  <asp:TextBox ID="txtDestination" runat="server" Rows="2" TextMode="MultiLine" 
                      Width="170px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style1" colspan="5" valign="top">
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
                          <td align="left" style="text-align: left" colspan="2">
                              <asp:DropDownList ID="drpCategory" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpCategory_SelectedIndexChanged" Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label51" runat="server" Text="Sub Category :"></asp:Label>
                          </td>
                          <td align="left" class="style3" colspan="2">
                              <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpSubCategory_SelectedIndexChanged" Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right" class="style5">
                              &nbsp;</td>
                          <td colspan="2">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label9" runat="server" Text="Item Name :"></asp:Label>
                          </td>
                          <td align="left" colspan="2">
                              <asp:DropDownList ID="drpItem" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpItem_SelectedIndexChanged" Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label54" runat="server" Text="HS Code :"></asp:Label>
                          </td>
                          <td class="style4" colspan="2">
                              <asp:Label ID="lblHSCode" runat="server" BorderStyle="None" BorderWidth="1px" 
                                  Text="." Width="16px"></asp:Label>
                          </td>
                          <td align="right" class="style5">
                              <asp:Label ID="Label11" runat="server" Text="Quantity :"></asp:Label>
                          </td>
                          <td colspan="2">
                              <asp:TextBox ID="txtQuantity" runat="server" Width="90px" AutoPostBack="True" 
                                  ontextchanged="txtQuantity_TextChanged"></asp:TextBox>
                              <asp:Label ID="lblUnit" runat="server" Text="Unit "></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label13" runat="server" Text="Unit Price :"></asp:Label>
                          </td>
                          <td align="left">
                              <asp:TextBox ID="txtUnitPrice" runat="server" AutoPostBack="True" 
                                  ontextchanged="txtUnitPrice_TextChanged" Width="86px"></asp:TextBox>
                              <asp:Label ID="Label91" runat="server" Text="Tk."></asp:Label>
                          </td>
                          <td align="left">
                              <asp:Label ID="Label73" runat="server" Text="Total :"></asp:Label>
                              <asp:TextBox ID="txtUnitPriceTotal" runat="server" Width="60px"></asp:TextBox>
                          </td>
                          <td align="right" bgcolor="#FFFFCC">
                              <asp:Label ID="Label61" runat="server" Text="CD :" ForeColor="#3333CC"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:CheckBox ID="chkCD" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkCD_CheckedChanged" />
                              <asp:Label ID="lblCD" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label86" runat="server" Text="%"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:Label ID="Label76" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActCD" runat="server"></asp:Label>
                          </td>
                          <td align="right" class="style5" bgcolor="#FFFFCC">
                              <asp:Label ID="Label62" runat="server" Text="RD :" ForeColor="#3333CC"></asp:Label>
                          </td>
                          <td>
                              <asp:CheckBox ID="chkRD" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkRD_CheckedChanged" />
                              <asp:Label ID="lblRD" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label89" runat="server" Text="%"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="Label79" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActRD" runat="server"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label52" runat="server" Text="SD :"></asp:Label>
                          </td>
                          <td align="left">
                              <asp:CheckBox ID="chkSD" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkSD_CheckedChanged" />
                              <asp:Label ID="lblSD" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label84" runat="server" Text="%"></asp:Label>
                          </td>
                          <td align="left">
                              <asp:Label ID="Label74" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActSD" runat="server"></asp:Label>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label53" runat="server" Text="VAT :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:CheckBox ID="chkVAT" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkVAT_CheckedChanged" />
                              <asp:Label ID="lblVAT" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label87" runat="server" Text="%"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:Label ID="Label77" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActVAT" runat="server"></asp:Label>
                          </td>
                          <td align="right" class="style5" bgcolor="#FFFFCC">
                              <asp:Label ID="Label63" runat="server" Text="AIT :" ForeColor="#3333CC"></asp:Label>
                          </td>
                          <td>
                              <asp:CheckBox ID="chkAIT" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkAIT_CheckedChanged" />
                              <asp:Label ID="lblAIT" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label90" runat="server" Text="%"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="Label80" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActAIT" runat="server"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label64" runat="server" Text="ATV :"></asp:Label>
                          </td>
                          <td align="left">
                              <asp:CheckBox ID="chkATV" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkATV_CheckedChanged" />
                              <asp:Label ID="lblATV" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label85" runat="server" Text="%"></asp:Label>
                          </td>
                          <td align="left">
                              <asp:Label ID="Label75" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActATV" runat="server"></asp:Label>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label65" runat="server" Text=" TTI :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:CheckBox ID="chkTTI" runat="server" Checked="True" AutoPostBack="True" 
                                  oncheckedchanged="chkTTI_CheckedChanged" />
                              <asp:Label ID="lblTTI" runat="server" Text="0.00"></asp:Label>
                              <asp:Label ID="Label88" runat="server" Text="%"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:Label ID="Label78" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActTTI" runat="server"></asp:Label>
                          </td>
                          <td align="right" class="style5">
                              <asp:Label ID="lblAnnx" runat="server" Text="Annx. :"></asp:Label>
                          </td>
                          <td>
                              <asp:CheckBox ID="chkAnnx" runat="server" Checked="True" 
                                  oncheckedchanged="chkAnnx_CheckedChanged" />
                              <asp:Label ID="Label72" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="Label81" runat="server" Text="Total :"></asp:Label>
                              <asp:Label ID="lblActAnnx" runat="server"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="right" class="style7">
                              <asp:Label ID="lblProp5" runat="server" Text="Property 5" Visible="False"></asp:Label>
                          </td>
                          <td class="style8" colspan="2">
                              <asp:DropDownList ID="drpProp5" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpProp5_SelectedIndexChanged" Visible="False" 
                                  Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right" class="style7">
                              <asp:Label ID="lblProp2" runat="server" Text="Property 2" Visible="False"></asp:Label>
                          </td>
                          <td class="style9" colspan="2">
                              <asp:DropDownList ID="drpProp2" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpProp2_SelectedIndexChanged" Visible="False" 
                                  Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right" class="style6">
                              &nbsp;</td>
                          <td class="style7" colspan="2">
                              <asp:CheckBox ID="chkTaxDeducted" runat="server" Text="Source TAX Deducted" />
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="lblProp1" runat="server" Text="Property 1:" Visible="False"></asp:Label>
                          </td>
                          <td align="left" colspan="2">
                              <asp:DropDownList ID="drpProp1" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpProp1_SelectedIndexChanged" Visible="False" 
                                  Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right">
                              <asp:Label ID="lblProp4" runat="server" Text="Property 4" Visible="False"></asp:Label>
                          </td>
                          <td align="center" class="style3" colspan="2">
                              <asp:DropDownList ID="drpProp4" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpProp4_SelectedIndexChanged" Visible="False" 
                                  Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="center" class="style5">
                              <asp:Label ID="lblProp3" runat="server" Text="Property 3" Visible="False"></asp:Label>
                          </td>
                          <td colspan="2">
                              <asp:DropDownList ID="drpProp3" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpProp3_SelectedIndexChanged" Visible="False" 
                                  Width="100px">
                              </asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="9">
                              <asp:Label ID="Label93" runat="server" Font-Bold="True" Font-Size="Medium" 
                                  Text="Total :"></asp:Label>
                              <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                          </td>
                      </tr>
                  </table>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:HiddenField ID="hfItemUnit" runat="server" />
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
                          onclick="btnAddItem_Click" Text="Add Item" />
                      

                      <asp:Button ID="btnClear" runat="server" CssClass="button_sub" 
                          onclick="btnClear_Click" Text="Clear" />
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td colspan="5">
                  <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                      CssClass="sGrid" DataKeyNames="ItemID,RowNo" 
                      onselectedindexchanged="gvItem_SelectedIndexChanged" Width="100%">
                      <Columns>
                          <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                              SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                          <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                              ShowDeleteButton="True" />
                          <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                          <asp:BoundField DataField="SubCategoryName" HeaderText="Sub Category" />
                          <asp:BoundField DataField="ItemName" HeaderText="Item" />
                          <asp:BoundField DataField="Property1" HeaderText="Property1" Visible="False" />
                          <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                          <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                          <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                          <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                          <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                          <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                          <asp:BoundField DataField="UnitPriceBDT" HeaderText="Unit Price" />
                          <asp:BoundField DataField="CD" HeaderText="CD" />
                          <asp:BoundField DataField="RD" HeaderText="RD" />
                          <asp:BoundField DataField="SD" HeaderText="SD" />
                          <asp:BoundField DataField="VAT" HeaderText="VAT" />
                          <asp:BoundField DataField="AIT" HeaderText="AIT" />
                          <asp:BoundField DataField="ATV" HeaderText="ATV" />
                          <asp:BoundField DataField="TTI" HeaderText="TTI" />
                          <asp:BoundField DataField="TotalPrice" HeaderText="Total" />
                          <asp:BoundField DataField="IsSrcTAXDeduct" HeaderText="Src TAX Deducted" />
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
              <td align="center" colspan="5">
                  <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" 
                      ForeColor="Red"></asp:Label>
                  <hr />
              </td>
          </tr>
          <tr>
              <td align="right" colspan="5">
                  <asp:Panel ID="Panel2" runat="server">
                      <asp:Button ID="btnSave" runat="server" CssClass="button" 
                          onclick="btnSave_Click" Text="Save" />
                      <asp:Button ID="btnRefreshChallan" runat="server" CssClass="button" 
                          onclick="btnRefreshChallan_Click" Text="Refresh" />
                  </asp:Panel>
              </td>
          </tr>
    </table>
      <uc2:Msgbox ID="msgBox" runat="server" />
    <br />
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

