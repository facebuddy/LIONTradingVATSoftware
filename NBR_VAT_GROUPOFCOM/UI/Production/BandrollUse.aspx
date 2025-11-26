<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_pn05akvb" %>
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
                    Bandroll Usage<uc1:production ID="production" runat="server" /></td>
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
                    <asp:Label ID="lblOrgId" runat="server" Text="Organization Name :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="drpOrgName" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="drpOrgName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" >
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="lblChlnNo" runat="server" Text="Challan No :"></asp:Label>
                </td>
                <td align="left" >
        <asp:TextBox ID="txtUsageChln" runat="server" Width="150px" 
                        ></asp:TextBox>
                </td>
                <td align="right" >
                    <asp:Label ID="lblDateUse" runat="server" Text="Usage Date :"></asp:Label>
                </td>
                <td align="left" >
                    <ww:jquerydatepicker ID="dtpDateUsage" runat="server" Width="150px" 
                        DateFormat="dd/MM/yyyy"></ww:jquerydatepicker>
                </td>
            </tr>
            <tr>
                <td  colspan="4" align="left">
                <table align="center" class="brd_tbl_input">
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label4" runat="server" Text="Bandroll Id :"></asp:Label>
                          </td>
                          <td align="left" style="text-align: left">
                              <asp:DropDownList ID="drpBandrollId" runat="server" AutoPostBack="True" 
                                  Width="100px" onselectedindexchanged="drpBandrollId_SelectedIndexChanged">
                              </asp:DropDownList>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label56" runat="server" Text="Receive Challan No :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:DropDownList ID="drpRecChlnId" runat="server" Width="100px" 
                                  AutoPostBack="True" 
                                  onselectedindexchanged="drpRecChlnId_SelectedIndexChanged">
                              </asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                              <asp:Label ID="Label57" runat="server" Text="Available Stock :"></asp:Label>
                              <asp:Label ID="lblAvlPcs" runat="server"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label52" runat="server" Text="Items :"></asp:Label>
                          </td>
                          <td align="left" style="text-align: left">
                              <asp:DropDownList ID="drpItems" runat="server" Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label51" runat="server" Text="Quantity :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:TextBox ID="txtQty" runat="server" 
                                  Width="100px" AutoPostBack="True" ontextchanged="txtQty_TextChanged"></asp:TextBox>
                              <asp:Label ID="lblUnit" runat="server">Pcs.</asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                    <asp:Button ID="btnAddBItem" runat="server" Text="Add Bandroll Item" CssClass="button" 
                                  onclick="btnAddBItem_Click" />


                    <asp:Button ID="btnClearBandrollGrid" runat="server" Text="Clear Bandroll Item" 
                                  CssClass="button" onclick="btnClearBandrollGrid_Click" />


                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                    <asp:GridView ID="dgvBUItemGrid" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False" 
                                  onselectedindexchanged="dgvBUItemGrid_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Row No" DataField="rowNo" />
                        <asp:BoundField HeaderText="Receive Challan Id" DataField="RcvChallanId" />
                        <asp:BoundField HeaderText="Bandroll" DataField="BandrollDetail" />
                        <asp:BoundField HeaderText="Item" DataField="ItemName" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
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
                          <td align="center" colspan="4">
                              <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                          </td>
                      </tr>
                      </table>
                </td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="Label58" runat="server" Text="Remarks :"></asp:Label>


                          </td>
                <td class="input_item" align="left" colspan="3">
                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="350px" 
                        ></asp:TextBox>


                          </td>
            </tr>

            <tr>
                <td class="input_item" align="center" colspan="4">
                    <asp:Button ID="btnSave1" runat="server" Text="Save Usage Challan" 
                                  CssClass="button" onclick="btnSave1_Click"  />


                    <asp:Button ID="btnClearChallan" runat="server" Text="Clear Usage Challan" 
                                  CssClass="button" onclick="btnClearChallan_Click"  />


                          </td>
            </tr>

            <tr>
                <td class="input_item" align="center" colspan="4">
                    <hr /></td>
            </tr>

            <tr>
                <td colspan="2" align="left">
                    <asp:Label ID="Label54" runat="server" Font-Bold="True" 
                        Text="Bandroll Usage Information"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="dgvBUMasterGrid" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False" 
                        DataKeyNames="challan_id" HorizontalAlign="Center" 
                        onselectedindexchanged="dgvBUMasterGrid_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Challan Id" Visible="False" 
                            DataField="challan_id" />
<asp:BoundField HeaderText="Organization ID" DataField="organization_id" Visible="False"></asp:BoundField>
                        <asp:BoundField HeaderText="Organization" DataField="orgName" />
                        <asp:BoundField HeaderText="Challan No" 
                            DataField="challan_no" />
                        <asp:BoundField HeaderText="Challan Date" DataField="challanDate" />
                        <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                        <EditRowStyle HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label55" runat="server" Font-Bold="True" Text="Details" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                <asp:GridView ID="dgvBUDetailGrid" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False" 
                        HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="row_no" HeaderText="Row No" />
                        <asp:BoundField DataField="rcv_challan_id" HeaderText="Receive Challan Id" 
                            Visible="False" />
                        <asp:BoundField DataField="rcvNo" HeaderText="Rec. Challan No" />
                        <asp:BoundField DataField="bandroll_id" HeaderText="Bandroll Id" />
                        <asp:BoundField DataField="description" 
                            HeaderText="Bandroll Details" />
                        <asp:BoundField DataField="iName" HeaderText="Item" />
                        <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="unit_price" HeaderText="Unit Price" 
                            Visible="False" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnClearBandrollDetails" runat="server" Text="Clear Details" 
                        height="30px" CssClass="button" 
                        Width="160px" onclick="btnClearBandrollDetails_Click" Visible="False" />
                </td>
            </tr>
            </table>
            <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

