<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="VDS_Monitorings.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.VDS_Monitorings" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <script type="text/javascript">
        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;
            var jsGvChallanItem = document.getElementById("<%=gvLocalPurchase.ClientID%>");

            var IsChecked = chkB.checked;
            if (IsChecked) {
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else {
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }
        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvLocalPurchase.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked != IsChecked) {
                        items[i].click();
                    }
                }
            }

        }

    </script>
    <script type="text/javascript">
        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;
            var jsGvChallanItem = document.getElementById("<%=gvImport.ClientID%>");

            var IsChecked = chkB.checked;
            if (IsChecked) {
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else {
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }
        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;
            var Chk = spanChk;

            var jsGvItem = document.getElementById("<%=gvImport.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked != IsChecked) {
                        items[i].click();
                    }
                }
            }

        }

    </script>
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">উৎসে কর কর্তন মনিটরিং</div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row" style="margin-top: 1%">
                                <div class="col-sm-6">
                                    <div class="col-sm-6" style="padding: 0px">
                                        <asp:Label ID="Label2" runat="server" Text="Date From:" class="present-address-lbl" Style="margin-left: 15%; margin-top: 5px"></asp:Label>
                                        <asp:TextBox ID="dtpDateFrom" runat="server" Style="width: 60%; margin-left: 38%" class="present-address-tb" dateformat="dd/MM/yyyy" placeholder="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtTransferOrderDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="dtpDateFrom">
                                        </cc1:CalendarExtender>
                                        <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="dtpDateFrom"
                                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="Invalid date format in From Date." CssClass="litMessage" />
                                    </div>
                                    <div class="col-sm-6" style="padding: 0px">
                                        <asp:Label ID="Label1" runat="server" Text="Date To:" class="present-address-lbl" Style="margin-top: 5px; margin-left: 8%"></asp:Label>
                                        <asp:TextBox ID="dtpDateTo" runat="server" Style="width: 60%; margin-left: 26%;" class="present-address-tb" dateformat="dd/MM/yyyy" placeholder="dd/MM/yyyy" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" MaxLength="10"></asp:TextBox>
                                        <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                                        <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="dtpDateTo"
                                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="Invalid date format in To Date." CssClass="litMessage" />

                                    </div>
                                </div>
                                <div class="col-sm-6" style="padding: 0px;">
                                    <asp:Label ID="Label6" runat="server" class="present-address-lbl" Text="Party Name:" Style="float: left; margin-top: 5px" />
                                    <asp:DropDownList runat="server" ID="drpParty" class="present-address-tb select2" Style="float: left; width: 37%; text-align: left">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearch" runat="server" class="btn-btn" OnClick="btnSearch_Click" Text="Search"  Style="background-color:#3B7CB5;" />
                                    <asp:Button ID="btnShow" runat="server" class="btn-btn" OnClick="btnShow_Click" Text="Show History" Style="background-color:#5CB85C;" />
                                    <%--<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />--%>
                                    <asp:TextBox runat="server" ID="txtChallan" Visible="false" />
                                </div>
                          <%--      <uc2:MsgBox ID="msgBox" runat="server" />--%>
                                <uc1:MsgBoxs runat="server" ID="msgBox" />
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading" runat="server" id="localPurchase" visible="false" style="text-align: center; font-size: 14px; font-weight: bold; height: 20px; padding-top: 0px">Local Purchase</div>
                        <div class="panel-body">
                            <div class="" runat="server" id="gridviewPurchase" visible="true">
                                <asp:GridView ID="gvLocalPurchase" runat="server" AutoGenerateColumns="False"
                                    OnSelectedIndexChanged="gvLocalPurchase_SelectedIndexChanged" CssClass="sGrid" DataKeyNames="RowID" Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Challan No" DataField="ChallanNo" />
                                        <asp:BoundField HeaderText="Challan Date" DataField="ChallanDate" />
                                        <asp:BoundField HeaderText="Total Amount" DataField="TotalAmount" />
                                         <asp:BoundField HeaderText="Amount" DataField="amount" />
                                        <asp:BoundField HeaderText="VAT" DataField="Vat" />
                                        <asp:BoundField HeaderText="SD" DataField="SD" />
                                        <asp:BoundField HeaderText="VDS" DataField="IsVDS" />
                                        <asp:BoundField HeaderText="Party Name" DataField="PartyName" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="row_no" Value='<%# Eval("RowId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading" runat="server" visible="false" id="import" style="text-align: center; font-size: 14px; font-weight: bold; height: 20px; padding-top: 0px">Import</div>
                        <div class="panel-body">
                            <div class="" runat="server" id="gridviewSale" visible="true">
                                <asp:GridView ID="gvImport" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvImport_SelectedIndexChanged"
                                    CssClass="sGrid" DataKeyNames="RowID" Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Challan No" DataField="ChallanNo" />
                                        <asp:BoundField HeaderText="Challan Date" DataField="ChallanDate" />
                                        <asp:BoundField HeaderText="Total Amount" DataField="TotalAmount" />
                                        <asp:BoundField HeaderText="Amount" DataField="amount" />
                                        <asp:BoundField HeaderText="VAT" DataField="Vat" />
                                        <asp:BoundField HeaderText="SD" DataField="SD" />
                                        <asp:BoundField HeaderText="CD" DataField="CD" />
                                        <asp:BoundField HeaderText="RD" DataField="RD" />
                                        <asp:BoundField HeaderText="AIT" DataField="AIT" />
                                        <asp:BoundField HeaderText="ATV" DataField="ATV" Visible="False" />
                                        <asp:BoundField HeaderText="TTI" DataField="TTI" />
                                        <asp:BoundField HeaderText="VDS" DataField="IsVDS" />
                                        <asp:BoundField HeaderText="Party Name" DataField="PartyName" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="pnLocalPurchase" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 80%; margin-left: 9%;">
                <div class="row" style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Style="font-size: 22px; font-weight: bold">Local Purchase Details</asp:Label>
                </div>
                <div class="row" style="margin-top: -4px; margin-right: 1%; margin-left: 1%;">
                    <asp:GridView ID="gvPurchase2" runat="server" AutoGenerateColumns="False"
                        CssClass="sGrid" DataKeyNames="RowId" Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                            <asp:BoundField HeaderText="Challan Date" DataField="challan_date" />
                            <asp:BoundField HeaderText="Item" DataField="item" />
                            <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                            <asp:BoundField HeaderText="Unit Price" DataField="unit_price" />
                            <asp:BoundField HeaderText="VAT" DataField="vat" />
                            <asp:BoundField HeaderText="SD" DataField="sd" />
                            <asp:BoundField HeaderText="VDS" DataField="is_vds" />
                            <asp:BoundField HeaderText="Party Name" DataField="party" />
                              <asp:BoundField HeaderText="Payment Status" DataField="payment" />
                            <asp:BoundField HeaderText="TR Challan No." DataField="tr_challan_no" />
                            <asp:BoundField HeaderText="TR Challan Date" DataField="tr_challan_date" DataFormatString="{0:dd/MM/yyyy}" />
                      <%--      <asp:TemplateField HeaderText="VDS Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdate" Text='<%#Eval("opening_balance_date") %>' runat="server" DateFormat="dd/MM/yyyy" CssClass="input-short-bst"></asp:TextBox>
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate" />
                                                
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="row_no" Value='<%# Eval("RowId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                </div>
                <div>
                    <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="test-btn-primary hiddencol" Style="margin-right: 12px; float: right"
                        ValidationGroup="addCategory" OnClick="btnUpdate_Click" />
                    &nbsp;
                <asp:Button ID="btnCatClear" runat="server" Text="Close" CssClass="test-btn-primary" Style="float: right" />
                </div>
            </div>
            <asp:Button ID="btnHiddenForLocalPurchase" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="modalPopupForLocalPurchase" runat="server" PopupControlID="pnLocalPurchase"
                TargetControlID="btnHiddenForLocalPurchase" BackgroundCssClass="mpBack">
            </cc1:ModalPopupExtender>

            <div id="pnImportDetail" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 80%; margin-left: 9%;">
                <div class="row" style="text-align: center">
                    <asp:Label ID="Label4" runat="server" Style="font-size: 22px; font-weight: bold">Import Details</asp:Label>
                </div>
                <div class="row" style="margin-top: -4px; margin-right: 1%; margin-left: 1%;">
                    <asp:GridView ID="gvImport2" runat="server" AutoGenerateColumns="False"
                        CssClass="sGrid" DataKeyNames="RowId" Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                            <asp:BoundField HeaderText="Challan Date" DataField="challan_date" />
                            <asp:BoundField HeaderText="Item" DataField="item" />
                            <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                            <asp:BoundField HeaderText="Unit Price" DataField="unit_price" />
                            <asp:BoundField HeaderText="VAT" DataField="vat" />
                            <asp:BoundField HeaderText="SD" DataField="sd" />
                            <asp:BoundField HeaderText="CD" DataField="cd" />
                            <asp:BoundField HeaderText="RD" DataField="rd" />
                            <asp:BoundField HeaderText="AIT" DataField="ait" />
                            <asp:BoundField HeaderText="ATV" DataField="atv" Visible="False" />
                            <asp:BoundField HeaderText="TTI" DataField="tti" />
                            <asp:BoundField HeaderText="VDS" DataField="is_vds" />
                            <asp:BoundField HeaderText="Party Name" DataField="party" />
                            <asp:BoundField HeaderText="TR Challan No." DataField="tr_challan_no" />
                            <asp:BoundField HeaderText="TR Challan Date" DataField="tr_challan_date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="row_no" Value='<%# Eval("RowId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                </div>
                <div>
                    <asp:Button ID="btnImportUpdate" runat="server" Text="Save" CssClass="test-btn-primary" Style="margin-right: 12px; float: right"
                        ValidationGroup="addCategory" OnClick="btnImportUpdate_Click" />
                    &nbsp;
    <asp:Button ID="btnImportClear" runat="server" Text="Close" CssClass="test-btn-primary" Style="float: right" />
                </div>
            </div>
            <asp:Button ID="btnHiddenForImport" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="modalPopupForImportDetail" runat="server" PopupControlID="pnImportDetail"
                TargetControlID="btnHiddenForImport" BackgroundCssClass="mpBack">
            </cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
