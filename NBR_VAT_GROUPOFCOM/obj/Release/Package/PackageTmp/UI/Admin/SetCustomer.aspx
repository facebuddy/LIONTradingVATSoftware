<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="SetCustomer, App_Web_znns2ib5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-size: 15px; font-weight: bold;">Customer Setup</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Name :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerName" CssClass="form-control" />
                                            <asp:HiddenField runat="server" ID="hfCID" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerAddress" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Mobile :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerMobile" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Phone :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerPhone" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Email :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerEmail" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer Web :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerWeb" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Customer BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCustomerBIN" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Ultimate Destination :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbUltimateDestinition" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Owner Name :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbOwnerName" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Owner Phone :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbOwnerPhone" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Owner Email :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbOwnerEmail" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnSave" runat="server" style="float:right" CssClass="btn btn-primary btn-sm" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnClear" runat="server" style="float:right" CssClass="btn btn-danger btn-sm" Text="Clear" OnClick="btnClear_Click" />
                                    <%-- <asp:Button ID="btnShow" runat="server" CssClass="btn btn-primary" Text="Show all Party" onclick="btnShow_Click"  />--%>
                                    <asp:Button ID="btnRefresh" runat="server" style="float:right" CssClass="btn btn-success btn-sm" Text="Refresh" OnClick="btnRefresh_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <uc2:MsgBox ID="msgBox" runat="server" />
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <div class="table table-responsive">
                                <asp:GridView ID="gvCustomerList" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" CellPadding="3" CellSpacing="2"
                                    DataKeyNames="customer_id" style="width:100%" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                                    OnSelectedIndexChanged="gvCustomerList_SelectedIndexChanged"
                                    OnRowDeleting="gvCustomerList_RowDeleting"
                                    OnRowDataBound="gvCustomerList_RowDataBound"
                                    PageSize="10" AllowPaging="true" OnPageIndexChanging="gvCustomerList_PageIndexChanging">
                                    <Columns>
                                        <asp:CommandField HeaderText="Edit" ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                        <asp:BoundField HeaderText="Customer Name" DataField="customer_name" />
                                        <asp:BoundField HeaderText="Customer Address" DataField="customer_address" />
                                        <asp:BoundField HeaderText="Customer BIN" DataField="customer_bin" />
                                        <asp:BoundField HeaderText="Customer Phone" DataField="customer_phone" />
                                        <asp:BoundField HeaderText="Owner Name" DataField="owner_name" />
                                        <asp:CommandField HeaderText="Remove" ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
