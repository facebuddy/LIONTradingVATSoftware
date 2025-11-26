<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="SetItemOrders.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Item.SetItemOrders" %>



<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style media="print">
        {
          
        }
        .noPrint
        {
            display: none;
        }
        @media print
        {
            table
            {
                width: 100%;
            }
            tr, td
            {
            }
            .full_width
            {
                width: 100%;
            }
        }
        .yesPrint
        {
            display: block !important;
        }
        input[type=text], select, textarea, .text_box
        {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {

            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }



        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;
                    height: 30px; padding-top: 0px">
                    Set Item Order
                </div>

                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top:1%">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="label9" runat="server" Text="Category Name :" class="control-label col-sm-5" />
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-input select2" data-toggle="dropdown"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                                            Height="33px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="label1" runat="server" Text="Sub Category :" class="control-label col-sm-5" />
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpSubCategory" runat="server" class="form-input select2" data-toggle="dropdown"
                                            AutoPostBack="True" Height="33px" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="label10" runat="server" Text="Item Name :" class="control-label col-sm-5" />
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlItemName" runat="server" class="form-input select2" data-toggle="dropdown"
                                            OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged" Height="33px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                           
                    </div>

                    <div class="row">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="label2" runat="server" Text="Organization Branch :" class="control-label col-sm-5" />
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpBranchName" runat="server" class="form-input select2" data-toggle="dropdown"
                                            Height="33px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="label16" runat="server" Text="Set Order :" class="control-label col-sm-5" />
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input"  style="text-align:center"
                                        onkeypress="return isNumberKey(event)" MaxLength="2" ID="txtOrder" placeholder="">0</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                           
                           
                    </div>
                   <%-- <div class="row">
                        <fieldset class="scheduler-border">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <div class="col-sm-7">
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                </div>
                            </div>
                        </fieldset>
                    </div>--%>
                     
                </div>
                     <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="text-align: right">
                        <%-- <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Style="float: right"
                            Text="Save" OnClick="btnSave_Click" />
                   
                        <asp:Button ID="btnShowCommissionerateList" runat="server" CssClass="btn btn-success"
                            Style="float: right" Text="Show List" OnClick="btnShowCommissionerateList_Click" />
                   
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-success" Style="float: right"
                            OnClick="btnRefresh_Click" Text="Refresh" />--%>
                    </div>
                    <div class="row" style="text-align: right">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right"
                            Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnShowList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;width:100px;float: right"
                            Text="Show Item" OnClick="btnShowList_Click" />
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right"
                            OnClick="btnRefresh_Click" Text="Refresh" />
                    </div>
                </div>
                 </div>
        </div>
    </div>
           

                <div class="row" style="overflow: auto; height: 300px;">
                        <asp:GridView ID="dgvItemSort" runat="server" AutoGenerateColumns="False"  CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"  BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" PageSize="50" OnPageIndexChanging="dgvItemSort_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="item_name" HeaderText="Item Name">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
                                <asp:BoundField DataField="order_by" HeaderText="Order" />
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
           
    <%--<uc2:MsgBox ID="msgBox" runat="server" />--%>
<%--    <uc2:MsgBox ID="msgBox" runat="server" />--%>
    <uc1:MsgBoxs runat="server" id="msgBox" />
</asp:Content>

