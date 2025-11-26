<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="AllChallanAudit, App_Web_qhrdyc5n" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <style>
        tr > td {
            padding: 5px;
        }

        tr > th {
            padding: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">All Challan Audit by NBR Authority</div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">Audit Part :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlAuditPart" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAuditPart_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                                <asp:ListItem Value="1">Local Purchase/Import</asp:ListItem>
                                                <asp:ListItem Value="2">Local Sale/Export</asp:ListItem>
                                                <asp:ListItem Value="3">Debit Note</asp:ListItem>
                                                <asp:ListItem Value="4">Credit Note</asp:ListItem>
                                                <asp:ListItem Value="5">VDS In Purchase</asp:ListItem>
                                                <asp:ListItem Value="6">VDS In Sales</asp:ListItem>
                                                <asp:ListItem Value="7">Rebate</asp:ListItem>
                                                <asp:ListItem Value="8">TR Challan</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="col-md-6" style="padding-left:0px;padding-right:0px">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right" style="padding-left:0px;">Date From :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateFrom" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6" style="padding-left:0px;padding-right:0px">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date To :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateTo" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-4 text-right">Items :</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-warning" Style="margin-top: -4px;" OnClick="btnSearch_Click"><i class="fa fa-search-plus"></i> Item</asp:LinkButton>
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-info" Style="margin-top: -4px;" OnClick="btnShow_Click"><i class="fa fa-clone"></i> Report</asp:LinkButton>
                                </div>
                                
                            </div>
                            <div class="row">
                                    <asp:Label runat="server" ID="lblAuditPartID" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblChallanID" Visible="false"></asp:Label>
                                    <fieldset class="scheduler-border" style="padding-left:0px;padding-right:0px">
                                        <legend class="scheduler-border">For NBR Authority</legend>
                                        <div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-5 text-right">Authority Name :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtNBRAuthorityName" runat="server" CssClass="form-control" Height="35px" MaxLength="120">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-4 text-right" style="padding-left:0px;"> Designation :</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox ID="txtAuthorityDesignation" runat="server" CssClass="form-control" Height="35px" MaxLength="120">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-4 text-right">Comment :</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox ID="txtNBRAuthorityComment" runat="server" CssClass="form-control" Height="35px" TextMode="MultiLine" Rows="3" MaxLength="500">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3" style="padding-left:0px;padding-right:0px">
                                            <asp:LinkButton ID="btnlnSingleChallan" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnlnSingleChallan_Click"><i class="fa fa-send"></i> This Challan</asp:LinkButton>
                                            <asp:LinkButton ID="btnlnAllChallan" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnlnAllChallan_Click"><i class="fa fa-send"></i> All Challan</asp:LinkButton>
                                        </div>
                                    </fieldset>
                               
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel panel-body">
                            <asp:GridView ID="gvNBRAChallan" runat="server" AutoGenerateColumns="False" DataKeyNames="challan_id"
                                HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" CssClass="sGrid"
                                OnRowCommand="gvNBRAChallan_RowCommand"
                                OnSelectedIndexChanged="gvNBRAChallan_SelectedIndexChanged"
                                Width="100%" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField HeaderText="SL.No." DataField="RowNo" />
                                    <asp:TemplateField HeaderText="Challan No.">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbChallanNo" runat="server" CommandArgument='<%# Eval("challan_id") %>' OnClick="lbChallanNo_Click"><%# Eval("challan_no") %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Challan Date" DataField="challan_date" />
                                    <asp:BoundField HeaderText="Party Name" DataField="party_name" />
                                    <asp:BoundField HeaderText="Total Amount" DataField="total_amount" DataFormatString="{0:n2}"/>
                                    <asp:BoundField HeaderText="Total Tax" DataField="total_tax" DataFormatString="{0:n2}"/>
                                    <asp:BoundField HeaderText="Grand Total" DataField="Grand_total" DataFormatString="{0:n2}"/>
                                </Columns>

                            </asp:GridView>
                            <asp:GridView ID="gvTreasuryChallan" runat="server" AutoGenerateColumns="false" DataKeyNames="challan_id"
                                HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" CssClass="sGrid"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="SL.No." DataField="RowNo" />
                                    <asp:BoundField HeaderText="Challan No." DataField="challan_no" />
                                    <asp:BoundField HeaderText="Treasury For" DataField="code_name" />
                                    <asp:BoundField HeaderText="Challan Date" DataField="challan_date" />
                                    <asp:BoundField HeaderText="Deposit Description" DataField="deposit_description" />
                                    <asp:BoundField HeaderText="Deposit Person" DataField="designation" />
                                    <asp:BoundField HeaderText="Barier Address" DataField="bearer_name_address" />
                                    <asp:BoundField HeaderText="Code No" DataField="code_no" />
                                    <asp:BoundField HeaderText="Amount" DataField="amount" DataFormatString="{0:n2}"/>
                                </Columns>
                                <SelectedRowStyle BackColor="BurlyWood" Font-Bold="true" />
                            </asp:GridView>
                            <asp:GridView ID="gvChallanItem" runat="server" AutoGenerateColumns="False"
                                HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" CssClass="sGrid"
                                Width="100%" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField HeaderText="SL.No." DataField="RowNo" />
                                    <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                                    <asp:BoundField HeaderText="Challan Date" DataField="challan_date" />
                                    <asp:BoundField HeaderText="Party" DataField="party_name" />
                                    <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                                    <asp:BoundField HeaderText="Unit Price" DataField="unit_price"  DataFormatString="{0:n2}"/>
                                    <asp:BoundField HeaderText="Tax" DataField="tax"  DataFormatString="{0:n2}"/>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="panel panel-primary" runat="server" id="pnl">
                        <div class="panel panel-heading text-center" style="height: 35px;">
                            <p>Details of Challan No:
                                <asp:Label runat="server" ID="lblChallanNo" Style="font-weight: bold"></asp:Label></p>
                        </div>
                        <div class="panel panel-body">
                            <asp:GridView ID="gvChallanDetails" runat="server" AutoGenerateColumns="False"
                                HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" CssClass="sGrid"
                                Width="100%" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                <Columns>
                                    <asp:BoundField HeaderText="SL.No." DataField="RowNo" />
                                    <asp:BoundField HeaderText="Item Name" DataField="item_name" />
                                    <asp:BoundField HeaderText="Unit" DataField="unit_code" />
                                    <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                                    <asp:BoundField HeaderText="Unit Price" DataField="unit_price" />
                                    <asp:BoundField HeaderText="Total" DataField="total" />
                                    <asp:BoundField HeaderText="Tax" DataField="tax" />
                                    <asp:BoundField HeaderText="Grand Total" DataField="grand_total" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

