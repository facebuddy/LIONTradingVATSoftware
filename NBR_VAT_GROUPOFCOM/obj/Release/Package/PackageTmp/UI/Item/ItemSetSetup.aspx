<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Item_ItemSetSetup, App_Web_ovuzd3bo" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Set Creation with Quantity & Price
                </div>


                <div class="panel-body" style="padding-top: 10px; padding-bottom: 5px">
                    <div class="row" runat="server" id="div_a">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Set Name:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpSetItem" CssClass="form-control select2" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Item Name:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpItem" AutoPostBack="true" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" CssClass="form-control select2" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                          <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Item Unit:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpitemUnit" CssClass="form-control select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                       

                    </div>
                    <div class="row" runat="server" id="div1">

                      <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Challan No:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpChallan" CssClass="form-control select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpChallan_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Challan Quantity:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtChallanQuantity" CssClass="form-control" runat="server" OnTextChanged="txtChallanQuantity_TextChanged" AutoPostBack="True">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                      
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Challan Price:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtChallanPrice" CssClass="form-control" runat="server" OnTextChanged="txtChallanPrice_TextChanged" AutoPostBack="True">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                           <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Gross Use:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtQuantityTotal" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtQuantityTotal_TextChanged">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Unit:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpUnit" CssClass="form-control select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnitSec_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Price:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" >
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="btnAdd" runat="server" class="btn-btn" Style="background-color: #B681B7" OnClick="btnAddItem_Click" Text="Add Item" />
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="btnSave" runat="server" Style="background-color: #4CAF50" class="btn-btn" Text="Save" OnClick="btnSave_Click" />
                        </div>
                        <div class="test-btn">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color: #3B7CB5; float: right" OnClick="btnSearch_Click" Text="Search" />
                        </div>
                    </div>
                    <div style="padding-top: 5%;">
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" HeaderStyle-CssClass="gvheader"
                            RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            DataKeyNames="RowNo" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Item ID" DataField="ItemID" Visible="false" />
                                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" DataFormatString="{0:n2}" />
                                <asp:BoundField HeaderText="Unit ID" DataField="UnitID" Visible="false" />
                                <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                                <asp:BoundField HeaderText="Price" DataField="Price" />
                            </Columns>
                            <HeaderStyle Height="25px" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="White" />
                        </asp:GridView>
                        <div style="text-align: right">
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text="Total :"></asp:Label>
                          <asp:TextBox ID="txtTotalSalePrice" Width="130px" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                         </div>
                    <div class="row" style="margin-top: 1%">

                        <div class="col-md-12">
                            <asp:GridView ID="gvSetItem" runat="server" AutoGenerateColumns="False" Width="100%"
                                CssClass="sGrid"
                                OnRowDataBound="gvSetItem_RowDataBound"
                                OnRowDeleting="gvSetItem_RowDeleting"
                                OnSelectedIndexChanged="gvSetItem_SelectedIndexChanged"
                                DataKeyNames="set_item_id" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif"
                                        SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                    <asp:BoundField DataField="ItemID" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="UnitID" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView>
                        </div>


                    </div>



                </div>

            </div>

        </div>
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>
