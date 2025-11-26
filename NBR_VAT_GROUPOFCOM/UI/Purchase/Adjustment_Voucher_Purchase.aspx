<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Purchase_Adjustment_Voucher_Purchase, App_Web_attcokcq" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
            }

            .full_width {
                width: 100%;
            }
        }

        .yesPrint {
            display: block !important;
        }

        input[type=text], select, textarea, .text_box {
            border: none;
        }
    </style>
    <style type="text/css">
        .style1 {
            height: 23px;
        }
    </style>

   
    <style type="text/css">
    .Hide
    {
        display: none;
    }

            .hiddencol {
            display: none;
        }

        h5 { 
            display: flex; 
            flex-direction: row; 
        } 
          
        h5:before, 
        h5:after { 
            content: ""; 
            flex: 1 1; 
            border-bottom: 1px solid #000; 
            margin: auto; 
        }

</style>

    <script type="text/javascript">
        function chkCheckedEvent() {
            var total = $("[id*=txtAmountOf]").val();
            total = total.replace(",", "");
            total = !isNaN(total) ? Number(total) : 0;

            var paid = 0;

            var payments =0;
            $.each(payments, function (index, value) {
                var amount = !isNaN($(value).val()) ? Number($(value).val()) : 0;
                paid += amount;
            });



            var remaining = total - paid;
            //var remains = Math.round(parseFloat(remaining).toFixed(8) * 100) / 100;
            // if (remaining < 0) { remaining = 0; } // for making remaining value 0;
            var remains = remaining;
            if ($("[id*=chkCash]").prop("checked")) {
                if (!$("[id*=txtCashAmount]").val()) { $("[id*=txtCashAmount]").val(remains); }
                $("[id*=txtCashAmount]").show();
            }
            else {
                $("[id*=txtCashAmount]").hide();
                $("[id*=txtCashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkPayOrder]").prop("checked")) {
                if (!$("[id*=txtPayOrderAmount]").val()) { $("[id*=txtPayOrderAmount]").val(remains); }
                $("[id*=txtPayOrderAmount]").show();
            }
            else {
                $("[id*=txtPayOrderAmount]").hide();
                $("[id*=txtPayOrderAmount]").val("");
            }

            /* -------------------------------------------------------- */

            //if ($("[id*=chkCheque]").prop("checked")) {
            //    if (!$("[id*=txtChequeAmount]").val()) { $("[id*=txtChequeAmount]").val(remains); }
            //    $("[id*=txtChequeAmount]").show();
            //}
            //else {
            //    $("[id*=txtChequeAmount]").hide();
            //    $("[id*=txtChequeAmount]").val("");
            //}
            if ($("[id*=chkCheque]").prop("checked")) {
                if (!$("[id*=txtChequeAmount]").val()) { $("[id*=txtChequeAmount]").val(remains); }
                $("[id*=txtChequeAmount]").show();
                $("[id*=lbl_transaction_id]").show();
                $("[id*=txt_transaction_id]").show();
            } else {
                $("[id*=txtChequeAmount]").hide();
                $("[id*=lbl_transaction_id]").hide();
                $("[id*=txt_transaction_id]").hide();
                $("[id*=txtChequeAmount]").val("");
            }
            /* -------------------------------------------------------- */

            if ($("[id*=chkBkash]").prop("checked")) {
                if (!$("[id*=txtbKashAmount]").val()) { $("[id*=txtbKashAmount]").val(remains); }
                $("[id*=txtbKashAmount]").show();
            }
            else {
                $("[id*=txtbKashAmount]").hide();
                $("[id*=txtbKashAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkTT]").prop("checked")) {
                if (!$("[id*=txtTPTAmount]").val()) { $("[id*=txtTPTAmount]").val(remains); }
                $("[id*=txtTPTAmount]").show();
            }
            else {
                $("[id*=txtTPTAmount]").hide();
                $("[id*=txtTPTAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkEFT]").prop("checked")) {
                if (!$("[id*=txtEFTAmount]").val()) { $("[id*=txtEFTAmount]").val(remains); }
                $("[id*=txtEFTAmount]").show();
            }
            else {
                $("[id*=txtEFTAmount]").hide();
                $("[id*=txtEFTAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=CheDebitCard]").prop("checked")) {
                if (!$("[id*=txtDebitCartAmount]").val()) { $("[id*=txtDebitCartAmount]").val(remains); }
                $("[id*=txtDebitCartAmount]").show();
            }
            else {
                $("[id*=txtDebitCartAmount]").hide();
                $("[id*=txtDebitCartAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=ChkOther]").prop("checked")) {
                if (!$("[id*=txtOthersAmount]").val()) { $("[id*=txtOthersAmount]").val(remains); }
                $("[id*=txtOthersAmount]").show();
            }
            else {
                $("[id*=txtOthersAmount]").hide();
                $("[id*=txtOthersAmount]").val("");
            }

            /* -------------------------------------------------------- */

            if ($("[id*=chkRocket]").prop("checked")) {
                if (!$("[id*=txtRocketAmount]").val()) { $("[id*=txtRocketAmount]").val(remains); }
                $("[id*=txtRocketAmount]").show();
            }
            else {
                $("[id*=txtRocketAmount]").hide();
                $("[id*=txtRocketAmount]").val("");
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Payable Adjustment Voucher
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">----</legend>
                            <div class="col-sm-4">
                                <div class=" control-label col-sm-5 label-font">
                                    <asp:Label ID="Label5" runat="server" Text="From Date:" />
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtFromDate" runat="server" type="text" class="form-input" placeholder="Enter From Date"
                                        onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);" BorderStyle="Solid"
                                        border-width="1px" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate" />
                                    <div style="width: auto">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFromDate"
                                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="Invalid date format in From Date." CssClass="litMessage" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class=" control-label col-sm-3 label-font">
                                    <asp:Label ID="Label6" runat="server" Text="To Date:" />
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtToDate" runat="server" onkeydown="return (event.keyCode!=13);"
                                        onkeyup="FormatIt(this);" BorderStyle="Solid" border-width="1px" type="text"
                                        class="form-input" placeholder="Enter To Date" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate" />
                                    <div style="width: auto">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtToDate"
                                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="Invalid date format in To Date." CssClass="litMessage" />
                                    </div>
                                    &nbsp;
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class=" control-label col-sm-3 label-font" style="width: 105px">
                                    <asp:Label ID="Label1" runat="server" Text="Party Name:" />
                                </div>
                                <div class=" dropdown col-sm-7" style="padding: 0px;">
                                    <asp:DropDownList ID="drpPartyName" runat="server" ReadOnly="true" class="present-address-tb-test select2"
                                        data-toggle="dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:Button ID="showBTN" runat="server" class="btn-btn" Style="background-color:#3B7CB5; float: right"
                                Text="Search" OnClick="showBTN_Click" />
                            <asp:TextBox ID="txtForChallan" runat="server" Visible="False"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="row">
                        <asp:GridView ID="gvCreditTransaction" runat="server" AutoGenerateColumns="False"
                            CssClass="sGrid" DataKeyNames="challan_id" Width="100%" Style="width: 97%; margin-left: 15px"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" OnRowDataBound="gvCreditTransaction_K_RowDataBound"
                            CellPadding="3" AutoGenerateSelectButton="True"
                            OnSelectedIndexChanged="gvCreditTransaction_SelectedIndexChanged"
                            AllowPaging="True" OnPageIndexChanging="gvCreditTransaction_PageIndexChanging"
                            PageSize="20">
                            <Columns>
                                <asp:BoundField HeaderText="Party Name" DataField="party_name" />
                                <%-- <asp:BoundField HeaderText="Item Name" DataField="item_name" />--%>
                                <asp:BoundField HeaderText="Challan Date" DataField="date" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                                <%-- <asp:BoundField HeaderText="Quantity" DataField="quantity" />--%>
                                <%--<asp:BoundField HeaderText="Actual Price" DataField="purchase_unit_price" />--%>
                                <%-- <asp:BoundField HeaderText="Vat" DataField="purchase_Vat" />--%>
                                <%-- <asp:BoundField HeaderText="SD" DataField="sd_rate" />--%>
                                <asp:BoundField DataField="vatable_price" HeaderText="Vatable Price" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Total" DataField="Total" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,#0.000}" FooterText="Total"/>
                                <asp:BoundField DataField="balance_due" HeaderText="Balance Due" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="vds" DataField="vds" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" FooterStyle-CssClass="Hide"/>
                                <asp:BoundField HeaderText="status" DataField="status" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" FooterStyle-CssClass="Hide"/>
                                <asp:BoundField HeaderText="vds" DataField="amount_without_vds" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" FooterStyle-CssClass="Hide"/>
                                 <%-- <asp:BoundField DataField="vat" HeaderText="VDS" />--%>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right"/>
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                    </div>
                </div>
                <div class="test-btn">
                    <div style="visibility: hidden">
                        <asp:Button ID="ClientButton" runat="server" Text="Select" class="test-btn-primary" />
                    </div>


                    <asp:Panel ID="ModalPanel" runat="server" Width="800" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color:white;text-align:center;font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;font:bold;background-color:cornflowerblue;">Payment Voucher</h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <p ID="txtFor" style="background-color: #ccc; width: 90%" runat="server"></p>
                            </div>
                            <br/>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label ID="Label2" runat="server" Text="Branch Name :" />
                                </div>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpBranchName" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label ID="Label8" runat="server" Text="Date :"></asp:Label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtTodaysDate" runat="server" AutoPostBack="True" placeholder="Enter Amount"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTodaysDate" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label ID="Label20" runat="server">Challan No. :</asp:Label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtRcvdFrom" runat="server" ReadOnly="true"></asp:TextBox>
                                    <button type="button" data-toggle="modal" data-target="#detailChallanModal">..</button>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label runat="server">Current Balance :</asp:Label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="tctCBalance" runat="server" type="text" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label ID="Label21" runat="server" CssClass="rqrd">Paying Amount :</asp:Label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtAmountOf" runat="server" placeholder="Enter Amount"
                                        AutoPostBack="True" OnTextChanged="txtAmountOf_TextChanged" style="background-color: lightgreen"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtForeignAmount_FilteredTextBoxExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtAmountOf" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label runat="server">Payable Amount :</asp:Label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtPaymentAmount" runat="server" type="text" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-3 text-right">
                                    <asp:Label runat="server">Particulars:</asp:Label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtParticulars" Width="225px" runat="server" type="text"></asp:TextBox>
                                    <%--<asp:TextBox ID="txtParticulars" Width="20px" runat="server" type="text"></asp:TextBox>--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-sm-5 text-right">
                                    <asp:Label runat="server">Balance Due :</asp:Label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtDue" runat="server" type="text" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <br/>
                        <div class="row">
                            <div><span id="vdsSpan" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-1"></span>
                                <span id="exemptedSpan" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-1"></span></div>
                            <div class="col-md-12">
                                
                                <span id="AITSpan" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-1"></span>
                                <span id="AITammount" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-1"></span>

                                <span id="trunVDS" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-1"></span>
                                <span id="trunVDSAmount" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-1"></span>

                                <%--added this below 4 lines instructed by ruhul bhai to show vds and aid on payment by sabbir 19/1/20--%>
                                <span id="payableVDS" runat="server" Visible="False" style="color: red; font-size: 12px; " class="col-sm-2">Deductible VDS:</span>
                                <span id="payableVDSAmount" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-2"></span>

                                <span id="payableAIT" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-2">Deductible AIT:</span>
                                <span id="payableAITAmount" runat="server" Visible="False" style="color: red; font-size: 12px;" class="col-sm-2"></span>



                            </div>
                        </div>

                        <br/>
                    
                        
                                <table id="paymentGateway" style="width: 100%;">
                                    <tr>
                                        <td colspan="4">
                                            <h2 style="color: white; text-align: center; font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; font: bold; background-color: cornflowerblue;">Check Payment Information</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkCash" runat="server" Text="Cash" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCashAmount" runat="server" type="text"  Style="display: none; width: 130px;"></asp:TextBox>
                                            <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtCashAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkPayOrder" runat="server" Style="margin-left: 10px" Visible="false" Text="Pay Order" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtPayOrderAmount" runat="server" CssClass="form-control" style="display:none;width:130px;" ></asp:TextBox>--%>
                                            <asp:TextBox ID="txtPayOrderAmount" runat="server"  type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" Enabled="True" TargetControlID="txtPayOrderAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkCheque" runat="server" Text="Cheque" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtChequeAmount" runat="server" CssClass="form-control" style="display:none;width:130px;"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtChequeAmount" runat="server" type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtChequeAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>

                                        <td>
                                            <asp:CheckBox ID="chkRocket" runat="server" Text="Rocket (DBBL Mobile)" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtRocketAmount" runat="server" CssClass="form-control" style="display:none;width:130px;"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtRocketAmount"  runat="server" type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" Enabled="True" TargetControlID="txtRocketAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkBkash" runat="server" Text="bKash" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtbKashAmount" runat="server" CssClass="form-control" style="display:none;width:130px;"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtbKashAmount"  runat="server" type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="txtbKashAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkTT" runat="server" Text="Telephone Transfer" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTPTAmount" runat="server"  type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" TargetControlID="txtTPTAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkEFT" runat="server" Text="EFT" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" ToolTip="Electronic Fund Transfer" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEFTAmount" runat="server" type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True" TargetControlID="txtEFTAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="CheDebitCard" runat="server" Style="margin-left: 10px" Text="Dr./Cr. Card" Visible="false" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDebitCartAmount" runat="server" type="text"  Style="display: none; width: 130px;"></asp:TextBox>
                                            <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True" TargetControlID="txtDebitCartAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="ChkOther" runat="server" Text="Other" Visible="false" Style="margin-left: 10px" onclick="chkCheckedEvent(this);" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOthersAmount" runat="server"  type="text" Style="display: none; width: 130px;"></asp:TextBox>
                                            <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True" TargetControlID="txtOthersAmount" FilterType="Numbers" FilterMode="ValidChars">
                                                                </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_transaction_id" Style="display: none;" runat="server" Text="Payment Info" ForeColor="red"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_transaction_id" Style="display: none;" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            
                        <div class="row">
                            <div class="col-md-12">
                                <table width="100%" style="border-width: 0px">
                                    <tr style="width: 100%">
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                        <td style="width: 40%; text-align: right">&nbsp;
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td style="width: 20%"></td>
                                        <td style="width: 0%"></td>
                                        <td style="width: 40%; text-align: right">
                                            <asp:Button ID="OKButton" runat="server" Style="background-color: #D9534F; float: right" CssClass="btn-btn" Text="Close"  OnClick="btnClose_Click" />
                                            <asp:Button ID="btnSubSave" runat="server" Style="background-color: #4CAF50; float: right" CssClass="btn-btn"
                                                        Text="Save" OnClick="btnSubSave_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    
                        <div class="modal fade" id="detailChallanModal" role="dialog">
                            <div class="modal-dialog modal-lg">
                
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">Challan Details</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12" id="detailChallanBody" runat="server">
                                                <!-- -->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" Style="background-color: #D9534F; color:white;" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                  
                            </div>
                        </div>
                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton"
                        BackgroundCssClass="modalPopup" PopupControlID="ModalPanel"/>
                    <asp:HiddenField ID="hdItemType" runat="server" />
                    <asp:HiddenField ID="hdBookId" runat="server" />
                    <asp:HiddenField ID="hdPageNo" runat="server" />
                    <%--  </div>--%>
                </div>
            </div>
        </div>
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
    <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 16.06.2021
            </div>    

</asp:Content>
