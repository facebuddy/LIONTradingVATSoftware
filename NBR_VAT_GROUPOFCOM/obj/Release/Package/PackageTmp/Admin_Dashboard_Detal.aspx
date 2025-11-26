<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Admin_Dashboard_Detal, App_Web_1kre2rwf" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/DashboardVTR.css" rel="stylesheet" type="text/css" />
      <link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
      <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
  
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <fieldset class="scheduler-border" id="fldTest" runat="server">
        <%--<fieldset id = "fldTest" runat = "server" class="scheduler- border">--%>
        <legend class="scheduler-border">Filtering</legend>
        <table style="width: 50%">
            <tr>
                <td style="width: 30%; padding-left: 18px">
                    User Name
                </td>
                <td style="width: 70%;">
                    <div style="width: 80%; border: 1px; border-style: solid; float: left;">
                        <asp:DropDownList ID="drpUserList" runat="server" Width="100%" Height="25px">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 20%; border: 0px; border-style: solid; float: right; font-weight: bold;
                        text-align: right">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Style="float: right;
                            background-color: #4CAF50" Text="Search" onclick="btnSearch_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold">Service</legend>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Purchase</legend>
            <div class="row">
                <asp:GridView ID="gvServicePurchase" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    Width="100%" Style="width: 97%; margin-left: 15px" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="challan_no" HeaderText="Challan No" />
                        <asp:BoundField HeaderText="Date" DataField="date_insert" />
                        <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                        <asp:BoundField DataField="purchase_unit_price" HeaderText="Purchase Unit Price" />
                        <asp:BoundField DataField="VAT" HeaderText="VAT" />
                        <asp:BoundField DataField="SD" HeaderText="SD" />
                        <asp:BoundField DataField="cd" HeaderText="CD" />
                        <asp:BoundField DataField="rd" HeaderText="RD" />
                        <asp:BoundField DataField="vds_amount" HeaderText="VDS" />
                        <asp:BoundField DataField="total_price" HeaderText="Total" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
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
            </div>
        </fieldset>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Sales</legend>
            <div class="row">
                <asp:GridView ID="gvServiceSale" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    Width="100%" Style="width: 97%; margin-left: 15px" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="challan_no" HeaderText="Challan No" />
                        <asp:BoundField HeaderText="Date" DataField="date_insert" />
                        <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                        <asp:BoundField DataField="purchase_unit_price" HeaderText="Purchase Unit Price" />
                        <asp:BoundField DataField="VAT" HeaderText="VAT" />
                        <asp:BoundField DataField="SD" HeaderText="SD" />
                        <asp:BoundField DataField="cd" HeaderText="CD" />
                        <asp:BoundField DataField="rd" HeaderText="RD" />
                        <asp:BoundField DataField="vds_amount" HeaderText="VDS" />
                        <asp:BoundField DataField="total_price" HeaderText="Total" />
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
            </div>
        </fieldset>
    </fieldset>
    <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold">Goods</legend>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Purchase</legend>
            <div class="row">
                <asp:GridView ID="gvGoodsPurchase" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    Width="100%" Style="width: 97%; margin-left: 15px" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="challan_no" HeaderText="Challan No" />
                        <asp:BoundField HeaderText="Date" DataField="date_insert" />
                        <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                        <asp:BoundField DataField="purchase_unit_price" HeaderText="Purchase Unit Price" />
                        <asp:BoundField DataField="VAT" HeaderText="VAT" />
                        <asp:BoundField DataField="SD" HeaderText="SD" />
                        <asp:BoundField DataField="cd" HeaderText="CD" />
                        <asp:BoundField DataField="rd" HeaderText="RD" />
                        <asp:BoundField DataField="vds_amount" HeaderText="VDS" />
                        <asp:BoundField DataField="total_price" HeaderText="Total" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
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
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </fieldset>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Sales</legend>
            <div class="row">
                <asp:GridView ID="gvGoodsSale" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    Width="100%" Style="width: 97%; margin-left: 15px" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="challan_no" HeaderText="Challan No" />
                        <asp:BoundField HeaderText="Date" DataField="date_insert" />
                        <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                        <asp:BoundField DataField="purchase_unit_price" HeaderText="Purchase Unit Price" />
                        <asp:BoundField DataField="VAT" HeaderText="VAT" />
                        <asp:BoundField DataField="SD" HeaderText="SD" />
                        <asp:BoundField DataField="cd" HeaderText="CD" />
                        <asp:BoundField DataField="rd" HeaderText="RD" />
                        <asp:BoundField DataField="vds_amount" HeaderText="VDS" />
                        <asp:BoundField DataField="total_price" HeaderText="Total" />
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
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </fieldset>
    </fieldset>
   <div>
    <uc2:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
