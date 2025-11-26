<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_f0n3q0ak" %>
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
                    Bandroll Receive<uc1:production ID="production" runat="server" /></td>
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
                        AutoPostBack="True" onselectedindexchanged="drpOrgName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" >
                    <asp:Label ID="lblDateRec" runat="server" Text="Receive Date :"></asp:Label>
                </td>
                <td align="left" >
                    <ww:jquerydatepicker ID="dtpDateReceive" runat="server" Width="150px" 
                        DateFormat="dd/MM/yyyy"></ww:jquerydatepicker>
                </td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="lblRecChlnNo" runat="server" Text="Receive Challan No :"></asp:Label>
                </td>
                <td align="left" >
        <asp:TextBox ID="txtReceiveChln" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td align="right" >
                    <asp:Label ID="Label2" runat="server" Text="Treasury Challan No :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="drpTreasuryNo" runat="server" style="margin-bottom: 0px" 
                        Width="150px">
                    </asp:DropDownList>
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
                                  Width="100px">
                              </asp:DropDownList>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label51" runat="server" Text="Quantity :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" 
                                  ontextchanged="txtQty_TextChanged" Width="100px"></asp:TextBox>
                              <asp:Label ID="lblTotalPrice" runat="server">Pieces</asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="right">
                              <asp:Label ID="Label52" runat="server" Text="Unit Price :"></asp:Label>
                          </td>
                          <td align="left" style="text-align: left">
                              <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                          </td>
                          <td align="right">
                              <asp:Label ID="Label53" runat="server" Text="Total Price :"></asp:Label>
                          </td>
                          <td align="left" class="style3">
                              <asp:TextBox ID="txtTotalPrice" runat="server" AutoPostBack="True" 
                                  ontextchanged="txtTotalPrice_TextChanged" Width="100px"></asp:TextBox>
                              <asp:Label ID="Label56" runat="server" Text="Tk."></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                    <asp:Button ID="btnSave0" runat="server" Text="Add Bandroll Item" CssClass="button" onclick="btnSave0_Click" 
                                   />


                    <asp:Button ID="btnClearBandrollGrid" runat="server" Text="Clear Bandroll Item" 
                                  CssClass="button" onclick="btnClearBandrollGrid_Click" />


                          </td>
                      </tr>
                      <tr>
                          <td align="center" colspan="4">
                    <asp:GridView ID="dgvBRItemGrid" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Row No" DataField="RowNo" />
                        <asp:BoundField HeaderText="Bandroll Id" DataField="BandrollId" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" />
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
                <td class="input_item" align="center" colspan="4">
                    <asp:Button ID="btnSave1" runat="server" Text="Save Bandroll Receive Challan" 
                                  CssClass="button" onclick="btnSave1_Click" />


                    <asp:Button ID="btnSave2" runat="server" Text="Clear Bandroll Receive Challan" 
                                  CssClass="button" onclick="btnSave2_Click" />


                          </td>
            </tr>
            <tr>
                <td class="input_item" align="center" colspan="4">
                    <hr /></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Label ID="Label54" runat="server" Font-Bold="True" 
                        Text="Bandroll Receive Information"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="dgvBRMasterGrid" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False" 
                        DataKeyNames="challan_id" HorizontalAlign="Center" 
                        onselectedindexchanged="dgvBRMasterGrid_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Challan Id" Visible="False" 
                            DataField="challan_id" />
<asp:BoundField HeaderText="Organization ID" DataField="organization_id" Visible="False"></asp:BoundField>
                        <asp:BoundField HeaderText="Organization" DataField="orgName" />
                        <asp:BoundField HeaderText="Receive Challan No" 
                            DataField="receive_challan_no" />
                        <asp:BoundField HeaderText="Receive Date" DataField="receiveDate" />
                        <asp:BoundField DataField="TChNo" HeaderText="Treasury Challan No" />
                        <asp:BoundField HeaderText="Treasury Challan Id" 
                            DataField="treasury_challan_id" Visible="False" />
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
                <asp:GridView ID="dgvBRDetailGrid" runat="server" 
                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False" 
                        HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="row_no" HeaderText="Row No" />
                        <asp:BoundField DataField="bandroll_id" HeaderText="Bandroll Id" />
                        <asp:BoundField DataField="description" 
                            HeaderText="Bandroll Details" />
                        <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" />
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
                    <asp:Button ID="btnShowBandrollDetails" runat="server" Text="Clear Details" 
                        height="30px" CssClass="button" 
                        Width="160px" onclick="btnShowBandrollDetails_Click" Visible="False" />
                </td>
            </tr>
            </table>
<uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>

